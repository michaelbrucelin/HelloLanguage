
namespace MultiThreading
{
    partial class Section21
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
            this.btnException = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnContinue2 = new System.Windows.Forms.Button();
            this.btnSubTask = new System.Windows.Forms.Button();
            this.btnFactory = new System.Windows.Forms.Button();
            this.btnScheduler = new System.Windows.Forms.Button();
            this.flp01 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp02 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp1.SuspendLayout();
            this.flp01.SuspendLayout();
            this.flp02.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 177);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // flp1
            // 
            this.flp1.Controls.Add(this.btnException);
            this.flp1.Controls.Add(this.flp01);
            this.flp1.Controls.Add(this.flp02);
            this.flp1.Controls.Add(this.btnSubTask);
            this.flp1.Controls.Add(this.btnFactory);
            this.flp1.Controls.Add(this.btnScheduler);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnException
            // 
            this.btnException.Location = new System.Drawing.Point(3, 3);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(100, 23);
            this.btnException.TabIndex = 1;
            this.btnException.Text = "Exception";
            this.btnException.UseVisualStyleBackColor = true;
            this.btnException.Click += new System.EventHandler(this.btnException_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(106, 0);
            this.btnCancel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(100, 23);
            this.btnCancel2.TabIndex = 2;
            this.btnCancel2.Text = "Cancel2";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(0, 0);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(100, 23);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnContinue2
            // 
            this.btnContinue2.Location = new System.Drawing.Point(106, 0);
            this.btnContinue2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnContinue2.Name = "btnContinue2";
            this.btnContinue2.Size = new System.Drawing.Size(100, 23);
            this.btnContinue2.TabIndex = 2;
            this.btnContinue2.Text = "Continue2";
            this.btnContinue2.UseVisualStyleBackColor = true;
            this.btnContinue2.Click += new System.EventHandler(this.btnContinue2_Click);
            // 
            // btnSubTask
            // 
            this.btnSubTask.Location = new System.Drawing.Point(3, 90);
            this.btnSubTask.Name = "btnSubTask";
            this.btnSubTask.Size = new System.Drawing.Size(100, 23);
            this.btnSubTask.TabIndex = 4;
            this.btnSubTask.Text = "SubTask";
            this.btnSubTask.UseVisualStyleBackColor = true;
            this.btnSubTask.Click += new System.EventHandler(this.btnSubTask_Click);
            // 
            // btnFactory
            // 
            this.btnFactory.Location = new System.Drawing.Point(3, 119);
            this.btnFactory.Name = "btnFactory";
            this.btnFactory.Size = new System.Drawing.Size(100, 23);
            this.btnFactory.TabIndex = 5;
            this.btnFactory.Text = "Factory";
            this.btnFactory.UseVisualStyleBackColor = true;
            this.btnFactory.Click += new System.EventHandler(this.btnFactory_Click);
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(3, 148);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(100, 23);
            this.btnScheduler.TabIndex = 6;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // flp01
            // 
            this.flp01.Controls.Add(this.btnCancel);
            this.flp01.Controls.Add(this.btnCancel2);
            this.flp01.Location = new System.Drawing.Point(3, 32);
            this.flp01.Name = "flp01";
            this.flp01.Size = new System.Drawing.Size(228, 23);
            this.flp01.TabIndex = 2;
            // 
            // flp02
            // 
            this.flp02.Controls.Add(this.btnContinue);
            this.flp02.Controls.Add(this.btnContinue2);
            this.flp02.Location = new System.Drawing.Point(3, 61);
            this.flp02.Name = "flp02";
            this.flp02.Size = new System.Drawing.Size(228, 23);
            this.flp02.TabIndex = 3;
            // 
            // Section21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section21";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task示例";
            this.Load += new System.EventHandler(this.Section21_Load);
            this.flp1.ResumeLayout(false);
            this.flp01.ResumeLayout(false);
            this.flp02.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnException;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnContinue2;
        private System.Windows.Forms.Button btnSubTask;
        private System.Windows.Forms.FlowLayoutPanel flp01;
        private System.Windows.Forms.FlowLayoutPanel flp02;
        private System.Windows.Forms.Button btnFactory;
        private System.Windows.Forms.Button btnScheduler;
    }
}