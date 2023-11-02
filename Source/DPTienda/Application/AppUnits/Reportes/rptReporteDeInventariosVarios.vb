Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.Reports


Public Class rptReporteDeInventariosVarios

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal oReporter As InventarioReportesVarios, _
                    ByVal Titulo As String, _
                    ByVal Almacen As String, _
                    ByVal Mes As String)

        MyBase.New()

        InitializeComponent()

        Try

            Dim dsExistencias As New DataSet

            Me.DataSource = oReporter.dsArticulos
            Me.DataMember = oReporter.dsArticulos.Tables(0).TableName

            Me.lblTitulo.Text = "REPORTE DE EXISTENCIAS : " & Titulo
            Me.TxtSucursal.Text = Almacen
            Me.txtMes.Text = Mes

            Me.txtArticulos.DataField = "Codigo"
            Me.txtColor.DataField = "Color"
            Me.txtTotal.DataField = "TotalA"
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtFechaReporte.Text = Format(Date.Now, "dd - MMM - yyyy")

            Me.PageSettings.Margins.Left = 0.5
            Me.PageSettings.Margins.Top = 0.5

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label4 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label2 As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private txtFechaReporte As TextBox = Nothing
	Private TxtSucursal As TextBox = Nothing
	Private txtPag As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Line37 As Line = Nothing
	Private Line38 As Line = Nothing
	Private Line39 As Line = Nothing
	Private Line40 As Line = Nothing
	Private TextBox6 As TextBox = Nothing
	Private txtMes As TextBox = Nothing
	Private txtArticulos As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtColor As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private tbTalla01 As TextBox = Nothing
	Private tbTotal01 As TextBox = Nothing
	Private tbTotal02 As TextBox = Nothing
	Private tbTalla02 As TextBox = Nothing
	Private tbTalla03 As TextBox = Nothing
	Private tbTotal03 As TextBox = Nothing
	Private tbTotal04 As TextBox = Nothing
	Private tbTalla04 As TextBox = Nothing
	Private tbTalla05 As TextBox = Nothing
	Private tbTotal05 As TextBox = Nothing
	Private tbTotal06 As TextBox = Nothing
	Private tbTalla06 As TextBox = Nothing
	Private tbTalla07 As TextBox = Nothing
	Private tbTotal07 As TextBox = Nothing
	Private tbTotal08 As TextBox = Nothing
	Private tbTalla08 As TextBox = Nothing
	Private tbTalla09 As TextBox = Nothing
	Private tbTotal09 As TextBox = Nothing
	Private tbTotal10 As TextBox = Nothing
	Private tbTalla10 As TextBox = Nothing
	Private tbTotal11 As TextBox = Nothing
	Private tbTalla11 As TextBox = Nothing
	Private tbTalla12 As TextBox = Nothing
	Private tbTotal12 As TextBox = Nothing
	Private tbTalla13 As TextBox = Nothing
	Private tbTotal13 As TextBox = Nothing
	Private tbTotal14 As TextBox = Nothing
	Private tbTalla14 As TextBox = Nothing
	Private tbTalla15 As TextBox = Nothing
	Private tbTotal15 As TextBox = Nothing
	Private tbTotal16 As TextBox = Nothing
	Private tbTalla16 As TextBox = Nothing
	Private tbTalla17 As TextBox = Nothing
	Private tbTotal17 As TextBox = Nothing
	Private tbTotal18 As TextBox = Nothing
	Private tbTalla18 As TextBox = Nothing
	Private tbTalla19 As TextBox = Nothing
	Private tbTotal19 As TextBox = Nothing
	Private tbTotal20 As TextBox = Nothing
	Private tbTalla20 As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private TextBox8 As TextBox = Nothing
	Private txtTotGral As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteDeInventariosVarios))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.txtFechaReporte = New DataDynamics.ActiveReports.TextBox()
            Me.TxtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.Line37 = New DataDynamics.ActiveReports.Line()
            Me.Line38 = New DataDynamics.ActiveReports.Line()
            Me.Line39 = New DataDynamics.ActiveReports.Line()
            Me.Line40 = New DataDynamics.ActiveReports.Line()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtMes = New DataDynamics.ActiveReports.TextBox()
            Me.txtArticulos = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtColor = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla01 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal01 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal02 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla02 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla03 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal03 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal04 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla04 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla05 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal05 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal06 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla06 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla07 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal07 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal08 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla08 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla09 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal09 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal10 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla10 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal11 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla11 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla12 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal12 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla13 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal13 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal14 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla14 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla15 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal15 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal16 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla16 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla17 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal17 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal18 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla18 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla19 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal19 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotal20 = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla20 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotGral = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla01,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal01,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal02,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla02,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla03,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal03,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal04,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla04,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla05,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal05,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal06,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla06,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla07,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal07,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal08,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla08,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla09,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal09,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotGral,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtArticulos, Me.txtTotal, Me.txtColor, Me.txtDescripcion, Me.tbTalla01, Me.tbTotal01, Me.tbTotal02, Me.tbTalla02, Me.tbTalla03, Me.tbTotal03, Me.tbTotal04, Me.tbTalla04, Me.tbTalla05, Me.tbTotal05, Me.tbTotal06, Me.tbTalla06, Me.tbTalla07, Me.tbTotal07, Me.tbTotal08, Me.tbTalla08, Me.tbTalla09, Me.tbTotal09, Me.tbTotal10, Me.tbTalla10, Me.tbTotal11, Me.tbTalla11, Me.tbTalla12, Me.tbTotal12, Me.tbTalla13, Me.tbTotal13, Me.tbTotal14, Me.tbTalla14, Me.tbTalla15, Me.tbTotal15, Me.tbTotal16, Me.tbTalla16, Me.tbTalla17, Me.tbTotal17, Me.tbTotal18, Me.tbTalla18, Me.tbTalla19, Me.tbTotal19, Me.tbTotal20, Me.tbTalla20})
            Me.Detail.Height = 0.3534722!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label4, Me.Label3, Me.Label6, Me.Label2, Me.lblTitulo, Me.txtFechaReporte, Me.TxtSucursal, Me.txtPag, Me.TextBox5, Me.Line37, Me.Line38, Me.Line39, Me.Line40, Me.TextBox6, Me.txtMes})
            Me.PageHeader.Height = 0.6131945!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.TextBox8, Me.txtTotGral})
            Me.GroupFooter1.Height = 0.25!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.625!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 9.3125!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 5.625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-"& _ 
                "align: middle"
            Me.Label4.Text = "TALLAS / EXISTENCIAS"
            Me.Label4.Top = 0.4375!
            Me.Label4.Width = 1.335137!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.5!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-"& _ 
                "align: middle"
            Me.Label3.Text = "TOTAL"
            Me.Label3.Top = 0.4375!
            Me.Label3.Width = 0.6875!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-"& _ 
                "align: middle"
            Me.Label6.Text = "COLOR"
            Me.Label6.Top = 0.4375!
            Me.Label6.Width = 1.125!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; vertical-"& _ 
                "align: middle"
            Me.Label2.Text = "ARTICULOS"
            Me.Label2.Top = 0.4375!
            Me.Label2.Width = 1.375!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.1875!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.5pt; vertica"& _ 
                "l-align: middle"
            Me.lblTitulo.Text = "REPORTE DE EXISTENCIAS:"
            Me.lblTitulo.Top = 0!
            Me.lblTitulo.Width = 6.875!
            '
            'txtFechaReporte
            '
            Me.txtFechaReporte.Height = 0.2!
            Me.txtFechaReporte.Left = 0.1230315!
            Me.txtFechaReporte.Name = "txtFechaReporte"
            Me.txtFechaReporte.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: middle"
            Me.txtFechaReporte.Text = "txtFecha"
            Me.txtFechaReporte.Top = 0.02460632!
            Me.txtFechaReporte.Width = 1!
            '
            'TxtSucursal
            '
            Me.TxtSucursal.Height = 0.1968504!
            Me.TxtSucursal.Left = 1.5625!
            Me.TxtSucursal.Name = "TxtSucursal"
            Me.TxtSucursal.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.TxtSucursal.Text = "TxtSucursal"
            Me.TxtSucursal.Top = 0.1875!
            Me.TxtSucursal.Width = 4.716043!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.2!
            Me.txtPag.Left = 8.689466!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; vertical-a"& _ 
                "lign: middle"
            Me.txtPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtPag.Text = "Pagina"
            Me.txtPag.Top = 0!
            Me.txtPag.Width = 0.5605316!
            '
            'TextBox5
            '
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 8.3125!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: middle"
            Me.TextBox5.Text = "Pag.:"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.3125!
            '
            'Line37
            '
            Me.Line37.Height = 0!
            Me.Line37.Left = 0.006944444!
            Me.Line37.LineWeight = 1!
            Me.Line37.Name = "Line37"
            Me.Line37.Top = 0.4444444!
            Me.Line37.Width = 9.3125!
            Me.Line37.X1 = 9.319445!
            Me.Line37.X2 = 0.006944444!
            Me.Line37.Y1 = 0.4444444!
            Me.Line37.Y2 = 0.4444444!
            '
            'Line38
            '
            Me.Line38.Height = 0.1875!
            Me.Line38.Left = 2.506944!
            Me.Line38.LineWeight = 1!
            Me.Line38.Name = "Line38"
            Me.Line38.Top = 0.4444444!
            Me.Line38.Width = 0!
            Me.Line38.X1 = 2.506944!
            Me.Line38.X2 = 2.506944!
            Me.Line38.Y1 = 0.4444444!
            Me.Line38.Y2 = 0.6319444!
            '
            'Line39
            '
            Me.Line39.Height = 0.1875!
            Me.Line39.Left = 1.381944!
            Me.Line39.LineWeight = 1!
            Me.Line39.Name = "Line39"
            Me.Line39.Top = 0.4444444!
            Me.Line39.Width = 0!
            Me.Line39.X1 = 1.381944!
            Me.Line39.X2 = 1.381944!
            Me.Line39.Y1 = 0.4444444!
            Me.Line39.Y2 = 0.6319444!
            '
            'Line40
            '
            Me.Line40.Height = 0.1875!
            Me.Line40.Left = 3.194444!
            Me.Line40.LineWeight = 1!
            Me.Line40.Name = "Line40"
            Me.Line40.Top = 0.4444444!
            Me.Line40.Width = 0!
            Me.Line40.X1 = 3.194444!
            Me.Line40.X2 = 3.194444!
            Me.Line40.Y1 = 0.4444444!
            Me.Line40.Y2 = 0.6319444!
            '
            'TextBox6
            '
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 6.310532!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: middle"
            Me.TextBox6.Text = "MES :"
            Me.TextBox6.Top = 0.2121064!
            Me.TextBox6.Width = 0.375!
            '
            'txtMes
            '
            Me.txtMes.Height = 0.2!
            Me.txtMes.Left = 6.685532!
            Me.txtMes.Name = "txtMes"
            Me.txtMes.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; vertical-al"& _ 
                "ign: middle"
            Me.txtMes.Text = "txtMes"
            Me.txtMes.Top = 0.2121064!
            Me.txtMes.Width = 0.9375!
            '
            'txtArticulos
            '
            Me.txtArticulos.Height = 0.2!
            Me.txtArticulos.Left = 0!
            Me.txtArticulos.Name = "txtArticulos"
            Me.txtArticulos.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtArticulos.Text = "txtarticulo"
            Me.txtArticulos.Top = 0.006944444!
            Me.txtArticulos.Width = 1.394193!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 2.50187!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; vertical-align: top"
            Me.txtTotal.Text = "txtTotal"
            Me.txtTotal.Top = 0.006944444!
            Me.txtTotal.Width = 0.6451772!
            '
            'txtColor
            '
            Me.txtColor.Height = 0.2!
            Me.txtColor.Left = 1.412303!
            Me.txtColor.Name = "txtColor"
            Me.txtColor.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt"
            Me.txtColor.Text = "txtColor"
            Me.txtColor.Top = 0.006944444!
            Me.txtColor.Width = 1.112697!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.CanGrow = false
            Me.txtDescripcion.Height = 0.2!
            Me.txtDescripcion.Left = 0!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "ddo-char-set: 1; font-size: 8pt"
            Me.txtDescripcion.Text = "txtDescripcion"
            Me.txtDescripcion.Top = 0.1944444!
            Me.txtDescripcion.Width = 2.542323!
            '
            'tbTalla01
            '
            Me.tbTalla01.DataField = "Talla01"
            Me.tbTalla01.Height = 0.197!
            Me.tbTalla01.Left = 3.22185!
            Me.tbTalla01.Name = "tbTalla01"
            Me.tbTalla01.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla01.Text = "Ta01"
            Me.tbTalla01.Top = 0.006944444!
            Me.tbTalla01.Width = 0.3!
            '
            'tbTotal01
            '
            Me.tbTotal01.DataField = "Total01"
            Me.tbTotal01.Height = 0.197!
            Me.tbTotal01.Left = 3.22185!
            Me.tbTotal01.Name = "tbTotal01"
            Me.tbTotal01.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal01.Text = "To01"
            Me.tbTotal01.Top = 0.2037949!
            Me.tbTotal01.Width = 0.3!
            '
            'tbTotal02
            '
            Me.tbTotal02.DataField = "Total02"
            Me.tbTotal02.Height = 0.197!
            Me.tbTotal02.Left = 3.53435!
            Me.tbTotal02.Name = "tbTotal02"
            Me.tbTotal02.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal02.Text = "To02"
            Me.tbTotal02.Top = 0.2034444!
            Me.tbTotal02.Width = 0.3!
            '
            'tbTalla02
            '
            Me.tbTalla02.DataField = "Talla02"
            Me.tbTalla02.Height = 0.197!
            Me.tbTalla02.Left = 3.53435!
            Me.tbTalla02.Name = "tbTalla02"
            Me.tbTalla02.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla02.Text = "Ta02"
            Me.tbTalla02.Top = 0.006944444!
            Me.tbTalla02.Width = 0.3!
            '
            'tbTalla03
            '
            Me.tbTalla03.DataField = "Talla03"
            Me.tbTalla03.Height = 0.197!
            Me.tbTalla03.Left = 3.82135!
            Me.tbTalla03.Name = "tbTalla03"
            Me.tbTalla03.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla03.Text = "Ta03"
            Me.tbTalla03.Top = 0.006944444!
            Me.tbTalla03.Width = 0.3!
            '
            'tbTotal03
            '
            Me.tbTotal03.DataField = "Total03"
            Me.tbTotal03.Height = 0.197!
            Me.tbTotal03.Left = 3.821751!
            Me.tbTotal03.Name = "tbTotal03"
            Me.tbTotal03.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal03.Text = "To03"
            Me.tbTotal03.Top = 0.2037949!
            Me.tbTotal03.Width = 0.3!
            '
            'tbTotal04
            '
            Me.tbTotal04.DataField = "Total04"
            Me.tbTotal04.Height = 0.197!
            Me.tbTotal04.Left = 4.139351!
            Me.tbTotal04.Name = "tbTotal04"
            Me.tbTotal04.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal04.Text = "To04"
            Me.tbTotal04.Top = 0.2034444!
            Me.tbTotal04.Width = 0.3!
            '
            'tbTalla04
            '
            Me.tbTalla04.DataField = "Talla04"
            Me.tbTalla04.Height = 0.197!
            Me.tbTalla04.Left = 4.139351!
            Me.tbTalla04.Name = "tbTalla04"
            Me.tbTalla04.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla04.Text = "Ta04"
            Me.tbTalla04.Top = 0.006944444!
            Me.tbTalla04.Width = 0.3!
            '
            'tbTalla05
            '
            Me.tbTalla05.DataField = "Talla05"
            Me.tbTalla05.Height = 0.197!
            Me.tbTalla05.Left = 4.449349!
            Me.tbTalla05.Name = "tbTalla05"
            Me.tbTalla05.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla05.Text = "Ta05"
            Me.tbTalla05.Top = 0.006944444!
            Me.tbTalla05.Width = 0.3!
            '
            'tbTotal05
            '
            Me.tbTotal05.DataField = "Total05"
            Me.tbTotal05.Height = 0.197!
            Me.tbTotal05.Left = 4.449349!
            Me.tbTotal05.Name = "tbTotal05"
            Me.tbTotal05.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal05.Text = "To05"
            Me.tbTotal05.Top = 0.2034444!
            Me.tbTotal05.Width = 0.3!
            '
            'tbTotal06
            '
            Me.tbTotal06.DataField = "Total06"
            Me.tbTotal06.Height = 0.197!
            Me.tbTotal06.Left = 4.752853!
            Me.tbTotal06.Name = "tbTotal06"
            Me.tbTotal06.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal06.Text = "To06"
            Me.tbTotal06.Top = 0.2037949!
            Me.tbTotal06.Width = 0.3!
            '
            'tbTalla06
            '
            Me.tbTalla06.DataField = "Talla06"
            Me.tbTalla06.Height = 0.197!
            Me.tbTalla06.Left = 4.752853!
            Me.tbTalla06.Name = "tbTalla06"
            Me.tbTalla06.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla06.Text = "Ta06"
            Me.tbTalla06.Top = 0.006944444!
            Me.tbTalla06.Width = 0.305!
            '
            'tbTalla07
            '
            Me.tbTalla07.DataField = "Talla07"
            Me.tbTalla07.Height = 0.197!
            Me.tbTalla07.Left = 5.069349!
            Me.tbTalla07.Name = "tbTalla07"
            Me.tbTalla07.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla07.Text = "Ta07"
            Me.tbTalla07.Top = 0.006944444!
            Me.tbTalla07.Width = 0.3!
            '
            'tbTotal07
            '
            Me.tbTotal07.DataField = "Total07"
            Me.tbTotal07.Height = 0.197!
            Me.tbTotal07.Left = 5.069349!
            Me.tbTotal07.Name = "tbTotal07"
            Me.tbTotal07.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal07.Text = "To07"
            Me.tbTotal07.Top = 0.2034444!
            Me.tbTotal07.Width = 0.3!
            '
            'tbTotal08
            '
            Me.tbTotal08.DataField = "Total08"
            Me.tbTotal08.Height = 0.197!
            Me.tbTotal08.Left = 5.352757!
            Me.tbTotal08.Name = "tbTotal08"
            Me.tbTotal08.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal08.Text = "To08"
            Me.tbTotal08.Top = 0.2037949!
            Me.tbTotal08.Width = 0.3!
            '
            'tbTalla08
            '
            Me.tbTalla08.DataField = "Talla08"
            Me.tbTalla08.Height = 0.197!
            Me.tbTalla08.Left = 5.352349!
            Me.tbTalla08.Name = "tbTalla08"
            Me.tbTalla08.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla08.Text = "Ta08"
            Me.tbTalla08.Top = 0.006944444!
            Me.tbTalla08.Width = 0.3070001!
            '
            'tbTalla09
            '
            Me.tbTalla09.DataField = "Talla09"
            Me.tbTalla09.Height = 0.197!
            Me.tbTalla09.Left = 5.65935!
            Me.tbTalla09.Name = "tbTalla09"
            Me.tbTalla09.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla09.Text = "Ta09"
            Me.tbTalla09.Top = 0.006944444!
            Me.tbTalla09.Width = 0.3!
            '
            'tbTotal09
            '
            Me.tbTotal09.DataField = "Total09"
            Me.tbTotal09.Height = 0.197!
            Me.tbTotal09.Left = 5.674349!
            Me.tbTotal09.Name = "tbTotal09"
            Me.tbTotal09.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal09.Text = "To09"
            Me.tbTotal09.Top = 0.2034444!
            Me.tbTotal09.Width = 0.3!
            '
            'tbTotal10
            '
            Me.tbTotal10.DataField = "Total10"
            Me.tbTotal10.Height = 0.197!
            Me.tbTotal10.Left = 5.962354!
            Me.tbTotal10.Name = "tbTotal10"
            Me.tbTotal10.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal10.Text = "To10"
            Me.tbTotal10.Top = 0.2034444!
            Me.tbTotal10.Width = 0.3!
            '
            'tbTalla10
            '
            Me.tbTalla10.DataField = "Talla10"
            Me.tbTalla10.Height = 0.197!
            Me.tbTalla10.Left = 5.962354!
            Me.tbTalla10.Name = "tbTalla10"
            Me.tbTalla10.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla10.Text = "Ta10"
            Me.tbTalla10.Top = 0.006944444!
            Me.tbTalla10.Width = 0.3!
            '
            'tbTotal11
            '
            Me.tbTotal11.DataField = "Total11"
            Me.tbTotal11.Height = 0.197!
            Me.tbTotal11.Left = 6.264348!
            Me.tbTotal11.Name = "tbTotal11"
            Me.tbTotal11.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal11.Text = "To11"
            Me.tbTotal11.Top = 0.2034444!
            Me.tbTotal11.Width = 0.3!
            '
            'tbTalla11
            '
            Me.tbTalla11.DataField = "Talla11"
            Me.tbTalla11.Height = 0.197!
            Me.tbTalla11.Left = 6.264348!
            Me.tbTalla11.Name = "tbTalla11"
            Me.tbTalla11.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla11.Text = "Ta11"
            Me.tbTalla11.Top = 0.006944444!
            Me.tbTalla11.Width = 0.3!
            '
            'tbTalla12
            '
            Me.tbTalla12.DataField = "Talla12"
            Me.tbTalla12.Height = 0.197!
            Me.tbTalla12.Left = 6.552556!
            Me.tbTalla12.Name = "tbTalla12"
            Me.tbTalla12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla12.Text = "Ta12"
            Me.tbTalla12.Top = 0.006944444!
            Me.tbTalla12.Width = 0.31!
            '
            'tbTotal12
            '
            Me.tbTotal12.DataField = "Total12"
            Me.tbTotal12.Height = 0.197!
            Me.tbTotal12.Left = 6.552556!
            Me.tbTotal12.Name = "tbTotal12"
            Me.tbTotal12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal12.Text = "To12"
            Me.tbTotal12.Top = 0.2037949!
            Me.tbTotal12.Width = 0.3!
            '
            'tbTalla13
            '
            Me.tbTalla13.DataField = "Talla13"
            Me.tbTalla13.Height = 0.197!
            Me.tbTalla13.Left = 6.869354!
            Me.tbTalla13.Name = "tbTalla13"
            Me.tbTalla13.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla13.Text = "Ta13"
            Me.tbTalla13.Top = 0.006944444!
            Me.tbTalla13.Width = 0.3!
            '
            'tbTotal13
            '
            Me.tbTotal13.DataField = "Total13"
            Me.tbTotal13.Height = 0.197!
            Me.tbTotal13.Left = 6.869354!
            Me.tbTotal13.Name = "tbTotal13"
            Me.tbTotal13.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal13.Text = "To13"
            Me.tbTotal13.Top = 0.2034444!
            Me.tbTotal13.Width = 0.3!
            '
            'tbTotal14
            '
            Me.tbTotal14.DataField = "Total14"
            Me.tbTotal14.Height = 0.197!
            Me.tbTotal14.Left = 7.159347!
            Me.tbTotal14.Name = "tbTotal14"
            Me.tbTotal14.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal14.Text = "To14"
            Me.tbTotal14.Top = 0.2034444!
            Me.tbTotal14.Width = 0.3!
            '
            'tbTalla14
            '
            Me.tbTalla14.DataField = "Talla14"
            Me.tbTalla14.Height = 0.197!
            Me.tbTalla14.Left = 7.159347!
            Me.tbTalla14.Name = "tbTalla14"
            Me.tbTalla14.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla14.Text = "Ta14"
            Me.tbTalla14.Top = 0.006944444!
            Me.tbTalla14.Width = 0.315!
            '
            'tbTalla15
            '
            Me.tbTalla15.DataField = "Talla15"
            Me.tbTalla15.Height = 0.197!
            Me.tbTalla15.Left = 7.474347!
            Me.tbTalla15.Name = "tbTalla15"
            Me.tbTalla15.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla15.Text = "Ta15"
            Me.tbTalla15.Top = 0.006944444!
            Me.tbTalla15.Width = 0.3!
            '
            'tbTotal15
            '
            Me.tbTotal15.DataField = "Total15"
            Me.tbTotal15.Height = 0.197!
            Me.tbTotal15.Left = 7.474347!
            Me.tbTotal15.Name = "tbTotal15"
            Me.tbTotal15.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal15.Text = "To15"
            Me.tbTotal15.Top = 0.2034444!
            Me.tbTotal15.Width = 0.3!
            '
            'tbTotal16
            '
            Me.tbTotal16.DataField = "Total16"
            Me.tbTotal16.Height = 0.197!
            Me.tbTotal16.Left = 7.762354!
            Me.tbTotal16.Name = "tbTotal16"
            Me.tbTotal16.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal16.Text = "To16"
            Me.tbTotal16.Top = 0.2034444!
            Me.tbTotal16.Width = 0.3!
            '
            'tbTalla16
            '
            Me.tbTalla16.DataField = "Talla16"
            Me.tbTalla16.Height = 0.197!
            Me.tbTalla16.Left = 7.762354!
            Me.tbTalla16.Name = "tbTalla16"
            Me.tbTalla16.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla16.Text = "Ta16"
            Me.tbTalla16.Top = 0.006944444!
            Me.tbTalla16.Width = 0.3!
            '
            'tbTalla17
            '
            Me.tbTalla17.DataField = "Talla17"
            Me.tbTalla17.Height = 0.197!
            Me.tbTalla17.Left = 8.074354!
            Me.tbTalla17.Name = "tbTalla17"
            Me.tbTalla17.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla17.Text = "Ta17"
            Me.tbTalla17.Top = 0.006944444!
            Me.tbTalla17.Width = 0.3!
            '
            'tbTotal17
            '
            Me.tbTotal17.DataField = "Total17"
            Me.tbTotal17.Height = 0.197!
            Me.tbTotal17.Left = 8.074354!
            Me.tbTotal17.Name = "tbTotal17"
            Me.tbTotal17.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal17.Text = "To17"
            Me.tbTotal17.Top = 0.2034444!
            Me.tbTotal17.Width = 0.3!
            '
            'tbTotal18
            '
            Me.tbTotal18.DataField = "Total18"
            Me.tbTotal18.Height = 0.197!
            Me.tbTotal18.Left = 8.389354!
            Me.tbTotal18.Name = "tbTotal18"
            Me.tbTotal18.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal18.Text = "To18"
            Me.tbTotal18.Top = 0.2034444!
            Me.tbTotal18.Width = 0.3!
            '
            'tbTalla18
            '
            Me.tbTalla18.DataField = "Talla18"
            Me.tbTalla18.Height = 0.197!
            Me.tbTalla18.Left = 8.389354!
            Me.tbTalla18.Name = "tbTalla18"
            Me.tbTalla18.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla18.Text = "Ta18"
            Me.tbTalla18.Top = 0.006944444!
            Me.tbTalla18.Width = 0.3!
            '
            'tbTalla19
            '
            Me.tbTalla19.DataField = "Talla19"
            Me.tbTalla19.Height = 0.197!
            Me.tbTalla19.Left = 8.683354!
            Me.tbTalla19.Name = "tbTalla19"
            Me.tbTalla19.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla19.Text = "Ta19"
            Me.tbTalla19.Top = 0.006944444!
            Me.tbTalla19.Width = 0.3!
            '
            'tbTotal19
            '
            Me.tbTotal19.DataField = "Total19"
            Me.tbTotal19.Height = 0.197!
            Me.tbTotal19.Left = 8.674111!
            Me.tbTotal19.Name = "tbTotal19"
            Me.tbTotal19.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal19.Text = "To19"
            Me.tbTotal19.Top = 0.2037949!
            Me.tbTotal19.Width = 0.3!
            '
            'tbTotal20
            '
            Me.tbTotal20.DataField = "Total20"
            Me.tbTotal20.Height = 0.197!
            Me.tbTotal20.Left = 8.985001!
            Me.tbTotal20.Name = "tbTotal20"
            Me.tbTotal20.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal20.Text = "To20"
            Me.tbTotal20.Top = 0.2034444!
            Me.tbTotal20.Width = 0.3!
            '
            'tbTalla20
            '
            Me.tbTalla20.DataField = "Talla20"
            Me.tbTalla20.Height = 0.197!
            Me.tbTalla20.Left = 8.994354!
            Me.tbTalla20.Name = "tbTalla20"
            Me.tbTalla20.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla20.Text = "Ta20"
            Me.tbTalla20.Top = 0.006944444!
            Me.tbTalla20.Width = 0.3!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.LineWeight = 2!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 9.3125!
            '
            'TextBox8
            '
            Me.TextBox8.Height = 0.2!
            Me.TextBox8.Left = 0.873032!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: middle"
            Me.TextBox8.Text = "TOTAL ARTICULOS"
            Me.TextBox8.Top = 0.02460632!
            Me.TextBox8.Width = 1.189468!
            '
            'txtTotGral
            '
            Me.txtTotGral.DataField = "TotalA"
            Me.txtTotGral.Height = 0.1875!
            Me.txtTotGral.Left = 2.1875!
            Me.txtTotGral.Name = "txtTotGral"
            Me.txtTotGral.OutputFormat = resources.GetString("txtTotGral.OutputFormat")
            Me.txtTotGral.Style = "text-align: right; font-weight: bold"
            Me.txtTotGral.Text = "Total"
            Me.txtTotGral.Top = 0.025!
            Me.txtTotGral.Width = 1.0625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 9.34375!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtArticulos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtColor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla01,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal01,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal02,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla02,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla03,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal03,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal04,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla04,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla05,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal05,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal06,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla06,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla07,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal07,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal08,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla08,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla09,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal09,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotGral,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
