Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports System.Web
Imports Microsoft.Office.Interop
Public Class rptPagosEcommApiTicket
    Inherits DataDynamics.ActiveReports.ActiveReport

    Dim oReporteFormapago As ReporteDetalleFormasPago
    Dim oLetras As cImprimirFactura
    Friend WithEvents txtHTML As DataDynamics.ActiveReports.RichTextBox
    Dim oOP As OtrosPagos

    Public Sub New(ByVal html_t As String)

        MyBase.New()
        InitializeComponent()
        Dim htmlContent As String = HttpUtility.HtmlDecode(html_t.Replace("\r\n", ""))
        Console.WriteLine(htmlContent)
        Me.txtHTML.Html = htmlContent
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPagosEcommApiTicket))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.txtHTML = New DataDynamics.ActiveReports.RichTextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.CanShrink = True
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtHTML})
        Me.Detail.Height = 0.3229166!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
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
        'txtHTML
        '
        Me.txtHTML.AutoReplaceFields = True
        Me.txtHTML.CanShrink = True
        Me.txtHTML.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtHTML.Height = 0.281!
        Me.txtHTML.Left = 0.031!
        Me.txtHTML.Name = "txtHTML"
        Me.txtHTML.RTF = resources.GetString("txtHTML.RTF")
        Me.txtHTML.Top = 0.0!
        Me.txtHTML.Width = 2.854!
        '
        'rptPagosEcommApiTicket
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.0!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.0!
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Custom paper"
        Me.PageSettings.PaperWidth = 2.98!
        Me.PrintWidth = 2.885!
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
