Public Class Contacto


#Region "Object Status Flags"

    Private bolFlagIsDirty As Boolean
    Private bolFlagIsNew As Boolean

    Public Overridable Function IsDirty() As Boolean
        Return bolFlagIsDirty
    End Function

    Public Overridable Function IsNew() As Boolean
        Return bolFlagIsNew
    End Function

    Public Overridable Sub SetFlagIsDirty()
        bolFlagIsDirty = True
    End Sub

    Public Overridable Sub ResetFlagIsDirty()
        bolFlagIsDirty = False
    End Sub

    Public Overridable Sub SetFlagIsNew()
        bolFlagIsNew = True
    End Sub

    Public Overridable Sub ResetFlagIsNew()
        bolFlagIsNew = False
    End Sub

#End Region


#Region "Fields"

    Private m_strNombre As String
    Private m_strApellidoPaterno As String
    Private m_strApellidoMaterno As String
    Private m_strDomicilio As String
    Private m_strColonia As String
    Private m_strCiudad As String
    Private m_strEstado As String
    Private m_strCodigoPostal As String
    Private m_strTelefono As String
    Private m_strSexo As String

    Public Event NombreChanged As EventHandler
    Public Event ApellidoPaternoChanged As EventHandler
    Public Event ApellidoMaternoChanged As EventHandler
    Public Event DomicilioChanged As EventHandler
    Public Event ColoniaChanged As EventHandler
    Public Event CiudadChanged As EventHandler
    Public Event EstadoChanged As EventHandler
    Public Event CodigoPostalChanged As EventHandler
    Public Event TelefonoChanged As EventHandler
    Public Event SexoChanged As EventHandler

    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Value As String)
            m_strNombre = Value

            SetFlagIsDirty()
            RaiseEvent NombreChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property ApellidoPaterno() As String
        Get
            Return m_strApellidoPaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoPaterno = Value

            SetFlagIsDirty()
            RaiseEvent ApellidoPaternoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property ApellidoMaterno() As String
        Get
            Return m_strApellidoMaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoMaterno = Value

            SetFlagIsDirty()
            RaiseEvent ApellidoMaternoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Domicilio() As String
        Get
            Return m_strDomicilio
        End Get
        Set(ByVal Value As String)
            m_strDomicilio = Value

            SetFlagIsDirty()
            RaiseEvent DomicilioChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value

            SetFlagIsDirty()
            RaiseEvent ColoniaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Value As String)
            m_strCiudad = Value

            SetFlagIsDirty()
            RaiseEvent CiudadChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Value As String)
            m_strEstado = Value

            SetFlagIsDirty()
            RaiseEvent EstadoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodigoPostal() As String
        Get
            Return m_strCodigoPostal
        End Get
        Set(ByVal Value As String)
            m_strCodigoPostal = Value

            SetFlagIsDirty()
            RaiseEvent CodigoPostalChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_strTelefono
        End Get
        Set(ByVal Value As String)
            m_strTelefono = Value

            SetFlagIsDirty()
            RaiseEvent TelefonoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Sexo() As String
        Get
            Return m_strSexo
        End Get
        Set(ByVal Value As String)
            m_strSexo = Value

            SetFlagIsDirty()
            RaiseEvent SexoChanged(Me, New EventArgs)
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Public Sub New()

        Me.Clear()

    End Sub

#End Region


#Region "Methods"

    Public Sub Clear()

        Me.Nombre = String.Empty
        Me.ApellidoPaterno = String.Empty
        Me.ApellidoMaterno = String.Empty
        Me.Domicilio = String.Empty
        Me.Colonia = String.Empty
        Me.Ciudad = String.Empty
        Me.Estado = String.Empty
        Me.CodigoPostal = String.Empty
        Me.Telefono = String.Empty
        Me.Sexo = String.Empty

        ResetFlagIsDirty()
        ResetFlagIsNew()

    End Sub

#End Region


End Class
