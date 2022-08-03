
namespace MultiThreading
{
    partial class Section13
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
            this.btnThis = new System.Windows.Forms.Button();
            this.btnRecursion = new System.Windows.Forms.Button();
            this.btnThis2 = new System.Windows.Forms.Button();
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
            this.flp1.Controls.Add(this.btnThis);
            this.flp1.Controls.Add(this.btnThis2);
            this.flp1.Controls.Add(this.btnRecursion);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnThis
            // 
            this.btnThis.Location = new System.Drawing.Point(3, 3);
            this.btnThis.Name = "btnThis";
            this.btnThis.Size = new System.Drawing.Size(100, 23);
            this.btnThis.TabIndex = 1;
            this.btnThis.Text = "This Lock";
            this.btnThis.UseVisualStyleBackColor = true;
            this.btnThis.Click += new System.EventHandler(this.btnThis_Click);
            // 
            // btnRecursion
            // 
            this.btnRecursion.Location = new System.Drawing.Point(3, 61);
            this.btnRecursion.Name = "btnRecursion";
            this.btnRecursion.Size = new System.Drawing.Size(100, 23);
            this.btnRecursion.TabIndex = 3;
            this.btnRecursion.Text = "Recursion Lock";
            this.btnRecursion.UseVisualStyleBackColor = true;
            this.btnRecursion.Click += new System.EventHandler(this.btnRecursion_Click);
            // 
            // btnThis2
            // 
            this.btnThis2.Location = new System.Drawing.Point(3, 32);
            this.btnThis2.Name = "btnThis2";
            this.btnThis2.Size = new System.Drawing.Size(100, 23);
            this.btnThis2.TabIndex = 2;
            this.btnThis2.Text = "This Lock2";
            this.btnThis2.UseVisualStyleBackColor = true;
            this.btnThis2.Click += new System.EventHandler(this.btnThis2_Click);
            // 
            // Section13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "锁的其它问题02";
            this.Load += new System.EventHandler(this.Section13_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnThis;
        private System.Windows.Forms.Button btnRecursion;
        private System.Windows.Forms.Button btnThis2;
    }
}