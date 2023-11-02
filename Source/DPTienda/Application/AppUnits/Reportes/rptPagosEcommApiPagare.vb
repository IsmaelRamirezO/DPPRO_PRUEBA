Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Web

Public Class rptPagosEcommApiPagare
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private dtPagos As DataTable

    Public Sub New(ByVal html_r As String)
        MyBase.New()
        InitializeComponent()
        Dim htmlContent As String = HttpUtility.HtmlDecode(html_r.Replace("\r\n", ""))
        Me.txtHtml.Html = htmlContent
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents txtHtml As DataDynamics.ActiveReports.RichTextBox
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPagosEcommApiPagare))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtHtml = New DataDynamics.ActiveReports.RichTextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtHtml})
        Me.Detail.Height = 5.229167!
        Me.Detail.Name = "Detail"
        '
        'txtHtml
        '
        Me.txtHtml.AutoReplaceFields = True
        Me.txtHtml.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtHtml.Height = 5.208167!
        Me.txtHtml.Left = 0.04166667!
        Me.txtHtml.Name = "txtHtml"
        Me.txtHtml.RTF = resources.GetString("txtHtml.RTF")
        Me.txtHtml.Top = 0.02083333!
        Me.txtHtml.Width = 6.229334!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'rptPagosEcommApiPagare
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.322917!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
