Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptVentasPorCliente
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsVentas As DataSet, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal TipoVenta As String, ByVal Almacen As String, ByVal Cliente As String)
        MyBase.New()
        InitializeComponent()

        Me.txtAlmacen.Text = Almacen
        Me.txtCliente.Text = Cliente
        Me.txtFechaDe.Text = FechaDe.ToShortDateString
        Me.txtFechaA.Text = FechaA.ToShortDateString
        Me.txtTipoVenta.Text = TipoVenta

        Me.DataSource = dsVentas
        Me.DataMember = "Facturas"

        Me.txtFecha.Text = Now.Date.ToShortDateString
        

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label16 As Label = Nothing
	Private Label1 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtAlmacen As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtFechaDe As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtFechaA As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtTipoVenta As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtCliente As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Line1 As Line = Nothing
	Private ClienteID As TextBox = Nothing
	Private txtFolioFactura As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private txtCodCaja As TextBox = Nothing
	Private txtVendedor As TextBox = Nothing
	Private txtIVA As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtDescuento As TextBox = Nothing
	Private txtSubTotal As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private txtSTotal As TextBox = Nothing
	Private txtSDescuento As TextBox = Nothing
	Private txtPagina As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasPorCliente))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
        Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.txtIVA = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.txtSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtAlmacen = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaDe = New DataDynamics.ActiveReports.TextBox()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaA = New DataDynamics.ActiveReports.TextBox()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.txtTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.txtPagina = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.ClienteID = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.txtSTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtSDescuento = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtFolioFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClienteID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioFactura, Me.txtFolioSAP, Me.txtCodCaja, Me.txtVendedor, Me.txtIVA, Me.txtTotal, Me.txtDescuento, Me.txtSubTotal, Me.TextBox1})
        Me.Detail.Height = 0.1451389!
        Me.Detail.Name = "Detail"
        '
        'txtFolioFactura
        '
        Me.txtFolioFactura.DataField = "FolioFactura"
        Me.txtFolioFactura.Height = 0.1312336!
        Me.txtFolioFactura.Left = 0.8071687!
        Me.txtFolioFactura.Name = "txtFolioFactura"
        Me.txtFolioFactura.Style = "text-align: right; font-size: 8.25pt"
        Me.txtFolioFactura.Text = Nothing
        Me.txtFolioFactura.Top = 0.0!
        Me.txtFolioFactura.Width = 0.656168!
        '
        'txtFolioSAP
        '
        Me.txtFolioSAP.DataField = "Referencia"
        Me.txtFolioSAP.Height = 0.1312336!
        Me.txtFolioSAP.Left = 1.509187!
        Me.txtFolioSAP.Name = "txtFolioSAP"
        Me.txtFolioSAP.Style = "text-align: right; font-size: 8.25pt"
        Me.txtFolioSAP.Text = "9999999999"
        Me.txtFolioSAP.Top = 0.0!
        Me.txtFolioSAP.Width = 0.7217847!
        '
        'txtCodCaja
        '
        Me.txtCodCaja.DistinctField = "CodCaja"
        Me.txtCodCaja.Height = 0.1312336!
        Me.txtCodCaja.Left = 2.296588!
        Me.txtCodCaja.Name = "txtCodCaja"
        Me.txtCodCaja.Style = "text-align: center; font-size: 8.25pt"
        Me.txtCodCaja.Text = "99"
        Me.txtCodCaja.Top = 0.0!
        Me.txtCodCaja.Width = 0.2624671!
        '
        'txtVendedor
        '
        Me.txtVendedor.DataField = "CodVendedor"
        Me.txtVendedor.Height = 0.1312336!
        Me.txtVendedor.Left = 2.693405!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Style = "text-align: center; font-size: 8.25pt"
        Me.txtVendedor.Text = Nothing
        Me.txtVendedor.Top = 0.0!
        Me.txtVendedor.Width = 0.5905511!
        '
        'txtIVA
        '
        Me.txtIVA.DataField = "IVA"
        Me.txtIVA.Height = 0.1312336!
        Me.txtIVA.Left = 4.330709!
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.OutputFormat = resources.GetString("txtIVA.OutputFormat")
        Me.txtIVA.Style = "font-size: 8.25pt"
        Me.txtIVA.Text = Nothing
        Me.txtIVA.Top = 0.0!
        Me.txtIVA.Width = 0.4593177!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "Total"
        Me.txtTotal.Height = 0.1312336!
        Me.txtTotal.Left = 4.855642!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
        Me.txtTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.txtTotal.Text = Nothing
        Me.txtTotal.Top = 0.0!
        Me.txtTotal.Width = 0.9186361!
        '
        'txtDescuento
        '
        Me.txtDescuento.DataField = "DescTotal"
        Me.txtDescuento.Height = 0.1312336!
        Me.txtDescuento.Left = 5.839895!
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.OutputFormat = resources.GetString("txtDescuento.OutputFormat")
        Me.txtDescuento.Style = "text-align: right; font-size: 8.25pt"
        Me.txtDescuento.Text = "$0"
        Me.txtDescuento.Top = 0.0!
        Me.txtDescuento.Width = 0.6561685!
        '
        'txtSubTotal
        '
        Me.txtSubTotal.DataField = "SubTotal"
        Me.txtSubTotal.Height = 0.1312336!
        Me.txtSubTotal.Left = 3.349574!
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat")
        Me.txtSubTotal.Style = "text-align: right; font-size: 8.25pt"
        Me.txtSubTotal.Text = Nothing
        Me.txtSubTotal.Top = 0.0!
        Me.txtSubTotal.Width = 0.7842847!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "Fecha"
        Me.TextBox1.Height = 0.1312336!
        Me.TextBox1.Left = 6.527395!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
        Me.TextBox1.Style = "text-align: right; font-size: 8.25pt"
        Me.TextBox1.Text = "09/12/2006"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.624836!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.Label18})
        Me.ReportFooter.Height = 0.25!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "Total"
        Me.TextBox2.Height = 0.1312336!
        Me.TextBox2.Left = 4.78691!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
        Me.TextBox2.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox2.Text = "TextBox1"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 1.0!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "DescTotal"
        Me.TextBox3.Height = 0.1312336!
        Me.TextBox3.Left = 5.843013!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
        Me.TextBox3.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox3.Text = "TextBox2"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.671916!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.6255744!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = ""
        Me.Label18.Text = "Total  Ventas y Descuentos .-"
        Me.Label18.Top = 0.0!
        Me.Label18.Width = 2.064715!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label16, Me.Label1, Me.txtFecha, Me.Label2, Me.txtAlmacen, Me.Label3, Me.txtFechaDe, Me.Label4, Me.txtFechaA, Me.Label5, Me.txtTipoVenta, Me.Label6, Me.txtCliente, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Line1})
        Me.PageHeader.Height = 1.458333!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 1.443569!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 7.152229!
        '
        'Label16
        '
        Me.Label16.Height = 0.1312336!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.56168!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-size: 8.25pt"
        Me.Label16.Text = "Fecha"
        Me.Label16.Top = 1.246719!
        Me.Label16.Width = 0.5905509!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.968504!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-size: 11.25pt"
        Me.Label1.Text = "Reporte de Ventas por Cliente"
        Me.Label1.Top = 0.0625!
        Me.Label1.Width = 2.362204!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 6.00246!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "text-align: center"
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.0!
        Me.txtFecha.Width = 1.0!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.706037!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Almacen .-"
        Me.Label2.Top = 0.328084!
        Me.Label2.Width = 0.7217847!
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Height = 0.2!
        Me.txtAlmacen.Left = 2.427822!
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Text = "TextBox1"
        Me.txtAlmacen.Top = 0.328084!
        Me.txtAlmacen.Width = 3.608924!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.771653!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "De .-"
        Me.Label3.Top = 0.5905511!
        Me.Label3.Width = 0.3937008!
        '
        'txtFechaDe
        '
        Me.txtFechaDe.Height = 0.2!
        Me.txtFechaDe.Left = 2.165354!
        Me.txtFechaDe.Name = "txtFechaDe"
        Me.txtFechaDe.Text = Nothing
        Me.txtFechaDe.Top = 0.5905511!
        Me.txtFechaDe.Width = 1.0!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 3.215223!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "A .-"
        Me.Label4.Top = 0.5905511!
        Me.Label4.Width = 0.2624671!
        '
        'txtFechaA
        '
        Me.txtFechaA.Height = 0.2!
        Me.txtFechaA.Left = 3.47769!
        Me.txtFechaA.Name = "txtFechaA"
        Me.txtFechaA.Text = Nothing
        Me.txtFechaA.Top = 0.5905511!
        Me.txtFechaA.Width = 1.0!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.7874014!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = ""
        Me.Label5.Text = "Tipo Venta .-"
        Me.Label5.Top = 0.9186354!
        Me.Label5.Width = 0.8530188!
        '
        'txtTipoVenta
        '
        Me.txtTipoVenta.Height = 0.2!
        Me.txtTipoVenta.Left = 1.64042!
        Me.txtTipoVenta.Name = "txtTipoVenta"
        Me.txtTipoVenta.Style = "font-size: 9pt"
        Me.txtTipoVenta.Text = Nothing
        Me.txtTipoVenta.Top = 0.9186354!
        Me.txtTipoVenta.Width = 1.181102!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 2.821522!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = ""
        Me.Label6.Text = "Cliente .-"
        Me.Label6.Top = 0.9186354!
        Me.Label6.Width = 0.5905514!
        '
        'txtCliente
        '
        Me.txtCliente.Height = 0.2!
        Me.txtCliente.Left = 3.412074!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Style = "font-size: 8.25pt"
        Me.txtCliente.Text = "TextBox1"
        Me.txtCliente.Top = 0.9186354!
        Me.txtCliente.Width = 2.887138!
        '
        'Label7
        '
        Me.Label7.Height = 0.1312336!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.7874014!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-size: 8.25pt"
        Me.Label7.Text = "Folio Factura"
        Me.Label7.Top = 1.246719!
        Me.Label7.Width = 0.7217847!
        '
        'Label8
        '
        Me.Label8.Height = 0.1312336!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.533137!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-size: 8.25pt"
        Me.Label8.Text = "Referencia"
        Me.Label8.Top = 1.246719!
        Me.Label8.Width = 0.7217847!
        '
        'Label9
        '
        Me.Label9.Height = 0.1312336!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 2.320538!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-size: 8.25pt"
        Me.Label9.Text = "Caja"
        Me.Label9.Top = 1.246719!
        Me.Label9.Width = 0.328084!
        '
        'Label10
        '
        Me.Label10.Height = 0.1312336!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 2.714239!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; font-size: 8.25pt"
        Me.Label10.Text = "Vendedor"
        Me.Label10.Top = 1.246719!
        Me.Label10.Width = 0.5905511!
        '
        'Label11
        '
        Me.Label11.Height = 0.1312336!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 3.370407!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-size: 8.25pt"
        Me.Label11.Text = "SubTotal"
        Me.Label11.Top = 1.246719!
        Me.Label11.Width = 0.9186354!
        '
        'Label12
        '
        Me.Label12.Height = 0.1312336!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 4.354658!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; font-size: 8.25pt"
        Me.Label12.Text = "IVA"
        Me.Label12.Top = 1.246719!
        Me.Label12.Width = 0.4593182!
        '
        'Label13
        '
        Me.Label13.Height = 0.1312336!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.833825!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: center; font-size: 8.25pt"
        Me.Label13.Text = "Total"
        Me.Label13.Top = 1.246719!
        Me.Label13.Width = 1.03002!
        '
        'Label14
        '
        Me.Label14.Height = 0.1312336!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.927575!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "text-align: center; font-size: 8.25pt"
        Me.Label14.Text = "Desc."
        Me.Label14.Top = 1.246719!
        Me.Label14.Width = 0.6466537!
        '
        'Label15
        '
        Me.Label15.Height = 0.1312336!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.0!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "text-align: center; font-size: 8.25pt"
        Me.Label15.Text = "ID Cliente"
        Me.Label15.Top = 1.246719!
        Me.Label15.Width = 0.7217847!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.246719!
        Me.Line1.Width = 7.152229!
        Me.Line1.X1 = 7.152229!
        Me.Line1.X2 = 0.0!
        Me.Line1.Y1 = 1.246719!
        Me.Line1.Y2 = 1.246719!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPagina, Me.Label17})
        Me.PageFooter.Height = 0.25!
        Me.PageFooter.Name = "PageFooter"
        '
        'txtPagina
        '
        Me.txtPagina.Height = 0.2!
        Me.txtPagina.Left = 6.642061!
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.Style = "text-align: center"
        Me.txtPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPagina.Text = Nothing
        Me.txtPagina.Top = 0.0!
        Me.txtPagina.Width = 0.4593171!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 6.303559!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = ""
        Me.Label17.Text = "Pág."
        Me.Label17.Top = 0.0!
        Me.Label17.Width = 0.3280845!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ClienteID})
        Me.GroupHeader1.DataField = "ClienteID"
        Me.GroupHeader1.Height = 0.15625!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'ClienteID
        '
        Me.ClienteID.DataField = "ClienteID"
        Me.ClienteID.Height = 0.1312336!
        Me.ClienteID.Left = 0.0!
        Me.ClienteID.Name = "ClienteID"
        Me.ClienteID.Style = "text-align: left; font-weight: bold; font-size: 8.25pt"
        Me.ClienteID.Text = "9999999999"
        Me.ClienteID.Top = 0.0!
        Me.ClienteID.Width = 5.183726!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSTotal, Me.txtSDescuento})
        Me.GroupFooter1.Height = 0.1451389!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'txtSTotal
        '
        Me.txtSTotal.DataField = "Total"
        Me.txtSTotal.Height = 0.1312336!
        Me.txtSTotal.Left = 4.75566!
        Me.txtSTotal.Name = "txtSTotal"
        Me.txtSTotal.OutputFormat = resources.GetString("txtSTotal.OutputFormat")
        Me.txtSTotal.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.txtSTotal.SummaryGroup = "GroupHeader1"
        Me.txtSTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtSTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtSTotal.Text = "TextBox1"
        Me.txtSTotal.Top = 0.0!
        Me.txtSTotal.Width = 1.0!
        '
        'txtSDescuento
        '
        Me.txtSDescuento.DataField = "DescTotal"
        Me.txtSDescuento.Height = 0.1312336!
        Me.txtSDescuento.Left = 5.843013!
        Me.txtSDescuento.Name = "txtSDescuento"
        Me.txtSDescuento.OutputFormat = resources.GetString("txtSDescuento.OutputFormat")
        Me.txtSDescuento.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
        Me.txtSDescuento.SummaryGroup = "GroupHeader1"
        Me.txtSDescuento.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtSDescuento.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtSDescuento.Text = "TextBox2"
        Me.txtSDescuento.Top = 0.0!
        Me.txtSDescuento.Width = 0.671916!
        '
        'rptVentasPorCliente
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.7875!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.7875!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.177083!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtFolioFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClienteID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region


End Class
