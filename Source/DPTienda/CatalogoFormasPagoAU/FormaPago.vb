
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class FormaPago

    Private oParent As CatalogoFormasPagoManager


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

    Private m_strID As String
    Private m_strVentaID As String
    Private m_strDescripcion As String
    Private m_dsExistencias As DataSet
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatus As Boolean



    Public Property ID() As String
        Get
            Return m_strID

        End Get

        Set(ByVal Valor As String)

            m_strID = Valor

        End Set

    End Property
    Public Property VentaID() As String
        Get
            Return m_strVentaID

        End Get

        Set(ByVal Valor As String)

            m_strVentaID = Valor

        End Set

    End Property



    Public Property Descripcion() As String
        Get
            Return m_strDescripcion

        End Get

        Set(ByVal Valor As String)

            m_strDescripcion = Valor

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
            Return m_bStatus

        End Get

        Set(ByVal Valor As Boolean)

            m_bStatus = Valor

        End Set

    End Property


#End Region



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoFormasPagoManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub


    Public Property Existencias() As DataSet
        Get
            Return m_dsExistencias
        End Get
        Set(ByVal Value As DataSet)
            m_dsExistencias = Value
        End Set
    End Property

#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_strID = String.Empty
        m_strVentaID = String.Empty
        m_strDescripcion = String.Empty
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
        oParent.Delete(Me.ID, me.VentaID)
    End Sub

#End Region


End Class
