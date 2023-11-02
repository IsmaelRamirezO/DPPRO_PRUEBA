Public Class UPC


    Private oParent As CatalogoUPCManager

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

#Region "Variables"

    Private m_strCodUPC As String
    Private m_strCodArticulo As String
    Private m_strNumero As String
    Private m_strDescripcion As String

#End Region

#Region "Events"
    Public Event CodUPCChanged As EventHandler
    Public Event CodArticuloChanged As EventHandler
    Public Event NumeroChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
#End Region

#Region "Fields"

    Public Property CodUPC() As String
        Get
            Return m_strCodUPC
        End Get
        Set(ByVal Value As String)
            m_strCodUPC = Value
            RaiseEvent CodUPCChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property CodArticulo() As String
        Get
            Return m_strCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCodArticulo = Value
            RaiseEvent CodArticuloChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return m_strNumero
        End Get
        Set(ByVal Value As String)
            m_strNumero = Value
            RaiseEvent NumeroChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
            RaiseEvent DescripcionChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoUPCManager)
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

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
