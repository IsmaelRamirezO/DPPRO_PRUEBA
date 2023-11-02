Public Interface IVentasReporter

    Property ConnectionString() As String
    Function Run() As DataSet
    Function RunNew() As DataSet
    Function RunNewPreview() As DataSet
    Function RunFolioSAP() As DataSet

End Interface
