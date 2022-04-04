Imports LinqInAction.Chapter06to08.Common.SampleClasses.Ch8
Namespace CodeSamples
    Public Class EditingForm

        Private Sub EditingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim context As New Ch8DataContext(My.Settings.liaConnectionString)
            Dim query = From p In context.Publishers _
                                    Select p

            Me.BindingSource1.DataSource = query.ToList
        End Sub
    End Class
End Namespace