' This code has been provided by Andrew Conrad from Microsoft
' See http://blogs.msdn.com/aconrad/archive/2007/09/07/science-project.aspx

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Runtime.CompilerServices

Module DataSetLinqOperators
  ''' <summary>
  ''' Creates a <see cref="DataTable"/> that contains the data from a source sequence.
  ''' </summary>
  ''' <remarks>
  ''' The initial schema of the DataTable is based on schema of the type T. All public property and fields are turned into DataColumns.
  ''' If the source sequence contains a sub-type of T, the table is automatically expanded for any addition public properties or fields.
  ''' </remarks>
  <Extension()> _
  Public Function ToDataTable(Of T)(ByVal source As IEnumerable(Of T)) As DataTable
    Return New ObjectShredder(Of T)().Shred(source, Nothing, Nothing)
  End Function

  ''' <summary>
  ''' Loads the data from a source sequence into an existing <see cref="DataTable"/>.
  ''' </summary>
  ''' <remarks>
  ''' The schema of <paramref name="table" /> must be consistent with the schema of the type T (all public property and fields are mapped to DataColumns).
  ''' If the source sequence contains a sub-type of T, the table is automatically expanded for any addition public properties or fields.
  ''' </remarks>
  <Extension()> _
  Public Function LoadSequence(Of T)(ByVal source As IEnumerable(Of T), ByVal table As DataTable, ByVal options As System.Nullable(Of LoadOption)) As DataTable
    If table Is Nothing Then
      Throw New ArgumentNullException("table")
    End If
    Return New ObjectShredder(Of T)().Shred(source, table, options)
  End Function
End Module