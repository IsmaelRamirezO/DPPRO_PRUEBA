Imports DportenisPro.DPTienda.Core

Public Class InventarioReportesVarios

    Implements IInventarioReporter

#Region "Constructors / Destructors"

    Public Sub New(Optional ByVal ApplicationContext As ApplicationContext = Nothing)

        If Not ApplicationContext Is Nothing Then m_strConnectionString = ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

    End Sub

#End Region

#Region "Properties"

    Private m_strConnectionString As String

    Private m_strCodAlmacen As String = String.Empty
    Private m_intMes As Integer = 0
    Private m_strCodMarca As String = String.Empty
    Private m_strCodOrigen As Integer = 0
    Private m_strCodLinea As String = String.Empty
    Private m_strCodFamilia As String = String.Empty
    Private m_intDip As Integer
    Private m_intTipoFiltro As Integer
    Private m_strSQLString As String

    Private m_datdsArticulos As DataSet

    Public Property ConnectionString() As String Implements IInventarioReporter.ConnectionString
        Get
        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property

    Public Property Mes() As Integer
        Get
            Return m_intMes
        End Get
        Set(ByVal Value As Integer)
            m_intMes = Value
        End Set
    End Property

    Public Property CodLinea() As String
        Get
            Return m_strCodLinea
        End Get
        Set(ByVal Value As String)
            m_strCodLinea = Value
        End Set
    End Property

    Public Property CodFamilia() As String
        Get
            Return m_strCodFamilia
        End Get
        Set(ByVal Value As String)
            m_strCodFamilia = Value
        End Set
    End Property

    Public Property CodMarca() As String
        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value
        End Set
    End Property

    Public Property CodOrigen() As Integer
        Get
            Return m_strCodOrigen
        End Get
        Set(ByVal Value As Integer)
            m_strCodOrigen = Value
        End Set
    End Property

    Public Property Dip() As Integer
        Get
            Return m_intDip
        End Get
        Set(ByVal Value As Integer)
            m_intDip = Value
        End Set
    End Property

    Public Property TipoFiltro() As Integer
        Get
            Return m_intTipoFiltro
        End Get
        Set(ByVal Value As Integer)
            m_intTipoFiltro = Value
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set
    End Property

    Public Property SQLString() As String
        Get
            Return m_strSQLString
        End Get
        Set(ByVal Value As String)
            m_strSQLString = Value
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

#End Region

#Region "Methods"

    Public Function GetReporteCostoInventario(ByVal CodAlmacen As String, ByVal Marca As String, ByVal CodLinea As String, ByVal CodFamilia As String) As DataTable
        Dim gateWay As New ReporteInventarioDataGateway(m_strConnectionString)
        Return gateWay.GetReporteCostoInventarios(CodAlmacen, Marca, CodLinea, CodFamilia)
    End Function

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Me.dsArticulos = oDataGateway.GetInventarioReportesVarios(Me)

        Return dsArticulos

    End Function

    Public Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.Runtoreport

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Me.dsArticulos = oDataGateway.GetInventarioReportesVariosToReport(Me)

        Return dsArticulos

    End Function


#End Region


#Region "Articulos Mas Vendidos"

    Public Function MasVendidos(ByVal num As Integer, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime) As DataSet

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.MasVendidos(num, datFechaIni, datFechaFin)

    End Function

    Public Function CodigosMasVendidos(ByVal Num As Integer, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime, ByVal TopTen As Boolean) As DataTable

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.CodigosMasVendidos(Num, datFechaIni, datFechaFin, TopTen)

    End Function

    Public Function ArticuloFactCorrida(ByVal strCodArticulo As String) As DataSet

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.ArticuloFactCorrida(strCodArticulo)

    End Function


    Public Function ArticulosVendidos(ByVal strCodArticulo As String, ByVal strTalla As String, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime) As Decimal


        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.ArticulosVendidos(strCodArticulo, strTalla, datFechaIni, datFechaFin)

    End Function


    Public Function Corrida(ByVal CORR As String) As DataSet

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Me.dsArticulos = oDataGateway.Corrida(CORR)

        Return dsArticulos

    End Function

#End Region

End Class
