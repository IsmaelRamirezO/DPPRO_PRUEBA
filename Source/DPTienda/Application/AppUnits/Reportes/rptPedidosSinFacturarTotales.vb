Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptPedidosSinFacturarTotales
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private dtPedidos As DataTable

    Public Sub New(ByRef ds As DataSet, ByVal CodAlmacen As String, ByVal datFechaInicio As Date, ByVal datFechaFin As Date)
        MyBase.New()
        InitializeComponent()

        'Encabezado :

        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        Me.txtSucursal.Text = oAlmacen.ID & "     " & oAlmacen.Descripcion

        oCatalogoAlmacenMgr = Nothing
        oAlmacen = Nothing


        Me.txtFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        Me.txtCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        Me.txtFechaDe.Text = Format(datFechaInicio, "dd-MM-yyyy")

        Me.txtFechaAl.Text = Format(datFechaFin, "dd-MM-yyyy")

        'Detalle :
        dtPedidos = ds.Tables(0).Copy
        Me.DataSource = ds.Tables(0)

        'Pie :

        If ds.Tables(0).Rows.Count > 0 Then
            Me.tbTotalImporte.Text = Format(IIf(IsDBNull(ds.Tables(0).Compute("SUM(Total)", "Status <> 'CAN'")), 0, ds.Tables(0).Compute("SUM(Total)", "Status <> 'CAN'")), "Currency")
        Else
            Me.tbTotalImporte.Text = Format(0, "Currency")
        End If


    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private lblFecha As Label = Nothing
	Private lblCaja As Label = Nothing
	Private txtCaja As Label = Nothing
	Private txtFecha As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private txtSucursal As Label = Nothing
	Private lblDe As Label = Nothing
	Private txtFechaDe As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private lblFechaAl As Label = Nothing
	Private txtFechaAl As Label = Nothing
	Private lblStatus As Label = Nothing
	Private lblTipoVenta As Label = Nothing
	Private lblCliente As Label = Nothing
	Private lblVendedor As Label = Nothing
	Private lblPago As Label = Nothing
	Private lblFormaPago As Label = Nothing
	Private lblDescuento As Label = Nothing
	Private lblImporte As Label = Nothing
	Private lblTotalArt As Label = Nothing
	Private lblFieldFecha As Label = Nothing
	Private lblFolioSAP As Label = Nothing
	Private lblFolio As Label = Nothing
	Private tbFolio As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbArticulo As TextBox = Nothing
	Private tbImporte As TextBox = Nothing
	Private tbdescuento As TextBox = Nothing
	Private SubReport1 As SubReport = Nothing
	Private tbVendedor As TextBox = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private tbNcred As TextBox = Nothing
	Private tbTotalImporte As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPedidosSinFacturarTotales))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.txtCaja = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblDe = New DataDynamics.ActiveReports.Label()
            Me.txtFechaDe = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblFechaAl = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAl = New DataDynamics.ActiveReports.Label()
            Me.lblStatus = New DataDynamics.ActiveReports.Label()
            Me.lblTipoVenta = New DataDynamics.ActiveReports.Label()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblVendedor = New DataDynamics.ActiveReports.Label()
            Me.lblPago = New DataDynamics.ActiveReports.Label()
            Me.lblFormaPago = New DataDynamics.ActiveReports.Label()
            Me.lblDescuento = New DataDynamics.ActiveReports.Label()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.lblTotalArt = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFecha = New DataDynamics.ActiveReports.Label()
            Me.lblFolioSAP = New DataDynamics.ActiveReports.Label()
            Me.lblFolio = New DataDynamics.ActiveReports.Label()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
            Me.tbdescuento = New DataDynamics.ActiveReports.TextBox()
            Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
            Me.tbVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
            Me.tbNcred = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTotalArt,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbdescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNcred,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.txtFolioSAP, Me.tbFecha, Me.tbArticulo, Me.tbImporte, Me.tbdescuento, Me.SubReport1, Me.tbVendedor, Me.tbCliente, Me.tbTipoVenta, Me.tbNcred})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFecha, Me.lblCaja, Me.txtCaja, Me.txtFecha, Me.lblSucursal, Me.txtSucursal, Me.lblDe, Me.txtFechaDe, Me.lblReportTitle, Me.Shape1, Me.lblFechaAl, Me.txtFechaAl})
            Me.ReportHeader.Height = 0.6444445!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTotalImporte, Me.Shape3})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblStatus, Me.lblTipoVenta, Me.lblCliente, Me.lblVendedor, Me.lblPago, Me.lblFormaPago, Me.lblDescuento, Me.lblImporte, Me.lblTotalArt, Me.lblFieldFecha, Me.lblFolioSAP, Me.lblFolio})
            Me.GroupHeader1.Height = 0.1979167!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.1811025!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFecha.Text = "Fecha:"
            Me.lblFecha.Top = 0!
            Me.lblFecha.Width = 0.5625!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.1811025!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.125!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblCaja.Text = "Caja:"
            Me.lblCaja.Top = 0.1875!
            Me.lblCaja.Width = 0.5625!
            '
            'txtCaja
            '
            Me.txtCaja.Height = 0.1811025!
            Me.txtCaja.HyperLink = Nothing
            Me.txtCaja.Left = 0.6250004!
            Me.txtCaja.Name = "txtCaja"
            Me.txtCaja.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtCaja.Text = ""
            Me.txtCaja.Top = 0.1875!
            Me.txtCaja.Width = 0.6983264!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1811025!
            Me.txtFecha.HyperLink = Nothing
            Me.txtFecha.Left = 0.625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFecha.Text = "LblFecha"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 1.0625!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.1811025!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1.4375!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblSucursal.Text = "Sucursal:"
            Me.lblSucursal.Top = 0.375!
            Me.lblSucursal.Width = 0.5625!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.1811025!
            Me.txtSucursal.HyperLink = Nothing
            Me.txtSucursal.Left = 2.125001!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtSucursal.Text = "LblSucursal"
            Me.txtSucursal.Top = 0.375!
            Me.txtSucursal.Width = 3.448326!
            '
            'lblDe
            '
            Me.lblDe.Height = 0.1811025!
            Me.lblDe.HyperLink = Nothing
            Me.lblDe.Left = 2.25!
            Me.lblDe.Name = "lblDe"
            Me.lblDe.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblDe.Text = "De:"
            Me.lblDe.Top = 0.1875!
            Me.lblDe.Width = 0.2810042!
            '
            'txtFechaDe
            '
            Me.txtFechaDe.Height = 0.1811025!
            Me.txtFechaDe.HyperLink = Nothing
            Me.txtFechaDe.Left = 2.5625!
            Me.txtFechaDe.Name = "txtFechaDe"
            Me.txtFechaDe.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFechaDe.Text = "LblFechaDE"
            Me.txtFechaDe.Top = 0.1875!
            Me.txtFechaDe.Width = 0.9685042!
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.1875!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 2.625!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; white-space: nowrap; vert"& _ 
                "ical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Pedidos Si Hay Sin Facturar Totales"
            Me.lblReportTitle.Top = 0!
            Me.lblReportTitle.Width = 3.0625!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.625!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.0625!
            '
            'lblFechaAl
            '
            Me.lblFechaAl.Height = 0.1811025!
            Me.lblFechaAl.HyperLink = Nothing
            Me.lblFechaAl.Left = 3.5625!
            Me.lblFechaAl.Name = "lblFechaAl"
            Me.lblFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFechaAl.Text = "Al:"
            Me.lblFechaAl.Top = 0.1875!
            Me.lblFechaAl.Width = 0.2810042!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.1811025!
            Me.txtFechaAl.HyperLink = Nothing
            Me.txtFechaAl.Left = 3.8125!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFechaAl.Text = ""
            Me.txtFechaAl.Top = 0.1875!
            Me.txtFechaAl.Width = 0.9685042!
            '
            'lblStatus
            '
            Me.lblStatus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblStatus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblStatus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblStatus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblStatus.Height = 0.188!
            Me.lblStatus.HyperLink = Nothing
            Me.lblStatus.Left = 7.0625!
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblStatus.Text = "Status"
            Me.lblStatus.Top = 0!
            Me.lblStatus.Visible = false
            Me.lblStatus.Width = 0.42!
            '
            'lblTipoVenta
            '
            Me.lblTipoVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTipoVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTipoVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTipoVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTipoVenta.Height = 0.1875!
            Me.lblTipoVenta.HyperLink = Nothing
            Me.lblTipoVenta.Left = 6.4375!
            Me.lblTipoVenta.Name = "lblTipoVenta"
            Me.lblTipoVenta.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblTipoVenta.Text = "Tipo Venta"
            Me.lblTipoVenta.Top = 0!
            Me.lblTipoVenta.Width = 0.625!
            '
            'lblCliente
            '
            Me.lblCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCliente.Height = 0.1875!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 5.9375!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblCliente.Text = "Cliente"
            Me.lblCliente.Top = 0!
            Me.lblCliente.Width = 0.5!
            '
            'lblVendedor
            '
            Me.lblVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVendedor.Height = 0.1875!
            Me.lblVendedor.HyperLink = Nothing
            Me.lblVendedor.Left = 5.375!
            Me.lblVendedor.Name = "lblVendedor"
            Me.lblVendedor.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblVendedor.Text = "Vendedor"
            Me.lblVendedor.Top = 0!
            Me.lblVendedor.Width = 0.5625!
            '
            'lblPago
            '
            Me.lblPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblPago.Height = 0.1875!
            Me.lblPago.HyperLink = Nothing
            Me.lblPago.Left = 4.6875!
            Me.lblPago.Name = "lblPago"
            Me.lblPago.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblPago.Text = "Pago"
            Me.lblPago.Top = 0!
            Me.lblPago.Width = 0.6875!
            '
            'lblFormaPago
            '
            Me.lblFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Height = 0.1875!
            Me.lblFormaPago.HyperLink = Nothing
            Me.lblFormaPago.Left = 3.947917!
            Me.lblFormaPago.Name = "lblFormaPago"
            Me.lblFormaPago.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFormaPago.Text = "Forma Pago"
            Me.lblFormaPago.Top = 0!
            Me.lblFormaPago.Width = 0.7395833!
            '
            'lblDescuento
            '
            Me.lblDescuento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescuento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescuento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescuento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescuento.Height = 0.1875!
            Me.lblDescuento.HyperLink = Nothing
            Me.lblDescuento.Left = 3.234!
            Me.lblDescuento.Name = "lblDescuento"
            Me.lblDescuento.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblDescuento.Text = "Descuento"
            Me.lblDescuento.Top = 0!
            Me.lblDescuento.Width = 0.7035!
            '
            'lblImporte
            '
            Me.lblImporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Height = 0.188!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 2.5!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblImporte.Text = "Importe"
            Me.lblImporte.Top = 0!
            Me.lblImporte.Width = 0.715!
            '
            'lblTotalArt
            '
            Me.lblTotalArt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTotalArt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTotalArt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTotalArt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTotalArt.Height = 0.188!
            Me.lblTotalArt.HyperLink = Nothing
            Me.lblTotalArt.Left = 1.9375!
            Me.lblTotalArt.Name = "lblTotalArt"
            Me.lblTotalArt.Style = "font-weight: bold; font-size: 8.25pt"
            Me.lblTotalArt.Text = "Total Art."
            Me.lblTotalArt.Top = 0!
            Me.lblTotalArt.Width = 0.5625!
            '
            'lblFieldFecha
            '
            Me.lblFieldFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Height = 0.1875!
            Me.lblFieldFecha.HyperLink = Nothing
            Me.lblFieldFecha.Left = 1.3125!
            Me.lblFieldFecha.Name = "lblFieldFecha"
            Me.lblFieldFecha.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFieldFecha.Text = "Fecha"
            Me.lblFieldFecha.Top = 0!
            Me.lblFieldFecha.Width = 0.625!
            '
            'lblFolioSAP
            '
            Me.lblFolioSAP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolioSAP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolioSAP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolioSAP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolioSAP.Height = 0.1875!
            Me.lblFolioSAP.HyperLink = Nothing
            Me.lblFolioSAP.Left = 0.625!
            Me.lblFolioSAP.Name = "lblFolioSAP"
            Me.lblFolioSAP.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFolioSAP.Text = "Folio SAP"
            Me.lblFolioSAP.Top = 0!
            Me.lblFolioSAP.Width = 0.6875!
            '
            'lblFolio
            '
            Me.lblFolio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFolio.Height = 0.1875!
            Me.lblFolio.HyperLink = Nothing
            Me.lblFolio.Left = 0!
            Me.lblFolio.Name = "lblFolio"
            Me.lblFolio.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFolio.Text = "Folio"
            Me.lblFolio.Top = 0!
            Me.lblFolio.Width = 0.625!
            '
            'tbFolio
            '
            Me.tbFolio.DataField = "Folio"
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 0!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbFolio.Top = 0!
            Me.tbFolio.Width = 0.625!
            '
            'txtFolioSAP
            '
            Me.txtFolioSAP.DataField = "FolioSAP"
            Me.txtFolioSAP.Height = 0.1875!
            Me.txtFolioSAP.Left = 0.6299213!
            Me.txtFolioSAP.Name = "txtFolioSAP"
            Me.txtFolioSAP.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.txtFolioSAP.Top = 0!
            Me.txtFolioSAP.Width = 0.6496062!
            '
            'tbFecha
            '
            Me.tbFecha.DataField = "Fecha"
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 1.299212!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.OutputFormat = resources.GetString("tbFecha.OutputFormat")
            Me.tbFecha.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbFecha.Top = 0!
            Me.tbFecha.Width = 0.625!
            '
            'tbArticulo
            '
            Me.tbArticulo.DataField = "TotalArticulos"
            Me.tbArticulo.Height = 0.1875!
            Me.tbArticulo.Left = 1.924212!
            Me.tbArticulo.Name = "tbArticulo"
            Me.tbArticulo.OutputFormat = resources.GetString("tbArticulo.OutputFormat")
            Me.tbArticulo.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbArticulo.Top = 0!
            Me.tbArticulo.Width = 0.3125!
            '
            'tbImporte
            '
            Me.tbImporte.DataField = "Total"
            Me.tbImporte.Height = 0.1875!
            Me.tbImporte.Left = 2.5!
            Me.tbImporte.Name = "tbImporte"
            Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
            Me.tbImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbImporte.Top = 0!
            Me.tbImporte.Width = 0.625!
            '
            'tbdescuento
            '
            Me.tbdescuento.DataField = "Descuento"
            Me.tbdescuento.Height = 0.1875!
            Me.tbdescuento.Left = 3.25!
            Me.tbdescuento.Name = "tbdescuento"
            Me.tbdescuento.OutputFormat = resources.GetString("tbdescuento.OutputFormat")
            Me.tbdescuento.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbdescuento.Top = 0!
            Me.tbdescuento.Width = 0.625!
            '
            'SubReport1
            '
            Me.SubReport1.CloseBorder = false
            Me.SubReport1.Height = 0.1875!
            Me.SubReport1.Left = 3.937008!
            Me.SubReport1.Name = "SubReport1"
            Me.SubReport1.Report = Nothing
            Me.SubReport1.ReportName = ""
            Me.SubReport1.Top = 0!
            Me.SubReport1.Width = 1.338583!
            '
            'tbVendedor
            '
            Me.tbVendedor.DataField = "Vendedor"
            Me.tbVendedor.Height = 0.1875!
            Me.tbVendedor.Left = 5.375!
            Me.tbVendedor.Name = "tbVendedor"
            Me.tbVendedor.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbVendedor.Top = 0!
            Me.tbVendedor.Width = 0.5625!
            '
            'tbCliente
            '
            Me.tbCliente.DataField = "Cliente"
            Me.tbCliente.Height = 0.1875!
            Me.tbCliente.Left = 6!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbCliente.Top = 0!
            Me.tbCliente.Width = 0.4375!
            '
            'tbTipoVenta
            '
            Me.tbTipoVenta.DataField = "TipoVenta"
            Me.tbTipoVenta.Height = 0.1875!
            Me.tbTipoVenta.Left = 6.625!
            Me.tbTipoVenta.Name = "tbTipoVenta"
            Me.tbTipoVenta.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbTipoVenta.Top = 0!
            Me.tbTipoVenta.Width = 0.25!
            '
            'tbNcred
            '
            Me.tbNcred.DataField = "Status"
            Me.tbNcred.Height = 0.1875!
            Me.tbNcred.Left = 7.06725!
            Me.tbNcred.Name = "tbNcred"
            Me.tbNcred.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbNcred.Top = 0!
            Me.tbNcred.Visible = false
            Me.tbNcred.Width = 0.382!
            '
            'tbTotalImporte
            '
            Me.tbTotalImporte.Height = 0.2!
            Me.tbTotalImporte.Left = 2.294783!
            Me.tbTotalImporte.Name = "tbTotalImporte"
            Me.tbTotalImporte.OutputFormat = resources.GetString("tbTotalImporte.OutputFormat")
            Me.tbTotalImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbTotalImporte.Top = 0!
            Me.tbTotalImporte.Width = 0.8661417!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.1875!
            Me.Shape3.Left = 0!
            Me.Shape3.LineWeight = 2!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 6.875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.083333!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTotalArt,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbdescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNcred,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        Dim oReporteFormapago As ReporteDetalleFormasPago

        'Dim oFactura As Factura
        Dim oRow() As DataRow

        'oFactura = Nothing
        'oFactura = oFacturaMgr.Create
        'oFacturaMgr.Load(tbFolio.Text, oAppContext.ApplicationConfiguration.NoCaja, oFactura)

        If Not Me.dtPedidos Is Nothing Then
            If Not tbFolio.Text Is Nothing Then
                If Not tbFolio.Text = String.Empty Then
                    Dim pedidoid As Integer = Me.Fields("PedidoID").Value
                    oRow = Me.dtPedidos.Select("FolioSAP ='" & txtFolioSAP.Text & "'", "Folio", DataViewRowState.CurrentRows)
                    If Not oRow Is Nothing Then
                        oReporteFormapago = New ReporteDetalleFormasPago(oRow(0).Item("PedidoID"), 3) '(oDataRpt.FacturaID)
                        Me.SubReport1.Report = oReporteFormapago
                        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
                        'Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember
                    End If
                End If
            End If
        End If
    End Sub
End Class
