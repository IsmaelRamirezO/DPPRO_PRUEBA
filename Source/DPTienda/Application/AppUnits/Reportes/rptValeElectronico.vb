Imports System
Imports System.Collections.Generic
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document


Public Class rptValeElectronico
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private TextoPagare As String = "Por este pagaré, me obligo a pagar incondicionalmente a la orden de {0} el día {1} del mes de {2} del año {3} , en su domicilio ubicado en {4} de la ciudad de {5} , la cantidad de: {6} (en letra: {7} Valor recibido a mi entera satisfacción. Si el presente pagaré no fuera cubierto el día señalado para su pago, cubriré además del importe de este documento, el {8}% mensual de interés moratorio,  desde el día en que debió ser pagado hasta el día que sea cubierto totalmente el presente pagaré, sometiéndome expresamente a la jurisdicción de los tribunales que el tenedor del documento señale, renunciando expresamente al fuero que por razón de mi domicilio presente o futuro me llegare a corresponder."

    Public Sub New(ByVal ValeElectronico As Dictionary(Of String, Object))
        MyBase.New()
        InitializeComponent()

        Me.txtFolio.Text = CStr(ValeElectronico("NUMVA"))
        Me.txtAcreditado.Text = CStr(ValeElectronico("KUNNR"))
        Me.txtFechaEmision.Text = CDate(ValeElectronico("FechaEmision")).ToString("dd/MM/yyyy")
        Me.txtSurtir.Text = CStr(ValeElectronico("NombreCODCT"))
        Me.txtDomicilio.Text = CStr(ValeElectronico("DomicilioCODCT"))
        Me.txtTelefono.Text = CStr(ValeElectronico("TelefonoCODCT"))

        'TextoPagare = TextoPagare.Replace("{0}", "<u>" & CStr(ValeElectronico("PagareDportenis")) & "</u> ")
        'TextoPagare = TextoPagare.Replace("{1}", "<u>" & CStr(DateTime.Now.ToString("dd")) & "</u>")
        'TextoPagare = TextoPagare.Replace("{2}", "<u>" & DateTime.Now.ToString("MM") & "</u>")
        'TextoPagare = TextoPagare.Replace("{3}", "<u>" & DateTime.Now.ToString("yyyy") & "</u>")
        'TextoPagare = TextoPagare.Replace("{4}", "<u>" & CStr(ValeElectronico("PagareDomicilio")) & "</u> ")
        'TextoPagare = TextoPagare.Replace("{5}", "<u>" & CStr(ValeElectronico("PagareCiudad")) & "</u> ")
        'TextoPagare = TextoPagare.Replace("{6}", "<u>" & CDec(ValeElectronico("Monto")).ToString("##,##0.00") & "</u> ")
        'TextoPagare = TextoPagare.Replace("{7}", "<u>" & CStr(ValeElectronico("MontoLetra")) & "</u> ")
        'TextoPagare = TextoPagare.Replace("{8}", "<u>" & CStr(ValeElectronico("PagarePorcentaje")) & "</u> ")


        'Me.txtEn.Text = CStr(ValeElectronico("PagareCiudad"))
        'Me.txtA.Text = DateTime.Now.ToString("dd")
        'Me.txtMes.Text = DateTime.Now.ToString("MMMM")
        'Me.txtAnio.Text = DateTime.Now.ToString("yy")
        'Me.txtNombreFirma.Text = CStr(ValeElectronico("NombreCODCT"))
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents imgDportenis As DataDynamics.ActiveReports.Picture
    Friend WithEvents imgdpstreet As DataDynamics.ActiveReports.Picture
    Friend WithEvents imgDPDinero As DataDynamics.ActiveReports.Picture
    Friend WithEvents imgDPVale As DataDynamics.ActiveReports.Picture
    Private WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Private WithEvents lblFolio As DataDynamics.ActiveReports.Label
    Private WithEvents txtFolio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAcreditado As DataDynamics.ActiveReports.Label
    Friend WithEvents txtAcreditado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaEmision As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaEmision As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSurtir As DataDynamics.ActiveReports.Label
    Private WithEvents lineaSurtir As DataDynamics.ActiveReports.Line
    Friend WithEvents txtSurtir As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDomicilio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDomicilio As DataDynamics.ActiveReports.TextBox
    Private WithEvents lineaDomicilio As DataDynamics.ActiveReports.Line
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Private WithEvents lineaTelefono As DataDynamics.ActiveReports.Line
    Friend WithEvents lblNombreFirma As DataDynamics.ActiveReports.Label
    Private WithEvents lineaNombreFirma As DataDynamics.ActiveReports.Line
    Friend WithEvents lblFirmaCliente As DataDynamics.ActiveReports.Label
    Friend WithEvents lineaFirma As DataDynamics.ActiveReports.Line
    Friend WithEvents lblEn As DataDynamics.ActiveReports.Label
    Friend WithEvents lineaEn As DataDynamics.ActiveReports.Line
    Friend WithEvents txtEn As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblA As DataDynamics.ActiveReports.Label
    Private WithEvents lineaA As DataDynamics.ActiveReports.Line
    Friend WithEvents txtA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDe As DataDynamics.ActiveReports.Label
    Friend WithEvents lineaMes As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblYear As DataDynamics.ActiveReports.Label
    Friend WithEvents lineaYear As DataDynamics.ActiveReports.Line
    Friend WithEvents txtAnio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreFirma As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblPagare As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare5 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare8 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare9 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare10 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare12 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare14 As DataDynamics.ActiveReports.Label
    Friend WithEvents lbPagare15 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPagare17 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPagare18 As DataDynamics.ActiveReports.Label
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptValeElectronico))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.txtNombreFirma = New DataDynamics.ActiveReports.TextBox()
        Me.txtAnio = New DataDynamics.ActiveReports.TextBox()
        Me.txtMes = New DataDynamics.ActiveReports.TextBox()
        Me.txtA = New DataDynamics.ActiveReports.TextBox()
        Me.imgDportenis = New DataDynamics.ActiveReports.Picture()
        Me.imgdpstreet = New DataDynamics.ActiveReports.Picture()
        Me.imgDPDinero = New DataDynamics.ActiveReports.Picture()
        Me.imgDPVale = New DataDynamics.ActiveReports.Picture()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.lblFolio = New DataDynamics.ActiveReports.Label()
        Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
        Me.lblAcreditado = New DataDynamics.ActiveReports.Label()
        Me.txtAcreditado = New DataDynamics.ActiveReports.TextBox()
        Me.lblFechaEmision = New DataDynamics.ActiveReports.Label()
        Me.txtFechaEmision = New DataDynamics.ActiveReports.TextBox()
        Me.lblSurtir = New DataDynamics.ActiveReports.Label()
        Me.lineaSurtir = New DataDynamics.ActiveReports.Line()
        Me.txtSurtir = New DataDynamics.ActiveReports.TextBox()
        Me.lblDomicilio = New DataDynamics.ActiveReports.Label()
        Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox()
        Me.lineaDomicilio = New DataDynamics.ActiveReports.Line()
        Me.lblTelefono = New DataDynamics.ActiveReports.Label()
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox()
        Me.lineaTelefono = New DataDynamics.ActiveReports.Line()
        Me.lblNombreFirma = New DataDynamics.ActiveReports.Label()
        Me.lineaNombreFirma = New DataDynamics.ActiveReports.Line()
        Me.lblFirmaCliente = New DataDynamics.ActiveReports.Label()
        Me.lineaFirma = New DataDynamics.ActiveReports.Line()
        Me.lblEn = New DataDynamics.ActiveReports.Label()
        Me.lineaEn = New DataDynamics.ActiveReports.Line()
        Me.txtEn = New DataDynamics.ActiveReports.TextBox()
        Me.lblA = New DataDynamics.ActiveReports.Label()
        Me.lineaA = New DataDynamics.ActiveReports.Line()
        Me.lblDe = New DataDynamics.ActiveReports.Label()
        Me.lineaMes = New DataDynamics.ActiveReports.Line()
        Me.lblYear = New DataDynamics.ActiveReports.Label()
        Me.lineaYear = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Shape2 = New DataDynamics.ActiveReports.Shape()
        Me.lblPagare = New DataDynamics.ActiveReports.Label()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare2 = New DataDynamics.ActiveReports.Label()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare3 = New DataDynamics.ActiveReports.Label()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare4 = New DataDynamics.ActiveReports.Label()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare5 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare6 = New DataDynamics.ActiveReports.Label()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare7 = New DataDynamics.ActiveReports.Label()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare8 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare9 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare10 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare11 = New DataDynamics.ActiveReports.Label()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare12 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare13 = New DataDynamics.ActiveReports.Label()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare14 = New DataDynamics.ActiveReports.Label()
        Me.lbPagare15 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare16 = New DataDynamics.ActiveReports.Label()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.lblPagare17 = New DataDynamics.ActiveReports.Label()
        Me.lblPagare18 = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        CType(Me.txtNombreFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDportenis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgdpstreet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDPDinero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDPVale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAcreditado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAcreditado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaEmision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEmision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSurtir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSurtir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbPagare15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPagare18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Height = 0.0!
        Me.Detail.Name = "Detail"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNombreFirma, Me.txtAnio, Me.txtMes, Me.txtA, Me.imgDportenis, Me.imgdpstreet, Me.imgDPDinero, Me.imgDPVale, Me.Shape1, Me.lblFolio, Me.txtFolio, Me.lblAcreditado, Me.txtAcreditado, Me.lblFechaEmision, Me.txtFechaEmision, Me.lblSurtir, Me.lineaSurtir, Me.txtSurtir, Me.lblDomicilio, Me.txtDomicilio, Me.lineaDomicilio, Me.lblTelefono, Me.txtTelefono, Me.lineaTelefono, Me.lblNombreFirma, Me.lineaNombreFirma, Me.lblFirmaCliente, Me.lineaFirma, Me.lblEn, Me.lineaEn, Me.txtEn, Me.lblA, Me.lineaA, Me.lblDe, Me.lineaMes, Me.lblYear, Me.lineaYear, Me.Line1, Me.Shape2, Me.lblPagare, Me.Line2, Me.Line3, Me.lblPagare2, Me.Line4, Me.lblPagare3, Me.Line5, Me.lblPagare4, Me.Line6, Me.lblPagare5, Me.lblPagare6, Me.Line7, Me.lblPagare7, Me.Line8, Me.lblPagare8, Me.lblPagare9, Me.lblPagare10, Me.lblPagare11, Me.Line9, Me.lblPagare12, Me.lblPagare13, Me.Line10, Me.lblPagare14, Me.lbPagare15, Me.lblPagare16, Me.Line11, Me.lblPagare17, Me.lblPagare18})
        Me.ReportHeader.Height = 6.811804!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'txtNombreFirma
        '
        Me.txtNombreFirma.Height = 0.1879999!
        Me.txtNombreFirma.Left = 0.8350002!
        Me.txtNombreFirma.Name = "txtNombreFirma"
        Me.txtNombreFirma.Style = "color: #1F487D; text-align: left"
        Me.txtNombreFirma.Text = Nothing
        Me.txtNombreFirma.Top = 5.625!
        Me.txtNombreFirma.Width = 3.073!
        '
        'txtAnio
        '
        Me.txtAnio.Height = 0.1879999!
        Me.txtAnio.Left = 5.231!
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Style = "color: #1F487D; text-align: center"
        Me.txtAnio.Text = Nothing
        Me.txtAnio.Top = 5.082!
        Me.txtAnio.Width = 0.277!
        '
        'txtMes
        '
        Me.txtMes.Height = 0.1879999!
        Me.txtMes.Left = 3.529!
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Style = "color: #1F487D; text-align: center"
        Me.txtMes.Text = Nothing
        Me.txtMes.Top = 5.082!
        Me.txtMes.Width = 1.279!
        '
        'txtA
        '
        Me.txtA.Height = 0.1879999!
        Me.txtA.Left = 2.834!
        Me.txtA.Name = "txtA"
        Me.txtA.Style = "color: #1F487D; text-align: center"
        Me.txtA.Text = Nothing
        Me.txtA.Top = 5.082!
        Me.txtA.Width = 0.474!
        '
        'imgDportenis
        '
        Me.imgDportenis.Height = 0.6140001!
        Me.imgDportenis.ImageData = CType(resources.GetObject("imgDportenis.ImageData"), System.IO.Stream)
        Me.imgDportenis.Left = 0.166!
        Me.imgDportenis.LineWeight = 0.0!
        Me.imgDportenis.Name = "imgDportenis"
        Me.imgDportenis.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.imgDportenis.Top = 0.509!
        Me.imgDportenis.Width = 1.031!
        '
        'imgdpstreet
        '
        Me.imgdpstreet.Height = 0.6140001!
        Me.imgdpstreet.ImageData = CType(resources.GetObject("imgdpstreet.ImageData"), System.IO.Stream)
        Me.imgdpstreet.Left = 1.531!
        Me.imgdpstreet.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.imgdpstreet.LineWeight = 0.0!
        Me.imgdpstreet.Name = "imgdpstreet"
        Me.imgdpstreet.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.imgdpstreet.Top = 0.509!
        Me.imgdpstreet.Width = 1.031!
        '
        'imgDPDinero
        '
        Me.imgDPDinero.Height = 0.6140001!
        Me.imgDPDinero.ImageData = CType(resources.GetObject("imgDPDinero.ImageData"), System.IO.Stream)
        Me.imgDPDinero.Left = 3.135!
        Me.imgDPDinero.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.imgDPDinero.LineWeight = 0.0!
        Me.imgDPDinero.Name = "imgDPDinero"
        Me.imgDPDinero.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.imgDPDinero.Top = 0.509!
        Me.imgDPDinero.Width = 1.031!
        '
        'imgDPVale
        '
        Me.imgDPVale.Height = 0.6140001!
        Me.imgDPVale.ImageData = CType(resources.GetObject("imgDPVale.ImageData"), System.IO.Stream)
        Me.imgDPVale.Left = 4.833!
        Me.imgDPVale.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.imgDPVale.LineWeight = 0.0!
        Me.imgDPVale.Name = "imgDPVale"
        Me.imgDPVale.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom
        Me.imgDPVale.Top = 0.5089999!
        Me.imgDPVale.Width = 1.031!
        '
        'Shape1
        '
        Me.Shape1.Height = 1.469!
        Me.Shape1.Left = 0.063!
        Me.Shape1.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Shape1.LineWeight = 7.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Style = DataDynamics.ActiveReports.ShapeType.RoundRect
        Me.Shape1.Top = 1.156!
        Me.Shape1.Width = 6.167!
        '
        'lblFolio
        '
        Me.lblFolio.Height = 0.188!
        Me.lblFolio.HyperLink = Nothing
        Me.lblFolio.Left = 0.172!
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Style = "font-weight: bold; color: #1F487D"
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.Top = 1.385!
        Me.lblFolio.Width = 0.76!
        '
        'txtFolio
        '
        Me.txtFolio.Height = 0.188!
        Me.txtFolio.Left = 0.9320002!
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Style = "color: #1F487D"
        Me.txtFolio.Text = Nothing
        Me.txtFolio.Top = 1.385!
        Me.txtFolio.Width = 1.135!
        '
        'lblAcreditado
        '
        Me.lblAcreditado.Height = 0.1879999!
        Me.lblAcreditado.HyperLink = Nothing
        Me.lblAcreditado.Left = 2.213!
        Me.lblAcreditado.Name = "lblAcreditado"
        Me.lblAcreditado.Style = "font-weight: bold; color: #1F487D"
        Me.lblAcreditado.Text = "Distribuidor"
        Me.lblAcreditado.Top = 1.385!
        Me.lblAcreditado.Width = 0.8330002!
        '
        'txtAcreditado
        '
        Me.txtAcreditado.Height = 0.1879999!
        Me.txtAcreditado.Left = 3.046!
        Me.txtAcreditado.Name = "txtAcreditado"
        Me.txtAcreditado.Style = "color: #1F487D"
        Me.txtAcreditado.Text = Nothing
        Me.txtAcreditado.Top = 1.385!
        Me.txtAcreditado.Width = 1.135!
        '
        'lblFechaEmision
        '
        Me.lblFechaEmision.Height = 0.1879999!
        Me.lblFechaEmision.HyperLink = Nothing
        Me.lblFechaEmision.Left = 4.181!
        Me.lblFechaEmision.Name = "lblFechaEmision"
        Me.lblFechaEmision.Style = "font-weight: bold; color: #1F487D; font-size: 8pt"
        Me.lblFechaEmision.Text = "Fecha Compra:"
        Me.lblFechaEmision.Top = 1.385!
        Me.lblFechaEmision.Width = 1.05!
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Height = 0.1879999!
        Me.txtFechaEmision.Left = 5.231!
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.Style = "color: #1F487D; text-align: center; font-size: 8pt"
        Me.txtFechaEmision.Text = Nothing
        Me.txtFechaEmision.Top = 1.385!
        Me.txtFechaEmision.Width = 0.9249997!
        '
        'lblSurtir
        '
        Me.lblSurtir.Height = 0.1879999!
        Me.lblSurtir.HyperLink = Nothing
        Me.lblSurtir.Left = 0.153!
        Me.lblSurtir.Name = "lblSurtir"
        Me.lblSurtir.Style = "font-weight: normal; color: #1F487D"
        Me.lblSurtir.Text = "Súrtase por este vale a: "
        Me.lblSurtir.Top = 1.742!
        Me.lblSurtir.Width = 1.604!
        '
        'lineaSurtir
        '
        Me.lineaSurtir.Height = 0.001999974!
        Me.lineaSurtir.Left = 1.781!
        Me.lineaSurtir.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaSurtir.LineWeight = 1.0!
        Me.lineaSurtir.Name = "lineaSurtir"
        Me.lineaSurtir.Top = 1.930003!
        Me.lineaSurtir.Width = 4.306!
        Me.lineaSurtir.X1 = 1.781!
        Me.lineaSurtir.X2 = 6.087!
        Me.lineaSurtir.Y1 = 1.930003!
        Me.lineaSurtir.Y2 = 1.932003!
        '
        'txtSurtir
        '
        Me.txtSurtir.Height = 0.1879999!
        Me.txtSurtir.Left = 1.781!
        Me.txtSurtir.Name = "txtSurtir"
        Me.txtSurtir.Style = "color: #1F487D"
        Me.txtSurtir.Text = Nothing
        Me.txtSurtir.Top = 1.762!
        Me.txtSurtir.Width = 4.311!
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Height = 0.1879999!
        Me.lblDomicilio.HyperLink = Nothing
        Me.lblDomicilio.Left = 0.153!
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Style = "font-weight: normal; color: #1F487D"
        Me.lblDomicilio.Text = "Domicilio:"
        Me.lblDomicilio.Top = 1.975004!
        Me.lblDomicilio.Width = 0.766!
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Height = 0.188!
        Me.txtDomicilio.Left = 0.9320002!
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Style = "color: #1F487D"
        Me.txtDomicilio.Text = Nothing
        Me.txtDomicilio.Top = 1.995004!
        Me.txtDomicilio.Width = 5.168!
        '
        'lineaDomicilio
        '
        Me.lineaDomicilio.Height = 0.0!
        Me.lineaDomicilio.Left = 0.9190003!
        Me.lineaDomicilio.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaDomicilio.LineWeight = 1.0!
        Me.lineaDomicilio.Name = "lineaDomicilio"
        Me.lineaDomicilio.Top = 2.162008!
        Me.lineaDomicilio.Width = 5.181!
        Me.lineaDomicilio.X1 = 0.9190003!
        Me.lineaDomicilio.X2 = 6.1!
        Me.lineaDomicilio.Y1 = 2.162008!
        Me.lineaDomicilio.Y2 = 2.162008!
        '
        'lblTelefono
        '
        Me.lblTelefono.Height = 0.1879999!
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Left = 2.6!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "font-weight: normal; color: #1F487D"
        Me.lblTelefono.Text = "Telefono:"
        Me.lblTelefono.Top = 2.203!
        Me.lblTelefono.Width = 0.766!
        '
        'txtTelefono
        '
        Me.txtTelefono.Height = 0.1879999!
        Me.txtTelefono.Left = 3.366!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "color: #1F487D"
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.Top = 2.203!
        Me.txtTelefono.Width = 2.734!
        '
        'lineaTelefono
        '
        Me.lineaTelefono.Height = 0.001000166!
        Me.lineaTelefono.Left = 3.373!
        Me.lineaTelefono.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaTelefono.LineWeight = 1.0!
        Me.lineaTelefono.Name = "lineaTelefono"
        Me.lineaTelefono.Top = 2.37!
        Me.lineaTelefono.Width = 2.714!
        Me.lineaTelefono.X1 = 3.373!
        Me.lineaTelefono.X2 = 6.087!
        Me.lineaTelefono.Y1 = 2.371!
        Me.lineaTelefono.Y2 = 2.37!
        '
        'lblNombreFirma
        '
        Me.lblNombreFirma.Height = 0.1879999!
        Me.lblNombreFirma.HyperLink = Nothing
        Me.lblNombreFirma.Left = 0.2160001!
        Me.lblNombreFirma.Name = "lblNombreFirma"
        Me.lblNombreFirma.Style = "font-weight: normal; color: #1F487D"
        Me.lblNombreFirma.Text = "Nombre:"
        Me.lblNombreFirma.Top = 5.625!
        Me.lblNombreFirma.Width = 0.619!
        '
        'lineaNombreFirma
        '
        Me.lineaNombreFirma.Height = 0.0!
        Me.lineaNombreFirma.Left = 0.8350002!
        Me.lineaNombreFirma.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaNombreFirma.LineWeight = 1.0!
        Me.lineaNombreFirma.Name = "lineaNombreFirma"
        Me.lineaNombreFirma.Top = 5.812999!
        Me.lineaNombreFirma.Width = 3.073!
        Me.lineaNombreFirma.X1 = 0.8350002!
        Me.lineaNombreFirma.X2 = 3.908!
        Me.lineaNombreFirma.Y1 = 5.812999!
        Me.lineaNombreFirma.Y2 = 5.812999!
        '
        'lblFirmaCliente
        '
        Me.lblFirmaCliente.Height = 0.1879999!
        Me.lblFirmaCliente.HyperLink = Nothing
        Me.lblFirmaCliente.Left = 0.2160001!
        Me.lblFirmaCliente.Name = "lblFirmaCliente"
        Me.lblFirmaCliente.Style = "font-weight: normal; color: #1F487D; text-align: center"
        Me.lblFirmaCliente.Text = "Firma"
        Me.lblFirmaCliente.Top = 6.179!
        Me.lblFirmaCliente.Width = 3.392!
        '
        'lineaFirma
        '
        Me.lineaFirma.Height = 0.001998901!
        Me.lineaFirma.Left = 0.2160001!
        Me.lineaFirma.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaFirma.LineWeight = 1.0!
        Me.lineaFirma.Name = "lineaFirma"
        Me.lineaFirma.Top = 6.156!
        Me.lineaFirma.Width = 3.392!
        Me.lineaFirma.X1 = 0.2160001!
        Me.lineaFirma.X2 = 3.608!
        Me.lineaFirma.Y1 = 6.156!
        Me.lineaFirma.Y2 = 6.157999!
        '
        'lblEn
        '
        Me.lblEn.Height = 0.1879999!
        Me.lblEn.HyperLink = Nothing
        Me.lblEn.Left = 0.171!
        Me.lblEn.Name = "lblEn"
        Me.lblEn.Style = "font-weight: normal; color: #1F487D"
        Me.lblEn.Text = "En"
        Me.lblEn.Top = 5.082!
        Me.lblEn.Width = 0.239!
        '
        'lineaEn
        '
        Me.lineaEn.Height = 0.001999378!
        Me.lineaEn.Left = 0.4200001!
        Me.lineaEn.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaEn.LineWeight = 1.0!
        Me.lineaEn.Name = "lineaEn"
        Me.lineaEn.Top = 5.258001!
        Me.lineaEn.Width = 2.288!
        Me.lineaEn.X1 = 0.4200001!
        Me.lineaEn.X2 = 2.708!
        Me.lineaEn.Y1 = 5.26!
        Me.lineaEn.Y2 = 5.258001!
        '
        'txtEn
        '
        Me.txtEn.Height = 0.1879999!
        Me.txtEn.Left = 0.41!
        Me.txtEn.Name = "txtEn"
        Me.txtEn.Style = "color: #1F487D; text-align: center"
        Me.txtEn.Text = Nothing
        Me.txtEn.Top = 5.082!
        Me.txtEn.Width = 2.298!
        '
        'lblA
        '
        Me.lblA.Height = 0.1879999!
        Me.lblA.HyperLink = Nothing
        Me.lblA.Left = 2.708!
        Me.lblA.Name = "lblA"
        Me.lblA.Style = "font-weight: normal; color: #1F487D"
        Me.lblA.Text = "a"
        Me.lblA.Top = 5.082!
        Me.lblA.Width = 0.1259999!
        '
        'lineaA
        '
        Me.lineaA.Height = 0.0!
        Me.lineaA.Left = 2.834!
        Me.lineaA.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaA.LineWeight = 1.0!
        Me.lineaA.Name = "lineaA"
        Me.lineaA.Top = 5.27!
        Me.lineaA.Width = 0.474!
        Me.lineaA.X1 = 2.834!
        Me.lineaA.X2 = 3.308!
        Me.lineaA.Y1 = 5.27!
        Me.lineaA.Y2 = 5.27!
        '
        'lblDe
        '
        Me.lblDe.Height = 0.1879999!
        Me.lblDe.HyperLink = Nothing
        Me.lblDe.Left = 3.308!
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Style = "font-weight: normal; color: #1F487D"
        Me.lblDe.Text = "de"
        Me.lblDe.Top = 5.082!
        Me.lblDe.Width = 0.2180001!
        '
        'lineaMes
        '
        Me.lineaMes.Height = 0.0!
        Me.lineaMes.Left = 3.529!
        Me.lineaMes.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaMes.LineWeight = 1.0!
        Me.lineaMes.Name = "lineaMes"
        Me.lineaMes.Top = 5.27!
        Me.lineaMes.Width = 1.279!
        Me.lineaMes.X1 = 3.529!
        Me.lineaMes.X2 = 4.808!
        Me.lineaMes.Y1 = 5.27!
        Me.lineaMes.Y2 = 5.27!
        '
        'lblYear
        '
        Me.lblYear.Height = 0.1879999!
        Me.lblYear.HyperLink = Nothing
        Me.lblYear.Left = 4.808!
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Style = "font-weight: normal; color: #1F487D"
        Me.lblYear.Text = "de 20"
        Me.lblYear.Top = 5.082!
        Me.lblYear.Width = 0.423!
        '
        'lineaYear
        '
        Me.lineaYear.Height = 0.0!
        Me.lineaYear.Left = 5.231!
        Me.lineaYear.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.lineaYear.LineWeight = 1.0!
        Me.lineaYear.Name = "lineaYear"
        Me.lineaYear.Top = 5.27!
        Me.lineaYear.Width = 0.277!
        Me.lineaYear.X1 = 5.231!
        Me.lineaYear.X2 = 5.508!
        Me.lineaYear.Y1 = 5.27!
        Me.lineaYear.Y2 = 5.27!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.211!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.371!
        Me.Line1.Width = 2.388999!
        Me.Line1.X1 = 0.211!
        Me.Line1.X2 = 2.599999!
        Me.Line1.Y1 = 2.371!
        Me.Line1.Y2 = 2.371!
        '
        'Shape2
        '
        Me.Shape2.Height = 3.916!
        Me.Shape2.Left = 0.063!
        Me.Shape2.LineColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.Shape2.LineWeight = 4.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 2.771!
        Me.Shape2.Width = 6.166999!
        '
        'lblPagare
        '
        Me.lblPagare.Height = 0.1879999!
        Me.lblPagare.HyperLink = Nothing
        Me.lblPagare.Left = 0.153!
        Me.lblPagare.Name = "lblPagare"
        Me.lblPagare.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare.Text = "Por este pagaré, me obligo a pagar incondicionalmente a la orden de:"
        Me.lblPagare.Top = 2.927!
        Me.lblPagare.Width = 3.647!
        '
        'Line2
        '
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 3.758!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 3.085!
        Me.Line2.Width = 2.389001!
        Me.Line2.X1 = 3.758!
        Me.Line2.X2 = 6.147001!
        Me.Line2.Y1 = 3.085!
        Me.Line2.Y2 = 3.085!
        '
        'Line3
        '
        Me.Line3.Height = 0.003000021!
        Me.Line3.Left = 0.153!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 3.29!
        Me.Line3.Width = 0.947!
        Me.Line3.X1 = 0.153!
        Me.Line3.X2 = 1.1!
        Me.Line3.Y1 = 3.293!
        Me.Line3.Y2 = 3.29!
        '
        'lblPagare2
        '
        Me.lblPagare2.Height = 0.1879999!
        Me.lblPagare2.HyperLink = Nothing
        Me.lblPagare2.Left = 1.1!
        Me.lblPagare2.Name = "lblPagare2"
        Me.lblPagare2.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare2.Text = "el día de"
        Me.lblPagare2.Top = 3.135!
        Me.lblPagare2.Width = 0.5520002!
        '
        'Line4
        '
        Me.Line4.Height = 0.003000021!
        Me.Line4.Left = 1.615!
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 3.29!
        Me.Line4.Width = 0.385!
        Me.Line4.X1 = 1.615!
        Me.Line4.X2 = 2.0!
        Me.Line4.Y1 = 3.29!
        Me.Line4.Y2 = 3.293!
        '
        'lblPagare3
        '
        Me.lblPagare3.Height = 0.1879999!
        Me.lblPagare3.HyperLink = Nothing
        Me.lblPagare3.Left = 2.014!
        Me.lblPagare3.Name = "lblPagare3"
        Me.lblPagare3.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare3.Text = "del mes de"
        Me.lblPagare3.Top = 3.135!
        Me.lblPagare3.Width = 0.649!
        '
        'Line5
        '
        Me.Line5.Height = 0.003000021!
        Me.Line5.Left = 2.653!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 3.293!
        Me.Line5.Width = 0.9469998!
        Me.Line5.X1 = 2.653!
        Me.Line5.X2 = 3.6!
        Me.Line5.Y1 = 3.296!
        Me.Line5.Y2 = 3.293!
        '
        'lblPagare4
        '
        Me.lblPagare4.Height = 0.1879999!
        Me.lblPagare4.HyperLink = Nothing
        Me.lblPagare4.Left = 3.6!
        Me.lblPagare4.Name = "lblPagare4"
        Me.lblPagare4.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare4.Text = "del año"
        Me.lblPagare4.Top = 3.135!
        Me.lblPagare4.Width = 0.4719999!
        '
        'Line6
        '
        Me.Line6.Height = 0.003000021!
        Me.Line6.Left = 4.031!
        Me.Line6.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 3.287!
        Me.Line6.Width = 0.579!
        Me.Line6.X1 = 4.031!
        Me.Line6.X2 = 4.61!
        Me.Line6.Y1 = 3.29!
        Me.Line6.Y2 = 3.287!
        '
        'lblPagare5
        '
        Me.lblPagare5.Height = 0.1879999!
        Me.lblPagare5.HyperLink = Nothing
        Me.lblPagare5.Left = 4.632!
        Me.lblPagare5.Name = "lblPagare5"
        Me.lblPagare5.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare5.Text = ", en su domicilio ubicado"
        Me.lblPagare5.Top = 3.135!
        Me.lblPagare5.Width = 1.451!
        '
        'lblPagare6
        '
        Me.lblPagare6.Height = 0.1879999!
        Me.lblPagare6.HyperLink = Nothing
        Me.lblPagare6.Left = 0.153!
        Me.lblPagare6.Name = "lblPagare6"
        Me.lblPagare6.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare6.Text = "en"
        Me.lblPagare6.Top = 3.343!
        Me.lblPagare6.Width = 0.218!
        '
        'Line7
        '
        Me.Line7.Height = 0.003000021!
        Me.Line7.Left = 0.332!
        Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 3.498!
        Me.Line7.Width = 2.868!
        Me.Line7.X1 = 0.332!
        Me.Line7.X2 = 3.2!
        Me.Line7.Y1 = 3.501!
        Me.Line7.Y2 = 3.498!
        '
        'lblPagare7
        '
        Me.lblPagare7.Height = 0.1879999!
        Me.lblPagare7.HyperLink = Nothing
        Me.lblPagare7.Left = 3.2!
        Me.lblPagare7.Name = "lblPagare7"
        Me.lblPagare7.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare7.Text = "en la ciudad de"
        Me.lblPagare7.Top = 3.343!
        Me.lblPagare7.Width = 0.872!
        '
        'Line8
        '
        Me.Line8.Height = 0.0!
        Me.Line8.Left = 4.041!
        Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 3.498!
        Me.Line8.Width = 1.649!
        Me.Line8.X1 = 4.041!
        Me.Line8.X2 = 5.69!
        Me.Line8.Y1 = 3.498!
        Me.Line8.Y2 = 3.498!
        '
        'lblPagare8
        '
        Me.lblPagare8.Height = 0.1879999!
        Me.lblPagare8.HyperLink = Nothing
        Me.lblPagare8.Left = 5.728!
        Me.lblPagare8.Name = "lblPagare8"
        Me.lblPagare8.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare8.Text = ", la"
        Me.lblPagare8.Top = 3.343!
        Me.lblPagare8.Width = 0.218!
        '
        'lblPagare9
        '
        Me.lblPagare9.Height = 0.1879999!
        Me.lblPagare9.HyperLink = Nothing
        Me.lblPagare9.Left = 0.153!
        Me.lblPagare9.Name = "lblPagare9"
        Me.lblPagare9.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare9.Text = "cantidad"
        Me.lblPagare9.Top = 3.575!
        Me.lblPagare9.Width = 0.521!
        '
        'lblPagare10
        '
        Me.lblPagare10.Height = 0.1879999!
        Me.lblPagare10.HyperLink = Nothing
        Me.lblPagare10.Left = 2.014!
        Me.lblPagare10.Name = "lblPagare10"
        Me.lblPagare10.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare10.Text = "de"
        Me.lblPagare10.Top = 3.575!
        Me.lblPagare10.Width = 0.1989998!
        '
        'lblPagare11
        '
        Me.lblPagare11.Height = 0.1879999!
        Me.lblPagare11.HyperLink = Nothing
        Me.lblPagare11.Left = 3.873!
        Me.lblPagare11.Name = "lblPagare11"
        Me.lblPagare11.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare11.Text = "$"
        Me.lblPagare11.Top = 3.575!
        Me.lblPagare11.Width = 0.1480002!
        '
        'Line9
        '
        Me.Line9.Height = 0.003000021!
        Me.Line9.Left = 4.021!
        Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 3.73!
        Me.Line9.Width = 0.8790002!
        Me.Line9.X1 = 4.021!
        Me.Line9.X2 = 4.9!
        Me.Line9.Y1 = 3.73!
        Me.Line9.Y2 = 3.733!
        '
        'lblPagare12
        '
        Me.lblPagare12.Height = 0.1879999!
        Me.lblPagare12.HyperLink = Nothing
        Me.lblPagare12.Left = 5.71!
        Me.lblPagare12.Name = "lblPagare12"
        Me.lblPagare12.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare12.Text = "( en"
        Me.lblPagare12.Top = 3.575!
        Me.lblPagare12.Width = 0.2259999!
        '
        'lblPagare13
        '
        Me.lblPagare13.Height = 0.1879999!
        Me.lblPagare13.HyperLink = Nothing
        Me.lblPagare13.Left = 0.153!
        Me.lblPagare13.Name = "lblPagare13"
        Me.lblPagare13.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare13.Text = "letra:"
        Me.lblPagare13.Top = 3.805!
        Me.lblPagare13.Width = 0.312!
        '
        'Line10
        '
        Me.Line10.Height = 0.002999067!
        Me.Line10.Left = 0.445!
        Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 3.970001!
        Me.Line10.Width = 4.025!
        Me.Line10.X1 = 0.445!
        Me.Line10.X2 = 4.47!
        Me.Line10.Y1 = 3.973!
        Me.Line10.Y2 = 3.970001!
        '
        'lblPagare14
        '
        Me.lblPagare14.Height = 0.1879999!
        Me.lblPagare14.HyperLink = Nothing
        Me.lblPagare14.Left = 4.572!
        Me.lblPagare14.Name = "lblPagare14"
        Me.lblPagare14.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare14.Text = ") valor recibido a mi entera"
        Me.lblPagare14.Top = 3.805!
        Me.lblPagare14.Width = 1.451!
        '
        'lbPagare15
        '
        Me.lbPagare15.Height = 0.1879999!
        Me.lbPagare15.HyperLink = Nothing
        Me.lbPagare15.Left = 0.166!
        Me.lbPagare15.Name = "lbPagare15"
        Me.lbPagare15.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lbPagare15.Text = "satisfacción. Si el presente pagaré no fuera cubierto el día señalado para su pag" & _
            "o, cubrire además del importe de"
        Me.lbPagare15.Top = 4.032!
        Me.lbPagare15.Width = 5.807!
        '
        'lblPagare16
        '
        Me.lblPagare16.Height = 0.1879999!
        Me.lblPagare16.HyperLink = Nothing
        Me.lblPagare16.Left = 0.153!
        Me.lblPagare16.Name = "lblPagare16"
        Me.lblPagare16.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare16.Text = "este documento, el"
        Me.lblPagare16.Top = 4.271!
        Me.lblPagare16.Width = 1.044!
        '
        'Line11
        '
        Me.Line11.Height = 0.003000259!
        Me.Line11.Left = 1.177!
        Me.Line11.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 4.436!
        Me.Line11.Width = 0.323!
        Me.Line11.X1 = 1.177!
        Me.Line11.X2 = 1.5!
        Me.Line11.Y1 = 4.436!
        Me.Line11.Y2 = 4.439!
        '
        'lblPagare17
        '
        Me.lblPagare17.Height = 0.1879999!
        Me.lblPagare17.HyperLink = Nothing
        Me.lblPagare17.Left = 1.521!
        Me.lblPagare17.Name = "lblPagare17"
        Me.lblPagare17.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare17.Text = "% mensual de intereses moratorios, desde el día que debio ser pagado hasta el dia" & _
            " en"
        Me.lblPagare17.Top = 4.271!
        Me.lblPagare17.Width = 4.452!
        '
        'lblPagare18
        '
        Me.lblPagare18.Height = 0.4800001!
        Me.lblPagare18.HyperLink = Nothing
        Me.lblPagare18.Left = 0.166!
        Me.lblPagare18.Name = "lblPagare18"
        Me.lblPagare18.Style = "font-weight: normal; color: #1F487D; font-size: 8.25pt"
        Me.lblPagare18.Text = resources.GetString("lblPagare18.Text")
        Me.lblPagare18.Top = 4.502!
        Me.lblPagare18.Width = 5.807!
        '
        'ReportFooter
        '
        Me.ReportFooter.Height = 0.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'rptValeElectronico
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 6.343999!
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
        CType(Me.txtNombreFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDportenis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgdpstreet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDPDinero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDPVale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAcreditado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAcreditado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaEmision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEmision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSurtir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSurtir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbPagare15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPagare18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
