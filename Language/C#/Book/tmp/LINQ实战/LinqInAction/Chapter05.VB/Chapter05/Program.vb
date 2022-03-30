Module Program

  Sub Main()
    AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath("..\..\..\..\Data\"))
    Application.EnableVisualStyles()
    Application.Run(New FormMain())
  End Sub

End Module