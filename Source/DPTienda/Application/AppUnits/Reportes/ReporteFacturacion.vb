Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class ReporteFacturacion
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oFacturaMgr As FacturaManager
    Dim oFactura As Factura

    Dim oFacturaCorridaMgr As FacturaCorridaManager
    Dim oFacturaCorrida As FacturaCorrida

    Dim oClientesMgr As ClientesManager
    Dim oCliente As Clientes

    Dim oAvisosFacturaMgr As AvisosFacturaManager
    Dim oAvisosFactura As AvisosFactura

    Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oReporteAvisosFactura As ReporteAvisosFactura

    Dim oFacturaFormaPago As FacturaFormaPago

    Dim oCatArtMgr As CatalogoArticuloManager

    Dim dsFactura As New DataSet
    Dim dsFormaPago As New DataSet
    Dim dsFormaPago2 As New DataSet
    Dim boolImprimirCedula As Boolean = True
    Dim CodTipoVenta As String = ""

    '------------------------------------------------------------------------------------
    ' JNAVA 23.06.2015: Total de la factura obtenido de la suma del detalle (P/KARUM)
    '------------------------------------------------------------------------------------
    Dim TotalFactura As Decimal = Decimal.Zero




#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private lblQuincenas As TextBox = Nothing
	Private tbNombre As TextBox = Nothing
	Private tbFactura As TextBox = Nothing
	Private tbDomicilio As TextBox = Nothing
	Private tbLugarFecha As TextBox = Nothing
	Private lblLeyendaPago As Label = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private lblCaja As Label = Nothing
	Private lblFactura As Label = Nothing
	Private LblDomTienda As Label = Nothing
	Private LblTelefono As Label = Nothing
	Private LblLocaliz As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label19 As Label = Nothing
	Private LblCopia As Label = Nothing
	Private txtDomTienda As TextBox = Nothing
	Private TxtTienda As TextBox = Nothing
	Private lblCancelacion As Label = Nothing
	Private tbFCancelacion As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label17 As Label = Nothing
	Private txtInfoSuc As TextBox = Nothing
	Private lblFechaReimpresa As Label = Nothing
	Private txtFechaReimpresion As TextBox = Nothing
	Private tbConcepto As TextBox = Nothing
	Private tbPUnitario As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbCodigo As TextBox = Nothing
	Private tbNumero As TextBox = Nothing
	Private tbDesc As TextBox = Nothing
	Private tbTotalConDesc As TextBox = Nothing
	Private Label35 As Label = Nothing
	Private tbCantDesc As TextBox = Nothing
	Private label34 As TextBox = Nothing
	Private lblSerie As TextBox = Nothing
	Private lblIMEI As TextBox = Nothing
	Private tbNumSerie As TextBox = Nothing
	Private tbIMEI As TextBox = Nothing
	Private Label27 As Label = Nothing
	Private Shape2 As Shape = Nothing
	Private Shape1 As Shape = Nothing
	Private Label29 As Label = Nothing
	Private Label25 As Label = Nothing
	Private Label24 As Label = Nothing
	Private Label23 As Label = Nothing
	Private tbSubTotal As TextBox = Nothing
	Private tbPlayer As TextBox = Nothing
	Private SubReport1 As SubReport = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private tbTotalLetras As TextBox = Nothing
	Private Label18 As Label = Nothing
	Private SubReport2 As SubReport = Nothing
	Private TxtBxSubTotSinDescto As TextBox = Nothing
    Private TxtSubTotIva As TextBox = Nothing
	Private Label26 As Label = Nothing
	Private Label28 As Label = Nothing
	Private Label30 As Label = Nothing
	Private Label31 As Label = Nothing
	Private Label32 As Label = Nothing
	Private Label33 As Label = Nothing
	Private Line3 As Line = Nothing
	Private lblNotas As TextBox = Nothing
	Private lblAPagar As Label = Nothing
    Private txtFirma As TextBox = Nothing
    Friend WithEvents txtCodProveedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMarca As DataDynamics.ActiveReports.TextBox
    Private WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents DPTicket As DataDynamics.ActiveReports.RichTextBox
    Friend WithEvents ImgDPTicket As DataDynamics.ActiveReports.Picture
    Friend WithEvents CodeImage As DataDynamics.ActiveReports.Barcode
    Friend WithEvents tbNumcliente As DataDynamics.ActiveReports.TextBox
    Private txtRecibiPor As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteFacturacion))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbConcepto = New DataDynamics.ActiveReports.TextBox()
        Me.tbPUnitario = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumero = New DataDynamics.ActiveReports.TextBox()
        Me.tbDesc = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotalConDesc = New DataDynamics.ActiveReports.TextBox()
        Me.Label35 = New DataDynamics.ActiveReports.Label()
        Me.tbCantDesc = New DataDynamics.ActiveReports.TextBox()
        Me.label34 = New DataDynamics.ActiveReports.TextBox()
        Me.lblSerie = New DataDynamics.ActiveReports.TextBox()
        Me.lblIMEI = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumSerie = New DataDynamics.ActiveReports.TextBox()
        Me.tbIMEI = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodProveedor = New DataDynamics.ActiveReports.TextBox()
        Me.txtMarca = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblQuincenas = New DataDynamics.ActiveReports.TextBox()
        Me.tbNombre = New DataDynamics.ActiveReports.TextBox()
        Me.tbFactura = New DataDynamics.ActiveReports.TextBox()
        Me.tbDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.tbLugarFecha = New DataDynamics.ActiveReports.TextBox()
        Me.lblLeyendaPago = New DataDynamics.ActiveReports.Label()
        Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.lblCaja = New DataDynamics.ActiveReports.Label()
        Me.lblFactura = New DataDynamics.ActiveReports.Label()
        Me.LblDomTienda = New DataDynamics.ActiveReports.Label()
        Me.LblTelefono = New DataDynamics.ActiveReports.Label()
        Me.LblLocaliz = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.LblCopia = New DataDynamics.ActiveReports.Label()
        Me.txtDomTienda = New DataDynamics.ActiveReports.TextBox()
        Me.TxtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblCancelacion = New DataDynamics.ActiveReports.Label()
        Me.tbFCancelacion = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.txtInfoSuc = New DataDynamics.ActiveReports.TextBox()
        Me.lblFechaReimpresa = New DataDynamics.ActiveReports.Label()
        Me.txtFechaReimpresion = New DataDynamics.ActiveReports.TextBox()
        Me.tbNumcliente = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label27 = New DataDynamics.ActiveReports.Label()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label29 = New DataDynamics.ActiveReports.Label()
        Me.Label25 = New DataDynamics.ActiveReports.Label()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.tbSubTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbPlayer = New DataDynamics.ActiveReports.TextBox()
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.tbTotalLetras = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport()
        Me.TxtBxSubTotSinDescto = New DataDynamics.ActiveReports.TextBox()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.TxtSubTotIva = New DataDynamics.ActiveReports.TextBox()
        Me.Label26 = New DataDynamics.ActiveReports.Label()
        Me.Label28 = New DataDynamics.ActiveReports.Label()
        Me.Label30 = New DataDynamics.ActiveReports.Label()
        Me.Label31 = New DataDynamics.ActiveReports.Label()
        Me.Label32 = New DataDynamics.ActiveReports.Label()
        Me.Label33 = New DataDynamics.ActiveReports.Label()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.lblNotas = New DataDynamics.ActiveReports.TextBox()
        Me.lblAPagar = New DataDynamics.ActiveReports.Label()
        Me.txtFirma = New DataDynamics.ActiveReports.TextBox()
        Me.txtRecibiPor = New DataDynamics.ActiveReports.TextBox()
        Me.DPTicket = New DataDynamics.ActiveReports.RichTextBox()
        Me.ImgDPTicket = New DataDynamics.ActiveReports.Picture()
        Me.CodeImage = New DataDynamics.ActiveReports.Barcode()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalConDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIMEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbIMEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQuincenas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaReimpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReimpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNumcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxSubTotSinDescto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRecibiPor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgDPTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbConcepto, Me.tbPUnitario, Me.tbTotal, Me.tbCantidad, Me.tbCodigo, Me.tbNumero, Me.tbDesc, Me.tbTotalConDesc, Me.Label35, Me.tbCantDesc, Me.label34, Me.lblSerie, Me.lblIMEI, Me.tbNumSerie, Me.tbIMEI, Me.txtCodProveedor, Me.txtMarca})
        Me.Detail.Height = 0.8836123!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'tbConcepto
        '
        Me.tbConcepto.Height = 0.2!
        Me.tbConcepto.Left = 0.256!
        Me.tbConcepto.MultiLine = False
        Me.tbConcepto.Name = "tbConcepto"
        Me.tbConcepto.Style = "ddo-char-set: 0; font-size: 6.75pt; font-family: Tahoma"
        Me.tbConcepto.Text = "Concepto"
        Me.tbConcepto.Top = 0.4240001!
        Me.tbConcepto.Width = 1.271!
        '
        'tbPUnitario
        '
        Me.tbPUnitario.Height = 0.2!
        Me.tbPUnitario.Left = 1.551673!
        Me.tbPUnitario.Name = "tbPUnitario"
        Me.tbPUnitario.OutputFormat = resources.GetString("tbPUnitario.OutputFormat")
        Me.tbPUnitario.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbPUnitario.Text = "$5,200.31"
        Me.tbPUnitario.Top = 0.0!
        Me.tbPUnitario.Width = 0.551181!
        '
        'tbTotal
        '
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 2.109744!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotal.Text = "$99,999.00"
        Me.tbTotal.Top = 0.0!
        Me.tbTotal.Width = 0.6102362!
        '
        'tbCantidad
        '
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 0.2559055!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.OutputFormat = resources.GetString("tbCantidad.OutputFormat")
        Me.tbCantidad.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCantidad.Text = "99"
        Me.tbCantidad.Top = 0.0!
        Me.tbCantidad.Visible = False
        Me.tbCantidad.Width = 0.1574803!
        '
        'tbCodigo
        '
        Me.tbCodigo.CanShrink = True
        Me.tbCodigo.Height = 0.2!
        Me.tbCodigo.Left = 0.256!
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCodigo.Text = "000000000000000000"
        Me.tbCodigo.Top = 0.0!
        Me.tbCodigo.Width = 1.27!
        '
        'tbNumero
        '
        Me.tbNumero.Height = 0.2!
        Me.tbNumero.Left = 1.299705!
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNumero.Text = "25.5"
        Me.tbNumero.Top = 0.0!
        Me.tbNumero.Visible = False
        Me.tbNumero.Width = 0.2559055!
        '
        'tbDesc
        '
        Me.tbDesc.CanShrink = True
        Me.tbDesc.Height = 0.2!
        Me.tbDesc.Left = 2.125!
        Me.tbDesc.MultiLine = False
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDesc.Text = "$0.00 -"
        Me.tbDesc.Top = 0.4375001!
        Me.tbDesc.Width = 0.6190944!
        '
        'tbTotalConDesc
        '
        Me.tbTotalConDesc.CanGrow = False
        Me.tbTotalConDesc.Height = 0.1574803!
        Me.tbTotalConDesc.Left = 0.8125!
        Me.tbTotalConDesc.MultiLine = False
        Me.tbTotalConDesc.Name = "tbTotalConDesc"
        Me.tbTotalConDesc.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalConDesc.Text = "$0.00"
        Me.tbTotalConDesc.Top = 1.0625!
        Me.tbTotalConDesc.Width = 0.6889763!
        '
        'Label35
        '
        Me.Label35.Height = 0.1574802!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.3125!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "text-align: left; font-size: 8.25pt; font-family: Tahoma"
        Me.Label35.Text = "TOTAL"
        Me.Label35.Top = 1.069882!
        Me.Label35.Width = 0.4527559!
        '
        'tbCantDesc
        '
        Me.tbCantDesc.CanShrink = True
        Me.tbCantDesc.Height = 0.2!
        Me.tbCantDesc.Left = 2.119095!
        Me.tbCantDesc.MultiLine = False
        Me.tbCantDesc.Name = "tbCantDesc"
        Me.tbCantDesc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCantDesc.Text = "$0.00 -"
        Me.tbCantDesc.Top = 1.0!
        Me.tbCantDesc.Width = 0.61!
        '
        'label34
        '
        Me.label34.CanShrink = True
        Me.label34.Height = 0.2!
        Me.label34.Left = 1.5685!
        Me.label34.Name = "label34"
        Me.label34.Style = "ddo-char-set: 1; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.label34.Text = "AHORRO"
        Me.label34.Top = 0.4240001!
        Me.label34.Width = 0.563!
        '
        'lblSerie
        '
        Me.lblSerie.CanShrink = True
        Me.lblSerie.Height = 0.125!
        Me.lblSerie.Left = 0.25!
        Me.lblSerie.MultiLine = False
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.lblSerie.Text = "NÚM. SERIE"
        Me.lblSerie.Top = 0.6250001!
        Me.lblSerie.Width = 1.0565!
        '
        'lblIMEI
        '
        Me.lblIMEI.CanShrink = True
        Me.lblIMEI.Height = 0.125!
        Me.lblIMEI.Left = 0.25!
        Me.lblIMEI.MultiLine = False
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.lblIMEI.Text = "IMEI"
        Me.lblIMEI.Top = 0.7500001!
        Me.lblIMEI.Width = 1.0565!
        '
        'tbNumSerie
        '
        Me.tbNumSerie.CanShrink = True
        Me.tbNumSerie.Height = 0.125!
        Me.tbNumSerie.Left = 1.3125!
        Me.tbNumSerie.MultiLine = False
        Me.tbNumSerie.Name = "tbNumSerie"
        Me.tbNumSerie.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbNumSerie.Text = Nothing
        Me.tbNumSerie.Top = 0.6250001!
        Me.tbNumSerie.Width = 1.4375!
        '
        'tbIMEI
        '
        Me.tbIMEI.CanShrink = True
        Me.tbIMEI.Height = 0.125!
        Me.tbIMEI.Left = 1.3125!
        Me.tbIMEI.MultiLine = False
        Me.tbIMEI.Name = "tbIMEI"
        Me.tbIMEI.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbIMEI.Text = Nothing
        Me.tbIMEI.Top = 0.7500001!
        Me.tbIMEI.Width = 1.4375!
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.Height = 0.2!
        Me.txtCodProveedor.Left = 0.256!
        Me.txtCodProveedor.MultiLine = False
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.txtCodProveedor.Text = "CodProveedor"
        Me.txtCodProveedor.Top = 0.208!
        Me.txtCodProveedor.Width = 1.271!
        '
        'txtMarca
        '
        Me.txtMarca.Height = 0.2!
        Me.txtMarca.Left = 1.57!
        Me.txtMarca.MultiLine = False
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.txtMarca.Text = "Marca"
        Me.txtMarca.Top = 0.2!
        Me.txtMarca.Width = 1.159!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblQuincenas, Me.tbNombre, Me.tbFactura, Me.tbDomicilio, Me.tbLugarFecha, Me.lblLeyendaPago, Me.tbTipoVenta, Me.lblCaja, Me.lblFactura, Me.LblDomTienda, Me.LblTelefono, Me.LblLocaliz, Me.Label16, Me.Label19, Me.LblCopia, Me.txtDomTienda, Me.TxtTienda, Me.lblCancelacion, Me.tbFCancelacion, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label17, Me.txtInfoSuc, Me.lblFechaReimpresa, Me.txtFechaReimpresion, Me.tbNumcliente})
        Me.ReportHeader.Height = 3.395139!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblQuincenas
        '
        Me.lblQuincenas.Height = 0.15748!
        Me.lblQuincenas.Left = 1.75!
        Me.lblQuincenas.Name = "lblQuincenas"
        Me.lblQuincenas.Style = "ddo-char-set: 1; text-align: right; font-size: 10pt; font-family: Tahoma"
        Me.lblQuincenas.Text = Nothing
        Me.lblQuincenas.Top = 1.953576!
        Me.lblQuincenas.Visible = False
        Me.lblQuincenas.Width = 0.9665347!
        '
        'tbNombre
        '
        Me.tbNombre.Height = 0.1574803!
        Me.tbNombre.Left = 0.2559055!
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.tbNombre.Text = "Nombre"
        Me.tbNombre.Top = 2.35351!
        Me.tbNombre.Width = 2.46063!
        '
        'tbFactura
        '
        Me.tbFactura.Height = 0.1574803!
        Me.tbFactura.Left = 1.64042!
        Me.tbFactura.Name = "tbFactura"
        Me.tbFactura.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 6.75pt; font-f" & _
    "amily: Tahoma"
        Me.tbFactura.Text = "FACT"
        Me.tbFactura.Top = 1.574803!
        Me.tbFactura.Width = 1.076115!
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Height = 0.1574802!
        Me.tbDomicilio.Left = 0.286!
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbDomicilio.Text = "Domicilio"
        Me.tbDomicilio.Top = 2.764!
        Me.tbDomicilio.Width = 2.440945!
        '
        'tbLugarFecha
        '
        Me.tbLugarFecha.Height = 0.158957!
        Me.tbLugarFecha.Left = 0.2559055!
        Me.tbLugarFecha.Name = "tbLugarFecha"
        Me.tbLugarFecha.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbLugarFecha.Text = "Lugar Fecha"
        Me.tbLugarFecha.Top = 2.153543!
        Me.tbLugarFecha.Width = 2.46063!
        '
        'lblLeyendaPago
        '
        Me.lblLeyendaPago.Height = 0.1860237!
        Me.lblLeyendaPago.HyperLink = Nothing
        Me.lblLeyendaPago.Left = 0.223!
        Me.lblLeyendaPago.Name = "lblLeyendaPago"
        Me.lblLeyendaPago.Style = "text-decoration: underline; ddo-char-set: 1; text-align: center; font-weight: nor" & _
    "mal; font-size: 8.25pt; font-family: Tahoma"
        Me.lblLeyendaPago.Text = "_____Pago hecho en una sola exhibición_____"
        Me.lblLeyendaPago.Top = 3.209!
        Me.lblLeyendaPago.Width = 2.440945!
        '
        'tbTipoVenta
        '
        Me.tbTipoVenta.Height = 0.15748!
        Me.tbTipoVenta.Left = 0.2559054!
        Me.tbTipoVenta.Name = "tbTipoVenta"
        Me.tbTipoVenta.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.tbTipoVenta.Text = "TipoVenta"
        Me.tbTipoVenta.Top = 1.953576!
        Me.tbTipoVenta.Width = 1.5625!
        '
        'lblCaja
        '
        Me.lblCaja.Height = 0.1574798!
        Me.lblCaja.HyperLink = Nothing
        Me.lblCaja.Left = 0.2559055!
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Style = "ddo-char-set: 0; font-weight: normal; font-size: 9pt; font-family: Tahoma"
        Me.lblCaja.Text = "CAJA"
        Me.lblCaja.Top = 1.754921!
        Me.lblCaja.Width = 1.25!
        '
        'lblFactura
        '
        Me.lblFactura.Height = 0.1574803!
        Me.lblFactura.HyperLink = Nothing
        Me.lblFactura.Left = 0.2559054!
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Style = "font-size: 9pt; font-family: Tahoma"
        Me.lblFactura.Text = "APLICA A FACTURA: "
        Me.lblFactura.Top = 1.553642!
        Me.lblFactura.Width = 1.318898!
        '
        'LblDomTienda
        '
        Me.LblDomTienda.Height = 0.1574803!
        Me.LblDomTienda.HyperLink = Nothing
        Me.LblDomTienda.Left = 2.75!
        Me.LblDomTienda.Name = "LblDomTienda"
        Me.LblDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblDomTienda.Text = "Direccion"
        Me.LblDomTienda.Top = 1.25!
        Me.LblDomTienda.Visible = False
        Me.LblDomTienda.Width = 2.362204!
        '
        'LblTelefono
        '
        Me.LblTelefono.Height = 0.1574803!
        Me.LblTelefono.HyperLink = Nothing
        Me.LblTelefono.Left = 2.75!
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblTelefono.Text = "Telefono"
        Me.LblTelefono.Top = 1.0!
        Me.LblTelefono.Visible = False
        Me.LblTelefono.Width = 2.362205!
        '
        'LblLocaliz
        '
        Me.LblLocaliz.Height = 0.1574803!
        Me.LblLocaliz.HyperLink = Nothing
        Me.LblLocaliz.Left = 2.75!
        Me.LblLocaliz.Name = "LblLocaliz"
        Me.LblLocaliz.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.LblLocaliz.Text = "Ciudad Estado"
        Me.LblLocaliz.Top = 1.0!
        Me.LblLocaliz.Visible = False
        Me.LblLocaliz.Width = 2.362204!
        '
        'Label16
        '
        Me.Label16.Height = 0.1574803!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.3184055!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label16.Text = "SUCURSAL:"
        Me.Label16.Top = 0.6973423!
        Me.Label16.Width = 2.362205!
        '
        'Label19
        '
        Me.Label19.Height = 0.1574803!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 2.75!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label19.Text = "R.F.C. CDP-950126-9M5"
        Me.Label19.Top = 1.0!
        Me.Label19.Visible = False
        Me.Label19.Width = 2.362204!
        '
        'LblCopia
        '
        Me.LblCopia.Height = 0.1574805!
        Me.LblCopia.HyperLink = Nothing
        Me.LblCopia.Left = 0.3188976!
        Me.LblCopia.Name = "LblCopia"
        Me.LblCopia.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Tahoma; ve" & _
    "rtical-align: top"
        Me.LblCopia.Text = "COPIA DE FACTURA"
        Me.LblCopia.Top = 1.158465!
        Me.LblCopia.Width = 2.362205!
        '
        'txtDomTienda
        '
        Me.txtDomTienda.Height = 0.28!
        Me.txtDomTienda.Left = 2.75!
        Me.txtDomTienda.Name = "txtDomTienda"
        Me.txtDomTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.txtDomTienda.Text = "Direccion"
        Me.txtDomTienda.Top = 1.0!
        Me.txtDomTienda.Visible = False
        Me.txtDomTienda.Width = 2.362205!
        '
        'TxtTienda
        '
        Me.TxtTienda.Height = 0.1574803!
        Me.TxtTienda.Left = 2.75!
        Me.TxtTienda.Name = "TxtTienda"
        Me.TxtTienda.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma; vertical-align: top"
        Me.TxtTienda.Text = "Tienda"
        Me.TxtTienda.Top = 1.0!
        Me.TxtTienda.Visible = False
        Me.TxtTienda.Width = 2.362205!
        '
        'lblCancelacion
        '
        Me.lblCancelacion.Height = 0.1574803!
        Me.lblCancelacion.HyperLink = Nothing
        Me.lblCancelacion.Left = 0.2559054!
        Me.lblCancelacion.Name = "lblCancelacion"
        Me.lblCancelacion.Style = "font-size: 9pt; font-family: Tahoma"
        Me.lblCancelacion.Text = "FOLIO CANCELACION: "
        Me.lblCancelacion.Top = 1.366142!
        Me.lblCancelacion.Width = 1.318898!
        '
        'tbFCancelacion
        '
        Me.tbFCancelacion.Height = 0.1574803!
        Me.tbFCancelacion.Left = 1.64042!
        Me.tbFCancelacion.Name = "tbFCancelacion"
        Me.tbFCancelacion.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.tbFCancelacion.Text = "FACT"
        Me.tbFCancelacion.Top = 1.377953!
        Me.tbFCancelacion.Width = 1.049869!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574803!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.1875!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label8.Text = "COMERCIAL D'PORTENIS, S.A. DE C.V."
        Me.Label8.Top = 0.1241471!
        Me.Label8.Width = 2.60187!
        '
        'Label9
        '
        Me.Label9.Height = 0.2183727!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.3809055!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label9.Text = "Matriz: Melchor Ocampo #1005 Centro"
        Me.Label9.Top = 0.2816273!
        Me.Label9.Width = 2.283465!
        '
        'Label10
        '
        Me.Label10.Height = 0.1437008!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 2.630905!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label10.Text = "C.P. 82000 TEL. 6699155300"
        Me.Label10.Top = 0.6753281!
        Me.Label10.Width = 2.283465!
        '
        'Label11
        '
        Me.Label11.Height = 0.1437008!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 2.630905!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label11.Text = "R.F.C. CDP-950126-9M5"
        Me.Label11.Top = 0.8190285!
        Me.Label11.Width = 2.283465!
        '
        'Label12
        '
        Me.Label12.Height = 0.1437008!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.3809055!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label12.Text = "Mazatlán, Sin."
        Me.Label12.Top = 0.4627299!
        Me.Label12.Width = 2.283465!
        '
        'Label17
        '
        Me.Label17.Height = 0.1574803!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 0.3809055!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.Label17.Text = "MATRIZ:"
        Me.Label17.Top = -0.0333333!
        Me.Label17.Width = 2.283465!
        '
        'txtInfoSuc
        '
        Me.txtInfoSuc.Height = 0.1875!
        Me.txtInfoSuc.Left = 0.3125!
        Me.txtInfoSuc.Name = "txtInfoSuc"
        Me.txtInfoSuc.Style = "text-align: center; font-size: 8.25pt"
        Me.txtInfoSuc.Text = "InfoSuc"
        Me.txtInfoSuc.Top = 0.875!
        Me.txtInfoSuc.Width = 2.362!
        '
        'lblFechaReimpresa
        '
        Me.lblFechaReimpresa.Height = 0.1574803!
        Me.lblFechaReimpresa.HyperLink = Nothing
        Me.lblFechaReimpresa.Left = 0.2559999!
        Me.lblFechaReimpresa.Name = "lblFechaReimpresa"
        Me.lblFechaReimpresa.Style = "font-size: 9pt; font-family: Tahoma"
        Me.lblFechaReimpresa.Text = "REIMPRESA:"
        Me.lblFechaReimpresa.Top = 2.951665!
        Me.lblFechaReimpresa.Visible = False
        Me.lblFechaReimpresa.Width = 1.318898!
        '
        'txtFechaReimpresion
        '
        Me.txtFechaReimpresion.Height = 0.158957!
        Me.txtFechaReimpresion.Left = 1.062595!
        Me.txtFechaReimpresion.Name = "txtFechaReimpresion"
        Me.txtFechaReimpresion.Style = "ddo-char-set: 0; font-size: 9pt; font-family: Tahoma"
        Me.txtFechaReimpresion.Text = "Fecha Reimpresión"
        Me.txtFechaReimpresion.Top = 2.962523!
        Me.txtFechaReimpresion.Visible = False
        Me.txtFechaReimpresion.Width = 1.625!
        '
        'tbNumcliente
        '
        Me.tbNumcliente.Height = 0.1574803!
        Me.tbNumcliente.Left = 0.263!
        Me.tbNumcliente.Name = "tbNumcliente"
        Me.tbNumcliente.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.tbNumcliente.Text = "NumeroCliente"
        Me.tbNumcliente.Top = 2.551!
        Me.tbNumcliente.Visible = False
        Me.tbNumcliente.Width = 2.46063!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label27, Me.Shape2, Me.Shape1, Me.Label29, Me.Label25, Me.Label24, Me.Label23, Me.tbSubTotal, Me.tbPlayer, Me.SubReport1, Me.Label1, Me.Label2, Me.tbTotalLetras, Me.Label18, Me.SubReport2, Me.TxtBxSubTotSinDescto, Me.Label20, Me.TxtSubTotIva, Me.Label26, Me.Label28, Me.Label30, Me.Label31, Me.Label32, Me.Label33, Me.Line3, Me.lblNotas, Me.lblAPagar, Me.txtFirma, Me.txtRecibiPor, Me.DPTicket, Me.ImgDPTicket, Me.CodeImage})
        Me.ReportFooter.Height = 7.458333!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label27
        '
        Me.Label27.Height = 0.3937008!
        Me.Label27.HyperLink = Nothing
        Me.Label27.Left = 0.3149605!
        Me.Label27.Name = "Label27"
        Me.Label27.Style = "font-weight: bold; font-size: 12pt; font-family: Arial"
        Me.Label27.Text = "S H C P"
        Me.Label27.Top = 1.813484!
        Me.Label27.Width = 0.3937007!
        '
        'Shape2
        '
        Me.Shape2.Height = 0.3937007!
        Me.Shape2.Left = 0.2952755!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 1.81496!
        Me.Shape2.Width = 0.3937007!
        '
        'Shape1
        '
        Me.Shape1.Height = 2.480315!
        Me.Shape1.Left = 0.2952755!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 1.813484!
        Me.Shape1.Width = 1.417323!
        '
        'Label29
        '
        Me.Label29.Height = 0.3149607!
        Me.Label29.HyperLink = Nothing
        Me.Label29.Left = 0.2362203!
        Me.Label29.Name = "Label29"
        Me.Label29.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label29.Text = "SUBSECRETARIA DE INGRESOS"
        Me.Label29.Top = 2.804626!
        Me.Label29.Width = 1.496063!
        '
        'Label25
        '
        Me.Label25.Height = 0.1574802!
        Me.Label25.HyperLink = Nothing
        Me.Label25.Left = 0.7391729!
        Me.Label25.Name = "Label25"
        Me.Label25.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label25.Text = "C4907687"
        Me.Label25.Top = 2.144685!
        Me.Label25.Width = 0.7874014!
        '
        'Label24
        '
        Me.Label24.Height = 0.1574807!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.7386813!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label24.Text = "D1559715"
        Me.Label24.Top = 1.987204!
        Me.Label24.Width = 0.7874014!
        '
        'Label23
        '
        Me.Label23.Height = 0.1574798!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.7386813!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label23.Text = "FOLIO"
        Me.Label23.Top = 1.829724!
        Me.Label23.Width = 0.7874014!
        '
        'tbSubTotal
        '
        Me.tbSubTotal.Height = 0.178642!
        Me.tbSubTotal.Left = 1.75!
        Me.tbSubTotal.Name = "tbSubTotal"
        Me.tbSubTotal.OutputFormat = resources.GetString("tbSubTotal.OutputFormat")
        Me.tbSubTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbSubTotal.Text = Nothing
        Me.tbSubTotal.Top = 0.3125!
        Me.tbSubTotal.Width = 0.944382!
        '
        'tbPlayer
        '
        Me.tbPlayer.Height = 0.2!
        Me.tbPlayer.Left = 0.9330708!
        Me.tbPlayer.Name = "tbPlayer"
        Me.tbPlayer.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
    "amily: Tahoma"
        Me.tbPlayer.Text = Nothing
        Me.tbPlayer.Top = 0.7810042!
        Me.tbPlayer.Width = 0.5625!
        '
        'SubReport1
        '
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.6924215!
        Me.SubReport1.Left = 0.8125!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.Top = 1.0!
        Me.SubReport1.Width = 1.6875!
        '
        'Label1
        '
        Me.Label1.Height = 0.1786415!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.2559055!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label1.Text = "PLAYER:"
        Me.Label1.Top = 0.7819882!
        Me.Label1.Width = 0.5!
        '
        'Label2
        '
        Me.Label2.Height = 0.1412403!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.3622047!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "PAGO:"
        Me.Label2.Top = 1.017224!
        Me.Label2.Width = 0.3937007!
        '
        'tbTotalLetras
        '
        Me.tbTotalLetras.Height = 0.2!
        Me.tbTotalLetras.Left = 0.2559055!
        Me.tbTotalLetras.Name = "tbTotalLetras"
        Me.tbTotalLetras.Style = "font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalLetras.Text = Nothing
        Me.tbTotalLetras.Top = 0.534941!
        Me.tbTotalLetras.Width = 2.440945!
        '
        'Label18
        '
        Me.Label18.Height = 0.9286423!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 1.732283!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label18.Text = "CONTRIBUYENTE AUTORIZADO A IMPRIMIR SUS PROPIOS COM- PROBANTES FISCALES"
        Me.Label18.Top = 3.309547!
        Me.Label18.Width = 1.023622!
        '
        'SubReport2
        '
        Me.SubReport2.CanGrow = False
        Me.SubReport2.CanShrink = False
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.3897638!
        Me.SubReport2.Left = 0.2662401!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.Top = 1.367126!
        Me.SubReport2.Visible = False
        Me.SubReport2.Width = 0.3149605!
        '
        'TxtBxSubTotSinDescto
        '
        Me.TxtBxSubTotSinDescto.DataField = "TOTAL"
        Me.TxtBxSubTotSinDescto.Height = 0.1574803!
        Me.TxtBxSubTotSinDescto.Left = 1.732783!
        Me.TxtBxSubTotSinDescto.Name = "TxtBxSubTotSinDescto"
        Me.TxtBxSubTotSinDescto.OutputFormat = resources.GetString("TxtBxSubTotSinDescto.OutputFormat")
        Me.TxtBxSubTotSinDescto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.TxtBxSubTotSinDescto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TxtBxSubTotSinDescto.Text = Nothing
        Me.TxtBxSubTotSinDescto.Top = 0.05610216!
        Me.TxtBxSubTotSinDescto.Width = 0.944882!
        '
        'Label20
        '
        Me.Label20.Height = 0.1574802!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.3149606!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.Label20.Text = "SUBTOTAL SIN DESC.:"
        Me.Label20.Top = 0.05610216!
        Me.Label20.Width = 1.338583!
        '
        'TxtSubTotIva
        '
        Me.TxtSubTotIva.Height = 0.1574802!
        Me.TxtSubTotIva.Left = 0.3149606!
        Me.TxtSubTotIva.Name = "TxtSubTotIva"
        Me.TxtSubTotIva.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.TxtSubTotIva.Text = Nothing
        Me.TxtSubTotIva.Top = 0.3061024!
        Me.TxtSubTotIva.Width = 1.338583!
        '
        'Label26
        '
        Me.Label26.Height = 1.259842!
        Me.Label26.HyperLink = Nothing
        Me.Label26.Left = 1.732283!
        Me.Label26.Name = "Label26"
        Me.Label26.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Tahoma"
        Me.Label26.Text = "LA REPRODUCION NO AUTORIZADA DE ESTE COMPRO- BANTE CONSTITU- YE UN DELITO EN LOS " & _
    "TERMINOS DE LAS DISPOSICIO- NES FISCALES"
        Me.Label26.Top = 1.813484!
        Me.Label26.Width = 1.023622!
        '
        'Label28
        '
        Me.Label28.Height = 0.4724407!
        Me.Label28.HyperLink = Nothing
        Me.Label28.Left = 0.3149605!
        Me.Label28.Name = "Label28"
        Me.Label28.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label28.Text = "SECRETARIA DE HACIENDA Y CREDITO PUBLICO"
        Me.Label28.Top = 2.31496!
        Me.Label28.Width = 1.377953!
        '
        'Label30
        '
        Me.Label30.Height = 0.3149607!
        Me.Label30.HyperLink = Nothing
        Me.Label30.Left = 0.2362203!
        Me.Label30.Name = "Label30"
        Me.Label30.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label30.Text = "CEDULA DE IDEN- TIFICACION FISCAL"
        Me.Label30.Top = 3.119587!
        Me.Label30.Width = 1.496063!
        '
        'Label31
        '
        Me.Label31.Height = 0.1437008!
        Me.Label31.HyperLink = Nothing
        Me.Label31.Left = 0.2362203!
        Me.Label31.Name = "Label31"
        Me.Label31.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label31.Text = "CDP-950126-9M5"
        Me.Label31.Top = 3.434547!
        Me.Label31.Width = 1.496063!
        '
        'Label32
        '
        Me.Label32.Height = 0.314961!
        Me.Label32.HyperLink = Nothing
        Me.Label32.Left = 0.3149605!
        Me.Label32.Name = "Label32"
        Me.Label32.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label32.Text = "COMERCIAL D PORTENIS, S.A. DE C.V."
        Me.Label32.Top = 3.592028!
        Me.Label32.Width = 1.417323!
        '
        'Label33
        '
        Me.Label33.Height = 0.3149605!
        Me.Label33.HyperLink = Nothing
        Me.Label33.Left = 0.472441!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "text-align: center; font-size: 9pt; font-family: Tahoma"
        Me.Label33.Text = "22/03/95 vhjm8hjL2H"
        Me.Label33.Top = 3.939469!
        Me.Label33.Width = 1.023622!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.243165!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0231846!
        Me.Line3.Width = 2.362!
        Me.Line3.X1 = 0.243165!
        Me.Line3.X2 = 2.605165!
        Me.Line3.Y1 = 0.0231846!
        Me.Line3.Y2 = 0.0231846!
        '
        'lblNotas
        '
        Me.lblNotas.Height = 0.1574803!
        Me.lblNotas.Left = 0.25!
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Style = "ddo-char-set: 0; text-align: justify; font-weight: normal; font-size: 9pt; font-f" & _
    "amily: Tahoma"
        Me.lblNotas.Text = Nothing
        Me.lblNotas.Top = 5.363!
        Me.lblNotas.Width = 2.362369!
        '
        'lblAPagar
        '
        Me.lblAPagar.Height = 0.4330709!
        Me.lblAPagar.HyperLink = Nothing
        Me.lblAPagar.Left = 0.2654202!
        Me.lblAPagar.Name = "lblAPagar"
        Me.lblAPagar.Style = "ddo-char-set: 1; text-align: justify; font-weight: bold; font-size: 8.25pt; font-" & _
    "family: Tahoma"
        Me.lblAPagar.Text = ""
        Me.lblAPagar.Top = 4.846949!
        Me.lblAPagar.Width = 2.362369!
        '
        'txtFirma
        '
        Me.txtFirma.Height = 0.1875!
        Me.txtFirma.Left = 0.25!
        Me.txtFirma.Name = "txtFirma"
        Me.txtFirma.Style = "font-size: 9pt; font-family: Tahoma"
        Me.txtFirma.Text = "FIRMA_________________"
        Me.txtFirma.Top = 4.4375!
        Me.txtFirma.Width = 2.0!
        '
        'txtRecibiPor
        '
        Me.txtRecibiPor.Height = 0.1875!
        Me.txtRecibiPor.Left = 0.6875!
        Me.txtRecibiPor.Name = "txtRecibiPor"
        Me.txtRecibiPor.Style = "font-size: 9pt; font-family: Tahoma"
        Me.txtRecibiPor.Text = "Recibi Por"
        Me.txtRecibiPor.Top = 4.625!
        Me.txtRecibiPor.Visible = False
        Me.txtRecibiPor.Width = 1.1875!
        '
        'DPTicket
        '
        Me.DPTicket.AutoReplaceFields = True
        Me.DPTicket.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.DPTicket.Height = 0.9271666!
        Me.DPTicket.Left = 0.206!
        Me.DPTicket.Name = "DPTicket"
        Me.DPTicket.RTF = resources.GetString("DPTicket.RTF")
        Me.DPTicket.Top = 5.330501!
        Me.DPTicket.Visible = False
        Me.DPTicket.Width = 2.425!
        '
        'ImgDPTicket
        '
        Me.ImgDPTicket.Height = 0.9585833!
        Me.ImgDPTicket.ImageData = Nothing
        Me.ImgDPTicket.Left = 0.206!
        Me.ImgDPTicket.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ImgDPTicket.LineWeight = 0.0!
        Me.ImgDPTicket.Name = "ImgDPTicket"
        Me.ImgDPTicket.Top = 6.3295!
        Me.ImgDPTicket.Visible = False
        Me.ImgDPTicket.Width = 2.4375!
        '
        'CodeImage
        '
        Me.CodeImage.Font = New System.Drawing.Font("Courier New", 8.0!)
        Me.CodeImage.Height = 0.187!
        Me.CodeImage.Left = 0.229!
        Me.CodeImage.Name = "CodeImage"
        Me.CodeImage.Text = "Barcode1"
        Me.CodeImage.Top = 6.3295!
        Me.CodeImage.Visible = False
        Me.CodeImage.Width = 2.414!
        '
        'PageHeader
        '
        Me.PageHeader.CanShrink = True
        Me.PageHeader.Height = 0.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'ReporteFacturacion
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.69028!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Custom paper"
        Me.PageSettings.PaperWidth = 2.979861!
        Me.PrintWidth = 2.8125!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalConDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.label34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIMEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbIMEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQuincenas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLugarFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLeyendaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLocaliz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblCopia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInfoSuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaReimpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReimpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNumcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxSubTotSinDescto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSubTotIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRecibiPor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgDPTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub InicializaObjetos()

        oFacturaMgr = New FacturaManager(oAppContext)
        oFactura = oFacturaMgr.Create

        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaCorrida = oFacturaCorridaMgr.Create

        oClientesMgr = New ClientesManager(oAppContext)
        oCliente = oClientesMgr.Create

        oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
        oAvisosFactura = oAvisosFacturaMgr.Create

        oFacturaFormaPago = New FacturaFormaPago(oAppContext)

        oCatArtMgr = New CatalogoArticuloManager(oAppContext)

    End Sub
    'Tipo Fact  
    'COPIA FACTURA
    'string.empty --->Factura Normal
    'CANCELACIÓN DE FACTURA
    Public Sub New(ByVal oDataRpt As rptFacturaInfo, ByVal DatosGenerales As DataTable, ByVal TipoFact As String, ByVal ImprimirCedula As Boolean, _
    Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, Optional ByVal bReimpresion As Boolean = False, Optional ByVal ImporteSeguro As Decimal = 0, Optional ByVal DPTicket As Dictionary(Of String, Object) = Nothing, Optional ByVal FechaPrimerPago As DateTime = Nothing)

        MyBase.New()
        InitializeComponent()
        InicializaObjetos()
        oFactura.ClearFields()
        Dim dtDetalle As DataTable

        If TipoFact = "CANCELACIÓN DE FACTURA" Then
            TipoFact = "CANCELACIÓN DE NOTA DE VENTA"
            lblCancelacion.Visible = True
            Me.tbFCancelacion.Visible = True
            Me.lblFactura.Text = "APLICA A NOTA DE VENTA:"
        Else
            If TipoFact = "FACTURA" Then
                TipoFact = "NOTA DE VENTA"
            ElseIf TipoFact = "COPIA DE FACTURA" Then
                TipoFact = "COPIA DE NOTA DE VENTA"
            End If
            lblCancelacion.Visible = False
            Me.tbFCancelacion.Visible = False
            Me.lblFactura.Text = "FOLIO:"
        End If
        oFacturaMgr.LoadInto(oDataRpt.FacturaID, oFactura)
        oFactura.Detalle = oFacturaCorridaMgr.Load(oDataRpt.FacturaID)

        'Me.DataSource = oFactura.Detalle
        'Me.DataMember = "FacturaDetalle"
        Dim dtTemp As DataTable

        dtDetalle = FormatearTablaDetalle().Clone
        'Me.DataSource = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
        dtTemp = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
        Me.DataSource = SepararArticulos(dtTemp).Copy
        Me.tbCantidad.DataField = "Cantidad"
        Me.txtCodProveedor.DataField = "CodArtProv"
        Me.txtMarca.DataField = "Marca"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "PrecioOferta"
        Me.tbTotal.DataField = "Total"
        Me.tbFCancelacion.Text = oFactura.FCancelacionSD
        Me.tbDesc.DataField = "Descuento"

        '--------------------------------------------------------------------
        'JNAVA (07.12.2014): Datafield de Electronicos
        '--------------------------------------------------------------------
        Me.tbNumSerie.DataField = "NumeroSerie"
        Me.tbIMEI.DataField = "IMEI"
        '--------------------------------------------------------------------

        boolImprimirCedula = ImprimirCedula

        If TipoLeyenda <> "" Then
            If TipoLeyenda = "FACTURA" Then
                TipoLeyenda = "NOTA DE VENTA"
            ElseIf TipoLeyenda = "COPIA DE FACTURA" Then
                TipoLeyenda = "COPIA DE NOTA DE VENTA"
            End If
            LblCopia.Text = TipoLeyenda
        Else
            LblCopia.Text = TipoFact
        End If


        If oFactura.Referencia = "" Then
            tbFactura.Text = CStr(DatosGenerales.Rows(0).Item("FolioFactura")).PadLeft(10, "0")
            LblCopia.Text = "NOTA DE VENTA"
        Else
            tbFactura.Text = oFactura.Referencia
        End If

        lblCaja.Text = "CAJA :" & oFactura.CodCaja

        tbTipoVenta.Text = DatosGenerales.Rows(0).Item("TipoVenta")
        tbNombre.Text = DatosGenerales.Rows(0).Item("NombreCliente")

        If oFactura.CodTipoVenta = "D" Then
            Me.tbNumcliente.Visible = True
            Me.tbNumcliente.Text = "(" & DatosGenerales.Rows(0).Item("ClienteID") & ")"
        End If

        'se asignas las quincenas del vale
        If oFactura.CodTipoVenta = "V" Then
            Me.txtFirma.Visible = True
            Me.lblQuincenas.Visible = True
            Me.lblAPagar.Visible = True
            Me.lblQuincenas.Text = strQuin & " QUINCENAS"
            Me.lblLeyendaPago.Text = "________Pago hecho en parcialidades______"

            dsFormaPago2 = oFacturaFormaPago.Load(oDataRpt.FacturaID)
            If dsFormaPago2.Tables(0).Rows.Count > 0 Then
                Dim oDataView As New DataView(dsFormaPago2.Tables(0), "CodFormasPago = 'DPVL'", "CodFormasPago", DataViewRowState.CurrentRows)

                If oDataView.Count > 0 Then
                    'Total a pagar en quincenas
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 19/12/2014: Se modifico la leyenda del ticket por temas fiscales con SAP solicitado en mail del 19/12/2014 de Leticia Linn
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (19/12/2014): Se mnodificaron los pagos quincenales para sumar el importe del Seguro en las ventas de DPVale
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'Me.lblAPagar.Text = "Usted pagará la cantidad de " _
                    If Me.lblCancelacion.Visible = False Then
                        Me.lblAPagar.Text = "PAGOS QUINCENALES DE " _
                                            & CStr(Format(((CDbl(oDataView(0)("MontoPago")) + ImporteSeguro) / CInt(strQuin)), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                        '& CStr(Format(Format(CDbl(oDataView(0)("MontoPago")), "$#,##0.00") / CInt(strQuin), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                    Else
                        Me.lblAPagar.Text = ""
                    End If
                Else
                    Me.lblAPagar.Text = ""
                End If
                If FechaPrimerPago <> Nothing Then
                    lblAPagar.Text &= vbCrLf & "EMPIEZA A PAGAR EL: " & FechaPrimerPago.ToString("dd/MM/yyyy")
                End If
            Else
                Me.txtFirma.Visible = False
                Me.lblAPagar.Text = ""
            End If


        Else
            Me.txtFirma.Visible = False
            Me.lblQuincenas.Visible = False
            Me.lblAPagar.Visible = False
        End If

        '**************************************************************
        Dim strdt As String = String.Empty
        tbDomicilio.Text = String.Empty
        '------------------------DOMICILIO
        strdt = Trim(DatosGenerales.Rows(0).Item("Domicilio"))
        If strdt <> String.Empty Then
            tbDomicilio.Text = strdt & vbNewLine
        End If
        '------------------------CIUDAD ESTADO
        strdt = Trim(DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado"))
        If strdt <> String.Empty Then
            If oFactura.CodTipoVenta = "P" Then
                tbDomicilio.Text = tbDomicilio.Text & strdt
            Else
                tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            End If
        End If
        '------------------------RFC
        strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC")))
        If strdt <> String.Empty Then
            tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
        End If
        '------------------------TELEFONO
        strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono")))
        If strdt <> String.Empty Then
            tbDomicilio.Text = tbDomicilio.Text & strdt
        End If
        '**************************************************************
        strdt = String.Empty
        '----------------------------FACILITO - TEXTO LETRA
        If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
            strdt = Trim(DatosGenerales.Rows(0).Item("AutorizacionFacilito")) & vbNewLine & vbNewLine
        End If

        If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
            strdt = strdt & Trim(DatosGenerales.Rows(0).Item("LeyendaPago")) & vbNewLine & vbNewLine
        End If
        '----------------------------FACILITO - TEXTO LETRA
        ' Autorizacion Facilito + Leyenda de Pago + Cantidad Con Letra 
        tbTotalLetras.Text = strdt & DatosGenerales.Rows(0).Item("CantidadTexto")

        'Cantidad total de piezas
        Me.tbSubTotal.Text = CInt(oFactura.Detalle.Tables(0).Compute("SUM(Cantidad)", "")) & vbNewLine
        Me.TxtSubTotIva.Text = "Total Piezas".ToUpper & vbNewLine
        '*******************************************************************
        '------------------------------DESC. APLICADO:
        If DatosGenerales.Rows(0).Item("Descuento") <> 0 Then
            ' If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
            ' tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1), "Currency") & vbNewLine
            'Else
            '--------------------------------------------------------------------------------------------------------
            ' JNAVA 23.07.2015: se agrego un salto de linea para diferencia lo que tiene IVA de lo que no
            '--------------------------------------------------------------------------------------------------------
            tbSubTotal.Text &= Format(DatosGenerales.Rows(0).Item("Descuento"), "Currency") & vbNewLine & vbNewLine
            ' End If
            'TxtSubTotIva.Text = "DESC. APLICADO:" & vbNewLine
            TxtSubTotIva.Text &= "USTED AHORRO:" & vbNewLine & vbNewLine
            '--------------------------------------------------------------------------------------------------------
        Else
            Label20.Text = String.Empty
            TxtBxSubTotSinDescto.Text = String.Empty
            TxtBxSubTotSinDescto.Visible = False
            Label20.Visible = False
        End If
        '------------------------------DESC. APLICADO:
        '----------------------------SUBTOTAL      
        If DatosGenerales.Rows(0).Item("Subtotal") <> 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDbl(DatosGenerales.Rows(0).Item("Subtotal")), "$#,##0.00") & vbNewLine
            If DatosGenerales.Rows(0).Item("Descuento") <> 0 Then
                TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
            Else
                TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
            End If
        End If
        '----------------------------SUBTOTAL
        '----------------------------IVA
        If DatosGenerales.Rows(0).Item("Iva") <> 0 Then
            tbSubTotal.Text = tbSubTotal.Text & Format(CDbl(DatosGenerales.Rows(0).Item("IVA")), "$#,##0.00") & vbNewLine
            TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
        End If
        '----------------------------IVA
        '----------------------------TOTAL
        '--------------------------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: Truncamos el total de la factura para eliminar centavos de mas y lo ponemos el total
        '--------------------------------------------------------------------------------------------------------
        'TotalFactura -= DatosGenerales.Rows(0).Item("Descuento")
        'tbSubTotal.Text = tbSubTotal.Text & Format(TotalFactura, "$#,##0.00")
        tbSubTotal.Text = tbSubTotal.Text & Format(CDec(DatosGenerales.Rows(0).Item("Total")), "$#,##0.00")
        '--------------------------------------------------------------------------------------------------------
        TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
        '----------------------------TOTAL
        '*******************************************************************

        'Vendedor
        tbPlayer.Text = DatosGenerales.Rows(0).Item("CodVendedor")

        '------------------------SUCURSAL
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        Me.TxtTienda.Text = oAlmacen.Descripcion
        Me.txtDomTienda.Text = oAlmacen.DireccionCalle
        Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
        Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oCatalogoAlmacenesMgr = Nothing
        'tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))
        '----------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 21.02.2014: Se le agrego la hora a la fecha que se imprime en la nota de venta
        '----------------------------------------------------------------------------------------------------------------------------------------------
        tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & Format(oFactura.Fecha, "dd-MMM-yyyy hh:mm tt").ToUpper
        If bReimpresion Then
            Me.txtFechaReimpresion.Text = Format(Now, "dd-MMM-yy hh:mm tt").ToUpper
            Me.txtFechaReimpresion.Visible = True
            Me.lblFechaReimpresa.Visible = True
        End If
        oAlmacen = Nothing
        Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbLf & Me.txtDomTienda.Text & vbLf & Me.LblTelefono.Text & vbLf & _
                             Me.Label19.Text & vbLf & Me.LblLocaliz.Text


        '-------------------------SUCURSAL

        If oConfigCierreFI.HabilitarDPTicket = False Then
            'Notas
            Dim pdsAvisos As New DataSet
            oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
            pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)

            '---------------------------------------------------------------------------------------
            'JNAVA (07.12.2014): Modificaciones para Venta de Electronicos
            '---------------------------------------------------------------------------------------
            'Revisamos si son puros electronicos en la factura y si hay articulos telcel
            Dim bSoloTelcel As Boolean = False
            Dim bTelcel As Boolean = False

            'Revisamos si hay articulos telcel
            HayTelcel(oFactura.Detalle.Tables(0), bTelcel, bSoloTelcel)
            If pdsAvisos.Tables(0).Rows.Count > 0 Then
                For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
                    If bSoloTelcel = False And bTelcel = True Then
                        'Se agregan todas las leyendas
                        lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                    ElseIf bSoloTelcel = True Then
                        'Solo se agrega la nota 7
                        If oRow.Item("Telcel") = "1" Then
                            lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                        End If
                    ElseIf bTelcel = False Then
                        'no se Agrega la nota 7
                        If oRow.Item("Telcel") <> "1" Then
                            lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                        End If
                    End If
                Next
            End If
        Else
            Me.lblNotas.Visible = False
            If Not DPTicket Is Nothing Then
                '-----------------------------------------------------------------------------------
                'FLIZARRAGA 08/05/2017: Se agrega el html de DPTicket
                '-----------------------------------------------------------------------------------
                If DPTicket.Count > 0 Then
                    Try
                        If DPTicket.ContainsKey("html") Then Me.DPTicket.Html = CStr(DPTicket("html"))
                        If DPTicket.ContainsKey("tipoimagen") Then
                            Select Case CStr(DPTicket("tipoimagen")).ToUpper()
                                Case "CB"
                                    Me.CodeImage.Text = CStr(DPTicket("valorimagen"))
                                    Me.CodeImage.Style = BarCodeStyle.Ansi39
                                    Me.CodeImage.Location = New PointF(0.011, 8.031)
                                    Me.CodeImage.Size = New SizeF(2.414, 0.187)
                                    Me.DPTicket.Visible = True
                                    Me.CodeImage.Visible = True
                                    Me.ImgDPTicket.Visible = False
                                Case "QR"
                                    Me.CodeImage.Text = CStr(DPTicket("valorimagen"))
                                    Me.CodeImage.Style = BarCodeStyle.QRCode
                                    Me.CodeImage.Location = New PointF(0.827, 7.959)
                                    Me.CodeImage.Size = New SizeF(0.542, 0.542)
                                    Me.DPTicket.Visible = True
                                    Me.CodeImage.Visible = True
                                    Me.ImgDPTicket.Visible = False
                                Case "IMAGEN"
                                    Me.CodeImage.Visible = False
                                    Me.DPTicket.Visible = True
                                    Me.ImgDPTicket.Visible = True
                                    Me.ImgDPTicket.Image = DecodificarImagen(CStr(DPTicket("valorimagen")))
                                Case Else
                                    Me.DPTicket.Visible = False
                                    Me.CodeImage.Visible = False
                                    Me.ImgDPTicket.Visible = False
                            End Select
                        End If
                    Catch ex As Exception
                        EscribeLog(ex.Message, "Error al imprimir DPTicket")
                    End Try
                End If
            End If
        End If

        '---------------------------------------------------------------------------------------
        'Notas


        '        lblNotas.Text &= vbCrLf & "Póliza de Garantía DP" & vbCrLf & vbCrLf & _
        '"Comercial Dportenis, S.A de C.V, otorga la presente póliza a favor de sus consumidores, con respecto a todos los artículos que  comercializa, salvo en los casos en que el productor, importador, distribuidor o algún tercero asuma la obligación de garantizar el producto por escrito." & vbCrLf & vbCrLf & _
        '"El cliente tiene 30 días para cambios y devoluciones, y 60 días por defecto de fabricación en el área de ropa, calzado, relojería y lentes." & vbCrLf & vbCrLf & _
        '"*En el caso de relojería y lentes, si el defecto de fabricación se presenta posterior a la fecha señalada en el párrafo anterior, enviar directamente con el fabricante atendiendo las condiciones que establece este en la garantía por escrito que se encuentra dentro de la caja del producto." & vbCrLf & vbCrLf & _
        '"*La garantía no aplica si los datos y/o especificaciones del producto adquirido, no corresponden  a este documento y asimismo, tampoco si el artículo ha sufrido daños causados por el uso inapropiado, alteraciones o fallas, provocadas por descuido u omisión del consumidor." & vbCrLf & vbCrLf & _
        '"Aviso      de       Privacidad " & vbCrLf & vbCrLf & _
        '"Grupo DP1 con domicilio en Melchor Ocampo #1005 Col. Centro, C.P. 82000. Mazatlán, Sinaloa, México, utilizará sus datos personales para alguna(s) de las finalidades siguientes: Fines mercadológicos y de publicidad.- contactar a los usuarios para promociones, ofertas, preventas e información especializada de productos; Prospección comercial.- otorgamiento de crédito; Necesarios.- registro y ventas de productos a través del sitio web, envío de facturas y cobranza de las mismas, contacto y atención al cliente, envío de información necesaria para el cliente, establecimiento de forma y tiempo de pago, contacto para cotizaciones, presupuestos, envío de estados de cuenta, localización en caso de ser necesario, movimientos ante IMSS, INFONAVIT e INFONACOT, reclutamiento, selección y contratación, pago de nómina y pago de finiquitos. Si usted no está de acuerdo con alguna de las finalidades aquí descritas, por favor utilice el mecanismo descrito en el aviso integral, de lo contrario se entiende que nos otorga su consentimiento. Para mayor información acerca del tratamiento y de los derechos que puede hacer valer, usted puede acceder al aviso de privacidad integral ingresando a nuestro sitio web en: http://www.dportenis.com en el apartado Aviso de Privacidad." & vbCrLf & vbCrLf & _
        '"1Comercial Dportenis, S.A. de C.V., Distribuciones Deportivas, S.A. de C.V., Dpservicios, S.C., Enlace Arrendadora, S.A. de C.V., Futuro ABC, S.A. de C.V., SOFOM ENR, Mas Diferente, S.A. de C.V., Negocios Integrales de México, S.A. de C.V., Sistema de Administración y Mercadeo en Punto de Venta, S.A. de C.V., Aspiración DP, SAPI de C.V."

        '        Me.lblNotas.Text &= vbCrLf & "AVISO DE PRIVACIDAD" & vbCrLf & vbCrLf & _
        '"GRUPO DP1 con domicilio en Melchor Ocampo #1005, Col. Centro, C.P. Mazatlán, Sinaloa, México, C.P. 82000; utilizará sus datos personales para alguna(s) de las finalidades siguientes: Fines mercadológicos y de publicidad.- contactar a los usuarios para promociones, ofertas, preventas e información especializada de productos; Prospección comercial.- otorgamiento de crédito. Para mayor información acerca del tratamiento y de los derechos que puede hacer valer, acceda al aviso de privacidad integral en nuestro sitio web www.dportenis.com, en el apartado Aviso de Privacidad." & vbCrLf & vbCrLf & _
        '"1 Comercial Dportenis, S.A. de C.V., Distribuciones Deportivas, S.A. de C.V., Dpservicios, S.C., Enlace Arrendadora, S.A. de C.V., Futuro ABC, S.A. de C.V SOFOM ENR., Mas Diferente, S.A. de C.V., Negocios Integrales de México, S.A. de C.V., Sistema de Administración, Mercadeo en Punto de Venta, S.A. de C.V., Aspiración DP, SAPI de C.V."

        oReporteFormapago = New ReporteDetalleFormasPago(oFactura.FacturaID) 'oDataRpt.FacturaID
        Me.SubReport1.Report = oReporteFormapago
        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember

        oReporteAvisosFactura = New ReporteAvisosFactura(oDataRpt.ModuloID, oDataRpt.Disponible)
        Me.SubReport2.Report = oReporteAvisosFactura
        Me.SubReport2.Report.DataSource = oReporteAvisosFactura.DataSource
        Me.SubReport2.Report.DataMember = oReporteAvisosFactura.DataMember
        Me.CodTipoVenta = oFactura.CodTipoVenta
        Me.Run()

    End Sub

    '-------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/07/2017: Decodifica la imagen de codebase64 a Image
    '-------------------------------------------------------------------------------------------

    Private Function DecodificarImagen(ByVal Imagen As String) As Image

        ' Preparamos la firma y obtenemos los datos 
        '-----------------------------------------------------------------------------------
        Dim img As System.Drawing.Image
        Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
        If Not Imagen Is String.Empty Then
            Dim b() As Byte
            '-----------------------------------------------------------------------------------
            ' Convertirmos la codificacion de base64 a imagen
            '-----------------------------------------------------------------------------------
            b = Convert.FromBase64String(Imagen)
            MS = New System.IO.MemoryStream(b)

            '-----------------------------------------------------------------------------------
            ' Creamos la imagen
            '-----------------------------------------------------------------------------------
            img = System.Drawing.Image.FromStream(MS)
        End If
        Return img
    End Function

    Private Function SepararArticulos(ByVal dt As DataTable, Optional ByVal EsSiHay As Boolean = False) As DataTable

        Dim newDT As DataTable = dt.Clone
        Dim NumSerie() As String
        Dim IMEI() As String

        For Each oRow As DataRow In dt.Rows

            Dim i As Integer

            For i = 1 To CInt(oRow!Cantidad)

                '-------------------------------------------------------------------------------------
                'JNAVA (07.12.2014): Separamos Numero de Serie e IMEI de Electronicos solo cuando no es del si hay
                '-------------------------------------------------------------------------------------
                If Not EsSiHay Then
                    If CStr(oRow!NumeroSerie).Trim <> "" Then
                        NumSerie = CStr(oRow!NumeroSerie).Split(";")
                    End If
                    If CStr(oRow!IMEI).Trim <> "" Then
                        IMEI = CStr(oRow!IMEI).Split(";")
                    End If
                End If
                '-----------------------------------------------------------------------

                Dim oNewRow As DataRow = newDT.NewRow

                With oNewRow
                    !Cantidad = 1
                    !CodArticulo = oRow!CodArticulo
                    !CodArtProv = oRow!CodArtProv
                    !Marca = oRow!Marca
                    !Descripcion = oRow!Descripcion
                    !Numero = oRow!Numero
                    !PrecioOferta = oRow!PrecioOferta
                    !Descuento = CDec(oRow!Descuento) / CInt(oRow!Cantidad)
                    !Total = oRow!PrecioOferta
                    '-------------------------------------------------------------------------------------
                    'JNAVA (22.12.2014): Separamos Numero de Serie e IMEI de Electronicos solo cuando no es del si hay
                    '-------------------------------------------------------------------------------------
                    If Not EsSiHay Then
                        If CStr(oRow!NumeroSerie).Trim <> "" Then
                            !NumeroSerie = NumSerie(i - 1)
                        End If
                        If CStr(oRow!IMEI).Trim <> "" Then
                            !IMEI = IMEI(i - 1)
                        End If
                    End If
                End With

                newDT.Rows.Add(oNewRow)

            Next i

        Next

        newDT.AcceptChanges()

        Return newDT

    End Function

    Private Function FormatearTablaDetalle() As DataTable

        Dim dt As New DataTable("Detalle")

        dt.Columns.Add("Cantidad")
        dt.Columns.Add("CodArticulo")
        dt.Columns.Add("CodArtProv", GetType(String))
        dt.Columns.Add("Marca", GetType(String))
        dt.Columns.Add("Descripcion")
        dt.Columns.Add("Numero")
        dt.Columns.Add("PrecioOferta")
        dt.Columns.Add("Descuento")
        dt.Columns.Add("Total")
        '-------------------------------------------------------------
        'JNAVA (07.12.2014): SEagregaron datos de Electornicos
        '-------------------------------------------------------------
        dt.Columns.Add("NumeroSerie")
        dt.Columns.Add("IMEI")

        dt.AcceptChanges()

        Return dt

    End Function

    Private Function LlenarTablaDetalle(ByVal dtFacturaDetalle As DataTable, ByVal dtDetalle As DataTable, Optional ByVal EsSiHay As Boolean = False) As DataTable

        Dim dtTemp As DataTable
        Dim oArticulo As Articulo
        Dim BrandMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.CatalogoMarcasManager(oAppContext)
        Dim Brand As DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.Marca = BrandMgr.Create()

        dtTemp = dtDetalle.Clone

        '--------------------------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: limpiamos el total de la factura
        '--------------------------------------------------------------------------------------------------------
        TotalFactura = Decimal.Zero

        oArticulo = oCatArtMgr.Create

        If Not dtFacturaDetalle Is Nothing Then

            For Each oRow As DataRow In dtFacturaDetalle.Rows

                Dim oNewRow As DataRow = dtTemp.NewRow
                With oNewRow
                    !Cantidad = oRow!Cantidad
                    !CodArticulo = oRow!CodArticulo
                    !Descripcion = oRow!Descripcion
                    !Numero = oRow!Numero
                    '--------------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 25.05.2015: Se modifico el precio unitario para que tome el precio despues de iva que se descarga de SAP en la impresion del ticket
                    '                     Por el problema con la PROFECO reportado en mail de Nayeli del 25/05/2015
                    '--------------------------------------------------------------------------------------------------------------------------------------------
                    oArticulo.ClearFields()
                    oCatArtMgr.LoadInto(oRow!CodArticulo, oArticulo)
                    Brand = BrandMgr.Load(oArticulo.CodMarca)
                    !CodArtProv = oArticulo.CodArtProv
                    !Marca = Brand.Descripcion
                    If oArticulo.Exist = True Then
                        If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "V" OrElse oFactura.CodTipoVenta = "E" _
                        OrElse (InStr("D,S", oFactura.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
                            !PrecioOferta = oArticulo.PrecioIva
                        Else
                            !PrecioOferta = oRow!Preciooferta 'oArticulo.PrecioOferta
                        End If
                        '!Total = oArticulo.PrecioIva * oRow!Cantidad
                        !Total = !PrecioOferta * oRow!Cantidad
                    Else
                        EscribeLog("Articulo: " & oRow!Codarticulo & " no existe en catalogo de articulos", "No existe en Catalogo de Articulo")
                        !PrecioOferta = oRow!Preciooferta
                        !Total = oRow!Total
                    End If
                    !Descuento = CDec(oRow!CantDescuentoSistema) + ((CDec(oRow!Total) - CDec(oRow!CantDescuentoSistema)) * (CDec(oRow!Descuento) / 100))
                    '-------------------------------------------------------------------------------------
                    'JNAVA (07.12.2014): Se agregaron datos de Electornicos solo cuando no es del si hay
                    '-------------------------------------------------------------------------------------
                    If Not EsSiHay Then
                        !NumeroSerie = oRow!NumeroSerie
                        !IMEI = oRow!IMEI
                    End If

                    '--------------------------------------------------------------------------------------------------------
                    ' JNAVA 24.06.2015: Sumamos el total de la factura en base al detalle
                    '--------------------------------------------------------------------------------------------------------
                    TotalFactura += !Total

                End With
                dtTemp.Rows.Add(oNewRow)

            Next

        End If

        '--------------------------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: Truncamos el total de la factura para eliminar centavos de mas y lo ponemos el total
        '--------------------------------------------------------------------------------------------------------
        TotalFactura = Truncar(TotalFactura, 2)

        Return dtTemp

    End Function

    Dim intIndex As Integer = 0
    Dim bAnterior As Boolean
    Dim x As Double = 0.001
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        intIndex += 1

        If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
        OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 27.05.2015: Se comentaron estas 2 lineas porque ahora se imprime en el ticket el precio del articulo con IVA que se descarga
            '                     desde SAP y ya no se calcula
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Me.tbPUnitario.Value = Decimal.Round(CDbl(Me.tbPUnitario.Text) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            Me.tbPUnitario.Text = Format(Me.tbPUnitario.Value, "Currency")

            Me.tbTotal.Value = CInt(tbCantidad.Text) * CDbl(tbPUnitario.Text)
            Me.tbTotal.Text = Format(Me.tbTotal.Value, "Currency")

            '-----------------------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (25.06.2015): Se elimino redondeo por problemas con centavos y se trunco
            '-----------------------------------------------------------------------------------------------------------------------------------------
            Me.tbDesc.Value = CDbl(Me.tbDesc.Text) * (1 + oAppContext.ApplicationConfiguration.IVA) 'Correccion por cambio Faamework (JNAVA - 06/11/2015)
            Me.tbDesc.Value = Decimal.Round(Me.tbDesc.Value, 2)
            'Me.tbDesc.Value = Truncar(CDbl(Me.tbDesc.Text) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            '-----------------------------------------------------------------------------------------------------------------------------------------
            Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency")
            'Me.tbDesc.Text = Format((CDbl(Me.tbDesc.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")

            'If DirectCast(Detail.Controls("tbDesc"), TextBox).Value = 0 Then
            '    DirectCast(Detail.Controls("label34"), TextBox).Height = 0
            '    DirectCast(Detail.Controls("tbCantDesc"), TextBox).Height = 0
            '    DirectCast(Detail.Controls("tbDesc"), TextBox).Height = 0
            '    bAnterior = False
            'Else
            '    bAnterior = True
            'End If

            'If intIndex > 1 AndAlso Not bAnterior Then
            '    Me.tbPUnitario.Top = Me.tbPUnitario.Top - 0.135
            '    Me.tbConcepto.Top = Me.tbConcepto.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
            '    Me.tbNumero.Top = Me.tbNumero.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
            '    Me.tbTotal.Top = Me.tbTotal.Top - 0.135 '(0.13 + ((intIndex - 1) * 0.001)) + x
            '    x += 0.002
            '    'bAnterior = True
            'End If

            '    If DirectCast(Detail.Controls("tbDesc"), TextBox).Value = 0 Then
            '        '    Me.tbConcepto.Text &= vbCrLf & "AHORRO: " & Me.tbDesc.Text
            '        '    Me.tbTotal.Text &= vbCrLf & Me.tbCantDesc.Text
            '        'Me.Label34.Visible = False
            '        'Me.tbDesc.Visible = False
            '        'Me.tbCantDesc.Visible = False
            '        'DirectCast(Detail.Controls("tbTotal"), TextBox)

            '        DirectCast(Detail.Controls("label34"), TextBox).Text = ""
            '        DirectCast(Detail.Controls("tbCantDesc"), TextBox).Text = ""
            '        DirectCast(Detail.Controls("tbDesc"), TextBox).Text = ""


            '    'Me.label34.Text = ""
            '    'Me.tbDesc.Text = ""
            '    ' Me.tbCantDesc.Text = ""
            'End If
        End If
        If DirectCast(Detail.Controls("tbDesc"), TextBox).Value > 0 Then
            'Me.tbDesc.Text = Format(Me.tbDesc.Value, "Currency") & " -"
            DirectCast(Detail.Controls("label34"), TextBox).Text = "AHORRO"
            'DirectCast(Detail.Controls("label34"), TextBox).Text.re
            DirectCast(Detail.Controls("tbDesc"), TextBox).Text = Format(DirectCast(Detail.Controls("tbDesc"), TextBox).Value, "Currency") & " -"
            DirectCast(Detail.Controls("tbCantDesc"), TextBox).Text = DirectCast(Detail.Controls("tbDesc"), TextBox).Text
            DirectCast(Detail.Controls("tbTotalConDesc"), TextBox).Text = Format(DirectCast(Detail.Controls("tbTotal"), TextBox).Value - DirectCast(Detail.Controls("tbDesc"), TextBox).Value, "Currency")
            If InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs Then
                DirectCast(Detail.Controls("tbTotal"), TextBox).Text = DirectCast(Detail.Controls("tbTotalConDesc"), TextBox).Text
            End If
            DirectCast(Detail.Controls("label34"), TextBox).Visible = True
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = True
            'Me.tbTotalConDesc.Text = Format((CDbl(Me.tbTotal.Text) - CDbl(Me.tbDesc.Text)), "Currency")
            'Me.tbCantDesc.Text = Me.tbDesc.Text '& " -"
            'Me.label34.Text = "AHORRO"
        Else
            DirectCast(Detail.Controls("label34"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = False
        End If
        '---------------------------------------------------------------------------------------
        'JNAVA (07.12.2014): Venta de electornicos - No mostrar ahorro y mostar IMEI y/o Serie
        '---------------------------------------------------------------------------------------
        If Me.tbNumSerie.Text <> "" Then

            'Quitamos el ahorro
            DirectCast(Detail.Controls("label34"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbDesc"), TextBox).Visible = False

            'Ponemos el numero de serie 
            DirectCast(Detail.Controls("lblSerie"), TextBox).Visible = True
            DirectCast(Detail.Controls("tbNumSerie"), TextBox).Visible = True

            'Revisamos si debemos quitar el IMEI
            If Me.tbIMEI.Text = "" Then
                DirectCast(Detail.Controls("lblIMEI"), TextBox).Visible = False
                DirectCast(Detail.Controls("tbIMEI"), TextBox).Visible = False
            Else
                DirectCast(Detail.Controls("lblIMEI"), TextBox).Visible = True
                DirectCast(Detail.Controls("tbIMEI"), TextBox).Visible = True
            End If

        Else

            'quitamos el Numero de serie e imei
            DirectCast(Detail.Controls("lblSerie"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbNumSerie"), TextBox).Visible = False
            DirectCast(Detail.Controls("lblIMEI"), TextBox).Visible = False
            DirectCast(Detail.Controls("tbIMEI"), TextBox).Visible = False

        End If
        '---------------------------------------------------------------------------------------


    End Sub

    Private Sub ReportFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter.BeforePrint
        If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
        OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 27.05.2015: Se comentó esta linea porque ahora se imprime en el ticket el precio del articulo con IVA que se descarga
            '                     desde SAP y ya no se calcula
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Me.TxtBxSubTotSinDescto.Value = Decimal.Round(CDbl(Me.TxtBxSubTotSinDescto.Text) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            Me.TxtBxSubTotSinDescto.Text = Format(Me.TxtBxSubTotSinDescto.Value, "Currency")

            'Me.TxtBxSubTotSinDescto.Text = Format((CDbl(Me.TxtBxSubTotSinDescto.Text) * (1 + oAppContext.ApplicationConfiguration.IVA)), "Currency")
        End If
    End Sub

    Private Sub ReporteFacturacion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        If Me.boolImprimirCedula = False Then

            'Movemos hacia la derecha los datos generales 
            Me.Label17.Left = 3.5
            'Me.Label8.Left = 3.5
            'Me.Label9.Left = 3.5
            Me.Label10.Left = 3.5
            Me.Label11.Left = 3.5
            'Me.Label12.Left = 3.5

            'Ponemos invisibles los datos generales
            Me.Label17.Visible = False
            'Me.Label8.Visible = False  'Razon Social
            'Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            'Me.Label12.Visible = False

            'Ya no movemos dinamicamente el header
            'Subimos los controles del page header
            'Me.Label8.Top = 0.01
            'Me.Label16.Top = 0.167

            'Me.txtInfoSuc.Top = 0.333

            ''Me.TxtTienda.Top = 0.167
            ''Me.txtDomTienda.Top = 0.325
            '''Me.LblTelefono.Top = 0.482
            ''Me.LblTelefono.Top = 0.61
            '''Me.Label19.Top = 0.64
            ''Me.Label19.Top = 0.768
            ''Me.LblLocaliz.Top = 0.926
            ''Me.LblDomTienda.Top = 0.955

            ''Me.LblCopia.Top = 1.2
            'Me.LblCopia.Top = 0.566
            ''Me.lblCancelacion.Top = 1.304
            ''Me.lblCancelacion.Top = 0.604
            'Me.lblCancelacion.Top = 0.791
            ''Me.tbFCancelacion.Top = 0.615
            'Me.tbFCancelacion.Top = 0.791
            ''Me.lblFactura.Top = 0.791
            ''Me.tbFactura.Top = 0.812
            'Me.lblFactura.Top = 0.978
            'Me.tbFactura.Top = 0.978
            ''Me.lblCaja.Top = 0.992
            'Me.lblCaja.Top = 1.179
            ''Me.tbTipoVenta.Top = 1.191
            'Me.tbTipoVenta.Top = 1.378
            'Me.lblQuincenas.Top = Me.tbTipoVenta.Top
            ''Me.tbLugarFecha.Top = 1.391
            'Me.tbLugarFecha.Top = 1.578
            ''Me.tbNombre.Top = 1.591
            'Me.tbNombre.Top = 1.778
            ''Me.tbDomicilio.Top = 1.791
            'Me.tbDomicilio.Top = 1.978
            ''Me.lblFechaReimpresa.Top = 2.028
            ''Me.txtFechaReimpresion.Top = 2.028
            'Me.lblFechaReimpresa.Top = 2.178
            'Me.txtFechaReimpresion.Top = 2.178
            ''Me.lblLeyendaPago.Top = 2.265
            'Me.lblLeyendaPago.Top = 2.415
            ''Me.ReportHeader.Height = 2.2
            'Me.ReportHeader.Height = 2.587

            'Movemos los datos fiscales hacia la derecha
            Me.Label26.Left = 5.17
            Me.Label18.Left = 5.17
            Me.Shape2.Left = 3.733
            Me.Shape1.Left = 3.733
            Me.Label27.Left = 3.733
            Me.Label23.Left = 4.176
            Me.Label24.Left = 4.176
            Me.Label25.Left = 4.177
            Me.Label28.Left = 3.752
            Me.Label29.Left = 3.674
            Me.Label30.Left = 3.674
            Me.Label31.Left = 3.674
            Me.Label32.Left = 3.752
            Me.Label33.Left = 3.91

            'Ponemos invisibles los datos fiscales
            Me.Label26.Visible = False
            Me.Label18.Visible = False
            Me.Shape2.Visible = False
            Me.Shape1.Visible = False
            Me.Label27.Visible = False
            Me.Label23.Visible = False
            Me.Label24.Visible = False
            Me.Label25.Visible = False
            Me.Label28.Visible = False
            Me.Label29.Visible = False
            Me.Label30.Visible = False
            Me.Label31.Visible = False
            Me.Label32.Visible = False
            Me.Label33.Visible = False

            'Subo el total a pagar quincenalmente
            If txtRecibiPor.Visible = True Then
                txtFirma.Top = 1.878
                txtRecibiPor.Top = 2.068
                Me.lblAPagar.Top = 2.268
                'Subo las notas
                If Me.lblAPagar.Visible = True Then
                    Me.lblNotas.Top = Me.lblAPagar.Top + 0.6
                Else
                    Me.lblNotas.Top = 2.268
                End If
                'Seteo el alto del ReporteFooter
                Me.ReportFooter.Height = 3.4
            Else
                txtFirma.Top = 1.878

                Me.lblAPagar.Top = 2.068
                'Subo las notas
                If Me.lblAPagar.Visible = True Then
                    Me.lblNotas.Top = Me.lblAPagar.Top + 0.6
                Else
                    Me.lblNotas.Top = 2.068
                End If
                'Seteo el alto del ReporteFooter
                Me.ReportFooter.Height = 3.2
            End If

        End If
    End Sub

#Region "Facturacion SiHay"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2013: Nuevo constructor para la impresion de Facturación SiHay
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub New(ByVal oDataRpt As rptFacturaInfo, ByVal DatosGenerales As DataTable, ByVal opcion As Boolean, _
    ByVal TipoFact As String, ByVal ImprimirCedula As Boolean, _
    Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, Optional ByVal bReimpresion As Boolean = False, _
    Optional ByVal FactSiHay As Boolean = False, Optional ByVal ImporteSeguro As Decimal = 0, Optional ByVal DPTicket As Dictionary(Of String, Object) = Nothing, Optional ByVal FechaPrimerPago As DateTime = Nothing)

        MyBase.New()
        InitializeComponent()
        InicializaObjetos()
        Try
1:          oFactura.ClearFields()

            Dim detallesFactura As DataTable = Nothing
            If TipoFact = "CANCELACIÓN DE FACTURA" Then
                TipoFact = "CANCELACIÓN DE NOTA DE VENTA"
                lblCancelacion.Visible = True
                Me.tbFCancelacion.Visible = True
                Me.lblFactura.Text = "APLICA A NOTA DE VENTA:"
            Else
                If TipoFact = "FACTURA" Then
                    TipoFact = "NOTA DE VENTA"
                ElseIf TipoFact = "COPIA DE FACTURA" Then
                    TipoFact = "COPIA DE NOTA DE VENTA"
                ElseIf TipoFact = "PENDIENTE" Then
                    TipoFact = "PENDIENTE POR ENTREGAR"
                ElseIf TipoFact = "COPIA PENDIENTE" Then
                    TipoFact = "COPIA PENDIENTE POR ENTREGAR"
                End If
                lblCancelacion.Visible = False
                Me.tbFCancelacion.Visible = False
                Me.lblFactura.Text = "FOLIO:"
            End If
2:          oFacturaMgr.LoadInto(oDataRpt.FacturaID, oFactura)
3:          oFactura.Detalle = oFacturaCorridaMgr.Load(oDataRpt.FacturaID)

            'Me.DataSource = oFactura.Detalle
            'Me.DataMember = "FacturaDetalle"
            Dim dtTemp As DataTable

4:          Dim dtDetalle As DataTable = FormatearTablaDetalle().Clone
5:          dtTemp = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
            'dtTemp = LlenarTablaDetalle(dtDetallesArticulos, dtDetalle).Copy
6:          Me.DataSource = SepararArticulos(dtTemp).Copy
            Me.tbCantidad.DataField = "Cantidad"
            Me.tbCodigo.DataField = "CodArticulo"
            Me.txtCodProveedor.DataField = "CodArtProv"
            Me.txtMarca.DataField = "Marca"
            Me.tbConcepto.DataField = "Descripcion"
            Me.tbNumero.DataField = "Numero"
            Me.tbPUnitario.DataField = "PrecioOferta"
            Me.tbTotal.DataField = "Total"
            Me.tbFCancelacion.Text = oFactura.FCancelacionSD
            Me.tbDesc.DataField = "Descuento"


7:          boolImprimirCedula = ImprimirCedula

8:          If TipoLeyenda <> "" Then
                If TipoLeyenda = "FACTURA" Then
                    TipoLeyenda = "NOTA DE VENTA"
                ElseIf TipoLeyenda = "COPIA DE FACTURA" Then
                    TipoLeyenda = "COPIA DE NOTA DE VENTA"
                End If
                LblCopia.Text = TipoLeyenda
            Else
9:              LblCopia.Text = TipoFact
            End If


10:         If oFactura.Referencia = "" Then
11:             tbFactura.Text = CStr(DatosGenerales.Rows(0).Item("FolioFactura")).PadLeft(10, "0")
12:             LblCopia.Text = "NOTA DE VENTA"
            Else
13:             tbFactura.Text = oFactura.Referencia
            End If

14:         lblCaja.Text = "CAJA :" & oFactura.CodCaja

15:         tbTipoVenta.Text = DatosGenerales.Rows(0).Item("TipoVenta")
16:         tbNombre.Text = DatosGenerales.Rows(0).Item("NombreCliente")
            If oFactura.CodTipoVenta = "D" Then
                Me.tbNumcliente.Visible = True
                Me.tbNumcliente.Text = "(" & DatosGenerales.Rows(0).Item("ClienteID") & ")"
            End If

            'se asignas las quincenas del vale
17:         If oFactura.CodTipoVenta = "V" Then
                Me.txtFirma.Visible = True
                Me.lblQuincenas.Visible = True
                Me.lblAPagar.Visible = True
18:             Me.lblQuincenas.Text = strQuin & " QUINCENAS"
19:             Me.lblLeyendaPago.Text = "________Pago hecho en parcialidades______"

20:             dsFormaPago2 = oFacturaFormaPago.Load(oDataRpt.FacturaID)
21:             If dsFormaPago2.Tables(0).Rows.Count > 0 Then
22:                 Dim oDataView As New DataView(dsFormaPago2.Tables(0), "CodFormasPago = 'DPVL'", "CodFormasPago", DataViewRowState.CurrentRows)

23:                 If oDataView.Count > 0 Then
                        'Total a pagar en quincenas
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 19/12/2014: Se modifico la leyenda del ticket por temas fiscales con SAP solicitado en mail del 19/12/2014 de Leticia Linn
                        '-------------------------------------------------------------------------------------------------------------------------------------
24:                     If Me.lblCancelacion.Visible = False Then
25:                         Me.lblAPagar.Text = "PAGOS QUINCENALES DE " _
                                                & CStr(Format(((CDbl(oDataView(0)("MontoPago")) + ImporteSeguro) / CInt(strQuin)), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                            '& CStr(Format(Format(CDbl(oDataView(0)("MontoPago")), "$#,##0.00") / CInt(strQuin), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                        Else
                            Me.lblAPagar.Text = ""
                        End If
                        'Me.lblAPagar.Text = "Usted pagará la cantidad de " _
                        '& CStr(Format(Format(CDbl(oDataView(0)("MontoPago")), "$#,##0.00") / CInt(strQuin), "$#,##0.00")) & " de manera quincenal en el plazo establecido."
                    Else
                        Me.lblAPagar.Text = ""
                    End If
                    If FechaPrimerPago <> Nothing Then
                        lblAPagar.Text &= vbCrLf & "EMPIEZA A PAGAR EL: " & FechaPrimerPago.ToString("dd/MM/yyyy")
                    End If
                Else
                    Me.txtFirma.Visible = False
                    Me.lblAPagar.Text = ""
                End If


            Else
                Me.txtFirma.Visible = False
                Me.lblQuincenas.Visible = False
                Me.lblAPagar.Visible = False
            End If

            '**************************************************************
            Dim strdt As String = String.Empty
            tbDomicilio.Text = String.Empty
            '------------------------DOMICILIO
26:         strdt = Trim(DatosGenerales.Rows(0).Item("Domicilio"))
27:         If strdt <> String.Empty Then
28:             tbDomicilio.Text = strdt & vbNewLine
            End If
            '------------------------CIUDAD ESTADO
29:         strdt = Trim(DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado"))
30:         If strdt <> String.Empty Then
31:             If oFactura.CodTipoVenta = "P" Then
32:                 tbDomicilio.Text = tbDomicilio.Text & strdt
                Else
33:                 tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
                End If
            End If
            '------------------------RFC
34:         strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC")))
35:         If strdt <> String.Empty Then
36:             tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            End If
            '------------------------TELEFONO
37:         strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono")))
38:         If strdt <> String.Empty Then
39:             tbDomicilio.Text = tbDomicilio.Text & strdt
            End If
            '**************************************************************
            strdt = String.Empty
            '----------------------------FACILITO - TEXTO LETRA
40:         If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
41:             strdt = Trim(DatosGenerales.Rows(0).Item("AutorizacionFacilito")) & vbNewLine & vbNewLine
            End If

42:         If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
43:             strdt = strdt & Trim(DatosGenerales.Rows(0).Item("LeyendaPago")) & vbNewLine & vbNewLine
            End If
            '----------------------------FACILITO - TEXTO LETRA
            ' Autorizacion Facilito + Leyenda de Pago + Cantidad Con Letra 
44:         tbTotalLetras.Text = strdt & DatosGenerales.Rows(0).Item("CantidadTexto")

            'Cantidad total de piezas
45:         Me.tbSubTotal.Text = CInt(oFactura.Detalle.Tables(0).Compute("Sum(Cantidad)", "")) & vbNewLine
46:         Me.TxtSubTotIva.Text = "Total Piezas".ToUpper & vbNewLine
            ''*******************************************************************
            ''------------------------------DESC. APLICADO:
            'Dim descuento As Decimal = CDec(dtDetallesArticulos.Compute("SUM(CantDescuentoSistema)", "")) + CDec(dtDetallesArticulos.Compute("SUM(Adicional)", ""))
            'If oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "O" OrElse oFactura.CodTipoVenta = "F" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
            '    If descuento <> 0 Then
            '        ' If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
            '        ' tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1), "Currency") & vbNewLine
            '        'Else
            '        tbSubTotal.Text &= Format(descuento, "Currency") & vbNewLine
            '        ' End If
            '        'TxtSubTotIva.Text = "DESC. APLICADO:" & vbNewLine
            '        TxtSubTotIva.Text &= "USTED AHORRO:" & vbNewLine
            '    Else
            '        Label20.Text = String.Empty
            '        TxtBxSubTotSinDescto.Text = String.Empty
            '        TxtBxSubTotSinDescto.Visible = False
            '        Label20.Visible = False
            '    End If
            'Else
            '    Label20.Text = String.Empty
            '    TxtBxSubTotSinDescto.Text = String.Empty
            '    TxtBxSubTotSinDescto.Visible = False
            '    Label20.Visible = False
            'End If
            ''------------------------------DESC. APLICADO:
            ''----------------------------SUBTOTAL
            'Dim total As Decimal = CDec(dtDetallesArticulos.Compute("SUM(Total)", ""))
            'If oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "O" OrElse oFactura.CodTipoVenta = "F" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
            '    If total <> 0 Then
            '        tbSubTotal.Text = tbSubTotal.Text & Format(total, "$#,##0.00") & vbNewLine
            '        If descuento <> 0 Then
            '            TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
            '        Else
            '            TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
            '        End If
            '    End If
            'End If
            ''----------------------------SUBTOTAL
            ''----------------------------IVA
            'Dim iva As Decimal = CDec(dtDetallesArticulos.Compute("SUM(Total)", "")) * oAppContext.ApplicationConfiguration.IVA
            'If oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "O" OrElse oFactura.CodTipoVenta = "F" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
            '    If iva <> 0 Then
            '        tbSubTotal.Text = tbSubTotal.Text & Format(iva, "$#,##0.00") & vbNewLine
            '        TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
            '    End If
            'End If
            ''----------------------------IVA
            ''----------------------------TOTAL
            'Dim NewTotal As Decimal = total * (oAppContext.ApplicationConfiguration.IVA + 1)
            ''total = total * (oAppContext.ApplicationConfiguration.IVA + 1)
            'tbSubTotal.Text = tbSubTotal.Text & Format(NewTotal, "$#,##0.00")
            'TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
            'tbTotalLetras.Text = strdt & Letras(NewTotal)
            ''----------------------------TOTAL
            ''*******************************************************************
            '------------------------------DESC. APLICADO:
47:         If oFactura.DescTotal <> 0 Then
                ' If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
                ' tbSubTotal.Text = Format(DatosGenerales.Rows(0).Item("Descuento") * (oAppContext.ApplicationConfiguration.IVA + 1), "Currency") & vbNewLine
                'Else
48:             tbSubTotal.Text &= Format(oFactura.DescTotal, "Currency") & vbNewLine
                ' End If
                'TxtSubTotIva.Text = "DESC. APLICADO:" & vbNewLine
49:             TxtSubTotIva.Text &= "USTED AHORRO:" & vbNewLine
            Else
                Label20.Text = String.Empty
                TxtBxSubTotSinDescto.Text = String.Empty
                TxtBxSubTotSinDescto.Visible = False
                Label20.Visible = False
            End If


            '------------------------------DESC. APLICADO:
            '----------------------------SUBTOTAL 
50:         If oFactura.ClienteId = 10000000 And oFactura.ClienteId = 99999 Then
51:             If oFactura.SubTotal <> 0 Then
52:                 tbSubTotal.Text = tbSubTotal.Text & Format(oFactura.SubTotal, "$#,##0.00") & vbNewLine
53:                 If DatosGenerales.Rows(0).Item("Descuento") <> 0 Then
54:                     TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
                    Else
55:                     TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
                    End If
                End If
                '----------------------------SUBTOTAL
                '----------------------------IVA
56:             If oFactura.IVA <> 0 Then
57:                 tbSubTotal.Text = tbSubTotal.Text & Format(oFactura.IVA, "$#,##0.00") & vbNewLine
58:                 TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
                End If
                '----------------------------IVA
            End If

            '----------------------------TOTAL
            '--------------------------------------------------------------------------------------------------------
            ' JNAVA 24.06.2015: Truncamos el total de la factura para eliminar centavos de mas y lo ponemos el total
            '--------------------------------------------------------------------------------------------------------
            '            TotalFactura -= oFactura.DescTotal
            '59:         tbSubTotal.Text = tbSubTotal.Text & Format(TotalFactura, "$#,##0.00")
            tbSubTotal.Text = tbSubTotal.Text & Format(CDec(DatosGenerales.Rows(0).Item("Total")), "$#,##0.00")
            '--------------------------------------------------------------------------------------------------------
60:         TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
            '----------------------------TOTAL
            '*******************************************************************

            'Vendedor
61:         tbPlayer.Text = DatosGenerales.Rows(0).Item("CodVendedor")

            '------------------------SUCURSAL
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
62:         Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            Dim oAlmacen As Almacen
63:         oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

64:         Me.TxtTienda.Text = oAlmacen.Descripcion
65:         Me.txtDomTienda.Text = oAlmacen.DireccionCalle
66:         Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
67:         Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
            oCatalogoAlmacenesMgr = Nothing
            'tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 21.02.2014: Se le agrego la hora a la fecha que se imprime en la nota de venta
            '----------------------------------------------------------------------------------------------------------------------------------------------
68:         tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & Format(oFactura.Fecha, "dd-MMM-yyyy hh:mm tt").ToUpper
69:         If bReimpresion Then
70:             Me.txtFechaReimpresion.Text = Format(Now, "dd-MMM-yy hh:mm tt").ToUpper
71:             Me.txtFechaReimpresion.Visible = True
72:             Me.lblFechaReimpresa.Visible = True
            End If
            oAlmacen = Nothing
73:         Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbLf & Me.txtDomTienda.Text & vbLf & Me.LblTelefono.Text & vbLf & _
                                 Me.Label19.Text & vbLf & Me.LblLocaliz.Text


            '-------------------------SUCURSAL
            If oConfigCierreFI.HabilitarDPTicket = False Then
                'Notas
                Dim pdsAvisos As New DataSet
                oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
                pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
                '74:         If pdsAvisos.Tables(0).Rows.Count > 0 Then
                '                For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
                '75:                 lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                '                Next
                '            End If

                '---------------------------------------------------------------------------------------
                'JNAVA (25.03.2014): Modificaciones para Venta de Electronicos
                '---------------------------------------------------------------------------------------
                'Revisamos si son puros electronicos en la factura y si hay articulos telcel
                Dim bSoloTelcel As Boolean = False
                Dim bTelcel As Boolean = False

                'Revisamos si hay articulos telcel
                HayTelcel(oFactura.Detalle.Tables(0), bTelcel, bSoloTelcel)
                If pdsAvisos.Tables(0).Rows.Count > 0 Then
                    For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
                        If bSoloTelcel = False And bTelcel = True Then
                            'Se agregan todas las leyendas
                            lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                        ElseIf bSoloTelcel = True Then
                            'Solo se agrega la nota 7
                            If oRow.Item("Telcel") = "1" Then
                                lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                            End If
                        ElseIf bTelcel = False Then
                            'no se Agrega la nota 7
                            If oRow.Item("Telcel") <> "1" Then
                                lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                            End If
                        End If
                    Next
                End If
            Else
                lblNotas.Visible = False
                '-----------------------------------------------------------------------------------
                'FLIZARRAGA 08/05/2017: Se agrega el html de DPTicket
                '-----------------------------------------------------------------------------------
                If Not DPTicket Is Nothing Then
                    If DPTicket.Count > 0 Then
                        Try
                            If DPTicket.ContainsKey("html") Then Me.DPTicket.Html = CStr(DPTicket("html"))
                            If DPTicket.ContainsKey("tipoimagen") Then
                                Select Case CStr(DPTicket("tipoimagen")).ToUpper()
                                    Case "CB"
                                        Me.CodeImage.Text = CStr(DPTicket("valorimagen"))
                                        Me.CodeImage.Style = BarCodeStyle.Ansi39
                                        Me.CodeImage.Location = New PointF(0.011, 8.031)
                                        Me.CodeImage.Size = New SizeF(2.414, 0.187)
                                        Me.DPTicket.Visible = True
                                        Me.CodeImage.Visible = True
                                        Me.ImgDPTicket.Visible = False
                                    Case "QR"
                                        Me.CodeImage.Text = CStr(DPTicket("valorimagen"))
                                        Me.CodeImage.Style = BarCodeStyle.QRCode
                                        Me.CodeImage.Location = New PointF(0.827, 7.959)
                                        Me.CodeImage.Size = New SizeF(0.542, 0.542)
                                        Me.DPTicket.Visible = True
                                        Me.CodeImage.Visible = True
                                        Me.ImgDPTicket.Visible = False
                                    Case "IMAGEN"
                                        Me.CodeImage.Visible = False
                                        Me.DPTicket.Visible = True
                                        Me.ImgDPTicket.Visible = True
                                        Me.ImgDPTicket.Image = DecodificarImagen(CStr(DPTicket("valorimagen")))
                                    Case Else
                                        Me.DPTicket.Visible = False
                                        Me.CodeImage.Visible = False
                                        Me.ImgDPTicket.Visible = False
                                End Select
                            End If
                        Catch ex As Exception
                            EscribeLog(ex.Message, "Error al imprimir DPTicket")
                        End Try
                    End If
                End If
            End If


            '---------------------------------------------------------------------------------------
            'Notas

            '------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 18/04/2013: Se valida si son los articulos con existencias o sin existencias True="Con Existencias" y 
            '                       False="Sin existencias"
            '------------------------------------------------------------------------------------------------------------------------------

76:         Me.txtRecibiPor.Visible = FactSiHay

77:         lblNotas.Visible = opcion
78:         Label2.Visible = opcion
79:         SubReport1.Visible = opcion

            oReporteFormapago = New ReporteDetalleFormasPago(oFactura.PedidoID, 1)  'oDataRpt.PedidoID
            Me.SubReport1.Report = oReporteFormapago
            Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
            Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember

            oReporteAvisosFactura = New ReporteAvisosFactura(oDataRpt.ModuloID, oDataRpt.Disponible)
            Me.SubReport2.Report = oReporteAvisosFactura
            Me.SubReport2.Report.DataSource = oReporteAvisosFactura.DataSource
            Me.SubReport2.Report.DataMember = oReporteAvisosFactura.DataMember
            Me.CodTipoVenta = oFactura.CodTipoVenta
            Me.Run()
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error en linea " & Err.Erl)
            Throw New ApplicationException("Se produjó un error. La Factura no pudo ser impresa. Linea: " & Err.Erl, ex)
        End Try

    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2013: Se agrego constructor vacio para hacer impresion del Tickets de Pedidos
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Sub New()
        InitializeComponent()
        InicializaObjetos()
        Me.txtFirma.Visible = False
        Me.txtRecibiPor.Visible = False
    End Sub

    Public Sub ImprimirCancelacionSH(ByVal facturados As Boolean, ByVal rpt As rptFacturaInfo, ByVal dtDetallesArticulos As DataTable, ByVal DatosGenerales As DataTable, ByVal opcion As Boolean, _
    ByVal TipoFact As String, ByVal ImprimirCedula As Boolean, _
    Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, Optional ByVal bReimpresion As Boolean = False, Optional ByVal ImporteSeguro As Decimal = 0)

        oFactura.ClearFields()
        Dim pedido As New Pedidos(rpt.PedidoID)
        Dim detallesFactura As DataTable = Nothing
        Dim tipoFactura As String = TipoFact

        '----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 29/04/2013: Por medio del titulo se selecciona el mensaje a mostrar en el Ticket
        '----------------------------------------------------------------------------------------------------------------------------
        Select Case TipoFact
            Case "PENDIENTE"
                TipoFact = "PENDIENTE POR ENTREGAR"
                lblCancelacion.Visible = False
                Me.tbFCancelacion.Visible = False
                Me.lblFactura.Text = "FOLIO:"
            Case "COPIA PENDIENTE"
                TipoFact = "COPIA PENDIENTE POR ENTREGAR"
                lblCancelacion.Visible = False
                Me.tbFCancelacion.Visible = False
                Me.lblFactura.Text = "FOLIO:"
            Case "CANCELACION"
                TipoFact = "CANCELACIÓN DE NOTA DE VENTA"
                lblCancelacion.Visible = True
                Me.tbFCancelacion.Visible = True
                Me.lblFactura.Text = "APLICA A NOTA DE"
            Case "COPIA CANCELACION"
                TipoFact = "COPIA CANCELACIÓN DE NOTA DE VENTA"
                lblCancelacion.Visible = True
                Me.tbFCancelacion.Visible = True
                Me.lblFactura.Text = "APLICA A NOTA DE"
        End Select

        'Me.DataSource = oFactura.Detalle
        'Me.DataMember = "FacturaDetalle"
        Dim dtTemp As DataTable

        Dim dtDetalle As DataTable = FormatearTablaDetalle().Clone
        'Me.DataSource = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
        'If (tipoFactura.Trim = "cancelacion".ToUpper()) Then
        'dtTemp = LlenarTablaDetallePedidoSH(dtDetallesArticulos, dtDetalle).Copy
        'Else
        dtTemp = LlenarTablaDetalle(dtDetallesArticulos, dtDetalle, True).Copy
        'End If

        Me.DataSource = SepararArticulos(dtTemp, True).Copy
        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.txtCodProveedor.DataField = "CodArtProv"
        Me.txtMarca.DataField = "Marca"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "PrecioOferta"
        Me.tbTotal.DataField = "Total"
        Me.tbFCancelacion.Text = oFactura.FCancelacionSD
        Me.tbDesc.DataField = "Descuento"

        boolImprimirCedula = ImprimirCedula

        If TipoLeyenda <> "" Then
            If TipoLeyenda = "FACTURA" Then
                TipoLeyenda = "NOTA DE VENTA"
            ElseIf TipoLeyenda = "COPIA DE FACTURA" Then
                TipoLeyenda = "COPIA DE NOTA DE VENTA"
            End If
            Select Case TipoLeyenda.Trim.ToUpper
                Case "PENDIENTE"
                    TipoLeyenda = "PENDIENTE POR ENTREGAR"
                    lblCancelacion.Visible = False
                    Me.tbFCancelacion.Visible = False
                    Me.lblFactura.Text = "FOLIO:"
                Case "COPIA PENDIENTE"
                    TipoLeyenda = "COPIA PENDIENTE POR ENTREGAR"
                    lblCancelacion.Visible = False
                    Me.tbFCancelacion.Visible = False
                    Me.lblFactura.Text = "FOLIO:"
            End Select
            LblCopia.Text = TipoLeyenda
        Else
            LblCopia.Text = TipoFact
        End If


        If tipoFactura = "CANCELACION" Or tipoFactura = "COPIA CANCELACION" Then
            tbFactura.Text = pedido.Referencia
            tbFCancelacion.Text = pedido.FolioPedido
        ElseIf pedido.FolioSAP = "" Then
            tbFactura.Text = CStr(DatosGenerales.Rows(0).Item("FolioFactura")).PadLeft(10, "0")
            LblCopia.Text = "PENDIENTE POR ENTREGAR"
        Else
            tbFactura.Text = pedido.FolioSAP
        End If

        lblCaja.Text = "CAJA :" & oFactura.CodCaja

        tbTipoVenta.Text = DatosGenerales.Rows(0).Item("TipoVenta")
        tbNombre.Text = DatosGenerales.Rows(0).Item("NombreCliente")

        'se asignas las quincenas del vale
        If pedido.CodTipoVenta = "V" Then
            Me.lblQuincenas.Visible = True
            Me.lblAPagar.Visible = True
            Me.lblQuincenas.Text = strQuin & " QUINCENAS"
            Me.lblLeyendaPago.Text = "________Pago hecho en parcialidades______"

            dsFormaPago2 = oFacturaFormaPago.LoadByPedidoID(pedido.PedidoID)
            If dsFormaPago2.Tables(0).Rows.Count > 0 Then
                Dim oDataView As New DataView(dsFormaPago2.Tables(0), "CodFormasPago = 'DPVL'", "CodFormasPago", DataViewRowState.CurrentRows)

                If oDataView.Count > 0 Then
                    'Total a pagar en quincenas
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 23/12/2014: Se modifico la leyenda del ticket por temas fiscales con SAP solicitado en mail del 19/12/2014 de Leticia Linn
                    '-------------------------------------------------------------------------------------------------------------------------------------
                    If Me.lblCancelacion.Visible = False Then
                        Me.lblAPagar.Text = "PAGOS QUINCENALES DE " _
                                            & CStr(Format(((CDbl(oDataView(0)("MontoPago")) + ImporteSeguro) / CInt(strQuin)), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                    Else
                        Me.lblAPagar.Text = ""
                    End If
                    'Me.lblAPagar.Text = "Usted pagará la cantidad de " _
                    '& CStr(Format(Format(CDbl(oDataView(0)("MontoPago")), "$#,##0.00") / CInt(strQuin), "$#,##0.00")) & " de manera quincenal en el plazo establecido."
                Else
                    Me.lblAPagar.Text = ""
                End If
            Else
                Me.lblAPagar.Text = ""
            End If

        Else
            Me.lblQuincenas.Visible = False
            Me.lblAPagar.Visible = False
        End If

        '**************************************************************
        Dim strdt As String = String.Empty
        tbDomicilio.Text = String.Empty
        '------------------------DOMICILIO
        strdt = Trim(DatosGenerales.Rows(0).Item("Domicilio"))
        If strdt <> String.Empty Then
            tbDomicilio.Text = strdt & vbNewLine
        End If
        '------------------------CIUDAD ESTADO
        strdt = Trim(DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado"))
        If strdt <> String.Empty Then
            If oFactura.CodTipoVenta = "P" Then
                tbDomicilio.Text = tbDomicilio.Text & strdt
            Else
                tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            End If
        End If
        '------------------------RFC
        strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC")))
        If strdt <> String.Empty Then
            tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
        End If
        '------------------------TELEFONO
        strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono")))
        If strdt <> String.Empty Then
            tbDomicilio.Text = tbDomicilio.Text & strdt
        End If
        '**************************************************************
        strdt = String.Empty
        '----------------------------FACILITO - TEXTO LETRA
        If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
            strdt = Trim(DatosGenerales.Rows(0).Item("AutorizacionFacilito")) & vbNewLine & vbNewLine
        End If

        If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
            strdt = strdt & Trim(DatosGenerales.Rows(0).Item("LeyendaPago")) & vbNewLine & vbNewLine
        End If
        '----------------------------FACILITO - TEXTO LETRA
        ' Autorizacion Facilito + Leyenda de Pago + Cantidad Con Letra 
        'tbTotalLetras.Text = strdt & DatosGenerales.Rows(0).Item("CantidadTexto")

        'Cantidad total de piezas
        Me.tbSubTotal.Text = CInt(dtDetallesArticulos.Compute("SUM(Cantidad)", "")) & vbNewLine
        Me.TxtSubTotIva.Text = "Total Piezas".ToUpper & vbNewLine
        '*******************************************************************
        '------------------------------DESC. APLICADO:
        Dim descuento As Decimal = GetDescuentoTotalFacturaExistenciaSH(dtDetallesArticulos)
        'AndAlso (tipoFactura <> "CANCELACION" Or tipoFactura <> "COPIA CANCELACION") 
        If descuento <> 0 Then
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 28.05.2015: Se aumento el IVA, porque le faltaba segun el tipo de venta
            '---------------------------------------------------------------------------------------------------------------------------------
            If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
            OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
                tbSubTotal.Text &= Format(Math.Round(descuento * (1 + oAppContext.ApplicationConfiguration.IVA), 2), "Currency") & vbNewLine
            Else
                tbSubTotal.Text &= Format(Math.Round(descuento, 2), "Currency") & vbNewLine
            End If

            TxtSubTotIva.Text &= "USTED AHORRO:" & vbNewLine
        Else
            Label20.Text = String.Empty

            TxtBxSubTotSinDescto.Text = String.Empty
            TxtBxSubTotSinDescto.Visible = False
            Label20.Visible = False
        End If

        If facturados Then

            '------------------------------DESC. APLICADO:
            '----------------------------SUBTOTAL
            Dim total As Decimal = CDec(dtDetallesArticulos.Compute("SUM(Total)", ""))
            'If tipoFactura <> "CANCELACION" Or tipoFactura <> "COPIA CANCELACION" Then
            If pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999" Then
                If total <> 0 Then
                    tbSubTotal.Text = tbSubTotal.Text & Format(total - descuento, "$#,##0.00") & vbNewLine
                    If descuento <> 0 Then
                        TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
                    Else
                        TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
                    End If
                End If
            End If

            '----------------------------SUBTOTAL
            '----------------------------IVA
            If pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999" Then
                Dim iva As Decimal = (total - descuento) * oAppContext.ApplicationConfiguration.IVA
                If iva <> 0 Then
                    tbSubTotal.Text = tbSubTotal.Text & Format(iva, "$#,##0.00") & vbNewLine
                    TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
                End If
            End If
            'End If

            '----------------------------IVA
            '----------------------------TOTAL
            Dim NewTotal As Decimal = (total - descuento) * (oAppContext.ApplicationConfiguration.IVA + 1)
            'total = total * (oAppContext.ApplicationConfiguration.IVA + 1)
            tbSubTotal.Text = tbSubTotal.Text & Format(NewTotal, "$#,##0.00")
            TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
            tbTotalLetras.Text = strdt & Letras(Math.Round(NewTotal, 2)).ToUpper()
            '----------------------------TOTAL
            '*******************************************************************
        Else
            Dim desc As Decimal = 0
            If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
            OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
                desc = Math.Round(descuento * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            Else
                desc = Math.Round(descuento, 2)
            End If

            Dim total As Decimal = CDec(dtDetallesArticulos.Compute("SUM(Total)", ""))
            Dim iva As Decimal = total * oAppContext.ApplicationConfiguration.IVA
            tbSubTotal.Text = tbSubTotal.Text & Format(total + iva - desc, "$#,##0.00") & vbNewLine

            TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
        End If
        'Vendedor
        tbPlayer.Text = DatosGenerales.Rows(0).Item("CodVendedor")

        '------------------------SUCURSAL
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '.ApplicationConfiguration.Almacen)
        Me.TxtTienda.Text = oAlmacen.Descripcion
        Me.txtDomTienda.Text = oAlmacen.DireccionCalle
        Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
        Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
        oCatalogoAlmacenesMgr = Nothing
        'tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))
        '----------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 21.02.2014: Se le agrego la hora a la fecha que se imprime en la nota de venta
        '----------------------------------------------------------------------------------------------------------------------------------------------
        tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & Format(pedido.Fecha, "dd-MMM-yyyy hh:mm tt").ToUpper
        If bReimpresion Then
            Me.txtFechaReimpresion.Text = Format(Now, "dd-MMM-yy hh:mm tt").ToUpper
            Me.txtFechaReimpresion.Visible = True
            Me.lblFechaReimpresa.Visible = True
        End If
        oAlmacen = Nothing
        Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbLf & Me.txtDomTienda.Text & vbLf & Me.LblTelefono.Text & vbLf & _
                             Me.Label19.Text & vbLf & Me.LblLocaliz.Text


        '-------------------------SUCURSAL
        If oConfigCierreFI.HabilitarDPTicket = False Then
            'Notas
            Dim pdsAvisos As New DataSet
            oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
            pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
            If pdsAvisos.Tables(0).Rows.Count > 0 Then
                For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
                    lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                Next
            End If
        Else
            lblNotas.Visible = False

        End If

        '----- Validacion de campos a mostrar en cancelacion--------------
        If tipoFactura = "CANCELACION" Then
            Me.tbNumcliente.Visible = False
        End If
        'Notas

        '------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 18/04/2013: Se valida si son los articulos con existencias o sin existencias True="Con Existencias" y 
        '                       False="Sin existencias"
        '------------------------------------------------------------------------------------------------------------------------------

        lblNotas.Visible = opcion
        Label2.Visible = opcion
        SubReport1.Visible = opcion

        oReporteFormapago = New ReporteDetalleFormasPago(pedido.PedidoID, 1)
        Me.SubReport1.Report = oReporteFormapago
        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember
        Me.Label2.Visible = facturados
        Me.SubReport1.Visible = facturados

        oReporteAvisosFactura = New ReporteAvisosFactura(rpt.ModuloID, rpt.Disponible)
        Me.SubReport2.Report = oReporteAvisosFactura
        Me.SubReport2.Report.DataSource = oReporteAvisosFactura.DataSource
        Me.SubReport2.Report.DataMember = oReporteAvisosFactura.DataMember
        Me.CodTipoVenta = pedido.CodTipoVenta
        Me.Run()
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2013: Se agrego la funcion donde se realizara la impresión de los pedidos de las ventas SiHay
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Sub ImprimirPedidoSH(ByVal rpt As rptFacturaInfo, ByVal dtDetallesArticulos As DataTable, ByVal DatosGenerales As DataTable, ByVal opcion As Boolean, _
    ByVal TipoFact As String, ByVal ImprimirCedula As Boolean, _
    Optional ByVal TipoLeyenda As String = "", Optional ByVal strQuin As Integer = 0, Optional ByVal bReimpresion As Boolean = False, Optional ByVal ImporteSeguro As Decimal = 0, Optional ByVal FechaPrimerPago As DateTime = Nothing)

        oFactura.ClearFields()
        Dim pedido As New Pedidos(rpt.PedidoID)
        Dim detallesFactura As DataTable = Nothing
        Dim tipoFactura As String = TipoFact

        '----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 29/04/2013: Por medio del titulo se selecciona el mensaje a mostrar en el Ticket
        '----------------------------------------------------------------------------------------------------------------------------
        Select Case TipoFact
            Case "PENDIENTE"
                TipoFact = "PENDIENTE POR ENTREGAR"
                lblCancelacion.Visible = False
                Me.tbFCancelacion.Visible = False
                Me.lblFactura.Text = "FOLIO:"
            Case "COPIA PENDIENTE"
                TipoFact = "COPIA PENDIENTE POR ENTREGAR"
                lblCancelacion.Visible = False
                Me.tbFCancelacion.Visible = False
                Me.lblFactura.Text = "FOLIO:"
            Case "CANCELACION"
                TipoFact = "CANCELACIÓN DE NOTA DE VENTA"
                lblCancelacion.Visible = True
                Me.tbFCancelacion.Visible = True
                Me.lblFactura.Text = "APLICA A NOTA DE"
            Case "COPIA CANCELACION"
                TipoFact = "COPIA CANCELACIÓN DE NOTA DE VENTA"
                lblCancelacion.Visible = True
                Me.tbFCancelacion.Visible = True
                Me.lblFactura.Text = "APLICA A NOTA DE"
        End Select

        'Me.DataSource = oFactura.Detalle
        'Me.DataMember = "FacturaDetalle"
        Dim dtTemp As DataTable

        Dim dtDetalle As DataTable = FormatearTablaDetalle().Clone
        'Me.DataSource = LlenarTablaDetalle(oFactura.Detalle.Tables(0), dtDetalle).Copy
        dtTemp = LlenarTablaDetalle(dtDetallesArticulos, dtDetalle, True).Copy
        Me.DataSource = SepararArticulos(dtTemp, True).Copy
        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCodigo.DataField = "CodArticulo"
        Me.txtCodProveedor.DataField = "CodArtProv"
        Me.txtMarca.DataField = "Marca"
        Me.tbConcepto.DataField = "Descripcion"
        Me.tbNumero.DataField = "Numero"
        Me.tbPUnitario.DataField = "PrecioOferta"
        Me.tbTotal.DataField = "Total"
        Me.tbFCancelacion.Text = oFactura.FCancelacionSD
        Me.tbDesc.DataField = "Descuento"


        boolImprimirCedula = ImprimirCedula

        If TipoLeyenda <> "" Then
            If TipoLeyenda = "FACTURA" Then
                TipoLeyenda = "NOTA DE VENTA"
            ElseIf TipoLeyenda = "COPIA DE FACTURA" Then
                TipoLeyenda = "COPIA DE NOTA DE VENTA"
            End If
            Select Case TipoLeyenda.Trim.ToUpper
                Case "PENDIENTE"
                    TipoLeyenda = "PENDIENTE POR ENTREGAR"
                    lblCancelacion.Visible = False
                    Me.tbFCancelacion.Visible = False
                    Me.lblFactura.Text = "FOLIO:"
                Case "COPIA PENDIENTE"
                    TipoLeyenda = "COPIA PENDIENTE POR ENTREGAR"
                    lblCancelacion.Visible = False
                    Me.tbFCancelacion.Visible = False
                    Me.lblFactura.Text = "FOLIO:"
            End Select
            LblCopia.Text = TipoLeyenda
        Else
            LblCopia.Text = TipoFact
        End If

        If tipoFactura = "CANCELACION" Or tipoFactura = "COPIA CANCELACION" Then
            tbFactura.Text = pedido.Referencia
            tbFCancelacion.Text = pedido.FolioPedido
        ElseIf pedido.FolioSAP = "" Then
                tbFactura.Text = CStr(DatosGenerales.Rows(0).Item("FolioFactura")).PadLeft(10, "0")
                LblCopia.Text = "PENDIENTE POR ENTREGAR"
            Else
                tbFactura.Text = pedido.FolioSAP
            End If

            lblCaja.Text = "CAJA :" & oFactura.CodCaja

            tbTipoVenta.Text = DatosGenerales.Rows(0).Item("TipoVenta")
            tbNombre.Text = DatosGenerales.Rows(0).Item("NombreCliente")

            'se asignas las quincenas del vale
            If pedido.CodTipoVenta = "V" Then
                Me.lblQuincenas.Visible = True
                Me.lblAPagar.Visible = True
                Me.lblQuincenas.Text = strQuin & " QUINCENAS"
                Me.lblLeyendaPago.Text = "________Pago hecho en parcialidades______"

                dsFormaPago2 = oFacturaFormaPago.LoadByPedidoID(pedido.PedidoID)
                If dsFormaPago2.Tables(0).Rows.Count > 0 Then
                    Dim oDataView As New DataView(dsFormaPago2.Tables(0), "CodFormasPago = 'DPVL'", "CodFormasPago", DataViewRowState.CurrentRows)

                    If oDataView.Count > 0 Then
                        'Total a pagar en quincenas
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        'JNAVA 23/12/2014: Se modifico la leyenda del ticket por temas fiscales con SAP solicitado en mail del 19/12/2014 de Leticia Linn
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        If Me.lblCancelacion.Visible = False Then
                            Me.lblAPagar.Text = "PAGOS QUINCENALES DE " _
                                                & CStr(Format(((CDbl(oDataView(0)("MontoPago")) + ImporteSeguro) / CInt(strQuin)), "$#,##0.00")) '& " de manera quincenal en el plazo establecido."
                        Else
                            Me.lblAPagar.Text = ""
                        End If
                        'Me.lblAPagar.Text = "Usted pagará la cantidad de " _
                        '& CStr(Format(Format(CDbl(oDataView(0)("MontoPago")), "$#,##0.00") / CInt(strQuin), "$#,##0.00")) & " de manera quincenal en el plazo establecido."
                    Else
                        Me.lblAPagar.Text = ""
                    End If
                Else
                    Me.lblAPagar.Text = ""
                End If
                If FechaPrimerPago <> Nothing Then
                    lblAPagar.Text &= vbCrLf & "EMPIEZA A PAGAR EL: " & FechaPrimerPago.ToString("dd/MM/yyyy")
                End If
            Else
                Me.lblQuincenas.Visible = False
                Me.lblAPagar.Visible = False
            End If

            '**************************************************************
            Dim strdt As String = String.Empty
            tbDomicilio.Text = String.Empty
            '------------------------DOMICILIO
            strdt = Trim(DatosGenerales.Rows(0).Item("Domicilio"))
            If strdt <> String.Empty Then
                tbDomicilio.Text = strdt & vbNewLine
            End If
            '------------------------CIUDAD ESTADO
            strdt = Trim(DatosGenerales.Rows(0).Item("Ciudad") & " " & DatosGenerales.Rows(0).Item("Estado"))
            If strdt <> String.Empty Then
                If oFactura.CodTipoVenta = "P" Then
                    tbDomicilio.Text = tbDomicilio.Text & strdt
                Else
                    tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
                End If
            End If
            '------------------------RFC
            strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("RFC")), "", DatosGenerales.Rows(0).Item("RFC")))
            If strdt <> String.Empty Then
                tbDomicilio.Text = tbDomicilio.Text & strdt & vbNewLine
            End If
            '------------------------TELEFONO
            strdt = Trim(IIf(IsDBNull(DatosGenerales.Rows(0).Item("Telefono")), "", DatosGenerales.Rows(0).Item("Telefono")))
            If strdt <> String.Empty Then
                tbDomicilio.Text = tbDomicilio.Text & strdt
            End If
            '**************************************************************
            strdt = String.Empty
            '----------------------------FACILITO - TEXTO LETRA
            If Trim(CStr(DatosGenerales.Rows(0).Item("AutorizacionFacilito"))) <> String.Empty Then
                strdt = Trim(DatosGenerales.Rows(0).Item("AutorizacionFacilito")) & vbNewLine & vbNewLine
            End If

            If Trim(CStr(DatosGenerales.Rows(0).Item("LeyendaPago"))) <> String.Empty Then
                strdt = strdt & Trim(DatosGenerales.Rows(0).Item("LeyendaPago")) & vbNewLine & vbNewLine
            End If
            '----------------------------FACILITO - TEXTO LETRA
            ' Autorizacion Facilito + Leyenda de Pago + Cantidad Con Letra 
            'tbTotalLetras.Text = strdt & DatosGenerales.Rows(0).Item("CantidadTexto")

            'Cantidad total de piezas
            Me.tbSubTotal.Text = CInt(dtDetallesArticulos.Compute("SUM(Cantidad)", "")) & vbNewLine
            Me.TxtSubTotIva.Text = "Total Piezas".ToUpper & vbNewLine
            '*******************************************************************
            '------------------------------DESC. APLICADO:
            Dim descuento As Decimal = GetDescuentoTotalFacturaExistenciaSH(dtDetallesArticulos)
            If descuento <> 0 Then
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 28.05.2015: Se aumento el IVA, porque le faltaba segun el tipo de venta
                '---------------------------------------------------------------------------------------------------------------------------------
                If Me.CodTipoVenta = "P" OrElse Me.CodTipoVenta = "V" OrElse Me.CodTipoVenta = "E" _
                OrElse (InStr("D,S", Me.CodTipoVenta) > 0 AndAlso oConfigCierreFI.AplicaNewDescuentosDIPs) Then
                    tbSubTotal.Text &= Format(Math.Round(descuento * (1 + oAppContext.ApplicationConfiguration.IVA), 2), "Currency") & vbNewLine
                Else
                    tbSubTotal.Text &= Format(Math.Round(descuento, 2), "Currency") & vbNewLine
                End If

                TxtSubTotIva.Text &= "USTED AHORRO:" & vbNewLine
            Else
                Label20.Text = String.Empty
                TxtBxSubTotSinDescto.Text = String.Empty
                TxtBxSubTotSinDescto.Visible = False
                Label20.Visible = False
            End If

            '------------------------------DESC. APLICADO:
            '----------------------------SUBTOTAL
            Dim total As Decimal = CDec(dtDetallesArticulos.Compute("SUM(Total)", ""))
            If pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999" Then
                If total <> 0 Then
                    tbSubTotal.Text = tbSubTotal.Text & Format(total - descuento, "$#,##0.00") & vbNewLine
                    If descuento <> 0 Then
                        TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL CON DESC.:" & vbNewLine
                    Else
                        TxtSubTotIva.Text = TxtSubTotIva.Text & "SUBTOTAL:" & vbNewLine
                    End If
                End If
            End If
            '----------------------------SUBTOTAL
            '----------------------------IVA
            If pedido.ClienteID <> "1" AndAlso pedido.ClienteID <> "99999" Then
                Dim iva As Decimal = (total - descuento) * oAppContext.ApplicationConfiguration.IVA
                If iva <> 0 Then
                    tbSubTotal.Text = tbSubTotal.Text & Format(iva, "$#,##0.00") & vbNewLine
                    TxtSubTotIva.Text = TxtSubTotIva.Text & "IVA:" & vbNewLine
                End If
            End If
            '----------------------------IVA
            '----------------------------TOTAL
            Dim NewTotal As Decimal = (total - descuento) * (oAppContext.ApplicationConfiguration.IVA + 1)
            'total = total * (oAppContext.ApplicationConfiguration.IVA + 1)
            tbSubTotal.Text = tbSubTotal.Text & Format(NewTotal, "$#,##0.00")
            TxtSubTotIva.Text = TxtSubTotIva.Text & "TOTAL:" & vbNewLine
            tbTotalLetras.Text = strdt & Letras(Math.Round(NewTotal, 2)).ToUpper()
            '----------------------------TOTAL
            '*******************************************************************

            'Vendedor
            tbPlayer.Text = DatosGenerales.Rows(0).Item("CodVendedor")

            '------------------------SUCURSAL
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            Dim oAlmacen As Almacen
            oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) '.ApplicationConfiguration.Almacen)
            Me.TxtTienda.Text = oAlmacen.Descripcion
            Me.txtDomTienda.Text = oAlmacen.DireccionCalle
            Me.LblTelefono.Text = "C.P." & oAlmacen.DireccionCP & " TEL. " & oAlmacen.TelefonoNum
            Me.LblLocaliz.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado
            oCatalogoAlmacenesMgr = Nothing
            'tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & UCase(Format(Now, "dd-MMM-yy hh:mm tt"))
            '----------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 21.02.2014: Se le agrego la hora a la fecha que se imprime en la nota de venta
            '----------------------------------------------------------------------------------------------------------------------------------------------
            tbLugarFecha.Text = oAlmacen.DireccionCiudad & ", " & oAlmacen.DireccionEstado & ", " & Format(pedido.Fecha, "dd-MMM-yyyy hh:mm tt").ToUpper
            If bReimpresion Then
                Me.txtFechaReimpresion.Text = Format(Now, "dd-MMM-yy hh:mm tt").ToUpper
                Me.txtFechaReimpresion.Visible = True
                Me.lblFechaReimpresa.Visible = True
            End If
            oAlmacen = Nothing
            Me.txtInfoSuc.Text = Me.TxtTienda.Text & vbLf & Me.txtDomTienda.Text & vbLf & Me.LblTelefono.Text & vbLf & _
                                 Me.Label19.Text & vbLf & Me.LblLocaliz.Text


            '-------------------------SUCURSAL
            If oConfigCierreFI.HabilitarDPTicket = False Then
                'Notas
                Dim pdsAvisos As New DataSet
                oAvisosFacturaMgr = New AvisosFacturaManager(oAppContext)
                pdsAvisos = oAvisosFacturaMgr.LoadEnabled("FACTURACION", True)
                If pdsAvisos.Tables(0).Rows.Count > 0 Then
                    For Each oRow As DataRow In pdsAvisos.Tables(0).Rows
                        lblNotas.Text += oRow.Item("Nota") & "." & Microsoft.VisualBasic.vbCrLf
                    Next
                End If
            Else
                lblNotas.Visible = False

            End If

        '----- Validacion de campos a mostrar en cancelacion--------------
        If tipoFactura = "CANCELACION" Then
            Me.tbNumcliente.Visible = False
        End If
            'Notas

            '------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 18/04/2013: Se valida si son los articulos con existencias o sin existencias True="Con Existencias" y 
            '                       False="Sin existencias"
            '------------------------------------------------------------------------------------------------------------------------------

        lblNotas.Visible = opcion
        Label2.Visible = opcion
        SubReport1.Visible = opcion

        oReporteFormapago = New ReporteDetalleFormasPago(pedido.PedidoID, 1)
        Me.SubReport1.Report = oReporteFormapago
        Me.SubReport1.Report.DataSource = oReporteFormapago.DataSource
        Me.SubReport1.Report.DataMember = oReporteFormapago.DataMember

        oReporteAvisosFactura = New ReporteAvisosFactura(rpt.ModuloID, rpt.Disponible)
        Me.SubReport2.Report = oReporteAvisosFactura
        Me.SubReport2.Report.DataSource = oReporteAvisosFactura.DataSource
        Me.SubReport2.Report.DataMember = oReporteAvisosFactura.DataMember
        Me.CodTipoVenta = pedido.CodTipoVenta
        Me.Run()
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/05/2013: Funcion para convertir un numero en letra
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & " pesos con " & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/05/2013: Funcion para obtener el descuento total de la factura "SiHay"
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Function GetDescuentoTotalFacturaExistenciaSH(ByVal dtDetalle As DataTable) As Decimal
        Dim DescTotal As Decimal = 0
        For Each row As DataRow In dtDetalle.Rows
            DescTotal += CDec(row!CantDescuentoSistema) + ((CDec(row!Total) - CDec(row!CantDescuentoSistema)) * (CDec(row!Descuento) / 100))
        Next
        Return DescTotal
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA LLenado de datos por medio de la tabla de pedidos
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Function LlenarTablaDetallePedidoSH(ByVal dtFacturaDetalle As DataTable, ByVal dtDetalle As DataTable) As DataTable

        Dim dtTemp As DataTable
        dtTemp = dtDetalle.Clone

        '--------------------------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: limpiamos el total de la factura
        '--------------------------------------------------------------------------------------------------------
        TotalFactura = Decimal.Zero

        For Each oRow As DataRow In dtFacturaDetalle.Rows

            Dim oNewRow As DataRow = dtTemp.NewRow

            With oNewRow
                !Cantidad = oRow!Cantidad
                !CodArticulo = oRow!CodArticulo
                !Descripcion = oRow!Descripcion
                !Numero = oRow!Numero
                !PrecioOferta = oRow!Preciooferta
                !Total = oRow!Total
                !Descuento = CDec(oRow!CantDescuentoSistema) + ((CDec(oRow!Total) - CDec(oRow!CantDescuentoSistema)) * (CDec(oRow!Descuento) / 100))

                '--------------------------------------------------------------------------------------------------------
                ' JNAVA 24.06.2015: Sumamos el total de la factura en base al detalle
                '--------------------------------------------------------------------------------------------------------
                TotalFactura += !Total
            End With
            dtTemp.Rows.Add(oNewRow)

        Next

        '--------------------------------------------------------------------------------------------------------
        ' JNAVA 24.06.2015: Truncamos el total de la factura para eliminar centavos de mas y lo ponemos el total
        '--------------------------------------------------------------------------------------------------------
        TotalFactura = Truncar(TotalFactura, 2)

        Return dtTemp

    End Function

#End Region

#Region "Ventas Electronicos"

    '-----------------------------------------------
    'JNAVA (07.12.2014): Venta de Electronicos
    '-----------------------------------------------
    Private Sub HayTelcel(ByVal DetalleFactura As DataTable, ByRef Telcel As Boolean, ByRef SoloTelcel As Boolean)

        Dim cCodigos As Integer = 0
        Dim cTelcel As Integer = 0

        Dim oArticulosMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo

        'Revisamos que el codigo del articulo sea o no Telcel 
        For Each oRow As DataRow In DetalleFactura.Rows

            'Sacamos los datos del codigo
            oArticulo = oArticulosMgr.Create
            oArticulosMgr.LoadInto(CStr(oRow!CodArticulo).Trim, oArticulo)

            'Si hay al menos un Telcel, lo agregamos al contador
            If oArticulo.CodElectronico = "12" Or oArticulo.CodElectronico = "22" Then
                'Contamos los codigos de telcel
                cTelcel += 1
            End If
            'Contamos todos los codigos de las facturas
            cCodigos += 1
        Next

        'Si los codigos de telcel son iguales al total de codigos, es que solo hay Telcel
        If cCodigos = cTelcel Then
            SoloTelcel = True
            Telcel = True
            Exit Sub 'No salimos
        Else 'De  lo contrario, hay otros codigos
            SoloTelcel = False
            'Si el contador de codigos telcel es mayor que cero, es por ke hay al menos un telcel
            If cTelcel > 0 Then
                Telcel = True
            Else 'De lo c telcelontrario no hay ningun
                Telcel = False
            End If
        End If

    End Sub

#End Region

#Region "DP Card Credit"
    '------------------------------------------------------------------------
    'JNAVA 23.06.2015: Function btener Total de factura en base al detalle (KARUM)
    '------------------------------------------------------------------------
    Private Function ObtenerTotalFacturaByDetalle(ByVal TotalArticulo As Decimal) As Decimal
        Dim decResult As Decimal


    End Function

#End Region

    Private Sub Detail_Format(sender As Object, e As System.EventArgs) Handles Detail.Format
        tbCodigo.Text = CLng(Me.tbCodigo.Text.Trim()).ToString()
    End Sub
End Class
