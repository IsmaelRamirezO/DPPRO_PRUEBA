Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptMovimientosPorArticulo
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal strCodArticulo As String, ByVal strDescripcionArticulo As String, ByVal strTEntrada As String, ByVal strTSalida As String, ByVal strTFinal As String)
        MyBase.New()
        InitializeComponent()
        Me.txtFecha.Text = Now
        Me.txtTEntradas.Text = strTEntrada
        Me.txtTSalidas.Text = strTSalida
        Me.txtTStock.Text = strTFinal
        Me.txtCodArticulo.Text = strCodArticulo
        Me.txtDescripcionArticulo.Text = strDescripcionArticulo
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Label1 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtCodArticulo As TextBox = Nothing
	Private txtDescripcionArticulo As TextBox = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label8 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private Line2 As Line = Nothing
	Private txtBWART As TextBox = Nothing
	Private txtMBLNR As TextBox = Nothing
	Private txtBUDAT As TextBox = Nothing
	Private txtJ_3ASIZ As TextBox = Nothing
	Private txtMENGE As TextBox = Nothing
	Private txtDescripcionMovimiento As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private txtTEntradas As TextBox = Nothing
	Private txtTSalidas As TextBox = Nothing
	Private txtTStock As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptMovimientosPorArticulo))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcionArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.txtBWART = New DataDynamics.ActiveReports.TextBox()
            Me.txtMBLNR = New DataDynamics.ActiveReports.TextBox()
            Me.txtBUDAT = New DataDynamics.ActiveReports.TextBox()
            Me.txtJ_3ASIZ = New DataDynamics.ActiveReports.TextBox()
            Me.txtMENGE = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcionMovimiento = New DataDynamics.ActiveReports.TextBox()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtTEntradas = New DataDynamics.ActiveReports.TextBox()
            Me.txtTSalidas = New DataDynamics.ActiveReports.TextBox()
            Me.txtTStock = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcionArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtBWART,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMBLNR,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtBUDAT,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtJ_3ASIZ,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMENGE,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcionMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTEntradas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTSalidas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTStock,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtBWART, Me.txtMBLNR, Me.txtBUDAT, Me.txtJ_3ASIZ, Me.txtMENGE, Me.txtDescripcionMovimiento})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Label4, Me.Label5, Me.txtTEntradas, Me.txtTSalidas, Me.txtTStock, Me.Line1})
            Me.ReportFooter.Height = 0.6756945!
            Me.ReportFooter.KeepTogether = true
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.txtFecha, Me.Label2, Me.txtCodArticulo, Me.txtDescripcionArticulo, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11, Me.Line2})
            Me.PageHeader.Height = 0.875!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Label1
            '
            Me.Label1.Height = 0.2624672!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.39977!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 15.75pt"
            Me.Label1.Text = "Histórico de Movimientos por Articulo"
            Me.Label1.Top = 0!
            Me.Label1.Width = 3.805774!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 5.249344!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "text-align: center"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 1.771653!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.3937007!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 9.75pt"
            Me.Label2.Text = "Cod. Articulo"
            Me.Label2.Top = 0.328084!
            Me.Label2.Width = 0.9186354!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.Height = 0.2!
            Me.txtCodArticulo.Left = 1.377953!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Top = 0.328084!
            Me.txtCodArticulo.Width = 1.64042!
            '
            'txtDescripcionArticulo
            '
            Me.txtDescripcionArticulo.Height = 0.2!
            Me.txtDescripcionArticulo.Left = 3.083989!
            Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
            Me.txtDescripcionArticulo.Top = 0.328084!
            Me.txtDescripcionArticulo.Width = 3.412074!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center"
            Me.Label6.Text = "Clave"
            Me.Label6.Top = 0.656168!
            Me.Label6.Width = 0.656168!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.656168!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center"
            Me.Label7.Text = "Folio"
            Me.Label7.Top = 0.656168!
            Me.Label7.Width = 1.115485!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 1.771653!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center"
            Me.Label8.Text = "Fecha"
            Me.Label8.Top = 0.656168!
            Me.Label8.Width = 1.246719!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 3.018373!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center"
            Me.Label9.Text = "Talla"
            Me.Label9.Top = 0.656168!
            Me.Label9.Width = 0.3871388!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 3.412074!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center"
            Me.Label10.Text = "Cantidad"
            Me.Label10.Top = 0.656168!
            Me.Label10.Width = 0.7217847!
            '
            'Label11
            '
            Me.Label11.Height = 0.2!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 4.133858!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "text-align: center"
            Me.Label11.Text = "Descripcion"
            Me.Label11.Top = 0.656168!
            Me.Label11.Width = 2.821522!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.8541667!
            Me.Line2.Width = 7.021!
            Me.Line2.X1 = 7.021!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0.8541667!
            Me.Line2.Y2 = 0.8541667!
            '
            'txtBWART
            '
            Me.txtBWART.DataField = "BWART"
            Me.txtBWART.Height = 0.2!
            Me.txtBWART.Left = 0!
            Me.txtBWART.Name = "txtBWART"
            Me.txtBWART.Style = "text-align: center"
            Me.txtBWART.Top = 0!
            Me.txtBWART.Width = 0.656168!
            '
            'txtMBLNR
            '
            Me.txtMBLNR.DataField = "Folioprincipal"
            Me.txtMBLNR.Height = 0.2!
            Me.txtMBLNR.Left = 0.656168!
            Me.txtMBLNR.Name = "txtMBLNR"
            Me.txtMBLNR.Style = "text-align: center"
            Me.txtMBLNR.Top = 0!
            Me.txtMBLNR.Width = 1.104085!
            '
            'txtBUDAT
            '
            Me.txtBUDAT.DataField = "BUDAT"
            Me.txtBUDAT.Height = 0.2!
            Me.txtBUDAT.Left = 1.775755!
            Me.txtBUDAT.Name = "txtBUDAT"
            Me.txtBUDAT.Style = "text-align: center"
            Me.txtBUDAT.Top = 0!
            Me.txtBUDAT.Width = 1.246719!
            '
            'txtJ_3ASIZ
            '
            Me.txtJ_3ASIZ.DataField = "J_3ASIZ"
            Me.txtJ_3ASIZ.Height = 0.2!
            Me.txtJ_3ASIZ.Left = 3.018373!
            Me.txtJ_3ASIZ.Name = "txtJ_3ASIZ"
            Me.txtJ_3ASIZ.Top = 0!
            Me.txtJ_3ASIZ.Width = 0.3937008!
            '
            'txtMENGE
            '
            Me.txtMENGE.DataField = "MENGE"
            Me.txtMENGE.Height = 0.2!
            Me.txtMENGE.Left = 3.432087!
            Me.txtMENGE.Name = "txtMENGE"
            Me.txtMENGE.Style = "text-align: right"
            Me.txtMENGE.Top = 0!
            Me.txtMENGE.Width = 0.6402557!
            '
            'txtDescripcionMovimiento
            '
            Me.txtDescripcionMovimiento.DataField = "Descripcion"
            Me.txtDescripcionMovimiento.Height = 0.2!
            Me.txtDescripcionMovimiento.Left = 4.137057!
            Me.txtDescripcionMovimiento.Name = "txtDescripcionMovimiento"
            Me.txtDescripcionMovimiento.Top = 0!
            Me.txtDescripcionMovimiento.Width = 2.818323!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0656168!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "font-weight: bold; font-size: 9.75pt; vertical-align: top"
            Me.Label3.Text = "Entradas"
            Me.Label3.Top = 0.0625!
            Me.Label3.Width = 0.9186354!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.0656168!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label4.Text = "Salidas"
            Me.Label4.Top = 0.2593504!
            Me.Label4.Width = 0.9186354!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.0656168!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "font-weight: bold; font-size: 9.75pt"
            Me.Label5.Text = "Stock Final"
            Me.Label5.Top = 0.4562007!
            Me.Label5.Width = 0.9186354!
            '
            'txtTEntradas
            '
            Me.txtTEntradas.Height = 0.2!
            Me.txtTEntradas.Left = 1.049869!
            Me.txtTEntradas.Name = "txtTEntradas"
            Me.txtTEntradas.Style = "text-align: right; font-size: 9.75pt"
            Me.txtTEntradas.Text = "TextBox1"
            Me.txtTEntradas.Top = 0.0625!
            Me.txtTEntradas.Width = 1!
            '
            'txtTSalidas
            '
            Me.txtTSalidas.Height = 0.2!
            Me.txtTSalidas.Left = 1.049869!
            Me.txtTSalidas.Name = "txtTSalidas"
            Me.txtTSalidas.Style = "text-align: right; font-size: 9.75pt"
            Me.txtTSalidas.Text = "TextBox2"
            Me.txtTSalidas.Top = 0.2593504!
            Me.txtTSalidas.Width = 1!
            '
            'txtTStock
            '
            Me.txtTStock.Height = 0.2!
            Me.txtTStock.Left = 1.049869!
            Me.txtTStock.Name = "txtTStock"
            Me.txtTStock.Style = "text-align: right; font-size: 9.75pt"
            Me.txtTStock.Text = "TextBox3"
            Me.txtTStock.Top = 0.4562007!
            Me.txtTStock.Width = 1!
            '
            'Line1
            '
            Me.Line1.Height = 1.173319E-08!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0!
            Me.Line1.Width = 7.021!
            Me.Line1.X1 = 7.021!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0!
            Me.Line1.Y2 = 1.173319E-08!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.0625!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcionArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtBWART,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMBLNR,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtBUDAT,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtJ_3ASIZ,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMENGE,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcionMovimiento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTEntradas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTSalidas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTStock,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
