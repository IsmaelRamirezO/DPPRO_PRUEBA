Imports DportenisPro.DPTienda.Core

Public Class VentasDetalleReporter


    Implements IVentasReporter


    Private m_strConnectionString As String
    Private oApplicationContext As ApplicationContext

    Public Property ConnectionString() As String Implements IVentasReporter.ConnectionString
        Get
            Return m_strConnectionString
        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#Region "Parametros del Reporte"
    Private m_strAlmacen As String
    Private m_strFechaIni As Date
    Private m_strFechaFin As Date
    Private m_strCodCaja As String


    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

    Public Property FechaIni() As Date
        Get
            Return m_strFechaIni
        End Get
        Set(ByVal Value As Date)
            m_strFechaIni = Value
        End Set
    End Property



    Public Property FechaFin() As Date
        Get
            Return m_strFechaFin
        End Get
        Set(ByVal Value As Date)
            m_strFechaFin = Value
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set
    End Property


#End Region


#Region "Generador del Reporte"

    Public Function Run() As System.Data.DataSet Implements IVentasReporter.Run

        Dim oDataGateway As New ReporteVentasDataGateWay(m_strConnectionString, oApplicationContext)

        Return oDataGateway.GetReporteVentasDetalle(m_strFechaIni, m_strFechaFin, m_strCodCaja, m_strAlmacen)

    End Function

    Public Function RunNew() As System.Data.DataSet Implements IVentasReporter.RunNew

        Dim oDataGateway As New ReporteVentasDataGateWay(m_strConnectionString, oApplicationContext)

        Return oDataGateway.GetReporteVentasDetalle(m_strFechaIni, m_strFechaFin, m_strCodCaja, m_strAlmacen)

    End Function

#End Region

    Public Function RunNewPreview() As System.Data.DataSet Implements IVentasReporter.RunNewPreview

    End Function

    Public Function RunFolioSAP() As System.Data.DataSet Implements IVentasReporter.RunFolioSAP

    End Function
End Class
