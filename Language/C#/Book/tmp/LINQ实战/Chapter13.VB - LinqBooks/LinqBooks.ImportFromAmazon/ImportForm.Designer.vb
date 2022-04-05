<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.panel1 = New System.Windows.Forms.Panel
    Me.groupBox1 = New System.Windows.Forms.GroupBox
    Me.keywords = New System.Windows.Forms.TextBox
    Me.label1 = New System.Windows.Forms.Label
    Me.searchButton = New System.Windows.Forms.Button
    Me.panel2 = New System.Windows.Forms.Panel
    Me.groupBox2 = New System.Windows.Forms.GroupBox
    Me.importButton = New System.Windows.Forms.Button
    Me.categoryComboBox = New System.Windows.Forms.ComboBox
    Me.bookDataGridView = New System.Windows.Forms.DataGridView
    Me.Import = New System.Windows.Forms.DataGridViewCheckBoxColumn
    Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ISBN = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.bookBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.panel1.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.panel2.SuspendLayout()
    Me.groupBox2.SuspendLayout()
    CType(Me.bookDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.bookBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'panel1
    '
    Me.panel1.Controls.Add(Me.groupBox1)
    Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.panel1.Location = New System.Drawing.Point(0, 0)
    Me.panel1.Name = "panel1"
    Me.panel1.Size = New System.Drawing.Size(531, 66)
    Me.panel1.TabIndex = 1
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.keywords)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Controls.Add(Me.searchButton)
    Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.groupBox1.Location = New System.Drawing.Point(0, 0)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(531, 66)
    Me.groupBox1.TabIndex = 0
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Search"
    '
    'keywords
    '
    Me.keywords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.keywords.Location = New System.Drawing.Point(13, 33)
    Me.keywords.Name = "keywords"
    Me.keywords.Size = New System.Drawing.Size(431, 20)
    Me.keywords.TabIndex = 2
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(12, 17)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(62, 13)
    Me.label1.TabIndex = 1
    Me.label1.Text = "Keyword(s):"
    '
    'searchButton
    '
    Me.searchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.searchButton.Location = New System.Drawing.Point(450, 30)
    Me.searchButton.Name = "searchButton"
    Me.searchButton.Size = New System.Drawing.Size(75, 23)
    Me.searchButton.TabIndex = 0
    Me.searchButton.Text = "Search"
    Me.searchButton.UseVisualStyleBackColor = True
    '
    'panel2
    '
    Me.panel2.Controls.Add(Me.groupBox2)
    Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.panel2.Location = New System.Drawing.Point(0, 66)
    Me.panel2.Name = "panel2"
    Me.panel2.Size = New System.Drawing.Size(531, 320)
    Me.panel2.TabIndex = 2
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.importButton)
    Me.groupBox2.Controls.Add(Me.categoryComboBox)
    Me.groupBox2.Controls.Add(Me.bookDataGridView)
    Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.groupBox2.Location = New System.Drawing.Point(0, 0)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(531, 320)
    Me.groupBox2.TabIndex = 0
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Results"
    '
    'importButton
    '
    Me.importButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.importButton.Location = New System.Drawing.Point(442, 286)
    Me.importButton.Name = "importButton"
    Me.importButton.Size = New System.Drawing.Size(75, 23)
    Me.importButton.TabIndex = 2
    Me.importButton.Text = "Import"
    Me.importButton.UseVisualStyleBackColor = True
    '
    'categoryComboBox
    '
    Me.categoryComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.categoryComboBox.DisplayMember = "Name"
    Me.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.categoryComboBox.FormattingEnabled = True
    Me.categoryComboBox.Location = New System.Drawing.Point(137, 286)
    Me.categoryComboBox.Name = "categoryComboBox"
    Me.categoryComboBox.Size = New System.Drawing.Size(299, 21)
    Me.categoryComboBox.TabIndex = 1
    Me.categoryComboBox.ValueMember = "ID"
    '
    'bookDataGridView
    '
    Me.bookDataGridView.AllowUserToAddRows = False
    Me.bookDataGridView.AllowUserToDeleteRows = False
    Me.bookDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.bookDataGridView.AutoGenerateColumns = False
    Me.bookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.bookDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Import, Me.Title, Me.ISBN})
    Me.bookDataGridView.DataSource = Me.bookBindingSource
    Me.bookDataGridView.Location = New System.Drawing.Point(15, 19)
    Me.bookDataGridView.Name = "bookDataGridView"
    Me.bookDataGridView.RowHeadersVisible = False
    Me.bookDataGridView.Size = New System.Drawing.Size(502, 256)
    Me.bookDataGridView.TabIndex = 0
    '
    'Import
    '
    Me.Import.HeaderText = "Import"
    Me.Import.Name = "Import"
    '
    'Title
    '
    Me.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.Title.DataPropertyName = "Title"
    Me.Title.HeaderText = "Title"
    Me.Title.Name = "Title"
    Me.Title.ReadOnly = True
    '
    'ISBN
    '
    Me.ISBN.DataPropertyName = "Isbn"
    Me.ISBN.HeaderText = "ISBN"
    Me.ISBN.Name = "ISBN"
    Me.ISBN.ReadOnly = True
    '
    'ImportForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(531, 386)
    Me.Controls.Add(Me.panel2)
    Me.Controls.Add(Me.panel1)
    Me.Name = "ImportForm"
    Me.Text = "Import from Amazon"
    Me.panel1.ResumeLayout(False)
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    Me.panel2.ResumeLayout(False)
    Me.groupBox2.ResumeLayout(False)
    CType(Me.bookDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.bookBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Private WithEvents panel1 As System.Windows.Forms.Panel
  Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Private WithEvents keywords As System.Windows.Forms.TextBox
  Private WithEvents label1 As System.Windows.Forms.Label
  Private WithEvents searchButton As System.Windows.Forms.Button
  Private WithEvents panel2 As System.Windows.Forms.Panel
  Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Private WithEvents importButton As System.Windows.Forms.Button
  Private WithEvents categoryComboBox As System.Windows.Forms.ComboBox
  Private WithEvents bookDataGridView As System.Windows.Forms.DataGridView
  Private WithEvents Import As System.Windows.Forms.DataGridViewCheckBoxColumn
  Private WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
  Private WithEvents ISBN As System.Windows.Forms.DataGridViewTextBoxColumn
  Private WithEvents bookBindingSource As System.Windows.Forms.BindingSource

End Class
