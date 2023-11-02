Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasTotalesporHora
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim vlFact As Integer, vlVisible As Boolean

    Public Sub New(ByVal CodCaja As String, ByVal FechaDel As DateTime, ByVal FechaAl As DateTime, ByVal horade As DateTime, ByVal horaal As DateTime, ByVal dsVentasTotales As DataSet)
        MyBase.New()
        InitializeComponent()

        Try

            txtCaja.Text = CodCaja
            txtFecha.Text = Now.ToShortTimeString
            txtFechaDel.Text = FechaDel
            txtFechaAl.Text = FechaAl
            txtHoraDel.Text = horade.ToShortTimeString
            txtHoralAl.Text = horaal.ToShortTimeString
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            Dim oAlmacen As Almacen
            Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
            oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

            If Not oAlmacen Is Nothing Then

                txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

            Else

                txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

            End If

            DataSource = dsVentasTotales
            DataMember = dsVentasTotales.Tables(0).TableName

            vlFact = 0
            vlVisible = True

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtCaja As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private txtHoraDel As TextBox = Nothing
	Private txtHoralAl As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtPagina As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private Label20 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtDescuento As TextBox = Nothing
	Private txtVendedor As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtTipoVenta As TextBox = Nothing
	Private txtNotaCredito As TextBox = Nothing
	Private txtstatus As TextBox = Nothing
	Private TxtCodFP As TextBox = Nothing
	Private TxtMonto As TextBox = Nothing
	Private txtfoliosap As TextBox = Nothing
	Private TxtSArticulos As TextBox = Nothing
	Private txtSImporte As TextBox = Nothing
	Private txtSDescuento As TextBox = Nothing
	Private txtSMonto As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasTotalesporHora))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.txtTipoVenta = New DataDynamics.ActiveReports.TextBox()
        Me.txtNotaCredito = New DataDynamics.ActiveReports.TextBox()
        Me.txtstatus = New DataDynamics.ActiveReports.TextBox()
        Me.TxtCodFP = New DataDynamics.ActiveReports.TextBox()
        Me.TxtMonto = New DataDynamics.ActiveReports.TextBox()
        Me.txtfoliosap = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
        Me.txtHoraDel = New DataDynamics.ActiveReports.TextBox()
        Me.txtHoralAl = New DataDynamics.ActiveReports.TextBox()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtPagina = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.TxtSArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtSImporte = New DataDynamics.ActiveReports.TextBox()
        Me.txtSDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.txtSMonto = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodFP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfoliosap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoraDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoralAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtCantidad, Me.txtImporte, Me.txtDescuento, Me.txtVendedor, Me.txtCliente, Me.txtTipoVenta, Me.txtNotaCredito, Me.txtstatus, Me.TxtCodFP, Me.TxtMonto, Me.txtfoliosap})
        Me.Detail.Height = 0.2076389!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'txtFolio
        '
        Me.txtFolio.DataField = "Folio"
        Me.txtFolio.Height = 0.2!
        Me.txtFolio.Left = 0.0!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.txtFolio.Text = "0"
        Me.txtFolio.Top = 0.0!
        Me.txtFolio.Width = 0.472441!
        '
        'txtCantidad
        '
        Me.txtCantidad.DataField = "cantidad"
        Me.txtCantidad.Height = 0.2!
        Me.txtCantidad.Left = 1.159448!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
        Me.txtCantidad.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.txtCantidad.Text = "0"
        Me.txtCantidad.Top = 0.0!
        Me.txtCantidad.Width = 0.6919295!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "total"
        Me.txtImporte.Height = 0.2!
        Me.txtImporte.Left = 1.851378!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
        Me.txtImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.txtImporte.Text = "0"
        Me.txtImporte.Top = 0.0!
        Me.txtImporte.Width = 0.8100396!
        '
        'txtDescuento
        '
        Me.txtDescuento.DataField = "desctotal"
        Me.txtDescuento.Height = 0.2!
        Me.txtDescuento.Left = 2.661417!
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.OutputFormat = resources.GetString("txtDescuento.OutputFormat")
        Me.txtDescuento.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.txtDescuento.Text = "0"
        Me.txtDescuento.Top = 0.0!
        Me.txtDescuento.Width = 0.8794292!
        '
        'txtVendedor
        '
        Me.txtVendedor.DataField = "CodVendedor"
        Me.txtVendedor.Height = 0.2!
        Me.txtVendedor.Left = 4.75!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.txtVendedor.Text = Nothing
        Me.txtVendedor.Top = 0.0!
        Me.txtVendedor.Width = 0.7723104!
        '
        'txtCliente
        '
        Me.txtCliente.DataField = "ClienteID"
        Me.txtCliente.Height = 0.2!
        Me.txtCliente.Left = 5.52231!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.txtCliente.Text = Nothing
        Me.txtCliente.Top = 0.0!
        Me.txtCliente.Width = 0.8116805!
        '
        'txtTipoVenta
        '
        Me.txtTipoVenta.DataField = "CodTipoVenta"
        Me.txtTipoVenta.Height = 0.2!
        Me.txtTipoVenta.Left = 6.333992!
        Me.txtTipoVenta.Name = "txtTipoVenta"
        Me.txtTipoVenta.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.txtTipoVenta.Text = Nothing
        Me.txtTipoVenta.Top = 0.0!
        Me.txtTipoVenta.Width = 0.3523626!
        '
        'txtNotaCredito
        '
        Me.txtNotaCredito.DataField = "NotaCreditoID"
        Me.txtNotaCredito.Height = 0.2!
        Me.txtNotaCredito.Left = 6.686354!
        Me.txtNotaCredito.Name = "txtNotaCredito"
        Me.txtNotaCredito.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.txtNotaCredito.Text = Nothing
        Me.txtNotaCredito.Top = 0.0!
        Me.txtNotaCredito.Width = 0.4048567!
        '
        'txtstatus
        '
        Me.txtstatus.DataField = "status"
        Me.txtstatus.Height = 0.2!
        Me.txtstatus.Left = 7.091208!
        Me.txtstatus.Name = "txtstatus"
        Me.txtstatus.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: top"
        Me.txtstatus.Text = Nothing
        Me.txtstatus.Top = 0.0!
        Me.txtstatus.Width = 0.4109321!
        '
        'TxtCodFP
        '
        Me.TxtCodFP.DataField = "CodFormasPago"
        Me.TxtCodFP.Height = 0.2!
        Me.TxtCodFP.Left = 3.540846!
        Me.TxtCodFP.Name = "TxtCodFP"
        Me.TxtCodFP.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.TxtCodFP.Text = Nothing
        Me.TxtCodFP.Top = 0.0!
        Me.TxtCodFP.Width = 0.551181!
        '
        'TxtMonto
        '
        Me.TxtMonto.DataField = "MontoPago"
        Me.TxtMonto.Height = 0.2!
        Me.TxtMonto.Left = 4.092028!
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.OutputFormat = resources.GetString("TxtMonto.OutputFormat")
        Me.TxtMonto.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
        Me.TxtMonto.Text = Nothing
        Me.TxtMonto.Top = 0.0!
        Me.TxtMonto.Width = 0.6579724!
        '
        'txtfoliosap
        '
        Me.txtfoliosap.DataField = "Referencia"
        Me.txtfoliosap.Height = 0.2007874!
        Me.txtfoliosap.Left = 0.472441!
        Me.txtfoliosap.Name = "txtfoliosap"
        Me.txtfoliosap.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.txtfoliosap.Text = "0"
        Me.txtfoliosap.Top = 0.0!
        Me.txtfoliosap.Width = 0.6771654!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.txtCaja, Me.txtFecha, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.txtFechaDel, Me.txtFechaAl, Me.txtHoraDel, Me.txtHoralAl, Me.Label7, Me.txtSucursal, Me.txtPagina, Me.Label8})
        Me.ReportHeader.Height = 0.8319445!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.8661417!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 7.611548!
        '
        'Label1
        '
        Me.Label1.Height = 0.2!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.519685!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = ""
        Me.Label1.Text = "REPORTE DE VENTAS EN TOTALES"
        Me.Label1.Top = 0.03937007!
        Me.Label1.Width = 2.440945!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.3543307!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Caja.:"
        Me.Label2.Top = 0.3149606!
        Me.Label2.Width = 0.4330709!
        '
        'txtCaja
        '
        Me.txtCaja.Height = 0.2!
        Me.txtCaja.Left = 0.847441!
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Text = "txtCaja"
        Me.txtCaja.Top = 0.3149606!
        Me.txtCaja.Width = 0.472441!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.2!
        Me.txtFecha.Left = 0.07874014!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Text = "txtFecha"
        Me.txtFecha.Top = 0.03937007!
        Me.txtFecha.Width = 1.0!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.449803!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = ""
        Me.Label3.Text = "De.:"
        Me.Label3.Top = 0.3149606!
        Me.Label3.Width = 0.2918307!
        '
        'Label4
        '
        Me.Label4.Height = 0.2!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.630905!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "Al.:"
        Me.Label4.Top = 0.3149606!
        Me.Label4.Width = 0.2760828!
        '
        'Label5
        '
        Me.Label5.Height = 0.2!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 3.737697!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = ""
        Me.Label5.Text = "en el Transcurso De.:"
        Me.Label5.Top = 0.3149606!
        Me.Label5.Width = 1.377953!
        '
        'Label6
        '
        Me.Label6.Height = 0.2!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.863681!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = ""
        Me.Label6.Text = "A las.:"
        Me.Label6.Top = 0.3149606!
        Me.Label6.Width = 0.4808071!
        '
        'txtFechaDel
        '
        Me.txtFechaDel.Height = 0.2!
        Me.txtFechaDel.Left = 1.764764!
        Me.txtFechaDel.Name = "txtFechaDel"
        Me.txtFechaDel.OutputFormat = resources.GetString("txtFechaDel.OutputFormat")
        Me.txtFechaDel.Text = "15/02/2005"
        Me.txtFechaDel.Top = 0.3149606!
        Me.txtFechaDel.Width = 0.7480313!
        '
        'txtFechaAl
        '
        Me.txtFechaAl.Height = 0.2!
        Me.txtFechaAl.Left = 2.9375!
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.OutputFormat = resources.GetString("txtFechaAl.OutputFormat")
        Me.txtFechaAl.Text = "01/03/2005"
        Me.txtFechaAl.Top = 0.3125!
        Me.txtFechaAl.Width = 0.748032!
        '
        'txtHoraDel
        '
        Me.txtHoraDel.Height = 0.2!
        Me.txtHoraDel.Left = 5.11565!
        Me.txtHoraDel.Name = "txtHoraDel"
        Me.txtHoraDel.Text = "10:43:42"
        Me.txtHoraDel.Top = 0.3149606!
        Me.txtHoraDel.Width = 0.7086618!
        '
        'txtHoralAl
        '
        Me.txtHoralAl.Height = 0.2!
        Me.txtHoralAl.Left = 6.340552!
        Me.txtHoralAl.Name = "txtHoralAl"
        Me.txtHoralAl.Text = "10:43:42"
        Me.txtHoralAl.Top = 0.3149606!
        Me.txtHoralAl.Width = 0.7086618!
        '
        'Label7
        '
        Me.Label7.Height = 0.2!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 2.362205!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = ""
        Me.Label7.Text = "Sucursal.:"
        Me.Label7.Top = 0.5905511!
        Me.Label7.Width = 0.6692913!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 3.070866!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Text = "05 TENIENTE AZUETA"
        Me.txtSucursal.Top = 0.5905511!
        Me.txtSucursal.Width = 2.480315!
        '
        'txtPagina
        '
        Me.txtPagina.Height = 0.2!
        Me.txtPagina.Left = 6.729331!
        Me.txtPagina.Name = "txtPagina"
        Me.txtPagina.Style = "text-align: right"
        Me.txtPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPagina.Text = "1"
        Me.txtPagina.Top = 0.0625!
        Me.txtPagina.Width = 0.629921!
        '
        'Label8
        '
        Me.Label8.Height = 0.2!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.375!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = ""
        Me.Label8.Text = "Pág."
        Me.Label8.Top = 0.06250001!
        Me.Label8.Width = 0.3543305!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtSArticulos, Me.txtSImporte, Me.txtSDescuento, Me.txtSMonto})
        Me.ReportFooter.Height = 0.5097222!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'TxtSArticulos
        '
        Me.TxtSArticulos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.TxtSArticulos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TxtSArticulos.Height = 0.2!
        Me.TxtSArticulos.Left = 1.371!
        Me.TxtSArticulos.Name = "TxtSArticulos"
        Me.TxtSArticulos.OutputFormat = resources.GetString("TxtSArticulos.OutputFormat")
        Me.TxtSArticulos.Style = "text-align: right; font-size: 8.25pt"
        Me.TxtSArticulos.Text = "0"
        Me.TxtSArticulos.Top = 0.0!
        Me.TxtSArticulos.Width = 0.488681!
        '
        'txtSImporte
        '
        Me.txtSImporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.txtSImporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSImporte.Height = 0.2!
        Me.txtSImporte.Left = 1.861978!
        Me.txtSImporte.Name = "txtSImporte"
        Me.txtSImporte.OutputFormat = resources.GetString("txtSImporte.OutputFormat")
        Me.txtSImporte.Style = "text-align: right; font-size: 8.25pt"
        Me.txtSImporte.Text = "0"
        Me.txtSImporte.Top = 0.0!
        Me.txtSImporte.Width = 0.7690223!
        '
        'txtSDescuento
        '
        Me.txtSDescuento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.txtSDescuento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSDescuento.Height = 0.2!
        Me.txtSDescuento.Left = 2.732958!
        Me.txtSDescuento.Name = "txtSDescuento"
        Me.txtSDescuento.OutputFormat = resources.GetString("txtSDescuento.OutputFormat")
        Me.txtSDescuento.Style = "text-align: right; font-size: 8.25pt"
        Me.txtSDescuento.Text = "0"
        Me.txtSDescuento.Top = 0.0!
        Me.txtSDescuento.Width = 0.808042!
        '
        'txtSMonto
        '
        Me.txtSMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
        Me.txtSMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSMonto.DataField = "MontoPago"
        Me.txtSMonto.Height = 0.2!
        Me.txtSMonto.Left = 3.984!
        Me.txtSMonto.Name = "txtSMonto"
        Me.txtSMonto.OutputFormat = resources.GetString("txtSMonto.OutputFormat")
        Me.txtSMonto.Style = "text-align: right; font-size: 8.25pt"
        Me.txtSMonto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtSMonto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtSMonto.Text = "0"
        Me.txtSMonto.Top = 0.0!
        Me.txtSMonto.Width = 0.80315!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20})
        Me.PageHeader.Height = 0.1979167!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label9
        '
        Me.Label9.Height = 0.2!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label9.Text = "FOLIO"
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 0.472441!
        '
        'Label10
        '
        Me.Label10.Height = 0.2!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 1.132301!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label10.Text = "ARTICULOS"
        Me.Label10.Top = 0.0!
        Me.Label10.Width = 0.7480313!
        '
        'Label11
        '
        Me.Label11.Height = 0.2!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 1.880332!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label11.Text = "IMPORTE"
        Me.Label11.Top = 0.0!
        Me.Label11.Width = 0.8267716!
        '
        'Label12
        '
        Me.Label12.Height = 0.2!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 2.707103!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label12.Text = "DESCUENTO"
        Me.Label12.Top = 0.0!
        Me.Label12.Width = 0.8567917!
        '
        'Label13
        '
        Me.Label13.Height = 0.2!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 3.563894!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label13.Text = "F. PAGO"
        Me.Label13.Top = 0.0!
        Me.Label13.Width = 0.6205707!
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 4.921178!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label14.Text = "VENDEDOR"
        Me.Label14.Top = 0.0!
        Me.Label14.Width = 0.753691!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 5.67487!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label15.Text = "CLIENTE"
        Me.Label15.Top = 0.0!
        Me.Label15.Width = 0.5774283!
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 6.252297!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label16.Text = "T. VTA."
        Me.Label16.Top = 0.0!
        Me.Label16.Width = 0.476213!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 4.184465!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label17.Text = "MONTO"
        Me.Label17.Top = 0.0!
        Me.Label17.Width = 0.7367125!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 6.72851!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label18.Text = "N.C."
        Me.Label18.Top = 0.0!
        Me.Label18.Width = 0.3581037!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 7.086611!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label19.Text = "CANC."
        Me.Label19.Top = 0.0!
        Me.Label19.Width = 0.4855647!
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.472441!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
        Me.Label20.Text = "FOLIO SAP"
        Me.Label20.Top = 0.0!
        Me.Label20.Width = 0.6771654!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Visible = False
        '
        'rptVentasTotalesporHora
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.645833!
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
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodFP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfoliosap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoraDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoralAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        If vlFact = txtFolio.Text Then
            vlVisible = False
        Else
            TxtSArticulos.Text = FormatNumber(CDbl(TxtSArticulos.Text) + CDbl(txtCantidad.Text), 0)
            txtSImporte.Text = FormatCurrency(CDbl(txtSImporte.Text) + CDbl(txtImporte.Text), 2)
            txtSDescuento.Text = FormatCurrency(CDbl(txtSDescuento.Text) + CDbl(txtDescuento.Text), 2)
            vlVisible = True
        End If
        txtFolio.Visible = vlVisible
        txtCantidad.Visible = vlVisible
        txtImporte.Visible = vlVisible
        txtDescuento.Visible = vlVisible
        txtVendedor.Visible = vlVisible
        txtCliente.Visible = vlVisible
        txtTipoVenta.Visible = vlVisible
        txtNotaCredito.Visible = vlVisible
        txtstatus.Visible = vlVisible
        txtfoliosap.Visible = vlVisible
        vlFact = txtFolio.Text
    End Sub

    Private Sub rptVentasTotalesporHora_ReportStart(sender As System.Object, e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
