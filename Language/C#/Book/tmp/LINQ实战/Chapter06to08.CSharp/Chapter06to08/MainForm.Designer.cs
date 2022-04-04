namespace Samples.CSharp
{
    partial class MainForm
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
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.SampleTreeview = new System.Windows.Forms.TreeView();
          this.ListingLabel = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this.DescriptionLabel = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.ChapterLabel = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.btnRunAll = new System.Windows.Forms.Button();
          this.btnRun = new System.Windows.Forms.Button();
          this.OutputTextBos = new System.Windows.Forms.TextBox();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.SuspendLayout();
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Name = "splitContainer1";
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.SampleTreeview);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.ListingLabel);
          this.splitContainer1.Panel2.Controls.Add(this.label5);
          this.splitContainer1.Panel2.Controls.Add(this.DescriptionLabel);
          this.splitContainer1.Panel2.Controls.Add(this.label3);
          this.splitContainer1.Panel2.Controls.Add(this.ChapterLabel);
          this.splitContainer1.Panel2.Controls.Add(this.label1);
          this.splitContainer1.Panel2.Controls.Add(this.btnRunAll);
          this.splitContainer1.Panel2.Controls.Add(this.btnRun);
          this.splitContainer1.Panel2.Controls.Add(this.OutputTextBos);
          this.splitContainer1.Size = new System.Drawing.Size(581, 508);
          this.splitContainer1.SplitterDistance = 193;
          this.splitContainer1.TabIndex = 0;
          // 
          // SampleTreeview
          // 
          this.SampleTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
          this.SampleTreeview.HideSelection = false;
          this.SampleTreeview.Location = new System.Drawing.Point(0, 0);
          this.SampleTreeview.Name = "SampleTreeview";
          this.SampleTreeview.Size = new System.Drawing.Size(193, 508);
          this.SampleTreeview.TabIndex = 0;
          this.SampleTreeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SampleTreeview_AfterSelect);
          // 
          // ListingLabel
          // 
          this.ListingLabel.AutoSize = true;
          this.ListingLabel.Location = new System.Drawing.Point(297, 11);
          this.ListingLabel.Name = "ListingLabel";
          this.ListingLabel.Size = new System.Drawing.Size(0, 13);
          this.ListingLabel.TabIndex = 8;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(228, 11);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(40, 13);
          this.label5.TabIndex = 7;
          this.label5.Text = "Listing:";
          // 
          // DescriptionLabel
          // 
          this.DescriptionLabel.AutoSize = true;
          this.DescriptionLabel.Location = new System.Drawing.Point(76, 35);
          this.DescriptionLabel.Name = "DescriptionLabel";
          this.DescriptionLabel.Size = new System.Drawing.Size(0, 13);
          this.DescriptionLabel.TabIndex = 6;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(6, 35);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(60, 13);
          this.label3.TabIndex = 5;
          this.label3.Text = "Description";
          // 
          // ChapterLabel
          // 
          this.ChapterLabel.AutoSize = true;
          this.ChapterLabel.Location = new System.Drawing.Point(73, 12);
          this.ChapterLabel.Name = "ChapterLabel";
          this.ChapterLabel.Size = new System.Drawing.Size(0, 13);
          this.ChapterLabel.TabIndex = 4;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(6, 12);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(47, 13);
          this.label1.TabIndex = 3;
          this.label1.Text = "Chapter:";
          // 
          // btnRunAll
          // 
          this.btnRunAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.btnRunAll.Location = new System.Drawing.Point(297, 61);
          this.btnRunAll.Name = "btnRunAll";
          this.btnRunAll.Size = new System.Drawing.Size(75, 23);
          this.btnRunAll.TabIndex = 2;
          this.btnRunAll.Text = "Run All";
          this.btnRunAll.UseVisualStyleBackColor = true;
          this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
          // 
          // btnRun
          // 
          this.btnRun.Location = new System.Drawing.Point(9, 61);
          this.btnRun.Name = "btnRun";
          this.btnRun.Size = new System.Drawing.Size(75, 23);
          this.btnRun.TabIndex = 1;
          this.btnRun.Text = "Run";
          this.btnRun.UseVisualStyleBackColor = true;
          this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
          // 
          // OutputTextBos
          // 
          this.OutputTextBos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.OutputTextBos.Location = new System.Drawing.Point(2, 90);
          this.OutputTextBos.Multiline = true;
          this.OutputTextBos.Name = "OutputTextBos";
          this.OutputTextBos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.OutputTextBos.Size = new System.Drawing.Size(379, 415);
          this.OutputTextBos.TabIndex = 0;
          // 
          // MainForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(581, 508);
          this.Controls.Add(this.splitContainer1);
          this.Name = "MainForm";
          this.Text = "LINQ in Action samples";
          this.Load += new System.EventHandler(this.Form_Load);
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.Panel2.PerformLayout();
          this.splitContainer1.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView SampleTreeview;
        private System.Windows.Forms.TextBox OutputTextBos;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ChapterLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ListingLabel;
    }
}