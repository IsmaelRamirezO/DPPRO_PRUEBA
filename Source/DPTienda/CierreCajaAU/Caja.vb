
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class Caja

    Private oParent As CierreCajaManager



#Region "Fields"

    Private m_intCierreCajaID As Integer
    Private m_intInicioCajaID As Integer
    Private m_strCodCaja As String
    Private m_intFolioFacturaInicial As Integer
    Private m_intFolioFacturaFinal As Integer
    Private m_decRetiros As Decimal
    Private m_decTarjetaManual As Decimal
    Private m_decTarjetaElectronica As Decimal
    Private m_decFacturacion As Decimal
    Private m_decFondo As Decimal
    Private m_decAbonosApartados As Decimal
    Private m_decAbonosCreditoDirecto As Decimal
    Private m_decSobrante As Decimal
    Private m_decFaltante As Decimal
    Private m_datFechaCierre As Date
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bolStatusRegistro As Boolean

    '--------------------------------------
    ' JNAVA (23.03.2015): DPCARD
    '--------------------------------------
    Private m_decDPCARD As Decimal


    Public Property CierreCajaID() As Integer
        Get
            Return m_intCierreCajaID
        End Get

        Set(ByVal Value As Integer)
            m_intCierreCajaID = Value
        End Set
    End Property


    Public Property InicioCajaID() As Integer
        Get
            Return m_intInicioCajaID
        End Get
        Set(ByVal Value As Integer)
            m_intInicioCajaID = Value
        End Set
    End Property


    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set
    End Property


    Public Property FolioFacturaInicial() As Integer
        Get
            Return m_intFolioFacturaInicial
        End Get
        Set(ByVal Value As Integer)
            m_intFolioFacturaInicial = Value
        End Set
    End Property


    Public Property FolioFacturaFinal() As Integer
        Get
            Return m_intFolioFacturaFinal
        End Get
        Set(ByVal Value As Integer)
            m_intFolioFacturaFinal = Value
        End Set
    End Property


    Public Property Retiros() As Decimal
        Get
            Return m_decRetiros
        End Get
        Set(ByVal Value As Decimal)
            m_decRetiros = Value
        End Set
    End Property


    Public Property TarjetaManual() As Decimal
        Get
            Return m_decTarjetaManual
        End Get
        Set(ByVal Value As Decimal)
            m_decTarjetaManual = Value
        End Set
    End Property


    Public Property TarjetaElectronica() As Decimal
        Get
            Return m_decTarjetaElectronica
        End Get
        Set(ByVal Value As Decimal)
            m_decTarjetaElectronica = Value
        End Set
    End Property


    Public Property Facturacion() As Decimal
        Get
            Return m_decFacturacion
        End Get
        Set(ByVal Value As Decimal)
            m_decFacturacion = Value
        End Set
    End Property


    Public Property Fondo() As Decimal
        Get
            Return m_decFondo
        End Get
        Set(ByVal Value As Decimal)
            m_decFondo = Value
        End Set
    End Property


    Public Property AbonosApartados() As Decimal
        Get
            Return m_decAbonosApartados
        End Get
        Set(ByVal Value As Decimal)
            m_decAbonosApartados = Value
        End Set
    End Property


    Public Property AbonosCreditoDirecto() As Decimal
        Get
            Return m_decAbonosCreditoDirecto
        End Get
        Set(ByVal Value As Decimal)
            m_decAbonosCreditoDirecto = Value
        End Set
    End Property


    Public Property Sobrante() As Decimal
        Get
            Return m_decSobrante
        End Get
        Set(ByVal Value As Decimal)
            m_decSobrante = Value
        End Set
    End Property


    Public Property Faltante() As Decimal
        Get
            Return m_decFaltante
        End Get
        Set(ByVal Value As Decimal)
            m_decFaltante = Value
        End Set
    End Property


    Public Property FechaCierre() As Date
        Get
            Return m_datFechaCierre
        End Get
        Set(ByVal Value As Date)
            m_datFechaCierre = Value
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

    Public Property DPCardCredit() As Decimal
        Get
            Return m_decDPCARD
        End Get
        Set(ByVal Value As Decimal)
            m_decDPCARD = Value
        End Set
    End Property

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

    Friend Sub New(ByVal Parent As CierreCajaManager)

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

        m_intCierreCajaID = 0
        m_intInicioCajaID = 0
        m_strCodCaja = String.Empty
        m_intFolioFacturaInicial = 0
        m_intFolioFacturaFinal = 0
        m_decRetiros = 0.0
        m_decTarjetaManual = 0.0
        m_decTarjetaElectronica = 0.0
        m_decFacturacion = 0.0
        m_decFondo = 0.0
        m_decAbonosApartados = 0.0
        m_decAbonosCreditoDirecto = 0.0
        m_decSobrante = 0.0
        m_decFaltante = 0.0
        m_datFechaCierre = Date.Now
        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name
        m_datFecha = Date.Now
        m_bolStatusRegistro = True
        m_decDPCARD = 0.0

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
