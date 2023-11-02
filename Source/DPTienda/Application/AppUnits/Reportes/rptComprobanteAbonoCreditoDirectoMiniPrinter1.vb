Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras

Public Class rptComprobanteAbonoCreditoDirectoMiniPrinter
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

        Dim rptFacturas As New rptFacturasAbonodasCDTMiniPrinter(oAbonoCredito.Facturas)

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
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptComprobanteAbonoCreditoDirectoMiniPrinter))
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
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
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
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0.3645833!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtAsociado, Me.SubReport1, Me.txtFecha, Me.txtCantidad, Me.txtImporteLetra, Me.Label8, Me.Label9, Me.Label11, Me.txtCodFormaPago, Me.txtMontoFormaPago, Me.Label10, Me.Label12, Me.Label13, Me.Label14})
            Me.PageHeader.Height = 3.176389!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.1574803!
            Me.txtFolio.Left = 0.7283465!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtFolio.Text = "No. Folio"
            Me.txtFolio.Top = 0.472441!
            Me.txtFolio.Width = 1!
            '
            'txtAsociado
            '
            Me.txtAsociado.Height = 0.2!
            Me.txtAsociado.Left = 0.2559055!
            Me.txtAsociado.Name = "txtAsociado"
            Me.txtAsociado.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtAsociado.Text = "Recibi de"
            Me.txtAsociado.Top = 0.9611222!
            Me.txtAsociado.Width = 2.440945!
            '
            'SubReport1
            '
            Me.SubReport1.CloseBorder = false
            Me.SubReport1.Height = 0.7086611!
            Me.SubReport1.Left = 0.2362205!
            Me.SubReport1.Name = "SubReport1"
            Me.SubReport1.Report = Nothing
            Me.SubReport1.Top = 1.496063!
            Me.SubReport1.Width = 2.42126!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1574803!
            Me.txtFecha.Left = 0.7711611!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtFecha.Text = "Fecha"
            Me.txtFecha.Top = 0.7086611!
            Me.txtFecha.Width = 1.692913!
            '
            'txtCantidad
            '
            Me.txtCantidad.Height = 0.1574805!
            Me.txtCantidad.Left = 1.889764!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
            Me.txtCantidad.Text = "txtCantidad"
            Me.txtCantidad.Top = 2.267224!
            Me.txtCantidad.Width = 0.7637792!
            '
            'txtImporteLetra
            '
            Me.txtImporteLetra.Height = 0.3257954!
            Me.txtImporteLetra.Left = 0.2559055!
            Me.txtImporteLetra.Name = "txtImporteLetra"
            Me.txtImporteLetra.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtImporteLetra.Text = "txtImporteLetra"
            Me.txtImporteLetra.Top = 2.503445!
            Me.txtImporteLetra.Width = 2.42126!
            '
            'Label8
            '
            Me.Label8.Height = 0.1574803!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.3346457!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: right; font-size: 8.25pt; font-family: Tahoma"
            Me.Label8.Text = "Factura"
            Me.Label8.Top = 1.259842!
            Me.Label8.Width = 0.551181!
            '
            'Label9
            '
            Me.Label9.Height = 0.1574803!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 1.102362!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label9.Text = "Abono"
            Me.Label9.Top = 1.259842!
            Me.Label9.Width = 0.5511812!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.551181!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "font-weight: bold; font-size: 9pt; font-family: Tahoma"
            Me.Label11.Text = "ABONO A CRÉDITO DIRECTO"
            Me.Label11.Top = 0.07874014!
            Me.Label11.Width = 1.889764!
            '
            'txtCodFormaPago
            '
            Me.txtCodFormaPago.Height = 0.1574803!
            Me.txtCodFormaPago.Left = 0.7086611!
            Me.txtCodFormaPago.Name = "txtCodFormaPago"
            Me.txtCodFormaPago.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtCodFormaPago.Text = "Forma Pago"
            Me.txtCodFormaPago.Top = 2.992126!
            Me.txtCodFormaPago.Width = 0.7086611!
            '
            'txtMontoFormaPago
            '
            Me.txtMontoFormaPago.Height = 0.1574802!
            Me.txtMontoFormaPago.Left = 1.496063!
            Me.txtMontoFormaPago.Name = "txtMontoFormaPago"
            Me.txtMontoFormaPago.OutputFormat = resources.GetString("txtMontoFormaPago.OutputFormat")
            Me.txtMontoFormaPago.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.txtMontoFormaPago.Text = "Cant. F.P."
            Me.txtMontoFormaPago.Top = 2.992126!
            Me.txtMontoFormaPago.Width = 0.6299215!
            '
            'Label10
            '
            Me.Label10.Height = 0.1574803!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.811024!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label10.Text = "Saldo"
            Me.Label10.Top = 1.259842!
            Me.Label10.Width = 0.551181!
            '
            'Label12
            '
            Me.Label12.Height = 0.1574803!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.2559055!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label12.Text = "FOLIO :"
            Me.Label12.Top = 0.472441!
            Me.Label12.Width = 0.472441!
            '
            'Label13
            '
            Me.Label13.Height = 0.1574803!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.2559055!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label13.Text = "FECHA :"
            Me.Label13.Top = 0.7086611!
            Me.Label13.Width = 0.472441!
            '
            'Label14
            '
            Me.Label14.Height = 0.1574803!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 1.338583!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "font-size: 8.25pt; font-family: Tahoma"
            Me.Label14.Text = "Importe"
            Me.Label14.Top = 2.267224!
            Me.Label14.Width = 0.5068896!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11.69306!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 2.992361!
            Me.PrintWidth = 2.770833!
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
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
