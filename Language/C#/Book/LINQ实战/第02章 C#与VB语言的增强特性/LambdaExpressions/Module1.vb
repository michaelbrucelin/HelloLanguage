Module Module1

  Class Customer
    Public Name As String
  End Class

  Class Person
    Public Age As Int32
    Public City As String
  End Class

  Class ProcessData
    Public Id As Int32
    Public Memory As Int64
    Public Name As String
  End Class

  Sub DisplayProcesses(ByVal match As Predicate(Of Process))
    Dim processes = New List(Of ProcessData)()
    For Each process In System.Diagnostics.Process.GetProcesses()
      If match(process) Then
        processes.Add(New ProcessData With {.Id = process.Id, _
            .Name = process.ProcessName, .Memory = process.WorkingSet64})
      End If
    Next

    ObjectDumper.Write(processes)
  End Sub

  Sub Main()
    DisplayProcesses(Function(process) process.WorkingSet64 >= 20 * 1024 * 1024)

    '
    ' Sample lambda expressions
    '

    Dim lambda1 = Function(x) x + 1              ' Implicitly typed
    Dim lambda2 = Function(x As Integer) x + 1   ' Explicitly typed
    Dim lambda3 = Function(x, y) x * y           ' Multiple parameters
    Dim lambda4 = Function() 1                   ' No parameters
    Dim lambda5 = Function(customer) customer.Name
    Dim lambda6 = Function(person) person.City = "Paris"
    Dim lambda7 = Function(person, minAge) person.Age >= minAge
    Dim lambda8 = Function(customer) customer.Name
    Dim lambda9 = Function(person) person.City = "Paris"
    Dim lambda10 = Function(person, minAge) person.Age >= minAge

    ' lambda expression without parameter
    Dim getDateTime As Func(Of DateTime) = Function() DateTime.Now

    ' lambda expression with an implicitly-typed String parameter
    Dim upperImplicit As Func(Of String, String) = Function(s) s.ToUpper()

    ' lambda expression with an explicitly-typed string parameter
    Dim upperExplicit As Func(Of String, String) = Function(s As String) s.ToUpper()

    ' lambda expression with two implicitly-typed parameters
    Dim sumInts As Func(Of Integer, Integer, Integer) = Function(x, y) x + y

    ' Predicate<T> and Func<T, Boolean> are equivalent (but not compatible)
    Dim equalsOne1 As Predicate(Of Integer) = Function(x) x = 1
    Dim equalsOne2 As Func(Of Integer, Boolean) = Function(x) x = 1

    ' same lambda expression but different delegate types
    Dim incInt As Func(Of Integer, Integer) = Function(x) x + 1
    Dim incIntAsDouble As Func(Of Integer, Double) = Function(x) x + 1
  End Sub

End Module