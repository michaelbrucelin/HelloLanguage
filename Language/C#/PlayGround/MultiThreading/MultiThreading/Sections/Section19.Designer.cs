
namespace MultiThreading
{
    partial class Section19
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
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnFore = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNoJoin = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
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
            this.flp1.Controls.Add(this.btnNoJoin);
            this.flp1.Controls.Add(this.btnJoin);
            this.flp1.Controls.Add(this.btnFore);
            this.flp1.Controls.Add(this.btnBack);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(3, 32);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(100, 23);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnFore
            // 
            this.btnFore.Location = new System.Drawing.Point(3, 61);
            this.btnFore.Name = "btnFore";
            this.btnFore.Size = new System.Drawing.Size(100, 23);
            this.btnFore.TabIndex = 3;
            this.btnFore.Text = "Foreground";
            this.btnFore.UseVisualStyleBackColor = true;
            this.btnFore.Click += new System.EventHandler(this.btnFore_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 90);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Background";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNoJoin
            // 
            this.btnNoJoin.Location = new System.Drawing.Point(3, 3);
            this.btnNoJoin.Name = "btnNoJoin";
            this.btnNoJoin.Size = new System.Drawing.Size(100, 23);
            this.btnNoJoin.TabIndex = 1;
            this.btnNoJoin.Text = "NoJoin";
            this.btnNoJoin.UseVisualStyleBackColor = true;
            this.btnNoJoin.Click += new System.EventHandler(this.btnNoJoin_Click);
            // 
            // Section19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section19";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thread示例";
            this.Load += new System.EventHandler(this.Section19_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnFore;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNoJoin;
    }
}