Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ReportesGlobalesInventarioReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal strMes As String, _
                    ByVal strMarca As String, _
                    ByVal strLinea As String, _
                    ByVal strFamilia As String, _
                    ByVal dtGlobal As DataTable, _
                    ByVal Sucursal As String)

        MyBase.New()

        InitializeComponent()

        lblReporte.Text = "REPORTE DE AUDITORIA DEL MES DE : " & strMes
        If strMarca <> "" Then
            lblpor.Text = "MARCA : " & strMarca & " FAMILIA : " & strFamilia & " LINEA : " & strLinea
        ElseIf strFamilia = "" And strLinea = "" Then
            lblpor.Text = "TODAS LAS MARCAS, LINEAS, FAMILIAS"
        Else
            lblpor.Text = "FAMILIA : " & strFamilia & " LINEA : " & strLinea
        End If
        lblSucursal.Text = "SUCURSAL : " & Sucursal
        lblFecha.Text = Date.Today
        Me.DataSource = dtGlobal
        Me.DataMember = "Global"

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblReporte As Label = Nothing
	Private lblpor As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private txtCodigo As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private Label7 As Label = Nothing
	Private TextBox5 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesGlobalesInventarioReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblReporte = New DataDynamics.ActiveReports.Label()
            Me.lblpor = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblpor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.TextBox2, Me.TextBox3, Me.TextBox4})
            Me.Detail.Height = 0.3333333!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblReporte, Me.lblpor, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.lblSucursal, Me.lblFecha, Me.Line1, Me.Line2, Me.Line3, Me.Line4})
            Me.PageHeader.Height = 1.270833!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label7, Me.TextBox5, Me.TextBox6})
            Me.GroupFooter1.Height = 0.3958333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.1875!
            Me.Shape1.Left = 0.0625!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.0625!
            Me.Shape1.Width = 6.375!
            '
            'lblReporte
            '
            Me.lblReporte.Height = 0.2!
            Me.lblReporte.HyperLink = Nothing
            Me.lblReporte.Left = 1.0625!
            Me.lblReporte.Name = "lblReporte"
            Me.lblReporte.Style = "text-align: center"
            Me.lblReporte.Text = "REPORTE DE AUDITORIA DEL MES DE :"
            Me.lblReporte.Top = 0.125!
            Me.lblReporte.Width = 3.9375!
            '
            'lblpor
            '
            Me.lblpor.Height = 0.2!
            Me.lblpor.HyperLink = Nothing
            Me.lblpor.Left = 0.6875!
            Me.lblpor.Name = "lblpor"
            Me.lblpor.Style = "text-align: center; vertical-align: top"
            Me.lblpor.Text = "POR MARCA / LINEA / FAMILIA"
            Me.lblpor.Top = 0.375!
            Me.lblpor.Width = 4.875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.1875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center"
            Me.Label3.Text = "Código"
            Me.Label3.Top = 1!
            Me.Label3.Width = 0.6875!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.0625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center"
            Me.Label4.Text = "Nombre"
            Me.Label4.Top = 1!
            Me.Label4.Width = 2!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "Cantidad"
            Me.Label5.Top = 1!
            Me.Label5.Width = 1.375!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Costo"
            Me.Label6.Top = 1!
            Me.Label6.Width = 1.375!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.6875!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center; vertical-align: top"
            Me.lblSucursal.Text = "SUCURSAL : "
            Me.lblSucursal.Top = 0.625!
            Me.lblSucursal.Width = 4.875!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = ""
            Me.lblFecha.Text = ""
            Me.lblFecha.Top = 0.125!
            Me.lblFecha.Width = 0.8125!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0625!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1!
            Me.Line1.Width = 6.375!
            Me.Line1.X1 = 6.4375!
            Me.Line1.X2 = 0.0625!
            Me.Line1.Y1 = 1!
            Me.Line1.Y2 = 1!
            '
            'Line2
            '
            Me.Line2.Height = 0.25!
            Me.Line2.Left = 4.756945!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.006944!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 4.756945!
            Me.Line2.X2 = 4.756945!
            Me.Line2.Y1 = 1.006944!
            Me.Line2.Y2 = 1.256944!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 3.319444!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.006944!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 3.319444!
            Me.Line3.X2 = 3.319444!
            Me.Line3.Y1 = 1.006944!
            Me.Line3.Y2 = 1.256944!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 1.006944!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.006944!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 1.006944!
            Me.Line4.X2 = 1.006944!
            Me.Line4.Y1 = 1.006944!
            Me.Line4.Y2 = 1.256944!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.2!
            Me.txtCodigo.Left = 0.25!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: center"
            Me.txtCodigo.Text = "TextBox1"
            Me.txtCodigo.Top = 0.0625!
            Me.txtCodigo.Width = 0.625!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Nombre"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 1.0625!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0.0625!
            Me.TextBox2.Width = 2.1875!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "Cantidad"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 3.4375!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right"
            Me.TextBox3.Text = "TextBox3"
            Me.TextBox3.Top = 0.0625!
            Me.TextBox3.Width = 1.1875!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Costo"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 4.8125!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: right"
            Me.TextBox4.Text = "TextBox4"
            Me.TextBox4.Top = 0.0625!
            Me.TextBox4.Width = 1.5625!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0.0625!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.0625!
            Me.Shape2.Width = 6.375!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = ""
            Me.Label7.Text = "TOTALES"
            Me.Label7.Top = 0.125!
            Me.Label7.Width = 1.3125!
            '
            'TextBox5
            '
            Me.TextBox5.DataField = "Cantidad"
            Me.TextBox5.Height = 0.2!
            Me.TextBox5.Left = 3.4375!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "text-align: right"
            Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox5.Text = "TextBox5"
            Me.TextBox5.Top = 0.125!
            Me.TextBox5.Width = 1.1875!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "Costo"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 4.8125!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
            Me.TextBox6.Style = "text-align: right"
            Me.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox6.Text = "TextBox6"
            Me.TextBox6.Top = 0.125!
            Me.TextBox6.Width = 1.5625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.4097222!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
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
            CType(Me.lblReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblpor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
