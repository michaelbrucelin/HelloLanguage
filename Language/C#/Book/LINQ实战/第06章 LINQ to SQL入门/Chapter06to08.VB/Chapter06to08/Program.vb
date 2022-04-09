Module Program

  Sub Main()
    AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath("..\..\..\..\Chapter06to08.Data\"))
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(False)
    Application.Run(New MainForm())
  End Sub

End Module