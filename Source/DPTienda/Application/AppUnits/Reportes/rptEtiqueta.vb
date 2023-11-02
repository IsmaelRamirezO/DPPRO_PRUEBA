Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiqueta
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEtiqueta))
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
            Me.Detail.Height = 2.207639!
            Me.Detail.KeepTogether = true
            Me.Detail.Name = "Detail"
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Medidas"
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 0.313!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat")
            Me.TextBox1.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.TextBox1.Text = "Medidas"
            Me.TextBox1.Top = 1.05!
            Me.TextBox1.Width = 1!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Precio"
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 0.3125!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat")
            Me.TextBox2.Style = "text-align: center; font-size: 12pt; font-family: Arial"
            Me.TextBox2.Text = "Precio"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 1!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "CodArticulo"
            Me.TextBox3.Height = 0.2!
            Me.TextBox3.Left = 0.0625!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "ddo-char-set: 1; text-align: center; font-size: 11pt; font-family: Arial"
            Me.TextBox3.Text = "MODELO"
            Me.TextBox3.Top = 1.875!
            Me.TextBox3.Width = 1.375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 1.5!
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

    Private Sub rptEtiqueta_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.PageSettings.Collate = PageSettings.PrinterCollate.Collate
        'Me.PageSettings.DefaultPaperSize = True
        'Me.PageSettings.DefaultPaperSource = True
        'Me.PageSettings.Duplex = Drawing.Printing.Duplex.Default
        'Me.PageSettings.Gutter = 0.1F
        'Me.PageSettings.MirrorMargins = False
        'Me.PageSettings.Orientation = PageOrientation.Default

        'Me.PageSettings.PaperSource = System.Drawing.Printing.PaperSourceKind.TractorFeed
        'Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        'Me.PageSettings.PaperHeight = 3.0F
        'Me.PageSettings.PaperWidth = 3.0F
        'Me.PageSettings.Margins.Bottom = 0.0F
        'Me.PageSettings.Margins.Left = 0.0F
        'Me.PageSettings.Margins.Right = 0.0F
        'Me.PageSettings.Margins.Top = 0.0F



    End Sub
End Class
