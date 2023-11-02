Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago

Public Class rptOtrosPagosEcomm
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oLetras As cImprimirFactura
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblRef As DataDynamics.ActiveReports.Label
    Friend WithEvents lblImporte As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMetodoPago As DataDynamics.ActiveReports.Label
    Friend WithEvents lblVale As DataDynamics.ActiveReports.Label
    Friend WithEvents txtRef As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtImporte As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMetodoPago As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVale As DataDynamics.ActiveReports.TextBox
    Dim oOP As OtrosPagos

    Public Sub New(ByVal sNoOrden As String, ByVal Concepto As String, ByVal tipopago As Integer, ByVal vale As String)

        MyBase.New()
        InitializeComponent()
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        Me.tbNotas.Text = pagoMgr.GetNotaTicketTiposPagosEcommById(tipopago)
        oOP = New OtrosPagos(sNoOrden.Trim, Concepto, 2)

        Me.txtFecha.Text = Format(Date.Now, "dd-MM-yyyy")
        Me.tbNoOrden.Text = oOP.NumOrden
        Me.txtRef.Text = oOP.NumOrden & "ECPTVL"
        Me.txtImporte.Text = oOP.TotalPago.ToString("c")

        Me.txtMetodoPago.Text = oOP.OtrosPagosDetalles(0).CodFormasPago
        Me.txtVale.Text = vale
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Label16 As Label = Nothing
    Private lblOrden As Label = Nothing
    Private tbNoOrden As TextBox = Nothing
    Private tbNotas As TextBox = Nothing
    Private Label8 As Label = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptOtrosPagosEcomm))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.lblOrden = New DataDynamics.ActiveReports.Label()
        Me.tbNoOrden = New DataDynamics.ActiveReports.TextBox()
        Me.tbNotas = New DataDynamics.ActiveReports.TextBox()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.lblRef = New DataDynamics.ActiveReports.Label()
        Me.lblImporte = New DataDynamics.ActiveReports.Label()
        Me.lblMetodoPago = New DataDynamics.ActiveReports.Label()
        Me.lblVale = New DataDynamics.ActiveReports.Label()
        Me.txtRef = New DataDynamics.ActiveReports.TextBox()
        Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
        Me.txtMetodoPago = New DataDynamics.ActiveReports.TextBox()
        Me.txtVale = New DataDynamics.ActiveReports.TextBox()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNoOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMetodoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMetodoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label16, Me.lblOrden, Me.tbNoOrden, Me.tbNotas, Me.Label8, Me.Label1, Me.txtFecha, Me.lblRef, Me.lblImporte, Me.lblMetodoPago, Me.lblVale, Me.txtRef, Me.txtImporte, Me.txtMetodoPago, Me.txtVale})
        Me.ReportHeader.Height = 2.978473!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Label16
        '
        Me.Label16.Height = 0.1574803!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.237!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label16.Text = "COMPROBANTE DE PAGO"
        Me.Label16.Top = 0.364!
        Me.Label16.Width = 2.43061!
        '
        'lblOrden
        '
        Me.lblOrden.Height = 0.1574803!
        Me.lblOrden.HyperLink = Nothing
        Me.lblOrden.Left = 0.237!
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblOrden.Text = "No. Orden:"
        Me.lblOrden.Top = 0.9810001!
        Me.lblOrden.Width = 0.7670001!
        '
        'tbNoOrden
        '
        Me.tbNoOrden.Height = 0.1574803!
        Me.tbNoOrden.Left = 1.074!
        Me.tbNoOrden.Name = "tbNoOrden"
        Me.tbNoOrden.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.tbNoOrden.Text = Nothing
        Me.tbNoOrden.Top = 0.9810001!
        Me.tbNoOrden.Width = 1.049869!
        '
        'tbNotas
        '
        Me.tbNotas.CanShrink = True
        Me.tbNotas.Height = 0.5899987!
        Me.tbNotas.Left = 0.102!
        Me.tbNotas.Name = "tbNotas"
        Me.tbNotas.Style = "text-align: justify; font-weight: normal; font-size: 8.25pt; font-family: Tahoma;" & _
    " text-justify: auto"
        Me.tbNotas.Text = "Nota: En caso de cancelación o devolución de algún producto es necesario que se c" & _
    "omunique a nuestros números de atención a clientes: 01 800 0028 774"
        Me.tbNotas.Top = 2.254!
        Me.tbNotas.Width = 2.56585!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574803!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.237!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label8.Text = "TIENDA"
        Me.Label8.Top = 0.125!
        Me.Label8.Width = 2.4375!
        '
        'Label1
        '
        Me.Label1.Height = 0.1574803!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.004!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.Label1.Text = "Fecha:"
        Me.Label1.Top = 0.719!
        Me.Label1.Width = 0.475!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1574803!
        Me.txtFecha.Left = 1.479!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 9pt; font-fa" & _
    "mily: Tahoma"
        Me.txtFecha.Text = "00/00/0000"
        Me.txtFecha.Top = 0.7190001!
        Me.txtFecha.Width = 1.217869!
        '
        'lblRef
        '
        Me.lblRef.Height = 0.1574803!
        Me.lblRef.HyperLink = Nothing
        Me.lblRef.Left = 0.237!
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblRef.Text = "Referencia:"
        Me.lblRef.Top = 1.20098!
        Me.lblRef.Width = 0.767!
        '
        'lblImporte
        '
        Me.lblImporte.Height = 0.1574803!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 0.237!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblImporte.Text = "Importe:"
        Me.lblImporte.Top = 1.420961!
        Me.lblImporte.Width = 0.663!
        '
        'lblMetodoPago
        '
        Me.lblMetodoPago.Height = 0.157059!
        Me.lblMetodoPago.HyperLink = Nothing
        Me.lblMetodoPago.Left = 0.237!
        Me.lblMetodoPago.Name = "lblMetodoPago"
        Me.lblMetodoPago.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblMetodoPago.Text = "Método de Pago:"
        Me.lblMetodoPago.Top = 1.640941!
        Me.lblMetodoPago.Width = 1.173!
        '
        'lblVale
        '
        Me.lblVale.Height = 0.1574803!
        Me.lblVale.HyperLink = Nothing
        Me.lblVale.Left = 0.237!
        Me.lblVale.Name = "lblVale"
        Me.lblVale.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
        Me.lblVale.Text = "No. de Vale:"
        Me.lblVale.Top = 1.860921!
        Me.lblVale.Width = 0.837!
        '
        'txtRef
        '
        Me.txtRef.Height = 0.1574803!
        Me.txtRef.Left = 1.074!
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.txtRef.Text = Nothing
        Me.txtRef.Top = 1.20098!
        Me.txtRef.Width = 1.049869!
        '
        'txtImporte
        '
        Me.txtImporte.Height = 0.1574803!
        Me.txtImporte.Left = 1.004!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
        Me.txtImporte.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.txtImporte.Text = "100"
        Me.txtImporte.Top = 1.421!
        Me.txtImporte.Width = 1.049869!
        '
        'txtMetodoPago
        '
        Me.txtMetodoPago.Height = 0.1574803!
        Me.txtMetodoPago.Left = 1.479!
        Me.txtMetodoPago.Name = "txtMetodoPago"
        Me.txtMetodoPago.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.txtMetodoPago.Text = "Dpvale"
        Me.txtMetodoPago.Top = 1.641!
        Me.txtMetodoPago.Width = 1.218!
        '
        'txtVale
        '
        Me.txtVale.Height = 0.1574803!
        Me.txtVale.Left = 1.157!
        Me.txtVale.Name = "txtVale"
        Me.txtVale.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
    "ly: Tahoma"
        Me.txtVale.Text = Nothing
        Me.txtVale.Top = 1.861!
        Me.txtVale.Width = 1.362!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'rptOtrosPagosEcomm
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
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNoOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMetodoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMetodoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
