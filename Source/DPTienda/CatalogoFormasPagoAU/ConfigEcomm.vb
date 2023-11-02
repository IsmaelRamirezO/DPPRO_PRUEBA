
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class ConfigEcomm

    Private oParent As CatalogoFormasPagoManager




#Region "Fields"

    Private m_strID As String
    Private m_strPlataforma As String
    Private m_strTienda As String
    Private m_strNombre As String
    Private m_strCalleNum As String
    Private m_strColonia As String
    Private m_strCP As String
    Private m_strTelefono As String
    Private m_strCiudad As String
    Private m_strEstado As String
    Private m_Dias As Integer
    Private m_strEstatuP As String
    Private m_strEstatusC As String
    Private m_strCorreoE As String



    Public Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Valor As String)
            m_strID = Valor
        End Set
    End Property
    Public Property Plataforma() As String
        Get
            Return m_strPlataforma
        End Get
        Set(ByVal Valor As String)
            m_strPlataforma = Valor
        End Set
    End Property
    Public Property Tienda() As String
        Get
            Return m_strTienda
        End Get
        Set(ByVal Valor As String)
            m_strTienda = Valor
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Valor As String)
            m_strNombre = Valor
        End Set
    End Property
    Public Property CalleNum() As String
        Get
            Return m_strCalleNum
        End Get
        Set(ByVal Valor As String)
            m_strCalleNum = Valor
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Valor As String)
            m_strColonia = Valor
        End Set
    End Property
    Public Property CP() As String
        Get
            Return m_strCP
        End Get
        Set(ByVal Valor As String)
            m_strCP = Valor
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return m_strTelefono
        End Get
        Set(ByVal Valor As String)
            m_strTelefono = Valor
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Valor As String)
            m_strCiudad = Valor
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Valor As String)
            m_strEstado = Valor
        End Set
    End Property
    Public Property Dias() As Integer
        Get
            Return m_Dias
        End Get
        Set(ByVal Valor As Integer)
            m_Dias = Valor
        End Set
    End Property
    Public Property EstatusP() As String
        Get
            Return m_strEstatuP
        End Get
        Set(ByVal Valor As String)
            m_strEstatuP = Valor
        End Set
    End Property
    Public Property EstatusC() As String
        Get
            Return m_strEstatusC
        End Get
        Set(ByVal Valor As String)
            m_strEstatusC = Valor
        End Set
    End Property
    Public Property Correo() As String
        Get
            Return m_strCorreoE
        End Get
        Set(ByVal Valor As String)
            m_strCorreoE = Valor
        End Set
    End Property

#End Region



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoFormasPagoManager)

        oParent = Parent


    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region



#Region "Methods"
#End Region


End Class
