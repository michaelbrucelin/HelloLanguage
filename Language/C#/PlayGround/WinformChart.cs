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
        // 绘制图表示例
        // data是数据源，每个KeyValuePair对应一个Series，其中Key可以作为Series的Legend使用，而Value仍然是一个字典，每个KeyValuePair对应一个Point
        public void DrawChar(Dictionary<string, Dictionary<int, int>> data)
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
                chart1.Series[pnum].ChartType = SeriesChartType.Line;

                for (int i = 0; i < 288 + 1; i++)
                {
                    if (points.ContainsKey(i))
                        chart1.Series[pnum].Points.Add(points[i]);
                    else
                        chart1.Series[pnum].Points.Add(0);
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
            int[] intervals = new int[] { -1, 1, 2, 5, 10, 25, 50, 100, 250, 500, 1000, 2500, 5000, 10000, int.MaxValue };
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
    }
}
