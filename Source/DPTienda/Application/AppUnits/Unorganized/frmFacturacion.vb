Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

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

Imports DportenisPro.DPTienda.ApplicationUnits.CambiarFolioFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports System.Collections.Generic
Imports Janus.Windows.GridEX
Imports System.Threading
Imports Pinpad
Imports uPaydll

Public Class frmFacturacion

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

    Public Property SerialId As String
        Get
            Return m_SerialId
        End Get
        Set(value As String)
            m_SerialId = value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents dgHeader As Janus.Windows.GridEX.GridEX
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
    Friend WithEvents lblTotalPiezas As System.Windows.Forms.Label
    Friend WithEvents nebTotalPiezas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnPromosAplicadas As Janus.Windows.EditControls.UIButton
    Friend WithEvents MnuModificarBeneficiario As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuModificarBeneficiario1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup6 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacion))
        Dim ExplorerBarGroup5 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
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
        Me.MnuModificarBeneficiario = New Janus.Windows.UI.CommandBars.UICommand("MnuModificarBeneficiario")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnPromosAplicadas = New Janus.Windows.EditControls.UIButton()
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
        Me.dgHeader = New Janus.Windows.GridEX.GridEX()
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
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar3.SuspendLayout()
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar2.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exbGuardarCliente.SuspendLayout()
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'uICommandManager1
        '
        Me.uICommandManager1.BottomRebar = Me.BottomRebar1
        Me.uICommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.uICommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuHerramientas, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoAbrir, Me.menuArchivoApartado, Me.menuArchivoEliminar, Me.menuArchivoGuardar, Me.menuArchivoImprimir, Me.menuArchivoSalir, Me.menuHerramientasPago, Me.menuAyudasTema, Me.ToolBarNuevo, Me.ToolBarAbrir, Me.ToolBarGuardar, Me.ToolBarEliminar, Me.ToolBarAyuda, Me.menuFacturarDev, Me.MnuModificarBeneficiario})
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
        Me.UiCommandBar1.Size = New System.Drawing.Size(682, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
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
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ToolBarNuevo1, Me.Separator5, Me.ToolBarAbrir1, Me.Separator6, Me.menuArchivoImprimir1, Me.Separator7, Me.Separator3, Me.ToolBarAyuda1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(210, 28)
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
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
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
        Me.MnuModificarBeneficiario1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
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
        Me.menuHerramientas.Visible = Janus.Windows.UI.InheritableBoolean.[False]
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
        Me.menuAyuda.Visible = Janus.Windows.UI.InheritableBoolean.[False]
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
        Me.TopRebar1.Size = New System.Drawing.Size(682, 50)
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.btnPromosAplicadas)
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
        Me.explorerBar1.Controls.Add(Me.dgHeader)
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
        ExplorerBarGroup6.Expandable = False
        ExplorerBarGroup6.Expanded = False
        ExplorerBarGroup6.Image = CType(resources.GetObject("ExplorerBarGroup6.Image"), System.Drawing.Image)
        ExplorerBarGroup6.Key = "Group1"
        ExplorerBarGroup6.Text = "Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup6})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(688, 622)
        Me.explorerBar1.TabIndex = 15
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnPromosAplicadas
        '
        Me.btnPromosAplicadas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPromosAplicadas.Icon = CType(resources.GetObject("btnPromosAplicadas.Icon"), System.Drawing.Icon)
        Me.btnPromosAplicadas.Location = New System.Drawing.Point(468, 141)
        Me.btnPromosAplicadas.Name = "btnPromosAplicadas"
        Me.btnPromosAplicadas.Size = New System.Drawing.Size(24, 20)
        Me.btnPromosAplicadas.TabIndex = 93
        Me.btnPromosAplicadas.Tag = "Probando"
        Me.btnPromosAplicadas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        Me.ebClienteDescripcion.TabIndex = 68
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
        Me.chkPromoEspecial.Location = New System.Drawing.Point(496, 144)
        Me.chkPromoEspecial.Name = "chkPromoEspecial"
        Me.chkPromoEspecial.Size = New System.Drawing.Size(168, 16)
        Me.chkPromoEspecial.TabIndex = 90
        Me.chkPromoEspecial.Text = "Promoci�n Especial"
        Me.chkPromoEspecial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtFolioVentaManual
        '
        Me.txtFolioVentaManual.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioVentaManual.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioVentaManual.BackColor = System.Drawing.Color.Ivory
        Me.txtFolioVentaManual.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtFolioVentaManual.Location = New System.Drawing.Point(216, 140)
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
        Me.chkVentaManual.Location = New System.Drawing.Point(12, 144)
        Me.chkVentaManual.Name = "chkVentaManual"
        Me.chkVentaManual.Size = New System.Drawing.Size(168, 16)
        Me.chkVentaManual.TabIndex = 75
        Me.chkVentaManual.Text = "Nota de Venta Manual"
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
        Me.EbFolioSAP.TabIndex = 87
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
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Expanded = False
        ExplorerBarGroup4.Image = CType(resources.GetObject("ExplorerBarGroup4.Image"), System.Drawing.Image)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Datos del Art�culo"
        Me.explorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.explorerBar3.Location = New System.Drawing.Point(16, 384)
        Me.explorerBar3.Name = "explorerBar3"
        Me.explorerBar3.Size = New System.Drawing.Size(392, 216)
        Me.explorerBar3.TabIndex = 86
        Me.explorerBar3.Text = "ExplorerBar3"
        Me.explorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'chkDip
        '
        Me.chkDip.BackColor = System.Drawing.Color.Transparent
        Me.chkDip.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDip.Location = New System.Drawing.Point(256, 176)
        Me.chkDip.Name = "chkDip"
        Me.chkDip.Size = New System.Drawing.Size(120, 23)
        Me.chkDip.TabIndex = 68
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
        Me.ebMontoDscto.TabIndex = 67
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
        Me.txtCorrida.Location = New System.Drawing.Point(124, 95)
        Me.txtCorrida.Name = "txtCorrida"
        Me.txtCorrida.ReadOnly = True
        Me.txtCorrida.Size = New System.Drawing.Size(65, 22)
        Me.txtCorrida.TabIndex = 66
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
        Me.ebTallaAl.TabIndex = 46
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
        Me.ebTallaDel.TabIndex = 45
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
        Me.ebExistencias.TabIndex = 47
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
        Me.ebPrecioArticulo.Location = New System.Drawing.Point(123, 175)
        Me.ebPrecioArticulo.Name = "ebPrecioArticulo"
        Me.ebPrecioArticulo.ReadOnly = True
        Me.ebPrecioArticulo.Size = New System.Drawing.Size(104, 22)
        Me.ebPrecioArticulo.TabIndex = 49
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
        Me.ebPorcentajeDscto.TabIndex = 48
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
        Me.ebCodigoArticulo.TabIndex = 43
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
        Me.ebDescripcionArticulo.TabIndex = 44
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
        Me.Label11.Text = "C�digo"
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
        Me.Label10.Text = "Descripci�n"
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
        ExplorerBarGroup5.Expandable = False
        ExplorerBarGroup5.Expanded = False
        ExplorerBarGroup5.Image = CType(resources.GetObject("ExplorerBarGroup5.Image"), System.Drawing.Image)
        ExplorerBarGroup5.Key = "Group1"
        ExplorerBarGroup5.Text = "Totales"
        Me.explorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup5})
        Me.explorerBar2.Location = New System.Drawing.Point(416, 384)
        Me.explorerBar2.Name = "explorerBar2"
        Me.explorerBar2.Size = New System.Drawing.Size(248, 176)
        Me.explorerBar2.TabIndex = 85
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
        Me.nebTotalPiezas.Location = New System.Drawing.Point(117, 44)
        Me.nebTotalPiezas.Name = "nebTotalPiezas"
        Me.nebTotalPiezas.ReadOnly = True
        Me.nebTotalPiezas.Size = New System.Drawing.Size(104, 22)
        Me.nebTotalPiezas.TabIndex = 95
        Me.nebTotalPiezas.TabStop = False
        Me.nebTotalPiezas.Text = "0"
        Me.nebTotalPiezas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebTotalPiezas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebTotalPiezas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPiezas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPiezas.Location = New System.Drawing.Point(13, 44)
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Size = New System.Drawing.Size(100, 16)
        Me.lblTotalPiezas.TabIndex = 94
        Me.lblTotalPiezas.Text = "Total Piezas"
        '
        'prgProgressBar1
        '
        Me.prgProgressBar1.Location = New System.Drawing.Point(13, 140)
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
        Me.ebDescuentoTotal.Location = New System.Drawing.Point(117, 148)
        Me.ebDescuentoTotal.Name = "ebDescuentoTotal"
        Me.ebDescuentoTotal.ReadOnly = True
        Me.ebDescuentoTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebDescuentoTotal.TabIndex = 22
        Me.ebDescuentoTotal.TabStop = False
        Me.ebDescuentoTotal.Text = "$0.00"
        Me.ebDescuentoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDescuentoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(13, 152)
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
        Me.ebImporteTotal.Location = New System.Drawing.Point(117, 116)
        Me.ebImporteTotal.Name = "ebImporteTotal"
        Me.ebImporteTotal.ReadOnly = True
        Me.ebImporteTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebImporteTotal.TabIndex = 18
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
        Me.ebIVA.Location = New System.Drawing.Point(117, 92)
        Me.ebIVA.Name = "ebIVA"
        Me.ebIVA.ReadOnly = True
        Me.ebIVA.Size = New System.Drawing.Size(104, 22)
        Me.ebIVA.TabIndex = 17
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
        Me.ebSubTotal.Location = New System.Drawing.Point(117, 68)
        Me.ebSubTotal.Name = "ebSubTotal"
        Me.ebSubTotal.ReadOnly = True
        Me.ebSubTotal.Size = New System.Drawing.Size(104, 22)
        Me.ebSubTotal.TabIndex = 16
        Me.ebSubTotal.TabStop = False
        Me.ebSubTotal.Text = "$0.00"
        Me.ebSubTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 116)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 16)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Importe Total"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 92)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 16)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "I.V.A."
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 68)
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
        Me.grdDetalle.Location = New System.Drawing.Point(16, 184)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Rows.Count = 10
        Me.grdDetalle.Rows.DefaultSize = 19
        Me.grdDetalle.Rows.Fixed = 0
        Me.grdDetalle.Size = New System.Drawing.Size(648, 192)
        Me.grdDetalle.StyleInfo = resources.GetString("grdDetalle.StyleInfo")
        Me.grdDetalle.TabIndex = 72
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
        Me.ebCodCaja.TabIndex = 63
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
        Me.ebCodVendedor.MaxLength = 8
        Me.ebCodVendedor.Name = "ebCodVendedor"
        Me.ebCodVendedor.Size = New System.Drawing.Size(136, 22)
        Me.ebCodVendedor.TabIndex = 66
        Me.ebCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnFormaPago
        '
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.Location = New System.Drawing.Point(416, 568)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(248, 32)
        Me.btnFormaPago.TabIndex = 74
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
        Me.ebClienteID.TabIndex = 67
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
        Me.ebFolioApartado.TabIndex = 64
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
        'dgHeader
        '
        Me.dgHeader.AllowDrop = True
        Me.dgHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHeader.AutomaticSort = False
        Me.dgHeader.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.dgHeader.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.dgHeader.DesignTimeLayout = GridEXLayout3
        Me.dgHeader.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgHeader.Enabled = False
        Me.dgHeader.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.dgHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.dgHeader.GroupByBoxVisible = False
        Me.dgHeader.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgHeader.Location = New System.Drawing.Point(16, 163)
        Me.dgHeader.Name = "dgHeader"
        Me.dgHeader.ScrollBars = Janus.Windows.GridEX.ScrollBars.None
        Me.dgHeader.Size = New System.Drawing.Size(648, 37)
        Me.dgHeader.TabIndex = 73
        Me.dgHeader.TabStop = False
        Me.dgHeader.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoVenta
        '
        Me.ebTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.ebTipoVenta.DesignTimeLayout = GridEXLayout4
        Me.ebTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoVenta.Location = New System.Drawing.Point(349, 62)
        Me.ebTipoVenta.Name = "ebTipoVenta"
        Me.ebTipoVenta.Size = New System.Drawing.Size(168, 22)
        Me.ebTipoVenta.TabIndex = 65
        Me.ebTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaFactura
        '
        Me.ebFechaFactura.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ebFechaFactura.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFactura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaFactura.Location = New System.Drawing.Point(349, 34)
        Me.ebFechaFactura.Name = "ebFechaFactura"
        Me.ebFechaFactura.ReadOnly = True
        Me.ebFechaFactura.Size = New System.Drawing.Size(168, 22)
        Me.ebFechaFactura.TabIndex = 62
        Me.ebFechaFactura.TabStop = False
        Me.ebFechaFactura.TodayButtonText = "Hoy"
        Me.ebFechaFactura.Value = New Date(2005, 9, 3, 0, 0, 0, 0)
        Me.ebFechaFactura.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'btnAltaCliente
        '
        Me.btnAltaCliente.Enabled = False
        Me.btnAltaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAltaCliente.Location = New System.Drawing.Point(551, 116)
        Me.btnAltaCliente.Name = "btnAltaCliente"
        Me.btnAltaCliente.Size = New System.Drawing.Size(113, 24)
        Me.btnAltaCliente.TabIndex = 70
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
        Me.ebStatus.TabIndex = 66
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
        Me.ebPlayerDescripcion.Size = New System.Drawing.Size(273, 21)
        Me.ebPlayerDescripcion.TabIndex = 71
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
        'frmFacturacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(682, 667)
        Me.Controls.Add(Me.exbGuardarCliente)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturaci�n"
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
        CType(Me.explorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar3.ResumeLayout(False)
        CType(Me.explorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar2.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exbGuardarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exbGuardarCliente.ResumeLayout(False)
        CType(Me.timer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

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
    Dim dsDetalle As DataSet = New DataSet
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
    Dim intNUMVA As Integer = 0 'Variable para guardar el numero de dpvale usado en una factura para la reimpresion de un ticket
    Private strNUMVA As String = ""

    '---------------------------------------------------------------------------------------------------
    ' JNAVA (17.02.2017): Variables para obtener los datos del cliente y el distribuidor
    '---------------------------------------------------------------------------------------------------
    Dim vNombreAsociado As String = String.Empty
    Dim vNombreClienteAsociado As String = String.Empty
    '---------------------------------------------------------------------------------------------------

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
    Dim dtDescFormasPago As DataTable
    Dim dtPromoAplicada As DataTable
    Dim bRechazoPromo As Boolean = False
    Dim DPValeVentaID As String = ""
    Dim CentroSAP As String = ""
    Dim bReintentoDPVL As Boolean = False
    Dim strDatosPromoClientes As String = ""
    Dim dtPromosCS As DataTable
    Dim dtPromosCSVig As DataTable
    Dim dtCS As DataTable
    Private m_SerialId As String = ""
    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 28/09/2017: Informaci�n de vale de electronico
    '--------------------------------------------------------------------------------------
    Private oDPValeSAP As cDPValeSAP

    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 06/12/2017: Correcci�n DPPRO
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
    Dim oFactura As Factura

    'objeto SAP
    Public oSAPMgr As ProcesoSAPManager

    'Vales DescuentoInfo
    Dim oValeDescuentoLocalInfo As New ValesDescuentoInfo

    'Objeto Avisos Factura
    Dim oAvisoFacturaMgr As AvisosFacturaManager
    Dim oAvisosFactura As AvisosFactura

    'Objeto FacturaCorrida
    Dim oFacturaCorridaMgr As FacturaCorridaManager

    'Objeto Art�culo
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

    'Objeto de Catalogos Formas Pago
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
    Private dtCantidadLibre As DataTable = Nothing
#End Region

#Region "Codigo Proveedor"

    Private CodPadreArticulo As String = ""

#End Region

#End Region

#Region "Objetos S2Credit"

    '----------------------------------------------------------
    ' JNAVA (15.05.2016): Objetos para S2Credit
    '----------------------------------------------------------
    Dim oS2Credit As New ProcesosS2Credit

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
        oSAPMgr.ZCS_ALGORITMO_PROMOS_LOAD_ESQUEMA()

        'Objeto AvisosFactura
        oAvisoFacturaMgr = New AvisosFacturaManager(oAppContext)
        oAvisosFactura = oAvisoFacturaMgr.Create

        'Objeto Factura
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)

        'Objeto Art�culo
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
        oFingerPrintMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)

        'Objeto Firmas
        oFirmasMgr = New FirmaManager(oAppContext, oConfigCierreFI)

        oFPMgr = New CatalogoFormasPagoManager(oAppContext)

        SetEstructuraPromoAplicada()

        SiHay = New DataSet

        CentroSAP = oSAPMgr.Read_Centros

        '--------------------------------------------------------------
        ' JNAVA (07.01.2015): Modificacion para Retail
        '--------------------------------------------------------------
        Me.DPValeVentaID = CentroSAP & oFactura.CodCaja & Format(oSAPMgr.MSS_GET_SY_DATE_TIME, "ddMMyyyyhhmmss")
        'Me.DPValeVentaID = CentroSAP & oFactura.CodCaja & Format(Date.Now, "ddMMyyyyhhmmss")
        '--------------------------------------------------------------

        strDatosPromoClientes = ""

        oFactura.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()

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
        EbFolioSAP.DataBindings.Add(New Binding("Text", oFactura, "Referencia"))
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

    Private Sub StressTest()
        Dim oHilo1 As Thread, oHilo2 As Thread, oHilo3 As Thread, oHilo4 As Thread, ohilo5 As Thread

        oHilo1 = New Thread(AddressOf Test)
        oHilo2 = New Thread(AddressOf Test)
        oHilo3 = New Thread(AddressOf Test)
        oHilo4 = New Thread(AddressOf Test)
        ohilo5 = New Thread(AddressOf Test)

        oHilo1.Start()
        oHilo2.Start()
        oHilo3.Start()
        oHilo4.Start()
        ohilo5.Start()

    End Sub

    Private Sub Test()

        Dim i As Integer = 0, lim = 50

        RestService = New ProcesosRetail("/pos/dips", "POST")
        Dim result As Dictionary(Of String, Object)
        For i = 1 To lim
            result = RestService.SapZbapiSelectDips("0000000001")
            strCat = CStr(result("SapZbapiSelectDips")("O_RETURN"))
        Next

        MsgBox("Termino Hilo")

    End Sub

#Region "General Form Methods"

    Private Sub uICommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uICommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoAbrir"

                LoadSearchFormFactura()

            Case "ToolBarImprimir", "menuArchivoImprimir"
                ' Futura implementacion
                Dim ofrmPago As New frmPago
                'ofrmPago.intFolioDPVale = intNUMVA
                ofrmPago.StrFolioDPVale = strNUMVA
                ofrmPago.bReimprir = True
                '-----------------------------------------------------------------------------------
                ' JNAVA (17.02.2017):  Obtenemos los datos del lciente y distribuidor
                '-----------------------------------------------------------------------------------
                ofrmPago.vNombreAsociado = vNombreAsociado
                ofrmPago.vNombreClienteAsociado = vNombreClienteAsociado

                '-----------------------------------------------------------------------------------
                ' JNAVA (26.03.2015):  Obtenemos las Formas de pago para el ticket DPCA
                '-----------------------------------------------------------------------------------
                Dim dtFormasPago As DataTable
                dtFormasPago = ofrmPago.ObtenerFormasPagoByFacturaID(oFactura.FacturaID)

                '-----------------------------------------------------------------------------------
                ' JNAVA (26.03.2015):  Preparamos los datos para el ticket de DPCARD
                '-----------------------------------------------------------------------------------
                ReimprimirVoucherDPCA(dtFormasPago)

                '-----------------------------------------------------------------------------------
                'FLIZARRAGA 08/06/2017: Reeimprimir voucher de Banamex
                '-----------------------------------------------------------------------------------
                ReeimpresionBanamex(dtFormasPago)
                '-----------------------------------------------------------------------------------
                ' JNAVA (05.08.2016): Validamos si esta activo S2Credit
                '-----------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then
                    '-----------------------------------------------------------------------------------
                    ' JNAVA (05.08.2016): Preparamos los datos para el ticket de Seguro desde S2Credit
                    '-----------------------------------------------------------------------------------
                    PrepararReimpresionSeguroS2Credit(ofrmPago)
                Else
                    '-----------------------------------------------------------------------------------
                    ' JNAVA (12.02.2015):  Preparamos los datos para el ticket de Seguro cuando es reimpresion
                    '-----------------------------------------------------------------------------------
                    PrepararReimpresionSeguroDPVale(ofrmPago)
                End If

                ''-----------------------------------------------------------------------------------
                '' JNAVA (12.02.2015):  Preparamos los datos para el ticket de Seguro cuando es reimpresion
                ''-----------------------------------------------------------------------------------
                'PrepararReimpresionSeguroDPVale(ofrmPago)
                '----------------------------------------------------------------------------------------
                'FLIZARRAGA 16/11/2017: Calcula la primer fecha de pago del vale
                '----------------------------------------------------------------------------------------
                ofrmPago.FechaPrimerPago = CalcularFechaPrimerPago()

                '-----------------------------------------------------------------------------------
                ' JNAVA (12.02.2015): (MOVIDO) Reimprimimos Factura
                '-----------------------------------------------------------------------------------
                If oFactura.Impresa = True Then
                    ofrmPago.ActionPreview(oFactura.FacturaID, "Facturacion", True, "COPIA DE FACTURA", strQuin, True)
                Else
                    ofrmPago.ActionPreview(oFactura.FacturaID, "Facturacion", True, "FACTURA", strQuin, True)
                End If

                '---------------------------------------------------
                ' JNAVA(10.02.2015): Reimpresion de Seguro de vida
                '---------------------------------------------------
                If Not ofrmPago.DatosTicketSeguro Is Nothing AndAlso ofrmPago.DatosTicketSeguro.Count > 0 Then
                    ofrmPago.ImprimirTicketSeguro()
                End If
                If oFactura.CodTipoVenta.Trim() = "V" Then
                    If Not oDPValeSAP Is Nothing Then
                        If IsNumeric(oDPValeSAP.IDDPVale) = False Then
                            ofrmPago.ImprimeValeElectronico(oDPValeSAP)
                        End If
                    End If
                End If

            Case "menuFacturarDev"
                Dim strResult As String
                Do
                    strResult = InputBox("Introduzca el folio del Vale de Caja: ", Me.Text, "", 400, 300)
                    'MsgBox("El codigo es diferente al seleccionado!", MsgBoxStyle.Information, Me.Text)
                    If strResult = "" Then Exit Sub
                Loop Until IsNumeric(strResult)

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


                If CDbl(strResult) > Int32.MaxValue Then
                    MsgBox("Numero de vale incorrecto, verifique sus datos", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                    Exit Sub
                End If

                oValeCaja = oValeCajaMgr.Load(CInt(strResult))

                If Not (oValeCaja Is Nothing) Then

                    If oValeCaja.MontoUtilizado > 0 Then

                        MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " ya fue utilizado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                        Exit Sub

                    Else

                        If oValeCaja.StastusRegistro = False Then

                            MsgBox("El Vale de Caja " & Format(oValeCaja.ValeCajaID, "000000") & " est� deshabilitado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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

                    MsgBox("Folio del Vale de Caja no existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                    Exit Sub

                End If

                oNotaCredito = oNotaCreditoMgr.Load(oValeCaja.DocumentoID)

                'Fonacot Facilito change
                If Not oValeCaja.ValeCajaID = 0 Then
                    If Not oNotaCredito Is Nothing Then


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
                            'MsgBox("C�digo de Vendedor NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturaci�n ")
                            'ebCodVendedor.Text = oFactura.CodVendedor
                            'e.Cancel = True
                        End If

                        Me.grdDetalle.Focus()
                    End If
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
                    RemoveEmptyRow()
                    'dsDetalle.Tables(0).Rows(0).Delete()
                    'dsDetalle.AcceptChanges()

                    'Objeto Contrato
                    oContratoInfo = Nothing
                    oContratoMgr = New ContratoManager(oAppContext)
                    oContratoInfo = oContratoMgr.Create

                    oContratoInfo = oAbrirApartado.oContrato

                    vApartadoInstance = True

                    'Cargamos articulos del apartado en el grid
                    LoadDataofApartado()
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

                LoadSearchFormFactura()

            Case "menuArchivoSalir"

                Me.Close()

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
            LoadDataofApartado()

        End If

        'Verificamos si la factura es instancia de NOTA DE CREDITO
        If vNCInstance Then

            LoadDataofNotaCredito()

        End If

        If Not vApartadoInstance And Not vNCInstance Then

            With oAppContext.ApplicationConfiguration

                If (.Descuento < .DsctoCompra3MasDIP) Or (.Descuento < .DsctoCompra3MasNoDIP) Or (.Descuento < .DsctoCompra3oMenosDIP) Or (.Descuento < .DsctoCompra3oMenosNoDIP) Then

                    MsgBox("Configuraci�n de Descuentos de Asociados Incorrecta. Deben ser menores o iguales al descuento m�ximo.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Factura")

                    Me.Close()

                End If

                If .CodigosXFactura <= 0 Then

                    MsgBox("No tiene configurada la cantidad de c�digos por factura.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Factura")

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
                'MsgBox("C�digo de Vendedor NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Facturaci�n ")
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
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.08.2014: Pedimos capturar el celular y el email del cliente si esta activada la configuracion
        '----------------------------------------------------------------------------------------------------------------------------------------
        strDatosPromoClientes = ""
        Application.DoEvents()
        If oConfigCierreFI.PedirDatosPromoComienzo Then CapturaCelParaSMS()
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.02.2015: Mostramos el boton para mostrar las promos aplicadas en el CS en base a la config
        '----------------------------------------------------------------------------------------------------------------------------------------
        Me.btnPromosAplicadas.Visible = oConfigCierreFI.AplicaCrossSelling
        grdDetalle.Select(0, 0)
    End Sub

    Private Sub CapturaCelParaSMS()
        Try
            '---------------------------------------------------------------------------------------------------------------
            'Preguntamos si desea dejar su cel para envio de promociones si la config esta activada
            '---------------------------------------------------------------------------------------------------------------
            'If oConfigCierreFI.PromoSMS AndAlso MessageBox.Show("�Desea recibir nuestras promociones a trav�s de un SMS?", _
            ' "Promociones SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Dim frmCapCel As New frmCapturaCelSMS

            If frmCapCel.ShowDialog = DialogResult.OK Then
                Dim oFrmP As New frmPago
                Dim oNewRow As DataRow

                '--------------------------------------------------------------------------------------
                ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
                '--------------------------------------------------------------------------------------
                'oSAPMgr.ZRFC_INSERTA_DATOS_PROMO(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, "", "", frmCapCel.ebEmail.Text.Trim, "", Me.DPValeVentaID)
                Dim oRetail As New ProcesosRetail("/pos/tiendas", "POST")
                oRetail.SapZrfcInsetaDatosPromo(frmCapCel.nebLada.Value, frmCapCel.nebNumCel.Value, "", "", frmCapCel.ebEmail.Text.Trim, "", Me.DPValeVentaID)

                strDatosPromoClientes = frmCapCel.nebLada.Value & "|" & frmCapCel.nebNumCel.Value & "|" & frmCapCel.ebEmail.Text.Trim
            End If
            'End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al capturar celular para sms y email")
        End Try

    End Sub

    Private Sub RemoveEmptyRow()
        Dim i As Integer = 0
        For i = dsDetalle.Tables(0).Rows.Count - 1 To 0 Step -1
            If Not CStr(dsDetalle.Tables(0).Rows(i)("CodProveedor")) Is Nothing AndAlso CStr(dsDetalle.Tables(0).Rows(i)("CodProveedor")).Trim() = String.Empty Then
                dsDetalle.Tables(0).Rows.RemoveAt(i)
                dsDetalle.Tables(0).AcceptChanges()
            ElseIf CInt(dsDetalle.Tables(0).Rows(i)("Cantidad")) <= 0 Then
                dsDetalle.Tables(0).Rows.RemoveAt(i)
                dsDetalle.Tables(0).AcceptChanges()
            End If
        Next
        If grdDetalle.Rows.Count > 0 Then
            grdDetalle.Select(grdDetalle.Rows.Count - 1, 0)
        End If
    End Sub

    Private Sub btnFormaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormaPago.Click

        btnFormaPago.Enabled = False
        FormaPago()
        btnFormaPago.Enabled = True
        '        btnFormaPago.Focus()
        '        RemoveEmptyRow()
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        ' JNAVA (07.04.2016): Si un registro viene vacio cuando hay mas de uno, entonces lo quitamos
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        For Each oRowD As DataRow In Me.dsDetalle.Tables(0).Rows
        '            If Me.dsDetalle.Tables(0).Rows.Count > 1 AndAlso CStr(oRowD!Codigo).Trim = "" Then
        '                Me.dsDetalle.Tables(0).Rows.Remove(oRowD)
        '                Exit For
        '            End If
        '        Next
        '        Me.dsDetalle.Tables(0).AcceptChanges()
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        'FLIZARRAGA 28/09/2018: Validar que no haya dos tarjetas de lealtad en el pedido
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        If ValidarTarjetaLealtadEnDetalle() = False Then
        '            Exit Sub
        '        End If
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '        '-----------------------------------------------------------------------------------------------------------------------------
        '        'If FacturacionSiHay > 0 Then

        '        Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        '        Me.dtCantidadLibre = Me.dsDetalle.Tables(0).Copy()
        '        Me.dtCantidadLibre.TableName = "MaterialesLibres"

        '        'If ValidarMaterialesNegadosSH(Me.dtCantidadLibre, dtNegadosSH, "PF,P,RP", vApartadoInstance) = False Then
        '        '    ShowFormNegadosSH(dtNegadosSH)
        '        '    Exit Sub
        '        'End If
        '        'End If
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
        '            If oFactura.ClienteId = 0 And oFactura.CodTipoVenta <> "P" And oFactura.CodTipoVenta <> "E" Then
        '                MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
        '                ebClienteID.Focus()
        '                Exit Sub
        '            End If
        '            'If oConfigCierreFI.UsarHuellas Then
        '            '    If oFactura.ClienteId = 10000000 AndAlso (oFactura.CodTipoVenta <> "P" OrElse oConfigCierreFI.RegistroPGOpcional = False) Then
        '            '        MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
        '            '        ebClienteID.Focus()
        '            '        Exit Sub
        '            '    End If
        '            'Else
        '            '    If oFactura.ClienteId = 10000000 Then
        '            '        MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
        '            '        ebClienteID.Focus()
        '            '        Exit Sub
        '            '    End If
        '            'End If
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
        '            If (ebTipoVenta.Value <> "P" AndAlso ebTipoVenta.Value <> "V" AndAlso ebTipoVenta.Value <> "E" AndAlso oFactura.ClienteId <= 0) Then
        '                MsgBox("Por el Tipo de Venta es necesario ingresar C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
        '                ebClienteID.Focus()
        '                Exit Sub
        '            ElseIf ebTipoVenta.Value = "P" AndAlso oConfigCierreFI.UsarHuellas Then
        '                Dim FolioSAP As String = ""
        '                If oFactura.ClienteId <= 0 Then
        '                    If MessageBox.Show("�Desea registrar los datos del cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '                        If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
        '                            GoTo EspecificaRazon
        '                        End If
        '                    ElseIf oFactura.RazonRechazo.Trim = "" Then
        'EspecificaRazon:
        '                        'oFactura.RazonRechazo = InputBox("Especifique la raz�n por la que no registr� los datos del cliente.", Me.Text)
        '                        Dim oFrmRazones As New frmRazonesRechazo
        '                        oFrmRazones.ModuloOrigen = "FA"
        '                        If oFrmRazones.ShowDialog = DialogResult.OK Then
        '                            oFactura.RazonRechazo = oFrmRazones.cmbRazones.Text
        '                            oFactura.RazonRechazoID = oFrmRazones.cmbRazones.Value
        '                            'End If
        '                            'If oFactura.RazonRechazo.Trim = "" OrElse oFactura.RazonRechazo.Trim.Length < 5 Then
        '                        Else
        '                            'MessageBox.Show("Es necesario seleccionar una raz�n de rechazo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                            'GoTo EspecificaRazon
        '                            Exit Sub
        '                        End If
        '                    End If
        '                ElseIf oFingerPrintMgr.IsClientePGEnFactura(oFactura.ClienteId, FolioSAP) Then
        '                    oFactura.RazonRechazo = "El cliente ya habia sido registrado anteriormente con el codigo: " & CStr(oFactura.ClienteId).PadLeft(10, "0") & _
        '                                            " en la Factura: " & FolioSAP
        '                    oFactura.RazonRechazoID = 0
        '                Else
        '                    oFactura.RazonRechazo = ""
        '                    oFactura.RazonRechazoID = 0
        '                End If
        '            End If
        '            If oFactura.CodVendedor = String.Empty Then
        '                MsgBox("Asigne C�digo de Vendedor.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
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
        '                        MsgBox("La compra debe ser igual o mayor a la cantidad devuelta a Dportenis Vale", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
        '                        grdDetalle.Focus()
        '                        Exit Sub
        '                    End If
        '                End If
        '            End If
        '            If oValeCaja.ValeCajaID > 0 Then
        '                If oFactura.Total < oValeCaja.Importe Then
        '                    MsgBox("La compra debe ser igual o mayor a la cantidad devuelta", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
        '                            MsgBox("Este asociado no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Exclamation, Me.Text)
        '                            Exit Sub
        '                        Else
        '                            MsgBox("Este asociado no tiene descuento por que no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Exclamation, Me.Text)
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
        '                    MsgBox("Debe Ingresar Numero de Autorizaci�n. No se puede continuar. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
        '            '------------------------------------------------------------------------------------------------------------------------------------
        '            'RGERMAIN 29.08.2014: Validamos si el cliente dejo sus datos para enviarle promociones si esta activada la config
        '            '------------------------------------------------------------------------------------------------------------------------------------
        '            If oConfigCierreFI.PedirDatosPromoComienzo AndAlso strDatosPromoClientes.Trim = "" Then
        '                If MessageBox.Show("�Estas seguro que no deseas capturar los datos del cliente para futuras promociones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
        '                    CapturaCelParaSMS()
        '                End If
        '            End If

        '            '-----------------------------------------------------------------------------------------------------------------------------------------
        '            'JNAVA (19.12.2014): Validamos que si NO aplica el CrossSelling, se revisan las promociones vigentes
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
        '                strFolioCupon = InputBox("Especifique el Folio del Cup�n", "Dportenis PRO", "").Trim.ToUpper
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
        '            '------------------------------------------------------------------------------------------------------------------------------------
        '            'Validamos Tipo de Descuento
        '            '------------------------------------------------------------------------------------------------------------------------------------
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

        '                    'A�adimos Evento A TipoDescuento
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
        '                    '    MsgBox("Este tipo de descuento no est� permitido para esta tienda." & vbCrLf & "Debe elegir otro tipo de descuento.", MsgBoxStyle.Exclamation, "Dportenis Pro")
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
        '                    '            MsgBox("S�lo puede aplicar descuentos a 3 piezas. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
        '                    '        Case 2
        '                    '            MsgBox("Existen c�digos con m�s del " & CInt(oValeDescuentoLocalInfo.TipoVale) * 10 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
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
        '            MsgBox("Factura no tiene asignado art�culos.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
        '        End If

    End Sub

    Private Function ValidaPromosFormasPago() As Boolean
        If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then
            Dim oRow As DataRow
            Dim strPagos As String = ""

            For Each oRow In dtDescFormasPago.Rows
                strPagos &= CStr(oRow!Descripcion).Trim & vbCrLf
            Next
            If MessageBox.Show("Las promociones aplicadas est�n condicionadas a las siguientes formas de pago:" & vbCrLf & vbCrLf & _
            strPagos & vbCrLf & "�Deseas aprovechar estas promociones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
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

            'oArtTemp = oArticuloMgr.Create
            'oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArtTemp)
            'If oArtTemp.Exist Then
            '    If (oArtTemp.PrecioVenta * (1 + oAppContext.ApplicationConfiguration.IVA)) < 1 Then
            '        If strCodigosSinPrecio.Trim <> "" Then strCodigosSinPrecio &= ", "
            '        strCodigosSinPrecio &= oArtTemp.CodArticulo.Trim
            '        bRes = False
            '    End If
            '    If oArtTemp.CostoProm <= 0 Then
            '        If strCodigosSinCosto.Trim <> "" Then strCodigosSinCosto &= ", "
            '        strCodigosSinCosto &= oArtTemp.CodArticulo.Trim
            '        bRes = False
            '    End If
            'Else
            '    If strCodigosNoEncontrados.Trim <> "" Then strCodigosNoEncontrados &= ", "
            '    strCodigosNoEncontrados &= CStr(oRow!Codigo).Trim
            '    bRes = False
            '    Exit For
            'End If
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

    Private Function ValidaPromoEspecial(ByVal Folio As String, ByRef oCuponDesc As CuponDescuento) As Boolean

        Dim strMsgError As String = ""

        If IsNumeric(Folio.Trim) Then Folio = Folio.Trim.PadLeft(10, "0")

        '--------------------------------------------------------------------------------------
        ' JNAVA (28.12.2015): Adaptacion para SAP RETAIL
        '--------------------------------------------------------------------------------------
        'oCuponDesc = oSAPMgr.ZCUP_INFO_CUPON(Folio.Trim, Me.ebTipoVenta.Value, strMsgError)
        Dim oRetail As New ProcesosRetail("/pos/cupones", "POST")
        Dim Parametros As New Dictionary(Of String, Object)
        With Parametros
            .Add("I_FOLIO", Folio.Trim)
            .Add("I_TIPO_VENTA", Me.ebTipoVenta.Value.Trim)
            .Add("I_TIENDA", "T" & oAppContext.ApplicationConfiguration.Almacen)
        End With
        '--------------------------------------------------------------------------------------
        ' Seteamos datos de cupon que obtuvimos a los que deben ser
        '--------------------------------------------------------------------------------------
        oCuponDesc = ConvertirACupon(Folio.Trim, oRetail.SapZcupInfocupon(Parametros), strMsgError)
        '--------------------------------------------------------------------------------------

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
        'ValidaValeEmpleadoSAP( _
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
                MessageBox.Show("El vale de descuento est� vencido", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Error)

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
    '        Dim STATU As SAPFunctionsOCX.Parameter           '   Indicador de una posici�n
    '        Dim PORCENTAJE As SAPFunctionsOCX.Parameter           '   Indicador de una posici�n
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
    '            Throw New ApplicationException("No se pudo establecer la conexi�n con SAP.")
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

                    MsgBox("Folio de Factura No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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

        End If

    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating
        If bolCloseForm = False Then
            'If Not (ebClienteID.Value <= 1) Then
            If ebClienteID.Value > 0 Then
                Valida()
                If dsDetalle.Tables(0).Rows.Count > 0 AndAlso dsDetalle.Tables(0).Rows(0)!Codigo <> "" Then
                    '-----------------------------------------------------------------------------------------------------------------------------
                    'Aplicamos las promociones vigentes
                    '-----------------------------------------------------------------------------------------------------------------------------
                    AplicarPromociones()
                End If
            Else
                'ebClienteID.Value = 0
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
        ' If strTipoVenta.Trim = "P" Then
        'GetClientePG(strCodCliente)
        'oClienteMgr.LoadPG(IIf(IsNumeric(strCodCliente), CInt(strCodCliente), 0), oCliente)
        'oCliente.TipoVenta = strTipoVenta
        'Else
        If oConfigCierreFI.UsarDescargaClientes = False Then GetCliente(strCodCliente, oFactura.CodTipoVenta)
        Me.oClienteMgr.Load(strCodCliente, oCliente, oFactura.CodTipoVenta)
        oCliente.TipoVenta = oFactura.CodTipoVenta
        'End If

        If (oCliente Is Nothing) OrElse CDbl(oCliente.CodigoAlterno) <= 0 OrElse (oCliente.CodigoAlterno = String.Empty) OrElse (Not IsNumeric(oCliente.CodigoAlterno)) Then
            MsgBox("Cliente " & strCodCliente & " no est� registrado. No Existe.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Clientes")
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

            ' Se pidi� quitar la validaci�n del l�mite de cr�dito de los clientes DIPS 02/04/2012
            'If oFactura.CodTipoVenta = "D" Then
            '    '--Cargamos Datos de Credito del Asociado

            '    oLimiteCreditoSAP = New CreditoAsociadoSAP
            '    Dim oSAPmgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            '    oLimiteCreditoSAP = oSAPmgr.GetCreditoAsociadoSAP(oCliente.CodigoAlterno.PadLeft(10, "0"))
            '    oSAPmgr = Nothing

            '    If oLimiteCreditoSAP.LimiteCredito = 0 Then
            '        MsgBox("Cliente No cuenta con Cr�dito.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    ElseIf oLimiteCreditoSAP.Bloqueado = "S" Then
            '        MsgBox("Cliente tiene el Cr�dito Bloqueado.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    Else
            '        MsgBox("Cr�dito Disponible : " & Format(oLimiteCreditoSAP.LimiteCredito - oLimiteCreditoSAP.Credito, "Currency"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
            '    End If
            'End If
            '---------------------------------------------------------------------------------------------------------------------------------------------
            'Validamos los datos del Cliente
            '---------------------------------------------------------------------------------------------------------------------------------------------
            If ValidaDatosObligatoriosCliente(oCliente) = False And oFactura.CodTipoVenta <> "D" Then
                If oFactura.CodTipoVenta = "P" Then
                    If MessageBox.Show("El cliente no tiene todos los datos personales registrados." & vbCrLf & vbCrLf & "�Deseas complementarlos en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
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

            MsgBox("Cliente No es Asociado. Tipo de Venta Incorrecto. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturaci�n")
            oFactura.CodTipoVenta = "P"
            oFactura.ClienteId = 10000000
            ebClienteDescripcion.Text = "P�BLICO GENERAL"
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

                    MsgBox("Asociado cuenta con pagos vencidos. Es necesario que regularice sus pagos. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturaci�n")
                    oFactura.ClienteId = 10000000
                    ebClienteDescripcion.Text = "P�BLICO GENERAL"
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

                MsgBox("Asociado no cuenta con Cr�dito Directo en Tienda. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "  Facturaci�n")

            End If

        End If

        Return True

    End Function

    Private Function ValidamosCreditoDirecto() As Boolean

        Dim oProcess As New FacturacionProcess(oAppContext)

        Dim oResult As Boolean

        oResult = oProcess.Verificacion_Credito_Directo(oFactura.ClienteId)

        If Not oResult Then

            oFactura.ClienteId = 10000000
            ebClienteDescripcion.Text = "P�BLICO GENERAL"

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
            If IsNumeric(ebCodVendedor.Text.Trim()) Then
                LoadSearchFormPlayer()
                ebCodVendedor.Focus()
                ebCodVendedor.SelectAll()
            Else
                MessageBox.Show("Los c�digos de vendedor debe ser n�mericos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub ebCodVendedor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodVendedor.Validating

        If oConfigCierreFI.ShowManagerPC AndAlso ebCodVendedor.Text.Trim = "" Then

            ebCodVendedor.Focus()
            Return

        End If
        If ebCodVendedor.Text.Trim <> "" AndAlso ebCodVendedor.Text.Trim <> oFactura.CodVendedor.Trim Then
            If IsNumeric(ebCodVendedor.Text.Trim()) = False Then
                MessageBox.Show("C�digo de vendedor debe ser numerico", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
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
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no est� asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebPlayerDescripcion.Text = ""
                '    e.Cancel = True
                'Else
                ebPlayerDescripcion.Text = oVendedor.Nombre
                oFactura.CodVendedor = oVendedor.ID
                '----------------------------------------------------------------------------------------------------------------------
                'Empezamos a correr el cron�metro
                '----------------------------------------------------------------------------------------------------------------------
                If Me.ebTipoVenta.Value <> "" AndAlso oConfigCierreFI.ShowManagerPC Then EjecutarCronometro(True)
                'End If
            Else
NoExiste:
                MsgBox("C�digo de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n ")

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
        frmClientes.TipoVenta = IIf(oFactura.CodTipoVenta <> "D", "C", oFactura.CodTipoVenta)
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

        Me.ebCodVendedor.Focus()

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
                MsgBox("Tipo de Venta no permitido en este nivel.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Facturaci�n")
                e.Cancel = True
                If oConfigCierreFI.UsarHuellas = False Then ebClienteID.Value = 10000000
                ebClienteDescripcion.Text = "PUBLICO GENERAL"
                ebTipoVenta.Value = "P"
            End If
        ElseIf ebTipoVenta.Value = "S" AndAlso oAppContext.ApplicationConfiguration.Almacen <> "053" Then
            MessageBox.Show("Este tipo de venta no esta permitida para esta tienda.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            If oConfigCierreFI.UsarHuellas = False Then ebClienteID.Value = 10000000
            ebClienteDescripcion.Text = "PUBLICO GENERAL"
            ebTipoVenta.Value = "P"
        End If
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Validamos si tiene catalogos agregados al detalle si cambia el tipo de venta distinto a Dips
        '----------------------------------------------------------------------------------------------------------------------------------------
        If ebTipoVenta.Value = "D" AndAlso ebTipoVenta.Value = "S" Then
            If dsDetalle.Tables.Count <= 0 Then
                GoTo Siguiente
            End If
            If dsDetalle.Tables(0).Rows.Count > 0 Then
                For Each oRow As DataRow In dsDetalle.Tables(0).Rows
                    If oRow("Codigo") <> "" Then
                        oArticulo = oArticuloMgr.Create
                        oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArticulo)
                        If EsCatalogo(CStr(oRow!Codigo).Trim) = False Then
                            MsgBox("Se han agregado catalogos en el detalle. No puede cambiar tipo de venta.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Facturaci�n")
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
Siguiente:
            'Else
            'AplicaDescuentosDips:
            '            AplicaDescuentosDips()
            '            TotalAPagarDips = oFactura.Total
        End If

        '        If Compara = False AndAlso dsDetalle.Tables(0).Rows.Count > 0 AndAlso oFactura.CodTipoVenta <> "E" Then
        '            AplicaPromocionesVigentes()
        '            TotalAPagarPromo = oFactura.Total
        '        End If

        '        If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso Compara = False AndAlso TotalAPagarDips < TotalAPagarPromo Then
        '            Compara = True
        '            GoTo AplicaDescuentosDips
        '        End If



        '----------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos las promociones vigentes
        '----------------------------------------------------------------------------------------------------------------------------------------
        AplicarPromociones()
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

    End Sub

    Private Sub ebTipoVenta_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebTipoVenta.ValueChanged

        oFactura.CodTipoVenta = UCase(ebTipoVenta.Value)
        Select Case oFactura.CodTipoVenta
            Case "V"
PG:
                oFactura.ClienteId = 10000000
                ebClienteID.Enabled = False
                Me.btnAltaCliente.Enabled = False
                Me.ebClienteDescripcion.Text = "P�BLICO GENERAL"
            Case "E"
                oFactura.ClienteId = 10000000
                ebClienteID.Enabled = False
                Me.btnAltaCliente.Enabled = False
                Me.ebClienteDescripcion.Text = "VENTAS A EMPLEADOS"
            Case "P"
                oFactura.ClienteId = 10000000
                ebClienteID.Enabled = False
                Me.btnAltaCliente.Enabled = False
                Me.ebClienteDescripcion.Text = "P�BLICO GENERAL"
            Case Else
                oFactura.ClienteId = 0
                ebClienteID.Enabled = True
                Me.ebClienteDescripcion.Text = ""
                Me.btnAltaCliente.Enabled = True
                'Case "P", "V"
        End Select

        strCondicionVenta = ebTipoVenta.DropDownList.GetValue(2)
        strListaPrecios = ebTipoVenta.DropDownList.GetValue(3)
        Dim row As GridEXRow = ebTipoVenta.DropDownList.GetRow()
        If Not row Is Nothing Then
            Dim motivo As String = CStr(row.Cells(4).Value)
            oFactura.MotivoPedido = motivo
            oFactura.TipoCliente = CStr(row.Cells(5).Value)
        End If
        'oFactura.MotivoPedido = ebTipoVenta.DropDownList.GetRow()

    End Sub

    Private Sub frmFacturacion_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Me.Dispose()

    End Sub

    Private Sub frmFacturacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim intLargo As Integer = 0
        If (e.KeyCode = Keys.Escape) Then

            'Me.Finalize()
            bolCloseForm = True
            Me.Close()

            'ElseIf e.Alt And e.KeyCode = Keys.D Then

            '    If oFactura.CodTipoVenta = "D" Then
            '        
            '            oAppContext.Security.CloseImpersonatedSession()
            '            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
            '                '''Implementar Descuento Adicional
            '                grdDetalle.Cols(6).AllowEditing = True
            '                boolDescuentoDipsEspecial = True
            '            Else
            '                '''Implementar Descuento Adicional
            '                grdDetalle.Cols(6).AllowEditing = False
            '                boolDescuentoDipsEspecial = False
            '            End If
            '        
            '    ElseIf oFactura.CodTipoVenta = "S" Then

            '        If oFactura.CodTipoVenta = "S" Then
            '            oAppContext.Security.CloseImpersonatedSession()
            '            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
            '                '''Implementar Descuento Adicional
            '                grdDetalle.Cols(6).AllowEditing = True
            '                boolDescuentoSocioEspecial = True
            '            Else
            '                '''Implementar Descuento Adicional
            '                grdDetalle.Cols(6).AllowEditing = False
            '                boolDescuentoSocioEspecial = False
            '            End If
            '            oAppContext.Security.CloseImpersonatedSession()
            '        End If

            '    End If

            'ElseIf e.Alt And e.KeyCode = Keys.S Then

            'If oFactura.CodTipoVenta = "S" Then
            '    oAppContext.Security.CloseImpersonatedSession()
            '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
            '        '''Implementar Descuento Adicional
            '        grdDetalle.Cols(6).AllowEditing = True
            '        boolDescuentoSocioEspecial = True
            '    Else
            '        '''Implementar Descuento Adicional
            '        grdDetalle.Cols(6).AllowEditing = False
            '        boolDescuentoSocioEspecial = False
            '    End If
            '    oAppContext.Security.CloseImpersonatedSession()
            'End If

        Else
            'Captura Manual
            'ALLOW
            If Me.ActiveControl Is Me.grdDetalle And Not e.KeyCode = Keys.Enter And Me.grdDetalle.Cols(0).AllowEditing = False Then
                If e.KeyCode = 189 Then
                    str = str & "-"
                Else
                    str = str & Chr(e.KeyCode)
                    Console.WriteLine(str)
                End If


                'MsgBox(e.KeyCode)
                'ALLOW
            ElseIf Me.ActiveControl Is Me.grdDetalle And Me.grdDetalle.Cols(0).AllowEditing = False And Me.grdDetalle.Col = 0 Then
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
                    Console.WriteLine(str)
                    grdDetalle(grdDetalle.Row, grdDetalle.Col) = str
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

                    'If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                    'ALLOW
                    Me.grdDetalle.Cols(0).AllowEditing = False
                    Me.grdDetalle.Cols(1).AllowEditing = False
                    boolManual = True
                    Dim codigo As String = LoadSearchArticulo()
                    If codigo.Trim() <> "" Then
                        grdDetalle(grdDetalle.Row, 0) = codigo
                        CargarCodArticulo(grdDetalle.Row)
                    End If
                    'Else
                    '    'ALLOW
                    '    Me.grdDetalle.Cols(0).AllowEditing = False
                    '    boolManual = False
                    'End If
                    'oAppContext.Security.CloseImpersonatedSession()

                End If

            Case Keys.Escape

                'Try
                '    grdDetalle.Select(grdDetalle.Row, grdDetalle.Col)
                'Catch ex As Exception
                'End Try

            Case Keys.Enter

                Select Case grdDetalle.Col
                    Case 0
                        CargarUPC(grdDetalle.Row, grdDetalle.Col)
                    Case 2
                        CalcularCantidad(grdDetalle.Row, grdDetalle.Col)
                    Case 6
                        grdDetalle.Select(grdDetalle.Row, 0)
                    Case Else
                        grdDetalle.Select(grdDetalle.Row, grdDetalle.Col + 1)

                        grdDetalle.Refresh()
                        If boolManual = False Then
                            grdDetalle.Select(grdDetalle.Row, 0)
                        End If
                End Select

            Case Keys.Insert

                If ValidateRowGrid(grdDetalle.Row) Then


                    'If oAppContext.ApplicationConfiguration.CodigosXFactura <= dsDetalle.Tables(0).Rows.Count Then 'Comentado por ralcaraz
                    'If dsDetalle.Tables(0).Rows.Count > 9 Then 'Comentado por earagon 24.03.2008 prueba de venta con mas de 10 articulos.
                    If dsDetalle.Tables(0).Rows.Count > oAppContext.ApplicationConfiguration.CodigosXFactura Then

                        MsgBox("No puede agregar m�s c�digos a la factura. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Factura")

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

                If dsDetalle.Tables(0).Rows.Count > 0 Then

                    If dsDetalle.Tables(0).Rows.Count = 1 Then
                        If dsDetalle.Tables(0).Rows(nRow).Item(0) <> "" Then
                            Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & grdDetalle(nRow, 0) & "' and Talla = '" & grdDetalle(nRow, 1) & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                            If oDataView.Count > 0 Then
                                If EsCatalogo(CStr(oDataView.Item(0)("Articulo")).Trim) = False Then
                                    'If Mid(CStr(oDataView.Item(0)("Articulo")), 1, 6) = "DT-CAT" Then
                                    strLlevaCatalogo = ""
                                End If
                                oDataView.Delete(0)
                                oFactura.dtMotivos.AcceptChanges()
                                'Dim codigo As String
                                'codigo = CStr(Me.dsDetalle.Tables(0).Rows(grdDetalle.Row)!Codigo)
                                ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
                            End If
                        End If


                        LimpiaDatosGrid(nRow)

                        grdDetalle.Select(nRow, 0)

                        grdDetalle.Focus()

                        grdDetalle.Select(nRow, 0)
                        str = ""

                    Else

                        vRowDelete = True

                        If dsDetalle.Tables(0).Rows(nRow).Item(0) <> "" Then
                            Dim oDataView As New DataView(oFactura.dtMotivos, "Articulo = '" & grdDetalle(nRow, 0) & "' and Talla = '" & grdDetalle(nRow, 1) & "'", "Articulo,Talla", DataViewRowState.CurrentRows)
                            If oDataView.Count > 0 Then
                                If EsCatalogo(oDataView.Item(0)("Articulo")) Then 'Mid(CStr(oDataView.Item(0)("Articulo")), 1, 6) = "DT-CAT" Then
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
                        'Dim codigo As String
                        'codigo = CStr(Me.dsDetalle.Tables(0).Rows(grdDetalle.Row)!Codigo)
                        ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)

                        ActualizaCalculos()

                        grdDetalle.Select(0, 0)

                        grdDetalle.Focus()

                        'ActualizaDatosArticulo(0, grdDetalle.Col)

                        'grdDetalle.ColSel = 0
                        'grdDetalle.RowSel = 0
                    End If
                    ActualizaCalculos()
                End If
                'Captura Manual (Todo el F2)
            Case Keys.F2
                'If grdDetalle.Col = 0 Then

                '    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CapturaManualDeMaterial") = True Then
                '        'ALLOW
                '        boolManual = True
                '        Me.grdDetalle.Cols(0).AllowEditing = True
                '    Else
                '        'ALLOW
                '        Me.grdDetalle.Cols(0).AllowEditing = False
                '        boolManual = False
                '    End If
                '    oAppContext.Security.CloseImpersonatedSession()

                'End If

            Case e.Alt And Keys.D

                If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso grdDetalle.Col = 6 AndAlso EsCatalogo(grdDetalle(grdDetalle.Row, 0)) Then 'Mid(CStr(grdDetalle(grdDetalle.Row, 0)).ToUpper.Trim, 1, 6) = "DT-CAT" Then
                    'oAppContext.Security.CloseImpersonatedSession()
                    'If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Facturacion.Descuentos", "DportenisPro.DPTienda.Facturacion.Descuentos.Dips") Then
                    '''Implementar Descuento Adicional
                    grdDetalle.Cols(6).AllowEditing = True
                    If oFactura.CodTipoVenta = "D" Then
                        boolDescuentoDipsEspecial = True
                    Else
                        boolDescuentoSocioEspecial = True
                    End If
                    'Else
                    '    '''Implementar Descuento Adicional
                    '    grdDetalle.Cols(6).AllowEditing = False
                    '    If oFactura.CodTipoVenta = "D" Then
                    '        boolDescuentoDipsEspecial = False
                    '    Else
                    '        boolDescuentoSocioEspecial = False
                    '    End If
                    'End If
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

    Private Sub AddEmptyRow()
        If ValidateRowGrid(grdDetalle.Row) Then


            'If oAppContext.ApplicationConfiguration.CodigosXFactura <= dsDetalle.Tables(0).Rows.Count Then 'Comentado por ralcaraz
            'If dsDetalle.Tables(0).Rows.Count > 9 Then 'Comentado por earagon 24.03.2008 prueba de venta con mas de 10 articulos.
            If dsDetalle.Tables(0).Rows.Count > oAppContext.ApplicationConfiguration.CodigosXFactura Then

                MsgBox("No puede agregar m�s c�digos a la factura. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Factura")

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

                grdDetalle.Focus()
                grdDetalle.Select(ActualRow, 0)
                grdDetalle.Refresh()

            End If


        Else

            grdDetalle.Focus()
            grdDetalle.Select(grdDetalle.Row, grdDetalle.Col)

        End If
        str = ""
    End Sub

    Private Function BuscarCodigoEnDetalle(ByVal Codigo As String, ByVal Talla As String, ByVal dtDetalle As DataTable) As Integer

        Dim i As Integer = 0

        For Each oRow As DataRow In dtDetalle.Rows

            If CStr(oRow!Codigo).Trim.ToUpper.PadLeft(18, "0") = Codigo.ToUpper.Trim.PadLeft(18, "0") AndAlso CStr(oRow!Talla).Trim.ToUpper = Talla.Trim.ToUpper Then

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

    Private Sub AplicaPromocion2x1YMedio(ByRef dtDetalleTemp As DataTable, ByVal IsPorMarca As Boolean, ByRef dtDetalle As DataTable, _
                                           ByVal Limpiar As Boolean, ByRef PromoID As Integer)

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
                    If EsCatalogo(CStr(dvRow!Codigo).Trim) = False Then
                        ' If Mid(CStr(dvRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
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
                    'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" _
                    If oRowTemp!Checado = False AndAlso EsCatalogo(CStr(oRowTemp!Codigo).Trim) = False _
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
                                'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT"
                                If oRowTemp!Checado = False AndAlso EsCatalogo(CStr(oRowTemp!Codigo).Trim) = False AndAlso _
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
                                'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT"
                                If oRowTemp!Checado = False AndAlso EsCatalogo(oRowTemp!Codigo) = False AndAlso _
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
                        'RGERMAIN 07/05/2013: Se modific� por solicitud de Jose Oscar Sanchez las reglas del 2 x 1 �, pero se dej� configurable 
                        'en caso de que quieran regresar a la forma anterior de la aplicaci�n de la promoci�n
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
                            Else
                                dtDetalle.Rows(idxMay)!Adicional = 0
                                If oConfigCierreFI.NuevaRegla2x1yMedio = False Then
                                    'Forma anterior, se le aplica el resto que le hace falta para completar el 50% de descuento
                                    dtDetalle.Rows(idxMen)!Adicional = Decimal.Round(50 - PorcDescSis, 2)
                                Else
                                    'Forma nueva, se le aplica el 50% de descuento sin importar el descuento que ya tenga por sistema
                                    dtDetalle.Rows(idxMen)!Adicional = 50
                                End If
                                'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                                dtDetalle.Rows(idxMen)!Condicion = "ZDP4"
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
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Si aplic� la promoci�n agregamos las formas de pago para la que solo est� permitida
        '---------------------------------------------------------------------------------------------------------------------------------------
        If bAplica Then
            If IsPorMarca Then
                AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1�M")
            Else
                AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1�G")
            End If
        End If

    End Sub

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

                    If oRowTemp!Checado = False AndAlso ImpMayor < oRowTemp!Importe AndAlso i <> idx AndAlso EsCatalogo(oRowTemp!Codigo) = False Then 'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
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
                        'RGERMAIN 07/05/2013: Se modific� por solicitud de Jose Oscar Sanches las reglas del 2 x 1 �, pero se dej� configurable 
                        'en caso de que quieran regresar a la forma anterior de la aplicaci�n de la promoci�n
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
                    'RGERMAIN 07/05/2013: Se modific� por solicitud de Jose Oscar Sanches las reglas del 2 x 1 �, pero se dej� configurable 
                    'en caso de que quieran regresar a la forma anterior de la aplicaci�n de la promoci�n
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
        'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If aplico Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "2x1�C")
        Return aplico
    End Function

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
                'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
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
            'RGERMAIN 19.08.2014: Separamos los dpaquetes que traen un material con el codigo de uso configurado de los dem�s depaquetes
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
                        strIdxs = str.Split("�")
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
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Validamos si el dpakete aplica o ya otro le gano los codigos
        '---------------------------------------------------------------------------------------------------------------------------------------
        For Each str As String In Result
            If str.Trim <> "" Then
                Descuento = str.Split("�")
                idxRow = CInt(Descuento(0))

                If dvDetalle(idxRow)!UsadoPromo = True Then
                    AplicaDpakete = False
                    Exit For
                End If
            End If
        Next
        If AplicaDpakete Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos del dpakete al detalle de la factura
            '------------------------------------------------------------------------------------------------------------------------------------
            Combinacion &= idxDpakete & ","

            IndicesDesc &= Descuentos

            For Each str As String In Result
                If str.Trim <> "" Then
                    Descuento = str.Split("�")
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
                DPKTIdxs &= idx & "�"
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

    Private Sub AplicaPromocion20y30(ByRef dtDetalle As DataTable, ByVal PromoID As Integer)

        'Dim dtView As New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        Dim dtView As DataView
        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
        Dim PorcSis As Decimal = 0
        Dim idxs As String = ""
        Dim bAplica As Boolean = False
        Dim DescSistema As Decimal = 0
        Dim dtTemp As DataTable, oNewCol As DataColumn
        Dim idxMay As Integer = 0


        'Modificamos la regla, si esta activada la config entonces ordenamos de mayo a menor importe considerando el precio ya restando el descuento por
        'sistema
        If oConfigCierreFI.NuevaRegla20y30 Then

            oNewCol = New DataColumn("ImporteFinal")
            oNewCol.DataType = GetType(Decimal)
            oNewCol.Caption = "ImporteFinal"
            oNewCol.Expression = "Importe - Descuento"

            dtDetalle.Columns.Add(oNewCol)
            dtDetalle.AcceptChanges()

            dtView = New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "ImporteFinal DESC", DataViewRowState.CurrentRows)
        Else
            dtView = New DataView(dtDetalle, "NOT(Codigo like 'DT-CAT%')", "Importe DESC", DataViewRowState.CurrentRows)
        End If

        If dtView.Count > 1 Then
            '-------------------------------------------------------------------------------------------------------------------------------------------
            'Ordenamos de mayor a menor por el importe menos el descuento que trae de sistema
            '-------------------------------------------------------------------------------------------------------------------------------------------
            'For Each oRowV As DataRowView In dtView
            '    oRowV!Checado = False
            'Next

            'LimpiaStatusPromo(dtDetalle, False, dtDetalle)
            i = 0

            For Each oRow As DataRowView In dtView

                'idxMay = i
                'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRow!Codigo)
                'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRow!Codigo) > 0, True, False)
                'Modificamos la regla, si esta activada la config ya no tomamos en cuenta que el producto de mayor precio tenga que ser de precio entero
                If oConfigCierreFI.NuevaRegla20y30 Then
                    DescSistema = 0
                Else
                    DescSistema = oRow!Descuento
                End If
                If DescSistema <= 0 AndAlso InStr(idxs, i) <= 0 AndAlso oRow!UsadoPromo = False Then 'AndAlso Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                    idxs &= i & ","
                    j = 0
                    For Each oRowS As DataRowView In dtView

                        'OtraPromo = oFacturaMgr.IsPromoDosPorUnoYMedioVigente(oRowS!Codigo)
                        'If OtraPromo = False Then OtraPromo = IIf(oFacturaMgr.GetDescuentoAdicional(oRowS!Codigo) > 0, True, False)
                        'Modificamos la regla, si esta activada la config ya no tomamos en cuenta que el segundo producto de mayor precio tenga que ser de 
                        'precio entero
                        If oConfigCierreFI.NuevaRegla20y30 Then
                            DescSistema = 0
                        Else
                            DescSistema = oRowS!Descuento
                        End If
                        If DescSistema <= 0 AndAlso InStr(idxs, j) <= 0 AndAlso oRow!Importe - oRow!Descuento >= oRowS!Importe - oRowS!Descuento AndAlso oRowS!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowS!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                            bAplica = True
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

                            For Each oRowT As DataRowView In dtView

                                'Modificamos la regla, si esta activada la config ya no tomamos en cuenta que el tercer producto tenga un porcentaje de 
                                'descuento menor al 30%
                                If oConfigCierreFI.NuevaRegla20y30 Then
                                    PorcSis = 0
                                Else
                                    PorcSis = Math.Round((oRowT!Descuento * 100 / oRowT!Total), 2)
                                End If

                                If PorcSis < 30 AndAlso InStr(idxs, k) <= 0 AndAlso oRowS!Importe - oRowS!Descuento >= oRowT!Importe - oRowT!Descuento AndAlso oRowT!UsadoPromo = False Then 'AndAlso Mid(CStr(oRowT!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then
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
        'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If bAplica Then AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "20y30")

    End Sub

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

                    If EsCatalogo(oRow!Codigo) = False Then 'Mid(CStr(oRow!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

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

    Private Sub AgregaFormasPagoDescuento(ByVal dtFP As DataTable, ByVal CodPromo As String)

        Dim oRow As DataRow
        Dim dvExis As DataView
        Dim dtFPTotales As DataTable
        Dim bFiltrada As Boolean = True
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Primero validamos si la promoci�n realmente esta condicionada por algunas formas de pago, revisando si las formas de pago permitidas 
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
                    'Revisamos que la forma de pago no est� agregada para hacerlo
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
                        Case "2x1�G"
                            !Descripcion = "Dos Por Uno y Medio General"
                        Case "2x1�M"
                            !Descripcion = "Dos Por Uno y Medio Por Marca"
                        Case "2x1�C"
                            !Descripcion = "Dos Por Uno y Medio Por Codigo"
                        Case "20y30"
                            !Descripcion = "20 y 30 % General"
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
                        Case "CS"
                            !Descripcion = "Cross Selling"
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
                'Si ya est� aplicada la promoci�n anteriormente revisamos si est� condicionada a alguna forma de pago y si es as�, entonces 
                'actualizamos el campo ValidaFP a True para marcar que esta promoci�n s� est� condicionada
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

    Private Function AplicaDescuentosAutomaticos(ByVal dtDetalleTemp As DataTable, ByVal Porc As Decimal, ByVal bAceptaDescuento As Boolean, _
    ByRef oCupon As CuponDescuento) As Boolean

        Dim Desc20y30 As Boolean = False
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

        If Not dtDescFormasPago Is Nothing Then dtDescFormasPago.Clear()

        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Aplicamos Descuento Fijo Por Cliente
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
        '-----------------------------------------------------------------------------------------------------------------------------------------
        bCondicionada = IsPromoCondicionadaFP("DF")
        If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
            DescuentoFijo = AplicaDescuentoFijo(dtDetalleTemp)
        End If
        Dim modulo As String = ""
        Dim check As String = ""
        If Not oCupon Is Nothing Then
            modulo = IIf(oCupon.InfoCupon.ContainsKey("MODULO"), CStr(oCupon.InfoCupon("MODULO")), "")
            check = IIf(oCupon.InfoCupon.ContainsKey("CUPON_CHECK"), oCupon.InfoCupon("CUPON_CHECK"), "")
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
                ' JNAVA (11/11/2015): En caso de que sea cupon para promoci�n del Buen Fin, no realiza esto
                '----------------------------------------------------------------------------------------------------------------------------------------
            ElseIf Not oCupon Is Nothing AndAlso oConfigCierreFI.CuponDescuentos = True AndAlso modulo <> "SH" AndAlso check.ToUpper() <> "X" Then

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
                'RGERMAIN 14.11.2014: Aplicamos este motor de promociones solo si no esta activa la config del nuevo motor de Cross Selling en SAP
                '---------------------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento de los DPaketes y Street Packs
                '---------------------------------------------------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("DPKT")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    Dpaketes = AplicaPromocionDPaketes(dtDetalleTemp)
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 20% y 30%
                '---------------------------------------------------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("20y30")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    Desc20y30 = oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "20y30", PromoID)

                    If Desc20y30 Then
                        AplicaPromocion20y30(dtDetalleTemp, PromoID)
                    End If
                End If
                '---------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 � General
                '---------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("2x1�G")
                '---------------------------------------------------------------------------------------------------------------------------------
                'Si esta promocion esta condicionada por formas de pago especificas y el cliente no acepto las promociones entonces no la aplica
                '---------------------------------------------------------------------------------------------------------------------------------
                If Not (bCondicionada AndAlso bAceptaDescuento = False) Then
                    If Desc20y30 OrElse Dpaketes Then LimpiaStatus = False

                    TipoVenta = oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "2x1", PromoID)

                    If TipoVenta Then

                        DosPorUnoYMedioGeneral = oFacturaMgr.IsPromoDosPorUnoYMedioVigente("@@")

                        If DosPorUnoYMedioGeneral Then

                            AplicaPromocion2x1YMedio(dtDetalleTemp, False, dtDetalleTemp, LimpiaStatus, PromoID)

                        End If

                    End If
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 � Por Marca
                '---------------------------------------------------------------------------------------------------------------------------------
                Dim CodMarca As String = ""
                Dim CodMarcas As String = ""

                bCondicionada = IsPromoCondicionadaFP("2x1�M")
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
                                AplicaPromocion2x1YMedio(dtDetMarcas, True, dtDetalleTemp, LimpiaStatus, PromoID)

                            End If

                        Next

                    End If
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento De la Promocion 2 x 1 � Por Codigo
                '---------------------------------------------------------------------------------------------------------------------------------
                bCondicionada = IsPromoCondicionadaFP("2x1�C")
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
                            AndAlso InStr(CodMarcas, CodMarca) <= 0 AndAlso EsCatalogo(oRowTemp!Codigo) = False Then 'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT" Then

                                AplicaPromocion2x1YMedioPorCodigo(dtDetalleView, oRowTemp, i, PromoID)

                            End If
                            i += 1

                        Next

                    End If
                End If
                '---------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Promocion Descuento Sobre Descuento
                '---------------------------------------------------------------------------------------------------------------------------------
                AplicaDescuentoSobreDescuento(dtDetalleTemp, bAceptaDescuento)
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
            '-----------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/11/2013: En caso de que la promoci�n de nuevo empleado si se aplique toma la nueva
            '-----------------------------------------------------------------------------------------------------------------------------------
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

        Return bolResult

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
                'Calculamos el importe que se bonificar� al total de la factura en base al importe del articulo mas caro que va en esta 
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
                'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
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
            'dtDetalleTemp.AcceptChanges()"
            strMsg = AplicaDescuentoCupon(dtView, oCupon.LimiteDescuento, IIf(oCupon.TipoDescuento = "I", 0, oCupon.Descuento), bNoAplicaEnNinguno)

            'dtView = New DataView(dtDetalleTemp, "UsadoPromo = True", "", DataViewRowState.CurrentRows)
            dtView.RowFilter = "UsadoPromo = True"

            If dtView.Count > 0 Then
                'Validamos si el cupon aplica segun el minimo y maximo segun el tipo de cupon
                CantPiezas = dtView.Count
                If oCupon.TipoDescuento.Trim().ToUpper() = "P" Then
                    If CantPiezas < oCupon.Minimo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle no supera el m�nimo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf CantPiezas > oCupon.Maximo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle supera el m�ximo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    End If
                    If bolResult = False Then LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                ElseIf oCupon.TipoDescuento.Trim().ToUpper() = "I" Then
                    Total = GetTotalFacturaParaCupon(dtView)
                    LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                    dtView.RowFilter = ""
                    If Total < oCupon.Minimo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle no supera el monto m�nimo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf Total > oCupon.Maximo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle supera el monto m�ximo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Function AplicaDescuentoCupon(ByRef dtView As DataView, ByVal LimDesc As Decimal, ByVal Desc As Decimal, ByRef NoAplica As Boolean, _
                                          Optional ByVal Tipo As String = "", Optional ByVal TotalFac As Decimal = 0) As String
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
            strMsg = "Promoci�n de cup�n aplicada con restricciones para algunos productos."
            NoAplica = False
        ElseIf bNoAplica AndAlso bAplica = False Then
            'Entonces no aplico en ningun producto del detalle de la factura el descuento del cupon
            strMsg = "Verifique las restricciones de la promoci�n." & vbCrLf & vbCrLf & "El cup�n no aplica."
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
                        MessageBox.Show("El cup�n no aplica porque el detalle no supera el m�nimo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf CantPiezas > oCupon.Maximo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle supera el m�ximo de piezas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    End If
                    If bolResult = False Then LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                ElseIf oCupon.TipoDescuento.Trim.ToUpper = "I" Then
                    Total = GetTotalFacturaParaCupon(dtView)
                    LimpiaStatusPromo(dtDetalleTemp, False, dtDetalleTemp)
                    dtView.RowFilter = ""
                    If Total < oCupon.Minimo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle no supera el monto m�nimo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bolResult = False
                    ElseIf Total > oCupon.Maximo Then
                        MessageBox.Show("El cup�n no aplica porque el detalle supera el monto m�ximo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    oRow!Condicion = condicion
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
            strMsg = "Promoci�n de cup�n aplicada con restricciones para algunos productos."
            NoAplica = False
        ElseIf bNoAplica AndAlso bAplica = False Then
            'Entonces no aplico en ningun producto del detalle de la factura el descuento del cupon
            strMsg = "Verifique las restricciones de la promoci�n." & vbCrLf & vbCrLf & "El cup�n no aplica."
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

    Private Sub AplicaDescuentoSobreDescuento(ByRef dtDetalleTemp As DataTable, ByVal bAcepta As Boolean)

        Dim i As Integer = 0
        Dim DescGen As Decimal = 0
        Dim DescMarca As Decimal = 0
        Dim CodMarca As String = ""
        Dim PromoID As Integer = 0
        Dim bAplicaG As Boolean = True, bAplicaM As Boolean = True, bAplicaC As Boolean = True
        Dim PromoIDs As String = ""
        '----------------------------------------------------------------------------------------------------------------------------------------
        'Validamos si alguna de estas promociones esta condicionada por formas de pago especificas y si el cliente las acept� para aplicarlas
        '----------------------------------------------------------------------------------------------------------------------------------------
        If IsPromoCondicionadaFP("DSDG") AndAlso bAcepta = False Then bAplicaG = False
        If IsPromoCondicionadaFP("DSDM") AndAlso bAcepta = False Then bAplicaM = False
        If IsPromoCondicionadaFP("DSDC") AndAlso bAcepta = False Then bAplicaC = False

        If bAplicaG OrElse bAplicaM OrElse bAplicaC Then
            For Each oRowTemp As DataRow In dtDetalleTemp.Rows
                '------------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional General si est� vigente
                '------------------------------------------------------------------------------------------------------------------------------------
                DescGen = 0
                'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT"
                If oFacturaMgr.IsTipoVentaPermitida("@@", oFactura.CodTipoVenta, "DA", PromoID) AndAlso oRowTemp!UsadoPromo = False _
                AndAlso oRowTemp!Codigo <> "" AndAlso EsCatalogo(oRowTemp!Codigo) = False AndAlso bAplicaG Then
                    DescGen = oFacturaMgr.GetDescuentoAdicionalPorMarca("@@")
                    oRowTemp!Adicional = DescGen
                    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                    oRowTemp!Condicion = "ZDP4"
                    oRowTemp!UsadoPromo = True
                    If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                        PromoIDs &= PromoID.ToString & ","
                        '---------------------------------------------------------------------------------------------------------------------------
                        'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
                        '---------------------------------------------------------------------------------------------------------------------------
                        AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDG")
                    End If
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional Por Marca si est� vigente
                '-----------------------------------------------------------------------------------------------------------------------------------
                DescMarca = 0
                'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT"
                If DescGen = 0 AndAlso oRowTemp!UsadoPromo = False AndAlso oRowTemp!Codigo <> "" AndAlso _
                EsCatalogo(oRowTemp!Codigo) = False AndAlso bAplicaM Then
                    CodMarca = CStr(oRowTemp!Codigo).Substring(0, 2)
                    If oFacturaMgr.IsTipoVentaPermitida(CodMarca, oFactura.CodTipoVenta, "DA", PromoID) Then
                        DescMarca = oFacturaMgr.GetDescuentoAdicionalPorMarca(CodMarca)
                        oRowTemp!Adicional = DescMarca
                        'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                        oRowTemp!Condicion = "ZDP4"
                        oRowTemp!UsadoPromo = True
                        If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                            PromoIDs &= PromoID.ToString & ","
                            '-----------------------------------------------------------------------------------------------------------------------
                            'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
                            '-----------------------------------------------------------------------------------------------------------------------
                            AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDM")
                        End If
                    End If
                End If
                '-----------------------------------------------------------------------------------------------------------------------------------
                'Aplicamos Descuento Adicional por Codigo si esta vigente
                '-----------------------------------------------------------------------------------------------------------------------------------
                'Mid(CStr(oRowTemp!Codigo).Trim.ToUpper, 1, 6) <> "DT-CAT"	
                If oFacturaMgr.IsTipoVentaPermitida(oRowTemp!Codigo, oFactura.CodTipoVenta, "DA", PromoID) AndAlso DescGen = 0 _
                AndAlso DescMarca = 0 AndAlso oRowTemp!UsadoPromo = False AndAlso oRowTemp!Codigo <> "" AndAlso _
                EsCatalogo(oRowTemp!Codigo) = False AndAlso bAplicaC Then
                    oRowTemp!Adicional = oFacturaMgr.GetDescuentoAdicional(oRowTemp!Codigo)
                    'TODO:Ray cambiar por la real cuando mary cree la condicion de descuento para esta promocion
                    oRowTemp!Condicion = "ZDP4"
                    oRowTemp!UsadoPromo = True
                    If InStr(PromoIDs.Trim, PromoID.ToString) <= 0 Then
                        PromoIDs &= PromoID.ToString & ","
                        '---------------------------------------------------------------------------------------------------------------------------
                        'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
                        '---------------------------------------------------------------------------------------------------------------------------
                        AgregaFormasPagoDescuento(oFacturaMgr.GetFormasPagoByPromocion(PromoID), "DSDC")
                    End If
                End If
                i += 1

            Next
        End If

    End Sub

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

        Select Case e.OldRange.c1
            Case 2
                If dsDetalle.Tables(0).Rows.Count > 0 Then
                    CalcularCantidad(e.OldRange.r1, e.OldRange.c1)
                End If
        End Select
        Exit Sub

        Dim BrandMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.CatalogoMarcasManager(oAppContext)
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

                    If e.NewRange.r1 >= 0 AndAlso grdDetalle(e.NewRange.r1, 0) <> "" Then

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
                                    If CStr(dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo).Trim() <> "" Then
                                        CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                                        If CodeRow > 0 Then

                                            MsgBox("El C�digo / Talla ya fue registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                            e.Cancel = True

                                            grdDetalle.Select(e.OldRange.r1, 0)

                                            grdDetalle.Focus()

                                            Exit Sub

                                        End If
                                    End If     

                                End If

                                If FindTalla(grdDetalle(e.OldRange.r1, 1)) = False Then

                                    MsgBox("Talla no corresponde al Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                    e.Cancel = True

                                    grdDetalle.Select(e.OldRange.r1, 1)

                                    grdDetalle.Focus()

                                    Exit Sub

                                End If

                            Case 2      'Cantidad

                                If grdDetalle(e.OldRange.r1, 2) > ebExistencias.Value Then

                                    MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Factura")

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

                            MsgBox("Ingrese C�digo de Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                            e.Cancel = True

                            LimpiaDatosGrid(e.OldRange.r1)

                            ActualizaCalculos()

                            grdDetalle.Select(e.OldRange.r2, 0)

                            grdDetalle.Focus()

                        Else


                            oArticulo.ClearFields()

                            vNumeroArticulo = 0
                            Dim oCatalogoUPCMgr As CatalogoUPCManager
                            oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
                            If oCatalogoUPCMgr.IsSkuOrMaterial(grdDetalle(e.OldRange.r1, 0)) = "S" Then
                                'If IsNumeric(grdDetalle(e.OldRange.r1, 0)) Then

                                'Es un CodigoUPC
                                Dim dsUPC As New DataTable
                                'Dim oCatalogoUPCMgr As CatalogoUPCManager
                                'oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
                                'On Error Resume Next

                                'dsUPC = oCatalogoUPCMgr.Load2(grdDetalle(e.OldRange.r1, 0))

                                dsUPC = oFacturaMgr.GetUPCData(grdDetalle(e.OldRange.r1, 0))

                                If dsUPC.Rows.Count > 0 Then

                                    'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                    'Mid(UCase(dsUPC.Rows(0).Item("CodArticulo")), 1, 6) = "DT-CAT"
                                    If EsCatalogo(dsUPC.Rows(0).Item("CodArticulo")) = True And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                                        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                            MsgBox("�D� de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                        Else
                                            MsgBox("�D� de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                        End If

                                        e.Cancel = True
                                        grdDetalle(grdDetalle.Row, 0) = ""
                                        grdDetalle.Select(grdDetalle.Row, 0)
                                        Exit Sub
                                    End If

                                    '''''''''''''

                                    oArticuloMgr.LoadInto(dsUPC.Rows(0).Item("CodArticulo"), oArticulo)
                                    grdDetalle(e.OldRange.r1, 0) = oArticulo.CodArtProv
                                    dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = oArticulo.CodArticulo
                                    dsDetalle.Tables(0).AcceptChanges()
                                    'grdDetalle(e.OldRange.r1, 0) = UCase(dsUPC.Rows(0).Item("CodArticulo"))
                                    vNumeroArticulo = dsUPC.Rows(0).Item("Numero")

                                    grdDetalle(e.OldRange.r1, 1) = vNumeroArticulo
                                    '</Captura con lector>
                                    CodeRow = BuscaCodigoEnVenta(grdDetalle(e.OldRange.r1, 0), vNumeroArticulo, e.OldRange.r1)
                                    If CodeRow = 0 Then
                                        ActualizaDatosArticulo(e.OldRange.r1, 0)
                                        If 1 > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
                                            dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = oArticulo.CodArticulo
                                            dsDetalle.Tables(0).AcceptChanges()

                                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                            'AplicaDescuentosAutomaticos()
                                            '/*********************
                                            ActualizaCalculos()
                                            '**************Prueba************************
                                            'SendKeys.Send("{UP}")
                                            If boolManual Then
                                                Dim oForm As New frmMotivosFactura
                                                oForm.Motivos = oFactura.dtMotivos

                                                oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                                                oForm.Articulo = grdDetalle(e.OldRange.r1, 0)
                                                oForm.Talla = grdDetalle(e.OldRange.r1, 1)

                                                oForm.ShowDialog()
                                            End If
                                            'SendKeys.Send("{TAB}")
                                            AddEmptyRow()
                                            e.Cancel = True
                                            'SendKeys.Send("{INSERT}")
                                        End If
                                    Else
                                        ActualizaDatosArticulo(CodeRow - 1, 0)
                                        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
                                    MsgBox("C�digo UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                    e.Cancel = True
                                    LimpiaDatosGrid(e.OldRange.r1)
                                    ActualizaCalculos()
                                    grdDetalle.Focus()
                                    Exit Sub

                                End If

                                dsUPC = Nothing

                            Else        '--NO ES UN CODIGO UPC

                                vCodArticulo = UCase(grdDetalle(e.OldRange.r1, 0))
                                '-------------------------------------------------------------------------------------------------------------
                                'FLIZARRAGA 12/07/2016: Validamos si existe el articulo por el c�digo proveedor
                                '-------------------------------------------------------------------------------------------------------------
                                CodPadreArticulo = oArticuloMgr.ValidaCodigoProveedor(vCodArticulo)
                                If CodPadreArticulo <> "" Then
                                    'oFactura.FacturaArticuloExistencia = 0

                                    vNumStringArticulo = Mid(vCodArticulo, 1, 2)
                                    'SendKeys.Send("{TAB}")
                                    'SendKeys.Send("{UP}")
                                    'grdDetalle.Select(e.OldRange.r1, 1)

                                Else
                                    e.Cancel = True
                                    grdDetalle(grdDetalle.Row, 0) = ""
                                    MessageBox.Show("No existe el c�digo de proveedor", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If

                                Exit Sub

                                ''Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                ''Mid(UCase(vCodArticulo), 1, 6) = "DT-CAT"
                                'If EsCatalogo(vCodArticulo) = True AndAlso Me.ebTipoVenta.Value <> "D" AndAlso Me.ebTipoVenta.Value <> "S" Then
                                '    If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                '        MsgBox("�D� de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                '    Else
                                '        MsgBox("�D� de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                '    End If

                                '    e.Cancel = True
                                '    grdDetalle(grdDetalle.Row, 0) = ""
                                '    grdDetalle.Select(grdDetalle.Row, 0)
                                '    Exit Sub
                                'End If

                                ' '''''''''''''

                                'If IsNumeric(vNumStringArticulo) Then

                                '    '</Captura con Lector>
                                '    vCodArticulo = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                                '    vNumeroArticulo = CDec(vNumStringArticulo) / 2

                                '    '--Obtenemos el Codigo Nuevo
                                '    oArticulo.ClearFields()
                                '    oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                                '    If oArticulo.CodArticulo <> String.Empty Then
                                '        vCodArticulo = oArticulo.CodArticulo
                                '    Else
                                '        oArticulo.ClearFields()
                                '        oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                                '        If oArticulo.CodArticulo <> String.Empty Then
                                '            vCodArticulo = oArticulo.CodArticulo
                                '        End If
                                '    End If

                                '    'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                                '    'Mid(UCase(vCodArticulo), 1, 6) = "DT-CAT"
                                '    If EsCatalogo(vCodArticulo) = True And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                                '        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                                '            MsgBox("�D� de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                                '        Else
                                '            MsgBox("�D� de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                                '        End If

                                '        e.Cancel = True
                                '        grdDetalle(grdDetalle.Row, 0) = ""
                                '        grdDetalle.Select(grdDetalle.Row, 0)
                                '        Exit Sub
                                '    End If

                                '    '''''''''''''


                                '    'Se cambia la talla del material si es accesorio o textil
                                '    If oArticulo.CodCorrida = "ACC" OrElse oArticulo.CodCorrida = "TEX" OrElse oArticulo.CodCorrida = "AC1" Then

                                '        Select Case vNumeroArticulo
                                '            Case "10"
                                '                vNumeroArticulo = "XXL"
                                '            Case "8"
                                '                vNumeroArticulo = "XL"
                                '            Case "6"
                                '                vNumeroArticulo = "L"
                                '            Case "4"
                                '                vNumeroArticulo = "M"
                                '            Case "2"
                                '                vNumeroArticulo = "S"
                                '            Case "1"
                                '                vNumeroArticulo = "XS"
                                '            Case "0"
                                '                vNumeroArticulo = "U"
                                '            Case Else
                                '                vNumeroArticulo = vNumeroArticulo
                                '        End Select


                                '    End If

                                '    'CodeRow = BuscaCodigoEnVenta(UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2)), vNumeroArticulo, e.OldRange.r1)
                                '    CodeRow = BuscaCodigoEnVenta(vCodArticulo, vNumeroArticulo, e.OldRange.r1)

                                '    If CodeRow = 0 Then
                                '        'grdDetalle(e.OldRange.r1, 0) = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                                '        grdDetalle(e.OldRange.r1, 0) = vCodArticulo
                                '        grdDetalle(e.OldRange.r1, 1) = vNumeroArticulo
                                '        ActualizaDatosArticulo(e.OldRange.r1, 0)
                                '        If 1 > ebExistencias.Value Then
                                '            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                '            e.Cancel = True
                                '            LimpiaDatosGrid(e.OldRange.r1)
                                '            grdDetalle.Focus()
                                '        Else
                                '            grdDetalle(e.OldRange.r1, 2) = 1
                                '            grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                                '            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)

                                '            '**************Prueba2************************
                                '            grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)
                                '            '/*********************
                                '            '--Aplicamos Descuento si lo tuviera
                                '            If ebPorcentajeDscto.Value > 0 Then
                                '                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * ebPorcentajeDscto.Value, 2)
                                '            Else
                                '                grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 2) * ebMontoDscto.Value, 2)
                                '            End If

                                '            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                '            'AplicaDescuentosAutomaticos()
                                '            '/*********************
                                '            ActualizaCalculos()
                                '            '**************Prueba2************************
                                '            'SendKeys.Send("{UP}")
                                '            If boolManual Then
                                '                Dim oForm As New frmMotivosFactura
                                '                oForm.Motivos = oFactura.dtMotivos

                                '                oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                                '                oForm.Articulo = grdDetalle(e.OldRange.r1, 0)
                                '                oForm.Talla = grdDetalle(e.OldRange.r1, 1)

                                '                oForm.ShowDialog()
                                '            End If
                                '            'SendKeys.Send("{TAB}")
                                '            'grdDetalle.Col = 1
                                '            'SendKeys.Send("{INSERT}")
                                '        End If
                                '    Else
                                '        ActualizaDatosArticulo(CodeRow - 1, 0)
                                '        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                '            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                '            grdDetalle.Focus()
                                '        Else
                                '            grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                                '            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)

                                '            '**************Prueba2************************
                                '            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                '            '--Aplicamos Descuento si lo tuviera
                                '            If ebPorcentajeDscto.Value > 0 Then
                                '                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 4) * ebPorcentajeDscto.Value, 2)
                                '            Else
                                '                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 2) * ebMontoDscto.Value, 2)
                                '            End If

                                '            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                '            'AplicaDescuentosAutomaticos()
                                '            '**************Prueba2************************
                                '            If boolManual Then
                                '                Dim oForm As New frmMotivosFactura
                                '                oForm.Motivos = oFactura.dtMotivos

                                '                oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                                '                oForm.Articulo = grdDetalle(e.OldRange.r1, 0)
                                '                oForm.Talla = grdDetalle(e.OldRange.r1, 1)

                                '                oForm.ShowDialog()
                                '            End If
                                '        End If
                                '        LimpiaDatosGrid(e.OldRange.r1)
                                '        ActualizaCalculos()
                                '        e.Cancel = True
                                '    End If

                                '    Exit Sub
                                '    '<END/>

                                'End If

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

                                MsgBox("C�digo de Art�culo No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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


                                'Obtenemos Numero Inicio y Numero Fin del Art�culo
                                oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

                                'Obtenemos Tallas de la Corrida del Art�culo
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
                                'If dsDetalle.Tables(0).Rows.Count > 1 Then

                                '    CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                                '    '<Sumar al mismo c�digo>

                                '    If CodeRow > 0 Then 'AndAlso (TipoVenta = False OrElse (oFacturaMgr.IsPromoDosPorUnoYMedioVigente("XX") = False AndAlso oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CodMarca) = False)) Then
                                '        ActualizaDatosArticulo(CodeRow - 1, 0)
                                '        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                '            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                '            grdDetalle.Focus()
                                '        Else
                                '            grdDetalle(CodeRow - 1, 2) = grdDetalle(CodeRow - 1, 2) + 1
                                '            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                '            '**************Prueba************************
                                '            grdDetalle(CodeRow - 1, 4) = Decimal.Round(grdDetalle(CodeRow - 1, 3) * grdDetalle(CodeRow - 1, 2), 2)
                                '            '--Aplicamos Descuento si lo tuviera
                                '            If ebPorcentajeDscto.Value > 0 Then
                                '                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 4) * ebPorcentajeDscto.Value, 2)
                                '            Else
                                '                grdDetalle(CodeRow - 1, 5) = Decimal.Round(grdDetalle(CodeRow - 1, 2) * ebMontoDscto.Value, 2)
                                '            End If

                                '            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                '            'AplicaDescuentosAutomaticos()
                                '            '**************Prueba************************
                                '        End If
                                '        LimpiaDatosGrid(e.OldRange.r1)
                                '        grdDetalle.Select(e.OldRange.r1, 0)
                                '        ActualizaCalculos()
                                '        ActualizaDatosArticulo(e.OldRange.r1, e.OldRange.c1)
                                '        Exit Sub
                                '    End If
                                '    '</Sumar al mismo c�digo>

                                'End If
                                If CStr(dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo).Trim() <> "" Then
                                    Exit Sub
                                End If
                                If FindTalla(grdDetalle(e.OldRange.r1, 1)) = False Then

                                    MsgBox("Talla no corresponde al Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                    e.Cancel = True

                                    grdDetalle.Select(e.OldRange.r1, 1)

                                    grdDetalle.Focus()

                                Else

                                    'Obtenemos Existencia
                                    Dim cuenta As Integer = 0
                                    oFacturaMgr.GetExistenciaCodProveedor(CodPadreArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura, oArticulo, cuenta)
                                    If cuenta > 1 Then

                                        If BrandMgr.Load(oArticulo.CodMarca) Is Nothing Then
                                            MsgBox("La marca del producto no existe en el cat�logo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                            e.Cancel = True

                                            grdDetalle.Focus()

                                            Exit Sub

                                        End If

                                        Dim frmColor As New frmItemColor(CodPadreArticulo, grdDetalle(e.OldRange.r1, e.OldRange.c1))
                                        frmColor.ShowDialog()
                                        If frmColor.Action = Windows.Forms.DialogResult.OK Then
                                            CodeRow = BuscaCodigoEnVentaProveedor(frmColor.Code, e.OldRange.r1)
                                            If CodeRow > 0 Then
                                                ActualizaDatosArticuloProveedor(CodeRow - 1, 0)
                                                If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                                    dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = ""
                                                    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                                    grdDetalle.Focus()
                                                    e.Cancel = True
                                                    Exit Sub
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
                                                    LimpiaDatosGrid(e.OldRange.r1)
                                                    grdDetalle.Select(e.OldRange.r1, 0)
                                                    Exit Sub
                                                End If
                                            Else
                                                oArticulo.ClearFields()
                                                oArticuloMgr.LoadInto(frmColor.Code, oArticulo)
                                                ActualizaDatosArticuloProveedor(e.OldRange.r1, e.OldRange.c1)
                                                dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = oArticulo.CodArticulo
                                                dsDetalle.Tables(0).AcceptChanges()
                                                'Obtenemos Numero Inicio y Numero Fin del Art�culo
                                                oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                                                If oFactura.FacturaArticuloExistencia = 0 Then
                                                    dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = ""
                                                    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                                    e.Cancel = True
                                                    grdDetalle.Select(e.OldRange.r1, 1)
                                                    grdDetalle.Focus()
                                                    e.Cancel = True
                                                    Exit Sub
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
                                                End If
                                            End If

                                        Else
                                            e.Cancel = True
                                            Exit Sub
                                        End If
                                    Else
                                        'Verificamos si el Articulo ya esta en la venta
                                        If dsDetalle.Tables(0).Rows.Count > 0 Then
                                            CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)
                                            If CodeRow > 0 Then
                                                ActualizaDatosArticulo(CodeRow - 1, 0)
                                                If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                                                    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                                                    grdDetalle.Focus()
                                                    Exit Sub
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
                                                End If
                                                LimpiaDatosGrid(e.OldRange.r1)
                                                grdDetalle.Select(e.OldRange.r1, 0)
                                                ActualizaCalculos()
                                                ActualizaDatosArticulo(e.OldRange.r1, e.OldRange.c1)
                                                Exit Sub
                                            Else
                                                ActualizaDatosArticulo(e.OldRange.r1, e.OldRange.c1)
                                                'oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura, oArticulo.CodElectronico)
                                                dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = oArticulo.CodArticulo
                                                dsDetalle.Tables(0).AcceptChanges()
                                                'Obtenemos Numero Inicio y Numero Fin del Art�culo
                                                oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                                                If oFactura.FacturaArticuloExistencia = 0 Then
                                                    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                                    e.Cancel = True

                                                    grdDetalle.Select(e.OldRange.r1, 1)

                                                    grdDetalle.Focus()
                                                    Exit Sub
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
                                                End If
                                            End If
                                        End If
                                    End If
                                    ActualizaCalculos()
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
                                    ''oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura, oArticulo.CodElectronico)
                                    'dsDetalle.Tables(0).Rows(e.OldRange.r1)!Codigo = oArticulo.CodArticulo
                                    'dsDetalle.Tables(0).AcceptChanges()
                                    ''Obtenemos Numero Inicio y Numero Fin del Art�culo
                                    'oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                                    'If oFactura.FacturaArticuloExistencia = 0 Then

                                    '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                                    '    e.Cancel = True

                                    '    grdDetalle.Select(e.OldRange.r1, 1)

                                    '    grdDetalle.Focus()


                                    '    'ElseIf oFactura.FacturaArticuloExistencia = SumaCantidad(oArticulo.CodArticulo, grdDetalle(e.OldRange.r1, e.OldRange.c1)) Then

                                    '    '    MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, " Facturaci�n")

                                    '    '    e.Cancel = True

                                    '    '    grdDetalle.Select(e.OldRange.r1, 1)

                                    '    '    grdDetalle.Focus()

                                    'Else
                                    '    grdDetalle(e.OldRange.r1, 2) = 1
                                    '    grdDetalle(e.OldRange.r1, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                                    '    grdDetalle(e.OldRange.r1, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)

                                    '    '**************Prueba2************************
                                    '    grdDetalle(e.OldRange.r1, 4) = Decimal.Round(grdDetalle(e.OldRange.r1, 3) * grdDetalle(e.OldRange.r1, 2), 2)
                                    '    '/*********************
                                    '    '--Aplicamos Descuento si lo tuviera
                                    '    If ebPorcentajeDscto.Value > 0 Then
                                    '        grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 4) * ebPorcentajeDscto.Value, 2)
                                    '    Else
                                    '        grdDetalle(e.OldRange.r1, 5) = Decimal.Round(grdDetalle(e.OldRange.r1, 2) * ebMontoDscto.Value, 2)
                                    '    End If

                                    '    '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                                    '    'AplicaDescuentosAutomaticos()
                                    '    '/*********************
                                    '    ActualizaCalculos()
                                    '    'MOTIVOs Captura Manual
                                    '    'Validar que este en modo de captura manual
                                    '    If boolManual Then
                                    '        Dim oForm As New frmMotivosFactura
                                    '        oForm.Motivos = oFactura.dtMotivos

                                    '        oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                                    '        oForm.Articulo = grdDetalle(e.OldRange.r1, 0)
                                    '        oForm.Talla = grdDetalle(e.OldRange.r1, 1)

                                    '        oForm.ShowDialog()
                                    '    End If


                                    'End If

                                End If

                            End If

                        Else
                            If CStr(grdDetalle(e.OldRange.r1, 1)).Trim() <> "" Then
                                e.Cancel = True
                            End If


                            'If oArticulo.CodCorrida <> "ACC" And oArticulo.CodCorrida <> "TEX" Then

                            '    MsgBox("Talla no corresponde al Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturaci�n")

                            '    e.Cancel = True

                            '    grdDetalle.Select(e.OldRange)

                            '    grdDetalle.Focus()

                            'Else

                            '    'Verificamos si el Articulo ya esta en la venta
                            '    If dsDetalle.Tables(0).Rows.Count > 1 Then

                            '        CodeRow = BuscaCodigoEnVenta(UCase(grdDetalle(e.OldRange.r1, 0)), grdDetalle(e.OldRange.r1, 1), e.OldRange.r1)

                            '        '<Sumar al mismo c�digo>
                            '        If CodeRow > 0 Then
                            '            ActualizaDatosArticulo(CodeRow - 1, 0)
                            '            If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                            '                MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturaci�n")
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
                            '        '</Sumar al mismo c�digo>

                            '    End If

                            '    'Obtenemos Existencia
                            '    oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura)

                            '    If oFactura.FacturaArticuloExistencia = 0 Then

                            '        MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Facturaci�n")

                            '        e.Cancel = True

                            '        grdDetalle.Select(e.OldRange)

                            '        grdDetalle.Focus()

                            '    End If

                            'End If

                        End If

                    Case 2  'Columna CANTIDAD

                        If grdDetalle(e.OldRange.r1, 2) <= 0 And oFactura.FacturaArticuloExistencia > 0 Then

                            MsgBox("Cantidad debe ser mayor a Cero. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                            e.Cancel = True

                            grdDetalle.Select(e.OldRange)

                            grdDetalle.Focus()

                            'ElseIf grdDetalle(e.OldRange.r1, 2) > 1 AndAlso TipoVenta = True AndAlso (oFacturaMgr.IsPromoDosPorUnoYMedioVigente("XX") OrElse oFacturaMgr.IsPromoDosPorUnoYMedioVigente(CodMarca)) Then

                            '    MessageBox.Show("La cantidad no debe ser mayor a uno mientras est� vigente la promoci�n 2 x 1 �", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            '    e.Cancel = True

                            '    grdDetalle.Select(e.OldRange)

                            '    grdDetalle.Focus()

                        Else
                            If grdDetalle(e.OldRange.r1, 2) > oFactura.FacturaArticuloExistencia Then

                                MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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

            'If Me.boolDescuentoDipsEspecial AndAlso EsCatalogo(vCodigo) = True Then 'Mid(vCodigo.ToUpper.Trim, 1, 6) = "DT-CAT" Then
            '    grdDetalle.Cols(6).AllowEditing = True
            'Else
            '    grdDetalle.Cols(6).AllowEditing = False
            'End If

        End If

    End Sub

    Private Sub grdDetalle_KeyDownEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles grdDetalle.KeyDownEdit

        Select Case e.KeyCode

            Case Keys.Enter

                If grdDetalle.Col = 6 Then

                    grdDetalle.Select(grdDetalle.Row, 0)

                Else

                    grdDetalle.Select(grdDetalle.Row, grdDetalle.Col + 1)

                    If grdDetalle(grdDetalle.Row, 0) = String.Empty Then

                        grdDetalle.Select(grdDetalle.Row, 0)

                    End If

                End If

            Case Keys.Escape

                Me.Finalize()

        End Select

    End Sub

    Private Sub grdDetalle_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grdDetalle.Validating

        Dim Compara As Boolean = False
        Dim TotalAPagarDip As Decimal = 0
        Dim TotalAPagarPromo As Decimal = 0
        ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
        AplicarPromociones()
        Exit Sub
        If Not vApartadoInstance Then

            Dim codeRow As Integer = 0

            '</Verificamos ultima informacion>
            Dim nRow As DataRow

            If grdDetalle.Row < 0 Then
                nRow = dsDetalle.Tables(0).Rows(0)
            Else
                nRow = dsDetalle.Tables(0).Rows(grdDetalle.Row)
            End If

            If nRow!Codigo = String.Empty Or (nRow!Talla = String.Empty And nRow!Cantidad = 0) Then
                Me.grdDetalle.Cols(0).AllowEditing = False
                str = ""
                'If dsDetalle.Tables(0).Rows.Count > 1 Then

                '    dsDetalle.Tables(0).Rows(grdDetalle.Row).Delete()
                '    dsDetalle.AcceptChanges()
                '    grdDetalle.Select(0, 0)
                '    ActualizaDatosArticulo(0, grdDetalle.Col)

                'Else

                '    If grdDetalle.Row >= 0 Then LimpiaDatosGrid(grdDetalle.Row)

                'End If

            Else

                If FindTalla(nRow!Talla) = False Then

                    MsgBox("Talla no corresponde al Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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

                            MsgBox("El C�digo / Talla ya fue registrado. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

                            e.Cancel = True

                            grdDetalle.Select(grdDetalle.Row, 1)

                            grdDetalle.Focus()

                            Exit Sub

                        End If

                    End If

                    If nRow!Cantidad <= 0 Then

                        MsgBox("Cantidad debe ser mayor a cero. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Factura")

                        e.Cancel = True

                        grdDetalle.Focus()

                        Exit Sub

                    Else

                        If nRow!Cantidad > ebExistencias.Value Then

                            MsgBox("Cantidad debe ser menor o igual a la Existencia. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")

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
                            MsgBox("Solo puede aplicar hasta el " & oAppContext.ApplicationConfiguration.Descuento * 100 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
            '            ''</Contamos las piezas de la factura y  verificamos descuento maximo>
            '            'Dim oRow As DataRow, vTPiezas As Integer = 0
            '            'For Each oRow In dsDetalle.Tables(0).Rows
            '            '    vTPiezas = vTPiezas + oRow("Cantidad")
            '            'Next
            '            'oRow = Nothing
            '            'TotalPiezasFactura = vTPiezas
            '            ''<End/>

            '            'If ebTipoVenta.Value = "D" Then 'And boolDescuentoDipsEspecial = False Then     '-- Asociados DIP's
            '            '    If dsDetalle.Tables(0).Rows.Count > 0 Then
            '            '        '--Calculamos Descuentos para el Asociado
            '            '        Dim bolOverFlowDescuento As Boolean = False
            '            '        Dim oDsctoGeneral As Decimal = 0
            '            '        Dim oDsctoArticulo As Decimal = 0
            '            '        Dim iFil As Integer = 0

            '            '        If vTPiezas = 0 Then
            '            '            oFactura.DescTotal = 0
            '            '        Else
            '            '            oFactura.DescTotal = 0

            '            '            'verificamos si ya compro el catalogo
            '            '            strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

            '            '            'Checamos si lleva el catalogo (Libro)
            '            '            For Each oRow In dsDetalle.Tables(0).Rows
            '            '                If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
            '            '                    strLlevaCatalogo = "S"
            '            '                    Exit For
            '            '                Else
            '            '                    strLlevaCatalogo = ""
            '            '                End If
            '            '            Next

            '            '            For Each oRow In dsDetalle.Tables(0).Rows
            '            '                '--oRow!Descuento = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))


            '            '                If strCat = "S" Then 'S=Ya lo compro     X=No lo ha comprado
            '            '                    'validar que en el detalle no le aplique descuento a los catalogos (Libros)
            '            '                    If Mid(oRow("Codigo"), 1, 6) <> "DT-CAT" Then
            '            '                        oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
            '            '                    End If
            '            '                Else
            '            '                    'Si lleva el catalogo por primera vez le aplica descuentos a los articulos
            '            '                    If strLlevaCatalogo = "S" Then
            '            '                        'validar que en el detalle no le aplique descuento a los catalogos (Libros)
            '            '                        If Mid(oRow("Codigo"), 1, 6) <> "DT-CAT" Then
            '            '                            oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))
            '            '                        End If
            '            '                    Else
            '            '                        oRow!Adicional = 0
            '            '                    End If

            '            '                End If

            '            '                iFil = iFil + 1

            '            '            Next
            '            '            ActualizaCalculos()
            '            '        End If
            '            '    End If

            '            'ElseIf ebTipoVenta.Value = "S" Then

            '            '    If boolDescuentoSocioEspecial = False Then

            '            '        For Each oRow In dsDetalle.Tables(0).Rows

            '            '            oRow!Adicional = AplicaDescuentoAsociado(vTPiezas, oRow("Codigo"), oRow("Total"))

            '            '        Next

            '            '    End If

            '            '    ActualizaCalculos()

            '            'Else

            '            '    If ebTipoVenta.Value = "D" Then

            '            '        'verificamos si ya compro el catalogo
            '            '        strCat = oSAPMgr.Write_Select_Dips(CStr(oFactura.ClienteId).PadLeft(10, "0"))

            '            '        'Checamos si lleva el catalogo (Libro)
            '            '        For Each oRow In dsDetalle.Tables(0).Rows
            '            '            If Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
            '            '                strLlevaCatalogo = "S"
            '            '                Exit For
            '            '            Else
            '            '                strLlevaCatalogo = ""
            '            '            End If
            '            '        Next

            '            '    End If

            '            '    ActualizaCalculos()
            '            'End If
            '            'If Me.boolDescuentoDPakete = False Then
            '            '--------------------------------------------------------------------------------------------------------------------------------
            '            'Aplicamos los descuentos dips de la forma seg�n este configurada la aplicaci�n
            '            '--------------------------------------------------------------------------------------------------------------------------------
            '            If oConfigCierreFI.AplicaNewDescuentosDIPs = False Then
            '                AplicaDescuentosDips()
            '            Else
            '                AplicaDescuentosDips()
            '                'NuevosDescuentosDips()
            '            End If

            '            TotalAPagarDip = oFactura.Total

            '            If Compara = False AndAlso dsDetalle.Tables(0).Rows.Count > 0 AndAlso oFactura.CodTipoVenta <> "E" Then
            '                AplicaPromocionesVigentes()
            '                TotalAPagarPromo = oFactura.Total
            '            End If

            '            If (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") AndAlso TotalAPagarDip < TotalAPagarPromo AndAlso Compara = False Then
            '                Compara = True
            '                GoTo AplicaDescuentosDips
            '            End If

            '            VerificaCondicionDescuento(dsDetalle.Tables(0))

            '------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos las promociones vigentes
            '------------------------------------------------------------------------------------------------------------------------------------
            AplicarPromociones()

            '-----------------------------------------------------------------------------------------
            ' JNAVA 25.06.2015: sacamos total en base a precio unitario con iva
            '-----------------------------------------------------------------------------------------
            'Dim TotalIVA As Decimal = Decimal.Zero
            'If dsDetalle.Tables.Count > 0 Then
            '    Dim Subtotal As Decimal = Decimal.Zero
            '    Dim PrecioUnitIVA As Decimal = Decimal.Zero
            '    For Each oRowA As DataRow In dsDetalle.Tables(0).Rows
            '        PrecioUnitIVA = CDec(oRowA(3)) * (oAppContext.ApplicationConfiguration.IVA + 1)
            '        PrecioUnitIVA = Truncar(PrecioUnitIVA, 2) 'Truncamos para dejar
            '        Subtotal = PrecioUnitIVA * CInt(oRowA(2))
            '        TotalIVA += Subtotal
            '    Next
            'End If
            'oFactura.Total = TotalIVA - oFactura.DescTotal
            '-----------------------------------------------------------------------------------------

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

    Private Function IsDip(ByVal Codigo As String) As Boolean
        Dim articuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim art As Articulo = articuloMgr.Create()
        art.ClearFields()
        articuloMgr.LoadInto(Codigo, art)
        Return art.Dip
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
                'Si no ha comprado el cat�logo (Libro), checamos si lo lleva en el detalle de la factura
                '----------------------------------------------------------------------------------------------------------------------
                If strCat.Trim <> "S" Then
                    strLlevaCatalogo = ""
                    For Each oRow In dsDetalle.Tables(0).Rows
                        If EsCatalogo(oRow("Codigo")) = True Then 'Mid(oRow("Codigo"), 1, 6) = "DT-CAT" Then
                            strLlevaCatalogo = "S"
                            Exit For
                        End If
                    Next
                End If

                If strCat.Trim = "S" OrElse strLlevaCatalogo.Trim = "S" Then
                    For Each oRow In dsDetalle.Tables(0).Rows
                        '----------------------------------------------------------------------------------------------------------------------
                        'Validar que en el detalle no le aplique descuento a los cat�logos (Libros)
                        '----------------------------------------------------------------------------------------------------------------------
                        'Mid(oRow("Codigo"), 1, 6) <> "DT-CAT"
                        If EsCatalogo(oRow("Codigo")) = False AndAlso oRow("Codigo") <> "" Then
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
        Dim modulo As String = ""
        Dim check As String = ""
        If Not oCuponDesc Is Nothing Then
            modulo = IIf(oCuponDesc.InfoCupon.ContainsKey("MODULO"), CStr(oCuponDesc.InfoCupon("MODULO")), "")
            check = IIf(oCuponDesc.InfoCupon.ContainsKey("CUPON_CHECK"), CStr(oCuponDesc.InfoCupon("CUPON_CHECK")), "")
        End If
        '------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (04.12.2014): Calculamos si se aplicara descuento o no en las Ventas de electronicos
        '------------------------------------------------------------------------------------------------------------------------------------
        CalculoVentaElectronicos()

AplicaDescuentosDips:
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'Si es tipo de venta DIPs o Socios aplicamos el descuento exclusivo para estos clientes
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If InStr("D,S", Me.ebTipoVenta.Value) > 0 AndAlso oCuponDesc Is Nothing Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos dips de la forma seg�n este configurada la aplicaci�n
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
        ElseIf InStr("D,S", Me.ebTipoVenta.Value) > 0 AndAlso modulo.ToUpper() = "SH" Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos los descuentos dips de la forma seg�n este configurada la aplicaci�n
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
            If oConfigCierreFI.CuponDescuentos = True AndAlso (oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "S") = True AndAlso modulo.ToUpper() = "SH" Then
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
        ' JNAVA (11/11/2015): En caso de que sea cupon para promoci�n del Buen Fin, que se aplique con todas las demas promociones
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not oCuponDesc Is Nothing AndAlso check.ToUpper() = "X" Then
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

        dsTemp = DesAgruparCodigos(dsDetalle).Copy

        bolResult = AplicaDescuentosAutomaticos(dsTemp.Tables(0), Porc, bAceptaPromo, oCupon)

        dsTemp = AgruparCodigos(dsTemp).Copy
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 14.11.2014: Solo si no est� la configuracion del Cross Selling activa actualizamos los descuentos aplicados en el detalle de
        'la factura con el motor anterior
        '--------------------------------------------------------------------------------------------------------------------------------------
        'If oConfigCierreFI.AplicaCrossSelling = False Then ActualizaDescuentosAdicionales(dsTemp.Tables(0))
        ActualizaDescuentosAdicionales(dsTemp.Tables(0))

        ActualizaCalculos()

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
            Dim htTotales As Hashtable

            oSAPMgr.ZCS_ALGORITMO_PROMOS_GETDATA(dtDetalleTemp, Me.ebTipoVenta.Value, Today, htTotales, dtMatDesc, dtPromosCS, dtCS)
            'oSAPMgr.ZCS_ALGORITMO_PROMOS(dtDetalleTemp, Me.ebTipoVenta.Value, Today, htTotales, dtMatDesc, dtPromosCS, dtCS)
            'si se aplico algun descuento al detalle de la factura ejecutar la RFC de las formas de pago para saber por cuales formas de pago 
            'estan condicionadas
            ValidaPromoAplicadaCS(dtPromosCS)
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
                For Each oRowV In dvDetalle
                    oRowV!Codigo = CStr(oRowV!Codigo).Trim.PadLeft(18, "0")
                Next

                dvDetalle.RowFilter = "Codigo = '" & CStr(oRow!MATNR).Trim & "' " 'And Talla = '" & strTalla & "'"
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
            'dtFPSAP = oSAPMgr.ZCS_PROMO_VIGENTES(Today, dtPromosCSVig).Copy
            Dim oRetail As New ProcesosRetail("/pos/cs", "POST")
            dtFPSAP = oRetail.SapZcsPromoVigentes(Today, "T" & oAppContext.ApplicationConfiguration.Almacen, dtPromosCSVig).Copy()
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
            'Si aplic� la promoci�n agregamos las formas de pago para las cuales est� permitida
            '---------------------------------------------------------------------------------------------------------------------------
            AgregaFormasPagoDescuento(dtFP, "CS")
        End If

        Return bRes

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

    Private Sub LoadSearchFormFactura()
        strQuin = 0
        'intNUMVA = 0
        strNUMVA = ""
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
                MsgBox("Folio de Factura No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                ebFolioFactura.Focus()
            Else

                'CArgamos folio sap
                EbFolioSAP.Visible = True

                '--Cargamos Cliente
                oCliente.Clear()
                If ebClienteID.Value = 10000000 Then
                    oFactura.ClienteId = 10000000
                    ebClienteDescripcion.Text = "P�BLICO GENERAL"
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
                    Dim oDPVale As New cDPVale

                    'strQuin = oSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oAppSAPConfig.Plaza, oFactura.Fecha, oFactura.Total, CStr(dpValeId), FechaCobro, dtDetalleVale)
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 15.02.2014: Se modifico la forma de obtener el numero de quincenas de un dpvale usado en una factura porque cuando fue usado
                    '                     con la promoci�n Compre ahora y pague despues ya no cuadraban las quincenas
                    '--------------------------------------------------------------------------------------------------------------------------------------
                    If dpValeId.Trim() <> "" Then
                        'intNUMVA = dpValeId
                        strNUMVA = dpValeId
                        oDPVale.I_RUTA = "X"
                        oDPVale.INUMVA = dpValeId.Trim().PadLeft(10, "0")

                        '----------------------------------------------------------------------------------------
                        ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                        '----------------------------------------------------------------------------------------
                        Dim oS2Credit As New ProcesosS2Credit
                        'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

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

                        If oDPVale.InfoDPVALE.Rows.Count > 0 Then
                            If oDPVale.InfoDPVALE.Rows(0)!NUMDE <> "" Then
                                strQuin = oDPVale.InfoDPVALE.Rows(0)!NUMDE ' oDPVale.INUMVA 
                            End If
                        End If


                        '---------------------------------------------------------------------------------------------------
                        ' JNAVA (17.02.2017): Obtenemos los datos del cliente y el distribuidor
                        '---------------------------------------------------------------------------------------------------
                        Dim oClienteSAP As New ClientesSAP
                        Dim CodCliente As String = CStr(oDPVale.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0")
                        Dim CodDistr As String = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadLeft(10, "0")

                        oClienteSAP = GetClienteDPVale(CodCliente)

                        vNombreAsociado = NombreDistribuidor & " (" & CodDistr & ")"
                        If Not oClienteSAP Is Nothing Then
                            vNombreClienteAsociado = oClienteSAP.Nombre & " " & oClienteSAP.Apellidos & " (" & CodCliente & ")"
                        Else
                            vNombreClienteAsociado = String.Empty
                        End If

                        '---------------------------------------------------------------------------------------------------

                    End If
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

    Private Sub CreateTempData()

        dsDetalle = Nothing
        dsDetalle = New DataSet
        Dim dtDetalle As New DataTable("Detalle")

        Dim dCol As DataColumn
        Dim dRow As DataRow



        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "CodProveedor"
        dCol.Caption = "C�digo"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = True
        dCol.MaxLength = 50
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
        dCol = New DataColumn("Codigo")
        dCol.DataType = System.Type.GetType("System.String")
        dCol.Caption = "C�digo"
        dCol.DefaultValue = ""
        dtDetalle.Columns.Add(dCol)

        dsDetalle.Tables.Add(dtDetalle)

        grdDetalle.DataSource = Nothing

        grdDetalle.DataSource = dsDetalle.Tables(0)

        grdDetalle.Cols(0).Width = 185
        grdDetalle.Cols(1).Visible = True
        grdDetalle.Cols(1).Format = "##0.0"
        grdDetalle.Cols(1).Width = 57
        grdDetalle.Cols(1).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
        grdDetalle.Cols(2).Width = 63
        grdDetalle.Cols(2).Format = "##0"
        grdDetalle.Cols(3).Width = 80
        grdDetalle.Cols(3).Format = "$ ###,##0.00"
        grdDetalle.Cols(3).AllowEditing = False
        grdDetalle.Cols(4).Width = 80
        grdDetalle.Cols(4).Format = "$ ###,##0.00"
        grdDetalle.Cols(4).AllowEditing = False
        grdDetalle.Cols(5).Width = 80
        grdDetalle.Cols(5).Format = "$ ###,##0.00"
        grdDetalle.Cols(5).AllowEditing = False
        grdDetalle.Cols(6).Width = 80
        grdDetalle.Cols(6).Format = "##0.00"
        grdDetalle.Cols(6).AllowEditing = False
        grdDetalle.Cols(7).Visible = False
        grdDetalle.Cols(8).Visible = False
        grdDetalle.Cols(9).Visible = False
        grdDetalle.Cols(10).Visible = False
        Me.grdDetalle.Cols(1).AllowEditing = False
        If vApartadoInstance = False Then
            dRow = dsDetalle.Tables(0).NewRow()
            dsDetalle.Tables(0).Rows.Add(dRow)
        End If

    End Sub

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

                MsgBox("Los siguientes datos no son correctos. " & vbCrLf & vbCrLf & mMensaje, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "   Facturaci�n")

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
        grdDetalle(oRow, 0) = ""
        grdDetalle(oRow, 1) = ""
        grdDetalle(oRow, 2) = 0
        grdDetalle(oRow, 3) = 0
        grdDetalle(oRow, 4) = 0
        grdDetalle(oRow, 5) = 0
        grdDetalle(oRow, 6) = 0
        If grdDetalle.Rows.Count = 1 Then
            dsDetalle.Tables(0).Rows(0)!Codigo = ""
        End If

    End Sub

    Private Sub FillTipoVenta()

        Dim oTipoVentaMgr As New TiposVentaManager(oAppContext)
        dsTipoVenta = oTipoVentaMgr.Load()
        '---------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 16/10/2014: No se carga el tipo de venta de socios
        '---------------------------------------------------------------------------------------------------------------
        Dim dv As DataView
        If oConfigCierreFI.TipoVentaFactFiscal = True Then
            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'S'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        Else
            dv = New DataView(dsTipoVenta.Tables(0), "CodTipoVenta <> 'S' AND CodTipoVenta <> 'I'", "CodTipoventa desc", DataViewRowState.CurrentRows)
        End If

        'ebTipoVenta.SetDataBinding(dsTipoVenta, dsTipoVenta.Tables(0).TableName)
        ebTipoVenta.DataSource = dv
        ebTipoVenta.DisplayMember = "Descripcion"
        ebTipoVenta.ValueMember = "CodTipoVenta"
        ebTipoVenta.Value = "P"

        ebTipoVenta.Refresh()

        oTipoVentaMgr.Dispose()

        strCondicionVenta = ebTipoVenta.DropDownList.GetValue(2)
        strListaPrecios = ebTipoVenta.DropDownList.GetValue(3)



        Dim dvTipoVenta As New DataView(dsTipoVenta.Tables(0), "CodTipoVenta = 'P'", "CodTipoVenta", DataViewRowState.CurrentRows)

        strCondicionVenta = dvTipoVenta(0)("CodSAP")
        strListaPrecios = dvTipoVenta(0)("ListaPrecios")
        oFactura.MotivoPedido = dvTipoVenta(0)("MotivoPedido")
        oFactura.TipoCliente = dvTipoVenta(0)("TipoCliente")
        ebTipoVenta.Value = "P"

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
                ebCodVendedor.Focus()

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

                ebCodVendedor.Focus()

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
            If oOpenRecordDialogView.Record Is Nothing Then
                Exit Sub
            End If
            oVendedor.ClearFields()
            oVendedoresMgr.LoadInto(oOpenRecordDialogView.Record.Item("CodVendedor"), oVendedor)
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 18.02.2016: Ya no se necesita validar si el vendedor esta asignado a alguna oficina de venta
            '------------------------------------------------------------------------------------------------------------------------------------
            'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)
            'Select Case strRes
            '    Case "0"
            '        MsgBox("C�digo de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n ")
            '        oOpenRecordDialogView.Dispose()
            '        oOpenRecordDialogView = Nothing
            '        Exit Sub
            '    Case "2"
            '        MessageBox.Show("El Vendedor " & oVendedor.ID & " no est� asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            MsgBox("Corrida del Art�culo NO EXISTE.  ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "  Facturaci�n")

        End If

    End Sub

    Private Function FindTalla(ByVal strTalla As String) As Boolean

        Dim iCol As Integer
        Dim campoTalla As String

        'QUITAR DESPUES
        Return True

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
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 11.11.2014: La utilizamos para saber si ya revisamos el precio desde SAP cuando se realiza la descarga para que no se quede 
        'ciclado cuando no esta alimentado el precio en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim bPrimera As Boolean = True

Inicio:
        oArticulo.ClearFields()
        'Obtenemos Existencia
        If oRow >= 0 Then


            If IsDBNull(dsDetalle.Tables(0).Rows(oRow)) = False Then
                If CStr(dsDetalle.Tables(0).Rows(oRow)!Codigo).Trim() = "" Then
                    CodPadreArticulo = oArticuloMgr.ValidaCodigoProveedor(grdDetalle(oRow, 0))
                    oFacturaMgr.GetExistenciaCodProveedor(CodPadreArticulo, oFactura.CodAlmacen, grdDetalle(oRow, 1), oFactura, oArticulo)
                    'oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(e.OldRange.r1, e.OldRange.c1), oFactura, oArticulo.CodElectronico)
                    dsDetalle.Tables(0).Rows(oRow)!Codigo = oArticulo.CodArticulo
                Else
                    oArticuloMgr.LoadInto(CStr(dsDetalle.Tables(0).Rows(oRow)!Codigo).Trim(), oArticulo)
                End If

                'dsDetalle.Tables(0).AcceptChanges()
                'oArticuloMgr.LoadInto(grdDetalle(oRow, 0), oArticulo)

                oFactura.FacturaArticuloExistencia = 0

                '--oArticulo.Descuento = oArticulo.Descuento / 100

                FillTallasArticulo(oArticulo.CodCorrida)

                '--Obtenemos Tallas del Art�culo
                oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

                '--Obtenemos Existencia
                oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(oRow, 1), oFactura, oArticulo.CodElectronico)

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
                '--------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 09/05/2013: Si esta activada la config, se revisa si el articulo no tiene el precio se realiza la descarga de precios y
                'y descuentos en automatico 
                ''--------------------------------------------------------------------------------------------------------------------------------------
                'If oConfigCierreFI.BorrarPreciosCierre AndAlso Me.ebPrecioArticulo.Value = 0 Then
                '    If bPrimera = True Then
                '        Dim oFrmDescargaPrecio As New frmDescargasXCodigo
                '        With oFrmDescargaPrecio
                '            .MostrarMensajes = False
                '            .ebArticuloID.Text = CStr(grdDetalle(oRow, 0)).Trim
                '            .btnAgregar.PerformClick()
                '            .rbDescuentos.Checked = True
                '            .btnDescargar.PerformClick()
                '        End With
                '        bPrimera = False
                '        GoTo Inicio
                '    Else
                '        MessageBox.Show("Para el art�culo " & Me.ebCodigoArticulo.Text.Trim & " no hay precio alimentado en SAP." & vbCrLf & "Favor de llamar a Soporte Tecnico.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        GoTo Final
                '    End If
                'End If

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
Final:
                'ALLOW
                'Me.grdDetalle.Select(grdDetalle.Row, 1)
                Me.grdDetalle.Cols(0).AllowEditing = False
            End If
        End If
    End Sub

    Private Sub ActualizaDatosArticuloProveedor(ByVal oRow As Integer, ByVal oCol As Integer)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 11.11.2014: La utilizamos para saber si ya revisamos el precio desde SAP cuando se realiza la descarga para que no se quede 
        'ciclado cuando no esta alimentado el precio en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim bPrimera As Boolean = True


        'dsDetalle.Tables(0).AcceptChanges()
        'oArticuloMgr.LoadInto(grdDetalle(oRow, 0), oArticulo)

        oFactura.FacturaArticuloExistencia = 0

        '--oArticulo.Descuento = oArticulo.Descuento / 100

        FillTallasArticulo(oArticulo.CodCorrida)

        '--Obtenemos Tallas del Art�culo
        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)

        '--Obtenemos Existencia
        oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, grdDetalle(oRow, 1), oFactura, oArticulo.CodElectronico)

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

                '-----------------------------------------------------------------------
                ' JNAVA (30.09.2015): Si es de DPCard Puntos, no se agrega el pago
                '-----------------------------------------------------------------------
                If oRow!CodFormasPago <> "DPPT" Then

                    dtResult.ImportRow(oRow)

                End If

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
        Dim oArtTemp As Articulo

        For Each oRow As DataRow In dsDetTemp.Tables(0).Rows

            '------------------------------------------------------------------------
            'JNAVA (04.12.2014): Solo agregamos los codigos que no son electronicos
            '------------------------------------------------------------------------
            If CStr(oRow!Codigo).Trim <> "" Then
                oArtTemp = oArticuloMgr.Create
                oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArtTemp)
            Else
                GoTo Continuar
            End If

            If oArtTemp.CodElectronico = 0 Then 'No es Electronico
Continuar:
                For i As Integer = 1 To oRow!Cantidad
                    oNewRow = dsDetDesAgrup.Tables(0).NewRow
                    With oNewRow
                        !Codigo = oRow!Codigo
                        !Talla = oRow!Talla
                        !Cantidad = 1
                        !Importe = oRow!Importe
                        !Total = oRow!Importe
                        !Descuento = oRow!Descuento / oRow!Cantidad
                        If EsCatalogo(oRow!Codigo) = True Then 'Mid(CStr(oRow!Codigo), 1, 6) = "DT-CAT" Then
                            !Adicional = oRow!Adicional
                        Else
                            !Adicional = 0
                        End If
                        !Checado = oRow!Checado
                        !UsadoPromo = oRow!UsadoPromo
                    End With
                    dsDetDesAgrup.Tables(0).Rows.Add(oNewRow)
                Next

            End If

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
            'JNAVA (04.12.2014): Obtenemos el index del articulo para actualizarle las promociones
            '----------------------------------------------------------------------------------------
            i = BuscarCodigoEnDetalle(oRow!Codigo, oRow!Talla, dsDetalle.Tables(0))

            'grdDetalle(i, 6) = oRow!Adicional
            dsDetalle.Tables(0).Rows(i)!Adicional = oRow!Adicional
            dsDetalle.Tables(0).Rows(i)!Condicion = oRow!Condicion
            'i += 1

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
            'JNAVA 04.12.2014: Venta de Electronicos
            '----------------------------------------------------------------------------------------------------------
            'If oConfigCierreFI.VentasElectronicos Then
            'Revisamos los articulos para saber si hay electronicos o no
            Dim dtElectronicos As DataTable
            dtElectronicos = GetVentaElectronicos(dsDetalle.Tables(0).Copy)
            'Si hay electronicos mostramos pantalla de captura
            If Not dtElectronicos Is Nothing AndAlso dtElectronicos.Rows.Count > 0 Then
                If CapturaDatosElectronicos(dtElectronicos) Then
                    'Se si capturaron datos (continuar), pasamos la tabla de electronicos a la forma de pago
                    frmPagoCliente.dtElectronicos = dtElectronicos
                Else
                    'Si no se capturaron (se cancelo), no abrimos las formas de pago
                    Exit Sub
                End If
            End If
            'End If

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
            '---------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 08/05/2013: Se hace la validaci�n para agregar las cantidades libres que ya fueron restadas de los pedidos pendientes'
            '---------------------------------------------------------------------------------------------------------------------------------
            If Not Me.dtCantidadLibre Is Nothing Then
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
12:         If oConfigCierreFI.UsarHuellas AndAlso oFactura.CodTipoVenta = "P" Then
13:             oFactura.ClientPGID = oFactura.ClienteId
14:             oFactura.ClienteId = 10000000
            End If
            '----------------------------------------------------------------------------------------------------------
            'Si el cronometro esta corriendo, lo seguimos mostrando en la pantalla de formas pago
            '----------------------------------------------------------------------------------------------------------
15:         If Me.timer1.Enabled = True Then
16:             frmPagoCliente.bCronometro = True
17:             frmPagoCliente.strCrono = Me.lblCronometro.Text
            End If
            '----------------------------------------------------------------------------------------------------------
            'Si debe filtrar las formas de pago por las promociones aplicadas enviamos las formas de pago permitidas
            '----------------------------------------------------------------------------------------------------------
            If Not dtDescFormasPago Is Nothing AndAlso dtDescFormasPago.Rows.Count > 0 Then frmPagoCliente.dtDescFormasPago = dtDescFormasPago.Copy
            '----------------------------------------------------------------------------------------------------------
            'RGERMAIN 17.05.2014: Le pasamos el ID de la venta DPVale y si es un reintento de guardado de la venta DPVL
            '----------------------------------------------------------------------------------------------------------
            frmPagoCliente.DPValeVentaID = Me.DPValeVentaID
            frmPagoCliente.bReintentoDPVL = Me.bReintentoDPVL
            '----------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Le pasamos los datos del cliente si esta activada la config
            '----------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PedirDatosPromoComienzo Then frmPagoCliente.strDatosPromoClientes = strDatosPromoClientes.Trim
            '----------------------------------------------------------------------------------------------------------
            'rgermain 03.03.2016: Actualizamos el folio de factura dppro por si se queda la pantalla abierta y se abrio otra instancia desde el
            '                     modulo de notas de credito
            '----------------------------------------------------------------------------------------------------------
            LoadFolioFactura()
            '----------------------------------------------------------------------------------------------------------
            'Mostramos pantalla de formas de pago
            '----------------------------------------------------------------------------------------------------------
18:         frmPagoCliente.ShowDialog(oFactura, CodTipoDescuento, vNCInstance, oDevolucionDPvale, vApartadoInstance, _
                                    oValeDescuentoLocalInfo, strCondicionVenta, strListaPrecios)

19:         Me.FormasPago = frmPagoCliente.dtFormasPago.Copy

            Me.bReintentoDPVL = frmPagoCliente.bReintentoDPVL

            If oConfigCierreFI.PedirDatosPromoComienzo Then strDatosPromoClientes = frmPagoCliente.strDatosPromoClientes.Trim

20:         If frmPagoCliente.DialogResult = DialogResult.OK Then

21:             FacturaGuardada = True
22:             If vNCInstance Or vApartadoInstance Then

23:                 If vNCInstance Then
24:                     vNCFacturada = True
25:                     '  Me.Close()
                    End If
                    Me.Close()

26:                 frmPagoCliente.Dispose()
27:                 frmPagoCliente = Nothing
                    Exit Sub
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
                        Exit Sub
39:                     NuevaFactura()

40:                     ebTipoVenta.Focus()

                    End If


                Else

41:                 frmPagoCliente.Dispose()
42:                 frmPagoCliente = Nothing
                    '-----------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 21/02/2018: Se cierra la pantalla de facturaci�n
                    '-----------------------------------------------------------------------------------------------------------
                    Me.Dispose()
                    Exit Sub
                    If bolNC = True Then
                        Me.DialogResult = DialogResult.OK
                        Exit Sub
                    End If

44:                 NuevaFactura()

                    If (bolCloseForm = True) Then
                        Exit Sub
                    End If

45:                 LoadFolioFactura()

46:                 oFactura.CodTipoVenta = "P"
                    oFactura.ClienteId = 10000000
47:                 'oFactura.ClienteId = IIf(oConfigCierreFI.UsarHuellas = True, 0, 10000000)

                    ebTipoVenta.Focus()

                End If

            Else

48:             FacturaGuardada = False
49:             frmPagoCliente.Dispose()
50:             frmPagoCliente = Nothing
                '----------------------------------------------------------------------------------------------------------
                'Regresamos el id del cliente PG
                '----------------------------------------------------------------------------------------------------------
                'If oConfigCierreFI.UsarHuellas AndAlso oFactura.CodTipoVenta = "P" Then oFactura.ClienteId = oFactura.ClientPGID
                Exit Sub
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al abrir la formas de pago: Linea " & Err.Erl)
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
        'Captura Manual
        'ALLOW
        Me.grdDetalle.Cols(0).AllowEditing = False
        ''
        boolManual = False

        oFactura.ClearFields()
        oFactura.ClienteId = 10000000
        ebClienteID.Enabled = False
        Me.btnAltaCliente.Enabled = False
        Me.ebClienteDescripcion.Text = "P�BLICO GENERAL"
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
        Me.grdDetalle.Cols(0).AllowEditing = False
        ebTallaDel.Value = 0
        ebTallaAl.Value = 0
        ebExistencias.Value = 0
        ebFolioApartado.Value = 0
        Me.txtFolioVentaManual.Text = ""
        Me.chkVentaManual.Checked = False
        Me.chkPromoEspecial.Checked = False
        'Me.boolDescuentoDPakete = False 

        ebIVA.Visible = True
        ebSubTotal.Visible = True
        EbFolioSAP.Visible = False

        Me.ebClienteDescripcion.Text = "P�BLICO GENERAL"
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
        'Reseteamos el cron�metro
        '----------------------------------------------------------------------------------------------------------------------
        If Me.timer1.Enabled = True Then EjecutarCronometro(False)

        If Not dtDescFormasPago Is Nothing Then dtDescFormasPago.Clear()
        If Not dtPromoAplicada Is Nothing Then dtPromoAplicada.Clear()
        bRechazoPromo = False
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
        '--------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 17.05.2014: Se arma un id para las ventas DPVale para identificarla en caso de reintento
        '--------------------------------------------------------------------------------------------------------------------------------------
        'Me.DPValeVentaID = CentroSAP & oFactura.CodCaja & Format(oSAPMgr.MSS_GET_SY_DATE_TIME, "ddMMyyyyhhmmss")
        Me.DPValeVentaID = CentroSAP & oFactura.CodCaja & Format(Date.Now, "ddMMyyyyhhmmss")
        bReintentoDPVL = False
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.08.2014: Pedimos capturar el celular y el email del cliente si esta activada la configuracion
        '----------------------------------------------------------------------------------------------------------------------------------------
        strDatosPromoClientes = ""
        If oConfigCierreFI.PedirDatosPromoComienzo Then CapturaCelParaSMS()
        '----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 28.02.2015: Se limpian los datatables de las promociones aplicadas en el Cross Selling
        '----------------------------------------------------------------------------------------------------------------------------------------
        If Not Me.dtPromosCS Is Nothing Then Me.dtPromosCS.Clear()
        If Not Me.dtPromosCSVig Is Nothing Then Me.dtPromosCSVig.Clear()
        If Not Me.dtCS Is Nothing Then dtCS.Clear()
        Me.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
        oFactura.SerialId = Me.SerialId

    End Sub

    Private Function LoadFolioFactura()

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

    End Function

    Private Function LoadSearchArticulo() As String

        Dim cArticulo As String
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If oOpenRecordDlg.pbCodigo = String.Empty Then
                cArticulo = oOpenRecordDlg.Record.Item("CodArtProv")
                Me.CodArticulo = CStr(oOpenRecordDlg.Record.Item("C�digo"))
                '------------------------------------------------------------------------------------------
                ' JNAVA (17.12.2015): Comentado para adaptacion de nuevos codigos en SAP RETAIL
                '------------------------------------------------------------------------------------------
                'str = str & cArticulo
                'str = Mid(str, str.Length - 13)
            Else
                cArticulo = oOpenRecordDlg.Record.Item("CodArtProv")
                Me.CodArticulo = CStr(oOpenRecordDlg.Record.Item("C�digo"))
                '------------------------------------------------------------------------------------------
                ' JNAVA (17.12.2015): Comentado para adaptacion de nuevos codigos en SAP RETAIL
                '------------------------------------------------------------------------------------------
                'str = str & cArticulo
                'str = Mid(str, str.Length - 13)
            End If

            '------------------------------------------------------------------------------------------
            ' JNAVA (17.12.2015): Adecuacion para nuevos codigos de articulos en SAP RETAIL
            '------------------------------------------------------------------------------------------
            'Dim iLength As Integer = 13 'Se deja 13 por codigos originales (Puede cambiar)
            'If cArticulo.Length <= 10 Then
            '    iLength = 9
            'End If

            'str = str & cArticulo
            'str = Mid(str, str.Length - iLength)
            '------------------------------------------------------------------------------------------

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
        '-------------------------------------------------------------
        ' JNAVA (02.03.2016): Se quita columna de talla
        '-------------------------------------------------------------
        grdDetalle.Cols(3).Width = 57
        grdDetalle.Cols(3).Format = "##0.0"
        grdDetalle.Cols(3).Visible = False
        '-------------------------------------------------------------
        grdDetalle.Cols(4).Width = 57
        grdDetalle.Cols(4).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
        grdDetalle.Cols(5).Width = 63
        grdDetalle.Cols(5).Format = "##0"
        grdDetalle.Cols(6).Width = 80
        grdDetalle.Cols(6).Format = "$ ###,##0.00"
        grdDetalle.Cols(6).AllowEditing = False
        grdDetalle.Cols(7).Visible = False
        '''grdDetalle.Cols(6).Width = 80
        '''grdDetalle.Cols(6).Format = "$ ###,##0.00"
        grdDetalle.Cols(7).AllowEditing = False
        grdDetalle.Cols(8).Format = "$ ###,##0.00"
        grdDetalle.Cols(8).Width = 80
        grdDetalle.Cols(9).Format = "##0.00"
        grdDetalle.Cols(9).Width = 80
        grdDetalle.Cols(10).Width = 80
        grdDetalle.Cols(10).Format = "##0.00"
        grdDetalle.Cols(10).AllowEditing = False

        '------------------------------------------------------------
        'JNAVA (22.12.2014): Quitamos la columans de Electronicos
        '------------------------------------------------------------
        grdDetalle.Cols(11).Visible = False
        grdDetalle.Cols(12).Visible = False

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

    Private Sub ActualizaCalculos()

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

                    '-----------------------------------------------------------------------------------
                    ' Descuento Adicional
                    '-----------------------------------------------------------------------------------
                    vSaldarDescuentoAdicional += oRow("Adicional")
                    'Calculamos el descuento adicional que le corresponde a cada pieza del producto
                    vDsctoAdiUnit = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdiUnit = vDsctoAdiUnit / oRow("Cantidad") ' Truncar(vDsctoAdiUnit, 2) / oRow("Cantidad")
                    'vDsctoAdiUnit = vDsctoAdiUnit / oRow("Cantidad")

                    '-----------------------------------------------------------------------------------
                    ' JNAVA (22.07.2015): Obtenemos el descuento adicional total ya que se ponia 
                    '                     el descuento adicional unitario
                    '-----------------------------------------------------------------------------------
                    'Calculamos el descuento adicional total del producto}
                    'vDsctoAdicional += vDsctoAdiUnit
                    'vDsctoAdicional += (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    Dim vDsctoAdicionalTotal As Decimal = Decimal.Zero
                    vDsctoAdicionalTotal = (oRow("Total") - oRow("Descuento")) * (oRow("Adicional") / 100)
                    vDsctoAdicional += vDsctoAdicionalTotal
                    'vDsctoAdicional += Truncar(vDsctoAdicionalTotal, 2)
                    'vDsctoAdicional += vDsctoAdicionalTotal

                    '-----------------------------------------------------------------------------------
                    ' Importe
                    '-----------------------------------------------------------------------------------
                    'Calculamos el importe unitario de cada pieza del producto restando los descuentos
                    vImporte = oRow("Importe") - vDsctoUnit - vDsctoAdiUnit
                    'Le aumentamos el iva al precio unitario
                    vImporte = Decimal.Round(vImporte * (1 + oAppContext.ApplicationConfiguration.IVA), 2)

                    '-----------------------------------------------------------------------------------
                    ' Total
                    '-----------------------------------------------------------------------------------
                    'Sumamos al importe total de la factura el total de este producto ya con los descuentos restados y el iva aumentado
                    vTotalGeneral = vTotalGeneral + (vImporte * oRow("Cantidad"))

                End If
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
            'If oRow("Codigo") = strCodigo And (nRow - 1) <> nRowG Then
            If oRow("CodProveedor") = strCodigo And oRow("Talla") = strTalla And (nRow - 1) <> nRowG Then

                Return nRow

            End If

        Next

        Return 0

    End Function

    Private Function BuscaCodigoEnVentaProveedor(ByVal strCodigo As String, ByVal nRowG As Integer) As Integer

        Dim oRow As DataRow
        Dim nRow As Integer = 0

        For Each oRow In dsDetalle.Tables(0).Rows

            nRow = nRow + 1
            If oRow("Codigo") = strCodigo And (nRow - 1) <> nRowG Then
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
        Dim CdpVale As New cDPVale()
        If IsNumeric(DPValeID.Trim()) Then
            CdpVale.INUMVA = DPValeID.PadLeft(10, "0")
        Else
            CdpVale.INUMVA = DPValeID.Trim()
        End If
        CdpVale.I_RUTA = "X"
        oS2Credit = New ProcesosS2Credit()
        CdpVale = oS2Credit.ValidaDPVale(CdpVale, Nothing, Nothing)
        oDevolucionDPvale.Status = ValidaEstatusVale(CdpVale)
        oDevolucionDPvale.Codct = CStr(CdpVale.InfoDPVALE.Rows(0)!CODCT)
        Me.ShowDialog()

    End Function

    Private Sub LoadDataofNotaCredito()

        uICommandManager1.CommandBars(0).Enabled = False
        uICommandManager1.CommandBars(1).Enabled = False

        'como el TipoVta es Dpvale el Cliente es Pub. Gral.
        oFactura.ClienteId = 10000000
        ebClienteDescripcion.Text = "P�BLICO GENERAL"
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
        If oContratoInfo.ClienteID = 10000000 Then

            ebClienteDescripcion.Text = "P�BLICO GENERAL"

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
                .Item("CodProveedor") = oRowContrato("CodArtProv")
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
        grdDetalle.Enabled = False
        oFactura.DescTotal = oContratoInfo.DescuentoTotal
        oFactura.Total = oContratoInfo.ImporteTotal
        oFactura.IVA = oContratoInfo.IVA
        oFactura.SubTotal = oFactura.Total - oFactura.IVA
        Me.nebTotalPiezas.Value = IIf(IsDBNull(dsDetalle.Tables(0).Compute("SUM(Cantidad)", "")), 0, dsDetalle.Tables(0).Compute("SUM(Cantidad)", ""))

        oFactura.ApartadoID = oContratoInfo.ID
        ebFolioApartado.Value = oContratoInfo.FolioApartado
        oFactura.Referencia = oContratoInfo.Referencia

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
                Dim FirmaDistribuidor As Image
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
                Dim DpvaleInfo As New DevolucionDPValeInfo()
                DpvaleInfo.DPValeOrigen = oRow("Orige")
                DpvaleInfo.FechaExpedicion = Now
                DpvaleInfo.FechaEntregado = Now
                DpvaleInfo.FacturaId = 0
                DpvaleInfo.MontoDPValeUtilizado = 0
                DpvaleInfo.MontoDPValeP = 0
                DpvaleInfo.DPValeID = Me.oDevolucionDPvale.DPValeID
                DpvaleInfo.AsociadoID = oRow("KUNNR")
                DpvaleInfo.ClienteAsociadoID = oRow("CODCT")

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

                ofrmPago.PrintRevale(DpvaleInfo, NombreDistribuidor, FirmaDistribuidor)
                ofrmPago.Dispose()
                ofrmPago = Nothing

            End If

        ElseIf FacturaGuardada = False AndAlso Not Me.FormasPago Is Nothing Then

            For Each oRow As DataRow In Me.FormasPago.Rows

                If oRow!CodTipoTarjeta = "TE" Then

                    MsgBox("Es necesario guardar la factura", MsgBoxStyle.Exclamation, "Dportenis Pro")
                    e.Cancel = True
                    Exit For

                End If

            Next

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
            If MessageBox.Show("�Deseas dar de alta al cliente en este momento?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                AltadeCliente()
            Else
                Me.ebClienteID.Focus()
            End If
        End If
    End Sub

    Private Sub ebClienteID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.LostFocus

        'If oConfigCierreFI.UsarHuellas = True AndAlso Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.True Then

        '    Me.uICommandManager1.CommandBars(1).Commands("menuBuscarHuella").Enabled = Janus.Windows.UI.InheritableBoolean.False

        'End If

    End Sub

    Private Sub grdDetalle_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdDetalle.AfterEdit

        Me.grdDetalle.Cols(6).AllowEditing = False

    End Sub

    Private Sub btnPromosAplicadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPromosAplicadas.Click

        If Not Me.dtPromosCS Is Nothing AndAlso Me.dtPromosCS.Rows.Count > 0 Then
            Dim oFrmPromosCS As New frmPromosAplicadasCS("PA", dtPromosCS, dtPromosCSVig, dtCS)

            oFrmPromosCS.ShowDialog()
        End If

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

        If Me.chkPromoEspecial.Checked = False Then
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Aplicamos las promociones vigentes
            '-------------------------------------------------------------------------------------------------------------------------------------
            AplicarPromociones()
            'AplicaPromocionesVigentes()
        End If

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

#Region "Metodos Filtros Descuentos"

    Public Sub InsertarCodigo(ByVal codigo As String)
        Dim dRow As DataRow
        Dim ActualRow As Integer
        ActualRow = dsDetalle.Tables(0).Rows.Count
        dRow = dsDetalle.Tables(0).Rows(0)
        dRow("Codigo") = codigo
        dsDetalle.AcceptChanges()

        ActualizaCalculos()

        ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
        'ALLOW
        Me.grdDetalle.Cols(0).AllowEditing = False
        boolManual = False

        grdDetalle.Refresh()

        'grdDetalle.Select(ActualRow, 0)
    End Sub
#End Region

#Region "Venta de Electronicos"

    Private Function GetVentaElectronicos(ByVal dtDetalle As DataTable) As DataTable

        Dim dtElectronicos As DataTable
        Dim oArtTemp As Articulo

        'Creamos Tabla para electronicos
        dtElectronicos = SetTablaElectronicos()
        dtElectronicos.AcceptChanges()

        'obtenemos los articulos que son electronicos
        For Each oRow As DataRow In dtDetalle.Rows

            oArtTemp = oArticuloMgr.Create
            oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArtTemp)

            'Revisamos que sea o no electronico en base al CodElectronico
            If oArtTemp.CodElectronico <> 0 Then

                'En base a la cantidad de piezas por articulos...
                For cantidad As Integer = 1 To CInt(oRow!Cantidad)

                    '...llenamos la tabla con los articulos que son electronicos
                    Dim oRowE As DataRow = dtElectronicos.NewRow()
                    oRowE("MATERIAL") = oArtTemp.CodArticulo
                    oRowE("DESCRIPCION") = oArtTemp.Descripcion
                    oRowE("NUMSERIE") = ""
                    oRowE("IMEI") = ""
                    oRowE("FACTURA") = ""
                    oRowE("DPVALE") = ""
                    oRowE("FORMAPAGO") = ""
                    oRowE("NUMDENOMINACION") = oArtTemp.CodElectronico
                    dtElectronicos.Rows.Add(oRowE)
                Next

            End If

        Next

        dtElectronicos.AcceptChanges()

        Return dtElectronicos

    End Function

    Private Function SetTablaElectronicos() As DataTable

        Dim dtElectronicos As New DataTable
        dtElectronicos.Columns.Add("MATERIAL")
        dtElectronicos.Columns.Add("DESCRIPCION")
        dtElectronicos.Columns.Add("NUMSERIE")
        dtElectronicos.Columns.Add("IMEI")
        dtElectronicos.Columns.Add("FACTURA")
        dtElectronicos.Columns.Add("DPVALE")
        dtElectronicos.Columns.Add("FORMAPAGO")
        dtElectronicos.Columns.Add("NUMDENOMINACION")

        dtElectronicos.AcceptChanges()

        Return dtElectronicos

    End Function

    Private Function CapturaDatosElectronicos(ByRef dtElectronicos As DataTable) As Boolean

        Dim bResp As Boolean = False

        Try
            Dim ofrmElectronicos As New frmCapturaVentaElectronicos
            ofrmElectronicos.dtElectronicos = dtElectronicos.Copy
            ofrmElectronicos.ShowDialog()

            'Asignamos valores de la tabla devuelta
            dtElectronicos = ofrmElectronicos.dtElectronicos

            'Obtenemos resultados
            bResp = ofrmElectronicos.bContinuar

            'Destruimos el objeto del formulario
            ofrmElectronicos.Dispose()

        Catch ex As Exception

            Throw ex

        End Try

        Return bResp

    End Function

    Private Sub CalculoVentaElectronicos()

        Try

            Dim oArtTemp As Articulo
            Dim DescAdicional As Decimal = Decimal.Zero

            'Obtenemos los articulos que son electronicos
            For Each oRow As DataRow In dsDetalle.Tables(0).Rows
                If oRow.RowState <> DataRowState.Deleted Then
                    If CStr(oRow!Codigo).Trim <> "" Then
                        oArtTemp = oArticuloMgr.Create
                        oArticuloMgr.LoadInto(CStr(oRow!Codigo).Trim, oArtTemp)
                    Else
                        Exit Sub
                    End If

                    'Revisamos que sea o no electronico en base al CodElectronico
                    If oArtTemp.CodElectronico <> 0 Then

                        'Validamos que la venta no sea DPVale para obtener el descuento para Efectivo)
                        If oFactura.CodTipoVenta <> "V" Then
                            'Calculamos porcentaje de descuento adicional para pagos en efectivo
                            DescAdicional = 100 - ((oArtTemp.CostoProm * 100) / oArtTemp.PrecioVenta)
                            oRow!Adicional = DescAdicional

                            'Ponemos ZDP4 en la columna Condicion para el descuento a aplicar
                            oRow!Condicion = "ZDP4"
                        Else
                            oRow!Adicional = 0
                            oRow!Condicion = ""
                        End If

                    End If
                End If
            Next

            dsDetalle.Tables(0).AcceptChanges()

        Catch ex As Exception

            Throw ex

        End Try


    End Sub


#End Region

#Region "Seguros de Vida DPVale"

    Private Sub PrepararReimpresionSeguroDPVale(ByRef oPago As frmPago)


        If oConfigCierreFI.GenerarSeguro Then 'Revisamos config
            If oFactura.CodTipoVenta = "V" Then 'Revisamos Tipo de venta
                Dim oDPVale As New cDPVale
                Dim DPValeID As Integer
                Dim dtSeguro As DataTable
                Dim FechaCobro As Date
                Dim Quincenas As String
                Dim ClienteDPVale As String
                Dim strFecha As String

                '---------------------------------------------------
                ' Obtenemos el DPValeID de la Factura
                '---------------------------------------------------
                DPValeID = oFacturaMgr.GetDPVALEID(oFactura.FacturaID)

                '---------------------------------------------------
                ' Validamos el DPValeID obtenido de la Factura
                '---------------------------------------------------
                If DPValeID > 0 Then

                    '---------------------------------------------------
                    ' Obtenemos el DPValeID de la Factura
                    '---------------------------------------------------
                    dtSeguro = oFacturaMgr.GetSeguroDPValeByDPValeID(CStr(DPValeID).TrimEnd.PadLeft(10, "0"))

                    '---------------------------------------------------
                    ' Validamos que existan registros en los Seguros de Calzado
                    '---------------------------------------------------
                    If Not dtSeguro Is Nothing AndAlso dtSeguro.Rows.Count > 0 Then

                        '--------------------------------------------------------------------------
                        ' Validamos DPVale en SAP para sacar el Cliente, Quincenas Fecha de cobro
                        '--------------------------------------------------------------------------
                        oDPVale.I_RUTA = "X"
                        oDPVale.INUMVA = DPValeID.ToString.Trim.PadLeft(10, "0")
                        oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)


                        If oDPVale.InfoDPVALE.Rows.Count > 0 Then

                            '--------------------------------------------------------------------------
                            ' Obtenemos Detalle del DPVale
                            '--------------------------------------------------------------------------
                            ClienteDPVale = oDPVale.InfoDPVALE.Rows(0)!CODCT
                            Quincenas = oDPVale.InfoDPVALE.Rows(0)!NUMDE
                            strFecha = oDPVale.InfoDPVALE.Rows(0)!FECCO
                            If strFecha = String.Empty Then
                                FechaCobro = Date.Today
                            Else
                                strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                                FechaCobro = CDate(strFecha)
                            End If
                            'If strFecha.Trim <> "" AndAlso CLng(strFecha.Trim) > 0 Then
                            '    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                            '    FechaCobro = CDate(strFecha)
                            'Else
                            '    FechaCobro = Today
                            'End If
                            

                            '---------------------------------------------------------------
                            'Obtenemos Beneficiarios
                            '---------------------------------------------------------------
                            oPago.Beneficiarios = dtSeguro.Rows(0).Item("Beneficiario")

                            '---------------------------------------------------
                            ' JNAVA (12.02.2015): Obtenemos los datos del Financiamiento
                            '---------------------------------------------------
                            oPago.DatosTicketSeguro.Clear()
                            oPago.DatosTicketSeguro = oPago.PrepararDatosTicket(ClienteDPVale, Quincenas, FechaCobro, "V")
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

#Region "S2Credit"

    Private Sub PrepararReimpresionSeguroS2Credit(ByRef oPago As frmPago)

        If oConfigCierreFI.GenerarSeguro Then 'Revisamos config

            If oFactura.CodTipoVenta = "V" Then 'Revisamos Tipo de venta

                Dim oS2Credit As New ProcesosS2Credit
                Dim SeguroID As String = "1" 'Por Default 1

                Dim oDPVale As New cDPVale
                Dim DPValeID As String
                Dim Beneficiario As String = String.Empty
                Dim FechaCobro As Date
                Dim Quincenas As String
                Dim ClienteDPVale As String
                'Dim strFecha As String

                '---------------------------------------------------
                ' Obtenemos el DPValeID de la Factura
                '---------------------------------------------------

                If oFactura.PedidoID <> 0 Then
                    DPValeID = oFacturaMgr.GetDPVALEID(0, oFactura.PedidoID)
                Else
                    DPValeID = oFacturaMgr.GetDPVALEID(oFactura.FacturaID)
                End If



                '---------------------------------------------------
                ' Validamos el DPValeID obtenido de la Factura
                '---------------------------------------------------
                If DPValeID.Trim() <> "" Then

                    '---------------------------------------------------
                    ' Obtenemos los datos del seguro
                    '---------------------------------------------------
                    If IsNumeric(DPValeID.Trim()) Then
                        DPValeID = DPValeID.Trim().PadLeft(10, "0")
                    End If

                    Beneficiario = oS2Credit.ObtenerBeneficiarioSeguro(DPValeID.Trim(), FechaCobro)

                    oDPVale.INUMVA = DPValeID
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
                    oDPValeSAP = GetObjectDPValeSAP(oDPVale)

                    '---------------------------------------------------
                    ' Validamos que haya beneficiario en los Seguros de Calzado
                    '---------------------------------------------------
                    If Beneficiario.Trim <> String.Empty Then

                        '----------------------------------------------------------------------------------------
                        ' Valida DPVale en S2Credit 
                        '----------------------------------------------------------------------------------------

                        If oDPVale.InfoDPVALE.Rows.Count > 0 Then

                            '--------------------------------------------------------------------------
                            ' Obtenemos Detalle del DPVale
                            '--------------------------------------------------------------------------
                            ClienteDPVale = oDPVale.InfoDPVALE.Rows(0)!CODCT
                            Quincenas = oDPVale.InfoDPVALE.Rows(0)!NUMDE

                            '----------------------------------------------------------------------------------------
                            ' JNAVA (07.11.2016): Se obtiene la fecha de cobro al obtener al beneficiario
                            '----------------------------------------------------------------------------------------
                            'strFecha = oDPVale.InfoDPVALE.Rows(0)!FECCO
                            'If strFecha = String.Empty Then
                            '    FechaCobro = Date.Today
                            'Else
                            '    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                            '    FechaCobro = CDate(strFecha)
                            'End If
                            '----------------------------------------------------------------------------------------

                            '---------------------------------------------------------------
                            ' Obtenemos Beneficiarios
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
                            ' Obtenemos los datos del Financiamiento
                            '---------------------------------------------------
                            oPago.DatosTicketSeguro.Clear()
                            oPago.Beneficiarios = Beneficiario
                            oPago.DatosTicketSeguro = oPago.PrepararDatosTicketS2Credit(ClienteDPVale, Quincenas, FechaCobro, "V", oDatosAseguradora)
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

#Region "DP CARD"

    Private Sub ReimprimirVoucherDPCA(ByVal dtFormasPago As DataTable)

        Dim oOP As New OtrosPagos
        Dim htDatos As New Hashtable

        Try

            For Each oRow As DataRow In dtFormasPago.Rows

                If oRow!CodFormasPago = "DPCA" Then

                    htDatos("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                    htDatos("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                    htDatos("Vendedor") = oAppContext.Security.CurrentUser.Name
                    htDatos("Tarjeta") = oRow!NumeroTarjeta
                    htDatos("TarjetaHabiente") = ""
                    htDatos("Monto") = oRow!MontoPago
                    htDatos("Linea") = "DIGITADA"
                    htDatos("ConsecutivoPOS") = oRow!DPValeID

                    '------------------------------------------------------
                    ' JNAVA 24.06.2015: imprimimor la promocion
                    '------------------------------------------------------
                    Select Case CStr(oRow!Id_Num_promo)
                        Case "00"
                            htDatos("Promocion") = ""
                        Case "30"
                            htDatos("Promocion") = "3 Meses sin intereses"
                        Case "40"
                            htDatos("Promocion") = "6 Meses sin intereses"
                        Case "50"
                            htDatos("Promocion") = "9 Meses sin intereses"
                    End Select

                    oOP.ImprimirVoucherDPCard(htDatos, "VTA", False, False)
                    oOP.ImprimirVoucherDPCard(htDatos, "VTA", True, False)

                End If

            Next
        Catch ex As Exception

            Throw ex

        End Try

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

#Region "SAP RETAIL"

    Private Function ConvertirACupon(ByVal Folio As String, ByVal dCupon As Dictionary(Of String, Object), ByRef strErrorMsg As String) As CuponDescuento
        Dim oCuponResp As New CuponDescuento
        Dim strResult As String = ""
        Dim FechaVig As String = ""
        strResult = dCupon("SapZcupInfoCupon")("E_RESULTADO")
        If CInt(strResult) = 1 Then
            oCuponResp = New CuponDescuento
            With oCuponResp
                .Folio = IIf(IsNumeric(Folio.Trim), Folio.Trim.PadLeft(10, "0"), Folio.Trim.ToUpper)
                .Descripcion = dCupon("SapZcupInfoCupon")("E_DESCRIPCION")
                .TipoDescuento = dCupon("SapZcupInfoCupon")("E_TIPO_DESCTO")
                .Descuento = dCupon("SapZcupInfoCupon")("E_DESCUENTO")
                .Minimo = dCupon("SapZcupInfoCupon")("E_MINIMO")
                .Maximo = dCupon("SapZcupInfoCupon")("E_MAXIMO")
                .LimiteDescuento = dCupon("SapZcupInfoCupon")("E_LIMITE_DESCTO")
                FechaVig = dCupon("SapZcupInfoCupon")("E_FECHA_FIN")
                .FechaVigencia = CDate(FechaVig.Substring(8, 2) & "/" & FechaVig.Substring(5, 2) & "/" & FechaVig.Substring(0, 4))
                .FormasPago = CType(dCupon("T_FORMASPAGO"), DataTable)
            End With

            Dim dtZcupones As DataTable = CType(dCupon("E_ZCUPONES"), DataTable)
            oCuponResp.InfoCupon = New Hashtable
            For Each fila As DataRow In dtZcupones.Rows
                For Each Column As DataColumn In dtZcupones.Columns
                    oCuponResp.InfoCupon.Add(Column.ColumnName, fila(Column.ColumnName))
                Next
            Next
            If oCuponResp.InfoCupon.ContainsKey("MODULO") = False Then
                oCuponResp.InfoCupon("MODULO") = ""
            End If
            If oCuponResp.InfoCupon.ContainsKey("CUPON_CHECK") = False Then
                oCuponResp.InfoCupon("CUPON_CHECK") = ""
            End If
            If oCuponResp.InfoCupon.ContainsKey("TIPO_DESCUENTO") = False Then
                oCuponResp.InfoCupon("TIPODESCUENTO") = ""
            End If
            If oCuponResp.InfoCupon.ContainsKey("DESCUENTO") = False Then
                oCuponResp.InfoCupon("DESCUENTO") = ""
            End If
        Else
            strErrorMsg = dCupon("SapZcupInfoCupon")("E_DESCRIPCION").ToString
            oCuponResp = Nothing
        End If

        Return oCuponResp

    End Function

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
        DPValeID = oFacturaMgr.GetDPVALEID(oFactura.FacturaID)
        If DPValeID.Trim() <> "" Then
            If IsNumeric(DPValeID.Trim()) Then
                DPValeID = DPValeID.Trim().PadLeft(10, "0")
            End If
            oDPVale.INUMVA = DPValeID
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)
            If Not oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO Is DBNull.Value Then
                Fecha = CDate(oDPVale.InfoDPVALE.Rows(0)!FECHAPRIMERPAGO)
                Fecha = GetFechaFechaPrimerPago(Fecha)
            Else
                Fecha = GetFechaFechaPrimerPago(Date.Now)
            End If
            
        End If
        Return Fecha
    End Function

    Private Function GetFechaFechaPrimerPago(ByVal Fecha As DateTime) As DateTime
        Dim FechaCobro As DateTime
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

#Region "Correcciones DPPRO"

    Private Sub CargarCodArticulo(ByVal indice As Integer)
        ArtExistencia = oArticuloMgr.GetExistenciaByCodigo(Me.CodArticulo)
        dsDetalle.Tables(0).Rows(indice)!Codigo = Me.CodArticulo
        dsDetalle.Tables(0).AcceptChanges()
        If ArtExistencia.Count > 0 Then
            Color = CStr(ArtExistencia("Color"))
            grdDetalle(indice, 1) = CStr(ArtExistencia("Numero"))
            ActualizaDatosArticulos(Me.CodArticulo, CStr(ArtExistencia("Numero")))
            If oFactura.FacturaArticuloExistencia > 0 Then
                Dim CodeRow As Integer
                CodeRow = BuscaCodigoEnVentaProveedor(oArticulo.CodArticulo, indice)
                If CodeRow > 0 Then
                    ActualizaDatosArticulo(CodeRow - 1, 0)
                    If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                        dsDetalle.Tables(0).Rows(indice)!Codigo = ""
                        grdDetalle(grdDetalle.Row, 0) = ""
                        grdDetalle(grdDetalle.Row, 1) = ""
                        grdDetalle(grdDetalle.Row, 2) = 0
                        MsgBox("No se cuenta con existencia del art�culo con esa talla", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                        grdDetalle.Select(indice, 0)
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
                        LimpiaDatosGrid(indice)
                        grdDetalle.Select(indice, 0)
                    End If
                Else
                    ActualizaDatosArticulos(oArticulo.CodArticulo, CStr(ArtExistencia("Numero")))
                    dsDetalle.Tables(0).Rows(indice)!Codigo = oArticulo.CodArticulo
                    dsDetalle.Tables(0).AcceptChanges()
                    'Obtenemos Numero Inicio y Numero Fin del Art�culo
                    oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
                    If oFactura.FacturaArticuloExistencia = 0 Then
                        dsDetalle.Tables(0).Rows(indice)!Codigo = ""
                        grdDetalle(grdDetalle.Row, 0) = ""
                        grdDetalle(grdDetalle.Row, 1) = ""
                        grdDetalle(grdDetalle.Row, 2) = 0
                        MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                        grdDetalle.Select(indice, 0)
                        grdDetalle.Focus()
                    Else
                        grdDetalle(indice, 2) = 1
                        grdDetalle(indice, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                        grdDetalle(indice, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)
                        '**************Prueba2************************
                        grdDetalle(indice, 4) = Decimal.Round(grdDetalle(indice, 3) * grdDetalle(indice, 2), 2)
                        '/*********************
                        '--Aplicamos Descuento si lo tuviera
                        If ebPorcentajeDscto.Value > 0 Then
                            grdDetalle(indice, 5) = Decimal.Round(grdDetalle(indice, 4) * ebPorcentajeDscto.Value, 2)
                        Else
                            grdDetalle(indice, 5) = Decimal.Round(grdDetalle(indice, 2) * ebMontoDscto.Value, 2)
                        End If
                        grdDetalle.Select(indice, 2)
                    End If
                End If
            Else
                grdDetalle(grdDetalle.Row, 0) = ""
                grdDetalle(grdDetalle.Row, 1) = ""
                grdDetalle(grdDetalle.Row, 2) = 0
                MessageBox.Show("No hay existencias del c�digo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            grdDetalle(grdDetalle.Row, 0) = ""
            grdDetalle(grdDetalle.Row, 1) = ""
            grdDetalle(grdDetalle.Row, 2) = 0
            MessageBox.Show("No hay existencia del c�digo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CalcularCantidad(ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        If RowIndex > grdDetalle.Rows.Count - 1 Then
            Exit Sub
        End If
        If grdDetalle(RowIndex, 2) <= 0 And oFactura.FacturaArticuloExistencia > 0 Then
            MsgBox("Cantidad debe ser mayor a Cero. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
            grdDetalle(grdDetalle.Row, 2) = 1
            grdDetalle.Select(RowIndex, 2)
            grdDetalle.Focus()
            ActualizaDatosArticulo(grdDetalle.Row, 0)
            ActualizaCalculos()
        Else
            If grdDetalle(RowIndex, 2) > oFactura.FacturaArticuloExistencia Then
                MsgBox("Cantidad debe ser menor o igual a la Existencia.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                grdDetalle(grdDetalle.Row, 2) = oFactura.FacturaArticuloExistencia
                grdDetalle.Select(RowIndex, 0)
                ActualizaDatosArticulo(grdDetalle.Row, 0)
                ActualizaCalculos()
            Else
                ActualizaDatosArticulo(RowIndex, 0)
                grdDetalle(RowIndex, 4) = Decimal.Round(grdDetalle(RowIndex, 3) * grdDetalle(RowIndex, 2), 2)

                '/*********************
                '--Aplicamos Descuento si lo tuviera
                If ebPorcentajeDscto.Value > 0 Then
                    grdDetalle(RowIndex, 5) = Decimal.Round(grdDetalle(RowIndex, 4) * ebPorcentajeDscto.Value, 2)
                Else
                    grdDetalle(RowIndex, 5) = Decimal.Round(grdDetalle(RowIndex, 2) * ebMontoDscto.Value, 2)
                End If
                '**************Aplicamos Descuentos Adicionales Segun Las Promociones Vigentes
                'AplicaDescuentosAutomaticos()
                '/**********************************************************

                ActualizaCalculos()
            End If
        End If
    End Sub

    Private Function ActualizaDatosArticulos(ByVal CodArticulo As String, ByVal Talla As String) As Boolean
        Dim valido As Boolean = True
        Dim BrandMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas.CatalogoMarcasManager(oAppContext)
        oArticulo.ClearFields()
        oArticuloMgr.LoadInto(CodArticulo, oArticulo)

        If BrandMgr.Load(oArticulo.CodMarca) Is Nothing Then
            MsgBox("La marca del producto no existe en el cat�logo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
            grdDetalle.Focus()
            Return False
        End If
        oFactura.FacturaArticuloExistencia = 0
        FillTallasArticulo(oArticulo.CodCorrida)
        oFacturaMgr.GetTallasArticulo(oArticulo.CodCorrida, oFactura)
        oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oFactura.CodAlmacen, Talla, oFactura, oArticulo.CodElectronico)
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
        Me.grdDetalle.Cols(0).AllowEditing = False
        Me.grdDetalle.Cols(1).AllowEditing = False
        Return valido
    End Function

    Private Sub CargarUPC(ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        If grdDetalle(RowIndex, 0) = "" Then
            MsgBox("Ingrese C�digo de Art�culo. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
            LimpiaDatosGrid(RowIndex)
            ActualizaCalculos()
            grdDetalle.Select(RowIndex, 0)
            grdDetalle.Focus()
        Else
            oArticulo.ClearFields()

            vNumeroArticulo = 0
            Dim oCatalogoUPCMgr As CatalogoUPCManager
            oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            If oCatalogoUPCMgr.IsSkuOrMaterial(grdDetalle(RowIndex, 0)) = "S" Then
                'Es un CodigoUPC
                Dim dsUPC As New DataTable
                Dim CodeRow As Integer
                dsUPC = oFacturaMgr.GetUPCData(grdDetalle(RowIndex, 0))
                If dsUPC.Rows.Count > 0 Then
                    'Validamos que el si el articulo en un 'DT-CAT' solamente el tipo de venta a utilizar sea DIPS
                    If EsCatalogo(dsUPC.Rows(0).Item("CodArticulo")) = True And Me.ebTipoVenta.Value <> "D" And Me.ebTipoVenta.Value <> "S" Then
                        If oAppContext.ApplicationConfiguration.Almacen = "053" Then
                            MsgBox("�D� de alta al cliente como SOCIO!", MsgBoxStyle.Information, Me.Text)
                        Else
                            MsgBox("�D� de alta al cliente como DIP!", MsgBoxStyle.Information, Me.Text)
                        End If
                        grdDetalle(grdDetalle.Row, 0) = ""
                        grdDetalle.Select(grdDetalle.Row, 0)
                    End If
                    oArticuloMgr.LoadInto(dsUPC.Rows(0).Item("CodArticulo"), oArticulo)
                    grdDetalle(RowIndex, 0) = oArticulo.CodArtProv
                    dsDetalle.Tables(0).Rows(RowIndex)!Codigo = oArticulo.CodArticulo
                    dsDetalle.Tables(0).AcceptChanges()
                    'grdDetalle(e.OldRange.r1, 0) = UCase(dsUPC.Rows(0).Item("CodArticulo"))
                    vNumeroArticulo = dsUPC.Rows(0).Item("Numero")
                    grdDetalle(RowIndex, 1) = vNumeroArticulo
                    '</Captura con lector>
                    CodeRow = BuscaCodigoEnVenta(grdDetalle(RowIndex, 0), vNumeroArticulo, RowIndex)
                    If CodeRow = 0 Then
                        ActualizaDatosArticulo(RowIndex, 0)
                        If 1 > ebExistencias.Value Then
                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                            LimpiaDatosGrid(RowIndex)
                            ActualizaCalculos()
                            grdDetalle.Focus()
                        Else
                            grdDetalle(RowIndex, 2) = 1
                            grdDetalle(RowIndex, 3) = Decimal.Round(oArticulo.PrecioVenta, 2)
                            grdDetalle(RowIndex, 4) = Decimal.Round(oArticulo.PrecioVenta, 2)

                            '**************Prueba************************
                            grdDetalle(RowIndex, 4) = Decimal.Round(grdDetalle(RowIndex, 3) * grdDetalle(RowIndex, 2), 2)
                            '/*********************
                            '--Aplicamos Descuento si lo tuviera
                            If ebPorcentajeDscto.Value > 0 Then
                                grdDetalle(RowIndex, 5) = Decimal.Round(grdDetalle(RowIndex, 4) * ebPorcentajeDscto.Value, 2)
                            Else
                                grdDetalle(RowIndex, 5) = Decimal.Round(grdDetalle(RowIndex, 2) * ebMontoDscto.Value, 2)
                            End If
                            dsDetalle.Tables(0).Rows(RowIndex)!Codigo = oArticulo.CodArticulo
                            dsDetalle.Tables(0).AcceptChanges()

                            '**********Aplicamos Descuento Adicional Automatico Segun Promocion Vigente
                            'AplicaDescuentosAutomaticos()
                            '/*********************
                            ActualizaCalculos()
                            '**************Prueba************************
                            'SendKeys.Send("{UP}")
                            'If boolManual Then
                            '    Dim oForm As New frmMotivosFactura
                            '    oForm.Motivos = oFactura.dtMotivos

                            '    oForm.Tienda = oAppContext.ApplicationConfiguration.Almacen
                            '    oForm.Articulo = grdDetalle(RowIndex, 0)
                            '    oForm.Talla = grdDetalle(RowIndex, 1)

                            '    oForm.ShowDialog()
                            'End If
                            'SendKeys.Send("{TAB}")
                            AddEmptyRow()

                        End If
                    Else
                        ActualizaDatosArticulo(CodeRow - 1, 0)
                        If (grdDetalle(CodeRow - 1, 2) + 1) > ebExistencias.Value Then
                            MsgBox("No se cuenta con existencia en esta Talla. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
                        LimpiaDatosGrid(RowIndex)
                        ActualizaCalculos()
                    End If
                Else
                    dsUPC = Nothing
                    MsgBox("C�digo UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                    LimpiaDatosGrid(RowIndex)
                    ActualizaCalculos()
                    grdDetalle.Focus()
                End If
                dsUPC = Nothing
            Else
                MessageBox.Show("No existe el c�digo UPC", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                grdDetalle(RowIndex, 0) = ""
            End If
        End If
    End Sub

    Private Sub grdDetalle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdDetalle.MouseClick
        If grdDetalle.Row >= 0 Then
            Dim codigo As String
            codigo = CStr(Me.dsDetalle.Tables(0).Rows(grdDetalle.Row)!Codigo)
            ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
        End If
    End Sub

#End Region

    Private Sub grdDetalle_SelChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetalle.SelChange
        If grdDetalle.Row >= 0 Then
            Dim codigo As String
            codigo = CStr(Me.dsDetalle.Tables(0).Rows(grdDetalle.Row)!Codigo)
            ActualizaDatosArticulo(grdDetalle.Row, grdDetalle.Col)
        End If
    End Sub

#Region "Correcciones validaciones DPVale"

    Private Function ValidaEstatusVale(ByVal CdpVale As cDPVale) As String
        Dim oDPValeSAP As New cDPValeSAP()
        Dim status As String = ""
        If CdpVale.EsElectronico Then
            oDPValeSAP.EsCalzado = CdpVale.EsCalzado
            oDPValeSAP.PromocionValeElectronico = CdpVale.PromocionValeElectronico
            If CdpVale.EsCalzado = False Then
                status = "El vale no es de calzado"
                Return status
            End If
            Dim oCSAP As ClientesSAP
            'oCSAP = GetCliente(ebClienteID.Text, oFactura.CodTipoVenta)
            oCSAP = GetClienteDPVale(CStr(CdpVale.InfoDPVALE.Rows(0)!CODCT).PadLeft(10, "0"))
            If oCSAP.Status <> 1 Then
                status = "El Cliente esta bloqueado"
                Return status
            End If
        End If
        oDPValeSAP.InfoDPVALE = CdpVale.InfoDPVALE
        oDPValeSAP.IDDPVale = CdpVale.INUMVA
        oDPValeSAP.Plaza = CdpVale.EPLAZA
        oDPValeSAP.ValeElectronico = CdpVale.EsElectronico
        'rgermain 15.10.2016: Si es S2Credit el saldo disponible esta en la propiedad LimiteCreditoPrestamo
        If oConfigCierreFI.AplicarS2Credit Then
            oDPValeSAP.LimiteCredito = CdpVale.LimiteCreditoPrestamo
        Else
            oDPValeSAP.LimiteCredito = CdpVale.LimiteCredito
        End If

        oDPValeSAP.Congelado = CdpVale.Congelado
        If CdpVale.EEXIST = "S" Then

            '-------------------------------------------------------------------------------------------------'-----------------------------------------------------
            'rgermain 14.10.2016: En este caso el limite de credito de prestamo es el saldo disponible, se guardo el valor ahi para no generar una nueva propiedad
            '                     al objeto
            '-------------------------------------------------------------------------------------------------'-----------------------------------------------------
            If oDPValeSAP.LimiteCredito <= 0 Then
                status = "El Acreditado no tiene saldo disponible. Verificar con la plaza DPVale."
                Return status
            End If
            If oDPValeSAP.Congelado = "X" Then
                status = "El Asociado esta congelado"
                Return status
            End If
            If oDPValeSAP.Plaza = String.Empty Then
                status = "No hay Plaza"
                Return status
            End If
            If CdpVale.ESTATU <> "A" Then
                If CdpVale.ESTATU = "E" Then
                    status = "El Dpvale est� Expirado"
                    Return status
                Else
                    If CdpVale.ESTATU = "U" Then
                        status = "El Dpvale ya esta Usado"
                        Return status
                    Else
                        If CdpVale.ESTATU = "C" Then
                            status = "El Dpvale esta Cancelado"
                            Return status
                        Else
                            status = "El Dpvale no se encuentra disponible. Favor de verificar."
                            Return status
                        End If
                    End If
                End If
            End If
        Else
            status = "El dpvale no Existe"
            Return status
        End If
        Return status
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
                    MessageBox.Show("No puede haber dos tarjetas de lealtad en la venta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                ConteoPosicionTarjeta += 1
            End If
        Next
        If ConteoPosicionTarjeta > 1 Then
            MessageBox.Show("No puede haber dos tarjetas de lealtad en la venta", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            valido = False
        End If
        Return valido
    End Function

#End Region



#Region "Correcci�n ventas incompletas"

    Private Function ProductosEnAclaracion() As DataTable
        Dim strCentro As String = String.Empty
        Dim oParametros As New Dictionary(Of String, Object)
        Dim dtResult As DataTable

        strCentro = oSAPMgr.Read_Centros


        'Obtener la informaci�n para ejecutar la RFC
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


    Private Sub FormaPago()
        btnFormaPago.Focus()
        RemoveEmptyRow()
        '------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 23/11/2018: Se valida que la suma del detalle cuadre con la cabecera
        '------------------------------------------------------------------------------------------------------
        If ValidaTotalDetalleCabecera() = False Then
            MessageBox.Show("El total no coincide con la suma del detalle", "Facturaci�n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '-----------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (07.04.2016): Si un registro viene vacio cuando hay mas de uno, entonces lo quitamos
        '-----------------------------------------------------------------------------------------------------------------------------
        For Each oRowD As DataRow In Me.dsDetalle.Tables(0).Rows
            If Me.dsDetalle.Tables(0).Rows.Count > 1 AndAlso CStr(oRowD!Codigo).Trim = "" Then
                Me.dsDetalle.Tables(0).Rows.Remove(oRowD)
                Exit For
            End If
        Next
        Me.dsDetalle.Tables(0).AcceptChanges()
        '-----------------------------------------------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/04/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '-----------------------------------------------------------------------------------------------------------------------------
        'If FacturacionSiHay > 0 Then
        Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
        Me.dtCantidadLibre = Me.dsDetalle.Tables(0).Copy()
        Me.dtCantidadLibre.TableName = "MaterialesLibres"

        'If ValidarMaterialesNegadosSH(Me.dtCantidadLibre, dtNegadosSH, "PF,P,RP", vApartadoInstance) = False Then
        '    ShowFormNegadosSH(dtNegadosSH)
        '    Exit Sub
        'End If
        'End If


        '-----------------------------------------------------------------------------------------------------------------------------
        'MLVARGAS 20/05/2022: Validacion de los pedidos que estan pendientes por Facturar y Surtir
        '-----------------------------------------------------------------------------------------------------------------------------

        If ValidarMaterialesNegadosSH(Me.dsDetalle.Tables(0), dtNegadosSH, "PF,P,RP") = False Then
            ShowFormNegadosSH(dtNegadosSH)
            Exit Sub
        End If

        Dim dtNegados As DataTable
        Dim UserNameNiega As String = ""
        Dim dtDefectuososEC As New DataTable 'Tabla con los codigos baja calidad EC que el player selecciono que van en la venta
        Dim UserNameDesmarca As String = ""
        Dim dtDefecECSAP As New DataTable 'Tabla con los codigos baja calidad EC marcados en SAP


        '-----------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 20/05/2022: Revisamos si hay codigos por negar a los pedidos solicitados por el Ecommerce en el detalle de la factura
        '-----------------------------------------------------------------------------------------------------------------------------
        If ValidarMaterialesParaNegarEC(dtNegados, Me.dsDetalle.Tables(0), dtDefectuososEC, dtDefecECSAP, UserNameDesmarca, "V") = False Then
            Exit Sub
        End If


        '  Dim dtAclaracion As DataTable
        ' dtAclaracion = ProductosEnAclaracion()

        '-----------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 06/07/2022: No se validaran los productos en aclaraci�n a petici�n de Francisco Rojo
        '-----------------------------------------------------------------------------------------------------------------------------
        'If ValidarProductosEnAclaracion(dtAclaracion, Me.dsDetalle.Tables(0)) = False Then
        '    Exit Sub
        'End If

        '-----------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS 06/06/2022: Revisamos si hay productos en reserva
        '-----------------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS Comentado mientras se resuelve
        'If ValidarProductosEnNecesidad(dtAclaracion, Me.dsDetalle.Tables(0)) = False Then
        '    Exit Sub
        'End If

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
            If oFactura.ClienteId = 0 And oFactura.CodTipoVenta <> "P" And oFactura.CodTipoVenta <> "E" Then
                MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
                ebClienteID.Focus()
                Exit Sub
            End If
            'If oConfigCierreFI.UsarHuellas Then
            '    If oFactura.ClienteId = 10000000 AndAlso (oFactura.CodTipoVenta <> "P" OrElse oConfigCierreFI.RegistroPGOpcional = False) Then
            '        MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
            '        ebClienteID.Focus()
            '        Exit Sub
            '    End If
            'Else
            '    If oFactura.ClienteId = 10000000 Then
            '        MsgBox("Asigne C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
            '        ebClienteID.Focus()
            '        Exit Sub
            '    End If
            'End If
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
            If (ebTipoVenta.Value <> "P" AndAlso ebTipoVenta.Value <> "V" AndAlso ebTipoVenta.Value <> "E" AndAlso oFactura.ClienteId <= 0) Then
                MsgBox("Por el Tipo de Venta es necesario ingresar C�digo de Cliente.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
                ebClienteID.Focus()
                Exit Sub
            ElseIf ebTipoVenta.Value = "P" AndAlso oConfigCierreFI.UsarHuellas Then
                Dim FolioSAP As String = ""
                If oFactura.ClienteId <= 0 Then
                    If MessageBox.Show("�Desea registrar los datos del cliente?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        If AltadeCliente() = False AndAlso oFactura.RazonRechazo.Trim = "" Then
                            GoTo EspecificaRazon
                        End If
                    ElseIf oFactura.RazonRechazo.Trim = "" Then
EspecificaRazon:
                        'oFactura.RazonRechazo = InputBox("Especifique la raz�n por la que no registr� los datos del cliente.", Me.Text)
                        Dim oFrmRazones As New frmRazonesRechazo
                        oFrmRazones.ModuloOrigen = "FA"
                        If oFrmRazones.ShowDialog = DialogResult.OK Then
                            oFactura.RazonRechazo = oFrmRazones.cmbRazones.Text
                            oFactura.RazonRechazoID = oFrmRazones.cmbRazones.Value
                            'End If
                            'If oFactura.RazonRechazo.Trim = "" OrElse oFactura.RazonRechazo.Trim.Length < 5 Then
                        Else
                            'MessageBox.Show("Es necesario seleccionar una raz�n de rechazo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'GoTo EspecificaRazon
                            Exit Sub
                        End If
                    End If
                ElseIf oFingerPrintMgr.IsClientePGEnFactura(oFactura.ClienteId, FolioSAP) Then
                    oFactura.RazonRechazo = "El cliente ya habia sido registrado anteriormente con el codigo: " & CStr(oFactura.ClienteId).PadLeft(10, "0") & _
                                            " en la Factura: " & FolioSAP
                    oFactura.RazonRechazoID = 0
                Else
                    oFactura.RazonRechazo = ""
                    oFactura.RazonRechazoID = 0
                End If
            End If
            If oFactura.CodVendedor = String.Empty Then
                MsgBox("Asigne C�digo de Vendedor.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
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
                        MsgBox("La compra debe ser igual o mayor a la cantidad devuelta a Dportenis Vale", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
                        grdDetalle.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If oValeCaja.ValeCajaID > 0 Then
                If oFactura.Total < oValeCaja.Importe Then
                    MsgBox("La compra debe ser igual o mayor a la cantidad devuelta", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
                            MsgBox("Este asociado no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        Else
                            MsgBox("Este asociado no tiene descuento por que no ha comprado el nuevo catalogo de la temporada", MsgBoxStyle.Exclamation, Me.Text)
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
                    MsgBox("Debe Ingresar Numero de Autorizaci�n. No se puede continuar. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturaci�n")
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
            '------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 29.08.2014: Validamos si el cliente dejo sus datos para enviarle promociones si esta activada la config
            '------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.PedirDatosPromoComienzo AndAlso strDatosPromoClientes.Trim = "" Then
                If MessageBox.Show("�Estas seguro que no deseas capturar los datos del cliente para futuras promociones?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    CapturaCelParaSMS()
                End If
            End If

            '-----------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (19.12.2014): Validamos que si NO aplica el CrossSelling, se revisan las promociones vigentes
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
                strFolioCupon = InputBox("Especifique el Folio del Cup�n", "Dportenis PRO", "").Trim.ToUpper
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
            '------------------------------------------------------------------------------------------------------------------------------------
            'Validamos Tipo de Descuento
            '------------------------------------------------------------------------------------------------------------------------------------
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

                    'A�adimos Evento A TipoDescuento
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
                    '    MsgBox("Este tipo de descuento no est� permitido para esta tienda." & vbCrLf & "Debe elegir otro tipo de descuento.", MsgBoxStyle.Exclamation, "Dportenis Pro")
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
                    '            MsgBox("S�lo puede aplicar descuentos a 3 piezas. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
                    '        Case 2
                    '            MsgBox("Existen c�digos con m�s del " & CInt(oValeDescuentoLocalInfo.TipoVale) * 10 & "% de Descuento. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "  Factura")
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
            MsgBox("Factura no tiene asignado art�culos.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturaci�n")
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
                    LogMensaje &= "CodArt�culo: " & CStr(oRow("Codigo")) & " Cant: " & CStr(oRow("Cantidad")) & " Importe: " & CStr(vImporte) & vbCrLf
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