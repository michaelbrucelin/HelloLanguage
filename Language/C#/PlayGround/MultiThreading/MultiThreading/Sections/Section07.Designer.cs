﻿
namespace MultiThreading
{
    partial class Section07
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
            this.btnMultiJobs = new System.Windows.Forms.Button();
            this.btnMultiJobs2 = new System.Windows.Forms.Button();
            this.btnMultiJobs3 = new System.Windows.Forms.Button();
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
            this.flp1.Controls.Add(this.btnMultiJobs);
            this.flp1.Controls.Add(this.btnMultiJobs2);
            this.flp1.Controls.Add(this.btnMultiJobs3);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnMultiJobs
            // 
            this.btnMultiJobs.Location = new System.Drawing.Point(3, 3);
            this.btnMultiJobs.Name = "btnMultiJobs";
            this.btnMultiJobs.Size = new System.Drawing.Size(100, 23);
            this.btnMultiJobs.TabIndex = 1;
            this.btnMultiJobs.Text = "MultiJobs";
            this.btnMultiJobs.UseVisualStyleBackColor = true;
            this.btnMultiJobs.Click += new System.EventHandler(this.btnMultiJobs_Click);
            // 
            // btnMultiJobs2
            // 
            this.btnMultiJobs2.Location = new System.Drawing.Point(3, 32);
            this.btnMultiJobs2.Name = "btnMultiJobs2";
            this.btnMultiJobs2.Size = new System.Drawing.Size(100, 23);
            this.btnMultiJobs2.TabIndex = 2;
            this.btnMultiJobs2.Text = "MultiJobs2";
            this.btnMultiJobs2.UseVisualStyleBackColor = true;
            this.btnMultiJobs2.Click += new System.EventHandler(this.btnMultiJobs2_Click);
            // 
            // btnMultiJobs3
            // 
            this.btnMultiJobs3.Location = new System.Drawing.Point(3, 61);
            this.btnMultiJobs3.Name = "btnMultiJobs3";
            this.btnMultiJobs3.Size = new System.Drawing.Size(100, 23);
            this.btnMultiJobs3.TabIndex = 3;
            this.btnMultiJobs3.Text = "MultiJobs3";
            this.btnMultiJobs3.UseVisualStyleBackColor = true;
            this.btnMultiJobs3.Click += new System.EventHandler(this.btnMultiJobs3_Click);
            // 
            // Section07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section07";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task示例01";
            this.Load += new System.EventHandler(this.Section07_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnMultiJobs;
        private System.Windows.Forms.Button btnMultiJobs2;
        private System.Windows.Forms.Button btnMultiJobs3;
    }
}