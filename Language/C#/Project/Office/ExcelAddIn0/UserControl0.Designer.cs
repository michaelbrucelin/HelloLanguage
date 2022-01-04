namespace ExcelAddIn0
{
    partial class UserControl0
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtShow = new System.Windows.Forms.TextBox();
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tlp1.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.Color.Silver;
            this.txtShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShow.Location = new System.Drawing.Point(0, 20);
            this.txtShow.Margin = new System.Windows.Forms.Padding(0);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.Size = new System.Drawing.Size(300, 480);
            this.txtShow.TabIndex = 0;
            this.txtShow.Text = "Hello World";
            // 
            // tlp1
            // 
            this.tlp1.ColumnCount = 1;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Controls.Add(this.txtShow, 0, 1);
            this.tlp1.Controls.Add(this.pnl1, 0, 0);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp1.Location = new System.Drawing.Point(0, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 2;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp1.Size = new System.Drawing.Size(300, 500);
            this.tlp1.TabIndex = 1;
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.txtRange);
            this.pnl1.Controls.Add(this.btnLoad);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Margin = new System.Windows.Forms.Padding(0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(300, 20);
            this.pnl1.TabIndex = 1;
            // 
            // txtRange
            // 
            this.txtRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRange.Font = new System.Drawing.Font("宋体", 8F);
            this.txtRange.Location = new System.Drawing.Point(0, 0);
            this.txtRange.Margin = new System.Windows.Forms.Padding(0);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(225, 20);
            this.txtRange.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(225, 0);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 20);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // UserControl0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp1);
            this.Name = "UserControl0";
            this.Size = new System.Drawing.Size(300, 500);
            this.Load += new System.EventHandler(this.UserControl0_Load);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Button btnLoad;
    }
}
