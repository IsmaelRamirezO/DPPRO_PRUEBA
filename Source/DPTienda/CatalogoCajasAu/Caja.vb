
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class Caja

    Private oParent As CatalogoCajaManager



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
    Private m_strDescripcion As String
    Private m_strIP As String

    Private m_bStatus As Boolean
    Private m_datFecha As Date      'Fecha
    Private m_strUsuario As String  'Usuario
    Private m_strFolioFactura As Integer
    Private m_strFolioApartado As Integer
    Private m_strFolioNotaCredito As Integer
    Private m_strFolioAbono As Integer






    Public Property ID() As String
        Get
            Return m_strID

        End Get

        Set(ByVal Valor As String)

            m_strID = Valor

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

    Public Property IP() As String
        Get
            Return m_strIP

        End Get

        Set(ByVal Valor As String)

            m_strIP = Valor

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


    Public Property FolioFactura() As Integer
        Get
            Return m_strFolioFactura

        End Get

        Set(ByVal Valor As Integer)

            m_strFolioFactura = Valor

        End Set

    End Property


    Public Property FolioApartado() As Integer
        Get
            Return m_strFolioApartado

        End Get

        Set(ByVal Valor As Integer)

            m_strFolioApartado = Valor

        End Set

    End Property


    Public Property FolioNotaCredito() As Integer
        Get
            Return m_strFolioNotaCredito

        End Get

        Set(ByVal Valor As Integer)

            m_strFolioNotaCredito = Valor

        End Set

    End Property


    Public Property FolioAbono() As Integer
        Get
            Return m_strFolioAbono

        End Get

        Set(ByVal Valor As Integer)

            m_strFolioAbono = Valor

        End Set

    End Property


#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoCajaManager)

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

        m_strID = String.Empty
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
        oParent.Delete(Me.ID)
    End Sub

#End Region


End Class
