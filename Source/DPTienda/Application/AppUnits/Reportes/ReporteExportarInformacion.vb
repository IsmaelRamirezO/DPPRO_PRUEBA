Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ReporteExportarInformacion
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByRef ds As DataSet, ByVal Fecha As Date, ByVal Hora As String)
        MyBase.New()

        InitializeComponent()

        LblFecha.Text = Fecha
        LblHora.Text = Hora

        Me.DataSource = ds.Tables(0)

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private LblFecha As Label = Nothing
	Private Label2 As Label = Nothing
	Private LblHora As Label = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private TextBox4 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteExportarInformacion))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.LblHora = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblHora,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.LblFecha, Me.Label2, Me.LblHora})
            Me.ReportHeader.Height = 0.25!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox4})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = ""
            Me.Label1.Text = "Resultado de la Exportación realizada el "
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.5625!
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1875!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 2.625!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = ""
            Me.LblFecha.Text = ""
            Me.LblFecha.Top = 0.0625!
            Me.LblFecha.Width = 0.8125!
            '
            'Label2
            '
            Me.Label2.Height = 0.1875!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 3.4375!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = ""
            Me.Label2.Text = "a las "
            Me.Label2.Top = 0.0625!
            Me.Label2.Width = 0.375!
            '
            'LblHora
            '
            Me.LblHora.Height = 0.1875!
            Me.LblHora.HyperLink = Nothing
            Me.LblHora.Left = 3.8125!
            Me.LblHora.Name = "LblHora"
            Me.LblHora.Style = ""
            Me.LblHora.Text = ""
            Me.LblHora.Top = 0.0625!
            Me.LblHora.Width = 1.1875!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Familia"
            Me.TextBox1.Height = 0.1875!
            Me.TextBox1.Left = 0.0625!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Text = "TextBox1"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.375!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Nombre"
            Me.TextBox2.Height = 0.1875!
            Me.TextBox2.Left = 0.5!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Text = "TextBox2"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 3.0625!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "Cantidad"
            Me.TextBox3.Height = 0.1875!
            Me.TextBox3.Left = 3.625!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat")
            Me.TextBox3.Style = "text-align: right"
            Me.TextBox3.Text = "TextBox3"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 1.1875!
            '
            'TextBox4
            '
            Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.[Double]
            Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.TextBox4.DataField = "Cantidad"
            Me.TextBox4.Height = 0.1875!
            Me.TextBox4.Left = 3.625!
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat")
            Me.TextBox4.Style = "text-align: right"
            Me.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox4.Text = "TextBox4"
            Me.TextBox4.Top = 0!
            Me.TextBox4.Width = 1.1875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.25!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblHora,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
