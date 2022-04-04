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
    Me.lnkFormBooks = New System.Windows.Forms.LinkLabel
    Me.lnkFormStrings = New System.Windows.Forms.LinkLabel
    Me.SuspendLayout()
    '
    'lnkFormBooks
    '
    Me.lnkFormBooks.AutoSize = True
    Me.lnkFormBooks.Location = New System.Drawing.Point(12, 27)
    Me.lnkFormBooks.Name = "lnkFormBooks"
    Me.lnkFormBooks.Size = New System.Drawing.Size(60, 13)
    Me.lnkFormBooks.TabIndex = 4
    Me.lnkFormBooks.TabStop = True
    Me.lnkFormBooks.Text = "FormBooks"
    '
    'lnkFormStrings
    '
    Me.lnkFormStrings.AutoSize = True
    Me.lnkFormStrings.Location = New System.Drawing.Point(12, 9)
    Me.lnkFormStrings.Name = "lnkFormStrings"
    Me.lnkFormStrings.Size = New System.Drawing.Size(62, 13)
    Me.lnkFormStrings.TabIndex = 3
    Me.lnkFormStrings.TabStop = True
    Me.lnkFormStrings.Text = "FormStrings"
    '
    'FormMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(292, 271)
    Me.Controls.Add(Me.lnkFormBooks)
    Me.Controls.Add(Me.lnkFormStrings)
    Me.Name = "FormMain"
    Me.Text = "LINQ in Action - Chapter 4"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Private WithEvents lnkFormBooks As System.Windows.Forms.LinkLabel
  Private WithEvents lnkFormStrings As System.Windows.Forms.LinkLabel

End Class
