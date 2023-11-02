Public Class InventarioMovimientoArticulosReporter

    Implements IInventarioReporter

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
    Private m_strArticulo As String
    Private m_strCorDescripcion As String
    Private m_strSInicial As Decimal
    Private m_strSFinal As Decimal
    Private m_strCorridaIni As Decimal
    Private m_strCorridaFin As Decimal
    Private m_dsInvMovArtDetalle As DataSet


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

    Public Property Articulo() As String
        Get
            Return m_strArticulo
        End Get
        Set(ByVal Value As String)
            m_strArticulo = Value
        End Set
    End Property

    Public Property SaldoInicial() As Decimal
        Get
            Return m_strSInicial
        End Get
        Set(ByVal Value As Decimal)
            m_strSInicial = Value
        End Set
    End Property

    Public Property SaldoFinal() As Decimal
        Get
            Return m_strSFinal
        End Get
        Set(ByVal Value As Decimal)
            m_strSFinal = Value
        End Set
    End Property

    Public Property InvMovArtDetalle() As DataSet
        Get
            Return m_dsInvMovArtDetalle
        End Get
        Set(ByVal Value As DataSet)
            m_dsInvMovArtDetalle = Value
        End Set
    End Property
#End Region

    Public Property CorridaIni() As Decimal
        Get
            Return m_strCorridaIni
        End Get
        Set(ByVal Value As Decimal)
            m_strCorridaIni = Value
        End Set
    End Property

    Public Property CorridaFin() As Decimal
        Get
            Return m_strCorridaFin
        End Get
        Set(ByVal Value As Decimal)
            m_strCorridaFin = Value
        End Set
    End Property

    Public Property CorDescripcion() As String
        Get
            Return m_strCorDescripcion
        End Get
        Set(ByVal Value As String)
            m_strCorDescripcion = Value
        End Set
    End Property

#Region "Generador del Reporte"

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        'TODO: CLM - Ejecutar consulta del DataGateway
        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.GetInventarioMovimientoArticulosDetalle(m_strAlmacen, m_strMes, m_strArticulo)

    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

    Public Function Load(ByVal m_strAlmacen As String, ByVal m_strMes As String, ByVal m_strArticulos As String, ByVal m_strConnectionString As String) As InventarioMovimientoArticulosReporter



        Dim oReadIMArticulos As InventarioMovimientoArticulosReporter

        Dim oReadCorridas As InventarioMovimientoArticulosReporter

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)
        oReadIMArticulos = oDataGateway.GetInventarioMovimientoArticulosGeneral(m_strAlmacen, m_strMes, m_strArticulos)



        Return oReadIMArticulos

    End Function


    Public Function LoadCorrida(ByVal m_strArticulos As String, ByVal m_strConnectionString As String) As InventarioMovimientoArticulosReporter

        'If (ID = String.Empty) Then
        '    Throw New ArgumentException("Debe especificar un Código")
        'End If

        'If (ID.Length > 2) Then
        '    Throw New ArgumentException("El Código no debe exceder los 2 caracteres de longitud.")
        'End If

        Dim oReadIMArticulos As InventarioMovimientoArticulosReporter

        Dim oReadCorridas As InventarioMovimientoArticulosReporter

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        oReadCorridas = oDataGateway.GetConsultaCorrida(m_strArticulos)

        Return oReadCorridas

    End Function


#End Region

End Class
