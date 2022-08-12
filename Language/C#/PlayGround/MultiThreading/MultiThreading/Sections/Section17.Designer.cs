
namespace MultiThreading
{
    partial class Section17
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
            this.btnUITrue = new System.Windows.Forms.Button();
            this.btnUIFalse = new System.Windows.Forms.Button();
            this.btnLibTrue = new System.Windows.Forms.Button();
            this.btnLibFalse = new System.Windows.Forms.Button();
            this.spl1 = new System.Windows.Forms.SplitContainer();
            this.txtShow = new System.Windows.Forms.TextBox();
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
            this.flp1.Controls.Add(this.btnUITrue);
            this.flp1.Controls.Add(this.btnUIFalse);
            this.flp1.Controls.Add(this.btnLibTrue);
            this.flp1.Controls.Add(this.btnLibFalse);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(106, 322);
            this.flp1.TabIndex = 0;
            // 
            // btnUITrue
            // 
            this.btnUITrue.Location = new System.Drawing.Point(3, 3);
            this.btnUITrue.Name = "btnUITrue";
            this.btnUITrue.Size = new System.Drawing.Size(100, 23);
            this.btnUITrue.TabIndex = 1;
            this.btnUITrue.Text = "UITrue";
            this.btnUITrue.UseVisualStyleBackColor = true;
            this.btnUITrue.Click += new System.EventHandler(this.btnUITrue_Click);
            // 
            // btnUIFalse
            // 
            this.btnUIFalse.Location = new System.Drawing.Point(3, 32);
            this.btnUIFalse.Name = "btnUIFalse";
            this.btnUIFalse.Size = new System.Drawing.Size(100, 23);
            this.btnUIFalse.TabIndex = 2;
            this.btnUIFalse.Text = "UIFalse";
            this.btnUIFalse.UseVisualStyleBackColor = true;
            this.btnUIFalse.Click += new System.EventHandler(this.btnUIFalse_Click);
            // 
            // btnLibTrue
            // 
            this.btnLibTrue.Location = new System.Drawing.Point(3, 61);
            this.btnLibTrue.Name = "btnLibTrue";
            this.btnLibTrue.Size = new System.Drawing.Size(100, 23);
            this.btnLibTrue.TabIndex = 3;
            this.btnLibTrue.Text = "LibTrue";
            this.btnLibTrue.UseVisualStyleBackColor = true;
            this.btnLibTrue.Click += new System.EventHandler(this.btnLibTrue_Click);
            // 
            // btnLibFalse
            // 
            this.btnLibFalse.Location = new System.Drawing.Point(3, 90);
            this.btnLibFalse.Name = "btnLibFalse";
            this.btnLibFalse.Size = new System.Drawing.Size(100, 23);
            this.btnLibFalse.TabIndex = 4;
            this.btnLibFalse.Text = "LibFalse";
            this.btnLibFalse.UseVisualStyleBackColor = true;
            this.btnLibFalse.Click += new System.EventHandler(this.btnLibFalse_Click);
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
            // Section17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 322);
            this.Controls.Add(this.spl1);
            this.MaximumSize = new System.Drawing.Size(800, 360);
            this.MinimumSize = new System.Drawing.Size(800, 360);
            this.Name = "Section17";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigAwait示例";
            this.Load += new System.EventHandler(this.Section17_Load);
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
        private System.Windows.Forms.Button btnUITrue;
        private System.Windows.Forms.Button btnUIFalse;
        private System.Windows.Forms.Button btnLibTrue;
        private System.Windows.Forms.Button btnLibFalse;
    }
}