namespace LinqInAction.Chapter04.Win
{
  partial class FormBooks
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.Book = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Book,
            this.Price});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(10, 10);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(272, 251);
      this.dataGridView1.TabIndex = 0;
      // 
      // Book
      // 
      this.Book.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Book.DataPropertyName = "Book";
      this.Book.HeaderText = "Book";
      this.Book.Name = "Book";
      this.Book.Width = 57;
      // 
      // Price
      // 
      this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Price.DataPropertyName = "Price";
      this.Price.HeaderText = "Price";
      this.Price.Name = "Price";
      this.Price.Width = 56;
      // 
      // FormBooks
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 271);
      this.Controls.Add(this.dataGridView1);
      this.Name = "FormBooks";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.Text = "FormBooks";
      this.Load += new System.EventHandler(this.FormBooks_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Book;
    private System.Windows.Forms.DataGridViewTextBoxColumn Price;
  }
}