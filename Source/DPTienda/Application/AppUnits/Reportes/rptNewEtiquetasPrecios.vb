Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptNewEtiquetasPrecios
    Inherits DataDynamics.ActiveReports.ActiveReport
    Private index As Integer = 1
    Private linea As Integer = 1
    Private pointBarCode As PointF
    Private pointTxtLinea As PointF
    Private ptxtCodigo As PointF
    Private plblPrecioNormal As PointF
    Private plblPrecioOferta As PointF
    Private ptxtPrecioNormal As PointF
    Private ptxtPrecioOferta As PointF
    Private plblMx As PointF
    Private plblUsa As PointF
    Private plblMx2 As PointF
    Private plblUsa2 As PointF
    Private ptxtTalla1 As PointF
    Private ptxtTalla2 As PointF
    Private pimgTalla As PointF
    Private lTxtTalla1 As PointF, lTxtTalla2 As PointF, lTxtTalla3 As PointF, lTxtTalla4 As PointF, lTxtTalla5 As PointF
    Private lTxtTalla6 As PointF, lTxtTalla7 As PointF, lTxtTalla8 As PointF, lTxtTalla9 As PointF, lTxtTalla10 As PointF
    Private lTxtTalla11 As PointF, lTxtTalla12 As PointF, lTxtTalla13 As PointF, pLblMex As PointF, pLblMex2 As PointF

    Public Sub New(ByVal bNormal As Boolean, ByVal dtCodigos As DataTable, ByVal Index As Integer)

        MyBase.New()
        InitializeComponent()

        pointBarCode = New PointF(0.95, 1.715)
        pointTxtLinea = New PointF(0.125, 1.77)
        ptxtCodigo = New PointF(0, 0.125)
        plblPrecioNormal = New PointF(0.125, 0.313)
        plblPrecioOferta = New PointF(0.875, 0.313)
        ptxtPrecioNormal = New PointF(0.125, 0.43)
        ptxtPrecioOferta = New PointF(0.875, 0.438)
        plblMx = New PointF(0, 0.563)
        plblUsa = New PointF(0.375, 0.563)
        plblMx2 = New PointF(0.75, 0.563)
        plblUsa2 = New PointF(1.125, 0.563)
        ptxtTalla1 = New PointF(0, 0.75)
        ptxtTalla2 = New PointF(0.75, 0.75)
        pimgTalla = New PointF(0.188, 0.688)
        lTxtTalla1 = New PointF(0.125, 0.75)
        lTxtTalla2 = New PointF(0.125, 0.875)
        lTxtTalla3 = New PointF(0.125, 1)
        lTxtTalla4 = New PointF(0.125, 1.125)
        lTxtTalla5 = New PointF(0.125, 1.25)
        lTxtTalla6 = New PointF(0.125, 1.375)
        lTxtTalla7 = New PointF(0.125, 1.5)
        lTxtTalla8 = New PointF(0.813, 0.75)
        lTxtTalla9 = New PointF(0.813, 0.875)
        lTxtTalla10 = New PointF(0.813, 1)
        lTxtTalla11 = New PointF(0.813, 1.125)
        lTxtTalla12 = New PointF(0.813, 1.25)
        lTxtTalla13 = New PointF(0.813, 1.375)
        pLblMex = New PointF(0.125, 0.625)
        pLblMex2 = New PointF(0.813, 0.625)
        Me.DataSource = dtCodigos
    End Sub




