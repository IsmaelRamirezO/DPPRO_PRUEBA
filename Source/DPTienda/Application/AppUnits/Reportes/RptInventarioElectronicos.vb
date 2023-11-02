Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.Reports.Inventario
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class RptInventarioElectronicos
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        Dim dtInventario As DataTable
        Dim oAlmacen As Almacen

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oDataGateway As New ReporteInventarioDataGateway(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        'Obtenemos el Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen & Space(1) & oAlmacen.Descripcion
        End If

        'Formateamos la fecha y la mostramos
        Me.txtFecha.Text = Format(Date.Now, "dd/MM/yyyy")

        'Obtenemos la informacion del inventario actual de inventarios
        dtInventario = oDataGateway.GetInventarioElectronicos(oAppContext.ApplicationConfiguration.Almacen).Tables(0).Copy

        'Total de Articulos
        If dtInventario Is Nothing Or dtInventario.Rows.Count Then
            Me.txtTotal.Text = dtInventario.Compute("SUM(Cantidad)", "")
        Else
            Me.txtTotal.Text = 0
        End If


        Me.DataSource = dtInventario

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
    Private txtSucursal As TextBox = Nothing
    Private Label4 As Label = Nothing
    Private Label1 As Label = Nothing
    Private txtFecha As TextBox = Nothing
    Private Label2 As Label = Nothing
    Private Shape9 As Shape = Nothing
    Private Label8 As Label = Nothing
    Private Label9 As Label = Nothing
    Private Label10 As Label = Nothing
    Private Label11 As Label = Nothing
    Private txtCodigo As TextBox = Nothing
    Private txtProducto As TextBox = Nothing
    Private txtCantidad As TextBox = Nothing
    Private txtMarca As TextBox = Nothing
    Private Shape10 As Shape = Nothing
    Private Label12 As Label = Nothing
    Private txtTotal As TextBox = Nothing
    Private Label13 As Label = Nothing
    Private TextBox1 As TextBox = Nothing
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptInventarioElectronicos))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.ReportHeader = New DataDynamics.ActiveReports.ReportHeader()
            Me.ReportFooter = New DataDynamics.ActiveReports.ReportFooter()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
            Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Shape9 = New DataDynamics.ActiveReports.Shape()
            Me.Label8 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label10 = New DataDynamics.ActiveReports.Label()
            Me.Label11 = New DataDynamics.ActiveReports.Label()
            Me.txtCodigo = New DataDynamics.ActiveReports.TextBox()
            Me.txtProducto = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtMarca = New DataDynamics.ActiveReports.TextBox()
            Me.Shape10 = New DataDynamics.ActiveReports.Shape()
            Me.Label12 = New DataDynamics.ActiveReports.Label()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.TextBox1 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtProducto,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtMarca,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtProducto, Me.txtCantidad, Me.txtMarca})
            Me.Detail.Height = 0.3125!
            Me.Detail.Name = "Detail"
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.txtSucursal, Me.Label4, Me.Label1, Me.txtFecha, Me.Label2})
            Me.ReportHeader.Height = 0.6875!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'ReportFooter
            '
            Me.ReportFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label13, Me.TextBox1})
            Me.ReportFooter.Height = 0.3125!
            Me.ReportFooter.Name = "ReportFooter"
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
            Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape9, Me.Label8, Me.Label9, Me.Label10, Me.Label11})
            Me.GroupHeader1.Height = 0.3125!
            Me.GroupHeader1.Name = "GroupHeader1"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape10, Me.Label12, Me.txtTotal})
            Me.GroupFooter1.Height = 0.3222222!
            Me.GroupFooter1.Name = "GroupFooter1"
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
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.84375!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt"
            Me.Label1.Text = "INVENTARIO ACTUAL DE ELECTRÓNICOS"
            Me.Label1.Top = 0.0625!
            Me.Label1.Width = 2.8125!
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
            'Shape9
            '
            Me.Shape9.Height = 0.3125!
            Me.Shape9.Left = 0!
            Me.Shape9.LineWeight = 2!
            Me.Shape9.Name = "Shape9"
            Me.Shape9.RoundingRadius = 9.999999!
            Me.Shape9.Top = 0!
            Me.Shape9.Width = 6.3125!
            '
            'Label8
            '
            Me.Label8.Height = 0.1875!
            Me.Label8.HyperLink = Nothing
            Me.Label8.Left = 5.375!
            Me.Label8.Name = "Label8"
            Me.Label8.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial"
            Me.Label8.Text = "Cantidad"
            Me.Label8.Top = 0.0625!
            Me.Label8.Width = 0.8125!
            '
            'Label9
            '
            Me.Label9.Height = 0.1875!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 4!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial"
            Me.Label9.Text = "Marca"
            Me.Label9.Top = 0.0625!
            Me.Label9.Width = 1.0625!
            '
            'Label10
            '
            Me.Label10.Height = 0.1875!
            Me.Label10.HyperLink = Nothing
            Me.Label10.Left = 1.875!
            Me.Label10.Name = "Label10"
            Me.Label10.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial"
            Me.Label10.Text = "Producto"
            Me.Label10.Top = 0.0625!
            Me.Label10.Width = 1.8125!
            '
            'Label11
            '
            Me.Label11.Height = 0.1875!
            Me.Label11.HyperLink = Nothing
            Me.Label11.Left = 0.1302083!
            Me.Label11.Name = "Label11"
            Me.Label11.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial"
            Me.Label11.Text = "Código"
            Me.Label11.Top = 0.0625!
            Me.Label11.Width = 1.4375!
            '
            'txtCodigo
            '
            Me.txtCodigo.DataField = "Codigo"
            Me.txtCodigo.Height = 0.1875!
            Me.txtCodigo.Left = 0.125!
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.Style = "font-weight: normal; font-size: 8.25pt"
            Me.txtCodigo.Top = 0.0625!
            Me.txtCodigo.Width = 1.6875!
            '
            'txtProducto
            '
            Me.txtProducto.DataField = "Producto"
            Me.txtProducto.Height = 0.1875!
            Me.txtProducto.Left = 1.875!
            Me.txtProducto.Name = "txtProducto"
            Me.txtProducto.Style = "font-size: 8.25pt"
            Me.txtProducto.Top = 0.0625!
            Me.txtProducto.Width = 2!
            '
            'txtCantidad
            '
            Me.txtCantidad.DataField = "Cantidad"
            Me.txtCantidad.Height = 0.1875!
            Me.txtCantidad.Left = 5.375!
            Me.txtCantidad.Name = "txtCantidad"
            Me.txtCantidad.Style = "text-align: center; font-size: 8.25pt"
            Me.txtCantidad.Top = 0.0625!
            Me.txtCantidad.Width = 0.8125!
            '
            'txtMarca
            '
            Me.txtMarca.DataField = "Marca"
            Me.txtMarca.Height = 0.1875!
            Me.txtMarca.Left = 4!
            Me.txtMarca.Name = "txtMarca"
            Me.txtMarca.Style = "text-align: left; font-size: 8.25pt"
            Me.txtMarca.Top = 0.0625!
            Me.txtMarca.Width = 1.3125!
            '
            'Shape10
            '
            Me.Shape10.Height = 0.3125!
            Me.Shape10.Left = 0!
            Me.Shape10.LineWeight = 2!
            Me.Shape10.Name = "Shape10"
            Me.Shape10.RoundingRadius = 9.999999!
            Me.Shape10.Top = 0!
            Me.Shape10.Width = 6.3125!
            '
            'Label12
            '
            Me.Label12.Height = 0.1875!
            Me.Label12.HyperLink = Nothing
            Me.Label12.Left = 4!
            Me.Label12.Name = "Label12"
            Me.Label12.Style = "color: Black; ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9."& _ 
                "75pt; font-family: Arial; vertical-align: middle"
            Me.Label12.Text = "Total Electrónicos:"
            Me.Label12.Top = 0.0625!
            Me.Label12.Width = 1.375!
            '
            'txtTotal
            '
            Me.txtTotal.Height = 0.1875!
            Me.txtTotal.Left = 5.375!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.Style = "text-align: center; font-size: 9.75pt"
            Me.txtTotal.Top = 0.0625!
            Me.txtTotal.Width = 0.8125!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 2.630208!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = "font-size: 8.25pt"
            Me.Label13.Text = "Página:"
            Me.Label13.Top = 0.0625!
            Me.Label13.Width = 0.5118113!
            '
            'TextBox1
            '
            Me.TextBox1.Height = 0.2!
            Me.TextBox1.Left = 3.18139!
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Style = "text-align: center; font-size: 8.25pt"
            Me.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox1.Top = 0.0625!
            Me.TextBox1.Width = 0.5113187!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.322917!
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
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label8,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodigo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtProducto,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtMarca,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        End Sub

#End Region
End Class
