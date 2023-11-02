Public Class Ciudad

    Private oParent As CatalogoCiudadesManager

    Public Event CodCiudadChanged As EventHandler
    Public Event CodEstadoChanged As EventHandler
    Public Event CiudadChanged As EventHandler
    Public Event CodPlazaChanged As EventHandler

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
    Private m_strRango4 As String
    Private m_strRango3 As String
    Private m_strRango2 As String
    Private m_strRango1 As String
    Private m_strCodPlaza As String
    Private m_strCiudad As String
    Private m_intCodEstado As Integer
    Private m_intCodCiudad As Integer

    Public Property CodCiudad() As Integer
        Get
            Return m_intCodCiudad
        End Get
        Set(ByVal Value As Integer)
            m_intCodCiudad = Value
            SetStateDirty()
            RaiseEvent CodCiudadChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodEstado() As Integer
        Get
            Return m_intCodEstado
        End Get
        Set(ByVal Value As Integer)
            m_intCodEstado = Value
            SetStateDirty()
            RaiseEvent CodEstadoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Value As String)
            m_strCiudad = Value
            SetStateDirty()
            RaiseEvent CiudadChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodPlaza() As String
        Get
            Return m_strCodPlaza
        End Get
        Set(ByVal Value As String)
            m_strCodPlaza = Value
            SetStateDirty()
            RaiseEvent CodPlazaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Rango1() As String
        Get
            Return m_strRango1
        End Get
        Set(ByVal Value As String)
            m_strRango1 = Value
            SetStateDirty()
        End Set
    End Property

    Public Property Rango2() As String
        Get
            Return m_strRango2
        End Get
        Set(ByVal Value As String)
            m_strRango2 = Value
            SetStateDirty()
        End Set
    End Property

    Public Property Rango3() As String
        Get
            Return m_strRango3
        End Get
        Set(ByVal Value As String)
            m_strRango3 = Value
            SetStateDirty()
        End Set
    End Property

    Public Property Rango4() As String
        Get
            Return m_strRango4
        End Get
        Set(ByVal Value As String)
            m_strRango4 = Value
            SetStateDirty()
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

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoCiudadesManager)

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
        m_strRango4 = String.Empty
        m_strRango3 = String.Empty
        m_strRango2 = String.Empty
        m_strRango1 = String.Empty
        m_strCodPlaza = String.Empty
        m_strCiudad = String.Empty
        m_intCodEstado = 0
        m_intCodCiudad = 0

        SetStateNew()
        ResetStateDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        oParent.Delete(Me.CodCiudad)

    End Sub

#End Region

End Class
