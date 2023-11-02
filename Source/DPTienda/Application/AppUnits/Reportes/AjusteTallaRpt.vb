Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class AjusteTallaRpt
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private pnPag As Integer

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
	Private txtUsuario As TextBox = Nothing
	Private txtFolio As TextBox = Nothing
	Private Label12 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label14 As Label = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtT1 As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private TextBox2 As TextBox = Nothing
	Private TextBox3 As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private Label11 As Label = Nothing
	Private txtObservaciones As TextBox = Nothing
	Private txtSTotal As TextBox = Nothing
	Private Line4 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjusteTallaRpt))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
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
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtT1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox()
            Me.txtSTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigoAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreAlmacen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtT1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtT1, Me.TextBox1, Me.TextBox2, Me.TextBox3})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label11, Me.txtObservaciones, Me.txtSTotal, Me.Line4})
            Me.ReportFooter.Height = 0.7076389!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.txtFecha, Me.Label2, Me.txtTitulo, Me.Label3, Me.Label4, Me.Label5, Me.txtCodigoAlmacen, Me.txtNombreAlmacen, Me.txtPag, Me.Label6, Me.Label8, Me.Line1, Me.txtUsuario, Me.txtFolio, Me.Label12, Me.Label13, Me.Label14})
            Me.PageHeader.Height = 1.009722!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.9375!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.03125!
            Me.Shape1.Width = 6.4375!
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
            Me.txtTitulo.Style = "text-align: center; font-weight: bold; font-size: 9pt; font-family: Times New Rom"& _ 
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
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
            Me.Label6.Text = "MODELO DESC."
            Me.Label6.Top = 0.8125!
            Me.Label6.Width = 2.772146!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.118111!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: left; font-size: 9pt; font-family: Times New Roman"
            Me.Label8.Text = "Folio SAP"
            Me.Label8.Top = 0.7874014!
            Me.Label8.Width = 1.102363!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.75!
            Me.Line1.Width = 6.4375!
            Me.Line1.X1 = 6.4375!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.75!
            Me.Line1.Y2 = 0.75!
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
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 4.251969!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
            Me.Label12.Text = "Cantidad"
            Me.Label12.Top = 0.7874014!
            Me.Label12.Width = 0.5511808!
            '
            'Label13
            '
            Me.Label13.Height = 0.1875!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 3.779528!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
            Me.Label13.Text = "TallaE"
            Me.Label13.Top = 0.7874014!
            Me.Label13.Width = 0.3937011!
            '
            'Label14
            '
            Me.Label14.Height = 0.1875!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 3.307087!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = "text-align: center; font-size: 9pt; font-family: Times New Roman"
            Me.Label14.Text = "TallaS"
            Me.Label14.Top = 0.7874014!
            Me.Label14.Width = 0.3937008!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.Left = 0.01041663!
            Me.txtCodigo.MultiLine = false
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtCodigo.Text = "Codigo"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.091946!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.Left = 1.181102!
            Me.txtDescripcion.MultiLine = false
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-size: 9pt; font-family: Times New Roman"
            Me.txtDescripcion.Text = "Descripcion"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 2.047244!
            '
            'txtT1
            '
            Me.txtT1.DataField = "TallaS"
            Me.txtT1.Height = 0.188!
            Me.txtT1.Left = 3.307087!
            Me.txtT1.Name = "txtT1"
            Me.txtT1.Style = "text-align: right; font-size: 9pt; font-family: Times New Roman"
            Me.txtT1.Text = "TallaS"
            Me.txtT1.Top = 0!
            Me.txtT1.Width = 0.3937005!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "TallaE"
            Me.TextBox1.Height = 0.188!
            Me.TextBox1.Left = 3.779528!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: right; font-size: 9pt; font-family: Times New Roman"
            Me.TextBox1.Text = "TallaE"
            Me.TextBox1.Top = 0!
            Me.TextBox1.Width = 0.3937005!
            '
            'TextBox2
            '
            Me.TextBox2.DataField = "Cantidad"
            Me.TextBox2.Height = 0.188!
            Me.TextBox2.Left = 4.251969!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: right; font-size: 9pt; font-family: Times New Roman"
            Me.TextBox2.Text = "Cantidad"
            Me.TextBox2.Top = 0!
            Me.TextBox2.Width = 0.5511813!
            '
            'TextBox3
            '
            Me.TextBox3.DataField = "FolioSAP"
            Me.TextBox3.Height = 0.188!
            Me.TextBox3.Left = 5.118111!
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Style = "text-align: left; font-size: 9pt; font-family: Times New Roman; vertical-align: t"& _ 
                "op"
            Me.TextBox3.Text = "FolioSAP"
            Me.TextBox3.Top = 0!
            Me.TextBox3.Width = 1.102363!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 0!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
            Me.Label9.Text = "Total de Artículos"
            Me.Label9.Top = 0!
            Me.Label9.Width = 1.25!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
            Me.Label11.Text = "OBSERVACIONES DEL AJUSTE"
            Me.Label11.Top = 0.3020833!
            Me.Label11.Width = 2.4375!
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Height = 0.1875!
            Me.txtObservaciones.Left = 0!
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.Style = "ddo-char-set: 1; font-size: 9pt; font-family: Times New Roman"
            Me.txtObservaciones.Text = "Observaciones"
            Me.txtObservaciones.Top = 0.5!
            Me.txtObservaciones.Width = 5!
            '
            'txtSTotal
            '
            Me.txtSTotal.DataField = "Cantidad"
            Me.txtSTotal.Height = 0.1875!
            Me.txtSTotal.Left = 5.625!
            Me.txtSTotal.Name = "txtSTotal"
            Me.txtSTotal.Style = "ddo-char-set: 1; text-align: right; font-size: 9pt; font-family: Times New Roman"
            Me.txtSTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtSTotal.Text = "0"
            Me.txtSTotal.Top = 0!
            Me.txtSTotal.Width = 0.8125!
            '
            'Line4
            '
            Me.Line4.Height = 0!
            Me.Line4.Left = 0!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0!
            Me.Line4.Width = 6.4375!
            Me.Line4.X1 = 6.4375!
            Me.Line4.X2 = 0!
            Me.Line4.Y1 = 0!
            Me.Line4.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
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
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigoAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreAlmacen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtT1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtObservaciones,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint
        pnPag = pnPag + 1
        txtPag.Text = Str$(pnPag)
    End Sub

End Class
