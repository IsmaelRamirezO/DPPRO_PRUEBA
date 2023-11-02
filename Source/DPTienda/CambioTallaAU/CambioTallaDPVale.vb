Public Class CambioTallaDPVale


#Region "Variables"

    Private m_CambiosTallaDPValeId As Integer
    Private m_RefOrigen As String
    Private m_RefPadre As String
    Private m_RefGenerada As String
    Private m_ValeId As String
    Private m_Consecutivo As Integer
    Private m_Fecha As DateTime
    Private CambioTallaMgr As CambioTallaManager

#End Region

#Region "Propiedades"

    Public Property CambiosTallasDPValeId As Integer
        Get
            Return m_CambiosTallaDPValeId
        End Get
        Set(ByVal value As Integer)
            m_CambiosTallaDPValeId = value
        End Set
    End Property

    Public Property RefOrigen As String
        Get
            Return m_RefOrigen
        End Get
        Set(ByVal value As String)
            m_RefOrigen = value
        End Set
    End Property

    Public Property RefPadre As String
        Get
            Return m_RefPadre
        End Get
        Set(ByVal value As String)
            m_RefPadre = value
        End Set
    End Property

    Public Property RefGenerada As String
        Get
            Return m_RefGenerada
        End Get
        Set(ByVal value As String)
            m_RefGenerada = value
        End Set
    End Property

    Public Property ValeId As String
        Get
            Return m_ValeId
        End Get
        Set(ByVal value As String)
            m_ValeId = value
        End Set
    End Property

    Public Property Consecutivo As Integer
        Get
            Return m_Consecutivo
        End Get
        Set(ByVal value As Integer)
            m_Consecutivo = value
        End Set
    End Property

    Public Property Fecha As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal value As DateTime)
            m_Fecha = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal CambioTallaMgr As CambioTallaManager)
        Me.m_CambiosTallaDPValeId = 0
        Me.m_RefOrigen = ""
        Me.m_RefPadre = ""
        Me.m_RefGenerada = ""
        Me.m_ValeId = ""
        Me.m_Consecutivo = 0
        Me.m_Fecha = DateTime.Now
        Me.CambioTallaMgr = CambioTallaMgr
    End Sub

    Public Sub New(ByVal CambioTallaMgr As CambioTallaManager, ByVal CambiosTallaDPValeId As Integer)
        Me.CambiosTallasDPValeId = CambiosTallaDPValeId
        Me.m_RefOrigen = ""
        Me.m_RefPadre = ""
        Me.m_RefGenerada = ""
        Me.m_ValeId = ""
        Me.m_Consecutivo = 0
        Me.m_Fecha = DateTime.Now
        Me.CambioTallaMgr = CambioTallaMgr
        Me.CambioTallaMgr.LoadCambioTallaDPVale(Me)
    End Sub

#End Region

#Region "Metodos y funciones"

    Public Function Save() As Boolean
        Return Me.CambioTallaMgr.SaveCambiosTallaDPVale(Me)
    End Function

#End Region

End Class
