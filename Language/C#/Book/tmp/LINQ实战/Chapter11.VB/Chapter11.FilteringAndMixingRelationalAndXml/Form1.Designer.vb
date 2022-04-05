<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.groupBox2 = New System.Windows.Forms.GroupBox
		Me.bookDataGridView = New System.Windows.Forms.DataGridView
		Me.bookBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.importButton = New System.Windows.Forms.Button
		Me.subjectComboBox = New System.Windows.Forms.ComboBox
		Me.label2 = New System.Windows.Forms.Label
		Me.Import = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.dataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.groupBox1 = New System.Windows.Forms.GroupBox
		Me.label1 = New System.Windows.Forms.Label
		Me.searchButton = New System.Windows.Forms.Button
		Me.keywords = New System.Windows.Forms.TextBox
		Me.ImportColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
		Me.TitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.IsbnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
		Me.groupBox2.SuspendLayout()
		CType(Me.bookDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.bookBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'groupBox2
		'
		Me.groupBox2.Controls.Add(Me.bookDataGridView)
		Me.groupBox2.Controls.Add(Me.importButton)
		Me.groupBox2.Controls.Add(Me.subjectComboBox)
		Me.groupBox2.Controls.Add(Me.label2)
		Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.groupBox2.Location = New System.Drawing.Point(0, 91)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(594, 374)
		Me.groupBox2.TabIndex = 6
		Me.groupBox2.TabStop = False
		Me.groupBox2.Text = "Results"
		'
		'bookDataGridView
		'
		Me.bookDataGridView.AllowUserToAddRows = False
		Me.bookDataGridView.AllowUserToDeleteRows = False
		Me.bookDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
								Or System.Windows.Forms.AnchorStyles.Left) _
								Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.bookDataGridView.AutoGenerateColumns = False
		Me.bookDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
		Me.bookDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ImportColumn, Me.TitleDataGridViewTextBoxColumn, Me.IsbnDataGridViewTextBoxColumn})
		Me.bookDataGridView.DataSource = Me.bookBindingSource
		Me.bookDataGridView.Location = New System.Drawing.Point(12, 28)
		Me.bookDataGridView.Name = "bookDataGridView"
		Me.bookDataGridView.RowHeadersVisible = False
		Me.bookDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.bookDataGridView.Size = New System.Drawing.Size(570, 303)
		Me.bookDataGridView.TabIndex = 5
		'
		'bookBindingSource
		'
		Me.bookBindingSource.DataSource = GetType(LinqInAction.LinqToSql.Book)
		'
		'importButton
		'
		Me.importButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.importButton.Location = New System.Drawing.Point(497, 337)
		Me.importButton.Name = "importButton"
		Me.importButton.Size = New System.Drawing.Size(75, 23)
		Me.importButton.TabIndex = 5
		Me.importButton.Text = "&Import"
		Me.importButton.UseVisualStyleBackColor = True
		'
		'subjectComboBox
		'
		Me.subjectComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.subjectComboBox.DisplayMember = "Name"
		Me.subjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.subjectComboBox.FormattingEnabled = True
		Me.subjectComboBox.Location = New System.Drawing.Point(330, 339)
		Me.subjectComboBox.Name = "subjectComboBox"
		Me.subjectComboBox.Size = New System.Drawing.Size(154, 21)
		Me.subjectComboBox.TabIndex = 6
		Me.subjectComboBox.ValueMember = "ID"
		'
		'label2
		'
		Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.label2.AutoSize = True
		Me.label2.Location = New System.Drawing.Point(272, 343)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(46, 13)
		Me.label2.TabIndex = 7
		Me.label2.Text = "Subject:"
		'
		'Import
		'
		Me.Import.HeaderText = "Import"
		Me.Import.Name = "Import"
		'
		'dataGridViewTextBoxColumn6
		'
		Me.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.dataGridViewTextBoxColumn6.DataPropertyName = "Title"
		Me.dataGridViewTextBoxColumn6.HeaderText = "Title"
		Me.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6"
		Me.dataGridViewTextBoxColumn6.ReadOnly = True
		'
		'dataGridViewTextBoxColumn3
		'
		Me.dataGridViewTextBoxColumn3.DataPropertyName = "Isbn"
		Me.dataGridViewTextBoxColumn3.HeaderText = "Isbn"
		Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
		Me.dataGridViewTextBoxColumn3.ReadOnly = True
		'
		'groupBox1
		'
		Me.groupBox1.Controls.Add(Me.label1)
		Me.groupBox1.Controls.Add(Me.searchButton)
		Me.groupBox1.Controls.Add(Me.keywords)
		Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(594, 91)
		Me.groupBox1.TabIndex = 5
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Search"
		'
		'label1
		'
		Me.label1.AutoSize = True
		Me.label1.Location = New System.Drawing.Point(13, 19)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(62, 13)
		Me.label1.TabIndex = 4
		Me.label1.Text = "Keyword(s):"
		'
		'searchButton
		'
		Me.searchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.searchButton.Location = New System.Drawing.Point(507, 33)
		Me.searchButton.Name = "searchButton"
		Me.searchButton.Size = New System.Drawing.Size(75, 23)
		Me.searchButton.TabIndex = 3
		Me.searchButton.Text = "&Search"
		Me.searchButton.UseVisualStyleBackColor = True
		'
		'keywords
		'
		Me.keywords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
								Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.keywords.Location = New System.Drawing.Point(12, 36)
		Me.keywords.Name = "keywords"
		Me.keywords.Size = New System.Drawing.Size(489, 20)
		Me.keywords.TabIndex = 2
		'
		'ImportColumn
		'
		Me.ImportColumn.HeaderText = "Import"
		Me.ImportColumn.Name = "ImportColumn"
		'
		'TitleDataGridViewTextBoxColumn
		'
		Me.TitleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.TitleDataGridViewTextBoxColumn.DataPropertyName = "Title"
		Me.TitleDataGridViewTextBoxColumn.HeaderText = "Title"
		Me.TitleDataGridViewTextBoxColumn.Name = "TitleDataGridViewTextBoxColumn"
		'
		'IsbnDataGridViewTextBoxColumn
		'
		Me.IsbnDataGridViewTextBoxColumn.DataPropertyName = "Isbn"
		Me.IsbnDataGridViewTextBoxColumn.HeaderText = "Isbn"
		Me.IsbnDataGridViewTextBoxColumn.Name = "IsbnDataGridViewTextBoxColumn"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(594, 465)
		Me.Controls.Add(Me.groupBox2)
		Me.Controls.Add(Me.groupBox1)
		Me.Name = "Form1"
		Me.Text = "Amazon Search"
		Me.groupBox2.ResumeLayout(False)
		Me.groupBox2.PerformLayout()
		CType(Me.bookDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.bookBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
	Private WithEvents bookDataGridView As System.Windows.Forms.DataGridView
	Private WithEvents importButton As System.Windows.Forms.Button
	Private WithEvents subjectComboBox As System.Windows.Forms.ComboBox
	Private WithEvents label2 As System.Windows.Forms.Label
	Private WithEvents Import As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private WithEvents dataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
	Private WithEvents label1 As System.Windows.Forms.Label
	Private WithEvents searchButton As System.Windows.Forms.Button
	Private WithEvents keywords As System.Windows.Forms.TextBox
	Private WithEvents bookBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ImportColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
	Friend WithEvents TitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IsbnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
