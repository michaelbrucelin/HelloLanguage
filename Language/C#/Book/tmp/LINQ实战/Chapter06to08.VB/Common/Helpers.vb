Imports System.Reflection
Imports System.Data.Linq
Imports System.Runtime.CompilerServices

Module DemoHelper

    <Extension()> _
    Public Function GetChangeText(ByVal context As System.Data.Linq.DataContext) As String
        Dim mi As MethodInfo = GetType(DataContext).GetMethod("GetChangeText", BindingFlags.NonPublic Or BindingFlags.Instance)
        Return mi.Invoke(context, Nothing).ToString
    End Function

    <Extension()> _
    Public Function GetTableName(ByVal context As DataContext, ByVal obj As Object)
        Return context.Mapping.GetTable(obj.GetType()).TableName
    End Function

    Public Function GetDataContext(ByVal obj As System.ComponentModel.INotifyPropertyChanging) As DataContext
        'This won't work for objects outside of LINQ to SQL 
        'nor against entities that may have multipler listeners to PropertyChanging

        Dim _type = obj.GetType

        'get the invocation list for PropertyChanging
        Dim eventMember = (From method In _type.GetFields(BindingFlags.NonPublic Or BindingFlags.Static Or BindingFlags.Instance) _
                          Where method.Name = "PropertyChanging" Select method).Single.GetValue(obj)

        'get a single item or nothing
        Dim invocationItems = TryCast(eventMember, [Delegate])
        If invocationItems IsNot Nothing Then
            Dim invocationItem = invocationItems.GetInvocationList.SingleOrDefault
            'The target of the invocation is the change tracker
            Dim changeTracker = invocationItem.Target
            'Which has a services reference
            Dim services = changeTracker.GetType.GetField("services", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(changeTracker)
            'which has a reference to the context
            Dim context = services.GetType.GetProperty("Context", BindingFlags.Public Or BindingFlags.Instance).GetValue(services, Nothing)
            Return context
        Else
            Return Nothing
        End If
    End Function
End Module
