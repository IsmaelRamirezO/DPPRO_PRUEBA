
Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU




Public Class ValeCajaContrato
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
	Private Line12 As Line = Nothing
	Private tbTCredito As TextBox = Nothing
	Private tbNoTarjetaCredito As TextBox = Nothing
	Private tbNoAutorizacionTDC As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private tbValeCaja As TextBox = Nothing
	Private tbPenalizacion As TextBox = Nothing
	Private tbImporteFavor As TextBox = Nothing
	Private Line13 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValeCajaContrato))
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
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.tbTotalAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.tbTCredito = New DataDynamics.ActiveReports.TextBox()
            Me.tbNoTarjetaCredito = New DataDynamics.ActiveReports.TextBox()
            Me.tbNoAutorizacionTDC = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.tbValeCaja = New DataDynamics.ActiveReports.TextBox()
            Me.tbPenalizacion = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporteFavor = New DataDynamics.ActiveReports.TextBox()
            Me.Line13 = New DataDynamics.ActiveReports.Line()
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
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNoTarjetaCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNoAutorizacionTDC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbValeCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPenalizacion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporteFavor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTCredito, Me.tbNoTarjetaCredito, Me.tbNoAutorizacionTDC})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3, Me.tbCliente, Me.tbFolio, Me.tbFecha, Me.Label4, Me.tbDocumentoTipo, Me.Label5, Me.tbDocumentoFolio, Me.Label6, Me.tbDocumentoImporte, Me.Label7, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.tbTotalAbonos, Me.Line12})
            Me.PageHeader.Height = 2.072917!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label13, Me.Label14, Me.Label15, Me.tbValeCaja, Me.tbPenalizacion, Me.tbImporteFavor, Me.Line13})
            Me.GroupFooter1.Height = 0.8229167!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; font-family: Arial"
            Me.Label1.Text = "Vale de Caja"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 1.875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 4.8125!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label2.Text = "Folio :"
            Me.Label2.Top = 0.3125!
            Me.Label2.Width = 0.4375!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 4.8125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label3.Text = "Fecha :"
            Me.Label3.Top = 0.5625!
            Me.Label3.Width = 0.5!
            '
            'tbCliente
            '
            Me.tbCliente.Height = 0.1875!
            Me.tbCliente.Left = 0.125!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 1; font-family: Verdana"
            Me.tbCliente.Text = "tbCliente"
            Me.tbCliente.Top = 0.5!
            Me.tbCliente.Width = 3.5!
            '
            'tbFolio
            '
            Me.tbFolio.Height = 0.1875!
            Me.tbFolio.Left = 5.375!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbFolio.Text = "tbFolio"
            Me.tbFolio.Top = 0.3125!
            Me.tbFolio.Width = 0.875!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1875!
            Me.tbFecha.Left = 5.375!
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
            Me.Label4.Left = 0.125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Docto. Origen :"
            Me.Label4.Top = 0.875!
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
            Me.Label5.Left = 2.3125!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label5.Text = "Folio :"
            Me.Label5.Top = 0.875!
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
            Me.Label6.Left = 3.9375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label6.Text = "Importe :"
            Me.Label6.Top = 0.875!
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
            Me.Label7.Left = 0.125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label7.Text = "Movimientos :"
            Me.Label7.Top = 1.625!
            Me.Label7.Width = 1!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label9.Text = "Importe Cancelado"
            Me.Label9.Top = 1.875!
            Me.Label9.Width = 1.5!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.125!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label10.Text = "No. Tarjeta"
            Me.Label10.Top = 1.875!
            Me.Label10.Width = 0.75!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 1.875!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label11.Text = "No. Autorización"
            Me.Label11.Top = 1.875!
            Me.Label11.Width = 1.125!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.125!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label12.Text = "Total Abonos :"
            Me.Label12.Top = 1.25!
            Me.Label12.Width = 1!
            '
            'tbTotalAbonos
            '
            Me.tbTotalAbonos.Height = 0.1875!
            Me.tbTotalAbonos.Left = 1.125!
            Me.tbTotalAbonos.Name = "tbTotalAbonos"
            Me.tbTotalAbonos.OutputFormat = resources.GetString("tbTotalAbonos.OutputFormat")
            Me.tbTotalAbonos.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotalAbonos.Text = "tbTotalAbonos"
            Me.tbTotalAbonos.Top = 1.25!
            Me.tbTotalAbonos.Width = 0.875!
            '
            'Line12
            '
            Me.Line12.Height = 0!
            Me.Line12.Left = 0!
            Me.Line12.LineWeight = 3!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0!
            Me.Line12.Width = 6.375!
            Me.Line12.X1 = 0!
            Me.Line12.X2 = 6.375!
            Me.Line12.Y1 = 0!
            Me.Line12.Y2 = 0!
            '
            'tbTCredito
            '
            Me.tbTCredito.Height = 0.1875!
            Me.tbTCredito.Left = 4.125!
            Me.tbTCredito.Name = "tbTCredito"
            Me.tbTCredito.OutputFormat = resources.GetString("tbTCredito.OutputFormat")
            Me.tbTCredito.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTCredito.Text = "tbTCredito"
            Me.tbTCredito.Top = 0!
            Me.tbTCredito.Width = 1!
            '
            'tbNoTarjetaCredito
            '
            Me.tbNoTarjetaCredito.Height = 0.1875!
            Me.tbNoTarjetaCredito.Left = 0.125!
            Me.tbNoTarjetaCredito.Name = "tbNoTarjetaCredito"
            Me.tbNoTarjetaCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbNoTarjetaCredito.Text = "tbNoTarjetaCredito"
            Me.tbNoTarjetaCredito.Top = 0!
            Me.tbNoTarjetaCredito.Width = 1.75!
            '
            'tbNoAutorizacionTDC
            '
            Me.tbNoAutorizacionTDC.Height = 0.1875!
            Me.tbNoAutorizacionTDC.Left = 1.875!
            Me.tbNoAutorizacionTDC.Name = "tbNoAutorizacionTDC"
            Me.tbNoAutorizacionTDC.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbNoAutorizacionTDC.Text = "tbNoAutorizacionTDC"
            Me.tbNoAutorizacionTDC.Top = 0!
            Me.tbNoAutorizacionTDC.Width = 1.8125!
            '
            'Label13
            '
            Me.Label13.Height = 0.1875!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 3.75!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label13.Text = "Vale de Caja :"
            Me.Label13.Top = 0.0625!
            Me.Label13.Width = 1!
            '
            'Label14
            '
            Me.Label14.Height = 0.1875!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 3.75!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label14.Text = "Penalización :"
            Me.Label14.Top = 0.3125!
            Me.Label14.Width = 1!
            '
            'Label15
            '
            Me.Label15.Height = 0.1875!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 3.75!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; font-family: Arial"
            Me.Label15.Text = "Importe a Favor :"
            Me.Label15.Top = 0.5625!
            Me.Label15.Width = 1.25!
            '
            'tbValeCaja
            '
            Me.tbValeCaja.Height = 0.1875!
            Me.tbValeCaja.Left = 5.1875!
            Me.tbValeCaja.Name = "tbValeCaja"
            Me.tbValeCaja.OutputFormat = resources.GetString("tbValeCaja.OutputFormat")
            Me.tbValeCaja.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbValeCaja.Text = "tbValeCaja"
            Me.tbValeCaja.Top = 0.0625!
            Me.tbValeCaja.Width = 1.0625!
            '
            'tbPenalizacion
            '
            Me.tbPenalizacion.Height = 0.1875!
            Me.tbPenalizacion.Left = 5.1875!
            Me.tbPenalizacion.Name = "tbPenalizacion"
            Me.tbPenalizacion.OutputFormat = resources.GetString("tbPenalizacion.OutputFormat")
            Me.tbPenalizacion.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbPenalizacion.Text = "tbPenalizacion"
            Me.tbPenalizacion.Top = 0.3125!
            Me.tbPenalizacion.Width = 1.0625!
            '
            'tbImporteFavor
            '
            Me.tbImporteFavor.Height = 0.1875!
            Me.tbImporteFavor.Left = 5.0625!
            Me.tbImporteFavor.Name = "tbImporteFavor"
            Me.tbImporteFavor.OutputFormat = resources.GetString("tbImporteFavor.OutputFormat")
            Me.tbImporteFavor.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; font-fa"& _ 
                "mily: Arial"
            Me.tbImporteFavor.Text = "tbImporteFavor"
            Me.tbImporteFavor.Top = 0.5625!
            Me.tbImporteFavor.Width = 1.1875!
            '
            'Line13
            '
            Me.Line13.Height = 0!
            Me.Line13.Left = 0!
            Me.Line13.LineWeight = 3!
            Me.Line13.Name = "Line13"
            Me.Line13.Top = 0.8020833!
            Me.Line13.Width = 6.4375!
            Me.Line13.X1 = 0!
            Me.Line13.X2 = 6.4375!
            Me.Line13.Y1 = 0.8020833!
            Me.Line13.Y2 = 0.8020833!
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
            Me.PrintWidth = 6.479167!
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
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNoTarjetaCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNoAutorizacionTDC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbValeCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPenalizacion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporteFavor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
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

            Me.tbFolio.Text = .ValeCajaID

            Me.tbFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            Me.tbCliente.Text = .Nombre

            Me.tbDocumentoTipo.Text = .TipoDocumento

            Me.tbDocumentoFolio.Text = .FolioDocumento

            Me.tbDocumentoImporte.Text = Format(.DocumentoImporte, "Currency")

            Me.tbTotalAbonos.Text = Format(oDistribucionContrato.TotalAbonos, "Standard")



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

            tbPenalizacion.Text = Format(oDistribucionContrato.Penalizacion, "Standard")

            tbImporteFavor.Text = decImporteFavor

        End With

    End Sub

#End Region


End Class
