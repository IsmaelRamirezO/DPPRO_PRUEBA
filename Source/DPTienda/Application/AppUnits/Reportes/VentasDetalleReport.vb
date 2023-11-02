Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class VentasDetalleReport
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        lblReportDate.Text = Date.Now.ToString()
    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private lblFieldTipoVenta As Label = Nothing
	Private Label8 As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private Label7 As Label = Nothing
	Private lblReportDate As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldImporte As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lblFieldFormaPago As Label = Nothing
	Private lblFieldPago As Label = Nothing
	Private lblFieldVendedor As Label = Nothing
	Private lblFieldCliente As Label = Nothing
	Private Line2 As Line = Nothing
	Private Line3 As Line = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private Line12 As Line = Nothing
	Private tbFolio As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbTalla As TextBox = Nothing
	Private tbImporte As TextBox = Nothing
	Private tbTotal As TextBox = Nothing
	Private tbDescuento As TextBox = Nothing
	Private tbCantDescuento As TextBox = Nothing
	Private tbDescripcion As TextBox = Nothing
	Private tbArticuloID As TextBox = Nothing
	Private Line13 As Line = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Line14 As Line = Nothing
	Private Line15 As Line = Nothing
	Private Label4 As Label = Nothing
	Private Label2 As Label = Nothing
	Private tbPageNumber As TextBox = Nothing
	Private Label3 As Label = Nothing
	Private tbPageCount As TextBox = Nothing
	Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasDetalleReport))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.Line4 = New DataDynamics.ActiveReports.Line()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line7 = New DataDynamics.ActiveReports.Line()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.Line10 = New DataDynamics.ActiveReports.Line()
        Me.Line11 = New DataDynamics.ActiveReports.Line()
        Me.Line12 = New DataDynamics.ActiveReports.Line()
        Me.tbFolio = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.tbTalla = New DataDynamics.ActiveReports.TextBox()
        Me.tbImporte = New DataDynamics.ActiveReports.TextBox()
        Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
        Me.tbDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.tbCantDescuento = New DataDynamics.ActiveReports.TextBox()
        Me.tbDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.tbArticuloID = New DataDynamics.ActiveReports.TextBox()
        Me.Line13 = New DataDynamics.ActiveReports.Line()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.Line14 = New DataDynamics.ActiveReports.Line()
        Me.Line15 = New DataDynamics.ActiveReports.Line()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblFieldTipoVenta = New DataDynamics.ActiveReports.Label()
        Me.Label8 = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
        Me.Label7 = New DataDynamics.ActiveReports.Label()
        Me.lblReportDate = New DataDynamics.ActiveReports.Label()
        Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
        Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
        Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
        Me.lblFieldPago = New DataDynamics.ActiveReports.Label()
        Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
        Me.lblFieldCliente = New DataDynamics.ActiveReports.Label()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.Label4 = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.tbPageNumber = New DataDynamics.ActiveReports.TextBox()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.tbPageCount = New DataDynamics.ActiveReports.TextBox()
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCantDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbArticuloID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReportDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.Line3, Me.Line4, Me.Line5, Me.Line6, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11, Me.Line12, Me.tbFolio, Me.tbCantidad, Me.tbTalla, Me.tbImporte, Me.tbTotal, Me.tbDescuento, Me.tbCantDescuento, Me.tbDescripcion, Me.tbArticuloID, Me.Line13, Me.TextBox1, Me.Line14, Me.Line15})
        Me.Detail.Height = 0.2076389!
        Me.Detail.Name = "Detail"
        '
        'Line2
        '
        Me.Line2.Height = 0.1875!
        Me.Line2.Left = 0.0!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 0.0!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.1875!
        '
        'Line3
        '
        Me.Line3.Height = 0.1875!
        Me.Line3.Left = 1.023622!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.2559055!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 1.023622!
        Me.Line3.X2 = 1.023622!
        Me.Line3.Y1 = 0.2559055!
        Me.Line3.Y2 = 0.4434055!
        '
        'Line4
        '
        Me.Line4.Height = 0.1875!
        Me.Line4.Left = 3.392771!
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.006944444!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 3.392771!
        Me.Line4.X2 = 3.392771!
        Me.Line4.Y1 = 0.1944444!
        Me.Line4.Y2 = 0.006944444!
        '
        'Line5
        '
        Me.Line5.Height = 0.1875!
        Me.Line5.Left = 5.905513!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.007874014!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 5.905513!
        Me.Line5.X2 = 5.905513!
        Me.Line5.Y1 = 0.195374!
        Me.Line5.Y2 = 0.007874014!
        '
        'Line6
        '
        Me.Line6.Height = 0.1875!
        Me.Line6.Left = 6.506945!
        Me.Line6.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.006944444!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 6.506945!
        Me.Line6.X2 = 6.506945!
        Me.Line6.Y1 = 0.1944444!
        Me.Line6.Y2 = 0.006944444!
        '
        'Line7
        '
        Me.Line7.Height = 0.1875!
        Me.Line7.Left = 6.944445!
        Me.Line7.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.006944444!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 6.944445!
        Me.Line7.X2 = 6.944445!
        Me.Line7.Y1 = 0.1944444!
        Me.Line7.Y2 = 0.006944444!
        '
        'Line8
        '
        Me.Line8.Height = 0.1875!
        Me.Line8.Left = 7.756945!
        Me.Line8.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.006944444!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 7.756945!
        Me.Line8.X2 = 7.756945!
        Me.Line8.Y1 = 0.006944444!
        Me.Line8.Y2 = 0.1944444!
        '
        'Line9
        '
        Me.Line9.Height = 0.1875!
        Me.Line9.Left = 8.569445!
        Me.Line9.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.006944444!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 8.569445!
        Me.Line9.X2 = 8.569445!
        Me.Line9.Y1 = 0.006944444!
        Me.Line9.Y2 = 0.1944444!
        '
        'Line10
        '
        Me.Line10.Height = 0.1875!
        Me.Line10.Left = 9.944445!
        Me.Line10.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.006944444!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 9.944445!
        Me.Line10.X2 = 9.944445!
        Me.Line10.Y1 = 0.006944444!
        Me.Line10.Y2 = 0.1944444!
        '
        'Line11
        '
        Me.Line11.Height = 0.1875!
        Me.Line11.Left = 9.131945!
        Me.Line11.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.006944444!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 9.131945!
        Me.Line11.X2 = 9.131945!
        Me.Line11.Y1 = 0.006944444!
        Me.Line11.Y2 = 0.1944444!
        '
        'Line12
        '
        Me.Line12.Height = 0.1875!
        Me.Line12.Left = 10.5!
        Me.Line12.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0.006944444!
        Me.Line12.Width = 0.0!
        Me.Line12.X1 = 10.5!
        Me.Line12.X2 = 10.5!
        Me.Line12.Y1 = 0.006944444!
        Me.Line12.Y2 = 0.1944444!
        '
        'tbFolio
        '
        Me.tbFolio.DataField = "Folio"
        Me.tbFolio.Height = 0.2!
        Me.tbFolio.Left = 0.0!
        Me.tbFolio.Name = "tbFolio"
        Me.tbFolio.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.tbFolio.Text = Nothing
        Me.tbFolio.Top = 0.0!
        Me.tbFolio.Width = 1.023622!
        '
        'tbCantidad
        '
        Me.tbCantidad.DataField = "Cantidad"
        Me.tbCantidad.Height = 0.2!
        Me.tbCantidad.Left = 5.875!
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.OutputFormat = resources.GetString("tbCantidad.OutputFormat")
        Me.tbCantidad.Style = "ddo-char-set: 1; text-align: right; font-size: 10pt"
        Me.tbCantidad.Text = Nothing
        Me.tbCantidad.Top = 0.0!
        Me.tbCantidad.Width = 0.625!
        '
        'tbTalla
        '
        Me.tbTalla.DataField = "Talla"
        Me.tbTalla.Height = 0.2!
        Me.tbTalla.Left = 6.5!
        Me.tbTalla.Name = "tbTalla"
        Me.tbTalla.OutputFormat = resources.GetString("tbTalla.OutputFormat")
        Me.tbTalla.Style = "text-align: right"
        Me.tbTalla.Text = Nothing
        Me.tbTalla.Top = 0.0!
        Me.tbTalla.Width = 0.4375!
        '
        'tbImporte
        '
        Me.tbImporte.DataField = "Importe"
        Me.tbImporte.Height = 0.2!
        Me.tbImporte.Left = 6.9375!
        Me.tbImporte.Name = "tbImporte"
        Me.tbImporte.OutputFormat = resources.GetString("tbImporte.OutputFormat")
        Me.tbImporte.Style = "text-align: right"
        Me.tbImporte.Text = Nothing
        Me.tbImporte.Top = 0.0!
        Me.tbImporte.Width = 0.8125!
        '
        'tbTotal
        '
        Me.tbTotal.DataField = "Total"
        Me.tbTotal.Height = 0.2!
        Me.tbTotal.Left = 7.75!
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.OutputFormat = resources.GetString("tbTotal.OutputFormat")
        Me.tbTotal.Style = "text-align: right"
        Me.tbTotal.Text = Nothing
        Me.tbTotal.Top = 0.0!
        Me.tbTotal.Width = 0.8125!
        '
        'tbDescuento
        '
        Me.tbDescuento.DataField = "Descuento"
        Me.tbDescuento.Height = 0.2!
        Me.tbDescuento.Left = 8.5625!
        Me.tbDescuento.Name = "tbDescuento"
        Me.tbDescuento.Style = "text-align: right"
        Me.tbDescuento.Text = Nothing
        Me.tbDescuento.Top = 0.0!
        Me.tbDescuento.Width = 0.5625!
        '
        'tbCantDescuento
        '
        Me.tbCantDescuento.DataField = "CantDescuento"
        Me.tbCantDescuento.Height = 0.2!
        Me.tbCantDescuento.Left = 9.125!
        Me.tbCantDescuento.Name = "tbCantDescuento"
        Me.tbCantDescuento.OutputFormat = resources.GetString("tbCantDescuento.OutputFormat")
        Me.tbCantDescuento.Style = "text-align: right"
        Me.tbCantDescuento.Text = Nothing
        Me.tbCantDescuento.Top = 0.0!
        Me.tbCantDescuento.Width = 0.8125!
        '
        'tbDescripcion
        '
        Me.tbDescripcion.DataField = "Descripcion"
        Me.tbDescripcion.Height = 0.2!
        Me.tbDescripcion.Left = 3.415846!
        Me.tbDescripcion.Name = "tbDescripcion"
        Me.tbDescripcion.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt"
        Me.tbDescripcion.Text = Nothing
        Me.tbDescripcion.Top = 0.0!
        Me.tbDescripcion.Width = 2.459153!
        '
        'tbArticuloID
        '
        Me.tbArticuloID.DataField = "ArticuloID"
        Me.tbArticuloID.Height = 0.2!
        Me.tbArticuloID.Left = 2.18504!
        Me.tbArticuloID.Name = "tbArticuloID"
        Me.tbArticuloID.Style = "ddo-char-set: 1; text-align: left; font-size: 10pt"
        Me.tbArticuloID.Text = Nothing
        Me.tbArticuloID.Top = 0.0!
        Me.tbArticuloID.Width = 1.22441!
        '
        'Line13
        '
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 0.006944444!
        Me.Line13.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.1944444!
        Me.Line13.Width = 9.9375!
        Me.Line13.X1 = 0.006944444!
        Me.Line13.X2 = 9.944445!
        Me.Line13.Y1 = 0.1944444!
        Me.Line13.Y2 = 0.1944444!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "Referencia"
        Me.TextBox1.Height = 0.2!
        Me.TextBox1.Left = 1.023622!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 1; text-align: center; font-size: 10pt"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.181103!
        '
        'Line14
        '
        Me.Line14.Height = 0.1875!
        Me.Line14.Left = 2.165354!
        Me.Line14.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.007874014!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 2.165354!
        Me.Line14.X2 = 2.165354!
        Me.Line14.Y1 = 0.195374!
        Me.Line14.Y2 = 0.007874014!
        '
        'Line15
        '
        Me.Line15.Height = 0.1875!
        Me.Line15.Left = 1.030567!
        Me.Line15.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.006944444!
        Me.Line15.Width = 0.0!
        Me.Line15.X1 = 1.030567!
        Me.Line15.X2 = 1.030567!
        Me.Line15.Y1 = 0.1944444!
        Me.Line15.Y2 = 0.006944444!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFieldTipoVenta, Me.Label8, Me.lblFieldFolio, Me.Label7, Me.lblReportDate, Me.lblFieldArticulo, Me.lblFieldImporte, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldPago, Me.lblFieldVendedor, Me.lblFieldCliente})
        Me.PageHeader.Height = 0.6180556!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblFieldTipoVenta
        '
        Me.lblFieldTipoVenta.Height = 0.1811025!
        Me.lblFieldTipoVenta.HyperLink = Nothing
        Me.lblFieldTipoVenta.Left = 0.0!
        Me.lblFieldTipoVenta.Name = "lblFieldTipoVenta"
        Me.lblFieldTipoVenta.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldTipoVenta.Text = "Folio"
        Me.lblFieldTipoVenta.Top = 0.4375!
        Me.lblFieldTipoVenta.Width = 1.023622!
        '
        'Label8
        '
        Me.Label8.Height = 0.1811024!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 1.023622!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.Label8.Text = "Referencia"
        Me.Label8.Top = 0.4375!
        Me.Label8.Width = 1.181103!
        '
        'lblFieldFolio
        '
        Me.lblFieldFolio.Height = 0.1811024!
        Me.lblFieldFolio.HyperLink = Nothing
        Me.lblFieldFolio.Left = 2.18504!
        Me.lblFieldFolio.Name = "lblFieldFolio"
        Me.lblFieldFolio.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldFolio.Text = "Artículos"
        Me.lblFieldFolio.Top = 0.4370079!
        Me.lblFieldFolio.Width = 1.22441!
        '
        'Label7
        '
        Me.Label7.ClassName = "Heading1"
        Me.Label7.Height = 0.3937007!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0625!
        Me.Label7.MultiLine = False
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "white-space: nowrap; vertical-align: middle"
        Me.Label7.Text = "Reporte de Ventas en Detalle"
        Me.Label7.Top = 0.0!
        Me.Label7.Width = 4.330709!
        '
        'lblReportDate
        '
        Me.lblReportDate.Height = 0.1968504!
        Me.lblReportDate.HyperLink = Nothing
        Me.lblReportDate.Left = 7.551097!
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Style = "text-align: right; vertical-align: middle"
        Me.lblReportDate.Text = "Label2"
        Me.lblReportDate.Top = 0.0!
        Me.lblReportDate.Width = 2.362205!
        '
        'lblFieldArticulo
        '
        Me.lblFieldArticulo.Height = 0.1811025!
        Me.lblFieldArticulo.HyperLink = Nothing
        Me.lblFieldArticulo.Left = 3.415846!
        Me.lblFieldArticulo.Name = "lblFieldArticulo"
        Me.lblFieldArticulo.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldArticulo.Text = "Descripción"
        Me.lblFieldArticulo.Top = 0.4375!
        Me.lblFieldArticulo.Width = 2.459153!
        '
        'lblFieldImporte
        '
        Me.lblFieldImporte.Height = 0.1811025!
        Me.lblFieldImporte.HyperLink = Nothing
        Me.lblFieldImporte.Left = 5.875!
        Me.lblFieldImporte.Name = "lblFieldImporte"
        Me.lblFieldImporte.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldImporte.Text = "Cantidad"
        Me.lblFieldImporte.Top = 0.4375!
        Me.lblFieldImporte.Width = 0.625!
        '
        'lblFieldDescuento
        '
        Me.lblFieldDescuento.Height = 0.1811025!
        Me.lblFieldDescuento.HyperLink = Nothing
        Me.lblFieldDescuento.Left = 6.5!
        Me.lblFieldDescuento.Name = "lblFieldDescuento"
        Me.lblFieldDescuento.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldDescuento.Text = "Talla"
        Me.lblFieldDescuento.Top = 0.4375!
        Me.lblFieldDescuento.Width = 0.4375!
        '
        'lblFieldFormaPago
        '
        Me.lblFieldFormaPago.Height = 0.1811025!
        Me.lblFieldFormaPago.HyperLink = Nothing
        Me.lblFieldFormaPago.Left = 6.9375!
        Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
        Me.lblFieldFormaPago.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldFormaPago.Text = "Importe"
        Me.lblFieldFormaPago.Top = 0.4375!
        Me.lblFieldFormaPago.Width = 0.8125!
        '
        'lblFieldPago
        '
        Me.lblFieldPago.Height = 0.1811025!
        Me.lblFieldPago.HyperLink = Nothing
        Me.lblFieldPago.Left = 7.75!
        Me.lblFieldPago.Name = "lblFieldPago"
        Me.lblFieldPago.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldPago.Text = "Total"
        Me.lblFieldPago.Top = 0.4375!
        Me.lblFieldPago.Width = 0.8125!
        '
        'lblFieldVendedor
        '
        Me.lblFieldVendedor.Height = 0.1811025!
        Me.lblFieldVendedor.HyperLink = Nothing
        Me.lblFieldVendedor.Left = 8.5625!
        Me.lblFieldVendedor.Name = "lblFieldVendedor"
        Me.lblFieldVendedor.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldVendedor.Text = "Descto."
        Me.lblFieldVendedor.Top = 0.4375!
        Me.lblFieldVendedor.Width = 0.5625!
        '
        'lblFieldCliente
        '
        Me.lblFieldCliente.Height = 0.1811025!
        Me.lblFieldCliente.HyperLink = Nothing
        Me.lblFieldCliente.Left = 9.125!
        Me.lblFieldCliente.Name = "lblFieldCliente"
        Me.lblFieldCliente.Style = "color: White; ddo-char-set: 1; text-align: center; font-weight: bold; background-" & _
    "color: DimGray"
        Me.lblFieldCliente.Text = "Cant Desc."
        Me.lblFieldCliente.Top = 0.4375!
        Me.lblFieldCliente.Width = 0.8125!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label4, Me.Label2, Me.tbPageNumber, Me.Label3, Me.tbPageCount})
        Me.PageFooter.Height = 0.2291667!
        Me.PageFooter.Name = "PageFooter"
        '
        'Label4
        '
        Me.Label4.Height = 0.1968504!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = ""
        Me.Label4.Text = "Comercial Dportenis, S.A. de C.V."
        Me.Label4.Top = 0.009350416!
        Me.Label4.Width = 2.362205!
        '
        'Label2
        '
        Me.Label2.Height = 0.2!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 8.125!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "vertical-align: middle"
        Me.Label2.Text = "Página"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 0.5078735!
        '
        'tbPageNumber
        '
        Me.tbPageNumber.Height = 0.2!
        Me.tbPageNumber.Left = 8.679626!
        Me.tbPageNumber.Name = "tbPageNumber"
        Me.tbPageNumber.Style = "text-align: center; vertical-align: middle"
        Me.tbPageNumber.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.tbPageNumber.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageNumber.Text = "####"
        Me.tbPageNumber.Top = 0.0!
        Me.tbPageNumber.Width = 0.492126!
        '
        'Label3
        '
        Me.Label3.Height = 0.2!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 9.17175!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; vertical-align: middle"
        Me.Label3.Text = "de"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 0.2952757!
        '
        'tbPageCount
        '
        Me.tbPageCount.Height = 0.2!
        Me.tbPageCount.Left = 9.467028!
        Me.tbPageCount.Name = "tbPageCount"
        Me.tbPageCount.Style = "text-align: center; vertical-align: middle"
        Me.tbPageCount.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
        Me.tbPageCount.Text = "####"
        Me.tbPageCount.Top = 0.0!
        Me.tbPageCount.Width = 0.492126!
        '
        'VentasDetalleReport
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.1965278!
        Me.PageSettings.Margins.Right = 0.1965278!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.07292!
        Me.Sections.Add(Me.PageHeader)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.PageFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.tbFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCantDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbArticuloID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReportDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPageCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region
    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        Detail.AddBookmark("Reporte Ventas Deatalle\Pagína " & Me.PageNumber.ToString & "\")

        If DirectCast(Detail.Controls("tbTotal"), TextBox).Value < 0 Then
            DirectCast(Detail.Controls("tbTotal"), TextBox).ForeColor = System.Drawing.Color.Red
        Else
            DirectCast(Detail.Controls("tbTotal"), TextBox).ForeColor = System.Drawing.Color.Black
        End If

    End Sub
End Class
