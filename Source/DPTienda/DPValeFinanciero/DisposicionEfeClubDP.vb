Imports System.Collections.Generic

Public Class DisposicionEfeClubDP

#Region "Variables de instancia"

    Private m_TransactionId As Integer
    Private m_CodAlmacen As String
    Private m_CodPlaza As String
    Private m_Caja As String
    Private m_CodVendedor As String
    Private m_NombreCliente As String
    Private m_NoServicio As String
    Private m_NoTarjeta As String
    Private m_AccountNumber As String
    Private m_FechaKarum As DateTime
    Private m_IFE As String
    Private m_TransactionSequenceNumber As String
    Private m_ServicioId As String
    Private m_Banco As String
    Private m_Monto As Decimal
    Private m_EstatusDisp As String
    Private m_FechaDispConf As DateTime
    Private m_PlazoDisp As String
    Private m_UsuarioRep As String
    Private m_FechaRep As DateTime
    Private m_PaymentPlan As String
    Private m_SKU As String
    Private m_IPReproceso As String
    Private m_MontoSeguro As Decimal
    Private m_CMSeguro As Integer
    Private m_TicketSeguro As Integer
    Private m_Generado As Boolean
    Private m_Deslizada As Boolean
    Private oDPVMgr As DPValeFinancieroManager

#End Region

#Region "Constructores"

    Public Sub New(ByVal oDPVMgr As DPValeFinancieroManager)
        Me.TransactionId = 0
        Me.CodAlmacen = ""
        Me.CodPlaza = ""
        Me.Caja = ""
        Me.CodVendedor = ""
        Me.NombreCliente = ""
        Me.NoServicio = ""
        Me.NoTarjeta = ""
        Me.AccountNumber = ""
        Me.FechaKarum = DateTime.Now
        Me.IFE = ""
        Me.TransactionSequenceNumber = ""
        Me.ServicioId = ""
        Me.Banco = ""
        Me.Monto = 0
        Me.EstatusDisp = ""
        Me.FechaDispConf = DateTime.Now
        Me.PlazoDisp = ""
        Me.UsuarioRep = ""
        Me.FechaRep = DateTime.Now
        Me.PaymentPlan = ""
        Me.SKU = ""
        Me.IPReproceso = ""
        Me.MontoSeguro = 0
        Me.CMSeguro = 0
        Me.TicketSeguro = 0
        Me.Generado = False
        Me.Deslizada = False
        Me.oDPVMgr = oDPVMgr
    End Sub

    Public Sub New(ByVal oDPVMgr As DPValeFinancieroManager, ByVal TransactionId As Integer)
        Me.oDPVMgr = oDPVMgr
        Load(TransactionId)
    End Sub

#End Region

