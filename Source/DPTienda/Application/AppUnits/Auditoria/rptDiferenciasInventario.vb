Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptDiferenciasInventario
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Filtro As String)
        MyBase.New()
        InitializeComponent()
        Me.txtFechaReporte.Text = Now
        Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen
        Me.lblMarFamLin.Text = Filtro
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label22 As Label = Nothing
	Private lblMarFamLin As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line13 As Line = Nothing
	Private Line16 As Line = Nothing
	Private Line17 As Line = Nothing
	Private Line19 As Line = Nothing
	Private TextBox10 As TextBox = Nothing
	Private Line22 As Line = Nothing
	Private Label20 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label21 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Line21 As Line = Nothing
	Private Label14 As Label = Nothing
	Private Label15 As Label = Nothing
	Private Label16 As Label = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private Label17 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private Line2 As Line = Nothing
	Private Line20 As Line = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDiferenciasInventario))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.Line16 = New DataDynamics.ActiveReports.Line()
        Me.Line17 = New DataDynamics.ActiveReports.Line()
        Me.Line19 = New DataDynamics.ActiveReports.Line()
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
        Me.Line22 = New DataDynamics.ActiveReports.Line()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label14 = New DataDynamics.ActiveReports.Label()
        Me.Label15 = New DataDynamics.ActiveReports.Label()
        Me.Label16 = New DataDynamics.ActiveReports.Label()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
        Me.Label17 = New DataDynamics.ActiveReports.Label()
        Me.Label18 = New DataDynamics.ActiveReports.Label()
        Me.Label19 = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line20 = New DataDynamics.ActiveReports.Line()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.Label22 = New DataDynamics.ActiveReports.Label()
        Me.lblMarFamLin = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Label20 = New DataDynamics.ActiveReports.Label()
        Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
        Me.Label21 = New DataDynamics.ActiveReports.Label()
        Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
        Me.Line21 = New DataDynamics.ActiveReports.Line()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMarFamLin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox1, Me.txtCodArticulo, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.Line4, Me.Line5, Me.Line9, Me.Line10, Me.Line13, Me.Line16, Me.Line17, Me.Line19, Me.TextBox10, Me.Line22})
        Me.Detail.Height = 0.1652778!
        Me.Detail.Name = "Detail"
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "Entrada"
        Me.TextBox2.Height = 0.1653543!
        Me.TextBox2.Left = 1.732283!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox2.Text = "entrada"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.5511813!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "Piezas1"
        Me.TextBox1.Height = 0.1653543!
        Me.TextBox1.Left = 1.338583!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox1.Text = "piezas1"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 0.3937007!
        '
        'txtCodArticulo
        '
        Me.txtCodArticulo.DataField = "CodArticulo1"
        Me.txtCodArticulo.Height = 0.1653543!
        Me.txtCodArticulo.Left = 0.07874014!
        Me.txtCodArticulo.Name = "txtCodArticulo"
        Me.txtCodArticulo.Style = "font-weight: normal; font-size: 8.25pt"
        Me.txtCodArticulo.Text = "Codigo"
        Me.txtCodArticulo.Top = 0.0!
        Me.txtCodArticulo.Width = 1.259842!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "CodArticulo2"
        Me.TextBox3.Height = 0.1653543!
        Me.TextBox3.Left = 2.362205!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-weight: normal; font-size: 8.25pt"
        Me.TextBox3.Text = "codigo"
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 1.259842!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "Piezas2"
        Me.TextBox4.Height = 0.1653543!
        Me.TextBox4.Left = 3.622047!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox4.Text = "piezas2"
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.3937007!
        '
        'TextBox5
        '
        Me.TextBox5.DataField = "salida"
        Me.TextBox5.Height = 0.1653543!
        Me.TextBox5.Left = 4.015747!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox5.Text = "salida"
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.5354331!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "Descripcion"
        Me.TextBox6.Height = 0.1653543!
        Me.TextBox6.Left = 4.645669!
        Me.TextBox6.MultiLine = False
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Style = "font-weight: normal; font-size: 8.25pt"
        Me.TextBox6.Text = "Descripcion"
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 1.653543!
        '
        'Line4
        '
        Me.Line4.Height = 0.1653543!
        Me.Line4.Left = 0.0!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 0.0!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.1653543!
        '
        'Line5
        '
        Me.Line5.Height = 0.1653543!
        Me.Line5.Left = 1.732283!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 1.732283!
        Me.Line5.X2 = 1.732283!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.1653543!
        '
        'Line9
        '
        Me.Line9.Height = 0.1653543!
        Me.Line9.Left = 2.283465!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 2.283465!
        Me.Line9.X2 = 2.283465!
        Me.Line9.Y1 = 0.0!
        Me.Line9.Y2 = 0.1653543!
        '
        'Line10
        '
        Me.Line10.Height = 0.1653543!
        Me.Line10.Left = 1.338583!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 1.338583!
        Me.Line10.X2 = 1.338583!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.1653543!
        '
        'Line13
        '
        Me.Line13.Height = 0.1653543!
        Me.Line13.Left = 4.566929!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.0!
        Me.Line13.Width = 0.0!
        Me.Line13.X1 = 4.566929!
        Me.Line13.X2 = 4.566929!
        Me.Line13.Y1 = 0.0!
        Me.Line13.Y2 = 0.1653543!
        '
        'Line16
        '
        Me.Line16.Height = 0.1653543!
        Me.Line16.Left = 3.622047!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.0!
        Me.Line16.Width = 0.0!
        Me.Line16.X1 = 3.622047!
        Me.Line16.X2 = 3.622047!
        Me.Line16.Y1 = 0.0!
        Me.Line16.Y2 = 0.1653543!
        '
        'Line17
        '
        Me.Line17.Height = 0.1653543!
        Me.Line17.Left = 7.007875!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.0!
        Me.Line17.Width = 0.0!
        Me.Line17.X1 = 7.007875!
        Me.Line17.X2 = 7.007875!
        Me.Line17.Y1 = 0.0!
        Me.Line17.Y2 = 0.1653543!
        '
        'Line19
        '
        Me.Line19.Height = 0.1653543!
        Me.Line19.Left = 4.015747!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 4.015747!
        Me.Line19.X2 = 4.015747!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.1653543!
        '
        'TextBox10
        '
        Me.TextBox10.DataField = "Costo"
        Me.TextBox10.Height = 0.1653543!
        Me.TextBox10.Left = 6.299212!
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat")
        Me.TextBox10.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
        Me.TextBox10.Text = "Costo"
        Me.TextBox10.Top = 0.0!
        Me.TextBox10.Width = 0.7086618!
        '
        'Line22
        '
        Me.Line22.Height = 0.1653543!
        Me.Line22.Left = 6.299212!
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 0.0!
        Me.Line22.Width = 0.0!
        Me.Line22.X1 = 6.299212!
        Me.Line22.X2 = 6.299212!
        Me.Line22.Y1 = 0.0!
        Me.Line22.Y2 = 0.1653543!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label14, Me.Label15, Me.Label16, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.Label17, Me.Label18, Me.Label19, Me.Line2, Me.Line20})
        Me.ReportFooter.Height = 1.020833!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label14
        '
        Me.Label14.Height = 0.2!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.0!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label14.Text = "Total Sistema:"
        Me.Label14.Top = 0.1574803!
        Me.Label14.Width = 1.023622!
        '
        'Label15
        '
        Me.Label15.Height = 0.2!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 0.0!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label15.Text = "Total Leidos:"
        Me.Label15.Top = 0.3937007!
        Me.Label15.Width = 1.023622!
        '
        'Label16
        '
        Me.Label16.Height = 0.2!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.0!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label16.Text = "Diferencia:"
        Me.Label16.Top = 0.6299214!
        Me.Label16.Width = 0.7480313!
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "TSistema"
        Me.TextBox7.Height = 0.2!
        Me.TextBox7.Left = 1.030567!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
        Me.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox7.Text = "total"
        Me.TextBox7.Top = 0.1574803!
        Me.TextBox7.Width = 0.7874014!
        '
        'TextBox8
        '
        Me.TextBox8.DataField = "TFisico"
        Me.TextBox8.Height = 0.2!
        Me.TextBox8.Left = 1.030567!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
        Me.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox8.Text = "leidos"
        Me.TextBox8.Top = 0.3937007!
        Me.TextBox8.Width = 0.7874014!
        '
        'TextBox9
        '
        Me.TextBox9.DataField = "diferencia"
        Me.TextBox9.Height = 0.2!
        Me.TextBox9.Left = 1.030567!
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Style = "text-align: right; font-weight: normal; font-size: 8.25pt"
        Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox9.Text = "dif"
        Me.TextBox9.Top = 0.6299213!
        Me.TextBox9.Width = 0.7874014!
        '
        'Label17
        '
        Me.Label17.Height = 0.2!
        Me.Label17.HyperLink = Nothing
        Me.Label17.Left = 1.896708!
        Me.Label17.Name = "Label17"
        Me.Label17.Style = "ddo-char-set: 1; font-weight: normal"
        Me.Label17.Text = "pares"
        Me.Label17.Top = 0.1574803!
        Me.Label17.Width = 0.551181!
        '
        'Label18
        '
        Me.Label18.Height = 0.2!
        Me.Label18.HyperLink = Nothing
        Me.Label18.Left = 1.896708!
        Me.Label18.Name = "Label18"
        Me.Label18.Style = "ddo-char-set: 1; font-weight: normal"
        Me.Label18.Text = "pares"
        Me.Label18.Top = 0.3937007!
        Me.Label18.Width = 0.551181!
        '
        'Label19
        '
        Me.Label19.Height = 0.2!
        Me.Label19.HyperLink = Nothing
        Me.Label19.Left = 1.896708!
        Me.Label19.Name = "Label19"
        Me.Label19.Style = "ddo-char-set: 1; font-weight: normal"
        Me.Label19.Text = "pares"
        Me.Label19.Top = 0.6299213!
        Me.Label19.Width = 0.551181!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 1.030567!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.6102362!
        Me.Line2.Width = 0.7874019!
        Me.Line2.X1 = 1.030567!
        Me.Line2.X2 = 1.817969!
        Me.Line2.Y1 = 0.6102362!
        Me.Line2.Y2 = 0.6102362!
        '
        'Line20
        '
        Me.Line20.Height = 5.866598E-9!
        Me.Line20.Left = 0.0!
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 0.0!
        Me.Line20.Width = 7.007875!
        Me.Line20.X1 = 0.0!
        Me.Line20.X2 = 7.007875!
        Me.Line20.Y1 = 0.0!
        Me.Line20.Y2 = 5.866598E-9!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.txtSucursal, Me.txtFechaReporte, Me.Label3, Me.Label4, Me.Label7, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.Label13, Me.Label22, Me.lblMarFamLin})
        Me.PageHeader.Height = 1.25!
        Me.PageHeader.Name = "PageHeader"
        '
        'Label1
        '
        Me.Label1.Height = 0.2624672!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 2.125984!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 14.25pt"
        Me.Label1.Text = "Diferencias de Inventario"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.485729!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label2.Text = "Sucursal:"
        Me.Label2.Top = 0.5962106!
        Me.Label2.Width = 0.7217847!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.2!
        Me.txtSucursal.Left = 0.800525!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Text = "TextBox1"
        Me.txtSucursal.Top = 0.5912074!
        Me.txtSucursal.Width = 2.900262!
        '
        'txtFechaReporte
        '
        Me.txtFechaReporte.Height = 0.2!
        Me.txtFechaReporte.Left = 4.48819!
        Me.txtFechaReporte.Name = "txtFechaReporte"
        Me.txtFechaReporte.Text = Nothing
        Me.txtFechaReporte.Top = 0.5912074!
        Me.txtFechaReporte.Width = 2.519685!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 3.858268!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 1; font-weight: bold"
        Me.Label3.Text = "Fecha:"
        Me.Label3.Top = 0.5912074!
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
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label4.Text = "Código"
        Me.Label4.Top = 0.8799216!
        Me.Label4.Width = 1.338583!
        '
        'Label7
        '
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label7.Height = 0.3574803!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 1.732283!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label7.Text = "Entrada Talla"
        Me.Label7.Top = 0.8799216!
        Me.Label7.Width = 0.5511813!
        '
        'Label9
        '
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.3574803!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 4.566929!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label9.Text = "Descripción Material"
        Me.Label9.Top = 0.8799216!
        Me.Label9.Width = 1.732283!
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
        Me.Label10.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label10.Text = "Código"
        Me.Label10.Top = 0.8799216!
        Me.Label10.Width = 1.338583!
        '
        'Label11
        '
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.3574803!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 3.622047!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label11.Text = "No. Pzas"
        Me.Label11.Top = 0.8799216!
        Me.Label11.Width = 0.3937007!
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.3574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 4.015747!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label12.Text = "Salida Talla"
        Me.Label12.Top = 0.8799216!
        Me.Label12.Width = 0.5354331!
        '
        'Label13
        '
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.3574803!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 1.338583!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label13.Text = "No. Pzas"
        Me.Label13.Top = 0.8799216!
        Me.Label13.Width = 0.3937007!
        '
        'Label22
        '
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label22.Height = 0.3574803!
        Me.Label22.HyperLink = Nothing
        Me.Label22.Left = 6.299212!
        Me.Label22.Name = "Label22"
        Me.Label22.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; vertical-align: middle"
        Me.Label22.Text = "Costo. Unitario."
        Me.Label22.Top = 0.8799216!
        Me.Label22.Width = 0.7086618!
        '
        'lblMarFamLin
        '
        Me.lblMarFamLin.Height = 0.2!
        Me.lblMarFamLin.HyperLink = Nothing
        Me.lblMarFamLin.Left = 0.2250984!
        Me.lblMarFamLin.Name = "lblMarFamLin"
        Me.lblMarFamLin.Style = "ddo-char-set: 1; text-align: center; font-weight: bold"
        Me.lblMarFamLin.Text = ""
        Me.lblMarFamLin.Top = 0.2837106!
        Me.lblMarFamLin.Width = 6.2875!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label20, Me.tbPageNumber, Me.Label21, Me.tbPageCount, Me.Line21})
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label20
        '
        Me.Label20.Height = 0.2!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 4.881889!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
        Me.Label20.Text = "Página"
        Me.Label20.Top = 0.1574803!
        Me.Label20.Width = 0.5078735!
        '
        'tbPageNumber
        '
        Me.tbPageNumber.Height = 0.2!
        Me.tbPageNumber.Left = 5.436516!
        Me.tbPageNumber.Name = "tbPageNumber"
        Me.tbPageNumber.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageNumber.Text = Nothing
        Me.tbPageNumber.Top = 0.1574803!
        Me.tbPageNumber.Width = 0.492126!
        '
        'Label21
        '
        Me.Label21.Height = 0.2!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 5.92864!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.Label21.Text = "de"
        Me.Label21.Top = 0.1574803!
        Me.Label21.Width = 0.2952757!
        '
        'tbPageCount
        '
        Me.tbPageCount.Height = 0.2!
        Me.tbPageCount.Left = 6.223917!
        Me.tbPageCount.Name = "tbPageCount"
        Me.tbPageCount.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
        Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageCount.Text = Nothing
        Me.tbPageCount.Top = 0.1574803!
        Me.tbPageCount.Width = 0.492126!
        '
        'Line21
        '
        Me.Line21.Height = 5.866598E-9!
        Me.Line21.Left = 0.0!
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.0!
        Me.Line21.Width = 7.007875!
        Me.Line21.X1 = 0.0!
        Me.Line21.X2 = 7.007875!
        Me.Line21.Y1 = 0.0!
        Me.Line21.Y2 = 5.866598E-9!
        '
        'rptDiferenciasInventario
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.8034722!
        Me.PageSettings.Margins.Left = 0.60625!
        Me.PageSettings.Margins.Right = 0.60625!
        Me.PageSettings.Margins.Top = 0.5277778!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.020833!
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
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMarFamLin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub PageFooter_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.BeforePrint
        If Integer.Parse(tbPageNumber.Text) = Integer.Parse(tbPageCount.Text) Then
            Me.Line21.Visible = False
        End If
    End Sub
End Class
