<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.tabControl1 = New System.Windows.Forms.TabControl
    Me.tabPageLoading = New System.Windows.Forms.TabPage
    Me.btnTestLoading = New System.Windows.Forms.Button
    Me.tabPageWithoutLinq = New System.Windows.Forms.TabPage
    Me.btnDataTableSelect = New System.Windows.Forms.Button
    Me.btnDataViewsRelationships = New System.Windows.Forms.Button
    Me.btnDataViews = New System.Windows.Forms.Button
    Me.tabPageUntypedDataSet = New System.Windows.Forms.TabPage
    Me.btnUntypedDataView = New System.Windows.Forms.Button
    Me.btnUntypedRelationship = New System.Windows.Forms.Button
    Me.btnUntypedJoin = New System.Windows.Forms.Button
    Me.btnUntypedSimple = New System.Windows.Forms.Button
    Me.tabPageTypedDataSet = New System.Windows.Forms.TabPage
    Me.btnTypedDataView = New System.Windows.Forms.Button
    Me.btnTypedRelationship = New System.Windows.Forms.Button
    Me.btnTypedJoin = New System.Windows.Forms.Button
    Me.btnTypedSimple = New System.Windows.Forms.Button
    Me.tabPageCopyToDataTable = New System.Windows.Forms.TabPage
    Me.btnShowChanges = New System.Windows.Forms.Button
    Me.btnCopyToDataTable = New System.Windows.Forms.Button
    Me.tabPageDataRowComparer = New System.Windows.Forms.TabPage
    Me.btnIntersect = New System.Windows.Forms.Button
    Me.splitContainer1 = New System.Windows.Forms.SplitContainer
    Me.dataGridView1 = New System.Windows.Forms.DataGridView
    Me.label2 = New System.Windows.Forms.Label
    Me.dataGridView2 = New System.Windows.Forms.DataGridView
    Me.label1 = New System.Windows.Forms.Label
    Me.Panel1.SuspendLayout()
    Me.tabControl1.SuspendLayout()
    Me.tabPageLoading.SuspendLayout()
    Me.tabPageWithoutLinq.SuspendLayout()
    Me.tabPageUntypedDataSet.SuspendLayout()
    Me.tabPageTypedDataSet.SuspendLayout()
    Me.tabPageCopyToDataTable.SuspendLayout()
    Me.tabPageDataRowComparer.SuspendLayout()
    Me.splitContainer1.Panel1.SuspendLayout()
    Me.splitContainer1.Panel2.SuspendLayout()
    Me.splitContainer1.SuspendLayout()
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.tabControl1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(590, 62)
    Me.Panel1.TabIndex = 0
    '
    'tabControl1
    '
    Me.tabControl1.Controls.Add(Me.tabPageLoading)
    Me.tabControl1.Controls.Add(Me.tabPageWithoutLinq)
    Me.tabControl1.Controls.Add(Me.tabPageUntypedDataSet)
    Me.tabControl1.Controls.Add(Me.tabPageTypedDataSet)
    Me.tabControl1.Controls.Add(Me.tabPageCopyToDataTable)
    Me.tabControl1.Controls.Add(Me.tabPageDataRowComparer)
    Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tabControl1.Location = New System.Drawing.Point(0, 0)
    Me.tabControl1.Name = "tabControl1"
    Me.tabControl1.SelectedIndex = 0
    Me.tabControl1.Size = New System.Drawing.Size(590, 62)
    Me.tabControl1.TabIndex = 37
    '
    'tabPageLoading
    '
    Me.tabPageLoading.Controls.Add(Me.btnTestLoading)
    Me.tabPageLoading.Location = New System.Drawing.Point(4, 22)
    Me.tabPageLoading.Name = "tabPageLoading"
    Me.tabPageLoading.Padding = New System.Windows.Forms.Padding(3)
    Me.tabPageLoading.Size = New System.Drawing.Size(582, 36)
    Me.tabPageLoading.TabIndex = 1
    Me.tabPageLoading.Text = "Loading"
    Me.tabPageLoading.UseVisualStyleBackColor = True
    '
    'btnTestLoading
    '
    Me.btnTestLoading.Location = New System.Drawing.Point(8, 6)
    Me.btnTestLoading.Name = "btnTestLoading"
    Me.btnTestLoading.Size = New System.Drawing.Size(101, 23)
    Me.btnTestLoading.TabIndex = 23
    Me.btnTestLoading.Text = "Test loading"
    Me.btnTestLoading.UseVisualStyleBackColor = True
    '
    'tabPageWithoutLinq
    '
    Me.tabPageWithoutLinq.Controls.Add(Me.btnDataTableSelect)
    Me.tabPageWithoutLinq.Controls.Add(Me.btnDataViewsRelationships)
    Me.tabPageWithoutLinq.Controls.Add(Me.btnDataViews)
    Me.tabPageWithoutLinq.Location = New System.Drawing.Point(4, 22)
    Me.tabPageWithoutLinq.Name = "tabPageWithoutLinq"
    Me.tabPageWithoutLinq.Padding = New System.Windows.Forms.Padding(3)
    Me.tabPageWithoutLinq.Size = New System.Drawing.Size(582, 36)
    Me.tabPageWithoutLinq.TabIndex = 0
    Me.tabPageWithoutLinq.Text = "Without LINQ"
    Me.tabPageWithoutLinq.UseVisualStyleBackColor = True
    '
    'btnDataTableSelect
    '
    Me.btnDataTableSelect.Location = New System.Drawing.Point(8, 8)
    Me.btnDataTableSelect.Name = "btnDataTableSelect"
    Me.btnDataTableSelect.Size = New System.Drawing.Size(109, 23)
    Me.btnDataTableSelect.TabIndex = 0
    Me.btnDataTableSelect.Text = "DataTable.Select"
    Me.btnDataTableSelect.UseVisualStyleBackColor = True
    '
    'btnDataViewsRelationships
    '
    Me.btnDataViewsRelationships.Location = New System.Drawing.Point(238, 8)
    Me.btnDataViewsRelationships.Name = "btnDataViewsRelationships"
    Me.btnDataViewsRelationships.Size = New System.Drawing.Size(158, 23)
    Me.btnDataViewsRelationships.TabIndex = 2
    Me.btnDataViewsRelationships.Text = "DataViews and Relationships"
    Me.btnDataViewsRelationships.UseVisualStyleBackColor = True
    '
    'btnDataViews
    '
    Me.btnDataViews.Location = New System.Drawing.Point(123, 8)
    Me.btnDataViews.Name = "btnDataViews"
    Me.btnDataViews.Size = New System.Drawing.Size(109, 23)
    Me.btnDataViews.TabIndex = 1
    Me.btnDataViews.Text = "DataViews"
    Me.btnDataViews.UseVisualStyleBackColor = True
    '
    'tabPageUntypedDataSet
    '
    Me.tabPageUntypedDataSet.Controls.Add(Me.btnUntypedDataView)
    Me.tabPageUntypedDataSet.Controls.Add(Me.btnUntypedRelationship)
    Me.tabPageUntypedDataSet.Controls.Add(Me.btnUntypedJoin)
    Me.tabPageUntypedDataSet.Controls.Add(Me.btnUntypedSimple)
    Me.tabPageUntypedDataSet.Location = New System.Drawing.Point(4, 22)
    Me.tabPageUntypedDataSet.Name = "tabPageUntypedDataSet"
    Me.tabPageUntypedDataSet.Size = New System.Drawing.Size(582, 36)
    Me.tabPageUntypedDataSet.TabIndex = 2
    Me.tabPageUntypedDataSet.Text = "Untyped DataSet"
    Me.tabPageUntypedDataSet.UseVisualStyleBackColor = True
    '
    'btnUntypedDataView
    '
    Me.btnUntypedDataView.Location = New System.Drawing.Point(337, 7)
    Me.btnUntypedDataView.Name = "btnUntypedDataView"
    Me.btnUntypedDataView.Size = New System.Drawing.Size(75, 23)
    Me.btnUntypedDataView.TabIndex = 29
    Me.btnUntypedDataView.Text = "DataView"
    Me.btnUntypedDataView.UseVisualStyleBackColor = True
    '
    'btnUntypedRelationship
    '
    Me.btnUntypedRelationship.Location = New System.Drawing.Point(222, 7)
    Me.btnUntypedRelationship.Name = "btnUntypedRelationship"
    Me.btnUntypedRelationship.Size = New System.Drawing.Size(109, 23)
    Me.btnUntypedRelationship.TabIndex = 28
    Me.btnUntypedRelationship.Text = "With relationship"
    Me.btnUntypedRelationship.UseVisualStyleBackColor = True
    '
    'btnUntypedJoin
    '
    Me.btnUntypedJoin.Location = New System.Drawing.Point(115, 7)
    Me.btnUntypedJoin.Name = "btnUntypedJoin"
    Me.btnUntypedJoin.Size = New System.Drawing.Size(101, 23)
    Me.btnUntypedJoin.TabIndex = 27
    Me.btnUntypedJoin.Text = "With join"
    Me.btnUntypedJoin.UseVisualStyleBackColor = True
    '
    'btnUntypedSimple
    '
    Me.btnUntypedSimple.Location = New System.Drawing.Point(8, 7)
    Me.btnUntypedSimple.Name = "btnUntypedSimple"
    Me.btnUntypedSimple.Size = New System.Drawing.Size(101, 23)
    Me.btnUntypedSimple.TabIndex = 26
    Me.btnUntypedSimple.Text = "Simple query"
    Me.btnUntypedSimple.UseVisualStyleBackColor = True
    '
    'tabPageTypedDataSet
    '
    Me.tabPageTypedDataSet.Controls.Add(Me.btnTypedDataView)
    Me.tabPageTypedDataSet.Controls.Add(Me.btnTypedRelationship)
    Me.tabPageTypedDataSet.Controls.Add(Me.btnTypedJoin)
    Me.tabPageTypedDataSet.Controls.Add(Me.btnTypedSimple)
    Me.tabPageTypedDataSet.Location = New System.Drawing.Point(4, 22)
    Me.tabPageTypedDataSet.Name = "tabPageTypedDataSet"
    Me.tabPageTypedDataSet.Size = New System.Drawing.Size(582, 36)
    Me.tabPageTypedDataSet.TabIndex = 3
    Me.tabPageTypedDataSet.Text = "Typed DataSet"
    Me.tabPageTypedDataSet.UseVisualStyleBackColor = True
    '
    'btnTypedDataView
    '
    Me.btnTypedDataView.Location = New System.Drawing.Point(337, 7)
    Me.btnTypedDataView.Name = "btnTypedDataView"
    Me.btnTypedDataView.Size = New System.Drawing.Size(75, 23)
    Me.btnTypedDataView.TabIndex = 30
    Me.btnTypedDataView.Text = "DataView"
    Me.btnTypedDataView.UseVisualStyleBackColor = True
    '
    'btnTypedRelationship
    '
    Me.btnTypedRelationship.Location = New System.Drawing.Point(222, 7)
    Me.btnTypedRelationship.Name = "btnTypedRelationship"
    Me.btnTypedRelationship.Size = New System.Drawing.Size(109, 23)
    Me.btnTypedRelationship.TabIndex = 29
    Me.btnTypedRelationship.Text = "With relationship"
    Me.btnTypedRelationship.UseVisualStyleBackColor = True
    '
    'btnTypedJoin
    '
    Me.btnTypedJoin.Location = New System.Drawing.Point(115, 7)
    Me.btnTypedJoin.Name = "btnTypedJoin"
    Me.btnTypedJoin.Size = New System.Drawing.Size(101, 23)
    Me.btnTypedJoin.TabIndex = 28
    Me.btnTypedJoin.Text = "With join"
    Me.btnTypedJoin.UseVisualStyleBackColor = True
    '
    'btnTypedSimple
    '
    Me.btnTypedSimple.Location = New System.Drawing.Point(8, 7)
    Me.btnTypedSimple.Name = "btnTypedSimple"
    Me.btnTypedSimple.Size = New System.Drawing.Size(101, 23)
    Me.btnTypedSimple.TabIndex = 27
    Me.btnTypedSimple.Text = "Simple query"
    Me.btnTypedSimple.UseVisualStyleBackColor = True
    '
    'tabPageCopyToDataTable
    '
    Me.tabPageCopyToDataTable.Controls.Add(Me.btnShowChanges)
    Me.tabPageCopyToDataTable.Controls.Add(Me.btnCopyToDataTable)
    Me.tabPageCopyToDataTable.Location = New System.Drawing.Point(4, 22)
    Me.tabPageCopyToDataTable.Name = "tabPageCopyToDataTable"
    Me.tabPageCopyToDataTable.Padding = New System.Windows.Forms.Padding(3)
    Me.tabPageCopyToDataTable.Size = New System.Drawing.Size(582, 36)
    Me.tabPageCopyToDataTable.TabIndex = 5
    Me.tabPageCopyToDataTable.Text = "CopyToDataTable"
    Me.tabPageCopyToDataTable.UseVisualStyleBackColor = True
    '
    'btnShowChanges
    '
    Me.btnShowChanges.Enabled = False
    Me.btnShowChanges.Location = New System.Drawing.Point(128, 7)
    Me.btnShowChanges.Name = "btnShowChanges"
    Me.btnShowChanges.Size = New System.Drawing.Size(108, 23)
    Me.btnShowChanges.TabIndex = 3
    Me.btnShowChanges.Text = "Show changes"
    Me.btnShowChanges.UseVisualStyleBackColor = True
    '
    'btnCopyToDataTable
    '
    Me.btnCopyToDataTable.Location = New System.Drawing.Point(8, 7)
    Me.btnCopyToDataTable.Name = "btnCopyToDataTable"
    Me.btnCopyToDataTable.Size = New System.Drawing.Size(113, 23)
    Me.btnCopyToDataTable.TabIndex = 2
    Me.btnCopyToDataTable.Text = "CopyToDataTable"
    Me.btnCopyToDataTable.UseVisualStyleBackColor = True
    '
    'tabPageDataRowComparer
    '
    Me.tabPageDataRowComparer.Controls.Add(Me.btnIntersect)
    Me.tabPageDataRowComparer.Location = New System.Drawing.Point(4, 22)
    Me.tabPageDataRowComparer.Name = "tabPageDataRowComparer"
    Me.tabPageDataRowComparer.Padding = New System.Windows.Forms.Padding(3)
    Me.tabPageDataRowComparer.Size = New System.Drawing.Size(582, 36)
    Me.tabPageDataRowComparer.TabIndex = 4
    Me.tabPageDataRowComparer.Text = "DataRowComparer"
    Me.tabPageDataRowComparer.UseVisualStyleBackColor = True
    '
    'btnIntersect
    '
    Me.btnIntersect.Location = New System.Drawing.Point(8, 6)
    Me.btnIntersect.Name = "btnIntersect"
    Me.btnIntersect.Size = New System.Drawing.Size(75, 23)
    Me.btnIntersect.TabIndex = 1
    Me.btnIntersect.Text = "Intersect"
    Me.btnIntersect.UseVisualStyleBackColor = True
    '
    'splitContainer1
    '
    Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.splitContainer1.Location = New System.Drawing.Point(0, 62)
    Me.splitContainer1.Name = "splitContainer1"
    Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'splitContainer1.Panel1
    '
    Me.splitContainer1.Panel1.Controls.Add(Me.dataGridView1)
    Me.splitContainer1.Panel1.Controls.Add(Me.label2)
    '
    'splitContainer1.Panel2
    '
    Me.splitContainer1.Panel2.Controls.Add(Me.dataGridView2)
    Me.splitContainer1.Panel2.Controls.Add(Me.label1)
    Me.splitContainer1.Size = New System.Drawing.Size(590, 259)
    Me.splitContainer1.SplitterDistance = 92
    Me.splitContainer1.TabIndex = 2
    '
    'dataGridView1
    '
    Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dataGridView1.Location = New System.Drawing.Point(0, 13)
    Me.dataGridView1.Name = "dataGridView1"
    Me.dataGridView1.Size = New System.Drawing.Size(590, 79)
    Me.dataGridView1.TabIndex = 4
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Dock = System.Windows.Forms.DockStyle.Top
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(0, 0)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(65, 13)
    Me.label2.TabIndex = 3
    Me.label2.Text = "Publishers"
    '
    'dataGridView2
    '
    Me.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dataGridView2.Location = New System.Drawing.Point(0, 13)
    Me.dataGridView2.Name = "dataGridView2"
    Me.dataGridView2.Size = New System.Drawing.Size(590, 150)
    Me.dataGridView2.TabIndex = 2
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Dock = System.Windows.Forms.DockStyle.Top
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(0, 0)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(42, 13)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Books"
    '
    'FormMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(590, 321)
    Me.Controls.Add(Me.splitContainer1)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "FormMain"
    Me.Text = "LINQ to DataSet"
    Me.Panel1.ResumeLayout(False)
    Me.tabControl1.ResumeLayout(False)
    Me.tabPageLoading.ResumeLayout(False)
    Me.tabPageWithoutLinq.ResumeLayout(False)
    Me.tabPageUntypedDataSet.ResumeLayout(False)
    Me.tabPageTypedDataSet.ResumeLayout(False)
    Me.tabPageCopyToDataTable.ResumeLayout(False)
    Me.tabPageDataRowComparer.ResumeLayout(False)
    Me.splitContainer1.Panel1.ResumeLayout(False)
    Me.splitContainer1.Panel1.PerformLayout()
    Me.splitContainer1.Panel2.ResumeLayout(False)
    Me.splitContainer1.Panel2.PerformLayout()
    Me.splitContainer1.ResumeLayout(False)
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Private WithEvents tabControl1 As System.Windows.Forms.TabControl
  Private WithEvents tabPageLoading As System.Windows.Forms.TabPage
  Private WithEvents btnTestLoading As System.Windows.Forms.Button
  Private WithEvents tabPageWithoutLinq As System.Windows.Forms.TabPage
  Private WithEvents btnDataTableSelect As System.Windows.Forms.Button
  Private WithEvents btnDataViewsRelationships As System.Windows.Forms.Button
  Private WithEvents btnDataViews As System.Windows.Forms.Button
  Private WithEvents tabPageUntypedDataSet As System.Windows.Forms.TabPage
  Private WithEvents btnUntypedDataView As System.Windows.Forms.Button
  Private WithEvents btnUntypedRelationship As System.Windows.Forms.Button
  Private WithEvents btnUntypedJoin As System.Windows.Forms.Button
  Private WithEvents btnUntypedSimple As System.Windows.Forms.Button
  Private WithEvents tabPageTypedDataSet As System.Windows.Forms.TabPage
  Private WithEvents btnTypedDataView As System.Windows.Forms.Button
  Private WithEvents btnTypedRelationship As System.Windows.Forms.Button
  Private WithEvents btnTypedJoin As System.Windows.Forms.Button
  Private WithEvents btnTypedSimple As System.Windows.Forms.Button
  Private WithEvents tabPageCopyToDataTable As System.Windows.Forms.TabPage
  Private WithEvents btnShowChanges As System.Windows.Forms.Button
  Private WithEvents btnCopyToDataTable As System.Windows.Forms.Button
  Private WithEvents tabPageDataRowComparer As System.Windows.Forms.TabPage
  Private WithEvents btnIntersect As System.Windows.Forms.Button
  Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
  Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
  Private WithEvents label2 As System.Windows.Forms.Label
  Private WithEvents dataGridView2 As System.Windows.Forms.DataGridView
  Private WithEvents label1 As System.Windows.Forms.Label
End Class
