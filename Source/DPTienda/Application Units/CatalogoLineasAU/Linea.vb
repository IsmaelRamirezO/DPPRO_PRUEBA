Public Class Linea

    Private oParent As CatalogoLineasManager

    Public Event IDChanged As EventHandler
    Public Event DescripcionChanged As EventHandler

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
    Private m_strID As String

    Public Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Value As String)

            'If (Value = String.Empty) Then
            '    Throw New ArgumentException("El Codigo de Linea no puede ser cadena vacia.")
            'End If

            'If (Value.Length > 2) Then
            '    Throw New ArgumentException("El Codigo de Linea no puede exceder los 2 caracteres de longitud.")
            'End If

            m_strID = Value
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

    Friend Sub New(ByVal Parent As CatalogoLineasManager)

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
        m_strRecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.SessionLoginName
        m_strDescripcion = String.Empty
        m_strID = String.Empty

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