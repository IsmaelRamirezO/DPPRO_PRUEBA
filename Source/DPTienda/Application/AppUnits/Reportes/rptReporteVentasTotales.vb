Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DpTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Public Class rptReporteVentasTotales
    Inherits DataDynamics.ActiveReports.ActiveReport


    Dim oFacturaMgr As New FacturaManager(oAppContext)
    Dim dtFacturas As DataTable, oSAPMgr As ProcesoSAPManager
    Private WithEvents grupoFolio As DataDynamics.ActiveReports.GroupHeader
    Private WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblFolio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFolioGrupo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTipoReporte As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoReporte As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalFactura As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTotalFactura As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTotalFacturas As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFacturasTotal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents tbFacturaID As DataDynamics.ActiveReports.TextBox

    Public Sub New(ByRef ds As DataSet, ByVal datFechaInicio As Date, ByVal datFechaFin As Date)

        MyBase.New()
        InitializeComponent()


        'Encabezado :
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen, strCentro As String = oSAPMgr.Read_Centros

        oAlmacen = oCatalogoAlmacenMgr.Load(strCentro.Trim) 'oAppContext.ApplicationConfiguration.Almacen)

        Me.LblSucursal.Text = oAlmacen.ID & "     " & oAlmacen.Descripcion

        oCatalogoAlmacenMgr = Nothing
        oAlmacen = Nothing


        Me.LblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        Me.LblCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        Me.LblFechaDE.Text = Format(datFechaInicio, "dd-MM-yyyy")

        Me.LblFechaAL.Text = Format(datFechaFin, "dd-MM-yyyy")



        'Detalle :
        dtFacturas = ds.Tables(0).Copy
        Me.DataSource = ds.Tables(0)


    End Sub


