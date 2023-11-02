Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptConsignacion
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dtTrasladoDetalles As DataTable)
        MyBase.New()
        InitializeComponent()
        Dim row As DataRow = Nothing
        If dtTrasladoDetalles.Rows.Count Then
            Me.PageSettings.Orientation = PageOrientation.Landscape
            row = dtTrasladoDetalles.Rows(0)
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
            txtNoPedido.Text = CStr(row("EBELN"))
            txtProveedor.Text = CStr(row("LIFNR"))
            txtProveedorDesc.Text = CStr(row("TXLFN"))
            txtTienda.Text = CStr(row("WERKS"))
            txtTiendaDesc.Text = CStr(row("TXWRK"))
            txtPedidoId.Text = CStr(row("EBELN"))
            txtReferencia.Text = CStr(row("LFSNR"))
            txtResponsable.Text = CStr(row("BKTXT"))
            Me.DataSource = dtTrasladoDetalles
            Me.Run()
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Friend WithEvents lblResponsable As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNoPedido As DataDynamics.ActiveReports.Label
    Private WithEvents txtNoPedido As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtResponsable As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblProveedor As DataDynamics.ActiveReports.Label
    Friend WithEvents txtProveedor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblProveedorDesc As DataDynamics.ActiveReports.Label
    Friend WithEvents txtProveedorDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTienda As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTienda As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTiendaDesc As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTiendaDesc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblReferencia As DataDynamics.ActiveReports.Label
    Friend WithEvents txtReferencia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblPedidoId As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPedidoId As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMaterial As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDescripcion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNoSerie As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCantidad As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMaterial As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescripcion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoSerie As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCantidad As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblQuienRecibe As DataDynamics.ActiveReports.Label
    Private WithEvents Line1 As DataDynamics.ActiveReports.Line
    Private WithEvents logo_dp As DataDynamics.ActiveReports.Picture
    Friend WithEvents lblTotalPiezas As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTotalPiezas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFaltante As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFaltante As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSobrante As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSobrante As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCodProv As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodProv As DataDynamics.ActiveReports.Label
    Private WithEvents PageFooter As PageFooter = Nothing
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptConsignacion))
        Me.Detail = New DataDynamics.ActiveReports.Detail()
        Me.txtMaterial = New DataDynamics.ActiveReports.TextBox()
        Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
        Me.txtNoSerie = New DataDynamics.ActiveReports.TextBox()
        Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
        Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
        Me.lblResponsable = New DataDynamics.ActiveReports.Label()
        Me.lblNoPedido = New DataDynamics.ActiveReports.Label()
        Me.txtNoPedido = New DataDynamics.ActiveReports.TextBox()
        Me.txtResponsable = New DataDynamics.ActiveReports.TextBox()
        Me.lblProveedor = New DataDynamics.ActiveReports.Label()
        Me.txtProveedor = New DataDynamics.ActiveReports.TextBox()
        Me.lblProveedorDesc = New DataDynamics.ActiveReports.Label()
        Me.txtProveedorDesc = New DataDynamics.ActiveReports.TextBox()
        Me.lblTienda = New DataDynamics.ActiveReports.Label()
        Me.txtTienda = New DataDynamics.ActiveReports.TextBox()
        Me.lblTiendaDesc = New DataDynamics.ActiveReports.Label()
        Me.txtTiendaDesc = New DataDynamics.ActiveReports.TextBox()
        Me.lblReferencia = New DataDynamics.ActiveReports.Label()
        Me.txtReferencia = New DataDynamics.ActiveReports.TextBox()
        Me.lblPedidoId = New DataDynamics.ActiveReports.Label()
        Me.txtPedidoId = New DataDynamics.ActiveReports.TextBox()
        Me.lblMaterial = New DataDynamics.ActiveReports.Label()
        Me.lblDescripcion = New DataDynamics.ActiveReports.Label()
        Me.lblNoSerie = New DataDynamics.ActiveReports.Label()
        Me.lblCantidad = New DataDynamics.ActiveReports.Label()
        Me.logo_dp = New DataDynamics.ActiveReports.Picture()
        Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
        Me.lblQuienRecibe = New DataDynamics.ActiveReports.Label()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.lblTotalPiezas = New DataDynamics.ActiveReports.Label()
        Me.txtTotalPiezas = New DataDynamics.ActiveReports.TextBox()
        Me.lblFaltante = New DataDynamics.ActiveReports.Label()
        Me.txtFaltante = New DataDynamics.ActiveReports.TextBox()
        Me.lblSobrante = New DataDynamics.ActiveReports.Label()
        Me.txtSobrante = New DataDynamics.ActiveReports.TextBox()
        Me.lblFecha = New DataDynamics.ActiveReports.Label()
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
        Me.lblCodProv = New DataDynamics.ActiveReports.Label()
        Me.txtCodProv = New DataDynamics.ActiveReports.TextBox()
        CType(Me.txtMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProveedorDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedorDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTiendaDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTiendaDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPedidoId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPedidoId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logo_dp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblQuienRecibe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPiezas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFaltante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFaltante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSobrante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSobrante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.ColumnSpacing = 0.0!
        Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtMaterial, Me.txtDescripcion, Me.txtNoSerie, Me.txtCantidad, Me.txtFaltante, Me.txtSobrante, Me.txtCodProv})
        Me.Detail.Height = 0.1880001!
        Me.Detail.Name = "Detail"
        '
        'txtMaterial
        '
        Me.txtMaterial.DataField = "MATNR"
        Me.txtMaterial.Height = 0.188!
        Me.txtMaterial.Left = 0.224!
        Me.txtMaterial.Name = "txtMaterial"
        Me.txtMaterial.Style = "font-size: 8.25pt"
        Me.txtMaterial.Text = Nothing
        Me.txtMaterial.Top = 0.0!
        Me.txtMaterial.Width = 1.51!
        '
        'txtDescripcion
        '
        Me.txtDescripcion.DataField = "TXZ01"
        Me.txtDescripcion.Height = 0.188!
        Me.txtDescripcion.Left = 3.254!
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Style = "font-size: 8.25pt"
        Me.txtDescripcion.Text = Nothing
        Me.txtDescripcion.Top = 0.0000001192093!
        Me.txtDescripcion.Width = 3.359!
        '
        'txtNoSerie
        '
        Me.txtNoSerie.DataField = "SERNR"
        Me.txtNoSerie.Height = 0.188!
        Me.txtNoSerie.Left = 6.613!
        Me.txtNoSerie.Name = "txtNoSerie"
        Me.txtNoSerie.Style = "font-size: 8.25pt"
        Me.txtNoSerie.Text = Nothing
        Me.txtNoSerie.Top = 0.0000001192093!
        Me.txtNoSerie.Width = 1.094!
        '
        'txtCantidad
        '
        Me.txtCantidad.DataField = "ERFMG"
        Me.txtCantidad.Height = 0.188!
        Me.txtCantidad.Left = 7.707001!
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Style = "font-size: 8.25pt; text-align: center"
        Me.txtCantidad.Text = Nothing
        Me.txtCantidad.Top = 0.0000001192093!
        Me.txtCantidad.Width = 0.5520002!
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblResponsable, Me.lblNoPedido, Me.txtNoPedido, Me.txtResponsable, Me.lblProveedor, Me.txtProveedor, Me.lblProveedorDesc, Me.txtProveedorDesc, Me.lblTienda, Me.txtTienda, Me.lblTiendaDesc, Me.txtTiendaDesc, Me.lblReferencia, Me.txtReferencia, Me.lblPedidoId, Me.txtPedidoId, Me.lblMaterial, Me.lblDescripcion, Me.lblNoSerie, Me.lblCantidad, Me.logo_dp, Me.lblFaltante, Me.lblSobrante, Me.lblFecha, Me.txtFecha, Me.lblCodProv})
        Me.PageHeader.Height = 1.521!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblResponsable
        '
        Me.lblResponsable.Height = 0.1875!
        Me.lblResponsable.HyperLink = Nothing
        Me.lblResponsable.Left = 2.573!
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblResponsable.Text = "Responsable:"
        Me.lblResponsable.Top = 0.8330001!
        Me.lblResponsable.Width = 1.103!
        '
        'lblNoPedido
        '
        Me.lblNoPedido.Height = 0.1875!
        Me.lblNoPedido.HyperLink = Nothing
        Me.lblNoPedido.Left = 0.24!
        Me.lblNoPedido.Name = "lblNoPedido"
        Me.lblNoPedido.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblNoPedido.Text = "No Pedido:"
        Me.lblNoPedido.Top = 0.271!
        Me.lblNoPedido.Width = 0.677!
        '
        'txtNoPedido
        '
        Me.txtNoPedido.Height = 0.188!
        Me.txtNoPedido.Left = 0.933!
        Me.txtNoPedido.Name = "txtNoPedido"
        Me.txtNoPedido.Style = "font-size: 8.25pt"
        Me.txtNoPedido.Text = Nothing
        Me.txtNoPedido.Top = 0.271!
        Me.txtNoPedido.Width = 1.0!
        '
        'txtResponsable
        '
        Me.txtResponsable.Height = 0.188!
        Me.txtResponsable.Left = 3.676!
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Style = "font-size: 8.25pt"
        Me.txtResponsable.Text = Nothing
        Me.txtResponsable.Top = 0.8330001!
        Me.txtResponsable.Width = 1.99!
        '
        'lblProveedor
        '
        Me.lblProveedor.Height = 0.1875!
        Me.lblProveedor.HyperLink = Nothing
        Me.lblProveedor.Left = 0.24!
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblProveedor.Text = "Proveedor:"
        Me.lblProveedor.Top = 0.459!
        Me.lblProveedor.Width = 0.6770001!
        '
        'txtProveedor
        '
        Me.txtProveedor.Height = 0.188!
        Me.txtProveedor.Left = 0.933!
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Style = "font-size: 8.25pt"
        Me.txtProveedor.Text = Nothing
        Me.txtProveedor.Top = 0.459!
        Me.txtProveedor.Width = 1.0!
        '
        'lblProveedorDesc
        '
        Me.lblProveedorDesc.Height = 0.1875!
        Me.lblProveedorDesc.HyperLink = Nothing
        Me.lblProveedorDesc.Left = 2.573!
        Me.lblProveedorDesc.Name = "lblProveedorDesc"
        Me.lblProveedorDesc.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblProveedorDesc.Text = "Descripción Prov:"
        Me.lblProveedorDesc.Top = 0.459!
        Me.lblProveedorDesc.Width = 1.103!
        '
        'txtProveedorDesc
        '
        Me.txtProveedorDesc.Height = 0.188!
        Me.txtProveedorDesc.Left = 3.676!
        Me.txtProveedorDesc.Name = "txtProveedorDesc"
        Me.txtProveedorDesc.Style = "font-size: 8.25pt"
        Me.txtProveedorDesc.Text = Nothing
        Me.txtProveedorDesc.Top = 0.459!
        Me.txtProveedorDesc.Width = 1.99!
        '
        'lblTienda
        '
        Me.lblTienda.Height = 0.1875!
        Me.lblTienda.HyperLink = Nothing
        Me.lblTienda.Left = 0.24!
        Me.lblTienda.Name = "lblTienda"
        Me.lblTienda.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblTienda.Text = "Tienda:"
        Me.lblTienda.Top = 0.646!
        Me.lblTienda.Width = 0.6770001!
        '
        'txtTienda
        '
        Me.txtTienda.Height = 0.188!
        Me.txtTienda.Left = 0.933!
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Style = "font-size: 8.25pt"
        Me.txtTienda.Text = Nothing
        Me.txtTienda.Top = 0.646!
        Me.txtTienda.Width = 1.0!
        '
        'lblTiendaDesc
        '
        Me.lblTiendaDesc.Height = 0.1875!
        Me.lblTiendaDesc.HyperLink = Nothing
        Me.lblTiendaDesc.Left = 2.573!
        Me.lblTiendaDesc.Name = "lblTiendaDesc"
        Me.lblTiendaDesc.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblTiendaDesc.Text = "Nombre deTienda:"
        Me.lblTiendaDesc.Top = 0.647!
        Me.lblTiendaDesc.Width = 1.103!
        '
        'txtTiendaDesc
        '
        Me.txtTiendaDesc.Height = 0.188!
        Me.txtTiendaDesc.Left = 3.676!
        Me.txtTiendaDesc.Name = "txtTiendaDesc"
        Me.txtTiendaDesc.Style = "font-size: 8.25pt"
        Me.txtTiendaDesc.Text = Nothing
        Me.txtTiendaDesc.Top = 0.647!
        Me.txtTiendaDesc.Width = 1.99!
        '
        'lblReferencia
        '
        Me.lblReferencia.Height = 0.1875!
        Me.lblReferencia.HyperLink = Nothing
        Me.lblReferencia.Left = 0.24!
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblReferencia.Text = "Referencia:"
        Me.lblReferencia.Top = 0.8340001!
        Me.lblReferencia.Width = 0.6770001!
        '
        'txtReferencia
        '
        Me.txtReferencia.Height = 0.188!
        Me.txtReferencia.Left = 0.933!
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Style = "font-size: 8.25pt"
        Me.txtReferencia.Text = Nothing
        Me.txtReferencia.Top = 0.8340001!
        Me.txtReferencia.Width = 1.0!
        '
        'lblPedidoId
        '
        Me.lblPedidoId.Height = 0.1875!
        Me.lblPedidoId.HyperLink = Nothing
        Me.lblPedidoId.Left = 0.24!
        Me.lblPedidoId.Name = "lblPedidoId"
        Me.lblPedidoId.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblPedidoId.Text = "Pedido Id:"
        Me.lblPedidoId.Top = 1.022!
        Me.lblPedidoId.Width = 0.6770001!
        '
        'txtPedidoId
        '
        Me.txtPedidoId.Height = 0.188!
        Me.txtPedidoId.Left = 0.933!
        Me.txtPedidoId.Name = "txtPedidoId"
        Me.txtPedidoId.Style = "font-size: 8.25pt"
        Me.txtPedidoId.Text = Nothing
        Me.txtPedidoId.Top = 1.022!
        Me.txtPedidoId.Width = 1.0!
        '
        'lblMaterial
        '
        Me.lblMaterial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMaterial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMaterial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMaterial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMaterial.Height = 0.1875!
        Me.lblMaterial.HyperLink = Nothing
        Me.lblMaterial.Left = 0.224!
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblMaterial.Text = "Material"
        Me.lblMaterial.Top = 1.333!
        Me.lblMaterial.Width = 1.51!
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcion.Height = 0.1875!
        Me.lblDescripcion.HyperLink = Nothing
        Me.lblDescripcion.Left = 3.254!
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.Top = 1.333!
        Me.lblDescripcion.Width = 3.359!
        '
        'lblNoSerie
        '
        Me.lblNoSerie.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNoSerie.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNoSerie.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNoSerie.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNoSerie.Height = 0.1875!
        Me.lblNoSerie.HyperLink = Nothing
        Me.lblNoSerie.Left = 6.613!
        Me.lblNoSerie.Name = "lblNoSerie"
        Me.lblNoSerie.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblNoSerie.Text = "No. Serie"
        Me.lblNoSerie.Top = 1.333!
        Me.lblNoSerie.Width = 1.094!
        '
        'lblCantidad
        '
        Me.lblCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCantidad.Height = 0.1875!
        Me.lblCantidad.HyperLink = Nothing
        Me.lblCantidad.Left = 7.707001!
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.Top = 1.333!
        Me.lblCantidad.Width = 0.5520002!
        '
        'logo_dp
        '
        Me.logo_dp.Height = 1.0!
        Me.logo_dp.ImageData = CType(resources.GetObject("logo_dp.ImageData"), System.IO.Stream)
        Me.logo_dp.Left = 8.353001!
        Me.logo_dp.LineWeight = 0.0!
        Me.logo_dp.Name = "logo_dp"
        Me.logo_dp.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.logo_dp.Top = 0.148!
        Me.logo_dp.Width = 1.0!
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblQuienRecibe, Me.Line1, Me.lblTotalPiezas, Me.txtTotalPiezas})
        Me.PageFooter.Height = 1.302083!
        Me.PageFooter.Name = "PageFooter"
        '
        'lblQuienRecibe
        '
        Me.lblQuienRecibe.Height = 0.22!
        Me.lblQuienRecibe.HyperLink = Nothing
        Me.lblQuienRecibe.Left = 3.873!
        Me.lblQuienRecibe.Name = "lblQuienRecibe"
        Me.lblQuienRecibe.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblQuienRecibe.Text = "Nombre y firma de quien recibe"
        Me.lblQuienRecibe.Top = 0.846!
        Me.lblQuienRecibe.Width = 1.817!
        '
        'Line1
        '
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 3.693!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.846!
        Me.Line1.Width = 2.104031!
        Me.Line1.X1 = 3.693!
        Me.Line1.X2 = 5.797031!
        Me.Line1.Y1 = 0.846!
        Me.Line1.Y2 = 0.846!
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.Height = 0.19!
        Me.lblTotalPiezas.HyperLink = Nothing
        Me.lblTotalPiezas.Left = 6.786964!
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblTotalPiezas.Text = "Total de piezas"
        Me.lblTotalPiezas.Top = 0.0!
        Me.lblTotalPiezas.Width = 0.9200001!
        '
        'txtTotalPiezas
        '
        Me.txtTotalPiezas.DataField = "ERFMG"
        Me.txtTotalPiezas.Height = 0.188!
        Me.txtTotalPiezas.Left = 7.706964!
        Me.txtTotalPiezas.Name = "txtTotalPiezas"
        Me.txtTotalPiezas.Style = "font-size: 8.25pt"
        Me.txtTotalPiezas.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtTotalPiezas.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalPiezas.Text = Nothing
        Me.txtTotalPiezas.Top = 0.002!
        Me.txtTotalPiezas.Width = 0.5520001!
        '
        'lblFaltante
        '
        Me.lblFaltante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFaltante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFaltante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFaltante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFaltante.Height = 0.1875!
        Me.lblFaltante.HyperLink = Nothing
        Me.lblFaltante.Left = 8.259007!
        Me.lblFaltante.Name = "lblFaltante"
        Me.lblFaltante.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblFaltante.Text = "Faltante"
        Me.lblFaltante.Top = 1.333!
        Me.lblFaltante.Width = 0.5520002!
        '
        'txtFaltante
        '
        Me.txtFaltante.DataField = "Faltante"
        Me.txtFaltante.Height = 0.188!
        Me.txtFaltante.Left = 8.259007!
        Me.txtFaltante.Name = "txtFaltante"
        Me.txtFaltante.Style = "font-size: 8.25pt; text-align: center"
        Me.txtFaltante.Text = Nothing
        Me.txtFaltante.Top = 0.0000001192093!
        Me.txtFaltante.Width = 0.5520002!
        '
        'lblSobrante
        '
        Me.lblSobrante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSobrante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSobrante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSobrante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSobrante.Height = 0.1875!
        Me.lblSobrante.HyperLink = Nothing
        Me.lblSobrante.Left = 8.81102!
        Me.lblSobrante.Name = "lblSobrante"
        Me.lblSobrante.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblSobrante.Text = "Sobrante"
        Me.lblSobrante.Top = 1.333!
        Me.lblSobrante.Width = 0.5520002!
        '
        'txtSobrante
        '
        Me.txtSobrante.DataField = "Sobrante"
        Me.txtSobrante.Height = 0.188!
        Me.txtSobrante.Left = 8.81102!
        Me.txtSobrante.Name = "txtSobrante"
        Me.txtSobrante.Style = "font-size: 8.25pt; text-align: center"
        Me.txtSobrante.Text = Nothing
        Me.txtSobrante.Top = 0.0000001192093!
        Me.txtSobrante.Width = 0.5520002!
        '
        'lblFecha
        '
        Me.lblFecha.Height = 0.1875!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.24!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial"
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Top = 0.083!
        Me.lblFecha.Width = 0.677!
        '
        'txtFecha
        '
        Me.txtFecha.Height = 0.188!
        Me.txtFecha.Left = 0.933!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Style = "font-size: 8.25pt"
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.083!
        Me.txtFecha.Width = 1.0!
        '
        'lblCodProv
        '
        Me.lblCodProv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodProv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodProv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodProv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodProv.Height = 0.1875!
        Me.lblCodProv.HyperLink = Nothing
        Me.lblCodProv.Left = 1.734!
        Me.lblCodProv.Name = "lblCodProv"
        Me.lblCodProv.Style = "font-weight: bold; font-size: 8.25pt; font-family: Arial; text-align: center"
        Me.lblCodProv.Text = "Cod Proveedor"
        Me.lblCodProv.Top = 1.333!
        Me.lblCodProv.Width = 1.51!
        '
        'txtCodProv
        '
        Me.txtCodProv.DataField = "IDNLF"
        Me.txtCodProv.Height = 0.188!
        Me.txtCodProv.Left = 1.734!
        Me.txtCodProv.Name = "txtCodProv"
        Me.txtCodProv.Style = "font-size: 8.25pt"
        Me.txtCodProv.Text = Nothing
        Me.txtCodProv.Top = 0.0!
        Me.txtCodProv.Width = 1.51!
        '
        'rptConsignacion
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Bottom = 0.0!
        Me.PageSettings.Margins.Left = 0.3!
        Me.PageSettings.Margins.Right = 0.0!
        Me.PageSettings.Margins.Top = 0.1!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 9.500166!
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
        CType(Me.txtMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProveedorDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedorDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTiendaDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTiendaDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPedidoId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPedidoId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logo_dp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblQuienRecibe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPiezas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFaltante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFaltante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSobrante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSobrante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class
