
namespace MultiThreading
{
    partial class Section16
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClear = new System.Windows.Forms.Button();
            this.flp1 = new System.Windows.Forms.FlowLayoutPanel();
            this.spl1 = new System.Windows.Forms.SplitContainer();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnAsync2 = new System.Windows.Forms.Button();
            this.btnAsync3 = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl1)).BeginInit();
            this.spl1.Panel1.SuspendLayout();
            this.spl1.Panel2.SuspendLayout();
            this.spl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 119);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnSync);
            this.flp1.Controls.Add(this.btnAsync);
            this.flp1.Controls.Add(this.btnAsync2);
            this.flp1.Controls.Add(this.btnAsync3);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(106, 322);
            this.flp1.TabIndex = 0;
            // 
            // spl1
            // 
            this.spl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spl1.Location = new System.Drawing.Point(0, 0);
            this.spl1.Name = "spl1";
            // 
            // spl1.Panel1
            // 
            this.spl1.Panel1.Controls.Add(this.flp1);
            // 
            // spl1.Panel2
            // 
            this.spl1.Panel2.Controls.Add(this.txtShow);
            this.spl1.Size = new System.Drawing.Size(784, 322);
            this.spl1.SplitterDistance = 106;
            this.spl1.TabIndex = 1;
            // 
            // txtShow
            // 
            this.txtShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShow.Location = new System.Drawing.Point(0, 0);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(674, 322);
            this.txtShow.TabIndex = 0;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(3, 3);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(100, 23);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(3, 32);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(100, 23);
            this.btnAsync.TabIndex = 2;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnAsync2
            // 
            this.btnAsync2.Location = new System.Drawing.Point(3, 61);
            this.btnAsync2.Name = "btnAsync2";
            this.btnAsync2.Size = new System.Drawing.Size(100, 23);
            this.btnAsync2.TabIndex = 3;
            this.btnAsync2.Text = "Async2";
            this.btnAsync2.UseVisualStyleBackColor = true;
            this.btnAsync2.Click += new System.EventHandler(this.btnAsync2_Click);
            // 
            // btnAsync3
            // 
            this.btnAsync3.Location = new System.Drawing.Point(3, 90);
            this.btnAsync3.Name = "btnAsync3";
            this.btnAsync3.Size = new System.Drawing.Size(100, 23);
            this.btnAsync3.TabIndex = 4;
            this.btnAsync3.Text = "Async3";
            this.btnAsync3.UseVisualStyleBackColor = true;
            this.btnAsync3.Click += new System.EventHandler(this.btnAsync3_Click);
            // 
            // Section16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 322);
            this.Controls.Add(this.spl1);
            this.MaximumSize = new System.Drawing.Size(800, 360);
            this.MinimumSize = new System.Drawing.Size(800, 360);
            this.Name = "Section16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Async/Await示例03";
            this.Load += new System.EventHandler(this.Section16_Load);
            this.flp1.ResumeLayout(false);
            this.spl1.Panel1.ResumeLayout(false);
            this.spl1.Panel2.ResumeLayout(false);
            this.spl1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spl1)).EndInit();
            this.spl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.SplitContainer spl1;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnAsync2;
        private System.Windows.Forms.Button btnAsync3;
    }
}