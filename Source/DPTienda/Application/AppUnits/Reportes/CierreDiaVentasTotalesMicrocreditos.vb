
Imports System
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class CierreDiaVentasTotalesMicrocreditos
Inherits DataDynamics.ActiveReports.ActiveReport

	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
    Private lblFechaKarum As Label = Nothing
    Private lblConsecutivo As Label = Nothing
    Private lblCM As Label = Nothing
    Private lblServicio As Label = Nothing
    Private lblBanco As Label = Nothing
    Private lblClubDP As Label = Nothing
    Private lblImporte As Label = Nothing
    Private Label2 As Label = Nothing
    Private lblTitulo As Label = Nothing
    Private Line1 As Line = Nothing
    Private Label11 As Label = Nothing
    Private LblFechaDE As Label = Nothing
    Private Label12 As Label = Nothing
    Private LblFechaAL As Label = Nothing
    Private LblSucursal As Label = Nothing
    Private Label13 As Label = Nothing
    Private lblFecha As Label = Nothing
    Private txtConsecutivo As TextBox = Nothing
    Private txtCM As TextBox = Nothing
    Private txtServicio As TextBox = Nothing
    Private txtBanco As TextBox = Nothing
    Private txtImporte As TextBox = Nothing
    Private txtClubDP As TextBox = Nothing
    Private txtFechaKarum As TextBox = Nothing
    Private Shape2 As Shape = Nothing
    Friend WithEvents lblPlazo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblVendedor As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPlaza As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTienda As DataDynamics.ActiveReports.Label
    Friend WithEvents lblEstatus As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtVendedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlaza As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTienda As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCliente As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCte As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTotalCreditos As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTotalCreditoCancelado As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCreditoCancelado As DataDynamics.ActiveReports.TextBox
    Private tbTotalImporte As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CierreDiaVentasTotalesMicrocreditos))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtConsecutivo = New DataDynamics.ActiveReports.TextBox()
        Me.txtCM = New DataDynamics.ActiveReports.TextBox()
        Me.txtServicio = New DataDynamics.ActiveReports.TextBox()
        Me.txtBanco = New DataDynamics.ActiveReports.TextBox()
        Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
        Me.txtClubDP = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaKarum = New DataDynamics.ActiveReports.TextBox()
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox()
        Me.txtVendedor = New DataDynamics.ActiveReports.TextBox()
        Me.txtPlaza = New DataDynamics.ActiveReports.TextBox()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtCliente = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.tbTotalImporte = New DataDynamics.ActiveReports.TextBox()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.lblFechaKarum = New DataDynamics.ActiveReports.Label()
        Me.lblConsecutivo = New DataDynamics.ActiveReports.Label()
        Me.lblCM = New DataDynamics.ActiveReports.Label()
        Me.lblServicio = New DataDynamics.ActiveReports.Label()
        Me.lblBanco = New DataDynamics.ActiveReports.Label()
        Me.lblClubDP = New DataDynamics.ActiveReports.Label()
        Me.lblImporte = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.lblTitulo = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaDE = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.LblFechaAL = New DataDynamics.ActiveReports.Label()
        Me.LblSucursal = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.lblPlazo = New DataDynamics.ActiveReports.Label()
        Me.lblVendedor = New DataDynamics.ActiveReports.Label()
        Me.lblPlaza = New DataDynamics.ActiveReports.Label()
        Me.lblTienda = New DataDynamics.ActiveReports.Label()
        Me.lblEstatus = New DataDynamics.ActiveReports.Label()
        Me.lblCte = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.lblTotalCreditos = New DataDynamics.ActiveReports.Label()
        Me.lblTotalCreditoCancelado = New DataDynamics.ActiveReports.Label()
        Me.txtCreditoCancelado = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtConsecutivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClubDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaKarum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaKarum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblConsecutivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClubDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalCreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalCreditoCancelado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditoCancelado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtConsecutivo, Me.txtCM, Me.txtServicio, Me.txtBanco, Me.txtImporte, Me.txtClubDP, Me.txtFechaKarum, Me.txtPlazo, Me.txtVendedor, Me.txtPlaza, Me.txtTienda, Me.TextBox1, Me.txtCliente})
        Me.Detail.Height = 0.198!
        Me.Detail.Name = "Detail"
        '
        'txtConsecutivo
        '
        Me.txtConsecutivo.CountNullValues = True
        Me.txtConsecutivo.DataField = "Consecutivo"
        Me.txtConsecutivo.Height = 0.188!
        Me.txtConsecutivo.Left = 0.062!
        Me.txtConsecutivo.Name = "txtConsecutivo"
        Me.txtConsecutivo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtConsecutivo.Text = Nothing
        Me.txtConsecutivo.Top = 0.0!
        Me.txtConsecutivo.Width = 0.584!
        '
        'txtCM
        '
        Me.txtCM.DataField = "TransactionSequenceNumber"
        Me.txtCM.Height = 0.188!
        Me.txtCM.Left = 0.66!
        Me.txtCM.Name = "txtCM"
        Me.txtCM.OutputFormat = resources.GetString("txtCM.OutputFormat")
        Me.txtCM.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.txtCM.Text = Nothing
        Me.txtCM.Top = 0.0!
        Me.txtCM.Width = 0.438!
        '
        'txtServicio
        '
        Me.txtServicio.DataField = "ServicioId"
        Me.txtServicio.Height = 0.188!
        Me.txtServicio.Left = 2.055!
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.OutputFormat = resources.GetString("txtServicio.OutputFormat")
        Me.txtServicio.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.txtServicio.Text = Nothing
        Me.txtServicio.Top = 0.01!
        Me.txtServicio.Width = 0.507!
        '
        'txtBanco
        '
        Me.txtBanco.DataField = "Banco"
        Me.txtBanco.Height = 0.188!
        Me.txtBanco.Left = 2.562!
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.OutputFormat = resources.GetString("txtBanco.OutputFormat")
        Me.txtBanco.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtBanco.Text = Nothing
        Me.txtBanco.Top = 0.01!
        Me.txtBanco.Width = 0.5020001!
        '
        'txtImporte
        '
        Me.txtImporte.DataField = "Monto"
        Me.txtImporte.Height = 0.188!
        Me.txtImporte.Left = 3.867!
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
        Me.txtImporte.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Arial"
        Me.txtImporte.Text = Nothing
        Me.txtImporte.Top = 0.0!
        Me.txtImporte.Width = 0.604!
        '
        'txtClubDP
        '
        Me.txtClubDP.DataField = "ClubDP"
        Me.txtClubDP.Height = 0.188!
        Me.txtClubDP.Left = 3.064!
        Me.txtClubDP.Name = "txtClubDP"
        Me.txtClubDP.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
        Me.txtClubDP.Text = Nothing
        Me.txtClubDP.Top = 0.0!
        Me.txtClubDP.Width = 0.803!
        '
        'txtFechaKarum
        '
        Me.txtFechaKarum.DataField = "FechaKarum"
        Me.txtFechaKarum.Height = 0.188!
        Me.txtFechaKarum.Left = 1.1!
        Me.txtFechaKarum.Name = "txtFechaKarum"
        Me.txtFechaKarum.OutputFormat = resources.GetString("txtFechaKarum.OutputFormat")
        Me.txtFechaKarum.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtFechaKarum.Text = Nothing
        Me.txtFechaKarum.Top = 0.0!
        Me.txtFechaKarum.Width = 0.51!
        '
        'txtPlazo
        '
        Me.txtPlazo.DataField = "PlazoDisp"
        Me.txtPlazo.Height = 0.188!
        Me.txtPlazo.Left = 4.467!
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 0.0!
        Me.txtPlazo.Width = 0.479!
        '
        'txtVendedor
        '
        Me.txtVendedor.DataField = "CodVendedor"
        Me.txtVendedor.Height = 0.188!
        Me.txtVendedor.Left = 4.956!
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtVendedor.Text = Nothing
        Me.txtVendedor.Top = 0.0!
        Me.txtVendedor.Width = 0.472!
        '
        'txtPlaza
        '
        Me.txtPlaza.DataField = "CodPlaza"
        Me.txtPlaza.Height = 0.188!
        Me.txtPlaza.Left = 5.438!
        Me.txtPlaza.Name = "txtPlaza"
        Me.txtPlaza.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtPlaza.Text = Nothing
        Me.txtPlaza.Top = 0.0!
        Me.txtPlaza.Width = 0.479!
        '
        'txtTienda
        '
        Me.txtTienda.DataField = "CodAlmacen"
        Me.txtTienda.Height = 0.188!
        Me.txtTienda.Left = 5.927!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtTienda.Text = Nothing
        Me.txtTienda.Top = 0.0!
        Me.txtTienda.Width = 0.479!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "EstAbr"
        Me.TextBox1.Height = 0.188!
        Me.TextBox1.Left = 6.421!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.444!
        '
        'txtCliente
        '
        Me.txtCliente.DataField = "NombreCliente"
        Me.txtCliente.Height = 0.188!
        Me.txtCliente.Left = 1.617!
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.OutputFormat = resources.GetString("txtCliente.OutputFormat")
        Me.txtCliente.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial"
        Me.txtCliente.Text = Nothing
        Me.txtCliente.Top = 0.0!
        Me.txtCliente.Width = 0.438!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.Visible = False
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.tbTotalImporte, Me.lblTotalCreditos, Me.lblTotalCreditoCancelado, Me.txtCreditoCancelado})
        Me.ReportFooter.Height = 0.2083333!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape2
        '
        Me.Shape2.Height = 0.1875!
        Me.Shape2.Left = 0.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 6.875!
        '
        'tbTotalImporte
        '
        Me.tbTotalImporte.Height = 0.1875!
        Me.tbTotalImporte.Left = 3.867!
        Me.tbTotalImporte.Name = "tbTotalImporte"
        Me.tbTotalImporte.OutputFormat = resources.GetString("tbTotalImporte.OutputFormat")
        Me.tbTotalImporte.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Arial"
        Me.tbTotalImporte.Text = Nothing
        Me.tbTotalImporte.Top = 0.0!
        Me.tbTotalImporte.Width = 0.5890002!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblFechaKarum, Me.lblConsecutivo, Me.lblCM, Me.lblServicio, Me.lblBanco, Me.lblClubDP, Me.lblImporte, Me.Label2, Me.lblTitulo, Me.Line1, Me.Label11, Me.LblFechaDE, Me.Label12, Me.LblFechaAL, Me.LblSucursal, Me.Label13, Me.lblFecha, Me.lblPlazo, Me.lblVendedor, Me.lblPlaza, Me.lblTienda, Me.lblEstatus, Me.lblCte})
        Me.GroupHeader1.Height = 0.8545001!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.8125!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.875!
        '
        'lblFechaKarum
        '
        Me.lblFechaKarum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaKarum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaKarum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaKarum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaKarum.Height = 0.1875!
        Me.lblFechaKarum.HyperLink = Nothing
        Me.lblFechaKarum.Left = 1.107!
        Me.lblFechaKarum.Name = "lblFechaKarum"
        Me.lblFechaKarum.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblFechaKarum.Text = "Fecha"
        Me.lblFechaKarum.Top = 0.632!
        Me.lblFechaKarum.Width = 0.51!
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblConsecutivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblConsecutivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblConsecutivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblConsecutivo.Height = 0.1875!
        Me.lblConsecutivo.HyperLink = Nothing
        Me.lblConsecutivo.Left = 0.06200001!
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblConsecutivo.Text = "Consec"
        Me.lblConsecutivo.Top = 0.6319444!
        Me.lblConsecutivo.Width = 0.584!
        '
        'lblCM
        '
        Me.lblCM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCM.Height = 0.1875!
        Me.lblCM.HyperLink = Nothing
        Me.lblCM.Left = 0.6530001!
        Me.lblCM.Name = "lblCM"
        Me.lblCM.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblCM.Text = "CM"
        Me.lblCM.Top = 0.632!
        Me.lblCM.Width = 0.4375!
        '
        'lblServicio
        '
        Me.lblServicio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblServicio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblServicio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblServicio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblServicio.Height = 0.1875!
        Me.lblServicio.HyperLink = Nothing
        Me.lblServicio.Left = 2.055!
        Me.lblServicio.Name = "lblServicio"
        Me.lblServicio.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblServicio.Text = "Servicio"
        Me.lblServicio.Top = 0.632!
        Me.lblServicio.Width = 0.5079999!
        '
        'lblBanco
        '
        Me.lblBanco.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblBanco.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblBanco.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblBanco.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblBanco.Height = 0.1875!
        Me.lblBanco.HyperLink = Nothing
        Me.lblBanco.Left = 2.562!
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblBanco.Text = "Banco"
        Me.lblBanco.Top = 0.632!
        Me.lblBanco.Width = 0.5020001!
        '
        'lblClubDP
        '
        Me.lblClubDP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblClubDP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblClubDP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblClubDP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblClubDP.Height = 0.1875!
        Me.lblClubDP.HyperLink = Nothing
        Me.lblClubDP.Left = 3.064!
        Me.lblClubDP.Name = "lblClubDP"
        Me.lblClubDP.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblClubDP.Text = "Club DP"
        Me.lblClubDP.Top = 0.632!
        Me.lblClubDP.Width = 0.803!
        '
        'lblImporte
        '
        Me.lblImporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Height = 0.1875!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 3.852!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.Top = 0.632!
        Me.lblImporte.Width = 0.6040006!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.Label2.Text = "Fecha :"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.4375!
        '
        'lblTitulo
        '
        Me.lblTitulo.Height = 0.1875!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 2.262!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblTitulo.Text = "Reporte de Ventas Totales microcreditos"
        Me.lblTitulo.Top = 0.0!
        Me.lblTitulo.Width = 2.519!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.006944444!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.5694444!
        Me.Line1.Width = 6.875!
        Me.Line1.X1 = 0.006944444!
        Me.Line1.X2 = 6.881945!
        Me.Line1.Y1 = 0.5694444!
        Me.Line1.Y2 = 0.5694444!
        '
        'Label11
        '
        Me.Label11.Height = 0.1811025!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 2.25!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
            "25pt; font-family: Arial"
        Me.Label11.Text = "De:"
        Me.Label11.Top = 0.1875!
        Me.Label11.Width = 0.2810042!
        '
        'LblFechaDE
        '
        Me.LblFechaDE.Height = 0.1811025!
        Me.LblFechaDE.HyperLink = Nothing
        Me.LblFechaDE.Left = 2.5625!
        Me.LblFechaDE.Name = "LblFechaDE"
        Me.LblFechaDE.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
            "8.25pt; font-family: Arial"
        Me.LblFechaDE.Text = "LblFechaDE"
        Me.LblFechaDE.Top = 0.1875!
        Me.LblFechaDE.Width = 0.9685042!
        '
        'Label12
        '
        Me.Label12.Height = 0.1811025!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.5625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
            "25pt; font-family: Arial"
        Me.Label12.Text = "Al:"
        Me.Label12.Top = 0.1875!
        Me.Label12.Width = 0.2810042!
        '
        'LblFechaAL
        '
        Me.LblFechaAL.Height = 0.1811025!
        Me.LblFechaAL.HyperLink = Nothing
        Me.LblFechaAL.Left = 3.8125!
        Me.LblFechaAL.Name = "LblFechaAL"
        Me.LblFechaAL.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
            "8.25pt; font-family: Arial"
        Me.LblFechaAL.Text = "LblFechaAL"
        Me.LblFechaAL.Top = 0.1875!
        Me.LblFechaAL.Width = 0.9685042!
        '
        'LblSucursal
        '
        Me.LblSucursal.Height = 0.1811025!
        Me.LblSucursal.HyperLink = Nothing
        Me.LblSucursal.Left = 2.125001!
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
            "8.25pt; font-family: Arial"
        Me.LblSucursal.Text = "LblSucursal"
        Me.LblSucursal.Top = 0.375!
        Me.LblSucursal.Width = 3.448326!
        '
        'Label13
        '
        Me.Label13.Height = 0.1811025!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.4375!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
            "25pt; font-family: Arial"
        Me.Label13.Text = "Sucursal:"
        Me.Label13.Top = 0.375!
        Me.Label13.Width = 0.5625!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.2!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.5625!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-size: 8.25pt"
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.Top = 0.0!
        Me.lblFecha.Width = 0.875!
        '
        'lblPlazo
        '
        Me.lblPlazo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazo.Height = 0.1875!
        Me.lblPlazo.HyperLink = Nothing
        Me.lblPlazo.Left = 4.472!
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblPlazo.Text = "Plazo"
        Me.lblPlazo.Top = 0.632!
        Me.lblPlazo.Width = 0.4789996!
        '
        'lblVendedor
        '
        Me.lblVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Height = 0.1875!
        Me.lblVendedor.HyperLink = Nothing
        Me.lblVendedor.Left = 4.961!
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblVendedor.Text = "Vend"
        Me.lblVendedor.Top = 0.632!
        Me.lblVendedor.Width = 0.4720002!
        '
        'lblPlaza
        '
        Me.lblPlaza.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlaza.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlaza.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlaza.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlaza.Height = 0.1875!
        Me.lblPlaza.HyperLink = Nothing
        Me.lblPlaza.Left = 5.444!
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblPlaza.Text = "Plaza"
        Me.lblPlaza.Top = 0.632!
        Me.lblPlaza.Width = 0.4789997!
        '
        'lblTienda
        '
        Me.lblTienda.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTienda.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTienda.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTienda.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTienda.Height = 0.1875!
        Me.lblTienda.HyperLink = Nothing
        Me.lblTienda.Left = 5.937!
        Me.lblTienda.Name = "lblTienda"
        Me.lblTienda.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblTienda.Text = "Tienda"
        Me.lblTienda.Top = 0.632!
        Me.lblTienda.Width = 0.4789997!
        '
        'lblEstatus
        '
        Me.lblEstatus.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEstatus.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEstatus.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEstatus.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEstatus.Height = 0.1875!
        Me.lblEstatus.HyperLink = Nothing
        Me.lblEstatus.Left = 6.431!
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblEstatus.Text = "Est"
        Me.lblEstatus.Top = 0.632!
        Me.lblEstatus.Width = 0.4440002!
        '
        'lblCte
        '
        Me.lblCte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCte.Height = 0.1875!
        Me.lblCte.HyperLink = Nothing
        Me.lblCte.Left = 1.617!
        Me.lblCte.Name = "lblCte"
        Me.lblCte.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblCte.Text = "Cte"
        Me.lblCte.Top = 0.632!
        Me.lblCte.Width = 0.4379999!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblTotalCreditos
        '
        Me.lblTotalCreditos.Height = 0.1811025!
        Me.lblTotalCreditos.HyperLink = Nothing
        Me.lblTotalCreditos.Left = 2.646!
        Me.lblTotalCreditos.Name = "lblTotalCreditos"
        Me.lblTotalCreditos.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
            "25pt; font-family: Arial"
        Me.lblTotalCreditos.Text = "Creditos Aprobados"
        Me.lblTotalCreditos.Top = 0.005999997!
        Me.lblTotalCreditos.Width = 1.2055!
        '
        'lblTotalCreditoCancelado
        '
        Me.lblTotalCreditoCancelado.Height = 0.1811025!
        Me.lblTotalCreditoCancelado.HyperLink = Nothing
        Me.lblTotalCreditoCancelado.Left = 4.472!
        Me.lblTotalCreditoCancelado.Name = "lblTotalCreditoCancelado"
        Me.lblTotalCreditoCancelado.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
            "25pt; font-family: Arial"
        Me.lblTotalCreditoCancelado.Text = "Credito Cancelados"
        Me.lblTotalCreditoCancelado.Top = 0.006!
        Me.lblTotalCreditoCancelado.Width = 1.174!
        '
        'txtCreditoCancelado
        '
        Me.txtCreditoCancelado.Height = 0.1875!
        Me.txtCreditoCancelado.Left = 5.653!
        Me.txtCreditoCancelado.Name = "txtCreditoCancelado"
        Me.txtCreditoCancelado.OutputFormat = resources.GetString("txtCreditoCancelado.OutputFormat")
        Me.txtCreditoCancelado.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Arial"
        Me.txtCreditoCancelado.Text = Nothing
        Me.txtCreditoCancelado.Top = 0.0!
        Me.txtCreditoCancelado.Width = 0.5890002!
        '
        'CierreDiaVentasTotalesMicrocreditos
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.39375!
        Me.PageSettings.Margins.Top = 0.9840278!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.91!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
                    "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
                    "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
                    "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtConsecutivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClubDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaKarum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaKarum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblConsecutivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClubDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblFechaAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalCreditos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalCreditoCancelado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditoCancelado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private m_strConnectionStringDPVF As String

