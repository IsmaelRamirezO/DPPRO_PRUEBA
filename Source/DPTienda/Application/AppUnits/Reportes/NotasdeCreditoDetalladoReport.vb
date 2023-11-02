Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class NotasdeCreditoDetalladoReport

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New( _
                    ByVal nCaja As String, _
                    ByVal fDesde As Date, _
                    ByVal fHasta As Date, _
                    ByVal strSucursal As String, _
                    ByVal dtDetallado As DataTable)

        MyBase.New()

        InitializeComponent()

        lblFechaReporte.Text = Format(Date.Now, "dd/MM/yyyy")
        lblPagina.Text = "PAG: " & Me.PageNumber
        If nCaja = "00" Then
            lblCaja.Text = "Caja #: Todas"
        Else
            lblCaja.Text = "Caja #: " & nCaja
        End If
        lblRango.Text = "De : " & Format(fDesde, "dd/MM/yyyy") & " Al : " & Format(fHasta, "dd/MM/yyyy")
        lblSucursalDescripcion.Text = "Sucursal : " & strSucursal

        Me.DataSource = dtDetallado
        Me.DataMember = "Detallado"
        Me.txtFolio.DataField = "FolioNotaCredito"
        Me.txtFolioSAP.DataField = "SalesDocument"
        Me.txtSucursal.DataField = "CodAlmacen"
        Me.txtCodigo.DataField = "CodArticulo"
        Me.txtCantidad.DataField = "Cantidad"
        Me.txtTalla.DataField = "Numero"
        Me.txtImporte.DataField = "Importe"
        Me.txtTipo.DataField = "CodTipoDevolucion"
        Me.txtFechaFactura.DataField = "FechaFactura"
        Me.txtFolioFactura.DataField = "FolioReferencia"

        Me.txtTotalImporte.DataField = "Importe"

        Me.Run()

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblFechaReporte As Label = Nothing
	Private lblCaja As Label = Nothing
	Private lblTitulo As Label = Nothing
	Private lblRango As Label = Nothing
	Private lblPagina As Label = Nothing
	Private lblFolio As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblImporte As Label = Nothing
	Private lblCliente As Label = Nothing
	Private lblReviso As Label = Nothing
	Private Line4 As Line = Nothing
	Private Line5 As Line = Nothing
	Private Line6 As Line = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Line7 As Line = Nothing
	Private Line8 As Line = Nothing
	Private Line9 As Line = Nothing
	Private Line10 As Line = Nothing
	Private Line11 As Line = Nothing
	Private Line12 As Line = Nothing
	Private Label4 As Label = Nothing
	Private Line13 As Line = Nothing
	Private lblSucursalDescripcion As Label = Nothing
	Private Line14 As Line = Nothing
	Private Label6 As Label = Nothing
	Private txtFolio As TextBox = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtCodigo As TextBox = Nothing
	Private txtCantidad As TextBox = Nothing
	Private txtTalla As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtTipo As TextBox = Nothing
	Private txtFechaFactura As TextBox = Nothing
	Private txtFolioFactura As TextBox = Nothing
	Private txtFolioSAP As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private Label5 As Label = Nothing
	Private txtTotalImporte As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasdeCreditoDetalladoReport))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblFechaReporte = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblRango = New DataDynamics.ActiveReports.Label()
            Me.lblPagina = New DataDynamics.ActiveReports.Label()
            Me.lblFolio = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.lblCliente = New DataDynamics.ActiveReports.Label()
            Me.lblReviso = New DataDynamics.ActiveReports.Label()
            Me.Line4 = New DataDynamics.ActiveReports.Line()
            Me.Line5 = New DataDynamics.ActiveReports.Line()
            Me.Line6 = New DataDynamics.ActiveReports.Line()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Line7 = New DataDynamics.ActiveReports.Line()
            Me.Line8 = New DataDynamics.ActiveReports.Line()
            Me.Line9 = New DataDynamics.ActiveReports.Line()
            Me.Line10 = New DataDynamics.ActiveReports.Line()
            Me.Line11 = New DataDynamics.ActiveReports.Line()
            Me.Line12 = New DataDynamics.ActiveReports.Line()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Line13 = New DataDynamics.ActiveReports.Line()
            Me.lblSucursalDescripcion = New DataDynamics.ActiveReports.Label()
            Me.Line14 = New DataDynamics.ActiveReports.Line()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtFolio = New DataDynamics.ActiveReports.TextBox()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtTalla = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtTipo = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtFolioSAP = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.txtTotalImporte = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblFechaReporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReviso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursalDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTipo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolio, Me.txtSucursal, Me.txtCodigo, Me.txtCantidad, Me.txtTalla, Me.txtImporte, Me.txtTipo, Me.txtFechaFactura, Me.txtFolioFactura, Me.txtFolioSAP})
            Me.Detail.Height = 0.2!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblFechaReporte, Me.lblCaja, Me.lblTitulo, Me.lblRango, Me.lblPagina, Me.lblFolio, Me.lblSucursal, Me.lblFecha, Me.lblImporte, Me.lblCliente, Me.lblReviso, Me.Line4, Me.Line5, Me.Line6, Me.Label1, Me.Label2, Me.Label3, Me.Line7, Me.Line8, Me.Line9, Me.Line10, Me.Line11, Me.Line12, Me.Label4, Me.Line13, Me.lblSucursalDescripcion, Me.Line14, Me.Label6})
            Me.PageHeader.Height = 1.020833!
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
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.Label5, Me.txtTotalImporte})
            Me.GroupFooter1.Height = 0.25!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 1!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.322833!
            '
            'lblFechaReporte
            '
            Me.lblFechaReporte.Height = 0.2!
            Me.lblFechaReporte.HyperLink = Nothing
            Me.lblFechaReporte.Left = 0.0625!
            Me.lblFechaReporte.Name = "lblFechaReporte"
            Me.lblFechaReporte.Style = "text-align: left"
            Me.lblFechaReporte.Text = "FechaReporte"
            Me.lblFechaReporte.Top = 0.0625!
            Me.lblFechaReporte.Width = 0.9375!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.2!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.0625!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "text-align: left"
            Me.lblCaja.Text = "Caja"
            Me.lblCaja.Top = 0.3125!
            Me.lblCaja.Width = 1!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.6875!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "text-align: center"
            Me.lblTitulo.Text = "REPORTE DE NOTAS DE CREDITO DETALLADO"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 3.4375!
            '
            'lblRango
            '
            Me.lblRango.Height = 0.2!
            Me.lblRango.HyperLink = Nothing
            Me.lblRango.Left = 1.875!
            Me.lblRango.Name = "lblRango"
            Me.lblRango.Style = "text-align: center"
            Me.lblRango.Text = "Desde : Hasta:"
            Me.lblRango.Top = 0.3125!
            Me.lblRango.Width = 2.9375!
            '
            'lblPagina
            '
            Me.lblPagina.Height = 0.2!
            Me.lblPagina.HyperLink = Nothing
            Me.lblPagina.Left = 5.8125!
            Me.lblPagina.Name = "lblPagina"
            Me.lblPagina.Style = "text-align: right"
            Me.lblPagina.Text = "Pagina"
            Me.lblPagina.Top = 0.0625!
            Me.lblPagina.Width = 0.9375!
            '
            'lblFolio
            '
            Me.lblFolio.Height = 0.2!
            Me.lblFolio.HyperLink = Nothing
            Me.lblFolio.Left = 0.188!
            Me.lblFolio.Name = "lblFolio"
            Me.lblFolio.Style = "text-align: center; font-size: 9pt"
            Me.lblFolio.Text = "Folio"
            Me.lblFolio.Top = 0.78!
            Me.lblFolio.Width = 0.375!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.2!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 1.688!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "text-align: center; font-size: 8pt"
            Me.lblSucursal.Text = "SUC."
            Me.lblSucursal.Top = 0.78!
            Me.lblSucursal.Width = 0.3125!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.2!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 2.077264!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "text-align: center; font-size: 9pt"
            Me.lblFecha.Text = "Código"
            Me.lblFecha.Top = 0.78!
            Me.lblFecha.Width = 1.047736!
            '
            'lblImporte
            '
            Me.lblImporte.Height = 0.2!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 3.145669!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = "text-align: center; font-size: 9pt"
            Me.lblImporte.Text = "Cantidad"
            Me.lblImporte.Top = 0.78!
            Me.lblImporte.Width = 0.5625!
            '
            'lblCliente
            '
            Me.lblCliente.Height = 0.2!
            Me.lblCliente.HyperLink = Nothing
            Me.lblCliente.Left = 3.785!
            Me.lblCliente.Name = "lblCliente"
            Me.lblCliente.Style = "text-align: center; font-size: 9pt"
            Me.lblCliente.Text = "Talla"
            Me.lblCliente.Top = 0.78!
            Me.lblCliente.Width = 0.3125!
            '
            'lblReviso
            '
            Me.lblReviso.Height = 0.2!
            Me.lblReviso.HyperLink = Nothing
            Me.lblReviso.Left = 4.125!
            Me.lblReviso.Name = "lblReviso"
            Me.lblReviso.Style = "text-align: center; font-size: 9pt"
            Me.lblReviso.Text = "Importe"
            Me.lblReviso.Top = 0.78!
            Me.lblReviso.Width = 0.8125!
            '
            'Line4
            '
            Me.Line4.Height = 0.25!
            Me.Line4.Left = 0.6944444!
            Me.Line4.LineWeight = 1!
            Me.Line4.Name = "Line4"
            Me.Line4.Top = 0.7569444!
            Me.Line4.Width = 0!
            Me.Line4.X1 = 0.6944444!
            Me.Line4.X2 = 0.6944444!
            Me.Line4.Y1 = 0.7569444!
            Me.Line4.Y2 = 1.006944!
            '
            'Line5
            '
            Me.Line5.Height = 0.25!
            Me.Line5.Left = 4.967575!
            Me.Line5.LineWeight = 1!
            Me.Line5.Name = "Line5"
            Me.Line5.Top = 0.7569444!
            Me.Line5.Width = 0!
            Me.Line5.X1 = 4.967575!
            Me.Line5.X2 = 4.967575!
            Me.Line5.Y1 = 0.7569444!
            Me.Line5.Y2 = 1.006944!
            '
            'Line6
            '
            Me.Line6.Height = 0.4569447!
            Me.Line6.Left = 5.597497!
            Me.Line6.LineWeight = 1!
            Me.Line6.Name = "Line6"
            Me.Line6.Top = 0.5581255!
            Me.Line6.Width = 0!
            Me.Line6.X1 = 5.597497!
            Me.Line6.X2 = 5.597497!
            Me.Line6.Y1 = 0.5581255!
            Me.Line6.Y2 = 1.01507!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 5!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center; font-size: 9pt"
            Me.Label1.Text = "T.Devol."
            Me.Label1.Top = 0.78!
            Me.Label1.Width = 0.5625!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 5.75!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: center; font-size: 9pt"
            Me.Label2.Text = "Fecha"
            Me.Label2.Top = 0.78!
            Me.Label2.Width = 0.625!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 6.625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-size: 9pt"
            Me.Label3.Text = "Folio"
            Me.Label3.Top = 0.78!
            Me.Label3.Width = 0.625!
            '
            'Line7
            '
            Me.Line7.Height = 0!
            Me.Line7.Left = 0!
            Me.Line7.LineWeight = 1!
            Me.Line7.Name = "Line7"
            Me.Line7.Top = 0.75!
            Me.Line7.Width = 7.322833!
            Me.Line7.X1 = 7.322833!
            Me.Line7.X2 = 0!
            Me.Line7.Y1 = 0.75!
            Me.Line7.Y2 = 0.75!
            '
            'Line8
            '
            Me.Line8.Height = 0.25!
            Me.Line8.Left = 2.054188!
            Me.Line8.LineWeight = 1!
            Me.Line8.Name = "Line8"
            Me.Line8.Top = 0.7569444!
            Me.Line8.Width = 0!
            Me.Line8.X1 = 2.054188!
            Me.Line8.X2 = 2.054188!
            Me.Line8.Y1 = 0.7569444!
            Me.Line8.Y2 = 1.006944!
            '
            'Line9
            '
            Me.Line9.Height = 0.25!
            Me.Line9.Left = 3.156551!
            Me.Line9.LineWeight = 1!
            Me.Line9.Name = "Line9"
            Me.Line9.Top = 0.7569444!
            Me.Line9.Width = 0!
            Me.Line9.X1 = 3.156551!
            Me.Line9.X2 = 3.156551!
            Me.Line9.Y1 = 0.7569444!
            Me.Line9.Y2 = 1.006944!
            '
            'Line10
            '
            Me.Line10.Height = 0.25!
            Me.Line10.Left = 3.707732!
            Me.Line10.LineWeight = 1!
            Me.Line10.Name = "Line10"
            Me.Line10.Top = 0.7569444!
            Me.Line10.Width = 0!
            Me.Line10.X1 = 3.707732!
            Me.Line10.X2 = 3.707732!
            Me.Line10.Y1 = 0.7569444!
            Me.Line10.Y2 = 1.006944!
            '
            'Line11
            '
            Me.Line11.Height = 0.25!
            Me.Line11.Left = 4.101433!
            Me.Line11.LineWeight = 1!
            Me.Line11.Name = "Line11"
            Me.Line11.Top = 0.7569444!
            Me.Line11.Width = 0!
            Me.Line11.X1 = 4.101433!
            Me.Line11.X2 = 4.101433!
            Me.Line11.Y1 = 0.7569444!
            Me.Line11.Y2 = 1.006944!
            '
            'Line12
            '
            Me.Line12.Height = 0.25!
            Me.Line12.Left = 6.621118!
            Me.Line12.LineWeight = 1!
            Me.Line12.Name = "Line12"
            Me.Line12.Top = 0.7569444!
            Me.Line12.Width = 0!
            Me.Line12.X1 = 6.621118!
            Me.Line12.X2 = 6.621118!
            Me.Line12.Y1 = 0.7569444!
            Me.Line12.Y2 = 1.006944!
            '
            'Label4
            '
            Me.Label4.Height = 0.1375!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 6.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-size: 9pt"
            Me.Label4.Text = "FACTURA"
            Me.Label4.Top = 0.57!
            Me.Label4.Width = 0.75!
            '
            'Line13
            '
            Me.Line13.Height = 0!
            Me.Line13.Left = 5.597497!
            Me.Line13.LineWeight = 1!
            Me.Line13.Name = "Line13"
            Me.Line13.Top = 0.5581255!
            Me.Line13.Width = 1.711608!
            Me.Line13.X1 = 5.597497!
            Me.Line13.X2 = 7.309104!
            Me.Line13.Y1 = 0.5581255!
            Me.Line13.Y2 = 0.5581255!
            '
            'lblSucursalDescripcion
            '
            Me.lblSucursalDescripcion.Height = 0.2!
            Me.lblSucursalDescripcion.HyperLink = Nothing
            Me.lblSucursalDescripcion.Left = 0.0625!
            Me.lblSucursalDescripcion.Name = "lblSucursalDescripcion"
            Me.lblSucursalDescripcion.Style = "text-align: center"
            Me.lblSucursalDescripcion.Text = "Sucursal :"
            Me.lblSucursalDescripcion.Top = 0.5625!
            Me.lblSucursalDescripcion.Width = 5.1875!
            '
            'Line14
            '
            Me.Line14.Height = 0.25!
            Me.Line14.Left = 1.660488!
            Me.Line14.LineWeight = 1!
            Me.Line14.Name = "Line14"
            Me.Line14.Top = 0.7569444!
            Me.Line14.Width = 0!
            Me.Line14.X1 = 1.660488!
            Me.Line14.X2 = 1.660488!
            Me.Line14.Y1 = 0.7569444!
            Me.Line14.Y2 = 1.006944!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 0.7086611!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-size: 9pt"
            Me.Label6.Text = "Folio SAP"
            Me.Label6.Top = 0.7874014!
            Me.Label6.Width = 0.8661417!
            '
            'txtFolio
            '
            Me.txtFolio.Height = 0.2!
            Me.txtFolio.Left = 0!
            Me.txtFolio.Name = "txtFolio"
            Me.txtFolio.Style = "text-align: center"
            Me.txtFolio.Text = "Folio"
            Me.txtFolio.Top = 0!
            Me.txtFolio.Width = 0.625!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 1.688!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "text-align: center"
            Me.txtSucursal.Text = "Suc"
            Me.txtSucursal.Top = 0!
            Me.txtSucursal.Width = 0.3543307!
            '
            'txtCodigo
            '
            Me.txtCodigo.Height = 0.2!
            Me.txtCodigo.Left = 2.077264!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Text = "Codigo"
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.122047!
            '
            'txtCantidad
            '
            Me.txtCantidad.Height = 0.2!
            Me.txtCantidad.Left = 3.270669!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat")
            Me.txtCantidad.Style = "text-align: right"
            Me.txtCantidad.Text = "Q"
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.4375!
            '
            'txtTalla
            '
            Me.txtTalla.Height = 0.2!
            Me.txtTalla.Left = 3.7225!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: right"
            Me.txtTalla.Text = "30.5"
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.375!
            '
            'txtImporte
            '
            Me.txtImporte.Height = 0.2!
            Me.txtImporte.Left = 4.1875!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right"
            Me.txtImporte.Text = "Importe"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.75!
            '
            'txtTipo
            '
            Me.txtTipo.Height = 0.2!
            Me.txtTipo.Left = 5.03937!
            Me.txtTipo.Name = "txtTipo"
            Me.txtTipo.Style = "text-align: center"
            Me.txtTipo.Text = "Dev"
            Me.txtTipo.Top = 0!
            Me.txtTipo.Width = 0.5231299!
            '
            'txtFechaFactura
            '
            Me.txtFechaFactura.Height = 0.2!
            Me.txtFechaFactura.Left = 5.75!
            Me.txtFechaFactura.Name = "txtFechaFactura"
            Me.txtFechaFactura.OutputFormat = resources.GetString("txtFechaFactura.OutputFormat")
            Me.txtFechaFactura.Style = "text-align: center"
            Me.txtFechaFactura.Text = "02/08/2005"
            Me.txtFechaFactura.Top = 0!
            Me.txtFechaFactura.Width = 0.75!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.Height = 0.2!
            Me.txtFolioFactura.Left = 6.535434!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: right"
            Me.txtFolioFactura.Text = "Folio"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 0.7145674!
            '
            'txtFolioSAP
            '
            Me.txtFolioSAP.Height = 0.2!
            Me.txtFolioSAP.Left = 0.7086611!
            Me.txtFolioSAP.Name = "txtFolioSAP"
            Me.txtFolioSAP.Style = "text-align: center"
            Me.txtFolioSAP.Text = "Folio SAP"
            Me.txtFolioSAP.Top = 0!
            Me.txtFolioSAP.Width = 0.944882!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.25!
            Me.Shape2.Left = 0!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 7.322833!
            '
            'Label5
            '
            Me.Label5.Height = 0.2!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 1.0625!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center"
            Me.Label5.Text = "TOTALES   :"
            Me.Label5.Top = 0.04!
            Me.Label5.Width = 0.9375!
            '
            'txtTotalImporte
            '
            Me.txtTotalImporte.Height = 0.1875!
            Me.txtTotalImporte.Left = 3.75!
            Me.txtTotalImporte.Name = "txtTotalImporte"
            Me.txtTotalImporte.OutputFormat = resources.GetString("txtTotalImporte.OutputFormat")
            Me.txtTotalImporte.Style = "text-align: right"
            Me.txtTotalImporte.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
            Me.txtTotalImporte.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtTotalImporte.Text = "Total"
            Me.txtTotalImporte.Top = 0.04!
            Me.txtTotalImporte.Width = 1.1875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.385417!
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
            CType(Me.lblFechaReporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblRango,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblPagina,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReviso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursalDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTipo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioSAP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
