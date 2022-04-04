namespace LinqInAction.Chapter06to08.Common.CodeSamples
{
  partial class EditingForm
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
      this.components = new System.ComponentModel.Container();
      this.publisherBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.publisherDataGridView = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.publisherBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.publisherDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // publisherBindingSource
      // 
      this.publisherBindingSource.DataSource = typeof(LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Publisher);
      // 
      // publisherDataGridView
      // 
      this.publisherDataGridView.AutoGenerateColumns = false;
      this.publisherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.publisherDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
      this.publisherDataGridView.DataSource = this.publisherBindingSource;
      this.publisherDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.publisherDataGridView.Location = new System.Drawing.Point(0, 0);
      this.publisherDataGridView.Name = "publisherDataGridView";
      this.publisherDataGridView.Size = new System.Drawing.Size(347, 266);
      this.publisherDataGridView.TabIndex = 1;
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
      this.dataGridViewTextBoxColumn2.HeaderText = "Name";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "WebSite";
      this.dataGridViewTextBoxColumn3.HeaderText = "WebSite";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // EditingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(347, 266);
      this.Controls.Add(this.publisherDataGridView);
      this.Name = "EditingForm";
      this.Text = "EditingForm";
      this.Load += new System.EventHandler(this.EditingForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.publisherBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.publisherDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.BindingSource publisherBindingSource;
    private System.Windows.Forms.DataGridView publisherDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
  }
}