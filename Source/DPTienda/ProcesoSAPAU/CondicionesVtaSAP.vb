Public Class CondicionesVtaSAP

#Region "Variables"
    Private m_strCondicion As String
    Private m_strOrgVtas As String
    Private m_strCanalDist As String
    Private m_strJerarquia As String
    Private m_strCondMat As String
    Private m_strCondPrec As String
    Private m_strMaterial As String
    Private m_strOficinaVtas As String
    Private m_strListPrec As String
    Private m_dtFechaIni As Date
    Private m_dtFechaFin As Date
    Private m_siDescPorcentaje As Decimal
    Private m_moDescmonto As Decimal
#End Region

#Region "Fields Accessors"
    Public Property Condicion() As String
        Get
            Return m_strCondicion
        End Get
        Set(ByVal Value As String)
            m_strCondicion = Value
        End Set
    End Property

    Public Property OrgVtas() As String
        Get
            Return m_strOrgVtas
        End Get
        Set(ByVal Value As String)
            m_strOrgVtas = Value
        End Set
    End Property

    Public Property CanalDist() As String
        Get
            Return m_strCanalDist
        End Get
        Set(ByVal Value As String)
            m_strCanalDist = Value
        End Set
    End Property

    Public Property Jerarquia() As String
        Get
            Return m_strJerarquia
        End Get
        Set(ByVal Value As String)
            m_strJerarquia = Value
        End Set
    End Property

    Public Property CondMat() As String
        Get
            Return m_strCondMat
        End Get
        Set(ByVal Value As String)
            m_strCondMat = Value
        End Set
    End Property

    Public Property CondPrec() As String
        Get
            Return m_strCondPrec
        End Get
        Set(ByVal Value As String)
            m_strCondPrec = Value
        End Set
    End Property


    Public Property Material() As String
        Get
            Return m_strMaterial
        End Get
        Set(ByVal Value As String)
            m_strMaterial = Value
        End Set
    End Property

    Public Property OficinaVtas() As String
        Get
            Return m_strOficinaVtas
        End Get
        Set(ByVal Value As String)
            m_strOficinaVtas = Value
        End Set
    End Property


    Public Property ListPrec() As String
        Get
            Return m_strListPrec
        End Get
        Set(ByVal Value As String)
            m_strListPrec = Value
        End Set
    End Property


    Public Property FechaIni() As Date
        Get
            Return m_dtFechaIni
        End Get
        Set(ByVal Value As Date)
            m_dtFechaIni = Value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return m_dtFechaFin
        End Get
        Set(ByVal Value As Date)
            m_dtFechaFin = Value
        End Set
    End Property


    Public Property DescPorcentaje() As Decimal
        Get
            Return m_siDescPorcentaje
        End Get
        Set(ByVal Value As Decimal)
            m_siDescPorcentaje = Value
        End Set
    End Property

    Public Property Descmonto() As Decimal
        Get
            Return m_moDescmonto
        End Get
        Set(ByVal Value As Decimal)
            m_moDescmonto = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub Clear()

        m_strCondicion = String.Empty
        m_strOrgVtas = String.Empty
        m_strCanalDist = String.Empty
        m_strJerarquia = String.Empty
        m_strCondMat = String.Empty
        m_strCondPrec = String.Empty
        m_strMaterial = String.Empty
        m_strOficinaVtas = String.Empty
        m_strListPrec = String.Empty
        m_dtFechaIni = Date.Now
        m_dtFechaFin = Date.Now
        m_siDescPorcentaje = 0
        m_moDescmonto = 0

    End Sub

#End Region

End Class
