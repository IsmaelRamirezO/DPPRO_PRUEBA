Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja



Public Class ValeCajaNotaCredito
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private tbDocumentoTipo As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private tbDocumentoFolio As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private tbDocumentoImporte As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private lbTipoVenta As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Line12 As Line = Nothing
	Private tbFactura As TextBox = Nothing
	Private tbTipoVentaMonto As TextBox = Nothing
	Private tbTCredito As TextBox = Nothing
	Private tbNoTarjetaCredito As TextBox = Nothing
	Private tbNoAutorizacionTDC As TextBox = Nothing
	Private tbValeCaja As TextBox = Nothing
	Private tbTotalTipoVentaMonto As TextBox = Nothing
	Private tbTotalTDC As TextBox = Nothing
	Private tbTotalValeCaja As TextBox = Nothing
	Private Line8 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaNotaCredito))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoTipo = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.tbDocumentoImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.lbTipoVenta = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.tbFactura = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoVentaMonto = New DataDynamics.ActiveReports.TextBox()
            Me.tbTCredito = New DataDynamics.ActiveReports.TextBox()
            Me.tbNoTarjetaCredito = New DataDynamics.ActiveReports.TextBox()
            Me.tbNoAutorizacionTDC = New DataDynamics.ActiveReports.TextBox()
            Me.tbValeCaja = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalTipoVentaMonto = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalTDC = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalValeCaja = New DataDynamics.ActiveReports.TextBox()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoTipo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDocumentoImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lbTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoVentaMonto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNoTarjetaCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNoAutorizacionTDC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbValeCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalTipoVentaMonto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalTDC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalValeCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFactura, Me.tbTipoVentaMonto, Me.tbTCredito, Me.tbNoTarjetaCredito, Me.tbNoAutorizacionTDC, Me.tbValeCaja})
            Me.Detail.Height = 0.2388889!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.tbCliente, Me.tbFolio, Me.tbFecha, Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte, Me.Label7, Me.Label8, Me.lbTipoVenta, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Line12})
            Me.PageHeader.Height = 1.697222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTotalTipoVentaMonto, Me.tbTotalTDC, Me.tbTotalValeCaja, Me.Line8})
            Me.GroupFooter1.Height = 0.28125!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.647637!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label1.Text = "Vale de Caja"
            Me.Label1.Top = 0.07381889!
            Me.Label1.Width = 1.875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.210138!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Folio :"
            Me.Label2.Top = 0.3238189!
            Me.Label2.Width = 0.4375!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 5.210138!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label3.Text = "Fecha :"
            Me.Label3.Top = 0.573819!
            Me.Label3.Width = 0.5!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.1875!
            Me.tbCliente.Left = 0.125!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbCliente.Text = "tbCliente"
            Me.tbCliente.Top = 0.5!
            Me.tbCliente.Width = 3.5!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 5.75!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFolio.Text = "tbFolio"
            Me.tbFolio.Top = 0.3125!
            Me.tbFolio.Width = 0.875!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 5.75!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFecha.Text = "tbFecha"
            Me.tbFecha.Top = 0.5625!
            Me.tbFecha.Width = 0.9375!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.1476378!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Docto. Origen :"
            Me.Label4.Top = 0.8863187!
            Me.Label4.Width = 1!
            '
            'tbDocumentoTipo
            '
            Me.tbDocumentoTipo.Height = 0.1875!
            Me.tbDocumentoTipo.Left = 1.1875!
            Me.tbDocumentoTipo.Name = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoTipo.Text = "tbDocumentoTipo"
            Me.tbDocumentoTipo.Top = 0.875!
            Me.tbDocumentoTipo.Width = 1.0625!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.335137!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label5.Text = "Folio :"
            Me.Label5.Top = 0.8863187!
            Me.Label5.Width = 0.4375!
            '
            'tbDocumentoFolio
            '
            Me.tbDocumentoFolio.Height = 0.1875!
            Me.tbDocumentoFolio.Left = 2.8125!
            Me.tbDocumentoFolio.Name = "tbDocumentoFolio"
            Me.tbDocumentoFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoFolio.Text = "tbDocumentoFolio"
            Me.tbDocumentoFolio.Top = 0.875!
            Me.tbDocumentoFolio.Width = 1.0625!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.960138!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label6.Text = "Importe :"
            Me.Label6.Top = 0.8863187!
            Me.Label6.Width = 0.6875!
            '
            'tbDocumentoImporte
            '
            Me.tbDocumentoImporte.Height = 0.1875!
            Me.tbDocumentoImporte.Left = 4.6875!
            Me.tbDocumentoImporte.Name = "tbDocumentoImporte"
            Me.tbDocumentoImporte.OutputFormat = resources.GetString("tbDocumentoImporte.OutputFormat")
            Me.tbDocumentoImporte.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbDocumentoImporte.Text = "tbDocumentoImporte"
            Me.tbDocumentoImporte.Top = 0.875!
            Me.tbDocumentoImporte.Width = 1.25!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.1476378!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label7.Text = "Movimientos :"
            Me.Label7.Top = 1.261319!
            Me.Label7.Width = 1!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.1476378!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label8.Text = "Factura"
            Me.Label8.Top = 1.511319!
            Me.Label8.Width = 0.5625!
            '
            'lbTipoVenta
            '
            Me.lbTipoVenta.Height = 0.1875!
            Me.lbTipoVenta.HyperLink = Nothing
            Me.lbTipoVenta.Left = 1.210138!
            Me.lbTipoVenta.Name = "lbTipoVenta"
            Me.lbTipoVenta.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.lbTipoVenta.Text = "CDT o DPVale"
            Me.lbTipoVenta.Top = 1.511319!
            Me.lbTipoVenta.Width = 0.625!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.125!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label9.Text = "TDC"
            Me.Label9.Top = 1.5!
            Me.Label9.Width = 0.3125!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label10.Text = "No. Tarjeta"
            Me.Label10.Top = 1.5!
            Me.Label10.Width = 0.75!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 4.625!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label11.Text = "No. Autorización"
            Me.Label11.Top = 1.5!
            Me.Label11.Width = 1.125!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 6!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label12.Text = "Vale Caja"
            Me.Label12.Top = 1.5!
            Me.Label12.Width = 0.6875!
            '
            'Line12
            '
            Me.Line12.Height = 0!
            Me.Line12.Left = 0!
            Me.Line12.LineWeight = 3!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0!
            Me.Line12.Width = 6.619094!
            Me.Line12.X1 = 0!
            Me.Line12.X2 = 6.619094!
            Me.Line12.Y1 = 0!
            Me.Line12.Y2 = 0!
            '
            'tbFactura
            '
            Me.tbFactura.Height = 0.1875!
            Me.tbFactura.Left = 0.125!
            Me.tbFactura.Name = "tbFactura"
            Me.tbFactura.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFactura.Text = "tbFactura"
            Me.tbFactura.Top = 0!
            Me.tbFactura.Width = 0.875!
            '
            'tbTipoVentaMonto
            '
            Me.tbTipoVentaMonto.Height = 0.1875!
            Me.tbTipoVentaMonto.Left = 0.875!
            Me.tbTipoVentaMonto.Name = "tbTipoVentaMonto"
            Me.tbTipoVentaMonto.OutputFormat = resources.GetString("tbTipoVentaMonto.OutputFormat")
            Me.tbTipoVentaMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTipoVentaMonto.Text = "tbTipoVentaMonto"
            Me.tbTipoVentaMonto.Top = 0!
            Me.tbTipoVentaMonto.Width = 0.8125!
            '
            'tbTCredito
            '
            Me.tbTCredito.Height = 0.1875!
            Me.tbTCredito.Left = 1.75!
            Me.tbTCredito.Name = "tbTCredito"
            Me.tbTCredito.OutputFormat = resources.GetString("tbTCredito.OutputFormat")
            Me.tbTCredito.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTCredito.Text = "tbTCredito"
            Me.tbTCredito.Top = 0!
            Me.tbTCredito.Width = 0.8125!
            '
            'tbNoTarjetaCredito
            '
            Me.tbNoTarjetaCredito.Height = 0.1875!
            Me.tbNoTarjetaCredito.Left = 2.875!
            Me.tbNoTarjetaCredito.Name = "tbNoTarjetaCredito"
            Me.tbNoTarjetaCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbNoTarjetaCredito.Text = "tbNoTarjetaCredito"
            Me.tbNoTarjetaCredito.Top = 0!
            Me.tbNoTarjetaCredito.Width = 1.75!
            '
            'tbNoAutorizacionTDC
            '
            Me.tbNoAutorizacionTDC.Height = 0.1875!
            Me.tbNoAutorizacionTDC.Left = 4.625!
            Me.tbNoAutorizacionTDC.Name = "tbNoAutorizacionTDC"
            Me.tbNoAutorizacionTDC.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbNoAutorizacionTDC.Text = "tbNoAutorizacionTDC"
            Me.tbNoAutorizacionTDC.Top = 0!
            Me.tbNoAutorizacionTDC.Width = 1.8125!
            '
            'tbValeCaja
            '
            Me.tbValeCaja.Height = 0.1875!
            Me.tbValeCaja.Left = 5.8125!
            Me.tbValeCaja.Name = "tbValeCaja"
            Me.tbValeCaja.OutputFormat = resources.GetString("tbValeCaja.OutputFormat")
            Me.tbValeCaja.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbValeCaja.Text = "tbValeCaja"
            Me.tbValeCaja.Top = 0!
            Me.tbValeCaja.Width = 0.8125!
            '
            'tbTotalTipoVentaMonto
            '
            Me.tbTotalTipoVentaMonto.Height = 0.1875!
            Me.tbTotalTipoVentaMonto.Left = 0.5!
            Me.tbTotalTipoVentaMonto.Name = "tbTotalTipoVentaMonto"
            Me.tbTotalTipoVentaMonto.OutputFormat = resources.GetString("tbTotalTipoVentaMonto.OutputFormat")
            Me.tbTotalTipoVentaMonto.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa"& _ 
                "mily: Arial"
            Me.tbTotalTipoVentaMonto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalTipoVentaMonto.Text = "tbTotalTipoVentaMonto"
            Me.tbTotalTipoVentaMonto.Top = 0!
            Me.tbTotalTipoVentaMonto.Width = 1.1875!
            '
            'tbTotalTDC
            '
            Me.tbTotalTDC.Height = 0.1875!
            Me.tbTotalTDC.Left = 1.5!
            Me.tbTotalTDC.Name = "tbTotalTDC"
            Me.tbTotalTDC.OutputFormat = resources.GetString("tbTotalTDC.OutputFormat")
            Me.tbTotalTDC.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa"& _ 
                "mily: Arial"
            Me.tbTotalTDC.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalTDC.Text = "tbTotalTDC"
            Me.tbTotalTDC.Top = 0!
            Me.tbTotalTDC.Width = 1.0625!
            '
            'tbTotalValeCaja
            '
            Me.tbTotalValeCaja.Height = 0.1875!
            Me.tbTotalValeCaja.Left = 5.5!
            Me.tbTotalValeCaja.Name = "tbTotalValeCaja"
            Me.tbTotalValeCaja.OutputFormat = resources.GetString("tbTotalValeCaja.OutputFormat")
            Me.tbTotalValeCaja.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa"& _ 
                "mily: Arial"
            Me.tbTotalValeCaja.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalValeCaja.Text = "tbTotalValeCaja"
            Me.tbTotalValeCaja.Top = 0!
            Me.tbTotalValeCaja.Width = 1.1875!
            '
            'Line8
            '
            Me.Line8.Height = 0.003772974!
            Me.Line8.Left = 0.02083333!
            Me.Line8.LineWeight = 3!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.24229!
            Me.Line8.Width = 6.598261!
            Me.Line8.X1 = 0.02083333!
            Me.Line8.X2 = 6.619094!
            Me.Line8.Y1 = 0.24229!
            Me.Line8.Y2 = 0.246063!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.9840278!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.75!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoTipo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDocumentoImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lbTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoVentaMonto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNoTarjetaCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNoAutorizacionTDC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbValeCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalTipoVentaMonto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalTDC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalValeCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



