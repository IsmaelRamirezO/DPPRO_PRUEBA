Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras

Public Class rptComprobanteAbonoCreditoDirecto
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oAbonoCredito As AbonoCreditoDirecto, ByVal oAbonoDPVale As AbonoDPVale, ByVal Nombre As String)
        MyBase.New()
        InitializeComponent()

        Me.DataSource = oAbonoCredito.FormasDePago
        Me.DataMember = "FormasPago"


        Me.txtCodFormaPago.DataField = "IDFormaPago"
        Me.txtMontoFormaPago.DataField = "Total"

        'Me.txtFolio.Text = oAbonoDPVale.IDAbono
        Me.txtFolio.Text = oAbonoCredito.DocnumFB05
        Me.txtAsociado.Text = oAbonoCredito.AsociadoID & " " & Nombre

        Me.txtFecha.Text = Now
        Me.txtCantidad.Text = Format(oAbonoDPVale.MontoPago, "C")

        Dim Cantidad() As String = CStr(oAbonoDPVale.MontoPago).Split(".")
        Dim letra As New Letras

        If Cantidad.Length < 2 Then

            Me.txtImporteLetra.Text = "(" & letra.Letras(Cantidad(0)) & " Pesos 00/100 M.N.)"

        Else

            Me.txtImporteLetra.Text = "(" & letra.Letras(Cantidad(0)) & " Pesos " & Cantidad(1) & "/100 M.N.)"

        End If

        Dim rptFacturas As New rptFacturasAbonodasCDT(oAbonoCredito.Facturas)

        Me.SubReport1.Report = rptFacturas
        Me.SubReport1.Report.DataSource = rptFacturas.DataSource
        Me.SubReport1.Report.DataMember = rptFacturas.DataMember

        'Me.Run()

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtAsociado As TextBox = Nothing
	Private SubReport1 As SubReport = Nothing
	Private txtFecha As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtImporteLetra As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtCodFormaPago As TextBox = Nothing
	Private txtMontoFormaPago As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptComprobanteAbonoCreditoDirecto))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtAsociado = New DataDynamics.ActiveReports.TextBox()
            Me.SubReport1 = New DataDynamics.ActiveReports.SubReport()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporteLetra = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtCodFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtMontoFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteLetra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMontoFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtAsociado, Me.SubReport1, Me.txtFecha, Me.txtCantidad, Me.txtImporteLetra, Me.Label8, Me.Label9, Me.Label11, Me.txtCodFormaPago, Me.txtMontoFormaPago, Me.Label10})
            Me.PageHeader.Height = 4.6875!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 2.6875!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "font-size: 9pt"
            Me.txtFolio.Text = "No. Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 1!
            '
            'txtAsociado
            '
            Me.txtAsociado.Height = 0.2!
            Me.txtAsociado.Left = 0.4375!
            Me.txtAsociado.Name = "txtAsociado"
            Me.txtAsociado.Style = "font-size: 9pt"
            Me.txtAsociado.Text = "Recibi de"
            Me.txtAsociado.Top = 1.125!
            Me.txtAsociado.Width = 3.1875!
            '
            'SubReport1
            '
            Me.SubReport1.CloseBorder = false
            Me.SubReport1.Height = 0.6156499!
            Me.SubReport1.Left = 0.0625!
            Me.SubReport1.Name = "SubReport1"
            Me.SubReport1.Report = Nothing
            Me.SubReport1.Top = 1.88435!
            Me.SubReport1.Width = 3.875!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.67!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 9pt"
            Me.txtFecha.Text = "Fecha"
            Me.txtFecha.Top = 2.563!
            Me.txtFecha.Width = 1.692913!
            '
            'txtCantidad
            '
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 1.26!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "font-size: 9pt"
            Me.txtCantidad.Text = "txtCantidad"
            Me.txtCantidad.Top = 2.835!
            Me.txtCantidad.Width = 1!
            '
            'txtImporteLetra
            '
            Me.txtImporteLetra.Height = 0.2!
            Me.txtImporteLetra.Left = 0.0625!
            Me.txtImporteLetra.Name = "txtImporteLetra"
            Me.txtImporteLetra.Style = "font-size: 9pt"
            Me.txtImporteLetra.Text = "txtImporteLetra"
            Me.txtImporteLetra.Top = 4.0625!
            Me.txtImporteLetra.Width = 3.875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.6181104!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "font-size: 9pt"
            Me.Label8.Text = "Factura"
            Me.Label8.Top = 1.6875!
            Me.Label8.Width = 0.5068896!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 1.391733!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 9pt"
            Me.Label9.Text = "Abono"
            Me.Label9.Top = 1.6875!
            Me.Label9.Width = 0.8582674!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.5625!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "font-size: 9pt"
            Me.Label11.Text = "Abono a Crédito Directo Tienda"
            Me.Label11.Top = 0!
            Me.Label11.Width = 2.125!
            '
            'txtCodFormaPago
            '
            Me.txtCodFormaPago.Height = 0.2!
            Me.txtCodFormaPago.Left = 0.5625!
            Me.txtCodFormaPago.Name = "txtCodFormaPago"
            Me.txtCodFormaPago.Style = "font-size: 9pt"
            Me.txtCodFormaPago.Text = "Forma Pago"
            Me.txtCodFormaPago.Top = 4.375!
            Me.txtCodFormaPago.Width = 1!
            '
            'txtMontoFormaPago
            '
            Me.txtMontoFormaPago.Height = 0.2!
            Me.txtMontoFormaPago.Left = 1.6875!
            Me.txtMontoFormaPago.Name = "txtMontoFormaPago"
            Me.txtMontoFormaPago.OutputFormat = resources.GetString("txtMontoFormaPago.OutputFormat")
            Me.txtMontoFormaPago.Style = "font-size: 9pt"
            Me.txtMontoFormaPago.Text = "Cant. F.P."
            Me.txtMontoFormaPago.Top = 4.375!
            Me.txtMontoFormaPago.Width = 1!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.517225!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-size: 9pt"
            Me.Label10.Text = "Saldo"
            Me.Label10.Top = 1.6875!
            Me.Label10.Width = 0.857775!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0.7847222!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 3.989583!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteLetra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMontoFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



    Private Sub rptComprobanteAbonoCreditoDirecto_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
