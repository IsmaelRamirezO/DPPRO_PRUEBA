Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class InventarioNormalActiveReport
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label3 As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private TextBox8 As TextBox = Nothing
	Private TextBox9 As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private TextBox15 As TextBox = Nothing
	Private TextBox16 As TextBox = Nothing
	Private TextBox17 As TextBox = Nothing
	Private TextBox18 As TextBox = Nothing
	Private TextBox19 As TextBox = Nothing
	Private TextBox20 As TextBox = Nothing
	Private TextBox21 As TextBox = Nothing
	Private TextBox22 As TextBox = Nothing
	Private TextBox23 As TextBox = Nothing
	Private TextBox24 As TextBox = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private Line12 As Line = Nothing
	Private Line13 As Line = Nothing
	Private Line14 As Line = Nothing
	Private Line15 As Line = Nothing
	Private Line16 As Line = Nothing
	Private Line17 As Line = Nothing
	Private Line18 As Line = Nothing
	Private Line19 As Line = Nothing
	Private Line20 As Line = Nothing
	Private Line21 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioNormalActiveReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox9 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox18 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox19 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox20 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox21 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox22 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox23 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox24 = New DataDynamics.ActiveReports.TextBox()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.Line13 = New DataDynamics.ActiveReports.Line()
            Me.Line14 = New DataDynamics.ActiveReports.Line()
            Me.Line15 = New DataDynamics.ActiveReports.Line()
            Me.Line16 = New DataDynamics.ActiveReports.Line()
            Me.Line17 = New DataDynamics.ActiveReports.Line()
            Me.Line18 = New DataDynamics.ActiveReports.Line()
            Me.Line19 = New DataDynamics.ActiveReports.Line()
            Me.Line20 = New DataDynamics.ActiveReports.Line()
            Me.Line21 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox9, Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox13, Me.TextBox5, Me.TextBox14, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.TextBox22, Me.TextBox23, Me.TextBox24, Me.Line10, Me.Line11, Me.Line12, Me.Line13, Me.Line14, Me.Line15, Me.Line16, Me.Line17, Me.Line18, Me.Line19, Me.Line20, Me.Line21})
            Me.Detail.Height = 0.3958333!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.lblReportTitle, Me.Label1, Me.Label2})
            Me.PageHeader.Height = 1.197222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label3
            '
            Me.Label3.ClassName = "FieldHeader"
            Me.Label3.Height = 0.3937008!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.624016!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = ""
            Me.Label3.Text = "Tallas"
            Me.Label3.Top = 0.7874014!
            Me.Label3.Width = 4.822834!
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.2952756!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 0.03592517!
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "vertical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Inventario"
            Me.lblReportTitle.Top = 0.0492126!
            Me.lblReportTitle.Width = 2.559056!
            '
            'Label1
            '
            Me.Label1.ClassName = "FieldHeader"
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0492126!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Código"
            Me.Label1.Top = 0.7874014!
            Me.Label1.Width = 1.574803!
            '
            'Label2
            '
            Me.Label2.ClassName = "FieldHeader"
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0492126!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "Descripción"
            Me.Label2.Top = 0.9842521!
            Me.Label2.Width = 1.574803!
            '
            'TextBox1
            '
            Me.TextBox1.ClassName = "FieldData"
            Me.TextBox1.DataField = "Codigo"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 0.0492126!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Text = "TextBox1"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 1.427165!
            '
            'TextBox2
            '
            Me.TextBox2.ClassName = "FieldData"
            Me.TextBox2.DataField = "Descripcion"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.04921269!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0.1968504!
            Me.TextBox2.Width = 1.427165!
            '
            'TextBox3
            '
            Me.TextBox3.ClassName = "FieldData"
            Me.TextBox3.DataField = "Talla01"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 1.574803!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox3.Text = "00.00"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 0.3937008!
            '
            'TextBox4
            '
            Me.TextBox4.ClassName = "FieldData"
            Me.TextBox4.DataField = "Talla02"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 1.968504!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox4.Text = "00.00"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 0.3937008!
            '
            'TextBox6
            '
            Me.TextBox6.ClassName = "FieldData"
            Me.TextBox6.DataField = "Talla04"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 2.755905!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox6.Text = "00.00"
            Me.TextBox6.Top = 0!
            Me.TextBox6.Width = 0.3937008!
            '
            'TextBox7
            '
            Me.TextBox7.ClassName = "FieldData"
            Me.TextBox7.DataField = "Talla05"
            Me.TextBox7.Height = 0.2!
            Me.TextBox7.Left = 3.149606!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox7.Text = "00.00"
            Me.TextBox7.Top = 0!
            Me.TextBox7.Width = 0.3937008!
            '
            'TextBox8
            '
            Me.TextBox8.ClassName = "FieldData"
            Me.TextBox8.DataField = "Talla06"
            Me.TextBox8.Height = 0.2!
            Me.TextBox8.Left = 3.543307!
            Me.TextBox8.Name = "TextBox8"
            Me.TextBox8.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox8.Text = "00.00"
            Me.TextBox8.Top = 0!
            Me.TextBox8.Width = 0.3937008!
            '
            'TextBox9
            '
            Me.TextBox9.ClassName = "FieldData"
            Me.TextBox9.DataField = "Talla07"
            Me.TextBox9.Height = 0.2!
            Me.TextBox9.Left = 3.937008!
            Me.TextBox9.Name = "TextBox9"
            Me.TextBox9.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox9.Text = "00.00"
            Me.TextBox9.Top = 0!
            Me.TextBox9.Width = 0.3937008!
            '
            'TextBox10
            '
            Me.TextBox10.ClassName = "FieldData"
            Me.TextBox10.DataField = "Talla08"
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 4.330709!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox10.Text = "00.00"
            Me.TextBox10.Top = 0!
            Me.TextBox10.Width = 0.3937008!
            '
            'TextBox11
            '
            Me.TextBox11.ClassName = "FieldData"
            Me.TextBox11.DataField = "Talla09"
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 4.72441!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox11.Text = "00.00"
            Me.TextBox11.Top = 0!
            Me.TextBox11.Width = 0.3937008!
            '
            'TextBox12
            '
            Me.TextBox12.ClassName = "FieldData"
            Me.TextBox12.DataField = "Talla10"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 5.118111!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox12.Text = "00.00"
            Me.TextBox12.Top = 0!
            Me.TextBox12.Width = 0.3937008!
            '
            'TextBox13
            '
            Me.TextBox13.ClassName = "FieldData"
            Me.TextBox13.DataField = "Talla11"
            Me.TextBox13.Height = 0.2!
            Me.TextBox13.Left = 5.511812!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox13.Text = "00.00"
            Me.TextBox13.Top = 0!
            Me.TextBox13.Width = 0.3937008!
            '
            'TextBox5
            '
            Me.TextBox5.ClassName = "FieldData"
            Me.TextBox5.DataField = "Talla03"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 2.362205!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; background-color: Gainsbo"& _ 
                "ro"
            Me.TextBox5.Text = "00.00"
            Me.TextBox5.Top = 0!
            Me.TextBox5.Width = 0.3937008!
            '
            'TextBox14
            '
            Me.TextBox14.ClassName = "FieldData"
            Me.TextBox14.DataField = "Total01"
            Me.TextBox14.Height = 0.2!
            Me.TextBox14.Left = 1.574803!
            Me.TextBox14.Name = "TextBox14"
            Me.TextBox14.Style = "text-align: right"
            Me.TextBox14.Text = "0,000"
            Me.TextBox14.Top = 0.1968504!
            Me.TextBox14.Width = 0.3937007!
            '
            'TextBox15
            '
            Me.TextBox15.ClassName = "FieldData"
            Me.TextBox15.DataField = "Total02"
            Me.TextBox15.Height = 0.2!
            Me.TextBox15.Left = 1.968504!
            Me.TextBox15.Name = "TextBox15"
            Me.TextBox15.Style = "text-align: right"
            Me.TextBox15.Text = "0,000"
            Me.TextBox15.Top = 0.1968504!
            Me.TextBox15.Width = 0.3937007!
            '
            'TextBox16
            '
            Me.TextBox16.ClassName = "FieldData"
            Me.TextBox16.DataField = "Total03"
            Me.TextBox16.Height = 0.2!
            Me.TextBox16.Left = 2.362205!
            Me.TextBox16.Name = "TextBox16"
            Me.TextBox16.Style = "text-align: right"
            Me.TextBox16.Text = "0,000"
            Me.TextBox16.Top = 0.1968504!
            Me.TextBox16.Width = 0.3937007!
            '
            'TextBox17
            '
            Me.TextBox17.ClassName = "FieldData"
            Me.TextBox17.DataField = "Total04"
            Me.TextBox17.Height = 0.2!
            Me.TextBox17.Left = 2.755905!
            Me.TextBox17.Name = "TextBox17"
            Me.TextBox17.Style = "text-align: right"
            Me.TextBox17.Text = "0,000"
            Me.TextBox17.Top = 0.1968504!
            Me.TextBox17.Width = 0.3937007!
            '
            'TextBox18
            '
            Me.TextBox18.ClassName = "FieldData"
            Me.TextBox18.DataField = "Total05"
            Me.TextBox18.Height = 0.2!
            Me.TextBox18.Left = 3.149606!
            Me.TextBox18.Name = "TextBox18"
            Me.TextBox18.Style = "text-align: right"
            Me.TextBox18.Text = "0,000"
            Me.TextBox18.Top = 0.1968504!
            Me.TextBox18.Width = 0.3937007!
            '
            'TextBox19
            '
            Me.TextBox19.ClassName = "FieldData"
            Me.TextBox19.DataField = "Total06"
            Me.TextBox19.Height = 0.2!
            Me.TextBox19.Left = 3.543307!
            Me.TextBox19.Name = "TextBox19"
            Me.TextBox19.Style = "text-align: right"
            Me.TextBox19.Text = "0,000"
            Me.TextBox19.Top = 0.1968504!
            Me.TextBox19.Width = 0.3937007!
            '
            'TextBox20
            '
            Me.TextBox20.ClassName = "FieldData"
            Me.TextBox20.DataField = "Total07"
            Me.TextBox20.Height = 0.2!
            Me.TextBox20.Left = 3.937008!
            Me.TextBox20.Name = "TextBox20"
            Me.TextBox20.Style = "text-align: right"
            Me.TextBox20.Text = "0,000"
            Me.TextBox20.Top = 0.1968504!
            Me.TextBox20.Width = 0.3937007!
            '
            'TextBox21
            '
            Me.TextBox21.ClassName = "FieldData"
            Me.TextBox21.DataField = "Total08"
            Me.TextBox21.Height = 0.2!
            Me.TextBox21.Left = 4.330709!
            Me.TextBox21.Name = "TextBox21"
            Me.TextBox21.Style = "text-align: right"
            Me.TextBox21.Text = "0,000"
            Me.TextBox21.Top = 0.1968504!
            Me.TextBox21.Width = 0.3937007!
            '
            'TextBox22
            '
            Me.TextBox22.ClassName = "FieldData"
            Me.TextBox22.DataField = "Total09"
            Me.TextBox22.Height = 0.2!
            Me.TextBox22.Left = 4.72441!
            Me.TextBox22.Name = "TextBox22"
            Me.TextBox22.Style = "text-align: right"
            Me.TextBox22.Text = "0,000"
            Me.TextBox22.Top = 0.1968504!
            Me.TextBox22.Width = 0.3937007!
            '
            'TextBox23
            '
            Me.TextBox23.ClassName = "FieldData"
            Me.TextBox23.DataField = "Total10"
            Me.TextBox23.Height = 0.2!
            Me.TextBox23.Left = 5.118111!
            Me.TextBox23.Name = "TextBox23"
            Me.TextBox23.Style = "text-align: right"
            Me.TextBox23.Text = "0,000"
            Me.TextBox23.Top = 0.1968504!
            Me.TextBox23.Width = 0.3937007!
            '
            'TextBox24
            '
            Me.TextBox24.ClassName = "FieldData"
            Me.TextBox24.DataField = "Total11"
            Me.TextBox24.Height = 0.2!
            Me.TextBox24.Left = 5.511812!
            Me.TextBox24.Name = "TextBox24"
            Me.TextBox24.Style = "text-align: right"
            Me.TextBox24.Text = "0,000"
            Me.TextBox24.Top = 0.1968504!
            Me.TextBox24.Width = 0.3937007!
            '
            'Line10
            '
            Me.Line10.Height = 0.3937005!
            Me.Line10.Left = 1.574803!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 1.574803!
            Me.Line10.X2 = 1.574803!
            Me.Line10.Y1 = 0!
            Me.Line10.Y2 = 0.3937005!
            '
            'Line11
            '
            Me.Line11.Height = 0.3937005!
            Me.Line11.Left = 1.968504!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 0!
            Me.Line11.Width = 0!
            Me.Line11.X1 = 1.968504!
            Me.Line11.X2 = 1.968504!
            Me.Line11.Y1 = 0!
            Me.Line11.Y2 = 0.3937005!
            '
            'Line12
            '
            Me.Line12.Height = 0.3937005!
            Me.Line12.Left = 2.364337!
            Me.Line12.LineWeight = 1!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0!
            Me.Line12.Width = 0!
            Me.Line12.X1 = 2.364337!
            Me.Line12.X2 = 2.364337!
            Me.Line12.Y1 = 0!
            Me.Line12.Y2 = 0.3937005!
            '
            'Line13
            '
            Me.Line13.Height = 0.3937005!
            Me.Line13.Left = 2.760171!
            Me.Line13.LineWeight = 1!
            Me.Line13.Name = "Line13"
            Me.Line13.Top = 0!
            Me.Line13.Width = 0!
            Me.Line13.X1 = 2.760171!
            Me.Line13.X2 = 2.760171!
            Me.Line13.Y1 = 0!
            Me.Line13.Y2 = 0.3937005!
            '
            'Line14
            '
            Me.Line14.Height = 0.3937005!
            Me.Line14.Left = 3.145587!
            Me.Line14.LineWeight = 1!
            Me.Line14.Name = "Line14"
            Me.Line14.Top = 0!
            Me.Line14.Width = 0!
            Me.Line14.X1 = 3.145587!
            Me.Line14.X2 = 3.145587!
            Me.Line14.Y1 = 0!
            Me.Line14.Y2 = 0.3937005!
            '
            'Line15
            '
            Me.Line15.Height = 0.3937005!
            Me.Line15.Left = 3.541421!
            Me.Line15.LineWeight = 1!
            Me.Line15.Name = "Line15"
            Me.Line15.Top = 0!
            Me.Line15.Width = 0!
            Me.Line15.X1 = 3.541421!
            Me.Line15.X2 = 3.541421!
            Me.Line15.Y1 = 0!
            Me.Line15.Y2 = 0.3937005!
            '
            'Line16
            '
            Me.Line16.Height = 0.3937005!
            Me.Line16.Left = 3.937254!
            Me.Line16.LineWeight = 1!
            Me.Line16.Name = "Line16"
            Me.Line16.Top = 0!
            Me.Line16.Width = 0!
            Me.Line16.X1 = 3.937254!
            Me.Line16.X2 = 3.937254!
            Me.Line16.Y1 = 0!
            Me.Line16.Y2 = 0.3937005!
            '
            'Line17
            '
            Me.Line17.Height = 0.3937005!
            Me.Line17.Left = 4.333087!
            Me.Line17.LineWeight = 1!
            Me.Line17.Name = "Line17"
            Me.Line17.Top = 0!
            Me.Line17.Width = 0!
            Me.Line17.X1 = 4.333087!
            Me.Line17.X2 = 4.333087!
            Me.Line17.Y1 = 0!
            Me.Line17.Y2 = 0.3937005!
            '
            'Line18
            '
            Me.Line18.Height = 0.3937005!
            Me.Line18.Left = 4.728921!
            Me.Line18.LineWeight = 1!
            Me.Line18.Name = "Line18"
            Me.Line18.Top = 0!
            Me.Line18.Width = 0!
            Me.Line18.X1 = 4.728921!
            Me.Line18.X2 = 4.728921!
            Me.Line18.Y1 = 0!
            Me.Line18.Y2 = 0.3937005!
            '
            'Line19
            '
            Me.Line19.Height = 0.3937005!
            Me.Line19.Left = 5.114337!
            Me.Line19.LineWeight = 1!
            Me.Line19.Name = "Line19"
            Me.Line19.Top = 0!
            Me.Line19.Width = 0!
            Me.Line19.X1 = 5.114337!
            Me.Line19.X2 = 5.114337!
            Me.Line19.Y1 = 0!
            Me.Line19.Y2 = 0.3937005!
            '
            'Line20
            '
            Me.Line20.Height = 0.3937005!
            Me.Line20.Left = 5.510171!
            Me.Line20.LineWeight = 1!
            Me.Line20.Name = "Line20"
            Me.Line20.Top = 0!
            Me.Line20.Width = 0!
            Me.Line20.X1 = 5.510171!
            Me.Line20.X2 = 5.510171!
            Me.Line20.Y1 = 0!
            Me.Line20.Y2 = 0.3937005!
            '
            'Line21
            '
            Me.Line21.Height = 0.3937005!
            Me.Line21.Left = 5.906004!
            Me.Line21.LineWeight = 1!
            Me.Line21.Name = "Line21"
            Me.Line21.Top = 0!
            Me.Line21.Width = 0!
            Me.Line21.X1 = 5.906004!
            Me.Line21.X2 = 5.906004!
            Me.Line21.Y1 = 0!
            Me.Line21.Y2 = 0.3937005!
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
            Me.PrintWidth = 7.197917!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-size-adjus"& _ 
                        "t: inherit; font-stretch: inherit; font-size: 14pt; font-weight: bold", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-variant: inherit; font-size-adjust: inherit; font-stretch: inherit; font-siz"& _ 
                        "e: 12pt; font-style: inherit; font-weight: bold", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size-adjust: inherit; font-stretch: inherit; font-size: 10pt", "Heading3", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-weight: bold; color: #FFFFFF; background-color: #404040; vertical-align: mid"& _ 
                        "dle", "FieldHeader", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("vertical-align: middle", "FieldData", "Normal"))
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

	#End Region
End Class
