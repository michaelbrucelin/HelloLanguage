namespace HrmSalaryFmt
{
    partial class Home
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSrcPath = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.txtTgtPath = new System.Windows.Forms.TextBox();
            this.BtnBrowse2 = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSrcPath
            // 
            this.txtSrcPath.AllowDrop = true;
            this.txtSrcPath.Location = new System.Drawing.Point(12, 12);
            this.txtSrcPath.Name = "txtSrcPath";
            this.txtSrcPath.ReadOnly = true;
            this.txtSrcPath.Size = new System.Drawing.Size(479, 21);
            this.txtSrcPath.TabIndex = 0;
            this.txtSrcPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSrcPath_DragDrop);
            this.txtSrcPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSrcPath_DragEnter);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(497, 12);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 21);
            this.BtnBrowse.TabIndex = 1;
            this.BtnBrowse.Text = "浏览";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(497, 66);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 21);
            this.btnGen.TabIndex = 2;
            this.btnGen.Text = "生成";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // txtTgtPath
            // 
            this.txtTgtPath.AllowDrop = true;
            this.txtTgtPath.Location = new System.Drawing.Point(12, 39);
            this.txtTgtPath.Name = "txtTgtPath";
            this.txtTgtPath.ReadOnly = true;
            this.txtTgtPath.Size = new System.Drawing.Size(479, 21);
            this.txtTgtPath.TabIndex = 3;
            this.txtTgtPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTgtPath_DragDrop);
            this.txtTgtPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTgtPath_DragEnter);
            // 
            // BtnBrowse2
            // 
            this.BtnBrowse2.Location = new System.Drawing.Point(497, 39);
            this.BtnBrowse2.Name = "BtnBrowse2";
            this.BtnBrowse2.Size = new System.Drawing.Size(75, 21);
            this.BtnBrowse2.TabIndex = 4;
            this.BtnBrowse2.Text = "浏览";
            this.BtnBrowse2.UseVisualStyleBackColor = true;
            this.BtnBrowse2.Click += new System.EventHandler(this.BtnBrowse2_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(12, 90);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(29, 12);
            this.lblTip.TabIndex = 5;
            this.lblTip.Text = "Tips";
            this.lblTip.Click += new System.EventHandler(this.lblTip_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.BtnBrowse2);
            this.Controls.Add(this.txtTgtPath);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.txtSrcPath);
            this.MaximumSize = new System.Drawing.Size(600, 200);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrcPath;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox txtTgtPath;
        private System.Windows.Forms.Button BtnBrowse2;
        private System.Windows.Forms.Label lblTip;
    }
}

