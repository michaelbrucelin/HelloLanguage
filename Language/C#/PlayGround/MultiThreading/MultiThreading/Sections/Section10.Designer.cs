
namespace MultiThreading
{
    partial class Section10
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
            this.btnUnLock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnMonitorEnter = new System.Windows.Forms.Button();
            this.btnMonitorTryEnter = new System.Windows.Forms.Button();
            this.btnException = new System.Windows.Forms.Button();
            this.btnNoMonitor = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 206);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnUnLock);
            this.flp1.Controls.Add(this.btnLock);
            this.flp1.Controls.Add(this.btnMonitor);
            this.flp1.Controls.Add(this.btnNoMonitor);
            this.flp1.Controls.Add(this.btnMonitorEnter);
            this.flp1.Controls.Add(this.btnMonitorTryEnter);
            this.flp1.Controls.Add(this.btnException);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnUnLock
            // 
            this.btnUnLock.Location = new System.Drawing.Point(3, 3);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(100, 23);
            this.btnUnLock.TabIndex = 1;
            this.btnUnLock.Text = "UnLock";
            this.btnUnLock.UseVisualStyleBackColor = true;
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(3, 32);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(100, 23);
            this.btnLock.TabIndex = 2;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(3, 61);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(100, 23);
            this.btnMonitor.TabIndex = 3;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnMonitorEnter
            // 
            this.btnMonitorEnter.Location = new System.Drawing.Point(3, 119);
            this.btnMonitorEnter.Name = "btnMonitorEnter";
            this.btnMonitorEnter.Size = new System.Drawing.Size(120, 23);
            this.btnMonitorEnter.TabIndex = 5;
            this.btnMonitorEnter.Text = "Monitor Enter";
            this.btnMonitorEnter.UseVisualStyleBackColor = true;
            this.btnMonitorEnter.Click += new System.EventHandler(this.btnMonitorEnter_Click);
            // 
            // btnMonitorTryEnter
            // 
            this.btnMonitorTryEnter.Location = new System.Drawing.Point(3, 148);
            this.btnMonitorTryEnter.Name = "btnMonitorTryEnter";
            this.btnMonitorTryEnter.Size = new System.Drawing.Size(120, 23);
            this.btnMonitorTryEnter.TabIndex = 6;
            this.btnMonitorTryEnter.Text = "Monitor TryEnter";
            this.btnMonitorTryEnter.UseVisualStyleBackColor = true;
            this.btnMonitorTryEnter.Click += new System.EventHandler(this.btnMonitorTryEnter_Click);
            // 
            // btnException
            // 
            this.btnException.Location = new System.Drawing.Point(3, 177);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(100, 23);
            this.btnException.TabIndex = 7;
            this.btnException.Text = "Exception";
            this.btnException.UseVisualStyleBackColor = true;
            this.btnException.Click += new System.EventHandler(this.btnException_Click);
            // 
            // btnNoMonitor
            // 
            this.btnNoMonitor.Location = new System.Drawing.Point(3, 90);
            this.btnNoMonitor.Name = "btnNoMonitor";
            this.btnNoMonitor.Size = new System.Drawing.Size(120, 23);
            this.btnNoMonitor.TabIndex = 4;
            this.btnNoMonitor.Text = "No Monitor";
            this.btnNoMonitor.UseVisualStyleBackColor = true;
            this.btnNoMonitor.Click += new System.EventHandler(this.btnNoMonitor_Click);
            // 
            // Section10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "多线程安全问题";
            this.Load += new System.EventHandler(this.Section10_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnUnLock;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnException;
        private System.Windows.Forms.Button btnMonitorTryEnter;
        private System.Windows.Forms.Button btnMonitorEnter;
        private System.Windows.Forms.Button btnNoMonitor;
    }
}