Imports Janus.Windows.UI
Imports Janus.Windows.UI.Dock
Imports Janus.Windows.UI.CommandBars
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class MainFormAuditoria
    Inherits System.Windows.Forms.Form


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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents uiConsultas As Janus.Windows.UI.Dock.UIPanelGroup
    Friend WithEvents uiConsultasContainer As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents uiPanel0Container As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents uiPanel0 As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasMovDAuditoria As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasMovDAuditoria1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator11 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator12 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator13 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator14 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator15 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator16 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator19 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator20 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator21 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator22 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator23 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator24 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator25 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator26 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator27 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator28 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepMen As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtiExportarInfo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModFP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilPreciosDContratos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilDifEnCosto As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjuste As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilBorrarTras As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepCostoVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilLiberarCierreDia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuDesApart As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqDCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRevDApartados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnalDVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRecDExistencia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator35 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMIncongruencia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMDifHistoriInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoS As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoBSG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteS As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAuditoRet As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAnalisisInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMCostoSuc As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMCostoCodigo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMExistenciaN As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMArticulosA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMDescuentoO As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMReporteA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMReporteD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMViolacionInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMIncongruencia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMDifHistoriInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoE1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoS1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMTraspasoBSG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteE1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteS1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAuditoRet1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAnalisisInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMCostoSuc1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMCostoCodigo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMExistenciaN1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMDescuentoO1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMReporteA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMViolacionInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator36 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator37 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator38 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator39 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator40 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator41 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator42 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTS As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTE1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTS1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDS As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosSG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosOrigen As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDE1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDS1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosSG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosOrigen1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosHA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosHA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator43 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator45 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator46 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator47 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator44 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepMen1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtiExportarInfo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator30 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModFP1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilPreciosDContratos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator32 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator33 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilDifEnCosto1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjuste1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilBorrarTras1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepCostoVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilLiberarCierreDia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator34 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuDesApart1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqDCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRevDApartados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnalDVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRecDExistencia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator48 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator49 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator50 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator51 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator52 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator53 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTomadeInventario As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTomadeInventario1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator56 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator57 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator58 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqCajaFondoCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqCajaIngresoCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqCajaFondoCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator59 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqCajaIngresoCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteGeneral As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEntrada As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteSalida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteRecibidos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteGeneral1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEntrada1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteSalida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator60 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteRecibidos2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator62 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator64 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator61 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator63 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator65 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator29 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator66 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator68 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnaIMarcas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTE2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTS2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDE2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosDS2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosSG2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCanceladosOrigen2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnaIMarcas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasMovDAuditoria2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents menuUtilRepValeCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator17 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepValeCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilEFExportInfo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilEIRepExport As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilEIRepExpInfo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilEIExportInfo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiStatusBar2 As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuUtilRMAjusteE2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteS2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRMAjusteG2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator18 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTomadeInventario2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator31 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepValeCaja2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator54 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator55 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator67 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilArqDCaja2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator69 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportarGAD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportarGAD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator70 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEntradaSaida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModAjusteEntradaSaida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAnularAjusteTE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator71 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAnularAjusteTE1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator72 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCargarFolios As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCargarFolios1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuReporteCostosInventario As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuReporteCostosInventario1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFormAuditoria))
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel2 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel3 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel4 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuUtileriasMovDAuditoria2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasMovDAuditoria")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuUtilRMAjusteG2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteG")
        Me.Separator54 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMAjusteE2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteE")
        Me.Separator55 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMAjusteS2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteS")
        Me.Separator18 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilTomadeInventario2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTomadeInventario")
        Me.Separator31 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRepValeCaja2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepValeCaja")
        Me.Separator67 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilArqDCaja2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqDCaja")
        Me.Separator69 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.Separator71 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuUtileriasMovDAuditoria = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasMovDAuditoria")
        Me.menuUtilRepMen1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepMen")
        Me.menuUtiExportarInfo1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtiExportarInfo")
        Me.Separator30 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilModFP1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModFP")
        Me.menuUtilPreciosDContratos1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilPreciosDContratos")
        Me.Separator32 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilAnaIMarcas1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnaIMarcas")
        Me.Separator33 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilDifEnCosto1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilDifEnCosto")
        Me.menuUtilModAjuste1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjuste")
        Me.menuUtilBorrarTras1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilBorrarTras")
        Me.menuUtilRepCostoVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepCostoVenta")
        Me.menuUtilLiberarCierreDia1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilLiberarCierreDia")
        Me.Separator34 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuDesApart1 = New Janus.Windows.UI.CommandBars.UICommand("menuDesApart")
        Me.Separator56 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilArqDCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqDCaja")
        Me.Separator57 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilTomadeInventario1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTomadeInventario")
        Me.Separator58 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRevDApartados1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRevDApartados")
        Me.menuUtilAnalDVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnalDVenta")
        Me.menuUtilRecDExistencia1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRecDExistencia")
        Me.Separator17 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRepValeCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepValeCaja")
        Me.Separator72 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAnularAjusteTE1 = New Janus.Windows.UI.CommandBars.UICommand("menuAnularAjusteTE")
        Me.menuCargarFolios1 = New Janus.Windows.UI.CommandBars.UICommand("menuCargarFolios")
        Me.MnuReporteCostosInventario1 = New Janus.Windows.UI.CommandBars.UICommand("MnuReporteCostosInventario")
        Me.menuUtilRepMen = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepMen")
        Me.menuUtilRMIncongruencia1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMIncongruencia")
        Me.menuUtilRMDifHistoriInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMDifHistoriInv")
        Me.Separator36 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMTraspasoE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoE")
        Me.menuUtilRMTraspasoS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoS")
        Me.menuUtilRMTraspasoBSG1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoBSG")
        Me.Separator37 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMAjusteE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteE")
        Me.menuUtilRMAjusteS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteS")
        Me.menuUtilRMAjusteG1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteG")
        Me.Separator38 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMAuditoRet1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAuditoRet")
        Me.menuUtilRMAnalisisInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAnalisisInv")
        Me.Separator39 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMCostoSuc1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMCostoSuc")
        Me.menuUtilRMCostoCodigo1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMCostoCodigo")
        Me.Separator40 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMExistenciaN1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMExistenciaN")
        Me.menuUtilRMDescuentoO1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMDescuentoO")
        Me.Separator41 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMReporteA1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMReporteA")
        Me.Separator42 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRMViolacionInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMViolacionInv")
        Me.menuUtiExportarInfo = New Janus.Windows.UI.CommandBars.UICommand("menuUtiExportarInfo")
        Me.menuExportarGAD1 = New Janus.Windows.UI.CommandBars.UICommand("menuExportarGAD")
        Me.Separator70 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilEIExportInfo = New Janus.Windows.UI.CommandBars.UICommand("menuUtilEFExportInfo")
        Me.menuUtilEIRepExpInfo = New Janus.Windows.UI.CommandBars.UICommand("menuUtilEIRepExport")
        Me.menuUtilModFP = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModFP")
        Me.menuUtilPreciosDContratos = New Janus.Windows.UI.CommandBars.UICommand("menuUtilPreciosDContratos")
        Me.menuUtilAnaIMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnaIMarcas")
        Me.menuUtilDifEnCosto = New Janus.Windows.UI.CommandBars.UICommand("menuUtilDifEnCosto")
        Me.menuUtilModAjuste = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjuste")
        Me.menuUtilModAjusteGeneral1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteGeneral")
        Me.menuUtilModAjusteEntradaSaida1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEntradaSaida")
        Me.menuUtilModAjusteEntrada1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEntrada")
        Me.menuUtilModAjusteSalida1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteSalida")
        Me.Separator60 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilModAjusteEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEliminar")
        Me.menuUtilModAjusteRecibidos2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteRecibidos")
        Me.menuUtilBorrarTras = New Janus.Windows.UI.CommandBars.UICommand("menuUtilBorrarTras")
        Me.menuUtilRepCostoVenta = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepCostoVenta")
        Me.menuUtilLiberarCierreDia = New Janus.Windows.UI.CommandBars.UICommand("menuUtilLiberarCierreDia")
        Me.menuDesApart = New Janus.Windows.UI.CommandBars.UICommand("menuDesApart")
        Me.menuUtilArqDCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqDCaja")
        Me.menuUtilArqCajaFondoCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaFondoCaja")
        Me.Separator59 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilArqCajaIngresoCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaIngresoCaja")
        Me.menuUtilRevDApartados = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRevDApartados")
        Me.menuUtilAnalDVenta = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnalDVenta")
        Me.menuUtilRecDExistencia = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRecDExistencia")
        Me.menuUtilRMIncongruencia = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMIncongruencia")
        Me.menuUtilRMDifHistoriInv = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMDifHistoriInv")
        Me.menuUtilRMTraspasoE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoE")
        Me.menuUtilRMTraspasoS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoS")
        Me.menuUtilRMTraspasoBSG = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMTraspasoBSG")
        Me.menuUtilRMAjusteE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteE")
        Me.menuUtilRMAjusteS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteS")
        Me.menuUtilRMAjusteG = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAjusteG")
        Me.menuUtilRMAuditoRet = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAuditoRet")
        Me.menuUtilRMAnalisisInv = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMAnalisisInv")
        Me.menuUtilRMCostoSuc = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMCostoSuc")
        Me.menuUtilRMCostoCodigo = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMCostoCodigo")
        Me.menuUtilRMExistenciaN = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMExistenciaN")
        Me.menuUtilRMArticulosA = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMArticulosA")
        Me.menuUtilRMDescuentoO = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMDescuentoO")
        Me.menuUtilRMReporteA = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMReporteA")
        Me.menuUtilRMReporteD = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMReporteD")
        Me.menuUtilRMViolacionInv = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMViolacionInv")
        Me.menuUtilRepTraspasoTE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTE")
        Me.menuUtilRepTraspasoTS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTS")
        Me.menuUtilTrasCanceladosDE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDE")
        Me.menuUtilTrasCanceladosDS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDS")
        Me.menuUtilTrasCanceladosSG = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosSG")
        Me.menuUtilTrasCanceladosOrigen = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosOrigen")
        Me.menuInventarioMovArticulosHA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosHA")
        Me.menuUtilTomadeInventario = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTomadeInventario")
        Me.menuUtilArqCajaFondoCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaFondoCaja")
        Me.menuUtilArqCajaIngresoCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaIngresoCaja")
        Me.menuUtilModAjusteGeneral = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteGeneral")
        Me.menuUtilModAjusteEntrada = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEntrada")
        Me.menuUtilModAjusteSalida = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteSalida")
        Me.menuUtilModAjusteEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEliminar")
        Me.menuUtilModAjusteRecibidos = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteRecibidos")
        Me.menuUtilRepValeCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepValeCaja")
        Me.menuUtilEFExportInfo = New Janus.Windows.UI.CommandBars.UICommand("menuUtilEFExportInfo")
        Me.menuUtilEIRepExport = New Janus.Windows.UI.CommandBars.UICommand("menuUtilEIRepExport")
        Me.menuExportarGAD = New Janus.Windows.UI.CommandBars.UICommand("menuExportarGAD")
        Me.menuUtilModAjusteEntradaSaida = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEntradaSaida")
        Me.menuAnularAjusteTE = New Janus.Windows.UI.CommandBars.UICommand("menuAnularAjusteTE")
        Me.menuCargarFolios = New Janus.Windows.UI.CommandBars.UICommand("menuCargarFolios")
        Me.MnuReporteCostosInventario = New Janus.Windows.UI.CommandBars.UICommand("MnuReporteCostosInventario")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.Separator46 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator48 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator43 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator44 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator62 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator45 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator50 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator61 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator11 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator49 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator65 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator51 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator12 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator13 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator52 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator14 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator15 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator53 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator16 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator35 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasMovDAuditoria1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasMovDAuditoria")
        Me.Separator20 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator63 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator19 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator21 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator22 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator23 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioMovArticulosHA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosHA")
        Me.Separator24 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator25 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator29 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator26 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator27 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator28 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilRepTraspasoTE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTE")
        Me.menuUtilRepTraspasoTS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTS")
        Me.menuUtilTrasCanceladosDE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDE")
        Me.menuUtilTrasCanceladosDS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDS")
        Me.menuUtilTrasCanceladosSG1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosSG")
        Me.menuUtilTrasCanceladosOrigen1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosOrigen")
        Me.Separator47 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator64 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator68 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator66 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCatalogos1 = New Janus.Windows.UI.CommandBars.UICommand("menuGenerales")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.uiConsultas = New Janus.Windows.UI.Dock.UIPanelGroup()
        Me.uiConsultasContainer = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.uiPanel0Container = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.uiPanel0 = New Janus.Windows.UI.Dock.UIPanel()
        Me.menuUtilRepTraspasoTE2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTE")
        Me.menuUtilRepTraspasoTS2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTS")
        Me.menuUtilTrasCanceladosDE2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDE")
        Me.menuUtilTrasCanceladosDS2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDS")
        Me.menuUtilTrasCanceladosSG2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosSG")
        Me.menuUtilTrasCanceladosOrigen2 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosOrigen")
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiStatusBar2 = New Janus.Windows.UI.StatusBar.UIStatusBar()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.uiConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uiPanel0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 50)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        UiCommandCategory1.CategoryName = "Apartado"
        UiCommandCategory2.CategoryName = "Inventario"
        UiCommandCategory3.CategoryName = "Herramientas"
        Me.UiCommandManager1.Categories.AddRange(New Janus.Windows.UI.CommandBars.UICommandCategory() {UiCommandCategory1, UiCommandCategory2, UiCommandCategory3})
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuSalir, Me.menuUtileriasMovDAuditoria, Me.menuUtilRepMen, Me.menuUtiExportarInfo, Me.menuUtilModFP, Me.menuUtilPreciosDContratos, Me.menuUtilAnaIMarcas, Me.menuUtilDifEnCosto, Me.menuUtilModAjuste, Me.menuUtilBorrarTras, Me.menuUtilRepCostoVenta, Me.menuUtilLiberarCierreDia, Me.menuDesApart, Me.menuUtilArqDCaja, Me.menuUtilRevDApartados, Me.menuUtilAnalDVenta, Me.menuUtilRecDExistencia, Me.menuUtilRMIncongruencia, Me.menuUtilRMDifHistoriInv, Me.menuUtilRMTraspasoE, Me.menuUtilRMTraspasoS, Me.menuUtilRMTraspasoBSG, Me.menuUtilRMAjusteE, Me.menuUtilRMAjusteS, Me.menuUtilRMAjusteG, Me.menuUtilRMAuditoRet, Me.menuUtilRMAnalisisInv, Me.menuUtilRMCostoSuc, Me.menuUtilRMCostoCodigo, Me.menuUtilRMExistenciaN, Me.menuUtilRMArticulosA, Me.menuUtilRMDescuentoO, Me.menuUtilRMReporteA, Me.menuUtilRMReporteD, Me.menuUtilRMViolacionInv, Me.menuUtilRepTraspasoTE, Me.menuUtilRepTraspasoTS, Me.menuUtilTrasCanceladosDE, Me.menuUtilTrasCanceladosDS, Me.menuUtilTrasCanceladosSG, Me.menuUtilTrasCanceladosOrigen, Me.menuInventarioMovArticulosHA, Me.menuUtilTomadeInventario, Me.menuUtilArqCajaFondoCaja, Me.menuUtilArqCajaIngresoCaja, Me.menuUtilModAjusteGeneral, Me.menuUtilModAjusteEntrada, Me.menuUtilModAjusteSalida, Me.menuUtilModAjusteEliminar, Me.menuUtilModAjusteRecibidos, Me.menuUtilRepValeCaja, Me.menuUtilEFExportInfo, Me.menuUtilEIRepExport, Me.menuExportarGAD, Me.menuUtilModAjusteEntradaSaida, Me.menuAnularAjusteTE, Me.menuCargarFolios, Me.MnuReporteCostosInventario})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("05e90427-94bb-4c58-9aad-7b16d21d644e")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtileriasMovDAuditoria2, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(890, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuUtileriasMovDAuditoria2
        '
        Me.menuUtileriasMovDAuditoria2.Key = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria2.Name = "menuUtileriasMovDAuditoria2"
        Me.menuUtileriasMovDAuditoria2.Text = "&Movimientos de Auditoria"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        Me.menuSalir1.Text = "&Salir del Módulo de Auditoría"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilRMAjusteG2, Me.Separator54, Me.menuUtilRMAjusteE2, Me.Separator55, Me.menuUtilRMAjusteS2, Me.Separator18, Me.menuUtilTomadeInventario2, Me.Separator31, Me.menuUtilRepValeCaja2, Me.Separator67, Me.menuUtilArqDCaja2, Me.Separator69, Me.menuSalir2, Me.Separator71})
        Me.UiCommandBar2.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(184, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuUtilRMAjusteG2
        '
        Me.menuUtilRMAjusteG2.Key = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG2.Name = "menuUtilRMAjusteG2"
        Me.menuUtilRMAjusteG2.ToolTipText = "Ajustes Generales"
        '
        'Separator54
        '
        Me.Separator54.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator54.Key = "Separator"
        Me.Separator54.Name = "Separator54"
        '
        'menuUtilRMAjusteE2
        '
        Me.menuUtilRMAjusteE2.Key = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE2.Name = "menuUtilRMAjusteE2"
        Me.menuUtilRMAjusteE2.ToolTipText = "Ajustes de Entrada"
        '
        'Separator55
        '
        Me.Separator55.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator55.Key = "Separator"
        Me.Separator55.Name = "Separator55"
        '
        'menuUtilRMAjusteS2
        '
        Me.menuUtilRMAjusteS2.Key = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS2.Name = "menuUtilRMAjusteS2"
        Me.menuUtilRMAjusteS2.ToolTipText = "Ajustes de Salida"
        '
        'Separator18
        '
        Me.Separator18.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator18.Key = "Separator"
        Me.Separator18.Name = "Separator18"
        '
        'menuUtilTomadeInventario2
        '
        Me.menuUtilTomadeInventario2.Key = "menuUtilTomadeInventario"
        Me.menuUtilTomadeInventario2.Name = "menuUtilTomadeInventario2"
        Me.menuUtilTomadeInventario2.ToolTipText = "Toma de Inventario"
        '
        'Separator31
        '
        Me.Separator31.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator31.Key = "Separator"
        Me.Separator31.Name = "Separator31"
        '
        'menuUtilRepValeCaja2
        '
        Me.menuUtilRepValeCaja2.Key = "menuUtilRepValeCaja"
        Me.menuUtilRepValeCaja2.Name = "menuUtilRepValeCaja2"
        Me.menuUtilRepValeCaja2.ToolTipText = "Reporte de &Vales de Caja"
        '
        'Separator67
        '
        Me.Separator67.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator67.Key = "Separator"
        Me.Separator67.Name = "Separator67"
        '
        'menuUtilArqDCaja2
        '
        Me.menuUtilArqDCaja2.Icon = CType(resources.GetObject("menuUtilArqDCaja2.Icon"), System.Drawing.Icon)
        Me.menuUtilArqDCaja2.Key = "menuUtilArqDCaja"
        Me.menuUtilArqDCaja2.Name = "menuUtilArqDCaja2"
        Me.menuUtilArqDCaja2.ToolTipText = "Arqueo de Caja"
        '
        'Separator69
        '
        Me.Separator69.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator69.Key = "Separator"
        Me.Separator69.Name = "Separator69"
        '
        'menuSalir2
        '
        Me.menuSalir2.Key = "menuSalir"
        Me.menuSalir2.Name = "menuSalir2"
        Me.menuSalir2.ToolTipText = "Salir del Módulo de Auditoría"
        '
        'Separator71
        '
        Me.Separator71.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator71.Key = "Separator"
        Me.Separator71.Name = "Separator71"
        '
        'menuSalir
        '
        Me.menuSalir.Image = CType(resources.GetObject("menuSalir.Image"), System.Drawing.Image)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir del Módulo de Auditoría"
        '
        'menuUtileriasMovDAuditoria
        '
        Me.menuUtileriasMovDAuditoria.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilRepMen1, Me.menuUtiExportarInfo1, Me.Separator30, Me.menuUtilModFP1, Me.menuUtilPreciosDContratos1, Me.Separator32, Me.menuUtilAnaIMarcas1, Me.Separator33, Me.menuUtilDifEnCosto1, Me.menuUtilModAjuste1, Me.menuUtilBorrarTras1, Me.menuUtilRepCostoVenta1, Me.menuUtilLiberarCierreDia1, Me.Separator34, Me.menuDesApart1, Me.Separator56, Me.menuUtilArqDCaja1, Me.Separator57, Me.menuUtilTomadeInventario1, Me.Separator58, Me.menuUtilRevDApartados1, Me.menuUtilAnalDVenta1, Me.menuUtilRecDExistencia1, Me.Separator17, Me.menuUtilRepValeCaja1, Me.Separator72, Me.menuAnularAjusteTE1, Me.menuCargarFolios1, Me.MnuReporteCostosInventario1})
        Me.menuUtileriasMovDAuditoria.Image = CType(resources.GetObject("menuUtileriasMovDAuditoria.Image"), System.Drawing.Image)
        Me.menuUtileriasMovDAuditoria.Key = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria.Name = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria.Text = "Movimiento de Auditoria"
        '
        'menuUtilRepMen1
        '
        Me.menuUtilRepMen1.Key = "menuUtilRepMen"
        Me.menuUtilRepMen1.Name = "menuUtilRepMen1"
        '
        'menuUtiExportarInfo1
        '
        Me.menuUtiExportarInfo1.Enabled = Janus.Windows.UI.InheritableBoolean.[True]
        Me.menuUtiExportarInfo1.Key = "menuUtiExportarInfo"
        Me.menuUtiExportarInfo1.Name = "menuUtiExportarInfo1"
        Me.menuUtiExportarInfo1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator30
        '
        Me.Separator30.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator30.Key = "Separator"
        Me.Separator30.Name = "Separator30"
        '
        'menuUtilModFP1
        '
        Me.menuUtilModFP1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilModFP1.Key = "menuUtilModFP"
        Me.menuUtilModFP1.Name = "menuUtilModFP1"
        Me.menuUtilModFP1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilPreciosDContratos1
        '
        Me.menuUtilPreciosDContratos1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilPreciosDContratos1.Key = "menuUtilPreciosDContratos"
        Me.menuUtilPreciosDContratos1.Name = "menuUtilPreciosDContratos1"
        Me.menuUtilPreciosDContratos1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator32
        '
        Me.Separator32.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator32.Key = "Separator"
        Me.Separator32.Name = "Separator32"
        '
        'menuUtilAnaIMarcas1
        '
        Me.menuUtilAnaIMarcas1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilAnaIMarcas1.Key = "menuUtilAnaIMarcas"
        Me.menuUtilAnaIMarcas1.Name = "menuUtilAnaIMarcas1"
        Me.menuUtilAnaIMarcas1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator33
        '
        Me.Separator33.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator33.Key = "Separator"
        Me.Separator33.Name = "Separator33"
        Me.Separator33.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilDifEnCosto1
        '
        Me.menuUtilDifEnCosto1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilDifEnCosto1.Key = "menuUtilDifEnCosto"
        Me.menuUtilDifEnCosto1.Name = "menuUtilDifEnCosto1"
        Me.menuUtilDifEnCosto1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjuste1
        '
        Me.menuUtilModAjuste1.Key = "menuUtilModAjuste"
        Me.menuUtilModAjuste1.Name = "menuUtilModAjuste1"
        '
        'menuUtilBorrarTras1
        '
        Me.menuUtilBorrarTras1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilBorrarTras1.Key = "menuUtilBorrarTras"
        Me.menuUtilBorrarTras1.Name = "menuUtilBorrarTras1"
        Me.menuUtilBorrarTras1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRepCostoVenta1
        '
        Me.menuUtilRepCostoVenta1.Key = "menuUtilRepCostoVenta"
        Me.menuUtilRepCostoVenta1.Name = "menuUtilRepCostoVenta1"
        Me.menuUtilRepCostoVenta1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilLiberarCierreDia1
        '
        Me.menuUtilLiberarCierreDia1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilLiberarCierreDia1.Key = "menuUtilLiberarCierreDia"
        Me.menuUtilLiberarCierreDia1.Name = "menuUtilLiberarCierreDia1"
        Me.menuUtilLiberarCierreDia1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator34
        '
        Me.Separator34.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator34.Key = "Separator"
        Me.Separator34.Name = "Separator34"
        '
        'menuDesApart1
        '
        Me.menuDesApart1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuDesApart1.Key = "menuDesApart"
        Me.menuDesApart1.Name = "menuDesApart1"
        Me.menuDesApart1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator56
        '
        Me.Separator56.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator56.Key = "Separator"
        Me.Separator56.Name = "Separator56"
        '
        'menuUtilArqDCaja1
        '
        Me.menuUtilArqDCaja1.Key = "menuUtilArqDCaja"
        Me.menuUtilArqDCaja1.Name = "menuUtilArqDCaja1"
        '
        'Separator57
        '
        Me.Separator57.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator57.Key = "Separator"
        Me.Separator57.Name = "Separator57"
        '
        'menuUtilTomadeInventario1
        '
        Me.menuUtilTomadeInventario1.Key = "menuUtilTomadeInventario"
        Me.menuUtilTomadeInventario1.Name = "menuUtilTomadeInventario1"
        Me.menuUtilTomadeInventario1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator58
        '
        Me.Separator58.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator58.Key = "Separator"
        Me.Separator58.Name = "Separator58"
        Me.Separator58.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRevDApartados1
        '
        Me.menuUtilRevDApartados1.Key = "menuUtilRevDApartados"
        Me.menuUtilRevDApartados1.Name = "menuUtilRevDApartados1"
        Me.menuUtilRevDApartados1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilAnalDVenta1
        '
        Me.menuUtilAnalDVenta1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilAnalDVenta1.Key = "menuUtilAnalDVenta"
        Me.menuUtilAnalDVenta1.Name = "menuUtilAnalDVenta1"
        Me.menuUtilAnalDVenta1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRecDExistencia1
        '
        Me.menuUtilRecDExistencia1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtilRecDExistencia1.Key = "menuUtilRecDExistencia"
        Me.menuUtilRecDExistencia1.Name = "menuUtilRecDExistencia1"
        Me.menuUtilRecDExistencia1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator17
        '
        Me.Separator17.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator17.Key = "Separator"
        Me.Separator17.Name = "Separator17"
        Me.Separator17.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRepValeCaja1
        '
        Me.menuUtilRepValeCaja1.Image = CType(resources.GetObject("menuUtilRepValeCaja1.Image"), System.Drawing.Image)
        Me.menuUtilRepValeCaja1.Key = "menuUtilRepValeCaja"
        Me.menuUtilRepValeCaja1.Name = "menuUtilRepValeCaja1"
        Me.menuUtilRepValeCaja1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator72
        '
        Me.Separator72.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator72.Key = "Separator"
        Me.Separator72.Name = "Separator72"
        '
        'menuAnularAjusteTE1
        '
        Me.menuAnularAjusteTE1.Key = "menuAnularAjusteTE"
        Me.menuAnularAjusteTE1.Name = "menuAnularAjusteTE1"
        Me.menuAnularAjusteTE1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuCargarFolios1
        '
        Me.menuCargarFolios1.Key = "menuCargarFolios"
        Me.menuCargarFolios1.Name = "menuCargarFolios1"
        '
        'MnuReporteCostosInventario1
        '
        Me.MnuReporteCostosInventario1.Image = CType(resources.GetObject("MnuReporteCostosInventario1.Image"), System.Drawing.Image)
        Me.MnuReporteCostosInventario1.Key = "MnuReporteCostosInventario"
        Me.MnuReporteCostosInventario1.Name = "MnuReporteCostosInventario1"
        '
        'menuUtilRepMen
        '
        Me.menuUtilRepMen.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilRMIncongruencia1, Me.menuUtilRMDifHistoriInv1, Me.Separator36, Me.menuUtilRMTraspasoE1, Me.menuUtilRMTraspasoS1, Me.menuUtilRMTraspasoBSG1, Me.Separator37, Me.menuUtilRMAjusteE1, Me.menuUtilRMAjusteS1, Me.menuUtilRMAjusteG1, Me.Separator38, Me.menuUtilRMAuditoRet1, Me.menuUtilRMAnalisisInv1, Me.Separator39, Me.menuUtilRMCostoSuc1, Me.menuUtilRMCostoCodigo1, Me.Separator40, Me.menuUtilRMExistenciaN1, Me.menuUtilRMDescuentoO1, Me.Separator41, Me.menuUtilRMReporteA1, Me.Separator42, Me.menuUtilRMViolacionInv1})
        Me.menuUtilRepMen.Key = "menuUtilRepMen"
        Me.menuUtilRepMen.Name = "menuUtilRepMen"
        Me.menuUtilRepMen.Text = "Reportes Mensuales"
        '
        'menuUtilRMIncongruencia1
        '
        Me.menuUtilRMIncongruencia1.Key = "menuUtilRMIncongruencia"
        Me.menuUtilRMIncongruencia1.Name = "menuUtilRMIncongruencia1"
        '
        'menuUtilRMDifHistoriInv1
        '
        Me.menuUtilRMDifHistoriInv1.Key = "menuUtilRMDifHistoriInv"
        Me.menuUtilRMDifHistoriInv1.Name = "menuUtilRMDifHistoriInv1"
        Me.menuUtilRMDifHistoriInv1.Text = "Diferencias entre Historico e Inv"
        Me.menuUtilRMDifHistoriInv1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator36
        '
        Me.Separator36.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator36.Key = "Separator"
        Me.Separator36.Name = "Separator36"
        '
        'menuUtilRMTraspasoE1
        '
        Me.menuUtilRMTraspasoE1.Key = "menuUtilRMTraspasoE"
        Me.menuUtilRMTraspasoE1.Name = "menuUtilRMTraspasoE1"
        Me.menuUtilRMTraspasoE1.Text = "Traspasos E/S"
        '
        'menuUtilRMTraspasoS1
        '
        Me.menuUtilRMTraspasoS1.Key = "menuUtilRMTraspasoS"
        Me.menuUtilRMTraspasoS1.Name = "menuUtilRMTraspasoS1"
        Me.menuUtilRMTraspasoS1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMTraspasoBSG1
        '
        Me.menuUtilRMTraspasoBSG1.Key = "menuUtilRMTraspasoBSG"
        Me.menuUtilRMTraspasoBSG1.Name = "menuUtilRMTraspasoBSG1"
        Me.menuUtilRMTraspasoBSG1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator37
        '
        Me.Separator37.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator37.Key = "Separator"
        Me.Separator37.Name = "Separator37"
        '
        'menuUtilRMAjusteE1
        '
        Me.menuUtilRMAjusteE1.Key = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE1.Name = "menuUtilRMAjusteE1"
        Me.menuUtilRMAjusteE1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMAjusteS1
        '
        Me.menuUtilRMAjusteS1.Key = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS1.Name = "menuUtilRMAjusteS1"
        Me.menuUtilRMAjusteS1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMAjusteG1
        '
        Me.menuUtilRMAjusteG1.Key = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG1.Name = "menuUtilRMAjusteG1"
        '
        'Separator38
        '
        Me.Separator38.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator38.Key = "Separator"
        Me.Separator38.Name = "Separator38"
        '
        'menuUtilRMAuditoRet1
        '
        Me.menuUtilRMAuditoRet1.Key = "menuUtilRMAuditoRet"
        Me.menuUtilRMAuditoRet1.Name = "menuUtilRMAuditoRet1"
        '
        'menuUtilRMAnalisisInv1
        '
        Me.menuUtilRMAnalisisInv1.Key = "menuUtilRMAnalisisInv"
        Me.menuUtilRMAnalisisInv1.Name = "menuUtilRMAnalisisInv1"
        Me.menuUtilRMAnalisisInv1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator39
        '
        Me.Separator39.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator39.Key = "Separator"
        Me.Separator39.Name = "Separator39"
        '
        'menuUtilRMCostoSuc1
        '
        Me.menuUtilRMCostoSuc1.Key = "menuUtilRMCostoSuc"
        Me.menuUtilRMCostoSuc1.Name = "menuUtilRMCostoSuc1"
        Me.menuUtilRMCostoSuc1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMCostoCodigo1
        '
        Me.menuUtilRMCostoCodigo1.Key = "menuUtilRMCostoCodigo"
        Me.menuUtilRMCostoCodigo1.Name = "menuUtilRMCostoCodigo1"
        Me.menuUtilRMCostoCodigo1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator40
        '
        Me.Separator40.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator40.Key = "Separator"
        Me.Separator40.Name = "Separator40"
        Me.Separator40.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMExistenciaN1
        '
        Me.menuUtilRMExistenciaN1.Key = "menuUtilRMExistenciaN"
        Me.menuUtilRMExistenciaN1.Name = "menuUtilRMExistenciaN1"
        Me.menuUtilRMExistenciaN1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMDescuentoO1
        '
        Me.menuUtilRMDescuentoO1.Key = "menuUtilRMDescuentoO"
        Me.menuUtilRMDescuentoO1.Name = "menuUtilRMDescuentoO1"
        Me.menuUtilRMDescuentoO1.Text = "Descuentos Otrorgados"
        Me.menuUtilRMDescuentoO1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator41
        '
        Me.Separator41.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator41.Key = "Separator"
        Me.Separator41.Name = "Separator41"
        Me.Separator41.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMReporteA1
        '
        Me.menuUtilRMReporteA1.Key = "menuUtilRMReporteA"
        Me.menuUtilRMReporteA1.Name = "menuUtilRMReporteA1"
        Me.menuUtilRMReporteA1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator42
        '
        Me.Separator42.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator42.Key = "Separator"
        Me.Separator42.Name = "Separator42"
        Me.Separator42.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMViolacionInv1
        '
        Me.menuUtilRMViolacionInv1.Key = "menuUtilRMViolacionInv"
        Me.menuUtilRMViolacionInv1.Name = "menuUtilRMViolacionInv1"
        Me.menuUtilRMViolacionInv1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtiExportarInfo
        '
        Me.menuUtiExportarInfo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuExportarGAD1, Me.Separator70, Me.menuUtilEIExportInfo, Me.menuUtilEIRepExpInfo})
        Me.menuUtiExportarInfo.Key = "menuUtiExportarInfo"
        Me.menuUtiExportarInfo.Name = "menuUtiExportarInfo"
        Me.menuUtiExportarInfo.Text = "Exportar Información"
        '
        'menuExportarGAD1
        '
        Me.menuExportarGAD1.Key = "menuExportarGAD"
        Me.menuExportarGAD1.Name = "menuExportarGAD1"
        '
        'Separator70
        '
        Me.Separator70.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator70.Key = "Separator"
        Me.Separator70.Name = "Separator70"
        '
        'menuUtilEIExportInfo
        '
        Me.menuUtilEIExportInfo.Key = "menuUtilEFExportInfo"
        Me.menuUtilEIExportInfo.Name = "menuUtilEIExportInfo"
        Me.menuUtilEIExportInfo.Text = "Exportar Información Auditoria"
        '
        'menuUtilEIRepExpInfo
        '
        Me.menuUtilEIRepExpInfo.Key = "menuUtilEIRepExport"
        Me.menuUtilEIRepExpInfo.Name = "menuUtilEIRepExpInfo"
        '
        'menuUtilModFP
        '
        Me.menuUtilModFP.Key = "menuUtilModFP"
        Me.menuUtilModFP.Name = "menuUtilModFP"
        Me.menuUtilModFP.Text = "Modificacion de Forma de Pago"
        '
        'menuUtilPreciosDContratos
        '
        Me.menuUtilPreciosDContratos.Key = "menuUtilPreciosDContratos"
        Me.menuUtilPreciosDContratos.Name = "menuUtilPreciosDContratos"
        Me.menuUtilPreciosDContratos.Text = "Precios de Contratos"
        '
        'menuUtilAnaIMarcas
        '
        Me.menuUtilAnaIMarcas.Key = "menuUtilAnaIMarcas"
        Me.menuUtilAnaIMarcas.Name = "menuUtilAnaIMarcas"
        Me.menuUtilAnaIMarcas.Text = "Analisis de Inv por Marcas"
        '
        'menuUtilDifEnCosto
        '
        Me.menuUtilDifEnCosto.Key = "menuUtilDifEnCosto"
        Me.menuUtilDifEnCosto.Name = "menuUtilDifEnCosto"
        Me.menuUtilDifEnCosto.Text = "Diferencia en Costo"
        '
        'menuUtilModAjuste
        '
        Me.menuUtilModAjuste.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilModAjusteGeneral1, Me.menuUtilModAjusteEntradaSaida1, Me.menuUtilModAjusteEntrada1, Me.menuUtilModAjusteSalida1, Me.Separator60, Me.menuUtilModAjusteEliminar1, Me.menuUtilModAjusteRecibidos2})
        Me.menuUtilModAjuste.Key = "menuUtilModAjuste"
        Me.menuUtilModAjuste.Name = "menuUtilModAjuste"
        Me.menuUtilModAjuste.Text = "Modulo de Ajuste"
        '
        'menuUtilModAjusteGeneral1
        '
        Me.menuUtilModAjusteGeneral1.Key = "menuUtilModAjusteGeneral"
        Me.menuUtilModAjusteGeneral1.Name = "menuUtilModAjusteGeneral1"
        Me.menuUtilModAjusteGeneral1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjusteEntradaSaida1
        '
        Me.menuUtilModAjusteEntradaSaida1.Key = "menuUtilModAjusteEntradaSaida"
        Me.menuUtilModAjusteEntradaSaida1.Name = "menuUtilModAjusteEntradaSaida1"
        '
        'menuUtilModAjusteEntrada1
        '
        Me.menuUtilModAjusteEntrada1.Key = "menuUtilModAjusteEntrada"
        Me.menuUtilModAjusteEntrada1.Name = "menuUtilModAjusteEntrada1"
        Me.menuUtilModAjusteEntrada1.Text = "Ajuste Entrada (Consulta)"
        '
        'menuUtilModAjusteSalida1
        '
        Me.menuUtilModAjusteSalida1.Key = "menuUtilModAjusteSalida"
        Me.menuUtilModAjusteSalida1.Name = "menuUtilModAjusteSalida1"
        Me.menuUtilModAjusteSalida1.Text = "Ajuste Salida (Consulta)"
        '
        'Separator60
        '
        Me.Separator60.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator60.Key = "Separator"
        Me.Separator60.Name = "Separator60"
        Me.Separator60.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjusteEliminar1
        '
        Me.menuUtilModAjusteEliminar1.Key = "menuUtilModAjusteEliminar"
        Me.menuUtilModAjusteEliminar1.Name = "menuUtilModAjusteEliminar1"
        Me.menuUtilModAjusteEliminar1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjusteRecibidos2
        '
        Me.menuUtilModAjusteRecibidos2.Key = "menuUtilModAjusteRecibidos"
        Me.menuUtilModAjusteRecibidos2.Name = "menuUtilModAjusteRecibidos2"
        Me.menuUtilModAjusteRecibidos2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilBorrarTras
        '
        Me.menuUtilBorrarTras.Key = "menuUtilBorrarTras"
        Me.menuUtilBorrarTras.Name = "menuUtilBorrarTras"
        Me.menuUtilBorrarTras.Text = "Borrar Traspaso S/Grabar"
        '
        'menuUtilRepCostoVenta
        '
        Me.menuUtilRepCostoVenta.Key = "menuUtilRepCostoVenta"
        Me.menuUtilRepCostoVenta.Name = "menuUtilRepCostoVenta"
        Me.menuUtilRepCostoVenta.Text = "Reporte Costo de Venta"
        '
        'menuUtilLiberarCierreDia
        '
        Me.menuUtilLiberarCierreDia.Key = "menuUtilLiberarCierreDia"
        Me.menuUtilLiberarCierreDia.Name = "menuUtilLiberarCierreDia"
        Me.menuUtilLiberarCierreDia.Text = "Liberar Cierre del Dia"
        '
        'menuDesApart
        '
        Me.menuDesApart.Key = "menuDesApart"
        Me.menuDesApart.Name = "menuDesApart"
        Me.menuDesApart.Text = "Desmarcar Apartado"
        '
        'menuUtilArqDCaja
        '
        Me.menuUtilArqDCaja.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilArqCajaFondoCaja1, Me.Separator59, Me.menuUtilArqCajaIngresoCaja1})
        Me.menuUtilArqDCaja.Key = "menuUtilArqDCaja"
        Me.menuUtilArqDCaja.Name = "menuUtilArqDCaja"
        Me.menuUtilArqDCaja.Text = "Arqueo de Caja"
        '
        'menuUtilArqCajaFondoCaja1
        '
        Me.menuUtilArqCajaFondoCaja1.Icon = CType(resources.GetObject("menuUtilArqCajaFondoCaja1.Icon"), System.Drawing.Icon)
        Me.menuUtilArqCajaFondoCaja1.Key = "menuUtilArqCajaFondoCaja"
        Me.menuUtilArqCajaFondoCaja1.Name = "menuUtilArqCajaFondoCaja1"
        '
        'Separator59
        '
        Me.Separator59.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator59.Key = "Separator"
        Me.Separator59.Name = "Separator59"
        '
        'menuUtilArqCajaIngresoCaja1
        '
        Me.menuUtilArqCajaIngresoCaja1.Icon = CType(resources.GetObject("menuUtilArqCajaIngresoCaja1.Icon"), System.Drawing.Icon)
        Me.menuUtilArqCajaIngresoCaja1.Key = "menuUtilArqCajaIngresoCaja"
        Me.menuUtilArqCajaIngresoCaja1.Name = "menuUtilArqCajaIngresoCaja1"
        '
        'menuUtilRevDApartados
        '
        Me.menuUtilRevDApartados.Key = "menuUtilRevDApartados"
        Me.menuUtilRevDApartados.Name = "menuUtilRevDApartados"
        Me.menuUtilRevDApartados.Text = "Revision de Apartados"
        '
        'menuUtilAnalDVenta
        '
        Me.menuUtilAnalDVenta.Key = "menuUtilAnalDVenta"
        Me.menuUtilAnalDVenta.Name = "menuUtilAnalDVenta"
        Me.menuUtilAnalDVenta.Text = "Analisis de Venta"
        '
        'menuUtilRecDExistencia
        '
        Me.menuUtilRecDExistencia.Key = "menuUtilRecDExistencia"
        Me.menuUtilRecDExistencia.Name = "menuUtilRecDExistencia"
        Me.menuUtilRecDExistencia.Text = "Recalculo de Existencia"
        '
        'menuUtilRMIncongruencia
        '
        Me.menuUtilRMIncongruencia.Key = "menuUtilRMIncongruencia"
        Me.menuUtilRMIncongruencia.Name = "menuUtilRMIncongruencia"
        Me.menuUtilRMIncongruencia.Text = "Incongruencia de Inventario"
        Me.menuUtilRMIncongruencia.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMDifHistoriInv
        '
        Me.menuUtilRMDifHistoriInv.Key = "menuUtilRMDifHistoriInv"
        Me.menuUtilRMDifHistoriInv.Name = "menuUtilRMDifHistoriInv"
        Me.menuUtilRMDifHistoriInv.Text = "Diferencias entre Historia e Inv"
        '
        'menuUtilRMTraspasoE
        '
        Me.menuUtilRMTraspasoE.Key = "menuUtilRMTraspasoE"
        Me.menuUtilRMTraspasoE.Name = "menuUtilRMTraspasoE"
        Me.menuUtilRMTraspasoE.Text = "Traspaso de Entrada"
        '
        'menuUtilRMTraspasoS
        '
        Me.menuUtilRMTraspasoS.Key = "menuUtilRMTraspasoS"
        Me.menuUtilRMTraspasoS.Name = "menuUtilRMTraspasoS"
        Me.menuUtilRMTraspasoS.Text = "Traspaso de Salida"
        '
        'menuUtilRMTraspasoBSG
        '
        Me.menuUtilRMTraspasoBSG.Key = "menuUtilRMTraspasoBSG"
        Me.menuUtilRMTraspasoBSG.Name = "menuUtilRMTraspasoBSG"
        Me.menuUtilRMTraspasoBSG.Text = "Traspaso Borrados S/Grabar"
        '
        'menuUtilRMAjusteE
        '
        Me.menuUtilRMAjusteE.Icon = CType(resources.GetObject("menuUtilRMAjusteE.Icon"), System.Drawing.Icon)
        Me.menuUtilRMAjusteE.Key = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE.Name = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE.Text = "Ajustes de Entrada"
        '
        'menuUtilRMAjusteS
        '
        Me.menuUtilRMAjusteS.Icon = CType(resources.GetObject("menuUtilRMAjusteS.Icon"), System.Drawing.Icon)
        Me.menuUtilRMAjusteS.Key = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS.Name = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS.Text = "Ajustes de Salida"
        '
        'menuUtilRMAjusteG
        '
        Me.menuUtilRMAjusteG.Icon = CType(resources.GetObject("menuUtilRMAjusteG.Icon"), System.Drawing.Icon)
        Me.menuUtilRMAjusteG.Key = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG.Name = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG.Text = "Ajustes Generales"
        Me.menuUtilRMAjusteG.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilRMAuditoRet
        '
        Me.menuUtilRMAuditoRet.Key = "menuUtilRMAuditoRet"
        Me.menuUtilRMAuditoRet.Name = "menuUtilRMAuditoRet"
        Me.menuUtilRMAuditoRet.Text = "Auditoria de Retiros"
        '
        'menuUtilRMAnalisisInv
        '
        Me.menuUtilRMAnalisisInv.Key = "menuUtilRMAnalisisInv"
        Me.menuUtilRMAnalisisInv.Name = "menuUtilRMAnalisisInv"
        Me.menuUtilRMAnalisisInv.Text = "Analisis de Inventario"
        '
        'menuUtilRMCostoSuc
        '
        Me.menuUtilRMCostoSuc.Key = "menuUtilRMCostoSuc"
        Me.menuUtilRMCostoSuc.Name = "menuUtilRMCostoSuc"
        Me.menuUtilRMCostoSuc.Text = "Costo de Inv. por Sucursal"
        '
        'menuUtilRMCostoCodigo
        '
        Me.menuUtilRMCostoCodigo.Key = "menuUtilRMCostoCodigo"
        Me.menuUtilRMCostoCodigo.Name = "menuUtilRMCostoCodigo"
        Me.menuUtilRMCostoCodigo.Text = "Costo de Inv. por Codigo"
        '
        'menuUtilRMExistenciaN
        '
        Me.menuUtilRMExistenciaN.Key = "menuUtilRMExistenciaN"
        Me.menuUtilRMExistenciaN.Name = "menuUtilRMExistenciaN"
        Me.menuUtilRMExistenciaN.Text = "Existencia Negativa"
        '
        'menuUtilRMArticulosA
        '
        Me.menuUtilRMArticulosA.Key = "menuUtilRMArticulosA"
        Me.menuUtilRMArticulosA.Name = "menuUtilRMArticulosA"
        Me.menuUtilRMArticulosA.Text = "Articulos Apartados"
        '
        'menuUtilRMDescuentoO
        '
        Me.menuUtilRMDescuentoO.Key = "menuUtilRMDescuentoO"
        Me.menuUtilRMDescuentoO.Name = "menuUtilRMDescuentoO"
        Me.menuUtilRMDescuentoO.Text = "Descuento Otrorgados"
        '
        'menuUtilRMReporteA
        '
        Me.menuUtilRMReporteA.Key = "menuUtilRMReporteA"
        Me.menuUtilRMReporteA.Name = "menuUtilRMReporteA"
        Me.menuUtilRMReporteA.Text = "Reporte de Apartados"
        '
        'menuUtilRMReporteD
        '
        Me.menuUtilRMReporteD.Key = "menuUtilRMReporteD"
        Me.menuUtilRMReporteD.Name = "menuUtilRMReporteD"
        Me.menuUtilRMReporteD.Text = "Reporte de Defectuosos"
        '
        'menuUtilRMViolacionInv
        '
        Me.menuUtilRMViolacionInv.Key = "menuUtilRMViolacionInv"
        Me.menuUtilRMViolacionInv.Name = "menuUtilRMViolacionInv"
        Me.menuUtilRMViolacionInv.Text = "Violacion a Inventarrio"
        '
        'menuUtilRepTraspasoTE
        '
        Me.menuUtilRepTraspasoTE.Key = "menuUtilRepTraspasoTE"
        Me.menuUtilRepTraspasoTE.Name = "menuUtilRepTraspasoTE"
        Me.menuUtilRepTraspasoTE.Text = "Traspaso de Entrada"
        '
        'menuUtilRepTraspasoTS
        '
        Me.menuUtilRepTraspasoTS.Key = "menuUtilRepTraspasoTS"
        Me.menuUtilRepTraspasoTS.Name = "menuUtilRepTraspasoTS"
        Me.menuUtilRepTraspasoTS.Text = "Traspaso de Salida"
        '
        'menuUtilTrasCanceladosDE
        '
        Me.menuUtilTrasCanceladosDE.Key = "menuUtilTrasCanceladosDE"
        Me.menuUtilTrasCanceladosDE.Name = "menuUtilTrasCanceladosDE"
        Me.menuUtilTrasCanceladosDE.Text = "De Entrada"
        '
        'menuUtilTrasCanceladosDS
        '
        Me.menuUtilTrasCanceladosDS.Key = "menuUtilTrasCanceladosDS"
        Me.menuUtilTrasCanceladosDS.Name = "menuUtilTrasCanceladosDS"
        Me.menuUtilTrasCanceladosDS.Text = "De Salida"
        '
        'menuUtilTrasCanceladosSG
        '
        Me.menuUtilTrasCanceladosSG.Key = "menuUtilTrasCanceladosSG"
        Me.menuUtilTrasCanceladosSG.Name = "menuUtilTrasCanceladosSG"
        Me.menuUtilTrasCanceladosSG.Text = "Sin Grabar"
        '
        'menuUtilTrasCanceladosOrigen
        '
        Me.menuUtilTrasCanceladosOrigen.Key = "menuUtilTrasCanceladosOrigen"
        Me.menuUtilTrasCanceladosOrigen.Name = "menuUtilTrasCanceladosOrigen"
        Me.menuUtilTrasCanceladosOrigen.Text = "En Origen o Destino"
        '
        'menuInventarioMovArticulosHA
        '
        Me.menuInventarioMovArticulosHA.Key = "menuInventarioMovArticulosHA"
        Me.menuInventarioMovArticulosHA.Name = "menuInventarioMovArticulosHA"
        Me.menuInventarioMovArticulosHA.Text = "Historico de Apartado"
        '
        'menuUtilTomadeInventario
        '
        Me.menuUtilTomadeInventario.Icon = CType(resources.GetObject("menuUtilTomadeInventario.Icon"), System.Drawing.Icon)
        Me.menuUtilTomadeInventario.Key = "menuUtilTomadeInventario"
        Me.menuUtilTomadeInventario.Name = "menuUtilTomadeInventario"
        Me.menuUtilTomadeInventario.Text = "Toma de Inventario"
        '
        'menuUtilArqCajaFondoCaja
        '
        Me.menuUtilArqCajaFondoCaja.Key = "menuUtilArqCajaFondoCaja"
        Me.menuUtilArqCajaFondoCaja.Name = "menuUtilArqCajaFondoCaja"
        Me.menuUtilArqCajaFondoCaja.Text = "Fondo de Caja Chica"
        '
        'menuUtilArqCajaIngresoCaja
        '
        Me.menuUtilArqCajaIngresoCaja.Key = "menuUtilArqCajaIngresoCaja"
        Me.menuUtilArqCajaIngresoCaja.Name = "menuUtilArqCajaIngresoCaja"
        Me.menuUtilArqCajaIngresoCaja.Text = "Ingreso y Fondo de Caja"
        '
        'menuUtilModAjusteGeneral
        '
        Me.menuUtilModAjusteGeneral.Key = "menuUtilModAjusteGeneral"
        Me.menuUtilModAjusteGeneral.Name = "menuUtilModAjusteGeneral"
        Me.menuUtilModAjusteGeneral.Text = "Ajuste General"
        Me.menuUtilModAjusteGeneral.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjusteEntrada
        '
        Me.menuUtilModAjusteEntrada.Key = "menuUtilModAjusteEntrada"
        Me.menuUtilModAjusteEntrada.Name = "menuUtilModAjusteEntrada"
        Me.menuUtilModAjusteEntrada.Text = "Ajuste Entrada"
        '
        'menuUtilModAjusteSalida
        '
        Me.menuUtilModAjusteSalida.Key = "menuUtilModAjusteSalida"
        Me.menuUtilModAjusteSalida.Name = "menuUtilModAjusteSalida"
        Me.menuUtilModAjusteSalida.Text = "Ajuste Salida"
        '
        'menuUtilModAjusteEliminar
        '
        Me.menuUtilModAjusteEliminar.Key = "menuUtilModAjusteEliminar"
        Me.menuUtilModAjusteEliminar.Name = "menuUtilModAjusteEliminar"
        Me.menuUtilModAjusteEliminar.Text = "Eliminar Ajuste"
        '
        'menuUtilModAjusteRecibidos
        '
        Me.menuUtilModAjusteRecibidos.Key = "menuUtilModAjusteRecibidos"
        Me.menuUtilModAjusteRecibidos.Name = "menuUtilModAjusteRecibidos"
        Me.menuUtilModAjusteRecibidos.Text = "Ajuste Recibidos"
        '
        'menuUtilRepValeCaja
        '
        Me.menuUtilRepValeCaja.Image = CType(resources.GetObject("menuUtilRepValeCaja.Image"), System.Drawing.Image)
        Me.menuUtilRepValeCaja.Key = "menuUtilRepValeCaja"
        Me.menuUtilRepValeCaja.Name = "menuUtilRepValeCaja"
        Me.menuUtilRepValeCaja.Text = "Reporte de &Vales de Caja"
        '
        'menuUtilEFExportInfo
        '
        Me.menuUtilEFExportInfo.Key = "menuUtilEFExportInfo"
        Me.menuUtilEFExportInfo.Name = "menuUtilEFExportInfo"
        Me.menuUtilEFExportInfo.Text = "Exportar Información"
        '
        'menuUtilEIRepExport
        '
        Me.menuUtilEIRepExport.Key = "menuUtilEIRepExport"
        Me.menuUtilEIRepExport.Name = "menuUtilEIRepExport"
        Me.menuUtilEIRepExport.Text = "Reporte de Exportación"
        '
        'menuExportarGAD
        '
        Me.menuExportarGAD.Key = "menuExportarGAD"
        Me.menuExportarGAD.Name = "menuExportarGAD"
        Me.menuExportarGAD.Text = "Exportar Ganancia Adicional"
        Me.menuExportarGAD.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilModAjusteEntradaSaida
        '
        Me.menuUtilModAjusteEntradaSaida.Key = "menuUtilModAjusteEntradaSaida"
        Me.menuUtilModAjusteEntradaSaida.Name = "menuUtilModAjusteEntradaSaida"
        Me.menuUtilModAjusteEntradaSaida.Text = "Ajustes de Entrada - Salida"
        '
        'menuAnularAjusteTE
        '
        Me.menuAnularAjusteTE.Key = "menuAnularAjusteTE"
        Me.menuAnularAjusteTE.Name = "menuAnularAjusteTE"
        Me.menuAnularAjusteTE.Text = "Anular Ajuste"
        '
        'menuCargarFolios
        '
        Me.menuCargarFolios.Image = CType(resources.GetObject("menuCargarFolios.Image"), System.Drawing.Image)
        Me.menuCargarFolios.Key = "menuCargarFolios"
        Me.menuCargarFolios.Name = "menuCargarFolios"
        Me.menuCargarFolios.Text = "Cargar Folios Notas de Venta..."
        '
        'MnuReporteCostosInventario
        '
        Me.MnuReporteCostosInventario.Key = "MnuReporteCostosInventario"
        Me.MnuReporteCostosInventario.Name = "MnuReporteCostosInventario"
        Me.MnuReporteCostosInventario.Text = "Reporte Costos de Inventario"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
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
        Me.TopRebar1.Size = New System.Drawing.Size(890, 50)
        '
        'Separator46
        '
        Me.Separator46.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator46.Key = "Separator"
        Me.Separator46.Name = "Separator46"
        '
        'Separator48
        '
        Me.Separator48.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator48.Key = "Separator"
        Me.Separator48.Name = "Separator48"
        '
        'Separator43
        '
        Me.Separator43.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator43.Key = "Separator"
        Me.Separator43.Name = "Separator43"
        '
        'Separator44
        '
        Me.Separator44.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator44.Key = "Separator"
        Me.Separator44.Name = "Separator44"
        '
        'Separator62
        '
        Me.Separator62.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator62.Key = "Separator"
        Me.Separator62.Name = "Separator62"
        '
        'Separator45
        '
        Me.Separator45.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator45.Key = "Separator"
        Me.Separator45.Name = "Separator45"
        '
        'Separator50
        '
        Me.Separator50.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator50.Key = "Separator"
        Me.Separator50.Name = "Separator50"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'Separator61
        '
        Me.Separator61.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator61.Key = "Separator"
        Me.Separator61.Name = "Separator61"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'Separator11
        '
        Me.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator11.Key = "Separator"
        Me.Separator11.Name = "Separator11"
        '
        'Separator49
        '
        Me.Separator49.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator49.Key = "Separator"
        Me.Separator49.Name = "Separator49"
        '
        'Separator65
        '
        Me.Separator65.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator65.Key = "Separator"
        Me.Separator65.Name = "Separator65"
        '
        'Separator51
        '
        Me.Separator51.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator51.Key = "Separator"
        Me.Separator51.Name = "Separator51"
        '
        'Separator12
        '
        Me.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator12.Key = "Separator"
        Me.Separator12.Name = "Separator12"
        '
        'Separator13
        '
        Me.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator13.Key = "Separator"
        Me.Separator13.Name = "Separator13"
        '
        'Separator52
        '
        Me.Separator52.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator52.Key = "Separator"
        Me.Separator52.Name = "Separator52"
        '
        'Separator14
        '
        Me.Separator14.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator14.Key = "Separator"
        Me.Separator14.Name = "Separator14"
        '
        'Separator15
        '
        Me.Separator15.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator15.Key = "Separator"
        Me.Separator15.Name = "Separator15"
        '
        'Separator53
        '
        Me.Separator53.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator53.Key = "Separator"
        Me.Separator53.Name = "Separator53"
        '
        'Separator16
        '
        Me.Separator16.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator16.Key = "Separator"
        Me.Separator16.Name = "Separator16"
        '
        'Separator35
        '
        Me.Separator35.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator35.Key = "Separator"
        Me.Separator35.Name = "Separator35"
        '
        'menuUtileriasMovDAuditoria1
        '
        Me.menuUtileriasMovDAuditoria1.Image = CType(resources.GetObject("menuUtileriasMovDAuditoria1.Image"), System.Drawing.Image)
        Me.menuUtileriasMovDAuditoria1.Key = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria1.Name = "menuUtileriasMovDAuditoria1"
        '
        'Separator20
        '
        Me.Separator20.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator20.Key = "Separator"
        Me.Separator20.Name = "Separator20"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'Separator63
        '
        Me.Separator63.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator63.Key = "Separator"
        Me.Separator63.Name = "Separator63"
        '
        'Separator19
        '
        Me.Separator19.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator19.Key = "Separator"
        Me.Separator19.Name = "Separator19"
        '
        'Separator21
        '
        Me.Separator21.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator21.Key = "Separator"
        Me.Separator21.Name = "Separator21"
        '
        'Separator22
        '
        Me.Separator22.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator22.Key = "Separator"
        Me.Separator22.Name = "Separator22"
        '
        'Separator23
        '
        Me.Separator23.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator23.Key = "Separator"
        Me.Separator23.Name = "Separator23"
        '
        'menuInventarioMovArticulosHA1
        '
        Me.menuInventarioMovArticulosHA1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioMovArticulosHA1.Key = "menuInventarioMovArticulosHA"
        Me.menuInventarioMovArticulosHA1.Name = "menuInventarioMovArticulosHA1"
        '
        'Separator24
        '
        Me.Separator24.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator24.Key = "Separator"
        Me.Separator24.Name = "Separator24"
        '
        'Separator25
        '
        Me.Separator25.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator25.Key = "Separator"
        Me.Separator25.Name = "Separator25"
        '
        'Separator29
        '
        Me.Separator29.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator29.Key = "Separator"
        Me.Separator29.Name = "Separator29"
        '
        'Separator26
        '
        Me.Separator26.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator26.Key = "Separator"
        Me.Separator26.Name = "Separator26"
        '
        'Separator27
        '
        Me.Separator27.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator27.Key = "Separator"
        Me.Separator27.Name = "Separator27"
        '
        'Separator28
        '
        Me.Separator28.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator28.Key = "Separator"
        Me.Separator28.Name = "Separator28"
        '
        'menuUtilRepTraspasoTE1
        '
        Me.menuUtilRepTraspasoTE1.Key = "menuUtilRepTraspasoTE"
        Me.menuUtilRepTraspasoTE1.Name = "menuUtilRepTraspasoTE1"
        '
        'menuUtilRepTraspasoTS1
        '
        Me.menuUtilRepTraspasoTS1.Key = "menuUtilRepTraspasoTS"
        Me.menuUtilRepTraspasoTS1.Name = "menuUtilRepTraspasoTS1"
        '
        'menuUtilTrasCanceladosDE1
        '
        Me.menuUtilTrasCanceladosDE1.Key = "menuUtilTrasCanceladosDE"
        Me.menuUtilTrasCanceladosDE1.Name = "menuUtilTrasCanceladosDE1"
        '
        'menuUtilTrasCanceladosDS1
        '
        Me.menuUtilTrasCanceladosDS1.Key = "menuUtilTrasCanceladosDS"
        Me.menuUtilTrasCanceladosDS1.Name = "menuUtilTrasCanceladosDS1"
        '
        'menuUtilTrasCanceladosSG1
        '
        Me.menuUtilTrasCanceladosSG1.Key = "menuUtilTrasCanceladosSG"
        Me.menuUtilTrasCanceladosSG1.Name = "menuUtilTrasCanceladosSG1"
        '
        'menuUtilTrasCanceladosOrigen1
        '
        Me.menuUtilTrasCanceladosOrigen1.Key = "menuUtilTrasCanceladosOrigen"
        Me.menuUtilTrasCanceladosOrigen1.Name = "menuUtilTrasCanceladosOrigen1"
        '
        'Separator47
        '
        Me.Separator47.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator47.Key = "Separator"
        Me.Separator47.Name = "Separator47"
        '
        'Separator64
        '
        Me.Separator64.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator64.Key = "Separator"
        Me.Separator64.Name = "Separator64"
        '
        'Separator68
        '
        Me.Separator68.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator68.Key = "Separator"
        Me.Separator68.Name = "Separator68"
        '
        'Separator66
        '
        Me.Separator66.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator66.Key = "Separator"
        Me.Separator66.Name = "Separator66"
        '
        'menuCatalogos1
        '
        Me.menuCatalogos1.Key = "menuGenerales"
        Me.menuCatalogos1.Name = "menuCatalogos1"
        Me.menuCatalogos1.Text = "&Catalogos"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'uiConsultas
        '
        Me.uiConsultas.BackColor = System.Drawing.SystemColors.Control
        Me.uiConsultas.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark
        Me.uiConsultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uiConsultas.Location = New System.Drawing.Point(0, 23)
        Me.uiConsultas.Name = "uiConsultas"
        Me.uiConsultas.Size = New System.Drawing.Size(196, 529)
        Me.uiConsultas.TabIndex = 4
        Me.uiConsultas.Text = "Consultas"
        '
        'uiConsultasContainer
        '
        Me.uiConsultasContainer.Location = New System.Drawing.Point(0, 0)
        Me.uiConsultasContainer.Name = "uiConsultasContainer"
        Me.uiConsultasContainer.Size = New System.Drawing.Size(196, 529)
        Me.uiConsultasContainer.TabIndex = 0
        '
        'uiPanel0Container
        '
        Me.uiPanel0Container.Location = New System.Drawing.Point(0, 0)
        Me.uiPanel0Container.Name = "uiPanel0Container"
        Me.uiPanel0Container.Size = New System.Drawing.Size(201, 376)
        Me.uiPanel0Container.TabIndex = 0
        '
        'uiPanel0
        '
        Me.uiPanel0.Location = New System.Drawing.Point(0, 0)
        Me.uiPanel0.Name = "uiPanel0"
        Me.uiPanel0.Size = New System.Drawing.Size(201, 376)
        Me.uiPanel0.TabIndex = 4
        Me.uiPanel0.Text = "Panel 0"
        '
        'menuUtilRepTraspasoTE2
        '
        Me.menuUtilRepTraspasoTE2.Key = "menuUtilRepTraspasoTE"
        Me.menuUtilRepTraspasoTE2.Name = "menuUtilRepTraspasoTE2"
        '
        'menuUtilRepTraspasoTS2
        '
        Me.menuUtilRepTraspasoTS2.Key = "menuUtilRepTraspasoTS"
        Me.menuUtilRepTraspasoTS2.Name = "menuUtilRepTraspasoTS2"
        '
        'menuUtilTrasCanceladosDE2
        '
        Me.menuUtilTrasCanceladosDE2.Key = "menuUtilTrasCanceladosDE"
        Me.menuUtilTrasCanceladosDE2.Name = "menuUtilTrasCanceladosDE2"
        '
        'menuUtilTrasCanceladosDS2
        '
        Me.menuUtilTrasCanceladosDS2.Key = "menuUtilTrasCanceladosDS"
        Me.menuUtilTrasCanceladosDS2.Name = "menuUtilTrasCanceladosDS2"
        '
        'menuUtilTrasCanceladosSG2
        '
        Me.menuUtilTrasCanceladosSG2.Key = "menuUtilTrasCanceladosSG"
        Me.menuUtilTrasCanceladosSG2.Name = "menuUtilTrasCanceladosSG2"
        '
        'menuUtilTrasCanceladosOrigen2
        '
        Me.menuUtilTrasCanceladosOrigen2.Key = "menuUtilTrasCanceladosOrigen"
        Me.menuUtilTrasCanceladosOrigen2.Name = "menuUtilTrasCanceladosOrigen2"
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.UiStatusBar2)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(890, 509)
        Me.explorerBar1.TabIndex = 8
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiStatusBar2
        '
        Me.UiStatusBar2.Location = New System.Drawing.Point(0, 477)
        Me.UiStatusBar2.Name = "UiStatusBar2"
        UiStatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel1.Icon = CType(resources.GetObject("UiStatusBarPanel1.Icon"), System.Drawing.Icon)
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Text = "Usuario"
        UiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel2.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel2.Key = ""
        UiStatusBarPanel2.ProgressBarValue = 0
        UiStatusBarPanel2.Width = 250
        UiStatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel3.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel3.Key = ""
        UiStatusBarPanel3.ProgressBarValue = 0
        UiStatusBarPanel3.Width = 250
        UiStatusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel4.FormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel4.Icon = CType(resources.GetObject("UiStatusBarPanel4.Icon"), System.Drawing.Icon)
        UiStatusBarPanel4.Key = ""
        UiStatusBarPanel4.ProgressBarValue = 0
        UiStatusBarPanel4.Text = "D'PORTENIS Pro - DPTienda"
        UiStatusBarPanel4.Width = 350
        Me.UiStatusBar2.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1, UiStatusBarPanel2, UiStatusBarPanel3, UiStatusBarPanel4})
        Me.UiStatusBar2.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.UiStatusBar2.Size = New System.Drawing.Size(890, 32)
        Me.UiStatusBar2.TabIndex = 2
        '
        'MainFormAuditoria
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(890, 559)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainFormAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulo de Auditoría"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.uiConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uiPanel0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Methods"

    Private Sub MainFormAuditoria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UiStatusBar2.Panels(1).Text = String.Empty
        UiStatusBar2.Panels(2).Text = Format(Now, "Long Date")

        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = True Then

            UiStatusBar2.Panels(1).Text = UCase(oAppContext.Security.CurrentUser.Name)
            UiStatusBar2.Panels(2).Text = Format(Now, "Long Date")

            Me.UserLoginName = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
            Me.UserName = UCase(oAppContext.Security.CurrentUser.Name)

        Else

            Me.Close()

        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            '/****** Salir ******/
        Case "menuSalir"
                'Cerramos la sesión del Auditor
                oAppContext.Security.CloseImpersonatedSession()

                Me.Close()

                '/****** Auditoria ******/

            Case "menuUtilArqCajaIngresoCaja"

                Dim oArqueoCaja As New frmArqueoDeCaja
                oArqueoCaja.AdmnistrativoID = Me.UserLoginName
                oArqueoCaja.AdmnistrativoName = Me.UserName
                oArqueoCaja.Show()

            Case "menuCargarFolios"
                Dim oCargaFolios As New frmCargaFoliosNotasVenta
                oCargaFolios.AdmnistrativoID = Me.UserLoginName
                oCargaFolios.AdmnistrativoName = Me.UserName
                oCargaFolios.Show()

            Case "menuUtilArqCajaFondoCaja"

                Dim oArqueoCajaChica As New frmArqueoDeCajaChica
                oArqueoCajaChica.AdministrativoID = Me.UserLoginName
                oArqueoCajaChica.AdministrativoName = Me.UserName
                oArqueoCajaChica.Show()

            Case "menuUtilModAjusteGeneral"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AjusteGeneral") Then

                    Dim oFrmAjusteGeneral As New frmAjustesTalla
                    oFrmAjusteGeneral.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtilModAjusteEntrada"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AjusteEntrada") = True Then
                    Dim oFrmAjusteEntrada As New frmAjustesES
                    oFrmAjusteEntrada.TipoAjuste = "E"
                    oFrmAjusteEntrada.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtilModAjusteSalida"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AjusteSalida") = True Then
                    Dim oFrmAjusteSalida As New frmAjustesES
                    oFrmAjusteSalida.TipoAjuste = "S"
                    oFrmAjusteSalida.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtilModAjusteEntradaSaida"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AjusteEntradaSalida") = True Then
                    Dim oFrmAjusteES As New frmAjustesESNuevo
                    oFrmAjusteES.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtilTomadeInventario"

                Dim oFrmTomaInventario As New frmTomadeInventario
                oFrmTomaInventario.AdministrativoID = Me.UserLoginName
                oFrmTomaInventario.AdministrativoName = Me.UserName
                oFrmTomaInventario.Show()

            Case "menuUtilRMAuditoRet"

                Dim ofrmAuditoriaRetiroReport As New AuditoriaRetirosReportForm
                ofrmAuditoriaRetiroReport.Show()

            Case "menuUtilRevDApartados"

                Dim menuClickB As New frmRevisionApartados
                menuClickB.AdmnistrativoID = Me.UserLoginName
                menuClickB.AdmnistrativoName = Me.UserName
                menuClickB.Show()

            Case "menuUtilRMTraspasoE"

                Dim menuClickB As New frmReporteTraspasos
                menuClickB.Show()

            Case "menuUtilRMAjusteE"

                Dim iRepAjustes As AjusteEntrada
                Dim iRepAjEng As RepAjustesESEng.cRepAjustesES

                iRepAjustes = New AjusteEntrada
                iRepAjEng = New RepAjustesESEng.cRepAjustesES

                If iRepAjEng.Generar(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext.ApplicationConfiguration.Almacen, "E", iRepAjustes) Then
                    Dim iViewer As ReportViewerForm

                    iViewer = New ReportViewerForm
                    iRepAjustes.Run()
                    iViewer.Report = iRepAjustes
                    iViewer.Show()
                End If

            Case "menuUtilRMAjusteS"

                Dim iRepAjustes As AjusteEntrada
                Dim iRepAjEng As RepAjustesESEng.cRepAjustesES

                iRepAjustes = New AjusteEntrada
                iRepAjEng = New RepAjustesESEng.cRepAjustesES

                If iRepAjEng.Generar(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString(), oAppContext.ApplicationConfiguration.Almacen, "S", iRepAjustes) Then
                    Dim iViewer As ReportViewerForm

                    iViewer = New ReportViewerForm
                    iRepAjustes.Run()
                    iViewer.Report = iRepAjustes
                    iViewer.Show()
                End If

            Case "menuUtilRMAjusteG"

                Dim menuClickB As New frmReporteAgusteGeneral
                menuClickB.Show()

            Case "menuUtilRMDescuentoO"

                Dim menuClickB As New frmDescuentosOtorgados
                menuClickB.Show()

            Case "menuUtilRepCostoVenta"

                Dim menuClickB As New ValesdeCajaReportForm
                menuClickB.ShowMeforCostosdeVenta()

            Case "menuUtilRMIncongruencia"

                Dim menuClickB As New IncongruenciasInventarioReportForm
                menuClickB.ShowDialog()

            Case "menuUtilRMAnalisisInv"

                Dim menuClickB As New AnalisisInventarioAuditoria
                menuClickB.ShowDialog()

            Case "menuUtilRepValeCaja"

                Dim oRepoValeCajaAudi As New ValesdeCajaReportForm
                oRepoValeCajaAudi.ShowMeforValeDeCaja()
                'oRepoValeCajaAudi.ShowMeforAuditoria()

            Case "menuExportarGAD"

                Dim oExportInfo As New frmGananciaAdicional
                'Dim oExportInfo As New frmVentasPorCliente
                oExportInfo.Show()

            Case "menuUtilEFExportInfo"

                Dim oExportInfo As New FrmExportarInformacion
                oExportInfo.Show()

            Case "menuAnularAjusteTE"

                Dim oExportInfo As New frmAnularAjusteTE
                oExportInfo.Show()

            Case "menuUtilEIRepExport"


                If Dir("C:\DPT\AUD\EXIS" & Format(Date.Now, "yy") & ".DBF", FileAttribute.Archive) <> "" And Dir("C:\DPT\AUD\FAMILIA.DBF", FileAttribute.Archive) <> "" Then

                    Dim vlCadena As String, vlFecha As Date, vlHora As String
                    Dim dsDataSet As New DataSet

                    FileOpen(1, "C:\DPT\AUD\ExportInfo.bat", OpenMode.Input)
                    Do While Not EOF(1)
                        vlCadena = LineInput(1)
                        If vlCadena.Substring(0, 1) = "F" Then
                            vlFecha = vlCadena.Substring(14, 10)
                            vlHora = vlCadena.Substring(25, vlCadena.Length - 25)
                            Exit Do
                        End If
                    Loop
                    FileClose(1)

                    Dim oConDBF As New ADODB.ConnectionClass
                    Dim oRstDBF As New ADODB.RecordsetClass

                    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
                    oRstDBF.Open("SELECT Familia.Codigo, Familia.Nombre, Sum(EXIS" & Format(Date.Now, "yy") & ".Existencia) As Cantidad FROM Familia INNER JOIN EXIS" & Format(Date.Now, "yy") & " ON Familia.Codigo=EXIS" & Format(Date.Now, "yy") & ".Familia GROUP BY Familia.Codigo, Familia.Nombre;", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                    If Not oRstDBF.EOF Then

                        dsDataSet = New DataSet("RptExportInfo")
                        Dim dtExportInfo As New DataTable("RptExportInfo")

                        Dim dcFamilia As New DataColumn
                        With dcFamilia
                            .ColumnName = "Familia"
                            .Caption = "Familia"
                            .DataType = GetType(System.String)
                            .DefaultValue = String.Empty
                        End With

                        Dim dcNombre As New DataColumn
                        With dcNombre
                            .ColumnName = "Nombre"
                            .Caption = "Nombre"
                            .DataType = GetType(System.String)
                            .DefaultValue = String.Empty
                        End With

                        Dim dcCantidad As New DataColumn
                        With dcCantidad
                            .ColumnName = "Cantidad"
                            .Caption = "Cantidad"
                            .DataType = GetType(System.Double)
                            .DefaultValue = 0
                        End With

                        With dtExportInfo.Columns
                            .Add(dcFamilia)
                            .Add(dcNombre)
                            .Add(dcCantidad)
                        End With

                        dsDataSet.Tables.Add(dtExportInfo)

                        Dim drExpInfo As DataRow

                        oRstDBF.MoveFirst()
                        Do While Not oRstDBF.EOF

                            drExpInfo = dsDataSet.Tables("RptExportInfo").NewRow

                            With drExpInfo
                                !Familia = oRstDBF.Fields("Codigo").Value
                                !Nombre = oRstDBF.Fields("Nombre").Value
                                !Cantidad = oRstDBF.Fields("Cantidad").Value
                            End With

                            dsDataSet.Tables("RptExportInfo").Rows.Add(drExpInfo)

                            oRstDBF.MoveNext()
                        Loop
                    End If

                    Dim oARReporte As New ReporteExportarInformacion(dsDataSet, vlFecha, vlHora)
                    Dim oReportViewer As New ReportViewerForm

                    oARReporte.Document.Name = "Reporte de Exportación de Información"
                    oARReporte.Run()

                    oReportViewer.Report = oARReporte
                    oReportViewer.Show()

                Else

                    MsgBox("No ha generado el archivo de exportación de información.", MsgBoxStyle.Information, "Reporte de Exportación de Información")

                End If

            Case "MnuReporteCostosInventario"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPRO.DPTienda.Auditoria.Auditoria.ReporteCostosInventarios") = True Then
                    If IsDownloadAuditoria(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja) = False Then
                        Dim ofrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                        ofrmProcesoSAP.FechaDA = Date.Now
                        ofrmProcesoSAP.bMostrarMensaje = False
                        ofrmProcesoSAP.ShowDev("Inventarios")
                        ofrmProcesoSAP.Dispose()
                        ofrmProcesoSAP = Nothing
                        InsertarDescargaAuditoria(oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja)
                        Dim reporteCosto As New frmReporteCostosInventarios
                        reporteCosto.ShowDialog()
                    Else
                        Dim reporteCosto As New frmReporteCostosInventarios
                        reporteCosto.ShowDialog()
                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                End If

        End Select

    End Sub

    Private Function IsDownloadAuditoria(ByVal CodAlmacen As String, ByVal Caja As String) As Boolean
        Dim sapManager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Return sapManager.IsDownloadAuditoria(CodAlmacen, Caja, Date.Now)
    End Function

    Private Function InsertarDescargaAuditoria(ByVal CodAlmacen As String, ByVal Caja As String)
        Dim sapManager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        sapManager.InsertarDescargaAuditoria(CodAlmacen, Caja)
    End Function

    Private Sub MainFormAuditoria_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oAppContext.Security.CloseImpersonatedSession()

    End Sub

    Private Sub MainFormAuditoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Me.Close()

        End Select

    End Sub


#End Region

#Region "Properties User"

    Private m_strUserName As String
    Private m_strUserLoginName As String

    Public Property UserLoginName() As String
        Get
            Return m_strUserLoginName
        End Get
        Set(ByVal Value As String)
            m_strUserLoginName = Value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return m_strUserName
        End Get
        Set(ByVal Value As String)
            m_strUserName = Value
        End Set
    End Property

#End Region

   
End Class
