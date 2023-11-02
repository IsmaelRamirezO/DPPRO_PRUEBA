Public Class InventarioUnicosParesReporter
    Implements IInventarioReporter

    Private m_intTipo As Integer

    Private m_strConnectionString As String

    Public Property ConnectionString() As String Implements IInventarioReporter.ConnectionString
        Get
            Return m_strConnectionString
        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property

#Region "Parametros del Reporte"

    Private m_strMes As String
    Private m_strAlmacen As String
    Private m_intMinPares As Integer

    Public Property Mes() As String
        Get
            Return m_strMes
        End Get
        Set(ByVal Value As String)
            m_strMes = Value
        End Set
    End Property

    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

    Public Property MinPares() As Integer
        Get
            Return m_intMinPares
        End Get
        Set(ByVal Value As Integer)
            m_intMinPares = Value
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return m_intTipo
        End Get
        Set(ByVal Value As Integer)
            m_intTipo = Value
        End Set
    End Property

#End Region

#Region "Generador del Reporte"

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        'TODO: CLM - Ejecutar consulta del DataGateway

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.GetInventarioUnicosPares(m_strAlmacen, m_strMes, m_intMinPares, m_intTipo)


    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

#End Region


End Class
