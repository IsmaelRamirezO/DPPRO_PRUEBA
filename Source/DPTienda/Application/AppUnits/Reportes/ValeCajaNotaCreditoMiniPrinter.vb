Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja

Public Class ValeCajaNotaCreditoMiniPrinter
Inherits DataDynamics.ActiveReports.ActiveReport
	
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
    Private LblId As Label = Nothing
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
    Private Label9 As Label = Nothing
    Private Label12 As Label = Nothing
    Private tbFactura As TextBox = Nothing
    Private tbTipoVentaMonto As TextBox = Nothing
    Private tbTCredito As TextBox = Nothing
    Private tbValeCaja As TextBox = Nothing
    Private tbNoAutorizacionTDC As TextBox = Nothing
    Private tbNoTarjetaCredito As TextBox = Nothing
    Private tbTotalTipoVentaMonto As TextBox = Nothing
    Private tbTotalTDC As TextBox = Nothing
    Private tbTotalValeCaja As TextBox = Nothing
    Private lblExpira As Label = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaNotaCreditoMiniPrinter))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbFactura = New DataDynamics.ActiveReports.TextBox()
        Me.tbTipoVentaMonto = New DataDynamics.ActiveReports.TextBox()
        Me.tbTCredito = New DataDynamics.ActiveReports.TextBox()
        Me.tbValeCaja = New DataDynamics.ActiveReports.TextBox()
        Me.tbNoAutorizacionTDC = New DataDynamics.ActiveReports.TextBox()
        Me.tbNoTarjetaCredito = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.LblId = New DataDynamics.ActiveReports.Label()
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
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.tbTotalTipoVentaMonto = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotalTDC = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotalValeCaja = New DataDynamics.ActiveReports.TextBox()
        Me.lblExpira = New DataDynamics.ActiveReports.Label()
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTipoVentaMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbValeCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNoAutorizacionTDC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNoTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDocumentoTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDocumentoFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDocumentoImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalTipoVentaMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalTDC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalValeCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblExpira, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFactura, Me.tbTipoVentaMonto, Me.tbTCredito, Me.tbValeCaja, Me.tbNoAutorizacionTDC, Me.tbNoTarjetaCredito})
        Me.Detail.Height = 0.2076389!
        Me.Detail.Name = "Detail"
        '
        'tbFactura
        '
        Me.tbFactura.Height = 0.1875!
        Me.tbFactura.Left = 0.2559055!
        Me.tbFactura.Name = "tbFactura"
        Me.tbFactura.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.tbFactura.Text = "TbFactura"
        Me.tbFactura.Top = 0.0!
        Me.tbFactura.Width = 0.6889763!
        '
        'tbTipoVentaMonto
        '
        Me.tbTipoVentaMonto.Height = 0.1875!
        Me.tbTipoVentaMonto.Left = 3.385827!
        Me.tbTipoVentaMonto.Name = "tbTipoVentaMonto"
        Me.tbTipoVentaMonto.OutputFormat = resources.GetString("tbTipoVentaMonto.OutputFormat")
        Me.tbTipoVentaMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.tbTipoVentaMonto.Text = "tbTipoVentaMonto"
        Me.tbTipoVentaMonto.Top = 0.0!
        Me.tbTipoVentaMonto.Width = 0.8125!
        '
        'tbTCredito
        '
        Me.tbTCredito.Height = 0.1875!
        Me.tbTCredito.Left = 0.9657153!
        Me.tbTCredito.Name = "tbTCredito"
        Me.tbTCredito.OutputFormat = resources.GetString("tbTCredito.OutputFormat")
        Me.tbTCredito.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.tbTCredito.Text = "tbTCredito"
        Me.tbTCredito.Top = 0.0!
        Me.tbTCredito.Width = 0.8453084!
        '
        'tbValeCaja
        '
        Me.tbValeCaja.Height = 0.1875!
        Me.tbValeCaja.Left = 1.8!
        Me.tbValeCaja.Name = "tbValeCaja"
        Me.tbValeCaja.OutputFormat = resources.GetString("tbValeCaja.OutputFormat")
        Me.tbValeCaja.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.tbValeCaja.Text = "tbValeCaja"
        Me.tbValeCaja.Top = 0.0!
        Me.tbValeCaja.Width = 0.8125!
        '
        'tbNoAutorizacionTDC
        '
        Me.tbNoAutorizacionTDC.Height = 0.1875!
        Me.tbNoAutorizacionTDC.Left = 5.333662!
        Me.tbNoAutorizacionTDC.Name = "tbNoAutorizacionTDC"
        Me.tbNoAutorizacionTDC.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.tbNoAutorizacionTDC.Text = "tbNoAutorizacionTDC"
        Me.tbNoAutorizacionTDC.Top = 0.0!
        Me.tbNoAutorizacionTDC.Width = 1.201771!
        '
        'tbNoTarjetaCredito
        '
        Me.tbNoTarjetaCredito.Height = 0.1875!
        Me.tbNoTarjetaCredito.Left = 4.173229!
        Me.tbNoTarjetaCredito.Name = "tbNoTarjetaCredito"
        Me.tbNoTarjetaCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.tbNoTarjetaCredito.Text = "tbNoTarjetaCredito"
        Me.tbNoTarjetaCredito.Top = 0.0!
        Me.tbNoTarjetaCredito.Width = 1.102362!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.LblId, Me.Label3, Me.tbCliente, Me.tbFolio, Me.tbFecha, Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte})
        Me.PageHeader.Height = 1.864583!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.1574803!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.534941!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label1.Text = "VALE DE CAJA"
        Me.Label1.Top = 0.01624016!
        Me.Label1.Width = 1.948819!
        '
        'LblId
        '
        Me.LblId.Height = 0.1875!
        Me.LblId.HyperLink = Nothing
        Me.LblId.Left = 0.27!
        Me.LblId.Name = "LblId"
        Me.LblId.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.LblId.Text = "ID:"
        Me.LblId.Top = 0.53!
        Me.LblId.Width = 0.3065945!
        '
        'Label3
        '
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.2559055!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label3.Text = "FECHA :"
        Me.Label3.Top = 0.8149604!
        Me.Label3.Width = 0.531496!
        '
        'tbCliente
        '
        Me.tbCliente.Height = 0.1875!
        Me.tbCliente.Left = 0.2559055!
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCliente.Text = "tbCliente"
        Me.tbCliente.Top = 1.037401!
        Me.tbCliente.Width = 2.42126!
        '
        'tbFolio
        '
        Me.tbFolio.Height = 0.1875!
        Me.tbFolio.Left = 0.886!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbFolio.Text = "tbFolio"
        Me.tbFolio.Top = 0.53!
        Me.tbFolio.Width = 0.75!
        '
        'tbFecha
        '
        Me.tbFecha.Height = 0.1875!
        Me.tbFecha.Left = 0.8385819!
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbFecha.Text = "tbFecha"
        Me.tbFecha.Top = 0.8149604!
        Me.tbFecha.Width = 1.349902!
        '
        'Label4
        '
        Me.Label4.Height = 0.1889764!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2559055!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "DOCTO. ORIGEN :"
        Me.Label4.Top = 1.273622!
        Me.Label4.Width = 0.9645666!
        '
        'tbDocumentoTipo
        '
        Me.tbDocumentoTipo.Height = 0.1875!
        Me.tbDocumentoTipo.Left = 1.213583!
        Me.tbDocumentoTipo.Name = "tbDocumentoTipo"
        Me.tbDocumentoTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoTipo.Text = "tbDocumentoTipo"
        Me.tbDocumentoTipo.Top = 1.273622!
        Me.tbDocumentoTipo.Width = 0.4114173!
        '
        'Label5
        '
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2559055!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label5.Text = "FOLIO :"
        Me.Label5.Top = 0.3223424!
        Me.Label5.Width = 0.5565945!
        '
        'tbDocumentoFolio
        '
        Me.tbDocumentoFolio.Height = 0.1875!
        Me.tbDocumentoFolio.Left = 0.875!
        Me.tbDocumentoFolio.Name = "tbDocumentoFolio"
        Me.tbDocumentoFolio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoFolio.Text = "tbDocumentoFolio"
        Me.tbDocumentoFolio.Top = 0.3223424!
        Me.tbDocumentoFolio.Width = 1.375!
        '
        'Label6
        '
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.2559055!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label6.Text = "IMPORTE :"
        Me.Label6.Top = 1.512303!
        Me.Label6.Width = 0.6102362!
        '
        'tbDocumentoImporte
        '
        Me.tbDocumentoImporte.Height = 0.1875!
        Me.tbDocumentoImporte.Left = 1.276083!
        Me.tbDocumentoImporte.Name = "tbDocumentoImporte"
        Me.tbDocumentoImporte.OutputFormat = resources.GetString("tbDocumentoImporte.OutputFormat")
        Me.tbDocumentoImporte.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoImporte.Text = "tbDocumentoImporte"
        Me.tbDocumentoImporte.Top = 1.512303!
        Me.tbDocumentoImporte.Width = 1.401083!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.08333334!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7, Me.Label8, Me.Label9, Me.Label12})
        Me.GroupHeader1.Height = 0.5819445!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label7
        '
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.25!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label7.Text = "MOVIMIENTOS :"
        Me.Label7.Top = 0.0!
        Me.Label7.Width = 1.0!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574803!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.25!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label8.Text = "Factura"
        Me.Label8.Top = 0.3774605!
        Me.Label8.Width = 0.6889763!
        '
        'Label9
        '
        Me.Label9.Height = 0.1574803!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.9586611!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
    "family: Tahoma"
        Me.Label9.Text = "TDC"
        Me.Label9.Top = 0.3779528!
        Me.Label9.Width = 0.8464569!
        '
        'Label12
        '
        Me.Label12.Height = 0.1574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 1.883858!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
    "family: Tahoma"
        Me.Label12.Text = "Vale Caja"
        Me.Label12.Top = 0.3779528!
        Me.Label12.Width = 0.8110237!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTotalTipoVentaMonto, Me.tbTotalTDC, Me.tbTotalValeCaja, Me.lblExpira})
        Me.GroupFooter1.Height = 1.134722!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'tbTotalTipoVentaMonto
        '
        Me.tbTotalTipoVentaMonto.Height = 0.1875!
        Me.tbTotalTipoVentaMonto.Left = 0.2559055!
        Me.tbTotalTipoVentaMonto.Name = "tbTotalTipoVentaMonto"
        Me.tbTotalTipoVentaMonto.OutputFormat = resources.GetString("tbTotalTipoVentaMonto.OutputFormat")
        Me.tbTotalTipoVentaMonto.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa" & _
    "mily: Arial"
        Me.tbTotalTipoVentaMonto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.tbTotalTipoVentaMonto.Text = "tbTotalTipoVentaMonto"
        Me.tbTotalTipoVentaMonto.Top = 0.1412401!
        Me.tbTotalTipoVentaMonto.Width = 0.6889763!
        '
        'tbTotalTDC
        '
        Me.tbTotalTDC.Height = 0.1875!
        Me.tbTotalTDC.Left = 1.007382!
        Me.tbTotalTDC.Name = "tbTotalTDC"
        Me.tbTotalTDC.OutputFormat = resources.GetString("tbTotalTDC.OutputFormat")
        Me.tbTotalTDC.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa" & _
    "mily: Arial"
        Me.tbTotalTDC.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.tbTotalTDC.Text = "tbTotalTDC"
        Me.tbTotalTDC.Top = 0.1412401!
        Me.tbTotalTDC.Width = 0.7874014!
        '
        'tbTotalValeCaja
        '
        Me.tbTotalValeCaja.Height = 0.1875!
        Me.tbTotalValeCaja.Left = 1.889764!
        Me.tbTotalValeCaja.Name = "tbTotalValeCaja"
        Me.tbTotalValeCaja.OutputFormat = resources.GetString("tbTotalValeCaja.OutputFormat")
        Me.tbTotalValeCaja.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa" & _
    "mily: Arial"
        Me.tbTotalValeCaja.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.tbTotalValeCaja.Text = "tbTotalValeCaja"
        Me.tbTotalValeCaja.Top = 0.1412401!
        Me.tbTotalValeCaja.Width = 0.7874014!
        '
        'lblExpira
        '
        Me.lblExpira.Height = 0.551181!
        Me.lblExpira.HyperLink = Nothing
        Me.lblExpira.Left = 0.25!
        Me.lblExpira.Name = "lblExpira"
        Me.lblExpira.Style = "text-align: justify"
        Me.lblExpira.Text = "El presente documento tiene validez durante los siguientes 45 dias después de su " & _
    "fecha de expedición."
        Me.lblExpira.Top = 0.563!
        Me.lblExpira.Width = 2.440945!
        '
        'ValeCajaNotaCreditoMiniPrinter
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.771!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTipoVentaMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbValeCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNoAutorizacionTDC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNoTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDocumentoTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDocumentoFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDocumentoImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalTipoVentaMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalTDC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalValeCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblExpira, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Members Variables"

    Private oValeCaja As ValeCaja

    'Private strTipoVenta As String

