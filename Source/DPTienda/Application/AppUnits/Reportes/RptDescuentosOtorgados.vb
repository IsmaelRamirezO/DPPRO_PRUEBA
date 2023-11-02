Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class RptDescuentosOtorgados
    Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal dsDetalle As DataSet, ByVal FechaDe As DateTime, ByVal FechaAl As DateTime)
        MyBase.New()
        InitializeComponent()
        Dim oAlmacen As Almacen
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.txtSucursal.Text = oAlmacen.ID & " " & oAlmacen.Descripcion

        Else

            Me.txtSucursal.Text = oAppContext.ApplicationConfiguration.Almacen

        End If

        Me.DataSource = dsDetalle
        Me.DataMember = dsDetalle.Tables(0).TableName

        Me.txtFecha.Text = Now.Date.ToShortDateString

        Me.txtFechaDel.Text = FechaDe.ToLongDateString
        Me.txtFechaAl.Text = FechaAl.ToLongDateString

        'Me.txtCaja.Text = caja


    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private Shape1 As Shape = Nothing
	Private Label1 As Label = Nothing
	Private txtFecha As TextBox = Nothing
	Private TextBox11 As TextBox = Nothing
	Private txtFechaAl As TextBox = Nothing
	Private TextBox10 As TextBox = Nothing
	Private txtFechaDel As TextBox = Nothing
	Private Label14 As Label = Nothing
	Private Label13 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label16 As Label = Nothing
	Private Label6 As Label = Nothing
	Private Label9 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Label5 As Label = Nothing
	Private Label7 As Label = Nothing
	Private Label18 As Label = Nothing
	Private Label19 As Label = Nothing
	Private Label20 As Label = Nothing
	Private Label21 As Label = Nothing
	Private Label22 As Label = Nothing
	Private Label23 As Label = Nothing
	Private Label24 As Label = Nothing
	Private txtSucursal As TextBox = Nothing
	Private Line1 As Line = Nothing
	Private txtFolioFactura As TextBox = Nothing
    Private txtCodArticulo As TextBox = Nothing
	Private txtpreciounit As TextBox = Nothing
	Private txtdescuentosistema As TextBox = Nothing
	Private txtcantdescuentosistema As TextBox = Nothing
	Private txtPrecioOferta As TextBox = Nothing
	Private txtDescuento As TextBox = Nothing
	Private txtCantDescuento As TextBox = Nothing
	Private txtTotal As TextBox = Nothing
	Private txtCostoUnit As TextBox = Nothing
	Private txtUtilidad As TextBox = Nothing
	Private txtCodVendedor As TextBox = Nothing
	Private TextBox17 As TextBox = Nothing
	Private Shape2 As Shape = Nothing
	Private txtImporteGT As TextBox = Nothing
	Private TextBox12 As TextBox = Nothing
	Private TextBox13 As TextBox = Nothing
	Private TextBox14 As TextBox = Nothing
	Private TextBox15 As TextBox = Nothing
	Private TextBox16 As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptDescuentosOtorgados))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.Shape1 = New DataDynamics.ActiveReports.Shape()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.txtFecha = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox11 = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaAl = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox10 = New DataDynamics.ActiveReports.TextBox()
            Me.txtFechaDel = New DataDynamics.ActiveReports.TextBox()
            Me.Label14 = New DataDynamics.ActiveReports.Label()
            Me.Label13 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label16 = New DataDynamics.ActiveReports.Label()
            Me.Label6 = New DataDynamics.ActiveReports.Label()
            Me.Label9 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            Me.Label5 = New DataDynamics.ActiveReports.Label()
            Me.Label7 = New DataDynamics.ActiveReports.Label()
            Me.Label18 = New DataDynamics.ActiveReports.Label()
            Me.Label19 = New DataDynamics.ActiveReports.Label()
            Me.Label20 = New DataDynamics.ActiveReports.Label()
            Me.Label21 = New DataDynamics.ActiveReports.Label()
            Me.Label22 = New DataDynamics.ActiveReports.Label()
            Me.Label23 = New DataDynamics.ActiveReports.Label()
            Me.Label24 = New DataDynamics.ActiveReports.Label()
            Me.txtSucursal = New DataDynamics.ActiveReports.TextBox()
            Me.Line1 = New DataDynamics.ActiveReports.Line()
            Me.txtFolioFactura = New DataDynamics.ActiveReports.TextBox()
            Me.txtfecha = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodArticulo = New DataDynamics.ActiveReports.TextBox()
            Me.txtpreciounit = New DataDynamics.ActiveReports.TextBox()
            Me.txtdescuentosistema = New DataDynamics.ActiveReports.TextBox()
            Me.txtcantdescuentosistema = New DataDynamics.ActiveReports.TextBox()
            Me.txtPrecioOferta = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.txtCantDescuento = New DataDynamics.ActiveReports.TextBox()
            Me.txtTotal = New DataDynamics.ActiveReports.TextBox()
            Me.txtCostoUnit = New DataDynamics.ActiveReports.TextBox()
            Me.txtUtilidad = New DataDynamics.ActiveReports.TextBox()
            Me.txtCodVendedor = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox17 = New DataDynamics.ActiveReports.TextBox()
            Me.Shape2 = New DataDynamics.ActiveReports.Shape()
            Me.txtImporteGT = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox12 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox13 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox14 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox15 = New DataDynamics.ActiveReports.TextBox()
            Me.TextBox16 = New DataDynamics.ActiveReports.TextBox()
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtfecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtpreciounit,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtdescuentosistema,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtcantdescuentosistema,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCantDescuento,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtUtilidad,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCodVendedor,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtImporteGT,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtFolioFactura, Me.txtfecha, Me.txtCodArticulo, Me.txtpreciounit, Me.txtdescuentosistema, Me.txtcantdescuentosistema, Me.txtPrecioOferta, Me.txtDescuento, Me.txtCantDescuento, Me.txtTotal, Me.txtCostoUnit, Me.txtUtilidad, Me.txtCodVendedor, Me.TextBox17})
            Me.Detail.Height = 0.2076389!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.Label1, Me.txtFecha, Me.TextBox11, Me.txtFechaAl, Me.TextBox10, Me.txtFechaDel, Me.Label14, Me.Label13, Me.Label3, Me.Label16, Me.Label6, Me.Label9, Me.Label4, Me.Label5, Me.Label7, Me.Label18, Me.Label19, Me.Label20, Me.Label21, Me.Label22, Me.Label23, Me.Label24, Me.txtSucursal, Me.Line1})
            Me.PageHeader.Height = 1.270833!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtImporteGT, Me.TextBox12, Me.TextBox13, Me.TextBox14, Me.TextBox15, Me.TextBox16})
            Me.PageFooter.Height = 0.3534722!
            Me.PageFooter.Name = "PageFooter"
            '
            'Shape1
            '
            Me.Shape1.Height = 1.25!
            Me.Shape1.Left = 0.0625!
            Me.Shape1.Name = "Shape1"
            Me.Shape1.RoundingRadius = 9.999999!
            Me.Shape1.Top = 0!
            Me.Shape1.Width = 9.8125!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 1.5!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: center"
            Me.Label1.Text = "REPORTE DE DESCUENTOS OTORGADOS"
            Me.Label1.Top = 0.03937007!
            Me.Label1.Width = 7.75!
            '
            'txtFecha
            '
            Me.txtFecha.Height = 0.2!
            Me.txtFecha.Left = 0.1018701!
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.Top = 0.03937007!
            Me.txtFecha.Width = 1.338583!
            '
            'TextBox11
            '
            Me.TextBox11.Height = 0.2!
            Me.TextBox11.Left = 9.618605!
            Me.TextBox11.Name = "TextBox11"
            Me.TextBox11.Style = "font-size: 8.25pt"
            Me.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount
            Me.TextBox11.Text = "100"
            Me.TextBox11.Top = 0.03937007!
            Me.TextBox11.Width = 0.2362203!
            '
            'txtFechaAl
            '
            Me.txtFechaAl.Height = 0.2!
            Me.txtFechaAl.Left = 5.742618!
            Me.txtFechaAl.Name = "txtFechaAl"
            Me.txtFechaAl.OutputFormat = resources.GetString("txtFechaAl.OutputFormat")
            Me.txtFechaAl.Top = 0.2755906!
            Me.txtFechaAl.Width = 2.047244!
            '
            'TextBox10
            '
            Me.TextBox10.Height = 0.2!
            Me.TextBox10.Left = 9.306105!
            Me.TextBox10.Name = "TextBox10"
            Me.TextBox10.Style = "font-size: 8.25pt"
            Me.TextBox10.Text = "Pág."
            Me.TextBox10.Top = 0.03937007!
            Me.TextBox10.Width = 0.2987203!
            '
            'txtFechaDel
            '
            Me.txtFechaDel.Height = 0.2!
            Me.txtFechaDel.Left = 3.278543!
            Me.txtFechaDel.Name = "txtFechaDel"
            Me.txtFechaDel.OutputFormat = resources.GetString("txtFechaDel.OutputFormat")
            Me.txtFechaDel.Top = 0.2755906!
            Me.txtFechaDel.Width = 2.204725!
            '
            'Label14
            '
            Me.Label14.Height = 0.2!
            Me.Label14.HyperLink = Nothing
            Me.Label14.Left = 5.490159!
            Me.Label14.Name = "Label14"
            Me.Label14.Style = ""
            Me.Label14.Text = "Al.:"
            Me.Label14.Top = 0.2755906!
            Me.Label14.Width = 0.2755904!
            '
            'Label13
            '
            Me.Label13.Height = 0.2!
            Me.Label13.HyperLink = Nothing
            Me.Label13.Left = 4.151083!
            Me.Label13.Name = "Label13"
            Me.Label13.Style = ""
            Me.Label13.Text = "Sucursal.:"
            Me.Label13.Top = 0.511811!
            Me.Label13.Width = 0.6299212!
            '
            'Label3
            '
            Me.Label3.Height = 0.2982284!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.0625!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label3.Text = "FOLIO FACTURA"
            Me.Label3.Top = 0.8125!
            Me.Label3.Width = 0.625!
            '
            'Label16
            '
            Me.Label16.Height = 0.2!
            Me.Label16.HyperLink = Nothing
            Me.Label16.Left = 0.7111222!
            Me.Label16.Name = "Label16"
            Me.Label16.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
            Me.Label16.Text = "FECHA"
            Me.Label16.Top = 0.8267716!
            Me.Label16.Width = 0.7263778!
            '
            'Label6
            '
            Me.Label6.Height = 0.2!
            Me.Label6.HyperLink = Nothing
            Me.Label6.Left = 1.4375!
            Me.Label6.Name = "Label6"
            Me.Label6.Style = "text-align: center; font-weight: normal; font-size: 8.25pt; vertical-align: top"
            Me.Label6.Text = "CODIGO"
            Me.Label6.Top = 0.8267716!
            Me.Label6.Width = 1.25!
            '
            'Label9
            '
            Me.Label9.Height = 0.2982284!
            Me.Label9.HyperLink = Nothing
            Me.Label9.Left = 2.727854!
            Me.Label9.Name = "Label9"
            Me.Label9.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label9.Text = "PRECIO REAL"
            Me.Label9.Top = 0.8267716!
            Me.Label9.Width = 0.7096459!
            '
            'Label4
            '
            Me.Label4.Height = 0.3125!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 3.4375!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label4.Text = "% DESC. SISTEMA"
            Me.Label4.Top = 0.8125!
            Me.Label4.Width = 0.5625!
            '
            'Label5
            '
            Me.Label5.Height = 0.4375!
            Me.Label5.HyperLink = Nothing
            Me.Label5.Left = 4!
            Me.Label5.Name = "Label5"
            Me.Label5.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label5.Text = "IMPORTE DESC. SISTEMA"
            Me.Label5.Top = 0.8125!
            Me.Label5.Width = 0.75!
            '
            'Label7
            '
            Me.Label7.Height = 0.2982284!
            Me.Label7.HyperLink = Nothing
            Me.Label7.Left = 4.75!
            Me.Label7.Name = "Label7"
            Me.Label7.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label7.Text = "PRECIO PUBLICO"
            Me.Label7.Top = 0.8125!
            Me.Label7.Width = 0.75!
            '
            'Label18
            '
            Me.Label18.Height = 0.2!
            Me.Label18.HyperLink = Nothing
            Me.Label18.Left = 3!
            Me.Label18.Name = "Label18"
            Me.Label18.Style = ""
            Me.Label18.Text = "DE.:"
            Me.Label18.Top = 0.25!
            Me.Label18.Width = 0.2755904!
            '
            'Label19
            '
            Me.Label19.Height = 0.375!
            Me.Label19.HyperLink = Nothing
            Me.Label19.Left = 5.5!
            Me.Label19.Name = "Label19"
            Me.Label19.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label19.Text = "% DESC. OTORGADO"
            Me.Label19.Top = 0.8125!
            Me.Label19.Width = 0.75!
            '
            'Label20
            '
            Me.Label20.Height = 0.4375!
            Me.Label20.HyperLink = Nothing
            Me.Label20.Left = 6.25!
            Me.Label20.Name = "Label20"
            Me.Label20.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label20.Text = "IMPORTE DESC. OTORGADO"
            Me.Label20.Top = 0.8125!
            Me.Label20.Width = 0.75!
            '
            'Label21
            '
            Me.Label21.Height = 0.2982284!
            Me.Label21.HyperLink = Nothing
            Me.Label21.Left = 7!
            Me.Label21.Name = "Label21"
            Me.Label21.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label21.Text = "PRECIO FINAL"
            Me.Label21.Top = 0.8125!
            Me.Label21.Width = 0.75!
            '
            'Label22
            '
            Me.Label22.Height = 0.2982284!
            Me.Label22.HyperLink = Nothing
            Me.Label22.Left = 7.75!
            Me.Label22.Name = "Label22"
            Me.Label22.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label22.Text = "COSTO"
            Me.Label22.Top = 0.8125!
            Me.Label22.Width = 0.75!
            '
            'Label23
            '
            Me.Label23.Height = 0.2982284!
            Me.Label23.HyperLink = Nothing
            Me.Label23.Left = 8.5!
            Me.Label23.Name = "Label23"
            Me.Label23.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label23.Text = "UTILIDAD"
            Me.Label23.Top = 0.8125!
            Me.Label23.Width = 0.75!
            '
            'Label24
            '
            Me.Label24.Height = 0.2982284!
            Me.Label24.HyperLink = Nothing
            Me.Label24.Left = 9.25!
            Me.Label24.Name = "Label24"
            Me.Label24.Style = "text-align: center; font-weight: normal; font-size: 8.25pt"
            Me.Label24.Text = "PLAYER"
            Me.Label24.Top = 0.8125!
            Me.Label24.Width = 0.625!
            '
            'txtSucursal
            '
            Me.txtSucursal.Height = 0.2!
            Me.txtSucursal.Left = 4.8125!
            Me.txtSucursal.Name = "txtSucursal"
            Me.txtSucursal.Top = 0.5!
            Me.txtSucursal.Width = 2.047244!
            '
            'Line1
            '
            Me.Line1.Height = 0!
            Me.Line1.Left = 0.0625!
            Me.Line1.LineWeight = 1!
            Me.Line1.Name = "Line1"
            Me.Line1.Top = 0.75!
            Me.Line1.Width = 9.8125!
            Me.Line1.X1 = 0.0625!
            Me.Line1.X2 = 9.875!
            Me.Line1.Y1 = 0.75!
            Me.Line1.Y2 = 0.75!
            '
            'txtFolioFactura
            '
            Me.txtFolioFactura.DataField = "foliofactura"
            Me.txtFolioFactura.Height = 0.2!
            Me.txtFolioFactura.Left = 0.0625!
            Me.txtFolioFactura.Name = "txtFolioFactura"
            Me.txtFolioFactura.Style = "text-align: right; font-size: 9pt"
            Me.txtFolioFactura.Text = "foliofactura"
            Me.txtFolioFactura.Top = 0!
            Me.txtFolioFactura.Width = 0.625!
            '
            'txtfecha
            '
            Me.txtfecha.DataField = "fecha"
            Me.txtfecha.Height = 0.2!
            Me.txtfecha.Left = 0.6875!
            Me.txtfecha.Name = "txtfecha"
            Me.txtfecha.OutputFormat = resources.GetString("txtfecha.OutputFormat")
            Me.txtfecha.Style = "text-align: center; font-size: 9pt"
            Me.txtfecha.Text = "fecha"
            Me.txtfecha.Top = 0!
            Me.txtfecha.Width = 0.75!
            '
            'txtCodArticulo
            '
            Me.txtCodArticulo.DataField = "codarticulo"
            Me.txtCodArticulo.Height = 0.2!
            Me.txtCodArticulo.Left = 1.4375!
            Me.txtCodArticulo.Name = "txtCodArticulo"
            Me.txtCodArticulo.Style = "font-size: 9pt"
            Me.txtCodArticulo.Text = "CodArticulo"
            Me.txtCodArticulo.Top = 0!
            Me.txtCodArticulo.Width = 1.226!
            '
            'txtpreciounit
            '
            Me.txtpreciounit.DataField = "preciounit"
            Me.txtpreciounit.Height = 0.2!
            Me.txtpreciounit.Left = 10.1875!
            Me.txtpreciounit.Name = "txtpreciounit"
            Me.txtpreciounit.OutputFormat = resources.GetString("txtpreciounit.OutputFormat")
            Me.txtpreciounit.Style = "text-align: right; font-size: 9pt"
            Me.txtpreciounit.Text = "preciounit"
            Me.txtpreciounit.Top = 3.4375!
            Me.txtpreciounit.Width = 0.75!
            '
            'txtdescuentosistema
            '
            Me.txtdescuentosistema.DataField = "descuentosistema"
            Me.txtdescuentosistema.Height = 0.2!
            Me.txtdescuentosistema.Left = 3.4375!
            Me.txtdescuentosistema.Name = "txtdescuentosistema"
            Me.txtdescuentosistema.OutputFormat = resources.GetString("txtdescuentosistema.OutputFormat")
            Me.txtdescuentosistema.Style = "text-align: right; font-size: 9pt"
            Me.txtdescuentosistema.Text = "descuentosistema"
            Me.txtdescuentosistema.Top = 0!
            Me.txtdescuentosistema.Width = 0.5625!
            '
            'txtcantdescuentosistema
            '
            Me.txtcantdescuentosistema.DataField = "cantdescuentosistema"
            Me.txtcantdescuentosistema.Height = 0.2!
            Me.txtcantdescuentosistema.Left = 4!
            Me.txtcantdescuentosistema.Name = "txtcantdescuentosistema"
            Me.txtcantdescuentosistema.OutputFormat = resources.GetString("txtcantdescuentosistema.OutputFormat")
            Me.txtcantdescuentosistema.Style = "text-align: right; font-size: 9pt"
            Me.txtcantdescuentosistema.Text = "cantdescuentosistema"
            Me.txtcantdescuentosistema.Top = 0!
            Me.txtcantdescuentosistema.Width = 0.75!
            '
            'txtPrecioOferta
            '
            Me.txtPrecioOferta.DataField = "PrecioOferta"
            Me.txtPrecioOferta.Height = 0.2!
            Me.txtPrecioOferta.Left = 4.75!
            Me.txtPrecioOferta.Name = "txtPrecioOferta"
            Me.txtPrecioOferta.OutputFormat = resources.GetString("txtPrecioOferta.OutputFormat")
            Me.txtPrecioOferta.Style = "text-align: right; font-size: 9pt"
            Me.txtPrecioOferta.Text = "PrecioOferta"
            Me.txtPrecioOferta.Top = 0!
            Me.txtPrecioOferta.Width = 0.75!
            '
            'txtDescuento
            '
            Me.txtDescuento.DataField = "Descuento"
            Me.txtDescuento.Height = 0.2!
            Me.txtDescuento.Left = 5.5!
            Me.txtDescuento.Name = "txtDescuento"
            Me.txtDescuento.OutputFormat = resources.GetString("txtDescuento.OutputFormat")
            Me.txtDescuento.Style = "text-align: right; font-size: 9pt"
            Me.txtDescuento.Text = "Descuento"
            Me.txtDescuento.Top = 0!
            Me.txtDescuento.Width = 0.75!
            '
            'txtCantDescuento
            '
            Me.txtCantDescuento.DataField = "CantDescuento"
            Me.txtCantDescuento.Height = 0.2!
            Me.txtCantDescuento.Left = 6.25!
            Me.txtCantDescuento.Name = "txtCantDescuento"
            Me.txtCantDescuento.OutputFormat = resources.GetString("txtCantDescuento.OutputFormat")
            Me.txtCantDescuento.Style = "text-align: right; font-size: 9pt"
            Me.txtCantDescuento.Text = "CantDescuento"
            Me.txtCantDescuento.Top = 0!
            Me.txtCantDescuento.Width = 0.75!
            '
            'txtTotal
            '
            Me.txtTotal.DataField = "CantTotal"
            Me.txtTotal.Height = 0.2!
            Me.txtTotal.Left = 7!
            Me.txtTotal.Name = "txtTotal"
            Me.txtTotal.OutputFormat = resources.GetString("txtTotal.OutputFormat")
            Me.txtTotal.Style = "text-align: right; font-size: 9pt"
            Me.txtTotal.Text = "Total"
            Me.txtTotal.Top = 0!
            Me.txtTotal.Width = 0.75!
            '
            'txtCostoUnit
            '
            Me.txtCostoUnit.DataField = "CostoUnit"
            Me.txtCostoUnit.Height = 0.2!
            Me.txtCostoUnit.Left = 7.75!
            Me.txtCostoUnit.Name = "txtCostoUnit"
            Me.txtCostoUnit.OutputFormat = resources.GetString("txtCostoUnit.OutputFormat")
            Me.txtCostoUnit.Style = "text-align: right; font-size: 9pt"
            Me.txtCostoUnit.Text = "CostoUnit"
            Me.txtCostoUnit.Top = 0!
            Me.txtCostoUnit.Width = 0.75!
            '
            'txtUtilidad
            '
            Me.txtUtilidad.DataField = "Utilidad"
            Me.txtUtilidad.Height = 0.2!
            Me.txtUtilidad.Left = 8.5!
            Me.txtUtilidad.Name = "txtUtilidad"
            Me.txtUtilidad.OutputFormat = resources.GetString("txtUtilidad.OutputFormat")
            Me.txtUtilidad.Style = "text-align: right; font-size: 9pt"
            Me.txtUtilidad.Text = "Utilidad"
            Me.txtUtilidad.Top = 0!
            Me.txtUtilidad.Width = 0.75!
            '
            'txtCodVendedor
            '
            Me.txtCodVendedor.DataField = "CodVendedor"
            Me.txtCodVendedor.Height = 0.2!
            Me.txtCodVendedor.Left = 9.25!
            Me.txtCodVendedor.Name = "txtCodVendedor"
            Me.txtCodVendedor.Style = "text-align: right; font-size: 9pt"
            Me.txtCodVendedor.Text = "CodVendedor"
            Me.txtCodVendedor.Top = 0!
            Me.txtCodVendedor.Width = 0.625!
            '
            'TextBox17
            '
            Me.TextBox17.DataField = "preciounit"
            Me.TextBox17.Height = 0.2!
            Me.TextBox17.Left = 2.6875!
            Me.TextBox17.Name = "TextBox17"
            Me.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat")
            Me.TextBox17.Style = "text-align: right; font-size: 9pt"
            Me.TextBox17.Text = "PrecioUnit"
            Me.TextBox17.Top = 0!
            Me.TextBox17.Width = 0.7395833!
            '
            'Shape2
            '
            Me.Shape2.Height = 0.3125!
            Me.Shape2.Left = 0.0625!
            Me.Shape2.Name = "Shape2"
            Me.Shape2.RoundingRadius = 9.999999!
            Me.Shape2.Top = 0!
            Me.Shape2.Width = 9.8125!
            '
            'txtImporteGT
            '
            Me.txtImporteGT.DataField = "preciounit"
            Me.txtImporteGT.Height = 0.2!
            Me.txtImporteGT.Left = 2.6875!
            Me.txtImporteGT.Name = "txtImporteGT"
            Me.txtImporteGT.OutputFormat = resources.GetString("txtImporteGT.OutputFormat")
            Me.txtImporteGT.Style = "text-align: right; font-size: 9pt"
            Me.txtImporteGT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.txtImporteGT.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.txtImporteGT.Text = "PrecioUnit"
            Me.txtImporteGT.Top = 0.0625!
            Me.txtImporteGT.Width = 0.7395833!
            '
            'TextBox12
            '
            Me.TextBox12.DataField = "cantdescuentosistema"
            Me.TextBox12.Height = 0.2!
            Me.TextBox12.Left = 4!
            Me.TextBox12.Name = "TextBox12"
            Me.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat")
            Me.TextBox12.Style = "text-align: right; font-size: 9pt"
            Me.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox12.Text = "cantdescuentosistema"
            Me.TextBox12.Top = 0.0625!
            Me.TextBox12.Width = 0.7395833!
            '
            'TextBox13
            '
            Me.TextBox13.DataField = "PrecioOferta"
            Me.TextBox13.Height = 0.2!
            Me.TextBox13.Left = 4.75!
            Me.TextBox13.Name = "TextBox13"
            Me.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat")
            Me.TextBox13.Style = "text-align: right; font-size: 9pt"
            Me.TextBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox13.Text = "PrecioOferta"
            Me.TextBox13.Top = 0.0625!
            Me.TextBox13.Width = 0.7395833!
            '
            'TextBox14
            '
            Me.TextBox14.DataField = "Descuento"
            Me.TextBox14.Height = 0.2!
            Me.TextBox14.Left = 6.25!
            Me.TextBox14.Name = "TextBox14"
            Me.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat")
            Me.TextBox14.Style = "text-align: right; font-size: 9pt"
            Me.TextBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox14.Text = "CantDescuento"
            Me.TextBox14.Top = 0.0625!
            Me.TextBox14.Width = 0.7395833!
            '
            'TextBox15
            '
            Me.TextBox15.DataField = "Total"
            Me.TextBox15.Height = 0.2!
            Me.TextBox15.Left = 7!
            Me.TextBox15.Name = "TextBox15"
            Me.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat")
            Me.TextBox15.Style = "text-align: right; font-size: 9pt"
            Me.TextBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox15.Text = "Total"
            Me.TextBox15.Top = 0.0625!
            Me.TextBox15.Width = 0.7395833!
            '
            'TextBox16
            '
            Me.TextBox16.DataField = "CostoUnit"
            Me.TextBox16.Height = 0.2!
            Me.TextBox16.Left = 7.75!
            Me.TextBox16.Name = "TextBox16"
            Me.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat")
            Me.TextBox16.Style = "text-align: right; font-size: 9pt"
            Me.TextBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
            Me.TextBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
            Me.TextBox16.Text = "CostoUnit"
            Me.TextBox16.Top = 0.0625!
            Me.TextBox16.Width = 0.7395833!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0.5!
            Me.PageSettings.Margins.Right = 0.5!
            Me.PageSettings.Margins.Top = 0.5!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 10.32292!
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
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox11,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaAl,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox10,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFechaDel,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label6,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label9,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label5,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label7,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label18,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label19,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label20,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label21,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label22,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label23,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label24,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtSucursal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtFolioFactura,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtfecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodArticulo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtpreciounit,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtdescuentosistema,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtcantdescuentosistema,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtPrecioOferta,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCantDescuento,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTotal,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCostoUnit,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtUtilidad,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCodVendedor,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox17,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtImporteGT,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox12,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox13,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox14,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox15,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TextBox16,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

    Private Sub PageHeader_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.Format

    End Sub
End Class
