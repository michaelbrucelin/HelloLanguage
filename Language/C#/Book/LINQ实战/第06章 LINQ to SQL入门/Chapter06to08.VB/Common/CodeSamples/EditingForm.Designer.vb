Namespace CodeSamples

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EditingForm
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
            Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.DataGridView1 = New System.Windows.Forms.DataGridView
            Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.WebSiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Publisher)
            '
            'DataGridView1
            '
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.WebSiteDataGridViewTextBoxColumn})
            Me.DataGridView1.DataSource = Me.BindingSource1
            Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.Size = New System.Drawing.Size(292, 273)
            Me.DataGridView1.TabIndex = 0
            '
            'NameDataGridViewTextBoxColumn
            '
            Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
            Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
            Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
            '
            'WebSiteDataGridViewTextBoxColumn
            '
            Me.WebSiteDataGridViewTextBoxColumn.DataPropertyName = "WebSite"
            Me.WebSiteDataGridViewTextBoxColumn.HeaderText = "WebSite"
            Me.WebSiteDataGridViewTextBoxColumn.Name = "WebSiteDataGridViewTextBoxColumn"
            '
            'EditingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.Add(Me.DataGridView1)
            Me.Name = "EditingForm"
            Me.Text = "EditingForm"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents WebSiteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace