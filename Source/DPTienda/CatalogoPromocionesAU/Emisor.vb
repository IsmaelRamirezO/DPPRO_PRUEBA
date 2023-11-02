Imports DportenisPro.DPTienda.Core

Public Class Emisor

    Private oParent As CatalogoPromocionesManager

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
    Private m_strDescripcion As String
    Private m_strAbrev As String

    Public Property ID() As Integer
        Get
            Return m_intID
        End Get

        Set(ByVal Valor As Integer)
            m_intID = Valor
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

    Public Property Abrevacion() As String
        Get
            Return m_strAbrev
        End Get
        Set(ByVal Value As String)
            m_strAbrev = Value
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoPromocionesManager)

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
        m_strDescripcion = String.Empty
        m_strAbrev = String.Empty

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
