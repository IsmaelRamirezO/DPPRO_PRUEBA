Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class InventarioNormalReport
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
        InitializeComponent()
        lblReportDate.Text = Date.Now.ToString()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblReportTitle As Label = Nothing
	Private lblReportDate As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label5 As Label = Nothing
	Private lblFieldCodigo As Label = Nothing
	Private lblFieldDescripcion As Label = Nothing
	Private Label11 As Label = Nothing
	Private Line37 As Line = Nothing
	Private Line33 As Line = Nothing
	Private tbColor As TextBox = Nothing
	Private tbTotalA As TextBox = Nothing
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
	Private Line36 As Line = Nothing
	Private lneBottomTable As Line = Nothing
	Private tbCodigo As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioNormalReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.lblReportDate = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.lblFieldCodigo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescripcion = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Line37 = New DataDynamics.ActiveReports.Line()
            Me.Line33 = New DataDynamics.ActiveReports.Line()
            Me.tbColor = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalA = New DataDynamics.ActiveReports.TextBox()
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
            Me.Line36 = New DataDynamics.ActiveReports.Line()
            Me.lneBottomTable = New DataDynamics.ActiveReports.Line()
            Me.tbCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
            Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbColor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalA,System.ComponentModel.ISupportInitialize).BeginInit
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
            CType(Me.tbCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line33, Me.tbColor, Me.tbTotalA, Me.tbTalla01, Me.tbTotal01, Me.tbTotal02, Me.tbTalla02, Me.tbTalla03, Me.tbTotal03, Me.tbTotal04, Me.tbTalla04, Me.tbTalla05, Me.tbTotal05, Me.tbTotal06, Me.tbTalla06, Me.tbTalla07, Me.tbTotal07, Me.tbTotal08, Me.tbTalla08, Me.tbTalla09, Me.tbTotal09, Me.tbTotal10, Me.tbTalla10, Me.tbTotal11, Me.tbTalla11, Me.tbTalla12, Me.tbTotal12, Me.tbTalla13, Me.tbTotal13, Me.tbTotal14, Me.tbTalla14, Me.tbTalla15, Me.tbTotal15, Me.tbTotal16, Me.tbTalla16, Me.tbTalla17, Me.tbTotal17, Me.tbTotal18, Me.tbTalla18, Me.tbTalla19, Me.tbTotal19, Me.tbTotal20, Me.tbTalla20, Me.Line36, Me.lneBottomTable, Me.tbCodigo, Me.TextBox1})
            Me.Detail.Height = 0.4784722!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblReportTitle, Me.lblReportDate, Me.Label1, Me.Label5, Me.lblFieldCodigo, Me.lblFieldDescripcion, Me.Label11, Me.Line37})
            Me.PageHeader.Height = 1.197222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.Label3, Me.tbPageNumber, Me.tbPageCount, Me.Label4})
            Me.PageFooter.Height = 0.59375!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.3937007!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 0!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: normal; font-size"& _ 
                ": 14pt; font-family: Arial; white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Inventario"
            Me.lblReportTitle.Top = 0.3229167!
            Me.lblReportTitle.Width = 4.330709!
            '
            'lblReportDate
            '
            Me.lblReportDate.Height = 0.1968504!
            Me.lblReportDate.HyperLink = Nothing
            Me.lblReportDate.Left = 7.811514!
            Me.lblReportDate.Name = "lblReportDate"
            Me.lblReportDate.Style = "color: Black; text-align: right; font-size: 9.75pt; font-family: Arial; vertical-"& _ 
                "align: middle"
            Me.lblReportDate.Text = "Label2"
            Me.lblReportDate.Top = 0!
            Me.lblReportDate.Width = 2.362205!
            '
            'Label1
            '
            Me.Label1.Height = 0.394!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 4.370079!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size"& _ 
                ": 9.75pt; font-family: Arial; vertical-align: middle"
            Me.Label1.Text = "Tallas"
            Me.Label1.Top = 0.7874014!
            Me.Label1.Width = 6.145!
            '
            'Label5
            '
            Me.Label5.Height = 0.4000985!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.5625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size"& _ 
                ": 9.75pt; font-family: Arial; vertical-align: middle"
            Me.Label5.Text = "Color"
            Me.Label5.Top = 0.7874014!
            Me.Label5.Width = 1.125!
            '
            'lblFieldCodigo
            '
            Me.lblFieldCodigo.Height = 0.1968504!
            Me.lblFieldCodigo.HyperLink = Nothing
            Me.lblFieldCodigo.Left = 0!
            Me.lblFieldCodigo.Name = "lblFieldCodigo"
            Me.lblFieldCodigo.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size"& _ 
                ": 9.75pt; font-family: Arial"
            Me.lblFieldCodigo.Text = "Codigo"
            Me.lblFieldCodigo.Top = 0.7874014!
            Me.lblFieldCodigo.Width = 2.5625!
            '
            'lblFieldDescripcion
            '
            Me.lblFieldDescripcion.Height = 0.1968504!
            Me.lblFieldDescripcion.HyperLink = Nothing
            Me.lblFieldDescripcion.Left = 0!
            Me.lblFieldDescripcion.Name = "lblFieldDescripcion"
            Me.lblFieldDescripcion.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size"& _ 
                ": 9.75pt; font-family: Arial"
            Me.lblFieldDescripcion.Text = "Descripción"
            Me.lblFieldDescripcion.Top = 0.9842521!
            Me.lblFieldDescripcion.Width = 2.5625!
            '
            'Label11
            '
            Me.Label11.Height = 0.4000985!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 3.8125!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: normal; font-size"& _ 
                ": 9.75pt; font-family: Arial; vertical-align: middle"
            Me.Label11.Text = "Total Art."
            Me.Label11.Top = 0.7874014!
            Me.Label11.Width = 0.75!
            '
            'Line37
            '
            Me.Line37.Height = 0!
            Me.Line37.Left = 0.6762357!
            Me.Line37.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line37.LineWeight = 1!
            Me.Line37.Name = "Line37"
            Me.Line37.Top = 1.188047!
            Me.Line37.Width = 9.763778!
            Me.Line37.X1 = 0.6762357!
            Me.Line37.X2 = 10.44001!
            Me.Line37.Y1 = 1.188047!
            Me.Line37.Y2 = 1.188047!
            '
            'Line33
            '
            Me.Line33.Height = 0.469!
            Me.Line33.Left = 10.50694!
            Me.Line33.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line33.LineWeight = 1!
            Me.Line33.Name = "Line33"
            Me.Line33.Top = 0!
            Me.Line33.Width = 5.531311E-05!
            Me.Line33.X1 = 10.50694!
            Me.Line33.X2 = 10.507!
            Me.Line33.Y1 = 0!
            Me.Line33.Y2 = 0.469!
            '
            'tbColor
            '
            Me.tbColor.DataField = "Color"
            Me.tbColor.Height = 0.2!
            Me.tbColor.Left = 2.604167!
            Me.tbColor.Name = "tbColor"
            Me.tbColor.Style = "text-align: center; font-size: 8.25pt; font-family: Arial"
            Me.tbColor.Top = 0!
            Me.tbColor.Width = 1.1875!
            '
            'tbTotalA
            '
            Me.tbTotalA.CanShrink = true
            Me.tbTotalA.DataField = "TotalA"
            Me.tbTotalA.Height = 0.2!
            Me.tbTotalA.Left = 3.688!
            Me.tbTotalA.Name = "tbTotalA"
            Me.tbTotalA.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotalA.Top = 0.259!
            Me.tbTotalA.Width = 0.75!
            '
            'tbTalla01
            '
            Me.tbTalla01.DataField = "Talla01"
            Me.tbTalla01.Height = 0.197!
            Me.tbTalla01.Left = 4.44685!
            Me.tbTalla01.Name = "tbTalla01"
            Me.tbTalla01.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla01.Text = "Ta01"
            Me.tbTalla01.Top = 0!
            Me.tbTalla01.Width = 0.3!
            '
            'tbTotal01
            '
            Me.tbTotal01.DataField = "Total01"
            Me.tbTotal01.Height = 0.197!
            Me.tbTotal01.Left = 4.44685!
            Me.tbTotal01.Name = "tbTotal01"
            Me.tbTotal01.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal01.Text = "To01"
            Me.tbTotal01.Top = 0.2593504!
            Me.tbTotal01.Width = 0.3!
            '
            'tbTotal02
            '
            Me.tbTotal02.DataField = "Total02"
            Me.tbTotal02.Height = 0.197!
            Me.tbTotal02.Left = 4.75935!
            Me.tbTotal02.Name = "tbTotal02"
            Me.tbTotal02.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal02.Text = "To02"
            Me.tbTotal02.Top = 0.259!
            Me.tbTotal02.Width = 0.3!
            '
            'tbTalla02
            '
            Me.tbTalla02.DataField = "Talla02"
            Me.tbTalla02.Height = 0.197!
            Me.tbTalla02.Left = 4.75935!
            Me.tbTalla02.Name = "tbTalla02"
            Me.tbTalla02.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla02.Text = "Ta02"
            Me.tbTalla02.Top = 0!
            Me.tbTalla02.Width = 0.3!
            '
            'tbTalla03
            '
            Me.tbTalla03.DataField = "Talla03"
            Me.tbTalla03.Height = 0.197!
            Me.tbTalla03.Left = 5.04635!
            Me.tbTalla03.Name = "tbTalla03"
            Me.tbTalla03.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla03.Text = "Ta03"
            Me.tbTalla03.Top = 0!
            Me.tbTalla03.Width = 0.3!
            '
            'tbTotal03
            '
            Me.tbTotal03.DataField = "Total03"
            Me.tbTotal03.Height = 0.197!
            Me.tbTotal03.Left = 5.046751!
            Me.tbTotal03.Name = "tbTotal03"
            Me.tbTotal03.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal03.Text = "To03"
            Me.tbTotal03.Top = 0.2593504!
            Me.tbTotal03.Width = 0.3!
            '
            'tbTotal04
            '
            Me.tbTotal04.DataField = "Total04"
            Me.tbTotal04.Height = 0.197!
            Me.tbTotal04.Left = 5.364351!
            Me.tbTotal04.Name = "tbTotal04"
            Me.tbTotal04.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal04.Text = "To04"
            Me.tbTotal04.Top = 0.259!
            Me.tbTotal04.Width = 0.3!
            '
            'tbTalla04
            '
            Me.tbTalla04.DataField = "Talla04"
            Me.tbTalla04.Height = 0.197!
            Me.tbTalla04.Left = 5.364351!
            Me.tbTalla04.Name = "tbTalla04"
            Me.tbTalla04.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla04.Text = "Ta04"
            Me.tbTalla04.Top = 0!
            Me.tbTalla04.Width = 0.3!
            '
            'tbTalla05
            '
            Me.tbTalla05.DataField = "Talla05"
            Me.tbTalla05.Height = 0.197!
            Me.tbTalla05.Left = 5.674349!
            Me.tbTalla05.Name = "tbTalla05"
            Me.tbTalla05.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla05.Text = "Ta05"
            Me.tbTalla05.Top = 0!
            Me.tbTalla05.Width = 0.3!
            '
            'tbTotal05
            '
            Me.tbTotal05.DataField = "Total05"
            Me.tbTotal05.Height = 0.197!
            Me.tbTotal05.Left = 5.674349!
            Me.tbTotal05.Name = "tbTotal05"
            Me.tbTotal05.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal05.Text = "To05"
            Me.tbTotal05.Top = 0.259!
            Me.tbTotal05.Width = 0.3!
            '
            'tbTotal06
            '
            Me.tbTotal06.DataField = "Total06"
            Me.tbTotal06.Height = 0.197!
            Me.tbTotal06.Left = 5.977854!
            Me.tbTotal06.Name = "tbTotal06"
            Me.tbTotal06.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal06.Text = "To06"
            Me.tbTotal06.Top = 0.2593504!
            Me.tbTotal06.Width = 0.3!
            '
            'tbTalla06
            '
            Me.tbTalla06.DataField = "Talla06"
            Me.tbTalla06.Height = 0.197!
            Me.tbTalla06.Left = 5.977854!
            Me.tbTalla06.Name = "tbTalla06"
            Me.tbTalla06.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla06.Text = "Ta06"
            Me.tbTalla06.Top = 0!
            Me.tbTalla06.Width = 0.305!
            '
            'tbTalla07
            '
            Me.tbTalla07.DataField = "Talla07"
            Me.tbTalla07.Height = 0.197!
            Me.tbTalla07.Left = 6.29435!
            Me.tbTalla07.Name = "tbTalla07"
            Me.tbTalla07.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla07.Text = "Ta07"
            Me.tbTalla07.Top = 0!
            Me.tbTalla07.Width = 0.3!
            '
            'tbTotal07
            '
            Me.tbTotal07.DataField = "Total07"
            Me.tbTotal07.Height = 0.197!
            Me.tbTotal07.Left = 6.29435!
            Me.tbTotal07.Name = "tbTotal07"
            Me.tbTotal07.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal07.Text = "To07"
            Me.tbTotal07.Top = 0.259!
            Me.tbTotal07.Width = 0.3!
            '
            'tbTotal08
            '
            Me.tbTotal08.DataField = "Total08"
            Me.tbTotal08.Height = 0.197!
            Me.tbTotal08.Left = 6.577756!
            Me.tbTotal08.Name = "tbTotal08"
            Me.tbTotal08.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal08.Text = "To08"
            Me.tbTotal08.Top = 0.2593504!
            Me.tbTotal08.Width = 0.3!
            '
            'tbTalla08
            '
            Me.tbTalla08.DataField = "Talla08"
            Me.tbTalla08.Height = 0.197!
            Me.tbTalla08.Left = 6.57735!
            Me.tbTalla08.Name = "tbTalla08"
            Me.tbTalla08.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla08.Text = "Ta08"
            Me.tbTalla08.Top = 0!
            Me.tbTalla08.Width = 0.3070001!
            '
            'tbTalla09
            '
            Me.tbTalla09.DataField = "Talla09"
            Me.tbTalla09.Height = 0.197!
            Me.tbTalla09.Left = 6.884351!
            Me.tbTalla09.Name = "tbTalla09"
            Me.tbTalla09.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla09.Text = "Ta09"
            Me.tbTalla09.Top = 0!
            Me.tbTalla09.Width = 0.3!
            '
            'tbTotal09
            '
            Me.tbTotal09.DataField = "Total09"
            Me.tbTotal09.Height = 0.197!
            Me.tbTotal09.Left = 6.89935!
            Me.tbTotal09.Name = "tbTotal09"
            Me.tbTotal09.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal09.Text = "To09"
            Me.tbTotal09.Top = 0.259!
            Me.tbTotal09.Width = 0.3!
            '
            'tbTotal10
            '
            Me.tbTotal10.DataField = "Total10"
            Me.tbTotal10.Height = 0.197!
            Me.tbTotal10.Left = 7.187354!
            Me.tbTotal10.Name = "tbTotal10"
            Me.tbTotal10.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal10.Text = "To10"
            Me.tbTotal10.Top = 0.259!
            Me.tbTotal10.Width = 0.3!
            '
            'tbTalla10
            '
            Me.tbTalla10.DataField = "Talla10"
            Me.tbTalla10.Height = 0.197!
            Me.tbTalla10.Left = 7.187354!
            Me.tbTalla10.Name = "tbTalla10"
            Me.tbTalla10.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla10.Text = "Ta10"
            Me.tbTalla10.Top = 0!
            Me.tbTalla10.Width = 0.3!
            '
            'tbTotal11
            '
            Me.tbTotal11.DataField = "Total11"
            Me.tbTotal11.Height = 0.197!
            Me.tbTotal11.Left = 7.489347!
            Me.tbTotal11.Name = "tbTotal11"
            Me.tbTotal11.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal11.Text = "To11"
            Me.tbTotal11.Top = 0.259!
            Me.tbTotal11.Width = 0.3!
            '
            'tbTalla11
            '
            Me.tbTalla11.DataField = "Talla11"
            Me.tbTalla11.Height = 0.197!
            Me.tbTalla11.Left = 7.489347!
            Me.tbTalla11.Name = "tbTalla11"
            Me.tbTalla11.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla11.Text = "Ta11"
            Me.tbTalla11.Top = 0!
            Me.tbTalla11.Width = 0.3!
            '
            'tbTalla12
            '
            Me.tbTalla12.DataField = "Talla12"
            Me.tbTalla12.Height = 0.197!
            Me.tbTalla12.Left = 7.777555!
            Me.tbTalla12.Name = "tbTalla12"
            Me.tbTalla12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla12.Text = "Ta12"
            Me.tbTalla12.Top = 0!
            Me.tbTalla12.Width = 0.31!
            '
            'tbTotal12
            '
            Me.tbTotal12.DataField = "Total12"
            Me.tbTotal12.Height = 0.197!
            Me.tbTotal12.Left = 7.777555!
            Me.tbTotal12.Name = "tbTotal12"
            Me.tbTotal12.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal12.Text = "To12"
            Me.tbTotal12.Top = 0.2593504!
            Me.tbTotal12.Width = 0.3!
            '
            'tbTalla13
            '
            Me.tbTalla13.DataField = "Talla13"
            Me.tbTalla13.Height = 0.197!
            Me.tbTalla13.Left = 8.094355!
            Me.tbTalla13.Name = "tbTalla13"
            Me.tbTalla13.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla13.Text = "Ta13"
            Me.tbTalla13.Top = 0!
            Me.tbTalla13.Width = 0.3!
            '
            'tbTotal13
            '
            Me.tbTotal13.DataField = "Total13"
            Me.tbTotal13.Height = 0.197!
            Me.tbTotal13.Left = 8.094355!
            Me.tbTotal13.Name = "tbTotal13"
            Me.tbTotal13.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal13.Text = "To13"
            Me.tbTotal13.Top = 0.259!
            Me.tbTotal13.Width = 0.3!
            '
            'tbTotal14
            '
            Me.tbTotal14.DataField = "Total14"
            Me.tbTotal14.Height = 0.197!
            Me.tbTotal14.Left = 8.384347!
            Me.tbTotal14.Name = "tbTotal14"
            Me.tbTotal14.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal14.Text = "To14"
            Me.tbTotal14.Top = 0.259!
            Me.tbTotal14.Width = 0.3!
            '
            'tbTalla14
            '
            Me.tbTalla14.DataField = "Talla14"
            Me.tbTalla14.Height = 0.197!
            Me.tbTalla14.Left = 8.384347!
            Me.tbTalla14.Name = "tbTalla14"
            Me.tbTalla14.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla14.Text = "Ta14"
            Me.tbTalla14.Top = 0!
            Me.tbTalla14.Width = 0.315!
            '
            'tbTalla15
            '
            Me.tbTalla15.DataField = "Talla15"
            Me.tbTalla15.Height = 0.197!
            Me.tbTalla15.Left = 8.699347!
            Me.tbTalla15.Name = "tbTalla15"
            Me.tbTalla15.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla15.Text = "Ta15"
            Me.tbTalla15.Top = 0!
            Me.tbTalla15.Width = 0.3!
            '
            'tbTotal15
            '
            Me.tbTotal15.DataField = "Total15"
            Me.tbTotal15.Height = 0.197!
            Me.tbTotal15.Left = 8.699347!
            Me.tbTotal15.Name = "tbTotal15"
            Me.tbTotal15.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal15.Text = "To15"
            Me.tbTotal15.Top = 0.259!
            Me.tbTotal15.Width = 0.3!
            '
            'tbTotal16
            '
            Me.tbTotal16.DataField = "Total16"
            Me.tbTotal16.Height = 0.197!
            Me.tbTotal16.Left = 8.987354!
            Me.tbTotal16.Name = "tbTotal16"
            Me.tbTotal16.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal16.Text = "To16"
            Me.tbTotal16.Top = 0.259!
            Me.tbTotal16.Width = 0.3!
            '
            'tbTalla16
            '
            Me.tbTalla16.DataField = "Talla16"
            Me.tbTalla16.Height = 0.197!
            Me.tbTalla16.Left = 8.987354!
            Me.tbTalla16.Name = "tbTalla16"
            Me.tbTalla16.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla16.Text = "Ta16"
            Me.tbTalla16.Top = 0!
            Me.tbTalla16.Width = 0.3!
            '
            'tbTalla17
            '
            Me.tbTalla17.DataField = "Talla17"
            Me.tbTalla17.Height = 0.197!
            Me.tbTalla17.Left = 9.299355!
            Me.tbTalla17.Name = "tbTalla17"
            Me.tbTalla17.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla17.Text = "Ta17"
            Me.tbTalla17.Top = 0!
            Me.tbTalla17.Width = 0.3!
            '
            'tbTotal17
            '
            Me.tbTotal17.DataField = "Total17"
            Me.tbTotal17.Height = 0.197!
            Me.tbTotal17.Left = 9.299355!
            Me.tbTotal17.Name = "tbTotal17"
            Me.tbTotal17.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal17.Text = "To17"
            Me.tbTotal17.Top = 0.259!
            Me.tbTotal17.Width = 0.3!
            '
            'tbTotal18
            '
            Me.tbTotal18.DataField = "Total18"
            Me.tbTotal18.Height = 0.197!
            Me.tbTotal18.Left = 9.614354!
            Me.tbTotal18.Name = "tbTotal18"
            Me.tbTotal18.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal18.Text = "To18"
            Me.tbTotal18.Top = 0.259!
            Me.tbTotal18.Width = 0.3!
            '
            'tbTalla18
            '
            Me.tbTalla18.DataField = "Talla18"
            Me.tbTalla18.Height = 0.197!
            Me.tbTalla18.Left = 9.614354!
            Me.tbTalla18.Name = "tbTalla18"
            Me.tbTalla18.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla18.Text = "Ta18"
            Me.tbTalla18.Top = 0!
            Me.tbTalla18.Width = 0.3!
            '
            'tbTalla19
            '
            Me.tbTalla19.DataField = "Talla19"
            Me.tbTalla19.Height = 0.197!
            Me.tbTalla19.Left = 9.908355!
            Me.tbTalla19.Name = "tbTalla19"
            Me.tbTalla19.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla19.Text = "Ta19"
            Me.tbTalla19.Top = 0!
            Me.tbTalla19.Width = 0.3!
            '
            'tbTotal19
            '
            Me.tbTotal19.DataField = "Total19"
            Me.tbTotal19.Height = 0.197!
            Me.tbTotal19.Left = 9.899111!
            Me.tbTotal19.Name = "tbTotal19"
            Me.tbTotal19.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal19.Text = "To19"
            Me.tbTotal19.Top = 0.2593504!
            Me.tbTotal19.Width = 0.3!
            '
            'tbTotal20
            '
            Me.tbTotal20.DataField = "Total20"
            Me.tbTotal20.Height = 0.197!
            Me.tbTotal20.Left = 10.21!
            Me.tbTotal20.Name = "tbTotal20"
            Me.tbTotal20.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTotal20.Text = "To20"
            Me.tbTotal20.Top = 0.259!
            Me.tbTotal20.Width = 0.3!
            '
            'tbTalla20
            '
            Me.tbTalla20.DataField = "Talla20"
            Me.tbTalla20.Height = 0.197!
            Me.tbTalla20.Left = 10.21935!
            Me.tbTalla20.Name = "tbTalla20"
            Me.tbTalla20.Style = "text-align: right; font-size: 8.25pt; font-family: Arial"
            Me.tbTalla20.Text = "Ta20"
            Me.tbTalla20.Top = 0!
            Me.tbTalla20.Width = 0.3!
            '
            'Line36
            '
            Me.Line36.Height = 0.469!
            Me.Line36.Left = 10.50694!
            Me.Line36.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.Line36.LineWeight = 1!
            Me.Line36.Name = "Line36"
            Me.Line36.Top = 0!
            Me.Line36.Width = 5.531311E-05!
            Me.Line36.X1 = 10.50694!
            Me.Line36.X2 = 10.507!
            Me.Line36.Y1 = 0!
            Me.Line36.Y2 = 0.469!
            '
            'lneBottomTable
            '
            Me.lneBottomTable.Height = 0.003441006!
            Me.lneBottomTable.Left = 0.7874014!
            Me.lneBottomTable.LineColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
            Me.lneBottomTable.LineWeight = 1!
            Me.lneBottomTable.Name = "lneBottomTable"
            Me.lneBottomTable.Top = 0.469!
            Me.lneBottomTable.Width = 9.717599!
            Me.lneBottomTable.X1 = 0.7874014!
            Me.lneBottomTable.X2 = 10.505!
            Me.lneBottomTable.Y1 = 0.472441!
            Me.lneBottomTable.Y2 = 0.469!
            '
            'tbCodigo
            '
            Me.tbCodigo.DataField = "Codigo"
            Me.tbCodigo.Height = 0.1968504!
            Me.tbCodigo.Left = 0.7687007!
            Me.tbCodigo.MultiLine = false
            Me.tbCodigo.Name = "tbCodigo"
            Me.tbCodigo.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Arial"
            Me.tbCodigo.Text = "WWWWWWWWWWWWWWWWWWWA"
            Me.tbCodigo.Top = 0!
            Me.tbCodigo.Width = 1.653543!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Descripcion"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 0.7593507!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: left; font-size: 8.25pt; font-family: Arial"
            Me.TextBox1.Top = 0.25!
            Me.TextBox1.Width = 2.311516!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 8.46457!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8.25pt; font-family: Arial; vertical-align: middle"
            Me.Label2.Text = "Página"
            Me.Label2.Top = 0.07185042!
            Me.Label2.Width = 0.5078735!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 9.448819!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8.25pt; font-family: Arial; vertical-align: middle"& _ 
                ""
            Me.Label3.Text = "de"
            Me.Label3.Top = 0.07185042!
            Me.Label3.Width = 0.2952757!
            '
            'tbPageNumber
            '
            Me.tbPageNumber.Height = 0.2!
            Me.tbPageNumber.Left = 8.956695!
            Me.tbPageNumber.Name = "tbPageNumber"
            Me.tbPageNumber.Style = "text-align: center; font-size: 8.25pt; font-family: Arial; vertical-align: middle"& _ 
                ""
            Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageNumber.Text = "####"
            Me.tbPageNumber.Top = 0.07185042!
            Me.tbPageNumber.Width = 0.492126!
            '
            'tbPageCount
            '
            Me.tbPageCount.Height = 0.2!
            Me.tbPageCount.Left = 9.744097!
            Me.tbPageCount.Name = "tbPageCount"
            Me.tbPageCount.Style = "text-align: center; font-size: 8.25pt; font-family: Arial; vertical-align: middle"& _ 
                ""
            Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageCount.Text = "####"
            Me.tbPageCount.Top = 0.07185042!
            Me.tbPageCount.Width = 0.492126!
            '
            'Label4
            '
            Me.Label4.Height = 0.1968504!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.9375!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 8.25pt; font-family: Arial"
            Me.Label4.Text = "Comercial Dportenis, S.A. de C.V."
            Me.Label4.Top = 0.07185042!
            Me.Label4.Width = 2.362205!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.1965278!
            Me.PageSettings.Margins.Left = 0.1965278!
            Me.PageSettings.Margins.Right = 0.1965278!
            Me.PageSettings.Margins.Top = 0.1965278!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 10.55208!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size-adjust: inherit; font-stretch: inherit; font-size: 14pt", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-variant: inherit; font-weight: bold; font-size-adjust: inherit; font-stretch"& _ 
                        ": inherit; font-style: inherit; font-size: 12pt", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size-adjust: inherit; font-stretch: inherit; font-size: 10pt", "Heading3", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-weight: bold; text-align: center; vertical-align: middle; background-color: "& _ 
                        "Silver", "TableHeader", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("vertical-align: middle", "TableTextCell", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("vertical-align: middle; text-align: right", "TableNumberCell", "Normal"))
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportDate,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbColor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalA,System.ComponentModel.ISupportInitialize).EndInit
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
            CType(Me.tbCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Detail.AddBookmark("Reporte de Inventario Normal\Pagína " & Me.PageNumber.ToString & "\")

    End Sub
End Class
