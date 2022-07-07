using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestCSharp
{
    class Program
    {
        private Point? prevPosition = null;       // 用于Chart显示鼠标指向点的数据信息
        private ToolTip tooltip = new ToolTip();  // 用于Chart显示鼠标指向点的数据信息

        /// <summary>
        /// 绘制Chart
        /// </summary>
        /// <param name="data">data是数据源，每个KeyValuePair对应一个Series，其中Key可以作为Series的Legend使用，而Value仍然是一个字典，每个KeyValuePair对应一个Point</param>
        private void DrawChar(Dictionary<string, Dictionary<int, int>> data)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            Title title = chart1.Titles.Add("通 话 性 能");
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            chart1.Legends[0].Docking = Docking.Top;             // 图例的位置

            foreach (string pnum in data.Keys)
            {
                Dictionary<int, int> points = data[pnum];
                chart1.Series.Add(pnum);
                chart1.Series[pnum].ChartType = SeriesChartType.Line;  // 折线图，默认是柱状图

                for (int i = 0; i < 288 + 1; i++)
                {
                    if (points.ContainsKey(i))
                        // chart1.Series[pnum].Points.Add(points[i]);
                        chart1.Series[pnum].Points.AddXY(i, points[i]);
                    else
                        // chart1.Series[pnum].Points.Add(0);
                        chart1.Series[pnum].Points.AddXY(i, 0);
                }
            }

            // X轴刻度
            DateTime t = DateTime.Parse("00:00");
            for (int i = 0; i < 288 + 1; i++)
            {
                if (i % 12 == 0)
                {
                    CustomLabel xlabel = new CustomLabel();

                    xlabel.Text = t.ToString("HH");
                    xlabel.FromPosition = i - 1;
                    xlabel.ToPosition = i + 1;
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(xlabel);

                    xlabel.GridTicks = GridTickTypes.Gridline;
                    t = t.AddHours(1);
                }
            }

            // Y轴刻度
            int y_max = 0;  // Y轴最大刻度，用于定义Y轴刻度间隔
            foreach (Dictionary<int, int> item in data.Values)
            {
                int max = item.Values.Max();
                if (max > y_max)
                    y_max = max;
            }
            int[] intervals = new int[] { -1, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, int.MaxValue };
            int y_interval = intervals.Where(i => i <= y_max / 24).Max();
            chart1.ChartAreas[0].AxisY.Interval = y_interval == -1 ? 1 : y_interval;

            // Y轴Title
            chart1.ChartAreas[0].AxisY.Title = "并 发 数 量";
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12);

            // 网格线
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(234, 234, 234);
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.FromArgb(234, 234, 234);
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(234, 234, 234);
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.FromArgb(234, 234, 234);
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
        }

        /// <summary>
        /// 实现鼠标在某条折线上时，改折线变粗，并显示对应点的值
        /// 参考：https://stackoverflow.com/questions/33978447/display-tooltip-when-mouse-over-the-line-chart
        /// Point? prevPosition = null;
        /// ToolTip tooltip = new ToolTip();
        /// 
        /// private void chart_MouseMove(object sender, MouseEventArgs e)
        /// {
        ///     var pos = e.Location;
        ///     if (prevPosition.HasValue && pos == prevPosition.Value)
        ///         return;
        ///     tooltip.RemoveAll();
        ///     prevPosition = pos;
        ///     var results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
        ///     foreach (var result in results)
        ///     {
        ///         if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
        ///         {
        ///             var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
        ///             tooltip.Show(((int)yVal).ToString(), chart, pos.X, pos.Y - 15);
        ///         }
        ///     }
        /// }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;

            Point pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;

            tooltip.RemoveAll();
            prevPosition = pos;

            // Set ChartElementType.PlottingArea for full area, not only DataPoints
            HitTestResult[] results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    result.Series.BorderWidth = 2;  // 默认为1

                    int x_val = (int)result.ChartArea.AxisX.PixelPositionToValue(pos.X);     // x轴的值
                    // int y_val = (int)result.ChartArea.AxisY.PixelPositionToValue(pos.Y);  // y轴的值，并不是Series中点的Y值

                    DataPoint point = result.Series.Points[x_val];                           // Series中的点
                    int y_val = (int)point.YValues[0];                                       // Series中点的Y值

                    DateTime t = DateTime.Parse("00:00");
                    tooltip.Show($"({t.AddMinutes(x_val * 5).ToString("HH:mm")}, {y_val})", chart, pos.X, pos.Y - 12);
                }
                else
                {
                    foreach (Series s in chart.Series)
                        s.BorderWidth = 1;
                }
            }
        }
    }
}