#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private lblReportTitle As Label = Nothing
    Private Label1 As Label = Nothing
    Private LblFecha As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private LblFechaDE As Label = Nothing
    Private LblFechaAL As Label = Nothing
    Private Label4 As Label = Nothing
    Private LblCaja As Label = Nothing
    Private Label5 As Label = Nothing
    Private LblSucursal As Label = Nothing
    Private Label7 As Label = Nothing
    Private lblFieldFolio As Label = Nothing
    Private lblFieldArticulo As Label = Nothing
    Private lblFieldImporte As Label = Nothing
    Private lblFieldDescuento As Label = Nothing
    Private lblFieldFormaPago As Label = Nothing
    Private lblFieldVendedor As Label = Nothing
    Private lblFieldCliente As Label = Nothing
    Private lblFieldTipoVenta As Label = Nothing
    Private lblFieldNCred As Label = Nothing
    Private Label6 As Label = Nothing
    Private Shape4 As Shape = Nothing
    Private tbImporte As TextBox = Nothing
    Private tbdescuento As TextBox = Nothing
    Private tbVendedor As TextBox = Nothing
    Private tbCliente As TextBox = Nothing
    Private tbTipoVenta As TextBox = Nothing
    Private tbNcred As TextBox = Nothing
    Private tbArticulo As TextBox = Nothing
    Private tbFolio As TextBox = Nothing
    Private txtFormasPago As TextBox = Nothing
    Private tbFecha As TextBox = Nothing
    Private txtCodCaja As TextBox = Nothing
    Private txtFolioSAP As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteVentasTotales))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
        Me.tbdescuento = New DataDynamics.ActiveReports.TextBox()
        Me.tbVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
        Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.tbNcred = New DataDynamics.ActiveReports.TextBox()
        Me.tbArticulo = New DataDynamics.ActiveReports.TextBox()
        Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
        Me.txtFormasPago = New DataDynamics.ActiveReports.TextBox()
        Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.LblFecha = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
        Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.LblCaja = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.LblSucursal = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
        Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
        Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
        Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
        Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
        Me.lblFieldCliente = New DataDynamics.ActiveReports.Label()
        Me.lblFieldTipoVenta = New DataDynamics.ActiveReports.Label()
        Me.lblFieldNCred = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Shape4 = New DataDynamics.ActiveReports.Shape()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.grupoFolio = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.lblFolio = New DataDynamics.ActiveReports.Label()
        Me.txtFolioGrupo = New DataDynamics.ActiveReports.TextBox()
        Me.lblTipoReporte = New DataDynamics.ActiveReports.Label()
        Me.txtTipoReporte = New DataDynamics.ActiveReports.TextBox()
        Me.tbFacturaID = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalFactura = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotalFactura = New DataDynamics.ActiveReports.Label()
        Me.lblTotalFacturas = New DataDynamics.ActiveReports.Label()
        Me.txtFacturasTotal = New DataDynamics.ActiveReports.TextBox()
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbdescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNcred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldNCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolioGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFacturaID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFacturasTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbImporte, Me.tbdescuento, Me.tbVendedor, Me.tbCliente, Me.tbTipoVenta, Me.tbNcred, Me.tbArticulo, Me.tbFolio, Me.txtFormasPago, Me.tbFecha, Me.txtCodCaja, Me.txtFolioSAP, Me.tbFacturaID})
        Me.Detail.Height = 0.1979167!
        Me.Detail.Name = "Detail"
        '
        'tbImporte
        '
        Me.tbImporte.DataField = "Total"
        Me.tbImporte.Height = 0.1875!
        Me.tbImporte.Left = 2.5!
        Me.tbImporte.Name = "tbImporte"
        Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
        Me.tbImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.tbImporte.Text = Nothing
        Me.tbImporte.Top = 0.0!
        Me.tbImporte.Width = 0.625!
        '
        'tbdescuento
        '
        Me.tbdescuento.DataField = "Descuento"
        Me.tbdescuento.Height = 0.1875!
        Me.tbdescuento.Left = 3.228346!
        Me.tbdescuento.Name = "tbdescuento"
        Me.tbdescuento.OutputFormat = resources.GetString("tbdescuento.OutputFormat")
        Me.tbdescuento.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.tbdescuento.Text = Nothing
        Me.tbdescuento.Top = 0.0!
        Me.tbdescuento.Width = 0.625!
        '
        'tbVendedor
        '
        Me.tbVendedor.DataField = "Vendedor"
        Me.tbVendedor.Height = 0.1875!
        Me.tbVendedor.Left = 4.719!
        Me.tbVendedor.Name = "tbVendedor"
        Me.tbVendedor.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.tbVendedor.Text = Nothing
        Me.tbVendedor.Top = 0.0!
        Me.tbVendedor.Width = 0.5625!
        '
        'tbCliente
        '
        Me.tbCliente.DataField = "Cliente"
        Me.tbCliente.Height = 0.1875!
        Me.tbCliente.Left = 5.344!
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.tbCliente.Text = Nothing
        Me.tbCliente.Top = 0.0!
        Me.tbCliente.Width = 0.4375!
        '
        'tbTipoVenta
        '
        Me.tbTipoVenta.DataField = "TipoVenta"
        Me.tbTipoVenta.Height = 0.1875!
        Me.tbTipoVenta.Left = 5.969!
        Me.tbTipoVenta.Name = "tbTipoVenta"
        Me.tbTipoVenta.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.tbTipoVenta.Text = Nothing
        Me.tbTipoVenta.Top = 0.0!
        Me.tbTipoVenta.Width = 0.25!
        '
        'tbNcred
        '
        Me.tbNcred.DataField = "Status"
        Me.tbNcred.Height = 0.1875!
        Me.tbNcred.Left = 6.41125!
        Me.tbNcred.Name = "tbNcred"
        Me.tbNcred.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.tbNcred.Text = Nothing
        Me.tbNcred.Top = 0.0!
        Me.tbNcred.Visible = False
        Me.tbNcred.Width = 0.2452502!
        '
        'tbArticulo
        '
        Me.tbArticulo.DataField = "TotalArticulos"
        Me.tbArticulo.Height = 0.1875!
        Me.tbArticulo.Left = 1.924212!
        Me.tbArticulo.Name = "tbArticulo"
        Me.tbArticulo.OutputFormat = resources.GetString("tbArticulo.OutputFormat")
        Me.tbArticulo.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.tbArticulo.Text = Nothing
        Me.tbArticulo.Top = 0.0!
        Me.tbArticulo.Width = 0.3125!
        '
        'tbFolio
        '
        Me.tbFolio.DataField = "Folio"
        Me.tbFolio.Height = 0.1875!
        Me.tbFolio.Left = 0.0!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.tbFolio.Text = Nothing
        Me.tbFolio.Top = 0.0!
        Me.tbFolio.Width = 0.625!
        '
        'txtFormasPago
        '
        Me.txtFormasPago.DataField = "CodFormasPago"
        Me.txtFormasPago.Height = 0.1875!
        Me.txtFormasPago.Left = 3.875!
        Me.txtFormasPago.Name = "txtFormasPago"
        Me.txtFormasPago.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtFormasPago.Top = 0.0!
        Me.txtFormasPago.Visible = False
        Me.txtFormasPago.Width = 0.6980004!
        '
        'tbFecha
        '
        Me.tbFecha.DataField = "Fecha"
        Me.tbFecha.Height = 0.1875!
        Me.tbFecha.Left = 1.299212!
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.OutputFormat = resources.GetString("tbFecha.OutputFormat")
        Me.tbFecha.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.tbFecha.Text = Nothing
        Me.tbFecha.Top = 0.0!
        Me.tbFecha.Width = 0.625!
        '
        'txtCodCaja
        '
        Me.txtCodCaja.DataField = "CodCaja"
        Me.txtCodCaja.Height = 0.03937007!
        Me.txtCodCaja.Left = 1.9375!
        Me.txtCodCaja.Name = "txtCodCaja"
        Me.txtCodCaja.Tag = "No quitar es para jalar el detalle de la factura."
        Me.txtCodCaja.Text = Nothing
        Me.txtCodCaja.Top = 0.09793306!
        Me.txtCodCaja.Visible = False
        Me.txtCodCaja.Width = 0.03937007!
        '
        'txtFolioSAP
        '
        Me.txtFolioSAP.DataField = "Referencia"
        Me.txtFolioSAP.Height = 0.1875!
        Me.txtFolioSAP.Left = 0.6299213!
        Me.txtFolioSAP.Name = "txtFolioSAP"
        Me.txtFolioSAP.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtFolioSAP.Text = Nothing
        Me.txtFolioSAP.Top = 0.0!
        Me.txtFolioSAP.Width = 0.6496062!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.Label1, Me.LblFecha, Me.Label2, Me.Label3, Me.LblFechaDE, Me.LblFechaAL, Me.Label4, Me.LblCaja, Me.Label5, Me.LblSucursal})
        Me.ReportHeader.Height = 0.625!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblReportTitle
        '
        Me.lblReportTitle.ClassName = "Heading1"
        Me.lblReportTitle.Height = 0.1875!
        Me.lblReportTitle.HyperLink = Nothing
        Me.lblReportTitle.Left = 2.625!
        Me.lblReportTitle.MultiLine = False
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; white-space: nowrap; vert" & _
    "ical-align: middle"
        Me.lblReportTitle.Text = "Reporte de Ventas Totales"
        Me.lblReportTitle.Top = 0.0!
        Me.lblReportTitle.Width = 1.758366!
        '
        'Label1
        '
        Me.Label1.Height = 0.1811025!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.125!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label1.Text = "Fecha:"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.5625!
        '
        'LblFecha
        '
        Me.LblFecha.Height = 0.1811025!
        Me.LblFecha.HyperLink = Nothing
        Me.LblFecha.Left = 0.625!
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFecha.Text = "LblFecha"
        Me.LblFecha.Top = 0.0!
        Me.LblFecha.Width = 1.0625!
        '
        'Label2
        '
        Me.Label2.Height = 0.1811025!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 2.25!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label2.Text = "De:"
        Me.Label2.Top = 0.1875!
        Me.Label2.Width = 0.2810042!
        '
        'Label3
        '
        Me.Label3.Height = 0.1811025!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.5625!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label3.Text = "Al:"
        Me.Label3.Top = 0.1875!
        Me.Label3.Width = 0.2810042!
        '
        'LblFechaDE
        '
        Me.LblFechaDE.Height = 0.1811025!
        Me.LblFechaDE.HyperLink = Nothing
        Me.LblFechaDE.Left = 2.5625!
        Me.LblFechaDE.Name = "LblFechaDE"
        Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFechaDE.Text = "LblFechaDE"
        Me.LblFechaDE.Top = 0.1875!
        Me.LblFechaDE.Width = 0.9685042!
        '
        'LblFechaAL
        '
        Me.LblFechaAL.Height = 0.1811025!
        Me.LblFechaAL.HyperLink = Nothing
        Me.LblFechaAL.Left = 3.8125!
        Me.LblFechaAL.Name = "LblFechaAL"
        Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblFechaAL.Text = "LblFechaAL"
        Me.LblFechaAL.Top = 0.1875!
        Me.LblFechaAL.Width = 0.9685042!
        '
        'Label4
        '
        Me.Label4.Height = 0.1811025!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.125!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label4.Text = "Caja:"
        Me.Label4.Top = 0.1875!
        Me.Label4.Width = 0.5625!
        '
        'LblCaja
        '
        Me.LblCaja.Height = 0.1811025!
        Me.LblCaja.HyperLink = Nothing
        Me.LblCaja.Left = 0.6250004!
        Me.LblCaja.Name = "LblCaja"
        Me.LblCaja.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblCaja.Text = "LblCaja"
        Me.LblCaja.Top = 0.1875!
        Me.LblCaja.Width = 0.6983264!
        '
        'Label5
        '
        Me.Label5.Height = 0.1811025!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 1.4375!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.Label5.Text = "Sucursal:"
        Me.Label5.Top = 0.375!
        Me.Label5.Width = 0.5625!
        '
        'LblSucursal
        '
        Me.LblSucursal.Height = 0.1811025!
        Me.LblSucursal.HyperLink = Nothing
        Me.LblSucursal.Left = 2.125001!
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.LblSucursal.Text = "LblSucursal"
        Me.LblSucursal.Top = 0.375!
        Me.LblSucursal.Width = 3.448326!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.1979167!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7, Me.lblFieldFolio, Me.lblFieldArticulo, Me.lblFieldImporte, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldVendedor, Me.lblFieldCliente, Me.lblFieldTipoVenta, Me.lblFieldNCred, Me.Label6, Me.Shape4, Me.lblTipoReporte, Me.txtTipoReporte})
        Me.GroupHeader1.DataField = "TipoReporte"
        Me.GroupHeader1.Height = 0.5001025!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label7
        '
        Me.Label7.Height = 0.181!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.5674213!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.Label7.Text = "Referencia"
        Me.Label7.Top = 0.3189487!
        Me.Label7.Width = 0.6496062!
        '
        'lblFieldFolio
        '
        Me.lblFieldFolio.Height = 0.181!
        Me.lblFieldFolio.HyperLink = Nothing
        Me.lblFieldFolio.Left = 0.0!
        Me.lblFieldFolio.Name = "lblFieldFolio"
        Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblFieldFolio.Text = "Folio"
        Me.lblFieldFolio.Top = 0.319!
        Me.lblFieldFolio.Width = 0.5625!
        '
        'lblFieldArticulo
        '
        Me.lblFieldArticulo.Height = 0.1811025!
        Me.lblFieldArticulo.HyperLink = Nothing
        Me.lblFieldArticulo.Left = 1.84375!
        Me.lblFieldArticulo.Name = "lblFieldArticulo"
        Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldArticulo.Text = "Total Art."
        Me.lblFieldArticulo.Top = 0.3189487!
        Me.lblFieldArticulo.Width = 0.5625!
        '
        'lblFieldImporte
        '
        Me.lblFieldImporte.Height = 0.1811025!
        Me.lblFieldImporte.HyperLink = Nothing
        Me.lblFieldImporte.Left = 2.46875!
        Me.lblFieldImporte.Name = "lblFieldImporte"
        Me.lblFieldImporte.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblFieldImporte.Text = "Importe"
        Me.lblFieldImporte.Top = 0.3189487!
        Me.lblFieldImporte.Width = 0.625!
        '
        'lblFieldDescuento
        '
        Me.lblFieldDescuento.Height = 0.1811025!
        Me.lblFieldDescuento.HyperLink = Nothing
        Me.lblFieldDescuento.Left = 3.15625!
        Me.lblFieldDescuento.Name = "lblFieldDescuento"
        Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldDescuento.Text = "Descuento"
        Me.lblFieldDescuento.Top = 0.3189487!
        Me.lblFieldDescuento.Width = 0.625!
        '
        'lblFieldFormaPago
        '
        Me.lblFieldFormaPago.Height = 0.1811025!
        Me.lblFieldFormaPago.HyperLink = Nothing
        Me.lblFieldFormaPago.Left = 3.875!
        Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
        Me.lblFieldFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldFormaPago.Text = "Forma Pago"
        Me.lblFieldFormaPago.Top = 0.3189487!
        Me.lblFieldFormaPago.Width = 0.75!
        '
        'lblFieldVendedor
        '
        Me.lblFieldVendedor.Height = 0.1811025!
        Me.lblFieldVendedor.HyperLink = Nothing
        Me.lblFieldVendedor.Left = 4.719!
        Me.lblFieldVendedor.Name = "lblFieldVendedor"
        Me.lblFieldVendedor.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldVendedor.Text = "Vendedor"
        Me.lblFieldVendedor.Top = 0.319!
        Me.lblFieldVendedor.Width = 0.5625!
        '
        'lblFieldCliente
        '
        Me.lblFieldCliente.Height = 0.1811025!
        Me.lblFieldCliente.HyperLink = Nothing
        Me.lblFieldCliente.Left = 5.344!
        Me.lblFieldCliente.Name = "lblFieldCliente"
        Me.lblFieldCliente.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldCliente.Text = "Cliente"
        Me.lblFieldCliente.Top = 0.319!
        Me.lblFieldCliente.Width = 0.4375!
        '
        'lblFieldTipoVenta
        '
        Me.lblFieldTipoVenta.Height = 0.1811025!
        Me.lblFieldTipoVenta.HyperLink = Nothing
        Me.lblFieldTipoVenta.Left = 5.7815!
        Me.lblFieldTipoVenta.Name = "lblFieldTipoVenta"
        Me.lblFieldTipoVenta.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldTipoVenta.Text = "Tipo Venta"
        Me.lblFieldTipoVenta.Top = 0.319!
        Me.lblFieldTipoVenta.Width = 0.6178642!
        '
        'lblFieldNCred
        '
        Me.lblFieldNCred.Height = 0.181!
        Me.lblFieldNCred.HyperLink = Nothing
        Me.lblFieldNCred.Left = 6.4065!
        Me.lblFieldNCred.Name = "lblFieldNCred"
        Me.lblFieldNCred.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFieldNCred.Text = "St."
        Me.lblFieldNCred.Top = 0.3190513!
        Me.lblFieldNCred.Visible = False
        Me.lblFieldNCred.Width = 0.21875!
        '
        'Label6
        '
        Me.Label6.Height = 0.181!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.21875!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.Label6.Text = "Fecha"
        Me.Label6.Top = 0.319!
        Me.Label6.Width = 0.625!
        '
        'Shape4
        '
        Me.Shape4.Height = 0.1875!
        Me.Shape4.Left = 0.0!
        Me.Shape4.LineWeight = 2.0!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = 9.999999!
        Me.Shape4.Top = -0.1875!
        Me.Shape4.Width = 7.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTotalFacturas, Me.txtFacturasTotal})
        Me.GroupFooter1.Height = 0.24!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'grupoFolio
        '
        Me.grupoFolio.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFolio, Me.txtFolioGrupo})
        Me.grupoFolio.DataField = "Folio"
        Me.grupoFolio.Height = 0.2083333!
        Me.grupoFolio.Name = "grupoFolio"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalFactura, Me.lblTotalFactura})
        Me.GroupFooter2.Height = 0.1979167!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'lblFolio
        '
        Me.lblFolio.Height = 0.181!
        Me.lblFolio.HyperLink = Nothing
        Me.lblFolio.Left = 0.022!
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.Top = 0.0!
        Me.lblFolio.Width = 0.5625!
        '
        'txtFolioGrupo
        '
        Me.txtFolioGrupo.DataField = "Folio"
        Me.txtFolioGrupo.Height = 0.181!
        Me.txtFolioGrupo.Left = 0.5840001!
        Me.txtFolioGrupo.Name = "txtFolioGrupo"
        Me.txtFolioGrupo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtFolioGrupo.Text = Nothing
        Me.txtFolioGrupo.Top = 0.0!
        Me.txtFolioGrupo.Width = 0.9729999!
        '
        'lblTipoReporte
        '
        Me.lblTipoReporte.Height = 0.181!
        Me.lblTipoReporte.HyperLink = Nothing
        Me.lblTipoReporte.Left = 0.0!
        Me.lblTipoReporte.Name = "lblTipoReporte"
        Me.lblTipoReporte.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblTipoReporte.Text = "Tipo Reporte:"
        Me.lblTipoReporte.Top = 0.03!
        Me.lblTipoReporte.Width = 1.021!
        '
        'txtTipoReporte
        '
        Me.txtTipoReporte.DataField = "TipoReporte"
        Me.txtTipoReporte.Height = 0.181!
        Me.txtTipoReporte.Left = 1.027!
        Me.txtTipoReporte.Name = "txtTipoReporte"
        Me.txtTipoReporte.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtTipoReporte.Text = Nothing
        Me.txtTipoReporte.Top = 0.03!
        Me.txtTipoReporte.Width = 1.473!
        '
        'tbFacturaID
        '
        Me.tbFacturaID.DataField = "Folio"
        Me.tbFacturaID.Height = 0.1875!
        Me.tbFacturaID.Left = 0.0!
        Me.tbFacturaID.Name = "tbFacturaID"
        Me.tbFacturaID.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.tbFacturaID.Text = Nothing
        Me.tbFacturaID.Top = 0.0!
        Me.tbFacturaID.Width = 0.6496062!
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.DataField = "Importe"
        Me.txtTotalFactura.Height = 0.181!
        Me.txtTotalFactura.Left = 5.344!
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtTotalFactura.Text = Nothing
        Me.txtTotalFactura.Top = 0.0!
        Me.txtTotalFactura.Width = 1.473!
        '
        'lblTotalFactura
        '
        Me.lblTotalFactura.Height = 0.181!
        Me.lblTotalFactura.HyperLink = Nothing
        Me.lblTotalFactura.Left = 4.317!
        Me.lblTotalFactura.Name = "lblTotalFactura"
        Me.lblTotalFactura.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblTotalFactura.Text = "Total Factura:"
        Me.lblTotalFactura.Top = 0.0!
        Me.lblTotalFactura.Width = 1.021!
        '
        'lblTotalFacturas
        '
        Me.lblTotalFacturas.Height = 0.181!
        Me.lblTotalFacturas.HyperLink = Nothing
        Me.lblTotalFacturas.Left = 4.317!
        Me.lblTotalFacturas.Name = "lblTotalFacturas"
        Me.lblTotalFacturas.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.lblTotalFacturas.Text = "Total"
        Me.lblTotalFacturas.Top = 0.0!
        Me.lblTotalFacturas.Width = 1.021!
        '
        'txtFacturasTotal
        '
        Me.txtFacturasTotal.DataField = "Importe"
        Me.txtFacturasTotal.Height = 0.181!
        Me.txtFacturasTotal.Left = 5.344!
        Me.txtFacturasTotal.Name = "txtFacturasTotal"
        Me.txtFacturasTotal.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
        Me.txtFacturasTotal.Text = Nothing
        Me.txtFacturasTotal.Top = 0.0!
        Me.txtFacturasTotal.Width = 1.473!
        '
        'rptReporteVentasTotales
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.9840278!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.1965278!
        Me.PageSettings.Margins.Top = 0.1965278!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.385417!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.grupoFolio)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbdescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNcred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldNCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolioGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFacturaID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFacturasTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region



    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

    End Sub

End Class
