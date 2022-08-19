
namespace MultiThreading
{
    partial class Section20
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
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.btnContextFlow = new System.Windows.Forms.Button();
            this.flp11 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancelCallback = new System.Windows.Forms.Button();
            this.flp12 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelCallback2 = new System.Windows.Forms.Button();
            this.flp1.SuspendLayout();
            this.flp11.SuspendLayout();
            this.flp12.SuspendLayout();
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
            this.flp1.Controls.Add(this.btnThreadPool);
            this.flp1.Controls.Add(this.btnContextFlow);
            this.flp1.Controls.Add(this.flp11);
            this.flp1.Controls.Add(this.flp12);
            this.flp1.Controls.Add(this.btnClear);
            this.flp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp1.Location = new System.Drawing.Point(0, 0);
            this.flp1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(284, 262);
            this.flp1.TabIndex = 0;
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(3, 3);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(100, 23);
            this.btnThreadPool.TabIndex = 1;
            this.btnThreadPool.Text = "ThreadPool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnContextFlow
            // 
            this.btnContextFlow.Location = new System.Drawing.Point(3, 32);
            this.btnContextFlow.Name = "btnContextFlow";
            this.btnContextFlow.Size = new System.Drawing.Size(100, 23);
            this.btnContextFlow.TabIndex = 2;
            this.btnContextFlow.Text = "ContextFlow";
            this.btnContextFlow.UseVisualStyleBackColor = true;
            this.btnContextFlow.Click += new System.EventHandler(this.btnContextFlow_Click);
            // 
            // flp11
            // 
            this.flp11.Controls.Add(this.btnStart);
            this.flp11.Controls.Add(this.btnCancel);
            this.flp11.Location = new System.Drawing.Point(0, 61);
            this.flp11.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flp11.Name = "flp11";
            this.flp11.Size = new System.Drawing.Size(256, 23);
            this.flp11.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 0);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(109, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancelCallback
            // 
            this.btnCancelCallback.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelCallback.Location = new System.Drawing.Point(3, 0);
            this.btnCancelCallback.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancelCallback.Name = "btnCancelCallback";
            this.btnCancelCallback.Size = new System.Drawing.Size(100, 23);
            this.btnCancelCallback.TabIndex = 1;
            this.btnCancelCallback.Text = "Cancel Callback";
            this.btnCancelCallback.UseVisualStyleBackColor = true;
            this.btnCancelCallback.Click += new System.EventHandler(this.btnCancelCallback_Click);
            // 
            // flp12
            // 
            this.flp12.Controls.Add(this.btnCancelCallback);
            this.flp12.Controls.Add(this.btnCancelCallback2);
            this.flp12.Location = new System.Drawing.Point(0, 90);
            this.flp12.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flp12.Name = "flp12";
            this.flp12.Size = new System.Drawing.Size(256, 23);
            this.flp12.TabIndex = 4;
            // 
            // btnCancelCallback2
            // 
            this.btnCancelCallback2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelCallback2.Location = new System.Drawing.Point(109, 0);
            this.btnCancelCallback2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCancelCallback2.Name = "btnCancelCallback2";
            this.btnCancelCallback2.Size = new System.Drawing.Size(100, 23);
            this.btnCancelCallback2.TabIndex = 2;
            this.btnCancelCallback2.Text = "Cancel Callback2";
            this.btnCancelCallback2.UseVisualStyleBackColor = true;
            this.btnCancelCallback2.Click += new System.EventHandler(this.btnCancelCallback2_Click);
            // 
            // Section20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.flp1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Section20";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ThreadPool示例";
            this.Load += new System.EventHandler(this.Section20_Load);
            this.flp1.ResumeLayout(false);
            this.flp11.ResumeLayout(false);
            this.flp12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FlowLayoutPanel flp1;
        private System.Windows.Forms.Button btnThreadPool;
        private System.Windows.Forms.Button btnContextFlow;
        private System.Windows.Forms.FlowLayoutPanel flp11;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancelCallback;
        private System.Windows.Forms.FlowLayoutPanel flp12;
        private System.Windows.Forms.Button btnCancelCallback2;
    }
}