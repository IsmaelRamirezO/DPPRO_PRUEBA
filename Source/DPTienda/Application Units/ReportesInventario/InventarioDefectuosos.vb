Public Class InventarioDefectuosos

    Implements IInventarioReporter

    Private m_strConnectionString As String
    Private m_strAlmacen As String
    Private m_datdsArticulos As DataSet

    Public Property ConnectionString() As String Implements IInventarioReporter.ConnectionString
        Get
        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Me.dsArticulos = oDataGateway.GetInventarioReporteDefectuosos(Me.Almacen)

        Return Me.dsArticulos

    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

    Public Property dsArticulos() As DataSet
        Get
            Return m_datdsArticulos
        End Get
        Set(ByVal Value As DataSet)
            m_datdsArticulos = Value
        End Set
    End Property

End Class
