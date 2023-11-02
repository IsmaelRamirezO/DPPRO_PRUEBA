Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class HistoricoApartadosReport
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape2 As Shape = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private LblFecha As Label = Nothing
	Private LblCodigo As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lblFieldFormaPago As Label = Nothing
	Private lblFieldPago As Label = Nothing
	Private lblFieldVendedor As Label = Nothing
	Private Label6 As Label = Nothing
	Private LblCorrida As Label = Nothing
	Private Label7 As Label = Nothing
	Private LblDescripcion As Label = Nothing
	Private Label8 As Label = Nothing
	Private tbTotalExistencias As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private tbTotalApartados As TextBox = Nothing
	Private lblFieldImporte As Label = Nothing
	Private tbFolioApartado As TextBox = Nothing
	Private tbFechaApartado As TextBox = Nothing
	Private tbTalla As TextBox = Nothing
	Private tbCantidad As TextBox = Nothing
	Private tbStatus As TextBox = Nothing
	Private tbFolioFactura As TextBox = Nothing
	Private tbEntregado As TextBox = Nothing
	Private Label10 As Label = Nothing
	Private tbTotal As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoricoApartadosReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.LblCodigo = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
            Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.LblCorrida = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.LblDescripcion = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.tbTotalExistencias = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.tbTotalApartados = New DataDynamics.ActiveReports.TextBox()
            Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
            Me.tbFolioApartado = New DataDynamics.ActiveReports.TextBox()
            Me.tbFechaApartado = New DataDynamics.ActiveReports.TextBox()
            Me.tbTalla = New DataDynamics.ActiveReports.TextBox()
            Me.tbCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.tbStatus = New DataDynamics.ActiveReports.TextBox()
            Me.tbFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.tbEntregado = New DataDynamics.ActiveReports.TextBox()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.tbTotal = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCorrida,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalExistencias,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalApartados,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolioApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFechaApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbStatus,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbEntregado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbFolioApartado, Me.tbFechaApartado, Me.tbTalla, Me.tbCantidad, Me.tbStatus, Me.tbFolioFactura, Me.tbEntregado})
            Me.Detail.Height = 0.2291667!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Height = 0!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Shape1, Me.Label1, Me.LblFecha, Me.LblCodigo, Me.Label4, Me.Label5, Me.LblSucursal, Me.lblReportTitle, Me.lblFieldFolio, Me.lblFieldArticulo, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldPago, Me.lblFieldVendedor, Me.Label6, Me.LblCorrida, Me.Label7, Me.LblDescripcion, Me.Label8, Me.tbTotalExistencias, Me.Label9, Me.tbTotalApartados, Me.lblFieldImporte})
            Me.GroupHeader1.Height = 1.415972!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label10, Me.tbTotal})
            Me.GroupFooter1.Height = 0.40625!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3331693!
            Me.Shape2.Left = 0!
            Me.Shape2.LineWeight = 2!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 1.022146!
            Me.Shape2.Width = 6.988188!
            '
            'Shape1
            '
            Me.Shape1.Height = 1.035433!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.988188!
            '
            'Label1
            '
            Me.Label1.Height = 0.1811025!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.04133856!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label1.Text = "Fecha:"
            Me.Label1.Top = 0.07381889!
            Me.Label1.Width = 0.5625!
            '
            'LblFecha
            '
            Me.LblFecha.Height = 0.1811025!
            Me.LblFecha.HyperLink = Nothing
            Me.LblFecha.Left = 0.5413389!
            Me.LblFecha.Name = "LblFecha"
            Me.LblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblFecha.Text = "LblFecha"
            Me.LblFecha.Top = 0.07381889!
            Me.LblFecha.Width = 1.0625!
            '
            'LblCodigo
            '
            Me.LblCodigo.Height = 0.1811025!
            Me.LblCodigo.HyperLink = Nothing
            Me.LblCodigo.Left = 0.6038389!
            Me.LblCodigo.Name = "LblCodigo"
            Me.LblCodigo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblCodigo.Text = "LblCodigo"
            Me.LblCodigo.Top = 0.323819!
            Me.LblCodigo.Width = 1.885826!
            '
            'Label4
            '
            Me.Label4.Height = 0.1811025!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.04133856!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label4.Text = "Código:"
            Me.Label4.Top = 0.323819!
            Me.Label4.Width = 0.5625!
            '
            'Label5
            '
            Me.Label5.Height = 0.1811025!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 2.541338!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label5.Text = "Sucursal:"
            Me.Label5.Top = 0.386319!
            Me.Label5.Width = 0.5625!
            '
            'LblSucursal
            '
            Me.LblSucursal.Height = 0.1811025!
            Me.LblSucursal.HyperLink = Nothing
            Me.LblSucursal.Left = 3.228839!
            Me.LblSucursal.Name = "LblSucursal"
            Me.LblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblSucursal.Text = "LblSucursal"
            Me.LblSucursal.Top = 0.386319!
            Me.LblSucursal.Width = 2.260826!
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.3444882!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 2.5!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "ddo-char-set: 1; font-size: 10pt; white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Histórico de Artículos Apartados"
            Me.lblReportTitle.Top = 0!
            Me.lblReportTitle.Width = 2.322835!
            '
            'lblFieldFolio
            '
            Me.lblFieldFolio.Height = 0.181!
            Me.lblFieldFolio.HyperLink = Nothing
            Me.lblFieldFolio.Left = 0.09842521!
            Me.lblFieldFolio.Name = "lblFieldFolio"
            Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFolio.Text = "Folio Apartado"
            Me.lblFieldFolio.Top = 1.118602!
            Me.lblFieldFolio.Width = 0.9217521!
            '
            'lblFieldArticulo
            '
            Me.lblFieldArticulo.Height = 0.1811025!
            Me.lblFieldArticulo.HyperLink = Nothing
            Me.lblFieldArticulo.Left = 1.082677!
            Me.lblFieldArticulo.Name = "lblFieldArticulo"
            Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldArticulo.Text = "Fecha Apartado"
            Me.lblFieldArticulo.Top = 1.118602!
            Me.lblFieldArticulo.Width = 0.9375!
            '
            'lblFieldDescuento
            '
            Me.lblFieldDescuento.Height = 0.1811025!
            Me.lblFieldDescuento.HyperLink = Nothing
            Me.lblFieldDescuento.Left = 2.65748!
            Me.lblFieldDescuento.Name = "lblFieldDescuento"
            Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldDescuento.Text = "Cantidad"
            Me.lblFieldDescuento.Top = 1.118602!
            Me.lblFieldDescuento.Width = 0.625!
            '
            'lblFieldFormaPago
            '
            Me.lblFieldFormaPago.Height = 0.1811025!
            Me.lblFieldFormaPago.HyperLink = Nothing
            Me.lblFieldFormaPago.Left = 3.418307!
            Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
            Me.lblFieldFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFormaPago.Text = "Status"
            Me.lblFieldFormaPago.Top = 1.118602!
            Me.lblFieldFormaPago.Width = 0.4375!
            '
            'lblFieldPago
            '
            Me.lblFieldPago.Height = 0.1811025!
            Me.lblFieldPago.HyperLink = Nothing
            Me.lblFieldPago.Left = 4.097933!
            Me.lblFieldPago.Name = "lblFieldPago"
            Me.lblFieldPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldPago.Text = "Folio Factura"
            Me.lblFieldPago.Top = 1.118602!
            Me.lblFieldPago.Width = 0.8125!
            '
            'lblFieldVendedor
            '
            Me.lblFieldVendedor.Height = 0.1811025!
            Me.lblFieldVendedor.HyperLink = Nothing
            Me.lblFieldVendedor.Left = 5.163386!
            Me.lblFieldVendedor.Name = "lblFieldVendedor"
            Me.lblFieldVendedor.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldVendedor.Text = "Entregado"
            Me.lblFieldVendedor.Top = 1.118602!
            Me.lblFieldVendedor.Width = 0.625!
            '
            'Label6
            '
            Me.Label6.Height = 0.1811025!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.04133856!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label6.Text = "Corrida:"
            Me.Label6.Top = 0.511319!
            Me.Label6.Width = 0.5625!
            '
            'LblCorrida
            '
            Me.LblCorrida.Height = 0.1811025!
            Me.LblCorrida.HyperLink = Nothing
            Me.LblCorrida.Left = 0.6038389!
            Me.LblCorrida.Name = "LblCorrida"
            Me.LblCorrida.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblCorrida.Text = "LblCorrida"
            Me.LblCorrida.Top = 0.511319!
            Me.LblCorrida.Width = 1.885826!
            '
            'Label7
            '
            Me.Label7.Height = 0.1811025!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 0.04133856!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label7.Text = "Descripción:"
            Me.Label7.Top = 0.6988187!
            Me.Label7.Width = 0.75!
            '
            'LblDescripcion
            '
            Me.LblDescripcion.Height = 0.1811025!
            Me.LblDescripcion.HyperLink = Nothing
            Me.LblDescripcion.Left = 0.7913389!
            Me.LblDescripcion.Name = "LblDescripcion"
            Me.LblDescripcion.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.LblDescripcion.Text = "LblDescripcion"
            Me.LblDescripcion.Top = 0.6988187!
            Me.LblDescripcion.Width = 1.885826!
            '
            'Label8
            '
            Me.Label8.Height = 0.1811025!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 4.768209!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label8.Text = "Apartados en Existencias:"
            Me.Label8.Top = 0.573819!
            Me.Label8.Width = 1.585629!
            '
            'tbTotalExistencias
            '
            Me.tbTotalExistencias.Height = 0.1968504!
            Me.tbTotalExistencias.Left = 6.397638!
            Me.tbTotalExistencias.Name = "tbTotalExistencias"
            Me.tbTotalExistencias.Style = "font-size: 8.25pt"
            Me.tbTotalExistencias.Text = "tbTotalExistencias"
            Me.tbTotalExistencias.Top = 0.5905511!
            Me.tbTotalExistencias.Width = 0.492126!
            '
            'Label9
            '
            Me.Label9.Height = 0.1811025!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4.768209!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label9.Text = "Apartados en Movimientos:"
            Me.Label9.Top = 0.8238187!
            Me.Label9.Width = 1.585629!
            '
            'tbTotalApartados
            '
            Me.tbTotalApartados.Height = 0.1968504!
            Me.tbTotalApartados.Left = 6.397638!
            Me.tbTotalApartados.Name = "tbTotalApartados"
            Me.tbTotalApartados.Style = "font-size: 8.25pt"
            Me.tbTotalApartados.Text = "tbTotalApartados"
            Me.tbTotalApartados.Top = 0.8405514!
            Me.tbTotalApartados.Width = 0.492126!
            '
            'lblFieldImporte
            '
            Me.lblFieldImporte.Height = 0.1811025!
            Me.lblFieldImporte.HyperLink = Nothing
            Me.lblFieldImporte.Left = 2.165354!
            Me.lblFieldImporte.Name = "lblFieldImporte"
            Me.lblFieldImporte.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldImporte.Text = "Talla"
            Me.lblFieldImporte.Top = 1.118602!
            Me.lblFieldImporte.Width = 0.3125!
            '
            'tbFolioApartado
            '
            Me.tbFolioApartado.Height = 0.1968504!
            Me.tbFolioApartado.Left = 0.08513785!
            Me.tbFolioApartado.Name = "tbFolioApartado"
            Me.tbFolioApartado.Style = "font-size: 8.25pt"
            Me.tbFolioApartado.Text = "tbFolioApartado"
            Me.tbFolioApartado.Top = 0.02805114!
            Me.tbFolioApartado.Width = 0.7421257!
            '
            'tbFechaApartado
            '
            Me.tbFechaApartado.Height = 0.1968504!
            Me.tbFechaApartado.Left = 1.085138!
            Me.tbFechaApartado.Name = "tbFechaApartado"
            Me.tbFechaApartado.OutputFormat = resources.GetString("tbFechaApartado.OutputFormat")
            Me.tbFechaApartado.Style = "font-size: 8.25pt"
            Me.tbFechaApartado.Text = "tbFechaApartado"
            Me.tbFechaApartado.Top = 0.02805114!
            Me.tbFechaApartado.Width = 0.883366!
            '
            'tbTalla
            '
            Me.tbTalla.Height = 0.1968504!
            Me.tbTalla.Left = 2.147638!
            Me.tbTalla.Name = "tbTalla"
            Me.tbTalla.Style = "font-size: 8.25pt"
            Me.tbTalla.Text = "tbTalla"
            Me.tbTalla.Top = 0.02805114!
            Me.tbTalla.Width = 0.383366!
            '
            'tbCantidad
            '
            Me.tbCantidad.Height = 0.1968504!
            Me.tbCantidad.Left = 2.647638!
            Me.tbCantidad.Name = "tbCantidad"
            Me.tbCantidad.Style = "font-size: 8.25pt"
            Me.tbCantidad.Text = "tbCantidad"
            Me.tbCantidad.Top = 0.02805114!
            Me.tbCantidad.Width = 0.383366!
            '
            'tbStatus
            '
            Me.tbStatus.Height = 0.1968504!
            Me.tbStatus.Left = 3.390256!
            Me.tbStatus.Name = "tbStatus"
            Me.tbStatus.Style = "font-size: 8.25pt"
            Me.tbStatus.Text = "tbStatus"
            Me.tbStatus.Top = 0.03592519!
            Me.tbStatus.Width = 0.383366!
            '
            'tbFolioFactura
            '
            Me.tbFolioFactura.Height = 0.1968504!
            Me.tbFolioFactura.Left = 4.085138!
            Me.tbFolioFactura.Name = "tbFolioFactura"
            Me.tbFolioFactura.Style = "font-size: 8.25pt"
            Me.tbFolioFactura.Text = "tbFolioFactura"
            Me.tbFolioFactura.Top = 0.02805114!
            Me.tbFolioFactura.Width = 0.820866!
            '
            'tbEntregado
            '
            Me.tbEntregado.Height = 0.1968504!
            Me.tbEntregado.Left = 5.210138!
            Me.tbEntregado.Name = "tbEntregado"
            Me.tbEntregado.OutputFormat = resources.GetString("tbEntregado.OutputFormat")
            Me.tbEntregado.Style = "font-size: 8.25pt"
            Me.tbEntregado.Text = "tbEntregado"
            Me.tbEntregado.Top = 0.02805114!
            Me.tbEntregado.Width = 0.883366!
            '
            'Label10
            '
            Me.Label10.Height = 0.181!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.09842521!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label10.Text = "Total de Artículos Apartados Vigentes:"
            Me.Label10.Top = 0.118602!
            Me.Label10.Width = 2.26378!
            '
            'tbTotal
            '
            Me.tbTotal.Height = 0.1968504!
            Me.tbTotal.Left = 2.397638!
            Me.tbTotal.Name = "tbTotal"
            Me.tbTotal.Style = "font-size: 8.25pt"
            Me.tbTotal.Text = "tbTotal"
            Me.tbTotal.Top = 0.09055111!
            Me.tbTotal.Width = 0.633366!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.5902778!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.052083!
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
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCorrida,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalExistencias,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalApartados,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolioApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFechaApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbStatus,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbEntregado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Public Sub New(ByVal oAlmacen As Almacen, ByVal strCodigo As String, ByVal strDescripcion As String, _
                   ByVal strCorrida As String, ByVal intTotalExistencia As Integer, ByVal intTotalApartados As Integer, _
                   ByVal dtDetalle As DataTable, ByVal intTotalArticulos As Integer)

        MyBase.New()
        InitializeComponent()

        'Header :

        LblSucursal.Text = oAlmacen.ID & "    " & oAlmacen.Descripcion

        LblFecha.Text = Format(Date.Now, "dd-MMM-yyyy")

        LblCodigo.Text = strCodigo

        LblCorrida.Text = strCorrida

        LblDescripcion.Text = strDescripcion

        tbTotalExistencias.Text = intTotalExistencia

        tbTotalApartados.Text = intTotalApartados



        'Detail :

        Me.DataSource = dtDetalle

        tbFolioApartado.DataField = "FolioApartado"
        tbFechaApartado.DataField = "FechaApartado"
        tbTalla.DataField = "Talla"
        tbStatus.DataField = "Status"
        tbCantidad.DataField = "Cantidad"
        tbFolioFactura.DataField = "FolioFactura"
        tbEntregado.DataField = "Entregado"

        'tbTotal.Text = dtDetalle.Compute("SUM(Cantidad)", "FolioFactura <> '' AND Status <> False")
        tbTotal.Text = intTotalArticulos

    End Sub


    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

        'If (tbStatus.Text = True) Then
        '    tbStatus.Text = "S"
        'Else
        '    tbStatus.Text = "N"
        'End If


        If (tbFolioFactura.Text.Trim <> String.Empty) Then

            'Entregado :
            tbStatus.Text = "S"

        ElseIf (tbFolioFactura.Text.Trim = String.Empty) And (tbStatus.Text = True) Then

            'No Entregado :
            tbStatus.Text = "N"

        ElseIf (tbFolioFactura.Text.Trim = String.Empty) And (tbStatus.Text = False) Then

            'Cancelado :
            tbStatus.Text = "C"

        End If


        'tbFechaApartado.Text = Format(tbFechaApartado.Text, "dd-MMM-yyyy")

        'tbEntregado.Text = Format(tbEntregado.Text, "dd-MMM-yyyy")

    End Sub

End Class
