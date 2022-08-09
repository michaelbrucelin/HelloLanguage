
namespace MultiThreading
{
    partial class Section14
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnAsyncAwait = new System.Windows.Forms.Button();
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
            this.flp1.Controls.Add(this.btnSync);
            this.flp1.Controls.Add(this.btnAsync);
            this.flp1.Controls.Add(this.btnAsyncAwait);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
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
            // btnAsyncAwait
            // 
            this.btnAsyncAwait.Location = new System.Drawing.Point(3, 61);
            this.btnAsyncAwait.Name = "btnAsyncAwait";
            this.btnAsyncAwait.Size = new System.Drawing.Size(100, 23);
            this.btnAsyncAwait.TabIndex = 3;
            this.btnAsyncAwait.Text = "AsyncAwait";
            this.btnAsyncAwait.UseVisualStyleBackColor = true;
            this.btnAsyncAwait.Click += new System.EventHandler(this.btnAsyncAwait_Click);
            // 
            // Section14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section14";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Async/Await示例01";
            this.Load += new System.EventHandler(this.Section14_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnAsyncAwait;
    }
}