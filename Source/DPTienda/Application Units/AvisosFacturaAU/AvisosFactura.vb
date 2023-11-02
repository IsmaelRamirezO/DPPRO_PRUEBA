
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class AvisosFactura

    Private oParent As AvisosFacturaManager


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



#Region "Fields"

    Private m_intID As Integer
    Private m_strModulo As String

    Private m_bStatus As Boolean
    Private m_datFecha As Date      'Fecha
    Private m_strUsuario As String  'Usuario
    Private m_strNota As String
    Private m_bDisponible As Boolean
    Private m_dsDetalle As DataSet


    Public Property ID() As String
        Get
            Return m_intID

        End Get

        Set(ByVal Valor As String)

            m_intID = Valor

        End Set

    End Property



    Public Property Modulo() As String
        Get
            Return m_strModulo

        End Get

        Set(ByVal Valor As String)

            m_strModulo = Valor

        End Set

    End Property



    Public Property Status() As Boolean
        Get
            Return m_bStatus

        End Get

        Set(ByVal Valor As Boolean)

            m_bStatus = Valor

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


    Public Property Usuario() As String
        Get
            Return m_strUsuario

        End Get

        Set(ByVal Valor As String)

            m_strUsuario = Valor

        End Set

    End Property


    Public Property Nota() As String

        Get
            Return m_strNota

        End Get

        Set(ByVal Valor As String)

            m_strNota = Valor

        End Set

    End Property


    Public Property Disponible() As String
        Get
            Return m_bDisponible

        End Get

        Set(ByVal Valor As String)

            m_bDisponible = Valor

        End Set

    End Property

    Public Property Detalle() As DataSet
        Get
            Return m_dsDetalle
        End Get
        Set(ByVal Value As DataSet)
            m_dsDetalle = Value
        End Set
    End Property


#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As AvisosFacturaManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_intID = 0
        m_strModulo = String.Empty
        m_strNota = String.Empty
        m_bDisponible = False
        m_bStatus = False
        m_datFecha = Date.Now

        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name

        SetFlagNew()
        ResetFlagDirty()

    End Sub



    Public Sub Save()

        oParent.Save(Me)

    End Sub



    Public Sub Delete()
        oParent.Delete(Me.ID)
    End Sub

#End Region


End Class
