Public Class InventarioLineaFamilia

    Implements IInventarioReporter

    Private m_strCodFamilia As String

    Private m_strCodLinea As String

    Private m_intMes As Integer

    Private m_strConnectionString As String

    Public Property ConnectionString() As String Implements IInventarioReporter.ConnectionString
        Get

        End Get
        Set(ByVal Value As String)

            m_strConnectionString = Value

        End Set
    End Property

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.GetInventarioLineaFamilia(CStr(m_intMes), m_strCodLinea, m_strCodFamilia)

    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

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

End Class
