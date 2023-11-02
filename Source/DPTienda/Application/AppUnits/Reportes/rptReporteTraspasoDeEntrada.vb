Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptReporteTraspasoDeEntrada
    Inherits DataDynamics.ActiveReports.ActiveReport
    Private mPag As Integer
	Public Sub New()
	MyBase.New()
		InitializeComponent()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private txtPag As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtTraspaso As TextBox = Nothing
	Private txtOrigen As TextBox = Nothing
	Private txtDestino As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
    Private CTotal As TextBox = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Label12 As Label = Nothing
	Private txtTotalArticulos As TextBox = Nothing
	Private txtValorDeclarado As TextBox = Nothing
	Private txtNumeroGuia As TextBox = Nothing
    Private Line5 As Line = Nothing
    Private txtObservaciones As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptReporteTraspasoDeEntrada))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.CTotal = New DataDynamics.ActiveReports.TextBox()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.txtTotalArticulos = New DataDynamics.ActiveReports.TextBox()
        Me.txtValorDeclarado = New DataDynamics.ActiveReports.TextBox()
        Me.txtNumeroGuia = New DataDynamics.ActiveReports.TextBox()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.txtPag = New DataDynamics.ActiveReports.TextBox()
        Me.txtTraspaso = New DataDynamics.ActiveReports.TextBox()
        Me.txtOrigen = New DataDynamics.ActiveReports.TextBox()
        Me.txtDestino = New DataDynamics.ActiveReports.TextBox()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        CType(Me.CTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorDeclarado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTraspaso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CTotal, Me.Line3, Me.Line4, Me.txtCodigo, Me.txtDescripcion})
        Me.Detail.Height = 0.2291666!
        Me.Detail.Name = "Detail"
        '
        'CTotal
        '
        Me.CTotal.DataField = "TotalA"
        Me.CTotal.Height = 0.1875!
        Me.CTotal.Left = 6.115!
        Me.CTotal.Name = "CTotal"
        Me.CTotal.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
        Me.CTotal.Text = "CTotal"
        Me.CTotal.Top = 0.0!
        Me.CTotal.Width = 0.2600007!
        '
        'Line3
        '
        Me.Line3.Height = 0.281!
        Me.Line3.Left = 6.437!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0!
        Me.Line3.Width = 0.0004997253!
        Me.Line3.X1 = 6.4375!
        Me.Line3.X2 = 6.437!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.281!
        '
        'Line4
        '
        Me.Line4.Height = 0.375!
        Me.Line4.Left = 0.0625!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 0.0625!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.375!
        '
        'txtCodigo
        '
        Me.txtCodigo.DataField = "Codigo"
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 0.125!
        Me.txtCodigo.MultiLine = False
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtCodigo.Text = "Codigo"
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 1.375!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.1875!
        Me.txtDescripcion.Left = 1.562!
        Me.txtDescripcion.MultiLine = False
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtDescripcion.Text = "Descripcion"
        Me.txtDescripcion.Top = 0.0!
        Me.txtDescripcion.Width = 4.501!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.Label11, Me.Label12, Me.txtTotalArticulos, Me.txtValorDeclarado, Me.txtNumeroGuia, Me.Line5, Me.txtObservaciones})
        Me.ReportFooter.Height = 0.9791667!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label10
        '
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.125!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label10.Text = "Total Artículos"
        Me.Label10.Top = 0.0625!
        Me.Label10.Width = 1.625!
        '
        'Label11
        '
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.125!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label11.Text = "Valor Declarado"
        Me.Label11.Top = 0.25!
        Me.Label11.Width = 1.625!
        '
        'Label12
        '
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 0.125!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label12.Text = "Número de Guía"
        Me.Label12.Top = 0.4375!
        Me.Label12.Width = 1.625!
        '
        'txtTotalArticulos
        '
        Me.txtTotalArticulos.DataField = "TotalA"
        Me.txtTotalArticulos.Height = 0.1875!
        Me.txtTotalArticulos.Left = 5.375!
        Me.txtTotalArticulos.Name = "txtTotalArticulos"
        Me.txtTotalArticulos.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
        Me.txtTotalArticulos.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalArticulos.Text = "TotalArticulos"
        Me.txtTotalArticulos.Top = 0.0625!
        Me.txtTotalArticulos.Width = 1.0!
        '
        'txtValorDeclarado
        '
        Me.txtValorDeclarado.Height = 0.1875!
        Me.txtValorDeclarado.Left = 5.375!
        Me.txtValorDeclarado.Name = "txtValorDeclarado"
        Me.txtValorDeclarado.OutputFormat = resources.GetString("txtValorDeclarado.OutputFormat")
        Me.txtValorDeclarado.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
        Me.txtValorDeclarado.Text = "ValorDeclarado"
        Me.txtValorDeclarado.Top = 0.25!
        Me.txtValorDeclarado.Width = 1.0!
        '
        'txtNumeroGuia
        '
        Me.txtNumeroGuia.Height = 0.1875!
        Me.txtNumeroGuia.Left = 5.375!
        Me.txtNumeroGuia.Name = "txtNumeroGuia"
        Me.txtNumeroGuia.Style = "text-align: right; font-size: 8.25pt; font-family: Times New Roman"
        Me.txtNumeroGuia.Text = "NumeroGuia"
        Me.txtNumeroGuia.Top = 0.4375!
        Me.txtNumeroGuia.Width = 1.0!
        '
        'Line5
        '
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.0625!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 6.375!
        Me.Line5.X1 = 6.4375!
        Me.Line5.X2 = 0.0625!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.0!
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Height = 0.1875!
        Me.txtObservaciones.Left = 0.125!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtObservaciones.Text = "Observaciones"
        Me.txtObservaciones.Top = 0.625!
        Me.txtObservaciones.Width = 6.3125!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.txtFecha, Me.Label9, Me.txtPag, Me.txtTraspaso, Me.txtOrigen, Me.txtDestino, Me.Line1, Me.Line2})
        Me.PageHeader.Height = 0.9791667!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape2
        '
        Me.Shape2.Height = 0.25!
        Me.Shape2.Left = 0.0625!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.6875!
        Me.Shape2.Width = 6.375!
        '
        'Shape1
        '
        Me.Shape1.Height = 0.625!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 6.375!
        '
        'Label1
        '
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.6875!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-size: 8.25pt; font-family: Times New Roman"
        Me.Label1.Text = "REPORTE DE TRASPASO DE ENTRADA"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.5!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.125!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label2.Text = "Traspaso No."
        Me.Label2.Top = 0.4375!
        Me.Label2.Width = 0.6875!
        '
        'Label3
        '
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.5625!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label3.Text = "Suc. Origen."
        Me.Label3.Top = 0.4375!
        Me.Label3.Width = 0.625!
        '
        'Label4
        '
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 2.75!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label4.Text = "Suc. Destino"
        Me.Label4.Top = 0.4375!
        Me.Label4.Width = 0.625!
        '
        'Label5
        '
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 4.0!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label5.Text = "Entrego:"
        Me.Label5.Top = 0.4375!
        Me.Label5.Width = 0.5!
        '
        'Label6
        '
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 5.1875!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label6.Text = "Recibio:"
        Me.Label6.Top = 0.4375!
        Me.Label6.Width = 0.4375!
        '
        'Label7
        '
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.125!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label7.Text = "MODELO"
        Me.Label7.Top = 0.75!
        Me.Label7.Width = 1.375!
        '
        'Label8
        '
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.562!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label8.Text = "DESCRIPCIÓN"
        Me.Label8.Top = 0.75!
        Me.Label8.Width = 4.501!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 0.125!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtFecha.Text = "Fecha"
        Me.txtFecha.Top = 0.0625!
        Me.txtFecha.Width = 0.8125!
        '
        'Label9
        '
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 5.5!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.Label9.Text = "Pág."
        Me.Label9.Top = 0.0625!
        Me.Label9.Width = 0.375!
        '
        'txtPag
        '
        Me.txtPag.Height = 0.1875!
        Me.txtPag.Left = 5.875!
        Me.txtPag.Name = "txtPag"
        Me.txtPag.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtPag.Text = "N. Pag"
        Me.txtPag.Top = 0.0625!
        Me.txtPag.Width = 0.5!
        '
        'txtTraspaso
        '
        Me.txtTraspaso.Height = 0.1875!
        Me.txtTraspaso.Left = 0.875!
        Me.txtTraspaso.Name = "txtTraspaso"
        Me.txtTraspaso.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtTraspaso.Text = "Traspaso"
        Me.txtTraspaso.Top = 0.4375!
        Me.txtTraspaso.Width = 0.625!
        '
        'txtOrigen
        '
        Me.txtOrigen.Height = 0.1875!
        Me.txtOrigen.Left = 2.25!
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtOrigen.Text = "Origen"
        Me.txtOrigen.Top = 0.4375!
        Me.txtOrigen.Width = 0.4375!
        '
        'txtDestino
        '
        Me.txtDestino.Height = 0.1875!
        Me.txtDestino.Left = 3.4375!
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Style = "font-size: 8.25pt; font-family: Times New Roman"
        Me.txtDestino.Text = "Destino"
        Me.txtDestino.Top = 0.4375!
        Me.txtDestino.Width = 0.5!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 4.5!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.5625!
        Me.Line1.Width = 0.6875!
        Me.Line1.X1 = 5.1875!
        Me.Line1.X2 = 4.5!
        Me.Line1.Y1 = 0.5625!
        Me.Line1.Y2 = 0.5625!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 5.625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.5625!
        Me.Line2.Width = 0.75!
        Me.Line2.X1 = 6.375!
        Me.Line2.X2 = 5.625!
        Me.Line2.Y1 = 0.5625!
        Me.Line2.Y2 = 0.5625!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'rptReporteTraspasoDeEntrada
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.7!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.CTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorDeclarado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTraspaso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Propiedades"
    Public Property Folio() As String
        Get
            Folio = txtTraspaso.Text
        End Get
        Set(ByVal Value As String)
            txtTraspaso.Text = Value
        End Set
    End Property
    Public Property Fecha() As Date
        Get
            Fecha = txtFecha.Value
        End Get
        Set(ByVal Value As Date)
            txtFecha.Value = Value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Origen = txtOrigen.Text
        End Get
        Set(ByVal Value As String)
            txtOrigen.Text = Value
        End Set
    End Property
    Public Property Destino() As String
        Get
            Destino = txtDestino.Text
        End Get
        Set(ByVal Value As String)
            txtDestino.Text = Value
        End Set
    End Property
    Public Property ValorDeclarado() As String
        Get
            ValorDeclarado = txtValorDeclarado.Text
        End Get
        Set(ByVal Value As String)
            txtValorDeclarado.Text = Value
        End Set
    End Property
    Public Property Guia() As String
        Get
            Guia = txtNumeroGuia.Text
        End Get
        Set(ByVal Value As String)
            txtNumeroGuia.Text = Value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Observaciones = txtObservaciones.Text
        End Get
        Set(ByVal Value As String)
            txtObservaciones.Text = Value
        End Set
    End Property
#End Region

    Private Sub rptReporteTraspasoDeEntrada_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PageStart
        mPag = mPag + 1
        txtPag.Text = Str$(mPag)
    End Sub
End Class
