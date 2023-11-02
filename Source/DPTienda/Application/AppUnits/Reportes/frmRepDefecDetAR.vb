Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class frmRepDefecDetAR
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dtFechaIni As String, _
                    ByVal dtFechaFin As String, _
                    ByVal dtGlobal As DataTable, _
                    ByVal Sucursal As String)
        MyBase.New()

        InitializeComponent()

        lblpor.Text = "DE : " & dtFechaIni & " HASTA : " & dtFechaFin

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
	Private Label10 As Label = Nothing
	Private Label9 As Label = Nothing
	Private lblReporte As Label = Nothing
	Private lblpor As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line1 As Line = Nothing
	Private Shape1 As Shape = Nothing
	Private txtCodigo As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private TextBox6 As TextBox = Nothing
	Private TextBox7 As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private Label7 As Label = Nothing
	Private TextBox5 As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDefecDetAR))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.lblReporte = New DataDynamics.ActiveReports.Label()
            Me.lblpor = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
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
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox6, Me.TextBox7})
            Me.Detail.Height = 0.3125!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.Label9, Me.lblReporte, Me.lblpor, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.lblSucursal, Me.lblFecha, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line1, Me.Shape1})
            Me.PageHeader.Height = 1.270833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.tbPageNumber, Me.Label8, Me.tbPageCount})
            Me.PageFooter.Height = 0.3847222!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label7, Me.TextBox5})
            Me.GroupFooter1.Height = 0.3958333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 6.3125!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center"
            Me.Label10.Text = "Fecha"
            Me.Label10.Top = 1!
            Me.Label10.Width = 0.8125!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.9375!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "Talla"
            Me.Label9.Top = 1!
            Me.Label9.Width = 0.375!
            '
            'lblReporte
            '
            Me.lblReporte.Height = 0.2!
            Me.lblReporte.HyperLink = Nothing
            Me.lblReporte.Left = 1.6875!
            Me.lblReporte.Name = "lblReporte"
            Me.lblReporte.Style = "text-align: center"
            Me.lblReporte.Text = "REPORTE DE ARTÍCULOS DEFECTUOSOS A DETALLE"
            Me.lblReporte.Top = 0.125!
            Me.lblReporte.Width = 3.9375!
            '
            'lblpor
            '
            Me.lblpor.Height = 0.2!
            Me.lblpor.HyperLink = Nothing
            Me.lblpor.Left = 1.1875!
            Me.lblpor.Name = "lblpor"
            Me.lblpor.Style = "text-align: center; vertical-align: top"
            Me.lblpor.Text = ""
            Me.lblpor.Top = 0.375!
            Me.lblpor.Width = 4.875!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.125!
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
            Me.Label4.Left = 1.3125!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center"
            Me.Label4.Text = "Descripcion"
            Me.Label4.Top = 1!
            Me.Label4.Width = 2!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4.4375!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "Cantidad"
            Me.Label5.Top = 1!
            Me.Label5.Width = 0.625!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Motivo del Marcado"
            Me.Label6.Top = 1!
            Me.Label6.Width = 1.25!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1.1875!
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
            'Line2
            '
            Me.Line2.Height = 0.25!
            Me.Line2.Left = 5.046315!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 1.006944!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 5.046315!
            Me.Line2.X2 = 5.046315!
            Me.Line2.Y1 = 1.006944!
            Me.Line2.Y2 = 1.256944!
            '
            'Line3
            '
            Me.Line3.Height = 0.25!
            Me.Line3.Left = 3.943953!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.006944!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 3.943953!
            Me.Line3.X2 = 3.943953!
            Me.Line3.Y1 = 1.006944!
            Me.Line3.Y2 = 1.256944!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 1.266787!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.006944!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 1.266787!
            Me.Line4.X2 = 1.266787!
            Me.Line4.Y1 = 1.006944!
            Me.Line4.Y2 = 1.256944!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 4.416393!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 1.006944!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 4.416393!
            Me.Line5.X2 = 4.416393!
            Me.Line5.Y1 = 1.006944!
            Me.Line5.Y2 = 1.256944!
            '
            'Line6
            '
            Me.Line6.Height = 0.25!
            Me.Line6.Left = 6.306157!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 1.006944!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 6.306157!
            Me.Line6.X2 = 6.306157!
            Me.Line6.Y1 = 1.006944!
            Me.Line6.Y2 = 1.256944!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0625!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 1!
            Me.Line1.Width = 7.177167!
            Me.Line1.X1 = 7.239667!
            Me.Line1.X2 = 0.0625!
            Me.Line1.Y1 = 1!
            Me.Line1.Y2 = 1!
            '
            'Shape1
            '
            Me.Shape1.Height = 1.1875!
            Me.Shape1.Left = 0.06250001!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.0625!
            Me.Shape1.Width = 7.181597!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.2!
            Me.txtCodigo.Left = 0.125!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: center"
            Me.txtCodigo.Text = "TextBox1"
            Me.txtCodigo.Top = 0.0625!
            Me.txtCodigo.Width = 1.125!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Descripcion"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 1.375!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0.0625!
            Me.TextBox2.Width = 2.5!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "Cantidad"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 4.4375!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right"
            Me.TextBox3.Text = "TextBox3"
            Me.TextBox3.Top = 0.0625!
            Me.TextBox3.Width = 0.5!
            '
            'TextBox4
            '
            Me.TextBox4.DataField = "Motivo"
            Me.TextBox4.Height = 0.2!
            Me.TextBox4.Left = 5.0625!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: left"
            Me.TextBox4.Text = "TextBox4"
            Me.TextBox4.Top = 0.0625!
            Me.TextBox4.Width = 1.25!
            '
            'TextBox6
            '
            Me.TextBox6.DataField = "Talla"
            Me.TextBox6.Height = 0.2!
            Me.TextBox6.Left = 3.9375!
            Me.TextBox6.Name = "TextBox6"
            Me.TextBox6.Text = "TextBox6"
            Me.TextBox6.Top = 0.0625!
            Me.TextBox6.Width = 0.5!
            '
            'TextBox7
            '
            Me.TextBox7.DataField = "Fecha"
            Me.TextBox7.Height = 0.2!
            Me.TextBox7.Left = 6.3125!
            Me.TextBox7.Name = "TextBox7"
            Me.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat")
            Me.TextBox7.Style = "text-align: right"
            Me.TextBox7.Text = "TextBox7"
            Me.TextBox7.Top = 0.0625!
            Me.TextBox7.Width = 0.875!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0.0625!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0.0625!
            Me.Shape2.Width = 7.181597!
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
            Me.TextBox5.Left = 4.1875!
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
            Me.TextBox5.Style = "text-align: right"
            Me.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox5.Text = "TextBox5"
            Me.TextBox5.Top = 0.125!
            Me.TextBox5.Width = 0.75!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.346949!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; font-size: 8pt; vertical-align: middle"
            Me.Label2.Text = "Página"
            Me.Label2.Top = 0.07874014!
            Me.Label2.Width = 0.5078735!
            '
            'tbPageNumber
            '
            Me.tbPageNumber.Height = 0.2!
            Me.tbPageNumber.Left = 5.901576!
            Me.tbPageNumber.Name = "tbPageNumber"
            Me.tbPageNumber.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageNumber.Text = "####"
            Me.tbPageNumber.Top = 0.07874014!
            Me.tbPageNumber.Width = 0.492126!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 6.393699!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label8.Text = "de"
            Me.Label8.Top = 0.07874014!
            Me.Label8.Width = 0.2952757!
            '
            'tbPageCount
            '
            Me.tbPageCount.Height = 0.2!
            Me.tbPageCount.Left = 6.751476!
            Me.tbPageCount.Name = "tbPageCount"
            Me.tbPageCount.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; vertical-align: middle"
            Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.tbPageCount.Text = "####"
            Me.tbPageCount.Top = 0.07874014!
            Me.tbPageCount.Width = 0.492126!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.4097222!
            Me.PageSettings.Margins.Right = 0.4097222!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.322917!
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
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
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
            CType(Me.TextBox6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageNumber,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbPageCount,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
