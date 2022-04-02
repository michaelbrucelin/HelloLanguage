'Option Strict On

Module Module1

  Class Class1
  End Class

  Class Class2
    Public Sub Method1(ByVal s As String)
      Console.WriteLine("Class2.Method1")
    End Sub
  End Class

  Class Class3
    Public Sub Method1(ByVal o As Object)
      Console.WriteLine("Class3.Method1")
    End Sub
  End Class

  Class Class4
    Public Sub Method1(ByVal i As Integer)
      Console.WriteLine("Class4.Method1")
    End Sub
  End Class

  <System.Runtime.CompilerServices.Extension()> _
  Public Sub Method1(ByVal o As Object, ByVal i As Integer)
    Console.WriteLine("Extensions.Method1")
  End Sub

  Sub Main()
    Dim c1 As Class1 = New Class1()
    c1.Method1(12) ' Extensions.Method1 is called

    Dim c2 As Class2 = New Class2()
    c2.Method1(12)
    'Method1(New Class2(), 12)
    ' Class2.Method1 is called if Option Strict is Off
    ' The following compilation error happens if Option Strict is On: "Option Strict On disallows implicit conversions from 'Integer' to 'String'"

    Dim c3 As Class3 = New Class3()
    c3.Method1(12) ' Class3.Method1 is called

    Dim c4 As Class4 = New Class4()
    c4.Method1(12) ' Class4.Method1 is called
  End Sub

End Module
