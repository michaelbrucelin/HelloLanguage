Imports System.Linq.Expressions

Module Module1

  Sub Main()

    '
    ' Test AmazonBookSearch
    '

    Console.WriteLine("-= Testing AmazonBookSearch =-")
    Console.WriteLine()

    Dim search = _
      From book In New AmazonBookSearch() _
      Where _
        book.Title.Contains("ajax") AndAlso _
        (book.Publisher = "Manning") AndAlso _
        (book.Price <= 25) AndAlso _
        (book.Condition = BookCondition.New) _
      Select book

    ' Execute the LINQ to Amazon query
    Dim books = search.ToList()

    ObjectDumper.Write(books, 1)

    Console.WriteLine()
    Console.WriteLine("-= Using LINQ to Objects on the results =-")
    Console.WriteLine()

    ' Pure LINQ to Objects code, without any call to Amazon
    Dim groups = _
      From book In books _
      Group book By book.Year Into years = Group _
      Order By Year Descending _
      Select New With { _
        .Year = Year, _
        .Books = _
           From book In years _
          Select New With {book.Title, book.Authors} _
        }
    For Each group In groups
      Console.WriteLine("Published in " & group.Year)
      For Each book In group.Books
        Console.Write("  ")
        ObjectDumper.Write(book)
      Next
      Console.WriteLine()
    Next

    Console.WriteLine()

    '
    ' Test AmazonBookQueryProvider
    '

    Console.WriteLine("-= Testing AmazonBookQueryProvider =-")
    Console.WriteLine()

    Dim provider = New AmazonBookQueryProvider()
    Dim queryable = New Query(Of AmazonBook)(provider)
    Dim query = _
      From book In queryable _
      Where _
        book.Title.Contains("ajax") AndAlso _
        (book.Publisher = "Manning") AndAlso _
        (book.Price <= 25) AndAlso _
        (book.Condition = BookCondition.New)

    ObjectDumper.Write(query, 1)

    Console.WriteLine()
    Console.WriteLine("URL used: " + query.ToString())

    '
    ' Expression tree
    '

    ' For information, here is the expression tree matching the query above
    'Dim bookParam = Expression.Parameter(GetType(AmazonBook), "book")
    'Dim expressionTree = _
    '  Expression.Lambda(Of Func(Of AmazonBook, Boolean))( _
    '    Expression.AndAlso( _
    '      Expression.AndAlso( _
    '        Expression.AndAlso( _
    '          Expression.Call( _
    '            Expression.Property(bookParam, GetType(AmazonBook).GetProperty("Title")), _
    '            GetType(String).GetMethod("Contains"), _
    '            New Expression() {Expression.Constant("ajax", GetType(String))} _
    '          ), _
    '          Expression.Equal( _
    '            Expression.Property(bookParam, GetType(AmazonBook).GetProperty("Publisher")), _
    '            Expression.Constant("Manning", GetType(String)), _
    '            False, _
    '            GetType(String).GetMethod("op_Equality") _
    '          ) _
    '        ), _
    '        Expression.LessThanOrEqual( _
    '          Expression.Property(bookParam, GetType(AmazonBook).GetProperty("Price")), _
    '          Expression.Constant(25, GetType(Decimal)) _
    '        ) _
    '      ), _
    '      Expression.Equal( _
    '          Expression.Convert( _
    '          Expression.Property(bookParam, GetType(AmazonBook).GetProperty("Condition")), _
    '          GetType(Integer) _
    '        ), _
    '        Expression.Constant(1, GetType(Integer)) _
    '      ) _
    '    ), _
    '    New ParameterExpression() {bookParam} _
    '  )
  End Sub

End Module