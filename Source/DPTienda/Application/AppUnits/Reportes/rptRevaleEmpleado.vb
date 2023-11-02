Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptRevaleEmpleado
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Folio As Integer, ByVal Serie As String, ByVal Descuento As Decimal)
        MyBase.New()
        InitializeComponent()

        Me.lblFecha.Text = Format(Date.Today, "dd/MM/yyyy")
        Me.txtFolio.Text = Folio.ToString.PadLeft(5, "0")
        Me.txtSerie.Text = Serie
        Me.txtDesc.Text = CStr(Descuento * 100) & " %"

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblTitulo As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private lblFecha As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtSerie As TextBox = Nothing
	Private txtDesc As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptRevaleEmpleado))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtSerie = New DataDynamics.ActiveReports.TextBox()
            Me.txtDesc = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSerie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDesc,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.lblFecha, Me.txtFolio, Me.txtSerie, Me.txtDesc, Me.Label6})
            Me.PageHeader.Height = 3.010417!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.25!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 0.1875!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.lblTitulo.Text = "Dportenis"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 2.375!
            '
            'Label1
            '
            Me.Label1.Height = 0.25!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.1875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-weight: bold; font-size: 11.5pt; font-family: Tahoma"
            Me.Label1.Text = "Vale de Descuento (Re-Vale)"
            Me.Label1.Top = 0.3125!
            Me.Label1.Width = 2.375!
            '
            'Label2
            '
            Me.Label2.Height = 0.25!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.1875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label2.Text = "Folio:"
            Me.Label2.Top = 1.25!
            Me.Label2.Width = 0.9375!
            '
            'Label3
            '
            Me.Label3.Height = 0.25!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.1875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label3.Text = "Serie:"
            Me.Label3.Top = 1.5625!
            Me.Label3.Width = 0.9375!
            '
            'Label4
            '
            Me.Label4.Height = 0.25!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label4.Text = "Descuento:"
            Me.Label4.Top = 1.875!
            Me.Label4.Width = 0.9375!
            '
            'Label5
            '
            Me.Label5.Height = 0.625!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.1875!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: normal; font-size: 12pt"
            Me.Label5.Text = "* Este vale tendrá una vigencia de 30 dias después de su fecha de expedición."
            Me.Label5.Top = 2.25!
            Me.Label5.Width = 2.375!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.25!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 1.25!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: right; font-weight: normal; font-size: 12pt"
            Me.lblFecha.Text = "Fecha Impresion"
            Me.lblFecha.Top = 0.9375!
            Me.lblFecha.Width = 1.3125!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.25!
            Me.txtFolio.Left = 1.125!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: right; font-size: 12pt"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 1.25!
            Me.txtFolio.Width = 1.4375!
            '
            'txtSerie
            '
            Me.txtSerie.Height = 0.25!
            Me.txtSerie.Left = 1.125!
            Me.txtSerie.Name = "txtSerie"
            Me.txtSerie.Style = "text-align: right; font-size: 12pt"
            Me.txtSerie.Text = "Serie"
            Me.txtSerie.Top = 1.5625!
            Me.txtSerie.Width = 1.4375!
            '
            'txtDesc
            '
            Me.txtDesc.Height = 0.25!
            Me.txtDesc.Left = 1.125!
            Me.txtDesc.Name = "txtDesc"
            Me.txtDesc.Style = "text-align: right; font-size: 12pt"
            Me.txtDesc.Text = "Descuento"
            Me.txtDesc.Top = 1.875!
            Me.txtDesc.Width = 1.4375!
            '
            'Label6
            '
            Me.Label6.Height = 0.25!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.1875!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: left; font-weight: bold; font-size: 12pt; font-family: Tahoma"
            Me.Label6.Text = "Fecha:"
            Me.Label6.Top = 0.9375!
            Me.Label6.Width = 0.9375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0.1!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 2.71875!
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
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSerie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDesc,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
