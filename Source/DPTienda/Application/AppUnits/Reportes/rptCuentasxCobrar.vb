Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptCuentasxCobrar
    Inherits DataDynamics.ActiveReports.ActiveReport
    Private mnPag As Integer
	Public Sub New()
	MyBase.New()
        InitializeComponent()
        txtFecha.Value = Now()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private lblTitulo As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtCodigoSucursal As TextBox = Nothing
	Private txtNombreSucursal As TextBox = Nothing
	Private txtCaja As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtFechaDe As TextBox = Nothing
	Private Label5 As Label = Nothing
	Private txtFechaA As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private txtPagina As TextBox = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Shape1 As Shape = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtFechaFactura As TextBox = Nothing
	Private txtNombreCliente As TextBox = Nothing
	Private txtLimitePago As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtAbonos As TextBox = Nothing
	Private txtSaldo As TextBox = Nothing
	Private txtUsuario As TextBox = Nothing
	Private txtStatus As TextBox = Nothing
	Private txtClienteID As TextBox = Nothing
	Private txtSumaImporte As TextBox = Nothing
	Private txtSumaAbonos As TextBox = Nothing
	Private txtSumaSaldo As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCuentasxCobrar))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtCodigoSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombreSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtCaja = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaDe = New DataDynamics.ActiveReports.TextBox()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtFechaA = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtPagina = New DataDynamics.ActiveReports.TextBox()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombreCliente = New DataDynamics.ActiveReports.TextBox()
            Me.txtLimitePago = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtStatus = New DataDynamics.ActiveReports.TextBox()
            Me.txtClienteID = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumaImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumaAbonos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSumaSaldo = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigoSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLimitePago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumaImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumaAbonos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSumaSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtFechaFactura, Me.txtNombreCliente, Me.txtLimitePago, Me.txtImporte, Me.txtAbonos, Me.txtSaldo, Me.txtUsuario, Me.txtStatus, Me.txtClienteID})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSumaImporte, Me.txtSumaAbonos, Me.txtSumaSaldo})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.txtFecha, Me.Label2, Me.Label3, Me.txtCodigoSucursal, Me.txtNombreSucursal, Me.txtCaja, Me.Label4, Me.txtFechaDe, Me.Label5, Me.txtFechaA, Me.Label6, Me.txtPagina, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.Line1, Me.Shape1})
            Me.PageHeader.Height = 1.083333!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.1875!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.3125!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Times New "& _ 
                "Roman"
            Me.lblTitulo.Text = "REPORTE DE CUENTAS POR COBRAR"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 4.375!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1875!
            Me.txtFecha.Left = 0.125!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtFecha.Text = "Fecha"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 0.9375!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.125!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label2.Text = "Caja #"
            Me.Label2.Top = 0.3125!
            Me.Label2.Width = 0.5!
            '
            'Label3
            '
            Me.Label3.Height = 0.1875!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.125!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label3.Text = "Sucursal :"
            Me.Label3.Top = 0.5625!
            Me.Label3.Width = 0.625!
            '
            'txtCodigoSucursal
            '
            Me.txtCodigoSucursal.Height = 0.1875!
            Me.txtCodigoSucursal.Left = 0.75!
            Me.txtCodigoSucursal.MultiLine = false
            Me.txtCodigoSucursal.Name = "txtCodigoSucursal"
            Me.txtCodigoSucursal.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtCodigoSucursal.Text = "CodigoSucursal"
            Me.txtCodigoSucursal.Top = 0.5625!
            Me.txtCodigoSucursal.Width = 0.5!
            '
            'txtNombreSucursal
            '
            Me.txtNombreSucursal.Height = 0.1875!
            Me.txtNombreSucursal.Left = 1.3125!
            Me.txtNombreSucursal.MultiLine = false
            Me.txtNombreSucursal.Name = "txtNombreSucursal"
            Me.txtNombreSucursal.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtNombreSucursal.Text = "NombreSucursal"
            Me.txtNombreSucursal.Top = 0.5625!
            Me.txtNombreSucursal.Width = 2.0625!
            '
            'txtCaja
            '
            Me.txtCaja.Height = 0.1875!
            Me.txtCaja.Left = 0.6875!
            Me.txtCaja.Name = "txtCaja"
            Me.txtCaja.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtCaja.Text = "Caja"
            Me.txtCaja.Top = 0.3125!
            Me.txtCaja.Width = 0.4375!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.75!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label4.Text = "De :"
            Me.Label4.Top = 0.3125!
            Me.Label4.Width = 0.3125!
            '
            'txtFechaDe
            '
            Me.txtFechaDe.Height = 0.1875!
            Me.txtFechaDe.Left = 2.125!
            Me.txtFechaDe.Name = "txtFechaDe"
            Me.txtFechaDe.OutputFormat = resources.GetString("txtFechaDe.OutputFormat")
            Me.txtFechaDe.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtFechaDe.Text = "FechaDe"
            Me.txtFechaDe.Top = 0.3125!
            Me.txtFechaDe.Width = 0.6875!
            '
            'Label5
            '
            Me.Label5.Height = 0.1875!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label5.Text = "A :"
            Me.Label5.Top = 0.3125!
            Me.Label5.Width = 0.25!
            '
            'txtFechaA
            '
            Me.txtFechaA.Height = 0.1875!
            Me.txtFechaA.Left = 3.1875!
            Me.txtFechaA.Name = "txtFechaA"
            Me.txtFechaA.OutputFormat = resources.GetString("txtFechaA.OutputFormat")
            Me.txtFechaA.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtFechaA.Text = "FechaA"
            Me.txtFechaA.Top = 0.3125!
            Me.txtFechaA.Width = 0.8125!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 6.375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label6.Text = "PAG."
            Me.Label6.Top = 0.0625!
            Me.Label6.Width = 0.4375!
            '
            'txtPagina
            '
            Me.txtPagina.Height = 0.1875!
            Me.txtPagina.Left = 6.875!
            Me.txtPagina.Name = "txtPagina"
            Me.txtPagina.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtPagina.Text = "No. Pág."
            Me.txtPagina.Top = 0.0625!
            Me.txtPagina.Width = 0.5!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.0625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label7.Text = "FOLIO"
            Me.Label7.Top = 0.8125!
            Me.Label7.Width = 0.5!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 0.625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
            Me.Label8.Text = "FECHA"
            Me.Label8.Top = 0.8125!
            Me.Label8.Width = 0.5625!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 1.25!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
            Me.Label9.Text = "CLIENTE"
            Me.Label9.Top = 0.8125!
            Me.Label9.Width = 2.0625!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.375!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label10.Text = "LIMITE/PAGO"
            Me.Label10.Top = 0.8125!
            Me.Label10.Width = 0.875!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 4.3125!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label11.Text = "IMPORTE"
            Me.Label11.Top = 0.8125!
            Me.Label11.Width = 0.625!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 5!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label12.Text = "ABONOS"
            Me.Label12.Top = 0.8125!
            Me.Label12.Width = 0.625!
            '
            'Label13
            '
            Me.Label13.Height = 0.1875!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 5.6875!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label13.Text = "SALDO"
            Me.Label13.Top = 0.8125!
            Me.Label13.Width = 0.625!
            '
            'Label14
            '
            Me.Label14.Height = 0.1875!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 6.3125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label14.Text = "USUARIO"
            Me.Label14.Top = 0.8125!
            Me.Label14.Width = 0.5625!
            '
            'Label15
            '
            Me.Label15.Height = 0.1875!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 6.9375!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.Label15.Text = "STATUS"
            Me.Label15.Top = 0.8125!
            Me.Label15.Width = 0.5!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.06944445!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.7569444!
            Me.Line1.Width = 7.375!
            Me.Line1.X1 = 0.06944445!
            Me.Line1.X2 = 7.444445!
            Me.Line1.Y1 = 0.7569444!
            Me.Line1.Y2 = 0.7569444!
            '
            'Shape1
            '
            Me.Shape1.Height = 1.0625!
            Me.Shape1.Left = 0.0625!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.375!
            '
            'txtFolio
            '
            Me.txtFolio.DataField = "FolioFactura"
            Me.txtFolio.Height = 0.1875!
            Me.txtFolio.Left = 0.0625!
            Me.txtFolio.MultiLine = false
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.5!
            '
            'txtFechaFactura
            '
            Me.txtFechaFactura.DataField = "FechaFactura"
            Me.txtFechaFactura.Height = 0.1875!
            Me.txtFechaFactura.Left = 0.625!
            Me.txtFechaFactura.MultiLine = false
            Me.txtFechaFactura.Name = "txtFechaFactura"
            Me.txtFechaFactura.OutputFormat = resources.GetString("txtFechaFactura.OutputFormat")
            Me.txtFechaFactura.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtFechaFactura.Text = "Fecha"
            Me.txtFechaFactura.Top = 0!
            Me.txtFechaFactura.Width = 0.5625!
            '
            'txtNombreCliente
            '
            Me.txtNombreCliente.DataField = "Nombre"
            Me.txtNombreCliente.Height = 0.1875!
            Me.txtNombreCliente.Left = 1.875!
            Me.txtNombreCliente.MultiLine = false
            Me.txtNombreCliente.Name = "txtNombreCliente"
            Me.txtNombreCliente.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtNombreCliente.Text = "Nombre"
            Me.txtNombreCliente.Top = 0!
            Me.txtNombreCliente.Width = 1.6875!
            '
            'txtLimitePago
            '
            Me.txtLimitePago.DataField = "FechaLimitePago"
            Me.txtLimitePago.Height = 0.1875!
            Me.txtLimitePago.Left = 3.625!
            Me.txtLimitePago.MultiLine = false
            Me.txtLimitePago.Name = "txtLimitePago"
            Me.txtLimitePago.OutputFormat = resources.GetString("txtLimitePago.OutputFormat")
            Me.txtLimitePago.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtLimitePago.Text = "FechaLimitePago"
            Me.txtLimitePago.Top = 0!
            Me.txtLimitePago.Width = 0.625!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "PagoEstablecido"
            Me.txtImporte.Height = 0.1875!
            Me.txtImporte.Left = 4.3125!
            Me.txtImporte.MultiLine = false
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtImporte.Text = "Importe"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.625!
            '
            'txtAbonos
            '
            Me.txtAbonos.DataField = "Abonos"
            Me.txtAbonos.Height = 0.1875!
            Me.txtAbonos.Left = 5!
            Me.txtAbonos.MultiLine = false
            Me.txtAbonos.Name = "txtAbonos"
            Me.txtAbonos.OutputFormat = resources.GetString("txtAbonos.OutputFormat")
            Me.txtAbonos.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtAbonos.Text = "Abonos"
            Me.txtAbonos.Top = 0!
            Me.txtAbonos.Width = 0.625!
            '
            'txtSaldo
            '
            Me.txtSaldo.DataField = "Saldo"
            Me.txtSaldo.Height = 0.1875!
            Me.txtSaldo.Left = 5.6875!
            Me.txtSaldo.MultiLine = false
            Me.txtSaldo.Name = "txtSaldo"
            Me.txtSaldo.OutputFormat = resources.GetString("txtSaldo.OutputFormat")
            Me.txtSaldo.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtSaldo.Text = "Saldo"
            Me.txtSaldo.Top = 0!
            Me.txtSaldo.Width = 0.6875!
            '
            'txtUsuario
            '
            Me.txtUsuario.DataField = "Player"
            Me.txtUsuario.Height = 0.1875!
            Me.txtUsuario.Left = 6.4375!
            Me.txtUsuario.MultiLine = false
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtUsuario.Text = "Usuario"
            Me.txtUsuario.Top = 0!
            Me.txtUsuario.Width = 0.5!
            '
            'txtStatus
            '
            Me.txtStatus.DataField = "StatusFactura"
            Me.txtStatus.Height = 0.1875!
            Me.txtStatus.Left = 7!
            Me.txtStatus.MultiLine = false
            Me.txtStatus.Name = "txtStatus"
            Me.txtStatus.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtStatus.Text = "Status"
            Me.txtStatus.Top = 0!
            Me.txtStatus.Width = 0.4375!
            '
            'txtClienteID
            '
            Me.txtClienteID.DataField = "ClienteID"
            Me.txtClienteID.Height = 0.1875!
            Me.txtClienteID.Left = 1.25!
            Me.txtClienteID.MultiLine = false
            Me.txtClienteID.Name = "txtClienteID"
            Me.txtClienteID.Style = "font-size: 8.25pt; font-family: Times New Roman"
            Me.txtClienteID.Text = "ClienteID"
            Me.txtClienteID.Top = 0!
            Me.txtClienteID.Width = 0.5625!
            '
            'txtSumaImporte
            '
            Me.txtSumaImporte.DataField = "PagoEstablecido"
            Me.txtSumaImporte.Height = 0.1875!
            Me.txtSumaImporte.Left = 4.322917!
            Me.txtSumaImporte.Name = "txtSumaImporte"
            Me.txtSumaImporte.OutputFormat = resources.GetString("txtSumaImporte.OutputFormat")
            Me.txtSumaImporte.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtSumaImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumaImporte.Text = "SumaImporte"
            Me.txtSumaImporte.Top = 0!
            Me.txtSumaImporte.Width = 0.625!
            '
            'txtSumaAbonos
            '
            Me.txtSumaAbonos.DataField = "Abonos"
            Me.txtSumaAbonos.Height = 0.1875!
            Me.txtSumaAbonos.Left = 5!
            Me.txtSumaAbonos.Name = "txtSumaAbonos"
            Me.txtSumaAbonos.OutputFormat = resources.GetString("txtSumaAbonos.OutputFormat")
            Me.txtSumaAbonos.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtSumaAbonos.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumaAbonos.Text = "SumaAbonos"
            Me.txtSumaAbonos.Top = 0!
            Me.txtSumaAbonos.Width = 0.625!
            '
            'txtSumaSaldo
            '
            Me.txtSumaSaldo.DataField = "Saldo"
            Me.txtSumaSaldo.Height = 0.1875!
            Me.txtSumaSaldo.Left = 5.6875!
            Me.txtSumaSaldo.Name = "txtSumaSaldo"
            Me.txtSumaSaldo.OutputFormat = resources.GetString("txtSumaSaldo.OutputFormat")
            Me.txtSumaSaldo.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
            Me.txtSumaSaldo.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSumaSaldo.Text = "SumaSaldo"
            Me.txtSumaSaldo.Top = 0!
            Me.txtSumaSaldo.Width = 0.6875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.8!
            Me.PageSettings.Margins.Left = 0.5!
            Me.PageSettings.Margins.Right = 0.5!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.489583!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigoSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLimitePago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClienteID,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumaImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumaAbonos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSumaSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
    Public Property Titulo() As String
        Get
            Titulo = lblTitulo.Text
        End Get
        Set(ByVal Value As String)
            lblTitulo.Text = Value
        End Set
    End Property
    Public Property Desde() As Date
        Get
            Desde = txtFechaDe.Value
        End Get
        Set(ByVal Value As Date)
            txtFechaDe.Value = Value
        End Set
    End Property
    Public Property Hasta() As Date
        Get
            Hasta = txtFechaA.Value
        End Get
        Set(ByVal Value As Date)
            txtFechaA.Value = Value
        End Set
    End Property
    Public Property CodigoSucursal() As String
        Get
            CodigoSucursal = txtCodigoSucursal.Text
        End Get
        Set(ByVal Value As String)
            txtCodigoSucursal.Text = Value
        End Set
    End Property
    Public Property NombreSucursal() As String
        Get
            NombreSucursal = txtNombreSucursal.Text
        End Get
        Set(ByVal Value As String)
            txtNombreSucursal.Text = Value
        End Set
    End Property
    Public Property Caja() As String
        Get
            Caja = txtCaja.Text
        End Get
        Set(ByVal Value As String)
            txtCaja.Text = Value
        End Set
    End Property
    Private Sub rptCuentasxCobrar_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PageStart
        mnPag = mnPag + 1
        txtPagina.Text = mnPag
    End Sub
End Class
