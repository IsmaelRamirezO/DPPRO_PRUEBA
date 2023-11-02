
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class TipoVenta

    Private m_strListaPrecios As String

    Private m_strCodSAP As String


    Private oParent As CatalogoTipoVentaManager



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



#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoTipoVentaManager)

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
        m_strCodSAP = String.Empty
        m_strListaPrecios = String.Empty

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


    Public Property CodSAP() As String
        Get
            Return m_strCodSAP
        End Get
        Set(ByVal Value As String)
            m_strCodSAP = Value
        End Set
    End Property

    Public Property ListaPrecios() As String
        Get
            Return m_strListaPrecios
        End Get
        Set(ByVal Value As String)
            m_strListaPrecios = Value
        End Set
    End Property

End Class
