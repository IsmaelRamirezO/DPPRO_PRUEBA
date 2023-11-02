Public Class Marca

    

    Private oParent As CatalogoMarcasManager



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
    Private m_strCodMarca As String
    Private m_strDescripcion As String
    Private m_chrCodOrigen As Char
    Private m_bRecordEnabled As Boolean
    Private m_datRecordCreatedOn As Date
    Private m_strRecordCreatedBy As String
#End Region

#Region "Events"
    Public Event CodMarcaChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
    Public Event CodOrigenChanged As EventHandler
    Public Event RecordEnabledChanged As EventHandler
    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordCreatedByChanged As EventHandler
#End Region

#Region "Fields"

    Public Property CodMarca() As String
        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value

            RaiseEvent CodMarcaChanged(Me, New EventArgs)
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

    Public Property CodOrigen() As Char
        Get
            Return m_chrCodOrigen
        End Get
        Set(ByVal Value As Char)
            m_chrCodOrigen = Value

            RaiseEvent CodOrigenChanged(Me, New EventArgs)
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

    Friend Sub New(ByVal Parent As CatalogoMarcasManager)

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



        m_bRecordEnabled = False
        m_datRecordCreatedOn = Date.Now

        m_strRecordCreatedBy = String.Empty

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
