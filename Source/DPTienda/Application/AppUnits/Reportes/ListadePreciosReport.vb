Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ListadePreciosReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Data As DataTable, ByVal TipoReporte As Int16, ByVal Sucursal As String)

        MyBase.New()

        InitializeComponent()

        Me.DataSource = Data
        Me.DataMember = Data.TableName

        lblSucursal.Text = "SUCURSAL : " & Sucursal

        lblFecha.Text = Format(Date.Now, "dd/MM/yyyy")

        If TipoReporte < 3 Then
            txtDescuento.Visible = False
            lblDes.Visible = False
        End If

        Select Case TipoReporte
            Case 1
                lblTitulo.Text = "REPORTE DE ARTICULOS CON 20% DE DESCUENTO"
            Case 2
                lblTitulo.Text = "REPORTE DE ARTICULOS CON 40% DE DESCUENTO"
            Case 3
                lblTitulo.Text = "REPORTE DE ARTICULOS CON DESCUENTO DIFERENTE AL 20 Y 40%"
        End Select

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private lblDes As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label6 As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblPag As Label = Nothing
	Private txtNumPag As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private lblSucursal As Label = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtPrecioNormal As TextBox = Nothing
	Private txtPrecioOferta As TextBox = Nothing
	Private txtDescuento As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtFechaOferta As TextBox = Nothing
	Private Line2 As Line = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadePreciosReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.lblDes = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblPag = New DataDynamics.ActiveReports.Label()
            Me.txtNumPag = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioNormal = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioOferta = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaOferta = New DataDynamics.ActiveReports.TextBox()
            Me.Line2 = New DataDynamics.ActiveReports.Line()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNumPag,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioNormal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtPrecioNormal, Me.txtPrecioOferta, Me.txtDescuento, Me.txtDescripcion, Me.txtFechaOferta})
            Me.Detail.Height = 0.15625!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label2, Me.Label3, Me.lblDes, Me.Label5, Me.Label6, Me.lblTitulo, Me.lblFecha, Me.lblPag, Me.txtNumPag, Me.Line1, Me.lblSucursal})
            Me.PageHeader.Height = 0.6979167!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
            Me.GroupFooter1.Height = 0.01041667!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6875!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.85!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.0625!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: left; font-size: 8pt"
            Me.Label1.Text = "CODIGO"
            Me.Label1.Top = 0.5!
            Me.Label1.Width = 1.4375!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 1.5625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 8pt"
            Me.Label2.Text = "PRECIO NORMAL"
            Me.Label2.Top = 0.5!
            Me.Label2.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 2.4375!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: right; font-size: 8pt"
            Me.Label3.Text = "PRECIO OFERTA"
            Me.Label3.Top = 0.5!
            Me.Label3.Width = 0.9375!
            '
            'lblDes
            '
            Me.lblDes.Height = 0.2!
            Me.lblDes.HyperLink = Nothing
            Me.lblDes.Left = 3.4375!
            Me.lblDes.Name = "lblDes"
            Me.lblDes.Style = "text-align: center; font-size: 8pt"
            Me.lblDes.Text = "%"
            Me.lblDes.Top = 0.5!
            Me.lblDes.Width = 0.25!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 3.8125!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: left; font-size: 8pt"
            Me.Label5.Text = "DESCRIPCION"
            Me.Label5.Top = 0.5!
            Me.Label5.Width = 1.8125!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 5.875!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: right; font-size: 8pt"
            Me.Label6.Text = "FECHA OFERTA"
            Me.Label6.Top = 0.5!
            Me.Label6.Width = 0.9375!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 0.953125!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center; font-size: 9pt"
            Me.lblTitulo.Text = "REPORTE DE ARTICULOS "
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 4.9375!
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
            'lblPag
            '
            Me.lblPag.Height = 0.2!
            Me.lblPag.HyperLink = Nothing
            Me.lblPag.Left = 6!
            Me.lblPag.Name = "lblPag"
            Me.lblPag.Style = "font-size: 9pt"
            Me.lblPag.Text = "Pag."
            Me.lblPag.Top = 0.0625!
            Me.lblPag.Width = 0.375!
            '
            'txtNumPag
            '
            Me.txtNumPag.Height = 0.2!
            Me.txtNumPag.Left = 6.375!
            Me.txtNumPag.Name = "txtNumPag"
            Me.txtNumPag.Style = "font-size: 9pt"
            Me.txtNumPag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtNumPag.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.txtNumPag.Text = "0000"
            Me.txtNumPag.Top = 0.0625!
            Me.txtNumPag.Width = 0.5!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.4375!
            Me.Line1.Width = 6.875!
            Me.Line1.X1 = 6.875!
            Me.Line1.X2 = 0!
            Me.Line1.Y1 = 0.4375!
            Me.Line1.Y2 = 0.4375!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.953125!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center; font-size: 9pt"
            Me.lblSucursal.Text = "SUCURSAL : 00 "
            Me.lblSucursal.Top = 0.25!
            Me.lblSucursal.Width = 4.9375!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "CodArticulo"
            Me.txtCodigo.Height = 0.17!
            Me.txtCodigo.Left = 0!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "font-size: 9pt"
            Me.txtCodigo.Text = "01234567890123456789"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.5!
            '
            'txtPrecioNormal
            '
            Me.txtPrecioNormal.DataField = "PrecioNormal"
            Me.txtPrecioNormal.Height = 0.17!
            Me.txtPrecioNormal.Left = 1.5625!
            Me.txtPrecioNormal.Name = "txtPrecioNormal"
            Me.txtPrecioNormal.OutputFormat = resources.GetString("txtPrecioNormal.OutputFormat")
            Me.txtPrecioNormal.Style = "text-align: right; font-size: 9pt"
            Me.txtPrecioNormal.Text = "$ 000,000.00"
            Me.txtPrecioNormal.Top = 0!
            Me.txtPrecioNormal.Width = 0.8125!
            '
            'txtPrecioOferta
            '
            Me.txtPrecioOferta.DataField = "PrecioOferta"
            Me.txtPrecioOferta.Height = 0.17!
            Me.txtPrecioOferta.Left = 2.4375!
            Me.txtPrecioOferta.Name = "txtPrecioOferta"
            Me.txtPrecioOferta.OutputFormat = resources.GetString("txtPrecioOferta.OutputFormat")
            Me.txtPrecioOferta.Style = "text-align: right; font-size: 9pt"
            Me.txtPrecioOferta.Text = "$ 000,000.00"
            Me.txtPrecioOferta.Top = 0!
            Me.txtPrecioOferta.Width = 0.813!
            '
            'txtDescuento
            '
            Me.txtDescuento.DataField = "Descuento"
            Me.txtDescuento.Height = 0.17!
            Me.txtDescuento.Left = 3.3125!
            Me.txtDescuento.Name = "txtDescuento"
            Me.txtDescuento.Style = "text-align: right; font-size: 9pt"
            Me.txtDescuento.Text = "000.00"
            Me.txtDescuento.Top = 0!
            Me.txtDescuento.Width = 0.4375!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.CanGrow = false
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.17!
            Me.txtDescripcion.Left = 3.8125!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-size: 9pt"
            Me.txtDescripcion.Text = "0123456789012345678901234"
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 2.1875!
            '
            'txtFechaOferta
            '
            Me.txtFechaOferta.DataField = "FUO"
            Me.txtFechaOferta.Height = 0.17!
            Me.txtFechaOferta.Left = 6.0625!
            Me.txtFechaOferta.Name = "txtFechaOferta"
            Me.txtFechaOferta.Style = "text-align: center; font-size: 9pt"
            Me.txtFechaOferta.Text = "00/00/0000"
            Me.txtFechaOferta.Top = 0!
            Me.txtFechaOferta.Width = 0.6875!
            '
            'Line2
            '
            Me.Line2.Height = 0!
            Me.Line2.Left = 0!
            Me.Line2.LineWeight = 1!
            Me.Line2.Name = "Line2"
            Me.Line2.Top = 0!
            Me.Line2.Width = 6.875!
            Me.Line2.X1 = 6.875!
            Me.Line2.X2 = 0!
            Me.Line2.Y1 = 0!
            Me.Line2.Y2 = 0!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.875!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
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
            CType(Me.lblDes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNumPag,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioNormal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
