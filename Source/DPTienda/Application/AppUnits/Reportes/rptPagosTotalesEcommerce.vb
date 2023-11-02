Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptPagosTotalesEcommerce
    Inherits DataDynamics.ActiveReports.ActiveReport

    Private dtPagos As DataTable

    Public Sub New(ByRef ds As DataSet, ByVal CodAlmacen As String, ByVal datFechaInicio As Date, ByVal datFechaFin As Date)
        MyBase.New()
        InitializeComponent()

        'Encabezado :

        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        Me.txtSucursal.Text = oAlmacen.ID & "     " & oAlmacen.Descripcion

        oCatalogoAlmacenMgr = Nothing
        oAlmacen = Nothing

        Me.txtFecha.Text = Format(Date.Now, "dd-MM-yyyy")

        Me.txtCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        Me.txtFechaDe.Text = Format(datFechaInicio, "dd-MM-yyyy")

        Me.txtFechaAl.Text = Format(datFechaFin, "dd-MM-yyyy")

        'Detalle :
        dtPagos = ds.Tables(0).Copy
        Me.DataSource = ds.Tables(0)

        'Pie :

        If ds.Tables(0).Rows.Count > 0 Then
            Me.tbTotalImporte.Text = Format(IIf(IsDBNull(ds.Tables(0).Compute("SUM(TotalPago)", "")), 0, ds.Tables(0).Compute("SUM(TotalPago)", "")), "Currency")
        Else
            Me.tbTotalImporte.Text = Format(0, "Currency")
        End If

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private txtSucursal As Label = Nothing
	Private txtFechaAl As Label = Nothing
	Private lblFechaAl As Label = Nothing
	Private txtFechaDe As Label = Nothing
	Private lblReportTitle As Label = Nothing
	Private lblSucursal As Label = Nothing
	Private txtCaja As Label = Nothing
	Private txtFecha As Label = Nothing
	Private lblFecha As Label = Nothing
	Private lblCaja As Label = Nothing
	Private Shape1 As Shape = Nothing
	Private lblNoPedido As Label = Nothing
	Private lblFormaPago As Label = Nothing
	Private lblImporte As Label = Nothing
	Private lblUsuario As Label = Nothing
	Private lblFieldFecha As Label = Nothing
	Private lblMontoPago As Label = Nothing
	Private txtNoPedido As TextBox = Nothing
	Private txtImporte As TextBox = Nothing
	Private txtUsuario As TextBox = Nothing
	Private txtFieldFecha As TextBox = Nothing
	Private FormasPagos As SubReport = Nothing
	Private tbTotalImporte As TextBox = Nothing
	Private Shape3 As Shape = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPagosTotalesEcommerce))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.txtSucursal = New DataDynamics.ActiveReports.Label()
            Me.txtFechaAl = New DataDynamics.ActiveReports.Label()
            Me.lblFechaAl = New DataDynamics.ActiveReports.Label()
            Me.txtFechaDe = New DataDynamics.ActiveReports.Label()
            Me.lblReportTitle = New DataDynamics.ActiveReports.Label()
            Me.lblSucursal = New DataDynamics.ActiveReports.Label()
            Me.txtCaja = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.Label()
            Me.lblFecha = New DataDynamics.ActiveReports.Label()
            Me.lblCaja = New DataDynamics.ActiveReports.Label()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblNoPedido = New DataDynamics.ActiveReports.Label()
            Me.lblFormaPago = New DataDynamics.ActiveReports.Label()
            Me.lblImporte = New DataDynamics.ActiveReports.Label()
            Me.lblUsuario = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFecha = New DataDynamics.ActiveReports.Label()
            Me.lblMontoPago = New DataDynamics.ActiveReports.Label()
            Me.txtNoPedido = New DataDynamics.ActiveReports.TextBox()
            Me.txtImporte = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtFieldFecha = New DataDynamics.ActiveReports.TextBox()
            Me.FormasPagos = New DataDynamics.ActiveReports.SubReport()
            Me.tbTotalImporte = New DataDynamics.ActiveReports.TextBox()
            Me.Shape3 = New DataDynamics.ActiveReports.Shape()
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblNoPedido,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblMontoPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNoPedido,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFieldFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNoPedido, Me.txtImporte, Me.txtUsuario, Me.txtFieldFecha, Me.FormasPagos})
            Me.Detail.Height = 0.1763889!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSucursal, Me.txtFechaAl, Me.lblFechaAl, Me.txtFechaDe, Me.lblReportTitle, Me.lblSucursal, Me.txtCaja, Me.txtFecha, Me.lblFecha, Me.lblCaja, Me.Shape1})
            Me.ReportHeader.Height = 0.65625!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbTotalImporte, Me.Shape3})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblNoPedido, Me.lblFormaPago, Me.lblImporte, Me.lblUsuario, Me.lblFieldFecha, Me.lblMontoPago})
            Me.GroupHeader1.Height = 0.1979167!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.1811025!
            Me.txtSucursal.HyperLink = Nothing
            Me.txtSucursal.Left = 0.6875007!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtSucursal.Text = "LblSucursal"
            Me.txtSucursal.Top = 0.375!
            Me.txtSucursal.Width = 3.448326!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.1811025!
            Me.txtFechaAl.HyperLink = Nothing
            Me.txtFechaAl.Left = 2.9375!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFechaAl.Text = ""
            Me.txtFechaAl.Top = 0.1875!
            Me.txtFechaAl.Width = 0.9685042!
            '
            'lblFechaAl
            '
            Me.lblFechaAl.Height = 0.1811025!
            Me.lblFechaAl.HyperLink = Nothing
            Me.lblFechaAl.Left = 2.625!
            Me.lblFechaAl.Name = "lblFechaAl"
            Me.lblFechaAl.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFechaAl.Text = "Al:"
            Me.lblFechaAl.Top = 0.1875!
            Me.lblFechaAl.Width = 0.2810042!
            '
            'txtFechaDe
            '
            Me.txtFechaDe.Height = 0.1811025!
            Me.txtFechaDe.HyperLink = Nothing
            Me.txtFechaDe.Left = 1.625!
            Me.txtFechaDe.Name = "txtFechaDe"
            Me.txtFechaDe.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFechaDe.Text = "LblFechaDE"
            Me.txtFechaDe.Top = 0.1875!
            Me.txtFechaDe.Width = 0.9685042!
            '
            'lblReportTitle
            '
            Me.lblReportTitle.ClassName = "Heading1"
            Me.lblReportTitle.Height = 0.1875!
            Me.lblReportTitle.HyperLink = Nothing
            Me.lblReportTitle.Left = 1.75!
            Me.lblReportTitle.MultiLine = false
            Me.lblReportTitle.Name = "lblReportTitle"
            Me.lblReportTitle.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; white-space: nowrap; vert"& _ 
                "ical-align: middle"
            Me.lblReportTitle.Text = "Reporte de Pagos de Ecommerce"
            Me.lblReportTitle.Top = 0!
            Me.lblReportTitle.Width = 2.875!
            '
            'lblSucursal
            '
            Me.lblSucursal.Height = 0.1811025!
            Me.lblSucursal.HyperLink = Nothing
            Me.lblSucursal.Left = 0.125!
            Me.lblSucursal.Name = "lblSucursal"
            Me.lblSucursal.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblSucursal.Text = "Sucursal:"
            Me.lblSucursal.Top = 0.375!
            Me.lblSucursal.Width = 0.5625!
            '
            'txtCaja
            '
            Me.txtCaja.Height = 0.1811025!
            Me.txtCaja.HyperLink = Nothing
            Me.txtCaja.Left = 0.6250004!
            Me.txtCaja.Name = "txtCaja"
            Me.txtCaja.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtCaja.Text = "LblCaja"
            Me.txtCaja.Top = 0.1875!
            Me.txtCaja.Width = 0.6983264!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.1811025!
            Me.txtFecha.HyperLink = Nothing
            Me.txtFecha.Left = 0.625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: normal; font-size: "& _ 
                "8.25pt; font-family: Arial"
            Me.txtFecha.Text = "LblFecha"
            Me.txtFecha.Top = 0!
            Me.txtFecha.Width = 1.0625!
            '
            'lblFecha
            '
            Me.lblFecha.Height = 0.1811025!
            Me.lblFecha.HyperLink = Nothing
            Me.lblFecha.Left = 0.125!
            Me.lblFecha.Name = "lblFecha"
            Me.lblFecha.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFecha.Text = "Fecha:"
            Me.lblFecha.Top = 0!
            Me.lblFecha.Width = 0.5625!
            '
            'lblCaja
            '
            Me.lblCaja.Height = 0.1811025!
            Me.lblCaja.HyperLink = Nothing
            Me.lblCaja.Left = 0.125!
            Me.lblCaja.Name = "lblCaja"
            Me.lblCaja.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblCaja.Text = "Caja:"
            Me.lblCaja.Top = 0.1875!
            Me.lblCaja.Width = 0.5625!
            '
            'Shape1
            '
            Me.Shape1.Height = 0.625!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 5.5!
            '
            'lblNoPedido
            '
            Me.lblNoPedido.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNoPedido.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNoPedido.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNoPedido.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblNoPedido.Height = 0.188!
            Me.lblNoPedido.HyperLink = Nothing
            Me.lblNoPedido.Left = 0!
            Me.lblNoPedido.Name = "lblNoPedido"
            Me.lblNoPedido.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblNoPedido.Text = "No. Pedido"
            Me.lblNoPedido.Top = 0!
            Me.lblNoPedido.Width = 1.375!
            '
            'lblFormaPago
            '
            Me.lblFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFormaPago.Height = 0.1875!
            Me.lblFormaPago.HyperLink = Nothing
            Me.lblFormaPago.Left = 1.375!
            Me.lblFormaPago.Name = "lblFormaPago"
            Me.lblFormaPago.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFormaPago.Text = "Forma de Pago"
            Me.lblFormaPago.Top = 0!
            Me.lblFormaPago.Width = 0.875!
            '
            'lblImporte
            '
            Me.lblImporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblImporte.Height = 0.1875!
            Me.lblImporte.HyperLink = Nothing
            Me.lblImporte.Left = 3!
            Me.lblImporte.Name = "lblImporte"
            Me.lblImporte.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblImporte.Text = "Importe"
            Me.lblImporte.Top = 0!
            Me.lblImporte.Width = 0.8125!
            '
            'lblUsuario
            '
            Me.lblUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblUsuario.Height = 0.1875!
            Me.lblUsuario.HyperLink = Nothing
            Me.lblUsuario.Left = 3.8125!
            Me.lblUsuario.Name = "lblUsuario"
            Me.lblUsuario.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblUsuario.Text = "Usuario"
            Me.lblUsuario.Top = 0!
            Me.lblUsuario.Width = 0.8020833!
            '
            'lblFieldFecha
            '
            Me.lblFieldFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblFieldFecha.Height = 0.1875!
            Me.lblFieldFecha.HyperLink = Nothing
            Me.lblFieldFecha.Left = 4.625!
            Me.lblFieldFecha.Name = "lblFieldFecha"
            Me.lblFieldFecha.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblFieldFecha.Text = "Fecha"
            Me.lblFieldFecha.Top = 0!
            Me.lblFieldFecha.Width = 0.875!
            '
            'lblMontoPago
            '
            Me.lblMontoPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMontoPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMontoPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMontoPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblMontoPago.Height = 0.1875!
            Me.lblMontoPago.HyperLink = Nothing
            Me.lblMontoPago.Left = 2.25!
            Me.lblMontoPago.Name = "lblMontoPago"
            Me.lblMontoPago.Style = "text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblMontoPago.Text = "Monto"
            Me.lblMontoPago.Top = 0!
            Me.lblMontoPago.Width = 0.75!
            '
            'txtNoPedido
            '
            Me.txtNoPedido.DataField = "NumOrden"
            Me.txtNoPedido.Height = 0.188!
            Me.txtNoPedido.Left = 0!
            Me.txtNoPedido.Name = "txtNoPedido"
            Me.txtNoPedido.Style = "font-size: 8.25pt"
            Me.txtNoPedido.Top = 0!
            Me.txtNoPedido.Width = 1.375!
            '
            'txtImporte
            '
            Me.txtImporte.DataField = "TotalPago"
            Me.txtImporte.Height = 0.1875!
            Me.txtImporte.Left = 3!
            Me.txtImporte.Name = "txtImporte"
            Me.txtImporte.OutputFormat = resources.GetString("txtImporte.OutputFormat")
            Me.txtImporte.Style = "text-align: right; font-size: 8.25pt"
            Me.txtImporte.Top = 0!
            Me.txtImporte.Width = 0.8125!
            '
            'txtUsuario
            '
            Me.txtUsuario.DataField = "Usuario"
            Me.txtUsuario.Height = 0.188!
            Me.txtUsuario.Left = 3.8125!
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Style = "text-align: center; font-size: 8.25pt"
            Me.txtUsuario.Top = 0!
            Me.txtUsuario.Width = 0.802!
            '
            'txtFieldFecha
            '
            Me.txtFieldFecha.DataField = "Fecha"
            Me.txtFieldFecha.Height = 0.1875!
            Me.txtFieldFecha.Left = 4.625!
            Me.txtFieldFecha.Name = "txtFieldFecha"
            Me.txtFieldFecha.OutputFormat = resources.GetString("txtFieldFecha.OutputFormat")
            Me.txtFieldFecha.Style = "font-size: 8.25pt"
            Me.txtFieldFecha.Top = 0!
            Me.txtFieldFecha.Width = 0.875!
            '
            'FormasPagos
            '
            Me.FormasPagos.CloseBorder = false
            Me.FormasPagos.Height = 0.188!
            Me.FormasPagos.Left = 1.625!
            Me.FormasPagos.Name = "FormasPagos"
            Me.FormasPagos.Report = Nothing
            Me.FormasPagos.Top = 0!
            Me.FormasPagos.Width = 1.375!
            '
            'tbTotalImporte
            '
            Me.tbTotalImporte.Height = 0.188!
            Me.tbTotalImporte.Left = 3!
            Me.tbTotalImporte.Name = "tbTotalImporte"
            Me.tbTotalImporte.OutputFormat = resources.GetString("tbTotalImporte.OutputFormat")
            Me.tbTotalImporte.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt"
            Me.tbTotalImporte.Top = 0!
            Me.tbTotalImporte.Width = 0.813!
            '
            'Shape3
            '
            Me.Shape3.Height = 0.1875!
            Me.Shape3.Left = 0!
            Me.Shape3.LineWeight = 2!
            Me.Shape3.Name = "Shape3"
            Me.Shape3.RoundingRadius = 9.999999!
            Me.Shape3.Top = 0!
            Me.Shape3.Width = 5.5!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.552083!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDe,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblReportTitle,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCaja,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblNoPedido,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblMontoPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNoPedido,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFieldFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbTotalImporte,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    '--------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/09/2014: Se cargan las formas de pago de cada pedido
    '--------------------------------------------------------------------------------------------

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format
        Dim oReporteFormapago As ReporteDetalleFormasPago
        Dim oRow() As DataRow
        If Not dtPagos Is Nothing Then
            If dtPagos.Rows.Count > 0 Then
                If txtNoPedido.Text.Trim() <> String.Empty Then
                    Dim otropagoid As Integer = CInt(Me.Fields("OtrosPagosID").Value)
                    oReporteFormapago = New ReporteDetalleFormasPago(otropagoid, 4) '(oDataRpt.FacturaID)
                    Me.FormasPagos.Report = oReporteFormapago
                End If
            End If
        End If
    End Sub
End Class