#Region "Members Variables"

    Private oValeCaja As ValeCaja

    'Private strTipoVenta As String

#End Region



#Region "Constructors"

    Public Sub New(ByRef pValeCaja As ValeCaja, ByVal strTipoVenta As String)

        MyBase.New()
        InitializeComponent()

        oValeCaja = pValeCaja

        Sm_MostrarInformacion(strTipoVenta)

    End Sub

#End Region



#Region "Methods"

    Private Sub Sm_MostrarInformacion(ByVal strTipoVenta As String)

        With oValeCaja

            'Encabezado :

            Me.tbFolio.Text = .ValeCajaID

            Me.tbFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoFolio.Text = .FolioDocumento

            Me.tbDocumentoImporte.Text = Format(.DocumentoImporte, "Currency")



            'Detalle :

            Me.DataSource = .DistribucionDetalle.Tables("AnticiposClientesDetalle")

            Me.tbFactura.DataField = "Referencia"


            Select Case strTipoVenta

                Case "V"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoDPVale"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoDPVale"

                    Me.lbTipoVenta.Text = "DPVale"


                Case "D"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoCDT"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoCDT"

                    Me.tbTotalTDC.Visible = True
                    Me.tbTCredito.Visible = True


                    Me.tbNoAutorizacionTDC.Visible = True
                    Me.tbNoTarjetaCredito.Visible = True


                    Me.tbTotalValeCaja.Visible = True
                    Me.tbValeCaja.Visible = True

                    Me.Label9.Visible = True
                    Me.Label10.Visible = True
                    Me.Label11.Visible = True
                    Me.Label12.Visible = True


                    Me.lbTipoVenta.Text = "CDT"

                Case "F", "K"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.lbTipoVenta.Text = "FONACOT"



                Case "O"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.lbTipoVenta.Text = "FACILITO"

                Case "P", "A", "I", "S"

                    Me.tbTipoVentaMonto.Visible = False
                    Me.lbTipoVenta.Visible = False
                    Me.tbTotalTipoVentaMonto.Visible = False

            End Select


            Me.tbTCredito.DataField = "MontoCanceladoTarjeta"

            Me.tbTotalTDC.DataField = "MontoCanceladoTarjeta"

            Me.tbNoTarjetaCredito.DataField = "NumeroTarjeta"

            Me.tbNoAutorizacionTDC.DataField = "NumeroAutorizacionCancelacion"

            'Me.tbValeCaja.DataField = "AnticipoCliente"

            'Me.tbTotalValeCaja.DataField = "AnticipoCliente"

            Me.tbValeCaja.DataField = "TotalAC"

            Me.tbTotalValeCaja.DataField = "TotalAC"

        End With

    End Sub

#End Region

End Class
