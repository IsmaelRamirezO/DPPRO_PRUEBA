Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class EstadoCuentaGeneralReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataSet, ByVal nCaja As String, ByVal strSucursal As String)

        MyBase.New()

        InitializeComponent()

        '</Margins>

        Me.PageSettings.Margins.Left = 0.85

        Me.PageSettings.Margins.Top = 0.5

        '<Margins/>

        Me.DataSource = Data.Tables(0)

        Me.DataMember = Data.Tables(0).TableName

        lblFecha.Text = Format(Date.Now, "dd/MM/yyyy")

        lblCaja.Text = "Caja # : " & nCaja

        lblSucursal.Text = "Sucursal : " & strSucursal

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents ghAsociado As GroupHeader = Nothing
    Private WithEvents ghFactura As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents gfFactura As GroupFooter = Nothing
    Private WithEvents gfAsociado As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblCaja As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblPagina As Label = Nothing
	Private txtPag As TextBox = Nothing
	Private lblCliente As Label = Nothing
	Private lblNombre As Label = Nothing
	Private lblFactura As Label = Nothing
	Private lblFechaFactura As Label = Nothing
	Private lblCargos As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblCredito As Label = Nothing
	Private Label4 As Label = Nothing
	Private lblSaldo As Label = Nothing
	Private Line1 As Line = Nothing
	Private Label5 As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private txtAsociadoID As TextBox = Nothing
	Private txtNombre As TextBox = Nothing
	Private txtLimiteCrédito As TextBox = Nothing
	Private txtPlazo As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private txtFactura As TextBox = Nothing
	Private txtFechaFactura As TextBox = Nothing
	Private txtMontoFactura As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private lblAbonos As Label = Nothing
	Private txtFechaAbono As TextBox = Nothing
	Private txtMontoAbono As TextBox = Nothing
	Private txtFormaPago As TextBox = Nothing
	Private TextBox16 As TextBox = Nothing
	Private TextBox17 As TextBox = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private txtSaldoFactura As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private txtTotalAbonoReal As TextBox = Nothing
	Private txtTotalImporte As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private TextBox15 As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private TextBox19 As TextBox = Nothing
	Private TextBox20 As TextBox = Nothing
	Private TextBox21 As TextBox = Nothing
	Private Line8 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadoCuentaGeneralReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.ghAsociado = New DataDynamics.ActiveReports.GroupHeader()
            Me.gfAsociado = New DataDynamics.ActiveReports.GroupFooter()
            Me.ghFactura = New DataDynamics.ActiveReports.GroupHeader()
            Me.gfFactura = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblNombre = New DataDynamics.ActiveReports.Label()
            Me.lblFactura = New DataDynamics.ActiveReports.Label()
            Me.lblFechaFactura = New DataDynamics.ActiveReports.Label()
            Me.lblCargos = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.lblCredito = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.lblSaldo = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtAsociadoID = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtLimiteCrédito = New DataDynamics.ActiveReports.TextBox()
            Me.txtPlazo = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtMontoFactura = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
            Me.lblAbonos = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtMontoAbono = New DataDynamics.ActiveReports.TextBox()
            Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.txtSaldoFactura = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalAbonoReal = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCargos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCredito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAsociadoID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLimiteCrédito,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMontoFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMontoAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldoFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalAbonoReal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFechaAbono, Me.txtMontoAbono, Me.txtFormaPago, Me.TextBox16})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label7, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.Line8})
            Me.ReportFooter.Height = 0.2708333!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.lblFecha, Me.lblCaja, Me.lblSucursal, Me.lblPagina, Me.txtPag, Me.lblCliente, Me.lblNombre, Me.lblFactura, Me.lblFechaFactura, Me.lblCargos, Me.Label2, Me.lblCredito, Me.Label4, Me.lblSaldo, Me.Line1, Me.Label5, Me.Shape1})
            Me.PageHeader.Height = 1.134722!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'ghAsociado
            '
            Me.ghAsociado.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAsociadoID, Me.txtNombre, Me.txtLimiteCrédito, Me.txtPlazo, Me.txtSaldo})
            Me.ghAsociado.DataField = "AsociadoID"
            Me.ghAsociado.Height = 0.1875!
            Me.ghAsociado.Name = "ghAsociado"
            '
            'gfAsociado
            '
            Me.gfAsociado.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox18, Me.txtTotalAbonoReal, Me.txtTotalImporte, Me.Label6, Me.Line2, Me.Line3, Me.TextBox15})
            Me.gfAsociado.Height = 0.28125!
            Me.gfAsociado.Name = "gfAsociado"
            '
            'ghFactura
            '
            Me.ghFactura.CanShrink = true
            Me.ghFactura.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFactura, Me.txtFechaFactura, Me.txtMontoFactura, Me.TextBox14, Me.lblAbonos})
            Me.ghFactura.DataField = "FolioFactura"
            Me.ghFactura.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
            Me.ghFactura.Height = 0.3645833!
            Me.ghFactura.KeepTogether = true
            Me.ghFactura.Name = "ghFactura"
            '
            'gfFactura
            '
            Me.gfFactura.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox17, Me.Line6, Me.Line7, Me.txtSaldoFactura})
            Me.gfFactura.Height = 0.2597222!
            Me.gfFactura.Name = "gfFactura"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 2.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; vertical-align: middle"
            Me.Label1.Text = "ESTADO DE CUENTA POR CLIENTE"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.9375!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = "Fecha"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.75!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.2!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.125!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = ""
            Me.lblCaja.Text = "Caja # :"
            Me.lblCaja.Top = 0.25!
            Me.lblCaja.Width = 0.75!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.125!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = ""
            Me.lblSucursal.Text = "Sucursal :"
            Me.lblSucursal.Top = 0.4375!
            Me.lblSucursal.Width = 5.8125!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.9375!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = ""
            Me.lblPagina.Text = "Pag. :"
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 0.375!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.2!
            Me.txtPag.Left = 6.375!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.OutputFormat = resources.GetString("txtPag.OutputFormat")
            Me.txtPag.Style = "text-align: right"
            Me.txtPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtPag.Text = "Pag"
            Me.txtPag.Top = 0.0625!
            Me.txtPag.Width = 0.5!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.1875!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 0.1875!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "text-align: center; font-size: 9pt"
            Me.lblCliente.Text = "CLIENTE"
            Me.lblCliente.Top = 0.75!
            Me.lblCliente.Width = 0.5625!
            '
            'lblNombre
            '
            Me.lblNombre.Height = 0.1875!
            Me.lblNombre.HyperLink = Nothing
            Me.lblNombre.Left = 0.875!
            Me.lblNombre.Name = "lblNombre"
            Me.lblNombre.Style = "text-align: center; font-size: 9pt"
            Me.lblNombre.Text = "NOMBRE"
            Me.lblNombre.Top = 0.75!
            Me.lblNombre.Width = 0.625!
            '
            'lblFactura
            '
            Me.lblFactura.Height = 0.1875!
            Me.lblFactura.HyperLink = Nothing
            Me.lblFactura.Left = 0.875!
            Me.lblFactura.Name = "lblFactura"
            Me.lblFactura.Style = "text-align: center; font-size: 9pt"
            Me.lblFactura.Text = "FACTURA"
            Me.lblFactura.Top = 0.9375!
            Me.lblFactura.Width = 0.625!
            '
            'lblFechaFactura
            '
            Me.lblFechaFactura.Height = 0.1875!
            Me.lblFechaFactura.HyperLink = Nothing
            Me.lblFechaFactura.Left = 1.5625!
            Me.lblFechaFactura.Name = "lblFechaFactura"
            Me.lblFechaFactura.Style = "text-align: center; font-size: 9pt"
            Me.lblFechaFactura.Text = "FECHA"
            Me.lblFechaFactura.Top = 0.9375!
            Me.lblFechaFactura.Width = 0.8125!
            '
            'lblCargos
            '
            Me.lblCargos.Height = 0.1875!
            Me.lblCargos.HyperLink = Nothing
            Me.lblCargos.Left = 2.5!
            Me.lblCargos.Name = "lblCargos"
            Me.lblCargos.Style = "text-align: right; font-size: 9pt"
            Me.lblCargos.Text = "CARGOS"
            Me.lblCargos.Top = 0.9375!
            Me.lblCargos.Width = 0.875!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 3.5625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 9pt"
            Me.Label2.Text = "VENCE"
            Me.Label2.Top = 0.9375!
            Me.Label2.Width = 0.75!
            '
            'lblCredito
            '
            Me.lblCredito.Height = 0.1875!
            Me.lblCredito.HyperLink = Nothing
            Me.lblCredito.Left = 3.9375!
            Me.lblCredito.Name = "lblCredito"
            Me.lblCredito.Style = "text-align: right; font-size: 9pt"
            Me.lblCredito.Text = "CREDITO"
            Me.lblCredito.Top = 0.75!
            Me.lblCredito.Width = 0.875!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.9375!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 9pt"
            Me.Label4.Text = "PLAZO"
            Me.Label4.Top = 0.75!
            Me.Label4.Width = 0.5!
            '
            'lblSaldo
            '
            Me.lblSaldo.Height = 0.1875!
            Me.lblSaldo.HyperLink = Nothing
            Me.lblSaldo.Left = 6.375!
            Me.lblSaldo.Name = "lblSaldo"
            Me.lblSaldo.Style = "text-align: right; font-size: 9pt"
            Me.lblSaldo.Text = "SALDO"
            Me.lblSaldo.Top = 0.75!
            Me.lblSaldo.Width = 0.625!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.6875!
            Me.Line1.Width = 7.0625!
            Me.Line1.X1 = 7.0625!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.6875!
            Me.Line1.Y2 = 0.6875!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4.375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 9pt"
            Me.Label5.Text = "ABONOS CLAVE / ABONOS"
            Me.Label5.Top = 0.9375!
            Me.Label5.Width = 1.8125!
            '
            'Shape1
            '
            Me.Shape1.Height = 1.125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.0625!
            '
            'txtAsociadoID
            '
            Me.txtAsociadoID.DataField = "AsociadoID"
            Me.txtAsociadoID.Height = 0.1875!
            Me.txtAsociadoID.Left = 0!
            Me.txtAsociadoID.Name = "txtAsociadoID"
            Me.txtAsociadoID.Style = "text-align: right"
            Me.txtAsociadoID.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtAsociadoID.Text = "AsociadoID"
            Me.txtAsociadoID.Top = 0!
            Me.txtAsociadoID.Width = 0.75!
            '
            'txtNombre
            '
            Me.txtNombre.CanGrow = false
            Me.txtNombre.DataField = "Nombre"
            Me.txtNombre.Height = 0.1875!
            Me.txtNombre.Left = 0.8125!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtNombre.Text = "Nombre"
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 2.9375!
            '
            'txtLimiteCrédito
            '
            Me.txtLimiteCrédito.DataField = "Credito"
            Me.txtLimiteCrédito.Height = 0.1875!
            Me.txtLimiteCrédito.Left = 3.875!
            Me.txtLimiteCrédito.Name = "txtLimiteCrédito"
            Me.txtLimiteCrédito.OutputFormat = resources.GetString("txtLimiteCrédito.OutputFormat")
            Me.txtLimiteCrédito.Style = "text-align: right"
            Me.txtLimiteCrédito.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtLimiteCrédito.Text = "Credito"
            Me.txtLimiteCrédito.Top = 0!
            Me.txtLimiteCrédito.Width = 0.9375!
            '
            'txtPlazo
            '
            Me.txtPlazo.DataField = "Plazo"
            Me.txtPlazo.Height = 0.1875!
            Me.txtPlazo.Left = 4.9375!
            Me.txtPlazo.Name = "txtPlazo"
            Me.txtPlazo.Style = "text-align: center"
            Me.txtPlazo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtPlazo.Text = "Plazo"
            Me.txtPlazo.Top = 0!
            Me.txtPlazo.Width = 0.4375!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "SaldoAsociado"
            Me.txtSaldo.Height = 0.1875!
            Me.txtSaldo.Left = 6!
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right"
            Me.txtSaldo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtSaldo.Text = "SaldoAsociado"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 1!
            '
            'txtFactura
            '
            Me.txtFactura.DataField = "FolioFactura"
            Me.txtFactura.Height = 0.2!
            Me.txtFactura.Left = 0.8125!
            Me.txtFactura.Name = "txtFactura"
            Me.txtFactura.Style = "text-align: left"
            Me.txtFactura.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFactura.Text = "Factura"
            Me.txtFactura.Top = 0!
            Me.txtFactura.Width = 0.6875!
            '
            'txtFechaFactura
            '
            Me.txtFechaFactura.DataField = "FechaFactura"
            Me.txtFechaFactura.Height = 0.2!
            Me.txtFechaFactura.Left = 1.5625!
            Me.txtFechaFactura.Name = "txtFechaFactura"
            Me.txtFechaFactura.OutputFormat = resources.GetString("txtFechaFactura.OutputFormat")
            Me.txtFechaFactura.Style = "text-align: center"
            Me.txtFechaFactura.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFechaFactura.Text = "Fecha"
            Me.txtFechaFactura.Top = 0!
            Me.txtFechaFactura.Width = 0.8125!
            '
            'txtMontoFactura
            '
            Me.txtMontoFactura.DataField = "PagoEstablecido"
            Me.txtMontoFactura.Height = 0.2!
            Me.txtMontoFactura.Left = 2.4375!
            Me.txtMontoFactura.Name = "txtMontoFactura"
            Me.txtMontoFactura.OutputFormat = resources.GetString("txtMontoFactura.OutputFormat")
            Me.txtMontoFactura.Style = "text-align: right"
            Me.txtMontoFactura.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtMontoFactura.Text = "Importe"
            Me.txtMontoFactura.Top = 0!
            Me.txtMontoFactura.Width = 0.9375!
            '
            'TextBox14
            '
            Me.TextBox14.DataField = "FechaLimitePago"
            Me.TextBox14.Height = 0.2!
            Me.TextBox14.Left = 3.5!
            Me.TextBox14.Name = "TextBox14"
            Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
            Me.TextBox14.Style = "text-align: center"
            Me.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox14.Text = "VENCE"
            Me.TextBox14.Top = 0!
            Me.TextBox14.Width = 0.8125!
            '
            'lblAbonos
            '
            Me.lblAbonos.Height = 0.2!
            Me.lblAbonos.HyperLink = Nothing
            Me.lblAbonos.Left = 2.5625!
            Me.lblAbonos.Name = "lblAbonos"
            Me.lblAbonos.Style = "font-size: 9pt"
            Me.lblAbonos.Text = "ABONOS DEL DOCUMENTO"
            Me.lblAbonos.Top = 0.1875!
            Me.lblAbonos.Width = 1.8125!
            '
            'txtFechaAbono
            '
            Me.txtFechaAbono.DataField = "FechaAbono"
            Me.txtFechaAbono.Height = 0.2!
            Me.txtFechaAbono.Left = 3.4375!
            Me.txtFechaAbono.Name = "txtFechaAbono"
            Me.txtFechaAbono.OutputFormat = resources.GetString("txtFechaAbono.OutputFormat")
            Me.txtFechaAbono.Style = "text-align: center"
            Me.txtFechaAbono.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFechaAbono.Text = "FechaAbono"
            Me.txtFechaAbono.Top = 0!
            Me.txtFechaAbono.Width = 0.8125!
            '
            'txtMontoAbono
            '
            Me.txtMontoAbono.DataField = "MontoAbono"
            Me.txtMontoAbono.Height = 0.2!
            Me.txtMontoAbono.Left = 4.3125!
            Me.txtMontoAbono.Name = "txtMontoAbono"
            Me.txtMontoAbono.OutputFormat = resources.GetString("txtMontoAbono.OutputFormat")
            Me.txtMontoAbono.Style = "text-align: right"
            Me.txtMontoAbono.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtMontoAbono.Text = "MontoAbono"
            Me.txtMontoAbono.Top = 0!
            Me.txtMontoAbono.Width = 0.875!
            '
            'txtFormaPago
            '
            Me.txtFormaPago.DataField = "CodFormaPago"
            Me.txtFormaPago.Height = 0.2!
            Me.txtFormaPago.Left = 5.25!
            Me.txtFormaPago.Name = "txtFormaPago"
            Me.txtFormaPago.OutputFormat = resources.GetString("txtFormaPago.OutputFormat")
            Me.txtFormaPago.Style = "text-align: center"
            Me.txtFormaPago.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtFormaPago.Text = "(F)"
            Me.txtFormaPago.Top = 0!
            Me.txtFormaPago.Width = 0.25!
            '
            'TextBox16
            '
            Me.TextBox16.DataField = "ObsAbono"
            Me.TextBox16.Height = 0.2!
            Me.TextBox16.Left = 5.5!
            Me.TextBox16.Name = "TextBox16"
            Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
            Me.TextBox16.Style = "text-align: justify"
            Me.TextBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox16.Text = "obsAbono"
            Me.TextBox16.Top = 0!
            Me.TextBox16.Width = 1.5!
            '
            'TextBox17
            '
            Me.TextBox17.DataField = "MontoAbonoReal"
            Me.TextBox17.Height = 0.2!
            Me.TextBox17.Left = 4.1875!
            Me.TextBox17.Name = "TextBox17"
            Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
            Me.TextBox17.Style = "text-align: right"
            Me.TextBox17.SummaryGroup = "ghFactura"
            Me.TextBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.TextBox17.Text = "Importe"
            Me.TextBox17.Top = 0.0625!
            Me.TextBox17.Width = 1!
            '
            'Line6
            '
            Me.Line6.Height = 0!
            Me.Line6.Left = 4.069445!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.006944444!
            Me.Line6.Width = 1.125!
            Me.Line6.X1 = 5.194445!
            Me.Line6.X2 = 4.069445!
            Me.Line6.Y1 = 0.006944444!
            Me.Line6.Y2 = 0.006944444!
            '
            'Line7
            '
            Me.Line7.Height = 0!
            Me.Line7.Left = 4.069!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.03!
            Me.Line7.Width = 1.125!
            Me.Line7.X1 = 5.194!
            Me.Line7.X2 = 4.069!
            Me.Line7.Y1 = 0.03!
            Me.Line7.Y2 = 0.03!
            '
            'txtSaldoFactura
            '
            Me.txtSaldoFactura.DataField = "SaldoFactura"
            Me.txtSaldoFactura.Height = 0.2!
            Me.txtSaldoFactura.Left = 5.5625!
            Me.txtSaldoFactura.Name = "txtSaldoFactura"
            Me.txtSaldoFactura.OutputFormat = resources.GetString("txtSaldoFactura.OutputFormat")
            Me.txtSaldoFactura.Style = "text-align: right"
            Me.txtSaldoFactura.Text = "SaldoFactura"
            Me.txtSaldoFactura.Top = 0.0625!
            Me.txtSaldoFactura.Width = 1!
            '
            'TextBox18
            '
            Me.TextBox18.DataField = "SaldoFacturaReal"
            Me.TextBox18.Height = 0.2!
            Me.TextBox18.Left = 5.375!
            Me.TextBox18.Name = "TextBox18"
            Me.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat")
            Me.TextBox18.Style = "text-align: right"
            Me.TextBox18.SummaryGroup = "ghAsociado"
            Me.TextBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.TextBox18.Text = "TotalSaldoAS"
            Me.TextBox18.Top = 0.0625!
            Me.TextBox18.Width = 1.1875!
            '
            'txtTotalAbonoReal
            '
            Me.txtTotalAbonoReal.DataField = "MontoAbonoReal"
            Me.txtTotalAbonoReal.Height = 0.2!
            Me.txtTotalAbonoReal.Left = 4!
            Me.txtTotalAbonoReal.Name = "txtTotalAbonoReal"
            Me.txtTotalAbonoReal.OutputFormat = resources.GetString("txtTotalAbonoReal.OutputFormat")
            Me.txtTotalAbonoReal.Style = "text-align: right"
            Me.txtTotalAbonoReal.SummaryGroup = "ghAsociado"
            Me.txtTotalAbonoReal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalAbonoReal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.txtTotalAbonoReal.Text = "TotalAbono"
            Me.txtTotalAbonoReal.Top = 0.0625!
            Me.txtTotalAbonoReal.Width = 1.1875!
            '
            'txtTotalImporte
            '
            Me.txtTotalImporte.DataField = "MontoFactura"
            Me.txtTotalImporte.Height = 0.2!
            Me.txtTotalImporte.Left = 2.1875!
            Me.txtTotalImporte.Name = "txtTotalImporte"
            Me.txtTotalImporte.OutputFormat = resources.GetString("txtTotalImporte.OutputFormat")
            Me.txtTotalImporte.Style = "text-align: right"
            Me.txtTotalImporte.SummaryGroup = "ghAsociado"
            Me.txtTotalImporte.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
            Me.txtTotalImporte.Text = "TotalImporte"
            Me.txtTotalImporte.Top = 0.0625!
            Me.txtTotalImporte.Width = 1.1875!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = ""
            Me.Label6.Text = "Total Asociado"
            Me.Label6.Top = 0.0625!
            Me.Label6.Width = 1.0625!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0.006944444!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.006944444!
            Me.Line2.Width = 7!
            Me.Line2.X1 = 7.006945!
            Me.Line2.X2 = 0.006944444!
            Me.Line2.Y1 = 0.006944444!
            Me.Line2.Y2 = 0.006944444!
            '
            'Line3
            '
            Me.Line3.Height = 0!
            Me.Line3.Left = 0.006944444!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.2569444!
            Me.Line3.Width = 7!
            Me.Line3.X1 = 7.006945!
            Me.Line3.X2 = 0.006944444!
            Me.Line3.Y1 = 0.2569444!
            Me.Line3.Y2 = 0.2569444!
            '
            'TextBox15
            '
            Me.TextBox15.DataField = "AsociadoID"
            Me.TextBox15.Height = 0.1875!
            Me.TextBox15.Left = 1.1875!
            Me.TextBox15.Name = "TextBox15"
            Me.TextBox15.Style = "text-align: left"
            Me.TextBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox15.Text = "AsociadoID"
            Me.TextBox15.Top = 0.0625!
            Me.TextBox15.Width = 0.75!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "Total General"
            Me.Label7.Top = 0.0625!
            Me.Label7.Width = 1.0625!
            '
            'TextBox19
            '
            Me.TextBox19.DataField = "MontoFactura"
            Me.TextBox19.Height = 0.2!
            Me.TextBox19.Left = 2.1875!
            Me.TextBox19.Name = "TextBox19"
            Me.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat")
            Me.TextBox19.Style = "text-align: right"
            Me.TextBox19.SummaryGroup = "ghAsociado"
            Me.TextBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox19.Text = "GranTotalImporte"
            Me.TextBox19.Top = 0.0625!
            Me.TextBox19.Width = 1.1875!
            '
            'TextBox20
            '
            Me.TextBox20.DataField = "MontoAbonoReal"
            Me.TextBox20.Height = 0.2!
            Me.TextBox20.Left = 4!
            Me.TextBox20.Name = "TextBox20"
            Me.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat")
            Me.TextBox20.Style = "text-align: right"
            Me.TextBox20.SummaryGroup = "ghAsociado"
            Me.TextBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox20.Text = "GranTotalAbono"
            Me.TextBox20.Top = 0.0625!
            Me.TextBox20.Width = 1.1875!
            '
            'TextBox21
            '
            Me.TextBox21.DataField = "SaldoFacturaReal"
            Me.TextBox21.Height = 0.2!
            Me.TextBox21.Left = 5.375!
            Me.TextBox21.Name = "TextBox21"
            Me.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat")
            Me.TextBox21.Style = "text-align: right"
            Me.TextBox21.SummaryGroup = "ghAsociado"
            Me.TextBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox21.Text = "GranTotalSaldoAS"
            Me.TextBox21.Top = 0.0625!
            Me.TextBox21.Width = 1.1875!
            '
            'Line8
            '
            Me.Line8.Height = 0!
            Me.Line8.Left = 0.006944444!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.006944444!
            Me.Line8.Width = 7!
            Me.Line8.X1 = 7.006945!
            Me.Line8.X2 = 0.006944444!
            Me.Line8.Y1 = 0.006944444!
            Me.Line8.Y2 = 0.006944444!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.072917!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.ghAsociado)
            Me.Sections.Add(Me.ghFactura)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.gfFactura)
            Me.Sections.Add(Me.gfAsociado)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCargos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCredito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAsociadoID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLimiteCrédito,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPlazo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMontoFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMontoAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldoFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalAbonoReal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



    Private Sub EstadoCuentaGeneralReport_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
