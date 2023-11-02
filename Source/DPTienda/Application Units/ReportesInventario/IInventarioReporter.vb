Public Interface IInventarioReporter

    Property ConnectionString() As String
    Function Run() As DataSet
    Function RunTOReport() As DataSet

End Interface