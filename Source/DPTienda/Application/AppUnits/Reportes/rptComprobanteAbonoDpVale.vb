Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados

Public Class rptComprobanteAbonoDpVale
Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oAbonoDpVale As AbonoDPVale, ByVal frmAbonoDPVale As FrmAbonoDPVale, ByVal oAsociado As Asociado)
        MyBase.New()
        InitializeComponent()

        Me.txtFolio.Text = oAbonoDpVale.IDAbono
        Me.txtFecha.Text = oAbonoDpVale.Fecha
        Me.txtAsociado.Text = oAbonoDpVale.AsociadoID & " " & frmAbonoDPVale.EBAsociado.Text
        Me.txtAbono.Text = Format(oAbonoDpVale.MontoPago, "c")

        Dim Ob As New Letras
        Dim parametros() As String = CStr(oAbonoDpVale.MontoPago).Split(".")
        parametros(0) = parametros(0).Replace("$", "")
        If parametros.Length > 1 Then
            Me.txtAbonoLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & parametros(1) & "/100 M.N.)"
        Else
            Me.txtAbonoLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & "00/100 M.N.)"
        End If


        Me.txtAbono2.Text = Format(oAbonoDpVale.MontoPago, "c")


        Me.txtDescuentoPorcent.Text = Format(frmAbonoDPVale.nbBonificacion.Value, "00.00%")
        Me.txtDescuentoCantidad.Text = Format(oAbonoDpVale.Bonificacion, "c")

        Me.DataSource = oAbonoDpVale.Detalle
        Me.DataMember = "FormasPago"
        Me.txtFormaPago.DataField = "IDFormaPago"
        Me.txtMontoFormaPago.DataField = "Monto"

        Me.txtSaldo.Text = Format(oAbonoDpVale.SaldNuevo, "c")
        'Me.txtSaldoVencido.Text = Format(oAsociado.SaldoVencDPVale, "c")
        Me.txtPagoMinimo.Text = Format(oAbonoDpVale.PagoMin, "c")
        Me.txtLimiteCredito.Text = Format(oAsociado.LimiteCreditoDPVale, "c")
        Me.txtResponsable.Text = " "



    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtAsociado As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtAbono As TextBox = Nothing
	Private txtAbonoLetra As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private txtDescuentoPorcent As TextBox = Nothing
	Private txtDescuentoCantidad As TextBox = Nothing
	Private txtAbono2 As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private txtFormaPago As TextBox = Nothing
	Private txtMontoFormaPago As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private txtSaldo As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private txtSaldoVencido As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private txtPagoMinimo As TextBox = Nothing
	Private Label11 As Label = Nothing
	Private txtLimiteCredito As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Label12 As Label = Nothing
	Private txtResponsable As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptComprobanteAbonoDpVale))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtAsociado = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonoLetra = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtDescuentoPorcent = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescuentoCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbono2 = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtMontoFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.txtSaldoVencido = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.txtPagoMinimo = New DataDynamics.ActiveReports.TextBox()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtLimiteCredito = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonoLetra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuentoPorcent,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuentoCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbono2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMontoFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldoVencido,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPagoMinimo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLimiteCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFormaPago, Me.txtMontoFormaPago})
            Me.Detail.Height = 0.21875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.txtFolio, Me.Label2, Me.txtFecha, Me.Label3, Me.txtAsociado, Me.Label4, Me.txtAbono, Me.txtAbonoLetra, Me.Label5, Me.Label6, Me.txtDescuentoPorcent, Me.txtDescuentoCantidad, Me.txtAbono2})
            Me.PageHeader.Height = 1.6875!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.2076389!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7})
            Me.GroupHeader1.Height = 0.2291667!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label8, Me.txtSaldo, Me.Label9, Me.txtSaldoVencido, Me.Label10, Me.txtPagoMinimo, Me.Label11, Me.txtLimiteCredito, Me.Line1, Me.Label12, Me.txtResponsable})
            Me.GroupFooter1.Height = 1.575!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Folio:"
            Me.Label1.Top = 0.1875!
            Me.Label1.Width = 0.5!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0.8125!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-decoration: none; font-weight: bold; font-style: normal"
            Me.txtFolio.Text = "TextBox1"
            Me.txtFolio.Top = 0.1875!
            Me.txtFolio.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.375!
            Me.Label2.Width = 0.5!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.8125!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-weight: bold"
            Me.txtFecha.Text = "TextBox1"
            Me.txtFecha.Top = 0.375!
            Me.txtFecha.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Asociado:"
            Me.Label3.Top = 0.6875!
            Me.Label3.Width = 0.6875!
            '
            'txtAsociado
            '
            Me.txtAsociado.Height = 0.2!
            Me.txtAsociado.Left = 0.8125!
            Me.txtAsociado.Name = "txtAsociado"
            Me.txtAsociado.OutputFormat = resources.GetString("txtAsociado.OutputFormat")
            Me.txtAsociado.Style = "text-align: left"
            Me.txtAsociado.Text = "TextBox1"
            Me.txtAsociado.Top = 0.6875!
            Me.txtAsociado.Width = 4.375!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.0625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "Abono:"
            Me.Label4.Top = 1!
            Me.Label4.Width = 0.5!
            '
            'txtAbono
            '
            Me.txtAbono.Height = 0.2!
            Me.txtAbono.Left = 0.8125!
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.OutputFormat = resources.GetString("txtAbono.OutputFormat")
            Me.txtAbono.Style = "text-align: right"
            Me.txtAbono.Text = "TextBox1"
            Me.txtAbono.Top = 1!
            Me.txtAbono.Width = 0.6875!
            '
            'txtAbonoLetra
            '
            Me.txtAbonoLetra.Height = 0.2!
            Me.txtAbonoLetra.Left = 1.5625!
            Me.txtAbonoLetra.Name = "txtAbonoLetra"
            Me.txtAbonoLetra.OutputFormat = resources.GetString("txtAbonoLetra.OutputFormat")
            Me.txtAbonoLetra.Style = "text-align: left"
            Me.txtAbonoLetra.Text = "TextBox1"
            Me.txtAbonoLetra.Top = 1!
            Me.txtAbonoLetra.Width = 3.625!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.716535!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = ""
            Me.Label5.Text = "Abono:"
            Me.Label5.Top = 1.299212!
            Me.Label5.Visible = false
            Me.Label5.Width = 0.5!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Descuento:"
            Me.Label6.Top = 1.3125!
            Me.Label6.Width = 0.75!
            '
            'txtDescuentoPorcent
            '
            Me.txtDescuentoPorcent.Height = 0.2!
            Me.txtDescuentoPorcent.Left = 0.875!
            Me.txtDescuentoPorcent.Name = "txtDescuentoPorcent"
            Me.txtDescuentoPorcent.OutputFormat = resources.GetString("txtDescuentoPorcent.OutputFormat")
            Me.txtDescuentoPorcent.Text = "TextBox1"
            Me.txtDescuentoPorcent.Top = 1.3125!
            Me.txtDescuentoPorcent.Width = 0.5!
            '
            'txtDescuentoCantidad
            '
            Me.txtDescuentoCantidad.Height = 0.2!
            Me.txtDescuentoCantidad.Left = 1.4375!
            Me.txtDescuentoCantidad.Name = "txtDescuentoCantidad"
            Me.txtDescuentoCantidad.OutputFormat = resources.GetString("txtDescuentoCantidad.OutputFormat")
            Me.txtDescuentoCantidad.Style = "text-align: right"
            Me.txtDescuentoCantidad.Text = "TextBox2"
            Me.txtDescuentoCantidad.Top = 1.3125!
            Me.txtDescuentoCantidad.Width = 1!
            '
            'txtAbono2
            '
            Me.txtAbono2.Height = 0.2!
            Me.txtAbono2.Left = 3.466535!
            Me.txtAbono2.Name = "txtAbono2"
            Me.txtAbono2.OutputFormat = resources.GetString("txtAbono2.OutputFormat")
            Me.txtAbono2.Style = "text-align: right"
            Me.txtAbono2.Text = "TextBox1"
            Me.txtAbono2.Top = 1.299212!
            Me.txtAbono2.Visible = false
            Me.txtAbono2.Width = 1!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Pago:"
            Me.Label7.Top = 0!
            Me.Label7.Width = 0.5!
            '
            'txtFormaPago
            '
            Me.txtFormaPago.Height = 0.2!
            Me.txtFormaPago.Left = 0.875!
            Me.txtFormaPago.Name = "txtFormaPago"
            Me.txtFormaPago.Text = "TextBox1"
            Me.txtFormaPago.Top = 0!
            Me.txtFormaPago.Width = 0.3125!
            '
            'txtMontoFormaPago
            '
            Me.txtMontoFormaPago.Height = 0.2!
            Me.txtMontoFormaPago.Left = 1.25!
            Me.txtMontoFormaPago.Name = "txtMontoFormaPago"
            Me.txtMontoFormaPago.OutputFormat = resources.GetString("txtMontoFormaPago.OutputFormat")
            Me.txtMontoFormaPago.Style = "text-align: right"
            Me.txtMontoFormaPago.Text = "TextBox2"
            Me.txtMontoFormaPago.Top = 0!
            Me.txtMontoFormaPago.Width = 1!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.0625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Saldo:"
            Me.Label8.Top = 0!
            Me.Label8.Width = 0.4375!
            '
            'txtSaldo
            '
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 1.25!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right"
            Me.txtSaldo.Text = "TextBox1"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 1!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.559055!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = ""
            Me.Label9.Text = "Vencido:"
            Me.Label9.Top = 0.2362205!
            Me.Label9.Visible = false
            Me.Label9.Width = 0.625!
            '
            'txtSaldoVencido
            '
            Me.txtSaldoVencido.Height = 0.2!
            Me.txtSaldoVencido.Left = 3.746556!
            Me.txtSaldoVencido.Name = "txtSaldoVencido"
            Me.txtSaldoVencido.OutputFormat = resources.GetString("txtSaldoVencido.OutputFormat")
            Me.txtSaldoVencido.Style = "text-align: right"
            Me.txtSaldoVencido.Text = "TextBox1"
            Me.txtSaldoVencido.Top = 0.2362205!
            Me.txtSaldoVencido.Visible = false
            Me.txtSaldoVencido.Width = 1!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.07874014!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = ""
            Me.Label10.Text = "Pago Mínimo:"
            Me.Label10.Top = 0.2755906!
            Me.Label10.Width = 0.9375!
            '
            'txtPagoMinimo
            '
            Me.txtPagoMinimo.Height = 0.2!
            Me.txtPagoMinimo.Left = 1.26624!
            Me.txtPagoMinimo.Name = "txtPagoMinimo"
            Me.txtPagoMinimo.OutputFormat = resources.GetString("txtPagoMinimo.OutputFormat")
            Me.txtPagoMinimo.Style = "text-align: right"
            Me.txtPagoMinimo.Text = "TextBox1"
            Me.txtPagoMinimo.Top = 0.2755906!
            Me.txtPagoMinimo.Width = 1!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.07874014!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = ""
            Me.Label11.Text = "Límite de Crédito:"
            Me.Label11.Top = 0.5255905!
            Me.Label11.Width = 1.125!
            '
            'txtLimiteCredito
            '
            Me.txtLimiteCredito.Height = 0.2!
            Me.txtLimiteCredito.Left = 1.26624!
            Me.txtLimiteCredito.Name = "txtLimiteCredito"
            Me.txtLimiteCredito.OutputFormat = resources.GetString("txtLimiteCredito.OutputFormat")
            Me.txtLimiteCredito.Style = "text-align: right"
            Me.txtLimiteCredito.Text = "TextBox2"
            Me.txtLimiteCredito.Top = 0.5255905!
            Me.txtLimiteCredito.Width = 1!
            '
            'Line1
            '
            Me.Line1.Height = 0.006944478!
            Me.Line1.Left = 0.08568458!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.9630902!
            Me.Line1.Width = 2.180556!
            Me.Line1.X1 = 0.08568458!
            Me.Line1.X2 = 2.26624!
            Me.Line1.Y1 = 0.9700347!
            Me.Line1.Y2 = 0.9630902!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 0.07874014!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = ""
            Me.Label12.Text = "Firma del Responsable:"
            Me.Label12.Top = 1.15059!
            Me.Label12.Width = 1.5625!
            '
            'txtResponsable
            '
            Me.txtResponsable.Height = 0.2!
            Me.txtResponsable.Left = 0.07874014!
            Me.txtResponsable.Name = "txtResponsable"
            Me.txtResponsable.Text = "TextBox3"
            Me.txtResponsable.Top = 0.9630902!
            Me.txtResponsable.Width = 1!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperName = "Custom paper"
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
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAsociado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonoLetra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuentoPorcent,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuentoCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbono2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMontoFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldoVencido,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPagoMinimo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLimiteCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtResponsable,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
