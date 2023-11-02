
Imports DportenisPro.DPTienda.Core


Public Class DistribucionNC

    Private oParent As DistribucionNCManager



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

    Friend Sub New(ByVal Parent As DistribucionNCManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region



#Region "Fields"

    Private m_intID As Integer
    Private m_strCodAlmacen As String
    Private m_strCodCaja As String
    Private m_intReferencia As Integer
    Private m_decTotalAnticipoCliente As Decimal
    Private m_decTotalTarjetaCredito As Decimal
    Private m_decSaldoAnticipoCliente As Decimal
    Private m_decTotalDPVale As Decimal
    Private m_decTotalCDT As Decimal
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bolStatusRegistro As Boolean

    Private m_intClienteID As String
    Private m_strNombre As String
    Private m_strGeneradoPor As String
    Private m_decTotalAbonos As Decimal
    Private m_decPenalizacion As Decimal
    Private m_strDevEfectivo As String
    Private m_strMotivoCancelacion As String

    Private m_dsDetalle As DataSet

    Private m_decTotalFonacotFacilito As Decimal

    Private m_decTotalMontoCanje As Decimal


    Public Property ID() As Integer
        Get
            Return m_intID
        End Get
        Set(ByVal Value As Integer)
            m_intID = Value
        End Set
    End Property


    Public Property AlmacenID() As String

        Get
            Return m_strCodAlmacen
        End Get

        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set

    End Property


    Public Property CajaID() As String

        Get
            Return m_strCodCaja
        End Get

        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set

    End Property


    Public Property Referencia() As Integer

        Get
            Return m_intreferencia
        End Get

        Set(ByVal Value As Integer)
            m_intReferencia = Value
        End Set

    End Property


    Public Property ClienteID() As String

        Get
            Return m_intClienteID
        End Get

        Set(ByVal Value As String)
            m_intClienteID = Value
        End Set

    End Property


    Public Property Nombre() As String

        Get
            Return m_strNombre
        End Get

        Set(ByVal Value As String)
            m_strNombre = Value
        End Set

    End Property


    Public Property GeneradoPor() As String

        Get
            Return m_strGeneradoPor
        End Get

        Set(ByVal Value As String)
            m_strGeneradoPor = Value
        End Set

    End Property


    Public Property TotalAnticipoCliente() As Decimal

        Get
            Return m_decTotalAnticipoCliente
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalAnticipoCliente = Value
        End Set

    End Property


    Public Property TotalTarjetaCredito() As Decimal

        Get
            Return m_decTotalTarjetaCredito
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalTarjetaCredito = Value
        End Set

    End Property


    Public Property SaldoAnticipoCliente() As Decimal

        Get
            Return m_decSaldoAnticipoCliente
        End Get

        Set(ByVal Value As Decimal)
            m_decSaldoAnticipoCliente = Value
        End Set

    End Property


    Public Property TotalDPVale() As Decimal

        Get
            Return m_decTotalDPVale
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalDPVale = Value
        End Set

    End Property


    Public Property TotalCDT() As Decimal

        Get
            Return m_decTotalCDT
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalCDT = Value
        End Set

    End Property


    Public Property TotalAbonos() As Decimal

        Get
            Return m_decTotalAbonos
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalAbonos = Value
        End Set

    End Property



    Public Property Penalizacion() As Decimal

        Get
            Return m_decPenalizacion
        End Get

        Set(ByVal Value As Decimal)
            m_decPenalizacion = Value
        End Set

    End Property



    Public Property DevEfectivo() As String

        Get
            Return m_strDevEfectivo
        End Get

        Set(ByVal Value As String)
            m_strDevEfectivo = Value
        End Set

    End Property


    Public Property MotivoCancelacion() As String

        Get
            Return m_strMotivoCancelacion
        End Get

        Set(ByVal Value As String)
            m_strMotivoCancelacion = Value
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
            Return m_bolStatusRegistro
        End Get

        Set(ByVal Value As Boolean)
            m_bolStatusRegistro = Value
        End Set

    End Property


    Public Property Detalle() As DataSet

        Get
            Return m_dsDetalle
        End Get

        Set(ByVal Value As DataSet)
            m_dsDetalle = Value
        End Set

    End Property

    Public Property TotalFonacotFacilito() As Decimal

        Get
            Return m_decTotalFonacotFacilito
        End Get

        Set(ByVal Value As Decimal)
            m_decTotalFonacotFacilito = Value
        End Set

    End Property

    Public Property TotalCanje As Decimal
        Get
            Return m_decTotalMontoCanje
        End Get
        Set(value As Decimal)
            m_decTotalMontoCanje = value
        End Set
    End Property


#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_intID = 0
        m_strCodAlmacen = String.Empty
        m_strCodCaja = String.Empty
        m_intReferencia = 0
        m_decTotalAnticipoCliente = 0.0
        m_decTotalTarjetaCredito = 0.0
        m_decSaldoAnticipoCliente = 0.0
        m_strUsuario = String.Empty
        m_datFecha = Date.Now
        m_bolStatusRegistro = True

        m_intClienteID = 0
        m_strNombre = String.Empty
        m_strGeneradoPor = String.Empty
        m_decTotalAbonos = 0.0
        m_decPenalizacion = 0.0
        m_strDevEfectivo = String.Empty
        m_strMotivoCancelacion = String.Empty

        m_decTotalFonacotFacilito = 0.0

        m_dsDetalle = Nothing


        SetFlagNew()
        ResetFlagDirty()

    End Sub



    Public Sub Save()

        'oParent.Save(Me)

    End Sub



    Public Sub Delete()

        'oParent.Delete(Me.ID)

    End Sub

#End Region

End Class