#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtFamilia As TextBox = Nothing
	Private Barcode1 As Barcode = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtPrecioNormal As TextBox = Nothing
	Private txtPrecioOferta As TextBox = Nothing
	Private lblPrecioNormal As Label = Nothing
	Private lblPrecioOferta As Label = Nothing
	Private txtCodFamilia As TextBox = Nothing
	Private txtTalla1 As TextBox = Nothing
	Private txtTalla2 As TextBox = Nothing
	Private txtTalla3 As TextBox = Nothing
	Private txtTalla4 As TextBox = Nothing
	Private txtTalla5 As TextBox = Nothing
	Private txtTalla6 As TextBox = Nothing
	Private txtTalla7 As TextBox = Nothing
	Private txtTalla8 As TextBox = Nothing
	Private txtTalla9 As TextBox = Nothing
	Private txtTalla10 As TextBox = Nothing
	Private txtTalla11 As TextBox = Nothing
	Private txtTalla12 As TextBox = Nothing
	Private txtTalla13 As TextBox = Nothing
	Private lblMex As TextBox = Nothing
	Private lblMex2 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptNewEtiquetasPrecios))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.txtFamilia = New DataDynamics.ActiveReports.TextBox()
            Me.Barcode1 = New DataDynamics.ActiveReports.Barcode()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioNormal = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioOferta = New DataDynamics.ActiveReports.TextBox()
            Me.lblPrecioNormal = New DataDynamics.ActiveReports.Label()
            Me.lblPrecioOferta = New DataDynamics.ActiveReports.Label()
            Me.txtCodFamilia = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla1 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla2 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla3 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla4 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla5 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla6 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla7 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla8 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla9 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla12 = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla13 = New DataDynamics.ActiveReports.TextBox()
            Me.lblMex = New DataDynamics.ActiveReports.TextBox()
            Me.lblMex2 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioNormal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioNormal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodFamilia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMex,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMex2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.CanGrow = false
            Me.Detail.ColumnCount = 4
            Me.Detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown
            Me.Detail.ColumnSpacing = 0.26875!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFamilia, Me.Barcode1, Me.txtCodigo, Me.txtPrecioNormal, Me.txtPrecioOferta, Me.lblPrecioNormal, Me.lblPrecioOferta, Me.txtCodFamilia, Me.txtTalla1, Me.txtTalla2, Me.txtTalla3, Me.txtTalla4, Me.txtTalla5, Me.txtTalla6, Me.txtTalla7, Me.txtTalla8, Me.txtTalla9, Me.txtTalla10, Me.txtTalla11, Me.txtTalla12, Me.txtTalla13, Me.lblMex, Me.lblMex2})
            Me.Detail.Height = 2.779861!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.CanGrow = false
            Me.ReportHeader.Height = 0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.CanGrow = false
            Me.ReportFooter.Height = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'txtFamilia
            '
            Me.txtFamilia.CanGrow = false
            Me.txtFamilia.DataField = "Linea"
            Me.txtFamilia.Height = 0.2!
            Me.txtFamilia.Left = 0.125!
            Me.txtFamilia.Name = "txtFamilia"
            Me.txtFamilia.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 6.75pt; font-fam"& _ 
                "ily: Arial"
            Me.txtFamilia.Text = "Caballero"
            Me.txtFamilia.Top = 1.77!
            Me.txtFamilia.Width = 0.8125!
            '
            'Barcode1
            '
            Me.Barcode1.Alignment = System.Drawing.StringAlignment.Near
            Me.Barcode1.DataField = "CodigoQR"
            Me.Barcode1.Font = New System.Drawing.Font("Courier New", 8!)
            Me.Barcode1.Height = 0.418!
            Me.Barcode1.Left = 0.95!
            Me.Barcode1.Name = "Barcode1"
            Me.Barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.QRCode
            Me.Barcode1.Text = "000000097621674901"
            Me.Barcode1.Top = 1.715!
            Me.Barcode1.Width = 0.418!
            '
            'txtCodigo
            '
            Me.txtCodigo.CanGrow = false
            Me.txtCodigo.DataField = "CodArticulo"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.Left = 0!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.txtCodigo.Text = "Codigo"
            Me.txtCodigo.Top = 0.125!
            Me.txtCodigo.Width = 1.75!
            '
            'txtPrecioNormal
            '
            Me.txtPrecioNormal.CanGrow = false
            Me.txtPrecioNormal.DataField = "Precio"
            Me.txtPrecioNormal.Height = 0.14!
            Me.txtPrecioNormal.Left = 0.125!
            Me.txtPrecioNormal.Name = "txtPrecioNormal"
            Me.txtPrecioNormal.OutputFormat = resources.GetString("txtPrecioNormal.OutputFormat")
            Me.txtPrecioNormal.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.txtPrecioNormal.Top = 0.4375!
            Me.txtPrecioNormal.Width = 0.75!
            '
            'txtPrecioOferta
            '
            Me.txtPrecioOferta.CanGrow = false
            Me.txtPrecioOferta.DataField = "PrecioOferta"
            Me.txtPrecioOferta.Height = 0.14!
            Me.txtPrecioOferta.Left = 0.875!
            Me.txtPrecioOferta.Name = "txtPrecioOferta"
            Me.txtPrecioOferta.OutputFormat = resources.GetString("txtPrecioOferta.OutputFormat")
            Me.txtPrecioOferta.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.txtPrecioOferta.Top = 0.4375!
            Me.txtPrecioOferta.Width = 0.75!
            '
            'lblPrecioNormal
            '
            Me.lblPrecioNormal.Height = 0.125!
            Me.lblPrecioNormal.HyperLink = Nothing
            Me.lblPrecioNormal.Left = 0.125!
            Me.lblPrecioNormal.Name = "lblPrecioNormal"
            Me.lblPrecioNormal.Style = "text-align: left; font-weight: bold; font-size: 6.75pt"
            Me.lblPrecioNormal.Text = "Precio Normal"
            Me.lblPrecioNormal.Top = 0.3125!
            Me.lblPrecioNormal.Width = 0.75!
            '
            'lblPrecioOferta
            '
            Me.lblPrecioOferta.Height = 0.125!
            Me.lblPrecioOferta.HyperLink = Nothing
            Me.lblPrecioOferta.Left = 0.875!
            Me.lblPrecioOferta.Name = "lblPrecioOferta"
            Me.lblPrecioOferta.Style = "text-align: left; font-weight: bold; font-size: 6.75pt"
            Me.lblPrecioOferta.Text = "Precio Oferta"
            Me.lblPrecioOferta.Top = 0.3125!
            Me.lblPrecioOferta.Width = 0.75!
            '
            'txtCodFamilia
            '
            Me.txtCodFamilia.CanGrow = false
            Me.txtCodFamilia.DataField = "CodFamilia"
            Me.txtCodFamilia.Height = 0.125!
            Me.txtCodFamilia.Left = 0.0625!
            Me.txtCodFamilia.Name = "txtCodFamilia"
            Me.txtCodFamilia.Style = "font-size: 6pt"
            Me.txtCodFamilia.Top = 2.0625!
            Me.txtCodFamilia.Visible = false
            Me.txtCodFamilia.Width = 0.875!
            '
            'txtTalla1
            '
            Me.txtTalla1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla1.CanGrow = false
            Me.txtTalla1.Height = 0.125!
            Me.txtTalla1.Left = 0.125!
            Me.txtTalla1.Name = "txtTalla1"
            Me.txtTalla1.OutputFormat = resources.GetString("txtTalla1.OutputFormat")
            Me.txtTalla1.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla1.Text = "Talla1"
            Me.txtTalla1.Top = 0.765!
            Me.txtTalla1.Visible = false
            Me.txtTalla1.Width = 0.5!
            '
            'txtTalla2
            '
            Me.txtTalla2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla2.CanGrow = false
            Me.txtTalla2.Height = 0.125!
            Me.txtTalla2.Left = 0.125!
            Me.txtTalla2.Name = "txtTalla2"
            Me.txtTalla2.OutputFormat = resources.GetString("txtTalla2.OutputFormat")
            Me.txtTalla2.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla2.Text = "Talla2"
            Me.txtTalla2.Top = 0.89!
            Me.txtTalla2.Width = 0.5!
            '
            'txtTalla3
            '
            Me.txtTalla3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla3.CanGrow = false
            Me.txtTalla3.Height = 0.125!
            Me.txtTalla3.Left = 0.125!
            Me.txtTalla3.Name = "txtTalla3"
            Me.txtTalla3.OutputFormat = resources.GetString("txtTalla3.OutputFormat")
            Me.txtTalla3.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla3.Text = "Talla3"
            Me.txtTalla3.Top = 1.015!
            Me.txtTalla3.Width = 0.5!
            '
            'txtTalla4
            '
            Me.txtTalla4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla4.CanGrow = false
            Me.txtTalla4.Height = 0.125!
            Me.txtTalla4.Left = 0.125!
            Me.txtTalla4.Name = "txtTalla4"
            Me.txtTalla4.OutputFormat = resources.GetString("txtTalla4.OutputFormat")
            Me.txtTalla4.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla4.Text = "Talla4"
            Me.txtTalla4.Top = 1.14!
            Me.txtTalla4.Width = 0.5!
            '
            'txtTalla5
            '
            Me.txtTalla5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla5.CanGrow = false
            Me.txtTalla5.Height = 0.125!
            Me.txtTalla5.Left = 0.125!
            Me.txtTalla5.Name = "txtTalla5"
            Me.txtTalla5.OutputFormat = resources.GetString("txtTalla5.OutputFormat")
            Me.txtTalla5.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla5.Text = "Talla5"
            Me.txtTalla5.Top = 1.265!
            Me.txtTalla5.Width = 0.5!
            '
            'txtTalla6
            '
            Me.txtTalla6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla6.CanGrow = false
            Me.txtTalla6.Height = 0.125!
            Me.txtTalla6.Left = 0.125!
            Me.txtTalla6.Name = "txtTalla6"
            Me.txtTalla6.OutputFormat = resources.GetString("txtTalla6.OutputFormat")
            Me.txtTalla6.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla6.Text = "Talla6"
            Me.txtTalla6.Top = 1.39!
            Me.txtTalla6.Width = 0.5!
            '
            'txtTalla7
            '
            Me.txtTalla7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla7.CanGrow = false
            Me.txtTalla7.Height = 0.125!
            Me.txtTalla7.Left = 0.125!
            Me.txtTalla7.Name = "txtTalla7"
            Me.txtTalla7.OutputFormat = resources.GetString("txtTalla7.OutputFormat")
            Me.txtTalla7.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla7.Text = "Talla7"
            Me.txtTalla7.Top = 1.515!
            Me.txtTalla7.Width = 0.5!
            '
            'txtTalla8
            '
            Me.txtTalla8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla8.CanGrow = false
            Me.txtTalla8.Height = 0.125!
            Me.txtTalla8.Left = 0.8125!
            Me.txtTalla8.Name = "txtTalla8"
            Me.txtTalla8.OutputFormat = resources.GetString("txtTalla8.OutputFormat")
            Me.txtTalla8.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla8.Text = "Talla8"
            Me.txtTalla8.Top = 0.765!
            Me.txtTalla8.Width = 0.5!
            '
            'txtTalla9
            '
            Me.txtTalla9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla9.CanGrow = false
            Me.txtTalla9.Height = 0.125!
            Me.txtTalla9.Left = 0.8125!
            Me.txtTalla9.Name = "txtTalla9"
            Me.txtTalla9.OutputFormat = resources.GetString("txtTalla9.OutputFormat")
            Me.txtTalla9.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla9.Text = "Talla9"
            Me.txtTalla9.Top = 0.89!
            Me.txtTalla9.Width = 0.5!
            '
            'txtTalla10
            '
            Me.txtTalla10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla10.CanGrow = false
            Me.txtTalla10.Height = 0.125!
            Me.txtTalla10.Left = 0.8125!
            Me.txtTalla10.Name = "txtTalla10"
            Me.txtTalla10.OutputFormat = resources.GetString("txtTalla10.OutputFormat")
            Me.txtTalla10.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla10.Text = "Talla10"
            Me.txtTalla10.Top = 1.015!
            Me.txtTalla10.Width = 0.5!
            '
            'txtTalla11
            '
            Me.txtTalla11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla11.CanGrow = false
            Me.txtTalla11.Height = 0.125!
            Me.txtTalla11.Left = 0.8125!
            Me.txtTalla11.Name = "txtTalla11"
            Me.txtTalla11.OutputFormat = resources.GetString("txtTalla11.OutputFormat")
            Me.txtTalla11.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla11.Text = "Talla11"
            Me.txtTalla11.Top = 1.14!
            Me.txtTalla11.Width = 0.5!
            '
            'txtTalla12
            '
            Me.txtTalla12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla12.CanGrow = false
            Me.txtTalla12.Height = 0.125!
            Me.txtTalla12.Left = 0.8125!
            Me.txtTalla12.Name = "txtTalla12"
            Me.txtTalla12.OutputFormat = resources.GetString("txtTalla12.OutputFormat")
            Me.txtTalla12.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla12.Text = "Talla12"
            Me.txtTalla12.Top = 1.265!
            Me.txtTalla12.Width = 0.5!
            '
            'txtTalla13
            '
            Me.txtTalla13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.txtTalla13.CanGrow = false
            Me.txtTalla13.Height = 0.125!
            Me.txtTalla13.Left = 0.8125!
            Me.txtTalla13.Name = "txtTalla13"
            Me.txtTalla13.OutputFormat = resources.GetString("txtTalla13.OutputFormat")
            Me.txtTalla13.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.txtTalla13.Text = "Talla13"
            Me.txtTalla13.Top = 1.39!
            Me.txtTalla13.Width = 0.5!
            '
            'lblMex
            '
            Me.lblMex.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMex.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMex.CanGrow = false
            Me.lblMex.Height = 0.125!
            Me.lblMex.Left = 0.125!
            Me.lblMex.Name = "lblMex"
            Me.lblMex.OutputFormat = resources.GetString("lblMex.OutputFormat")
            Me.lblMex.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.lblMex.Text = "MEX"
            Me.lblMex.Top = 0.625!
            Me.lblMex.Width = 0.5!
            '
            'lblMex2
            '
            Me.lblMex2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMex2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMex2.CanGrow = false
            Me.lblMex2.Height = 0.125!
            Me.lblMex2.Left = 0.8125!
            Me.lblMex2.Name = "lblMex2"
            Me.lblMex2.OutputFormat = resources.GetString("lblMex2.OutputFormat")
            Me.lblMex2.Style = "text-align: center; font-weight: bold; font-size: 6.75pt"
            Me.lblMex2.Text = "MEX"
            Me.lblMex2.Top = 0.625!
            Me.lblMex2.Width = 0.5!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.1!
            Me.PageSettings.Margins.Left = 0.3!
            Me.PageSettings.Margins.Right = 0!
            Me.PageSettings.Margins.Top = 0.4!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.9375!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioNormal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioNormal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodFamilia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMex,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMex2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        Dim txtCodigo As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodigo"), DataDynamics.ActiveReports.TextBox)
        EnableControls(False)
        If txtCodigo.Text.Trim() = String.Empty Then
            CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Visible = False
            CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Visible = False
            CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Visible = False
            CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Visible = False
            CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Visible = False
        Else
            CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Visible = True
            CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Visible = True
            CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Visible = True
            CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Visible = True
            CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Visible = True
            Dim txtPrecioOferta As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtPrecioOferta"), DataDynamics.ActiveReports.TextBox)
            If CDec(txtPrecioOferta.Text.Trim()) = 0 Then
                Dim txtPrecio As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox)
                Dim lblPrecio As DataDynamics.ActiveReports.Label = CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label)
                txtPrecio.Location = New PointF(0.438, ptxtPrecioNormal.Y)
                lblPrecio.Location = New PointF(0.438, plblPrecioNormal.Y)
                txtPrecioOferta.Visible = False
                CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Visible = False
            Else
                CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Style &= "text-decoration:line-through;"
            End If
            Dim familia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtFamilia"), DataDynamics.ActiveReports.TextBox)
            Select Case familia.Value
                Case "CABALLERO"
                    Dim CodFamilia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodFamilia"), DataDynamics.ActiveReports.TextBox)
                    familia.Value = "CABALLERO"
                Case "DAMA"
                    Dim CodFamilia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodFamilia"), DataDynamics.ActiveReports.TextBox)
                    familia.Value = "DAMA"
                Case "BOYS", "GIRLS"
                    Dim CodFamilia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodFamilia"), DataDynamics.ActiveReports.TextBox)
                    familia.Value = "JOVEN"
                Case "NIÑOS ESCOLAR", "NIÑOS PRE ESCOLAR"
                    Dim CodFamilia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodFamilia"), DataDynamics.ActiveReports.TextBox)
                    familia.Value = "KIDS"
                Case "BEBE"
                    Dim CodFamilia As DataDynamics.ActiveReports.TextBox = CType(Detail.Controls("txtCodFamilia"), DataDynamics.ActiveReports.TextBox)
                    familia.Value = "BEBE"
                Case "UNISEX"
                    familia.Value = "UNISEX"
            End Select
            Dim corrida() As String = CStr(Me.Fields("Corrida1").Value).Split(",")
            Dim textCorrida As DataDynamics.ActiveReports.TextBox = Nothing, i As Integer = 1
            For i = 0 To corrida.Length - 1 Step 1
                textCorrida = CType(Detail.Controls("txtTalla" & CStr(i + 1)), DataDynamics.ActiveReports.TextBox)
                textCorrida.Border.LeftStyle = BorderLineStyle.Solid
                textCorrida.Border.RightStyle = BorderLineStyle.Solid
                textCorrida.Border.TopStyle = BorderLineStyle.Solid
                textCorrida.Border.BottomStyle = BorderLineStyle.Solid
                textCorrida.Value = corrida(i)
                textCorrida.Visible = True
            Next
            If corrida.Length <= 7 Then
                lblMex2.Border.LeftStyle = BorderLineStyle.Solid
                lblMex2.Border.RightStyle = BorderLineStyle.Solid
                lblMex2.Border.BottomStyle = BorderLineStyle.Solid
            End If
            Select Case linea
                Case 1
                    CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Location = New PointF(pointBarCode.X, pointBarCode.Y + 0.1)
                    CType(Detail.Controls("txtFamilia"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pointTxtLinea.X, pointTxtLinea.Y + 0.35)
                    CType(Detail.Controls("txtCodigo"), DataDynamics.ActiveReports.TextBox).Location = ptxtCodigo
                    CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location = New PointF(CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location.X, plblPrecioNormal.Y)
                    CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Location = plblPrecioOferta
                    CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location = New PointF(CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location.X, ptxtPrecioNormal.Y)
                    CType(Detail.Controls("txtPrecioOferta"), DataDynamics.ActiveReports.TextBox).Location = ptxtPrecioOferta
                    CType(Detail.Controls("txtTalla1"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla1
                    CType(Detail.Controls("txtTalla2"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla2
                    CType(Detail.Controls("txtTalla3"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla3
                    CType(Detail.Controls("txtTalla4"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla4
                    CType(Detail.Controls("txtTalla5"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla5
                    CType(Detail.Controls("txtTalla6"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla6
                    CType(Detail.Controls("txtTalla7"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla7
                    CType(Detail.Controls("txtTalla8"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla8
                    CType(Detail.Controls("txtTalla9"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla9
                    CType(Detail.Controls("txtTalla10"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla10
                    CType(Detail.Controls("txtTalla11"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla11
                    CType(Detail.Controls("txtTalla12"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla12
                    CType(Detail.Controls("txtTalla13"), DataDynamics.ActiveReports.TextBox).Location = lTxtTalla13
                    CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Location = pLblMex
                    CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Location = pLblMex2
                Case 2
                    CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Location = New PointF(pointBarCode.X, pointBarCode.Y) '- 0.008)
                    CType(Detail.Controls("txtFamilia"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pointTxtLinea.X, pointTxtLinea.Y + 0.24)
                    CType(Detail.Controls("txtCodigo"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtCodigo.X, ptxtCodigo.Y - 0.1)
                    CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location = New PointF(CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location.X, plblPrecioNormal.Y - 0.1)
                    CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Location = New PointF(plblPrecioOferta.X, plblPrecioOferta.Y - 0.1)
                    CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location = New PointF(CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location.X, ptxtPrecioNormal.Y - 0.1)
                    CType(Detail.Controls("txtPrecioOferta"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtPrecioOferta.X, ptxtPrecioOferta.Y - 0.1)
                    CType(Detail.Controls("txtTalla1"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla1.X, lTxtTalla1.Y - 0.1)
                    CType(Detail.Controls("txtTalla2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla2.X, lTxtTalla2.Y - 0.1)
                    CType(Detail.Controls("txtTalla3"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla3.X, lTxtTalla3.Y - 0.1)
                    CType(Detail.Controls("txtTalla4"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla4.X, lTxtTalla4.Y - 0.1)
                    CType(Detail.Controls("txtTalla5"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla5.X, lTxtTalla5.Y - 0.1)
                    CType(Detail.Controls("txtTalla6"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla6.X, lTxtTalla6.Y - 0.1)
                    CType(Detail.Controls("txtTalla7"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla7.X, lTxtTalla7.Y - 0.1)
                    CType(Detail.Controls("txtTalla8"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla8.X, lTxtTalla8.Y - 0.1)
                    CType(Detail.Controls("txtTalla9"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla9.X, lTxtTalla9.Y - 0.1)
                    CType(Detail.Controls("txtTalla10"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla10.X, lTxtTalla10.Y - 0.1)
                    CType(Detail.Controls("txtTalla11"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla11.X, lTxtTalla11.Y - 0.1)
                    CType(Detail.Controls("txtTalla12"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla12.X, lTxtTalla12.Y - 0.1)
                    CType(Detail.Controls("txtTalla13"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla13.X, lTxtTalla13.Y - 0.1)
                    CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex.X, pLblMex.Y - 0.1)
                    CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex2.X, pLblMex2.Y - 0.1)
                Case 3
                    CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Location = New PointF(pointBarCode.X, pointBarCode.Y - 0.1)
                    CType(Detail.Controls("txtFamilia"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pointTxtLinea.X, pointTxtLinea.Y + 0.15)
                    CType(Detail.Controls("txtCodigo"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtCodigo.X, ptxtCodigo.Y - 0.2)
                    CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location = New PointF(CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location.X, plblPrecioNormal.Y - 0.2)
                    CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Location = New PointF(plblPrecioOferta.X, plblPrecioOferta.Y - 0.2)
                    CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location = New PointF(CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location.X, ptxtPrecioNormal.Y - 0.2)
                    CType(Detail.Controls("txtPrecioOferta"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtPrecioOferta.X, ptxtPrecioOferta.Y - 0.2)
                    CType(Detail.Controls("txtTalla1"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla1.X, lTxtTalla1.Y - 0.2)
                    CType(Detail.Controls("txtTalla2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla2.X, lTxtTalla2.Y - 0.2)
                    CType(Detail.Controls("txtTalla3"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla3.X, lTxtTalla3.Y - 0.2)
                    CType(Detail.Controls("txtTalla4"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla4.X, lTxtTalla4.Y - 0.2)
                    CType(Detail.Controls("txtTalla5"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla5.X, lTxtTalla5.Y - 0.2)
                    CType(Detail.Controls("txtTalla6"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla6.X, lTxtTalla6.Y - 0.2)
                    CType(Detail.Controls("txtTalla7"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla7.X, lTxtTalla7.Y - 0.2)
                    CType(Detail.Controls("txtTalla8"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla8.X, lTxtTalla8.Y - 0.2)
                    CType(Detail.Controls("txtTalla9"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla9.X, lTxtTalla9.Y - 0.2)
                    CType(Detail.Controls("txtTalla10"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla10.X, lTxtTalla10.Y - 0.2)
                    CType(Detail.Controls("txtTalla11"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla11.X, lTxtTalla11.Y - 0.2)
                    CType(Detail.Controls("txtTalla12"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla12.X, lTxtTalla12.Y - 0.2)
                    CType(Detail.Controls("txtTalla13"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla13.X, lTxtTalla13.Y - 0.2)
                    CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex.X, pLblMex.Y - 0.2)
                    CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex2.X, pLblMex2.Y - 0.2)
                Case 4
                    CType(Detail.Controls("Barcode1"), DataDynamics.ActiveReports.Barcode).Location = New PointF(pointBarCode.X, pointBarCode.Y - 0.2)
                    CType(Detail.Controls("txtFamilia"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pointTxtLinea.X, pointTxtLinea.Y + 0.05)
                    CType(Detail.Controls("txtCodigo"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtCodigo.X, ptxtCodigo.Y - 0.255)
                    CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location = New PointF(CType(Detail.Controls("lblPrecioNormal"), DataDynamics.ActiveReports.Label).Location.X, plblPrecioNormal.Y - 0.3)
                    CType(Detail.Controls("lblPrecioOferta"), DataDynamics.ActiveReports.Label).Location = New PointF(plblPrecioOferta.X, plblPrecioOferta.Y - 0.3)
                    CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location = New PointF(CType(Detail.Controls("txtPrecioNormal"), DataDynamics.ActiveReports.TextBox).Location.X, ptxtPrecioNormal.Y - 0.3)
                    CType(Detail.Controls("txtPrecioOferta"), DataDynamics.ActiveReports.TextBox).Location = New PointF(ptxtPrecioOferta.X, ptxtPrecioOferta.Y - 0.3)
                    CType(Detail.Controls("txtTalla1"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla1.X, lTxtTalla1.Y - 0.3)
                    CType(Detail.Controls("txtTalla2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla2.X, lTxtTalla2.Y - 0.3)
                    CType(Detail.Controls("txtTalla3"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla3.X, lTxtTalla3.Y - 0.3)
                    CType(Detail.Controls("txtTalla4"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla4.X, lTxtTalla4.Y - 0.3)
                    CType(Detail.Controls("txtTalla5"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla5.X, lTxtTalla5.Y - 0.3)
                    CType(Detail.Controls("txtTalla6"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla6.X, lTxtTalla6.Y - 0.3)
                    CType(Detail.Controls("txtTalla7"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla7.X, lTxtTalla7.Y - 0.3)
                    CType(Detail.Controls("txtTalla8"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla8.X, lTxtTalla8.Y - 0.3)
                    CType(Detail.Controls("txtTalla9"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla9.X, lTxtTalla9.Y - 0.3)
                    CType(Detail.Controls("txtTalla10"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla10.X, lTxtTalla10.Y - 0.3)
                    CType(Detail.Controls("txtTalla11"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla11.X, lTxtTalla11.Y - 0.3)
                    CType(Detail.Controls("txtTalla12"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla12.X, lTxtTalla12.Y - 0.3)
                    CType(Detail.Controls("txtTalla13"), DataDynamics.ActiveReports.TextBox).Location = New PointF(lTxtTalla13.X, lTxtTalla13.Y - 0.3)
                    CType(Detail.Controls("lblMex"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex.X, pLblMex.Y - 0.3)
                    CType(Detail.Controls("lblMex2"), DataDynamics.ActiveReports.TextBox).Location = New PointF(pLblMex2.X, pLblMex2.Y - 0.3)
            End Select
        End If
        If index Mod 4 = 0 Then
            If linea = 4 Then
                linea = 1
            Else
                linea += 1
            End If
        End If
        index += 1
    End Sub

    Private Sub EnableControls(ByVal enable As Boolean)
        Dim i As Integer = 1
        For i = 1 To 13 Step 1
            CType(Detail.Controls("txtTalla" & CStr(i)), DataDynamics.ActiveReports.TextBox).Visible = enable
            CType(Detail.Controls("txtTalla" & CStr(i)), DataDynamics.ActiveReports.TextBox).Text = ""
        Next
    End Sub
End Class
