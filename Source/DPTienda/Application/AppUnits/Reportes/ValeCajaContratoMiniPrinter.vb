Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU

Public Class ValeCajaContratoMiniPrinter
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
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private tbTotalAbonos As TextBox = Nothing
	Private tbTCredito As TextBox = Nothing
	Private tbNoTarjetaCredito As TextBox = Nothing
	Private tbNoAutorizacionTDC As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private tbValeCaja As TextBox = Nothing
	Private tbPenalizacion As TextBox = Nothing
	Private tbImporteFavor As TextBox = Nothing
	Private lblExpira As Label = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaContratoMiniPrinter))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.tbTCredito = New DataDynamics.ActiveReports.TextBox()
        Me.tbNoTarjetaCredito = New DataDynamics.ActiveReports.TextBox()
        Me.tbNoAutorizacionTDC = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
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
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.tbTotalAbonos = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.tbValeCaja = New DataDynamics.ActiveReports.TextBox()
        Me.tbPenalizacion = New DataDynamics.ActiveReports.TextBox()
        Me.tbImporteFavor = New DataDynamics.ActiveReports.TextBox()
        Me.lblExpira = New DataDynamics.ActiveReports.Label()
        CType(Me.tbTCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNoTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNoAutorizacionTDC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbValeCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPenalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporteFavor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblExpira, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTCredito, Me.tbNoTarjetaCredito, Me.tbNoAutorizacionTDC})
        Me.Detail.Height = 0.2076389!
        Me.Detail.Name = "Detail"
        '
        'tbTCredito
        '
        Me.tbTCredito.Height = 0.1875!
        Me.tbTCredito.Left = 1.732283!
        Me.tbTCredito.Name = "tbTCredito"
        Me.tbTCredito.OutputFormat = resources.GetString("tbTCredito.OutputFormat")
        Me.tbTCredito.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.tbTCredito.Text = "tbTCredito"
        Me.tbTCredito.Top = 0.0!
        Me.tbTCredito.Width = 1.0!
        '
        'tbNoTarjetaCredito
        '
        Me.tbNoTarjetaCredito.Height = 0.1875!
        Me.tbNoTarjetaCredito.Left = 0.2559055!
        Me.tbNoTarjetaCredito.Name = "tbNoTarjetaCredito"
        Me.tbNoTarjetaCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.tbNoTarjetaCredito.Text = "tbNoTarjetaCredito"
        Me.tbNoTarjetaCredito.Top = 0.0!
        Me.tbNoTarjetaCredito.Width = 0.6889763!
        '
        'tbNoAutorizacionTDC
        '
        Me.tbNoAutorizacionTDC.Height = 0.1875!
        Me.tbNoAutorizacionTDC.Left = 1.023622!
        Me.tbNoAutorizacionTDC.Name = "tbNoAutorizacionTDC"
        Me.tbNoAutorizacionTDC.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.tbNoAutorizacionTDC.Text = "tbNoAutorizacionTDC"
        Me.tbNoAutorizacionTDC.Top = 0.0!
        Me.tbNoAutorizacionTDC.Width = 0.6299213!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.tbCliente, Me.tbFolio, Me.tbFecha, Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte, Me.Label7, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.tbTotalAbonos})
        Me.PageHeader.Height = 2.604167!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.1574803!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.6299212!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label1.Text = "VALE DE CAJA"
        Me.Label1.Top = 0.07874014!
        Me.Label1.Width = 1.875!
        '
        'Label2
        '
        Me.Label2.Height = 0.1574803!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.2559055!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label2.Text = "VALE :"
        Me.Label2.Top = 0.6437007!
        Me.Label2.Width = 0.3740158!
        '
        'Label3
        '
        Me.Label3.Height = 0.1417323!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.2559055!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label3.Text = "FECHA :"
        Me.Label3.Top = 0.8956695!
        Me.Label3.Width = 0.4527559!
        '
        'tbCliente
        '
        Me.tbCliente.Height = 0.1574803!
        Me.tbCliente.Left = 0.2559055!
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbCliente.Text = "tbCliente"
        Me.tbCliente.Top = 1.116142!
        Me.tbCliente.Width = 2.42126!
        '
        'tbFolio
        '
        Me.tbFolio.Height = 0.1574803!
        Me.tbFolio.Left = 0.8774604!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.OutputFormat = resources.GetString("tbFolio.OutputFormat")
        Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbFolio.Text = "tbFolio"
        Me.tbFolio.Top = 0.6437007!
        Me.tbFolio.Width = 1.091044!
        '
        'tbFecha
        '
        Me.tbFecha.Height = 0.1437008!
        Me.tbFecha.Left = 0.8774604!
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbFecha.Text = "tbFecha"
        Me.tbFecha.Top = 0.8937007!
        Me.tbFecha.Width = 1.091044!
        '
        'Label4
        '
        Me.Label4.Height = 0.1574803!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.2559055!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label4.Text = "DOCTO. ORIGEN :"
        Me.Label4.Top = 1.352362!
        Me.Label4.Width = 1.003937!
        '
        'tbDocumentoTipo
        '
        Me.tbDocumentoTipo.Height = 0.1574803!
        Me.tbDocumentoTipo.Left = 1.306102!
        Me.tbDocumentoTipo.Name = "tbDocumentoTipo"
        Me.tbDocumentoTipo.OutputFormat = resources.GetString("tbDocumentoTipo.OutputFormat")
        Me.tbDocumentoTipo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoTipo.Text = "tbDocumentoTipo"
        Me.tbDocumentoTipo.Top = 1.352362!
        Me.tbDocumentoTipo.Width = 1.181102!
        '
        'Label5
        '
        Me.Label5.Height = 0.1574802!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.2559055!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label5.Text = "FOLIO :"
        Me.Label5.Top = 0.4010827!
        Me.Label5.Width = 0.9251972!
        '
        'tbDocumentoFolio
        '
        Me.tbDocumentoFolio.Height = 0.1574802!
        Me.tbDocumentoFolio.Left = 1.306102!
        Me.tbDocumentoFolio.Name = "tbDocumentoFolio"
        Me.tbDocumentoFolio.OutputFormat = resources.GetString("tbDocumentoFolio.OutputFormat")
        Me.tbDocumentoFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoFolio.Text = "tbDocumentoFolio"
        Me.tbDocumentoFolio.Top = 0.4010827!
        Me.tbDocumentoFolio.Width = 1.181102!
        '
        'Label6
        '
        Me.Label6.Height = 0.1574803!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.2559055!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label6.Text = "IMPORTE :"
        Me.Label6.Top = 1.574803!
        Me.Label6.Width = 0.6889763!
        '
        'tbDocumentoImporte
        '
        Me.tbDocumentoImporte.Height = 0.1574803!
        Me.tbDocumentoImporte.Left = 1.306102!
        Me.tbDocumentoImporte.Name = "tbDocumentoImporte"
        Me.tbDocumentoImporte.OutputFormat = resources.GetString("tbDocumentoImporte.OutputFormat")
        Me.tbDocumentoImporte.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbDocumentoImporte.Text = "tbDocumentoImporte"
        Me.tbDocumentoImporte.Top = 1.574803!
        Me.tbDocumentoImporte.Width = 1.181102!
        '
        'Label7
        '
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.2559055!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label7.Text = "Movimientos :"
        Me.Label7.Top = 2.125984!
        Me.Label7.Width = 1.0!
        '
        'Label9
        '
        Me.Label9.Height = 0.1574802!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 1.732283!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label9.Text = "Importe Cancelado"
        Me.Label9.Top = 2.440945!
        Me.Label9.Visible = False
        Me.Label9.Width = 1.023622!
        '
        'Label10
        '
        Me.Label10.Height = 0.1437008!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.2559055!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label10.Text = "# Tarjeta"
        Me.Label10.Top = 2.440945!
        Me.Label10.Visible = False
        Me.Label10.Width = 0.6299213!
        '
        'Label11
        '
        Me.Label11.Height = 0.1574802!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.944882!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label11.Text = "# Autorización"
        Me.Label11.Top = 2.440945!
        Me.Label11.Visible = False
        Me.Label11.Width = 0.7874014!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.2559055!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Tahoma"
        Me.Label12.Text = "TOTAL ABONOS :"
        Me.Label12.Top = 1.811024!
        Me.Label12.Width = 1.003937!
        '
        'tbTotalAbonos
        '
        Me.tbTotalAbonos.Height = 0.1875!
        Me.tbTotalAbonos.Left = 1.306102!
        Me.tbTotalAbonos.Name = "tbTotalAbonos"
        Me.tbTotalAbonos.OutputFormat = resources.GetString("tbTotalAbonos.OutputFormat")
        Me.tbTotalAbonos.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbTotalAbonos.Text = "tbTotalAbonos"
        Me.tbTotalAbonos.Top = 1.811024!
        Me.tbTotalAbonos.Width = 1.181102!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label13, Me.Label14, Me.Label15, Me.tbValeCaja, Me.tbPenalizacion, Me.tbImporteFavor, Me.lblExpira})
        Me.GroupFooter1.Height = 1.353472!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Label13
        '
        Me.Label13.Height = 0.1574803!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 0.2559055!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label13.Text = "VALE DE CAJA :"
        Me.Label13.Top = 0.0620078!
        Me.Label13.Width = 1.102363!
        '
        'Label14
        '
        Me.Label14.Height = 0.1437008!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.2559055!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label14.Text = "PENALIZACIÓN :"
        Me.Label14.Top = 0.2194881!
        Me.Label14.Width = 1.102363!
        '
        'Label15
        '
        Me.Label15.Height = 0.1875!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.2559055!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Tahoma"
        Me.Label15.Text = "IMPORTE A FAVOR :"
        Me.Label15.Top = 0.363189!
        Me.Label15.Width = 1.259842!
        '
        'tbValeCaja
        '
        Me.tbValeCaja.Height = 0.1574803!
        Me.tbValeCaja.Left = 1.653543!
        Me.tbValeCaja.Name = "tbValeCaja"
        Me.tbValeCaja.OutputFormat = resources.GetString("tbValeCaja.OutputFormat")
        Me.tbValeCaja.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbValeCaja.Text = "tbValeCaja"
        Me.tbValeCaja.Top = 0.0620078!
        Me.tbValeCaja.Width = 1.031496!
        '
        'tbPenalizacion
        '
        Me.tbPenalizacion.Height = 0.1574803!
        Me.tbPenalizacion.Left = 1.653543!
        Me.tbPenalizacion.Name = "tbPenalizacion"
        Me.tbPenalizacion.OutputFormat = resources.GetString("tbPenalizacion.OutputFormat")
        Me.tbPenalizacion.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Tahoma"
        Me.tbPenalizacion.Text = "tbPenalizacion"
        Me.tbPenalizacion.Top = 0.2194881!
        Me.tbPenalizacion.Width = 1.031496!
        '
        'tbImporteFavor
        '
        Me.tbImporteFavor.Height = 0.1574803!
        Me.tbImporteFavor.Left = 1.653543!
        Me.tbImporteFavor.Name = "tbImporteFavor"
        Me.tbImporteFavor.OutputFormat = resources.GetString("tbImporteFavor.OutputFormat")
        Me.tbImporteFavor.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa" & _
    "mily: Tahoma"
        Me.tbImporteFavor.Text = "tbImporteFavor"
        Me.tbImporteFavor.Top = 0.363189!
        Me.tbImporteFavor.Width = 1.03002!
        '
        'lblExpira
        '
        Me.lblExpira.Height = 0.551181!
        Me.lblExpira.HyperLink = Nothing
        Me.lblExpira.Left = 0.2362205!
        Me.lblExpira.Name = "lblExpira"
        Me.lblExpira.Style = "text-align: justify"
        Me.lblExpira.Text = "El presente documento tiene validez durante los siguientes 45 dias después de su " & _
    "fecha de expedición."
        Me.lblExpira.Top = 0.7086611!
        Me.lblExpira.Width = 2.440945!
        '
        'ValeCajaContratoMiniPrinter
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.760417!
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
        CType(Me.tbTCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNoTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNoAutorizacionTDC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbValeCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPenalizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporteFavor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblExpira, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region


#Region "Members Variables"

    Private oValeCaja As ValeCaja

    Private oDistribucionContrato As DistribucionNC

    Private decImporteFavor As Decimal

#End Region



#Region "Constructors"

    Public Sub New(ByVal pValeCaja As ValeCaja, ByVal pDistribucionContrato As DistribucionNC, ByVal decMontoFavor As Decimal)

        MyBase.New()
        InitializeComponent()


        oValeCaja = pValeCaja
        oDistribucionContrato = pDistribucionContrato
        decImporteFavor = decMontoFavor


        Sm_MostrarInformacion()


    End Sub

#End Region



#Region "Methods"

    Private Sub Sm_MostrarInformacion()

        With oValeCaja

            'Encabezado :

            Me.tbFolio.Text = CStr(.ValeCajaID).PadLeft(10, "0")

            Me.tbFecha.Text = UCase(Format(.Fecha, "dd - MMM - yyyy"))

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoFolio.Text = .FolioDocumento.Trim.PadLeft(10, "0")

            Me.tbDocumentoImporte.Text = Format(.DocumentoImporte, "Currency")

            Me.tbTotalAbonos.Text = Format(oDistribucionContrato.TotalAbonos, "Currency")

            'Detalle :

            Dim dvDistribucion As New DataView

            dvDistribucion.Table = .DistribucionDetalle.Tables("AnticiposClientesDetalle")

            dvDistribucion.RowFilter = "NumeroTarjeta <> ''"

            'Me.DataSource = .DistribucionDetalle.Tables("AnticiposClientesDetalle")

            Me.DataSource = dvDistribucion

            Me.tbTCredito.DataField = "MontoCanceladoTarjeta"

            Me.tbNoTarjetaCredito.DataField = "NumeroTarjeta"

            Me.tbNoAutorizacionTDC.DataField = "NumeroAutorizacionCancelacion"



            'Pie de Pagina :

            tbValeCaja.Text = Format(oDistribucionContrato.SaldoAnticipoCliente, "Standard")

            tbPenalizacion.Text = Format(oDistribucionContrato.Penalizacion, "Currency")

            tbImporteFavor.Text = decImporteFavor

        End With

    End Sub

#End Region

End Class
