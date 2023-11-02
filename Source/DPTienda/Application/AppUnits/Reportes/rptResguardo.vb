Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptResguardo

    Inherits DataDynamics.ActiveReports.ActiveReport

    Public Sub New(ByVal Detalle As DataTable, ByVal OrdenCompra As String)
        MyBase.New()
        InitializeComponent()

        ' Seteamos cabecera
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion
        Else
            txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen
        End If
        txtFecha.Text = Format(Date.Now, "dd/MM/yyyy")

        If OrdenCompra.Trim = "" OrElse OrdenCompra.Trim = "0000000000" Then
            ' Reporte
            Me.lblTitulo.Text = "REPORTE DE MATERIALES EN RESGUARDO DE EMT"
            Me.txtOrdenCompra.Visible = False
            Me.lblOrdenCompra.Visible = False
        Else
            ' Salida de resguardo
            Me.lblTitulo.Text = "REPORTE DE SALIDA DE MATERIALES EN RESGUARDO DE EMT"
            Me.txtOrdenCompra.Text = OrdenCompra.Trim
        End If

        'Seteamos detalle
        Me.DataSource = Detalle

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents GroupHeader1 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter1 As GroupFooter = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
    Private Shape1 As Shape = Nothing
    Private lblTitulo As Label = Nothing
    Private Label13 As Label = Nothing
    Private txtSucursal As TextBox = Nothing
    Private txtFecha As TextBox = Nothing
    Private TextBox10 As TextBox = Nothing
    Private TextBox11 As TextBox = Nothing
    Private Label31 As Label = Nothing
    Private txtOrdenCompra As TextBox = Nothing
    Private lblOrdenCompra As Label = Nothing
    Private lblCodigo As Label = Nothing
    Private lblDescripcion As Label = Nothing
    Private lblCantidad As Label = Nothing
    Private lblTalla As Label = Nothing
    Private Label33 As Label = Nothing
    Private Label34 As Label = Nothing
    Private txtCodigo As Label = Nothing
    Private txtDescripcion As Label = Nothing
    Private txtCantidad As Label = Nothing
    Private txtTalla As Label = Nothing
    Private txtOrden As Label = Nothing
    Private txtFechaIngreso As Label = Nothing
    Private Shape5 As Shape = Nothing
    Private xtTotal As TextBox = Nothing
    Private Label30 As Label = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptResguardo))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.Label31 = New DataDynamics.ActiveReports.Label()
            Me.txtOrdenCompra = New DataDynamics.ActiveReports.TextBox()
            Me.lblOrdenCompra = New DataDynamics.ActiveReports.Label()
            Me.lblCodigo = New DataDynamics.ActiveReports.Label()
            Me.lblDescripcion = New DataDynamics.ActiveReports.Label()
            Me.lblCantidad = New DataDynamics.ActiveReports.Label()
            Me.lblTalla = New DataDynamics.ActiveReports.Label()
            Me.Label33 = New DataDynamics.ActiveReports.Label()
            Me.Label34 = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.Label()
            Me.txtDescripcion = New DataDynamics.ActiveReports.Label()
            Me.txtCantidad = New DataDynamics.ActiveReports.Label()
            Me.txtTalla = New DataDynamics.ActiveReports.Label()
            Me.txtOrden = New DataDynamics.ActiveReports.Label()
            Me.txtFechaIngreso = New DataDynamics.ActiveReports.Label()
            Me.Shape5 = New DataDynamics.ActiveReports.Shape()
            Me.xtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label30 = New DataDynamics.ActiveReports.Label()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrdenCompra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblOrdenCompra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtOrden,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaIngreso,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.xtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtDescripcion, Me.txtCantidad, Me.txtTalla, Me.txtOrden, Me.txtFechaIngreso})
            Me.Detail.Height = 0.1875!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblTitulo, Me.Label13, Me.txtSucursal, Me.txtFecha, Me.TextBox10, Me.TextBox11, Me.Label31, Me.txtOrdenCompra, Me.lblOrdenCompra})
            Me.ReportHeader.Height = 0.71875!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape5, Me.xtTotal, Me.Label30})
            Me.ReportFooter.Height = 0.25!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCodigo, Me.lblDescripcion, Me.lblCantidad, Me.lblTalla, Me.Label33, Me.Label34})
            Me.PageHeader.Height = 0.2076389!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'GroupHeader1
            '
            Me.GroupHeader1.DataField = "Folio"
            Me.GroupHeader1.Height = 0!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Height = 0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.7086611!
            Me.Shape1.Left = 0!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 7.637798!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.2!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1.851563!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt"
            Me.lblTitulo.Text = "REPORTE DE SALIDA DE MATERIALES EN RESGUARDO DE EMT"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 4.015625!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 2.146776!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label13.Text = "Sucursal:"
            Me.Label13.Top = 0.4375!
            Me.Label13.Width = 0.6299212!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.771776!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "font-size: 8.25pt"
            Me.txtSucursal.Top = 0.4375!
            Me.txtSucursal.Width = 2.800196!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Style = "font-size: 8.25pt"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 0.8154528!
            '
            'TextBox10
            '
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 7!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "font-size: 8.25pt"
            Me.TextBox10.Text = "Pág."
            Me.TextBox10.Top = 0.0625!
            Me.TextBox10.Width = 0.2987203!
            '
            'TextBox11
            '
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 7.3125!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "font-size: 8.25pt"
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox11.Text = "100"
            Me.TextBox11.Top = 0.0625!
            Me.TextBox11.Width = 0.2362203!
            '
            'Label31
            '
            Me.Label31.Height = 0.2!
            Me.Label31.HyperLink = Nothing
            Me.Label31.Left = 0.0625!
            Me.Label31.Name = "Label31"
            Me.Label31.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.Label31.Text = "Fecha:"
            Me.Label31.Top = 0.0625!
            Me.Label31.Width = 0.4375!
            '
            'txtOrdenCompra
            '
            Me.txtOrdenCompra.Height = 0.2!
            Me.txtOrdenCompra.Left = 1.1875!
            Me.txtOrdenCompra.Name = "txtOrdenCompra"
            Me.txtOrdenCompra.Style = "font-size: 8.25pt"
            Me.txtOrdenCompra.Text = "0000000000"
            Me.txtOrdenCompra.Top = 0.4375!
            Me.txtOrdenCompra.Width = 0.6875!
            '
            'lblOrdenCompra
            '
            Me.lblOrdenCompra.Height = 0.2!
            Me.lblOrdenCompra.HyperLink = Nothing
            Me.lblOrdenCompra.Left = 0.0625!
            Me.lblOrdenCompra.Name = "lblOrdenCompra"
            Me.lblOrdenCompra.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt"
            Me.lblOrdenCompra.Text = "Orden de Compra:"
            Me.lblOrdenCompra.Top = 0.4375!
            Me.lblOrdenCompra.Width = 1.125!
            '
            'lblCodigo
            '
            Me.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCodigo.Height = 0.1875!
            Me.lblCodigo.HyperLink = Nothing
            Me.lblCodigo.Left = 1.25!
            Me.lblCodigo.Name = "lblCodigo"
            Me.lblCodigo.Style = "font-weight: bold; font-size: 9pt"
            Me.lblCodigo.Text = " Código"
            Me.lblCodigo.Top = 0!
            Me.lblCodigo.Width = 1.4375!
            '
            'lblDescripcion
            '
            Me.lblDescripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblDescripcion.Height = 0.1875!
            Me.lblDescripcion.HyperLink = Nothing
            Me.lblDescripcion.Left = 2.6875!
            Me.lblDescripcion.Name = "lblDescripcion"
            Me.lblDescripcion.Style = "font-weight: bold; font-size: 9pt"
            Me.lblDescripcion.Text = " Descripción"
            Me.lblDescripcion.Top = 0!
            Me.lblDescripcion.Width = 2.0625!
            '
            'lblCantidad
            '
            Me.lblCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblCantidad.Height = 0.1875!
            Me.lblCantidad.HyperLink = Nothing
            Me.lblCantidad.Left = 6.9375!
            Me.lblCantidad.Name = "lblCantidad"
            Me.lblCantidad.Style = "text-align: center; font-weight: bold; font-size: 9pt"
            Me.lblCantidad.Text = "Cantidad"
            Me.lblCantidad.Top = 0!
            Me.lblCantidad.Width = 0.6875!
            '
            'lblTalla
            '
            Me.lblTalla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.lblTalla.Height = 0.1875!
            Me.lblTalla.HyperLink = Nothing
            Me.lblTalla.Left = 6.3125!
            Me.lblTalla.Name = "lblTalla"
            Me.lblTalla.Style = "text-align: center; font-weight: bold; font-size: 9pt"
            Me.lblTalla.Text = "Talla"
            Me.lblTalla.Top = 0!
            Me.lblTalla.Width = 0.625!
            '
            'Label33
            '
            Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label33.Height = 0.1875!
            Me.Label33.HyperLink = Nothing
            Me.Label33.Left = 0!
            Me.Label33.Name = "Label33"
            Me.Label33.Style = "font-weight: bold; font-size: 9pt"
            Me.Label33.Text = " No Orden"
            Me.Label33.Top = 0!
            Me.Label33.Width = 1.25!
            '
            'Label34
            '
            Me.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
            Me.Label34.Height = 0.1875!
            Me.Label34.HyperLink = Nothing
            Me.Label34.Left = 4.75!
            Me.Label34.Name = "Label34"
            Me.Label34.Style = "font-weight: bold; font-size: 9pt"
            Me.Label34.Text = "Fecha de Ingreso"
            Me.Label34.Top = 0!
            Me.Label34.Width = 1.5625!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.HyperLink = Nothing
            Me.txtCodigo.Left = 1.25!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "text-align: left; font-weight: normal; font-size: 9pt"
            Me.txtCodigo.Text = ""
            Me.txtCodigo.Top = 0!
            Me.txtCodigo.Width = 1.4375!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.DataField = "Descripcion"
            Me.txtDescripcion.Height = 0.1875!
            Me.txtDescripcion.HyperLink = Nothing
            Me.txtDescripcion.Left = 2.6875!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Style = "font-weight: normal; font-size: 9pt"
            Me.txtDescripcion.Text = ""
            Me.txtDescripcion.Top = 0!
            Me.txtDescripcion.Width = 2.0625!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.188!
            Me.txtCantidad.HyperLink = Nothing
            Me.txtCantidad.Left = 6.9375!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-weight: normal; font-size: 9pt"
            Me.txtCantidad.Text = ""
            Me.txtCantidad.Top = 0!
            Me.txtCantidad.Width = 0.688!
            '
            'txtTalla
            '
            Me.txtTalla.DataField = "Numero"
            Me.txtTalla.Height = 0.188!
            Me.txtTalla.HyperLink = Nothing
            Me.txtTalla.Left = 6.3125!
            Me.txtTalla.Name = "txtTalla"
            Me.txtTalla.Style = "text-align: center; font-weight: normal; font-size: 9pt"
            Me.txtTalla.Text = ""
            Me.txtTalla.Top = 0!
            Me.txtTalla.Width = 0.625!
            '
            'txtOrden
            '
            Me.txtOrden.DataField = "Orden"
            Me.txtOrden.Height = 0.1875!
            Me.txtOrden.HyperLink = Nothing
            Me.txtOrden.Left = 0!
            Me.txtOrden.Name = "txtOrden"
            Me.txtOrden.Style = "text-align: left; font-weight: normal; font-size: 9pt"
            Me.txtOrden.Text = ""
            Me.txtOrden.Top = 0!
            Me.txtOrden.Width = 1.25!
            '
            'txtFechaIngreso
            '
            Me.txtFechaIngreso.DataField = "FechaCreacion"
            Me.txtFechaIngreso.Height = 0.1875!
            Me.txtFechaIngreso.HyperLink = Nothing
            Me.txtFechaIngreso.Left = 4.75!
            Me.txtFechaIngreso.Name = "txtFechaIngreso"
            Me.txtFechaIngreso.Style = "font-weight: normal; font-size: 9pt"
            Me.txtFechaIngreso.Text = ""
            Me.txtFechaIngreso.Top = 0!
            Me.txtFechaIngreso.Width = 1.5625!
            '
            'Shape5
            '
            Me.Shape5.Height = 0.2130906!
            Me.Shape5.Left = 0!
            Me.Shape5.Name = "Shape5"
            Me.Shape5.RoundingRadius = 9.999999!
            Me.Shape5.Top = 0!
            Me.Shape5.Width = 7.637798!
            '
            'xtTotal
            '
            Me.xtTotal.DataField = "Cantidad"
            Me.xtTotal.Height = 0.2!
            Me.xtTotal.Left = 6.9375!
            Me.xtTotal.Name = "xtTotal"
            Me.xtTotal.OutputFormat = resources.GetString("xtTotal.OutputFormat")
            Me.xtTotal.Style = "text-align: center; font-weight: normal; font-size: 9pt"
            Me.xtTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.xtTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.xtTotal.Text = "999"
            Me.xtTotal.Top = 0!
            Me.xtTotal.Width = 0.6875!
            '
            'Label30
            '
            Me.Label30.Height = 0.2!
            Me.Label30.HyperLink = Nothing
            Me.Label30.Left = 0.0625!
            Me.Label30.Name = "Label30"
            Me.Label30.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt"
            Me.Label30.Text = "Total"
            Me.Label30.Top = 0!
            Me.Label30.Width = 0.375!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Bottom = 0.39375!
            Me.PageSettings.Margins.Left = 0.39375!
            Me.PageSettings.Margins.Right = 0.39375!
            Me.PageSettings.Margins.Top = 0.39375!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 7.71875!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.GroupHeader1)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter1)
            Me.Sections.Add(Me.PageFooter)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label31,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrdenCompra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblOrdenCompra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label33,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label34,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTalla,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtOrden,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaIngreso,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.xtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label30,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region


End Class
