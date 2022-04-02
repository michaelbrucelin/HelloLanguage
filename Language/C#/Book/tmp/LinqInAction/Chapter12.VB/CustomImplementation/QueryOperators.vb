Imports System.Runtime.CompilerServices

Namespace QueryOperators
  Public Module SomeModule
    ''' <summary>
    ''' Custom implementation of Where with the standard generic signature.
    ''' </summary>
    <Extension()> _
    Public Function Where(Of TSource)( _
      ByVal source As IEnumerable(Of TSource), ByVal predicate As Func(Of TSource, Boolean)) As IEnumerable(Of TSource)
      Console.WriteLine("in CustomImplementation.Where(Of TSource)")
      Return System.Linq.Enumerable.Where(source, predicate)
    End Function

    ''' <summary>
    ''' Custom implementation of Select with the standard generic signature.
    ''' </summary>
    <Extension()> _
    Public Function [Select](Of TSource, TResult)( _
      ByVal source As IEnumerable(Of TSource), ByVal selector As Func(Of TSource, TResult)) As IEnumerable(Of TResult)
      Console.WriteLine("in CustomImplementation.Select(Of TSource, TResult)")
      Return System.Linq.Enumerable.Select(source, selector)
    End Function
  End Module
End Namespace