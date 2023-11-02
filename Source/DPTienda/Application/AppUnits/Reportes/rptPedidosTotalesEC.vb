Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptPedidosTotalesEC
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private dtPedidos As DataTable
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Private WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEntrega As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescripcion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNotaVenta As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaPedido As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    Public Sub New(ByVal datFechaInicio As Date, ByVal datFechaFin As Date, Optional ByVal Status As String = "TP")
        MyBase.New()
        InitializeComponent()

        '--------------------------------------------------------------------------------------------
        ' JNAVA (14.03.2016): Seteamos datos de Encabezado
        '--------------------------------------------------------------------------------------------
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros)

        Me.txtSucursal.Text = oAlmacen.ID & " - " & oAlmacen.Descripcion

        oCatalogoAlmacenMgr = Nothing
        oAlmacen = Nothing

        Me.txtFecha.Text = Date.Now.ToShortDateString
        Me.txtFechaDe.Text = datFechaInicio.ToShortDateString
        Me.txtFechaAl.Text = datFechaFin.ToShortDateString
        '-------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------
        ' JNAVA (14.03.2016): Seteamos Detalle
        '--------------------------------------------------------------------------------------------
        Dim PedidoDetalle As DataTable
        PedidoDetalle = oSAPMgr.Z_FM_COMMX001_TRASL_PEDIDO(datFechaInicio, datFechaFin, Status)
        FormatearDetalle(PedidoDetalle)
        Me.DataSource = PedidoDetalle
        '--------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------
        ' JNAVA (14.03.2016): Seteamos Pie de pagina
        '--------------------------------------------------------------------------------------------
        If PedidoDetalle.Rows.Count > 0 Then
            Me.txtTotalImporte.Text = Format(IIf(IsDBNull(PedidoDetalle.Compute("SUM(KWERT)", "ESTATUS <> 'C'")), 0, PedidoDetalle.Compute("SUM(KWERT)", "ESTATUS <> 'C'")), "Currency")
        Else
            Me.txtTotalImporte.Text = Format(0, "Currency")
        End If
        '--------------------------------------------------------------------------------------------

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private lblDe As Label = Nothing
    Private txtFecha As Label = Nothing
    Private lblSucursal As Label = Nothing
    Private lblReportTitle As Label = Nothing
    Private txtFechaDe As Label = Nothing
    Private lblFechaAl As Label = Nothing
    Private txtFechaAl As Label = Nothing
    Private txtSucursal As Label = Nothing
    Private Shape1 As Shape = Nothing
    Private lblPago As Label = Nothing
    Private lblVendedor As Label = Nothing
    Private lblCliente As Label = Nothing
    Private lblTipoVenta As Label = Nothing
    Private WithEvents lblFolio As DataDynamics.ActiveReports.Label
    Private WithEvents lblFolioSAP As DataDynamics.ActiveReports.Label
    Private WithEvents lblFieldFecha As DataDynamics.ActiveReports.Label
    Private WithEvents lblTotalArt As DataDynamics.ActiveReports.Label
    Private WithEvents lblImporte As DataDynamics.ActiveReports.Label
    Private WithEvents lblDescuento As DataDynamics.ActiveReports.Label
    Private WithEvents lblFormaPago As DataDynamics.ActiveReports.Label
    Private WithEvents txtPedido As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSolicitud As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtGuia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalImporte As DataDynamics.ActiveReports.TextBox
    Private Shape3 As Shape = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPedidosTotalesEC))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtPedido = New DataDynamics.ActiveReports.TextBox()
        Me.txtSolicitud = New DataDynamics.ActiveReports.TextBox()
        Me.txtGuia = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox4 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox()
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox()
        Me.txtEntrega = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.txtFechaPedido = New DataDynamics.ActiveReports.TextBox()
        Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
        Me.Shape1 = New DataDynamics.ActiveReports.Shape()
        Me.lblDe = New DataDynamics.ActiveReports.Label()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.Label()
        Me.lblSucursal = New DataDynamics.ActiveReports.Label()
        Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
        Me.txtFechaDe = New DataDynamics.ActiveReports.Label()
        Me.lblFechaAl = New DataDynamics.ActiveReports.Label()
        Me.txtFechaAl = New DataDynamics.ActiveReports.Label()
        Me.txtSucursal = New DataDynamics.ActiveReports.Label()
        Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
        Me.Shape3 = New DataDynamics.ActiveReports.Shape()
        Me.txtTotalImporte = New DataDynamics.ActiveReports.TextBox()
        Me.Label1 = New DataDynamics.ActiveReports.Label()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.lblFolio = New DataDynamics.ActiveReports.Label()
        Me.lblFolioSAP = New DataDynamics.ActiveReports.Label()
        Me.lblFieldFecha = New DataDynamics.ActiveReports.Label()
        Me.lblTotalArt = New DataDynamics.ActiveReports.Label()
        Me.lblImporte = New DataDynamics.ActiveReports.Label()
        Me.lblDescuento = New DataDynamics.ActiveReports.Label()
        Me.lblFormaPago = New DataDynamics.ActiveReports.Label()
        Me.lblPago = New DataDynamics.ActiveReports.Label()
        Me.lblVendedor = New DataDynamics.ActiveReports.Label()
        Me.lblCliente = New DataDynamics.ActiveReports.Label()
        Me.lblTipoVenta = New DataDynamics.ActiveReports.Label()
        Me.lblNotaVenta = New DataDynamics.ActiveReports.Label()
        Me.Label2 = New DataDynamics.ActiveReports.Label()
        Me.Label3 = New DataDynamics.ActiveReports.Label()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFolioSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFieldFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNotaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtPedido, Me.txtSolicitud, Me.txtGuia, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.txtEntrega, Me.txtDescripcion, Me.txtFechaPedido})
        Me.Detail.Height = 0.1554167!
        Me.Detail.Name = "Detail"
        '
        'txtPedido
        '
        Me.txtPedido.DataField = "FOLIO_PEDIDO"
        Me.txtPedido.Height = 0.135!
        Me.txtPedido.Left = 0.0!
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtPedido.Text = Nothing
        Me.txtPedido.Top = 0.0!
        Me.txtPedido.Width = 0.675!
        '
        'txtSolicitud
        '
        Me.txtSolicitud.DataField = "ID_SOLICITUD"
        Me.txtSolicitud.Height = 0.135!
        Me.txtSolicitud.Left = 0.675!
        Me.txtSolicitud.Name = "txtSolicitud"
        Me.txtSolicitud.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtSolicitud.Text = Nothing
        Me.txtSolicitud.Top = 0.0!
        Me.txtSolicitud.Width = 0.5319999!
        '
        'txtGuia
        '
        Me.txtGuia.DataField = "GUIA"
        Me.txtGuia.Height = 0.135!
        Me.txtGuia.Left = 1.966!
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtGuia.Text = Nothing
        Me.txtGuia.Top = 0.0!
        Me.txtGuia.Width = 0.6730001!
        '
        'TextBox1
        '
        Me.TextBox1.DataField = "RESPONSABLE"
        Me.TextBox1.Height = 0.135!
        Me.TextBox1.Left = 2.639!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.087!
        '
        'TextBox2
        '
        Me.TextBox2.DataField = "MATERIAL"
        Me.TextBox2.Height = 0.135!
        Me.TextBox2.Left = 3.726!
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox2.Text = Nothing
        Me.TextBox2.Top = 0.0!
        Me.TextBox2.Width = 0.6799996!
        '
        'TextBox3
        '
        Me.TextBox3.DataField = "SOLICITADO"
        Me.TextBox3.Height = 0.135!
        Me.TextBox3.Left = 6.544!
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox3.Text = Nothing
        Me.TextBox3.Top = 0.0!
        Me.TextBox3.Width = 0.5189998!
        '
        'TextBox4
        '
        Me.TextBox4.DataField = "CANT_ENTREGADO"
        Me.TextBox4.Height = 0.135!
        Me.TextBox4.Left = 7.063!
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox4.Text = Nothing
        Me.TextBox4.Top = 0.0!
        Me.TextBox4.Width = 0.5130005!
        '
        'TextBox5
        '
        Me.TextBox5.DataField = "KZWI5"
        Me.TextBox5.Height = 0.135!
        Me.TextBox5.Left = 8.74!
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat")
        Me.TextBox5.Style = "text-align: right; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox5.Text = Nothing
        Me.TextBox5.Top = 0.0!
        Me.TextBox5.Width = 0.4990005!
        '
        'TextBox6
        '
        Me.TextBox6.DataField = "KWERT_SINIVA"
        Me.TextBox6.Height = 0.135!
        Me.TextBox6.Left = 8.177!
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat")
        Me.TextBox6.Style = "text-align: right; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox6.Text = Nothing
        Me.TextBox6.Top = 0.0!
        Me.TextBox6.Width = 0.5630004!
        '
        'TextBox7
        '
        Me.TextBox7.DataField = "ESTATUS"
        Me.TextBox7.Height = 0.135!
        Me.TextBox7.Left = 9.864!
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox7.Text = Nothing
        Me.TextBox7.Top = 0.0!
        Me.TextBox7.Width = 0.687!
        '
        'TextBox8
        '
        Me.TextBox8.DataField = "KWERT"
        Me.TextBox8.Height = 0.135!
        Me.TextBox8.Left = 9.239!
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat")
        Me.TextBox8.Style = "text-align: right; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.TextBox8.Text = Nothing
        Me.TextBox8.Top = 0.0!
        Me.TextBox8.Width = 0.6250002!
        '
        'txtEntrega
        '
        Me.txtEntrega.DataField = "FOLIO_ENTREGA"
        Me.txtEntrega.Height = 0.135!
        Me.txtEntrega.Left = 1.207!
        Me.txtEntrega.Name = "txtEntrega"
        Me.txtEntrega.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtEntrega.Text = Nothing
        Me.txtEntrega.Top = 0.0!
        Me.txtEntrega.Width = 0.751!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "MAKTX"
        Me.txtDescripcion.Height = 0.135!
        Me.txtDescripcion.Left = 4.41!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "text-align: left; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtDescripcion.Text = Nothing
        Me.txtDescripcion.Top = 0.0!
        Me.txtDescripcion.Width = 2.134!
        '
        'txtFechaPedido
        '
        Me.txtFechaPedido.DataField = "FECHA_CREACION"
        Me.txtFechaPedido.Height = 0.135!
        Me.txtFechaPedido.Left = 7.573!
        Me.txtFechaPedido.Name = "txtFechaPedido"
        Me.txtFechaPedido.OutputFormat = resources.GetString("txtFechaPedido.OutputFormat")
        Me.txtFechaPedido.Style = "text-align: center; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtFechaPedido.Text = Nothing
        Me.txtFechaPedido.Top = 0.0!
        Me.txtFechaPedido.Width = 0.6040007!
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblDe, Me.lblFecha, Me.txtFecha, Me.lblSucursal, Me.lblReportTitle, Me.txtFechaDe, Me.lblFechaAl, Me.txtFechaAl, Me.txtSucursal})
        Me.ReportHeader.Height = 0.9048612!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Shape1
        '
        Me.Shape1.Height = 0.625!
        Me.Shape1.Left = 0.0!
        Me.Shape1.LineWeight = 2.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.271!
        Me.Shape1.Width = 10.552!
        '
        'lblDe
        '
        Me.lblDe.Height = 0.1811025!
        Me.lblDe.HyperLink = Nothing
        Me.lblDe.Left = 4.025747!
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblDe.Text = "Del:"
        Me.lblDe.Top = 0.401!
        Me.lblDe.Width = 0.3126271!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.1811025!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 8.817521!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Top = 0.663!
        Me.lblFecha.Width = 0.5050001!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.1811025!
        Me.txtFecha.HyperLink = Nothing
        Me.txtFecha.Left = 9.322521!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "color: Black; ddo-char-set: 0; text-align: right; font-weight: normal; font-size:" & _
    " 8.25pt; font-family: Arial"
        Me.txtFecha.Text = ""
        Me.txtFecha.Top = 0.663!
        Me.txtFecha.Width = 0.8340001!
        '
        'lblSucursal
        '
        Me.lblSucursal.Height = 0.1811025!
        Me.lblSucursal.HyperLink = Nothing
        Me.lblSucursal.Left = 0.3954791!
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblSucursal.Text = "Sucursal:"
        Me.lblSucursal.Top = 0.663!
        Me.lblSucursal.Width = 0.5625!
        '
        'lblReportTitle
        '
        Me.lblReportTitle.ClassName = "Heading1"
        Me.lblReportTitle.Height = 0.1875!
        Me.lblReportTitle.HyperLink = Nothing
        Me.lblReportTitle.Left = 3.8385!
        Me.lblReportTitle.MultiLine = False
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; white-space: nowrap; vert" & _
    "ical-align: middle"
        Me.lblReportTitle.Text = "REPORTE DE PEDIDOS DE ECOMMERCE"
        Me.lblReportTitle.Top = 0.032!
        Me.lblReportTitle.Width = 2.875!
        '
        'txtFechaDe
        '
        Me.txtFechaDe.Height = 0.1811025!
        Me.txtFechaDe.HyperLink = Nothing
        Me.txtFechaDe.Left = 4.338748!
        Me.txtFechaDe.Name = "txtFechaDe"
        Me.txtFechaDe.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.txtFechaDe.Text = ""
        Me.txtFechaDe.Top = 0.401!
        Me.txtFechaDe.Width = 0.9685042!
        '
        'lblFechaAl
        '
        Me.lblFechaAl.Height = 0.1811025!
        Me.lblFechaAl.HyperLink = Nothing
        Me.lblFechaAl.Left = 5.307748!
        Me.lblFechaAl.Name = "lblFechaAl"
        Me.lblFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8." & _
    "25pt; font-family: Arial"
        Me.lblFechaAl.Text = "Al:"
        Me.lblFechaAl.Top = 0.401!
        Me.lblFechaAl.Width = 0.2501273!
        '
        'txtFechaAl
        '
        Me.txtFechaAl.Height = 0.1811025!
        Me.txtFechaAl.HyperLink = Nothing
        Me.txtFechaAl.Left = 5.557748!
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.txtFechaAl.Text = ""
        Me.txtFechaAl.Top = 0.401!
        Me.txtFechaAl.Width = 0.9685042!
        '
        'txtSucursal
        '
        Me.txtSucursal.Height = 0.1811025!
        Me.txtSucursal.HyperLink = Nothing
        Me.txtSucursal.Left = 0.9574793!
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: " & _
    "8.25pt; font-family: Arial"
        Me.txtSucursal.Text = ""
        Me.txtSucursal.Top = 0.663!
        Me.txtSucursal.Width = 3.448326!
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.txtTotalImporte, Me.Label1})
        Me.ReportFooter.Height = 0.2330321!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'Shape3
        '
        Me.Shape3.Height = 0.233!
        Me.Shape3.Left = 0.0!
        Me.Shape3.LineWeight = 2.0!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = 9.999999!
        Me.Shape3.Top = 0.0!
        Me.Shape3.Width = 10.558!
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Height = 0.156!
        Me.txtTotalImporte.Left = 9.218!
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.Style = "text-align: right; font-size: 6.75pt; font-family: Microsoft Sans Serif"
        Me.txtTotalImporte.Text = Nothing
        Me.txtTotalImporte.Top = 0.037!
        Me.txtTotalImporte.Width = 0.625!
        '
        'Label1
        '
        Me.Label1.Height = 0.159!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 8.156!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "color: Black; ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8" & _
    ".25pt; font-family: Microsoft Sans Serif"
        Me.Label1.Text = "Importe Total"
        Me.Label1.Top = 0.04403208!
        Me.Label1.Width = 1.062!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFolio, Me.lblFolioSAP, Me.lblFieldFecha, Me.lblTotalArt, Me.lblImporte, Me.lblDescuento, Me.lblFormaPago, Me.lblPago, Me.lblVendedor, Me.lblCliente, Me.lblTipoVenta, Me.lblNotaVenta, Me.Label2, Me.Label3})
        Me.GroupHeader1.Height = 0.15675!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblFolio
        '
        Me.lblFolio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolio.Height = 0.156!
        Me.lblFolio.HyperLink = Nothing
        Me.lblFolio.Left = 0.0!
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblFolio.Text = "Pedido"
        Me.lblFolio.Top = 0.0!
        Me.lblFolio.Width = 0.675!
        '
        'lblFolioSAP
        '
        Me.lblFolioSAP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFolioSAP.Height = 0.156!
        Me.lblFolioSAP.HyperLink = Nothing
        Me.lblFolioSAP.Left = 0.675!
        Me.lblFolioSAP.Name = "lblFolioSAP"
        Me.lblFolioSAP.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblFolioSAP.Text = "Solicitud"
        Me.lblFolioSAP.Top = 0.0!
        Me.lblFolioSAP.Width = 0.5320001!
        '
        'lblFieldFecha
        '
        Me.lblFieldFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFieldFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFieldFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFieldFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFieldFecha.Height = 0.156!
        Me.lblFieldFecha.HyperLink = Nothing
        Me.lblFieldFecha.Left = 1.966!
        Me.lblFieldFecha.Name = "lblFieldFecha"
        Me.lblFieldFecha.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblFieldFecha.Text = "Guia"
        Me.lblFieldFecha.Top = 0.0!
        Me.lblFieldFecha.Width = 0.6730001!
        '
        'lblTotalArt
        '
        Me.lblTotalArt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTotalArt.Height = 0.1565!
        Me.lblTotalArt.HyperLink = Nothing
        Me.lblTotalArt.Left = 2.639!
        Me.lblTotalArt.Name = "lblTotalArt"
        Me.lblTotalArt.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblTotalArt.Text = "Responsable"
        Me.lblTotalArt.Top = 0.0!
        Me.lblTotalArt.Width = 1.087!
        '
        'lblImporte
        '
        Me.lblImporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblImporte.Height = 0.1565!
        Me.lblImporte.HyperLink = Nothing
        Me.lblImporte.Left = 3.726!
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblImporte.Text = "Material"
        Me.lblImporte.Top = 0.0!
        Me.lblImporte.Width = 0.6839998!
        '
        'lblDescuento
        '
        Me.lblDescuento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescuento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescuento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescuento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescuento.Height = 0.156!
        Me.lblDescuento.HyperLink = Nothing
        Me.lblDescuento.Left = 6.540001!
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblDescuento.Text = "Solicitado"
        Me.lblDescuento.Top = 0.0!
        Me.lblDescuento.Width = 0.5160002!
        '
        'lblFormaPago
        '
        Me.lblFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Height = 0.156!
        Me.lblFormaPago.HyperLink = Nothing
        Me.lblFormaPago.Left = 7.063001!
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblFormaPago.Text = "Entregado"
        Me.lblFormaPago.Top = 0.0!
        Me.lblFormaPago.Width = 0.5099996!
        '
        'lblPago
        '
        Me.lblPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPago.Height = 0.156!
        Me.lblPago.HyperLink = Nothing
        Me.lblPago.Left = 9.864!
        Me.lblPago.Name = "lblPago"
        Me.lblPago.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblPago.Text = "Status"
        Me.lblPago.Top = 0.0!
        Me.lblPago.Width = 0.6875!
        '
        'lblVendedor
        '
        Me.lblVendedor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblVendedor.Height = 0.156!
        Me.lblVendedor.HyperLink = Nothing
        Me.lblVendedor.Left = 8.177002!
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblVendedor.Tag = ""
        Me.lblVendedor.Text = "Importe"
        Me.lblVendedor.Top = 0.0!
        Me.lblVendedor.Width = 0.5625!
        '
        'lblCliente
        '
        Me.lblCliente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCliente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCliente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCliente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCliente.Height = 0.156!
        Me.lblCliente.HyperLink = Nothing
        Me.lblCliente.Left = 8.739!
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblCliente.Text = "IVA"
        Me.lblCliente.Top = 0.0!
        Me.lblCliente.Width = 0.5!
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoVenta.Height = 0.156!
        Me.lblTipoVenta.HyperLink = Nothing
        Me.lblTipoVenta.Left = 9.239!
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblTipoVenta.Text = "Total"
        Me.lblTipoVenta.Top = 0.0!
        Me.lblTipoVenta.Width = 0.625!
        '
        'lblNotaVenta
        '
        Me.lblNotaVenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNotaVenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNotaVenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNotaVenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNotaVenta.Height = 0.156!
        Me.lblNotaVenta.HyperLink = Nothing
        Me.lblNotaVenta.Left = 1.207!
        Me.lblNotaVenta.Name = "lblNotaVenta"
        Me.lblNotaVenta.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.lblNotaVenta.Text = "Nota de venta"
        Me.lblNotaVenta.Top = 0.0!
        Me.lblNotaVenta.Width = 0.7510001!
        '
        'Label2
        '
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Height = 0.1565!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 4.41!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.Label2.Text = "Descripción"
        Me.Label2.Top = 0.0!
        Me.Label2.Width = 2.134!
        '
        'Label3
        '
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Height = 0.156!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 7.576!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: center; font-weight: bold; font-size: 6.75pt; font-family: Microsoft " & _
    "Sans Serif"
        Me.Label3.Tag = ""
        Me.Label3.Text = "Fecha"
        Me.Label3.Top = 0.0!
        Me.Label3.Width = 0.6010008!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptPedidosTotalesEC
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.2!
        Me.PageSettings.Margins.Left = 0.2!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.2!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.558!
        Me.Sections.Add(Me.ReportHeader)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.ReportFooter)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" & _
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" & _
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
        CType(Me.txtPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReportTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaAl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFolioSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFieldFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNotaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region "Metodos y Funciones"

    '------------------------------------------------------------------------------------------
    ' JNAVA (15.03.2016): Funcion para darle formato al detalle del reporte
    '------------------------------------------------------------------------------------------
    Sub FormatearDetalle(ByRef PedidoDetalle As DataTable)

        Dim dtDetalle As DataTable = PedidoDetalle.Copy
        For Each oRow As DataRow In dtDetalle.Rows

            '------------------------------------------------------------------------------------------
            ' JNAVA (15.03.2016): Quitamos ceros a la izquierda del pedido y el material
            '------------------------------------------------------------------------------------------
            oRow!FOLIO_PEDIDO = CStr(oRow!FOLIO_PEDIDO).TrimStart("0")
            oRow!MATERIAL = CStr(oRow!MATERIAL).TrimStart("0")

            '------------------------------------------------------------------------------------------
            ' JNAVA (15.03.2016): Damos formato al estatus del pedido
            '------------------------------------------------------------------------------------------
            Select Case oRow!ESTATUS
                Case "P"
                    oRow!ESTATUS = "Pendiente"
                Case "PS"
                    oRow!ESTATUS = "Parcialmente Surtido"
                Case "S"
                    oRow!ESTATUS = "Surtido"
                Case "N"
                    oRow!ESTATUS = "Negado"
                Case "F"
                    oRow!ESTATUS = "Facturado"
                Case "PF"
                    oRow!ESTATUS = "Parcialmente Facturado"
                Case "C"
                    oRow!ESTATUS = "Cancelado"
            End Select

            '------------------------------------------------------------------------------------------
            ' JNAVA (17.03.2016): Damos formato a la fecha de creacion
            '------------------------------------------------------------------------------------------
            Dim Fecha As String = CStr(oRow!FECHA_CREACION)
            If Fecha.Trim("0").Trim <> "" Then
                oRow!FECHA_CREACION = CDate(Fecha.Substring(6, 2) & "/" & Fecha.Substring(4, 2) & "/" & Fecha.Substring(0, 4)).ToShortDateString
            Else
                oRow!FECHA_CREACION = String.Empty
            End If
            '------------------------------------------------------------------------------------------
        Next

        PedidoDetalle = dtDetalle.Copy

    End Sub

#End Region

End Class
