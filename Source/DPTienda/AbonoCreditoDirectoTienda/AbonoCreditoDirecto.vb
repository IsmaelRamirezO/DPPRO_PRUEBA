Public Class AbonoCreditoDirecto


#Region "Constructors"

    Friend Sub New(ByVal Parent As AbonoCreditoDirectoManager)

        oParent = Parent

    End Sub
#End Region

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

#Region "Variables"

    Private m_strAsociadoID As String

    Private m_strClienteID As String

    Private m_strBanco As String

    Private m_bStatusRegistro As Boolean

    Private m_datFecha As Date

    Private m_strUsuario As String

    Private m_bytFirmaDigital As Byte

    Private m_strCuentaContable As String

    Private m_dblSaldoVencido As Double

    Private m_dblSaldo As Double

    Private m_dblLimiteCredito As Double

    Private m_datFechaExpiracion As Date

    Private m_chrACP As Char

    Private m_strAEMail As String

    Private m_strATelefono As String

    Private m_strAColonia As String

    Private m_strACiudad As String

    Private m_strAEstado As String

    Private m_strADomicilio As String

    Private m_chrASexo As Char

    Private m_strAApellidoMaterno As String

    Private m_strAApellidoPaterno As String

    Private m_strANombre As String

    Private m_intPlazo As Integer = 30

    Private m_dblLimCredBanco As Double = 0

    Private m_dsFacturas As New DataSet

    Private m_dsFormasDePago As DataSet

    Private m_dtNewFacturas As New DataTable("Facturas")

    Private m_strDocnumFB01 As String

    Private m_strDocnumFB05 As String


    Private m_intCreditoDirectoID As Integer

    Private oParent As AbonoCreditoDirectoManager
#End Region

#Region "Propiedades"

    Public Property CreditoDirectoID() As Integer
        Get
            Return m_intCreditoDirectoID
        End Get
        Set(ByVal Value As Integer)
            m_intCreditoDirectoID = Value
        End Set
    End Property


    Public Property AsociadoID() As String
        Get
            Return m_strAsociadoID
        End Get
        Set(ByVal Value As String)
            m_strAsociadoID = Value
        End Set
    End Property


    Public Property ClienteID() As String
        Get
            Return m_strClienteID
        End Get
        Set(ByVal Value As String)
            m_strClienteID = Value
        End Set
    End Property

    Public Property Banco() As String
        Get
            Return m_strBanco
        End Get
        Set(ByVal Value As String)
            m_strBanco = Value
        End Set
    End Property

    Public Property LimCredBanco() As Double
        Get
            Return m_dblLimCredBanco
        End Get
        Set(ByVal Value As Double)
            m_dblLimCredBanco = Value
        End Set
    End Property

    Public Property Plazo() As Integer
        Get
            Return m_intPlazo
        End Get
        Set(ByVal Value As Integer)
            m_intPlazo = Value
        End Set
    End Property

    Public Property ANombre() As String
        Get
            Return m_strANombre
        End Get
        Set(ByVal Value As String)
            m_strANombre = Value
        End Set
    End Property

    Public Property AApellidoPaterno() As String
        Get
            Return m_strAApellidoPaterno
        End Get
        Set(ByVal Value As String)
            m_strAApellidoPaterno = Value
        End Set
    End Property

    Public Property AApellidoMaterno() As String
        Get
            Return m_strAApellidoMaterno
        End Get
        Set(ByVal Value As String)
            m_strAApellidoMaterno = Value
        End Set
    End Property

    Public Property ASexo() As Char
        Get
            Return m_chrASexo
        End Get
        Set(ByVal Value As Char)
            m_chrASexo = Value
        End Set
    End Property

    Public Property ADomicilio() As String
        Get
            Return m_strADomicilio
        End Get
        Set(ByVal Value As String)
            m_strADomicilio = Value
        End Set
    End Property

    Public Property AEstado() As String
        Get
            Return m_strAEstado
        End Get
        Set(ByVal Value As String)
            m_strAEstado = Value
        End Set
    End Property

    Public Property ACiudad() As String
        Get
            Return m_strACiudad
        End Get
        Set(ByVal Value As String)
            m_strACiudad = Value
        End Set
    End Property

    Public Property AColonia() As String
        Get
            Return m_strAColonia
        End Get
        Set(ByVal Value As String)
            m_strAColonia = Value
        End Set
    End Property

    Public Property ATelefono() As String
        Get
            Return m_strATelefono
        End Get
        Set(ByVal Value As String)
            m_strATelefono = Value
        End Set
    End Property

    Public Property AEMail() As String
        Get
            Return m_strAEMail
        End Get
        Set(ByVal Value As String)
            m_strAEMail = Value
        End Set
    End Property

    Public Property ACP() As Char
        Get
            Return m_chrACP
        End Get
        Set(ByVal Value As Char)
            m_chrACP = Value
        End Set
    End Property

    Public Property FechaExpiracion() As Date
        Get
            Return m_datFechaExpiracion
        End Get
        Set(ByVal Value As Date)
            m_datFechaExpiracion = Value
        End Set
    End Property

    Public Property LimiteCredito() As Double
        Get
            Return m_dblLimiteCredito
        End Get
        Set(ByVal Value As Double)
            m_dblLimiteCredito = Value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return m_dblSaldo
        End Get
        Set(ByVal Value As Double)
            m_dblSaldo = Value
        End Set
    End Property

    Public Property SaldoVencido() As Double
        Get
            Return m_dblSaldoVencido
        End Get
        Set(ByVal Value As Double)
            m_dblSaldoVencido = Value
        End Set
    End Property


    Public Property CuentaContable() As String
        Get
            Return m_strCuentaContable
        End Get
        Set(ByVal Value As String)
            m_strCuentaContable = Value
        End Set
    End Property

    Public Property FirmaDigital() As Byte
        Get
            Return m_bytFirmaDigital
        End Get
        Set(ByVal Value As Byte)
            m_bytFirmaDigital = Value
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
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
        End Set
    End Property

    Public Property Facturas() As DataSet
        Get
            Return m_dsFacturas
        End Get
        Set(ByVal Value As DataSet)
            m_dsFacturas = Value
        End Set
    End Property


    Public Property FormasDePago() As DataSet
        Get
            Return m_dsFormasDePago
        End Get
        Set(ByVal Value As DataSet)
            m_dsFormasDePago = Value
        End Set
    End Property


    Public Property NewFacturas() As DataTable
        Get
            Return m_dtNewFacturas
        End Get
        Set(ByVal Value As DataTable)
            m_dtNewFacturas = Value
        End Set
    End Property

    Public Property DocnumFB05() As String
        Get
            Return m_strDocnumFB05
        End Get
        Set(ByVal Value As String)
            m_strDocnumFB05 = Value
        End Set
    End Property

    Public Property DocnumFB01() As String
        Get
            Return m_strDocnumFB01
        End Get
        Set(ByVal Value As String)
            m_strDocnumFB01 = Value
        End Set
    End Property


#End Region



End Class
