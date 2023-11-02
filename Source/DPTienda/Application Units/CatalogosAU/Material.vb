Public Class Material

    Private m_intLibre As Integer

    Private m_strDesLinea As String

    Private m_strCodLinea As String

    Private m_strDescripcion As String

    Private m_strTalla As String

    Private m_strCodArticulo As String

    Public Property CodArticulo() As String
        Get
            Return m_strCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCodArticulo = Value
        End Set
    End Property

    Public Property Talla() As String
        Get
            Return m_strTalla
        End Get
        Set(ByVal Value As String)
            m_strTalla = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
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

    Public Property DesLinea() As String
        Get
            Return m_strDesLinea
        End Get
        Set(ByVal Value As String)
            m_strDesLinea = Value
        End Set
    End Property

    Public Property Libre() As Integer
        Get
            Return m_intLibre
        End Get
        Set(ByVal Value As Integer)
            m_intLibre = Value
        End Set
    End Property

End Class
