
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class Transportista

    Private oParent As CatalogoTransportistaManager



#Region "Object Status Flags"

    Private bolIsDirty As Boolean
    Private bolIsNew As Boolean



    Public Function IsDirty() As Boolean
        Return bolIsDirty
    End Function

    Public Function IsNew() As Boolean
        Return bolIsNew
    End Function

    Friend Sub SetFlagDirty()
        bolIsDirty = True
    End Sub

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoTransportistaManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region



#Region "Fields"

    Private m_strID As String
    Private m_strNombre As String
    Private m_strTel As String
    Private m_strFax As String
    Private m_decPuntuacion As Decimal
    Private m_strRFC As String
    Private m_strDireccion As String
    Private m_strEstado As String
    Private m_strPais As String
    Private m_strCP As String
    Private m_bolPredeterminado As Boolean
    Private m_datFecha As Date
    Private m_bolStatus As Boolean
    Private m_strUsuario As String


    Public Property ID() As String
        Get
            Return m_strID
        End Get

        Set(ByVal Valor As String)
            m_strID = Valor
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


    Public Property Tel() As String
        Get
            Return m_strTel
        End Get

        Set(ByVal Valor As String)
            m_strTel = Valor
        End Set

    End Property


    Public Property Fax() As String
        Get
            Return m_strFax
        End Get

        Set(ByVal Valor As String)
            m_strFax = Valor
        End Set

    End Property


    Public Property Puntuacion() As Decimal
        Get
            Return m_decPuntuacion
        End Get

        Set(ByVal Valor As Decimal)
            m_decPuntuacion = Valor
        End Set

    End Property


    Public Property RFC() As String
        Get
            Return m_strRFC
        End Get

        Set(ByVal Valor As String)
            m_strRFC = Valor
        End Set

    End Property


    Public Property Direccion() As String
        Get
            Return m_strDireccion
        End Get

        Set(ByVal Valor As String)
            m_strDireccion = Valor
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


    Public Property Pais() As String
        Get
            Return m_strPais
        End Get

        Set(ByVal Valor As String)
            m_strPais = Valor
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


    Public Property Predeterminado() As Boolean
        Get
            Return m_bolPredeterminado
        End Get

        Set(ByVal Valor As Boolean)
            m_bolPredeterminado = Valor
        End Set

    End Property


    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get

        Set(ByVal Valor As Date)
            m_datFecha = Valor
        End Set

    End Property


    Public Property Status() As Boolean
        Get
            Return m_bolstatus
        End Get

        Set(ByVal Valor As Boolean)
            m_bolStatus = Valor
        End Set

    End Property


    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get

        Set(ByVal Valor As String)
            m_strUsuario = Valor
        End Set
    End Property


#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_strID = String.Empty
        m_strNombre = String.Empty
        m_strTel = String.Empty
        m_strFax = String.Empty
        m_decPuntuacion = 0
        m_strRFC = String.Empty
        m_strDireccion = String.Empty
        m_strEstado = String.Empty
        m_strPais = String.Empty
        m_strCP = String.Empty
        m_bolPredeterminado = False
        m_datFecha = Date.Today
        m_bolStatus = False
        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name

        SetFlagNew()
        ResetFlagDirty()

    End Sub



    Public Sub Save()

        'oParent.Save(Me)

    End Sub



    Public Sub Delete()

        'oParent.Delete(Me.ID)

    End Sub

#End Region



End Class
