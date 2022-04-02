Module Module1

  Sub Main()
    Dim array As Object() = {"String", 12, True, "a"c}

    Dim types = _
      array _
        .Select(Function(item) item.GetType().Name) _
        .OrderBy(Function(type) type)

    ObjectDumper.Write(types)
  End Sub

End Module