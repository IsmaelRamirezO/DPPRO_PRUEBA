
Public Class Almacen

    Private m_strOficinaVta As String = ""

    Private oParent As CatalogoAlmacenesManager

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

    Private m_strPlazaID As String

    Private m_strDireccionEstado As String
    Private m_strDireccionCiudad As String
    Private m_strDireccionCP As String
    Private m_strDireccionColonia As String
    Private m_strDireccionNumInt As String
    Private m_strDireccionNumExt As String
    Private m_strDireccionCalle As String

    Private m_strTelefonoLada As String
    Private m_strTelefonoNum As String

    Private m_bEsTienda As Boolean
    Private m_bMostrarEnSeparaciones As Boolean

    Private m_bRecordEnabled As Boolean
    Private m_datRecordCreatedOn As Date
    Private m_strRecordCreatedBy As String

    Public Event IDChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
    Public Event PlazaIDChanged As EventHandler
    Public Event DireccionEstadoChanged As EventHandler
    Public Event DireccionCiudadChanged As EventHandler
    Public Event DireccionCPChanged As EventHandler
    Public Event DireccionColoniaChanged As EventHandler
    Public Event DireccionNumIntChanged As EventHandler
    Public Event DireccionNumExtChanged As EventHandler
    Public Event DireccionCalleChanged As EventHandler
    Public Event TelefonoLadaChanged As EventHandler
    Public Event TelefonoNumChanged As EventHandler
    Public Event EsTiendaChanged As EventHandler
    Public Event MostrarEnSeparacionesChanged As EventHandler
    Public Event RecordEnabledChanged As EventHandler
    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordCreatedByChanged As EventHandler

    Public Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Value As String)

            m_strID = Value
            RaiseEvent IDChanged(Me, New EventArgs)
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

    Public Property PlazaID() As String
        Get
            Return m_strPlazaID
        End Get
        Set(ByVal Value As String)
            m_strPlazaID = Value
            RaiseEvent PlazaIDChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property EsTienda() As Boolean
        Get
            Return m_bEsTienda
        End Get
        Set(ByVal Value As Boolean)
            m_bEsTienda = Value

            RaiseEvent EsTiendaChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionCalle() As String
        Get
            Return m_strDireccionCalle
        End Get
        Set(ByVal Value As String)
            m_strDireccionCalle = Value

            RaiseEvent DireccionCalleChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionNumExt() As String
        Get
            Return m_strDireccionNumExt
        End Get
        Set(ByVal Value As String)
            m_strDireccionNumExt = Value

            RaiseEvent DireccionNumExtChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionNumInt() As String
        Get
            Return m_strDireccionNumInt
        End Get
        Set(ByVal Value As String)
            m_strDireccionNumInt = Value

            RaiseEvent DireccionNumIntChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionColonia() As String
        Get
            Return m_strDireccionColonia
        End Get
        Set(ByVal Value As String)
            m_strDireccionColonia = Value

            RaiseEvent DireccionColoniaChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionCP() As String
        Get
            Return m_strDireccionCP
        End Get
        Set(ByVal Value As String)
            m_strDireccionCP = Value

            RaiseEvent DireccionCPChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionCiudad() As String
        Get
            Return m_strDireccionCiudad
        End Get
        Set(ByVal Value As String)
            m_strDireccionCiudad = Value

            RaiseEvent DireccionCiudadChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property DireccionEstado() As String
        Get
            Return m_strDireccionEstado
        End Get
        Set(ByVal Value As String)
            m_strDireccionEstado = Value

            RaiseEvent DireccionEstadoChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property TelefonoLada() As String
        Get
            Return m_strTelefonoLada
        End Get
        Set(ByVal Value As String)
            m_strTelefonoLada = Value

            RaiseEvent TelefonoLadaChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property TelefonoNum() As String
        Get
            Return m_strTelefonoNum
        End Get
        Set(ByVal Value As String)
            m_strTelefonoNum = Value

            RaiseEvent TelefonoNumChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property MostrarEnSeparaciones() As Boolean
        Get
            Return m_bMostrarEnSeparaciones
        End Get
        Set(ByVal Value As Boolean)
            m_bMostrarEnSeparaciones = Value

            RaiseEvent MostrarEnSeparacionesChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            m_strRecordCreatedBy = Value

            RaiseEvent RecordCreatedByChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return m_datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            m_datRecordCreatedOn = Value

            RaiseEvent RecordCreatedOnChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordEnabled() As Boolean
        Get
            Return m_bRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_bRecordEnabled = Value

            RaiseEvent RecordEnabledChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoAlmacenesManager)

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

        m_strPlazaID = String.Empty

        m_strDireccionEstado = String.Empty
        m_strDireccionCiudad = String.Empty
        m_strDireccionCP = String.Empty
        m_strDireccionColonia = String.Empty
        m_strDireccionNumInt = String.Empty
        m_strDireccionNumExt = String.Empty
        m_strDireccionCalle = String.Empty

        m_strTelefonoLada = String.Empty
        m_strTelefonoNum = String.Empty

        m_bEsTienda = False
        m_bMostrarEnSeparaciones = False
        m_strOficinaVta = ""

        m_bRecordEnabled = False
        m_datRecordCreatedOn = Date.Now

        m_strRecordCreatedBy = String.Empty

        SetFlagNew()
        ResetFlagDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete()

    End Sub

#End Region

    Public Property OficinaVta() As String
        Get
            Return m_strOficinaVta
        End Get
        Set(ByVal Value As String)
            m_strOficinaVta = Value
        End Set
    End Property

End Class
