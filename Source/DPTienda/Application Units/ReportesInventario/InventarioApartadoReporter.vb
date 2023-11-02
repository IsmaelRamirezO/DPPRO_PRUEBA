Public Class InventarioApartadoReporter
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

    Private m_strAlmacen As String

    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

#End Region


#Region "Generador del Reporte"

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        'TODO: CLM - Ejecutar consulta del DataGateway

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.GetInventarioApartado(m_strAlmacen)

    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

#End Region


End Class
