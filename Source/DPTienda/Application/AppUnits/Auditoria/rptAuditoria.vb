Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptAuditoria
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
        InitializeComponent()

        Me.txtFechaReporte.Text = Now
        Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen()

	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents GroupHeader2 As GroupHeader = Nothing
    Private WithEvents GroupHeader3 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter3 As GroupFooter = Nothing
    Private WithEvents GroupFooter2 As GroupFooter = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private Label22 As Label = Nothing
	Private TextBox17 As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private Label23 As Label = Nothing
	Private TextBox19 As TextBox = Nothing
	Private TextBox20 As TextBox = Nothing
	Private TextBox21 As TextBox = Nothing
	Private TextBox22 As TextBox = Nothing
	Private TextBox23 As TextBox = Nothing
	Private TextBox24 As TextBox = Nothing
	Private TextBox25 As TextBox = Nothing
	Private TextBox26 As TextBox = Nothing
	Private Line4 As Line = Nothing
	Private Label24 As Label = Nothing
    Private txtCodProv As TextBox = Nothing
    Private Label18 As Label = Nothing
    Private Label9 As Label = Nothing
    Private txtTallas As TextBox = Nothing
    Private txtSistema As TextBox = Nothing
    Private txtFisico As TextBox = Nothing
    Private txtTSistema As TextBox = Nothing
    Private txtTFisico As TextBox = Nothing
    Private txtDiferencia As TextBox = Nothing
    Private txtCosto As TextBox = Nothing
    Private txtTCosto As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox9 As TextBox = Nothing
    Private Label21 As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line3 As Line = Nothing
    Private Label20 As Label = Nothing
    Private TextBox10 As TextBox = Nothing
    Friend WithEvents txtCodSAP As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Private TextBox12 As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAuditoria))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtCodProv = New DataDynamics.ActiveReports.TextBox()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtTallas = New DataDynamics.ActiveReports.TextBox()
        Me.txtSistema = New DataDynamics.ActiveReports.TextBox()
        Me.txtFisico = New DataDynamics.ActiveReports.TextBox()
        Me.txtTSistema = New DataDynamics.ActiveReports.TextBox()
        Me.txtTFisico = New DataDynamics.ActiveReports.TextBox()
        Me.txtDiferencia = New DataDynamics.ActiveReports.TextBox()
        Me.txtCosto = New DataDynamics.ActiveReports.TextBox()
        Me.txtTCosto = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodSAP = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader()
        Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox23 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox25 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox26 = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Label24 = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFisico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTFisico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodProv, Me.Label18, Me.Label9, Me.txtTallas, Me.txtSistema, Me.txtFisico, Me.txtTSistema, Me.txtTFisico, Me.txtDiferencia, Me.txtCosto, Me.txtTCosto, Me.txtCodSAP, Me.TextBox1})
        Me.Detail.Height = 0.6527665!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        '
        'txtCodProv
        '
        Me.txtCodProv.DataField = "CodProv"
        Me.txtCodProv.Height = 0.1312336!
        Me.txtCodProv.Left = 0.0!
        Me.txtCodProv.Name = "txtCodProv"
        Me.txtCodProv.Style = "font-weight: normal; font-size: 6.75pt"
        Me.txtCodProv.Text = "AC-000432-2293"
        Me.txtCodProv.Top = 0.0!
        Me.txtCodProv.Width = 1.39!
        '
        'Label18
        '
        Me.Label18.Height = 0.1250001!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.0!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.Label18.Text = "Fisico"
        Me.Label18.Top = 0.509!
        Me.Label18.Width = 0.9842521!
        '
        'Label9
        '
        Me.Label9.Height = 0.1250001!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.Label9.Text = "Sistema"
        Me.Label9.Top = 0.3235833!
        Me.Label9.Width = 0.9842521!
        '
        'txtTallas
        '
        Me.txtTallas.DataField = "Descripcion"
        Me.txtTallas.Height = 0.138!
        Me.txtTallas.Left = 1.389748!
        Me.txtTallas.Name = "txtTallas"
        Me.txtTallas.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtTallas.Text = "Descripcion"
        Me.txtTallas.Top = 0.0!
        Me.txtTallas.Width = 3.924961!
        '
        'txtSistema
        '
        Me.txtSistema.CanShrink = True
        Me.txtSistema.DataField = "Sistema"
        Me.txtSistema.Height = 0.1250001!
        Me.txtSistema.Left = 1.389748!
        Me.txtSistema.Name = "txtSistema"
        Me.txtSistema.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtSistema.Text = "Cantidades Sistema"
        Me.txtSistema.Top = 0.322!
        Me.txtSistema.Width = 3.924961!
        '
        'txtFisico
        '
        Me.txtFisico.CanShrink = True
        Me.txtFisico.DataField = "Fisico"
        Me.txtFisico.Height = 0.1250001!
        Me.txtFisico.Left = 1.39!
        Me.txtFisico.Name = "txtFisico"
        Me.txtFisico.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtFisico.Text = "Cantidades Fisico"
        Me.txtFisico.Top = 0.509!
        Me.txtFisico.Width = 3.924961!
        '
        'txtTSistema
        '
        Me.txtTSistema.DataField = "TSistema"
        Me.txtTSistema.Height = 0.1375!
        Me.txtTSistema.Left = 5.321195!
        Me.txtTSistema.Name = "txtTSistema"
        Me.txtTSistema.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtTSistema.Text = "9999"
        Me.txtTSistema.Top = 0.3215328!
        Me.txtTSistema.Width = 0.328084!
        '
        'txtTFisico
        '
        Me.txtTFisico.DataField = "TFisico"
        Me.txtTFisico.Height = 0.1375!
        Me.txtTFisico.Left = 5.315!
        Me.txtTFisico.Name = "txtTFisico"
        Me.txtTFisico.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtTFisico.Text = "9999"
        Me.txtTFisico.Top = 0.509!
        Me.txtTFisico.Width = 0.328084!
        '
        'txtDiferencia
        '
        Me.txtDiferencia.DataField = "Diferencia"
        Me.txtDiferencia.Height = 0.1375!
        Me.txtDiferencia.Left = 5.649278!
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtDiferencia.Text = "9999"
        Me.txtDiferencia.Top = 0.3215328!
        Me.txtDiferencia.Width = 0.328084!
        '
        'txtCosto
        '
        Me.txtCosto.DataField = "Costo"
        Me.txtCosto.Height = 0.1375!
        Me.txtCosto.Left = 5.977362!
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.OutputFormat = resources.GetString("txtCosto.OutputFormat")
        Me.txtCosto.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtCosto.Text = "$20,000.00"
        Me.txtCosto.Top = 0.3215328!
        Me.txtCosto.Width = 0.7217847!
        '
        'txtTCosto
        '
        Me.txtTCosto.DataField = "TCosto"
        Me.txtTCosto.Height = 0.1375!
        Me.txtTCosto.Left = 6.699148!
        Me.txtTCosto.Name = "txtTCosto"
        Me.txtTCosto.OutputFormat = resources.GetString("txtTCosto.OutputFormat")
        Me.txtTCosto.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtTCosto.Text = "$11,987,879.00"
        Me.txtTCosto.Top = 0.3215328!
        Me.txtTCosto.Width = 1.043635!
        '
        'txtCodSAP
        '
        Me.txtCodSAP.DataField = "CodArticulo"
        Me.txtCodSAP.Height = 0.1312336!
        Me.txtCodSAP.Left = 0.0!
        Me.txtCodSAP.Name = "txtCodSAP"
        Me.txtCodSAP.Style = "font-weight: bold; font-size: 8.25pt"
        Me.txtCodSAP.Text = "AC-000432-2293"
        Me.txtCodSAP.Top = 0.153!
        Me.txtCodSAP.Width = 1.172!
        '
        'TextBox1
        '
        Me.TextBox1.CanShrink = True
        Me.TextBox1.DataField = "Tallas"
        Me.TextBox1.Height = 0.128!
        Me.TextBox1.Left = 1.389748!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.TextBox1.Text = "Tallas"
        Me.TextBox1.Top = 0.156!
        Me.TextBox1.Width = 4.029252!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label20, Me.TextBox10, Me.TextBox12})
        Me.ReportFooter.Height = 0.25!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label20
        '
        Me.Label20.Height = 0.1312336!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 4.602527!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label20.Text = "Total Auditoria"
        Me.Label20.Top = 0.0!
        Me.Label20.Width = 0.8978834!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "Diferencia"
        Me.TextBox10.Height = 0.1375!
        Me.TextBox10.Left = 5.51181!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.TextBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox10.Text = "9999"
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.4655514!
        '
        'TextBox12
        '
        Me.TextBox12.DataField = "TCosto"
        Me.TextBox12.Height = 0.1375!
        Me.TextBox12.Left = 6.699148!
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
        Me.TextBox12.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox12.Text = "$11,987,879.00"
        Me.TextBox12.Top = 0.0!
        Me.TextBox12.Width = 1.043634!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.txtFechaReporte, Me.Label2, Me.txtSucursal})
        Me.PageHeader.Height = 0.5!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.2624672!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.474901!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 14.25pt"
        Me.Label1.Text = "Resultado de Auditoria"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.362204!
        '
        'txtFechaReporte
        '
        Me.txtFechaReporte.Height = 0.2!
        Me.txtFechaReporte.Left = 4.843175!
        Me.txtFechaReporte.Name = "txtFechaReporte"
        Me.txtFechaReporte.Text = Nothing
        Me.txtFechaReporte.Top = 0.0656168!
        Me.txtFechaReporte.Width = 2.559055!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 1.115485!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = ""
        Me.Label2.Text = "Sucursal.-"
        Me.Label2.Top = 0.2624672!
        Me.Label2.Width = 0.7217847!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 1.902887!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Text = "TextBox1"
        Me.txtSucursal.Top = 0.2624672!
        Me.txtSucursal.Width = 4.396325!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox13, Me.TextBox14, Me.Label22})
        Me.GroupHeader1.DataField = "CodFamilia"
        Me.GroupHeader1.Height = 0.15625!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before
        '
        'TextBox13
        '
        Me.TextBox13.DataField = "DesFamilia"
        Me.TextBox13.Height = 0.1312336!
        Me.TextBox13.Left = 1.102362!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "font-size: 8.25pt"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Width = 3.858267!
        '
        'TextBox14
        '
        Me.TextBox14.DataField = "CodFamilia"
        Me.TextBox14.Height = 0.1312336!
        Me.TextBox14.Left = 0.6299213!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 8.25pt"
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.0!
        Me.TextBox14.Width = 0.4593177!
        '
        'Label22
        '
        Me.Label22.Height = 0.1312336!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.0!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-size: 8.25pt"
        Me.Label22.Text = "Familia.-"
        Me.Label22.Top = 0.0!
        Me.Label22.Width = 0.6299213!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox7, Me.TextBox9, Me.Label21, Me.Line1, Me.Line3})
        Me.GroupFooter1.Height = 0.1451389!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "Diferencia"
        Me.TextBox7.Height = 0.1375!
        Me.TextBox7.Left = 5.51181!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.TextBox7.SummaryGroup = "GroupHeader1"
        Me.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox7.Text = "9999"
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.4655514!
        '
        'TextBox9
        '
        Me.TextBox9.DataField = "TCosto"
        Me.TextBox9.Height = 0.1375!
        Me.TextBox9.Left = 6.699148!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat")
        Me.TextBox9.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.TextBox9.SummaryGroup = "GroupHeader1"
        Me.TextBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox9.Text = "$11,987,879.00"
        Me.TextBox9.Top = 0.0!
        Me.TextBox9.Width = 1.043634!
        '
        'Label21
        '
        Me.Label21.Height = 0.1312336!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 4.799377!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "font-weight: bold; font-size: 8.25pt"
        Me.Label21.Text = "Total Linea"
        Me.Label21.Top = 0.0!
        Me.Label21.Width = 0.7010333!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.1312336!
        Me.Line1.Width = 7.742785!
        Me.Line1.X1 = 7.742785!
        Me.Line1.X2 = 0.0!
        Me.Line1.Y1 = 0.1312336!
        Me.Line1.Y2 = 0.1312336!
        '
        'Line3
        '
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.006944444!
        Me.Line3.Width = 7.742785!
        Me.Line3.X1 = 7.742785!
        Me.Line3.X2 = 0.0!
        Me.Line3.Y1 = 0.006944444!
        Me.Line3.Y2 = 0.006944444!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox17, Me.TextBox18, Me.Label23})
        Me.GroupHeader2.DataField = "CodMarca"
        Me.GroupHeader2.Height = 0.15625!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'TextBox17
        '
        Me.TextBox17.DataField = "CodMarca"
        Me.TextBox17.Height = 0.1312336!
        Me.TextBox17.Left = 0.6299213!
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Style = "font-size: 8.25pt"
        Me.TextBox17.Text = Nothing
        Me.TextBox17.Top = 0.0!
        Me.TextBox17.Width = 0.4593177!
        '
        'TextBox18
        '
        Me.TextBox18.DataField = "DesMarca"
        Me.TextBox18.Height = 0.1312336!
        Me.TextBox18.Left = 1.102362!
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Style = "font-size: 8.25pt"
        Me.TextBox18.Text = Nothing
        Me.TextBox18.Top = 0.0!
        Me.TextBox18.Width = 3.858267!
        '
        'Label23
        '
        Me.Label23.Height = 0.1312336!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 0.0!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-size: 8.25pt"
        Me.Label23.Text = "Marca.-"
        Me.Label23.Top = 0.0!
        Me.Label23.Width = 0.6299213!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.25!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.TextBox22, Me.TextBox23, Me.TextBox24, Me.TextBox25, Me.TextBox26, Me.Line4, Me.Label24, Me.TextBox2, Me.TextBox3})
        Me.GroupHeader3.DataField = "CodLinea"
        Me.GroupHeader3.Height = 0.4173838!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'TextBox19
        '
        Me.TextBox19.DataField = "CodLinea"
        Me.TextBox19.Height = 0.1312336!
        Me.TextBox19.Left = 0.6299213!
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Style = "font-size: 8.25pt"
        Me.TextBox19.Text = Nothing
        Me.TextBox19.Top = 0.0!
        Me.TextBox19.Width = 0.4593177!
        '
        'TextBox20
        '
        Me.TextBox20.DataField = "DesLinea"
        Me.TextBox20.Height = 0.1312336!
        Me.TextBox20.Left = 1.089238!
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Style = "font-size: 8.25pt"
        Me.TextBox20.Text = Nothing
        Me.TextBox20.Top = 0.0!
        Me.TextBox20.Width = 3.871392!
        '
        'TextBox21
        '
        Me.TextBox21.Height = 0.1312336!
        Me.TextBox21.Left = 0.0!
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox21.Text = "Cod. Padre"
        Me.TextBox21.Top = 0.268!
        Me.TextBox21.Width = 1.173!
        '
        'TextBox22
        '
        Me.TextBox22.Height = 0.1312336!
        Me.TextBox22.Left = 1.173!
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox22.Text = "Tallas"
        Me.TextBox22.Top = 0.268!
        Me.TextBox22.Width = 4.141961!
        '
        'TextBox23
        '
        Me.TextBox23.Height = 0.2622336!
        Me.TextBox23.Left = 5.321195!
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox23.Text = "Total"
        Me.TextBox23.Top = 0.137!
        Me.TextBox23.Width = 0.3280845!
        '
        'TextBox24
        '
        Me.TextBox24.Height = 0.2622336!
        Me.TextBox24.Left = 5.649279!
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox24.Text = "Dif."
        Me.TextBox24.Top = 0.137!
        Me.TextBox24.Width = 0.3280845!
        '
        'TextBox25
        '
        Me.TextBox25.Height = 0.2622336!
        Me.TextBox25.Left = 5.977362!
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox25.Text = "Costo"
        Me.TextBox25.Top = 0.137!
        Me.TextBox25.Width = 0.7217846!
        '
        'TextBox26
        '
        Me.TextBox26.Height = 0.2622336!
        Me.TextBox26.Left = 6.699148!
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox26.Text = "Costo Total"
        Me.TextBox26.Top = 0.137!
        Me.TextBox26.Width = 1.043635!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.007214825!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.41!
        Me.Line4.Width = 7.742785!
        Me.Line4.X1 = 7.75!
        Me.Line4.X2 = 0.007214825!
        Me.Line4.Y1 = 0.41!
        Me.Line4.Y2 = 0.41!
        '
        'Label24
        '
        Me.Label24.Height = 0.1312336!
        Me.Label24.HyperLink = Nothing
        Me.Label24.Left = 0.0!
        Me.Label24.Name = "Label24"
        Me.Label24.Style = "font-size: 8.25pt"
        Me.Label24.Text = "Linea.-"
        Me.Label24.Top = 0.0!
        Me.Label24.Width = 0.6299213!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.1312336!
        Me.TextBox2.Left = 1.172748!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox2.Text = "Descripción"
        Me.TextBox2.Top = 0.131!
        Me.TextBox2.Width = 4.141961!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.1312336!
        Me.TextBox3.Left = 0.0!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox3.Text = "Cod. Proveedor"
        Me.TextBox3.Top = 0.137!
        Me.TextBox3.Width = 1.173!
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Height = 0.25!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'rptAuditoria
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.39375!
        Me.PageSettings.Margins.Left = 0.39375!
        Me.PageSettings.Margins.Right = 0.03958333!
        Me.PageSettings.Margins.Top = 0.39375!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.75!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFisico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTFisico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

	#End Region



    
End Class
