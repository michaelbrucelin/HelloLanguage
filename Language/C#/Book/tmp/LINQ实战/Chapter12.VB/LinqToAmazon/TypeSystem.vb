' The code in this file comes from Matt Warren's series of blog posts on how to build a LINQ provider
' http://blogs.msdn.com/mattwar/archive/2007/08/09/linq-building-an-iqueryable-provider-part-i.aspx
' Converted to VB

Imports System.Reflection

Friend NotInheritable Class TypeSystem
  Private Sub New()
  End Sub
  Private Shared Function FindIEnumerable(ByVal seqType As Type) As Type
    If seqType Is Nothing OrElse seqType Is GetType(String) Then
      Return Nothing
    End If
    If seqType.IsArray Then
      Return GetType(IEnumerable(Of )).MakeGenericType(seqType.GetElementType())
    End If
    If seqType.IsGenericType Then
      For Each arg As Type In seqType.GetGenericArguments()
        Dim ienum As Type = GetType(IEnumerable(Of )).MakeGenericType(arg)
        If ienum.IsAssignableFrom(seqType) Then
          Return ienum
        End If
      Next
    End If
    Dim ifaces As Type() = seqType.GetInterfaces()
    If ifaces IsNot Nothing AndAlso ifaces.Length > 0 Then
      For Each iface As Type In ifaces
        Dim ienum As Type = FindIEnumerable(iface)
        If ienum IsNot Nothing Then
          Return ienum
        End If
      Next
    End If
    If seqType.BaseType IsNot Nothing AndAlso Not seqType.BaseType Is GetType(Object) Then
      Return FindIEnumerable(seqType.BaseType)
    End If
    Return Nothing
  End Function

  Friend Shared Function GetSequenceType(ByVal elementType As Type) As Type
    Return GetType(IEnumerable(Of )).MakeGenericType(elementType)
  End Function

  Friend Shared Function GetElementType(ByVal seqType As Type) As Type
    Dim ienum As Type = FindIEnumerable(seqType)
    If ienum Is Nothing Then
      Return seqType
    End If
    Return ienum.GetGenericArguments()(0)
  End Function

  Friend Shared Function IsNullableType(ByVal type As Type) As Boolean
    Return type IsNot Nothing AndAlso type.IsGenericType AndAlso type.GetGenericTypeDefinition() Is GetType(Nullable(Of ))
  End Function

  Friend Shared Function IsNullAssignable(ByVal type As Type) As Boolean
    Return Not type.IsValueType OrElse IsNullableType(type)
  End Function

  Friend Shared Function GetNonNullableType(ByVal type As Type) As Type
    If IsNullableType(type) Then
      Return type.GetGenericArguments()(0)
    End If
    Return type
  End Function

  Friend Shared Function GetMemberType(ByVal mi As MemberInfo) As Type
    Dim fi As FieldInfo = TryCast(mi, FieldInfo)
    If fi IsNot Nothing Then
      Return fi.FieldType
    End If
    Dim pi As PropertyInfo = TryCast(mi, PropertyInfo)
    If pi IsNot Nothing Then
      Return pi.PropertyType
    End If
    Dim ei As EventInfo = TryCast(mi, EventInfo)
    If ei IsNot Nothing Then
      Return ei.EventHandlerType
    End If
    Return Nothing
  End Function
End Class