
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class AbonosApartados

    Private oParent As AbonosApartadosManager


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


#Region "Fields"

    Private m_strID As Integer
    Private m_strCodAlmacen As String
    Private m_strDPValeID As String
    Private m_strCodCaja As String
    Private m_intFolioAbono As Integer
    Private m_intApartadoID As Integer
    Private m_intFolioApartado As Integer
    Private m_intClienteID As String
    Private m_strCodVendedor As String
    Private m_strCodFormaPago As String
    Private m_chrTipoTarjeta As String
    Private m_strCodBanco As String
    Private m_strNumeroTarjeta As String
    Private m_strNumeroAutorizacion As String
    Private m_dblComisionBancaria As Double
    Private m_dblIngresoComision As Double
    Private m_dblIvaComision As Double
    Private m_dblAbono As Double
    Private m_dblSaldoActual As Double
    Private m_dblSaldoNuevo As Double
    Private m_strDocfi As String
    Private m_strClaCobr As String
    Private m_strTipoMov As String
    Private m_intTicket As Integer
    Private m_strAfil As String
    Private m_intId_Num_Promo As Integer

    Private m_bStatus As Boolean
    Private m_datFecha As Date      'Fecha
    Private m_strUsuario As String  'Usuario

    Public Property Promocion() As Integer
        Get
            Return m_intId_Num_Promo
        End Get
        Set(ByVal Value As Integer)
            m_intId_Num_Promo = Value
        End Set
    End Property


    Public Property NumAfiliacion() As String
        Get
            Return m_strAfil
        End Get
        Set(ByVal Value As String)
            m_strAfil = Value
        End Set
    End Property

    Public Property TipoMov() As String
        Get
            Return m_strTipoMov
        End Get
        Set(ByVal Value As String)
            m_strTipoMov = Value
        End Set
    End Property

    Public Property ClaCobr() As String
        Get
            Return m_strClaCobr
        End Get
        Set(ByVal Value As String)
            m_strClaCobr = Value
        End Set
    End Property

    Public Property Docfi() As String
        Get
            Return m_strDocfi
        End Get
        Set(ByVal Value As String)
            m_strDocfi = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return m_strID

        End Get

        Set(ByVal Valor As Integer)

            m_strID = Valor

        End Set

    End Property

    Public Property DPValeID() As String
        Get
            Return m_strDPValeID

        End Get

        Set(ByVal Valor As String)

            m_strDPValeID = Valor

        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen

        End Get

        Set(ByVal Valor As String)

            m_strCodAlmacen = Valor

        End Set

    End Property
    Public Property CodCaja() As String
        Get
            Return m_strCodCaja

        End Get

        Set(ByVal Valor As String)

            m_strCodCaja = Valor

        End Set

    End Property
    Public Property ApartadoID() As Integer
        Get
            Return m_intApartadoID

        End Get

        Set(ByVal Valor As Integer)

            m_intApartadoID = Valor

        End Set

    End Property
    Public Property FolioApartado() As Integer
        Get
            Return m_intFolioApartado
        End Get
        Set(ByVal Value As Integer)
            m_intFolioApartado = Value
        End Set
    End Property
    Public Property ClienteID() As String

        Get
            Return m_intClienteID

        End Get

        Set(ByVal Valor As String)

            m_intClienteID = Valor

        End Set

    End Property
    Public Property CodVendedor() As String
        Get
            Return m_strCodVendedor

        End Get

        Set(ByVal Valor As String)

            m_strCodVendedor = Valor

        End Set

    End Property
    Public Property CodFormaPago() As String

        Get
            Return m_strCodFormaPago

        End Get

        Set(ByVal Valor As String)

            m_strCodFormaPago = Valor

        End Set

    End Property
    Public Property TipoTarjeta() As String

        Get
            Return m_chrTipoTarjeta

        End Get

        Set(ByVal Valor As String)

            m_chrTipoTarjeta = Valor

        End Set

    End Property
    Public Property CodBanco() As String

        Get
            Return m_strCodBanco

        End Get

        Set(ByVal Valor As String)

            m_strCodBanco = Valor

        End Set

    End Property
    Public Property NumeroTarjeta() As String

        Get
            Return m_strNumeroTarjeta

        End Get

        Set(ByVal Valor As String)

            m_strNumeroTarjeta = Valor

        End Set

    End Property
    Public Property NumeroAutorizacion() As String

        Get
            Return m_strNumeroAutorizacion

        End Get

        Set(ByVal Valor As String)

            m_strNumeroAutorizacion = Valor

        End Set

    End Property
    Public Property ComisionBancaria() As Double

        Get
            Return m_dblComisionBancaria

        End Get

        Set(ByVal Valor As Double)

            m_dblComisionBancaria = Valor

        End Set

    End Property
    Public Property IngresoComision() As Double

        Get
            Return m_dblIngresoComision

        End Get

        Set(ByVal Valor As Double)

            m_dblIngresoComision = Valor

        End Set

    End Property
    Public Property IvaComision() As Double

        Get
            Return m_dblIvaComision

        End Get

        Set(ByVal Valor As Double)

            m_dblIvaComision = Valor

        End Set

    End Property
    Public Property Abono() As Double

        Get
            Return m_dblAbono

        End Get

        Set(ByVal Valor As Double)

            m_dblAbono = Valor

        End Set

    End Property
    Public Property SaldoActual() As Double

        Get
            Return m_dblSaldoActual

        End Get

        Set(ByVal Valor As Double)

            m_dblSaldoActual = Valor

        End Set

    End Property
    Public Property SaldoNuevo() As Double

        Get
            Return m_dblSaldoNuevo

        End Get

        Set(ByVal Valor As Double)

            m_dblSaldoNuevo = Valor

        End Set

    End Property
    Public Property Usuario() As String
        Get
            Return m_strUsuario

        End Get

        Set(ByVal Valor As String)

            m_strUsuario = Valor

        End Set

    End Property
    Public Property Fecha() As Date
        Get
            Return m_datFecha

        End Get

        Set(ByVal Valor As Date)

            m_datFecha = Valor

        End Set

    End Property
    Public Property Status() As Boolean
        Get
            Return m_bStatus

        End Get

        Set(ByVal Valor As Boolean)

            m_bStatus = Valor

        End Set

    End Property
    Public Property FolioAbono() As Integer
        Get
            Return m_intFolioAbono
        End Get
        Set(ByVal Value As Integer)
            m_intFolioAbono = Value
        End Set
    End Property

    Public Property Ticket() As Integer
        Get
            Return m_intTicket
        End Get
        Set(ByVal Value As Integer)
            m_intTicket = Value
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As AbonosApartadosManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Sub ClearFields()

        m_strID = 0
        m_strDPValeID = String.Empty
        m_strCodAlmacen = String.Empty
        m_strCodCaja = String.Empty
        m_intApartadoID = 0
        m_intFolioApartado = 0
        m_intClienteID = 0
        m_strCodVendedor = String.Empty
        m_strCodFormaPago = String.Empty
        m_chrTipoTarjeta = String.Empty
        m_strCodBanco = String.Empty
        m_strNumeroTarjeta = String.Empty
        m_strNumeroAutorizacion = String.Empty
        m_dblComisionBancaria = 0
        m_dblIngresoComision = 0
        m_dblIvaComision = 0
        m_dblAbono = 0
        m_dblSaldoActual = 0
        m_dblSaldoNuevo = 0
        m_strDocfi = String.Empty
        m_strClaCobr = String.Empty
        m_strTipoMov = String.Empty
        m_strAfil = String.Empty
        m_intId_Num_Promo = 0

        m_bStatus = False
        m_datFecha = Date.Now
        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name

        SetFlagNew()
        ResetFlagDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

#End Region




   

End Class
