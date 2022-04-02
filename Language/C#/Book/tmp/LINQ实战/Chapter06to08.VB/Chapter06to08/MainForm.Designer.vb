<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
    Me.SampleTreeview = New System.Windows.Forms.TreeView
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.Button1 = New System.Windows.Forms.Button
    Me.btnRun = New System.Windows.Forms.Button
    Me.DescriptionLabel = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.ListingLabel = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.ChapterLabel = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.OutputTextBox = New System.Windows.Forms.TextBox
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SampleTreeview
    '
    Me.SampleTreeview.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SampleTreeview.HideSelection = False
    Me.SampleTreeview.Location = New System.Drawing.Point(0, 0)
    Me.SampleTreeview.Name = "SampleTreeview"
    Me.SampleTreeview.Size = New System.Drawing.Size(311, 506)
    Me.SampleTreeview.TabIndex = 0
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SampleTreeview)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnRun)
    Me.SplitContainer1.Panel2.Controls.Add(Me.DescriptionLabel)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel2.Controls.Add(Me.ListingLabel)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel2.Controls.Add(Me.ChapterLabel)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel2.Controls.Add(Me.OutputTextBox)
    Me.SplitContainer1.Size = New System.Drawing.Size(938, 506)
    Me.SplitContainer1.SplitterDistance = 311
    Me.SplitContainer1.TabIndex = 1
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(261, 54)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 8
    Me.Button1.Text = "Run All"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'btnRun
    '
    Me.btnRun.Location = New System.Drawing.Point(18, 54)
    Me.btnRun.Name = "btnRun"
    Me.btnRun.Size = New System.Drawing.Size(75, 23)
    Me.btnRun.TabIndex = 7
    Me.btnRun.Text = "Run"
    Me.btnRun.UseVisualStyleBackColor = True
    '
    'DescriptionLabel
    '
    Me.DescriptionLabel.AutoSize = True
    Me.DescriptionLabel.Location = New System.Drawing.Point(81, 37)
    Me.DescriptionLabel.Name = "DescriptionLabel"
    Me.DescriptionLabel.Size = New System.Drawing.Size(0, 13)
    Me.DescriptionLabel.TabIndex = 6
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(15, 37)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(63, 13)
    Me.Label6.TabIndex = 5
    Me.Label6.Text = "Description:"
    '
    'ListingLabel
    '
    Me.ListingLabel.AutoSize = True
    Me.ListingLabel.Location = New System.Drawing.Point(258, 13)
    Me.ListingLabel.Name = "ListingLabel"
    Me.ListingLabel.Size = New System.Drawing.Size(0, 13)
    Me.ListingLabel.TabIndex = 4
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(192, 13)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(40, 13)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Listing:"
    '
    'ChapterLabel
    '
    Me.ChapterLabel.AutoSize = True
    Me.ChapterLabel.Location = New System.Drawing.Point(81, 13)
    Me.ChapterLabel.Name = "ChapterLabel"
    Me.ChapterLabel.Size = New System.Drawing.Size(0, 13)
    Me.ChapterLabel.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(15, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Chapter:"
    '
    'OutputTextBox
    '
    Me.OutputTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.OutputTextBox.Location = New System.Drawing.Point(3, 86)
    Me.OutputTextBox.Multiline = True
    Me.OutputTextBox.Name = "OutputTextBox"
    Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.OutputTextBox.Size = New System.Drawing.Size(617, 420)
    Me.OutputTextBox.TabIndex = 0
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(938, 506)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Name = "MainForm"
    Me.Text = "LINQ In Action samples"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SampleTreeview As System.Windows.Forms.TreeView
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
  Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents ListingLabel As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ChapterLabel As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnRun As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
