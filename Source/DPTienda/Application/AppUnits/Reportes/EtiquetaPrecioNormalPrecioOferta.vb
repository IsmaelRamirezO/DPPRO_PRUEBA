Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class EtiquetaPrecioNormalPrecioOferta
Inherits DataDynamics.ActiveReports.ActiveReport
	
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private PageBreak3 As PageBreak = Nothing
	Private tbPrecio As TextBox = Nothing
	Private tbCorridaInicial As TextBox = Nothing
	Private tbCorridaFinal As TextBox = Nothing
	Private tbCodArticulo As TextBox = Nothing
	Private Label1 As Label = Nothing
	Private PageBreak2 As PageBreak = Nothing
	Private PageBreak1 As PageBreak = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtiquetaPrecioNormalPrecioOferta))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.PageBreak3 = New DataDynamics.ActiveReports.PageBreak()
            Me.tbPrecio = New DataDynamics.ActiveReports.TextBox()
            Me.tbCorridaInicial = New DataDynamics.ActiveReports.TextBox()
            Me.tbCorridaFinal = New DataDynamics.ActiveReports.TextBox()
            Me.tbCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.PageBreak2 = New DataDynamics.ActiveReports.PageBreak()
            Me.PageBreak1 = New DataDynamics.ActiveReports.PageBreak()
            CType(Me.tbPrecio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCorridaInicial,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCorridaFinal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbPrecio, Me.tbCorridaInicial, Me.tbCorridaFinal, Me.tbCodArticulo, Me.Label1})
            Me.Detail.Height = 2.020139!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PageBreak3})
            Me.PageHeader.Height = 0.04166667!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PageBreak1})
            Me.PageFooter.Height = 0.02083333!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PageBreak2})
            Me.GroupFooter1.Height = 0.02083333!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'PageBreak3
            '
            Me.PageBreak3.Height = 0.05555556!
            Me.PageBreak3.Left = 0!
            Me.PageBreak3.Name = "PageBreak3"
            Me.PageBreak3.Size = New System.Drawing.SizeF(1.5625!, 0.05555556!)
            Me.PageBreak3.Top = 0.02430556!
            Me.PageBreak3.Width = 1.5625!
            '
            'tbPrecio
            '
            Me.tbPrecio.Height = 0.1875!
            Me.tbPrecio.Left = 0.1172901!
            Me.tbPrecio.Name = "tbPrecio"
            Me.tbPrecio.OutputFormat = resources.GetString("tbPrecio.OutputFormat")
            Me.tbPrecio.Style = "ddo-char-set: 1; font-weight: normal; font-size: 11.25pt"
            Me.tbPrecio.Text = "tbPrecio"
            Me.tbPrecio.Top = -0.0152559!
            Me.tbPrecio.Width = 0.7229334!
            '
            'tbCorridaInicial
            '
            Me.tbCorridaInicial.Height = 0.1875!
            Me.tbCorridaInicial.Left = 0.1476378!
            Me.tbCorridaInicial.Name = "tbCorridaInicial"
            Me.tbCorridaInicial.OutputFormat = resources.GetString("tbCorridaInicial.OutputFormat")
            Me.tbCorridaInicial.Style = "font-weight: normal; font-size: 11.25pt"
            Me.tbCorridaInicial.Text = "tbCorridaInicial"
            Me.tbCorridaInicial.Top = 0.492126!
            Me.tbCorridaInicial.Width = 0.5!
            '
            'tbCorridaFinal
            '
            Me.tbCorridaFinal.Height = 0.1875!
            Me.tbCorridaFinal.Left = 0.9315944!
            Me.tbCorridaFinal.Name = "tbCorridaFinal"
            Me.tbCorridaFinal.OutputFormat = resources.GetString("tbCorridaFinal.OutputFormat")
            Me.tbCorridaFinal.Style = "font-weight: normal; font-size: 11.25pt"
            Me.tbCorridaFinal.Text = "tbCorridaFinal"
            Me.tbCorridaFinal.Top = 0.4635827!
            Me.tbCorridaFinal.Width = 0.5!
            '
            'tbCodArticulo
            '
            Me.tbCodArticulo.Height = 0.1875!
            Me.tbCodArticulo.Left = 0.07381889!
            Me.tbCodArticulo.Name = "tbCodArticulo"
            Me.tbCodArticulo.Style = "font-weight: normal; font-size: 9.75pt"
            Me.tbCodArticulo.Text = "tbCodArticulo"
            Me.tbCodArticulo.Top = 1.49754!
            Me.tbCodArticulo.Width = 1.304134!
            '
            'Label1
            '
            Me.Label1.Height = 0.1875!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.6589569!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: normal; font-size: 11.25pt"
            Me.Label1.Text = "A"
            Me.Label1.Top = 0.4847441!
            Me.Label1.Width = 0.25!
            '
            'PageBreak2
            '
            Me.PageBreak2.Height = 0.05555556!
            Me.PageBreak2.Left = 0!
            Me.PageBreak2.Name = "PageBreak2"
            Me.PageBreak2.Size = New System.Drawing.SizeF(1.5625!, 0.05555556!)
            Me.PageBreak2.Top = 0!
            Me.PageBreak2.Width = 1.5625!
            '
            'PageBreak1
            '
            Me.PageBreak1.Height = 0.05555556!
            Me.PageBreak1.Left = 0!
            Me.PageBreak1.Name = "PageBreak1"
            Me.PageBreak1.Size = New System.Drawing.SizeF(1.5625!, 0.05555556!)
            Me.PageBreak1.Top = 0.01111111!
            Me.PageBreak1.Width = 1.5625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.DefaultPaperSize = false
            Me.PageSettings.Margins.Bottom = 0.1965278!
            Me.PageSettings.Margins.Left = 0.03958333!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 2.35!
            Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
            Me.PageSettings.PaperName = "Custom paper"
            Me.PageSettings.PaperWidth = 1.570139!
            Me.PrintWidth = 1.5625!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.tbPrecio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCorridaInicial,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCorridaFinal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region



#Region "Constructores"

    Public Sub New(ByVal dt As DataTable)

        MyBase.New()
        InitializeComponent()

        dtDetalle = dt

        Sm_MostrarInformacion()

    End Sub

#End Region



#Region "Variables Miembros"

    Private dtDetalle As DataTable

#End Region



#Region "Métodos Miembros"

    Private Sub Sm_MostrarInformacion()

        Me.DataSource = dtDetalle

        Me.tbPrecio.DataField = "Precio"
        Me.tbCorridaInicial.DataField = "CorridaInicial"
        Me.tbCorridaFinal.DataField = "CorridaFinal"
        Me.tbCodArticulo.DataField = "CodArticulo"


        'me.PageSettings.PaperSource.   

    End Sub

#End Region


    

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

        Me.PageBreak1.Enabled = True

    End Sub



    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

        Me.PageBreak1.Enabled = True

    End Sub


    Private Sub PageFooter_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter.Format

        Me.PageBreak1.Enabled = True

    End Sub

End Class
