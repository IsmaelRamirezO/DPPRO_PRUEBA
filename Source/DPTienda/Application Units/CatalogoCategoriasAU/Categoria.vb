Public Class Categoria

    Private oParent As CatalogoCategoriasManager

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

    Private m_bolRecordEnabled As Boolean
    Private m_datRecordCreatedOn As Date
    Private m_strRecordCreatedBy As String
    Private m_strDescripcion As String
    Private m_intID As String = ""

    Public ReadOnly Property ID() As String
        Get
            Return m_intID
        End Get
    End Property

    Public Sub SetID(ByVal Value As String)
        m_intID = Value
    End Sub

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
            SetStateDirty()
        End Set
    End Property

    Public ReadOnly Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
    End Property

    Friend Sub SetRecordCreatedBy(ByVal Value As String)

        m_strRecordCreatedBy = Value
        SetStateDirty()
    End Sub

    Public ReadOnly Property RecordCreatedOn() As Date
        Get
            Return m_datRecordCreatedOn
        End Get
    End Property

    Friend Sub SetRecordCreatedOn(ByVal Value As Date)
        m_datRecordCreatedOn = Value
        SetStateDirty()
    End Sub

    Public Property RecordEnabled() As Boolean
        Get
            Return m_bolRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_bolRecordEnabled = Value
            SetStateDirty()
        End Set
    End Property

#End Region

#Region "Constructors"

    Friend Sub New(ByVal Parent As CatalogoCategoriasManager)
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

        m_bolRecordEnabled = False
        m_datRecordCreatedOn = Date.Now
        m_strRecordCreatedBy = "ASM"
        m_strDescripcion = String.Empty
        m_intID = 0

        SetStateNew()
        ResetStateDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete()

        oParent.Delete(Me.ID)

    End Sub

#End Region

End Class
