Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUPC
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Public Class CatalogoArticulosForm
    Inherits System.Windows.Forms.Form

    Private oCatalogoArticuloMgr As CatalogoArticuloManager
    Private oArticulo As Articulo
    Private dsBuscar As DataSet
    Dim iInitial As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents menuCatalogo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCategorias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoFamilias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMarcas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoPublicaciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTipoMoneda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUsos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCategorias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoFamilias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMarcas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoPublicaciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTipoMoneda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUsos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalago As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCategoria As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCorrida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoFamilia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoLineas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMarcas2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoProveedores As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoPublicaciones2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTemporada As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMoneda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUnidades As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUsos2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCategoria1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCorrida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoFamilia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoLineas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMarcas3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoProveedores1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoPublicaciones3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTemporada1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoMoneda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUnidades1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoUsos3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents NicePanel1 As PureComponents.NicePanel.NicePanel
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents UiButton19 As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar5 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents UiProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    Friend WithEvents ebColor2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebColor1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecUltTempDip As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecUltTemp As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMarca As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFamilia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebLinea As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCategoria As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCorrida As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPublicacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodNumTemporada As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoPro As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoDP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDescuento As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPrecio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMargen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCostoProm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chkDIP As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkOrdenable As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkImportado As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkPrecio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebColor3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebProveedor2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebProveedor1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNameProv2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNameProv1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMonedaCom As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebMonedaVen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUnidadVta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUnidadCom As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdi3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdi2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdi1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAlter3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAlter2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAlter1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFUC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFUO As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFecOferta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPrecioOferta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents imAdi3 As System.Windows.Forms.PictureBox
    Friend WithEvents imAdi2 As System.Windows.Forms.PictureBox
    Friend WithEvents imAdi1 As System.Windows.Forms.PictureBox
    Friend WithEvents imAlter3 As System.Windows.Forms.PictureBox
    Friend WithEvents imAlter2 As System.Windows.Forms.PictureBox
    Friend WithEvents imAlter1 As System.Windows.Forms.PictureBox
    Friend WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imArticulo As System.Windows.Forms.PictureBox
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoArticulosForm))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup5 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.menuCatalogo1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuCatalogoCategorias1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCategorias")
        Me.menuCatalogoFamilias1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoFamilias")
        Me.menuCatalogoMarcas1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMarcas")
        Me.menuCatalogoPublicaciones1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoPublicaciones")
        Me.menuCatalogoTipoMoneda1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTipoMoneda")
        Me.menuCatalogoUsos1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUsos")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ebFUC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFUO = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFecOferta = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNameProv2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNameProv1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMonedaCom = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMonedaVen = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.ebUnidadVta = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUnidadCom = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebProveedor2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebProveedor1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.ebPrecioOferta = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.ebDescuento = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPrecio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMargen = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCostoProm = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkDIP = New Janus.Windows.EditControls.UICheckBox
        Me.chkOrdenable = New Janus.Windows.EditControls.UICheckBox
        Me.chkImportado = New Janus.Windows.EditControls.UICheckBox
        Me.chkPrecio = New Janus.Windows.EditControls.UICheckBox
        Me.NicePanel1 = New PureComponents.NicePanel.NicePanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.imArticulo = New System.Windows.Forms.PictureBox
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.UiProgressBar1 = New Janus.Windows.EditControls.UIProgressBar
        Me.ebColor3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebColor2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebColor1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFecUltTempDip = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFecUltTemp = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.ebStatus = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebMarca = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUso = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFamilia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebLinea = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCategoria = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCorrida = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPublicacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ebCodNumTemporada = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ebCodigoPro = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ebCodigoDP = New Janus.Windows.GridEX.EditControls.EditBox
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage
        Me.ExplorerBar5 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.imAdi3 = New System.Windows.Forms.PictureBox
        Me.imAdi2 = New System.Windows.Forms.PictureBox
        Me.imAdi1 = New System.Windows.Forms.PictureBox
        Me.ebAdi3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.ebAdi2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.ebAdi1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.imAlter3 = New System.Windows.Forms.PictureBox
        Me.imAlter2 = New System.Windows.Forms.PictureBox
        Me.imAlter1 = New System.Windows.Forms.PictureBox
        Me.UiButton19 = New Janus.Windows.EditControls.UIButton
        Me.ebAlter3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.ebAlter2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.ebAlter1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.menuBarNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuBarNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCatalogoCategorias = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCategorias")
        Me.menuCatalogoFamilias = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoFamilias")
        Me.menuCatalogoMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMarcas")
        Me.menuCatalogoPublicaciones = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoPublicaciones")
        Me.menuCatalogoTipoMoneda = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTipoMoneda")
        Me.menuCatalogoUsos = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUsos")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuBarAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaAcerca1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuBarAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCatalago = New Janus.Windows.UI.CommandBars.UICommand("menuCatalago")
        Me.menuCatalogoCategoria1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCategoria")
        Me.menuCatalogoCorrida1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCorrida")
        Me.menuCatalogoFamilia1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoFamilia")
        Me.menuCatalogoLineas1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoLineas")
        Me.menuCatalogoMarcas3 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMarcas")
        Me.menuCatalogoProveedores1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoProveedores")
        Me.menuCatalogoPublicaciones3 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoPublicaciones")
        Me.menuCatalogoTemporada1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTemporada")
        Me.menuCatalogoMoneda1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMoneda")
        Me.menuCatalogoUnidades1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUnidades")
        Me.menuCatalogoUsos3 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUsos")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaAcerca3 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuCatalogoCategoria = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCategoria")
        Me.menuCatalogoCorrida = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCorrida")
        Me.menuCatalogoFamilia = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoFamilia")
        Me.menuCatalogoLineas = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoLineas")
        Me.menuCatalogoMarcas2 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMarcas")
        Me.menuCatalogoProveedores = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoProveedores")
        Me.menuCatalogoPublicaciones2 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoPublicaciones")
        Me.menuCatalogoTemporada = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTemporada")
        Me.menuCatalogoMoneda = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoMoneda")
        Me.menuCatalogoUnidades = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUnidades")
        Me.menuCatalogoUsos2 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoUsos")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaAcerca2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuArchivoImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoImprimir")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.NicePanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.ExplorerBar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar5.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuCatalogo1
        '
        Me.menuCatalogo1.Key = "menuCatalogo"
        Me.menuCatalogo1.Name = "menuCatalogo1"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuCatalogoCategorias1, Me.menuCatalogoFamilias1, Me.menuCatalogoMarcas1, Me.menuCatalogoPublicaciones1, Me.menuCatalogoTipoMoneda1, Me.menuCatalogoUsos1})
        Me.menuCatalogo.Key = "menuCatalogo"
        Me.menuCatalogo.Name = "menuCatalogo"
        Me.menuCatalogo.Text = "Ca&talogo"
        '
        'menuCatalogoCategorias1
        '
        Me.menuCatalogoCategorias1.Key = "menuCatalogoCategorias"
        Me.menuCatalogoCategorias1.Name = "menuCatalogoCategorias1"
        '
        'menuCatalogoFamilias1
        '
        Me.menuCatalogoFamilias1.Key = "menuCatalogoFamilias"
        Me.menuCatalogoFamilias1.Name = "menuCatalogoFamilias1"
        '
        'menuCatalogoMarcas1
        '
        Me.menuCatalogoMarcas1.Key = "menuCatalogoMarcas"
        Me.menuCatalogoMarcas1.Name = "menuCatalogoMarcas1"
        '
        'menuCatalogoPublicaciones1
        '
        Me.menuCatalogoPublicaciones1.Key = "menuCatalogoPublicaciones"
        Me.menuCatalogoPublicaciones1.Name = "menuCatalogoPublicaciones1"
        '
        'menuCatalogoTipoMoneda1
        '
        Me.menuCatalogoTipoMoneda1.Key = "menuCatalogoTipoMoneda"
        Me.menuCatalogoTipoMoneda1.Name = "menuCatalogoTipoMoneda1"
        '
        'menuCatalogoUsos1
        '
        Me.menuCatalogoUsos1.Key = "menuCatalogoUsos"
        Me.menuCatalogoUsos1.Name = "menuCatalogoUsos1"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "&Salir"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.White
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.UiTab1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(832, 603)
        Me.UiGroupBox1.TabIndex = 1
        '
        'UiTab1
        '
        Me.UiTab1.Controls.Add(Me.UiTabPage1)
        Me.UiTab1.Controls.Add(Me.UiTabPage2)
        Me.UiTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiTab1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiTab1.Location = New System.Drawing.Point(0, 0)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.SelectedIndex = 0
        Me.UiTab1.Size = New System.Drawing.Size(832, 603)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar3)
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar2)
        Me.UiTabPage1.Controls.Add(Me.NicePanel1)
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar1)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 22)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(830, 580)
        Me.UiTabPage1.TabIndex = 0
        Me.UiTabPage1.Text = "Datos del Articulo                  "
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.ebFUC)
        Me.ExplorerBar3.Controls.Add(Me.ebFUO)
        Me.ExplorerBar3.Controls.Add(Me.ebFecOferta)
        Me.ExplorerBar3.Controls.Add(Me.ebNameProv2)
        Me.ExplorerBar3.Controls.Add(Me.ebNameProv1)
        Me.ExplorerBar3.Controls.Add(Me.ebMonedaCom)
        Me.ExplorerBar3.Controls.Add(Me.ebMonedaVen)
        Me.ExplorerBar3.Controls.Add(Me.Label32)
        Me.ExplorerBar3.Controls.Add(Me.Label31)
        Me.ExplorerBar3.Controls.Add(Me.ebUnidadVta)
        Me.ExplorerBar3.Controls.Add(Me.ebUnidadCom)
        Me.ExplorerBar3.Controls.Add(Me.ebProveedor2)
        Me.ExplorerBar3.Controls.Add(Me.ebProveedor1)
        Me.ExplorerBar3.Controls.Add(Me.Label30)
        Me.ExplorerBar3.Controls.Add(Me.Label29)
        Me.ExplorerBar3.Controls.Add(Me.Label28)
        Me.ExplorerBar3.Controls.Add(Me.Label27)
        Me.ExplorerBar3.Controls.Add(Me.ebPrecioOferta)
        Me.ExplorerBar3.Controls.Add(Me.Label26)
        Me.ExplorerBar3.Controls.Add(Me.Label25)
        Me.ExplorerBar3.Controls.Add(Me.Label24)
        Me.ExplorerBar3.Controls.Add(Me.Label23)
        Me.ExplorerBar3.Controls.Add(Me.ebDescuento)
        Me.ExplorerBar3.Controls.Add(Me.ebPrecio)
        Me.ExplorerBar3.Controls.Add(Me.ebMargen)
        Me.ExplorerBar3.Controls.Add(Me.ebCostoProm)
        Me.ExplorerBar3.Controls.Add(Me.Label22)
        Me.ExplorerBar3.Controls.Add(Me.Label21)
        Me.ExplorerBar3.Controls.Add(Me.Label20)
        Me.ExplorerBar3.Controls.Add(Me.Label19)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Mercadeo"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 429)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(832, 163)
        Me.ExplorerBar3.TabIndex = 2
        Me.ExplorerBar3.TabStop = False
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebFUC
        '
        Me.ebFUC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFUC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFUC.AutoSize = False
        Me.ebFUC.BackColor = System.Drawing.Color.Ivory
        Me.ebFUC.Location = New System.Drawing.Point(336, 104)
        Me.ebFUC.Name = "ebFUC"
        Me.ebFUC.ReadOnly = True
        Me.ebFUC.Size = New System.Drawing.Size(96, 22)
        Me.ebFUC.TabIndex = 7
        Me.ebFUC.TabStop = False
        Me.ebFUC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFUC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFUO
        '
        Me.ebFUO.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFUO.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFUO.AutoSize = False
        Me.ebFUO.BackColor = System.Drawing.Color.Ivory
        Me.ebFUO.Location = New System.Drawing.Point(336, 80)
        Me.ebFUO.Name = "ebFUO"
        Me.ebFUO.ReadOnly = True
        Me.ebFUO.Size = New System.Drawing.Size(96, 22)
        Me.ebFUO.TabIndex = 6
        Me.ebFUO.TabStop = False
        Me.ebFUO.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFUO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecOferta
        '
        Me.ebFecOferta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecOferta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecOferta.AutoSize = False
        Me.ebFecOferta.BackColor = System.Drawing.Color.Ivory
        Me.ebFecOferta.Location = New System.Drawing.Point(336, 56)
        Me.ebFecOferta.Name = "ebFecOferta"
        Me.ebFecOferta.ReadOnly = True
        Me.ebFecOferta.Size = New System.Drawing.Size(96, 22)
        Me.ebFecOferta.TabIndex = 5
        Me.ebFecOferta.TabStop = False
        Me.ebFecOferta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecOferta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNameProv2
        '
        Me.ebNameProv2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNameProv2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNameProv2.AutoSize = False
        Me.ebNameProv2.BackColor = System.Drawing.Color.Ivory
        Me.ebNameProv2.Location = New System.Drawing.Point(634, 59)
        Me.ebNameProv2.Name = "ebNameProv2"
        Me.ebNameProv2.ReadOnly = True
        Me.ebNameProv2.Size = New System.Drawing.Size(176, 22)
        Me.ebNameProv2.TabIndex = 13
        Me.ebNameProv2.TabStop = False
        Me.ebNameProv2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNameProv2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNameProv1
        '
        Me.ebNameProv1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNameProv1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNameProv1.AutoSize = False
        Me.ebNameProv1.BackColor = System.Drawing.Color.Ivory
        Me.ebNameProv1.Location = New System.Drawing.Point(634, 33)
        Me.ebNameProv1.Name = "ebNameProv1"
        Me.ebNameProv1.ReadOnly = True
        Me.ebNameProv1.Size = New System.Drawing.Size(176, 22)
        Me.ebNameProv1.TabIndex = 12
        Me.ebNameProv1.TabStop = False
        Me.ebNameProv1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNameProv1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMonedaCom
        '
        Me.ebMonedaCom.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMonedaCom.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMonedaCom.AutoSize = False
        Me.ebMonedaCom.BackColor = System.Drawing.Color.Ivory
        Me.ebMonedaCom.ButtonImage = CType(resources.GetObject("ebMonedaCom.ButtonImage"), System.Drawing.Image)
        Me.ebMonedaCom.Location = New System.Drawing.Point(727, 85)
        Me.ebMonedaCom.Name = "ebMonedaCom"
        Me.ebMonedaCom.ReadOnly = True
        Me.ebMonedaCom.Size = New System.Drawing.Size(82, 22)
        Me.ebMonedaCom.TabIndex = 16
        Me.ebMonedaCom.TabStop = False
        Me.ebMonedaCom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMonedaCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMonedaVen
        '
        Me.ebMonedaVen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMonedaVen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMonedaVen.AutoSize = False
        Me.ebMonedaVen.BackColor = System.Drawing.Color.Ivory
        Me.ebMonedaVen.ButtonImage = CType(resources.GetObject("ebMonedaVen.ButtonImage"), System.Drawing.Image)
        Me.ebMonedaVen.Location = New System.Drawing.Point(727, 111)
        Me.ebMonedaVen.Name = "ebMonedaVen"
        Me.ebMonedaVen.ReadOnly = True
        Me.ebMonedaVen.Size = New System.Drawing.Size(82, 22)
        Me.ebMonedaVen.TabIndex = 17
        Me.ebMonedaVen.TabStop = False
        Me.ebMonedaVen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMonedaVen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(632, 112)
        Me.Label32.Name = "Label32"
        Me.Label32.TabIndex = 15
        Me.Label32.Text = "Moneda Venta:"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(632, 88)
        Me.Label31.Name = "Label31"
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Moneda Compra :"
        '
        'ebUnidadVta
        '
        Me.ebUnidadVta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidadVta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidadVta.AutoSize = False
        Me.ebUnidadVta.BackColor = System.Drawing.Color.Ivory
        Me.ebUnidadVta.ButtonImage = CType(resources.GetObject("ebUnidadVta.ButtonImage"), System.Drawing.Image)
        Me.ebUnidadVta.Location = New System.Drawing.Point(528, 111)
        Me.ebUnidadVta.Name = "ebUnidadVta"
        Me.ebUnidadVta.ReadOnly = True
        Me.ebUnidadVta.Size = New System.Drawing.Size(96, 22)
        Me.ebUnidadVta.TabIndex = 11
        Me.ebUnidadVta.TabStop = False
        Me.ebUnidadVta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUnidadVta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUnidadCom
        '
        Me.ebUnidadCom.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUnidadCom.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUnidadCom.AutoSize = False
        Me.ebUnidadCom.BackColor = System.Drawing.Color.Ivory
        Me.ebUnidadCom.ButtonImage = CType(resources.GetObject("ebUnidadCom.ButtonImage"), System.Drawing.Image)
        Me.ebUnidadCom.Location = New System.Drawing.Point(528, 85)
        Me.ebUnidadCom.Name = "ebUnidadCom"
        Me.ebUnidadCom.ReadOnly = True
        Me.ebUnidadCom.Size = New System.Drawing.Size(96, 22)
        Me.ebUnidadCom.TabIndex = 10
        Me.ebUnidadCom.TabStop = False
        Me.ebUnidadCom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUnidadCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebProveedor2
        '
        Me.ebProveedor2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebProveedor2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebProveedor2.AutoSize = False
        Me.ebProveedor2.BackColor = System.Drawing.Color.Ivory
        Me.ebProveedor2.ButtonImage = CType(resources.GetObject("ebProveedor2.ButtonImage"), System.Drawing.Image)
        Me.ebProveedor2.Location = New System.Drawing.Point(528, 59)
        Me.ebProveedor2.Name = "ebProveedor2"
        Me.ebProveedor2.ReadOnly = True
        Me.ebProveedor2.Size = New System.Drawing.Size(96, 22)
        Me.ebProveedor2.TabIndex = 9
        Me.ebProveedor2.TabStop = False
        Me.ebProveedor2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebProveedor2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebProveedor1
        '
        Me.ebProveedor1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebProveedor1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebProveedor1.AutoSize = False
        Me.ebProveedor1.BackColor = System.Drawing.Color.Ivory
        Me.ebProveedor1.ButtonImage = CType(resources.GetObject("ebProveedor1.ButtonImage"), System.Drawing.Image)
        Me.ebProveedor1.Location = New System.Drawing.Point(528, 33)
        Me.ebProveedor1.Name = "ebProveedor1"
        Me.ebProveedor1.ReadOnly = True
        Me.ebProveedor1.Size = New System.Drawing.Size(96, 22)
        Me.ebProveedor1.TabIndex = 8
        Me.ebProveedor1.TabStop = False
        Me.ebProveedor1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebProveedor1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(440, 112)
        Me.Label30.Name = "Label30"
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "Unidad Venta:"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(440, 88)
        Me.Label29.Name = "Label29"
        Me.Label29.TabIndex = 19
        Me.Label29.Text = "Unidad Compra:"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(440, 64)
        Me.Label28.Name = "Label28"
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Proveedor 2:"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(440, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.TabIndex = 17
        Me.Label27.Text = "Proveedor:"
        '
        'ebPrecioOferta
        '
        Me.ebPrecioOferta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPrecioOferta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPrecioOferta.AutoSize = False
        Me.ebPrecioOferta.BackColor = System.Drawing.Color.Ivory
        Me.ebPrecioOferta.Location = New System.Drawing.Point(336, 32)
        Me.ebPrecioOferta.Name = "ebPrecioOferta"
        Me.ebPrecioOferta.ReadOnly = True
        Me.ebPrecioOferta.Size = New System.Drawing.Size(96, 22)
        Me.ebPrecioOferta.TabIndex = 4
        Me.ebPrecioOferta.TabStop = False
        Me.ebPrecioOferta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPrecioOferta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(239, 112)
        Me.Label26.Name = "Label26"
        Me.Label26.TabIndex = 12
        Me.Label26.Text = "Fecha Ult Compra:"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(239, 88)
        Me.Label25.Name = "Label25"
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "Fecha Ult Oferta:"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(239, 64)
        Me.Label24.Name = "Label24"
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "Fecha Oferta:"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(240, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "Precio Oferta:"
        '
        'ebDescuento
        '
        Me.ebDescuento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescuento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescuento.AutoSize = False
        Me.ebDescuento.BackColor = System.Drawing.Color.Ivory
        Me.ebDescuento.Location = New System.Drawing.Point(137, 112)
        Me.ebDescuento.Name = "ebDescuento"
        Me.ebDescuento.ReadOnly = True
        Me.ebDescuento.Size = New System.Drawing.Size(96, 22)
        Me.ebDescuento.TabIndex = 3
        Me.ebDescuento.TabStop = False
        Me.ebDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPrecio
        '
        Me.ebPrecio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPrecio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPrecio.AutoSize = False
        Me.ebPrecio.BackColor = System.Drawing.Color.Ivory
        Me.ebPrecio.Location = New System.Drawing.Point(137, 85)
        Me.ebPrecio.Name = "ebPrecio"
        Me.ebPrecio.ReadOnly = True
        Me.ebPrecio.Size = New System.Drawing.Size(96, 22)
        Me.ebPrecio.TabIndex = 2
        Me.ebPrecio.TabStop = False
        Me.ebPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMargen
        '
        Me.ebMargen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMargen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMargen.AutoSize = False
        Me.ebMargen.BackColor = System.Drawing.Color.Ivory
        Me.ebMargen.Location = New System.Drawing.Point(137, 59)
        Me.ebMargen.Name = "ebMargen"
        Me.ebMargen.ReadOnly = True
        Me.ebMargen.Size = New System.Drawing.Size(96, 22)
        Me.ebMargen.TabIndex = 1
        Me.ebMargen.TabStop = False
        Me.ebMargen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebMargen.Visible = False
        Me.ebMargen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCostoProm
        '
        Me.ebCostoProm.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCostoProm.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCostoProm.AutoSize = False
        Me.ebCostoProm.BackColor = System.Drawing.Color.Ivory
        Me.ebCostoProm.Location = New System.Drawing.Point(137, 33)
        Me.ebCostoProm.Name = "ebCostoProm"
        Me.ebCostoProm.ReadOnly = True
        Me.ebCostoProm.Size = New System.Drawing.Size(96, 22)
        Me.ebCostoProm.TabIndex = 0
        Me.ebCostoProm.TabStop = False
        Me.ebCostoProm.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCostoProm.Visible = False
        Me.ebCostoProm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(48, 112)
        Me.Label22.Name = "Label22"
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Descuento:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(48, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Precio Venta:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(48, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Margen Utilidad:"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(48, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Costo Promedio:"
        Me.Label19.Visible = False
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.Label41)
        Me.ExplorerBar2.Controls.Add(Me.Label40)
        Me.ExplorerBar2.Controls.Add(Me.Label39)
        Me.ExplorerBar2.Controls.Add(Me.Label5)
        Me.ExplorerBar2.Controls.Add(Me.chkDIP)
        Me.ExplorerBar2.Controls.Add(Me.chkOrdenable)
        Me.ExplorerBar2.Controls.Add(Me.chkImportado)
        Me.ExplorerBar2.Controls.Add(Me.chkPrecio)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Atributos"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 360)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(832, 88)
        Me.ExplorerBar2.TabIndex = 1
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(600, 37)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(120, 16)
        Me.Label41.TabIndex = 7
        Me.Label41.Text = "Catalogo (DIP)"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(456, 37)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(120, 16)
        Me.Label40.TabIndex = 6
        Me.Label40.Text = "Ordenable"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(312, 37)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(120, 16)
        Me.Label39.TabIndex = 5
        Me.Label39.Text = "Importado"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Precio Codigo Barras"
        '
        'chkDIP
        '
        Me.chkDIP.BackColor = System.Drawing.Color.Transparent
        Me.chkDIP.Enabled = False
        Me.chkDIP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDIP.Location = New System.Drawing.Point(584, 34)
        Me.chkDIP.Name = "chkDIP"
        Me.chkDIP.Size = New System.Drawing.Size(120, 23)
        Me.chkDIP.TabIndex = 3
        Me.chkDIP.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkOrdenable
        '
        Me.chkOrdenable.BackColor = System.Drawing.Color.Transparent
        Me.chkOrdenable.Enabled = False
        Me.chkOrdenable.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrdenable.Location = New System.Drawing.Point(440, 34)
        Me.chkOrdenable.Name = "chkOrdenable"
        Me.chkOrdenable.Size = New System.Drawing.Size(120, 23)
        Me.chkOrdenable.TabIndex = 2
        Me.chkOrdenable.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkImportado
        '
        Me.chkImportado.BackColor = System.Drawing.Color.Transparent
        Me.chkImportado.Enabled = False
        Me.chkImportado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImportado.Location = New System.Drawing.Point(296, 34)
        Me.chkImportado.Name = "chkImportado"
        Me.chkImportado.Size = New System.Drawing.Size(120, 23)
        Me.chkImportado.TabIndex = 1
        Me.chkImportado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkPrecio
        '
        Me.chkPrecio.BackColor = System.Drawing.Color.Transparent
        Me.chkPrecio.Enabled = False
        Me.chkPrecio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrecio.Location = New System.Drawing.Point(96, 34)
        Me.chkPrecio.Name = "chkPrecio"
        Me.chkPrecio.Size = New System.Drawing.Size(176, 23)
        Me.chkPrecio.TabIndex = 0
        Me.chkPrecio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'NicePanel1
        '
        Me.NicePanel1.BackColor = System.Drawing.Color.Transparent
        Me.NicePanel1.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.NicePanel1.ContainerImage = ContainerImage1
        Me.NicePanel1.Controls.Add(Me.Panel1)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.NicePanel1.FooterImage = HeaderImage1
        Me.NicePanel1.FooterText = "Grupo Dportenis S.A. de C.V."
        Me.NicePanel1.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.NicePanel1.HeaderImage = HeaderImage2
        Me.NicePanel1.HeaderText = "Imagen del Articulo"
        Me.NicePanel1.IsExpanded = True
        Me.NicePanel1.Location = New System.Drawing.Point(440, 40)
        Me.NicePanel1.Name = "NicePanel1"
        Me.NicePanel1.OriginalFooterVisible = True
        Me.NicePanel1.OriginalHeight = 0
        Me.NicePanel1.Size = New System.Drawing.Size(381, 314)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(142, Byte), CType(179, Byte), CType(231, Byte))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(1, Byte), CType(45, Byte), CType(150, Byte))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(217, Byte), CType(232, Byte), CType(252, Byte))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(169, Byte), CType(198, Byte), CType(237, Byte))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(215, Byte), CType(230, Byte), CType(251, Byte))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.NicePanel1.Style = PanelStyle1
        Me.NicePanel1.TabIndex = 3
        Me.NicePanel1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.imArticulo)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(1, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 272)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Tag = "NicePanelAutoScroll"
        Me.Panel1.Text = "NicePanelAutoScroll"
        '
        'imArticulo
        '
        Me.imArticulo.BackColor = System.Drawing.Color.Transparent
        Me.imArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imArticulo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imArticulo.ForeColor = System.Drawing.Color.Black
        Me.imArticulo.Location = New System.Drawing.Point(0, 0)
        Me.imArticulo.Name = "imArticulo"
        Me.imArticulo.Size = New System.Drawing.Size(379, 272)
        Me.imArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imArticulo.TabIndex = 0
        Me.imArticulo.TabStop = False
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.AllowDrop = True
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.UiProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.ebColor3)
        Me.ExplorerBar1.Controls.Add(Me.ebColor2)
        Me.ExplorerBar1.Controls.Add(Me.ebColor1)
        Me.ExplorerBar1.Controls.Add(Me.ebFecUltTempDip)
        Me.ExplorerBar1.Controls.Add(Me.ebFecUltTemp)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.ebStatus)
        Me.ExplorerBar1.Controls.Add(Me.ebMarca)
        Me.ExplorerBar1.Controls.Add(Me.ebUso)
        Me.ExplorerBar1.Controls.Add(Me.ebFamilia)
        Me.ExplorerBar1.Controls.Add(Me.ebLinea)
        Me.ExplorerBar1.Controls.Add(Me.ebCategoria)
        Me.ExplorerBar1.Controls.Add(Me.ebCorrida)
        Me.ExplorerBar1.Controls.Add(Me.ebPublicacion)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebDescripcion)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebCodNumTemporada)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigoPro)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigoDP)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(832, 360)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'UiProgressBar1
        '
        Me.UiProgressBar1.Enabled = False
        Me.UiProgressBar1.Location = New System.Drawing.Point(17, 113)
        Me.UiProgressBar1.Name = "UiProgressBar1"
        Me.UiProgressBar1.Size = New System.Drawing.Size(414, 3)
        Me.UiProgressBar1.TabIndex = 0
        Me.UiProgressBar1.TabStop = False
        Me.UiProgressBar1.Text = "UiProgressBar1"
        '
        'ebColor3
        '
        Me.ebColor3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColor3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColor3.AutoSize = False
        Me.ebColor3.BackColor = System.Drawing.Color.Ivory
        Me.ebColor3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColor3.Location = New System.Drawing.Point(136, 264)
        Me.ebColor3.Name = "ebColor3"
        Me.ebColor3.ReadOnly = True
        Me.ebColor3.Size = New System.Drawing.Size(96, 22)
        Me.ebColor3.TabIndex = 9
        Me.ebColor3.TabStop = False
        Me.ebColor3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColor3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebColor2
        '
        Me.ebColor2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColor2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColor2.AutoSize = False
        Me.ebColor2.BackColor = System.Drawing.Color.Ivory
        Me.ebColor2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColor2.Location = New System.Drawing.Point(136, 240)
        Me.ebColor2.Name = "ebColor2"
        Me.ebColor2.ReadOnly = True
        Me.ebColor2.Size = New System.Drawing.Size(96, 22)
        Me.ebColor2.TabIndex = 8
        Me.ebColor2.TabStop = False
        Me.ebColor2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColor2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebColor1
        '
        Me.ebColor1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColor1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColor1.AutoSize = False
        Me.ebColor1.BackColor = System.Drawing.Color.Ivory
        Me.ebColor1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColor1.Location = New System.Drawing.Point(136, 216)
        Me.ebColor1.Name = "ebColor1"
        Me.ebColor1.ReadOnly = True
        Me.ebColor1.Size = New System.Drawing.Size(96, 22)
        Me.ebColor1.TabIndex = 7
        Me.ebColor1.TabStop = False
        Me.ebColor1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColor1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecUltTempDip
        '
        Me.ebFecUltTempDip.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecUltTempDip.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecUltTempDip.AutoSize = False
        Me.ebFecUltTempDip.BackColor = System.Drawing.Color.Ivory
        Me.ebFecUltTempDip.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecUltTempDip.Location = New System.Drawing.Point(320, 312)
        Me.ebFecUltTempDip.Name = "ebFecUltTempDip"
        Me.ebFecUltTempDip.ReadOnly = True
        Me.ebFecUltTempDip.Size = New System.Drawing.Size(96, 22)
        Me.ebFecUltTempDip.TabIndex = 16
        Me.ebFecUltTempDip.TabStop = False
        Me.ebFecUltTempDip.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecUltTempDip.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFecUltTemp
        '
        Me.ebFecUltTemp.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecUltTemp.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecUltTemp.AutoSize = False
        Me.ebFecUltTemp.BackColor = System.Drawing.Color.Ivory
        Me.ebFecUltTemp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecUltTemp.Location = New System.Drawing.Point(320, 288)
        Me.ebFecUltTemp.Name = "ebFecUltTemp"
        Me.ebFecUltTemp.ReadOnly = True
        Me.ebFecUltTemp.Size = New System.Drawing.Size(96, 22)
        Me.ebFecUltTemp.TabIndex = 15
        Me.ebFecUltTemp.TabStop = False
        Me.ebFecUltTemp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFecUltTemp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(49, 272)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 23)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Color T:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(49, 248)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 23)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Color S:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(49, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 23)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Color P:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(242, 320)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 12)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Ult. Temp."
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(241, 296)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 23)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Ult. Temp."
        '
        'ebStatus
        '
        Me.ebStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebStatus.AutoSize = False
        Me.ebStatus.BackColor = System.Drawing.Color.Ivory
        Me.ebStatus.ButtonImage = CType(resources.GetObject("ebStatus.ButtonImage"), System.Drawing.Image)
        Me.ebStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebStatus.Location = New System.Drawing.Point(320, 168)
        Me.ebStatus.Name = "ebStatus"
        Me.ebStatus.ReadOnly = True
        Me.ebStatus.Size = New System.Drawing.Size(96, 22)
        Me.ebStatus.TabIndex = 14
        Me.ebStatus.TabStop = False
        Me.ebStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMarca
        '
        Me.ebMarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMarca.AutoSize = False
        Me.ebMarca.BackColor = System.Drawing.Color.Ivory
        Me.ebMarca.ButtonImage = CType(resources.GetObject("ebMarca.ButtonImage"), System.Drawing.Image)
        Me.ebMarca.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMarca.Location = New System.Drawing.Point(136, 192)
        Me.ebMarca.Name = "ebMarca"
        Me.ebMarca.ReadOnly = True
        Me.ebMarca.Size = New System.Drawing.Size(96, 22)
        Me.ebMarca.TabIndex = 6
        Me.ebMarca.TabStop = False
        Me.ebMarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebUso
        '
        Me.ebUso.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebUso.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebUso.AutoSize = False
        Me.ebUso.BackColor = System.Drawing.Color.Ivory
        Me.ebUso.ButtonImage = CType(resources.GetObject("ebUso.ButtonImage"), System.Drawing.Image)
        Me.ebUso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUso.Location = New System.Drawing.Point(136, 168)
        Me.ebUso.Name = "ebUso"
        Me.ebUso.ReadOnly = True
        Me.ebUso.Size = New System.Drawing.Size(96, 22)
        Me.ebUso.TabIndex = 5
        Me.ebUso.TabStop = False
        Me.ebUso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFamilia
        '
        Me.ebFamilia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFamilia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFamilia.AutoSize = False
        Me.ebFamilia.BackColor = System.Drawing.Color.Ivory
        Me.ebFamilia.ButtonImage = CType(resources.GetObject("ebFamilia.ButtonImage"), System.Drawing.Image)
        Me.ebFamilia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFamilia.Location = New System.Drawing.Point(136, 121)
        Me.ebFamilia.Name = "ebFamilia"
        Me.ebFamilia.ReadOnly = True
        Me.ebFamilia.Size = New System.Drawing.Size(96, 22)
        Me.ebFamilia.TabIndex = 3
        Me.ebFamilia.TabStop = False
        Me.ebFamilia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFamilia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebLinea
        '
        Me.ebLinea.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebLinea.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebLinea.AutoSize = False
        Me.ebLinea.BackColor = System.Drawing.Color.Ivory
        Me.ebLinea.ButtonImage = CType(resources.GetObject("ebLinea.ButtonImage"), System.Drawing.Image)
        Me.ebLinea.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebLinea.Location = New System.Drawing.Point(136, 144)
        Me.ebLinea.Name = "ebLinea"
        Me.ebLinea.ReadOnly = True
        Me.ebLinea.Size = New System.Drawing.Size(96, 22)
        Me.ebLinea.TabIndex = 4
        Me.ebLinea.TabStop = False
        Me.ebLinea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLinea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCategoria
        '
        Me.ebCategoria.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCategoria.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCategoria.AutoSize = False
        Me.ebCategoria.BackColor = System.Drawing.Color.Ivory
        Me.ebCategoria.ButtonImage = CType(resources.GetObject("ebCategoria.ButtonImage"), System.Drawing.Image)
        Me.ebCategoria.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCategoria.Location = New System.Drawing.Point(320, 144)
        Me.ebCategoria.Name = "ebCategoria"
        Me.ebCategoria.ReadOnly = True
        Me.ebCategoria.Size = New System.Drawing.Size(96, 22)
        Me.ebCategoria.TabIndex = 13
        Me.ebCategoria.TabStop = False
        Me.ebCategoria.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCategoria.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCorrida
        '
        Me.ebCorrida.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCorrida.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCorrida.AutoSize = False
        Me.ebCorrida.BackColor = System.Drawing.Color.Ivory
        Me.ebCorrida.ButtonImage = CType(resources.GetObject("ebCorrida.ButtonImage"), System.Drawing.Image)
        Me.ebCorrida.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCorrida.Location = New System.Drawing.Point(320, 120)
        Me.ebCorrida.Name = "ebCorrida"
        Me.ebCorrida.ReadOnly = True
        Me.ebCorrida.Size = New System.Drawing.Size(96, 22)
        Me.ebCorrida.TabIndex = 12
        Me.ebCorrida.TabStop = False
        Me.ebCorrida.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorrida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPublicacion
        '
        Me.ebPublicacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPublicacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPublicacion.AutoSize = False
        Me.ebPublicacion.BackColor = System.Drawing.Color.Ivory
        Me.ebPublicacion.ButtonImage = CType(resources.GetObject("ebPublicacion.ButtonImage"), System.Drawing.Image)
        Me.ebPublicacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPublicacion.Location = New System.Drawing.Point(136, 312)
        Me.ebPublicacion.Name = "ebPublicacion"
        Me.ebPublicacion.ReadOnly = True
        Me.ebPublicacion.Size = New System.Drawing.Size(96, 22)
        Me.ebPublicacion.TabIndex = 11
        Me.ebPublicacion.TabStop = False
        Me.ebPublicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPublicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(240, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 23)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Status:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(49, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 23)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Marca:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(49, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 23)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Uso:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(49, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 23)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Familia:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(49, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 23)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Linea:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(240, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Categoria:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(240, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Corrida:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 320)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cat. DP:"
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoSize = False
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(136, 84)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(296, 22)
        Me.ebDescripcion.TabIndex = 2
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(48, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Descripcion:"
        '
        'ebCodNumTemporada
        '
        Me.ebCodNumTemporada.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodNumTemporada.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodNumTemporada.AutoSize = False
        Me.ebCodNumTemporada.BackColor = System.Drawing.Color.Ivory
        Me.ebCodNumTemporada.ButtonImage = CType(resources.GetObject("ebCodNumTemporada.ButtonImage"), System.Drawing.Image)
        Me.ebCodNumTemporada.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodNumTemporada.Location = New System.Drawing.Point(136, 288)
        Me.ebCodNumTemporada.Name = "ebCodNumTemporada"
        Me.ebCodNumTemporada.ReadOnly = True
        Me.ebCodNumTemporada.Size = New System.Drawing.Size(96, 22)
        Me.ebCodNumTemporada.TabIndex = 10
        Me.ebCodNumTemporada.TabStop = False
        Me.ebCodNumTemporada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodNumTemporada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Temporada:"
        '
        'ebCodigoPro
        '
        Me.ebCodigoPro.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoPro.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoPro.AutoSize = False
        Me.ebCodigoPro.BackColor = System.Drawing.Color.Ivory
        Me.ebCodigoPro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoPro.Location = New System.Drawing.Point(136, 59)
        Me.ebCodigoPro.Name = "ebCodigoPro"
        Me.ebCodigoPro.ReadOnly = True
        Me.ebCodigoPro.Size = New System.Drawing.Size(232, 22)
        Me.ebCodigoPro.TabIndex = 1
        Me.ebCodigoPro.TabStop = False
        Me.ebCodigoPro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(48, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CodigoPRO:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(48, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CodigoDP:"
        '
        'ebCodigoDP
        '
        Me.ebCodigoDP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoDP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoDP.AutoSize = False
        Me.ebCodigoDP.ButtonImage = CType(resources.GetObject("ebCodigoDP.ButtonImage"), System.Drawing.Image)
        Me.ebCodigoDP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigoDP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodigoDP.Location = New System.Drawing.Point(136, 34)
        Me.ebCodigoDP.MaxLength = 20
        Me.ebCodigoDP.Name = "ebCodigoDP"
        Me.ebCodigoDP.Size = New System.Drawing.Size(232, 22)
        Me.ebCodigoDP.TabIndex = 0
        Me.ebCodigoDP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoDP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.ExplorerBar5)
        Me.UiTabPage2.Controls.Add(Me.ExplorerBar4)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 22)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(830, 580)
        Me.UiTabPage2.TabIndex = 1
        Me.UiTabPage2.Text = "Datos Alternativos y Adicionales"
        '
        'ExplorerBar5
        '
        Me.ExplorerBar5.Controls.Add(Me.imAdi3)
        Me.ExplorerBar5.Controls.Add(Me.imAdi2)
        Me.ExplorerBar5.Controls.Add(Me.imAdi1)
        Me.ExplorerBar5.Controls.Add(Me.ebAdi3)
        Me.ExplorerBar5.Controls.Add(Me.Label36)
        Me.ExplorerBar5.Controls.Add(Me.ebAdi2)
        Me.ExplorerBar5.Controls.Add(Me.Label37)
        Me.ExplorerBar5.Controls.Add(Me.ebAdi1)
        Me.ExplorerBar5.Controls.Add(Me.Label38)
        Me.ExplorerBar5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Image = CType(resources.GetObject("ExplorerBarGroup4.Image"), System.Drawing.Image)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Articulos Adicionales"
        Me.ExplorerBar5.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.ExplorerBar5.Location = New System.Drawing.Point(0, 288)
        Me.ExplorerBar5.Name = "ExplorerBar5"
        Me.ExplorerBar5.Size = New System.Drawing.Size(832, 296)
        Me.ExplorerBar5.TabIndex = 1
        Me.ExplorerBar5.Text = "ExplorerBar5"
        Me.ExplorerBar5.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'imAdi3
        '
        Me.imAdi3.BackColor = System.Drawing.Color.Transparent
        Me.imAdi3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAdi3.Location = New System.Drawing.Point(552, 63)
        Me.imAdi3.Name = "imAdi3"
        Me.imAdi3.Size = New System.Drawing.Size(240, 220)
        Me.imAdi3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAdi3.TabIndex = 67
        Me.imAdi3.TabStop = False
        '
        'imAdi2
        '
        Me.imAdi2.BackColor = System.Drawing.Color.Transparent
        Me.imAdi2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAdi2.Location = New System.Drawing.Point(288, 63)
        Me.imAdi2.Name = "imAdi2"
        Me.imAdi2.Size = New System.Drawing.Size(240, 220)
        Me.imAdi2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAdi2.TabIndex = 66
        Me.imAdi2.TabStop = False
        '
        'imAdi1
        '
        Me.imAdi1.BackColor = System.Drawing.Color.Transparent
        Me.imAdi1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAdi1.Location = New System.Drawing.Point(24, 63)
        Me.imAdi1.Name = "imAdi1"
        Me.imAdi1.Size = New System.Drawing.Size(240, 220)
        Me.imAdi1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAdi1.TabIndex = 65
        Me.imAdi1.TabStop = False
        '
        'ebAdi3
        '
        Me.ebAdi3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdi3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdi3.BackColor = System.Drawing.Color.Ivory
        Me.ebAdi3.ButtonImage = CType(resources.GetObject("ebAdi3.ButtonImage"), System.Drawing.Image)
        Me.ebAdi3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdi3.Location = New System.Drawing.Point(632, 36)
        Me.ebAdi3.Name = "ebAdi3"
        Me.ebAdi3.ReadOnly = True
        Me.ebAdi3.Size = New System.Drawing.Size(159, 21)
        Me.ebAdi3.TabIndex = 5
        Me.ebAdi3.TabStop = False
        Me.ebAdi3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdi3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(550, 39)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 23)
        Me.Label36.TabIndex = 63
        Me.Label36.Text = "Adicional 3:"
        '
        'ebAdi2
        '
        Me.ebAdi2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdi2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdi2.BackColor = System.Drawing.Color.Ivory
        Me.ebAdi2.ButtonImage = CType(resources.GetObject("ebAdi2.ButtonImage"), System.Drawing.Image)
        Me.ebAdi2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdi2.Location = New System.Drawing.Point(369, 36)
        Me.ebAdi2.Name = "ebAdi2"
        Me.ebAdi2.ReadOnly = True
        Me.ebAdi2.Size = New System.Drawing.Size(159, 21)
        Me.ebAdi2.TabIndex = 4
        Me.ebAdi2.TabStop = False
        Me.ebAdi2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdi2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(287, 39)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(76, 23)
        Me.Label37.TabIndex = 60
        Me.Label37.Text = "Adicional 2:"
        '
        'ebAdi1
        '
        Me.ebAdi1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdi1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdi1.BackColor = System.Drawing.Color.Ivory
        Me.ebAdi1.ButtonImage = CType(resources.GetObject("ebAdi1.ButtonImage"), System.Drawing.Image)
        Me.ebAdi1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdi1.Location = New System.Drawing.Point(97, 36)
        Me.ebAdi1.Name = "ebAdi1"
        Me.ebAdi1.ReadOnly = True
        Me.ebAdi1.Size = New System.Drawing.Size(159, 21)
        Me.ebAdi1.TabIndex = 3
        Me.ebAdi1.TabStop = False
        Me.ebAdi1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdi1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(24, 39)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(76, 23)
        Me.Label38.TabIndex = 57
        Me.Label38.Text = "Adicional 1:"
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.Controls.Add(Me.imAlter3)
        Me.ExplorerBar4.Controls.Add(Me.imAlter2)
        Me.ExplorerBar4.Controls.Add(Me.imAlter1)
        Me.ExplorerBar4.Controls.Add(Me.UiButton19)
        Me.ExplorerBar4.Controls.Add(Me.ebAlter3)
        Me.ExplorerBar4.Controls.Add(Me.Label35)
        Me.ExplorerBar4.Controls.Add(Me.ebAlter2)
        Me.ExplorerBar4.Controls.Add(Me.Label34)
        Me.ExplorerBar4.Controls.Add(Me.ebAlter1)
        Me.ExplorerBar4.Controls.Add(Me.Label33)
        Me.ExplorerBar4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup5.Expandable = False
        ExplorerBarGroup5.Image = CType(resources.GetObject("ExplorerBarGroup5.Image"), System.Drawing.Image)
        ExplorerBarGroup5.Key = "Group1"
        ExplorerBarGroup5.Text = "Articulos Alternativos"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup5})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(832, 296)
        Me.ExplorerBar4.TabIndex = 0
        Me.ExplorerBar4.Text = "ExplorerBar4"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'imAlter3
        '
        Me.imAlter3.BackColor = System.Drawing.Color.Transparent
        Me.imAlter3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAlter3.Location = New System.Drawing.Point(552, 62)
        Me.imAlter3.Name = "imAlter3"
        Me.imAlter3.Size = New System.Drawing.Size(240, 220)
        Me.imAlter3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAlter3.TabIndex = 45
        Me.imAlter3.TabStop = False
        '
        'imAlter2
        '
        Me.imAlter2.BackColor = System.Drawing.Color.Transparent
        Me.imAlter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAlter2.Location = New System.Drawing.Point(288, 62)
        Me.imAlter2.Name = "imAlter2"
        Me.imAlter2.Size = New System.Drawing.Size(240, 220)
        Me.imAlter2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAlter2.TabIndex = 44
        Me.imAlter2.TabStop = False
        '
        'imAlter1
        '
        Me.imAlter1.BackColor = System.Drawing.Color.Transparent
        Me.imAlter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imAlter1.Location = New System.Drawing.Point(24, 62)
        Me.imAlter1.Name = "imAlter1"
        Me.imAlter1.Size = New System.Drawing.Size(240, 220)
        Me.imAlter1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imAlter1.TabIndex = 43
        Me.imAlter1.TabStop = False
        '
        'UiButton19
        '
        Me.UiButton19.Image = CType(resources.GetObject("UiButton19.Image"), System.Drawing.Image)
        Me.UiButton19.Location = New System.Drawing.Point(920, 48)
        Me.UiButton19.Name = "UiButton19"
        Me.UiButton19.Size = New System.Drawing.Size(24, 24)
        Me.UiButton19.TabIndex = 41
        '
        'ebAlter3
        '
        Me.ebAlter3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlter3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlter3.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter3.ButtonImage = CType(resources.GetObject("ebAlter3.ButtonImage"), System.Drawing.Image)
        Me.ebAlter3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter3.Location = New System.Drawing.Point(632, 35)
        Me.ebAlter3.Name = "ebAlter3"
        Me.ebAlter3.ReadOnly = True
        Me.ebAlter3.Size = New System.Drawing.Size(159, 21)
        Me.ebAlter3.TabIndex = 2
        Me.ebAlter3.TabStop = False
        Me.ebAlter3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlter3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(547, 38)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(88, 23)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "Alternativo 3:"
        '
        'ebAlter2
        '
        Me.ebAlter2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlter2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlter2.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter2.ButtonImage = CType(resources.GetObject("ebAlter2.ButtonImage"), System.Drawing.Image)
        Me.ebAlter2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter2.Location = New System.Drawing.Point(368, 35)
        Me.ebAlter2.Name = "ebAlter2"
        Me.ebAlter2.ReadOnly = True
        Me.ebAlter2.Size = New System.Drawing.Size(159, 21)
        Me.ebAlter2.TabIndex = 1
        Me.ebAlter2.TabStop = False
        Me.ebAlter2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlter2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(286, 38)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 23)
        Me.Label34.TabIndex = 36
        Me.Label34.Text = "Alternativo 2:"
        '
        'ebAlter1
        '
        Me.ebAlter1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAlter1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAlter1.BackColor = System.Drawing.Color.Ivory
        Me.ebAlter1.ButtonImage = CType(resources.GetObject("ebAlter1.ButtonImage"), System.Drawing.Image)
        Me.ebAlter1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAlter1.Location = New System.Drawing.Point(105, 35)
        Me.ebAlter1.Name = "ebAlter1"
        Me.ebAlter1.ReadOnly = True
        Me.ebAlter1.Size = New System.Drawing.Size(159, 21)
        Me.ebAlter1.TabIndex = 0
        Me.ebAlter1.TabStop = False
        Me.ebAlter1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAlter1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(25, 38)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 23)
        Me.Label33.TabIndex = 33
        Me.Label33.Text = "Alternativo 1:"
        '
        'imageList1
        '
        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'menuBarNuevo2
        '
        Me.menuBarNuevo2.Key = "menuBarNuevo"
        Me.menuBarNuevo2.Name = "menuBarNuevo2"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuCatalogoCategorias
        '
        Me.menuCatalogoCategorias.Key = "menuCatalogoCategorias"
        Me.menuCatalogoCategorias.Name = "menuCatalogoCategorias"
        Me.menuCatalogoCategorias.Text = "Cate&gorias"
        '
        'menuCatalogoFamilias
        '
        Me.menuCatalogoFamilias.Key = "menuCatalogoFamilias"
        Me.menuCatalogoFamilias.Name = "menuCatalogoFamilias"
        Me.menuCatalogoFamilias.Text = "&Familias"
        '
        'menuCatalogoMarcas
        '
        Me.menuCatalogoMarcas.Key = "menuCatalogoMarcas"
        Me.menuCatalogoMarcas.Name = "menuCatalogoMarcas"
        Me.menuCatalogoMarcas.Text = "Marcas"
        '
        'menuCatalogoPublicaciones
        '
        Me.menuCatalogoPublicaciones.Key = "menuCatalogoPublicaciones"
        Me.menuCatalogoPublicaciones.Name = "menuCatalogoPublicaciones"
        Me.menuCatalogoPublicaciones.Text = "Publicaciones"
        '
        'menuCatalogoTipoMoneda
        '
        Me.menuCatalogoTipoMoneda.Key = "menuCatalogoTipoMoneda"
        Me.menuCatalogoTipoMoneda.Name = "menuCatalogoTipoMoneda"
        Me.menuCatalogoTipoMoneda.Text = "Tipo Moneda"
        '
        'menuCatalogoUsos
        '
        Me.menuCatalogoUsos.Key = "menuCatalogoUsos"
        Me.menuCatalogoUsos.Name = "menuCatalogoUsos"
        Me.menuCatalogoUsos.Text = "Usos"
        '
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "Acerca de..."
        '
        'menuBarAyuda
        '
        Me.menuBarAyuda.Key = "menuBarAyuda"
        Me.menuBarAyuda.Name = "menuBarAyuda"
        Me.menuBarAyuda.Text = "Ayuda    "
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuAyudaAcerca1
        '
        Me.menuAyudaAcerca1.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca1.Name = "menuAyudaAcerca1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuBarAyuda1
        '
        Me.menuBarAyuda1.Image = CType(resources.GetObject("menuBarAyuda1.Image"), System.Drawing.Image)
        Me.menuBarAyuda1.Key = "menuBarAyuda"
        Me.menuBarAyuda1.Name = "menuBarAyuda1"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalago, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoGuardar, Me.menuCatalogoCategoria, Me.menuCatalogoCorrida, Me.menuCatalogoFamilia, Me.menuCatalogoLineas, Me.menuCatalogoMarcas2, Me.menuCatalogoProveedores, Me.menuCatalogoPublicaciones2, Me.menuCatalogoTemporada, Me.menuCatalogoMoneda, Me.menuCatalogoUnidades, Me.menuCatalogoUsos2, Me.menuAyudaTema, Me.menuAyudaAcerca2, Me.menuArchivoImprimir, Me.menuArchivoSalir, Me.menuAbrir})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("e388bf80-1e77-439d-b162-5b8af6a325f2")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.TabIndex = 0
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuArchivoSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(832, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir2, Me.Separator8, Me.menuArchivoImprimir2, Me.Separator10, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(189, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuArchivoImprimir2
        '
        Me.menuArchivoImprimir2.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir2.Name = "menuArchivoImprimir2"
        Me.menuArchivoImprimir2.Text = "&Imprimir"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        Me.menuAyudaTema2.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator6, Me.menuArchivoImprimir1, Me.Separator5})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuArchivoImprimir1
        '
        Me.menuArchivoImprimir1.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir1.Name = "menuArchivoImprimir1"
        Me.menuArchivoImprimir1.Text = "Imprimir"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuCatalago
        '
        Me.menuCatalago.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuCatalogoCategoria1, Me.menuCatalogoCorrida1, Me.menuCatalogoFamilia1, Me.menuCatalogoLineas1, Me.menuCatalogoMarcas3, Me.menuCatalogoProveedores1, Me.menuCatalogoPublicaciones3, Me.menuCatalogoTemporada1, Me.menuCatalogoMoneda1, Me.menuCatalogoUnidades1, Me.menuCatalogoUsos3})
        Me.menuCatalago.Key = "menuCatalago"
        Me.menuCatalago.Name = "menuCatalago"
        Me.menuCatalago.Text = "&Catalogo"
        '
        'menuCatalogoCategoria1
        '
        Me.menuCatalogoCategoria1.Key = "menuCatalogoCategoria"
        Me.menuCatalogoCategoria1.Name = "menuCatalogoCategoria1"
        '
        'menuCatalogoCorrida1
        '
        Me.menuCatalogoCorrida1.Key = "menuCatalogoCorrida"
        Me.menuCatalogoCorrida1.Name = "menuCatalogoCorrida1"
        '
        'menuCatalogoFamilia1
        '
        Me.menuCatalogoFamilia1.Key = "menuCatalogoFamilia"
        Me.menuCatalogoFamilia1.Name = "menuCatalogoFamilia1"
        '
        'menuCatalogoLineas1
        '
        Me.menuCatalogoLineas1.Key = "menuCatalogoLineas"
        Me.menuCatalogoLineas1.Name = "menuCatalogoLineas1"
        '
        'menuCatalogoMarcas3
        '
        Me.menuCatalogoMarcas3.Key = "menuCatalogoMarcas"
        Me.menuCatalogoMarcas3.Name = "menuCatalogoMarcas3"
        '
        'menuCatalogoProveedores1
        '
        Me.menuCatalogoProveedores1.Key = "menuCatalogoProveedores"
        Me.menuCatalogoProveedores1.Name = "menuCatalogoProveedores1"
        '
        'menuCatalogoPublicaciones3
        '
        Me.menuCatalogoPublicaciones3.Key = "menuCatalogoPublicaciones"
        Me.menuCatalogoPublicaciones3.Name = "menuCatalogoPublicaciones3"
        '
        'menuCatalogoTemporada1
        '
        Me.menuCatalogoTemporada1.Key = "menuCatalogoTemporada"
        Me.menuCatalogoTemporada1.Name = "menuCatalogoTemporada1"
        '
        'menuCatalogoMoneda1
        '
        Me.menuCatalogoMoneda1.Key = "menuCatalogoMoneda"
        Me.menuCatalogoMoneda1.Name = "menuCatalogoMoneda1"
        '
        'menuCatalogoUnidades1
        '
        Me.menuCatalogoUnidades1.Key = "menuCatalogoUnidades"
        Me.menuCatalogoUnidades1.Name = "menuCatalogoUnidades1"
        '
        'menuCatalogoUsos3
        '
        Me.menuCatalogoUsos3.Key = "menuCatalogoUsos"
        Me.menuCatalogoUsos3.Name = "menuCatalogoUsos3"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1, Me.Separator7, Me.menuAyudaAcerca3})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "&Temas de Ayuda"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuAyudaAcerca3
        '
        Me.menuAyudaAcerca3.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca3.Name = "menuAyudaAcerca3"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuCatalogoCategoria
        '
        Me.menuCatalogoCategoria.Image = CType(resources.GetObject("menuCatalogoCategoria.Image"), System.Drawing.Image)
        Me.menuCatalogoCategoria.Key = "menuCatalogoCategoria"
        Me.menuCatalogoCategoria.Name = "menuCatalogoCategoria"
        Me.menuCatalogoCategoria.Text = "Ca&tegorias"
        '
        'menuCatalogoCorrida
        '
        Me.menuCatalogoCorrida.Image = CType(resources.GetObject("menuCatalogoCorrida.Image"), System.Drawing.Image)
        Me.menuCatalogoCorrida.Key = "menuCatalogoCorrida"
        Me.menuCatalogoCorrida.Name = "menuCatalogoCorrida"
        Me.menuCatalogoCorrida.Text = "C&orridas"
        '
        'menuCatalogoFamilia
        '
        Me.menuCatalogoFamilia.Image = CType(resources.GetObject("menuCatalogoFamilia.Image"), System.Drawing.Image)
        Me.menuCatalogoFamilia.Key = "menuCatalogoFamilia"
        Me.menuCatalogoFamilia.Name = "menuCatalogoFamilia"
        Me.menuCatalogoFamilia.Text = "&Familia"
        '
        'menuCatalogoLineas
        '
        Me.menuCatalogoLineas.Image = CType(resources.GetObject("menuCatalogoLineas.Image"), System.Drawing.Image)
        Me.menuCatalogoLineas.Key = "menuCatalogoLineas"
        Me.menuCatalogoLineas.Name = "menuCatalogoLineas"
        Me.menuCatalogoLineas.Text = "&Lineas"
        '
        'menuCatalogoMarcas2
        '
        Me.menuCatalogoMarcas2.Image = CType(resources.GetObject("menuCatalogoMarcas2.Image"), System.Drawing.Image)
        Me.menuCatalogoMarcas2.Key = "menuCatalogoMarcas"
        Me.menuCatalogoMarcas2.Name = "menuCatalogoMarcas2"
        Me.menuCatalogoMarcas2.Text = "&Marcas"
        '
        'menuCatalogoProveedores
        '
        Me.menuCatalogoProveedores.Image = CType(resources.GetObject("menuCatalogoProveedores.Image"), System.Drawing.Image)
        Me.menuCatalogoProveedores.Key = "menuCatalogoProveedores"
        Me.menuCatalogoProveedores.Name = "menuCatalogoProveedores"
        Me.menuCatalogoProveedores.Text = "P&roveedores"
        '
        'menuCatalogoPublicaciones2
        '
        Me.menuCatalogoPublicaciones2.Image = CType(resources.GetObject("menuCatalogoPublicaciones2.Image"), System.Drawing.Image)
        Me.menuCatalogoPublicaciones2.Key = "menuCatalogoPublicaciones"
        Me.menuCatalogoPublicaciones2.Name = "menuCatalogoPublicaciones2"
        Me.menuCatalogoPublicaciones2.Text = "&Publicaciones"
        '
        'menuCatalogoTemporada
        '
        Me.menuCatalogoTemporada.Image = CType(resources.GetObject("menuCatalogoTemporada.Image"), System.Drawing.Image)
        Me.menuCatalogoTemporada.Key = "menuCatalogoTemporada"
        Me.menuCatalogoTemporada.Name = "menuCatalogoTemporada"
        Me.menuCatalogoTemporada.Text = "&Temporadas"
        '
        'menuCatalogoMoneda
        '
        Me.menuCatalogoMoneda.Image = CType(resources.GetObject("menuCatalogoMoneda.Image"), System.Drawing.Image)
        Me.menuCatalogoMoneda.Key = "menuCatalogoMoneda"
        Me.menuCatalogoMoneda.Name = "menuCatalogoMoneda"
        Me.menuCatalogoMoneda.Text = "Mon&eda"
        '
        'menuCatalogoUnidades
        '
        Me.menuCatalogoUnidades.Image = CType(resources.GetObject("menuCatalogoUnidades.Image"), System.Drawing.Image)
        Me.menuCatalogoUnidades.Key = "menuCatalogoUnidades"
        Me.menuCatalogoUnidades.Name = "menuCatalogoUnidades"
        Me.menuCatalogoUnidades.Text = "Un&idades"
        '
        'menuCatalogoUsos2
        '
        Me.menuCatalogoUsos2.Image = CType(resources.GetObject("menuCatalogoUsos2.Image"), System.Drawing.Image)
        Me.menuCatalogoUsos2.Key = "menuCatalogoUsos"
        Me.menuCatalogoUsos2.Name = "menuCatalogoUsos2"
        Me.menuCatalogoUsos2.Text = "&Usos"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Tema&s de Ayuda"
        '
        'menuAyudaAcerca2
        '
        Me.menuAyudaAcerca2.Image = CType(resources.GetObject("menuAyudaAcerca2.Image"), System.Drawing.Image)
        Me.menuAyudaAcerca2.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca2.Name = "menuAyudaAcerca2"
        Me.menuAyudaAcerca2.Text = "Acerca de..."
        '
        'menuArchivoImprimir
        '
        Me.menuArchivoImprimir.AllowFloatingChildren = Janus.Windows.UI.InheritableBoolean.False
        Me.menuArchivoImprimir.Checked = Janus.Windows.UI.InheritableBoolean.False
        Me.menuArchivoImprimir.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuArchivoImprimir.ControlWidth = 100
        Me.menuArchivoImprimir.Image = CType(resources.GetObject("menuArchivoImprimir.Image"), System.Drawing.Image)
        Me.menuArchivoImprimir.Key = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Name = "menuArchivoImprimir"
        Me.menuArchivoImprimir.Text = "&Imprimir"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.TabIndex = 0
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.TabIndex = 0
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(832, 50)
        Me.TopRebar1.TabIndex = 2
        '
        'CatalogoArticulosForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 653)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CatalogoArticulosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Artículos"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.NicePanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.ExplorerBar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar5.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitializeObjects()

        oCatalogoArticuloMgr = New CatalogoArticuloManager(oAppContext)

        oArticulo = oCatalogoArticuloMgr.Create

    End Sub

    Private Sub ebCodigoDP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoDP.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                LoadSearchForm()

            Case Keys.Enter

                If (ebCodigoDP.Text = String.Empty) Then

                    LoadSearchForm()

                Else

                    ebCodigoDP.Text = LoadCodigo(ebCodigoDP.Text)

                    If ebCodigoDP.Text <> String.Empty Then

                        oArticulo = oCatalogoArticuloMgr.Load(ebCodigoDP.Text)

                        If Not (oArticulo Is Nothing) Then

                            MuestraCampos()

                        Else

                            MsgBox("Código de Artículo NO EXISTE", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Información")
                            LimpiaCampos()

                        End If

                        ebCodigoDP.Focus()
                        ebCodigoDP.SelectAll()

                    End If

                    ''Cargamos el Articulo
                    '''''''''
                    'Dim oCatalogoUPCMgr As CatalogoUPCManager
                    'Dim oUPC As UPC
                    'oCatalogoUPCMgr = New CatalogoUPCManager(oAppContext)
                    'On Error Resume Next

                    'oUPC = Nothing
                    'oUPC = oCatalogoUPCMgr.Load(ebCodigoDP.Text.Trim)
                    'If oUPC.IsDirty Then

                    'Else
                    '    ebCodigoDP.Text = oUPC.CodArticulo
                    'End If

                    '''''''''

                End If

        End Select

    End Sub

    Private Function LoadCodigo(ByVal strCodigo As String) As String

        Dim strResult As String = String.Empty

        If IsNumeric(strCodigo) Then
            'Buscamos Codigo UPC
            Dim oUPCMgr As CatalogoUPCManager = New CatalogoUPCManager(oAppContext, oConfigCierreFI)
            Dim oUPC As UPC
            oUPC = oUPCMgr.Create

            oUPC = oUPCMgr.Load(strCodigo)

            If oUPC.CodArticulo <> String.Empty Then

                strResult = oUPC.CodArticulo

            Else

                MsgBox("Código UPC No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Consulta Existencias")
                strResult = String.Empty

            End If

            oUPCMgr.dispose()
            oUPCMgr = Nothing
            oUPC = Nothing

        Else

            'Verificamos si tiene talla
            If IsNumeric(Microsoft.VisualBasic.Left(Trim(strCodigo), 2)) Then

                strResult = Microsoft.VisualBasic.Right((strCodigo), Len(Trim(strCodigo)) - 2)

            Else

                strResult = strCodigo

            End If

        End If

        Return strResult

    End Function

    Private Sub ebCodigoDP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigoDP.ButtonClick

        LoadSearchForm()
        ebCodigoDP.Focus()
        ebCodigoDP.SelectAll()

    End Sub

    Private Sub LimpiaCampos()

        'Limpiamos campos del formulario
        ebCodigoDP.Text = ""
        ebCodigoPro.Text = ""
        ebDescripcion.Text = ""
        ebCodNumTemporada.Text = ""
        ebPublicacion.Text = ""
        ebCorrida.Text = ""
        ebCategoria.Text = ""
        ebLinea.Text = ""
        ebFamilia.Text = ""
        ebUso.Text = ""
        ebMarca.Text = ""
        ebStatus.Text = ""
        ebFecUltTemp.Text = ""
        ebFecUltTempDip.Text = ""
        ebColor1.Text = ""
        ebColor2.Text = ""
        ebColor3.Text = ""
        chkPrecio.Checked = False
        chkImportado.Checked = False
        chkOrdenable.Checked = False
        chkDIP.Checked = False
        ebCostoProm.Text = ""
        ebMargen.Text = ""
        ebPrecio.Text = ""
        ebDescuento.Text = ""
        ebPrecioOferta.Text = ""
        ebFecOferta.Text = ""
        ebFUO.Text = ""
        ebFUC.Text = ""
        ebProveedor1.Text = ""
        ebProveedor2.Text = ""
        ebUnidadCom.Text = ""
        ebUnidadVta.Text = ""
        ebNameProv1.Text = ""
        ebNameProv2.Text = ""
        ebMonedaCom.Text = ""
        ebMonedaVen.Text = ""
        ebAlter1.Text = ""
        ebAlter2.Text = ""
        ebAlter3.Text = ""
        ebAdi1.Text = ""
        ebAdi2.Text = ""
        ebAdi3.Text = ""
        imArticulo.Image = Nothing
        imAlter1.Image = Nothing
        imAlter2.Image = Nothing
        imAlter3.Image = Nothing
        imAdi1.Image = Nothing
        imAdi2.Image = Nothing
        imAdi3.Image = Nothing


        Me.ebCodigoDP.Focus()

    End Sub

    Private Sub CatalogoArticulosForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        If (iInitial = True) Then

            'Limpiamos cajas de texto
            LimpiaCampos()
            iInitial = False

        End If

    End Sub

    Private Sub CatalogoArticulosForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()
        iInitial = True

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoSalir"
                Me.Close()

            Case "menuAbrir"
                LoadSearchForm()
                ebCodigoDP.Focus()
                ebCodigoDP.SelectAll()

            Case "menuCatalogoCategoria"
                Dim oCategoriasForm As New CatalogoCategoriasForm
                oCategoriasForm.ShowDialog()
                oCategoriasForm.Dispose()

            Case "menuCatalogoCorrida"
                Dim oCorridasForm As New frmCorridas
                oCorridasForm.ShowDialog()
                oCorridasForm.Dispose()

            Case "menuCatalogoFamilia"
                Dim oFamiliasForm As New CatalogoFamiliasForm
                oFamiliasForm.ShowDialog()
                oFamiliasForm.Dispose()

            Case "menuCatalogoLineas"
                Dim oLineasForm As New CatalogoLineasForm
                oLineasForm.ShowDialog()
                oLineasForm.Dispose()

            Case "menuCatalogoMarcas"
                Dim oMarcasForm As New CatalogoMarcasForm
                oMarcasForm.ShowDialog()
                oMarcasForm.Dispose()

            Case "menuCatalogoPublicaciones"
                Dim oPublicacionesForm As New frmPublicaciones
                oPublicacionesForm.ShowDialog()
                oPublicacionesForm.Dispose()

            Case "menuCatalogoUnidades"
                Dim oUnidadesForm As New CatalogoUnidadForm
                oUnidadesForm.ShowDialog()
                oUnidadesForm.Dispose()

            Case "menuCatalogoUsos"
                Dim oUsosForm As New CatalogoUsosForm
                oUsosForm.ShowDialog()
                oUsosForm.Dispose()

            Case Else
                MsgBox("Opción no está disponible.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "Información")
                'MsgBox(e.Command.Key.ToString)

        End Select

    End Sub

    Private Sub MuestraCampos()

        LimpiaCampos()

        ebCodigoDP.Text = oArticulo.CodArticulo
        ebCodigoPro.Text = oArticulo.CodArtProv
        ebDescripcion.Text = oArticulo.Descripcion
        'ebCodNumTemporada.Text = oArticulo.CodNumTemporada
        'ebPublicacion.Text = oArticulo.CodPublicacion
        ebCorrida.Text = oArticulo.CodCorrida
        ebCategoria.Text = oArticulo.CodCategoria
        ebLinea.Text = oArticulo.Codlinea
        ebFamilia.Text = oArticulo.CodFamilia
        ebUso.Text = oArticulo.CodUso
        ebMarca.Text = oArticulo.CodMarca
        'ebStatus.Text = oArticulo.CodStatusArticulo
        'ebFecUltTemp.Text = Format(oArticulo.FecUltTemp, "dd-MM-yyyy")
        'ebFecUltTempDip.Text = Format(oArticulo.FecUltTempDip, "dd-MM-yyyy")
        'ebColor1.Text = oArticulo.Color1
        'ebColor2.Text = oArticulo.Color2
        'ebColor3.Text = oArticulo.Color3
        chkPrecio.Checked = oArticulo.ImpCodBarra
        'chkImportado.Checked = oArticulo.Importado
        'chkOrdenable.Checked = oArticulo.Ordenable
        'chkDIP.Checked = oArticulo.CatalogoDIP
        ebCostoProm.Text = Format(oArticulo.CostoProm, "$ ###,##0.00")
        ebMargen.Text = Format(oArticulo.MargenUtilidad, "###,#0.00")
        ebPrecio.Text = Format(oArticulo.PrecioVenta, " $ ###,##0.00")
        ebDescuento.Text = Format((oArticulo.Descuento) / 100, "% ##0.00")
        ebPrecioOferta.Text = Format(oArticulo.PrecioOferta, "$ ###,##0.00")
        If oArticulo.FechaOferta <> Nothing Then
            ebFecOferta.Text = Format(oArticulo.FechaOferta, "dd-MM-yyyy")
        End If
        'If oArticulo.FUO <> Nothing Then
        '    ebFUO.Text = Format(oArticulo.FUO, "dd-MM-yyyy")
        'End If
        'If oArticulo.FUC <> Nothing Then
        '    ebFUC.Text = Format(oArticulo.FUC, "dd-MM-yyyy")
        'End If
        'ebProveedor1.Text = oArticulo.CodProveedor1
        'ebProveedor2.Text = oArticulo.CodProveedor2
        ebUnidadCom.Text = oArticulo.CodUnidadCom
        ebUnidadVta.Text = oArticulo.CodUnidadVta
        ebNameProv1.Text = "Proveedor " & ebProveedor1.Text
        ebNameProv2.Text = "Proveedor " & ebProveedor2.Text
        ebMonedaCom.Text = oArticulo.CodMonedaCom
        ebMonedaVen.Text = oArticulo.CodMonedaVta
        'ebAlter1.Text = oArticulo.CodAlt1
        'ebAlter2.Text = oArticulo.CodAlt2
        'ebAlter3.Text = oArticulo.CodAlt3
        'ebAdi1.Text = oArticulo.CodAdi1
        'ebAdi2.Text = oArticulo.CodAdi2
        'ebAdi3.Text = oArticulo.CodAdi3

        'Mostramos imagen del artículo su lo tuviera
        If oArticulo.WithImage = True Then
            imArticulo.Image = Image.FromStream(oArticulo.Imagen)
        Else
            imArticulo.Image = Nothing
        End If

    End Sub

    Private Sub LoadSearchForm()

        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oArticulo = oCatalogoArticuloMgr.Load(oOpenRecordDlg.Record.Item("Código"))

            If Not (oArticulo Is Nothing) Then

                MuestraCampos()
                UiTab1.Focus()

            Else

                MsgBox("Código de Artículo NO EXISTE", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Información")

            End If

        End If

        ebCodigoDP.Focus()
        ebCodigoDP.SelectAll()

    End Sub

    Private Sub CatalogoArticulosForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
