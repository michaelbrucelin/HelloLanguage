namespace LinqBooks.ImportFromAmazon
{
  partial class ImportForm
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.keywords = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.searchButton = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.bookDataGridView = new System.Windows.Forms.DataGridView();
      this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.categoryComboBox = new System.Windows.Forms.ComboBox();
      this.importButton = new System.Windows.Forms.Button();
      this.Import = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(531, 66);
      this.panel1.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.keywords);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.searchButton);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(531, 66);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Search";
      // 
      // keywords
      // 
      this.keywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.keywords.Location = new System.Drawing.Point(13, 33);
      this.keywords.Name = "keywords";
      this.keywords.Size = new System.Drawing.Size(431, 20);
      this.keywords.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Keyword(s):";
      // 
      // searchButton
      // 
      this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.searchButton.Location = new System.Drawing.Point(450, 30);
      this.searchButton.Name = "searchButton";
      this.searchButton.Size = new System.Drawing.Size(75, 23);
      this.searchButton.TabIndex = 0;
      this.searchButton.Text = "Search";
      this.searchButton.UseVisualStyleBackColor = true;
      this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.groupBox2);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 66);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(531, 320);
      this.panel2.TabIndex = 1;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.importButton);
      this.groupBox2.Controls.Add(this.categoryComboBox);
      this.groupBox2.Controls.Add(this.bookDataGridView);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(531, 320);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Results";
      // 
      // bookDataGridView
      // 
      this.bookDataGridView.AllowUserToAddRows = false;
      this.bookDataGridView.AllowUserToDeleteRows = false;
      this.bookDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.bookDataGridView.AutoGenerateColumns = false;
      this.bookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.bookDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Import,
            this.Title,
            this.ISBN});
      this.bookDataGridView.DataSource = this.bookBindingSource;
      this.bookDataGridView.Location = new System.Drawing.Point(15, 19);
      this.bookDataGridView.Name = "bookDataGridView";
      this.bookDataGridView.RowHeadersVisible = false;
      this.bookDataGridView.Size = new System.Drawing.Size(502, 256);
      this.bookDataGridView.TabIndex = 0;
      // 
      // categoryComboBox
      // 
      this.categoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.categoryComboBox.DisplayMember = "Name";
      this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.categoryComboBox.FormattingEnabled = true;
      this.categoryComboBox.Location = new System.Drawing.Point(137, 286);
      this.categoryComboBox.Name = "categoryComboBox";
      this.categoryComboBox.Size = new System.Drawing.Size(299, 21);
      this.categoryComboBox.TabIndex = 1;
      this.categoryComboBox.ValueMember = "ID";
      // 
      // importButton
      // 
      this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.importButton.Location = new System.Drawing.Point(442, 286);
      this.importButton.Name = "importButton";
      this.importButton.Size = new System.Drawing.Size(75, 23);
      this.importButton.TabIndex = 2;
      this.importButton.Text = "Import";
      this.importButton.UseVisualStyleBackColor = true;
      this.importButton.Click += new System.EventHandler(this.importButton_Click);
      // 
      // Import
      // 
      this.Import.HeaderText = "Import";
      this.Import.Name = "Import";
      // 
      // Title
      // 
      this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Title.DataPropertyName = "Title";
      this.Title.HeaderText = "Title";
      this.Title.Name = "Title";
      this.Title.ReadOnly = true;
      // 
      // ISBN
      // 
      this.ISBN.DataPropertyName = "Isbn";
      this.ISBN.HeaderText = "ISBN";
      this.ISBN.Name = "ISBN";
      this.ISBN.ReadOnly = true;
      // 
      // ImportForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(531, 386);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "ImportForm";
      this.Text = "Import from Amazon";
      this.Load += new System.EventHandler(this.ImportForm_Load);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox keywords;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button searchButton;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView bookDataGridView;
    private System.Windows.Forms.BindingSource bookBindingSource;
    private System.Windows.Forms.ComboBox categoryComboBox;
    private System.Windows.Forms.Button importButton;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Import;
    private System.Windows.Forms.DataGridViewTextBoxColumn Title;
    private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
  }
}

