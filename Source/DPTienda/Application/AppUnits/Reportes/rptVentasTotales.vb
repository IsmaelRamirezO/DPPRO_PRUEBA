Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptVentasTotales
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
        InitializeComponent()
        Me.Label2.Text = Now.Date
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblReportTitle As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldImporte As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lblFieldFormaPago As Label = Nothing
	Private lblFieldPago As Label = Nothing
	Private lblFieldVendedor As Label = Nothing
	Private lblFieldCliente As Label = Nothing
	Private lblFieldTipoVenta As Label = Nothing
	Private lblFieldNCred As Label = Nothing
	Private lblReportDate As Label = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbArticulo As TextBox = Nothing
	Private tbImporte As TextBox = Nothing
	Private tbdescuento As TextBox = Nothing
	Private tbVendedor As TextBox = Nothing
	Private tbCliente As TextBox = Nothing
	Private tbTipoVenta As TextBox = Nothing
	Private tbFormaPago As TextBox = Nothing
	Private tbPago As TextBox = Nothing
	Private tbNcred As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label2 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtTotal As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasTotales))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
            Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
            Me.lblFieldCliente = New DataDynamics.ActiveReports.Label()
            Me.lblFieldTipoVenta = New DataDynamics.ActiveReports.Label()
            Me.lblFieldNCred = New DataDynamics.ActiveReports.Label()
            Me.lblReportDate = New DataDynamics.ActiveReports.Label()
            Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
            Me.tbArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
            Me.tbdescuento = New DataDynamics.ActiveReports.TextBox()
            Me.tbVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.tbCliente = New DataDynamics.ActiveReports.TextBox()
            Me.tbTipoVenta = New DataDynamics.ActiveReports.TextBox()
            Me.tbFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.tbPago = New DataDynamics.ActiveReports.TextBox()
            Me.tbNcred = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldNCred,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbdescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbNcred,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFormaPago, Me.tbPago, Me.tbNcred})
            Me.Detail.Height = 0.25!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.lblFieldFolio, Me.lblFieldArticulo, Me.lblFieldImporte, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldPago, Me.lblFieldVendedor, Me.lblFieldCliente, Me.lblFieldTipoVenta, Me.lblFieldNCred, Me.lblReportDate})
            Me.PageHeader.Height = 0.5104167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label2, Me.tbPageNumber, Me.Label3, Me.txtTotal, Me.Label5, Me.tbPageCount})
            Me.PageFooter.Height = 0.46875!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolio, Me.tbArticulo, Me.tbImporte, Me.tbdescuento, Me.tbVendedor, Me.tbCliente, Me.tbTipoVenta})
            Me.GroupHeader1.DataField = "FolioFactura"
            Me.GroupHeader1.Height = 0.21875!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.3937007!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 0.0625!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "font-size: 12pt; white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Ventas Total"
            Me.lblReportTitle.Top = -0.125!
            Me.lblReportTitle.Width = 2.125!
            '
            'lblFieldFolio
            '
            Me.lblFieldFolio.Height = 0.181!
            Me.lblFieldFolio.HyperLink = Nothing
            Me.lblFieldFolio.Left = 0!
            Me.lblFieldFolio.Name = "lblFieldFolio"
            Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFolio.Text = "Folio"
            Me.lblFieldFolio.Top = 0.3125!
            Me.lblFieldFolio.Width = 0.3125!
            '
            'lblFieldArticulo
            '
            Me.lblFieldArticulo.Height = 0.1811025!
            Me.lblFieldArticulo.HyperLink = Nothing
            Me.lblFieldArticulo.Left = 0.5625!
            Me.lblFieldArticulo.Name = "lblFieldArticulo"
            Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldArticulo.Text = "Total Art."
            Me.lblFieldArticulo.Top = 0.3125!
            Me.lblFieldArticulo.Width = 0.5625!
            '
            'lblFieldImporte
            '
            Me.lblFieldImporte.Height = 0.1811025!
            Me.lblFieldImporte.HyperLink = Nothing
            Me.lblFieldImporte.Left = 1.375!
            Me.lblFieldImporte.Name = "lblFieldImporte"
            Me.lblFieldImporte.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldImporte.Text = "Importe"
            Me.lblFieldImporte.Top = 0.3125!
            Me.lblFieldImporte.Width = 0.5!
            '
            'lblFieldDescuento
            '
            Me.lblFieldDescuento.Height = 0.1811025!
            Me.lblFieldDescuento.HyperLink = Nothing
            Me.lblFieldDescuento.Left = 2!
            Me.lblFieldDescuento.Name = "lblFieldDescuento"
            Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldDescuento.Text = "Descuento"
            Me.lblFieldDescuento.Top = 0.3125!
            Me.lblFieldDescuento.Width = 0.6875!
            '
            'lblFieldFormaPago
            '
            Me.lblFieldFormaPago.Height = 0.1811025!
            Me.lblFieldFormaPago.HyperLink = Nothing
            Me.lblFieldFormaPago.Left = 2.75!
            Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
            Me.lblFieldFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFormaPago.Text = "Forma Pago"
            Me.lblFieldFormaPago.Top = 0.3125!
            Me.lblFieldFormaPago.Width = 0.75!
            '
            'lblFieldPago
            '
            Me.lblFieldPago.Height = 0.1811025!
            Me.lblFieldPago.HyperLink = Nothing
            Me.lblFieldPago.Left = 3.8125!
            Me.lblFieldPago.Name = "lblFieldPago"
            Me.lblFieldPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldPago.Text = "Pago"
            Me.lblFieldPago.Top = 0.3125!
            Me.lblFieldPago.Width = 0.375!
            '
            'lblFieldVendedor
            '
            Me.lblFieldVendedor.Height = 0.1811025!
            Me.lblFieldVendedor.HyperLink = Nothing
            Me.lblFieldVendedor.Left = 4.375!
            Me.lblFieldVendedor.Name = "lblFieldVendedor"
            Me.lblFieldVendedor.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldVendedor.Text = "Vendedor"
            Me.lblFieldVendedor.Top = 0.3125!
            Me.lblFieldVendedor.Width = 0.625!
            '
            'lblFieldCliente
            '
            Me.lblFieldCliente.Height = 0.1811025!
            Me.lblFieldCliente.HyperLink = Nothing
            Me.lblFieldCliente.Left = 5.0625!
            Me.lblFieldCliente.Name = "lblFieldCliente"
            Me.lblFieldCliente.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldCliente.Text = "Cliente"
            Me.lblFieldCliente.Top = 0.3125!
            Me.lblFieldCliente.Width = 0.4375!
            '
            'lblFieldTipoVenta
            '
            Me.lblFieldTipoVenta.Height = 0.1811025!
            Me.lblFieldTipoVenta.HyperLink = Nothing
            Me.lblFieldTipoVenta.Left = 5.625!
            Me.lblFieldTipoVenta.Name = "lblFieldTipoVenta"
            Me.lblFieldTipoVenta.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldTipoVenta.Text = "Tipo Venta"
            Me.lblFieldTipoVenta.Top = 0.3125!
            Me.lblFieldTipoVenta.Width = 0.625!
            '
            'lblFieldNCred
            '
            Me.lblFieldNCred.Height = 0.181!
            Me.lblFieldNCred.HyperLink = Nothing
            Me.lblFieldNCred.Left = 6.5625!
            Me.lblFieldNCred.Name = "lblFieldNCred"
            Me.lblFieldNCred.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldNCred.Text = "Status"
            Me.lblFieldNCred.Top = 0.3125!
            Me.lblFieldNCred.Width = 0.3915!
            '
            'lblReportDate
            '
            Me.lblReportDate.Height = 0.1968504!
            Me.lblReportDate.HyperLink = Nothing
            Me.lblReportDate.Left = 5.3125!
            Me.lblReportDate.Name = "lblReportDate"
            Me.lblReportDate.Style = "text-align: right; font-size: 8.25pt; vertical-align: middle"
            Me.lblReportDate.Text = "Label2"
            Me.lblReportDate.Top = 0!
            Me.lblReportDate.Width = 1.612205!
            '
            'tbFolio
            '
            Me.tbFolio.DataField = "FolioFactura"
            Me.tbFolio.Height = 0.2!
            Me.tbFolio.Left = 0!
            Me.tbFolio.Name = "tbFolio"
            Me.tbFolio.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbFolio.Top = 0!
            Me.tbFolio.Width = 0.625!
            '
            'tbArticulo
            '
            Me.tbArticulo.DataField = "TotalArticulos"
            Me.tbArticulo.Height = 0.2!
            Me.tbArticulo.Left = 0.625!
            Me.tbArticulo.Name = "tbArticulo"
            Me.tbArticulo.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbArticulo.Top = 0!
            Me.tbArticulo.Width = 0.3125!
            '
            'tbImporte
            '
            Me.tbImporte.DataField = "Total"
            Me.tbImporte.Height = 0.2!
            Me.tbImporte.Left = 1.1315!
            Me.tbImporte.Name = "tbImporte"
            Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
            Me.tbImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbImporte.Text = "0"
            Me.tbImporte.Top = 0!
            Me.tbImporte.Width = 0.75!
            '
            'tbdescuento
            '
            Me.tbdescuento.DataField = "DescTotal"
            Me.tbdescuento.Height = 0.2!
            Me.tbdescuento.Left = 1.882!
            Me.tbdescuento.Name = "tbdescuento"
            Me.tbdescuento.OutputFormat = resources.GetString("tbdescuento.OutputFormat")
            Me.tbdescuento.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbdescuento.Top = 0!
            Me.tbdescuento.Width = 0.75!
            '
            'tbVendedor
            '
            Me.tbVendedor.DataField = "CodVendedor"
            Me.tbVendedor.Height = 0.2!
            Me.tbVendedor.Left = 4.375!
            Me.tbVendedor.Name = "tbVendedor"
            Me.tbVendedor.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbVendedor.Top = 0!
            Me.tbVendedor.Width = 0.5625!
            '
            'tbCliente
            '
            Me.tbCliente.DataField = "ClienteID"
            Me.tbCliente.Height = 0.2!
            Me.tbCliente.Left = 5.069!
            Me.tbCliente.Name = "tbCliente"
            Me.tbCliente.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.tbCliente.Top = 0!
            Me.tbCliente.Width = 0.4375!
            '
            'tbTipoVenta
            '
            Me.tbTipoVenta.DataField = "CodTipoVenta"
            Me.tbTipoVenta.Height = 0.2!
            Me.tbTipoVenta.Left = 5.7565!
            Me.tbTipoVenta.Name = "tbTipoVenta"
            Me.tbTipoVenta.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbTipoVenta.Top = 0!
            Me.tbTipoVenta.Width = 0.25!
            '
            'tbFormaPago
            '
            Me.tbFormaPago.DataField = "CodFormasPago"
            Me.tbFormaPago.Height = 0.2!
            Me.tbFormaPago.Left = 2.9375!
            Me.tbFormaPago.Name = "tbFormaPago"
            Me.tbFormaPago.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbFormaPago.Top = 0!
            Me.tbFormaPago.Width = 0.25!
            '
            'tbPago
            '
            Me.tbPago.DataField = "MontoPago"
            Me.tbPago.Height = 0.2!
            Me.tbPago.Left = 3.3195!
            Me.tbPago.Name = "tbPago"
            Me.tbPago.OutputFormat = resources.GetString("tbPago.OutputFormat")
            Me.tbPago.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbPago.Top = 0!
            Me.tbPago.Width = 0.8125!
            '
            'tbNcred
            '
            Me.tbNcred.DataField = "Status"
            Me.tbNcred.Height = 0.2!
            Me.tbNcred.Left = 6.507!
            Me.tbNcred.Name = "tbNcred"
            Me.tbNcred.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt"
            Me.tbNcred.Top = 0!
            Me.tbNcred.Width = 0.4375!
            '
            'Label4
            '
            Me.Label4.Height = 0.1968504!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.0625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.Label4.Text = "Comercial Dportenis, S.A. de C.V."
            Me.Label4.Top = 0.2593504!
            Me.Label4.Width = 2.362205!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.125!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
            Me.Label2.Text = "Página"
            Me.Label2.Top = 0.25!
            Me.Label2.Width = 0.5078735!
            '
            'tbPageNumber
            '
            Me.tbPageNumber.Height = 0.2!
            Me.tbPageNumber.Left = 5.679626!
            Me.tbPageNumber.Name = "tbPageNumber"
            Me.tbPageNumber.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageNumber.Text = "####"
            Me.tbPageNumber.Top = 0.25!
            Me.tbPageNumber.Width = 0.492126!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 6.17175!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label3.Text = "de"
            Me.Label3.Top = 0.25!
            Me.Label3.Width = 0.2952757!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 1.0625!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotal.Text = "0"
            Me.txtTotal.Top = 0!
            Me.txtTotal.Width = 1!
            '
            'Label5
            '
            Me.Label5.Height = 0.1968504!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.Label5.Text = "Total:"
            Me.Label5.Top = 0.009350416!
            Me.Label5.Width = 0.409941!
            '
            'tbPageCount
            '
            Me.tbPageCount.Height = 0.2!
            Me.tbPageCount.Left = 6.529528!
            Me.tbPageCount.Name = "tbPageCount"
            Me.tbPageCount.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageCount.Text = "####"
            Me.tbPageCount.Top = 0.25!
            Me.tbPageCount.Width = 0.492126!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.0625!
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
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldNCred,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbdescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTipoVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbNcred,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

	#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Detail.AddBookmark("Reporte Ventas Totales\Pagína " & Me.PageNumber.ToString & "\")

        'Me.txtTotal.Text = CDec(Me.txtTotal.Text) + CDec(DirectCast(Detail.Controls("tbPago"), TextBox).Text)


    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

        If DirectCast(GroupHeader1.Controls("tbImporte"), TextBox).Value < 0 Then
            DirectCast(GroupHeader1.Controls("tbImporte"), TextBox).ForeColor = System.Drawing.Color.Red
        Else
            DirectCast(GroupHeader1.Controls("tbImporte"), TextBox).ForeColor = System.Drawing.Color.Black
        End If

    End Sub
End Class
