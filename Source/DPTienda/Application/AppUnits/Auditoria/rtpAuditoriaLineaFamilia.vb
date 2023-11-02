Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rtpAuditoriaLineaFamilia
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
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private txtCodLinea As TextBox = Nothing
	Private txtDesLinea As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Label22 As Label = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private Label23 As Label = Nothing
	Private TextBox15 As TextBox = Nothing
	Private TextBox16 As TextBox = Nothing
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
    Private txtCodProv As TextBox = Nothing
    Private TextBox7 As TextBox = Nothing
    Private TextBox9 As TextBox = Nothing
    Private Label21 As Label = Nothing
    Private Line1 As Line = Nothing
    Private Line3 As Line = Nothing
    Private Label20 As Label = Nothing
    Private TextBox10 As TextBox = Nothing
    Friend WithEvents txtCodSAP As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescripcion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox11 As DataDynamics.ActiveReports.TextBox
    Private TextBox12 As TextBox = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rtpAuditoriaLineaFamilia))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
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
        Me.txtCodProv = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodSAP = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
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
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.txtCodLinea = New DataDynamics.ActiveReports.TextBox()
        Me.txtDesLinea = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
        Me.Label23 = New DataDynamics.ActiveReports.Label()
        Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
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
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label18, Me.Label9, Me.txtTallas, Me.txtSistema, Me.txtFisico, Me.txtTSistema, Me.txtTFisico, Me.txtDiferencia, Me.txtCosto, Me.txtTCosto, Me.txtCodProv, Me.txtCodSAP, Me.txtDescripcion})
        Me.Detail.Height = 0.5376831!
        Me.Detail.Name = "Detail"
        '
        'Label18
        '
        Me.Label18.Height = 0.1250001!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 0.0000001192093!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.Label18.Text = "Fisico"
        Me.Label18.Top = 0.4064167!
        Me.Label18.Width = 0.9842521!
        '
        'Label9
        '
        Me.Label9.Height = 0.1250001!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0000001192093!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.Label9.Text = "Sistema"
        Me.Label9.Top = 0.271!
        Me.Label9.Width = 0.9842521!
        '
        'txtTallas
        '
        Me.txtTallas.DataField = "Tallas"
        Me.txtTallas.Height = 0.1281168!
        Me.txtTallas.Left = 1.39!
        Me.txtTallas.Name = "txtTallas"
        Me.txtTallas.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtTallas.Text = "Tallas"
        Me.txtTallas.Top = 0.14!
        Me.txtTallas.Width = 3.92496!
        '
        'txtSistema
        '
        Me.txtSistema.DataField = "Sistema"
        Me.txtSistema.Height = 0.1250001!
        Me.txtSistema.Left = 1.39!
        Me.txtSistema.Name = "txtSistema"
        Me.txtSistema.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtSistema.Text = "Cantidades Sistema"
        Me.txtSistema.Top = 0.271!
        Me.txtSistema.Width = 3.92496!
        '
        'txtFisico
        '
        Me.txtFisico.DataField = "Fisico"
        Me.txtFisico.Height = 0.1250001!
        Me.txtFisico.Left = 1.39!
        Me.txtFisico.Name = "txtFisico"
        Me.txtFisico.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtFisico.Text = "Cantidades Fisico"
        Me.txtFisico.Top = 0.4064167!
        Me.txtFisico.Width = 3.92496!
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
        Me.txtTSistema.Top = 0.2689495!
        Me.txtTSistema.Width = 0.328084!
        '
        'txtTFisico
        '
        Me.txtTFisico.DataField = "TFisico"
        Me.txtTFisico.Height = 0.1375!
        Me.txtTFisico.Left = 5.321195!
        Me.txtTFisico.Name = "txtTFisico"
        Me.txtTFisico.Style = "text-align: right; font-size: 8.25pt; font-family: Courier New; vertical-align: m" & _
    "iddle"
        Me.txtTFisico.Text = "9999"
        Me.txtTFisico.Top = 0.4001831!
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
        Me.txtDiferencia.Top = 0.2689495!
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
        Me.txtCosto.Top = 0.2689495!
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
        Me.txtTCosto.Top = 0.2689495!
        Me.txtTCosto.Width = 1.043635!
        '
        'txtCodProv
        '
        Me.txtCodProv.DataField = "CodProv"
        Me.txtCodProv.Height = 0.1312336!
        Me.txtCodProv.Left = 0.0!
        Me.txtCodProv.Name = "txtCodProv"
        Me.txtCodProv.Style = "font-weight: normal; font-size: 6.75pt; ddo-char-set: 0"
        Me.txtCodProv.Text = "AC-000432-2293"
        Me.txtCodProv.Top = 0.0!
        Me.txtCodProv.Width = 1.39!
        '
        'txtCodSAP
        '
        Me.txtCodSAP.DataField = "CodArticulo"
        Me.txtCodSAP.Height = 0.1312336!
        Me.txtCodSAP.Left = 0.0!
        Me.txtCodSAP.Name = "txtCodSAP"
        Me.txtCodSAP.Style = "font-weight: bold; font-size: 8.25pt"
        Me.txtCodSAP.Text = "AC-000432-2293"
        Me.txtCodSAP.Top = 0.138!
        Me.txtCodSAP.Width = 1.168635!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.1281168!
        Me.txtDescripcion.Left = 1.39!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-size: 8.25pt; font-family: Courier New; vertical-align: middle"
        Me.txtDescripcion.Text = "Descripcion"
        Me.txtDescripcion.Top = 0.012!
        Me.txtDescripcion.Width = 3.92496!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label20, Me.TextBox10, Me.TextBox12})
        Me.ReportFooter.Height = 0.15625!
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
        Me.PageHeader.Height = 0.4604167!
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
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.txtCodLinea, Me.txtDesLinea, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.Line2, Me.Label22, Me.TextBox13, Me.TextBox14, Me.Label23, Me.TextBox15, Me.TextBox16, Me.TextBox8, Me.TextBox11})
        Me.GroupHeader1.Height = 0.4055556!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'Label3
        '
        Me.Label3.Height = 0.1312336!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 4.96063!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8.25pt"
        Me.Label3.Text = "Linea:"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 0.3937007!
        '
        'txtCodLinea
        '
        Me.txtCodLinea.DataField = "CodLinea"
        Me.txtCodLinea.Height = 0.1312336!
        Me.txtCodLinea.Left = 5.354331!
        Me.txtCodLinea.Name = "txtCodLinea"
        Me.txtCodLinea.Style = "font-size: 8.25pt"
        Me.txtCodLinea.Text = Nothing
        Me.txtCodLinea.Top = 0.0!
        Me.txtCodLinea.Width = 0.4593177!
        '
        'txtDesLinea
        '
        Me.txtDesLinea.DataField = "DesLinea"
        Me.txtDesLinea.Height = 0.1312336!
        Me.txtDesLinea.Left = 5.816765!
        Me.txtDesLinea.Name = "txtDesLinea"
        Me.txtDesLinea.Style = "font-size: 8.25pt"
        Me.txtDesLinea.Text = Nothing
        Me.txtDesLinea.Top = 0.0!
        Me.txtDesLinea.Width = 1.706037!
        '
        'TextBox1
        '
        Me.TextBox1.Height = 0.1312336!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox1.Text = "Cod. Articulo"
        Me.TextBox1.Top = 0.262!
        Me.TextBox1.Width = 1.15!
        '
        'TextBox2
        '
        Me.TextBox2.Height = 0.1312336!
        Me.TextBox2.Left = 1.168252!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox2.Text = "Tallas"
        Me.TextBox2.Top = 0.262!
        Me.TextBox2.Width = 4.146708!
        '
        'TextBox3
        '
        Me.TextBox3.Height = 0.2622336!
        Me.TextBox3.Left = 5.321195!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox3.Text = "Total"
        Me.TextBox3.Top = 0.131!
        Me.TextBox3.Width = 0.3280845!
        '
        'TextBox4
        '
        Me.TextBox4.Height = 0.2622336!
        Me.TextBox4.Left = 5.649279!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox4.Text = "Dif."
        Me.TextBox4.Top = 0.131!
        Me.TextBox4.Width = 0.3280845!
        '
        'TextBox5
        '
        Me.TextBox5.Height = 0.2622336!
        Me.TextBox5.Left = 5.977362!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox5.Text = "Costo"
        Me.TextBox5.Top = 0.131!
        Me.TextBox5.Width = 0.7217846!
        '
        'TextBox6
        '
        Me.TextBox6.Height = 0.2622336!
        Me.TextBox6.Left = 6.699148!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox6.Text = "Costo Total"
        Me.TextBox6.Top = 0.131!
        Me.TextBox6.Width = 1.043635!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.006944458!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.400178!
        Me.Line2.Width = 7.742785!
        Me.Line2.X1 = 7.74973!
        Me.Line2.X2 = 0.006944458!
        Me.Line2.Y1 = 0.400178!
        Me.Line2.Y2 = 0.400178!
        '
        'Label22
        '
        Me.Label22.Height = 0.1312336!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 0.0!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "font-size: 8.25pt"
        Me.Label22.Text = "Familia:"
        Me.Label22.Top = 0.0!
        Me.Label22.Width = 0.4593174!
        '
        'TextBox13
        '
        Me.TextBox13.DataField = "CodFamilia"
        Me.TextBox13.Height = 0.1312336!
        Me.TextBox13.Left = 0.4593171!
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Style = "font-size: 8.25pt"
        Me.TextBox13.Text = Nothing
        Me.TextBox13.Top = 0.0!
        Me.TextBox13.Width = 0.3937005!
        '
        'TextBox14
        '
        Me.TextBox14.DataField = "DesFamilia"
        Me.TextBox14.Height = 0.1312336!
        Me.TextBox14.Left = 0.853018!
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Style = "font-size: 8.25pt"
        Me.TextBox14.Text = Nothing
        Me.TextBox14.Top = 0.0!
        Me.TextBox14.Width = 1.706037!
        '
        'Label23
        '
        Me.Label23.Height = 0.1312336!
        Me.Label23.HyperLink = Nothing
        Me.Label23.Left = 2.598425!
        Me.Label23.Name = "Label23"
        Me.Label23.Style = "font-size: 8.25pt"
        Me.Label23.Text = "Marca:"
        Me.Label23.Top = 0.0!
        Me.Label23.Width = 0.4593174!
        '
        'TextBox15
        '
        Me.TextBox15.DataField = "CodMarca"
        Me.TextBox15.Height = 0.1312336!
        Me.TextBox15.Left = 3.057742!
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Style = "font-size: 8.25pt"
        Me.TextBox15.Text = Nothing
        Me.TextBox15.Top = 0.0!
        Me.TextBox15.Width = 0.3937005!
        '
        'TextBox16
        '
        Me.TextBox16.DataField = "DesMarca"
        Me.TextBox16.Height = 0.1312336!
        Me.TextBox16.Left = 3.451444!
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Style = "font-size: 8.25pt"
        Me.TextBox16.Text = Nothing
        Me.TextBox16.Top = 0.0!
        Me.TextBox16.Width = 1.509187!
        '
        'TextBox8
        '
        Me.TextBox8.Height = 0.1312336!
        Me.TextBox8.Left = 9.313226E-10!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox8.Text = "Cod. Proveedor"
        Me.TextBox8.Top = 0.131!
        Me.TextBox8.Width = 1.15!
        '
        'TextBox11
        '
        Me.TextBox11.Height = 0.1312336!
        Me.TextBox11.Left = 1.168!
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Style = "text-align: center; font-size: 8.25pt"
        Me.TextBox11.Text = "Descripción"
        Me.TextBox11.Top = 0.131!
        Me.TextBox11.Width = 4.146709!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox7, Me.TextBox9, Me.Label21, Me.Line1, Me.Line3})
        Me.GroupFooter1.Height = 0.1451389!
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
        'rtpAuditoriaLineaFamilia
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
        Me.Sections.Add(Me.Detail)
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
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

	#End Region
End Class
