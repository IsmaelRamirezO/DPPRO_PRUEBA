Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptIngresosDiaAnterior
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Ingreso As Decimal, ByVal TotalConteo As Decimal)
        MyBase.New()
        InitializeComponent()

        Me.txtIngresos.Text = Format(Ingreso, "c")

        Dim sobrante, Faltante As Decimal

        sobrante = Math.Abs(Math.Min(TotalConteo - Ingreso, 0))
        Faltante = Math.Max(TotalConteo - Ingreso, 0)
        Me.txtSobrante.Text = Format(sobrante, "c")
        Me.txtFaltante.Text = Format(Faltante, "c")

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
	Private txtIngresos As TextBox = Nothing
	Private txtSobrante As TextBox = Nothing
	Private txtFaltante As TextBox = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptIngresosDiaAnterior))
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
            Me.txtIngresos = New DataDynamics.ActiveReports.TextBox()
            Me.txtSobrante = New DataDynamics.ActiveReports.TextBox()
            Me.txtFaltante = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtBanco,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFicha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalConteo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtIngresos,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSobrante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFaltante,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtBanco, Me.txtFicha, Me.txtImporte})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0.01041667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.25!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label2, Me.Label3})
            Me.GroupHeader1.Height = 0.25!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalConteo, Me.txtIngresos, Me.txtSobrante, Me.txtFaltante, Me.Label4, Me.Label5, Me.Label6, Me.Label7})
            Me.GroupFooter1.Height = 0.7902778!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = -0.02312992!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 8.25pt"
            Me.Label1.Text = "BANCO"
            Me.Label1.Top = 0!
            Me.Label1.Width = 0.511811!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.5556104!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 8.25pt"
            Me.Label2.Text = "FICHA"
            Me.Label2.Top = 0!
            Me.Label2.Width = 0.4891731!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.36811!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8.25pt"
            Me.Label3.Text = "IMPORTE"
            Me.Label3.Top = 0!
            Me.Label3.Width = 0.656004!
            '
            'txtBanco
            '
            Me.txtBanco.DataField = "Banco"
            Me.txtBanco.Height = 0.2!
            Me.txtBanco.Left = 0.03937007!
            Me.txtBanco.Name = "txtBanco"
            Me.txtBanco.OutputFormat = resources.GetString("txtBanco.OutputFormat")
            Me.txtBanco.Style = "font-size: 8.25pt"
            Me.txtBanco.Text = "BNMX"
            Me.txtBanco.Top = 0!
            Me.txtBanco.Width = 0.3937007!
            '
            'txtFicha
            '
            Me.txtFicha.DataField = "Ficha"
            Me.txtFicha.Height = 0.1680118!
            Me.txtFicha.Left = 0.4867125!
            Me.txtFicha.Name = "txtFicha"
            Me.txtFicha.OutputFormat = resources.GetString("txtFicha.OutputFormat")
            Me.txtFicha.Style = "text-align: left; font-size: 8.25pt"
            Me.txtFicha.Text = "134567890"
            Me.txtFicha.Top = 0!
            Me.txtFicha.Width = 0.6112207!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "Importe"
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 1.242536!
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
            Me.txtTotalConteo.Left = 1.338583!
            Me.txtTotalConteo.Name = "txtTotalConteo"
            Me.txtTotalConteo.OutputFormat = resources.GetString("txtTotalConteo.OutputFormat")
            Me.txtTotalConteo.Style = "text-align: right; font-size: 8.25pt"
            Me.txtTotalConteo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtTotalConteo.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalConteo.Text = "TextBox4"
            Me.txtTotalConteo.Top = 0!
            Me.txtTotalConteo.Width = 0.7667326!
            '
            'txtIngresos
            '
            Me.txtIngresos.Height = 0.2!
            Me.txtIngresos.Left = 1.338583!
            Me.txtIngresos.Name = "txtIngresos"
            Me.txtIngresos.OutputFormat = resources.GetString("txtIngresos.OutputFormat")
            Me.txtIngresos.Style = "text-align: right; font-size: 8.25pt"
            Me.txtIngresos.Text = "TextBox5"
            Me.txtIngresos.Top = 0.1968504!
            Me.txtIngresos.Width = 0.7667326!
            '
            'txtSobrante
            '
            Me.txtSobrante.Height = 0.2!
            Me.txtSobrante.Left = 1.338583!
            Me.txtSobrante.Name = "txtSobrante"
            Me.txtSobrante.OutputFormat = resources.GetString("txtSobrante.OutputFormat")
            Me.txtSobrante.Style = "text-align: right; font-size: 8.25pt"
            Me.txtSobrante.Text = "TextBox6"
            Me.txtSobrante.Top = 0.3937007!
            Me.txtSobrante.Width = 0.7667326!
            '
            'txtFaltante
            '
            Me.txtFaltante.Height = 0.2!
            Me.txtFaltante.Left = 1.338583!
            Me.txtFaltante.Name = "txtFaltante"
            Me.txtFaltante.OutputFormat = resources.GetString("txtFaltante.OutputFormat")
            Me.txtFaltante.Style = "text-align: right; font-size: 8.25pt"
            Me.txtFaltante.Text = "TextBox7"
            Me.txtFaltante.Top = 0.5905511!
            Me.txtFaltante.Width = 0.7667326!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.4168307!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 8.25pt"
            Me.Label4.Text = "TOTAL CONTEO"
            Me.Label4.Top = 0!
            Me.Label4.Width = 0.9192917!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.4168307!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 8.25pt"
            Me.Label5.Text = "SOBRANTE"
            Me.Label5.Top = 0.375!
            Me.Label5.Width = 0.9192917!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.4168307!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 8.25pt"
            Me.Label6.Text = "INGRESO"
            Me.Label6.Top = 0.1875!
            Me.Label6.Width = 0.9192917!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.4168307!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 8.25pt"
            Me.Label7.Text = "FALTANTE"
            Me.Label7.Top = 0.5625!
            Me.Label7.Width = 0.9192917!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.145833!
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
            CType(Me.txtIngresos,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSobrante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFaltante,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
