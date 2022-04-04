Option Strict On

Imports LinqInAction.Chapter06to08.Common
Imports System.IO

Public Class MainForm
  Private _SampleList As New List(Of SampleClass)
  Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _SampleList.Add(New CodeSamples.Ch6Samples)
    _SampleList.Add(New CodeSamples.Ch7Samples)
    _SampleList.Add(New CodeSamples.Ch8Samples)


    For Each _class In _SampleList
      Dim ClassNode = Me.SampleTreeview.Nodes.Add(_class.Title)
      ClassNode.Tag = _class
      For Each item As SampleItem In _class
        Dim ItemNode = ClassNode.Nodes.Add(item.Description)
        ItemNode.Tag = item
      Next
    Next
  End Sub

  Dim CurrentSample As SampleItem
  Dim CurrentClass As SampleClass

  Private Sub SampleTreeview_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles SampleTreeview.AfterSelect
    Dim selectedNode As TreeNode = SampleTreeview.SelectedNode
    CurrentSample = TryCast(selectedNode.Tag, SampleItem)

    If CurrentSample IsNot Nothing Then
      CurrentClass = TryCast(selectedNode.Parent.Tag, SampleClass)
      ChapterLabel.Text = CurrentSample.Chapter.ToString
      ListingLabel.Text = CurrentSample.ListingNumber.ToString
      DescriptionLabel.Text = CurrentSample.Description
      btnRun.Enabled = True
    Else
      ChapterLabel.Text = ""
      ListingLabel.Text = ""
      DescriptionLabel.Text = ""
      btnRun.Enabled = False
    End If
  End Sub

  Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
    OutputTextBox.Text = ""
    If Not CurrentSample Is Nothing Then
      RunSample(CurrentClass, CurrentSample)
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    OutputTextBox.Text = ""
    For Each sampleClass In _SampleList
      For Each item As SampleItem In sampleClass
        RunSample(sampleClass, item)
      Next
    Next
  End Sub

  Private Sub RunSample(ByVal currentClass As SampleClass, ByVal currentSample As SampleItem)
    If Not currentSample Is Nothing Then
      MyBase.UseWaitCursor = True
      Dim newOut As StreamWriter = CurrentClass.OutputStreamWriter
      Dim out As TextWriter = Console.Out
      Console.SetOut(newOut)
      Dim baseStream As MemoryStream = DirectCast(newOut.BaseStream, MemoryStream)
      baseStream.SetLength(CLng(0))
      Try
        currentSample.Method.Invoke(CurrentClass, Nothing)
      Catch ex As Exception
        Console.WriteLine(ex.InnerException.ToString)
      End Try

      newOut.Flush()
      Console.SetOut(out)
      OutputTextBox.Text = (OutputTextBox.Text & newOut.Encoding.GetString(baseStream.ToArray))
      MyBase.UseWaitCursor = False

    End If
  End Sub
End Class
