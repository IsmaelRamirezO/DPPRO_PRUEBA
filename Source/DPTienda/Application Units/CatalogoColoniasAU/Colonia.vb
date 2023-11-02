Public Class Colonia

    Private oParent As CatalogoColoniasManager

    Public Event IDChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
    Public Event CiudadChanged As EventHandler

#Region "Object Status Flags"

    Dim bolDirty As Boolean
    Dim bolNew As Boolean

    Public Function IsDirty() As Boolean
        Return bolDirty
    End Function

    Friend Sub SetStateDirty()
        bolDirty = True
    End Sub

    Friend Sub ResetStateDirty()
        bolDirty = False
    End Sub

    Public Function IsNew() As Boolean
        Return bolNew
    End Function

    Friend Sub SetStateNew()
        bolNew = True
    End Sub

    Friend Sub ResetStateNew()
        bolNew = False
    End Sub

#End Region

#Region "Fields"

    Private m_bStatusRegistro As Boolean
    Private m_datFecha As Date
    Private m_strUsuario As String
    Private m_intCodCiudad As Integer
    Private m_strColonia As String
    Private m_intCodColonia As Integer

    Public Property CodColonia() As Integer
        Get
            Return m_intCodColonia
        End Get
        Set(ByVal Value As Integer)
            m_intCodColonia = Value
            SetStateDirty()
            RaiseEvent IDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value
            SetStateDirty()
            RaiseEvent DescripcionChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodCiudad() As Integer
        Get
            Return m_intCodCiudad
        End Get
        Set(ByVal Value As Integer)
            m_intCodCiudad = Value
            SetStateDirty()
            RaiseEvent CiudadChanged(Me, New EventArgs)
        End Set
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
    End Property

    Friend Sub SetUsuario(ByVal Value As String)
        m_strUsuario = Value
        SetStateDirty()
    End Sub

    Public ReadOnly Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
    End Property

    Friend Sub SetFecha(ByVal Value As Date)
        m_datFecha = Value
        SetStateDirty()
    End Sub

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
            SetStateDirty()
        End Set
    End Property

#End Region

#Region "Constructors"

    Friend Sub New(ByVal Parent As CatalogoColoniasManager)

        oParent = Parent

        Me.Clear()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oParent = Nothing
    End Sub

#End Region

#Region "Methods"

    Friend Sub Clear()

        m_bStatusRegistro = False
        m_datFecha = Date.Now
        m_strUsuario = String.Empty
        m_intCodCiudad = 0
        m_strColonia = String.Empty
        m_intCodColonia = 0

        SetStateNew()
        ResetStateDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        oParent.Delete(Me.CodColonia)

    End Sub

#End Region

End Class
