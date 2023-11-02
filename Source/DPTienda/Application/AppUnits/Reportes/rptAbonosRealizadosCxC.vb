Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptAbonosRealizadosCxC
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataTable, ByVal Caja As String, ByVal Almacen As String, ByVal Rango As String, ByVal Status As Boolean)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = Data

        Me.DataMember = Data.TableName

        If Status Then

            Me.lblTitulo.Text = "REPORTE DE ABONOS A CUENTAS POR COBRAR"
            Me.lblStatus.Text = "STATUS : (A)"

        Else

            Me.lblTitulo.Text = "REPORTE DE ABONOS CANCELADOS A CUENTAS POR COBRAR"
            Me.lblStatus.Text = "STATUS : (C)"

        End If

        Me.lblFecha.Text = Format(Now, "short date")

        Me.lblRango.Text = Rango

        Me.lblCaja.Text = Caja

        Me.lblSucursal.Text = Almacen

        Me.PageSettings.Margins.Top = 0.6
        Me.PageSettings.Margins.Left = 0.4
        Me.PageSettings.Margins.Right = 0

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label9 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private lblStatus As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblCaja As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private lblPag As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private lblRango As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtFechaA As TextBox = Nothing
	Private txtFactura As TextBox = Nothing
	Private txtFechaFactura As TextBox = Nothing
	Private txtCliente As TextBox = Nothing
	Private txtFormaPago As TextBox = Nothing
	Private txtAbono As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonosRealizadosCxC))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.lblStatus = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblPag = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaA = New DataDynamics.ActiveReports.TextBox()
            Me.txtFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
            Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtFechaA, Me.txtFactura, Me.txtFechaFactura, Me.txtCliente, Me.txtFormaPago, Me.txtAbono, Me.txtSaldo, Me.TextBox2})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label9, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.lblStatus, Me.lblFecha, Me.lblCaja, Me.lblSucursal, Me.lblTitulo, Me.lblPag, Me.TextBox1, Me.Line1, Me.lblRango})
            Me.PageHeader.Height = 0.8854167!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox3, Me.TextBox4, Me.Line2})
            Me.GroupFooter1.Height = 0.2076389!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.6875!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 6.6875!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: left; font-size: 8pt; vertical-align: top"
            Me.Label9.Text = "USUARIO"
            Me.Label9.Top = 0.6875!
            Me.Label9.Width = 0.875!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label1.Text = "FOLIO"
            Me.Label1.Top = 0.6875!
            Me.Label1.Width = 0.625!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label2.Text = "FECHA"
            Me.Label2.Top = 0.6875!
            Me.Label2.Width = 0.6875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.25!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label3.Text = "FACTURA"
            Me.Label3.Top = 0.6875!
            Me.Label3.Width = 0.625!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.9375!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label4.Text = "FECHA F."
            Me.Label4.Top = 0.6875!
            Me.Label4.Width = 0.625!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label5.Text = "CLIENTE"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 1.75!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 4.5!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label6.Text = "F. PAGO"
            Me.Label6.Top = 0.6875!
            Me.Label6.Width = 0.5625!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label7.Text = "ABONO"
            Me.Label7.Top = 0.6875!
            Me.Label7.Width = 0.6875!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8pt; vertical-align: top"
            Me.Label8.Text = "SALDO"
            Me.Label8.Top = 0.6875!
            Me.Label8.Width = 0.6875!
            '
            'lblStatus
            '
            Me.lblStatus.Height = 0.2!
            Me.lblStatus.HyperLink = Nothing
            Me.lblStatus.Left = 6.5625!
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Style = "text-align: left; font-size: 8pt; vertical-align: top"
            Me.lblStatus.Text = "Status :    A"
            Me.lblStatus.Top = 0.4375!
            Me.lblStatus.Width = 1.0625!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 9pt"
            Me.lblFecha.Text = "lblFecha"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 1!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.2!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.0625!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "font-size: 9pt"
            Me.lblCaja.Text = "lblCaja"
            Me.lblCaja.Top = 0.25!
            Me.lblCaja.Width = 1!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.0625!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "font-size: 9pt"
            Me.lblSucursal.Text = "lblSucursal"
            Me.lblSucursal.Top = 0.4375!
            Me.lblSucursal.Width = 4.9375!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.484375!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 9pt"
            Me.lblTitulo.Text = "REPORTE DE ABONOS A CUENTAS POR COBRAR"
            Me.lblTitulo.Top = 0.07708333!
            Me.lblTitulo.Width = 4.75!
            '
            'lblPag
            '
            Me.lblPag.Height = 0.2!
            Me.lblPag.HyperLink = Nothing
            Me.lblPag.Left = 6.5625!
            Me.lblPag.Name = "lblPag"
            Me.lblPag.Style = "font-size: 9pt"
            Me.lblPag.Text = "Pag."
            Me.lblPag.Top = 0.0625!
            Me.lblPag.Width = 0.3125!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 7!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: right; font-size: 9pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Text = "txtPag"
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 0.5!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.6875!
            Me.Line1.Width = 7.6875!
            Me.Line1.X1 = 7.6875!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.6875!
            Me.Line1.Y2 = 0.6875!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.2!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 1.828125!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center; font-weight: normal; font-size: 9pt"
            Me.lblRango.Text = "De : 00/00/0000    Al : 00/00/0000"
            Me.lblRango.Top = 0.2645833!
            Me.lblRango.Width = 4.0625!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "AbonoID"
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right; font-size: 8pt"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.5625!
            '
            'txtFechaA
            '
            Me.txtFechaA.DataField = "Fecha"
            Me.txtFechaA.Height = 0.2!
            Me.txtFechaA.Left = 0.625!
            Me.txtFechaA.Name = "txtFechaA"
            Me.txtFechaA.OutputFormat = resources.GetString("txtFechaA.OutputFormat")
            Me.txtFechaA.Style = "text-align: center; font-size: 8pt"
            Me.txtFechaA.Text = "00/00/0000"
            Me.txtFechaA.Top = 0!
            Me.txtFechaA.Width = 0.625!
            '
            'txtFactura
            '
            Me.txtFactura.DataField = "FolioFactura"
            Me.txtFactura.Height = 0.2!
            Me.txtFactura.Left = 1.3125!
            Me.txtFactura.Name = "txtFactura"
            Me.txtFactura.Style = "text-align: right; font-size: 8pt"
            Me.txtFactura.Text = "Factura"
            Me.txtFactura.Top = 0!
            Me.txtFactura.Width = 0.5625!
            '
            'txtFechaFactura
            '
            Me.txtFechaFactura.DataField = "FechaFactura"
            Me.txtFechaFactura.Height = 0.2!
            Me.txtFechaFactura.Left = 1.875!
            Me.txtFechaFactura.Name = "txtFechaFactura"
            Me.txtFechaFactura.OutputFormat = resources.GetString("txtFechaFactura.OutputFormat")
            Me.txtFechaFactura.Style = "text-align: center; font-size: 8pt"
            Me.txtFechaFactura.Text = "00/00/0000"
            Me.txtFechaFactura.Top = 0!
            Me.txtFechaFactura.Width = 0.6875!
            '
            'txtCliente
            '
            Me.txtCliente.CanGrow = false
            Me.txtCliente.DataField = "Cliente"
            Me.txtCliente.Height = 0.1375!
            Me.txtCliente.Left = 2.625!
            Me.txtCliente.Name = "txtCliente"
            Me.txtCliente.Style = "font-size: 8pt"
            Me.txtCliente.Text = "Cliente"
            Me.txtCliente.Top = 0!
            Me.txtCliente.Width = 2!
            '
            'txtFormaPago
            '
            Me.txtFormaPago.DataField = "CodFormaPago"
            Me.txtFormaPago.Height = 0.2!
            Me.txtFormaPago.Left = 4.6875!
            Me.txtFormaPago.Name = "txtFormaPago"
            Me.txtFormaPago.Style = "text-align: right; font-size: 8pt"
            Me.txtFormaPago.Text = "E"
            Me.txtFormaPago.Top = 0!
            Me.txtFormaPago.Width = 0.125!
            '
            'txtAbono
            '
            Me.txtAbono.DataField = "Monto"
            Me.txtAbono.Height = 0.2!
            Me.txtAbono.Left = 4.875!
            Me.txtAbono.Name = "txtAbono"
            Me.txtAbono.OutputFormat = resources.GetString("txtAbono.OutputFormat")
            Me.txtAbono.Style = "text-align: right; font-size: 8pt"
            Me.txtAbono.Text = "00.00"
            Me.txtAbono.Top = 0!
            Me.txtAbono.Width = 0.8125!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "Saldo"
            Me.txtSaldo.Height = 0.2!
            Me.txtSaldo.Left = 5.75!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right; font-size: 8pt"
            Me.txtSaldo.Text = "00.00"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.8125!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Usuario"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 6.6875!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: left; font-size: 8pt"
            Me.TextBox2.Text = "USER"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.9375!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "Monto"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 4.875!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right; font-weight: bold; font-size: 8pt"
            Me.TextBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox3.Text = "00.00"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.8125!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Saldo"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 5.75!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: right; font-weight: bold; font-size: 8pt"
            Me.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox4.Text = "00.00"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.8125!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 7.6875!
            Me.Line2.X1 = 7.6875!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.71875!
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
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

    End Sub
End Class
