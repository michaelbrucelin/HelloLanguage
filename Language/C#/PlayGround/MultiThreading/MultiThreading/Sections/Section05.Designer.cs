﻿
namespace MultiThreading
{
    partial class Section05
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
            this.btnIAsyncResult = new System.Windows.Forms.Button();
            this.btnCallback = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnIAsyncResult);
            this.flp1.Controls.Add(this.btnCallback);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnIAsyncResult
            // 
            this.btnIAsyncResult.Location = new System.Drawing.Point(3, 3);
            this.btnIAsyncResult.Name = "btnIAsyncResult";
            this.btnIAsyncResult.Size = new System.Drawing.Size(100, 23);
            this.btnIAsyncResult.TabIndex = 1;
            this.btnIAsyncResult.Text = "IAsyncResult";
            this.btnIAsyncResult.UseVisualStyleBackColor = true;
            this.btnIAsyncResult.Click += new System.EventHandler(this.btnIAsyncResult_Click);
            // 
            // btnCallback
            // 
            this.btnCallback.Location = new System.Drawing.Point(3, 32);
            this.btnCallback.Name = "btnCallback";
            this.btnCallback.Size = new System.Drawing.Size(100, 23);
            this.btnCallback.TabIndex = 2;
            this.btnCallback.Text = "Callback";
            this.btnCallback.UseVisualStyleBackColor = true;
            this.btnCallback.Click += new System.EventHandler(this.btnCallback_Click);
            // 
            // Section05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "获取多线程操作的返回值";
            this.Load += new System.EventHandler(this.Section05_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnIAsyncResult;
        private System.Windows.Forms.Button btnCallback;
    }
}