#Region "Constructores"

    Public Sub New(ByVal datFechaCierre As Date, ByVal strSucursal As String)

        MyBase.New()
        InitializeComponent()

        '--------------------------------------------------------
        'FLIZARRAGA 05/03/2018: ConnectionString de Servidor DPVF
        '--------------------------------------------------------
        m_strConnectionStringDPVF = "Data Source=" & oConfigCierreFI.ServerDPVF & "; Initial Catalog=" & _
                                    oConfigCierreFI.BaseDatosDPVF & "; User Id=" & _
                                    oConfigCierreFI.UserDPVF & " ;Password=" & _
                                    oConfigCierreFI.PasswordDPVF & ";TimeOut=120;"

        lblFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        LblFechaDE.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblFechaAL.Text = Format(datFechaCierre, "dd-MM-yyyy")

        LblSucursal.Text = strSucursal

        Sm_CreatDataSet(datFechaCierre)

        Sm_MostrarInformacion(datFechaCierre)

    End Sub

#End Region



#Region "Variables Miembros"

    Private dsNotasCredito As New DataSet

#End Region



#Region "Métodos Miembros"

    Private Sub Sm_CreatDataSet(ByVal datFechaCierre As Date)

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDPVF)

        Dim sccmdDataSet As SqlCommand
        Dim scdaDataSet As SqlDataAdapter


        sccmdDataSet = New SqlCommand
        scdaDataSet = New SqlDataAdapter


        With sccmdDataSet

            .Connection = sccnnConnection

            .CommandText = "[GetDisposicionEfecClubDPByFecha]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar))

        End With

        scdaDataSet.SelectCommand = sccmdDataSet

        Try
            With sccmdDataSet

                sccnnConnection.Open()

                .Parameters("@Fecha").Value = Format(datFechaCierre, "Short Date")
                .Parameters("@CodAlmacen").Value = oAppContext.ApplicationConfiguration.Almacen

                'Fill DataSet
                scdaDataSet.Fill(dsNotasCredito, "NotasCredito")

                sccnnConnection.Close()

                'If Not dsNotasCredito Is Nothing Then

                '    If dsNotasCredito.Tables(0).Rows.Count > 0 Then

                '        Sm_FormatGrid()

                '    End If

                'End If

            End With


        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Private Sub Sm_FormatGrid()

        Dim oRow As DataRow
        Dim intFolioNC As Integer = 0

        For Each oRow In dsNotasCredito.Tables(0).Rows

            If intFolioNC <> oRow!FolioNotaCredito Then

                intFolioNC = oRow!FolioNotaCredito

            Else

                oRow!Importe = 0

            End If

        Next

        oRow = Nothing

    End Sub

    Private Sub Sm_MostrarInformacion(ByVal datFechaCierre As Date)
        Dim cont As Integer = 1
        dsNotasCredito.Tables(0).Columns.Add("Consecutivo", GetType(String))
        dsNotasCredito.Tables(0).AcceptChanges()


        For Each Row As DataRow In dsNotasCredito.Tables(0).Rows
            Row("Consecutivo") = cont
            Row.AcceptChanges()
            cont += 1
        Next
        dsNotasCredito.Tables(0).AcceptChanges()
        Me.DataSource = dsNotasCredito.Tables(0)
        Dim Aceptado As Object, Cancelado As Object
        Aceptado = dsNotasCredito.Tables(0).Compute("SUM(Monto)", "EstatusDisp<>'Cancelado'")
        Cancelado = dsNotasCredito.Tables(0).Compute("SUM(Monto)", "EstatusDisp='Cancelado'")
        If Not Aceptado Is DBNull.Value Then
            tbTotalImporte.Value = CDec(Aceptado)
        Else
            tbTotalImporte.Value = 0
        End If
        If Not Cancelado Is DBNull.Value Then
            Me.txtCreditoCancelado.Value = CDec(Cancelado)
        Else
            Me.txtCreditoCancelado.Value = 0
        End If
    End Sub

#End Region

End Class
