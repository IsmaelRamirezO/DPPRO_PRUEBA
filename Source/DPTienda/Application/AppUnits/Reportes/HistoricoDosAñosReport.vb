Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class HistoricoDosAñosReport
    Inherits DataDynamics.ActiveReports.ActiveReport

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Shape2 As Shape = Nothing
	Private LblFecha As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label4 As Label = Nothing
	Private LblCodigo As Label = Nothing
	Private LblCorrida As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label7 As Label = Nothing
	Private LblDescripcion As Label = Nothing
	Private Label5 As Label = Nothing
	Private LblSucursal As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private Label8 As Label = Nothing
	Private tbSaldoInicial As TextBox = Nothing
	Private tbSaldoFinal As TextBox = Nothing
	Private Label9 As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private lblFieldArticulo As Label = Nothing
	Private lblFieldImporte As Label = Nothing
	Private lblFieldDescuento As Label = Nothing
	Private lblFieldFormaPago As Label = Nothing
	Private lblFieldPago As Label = Nothing
	Private lblFieldVendedor As Label = Nothing
	Private tbOrigen As TextBox = Nothing
	Private tbReferencia As TextBox = Nothing
	Private tbFecha As TextBox = Nothing
	Private tbDescripcion As TextBox = Nothing
	Private tbEntrada As TextBox = Nothing
	Private tbSalida As TextBox = Nothing
	Private tbSaldo As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Label10 As Label = Nothing
	Private tbTotalEntrada As TextBox = Nothing
	Private tbTotalSalidas As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoricoDosAñosReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.LblFecha = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.LblCodigo = New DataDynamics.ActiveReports.Label()
            Me.LblCorrida = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.LblDescripcion = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.LblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.tbSaldoInicial = New DataDynamics.ActiveReports.TextBox()
            Me.tbSaldoFinal = New DataDynamics.ActiveReports.TextBox()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
            Me.lblFieldArticulo = New DataDynamics.ActiveReports.Label()
            Me.lblFieldImporte = New DataDynamics.ActiveReports.Label()
            Me.lblFieldDescuento = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFormaPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldPago = New DataDynamics.ActiveReports.Label()
            Me.lblFieldVendedor = New DataDynamics.ActiveReports.Label()
            Me.tbOrigen = New DataDynamics.ActiveReports.TextBox()
            Me.tbReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.tbFecha = New DataDynamics.ActiveReports.TextBox()
            Me.tbDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.tbEntrada = New DataDynamics.ActiveReports.TextBox()
            Me.tbSalida = New DataDynamics.ActiveReports.TextBox()
            Me.tbSaldo = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.tbTotalEntrada = New DataDynamics.ActiveReports.TextBox()
            Me.tbTotalSalidas = New DataDynamics.ActiveReports.TextBox()
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblCorrida,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoInicial,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoFinal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbOrigen,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbEntrada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSalida,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalEntrada,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalSalidas,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbOrigen, Me.tbReferencia, Me.tbFecha, Me.tbDescripcion, Me.tbEntrada, Me.tbSalida, Me.tbSaldo})
            Me.Detail.Height = 0.28125!
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
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Shape2, Me.LblFecha, Me.Label1, Me.Label4, Me.LblCodigo, Me.LblCorrida, Me.Label6, Me.Label7, Me.LblDescripcion, Me.Label5, Me.LblSucursal, Me.lblReportTitle, Me.Label8, Me.tbSaldoInicial, Me.tbSaldoFinal, Me.Label9, Me.lblFieldFolio, Me.lblFieldArticulo, Me.lblFieldImporte, Me.lblFieldDescuento, Me.lblFieldFormaPago, Me.lblFieldPago, Me.lblFieldVendedor})
            Me.GroupHeader1.Height = 1.415972!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.Label10, Me.tbTotalEntrada, Me.tbTotalSalidas})
            Me.GroupFooter1.Height = 0.375!
            Me.GroupFooter1.Name = "GroupFooter1"
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
            Me.lblReportTitle.Left = 2.75!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "ddo-char-set: 1; font-size: 10pt; white-space: nowrap; vertical-align: middle"
            Me.lblReportTitle.Text = "Movimientos de Artículos"
            Me.lblReportTitle.Top = 0!
            Me.lblReportTitle.Width = 1.760335!
            '
            'Label8
            '
            Me.Label8.Height = 0.1811025!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.643209!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label8.Text = "Saldo Inicial"
            Me.Label8.Top = 0.573819!
            Me.Label8.Width = 0.7106292!
            '
            'tbSaldoInicial
            '
            Me.tbSaldoInicial.Height = 0.1968504!
            Me.tbSaldoInicial.Left = 6.397638!
            Me.tbSaldoInicial.Name = "tbSaldoInicial"
            Me.tbSaldoInicial.Style = "font-size: 8.25pt"
            Me.tbSaldoInicial.Text = "tbSaldoInicial"
            Me.tbSaldoInicial.Top = 0.5905511!
            Me.tbSaldoInicial.Width = 0.492126!
            '
            'tbSaldoFinal
            '
            Me.tbSaldoFinal.Height = 0.1968504!
            Me.tbSaldoFinal.Left = 6.397638!
            Me.tbSaldoFinal.Name = "tbSaldoFinal"
            Me.tbSaldoFinal.Style = "font-size: 8.25pt"
            Me.tbSaldoFinal.Text = "tbSaldoFinal"
            Me.tbSaldoFinal.Top = 0.8405514!
            Me.tbSaldoFinal.Width = 0.492126!
            '
            'Label9
            '
            Me.Label9.Height = 0.1811025!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 5.643209!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label9.Text = "Saldo Final"
            Me.Label9.Top = 0.8238187!
            Me.Label9.Width = 0.7106292!
            '
            'lblFieldFolio
            '
            Me.lblFieldFolio.Height = 0.181!
            Me.lblFieldFolio.HyperLink = Nothing
            Me.lblFieldFolio.Left = 0.09842521!
            Me.lblFieldFolio.Name = "lblFieldFolio"
            Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFolio.Text = "Origen"
            Me.lblFieldFolio.Top = 1.118602!
            Me.lblFieldFolio.Width = 0.4842521!
            '
            'lblFieldArticulo
            '
            Me.lblFieldArticulo.Height = 0.1811025!
            Me.lblFieldArticulo.HyperLink = Nothing
            Me.lblFieldArticulo.Left = 0.7701771!
            Me.lblFieldArticulo.Name = "lblFieldArticulo"
            Me.lblFieldArticulo.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldArticulo.Text = "Referencia"
            Me.lblFieldArticulo.Top = 1.118602!
            Me.lblFieldArticulo.Width = 0.6875!
            '
            'lblFieldImporte
            '
            Me.lblFieldImporte.Height = 0.1811025!
            Me.lblFieldImporte.HyperLink = Nothing
            Me.lblFieldImporte.Left = 1.665354!
            Me.lblFieldImporte.Name = "lblFieldImporte"
            Me.lblFieldImporte.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldImporte.Text = "Fecha"
            Me.lblFieldImporte.Top = 1.118602!
            Me.lblFieldImporte.Width = 0.375!
            '
            'lblFieldDescuento
            '
            Me.lblFieldDescuento.Height = 0.1811025!
            Me.lblFieldDescuento.HyperLink = Nothing
            Me.lblFieldDescuento.Left = 2.59498!
            Me.lblFieldDescuento.Name = "lblFieldDescuento"
            Me.lblFieldDescuento.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldDescuento.Text = "Descripción"
            Me.lblFieldDescuento.Top = 1.118602!
            Me.lblFieldDescuento.Width = 0.6875!
            '
            'lblFieldFormaPago
            '
            Me.lblFieldFormaPago.Height = 0.1811025!
            Me.lblFieldFormaPago.HyperLink = Nothing
            Me.lblFieldFormaPago.Left = 5.043307!
            Me.lblFieldFormaPago.Name = "lblFieldFormaPago"
            Me.lblFieldFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFormaPago.Text = "Entradas"
            Me.lblFieldFormaPago.Top = 1.118602!
            Me.lblFieldFormaPago.Width = 0.5625!
            '
            'lblFieldPago
            '
            Me.lblFieldPago.Height = 0.1811025!
            Me.lblFieldPago.HyperLink = Nothing
            Me.lblFieldPago.Left = 5.785434!
            Me.lblFieldPago.Name = "lblFieldPago"
            Me.lblFieldPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldPago.Text = "Salidas"
            Me.lblFieldPago.Top = 1.118602!
            Me.lblFieldPago.Width = 0.5!
            '
            'lblFieldVendedor
            '
            Me.lblFieldVendedor.Height = 0.1811025!
            Me.lblFieldVendedor.HyperLink = Nothing
            Me.lblFieldVendedor.Left = 6.475886!
            Me.lblFieldVendedor.Name = "lblFieldVendedor"
            Me.lblFieldVendedor.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldVendedor.Text = "Saldo"
            Me.lblFieldVendedor.Top = 1.118602!
            Me.lblFieldVendedor.Width = 0.375!
            '
            'tbOrigen
            '
            Me.tbOrigen.Height = 0.1968504!
            Me.tbOrigen.Left = 0.09842521!
            Me.tbOrigen.Name = "tbOrigen"
            Me.tbOrigen.Style = "font-size: 8.25pt"
            Me.tbOrigen.Text = "tbOrigen"
            Me.tbOrigen.Top = 0.0625!
            Me.tbOrigen.Width = 0.5546257!
            '
            'tbReferencia
            '
            Me.tbReferencia.Height = 0.1968504!
            Me.tbReferencia.Left = 0.7726382!
            Me.tbReferencia.Name = "tbReferencia"
            Me.tbReferencia.OutputFormat = resources.GetString("tbReferencia.OutputFormat")
            Me.tbReferencia.Style = "font-size: 8.25pt"
            Me.tbReferencia.Text = "tbReferencia"
            Me.tbReferencia.Top = 0.02805114!
            Me.tbReferencia.Width = 0.758366!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.1968504!
            Me.tbFecha.Left = 1.647638!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.OutputFormat = resources.GetString("tbFecha.OutputFormat")
            Me.tbFecha.Style = "font-size: 8.25pt"
            Me.tbFecha.Text = "tbFecha"
            Me.tbFecha.Top = 0.02805114!
            Me.tbFecha.Width = 0.820866!
            '
            'tbDescripcion
            '
            Me.tbDescripcion.Height = 0.1968504!
            Me.tbDescripcion.Left = 2.59498!
            Me.tbDescripcion.Name = "tbDescripcion"
            Me.tbDescripcion.Style = "font-size: 8.25pt"
            Me.tbDescripcion.Text = "tbDescripcion"
            Me.tbDescripcion.Top = 0.0625!
            Me.tbDescripcion.Width = 2.320866!
            '
            'tbEntrada
            '
            Me.tbEntrada.Height = 0.1968504!
            Me.tbEntrada.Left = 5.140256!
            Me.tbEntrada.Name = "tbEntrada"
            Me.tbEntrada.OutputFormat = resources.GetString("tbEntrada.OutputFormat")
            Me.tbEntrada.Style = "text-align: right; font-size: 8.25pt"
            Me.tbEntrada.Text = "tbEntrada"
            Me.tbEntrada.Top = 0.03592519!
            Me.tbEntrada.Width = 0.445866!
            '
            'tbSalida
            '
            Me.tbSalida.Height = 0.1968504!
            Me.tbSalida.Left = 5.835139!
            Me.tbSalida.Name = "tbSalida"
            Me.tbSalida.OutputFormat = resources.GetString("tbSalida.OutputFormat")
            Me.tbSalida.Style = "text-align: right; font-size: 8.25pt"
            Me.tbSalida.Text = "tbSalida"
            Me.tbSalida.Top = 0.02805114!
            Me.tbSalida.Width = 0.383366!
            '
            'tbSaldo
            '
            Me.tbSaldo.Height = 0.1968504!
            Me.tbSaldo.Left = 6.397639!
            Me.tbSaldo.Name = "tbSaldo"
            Me.tbSaldo.OutputFormat = resources.GetString("tbSaldo.OutputFormat")
            Me.tbSaldo.Style = "text-align: right; font-size: 8.25pt"
            Me.tbSaldo.Text = "tbSaldo"
            Me.tbSaldo.Top = 0.02805114!
            Me.tbSaldo.Width = 0.383366!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.3331693!
            Me.Shape3.Left = 0!
            Me.Shape3.LineWeight = 2!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0.02214587!
            Me.Shape3.Width = 6.988188!
            '
            'Label10
            '
            Me.Label10.Height = 0.181!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 0.09842521!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label10.Text = "Totales . . ."
            Me.Label10.Top = 0.118602!
            Me.Label10.Width = 0.7012799!
            '
            'tbTotalEntrada
            '
            Me.tbTotalEntrada.Height = 0.1968504!
            Me.tbTotalEntrada.Left = 5.082186!
            Me.tbTotalEntrada.Name = "tbTotalEntrada"
            Me.tbTotalEntrada.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.tbTotalEntrada.SummaryGroup = "GroupHeader1"
            Me.tbTotalEntrada.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.tbTotalEntrada.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalEntrada.Text = "tbTotalEntrada"
            Me.tbTotalEntrada.Top = 0.09842521!
            Me.tbTotalEntrada.Width = 0.4655512!
            '
            'tbTotalSalidas
            '
            Me.tbTotalSalidas.Height = 0.1968504!
            Me.tbTotalSalidas.Left = 5.769686!
            Me.tbTotalSalidas.Name = "tbTotalSalidas"
            Me.tbTotalSalidas.Style = "text-align: right; font-weight: bold; font-size: 8.25pt"
            Me.tbTotalSalidas.SummaryGroup = "GroupHeader1"
            Me.tbTotalSalidas.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.tbTotalSalidas.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.tbTotalSalidas.Text = "tbTotalSalidas"
            Me.tbTotalSalidas.Top = 0.09842521!
            Me.tbTotalSalidas.Width = 0.4655512!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.5902778!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.010417!
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
            CType(Me.LblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblCorrida,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.LblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoInicial,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoFinal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbOrigen,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbEntrada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSalida,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalEntrada,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalSalidas,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


    Public Sub New(ByVal oAlmacen As Almacen, ByVal strCodigo As String, ByVal strDescripcion As String, _
                     ByVal strCorrida As String, ByVal intSaldoInicial As Integer, ByVal intSaldoFinal As Integer, _
                     ByVal dtDetalle As DataTable)
        MyBase.New()
        InitializeComponent()
        

        'Header :

        LblSucursal.Text = oAlmacen.ID & "    " & oAlmacen.Descripcion

        LblFecha.Text = Format(Date.Now, "dd-MMM-yyyy")

        LblCodigo.Text = strCodigo

        LblCorrida.Text = strCorrida

        LblDescripcion.Text = strDescripcion

        tbSaldoInicial.Text = intSaldoInicial

        tbsaldofinal.Text = intSaldoFinal



        'Detail :

        Me.DataSource = dtDetalle.DefaultView

        tbOrigen.DataField = "Origen"
        tbReferencia.DataField = "Referencia"
        tbFecha.DataField = "Fecha"
        tbDescripcion.DataField = "Descripcion"
        tbEntrada.DataField = "Entrada"
        tbSalida.DataField = "Salida"
        tbSaldo.DataField = "Saldo"

        tbTotalEntrada.DataField = "Entrada"
        tbTotalSalidas.DataField = "Salida"

    End Sub

End Class
