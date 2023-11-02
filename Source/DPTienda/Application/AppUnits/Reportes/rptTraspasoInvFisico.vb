Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptTraspasoInvFisico

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal FTraslado As String, ByVal Origen As String, ByVal Destino As String)
        MyBase.New()
        InitializeComponent()
        txtFTraslado.Value = FTraslado.PadLeft(10, "0")
        txtFecha.Value = DateTime.Now.ToString("dd/MM/yyyy")
        txtOrigen.Value = Origen
        txtDestino.Value = Destino
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private LblNombRep As Label = Nothing
	Private txtOrigen As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private txtDestino As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtFTraslado As TextBox = Nothing
	Private Label15 As Label = Nothing
	Private Picture2 As Picture = Nothing
	Private Label14 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Picture3 As Picture = Nothing
	Private lblCodigo As Label = Nothing
	Private lblDescripcion As Label = Nothing
	Private lblCosto As Label = Nothing
	Private lblCantidad As Label = Nothing
	Private lblTalla As Label = Nothing
	Private lblNCaja As Label = Nothing
	Private txtCodigo As Label = Nothing
	Private txtDescripcion As Label = Nothing
	Private txtCosto As Label = Nothing
	Private txtCantidad As Label = Nothing
	Private txtTalla As Label = Nothing
	Private txtNCaja As Label = Nothing
	Private tctTCosto As TextBox = Nothing
	Private lblCostoTotal As Label = Nothing
	Private txtTCantidad As TextBox = Nothing
	Private txtTNCaja As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTraspasoInvFisico))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.LblNombRep = New DataDynamics.ActiveReports.Label()
            Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtDestino = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtFTraslado = New DataDynamics.ActiveReports.TextBox()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.Picture2 = New DataDynamics.ActiveReports.Picture()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Picture3 = New DataDynamics.ActiveReports.Picture()
            Me.lblCodigo = New DataDynamics.ActiveReports.Label()
            Me.lblDescripcion = New DataDynamics.ActiveReports.Label()
            Me.lblCosto = New DataDynamics.ActiveReports.Label()
            Me.lblCantidad = New DataDynamics.ActiveReports.Label()
            Me.lblTalla = New DataDynamics.ActiveReports.Label()
            Me.lblNCaja = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.Label()
            Me.txtDescripcion = New DataDynamics.ActiveReports.Label()
            Me.txtCosto = New DataDynamics.ActiveReports.Label()
            Me.txtCantidad = New DataDynamics.ActiveReports.Label()
            Me.txtTalla = New DataDynamics.ActiveReports.Label()
            Me.txtNCaja = New DataDynamics.ActiveReports.Label()
            Me.tctTCosto = New DataDynamics.ActiveReports.TextBox()
            Me.lblCostoTotal = New DataDynamics.ActiveReports.Label()
            Me.txtTCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtTNCaja = New DataDynamics.ActiveReports.TextBox()
            CType(Me.LblNombRep,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFTraslado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Picture3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCosto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCosto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tctTCosto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCostoTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTNCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtCosto, Me.txtCantidad, Me.txtTalla, Me.txtNCaja})
            Me.Detail.Height = 0.1979167!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LblNombRep, Me.txtOrigen, Me.Label4, Me.txtDestino, Me.Label2, Me.txtFTraslado, Me.Label15, Me.Picture2, Me.Label14, Me.txtFecha, Me.Picture3})
            Me.ReportHeader.Height = 0.9881945!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0.375!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCodigo, Me.lblDescripcion, Me.lblCosto, Me.lblCantidad, Me.lblTalla, Me.lblNCaja})
            Me.PageHeader.Height = 0.1979167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tctTCosto, Me.lblCostoTotal, Me.txtTCantidad, Me.txtTNCaja})
            Me.PageFooter.Height = 0.2076389!
            Me.PageFooter.Name = "PageFooter"
            '
            'LblNombRep
            '
            Me.LblNombRep.Height = 0.2!
            Me.LblNombRep.HyperLink = Nothing
            Me.LblNombRep.Left = 0.0625!
            Me.LblNombRep.Name = "LblNombRep"
            Me.LblNombRep.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.LblNombRep.Text = "TRASPASO DE INVENTARIO FISICO"
            Me.LblNombRep.Top = 0.0625!
            Me.LblNombRep.Width = 7.375!
            '
            'txtOrigen
            '
            Me.txtOrigen.Height = 0.2!
            Me.txtOrigen.Left = 3.84875!
            Me.txtOrigen.Name = "txtOrigen"
            Me.txtOrigen.OutputFormat = resources.GetString("txtOrigen.OutputFormat")
            Me.txtOrigen.Style = "ddo-char-set: 0; font-size: 9pt"
            Me.txtOrigen.Text = "T000 - CENTRO "
            Me.txtOrigen.Top = 0.4375!
            Me.txtOrigen.Width = 2.625!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 3.09875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label4.Text = "Destino:"
            Me.Label4.Top = 0.625!
            Me.Label4.Width = 0.75!
            '
            'txtDestino
            '
            Me.txtDestino.Height = 0.2!
            Me.txtDestino.Left = 3.84875!
            Me.txtDestino.Name = "txtDestino"
            Me.txtDestino.Style = "ddo-char-set: 0; font-size: 9pt"
            Me.txtDestino.Text = "DHL"
            Me.txtDestino.Top = 0.625!
            Me.txtDestino.Width = 2.625!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 3.09875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.Label2.Text = "Suc. Origen:"
            Me.Label2.Top = 0.4375!
            Me.Label2.Width = 0.75!
            '
            'txtFTraslado
            '
            Me.txtFTraslado.Height = 0.2!
            Me.txtFTraslado.Left = 2.09875!
            Me.txtFTraslado.Name = "txtFTraslado"
            Me.txtFTraslado.Style = "ddo-char-set: 0; font-size: 9.75pt"
            Me.txtFTraslado.Text = "1234567890"
            Me.txtFTraslado.Top = 0.625!
            Me.txtFTraslado.Width = 0.9375!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 1.03625!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "ddo-char-set: 1; font-weight: bold; font-size: 9.75pt"
            Me.Label15.Text = "Folio Traslado:"
            Me.Label15.Top = 0.625!
            Me.Label15.Width = 1.0625!
            '
            'Picture2
            '
            Me.Picture2.Height = 0.3125!
            Me.Picture2.ImageData = CType(resources.GetObject("Picture2.ImageData"),System.IO.Stream)
            Me.Picture2.Left = 0!
            Me.Picture2.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture2.LineWeight = 0!
            Me.Picture2.Name = "Picture2"
            Me.Picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture2.Top = 0!
            Me.Picture2.Width = 1.4375!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 1.03625!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt"
            Me.Label14.Text = "Fecha:"
            Me.Label14.Top = 0.4375!
            Me.Label14.Width = 1.0625!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 2.09875!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
            Me.txtFecha.Style = "ddo-char-set: 0; font-size: 9.75pt"
            Me.txtFecha.Top = 0.4375!
            Me.txtFecha.Width = 0.9375!
            '
            'Picture3
            '
            Me.Picture3.Height = 0.3125!
            Me.Picture3.ImageData = CType(resources.GetObject("Picture3.ImageData"),System.IO.Stream)
            Me.Picture3.Left = 6.072917!
            Me.Picture3.LineColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
            Me.Picture3.LineWeight = 0!
            Me.Picture3.Name = "Picture3"
            Me.Picture3.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
            Me.Picture3.Top = 0!
            Me.Picture3.Width = 1.4375!
            '
            'lblCodigo
            '
            Me.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Height = 0.1875!
            Me.lblCodigo.HyperLink = Nothing
            Me.lblCodigo.Left = 0!
            Me.lblCodigo.Name = "lblCodigo"
            Me.lblCodigo.Style = "font-weight: bold"
            Me.lblCodigo.Text = "Código"
            Me.lblCodigo.Top = 0!
            Me.lblCodigo.Width = 1.1875!
            '
            'lblDescripcion
            '
            Me.lblDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Height = 0.1875!
            Me.lblDescripcion.HyperLink = Nothing
            Me.lblDescripcion.Left = 1.1875!
            Me.lblDescripcion.Name = "lblDescripcion"
            Me.lblDescripcion.Style = "font-weight: bold"
            Me.lblDescripcion.Text = "Descripción"
            Me.lblDescripcion.Top = 0!
            Me.lblDescripcion.Width = 2.5625!
            '
            'lblCosto
            '
            Me.lblCosto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCosto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCosto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCosto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCosto.Height = 0.188!
            Me.lblCosto.HyperLink = Nothing
            Me.lblCosto.Left = 3.75!
            Me.lblCosto.Name = "lblCosto"
            Me.lblCosto.Style = "text-align: center; font-weight: bold"
            Me.lblCosto.Text = "Costo"
            Me.lblCosto.Top = 0!
            Me.lblCosto.Width = 0.938!
            '
            'lblCantidad
            '
            Me.lblCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Height = 0.1875!
            Me.lblCantidad.HyperLink = Nothing
            Me.lblCantidad.Left = 4.6875!
            Me.lblCantidad.Name = "lblCantidad"
            Me.lblCantidad.Style = "text-align: center; font-weight: bold"
            Me.lblCantidad.Text = "Cantidad"
            Me.lblCantidad.Top = 0!
            Me.lblCantidad.Width = 0.9375!
            '
            'lblTalla
            '
            Me.lblTalla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Height = 0.1875!
            Me.lblTalla.HyperLink = Nothing
            Me.lblTalla.Left = 5.625!
            Me.lblTalla.Name = "lblTalla"
            Me.lblTalla.Style = "text-align: center; font-weight: bold"
            Me.lblTalla.Text = "Talla"
            Me.lblTalla.Top = 0!
            Me.lblTalla.Width = 0.9375!
            '
            'lblNCaja
            '
            Me.lblNCaja.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNCaja.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNCaja.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNCaja.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNCaja.Height = 0.1875!
            Me.lblNCaja.HyperLink = Nothing
            Me.lblNCaja.Left = 6.5625!
            Me.lblNCaja.Name = "lblNCaja"
            Me.lblNCaja.Style = "text-align: center; font-weight: bold"
            Me.lblNCaja.Text = "# Caja"
            Me.lblNCaja.Top = 0!
            Me.lblNCaja.Width = 0.9375!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Material"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.HyperLink = Nothing
            Me.txtCodigo.Left = 0.01041667!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: left; font-weight: normal"
            Me.txtCodigo.Text = ""
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.177083!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.HyperLink = Nothing
            Me.txtDescripcion.Left = 1.1875!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-weight: normal"
            Me.txtDescripcion.Text = ""
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 2.5625!
            '
            'txtCosto
            '
            Me.txtCosto.DataField = "Costo"
            Me.txtCosto.Height = 0.1875!
            Me.txtCosto.HyperLink = Nothing
            Me.txtCosto.Left = 3.75!
            Me.txtCosto.Name = "txtCosto"
            Me.txtCosto.Style = "text-align: center; font-weight: normal"
            Me.txtCosto.Text = ""
            Me.txtCosto.Top = 0!
            Me.txtCosto.Width = 0.9479167!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.1875!
            Me.txtCantidad.HyperLink = Nothing
            Me.txtCantidad.Left = 4.6875!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-weight: normal"
            Me.txtCantidad.Text = ""
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.9375!
            '
            'txtTalla
            '
            Me.txtTalla.DataField = "Talla"
            Me.txtTalla.Height = 0.1875!
            Me.txtTalla.HyperLink = Nothing
            Me.txtTalla.Left = 5.625!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: center; font-weight: normal"
            Me.txtTalla.Text = ""
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.9375!
            '
            'txtNCaja
            '
            Me.txtNCaja.DataField = "CajaID"
            Me.txtNCaja.Height = 0.1875!
            Me.txtNCaja.HyperLink = Nothing
            Me.txtNCaja.Left = 6.5625!
            Me.txtNCaja.Name = "txtNCaja"
            Me.txtNCaja.Style = "text-align: center; font-weight: normal"
            Me.txtNCaja.Text = ""
            Me.txtNCaja.Top = 0!
            Me.txtNCaja.Width = 0.9375!
            '
            'tctTCosto
            '
            Me.tctTCosto.DataField = "Costo"
            Me.tctTCosto.Height = 0.1875!
            Me.tctTCosto.Left = 3.75!
            Me.tctTCosto.Name = "tctTCosto"
            Me.tctTCosto.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tctTCosto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tctTCosto.Top = 0!
            Me.tctTCosto.Width = 0.9375!
            '
            'lblCostoTotal
            '
            Me.lblCostoTotal.Height = 0.1875!
            Me.lblCostoTotal.HyperLink = Nothing
            Me.lblCostoTotal.Left = 2.822917!
            Me.lblCostoTotal.Name = "lblCostoTotal"
            Me.lblCostoTotal.Style = "font-weight: bold"
            Me.lblCostoTotal.Text = "Totales:"
            Me.lblCostoTotal.Top = 0!
            Me.lblCostoTotal.Width = 0.9375!
            '
            'txtTCantidad
            '
            Me.txtTCantidad.DataField = "Cantidad"
            Me.txtTCantidad.Height = 0.1875!
            Me.txtTCantidad.Left = 4.697917!
            Me.txtTCantidad.Name = "txtTCantidad"
            Me.txtTCantidad.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTCantidad.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTCantidad.Top = 0!
            Me.txtTCantidad.Width = 0.9375!
            '
            'txtTNCaja
            '
            Me.txtTNCaja.DataField = "CajaID"
            Me.txtTNCaja.Height = 0.1875!
            Me.txtTNCaja.Left = 6.5625!
            Me.txtTNCaja.Name = "txtTNCaja"
            Me.txtTNCaja.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
            Me.txtTNCaja.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTNCaja.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTNCaja.Top = 0!
            Me.txtTNCaja.Width = 0.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.2!
            Me.PageSettings.Margins.Left = 0.2!
            Me.PageSettings.Margins.Right = 0.2!
            Me.PageSettings.Margins.Top = 0.2!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.510417!
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
            CType(Me.LblNombRep,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDestino,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFTraslado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Picture3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCosto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCosto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tctTCosto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCostoTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTNCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        Me.txtCosto.Text = Format(CDec(Me.txtCosto.Text), "$ 0.0")
    End Sub

End Class
