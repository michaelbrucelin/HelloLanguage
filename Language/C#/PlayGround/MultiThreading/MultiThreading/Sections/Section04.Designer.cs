﻿
namespace MultiThreading
{
    partial class Section04
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
            this.btnSignalFake = new System.Windows.Forms.Button();
            this.btnSignalReal = new System.Windows.Forms.Button();
            this.btnSignalReal2 = new System.Windows.Forms.Button();
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
            this.flp1.Controls.Add(this.btnSignalFake);
            this.flp1.Controls.Add(this.btnSignalReal);
            this.flp1.Controls.Add(this.btnSignalReal2);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnSignalFake
            // 
            this.btnSignalFake.Location = new System.Drawing.Point(3, 3);
            this.btnSignalFake.Name = "btnSignalFake";
            this.btnSignalFake.Size = new System.Drawing.Size(100, 23);
            this.btnSignalFake.TabIndex = 1;
            this.btnSignalFake.Text = "Signal Fake";
            this.btnSignalFake.UseVisualStyleBackColor = true;
            this.btnSignalFake.Click += new System.EventHandler(this.btnSignalFake_Click);
            // 
            // btnSignalReal
            // 
            this.btnSignalReal.Location = new System.Drawing.Point(3, 32);
            this.btnSignalReal.Name = "btnSignalReal";
            this.btnSignalReal.Size = new System.Drawing.Size(100, 23);
            this.btnSignalReal.TabIndex = 2;
            this.btnSignalReal.Text = "Signal Real";
            this.btnSignalReal.UseVisualStyleBackColor = true;
            this.btnSignalReal.Click += new System.EventHandler(this.btnSignalReal_Click);
            // 
            // btnSignalReal2
            // 
            this.btnSignalReal2.Location = new System.Drawing.Point(3, 61);
            this.btnSignalReal2.Name = "btnSignalReal2";
            this.btnSignalReal2.Size = new System.Drawing.Size(100, 23);
            this.btnSignalReal2.TabIndex = 3;
            this.btnSignalReal2.Text = "Signal Real2";
            this.btnSignalReal2.UseVisualStyleBackColor = true;
            this.btnSignalReal2.Click += new System.EventHandler(this.btnSignalReal2_Click);
            // 
            // Section04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section04";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "信号量";
            this.Load += new System.EventHandler(this.Section04_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnSignalFake;
        private System.Windows.Forms.Button btnSignalReal;
        private System.Windows.Forms.Button btnSignalReal2;
    }
}