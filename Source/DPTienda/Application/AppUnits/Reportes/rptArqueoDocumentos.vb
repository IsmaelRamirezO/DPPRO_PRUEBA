Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptArqueoDocumentos
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private txtBanco As TextBox = Nothing
	Private txtFicha As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtTotalConteo As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptArqueoDocumentos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.txtBanco = New DataDynamics.ActiveReports.TextBox()
            Me.txtFicha = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotalConteo = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtBanco,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFicha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalConteo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtBanco, Me.txtFicha, Me.txtImporte})
            Me.Detail.Height = 0.2291667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0.25!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3})
            Me.GroupHeader1.Height = 0.2076389!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalConteo, Me.Label4})
            Me.GroupFooter1.Height = 0.21875!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.2893701!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 8.25pt"
            Me.Label1.Text = "Fecha"
            Me.Label1.Top = 0!
            Me.Label1.Width = 0.511811!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.186024!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 8.25pt"
            Me.Label2.Text = "CONCEPTO"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.769193!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.482283!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8.25pt"
            Me.Label3.Text = "IMPORTE"
            Me.Label3.Top = 0!
            Me.Label3.Width = 0.656004!
            '
            'txtBanco
            '
            Me.txtBanco.DataField = "Fecha"
            Me.txtBanco.Height = 0.2!
            Me.txtBanco.Left = 0.03937007!
            Me.txtBanco.Name = "txtBanco"
            Me.txtBanco.OutputFormat = resources.GetString("txtBanco.OutputFormat")
            Me.txtBanco.Style = "font-size: 8.25pt"
            Me.txtBanco.Top = 0!
            Me.txtBanco.Width = 0.944882!
            '
            'txtFicha
            '
            Me.txtFicha.DataField = "Concepto"
            Me.txtFicha.Height = 0.1680118!
            Me.txtFicha.Left = 1.038385!
            Me.txtFicha.Name = "txtFicha"
            Me.txtFicha.OutputFormat = resources.GetString("txtFicha.OutputFormat")
            Me.txtFicha.Style = "text-align: left; font-size: 8.25pt"
            Me.txtFicha.Top = 0!
            Me.txtFicha.Width = 1.087599!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Importe"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 2.169209!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporte.Text = "TextBox3"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.8720472!
            '
            'txtTotalConteo
            '
            Me.txtTotalConteo.DataField = "Importe"
            Me.txtTotalConteo.Height = 0.2!
            Me.txtTotalConteo.Left = 2.265256!
            Me.txtTotalConteo.Name = "txtTotalConteo"
            Me.txtTotalConteo.OutputFormat = resources.GetString("txtTotalConteo.OutputFormat")
            Me.txtTotalConteo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotalConteo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTotalConteo.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalConteo.Text = "TextBox4"
            Me.txtTotalConteo.Top = 0!
            Me.txtTotalConteo.Width = 0.7667326!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.343504!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 8.25pt"
            Me.Label4.Text = "TOTAL CONTEO"
            Me.Label4.Top = 0!
            Me.Label4.Width = 0.9192917!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 3.1875!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtBanco,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFicha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalConteo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

	#End Region
End Class
