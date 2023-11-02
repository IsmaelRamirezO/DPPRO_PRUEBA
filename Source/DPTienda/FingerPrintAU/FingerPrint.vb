Public Class FingerPrint

    Dim oParent As FingerPrintManager

#Region "Fields"

    Dim m_lngUserID As Long
    Dim m_strTemplate As String
    Dim m_intFingerID As Integer
    Dim m_intSampleNum As Integer
    Dim m_strIDCliente As String
    Dim m_bolEsClienteSAP As String

#End Region

#Region "Propiedades"

    Public Property UserID() As Long
        Get
            Return m_lngUserID
        End Get
        Set(ByVal Value As Long)
            m_lngUserID = Value
        End Set
    End Property

    Public Property EsClienteSAP() As Boolean
        Get
            Return m_bolEsClienteSAP
        End Get
        Set(ByVal Value As Boolean)
            m_bolEsClienteSAP = Value
        End Set
    End Property

    Public Property IDCliente() As String
        Get
            Return m_strIDCliente
        End Get
        Set(ByVal Value As String)
            m_strIDCliente = Value
        End Set
    End Property

    Public Property FingerID() As Integer
        Get
            Return m_intFingerID
        End Get
        Set(ByVal Value As Integer)
            m_intFingerID = Value
        End Set
    End Property

    Public Property SampleNum() As Integer
        Get
            Return m_intSampleNum
        End Get
        Set(ByVal Value As Integer)
            m_intSampleNum = Value
        End Set
    End Property

    Public Property Template() As String
        Get
            Return m_strTemplate
        End Get
        Set(ByVal Value As String)
            m_strTemplate = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Friend Sub New(ByVal Parent As FingerPrintManager)

        MyBase.New()

        oParent = Parent

        ClearFields()

    End Sub

    Public Sub ClearFields()

        m_strTemplate = String.Empty
        m_strIDCliente = String.Empty
        m_intFingerID = 0
        m_intSampleNum = 0
        m_bolEsClienteSAP = True
        m_lngUserID = 0

    End Sub

#End Region

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

    Public Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

End Class
