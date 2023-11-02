
Option Explicit On 

Imports DportenisPro.DPTienda.Core

Public Class Vendedor

    Private oParent As CatalogoVendedoresManager


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
    Private m_strNombre As String

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


#End Region


#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoVendedoresManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Sub ClearFields()

        m_strID = String.Empty
        m_strNombre = String.Empty

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region


End Class
