Public Class Estado

    Private oParent As CatalogoEstadosManager

    Public Event IDChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
    Public Event AbreviaChanged As EventHandler

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
    Private m_strAbrevia As String
    Private m_strDescripcion As String
    Private m_intCodEstado As Integer

    Public Property CodEstado() As Integer
        Get
            Return m_intCodEstado
        End Get
        Set(ByVal Value As Integer)
            m_intCodEstado = Value
            SetStateDirty()
            RaiseEvent IDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
            SetStateDirty()
            RaiseEvent DescripcionChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Abrevia() As String
        Get
            Return m_strAbrevia
        End Get
        Set(ByVal Value As String)
            m_strAbrevia = Value
            SetStateDirty()
            RaiseEvent AbreviaChanged(Me, New EventArgs)
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

    Friend Sub New(ByVal Parent As CatalogoEstadosManager)

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
        m_strAbrevia = String.Empty
        m_strDescripcion = String.Empty
        m_intCodEstado = 0

        SetStateNew()
        ResetStateDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        oParent.Delete(Me.CodEstado)

    End Sub

#End Region

End Class
