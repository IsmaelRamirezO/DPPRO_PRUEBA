Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AjustesESFrm
    Inherits DataDynamics.ActiveReports.ActiveReport
    Private pnPag As Integer

	Public Sub New()
	MyBase.New()
		InitializeComponent()
    End Sub
    Public Property CodigoAlmacen() As String
        Get
            CodigoAlmacen = txtCodigoAlmacen.Text
        End Get
        Set(ByVal Value As String)
            txtCodigoAlmacen.Text = Value
        End Set
    End Property
    Public Property NombreAlmacen() As String
        Get
            NombreAlmacen = txtNombreAlmacen.Text
        End Get
        Set(ByVal Value As String)
            txtNombreAlmacen.Text = Value
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
    Public Property Titulo() As String
        Get
            Titulo = txtTitulo.Text
        End Get
        Set(ByVal Value As String)
            txtTitulo.Text = Value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Usuario = txtUsuario.Text
        End Get
        Set(ByVal Value As String)
            txtUsuario.Text = Value
        End Set
    End Property
    Public Property Folio() As Long
        Get
            Folio = Val(txtFolio.Text)
        End Get
        Set(ByVal Value As Long)
            txtFolio.Text = Str$(Value)
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

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private txtTitulo As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private txtCodigoAlmacen As TextBox = Nothing
	Private txtNombreAlmacen As TextBox = Nothing
	Private txtPag As TextBox = Nothing
	Private Label6 As Label = Nothing
    Private Label8 As Label = Nothing
	Private Line1 As Line = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private txtUsuario As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private Line5 As Line = Nothing
	Private Label12 As Label = Nothing
	Private txtCodigo As TextBox = Nothing
    Private txtDescripcion As TextBox = Nothing
    Private txtCostoTotal As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private TxtBxFolioSAP As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private Label10 As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private txtSTotal As TextBox = Nothing
    Private txtSCosto As TextBox = Nothing
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
	Private Line4 As Line = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjustesESFrm))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.txtCostoTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
        Me.TxtBxFolioSAP = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Label9 = New DataDynamics.ActiveReports.Label()
        Me.Label10 = New DataDynamics.ActiveReports.Label()
        Me.Label11 = New DataDynamics.ActiveReports.Label()
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
        Me.txtSTotal = New DataDynamics.ActiveReports.TextBox()
        Me.txtSCosto = New DataDynamics.ActiveReports.TextBox()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.txtTitulo = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label5 = New DataDynamics.ActiveReports.Label()
        Me.txtCodigoAlmacen = New DataDynamics.ActiveReports.TextBox()
        Me.txtNombreAlmacen = New DataDynamics.ActiveReports.TextBox()
        Me.txtPag = New DataDynamics.ActiveReports.TextBox()
        Me.Label6 = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Label12 = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.Label13 = New DataDynamics.ActiveReports.Label()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCostoTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBxFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtCostoTotal, Me.txtTotal, Me.TxtBxFolioSAP, Me.TextBox2, Me.TextBox3})
        Me.Detail.Height = 0.4375!
        Me.Detail.Name = "Detail"
        '
        'txtCodigo
        '
        Me.txtCodigo.DataField = "Codigo"
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 0.01041663!
        Me.txtCodigo.MultiLine = False
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtCodigo.Text = "Codigo"
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 1.302083!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "Descripcion"
        Me.txtDescripcion.Height = 0.1875!
        Me.txtDescripcion.Left = 1.375!
        Me.txtDescripcion.MultiLine = False
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtDescripcion.Text = "Descripcion"
        Me.txtDescripcion.Top = 0.0!
        Me.txtDescripcion.Width = 2.156!
        '
        'txtCostoTotal
        '
        Me.txtCostoTotal.DataField = "Importe"
        Me.txtCostoTotal.Height = 0.1875!
        Me.txtCostoTotal.Left = 6.299212!
        Me.txtCostoTotal.Name = "txtCostoTotal"
        Me.txtCostoTotal.OutputFormat = resources.GetString("txtCostoTotal.OutputFormat")
        Me.txtCostoTotal.Style = "text-align: right; font-size: 9pt; font-family: Times New Roman"
        Me.txtCostoTotal.Text = "0"
        Me.txtCostoTotal.Top = 0.0!
        Me.txtCostoTotal.Width = 0.8125!
        '
        'txtTotal
        '
        Me.txtTotal.DataField = "Total"
        Me.txtTotal.Height = 0.1875!
        Me.txtTotal.Left = 6.299212!
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Style = "text-align: right"
        Me.txtTotal.Text = "Total"
        Me.txtTotal.Top = 0.1875!
        Me.txtTotal.Width = 0.8125!
        '
        'TxtBxFolioSAP
        '
        Me.TxtBxFolioSAP.DataField = "foliosap"
        Me.TxtBxFolioSAP.Height = 0.1574803!
        Me.TxtBxFolioSAP.Left = 5.301!
        Me.TxtBxFolioSAP.Name = "TxtBxFolioSAP"
        Me.TxtBxFolioSAP.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.TxtBxFolioSAP.Text = "0000000000"
        Me.TxtBxFolioSAP.Top = 0.0!
        Me.TxtBxFolioSAP.Width = 0.8661417!
        '
        'ReportHeader
        '
        Me.ReportHeader.Height = 0.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label10, Me.Label11, Me.txtObservaciones, Me.txtSTotal, Me.txtSCosto, Me.Line4})
        Me.ReportFooter.Height = 0.96875!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Label9
        '
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
        Me.Label9.Text = "Total de Artículos"
        Me.Label9.Top = 0.0!
        Me.Label9.Width = 1.25!
        '
        'Label10
        '
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
        Me.Label10.Text = "Costo Total"
        Me.Label10.Top = 0.1875!
        Me.Label10.Width = 1.25!
        '
        'Label11
        '
        Me.Label11.Height = 0.1875!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 0.0!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
        Me.Label11.Text = "OBSERVACIONES DEL AJUSTE"
        Me.Label11.Top = 0.5520833!
        Me.Label11.Width = 2.4375!
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Height = 0.1875!
        Me.txtObservaciones.Left = 0.0!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
        Me.txtObservaciones.Text = "Observaciones"
        Me.txtObservaciones.Top = 0.75!
        Me.txtObservaciones.Width = 5.0!
        '
        'txtSTotal
        '
        Me.txtSTotal.DataField = "Total"
        Me.txtSTotal.Height = 0.1875!
        Me.txtSTotal.Left = 6.299212!
        Me.txtSTotal.Name = "txtSTotal"
        Me.txtSTotal.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Times New Roman"
        Me.txtSTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtSTotal.Text = "0"
        Me.txtSTotal.Top = 0.0!
        Me.txtSTotal.Width = 0.8125!
        '
        'txtSCosto
        '
        Me.txtSCosto.DataField = "Importe"
        Me.txtSCosto.Height = 0.1875!
        Me.txtSCosto.Left = 6.299212!
        Me.txtSCosto.Name = "txtSCosto"
        Me.txtSCosto.OutputFormat = resources.GetString("txtSCosto.OutputFormat")
        Me.txtSCosto.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Times New Roman"
        Me.txtSCosto.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtSCosto.Text = "0"
        Me.txtSCosto.Top = 0.1875!
        Me.txtSCosto.Width = 0.8125!
        '
        'Line4
        '
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.0!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 7.165354!
        Me.Line4.X1 = 7.165354!
        Me.Line4.X2 = 0.0!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.0!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.txtFecha, Me.Label2, Me.txtTitulo, Me.Label3, Me.Label4, Me.Label5, Me.txtCodigoAlmacen, Me.txtNombreAlmacen, Me.txtPag, Me.Label6, Me.Label8, Me.Line1, Me.Line2, Me.Line3, Me.txtUsuario, Me.txtFolio, Me.Line5, Me.Label12, Me.Label7, Me.Label13, Me.Label1})
        Me.PageHeader.Height = 1.019767!
        Me.PageHeader.Name = "PageHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.9375!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.03937007!
        Me.Shape1.Width = 7.165354!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 0.0625!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtFecha.Text = "Fecha"
        Me.txtFecha.Top = 0.0625!
        Me.txtFecha.Width = 0.8125!
        '
        'Label2
        '
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.Label2.Text = "Ajuste No."
        Me.Label2.Top = 0.375!
        Me.Label2.Width = 0.625!
        '
        'txtTitulo
        '
        Me.txtTitulo.Height = 0.1875!
        Me.txtTitulo.Left = 1.625!
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Times New Rom" & _
    "an"
        Me.txtTitulo.Text = "REPORTE DE AJUSTES"
        Me.txtTitulo.Top = 0.0625!
        Me.txtTitulo.Width = 2.8125!
        '
        'Label3
        '
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 1.375!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.Label3.Text = "Sucursal"
        Me.Label3.Top = 0.375!
        Me.Label3.Width = 0.5!
        '
        'Label4
        '
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 4.875!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.Label4.Text = "Elaboró:"
        Me.Label4.Top = 0.375!
        Me.Label4.Width = 0.625!
        '
        'Label5
        '
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 5.5!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.Label5.Text = "pág."
        Me.Label5.Top = 0.0625!
        Me.Label5.Width = 0.375!
        '
        'txtCodigoAlmacen
        '
        Me.txtCodigoAlmacen.Height = 0.1875!
        Me.txtCodigoAlmacen.Left = 1.9375!
        Me.txtCodigoAlmacen.Name = "txtCodigoAlmacen"
        Me.txtCodigoAlmacen.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtCodigoAlmacen.Text = "CodigoAlmacen"
        Me.txtCodigoAlmacen.Top = 0.375!
        Me.txtCodigoAlmacen.Width = 0.625!
        '
        'txtNombreAlmacen
        '
        Me.txtNombreAlmacen.Height = 0.1875!
        Me.txtNombreAlmacen.Left = 2.625!
        Me.txtNombreAlmacen.Name = "txtNombreAlmacen"
        Me.txtNombreAlmacen.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtNombreAlmacen.Text = "NombreAlmacen"
        Me.txtNombreAlmacen.Top = 0.375!
        Me.txtNombreAlmacen.Width = 1.625!
        '
        'txtPag
        '
        Me.txtPag.Height = 0.1875!
        Me.txtPag.Left = 6.0625!
        Me.txtPag.Name = "txtPag"
        Me.txtPag.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtPag.Text = "No. Pag."
        Me.txtPag.Top = 0.0625!
        Me.txtPag.Width = 0.3125!
        '
        'Label6
        '
        Me.Label6.Height = 0.1574803!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.06299213!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
        Me.Label6.Text = "CODIGO"
        Me.Label6.Top = 0.7874014!
        Me.Label6.Width = 1.1875!
        '
        'Label8
        '
        Me.Label8.Height = 0.1574803!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 6.377953!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
        Me.Label8.Text = "TOTAL"
        Me.Label8.Top = 0.7874014!
        Me.Label8.Width = 0.75!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.7519687!
        Me.Line1.Width = 7.165354!
        Me.Line1.X1 = 7.165354!
        Me.Line1.X2 = 0.0!
        Me.Line1.Y1 = 0.7519687!
        Me.Line1.Y2 = 0.7519687!
        '
        'Line2
        '
        Me.Line2.Height = 0.2185042!
        Me.Line2.Left = 5.25!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.7500001!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 5.25!
        Me.Line2.X2 = 5.25!
        Me.Line2.Y1 = 0.7500001!
        Me.Line2.Y2 = 0.9685043!
        '
        'Line3
        '
        Me.Line3.Height = 0.2165355!
        Me.Line3.Left = 1.319444!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.7519687!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 1.319444!
        Me.Line3.X2 = 1.319444!
        Me.Line3.Y1 = 0.9685042!
        Me.Line3.Y2 = 0.7519687!
        '
        'txtUsuario
        '
        Me.txtUsuario.Height = 0.1875!
        Me.txtUsuario.Left = 5.5625!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
        Me.txtUsuario.Text = "USUARIO"
        Me.txtUsuario.Top = 0.375!
        Me.txtUsuario.Width = 0.8125!
        '
        'txtFolio
        '
        Me.txtFolio.Height = 0.1875!
        Me.txtFolio.Left = 0.75!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.txtFolio.Text = "Folio"
        Me.txtFolio.Top = 0.375!
        Me.txtFolio.Width = 0.5!
        '
        'Line5
        '
        Me.Line5.Height = 0.2165355!
        Me.Line5.Left = 6.222!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.752!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 6.222!
        Me.Line5.X2 = 6.222!
        Me.Line5.Y1 = 0.752!
        Me.Line5.Y2 = 0.9685355!
        '
        'Label12
        '
        Me.Label12.Height = 0.1574803!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 5.301!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "font-size: 9pt; font-family: Times New Roman"
        Me.Label12.Text = "FOLIO SAP"
        Me.Label12.Top = 0.7870001!
        Me.Label12.Width = 0.8661417!
        '
        'PageFooter
        '
        Me.PageFooter.Height = 0.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label7
        '
        Me.Label7.Height = 0.1574803!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 3.584!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
        Me.Label7.Text = "MARCA"
        Me.Label7.Top = 0.7870001!
        Me.Label7.Width = 0.563!
        '
        'Label13
        '
        Me.Label13.Height = 0.1574803!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.198!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
        Me.Label13.Text = "PROVEEDOR"
        Me.Label13.Top = 0.7870001!
        Me.Label13.Width = 1.0!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "Marca"
        Me.TextBox2.Height = 0.1875!
        Me.TextBox2.Left = 3.584!
        Me.TextBox2.MultiLine = False
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "font-size: 9pt; font-family: Times New Roman; vertical-align: middle; text-align:" & _
    " center"
        Me.TextBox2.Text = "Marca"
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.563!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "Proveedor"
        Me.TextBox3.Height = 0.1875!
        Me.TextBox3.Left = 4.198!
        Me.TextBox3.MultiLine = False
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "font-size: 9pt; font-family: Times New Roman; vertical-align: middle; text-align:" & _
    " center"
        Me.TextBox3.Text = "CodProveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 1.0!
        '
        'Label1
        '
        Me.Label1.Height = 0.1574803!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
        Me.Label1.Text = "DESCRIPCIÓN"
        Me.Label1.Top = 0.7870001!
        Me.Label1.Width = 2.156!
        '
        'AjustesESFrm
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.7!
        Me.PageSettings.Margins.Left = 0.5118055!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.1875!
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
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCostoTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBxFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint
        pnPag = pnPag + 1
        txtPag.Text = Str$(pnPag)
    End Sub
End Class
