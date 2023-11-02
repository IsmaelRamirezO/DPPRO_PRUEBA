Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptTraspasosEntradasInventarios
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal sucursal As String, ByVal titulo As String)
        MyBase.New()
        InitializeComponent()
        txtDe.Value = FechaInicio.ToString("dd/MM/yyyy")
        txtA.Value = FechaFin.ToString("dd/MM/yyyy")
        txtFecha.Value = DateTime.Now.ToString("dd/MM/yyyy")
        txtSucursal.Value = sucursal
        lblTituloReporte.Text = titulo
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private lblTituloReporte As Label = Nothing
    Private lblDe As Label = Nothing
    Private txtDe As Label = Nothing
    Private lblA As Label = Nothing
    Private txtA As Label = Nothing
    Private lblSucursal As Label = Nothing
    Private txtSucursal As Label = Nothing
    Private lblFecha As Label = Nothing
    Private txtFecha As Label = Nothing
    Private lblFolioSAP As Label = Nothing
    Private lblOrigen As Label = Nothing
    Private lblDestino As Label = Nothing
    Private lblPiezas As Label = Nothing
    Private lblCosto As Label = Nothing
    Private lblUsuario As Label = Nothing
    Private lblGuia As Label = Nothing
    Private lblFechaTraspaso As Label = Nothing
    Private txtFolioSAP As Label = Nothing
    Private txtFechaTraspaso As Label = Nothing
    Private txtOrigen As Label = Nothing
    Private txtDestino As Label = Nothing
    Private txtPiezas As Label = Nothing
    Private txtCosto As Label = Nothing
    Private txtUsuario As Label = Nothing
    Private txtGuia As Label = Nothing
    Private lblCostoTotal As Label = Nothing
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private txtCostoTotal As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTraspasosEntradasInventarios))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtFolioSAP = New DataDynamics.ActiveReports.Label()
        Me.txtFechaTraspaso = New DataDynamics.ActiveReports.Label()
        Me.txtOrigen = New DataDynamics.ActiveReports.Label()
        Me.txtDestino = New DataDynamics.ActiveReports.Label()
        Me.txtPiezas = New DataDynamics.ActiveReports.Label()
        Me.txtCosto = New DataDynamics.ActiveReports.Label()
        Me.txtUsuario = New DataDynamics.ActiveReports.Label()
        Me.txtGuia = New DataDynamics.ActiveReports.Label()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.lblTituloReporte = New DataDynamics.ActiveReports.Label()
        Me.lblDe = New DataDynamics.ActiveReports.Label()
        Me.txtDe = New DataDynamics.ActiveReports.Label()
        Me.lblA = New DataDynamics.ActiveReports.Label()
        Me.txtA = New DataDynamics.ActiveReports.Label()
        Me.lblSucursal = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblFolioSAP = New DataDynamics.ActiveReports.Label()
        Me.lblOrigen = New DataDynamics.ActiveReports.Label()
        Me.lblDestino = New DataDynamics.ActiveReports.Label()
        Me.lblPiezas = New DataDynamics.ActiveReports.Label()
        Me.lblCosto = New DataDynamics.ActiveReports.Label()
        Me.lblUsuario = New DataDynamics.ActiveReports.Label()
        Me.lblGuia = New DataDynamics.ActiveReports.Label()
        Me.lblFechaTraspaso = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblCostoTotal = New DataDynamics.ActiveReports.Label()
        Me.txtCostoTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaTraspaso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTituloReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaTraspaso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCostoTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCostoTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioSAP, Me.txtFechaTraspaso, Me.txtOrigen, Me.txtDestino, Me.txtPiezas, Me.txtCosto, Me.txtUsuario, Me.txtGuia, Me.Label2})
        Me.Detail.Height = 0.2083333!
        Me.Detail.Name = "Detail"
        '
        'txtFolioSAP
        '
        Me.txtFolioSAP.DataField = "FolioSAP"
        Me.txtFolioSAP.Height = 0.1875!
        Me.txtFolioSAP.HyperLink = Nothing
        Me.txtFolioSAP.Left = 0.0!
        Me.txtFolioSAP.Name = "txtFolioSAP"
        Me.txtFolioSAP.Style = "font-weight: normal"
        Me.txtFolioSAP.Text = ""
        Me.txtFolioSAP.Top = 0.0!
        Me.txtFolioSAP.Width = 1.0!
        '
        'txtFechaTraspaso
        '
        Me.txtFechaTraspaso.DataField = "FechaTraspaso"
        Me.txtFechaTraspaso.Height = 0.1875!
        Me.txtFechaTraspaso.HyperLink = Nothing
        Me.txtFechaTraspaso.Left = 1.0!
        Me.txtFechaTraspaso.Name = "txtFechaTraspaso"
        Me.txtFechaTraspaso.Style = "font-weight: normal"
        Me.txtFechaTraspaso.Text = ""
        Me.txtFechaTraspaso.Top = 0.0!
        Me.txtFechaTraspaso.Width = 1.125!
        '
        'txtOrigen
        '
        Me.txtOrigen.DataField = "Origen"
        Me.txtOrigen.Height = 0.1875!
        Me.txtOrigen.HyperLink = Nothing
        Me.txtOrigen.Left = 2.125!
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Style = "text-align: left; font-weight: normal"
        Me.txtOrigen.Text = ""
        Me.txtOrigen.Top = 0.0!
        Me.txtOrigen.Width = 0.5830002!
        '
        'txtDestino
        '
        Me.txtDestino.DataField = "Destino"
        Me.txtDestino.Height = 0.1875!
        Me.txtDestino.HyperLink = Nothing
        Me.txtDestino.Left = 2.708!
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Style = "text-align: left; font-weight: normal"
        Me.txtDestino.Text = ""
        Me.txtDestino.Top = 0.0!
        Me.txtDestino.Width = 0.6140001!
        '
        'txtPiezas
        '
        Me.txtPiezas.DataField = "Piezas"
        Me.txtPiezas.Height = 0.1875!
        Me.txtPiezas.HyperLink = Nothing
        Me.txtPiezas.Left = 3.323!
        Me.txtPiezas.Name = "txtPiezas"
        Me.txtPiezas.Style = "text-align: right; font-weight: normal"
        Me.txtPiezas.Text = ""
        Me.txtPiezas.Top = 0.0!
        Me.txtPiezas.Width = 0.5940003!
        '
        'txtCosto
        '
        Me.txtCosto.DataField = "Costo"
        Me.txtCosto.Height = 0.1875!
        Me.txtCosto.HyperLink = Nothing
        Me.txtCosto.Left = 3.917!
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Style = "text-align: right; font-weight: normal"
        Me.txtCosto.Text = ""
        Me.txtCosto.Top = 0.0!
        Me.txtCosto.Width = 0.7189999!
        '
        'txtUsuario
        '
        Me.txtUsuario.DataField = "UsuarioDPPRO"
        Me.txtUsuario.Height = 0.1875!
        Me.txtUsuario.HyperLink = Nothing
        Me.txtUsuario.Left = 4.635!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "text-align: left; font-weight: normal"
        Me.txtUsuario.Text = ""
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 0.9375!
        '
        'txtGuia
        '
        Me.txtGuia.DataField = "Guia"
        Me.txtGuia.Height = 0.1875!
        Me.txtGuia.HyperLink = Nothing
        Me.txtGuia.Left = 5.573!
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Style = "text-align: left; font-weight: normal"
        Me.txtGuia.Text = ""
        Me.txtGuia.Top = 0.0!
        Me.txtGuia.Width = 0.9375!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTituloReporte, Me.lblDe, Me.txtDe, Me.lblA, Me.txtA, Me.lblSucursal, Me.txtSucursal, Me.lblFecha, Me.txtFecha})
        Me.ReportHeader.Height = 0.9166667!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblTituloReporte
        '
        Me.lblTituloReporte.Height = 0.25!
        Me.lblTituloReporte.HyperLink = Nothing
        Me.lblTituloReporte.Left = 1.8125!
        Me.lblTituloReporte.Name = "lblTituloReporte"
        Me.lblTituloReporte.Style = "font-weight: bold; font-size: 14pt"
        Me.lblTituloReporte.Text = "Reporte Traspasos Entradas"
        Me.lblTituloReporte.Top = 0.0625!
        Me.lblTituloReporte.Width = 5.625!
        '
        'lblDe
        '
        Me.lblDe.Height = 0.1875!
        Me.lblDe.HyperLink = Nothing
        Me.lblDe.Left = 1.9375!
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Style = "font-weight: bold"
        Me.lblDe.Text = "De:"
        Me.lblDe.Top = 0.375!
        Me.lblDe.Width = 0.3125!
        '
        'txtDe
        '
        Me.txtDe.Height = 0.1875!
        Me.txtDe.HyperLink = Nothing
        Me.txtDe.Left = 2.25!
        Me.txtDe.Name = "txtDe"
        Me.txtDe.Style = ""
        Me.txtDe.Text = ""
        Me.txtDe.Top = 0.375!
        Me.txtDe.Width = 0.9375!
        '
        'lblA
        '
        Me.lblA.Height = 0.1875!
        Me.lblA.HyperLink = Nothing
        Me.lblA.Left = 3.1875!
        Me.lblA.Name = "lblA"
        Me.lblA.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
        Me.lblA.Text = "A"
        Me.lblA.Top = 0.375!
        Me.lblA.Width = 0.1875!
        '
        'txtA
        '
        Me.txtA.Height = 0.188!
        Me.txtA.HyperLink = Nothing
        Me.txtA.Left = 3.375!
        Me.txtA.Name = "txtA"
        Me.txtA.Style = ""
        Me.txtA.Text = ""
        Me.txtA.Top = 0.375!
        Me.txtA.Width = 0.938!
        '
        'lblSucursal
        '
        Me.lblSucursal.Height = 0.1875!
        Me.lblSucursal.HyperLink = Nothing
        Me.lblSucursal.Left = 1.9375!
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Style = "font-weight: bold"
        Me.lblSucursal.Text = "Sucursal:"
        Me.lblSucursal.Top = 0.5625!
        Me.lblSucursal.Width = 0.6875!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.1875!
        Me.txtSucursal.HyperLink = Nothing
        Me.txtSucursal.Left = 2.625!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Style = ""
        Me.txtSucursal.Text = ""
        Me.txtSucursal.Top = 0.5625!
        Me.txtSucursal.Width = 3.5625!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.1875!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.0625!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-weight: bold"
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Top = 0.125!
        Me.lblFecha.Width = 0.5625!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.HyperLink = Nothing
        Me.txtFecha.Left = 0.625!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = ""
        Me.txtFecha.Text = ""
        Me.txtFecha.Top = 0.125!
        Me.txtFecha.Width = 1.125!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.25!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFolioSAP, Me.lblOrigen, Me.lblDestino, Me.lblPiezas, Me.lblCosto, Me.lblUsuario, Me.lblGuia, Me.lblFechaTraspaso, Me.Label1})
        Me.PageHeader.Height = 0.1875!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblFolioSAP
        '
        Me.lblFolioSAP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Height = 0.1875!
        Me.lblFolioSAP.HyperLink = Nothing
        Me.lblFolioSAP.Left = 0.0!
        Me.lblFolioSAP.Name = "lblFolioSAP"
        Me.lblFolioSAP.Style = "font-weight: bold; background-color: LightGrey"
        Me.lblFolioSAP.Text = "Folio SAP"
        Me.lblFolioSAP.Top = 0.0!
        Me.lblFolioSAP.Width = 1.0!
        '
        'lblOrigen
        '
        Me.lblOrigen.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrigen.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrigen.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrigen.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblOrigen.Height = 0.1875!
        Me.lblOrigen.HyperLink = Nothing
        Me.lblOrigen.Left = 2.125!
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblOrigen.Text = "Origen"
        Me.lblOrigen.Top = 0.0!
        Me.lblOrigen.Width = 0.5830002!
        '
        'lblDestino
        '
        Me.lblDestino.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDestino.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDestino.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDestino.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDestino.Height = 0.1875!
        Me.lblDestino.HyperLink = Nothing
        Me.lblDestino.Left = 2.708!
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblDestino.Text = "Destino"
        Me.lblDestino.Top = 0.0!
        Me.lblDestino.Width = 0.6140001!
        '
        'lblPiezas
        '
        Me.lblPiezas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPiezas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPiezas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPiezas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPiezas.Height = 0.1875!
        Me.lblPiezas.HyperLink = Nothing
        Me.lblPiezas.Left = 3.322!
        Me.lblPiezas.Name = "lblPiezas"
        Me.lblPiezas.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblPiezas.Text = "Piezas"
        Me.lblPiezas.Top = 0.0!
        Me.lblPiezas.Width = 0.5940003!
        '
        'lblCosto
        '
        Me.lblCosto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCosto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCosto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCosto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCosto.Height = 0.1875!
        Me.lblCosto.HyperLink = Nothing
        Me.lblCosto.Left = 3.916!
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblCosto.Text = "Costo"
        Me.lblCosto.Top = 0.0!
        Me.lblCosto.Width = 0.7189999!
        '
        'lblUsuario
        '
        Me.lblUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblUsuario.Height = 0.1875!
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Left = 4.635!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.Top = 0.0!
        Me.lblUsuario.Width = 0.9375!
        '
        'lblGuia
        '
        Me.lblGuia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGuia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGuia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGuia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGuia.Height = 0.1875!
        Me.lblGuia.HyperLink = Nothing
        Me.lblGuia.Left = 5.572!
        Me.lblGuia.Name = "lblGuia"
        Me.lblGuia.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.lblGuia.Text = "Guía"
        Me.lblGuia.Top = 0.0!
        Me.lblGuia.Width = 0.9375!
        '
        'lblFechaTraspaso
        '
        Me.lblFechaTraspaso.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaTraspaso.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaTraspaso.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaTraspaso.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFechaTraspaso.Height = 0.1875!
        Me.lblFechaTraspaso.HyperLink = Nothing
        Me.lblFechaTraspaso.Left = 1.0!
        Me.lblFechaTraspaso.Name = "lblFechaTraspaso"
        Me.lblFechaTraspaso.Style = "font-weight: bold; background-color: LightGrey"
        Me.lblFechaTraspaso.Text = "Fecha Traspaso"
        Me.lblFechaTraspaso.Top = 0.0!
        Me.lblFechaTraspaso.Width = 1.125!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCostoTotal, Me.txtCostoTotal})
        Me.PageFooter.Height = 0.1979167!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.Height = 0.1875!
        Me.lblCostoTotal.HyperLink = Nothing
        Me.lblCostoTotal.Left = 2.98!
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Style = "font-weight: bold"
        Me.lblCostoTotal.Text = "Costo Total:"
        Me.lblCostoTotal.Top = 0.0!
        Me.lblCostoTotal.Width = 0.9375!
        '
        'txtCostoTotal
        '
        Me.txtCostoTotal.DataField = "Costo"
        Me.txtCostoTotal.Height = 0.1875!
        Me.txtCostoTotal.Left = 3.9175!
        Me.txtCostoTotal.Name = "txtCostoTotal"
        Me.txtCostoTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtCostoTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtCostoTotal.Text = Nothing
        Me.txtCostoTotal.Top = 0.0!
        Me.txtCostoTotal.Width = 0.9375!
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 6.51!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; background-color: LightGrey"
        Me.Label1.Text = "Motivo"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.74!
        '
        'Label2
        '
        Me.Label2.DataField = "Motivo"
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.51!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: left; font-weight: normal"
        Me.Label2.Text = ""
        Me.Label2.Top = -9.313226E-10!
        Me.Label2.Width = 1.74!
        '
        'rptTraspasosEntradasInventarios
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 8.27025!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaTraspaso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTituloReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaTraspaso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCostoTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCostoTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