#End Region

#Region "Constructors"

    Public Sub New(ByRef pValeCaja As ValeCaja, ByVal strTipoVenta As String, ByVal strFolioSAP As String)

        MyBase.New()

        Try
1:          InitializeComponent()

2:          oValeCaja = pValeCaja

3:          Sm_MostrarInformacion(strTipoVenta, strFolioSAP)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir el vale de caja de NC. Linea " & Err.Erl)
            Throw New ApplicationException("Linea " & Err.Erl)
        End Try

    End Sub

#End Region

#Region "Methods"

    Private Sub Sm_MostrarInformacion(ByVal strTipoVenta As String, ByVal strFolioSAP As String)

        With oValeCaja

            'Encabezado :
            '--------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 16.07.2013: Si es un vale de caja de tipo CP o PI entonces el folio del vale de caja sera el id del DPPRO de lo contrario sera el 
            'FolioSAP del documento origen
            '--------------------------------------------------------------------------------------------------------------------------------------------
            If InStr("PI,CP", .TipoDocumento.Trim.ToUpper) > 0 Then
                Me.tbFolio.Text = CStr(.FolioDocumento).PadLeft(10, "0")
                Me.tbDocumentoFolio.Text = CStr(.FolioDocumento).PadLeft(10, "0")
                'Me.tbDocumentoFolio.Text = CStr(.ValeCajaID).PadLeft(10, "0")
                Me.tbFolio.Visible = True
                Me.LblId.Visible = True
            Else
                Me.tbFolio.Text = CStr(.ValeCajaID).PadLeft(10, "0")
                Me.tbDocumentoFolio.Text = CStr(.FolioDocumento).PadLeft(10, "0")
            End If

            Me.tbFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoImporte.Text = Format(.DocumentoImporte, "Currency")

            'Detalle :
            '--------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (08/05/2013) - Se Adaptó para imprimir vale de caja de tipo Pedido Insurtible (PI), Cancelacion Factura (CF) y Cancelacion Pedido (CP)
            '--------------------------------------------------------------------------------------------------------------------------------------------------------
            If .TipoDocumento = "NC" Then
                Me.DataSource = .DistribucionDetalle.Tables("AnticiposClientesDetalle")
            End If

            Me.tbFactura.Text = strFolioSAP

            Select Case strTipoVenta

                Case "V"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoDPVale"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoDPVale"

                    'Me.lbTipoVenta.Text = "DPVale"


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
                    'Me.Label10.Visible = True
                    'Me.Label11.Visible = True
                    Me.Label12.Visible = True


                    'Me.lbTipoVenta.Text = "CDT"

                Case "F", "K"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    'Me.lbTipoVenta.Text = "FONACOT"

                Case "O"

                    Me.tbTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    Me.tbTotalTipoVentaMonto.DataField = "MontoCanceladoFonacotFacilito"
                    'Me.lbTipoVenta.Text = "FACILITO"

                Case "P", "A", "I", "S"

                    Me.tbTipoVentaMonto.Visible = False
                    'Me.lbTipoVenta.Visible = False
                    Me.tbTotalTipoVentaMonto.Visible = False

            End Select

            'Quitamos Labels de Movimientos para los pedidos insurtibles
            If .TipoDocumento = "PI" Or .TipoDocumento = "CF" Or .TipoDocumento = "CP" Then

                Me.tbTotalTipoVentaMonto.Visible = False
                Me.tbTotalTDC.Visible = False
                Me.tbTotalValeCaja.Visible = False

                Me.Detail.Visible = False
                Me.GroupHeader1.Visible = False
                'Me.GroupFooter1.Visible = False

                Me.tbFactura.Visible = False
                Me.tbTCredito.Visible = False
                Me.tbValeCaja.Visible = False

                Me.lblExpira.Location = New PointF(0.25, 0)

            End If

            Me.tbTCredito.DataField = "MontoCanceladoTarjeta"

            Me.tbTotalTDC.DataField = "MontoCanceladoTarjeta"

            Me.tbNoTarjetaCredito.DataField = "NumeroTarjeta"

            Me.tbNoAutorizacionTDC.DataField = "NumeroAutorizacionCancelacion"

            Me.tbValeCaja.DataField = "TotalAC"

            Me.tbTotalValeCaja.DataField = "TotalAC"

        End With

    End Sub

#End Region

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.tbFactura.Text = Me.tbFactura.Text.PadLeft(10, "0")
    End Sub

End Class
