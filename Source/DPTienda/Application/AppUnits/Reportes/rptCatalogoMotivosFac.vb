Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptCatalogoMotivosFac
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal stralmacen As String, ByVal strTipoMovto As String)
        MyBase.New()
        InitializeComponent()
        Me.txtFechaReporte.Text = Now.Date.ToShortDateString
        Me.txtSucursal.Text = stralmacen
        Me.txtTipoMovto.Text = strTipoMovto
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label16 As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private txtTipoMovto As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label15 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCatalogoMotivosFac))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.txtTipoMovto = New DataDynamics.ActiveReports.TextBox()
            Me.Label17 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
            Me.Label15 = New DataDynamics.ActiveReports.Label()
            Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTipoMovto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodArticulo, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7})
            Me.Detail.Height = 0.1652778!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label16, Me.Label1, Me.Label2, Me.txtSucursal, Me.txtFechaReporte, Me.Label3, Me.Label4, Me.Label7, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.txtTipoMovto, Me.Label17, Me.Label18})
            Me.ReportHeader.Height = 1.052083!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0.07222223!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.tbPageNumber, Me.Label15, Me.tbPageCount})
            Me.PageFooter.Height = 0.2708333!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "ddo-char-set: 1; font-weight: bold"
            Me.Label16.Text = "Tipo Movto:"
            Me.Label16.Top = 0.472441!
            Me.Label16.Width = 0.8612201!
            '
            'Label1
            '
            Me.Label1.Height = 0.1999672!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.813484!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 14.25pt"
            Me.Label1.Text = "Reporte de Motivos de Captura Manual"
            Me.Label1.Top = 0!
            Me.Label1.Width = 5.860728!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; font-weight: bold"
            Me.Label2.Text = "Sucursal:"
            Me.Label2.Top = 0.2755906!
            Me.Label2.Width = 0.7217847!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 0.738025!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.2755906!
            Me.txtSucursal.Width = 3.927822!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 5.36319!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.Top = 0.3412074!
            Me.txtFechaReporte.Width = 1.332186!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 4.733268!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; font-weight: bold"
            Me.Label3.Text = "Fecha:"
            Me.Label3.Top = 0.3412074!
            Me.Label3.Width = 0.6299215!
            '
            'Label4
            '
            Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label4.Height = 0.3574803!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label4.Text = "Fecha"
            Me.Label4.Top = 0.6924215!
            Me.Label4.Width = 0.7760826!
            '
            'Label7
            '
            Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label7.Height = 0.3574803!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.919783!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label7.Text = "Talla"
            Me.Label7.Top = 0.6924215!
            Me.Label7.Width = 0.3636813!
            '
            'Label10
            '
            Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label10.Height = 0.3574803!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 2.283464!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic"& _ 
                "al-align: middle"
            Me.Label10.Text = "ID Motivo"
            Me.Label10.Top = 0.6924215!
            Me.Label10.Width = 0.4010833!
            '
            'Label11
            '
            Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label11.Height = 0.3574803!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 2.684547!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label11.Text = "Descripción del Motivo"
            Me.Label11.Top = 0.6924215!
            Me.Label11.Width = 2.706201!
            '
            'Label12
            '
            Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label12.Height = 0.3574803!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 5.390747!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label12.Text = "Folio ID"
            Me.Label12.Top = 0.6924215!
            Me.Label12.Width = 0.4104333!
            '
            'Label13
            '
            Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label13.Height = 0.3574803!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 0.7760826!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label13.Text = "Articulo"
            Me.Label13.Top = 0.6924215!
            Me.Label13.Width = 1.143701!
            '
            'txtTipoMovto
            '
            Me.txtTipoMovto.Height = 0.2!
            Me.txtTipoMovto.Left = 0.8120083!
            Me.txtTipoMovto.Name = "txtTipoMovto"
            Me.txtTipoMovto.Top = 0.472441!
            Me.txtTipoMovto.Width = 3.832186!
            '
            'Label17
            '
            Me.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label17.Height = 0.3574803!
            Me.Label17.HyperLink = Nothing
            Me.Label17.Left = 5.810531!
            Me.Label17.Name = "Label17"
            Me.Label17.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label17.Text = "Tipo Movto"
            Me.Label17.Top = 0.6924215!
            Me.Label17.Width = 0.4729333!
            '
            'Label18
            '
            Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label18.Height = 0.3574803!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 6.288386!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
            Me.Label18.Text = "Codigo UPC"
            Me.Label18.Top = 0.6924215!
            Me.Label18.Width = 1.306102!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtCodArticulo.DataField = "Fecha"
            Me.txtCodArticulo.Height = 0.1653543!
            Me.txtCodArticulo.Left = 0!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.OutputFormat = resources.GetString("txtCodArticulo.OutputFormat")
            Me.txtCodArticulo.Style = "font-weight: normal; font-size: 8.25pt"
            Me.txtCodArticulo.Top = 0!
            Me.txtCodArticulo.Width = 0.7760826!
            '
            'TextBox1
            '
            Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox1.DataField = "Articulo"
            Me.TextBox1.Height = 0.1653543!
            Me.TextBox1.Left = 0.7760826!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 1.143701!
            '
            'TextBox2
            '
            Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox2.DataField = "Talla"
            Me.TextBox2.Height = 0.1653543!
            Me.TextBox2.Left = 1.919783!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.3636813!
            '
            'TextBox3
            '
            Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox3.DataField = "IdMotivo"
            Me.TextBox3.Height = 0.1653543!
            Me.TextBox3.Left = 2.283464!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.4010833!
            '
            'TextBox4
            '
            Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox4.DataField = "Descripcion"
            Me.TextBox4.Height = 0.1653543!
            Me.TextBox4.Left = 2.684547!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "font-weight: normal; font-size: 8.25pt"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 2.706201!
            '
            'TextBox5
            '
            Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox5.DataField = "facturaid"
            Me.TextBox5.Height = 0.1653543!
            Me.TextBox5.Left = 5.390747!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.4104333!
            '
            'TextBox6
            '
            Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox6.DataField = "tipomovto"
            Me.TextBox6.Height = 0.1653543!
            Me.TextBox6.Left = 5.810531!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.4729333!
            '
            'TextBox7
            '
            Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox7.DataField = "codupc"
            Me.TextBox7.Height = 0.1653543!
            Me.TextBox7.Left = 6.288386!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.TextBox7.Top = 0!
            Me.TextBox7.Width = 1.306102!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 5.125!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
            Me.Label14.Text = "Página"
            Me.Label14.Top = 0.0625!
            Me.Label14.Width = 0.5078735!
            '
            'tbPageNumber
            '
            Me.tbPageNumber.Height = 0.2!
            Me.tbPageNumber.Left = 5.679626!
            Me.tbPageNumber.Name = "tbPageNumber"
            Me.tbPageNumber.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageNumber.Text = "####"
            Me.tbPageNumber.Top = 0.0625!
            Me.tbPageNumber.Width = 0.492126!
            '
            'Label15
            '
            Me.Label15.Height = 0.2!
            Me.Label15.HyperLink = Nothing
            Me.Label15.Left = 6.17175!
            Me.Label15.Name = "Label15"
            Me.Label15.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label15.Text = "de"
            Me.Label15.Top = 0.0625!
            Me.Label15.Width = 0.2952757!
            '
            'tbPageCount
            '
            Me.tbPageCount.Height = 0.2!
            Me.tbPageCount.Left = 6.529528!
            Me.tbPageCount.Name = "tbPageCount"
            Me.tbPageCount.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageCount.Text = "####"
            Me.tbPageCount.Top = 0.0625!
            Me.tbPageCount.Width = 0.492126!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.4097222!
            Me.PageSettings.Margins.Top = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.614583!
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
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTipoMovto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
