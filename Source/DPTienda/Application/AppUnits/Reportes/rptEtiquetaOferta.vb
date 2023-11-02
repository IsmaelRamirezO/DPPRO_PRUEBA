Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiquetaOferta
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents Detail As Detail = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEtiquetaOferta))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3})
            Me.Detail.Height = 2.760417!
            Me.Detail.KeepTogether = true
            Me.Detail.Name = "Detail"
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "precio"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 1.102362!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: right; font-size: 12pt; font-family: Tahoma"
            Me.TextBox1.Text = "0.00"
            Me.TextBox1.Top = 0.01624016!
            Me.TextBox1.Width = 1.181103!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "preciooferta"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.8499014!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: right; font-size: 12pt; font-family: Tahoma"
            Me.TextBox2.Text = "0.00"
            Me.TextBox2.Top = 1.118602!
            Me.TextBox2.Width = 1.496063!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "codarticulo"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 0.534941!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "text-align: center; font-size: 12pt; font-family: Tahoma"
            Me.TextBox3.Top = 1.843504!
            Me.TextBox3.Width = 2.125984!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 2.917361!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperWidth = 2.936805!
            Me.PrintWidth = 2.947917!
            Me.Sections.Add(Me.Detail)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

	#End Region
End Class
