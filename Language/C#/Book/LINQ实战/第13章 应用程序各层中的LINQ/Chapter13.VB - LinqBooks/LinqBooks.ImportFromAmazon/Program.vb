Module Program

  Sub Main()
    AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath("..\..\..\LinqBooks.Web\App_Data\"))
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(False)
    Application.Run(New ImportForm())
  End Sub

End Module