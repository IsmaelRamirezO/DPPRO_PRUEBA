Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AcrRptDifSAPyDP
Inherits DataDynamics.ActiveReports.ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private TxtBxCodArt As TextBox = Nothing
	Private TxtBxTalla As TextBox = Nothing
	Private TxtBxDef As TextBox = Nothing
	Private TxtBxDefAparDP As TextBox = Nothing
	Private TxtBxApart As TextBox = Nothing
	Private TxtBxSAP As TextBox = Nothing
	Private TxtBxTotal As TextBox = Nothing
	Private Label8 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcrRptDifSAPyDP))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.TxtBxCodArt = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTalla = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDef = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxDefAparDP = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxApart = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxSAP = New DataDynamics.ActiveReports.TextBox()
            Me.TxtBxTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxCodArt,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDef,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxDefAparDP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxApart,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TxtBxTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxCodArt, Me.TxtBxTalla, Me.TxtBxDef, Me.TxtBxDefAparDP, Me.TxtBxApart, Me.TxtBxSAP})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Line1, Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6})
            Me.PageHeader.Height = 0.6979167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtBxTotal, Me.Label8})
            Me.PageFooter.Height = 0.1763889!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.7086611!
            Me.Shape1.Left = 0.2431649!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.141732!
            '
            'Label1
            '
            Me.Label1.Height = 0.3149606!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.2594051!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 14.25pt"
            Me.Label1.Text = "Diferencias Apartados y Defectuosos con SAP"
            Me.Label1.Top = 0.07874014!
            Me.Label1.Width = 6.141732!
            '
            'Label2
            '
            Me.Label2.Height = 0.1574803!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.4306649!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 9.75pt"
            Me.Label2.Text = "Codigo Articulo"
            Me.Label2.Top = 0.5196851!
            Me.Label2.Width = 1.023622!
            '
            'Label3
            '
            Me.Label3.Height = 0.1574803!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 1.817968!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-size: 9.75pt"
            Me.Label3.Text = "Talla"
            Me.Label3.Top = 0.5196851!
            Me.Label3.Width = 0.3937007!
            '
            'Label4
            '
            Me.Label4.Height = 0.1574803!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 5.118111!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-size: 9.75pt"
            Me.Label4.Text = "Diferencias"
            Me.Label4.Top = 0.5196851!
            Me.Label4.Width = 1.023622!
            '
            'Label5
            '
            Me.Label5.Height = 0.1574803!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.526629!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-size: 9.75pt"
            Me.Label5.Text = "Def."
            Me.Label5.Top = 0.5196851!
            Me.Label5.Width = 0.2687008!
            '
            'Label6
            '
            Me.Label6.Height = 0.1574803!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.11029!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "font-size: 9.75pt"
            Me.Label6.Text = "Apart."
            Me.Label6.Top = 0.5196851!
            Me.Label6.Width = 0.3937005!
            '
            'Label7
            '
            Me.Label7.Height = 0.1574803!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.779528!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "font-size: 9.75pt"
            Me.Label7.Text = "SAP"
            Me.Label7.Top = 0.5196851!
            Me.Label7.Width = 0.7874014!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.2431649!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.472441!
            Me.Line1.Width = 6.141732!
            Me.Line1.X1 = 6.384897!
            Me.Line1.X2 = 0.2431649!
            Me.Line1.Y1 = 0.472441!
            Me.Line1.Y2 = 0.472441!
            '
            'Line2
            '
            Me.Line2.Height = 0.2362201!
            Me.Line2.Left = 1.739228!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.472441!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 1.739228!
            Me.Line2.X2 = 1.739228!
            Me.Line2.Y1 = 0.472441!
            Me.Line2.Y2 = 0.7086611!
            '
            'Line3
            '
            Me.Line3.Height = 0.2362201!
            Me.Line3.Left = 2.454834!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 0.472441!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 2.454834!
            Me.Line3.X2 = 2.454834!
            Me.Line3.Y1 = 0.472441!
            Me.Line3.Y2 = 0.7086611!
            '
            'Line4
            '
            Me.Line4.Height = 0.2362202!
            Me.Line4.Left = 3.006015!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.4793854!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 3.006015!
            Me.Line4.X2 = 3.006015!
            Me.Line4.Y1 = 0.4793854!
            Me.Line4.Y2 = 0.7156056!
            '
            'Line5
            '
            Me.Line5.Height = 0.2362202!
            Me.Line5.Left = 3.635937!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.4793854!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 3.635937!
            Me.Line5.X2 = 3.635937!
            Me.Line5.Y1 = 0.4793854!
            Me.Line5.Y2 = 0.7156056!
            '
            'Line6
            '
            Me.Line6.Height = 0.2362202!
            Me.Line6.Left = 4.895779!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.4793854!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 4.895779!
            Me.Line6.X2 = 4.895779!
            Me.Line6.Y1 = 0.4793854!
            Me.Line6.Y2 = 0.7156056!
            '
            'TxtBxCodArt
            '
            Me.TxtBxCodArt.DataField = "CodArticulo"
            Me.TxtBxCodArt.Height = 0.1771653!
            Me.TxtBxCodArt.Left = 0.3449804!
            Me.TxtBxCodArt.Name = "TxtBxCodArt"
            Me.TxtBxCodArt.Style = "font-size: 9pt"
            Me.TxtBxCodArt.Top = 0!
            Me.TxtBxCodArt.Width = 1.417323!
            '
            'TxtBxTalla
            '
            Me.TxtBxTalla.DataField = "Numero"
            Me.TxtBxTalla.Height = 0.1771653!
            Me.TxtBxTalla.Left = 1.841043!
            Me.TxtBxTalla.Name = "TxtBxTalla"
            Me.TxtBxTalla.Style = "font-size: 9pt"
            Me.TxtBxTalla.Top = 0!
            Me.TxtBxTalla.Width = 0.551181!
            '
            'TxtBxDef
            '
            Me.TxtBxDef.DataField = "DefecDP"
            Me.TxtBxDef.Height = 0.1771653!
            Me.TxtBxDef.Left = 2.549705!
            Me.TxtBxDef.Name = "TxtBxDef"
            Me.TxtBxDef.Style = "font-size: 9pt"
            Me.TxtBxDef.Top = 0!
            Me.TxtBxDef.Width = 0.3937007!
            '
            'TxtBxDefAparDP
            '
            Me.TxtBxDefAparDP.Height = 0.1771653!
            Me.TxtBxDefAparDP.Left = 5.118111!
            Me.TxtBxDefAparDP.Name = "TxtBxDefAparDP"
            Me.TxtBxDefAparDP.Style = "font-size: 9pt"
            Me.TxtBxDefAparDP.Top = 0!
            Me.TxtBxDefAparDP.Width = 1.027559!
            '
            'TxtBxApart
            '
            Me.TxtBxApart.DataField = "AparDP"
            Me.TxtBxApart.Height = 0.1771653!
            Me.TxtBxApart.Left = 3.100886!
            Me.TxtBxApart.Name = "TxtBxApart"
            Me.TxtBxApart.Style = "font-size: 9pt"
            Me.TxtBxApart.Top = 0!
            Me.TxtBxApart.Width = 0.3937007!
            '
            'TxtBxSAP
            '
            Me.TxtBxSAP.DataField = "BlockSAP"
            Me.TxtBxSAP.Height = 0.1771653!
            Me.TxtBxSAP.Left = 3.700787!
            Me.TxtBxSAP.Name = "TxtBxSAP"
            Me.TxtBxSAP.Style = "font-size: 9pt"
            Me.TxtBxSAP.Top = 0!
            Me.TxtBxSAP.Width = 1.102362!
            '
            'TxtBxTotal
            '
            Me.TxtBxTotal.DataField = "DefAparDP"
            Me.TxtBxTotal.Height = 0.1574803!
            Me.TxtBxTotal.Left = 5.24065!
            Me.TxtBxTotal.Name = "TxtBxTotal"
            Me.TxtBxTotal.Style = "text-align: right"
            Me.TxtBxTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TxtBxTotal.Top = 0!
            Me.TxtBxTotal.Width = 1.102362!
            '
            'Label8
            '
            Me.Label8.Height = 0.1574803!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 3.902067!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = ""
            Me.Label8.Text = "Total de Articulos"
            Me.Label8.Top = 0!
            Me.Label8.Width = 1.102362!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0.7875!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.7875!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.6875!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
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
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxCodArt,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDef,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxDefAparDP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxApart,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TxtBxTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

	#End Region

   
    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint
        Me.TxtBxDefAparDP.Text = CStr(Math.Abs((CInt(TxtBxDef.Text) + CInt(Me.TxtBxApart.Text)) - CInt(Me.TxtBxSAP.Text)))
    End Sub
End Class
