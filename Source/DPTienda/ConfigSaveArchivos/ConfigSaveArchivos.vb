Public Class ConfigSaveArchivos

    Private m_usuario As String
    Private m_password As String
    Private m_ruta As String
    Private m_unidad As String
    Private m_CargaInicial As Boolean
    Private m_MiniPrinter As Boolean
    Private m_PrinterHP As Boolean


#Region "Methods"

    Public Sub New()

        Me.Create()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Private Sub Create()

        m_usuario = String.Empty
        m_password = String.Empty
        m_ruta = String.Empty
        m_unidad = String.Empty
        m_CargaInicial = True
        m_MiniPrinter = False
        m_PrinterHP = False


    End Sub

#End Region


#Region "Properties"



    Public Property PrinterHP() As Boolean
        Get
            Return m_PrinterHP
        End Get
        Set(ByVal Value As Boolean)
            m_PrinterHP = Value
        End Set
    End Property

    Public Property MiniPrinter() As Boolean
        Get
            Return m_MiniPrinter
        End Get
        Set(ByVal Value As Boolean)
            m_MiniPrinter = Value
        End Set
    End Property

    Public Property CargaInicial() As Boolean
        Get
            Return m_CargaInicial
        End Get
        Set(ByVal Value As Boolean)
            m_CargaInicial = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal Value As String)
            m_usuario = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return m_password
        End Get
        Set(ByVal Value As String)
            m_password = Value
        End Set
    End Property

    Public Property Ruta() As String
        Get
            Return m_ruta
        End Get
        Set(ByVal Value As String)
            m_ruta = Value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return m_unidad
        End Get
        Set(ByVal Value As String)
            m_unidad = Value
        End Set
    End Property

#End Region

End Class
