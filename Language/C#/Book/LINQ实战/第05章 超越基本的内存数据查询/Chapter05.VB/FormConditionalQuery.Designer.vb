<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConditionalQuery
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
    Me.groupBox1 = New System.Windows.Forms.GroupBox
    Me.cbxSortOrder = New System.Windows.Forms.ComboBox
    Me.cbxPageCount = New System.Windows.Forms.ComboBox
    Me.txtTitleFilter = New System.Windows.Forms.TextBox
    Me.label4 = New System.Windows.Forms.Label
    Me.label2 = New System.Windows.Forms.Label
    Me.label1 = New System.Windows.Forms.Label
    Me.btnSearch = New System.Windows.Forms.Button
    Me.dataGridView = New System.Windows.Forms.DataGridView
    Me.groupBox1.SuspendLayout()
    CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.cbxSortOrder)
    Me.groupBox1.Controls.Add(Me.cbxPageCount)
    Me.groupBox1.Controls.Add(Me.txtTitleFilter)
    Me.groupBox1.Controls.Add(Me.label4)
    Me.groupBox1.Controls.Add(Me.label2)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Controls.Add(Me.btnSearch)
    Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.groupBox1.Location = New System.Drawing.Point(10, 10)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(502, 130)
    Me.groupBox1.TabIndex = 7
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Criteria"
    '
    'cbxSortOrder
    '
    Me.cbxSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxSortOrder.FormattingEnabled = True
    Me.cbxSortOrder.Items.AddRange(New Object() {"(default)", "Title", "Publisher", "Page count"})
    Me.cbxSortOrder.Location = New System.Drawing.Point(77, 73)
    Me.cbxSortOrder.Name = "cbxSortOrder"
    Me.cbxSortOrder.Size = New System.Drawing.Size(152, 21)
    Me.cbxSortOrder.TabIndex = 5
    '
    'cbxPageCount
    '
    Me.cbxPageCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxPageCount.FormattingEnabled = True
    Me.cbxPageCount.Location = New System.Drawing.Point(77, 46)
    Me.cbxPageCount.Name = "cbxPageCount"
    Me.cbxPageCount.Size = New System.Drawing.Size(152, 21)
    Me.cbxPageCount.TabIndex = 3
    '
    'txtTitleFilter
    '
    Me.txtTitleFilter.Location = New System.Drawing.Point(77, 20)
    Me.txtTitleFilter.Name = "txtTitleFilter"
    Me.txtTitleFilter.Size = New System.Drawing.Size(152, 20)
    Me.txtTitleFilter.TabIndex = 1
    '
    'label4
    '
    Me.label4.AutoSize = True
    Me.label4.Location = New System.Drawing.Point(6, 76)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(56, 13)
    Me.label4.TabIndex = 4
    Me.label4.Text = "Sort order:"
    Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Location = New System.Drawing.Point(6, 49)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(65, 13)
    Me.label2.TabIndex = 2
    Me.label2.Text = "Page count:"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(6, 23)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(30, 13)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Title:"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'btnSearch
    '
    Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnSearch.Location = New System.Drawing.Point(9, 100)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(88, 23)
    Me.btnSearch.TabIndex = 6
    Me.btnSearch.Text = "Search"
    Me.btnSearch.UseVisualStyleBackColor = True
    '
    'dataGridView
    '
    Me.dataGridView.AllowUserToAddRows = False
    Me.dataGridView.AllowUserToDeleteRows = False
    Me.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dataGridView.Location = New System.Drawing.Point(10, 140)
    Me.dataGridView.Name = "dataGridView"
    Me.dataGridView.ReadOnly = True
    Me.dataGridView.Size = New System.Drawing.Size(502, 250)
    Me.dataGridView.TabIndex = 8
    '
    'FormConditionalQuery
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(522, 400)
    Me.Controls.Add(Me.dataGridView)
    Me.Controls.Add(Me.groupBox1)
    Me.Name = "FormConditionalQuery"
    Me.Padding = New System.Windows.Forms.Padding(10)
    Me.Text = "Conditional query"
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Private WithEvents cbxSortOrder As System.Windows.Forms.ComboBox
  Private WithEvents cbxPageCount As System.Windows.Forms.ComboBox
  Private WithEvents txtTitleFilter As System.Windows.Forms.TextBox
  Private WithEvents label4 As System.Windows.Forms.Label
  Private WithEvents label2 As System.Windows.Forms.Label
  Private WithEvents label1 As System.Windows.Forms.Label
  Private WithEvents btnSearch As System.Windows.Forms.Button
  Private WithEvents dataGridView As System.Windows.Forms.DataGridView
End Class
