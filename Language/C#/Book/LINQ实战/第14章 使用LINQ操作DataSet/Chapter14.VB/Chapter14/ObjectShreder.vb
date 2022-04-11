' This code has been provided by Andrew Conrad from Microsoft
' See http://blogs.msdn.com/aconrad/archive/2007/09/07/science-project.aspx

 Imports System
 Imports System.Collections.Generic
 Imports System.Data
 Imports System.Reflection

Public Class ObjectShredder(Of T)
  Private _fi As FieldInfo()
  Private _pi As PropertyInfo()
  Private _ordinalMap As Dictionary(Of String, Integer)
  Private _type As Type

  Public Sub New()
    _type = GetType(T)
    _fi = _type.GetFields()
    _pi = _type.GetProperties()
    _ordinalMap = New Dictionary(Of String, Integer)()
  End Sub

  Public Function Shred(ByVal source As IEnumerable(Of T), ByVal table As DataTable, _
    ByVal options As LoadOption?) As DataTable

    If GetType(T).IsPrimitive Then
      table = ShredPrimitive(source, table, options)
    End If

    If Table Is Nothing Then
      table = New DataTable(GetType(T).Name)
    End If

    ' now see if need to extend datatable base on the type T + build ordinal map
    table = ExtendTable(table, GetType(T))

    table.BeginLoadData()
    Using e As IEnumerator(Of T) = source.GetEnumerator()
      While e.MoveNext()
        If options IsNot Nothing Then
          table.LoadDataRow(ShredObject(table, e.Current), options.Value)
        Else
          table.LoadDataRow(ShredObject(table, e.Current), True)
        End If
      End While
    End Using
    table.EndLoadData()
    Return table
  End Function

  Public Function ShredPrimitive(ByVal source As IEnumerable(Of T), _
                                 ByVal table As DataTable, ByVal options As LoadOption?) As DataTable
    If table Is Nothing Then
      table = New DataTable(GetType(T).Name)
    End If

    If Not table.Columns.Contains("Value") Then
      table.Columns.Add("Value", GetType(T))
    End If

    table.BeginLoadData()
    Using e As IEnumerator(Of T) = source.GetEnumerator()
      Dim values = New Object(table.Columns.Count - 1) {}
      While e.MoveNext()
        values(table.Columns("Value").Ordinal) = e.Current
        If Not options Is Nothing Then
          table.LoadDataRow(values, options.Value)
        Else
          table.LoadDataRow(values, True)
        End If
      End While
    End Using
    table.EndLoadData()
    Return table
  End Function

  Public Function ExtendTable(ByVal table As DataTable, ByVal type As Type) As DataTable
    ' value is type derived from T, may need to extend table.
    For Each f As FieldInfo In type.GetFields()
      If Not _ordinalMap.ContainsKey(f.Name) Then
        Dim dc As DataColumn = If(table.Columns.Contains(f.Name), table.Columns(f.Name), table.Columns.Add(f.Name, f.FieldType))
        _ordinalMap.Add(f.Name, dc.Ordinal)
      End If
    Next
    For Each p As PropertyInfo In type.GetProperties()
      If Not _ordinalMap.ContainsKey(p.Name) Then
        Dim dc As DataColumn = If(table.Columns.Contains(p.Name), table.Columns(p.Name), table.Columns.Add(p.Name, p.PropertyType))
        _ordinalMap.Add(p.Name, dc.Ordinal)
      End If
    Next
    Return table
  End Function

  Public Function ShredObject(ByVal table As DataTable, ByVal instance As T) As Object()
    Dim fi As FieldInfo() = _fi
    Dim pi As PropertyInfo() = _pi

    If instance.GetType() IsNot GetType(T) Then
      ExtendTable(table, instance.GetType())
      fi = instance.GetType().GetFields()
      pi = instance.GetType().GetProperties()
    End If

    Dim values As Object() = New Object(table.Columns.Count - 1) {}
    For Each f As FieldInfo In fi
      values(_ordinalMap(f.Name)) = f.GetValue(instance)
    Next

    For Each p As PropertyInfo In pi
      values(_ordinalMap(p.Name)) = p.GetValue(instance, Nothing)
    Next
    Return values
  End Function
End Class