#Region "Propiedades"

    Public Property TransactionId As Integer
        Get
            Return m_TransactionId
        End Get
        Set(ByVal value As Integer)
            m_TransactionId = value
        End Set
    End Property

    Public Property CodAlmacen As String
        Get
            Return m_CodAlmacen
        End Get
        Set(ByVal value As String)
            m_CodAlmacen = value
        End Set
    End Property

    Public Property CodPlaza As String
        Get
            Return m_CodPlaza
        End Get
        Set(ByVal value As String)
            m_CodPlaza = value
        End Set
    End Property

    Public Property Caja As String
        Get
            Return m_Caja
        End Get
        Set(ByVal value As String)
            m_Caja = value
        End Set
    End Property

    Public Property CodVendedor As String
        Get
            Return m_CodVendedor
        End Get
        Set(ByVal value As String)
            m_CodVendedor = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return m_NombreCliente
        End Get
        Set(ByVal value As String)
            m_NombreCliente = value
        End Set
    End Property

    Public Property NoServicio As String
        Get
            Return m_NoServicio
        End Get
        Set(ByVal value As String)
            m_NoServicio = value
        End Set
    End Property

    Public Property NoTarjeta As String
        Get
            Return m_NoTarjeta
        End Get
        Set(ByVal value As String)
            m_NoTarjeta = value
        End Set
    End Property

    Public Property AccountNumber As String
        Get
            Return m_AccountNumber
        End Get
        Set(ByVal value As String)
            m_AccountNumber = value
        End Set
    End Property

    Public Property FechaKarum As DateTime
        Get
            Return m_FechaKarum
        End Get
        Set(ByVal value As DateTime)
            m_FechaKarum = value
        End Set
    End Property

    Public Property IFE As String
        Get
            Return m_IFE
        End Get
        Set(ByVal value As String)
            m_IFE = value
        End Set
    End Property

    Public Property TransactionSequenceNumber As String
        Get
            Return m_TransactionSequenceNumber
        End Get
        Set(ByVal value As String)
            m_TransactionSequenceNumber = value
        End Set
    End Property

    Public Property ServicioId As String
        Get
            Return m_ServicioId
        End Get
        Set(ByVal value As String)
            m_ServicioId = value
        End Set
    End Property

    Public Property Banco As String
        Get
            Return m_Banco
        End Get
        Set(ByVal value As String)
            m_Banco = value
        End Set
    End Property

    Public Property Monto As Decimal
        Get
            Return m_Monto
        End Get
        Set(ByVal value As Decimal)
            m_Monto = value
        End Set
    End Property

    Public Property EstatusDisp As String
        Get
            Return m_EstatusDisp
        End Get
        Set(ByVal value As String)
            m_EstatusDisp = value
        End Set
    End Property

    Public Property FechaDispConf As DateTime
        Get
            Return m_FechaDispConf
        End Get
        Set(ByVal value As DateTime)
            m_FechaDispConf = value
        End Set
    End Property

    Public Property PlazoDisp As String
        Get
            Return m_PlazoDisp
        End Get
        Set(ByVal value As String)
            m_PlazoDisp = value
        End Set
    End Property

    Public Property UsuarioRep As String
        Get
            Return m_UsuarioRep
        End Get
        Set(ByVal value As String)
            m_UsuarioRep = value
        End Set
    End Property

    Public Property FechaRep As DateTime
        Get
            Return m_FechaRep
        End Get
        Set(ByVal value As DateTime)
            m_FechaRep = value
        End Set
    End Property

    Public Property PaymentPlan As String
        Get
            Return m_PaymentPlan
        End Get
        Set(ByVal value As String)
            m_PaymentPlan = value
        End Set
    End Property

    Public Property SKU As String
        Get
            Return m_SKU
        End Get
        Set(ByVal value As String)
            m_SKU = value
        End Set
    End Property

    Public Property IPReproceso As String
        Get
            Return m_IPReproceso
        End Get
        Set(ByVal value As String)
            m_IPReproceso = value
        End Set
    End Property

    Public Property MontoSeguro As Decimal
        Get
            Return m_MontoSeguro
        End Get
        Set(ByVal value As Decimal)
            m_MontoSeguro = value
        End Set
    End Property

    Public Property CMSeguro As Integer
        Get
            Return m_CMSeguro
        End Get
        Set(ByVal value As Integer)
            m_CMSeguro = value
        End Set
    End Property

    Public Property TicketSeguro As Integer
        Get
            Return m_TicketSeguro
        End Get
        Set(ByVal value As Integer)
            m_TicketSeguro = value
        End Set
    End Property

    Public Property Generado As Boolean
        Get
            Return m_Generado
        End Get
        Set(ByVal value As Boolean)
            m_Generado = value
        End Set
    End Property

    Public Property Deslizada As Boolean
        Get
            Return m_Deslizada
        End Get
        Set(ByVal value As Boolean)
            m_Deslizada = value
        End Set
    End Property

#End Region

#Region "Metodos y funciones"

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        valido = Me.oDPVMgr.Save(Me)
        Return valido
    End Function

    Public Function SaveHistorial() As Boolean
        Dim valido As Boolean = False
        valido = Me.oDPVMgr.SaveHistorial(Me)
        Return valido
    End Function

    Public Sub Load(ByVal TransactionId As Integer)
        Dim disp As New Dictionary(Of String, Object)
        disp = oDPVMgr.LoadDispersion(TransactionId)
        Me.TransactionId = CInt(disp("TransactionId"))
        Me.CodAlmacen = CStr(disp("CodAlmacen"))
        Me.CodPlaza = CStr(disp("CodPlaza"))
        Me.Caja = CStr(disp("Caja"))
        Me.CodVendedor = CStr(disp("CodVendedor"))
        Me.NombreCliente = CStr(disp("NombreCliente"))
        Me.NoServicio = CStr(disp("NoServicio"))
        Me.NoTarjeta = CStr(disp("NoTarjeta"))
        Me.AccountNumber = CStr(disp("AccountNumber"))
        Me.FechaKarum = CDate(disp("FechaKarum"))
        Me.IFE = CStr(disp("IFE"))
        Me.TransactionSequenceNumber = CStr(disp("TransactionSequenceNumber"))
        Me.ServicioId = CStr(disp("ServicioId"))
        Me.Banco = CStr(disp("Banco"))
        Me.Monto = CDec(disp("Monto"))
        Me.EstatusDisp = CStr(disp("EstatusDisp"))
        Me.FechaDispConf = CDate(disp("FechaDispConf"))
        Me.PlazoDisp = CStr(disp("PlazoDisp"))
        Me.UsuarioRep = CStr(disp("UsuarioRep"))
        Me.FechaRep = CDate(disp("FechaRep"))
        Me.PaymentPlan = CStr(disp("PaymentPlan"))
        Me.SKU = CStr(disp("SKU"))
        Me.IPReproceso = CStr(disp("IPReproceso"))
        Me.MontoSeguro = CDec(disp("MontoSeguro"))
        Me.CMSeguro = CInt(disp("CMSeguro"))
        Me.TicketSeguro = CInt(disp("TicketSeguro"))
        Me.Generado = CBool(disp("Generado"))
        Me.Deslizada = CBool(disp("Deslizada"))
    End Sub

#End Region

End Class
