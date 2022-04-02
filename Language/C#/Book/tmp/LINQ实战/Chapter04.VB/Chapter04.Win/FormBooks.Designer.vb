<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBooks
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
    Me.dataGridView1 = New System.Windows.Forms.DataGridView
    Me.Book = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dataGridView1
    '
    Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Book, Me.Price})
    Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dataGridView1.Location = New System.Drawing.Point(10, 10)
    Me.dataGridView1.Name = "dataGridView1"
    Me.dataGridView1.Size = New System.Drawing.Size(272, 251)
    Me.dataGridView1.TabIndex = 1
    '
    'Book
    '
    Me.Book.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
    Me.Book.DataPropertyName = "Book"
    Me.Book.HeaderText = "Book"
    Me.Book.Name = "Book"
    Me.Book.Width = 57
    '
    'Price
    '
    Me.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
    Me.Price.DataPropertyName = "Price"
    Me.Price.HeaderText = "Price"
    Me.Price.Name = "Price"
    Me.Price.Width = 56
    '
    'FormBooks
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(292, 271)
    Me.Controls.Add(Me.dataGridView1)
    Me.Name = "FormBooks"
    Me.Padding = New System.Windows.Forms.Padding(10)
    Me.Text = "FormBooks"
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
  Private WithEvents Book As System.Windows.Forms.DataGridViewTextBoxColumn
  Private WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
