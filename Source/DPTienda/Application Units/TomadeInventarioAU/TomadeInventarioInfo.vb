Imports DportenisPro.DPTienda.Core

Public Class TomadeInventarioInfo

    Private oParent As TomadeInventarioManager

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As TomadeInventarioManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

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

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Fields"

    Private m_intFolio As Integer
    Private m_strSucursal As String
    Private m_strAdministrativo As String
    Private m_strResponsable As String
    Private m_strSemana As String
    Private m_datFechaAuditoria As Date
    Private m_intTotalCodigos As Integer
    Private m_strUsuario As String

    Private m_TomaInventarioDetalle As New DataTable

#End Region

#Region "Properties"

    Public Property Folio() As Integer
        Get
            Return m_intFolio
        End Get
        Set(ByVal Value As Integer)
            m_intFolio = Value
        End Set
    End Property

    Public Property Sucursal() As String
        Get
            Return m_strSucursal
        End Get
        Set(ByVal Value As String)
            m_strSucursal = Value
        End Set
    End Property

    Public Property Administrativo() As String
        Get
            Return m_strAdministrativo
        End Get
        Set(ByVal Value As String)
            m_strAdministrativo = Value
        End Set
    End Property

    Public Property Responsable() As String
        Get
            Return m_strResponsable
        End Get
        Set(ByVal Value As String)
            m_strResponsable = Value
        End Set
    End Property

    Public Property Semana() As String
        Get
            Return m_strSemana
        End Get
        Set(ByVal Value As String)
            m_strSemana = Value
        End Set
    End Property

    Public Property FechaAuditoria() As Date
        Get
            Return m_datFechaAuditoria
        End Get
        Set(ByVal Value As Date)
            m_datFechaAuditoria = Value
        End Set
    End Property


    Public Property TotalCodigos() As Integer
        Get
            Return m_intTotalCodigos
        End Get
        Set(ByVal Value As Integer)
            m_intTotalCodigos = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set
    End Property

    Public Property Detalle() As DataTable
        Get
            Return m_TomaInventarioDetalle
        End Get
        Set(ByVal Value As DataTable)
            m_TomaInventarioDetalle = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intFolio = 0
        m_strSucursal = String.Empty
        m_strAdministrativo = String.Empty
        m_strResponsable = String.Empty
        m_strSemana = String.Empty
        m_datFechaAuditoria = Date.Now
        m_intTotalCodigos = 0

        m_TomaInventarioDetalle.Dispose()
        m_TomaInventarioDetalle = Nothing
        m_TomaInventarioDetalle = New DataTable("Detalle")

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
