Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptMetasPlayers
    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime)
        MyBase.New()
        InitializeComponent()
        txtFechaInicio.Value = fechaInicio.ToString("dd/MM/yyyy")
        txtFechaFin.Value = fechaFin.ToString("dd/MM/yyyy")
        Me.FechaInicio = fechaInicio
        Me.FechaFin = fechaFin
        Initialize()
        SetMetasDiariasPlayers(fechaInicio, fechaFin)
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Line1 As Line = Nothing
    Private lblMarcadorxPlayer As Label = Nothing
    Private txtFechaFin As TextBox = Nothing
    Private lblA As Label = Nothing
    Private txtFechaInicio As TextBox = Nothing
    Private lblDe As Label = Nothing
    Private txtFechaReporte As TextBox = Nothing
    Private lblFecha As Label = Nothing
    Private lblCodPlayer As TextBox = Nothing
    Private lblNombre As TextBox = Nothing
    Private lblMeta As TextBox = Nothing
    Private lblAPV As TextBox = Nothing
    Private lblVenta As TextBox = Nothing
    Private lblCuantoxVender As TextBox = Nothing
    Private lblClientexAtender As TextBox = Nothing
    Private txtCodPlayer As TextBox = Nothing
    Private txtNombre As TextBox = Nothing
    Private txtMeta As TextBox = Nothing
    Private txtAPV As TextBox = Nothing
    Private txtVenta As TextBox = Nothing
    Private txtCuantoxVender As TextBox = Nothing
    Private txtClientexAtender As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptMetasPlayers))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.lblMarcadorxPlayer = New DataDynamics.ActiveReports.Label()
            Me.txtFechaFin = New DataDynamics.ActiveReports.TextBox()
            Me.lblA = New DataDynamics.ActiveReports.Label()
            Me.txtFechaInicio = New DataDynamics.ActiveReports.TextBox()
            Me.lblDe = New DataDynamics.ActiveReports.Label()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCodPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.lblNombre = New DataDynamics.ActiveReports.TextBox()
            Me.lblMeta = New DataDynamics.ActiveReports.TextBox()
            Me.lblAPV = New DataDynamics.ActiveReports.TextBox()
            Me.lblVenta = New DataDynamics.ActiveReports.TextBox()
            Me.lblCuantoxVender = New DataDynamics.ActiveReports.TextBox()
            Me.lblClientexAtender = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodPlayer = New DataDynamics.ActiveReports.TextBox()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtMeta = New DataDynamics.ActiveReports.TextBox()
            Me.txtAPV = New DataDynamics.ActiveReports.TextBox()
            Me.txtVenta = New DataDynamics.ActiveReports.TextBox()
            Me.txtCuantoxVender = New DataDynamics.ActiveReports.TextBox()
            Me.txtClientexAtender = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblMarcadorxPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaFin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblA,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaInicio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCodPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblAPV,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCuantoxVender,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblClientexAtender,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodPlayer,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMeta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtAPV,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVenta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCuantoxVender,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtClientexAtender,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodPlayer, Me.txtNombre, Me.txtMeta, Me.txtAPV, Me.txtVenta, Me.txtCuantoxVender, Me.txtClientexAtender})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.lblMarcadorxPlayer, Me.txtFechaFin, Me.lblA, Me.txtFechaInicio, Me.lblDe, Me.txtFechaReporte, Me.lblFecha})
            Me.ReportHeader.Height = 0.59375!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCodPlayer, Me.lblNombre, Me.lblMeta, Me.lblAPV, Me.lblVenta, Me.lblCuantoxVender, Me.lblClientexAtender})
            Me.PageHeader.Height = 0.3222222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.01041667!
            Me.PageFooter.Name = "PageFooter"
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0625!
            Me.Line1.LineWeight = 3!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0!
            Me.Line1.Width = 6.4375!
            Me.Line1.X1 = 0.0625!
            Me.Line1.X2 = 6.5!
            Me.Line1.Y1 = 0!
            Me.Line1.Y2 = 0!
            '
            'lblMarcadorxPlayer
            '
            Me.lblMarcadorxPlayer.Height = 0.2!
            Me.lblMarcadorxPlayer.HyperLink = Nothing
            Me.lblMarcadorxPlayer.Left = 1.375!
            Me.lblMarcadorxPlayer.Name = "lblMarcadorxPlayer"
            Me.lblMarcadorxPlayer.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblMarcadorxPlayer.Text = "Marcador por Players"
            Me.lblMarcadorxPlayer.Top = 0.0625!
            Me.lblMarcadorxPlayer.Width = 3.6875!
            '
            'txtFechaFin
            '
            Me.txtFechaFin.Height = 0.2!
            Me.txtFechaFin.Left = 2.625!
            Me.txtFechaFin.Name = "txtFechaFin"
            Me.txtFechaFin.OutputFormat = resources.GetString("txtFechaFin.OutputFormat")
            Me.txtFechaFin.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaFin.Top = 0.375!
            Me.txtFechaFin.Width = 0.8125!
            '
            'lblA
            '
            Me.lblA.Height = 0.2!
            Me.lblA.HyperLink = Nothing
            Me.lblA.Left = 2.4375!
            Me.lblA.Name = "lblA"
            Me.lblA.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblA.Text = "A:"
            Me.lblA.Top = 0.375!
            Me.lblA.Width = 0.1875!
            '
            'txtFechaInicio
            '
            Me.txtFechaInicio.Height = 0.2!
            Me.txtFechaInicio.Left = 1.625!
            Me.txtFechaInicio.Name = "txtFechaInicio"
            Me.txtFechaInicio.OutputFormat = resources.GetString("txtFechaInicio.OutputFormat")
            Me.txtFechaInicio.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaInicio.Top = 0.375!
            Me.txtFechaInicio.Width = 0.8125!
            '
            'lblDe
            '
            Me.lblDe.Height = 0.2!
            Me.lblDe.HyperLink = Nothing
            Me.lblDe.Left = 1.375!
            Me.lblDe.Name = "lblDe"
            Me.lblDe.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblDe.Text = "De:"
            Me.lblDe.Top = 0.375!
            Me.lblDe.Width = 0.25!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 0.5!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.OutputFormat = resources.GetString("txtFechaReporte.OutputFormat")
            Me.txtFechaReporte.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtFechaReporte.Top = 0.0625!
            Me.txtFechaReporte.Width = 0.8125!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt"
            Me.lblFecha.Text = "Fecha:"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.4375!
            '
            'lblCodPlayer
            '
            Me.lblCodPlayer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodPlayer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodPlayer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodPlayer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodPlayer.Height = 0.3125!
            Me.lblCodPlayer.Left = 0!
            Me.lblCodPlayer.Name = "lblCodPlayer"
            Me.lblCodPlayer.OutputFormat = resources.GetString("lblCodPlayer.OutputFormat")
            Me.lblCodPlayer.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblCodPlayer.Text = "ID"
            Me.lblCodPlayer.Top = 0!
            Me.lblCodPlayer.Width = 0.625!
            '
            'lblNombre
            '
            Me.lblNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNombre.Height = 0.3125!
            Me.lblNombre.Left = 0.625!
            Me.lblNombre.Name = "lblNombre"
            Me.lblNombre.OutputFormat = resources.GetString("lblNombre.OutputFormat")
            Me.lblNombre.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblNombre.Text = "Nombre"
            Me.lblNombre.Top = 0!
            Me.lblNombre.Width = 1.62!
            '
            'lblMeta
            '
            Me.lblMeta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMeta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMeta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMeta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMeta.Height = 0.3125!
            Me.lblMeta.Left = 2.25!
            Me.lblMeta.Name = "lblMeta"
            Me.lblMeta.OutputFormat = resources.GetString("lblMeta.OutputFormat")
            Me.lblMeta.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblMeta.Text = "Meta"
            Me.lblMeta.Top = 0!
            Me.lblMeta.Width = 0.8125!
            '
            'lblAPV
            '
            Me.lblAPV.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblAPV.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblAPV.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblAPV.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblAPV.Height = 0.3125!
            Me.lblAPV.Left = 3.0625!
            Me.lblAPV.Name = "lblAPV"
            Me.lblAPV.OutputFormat = resources.GetString("lblAPV.OutputFormat")
            Me.lblAPV.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblAPV.Text = "APV"
            Me.lblAPV.Top = 0!
            Me.lblAPV.Width = 0.6875!
            '
            'lblVenta
            '
            Me.lblVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblVenta.Height = 0.3125!
            Me.lblVenta.Left = 3.75!
            Me.lblVenta.Name = "lblVenta"
            Me.lblVenta.OutputFormat = resources.GetString("lblVenta.OutputFormat")
            Me.lblVenta.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblVenta.Text = "Venta"
            Me.lblVenta.Top = 0!
            Me.lblVenta.Width = 0.8125!
            '
            'lblCuantoxVender
            '
            Me.lblCuantoxVender.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCuantoxVender.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCuantoxVender.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCuantoxVender.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCuantoxVender.Height = 0.3125!
            Me.lblCuantoxVender.Left = 4.5625!
            Me.lblCuantoxVender.Name = "lblCuantoxVender"
            Me.lblCuantoxVender.OutputFormat = resources.GetString("lblCuantoxVender.OutputFormat")
            Me.lblCuantoxVender.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblCuantoxVender.Text = "Cuanto Por Vender"
            Me.lblCuantoxVender.Top = 0!
            Me.lblCuantoxVender.Width = 0.9375!
            '
            'lblClientexAtender
            '
            Me.lblClientexAtender.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblClientexAtender.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblClientexAtender.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblClientexAtender.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblClientexAtender.Height = 0.3125!
            Me.lblClientexAtender.Left = 5.5!
            Me.lblClientexAtender.Name = "lblClientexAtender"
            Me.lblClientexAtender.OutputFormat = resources.GetString("lblClientexAtender.OutputFormat")
            Me.lblClientexAtender.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.lblClientexAtender.Text = "Clientes por Atender"
            Me.lblClientexAtender.Top = 0!
            Me.lblClientexAtender.Width = 0.9375!
            '
            'txtCodPlayer
            '
            Me.txtCodPlayer.DataField = "CodPlayer"
            Me.txtCodPlayer.Height = 0.2!
            Me.txtCodPlayer.Left = 0!
            Me.txtCodPlayer.Name = "txtCodPlayer"
            Me.txtCodPlayer.OutputFormat = resources.GetString("txtCodPlayer.OutputFormat")
            Me.txtCodPlayer.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt"
            Me.txtCodPlayer.Top = 0!
            Me.txtCodPlayer.Width = 0.625!
            '
            'txtNombre
            '
            Me.txtNombre.DataField = "NombrePlayer"
            Me.txtNombre.Height = 0.2!
            Me.txtNombre.Left = 0.63!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.OutputFormat = resources.GetString("txtNombre.OutputFormat")
            Me.txtNombre.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic"& _ 
                "al-align: top"
            Me.txtNombre.Top = 0!
            Me.txtNombre.Width = 1.62!
            '
            'txtMeta
            '
            Me.txtMeta.DataField = "MetaDia"
            Me.txtMeta.Height = 0.2!
            Me.txtMeta.Left = 2.25!
            Me.txtMeta.Name = "txtMeta"
            Me.txtMeta.OutputFormat = resources.GetString("txtMeta.OutputFormat")
            Me.txtMeta.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; vert"& _ 
                "ical-align: top"
            Me.txtMeta.Top = 0!
            Me.txtMeta.Width = 0.813!
            '
            'txtAPV
            '
            Me.txtAPV.DataField = "APV"
            Me.txtAPV.Height = 0.2!
            Me.txtAPV.Left = 3.0625!
            Me.txtAPV.Name = "txtAPV"
            Me.txtAPV.OutputFormat = resources.GetString("txtAPV.OutputFormat")
            Me.txtAPV.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; vert"& _ 
                "ical-align: top"
            Me.txtAPV.Top = 0!
            Me.txtAPV.Width = 0.688!
            '
            'txtVenta
            '
            Me.txtVenta.DataField = "Venta"
            Me.txtVenta.Height = 0.2!
            Me.txtVenta.Left = 3.75!
            Me.txtVenta.Name = "txtVenta"
            Me.txtVenta.OutputFormat = resources.GetString("txtVenta.OutputFormat")
            Me.txtVenta.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; vert"& _ 
                "ical-align: top"
            Me.txtVenta.Top = 0!
            Me.txtVenta.Width = 0.813!
            '
            'txtCuantoxVender
            '
            Me.txtCuantoxVender.DataField = "PorVender"
            Me.txtCuantoxVender.Height = 0.2!
            Me.txtCuantoxVender.Left = 4.5625!
            Me.txtCuantoxVender.Name = "txtCuantoxVender"
            Me.txtCuantoxVender.OutputFormat = resources.GetString("txtCuantoxVender.OutputFormat")
            Me.txtCuantoxVender.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; vert"& _ 
                "ical-align: top"
            Me.txtCuantoxVender.Top = 0!
            Me.txtCuantoxVender.Width = 0.938!
            '
            'txtClientexAtender
            '
            Me.txtClientexAtender.DataField = "PorAtender"
            Me.txtClientexAtender.Height = 0.2!
            Me.txtClientexAtender.Left = 5.5!
            Me.txtClientexAtender.Name = "txtClientexAtender"
            Me.txtClientexAtender.OutputFormat = resources.GetString("txtClientexAtender.OutputFormat")
            Me.txtClientexAtender.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; vert"& _ 
                "ical-align: top"
            Me.txtClientexAtender.Top = 0!
            Me.txtClientexAtender.Width = 0.938!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
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
            CType(Me.lblMarcadorxPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaFin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblA,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaInicio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCodPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblAPV,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCuantoxVender,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblClientexAtender,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodPlayer,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMeta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtAPV,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVenta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCuantoxVender,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtClientexAtender,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

#Region "Variables"
    Private FechaInicio As DateTime, FechaFin As DateTime
    Private dtMetasPlayer As DataTable
    Private webService As WSBroker
#End Region

#Region "Metodos de Reporte"
    Private Sub Initialize()
        Me.dtMetasPlayer = New DataTable("MetaPlayer")
        Me.dtMetasPlayer.Columns.Add("CodPlayer", GetType(String))
        Me.dtMetasPlayer.Columns.Add("NombrePlayer", GetType(String))
        Me.dtMetasPlayer.Columns.Add("MetaDia", GetType(Decimal))
        Me.dtMetasPlayer.Columns.Add("APV", GetType(Decimal))
        Me.dtMetasPlayer.Columns.Add("Venta", GetType(Decimal))
        Me.dtMetasPlayer.Columns.Add("PorVender", GetType(Decimal))
        Me.dtMetasPlayer.Columns.Add("PorAtender", GetType(Decimal))
        Me.dtMetasPlayer.AcceptChanges()
        Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fecha As DateTime = proceso.MSS_GET_SY_DATE_TIME()
        Dim fechaInicio As DateTime, fechaFin As DateTime, lastDay As Date
        Dim lstMeses As ArrayList = GetListaMeses()
        If fecha.Day < 16 Then
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 1)
            fechaFin = New DateTime(fecha.Year, fecha.Month, 15)
        Else
            fechaInicio = New DateTime(fecha.Year, fecha.Month, 16)
            lastDay = fecha.AddMonths(1)
            lastDay = New Date(lastDay.Year, lastDay.Month, 1)
            fechaFin = lastDay.AddDays(-1)
            'If lstMeses.Contains(fecha.Month) Then
            '    fechaFin = New DateTime(fecha.Year, fecha.Month, 31)
            'Else
            '    fechaFin = New DateTime(fecha.Year, fecha.Month, 30)
            'End If
        End If
        Me.webService = New WSBroker("METAS_MS")
        Dim dtResponse As DataTable = Me.webService.GetMetasDiasPlayer("T" & oAppContext.ApplicationConfiguration.Almacen, fechaInicio, fechaFin)
        If Not dtResponse Is Nothing Then
            Dim codPlayer As String = "", fila As DataRow = Nothing
            If dtResponse.Rows.Count > 0 Then
                Dim lstPlayers As New ArrayList
                For Each row As DataRow In dtResponse.Rows
                    codPlayer = CStr(row("CodEmpleado"))
                    If lstPlayers.Contains(codPlayer) = False Then
                        lstPlayers.Add(codPlayer)
                    End If
                Next
                Dim rows() As DataRow
                For Each str As String In lstPlayers
                    fila = Me.dtMetasPlayer.NewRow()
                    fila("CodPlayer") = str
                    rows = dtResponse.Select("CodEmpleado='" & str & "'")
                    If rows.Length > 0 Then
                        fila("NombrePlayer") = CStr(rows(0)("NombreEmpleado"))
                    Else
                        fila("NombrePlayer") = ""
                    End If
                    fila("MetaDia") = 0
                    fila("APV") = 0
                    fila("Venta") = 0
                    fila("PorVender") = 0
                    fila("PorAtender") = 0
                    Me.dtMetasPlayer.Rows.Add(fila)
                Next
                Me.dtMetasPlayer.AcceptChanges()
            End If
        End If
    End Sub

    Private Function SetMetasDiariasPlayers(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim dtView As DataView = Nothing
        Dim codPlayer As String = "", total As Decimal = 0, apv As Decimal = 0, piezas As Decimal = 0, numFac As Integer = 0
        Dim porVender As Decimal = 0, porAtender As Decimal = 0, ventaPromedio As Decimal = 0, cantRest As Decimal = 0, metaPlayer As Decimal
        Dim meta As Hashtable = Nothing
        Dim lstMetasPlayers As ArrayList = MetaDiaPlayer.GetMetasDiasPlayers(FechaInicio, FechaFin)
        Dim dtResult As DataTable = MetaDiaPlayer.GetMetasVentas(oAppContext.ApplicationConfiguration.Almacen, FechaInicio, FechaFin)
        If lstMetasPlayers.Count > 0 And dtResult.Rows.Count > 0 Then
            Dim fila As DataRow = Nothing
            For Each row As DataRow In Me.dtMetasPlayer.Rows
                apv = 0
                cantRest = 0
                porVender = 0
                porAtender = 0
                codPlayer = CStr(row("CodPlayer"))
                If dtResult.Select("CodVendedor='" & codPlayer & "'").Length > 0 Then
                    meta = MetaDiaPlayer.GetSumaMetaPlayerByRange(codPlayer, FechaInicio, FechaFin)
                    If meta.ContainsKey("TieneMeta") AndAlso CBool(meta("TieneMeta")) = True Then
                        metaPlayer = CDec(meta("Meta"))
                        row("MetaDia") = metaPlayer
                        piezas = dtResult.Compute("SUM(Cantidad)", "CodVendedor='" & codPlayer & "'")
                        total = dtResult.Compute("SUM(Total)", "CodVendedor='" & codPlayer & "'")
                        numFac = dtResult.Compute("COUNT(CodVendedor)", "CodVendedor='" & codPlayer & "'")
                        If total > 0 Then
                            apv = piezas / numFac
                            ventaPromedio = total / numFac
                            cantRest = IIf(metaPlayer - total < 0, 0, metaPlayer - total)
                            porAtender = cantRest / ventaPromedio
                        End If
                    Else
                        row("MetaDia") = 0
                    End If
                    row("APV") = apv
                    row("Venta") = total
                    row("PorVender") = cantRest
                    row("PorAtender") = porAtender
                    row.AcceptChanges()
                End If
            Next
            Me.dtMetasPlayer.AcceptChanges()
            dtView = New DataView(Me.dtMetasPlayer, "", "MetaDia", DataViewRowState.CurrentRows)
            Me.dtMetasPlayer.AcceptChanges()
        End If
        Me.DataSource = dtView
    End Function
#End Region

End Class
