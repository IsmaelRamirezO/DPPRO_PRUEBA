Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class rptDeposito
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal ReferenciaTienda As String, ByVal ImporteTienda As Decimal, ByVal ReferenciaEcommerce As String, ByVal ImporteEcommerce As Decimal)
        MyBase.New()
        InitializeComponent()
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen

        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        Me.txtNombreTienda.Text = oAlmacen.ID & "     " & oAlmacen.Descripcion

        Me.txtVentaReferencia.Text = ReferenciaTienda

        Me.txtVentaCantidad.Text = Format(ImporteTienda, "C")

        Me.txtEcommerceReferencia.Text = ReferenciaEcommerce

        Me.txtCantidadEcommerce.Text = Format(ImporteEcommerce, "C")

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private lblTitulo As Label = Nothing
	Private lblFicha1 As Label = Nothing
	Private txtNombreTienda As TextBox = Nothing
	Private lblVentaConvenioCIEC As Label = Nothing
	Private txtVentaConvenioCIEC As TextBox = Nothing
	Private lblVentaReferencia As Label = Nothing
	Private txtVentaReferencia As TextBox = Nothing
	Private lblVentaCantidad As Label = Nothing
	Private txtVentaCantidad As TextBox = Nothing
	Private lblFicha2 As Label = Nothing
	Private lblEcommerceConvenio As Label = Nothing
	Private txtEcommerceConvenio As TextBox = Nothing
	Private lblEcommerceReferencia As Label = Nothing
	Private txtEcommerceReferencia As TextBox = Nothing
	Private lblEcommerceCantidad As Label = Nothing
	Private txtCantidadEcommerce As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDeposito))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.lblTitulo = New DataDynamics.ActiveReports.Label()
            Me.lblFicha1 = New DataDynamics.ActiveReports.Label()
            Me.txtNombreTienda = New DataDynamics.ActiveReports.TextBox()
            Me.lblVentaConvenioCIEC = New DataDynamics.ActiveReports.Label()
            Me.txtVentaConvenioCIEC = New DataDynamics.ActiveReports.TextBox()
            Me.lblVentaReferencia = New DataDynamics.ActiveReports.Label()
            Me.txtVentaReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.lblVentaCantidad = New DataDynamics.ActiveReports.Label()
            Me.txtVentaCantidad = New DataDynamics.ActiveReports.TextBox()
            Me.lblFicha2 = New DataDynamics.ActiveReports.Label()
            Me.lblEcommerceConvenio = New DataDynamics.ActiveReports.Label()
            Me.txtEcommerceConvenio = New DataDynamics.ActiveReports.TextBox()
            Me.lblEcommerceReferencia = New DataDynamics.ActiveReports.Label()
            Me.txtEcommerceReferencia = New DataDynamics.ActiveReports.TextBox()
            Me.lblEcommerceCantidad = New DataDynamics.ActiveReports.Label()
            Me.txtCantidadEcommerce = New DataDynamics.ActiveReports.TextBox()
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFicha1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVentaConvenioCIEC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVentaConvenioCIEC,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVentaReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVentaReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblVentaCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtVentaCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblFicha2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblEcommerceConvenio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEcommerceConvenio,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblEcommerceReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtEcommerceReferencia,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.lblEcommerceCantidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantidadEcommerce,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblTitulo, Me.lblFicha1, Me.txtNombreTienda, Me.lblVentaConvenioCIEC, Me.txtVentaConvenioCIEC, Me.lblVentaReferencia, Me.txtVentaReferencia, Me.lblVentaCantidad, Me.txtVentaCantidad, Me.lblFicha2, Me.lblEcommerceConvenio, Me.txtEcommerceConvenio, Me.lblEcommerceReferencia, Me.txtEcommerceReferencia, Me.lblEcommerceCantidad, Me.txtCantidadEcommerce})
            Me.PageHeader.Height = 3.40625!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 3.25!
            Me.Shape1.Left = 0.0625!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 5.3125!
            '
            'lblTitulo
            '
            Me.lblTitulo.Height = 0.375!
            Me.lblTitulo.HyperLink = Nothing
            Me.lblTitulo.Left = 1!
            Me.lblTitulo.Name = "lblTitulo"
            Me.lblTitulo.Style = "font-weight: bold; font-size: 18pt"
            Me.lblTitulo.Text = "FICHAS DE DEPÓSITO"
            Me.lblTitulo.Top = 0.0625!
            Me.lblTitulo.Width = 3.125!
            '
            'lblFicha1
            '
            Me.lblFicha1.Height = 0.25!
            Me.lblFicha1.HyperLink = Nothing
            Me.lblFicha1.Left = 0.3125!
            Me.lblFicha1.Name = "lblFicha1"
            Me.lblFicha1.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblFicha1.Text = "¦Ficha 1 Ventas de tienda"
            Me.lblFicha1.Top = 0.5!
            Me.lblFicha1.Width = 2.4375!
            '
            'txtNombreTienda
            '
            Me.txtNombreTienda.Height = 0.25!
            Me.txtNombreTienda.Left = 2.75!
            Me.txtNombreTienda.Name = "txtNombreTienda"
            Me.txtNombreTienda.Style = "font-size: 12.75pt"
            Me.txtNombreTienda.Top = 0.5!
            Me.txtNombreTienda.Width = 2.5625!
            '
            'lblVentaConvenioCIEC
            '
            Me.lblVentaConvenioCIEC.Height = 0.25!
            Me.lblVentaConvenioCIEC.HyperLink = Nothing
            Me.lblVentaConvenioCIEC.Left = 0.75!
            Me.lblVentaConvenioCIEC.Name = "lblVentaConvenioCIEC"
            Me.lblVentaConvenioCIEC.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblVentaConvenioCIEC.Text = "-Convenio CIEC:"
            Me.lblVentaConvenioCIEC.Top = 0.8125!
            Me.lblVentaConvenioCIEC.Width = 1.5625!
            '
            'txtVentaConvenioCIEC
            '
            Me.txtVentaConvenioCIEC.Height = 0.25!
            Me.txtVentaConvenioCIEC.Left = 2.3125!
            Me.txtVentaConvenioCIEC.Name = "txtVentaConvenioCIEC"
            Me.txtVentaConvenioCIEC.Style = "font-size: 14.25pt"
            Me.txtVentaConvenioCIEC.Text = "366632"
            Me.txtVentaConvenioCIEC.Top = 0.8125!
            Me.txtVentaConvenioCIEC.Width = 2.25!
            '
            'lblVentaReferencia
            '
            Me.lblVentaReferencia.Height = 0.25!
            Me.lblVentaReferencia.HyperLink = Nothing
            Me.lblVentaReferencia.Left = 0.75!
            Me.lblVentaReferencia.Name = "lblVentaReferencia"
            Me.lblVentaReferencia.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblVentaReferencia.Text = "-Referencia:"
            Me.lblVentaReferencia.Top = 1.0625!
            Me.lblVentaReferencia.Width = 1.25!
            '
            'txtVentaReferencia
            '
            Me.txtVentaReferencia.Height = 0.25!
            Me.txtVentaReferencia.Left = 2!
            Me.txtVentaReferencia.Name = "txtVentaReferencia"
            Me.txtVentaReferencia.Style = "font-size: 14.25pt"
            Me.txtVentaReferencia.Top = 1.0625!
            Me.txtVentaReferencia.Width = 2.5625!
            '
            'lblVentaCantidad
            '
            Me.lblVentaCantidad.Height = 0.25!
            Me.lblVentaCantidad.HyperLink = Nothing
            Me.lblVentaCantidad.Left = 0.75!
            Me.lblVentaCantidad.Name = "lblVentaCantidad"
            Me.lblVentaCantidad.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblVentaCantidad.Text = "-Cantidad a depositar:"
            Me.lblVentaCantidad.Top = 1.3125!
            Me.lblVentaCantidad.Width = 2.125!
            '
            'txtVentaCantidad
            '
            Me.txtVentaCantidad.Height = 0.25!
            Me.txtVentaCantidad.Left = 2.875!
            Me.txtVentaCantidad.Name = "txtVentaCantidad"
            Me.txtVentaCantidad.Style = "text-align: right; font-size: 14.25pt"
            Me.txtVentaCantidad.Top = 1.3125!
            Me.txtVentaCantidad.Width = 1.6875!
            '
            'lblFicha2
            '
            Me.lblFicha2.Height = 0.25!
            Me.lblFicha2.HyperLink = Nothing
            Me.lblFicha2.Left = 0.3125!
            Me.lblFicha2.Name = "lblFicha2"
            Me.lblFicha2.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblFicha2.Text = "¦Ficha 2 Pagos Ecommerce"
            Me.lblFicha2.Top = 1.875!
            Me.lblFicha2.Width = 2.75!
            '
            'lblEcommerceConvenio
            '
            Me.lblEcommerceConvenio.Height = 0.25!
            Me.lblEcommerceConvenio.HyperLink = Nothing
            Me.lblEcommerceConvenio.Left = 0.75!
            Me.lblEcommerceConvenio.Name = "lblEcommerceConvenio"
            Me.lblEcommerceConvenio.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblEcommerceConvenio.Text = "-Convenio:"
            Me.lblEcommerceConvenio.Top = 2.1875!
            Me.lblEcommerceConvenio.Width = 1!
            '
            'txtEcommerceConvenio
            '
            Me.txtEcommerceConvenio.Height = 0.25!
            Me.txtEcommerceConvenio.Left = 1.75!
            Me.txtEcommerceConvenio.Name = "txtEcommerceConvenio"
            Me.txtEcommerceConvenio.Style = "font-size: 14.25pt"
            Me.txtEcommerceConvenio.Text = "826332"
            Me.txtEcommerceConvenio.Top = 2.1875!
            Me.txtEcommerceConvenio.Width = 2.8125!
            '
            'lblEcommerceReferencia
            '
            Me.lblEcommerceReferencia.Height = 0.25!
            Me.lblEcommerceReferencia.HyperLink = Nothing
            Me.lblEcommerceReferencia.Left = 0.75!
            Me.lblEcommerceReferencia.Name = "lblEcommerceReferencia"
            Me.lblEcommerceReferencia.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblEcommerceReferencia.Text = "-Referencia:"
            Me.lblEcommerceReferencia.Top = 2.4375!
            Me.lblEcommerceReferencia.Width = 1.25!
            '
            'txtEcommerceReferencia
            '
            Me.txtEcommerceReferencia.Height = 0.25!
            Me.txtEcommerceReferencia.Left = 2!
            Me.txtEcommerceReferencia.Name = "txtEcommerceReferencia"
            Me.txtEcommerceReferencia.Style = "font-size: 14.25pt"
            Me.txtEcommerceReferencia.Top = 2.4375!
            Me.txtEcommerceReferencia.Width = 2.5625!
            '
            'lblEcommerceCantidad
            '
            Me.lblEcommerceCantidad.Height = 0.25!
            Me.lblEcommerceCantidad.HyperLink = Nothing
            Me.lblEcommerceCantidad.Left = 0.75!
            Me.lblEcommerceCantidad.Name = "lblEcommerceCantidad"
            Me.lblEcommerceCantidad.Style = "font-weight: normal; font-size: 14.25pt"
            Me.lblEcommerceCantidad.Text = "-Cantidad a depositar:"
            Me.lblEcommerceCantidad.Top = 2.6875!
            Me.lblEcommerceCantidad.Width = 2.125!
            '
            'txtCantidadEcommerce
            '
            Me.txtCantidadEcommerce.Height = 0.25!
            Me.txtCantidadEcommerce.Left = 2.875!
            Me.txtCantidadEcommerce.Name = "txtCantidadEcommerce"
            Me.txtCantidadEcommerce.Style = "text-align: right; font-size: 14.25pt"
            Me.txtCantidadEcommerce.Top = 2.6875!
            Me.txtCantidadEcommerce.Width = 1.6875!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.53125!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.lblTitulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFicha1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtNombreTienda,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVentaConvenioCIEC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVentaConvenioCIEC,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVentaReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVentaReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblVentaCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtVentaCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblFicha2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblEcommerceConvenio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEcommerceConvenio,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblEcommerceReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtEcommerceReferencia,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.lblEcommerceCantidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantidadEcommerce,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region
End Class
