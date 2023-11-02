Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ListadePreciosGeneralReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataTable, ByVal Almacen As String, ByVal Title As String)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = Data
        Me.DataMember = Data.TableName

        Me.lblFecha.Text = Format(Date.Now, "dd/MM/yyyy")
        Me.lblSucursal.Text = "Sucursal : " & UCase(Almacen)
        Me.lblTitulo.Text = Title

        Me.PageSettings.Margins.Top = 0.5
        Me.PageSettings.Margins.Right = 0.3
        Me.PageSettings.Margins.Left = 0.5

        Me.Run()

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
    Private Label8 As Label = Nothing
    Private Label9 As Label = Nothing
    Private Label10 As Label = Nothing
    Private lblFecha As Label = Nothing
    Private lblTitulo As Label = Nothing
    Private Label12 As Label = Nothing
    Private txtPag As TextBox = Nothing
    Private lblSucursal As Label = Nothing
    Private Line1 As Line = Nothing
    Private txtCodigo As TextBox = Nothing
    Private txtDescripcion As TextBox = Nothing
    Private txtLinea As TextBox = Nothing
    Private txtFamilia As TextBox = Nothing
    Private txtUso As TextBox = Nothing
    Private txtCorIni As TextBox = Nothing
    Private txtCorFin As TextBox = Nothing
    Private txtPrecio As TextBox = Nothing
    Private txtEsOferta As TextBox = Nothing
    Private txtDescuento As TextBox = Nothing
    Private Line2 As Line = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadePreciosGeneralReport))
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
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtPag = New DataDynamics.ActiveReports.TextBox()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtLinea = New DataDynamics.ActiveReports.TextBox()
            Me.txtFamilia = New DataDynamics.ActiveReports.TextBox()
            Me.txtUso = New DataDynamics.ActiveReports.TextBox()
            Me.txtCorIni = New DataDynamics.ActiveReports.TextBox()
            Me.txtCorFin = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecio = New DataDynamics.ActiveReports.TextBox()
            Me.txtEsOferta = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtLinea,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCorIni,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCorFin,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEsOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtLinea, Me.txtFamilia, Me.txtUso, Me.txtCorIni, Me.txtCorFin, Me.txtPrecio, Me.txtEsOferta, Me.txtDescuento})
            Me.Detail.Height = 0.1666667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.lblFecha, Me.lblTitulo, Me.Label12, Me.txtPag, Me.lblSucursal, Me.Line1})
            Me.PageHeader.Height = 0.6444445!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
            Me.PageFooter.Height = 0.02083333!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.625!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.375!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "font-size: 8pt; vertical-align: middle"
            Me.Label1.Text = "CODIGO"
            Me.Label1.Top = 0.4375!
            Me.Label1.Width = 0.6875!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.75!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-size: 8pt; vertical-align: middle"
            Me.Label2.Text = "DESCRIPCION"
            Me.Label2.Top = 0.4375!
            Me.Label2.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 3.6875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label3.Text = "LIN."
            Me.Label3.Top = 0.4375!
            Me.Label3.Width = 0.3125!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 4.0625!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label4.Text = "FAM."
            Me.Label4.Top = 0.4375!
            Me.Label4.Width = 0.375!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4.5!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label5.Text = "USO"
            Me.Label5.Top = 0.4375!
            Me.Label5.Width = 0.3125!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 4.9375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: right; font-size: 8pt; vertical-align: middle"
            Me.Label6.Text = "C.INI"
            Me.Label6.Top = 0.4375!
            Me.Label6.Width = 0.3125!
            '
            'Label7
            '
            Me.Label7.Height = 0.2!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 5.3125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: right; font-size: 8pt; vertical-align: middle"
            Me.Label7.Text = "C.FIN"
            Me.Label7.Top = 0.4375!
            Me.Label7.Width = 0.375!
            '
            'Label8
            '
            Me.Label8.Height = 0.2!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.875!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label8.Text = "PRECIO"
            Me.Label8.Top = 0.4375!
            Me.Label8.Width = 0.5625!
            '
            'Label9
            '
            Me.Label9.Height = 0.2!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 6.4375!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label9.Text = "OFERTA"
            Me.Label9.Top = 0.4375!
            Me.Label9.Visible = false
            Me.Label9.Width = 0.625!
            '
            'Label10
            '
            Me.Label10.Height = 0.2!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 7.1875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "text-align: center; font-size: 8pt; vertical-align: middle"
            Me.Label10.Text = "%"
            Me.Label10.Top = 0.4375!
            Me.Label10.Visible = false
            Me.Label10.Width = 0.1875!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.0625!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "font-size: 9pt"
            Me.lblFecha.Text = "00/00/0000"
            Me.lblFecha.Top = 0.0625!
            Me.lblFecha.Width = 0.75!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 0.8489583!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-size: 9pt; vertical-align: middle"
            Me.lblTitulo.Text = "REPORTE DE ARTICULOS EN GENERAL"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 5.5625!
            '
            'Label12
            '
            Me.Label12.Height = 0.2!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 6.4375!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "font-size: 9pt"
            Me.Label12.Text = "Pag.:"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 0.375!
            '
            'txtPag
            '
            Me.txtPag.Height = 0.2!
            Me.txtPag.Left = 6.9375!
            Me.txtPag.Name = "txtPag"
            Me.txtPag.Style = "text-align: right; font-size: 9pt"
            Me.txtPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtPag.Text = "1111"
            Me.txtPag.Top = 0.0625!
            Me.txtPag.Width = 0.375!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.1375!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1.598958!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center; font-size: 9pt; vertical-align: middle"
            Me.lblSucursal.Text = "SUCURSAL : xxx xxxxxxxxxxxxxxxxxxxxxxxxxx"
            Me.lblSucursal.Top = 0.25!
            Me.lblSucursal.Width = 4.25!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.4425!
            Me.Line1.Width = 7.375!
            Me.Line1.X1 = 7.375!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.4425!
            Me.Line1.Y2 = 0.4425!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "CodArticulo"
            Me.txtCodigo.Height = 0.16!
            Me.txtCodigo.Left = 0!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "font-size: 9pt"
            Me.txtCodigo.Text = "01234567890123456789012"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.6875!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.CanGrow = false
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.16!
            Me.txtDescripcion.Left = 1.75!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-size: 9pt"
            Me.txtDescripcion.Text = "01234567890123456789012345"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 1.875!
            '
            'txtLinea
            '
            Me.txtLinea.DataField = "CodLinea"
            Me.txtLinea.Height = 0.16!
            Me.txtLinea.Left = 3.6875!
            Me.txtLinea.Name = "txtLinea"
            Me.txtLinea.Style = "text-align: center; font-size: 9pt"
            Me.txtLinea.Text = "LLLL"
            Me.txtLinea.Top = 0!
            Me.txtLinea.Width = 0.3125!
            '
            'txtFamilia
            '
            Me.txtFamilia.DataField = "CodFamilia"
            Me.txtFamilia.Height = 0.16!
            Me.txtFamilia.Left = 4.0625!
            Me.txtFamilia.Name = "txtFamilia"
            Me.txtFamilia.Style = "text-align: center; font-size: 9pt"
            Me.txtFamilia.Text = "FFFF"
            Me.txtFamilia.Top = 0!
            Me.txtFamilia.Width = 0.375!
            '
            'txtUso
            '
            Me.txtUso.DataField = "CodUso"
            Me.txtUso.Height = 0.16!
            Me.txtUso.Left = 4.5!
            Me.txtUso.Name = "txtUso"
            Me.txtUso.Style = "text-align: center; font-size: 9pt"
            Me.txtUso.Text = "UUU"
            Me.txtUso.Top = 0!
            Me.txtUso.Width = 0.3125!
            '
            'txtCorIni
            '
            Me.txtCorIni.DataField = "NumInicio"
            Me.txtCorIni.Height = 0.16!
            Me.txtCorIni.Left = 4.875!
            Me.txtCorIni.Name = "txtCorIni"
            Me.txtCorIni.Style = "text-align: right; font-size: 9pt"
            Me.txtCorIni.Text = "00.0"
            Me.txtCorIni.Top = 0!
            Me.txtCorIni.Width = 0.375!
            '
            'txtCorFin
            '
            Me.txtCorFin.DataField = "NumFin"
            Me.txtCorFin.Height = 0.16!
            Me.txtCorFin.Left = 5.3125!
            Me.txtCorFin.Name = "txtCorFin"
            Me.txtCorFin.Style = "text-align: right; font-size: 9pt"
            Me.txtCorFin.Text = "00.0"
            Me.txtCorFin.Top = 0!
            Me.txtCorFin.Width = 0.375!
            '
            'txtPrecio
            '
            Me.txtPrecio.DataField = "Precio"
            Me.txtPrecio.Height = 0.16!
            Me.txtPrecio.Left = 5.75!
            Me.txtPrecio.Name = "txtPrecio"
            Me.txtPrecio.OutputFormat = resources.GetString("txtPrecio.OutputFormat")
            Me.txtPrecio.Style = "text-align: right; font-size: 9pt"
            Me.txtPrecio.Text = " 000,000.00"
            Me.txtPrecio.Top = 0!
            Me.txtPrecio.Width = 0.75!
            '
            'txtEsOferta
            '
            Me.txtEsOferta.DataField = "EsOferta"
            Me.txtEsOferta.Height = 0.16!
            Me.txtEsOferta.Left = 6.625!
            Me.txtEsOferta.Name = "txtEsOferta"
            Me.txtEsOferta.Style = "text-align: center; font-size: 9pt"
            Me.txtEsOferta.Text = "S"
            Me.txtEsOferta.Top = 0!
            Me.txtEsOferta.Visible = false
            Me.txtEsOferta.Width = 0.1875!
            '
            'txtDescuento
            '
            Me.txtDescuento.DataField = "Porcentaje"
            Me.txtDescuento.Height = 0.16!
            Me.txtDescuento.Left = 6.875!
            Me.txtDescuento.Name = "txtDescuento"
            Me.txtDescuento.Style = "text-align: right; font-size: 9pt"
            Me.txtDescuento.Text = "100.00"
            Me.txtDescuento.Top = 0!
            Me.txtDescuento.Visible = false
            Me.txtDescuento.Width = 0.5!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 7.375!
            Me.Line2.X1 = 7.375!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.395833!
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
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtLinea,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFamilia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCorIni,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCorFin,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEsOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region

End Class
