﻿
namespace MultiThreading
{
    partial class Section21_Scheduler
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
            this.btnScheduler = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnScheduler);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(384, 62);
            this.flp1.TabIndex = 0;
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(3, 3);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(100, 23);
            this.btnScheduler.TabIndex = 1;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // Section21_Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 62);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(400, 100);
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "Section21_Scheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.Section21_Scheduler_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnScheduler;
    }
}