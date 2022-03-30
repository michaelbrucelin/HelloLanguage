Public Class FormMain

  Private Sub lnkFormStrings_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFormStrings.LinkClicked
    Dim frm = New FormStrings()
    frm.Show()
  End Sub

  Private Sub lnkFormBooks_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFormBooks.LinkClicked
    Dim frm = New FormBooks()
    frm.Show()
  End Sub
End Class