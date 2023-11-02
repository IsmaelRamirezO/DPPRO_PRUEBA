Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports Janus.Windows.GridEX.EditControls

Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.AvisosFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.TiposVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta

Imports DportenisPro.DpTienda.ApplicationUnits.CambiarFolioFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports System.Collections.Generic

Public Class frmFacturacionSinExistencia

    Inherits System.Windows.Forms.Form

#Region "Propiedades"
    Public Property FormasPago() As DataTable
        Get
            Return m_dtFormasPago
        End Get
        Set(ByVal Value As DataTable)
            m_dtFormasPago = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeDisplayPromociones()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents uICommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientasPago As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudasTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientasPago1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudasTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ToolBarAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoApartado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoApartado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdDetalle As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ebCodCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ebCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnFormaPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioApartado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFolioFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebFechaFactura As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClienteDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents explorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents prgProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ebDescuentoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ebImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebIVA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSubTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents explorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebTallaAl As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTallaDel As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebExistencias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebPrecioArticulo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel21 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ebCodigoArticulo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcionArticulo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAltaCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCorrida As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPorcentajeDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebMontoDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chkDip As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents EbFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuFacturarDev As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuFacturarDev1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents chkVentaManual As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtFolioVentaManual As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkPromoEspecial As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents exbGuardarCliente As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents pbAvance As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents lblLabel14 As System.Windows.Forms.Label
    Friend WithEvents timer1 As System.Timers.Timer
    Friend WithEvents lblCronometro As System.Windows.Forms.Label
    Friend WithEvents dgHeader As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblPopupCodigo As System.Windows.Forms.Label
    Friend WithEvents txtPopupCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPopupTalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPopupCantidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PanelAgregarArticulo As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblPopuImporte As System.Windows.Forms.Label
    Friend WithEvents txtPopupImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPopupTotal As System.Windows.Forms.Label
    Friend WithEvents txtPopupTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPopupDescuento As System.Windows.Forms.Label
    Friend WithEvents txtPopupDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPopupAdicional As System.Windows.Forms.Label
    Friend WithEvents txtPopupAdicional As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnPopupGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblTotalPiezas As System.Windows.Forms.Label
    Friend WithEvents nebTotalPiezas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents MnuLoadWeb As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuLoadWeb1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarArticulosSiHay As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarArticulosSiHay1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuModificarBeneficiario As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuModificarBeneficiario1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacionSinExistencia))
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.uICommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuHerramientas1 = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ToolBarNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("ToolBarNuevo")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ToolBarAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("ToolBarAbrir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuLoadWeb1 = New Janus.Windows.UI.CommandBars.UICommand("MnuLoadWeb")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuCargarArticulosSiHay1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarArticulosSiHay")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ToolBarAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("ToolBarAyuda")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuFacturarDev1 = New Janus.Windows.UI.CommandBars.UICommand("menuFacturarDev")
        Me.menuArchivoApartado1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoApartado")
        Me.MnuModificarBeneficiario1 = New Janus.Windows.UI.CommandBars.UICommand("MnuModificarBeneficiario")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuHerramientas = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuHerramientasPago1 = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientasPago")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudasTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudasTema")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoApartado = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoApartado")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuHerramientasPago = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientasPago")
        Me.menuAyudasTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudasTema")
        Me.ToolBarNuevo = New Janus.Windows.UI.CommandBars.UICommand("ToolBarNuevo")
        Me.ToolBarAbrir = New Janus.Windows.UI.CommandBars.UICommand("ToolBarAbrir")
        Me.ToolBarGuardar = New Janus.Windows.UI.CommandBars.UICommand("ToolBarGuardar")
        Me.ToolBarEliminar = New Janus.Windows.UI.CommandBars.UICommand("ToolBarEliminar")
        Me.ToolBarAyuda = New Janus.Windows.UI.CommandBars.UICommand("ToolBarAyuda")
        Me.menuFacturarDev = New Janus.Windows.UI.CommandBars.UICommand("menuFacturarDev")
        Me.MnuLoadWeb = New Janus.Windows.UI.CommandBars.UICommand("MnuLoadWeb")
        Me.MnuCargarArticulosSiHay = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarArticulosSiHay")
        Me.MnuModificarBeneficiario = New Janus.Windows.UI.CommandBars.UICommand("MnuModificarBeneficiario")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.PanelAgregarArticulo = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnPopupGuardar = New Janus.Windows.EditControls.UIButton()
        Me.txtPopupAdicional = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPopupAdicional = New System.Windows.Forms.Label()
        Me.txtPopupDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPopupDescuento = New System.Windows.Forms.Label()
        Me.txtPopupTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPopupTotal = New System.Windows.Forms.Label()
        Me.txtPopupImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPopuImporte = New System.Windows.Forms.Label()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPopupCantidad = New System.Windows.Forms.Label()
        Me.txtPopupTalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPopupCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPopupCodigo = New System.Windows.Forms.Label()
        Me.dgHeader = New Janus.Windows.GridEX.GridEX()
        Me.ebClienteDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCronometro = New System.Windows.Forms.Label()
        Me.chkPromoEspecial = New Janus.Windows.EditControls.UICheckBox()
        Me.txtFolioVentaManual = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.chkVentaManual = New Janus.Windows.EditControls.UICheckBox()
        Me.EbFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.explorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.chkDip = New Janus.Windows.EditControls.UICheckBox()
        Me.ebMontoDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCorrida = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ebTallaAl = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebTallaDel = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebExistencias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebPrecioArticulo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebPorcentajeDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel21 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ebCodigoArticulo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDescripcionArticulo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.explorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebTotalPiezas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalPiezas = New System.Windows.Forms.Label()
        Me.prgProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ebDescuentoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ebImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebIVA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebSubTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.grdDetalle = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ebCodCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnFormaPago = New Janus.Windows.EditControls.UIButton()
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolioApartado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFolioFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebFechaFactura = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnAltaCliente = New Janus.Windows.EditControls.UIButton()
        Me.ebStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.exbGuardarCliente = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.pbAvance = New Janus.Windows.EditControls.UIProgressBar()
        Me.lblLabel14 = New System.Windows.Forms.Label()
        Me.timer1 = New System.Timers.Timer()
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.PanelAgregarArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAgregarArticulo.SuspendLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar3.SuspendLayout()
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar2.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exbGuardarCliente.SuspendLayout()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuHerramientas, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoAbrir, Me.menuArchivoApartado, Me.menuArchivoEliminar, Me.menuArchivoGuardar, Me.menuArchivoImprimir, Me.menuArchivoSalir, Me.menuHerramientasPago, Me.menuAyudasTema, Me.ToolBarNuevo, Me.ToolBarAbrir, Me.ToolBarGuardar, Me.ToolBarEliminar, Me.ToolBarAyuda, Me.menuFacturarDev, Me.MnuLoadWeb, Me.MnuCargarArticulosSiHay, Me.MnuModificarBeneficiario})
        Me.uICommandManager1.ContainerControl = Me
        '
        '
        '
        Me.uICommandManager1.EditContextMenu.Key = ""
        Me.uICommandManager1.Id = New System.Guid("f94005ba-f0cd-41a6-8f7c-550c5b633fe9")
        Me.uICommandManager1.LeftRebar = Me.LeftRebar1
        Me.uICommandManager1.LockCommandBars = True
        Me.uICommandManager1.RightRebar = Me.RightRebar1
        Me.uICommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.uICommandManager1.TopRebar = Me.TopRebar1
        Me.uICommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.uICommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.uICommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuHerramientas1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(672, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Visible = False
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        Me.menuArchivo1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuHerramientas1
        '
        Me.menuHerramientas1.Key = "menuHerramientas"
        Me.menuHerramientas1.Name = "menuHerramientas1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.CommandManager = Me.uICommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ToolBarNuevo1, Me.Separator5, Me.ToolBarAbrir1, Me.Separator6, Me.MnuLoadWeb1, Me.Separator8, Me.MnuCargarArticulosSiHay1, Me.Separator9, Me.menuArchivoImprimir1, Me.Separator7, Me.Separator3, Me.ToolBarAyuda1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(223, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'ToolBarNuevo1
        '
        Me.ToolBarNuevo1.Key = "ToolBarNuevo"
        Me.ToolBarNuevo1.Name = "ToolBarNuevo1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'ToolBarAbrir1
        '
        Me.ToolBarAbrir1.Key = "ToolBarAbrir"
        Me.ToolBarAbrir1.Name = "ToolBarAbrir1"
        Me.ToolBarAbrir1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'MnuLoadWeb1
        '
        Me.MnuLoadWeb1.Key = "MnuLoadWeb"
        Me.MnuLoadWeb1.Name = "MnuLoadWeb1"
        Me.MnuLoadWeb1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'MnuCargarArticulosSiHay1
        '
        Me.MnuCargarArticulosSiHay1.Key = "MnuCargarArticulosSiHay"
        Me.MnuCargarArticulosSiHay1.Name = "MnuCargarArticulosSiHay1"
        Me.MnuCargarArticulosSiHay1.Text = "Abrir Pedido"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuArchivoImprimir1
        '
        Me.menuArchivoImprimir1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuArchivoImprimir1.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir1.Name = "menuArchivoImprimir1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'ToolBarAyuda1
        '
        Me.ToolBarAyuda1.Key = "ToolBarAyuda"
        Me.ToolBarAyuda1.Name = "ToolBarAyuda1"
        Me.ToolBarAyuda1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoAbrir1, Me.Separator4, Me.menuFacturarDev1, Me.menuArchivoApartado1, Me.MnuModificarBeneficiario1, Me.Separator2, Me.menuArchivoSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoAbrir1
        '
        Me.menuArchivoAbrir1.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir1.Name = "menuArchivoAbrir1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuFacturarDev1
        '
        Me.menuFacturarDev1.Key = "menuFacturarDev"
        Me.menuFacturarDev1.Name = "menuFacturarDev1"
        '
        'menuArchivoApartado1
        '
        Me.menuArchivoApartado1.Image = CType(resources.GetObject("menuArchivoApartado1.Image"), System.Drawing.Image)
        Me.menuArchivoApartado1.Key = "menuArchivoApartado"
        Me.menuArchivoApartado1.Name = "menuArchivoApartado1"
        '
        'MnuModificarBeneficiario1
        '
        Me.MnuModificarBeneficiario1.Key = "MnuModificarBeneficiario"
        Me.MnuModificarBeneficiario1.Name = "MnuModificarBeneficiario1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'menuHerramientas
        '
        Me.menuHerramientas.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuHerramientasPago1})
        Me.menuHerramientas.Key = "menuHerramientas"
        Me.menuHerramientas.Name = "menuHerramientas"
        Me.menuHerramientas.Text = "&Herramientas"
        '
        'menuHerramientasPago1
        '
        Me.menuHerramientasPago1.Key = "menuHerramientasPago"
        Me.menuHerramientasPago1.Name = "menuHerramientasPago1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudasTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
        '
        'menuAyudasTema1
        '
        Me.menuAyudasTema1.Key = "menuAyudasTema"
        Me.menuAyudasTema1.Name = "menuAyudasTema1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Icon = CType(resources.GetObject("menuArchivoNuevo.Icon"), System.Drawing.Icon)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoAbrir
        '
        Me.menuArchivoAbrir.Icon = CType(resources.GetObject("menuArchivoAbrir.Icon"), System.Drawing.Icon)
        Me.menuArchivoAbrir.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Name = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Text = "A&brir"
        '
        'menuArchivoApartado
        '
        Me.menuArchivoApartado.Image = CType(resources.GetObject("menuArchivoApartado.Image"), System.Drawing.Image)
        Me.menuArchivoApartado.Key = "menuArchivoApartado"
        Me.menuArchivoApartado.Name = "menuArchivoApartado"
        Me.menuArchivoApartado.Text = "Facturar Apartado"
        '
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Icon = CType(resources.GetObject("menuArchivoEliminar.Icon"), System.Drawing.Icon)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "&Eliminar"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Icon = CType(resources.GetObject("menuArchivoGuardar.Icon"), System.Drawing.Icon)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoImprimir
        '
        Me.menuArchivoImprimir.Icon = CType(resources.GetObject("menuArchivoImprimir.Icon"), System.Drawing.Icon)
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "&Imprimir"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "&Salir"
        '
        'menuHerramientasPago
        '
        Me.menuHerramientasPago.Icon = CType(resources.GetObject("menuHerramientasPago.Icon"), System.Drawing.Icon)
        Me.menuHerramientasPago.Key = "menuHerramientasPago"
        Me.menuHerramientasPago.Name = "menuHerramientasPago"
        Me.menuHerramientasPago.Text = "&Forma de Pago"
        '
        'menuAyudasTema
        '
        Me.menuAyudasTema.Image = CType(resources.GetObject("menuAyudasTema.Image"), System.Drawing.Image)
        Me.menuAyudasTema.Key = "menuAyudasTema"
        Me.menuAyudasTema.Name = "menuAyudasTema"
        Me.menuAyudasTema.Text = "&Temas de Ayuda"
        '
        'ToolBarNuevo
        '
        Me.ToolBarNuevo.Icon = CType(resources.GetObject("ToolBarNuevo.Icon"), System.Drawing.Icon)
        Me.ToolBarNuevo.Key = "ToolBarNuevo"
        Me.ToolBarNuevo.Name = "ToolBarNuevo"
        Me.ToolBarNuevo.Text = "&Nuevo"
        '
        'ToolBarAbrir
        '
        Me.ToolBarAbrir.Icon = CType(resources.GetObject("ToolBarAbrir.Icon"), System.Drawing.Icon)
        Me.ToolBarAbrir.Key = "ToolBarAbrir"
        Me.ToolBarAbrir.Name = "ToolBarAbrir"
        Me.ToolBarAbrir.Text = "A&brir"
        '
        'ToolBarGuardar
        '
        Me.ToolBarGuardar.Icon = CType(resources.GetObject("ToolBarGuardar.Icon"), System.Drawing.Icon)
        Me.ToolBarGuardar.Key = "ToolBarGuardar"
        Me.ToolBarGuardar.Name = "ToolBarGuardar"
        Me.ToolBarGuardar.Text = "&Guardar"
        '
        'ToolBarEliminar
        '
        Me.ToolBarEliminar.Icon = CType(resources.GetObject("ToolBarEliminar.Icon"), System.Drawing.Icon)
        Me.ToolBarEliminar.Key = "ToolBarEliminar"
        Me.ToolBarEliminar.Name = "ToolBarEliminar"
        Me.ToolBarEliminar.Text = "&Eliminar"
        '
        'ToolBarAyuda
        '
        Me.ToolBarAyuda.Image = CType(resources.GetObject("ToolBarAyuda.Image"), System.Drawing.Image)
        Me.ToolBarAyuda.Key = "ToolBarAyuda"
        Me.ToolBarAyuda.Name = "ToolBarAyuda"
        Me.ToolBarAyuda.Text = "&Temas de Ayuda"
        '
        'menuFacturarDev
        '
        Me.menuFacturarDev.Key = "menuFacturarDev"
        Me.menuFacturarDev.Name = "menuFacturarDev"
        Me.menuFacturarDev.Text = "Facturar Devolucion"
        '
        'MnuLoadWeb
        '
        Me.MnuLoadWeb.Key = "MnuLoadWeb"
        Me.MnuLoadWeb.Name = "MnuLoadWeb"
        Me.MnuLoadWeb.Text = "Cargar Web"
        '
        'MnuCargarArticulosSiHay
        '
        Me.MnuCargarArticulosSiHay.Key = "MnuCargarArticulosSiHay"
        Me.MnuCargarArticulosSiHay.Name = "MnuCargarArticulosSiHay"
        Me.MnuCargarArticulosSiHay.Text = "Abrir Folio Si Hay"
        '
        'MnuModificarBeneficiario
        '
        Me.MnuModificarBeneficiario.Key = "MnuModificarBeneficiario"
        Me.MnuModificarBeneficiario.Name = "MnuModificarBeneficiario"
        Me.MnuModificarBeneficiario.Text = "Modificar Beneficiario"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.uICommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.uICommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.uICommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(672, 50)
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.PanelAgregarArticulo)
        Me.explorerBar1.Controls.Add(Me.dgHeader)
        Me.explorerBar1.Controls.Add(Me.ebClienteDescripcion)
        Me.explorerBar1.Controls.Add(Me.lblCronometro)
        Me.explorerBar1.Controls.Add(Me.chkPromoEspecial)
        Me.explorerBar1.Controls.Add(Me.txtFolioVentaManual)
        Me.explorerBar1.Controls.Add(Me.chkVentaManual)
        Me.explorerBar1.Controls.Add(Me.EbFolioSAP)
        Me.explorerBar1.Controls.Add(Me.explorerBar3)
        Me.explorerBar1.Controls.Add(Me.explorerBar2)
        Me.explorerBar1.Controls.Add(Me.grdDetalle)
        Me.explorerBar1.Controls.Add(Me.ebCodCaja)
        Me.explorerBar1.Controls.Add(Me.Label18)
        Me.explorerBar1.Controls.Add(Me.ebCodVendedor)
        Me.explorerBar1.Controls.Add(Me.btnFormaPago)
        Me.explorerBar1.Controls.Add(Me.ebClienteID)
        Me.explorerBar1.Controls.Add(Me.ebFolioApartado)
        Me.explorerBar1.Controls.Add(Me.ebFolioFactura)
        Me.explorerBar1.Controls.Add(Me.ebTipoVenta)
        Me.explorerBar1.Controls.Add(Me.ebFechaFactura)
        Me.explorerBar1.Controls.Add(Me.btnAltaCliente)
        Me.explorerBar1.Controls.Add(Me.ebStatus)
        Me.explorerBar1.Controls.Add(Me.ebPlayerDescripcion)
        Me.explorerBar1.Controls.Add(Me.Label8)
        Me.explorerBar1.Controls.Add(Me.Label7)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Controls.Add(Me.Label2)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.Label9)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Expanded = False
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(672, 617)
        Me.explorerBar1.TabIndex = 15
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'PanelAgregarArticulo
        '
        Me.PanelAgregarArticulo.Controls.Add(Me.btnCancelar)
        Me.PanelAgregarArticulo.Controls.Add(Me.btnPopupGuardar)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupAdicional)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopupAdicional)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupDescuento)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopupDescuento)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupTotal)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopupTotal)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupImporte)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopuImporte)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtCantidad)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopupCantidad)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupTalla)
        Me.PanelAgregarArticulo.Controls.Add(Me.Label25)
        Me.PanelAgregarArticulo.Controls.Add(Me.txtPopupCodigo)
        Me.PanelAgregarArticulo.Controls.Add(Me.lblPopupCodigo)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "GrupoArticulo"
        ExplorerBarGroup1.Text = "Agregar Articulo"
        Me.PanelAgregarArticulo.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.PanelAgregarArticulo.Location = New System.Drawing.Point(670, 176)
        Me.PanelAgregarArticulo.Name = "PanelAgregarArticulo"
        Me.PanelAgregarArticulo.Size = New System.Drawing.Size(301, 262)
        Me.PanelAgregarArticulo.TabIndex = 94
        Me.PanelAgregarArticulo.Visible = False
        Me.PanelAgregarArticulo.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(214, 229)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnPopupGuardar
        '
        Me.btnPopupGuardar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPopupGuardar.Location = New System.Drawing.Point(126, 229)
        Me.btnPopupGuardar.Name = "btnPopupGuardar"
        Me.btnPopupGuardar.Size = New System.Drawing.Size(80, 24)
        Me.btnPopupGuardar.TabIndex = 15
        Me.btnPopupGuardar.Text = "&Guardar"
        Me.btnPopupGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtPopupAdicional
        '
        Me.txtPopupAdicional.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupAdicional.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupAdicional.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupAdicional.Location = New System.Drawing.Point(88, 201)
        Me.txtPopupAdicional.Name = "txtPopupAdicional"
        Me.txtPopupAdicional.ReadOnly = True
        Me.txtPopupAdicional.Size = New System.Drawing.Size(104, 22)
        Me.txtPopupAdicional.TabIndex = 14
        Me.txtPopupAdicional.TabStop = False
        Me.txtPopupAdicional.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPopupAdicional.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopupAdicional
        '
        Me.lblPopupAdicional.AutoSize = True
        Me.lblPopupAdicional.BackColor = System.Drawing.Color.Transparent
        Me.lblPopupAdicional.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopupAdicional.Location = New System.Drawing.Point(16, 205)
        Me.lblPopupAdicional.Name = "lblPopupAdicional"
        Me.lblPopupAdicional.Size = New System.Drawing.Size(66, 14)
        Me.lblPopupAdicional.TabIndex = 13
        Me.lblPopupAdicional.Text = "Adicional:"
        '
        'txtPopupDescuento
        '
        Me.txtPopupDescuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupDescuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.txtPopupDescuento.Location = New System.Drawing.Point(88, 174)
        Me.txtPopupDescuento.Name = "txtPopupDescuento"
        Me.txtPopupDescuento.ReadOnly = True
        Me.txtPopupDescuento.Size = New System.Drawing.Size(104, 22)
        Me.txtPopupDescuento.TabIndex = 12
        Me.txtPopupDescuento.TabStop = False
        Me.txtPopupDescuento.Text = "0.00 %"
        Me.txtPopupDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPopupDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopupDescuento
        '
        Me.lblPopupDescuento.AutoSize = True
        Me.lblPopupDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lblPopupDescuento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopupDescuento.Location = New System.Drawing.Point(16, 178)
        Me.lblPopupDescuento.Name = "lblPopupDescuento"
        Me.lblPopupDescuento.Size = New System.Drawing.Size(76, 14)
        Me.lblPopupDescuento.TabIndex = 11
        Me.lblPopupDescuento.Text = "Descuento:"
        '
        'txtPopupTotal
        '
        Me.txtPopupTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtPopupTotal.Location = New System.Drawing.Point(88, 147)
        Me.txtPopupTotal.Name = "txtPopupTotal"
        Me.txtPopupTotal.ReadOnly = True
        Me.txtPopupTotal.Size = New System.Drawing.Size(104, 22)
        Me.txtPopupTotal.TabIndex = 10
        Me.txtPopupTotal.TabStop = False
        Me.txtPopupTotal.Text = "$0.00"
        Me.txtPopupTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPopupTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopupTotal
        '
        Me.lblPopupTotal.AutoSize = True
        Me.lblPopupTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblPopupTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopupTotal.Location = New System.Drawing.Point(16, 151)
        Me.lblPopupTotal.Name = "lblPopupTotal"
        Me.lblPopupTotal.Size = New System.Drawing.Size(42, 14)
        Me.lblPopupTotal.TabIndex = 9
        Me.lblPopupTotal.Text = "Total:"
        '
        'txtPopupImporte
        '
        Me.txtPopupImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtPopupImporte.Location = New System.Drawing.Point(88, 120)
        Me.txtPopupImporte.Name = "txtPopupImporte"
        Me.txtPopupImporte.ReadOnly = True
        Me.txtPopupImporte.Size = New System.Drawing.Size(104, 22)
        Me.txtPopupImporte.TabIndex = 8
        Me.txtPopupImporte.Text = "$0.00"
        Me.txtPopupImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPopupImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopuImporte
        '
        Me.lblPopuImporte.AutoSize = True
        Me.lblPopuImporte.BackColor = System.Drawing.Color.Transparent
        Me.lblPopuImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopuImporte.Location = New System.Drawing.Point(16, 124)
        Me.lblPopuImporte.Name = "lblPopuImporte"
        Me.lblPopuImporte.Size = New System.Drawing.Size(61, 14)
        Me.lblPopuImporte.TabIndex = 7
        Me.lblPopuImporte.Text = "Importe:"
        '
        'txtCantidad
        '
        Me.txtCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCantidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(88, 95)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(56, 22)
        Me.txtCantidad.TabIndex = 6
        Me.txtCantidad.Tag = "La Cantidad"
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopupCantidad
        '
        Me.lblPopupCantidad.AutoSize = True
        Me.lblPopupCantidad.BackColor = System.Drawing.Color.Transparent
        Me.lblPopupCantidad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopupCantidad.Location = New System.Drawing.Point(16, 100)
        Me.lblPopupCantidad.Name = "lblPopupCantidad"
        Me.lblPopupCantidad.Size = New System.Drawing.Size(66, 14)
        Me.lblPopupCantidad.TabIndex = 5
        Me.lblPopupCantidad.Text = "Cantidad:"
        '
        'txtPopupTalla
        '
        Me.txtPopupTalla.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupTalla.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupTalla.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupTalla.Location = New System.Drawing.Point(88, 68)
        Me.txtPopupTalla.Name = "txtPopupTalla"
        Me.txtPopupTalla.ReadOnly = True
        Me.txtPopupTalla.Size = New System.Drawing.Size(56, 22)
        Me.txtPopupTalla.TabIndex = 4
        Me.txtPopupTalla.Tag = "La talla"
        Me.txtPopupTalla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPopupTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 14)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Talla:"
        '
        'txtPopupCodigo
        '
        Me.txtPopupCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPopupCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPopupCodigo.ButtonImage = CType(resources.GetObject("txtPopupCodigo.ButtonImage"), System.Drawing.Image)
        Me.txtPopupCodigo.ButtonImageSize = New System.Drawing.Size(16, 16)
        Me.txtPopupCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtPopupCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopupCodigo.Location = New System.Drawing.Point(88, 40)
        Me.txtPopupCodigo.Name = "txtPopupCodigo"
        Me.txtPopupCodigo.ReadOnly = True
        Me.txtPopupCodigo.Size = New System.Drawing.Size(207, 22)
        Me.txtPopupCodigo.TabIndex = 2
        Me.txtPopupCodigo.Tag = "El Código"
        Me.txtPopupCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPopupCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPopupCodigo
        '
        Me.lblPopupCodigo.AutoSize = True
        Me.lblPopupCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblPopupCodigo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopupCodigo.Location = New System.Drawing.Point(16, 44)
        Me.lblPopupCodigo.Name = "lblPopupCodigo"
        Me.lblPopupCodigo.Size = New System.Drawing.Size(54, 14)
        Me.lblPopupCodigo.TabIndex = 1
        Me.lblPopupCodigo.Text = "Código:"
        '
        'dgHeader
        '
        Me.dgHeader.AllowCardSizing = False
        Me.dgHeader.AllowColumnDrag = False
        Me.dgHeader.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgHeader.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.dgHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgHeader.GroupByBoxVisible = False
        Me.dgHeader.Location = New System.Drawing.Point(16, 172)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.dgHeader.Size = New System.Drawing.Size(648, 204)
        Me.dgHeader.TabIndex = 13
        Me.dgHeader.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteDescripcion
        '
        Me.ebClienteDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebClienteDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClienteDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.3!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteDescripcion.Location = New System.Drawing.Point(272, 90)
        Me.ebClienteDescripcion.MaxLength = 35
        Me.ebClienteDescripcion.Name = "ebClienteDescripcion"
        Me.ebClienteDescripcion.ReadOnly = True
        Me.ebClienteDescripcion.Size = New System.Drawing.Size(392, 22)
        Me.ebClienteDescripcion.TabIndex = 8
        Me.ebClienteDescripcion.TabStop = False
        Me.ebClienteDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCronometro
        '
        Me.lblCronometro.BackColor = System.Drawing.Color.Transparent
        Me.lblCronometro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCronometro.Location = New System.Drawing.Point(548, 88)
        Me.lblCronometro.Name = "lblCronometro"
        Me.lblCronometro.Size = New System.Drawing.Size(116, 24)
        Me.lblCronometro.TabIndex = 92
        Me.lblCronometro.Text = "00 : 00 : 00"
        Me.lblCronometro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCronometro.Visible = False
        '
        'chkPromoEspecial
        '
        Me.chkPromoEspecial.BackColor = System.Drawing.Color.Transparent
        Me.chkPromoEspecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPromoEspecial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkPromoEspecial.Location = New System.Drawing.Point(497, 150)
        Me.chkPromoEspecial.Name = "chkPromoEspecial"
        Me.chkPromoEspecial.Size = New System.Drawing.Size(168, 16)
        Me.chkPromoEspecial.TabIndex = 12
        Me.chkPromoEspecial.Text = "Promoción Especial"
        Me.chkPromoEspecial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtFolioVentaManual
        '
        Me.txtFolioVentaManual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioVentaManual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioVentaManual.BackColor = System.Drawing.Color.Ivory
        Me.txtFolioVentaManual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFolioVentaManual.Location = New System.Drawing.Point(216, 146)
        Me.txtFolioVentaManual.Name = "txtFolioVentaManual"
        Me.txtFolioVentaManual.ReadOnly = True
        Me.txtFolioVentaManual.Size = New System.Drawing.Size(108, 22)
        Me.txtFolioVentaManual.TabIndex = 89
        Me.txtFolioVentaManual.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFolioVentaManual.Visible = False
        Me.txtFolioVentaManual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkVentaManual
        '
        Me.chkVentaManual.BackColor = System.Drawing.Color.Transparent
        Me.chkVentaManual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVentaManual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkVentaManual.Location = New System.Drawing.Point(12, 150)
        Me.chkVentaManual.Name = "chkVentaManual"
        Me.chkVentaManual.Size = New System.Drawing.Size(168, 16)
        Me.chkVentaManual.TabIndex = 75
        Me.chkVentaManual.Text = "Nota de Venta Manual"
        Me.chkVentaManual.Visible = False
        Me.chkVentaManual.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EbFolioSAP
        '
        Me.EbFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EbFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EbFolioSAP.BackColor = System.Drawing.Color.Ivory
        Me.EbFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.EbFolioSAP.Location = New System.Drawing.Point(128, 34)
        Me.EbFolioSAP.Name = "EbFolioSAP"
        Me.EbFolioSAP.Size = New System.Drawing.Size(96, 22)
        Me.EbFolioSAP.TabIndex = 1
        Me.EbFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EbFolioSAP.Visible = False
        Me.EbFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'explorerBar3
        '
        Me.explorerBar3.Controls.Add(Me.chkDip)
        Me.explorerBar3.Controls.Add(Me.ebMontoDscto)
        Me.explorerBar3.Controls.Add(Me.txtCorrida)
        Me.explorerBar3.Controls.Add(Me.Label19)
        Me.explorerBar3.Controls.Add(Me.ebTallaAl)
        Me.explorerBar3.Controls.Add(Me.ebTallaDel)
        Me.explorerBar3.Controls.Add(Me.ebExistencias)
        Me.explorerBar3.Controls.Add(Me.ebPrecioArticulo)
        Me.explorerBar3.Controls.Add(Me.ebPorcentajeDscto)
        Me.explorerBar3.Controls.Add(Me.lblLabel1)
        Me.explorerBar3.Controls.Add(Me.lblLabel21)
        Me.explorerBar3.Controls.Add(Me.Label5)
        Me.explorerBar3.Controls.Add(Me.Label6)
        Me.explorerBar3.Controls.Add(Me.Label14)
        Me.explorerBar3.Controls.Add(Me.Label15)
        Me.explorerBar3.Controls.Add(Me.Label16)
        Me.explorerBar3.Controls.Add(Me.Label17)
        Me.explorerBar3.Controls.Add(Me.Label24)
        Me.explorerBar3.Controls.Add(Me.Label20)
        Me.explorerBar3.Controls.Add(Me.ebCodigoArticulo)
        Me.explorerBar3.Controls.Add(Me.ebDescripcionArticulo)
        Me.explorerBar3.Controls.Add(Me.Label11)
        Me.explorerBar3.Controls.Add(Me.Label13)
        Me.explorerBar3.Controls.Add(Me.Label12)
        Me.explorerBar3.Controls.Add(Me.Label10)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Expanded = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos del Artículo"
        Me.explorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.explorerBar3.Location = New System.Drawing.Point(16, 384)
        Me.explorerBar3.Name = "explorerBar3"
        Me.explorerBar3.Size = New System.Drawing.Size(392, 216)
        Me.explorerBar3.TabIndex = 14
        Me.explorerBar3.Text = "ExplorerBar3"
        Me.explorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'chkDip
        '
        Me.chkDip.AutoCheck = False
        Me.chkDip.BackColor = System.Drawing.Color.Transparent
        Me.chkDip.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDip.Location = New System.Drawing.Point(256, 176)
        Me.chkDip.Name = "chkDip"
        Me.chkDip.Size = New System.Drawing.Size(120, 23)
        Me.chkDip.TabIndex = 24
        Me.chkDip.TabStop = False
        Me.chkDip.Text = "Catalogo Dip"
        Me.chkDip.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebMontoDscto
        '
        Me.ebMontoDscto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMontoDscto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMontoDscto.BackColor = System.Drawing.Color.Ivory
        Me.ebMontoDscto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMontoDscto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebMontoDscto.Location = New System.Drawing.Point(256, 148)
        Me.ebMontoDscto.MaxLength = 5
        Me.ebMontoDscto.Name = "ebMontoDscto"
        Me.ebMontoDscto.ReadOnly = True
        Me.ebMontoDscto.Size = New System.Drawing.Size(104, 22)
        Me.ebMontoDscto.TabIndex = 22
        Me.ebMontoDscto.TabStop = False
        Me.ebMontoDscto.Text = "$0.00"
        Me.ebMontoDscto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMontoDscto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.ebMontoDscto.Visible = False
        Me.ebMontoDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCorrida
        '
        Me.txtCorrida.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCorrida.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCorrida.BackColor = System.Drawing.Color.Ivory
        Me.txtCorrida.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrida.Location = New System.Drawing.Point(123, 95)
        Me.txtCorrida.Name = "txtCorrida"
        Me.txtCorrida.ReadOnly = True
        Me.txtCorrida.Size = New System.Drawing.Size(65, 22)
        Me.txtCorrida.TabIndex = 17
        Me.txtCorrida.TabStop = False
        Me.txtCorrida.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 96)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 23)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "Corrida"
        '
        'ebTallaAl
        '
        Me.ebTallaAl.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaAl.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaAl.BackColor = System.Drawing.Color.Ivory
        Me.ebTallaAl.DecimalDigits = 1
        Me.ebTallaAl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTallaAl.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebTallaAl.Location = New System.Drawing.Point(304, 120)
        Me.ebTallaAl.Name = "ebTallaAl"
        Me.ebTallaAl.ReadOnly = True
        Me.ebTallaAl.Size = New System.Drawing.Size(56, 22)
        Me.ebTallaAl.TabIndex = 20
        Me.ebTallaAl.TabStop = False
        Me.ebTallaAl.Text = "0"
        Me.ebTallaAl.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTallaAl.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTallaDel
        '
        Me.ebTallaDel.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaDel.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaDel.BackColor = System.Drawing.Color.Ivory
        Me.ebTallaDel.DecimalDigits = 1
        Me.ebTallaDel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTallaDel.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebTallaDel.Location = New System.Drawing.Point(216, 120)
        Me.ebTallaDel.Name = "ebTallaDel"
        Me.ebTallaDel.ReadOnly = True
        Me.ebTallaDel.Size = New System.Drawing.Size(56, 22)
        Me.ebTallaDel.TabIndex = 19
        Me.ebTallaDel.TabStop = False
        Me.ebTallaDel.Text = "0"
        Me.ebTallaDel.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTallaDel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebExistencias
        '
        Me.ebExistencias.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebExistencias.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebExistencias.BackColor = System.Drawing.Color.Ivory
        Me.ebExistencias.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebExistencias.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebExistencias.Location = New System.Drawing.Point(304, 94)
        Me.ebExistencias.Name = "ebExistencias"
        Me.ebExistencias.ReadOnly = True
        Me.ebExistencias.Size = New System.Drawing.Size(56, 22)
        Me.ebExistencias.TabIndex = 18
        Me.ebExistencias.TabStop = False
        Me.ebExistencias.Text = "0"
        Me.ebExistencias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebExistencias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebExistencias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPrecioArticulo
        '
        Me.ebPrecioArticulo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPrecioArticulo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPrecioArticulo.BackColor = System.Drawing.Color.Ivory
        Me.ebPrecioArticulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPrecioArticulo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebPrecioArticulo.Location = New System.Drawing.Point(123, 184)
        Me.ebPrecioArticulo.Name = "ebPrecioArticulo"
        Me.ebPrecioArticulo.ReadOnly = True
        Me.ebPrecioArticulo.Size = New System.Drawing.Size(104, 22)
        Me.ebPrecioArticulo.TabIndex = 23
        Me.ebPrecioArticulo.TabStop = False
        Me.ebPrecioArticulo.Text = "$0.00"
        Me.ebPrecioArticulo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPrecioArticulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPorcentajeDscto
        '
        Me.ebPorcentajeDscto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPorcentajeDscto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPorcentajeDscto.BackColor = System.Drawing.Color.Ivory
        Me.ebPorcentajeDscto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPorcentajeDscto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.ebPorcentajeDscto.Location = New System.Drawing.Point(123, 148)
        Me.ebPorcentajeDscto.MaxLength = 5
        Me.ebPorcentajeDscto.Name = "ebPorcentajeDscto"
        Me.ebPorcentajeDscto.ReadOnly = True
        Me.ebPorcentajeDscto.Size = New System.Drawing.Size(104, 22)
        Me.ebPorcentajeDscto.TabIndex = 21
        Me.ebPorcentajeDscto.TabStop = False
        Me.ebPorcentajeDscto.Text = "0.00 %"
        Me.ebPorcentajeDscto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPorcentajeDscto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.ebPorcentajeDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(280, 122)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(28, 23)
        Me.lblLabel1.TabIndex = 63
        Me.lblLabel1.Text = "Al"
        '
        'lblLabel21
        '
        Me.lblLabel21.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel21.Location = New System.Drawing.Point(184, 122)
        Me.lblLabel21.Name = "lblLabel21"
        Me.lblLabel21.Size = New System.Drawing.Size(28, 23)
        Me.lblLabel21.TabIndex = 62
        Me.lblLabel21.Text = "Del"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(107, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 23)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(107, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 23)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = ":"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(107, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 23)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(107, 178)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 23)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(107, 148)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(16, 23)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = ":"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(107, 71)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 23)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = ":"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(226, 96)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 23)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "Existencias"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 122)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 23)
        Me.Label20.TabIndex = 54
        Me.Label20.Text = "Tallas"
        '
        'ebCodigoArticulo
        '
        Me.ebCodigoArticulo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoArticulo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoArticulo.BackColor = System.Drawing.Color.Ivory
        Me.ebCodigoArticulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoArticulo.Location = New System.Drawing.Point(123, 40)
        Me.ebCodigoArticulo.Name = "ebCodigoArticulo"
        Me.ebCodigoArticulo.ReadOnly = True
        Me.ebCodigoArticulo.Size = New System.Drawing.Size(237, 22)
        Me.ebCodigoArticulo.TabIndex = 15
        Me.ebCodigoArticulo.TabStop = False
        Me.ebCodigoArticulo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoArticulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcionArticulo
        '
        Me.ebDescripcionArticulo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcionArticulo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcionArticulo.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcionArticulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcionArticulo.Location = New System.Drawing.Point(123, 67)
        Me.ebDescripcionArticulo.Name = "ebDescripcionArticulo"
        Me.ebDescripcionArticulo.ReadOnly = True
        Me.ebDescripcionArticulo.Size = New System.Drawing.Size(237, 22)
        Me.ebDescripcionArticulo.TabIndex = 16
        Me.ebDescripcionArticulo.TabStop = False
        Me.ebDescripcionArticulo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcionArticulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 23)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Código"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 23)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Precio"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 23)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Descuento"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Descripción"
        '
        'explorerBar2
        '
        Me.explorerBar2.Controls.Add(Me.nebTotalPiezas)
        Me.explorerBar2.Controls.Add(Me.lblTotalPiezas)
        Me.explorerBar2.Controls.Add(Me.prgProgressBar1)
        Me.explorerBar2.Controls.Add(Me.ebDescuentoTotal)
        Me.explorerBar2.Controls.Add(Me.Label27)
        Me.explorerBar2.Controls.Add(Me.ebImporteTotal)
        Me.explorerBar2.Controls.Add(Me.ebIVA)
        Me.explorerBar2.Controls.Add(Me.ebSubTotal)
        Me.explorerBar2.Controls.Add(Me.Label21)
        Me.explorerBar2.Controls.Add(Me.Label22)
        Me.explorerBar2.Controls.Add(Me.Label23)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Expanded = False
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Totales"
        Me.explorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.explorerBar2.Location = New System.Drawing.Point(416, 384)
        Me.explorerBar2.Name = "explorerBar2"
        Me.explorerBar2.Size = New System.Drawing.Size(248, 176)
        Me.explorerBar2.TabIndex = 25
        Me.explorerBar2.Text = "ExplorerBar2"
        Me.explorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebTotalPiezas
        '
        Me.nebTotalPiezas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebTotalPiezas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebTotalPiezas.BackColor = System.Drawing.Color.Ivory
        Me.nebTotalPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebTotalPiezas.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebTotalPiezas.Location = New System.Drawing.Point(120, 32)
        Me.nebTotalPiezas.Name = "nebTotalPiezas"
        Me.nebTotalPiezas.ReadOnly = True
        Me.nebTotalPiezas.Size = New System.Drawing.Size(104, 22)
        Me.nebTotalPiezas.TabIndex = 26
        Me.nebTotalPiezas.TabStop = False
        Me.nebTotalPiezas.Text = "0"
        Me.nebTotalPiezas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTotalPiezas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebTotalPiezas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.AutoSize = True
        Me.lblTotalPiezas.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPiezas.Location = New System.Drawing.Point(16, 40)
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Size = New System.Drawing.Size(79, 14)
        Me.lblTotalPiezas.TabIndex = 25
        Me.lblTotalPiezas.Text = "Total Piezas"
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(16, 128)
        Me.prgProgressBar1.Name = "prgProgressBar1"
        Me.prgProgressBar1.Size = New System.Drawing.Size(216, 2)
        Me.prgProgressBar1.TabIndex = 24
        '
        'ebDescuentoTotal
        '
        Me.ebDescuentoTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescuentoTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescuentoTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebDescuentoTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescuentoTotal.ForeColor = System.Drawing.Color.Red
        Me.ebDescuentoTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebDescuentoTotal.Location = New System.Drawing.Point(120, 144)
        Me.ebDescuentoTotal.Name = "ebDescuentoTotal"
        Me.ebDescuentoTotal.ReadOnly = True
        Me.ebDescuentoTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebDescuentoTotal.TabIndex = 30
        Me.ebDescuentoTotal.TabStop = False
        Me.ebDescuentoTotal.Text = "$0.00"
        Me.ebDescuentoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDescuentoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(16, 144)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 16)
        Me.Label27.TabIndex = 23
        Me.Label27.Text = "Dscto. Total"
        '
        'ebImporteTotal
        '
        Me.ebImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporteTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebImporteTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebImporteTotal.Location = New System.Drawing.Point(120, 104)
        Me.ebImporteTotal.Name = "ebImporteTotal"
        Me.ebImporteTotal.ReadOnly = True
        Me.ebImporteTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebImporteTotal.TabIndex = 29
        Me.ebImporteTotal.TabStop = False
        Me.ebImporteTotal.Text = "$0.00"
        Me.ebImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebIVA
        '
        Me.ebIVA.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebIVA.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebIVA.BackColor = System.Drawing.Color.Ivory
        Me.ebIVA.DecimalDigits = 2
        Me.ebIVA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebIVA.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebIVA.Location = New System.Drawing.Point(120, 80)
        Me.ebIVA.Name = "ebIVA"
        Me.ebIVA.ReadOnly = True
        Me.ebIVA.Size = New System.Drawing.Size(104, 22)
        Me.ebIVA.TabIndex = 28
        Me.ebIVA.TabStop = False
        Me.ebIVA.Text = "$0.00"
        Me.ebIVA.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebIVA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSubTotal
        '
        Me.ebSubTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSubTotal.BackColor = System.Drawing.Color.Ivory
        Me.ebSubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSubTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebSubTotal.Location = New System.Drawing.Point(120, 56)
        Me.ebSubTotal.Name = "ebSubTotal"
        Me.ebSubTotal.ReadOnly = True
        Me.ebSubTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebSubTotal.TabIndex = 27
        Me.ebSubTotal.TabStop = False
        Me.ebSubTotal.Text = "$0.00"
        Me.ebSubTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(16, 112)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 16)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Importe Total"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(16, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 16)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "I.V.A."
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(16, 64)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 16)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Subtotal"
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowDelete = True
        Me.grdDetalle.BackColor = System.Drawing.Color.AliceBlue
        Me.grdDetalle.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.grdDetalle.ColumnInfo = resources.GetString("grdDetalle.ColumnInfo")
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.Location = New System.Drawing.Point(16, 328)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Rows.Count = 10
        Me.grdDetalle.Rows.DefaultSize = 19
        Me.grdDetalle.Rows.Fixed = 0
        Me.grdDetalle.Size = New System.Drawing.Size(648, 48)
        Me.grdDetalle.StyleInfo = resources.GetString("grdDetalle.StyleInfo")
        Me.grdDetalle.TabIndex = 72
        Me.grdDetalle.Visible = False
        '
        'ebCodCaja
        '
        Me.ebCodCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.BackColor = System.Drawing.Color.Ivory
        Me.ebCodCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodCaja.Location = New System.Drawing.Point(609, 34)
        Me.ebCodCaja.MaxLength = 2
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.ReadOnly = True
        Me.ebCodCaja.Size = New System.Drawing.Size(56, 22)
        Me.ebCodCaja.TabIndex = 3
        Me.ebCodCaja.TabStop = False
        Me.ebCodCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebCodCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(542, 34)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 23)
        Me.Label18.TabIndex = 84
        Me.Label18.Text = "Caja No  :"
        '
        'ebCodVendedor
        '
        Me.ebCodVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodVendedor.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodVendedor.ButtonImage = CType(resources.GetObject("ebCodVendedor.ButtonImage"), System.Drawing.Image)
        Me.ebCodVendedor.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodVendedor.Location = New System.Drawing.Point(128, 118)
        Me.ebCodVendedor.MaxLength = 10
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(136, 22)
        Me.ebCodVendedor.TabIndex = 9
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnFormaPago
        '
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.Location = New System.Drawing.Point(416, 568)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(248, 32)
        Me.btnFormaPago.TabIndex = 31
        Me.btnFormaPago.Text = "&Forma de Pago"
        Me.btnFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteID.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebClienteID.Location = New System.Drawing.Point(128, 90)
        Me.ebClienteID.MaxLength = 10
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(136, 22)
        Me.ebClienteID.TabIndex = 7
        Me.ebClienteID.Text = "0"
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebClienteID.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioApartado
        '
        Me.ebFolioApartado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.BackColor = System.Drawing.Color.Ivory
        Me.ebFolioApartado.Enabled = False
        Me.ebFolioApartado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioApartado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioApartado.Location = New System.Drawing.Point(128, 62)
        Me.ebFolioApartado.MaxLength = 6
        Me.ebFolioApartado.Name = "ebFolioApartado"
        Me.ebFolioApartado.Size = New System.Drawing.Size(96, 22)
        Me.ebFolioApartado.TabIndex = 4
        Me.ebFolioApartado.TabStop = False
        Me.ebFolioApartado.Text = "0"
        Me.ebFolioApartado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioApartado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioApartado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioFactura
        '
        Me.ebFolioFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.BackColor = System.Drawing.Color.Ivory
        Me.ebFolioFactura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioFactura.Location = New System.Drawing.Point(128, 34)
        Me.ebFolioFactura.MaxLength = 6
        Me.ebFolioFactura.Name = "ebFolioFactura"
        Me.ebFolioFactura.ReadOnly = True
        Me.ebFolioFactura.Size = New System.Drawing.Size(88, 22)
        Me.ebFolioFactura.TabIndex = 61
        Me.ebFolioFactura.TabStop = False
        Me.ebFolioFactura.Text = "0"
        Me.ebFolioFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioFactura.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioFactura.Visible = False
        Me.ebFolioFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout1
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(349, 62)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(168, 22)
        Me.ebTipoVenta.TabIndex = 5
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaFactura
        '
        Me.ebFechaFactura.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ebFechaFactura.DropDownCalendar.FirstMonth = New Date(2022, 5, 1, 0, 0, 0, 0)
        Me.ebFechaFactura.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFactura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaFactura.Location = New System.Drawing.Point(349, 34)
        Me.ebFechaFactura.Name = "ebFechaFactura"
        Me.ebFechaFactura.ReadOnly = True
        Me.ebFechaFactura.Size = New System.Drawing.Size(168, 22)
        Me.ebFechaFactura.TabIndex = 2
        Me.ebFechaFactura.TabStop = False
        Me.ebFechaFactura.TodayButtonText = "Hoy"
        Me.ebFechaFactura.Value = New Date(2005, 9, 3, 0, 0, 0, 0)
        Me.ebFechaFactura.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'btnAltaCliente
        '
        Me.btnAltaCliente.Enabled = False
        Me.btnAltaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAltaCliente.Location = New System.Drawing.Point(544, 116)
        Me.btnAltaCliente.Name = "btnAltaCliente"
        Me.btnAltaCliente.Size = New System.Drawing.Size(120, 24)
        Me.btnAltaCliente.TabIndex = 11
        Me.btnAltaCliente.Text = "Alta de Cliente"
        Me.btnAltaCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebStatus
        '
        Me.ebStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebStatus.BackColor = System.Drawing.Color.Ivory
        Me.ebStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebStatus.Location = New System.Drawing.Point(609, 62)
        Me.ebStatus.MaxLength = 3
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.ReadOnly = True
        Me.ebStatus.Size = New System.Drawing.Size(56, 22)
        Me.ebStatus.TabIndex = 6
        Me.ebStatus.TabStop = False
        Me.ebStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerDescripcion
        '
        Me.ebPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebPlayerDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayerDescripcion.Location = New System.Drawing.Point(272, 118)
        Me.ebPlayerDescripcion.Name = "ebPlayerDescripcion"
        Me.ebPlayerDescripcion.ReadOnly = True
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(264, 21)
        Me.ebPlayerDescripcion.TabIndex = 10
        Me.ebPlayerDescripcion.TabStop = False
        Me.ebPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Cliente             :"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 23)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Player              :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Folio Factura    :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(229, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Fecha                :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Folio Apartado :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(229, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Tipo de Venta   :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(542, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 23)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Status   :"
        '
        'exbGuardarCliente
        '
        Me.exbGuardarCliente.Controls.Add(Me.pbAvance)
        Me.exbGuardarCliente.Controls.Add(Me.lblLabel14)
        Me.exbGuardarCliente.Location = New System.Drawing.Point(672, 112)
        Me.exbGuardarCliente.Name = "exbGuardarCliente"
        Me.exbGuardarCliente.Size = New System.Drawing.Size(328, 96)
        Me.exbGuardarCliente.TabIndex = 194
        Me.exbGuardarCliente.Text = "ExplorerBar2"
        Me.exbGuardarCliente.Visible = False
        Me.exbGuardarCliente.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'pbAvance
        '
        Me.pbAvance.Location = New System.Drawing.Point(8, 40)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ShowPercentage = True
        Me.pbAvance.Size = New System.Drawing.Size(312, 32)
        Me.pbAvance.TabIndex = 2
        '
        'lblLabel14
        '
        Me.lblLabel14.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel14.Location = New System.Drawing.Point(8, 8)
        Me.lblLabel14.Name = "lblLabel14"
        Me.lblLabel14.Size = New System.Drawing.Size(200, 40)
        Me.lblLabel14.TabIndex = 1
        Me.lblLabel14.Text = "Guardando Cliente ..."
        '
        'timer1
        '
        Me.timer1.Interval = 1000.0R
        Me.timer1.SynchronizingObject = Me
        '
        'frmFacturacionSinExistencia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(672, 667)
        Me.Controls.Add(Me.exbGuardarCliente)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFacturacionSinExistencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación ""Si Hay"""
        CType(Me.uICommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        CType(Me.PanelAgregarArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAgregarArticulo.ResumeLayout(False)
        Me.PanelAgregarArticulo.PerformLayout()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar3.ResumeLayout(False)
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar2.ResumeLayout(False)
        Me.explorerBar2.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exbGuardarCliente.ResumeLayout(False)
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (15.07.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit

#End Region

#Region "Environment Var"

#Region "Variables Generales"

    Dim TotalPiezasFactura As Integer = 0
    Dim vFolioFactura As Integer
    Dim vRowDelete As Boolean = False
    Dim vCodTipoDescuento As String
    Dim vCodArticulo As String
    Dim vNumeroArticulo As String
    Dim vNumStringArticulo As String
    Dim dsTipoVenta As New DataSet         'Dataset para cargar los tipos de venta
    Dim dsTallas As New DataSet             'Dataset para cargar las tallas de un articulo determinado
    Dim isFormLoad As Boolean = False
    'Variables Grid
    Dim vCodigo As String
    Dim vTalla As String
    Dim vCantidad As Decimal
    Dim vImporte As Decimal
    Dim vTotal As Decimal
    Dim vDescuento As Decimal
    Dim vDescuentoAdicional As Decimal = 0
    Dim vSaldarDescuentoAdicional As Decimal = 0
    Dim boolDescuentoDipsEspecial As Boolean = False
    'Dim boolDescuentoDPakete As Boolean = False
    Dim boolDescuentoSocioEspecial As Boolean = False
    'Variables Detalle
    Public dsDetalle As DataSet = New DataSet
    Dim dtMotivos As DataTable
    Private bolCloseForm As Boolean
    Private bolIsNewFacturaInput As Boolean = False
    Private bolIsOpenFacturaInput As Boolean = False
    '--Variable Condicion de Precio y ListaPrecios
    Dim strCondicionVenta As String = String.Empty
    Dim strListaPrecios As String = String.Empty

    '--Objeto del Limite de Credito SAP
    Dim oLimiteCreditoSAP As CreditoAsociadoSAP
    'Captura Manual
    Dim str As String = ""
    Dim strQuin As Integer
    Dim DPValeID As String = ""

    'Catalogo
    Dim strCat As String = ""
    Dim strLlevaCatalogo As String = ""
    'Motivos de captura manual
    Dim boolManual As Boolean = False
    Dim m_dtFormasPago As DataTable
    Public FacturaGuardada As Boolean
    Public bolNC As Boolean
    Dim CodTipoVentaTemp As String = ""
    Dim oCuponDesc As CuponDescuento
    'Dim dtDetalleTemp As DataTable
    Dim bolMenuAbrir As Boolean = False
    Dim bValidaProcesoBusquedaHuella As Boolean = False
    Dim value As String = ""
    Dim GridIndex As Integer = 0
    Dim dtDescFormasPago As DataTable
    Dim dtPromoAplicada As DataTable
    Dim bRechazoPromo As Boolean = False
    Dim modificar As Boolean = False
    Dim FormExistenciasSH As frmConsultaSiHay
    Private SerialId As String
    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 28/09/2017: Información de vale de electronico
    '--------------------------------------------------------------------------------------
    Private oDPValeSAP As cDPValeSAP

    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 06/12/2017: Corrección DPPRO
    '--------------------------------------------------------------------------------------
    Private Color As String = ""
    Private ArtExistencia As New Hashtable()
    Private CodArticulo As String
#End Region

#Region "Variables Objeto"

    'Objeto Notas Credito
    Public oNotaCreditoMgr As NotasCreditoManager
    Public oNotaCredito As NotaCredito

    'Objeto ValeCaja
    Public oValeCajaMgr As ValeCajaManager
    Public oValeCaja As ValeCaja

    'Objeto Factura
    Dim oFacturaMgr As FacturaManager
    Public oFactura As Factura

    'objeto SAP
    Public oSAPMgr As ProcesoSAPManager

    'Vales DescuentoInfo
    Dim oValeDescuentoLocalInfo As New ValesDescuentoInfo

    'Objeto Avisos Factura
    Dim oAvisoFacturaMgr As AvisosFacturaManager
    Dim oAvisosFactura As AvisosFactura

    'Objeto FacturaCorrida
    Dim oFacturaCorridaMgr As FacturaCorridaManager

    'Objeto Artículo
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Objeto Cliente
    Dim oClienteMgr As ClientesManager
    Dim oCliente As ClienteAlterno

    'Objeto Player
    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    'Objeto Asociado
    Dim oAsociadoMgr As AsociadosManager
    Dim oAsociado As Asociado

    'Objeto Creditos en Tienda
    'Dim oCreditoEnTienda As wsCreditosEnTienda.CreditoCreditosEnTienda
    'Dim OCreditoEnTiendaInfo As wsCreditosEnTienda.CreditoEnTiendaInfo

    'Objeto Contrato
    Dim oContratoMgr As ContratoManager
    Dim oContratoInfo As Contrato
    Dim oContratoTemp As Contrato

    '--Objetos Condiciones de Venta
    Dim oCondicionVenta As CondicionesVtaSAP

    'Objeto FingerPrint
    Dim oFingerP As FingerPrint
    Dim oFingerPrintMgr As FingerPrintManager

    'Objeto Firmas
    Dim oFirmasMgr As FirmaManager

    'Objeto Vale Empleado
    Dim oValeE As ValeEmpleado
    Dim promociones As DataTable
    Dim oFPMgr As CatalogoFormasPagoManager
    Private RestService As New ProcesosRetail("", "POST")

#End Region

#Region "Variables Facturacion Devolucion DPVale"

    Dim vNCInstance As Boolean = False
    Dim oDevolucionDPvale As New DevolucionDPValeInfo
    Dim vNCFacturada As Boolean = False
#End Region

#Region "Variables Facturacion Contrato"

    Dim vApartadoInstance As Boolean = False

#End Region

#Region "Variables SiHay"
    Private SiHay As DataSet = Nothing
    Private Pedido As Pedidos = Nothing
    Private dtCantidadLibre As DataTable = Nothing
#End Region

#End Region

#Region "Initialize"

    Private Sub InitializeObjects()

        'Objeto Nota Credito
        'Fonacot Facilito change
        oNotaCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        If oNotaCredito Is Nothing Then
            oNotaCredito = oNotaCreditoMgr.Create
        End If

        'Objeto ValeCaja
        'Fonacot Facilito change
        oValeCajaMgr = New ValeCajaManager(oAppContext)
        If oValeCaja Is Nothing Then
            oValeCaja = oValeCajaMgr.Create
        End If


        'Objeto Factura
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFactura = oFacturaMgr.Create

        'Obejto SAP
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        'Objeto AvisosFactura
        oAvisoFacturaMgr = New AvisosFacturaManager(oAppContext)
        oAvisosFactura = oAvisoFacturaMgr.Create

        'Objeto Factura
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)

        'Objeto Artículo
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

        'Objeto Cliente
        oClienteMgr = New ClientesManager(oAppContext)
        oCliente = oClienteMgr.CreateAlterno

        'Objeto Vendedores
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        'Objeto Asociado
        oAsociadoMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadoMgr.Create

        'Objeto Credito En Tienda WS
        'oCreditoEnTienda = New wsCreditosEnTienda.CreditoCreditosEnTienda
        'OCreditoEnTiendaInfo = New wsCreditosEnTienda.CreditoEnTiendaInfo

        'If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    oCreditoEnTienda.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
        '    oCreditoEnTienda.strURL.TrimStart("/")

        'End If

        '--Objeto Condiciones de Venta
        oCondicionVenta = New CondicionesVtaSAP
        oCondicionVenta.Clear()

        'Obejto FingerPrint
        oFingerPrintMgr = New FingerPrintManager(oAppContext, oConfigCierreFI) ', oAppSAPConfig.OficinaVenta)

        'Objeto Firmas
        oFirmasMgr = New FirmaManager(oAppContext, oConfigCierreFI)
        SetEstructuraPromoAplicada()
        oFPMgr = New CatalogoFormasPagoManager(oAppContext)
        SiHay = New DataSet
        oFactura.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
    End Sub

    Private Sub InitializeDisplayPromociones()
        Me.promociones = New DataTable("Promociones")
        Me.promociones.Columns.Add("Promociones", GetType(String))
        Me.promociones.AcceptChanges()
    End Sub

    Private Sub InitializeBinding()

        'Objeto Factura
        ebFolioFactura.DataBindings.Add(New Binding("Value", oFactura, "FolioFactura"))
        ebFechaFactura.DataBindings.Add(New Binding("Value", oFactura, "Fecha"))
        'ebFolioApartado.DataBindings.Add(New Binding("Value", oFactura, "ApartadoID"))
        ebTipoVenta.DataBindings.Add(New Binding("Value", oFactura, "CodTipoVenta"))
        ebStatus.DataBindings.Add(New Binding("Text", oFactura, "StatusFactura"))
        ebClienteID.DataBindings.Add(New Binding("Value", oFactura, "ClienteID"))
        ebCodVendedor.DataBindings.Add(New Binding("Text", oFactura, "CodVendedor"))
        ebCodCaja.DataBindings.Add(New Binding("Text", oFactura, "CodCaja"))
        ebSubTotal.DataBindings.Add(New Binding("Value", oFactura, "SubTotal"))
        ebIVA.DataBindings.Add(New Binding("Value", oFactura, "IVA"))
        ebImporteTotal.DataBindings.Add(New Binding("Value", oFactura, "Total"))
        ebDescuentoTotal.DataBindings.Add(New Binding("Value", oFactura, "DescTotal"))
        EbFolioSAP.DataBindings.Add(New Binding("Text", oFactura, "FolioSAP"))
        txtFolioVentaManual.DataBindings.Add(New Binding("Text", oFactura, "FolioNotaVentaManual"))

        'Objeto Articulo
        ebCodigoArticulo.DataBindings.Add(New Binding("Text", oArticulo, "CodArticulo"))
        ebDescripcionArticulo.DataBindings.Add(New Binding("Text", oArticulo, "Descripcion"))
        'ebDescuentoPromocion.DataBindings.Add(New Binding("Value", oArticulo, "Descuento"))
        'ebPrecioArticulo.DataBindings.Add(New Binding("Value", oArticulo, "PrecioOferta"))
        'ebPrecioArticulo.DataBindings.Add(New Binding("Value", oArticulo, "PrecioVenta"))
        ebTallaDel.DataBindings.Add(New Binding("Value", oFactura, "FacturaArticuloTallaDel"))
        ebTallaAl.DataBindings.Add(New Binding("Value", oFactura, "FacturaArticuloTallaAl"))
        ebExistencias.DataBindings.Add(New Binding("Value", oFactura, "FacturaArticuloExistencia"))
        txtCorrida.DataBindings.Add(New Binding("Text", oArticulo, "CodCorrida"))
        chkDip.DataBindings.Add(New Binding("Checked", oArticulo, "DIP"))

    End Sub

#End Region

#Region "Methods"

#Region "General Form Methods"

    Private Sub uICommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoAbrir"

                'LoadSearchFormFactura()
                LoadSearchFormFacturaJanus()

            Case "ToolBarImprimir", "menuArchivoImprimir"
                ' Futura implementacion
                If Not Me.Pedido Is Nothing Then
                    ImprimirPedido()
                Else
                    Dim ofrmPago As New frmPago
                    If oFactura.Impresa = True Then
                        ofrmPago.ActionPreview(oFactura.FacturaID, "Facturacion", True, "COPIA DE FACTURA", strQuin, True)
                    Else
                        ofrmPago.ActionPreview(oFactura.FacturaID, "Facturacion", True, "FACTURA", strQuin, True)
                    End If
                End If
            Case "menuFacturarDev"
                Dim strResult As String
                strResult = InputBox("Introduzca el folio del Vale de Caja: ", Me.Text, "", 400, 300)
                'MsgBox("El codigo es diferente al seleccionado!", MsgBoxStyle.Information, Me.Text)
                If strResult = "" Then Exit Sub

                'Objeto Nota Credito
                'Fonacot Facilito change
                oNotaCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                If oNotaCredito Is Nothing Then
                    oNotaCredito = oNotaCreditoMgr.Create
                End If

                'Objeto ValeCaja
                'Fonacot Facilito change
                oValeCajaMgr = New ValeCajaManager(oAppContext)
                If oValeCaja Is Nothing Then
                    oValeCaja = oValeCajaMgr.Create
                End If

                oValeCaja = oValeCajaMgr.Load(CInt(strResult))

                If Not (oValeCaja Is Nothing) Then

                    If oValeCaja.MontoUtilizado > 0 Then

                        MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " ya fue utilizado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                        Exit Sub

                    Else

                        If oValeCaja.StastusRegistro = False Then

                            MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " està deshabilitado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            Exit Sub

                            'Else

                            'Validamos si sobrepasamos el Total de la Deuda
                            'If (ebTotalPagoCliente.Value + oValeCaja.Importe) > oFactura.Total Then

                            'EBPago.Value = oFactura.Total - ebTotalPagoCliente.Value

                            'Else

                            '   EBPago.Value = oValeCaja.Importe

                            'End If

                        End If

                    End If

                Else

                    MsgBox("Folio del Vale de Caja no existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                    Exit Sub

                End If

                oNotaCredito = oNotaCreditoMgr.Load(oValeCaja.DocumentoID)

                'Fonacot Facilito change
                If Not oValeCaja.ValeCajaID = 0 Then
                    'Asigno el valor al tipo de venta
                    oFactura.CodTipoVenta = oNotaCredito.TipoVentaID
                    Me.ebTipoVenta.Value = oNotaCredito.TipoVentaID
                    Me.ebTipoVenta.Enabled = False

                    'Asigno el valor al codigo del cliente
                    oFactura.ClienteId = oNotaCredito.ClienteID
                    Me.ebClienteID.Text = oFactura.ClienteId
                    Me.ebClienteID.Enabled = False
                    Valida()

                    'Asigno el valor al codigo del vendedor
                    oFactura.CodVendedor = oNotaCredito.PlayerID
                    Me.ebCodVendedor.Text = oNotaCredito.PlayerID
                    Me.ebCodVendedor.Enabled = False
                    oVendedor.ClearFields()
                    oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

                    If oVendedor.ID <> String.Empty Then
                        ebPlayerDescripcion.Text = oVendedor.Nombre
                        'oFactura.CodVendedor = oVendedor.ID
                    Else
                        'MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación ")
                        'ebCodVendedor.Text = oFactura.CodVendedor
                        'e.Cancel = True
                    End If

                    Me.grdDetalle.Focus()

                End If

            Case "menuArchivoNuevo"

                NuevaFactura()

                ebTipoVenta.Focus()

            Case "menuArchivoApartado"

                Dim oAbrirApartado As New frmAbrirApartado

                oAbrirApartado.ShowDialog()

                If oAbrirApartado.DialogResult = DialogResult.OK Then

                    NuevaFactura()
                    vRowDelete = True
                    dsDetalle.Tables(0).Rows.Clear()
                    'dsDetalle.Tables(0).Rows(0).Delete()
                    dsDetalle.AcceptChanges()

                    'Objeto Contrato
                    oContratoInfo = Nothing
                    oContratoMgr = New ContratoManager(oAppContext)
                    oContratoInfo = oContratoMgr.Create

                    oContratoInfo = oAbrirApartado.oContrato

                    vApartadoInstance = True

                    'Cargamos articulos del apartado en el grid
                    'LoadDataofApartado()
                    LoadDataofApartadoJanus()
                    UiCommandBar2.Enabled = True
                    uICommandManager1.Commands("ToolBarAbrir").Enabled = Janus.Windows.UI.InheritableBoolean.False

                End If

                oAbrirApartado.Dispose()
                oAbrirApartado = Nothing

            Case "ToolBarNuevo"

                If vApartadoInstance Then

                    uICommandManager1.CommandBars(0).Enabled = True
                    uICommandManager1.CommandBars(1).Enabled = True
                    uICommandManager1.Commands("ToolBarAbrir").Enabled = Janus.Windows.UI.InheritableBoolean.True

                    ebTipoVenta.Enabled = True
                    ebCodVendedor.Enabled = True
                    ebClienteID.Enabled = True
                    vApartadoInstance = False

                End If

                NuevaFactura()

                explorerBar1.Enabled = True

                ebTipoVenta.Focus()

            Case "ToolBarAbrir"

                'LoadSearchFormFactura()
                LoadSearchFormFacturaJanus()

            Case "menuArchivoSalir"

                Me.Close()


            Case "MnuCargarArticulosSiHay"
                '----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 03/05/2013: Abrir un pedido si hay
                '----------------------------------------------------------------------------------------------------------------------
                LoadSearchFormPedido()

            Case "MnuModificarBeneficiario"
                ModificarBeneficiario()

        End Select

    End Sub

    Private Sub GuardadoAutomatico(ByVal strClienteID As String, ByVal CodTipoVenta As String)
        Me.pbAvance.Value = 0
        Me.pbAvance.Minimum = 0
        Me.pbAvance.Maximum = 2
        Me.exbGuardarCliente.Left = 168
        Me.exbGuardarCliente.Top = 96
        Me.exbGuardarCliente.Visible = True
        Application.DoEvents()
        Me.pbAvance.Value = 1
        AltadeCliente(strClienteID, CodTipoVenta)
        Me.pbAvance.Value = 2
        Me.exbGuardarCliente.Visible = False
    End Sub

    Private Sub frmFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 21/05/2013: Se encapsulo en un procedimiento para poderlo llamar desde otros formularios
        '---------------------------------------------------------------------------------------------------------------------------------------
        LoadFactura()
    End Sub

    Public Sub LoadFactura()
        Me.ebFechaFactura.Text = Format(ebFechaFactura.Value, "dd - MMMM - yyyy")

        InitializeObjects()

        InitializeBinding()

        FillTipoVenta()

        isFormLoad = True

        LoadFolioFactura()

        If (bolCloseForm = True) Then
            Me.Close()
            Exit Sub
        End If

        CreateTempData()

        If vApartadoInstance Then

            'Cargamos articulos del apartado en el grid
            'LoadDataofApartado()
            LoadDataofApartadoJanus()

        End If

        'Verificamos si la factura es instancia de NOTA DE CREDITO
        If vNCInstance Then

            LoadDataofNotaCredito()

        End If

        If Not vApartadoInstance And Not vNCInstance Then

            With oAppContext.ApplicationConfiguration

                If (.Descuento < .DsctoCompra3MasDIP) Or (.Descuento < .DsctoCompra3MasNoDIP) Or (.Descuento < .DsctoCompra3oMenosDIP) Or (.Descuento < .DsctoCompra3oMenosNoDIP) Then

                    MsgBox("Configuración de Descuentos de Asociados Incorrecta. Deben ser menores o iguales al descuento máximo.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Factura")

                    Me.Close()

                End If

                If .CodigosXFactura <= 0 Then

                    MsgBox("No tiene configurada la cantidad de códigos por factura.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Factura")

                End If

            End With

        End If

        'Fonacot Facilito change
        If Not oValeCaja.ValeCajaID = 0 Then
            'Asigno el valor al tipo de venta
            oFactura.CodTipoVenta = oNotaCredito.TipoVentaID
            Me.ebTipoVenta.Value = oNotaCredito.TipoVentaID
            Me.ebTipoVenta.Enabled = False

            'Asigno el valor al codigo del cliente
            oFactura.ClienteId = oNotaCredito.ClienteID
            Me.ebClienteID.Text = oFactura.ClienteId
            Me.ebClienteID.Enabled = False
            Valida()

            'Asigno el valor al codigo del vendedor
            oFactura.CodVendedor = oNotaCredito.PlayerID
            Me.ebCodVendedor.Text = oNotaCredito.PlayerID
            Me.ebCodVendedor.Enabled = False
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                ebPlayerDescripcion.Text = oVendedor.Nombre
                'oFactura.CodVendedor = oVendedor.ID
            Else
                'MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación ")
                'ebCodVendedor.Text = oFactura.CodVendedor
                'e.Cancel = True
            End If

            Me.grdDetalle.Focus()

        End If


        'ALLOW
        Me.grdDetalle.Cols(0).AllowEditing = False
        boolManual = False
        Me.ebTipoVenta.Focus()

        'If oConfigCierreFI.UsarHuellas = False Then

        '    Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Visible = Janus.Windows.UI.InheritableBoolean.False

        'Else

        '    Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False
        '    'Dim strValor As String = oFingerPrintMgr.GetCongif("HuellaOpcional").Trim.ToUpper
        '    'If strValor.Trim = "" Then strValor = "SI"
        '    'If strValor.Trim <> "SI" Then
        '    '    Me.ebClienteID.ReadOnly = True
        '    'End If
        '    If oConfigCierreFI.HuellaOpcional = False Then
        '        Me.ebClienteID.ReadOnly = True
        '    End If

        'End If

        If oConfigCierreFI.ShowManagerPC Then
            MostrarCronometro()
        End If
    End Sub

    Public Function cargarDetalleCupon(ByVal dsDetalles As DataTable) As DataTable
        Dim dsCupon As DataTable = New DataTable("CuponDetalles")
        dsCupon.Columns.Add("MATERIAL", GetType(String))
        dsCupon.Columns.Add("TALLA", GetType(String))
        dsCupon.Columns.Add("CANTIDAD", GetType(Integer))
        dsCupon.AcceptChanges()
        For Each row As DataRow In dsDetalles.Rows
            Dim cupon As DataRow = dsCupon.NewRow()
            cupon("MATERIAL") = row("Codigo")
            cupon("TALLA") = row("Talla")
            cupon("CANTIDAD") = row("Cantidad")
            dsCupon.Rows.Add(cupon)
        Next
        dsCupon.AcceptChanges()
        Return dsCupon
    End Function

    Private Sub btnFormaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormaPago.Click
        btnFormaPago.Enabled = False
        FormaPago()
        btnFormaPago.Enabled = True
        '        btnFormaPago.Focus()

        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        'FLIZARRAGA 28/09/2018: Validar que no haya dos tarjetas de lealtad en el pedido
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        If ValidarTarjetaLealtadEnDetalle() = False Then
        '            Exit Sub
        '        End If

        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        'FLIZARRAGA 18/04/2013: Validar Existencia en SiHay
        '        '-----------------------------------------------------------------------------------------------------------------------------------------

        '        Dim minima As DataTable
        '        SiHay = New DataSet
        '        ActualizarExistenciasSH()
        '        If EsVentaSiHay() = True Then
        '            If ValidarExistenciaSiHay() = False OrElse ValidarImporteMinimoSH() = False OrElse ValidarDescuentoMaximoSH() = False Then
        '                Exit Sub
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------
        '            'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '            '-----------------------------------------------------------------------------------------------------------------------------
        '            If FacturacionSiHay > 0 Then
        '                Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        '                Me.dtCantidadLibre = RestarCantidadesSiHay(Me.dsDetalle.Tables(0))
        '                If ValidarMaterialesNegadosSH(Me.dtCantidadLibre, dtNegadosSH, "PF,P,RP", vApartadoInstance) = False Then
        '                    ShowFormNegadosSH(dtNegadosSH)
        '                    Exit Sub
        '                End If
        '            End If

        '            FormExistenciasSH = New frmConsultaSiHay
        '            FormExistenciasSH.CargarExistenciasMinimos(GetArticulosSinExistencia())
        '            If FormExistenciasSH.FueAceptadoMinimos() = False Then
        '                Exit Sub
        '            End If
        '            minima = FormExistenciasSH.GetDataSourceMinimo()
        '            If Not minima Is Nothing Then
        '                SiHay.Tables.Add(minima)
        '            End If
        '        Else
        '            MessageBox.Show("No se puede facturar productos que haya existencias en la Tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Sub
        '        End If


        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        'Validar Inicio de Dia
        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        Dim oInicioDiaMgr As New InicioDiaManager(oAppContext)
        '        If oInicioDiaMgr.Load(Format(Date.Now, "Short Date"), oAppContext.ApplicationConfiguration.Almacen) = 0 Then
        '            MsgBox("El Dia " & Format(Date.Now, "dd-MMM-yyyy") & " no ha sido Iniciado." & vbCrLf & "Verifique la Fecha del Sistema Operativo.", MsgBoxStyle.Exclamation, "DPTienda")
        '            oInicioDiaMgr = Nothing
        '            Exit Sub
        '        End If
        '        oInicioDiaMgr = Nothing
        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        'Validar Cierre de Dia
        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        Dim oCierreDiasMgr As New CierreDiaManager(oAppContext)
        '        If (oCierreDiasMgr.ValidarCierreDia(Date.Now) = False) Then
        '            MsgBox("El Dia " & Format(Date.Now, "dd-MMM-yyyy") & " se encuentra Cerrado." & vbCrLf & "Verifique la Fecha del Sistema Operativo.", MsgBoxStyle.Exclamation, "DPTienda")
        '            oCierreDiasMgr = Nothing
        '            Exit Sub
        '        End If
        '        oCierreDiasMgr = Nothing
        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        'Validaciones Generales
        '        '-----------------------------------------------------------------------------------------------------------------------------------------
        '        If oFactura.Total > 0 Then
        '            If oConfigCierreFI.UsarHuellas Then
        '                If (oFactura.ClienteId = 10000000 Or oFactura.ClienteId = 0) AndAlso (oFactura.CodTipoVenta <> "P" OrElse oConfigCierreFI.RegistroPGOpcional = False) Then
        '                    MsgBox("Asigne Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
        '                    ebClienteID.Focus()
        '                    Exit Sub
        '                End If
        '            Else
        '                If (oFactura.ClienteId = 10000000 Or oFactura.ClienteId = 0) AndAlso oFactura.CodTipoVenta = "P" Then
        '                    MsgBox("Asigne Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
        '                    ebClienteID.Focus()
        '                    Exit Sub
        '                End If
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'Validamos que ningun codigo cueste menos de 1 peso incluyendo el IVA para que no truen en SAP
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            Dim strMsg As String = ""
        '            If ValidaImporteCostoPorCodigo(dsDetalle.Tables(0), strMsg) = False Then
        '                MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'Validamos que si es PG si no capturan al cliente ponga la razon de no registro
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            If (ebTipoVenta.Value <> "P" AndAlso ebTipoVenta.Value <> "V" AndAlso ebTipoVenta.Value <> "E") AndAlso oFactura.ClienteId <= 1 Then
        '                MsgBox("Por el Tipo de Venta es necesario ingresar Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Facturación")
        '                ebClienteID.Focus()
        '                Exit Sub
        '            ElseIf ebTipoVenta.Value = "P" AndAlso oConfigCierreFI.UsarHuellas Then
        '                Dim FolioSAP As String = ""
        '                If oFactura.ClienteId <= 0 Then
        '                    If EsVentaSiHay() = True Then
        '                        If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
        '                            MessageBox.Show("Debe ingresar un cliente si quiere realizar una venta con formato SiHay", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                            Exit Sub
        '                        End If
        '                    Else
        '                        If MessageBox.Show("¿Desea registrar los datos del cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '                            If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
        '                                GoTo EspecificaRazon
        '                            End If
        '                        ElseIf oFactura.RazonRechazo.Trim = "" Then
        'EspecificaRazon:
        '                            'oFactura.RazonRechazo = InputBox("Especifique la razón por la que no registró los datos del cliente.", Me.Text)
        '                            Dim oFrmRazones As New frmRazonesRechazo
        '                            oFrmRazones.ModuloOrigen = "FA"
        '                            If oFrmRazones.ShowDialog = DialogResult.OK Then
        '                                oFactura.RazonRechazo = oFrmRazones.cmbRazones.Text
        '                                oFactura.RazonRechazoID = oFrmRazones.cmbRazones.Value
        '                                'End If
        '                                'If oFactura.RazonRechazo.Trim = "" OrElse oFactura.RazonRechazo.Trim.Length < 5 Then
        '                            Else
        '                                'MessageBox.Show("Es necesario seleccionar una razón de rechazo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                                'GoTo EspecificaRazon
        '                                Exit Sub
        '                            End If
        '                        End If
        '                    End If

        '                    'ElseIf oFingerPrintMgr.IsClientePGEnFactura(oFactura.ClienteId, FolioSAP) Then
        '                    '    oFactura.RazonRechazo = "El cliente ya habia sido registrado anteriormente con el codigo: " & CStr(oFactura.ClienteId).PadLeft(10, "0") & _
        '                    '                            " en la Factura: " & FolioSAP
        '                    '    oFactura.RazonRechazoID = 0
        '                Else
        '                    oFactura.RazonRechazo = ""
        '                    oFactura.RazonRechazoID = 0
        '                End If
        '            End If
        '            If oFactura.CodVendedor = String.Empty Then
        '                MsgBox("Asigne Código de Vendedor.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Facturación")
        '                ebCodVendedor.Focus()
        '                Exit Sub
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'Si es instancia de Nota de Credito
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            If vNCInstance = True Then
        '                If ebImporteTotal.Value < oDevolucionDPvale.MontoDPVale Then
        '                    Dim dif As Double
        '                    dif = oDevolucionDPvale.MontoDPVale - ebImporteTotal.Value
        '                    If Not (dif >= 0.01 AndAlso dif <= 0.99) Then
        '                        MsgBox("La compra debe ser igual o mayor a la cantidad devuelta a Dportenis Vale", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
        '                        grdDetalle.Focus()
        '                        Exit Sub
        '                    End If
        '                End If
        '            End If
        '            If oValeCaja.ValeCajaID > 0 Then
        '                If oFactura.Total < oValeCaja.Importe Then
        '                    MsgBox("La compra debe ser igual o mayor a la cantidad devuelta", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
        '                    grdDetalle.Focus()
        '                    Exit Sub
        '                End If
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'Catalogo
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            If oFactura.CodTipoVenta = "D" Then
        '                If strCat = "S" Then
        '                Else
        '                    If strLlevaCatalogo = "" Then
        '                        Dim strDesc As String = ""
        '                        For Each oRow As DataRow In dsDetalle.Tables(0).Rows
        '                            If oRow("Adicional") > 0 Then
        '                                strDesc = "S"
        '                                Exit For
        '                            Else
        '                                strDesc = ""
        '                            End If
        '                        Next

        '                        If strDesc = "S" Then
        '                            MsgBox("Este asociado no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Information, Me.Text)
        '                        Else
        '                            MsgBox("Este asociado no tiene descuento por que no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Information, Me.Text)
        '                        End If

        '                    End If
        '                End If
        '            End If
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'Si es Facilito se pide Autorizacion
        '            'Fonacot Facilito change --->And oValeCaja.ValeCajaID = 0
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            If oFactura.CodTipoVenta = "O" And oValeCaja.ValeCajaID = 0 Then
        '                Dim oAutorizacionFacilito As New frmAutorizacionFacilito(oFactura.NumeroFacilito)
        '                oAutorizacionFacilito.ShowMeByFactura(oFactura.ClienteId)
        '                If oAutorizacionFacilito.DialogResult = DialogResult.OK Then
        '                    oFactura.NumeroFacilito = oAutorizacionFacilito.txtNumeroAutorizacion.Text
        '                Else
        '                    MsgBox("Debe Ingresar Numero de Autorización. No se puede continuar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
        '                End If
        '                oAutorizacionFacilito.Dispose()
        '                oAutorizacionFacilito = Nothing
        '                If oFactura.NumeroFacilito = String.Empty Then
        '                    Exit Sub
        '                End If
        '            Else
        '                'Fonacot Facilito change --> el else
        '                If oNotaCredito.ID > 0 Then
        '                    oFactura.NumeroFacilito = oFacturaMgr.GetNumeroFacilito(oNotaCredito.ID)
        '                Else
        '                    oFactura.NumeroFacilito = "0"
        '                End If

        '            End If


        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'JNAVA (04.02.2015): Validamos que si NO aplica el CrossSelling, se revisan las promociones vigentes
        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            If oConfigCierreFI.AplicaCrossSelling = False Then
        '                '-----------------------------------------------------------------------------------------------------------------------------------------
        '                'Validamos si no cambiaron las promociones vigentes para la sucursal en el transcurso del dia
        '                '-----------------------------------------------------------------------------------------------------------------------------------------
        '                Dim dtPromos As DataTable
        '                If oSAPMgr.ZBAPI_CHECK_PROMOS_VIGENTES(dtPromos) = "A" Then
        '                    Dim oFrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

        '                    For Each oRowP As DataRow In dtPromos.Rows
        '                        'Realizamos la descarga de Descuentos Adicionales modificados en el dia actual
        '                        oFrmProcesoSAP.OpcDescAdi = CInt(oRowP!TipoDesc)
        '                        oFrmProcesoSAP.ShowDev("DescuentosAdicionales")
        '                        'Marcamos el registro en SAP para indicar que ya se actualizaron los descuentos modificados en el dia
        '                        oSAPMgr.ZBAPI_UPD_PROMOS_VIGENTES(CInt(oRowP!TipoDesc))
        '                    Next
        '                    'Aplicamos los descuentos adicionales de nuevo para actualizar la factura
        '                    grdDetalle_Validating(Nothing, Nothing)
        '                    'Le indicamos al player que los descuentos han cambiado
        '                    MessageBox.Show("Los Descuentos Adicionales han cambiado, favor de verificar de nuevo el detalle de la factura.", Me.Text, _
        '                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                    Exit Sub

        '                End If
        '            End If

        '            '----------------------------------------------------------------------------------------------------------------------------
        '            'Aplicamos la promocion especial si es que lleva (Cupon Descuento)
        '            '----------------------------------------------------------------------------------------------------------------------------
        '            Dim strFolioCupon As String = ""
        '            oCuponDesc = Nothing
        '            If Me.chkPromoEspecial.Checked Then
        '                strFolioCupon = InputBox("Especifique el Folio del Cupón", "Dportenis PRO", "").Trim.ToUpper
        '                If strFolioCupon.Trim <> "" Then
        '                    If ValidaPromoEspecial(strFolioCupon, oCuponDesc) = False Then
        '                        Exit Sub
        '                    End If
        '                Else
        '                    Exit Sub
        '                End If
        '            End If
        '            '------------------------------------------------------------------------------------------------
        '            'Validamos el vale de Empleado en caso de ser tipo de venta Empleado
        '            '------------------------------------------------------------------------------------------------
        '            oValeE = New ValeEmpleado
        '            If Me.ebTipoVenta.Value = "E" Then
        '                Dim oFrm As New frmValeEmpleado
        '                oFrm.ShowDialog()
        '                If oFrm.DialogResult = DialogResult.OK Then
        '                    oValeE = IIf(Not oFrm.ValeEmpleado Is Nothing, oFrm.ValeEmpleado, oValeE)
        '                    'AplicaPromocionesVigentes(oFrm.nebDescuento.Value * 100)
        '                    AplicarPromociones(oFrm.nebDescuento.Value * 100)
        '                Else
        '                    Exit Sub
        '                End If
        '            End If
        '            '------------------------------------------------------------------------------------------------------------------------------------
        '            'Si el cliente rechazo las promociones condicionadas por formas de pago y se arrepintio volvemos a aplicar las promociones vigentes
        '            'para preguntarle de nuevo si las acepta
        '            '------------------------------------------------------------------------------------------------------------------------------------
        '            If bRechazoPromo Then AplicarPromociones()
        '            '------------------------------------------------------------------------------------------------
        '            'Validamos Tipo de Descuento
        '            '------------------------------------------------------------------------------------------------
        'ValidaDescuentoAdicional:
        '            If vDescuentoAdicional > 0 Then     '--'If oFactura.DescTotal > 0 Then -- NO APLICA
        '                '--------------------------------------------------------------------------------------------------------------------------------
        '                'Si tiene promociones aplicadas revisamos si estas promociones estan condicionadas por formas de pago especificas para preguntar
        '                'al cliente si desea aprovechar las promociones pagando con estas formas de pago o no
        '                '--------------------------------------------------------------------------------------------------------------------------------
        '                If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then
        '                    If ValidaPromosFormasPago() = False Then GoTo ValidaDescuentoAdicional
        '                End If
        '                If vApartadoInstance Then
        '                    vCodTipoDescuento = oContratoInfo.TipoDescuentoID
        '                    AbrirFormaPago(vCodTipoDescuento)
        '                Else
        'EligeTipoDescuento:
        '                    'oValidaDescuento.TipoVenta = IIf(ebTipoVenta.Value = "D", "C", ebTipoVenta.Value)
        '                    oValidaDescuento = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.frmValidaTipoDescuento(oAppContext)
        '                    oValidaDescuento.TipoVenta = IIf(ebTipoVenta.Value = "D", "C", IIf(ebTipoVenta.Value = "I", "P", IIf(ebTipoVenta.Value = "S", "P", ebTipoVenta.Value)))
        '                    oValidaDescuento.FolioVale = oValeDescuentoLocalInfo.FolioVale
        '                    oValidaDescuento.Sucursal = oValeDescuentoLocalInfo.Sucursal
        '                    oValidaDescuento.TipoVale = oValeDescuentoLocalInfo.TipoVale

        '                    'Añadimos Evento A TipoDescuento
        '                    AddHandler oValidaDescuento.ebCodTipoDescuento.ValueChanged, AddressOf ebCodTipoDescuento_ValueChanged
        '                    '

        '                    'oValidaDescuento.ShowDialog()
        '                    If Me.ebTipoVenta.Value = "D" OrElse Me.ebTipoVenta.Value = "S" Then
        '                        vCodTipoDescuento = "DCD"
        '                    ElseIf Me.ebTipoVenta.Value = "E" Then
        '                        vCodTipoDescuento = "DVD"
        '                    Else
        '                        vCodTipoDescuento = "DMA"
        '                    End If

        '                    'If oValidaDescuento.DialogResult = DialogResult.OK Then
        '                    'vCodTipoDescuento = oValidaDescuento.ebCodTipoDescuento.Value
        '                    'If oFirmasMgr.ValidaDescuento(vCodTipoDescuento, oSAPMgr.Read_Centros) = False Then
        '                    '    MsgBox("Este tipo de descuento no está permitido para esta tienda." & vbCrLf & "Debe elegir otro tipo de descuento.", MsgBoxStyle.Exclamation, "Dportenis Pro")
        '                    '    Exit Sub
        '                    'End If
        '                    'oValeDescuentoLocalInfo.FolioVale = oValidaDescuento.FolioVale
        '                    oValeDescuentoLocalInfo.FolioVale = oValeE.Folio
        '                    oValeDescuentoLocalInfo.Serie = oValeE.Serie
        '                    oValeDescuentoLocalInfo.Sucursal = oValidaDescuento.Sucursal
        '                    oValeDescuentoLocalInfo.TipoVale = oValidaDescuento.TipoVale
        '                    oValidaDescuento.Dispose()
        '                    oValidaDescuento = Nothing
        '                    'If vCodTipoDescuento = "DVD" Then
        '                    '    Select Case ValidaDVD(TotalPiezasFactura)
        '                    '        Case 0
        '                    '            AbrirFormaPago(vCodTipoDescuento)
        '                    '        Case 1
        '                    '            MsgBox("Sólo puede aplicar descuentos a 3 piezas. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
        '                    '        Case 2
        '                    '            MsgBox("Existen códigos con más del " & CInt(oValeDescuentoLocalInfo.TipoVale) * 10 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
        '                    '    End Select
        '                    'Else
        '                    AbrirFormaPago(vCodTipoDescuento)
        '                    'End If
        '                    'Else
        '                    '    vCodTipoDescuento = String.Empty
        '                    '    oValeDescuentoLocalInfo.FolioVale = 0
        '                    '    oValeDescuentoLocalInfo.Sucursal = String.Empty
        '                    '    oValeDescuentoLocalInfo.TipoVale = String.Empty
        '                    '    oValidaDescuento.Dispose()
        '                    '    oValidaDescuento = Nothing
        '                    '    Exit Sub
        '                    'End If
        '                End If
        '            Else
        '                vCodTipoDescuento = String.Empty
        '                AbrirFormaPago(vCodTipoDescuento)
        '            End If
        '        Else
        '            MsgBox("Factura no tiene asignado artículos.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Facturación")
        '        End If

    End Sub

    Private Function ValidaPromosFormasPago() As Boolean
        If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then
            Dim oRow As DataRow
            Dim strPagos As String = ""

            For Each oRow In dtDescFormasPago.Rows
                strPagos &= CStr(oRow!Descripcion).Trim & vbCrLf
            Next
            If MessageBox.Show("Las promociones aplicadas están condicionadas a las siguientes formas de pago:" & vbCrLf & vbCrLf & _
            strPagos & vbCrLf & "¿Deseas aprovechar estas promociones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = DialogResult.No Then
                AplicarPromociones(, , False)
                bRechazoPromo = True
            Else
                bRechazoPromo = False
            End If
        End If

        Return Not bRechazoPromo

    End Function

    Private Function ValidaImporteCostoPorCodigo(ByVal dtDetalleTemp As DataTable, ByRef strMensaje As String) As Boolean
        Dim bRes As Boolean = True
        Dim oRow As DataRow
        Dim oArtTemp As Articulo
        Dim strCodigosSinPrecio As String = ""
        Dim strCodigosSinCosto As String = ""
        Dim strCodigosNoEncontrados As String = ""

        For Each oRow In dtDetalleTemp.Rows
            oArtTemp = oArticuloMgr.Create
            oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArtTemp)
            If oArtTemp.Exist Then
                If (oArtTemp.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA)) < 1 Then
                    If strCodigosSinPrecio.Trim <> "" Then strCodigosSinPrecio &= ", "
                    strCodigosSinPrecio &= oArtTemp.CodArticulo.Trim
                    bRes = False
                End If
                If oArtTemp.CostoProm <= 0 Then
                    If strCodigosSinCosto.Trim <> "" Then strCodigosSinCosto &= ", "
                    strCodigosSinCosto &= oArtTemp.CodArticulo.Trim
                    bRes = False
                End If
            Else
                If strCodigosNoEncontrados.Trim <> "" Then strCodigosNoEncontrados &= ", "
                strCodigosNoEncontrados &= CStr(oRow!Codigo).Trim
                bRes = False
                Exit For
            End If
        Next

        If bRes = False Then
            If strCodigosSinPrecio.Trim <> "" Then
                strMensaje = "Algunos codigos de la factura tienen un precio menor a 1 peso" & vbCrLf & vbCrLf & strCodigosSinPrecio
            End If
            If strCodigosSinCosto.Trim <> "" Then
                If strMensaje.Trim = "" Then
                    strMensaje = "Algunos codigos de la factura no tienen costo" & vbCrLf & vbCrLf & strCodigosSinCosto
                Else
                    strMensaje &= vbCrLf & vbCrLf & "Algunos codigos de la factura no tienen costo" & vbCrLf & vbCrLf & strCodigosSinCosto
                End If
            End If
            If strCodigosSinPrecio.Trim = "" AndAlso strCodigosSinCosto.Trim = "" Then
                strMensaje = "Algunos codigos de la factura no estan registrados en el Catalogo de Articulos" & vbCrLf & vbCrLf & strCodigosNoEncontrados
            End If
            strMensaje &= vbCrLf & vbCrLf & "Favor de revisar el detalle de la nota de venta."
        End If

        Return bRes

    End Function
    Private Function DeleteNoMaterialCupon(ByRef materiales As DataTable)
        For i As Integer = materiales.Rows.Count - 1 To 0 Step -1
            If CInt(materiales.Rows(i)("Cantidad")) = 0 Then
                materiales.Rows.RemoveAt(i)
            End If
        Next
        For Each Row As DataRow In materiales.Rows
            Dim Talla As String = ""
            If IsNumeric(Row!Talla) Then
                If CStr(Row!Talla).LastIndexOf(".") = -1 Then
                    Talla = CStr(Row!Talla) & ".0"
                Else
                    Talla = CStr(Row!Talla)
                End If
            Else
                Talla = CStr(Row!Talla)
            End If
            Row!Talla = Talla
        Next
        materiales.AcceptChanges()
    End Function

    Private Function CumpleCantidadMaterialCupon(ByVal dtDetalle As DataTable, ByVal cupon As DataTable, ByRef Codigos As String) As Boolean
        Dim validar As Boolean = True
        For Each row As DataRow In dtDetalle.Rows
            Dim Talla As String = GetFormatTalla(CStr(row!Talla))
            Dim rows() As DataRow = cupon.Select("Material='" & row!Material & "' AND Talla='" & Talla & "'")
            If rows.Length > 0 Then
                If CInt(row!Cantidad) > CInt(rows(0)("Cantidad")) Then
                    Codigos = "Código: " & CStr(row!Material) & " " & CStr(rows(0)("Cantidad")) & " de " & CStr(row!Cantidad) & vbCrLf
                    validar = False
                End If
            End If
        Next
        Return validar
    End Function

    Private Function GetFormatTalla(ByVal talla As String) As String
        Dim size = ""
        If IsNumeric(talla) Then
            If talla.LastIndexOf(".") = -1 Then
                size = talla & ".0"
            Else
                size = talla
            End If
        Else
            size = talla
        End If
        Return size
    End Function

    Private Function RemoveFormatTalla(ByVal talla As String) As String
        Dim size As String = ""
        If (IsNumeric(talla)) Then
            If (talla.LastIndexOf(".") <> -1) Then
                Dim index As Integer = talla.LastIndexOf(".")
                Dim dec As String = talla.Substring(index + 1, (talla.Length - 1) - index)
                If CInt(dec) = 0 Then
                    size = talla.Remove(index, talla.Length - index)
                Else
                    size = talla
                End If
            Else
                size = talla
            End If
        Else
            size = talla
        End If
        Return size
    End Function


    Private Function AsignarPermisoDevolucion(ByRef dtDetalles As DataTable, ByVal dtMateriales As DataTable, ByVal valor As Boolean)
        Dim rows() As DataRow = Nothing
        For Each row As DataRow In dtDetalles.Rows
            Dim Talla As String = GetFormatTalla(CStr(row!Talla))
            rows = dtMateriales.Select("Material='" & row!Codigo & "' AND Talla='" & Talla & "'")
            If rows.Length > 0 Then
                'If CInt(row!Cantidad) <= CInt(rows(0)("Cantidad")) Then
                row!DevolucionCupon = valor
                'End If
            End If
        Next
    End Function

    Private Function SetDescuentoPrecio(ByRef materiales As DataTable, ByVal detalles As DataTable, ByVal descuento As Decimal, ByVal tipo As Char)
        Dim rows() As DataRow
        Dim totalFac As Decimal = GetTotalFacturaMateriales(detalles, materiales)
        Dim descImporte As Decimal = Decimal.Round((descuento * 100) / totalFac, 2)
        materiales.Columns.Add("Importe", GetType(Decimal))
        For Each row As DataRow In materiales.Rows
            rows = detalles.Select("Codigo='" & row("Material") & "'")
            If rows.Length > 0 Then
                Dim unitario As Decimal = CDec(rows(0)("Importe"))
                Dim desc As Decimal = CDec(rows(0)("Descuento"))
                Dim cant As Decimal = CDec(row!Cantidad)
                Dim res As Decimal = 0
                If tipo = "P" Then
                    res = ((((cant * unitario) - (((cant * unitario) / 100) * desc)) / 100) * descuento)
                Else
                    res = ((cant * unitario) / 100) * descImporte
                End If
                row("Importe") = res
            End If
        Next
    End Function

    Private Function GetTotalFacturaMateriales(ByVal detalles As DataTable, ByVal materiales As DataTable) As Decimal
        Dim rows() As DataRow
        Dim total As Decimal = 0
        For Each row As DataRow In materiales.Rows
            Dim talla As String = RemoveFormatTalla(row!Talla)
            rows = detalles.Select("Codigo='" & row!Material & "' AND Talla='" & talla & "'")
            If rows.Length > 0 Then
                total += CDec(rows(0)("Importe")) * CDec(row!Cantidad)
            End If
        Next
        Return Math.Round(total * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
    End Function



    Private Function ValidaPromoEspecial(ByVal Folio As String, ByRef oCuponDesc As CuponDescuento) As Boolean

        Dim strMsgError As String = ""

        If IsNumeric(Folio.Trim) Then Folio = Folio.Trim.PadLeft(10, "0")

        oCuponDesc = oSAPMgr.ZCUP_INFO_CUPON(Folio.Trim, Me.ebTipoVenta.Value, strMsgError)

        If Not oCuponDesc Is Nothing Then
            'If AplicaPromocionesVigentes(, oCuponDesc) Then
            If AplicarPromociones(, oCuponDesc) Then
                Return True
            Else
                Return False
            End If
        Else
            MessageBox.Show(strMsgError, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

    End Function

    'Manager Descuento DVD
    Dim oValidaDescuento As DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.frmValidaTipoDescuento
    Dim WithEvents obtnOKTwo As Janus.Windows.EditControls.UIButton

    Private Sub ebCodTipoDescuento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If oValidaDescuento.ebCodTipoDescuento.Value = "DVD" Then
            obtnOKTwo = New Janus.Windows.EditControls.UIButton
            With obtnOKTwo
                .Size = oValidaDescuento.Controls(0).Controls(5).Size
                .Location = oValidaDescuento.Controls(0).Controls(5).Location
                .Text = oValidaDescuento.Controls(0).Controls(5).Text
                .Font = DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).Font
                .ForeColor = DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).ForeColor
                .VisualStyle = DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).VisualStyle
                .TabIndex = DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).TabIndex
                DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).Visible = False
            End With
            oValidaDescuento.Controls(0).Controls.Add(obtnOKTwo)
        Else
            DirectCast(oValidaDescuento.Controls(0).Controls(5), Janus.Windows.EditControls.UIButton).Visible = True
            oValidaDescuento.Controls(0).Controls.Remove(obtnOKTwo)
            obtnOKTwo = Nothing
        End If
    End Sub

    Private Sub obtnOKTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obtnOKTwo.Click
        Dim strStatusVale As String
        Dim strPorcentaje As String
        Dim strFolioVale As String = _
            DirectCast(oValidaDescuento.Controls(0).Controls(1), Janus.Windows.GridEX.EditControls.NumericEditBox).Value

        '---------------------------------------------------------------------
        'JNAVA (28.12.2015): Consumo de servicios REST para SAP Retail
        '---------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos/empleados", "POST")
        oRetail.ValidaValeEmpleadoSAP(strFolioVale, strStatusVale, strPorcentaje)
        ''ValidaValeEmpleadoSAP( _
        'strFolioVale _
        ', strStatusVale, _
        'strPorcentaje)
        '---------------------------------------------------------------------

        Select Case strStatusVale
            Case 0 'Activo

                oValidaDescuento.FolioVale = strFolioVale
                oValidaDescuento.TipoVale = strPorcentaje / 10
                oValidaDescuento.Sucursal = oAppContext.ApplicationConfiguration.Almacen
                DirectCast(oValidaDescuento.Controls(0).Controls(7),  _
                Janus.Windows.GridEX.EditControls.MultiColumnCombo).Value = strPorcentaje / 10

                oValidaDescuento.DialogResult = DialogResult.OK

            Case 1 'Usado
                MessageBox.Show("El vale de descuento ya fue utilizado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case 2 'Baja
                MessageBox.Show("El vale de descuento fue dado de baja", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case 3 'No Existe
                MessageBox.Show("El vale de descuento no existe", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case 4 ' Vencido
                MessageBox.Show("El vale de descuento está vencido", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Select
    End Sub

    'Private Sub ValidaValeEmpleadoSAP(ByVal strVale As String, ByRef strStatusVale As String, ByRef strPorcentaje As String)
    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        'Parametros Exports
    '        Dim NUMVA As SAPFunctionsOCX.Parameter          '   Fichero local para upload/download
    '        'Fin Parametros Exports

    '        'Parametros Imports
    '        Dim STATU As SAPFunctionsOCX.Parameter           '   Indicador de una posición
    '        Dim PORCENTAJE As SAPFunctionsOCX.Parameter           '   Indicador de una posición
    '        'Fin parametros Imports

    '        With objR3.Connection
    '            .ApplicationServer = oAppSAPConfig.ApplicationServer
    '            .GroupName = oAppSAPConfig.GroupName
    '            .System = oAppSAPConfig.System
    '            .Client = oAppSAPConfig.Client
    '            .User = oAppSAPConfig.User
    '            .Password = oAppSAPConfig.Password
    '            .language = oAppSAPConfig.Language
    '            .SystemNumber = oAppSAPConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        End If

    '        objFunc = objR3.Add("ZBAPI_CONSULTAVALEDESCTO")

    '        'Exports
    '        NUMVA = objFunc.Exports("NUMVA")
    '        'Fin Exports


    '        'Imports
    '        STATU = objFunc.Imports("STATU")
    '        PORCENTAJE = objFunc.Imports("PORCENTAJE")
    '        'Fin Imports

    '        'Captura de Info
    '        NUMVA.Value = strVale.PadLeft(10, "0")
    '        Dim bolStatus As Boolean
    '        bolStatus = objFunc.Call()

    '        If STATU.Value = String.Empty Then
    '            MsgBox("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema." & bolStatus)
    '            'Throw New ApplicationException("Error al Procesar VALE en SAP. Notificar al Administrador del Sistema.")
    '        Else

    '            strStatusVale = STATU.Value
    '            strPorcentaje = PORCENTAJE.Value

    '        End If

    '        objR3.Connection.LogOff()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try


    'End Sub

    'Manager Descuento DVD

    Private Function ValidaDVD(ByVal TPiezas As Integer) As Integer

        'Creamos objeto Articulo

        Dim oArticuloTemp As Articulo
        oArticuloTemp = oArticuloMgr.Create

        'Validamos Descuento > al 20% o 40%
        Dim i As Integer = 0
        Dim iPzasDscto As Integer = 0
        Dim iDsctoPermitido As Decimal = 0

        For i = 0 To (grdDetalle.Rows.Count - 1)

            oArticuloMgr.LoadInto(grdDetalle(i, 0), oArticuloTemp)

            If (grdDetalle(i, 5) + grdDetalle(i, 6)) > 0 Then

                iPzasDscto = iPzasDscto + grdDetalle(i, 2)

                If Decimal.Round(oArticuloTemp.Descuento, 2) > 0 Then

                    If Decimal.Round(oArticuloTemp.Descuento, 2) >= CInt(oValeDescuentoLocalInfo.TipoVale) * 10 Then

                        Return 2

                    Else

                        iDsctoPermitido = 0

                        iDsctoPermitido = ((Decimal.Round(oArticuloTemp.PrecioVenta, 2) - (Decimal.Round(oArticuloTemp.PrecioVenta, 2) * (CInt(oValeDescuentoLocalInfo.TipoVale) * 10) / 100)) * 100 / Decimal.Round(oArticuloTemp.PrecioOferta, 2))

                        iDsctoPermitido = Decimal.Round(100 - iDsctoPermitido, 2)

                        If (grdDetalle(i, 5) + grdDetalle(i, 6)) > iDsctoPermitido Then

                            Return 2

                        End If

                    End If

                Else

                    '''Descuentos para la 53
                    Dim DescuentoSocio As Decimal = 0
                    DescuentoSocio = 0
                    If oAppContext.ApplicationConfiguration.Almacen = "053" Then

                        If oFactura.CodTipoVenta = "S" Then
                            DescuentoSocio = 25
                        Else
                            DescuentoSocio = 10
                        End If

                    End If
                    '''Fin Descuentos para la 53

                    If grdDetalle(i, 5) <= 0 Then 'Articulos sin Condiociones de Venta.
                        If (DescuentoSocio + grdDetalle(i, 5) + grdDetalle(i, 6)) > CInt(oValeDescuentoLocalInfo.TipoVale) * 10 Then

                            Return 2

                        End If
                    Else 'Aqui entra si el articulo tiene un descuento por CondicionesVentas
                        If (grdDetalle(i, 5) + grdDetalle(i, 6)) > CInt(oValeDescuentoLocalInfo.TipoVale) * 10 Then

                            Return 2

                        End If
                    End If

                End If

            End If

        Next

        oArticuloTemp = Nothing

        If iPzasDscto > 3 Then

            Return 1

        End If

        Return 0

    End Function

    Private Sub ebFolioFactura_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebFolioFactura.ButtonClick

        LoadSearchFormFactura()

    End Sub

    Private Sub ebFolioFactura_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioFactura.Validating

        If ebFolioFactura.Value > 0 Then

            If ebFolioFactura.Value <> oFactura.FolioFactura Then

                oFactura.ClearFields()

                oFacturaMgr.Load(ebFolioFactura.Value, oFactura.CodCaja, oFactura)

                If oFactura.FacturaID = 0 Then

                    MsgBox("Folio de Factura No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                    ebFolioFactura.Focus()

                End If

            End If

        End If

    End Sub

    Private Sub ebFolioFactura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFolioFactura.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                LoadSearchFormFactura()

        End Select

    End Sub

    Private Sub ebClienteID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            If Me.ebClienteID.ReadOnly = False Then
                If oConfigCierreFI.UsarDescargaClientes Then
                    LoadSearchFormCliente()
                Else
                    LoadSearchFormClientesSAP()
                End If
            Else
                ProcesoBusquedaClienteCRM()
            End If

        ElseIf e.KeyCode = Keys.Enter Then

            'SendKeys.Send("{TAB}")
            If ebCodVendedor.Text.Trim() <> "" Then
                dgHeader.Focus()
            Else
                ebCodVendedor.Focus()
            End If

        End If

    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating
        If bolCloseForm = False Then
            'If Not (ebClienteID.Value <= 1) Then
            If ebClienteID.Value > 0 Then
                Valida()
                If dsDetalle.Tables(0).Rows.Count > 0 AndAlso dsDetalle.Tables(0).Rows(0)!Codigo <> "" Then
                    AplicarPromociones()
                End If
            Else
                ebClienteID.Value = 0
                btnAltaCliente.Focus()

            End If
        End If

    End Sub

    Private Sub Valida()

        Dim strCodCliente As String
        strCodCliente = CStr(ebClienteID.Value).PadLeft(10, "0")
        'Dim strTipoVenta As String = oClienteMgr.GetTipoVenta(strCodCliente)

        'If strTipoVenta.Trim = "P" AndAlso (bolMenuAbrir = True OrElse oConfigCierreFI.UsarHuellas = False) Then Exit Sub

        oCliente.Clear()
        'If strTipoVenta.Trim = "P" Then
        '    GetClientePG(strCodCliente)
        '    oClienteMgr.LoadPG(IIf(IsNumeric(strCodCliente), CInt(strCodCliente), 0), oCliente)
        '    oCliente.TipoVenta = strTipoVenta
        'Else
        If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(strCodCliente, oFactura.CodTipoVenta)
        Me.oClienteMgr.Load(strCodCliente, oCliente, oFactura.CodTipoVenta)
        oCliente.TipoVenta = oFactura.CodTipoVenta
        'End If

        If (oCliente Is Nothing) OrElse CDbl(oCliente.CodigoAlterno) <= 0 OrElse (oCliente.CodigoAlterno = String.Empty) OrElse (Not IsNumeric(oCliente.CodigoAlterno)) Then
            MsgBox("Cliente " & strCodCliente & " no está registrado. No Existe.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
            ebClienteID.Text = ""
            ebClienteDescripcion.Text = String.Empty
            ebClienteID.Focus()
            'ElseIf InStr(oFacturaMgr.ValidaTipoVentaCliente(oCliente.CodigoAlterno), oFactura.CodTipoVenta) <= 0 Then
            '    MsgBox("El Cliente " & strCodCliente & " no pertenece al tipo de venta seleccionado.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Dportenis Pro")
            '    ebClienteDescripcion.Text = String.Empty
            '    ebClienteID.Text = ""
            '    ebClienteID.Focus()
        Else
            oFactura.ClienteId = CInt(oCliente.CodigoAlterno)
            If oFactura.ClienteId <= 0 Then oFactura.RazonRechazo = ""
            'ebClienteDescripcion.Text = oCliente.Nombre.Trim & " " & oCliente.ApellidoPaterno.Trim & " " & oCliente.ApellidoMaterno.Trim
            ebClienteDescripcion.Text = oCliente.NombreCompleto

            ' Se pidió quitar la validación del límite de crédito de los clientes DIPS 02/04/2012
            'If oFactura.CodTipoVenta = "D" Then
            '    '--Cargamos Datos de Credito del Asociado

            '    oLimiteCreditoSAP = New CreditoAsociadoSAP
            '    Dim oSAPmgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            '    oLimiteCreditoSAP = oSAPmgr.GetCreditoAsociadoSAP(oCliente.CodigoAlterno.PadLeft(10, "0"))
            '    oSAPmgr = Nothing

            '    If oLimiteCreditoSAP.LimiteCredito = 0 Then
            '        MsgBox("Cliente No cuenta con Crédito.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    ElseIf oLimiteCreditoSAP.Bloqueado = "S" Then
            '        MsgBox("Cliente tiene el Crédito Bloqueado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    Else
            '        MsgBox("Crédito Disponible : " & Format(oLimiteCreditoSAP.LimiteCredito - oLimiteCreditoSAP.Credito, "Currency"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    End If
            'End If
            '---------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos los datos del Cliente
            '---------------------------------------------------------------------------------------------------------------------------------------------
            If ValidaDatosObligatoriosCliente(oCliente) = False And oFactura.CodTipoVenta <> "D" Then
                If oFactura.CodTipoVenta = "P" Then
                    If MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "¿Deseas complementarlos en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        AltadeCliente(oCliente.CodigoAlterno, oCliente.TipoVenta, True)
                    End If
                Else
                    MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "Es necesario complementarlos para continuar con la venta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    AltadeCliente(oCliente.CodigoAlterno, oCliente.TipoVenta)
                End If
            End If
            'If (strTipoVenta.Trim <> "P" And strTipoVenta.Trim <> "V") Then
            '    If Not oValeCaja.ValeCajaID > 0 Then
            '        ModificaCliente()
            '    End If
            'End If

        End If

    End Sub

    Private Sub ebClienteID_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebClienteID.ButtonClick

        If Me.ebClienteID.ReadOnly = False Then
            If oConfigCierreFI.UsarDescargaClientes Then
                LoadSearchFormCliente()
            Else
                LoadSearchFormClientesSAP()
            End If
        Else
            ProcesoBusquedaClienteCRM()
        End If

    End Sub

    Private Function ValidaAsociadoCredito() As Boolean

        oAsociado.Clear()

        oAsociadoMgr.LoadIntoByClienteID(oFactura.ClienteId, oAsociado)

        If oAsociado.AsociadoID = 0 Then

            MsgBox("Cliente No es Asociado. Tipo de Venta Incorrecto. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")
            oFactura.CodTipoVenta = "P"
            oFactura.ClienteId = 1
            ebClienteDescripcion.Text = "PÚBLICO GENERAL"
            ebSubTotal.Visible = False
            ebIVA.Visible = False
            Return False

        Else

            'Verificamos si tiene Credito Directo
            If oAsociado.EsCreditoDirectoTienda Then

                ebSubTotal.Visible = False
                ebIVA.Visible = False

                'Verificamos si tiene pagos Vencidos Credito Directo
                If oAsociado.SaldoVencDirectoTienda > 0 Then

                    MsgBox("Asociado cuenta con pagos vencidos. Es necesario que regularice sus pagos. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")
                    oFactura.ClienteId = 1
                    ebClienteDescripcion.Text = "PÚBLICO GENERAL"
                    Return False

                Else

                    'Validamos el Credito Directo
                    If Not ValidamosCreditoDirecto() Then
                        Return False
                    End If

                End If

            Else

                ebSubTotal.Visible = True
                ebIVA.Visible = True

                MsgBox("Asociado no cuenta con Crédito Directo en Tienda. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturación")

            End If

        End If

        Return True

    End Function

    Private Function ValidamosCreditoDirecto() As Boolean

        Dim oProcess As New FacturacionProcess(oAppContext)

        Dim oResult As Boolean

        oResult = oProcess.Verificacion_Credito_Directo(oFactura.ClienteId)

        If Not oResult Then

            oFactura.ClienteId = 1
            ebClienteDescripcion.Text = "PÚBLICO GENERAL"

        End If

        oProcess.Dispose()
        oProcess = Nothing

        Return oResult

    End Function

    Private Sub ebCodVendedor_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCodVendedor.ButtonClick

        LoadSearchFormPlayer()

    End Sub

    Private Sub ebCodVendedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodVendedor.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormPlayer()
            ebCodVendedor.Focus()
            ebCodVendedor.SelectAll()

        End If

        If e.KeyCode = Keys.Enter Then

            'SendKeys.Send("{TAB}")
            If IsNumeric(ebCodVendedor.Text.Trim()) = True Then
                If ebClienteID.Enabled = False Then
                    dgHeader.Focus()
                ElseIf ebClienteID.Text.Trim() <> "0" Then
                    dgHeader.Focus()
                Else
                    ebClienteID.Focus()
                End If
            Else
                MessageBox.Show("El código del vendedor debe ser numerico", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            

        End If

    End Sub

    Private Sub ebCodVendedor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating

        If oConfigCierreFI.ShowManagerPC AndAlso ebCodVendedor.Text.Trim = "" Then

            ebCodVendedor.Focus()
            Return

        End If
        If IsNumeric(ebCodVendedor.Text.Trim()) = False Then
            MessageBox.Show("El código de vendedor debe ser numerico", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If ebCodVendedor.Text.Trim <> "" AndAlso ebCodVendedor.Text.Trim <> oFactura.CodVendedor.Trim Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                '------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
                '------------------------------------------------------------------------------------------------------------------------------------
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)

                'If strRes.Trim = "0" Then
                '    GoTo NoExiste
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebPlayerDescripcion.Text = ""
                '    e.Cancel = True
                'Else
                ebPlayerDescripcion.Text = oVendedor.Nombre
                oFactura.CodVendedor = oVendedor.ID
                '----------------------------------------------------------------------------------------------------------------------
                'Empezamos a correr el cronómetro
                '----------------------------------------------------------------------------------------------------------------------
                If Me.ebTipoVenta.Value <> "" AndAlso oConfigCierreFI.ShowManagerPC Then EjecutarCronometro(True)
                'End If
            Else
NoExiste:
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                ebCodVendedor.Text = oFactura.CodVendedor
                oVendedor.ClearFields()
                Me.ebPlayerDescripcion.Text = ""
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub BorraDescuentoAdicional()

        Dim dRow As DataRow
        For Each dRow In dsDetalle.Tables(0).Rows
            dRow!Adicional = 0
        Next
        ActualizaCalculos()

    End Sub

    Private Sub ebClienteID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.ValueChanged

        If ebClienteID.Value > 0 Then

            btnAltaCliente.Enabled = False

        Else

            ebClienteDescripcion.Text = String.Empty
            btnAltaCliente.Enabled = True

        End If

    End Sub

    Private Sub btnAltaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaCliente.Click

        AltadeCliente()

    End Sub

    Private Function AltadeCliente(Optional ByVal ClienteID As String = "", Optional ByVal TipoCliente As String = "", Optional ByVal Complemento As Boolean = False) As Boolean

        Dim bResult As Boolean = False
        Dim frmClientes As New frmClientesSAP
        frmClientes.TipoVenta = IIf(oFactura.CodTipoVenta <> "D", "C", oFactura.CodTipoVenta) 'oFactura.CodTipoVenta
        frmClientes.ClienteID = ClienteID
        frmClientes.TipoCliente = TipoCliente
        frmClientes.Player = Me.ebCodVendedor.Text.Trim

        frmClientes.ShowMeforFactura() 'oFactura.CodTipoVenta, ClienteID)

        If frmClientes.DialogResult = DialogResult.OK Then

            oFactura.ClienteId = frmClientes.ClienteID
            If oFactura.CodTipoVenta = "P" Then
                oFactura.ClientPGID = frmClientes.ClienteID
                oFactura.RazonRechazo = ""
            End If

            ebClienteDescripcion.Text = frmClientes.NombreApellidos
            oCliente.Clear()
            oClienteMgr.LoadInto(oFactura.ClienteId, oCliente)
            bResult = True

            frmClientes.Dispose()
            frmClientes = Nothing
            If ebCodVendedor.Text.Trim() <> "" Then
                dgHeader.Focus()
            Else
                ebCodVendedor.Focus()
            End If
        ElseIf Complemento = False Then

            frmClientes.Dispose()
            frmClientes = Nothing

            oFactura.ClienteId = 0
            oFactura.ClientPGID = 0
            ebClienteID.Focus()

        End If

        Return bResult

    End Function

    Private Function ModificaCliente() As Boolean
        Try

            Dim ofrmClientesSAP As New frmClientesUpDateSAP

            If (oCliente Is Nothing) Then

                MsgBox("No ha sido seleccionado un Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Function

            End If
            ofrmClientesSAP.CodigoAlterno = oCliente.CodigoAlterno
            ofrmClientesSAP.Ciudad = oCliente.Ciudad
            ofrmClientesSAP.Colonia = oCliente.Colonia
            ofrmClientesSAP.CP = oCliente.CP
            ofrmClientesSAP.Direccion = oCliente.Direccion
            ofrmClientesSAP.EMail = oCliente.EMail
            ofrmClientesSAP.Estado = oCliente.Estado
            ofrmClientesSAP.Telefono = oCliente.Telefono

            ofrmClientesSAP.ShowDialog()

            oCliente.Clear()
            oClienteMgr.LoadInto(oFactura.ClienteId, oCliente)

            ofrmClientesSAP.Dispose()
            ofrmClientesSAP = Nothing

        Catch ex As Exception

            Throw ex

        End Try


    End Function

    Private Sub ebTipoVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebTipoVenta.KeyDown

        If e.KeyCode = Keys.Enter Then

            Me.ebCodVendedor.Focus()

        End If

    End Sub

    Private Sub ebTipoVenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebTipoVenta.LostFocus

        'Me.ebCodVendedor.Focus()

    End Sub

    Private Sub ebTipoVenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTipoVenta.Validating

        If ebTipoVenta.Value = "E" Then
            Me.chkPromoEspecial.Enabled = False
            Me.chkPromoEspecial.Checked = False
        Else
            Me.chkPromoEspecial.Enabled = True
        End If

        If ebTipoVenta.Value = "A" And Not vApartadoInstance Then     '''Apartados
            If Not bolIsOpenFacturaInput Then
                MsgBox("Tipo de Venta no permitido en este nivel.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Facturación")
                e.Cancel = True
                If oConfigCierreFI.UsarHuellas = False Then ebClienteID.Value = 1
                ebClienteDescripcion.Text = "PUBLICO GENERAL"
                ebTipoVenta.Value = "P"
            End If
        ElseIf ebTipoVenta.Value = "S" AndAlso oAppContext.ApplicationConfiguration.Almacen <> "053" Then
            MessageBox.Show("Este tipo de venta no esta permitida para esta tienda.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            If oConfigCierreFI.UsarHuellas = False Then ebClienteID.Value = 1
            ebClienteDescripcion.Text = "PUBLICO GENERAL"
            ebTipoVenta.Value = "P"
        End If

        Dim TotalAPagarDips As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0
        Dim Compara As Boolean = False
        'Validamos si tiene catalogos agregados al detalle si cambia el tipo de venta distinto a Dips
        If ebTipoVenta.Value <> "D" AndAlso ebTipoVenta.Value <> "S" Then
            If dsDetalle.Tables(0).Rows.Count > 0 Then
                For Each oRow As DataRow In dsDetalle.Tables(0).Rows
                    If oRow("Codigo") <> "" Then
                        If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                            MsgBox("Se han agregado catalogos en el detalle. No puede cambiar tipo de venta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Facturación")
                            If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                ebTipoVenta.Value = "S"
                            Else
                                ebTipoVenta.Value = "D"
                            End If

                            e.Cancel = True
                            Exit Sub
                        End If
                    End If

                Next

            End If
            'Else
            'AplicaDescuentosDips:
            '            AplicaDescuentosDips()
            '            TotalAPagarDips = oFactura.Total
        End If

        'If Compara = False AndAlso dsDetalle.Tables(0).Rows.Count > 0 AndAlso oFactura.CodTipoVenta <> "E" Then
        '    AplicaPromocionesVigentes()
        '    TotalAPagarPromo = oFactura.Total
        'End If

        'If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso Compara = False AndAlso TotalAPagarDips < TotalAPagarPromo Then
        '    Compara = True
        '    GoTo AplicaDescuentosDips
        'End If

        'Actualizamos los descuentos adicionales en el detalle dependiendo el tipo de venta seleccionado
        'If dsDetalle.Tables(0).Rows.Count > 1 Then
        '    AplicaDescuentosAutomaticos()
        '    ActualizaCalculos()
        'End If

        'Borra la informacion del campo adicional en el detalle cuando el tipo de venta es DPVALE
        'If ebTipoVenta.Value = "V" Then
        '    If dsDetalle.Tables(0).Rows.Count > 0 Then
        '        Dim i As Integer
        '        Dim Lim As Integer = dsDetalle.Tables(0).Rows.Count
        '        For i = 0 To Lim - 1
        '            Me.grdDetalle.Item(i, 6) = 0
        '        Next
        '    End If
        '    Me.grdDetalle.Focus()
        'End If
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos las promociones vigentes
        '----------------------------------------------------------------------------------------------------------------------------------------
        AplicarPromociones()

    End Sub




    Private Sub ebTipoVenta_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebTipoVenta.ValueChanged

        oFactura.CodTipoVenta = UCase(ebTipoVenta.Value)
        Select Case oFactura.CodTipoVenta
            Case "V", "P"
                '----------------------------------------------------------------------------------------------------
                ' JNAVA (04.03.2016): Si es publico en general permitimos que ingresen un cliente en SH
                '----------------------------------------------------------------------------------------------------
                If oFactura.CodTipoVenta = "P" Then
                    oFactura.ClienteId = 0
                    ebClienteID.Enabled = True
                    Me.btnAltaCliente.Enabled = True
                Else
                    ebClienteID.Enabled = False
                    Me.btnAltaCliente.Enabled = False
                    oFactura.ClienteId = 10000000
                    Me.ebClienteDescripcion.Text = "PÚBLICO GENERAL"
                End If
                '----------------------------------------------------------------------------------------------------
            Case "E"
                oFactura.ClienteId = 10000000
                ebClienteID.Enabled = False
                Me.btnAltaCliente.Enabled = False
                Me.ebClienteDescripcion.Text = "VENTAS A EMPLEADOS"
            Case Else
                'If oFactura.CodTipoVenta = "P" Then GoTo PG 'AndAlso oConfigCierreFI.UsarHuellas = False
                oFactura.ClienteId = 0
                ebClienteID.Enabled = True
                Me.ebClienteDescripcion.Text = ""
                Me.btnAltaCliente.Enabled = True
                'Case "P", "V"
        End Select

        '--Columna de Dscto. Adicional (D)ips Automatico
        'If oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S" Then
        'grdDetalle.Cols(6).AllowEditing = False
        'Else
        '    grdDetalle.Cols(6).AllowEditing = True
        'End If

        strCondicionVenta = ebTipoVenta.DropDownList.GetValue(2)
        strListaPrecios = ebTipoVenta.DropDownList.GetValue(3)
        Dim row As GridEXRow = ebTipoVenta.DropDownList.GetRow()
        If Not row Is Nothing Then
            Dim motivo As String = CStr(row.Cells(4).Value)
            oFactura.MotivoPedido = motivo
        End If
        'oFactura.MotivoPedido = ebTipoVenta.DropDownList.GetRow()

    End Sub

    Private Sub frmFacturacion_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Me.Dispose()

    End Sub

    Private Sub frmFacturacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim intLargo As Integer = 0
        If e.Alt And e.KeyCode = Keys.D Then
            If dgHeader.RowCount > 0 Then
                Dim row As DataRow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
                If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso dgHeader.Col = 6 AndAlso Mid(CStr(row!Codigo), 1, 6) = "DT-CAT" Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
                        dgHeader.Tables(0).Columns("Adicional").EditType = EditType.TextBox
                        If oFactura.CodTipoVenta = "D" Then
                            boolDescuentoDipsEspecial = True
                        Else
                            boolDescuentoSocioEspecial = True
                        End If
                    Else
                        dgHeader.Tables(0).Columns("Adicional").EditType = EditType.NoEdit
                        If oFactura.CodTipoVenta = "D" Then
                            boolDescuentoDipsEspecial = False
                        Else
                            boolDescuentoSocioEspecial = False
                        End If
                    End If
                End If
            End If
            'ElseIf (e.Alt And e.KeyCode = Keys.P) Then
            '    btnFormaPago.Focus()
            '    Dim nHwnI As System.IntPtr
            '    nHwnI = FindWindow(vbNullString, "Promociones")
            '    If Val(nHwnI.ToString) <> 0 Then
            '        ShowWindow(nHwnI, 9)
            '        SetForegroundWindow(nHwnI)
            '    Else
            '        Dim form As New frmMostrarPromociones
            '        form.Promociones = Me.promociones
            '        Dim count As Integer = Me.promociones.Rows.Count
            '        form.Promociones.AcceptChanges()
            '        form.Show()
            '    End If
        ElseIf (e.Control And e.KeyCode = Keys.E) Then
            'Consultando la existencia en otras tiendas.
            'Dim frmConsulta As New frmConsultaSiHay
            Dim dtArticulos As DataTable = Me.GetArticulosSinExistencia()
            If dtArticulos.Rows.Count > 0 Then
                FormExistenciasSH = New frmConsultaSiHay
                FormExistenciasSH.Almacen = oAppContext.ApplicationConfiguration.Almacen
                FormExistenciasSH.CargarExistencias(dtArticulos)
                FormExistenciasSH.Show()
            End If
        ElseIf (e.KeyCode = Keys.Escape) Then

            'Me.Finalize()
            bolCloseForm = True
            Me.Close()

            

        Else

            If e.KeyCode = Keys.Delete Then

                'ElseIf e.KeyCode = Keys.Insert And vApartadoInstance = False And explorerBar1.Enabled = True Then
                '    ShowPanelInsert()
            ElseIf Me.ActiveControl Is Me.dgHeader And Not e.KeyCode = Keys.Enter Then
                If e.KeyCode = 189 Then
                    str = str & "-"
                Else
                    str = str & Chr(e.KeyCode)
                End If
            ElseIf Me.ActiveControl Is Me.dgHeader Then
                str = Regex.Replace(str, "[^\w\.@-]", "")
                str = str.Trim
                str = str.Replace("", "")
                intLargo = str.Length - 1
                str = str.PadLeft(18, "0")

                If str <> "" AndAlso str.Length > 0 AndAlso str <> "000000000000000000" Then
                    str = str.PadLeft(18, "0")
                    str = Mid(str, str.Length - 17)
                    If IsNumeric(str) Then
                        str = Mid(str, str.Length - 17)
                    Else
                        If str.Length > intLargo Then
                            str = Mid(str, str.Length - intLargo)
                        Else
                            str = Mid(str, str.Length - 11)
                        End If
                    End If

                    'txtPopupCodigo.Text = str
                    AgregarCodigoGrid(str)
                    str = ""
                Else
                    str = ""
                End If
            End If

        End If
    End Sub

#End Region

#Region "Grid Detalle Methods"

    Private Sub grdDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDetalle.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.F

                btnFormaPago.Focus()


            Case e.Alt And Keys.S

                If grdDetalle.Col = 0 And grdDetalle(grdDetalle.Row, 0) = String.Empty Then

                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                        'ALLOW
                        Me.grdDetalle.Cols(0).AllowEditing = True
                        boolManual = True
                        grdDetalle(grdDetalle.Row, 0) = LoadSearchArticulo()
                    Else
                        'ALLOW
                        Me.grdDetalle.Cols(0).AllowEditing = False
                        boolManual = False
                    End If
                    oAppContext.Security.CloseImpersonatedSession()



                End If

            Case Keys.Escape

                'Try
                '    grdDetalle.Select(grdDetalle.Row, grdDetalle.Col)
                'Catch ex As Exception
                'End Try

                'Case Keys.Enter

                '    If grdDetalle.Col = 6 Then

                '        grdDetalle.Select(grdDetalle.Row, 0)

                '    Else

                '        grdDetalle.Select(grdDetalle.Row, grdDetalle.Col + 1)

                '    End If

            Case Keys.Insert

                If ValidateRowGrid(grdDetalle.Row) Then


                    'If oAppContext.ApplicationConfiguration.CodigosXFactura <= dsDetalle.Tables(0).Rows.Count Then 'Comentado por ralcaraz
                    'If dsDetalle.Tables(0).Rows.Count > 9 Then 'Comentado por earagon 24.03.2008 prueba de venta con mas de 10 articulos.
                    If dsDetalle.Tables(0).Rows.Count > oAppContext.ApplicationConfiguration.CodigosXFactura Then

                        MsgBox("No puede agregar más códigos a la factura. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Factura")

                    Else

                        Dim dRow As DataRow
                        Dim ActualRow As Integer
                        ActualRow = dsDetalle.Tables(0).Rows.Count
                        dRow = dsDetalle.Tables(0).NewRow
                        dsDetalle.Tables(0).Rows.Add(dRow)
                        dsDetalle.AcceptChanges()

                        ActualizaCalculos()

                        ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
                        'ALLOW
                        Me.grdDetalle.Cols(0).AllowEditing = False
                        boolManual = False

                        grdDetalle.Refresh()

                        grdDetalle.Select(ActualRow, 0)

                    End If


                Else

                    grdDetalle.Focus()
                    grdDetalle.Select(grdDetalle.Row, grdDetalle.Col)

                End If
                str = ""

            Case Keys.Delete

                'If Me.boolDescuentoDPakete Then Exit Select

                Dim nRow As Integer = grdDetalle.Row
                Dim tRows As Integer = grdDetalle.Rows.Count - 1

                If dsDetalle.Tables(0).Rows.Count = 1 Then
                    If dsDetalle.Tables(0).Rows(nRow).Item(0) <> "" Then
                        Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & grdDetalle(nRow, 0) & "' and Talla = '" & grdDetalle(nRow, 1) & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                        If oDataView.Count > 0 Then
                            If Mid(CStr(oDataView.Item(0)("Articulo")), 1, 6) = "DT-CAT" Then
                                strLlevaCatalogo = ""
                            End If
                            oDataView.Delete(0)
                            oFactura.dtMotivos.AcceptChanges()

                        End If
                    End If


                    LimpiaDatosGrid(nRow)

                    grdDetalle.Select(nRow, 0)

                    grdDetalle.Focus()

                Else

                    vRowDelete = True

                    If dsDetalle.Tables(0).Rows(nRow).Item(0) <> "" Then
                        Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & grdDetalle(nRow, 0) & "' and Talla = '" & grdDetalle(nRow, 1) & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                        If oDataView.Count > 0 Then
                            If Mid(CStr(oDataView.Item(0)("Articulo")), 1, 6) = "DT-CAT" Then
                                strLlevaCatalogo = ""
                            End If
                            oDataView.Delete(0)
                            oFactura.dtMotivos.AcceptChanges()
                        End If
                    End If

                    dsDetalle.Tables(0).Rows(nRow).Delete()

                    dsDetalle.AcceptChanges()

                    '******** Aplica los descuentos adicionales automaticos segun las promociones vigentes
                    'AplicaDescuentosAutomaticos()

                    ActualizaCalculos()

                    grdDetalle.Select(0, 0)

                    grdDetalle.Focus()

                    ActualizaDatosArticulo(0, grdDetalle.Col)

                End If
                'Captura Manual (Todo el F2)
            Case Keys.F2
                If grdDetalle.Col = 0 Then

                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                        'ALLOW
                        boolManual = True
                        Me.grdDetalle.Cols(0).AllowEditing = True
                    Else
                        'ALLOW
                        Me.grdDetalle.Cols(0).AllowEditing = False
                        boolManual = False
                    End If
                    oAppContext.Security.CloseImpersonatedSession()

                End If

            Case e.Alt And Keys.D

                If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso grdDetalle.Col = 6 AndAlso Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 6) = "DT-CAT" Then
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
                        '''Implementar Descuento Adicional
                        grdDetalle.Cols(6).AllowEditing = True
                        If oFactura.CodTipoVenta = "D" Then
                            boolDescuentoDipsEspecial = True
                        Else
                            boolDescuentoSocioEspecial = True
                        End If
                    Else
                        '''Implementar Descuento Adicional
                        grdDetalle.Cols(6).AllowEditing = False
                        If oFactura.CodTipoVenta = "D" Then
                            boolDescuentoDipsEspecial = False
                        Else
                            boolDescuentoSocioEspecial = False
                        End If
                    End If
                End If

            Case e.Alt And Keys.P

                'If Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 2) = "CZ" OrElse _
                'Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 5) = "OB-DM" OrElse _
                'Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 5) = "OB-SS" OrElse _
                'Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 5) = "OB-CE" Then
                '    oAppContext.Security.CloseImpersonatedSession()
                '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
                '        '''Implementar Descuento Adicional
                '        grdDetalle.Cols(6).AllowEditing = True
                '        Me.boolDescuentoDPakete = True 'TODO:Ray kitar este variable cuando se implemente DPakete
                '    Else
                '        '''Implementar Descuento Adicional
                '        grdDetalle.Cols(6).AllowEditing = False
                '    End If

                'End If

        End Select

    End Sub

    Private Function BuscarCodigoEnDetalle(ByVal Codigo As String, ByVal Talla As String, ByVal dtDetalle As DataTable) As Integer

        Dim i As Integer = 0

        For Each oRow As DataRow In dtDetalle.Rows
            If CStr(oRow!Codigo).Trim.ToUpper = Codigo.ToUpper.Trim AndAlso CStr(oRow!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then
                Return i
            End If
            i += 1
        Next

        Return -1

    End Function

    Private Sub LimpiaStatusTemp(ByRef dtTemp As DataTable, ByVal Indices As String)

        Dim i As Integer = 0

        For Each oRow As DataRow In dtTemp.Rows

            If oRow!UsadoPromo = False AndAlso InStr(Indices, CStr(i).Trim) <= 0 Then
                oRow!Checado = False
            End If
            i += 1

        Next
        dtTemp.AcceptChanges()

    End Sub

    Private Function ObtenerCodigosPorMarca(ByVal CodMarca As String, ByVal dtDetTemp As DataTable) As DataTable

        Dim dtTemp As DataTable = dtDetTemp.Clone
        Dim oCol As DataColumn
        Dim oNewRow As DataRow
        Dim i As Integer = 0

        oCol = New DataColumn("idxDetalle")
        oCol.DataType = System.Type.GetType("System.Int32")
        oCol.DefaultValue = 0
        dtTemp.Columns.Add(oCol)
        dtTemp.AcceptChanges()

        For Each oRow As DataRow In dtDetTemp.Rows

            With oRow

                If CStr(!Codigo).Substring(0, 2).ToUpper.Trim = CodMarca.ToUpper.Trim Then

                    oNewRow = dtTemp.NewRow
                    oNewRow!Codigo = oRow!Codigo
                    oNewRow!Talla = !Talla
                    oNewRow!Cantidad = !Cantidad
                    oNewRow!Importe = !Importe
                    oNewRow!Total = !Total
                    oNewRow!Descuento = !Descuento
                    oNewRow!Adicional = !Adicional
                    oNewRow!Checado = !Checado
                    oNewRow!UsadoPromo = !UsadoPromo
                    oNewRow!idxDetalle = i
                    dtTemp.Rows.Add(oNewRow)

                End If

            End With

            i += 1

        Next
        dtTemp.AcceptChanges()

        Return dtTemp

    End Function

    Private Sub LimpiaStatusPromo(ByRef dtDetalleTemp As DataTable, ByVal IsPorMarca As Boolean, ByRef dtDetalle As DataTable)

        Dim i As Integer = 0

        For Each oRow As DataRow In dtDetalleTemp.Rows
            If oRow!UsadoPromo Then
                If IsPorMarca Then
                    'grdDetalle(oRow!idxDetalle, 6) = 0
                    dtDetalle.Rows(oRow!idxDetalle)!Adicional = 0
                Else
                    'grdDetalle(i, 6) = 0
                    dtDetalleTemp.Rows(i)!Adicional = 0
                End If
            End If
            If IsPorMarca Then
                'grdDetalle(oRow!idxDetalle, 7) = False
                'grdDetalle(oRow!idxDetalle, 8) = False
                dtDetalle.Rows(oRow!idxDetalle)!Checado = False
                dtDetalle.Rows(oRow!idxDetalle)!UsadoPromo = False
            End If
            oRow!Checado = False
            oRow!UsadoPromo = False
            i += 1
        Next
        dtDetalleTemp.AcceptChanges()
        dtDetalle.AcceptChanges()

    End Sub

    Private Function AplicaPromocion2x1YMedio(ByRef dtDetalleTemp As DataTable, ByVal IsPorMarca As Boolean, ByRef dtDetalle As DataTable, _
                                         ByVal Limpiar As Boolean, ByRef PromoID As Integer) As Boolean()
        Dim aplica() As Boolean = {False, False}
        If Limpiar Then LimpiaStatusPromo(dtDetalleTemp, IsPorMarca, dtDetalle)
        Dim bAplica As Boolean = False
        If dtDetalleTemp.Rows.Count > 1 Then

            Dim idxMay As Integer = 0, idxMen As Integer = 0
            Dim ImpMayor As Decimal = 0, ImpMenor As Decimal = 0
            Dim PorcDescSis As Decimal = 0
            Dim DescSis As Decimal = 0
            Dim dtView As DataView
            Dim i As Integer = 0
            Dim idxs As String = "" 'Indices de los codigos con importe mayor ya checados
            Dim cantTotal As Integer 'Se usa para contar el total de codigos descartando los DT-CAT
            'Dim OtraPromo As Boolean = False

Regresa:

            cantTotal = 0

            LimpiaStatusTemp(dtDetalleTemp, idxs)

            dtView = New DataView(dtDetalleTemp, "Checado = False", "Descuento", DataViewRowState.CurrentRows)

            If IsPorMarca = False Then
                For Each dvRow As DataRowView In dtView
                    If Mid(CStr(dvRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
                        cantTotal += 1
                    End If
                Next
            Else
                cantTotal = dtView.Count
            End If

            'If dtView.Count > 1 Then
            If cantTotal > 1 Then

                ImpMayor = 0
                i = 0
                For Each oRowTemp As DataRow In dtDetalleTemp.Rows

                    If oRowTemp!Checado = False AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" _
                    AndAlso ImpMayor < (oRowTemp!Importe - oRowTemp!Descuento) Then
                        ImpMayor = oRowTemp!Importe - oRowTemp!Descuento
                        idxMay = i
                    End If
                    i += 1

                Next

                idxs &= idxMay & ","

                For j As Integer = 1 To dtDetalleTemp.Rows.Count

                    dtView = New DataView(dtDetalleTemp, "Checado = False", "", DataViewRowState.CurrentRows)

                    If dtView.Count > 0 Then
                        '-------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 16.06.2014: Se modifico para en base a la configuracion emparejar entre los 2 articulos de mayor precio
                        'o el de mayor precio con el de menor de la factura como se ha hecho hasta hoy
                        '-------------------------------------------------------------------------------------------------------------------
                        i = 0
                        If oConfigCierreFI.EmparejarMayorPrecio2x1 Then
                            ImpMenor = 0
                            idxMen = -1
                            For Each oRowTemp As DataRow In dtDetalleTemp.Rows
                                If oRowTemp!Checado = False AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" AndAlso _
                                ImpMenor <= (oRowTemp!Importe - oRowTemp!Descuento) AndAlso i <> idxMay Then
                                    ImpMenor = oRowTemp!Importe - oRowTemp!Descuento
                                    idxMen = i
                                End If
                                i += 1
                            Next
                        Else
                            ImpMenor = ImpMayor
                            idxMen = idxMay
                            For Each oRowTemp As DataRow In dtDetalleTemp.Rows
                                If oRowTemp!Checado = False AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" AndAlso _
                                ImpMenor >= (oRowTemp!Importe - oRowTemp!Descuento) Then
                                    ImpMenor = oRowTemp!Importe - oRowTemp!Descuento
                                    idxMen = i
                                End If
                                i += 1
                            Next
                        End If

                        'idxdet = BuscarCodigoEnDetalle(dtDetalleTemp.Rows(idxMay)!Codigo, dtDetalleTemp.Rows(idxMay)!Talla)

                        'idxdet = BuscarCodigoEnDetalle(dtDetalleTemp.Rows(idxMen)!Codigo, dtDetalleTemp.Rows(idxMen)!Talla)

                        dtDetalleTemp.Rows(idxMen)!Checado = True

                        If IsPorMarca Then
                            'grdDetalle(dtDetalleTemp.Rows(idxMen)!idxDetalle, 8) = True
                            dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Checado = True
                            PorcDescSis = Decimal.Round((dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Descuento * 100 / dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Total), 2)
                            DescSis = dtDetalle.Rows(dtDetalleTemp.Rows(idxMay)!idxDetalle)!Descuento
                        Else
                            PorcDescSis = Decimal.Round((dtDetalle.Rows(idxMen)!Descuento * 100 / dtDetalle.Rows(idxMen)!Total), 2)
                            DescSis = dtDetalle.Rows(idxMay)!Descuento
                        End If
                        '------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 07/05/2013: Se modificó por solicitud de Jose Oscar Sanches las reglas del 2 x 1 ½, pero se dejó configurable 
                        'en caso de que quieran regresar a la forma anterior de la aplicación de la promoción
                        '------------------------------------------------------------------------------------------------------------------------
                        Dim bResultado As Boolean = False

                        If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                            'Forma anterior, el de mayor precio debe ser de precio entero y el de menor debe de tener un descuento menor al 50%
                            If DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idxMen <> idxMay Then bResultado = True
                        Else
                            'Forma nueva no importa si el de precio mayor tiene un descuento por sistema y el de menor precio tiene un decuento
                            'mayor al 50%, de todas formas aplica
                            If idxMen <> idxMay Then bResultado = True
                        End If
                        'If DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idxMen <> idxMay Then
                        If bResultado Then

                            dtDetalleTemp.Rows(idxMay)!UsadoPromo = True
                            dtDetalleTemp.Rows(idxMen)!UsadoPromo = True
                            bAplica = True
                            If IsPorMarca Then
                                dtDetalle.Rows(dtDetalleTemp.Rows(idxMay)!idxDetalle)!UsadoPromo = True
                                dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!UsadoPromo = True
                                dtDetalle.Rows(dtDetalleTemp.Rows(idxMay)!idxDetalle)!Checado = True
                                dtDetalle.Rows(dtDetalleTemp.Rows(idxMay)!idxDetalle)!Adicional = 0
                                If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                                    'Forma anterior, se le aplica el resto que le hace falta para completar el 50% de descuento
                                    dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                                Else
                                    'Forma nueva, se le aplica el 50% de descuento sin importar el descuento que ya tenga por sistema
                                    dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Adicional = 50
                                End If
                                'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                                dtDetalle.Rows(dtDetalleTemp.Rows(idxMen)!idxDetalle)!Condicion = "ZDP4"
                                aplica(1) = True
                            Else
                                dtDetalle.Rows(idxMay)!Adicional = 0
                                If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                                    'Forma anterior, se le aplica el resto que le hace falta para completar el 50% de descuento
                                    dtDetalle.Rows(idxMen)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                                Else
                                    'Forma nueva, se le aplica el 50% de descuento sin importar el descuento que ya tenga por sistema
                                    dtDetalle.Rows(idxMen)!Adicional = 50
                                End If
                                dtDetalle.Rows(idxMen)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                                'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                                dtDetalle.Rows(idxMen)!Condicion = "ZDP4"
                                aplica(0) = True
                            End If

                            dtDetalleTemp.Rows(idxMay)!Checado = True
                            j = dtDetalleTemp.Rows.Count
                        End If

                        dtDetalleTemp.AcceptChanges()
                        dtDetalle.AcceptChanges()

                    End If

                Next

                GoTo Regresa

            End If

        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si aplicó la promoción agregamos las formas de pago para la que solo está permitida
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If bAplica Then
            If IsPorMarca Then
                AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1½M")
            Else
                AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1½G")
            End If
        End If
        Return aplica
    End Function

    Private Function AplicaPromocion2x1YMedioPorCodigo(ByRef dtDetalle As DataView, ByVal oRow As DataRowView, ByVal idx As Integer, ByVal PromoID As Integer) As Boolean

        'LimpiaStatusPromo(dtDetalle, False, dtDetalle)
        Dim aplico As Boolean = False
        Dim idxs As String = "" 'Indices de los codigos con importe mayor ya checados
        If dtDetalle.Count > 1 Then

            Dim idxMay As Integer = 0 ',idxMen As Integer = 0
            Dim ImpMayor As Decimal = 0 ', ImpMenor As Decimal = 0
            Dim PorcDescSis As Decimal = 0
            Dim DescSis As Decimal = 0
            Dim dtView As DataView
            Dim i As Integer = 0


Regresa:

            'LimpiaStatusTemp(dtDetalle.Table, idxs)

            dtView = New DataView(dtDetalle.Table, "Checado = False and Importe >= " & CStr(oRow!Importe), "", DataViewRowState.CurrentRows)

            If dtView.Count > 0 Then

                ImpMayor = 0
                idxMay = 0
                i = 0
                For Each oRowTemp As DataRowView In dtDetalle

                    If oRowTemp!Checado = False AndAlso ImpMayor < oRowTemp!Importe AndAlso i <> idx AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
                        ImpMayor = oRowTemp!Importe
                        idxMay = i
                    End If
                    i += 1

                Next

                'idxs &= idxMay & ","

                dtDetalle(idx)!Checado = True
                dtDetalle(idxMay)!Checado = True

                PorcDescSis = Decimal.Round((dtDetalle(idx)!Descuento * 100 / dtDetalle(idx)!Total), 2)
                DescSis = dtDetalle(idxMay)!Descuento

                Dim CodArticulo As String = CStr(dtDetalle(idxMay)!Codigo)
                Dim tieneJerarquia As Boolean = oFacturaMgr.TieneJerarquiaDescuentoAdicional(PromoID, ebFechaFactura.Value, ebTipoVenta.Value)
                Dim bResultado As Boolean = False

                If tieneJerarquia Then
                    Dim jerarquiaIdx As String = oFacturaMgr.GetJerarquiaDescuentoAdicional(PromoID)
                    If Not jerarquiaIdx = Nothing Then
                        Dim DescuentoAdicional As Boolean = oFacturaMgr.GetDescuentoAdicionalIDByCodigo(CodArticulo, jerarquiaIdx, ebFechaFactura.Value, ebTipoVenta.Value)
                        '------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 07/05/2013: Se modificó por solicitud de Jose Oscar Sanches las reglas del 2 x 1 ½, pero se dejó configurable 
                        'en caso de que quieran regresar a la forma anterior de la aplicación de la promoción
                        '------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                            'Forma anterior, el de mayor precio debe ser de precio entero y el de menor debe de tener un descuento menor al 50%
                            If DescuentoAdicional AndAlso DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then bResultado = True
                        Else
                            'Forma nueva no importa si el de precio mayor tiene un descuento por sistema y el de menor precio tiene un descuento
                            'mayor al 50%, de todas formas aplica
                            If DescuentoAdicional AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then bResultado = True
                        End If
                        If bResultado Then
                            dtDetalle(idxMay)!UsadoPromo = True
                            dtDetalle(idx)!UsadoPromo = True

                            dtDetalle(idxMay)!Adicional = 0
                            If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                                'Forma anterior, se le aplica el resto que le hace falta para completar el 50% de descuento
                                dtDetalle(idx)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                            Else
                                'Forma nueva, se aplica el 50% de descuento sin importar el descuento por sistema que tenga
                                dtDetalle(idx)!Adicional = 50
                            End If
                            'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                            dtDetalle(idx)!Condicion = "ZDP4"
                            aplico = True
                            dtDetalle.Table.AcceptChanges()

                            GoTo Final
                        End If
                    End If
                Else
                    If DescSis > 0 Then idxs &= idxMay & ","
                    If PorcDescSis >= 50 Then idxs &= idx & ","
                    '------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 07/05/2013: Se modificó por solicitud de Jose Oscar Sanches las reglas del 2 x 1 ½, pero se dejó configurable 
                    'en caso de que quieran regresar a la forma anterior de la aplicación de la promoción
                    '------------------------------------------------------------------------------------------------------------------------
                    If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                        'Forma anterior, el de mayor precio debe ser de precio entero y el de menor debe de tener un descuento menor al 50%
                        If DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then bResultado = True
                    Else
                        'Forma nueva no importa si el de precio mayor tiene un descuento por sistema y el de menor precio tiene un descuento
                        'mayor al 50%, de todas formas aplica
                        If idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then bResultado = True
                    End If
                    If bResultado Then

                        dtDetalle(idxMay)!UsadoPromo = True
                        dtDetalle(idx)!UsadoPromo = True

                        dtDetalle(idxMay)!Adicional = 0
                        If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                            'Forma anterior, se le aplica el resto que le hace falta para completar el 50% de descuento
                            dtDetalle(idx)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                        Else
                            'Forma nueva, se aplica el 50% de descuento sin importar el descuento por sistema que tenga
                            dtDetalle(idx)!Adicional = 50
                        End If
                        'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                        dtDetalle(idx)!Condicion = "ZDP4"
                        aplico = True
                        dtDetalle.Table.AcceptChanges()

                        GoTo Final

                    End If
                End If

                dtDetalle.Table.AcceptChanges()

                GoTo Regresa

            End If

        End If
Final:
        LimpiaStatusTemp(dtDetalle.Table, idxs)
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If aplico Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1½C")
        Return aplico
    End Function

    '    Private Function AplicaPromocion2x1YMedioPorCodigo(ByRef dtDetalle As DataView, ByVal oRow As DataRowView, ByVal idx As Integer, ByVal PromoID As Integer) As Boolean

    '        'LimpiaStatusPromo(dtDetalle, False, dtDetalle)
    '        Dim aplico As Boolean = False
    '        Dim idxs As String = "" 'Indices de los codigos con importe mayor ya checados
    '        If dtDetalle.Count > 1 Then

    '            Dim idxMay As Integer = 0 ',idxMen As Integer = 0
    '            Dim ImpMayor As Decimal = 0 ', ImpMenor As Decimal = 0
    '            Dim PorcDescSis As Decimal = 0
    '            Dim DescSis As Decimal = 0
    '            Dim dtView As DataView
    '            Dim i As Integer = 0


    'Regresa:

    '            'LimpiaStatusTemp(dtDetalle.Table, idxs)

    '            dtView = New DataView(dtDetalle.Table, "Checado = False and Importe >= " & CStr(oRow!Importe), "", DataViewRowState.CurrentRows)

    '            If dtView.Count > 0 Then

    '                ImpMayor = 0
    '                idxMay = 0
    '                i = 0
    '                For Each oRowTemp As DataRowView In dtDetalle

    '                    If oRowTemp!Checado = False AndAlso ImpMayor < oRowTemp!Importe AndAlso i <> idx AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
    '                        ImpMayor = oRowTemp!Importe
    '                        idxMay = i
    '                    End If
    '                    i += 1

    '                Next

    '                'idxs &= idxMay & ","

    '                dtDetalle(idx)!Checado = True
    '                dtDetalle(idxMay)!Checado = True

    '                PorcDescSis = Decimal.Round((dtDetalle(idx)!Descuento * 100 / dtDetalle(idx)!Total), 2)
    '                DescSis = dtDetalle(idxMay)!Descuento

    '                Dim CodArticulo As String = CStr(dtDetalle(idxMay)!Codigo)
    '                Dim tieneJerarquia As Boolean = oFacturaMgr.TieneJerarquiaDescuentoAdicional(PromoID, ebFechaFactura.Value, ebTipoVenta.Value)

    '                If tieneJerarquia Then
    '                    Dim jerarquiaIdx As String = oFacturaMgr.GetJerarquiaDescuentoAdicional(PromoID)
    '                    If Not jerarquiaIdx = Nothing Then
    '                        Dim DescuentoAdicional As Boolean = oFacturaMgr.GetDescuentoAdicionalIDByCodigo(CodArticulo, jerarquiaIdx, ebFechaFactura.Value, ebTipoVenta.Value)
    '                        If DescuentoAdicional AndAlso DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then
    '                            dtDetalle(idxMay)!UsadoPromo = True
    '                            dtDetalle(idx)!UsadoPromo = True

    '                            dtDetalle(idxMay)!Adicional = 0
    '                            dtDetalle(idx)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
    '                            'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
    '                            dtDetalle(idx)!Condicion = "Z3AN"
    '                            aplico = True
    '                            dtDetalle.Table.AcceptChanges()

    '                            GoTo Final
    '                        End If
    '                    End If
    '                Else
    '                    If DescSis > 0 Then idxs &= idxMay & ","
    '                    If PorcDescSis >= 50 Then idxs &= idx & ","
    '                    If DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then

    '                        dtDetalle(idxMay)!UsadoPromo = True
    '                        dtDetalle(idx)!UsadoPromo = True

    '                        dtDetalle(idxMay)!Adicional = 0
    '                        dtDetalle(idx)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
    '                        'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
    '                        dtDetalle(idx)!Condicion = "Z3AN"
    '                        aplico = True
    '                        dtDetalle.Table.AcceptChanges()

    '                        GoTo Final

    '                    End If
    '                End If
    '                'If DescSis = 0 AndAlso PorcDescSis < 50 AndAlso idx <> idxMay AndAlso ImpMayor >= dtDetalle(idx)!Importe Then

    '                '    dtDetalle(idxMay)!UsadoPromo = True
    '                '    dtDetalle(idx)!UsadoPromo = True

    '                '    dtDetalle(idxMay)!Adicional = 0
    '                '    dtDetalle(idx)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
    '                '    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
    '                '    dtDetalle(idx)!Condicion = "Z3AN"
    '                '    aplico = True
    '                '    dtDetalle.Table.AcceptChanges()

    '                '    GoTo Final

    '                'End If

    '                dtDetalle.Table.AcceptChanges()

    '                GoTo Regresa

    '            End If

    '        End If
    'Final:
    '        LimpiaStatusTemp(dtDetalle.Table, idxs)
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        If aplico Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1½C")
    '        Return aplico
    '    End Function

    Private Function AplicaPromocionDPaketes(ByRef dtDetalle As DataTable) As Boolean

        Dim dtView As New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        Dim PorcSis As Decimal = 0
        Dim dtPaketes As DataTable
        Dim dtPaketesDet As DataTable
        Dim dtDpaketesPosibles As DataTable
        Dim dtCombinaciones As DataTable
        Dim idxs As String = ""
        Dim DPKTidxs As String = "" 'Se usa para ir guardando los codigos a los que se le aplicara el descuento de los dpaketes y su descuento
        Dim idx As Integer = 0
        Dim Folio As String
        Dim oNewRow As DataRow
        Dim i As Integer = 0
        Dim dtViewDPKT As DataView
        Dim dvMasPaketes As New DataView
        Dim bResult As Boolean = False

        If dtView.Count > 1 Then

            EstructuraCombinaciones(dtDpaketesPosibles, dtCombinaciones)

            For Each oRow As DataRowView In dtView

                dtPaketes = oFacturaMgr.IsCodigoEnDPakete(oRow!Codigo)

OtroDpakete:
                If dtPaketes.Rows.Count > 0 Then

                    Folio = ""
                    idxs = ""
                    DPKTidxs = ""
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Si el codigo pertenece a mas de un dpakete verificamos cada uno de ellos para validar todas las combinaciones posibles
                    '----------------------------------------------------------------------------------------------------------------------------
                    For Each oRowP As DataRow In dtPaketes.Rows
                        If oRowP!Checado = False Then
                            Folio = oRowP!FolioDpakete
                            oRowP!Checado = True
                            Exit For
                        End If
                    Next
                    dtPaketes.AcceptChanges()
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Validamos si ya checamos este dpakete y si es asi regresamos los codigos que ya aplicaron para que no se repitan
                    '----------------------------------------------------------------------------------------------------------------------------
                    idxs = IsDpaketeValidado(dtDpaketesPosibles, Folio)
                    '----------------------------------------------------------------------------------------------------------------------------
                    'Verificamos si el codigo ya se incluyo en el dpakete ya validado
                    '----------------------------------------------------------------------------------------------------------------------------
                    If InStr(idxs, i) <= 0 Then

                        dtPaketesDet = oFacturaMgr.GetDetalleDPakete(Folio)

                        If dtPaketesDet.Rows.Count > 0 Then
                            '------------------------------------------------------------------------------------------------------------------
                            'Buscamos los codigos del dpakete en el detalle de la factura
                            '------------------------------------------------------------------------------------------------------------------
                            BuscaCodigosEnDetalle(dtPaketesDet, dtView, idxs, DPKTidxs)

                            dtViewDPKT = New DataView(dtPaketesDet, "Checado=False", "", DataViewRowState.CurrentRows)

                            If dtViewDPKT.Count <= 0 Then
                                '--------------------------------------------------------------------------------------------------------------
                                'Se encontraron todos los codigos del dpakete en el detalle de la factura
                                'Lo agregamos en las posibles Dpaketes que aplican a la factura
                                '--------------------------------------------------------------------------------------------------------------
                                oNewRow = dtDpaketesPosibles.NewRow
                                oNewRow!FolioDpakete = Folio
                                oNewRow!Descuentos = DPKTidxs
                                dtDpaketesPosibles.Rows.Add(oNewRow)
                                dtDpaketesPosibles.AcceptChanges()
                            End If

                        End If

                    End If
                    '--------------------------------------------------------------------------------------------------------------------------
                    'Verificamos si pertenece a mas dpaketes el codigo
                    '--------------------------------------------------------------------------------------------------------------------------
                    dvMasPaketes = New DataView(dtPaketes, "Checado=False", "", DataViewRowState.CurrentRows)

                    If dvMasPaketes.Count > 0 Then GoTo OtroDpakete

                End If

                i += 1

            Next
            '---------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 19.08.2014: Ordenamos los posibles dpaketes a aplicar de la siguiente forma: si esta activa la configuracion de prioridad
            'por codigo de uso ordenamos en base a los dpaquetes que tengan algun material con ese codigo de uso, de lo contrario ordenamos por
            'el descuento del mayor al menor
            '---------------------------------------------------------------------------------------------------------------------------------
            dtDpaketesPosibles = OrdenaDpaketesPosibles(dtDpaketesPosibles, dtDetalle, dtView, oConfigCierreFI.DPKTPrioridadCodUso)
            '---------------------------------------------------------------------------------------------------------------------------------
            'Verificamos las posibles combinaciones de los dpaketes que aplican para saber cual es la mejor
            '---------------------------------------------------------------------------------------------------------------------------------
            Dim Combinacion As String = ""
            Dim idxsDet As String = ""
            Dim IdxsDesc As String = ""

            idxs = ""
            idx = 0
            For Each oRowCombi As DataRow In dtDpaketesPosibles.Rows
                Combinacion = ""
                DPKTidxs = ""
                idxsDet = ""
                IdxsDesc = ""
                LimpiaStatusPromo(dtDetalle, False, dtDetalle)

                If InStr(idxs, idx) <= 0 Then
                    dtPaketesDet = oFacturaMgr.GetDetalleDPakete(CStr(oRowCombi!FolioDpakete).Trim)
                    BuscaCodigosEnDetalle(dtPaketesDet, dtView, idxsDet, DPKTidxs)
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Aplicamos primero el dpakete actual
                    '---------------------------------------------------------------------------------------------------------------------------
                    AplicaDescuentosDpakete(dtView, DPKTidxs, oRowCombi!FolioDpakete, Combinacion, idx, IdxsDesc) ' dtDpaketesPosibles)
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Verificamos si entran otros dpaketes en combinacion
                    '---------------------------------------------------------------------------------------------------------------------------
                    i = 0
                    For Each oRowPD As DataRow In dtDpaketesPosibles.Rows
                        DPKTidxs = ""
                        If idx <> i Then
                            dtPaketesDet = oFacturaMgr.GetDetalleDPakete(CStr(oRowPD!FolioDpakete).Trim)
                            BuscaCodigosEnDetalle(dtPaketesDet, dtView, idxsDet, DPKTidxs)
                            dtViewDPKT = New DataView(dtPaketesDet, "Checado=False", "", DataViewRowState.CurrentRows)
                            '-------------------------------------------------------------------------------------------------------------------
                            'Sigue aplicando el dpakete en combinacion con otros
                            '-------------------------------------------------------------------------------------------------------------------
                            If dtViewDPKT.Count <= 0 Then
                                AplicaDescuentosDpakete(dtView, DPKTidxs, oRowPD!FolioDpakete, Combinacion, i, IdxsDesc) ' dtDpaketesPosibles)
                            End If
                        End If
                        i += 1
                    Next
                    '------------------------------------------------------------------------------------------------------------------
                    'Lo agregamos en las posibles combinaciones que aplican a la factura
                    '------------------------------------------------------------------------------------------------------------------
                    oNewRow = dtCombinaciones.NewRow
                    oNewRow!Combinacion = Combinacion
                    oNewRow!IndicesDescuentos = IdxsDesc
                    oNewRow!DescTotal = GetDescTotalFacturaParaDpakete(dtDetalle)
                    dtCombinaciones.Rows.Add(oNewRow)
                    dtCombinaciones.AcceptChanges()

                    idxs &= Combinacion
                End If
                idx += 1
            Next
            '------------------------------------------------------------------------------------------------------------------
            'Ordenamos las posibles combinaciones y aplicamos la de mayor descuento
            '------------------------------------------------------------------------------------------------------------------
            Dim dvMejorDpakete As New DataView(dtCombinaciones, "", "DescTotal DESC", DataViewRowState.CurrentRows)

            If dvMejorDpakete.Count > 0 Then
                LimpiaStatusPromo(dtDetalle, False, dtDetalle)

                AplicaDescuentosDpakete(dtView, dvMejorDpakete(0)!IndicesDescuentos, "", "", 0, "") ' dtDpaketesPosibles)
                bResult = True
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
                '-----------------------------------------------------------------------------------------------------------------------------------------
                Dim FoliosDpaketes() As String = CStr(dvMejorDpakete(0)!Combinacion).Trim.Split(",")
                Dim strFolio As String = ""
                For Each strFolio In FoliosDpaketes
                    If Not strFolio Is Nothing AndAlso strFolio.Trim <> "" Then
                        strFolio = dtDpaketesPosibles.Rows(strFolio)!FolioDpakete
                        If strFolio.Trim <> "" Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByDpakete(strFolio), "DPKT")
                    End If
                Next
            End If

        End If

        Return bResult

    End Function

    'Private Function OrdenaDpaketesPosibles(ByVal dtTempDPKT As DataTable, ByRef dtDetalle As DataTable, ByRef dtViewDet As DataView) As DataTable

    '    Dim dtTemp As DataTable = dtTempDPKT.Copy
    '    Dim i As Integer = 0
    '    Dim oNewCol As New DataColumn("Descuento", Type.GetType("System.String"))
    '    Dim dtTempSort As DataTable = dtTempDPKT.Clone
    '    Dim oRow As DataRow

    '    dtTemp.Columns.Add(oNewCol)
    '    dtTemp.AcceptChanges()

    '    For Each oRow In dtTempDPKT.Rows
    '        LimpiaStatusPromo(dtDetalle, False, dtDetalle)

    '        AplicaDescuentosDpakete(dtViewDet, oRow!Descuentos, "", "", 0, "") ' dtDpaketesPosibles)
    '        dtTemp.Rows(i)!Descuento = GetDescTotalFacturaParaDpakete(dtDetalle)
    '        i += 1
    '    Next
    '    dtTemp.AcceptChanges()

    '    Dim dtViewTemp As New DataView(dtTemp, "", "Descuento DESC", DataViewRowState.CurrentRows)

    '    For Each oRowV As DataRowView In dtViewTemp
    '        oRow = dtTempSort.NewRow
    '        oRow!FolioDpakete = oRowV!FolioDpakete
    '        oRow!Descuentos = oRowV!Descuentos
    '        dtTempSort.Rows.Add(oRow)
    '    Next
    '    dtTempSort.AcceptChanges()

    '    Return dtTempSort

    'End Function

    Private Function OrdenaDpaketesPosibles(ByVal dtTempDPKT As DataTable, ByRef dtDetalle As DataTable, ByRef dtViewDet As DataView, Optional ByVal bMochilazo As Boolean = False) As DataTable

        Dim dtTemp As DataTable = dtTempDPKT.Copy
        Dim i As Integer = 0
        Dim oNewCol As New DataColumn("Descuento", Type.GetType("System.String"))
        Dim dtTempSort As DataTable = dtTempDPKT.Clone
        Dim oRow As DataRow, dtPaketesDet As DataTable, oRowD As DataRow, oArticulo As Articulo

        If bMochilazo = False Then

            dtTemp.Columns.Add(oNewCol)
            dtTemp.AcceptChanges()

            For Each oRow In dtTempDPKT.Rows
                LimpiaStatusPromo(dtDetalle, False, dtDetalle)

                AplicaDescuentosDpakete(dtViewDet, oRow!Descuentos, "", "", 0, "") ' dtDpaketesPosibles)
                dtTemp.Rows(i)!Descuento = GetDescTotalFacturaParaDpakete(dtDetalle)
                i += 1
            Next
            dtTemp.AcceptChanges()

            Dim dtViewTemp As New DataView(dtTemp, "", "Descuento DESC", DataViewRowState.CurrentRows)

            For Each oRowV As DataRowView In dtViewTemp
                oRow = dtTempSort.NewRow
                oRow!FolioDpakete = oRowV!FolioDpakete
                oRow!Descuentos = oRowV!Descuentos
                oRow!PromoID = oRowV!PromoID
                dtTempSort.Rows.Add(oRow)
            Next
            dtTempSort.AcceptChanges()

        Else
            Dim EsMochila As Boolean, strMochilas As String = "", strOtro As String = ""
            '----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 19.08.2014: Separamos los dpaquetes que traen un material con el codigo de uso configurado de los demás depaquetes
            '----------------------------------------------------------------------------------------------------------------------------------
            For Each oRow In dtTempDPKT.Rows
                dtPaketesDet = oFacturaMgr.GetDetalleDPakete(oRow!FolioDpakete)
                EsMochila = False
                For Each oRowD In dtPaketesDet.Rows
                    oArticulo = oArticuloMgr.Load(CStr(oRowD!Codigo).Trim)
                    If IsNumeric(oArticulo.CodUso.Trim) AndAlso CLng(oArticulo.CodUso.Trim) = CLng(oConfigCierreFI.DPKTCodUso) Then
                        strMochilas &= i & ","
                        EsMochila = True
                        Exit For
                    End If
                Next
                If EsMochila = False Then strOtro &= i & ","
                i += 1
            Next

            Dim strMochilazo() As String, strOtros() As String, idx As String = ""
            '----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 19.08.2014: Ahora agregamos en primer lugar los dpaquetes con el codigo de uso configurado y despues los demas dpaquetes
            '----------------------------------------------------------------------------------------------------------------------------------
            If strMochilas.Trim <> "" Then
                strMochilazo = strMochilas.Trim.Split(",")
                For Each idx In strMochilazo
                    If idx.Trim <> "" Then
                        oRow = dtTempSort.NewRow
                        oRow!FolioDpakete = dtTempDPKT.Rows(CInt(idx))!FolioDpakete
                        oRow!Descuentos = dtTempDPKT.Rows(CInt(idx))!Descuentos
                        oRow!PromoID = dtTempDPKT.Rows(CInt(idx))!PromoID
                        dtTempSort.Rows.Add(oRow)
                    End If
                Next
            End If
            If strOtro.Trim <> "" Then
                strOtros = strOtro.Trim.Split(",")
                For Each idx In strOtros
                    If idx.Trim <> "" Then
                        oRow = dtTempSort.NewRow
                        oRow!FolioDpakete = dtTempDPKT.Rows(CInt(idx))!FolioDpakete
                        oRow!Descuentos = dtTempDPKT.Rows(CInt(idx))!Descuentos
                        oRow!PromoID = dtTempDPKT.Rows(CInt(idx))!PromoID
                        dtTempSort.Rows.Add(oRow)
                    End If
                Next

            End If
            dtTempSort.AcceptChanges()

        End If

        Return dtTempSort

    End Function

    Private Function IsDpaketeValidado(ByVal dtTemp As DataTable, ByVal Folio As String) As String

        Dim strIdxs() As String
        Dim Result() As String
        Dim idxs As String = ""

        For Each oRow As DataRow In dtTemp.Rows
            If CLng(oRow!FolioDpakete) = CLng(Folio) Then
                Result = CStr(oRow!Descuentos).Split("|")
                For Each str As String In Result
                    If str.Trim <> "" Then
                        strIdxs = str.Split("°")
                        idxs &= strIdxs(0) & ","
                    End If
                Next
            End If
        Next

        Return idxs

    End Function

    Private Sub AplicaDescuentosDpakete(ByRef dvDetalle As DataView, ByVal Descuentos As String, ByVal Folio As String, ByRef Combinacion As String, _
                                        ByVal idxDpakete As Integer, ByRef IndicesDesc As String) 'ByRef dtDPaketeTemp As DataTable)
        Dim Result() As String = Descuentos.Split("|")
        Dim Descuento() As String
        Dim idxRow As Integer = 0
        Dim Desc As Decimal = 0
        Dim AplicaDpakete As Boolean = True

        'Validamos si el dpakete aplica o ya otro le gano los codigos
        For Each str As String In Result
            If str.Trim <> "" Then
                Descuento = str.Split("°")
                idxRow = CInt(Descuento(0))

                If dvDetalle(idxRow)!UsadoPromo = True Then
                    AplicaDpakete = False
                    Exit For
                End If
            End If
        Next
        If AplicaDpakete Then
            'Aplicamos los descuentos del dpakete al detalle de la factura
            Combinacion &= idxDpakete & ","
            'dtDPaketeTemp.Rows(idxDpakete)!Descuentos = Descuentos
            IndicesDesc &= Descuentos
            'dtDPaketeTemp.AcceptChanges()
            For Each str As String In Result
                If str.Trim <> "" Then
                    Descuento = str.Split("°")
                    idxRow = CInt(Descuento(0))
                    Desc = CDec(Descuento(1))

                    dvDetalle(idxRow)!Condicion = "ZDP4"
                    dvDetalle(idxRow)!Adicional = Desc
                    dvDetalle(idxRow)!UsadoPromo = True
                    dvDetalle(idxRow)!Checado = True
                End If
            Next
            dvDetalle.Table.AcceptChanges()
        End If

    End Sub

    Private Function GetDescTotalFacturaParaDpakete(ByVal dtDetalle As DataTable) As Decimal

        Dim oRow As DataRow
        Dim vDscto As Decimal = 0
        Dim vDsctoAdicional As Decimal = 0

        For Each oRow In dtDetalle.Rows
            vDscto = vDscto + oRow("Descuento")
            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
        Next

        Return vDscto + vDsctoAdicional

    End Function

    Private Sub EstructuraCombinaciones(ByRef dtTemp As DataTable, ByRef dtCombi As DataTable)

        Dim oNewCol As DataColumn
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Generamos Estructura para tabla de los posibles dpaketes
        '-----------------------------------------------------------------------------------------------------------------------------------------
        dtTemp = New DataTable("PosiblesDpaketes")

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "FolioDpakete"
            .DataType = System.Type.GetType("System.String")
            .DefaultValue = ""
        End With
        dtTemp.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "Descuentos"
            .DataType = System.Type.GetType("System.String")
            .DefaultValue = ""
        End With
        dtTemp.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "PromoID"
            .DataType = System.Type.GetType("System.Int32")
            .DefaultValue = 0
        End With
        dtTemp.Columns.Add(oNewCol)

        dtTemp.AcceptChanges()

        'Generamos estructura para las posibles combinaciones
        dtCombi = New DataTable("PosiblesCombinaciones")

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "Combinacion"
            .DataType = System.Type.GetType("System.String")
            .DefaultValue = ""
        End With
        dtCombi.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "IndicesDescuentos"
            .DataType = System.Type.GetType("System.String")
            .DefaultValue = ""
        End With
        dtCombi.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "DescTotal"
            .DataType = System.Type.GetType("System.Decimal")
            .DefaultValue = 0
        End With
        dtCombi.Columns.Add(oNewCol)

        dtCombi.AcceptChanges()

    End Sub

    Private Sub BuscaCodigosEnDetalle(ByRef dtTemp As DataTable, ByRef dtView As DataView, ByRef idxs As String, ByRef DPKTidxs As String)

        Dim idxsTemp As String = idxs

        For Each oRowPD As DataRow In dtTemp.Rows
            If CodigoEnDpakete(oRowPD!Codigo, oRowPD!Descuento, dtView, idxsTemp, DPKTidxs) Then
                oRowPD!Checado = True
                DPKTidxs &= oRowPD!Descuento & "|"
            End If
        Next
        dtTemp.AcceptChanges()

        Dim dtViewTemp As New DataView(dtTemp, "Checado = False", "", DataViewRowState.CurrentRows)

        If dtViewTemp.Count <= 0 Then
            idxs = idxsTemp
        End If

    End Sub

    Private Function CodigoEnDpakete(ByVal Codigo As String, ByRef Descuento As Decimal, ByRef dvTemp As DataView, ByRef Indices As String, _
                                     ByRef DPKTIdxs As String) As Boolean
        Dim idx As Integer = 0
        Dim PorcSis As Decimal = 0

        For Each oRow As DataRowView In dvTemp
            If InStr(Indices, idx) <= 0 AndAlso Codigo.Trim.ToUpper = CStr(oRow!Codigo).Trim.ToUpper Then
                'PorcSis = Math.Round((oRow!Descuento * 100 / oRow!Total), 2)
                'If PorcSis < Descuento Then
                Indices &= idx & ","
                DPKTIdxs &= idx & "°"
                'Descuento = Descuento - PorcSis
                'If Checar = True Then oRow!Checado = True
                Return True
                'End If
            End If
Sigue:
            idx += 1
        Next

        Return False
    End Function

    Private Sub CodigoEnDetalle(ByVal Codigo As String, ByVal dvTemp As DataView, ByRef idx As Integer)
        Dim i As Integer = 0

        For Each oRow As DataRowView In dvTemp
            If CStr(oRow!Codigo).Trim.ToUpper = Codigo.Trim.ToUpper AndAlso i <> idx Then
                idx = i
                Exit For
            End If
            i += 1
        Next

    End Sub

    Private Function AplicaPromocion20y30(ByRef dtDetalle As DataTable, ByVal PromoID As Integer) As Boolean
        Dim dtView As New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
        Dim PorcSis As Decimal = 0
        'Dim OtraPromo As Boolean = False
        'Dim idxMay As Integer, idxSeg As Integer, idxTer As Integer
        Dim idxs As String = ""
        Dim aplica As Boolean = False
        Dim bAplica As Boolean = False
        If dtView.Count > 1 Then

            'For Each oRowV As DataRowView In dtView
            'oRowV!Checado = False
            'Next

            'LimpiaStatusPromo(dtDetalle, False, dtDetalle)
            i = 0
            For Each oRow As DataRowView In dtView

                'idxMay = i
                'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRow!Codigo)
                'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRow!Codigo) > 0, True, False)

                If oRow!Descuento <= 0 AndAlso InStr(idxs, i) <= 0 AndAlso oRow!UsadoPromo = False Then 'AndAlso Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                    idxs &= i & ","
                    j = 0
                    For Each oRowS As DataRowView In dtView

                        'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowS!Codigo)
                        'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRowS!Codigo) > 0, True, False)

                        If oRowS!Descuento <= 0 AndAlso InStr(idxs, j) <= 0 AndAlso oRow!Importe >= oRowS!Importe AndAlso oRowS!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowS!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                            idxs &= j & ","
                            k = 0
                            'If j = dtView.Count - 1 Then
                            dtView(i)!UsadoPromo = True
                            dtView(j)!UsadoPromo = True
                            dtView(i)!Checado = True
                            dtView(j)!Checado = True
                            'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                            dtView(j)!Condicion = "ZDP4"
                            dtView(i)!Adicional = 0
                            dtView(j)!Adicional = 20
                            'Exit Sub
                            'End If
                            aplica = True
                            'idxSeg = j
                            For Each oRowT As DataRowView In dtView

                                'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowT!Codigo)
                                'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRowT!Codigo) > 0, True, False)

                                PorcSis = Math.Round((oRowT!Descuento * 100 / oRowT!Total), 2)
                                If PorcSis < 30 AndAlso InStr(idxs, k) <= 0 AndAlso oRowS!Importe >= oRowT!Importe AndAlso oRowT!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowT!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
                                    idxs &= k & ","
                                    'idxTer = k

                                    'dtView(i)!UsadoPromo = True
                                    'dtView(j)!UsadoPromo = True
                                    dtView(k)!UsadoPromo = True
                                    'dtView(i)!Checado = True
                                    'dtView(j)!Checado = True
                                    dtView(k)!Checado = True
                                    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                                    'dtView(j)!Condicion = "Z3AN"
                                    dtView(k)!Condicion = "ZDP4"
                                    'dtView(i)!Adicional = 0
                                    'dtView(j)!Adicional = 20
                                    dtView(k)!Adicional = 30 - PorcSis
                                    GoTo Sigue

                                End If
                                k += 1

                            Next

                        End If
                        j += 1

                    Next

                End If
Sigue:
                i += 1

            Next

            dtDetalle.AcceptChanges()

        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If aplica Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "20y30")
        Return aplica
    End Function

    '    Private Function AplicaPromocion20y30Codigo(ByRef dtDetalle As DataTable, ByVal PromoID As Integer) As Boolean
    '        Dim dtView As New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
    '        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
    '        Dim PorcSis As Decimal = 0
    '        'Dim OtraPromo As Boolean = False
    '        'Dim idxMay As Integer, idxSeg As Integer, idxTer As Integer
    '        Dim idxs As String = ""
    '        Dim aplica As Boolean = False
    '        Dim bAplica As Boolean = False
    '        If dtView.Count > 1 Then

    '            'For Each oRowV As DataRowView In dtView
    '            'oRowV!Checado = False
    '            'Next

    '            'LimpiaStatusPromo(dtDetalle, False, dtDetalle)
    '            i = 0
    '            For Each oRow As DataRowView In dtView

    '                'idxMay = i
    '                'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRow!Codigo)
    '                'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRow!Codigo) > 0, True, False)

    '                If oRow!Descuento <= 0 AndAlso InStr(idxs, i) <= 0 AndAlso oRow!UsadoPromo = False Then 'AndAlso Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

    '                    idxs &= i & ","
    '                    j = 0
    '                    For Each oRowS As DataRowView In dtView

    '                        'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowS!Codigo)
    '                        'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRowS!Codigo) > 0, True, False)
    '                        If oRowS!Descuento <= 0 AndAlso InStr(idxs, j) <= 0 AndAlso oRow!Importe >= oRowS!Importe AndAlso oRowS!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowS!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
    '                            If oFacturaMgr.TienePromocion20y30ByCodigo(oRowS!Codigo, ebFechaFactura.Value, ebTipoVenta.Value) Then
    '                                idxs &= j & ","
    '                                k = 0
    '                                'If j = dtView.Count - 1 Then
    '                                dtView(i)!UsadoPromo = True
    '                                dtView(j)!UsadoPromo = True
    '                                dtView(i)!Checado = True
    '                                dtView(j)!Checado = True
    '                                'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
    '                                dtView(j)!Condicion = "Z3AN"
    '                                dtView(i)!Adicional = 0
    '                                dtView(j)!Adicional = 20
    '                                'Exit Sub
    '                                'End If
    '                                aplica = True
    '                                'idxSeg = j
    '                                For Each oRowT As DataRowView In dtView

    '                                    'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowT!Codigo)
    '                                    'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRowT!Codigo) > 0, True, False)

    '                                    PorcSis = Math.Round((oRowT!Descuento * 100 / oRowT!Total), 2)
    '                                    If PorcSis < 30 AndAlso InStr(idxs, k) <= 0 AndAlso oRowS!Importe >= oRowT!Importe AndAlso oRowT!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowT!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
    '                                        idxs &= k & ","
    '                                        'idxTer = k

    '                                        'dtView(i)!UsadoPromo = True
    '                                        'dtView(j)!UsadoPromo = True
    '                                        dtView(k)!UsadoPromo = True
    '                                        'dtView(i)!Checado = True
    '                                        'dtView(j)!Checado = True
    '                                        dtView(k)!Checado = True
    '                                        'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
    '                                        'dtView(j)!Condicion = "Z3AN"
    '                                        dtView(k)!Condicion = "Z3AN"
    '                                        'dtView(i)!Adicional = 0
    '                                        'dtView(j)!Adicional = 20
    '                                        dtView(k)!Adicional = 30 - PorcSis
    '                                        GoTo Sigue

    '                                    End If
    '                                    k += 1

    '                                Next
    '                            End If

    '                        End If
    '                        j += 1

    '                    Next

    '                End If
    'Sigue:
    '                i += 1

    '            Next

    '            dtDetalle.AcceptChanges()

    '        End If
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
    '        '-----------------------------------------------------------------------------------------------------------------------------------------
    '        If aplica Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "20y30C")
    '        Return aplica
    '    End Function

    'Private Function AplicaDescuentoFijo(ByVal dtDetalle As DataTable) As Boolean

    '    Dim DescFijo As Decimal = 0
    '    Dim PromoID As Integer = 0
    '    Dim Band As Boolean = oFacturaMgr.GetDescuentoAdicionalFijoByCliente(Me.ebClienteID.Text.Trim.PadLeft(10, "0"), DescFijo, PromoID)
    '    Dim PorcDescSis As Decimal = 0
    '    Dim MontoFijo As Decimal = 0
    '    Dim PorcDif As Decimal = 0
    '    Dim TotalDesc As Decimal = 0
    '    Dim bAplica As Boolean = False

    '    If Band AndAlso dtDetalle.Rows.Count > 0 Then

    '        For Each oRow As DataRow In dtDetalle.Rows

    '            If Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

    '                bAplica = True
    '                PorcDescSis = Decimal.Round((oRow!Descuento * 100) / oRow!Total, 2)
    '                If PorcDescSis < DescFijo Then
    '                    MontoFijo = Decimal.Round(oRow!Total - (oRow!Total * (DescFijo / 100)), 2)
    '                    TotalDesc = Decimal.Round(oRow!Total - oRow!Descuento, 2)
    '                    PorcDif = Decimal.Round((TotalDesc - MontoFijo) * 100 / TotalDesc, 2)
    '                    oRow!Adicional = PorcDif
    '                    oRow!Condicion = "Z3AN"
    '                Else
    '                    oRow!Adicional = 0
    '                    oRow!Condicion = ""
    '                    'Band = False
    '                End If

    '            End If

    '        Next

    '        dtDetalle.AcceptChanges()

    '    End If

    '    If bAplica Then
    '        AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromoFijo(PromoID), "DF")
    '    End If

    '    Return Band

    'End Function

    Private Function AplicaDescuentoFijo(ByVal dtDetalle As DataTable) As Boolean

        Dim DescFijo As Decimal = 0
        Dim PromoID As Integer = 0
        Dim htDatosDesc As Hashtable
        Dim Band As Boolean = oFacturaMgr.GetDescuentoAdicionalFijoByCliente(Me.ebClienteID.Text.Trim.PadLeft(10, "0"), htDatosDesc) ' DescFijo, PromoID)
        Dim PorcDescSis As Decimal = 0
        Dim MontoFijo As Decimal = 0
        Dim PorcDif As Decimal = 0
        Dim TotalDesc As Decimal = 0
        Dim bAplica As Boolean = False, bVigente As Boolean = False

        If Band AndAlso dtDetalle.Rows.Count > 0 Then

            DescFijo = htDatosDesc("DescFijo")
            PromoID = htDatosDesc("PromoID")
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 07.08.2015: Si es un cliente Dip Corporativo entonces le decimos que no valide si ya compro el catalogo nuevo siempre y 
            '                     cuando tenga los 4 meses de vigencia
            '-------------------------------------------------------------------------------------------------------------------------------------
            If CDate(htDatosDesc("Fecha")).AddMonths(4) >= Today Then
                bVigente = True
            Else
                bVigente = False
            End If
            If CBool(htDatosDesc("DipCorp")) = True AndAlso bVigente Then
                strLlevaCatalogo = "S"
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 07.08.2015: Validamos si es un dip corporativo entonces y esta vigente o el cliente no es dip corporativo entonce aplica el
            '                     descuento fijo
            '-------------------------------------------------------------------------------------------------------------------------------------
            If (htDatosDesc("DipCorp") = True AndAlso bVigente) OrElse htDatosDesc("DipCorp") = False Then

                For Each oRow As DataRow In dtDetalle.Rows
                    If EsCatalogo(oRow!Codigo) = False Then
                        'If Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                        bAplica = True
                        PorcDescSis = Decimal.Round((oRow!Descuento * 100) / oRow!Total, 2)
                        If PorcDescSis < DescFijo Then
                            If IsDip(oRow!Codigo) = True Then
                                MontoFijo = Decimal.Round(oRow!Total - (oRow!Total * (DescFijo / 100)), 2)
                                TotalDesc = Decimal.Round(oRow!Total - oRow!Descuento, 2)
                                PorcDif = Decimal.Round((TotalDesc - MontoFijo) * 100 / TotalDesc, 2)
                                oRow!Adicional = PorcDif
                                oRow!Condicion = "ZDP4"
                            Else
                                MontoFijo = Decimal.Round(oRow!Total - (oRow!Total * (oConfigCierreFI.DescuentoFijoNoCatalogo / 100)), 2)
                                TotalDesc = Decimal.Round(oRow!Total - oRow!Descuento, 2)
                                PorcDif = Decimal.Round((TotalDesc - MontoFijo) * 100 / TotalDesc, 2)
                                oRow!Adicional = PorcDif
                                oRow!Condicion = "ZDP4"
                            End If

                        Else
                            oRow!Adicional = 0
                            oRow!Condicion = ""
                            'Band = False
                        End If

                    End If

                Next
            End If

            dtDetalle.AcceptChanges()

        End If

        If bAplica Then
            AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromoFijo(PromoID), "DF")
        End If

        Return Band

    End Function

    Private Function IsDip(ByVal Codigo As String) As Boolean
        Dim articuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim art As Articulo = articuloMgr.Create()
        art.ClearFields()
        articuloMgr.LoadInto(Codigo, art)
        Return art.Dip
    End Function

    Private Sub AgregaFormasPagoDescuento(ByVal dtFP As DataTable, ByVal CodPromo As String)

        Dim oRow As DataRow
        Dim dvExis As DataView
        Dim dtFPTotales As DataTable
        Dim bFiltrada As Boolean = True
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Primero validamos si la promoción realmente esta condicionada por algunas formas de pago, revisando si las formas de pago permitidas 
        'desde SAP son menos que las formas de pago totales permitidas en la bd local para el tipo de venta seleccionado
        '-----------------------------------------------------------------------------------------------------------------------------------------
        dtFPTotales = oFPMgr.GetAll(Me.ebTipoVenta.Value).Tables(0)
        'If Not dtFPTotales Is Nothing AndAlso dtFPTotales.Rows.Count > 0 Then
        '    For Each oRow In dtFPTotales.Rows
        '        dvExis = New DataView(dtFP, "CodFormaPago = '" & CStr(oRow!CodFormasPago).Trim.ToUpper & "'", "", DataViewRowState.CurrentRows)
        '        If dvExis.Count <= 0 Then
        '            bFiltrada = True
        '            Exit For
        '        End If
        '    Next
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si realmente si esta filtrada por solo algunas formas de pago entonces las agregamos a las permitidas por la promocion
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If bFiltrada Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Agregamos las formas de pago permitidas para esta promocion
            '-------------------------------------------------------------------------------------------------------------------------------------
            If dtDescFormasPago Is Nothing OrElse dtDescFormasPago.Rows.Count = 0 Then
                dtDescFormasPago = dtFP.Copy
            Else
                dvExis = New DataView(dtDescFormasPago)
                For Each oRow In dtFP.Rows
                    '---------------------------------------------------------------------------------------------------------------------------------
                    'Revisamos que la forma de pago no esté agregada para hacerlo
                    '---------------------------------------------------------------------------------------------------------------------------------
                    dvExis.RowFilter = "CodFormaPago = '" & CStr(oRow!CodFormaPago).Trim.ToUpper & "'"
                    If dvExis.Count <= 0 Then dtDescFormasPago.ImportRow(oRow)
                Next
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Ahora revisamos las promociones aplicadas para agregarla a la tabla con la que validamos posteriormente si aplica en base a algunas
            'formas de pago o no filtra y permite todas
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If Not dtPromoAplicada Is Nothing AndAlso dtPromoAplicada.Rows.Count > 0 Then
                dvExis = New DataView(dtPromoAplicada, "CodPromo = '" & CodPromo.Trim & "'", "", DataViewRowState.CurrentRows)
            End If
            If dvExis Is Nothing OrElse dvExis.Count <= 0 Then
                oRow = dtPromoAplicada.NewRow
                With oRow
                    !CodPromo = CodPromo.Trim
                    Select Case CodPromo.Trim
                        Case "2x1½G"
                            !Descripcion = "Dos Por Uno y Medio General"
                        Case "2x1½M"
                            !Descripcion = "Dos Por Uno y Medio Por Marca"
                        Case "2x1½C"
                            !Descripcion = "Dos Por Uno y Medio Por Codigo"
                        Case "20y30"
                            !Descripcion = "20 y 30 % General"
                        Case "20y30C"
                            !Descripcion = "20 y 30 % Por Codigo"
                        Case "DSDG"
                            !Descripcion = "Descuento Sobre Descuento General"
                        Case "DSDM"
                            !Descripcion = "Descuento Sobre Descuento Por Marca"
                        Case "DSDC"
                            !Descripcion = "Descuento Sobre Descuento Por Codigo "
                        Case "DF"
                            !Descripcion = "Descuento Fijo Por Cliente"
                        Case "DPKT"
                            !Descripcion = "Dpakete"
                        Case "BON"
                            !Descripcion = "Bonificacion"
                    End Select
                    '!Descripcion = Desc.Trim
                    If dtFP.Rows.Count > 0 Then
                        !ValidaFP = True
                    Else
                        !ValidaFP = False
                    End If
                End With
                dtPromoAplicada.Rows.Add(oRow)
            Else
                '-------------------------------------------------------------------------------------------------------------------------------
                'Si ya está aplicada la promoción anteriormente revisamos si está condicionada a alguna forma de pago y si es así, entonces 
                'actualizamos el campo ValidaFP a True para marcar que esta promoción sí está condicionada
                '-------------------------------------------------------------------------------------------------------------------------------
                If dtFP.Rows.Count > 0 Then dvExis(0)!ValidaFP = True
            End If
        End If

    End Sub

    Private Function IsPromoCondicionadaFP(ByVal CodPromo As String) As Boolean

        Dim bRes As Boolean = False
        Dim dvExis As DataView

        If dtPromoAplicada.Rows.Count > 0 Then
            dvExis = New DataView(dtPromoAplicada, "CodPromo = '" & CodPromo.Trim & "'", "", DataViewRowState.CurrentRows)
            If dvExis.Count > 0 Then
                bRes = dvExis(0)!ValidaFP
            End If
        End If

        Return bRes

    End Function

    Private Function AplicaDescuentosAutomaticos(ByVal dtDetalleTemp As DataTable, ByVal Porc As Decimal, ByVal bAceptaDescuento As Boolean, Optional ByRef oCupon As CuponDescuento = Nothing) As Boolean

        Dim Desc20y30 As Boolean = False
        Dim Desc20y30Codigo As Boolean = False
        Dim DosPorUnoYMedioGeneral As Boolean = False
        Dim DosPorUnoYMedioPorMarca As Boolean = False
        Dim DosPorUnoYMedioPorCodigo As Boolean = False
        Dim DescuentoFijo As Boolean = False
        Dim DescFijo As Decimal = 0
        Dim TipoVenta As Boolean = False
        Dim bolResult As Boolean = True
        Dim Dpaketes As Boolean = False
        Dim LimpiaStatus As Boolean = True
        Dim PromoID As Integer = 0
        Dim bCondicionada As Boolean
        Dim DescuentoSobreDescuento As Boolean = False
        Dim aplicoDesc20y30 As Boolean = False
        Dim aplicoDesc20y30Codigo As Boolean = False
        Dim aplicoDosPorUnoYMedio() As Boolean = {False, False}
        Dim aplicoDosPorUnoYMedioCodigo As Boolean = False

        If Not dtDescFormasPago Is Nothing Then dtDescFormasPago.Clear()


        '---------------------------------------------------------------------------------------
        'Aplicamos Descuento Fijo Por Cliente
        '---------------------------------------------------------------------------------------
        bCondicionada = IsPromoCondicionadaFP("DF")
        If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
            DescuentoFijo = AplicaDescuentoFijo(dtDetalleTemp)
        End If

        If DescuentoFijo = False Then

            LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
            '---------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/11/2013: Se agrego una validacion mas en caso de que la promocion de nuevo empleado no se aplique
            '                       toma la normal
            '---------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "E" AndAlso oConfigCierreFI.PromocionEmpleado = False Then
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento de Empleado
                '---------------------------------------------------------------------------------------
                AplicaDescuentoEmpleado(dtDetalleTemp, Porc)

                '----------------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (11/11/2015): En caso de que sea cupon para promoción del Buen Fin, no realiza esto
                '----------------------------------------------------------------------------------------------------------------------------------------
            ElseIf Not oCupon Is Nothing AndAlso oConfigCierreFI.CuponDescuentos = True AndAlso CStr(oCupon.InfoCupon("MODULO")).ToUpper() <> "SH" AndAlso CStr(oCuponDesc.InfoCupon("CUPON_CHECK")).ToUpper() <> "X" Then

                '---------------------------------------------------------------------------------------
                'Aplicamos Cupon de Descuento
                '---------------------------------------------------------------------------------------
                bolResult = AplicaPromocionEspecial(dtDetalleTemp, oCupon)

            ElseIf Not oCupon Is Nothing AndAlso oConfigCierreFI.CuponDescuentos = False Then
                '---------------------------------------------------------------------------------------
                'Aplicamos Cupon de Descuento
                '---------------------------------------------------------------------------------------

                bolResult = AplicaPromocionEspecial(dtDetalleTemp, oCupon)

            ElseIf oConfigCierreFI.AplicaCrossSelling = False Then
                '---------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 12.02.2015: Aplicamos este motor de promociones solo si no esta activa la config del nuevo motor de Cross Selling en SAP
                '---------------------------------------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento de los DPaketes y Street Packs
                '---------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("DPKT")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    Dpaketes = AplicaPromocionDPaketes(dtDetalleTemp)
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 20% y 30%
                '---------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("20y30")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    Desc20y30 = oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "20y30", PromoID)

                    If Desc20y30 Then
                        aplicoDesc20y30 = AplicaPromocion20y30(dtDetalleTemp, PromoID)
                    End If
                End If

                'bCondicionada = IsPromoCondicionadaFP("20y30C")

                ''---------------------------------------------------------------------------------------------------------------------------------
                ''Si esta procmocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                ''---------------------------------------------------------------------------------------------------------------------------------
                'If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                '    If aplicoDesc20y30 = False Then
                '        aplicoDesc20y30Codigo = AplicaPromocion20y30Codigo(dtDetalleTemp, PromoID)
                '    End If
                'End If

                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 ½ General
                '---------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("2x1½G")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    If Desc20y30 OrElse Dpaketes Then LimpiaStatus = False

                    TipoVenta = oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "2x1", PromoID)

                    If TipoVenta Then

                        DosPorUnoYMedioGeneral = oFacturaMgr.IsPromoDosPorUnoYMedioVigente("@@")

                        If DosPorUnoYMedioGeneral Then

                            aplicoDosPorUnoYMedio = AplicaPromocion2x1YMedio(dtDetalleTemp, False, dtDetalleTemp, LimpiaStatus, PromoID)

                        End If

                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 ½ Por Marca
                '---------------------------------------------------------------------------------------
                Dim CodMarca As String = ""
                Dim CodMarcas As String = ""

                bCondicionada = IsPromoCondicionadaFP("2x1½M")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then

                    If DosPorUnoYMedioGeneral = False Then

                        Dim dtDetMarcas As DataTable

                        For Each oRowTemp As DataRow In dtDetalleTemp.Rows

                            CodMarca = CStr(oRowTemp!Codigo).Substring(0, 2).ToUpper.Trim
                            TipoVenta = oFacturaMgr.IsTipoVentaPermitida(CodMarca, oFactura.CodTipoVenta, "2x1", PromoID)
                            DosPorUnoYMedioPorMarca = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CodMarca)

                            If TipoVenta AndAlso DosPorUnoYMedioPorMarca AndAlso InStr(CodMarcas, CodMarca) <= 0 AndAlso CodMarca <> "DT" Then

                                CodMarcas &= CodMarca & ","
                                dtDetMarcas = ObtenerCodigosPorMarca(CodMarca, dtDetalleTemp)
                                aplicoDosPorUnoYMedio = AplicaPromocion2x1YMedio(dtDetMarcas, True, dtDetalleTemp, LimpiaStatus, PromoID)

                            End If

                        Next

                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 ½ Por Codigo
                '---------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("2x1½C")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    If DosPorUnoYMedioGeneral = False Then

                        Dim i As Integer = 0
                        Dim dtDetalleView As DataView '(dtDetalleTemp, "", "Importe", DataViewRowState.CurrentRows)
                        '------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 24.10.2014: Se modifico para que en base a la nueva configuracion empareje los dos codigos mas caros o el mas
                        'barato con el mas caro como lo hacia antes
                        '------------------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.EmparejarMayorPrecio2x1 Then
                            dtDetalleView = New DataView(dtDetalleTemp, "", "Importe DESC", DataViewRowState.CurrentRows)
                        Else
                            dtDetalleView = New DataView(dtDetalleTemp, "", "Importe", DataViewRowState.CurrentRows)
                        End If
                        For Each oRowTemp As DataRowView In dtDetalleView

                            CodMarca = CStr(oRowTemp!Codigo).Substring(0, 2).ToUpper.Trim
                            TipoVenta = oFacturaMgr.IsTipoVentaPermitida(oRowTemp!Codigo, oFactura.CodTipoVenta, "2x1", PromoID)
                            DosPorUnoYMedioPorCodigo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowTemp!Codigo)

                            If TipoVenta AndAlso DosPorUnoYMedioPorCodigo AndAlso oRowTemp!UsadoPromo = False _
                            AndAlso InStr(CodMarcas, CodMarca) <= 0 AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                                aplicoDosPorUnoYMedioCodigo = AplicaPromocion2x1YMedioPorCodigo(dtDetalleView, oRowTemp, i, PromoID)

                            End If
                            i += 1

                        Next

                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Promocion Descuento Sobre Descuento
                '---------------------------------------------------------------------------------------
                DescuentoSobreDescuento = AplicaDescuentoSobreDescuento(dtDetalleTemp, bAceptaDescuento)
                '--------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Promocion Bonificacion Del Codigo Mas Caro
                '--------------------------------------------------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("BON")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    TipoVenta = oFacturaMgr.IsTipoVentaPermitida("BON", oFactura.CodTipoVenta, "BON", PromoID)
                    If TipoVenta Then
                        AplicaPromocionBonificacion(dtDetalleTemp, PromoID)
                    End If
                End If
            Else
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 14.11.2014: Si esta configurado aplicamos el nuevo motor de promociones Cross Selling en SAP
                '-------------------------------------------------------------------------------------------------------------------------------
                AplicaDescuentosCS(bAceptaDescuento, dtDetalleTemp)
            End If
            '---------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/11/2013: En caso de que la promoción de nuevo empleado si se aplique toma la nueva
            '---------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "E" AndAlso oConfigCierreFI.PromocionEmpleado = True Then
                AplicaNuevoDescuentoEmpleado(dtDetalleTemp, Porc)
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2013: Agrega promocion de Cupon a los DIPS y Socios
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Not oCupon Is Nothing AndAlso oConfigCierreFI.CuponDescuentos = True AndAlso CStr(oCupon.InfoCupon("MODULO")).ToUpper() = "SH" Then
                bolResult = AplicaPromocionEspecialCupon(dtDetalleTemp, oCupon, "ZDP4")
            End If
        End If
        Dim hash As New Hashtable(9)
        hash("Vale Empleado") = IIf(chkPromoEspecial.Checked = False, IIf(oFactura.CodTipoVenta = "E", True, False), False)
        hash("DPaketes") = IIf(chkPromoEspecial.Checked = False, Dpaketes, False)
        hash("Descuento 20 y 30") = IIf(chkPromoEspecial.Checked = False, aplicoDesc20y30, False)
        hash("Descuento 20 y 30 Por Codigo") = IIf(chkPromoEspecial.Checked = False, aplicoDesc20y30Codigo, False)
        hash("Dos por uno y medio general") = IIf(chkPromoEspecial.Checked = False, IIf(aplicoDosPorUnoYMedio(0) = True, True, False), False)
        hash("Dos por uno y medio por Marca") = IIf(chkPromoEspecial.Checked = False, IIf(aplicoDosPorUnoYMedio(1) = True, True, False), False)
        hash("Dos por uno y medio por Codigo") = IIf(chkPromoEspecial.Checked = False, aplicoDosPorUnoYMedioCodigo, False)
        hash("Descuento Fijo") = IIf(chkPromoEspecial.Checked = False, DescuentoFijo, False)
        hash("Descuento sobre Descuento") = IIf(chkPromoEspecial.Checked = False, DescuentoSobreDescuento, False)
        hash("Cupones") = chkPromoEspecial.Checked
        'hash("Descuento de Sistema") = TieneDescuento(dtDetalleTemp)

        CrearPromociones(hash)
        Dim count As Integer = Me.promociones.Rows.Count
        Return bolResult

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------
    'Funcion para aplicar los descuentos del nuevo motor del Cross Selling en SAP
    '------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub AplicaDescuentosCS(ByVal bAceptaPromo As Boolean, ByRef dtDetalleTemp As DataTable)
        Dim dtMatDesc As DataTable
        'Limpiamos la tabla de formas de pago condicionadas de las promociones
        If Not dtDescFormasPago Is Nothing Then dtDescFormasPago.Clear()
        '---------------------------------------------------------------------------------------
        'JNAVA (12.12.2014): Verificamos ke vengan datos en la tabla de detalel temporal
        '---------------------------------------------------------------------------------------
        If dtDetalleTemp Is Nothing Or dtDetalleTemp.Rows.Count = 0 Then
            GoTo Continua
        End If
        'Solo verificamos las promos en SAP si ya hay articulos en el detalle de la factura
        If dsDetalle.Tables(0).Rows.Count > 0 AndAlso dsDetalle.Tables(0).Rows(0)!Codigo <> "" AndAlso bAceptaPromo Then
            Dim htTotales As Hashtable, dtPromos As DataTable, dtCS As DataTable

            oSAPMgr.ZCS_ALGORITMO_PROMOS(dtDetalleTemp, Me.ebTipoVenta.Value, Today, htTotales, dtMatDesc, dtPromos, dtCS)
            'si se aplico algun descuento al detalle de la factura ejecutar la RFC de las formas de pago para saber por cuales formas de pago 
            'estan condicionadas
            ValidaPromoAplicadaCS(dtPromos)
        End If
Continua:
        '---------------------------------------------------------------------------------------------------------------------------
        'Pasamos los descuentos calculados en SAP al detalle de la factura
        '---------------------------------------------------------------------------------------------------------------------------
        ActualizaDescuentosCS(dtMatDesc, dtDetalleTemp)
    End Sub

    Private Sub ActualizaDescuentosCS(ByVal dtDesc As DataTable, ByRef dtDetalleTemp As DataTable)

        Dim oRow As DataRow
        Dim strTalla As String = "", dvDetalle As DataView, oRowV As DataRowView

        If dtDesc Is Nothing Then
            For Each oRow In dtDetalleTemp.Rows
                oRow!Adicional = 0
                oRow!Condicion = ""
            Next
        Else
            dvDetalle = New DataView(dtDetalleTemp, "", "", DataViewRowState.CurrentRows)
            For Each oRow In dtDesc.Rows
                'strTalla = CStr(oRow!Talla).Trim
                'If IsNumeric(strTalla) AndAlso InStr(strTalla, ".0") > 0 Then strTalla = CInt(strTalla)

                'idx = BuscarCodigoEnDetalle(CStr(oRow!MATNR).Trim, CStr(oRow!Talla), dtDetalleTemp)
                dvDetalle.RowFilter = "Codigo = '" & CStr(oRow!MATNR).Trim & "'" ' And Talla = '" & strTalla & "'"
                For Each oRowV In dvDetalle
                    oRowV!Adicional = oRow!Descto_Promo_PJE
                    oRowV!Condicion = "ZDP4"
                Next
                'If idx >= 0 Then
                '    If oRow!Descto_Promo_PJE > 0 Then
                '        dtDetalleTemp.Rows(idx)!Adicional = oRow!Descto_Promo_PJE
                '        dtDetalleTemp.Rows(idx)!Condicion = "Z3AN"
                '    Else
                '        dtDetalleTemp.Rows(idx)!Adicional = 0
                '        dtDetalleTemp.Rows(idx)!Condicion = ""
                '    End If
                'End If
            Next
        End If
        dtDetalleTemp.AcceptChanges()

    End Sub

    Private Function ValidaPromoAplicadaCS(ByVal dtDetalle As DataTable) As Boolean

        Dim bRes As Boolean = False
        Dim oRow As DataRow, strPromoID As String = "", strPromos() As String
        Dim dtFP As DataTable, dtFPSAP As DataTable, strID As String = "", dvFPSAP As DataView
        Dim oRowV As DataRowView, oNewRow As DataRow, dvFP As DataView, dtAllFP As DataTable

        For Each oRow In dtDetalle.Rows
            If oRow!Descto_Promo_Imp > 0 AndAlso InStr(strPromoID.Trim, CStr(oRow!promocion)) <= 0 Then
                strPromoID &= CStr(oRow!Promocion).Trim & ","
            End If
        Next
        'Si se aplicaron descuentos entonces revisamos las formas de pago permitidas para esta promociones
        If strPromoID.Trim <> "" Then

            '--------------------------------------------------------------------------------------
            ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
            '--------------------------------------------------------------------------------------
            'dtFPSAP = oSAPMgr.ZCS_PROMO_VIGENTES(Today).Copy
            Dim oRetail As New ProcesosRetail("/pos/cs", "POST")
            dtFPSAP = oRetail.SapZcsPromoVigentes(Today, "T" & oAppContext.ApplicationConfiguration.Almacen).Copy()
            '--------------------------------------------------------------------------------------
            'Generamos la estructura de la tabla a como la extrae de la bd local con el motor de promociones del DPPRO
            dtFP = New DataTable("FormasPagoDesc")
            dtFP.Columns.Add("DescuentoFPID", GetType(Integer))
            dtFP.Columns.Add("DescuentoAdicionalID", GetType(Integer))
            dtFP.Columns.Add("CodFormaPago", GetType(String))
            dtFP.Columns.Add("Descripcion", GetType(String))
            dtFP.AcceptChanges()
            'Filtramos las formas de pago extraidas de SAP por las promos aplicadas
            strPromos = strPromoID.Trim.Split(",")
            dvFPSAP = New DataView(dtFPSAP)
            'obtenemos todas las formas de pago del catalogo local para sacar la descripcion de cada forma de pago
            dtAllFP = oFPMgr.GetAll(Me.ebTipoVenta.Value).Tables(0).Copy
            dvFP = New DataView(dtAllFP)
            For Each strID In strPromos
                If Not strID Is Nothing AndAlso strID.Trim <> "" Then
                    dvFPSAP.RowFilter = "ID = '" & strID.Trim & "'"
                    For Each oRowV In dvFPSAP
                        If dtFP.Rows.Count <= 0 OrElse dtFP.Compute("COUNT(CodFormaPago)", "CodFormaPago = '" & CStr(oRowV!Forma_Pago).Trim & "'") <= 0 Then
                            oNewRow = dtFP.NewRow
                            With oNewRow
                                !DescuentoFPID = 0
                                !DescuentoAdicionalID = oRowV!ID
                                !CodFormaPago = CStr(oRowV!Forma_Pago).Trim
                                dvFP.RowFilter = "CodFormasPago = '" & CStr(oRowV!Forma_Pago).Trim & "'"
                                If dvFP.Count > 0 Then
                                    !Descripcion = dvFP(0)!Descripcion
                                Else
                                    !Descripcion = ""
                                End If
                            End With
                            dtFP.Rows.Add(oNewRow)
                        End If
                    Next
                End If
            Next
            '---------------------------------------------------------------------------------------------------------------------------
            'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
            '---------------------------------------------------------------------------------------------------------------------------
            AgregaFormasPagoDescuento(dtFP, "CS")
        End If

        Return bRes

    End Function

    Private Function TieneDescuento(ByVal detalle As DataTable)
        Dim validar As Boolean = False
        For Each row As DataRow In detalle.Rows
            If row!Descuento > 0 Then
                validar = True
            End If
        Next
        Return validar
    End Function

    Private Function CrearPromociones(ByVal promociones As Hashtable)
        Me.promociones.Clear()
        For Each promocion As String In promociones.Keys
            Dim validar As Boolean = CBool(promociones(promocion))
            If validar = True Then
                AgregarPromocion(Me.promociones, promocion)
            End If
        Next
    End Function

    Private Function AgregarPromocion(ByRef promociones As DataTable, ByVal promocion As String)
        Dim row As DataRow = promociones.NewRow()
        row("Promociones") = promocion
        promociones.Rows.Add(row)
        promociones.AcceptChanges()
    End Function

    Private Sub AplicaPromocionBonificacion(ByRef dtDetalleTemp As DataTable, ByVal PromoID As Integer)

        Dim dtView As DataView
        Dim dtTemp As DataTable = dtDetalleTemp.Copy
        Dim PorcBon As Decimal = 0
        Dim Total As Decimal = 0
        Dim ImporteBon As Decimal = 0
        Dim PorcDesc As Decimal = 0
        Dim oRow As DataRowView
        Dim oNewCol As New DataColumn
        Dim ImporteMasCaro As Decimal

        dtTemp.Columns.Add("ImporteNeto", GetType(Decimal), "Importe - Descuento")
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Ordenamos el detalle de la factura desde el material mas caro al mas barato una vez restado el descuento que trae cada uno por sistema
        '----------------------------------------------------------------------------------------------------------------------------------------
        dtView = New DataView(dtTemp, "NOT(Codigo like 'DT-CAT%') And UsadoPromo = False", "ImporteNeto DESC", DataViewRowState.CurrentRows)

        If dtView.Count > 1 Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el importe del material mas caro ya con iva
            '------------------------------------------------------------------------------------------------------------------------------------
            ImporteMasCaro = Decimal.Round(dtView(0)!ImporteNeto * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
            '--------------------------------------------------------------------------------------------------------------------------------
            'Obtenemos el porcentaje de bonificacion y si es mayor a cero procedemos con la aplicacion del descuento
            '--------------------------------------------------------------------------------------------------------------------------------
            PorcBon = oFacturaMgr.GetDescuentoAdicional("BON")
            If PorcBon > 0 Then
                '----------------------------------------------------------------------------------------------------------------------------
                'Calculamos el importe que se bonificará al total de la factura en base al importe del articulo mas caro que va en esta 
                'factura y al porcentaje de bonificacion de la promocion
                '----------------------------------------------------------------------------------------------------------------------------
                ImporteBon = ImporteMasCaro * PorcBon / 100
                '----------------------------------------------------------------------------------------------------------------------------
                'Obtenemos el importe total de la factura
                '----------------------------------------------------------------------------------------------------------------------------
                Total = GetTotalFacturaParaCupon(dtView)
                '----------------------------------------------------------------------------------------------------------------------------
                'Calculamos el porcentaje que representa el importe a bonificar en el total de la factura
                '----------------------------------------------------------------------------------------------------------------------------
                PorcDesc = Decimal.Round(ImporteBon * 100 / Total, 2)
                '----------------------------------------------------------------------------------------------------------------------------
                'Aplicamos el porcentaje de descuento en todos los productos de la factura
                '----------------------------------------------------------------------------------------------------------------------------
                dtView = New DataView(dtDetalleTemp, "NOT(Codigo like 'DT-CAT%')", "", DataViewRowState.CurrentRows)
                For Each oRow In dtView
                    If CBool(oRow!UsadoPromo) = False Then
                        oRow!Adicional = PorcDesc
                        oRow!Condicion = "ZDP4"
                        oRow!UsadoPromo = True
                        oRow!Checado = True
                    End If
                Next
                '----------------------------------------------------------------------------------------------------------------------------
                'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
                '----------------------------------------------------------------------------------------------------------------------------
                AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "BON")
            End If
        End If

    End Sub

    Private Function AplicaPromocionEspecial(ByRef dtDetalleTemp As DataTable, ByRef oCupon As CuponDescuento) As Boolean

        Dim dtView As New DataView(dtDetalleTemp, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        'Dim dtViewPromo As DataView
        Dim PorcSis As Decimal = 0
        Dim CantPiezas As Integer = 0
        Dim Total As Decimal = 0
        Dim i As Integer = 0
        Dim bolResult As Boolean = True
        Dim strMsg As String = ""
        Dim bNoAplicaEnNinguno As Boolean = False

        If dtView.Count > 0 Then

            'For Each oRow As DataRowView In dtView
            '    PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
            '    If PorcSis <= oCupon.LimiteDescuento Then
            '        dtView(i)!Adicional = oCupon.Descuento
            '        dtView(i)!Condicion = "Z3AN"
            '        dtView(i)!UsadoPromo = True
            '        dtView(i)!Checado = True
            '    End If
            '    i += 1
            'Next
            'dtDetalleTemp.AcceptChanges()
            strMsg = AplicaDescuentoCupon(dtView, oCupon.LimiteDescuento, IIf(oCupon.TipoDescuento.Trim.ToUpper = "I", 0, oCupon.Descuento), bNoAplicaEnNinguno)

            'dtView = New DataView(dtDetalleTemp, "UsadoPromo = True", "", DataViewRowState.CurrentRows)
            dtView.RowFilter = "UsadoPromo = True"

            If dtView.Count > 0 Then
                'Validamos si el cupon aplica segun el minimo y maximo segun el tipo de cupon
                CantPiezas = dtView.Count
                If oCupon.TipoDescuento.Trim.ToUpper = "P" Then
                    If CantPiezas < oCupon.Minimo Then
                        MessageBox.Show("El cupón no aplica porque el detalle no supera el mínimo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf CantPiezas > oCupon.Maximo Then
                        MessageBox.Show("El cupón no aplica porque el detalle supera el máximo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    End If
                    If bolResult = False Then LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                ElseIf oCupon.TipoDescuento.Trim.ToUpper = "I" Then
                    Total = GetTotalFacturaParaCupon(dtView)
                    LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                    dtView.RowFilter = ""
                    If Total < oCupon.Minimo Then
                        MessageBox.Show("El cupón no aplica porque el detalle no supera el monto mínimo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf Total > oCupon.Maximo Then
                        MessageBox.Show("El cupón no aplica porque el detalle supera el monto máximo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    Else
                        AplicaDescuentoCupon(dtView, oCupon.LimiteDescuento, oCupon.Descuento, bNoAplicaEnNinguno, "I", Total)
                    End If
                End If
            End If

            If strMsg.Trim <> "" Then MessageBox.Show(strMsg.Trim, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If bNoAplicaEnNinguno Then oCupon = Nothing

        End If

        Return bolResult

    End Function

    'Private Function AplicaPromocionEspecialMaterial(ByRef dtDetalleTemp As DataTable, ByVal oCupon As CuponDescuento) As Boolean
    '    Dim dtView As New DataView(dtDetalleTemp, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
    '    Dim PorcSis As Decimal = 0
    '    Dim CantPiezas As Integer = 0
    '    Dim Total As Decimal = 0
    '    Dim i As Integer = 0
    '    Dim bolResult As Boolean = True
    '    Dim listaCodigos As String
    '    If dtView.Count > 0 Then
    '        CantPiezas = dtView.Count
    '        listaCodigos = GetCodigosArticulos(dtView, oCupon)
    '        dtView.RowFilter = "NOT (Codigo in (" & listaCodigos & "))"

    '    End If
    'End Function

    'Private Function GetCodigosArticulos(ByVal dtView As DataView, ByVal oCupon As CuponDescuento) As String
    '    Dim codigos As String = ""
    '    Dim rows() As DataRow
    '    Dim copia As DataTable = dtView.Table.Copy()
    '    For Each row As DataRowView In dtView
    '        Dim Talla As String = GetFormatTalla(row!Talla)
    '        Dim count() As DataRow = copia.Select("Codigo='" & CStr(row!Codigo) & "'")
    '        rows = oCupon.MaterialesDetalles.Select("Material='" & CStr(row!Codigo) & "' AND Talla='" & Talla & "'")
    '        If rows.Length > 0 Then
    '            codigos &= "'" & CStr(row!Codigo) & "',"
    '        End If
    '    Next
    '    If codigos.Length > 0 Then
    '        codigos = codigos.Remove(codigos.Length - 1, 1)
    '    Else
    '        codigos = "''"
    '    End If
    '    Return codigos
    'End Function

    Private Function AplicaDescuentoCupon(ByRef dtView As DataView, ByVal LimDesc As Decimal, ByVal Desc As Decimal, ByRef NoAplica As Boolean, Optional ByVal Tipo As String = "", _
                                     Optional ByVal TotalFac As Decimal = 0) As String
        Dim PorcSis As Decimal = 0
        Dim i As Integer = 0
        Dim vDesc As Decimal = 0
        Dim bAplica As Boolean = False
        Dim bNoAplica As Boolean = False
        Dim strMsg As String = ""
        If Tipo.Trim.ToUpper = "I" Then
            vDesc = Decimal.Round((Desc * 100) / TotalFac, 2)
        Else
            vDesc = Desc
        End If
        For Each oRow As DataRowView In dtView
            PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
            If PorcSis <= LimDesc Then
                bAplica = True
                dtView(i)!Adicional = vDesc
                dtView(i)!Condicion = "ZDP4"
                dtView(i)!UsadoPromo = True
                dtView(i)!Checado = True
            Else
                bNoAplica = True
            End If
            i += 1
        Next
        dtView.Table.AcceptChanges()
        If bAplica AndAlso bNoAplica Then
            'Entonces aplico en algunos productos del detalle de la factura el descuento del cupon y en otros no 
            strMsg = "Promoción de cupón aplicada con restricciones para algunos productos."
            NoAplica = False
        ElseIf bNoAplica AndAlso bAplica = False Then
            'Entonces no aplico en ningun producto del detalle de la factura el descuento del cupon
            strMsg = "Verifique las restricciones de la promoción." & vbCrLf & vbCrLf & "El cupón no aplica."
            NoAplica = True
        ElseIf bAplica AndAlso bNoAplica = False Then
            'Entonces aplico en todos los productos del detalle de la factura el descuento del cupon
            strMsg = ""
            NoAplica = False
        End If
        Return strMsg.Trim
    End Function

    '---------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/02/2014: Nuevos cupones con todos los demas descuentos
    '---------------------------------------------------------------------------------------------------------------------

    Private Function AplicaPromocionEspecialCupon(ByRef dtDetalleTemp As DataTable, ByRef oCupon As CuponDescuento, Optional ByVal condicion As String = "ZDP4") As Boolean

        Dim dtView As New DataView(dtDetalleTemp, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        'Dim dtViewPromo As DataView
        Dim PorcSis As Decimal = 0
        Dim CantPiezas As Integer = 0
        Dim Total As Decimal = 0
        Dim i As Integer = 0
        Dim bolResult As Boolean = True
        Dim strMsg As String = ""
        Dim bNoAplicaEnNinguno As Boolean = False

        If dtView.Count > 0 Then

            'For Each oRow As DataRowView In dtView
            '    PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
            '    If PorcSis <= oCupon.LimiteDescuento Then
            '        dtView(i)!Adicional = oCupon.Descuento
            '        dtView(i)!Condicion = "Z3AN"
            '        dtView(i)!UsadoPromo = True
            '        dtView(i)!Checado = True
            '    End If
            '    i += 1
            'Next
            'dtDetalleTemp.AcceptChanges()
            strMsg = AplicaNuevoDescuentoCupon(dtView, oCupon.LimiteDescuento, IIf(oCupon.TipoDescuento.Trim.ToUpper = "I", 0, oCupon.Descuento), bNoAplicaEnNinguno, "", 0, condicion)

            'dtView = New DataView(dtDetalleTemp, "UsadoPromo = True", "", DataViewRowState.CurrentRows)
            dtView.RowFilter = "UsadoPromo = True"

            If dtView.Count > 0 Then
                'Validamos si el cupon aplica segun el minimo y maximo segun el tipo de cupon
                CantPiezas = dtView.Count
                If oCupon.TipoDescuento.Trim.ToUpper = "P" Then
                    If CantPiezas < oCupon.Minimo Then
                        MessageBox.Show("El cupón no aplica porque el detalle no supera el mínimo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf CantPiezas > oCupon.Maximo Then
                        MessageBox.Show("El cupón no aplica porque el detalle supera el máximo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    End If
                    If bolResult = False Then LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                ElseIf oCupon.TipoDescuento.Trim.ToUpper = "I" Then
                    Total = GetTotalFacturaParaCupon(dtView)
                    LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                    dtView.RowFilter = ""
                    If Total < oCupon.Minimo Then
                        MessageBox.Show("El cupón no aplica porque el detalle no supera el monto mínimo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf Total > oCupon.Maximo Then
                        MessageBox.Show("El cupón no aplica porque el detalle supera el monto máximo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    Else
                        AplicaNuevoDescuentoCupon(dtView, oCupon.LimiteDescuento, oCupon.Descuento, bNoAplicaEnNinguno, "I", Total, condicion)
                    End If
                End If
            End If

            If strMsg.Trim <> "" Then MessageBox.Show(strMsg.Trim, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If bNoAplicaEnNinguno Then oCupon = Nothing

        End If

        Return bolResult

    End Function

    Private Function AplicaNuevoDescuentoCupon(ByRef dtView As DataView, ByVal LimDesc As Decimal, ByVal Desc As Decimal, ByRef NoAplica As Boolean, _
                                          Optional ByVal Tipo As String = "", Optional ByVal TotalFac As Decimal = 0, Optional ByVal condicion As String = "ZDP4") As String
        Dim PorcSis As Decimal = 0
        Dim i As Integer = 0
        Dim vDesc As Decimal = 0
        Dim bAplica As Boolean = False
        Dim bNoAplica As Boolean = False
        Dim strMsg As String = ""
        Dim importe As Decimal = 0, importesinadicional As Decimal = 0, importecupon As Decimal = 0
        Dim porcentajeCupon As Decimal = 0

        If Tipo.Trim.ToUpper = "I" Then
            vDesc = Decimal.Round((Desc * 100) / TotalFac, 2)
        Else
            vDesc = Desc
        End If
        For Each oRow As DataRowView In dtView
            PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
            If PorcSis <= LimDesc Then
                'bAplica = True
                'dtView(i)!Adicional = vDesc
                'dtView(i)!Condicion = "Z3AN"
                'dtView(i)!UsadoPromo = True
                'dtView(i)!Checado = True
                bAplica = True
                importe = CDec(oRow!Total) - CDec(oRow!Descuento)
                'FLIZARRAGA 26/02/2014: Se obtiene el descuento proporcional en caso de que haya adicionales aplicados con anterioridad
                If CDec(oRow!Adicional) <> 0 Then
                    importesinadicional = importe - (importe * (CDec(oRow!Adicional) / 100))
                    importecupon = importesinadicional - (importesinadicional * (vDesc / 100))
                    porcentajeCupon = ((importe - importecupon) / importe) * 100
                    oRow!Adicional = porcentajeCupon
                    oRow!Condicion = "ZDP4"
                    oRow!UsadoPromo = True
                    oRow!Checado = True
                Else
                    'FLIZARRAGA 26/02/2014: En caso de no contar con adicionales se le aplica el porcentaje directo
                    oRow!Adicional = vDesc
                    oRow!Condicion = "ZDP4"
                    oRow!UsadoPromo = True
                    oRow!Checado = True
                End If
            Else
                bNoAplica = True
            End If
            i += 1
        Next
        dtView.Table.AcceptChanges()

        If bAplica AndAlso bNoAplica Then
            'Entonces aplico en algunos productos del detalle de la factura el descuento del cupon y en otros no 
            strMsg = "Promoción de cupón aplicada con restricciones para algunos productos."
            NoAplica = False
        ElseIf bNoAplica AndAlso bAplica = False Then
            'Entonces no aplico en ningun producto del detalle de la factura el descuento del cupon
            strMsg = "Verifique las restricciones de la promoción." & vbCrLf & vbCrLf & "El cupón no aplica."
            NoAplica = True
        ElseIf bAplica AndAlso bNoAplica = False Then
            'Entonces aplico en todos los productos del detalle de la factura el descuento del cupon
            strMsg = ""
            NoAplica = False
        End If

        Return strMsg.Trim

    End Function

    Private Function AplicaDescuentosCuponMaterial(ByRef dtView As DataView, ByVal materiales As DataTable, ByVal LimDesc As Decimal, ByVal Desc As Decimal, ByRef NoAplica As Boolean, Optional ByVal Tipo As String = "", _
                                                   Optional ByVal TotalFac As Decimal = 0) As String
        Dim PorcSis As Decimal = 0
        Dim i As Integer = 0
        Dim vDesc As Decimal = 0
        Dim bAplica As Boolean = False
        Dim bNoAplica As Boolean = False
        Dim strMsg As String = ""
        Dim cont As Integer = 0

        If Tipo.Trim.ToUpper = "I" Then
            vDesc = Decimal.Round((Desc * 100) / TotalFac, 2)
        Else
            vDesc = Desc
        End If
        For Each row As DataRow In materiales.Rows
            cont = 0
            Dim cant As Integer = CInt(row!Cantidad)
            Dim talla As String = RemoveFormatTalla(CStr(row!Talla))
            Dim rows() As DataRow = dtView.Table.Select("Codigo='" & row!Material & "' AND Talla='" & talla & "'")
            For Each renglon As DataRow In rows
                If (cont < cant) Then
                    PorcSis = Decimal.Round(renglon!Descuento * 100 / renglon!Total, 2)
                    If PorcSis <= LimDesc Then
                        bAplica = True
                        renglon!Adicional = vDesc
                        renglon!Condicion = "ZDP4"
                        renglon!UsadoPromo = True
                        renglon!Checado = True
                        cont += 1
                    Else
                        bNoAplica = True
                    End If
                End If
            Next
        Next
        dtView.Table.AcceptChanges()
        If bAplica AndAlso bNoAplica Then
            'Entonces aplico en algunos productos del detalle de la factura el descuento del cupon y en otros no 
            strMsg = "Promoción de cupón aplicada con restricciones para algunos productos."
            NoAplica = False
        ElseIf bNoAplica AndAlso bAplica = False Then
            'Entonces no aplico en ningun producto del detalle de la factura el descuento del cupon
            strMsg = "Verifique las restricciones de la promoción." & vbCrLf & vbCrLf & "El cupón no aplica."
            NoAplica = True
        ElseIf bAplica AndAlso bNoAplica = False Then
            'Entonces aplico en todos los productos del detalle de la factura el descuento del cupon
            strMsg = ""
            NoAplica = False
        End If
        Return strMsg.Trim
    End Function


    Private Function GetTotalFacturaParaCupon(ByVal dtView As DataView) As Decimal

        Dim oRow As DataRowView
        Dim vSubTotal As Decimal = 0
        Dim vDscto As Decimal = 0   'Descuento por sistema
        Dim vDsctoAdicional As Decimal = 0  'Descuento Adicional
        Dim vIVA As Decimal = 0
        Dim vDescTotal As Decimal = 0
        Dim vTotal As Decimal = 0

        For Each oRow In dtView
            vDscto = vDscto + oRow("Descuento")
            If oRow("Descuento") > 0 Then
                vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
            Else
                vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
            End If
            vSubTotal = vSubTotal + oRow("Total")
        Next
        vDescTotal = vDscto + vDsctoAdicional

        vSubTotal = vSubTotal - vDescTotal

        vIVA = vSubTotal * oAppContext.ApplicationConfiguration.IVA
        vTotal = Decimal.Round(vSubTotal + vIVA, 2)

        Return vTotal

    End Function

    Private Function AplicaDescuentoSobreDescuento(ByRef dtDetalleTemp As DataTable, ByVal bAcepta As Boolean) As Boolean

        Dim i As Integer = 0
        Dim DescGen As Decimal = 0
        Dim DescMarca As Decimal = 0
        Dim CodMarca As String = ""
        Dim aplica As Boolean = False
        Dim PromoID As Integer = 0
        Dim bAplicaG As Boolean = True, bAplicaM As Boolean = True, bAplicaC As Boolean = True
        Dim PromoIDs As String = ""
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Validamos si alguna de estas promociones esta condicionada por formas de pago especificas y si el cliente las aceptó para aplicarlas
        '----------------------------------------------------------------------------------------------------------------------------------------
        If IsPromoCondicionadaFP("DSDG") AndAlso bAcepta = False Then bAplicaG = False
        If IsPromoCondicionadaFP("DSDM") AndAlso bAcepta = False Then bAplicaM = False
        If IsPromoCondicionadaFP("DSDC") AndAlso bAcepta = False Then bAplicaC = False
        If bAplicaG OrElse bAplicaM OrElse bAplicaC Then
            For Each oRowTemp As DataRow In dtDetalleTemp.Rows
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional General si está vigente
                '---------------------------------------------------------------------------------------
                DescGen = 0
                If oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "DA", PromoID) AndAlso oRowTemp!UsadoPromo = False AndAlso oRowTemp!Codigo <> "" AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" AndAlso bAplicaG Then
                    DescGen = oFacturaMgr.GetDescuentoAdicionalPorMarca("@@")
                    oRowTemp!Adicional = DescGen
                    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                    oRowTemp!Condicion = "ZDP4"
                    oRowTemp!UsadoPromo = True
                    aplica = True
                    If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                        PromoIDs &= PromoID.ToString & ","
                        '---------------------------------------------------------------------------------------------------------------------------
                        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
                        '---------------------------------------------------------------------------------------------------------------------------
                        AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDG")
                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional Por Marca si está vigente
                '---------------------------------------------------------------------------------------
                DescMarca = 0
                If DescGen = 0 AndAlso oRowTemp!UsadoPromo = False AndAlso oRowTemp!Codigo <> "" AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" AndAlso bAplicaM Then
                    CodMarca = CStr(oRowTemp!Codigo).Substring(0, 2)
                    If oFacturaMgr.IsTipoVentaPermitida(CodMarca, oFactura.CodTipoVenta, "DA", PromoID) Then
                        DescMarca = oFacturaMgr.GetDescuentoAdicionalPorMarca(CodMarca)
                        oRowTemp!Adicional = DescMarca
                        'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                        oRowTemp!Condicion = "ZDP4"
                        oRowTemp!UsadoPromo = True
                        aplica = True
                        If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                            PromoIDs &= PromoID.ToString & ","
                            '-----------------------------------------------------------------------------------------------------------------------
                            'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
                            '-----------------------------------------------------------------------------------------------------------------------
                            AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDM")
                        End If
                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional por Codigo si esta vigente
                '---------------------------------------------------------------------------------------
                If oFacturaMgr.IsTipoVentaPermitida(oRowTemp!Codigo, oFactura.CodTipoVenta, "DA", PromoID) AndAlso DescGen = 0 AndAlso DescMarca = 0 AndAlso oRowTemp!UsadoPromo = False AndAlso oRowTemp!Codigo <> "" AndAlso Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" AndAlso bAplicaC Then
                    oRowTemp!Adicional = oFacturaMgr.GetDescuentoAdicional(oRowTemp!Codigo)
                    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                    oRowTemp!Condicion = "ZDP4"
                    oRowTemp!UsadoPromo = True
                    aplica = True
                    If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                        PromoIDs &= PromoID.ToString & ","
                        '---------------------------------------------------------------------------------------------------------------------------
                        'Si aplicó la promoción agregamos las formas de pago para las cuales está permitida
                        '---------------------------------------------------------------------------------------------------------------------------
                        AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDC")
                    End If
                End If
                i += 1

            Next
        End If
        Return aplica
    End Function

    Private Sub AplicaDescuentoEmpleado(ByRef dtTemp As DataTable, ByVal Porc As Decimal)

        Dim impMayor As Decimal = 0
        Dim idxMay As Integer = 0
        Dim i As Integer = 0
        Dim dtView As DataView
        Dim NumMax As Integer = 0
        Dim PorcSis As Decimal = 0
        Dim Vuelta As Boolean = False
        Dim Limite As Integer = 0

        dtView = New DataView(dtTemp, "Descuento*100/Total < " & Porc, "Importe DESC", DataViewRowState.CurrentRows)
        'Verificamos que realmente sean solo codigos con descuento menor al porcentaje del vale de empleado
        '(puede que se haya escapado alguno por el redondeo)
        For Each oRowV As DataRowView In dtView
            If Decimal.Round(oRowV!Descuento * 100 / oRowV!Total, 2) >= Porc Then
                Limite += 1
            End If
        Next
        Limite = IIf(dtView.Count > 3, 3, dtView.Count) - Limite

        Do While NumMax < Limite

            If Vuelta Then
                'i = 0
                'Do While NumMax < Limite
                PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
                If PorcSis < Porc AndAlso dtView(i)!Adicional = 0 Then
                    dtView(i)!Adicional = Porc - PorcSis
                    'TODO:Ray cambiarlo por ZRVD cuando se creen las demas condiciones de descuento"
                    dtView(i)!Condicion = "ZDP4"
                    NumMax += 1
                End If
                'i += 1
                'Loop
            Else
                If dtView(i)!Descuento = 0 Then
                    dtView(i)!Adicional = Porc
                    'TODO:Ray cambiarlo por ZRVD cuando se creen las demas condiciones de descuento"
                    dtView(i)!Condicion = "ZDP4"
                    NumMax += 1
                End If
            End If
            If i = dtView.Count - 1 Then
                Vuelta = True
                i = 0
            Else
                i += 1
            End If

        Loop

        'If dtView.Count > 3 Then
        '    For i = 1 To 3
        '        PorcSis = Decimal.Round(dtView(i)!Descuento * 100 / dtView(i)!Total, 2)
        '        If PorcSis < Porc Then
        '            dtView(i)!Adicional = Porc - PorcSis
        '        End If
        '    Next
        'Else
        '    For Each oRowV As DataRowView In dtView
        '        PorcSis = Decimal.Round(oRowV!Descuento * 100 / oRowV!Total, 2)
        '        If PorcSis < Porc Then
        '            oRowV!Adicional = Porc - PorcSis
        '        End If
        '    Next
        'End If

        dtTemp.AcceptChanges()

    End Sub

    Private Sub AplicaNuevoDescuentoEmpleado(ByRef dtTemp As DataTable, ByVal Porc As Decimal)

        Dim impMayor As Decimal = 0
        Dim idxMay As Integer = 0
        Dim i As Integer = 0
        Dim dtView As DataView
        Dim NumMax As Integer = 0
        Dim PorcSis As Decimal = 0
        Dim Vuelta As Boolean = False
        Dim Limite As Integer = 0
        Dim importe As Decimal = 0, importesinadicional As Decimal = 0, importeempleado As Decimal = 0
        Dim porcentajeEmpleado As Decimal = 0

        dtView = New DataView(dtTemp, "", "Importe DESC", DataViewRowState.CurrentRows)
        '-------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 07/11/2013: Se valida si la cantidad de articulos es mayor a limite de articulos permitidos si es asi se pone
        '                       el limite, en caso contrario la cantidad de articulos que haya
        '-------------------------------------------------------------------------------------------------------------------------
        Limite = IIf(dtView.Count > oConfigCierreFI.LimiteArticulosEmpleados, oConfigCierreFI.LimiteArticulosEmpleados, dtView.Count)
        For Each row As DataRowView In dtView
            If NumMax < Limite Then
                importe = CDec(row!Total) - CDec(row!Descuento)
                'FLIZARRAGA 07/11/2013: Se obtiene el descuento proporcional en caso de que haya adicionales aplicados con anterioridad
                If CDec(row!Adicional) <> 0 Then
                    importesinadicional = importe - (importe * (CDec(row!Adicional) / 100))
                    importeempleado = importesinadicional - (importesinadicional * (Porc / 100))
                    porcentajeEmpleado = ((importe - importeempleado) / importe) * 100
                    row!Adicional = porcentajeEmpleado
                    row!Condicion = "ZDP4"
                    NumMax += 1
                Else
                    'FLIZARRAGA 07/11/2013: En caso de no contar con adicionales se le aplica el porcentaje directo
                    row!Adicional = Porc
                    row!Condicion = "ZDP4"
                    NumMax += 1
                End If
            Else
                Exit For
            End If
        Next

        dtTemp.AcceptChanges()

    End Sub

    Private Sub grdDetalle_BeforeRowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles grdDetalle.BeforeRowColChange
        If vApartadoInstance Then
            If e.NewRange.r1 >= 0 Then

                If e.NewRange.r1 <> e.OldRange.r1 Then

                    If grdDetalle(e.NewRange.r1, 0) <> "" Then

                        ActualizaDatosArticulo(e.NewRange.r1, 0)

                    End If

                End If

            End If

            Exit Sub

        End If

        Dim vstD As Decimal, vDescuentoAnterior As Decimal
        Dim vSubTotalAnterior As Decimal = 0
        Dim vSubTotalActual As Decimal = 0
        Dim CodeRow As Integer = 0

        If isFormLoad = True Then

            'Dim CodMarca As String
            'Dim TipoVenta As Boolean

            'If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "I" Then
            '    TipoVenta = True
            'Else
            '    TipoVenta = False
            'End If

            'TODO: Ray checar este IF ahora el unico descuento manual aceptado es en los catalogos
            If Me.boolDescuentoSocioEspecial OrElse Me.boolDescuentoDipsEspecial Then Me.grdDetalle.Cols(0).AllowEditing = False

            If e.OldRange.r1 <> e.NewRange.r1 Then  'Si cambiamos de Fila

                If vRowDelete Then

                    ActualizaCalculos()

                    If grdDetalle(e.NewRange.r1, 0) <> "" Then

                        ActualizaDatosArticulo(e.NewRange.r1, 0)

                    End If

                    vRowDelete = False

                Else

                    If ValidateRowGrid(e.OldRange.r1) Then

                        Select Case e.OldRange.c1

                            Case 1      'Talla

                                If Not IsNumeric(grdDetalle(e.OldRange.r1, 1)) Then
                                    grdDetalle(e.OldRange.r1, 1) = UCase(grdDetalle(e.OldRange.r1, 1))
                                End If

                                'If grdDetalle(e.OldRange.r1, 0) <> "" Then
                                '    CodMarca = CStr(grdDetalle(e.OldRange.r1, 0)).Substring(0, 2).ToUpper.Trim()
                                'End If

                                'Verificamos si el Articulo ya esta en la venta
                                If dsDetalle.Tables(0).Rows.Count > 1 Then

                                    CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                                    If CodeRow > 0 Then

                                        MsgBox("El Código / Talla ya fue registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                                        e.Cancel = True

                                        grdDetalle.Select(e.OldRange.r1, 1)

                                        grdDetalle.Focus()

                                        Exit Sub

                                    End If

                                End If

                                If FindTalla(grdDetalle(e.OldRange.r1, 1)) = False Then

                                    MsgBox("Talla no corresponde al Artículo. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Facturación")

                                    e.Cancel = True

                                    grdDetalle.Select(e.OldRange.r1, 1)

                                    grdDetalle.Focus()

                                    Exit Sub

                                End If

                            Case 2      'Cantidad

                                If grdDetalle(e.OldRange.r1, 2) > ebExistencias.Value Then

                                    MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Factura")

                                    e.Cancel = True

                                    grdDetalle.Focus()

                                    Exit Sub

                                Else

                                    grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)

                                    grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * Me.ebPorcentajeDscto.Value, 2)

                                    ActualizaCalculos()

                                End If

                            Case 5      'Descuento

                                'If ((grdDetalle(e.OldRange.r1, 5) / 100) > oAppContext.ApplicationConfiguration.Descuento And oFactura.CodTipoVenta <> "A") Or grdDetalle(e.OldRange.r1, 5) < 0 Then

                                '    grdDetalle(e.OldRange.r1, 5) = vDescuento

                                '    e.Cancel = True

                                '    grdDetalle.Select(e.OldRange)

                                '    Exit Sub

                                'Else

                                '    ActualizaCalculos()

                                'End If

                            Case 6      'Descuento Adicional

                                'Para que nos deje salir por que hay condiciones de venta con
                                'descuentos muy altos y sobre pasa el descuento del archivo
                                'de configuracion.
                                If grdDetalle(e.OldRange.r1, 6) <= 0 Then
                                    grdDetalle(e.OldRange.r1, 6) = 0
                                    ActualizaCalculos()
                                    'Exit Sub
                                    Exit Select
                                End If

                                If ((grdDetalle(e.OldRange.r1, 6) + (ebPorcentajeDscto.Value * 100)) > (oAppContext.ApplicationConfiguration.Descuento * 100)) Or (grdDetalle(e.OldRange.r1, 6) < 0) Then

                                    grdDetalle(e.OldRange.r1, 6) = 0

                                    e.Cancel = True

                                    grdDetalle.Select(e.OldRange)

                                End If

                                ActualizaCalculos()


                        End Select

                        If grdDetalle(e.NewRange.r1, 0) <> "" Then

                            ActualizaDatosArticulo(e.NewRange.r1, 0)

                        End If

                    Else

                        e.Cancel = True

                        grdDetalle.Select(e.OldRange.r1, e.OldRange.c1)

                        grdDetalle.Focus()

                    End If

                End If

            Else    'En la misma fila, diferente columna

                'If grdDetalle(e.OldRange.r1, 0) <> "" Then
                '    CodMarca = CStr(grdDetalle(e.OldRange.r1, 0)).Substring(0, 2).ToUpper.Trim()
                'End If

                Select Case e.OldRange.c1

                    Case 0  'Columna CODIGO

                        If grdDetalle(e.OldRange.r1, 0) = "" Then

                            MsgBox("Ingrese Código de Artículo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            e.Cancel = True

                            LimpiaDatosGrid(e.OldRange.r1)

                            ActualizaCalculos()

                            grdDetalle.Select(e.OldRange.r2, 0)

                            grdDetalle.Focus()

                        Else

                            oArticulo.ClearFields()

                            vNumeroArticulo = 0

                            If IsNumeric(grdDetalle(e.OldRange.r1, 0)) Then

                                'Es un CodigoUPC
                                Dim dsUPC As New DataTable
                                Dim oCatalogoUPCMgr As CatalogoUPCManager
                                oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
                                'On Error Resume Next

                                dsUPC = oCatalogoUPCMgr.Load2(grdDetalle(e.OldRange.r1, 0))

                                dsUPC = oFacturaMgr.GetUPCData(grdDetalle(e.OldRange.r1, 0))

                                If dsUPC.Rows.Count > 0 Then

                                    'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                    If Mid(UCase(dsUPC.Rows(0).Item("CodArticulo")), 1, 6) = "DT-CAT" And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                                        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                            MsgBox("¡Dá de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                        Else
                                            MsgBox("¡Dá de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                        End If

                                        e.Cancel = True
                                        grdDetalle(grdDetalle.Row, 0) = ""
                                        grdDetalle.Select(grdDetalle.Row, 0)
                                        Exit Sub
                                    End If

                                    '''''''''''''


                                    grdDetalle(e.OldRange.r1, 0) = UCase(dsUPC.Rows(0).Item("CodArticulo"))
                                    vNumeroArticulo = dsUPC.Rows(0).Item("Numero")

                                    grdDetalle(e.OldRange.r1, 1) = vNumeroArticulo
                                    '</Captura con lector>
                                    CodeRow = BuscaCodigoEnVenta(grdDetalle(e.OldRange.r1, 0), vNumeroArticulo, e.OldRange.r1)
                                    If CodeRow = 0 Then
                                        ActualizaDatosArticulo(e.OldRange.r1, 0)
                                        If 1 > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                            e.Cancel = True
                                            LimpiaDatosGrid(e.OldRange.r1)
                                            ActualizaCalculos()
                                            grdDetalle.Focus()
                                        Else
                                            grdDetalle(e.OldRange.r1, 2) = 1
                                            grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                                            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)

                                            '**************Prueba************************
                                            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)
                                            '/*********************
                                            '--Aplicamos Descuento si lo tuviera
                                            If ebPorcentajeDscto.Value > 0 Then
                                                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * ebPorcentajeDscto.Value, 2)
                                            Else
                                                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 2) * ebMontoDscto.Value, 2)
                                            End If

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '/*********************
                                            ActualizaCalculos()
                                            '**************Prueba************************
                                            SendKeys.Send("{UP}")
                                            SendKeys.Send("{INSERT}")
                                        End If
                                    Else
                                        ActualizaDatosArticulo(CodeRow - 1, 0)
                                        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                            grdDetalle.Focus()
                                        Else
                                            grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)

                                            '**************Prueba************************
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                            '--Aplicamos Descuento si lo tuviera
                                            If ebPorcentajeDscto.Value > 0 Then
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 4) * ebPorcentajeDscto.Value, 2)
                                            Else
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 2) * ebMontoDscto.Value, 2)
                                            End If

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '**************Prueba************************
                                        End If
                                        LimpiaDatosGrid(e.OldRange.r1)
                                        ActualizaCalculos()
                                        e.Cancel = True
                                    End If
                                    Exit Sub
                                    '<END/>
                                Else

                                    dsUPC = Nothing
                                    MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                    e.Cancel = True
                                    LimpiaDatosGrid(e.OldRange.r1)
                                    ActualizaCalculos()
                                    grdDetalle.Focus()
                                    Exit Sub

                                End If

                                dsUPC = Nothing

                            Else        '--NO ES UN CODIGO UPC

                                vCodArticulo = UCase(grdDetalle(e.OldRange.r1, 0))
                                vNumStringArticulo = Mid(vCodArticulo, 1, 2)

                                'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                If Mid(UCase(vCodArticulo), 1, 6) = "DT-CAT" And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                                    If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                        MsgBox("¡Dá de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                    Else
                                        MsgBox("¡Dá de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                    End If

                                    e.Cancel = True
                                    grdDetalle(grdDetalle.Row, 0) = ""
                                    grdDetalle.Select(grdDetalle.Row, 0)
                                    Exit Sub
                                End If

                                '''''''''''''

                                If IsNumeric(vNumStringArticulo) Then

                                    '</Captura con Lector>
                                    vCodArticulo = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                                    vNumeroArticulo = CDec(vNumStringArticulo) / 2

                                    '--Obtenemos el Codigo Nuevo
                                    oArticulo.ClearFields()
                                    oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                                    If oArticulo.CodArticulo <> String.Empty Then
                                        vCodArticulo = oArticulo.CodArticulo
                                    Else
                                        oArticulo.ClearFields()
                                        oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                                        If oArticulo.CodArticulo <> String.Empty Then
                                            vCodArticulo = oArticulo.CodArticulo
                                        End If
                                    End If

                                    'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                    If Mid(UCase(vCodArticulo), 1, 6) = "DT-CAT" And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                                        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                            MsgBox("¡Dá de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                        Else
                                            MsgBox("¡Dá de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                        End If

                                        e.Cancel = True
                                        grdDetalle(grdDetalle.Row, 0) = ""
                                        grdDetalle.Select(grdDetalle.Row, 0)
                                        Exit Sub
                                    End If

                                    '''''''''''''


                                    'Se cambia la talla del material si es accesorio o textil
                                    If oArticulo.CodCorrida = "ACC" OrElse oArticulo.CodCorrida = "TEX" OrElse oArticulo.CodCorrida = "AC1" Then

                                        Select Case vNumeroArticulo
                                            Case "10"
                                                vNumeroArticulo = "XXL"
                                            Case "8"
                                                vNumeroArticulo = "XL"
                                            Case "6"
                                                vNumeroArticulo = "L"
                                            Case "4"
                                                vNumeroArticulo = "M"
                                            Case "2"
                                                vNumeroArticulo = "S"
                                            Case "1"
                                                vNumeroArticulo = "XS"
                                            Case "0"
                                                vNumeroArticulo = "U"
                                            Case Else
                                                vNumeroArticulo = vNumeroArticulo
                                        End Select


                                    End If

                                    'CodeRow = BuscaCodigoEnVenta(UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2)), vNumeroArticulo, e.OldRange.r1)
                                    CodeRow = BuscaCodigoEnVenta(vCodArticulo, vNumeroArticulo, e.OldRange.r1)

                                    If CodeRow = 0 Then
                                        'grdDetalle(e.OldRange.r1, 0) = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                                        grdDetalle(e.OldRange.r1, 0) = vCodArticulo
                                        grdDetalle(e.OldRange.r1, 1) = vNumeroArticulo
                                        ActualizaDatosArticulo(e.OldRange.r1, 0)
                                        If 1 > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                            e.Cancel = True
                                            LimpiaDatosGrid(e.OldRange.r1)
                                            grdDetalle.Focus()
                                        Else
                                            grdDetalle(e.OldRange.r1, 2) = 1
                                            grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                                            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)

                                            '**************Prueba2************************
                                            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)
                                            '/*********************
                                            '--Aplicamos Descuento si lo tuviera
                                            If ebPorcentajeDscto.Value > 0 Then
                                                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * ebPorcentajeDscto.Value, 2)
                                            Else
                                                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 2) * ebMontoDscto.Value, 2)
                                            End If

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '/*********************
                                            ActualizaCalculos()
                                            '**************Prueba2************************
                                            SendKeys.Send("{UP}")
                                            SendKeys.Send("{INSERT}")
                                        End If
                                    Else
                                        ActualizaDatosArticulo(CodeRow - 1, 0)
                                        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                            grdDetalle.Focus()
                                        Else
                                            grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)

                                            '**************Prueba2************************
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                            '--Aplicamos Descuento si lo tuviera
                                            If ebPorcentajeDscto.Value > 0 Then
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 4) * ebPorcentajeDscto.Value, 2)
                                            Else
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 2) * ebMontoDscto.Value, 2)
                                            End If

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '**************Prueba2************************
                                        End If
                                        LimpiaDatosGrid(e.OldRange.r1)
                                        ActualizaCalculos()
                                        e.Cancel = True
                                    End If

                                    Exit Sub
                                    '<END/>

                                End If

                            End If

                            'grdDetalle(e.OldRange.r1, e.OldRange.c1) = UCase(grdDetalle(e.OldRange.r1, e.OldRange.c1))
                            'oArticuloMgr.LoadInto(grdDetalle(e.OldRange.r1, e.OldRange.c1), oArticulo)

                            oArticulo.ClearFields()
                            oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                            If oArticulo.CodArticulo = String.Empty Then
                                grdDetalle(e.OldRange.r1, e.OldRange.c1) = vCodArticulo
                                oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                            Else
                                grdDetalle(e.OldRange.r1, e.OldRange.c1) = oArticulo.CodArticulo
                            End If

                            If Not oArticulo.Exist Then

                                MsgBox("Código de Artículo No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                                LimpiaDatosGrid(e.OldRange.r1)

                                ActualizaCalculos()

                                e.Cancel = True

                                grdDetalle.Select(e.OldRange)

                                grdDetalle.Focus()

                            Else

                                ActualizaDatosArticulo(e.OldRange.r1, 0)

                                If grdDetalle(e.OldRange.r1, 0) <> vCodigo Then

                                    grdDetalle(e.OldRange.r1, 1) = vNumeroArticulo
                                    grdDetalle(e.OldRange.r1, 2) = 0
                                    grdDetalle(e.OldRange.r1, 3) = 0
                                    grdDetalle(e.OldRange.r1, 4) = 0
                                    grdDetalle(e.OldRange.r1, 5) = 0

                                    oFactura.FacturaArticuloExistencia = 0

                                End If

                                '--Ponemos el Precio en el Grid / por SAP se usara PrecioNormal
                                '--grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioOferta, 2)
                                grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)

                                '-- Cargamos Descuento Sistema / por SAP el descuento se carga desde Condiciones de Venta
                                '-- oArticulo.Descuento = oArticulo.Descuento / 100
                                'If oFactura.CodTipoVenta = "S" Then
                                '    'ebPorcentajeDscto.Value = 25 / 100
                                'Else
                                '    oCondicionVenta = CargaCondicionVenta(oArticulo)
                                '    If oCondicionVenta.DescPorcentaje > 0 Then
                                '        ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
                                '    ElseIf oCondicionVenta.Descmonto > 0 Then
                                '        ebMontoDscto.Value = oCondicionVenta.Descmonto
                                '    Else
                                '        ebPorcentajeDscto.Value = 0
                                '        ebMontoDscto.Value = 0
                                '    End If
                                'End If


                                'Obtenemos Numero Inicio y Numero Fin del Artículo
                                oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

                                'Obtenemos Tallas de la Corrida del Artículo
                                FillTallasArticulo(oArticulo.CodCorrida)

                            End If

                        End If

                    Case 1  'Columna TALLA

                        If Not IsNumeric(grdDetalle(e.OldRange.r1, 1)) Then
                            grdDetalle(e.OldRange.r1, 1) = UCase(grdDetalle(e.OldRange.r1, 1))
                        End If

                        If grdDetalle(e.OldRange.r1, 0) <> "" Then

                            If grdDetalle(e.OldRange.r1, 1) <> String.Empty Then

                                'Verificamos si el Articulo ya esta en la venta
                                If dsDetalle.Tables(0).Rows.Count > 1 Then

                                    CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                                    '<Sumar al mismo código>

                                    If CodeRow > 0 Then 'AndAlso (TipoVenta = False OrElse (oFacturaMgr.IsPromoDosPorUnoYMedioVigente("XX") = False AndAlso oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CodMarca) = False)) Then
                                        ActualizaDatosArticulo(CodeRow - 1, 0)
                                        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                                            grdDetalle.Focus()
                                        Else
                                            grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                            '**************Prueba************************
                                            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                            '--Aplicamos Descuento si lo tuviera
                                            If ebPorcentajeDscto.Value > 0 Then
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 4) * ebPorcentajeDscto.Value, 2)
                                            Else
                                                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 2) * ebMontoDscto.Value, 2)
                                            End If

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '**************Prueba************************
                                        End If
                                        LimpiaDatosGrid(e.OldRange.r1)
                                        grdDetalle.Select(e.OldRange.r1, 0)
                                        ActualizaCalculos()
                                        Exit Sub
                                    End If
                                    '</Sumar al mismo código>

                                End If

                                If FindTalla(grdDetalle(e.OldRange.r1, 1)) = False Then

                                    MsgBox("Talla no corresponde al Artículo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                                    e.Cancel = True

                                    grdDetalle.Select(e.OldRange.r1, 1)

                                    grdDetalle.Focus()

                                Else

                                    'Obtenemos Existencia
                                    oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura)

                                    If oFactura.FacturaArticuloExistencia = 0 Then

                                        MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                                        e.Cancel = True

                                        grdDetalle.Select(e.OldRange.r1, 1)

                                        grdDetalle.Focus()


                                        'ElseIf oFactura.FacturaArticuloExistencia = SumaCantidad(oArticulo.CodArticulo, grdDetalle(e.OldRange.r1, e.OldRange.c1)) Then

                                        '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Facturación")

                                        '    e.Cancel = True

                                        '    grdDetalle.Select(e.OldRange.r1, 1)

                                        '    grdDetalle.Focus()

                                    Else
                                        'MOTIVOs Captura Manual
                                        'Validar que este en modo de captura manual
                                        If boolManual Then
                                            Dim oForm As New frmMotivosFactura
                                            oForm.Motivos = oFactura.dtMotivos

                                            oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                                            oForm.Articulo = grdDetalle(e.OldRange.r1, 0)
                                            oForm.Talla = grdDetalle(e.OldRange.r1, 1)

                                            oForm.ShowDialog()
                                        End If


                                    End If

                                End If

                            End If

                        Else

                            e.Cancel = True

                            'If oArticulo.CodCorrida <> "ACC" And oArticulo.CodCorrida <> "TEX" Then

                            '    MsgBox("Talla no corresponde al Artículo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            '    e.Cancel = True

                            '    grdDetalle.Select(e.OldRange)

                            '    grdDetalle.Focus()

                            'Else

                            '    'Verificamos si el Articulo ya esta en la venta
                            '    If dsDetalle.Tables(0).Rows.Count > 1 Then

                            '        CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                            '        '<Sumar al mismo código>
                            '        If CodeRow > 0 Then
                            '            ActualizaDatosArticulo(CodeRow - 1, 0)
                            '            If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                            '                MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                            '                grdDetalle.Focus()
                            '            Else
                            '                grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                            '                grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                            '            End If
                            '            LimpiaDatosGrid(e.OldRange.r1)
                            '            grdDetalle.Select(e.OldRange.r1, 0)
                            '            ActualizaCalculos()
                            '            Exit Sub
                            '        End If
                            '        '</Sumar al mismo código>

                            '    End If

                            '    'Obtenemos Existencia
                            '    oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura)

                            '    If oFactura.FacturaArticuloExistencia = 0 Then

                            '        MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            '        e.Cancel = True

                            '        grdDetalle.Select(e.OldRange)

                            '        grdDetalle.Focus()

                            '    End If

                            'End If

                        End If

                    Case 2  'Columna CANTIDAD

                        If grdDetalle(e.OldRange.r1, 2) <= 0 And oFactura.FacturaArticuloExistencia > 0 Then

                            MsgBox("Cantidad debe ser mayor a Cero. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            e.Cancel = True

                            grdDetalle.Select(e.OldRange)

                            grdDetalle.Focus()

                            'ElseIf grdDetalle(e.OldRange.r1, 2) > 1 AndAlso TipoVenta = True AndAlso (oFacturaMgr.IsPromoDosPorUnoYMedioVigente("XX") OrElse oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CodMarca)) Then

                            '    MessageBox.Show("La cantidad no debe ser mayor a uno mientras esté vigente la promoción 2 x 1 ½", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            '    e.Cancel = True

                            '    grdDetalle.Select(e.OldRange)

                            '    grdDetalle.Focus()

                        Else

                            If grdDetalle(e.OldRange.r1, 2) > oFactura.FacturaArticuloExistencia Then

                                MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                                e.Cancel = True

                                grdDetalle.Select(e.OldRange)

                                grdDetalle.Focus()

                            Else

                                grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)

                                '/*********************
                                '--Aplicamos Descuento si lo tuviera
                                If ebPorcentajeDscto.Value > 0 Then
                                    grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * ebPorcentajeDscto.Value, 2)
                                Else
                                    grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 2) * ebMontoDscto.Value, 2)
                                End If
                                '**************Aplicamos Descuentos Adicionales Segun Las Promociones Vigentes
                                'AplicaDescuentosAutomaticos()
                                '/**********************************************************

                                ActualizaCalculos()

                            End If

                        End If


                    Case 5  'Columna DESCUENTO

                        'If ((grdDetalle(e.OldRange.r1, 5) / 100) > oAppContext.ApplicationConfiguration.Descuento And oFactura.CodTipoVenta <> "A") Or grdDetalle(e.OldRange.r1, 5) < 0 Then

                        '    grdDetalle(e.OldRange.r1, 5) = vDescuento

                        '    e.Cancel = True

                        '    grdDetalle.Select(e.OldRange)

                        'Else

                        '    ActualizaCalculos()

                        'End If

                    Case 6  'Columna DESCUENTO ADICIONAL

                        'If (((grdDetalle(e.OldRange.r1, 5) + grdDetalle(e.OldRange.r1, 6)) / 100) > oAppContext.ApplicationConfiguration.Descuento And oFactura.CodTipoVenta <> "A") Or grdDetalle(e.OldRange.r1, 6) < 0 Then

                        '    grdDetalle(e.OldRange.r1, 6) = 0

                        '    e.Cancel = True

                        '    grdDetalle.Select(e.OldRange)

                        'Else

                        'Para que nos deje salir por que hay condiciones de venta con
                        'descuentos muy altos y sobrepasa el descuento del archivo
                        'de configuracion.
                        If grdDetalle(e.OldRange.r1, 6) <= 0 Then
                            grdDetalle(e.OldRange.r1, 6) = 0
                            ActualizaCalculos()
                            Exit Sub
                        End If

                        If ((grdDetalle(e.OldRange.r1, 6) + (ebPorcentajeDscto.Value * 100)) > (oAppContext.ApplicationConfiguration.Descuento * 100)) Or (grdDetalle(e.OldRange.r1, 6) < 0) Then

                            grdDetalle(e.OldRange.r1, 6) = 0

                            e.Cancel = True

                            grdDetalle.Select(e.OldRange)

                        End If

                        ActualizaCalculos()

                End Select

            End If

        End If

    End Sub

    Private Function SumaCantidad(ByVal Codigo As String, ByVal Talla As String) As Integer

        Dim Cant As Integer = 0

        For Each oRow As DataRow In dsDetalle.Tables(0).Rows

            If CStr(oRow!Codigo).ToUpper.Trim = Codigo.ToUpper.Trim AndAlso CStr(oRow!Talla).ToUpper.Trim = Talla.ToUpper.Trim Then
                Cant += IIf(oRow!Cantidad Is Nothing, 0, oRow!Cantidad)
            End If

        Next

        Return Cant

    End Function

    Private Function CargaCondicionVenta(ByVal objArticulo As Articulo) As CondicionesVtaSAP

        Dim oResult As New CondicionesVtaSAP

        With oResult

            If Not oAppContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                .OficinaVtas = "T" & oAppContext.ApplicationConfiguration.Almacen
            Else
                GoTo Cambio_053
                '.OficinaVtas = "C053"
            End If
            .Jerarquia = objArticulo.Jerarquia
            .CondMat = objArticulo.CodMarca
            .CondPrec = strCondicionVenta
            .Material = objArticulo.CodArticulo
            .ListPrec = strListaPrecios
        End With

        oFacturaMgr.GetCondicionVenta(oResult)

        CargaCondicionVenta = oResult

        oResult = Nothing

    End Function

    Private Sub grdDetalle_BeforeEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdDetalle.BeforeEdit

        If isFormLoad = True Then

            vCodigo = grdDetalle(e.Row, 0)
            vCantidad = grdDetalle(e.Row, 2)
            vImporte = grdDetalle(e.Row, 3)
            vTotal = grdDetalle(e.Row, 4)
            vDescuento = grdDetalle(e.Row, 6)

            'If Me.boolDescuentoDipsEspecial AndAlso Mid(vCodigo.ToUpper.Trim, 1, 6) = "DT-CAT" Then
            '    grdDetalle.Cols(6).AllowEditing = True
            'Else
            '    grdDetalle.Cols(6).AllowEditing = False
            'End If

        End If

    End Sub

    Private Sub grdDetalle_KeyDownEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles grdDetalle.KeyDownEdit

        Select Case e.KeyCode

            'Case Keys.Enter

            '    If grdDetalle.Col = 6 Then

            '        grdDetalle.Select(grdDetalle.Row, 0)

            '    Else

            '        grdDetalle.Select(grdDetalle.Row, grdDetalle.Col + 1)

            '        If grdDetalle(grdDetalle.Row, 0) = String.Empty Then

            '            grdDetalle.Select(grdDetalle.Row, 0)

            '        End If

            '    End If

            Case Keys.Escape

                Me.Finalize()

        End Select

    End Sub

    Private Sub grdDetalle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDetalle.Validating

        Dim Compara As Boolean = False
        Dim TotalAPagarDip As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0

        If Not vApartadoInstance Then

            Dim codeRow As Integer = 0

            '</Verificamos ultima informacion>
            Dim nRow As DataRow

            nRow = dsDetalle.Tables(0).Rows(grdDetalle.Row)

            If nRow!Codigo = String.Empty Or (nRow!Talla = String.Empty And nRow!Cantidad = 0) Then

                If dsDetalle.Tables(0).Rows.Count > 1 Then

                    dsDetalle.Tables(0).Rows(grdDetalle.Row).Delete()
                    dsDetalle.AcceptChanges()
                    grdDetalle.Select(0, 0)
                    ActualizaDatosArticulo(0, grdDetalle.Col)

                Else

                    LimpiaDatosGrid(grdDetalle.Row)

                End If

            Else

                If FindTalla(nRow!Talla) = False Then

                    MsgBox("Talla no corresponde al Artículo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                    e.Cancel = True

                    grdDetalle.Select(grdDetalle.Row, 1)

                    grdDetalle.Focus()

                Else

                    If dsDetalle.Tables(0).Rows.Count > 1 Then


                        'Dim TipoVenta As Boolean

                        'If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "I" Then
                        '    TipoVenta = True
                        'Else
                        '    TipoVenta = False
                        'End If

                        codeRow = BuscaCodigoEnVenta(UCase(nRow!Codigo), nRow!Talla, grdDetalle.Row)

                        If codeRow > 0 Then 'AndAlso (TipoVenta = False OrElse (oFacturaMgr.IsPromoDosPorUnoYMedioVigente("XX") = False AndAlso oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CStr(nRow!Codigo).Substring(0, 2)) = False)) Then

                            MsgBox("El Código / Talla ya fue registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            e.Cancel = True

                            grdDetalle.Select(grdDetalle.Row, 1)

                            grdDetalle.Focus()

                            Exit Sub

                        End If

                    End If

                    If nRow!Cantidad <= 0 Then

                        MsgBox("Cantidad debe ser mayor a cero. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Factura")

                        e.Cancel = True

                        grdDetalle.Focus()

                        Exit Sub

                    Else

                        If nRow!Cantidad > ebExistencias.Value Then

                            MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")

                            e.Cancel = True

                            grdDetalle.Focus()

                            Exit Sub

                        Else

                            '------------------------------------------------------------------------------------------------------------
                            'Actualizamos total y descuento por sistema
                            '------------------------------------------------------------------------------------------------------------
                            grdDetalle(grdDetalle.Row, 4) = Decimal.Round(grdDetalle(grdDetalle.Row, 3) * grdDetalle(grdDetalle.Row, 2), 2)
                            If ebPorcentajeDscto.Value > 0 Then
                                grdDetalle(grdDetalle.Row, 5) = Decimal.Round(grdDetalle(grdDetalle.Row, 4) * ebPorcentajeDscto.Value, 2)
                            Else
                                grdDetalle(grdDetalle.Row, 5) = Decimal.Round(grdDetalle(grdDetalle.Row, 2) * ebMontoDscto.Value, 2)
                            End If

                        End If

                    End If

                    '</Descuento>
                    If nRow!Adicional > 0 Then
                        If nRow!Adicional > (oAppContext.ApplicationConfiguration.Descuento * 100) Then
                            MsgBox("Solo puede aplicar hasta el " & oAppContext.ApplicationConfiguration.Descuento * 100 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                            e.Cancel = True
                            grdDetalle(grdDetalle.Row, 6) = 0
                            grdDetalle.Focus()
                            Exit Sub
                        End If
                    Else
                        grdDetalle(grdDetalle.Row, 6) = 0
                    End If
                    '<End/>

                End If

            End If

            nRow = Nothing
            '<End/>


            'AplicaDescuentosDips:
            ''</Contamos las piezas de la factura y  verificamos descuento maximo>
            'Dim oRow As DataRow, vTPiezas As Integer = 0
            'For Each oRow In dsDetalle.Tables(0).Rows
            '    vTPiezas = vTPiezas + oRow("Cantidad")
            'Next
            'oRow = Nothing
            'TotalPiezasFactura = vTPiezas
            ''<End/>

            'If ebTipoVenta.Value = "D" Then 'And boolDescuentoDipsEspecial = False Then     '-- Asociados DIP's
            '    If dsDetalle.Tables(0).Rows.Count > 0 Then
            '        '--Calculamos Descuentos para el Asociado
            '        Dim bolOverFlowDescuento As Boolean = False
            '        Dim oDsctoGeneral As Decimal = 0
            '        Dim oDsctoArticulo As Decimal = 0
            '        Dim iFil As Integer = 0

            '        If vTPiezas = 0 Then
            '            oFactura.DescTotal = 0
            '        Else
            '            oFactura.DescTotal = 0

            '            'verificamos si ya compro el catalogo
            '            strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

            '            'Checamos si lleva el catalogo (Libro)
            '            For Each oRow In dsDetalle.Tables(0).Rows
            '                If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
            '                    strLlevaCatalogo = "S"
            '                    Exit For
            '                Else
            '                    strLlevaCatalogo = ""
            '                End If
            '            Next

            '            For Each oRow In dsDetalle.Tables(0).Rows
            '                '--oRow!Descuento = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))


            '                If strCat = "S" Then 'S=Ya lo compro     X=No lo ha comprado
            '                    'validar que en el detalle no le aplique descuento a los catalogos (Libros)
            '                    If Mid(oRow("Codigo"), 1, 6) <> "DT-CAT" Then
            '                        oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
            '                    End If
            '                Else
            '                    'Si lleva el catalogo por primera vez le aplica descuentos a los articulos
            '                    If strLlevaCatalogo = "S" Then
            '                        'validar que en el detalle no le aplique descuento a los catalogos (Libros)
            '                        If Mid(oRow("Codigo"), 1, 6) <> "DT-CAT" Then
            '                            oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
            '                        End If
            '                    Else
            '                        oRow!Adicional = 0
            '                    End If

            '                End If

            '                iFil = iFil + 1

            '            Next
            '            ActualizaCalculos()
            '        End If
            '    End If

            'ElseIf ebTipoVenta.Value = "S" Then

            '    If boolDescuentoSocioEspecial = False Then

            '        For Each oRow In dsDetalle.Tables(0).Rows

            '            oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))

            '        Next

            '    End If

            '    ActualizaCalculos()

            'Else

            '    If ebTipoVenta.Value = "D" Then

            '        'verificamos si ya compro el catalogo
            '        strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

            '        'Checamos si lleva el catalogo (Libro)
            '        For Each oRow In dsDetalle.Tables(0).Rows
            '            If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
            '                strLlevaCatalogo = "S"
            '                Exit For
            '            Else
            '                strLlevaCatalogo = ""
            '            End If
            '        Next

            '    End If

            '    ActualizaCalculos()
            'End If
            'If Me.boolDescuentoDPakete = False Then
            '--------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos dips de la forma según este configurada la aplicación
            '--------------------------------------------------------------------------------------------------------------------------------
            'If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
            '    AplicaDescuentosDips()
            'Else
            '    AplicaDescuentosDips()
            '    'NuevosDescuentosDips()
            'End If

            'TotalAPagarDip = oFactura.Total

            'If Compara = False AndAlso dsDetalle.Tables(0).Rows.Count > 0 AndAlso oFactura.CodTipoVenta <> "E" Then
            '    AplicaPromocionesVigentes()
            '    TotalAPagarPromo = oFactura.Total
            'ElseIf oFactura.CodTipoVenta = "E" Then
            '    If Me.promociones.Select("Promociones='Vale Empleados'").Length = 0 Then
            '        AgregarPromocion(Me.promociones, "Vale Empleados")
            '    End If
            'End If

            'If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo AndAlso Compara = False Then
            '    Compara = True
            '    GoTo AplicaDescuentosDips
            'End If

            'VerificaCondicionDescuento(dsDetalle.Tables(0))
            AplicarPromociones()
        End If

    End Sub
    Private Sub VerificaCondicionDescuento(ByRef dtDetalle As DataTable)

        For Each oRow As DataRow In dtDetalle.Rows
            If oRow!Adicional > 0 AndAlso CStr(oRow!Condicion).Trim = "" Then
                oRow!Condicion = "ZDP4"
            End If
        Next
        dtDetalle.AcceptChanges()

    End Sub

    Private Sub AplicaDescuentosDips()

        '</Contamos las piezas de la factura y  verificamos descuento maximo>
        Dim oRow As DataRow, vTPiezas As Integer = 0
        For Each oRow In dsDetalle.Tables(0).Rows
            vTPiezas = vTPiezas + oRow("Cantidad")
        Next
        oRow = Nothing
        TotalPiezasFactura = vTPiezas
        '<End/>

        If ebTipoVenta.Value = "D" Then 'And boolDescuentoDipsEspecial = False Then     '-- Asociados DIP's
            If dsDetalle.Tables(0).Rows.Count > 0 Then
                '--Calculamos Descuentos para el Asociado
                Dim bolOverFlowDescuento As Boolean = False
                Dim oDsctoGeneral As Decimal = 0
                Dim oDsctoArticulo As Decimal = 0
                Dim iFil As Integer = 0

                If vTPiezas = 0 Then
                    oFactura.DescTotal = 0
                Else
                    oFactura.DescTotal = 0

                    'verificamos si ya compro el catalogo
                    RestService = New ProcesosRetail("/pos/dips", "POST")
                    'RestService.Metodo = "/pos/dips"

                    Dim result As Dictionary(Of String, Object) = RestService.SapZbapiSelectDips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                    strCat = CStr(result("SapZbapiSelectDips")("O_RETURN"))
                    'strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

                    'Checamos si lleva el catalogo (Libro)
                    For Each oRow In dsDetalle.Tables(0).Rows
                        If CStr(oRow("Codigo")) <> "" Then
                            If EsCatalogo(oRow("Codigo")) = True Then 'Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                                strLlevaCatalogo = "S"
                                Exit For
                            Else
                                strLlevaCatalogo = ""
                            End If
                        End If
                    Next

                    For Each oRow In dsDetalle.Tables(0).Rows
                        '--oRow!Descuento = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))

                        If CStr(oRow("Codigo")) <> "" Then
                            If strCat = "S" Then 'S=Ya lo compro     X=No lo ha comprado
                                'validar que en el detalle no le aplique descuento a los catalogos (Libros)
                                'Mid(oRow("Codigo"), 1, 6) <> "DT-CAT"
                                If EsCatalogo(oRow("Codigo")) = False AndAlso oRow("Codigo") <> "" Then
                                    oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
                                    If oRow!Adicional > 0 Then oRow!Condicion = "ZDP4"
                                End If
                            Else
                                'Si lleva el catalogo por primera vez le aplica descuentos a los articulos
                                If strLlevaCatalogo = "S" Then
                                    'validar que en el detalle no le aplique descuento a los catalogos (Libros)
                                    'Mid(oRow("Codigo"), 1, 6) <> "DT-CAT"
                                    If EsCatalogo(oRow("Codigo")) = False AndAlso oRow("Codigo") <> "" Then
                                        oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
                                        If oRow!Adicional > 0 Then oRow!Condicion = "ZDP4"
                                    End If
                                Else
                                    oRow!Adicional = 0
                                End If

                            End If

                            iFil = iFil + 1
                        End If

                    Next
                    ActualizaCalculos()
                End If
            End If

        ElseIf ebTipoVenta.Value = "S" Then

            'If boolDescuentoSocioEspecial = False Then

            For Each oRow In dsDetalle.Tables(0).Rows
                'Mid(oRow!Codigo, 1, 6) <> "DT-CAT"
                If oRow("Codigo") <> "" AndAlso (boolDescuentoSocioEspecial = False OrElse EsCatalogo(oRow!Codigo) = False) Then

                    oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
                    If oRow!Adicional > 0 Then oRow!Condicion = "ZDP4"

                End If

            Next

            '        End If

            ActualizaCalculos()

        Else

            If ebTipoVenta.Value = "D" Then
                RestService = New ProcesosRetail("/pos/dips", "POST")
                'verificamos si ya compro el catalogo
                'RestService.Metodo = "/pos/dips"

                Dim result As Dictionary(Of String, Object) = RestService.SapZbapiSelectDips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                strCat = CStr(result("SapZbapiSelectDips2")("O_RETURN"))
                'strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

                'Checamos si lleva el catalogo (Libro)
                For Each oRow In dsDetalle.Tables(0).Rows
                    If EsCatalogo(oRow("Codigo")) = False Then 'Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                        strLlevaCatalogo = "S"
                        Exit For
                    Else
                        strLlevaCatalogo = ""
                    End If
                Next

            End If

            ActualizaCalculos()

        End If

    End Sub

    Public Function EsCatalogo(Material As String) As Boolean
        Dim bRes As Boolean = False
        Dim oArticulo As Articulo, oArticuloMgr As New CatalogoArticuloManager(oAppContext)

        oArticulo = oArticuloMgr.Create
        oArticuloMgr.LoadInto(Material.Trim, oArticulo)
        If (Not oArticulo Is Nothing AndAlso oArticulo.CodArticulo.Trim <> "") AndAlso oArticulo.CodMarca.Trim.ToUpper = "DT" Then
            bRes = True
        End If

        Return bRes
    End Function

    Private Sub NuevosDescuentosDips()

        Dim Descuento As Decimal = 0
        Dim oRow As DataRow

        If dsDetalle.Tables(0).Rows.Count > 0 Then

            Descuento = oSAPMgr.ZRFC_DESCDIPS(oFactura.ClienteId.ToString)

            If Descuento > 0 Then
                '----------------------------------------------------------------------------------------------------------------------
                'Verificamos si ya compro el catalogo, S=Ya lo compro     X=No lo ha comprado
                '----------------------------------------------------------------------------------------------------------------------
                strCat = ""
                RestService.Metodo = "pos/dips"

                Dim result As Dictionary(Of String, Object) = RestService.SapZbapiSelectDips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                strCat = CStr(result("SapZbapiSelectDips")("SapReturn"))
                'strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))
                '----------------------------------------------------------------------------------------------------------------------
                'Si no ha comprado el catálogo (Libro), checamos si lo lleva en el detalle de la factura
                '----------------------------------------------------------------------------------------------------------------------
                If strCat.Trim <> "S" Then
                    strLlevaCatalogo = ""
                    For Each oRow In dsDetalle.Tables(0).Rows
                        If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                            strLlevaCatalogo = "S"
                            Exit For
                        End If
                    Next
                End If

                If strCat.Trim = "S" OrElse strLlevaCatalogo.Trim = "S" Then
                    For Each oRow In dsDetalle.Tables(0).Rows
                        '----------------------------------------------------------------------------------------------------------------------
                        'Validar que en el detalle no le aplique descuento a los catálogos (Libros)
                        '----------------------------------------------------------------------------------------------------------------------
                        If Mid(oRow("Codigo"), 1, 6) <> "DT-CAT" AndAlso oRow("Codigo") <> "" Then
                            oRow!Adicional = Descuento
                            If oRow!Adicional > 0 Then oRow!Condicion = "ZDP4"
                        End If
                    Next

                    ActualizaCalculos()
                End If

            End If

        End If

    End Sub

    Private Function AplicarPromociones(Optional ByVal Porc As Decimal = 0, Optional ByVal oCuponDesc As CuponDescuento = Nothing, _
   Optional ByVal bAceptaPromo As Boolean = True) As Boolean
        Dim Compara As Boolean = False
        Dim TotalAPagarDip As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0
        Dim bolResult As Boolean = True

AplicaDescuentosDips:
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si es tipo de venta DIPs o Socios aplicamos el descuento exclusivo para estos clientes
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If InStr("D,S", Me.ebTipoVenta.Value) > 0 AndAlso oCuponDesc Is Nothing Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos dips de la forma según este configurada la aplicación
            '-------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 27/02/2013: Agrega promocion de Cupon a los DIPS y Socios
            '-------------------------------------------------------------------------------------------------------------------------------------
        ElseIf InStr("D,S", Me.ebTipoVenta.Value) > 0 AndAlso CStr(oCuponDesc.InfoCupon("MODULO")).ToUpper() = "SH" Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos dips de la forma según este configurada la aplicación
            '-------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/02/2014: En caso de que tome la nueva promocion de cupon con todas las demas promociones solo siendo los cupones de Si Hay
            '----------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.CuponDescuentos = True AndAlso (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") = True AndAlso CStr(oCuponDesc.InfoCupon("MODULO")).ToUpper() = "SH" Then
                Dim dsTemp As DataSet
                dsTemp = DesAgruparCodigosDIPS(dsDetalle).Copy
                bolResult = AplicaPromocionEspecialCupon(dsTemp.Tables(0), oCuponDesc, "ZDP4")
                dsTemp = AgruparCodigos(dsTemp).Copy
                ActualizaDescuentosAdicionales(dsTemp.Tables(0))
                ActualizaCalculos()
            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Obtenemos el total a pagar una vez ha sido aplicada la promocion para clientes DIPs y Socios
        '-----------------------------------------------------------------------------------------------------------------------------------------
        TotalAPagarDip = oFactura.Total
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Ahora aplicamos las promociones vigentes para posteriormente comparar cual promocion le conviene mas al cliente
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If Compara = False AndAlso dsDetalle.Tables(0).Rows.Count > 0 Then 'AndAlso oFactura.CodTipoVenta <> "E" Then
            bolResult = AplicaPromocionesVigentes(Porc, oCuponDesc, bAceptaPromo)
            TotalAPagarPromo = oFactura.Total
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Comparamos cual promocion le conviene mas al cliente y la aplicamos segun sea el caso
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo AndAlso Compara = False Then
            Compara = True
            GoTo AplicaDescuentosDips
        End If

        '----------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (11/11/2015): En caso de que sea cupon para promoción del Buen Fin, que se aplique con todas las demas promociones
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not oCuponDesc Is Nothing AndAlso CStr(oCuponDesc.InfoCupon("CUPON_CHECK")).ToUpper() = "X" Then
            Dim dsTemp As DataSet
            dsTemp = DesAgruparCodigosDIPS(dsDetalle).Copy
            bolResult = AplicaPromocionEspecialCupon(dsTemp.Tables(0), oCuponDesc, "ZDP4")
            dsTemp = AgruparCodigos(dsTemp).Copy
            ActualizaDescuentosAdicionales(dsTemp.Tables(0))
            ActualizaCalculos()
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Verificamos que ningun material haya quedado sin condicion de descuento para que no haya problemas al guardar en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------
        VerificaCondicionDescuento(dsDetalle.Tables(0))

        Return bolResult

    End Function

    Private Function AplicaPromocionesVigentes(ByVal Porc As Decimal, ByRef oCupon As CuponDescuento, ByVal bAceptaPromo As Boolean) As Boolean

        Dim dsTemp As DataSet
        Dim bolResult As Boolean = True

        'If ebTipoVenta.Value = "P" OrElse ebTipoVenta.Value = "I" OrElse ebTipoVenta.Value = "E" Then

        dsTemp = DesAgruparCodigos(dsDetalle).Copy

        'End If

        'If ebTipoVenta.Value <> "D" AndAlso ebTipoVenta.Value <> "S" Then

        bolResult = AplicaDescuentosAutomaticos(dsTemp.Tables(0), Porc, bAceptaPromo, oCupon)

        'End If

        'If ebTipoVenta.Value = "P" OrElse ebTipoVenta.Value = "I" OrElse ebTipoVenta.Value = "E" Then

        dsTemp = AgruparCodigos(dsTemp).Copy

        'End If

        ActualizaDescuentosAdicionales(dsTemp.Tables(0))
        ActualizaCalculos()

        Return bolResult

    End Function

    Private Sub grdDetalle_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdDetalle.StartEdit

        If e.Col = 0 Then

            If grdDetalle(e.Row, 0) <> String.Empty Then

                e.Cancel = True

            End If
            'No permite editar la celda del descuento adicional si el tipo de venta es DPVale
            'ElseIf e.Col = 6 AndAlso Me.ebTipoVenta.Value = "V" Then

            '    e.Cancel = True
            'No permite editar la celda del descuento adicional ahora se genera automaticamente por sistema
            ' ElseIf e.Col = 6 Then

            'e.Cancel = True

        End If

    End Sub

#End Region

#Region "General User Methods"

    Private Sub LoadSearchFormFactura()
        strQuin = 0
        bolMenuAbrir = True
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim dtDetalleVale As DataTable
        oOpenRecordDlg.CurrentView = New FacturaCajaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            bolIsOpenFacturaInput = True
            oFactura.ClearFields()
            oFacturaMgr.LoadInto(oOpenRecordDlg.Record.Item("FacturaID"), oFactura)

            If oFactura.FacturaID = 0 Then
                MsgBox("Folio de Factura No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                ebFolioFactura.Focus()
            Else

                'CArgamos folio sap
                EbFolioSAP.Visible = True

                '--Cargamos Cliente
                oCliente.Clear()
                If ebClienteID.Value = 1 Then
                    oFactura.ClienteId = 1
                    ebClienteDescripcion.Text = "PÚBLICO GENERAL"
                    'ebClienteID.Value = 0
                Else
                    If oFactura.CodTipoVenta = "A" Then
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, "I")
                    Else
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, oFactura.CodTipoVenta)
                    End If
                    If oCliente.CodigoAlterno = 0 Then
                        ebClienteDescripcion.Text = ""
                    Else
                        oFactura.ClienteId = oCliente.CodigoAlterno
                        ebClienteDescripcion.Text = oCliente.NombreCompleto
                    End If
                End If
                '---Cargamos Numero de Quincenas
                If oFactura.CodTipoVenta = "V" Then
                    Dim dpValeId As Integer = oFacturaMgr.GetDPVALEID(oFactura.FacturaID)
                    Dim FechaCobro As Date

                    'strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(dpValeId), FechaCobro, dtDetalleVale)

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                    '--------------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then
                        '----------------------------------------------------------------------------------------
                        ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                        '----------------------------------------------------------------------------------------
                        strQuin = oS2Credit.ObtenerPromociones(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(dpValeId), FechaCobro, dtDetalleVale)
                    Else
                        strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(dpValeId), FechaCobro, dtDetalleVale)
                    End If
                    '--------------------------------------------------------------------------------------------
                End If


                '--Cargamos Vendedores
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
                If oVendedor.ID <> String.Empty Then
                    ebPlayerDescripcion.Text = oVendedor.Nombre
                    oFactura.CodVendedor = oVendedor.ID
                Else
                    ebPlayerDescripcion.Text = ""
                End If

                '--Cargamos Apartado
                If oFactura.ApartadoID <> 0 Then
                    Dim oApartadoMgr As New ContratoManager(oAppContext)
                    Dim oApartadoInfo As Contrato
                    oApartadoInfo = oApartadoMgr.Create
                    oApartadoInfo = oApartadoMgr.Load(oFactura.ApartadoID)
                    If (Not oApartadoInfo Is Nothing) And oApartadoInfo.FolioApartado <> 0 Then
                        ebFolioApartado.Value = oApartadoInfo.FolioApartado
                    Else
                        ebFolioApartado.Value = oFactura.ApartadoID
                    End If
                    oApartadoInfo = Nothing
                    oApartadoMgr = Nothing
                End If
                '

                '--Cargamos Detalle de la Factura
                oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
                grdDetalle.DataSource = Nothing
                grdDetalle.DataSource = oFactura.Detalle.Tables(0)
                FormateaGrid()
                explorerBar1.Enabled = False
                Me.UiCommandBar2.Commands("menuArchivoImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True

                'Calculamos total de piezas
                Me.nebTotalPiezas.Value = oFactura.Detalle.Tables(0).Compute("SUM(Cantidad)", "")

            End If

            bolIsOpenFacturaInput = False

        End If

        bolMenuAbrir = False

    End Sub

    Public Function CreateTempData() As DataTable

        dsDetalle = Nothing
        dsDetalle = New DataSet
        Dim dtDetalle As New DataTable("Detalle")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Codigo"
        dCol.Caption = "Código"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = True
        dCol.MaxLength = 20
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.Caption = "Código"
        dCol.ColumnName = "CodProveedor"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = True
        dCol.MaxLength = 20
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Talla"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Int16")
        dCol.ColumnName = "Cantidad"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "Importe"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "Total"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "Descuento"
        dCol.Caption = "Descuento %"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.Decimal")
        dCol.ColumnName = "Adicional"
        dCol.Caption = "Adicional"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = True
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("UsadoPromo")
        dCol.DataType = System.Type.GetType("System.Boolean")
        dCol.DefaultValue = False
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("Checado")
        dCol.DataType = System.Type.GetType("System.Boolean")
        dCol.DefaultValue = False
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("Condicion")
        dCol.DataType = System.Type.GetType("System.String")
        dCol.MaxLength = 4
        dCol.DefaultValue = ""
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("DevolucionCupon")
        dCol.DataType = GetType(Boolean)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("ConExistencia")
        dCol.DataType = GetType(Integer)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("SinExistencia")
        dCol.DataType = GetType(Integer)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("ModoVenta")
        dCol.DataType = GetType(Integer)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("Descripcion")
        dCol.DataType = GetType(String)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn("Stock")
        dCol.DataType = GetType(Integer)
        dCol.DefaultValue = DBNull.Value
        dtDetalle.Columns.Add(dCol)

        dsDetalle.Tables.Add(dtDetalle)

        grdDetalle.DataSource = Nothing

        'grdDetalle.DataSource = dsDetalle.Tables(0)
        dgHeader.DataSource = dsDetalle.Tables(0)
        'grdDetalle.Cols(0).Width = 185
        'grdDetalle.Cols(1).Width = 57
        'grdDetalle.Cols(1).Format = "##0.0"
        'grdDetalle.Cols(2).Width = 63
        'grdDetalle.Cols(2).Format = "##0"
        'grdDetalle.Cols(3).Width = 80
        'grdDetalle.Cols(3).Format = "$ ###,##0.00"
        'grdDetalle.Cols(3).AllowEditing = False
        'grdDetalle.Cols(4).Width = 80
        'grdDetalle.Cols(4).Format = "$ ###,##0.00"
        'grdDetalle.Cols(4).AllowEditing = False
        'grdDetalle.Cols(5).Width = 80
        'grdDetalle.Cols(5).Format = "$ ###,##0.00"
        'grdDetalle.Cols(5).AllowEditing = False
        'grdDetalle.Cols(6).Width = 80
        'grdDetalle.Cols(6).Format = "##0.00"
        'grdDetalle.Cols(6).AllowEditing = False
        'grdDetalle.Cols(7).Visible = False
        'grdDetalle.Cols(8).Visible = False
        'grdDetalle.Cols(9).Visible = False
        'grdDetalle.Cols(10).Visible = False
        dgHeader.Tables(0).Columns("Cantidad").EditType = EditType.TextBox
        If vApartadoInstance = False Then
            'dRow = dsDetalle.Tables(0).NewRow()
            'dRow("Codigo") = ""
            'dRow("Talla") = 0
            'dRow("Cantidad") = 0
            'dRow("Importe") = 0
            'dRow("Total") = 0
            'dRow("Descuento") = 0
            'dRow("Adicional") = 0
            'dsDetalle.Tables(0).Rows.Add(dRow)
        End If

        Return dtDetalle.Copy

    End Function

    Private Function ValidateRowGrid(ByVal gRow As Integer) As Boolean

        On Error GoTo EscapeLongHorn

        Dim mMensaje As String = ""

        If gRow >= 0 Then

            If grdDetalle(gRow, 0) = "" Then

                mMensaje = mMensaje + " CODIGO" + vbCrLf

            End If

            If grdDetalle(gRow, 1) = "" Then

                mMensaje = mMensaje + " TALLA" + vbCrLf

            End If

            If grdDetalle(gRow, 2) = 0 Then

                mMensaje = mMensaje + " CANTIDAD" + vbCrLf

            End If

            If mMensaje <> "" Then

                MsgBox("Los siguientes datos no son correctos. " & vbCrLf & vbCrLf & mMensaje, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "   Facturación")

                Return False

            Else

                Return True

            End If

        End If

EscapeLongHorn:

        Exit Function

    End Function

    Private Sub LimpiaDatosGrid(ByVal oRow As Integer)

        oFactura.DescTotal = 0
        oFactura.Total = 0
        oFactura.SubTotal = 0
        oFactura.IVA = 0
        oArticulo.CodCorrida = String.Empty
        oArticulo.CodArticulo = String.Empty
        oArticulo.Descripcion = String.Empty
        txtCorrida.Text = String.Empty
        ebPorcentajeDscto.Text = String.Empty
        oArticulo.Descuento = 0
        oArticulo.PrecioOferta = 0
        ebPrecioArticulo.Value = 0
        oFactura.FacturaArticuloExistencia = 0
        oFactura.FacturaArticuloTallaAl = 0
        oFactura.FacturaArticuloTallaDel = 0
        dsDetalle.Tables(0).Clear()
        grdDetalle(oRow, 0) = ""
        grdDetalle(oRow, 1) = ""
        grdDetalle(oRow, 2) = 0
        grdDetalle(oRow, 3) = 0
        grdDetalle(oRow, 4) = 0
        grdDetalle(oRow, 5) = 0
        grdDetalle(oRow, 6) = 0

    End Sub

    Private Sub FillTipoVenta()

        Dim FiltroTipoVenta As String = ""
        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)
        dsTipoVenta = oTipoVentaMgr.Load()

        '------------------------------------------------------------------------------------------------------------
        ' JNAVA 27/10/2014: Se quito la validacion que quitaba las ventas DPVales y se Mejoro filtro
        '------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.DPValeSiHay = True Then
            FiltroTipoVenta = "CodTipoVenta <> 'S' AND CodTipoVenta <> 'O' AND CodTipoVenta <> 'K' AND CodTipoVenta <> 'A'"
        Else
            FiltroTipoVenta = "CodTipoVenta <> 'S' AND CodTipoVenta <> 'O' AND CodTipoVenta <> 'V' AND CodTipoVenta <> 'K' AND CodTipoVenta <> 'A'"
        End If

        If oConfigCierreFI.TipoVentaFactFiscal = False Then
            FiltroTipoVenta &= " AND CodTipoVenta <> 'I'"
        End If

        '------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 14/09/2020: Se agrega que se quite el tipo de venta DIP's a petición de EDGAR EDUARDO LIZARRAGA 
        '------------------------------------------------------------------------------------------------------------

        'FiltroTipoVenta &= " AND CodTipoVenta <> 'D'"

        '----------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 26.07.2013: Filtramos por los tipos de ventas permitidos para las ventas SH solamente
        '----------------------------------------------------------------------------------------------------------------------------------------------
        Dim dtTipoVenta As DataTable = dsTipoVenta.Tables(0).Copy
        Dim dvTipoVenta As New DataView(dtTipoVenta, FiltroTipoVenta, "CodTipoVenta", DataViewRowState.CurrentRows)
        'Dim oRow As DataRowView

        ''--------------------------------------------------------------------------------------
        ''FLIZARRAGA 06/10/2014: Se quito la validacion que quitaba las ventas DPVales
        ''--------------------------------------------------------------------------------------
        'If oConfigCierreFI.DPValeSiHay = True Then
        '    dvTipoVenta.RowFilter = "Not CodTipoVenta In ('O','S')"
        'Else
        '    dvTipoVenta.RowFilter = "Not CodTipoVenta In ('O','D','S')"
        'End If


        'dsTipoVenta.Tables(0).Clear()

        'For Each oRow In dvTipoVenta
        '    dsTipoVenta.Tables(0).ImportRow(oRow.Row)
        'Next

        'ebTipoVenta.SetDataBinding(dsTipoVenta, dsTipoVenta.Tables(0).TableName)
        ebTipoVenta.DataSource = dvTipoVenta
        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"
        ebTipoVenta.Value = "P"

        ebTipoVenta.Refresh()

        oTipoVentaMgr.Dispose()

        strCondicionVenta = ebTipoVenta.DropDownList.GetValue(2)
        strListaPrecios = ebTipoVenta.DropDownList.GetValue(3)

        ' Dim dvTipoVenta As New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'P'", "CodTipoVenta", DataViewRowState.CurrentRows)
        'dvTipoVenta.RowFilter = "CodTipoVenta = 'P'"

        strCondicionVenta = dvTipoVenta(0)("CodSAP")
        strListaPrecios = dvTipoVenta(0)("ListaPrecios")
        oFactura.MotivoPedido = dvTipoVenta(0)("MotivoPedido")
        ebTipoVenta.Value = "P"
        Dim cattipoventa As New CatalogoTipoVentaManager(oAppContext)
        oFactura.MotivoPedido = cattipoventa.GetMotivoPedidoByTipoVenta(ebTipoVenta.Value)

    End Sub

    Private Sub LoadSearchFormClientesSAP()

        Dim oOpenRecordDlg As OpenFROMSAPRecordDialogClientes

        oOpenRecordDlg = New OpenFROMSAPRecordDialogClientes

        oOpenRecordDlg.TipoVenta = oFactura.CodTipoVenta
        oOpenRecordDlg.CurrentView = New ClientesFromSAPOpenRecordDialogView


        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Try

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    Me.ebClienteID.Text = oOpenRecordDlg.Record.Item("KUNNR")
                    Me.ebClienteDescripcion.Text = oOpenRecordDlg.Record.Item("NAME1")

                Else

                    Me.ebClienteID.Text = CType(oOpenRecordDlg.pbCodigo, String)
                    Me.ebClienteDescripcion.Text = CType(oOpenRecordDlg.pbNombre, String)

                End If
                'If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(Me.ebClienteID.Text)
                'Me.oClienteMgr.Load(Me.ebClienteID.Text, oCliente, oFactura.CodTipoVenta)
                'oFactura.ClienteId = CInt(oCliente.CodigoAlterno)
                'ebCodVendedor.Focus()
                If ebCodVendedor.Text.Trim() = "" Then
                    ebCodVendedor.Focus()
                Else
                    dgHeader.Focus()
                End If
                If CStr(ebTipoVenta.Value) = "D" Or CStr(ebTipoVenta.Value) = "S" Then
                    If dsDetalle.Tables(0).Rows.Count > 0 Then
                        If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                            AplicaDescuentosDips()
                        Else
                            AplicaDescuentosDips()
                            'NuevosDescuentosDips()
                        End If
                    End If
                End If
            Catch ex As Exception

                Throw New ApplicationException("[LoadSearchForm]", ex)

            End Try

        End If

    End Sub

    Private Sub LoadSearchFormCliente()

        Dim oOpenRecordDlg As OpenRecordDialogClientes

        Dim strTipoVenta As String = Me.oFactura.CodTipoVenta

        oCliente = Me.oClienteMgr.CreateAlterno
        oCliente.TipoVenta = strTipoVenta
        oOpenRecordDlg = New OpenRecordDialogClientes
        oOpenRecordDlg.GrupoDeCuentas = oCliente.TipoVenta
        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            Try

                Dim intClienteID As String

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    intClienteID = oOpenRecordDlg.Record.Item("CodigoAlterno")

                Else

                    intClienteID = CType(oOpenRecordDlg.pbCodigo, String)

                End If

                Me.oClienteMgr.Load(intClienteID, oCliente, strTipoVenta)

                oFactura.ClienteId = CInt(oCliente.CodigoAlterno)
                ebClienteDescripcion.Text = oCliente.Nombre.Trim & " " & oCliente.ApellidoPaterno.Trim & " " & oCliente.ApellidoMaterno.Trim

                'ebCodVendedor.Focus()
                If ebCodVendedor.Text.Trim() = "" Then
                    ebCodVendedor.Focus()
                Else
                    dgHeader.Focus()
                End If
                If CStr(ebTipoVenta.Value) = "D" Or CStr(ebTipoVenta.Value) = "S" Then
                    If dsDetalle.Tables(0).Rows.Count > 0 Then
                        If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                            AplicaDescuentosDips()
                        Else
                            AplicaDescuentosDips()
                            'NuevosDescuentosDips()
                        End If
                    End If
                End If
            Catch ex As Exception

                Throw ex

            End Try

        End If

    End Sub

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "  Facturación ")
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "2"
            '        MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "1"
            If oOpenRecordDialogView.pbNombre <> String.Empty Then
                oFactura.CodVendedor = oOpenRecordDialogView.pbCodigo
                ebPlayerDescripcion.Text = oOpenRecordDialogView.pbNombre

            Else
                oFactura.CodVendedor = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebPlayerDescripcion.Text = oOpenRecordDialogView.Record.Item("Nombre")
            End If
            'End Select

        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub FillTallasArticulo(ByVal vCodCorrida As String)

        dsTallas = Nothing

        dsTallas = oFacturaMgr.GetTallasArticulo(vCodCorrida)

        If dsTallas Is Nothing Then

            MsgBox("Corrida del Artículo NO EXISTE.  ", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, "  Facturación")

        End If

    End Sub

    Private Function FindTalla(ByVal strTalla As String) As Boolean

        Dim iCol As Integer
        Dim campoTalla As String

        If Not (dsTallas Is Nothing) Then

            For iCol = 0 To 19

                campoTalla = "C" & Format(iCol + 1, "00")

                If dsTallas.Tables(0).Rows(0).Item(campoTalla) = strTalla Then

                    Return True

                End If

            Next

        End If

        Return False

    End Function

    Private Sub ActualizaDatosArticulo(ByVal oRow As Integer, ByVal oCol As Integer)

        oArticulo.ClearFields()

        oArticuloMgr.LoadInto(grdDetalle(oRow, 0), oArticulo)

        oFactura.FacturaArticuloExistencia = 0

        '--oArticulo.Descuento = oArticulo.Descuento / 100

        FillTallasArticulo(oArticulo.CodCorrida)

        '--Obtenemos Tallas del Artículo
        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

        '--Obtenemos Existencia
        oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(oRow, 1), oFactura)

        'oArticulo.PrecioVenta = Decimal.Round(oArticulo.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA), 2)

        'Sacamos el precio real del articulo con descuento C053 Incluido.


        If oAppContext.ApplicationConfiguration.Almacen = "053" Then 'Tienda C1
            If oFactura.CodTipoVenta = "S" Then 'Ventas Socios 25% Descuento
                oArticulo.PrecioVenta = oArticulo.PrecioSocio
                ebPrecioArticulo.Value = (oArticulo.PrecioVenta / 0.75) * (1 + oAppContext.ApplicationConfiguration.IVA) 'Correccion por cambio Faamework (JNAVA - 06/11/2015)
                ebPrecioArticulo.Value = Decimal.Round(ebPrecioArticulo.Value, 2)
            Else 'Ventas 10% Descuento.
                ebPrecioArticulo.Value = (oArticulo.PrecioVenta / 0.9) * (1 + oAppContext.ApplicationConfiguration.IVA) 'Correccion por cambio Faamework (JNAVA - 06/11/2015)
                ebPrecioArticulo.Value = Decimal.Round(ebPrecioArticulo.Value, 2)
            End If
        Else 'Tiendas T1
            ebPrecioArticulo.Value = Decimal.Round(oArticulo.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
        End If


        '--Cargamos Condicion de Venta
        oCondicionVenta = CargaCondicionVenta(oArticulo)
        If oCondicionVenta.DescPorcentaje > 0 Then
            If oAppContext.ApplicationConfiguration.Almacen = "053" Then 'Vemos si la condicion es mayor al descuento C1 o C2
                'If oFactura.CodTipoVenta = "S" Then
                '    If oCondicionVenta.DescPorcentaje > 25 Then
                '        oArticulo.PrecioVenta = oArticulo.PrecioIva / 1.15
                '        ebPrecioArticulo.Value = Decimal.Round((oArticulo.PrecioVenta) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                '        ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
                '    Else
                '        ebPorcentajeDscto.Value = 0
                '        ebMontoDscto.Value = 0
                '    End If
                'Else
                '    If oCondicionVenta.DescPorcentaje > 10 Then
                '        oArticulo.PrecioVenta = oArticulo.PrecioIva / 1.15
                '        ebPrecioArticulo.Value = Decimal.Round((oArticulo.PrecioVenta) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                '        ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
                '    Else
                '        ebPorcentajeDscto.Value = 0
                '        ebMontoDscto.Value = 0
                '    End If
                'End If
                ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
            Else
                ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
            End If
        ElseIf oCondicionVenta.Descmonto > 0 Then 'Ya no Aplica.
            ebMontoDscto.Value = oCondicionVenta.Descmonto
        Else
            ebPorcentajeDscto.Value = 0
            ebMontoDscto.Value = 0
        End If

        'ALLOW
        'Me.grdDetalle.Select(grdDetalle.Row, 1)
        Me.grdDetalle.Cols(0).AllowEditing = False

    End Sub

    Private Function SoloFormaPagoTE(ByVal dtFP As DataTable) As DataTable

        Dim dtResult As DataTable = dtFP.Clone

        For Each oRow As DataRow In dtFP.Rows

            If oRow!CodTipoTarjeta = "TE" Then

                dtResult.ImportRow(oRow)

            End If

        Next

        Return dtResult

    End Function

    Private Function AgruparCodigos(ByVal dsDetTemp As DataSet) As DataSet

        Dim dsDetAgrup As DataSet = dsDetTemp.Copy
        Dim oNewRow As DataRow
        Dim Codigos As String = ""
        Dim Cant As Integer = 0
        Dim Total As Decimal = 0
        Dim TotalDescAdi As Decimal = 0
        Dim TotalDescSis As Decimal = 0
        Dim odtView As DataView
        Dim Condicion As String = ""
        Dim DescMay As Decimal = 0

        dsDetAgrup.Tables(0).Clear()

        For Each oRow As DataRow In dsDetTemp.Tables(0).Rows

            If InStr(Codigos, CStr(oRow!Codigo & oRow!Talla & "|").ToUpper) <= 0 Then

                Codigos &= CStr(oRow!Codigo & oRow!Talla).ToUpper & "|"
                odtView = New DataView(dsDetTemp.Tables(0), "Codigo='" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'", "Codigo", DataViewRowState.CurrentRows)

                TotalDescAdi = 0
                Condicion = ""
                DescMay = 0
                For Each oRowV As DataRowView In odtView
                    TotalDescAdi += (oRowV!Total - oRowV!Descuento) * (oRowV!Adicional / 100)
                    If oRowV!Adicional > DescMay Then
                        DescMay = oRowV!Adicional
                        Condicion = CStr(oRowV!Condicion).Trim
                    End If
                Next

                Cant = dsDetTemp.Tables(0).Compute("Sum(Cantidad)", "Codigo = '" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'")
                Total = dsDetTemp.Tables(0).Compute("Sum(Total)", "Codigo = '" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'")
                TotalDescSis = dsDetTemp.Tables(0).Compute("Sum(Descuento)", "Codigo = '" & oRow!Codigo & "' and Talla='" & oRow!Talla & "'")

                oNewRow = dsDetAgrup.Tables(0).NewRow
                With oNewRow
                    !Codigo = oRow!Codigo
                    !Talla = oRow!Talla
                    !Cantidad = Cant
                    !Importe = oRow!Importe
                    !Total = Total
                    !Descuento = TotalDescSis
                    '!Adicional = IIf(Total - TotalDescSis > 0, (TotalDescAdi * 100) / (Total - TotalDescSis), 0)
                    If Total - TotalDescSis > 0 Then
                        !Adicional = Decimal.Round((TotalDescAdi * 100) / (Total - TotalDescSis), 2)
                    Else
                        !Adicional = 0
                    End If
                    !Checado = oRow!Checado
                    !UsadoPromo = oRow!UsadoPromo
                    !Condicion = Condicion
                End With
                dsDetAgrup.Tables(0).Rows.Add(oNewRow)

            End If

        Next
        dsDetAgrup.AcceptChanges()

        Return dsDetAgrup

    End Function

    Private Function DesAgruparCodigos(ByVal dsDetTemp As DataSet) As DataSet

        Dim dsDetDesAgrup As DataSet = dsDetTemp.Clone
        Dim oNewRow As DataRow

        For Each oRow As DataRow In dsDetTemp.Tables(0).Rows

            For i As Integer = 1 To oRow!Cantidad
                oNewRow = dsDetDesAgrup.Tables(0).NewRow
                With oNewRow
                    !Codigo = oRow!Codigo
                    !Talla = oRow!Talla
                    !Cantidad = 1
                    !Importe = oRow!Importe
                    !Total = oRow!Importe
                    !Descuento = oRow!Descuento / oRow!Cantidad
                    If Mid(CStr(oRow!Codigo), 1, 6) = "DT-CAT" Then
                        !Adicional = oRow!Adicional
                    Else
                        !Adicional = 0
                    End If
                    !Checado = oRow!Checado
                    !UsadoPromo = oRow!UsadoPromo
                End With
                dsDetDesAgrup.Tables(0).Rows.Add(oNewRow)
            Next

        Next
        dsDetDesAgrup.AcceptChanges()

        Return dsDetDesAgrup

    End Function

    '--------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/02/2014: Se creo una nueva funcion de desagrupado para los clientes DIPS para usarla en cupones Si Hay
    '--------------------------------------------------------------------------------------------------------------------

    Private Function DesAgruparCodigosDIPS(ByVal dsDetTemp As DataSet) As DataSet

        Dim dsDetDesAgrup As DataSet = dsDetTemp.Clone
        Dim oNewRow As DataRow

        For Each oRow As DataRow In dsDetTemp.Tables(0).Rows

            For i As Integer = 1 To oRow!Cantidad
                oNewRow = dsDetDesAgrup.Tables(0).NewRow
                With oNewRow
                    !Codigo = oRow!Codigo
                    !Talla = oRow!Talla
                    !Cantidad = 1
                    !Importe = oRow!Importe
                    !Total = oRow!Importe
                    !Descuento = oRow!Descuento / oRow!Cantidad
                    !Adicional = oRow!Adicional
                    !Checado = oRow!Checado
                    !UsadoPromo = oRow!UsadoPromo
                End With
                dsDetDesAgrup.Tables(0).Rows.Add(oNewRow)
            Next

        Next
        dsDetDesAgrup.AcceptChanges()

        Return dsDetDesAgrup

    End Function

    Private Sub ActualizaDescuentosAdicionales(ByRef dtDetalle As DataTable)

        Dim i As Integer = 0
        For Each oRow As DataRow In dtDetalle.Rows

            '----------------------------------------------------------------------------------------
            'RGERMAIN 12.02.2015: Obtenemos el index del articulo para actualizarle las promociones
            '----------------------------------------------------------------------------------------
            i = BuscarCodigoEnDetalle(oRow!Codigo, oRow!Talla, dsDetalle.Tables(0))

            'grdDetalle(i, 6) = oRow!Adicional
            dsDetalle.Tables(0).Rows(i)!Adicional = oRow!Adicional
            dsDetalle.Tables(0).Rows(i)!Condicion = oRow!Condicion
            i += 1

        Next
        dsDetalle.Tables(0).AcceptChanges()

    End Sub

    Private Sub AbrirFormaPago(ByVal CodTipoDescuento As String)

        Try
1:          Dim frmPagoCliente As New frmPago

            If Me.ebTipoVenta.Value = "V" Then
                frmPagoCliente.tipoV = True
            Else
                frmPagoCliente.tipoV = False
            End If
            '----------------------------------------------------------------------------------------------------------
            'Fonacot Facilito change
            '----------------------------------------------------------------------------------------------------------
2:          If oValeCaja.ValeCajaID > 0 Then
3:              frmPagoCliente.oNotaCredito = oNotaCredito
4:              frmPagoCliente.oVC = oValeCaja
            End If

5:          oFactura.Detalle = Nothing
6:          oFactura.Detalle = New DataSet
7:          oFactura.Detalle = dsDetalle.Copy
            '----------------------------------------------------------------------------------------------------------
            'Le pasamos las formas de pago con TE en caso de haberlas
            '----------------------------------------------------------------------------------------------------------
8:          If Not Me.FormasPago Is Nothing Then
9:              Me.FormasPago = SoloFormaPagoTE(Me.FormasPago).Copy
10:             frmPagoCliente.dtFormasPago = Me.FormasPago.Copy
            End If
            frmPagoCliente.ModoVenta = GetModoVenta()
            If frmPagoCliente.ModoVenta = 1 Then
                If SiHay.Tables.Contains("ArticulosConExistencia") = False Then
                    SiHay.Tables.Add(GetArticulosConExistencias())
                Else
                    SiHay.Tables.Remove(SiHay.Tables("ArticulosConExistencia"))
                    SiHay.Tables.Add(GetArticulosConExistencias())
                End If
                If SiHay.Tables.Contains("ArticulosSinExistencias") = False Then
                    SiHay.Tables.Add(GetArticulosSinExistencia())
                Else
                    SiHay.Tables.Remove(SiHay.Tables("ArticulosSinExistencias"))
                    SiHay.Tables.Add(GetArticulosSinExistencia())
                End If
                If SiHay.Tables.Contains("MaterialesLibres") = False Then
                    SiHay.Tables.Add(Me.dtCantidadLibre)
                Else
                    SiHay.Tables.Remove(SiHay.Tables("MaterialesLibres"))
                    SiHay.Tables.Add(Me.dtCantidadLibre)
                End If
                frmPagoCliente.DataSetSiHay = SiHay
            End If
            '----------------------------------------------------------------------------------------------------------
            'Le pasamos el cupon de descuento utilizado en la factura en caso de existir
            '----------------------------------------------------------------------------------------------------------
11:         If Not oCuponDesc Is Nothing Then frmPagoCliente.oCuponDesc = oCuponDesc
            '----------------------------------------------------------------------------------------------------------
            'Si es tipo venta PG pasamos el id del cliente PG
            '----------------------------------------------------------------------------------------------------------
            '12:         If oConfigCierreFI.UsarHuellas AndAlso oFactura.CodTipoVenta = "P" Then
12:         If oFactura.CodTipoVenta = "P" Then
13:             oFactura.ClientPGID = oFactura.ClienteId
14:             'oFactura.ClienteId = 1
            End If
            '----------------------------------------------------------------------------------------------------------
            'Si el cronometro esta corriendo, lo seguimos mostrando en la pantalla de formas pago
            '----------------------------------------------------------------------------------------------------------
15:         If Me.timer1.Enabled = True Then
16:             frmPagoCliente.bCronometro = True
17:             frmPagoCliente.strCrono = Me.lblCronometro.Text
            End If
            'Si debe filtrar las formas de pago por las promociones aplicadas enviamos las formas de pago permitidas
            '----------------------------------------------------------------------------------------------------------
            If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then frmPagoCliente.dtDescFormasPago = dtDescFormasPago.Copy
            '----------------------------------------------------------------------------------------------------------
            'Mostramos pantalla de formas de pago
            '----------------------------------------------------------------------------------------------------------
18:         frmPagoCliente.ShowDialog(oFactura, CodTipoDescuento, vNCInstance, oDevolucionDPvale, vApartadoInstance, _
                                    oValeDescuentoLocalInfo, strCondicionVenta, strListaPrecios)

19:         Me.FormasPago = frmPagoCliente.dtFormasPago.Copy

20:         If frmPagoCliente.DialogResult = DialogResult.OK Then

21:             FacturaGuardada = True
22:             If vNCInstance Or vApartadoInstance Then

23:                 If vNCInstance Then
24:                     vNCFacturada = True
25:                     Me.Close()

                    End If

26:                 frmPagoCliente.Dispose()
27:                 frmPagoCliente = Nothing

28:                 If uICommandManager1.Commands("ToolBarNuevo").Enabled = Janus.Windows.UI.InheritableBoolean.False Then

29:                     Me.Close()

                    Else

30:                     If vApartadoInstance Then
31:                         uICommandManager1.CommandBars(0).Enabled = True
32:                         uICommandManager1.CommandBars(1).Enabled = True
33:                         uICommandManager1.Commands("ToolBarAbrir").Enabled = Janus.Windows.UI.InheritableBoolean.True
34:                         ebTipoVenta.Enabled = True
35:                         ebCodVendedor.Enabled = True
36:                         ebClienteID.Enabled = True
37:                         vApartadoInstance = False
                        End If

38:                     explorerBar1.Enabled = True

39:                     NuevaFactura()

40:                     ebTipoVenta.Focus()

                    End If


                Else

41:                 frmPagoCliente.Dispose()
42:                 frmPagoCliente = Nothing
                    '-----------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 21/02/2018: Se cierra la pantalla de facturación
                    '-----------------------------------------------------------------------------------------------------------
                    Me.Dispose()
                    Exit Sub
                    '                    If bolNC = True Then
                    '                        Me.DialogResult = DialogResult.OK
                    '                        Exit Sub
                    '                    End If

                    '44:                 NuevaFactura()

                    '                    If (bolCloseForm = True) Then
                    '                        Exit Sub
                    '                    End If

                    '45:                 LoadFolioFactura()

                    '46:                 oFactura.CodTipoVenta = "P"
                    '47:                 oFactura.ClienteId = IIf(oConfigCierreFI.UsarHuellas = True, 0, 1)

                    '                    ebTipoVenta.Focus()

                End If

            Else

48:             FacturaGuardada = False
49:             frmPagoCliente.Dispose()
50:             frmPagoCliente = Nothing
                '----------------------------------------------------------------------------------------------------------
                'Regresamos el id del cliente PG
                '----------------------------------------------------------------------------------------------------------
51:             'If oConfigCierreFI.UsarHuellas AndAlso oFactura.CodTipoVenta = "P" Then oFactura.ClienteId = oFactura.ClientPGID

            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al abrir la formas de pago: Linea " & Err.Erl) ',  ex)
            'Throw ex
        End Try

    End Sub

    Private Sub NuevaFactura()

        oFingerP = Nothing
        strCat = ""
        strLlevaCatalogo = ""
        bolMenuAbrir = False

        boolDescuentoDipsEspecial = False
        Me.boolDescuentoSocioEspecial = False
        Me.exbGuardarCliente.Visible = False

        bolIsNewFacturaInput = True
        FacturaGuardada = False
        bolNC = False
        FormasPago = Nothing

        grdDetalle.DataSource = Nothing
        dsDetalle = Nothing
        SiHay = New DataSet
        Me.Pedido = Nothing
        'Captura Manual
        'ALLOW
        Me.grdDetalle.Cols(0).AllowEditing = False
        ''
        boolManual = False

        oFactura.ClearFields()
        oFactura.CodTipoVenta = "P"
        'oFactura.ClienteId = IIf(oConfigCierreFI.UsarHuellas = True, 0, 1)
        oFactura.ClienteId = 0

        CreateTempData()

        Me.grdDetalle.AllowEditing = True

        oArticulo.ClearFields()
        ebClienteDescripcion.Text = ""
        ebPlayerDescripcion.Text = ""
        'Limpiar Campos Articulo
        ebCodigoArticulo.Text = ""
        ebDescripcionArticulo.Text = ""
        ebPorcentajeDscto.Value = 0
        ebMontoDscto.Value = 0
        ebPrecioArticulo.Value = 0
        ebTallaDel.Value = 0
        ebTallaAl.Value = 0
        ebExistencias.Value = 0
        ebFolioApartado.Value = 0
        Me.txtFolioVentaManual.Text = ""
        Me.chkVentaManual.Checked = False
        Me.chkPromoEspecial.Checked = False
        'Me.boolDescuentoDPakete = False 
        dgHeader.Enabled = True
        ebIVA.Visible = True
        ebSubTotal.Visible = True
        EbFolioSAP.Visible = False
        DPValeID = 0

        'Me.ebClienteDescripcion.Text = "PÚBLICO GENERAL"
        Me.ebClienteDescripcion.Text = ""
        ebTipoVenta.Focus()

        LoadFolioFactura()

        bolIsNewFacturaInput = False

        If (bolCloseForm = True) Then
            Me.Close()
        End If

        Me.UiCommandBar2.Commands("menuArchivoImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.False
        oNotaCreditoMgr = Nothing
        oNotaCredito = Nothing
        oValeCajaMgr = Nothing
        oValeCaja = Nothing
        If Not oCliente Is Nothing Then oCliente.Clear()
        '----------------------------------------------------------------------------------------------------------------------
        'Reseteamos el cronómetro
        '----------------------------------------------------------------------------------------------------------------------
        If Me.timer1.Enabled = True Then EjecutarCronometro(False)

        'Objeto Nota Credito
        'Fonacot Facilito change
        Try
            oNotaCreditoMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            oNotaCredito = oNotaCreditoMgr.Create


            'Objeto ValeCaja
            'Fonacot Facilito change
            oValeCajaMgr = New ValeCajaManager(oAppContext)
            oValeCaja = oValeCajaMgr.Create

        Catch ex As Exception

        End Try

        Me.nebTotalPiezas.Value = 0
        Me.txtCorrida.Text = ""

        Me.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        oFactura.SerialId = Me.SerialId

    End Sub

    Private Sub LoadFolioFactura()

        Dim oCajaMgr As CatalogoCajaManager
        Dim oCaja As Caja

        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCaja = oCajaMgr.Create

        oCaja = oCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja)

        oFactura.FolioFactura = oCaja.FolioFactura

        oCaja = Nothing

        oCajaMgr = Nothing


        Dim oDG As New CambiarFolioFacturaDataGateway(oAppContext)

        'If (oDG.ValidarFolio(oFactura.FolioFactura) = True) Then

        '    MsgBox("El Folio Actual ya se encuentra usado.", MsgBoxStyle.Exclamation, "DPTienda")

        '    Dim frmCambiarFolio As New frmCambiarFolio
        '    frmCambiarFolio.Show()

        '    'Me.Close()
        '    bolCloseForm = True

        'End If

        oDG = Nothing

    End Sub

    Private Function LoadSearchArticulo() As String

        Dim cArticulo As String
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If oOpenRecordDlg.pbCodigo = String.Empty Then

                cArticulo = oOpenRecordDlg.Record.Item("CodArtProv")
                Me.CodArticulo = oOpenRecordDlg.Record.Item("Código")
                'str = str & cArticulo
                'str = Mid(str, str.Length - 13)
            Else

                cArticulo = oOpenRecordDlg.Record.Item("CodArtProv")
                Me.CodArticulo = oOpenRecordDlg.Record.Item("Código")
                'str = str & cArticulo
                'str = Mid(str, str.Length - 13)
            End If

        Else

            cArticulo = ""
            str = ""

        End If

        oOpenRecordDlg.Dispose()
        oOpenRecordDlg = Nothing

        Return cArticulo

    End Function

    Private Sub FormateaGrid()

        grdDetalle.Cols(0).Visible = False
        grdDetalle.Cols(1).Width = 185
        grdDetalle.Cols(2).Visible = False
        grdDetalle.Cols(3).Width = 57
        grdDetalle.Cols(3).Format = "##0.0"
        grdDetalle.Cols(4).Width = 63
        grdDetalle.Cols(4).Format = "##0"
        grdDetalle.Cols(5).Width = 80
        grdDetalle.Cols(5).Format = "$ ###,##0.00"
        grdDetalle.Cols(5).AllowEditing = False
        grdDetalle.Cols(6).Visible = False
        '''grdDetalle.Cols(6).Width = 80
        '''grdDetalle.Cols(6).Format = "$ ###,##0.00"
        grdDetalle.Cols(7).AllowEditing = False
        grdDetalle.Cols(7).Format = "$ ###,##0.00"
        grdDetalle.Cols(7).Width = 80
        grdDetalle.Cols(8).Format = "##0.00"
        grdDetalle.Cols(8).Width = 80
        grdDetalle.Cols(9).Width = 80
        grdDetalle.Cols(9).Format = "##0.00"
        grdDetalle.Cols(9).AllowEditing = False

    End Sub

    'Private Sub ActualizaCalculos()

    '    Dim oRow As DataRow
    '    Dim vTotalGeneral As Double
    '    Dim vSubTotal As Decimal = 0
    '    Dim vDscto As Decimal = 0
    '    Dim vDsctoAdicional As Decimal = 0
    '    Dim vIVA As Decimal = 0


    '    '--Flag Descuento Adicional
    '    vSaldarDescuentoAdicional = 0
    '    vDescuentoAdicional = 0
    '    '--End Flag

    '    For Each oRow In dsDetalle.Tables(0).Rows
    '        vDscto = vDscto + oRow("Descuento")
    '        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
    '            If oFactura.CodTipoVenta = "S" Then
    '                If oRow("Descuento") > 0 Then
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + oRow("Total")
    '                Else
    '                    'AQUI NO HAY PEDO NO HAY DESCUENTO
    '                    'vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") / 0.75) * ((oRow("Adicional") + 25) / 100), 2)
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + (oRow("Total"))
    '                End If
    '            Else
    '                If oRow("Descuento") > 0 Then
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + oRow("Total")
    '                Else
    '                    'AQUI NO HAY PEDO NO HAY DESCUENTO
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + (oRow("Total"))
    '                End If
    '            End If
    '        Else
    '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '            vSubTotal = vSubTotal + oRow("Total")
    '        End If
    '    Next
    '    oFactura.DescTotal = vDscto + vDsctoAdicional

    '    If oAppContext.ApplicationConfiguration.Almacen = "053" Then
    '        vDescuentoAdicional = vSaldarDescuentoAdicional
    '    Else
    '        vDescuentoAdicional = vDsctoAdicional
    '    End If

    '    vSubTotal = vSubTotal - oFactura.DescTotal
    '    oFactura.SubTotal = vSubTotal

    '    oFactura.IVA = oFactura.SubTotal * oAppContext.ApplicationConfiguration.IVA
    '    oFactura.Total = Decimal.Round(oFactura.SubTotal + oFactura.IVA, 2)
    '    'ver que ondas con el IVA
    '    If oFactura.CodTipoVenta = "P" Or oFactura.CodTipoVenta = "V" Then
    '        oFactura.DescTotal = Math.Round(oFactura.DescTotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
    '    End If

    'End Sub

    'Public Sub ActualizaCalculos()

    '    Dim oRow As DataRow
    '    Dim vTotalGeneral As Decimal = 0
    '    Dim vSubTotal As Decimal = 0
    '    Dim vDscto As Decimal = 0
    '    Dim vDsctoAdicional As Decimal = 0
    '    Dim vIVA As Decimal = 0
    '    Dim vDsctoUnit As Decimal = 0, vDsctoAdiUnit As Decimal = 0, vImporte As Decimal = 0


    '    '--Flag Descuento Adicional
    '    vSaldarDescuentoAdicional = 0
    '    vDescuentoAdicional = 0
    '    '--End Flag
    '    '----------------------------------------------------------------------------------------------------------------------------------
    '    'RGERMAIN 01.07.2015: Se modifica el calculo de precios para que el detalle de la factura cuadre exactamente igual al total sin
    '    '                     diferencia de centavos
    '    '----------------------------------------------------------------------------------------------------------------------------------
    '    For Each oRow In dsDetalle.Tables(0).Rows
    '        vDscto = vDscto + oRow("Descuento")
    '        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
    '            If oFactura.CodTipoVenta = "S" Then
    '                If oRow("Descuento") > 0 Then
    '                    'If EntroPromocionDosPorUnoYMedio(idx) Then 
    '                    '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Importe") - oRow("Descuento") / oRow("Cantidad")) * (oRow("Adicional") / 100), 2)
    '                    'Else
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '                    'End If
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + oRow("Total")
    '                Else
    '                    'AQUI NO HAY PEDO NO HAY DESCUENTO
    '                    'vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") / 0.75) * ((oRow("Adicional") + 25) / 100), 2)
    '                    'If EntroPromocionDosPorUnoYMedio(idx) Then 
    '                    '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Importe")) * ((oRow("Adicional")) / 100), 2)
    '                    'Else
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
    '                    'End If
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + (oRow("Total"))
    '                End If
    '            Else
    '                If oRow("Descuento") > 0 Then
    '                    'If EntroPromocionDosPorUnoYMedio(idx) Then 
    '                    '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Importe") - oRow("Descuento") / oRow("Cantidad")) * (oRow("Adicional") / 100), 2)
    '                    'Else
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '                    'End If
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + oRow("Total")
    '                Else
    '                    'AQUI NO HAY PEDO NO HAY DESCUENTO
    '                    'If EntroPromocionDosPorUnoYMedio(idx) Then 
    '                    '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Importe")) * ((oRow("Adicional")) / 100), 2)
    '                    'Else
    '                    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
    '                    'End If
    '                    vSaldarDescuentoAdicional += oRow("Adicional")
    '                    vSubTotal = vSubTotal + (oRow("Total"))
    '                End If
    '            End If
    '        Else

    '            'If EntroPromocionDosPorUnoYMedio(idx) Then
    '            '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Importe") - oRow("Descuento") / oRow("Cantidad")) * (oRow("Adicional") / 100), 2)
    '            'Else
    '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
    '            'End If
    '            vSubTotal = vSubTotal + oRow("Total")
    '        End If
    '        'idx += 1 'Comentar en caso de no liberar
    '    Next
    '    oFactura.DescTotal = vDscto + vDsctoAdicional

    '    If oAppContext.ApplicationConfiguration.Almacen = "053" Then
    '        vDescuentoAdicional = vSaldarDescuentoAdicional
    '    Else
    '        vDescuentoAdicional = vDsctoAdicional
    '    End If

    '    vSubTotal = vSubTotal - oFactura.DescTotal
    '    oFactura.SubTotal = vSubTotal

    '    oFactura.IVA = oFactura.SubTotal * oAppContext.ApplicationConfiguration.IVA
    '    oFactura.Total = Decimal.Round(oFactura.SubTotal + oFactura.IVA, 2)
    '    'ver que ondas con el IVA
    '    If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "V" OrElse oFactura.CodTipoVenta = "E" Then
    '        oFactura.DescTotal = Math.Round(oFactura.DescTotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
    '    End If
    '    'Calculamos el total de piezas que van en el detalle de la factura
    '    Me.nebTotalPiezas.Value = IIf(IsDBNull(dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")), 0, dsDetalle.Tables(0).Compute("SUM(Cantidad)", ""))
    'End Sub

    Public Sub ActualizaCalculos()

        Dim oRow As DataRow
        Dim vTotalGeneral As Decimal = 0
        Dim vSubTotal As Decimal = 0
        Dim vDscto As Decimal = 0
        Dim vDsctoAdicional As Decimal = 0
        Dim vIVA As Decimal = 0
        Dim vDsctoUnit As Decimal = 0, vDsctoAdiUnit As Decimal = 0, vImporte As Decimal = 0
        'Dim idx As Integer = 0 

        '--Flag Descuento Adicional
        vSaldarDescuentoAdicional = 0
        vDescuentoAdicional = 0
        '--End Flag
        '----------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 01.07.2015: Se modifica el calculo de precios para que el detalle de la factura cuadre exactamente igual al total sin
        '                     diferencia de centavos
        '----------------------------------------------------------------------------------------------------------------------------------
        If dsDetalle.Tables(0).Rows.Count > 0 AndAlso CStr(dsDetalle.Tables(0).Rows(0)!Codigo).Trim <> "" Then
            For Each oRow In dsDetalle.Tables(0).Rows
                'Obtenemos el descuento total del producto
                vDscto += oRow("Descuento")
                'Calculamos el descuento por sistema que le toca a cada pieza del producto
                vDsctoUnit = oRow("Descuento") / oRow("Cantidad")
                'If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                '    If oFactura.CodTipoVenta = "S" Then
                '        If oRow("Descuento") > 0 Then
                '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
                '            vSaldarDescuentoAdicional += oRow("Adicional")
                '            vSubTotal = vSubTotal + oRow("Total")
                '        Else
                '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
                '            vSaldarDescuentoAdicional += oRow("Adicional")
                '            vSubTotal = vSubTotal + (oRow("Total"))
                '        End If
                '    Else
                '        If oRow("Descuento") > 0 Then
                '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
                '            vSaldarDescuentoAdicional += oRow("Adicional")
                '            vSubTotal = vSubTotal + oRow("Total")
                '        Else
                '            vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total")) * ((oRow("Adicional")) / 100), 2)
                '            vSaldarDescuentoAdicional += oRow("Adicional")
                '            vSubTotal = vSubTotal + (oRow("Total"))
                '        End If
                '    End If
                'Else
                '    vDsctoAdicional = vDsctoAdicional + Decimal.Round((oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100), 2)
                '    vSubTotal = vSubTotal + oRow("Total")
                'End If
                vSaldarDescuentoAdicional += oRow("Adicional")
                'Calculamos el descuento adicional que le corresponde a cada pieza del producto
                vDsctoAdiUnit = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                vDsctoAdiUnit = vDsctoAdiUnit / oRow("Cantidad")
                'Calculamos el descuento adicional total del producto
                vDsctoAdicional += vDsctoAdiUnit
                'Calculamos el importe unitario de cada pieza del producto restando los descuentos
                vImporte = oRow("Importe") - vDsctoUnit - vDsctoAdiUnit
                'Le aumentamos el iva al precio unitario
                vImporte = Decimal.Round(vImporte * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                'Sumamos al importe total de la factura el total de este producto ya con los descuentos restados y el iva aumentado
                vTotalGeneral = vTotalGeneral + (vImporte * oRow("Cantidad"))

            Next
        End If

        oFactura.DescTotal = vDscto + vDsctoAdicional

        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
            vDescuentoAdicional = vSaldarDescuentoAdicional
        Else
            vDescuentoAdicional = vDsctoAdicional
        End If

        'vSubTotal = vSubTotal - oFactura.DescTotal
        oFactura.Total = vTotalGeneral
        oFactura.SubTotal = Decimal.Round(vTotalGeneral / (1 + oAppContext.ApplicationConfiguration.IVA), 2)
        oFactura.IVA = Decimal.Round(oFactura.SubTotal * oAppContext.ApplicationConfiguration.IVA, 2)

        'oFactura.SubTotal = vSubTotal
        'oFactura.IVA = Math.Round(oFactura.SubTotal * oAppContext.ApplicationConfiguration.IVA, 2)
        'oFactura.Total = Decimal.Round(oFactura.SubTotal + oFactura.IVA, 2)

        '-----------------------------------------------------------------------------------------
        ' JNAVA 25.06.2015: quitamos redondeo por problemas de centavos y truncamos
        '-----------------------------------------------------------------------------------------
        'ver que ondas con el IVA
        If oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "V" OrElse oFactura.CodTipoVenta = "E" Then
            'oFactura.DescTotal = Math.Round(oFactura.DescTotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
            oFactura.DescTotal = Decimal.Round(oFactura.DescTotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
            'oFactura.DescTotal = Truncar(oFactura.DescTotal * (oAppContext.ApplicationConfiguration.IVA + 1), 2)
        End If

        'Calculamos el total de piezas que van en el detalle de la factura
        Me.nebTotalPiezas.Value = IIf(IsDBNull(dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")), 0, dsDetalle.Tables(0).Compute("SUM(Cantidad)", ""))

    End Sub

    Private Function AplicaDescuentoAsociado(ByVal CantidadCompra As Decimal, ByVal strCodigo As String, ByVal oImporte As Decimal) As Decimal

        Dim oDsctoAsociado As Decimal = 0
        Dim oArticuloVal As Articulo
        Dim oDsctoOferteo As Decimal = 0

        oArticuloVal = oArticuloMgr.Create
        oArticuloVal.ClearFields()

        oArticuloMgr.LoadInto(strCodigo, oArticuloVal)

        oDsctoOferteo = CargaCondicionVenta(oArticuloVal).DescPorcentaje

        If oArticuloVal.Dip Then      '-- Implementar
            If CantidadCompra <= 3 Then
                oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosDIP * 100)
                'If oDsctoOferteo <= 0 Then
                '    oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosDIP * 100)
                'Else
                '    If oDsctoOferteo >= (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosDIP * 100) Then
                '        oDsctoAsociado = 0
                '    Else
                '        oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosDIP * 100) - oDsctoOferteo
                '    End If
                'End If
            Else
                oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasDIP * 100)
                'If oDsctoOferteo <= 0 Then
                '    oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasDIP * 100)
                'Else
                '    If oDsctoOferteo >= (oAppContext.ApplicationConfiguration.DsctoCompra3MasDIP * 100) Then
                '        oDsctoAsociado = 0
                '    Else
                '        oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasDIP * 100) - oDsctoOferteo
                '    End If
                'End If
            End If
        Else
            If CantidadCompra <= 3 Then
                oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosNoDIP * 100)
                'If oDsctoOferteo <= 0 Then
                '    oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosNoDIP * 100)
                'Else
                '    If oDsctoOferteo >= (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosNoDIP * 100) Then
                '        oDsctoAsociado = 0
                '    Else
                '        oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3oMenosNoDIP * 100) - oDsctoOferteo
                '    End If
                'End If
            Else
                oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasNoDIP * 100)
                'If oDsctoOferteo <= 0 Then
                '    oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasNoDIP * 100)
                'Else
                '    If oDsctoOferteo >= (oAppContext.ApplicationConfiguration.DsctoCompra3MasNoDIP * 100) Then
                '        oDsctoAsociado = 0
                '    Else
                '        oDsctoAsociado = (oAppContext.ApplicationConfiguration.DsctoCompra3MasNoDIP * 100) - oDsctoOferteo
                '    End If
                'End If
            End If
        End If

        oArticuloVal = Nothing

        Return oDsctoAsociado

    End Function

    Private Function BuscaCodigoEnVenta(ByVal strCodigo As String, ByVal strTalla As String, ByVal nRowG As Integer) As Integer

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In dsDetalle.Tables(0).Rows

            nRow = nRow + 1

            If oRow("Codigo") = strCodigo And oRow("Talla") = strTalla And (nRow - 1) <> nRowG Then

                Return nRow

            End If

        Next

        Return 0

    End Function

#End Region

#Region "Instance Methods"

    Public Function ShowNC(ByVal NCID As Integer, _
                        ByVal MontoDPVale As Decimal, _
                        ByVal DPValeID As String, _
                        ByVal ClienteID As Decimal, _
                        ByVal Player As String)

        vNCInstance = True
        oDevolucionDPvale.NotaCreditoID = NCID
        oDevolucionDPvale.DPValeID = DPValeID
        oDevolucionDPvale.MontoDPVale = MontoDPVale
        oDevolucionDPvale.ClienteID = ClienteID
        oDevolucionDPvale.PlayerNC = Player

        Me.ShowDialog()

    End Function

    Private Sub LoadDataofNotaCredito()

        uICommandManager1.CommandBars(0).Enabled = False
        uICommandManager1.CommandBars(1).Enabled = False

        'como el TipoVta es Dpvale el Cliente es Pub. Gral.
        oFactura.ClienteId = 1
        ebClienteDescripcion.Text = "PÚBLICO GENERAL"
        ebClienteID.Enabled = False

        'Mostramos Player
        ebCodVendedor.Text = oDevolucionDPvale.PlayerNC
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
        ebPlayerDescripcion.Text = oVendedor.Nombre
        oFactura.CodVendedor = oVendedor.ID

        oFactura.CodTipoVenta = "V"
        ebTipoVenta.Enabled = False

    End Sub

    Public Function ShowApartado(ByVal oContrato As Contrato)

        'Objeto Contrato
        oContratoMgr = New ContratoManager(oAppContext)
        oContratoInfo = oContratoMgr.Create

        oContratoInfo = oContrato

        vApartadoInstance = True

        Me.ShowDialog()

    End Function

    Private Sub LoadDataofApartado()

        uICommandManager1.CommandBars(0).Enabled = False
        uICommandManager1.CommandBars(1).Enabled = False

        'oFactura.CodTipoVenta = "P"
        oFactura.CodTipoVenta = "A"
        ebTipoVenta.Enabled = False

        ebCodVendedor.Text = oContratoInfo.PlayerID
        ebCodVendedor.Enabled = False
        btnAltaCliente.Enabled = False

        'Mostramos Player
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
        ebPlayerDescripcion.Text = oVendedor.Nombre
        oFactura.CodVendedor = oVendedor.ID

        'Mostramos Cliente
        ebClienteID.Value = CInt(oContratoInfo.ClienteID)
        If oContratoInfo.ClienteID = 1 Then

            ebClienteDescripcion.Text = "PÚBLICO GENERAL"

        Else

            ebClienteID.Enabled = False
            oCliente.Clear()
            oClienteMgr.Load(oContratoInfo.ClienteID, oCliente, "I")     '--Los ctes. de Apartados estan en el rango de Fiscal
            ebClienteDescripcion.Text = oCliente.NombreCompleto
            oFactura.ClienteId = CInt(oCliente.CodigoAlterno)

        End If

        'Llenamos el Grid con el Detalle del Apartado
        Dim oRowContrato As DataRow, oRowGrid As DataRow
        For Each oRowContrato In oContratoInfo.Detalle.Tables(0).Rows

            oRowGrid = dsDetalle.Tables(0).NewRow()

            With oRowGrid
                .Item("Codigo") = oRowContrato("CodArticulo")
                .Item("Talla") = oRowContrato("Numero")
                .Item("Cantidad") = oRowContrato("Cantidad")
                .Item("Importe") = oRowContrato("Precio")
                .Item("Total") = oRowContrato("Importe")
                .Item("Descuento") = (oRowContrato("Precio") * oRowContrato("Cantidad")) _
                                     * (oRowContrato("Descuento") / 100) '0
                .Item("Adicional") = 0 'oRowContrato("Descuento")
            End With

            dsDetalle.Tables(0).Rows.Add(oRowGrid)

        Next
        dsDetalle.AcceptChanges()

        oFactura.DescTotal = oContratoInfo.DescuentoTotal
        oFactura.Total = oContratoInfo.ImporteTotal
        oFactura.IVA = oContratoInfo.IVA
        oFactura.SubTotal = oFactura.Total - oFactura.IVA
        Me.nebTotalPiezas.Value = IIf(IsDBNull(dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")), 0, dsDetalle.Tables(0).Compute("SUM(Cantidad)", ""))
        oFactura.ApartadoID = oContratoInfo.ID
        ebFolioApartado.Value = oContratoInfo.FolioApartado

        'Fecha de Contrato Para Determinacion de Precios en SAP
        '18.10.2007
        oFactura.FechaApartado = Format(oContratoInfo.Fecha, "dd.MM.yyyy")
        'Bloqueamos Grid
        grdDetalle.Cols(0).AllowEditing = False
        grdDetalle.Cols(1).AllowEditing = False
        grdDetalle.Cols(2).AllowEditing = False
        grdDetalle.Cols(3).AllowEditing = False
        grdDetalle.Cols(4).AllowEditing = False
        grdDetalle.Cols(5).AllowEditing = False
        grdDetalle.Cols(6).AllowEditing = False

        btnFormaPago.Focus()

    End Sub

#End Region

#Region "APIs"
    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As System.IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function ShowWindow(ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function SetForegroundWindow(ByVal hWnd As System.IntPtr) As Boolean
    End Function
#End Region

#End Region

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/12/2016: Variables de código proveedor
    '-------------------------------------------------------------------------------------------------------------------------------
#Region "Codigo Proveedor"

    Private CodPadreArticulo As String = ""
    Private CodArticuloPopup As String = ""

#End Region


    Private Sub frmFacturacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.vNCInstance AndAlso Not vNCFacturada Then
            If MessageBox.Show("Desea mandar imprimir el ReVale", "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim ofrmPago As New frmPago

                ofrmPago.InitializeObjects()
                ofrmPago.InitializeObjectsSAP()
                ofrmPago.owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
                ofrmPago.owsDPValeInfo.MontoDPValeI = Me.oDevolucionDPvale.MontoDPVale

                Dim oDPVale As New cDPVale
                oDPVale.INUMVA = CStr(Me.oDevolucionDPvale.DPValeID).PadLeft(10, "0")

                'Dim oConURed As New MontarUnidadRed.cMontaUnidadRed(oConfigCierreFI.Password, oConfigCierreFI.Usuario, oConfigCierreFI.Unidad, oConfigCierreFI.Ruta)
                'oConURed.Conecta()

                'If Not Directory.Exists(oConfigCierreFI.Ruta & "\Firmas") Then
                '    Directory.CreateDirectory(oConfigCierreFI.Ruta & "\Firmas")
                'Else
                '    'Obtener la lista de todos los archivos
                '    Dim strFiles() As String = Directory.GetFileSystemEntries(oConfigCierreFI.Ruta & "\Firmas\", "*.BMP")

                '    For Each strFile As String In strFiles
                '        If Now.AddDays(-1).ToShortDateString = File.GetCreationTime(strFile).ToShortDateString Then
                '            If File.Exists(strFile) Then File.Delete(strFile)
                '        End If
                '    Next

                'End If


                'oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(oDevolucionDPvale.DPValeID).PadLeft(10, "0") & ".bmp"

                'If File.Exists(oDPVale.I_RUTA) Then
                oDPVale.I_RUTA = "X"
                'End If

                '----------------------------------------------------------------------------------------
                ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                '----------------------------------------------------------------------------------------
                'oDPVale = ofrmPago.oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                '----------------------------------------------------------------------------------------
                ' JNAVA (15.07.2016): Valida DPVale
                '----------------------------------------------------------------------------------------
                Dim FirmaDistribuidor As Image = Nothing
                Dim NombreDistribuidor As String = String.Empty
                If oConfigCierreFI.AplicarS2Credit Then
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                Else
                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                End If
                '----------------------------------------------------------------------------------------

                'oConURed.Desconecta()
                'oConURed.Desconecta()

                'oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(oDevolucionDPvale.DPValeID).PadLeft(10, "0") & ".bmp"

                Dim oRow As DataRow
                oRow = oDPVale.InfoDPVALE.Rows(0)
                Dim DPValeInfo As New DevolucionDPValeInfo()
                DPValeInfo.DPValeOrigen = oRow("Orige")
                DPValeInfo.FechaExpedicion = Now
                DPValeInfo.FechaEntregado = Now
                DPValeInfo.FacturaId = 0
                DPValeInfo.MontoDPValeUtilizado = 0
                DPValeInfo.MontoDPValeP = 0
                DPValeInfo.DPValeID = Me.oDevolucionDPvale.DPValeID
                DPValeInfo.AsociadoID = oRow("KUNNR")
                DPValeInfo.ClienteAsociadoID = oRow("CODCT")

                'ofrmPago.owsDPValeInfo.DPValeOrigen = oRow("Orige")
                ofrmPago.owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
                ofrmPago.owsDPValeInfo.FechaEntregado = Now.ToShortDateString
                ofrmPago.owsDPValeInfo.FacturaID = 0
                ofrmPago.owsDPValeInfo.MontoUtilizado = 0
                ofrmPago.owsDPValeInfo.MontoDPValeP = 0
                ofrmPago.vSobrante = Me.oDevolucionDPvale.MontoDPVale
                ofrmPago.owsDPValeInfo.DPValeID = Me.oDevolucionDPvale.DPValeID
                ofrmPago.owsDPValeInfo.AsociadoID = oRow("KUNNR")
                ofrmPago.owsDPValeInfo.ClienteAsociadoID = oRow("CODCT")

                ofrmPago.PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
                ofrmPago.Dispose()
                ofrmPago = Nothing

            End If

        ElseIf FacturaGuardada = False AndAlso Not Me.FormasPago Is Nothing Then

            For Each oRow As DataRow In Me.FormasPago.Rows

                If orow!CodTipoTarjeta = "TE" Then

                    MsgBox("Es necesario guardar la factura", MsgBoxStyle.Exclamation, "Dportenis Pro")
                    e.Cancel = True
                    Exit For

                End If
            Next
        End If
        timer1.Close()
        timer1.Dispose()
    End Sub

    Private Sub ebClienteID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.GotFocus

        If oConfigCierreFI.UsarHuellas = True Then
            'If Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False Then
            '    Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True
            'End If
        End If

    End Sub

    Private Sub ProcesoBusquedaClienteCRM()

        If Not oCliente Is Nothing Then oCliente.Clear()
        'Mostrar el cuadro de busqueda manual del cliente
        If oConfigCierreFI.UsarDescargaClientes Then
            LoadSearchFormCliente()
        Else
            LoadSearchFormClientesSAP()
        End If

        If oCliente Is Nothing OrElse oCliente.CodigoAlterno.Trim = "" OrElse CDbl(oCliente.CodigoAlterno) <= 0 Then ebClienteID_Validating(Nothing, Nothing)

        If oCliente Is Nothing OrElse oCliente.CodigoAlterno.Trim = "" OrElse CDbl(oCliente.CodigoAlterno) <= 0 Then
            If MessageBox.Show("¿Deseas dar de alta al cliente en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                AltadeCliente()
            Else
                Me.ebClienteID.Focus()
            End If
        End If

    End Sub


    Private Sub grdDetalle_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdDetalle.AfterEdit

        Me.grdDetalle.Cols(6).AllowEditing = False

    End Sub

#Region "Notas Ventas Manuales"

    Private Sub chkVentaManual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVentaManual.CheckedChanged
        If Me.chkVentaManual.Checked = True Then
            Me.txtFolioVentaManual.Visible = True
            Dim oForm As New frmShowFolioToUser
            Dim FolioToShow As Integer
            FolioToShow = CargarFolioNext()
            If FolioToShow = 0 Then
                MessageBox.Show("Se han acabado los folios almacenados para Notas de Venta Manuales." & vbCrLf & " Pongase en contacto con su Auditor de Plaza.", "Auditoria Dportenis.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.chkVentaManual.Checked = False
                Me.txtFolioVentaManual.Text = ""
                Exit Sub
            Else
                Me.txtFolioVentaManual.Focus()
                oForm.Show()
            End If

        Else
            Me.txtFolioVentaManual.Text = ""
            Me.txtFolioVentaManual.Visible = False
        End If
    End Sub
    Private Function CargarFolioNext() As Integer
        Dim FolioNext As Integer
        FolioNext = oFacturaMgr.CargarFolioNext

        Me.txtFolioVentaManual.Text = FolioNext
        Return FolioNext


    End Function
#End Region

    Private Sub chkPromoEspecial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPromoEspecial.CheckedChanged
        AplicarPromociones()
        'If Me.chkPromoEspecial.Checked = False Then
        '    AplicaPromocionesVigentes()
        'End If

    End Sub

    Private Sub timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer1.Elapsed

        Me.lblCronometro.Text = Format(CDate(Me.lblCronometro.Text).AddSeconds(1), "HH : mm : ss")

    End Sub

    Private Sub MostrarCronometro()

        Me.ebClienteDescripcion.Width = 264
        Me.lblCronometro.Visible = True

    End Sub

    Private Sub EjecutarCronometro(ByVal bStart As Boolean)

        If bStart Then
            Me.timer1.Start()
        Else
            Me.timer1.Stop()
            Me.lblCronometro.Text = "00 : 00 : 00"
        End If

    End Sub

#Region "Metodos Form Grid Janus"
    
#End Region

#Region "Metodos Grid Janus"

    Private Sub ActualizaDatosArticuloJanus(ByVal codigo As String) ', ByVal talla As String)

        oArticulo.ClearFields()

        oArticuloMgr.LoadInto(codigo, oArticulo)

        oFactura.FacturaArticuloExistencia = 0

        '--oArticulo.Descuento = oArticulo.Descuento / 100

        FillTallasArticulo(oArticulo.CodCorrida)

        '--Obtenemos Tallas del Artículo
        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

        '--Obtenemos Existencia
        oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, "", oFactura)

        'oArticulo.PrecioVenta = Decimal.Round(oArticulo.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA), 2)

        'Sacamos el precio real del articulo con descuento C053 Incluido.


        If oAppContext.ApplicationConfiguration.Almacen = "053" Then 'Tienda C1
            If oFactura.CodTipoVenta = "S" Then 'Ventas Socios 25% Descuento
                oArticulo.PrecioVenta = oArticulo.PrecioSocio
                ebPrecioArticulo.Value = (oArticulo.PrecioVenta / 0.75) * (1 + oAppContext.ApplicationConfiguration.IVA) 'Correccion por cambio Faamework (JNAVA - 06/11/2015)
                ebPrecioArticulo.Value = Decimal.Round(ebPrecioArticulo.Value, 2)
            Else 'Ventas 10% Descuento.
                ebPrecioArticulo.Value = (oArticulo.PrecioVenta / 0.9) * (1 + oAppContext.ApplicationConfiguration.IVA)
                ebPrecioArticulo.Value = Decimal.Round(ebPrecioArticulo.Value, 2)
            End If
        Else 'Tiendas T1
            ebPrecioArticulo.Value = Decimal.Round(oArticulo.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
        End If


        '--Cargamos Condicion de Venta
        oCondicionVenta = CargaCondicionVenta(oArticulo)
        If oCondicionVenta.DescPorcentaje > 0 Then
            If oAppContext.ApplicationConfiguration.Almacen = "053" Then 'Vemos si la condicion es mayor al descuento C1 o C2
                'If oFactura.CodTipoVenta = "S" Then
                '    If oCondicionVenta.DescPorcentaje > 25 Then
                '        oArticulo.PrecioVenta = oArticulo.PrecioIva / 1.15
                '        ebPrecioArticulo.Value = Decimal.Round((oArticulo.PrecioVenta) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                '        ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
                '    Else
                '        ebPorcentajeDscto.Value = 0
                '        ebMontoDscto.Value = 0
                '    End If
                'Else
                '    If oCondicionVenta.DescPorcentaje > 10 Then
                '        oArticulo.PrecioVenta = oArticulo.PrecioIva / 1.15
                '        ebPrecioArticulo.Value = Decimal.Round((oArticulo.PrecioVenta) * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                '        ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
                '    Else
                '        ebPorcentajeDscto.Value = 0
                '        ebMontoDscto.Value = 0
                '    End If
                'End If
                ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
            Else
                ebPorcentajeDscto.Value = oCondicionVenta.DescPorcentaje / 100
            End If
        ElseIf oCondicionVenta.Descmonto > 0 Then 'Ya no Aplica.
            ebMontoDscto.Value = oCondicionVenta.Descmonto
        Else
            ebPorcentajeDscto.Value = 0
            ebMontoDscto.Value = 0
        End If

    End Sub

    Private Function ValidateRowGridJanus(ByVal gRow As Integer) As Boolean

        On Error GoTo EscapeLongHorn

        Dim mMensaje As String = ""
        Dim row As GridEXRow = dgHeader.GetRow(gRow)
        If gRow >= 0 Then

            If CStr(row.Cells(0).Value) = "" Then

                mMensaje = mMensaje + " CODIGO" + vbCrLf

            End If

            If CStr(row.Cells(1).Value) = "" Then

                mMensaje = mMensaje + " TALLA" + vbCrLf

            End If

            If CDec(row.Cells(2).Value) = 0 Then

                mMensaje = mMensaje + " CANTIDAD" + vbCrLf

            End If

            If mMensaje <> "" Then

                MsgBox("Los siguientes datos no son correctos. " & vbCrLf & vbCrLf & mMensaje, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "   Facturación")

                Return False

            Else

                Return True

            End If

        End If

EscapeLongHorn:

        Exit Function

    End Function

    Private Sub LimpiaDatosGridJanus(ByVal oRow As Integer)

        oFactura.DescTotal = 0
        oFactura.Total = 0
        oFactura.SubTotal = 0
        oFactura.IVA = 0
        oArticulo.CodCorrida = String.Empty
        oArticulo.CodArticulo = String.Empty
        oArticulo.Descripcion = String.Empty
        txtCorrida.Text = String.Empty
        ebPorcentajeDscto.Text = String.Empty
        oArticulo.Descuento = 0
        oArticulo.PrecioOferta = 0
        ebPrecioArticulo.Value = 0
        oFactura.FacturaArticuloExistencia = 0
        oFactura.FacturaArticuloTallaAl = 0
        oFactura.FacturaArticuloTallaDel = 0
        dgHeader.GetRow(oRow).Cells(0).Value = ""
        dgHeader.GetRow(oRow).Cells(1).Value = ""
        dgHeader.GetRow(oRow).Cells(2).Value = 0
        dgHeader.GetRow(oRow).Cells(3).Value = 0
        dgHeader.GetRow(oRow).Cells(4).Value = 0
        dgHeader.GetRow(oRow).Cells(5).Value = 0
        dgHeader.GetRow(oRow).Cells(6).Value = 0

    End Sub
#End Region

    Private Sub dgHeader2_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles dgHeader.UpdatingCell
        If e.Column.Index = 3 Then
            'If CDec(e.Value) <> 0 Then
            e.Value = IIf(e.Value <= 0, 1, e.Value)
            Dim row As DataRow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
            '--Aplicamos Descuento si lo tuviera
            Dim descuento As Decimal = 0
            Dim total As Decimal = CDec(e.Value) * CDec(row("Importe"))
            If ebPorcentajeDscto.Value > 0 Then
                descuento = Decimal.Round(CDec(total) * ebPorcentajeDscto.Value, 2)
            Else
                descuento = Decimal.Round(CDec(e.Value) * ebMontoDscto.Value, 2)
            End If

            row("Cantidad") = e.Value
            If CInt(e.Value) > CInt(ebExistencias.Value) Then
                row("ConExistencia") = CInt(ebExistencias.Value)
                row("SinExistencia") = CInt(e.Value) - CInt(ebExistencias.Value)
            Else
                row("ConExistencia") = CInt(e.Value)
                row("SinExistencia") = 0
            End If
            row("Total") = total
            row("Descuento") = descuento
            row.AcceptChanges()
            dsDetalle.Tables(0).AcceptChanges()
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
            Dim TotalAPagarDip As Decimal = 0
            Dim TotalAPagarPromo As Decimal = 0
            TotalAPagarDip = oFactura.Total
            AplicarPromociones()
            TotalAPagarPromo = oFactura.Total
            If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo Then
                If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                    AplicaDescuentosDips()
                Else
                    AplicaDescuentosDips()
                    'NuevosDescuentosDips()
                End If
            End If
            VerificaCondicionDescuento(dsDetalle.Tables(0))
            ActualizaCalculos()
            'End If
        ElseIf e.Column.Index = 6 Then
            If CDec(e.Value) <= 0 Then
                e.Value = 0
                ActualizaCalculos()
                Exit Sub
            ElseIf ((CDec(e.Value) + (ebPorcentajeDscto.Value * 100)) > (oAppContext.ApplicationConfiguration.Descuento * 100)) Or (e.Value < 0) Then
                e.Value = 0
                ActualizaCalculos()
            End If
            Dim renglon As DataRow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
            renglon("Adicional") = e.Value
            renglon.AcceptChanges()
            dsDetalle.Tables(0).AcceptChanges()
            Dim TotalAPagarDip As Decimal = 0
            Dim TotalAPagarPromo As Decimal = 0
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
            TotalAPagarDip = oFactura.Total
            AplicarPromociones()
            TotalAPagarPromo = oFactura.Total
            If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo Then
                If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                    AplicaDescuentosDips()
                Else
                    AplicaDescuentosDips()
                    'NuevosDescuentosDips()
                End If
            End If
            VerificaCondicionDescuento(dsDetalle.Tables(0))
            ActualizaCalculos()
            boolDescuentoDipsEspecial = False
            boolDescuentoSocioEspecial = False
            dgHeader.Tables(0).Columns("Adicional").EditType = EditType.NoEdit
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPopupCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPopupCodigo.KeyDown
        Select Case e.KeyCode
            Case e.Alt And Keys.S
                'If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                boolManual = True
                txtPopupCodigo.ReadOnly = True
                txtPopupCodigo.Text = LoadSearchArticulo()
                txtCantidad.Focus()
                ' SendKeys.Send("{ENTER}")
                'Else
                '    boolManual = False
                'End If
                'oAppContext.Security.CloseImpersonatedSession()
                'Case Keys.F2
                '    If modificar = False Then
                '        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                '            txtPopupCodigo.Text = ""
                '            txtPopupCodigo.ReadOnly = False
                '            txtPopupTalla.Text = ""
                '            txtCantidad.Text = ""
                '            txtPopupImporte.Text = ""
                '            txtPopupTotal.Text = ""
                '            txtPopupDescuento.Text = ""
                '            txtPopupAdicional.Text = ""
                '            boolManual = True
                '        Else
                '            boolManual = False
                '        End If
                '        oAppContext.Security.CloseImpersonatedSession()
                '    End If
            Case Keys.Enter
                Me.txtCantidad.Focus()
                'CargarCodigo()
        End Select
    End Sub

    Private Sub CargarCodigoSH(ByVal codArticulo As String)
        oFacturaMgr.GetExistenciaArticulo(codArticulo, oFactura.CodAlmacen, txtPopupTalla.Text.Trim(), oFactura)
        
        'MOTIVOS Captura Manual
        'Validar que este en modo de captura manual
        'Se cambia la talla del material si es accesorio o textil
        ActualizaDatosArticuloJanus(txtPopupCodigo.Text.Trim()) ', txtPopupTalla.Text.Trim())
        If oArticulo.CodCorrida = "ACC" OrElse oArticulo.CodCorrida = "TEX" OrElse oArticulo.CodCorrida = "AC1" Then

            Select Case vNumeroArticulo
                Case "10"
                    vNumeroArticulo = "XXL"
                Case "8"
                    vNumeroArticulo = "XL"
                Case "6"
                    vNumeroArticulo = "L"
                Case "4"
                    vNumeroArticulo = "M"
                Case "2"
                    vNumeroArticulo = "S"
                Case "1"
                    vNumeroArticulo = "XS"
                Case "0"
                    vNumeroArticulo = "U"
                Case Else
                    vNumeroArticulo = vNumeroArticulo
            End Select
        Else
            vNumeroArticulo = txtPopupTalla.Text.Trim()
        End If
        
        txtCantidad.ReadOnly = False
        txtCantidad.Focus()
    End Sub

    Public Function CargarCodigo()
        Dim CodeRow As Integer = 0
        ' If modificar = False Then
        If Me.CodArticulo <> "" Then
            Dim oCatalogoUPCMgr As CatalogoUPCManager
            oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            If oCatalogoUPCMgr.IsSkuOrMaterial(Me.CodArticulo) = "S" Then
                'If IsNumeric(txtPopupCodigo.Text.Trim()) Then
                'Es un CodigoUPC
                Dim dsUPC As New DataTable

                'On Error Resume Next

                dsUPC = oCatalogoUPCMgr.Load2(txtPopupCodigo.Text.Trim())

                dsUPC = oFacturaMgr.GetUPCData(txtPopupCodigo.Text.Trim())
                If dsUPC.Rows.Count > 0 Then
                    txtPopupCodigo.Text = UCase(dsUPC.Rows(0).Item("CodArticulo"))
                    Dim talla As String = dsUPC.Rows(0).Item("Numero")
                    txtPopupTalla.Text = talla
                    '</Captura con lector>
                    Dim dataRow As DataRow = Nothing
                    dataRow = BuscaCodigoVentaJanus(txtPopupCodigo.Text.Trim()) ', txtPopupTalla.Text.Trim())
                    If dataRow Is Nothing Then
                        ActualizaDatosArticuloJanus(txtPopupCodigo.Text.Trim()) ', txtPopupTalla.Text.Trim())
                        'If 1 > ebExistencias.Value Then
                        '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                        '    Return False
                        'Else
                        txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)
                        txtPopupTotal.Value = CDec(txtCantidad.Value) * Decimal.Round(oArticulo.PrecioVenta, 2)
                        '--Aplicamos Descuento si lo tuviera
                        If ebPorcentajeDscto.Value > 0 Then
                            txtPopupDescuento.Value = Decimal.Round(CDec(txtPopupTotal.Value) * ebPorcentajeDscto.Value, 2)
                        Else
                            txtPopupDescuento.Value = Decimal.Round(CDec(txtCantidad.Value) * ebMontoDscto.Value, 2)
                        End If
                        ActualizaCalculos()
                        CargarCodigoSH(Me.CodArticulo)
                        'End If
                    Else
                        ActualizaDatosArticuloJanus(Me.CodArticulo) ', txtPopupTalla.Text.Trim())
                        'If CDec(txtCantidad.Value) > ebExistencias.Value Then
                        '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                        '    txtPopupTalla.Focus()
                        '    Return False
                        'Else
                        txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
                        If ebPorcentajeDscto.Value > 0 Then
                            txtPopupDescuento.Value = Decimal.Round(CDec(txtPopupTotal.Value) * CDec(ebPorcentajeDscto.Value), 2)
                        Else
                            txtPopupDescuento.Value = Decimal.Round(CDec(txtCantidad.Value) * ebMontoDscto.Value, 2)
                        End If
                        'End If
                        ActualizaCalculos()
                        CargarCodigoSH(Me.CodArticulo)
                    End If
                Else
                    dsUPC = Nothing
                    MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                    txtPopupCodigo.Focus()
                    Return False
                End If
            Else
                Dim BrandMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.CatalogoMarcasManager(oAppContext)
                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(Me.CodArticulo, oArticulo)
                If BrandMgr.Load(oArticulo.CodMarca) Is Nothing Then
                    MsgBox("La marca del producto no existe en el catálogo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                    Exit Function
                End If
                ArtExistencia = oArticuloMgr.GetExistenciaByCodigo(Me.CodArticulo)
                If ArtExistencia.Count > 0 Then
                    Color = CStr(ArtExistencia("Color"))
                    Me.txtPopupTalla.Text = CStr(ArtExistencia("Numero"))
                    If txtCantidad.Text.Trim = "" Then
                        txtCantidad.Value = 1
                    End If
                    txtPopupDescuento.Value = 0
                    txtPopupAdicional.Value = 0
                    oFactura.FacturaArticuloExistencia = 0
                    '--Ponemos el Precio en el Grid / por SAP se usara PrecioNormal
                    txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)
                    txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
                    'Obtenemos Numero Inicio y Numero Fin del Artículo
                    oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                    'Obtenemos Tallas de la Corrida del Artículo
                    ActualizaDatosArticuloJanus(Me.CodArticulo)
                    txtPopupDescuento.Value = ebPorcentajeDscto.Value
                    FillTallasArticulo(oArticulo.CodCorrida)
                    Me.txtCantidad.Focus()
                    Me.txtCantidad.ReadOnly = False
                Else
                    txtCantidad.Value = 1
                    txtPopupDescuento.Value = 0
                    txtPopupAdicional.Value = 0
                    oFactura.FacturaArticuloExistencia = 0
                    '--Ponemos el Precio en el Grid / por SAP se usara PrecioNormal
                    txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)
                    txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
                    'Obtenemos Numero Inicio y Numero Fin del Artículo
                    oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                    'Obtenemos Tallas de la Corrida del Artículo
                    ActualizaDatosArticuloJanus(Me.CodArticulo)
                    txtPopupDescuento.Value = ebPorcentajeDscto.Value
                    Me.txtPopupTalla.ReadOnly = False
                    Me.txtPopupTalla.Focus()
                End If

                'oArticulo.ClearFields()
                'vNumeroArticulo = 0
                'vCodArticulo = UCase(txtPopupCodigo.Text.Trim())
                'CodPadreArticulo = oArticuloMgr.ValidaCodigoProveedor(vCodArticulo)

                'If CodPadreArticulo <> "" Then
                '    vNumStringArticulo = Mid(vCodArticulo, 1, 2)
                'Else
                '    txtPopupCodigo.Text = ""
                '    MessageBox.Show("No existe el código de proveedor", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'End If

                'If ValidarDTCAT(CStr(vCodArticulo)) = False Then
                '    Return False
                'End If
                'oArticulo.ClearFields()
                'oArticuloMgr.LoadInto(vCodArticulo, oArticulo, False)
                'If oArticulo.CodArticulo = String.Empty Then
                '    txtPopupCodigo.Text = vCodArticulo
                '    oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                'Else
                '    txtPopupCodigo.Text = oArticulo.CodArticulo
                'End If
                'If Not oArticulo.Exist Then
                '    MsgBox("Código de Artículo No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                '    ActualizaCalculos()
                'Else
                '    If CStr(txtPopupCodigo.Text.Trim) <> vCodigo Then
                '        txtPopupTalla.Text = vNumeroArticulo
                '        txtCantidad.Value = 1
                '        txtPopupImporte.Value = 0
                '        txtPopupTotal.Value = 0
                '        txtPopupDescuento.Value = 0
                '        txtPopupAdicional.Value = 0
                '        oFactura.FacturaArticuloExistencia = 0
                '    End If
                '    '--Ponemos el Precio en el Grid / por SAP se usara PrecioNormal

                '    txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)

                '    'Obtenemos Numero Inicio y Numero Fin del Artículo
                '    oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

                '    'Obtenemos Tallas de la Corrida del Artículo
                '    ActualizaDatosArticuloJanus(txtPopupCodigo.Text.Trim())
                '    txtPopupDescuento.Value = ebPorcentajeDscto.Value
                '    FillTallasArticulo(oArticulo.CodCorrida)
                '    txtPopupTalla.Focus()
                'End If
            End If
        Else
            'MsgBox("Ingrese Código de Artículo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
            ActualizaCalculos()
            'txtPopupCodigo.Focus()
        End If
        'txtPopupCodigo.ReadOnly = True
        'txtPopupTalla.ReadOnly = False
        'txtPopupTalla.Focus()
        'End If
    End Function

    Private Sub txtPopupTalla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPopupTalla.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If txtPopupCodigo.Text.Trim() <> "" Then
            '    '-----------------------------------------------------------------------------
            '    ' JNAVA (31.01.2016): Si no se encuentra la talla, no continua con el proceso
            '    '-----------------------------------------------------------------------------
            '    If Not CargarTalla() Then
            '        Exit Sub
            '    End If
            '    '-----------------------------------------------------------------------------
            'End If
            'Me.txtCantidad.Focus()
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function CargarTalla() As Boolean
        If txtPopupCodigo.Text.Trim = "" Then
            MessageBox.Show("Antes tienes que elegir el Código", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtPopupCodigo.Focus()
            Exit Function
        End If
        If txtPopupTalla.Text.Trim() <> "" Then
            Me.txtCantidad.Focus()
            Me.txtPopupTalla.ReadOnly = True
            Exit Function
            'If Not IsNumeric(txtPopupTalla.Text.Trim()) Then
            '    txtPopupTalla.Text = UCase(txtPopupTalla.Text.Trim())
            'End If
            'If txtPopupCodigo.Text.Trim() <> "" AndAlso txtPopupTalla.Text.Trim() <> "" Then
            '    Dim BrandMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.CatalogoMarcasManager(oAppContext)
            '    Dim cuenta As Integer = 0
            '    '----------------------------------------------------------------
            '    ' JNAVA (30.01.2017): Limpiamos el articulo
            '    '----------------------------------------------------------------
            '    oArticulo.ClearFields()
            '    '----------------------------------------------------------------
            '    oFacturaMgr.GetExistenciaCodProveedor(CodPadreArticulo, oFactura.CodAlmacen, txtPopupTalla.Text.Trim(), oFactura, oArticulo, cuenta)
            '    If cuenta > 1 Then
            '        If BrandMgr.Load(oArticulo.CodMarca) Is Nothing Then
            '            MsgBox("La marca del producto no existe en el catálogo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
            '            Exit Function
            '        End If
            '        Dim frmColor As New frmItemColor(CodPadreArticulo, txtPopupTalla.Text.Trim())
            '        frmColor.ShowDialog()
            '        If frmColor.Action = Windows.Forms.DialogResult.OK Then
            '            oArticulo.ClearFields()
            '            oArticuloMgr.LoadInto(frmColor.Code, oArticulo)
            '            CodArticuloPopup = oArticulo.CodArticulo
            '            oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
            '            If CStr(txtPopupCodigo.Text.Trim) <> vCodigo Then
            '                txtCantidad.Value = 1
            '                txtPopupImporte.Value = 0
            '                txtPopupTotal.Value = 0
            '                txtPopupDescuento.Value = 0
            '                txtPopupAdicional.Value = 0
            '                oFactura.FacturaArticuloExistencia = 0
            '            End If
            '            txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)
            '            txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
            '            'Obtenemos Numero Inicio y Numero Fin del Artículo
            '            oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

            '            'Obtenemos Tallas de la Corrida del Artículo
            '            ActualizaDatosArticuloJanus(CodArticuloPopup)
            '            txtPopupDescuento.Value = ebPorcentajeDscto.Value
            '            FillTallasArticulo(oArticulo.CodCorrida)
            '        Else
            '            CodArticuloPopup = ""
            '        End If
            '    Else

            '        '------------------------------------------------------------------------------------------------------
            '        ' JNAVA (31.01.2017): Si no se cargo el articulo, es por que no existe en esa talla
            '        '------------------------------------------------------------------------------------------------------
            '        If oArticulo.CodArticulo.Trim = String.Empty Then
            '            '-------------------------------------------------------------------------------------------------------------------------------
            '            ' JNAVA (03.03.2017): Validamos que este activa la configuracion de Articulos de Catalogo en SH
            '            '-------------------------------------------------------------------------------------------------------------------------------
            '            ' JNAVA (22.03.2017): Agregamos validacion de la configuracion para Todos los Articulos en SH activa
            '            '-------------------------------------------------------------------------------------------------------------------------------
            '            If oConfigCierreFI.TodosArticulosSH OrElse oConfigCierreFI.ArticuloCatalogoSH Then

            '                '-------------------------------------------------------------------------------------------------------------------------------
            '                ' Obtenemos el codigo del catalogo filtrado por el CodPadre
            '                '-------------------------------------------------------------------------------------------------------------------------------
            '                Dim dtCodigos As DataTable = oArticuloMgr.LoadIntoByCodPadre(CodPadreArticulo)
            '                Dim StrCodigoArticulo As String = String.Empty
            '                Dim strDescripcion() As String
            '                For Each oRow As DataRow In dtCodigos.Rows
            '                    strDescripcion = CStr(oRow!Descripcion).Split(",")
            '                    If GetFormatTalla(strDescripcion(1).Trim()) = GetFormatTalla(txtPopupTalla.Text.Trim()) Then
            '                        StrCodigoArticulo = CStr(oRow!CodArticulo)
            '                        Exit For
            '                    End If
            '                Next

            '                oArticulo.ClearFields()
            '                oArticuloMgr.LoadInto(StrCodigoArticulo, oArticulo)

            '                ''-------------------------------------------------------------------------------------------------------------------------------
            '                ''Validamos que se haya cargado el articulo o de lo contrario que sea dip
            '                ''------------------------------------------------------------------------------------------------------------------------------
            '                'If oArticulo.CodArticulo = String.Empty OrElse Not oArticulo.Dip Then
            '                '    MessageBox.Show("Producto no existente en el inventario de la tienda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                '    Me.txtPopupTalla.Text = String.Empty
            '                '    Me.txtPopupTalla.Focus()
            '                '    Return False
            '                'End If

            '                '-------------------------------------------------------------------------------------------------------------------------------
            '                ' JNAVA (22.03.2017): Validamos que este activa la configuracion de Todos los Articulos (Nueva) o la de Articulos de Catalogo en SH (y que sea DIP)
            '                '-------------------------------------------------------------------------------------------------------------------------------
            '                If oArticulo.CodArticulo = String.Empty OrElse Not (oConfigCierreFI.TodosArticulosSH OrElse Not (oConfigCierreFI.ArticuloCatalogoSH AndAlso oArticulo.Dip)) Then
            '                    MessageBox.Show("Producto no existente en el inventario de la tienda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                    Me.txtPopupTalla.Text = String.Empty
            '                    Me.txtPopupTalla.Focus()
            '                    Return False
            '                End If
            '                '-------------------------------------------------------------------------------------------------------------------------------

            '            Else
            '                MessageBox.Show("El Artículo no cuenta con esa talla.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '                Me.txtPopupTalla.Text = String.Empty
            '                Me.txtPopupTalla.Focus()
            '                Return False
            '            End If
            '        End If
            '        '------------------------------------------------------------------------------------------------------

            '        CodArticuloPopup = oArticulo.CodArticulo
            '        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
            '        If CStr(txtPopupCodigo.Text.Trim) <> vCodigo Then
            '            txtCantidad.Value = 1
            '            txtPopupImporte.Value = 0
            '            txtPopupTotal.Value = 0
            '            txtPopupDescuento.Value = 0
            '            txtPopupAdicional.Value = 0
            '            oFactura.FacturaArticuloExistencia = 0
            '        End If
            '        txtPopupImporte.Value = Decimal.Round(oArticulo.PrecioVenta, 2)
            '        txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
            '        'Obtenemos Numero Inicio y Numero Fin del Artículo
            '        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

            '        'Obtenemos Tallas de la Corrida del Artículo
            '        ActualizaDatosArticuloJanus(CodArticuloPopup)
            '        txtPopupDescuento.Value = ebPorcentajeDscto.Value
            '        FillTallasArticulo(oArticulo.CodCorrida)

            '    End If
            '    txtCantidad.Focus()
            'End If
        End If
    End Function

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If Not txtCantidad.Value Is Nothing AndAlso CDec(txtCantidad.Value) <> 0 Then
            '    CalcularCantidad()
            'End If
            Me.btnPopupGuardar.Focus()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2013: Función para calcular la existencia del articulo en el almacen
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function CalcularCantidad()

        If txtPopupCodigo.Text.Trim() <> String.Empty AndAlso txtPopupTalla.Text.Trim() = String.Empty Then
            MessageBox.Show("Antes debes de elegir el Código con su talla")
            Exit Function
        End If

        If txtPopupCodigo.Text.Trim() = "" Or txtPopupTalla.Text.Trim() = "" Then
            'MessageBox.Show("Antes debes de elegir el Código con su talla")
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/04/2013: Se validara si el producto esta dado de alta en el almacen
        '--------------------------------------------------------------------------------------------------------------------------
        Dim cant As Integer = oFactura.FacturaArticuloExistencia
        Dim CorridaMgr As New FacturaCorridaManager(oAppContext)

        Dim existe As Boolean = CorridaMgr.IsArticuloEnAlmacen(Me.CodArticulo)
        If existe = False Then
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (21.07.2015): Validamos que este activa la configuracion de Articulos de Catalogo en SH
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (22.03.2017): Validamos que este activa la configuracion de Articulos sin Existencia en SH
            '-------------------------------------------------------------------------------------------------------------------------------
            If Not oConfigCierreFI.TodosArticulosSH AndAlso Not oConfigCierreFI.ArticuloCatalogoSH Then
                GoTo NoExiste
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'JNAVA 27.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
            '-----------------------------------------------------------------------------------------------------------------------------
            ''-----------------------------------------------------------------------------------------------------------------------------
            ''JNAVA 21.07.2015: Validamos que la tienda y el producto sean de catalogo para saltarse esta validacion
            ''-----------------------------------------------------------------------------------------------------------------------------
            'Dim bEsTiendaDeCatalogo As Boolean = oSAPMgr.ZSH_ES_TIENDA_CATALOGO
            'If bEsTiendaDeCatalogo Then
            '-----------------------------------------------------------------------------------------------------------------------------
            If Me.txtPopupCodigo.Text.Trim <> "" AndAlso Me.CodArticulo.Trim <> "" Then ' JNAVA (12.02.2017): Validamos que este cargado el codigo del articulo
                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(Me.CodArticulo, oArticulo)

                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (22.03.2017): Validamos que este activa la configuracion de Articulos sin Existencia o de CAtalogo en si Hay (y que sea DIP)
                '-------------------------------------------------------------------------------------------------------------------------------
                'If oArticulo.CodArticulo.Trim = "" OrElse oArticulo.Dip = False Then
                If oArticulo.CodArticulo = String.Empty OrElse Not (oConfigCierreFI.TodosArticulosSH OrElse Not (oConfigCierreFI.ArticuloCatalogoSH AndAlso oArticulo.Dip)) Then
                    GoTo NoExiste
                Else
                    GoTo Existe
                End If
                '-------------------------------------------------------------------------------------------------------------------------------
            Else
                '-----------------------------------------------------------------------------------------------------------------------------
                'JNAVA 27.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
                '-----------------------------------------------------------------------------------------------------------------------------
                '*GoTo NoExiste
                '-----------------------------------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------------------------------------------
                'JNAVA 27.10.2015: Se agregó esta parte en base a la validacion que se quito para no afectar otras validaciones
                '-----------------------------------------------------------------------------------------------------------------------------
NoExiste:
                MessageBox.Show("Producto no existente en el inventario de la tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            '-----------------------------------------------------------------------------------------------------------------------------
            'JNAVA 27.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
            '-----------------------------------------------------------------------------------------------------------------------------
            '*                Else
            '*NoExiste:
            '*                    MessageBox.Show("Producto no existente en el inventario de la tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '*                End If
            '-----------------------------------------------------------------------------------------------------------------------------
        Else
Existe:
            txtPopupTotal.Value = CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value)
            'If ebPorcentajeDscto.Value > 0 Then
            '    txtPopupDescuento.Value = Decimal.Round(CDec(txtPopupTotal.Value) * CDec(ebPorcentajeDscto.Value), 2)
            'Else
            '    txtPopupDescuento.Value = Decimal.Round(CDec(txtCantidad.Value) * ebMontoDscto.Value, 2)
            'End If
            txtPopupDescuento.Value = ebPorcentajeDscto.Value
            'txtPopupTotal.Value = Decimal.Round(CDec(txtPopupImporte.Value) * CDec(txtCantidad.Value), 2)
            '    '/*********************
            '    '--Aplicamos Descuento si lo tuviera
            'If ebPorcentajeDscto.Value > 0 Then
            '    txtPopupDescuento.Value = Decimal.Round(CDec(txtPopupTotal.Value) * ebPorcentajeDscto.Value, 2)
            'Else
            '    txtPopupDescuento.Value = Decimal.Round(CDec(txtCantidad.Value) * ebMontoDscto.Value, 2)
            'End If
            '**************Aplicamos Descuentos Adicionales Segun Las Promociones Vigentes
            'AplicaDescuentosAutomaticos()
            '/**********************************************************
            btnPopupGuardar.Focus()
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        PanelAgregarArticulo.Visible = False
        ClearValuesArticulosPanel()
    End Sub

    Private Sub txtPopupCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPopupCodigo.ButtonClick
        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
            boolManual = True
            If boolManual Then
                txtPopupCodigo.ReadOnly = True
                txtPopupCodigo.Text = LoadSearchArticulo()
                txtCantidad.Focus()
                '  SendKeys.Send("{ENTER}")
            End If
        Else
            boolManual = False
        End If
        oAppContext.Security.CloseImpersonatedSession()
    End Sub

    Private Sub btnPopupGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPopupGuardar.Click
        If ValidarArticuloManual() Then
            Guardar()
            ClearValuesArticulosPanel()
        End If
    End Sub

    Public Function Guardar()
        SaveArticuloDataTable()
        Dim TotalAPagarDip As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0
        If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
            AplicaDescuentosDips()
        Else
            AplicaDescuentosDips()
            'NuevosDescuentosDips()
        End If
        TotalAPagarDip = oFactura.Total
        AplicarPromociones()
        TotalAPagarPromo = oFactura.Total
        If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo Then
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
        End If
        VerificaCondicionDescuento(dsDetalle.Tables(0))
        ActualizaCalculos()
    End Function

    Private Sub Descargar(ByVal dtMateriales As DataTable)
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

        frmDescargas.Timer1.Enabled = False
        frmDescargas.bPorCodigo = True
        frmDescargas.dtMateriales = dtMateriales
        frmDescargas.bMostrarMensaje = False
        frmDescargas.ShowDev("Descuentos")
        frmDescargas.ShowDev("Inventarios")
        frmDescargas.ShowDev("CodigosUPC")
    End Sub

    Private Sub UpdateCode(ByVal dtMateriales As DataTable)
        Dim frmDescargas As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        frmDescargas.Timer1.Enabled = False
        frmDescargas.bPorCodigo = True
        frmDescargas.bMostrarMensaje = False
        frmDescargas.dtMateriales = dtMateriales
        frmDescargas.ShowDev("Articulos")
    End Sub


    Public Sub ActualizaProducto(ByVal Codigo As String)
        Dim dtMateriales As New DataTable()
        dtMateriales.Columns.Add("Material", GetType(String))
        dtMateriales.Columns.Add("Descripcion", GetType(String))
        dtMateriales.AcceptChanges()

        Dim row As DataRow = dtMateriales.NewRow()
        row("Material") = Codigo
        row("Descripcion") = ""
        dtMateriales.Rows.Add(row)
        UpdateCode(dtMateriales)
        Descargar(dtMateriales)
    End Sub


    '------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/10/2012: Funcion que valida la captura de datos manual de los articulos 
    '------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarArticuloManual() As Boolean
        Dim controls() As Control = {txtPopupCodigo, txtCantidad}
        If ValidarControles(controls) = False Then
            Return False
        End If

        '--------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 09/02/2022: Descargar los datos del artículo solicitado de SAP
        '--------------------------------------------------------------------------------------------------------------------------

        ActualizaProducto(Me.CodArticulo)

        '--------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 16/05/2022: Volver a cargar el artículo, una vez actualizado
        '--------------------------------------------------------------------------------------------------------------------------

        CargarCodigo()

        '--------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 16/05/2022: Validar si el producto esta extendido a la tienda que selecciona
        '--------------------------------------------------------------------------------------------------------------------------

        If oConfigCierreFI.ValidarMaterialesExtendidos Then
            Dim total As Integer
            total = oFacturaMgr.getTotalRegistrosExistencias(Me.CodArticulo)
            If total = 0 Then
                MessageBox.Show("Producto NO extendido para su tienda, proceso controlado para la venta por los ADIS, favor de llamar a soporte", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If
        End If

        '--------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 12/05/2022: Buscar el producto en SAPCAR, comentado a petición de Francisco
        '--------------------------------------------------------------------------------------------------------------------------

        'If oSAPMgr.SAPApplicationConfig.SiHay Then
        '    Dim strCentro As String
        '    Dim dtArt As DataTable
        '    Dim list As New List(Of String)

        '    list.Add(Me.CodArticulo)

        '    strCentro = oSAPMgr.Read_Centros
        '    dtArt = ConsultaExistenciasSAPCAR("General", list, strCentro)

        '    If Not dtArt Is Nothing AndAlso dtArt.Rows.Count > 0 Then
        '        Dim oRow As DataRow = dtArt.Rows(0)
        '        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        '        procesoMgr.UpdateExistenciaSAPCAR(Me.CodArticulo, oRow!STK_DISPONIBLE, oRow!APARTADOS, oRow!DEFECTUOSOS, oRow!STK_CONSIGNACION, oRow!STK_TRANSITO)
        '    Else
        '        MessageBox.Show("No se pudo comparar existencias con SAPCAR", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If

        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/04/2013: Se validara si el producto esta dado de alta en el almacen
        '--------------------------------------------------------------------------------------------------------------------------
        Dim cant As Integer = oFactura.FacturaArticuloExistencia
        Dim CorridaMgr As New FacturaCorridaManager(oAppContext)

        Dim existe As Boolean = CorridaMgr.IsArticuloEnAlmacen(Me.CodArticulo)
        If existe = False Then
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (20.07.2015): Si no esta activa Config para permitir arituculos de catalogo en Si Hay, se muestra mensaje de no existencia
            '-------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (22.03.2017): Validamos que este activa la configuracion de Articulos sin Existencia en SH
            '-------------------------------------------------------------------------------------------------------------------------------
            If Not oConfigCierreFI.TodosArticulosSH AndAlso Not oConfigCierreFI.ArticuloCatalogoSH Then
                GoTo NoExiste
            End If

            '-----------------------------------------------------------------------------------------------------------------------------
            'JNAVA 28.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
            '---------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 17.07.2015: Validamos que la tienda y el producto sean de catalogo para saltarse esta validacion
            ''-----------------------------------------------------------------------------------------------------------------------------
            'Dim bEsTiendaDeCatalogo As Boolean = oSAPMgr.ZSH_ES_TIENDA_CATALOGO
            'If bEsTiendaDeCatalogo Then-----------------------------------------------------------------------------------
            ''-----------------------------------------------------------------------------------------------------------------------------
            ''RGERMAIN 17.07.2015: Validamos que la tienda y el producto sean de catalogo para saltarse esta validacion
            ''-----------------------------------------------------------------------------------------------------------------------------
            'Dim bEsTiendaDeCatalogo As Boolean = oSAPMgr.ZSH_ES_TIENDA_CATALOGO
            'If bEsTiendaDeCatalogo Then
            '-----------------------------------------------------------------------------------------------------------------------------
            If Me.txtPopupCodigo.Text.Trim <> "" Then
                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(Me.CodArticulo, oArticulo)
                '-------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (22.03.2017): Validamos que este activa la configuracion de Articulos sin Existencia o de CAtalogo en si Hay (y que sea DIP)
                '-------------------------------------------------------------------------------------------------------------------------------
                'If oArticulo.CodArticulo.Trim = "" OrElse oArticulo.Dip = False Then
                If oArticulo.CodArticulo = String.Empty OrElse Not (oConfigCierreFI.TodosArticulosSH OrElse Not (oConfigCierreFI.TodosArticulosSH AndAlso oArticulo.Dip)) Then
                    GoTo NoExiste
                End If
                '-------------------------------------------------------------------------------------------------------------------------------
            Else
                '-----------------------------------------------------------------------------------------------------------------------------
                'JNAVA 28.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
                '-----------------------------------------------------------------------------------------------------------------------------
                '*GoTo NoExiste
                '-----------------------------------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------------------------------------------
                'JNAVA 28.10.2015: Se agregó esta parte en base a la validacion que se quito para no afectar otras validaciones
                '-----------------------------------------------------------------------------------------------------------------------------
NoExiste:
                MessageBox.Show("Producto no existente en el inventario de la tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            '-----------------------------------------------------------------------------------------------------------------------------
            'JNAVA 27.10.2015: Se comentó esta validacion puesto que se solicito en proyecto CDPT-085 EF Si Hay Aceptación Catalogo V2 *
            '-----------------------------------------------------------------------------------------------------------------------------
            '*                Else
            '*NoExiste:
            '*                    MessageBox.Show("Producto no existente en el inventario de la tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '*                End If
            '-----------------------------------------------------------------------------------------------------------------------------
        End If
        'If CDec(txtCantidad.Value) > CDec(ebExistencias.Value) Then
        '    MessageBox.Show("La cantidad debe ser igual o menor que las existencias", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If
        Return True
    End Function

    Public Function ValidarControles(ByVal controls() As Control) As Boolean
        Dim valido As Boolean = True
        Dim mensaje As String = "Lista de controles a capturar" & vbCrLf
        For Each ctrl As Control In controls
            If TypeOf ctrl Is EditBox Then
                Dim Edit As EditBox = CType(ctrl, EditBox)
                If Edit.Text.Trim = "" OrElse (IsNumeric(Edit.Text.Trim) AndAlso Convert.ToInt64(Edit.Text.Trim) <= 0) Then
                    Dim mensajeControl As String = CStr(Edit.Tag.ToString())
                    valido = False
                    mensaje &= mensajeControl & vbCrLf
                End If
            ElseIf TypeOf ctrl Is NumericEditBox Then
                Dim edit As NumericEditBox = CType(ctrl, NumericEditBox)
                If edit.Value <= 0 Then
                    Dim mensajeControl As String = CStr(edit.Tag.ToString())
                    valido = False
                    mensaje &= mensajeControl & vbCrLf
                End If
            End If
        Next
        If valido = False Then
            MessageBox.Show(mensaje, "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Public Function ClearControls(ByVal controls() As Control)
        For Each ctrl As Control In controls
            If TypeOf ctrl Is EditBox Then
                Dim edit As EditBox = CType(ctrl, EditBox)
                edit.Text = ""
            ElseIf TypeOf ctrl Is NumericEditBox Then
                Dim edit As NumericEditBox = CType(ctrl, NumericEditBox)
                edit.Value = 0
            End If
        Next
    End Function

    Public Function ValidarCodigoUpc(ByRef row As DataRow, ByVal codigo As String) As Boolean
        Dim valido As Boolean = False
        If IsNumeric(codigo) Then
            'Es un CodigoUPC
            Dim dsUPC As New DataTable
            Dim oCatalogoUPCMgr As CatalogoUPCManager
            oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            'On Error Resume Next
            dsUPC = oCatalogoUPCMgr.Load2(codigo)
            dsUPC = oFacturaMgr.GetUPCData(codigo)
            If dsUPC.Rows.Count > 0 Then
                If ValidarDTCAT(CStr(dsUPC.Rows(0).Item("CodArticulo"))) = False Then
                    Return False
                End If
                Dim art As Articulo = oArticuloMgr.Create()
                art.ClearFields()
                '-----------------------------------------------------------------------------------
                ' JNAVA (10.02.2017): Se envia el codigo del articulo para obtener su informacion
                '-----------------------------------------------------------------------------------
                oArticuloMgr.LoadInto(CStr(dsUPC.Rows(0).Item("CodArticulo")), art)
                '-----------------------------------------------------------------------------------
                row("Codigo") = CStr(dsUPC.Rows(0).Item("CodArticulo"))
                row("CodProveedor") = art.CodArtProv
                Dim talla As String = dsUPC.Rows(0).Item("Numero")
                row("Talla") = talla
                Dim codigoArt As String = CStr(row("Codigo"))
                Dim ArticuloMgr As CatalogoArticuloManager = New CatalogoArticuloManager(oAppContext)
                art = ArticuloMgr.Create()
                ArticuloMgr.LoadInto(codigoArt, art)
                row("Descripcion") = art.Descripcion
                '</Captura con lector>
                Dim dataRow As dataRow = Nothing
                dataRow = BuscaCodigoVentaJanus(CStr(row!Codigo)) ', talla)
                If dataRow Is Nothing Then
                    ActualizaDatosArticuloJanus(CStr(row!Codigo)) ', talla)
                    'If 1 > ebExistencias.Value Then
                    '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                    '    Return False
                    'Else
                    row("Cantidad") = 1
                    row("Importe") = Decimal.Round(oArticulo.PrecioVenta, 2)
                    row("Total") = CDec(1) * Decimal.Round(oArticulo.PrecioVenta, 2)
                    row("ModoVenta") = 0
                    If 1 > CInt(ebExistencias.Value) Then
                        row("ConExistencia") = CInt(ebExistencias.Value)
                        row("SinExistencia") = 1 - CInt(ebExistencias.Value)
                    Else
                        row("ConExistencia") = 1
                        row("SinExistencia") = 0
                    End If
                    '--Aplicamos Descuento si lo tuviera
                    If ebPorcentajeDscto.Value > 0 Then
                        row("Descuento") = Decimal.Round(CDec(row("Total")) * ebPorcentajeDscto.Value, 2)
                    Else
                        row("Descuento") = Decimal.Round(CDec(1) * ebMontoDscto.Value, 2)
                    End If
                    ActualizaCalculos()
                    'End If
                Else
                    Dim code As String = CStr(dataRow!Codigo)
                    Dim size As String = CStr(dataRow!Talla)
                    ActualizaDatosArticuloJanus(code) ', size)
                    'If CDec(dataRow!Cantidad) > ebExistencias.Value Then
                    '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                    '    dgHeader.Focus()
                    '    Return False
                    'Else
                    Dim importe As Decimal = CDec(dataRow!Importe)
                    Dim cantidad As Decimal = CDec(dataRow!Cantidad) + 1
                    If cantidad > CInt(ebExistencias.Value) Then
                        row("ConExistencia") = cantidad
                        row("SinExistencia") = cantidad - CInt(ebExistencias.Value)
                    Else
                        row("ConExistencia") = cantidad
                        row("SinExistencia") = 0
                    End If
                    dataRow("Cantidad") = cantidad
                    dataRow("Total") = importe * cantidad
                    If ebPorcentajeDscto.Value > 0 Then
                        dataRow("Descuento") = Decimal.Round(CDec(dataRow("Total")) * CDec(ebPorcentajeDscto.Value), 2)
                    Else
                        dataRow("Descuento") = Decimal.Round(CDec(dataRow("Cantidad")) * CDec(ebMontoDscto.Value), 2)
                    End If
                    'End If
                    ActualizaCalculos()
                    Return False
                End If
            Else
                dsUPC = Nothing
                MsgBox("Código UPC No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                dgHeader.Focus()
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function ValidarDTCAT(ByVal Codigo As String) As Boolean
        Dim valido As Boolean = True
        Dim o
        'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
        If Mid(UCase(Codigo), 1, 6) = "DT-CAT" And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
            If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                MsgBox("¡Dá de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
            Else
                MsgBox("¡Dá de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
            End If
            valido = False
        End If
        Return valido
    End Function

    Public Function SaveArticuloDataTable() As Boolean
        Dim valido As Boolean = True
        Dim index As Integer = 0
        Dim ArticuloMgr As CatalogoArticuloManager = New CatalogoArticuloManager(oAppContext)
        Dim art As Articulo = Nothing
        Dim row As DataRow = Nothing
        Try

            ' MLVARGAS (11.05.2022) Volver a cargar la existencia del producto
            oFacturaMgr.GetExistenciaArticulo(Me.CodArticulo, oFactura.CodAlmacen, "", oFactura)

            row = BuscaCodigoVentaJanus(Me.CodArticulo) ', txtPopupTalla.Text.Trim())
            If row Is Nothing Then
                row = dsDetalle.Tables(0).NewRow()
                row("CodProveedor") = txtPopupCodigo.Text.Trim()
                row("Codigo") = Me.CodArticulo
                art = ArticuloMgr.Create()
                ArticuloMgr.LoadInto(txtPopupCodigo.Text.Trim(), art)
                row("Talla") = txtPopupTalla.Text.Trim()
                row("Cantidad") = CDec(txtCantidad.Value)
                row("Descripcion") = art.Descripcion
                row("Importe") = CDec(txtPopupImporte.Value)
                row("Total") = CDec(txtPopupTotal.Value)
                row("Descuento") = Math.Round(CDec(txtPopupDescuento.Value) * CDec(row("Total")), 2)
                row("Adicional") = CDec(txtPopupAdicional.Value)

                Dim cant As Integer = CInt(txtCantidad.Value)
                Dim stock As Integer = CInt(ebExistencias.Value)
                If (cant > stock) Then
                    row("ModoVenta") = 1
                    row("ConExistencia") = stock
                    row("SinExistencia") = cant - stock
                Else
                    row("ModoVenta") = 0
                    row("ConExistencia") = cant
                    row("SinExistencia") = 0
                End If
                row("Stock") = stock
                dsDetalle.Tables(0).Rows.Add(row)
                dsDetalle.AcceptChanges()
                'If boolManual Then
                '    Dim oForm As New frmMotivosFactura
                '    oForm.Motivos = oFactura.dtMotivos
                '    oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                '    oForm.Articulo = CStr(txtPopupCodigo.Text.Trim())
                '    oForm.Talla = txtPopupTalla.Text.Trim()
                '    oForm.ShowDialog()
                'End If
            Else
                row("Codigo") = Me.CodArticulo
                row("CodProveedor") = txtPopupCodigo.Text.Trim()
                row("Talla") = txtPopupTalla.Text.Trim()
                Dim cant As Integer
                If modificar = True Then
                    cant = CInt(txtCantidad.Value)
                Else
                    Dim cantGrid As Integer = CInt(row("Cantidad"))
                    cant = CInt(txtCantidad.Value) + cantGrid
                End If
                Dim stock As Integer = CInt(ebExistencias.Value)
                If (cant > stock) Then
                    row("ModoVenta") = 1
                    row("ConExistencia") = stock
                    row("SinExistencia") = cant - stock
                Else
                    row("ModoVenta") = 0
                    row("ConExistencia") = cant
                    row("SinExistencia") = 0
                End If
                row("Cantidad") = cant
                row("Importe") = CDec(txtPopupImporte.Value)
                '-------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 13.05.2015: Se corrigio el problema que duplicaba las piezas cuando daban insert varias veces e ingresaban el mismo
                '                     codigo y talla
                '-------------------------------------------------------------------------------------------------------------------------------
                If modificar Then
                    row("Total") = CDec(txtPopupTotal.Value)
                    row("Descuento") = CDec(txtPopupDescuento.Value)
                Else
                    row("Total") += CDec(txtPopupTotal.Value)
                    row("Descuento") += CDec(txtPopupDescuento.Value)
                End If
                row("Adicional") = CDec(txtPopupAdicional.Value)
                dsDetalle.AcceptChanges()
            End If

        Catch ex As Exception
            valido = False
            MessageBox.Show("Ha surgido un error " & vbCrLf & ex.Message, "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return valido
    End Function

    Public Function ClearValuesArticulosPanel()
        Dim controls() As Control = {txtPopupCodigo, txtPopupTalla, txtCantidad, txtPopupImporte, txtPopupDescuento, txtPopupAdicional}
        ClearControls(controls)
        txtPopupCodigo.ReadOnly = True
        txtPopupTalla.ReadOnly = True
        txtCantidad.ReadOnly = True
        modificar = False
        boolManual = False
        PanelAgregarArticulo.Visible = False
        EnableControls(True)
        CodArticuloPopup = ""
        CodPadreArticulo = ""
        'dgHeader.Focus()
    End Function

    Private Sub dgHeader_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles dgHeader.RowDoubleClick
        If Not dgHeader.GetRow() Is Nothing Then
            txtPopupCodigo.ReadOnly = True
            txtPopupTalla.ReadOnly = False
            txtCantidad.ReadOnly = False
            GridIndex = dgHeader.Row
            Dim dataRow As DataRow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
            CodArticuloPopup = dataRow!Codigo
            txtPopupCodigo.Text = CStr(dataRow!CodProveedor)
            txtPopupTalla.Text = CStr(dataRow!Talla)
            txtCantidad.Value = CDec(dataRow!Cantidad)
            txtPopupImporte.Value = CDec(dataRow!Importe)
            txtPopupTotal.Value = CDec(dataRow!Total)
            txtPopupDescuento.Value = CDec(dataRow!Descuento)
            txtPopupAdicional.Value = CDec(dataRow!Adicional)
            If Mid(CStr(dataRow!Codigo), 1, 6) = "DT-CAT" Then
                txtPopupAdicional.ReadOnly = False
            Else
                txtPopupAdicional.ReadOnly = True
            End If
            PanelAgregarArticulo.Location = New Point(216, 145)
            PanelAgregarArticulo.Visible = True
            PanelAgregarArticulo.Focus()
            txtPopupCodigo.Focus()
            modificar = True
            ActualizaCalculos()
        End If
    End Sub

    Public Function BuscaCodigoVentaJanus(ByVal Codigo As String) ', ByVal Talla As String) As DataRow
        Dim row As DataRow = Nothing
        For Each data As DataRow In dsDetalle.Tables(0).Rows
            If CStr(data!Codigo) = Codigo Then 'And CStr(data!Talla) = Talla Then
                row = data
            End If
        Next
        Return row
    End Function

    Private Function AgregarCodigoGrid(ByVal codigo As String)
        Dim row As DataRow = dsDetalle.Tables(0).NewRow()
        Dim TotalAPagarDip As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0
        If ValidarCodigoUpc(row, codigo) = True Then
            dsDetalle.Tables(0).Rows.Add(row)
        End If
        dsDetalle.AcceptChanges()
        If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
            AplicaDescuentosDips()
        Else
            AplicaDescuentosDips()
            'NuevosDescuentosDips()
        End If
        TotalAPagarDip = oFactura.Total
        AplicarPromociones()
        TotalAPagarPromo = oFactura.Total
        If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo Then
            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                AplicaDescuentosDips()
            Else
                AplicaDescuentosDips()
                'NuevosDescuentosDips()
            End If
        End If
        VerificaCondicionDescuento(dsDetalle.Tables(0))
        ActualizaCalculos()
    End Function

    Private Sub dgHeader_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgHeader.SelectionChanged
        If Not dgHeader.GetRow() Is Nothing Then
            Dim row As DataRow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
            If Not row Is Nothing Then
                Dim codigo As String = CStr(row!Codigo)
                'Dim talla As String = CStr(row!Talla)
                ActualizaDatosArticuloJanus(codigo) ', talla)
            End If
        End If
    End Sub

    Public Sub LoadDataofApartadoJanus()
        uICommandManager1.CommandBars(0).Enabled = False
        uICommandManager1.CommandBars(1).Enabled = False

        'oFactura.CodTipoVenta = "P"
        oFactura.CodTipoVenta = "A"
        ebTipoVenta.Enabled = False

        ebCodVendedor.Text = oContratoInfo.PlayerID
        ebCodVendedor.Enabled = False
        btnAltaCliente.Enabled = False
        'Mostramos Player
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
        ebPlayerDescripcion.Text = oVendedor.Nombre
        oFactura.CodVendedor = oVendedor.ID
        'Mostramos Cliente
        ebClienteID.Value = CInt(oContratoInfo.ClienteID)
        If oContratoInfo.ClienteID = 1 Then
            ebClienteDescripcion.Text = "PÚBLICO GENERAL"
        Else
            ebClienteID.Enabled = False
            oCliente.Clear()
            oClienteMgr.Load(oContratoInfo.ClienteID, oCliente, "I")     '--Los ctes. de Apartados estan en el rango de Fiscal
            ebClienteDescripcion.Text = oCliente.NombreCompleto
            oFactura.ClienteId = CInt(oCliente.CodigoAlterno)
        End If
        'Llenamos el Grid con el Detalle del Apartado
        Dim oRowContrato As DataRow, oRowGrid As DataRow
        For Each oRowContrato In oContratoInfo.Detalle.Tables(0).Rows

            oRowGrid = dsDetalle.Tables(0).NewRow()

            With oRowGrid
                .Item("Codigo") = oRowContrato("CodArticulo")
                .Item("Talla") = oRowContrato("Numero")
                .Item("Cantidad") = oRowContrato("Cantidad")
                .Item("Importe") = oRowContrato("Precio")
                .Item("Total") = oRowContrato("Importe")
                .Item("Descuento") = (oRowContrato("Precio") * oRowContrato("Cantidad")) _
                                     * (oRowContrato("Descuento") / 100) '0
                .Item("Adicional") = 0 'oRowContrato("Descuento")
            End With

            dsDetalle.Tables(0).Rows.Add(oRowGrid)

        Next
        dsDetalle.AcceptChanges()

        oFactura.DescTotal = oContratoInfo.DescuentoTotal
        oFactura.Total = oContratoInfo.ImporteTotal
        oFactura.IVA = oContratoInfo.IVA
        oFactura.SubTotal = oFactura.Total - oFactura.IVA
        Me.nebTotalPiezas.Value = IIf(IsDBNull(dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")), 0, dsDetalle.Tables(0).Compute("SUM(Cantidad)", ""))
        dgHeader.Enabled = False
        oFactura.ApartadoID = oContratoInfo.ID
        ebFolioApartado.Value = oContratoInfo.FolioApartado

        'Fecha de Contrato Para Determinacion de Precios en SAP
        '18.10.2007
        oFactura.FechaApartado = Format(oContratoInfo.Fecha, "dd.MM.yyyy")
        dgHeader.Tables(0).Columns("Cantidad").EditType = EditType.NoEdit
        btnFormaPago.Focus()
    End Sub

    Private Sub SetEstructuraPromoAplicada()

        dtPromoAplicada = New DataTable("PromosAplicadas")

        Dim oNewCol As New DataColumn

        With oNewCol
            .ColumnName = "CodPromo"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtPromoAplicada.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "Descripcion"
            .DataType = GetType(String)
            .DefaultValue = ""
        End With
        dtPromoAplicada.Columns.Add(oNewCol)

        oNewCol = New DataColumn
        With oNewCol
            .ColumnName = "ValidaFP"
            .DataType = GetType(Boolean)
            .DefaultValue = False
        End With
        dtPromoAplicada.Columns.Add(oNewCol)

        dtPromoAplicada.AcceptChanges()

    End Sub


    Private Sub LoadSearchFormFacturaJanus()
        strQuin = 0
        bolMenuAbrir = True
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim dtDetalleVale As DataTable
        oOpenRecordDlg.CurrentView = New FacturaCajaPedidosOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            bolIsOpenFacturaInput = True
            oFactura.ClearFields()
            oFacturaMgr.LoadInto(oOpenRecordDlg.Record.Item("FacturaID"), oFactura)

            If oFactura.FacturaID = 0 Then
                MsgBox("Folio de Factura No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                ebFolioFactura.Focus()
            Else

                'CArgamos folio sap
                EbFolioSAP.Visible = True

                '--Cargamos Cliente
                oCliente.Clear()
                If ebClienteID.Value = 1 Then
                    oFactura.ClienteId = 1
                    ebClienteDescripcion.Text = "PÚBLICO GENERAL"
                    'ebClienteID.Value = 0
                Else
                    If oFactura.CodTipoVenta = "A" Then
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, "I")
                    Else
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, oFactura.CodTipoVenta)
                    End If
                    If oCliente.CodigoAlterno = 0 Then
                        ebClienteDescripcion.Text = ""
                    Else
                        oFactura.ClienteId = oCliente.CodigoAlterno
                        ebClienteDescripcion.Text = oCliente.NombreCompleto
                    End If
                End If
                '---Cargamos Numero de Quincenas
                If oFactura.CodTipoVenta = "V" Then
                    Dim dpValeId As String = oFacturaMgr.GetDPVALEID(oFactura.FacturaID)
                    Dim FechaCobro As Date

                    'strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(dpValeId), FechaCobro, dtDetalleVale)

                    '--------------------------------------------------------------------------------------------
                    ' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                    '--------------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then
                        '----------------------------------------------------------------------------------------
                        ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                        '----------------------------------------------------------------------------------------
                        strQuin = oS2Credit.ObtenerPromociones(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, dpValeId, FechaCobro, dtDetalleVale)
                    Else
                        strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, dpValeId, FechaCobro, dtDetalleVale)
                    End If
                    '--------------------------------------------------------------------------------------------
                End If


                '--Cargamos Vendedores
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
                If oVendedor.ID <> String.Empty Then
                    ebPlayerDescripcion.Text = oVendedor.Nombre
                    oFactura.CodVendedor = oVendedor.ID
                Else
                    ebPlayerDescripcion.Text = ""
                End If

                '--Cargamos Apartado
                If oFactura.ApartadoID <> 0 Then
                    Dim oApartadoMgr As New ContratoManager(oAppContext)
                    Dim oApartadoInfo As Contrato
                    oApartadoInfo = oApartadoMgr.Create
                    oApartadoInfo = oApartadoMgr.Load(oFactura.ApartadoID)
                    If (Not oApartadoInfo Is Nothing) And oApartadoInfo.FolioApartado <> 0 Then
                        ebFolioApartado.Value = oApartadoInfo.FolioApartado
                    Else
                        ebFolioApartado.Value = oFactura.ApartadoID
                    End If
                    oApartadoInfo = Nothing
                    oApartadoMgr = Nothing
                End If
                '

                '--Cargamos Detalle de la Factura
                dsDetalle.Tables(0).Rows.Clear()
                oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
                Dim art As Articulo = oArticuloMgr.Create()
                For Each data As DataRow In oFactura.Detalle.Tables(0).Rows
                    Dim oRowGrid As DataRow = dsDetalle.Tables(0).NewRow()
                    art.ClearFields()
                    oArticuloMgr.LoadInto(data("CodArticulo"), art)
                    With oRowGrid
                        .Item("CodProveedor") = art.CodArtProv
                        .Item("Codigo") = data("CodArticulo")
                        .Item("Talla") = data("Numero")
                        .Item("Cantidad") = data("Cantidad")
                        .Item("Importe") = Math.Round(data("PrecioOferta"), 2)
                        .Item("Total") = Math.Round(data("Total"), 2)
                        .Item("Descuento") = Math.Round(data("CantDescuentoSistema"), 2)
                        .Item("Adicional") = Math.Round(data("Descuento"), 2)
                    End With

                    dsDetalle.Tables(0).Rows.Add(oRowGrid)
                Next
                'dgHeader.DataSource = Nothing
                'dgHeader.DataSource = oFactura.Detalle.Tables(0)
                'FormateaGrid()
                explorerBar1.Enabled = False
                Me.UiCommandBar2.Commands("menuArchivoImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True

                'Calculamos total de piezas
                Me.nebTotalPiezas.Value = Math.Round(oFactura.Detalle.Tables(0).Compute("SUM(Cantidad)", ""), 2)
                Me.Pedido = Nothing
            End If

            bolIsOpenFacturaInput = False

        End If

        bolMenuAbrir = False

    End Sub

    Private Sub dgHeader_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgHeader.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                'If Me.boolDescuentoDPakete Then Exit Select
                If dsDetalle.Tables(0).Rows.Count > 0 Then
                    If MessageBox.Show("¿Esta seguro de eliminar este Articulo?", "Facturación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim nRow As Integer = dgHeader.Row
                        Dim row As datarow = Nothing
                        Dim code As String = ""
                        Dim size As String = ""
                        vRowDelete = True
                        If dsDetalle.Tables(0).Rows(nRow).Item(0) <> "" Then
                            row = CType(dgHeader.GetRow().DataRow, DataRowView).Row
                            code = CStr(row!Codigo)
                            'size = CStr(row!Talla)
                            Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & code & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                            'Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & code & "' and Talla = '" & size & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                            If oDataView.Count > 0 Then
                                If Mid(CStr(oDataView.Item(0)("Articulo")), 1, 6) = "DT-CAT" Then
                                    strLlevaCatalogo = ""
                                End If
                                oDataView.Delete(0)
                                oFactura.dtMotivos.AcceptChanges()
                            End If
                        End If

                        dsDetalle.Tables(0).Rows.Remove(row)

                        dsDetalle.AcceptChanges()

                        '******** Aplica los descuentos adicionales automaticos segun las promociones vigentes
                        'AplicaDescuentosAutomaticos()
                        Dim TotalAPagarDip As Decimal = 0
                        Dim TotalAPagarPromo As Decimal = 0
                        If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                            AplicaDescuentosDips()
                        Else
                            AplicaDescuentosDips()
                            'NuevosDescuentosDips()
                        End If
                        TotalAPagarDip = oFactura.Total
                        AplicarPromociones()
                        TotalAPagarPromo = oFactura.Total
                        If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo Then
                            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
                                AplicaDescuentosDips()
                            Else
                                AplicaDescuentosDips()
                                'NuevosDescuentosDips()
                            End If
                        End If
                        VerificaCondicionDescuento(dsDetalle.Tables(0))
                        ActualizaCalculos()

                        'grdDetalle.Select(0, 0)

                        'grdDetalle.Focus()
                        If dgHeader.RowCount > 0 Then
                            dgHeader.MoveTo(0)
                            dgHeader.Focus()
                            Dim datarow As datarow = CType(dgHeader.GetRow().DataRow, DataRowView).Row
                            ActualizaDatosArticuloJanus(CStr(datarow!Codigo)) ', CStr(datarow!Talla))
                        End If
                    End If
                End If
            Case Keys.Insert And vApartadoInstance = False And explorerBar1.Enabled
                ShowPanelInsert()
            Case Keys.Enter
                If dgHeader.Col = 6 Or dgHeader.Col = 3 Then
                    SendKeys.Send("{TAB}")
                End If
        End Select
    End Sub

    Private Sub txtPopupAdicional_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPopupAdicional.GotFocus
        If Mid(txtPopupCodigo.Text.Trim(), 1, 6) = "DT-CAT" Then
            txtPopupAdicional.ReadOnly = False
        Else
            txtPopupAdicional.ReadOnly = True
        End If
    End Sub

    Private Sub dgHeader_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgHeader.GotFocus
        'If dgHeader.RowCount = 0 Then
        '    ShowPanelInsert()
        'End If
    End Sub

    Private Sub txtCantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating ', txtPopupTalla.Validating
        If Not txtCantidad.Value Is Nothing AndAlso CDec(txtCantidad.Value) <> 0 Then
            CalcularCantidad()
        End If
    End Sub

#Region "Facturacion SiHay"

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Se valida que el importe de la factura sea mayor o igual al permitido
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function ValidarImporteMinimoSH() As Boolean
        Dim valido As Boolean = True
        Dim importe As Decimal = CDec(ebImporteTotal.Value)
        If importe < ImporteMinimoSH Then
            valido = False
            MessageBox.Show("No cubre el Monto Total del Importe requerido para la Promocion 'SiHay'", "DportenisPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Se valida que los descuentos de los Articulos no sobrepasen el permitido
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function ValidarDescuentoMaximoSH() As Boolean
        Dim valido As Boolean = True
        Dim DescTotal As Decimal = 0
        Dim mensaje As String = "La lista de estos articulos rebasan el porcentaje permitido para la Promoción 'SiHay'" & vbCrLf
        Dim descuento As Decimal = 0
        Dim codigo As String = ""
        Dim oarticulo As articulo = oArticuloMgr.Create()
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            descuento = 0
            codigo = CStr(row!Codigo)
            oarticulo.ClearFields()
            oArticuloMgr.LoadInto(codigo, oarticulo)
            oCondicionVenta = CargaCondicionVenta(oarticulo)
            If oCondicionVenta.DescPorcentaje > 0 Then
                If oAppContext.ApplicationConfiguration.Almacen = "053" Then 'Vemos si la condicion es mayor al descuento C1 o C2
                    descuento = oCondicionVenta.DescPorcentaje
                Else
                    descuento = oCondicionVenta.DescPorcentaje
                End If
            ElseIf oCondicionVenta.Descmonto <= 0 Then 'Ya no Aplica.
                descuento = 0
            End If
            If PorcMasDescSH > 0 Then
                If descuento > PorcMasDescSH Then
                    valido = False
                    Dim articulo As String = CStr(row!Codigo)
                    mensaje &= "Codigo: " & articulo & " Descuento: " & CStr(descuento) & vbCrLf
                End If
            End If
        Next
        If valido = False Then
            MessageBox.Show(mensaje, "DportenisPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Actualiza las existencias en dado caso que se haya hecho algun traspaso o se haya marcado como defectuoso
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function ActualizarExistenciasSH()
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oFactura As Factura = oFacturaMgr.Create()
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            Dim codigo As String = CStr(row!Codigo)
            Dim talla As String = CStr(row!Talla)
            Dim cant As Integer = CInt(row!Cantidad)
            oFactura.FacturaArticuloExistencia = 0
            oFacturaMgr.GetExistenciaArticulo(codigo, oAppContext.ApplicationConfiguration.Almacen, talla, oFactura)
            Dim stock As Integer = CInt(oFactura.FacturaArticuloExistencia)
            If (cant > stock) Then
                row("ConExistencia") = stock
                row("SinExistencia") = cant - stock
            Else
                row("ConExistencia") = cant
                row("SinExistencia") = 0
            End If
            dsDetalle.AcceptChanges()
        Next
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Funcion para saber si va aplicar la promoción del SiHay
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetModoVenta() As Integer
        Dim modo As Integer = 0
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            If CInt(row("SinExistencia")) > 0 Then
                modo = 1
            End If
        Next
        Return modo
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Valida si es venta SiHay o No
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Function EsVentaSiHay() As Boolean
        Dim cantidad As Integer = dsDetalle.Tables(0).Rows.Count
        Dim counter As Integer = 0
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            If CInt(row!SinExistencia) = 0 AndAlso CInt(row!ConExistencia) > 0 Then
                counter += 1
            End If
        Next
        If cantidad = counter Then
            Return False
        Else
            Return True
        End If
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Se obtiene los Articulos que si entraran a la promoción SiHay
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetArticulosSinExistencia() As DataTable
        Dim dtArticulos As New DataTable("ArticulosSinExistencias")
        dtArticulos.Columns.Add("CodArticulo", GetType(String))
        dtArticulos.Columns.Add("Descripcion", GetType(String))
        dtArticulos.Columns.Add("Numero", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        dtArticulos.Columns.Add("PrecioUnitario", GetType(Decimal))
        dtArticulos.Columns.Add("Preciooferta", GetType(Decimal))
        dtArticulos.Columns.Add("Total", GetType(Decimal))
        dtArticulos.Columns.Add("CantDescuentoSistema", GetType(Decimal))
        dtArticulos.Columns.Add("Descuento", GetType(Decimal))
        dtArticulos.Columns.Add("Condicion", GetType(String))
        dtArticulos.Columns.Add("Adicional", GetType(Decimal))
        dtArticulos.AcceptChanges()
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            If CInt(row!SinExistencia) > 0 Then
                Dim fila As DataRow = dtArticulos.NewRow()
                fila("CodArticulo") = CStr(row!Codigo)
                fila("Descripcion") = CStr(row!Descripcion)
                fila("Numero") = CStr(row!Talla)
                fila("Cantidad") = CInt(row!SinExistencia)
                fila("PrecioUnitario") = CDec(row!Importe)
                fila("Preciooferta") = CDec(row!Importe)
                fila("Total") = CInt(row!SinExistencia) * CDec(row!Importe)
                fila("CantDescuentoSistema") = (CDec(row!Descuento) / CInt(row!Cantidad)) * CInt(row!SinExistencia)
                fila("Descuento") = CDec(row!Adicional) '(CDec(row!Adicional) / CInt(row!Cantidad)) * CInt(row!SinExistencia)
                fila("Condicion") = CStr(row!Condicion)
                fila("Adicional") = CDec(row!Adicional) '(CDec(row!Adicional) / CInt(row!Cantidad)) * CInt(row!SinExistencia)
                dtArticulos.Rows.Add(fila)
            End If
        Next
        Return dtArticulos
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Funcion para obtener los articulos que si tuvieron existencias
    '----------------------------------------------------------------------------------------------------------------------------------

    Private Function GetArticulosConExistencias() As DataTable
        Dim dtArticulos As New DataTable("ArticulosConExistencia")
        dtArticulos.Columns.Add("CodArticulo", GetType(String))
        dtArticulos.Columns.Add("Descripcion", GetType(String))
        dtArticulos.Columns.Add("Numero", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        dtArticulos.Columns.Add("PrecioUnitario", GetType(Decimal))
        dtArticulos.Columns.Add("Preciooferta", GetType(Decimal))
        dtArticulos.Columns.Add("Total", GetType(Decimal))
        dtArticulos.Columns.Add("CantDescuentoSistema", GetType(Decimal))
        dtArticulos.Columns.Add("Descuento", GetType(Decimal))
        dtArticulos.Columns.Add("Condicion", GetType(String))
        dtArticulos.Columns.Add("Adicional", GetType(Decimal))
        dtArticulos.AcceptChanges()
        For Each row As DataRow In dsDetalle.Tables(0).Rows
            Dim StockTienda As Integer = CInt(row!ConExistencia)
            If StockTienda > 0 Then
                Dim fila As DataRow = dtArticulos.NewRow()
                fila("CodArticulo") = CStr(row!Codigo)
                fila("Descripcion") = CStr(row!Descripcion)
                fila("Numero") = CStr(row!Talla)
                fila("Cantidad") = CInt(row!ConExistencia)
                fila("PrecioUnitario") = CDec(row!Importe)
                fila("Preciooferta") = CDec(row!Importe)
                fila("Total") = CInt(row!ConExistencia) * CDec(row!Importe)
                fila("CantDescuentoSistema") = (CDec(row!Descuento) / CInt(row!Cantidad)) * CInt(row!ConExistencia)
                fila("Descuento") = CDec(row!Adicional) '(CDec(row!Adicional) / CInt(row!Cantidad)) * CInt(row!ConExistencia)
                fila("Condicion") = CStr(row!Condicion)
                fila("Adicional") = CDec(row!Adicional) '(CDec(row!Adicional) / CInt(row!Cantidad)) * CInt(row!ConExistencia)
                dtArticulos.Rows.Add(fila)
            End If
        Next
        Return dtArticulos
    End Function


    Private Function ConcatenarMateriales(ByVal oList As List(Of String)) As String
        Dim materiales As String = String.Empty

        If oList.Count > 1 Then
            For i As Integer = 0 To oList.Count - 1
                materiales += oList.Item(i) + ","
            Next i
            materiales = "(" & materiales.Substring(0, materiales.Length - 1) & ")"
        Else
            materiales = oList.Item(0)
        End If

        Return materiales
    End Function


    Private Function ConsultaExistenciasSAPCAR(ByVal tipo As String, ByVal articulos As List(Of String), ByVal centro As String) As DataTable
        Dim dtDatos As DataTable
        Dim htParams As Hashtable = New Hashtable
        Dim showMessage As Boolean

        htParams.Add("ClienteSAP", oSapMgr.SAPApplicationConfig.ClienteCAR)
        htParams.Add("Material", ConcatenarMateriales(articulos))
        If centro.Length > 0 Then
            htParams.Add("Centro", centro)
        End If
        If tipo = "SI_HAY" Then
            htParams.Add("IDCanal", oSapMgr.SAPApplicationConfig.IdCanalCAR)
            htParams.Add("Version", oSapMgr.SAPApplicationConfig.VersionCAR)
        End If

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As ProcesosRetail

        If tipo = "General" Then
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/POSStkSet", "GET")
            showMessage = False
        Else
            oRetail = New ProcesosRetail("/sap/opu/odata/sap/ZVIEW_STOCK_POS_SRV/VersionStkSet", "GET")
            showMessage = True
        End If


        dtDatos = oRetail.SapCarInventario(htParams, showMessage)

        Return dtDatos

    End Function



    '-----------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2013: Función para validar que existen las cantidades deseadas con la aplicación de la promoción SiHay
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Function ValidarExistenciaSiHay() As Boolean
        Dim valid As Boolean = True
        'Dim mensaje As String = "El Listado de articulos no cumple la existencia de la cantidad requerida:" & vbCrLf
        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim dtArticulos As DataTable = GetArticulosSinExistencia()
        Dim dtFaltante As DataTable = CreateMaterialFaltante()
        Dim dtMaterialesOk As DataTable = MaterialesOk()

        '-----------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 23/08/2021: Si No se encuentra activo el check de Si Hay de SAP CAR se realiza la consulta con el servicio SAP ECC
        '-----------------------------------------------------------------------------------------------------------------------------
        If Not oSAPMgr.SAPApplicationConfig.SiHay Then
            Dim source As DataSet = procesoMgr.ZSH_DISPONIBILIDAD(dtArticulos)
            Dim diferencias As DataTable = source.Tables("T_DIFERENCIAS")
            Dim disponibles As DataTable = source.Tables("T_DISPONIBLES")

            If diferencias.Rows.Count > 0 Then
                valid = False
                For Each row As DataRow In diferencias.Rows
                    Dim renglones() As DataRow = disponibles.Select("MATNR='" & CStr(row!MATERIAL) & "' AND TALLA='" & CStr(row!TALLA) & "'")
                    Dim cant As String = "", faltantes As String = ""
                    Dim fila As DataRow = dtFaltante.NewRow()
                    '----------------------------------------------------------------------
                    ' JNAVA (13.02.2017): Obtenemos el codigo provedor del articulo
                    '----------------------------------------------------------------------
                    oArticulo = oArticuloMgr.Create()
                    oArticuloMgr.LoadInto(CStr(row!MATERIAL), oArticulo)
                    fila("CodArticulo") = oArticulo.CodArtProv ' CStr(row!MATERIAL)
                    '----------------------------------------------------------------------
                    fila("talla") = CStr(row!Talla)
                    If renglones.Length > 0 Then
                        fila("Existencia") = CInt(renglones(0)!CANTIDAD)
                        fila("Faltante") = CInt(row!Cantidad)
                        cant = CStr(renglones(0)!CANTIDAD)
                        faltantes = CStr(row!CANTIDAD)
                    Else
                        fila("Existencia") = 0
                        fila("Faltante") = CInt(row!Cantidad)
                        cant = "0"
                        faltantes = "0"
                    End If
                    dtFaltante.Rows.Add(fila)
                    'mensaje &= CStr(row!MATERIAL) & "  Talla: " & CStr(row!TALLA) & " existencia: " & cant & " Faltantes: " & faltantes & vbCrLf
                Next
                ShowFormMessage(dtFaltante, "El Listado de articulos no cumple la existencia de la cantidad requerida", GetAtributosMaterialNoValido())
                'MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            '-----------------------------------------------------------------------------------------------------------------------------
            'MLVARGAS 23/08/2021: Si está activo el check de Si Hay de SAP CAR 
            '-----------------------------------------------------------------------------------------------------------------------------

            Dim centro As String = oSAPMgr.Read_Centros()
            Dim listProducts As New List(Of String)
            Dim dtQryView As DataView
            Dim nCantSol As Integer
            Dim nCantLibre As Integer

            For Each oRow As DataRow In dtArticulos.Rows
                listProducts.Add(CStr(oRow!codArticulo))
            Next

            Dim strCodigos As String = String.Empty
            Dim dtDatos As DataTable
            Dim totArt As Integer = 0
            dtDatos = ConsultaExistenciasSAPCAR("SI_HAY", listProducts, String.Empty)
            ' Procesar la respuesta del servicio
            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                dtQryView = New DataView(dtDatos, "", "", DataViewRowState.CurrentRows)
                For Each oRow As DataRow In dtArticulos.Rows
                    dtQryView.RowFilter = "Material='" & oRow!codArticulo & "'"
                    If dtQryView.Count > 0 Then
                        Dim totArticulos As Integer = 0
                        For Each oRowView As DataRowView In dtQryView
                            'SUMAR EXISTENCIAS POR PRODUCTO
                            totArticulos += oRowView!STK_DISPONIBLE
                        Next
                        AgregaMaterial(dtMaterialesOk, oRow!codArticulo, totArticulos)                      
                    Else
                        Dim row As DataRow = dtFaltante.NewRow()
                        row("CodArticulo") = oRow!codArticulo
                        row("talla") = oRow!Numero
                        row("Faltante") = oRow!Cantidad
                        row("Existencia") = "0"
                        dtFaltante.Rows.Add(row)
                        valid = False
                    End If
                Next

                dtQryView = New DataView(dtMaterialesOk, "", "", DataViewRowState.CurrentRows)
                For Each oRow As DataRow In dtArticulos.Rows
                    dtQryView.RowFilter = "CodArticulo='" & oRow!codArticulo & "'"
                    nCantSol = oRow!Cantidad
                    nCantLibre = 0
                    If dtQryView.Count > 0 Then
                        Dim oRowView As DataRowView = dtQryView.Item(0)
                        nCantLibre = oRowView!Cantidad
                    End If

                    If nCantLibre >= nCantSol Then
                        totArt += 1
                    Else
                        If Not ValidaExistencia(dtFaltante, oRow!codArticulo) Then
                            Dim row As DataRow = dtFaltante.NewRow()
                            row("CodArticulo") = oRow!codArticulo
                            row("talla") = oRow!Numero
                            row("Faltante") = nCantSol
                            row("Existencia") = nCantLibre
                            dtFaltante.Rows.Add(row)
                        End If
                    End If
                Next



                If valid Then
                    If listProducts.Count > totArt Then
                        valid = False
                    End If
                End If


                If valid = False Then
                    ShowFormMessage(dtFaltante, "El Listado de articulos no cumple la existencia de la cantidad requerida", GetAtributosMaterialNoValido())
                End If
            Else
                valid = False
            End If
        End If
        Return valid
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Obtiene los articulos de la factura sin existencia
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetFacturaCorridaSinExistencia() As DataTable
        Dim articulos As DataTable = Me.dsDetalle.Tables(0).Clone()
        For Each row As DataRow In Me.dsDetalle.Tables(0).Rows
            If CInt(row!SinExistencia) > 0 Then
                articulos.ImportRow(row)
            End If
        Next
        Return articulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Obtiene los articulos de la factura con existencia
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function GetFacturaCorridaConExistencia() As DataTable
        Dim articulos As DataTable = Me.dsDetalle.Tables(0).Clone()
        For Each row As DataRow In Me.dsDetalle.Tables(0).Rows
            If CInt(row!ConExistencia) = 0 Then
                articulos.ImportRow(row)
            End If
        Next
        Return articulos
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013: Función para abrir pedido guardado
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Sub LoadSearchFormPedido()
        strQuin = 0
        bolMenuAbrir = True
        Dim oOpenRecordDlg As New OpenRecordDialog
        Dim dtDetalleVale As DataTable
        oOpenRecordDlg.CurrentView = New PedidoCajaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            bolIsOpenFacturaInput = True
            Me.Pedido = New Pedidos(oOpenRecordDlg.Record.Item("PedidoID"))
            'oFactura.ClearFields()
            'oFacturaMgr.LoadInto(oOpenRecordDlg.Record.Item("FacturaID"), oFactura)

            If Me.Pedido.PedidoID = 0 Then
                MsgBox("Folio de Pedido No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturación")
                ebFolioFactura.Focus()
            Else

                'CArgamos folio sap
                EbFolioSAP.Visible = True

                '--Cargamos Cliente
                oCliente.Clear()
                If Pedido.ClienteID = 1 Then
                    oClienteMgr.LoadPG(Pedido.ClientePGID, oCliente)
                    If oCliente.CodigoCliente > 0 Then
                        oFactura.ClienteId = Pedido.ClientePGID
                        Me.ebClienteID.Value = Pedido.ClientePGID
                        Me.ebClienteDescripcion.Text = oCliente.NombreCompleto
                    Else
                        oFactura.ClienteId = 1
                        Me.ebClienteID.Value = Pedido.ClienteID
                        ebClienteDescripcion.Text = "PÚBLICO GENERAL"
                    End If
                    'ebClienteID.Value = 0
                Else
                    Me.ebClienteID.Value = Pedido.ClienteID
                    If Me.Pedido.CodTipoVenta = "A" Then
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, "I")
                    Else
                        oClienteMgr.Load(CStr(ebClienteID.Value).PadLeft(10, "0"), oCliente, Me.Pedido.CodTipoVenta)
                    End If
                    If oCliente.CodigoAlterno = 0 Then
                        ebClienteDescripcion.Text = ""
                    Else
                        oFactura.ClienteId = oCliente.CodigoCliente
                        Me.ebClienteID.Value = Pedido.ClienteID
                        ebClienteDescripcion.Text = oCliente.NombreCompleto
                    End If
                End If
                Me.ebTipoVenta.Value = Pedido.CodTipoVenta
                '---Cargamos Numero de Quincenas
                If Me.Pedido.CodTipoVenta = "V" Then
                    DPValeID = oFacturaMgr.GetDPVALEID(0, Pedido.PedidoID)
                    Dim FechaCobro As Date

                    'strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(DPValeID), FechaCobro, dtDetalleVale)

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (20.02.2016): Comentamos pues se obtienen el numero de quincenas del vale 
                    '----------------------------------------------------------------------------------------
                    ''--------------------------------------------------------------------------------------------
                    '' JNAVA (27.07.2016): Obtenemos Promociones en base a configuracion de validador 
                    ''--------------------------------------------------------------------------------------------
                    'If oConfigCierreFI.AplicarS2Credit Then
                    '    '----------------------------------------------------------------------------------------
                    '    ' JNAVA (27.07.2016): Obtiene las promociones disponibles en base a la plaza, monto y fecha
                    '    '----------------------------------------------------------------------------------------
                    '    strQuin = oS2Credit.ObtenerPromociones(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(DPValeID), FechaCobro, dtDetalleVale)
                    'Else
                    '    strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(DPValeID), FechaCobro, dtDetalleVale)
                    'End If
                    ''--------------------------------------------------------------------------------------------

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (20.02.2016): Obtenemos el numero de quincenas del vale 
                    '----------------------------------------------------------------------------------------
                    If IsNumeric(DPValeID.Trim()) Then
                        DPValeID = DPValeID.Trim().PadLeft(10, "0")
                    End If
                    Dim oS2Credit As New ProcesosS2Credit
                    Dim oDPVale As New cDPVale
                    oDPVale.I_RUTA = "X"
                    oDPVale.INUMVA = DPValeID.Trim()

                    '----------------------------------------------------------------------------------------
                    '  Obtenemos informacion del DPVale
                    '----------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then
                        oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
                    Else
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    End If

                    '----------------------------------------------------------------------------------------------------------
                    ' Validamos si es revale o no para obtener quincenas correspondientes y Fecha de Cobro
                    '----------------------------------------------------------------------------------------------------------
                    If oDPVale.InfoDPVALE.Rows(0).Item("Orige") <> String.Empty Then
                        strQuin = CStr(oDPVale.InfoDPVALE.Rows(0)!ONUMDE)
                        FechaCobro = CDate(oDPVale.InfoDPVALE.Rows(0)!OFECCO)
                    Else
                        strQuin = CStr(oDPVale.InfoDPVALE.Rows(0)!NUMDE)
                    End If
                    '----------------------------------------------------------------------------------------

                End If


                '--Cargamos Vendedores
                Me.ebCodVendedor.Text = Pedido.CodVendedor
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(ebCodVendedor.Text, oVendedor)
                If oVendedor.ID <> String.Empty Then
                    ebPlayerDescripcion.Text = oVendedor.Nombre
                    oFactura.CodVendedor = oVendedor.ID
                Else
                    ebPlayerDescripcion.Text = ""
                End If
                '--------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 03/05/2013: Cargamos Detalle del pedido
                '--------------------------------------------------------------------------------------------------------------------
                dsDetalle.Tables(0).Rows.Clear()
                Dim art As Articulo = oArticuloMgr.Create()
                For Each data As PedidoDetalles In Me.Pedido.PedidosDetalles
                    Dim oRowGrid As DataRow = dsDetalle.Tables(0).NewRow()
                    art.ClearFields()
                    oArticuloMgr.LoadInto(data.CodArticulo, art)
                    With oRowGrid
                        .Item("CodProveedor") = art.CodArtProv
                        .Item("Codigo") = data.CodArticulo
                        .Item("Talla") = data.Numero
                        .Item("Cantidad") = data.Cantidad
                        .Item("Importe") = Math.Round(data.PrecioUnit)
                        .Item("Total") = Math.Round(data.Total, 2)
                        .Item("Descuento") = data.CantDescuentoSistema
                        .Item("Adicional") = data.Descuento
                    End With

                    dsDetalle.Tables(0).Rows.Add(oRowGrid)
                Next
                'dgHeader.DataSource = Nothing
                'dgHeader.DataSource = oFactura.Detalle.Tables(0)
                'FormateaGrid()
                explorerBar1.Enabled = False
                Me.UiCommandBar2.Commands("menuArchivoImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True

                ebStatus.Text = Me.Pedido.Status
                ebSubTotal.Value = Me.Pedido.SubTotal
                ebIVA.Value = Me.Pedido.IVA
                ebImporteTotal.Value = Me.Pedido.Total

                Label1.Text = "Folio Pedido  :"
                EbFolioSAP.Text = Me.Pedido.FolioSAP
                'Calculamos total de piezas
                Me.nebTotalPiezas.Value = dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")

            End If

            bolIsOpenFacturaInput = False

        End If

        bolMenuAbrir = False

    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/05/2013 Imprime todos las facturas y los articulos pendientes por entregar del Pedido
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Function ImprimirPedido()
        Dim ofrmPago As New frmPago
        'ofrmPago.intFolioDPVale = DPValeID
        ofrmPago.StrFolioDPVale = DPValeID
        


        '-----------------------------------------------------------------------------------
        ' JNAVA (12.02.2015):  Preparamos los datos para el ticket de Seguro cuando es reimpresion
        '-----------------------------------------------------------------------------------
        PrepararReimpresionSeguroDPVale(ofrmPago)
        '-----------------------------------------------------------------------------------
        'FLIZARRAGA 08/06/2017: Reeimprimir voucher de Banamex
        '-----------------------------------------------------------------------------------
        ReeimpresionBanamex(Pedido.FormasPago)

        ofrmPago.FechaPrimerPago = CalcularFechaPrimerPago()

        '-----------------------------------------------------------------------------------
        ' JNAVA (12.02.2015): (MOVIDO) Reimprimimos pedido
        '-----------------------------------------------------------------------------------
        ofrmPago.ActionPreviewFacturacionSH(Me.Pedido.PedidoID, False, "Facturacion", False, "", strQuin)

        '---------------------------------------------------
        ' JNAVA(10.02.2015): Reimpresion de Seguro de vida
        '---------------------------------------------------
        If Not ofrmPago.DatosTicketSeguro Is Nothing AndAlso ofrmPago.DatosTicketSeguro.Count > 0 Then
            ofrmPago.ImprimirTicketSeguro()
        End If

        If Pedido.CodTipoVenta.Trim() = "V" Then
            If Not oDPValeSAP Is Nothing Then
                If IsNumeric(oDPValeSAP.IDDPVale) = False Then
                    ofrmPago.ImprimeValeElectronico(oDPValeSAP)
                End If
            End If
        End If

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Resta las cantidades del pedido "SiHay"
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function RestarCantidadesSiHay(ByVal dtMateriales As DataTable) As DataTable
        Dim dtArticulos As DataTable = dtMateriales.Copy()
        dtArticulos.TableName = "MaterialesLibres"
        For Each row As DataRow In dtArticulos.Rows
            If CInt(row!SinExistencia) > 0 Then
                row("Cantidad") = CInt(row!Cantidad) - CInt(row!SinExistencia)
            End If
        Next
        dtArticulos.AcceptChanges()
        Return dtArticulos
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/05/2013: Crear la tabla de material faltante que no cumple la existencia
    '-------------------------------------------------------------------------------------------------------------------------------

    Public Function CreateMaterialFaltante() As DataTable
        Dim dtMaterial As New DataTable("MaterialFaltante")
        dtMaterial.Columns.Add("CodArticulo", GetType(String))
        dtMaterial.Columns.Add("Talla", GetType(String))
        dtMaterial.Columns.Add("Existencia", GetType(Integer))
        dtMaterial.Columns.Add("Faltante", GetType(Integer))
        dtMaterial.AcceptChanges()
        Return dtMaterial
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 26/11/2021: Crear la tabla de materiales que cumplen con la existencia
    '-------------------------------------------------------------------------------------------------------------------------------

    Public Function MaterialesOk() As DataTable
        Dim dtMaterial As New DataTable("Materiales")
        dtMaterial.Columns.Add("CodArticulo", GetType(String))
        dtMaterial.Columns.Add("Cantidad", GetType(Integer))
        Return dtMaterial
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 26/11/2021: Agregar el material a la lista de disponibles si no está repetido
    '-------------------------------------------------------------------------------------------------------------------------------

    Public Sub AgregaMaterial(ByRef dtMateriales As DataTable, ByVal codigo As String, ByVal cantidad As Integer)
        Dim fila As DataRow = dtMateriales.NewRow()
        fila("CodArticulo") = codigo
        fila("Cantidad") = cantidad
        dtMateriales.Rows.Add(fila)
    End Sub


    Public Function ValidaExistencia(ByVal dtMateriales As DataTable, ByVal codigo As String) As Boolean
        Dim encontrado As Boolean = False

        For Each oRow As DataRow In dtMateriales.Rows
            Dim valor As String = CStr(oRow("CodArticulo"))
            If valor = codigo Then
                encontrado = True
                Exit For
            End If
        Next

        Return encontrado
    End Function




    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/05/2013: Habilita o Desahabilita el cuadro de insercion de articulos manual
    '--------------------------------------------------------------------------------------------------------------------------------

    Private Sub EnableControls(ByVal enable As Boolean)
        explorerBar2.Enabled = enable
        explorerBar3.Enabled = enable
        dgHeader.Enabled = enable
        EbFolioSAP.Enabled = enable
        ebFechaFactura.Enabled = enable
        ebCodCaja.Enabled = enable
        ebFolioApartado.Enabled = enable
        ebTipoVenta.Enabled = enable
        ebStatus.Enabled = enable
        ebClienteID.Enabled = enable
        ebClienteDescripcion.Enabled = enable
        ebCodVendedor.Enabled = enable
        ebPlayerDescripcion.Enabled = enable
        btnAltaCliente.Enabled = enable
        chkVentaManual.Enabled = enable
        txtFolioVentaManual.Enabled = enable
        If ebClienteID.Value = 99999 Then
            chkPromoEspecial.Enabled = False
        Else
            chkPromoEspecial.Enabled = enable
        End If
        btnFormaPago.Enabled = enable
    End Sub

    Private Sub ShowPanelInsert()
        txtCantidad.Value = 0
        PanelAgregarArticulo.Location = New Point(216, 145)
        PanelAgregarArticulo.Visible = True
        boolManual = True
        EnableControls(False)
        PanelAgregarArticulo.Focus()
        txtPopupCodigo.Focus()
        txtCantidad.Text = 1
        txtPopupTalla.Text = String.Empty
        txtPopupImporte.Text = "0"
        txtPopupTotal.Text = "0"
        txtPopupDescuento.Text = "0"
        txtPopupAdicional.Text = String.Empty

    End Sub

    Private Sub txtPopupCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPopupCodigo.Validating
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 19.11.2013: Se cambio a que cargara la info del codigo en el validating porque si no daban enter no cargaba el precio y no sumaba el
        'el importe al total del pedido SH
        '------------------------------------------------------------------------------------------------------------------------------------------------
        CargarCodigo()
    End Sub

    Private Sub txtPopupTalla_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPopupTalla.Validating
        '-----------------------------------------------------------------------------
        ' JNAVA (04.03.2016): Validamos talla
        '-----------------------------------------------------------------------------
        If txtPopupCodigo.Text.Trim() <> "" Then
            '-----------------------------------------------------------------------------
            ' JNAVA (31.01.2016): Si no se encuentra la talla, no continua con el proceso
            '-----------------------------------------------------------------------------
            If Not CargarTalla() Then
                Exit Sub
            End If
            '-----------------------------------------------------------------------------
        Else
            txtPopupTalla.Text = String.Empty
        End If
        '-----------------------------------------------------------------------------
        Me.txtCantidad.Focus()
    End Sub

#End Region

#Region "Seguros de Vida DPVale"

    '---------------------------------------------------
    ' JNAVA (12.02.2015): Preparamos la reimpresion del seguro 
    '---------------------------------------------------
    Private Sub PrepararReimpresionSeguroDPVale(ByRef oPago As frmPago)

        If oConfigCierreFI.GenerarSeguro Then 'Revisamos config
            If oFactura.CodTipoVenta = "V" Then 'Revisamos Tipo de venta
                Dim oDPVale As New cDPVale
                Dim DPValeID As String
                Dim dtSeguro As DataTable
                Dim FechaCobro As Date
                Dim Quincenas As String
                Dim ClienteDPVale As String
                Dim strFecha As String
                Dim Beneficiario As String = String.Empty
                Dim SeguroID As String = "1"
                '---------------------------------------------------
                ' Obtenemos el DPValeID de la Factura
                '---------------------------------------------------
                DPValeID = oFacturaMgr.GetDPVALEID(0, Pedido.PedidoID)
                If IsNumeric(DPValeID.Trim()) Then
                    DPValeID = DPValeID.Trim().PadLeft(10, "0")
                End If
                '---------------------------------------------------
                ' Validamos el DPValeID obtenido de la Factura
                '---------------------------------------------------
                If DPValeID <> "" Then
                    Beneficiario = oS2Credit.ObtenerBeneficiarioSeguro(DPValeID.Trim(), FechaCobro)
                    '---------------------------------------------------
                    ' Validamos que existan registros en los Seguros de Calzado
                    '---------------------------------------------------
                    If Beneficiario.Trim() <> "" Then

                        '--------------------------------------------------------------------------
                        ' Validamos DPVale en SAP para sacar el Cliente, Quincenas Fecha de cobro
                        '--------------------------------------------------------------------------
                        oDPVale.I_RUTA = "X"
                        oDPVale.INUMVA = DPValeID.Trim()
                        '----------------------------------------------------------------------------------------
                        ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                        '----------------------------------------------------------------------------------------
                        Dim oS2Credit As New ProcesosS2Credit
                        ' oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (18.07.2016): Valida DPVale
                        '----------------------------------------------------------------------------------------
                        Dim FirmaDistribuidor As Image = Nothing
                        Dim NombreDistribuidor As String = String.Empty
                        If oConfigCierreFI.AplicarS2Credit Then
                            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                        Else
                            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                        End If
                        '----------------------------------------------------------------------------------------
                        oDPValeSAP = GetObjectDPValeSAP(oDPVale)
                        If oDPVale.InfoDPVALE.Rows.Count > 0 Then

                            '--------------------------------------------------------------------------
                            ' Obtenemos Detalle del DPVale
                            '--------------------------------------------------------------------------
                            ClienteDPVale = oDPVale.InfoDPVALE.Rows(0)!CODCT
                            Quincenas = oDPVale.InfoDPVALE.Rows(0)!NUMDE
                            'strFecha = oDPVale.InfoDPVALE.Rows(0)!FECCO
                            'If strFecha.Trim <> "" AndAlso CLng(strFecha.Trim) > 0 Then
                            '    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                            '    FechaCobro = CDate(strFecha)
                            'Else
                            '    FechaCobro = Today
                            'End If
                            'strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                            'FechaCobro = CDate(strFecha)

                            '---------------------------------------------------------------
                            'Obtenemos Beneficiarios
                            '---------------------------------------------------------------
                            oPago.Beneficiarios = Beneficiario
                            '-----------------------------------------------------------------------------------
                            ' Obtenemos los datos de la aseguradora
                            '-----------------------------------------------------------------------------------
                            Dim oDatosAseguradora As New Hashtable
                            Dim oRowAseguradora As DataRow
                            oS2Credit.ObtenerSeguroPorID(SeguroID, 0, oRowAseguradora)

                            If Not oRowAseguradora Is Nothing Then
                                oDatosAseguradora.Add("purchaseId", oRowAseguradora("name"))
                                oDatosAseguradora.Add("name", oRowAseguradora("name"))
                                oDatosAseguradora.Add("rate", oRowAseguradora("rate"))
                                oDatosAseguradora.Add("business_name", oRowAseguradora("business_name"))
                                oDatosAseguradora.Add("prime_amount", oRowAseguradora("prime_amount"))
                                oDatosAseguradora.Add("insurance_policy", oRowAseguradora("insurance_policy"))
                                oDatosAseguradora.Add("url", oRowAseguradora("url"))
                                oDatosAseguradora.Add("phone", oRowAseguradora("phone"))
                                oDatosAseguradora.Add("email", oRowAseguradora("email"))
                            End If
                            '-----------------------------------------------------------------------------------
                            'FLIZARRAGA 22/05/2017: Se cargan los montos del seguro y fechas
                            '-----------------------------------------------------------------------------------
                            oDatosAseguradora("insurance") = CDec(oDPVale.InfoDPVALE.Rows(0)!INSURANCE)
                            oDatosAseguradora("amount") = CDec(oDPVale.InfoDPVALE.Rows(0)!AMOUNT)
                            oDatosAseguradora("FechaPrimeraAmortizacion") = CDate(oDPVale.InfoDPVALE.Rows(0)!DATESTART)
                            oDatosAseguradora("CuentaAmortizaciones") = CInt(oDPVale.InfoDPVALE.Rows(0)!CUENTAMORTIZACIONES)
                            oDatosAseguradora("MontoAmortizaciones") = CDec(oDPVale.InfoDPVALE.Rows(0)!MONTOAMORTIZACIONES)
                            oDatosAseguradora("datestart") = oFactura.Fecha
                            oDatosAseguradora("dateend") = CDate(oDPVale.InfoDPVALE.Rows(0)!DATEEND)
                            oDatosAseguradora("numde") = Quincenas
                            oDatosAseguradora("loan_term") = CInt(oDPVale.InfoDPVALE.Rows(0)!LOANTERM)
                            oDatosAseguradora("idOffer") = GetIdOffer(oDPVale, oFactura.Fecha)
                            '---------------------------------------------------
                            ' JNAVA (12.02.2015): Obtenemos los datos del Financiamiento
                            '---------------------------------------------------
                            oPago.DatosTicketSeguro.Clear()
                            oPago.DatosTicketSeguro = oPago.PrepararDatosTicketS2Credit(ClienteDPVale, Quincenas, FechaCobro, "V", oDatosAseguradora)
                            'oPago.DatosTicketSeguro = oPago.PrepararDatosTicket(ClienteDPVale, Quincenas, FechaCobro, "V")
                            If oPago.DatosTicketSeguro Is Nothing OrElse oPago.DatosTicketSeguro.Count <= 0 Then
                                MessageBox.Show("Ocurrio un error al obtener los datos del Financiamiento del Seguro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If

                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "Modificacion de Beneficiarios"
    Private Sub ModificarBeneficiario()
        oAppContext.Security.CloseImpersonatedSession()
        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.ModificarBeneficiario") Then
            Dim frmModificar As New frmModificarBeneficiario
            frmModificar.ShowDialog()
        End If
        oAppContext.Security.CloseImpersonatedSession()

    End Sub
#End Region

#Region "Banamex"

    Private Sub ReeimpresionBanamex(ByVal dtFormasPago As DataTable)
        If oConfigCierreFI.PagosBanamex Then
            Dim pay As New uPaydll.upaydll
            Dim DPValeId As String = ""
            For Each row As DataRow In dtFormasPago.Rows
                If CStr(row("CodFormasPago")).Trim() = "TACR" Or CStr(row("CodFormasPago")).Trim() = "TADB" Then
                    DPValeId = CStr(row("DPValeID"))
                    pay.reimpresion(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex, DPValeId)
                End If
            Next
        End If
    End Sub

#End Region

#Region "Vigencia Poliza Seguro"

    Private Function GetIdOffer(ByVal ODPVale As cDPVale, ByVal FechaFactura As DateTime) As String
        Dim idOffer As String = ""
        Dim dtDetalleVale As New DataTable
        Dim NumeroQuin As Integer
        Dim rows() As DataRow, Feccr As DateTime
        Feccr = Mid(ODPVale.InfoDPVALE.Rows(0)!FECCR, 7, 2) & "/" & Mid(ODPVale.InfoDPVALE.Rows(0)!FECCR, 5, 2) & "/" & Mid(ODPVale.InfoDPVALE.Rows(0)!FECCR, 1, 4)
        NumeroQuin = oS2Credit.ObtenerPromociones(oAppSAPConfig.Plaza, FechaFactura, CStr(ODPVale.InfoDPVALE.Rows(0)!NUMDE), ODPVale.INUMVA, Feccr, dtDetalleVale)
        If Not dtDetalleVale Is Nothing Then
            rows = dtDetalleVale.Select("NUMDE=" & CStr(ODPVale.InfoDPVALE.Rows(0)!NUMDE), "")
            If rows.Length > 0 Then
                If CStr(rows(0)!PromocionID).Trim() <> "" Then
                    If Feccr > FechaFactura Then
                        idOffer = CStr(rows(0)!PromocionID)
                    End If
                End If
            End If
        End If
        Return idOffer
    End Function

#End Region

#Region "Vale electronico"

    Private Function GetObjectDPValeSAP(ByVal oDPVale As cDPVale) As cDPValeSAP
        Dim oDPValeSAP As New cDPValeSAP()
        oDPValeSAP.EsCalzado = oDPVale.EsCalzado
        oDPValeSAP.ValeElectronico = oDPVale.EsElectronico
        oDPValeSAP.PromocionValeElectronico = oDPVale.PromocionValeElectronico
        oDPValeSAP.InfoDPVALE = oDPVale.InfoDPVALE
        oDPValeSAP.IDDPVale = oDPVale.INUMVA
        oDPValeSAP.Plaza = oDPVale.EPLAZA
        If oConfigCierreFI.AplicarS2Credit Then
            oDPValeSAP.LimiteCredito = oDPVale.LimiteCreditoPrestamo
        Else
            oDPValeSAP.LimiteCredito = oDPVale.LimiteCredito
        End If
        Dim oRow As DataRow
        oRow = oDPValeSAP.InfoDPVALE.Rows(0)
        oDPValeSAP.IDAsociado = CStr(oRow("KUNNR"))
        If Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECCR"), 1, 4) = "0000" Then
            oDPValeSAP.FechaExpedicion = Now.Date
            oDPValeSAP.FechaCreacion = Now.Date
        Else
            oDPValeSAP.FechaExpedicion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
            oDPValeSAP.FechaCreacion = Mid(oRow("FECCR"), 7, 2) & "/" & Mid(oRow("FECCR"), 5, 2) & "/" & Mid(oRow("FECCR"), 1, 4)
        End If

        If Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 7, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 5, 2) = "00" Or Mid(oDPVale.InfoDPVALE.Rows(0)("FECIN"), 1, 4) = "0000" Then
            oDPValeSAP.FechaInicial = Now.Date
        Else
            oDPValeSAP.FechaInicial = Mid(oRow("FECIN"), 7, 2) & "/" & Mid(oRow("FECIN"), 5, 2) & "/" & Mid(oRow("FECIN"), 1, 4)
        End If

        oDPValeSAP.IDCliente = CStr(oRow("CODCT")).PadLeft(10, "0")
        oDPValeSAP.RMONTODPVALE = CDec(oRow("Monto"))
        oDPValeSAP.RPARES_PZAS = CInt(oRow("Pares"))
        If CStr(oRow("REVAL")) = "X" Then
            oDPValeSAP.IsRevale = True 'Para saber SI es Revale
        Else
            oDPValeSAP.REVALE = False
            oDPValeSAP.IsRevale = False
        End If


        If CStr(oRow("ZREVAL2")) = "X" Then
            oDPValeSAP.IsReRevale = True 'Para saber SI es ReRevale
        Else
            oDPValeSAP.IsReRevale = False 'Para saber si NO es ReRevale
        End If

        '-----------------------------------------------------------------------------------
        'FLIZARRAGA 21/07/2017: Identifica si es un vale electronico
        '-----------------------------------------------------------------------------------

        If oDPValeSAP.ValeElectronico Then
            oDPValeSAP.MontoElectronico = oDPVale.MontoElectronico
        End If
        Return oDPValeSAP
    End Function

#End Region

#Region "Fecha de primer Pago Vale"

    Private Function CalcularFechaPrimerPago() As DateTime
        Dim Fecha As New DateTime()
        Dim oS2Credit As New ProcesosS2Credit
        Dim oDPVale As New cDPVale
        Dim DPValeID As String
        '---------------------------------------------------
        ' Obtenemos el DPValeID de la Factura
        '---------------------------------------------------
        DPValeID = oFacturaMgr.GetDPVALEID(0, Pedido.PedidoID)
        If DPValeID.Trim() <> "" Then
            If IsNumeric(DPValeID.Trim()) Then
                DPValeID = DPValeID.Trim().PadLeft(10, "0")
            End If
            oDPVale.INUMVA = DPValeID
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
            Fecha = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
            Fecha = GetFechaFechaPrimerPago(Fecha)
        End If
        Return Fecha
    End Function

    Private Function GetFechaFechaPrimerPago(ByVal Fecha As DateTime) As DateTime
        Dim FechaCobro As DateTime
        Dim FechaActual As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        If Fecha.Day >= 1 And Fecha.Day <= 6 Then
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, 15)
        ElseIf Fecha.Day >= 7 AndAlso Fecha.Day <= 20 Then
            Dim dia As Integer = 0
            Select Case Fecha.Month
                Case 1
                    dia = 31
                Case 2
                    dia = 28
                Case 3
                    dia = 31
                Case 4
                    dia = 30
                Case 5
                    dia = 31
                Case 6
                    dia = 30
                Case 7
                    dia = 31
                Case 8
                    dia = 31
                Case 9
                    dia = 30
                Case 10
                    dia = 31
                Case 11
                    dia = 30
                Case 12
                    dia = 31
            End Select
            FechaCobro = New DateTime(Fecha.Year, Fecha.Month, dia)
        ElseIf Fecha.Day >= 21 AndAlso Fecha.Day <= 31 Then
            FechaCobro = New DateTime(Fecha.AddMonths(1).Year, Fecha.AddMonths(1).Month, 15)
        End If
        Return FechaCobro
    End Function

#End Region

#Region "Mejoras de Lealtad"

    Private Function ValidarTarjetaLealtadEnDetalle() As Boolean
        Dim valido As Boolean = True
        Dim ArtMgr As New CatalogoArticuloManager(oAppContext)
        Dim Art As Articulo = ArtMgr.Create()
        Dim ConteoPosicionTarjeta As Integer = 0
        For Each row As DataRow In Me.dsDetalle.Tables(0).Rows
            Art.ClearFields()
            ArtMgr.LoadInto(CStr(row("Codigo")), Art)
            If Art.CodArtProv.Contains("CARD") Then
                If CInt(row("Cantidad")) > 1 Then
                    MessageBox.Show("No puede haber más de una tarjeta de lealtad en la venta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                ConteoPosicionTarjeta += 1
            End If
        Next
        If ConteoPosicionTarjeta > 1 Then
            MessageBox.Show("No puede haber más de una tarjeta de lealtad en la venta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            valido = False
        End If
        Return valido
    End Function

#End Region

#Region "Correcciones Ventas Incompletas"


    Private Function ProductosEnAclaracionLocal() As DataTable
        Dim dtArticulos As DataTable = GetProductosAclaracion()
        Dim dtResult As DataTable

        For Each oRow As DataRow In Me.dsDetalle.Tables(0).Rows
            dtResult = oFacturaMgr.GetArtAclaracion(oRow("Codigo"))
            If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
                dtArticulos.ImportRow(dtResult.Rows(0))
            End If
        Next

        Return dtArticulos

    End Function

    Private Function ProductosEnAclaracion() As DataTable
        Dim strCentro As String = String.Empty
        Dim oParametros As New Dictionary(Of String, Object)
        Dim dtResult As DataTable

        strCentro = oSAPMgr.Read_Centros


        'Obtener la información para ejecutar la RFC
        With oParametros

            ' ------------------------------------------------------------------
            ' Llenamos datos de los productos
            '------------------------------------------------------------------
            Dim oArticulos As New List(Of Dictionary(Of String, Object))

            For Each oRow As DataRow In Me.dsDetalle.Tables(0).Rows

                Dim oArt As New Dictionary(Of String, Object)

                With oArt
                    .Add("WERKS", strCentro)
                    .Add("MATNR", oRow("Codigo"))

                End With
                oArticulos.Add(oArt)
            Next

            '------------------------------------------------------------------
            ' Metemos los datos de los articulos para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("SapPiCenmat", oArticulos)
        End With


        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos_api/s1", "POST")
        dtResult = oRetail.SapZFmProducAclaracion(oParametros)

        Return dtResult

    End Function

    Private Function GetDetalleCantidadesLibres(ByVal dtDetalles As DataTable) As DataTable
        Dim dtArticulosLibres As DataTable = dtDetalles.Copy()
        Dim dtLibres As DataTable = Nothing
        dtArticulosLibres.Columns.Add("Libres", GetType(Integer))
        If Me.SiHay.Tables.Contains("MaterialesLibres") Then
            dtLibres = Me.SiHay.Tables("MaterialesLibres")
            For Each row As DataRow In dtArticulosLibres.Rows
                Dim codigo As String = CStr(row!Codigo)
                Dim talla As String = CStr(row!Talla)
                Dim cantidad As Integer = CInt(row!Cantidad)
                Dim suma As Decimal = dtLibres.Compute("SUM(Libres)", "Codigo='" & codigo & "' AND Talla='" & talla & "'")
                row("Libres") = suma
            Next
            dtArticulosLibres.AcceptChanges()
        End If
        Return dtArticulosLibres
    End Function


    Private Sub AjustaProductosAclaracion()
        Dim dtAclaracion As DataTable
        dtAclaracion = ProductosEnAclaracionLocal()
        Dim dtArticulos As DataTable = Me.dsDetalle.Tables(0)


        If Not dtAclaracion Is Nothing AndAlso dtAclaracion.Rows.Count > 0 Then
            For Each oRow As DataRow In dtArticulos.Rows
                Dim cantidad As Integer = oRow!Cantidad
                Dim libres As Integer = oRow!Stock '  oRow!ConExistencia
                Dim faltantes As Integer = oRow!SinExistencia
                Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "CodArticulo = '" & oRow!Codigo & "'"))

                If reserva > 0 Then
                    If reserva > libres Then
                        oRow!ConExistencia = 0
                        oRow!SinExistencia = faltantes + libres
                    Else
                        Dim enTienda = libres - reserva
                        If enTienda < cantidad Then
                            oRow!ConExistencia = enTienda
                            oRow!SinExistencia = cantidad - enTienda
                        End If
                    End If
                End If
            Next
            dtArticulos.AcceptChanges()
        End If

    End Sub


    Private Sub AjustaTotales()
        Dim dtAclaracion As DataTable
        dtAclaracion = ProductosEnAclaracion()
        Dim dtArticulos As DataTable = Me.dsDetalle.Tables(0)


        For Each oRow As DataRow In dtArticulos.Rows

            Dim cantidad As Integer = oRow!Cantidad
            Dim libres As Integer = oRow!Stock '  oRow!ConExistencia
            Dim faltantes As Integer = oRow!SinExistencia
            Dim reserva = Convert.ToInt32(dtAclaracion.Compute("SUM(Cantidad)", "MATNR = '" & oRow!Codigo & "'"))

            If reserva > 0 Then
                If reserva > libres Then
                    oRow!ConExistencia = 0
                    oRow!SinExistencia = faltantes + libres
                Else
                    Dim enTienda = libres - reserva
                    If enTienda < cantidad Then
                        oRow!ConExistencia = enTienda
                        oRow!SinExistencia = cantidad - enTienda
                    End If
                End If
            End If

        Next
        dtArticulos.AcceptChanges()
    End Sub

    Private Sub FormaPago()
        btnFormaPago.Focus()
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 23/11/2018: Se valida que la suma del detalle cuadre con la cabecera
        '------------------------------------------------------------------------------------------------------
        If ValidaTotalDetalleCabecera() = False Then
            MessageBox.Show("El total no coincide con la suma del detalle", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 18/04/2013: Validar Existencia en SiHay
        '-----------------------------------------------------------------------------------------------------------------------------------------

        Dim minima As DataTable
        SiHay = New DataSet
        ActualizarExistenciasSH()

        'AjustaTotales()

        AjustaProductosAclaracion()

        If EsVentaSiHay() = True Then
            If ValidarExistenciaSiHay() = False OrElse ValidarImporteMinimoSH() = False OrElse ValidarDescuentoMaximoSH() = False Then
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            If FacturacionSiHay > 0 Then
                Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
                Me.dtCantidadLibre = RestarCantidadesSiHay(Me.dsDetalle.Tables(0))
                If ValidarMaterialesNegadosSH(Me.dtCantidadLibre, dtNegadosSH, "PF,P,RP", vApartadoInstance) = False Then
                    ShowFormNegadosSH(dtNegadosSH)
                    Exit Sub
                End If
            End If

            If Not oAppSAPConfig.SiHay Then
                FormExistenciasSH = New frmConsultaSiHay
                FormExistenciasSH.CargarExistenciasMinimos(GetArticulosSinExistencia())
                If FormExistenciasSH.FueAceptadoMinimos() = False Then
                    Exit Sub
                End If
                minima = FormExistenciasSH.GetDataSourceMinimo()
                If Not minima Is Nothing Then
                    SiHay.Tables.Add(minima)
                End If
            End If


            If SiHay.Tables.Contains("MaterialesLibres") = False Then
                SiHay.Tables.Add(Me.dtCantidadLibre)
            End If

            '-----------------------------------------------------------------------------------------------------------------------------------------
            'MLVARGAS 19/05/2022: Validar Solicitudes en Ecommerce
            '-----------------------------------------------------------------------------------------------------------------------------------------
            Dim dtNegados As DataTable
            Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
            Dim UserNameDesmarca As String = ""
            Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP
            Dim dtArticuloLibre As DataTable = GetDetalleCantidadesLibres(dsDetalle.Tables(0))


            If ValidarMaterialesParaNegarEC(dtNegados, dtArticuloLibre, dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
                Exit Sub
            End If

        Else
            MessageBox.Show("No se puede facturar productos que haya existencias en la Tienda", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Validar Inicio de Dia
        '-----------------------------------------------------------------------------------------------------------------------------------------
        Dim oInicioDiaMgr As New InicioDiaManager(oAppContext)
        If oInicioDiaMgr.Load(Format(Date.Now, "Short Date"), oAppContext.ApplicationConfiguration.Almacen) = 0 Then
            MsgBox("El Dia " & Format(Date.Now, "dd-MMM-yyyy") & " no ha sido Iniciado." & vbCrLf & "Verifique la Fecha del Sistema Operativo.", MsgBoxStyle.Exclamation, "DPTienda")
            oInicioDiaMgr = Nothing
            Exit Sub
        End If
        oInicioDiaMgr = Nothing
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Validar Cierre de Dia
        '-----------------------------------------------------------------------------------------------------------------------------------------
        Dim oCierreDiasMgr As New CierreDiaManager(oAppContext)
        If (oCierreDiasMgr.ValidarCierreDia(Date.Now) = False) Then
            MsgBox("El Dia " & Format(Date.Now, "dd-MMM-yyyy") & " se encuentra Cerrado." & vbCrLf & "Verifique la Fecha del Sistema Operativo.", MsgBoxStyle.Exclamation, "DPTienda")
            oCierreDiasMgr = Nothing
            Exit Sub
        End If
        oCierreDiasMgr = Nothing
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Validaciones Generales
        '-----------------------------------------------------------------------------------------------------------------------------------------

        If oFactura.Total > 0 Then
            If oConfigCierreFI.UsarHuellas Then
                If (oFactura.ClienteId = 10000000 Or oFactura.ClienteId = 0) AndAlso (oFactura.CodTipoVenta <> "P" OrElse oConfigCierreFI.RegistroPGOpcional = False) AndAlso (oFactura.CodTipoVenta <> "V") Then
                    MsgBox("Asigne Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
                    ebClienteID.Focus()
                    Exit Sub
                End If
            Else
                If (oFactura.ClienteId = 10000000 Or oFactura.ClienteId = 0) AndAlso oFactura.CodTipoVenta = "P" Then
                    MsgBox("Asigne Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
                    ebClienteID.Focus()
                    Exit Sub
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que ningun codigo cueste menos de 1 peso incluyendo el IVA para que no truen en SAP
            '-----------------------------------------------------------------------------------------------------------------------------------------
            Dim strMsg As String = ""
            If ValidaImporteCostoPorCodigo(dsDetalle.Tables(0), strMsg) = False Then
                MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que si es PG si no capturan al cliente ponga la razon de no registro
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If (ebTipoVenta.Value <> "P" AndAlso ebTipoVenta.Value <> "V" AndAlso ebTipoVenta.Value <> "E") AndAlso oFactura.ClienteId <= 1 Then
                MsgBox("Por el Tipo de Venta es necesario ingresar Código de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
                ebClienteID.Focus()
                Exit Sub
            ElseIf ebTipoVenta.Value = "P" AndAlso oConfigCierreFI.UsarHuellas Then
                Dim FolioSAP As String = ""
                If oFactura.ClienteId <= 0 Then
                    If EsVentaSiHay() = True Then
                        If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
                            MessageBox.Show("Debe ingresar un cliente si quiere realizar una venta con formato SiHay", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Else
                        If MessageBox.Show("¿Desea registrar los datos del cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
                                GoTo EspecificaRazon
                            End If
                        ElseIf oFactura.RazonRechazo.Trim = "" Then
EspecificaRazon:
                            'oFactura.RazonRechazo = InputBox("Especifique la razón por la que no registró los datos del cliente.", Me.Text)
                            Dim oFrmRazones As New frmRazonesRechazo
                            oFrmRazones.ModuloOrigen = "FA"
                            If oFrmRazones.ShowDialog = DialogResult.OK Then
                                oFactura.RazonRechazo = oFrmRazones.cmbRazones.Text
                                oFactura.RazonRechazoID = oFrmRazones.cmbRazones.Value
                                'End If
                                'If oFactura.RazonRechazo.Trim = "" OrElse oFactura.RazonRechazo.Trim.Length < 5 Then
                            Else
                                'MessageBox.Show("Es necesario seleccionar una razón de rechazo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'GoTo EspecificaRazon
                                Exit Sub
                            End If
                        End If
                    End If

                    'ElseIf oFingerPrintMgr.IsClientePGEnFactura(oFactura.ClienteId, FolioSAP) Then
                    '    oFactura.RazonRechazo = "El cliente ya habia sido registrado anteriormente con el codigo: " & CStr(oFactura.ClienteId).PadLeft(10, "0") & _
                    '                            " en la Factura: " & FolioSAP
                    '    oFactura.RazonRechazoID = 0
                Else
                    oFactura.RazonRechazo = ""
                    oFactura.RazonRechazoID = 0
                End If
            End If
            If oFactura.CodVendedor = String.Empty Then
                MsgBox("Asigne Código de Vendedor.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
                ebCodVendedor.Focus()
                Exit Sub
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Si es instancia de Nota de Credito
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If vNCInstance = True Then
                If ebImporteTotal.Value < oDevolucionDPvale.MontoDPVale Then
                    Dim dif As Double
                    dif = oDevolucionDPvale.MontoDPVale - ebImporteTotal.Value
                    If Not (dif >= 0.01 AndAlso dif <= 0.99) Then
                        MsgBox("La compra debe ser igual o mayor a la cantidad devuelta a Dportenis Vale", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                        grdDetalle.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If oValeCaja.ValeCajaID > 0 Then
                If oFactura.Total < oValeCaja.Importe Then
                    MsgBox("La compra debe ser igual o mayor a la cantidad devuelta", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                    grdDetalle.Focus()
                    Exit Sub
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Catalogo
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "D" Then
                If strCat = "S" Then
                Else
                    If strLlevaCatalogo = "" Then
                        Dim strDesc As String = ""
                        For Each oRow As DataRow In dsDetalle.Tables(0).Rows
                            If oRow("Adicional") > 0 Then
                                strDesc = "S"
                                Exit For
                            Else
                                strDesc = ""
                            End If
                        Next

                        If strDesc = "S" Then
                            MsgBox("Este asociado no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Information, Me.Text)
                        Else
                            MsgBox("Este asociado no tiene descuento por que no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Information, Me.Text)
                        End If

                    End If
                End If
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Si es Facilito se pide Autorizacion
            'Fonacot Facilito change --->And oValeCaja.ValeCajaID = 0
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If oFactura.CodTipoVenta = "O" And oValeCaja.ValeCajaID = 0 Then
                Dim oAutorizacionFacilito As New frmAutorizacionFacilito(oFactura.NumeroFacilito)
                oAutorizacionFacilito.ShowMeByFactura(oFactura.ClienteId)
                If oAutorizacionFacilito.DialogResult = DialogResult.OK Then
                    oFactura.NumeroFacilito = oAutorizacionFacilito.txtNumeroAutorizacion.Text
                Else
                    MsgBox("Debe Ingresar Numero de Autorización. No se puede continuar. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                End If
                oAutorizacionFacilito.Dispose()
                oAutorizacionFacilito = Nothing
                If oFactura.NumeroFacilito = String.Empty Then
                    Exit Sub
                End If
            Else
                'Fonacot Facilito change --> el else
                If oNotaCredito.ID > 0 Then
                    oFactura.NumeroFacilito = oFacturaMgr.GetNumeroFacilito(oNotaCredito.ID)
                Else
                    oFactura.NumeroFacilito = "0"
                End If

            End If


            '-----------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (04.02.2015): Validamos que si NO aplica el CrossSelling, se revisan las promociones vigentes
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.AplicaCrossSelling = False Then
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'Validamos si no cambiaron las promociones vigentes para la sucursal en el transcurso del dia
                '-----------------------------------------------------------------------------------------------------------------------------------------
                Dim dtPromos As DataTable
                If oSAPMgr.ZBAPI_CHECK_PROMOS_VIGENTES(dtPromos) = "A" Then
                    Dim oFrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                    For Each oRowP As DataRow In dtPromos.Rows
                        'Realizamos la descarga de Descuentos Adicionales modificados en el dia actual
                        oFrmProcesoSAP.OpcDescAdi = CInt(oRowP!TipoDesc)
                        oFrmProcesoSAP.ShowDev("DescuentosAdicionales")
                        'Marcamos el registro en SAP para indicar que ya se actualizaron los descuentos modificados en el dia
                        oSAPMgr.ZBAPI_UPD_PROMOS_VIGENTES(CInt(oRowP!TipoDesc))
                    Next
                    'Aplicamos los descuentos adicionales de nuevo para actualizar la factura
                    grdDetalle_Validating(Nothing, Nothing)
                    'Le indicamos al player que los descuentos han cambiado
                    MessageBox.Show("Los Descuentos Adicionales han cambiado, favor de verificar de nuevo el detalle de la factura.", Me.Text, _
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub

                End If
            End If

            '----------------------------------------------------------------------------------------------------------------------------
            'Aplicamos la promocion especial si es que lleva (Cupon Descuento)
            '----------------------------------------------------------------------------------------------------------------------------
            Dim strFolioCupon As String = ""
            oCuponDesc = Nothing
            If Me.chkPromoEspecial.Checked Then
                strFolioCupon = InputBox("Especifique el Folio del Cupón", "Dportenis PRO", "").Trim.ToUpper
                If strFolioCupon.Trim <> "" Then
                    If ValidaPromoEspecial(strFolioCupon, oCuponDesc) = False Then
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
            '------------------------------------------------------------------------------------------------
            'Validamos el vale de Empleado en caso de ser tipo de venta Empleado
            '------------------------------------------------------------------------------------------------
            oValeE = New ValeEmpleado
            If Me.ebTipoVenta.Value = "E" Then
                Dim oFrm As New frmValeEmpleado
                oFrm.ShowDialog()
                If oFrm.DialogResult = DialogResult.OK Then
                    oValeE = IIf(Not oFrm.ValeEmpleado Is Nothing, oFrm.ValeEmpleado, oValeE)
                    'AplicaPromocionesVigentes(oFrm.nebDescuento.Value * 100)
                    AplicarPromociones(oFrm.nebDescuento.Value * 100)
                Else
                    Exit Sub
                End If
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'Si el cliente rechazo las promociones condicionadas por formas de pago y se arrepintio volvemos a aplicar las promociones vigentes
            'para preguntarle de nuevo si las acepta
            '------------------------------------------------------------------------------------------------------------------------------------
            If bRechazoPromo Then AplicarPromociones()
            '------------------------------------------------------------------------------------------------
            'Validamos Tipo de Descuento
            '------------------------------------------------------------------------------------------------
ValidaDescuentoAdicional:
            If vDescuentoAdicional > 0 Then     '--'If oFactura.DescTotal > 0 Then -- NO APLICA
                '--------------------------------------------------------------------------------------------------------------------------------
                'Si tiene promociones aplicadas revisamos si estas promociones estan condicionadas por formas de pago especificas para preguntar
                'al cliente si desea aprovechar las promociones pagando con estas formas de pago o no
                '--------------------------------------------------------------------------------------------------------------------------------
                If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then
                    If ValidaPromosFormasPago() = False Then GoTo ValidaDescuentoAdicional
                End If
                If vApartadoInstance Then
                    vCodTipoDescuento = oContratoInfo.TipoDescuentoID
                    AbrirFormaPago(vCodTipoDescuento)
                Else
EligeTipoDescuento:
                    'oValidaDescuento.TipoVenta = IIf(ebTipoVenta.Value = "D", "C", ebTipoVenta.Value)
                    oValidaDescuento = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.frmValidaTipoDescuento(oAppContext)
                    oValidaDescuento.TipoVenta = IIf(ebTipoVenta.Value = "D", "C", IIf(ebTipoVenta.Value = "I", "P", IIf(ebTipoVenta.Value = "S", "P", ebTipoVenta.Value)))
                    oValidaDescuento.FolioVale = oValeDescuentoLocalInfo.FolioVale
                    oValidaDescuento.Sucursal = oValeDescuentoLocalInfo.Sucursal
                    oValidaDescuento.TipoVale = oValeDescuentoLocalInfo.TipoVale

                    'Añadimos Evento A TipoDescuento
                    AddHandler oValidaDescuento.ebCodTipoDescuento.ValueChanged, AddressOf ebCodTipoDescuento_ValueChanged
                    '

                    'oValidaDescuento.ShowDialog()
                    If Me.ebTipoVenta.Value = "D" OrElse Me.ebTipoVenta.Value = "S" Then
                        vCodTipoDescuento = "DCD"
                    ElseIf Me.ebTipoVenta.Value = "E" Then
                        vCodTipoDescuento = "DVD"
                    Else
                        vCodTipoDescuento = "DMA"
                    End If

                    'If oValidaDescuento.DialogResult = DialogResult.OK Then
                    'vCodTipoDescuento = oValidaDescuento.ebCodTipoDescuento.Value
                    'If oFirmasMgr.ValidaDescuento(vCodTipoDescuento, oSAPMgr.Read_Centros) = False Then
                    '    MsgBox("Este tipo de descuento no está permitido para esta tienda." & vbCrLf & "Debe elegir otro tipo de descuento.", MsgBoxStyle.Exclamation, "Dportenis Pro")
                    '    Exit Sub
                    'End If
                    'oValeDescuentoLocalInfo.FolioVale = oValidaDescuento.FolioVale
                    oValeDescuentoLocalInfo.FolioVale = oValeE.Folio
                    oValeDescuentoLocalInfo.Serie = oValeE.Serie
                    oValeDescuentoLocalInfo.Sucursal = oValidaDescuento.Sucursal
                    oValeDescuentoLocalInfo.TipoVale = oValidaDescuento.TipoVale
                    oValidaDescuento.Dispose()
                    oValidaDescuento = Nothing
                    'If vCodTipoDescuento = "DVD" Then
                    '    Select Case ValidaDVD(TotalPiezasFactura)
                    '        Case 0
                    '            AbrirFormaPago(vCodTipoDescuento)
                    '        Case 1
                    '            MsgBox("Sólo puede aplicar descuentos a 3 piezas. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
                    '        Case 2
                    '            MsgBox("Existen códigos con más del " & CInt(oValeDescuentoLocalInfo.TipoVale) * 10 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
                    '    End Select
                    'Else
                    AbrirFormaPago(vCodTipoDescuento)
                    'End If
                    'Else
                    '    vCodTipoDescuento = String.Empty
                    '    oValeDescuentoLocalInfo.FolioVale = 0
                    '    oValeDescuentoLocalInfo.Sucursal = String.Empty
                    '    oValeDescuentoLocalInfo.TipoVale = String.Empty
                    '    oValidaDescuento.Dispose()
                    '    oValidaDescuento = Nothing
                    '    Exit Sub
                    'End If
                End If
            Else
                vCodTipoDescuento = String.Empty
                AbrirFormaPago(vCodTipoDescuento)
            End If
        Else
            MsgBox("Factura no tiene asignado artículos.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación")
        End If
    End Sub

#End Region

#Region "Mejoras en tiendas"

    Private Function ValidaTotalDetalleCabecera() As Boolean
        Dim valido As Boolean = True
        Dim oRow As DataRow
        Dim vTotalGeneral As Decimal = 0
        Dim vSubTotal As Decimal = 0
        Dim vDscto As Decimal = 0
        Dim vDsctoAdicional As Decimal = 0
        Dim vIVA As Decimal = 0
        Dim vDsctoUnit As Decimal = 0, vDsctoAdiUnit As Decimal = 0, vImporte As Decimal = 0
        'Dim idx As Integer = 0 
        Dim LogMensaje As String = "El total factura: " & CStr(oFactura.Total) & vbCrLf
        '--Flag Descuento Adicional
        vSaldarDescuentoAdicional = 0
        vDescuentoAdicional = 0
        '--End Flag
        If dsDetalle.Tables(0).Rows.Count > 0 AndAlso dsDetalle.Tables(0).Rows(0).RowState <> DataRowState.Deleted AndAlso CStr(dsDetalle.Tables(0).Rows(0)!Codigo).Trim <> "" Then
            For Each oRow In dsDetalle.Tables(0).Rows
                'Obtenemos el descuento total del producto
                If CInt(oRow!Cantidad) > 0 Then

                    '-----------------------------------------------------------------------------------
                    ' Descuento por Sistema
                    '-----------------------------------------------------------------------------------
                    vDscto += oRow("Descuento")
                    'Calculamos el descuento por sistema que le toca a cada pieza del producto
                    vDsctoUnit = oRow("Descuento") / oRow("Cantidad")


                    '-----------------------------------------------------------------------------------
                    ' Descuento Adicional
                    '-----------------------------------------------------------------------------------
                    vSaldarDescuentoAdicional += oRow("Adicional")
                    'Calculamos el descuento adicional que le corresponde a cada pieza del producto
                    vDsctoAdiUnit = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdiUnit = vDsctoAdiUnit / oRow("Cantidad") ' Truncar(vDsctoAdiUnit, 2) / oRow("Cantidad")
                    Dim vDsctoAdicionalTotal As Decimal = Decimal.Zero
                    vDsctoAdicionalTotal = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdicional += vDsctoAdicionalTotal


                    '-----------------------------------------------------------------------------------
                    ' Importe
                    '-----------------------------------------------------------------------------------
                    'Calculamos el importe unitario de cada pieza del producto restando los descuentos
                    vImporte = oRow("Importe") - vDsctoUnit - vDsctoAdiUnit
                    'Le aumentamos el iva al precio unitario
                    vImporte = Decimal.Round(vImporte * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    LogMensaje &= "CodArtículo: " & CStr(oRow("Codigo")) & " Cant: " & CStr(oRow("Cantidad")) & " Importe: " & CStr(vImporte) & vbCrLf
                    '-----------------------------------------------------------------------------------
                    ' Total
                    '-----------------------------------------------------------------------------------
                    'Sumamos al importe total de la factura el total de este producto ya con los descuentos restados y el iva aumentado
                    vTotalGeneral = vTotalGeneral + (vImporte * oRow("Cantidad"))

                End If
            Next
        End If
        If Math.Abs(oFactura.Total - vTotalGeneral) > 1 Then
            EscribeLog("Error de Monto " & vbCrLf & LogMensaje, "Log de errores de Monto")
            valido = False
        Else
            EscribeLog("Correcto Monto " & vbCrLf & LogMensaje, "Log de errores de Monto")
        End If
        Return valido
    End Function

#End Region

End Class