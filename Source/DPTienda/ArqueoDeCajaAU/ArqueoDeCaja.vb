Public Class ArqueoDeCaja



#Region "Variables"

    Private m_datIngresos As DataSet

    Private m_bStatusRegistro As Boolean

    Private m_datFecha As Date

    Private m_strObservaciones As String

    Private m_dec As Decimal

    Private m_decIngresosDiaAnterioro As Decimal

    Private m_decIngresosDia As Decimal

    Private m_strResponsable As String

    Private m_strAdministrativo As String

    Private m_strCaja As String

    Private m_strSucursal As String

    Private m_intFolio As Integer = 0

    Private oParent As ArqueoDeCajaManager

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

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As ArqueoDeCajaManager)

        oParent = Parent

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Propiedades"

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

    Public Property Caja() As String
        Get
            Return m_strCaja
        End Get
        Set(ByVal Value As String)
            m_strCaja = Value
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

    Public Property IngresosDia() As Decimal
        Get
            Return m_decIngresosDia
        End Get
        Set(ByVal Value As Decimal)
            m_decIngresosDia = Value
        End Set
    End Property

    Public Property IngresosDiaAnterioro() As Decimal
        Get
            Return m_decIngresosDiaAnterioro
        End Get
        Set(ByVal Value As Decimal)
            m_decIngresosDiaAnterioro = Value
        End Set
    End Property

    Public Property FondoCaja() As Decimal
        Get
            Return m_dec
        End Get
        Set(ByVal Value As Decimal)
            m_dec = Value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return m_strObservaciones
        End Get
        Set(ByVal Value As String)
            m_strObservaciones = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As Date)
            m_datFecha = Value
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
        End Set
    End Property

    Public Property Ingresos() As DataSet
        Get
            Return m_datIngresos
        End Get
        Set(ByVal Value As DataSet)
            m_datIngresos = Value
        End Set
    End Property
#End Region



End Class
