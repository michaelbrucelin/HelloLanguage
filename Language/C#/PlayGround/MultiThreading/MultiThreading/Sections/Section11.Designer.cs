
namespace MultiThreading
{
    partial class Section11
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
            this.btnSameLock = new System.Windows.Forms.Button();
            this.btnDiffLock = new System.Windows.Forms.Button();
            this.btnPublicLock = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 90);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnSameLock);
            this.flp1.Controls.Add(this.btnDiffLock);
            this.flp1.Controls.Add(this.btnPublicLock);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnSameLock
            // 
            this.btnSameLock.Location = new System.Drawing.Point(3, 3);
            this.btnSameLock.Name = "btnSameLock";
            this.btnSameLock.Size = new System.Drawing.Size(100, 23);
            this.btnSameLock.TabIndex = 1;
            this.btnSameLock.Text = "同一个锁";
            this.btnSameLock.UseVisualStyleBackColor = true;
            this.btnSameLock.Click += new System.EventHandler(this.btnSameLock_Click);
            // 
            // btnDiffLock
            // 
            this.btnDiffLock.Location = new System.Drawing.Point(3, 32);
            this.btnDiffLock.Name = "btnDiffLock";
            this.btnDiffLock.Size = new System.Drawing.Size(100, 23);
            this.btnDiffLock.TabIndex = 2;
            this.btnDiffLock.Text = "独立的锁";
            this.btnDiffLock.UseVisualStyleBackColor = true;
            this.btnDiffLock.Click += new System.EventHandler(this.btnDiffLock_Click);
            // 
            // btnPublicLock
            // 
            this.btnPublicLock.Location = new System.Drawing.Point(3, 61);
            this.btnPublicLock.Name = "btnPublicLock";
            this.btnPublicLock.Size = new System.Drawing.Size(100, 23);
            this.btnPublicLock.TabIndex = 3;
            this.btnPublicLock.Text = "public lock";
            this.btnPublicLock.UseVisualStyleBackColor = true;
            this.btnPublicLock.Click += new System.EventHandler(this.btnPublicLock_Click);
            // 
            // Section11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "锁的共用问题";
            this.Load += new System.EventHandler(this.Section11_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnSameLock;
        private System.Windows.Forms.Button btnDiffLock;
        private System.Windows.Forms.Button btnPublicLock;
    }
}