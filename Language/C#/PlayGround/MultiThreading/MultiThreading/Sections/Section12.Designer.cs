
namespace MultiThreading
{
    partial class Section12
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
            this.btnStatic = new System.Windows.Forms.Button();
            this.btnInstance = new System.Windows.Forms.Button();
            this.btnSameString = new System.Windows.Forms.Button();
            this.btnDiffString = new System.Windows.Forms.Button();
            this.btnSameGenerics = new System.Windows.Forms.Button();
            this.btnDiffGenerics = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 90);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnStatic);
            this.flp1.Controls.Add(this.btnInstance);
            this.flp1.Controls.Add(this.btnSameString);
            this.flp1.Controls.Add(this.btnDiffString);
            this.flp1.Controls.Add(this.btnSameGenerics);
            this.flp1.Controls.Add(this.btnDiffGenerics);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnStatic
            // 
            this.btnStatic.Location = new System.Drawing.Point(3, 3);
            this.btnStatic.Name = "btnStatic";
            this.btnStatic.Size = new System.Drawing.Size(100, 23);
            this.btnStatic.TabIndex = 1;
            this.btnStatic.Text = "Static Lock";
            this.btnStatic.UseVisualStyleBackColor = true;
            this.btnStatic.Click += new System.EventHandler(this.btnStatic_Click);
            // 
            // btnInstance
            // 
            this.btnInstance.Location = new System.Drawing.Point(109, 3);
            this.btnInstance.Name = "btnInstance";
            this.btnInstance.Size = new System.Drawing.Size(100, 23);
            this.btnInstance.TabIndex = 2;
            this.btnInstance.Text = "Instance Lock";
            this.btnInstance.UseVisualStyleBackColor = true;
            this.btnInstance.Click += new System.EventHandler(this.btnInstance_Click);
            // 
            // btnSameString
            // 
            this.btnSameString.Location = new System.Drawing.Point(3, 32);
            this.btnSameString.Name = "btnSameString";
            this.btnSameString.Size = new System.Drawing.Size(100, 23);
            this.btnSameString.TabIndex = 3;
            this.btnSameString.Text = "Same String";
            this.btnSameString.UseVisualStyleBackColor = true;
            this.btnSameString.Click += new System.EventHandler(this.btnSameString_Click);
            // 
            // btnDiffString
            // 
            this.btnDiffString.Location = new System.Drawing.Point(109, 32);
            this.btnDiffString.Name = "btnDiffString";
            this.btnDiffString.Size = new System.Drawing.Size(100, 23);
            this.btnDiffString.TabIndex = 4;
            this.btnDiffString.Text = "Diff String";
            this.btnDiffString.UseVisualStyleBackColor = true;
            this.btnDiffString.Click += new System.EventHandler(this.btnDiffString_Click);
            // 
            // btnSameGenerics
            // 
            this.btnSameGenerics.Location = new System.Drawing.Point(3, 61);
            this.btnSameGenerics.Name = "btnSameGenerics";
            this.btnSameGenerics.Size = new System.Drawing.Size(100, 23);
            this.btnSameGenerics.TabIndex = 5;
            this.btnSameGenerics.Text = "Same Generics";
            this.btnSameGenerics.UseVisualStyleBackColor = true;
            this.btnSameGenerics.Click += new System.EventHandler(this.btnSameGenerics_Click);
            // 
            // btnDiffGenerics
            // 
            this.btnDiffGenerics.Location = new System.Drawing.Point(109, 61);
            this.btnDiffGenerics.Name = "btnDiffGenerics";
            this.btnDiffGenerics.Size = new System.Drawing.Size(100, 23);
            this.btnDiffGenerics.TabIndex = 6;
            this.btnDiffGenerics.Text = "Diff Generics";
            this.btnDiffGenerics.UseVisualStyleBackColor = true;
            this.btnDiffGenerics.Click += new System.EventHandler(this.btnDiffGenerics_Click);
            // 
            // Section12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "锁的其它问题01";
            this.Load += new System.EventHandler(this.Section12_Load);
            this.flp1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnStatic;
        private System.Windows.Forms.Button btnInstance;
        private System.Windows.Forms.Button btnSameString;
        private System.Windows.Forms.Button btnDiffString;
        private System.Windows.Forms.Button btnSameGenerics;
        private System.Windows.Forms.Button btnDiffGenerics;
    }
}