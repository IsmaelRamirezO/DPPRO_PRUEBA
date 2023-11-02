Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptCostosInventarios
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal almacen As String, ByVal fecha As DateTime)
        MyBase.New()
        InitializeComponent()
        txtSucursal.Text = almacen
        txtFecha.Text = fecha.ToString("dd/MM/yyyy HH:mm")
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private lblReporteCostoInventarios As Label = Nothing
    Private lblHora As Label = Nothing
    Private txtFecha As Label = Nothing
    Private lblAlmacen As Label = Nothing
    Private txtSucursal As Label = Nothing
    Private lblTotalPiezas As Label = Nothing
    Private txtTotalPiezas As TextBox = Nothing
    Private lblTotalCosto As Label = Nothing
    Private txtTotalCosto As TextBox = Nothing
    Private Shape1 As Shape = Nothing
    Private lblCodigo As TextBox = Nothing
    Private lblTotalArticulos As TextBox = Nothing
    Private lblTotalStock As TextBox = Nothing
    Private TextBox1 As TextBox = Nothing
    Private TextBox3 As TextBox = Nothing
    Private TextBox4 As TextBox = Nothing
    Private txtCodigo As TextBox = Nothing
    Private txtTotalArticulos As TextBox = Nothing
    Private txtTotalStock As TextBox = Nothing
    Private lblNumeroPagina As Label = Nothing
    Private txtPage As TextBox = Nothing
    Private txtPageCount As TextBox = Nothing
    Private lblDiagonal As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line2 As Line = Nothing
    Private lblFirmaManager As Label = Nothing
    Private lblFirmaAuditor As Label = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCostosInventarios))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotalStock = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblReporteCostoInventarios = New DataDynamics.ActiveReports.Label()
        Me.lblHora = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.Label()
        Me.lblAlmacen = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.Label()
        Me.lblTotalPiezas = New DataDynamics.ActiveReports.Label()
        Me.txtTotalPiezas = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotalCosto = New DataDynamics.ActiveReports.Label()
        Me.txtTotalCosto = New DataDynamics.ActiveReports.TextBox()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.lblFirmaManager = New DataDynamics.ActiveReports.Label()
        Me.lblFirmaAuditor = New DataDynamics.ActiveReports.Label()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotalArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.lblTotalStock = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblNumeroPagina = New DataDynamics.ActiveReports.Label()
        Me.txtPage = New DataDynamics.ActiveReports.TextBox()
        Me.txtPageCount = New DataDynamics.ActiveReports.TextBox()
        Me.lblDiagonal = New DataDynamics.ActiveReports.Label()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReporteCostoInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaAuditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumeroPagina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPageCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDiagonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnCount = 2
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtTotalArticulos, Me.txtTotalStock})
        Me.Detail.Height = 0.191!
        Me.Detail.Name = "Detail"
        '
        'txtCodigo
        '
        Me.txtCodigo.DataField = "CodArticulo"
        Me.txtCodigo.Height = 0.188!
        Me.txtCodigo.Left = 0.0!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "font-weight: normal; font-size: 6.75pt"
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 1.625!
        '
        'txtTotalArticulos
        '
        Me.txtTotalArticulos.DataField = "Libre"
        Me.txtTotalArticulos.Height = 0.188!
        Me.txtTotalArticulos.Left = 1.625!
        Me.txtTotalArticulos.Name = "txtTotalArticulos"
        Me.txtTotalArticulos.OutputFormat = resources.GetString("txtTotalArticulos.OutputFormat")
        Me.txtTotalArticulos.Style = "text-align: right; font-weight: normal; font-size: 6.75pt"
        Me.txtTotalArticulos.Text = Nothing
        Me.txtTotalArticulos.Top = 0.003!
        Me.txtTotalArticulos.Width = 0.875!
        '
        'txtTotalStock
        '
        Me.txtTotalStock.DataField = "Costo"
        Me.txtTotalStock.Height = 0.188!
        Me.txtTotalStock.Left = 2.5!
        Me.txtTotalStock.Name = "txtTotalStock"
        Me.txtTotalStock.OutputFormat = resources.GetString("txtTotalStock.OutputFormat")
        Me.txtTotalStock.Style = "text-align: right; font-weight: normal; font-size: 6.75pt"
        Me.txtTotalStock.Text = Nothing
        Me.txtTotalStock.Top = 0.003!
        Me.txtTotalStock.Width = 1.063!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReporteCostoInventarios, Me.lblHora, Me.txtFecha, Me.lblAlmacen, Me.txtSucursal, Me.lblTotalPiezas, Me.txtTotalPiezas, Me.lblTotalCosto, Me.txtTotalCosto, Me.Shape1})
        Me.ReportHeader.Height = 1.208333!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblReporteCostoInventarios
        '
        Me.lblReporteCostoInventarios.Height = 0.3125!
        Me.lblReporteCostoInventarios.HyperLink = Nothing
        Me.lblReporteCostoInventarios.Left = 1.3125!
        Me.lblReporteCostoInventarios.Name = "lblReporteCostoInventarios"
        Me.lblReporteCostoInventarios.Style = "text-align: center; font-weight: bold; font-size: 14pt"
        Me.lblReporteCostoInventarios.Text = "Reporte Costo Inventarios"
        Me.lblReporteCostoInventarios.Top = 0.0!
        Me.lblReporteCostoInventarios.Width = 4.4375!
        '
        'lblHora
        '
        Me.lblHora.Height = 0.1875!
        Me.lblHora.HyperLink = Nothing
        Me.lblHora.Left = 5.6455!
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Style = "font-weight: bold"
        Me.lblHora.Text = "Fecha:"
        Me.lblHora.Top = 0.437!
        Me.lblHora.Width = 0.4375!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.HyperLink = Nothing
        Me.txtFecha.Left = 6.083!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-weight: bold; font-size: 9.75pt"
        Me.txtFecha.Text = ""
        Me.txtFecha.Top = 0.437!
        Me.txtFecha.Width = 1.2925!
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblAlmacen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblAlmacen.Height = 0.1875!
        Me.lblAlmacen.HyperLink = Nothing
        Me.lblAlmacen.Left = 0.0625!
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Style = "font-weight: bold"
        Me.lblAlmacen.Text = "Sucursal:"
        Me.lblAlmacen.Top = 0.4375!
        Me.lblAlmacen.Width = 0.875!
        '
        'txtSucursal
        '
        Me.txtSucursal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSucursal.Height = 0.1875!
        Me.txtSucursal.HyperLink = Nothing
        Me.txtSucursal.Left = 0.9375!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Style = "font-weight: bold; font-size: 9.75pt"
        Me.txtSucursal.Text = ""
        Me.txtSucursal.Top = 0.4375!
        Me.txtSucursal.Width = 4.0625!
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalPiezas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalPiezas.Height = 0.1875!
        Me.lblTotalPiezas.HyperLink = Nothing
        Me.lblTotalPiezas.Left = 0.0625!
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Style = "font-weight: bold; font-size: 9.75pt"
        Me.lblTotalPiezas.Text = "Total Piezas:"
        Me.lblTotalPiezas.Top = 0.625!
        Me.lblTotalPiezas.Width = 0.875!
        '
        'txtTotalPiezas
        '
        Me.txtTotalPiezas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalPiezas.DataField = "Libre"
        Me.txtTotalPiezas.Height = 0.1875!
        Me.txtTotalPiezas.Left = 0.9375!
        Me.txtTotalPiezas.Name = "txtTotalPiezas"
        Me.txtTotalPiezas.OutputFormat = resources.GetString("txtTotalPiezas.OutputFormat")
        Me.txtTotalPiezas.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalPiezas.Text = Nothing
        Me.txtTotalPiezas.Top = 0.625!
        Me.txtTotalPiezas.Width = 4.0625!
        '
        'lblTotalCosto
        '
        Me.lblTotalCosto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalCosto.Height = 0.1875!
        Me.lblTotalCosto.HyperLink = Nothing
        Me.lblTotalCosto.Left = 0.0625!
        Me.lblTotalCosto.Name = "lblTotalCosto"
        Me.lblTotalCosto.Style = "font-weight: bold; font-size: 9.75pt"
        Me.lblTotalCosto.Text = "Total Costo:"
        Me.lblTotalCosto.Top = 0.8125!
        Me.lblTotalCosto.Width = 0.875!
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.DataField = "Costo"
        Me.txtTotalCosto.Height = 0.1875!
        Me.txtTotalCosto.Left = 0.9375!
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.OutputFormat = resources.GetString("txtTotalCosto.OutputFormat")
        Me.txtTotalCosto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalCosto.Text = Nothing
        Me.txtTotalCosto.Top = 0.8125!
        Me.txtTotalCosto.Width = 4.0625!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.5625!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.4375!
        Me.Shape1.Width = 4.9375!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.Line2, Me.lblFirmaManager, Me.lblFirmaAuditor})
        Me.ReportFooter.Height = 0.5819445!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.6319444!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1939444!
        Me.Line1.Width = 2.3125!
        Me.Line1.X1 = 0.6319444!
        Me.Line1.X2 = 2.944444!
        Me.Line1.Y1 = 0.1939444!
        Me.Line1.Y2 = 0.1939444!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 4.570446!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.1939444!
        Me.Line2.Width = 2.3125!
        Me.Line2.X1 = 4.570446!
        Me.Line2.X2 = 6.882946!
        Me.Line2.Y1 = 0.1939444!
        Me.Line2.Y2 = 0.1939444!
        '
        'lblFirmaManager
        '
        Me.lblFirmaManager.Height = 0.1875!
        Me.lblFirmaManager.HyperLink = Nothing
        Me.lblFirmaManager.Left = 1.25!
        Me.lblFirmaManager.Name = "lblFirmaManager"
        Me.lblFirmaManager.Style = "font-weight: bold; font-size: 9.75pt"
        Me.lblFirmaManager.Text = "Firma Manager"
        Me.lblFirmaManager.Top = 0.312!
        Me.lblFirmaManager.Width = 1.0625!
        '
        'lblFirmaAuditor
        '
        Me.lblFirmaAuditor.Height = 0.1875!
        Me.lblFirmaAuditor.HyperLink = Nothing
        Me.lblFirmaAuditor.Left = 5.251!
        Me.lblFirmaAuditor.Name = "lblFirmaAuditor"
        Me.lblFirmaAuditor.Style = "font-weight: bold; font-size: 9.75pt"
        Me.lblFirmaAuditor.Text = "Firma Auditor"
        Me.lblFirmaAuditor.Top = 0.312!
        Me.lblFirmaAuditor.Width = 1.0625!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCodigo, Me.lblTotalArticulos, Me.lblTotalStock, Me.TextBox1, Me.TextBox3, Me.TextBox4})
        Me.PageHeader.Height = 0.198!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblCodigo
        '
        Me.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Height = 0.188!
        Me.lblCodigo.Left = 0.0!
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.Top = 0.0!
        Me.lblCodigo.Width = 1.625!
        '
        'lblTotalArticulos
        '
        Me.lblTotalArticulos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArticulos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArticulos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArticulos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArticulos.Height = 0.188!
        Me.lblTotalArticulos.Left = 1.625!
        Me.lblTotalArticulos.Name = "lblTotalArticulos"
        Me.lblTotalArticulos.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.lblTotalArticulos.Text = "Total Artículos"
        Me.lblTotalArticulos.Top = 0.0!
        Me.lblTotalArticulos.Width = 0.875!
        '
        'lblTotalStock
        '
        Me.lblTotalStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalStock.Height = 0.188!
        Me.lblTotalStock.Left = 2.5!
        Me.lblTotalStock.Name = "lblTotalStock"
        Me.lblTotalStock.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.lblTotalStock.Text = "Total Stock"
        Me.lblTotalStock.Top = 0.0!
        Me.lblTotalStock.Width = 1.063!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Height = 0.188!
        Me.TextBox1.Left = 3.813!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.TextBox1.Text = "Código"
        Me.TextBox1.Top = 0.01!
        Me.TextBox1.Width = 1.625!
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Height = 0.188!
        Me.TextBox3.Left = 5.438001!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.TextBox3.Text = "Total Artículos"
        Me.TextBox3.Top = 0.01!
        Me.TextBox3.Width = 0.875!
        '
        'TextBox4
        '
        Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox4.Height = 0.188!
        Me.TextBox4.Left = 6.313001!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "text-align: center; font-weight: normal; font-size: 6.75pt; font-family: Microsof" & _
    "t Sans Serif"
        Me.TextBox4.Text = "Total Stock"
        Me.TextBox4.Top = 0.01!
        Me.TextBox4.Width = 1.063!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblNumeroPagina, Me.txtPage, Me.txtPageCount, Me.lblDiagonal})
        Me.PageFooter.Height = 0.1875!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblNumeroPagina
        '
        Me.lblNumeroPagina.Height = 0.1875!
        Me.lblNumeroPagina.HyperLink = Nothing
        Me.lblNumeroPagina.Left = 4.438!
        Me.lblNumeroPagina.Name = "lblNumeroPagina"
        Me.lblNumeroPagina.Style = "font-weight: bold; font-size: 8.25pt"
        Me.lblNumeroPagina.Text = "Número de Pagina"
        Me.lblNumeroPagina.Top = 0.0!
        Me.lblNumeroPagina.Width = 1.0625!
        '
        'txtPage
        '
        Me.txtPage.Height = 0.1875!
        Me.txtPage.Left = 5.5005!
        Me.txtPage.Name = "txtPage"
        Me.txtPage.OutputFormat = resources.GetString("txtPage.OutputFormat")
        Me.txtPage.Style = "text-align: right; font-size: 8.25pt"
        Me.txtPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPage.Text = Nothing
        Me.txtPage.Top = 0.0!
        Me.txtPage.Width = 0.8125!
        '
        'txtPageCount
        '
        Me.txtPageCount.Height = 0.1875!
        Me.txtPageCount.Left = 6.438!
        Me.txtPageCount.Name = "txtPageCount"
        Me.txtPageCount.Style = "font-size: 8.25pt"
        Me.txtPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.txtPageCount.Text = Nothing
        Me.txtPageCount.Top = 0.0!
        Me.txtPageCount.Width = 0.9375!
        '
        'lblDiagonal
        '
        Me.lblDiagonal.Height = 0.1875!
        Me.lblDiagonal.HyperLink = Nothing
        Me.lblDiagonal.Left = 6.313!
        Me.lblDiagonal.Name = "lblDiagonal"
        Me.lblDiagonal.Style = ""
        Me.lblDiagonal.Text = "/"
        Me.lblDiagonal.Top = 0.0!
        Me.lblDiagonal.Width = 0.125!
        '
        'rptCostosInventarios
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.614584!
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
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReporteCostoInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaAuditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumeroPagina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPageCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDiagonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
