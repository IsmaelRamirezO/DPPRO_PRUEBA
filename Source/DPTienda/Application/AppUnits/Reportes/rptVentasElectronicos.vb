Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptVentasElectronicos
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Fecha As DateTime)
        MyBase.New()
        InitializeComponent()

        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oFacturasMgr As New FacturaManager(oAppContext)
        Dim dtVentasElectronicos As DataTable
        Dim TotalVentas As Decimal

        '----------------------------------------------------------------------
        ' JNAVA (15.03.2016): Modificacion para mostrar datos de almacen
        '----------------------------------------------------------------------
        'Obtenemos el Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & Space(1) & oAlmacen.Descripcion
        End If
        '----------------------------------------------------------------------

        Me.txtFecha.Text = Format(Fecha, "dd/MM/yyyy")

        dtVentasElectronicos = oFacturasMgr.VentasElectronicosDelDia(Fecha.Date.ToShortDateString).Tables(0).Copy
        dtVentasElectronicos = FormatearVentasElectronicos(dtVentasElectronicos, TotalVentas)

        Me.txtTotal.Text = "$" & FormatNumber(TotalVentas, 2)

        Me.DataSource = dtVentasElectronicos

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents GroupHeader2 As GroupHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents GroupFooter2 As GroupFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private Label4 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private txtFecha As TextBox = Nothing
	Private Label2 As Label = Nothing
	Private Shape7 As Shape = Nothing
	Private lblUsuario As Label = Nothing
	Private lblFormaPago As Label = Nothing
	Private Label7 As Label = Nothing
	Private lblSerie As Label = Nothing
	Private lblProducto As Label = Nothing
	Private lblFieldFolio As Label = Nothing
	Private Label8 As Label = Nothing
	Private txtProducto As TextBox = Nothing
	Private txtNumeroSerie As TextBox = Nothing
	Private txtIMEI As TextBox = Nothing
	Private txtFormasPago As TextBox = Nothing
	Private txtUsuario As TextBox = Nothing
	Private txtFactura As TextBox = Nothing
	Private TextBox1 As TextBox = Nothing
	Private Shape8 As Shape = Nothing
	Private Label6 As Label = Nothing
	Private txtTotal As TextBox = Nothing
	Private Label13 As Label = Nothing
	Private TextBox2 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptVentasElectronicos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Shape7 = New DataDynamics.ActiveReports.Shape()
            Me.lblUsuario = New DataDynamics.ActiveReports.Label()
            Me.lblFormaPago = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.lblSerie = New DataDynamics.ActiveReports.Label()
            Me.lblProducto = New DataDynamics.ActiveReports.Label()
            Me.lblFieldFolio = New DataDynamics.ActiveReports.Label()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.txtProducto = New DataDynamics.ActiveReports.TextBox()
            Me.txtNumeroSerie = New DataDynamics.ActiveReports.TextBox()
            Me.txtIMEI = New DataDynamics.ActiveReports.TextBox()
            Me.txtFormasPago = New DataDynamics.ActiveReports.TextBox()
            Me.txtUsuario = New DataDynamics.ActiveReports.TextBox()
            Me.txtFactura = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape8 = New DataDynamics.ActiveReports.Shape()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.TextBox2 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblSerie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblProducto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtProducto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNumeroSerie,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtIMEI,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFormasPago,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtProducto, Me.txtNumeroSerie, Me.txtIMEI, Me.txtFormasPago, Me.txtUsuario, Me.txtFactura, Me.TextBox1})
            Me.Detail.Height = 0.3125!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.Label4, Me.txtSucursal, Me.txtFecha, Me.Label2})
            Me.ReportHeader.Height = 0.6763889!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label13, Me.TextBox2})
            Me.ReportFooter.Height = 0.3020833!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'GroupHeader2
            '
            Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape7, Me.lblUsuario, Me.lblFormaPago, Me.Label7, Me.lblSerie, Me.lblProducto, Me.lblFieldFolio, Me.Label8})
            Me.GroupHeader2.Height = 0.3222222!
            Me.GroupHeader2.Name = "GroupHeader2"
            '
            'GroupFooter2
            '
            Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape8, Me.Label6, Me.txtTotal})
            Me.GroupFooter2.Height = 0.3222222!
            Me.GroupFooter2.Name = "GroupFooter2"
            '
            'Shape1
            '
            Me.Shape1.Height = 0.6875!
            Me.Shape1.Left = 0!
            Me.Shape1.LineWeight = 2!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 6.3125!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.76575!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt"
            Me.Label1.Text = "RESUMEN DE VENTAS DE ELECTRÓNICOS"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.8125!
            '
            'Label4
            '
            Me.Label4.Height = 0.2!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 1.70325!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label4.Text = "Sucursal:"
            Me.Label4.Top = 0.375!
            Me.Label4.Width = 0.625!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 2.32825!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Style = "font-size: 8.25pt"
            Me.txtSucursal.Text = "TextBox1"
            Me.txtSucursal.Top = 0.375!
            Me.txtSucursal.Width = 2.3125!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.5625!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Text = "DD/MM/AAAA"
            Me.txtFecha.Top = 0.0625!
            Me.txtFecha.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.0625!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "font-weight: bold; font-size: 8.25pt"
            Me.Label2.Text = "Fecha:"
            Me.Label2.Top = 0.0625!
            Me.Label2.Width = 0.5!
            '
            'Shape7
            '
            Me.Shape7.Height = 0.3125!
            Me.Shape7.Left = 0!
            Me.Shape7.LineWeight = 2!
            Me.Shape7.Name = "Shape7"
            Me.Shape7.RoundingRadius = 9.999999!
            Me.Shape7.Top = 0!
            Me.Shape7.Width = 6.3125!
            '
            'lblUsuario
            '
            Me.lblUsuario.Height = 0.1875!
            Me.lblUsuario.HyperLink = Nothing
            Me.lblUsuario.Left = 5.6875!
            Me.lblUsuario.Name = "lblUsuario"
            Me.lblUsuario.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblUsuario.Text = "Usuario"
            Me.lblUsuario.Top = 0.0625!
            Me.lblUsuario.Width = 0.5625!
            '
            'lblFormaPago
            '
            Me.lblFormaPago.Height = 0.1875!
            Me.lblFormaPago.HyperLink = Nothing
            Me.lblFormaPago.Left = 4.25!
            Me.lblFormaPago.Name = "lblFormaPago"
            Me.lblFormaPago.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFormaPago.Text = "Formas Pago"
            Me.lblFormaPago.Top = 0.0625!
            Me.lblFormaPago.Width = 0.8125!
            '
            'Label7
            '
            Me.Label7.Height = 0.1875!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 3.125!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label7.Text = "IMEI"
            Me.Label7.Top = 0.0625!
            Me.Label7.Width = 1.125!
            '
            'lblSerie
            '
            Me.lblSerie.Height = 0.1875!
            Me.lblSerie.HyperLink = Nothing
            Me.lblSerie.Left = 1.6875!
            Me.lblSerie.Name = "lblSerie"
            Me.lblSerie.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblSerie.Text = "Número de Serie"
            Me.lblSerie.Top = 0.0625!
            Me.lblSerie.Width = 1.4375!
            '
            'lblProducto
            '
            Me.lblProducto.Height = 0.1875!
            Me.lblProducto.HyperLink = Nothing
            Me.lblProducto.Left = 0.75!
            Me.lblProducto.Name = "lblProducto"
            Me.lblProducto.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblProducto.Text = "Producto"
            Me.lblProducto.Top = 0.0625!
            Me.lblProducto.Width = 0.9375!
            '
            'lblFieldFolio
            '
            Me.lblFieldFolio.Height = 0.1875!
            Me.lblFieldFolio.HyperLink = Nothing
            Me.lblFieldFolio.Left = 0.0625!
            Me.lblFieldFolio.Name = "lblFieldFolio"
            Me.lblFieldFolio.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.lblFieldFolio.Text = "Factura:"
            Me.lblFieldFolio.Top = 0.0625!
            Me.lblFieldFolio.Width = 0.6875!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.0625!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8."& _ 
                "25pt; font-family: Arial"
            Me.Label8.Text = "Importe"
            Me.Label8.Top = 0.0625!
            Me.Label8.Width = 0.625!
            '
            'txtProducto
            '
            Me.txtProducto.DataField = "Producto"
            Me.txtProducto.Height = 0.1875!
            Me.txtProducto.Left = 0.75!
            Me.txtProducto.Name = "txtProducto"
            Me.txtProducto.Style = "font-size: 8.25pt"
            Me.txtProducto.Top = 0.0625!
            Me.txtProducto.Width = 0.9375!
            '
            'txtNumeroSerie
            '
            Me.txtNumeroSerie.DataField = "NumeroSerie"
            Me.txtNumeroSerie.Height = 0.1875!
            Me.txtNumeroSerie.Left = 1.6875!
            Me.txtNumeroSerie.Name = "txtNumeroSerie"
            Me.txtNumeroSerie.Style = "font-size: 8.25pt"
            Me.txtNumeroSerie.Top = 0.0625!
            Me.txtNumeroSerie.Width = 1.4375!
            '
            'txtIMEI
            '
            Me.txtIMEI.DataField = "IMEI"
            Me.txtIMEI.Height = 0.1875!
            Me.txtIMEI.Left = 3.125!
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Style = "font-size: 8.25pt"
            Me.txtIMEI.Top = 0.0625!
            Me.txtIMEI.Width = 1.125!
            '
            'txtFormasPago
            '
            Me.txtFormasPago.DataField = "FormaPago"
            Me.txtFormasPago.Height = 0.1875!
            Me.txtFormasPago.Left = 4.25!
            Me.txtFormasPago.Name = "txtFormasPago"
            Me.txtFormasPago.Style = "font-size: 8.25pt"
            Me.txtFormasPago.Top = 0.0625!
            Me.txtFormasPago.Width = 0.8125!
            '
            'txtUsuario
            '
            Me.txtUsuario.DataField = "Usuario"
            Me.txtUsuario.Height = 0.1875!
            Me.txtUsuario.Left = 5.6875!
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.Style = "font-size: 8.25pt"
            Me.txtUsuario.Top = 0.0625!
            Me.txtUsuario.Width = 0.5625!
            '
            'txtFactura
            '
            Me.txtFactura.DataField = "Factura"
            Me.txtFactura.Height = 0.1875!
            Me.txtFactura.Left = 0.0625!
            Me.txtFactura.Name = "txtFactura"
            Me.txtFactura.Style = "font-weight: normal; font-size: 8.25pt"
            Me.txtFactura.Top = 0.0625!
            Me.txtFactura.Width = 0.6875!
            '
            'TextBox1
            '
            Me.TextBox1.DataField = "Importe"
            Me.TextBox1.Height = 0.1875!
            Me.TextBox1.Left = 5.0625!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "font-weight: normal; font-size: 8.25pt"
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 0.625!
            '
            'Shape8
            '
            Me.Shape8.Height = 0.3125!
            Me.Shape8.Left = 0!
            Me.Shape8.LineWeight = 2!
            Me.Shape8.Name = "Shape8"
            Me.Shape8.RoundingRadius = 9.999999!
            Me.Shape8.Top = 0!
            Me.Shape8.Width = 6.3125!
            '
            'Label6
            '
            Me.Label6.Height = 0.1875!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 3.8125!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial; vertical-align: middle"
            Me.Label6.Text = "Importe Total:"
            Me.Label6.Top = 0.0625!
            Me.Label6.Width = 1!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.1875!
            Me.txtTotal.Left = 4.8125!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Style = "text-align: right; font-size: 9.75pt"
            Me.txtTotal.Top = 0.0625!
            Me.txtTotal.Width = 0.875!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 2.64075!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-size: 8.25pt"
            Me.Label13.Text = "Página:"
            Me.Label13.Top = 0.0625!
            Me.Label13.Width = 0.5118113!
            '
            'TextBox2
            '
            Me.TextBox2.Height = 0.2!
            Me.TextBox2.Left = 3.191931!
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox2.Top = 0.0625!
            Me.TextBox2.Width = 0.5113187!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.343999!
            Me.Sections.Add(Me.ReportHeader)
            Me.Sections.Add(Me.GroupHeader2)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.GroupFooter2)
            Me.Sections.Add(Me.ReportFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFormaPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblSerie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblProducto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFieldFolio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtProducto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNumeroSerie,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtIMEI,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFormasPago,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUsuario,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Function FormatearVentasElectronicos(ByVal TablaVentasElectronicos As DataTable, ByRef TotalVentas As Decimal) As DataTable

        '-----------------------------------------------------------------------------------------------
        'JNAVA (28.01.2015): Si viene vacia la tabla con las ventas de elenctronicos, que se salga.
        '-----------------------------------------------------------------------------------------------
        If TablaVentasElectronicos Is Nothing Then
            TablaVentasElectronicos = CrearTablaVentasElectronicos()
        End If

        Dim dtReturn As DataTable = TablaVentasElectronicos.Clone
        Dim sNumeroSerie() As String
        Dim sIMEI() As String

        dtReturn.Columns.Remove("Cantidad")
        dtReturn.AcceptChanges()

        'Separamos el detalle
        For Each oRow As DataRow In TablaVentasElectronicos.Rows

            'Obtenemos los numeros de serie e IMEI de cada articulo
            sNumeroSerie = CStr(oRow!NumeroSerie).Remove(CStr(oRow!NumeroSerie).Length - 1, 1).Split(";")
            If CStr(oRow!IMEI) <> "" Then
                sIMEI = CStr(oRow!IMEI).Remove(CStr(oRow!IMEI).Length - 1, 1).Split(";")
            End If

            'En base a la cantidad de piezas por articulos...
            For cantidad As Integer = 1 To CInt(oRow!Cantidad)
                '...llenamos la tabla con las ventas de electronicos
                Dim oRowE As DataRow = dtReturn.NewRow()
                oRowE("Factura") = oRow!Factura
                oRowE("Material") = oRow!Material
                oRowE("Producto") = oRow!Producto
                oRowE("FormaPago") = oRow!FormaPago
                oRowE("NumeroSerie") = sNumeroSerie(cantidad - 1)
                If sIMEI Is Nothing Then
                    oRowE("IMEI") = ""
                Else
                    oRowE("IMEI") = sIMEI(cantidad - 1)
                End If
                oRowE("Usuario") = oRow!Usuario
                oRowE("Fecha") = oRow!Fecha
                oRowE("Importe") = FormatNumber(CDec(oRow!Importe), 2)
                dtReturn.Rows.Add(oRowE)
            Next

            'Sacamos el total de ventas
            TotalVentas += (oRow!Importe * CInt(oRow!Cantidad))

        Next

        dtReturn.AcceptChanges()

        Return dtReturn

    End Function

    Private Function CrearTablaVentasElectronicos() As DataTable

        'Creo mi datatable y columnas
        Dim dtVentasElectronicos As New DataTable
        dtVentasElectronicos.Columns.Add("Factura")
        dtVentasElectronicos.Columns.Add("Material")
        dtVentasElectronicos.Columns.Add("Producto")
        dtVentasElectronicos.Columns.Add("FormaPago")
        dtVentasElectronicos.Columns.Add("NumeroSerie")
        dtVentasElectronicos.Columns.Add("IMEI")
        dtVentasElectronicos.Columns.Add("Usuario")
        dtVentasElectronicos.Columns.Add("Fecha")
        dtVentasElectronicos.Columns.Add("Importe")
        dtVentasElectronicos.Columns.Add("Cantidad")

        Return dtVentasElectronicos

    End Function
End Class
