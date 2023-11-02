Public Class Familias

    Private oParent As CatalogoFamiliasManager

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


    '#End Region

#Region "Fields"

    Private m_strID As String
    Private m_strDescripcion As String
    Private m_strRecordCreatedBy As String
    Private m_datRecordCreatedOn As Date
    Private m_bRecordEnabled As Boolean


    Public Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Value As String)

            m_strID = Value

            SetFlagDirty()
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            m_strRecordCreatedBy = Value
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return m_datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            m_datRecordCreatedOn = Value
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordEnabled() As Boolean
        Get
            Return m_bRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_bRecordEnabled = Value
            SetFlagDirty()
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoFamiliasManager)

        oParent = Parent

        ClearFields()

    End Sub

#End Region


#Region "Methods"

    Private Sub ClearFields()

        m_strID = String.Empty
        m_strDescripcion = String.Empty
        m_datRecordCreatedOn = Date.Now
        m_strRecordCreatedBy = String.Empty
        m_bRecordEnabled = False

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region
End Class
