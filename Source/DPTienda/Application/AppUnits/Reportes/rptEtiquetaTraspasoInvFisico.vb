Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptEtiquetaTraspasoInvFisico

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal FTraslado As String, ByVal SucOri As String, ByVal NCaja As Integer, _
                ByVal FechaTraslado As DateTime)
        MyBase.New()
        InitializeComponent()

        txtFTraslado.Text = FTraslado.PadLeft(10, "0")
        Me.txtNBulto.Text = CStr(NCaja).PadLeft(3, "0").Trim
        txtCentroO.Text = SucOri
        txtFechaT.Text = FechaTraslado.ToShortDateString
        Me.txtCodBar.Text = FTraslado.PadLeft(10, "0") & CStr(NCaja).PadLeft(3, "0")
        Me.bcBarras.Text = FTraslado.PadLeft(10, "0") & CStr(NCaja).PadLeft(3, "0").Trim
    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Line1 As Line = Nothing
    Private Shape1 As Shape = Nothing
    Private txtFTraslado As TextBox = Nothing
    Private txtNBulto As TextBox = Nothing
    Private Label1 As Label = Nothing
    Private Label2 As Label = Nothing
    Private Label3 As Label = Nothing
    Private Label4 As Label = Nothing
    Private txtCentroO As TextBox = Nothing
    Private txtFechaT As TextBox = Nothing
    Private Line2 As Line = Nothing
    Private Shape2 As Shape = Nothing
    Private Label5 As Label = Nothing
    Private Label6 As Label = Nothing
    Private Label7 As Label = Nothing
    Private Label8 As Label = Nothing
    Private Line3 As Line = Nothing
    Private Line4 As Line = Nothing
    Private txtCodigo As TextBox = Nothing
    Private txtTalla As TextBox = Nothing
    Private txtCant As TextBox = Nothing
    Private Label9 As Label = Nothing
    Private Label10 As Label = Nothing
    Private TextBox1 As TextBox = Nothing
    Private TextBox2 As TextBox = Nothing
    Private bcBarras As Barcode = Nothing
    Private txtCodBar As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEtiquetaTraspasoInvFisico))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtFTraslado = New DataDynamics.ActiveReports.TextBox()
            Me.txtNBulto = New DataDynamics.ActiveReports.TextBox()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtCentroO = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaT = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Line3 = New DataDynamics.ActiveReports.Line()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
            Me.txtCant = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            Me.bcBarras = New DataDynamics.ActiveReports.Barcode()
            Me.txtCodBar = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtFTraslado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNBulto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCentroO,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaT,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCant,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodBar,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtTalla, Me.txtCant})
            Me.Detail.Height = 0.1666667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.Shape1, Me.txtFTraslado, Me.txtNBulto, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.txtCentroO, Me.txtFechaT, Me.Line2, Me.Shape2, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Line3, Me.Line4})
            Me.PageHeader.Height = 1.197222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label9, Me.Label10, Me.TextBox1, Me.TextBox2, Me.bcBarras, Me.txtCodBar})
            Me.PageFooter.Height = 0.7604167!
            Me.PageFooter.Name = "PageFooter"
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.006944444!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.8194444!
            Me.Line1.Width = 3.375!
            Me.Line1.X1 = 0.006944444!
            Me.Line1.X2 = 3.381944!
            Me.Line1.Y1 = 0.8194444!
            Me.Line1.Y2 = 0.8194444!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.3125!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0.6875!
            Me.Shape1.Width = 3.375!
            '
            'txtFTraslado
            '
            Me.txtFTraslado.Height = 0.4245!
            Me.txtFTraslado.Left = 0!
            Me.txtFTraslado.Name = "txtFTraslado"
            Me.txtFTraslado.Style = "ddo-char-set: 1; text-align: center; font-size: 27.75pt"
            Me.txtFTraslado.Text = "430000987678"
            Me.txtFTraslado.Top = 0.0625!
            Me.txtFTraslado.Width = 2.622!
            '
            'txtNBulto
            '
            Me.txtNBulto.Height = 0.4375!
            Me.txtNBulto.Left = 2.6875!
            Me.txtNBulto.Name = "txtNBulto"
            Me.txtNBulto.Style = "ddo-char-set: 1; text-align: center; font-size: 26.25pt"
            Me.txtNBulto.Top = 0.0625!
            Me.txtNBulto.Width = 0.6875!
            '
            'Label1
            '
            Me.Label1.Height = 0.125!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label1.Text = "Folio Traslado"
            Me.Label1.Top = 0.5!
            Me.Label1.Width = 2.625!
            '
            'Label2
            '
            Me.Label2.Height = 0.125!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 2.6875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "# Caja"
            Me.Label2.Top = 0.5!
            Me.Label2.Width = 0.6875!
            '
            'Label3
            '
            Me.Label3.Height = 0.125!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label3.Text = "Suc. Origen"
            Me.Label3.Top = 0.6875!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.125!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Fecha Traslado"
            Me.Label4.Top = 0.6875!
            Me.Label4.Width = 2.125!
            '
            'txtCentroO
            '
            Me.txtCentroO.Height = 0.201!
            Me.txtCentroO.Left = 0.0625!
            Me.txtCentroO.Name = "txtCentroO"
            Me.txtCentroO.Style = "text-align: center"
            Me.txtCentroO.Text = "Z000"
            Me.txtCentroO.Top = 0.8125!
            Me.txtCentroO.Width = 1!
            '
            'txtFechaT
            '
            Me.txtFechaT.Height = 0.201!
            Me.txtFechaT.Left = 1.1875!
            Me.txtFechaT.Name = "txtFechaT"
            Me.txtFechaT.Style = "text-align: center"
            Me.txtFechaT.Text = "00/00/0000"
            Me.txtFechaT.Top = 0.8125!
            Me.txtFechaT.Width = 2.125!
            '
            'Line2
            '
            Me.Line2.Height = 0.3125001!
            Me.Line2.Left = 1.131944!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0.6944444!
            Me.Line2.Width = 0!
            Me.Line2.X1 = 1.131944!
            Me.Line2.X2 = 1.131944!
            Me.Line2.Y1 = 0.6944444!
            Me.Line2.Y2 = 1.006944!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.125!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 1.0625!
            Me.Shape2.Width = 3.375!
            '
            'Label5
            '
            Me.Label5.Height = 0.125!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 0.0625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label5.Text = "Suc. Origen"
            Me.Label5.Top = 0.6875!
            Me.Label5.Width = 1!
            '
            'Label6
            '
            Me.Label6.Height = 0.138!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.0625!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label6.Text = "Codigo"
            Me.Label6.Top = 1.0625!
            Me.Label6.Width = 1.444!
            '
            'Label7
            '
            Me.Label7.Height = 0.138!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 1.625!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label7.Text = "Talla"
            Me.Label7.Top = 1.0625!
            Me.Label7.Width = 1!
            '
            'Label8
            '
            Me.Label8.Height = 0.138!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 2.75!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.Label8.Text = "Cantidad"
            Me.Label8.Top = 1.0625!
            Me.Label8.Width = 0.5625!
            '
            'Line3
            '
            Me.Line3.Height = 0.125!
            Me.Line3.Left = 1.5625!
            Me.Line3.LineWeight = 1!
            Me.Line3.Name = "Line3"
            Me.Line3.Top = 1.0625!
            Me.Line3.Width = 0!
            Me.Line3.X1 = 1.5625!
            Me.Line3.X2 = 1.5625!
            Me.Line3.Y1 = 1.0625!
            Me.Line3.Y2 = 1.1875!
            '
            'Line4
            '
            Me.Line4.Height = 0.125!
            Me.Line4.Left = 2.694444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 1.069444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 2.694444!
            Me.Line4.X2 = 2.694444!
            Me.Line4.Y1 = 1.069444!
            Me.Line4.Y2 = 1.194444!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.138!
            Me.txtCodigo.Left = 0.0625!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "ddo-char-set: 1; text-align: left; font-size: 8.25pt"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.4375!
            '
            'txtTalla
            '
            Me.txtTalla.DataField = "Talla"
            Me.txtTalla.Height = 0.138!
            Me.txtTalla.Left = 1.625!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "ddo-char-set: 1; text-align: center; font-size: 8.25pt"
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 1!
            '
            'txtCant
            '
            Me.txtCant.DataField = "Cantidad"
            Me.txtCant.Height = 0.138!
            Me.txtCant.Left = 2.75!
            Me.txtCant.Name = "txtCant"
            Me.txtCant.Style = "ddo-char-set: 1; text-align: center; font-size: 8.25pt"
            Me.txtCant.Top = 0!
            Me.txtCant.Width = 0.5625!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 1.035667!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 6.75pt"
            Me.Label9.Text = "Pág."
            Me.Label9.Top = 0.5!
            Me.Label9.Width = 0.328!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.723167!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 6.75pt"
            Me.Label10.Text = "dé"
            Me.Label10.Top = 0.5!
            Me.Label10.Width = 0.328!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 1.410667!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-size: 6.75pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Text = "000"
            Me.TextBox1.Top = 0.5!
            Me.TextBox1.Width = 0.262!
            '
            'TextBox2
            '
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 2.098167!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center; font-size: 6.75pt"
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox2.Text = "000"
            Me.TextBox2.Top = 0.5!
            Me.TextBox2.Width = 0.262!
            '
            'bcBarras
            '
            Me.bcBarras.CheckSumEnabled = false
            Me.bcBarras.Font = New System.Drawing.Font("Courier New", 8!)
            Me.bcBarras.Height = 0.375!
            Me.bcBarras.Left = 0.1901041!
            Me.bcBarras.Name = "bcBarras"
            Me.bcBarras.Text = "1234567890123"
            Me.bcBarras.Top = 0!
            Me.bcBarras.Width = 3!
            '
            'txtCodBar
            '
            Me.txtCodBar.Height = 0.125!
            Me.txtCodBar.Left = 0.1875!
            Me.txtCodBar.Name = "txtCodBar"
            Me.txtCodBar.Style = "ddo-char-set: 1; text-align: center; font-size: 8.25pt"
            Me.txtCodBar.Text = "1234567890123"
            Me.txtCodBar.Top = 0.375!
            Me.txtCodBar.Width = 3!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0!
            Me.PageSettings.Margins.Left = 0.2!
            Me.PageSettings.Margins.Right = 0.2!
            Me.PageSettings.Margins.Top = 0!
            Me.PageSettings.MirrorMargins = true
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 3.395833!
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
            CType(Me.txtFTraslado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNBulto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCentroO,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaT,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCant,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodBar,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
