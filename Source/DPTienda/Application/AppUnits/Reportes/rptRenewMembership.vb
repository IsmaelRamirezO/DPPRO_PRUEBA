Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptRenewMembership
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal datos As Hashtable)
        MyBase.New()
        InitializeComponent()
        Me.txtFecha.Text = "Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")
        Me.txtHora.Text = "Hora: " & DateTime.Now.ToString("HH:mm")
        Me.txtNoTienda.Text = oAppContext.ApplicationConfiguration.Almacen
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        Me.txtNombreTienda.Text = oAlmacen.Descripcion & vbCrLf & _
                            oAlmacen.DireccionCalle & vbCrLf & _
                            "C.P." & oAlmacen.DireccionCP & _
                            " TEL. " & oAlmacen.TelefonoNum & vbCrLf & _
                            "R.F.C. CDP-950126-9M5" & vbCrLf & _
                            oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        Me.txtNoCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        Me.txtVendedor.Text = CStr(datos("CodVendedor"))
        Me.txtCardTypeID.Text = CStr(datos("CardTypeID"))
        Me.txtNoTarjeta.Text = CStr(datos("CardId"))
        Me.txtStatus.Text = CStr(datos("Status"))
        Me.txtFechaActivacion.Text = CStr(datos("Activate"))
        Me.txtFechaExpiracion.Text = CStr(datos("Expire"))
        Me.txtIDExpiracion.Text = CStr(datos("ExpireStatusID"))
        Me.txtMensajeExpiracion.Text = CStr(datos("ExpireStatusDescriptionCustomer"))
        Me.txtClienteID.Text = CStr(datos("CustomerID"))
        Me.txtCliente.Text = CStr(datos("CustomerName"))
        Me.txtTotalPuntos.Text = CStr(datos("BalancePoints"))
        Me.txtPuntoExpirar.Text = CStr(datos("PointsToExpire"))
        Me.txtTotalPuntoPesos.Text = CStr(datos("BalanceAmount"))
        Me.txtPromocional.Text = CStr(datos("PromotinalMessage"))
        Me.txtMensaje.Text = CStr(datos("PersonalMessage"))
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblDPCardPuntos As Label = Nothing
	Private lblStatus As Label = Nothing
	Private txtStatus As TextBox = Nothing
	Private lblTotalPuntos As Label = Nothing
	Private txtTotalPuntos As TextBox = Nothing
	Private lblFechaActivacion As Label = Nothing
	Private txtFechaActivacion As TextBox = Nothing
	Private lblTotalPuntosPesos As Label = Nothing
	Private txtTotalPuntoPesos As TextBox = Nothing
	Private txtPromocional As TextBox = Nothing
	Private txtMensaje As TextBox = Nothing
	Private lblOldCard As Label = Nothing
	Private txtNoTarjeta As TextBox = Nothing
	Private lblNoTienda As Label = Nothing
	Private txtNoTienda As TextBox = Nothing
	Private lblNoCaja As Label = Nothing
	Private txtNoCaja As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtHora As TextBox = Nothing
	Private txtVendedor As TextBox = Nothing
	Private lblVendedor As Label = Nothing
	Private txtNombreTienda As TextBox = Nothing
	Private lblFechaExpiracion As Label = Nothing
	Private txtFechaExpiracion As TextBox = Nothing
	Private lblClienteID As Label = Nothing
	Private txtClienteID As TextBox = Nothing
	Private lblCliente As Label = Nothing
	Private txtCliente As TextBox = Nothing
	Private lblPuntosExpira As Label = Nothing
	Private txtPuntoExpirar As TextBox = Nothing
	Private txtMensajeExpiracion As TextBox = Nothing
	Private lblIDExpiracion As Label = Nothing
	Private txtIDExpiracion As TextBox = Nothing
	Private lblCardTypeID As Label = Nothing
	Private txtCardTypeID As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRenewMembership))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblDPCardPuntos = New DataDynamics.ActiveReports.Label()
            Me.lblStatus = New DataDynamics.ActiveReports.Label()
            Me.txtStatus = New DataDynamics.ActiveReports.TextBox()
            Me.lblTotalPuntos = New DataDynamics.ActiveReports.Label()
            Me.txtTotalPuntos = New DataDynamics.ActiveReports.TextBox()
            Me.lblFechaActivacion = New DataDynamics.ActiveReports.Label()
            Me.txtFechaActivacion = New DataDynamics.ActiveReports.TextBox()
            Me.lblTotalPuntosPesos = New DataDynamics.ActiveReports.Label()
            Me.txtTotalPuntoPesos = New DataDynamics.ActiveReports.TextBox()
            Me.txtPromocional = New DataDynamics.ActiveReports.TextBox()
            Me.txtMensaje = New DataDynamics.ActiveReports.TextBox()
            Me.lblOldCard = New DataDynamics.ActiveReports.Label()
            Me.txtNoTarjeta = New DataDynamics.ActiveReports.TextBox()
            Me.lblNoTienda = New DataDynamics.ActiveReports.Label()
            Me.txtNoTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblNoCaja = New DataDynamics.ActiveReports.Label()
            Me.txtNoCaja = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtHora = New DataDynamics.ActiveReports.TextBox()
            Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.lblVendedor = New DataDynamics.ActiveReports.Label()
            Me.txtNombreTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblFechaExpiracion = New DataDynamics.ActiveReports.Label()
            Me.txtFechaExpiracion = New DataDynamics.ActiveReports.TextBox()
            Me.lblClienteID = New DataDynamics.ActiveReports.Label()
            Me.txtClienteID = New DataDynamics.ActiveReports.TextBox()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
            Me.lblPuntosExpira = New DataDynamics.ActiveReports.Label()
            Me.txtPuntoExpirar = New DataDynamics.ActiveReports.TextBox()
            Me.txtMensajeExpiracion = New DataDynamics.ActiveReports.TextBox()
            Me.lblIDExpiracion = New DataDynamics.ActiveReports.Label()
            Me.txtIDExpiracion = New DataDynamics.ActiveReports.TextBox()
            Me.lblCardTypeID = New DataDynamics.ActiveReports.Label()
            Me.txtCardTypeID = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblDPCardPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTotalPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalPuntos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaActivacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaActivacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTotalPuntosPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalPuntoPesos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPromocional,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMensaje,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblOldCard,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoTarjeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaExpiracion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaExpiracion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblClienteID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPuntosExpira,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPuntoExpirar,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMensajeExpiracion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblIDExpiracion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtIDExpiracion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCardTypeID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCardTypeID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblDPCardPuntos, Me.lblStatus, Me.txtStatus, Me.lblTotalPuntos, Me.txtTotalPuntos, Me.lblFechaActivacion, Me.txtFechaActivacion, Me.lblTotalPuntosPesos, Me.txtTotalPuntoPesos, Me.txtPromocional, Me.txtMensaje, Me.lblOldCard, Me.txtNoTarjeta, Me.lblNoTienda, Me.txtNoTienda, Me.lblNoCaja, Me.txtNoCaja, Me.txtFecha, Me.txtHora, Me.txtVendedor, Me.lblVendedor, Me.txtNombreTienda, Me.lblFechaExpiracion, Me.txtFechaExpiracion, Me.lblClienteID, Me.txtClienteID, Me.lblCliente, Me.txtCliente, Me.lblPuntosExpira, Me.txtPuntoExpirar, Me.txtMensajeExpiracion, Me.lblIDExpiracion, Me.txtIDExpiracion, Me.lblCardTypeID, Me.txtCardTypeID})
            Me.PageHeader.Height = 6.165972!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblDPCardPuntos
            '
            Me.lblDPCardPuntos.Height = 0.1875!
            Me.lblDPCardPuntos.HyperLink = Nothing
            Me.lblDPCardPuntos.Left = 0.125!
            Me.lblDPCardPuntos.Name = "lblDPCardPuntos"
            Me.lblDPCardPuntos.Style = "font-weight: bold; font-size: 9.75pt; vertical-align: top"
            Me.lblDPCardPuntos.Text = "Renovacion de Membresia DPCard"
            Me.lblDPCardPuntos.Top = 0!
            Me.lblDPCardPuntos.Width = 2.5!
            '
            'lblStatus
            '
            Me.lblStatus.Height = 0.1875!
            Me.lblStatus.HyperLink = Nothing
            Me.lblStatus.Left = 0!
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblStatus.Text = "Estatus:"
            Me.lblStatus.Top = 2.25!
            Me.lblStatus.Width = 0.625!
            '
            'txtStatus
            '
            Me.txtStatus.Height = 0.1875!
            Me.txtStatus.Left = 0.625!
            Me.txtStatus.Name = "txtStatus"
            Me.txtStatus.Top = 2.25!
            Me.txtStatus.Width = 1.875!
            '
            'lblTotalPuntos
            '
            Me.lblTotalPuntos.Height = 0.1875!
            Me.lblTotalPuntos.HyperLink = Nothing
            Me.lblTotalPuntos.Left = 0!
            Me.lblTotalPuntos.Name = "lblTotalPuntos"
            Me.lblTotalPuntos.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblTotalPuntos.Text = "Total Puntos:"
            Me.lblTotalPuntos.Top = 4.125!
            Me.lblTotalPuntos.Width = 1.125!
            '
            'txtTotalPuntos
            '
            Me.txtTotalPuntos.Height = 0.1875!
            Me.txtTotalPuntos.Left = 1.125!
            Me.txtTotalPuntos.Name = "txtTotalPuntos"
            Me.txtTotalPuntos.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtTotalPuntos.Top = 4.125!
            Me.txtTotalPuntos.Width = 1.375!
            '
            'lblFechaActivacion
            '
            Me.lblFechaActivacion.Height = 0.1875!
            Me.lblFechaActivacion.HyperLink = Nothing
            Me.lblFechaActivacion.Left = 0!
            Me.lblFechaActivacion.Name = "lblFechaActivacion"
            Me.lblFechaActivacion.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblFechaActivacion.Text = "Fecha Activación:"
            Me.lblFechaActivacion.Top = 2.4375!
            Me.lblFechaActivacion.Width = 1.25!
            '
            'txtFechaActivacion
            '
            Me.txtFechaActivacion.Height = 0.1875!
            Me.txtFechaActivacion.Left = 1.25!
            Me.txtFechaActivacion.Name = "txtFechaActivacion"
            Me.txtFechaActivacion.OutputFormat = resources.GetString("txtFechaActivacion.OutputFormat")
            Me.txtFechaActivacion.Top = 2.4375!
            Me.txtFechaActivacion.Width = 1.25!
            '
            'lblTotalPuntosPesos
            '
            Me.lblTotalPuntosPesos.Height = 0.1875!
            Me.lblTotalPuntosPesos.HyperLink = Nothing
            Me.lblTotalPuntosPesos.Left = 0!
            Me.lblTotalPuntosPesos.Name = "lblTotalPuntosPesos"
            Me.lblTotalPuntosPesos.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblTotalPuntosPesos.Text = "Puntos en Pesos:"
            Me.lblTotalPuntosPesos.Top = 4.5!
            Me.lblTotalPuntosPesos.Width = 1.5!
            '
            'txtTotalPuntoPesos
            '
            Me.txtTotalPuntoPesos.Height = 0.1875!
            Me.txtTotalPuntoPesos.Left = 1.5!
            Me.txtTotalPuntoPesos.Name = "txtTotalPuntoPesos"
            Me.txtTotalPuntoPesos.OutputFormat = resources.GetString("txtTotalPuntoPesos.OutputFormat")
            Me.txtTotalPuntoPesos.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtTotalPuntoPesos.Top = 4.5!
            Me.txtTotalPuntoPesos.Width = 1!
            '
            'txtPromocional
            '
            Me.txtPromocional.Height = 0.5625!
            Me.txtPromocional.Left = 0!
            Me.txtPromocional.Name = "txtPromocional"
            Me.txtPromocional.Top = 4.947917!
            Me.txtPromocional.Width = 2.5!
            '
            'txtMensaje
            '
            Me.txtMensaje.Height = 0.375!
            Me.txtMensaje.Left = 0!
            Me.txtMensaje.Name = "txtMensaje"
            Me.txtMensaje.Style = "font-size: 8.25pt"
            Me.txtMensaje.Top = 5.625!
            Me.txtMensaje.Width = 2.5!
            '
            'lblOldCard
            '
            Me.lblOldCard.Height = 0.1875!
            Me.lblOldCard.HyperLink = Nothing
            Me.lblOldCard.Left = 0!
            Me.lblOldCard.Name = "lblOldCard"
            Me.lblOldCard.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblOldCard.Text = "No. Tarjeta:"
            Me.lblOldCard.Top = 2.0625!
            Me.lblOldCard.Width = 0.8125!
            '
            'txtNoTarjeta
            '
            Me.txtNoTarjeta.Height = 0.1875!
            Me.txtNoTarjeta.Left = 0.8125!
            Me.txtNoTarjeta.Name = "txtNoTarjeta"
            Me.txtNoTarjeta.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtNoTarjeta.Top = 2.0625!
            Me.txtNoTarjeta.Width = 1.6875!
            '
            'lblNoTienda
            '
            Me.lblNoTienda.Height = 0.1875!
            Me.lblNoTienda.HyperLink = Nothing
            Me.lblNoTienda.Left = 0!
            Me.lblNoTienda.Name = "lblNoTienda"
            Me.lblNoTienda.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblNoTienda.Text = "No. Tienda:"
            Me.lblNoTienda.Top = 0.53125!
            Me.lblNoTienda.Width = 0.875!
            '
            'txtNoTienda
            '
            Me.txtNoTienda.Height = 0.1875!
            Me.txtNoTienda.Left = 0.875!
            Me.txtNoTienda.Name = "txtNoTienda"
            Me.txtNoTienda.Top = 0.531!
            Me.txtNoTienda.Width = 1.125!
            '
            'lblNoCaja
            '
            Me.lblNoCaja.Height = 0.1875!
            Me.lblNoCaja.HyperLink = Nothing
            Me.lblNoCaja.Left = 0!
            Me.lblNoCaja.Name = "lblNoCaja"
            Me.lblNoCaja.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblNoCaja.Text = "No. Caja:"
            Me.lblNoCaja.Top = 1.40625!
            Me.lblNoCaja.Width = 0.75!
            '
            'txtNoCaja
            '
            Me.txtNoCaja.Height = 0.1875!
            Me.txtNoCaja.Left = 0.75!
            Me.txtNoCaja.Name = "txtNoCaja"
            Me.txtNoCaja.Top = 1.406!
            Me.txtNoCaja.Width = 0.6875!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1875!
            Me.txtFecha.Left = 0!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtFecha.Text = "Fecha: 18/04/2015"
            Me.txtFecha.Top = 0.25!
            Me.txtFecha.Width = 1.375!
            '
            'txtHora
            '
            Me.txtHora.Height = 0.1875!
            Me.txtHora.Left = 1.375!
            Me.txtHora.Name = "txtHora"
            Me.txtHora.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtHora.Text = "Hora: 12:30"
            Me.txtHora.Top = 0.25!
            Me.txtHora.Width = 1.125!
            '
            'txtVendedor
            '
            Me.txtVendedor.Height = 0.1875!
            Me.txtVendedor.Left = 0.75!
            Me.txtVendedor.Name = "txtVendedor"
            Me.txtVendedor.Top = 1.5935!
            Me.txtVendedor.Width = 0.6875!
            '
            'lblVendedor
            '
            Me.lblVendedor.Height = 0.1875!
            Me.lblVendedor.HyperLink = Nothing
            Me.lblVendedor.Left = 0!
            Me.lblVendedor.Name = "lblVendedor"
            Me.lblVendedor.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblVendedor.Text = "Vendedor:"
            Me.lblVendedor.Top = 1.59375!
            Me.lblVendedor.Width = 0.75!
            '
            'txtNombreTienda
            '
            Me.txtNombreTienda.Height = 0.565!
            Me.txtNombreTienda.Left = 0!
            Me.txtNombreTienda.Name = "txtNombreTienda"
            Me.txtNombreTienda.Top = 0.7925!
            Me.txtNombreTienda.Width = 2.5!
            '
            'lblFechaExpiracion
            '
            Me.lblFechaExpiracion.Height = 0.1875!
            Me.lblFechaExpiracion.HyperLink = Nothing
            Me.lblFechaExpiracion.Left = 0!
            Me.lblFechaExpiracion.Name = "lblFechaExpiracion"
            Me.lblFechaExpiracion.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblFechaExpiracion.Text = "Fecha Expiración:"
            Me.lblFechaExpiracion.Top = 2.625!
            Me.lblFechaExpiracion.Width = 1.25!
            '
            'txtFechaExpiracion
            '
            Me.txtFechaExpiracion.Height = 0.1875!
            Me.txtFechaExpiracion.Left = 1.25!
            Me.txtFechaExpiracion.Name = "txtFechaExpiracion"
            Me.txtFechaExpiracion.OutputFormat = resources.GetString("txtFechaExpiracion.OutputFormat")
            Me.txtFechaExpiracion.Top = 2.625!
            Me.txtFechaExpiracion.Width = 1.25!
            '
            'lblClienteID
            '
            Me.lblClienteID.Height = 0.1875!
            Me.lblClienteID.HyperLink = Nothing
            Me.lblClienteID.Left = 0!
            Me.lblClienteID.Name = "lblClienteID"
            Me.lblClienteID.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblClienteID.Text = "Cliente ID:"
            Me.lblClienteID.Top = 3.625!
            Me.lblClienteID.Width = 0.75!
            '
            'txtClienteID
            '
            Me.txtClienteID.Height = 0.1875!
            Me.txtClienteID.Left = 0.75!
            Me.txtClienteID.Name = "txtClienteID"
            Me.txtClienteID.OutputFormat = resources.GetString("txtClienteID.OutputFormat")
            Me.txtClienteID.Top = 3.625!
            Me.txtClienteID.Width = 1.75!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.1875!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 0!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblCliente.Text = "Cliente:"
            Me.lblCliente.Top = 3.8125!
            Me.lblCliente.Width = 0.6875!
            '
            'txtCliente
            '
            Me.txtCliente.Height = 0.1875!
            Me.txtCliente.Left = 0.6875!
            Me.txtCliente.Name = "txtCliente"
            Me.txtCliente.OutputFormat = resources.GetString("txtCliente.OutputFormat")
            Me.txtCliente.Top = 3.8125!
            Me.txtCliente.Width = 1.8125!
            '
            'lblPuntosExpira
            '
            Me.lblPuntosExpira.Height = 0.1875!
            Me.lblPuntosExpira.HyperLink = Nothing
            Me.lblPuntosExpira.Left = 0!
            Me.lblPuntosExpira.Name = "lblPuntosExpira"
            Me.lblPuntosExpira.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblPuntosExpira.Text = "Puntos a expirar:"
            Me.lblPuntosExpira.Top = 4.3125!
            Me.lblPuntosExpira.Width = 1.25!
            '
            'txtPuntoExpirar
            '
            Me.txtPuntoExpirar.Height = 0.1875!
            Me.txtPuntoExpirar.Left = 1.25!
            Me.txtPuntoExpirar.Name = "txtPuntoExpirar"
            Me.txtPuntoExpirar.Style = "font-weight: bold; font-size: 9.75pt"
            Me.txtPuntoExpirar.Top = 4.3125!
            Me.txtPuntoExpirar.Width = 1.25!
            '
            'txtMensajeExpiracion
            '
            Me.txtMensajeExpiracion.Height = 0.5!
            Me.txtMensajeExpiracion.Left = 0!
            Me.txtMensajeExpiracion.Name = "txtMensajeExpiracion"
            Me.txtMensajeExpiracion.OutputFormat = resources.GetString("txtMensajeExpiracion.OutputFormat")
            Me.txtMensajeExpiracion.Top = 3!
            Me.txtMensajeExpiracion.Width = 2.5!
            '
            'lblIDExpiracion
            '
            Me.lblIDExpiracion.Height = 0.1875!
            Me.lblIDExpiracion.HyperLink = Nothing
            Me.lblIDExpiracion.Left = 0!
            Me.lblIDExpiracion.Name = "lblIDExpiracion"
            Me.lblIDExpiracion.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblIDExpiracion.Text = "Id Expiración:"
            Me.lblIDExpiracion.Top = 2.8125!
            Me.lblIDExpiracion.Width = 1.25!
            '
            'txtIDExpiracion
            '
            Me.txtIDExpiracion.Height = 0.1875!
            Me.txtIDExpiracion.Left = 1.25!
            Me.txtIDExpiracion.Name = "txtIDExpiracion"
            Me.txtIDExpiracion.OutputFormat = resources.GetString("txtIDExpiracion.OutputFormat")
            Me.txtIDExpiracion.Top = 2.8125!
            Me.txtIDExpiracion.Width = 1.25!
            '
            'lblCardTypeID
            '
            Me.lblCardTypeID.Height = 0.1875!
            Me.lblCardTypeID.HyperLink = Nothing
            Me.lblCardTypeID.Left = 0!
            Me.lblCardTypeID.Name = "lblCardTypeID"
            Me.lblCardTypeID.Style = "font-weight: bold; font-size: 9.75pt"
            Me.lblCardTypeID.Text = "Tipo Tarjeta:"
            Me.lblCardTypeID.Top = 1.875!
            Me.lblCardTypeID.Width = 0.9375!
            '
            'txtCardTypeID
            '
            Me.txtCardTypeID.Height = 0.1875!
            Me.txtCardTypeID.Left = 0.9375!
            Me.txtCardTypeID.Name = "txtCardTypeID"
            Me.txtCardTypeID.Top = 1.875!
            Me.txtCardTypeID.Width = 1.5625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.646!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblDPCardPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTotalPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalPuntos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaActivacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaActivacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTotalPuntosPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalPuntoPesos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPromocional,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMensaje,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblOldCard,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoTarjeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaExpiracion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaExpiracion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblClienteID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPuntosExpira,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPuntoExpirar,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMensajeExpiracion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblIDExpiracion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtIDExpiracion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCardTypeID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCardTypeID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
