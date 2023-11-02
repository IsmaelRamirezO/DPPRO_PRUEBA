Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Janus.Windows.UI
Imports Janus.Windows.UI.Dock
Imports Janus.Windows.UI.CommandBars
Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.InicioCaja
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.GananciasAdicionalesAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports System.Text
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports System.Reflection
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports EmpGerInt

'GAD
Imports DportenisPro.DPTienda.ApplicationUnits.ExporterDBF
Imports System.IO
Imports uPaydll
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago


Public Class MainForm
    Inherits System.Windows.Forms.Form
    Dim oPanelControl As Control
    Dim DashBoardTemp As HomeDash
    Dim enableTimers As Boolean = False
    Dim bolAvisoMensaje As Boolean
    Dim oCierreDiasMgr As CierreDiaManager
    Dim oInicioDiaMgr As InicioDiaManager
    Dim oServerUPCMgr As ServerUPCManager
    Dim oFingerPMgr As FingerPrintManager
    Friend WithEvents menuInventarioReportePedidosEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReportePedidosEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClientesDPVL1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClientesDPVL As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator43 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCargaNotasCredito1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCargaNotasCredito As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPinPadBanamex1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPinPadBanamex As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPinPadBanamexOffline1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPinPadBanamexOffline As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCambioTalla1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCambioTalla As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDisposicionEfectivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDisposicionEfectivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevaDisposicion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMonitoreoReproceso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDisposicionCancelar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevaDisposicion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMonitoreoReproceso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDisposicionCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCancelacion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCancelacion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarFactura1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDevolucionTarjeta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDevolucionTarjeta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPedidosCompra1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuPedidosCompra As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuRecepcionPedido1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDevolucionProveedor1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuRecepcionPedido As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDevolucionProveedor As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuDescargaManual As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuDescargaManual2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuDescargaManual1 As Janus.Windows.UI.CommandBars.UICommand
    Private oSAPMgr As ProcesoSAPManager
    Dim oTSMgr As TraspasosSalidaManager
    '  Dim oSAPMgr As ProcesoSAPManager


#Region " Código generado por el Diseñador de Windows Forms "
    Public DescargaManual As Boolean = False
    Friend WithEvents menuReportesWeb1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuReportesWeb As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRepWeb11 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRepWeb1 As Janus.Windows.UI.CommandBars.UICommand
    Public oCatArt As New CatalogoArticuloManager(oAppContext)
    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oServerUPCMgr = New ServerUPCManager(oAppContext, oConfigCierreFI)
        oFingerPMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)
        oInicioDiaMgr = New InicioDiaManager(oAppContext, oAppSAPConfig)
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        '-----------------------------------------------------------
        ' JNAVA (11/11/2015): Agregamos el homedash (Migracion)
        '-----------------------------------------------------------
        oPanelControl = New HomeDash
        oPanelControl.CreateControl()
        oPanelControl.Dock = DockStyle.Fill
        Me.Controls.Add(oPanelControl)
        DashBoardTemp = CType(oPanelControl, HomeDash)
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
    Friend WithEvents UiStatusBar1 As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents uiPanel0Container As Janus.Windows.UI.Dock.UIPanelInnerContainer
    Friend WithEvents uiPanel0 As Janus.Windows.UI.Dock.UIPanel
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuVentas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarios As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGenerales As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilerias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasFacturacion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCambioTalla As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaInicio As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarFactura As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCierreDia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaAnalisisVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaNotasCredito As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasAvisosenNotas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaModDatosFact As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarios1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilerias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasFacturacion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCambioTalla1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaInicio1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCierreDia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaAnalisisVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaNotasCredito1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasAvisosenNotas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaModDatosFact1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosContratos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosAOA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbono As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosEdoCtaXContrato As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadoCancelarAbono As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosContratos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosAOA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbono1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosEdoCtaXContrato1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadoCancelarAbono1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioExistdeCodigo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMov As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioRepOperacional As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioExistdeCodigo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMov1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioRepOperacional1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVED As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVXH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaPromXH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVXHVentaTotal As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVXHVentaDetalle As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasNotaCreditoManejo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesConcentrado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesDetallado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesParciales As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVT1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVED1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaVXH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReporteVentaPromXH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaAnalisisVentaReporte As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesConcentrado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesDetallado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesParciales1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasNotaCreditoManejo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCAbono As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaCXCCancelarAbono As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCuenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCtaXCliente As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCtaXFact As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaCXCEdoCtaXGeneral As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCAbono1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaCXCCancelarAbono1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCuenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCtaXCliente1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCEdoCtaXFact1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentaCXCEdoCtaXGeneral1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVerBarra As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVer1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVerBarra1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoAV As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoAAV As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbonoAA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbonoAC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratosDef As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratoNDCredito As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbonoAA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDAbonoAC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratosDef1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosCancelarContratoNDCredito1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosPA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticuloTA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosH2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosPA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticuloTA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMovArticulosH21 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvCod As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvCodDet As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMarcas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvLinea As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvFamilia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvUsos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvSucursal As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvArtCD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvFM As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvRA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvCod1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvCodDet1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMarcas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvLinea1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvFamilia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvUsos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvSucursal1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvArtCD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvLF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMLF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvMF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvFM1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioCostodeInvRA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasosTE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasosSalida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoPT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoModTSalida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoBTG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoRDD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoTSG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasosSalida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoPT1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoModTSalida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoBTG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoRDD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoTSG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvPC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvLFD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvMF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvMLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvOLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvEN As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvAA As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvUP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvRG As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvPC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvEN1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvAA1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvUP1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteInvRG1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovPC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovLF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovPC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovMF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovMF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovMLF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioArtSinMovMLF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosoMAD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuososDAD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDesfectuososRDD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosoMAD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuososDAD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDesfectuososRDD1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasCompactarArc As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasGenerarArchivos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarDoc As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasProcArc As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRespaldarArch As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasMovDAuditoria As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasCierreDAño As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasDatosDSucursal As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasImpDEtiquetas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasDepDInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasCompactarArc1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasGenerarArchivos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarDoc1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRespaldarArch1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasMovDAuditoria1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasCierreDAño1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasDatosDSucursal1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasImpDEtiquetas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCT2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCD2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoCC2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoAV2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuApartadosRepDApartadoAAV2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesArticulos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesClientes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesProveedores As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesFamilias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPlayers As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesMarcas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesSucursales As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesUsos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesFDePago As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTDeVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTDeDev As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTDeAjuste As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesClaveMReg As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCAdmvo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCtaP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesDescuentos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesManagerT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesLineas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesArticulos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesFamilias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesLineas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesMarcas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesUsos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesBancos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesDescuentos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolioFac As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolioCont As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolAbono As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolioFac1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolioCont1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasEliminarFolAbono1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRespaldoResDisco As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasFormatoDisco As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRespaldoResDisco1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasFormatoDisco1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasImpPrecioNor As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasImpPrecioOfert As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasImpUna As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator11 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator12 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator13 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator14 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator15 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator16 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator17 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator18 As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuUtilCambioTalla As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilCancelarCambioTalla As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilModFP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilPreciosDContratos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepDTraspasos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTrasCancelados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnalCosto As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnaLU As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilAnaIMarcas As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuGenerales1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesAlmacen As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesAlmacen1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCat As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCiudades As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCodigoUPC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesColonias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCorridas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesEstados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesFamilia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesOrigenes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPlaza As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPublicaciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesStatus As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoCliente As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoDescuento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoMov As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesUnidades As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesVentas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCat1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesCiudades1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesColonias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesEstados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesFDePago1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPlaza1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoDescuento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoTarjeta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoTarjeta1 As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuReporteTraspasoTT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTE As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilRepTraspasoTS As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuReporteTraspasoTT1 As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuGeneralesVales As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesVales1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuConsultarExistencia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator47 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRetiros As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesTipoVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPlayer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesPlayer1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasProcArc1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator49 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator50 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator51 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator52 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator53 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator54 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator55 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilTomadeInventario As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuClientes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClienteAsociado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClienteAsociado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuHerramientasOpciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuHerramientasOpciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator31 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClientes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesAsociados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClienteDPVale As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClienteDEnTienda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClientes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCredito As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCredito1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesAsociados2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator64 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClienteDPVale2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuClientesClienteDEnTienda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesBanco As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGeneralesBanco1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasInicioCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCierreCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasInicioCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCierreCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasRetiros As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasRetiros1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator61 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasACDT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasACDT1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator63 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCaja As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator65 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCaja1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTEntradaDBF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator29 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTEntradaDBF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionSegmentoContable As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionSegmentoContable1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator66 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionDefinicionAsiento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionAsignacionAsiento As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionSegmentoContable2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionDefinicionAsiento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacionAsignacionAsiento1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator67 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuContabilizacion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReasignarPlayer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasReasignarPlayer1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNotasCreditoReportesConcentrado2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCajaManejo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCajaReporte As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCajaManejo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator68 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasValeCajaReporte1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteVarios As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator30 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteVarios1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator32 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCambiarFolio As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasUserRoles As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator33 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasUserRoles1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesAbonosRealizados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesAbonosRealizados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesCxC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesCxCCanceladas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesAbonosCancelado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesHistorial As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesCxC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesCxCCanceladas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesAbonosCancelado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCXCReportesHistorial1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilGananciasAdicionales As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilGananciasAdicionales1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator34 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilesLstPrecios As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilesLstPrecios1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilGenArchCierreDia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtilGenArchCierreDia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtileriasConfiguraSAP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtileriasConfiguraSAP1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtileriasCargaInicial As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtileriasCargaInicial1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasLoadFacturas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator56 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasLoadFacturas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGerencial As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGerencial1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuConfigurarGerencial As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuTemporadas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuConfigurarGerencial1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuTemporadas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAnticiparMetas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAnticiparMetas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizaciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizacionesOpcion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizaciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizacionesOpcion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRutaArvhivos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasRutaArvhivos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuListaArticuloDescuentoSAP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuListaArticuloDescuentoSAP1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasPorCliente As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasPorCliente1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator57 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportarGAD As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtilConfigFotos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuUtilConfigFotos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuActuDescargaImagenes As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuActuDescargaImagenes1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuListaArticulosDescuentoSAPGroup As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuListaArticulosDescuentoSAPGroup1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasNumeroReferencia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasNumeroReferencia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventariolModAjusteGeneral As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventariolModAjusteGeneral1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioEFExportInfo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuUtilCargaArchivosSAP As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuUtilCargaArchivosSAP1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMasVendidos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioMasVendidos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAudDxt As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAudDxt1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator58 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CatMotCapMan As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents RepMotCapMan As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCapturaManual As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCapturaManual1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CatMotCapMan1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents RepMotCapMan1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvDefect As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvDevProv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvAud As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvConcInv As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvConcVtas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTiendas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvDefect1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvDevProv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvAud1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvConcInv1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvConcVtas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTiendas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator69 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator70 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents frmRepDefecDet As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents frmRepDefecDet1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBitacora As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator71 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBitacora1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasDPValeF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasDPValeF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasArchivosDPVF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasGenArchDPVF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasGenArchDPVF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirTickets As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirTickets1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImageGearRegistration As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator72 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImageGearRegistration1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirDPVFinanciero As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirDPVFinanciero1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOperacionalMarcas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOperacionalCodigos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator73 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOperacionalMarcas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOperacionalCodigos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarNotaVenta As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarNotaVenta1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizacionesXCodigos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuActualizacionesXCodigos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirCupon As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirCupon1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoErroresCDIST As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoErroresCDIST1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoEntradaBultos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTraspasoEntradaBultos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteDifTraslados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteDifTraslados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator74 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosoMADEcm As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioDefectuosoMADEcm1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioSurtirTraspasosSolicitados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioSurtirTraspasosSolicitados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator75 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioPedCancEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioPedCancEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoVentaDist As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoVentaDist1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoAutorizar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInvTraspasoAutorizar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteDefecEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioReporteDefecEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioFacturarPedidosEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioFacturarPedidosEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioAsignarGuiaEC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioAsignarGuiaEC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirVC As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasReimprimirVC1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuFacturacionSinExistencia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSurtirPedidosSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSurtirPedidosSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuFacturacionSinExistencia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuPedidosInsurtiblesSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuPedidosInsurtiblesSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecibirPedidoSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecibirPedidoSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEnviarPedidoSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEnviarPedidoSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCancelacionPedido As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCancelacionPedido1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuFacturarPedidosSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuFacturarPedidosSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuReingresarPedidosCancelados As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator76 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuReingresarPedidosCancelados1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuConsultaExistenciaSH As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuConsultaExistenciaSH1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuVentasPlayer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuVentasPlayer1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMetasDiarias As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMetasDiarias1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMetasTienda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuMetasTienda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTF As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator77 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioTF1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoEntradaVirtual As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoEntradaVirtual1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasRecibirOtrosPagos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator78 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasRecibirOtrosPagos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarOtrosPagos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVentasCancelarOtrosPagos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasSaldoDPCard As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator79 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuUtileriasSaldoDPCard1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDPCardPuntos As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuDPCardPuntos1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuConsultaDPCardPunto As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuConsultaDPCardPunto1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoDPCardPunto As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoDPCardPunto1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuInventarioEMT As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator80 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoEntradaMercancia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspasoEntradaMercancia1 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel2 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuVentas1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentas")
        Me.menuApartados1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartados")
        Me.menuInventarios1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarios")
        Me.menuGenerales1 = New Janus.Windows.UI.CommandBars.UICommand("menuGenerales")
        Me.menuUtilerias1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilerias")
        Me.menuClientes1 = New Janus.Windows.UI.CommandBars.UICommand("menuClientes")
        Me.menuCredito1 = New Janus.Windows.UI.CommandBars.UICommand("menuCredito")
        Me.menuVer1 = New Janus.Windows.UI.CommandBars.UICommand("menuVer")
        Me.menuGerencial1 = New Janus.Windows.UI.CommandBars.UICommand("menuGerencial")
        Me.menuSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuSH")
        Me.MnuDPCardPuntos1 = New Janus.Windows.UI.CommandBars.UICommand("MnuDPCardPuntos")
        Me.menuActualizaciones1 = New Janus.Windows.UI.CommandBars.UICommand("menuActualizaciones")
        Me.MnuVentasPlayer1 = New Janus.Windows.UI.CommandBars.UICommand("MnuVentasPlayer")
        Me.MenuDescargaManual1 = New Janus.Windows.UI.CommandBars.UICommand("MenuDescargaManual")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuReportesWeb1 = New Janus.Windows.UI.CommandBars.UICommand("menuReportesWeb")
        Me.menuVentas = New Janus.Windows.UI.CommandBars.UICommand("menuVentas")
        Me.menuVentasFacturacion1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasFacturacion")
        Me.MnuCancelacion1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelacion")
        Me.menuVentasCancelarNotaVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarNotaVenta")
        Me.Separator50 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasCambioTalla1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCambioTalla")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentaInicio1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaInicio")
        Me.menuVentasInicioCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasInicioCaja")
        Me.menuVentasCierreDia1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCierreDia")
        Me.menuVentasCierreCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCierreCaja")
        Me.Separator61 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasRetiros1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasRetiros")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasReporteVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVenta")
        Me.menuVentaAnalisisVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaAnalisisVenta")
        Me.Separator11 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentaNotasCredito1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaNotasCredito")
        Me.menuVentasCXC1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXC")
        Me.menuVentasAvisosenNotas1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasAvisosenNotas")
        Me.Separator49 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentaModDatosFact1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaModDatosFact")
        Me.menuVentasReasignarPlayer1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReasignarPlayer")
        Me.Separator65 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasValeCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCaja")
        Me.menuVentasDPValeF1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasDPValeF")
        Me.Separator78 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasRecibirOtrosPagos1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasRecibirOtrosPagos")
        Me.menuVentasCancelarOtrosPagos1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarOtrosPagos")
        Me.menuApartados = New Janus.Windows.UI.CommandBars.UICommand("menuApartados")
        Me.menuApartadosContratos1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosContratos")
        Me.menuApartadosCancelarContratos1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratos")
        Me.Separator51 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuApartadosAOA1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosAOA")
        Me.menuApartadoCancelarAbono1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadoCancelarAbono")
        Me.Separator12 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuApartadosRepDApartado1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartado")
        Me.menuApartadosRepDAbono1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbono")
        Me.Separator13 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuApartadosEdoCtaXContrato1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosEdoCtaXContrato")
        Me.menuInventarios = New Janus.Windows.UI.CommandBars.UICommand("menuInventarios")
        Me.menuInventarioExistdeCodigo1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioExistdeCodigo")
        Me.Separator52 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioMovArticulos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulos")
        Me.menuInventarioCostodeInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInv")
        Me.Separator14 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioTraspasos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasos")
        Me.Separator15 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioReporteInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInv")
        Me.menuInventarioArtSinMov1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMov")
        Me.Separator53 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioRepOperacional1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioRepOperacional")
        Me.Separator16 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioDefectuosos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosos")
        Me.menuInventariolModAjusteGeneral1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventariolModAjusteGeneral")
        Me.Separator58 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.MnuPedidosCompra1 = New Janus.Windows.UI.CommandBars.UICommand("MnuPedidosCompra")
        Me.menuAudDxt1 = New Janus.Windows.UI.CommandBars.UICommand("menuAudDxt")
        Me.Separator75 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioSurtirTraspasosSolicitados1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioSurtirTraspasosSolicitados")
        Me.menuInventarioReportePedidosEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReportePedidosEC")
        Me.menuInventarioFacturarPedidosEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioFacturarPedidosEC")
        Me.menuInventarioAsignarGuiaEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioAsignarGuiaEC")
        Me.menuInventarioPedCancEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioPedCancEC")
        Me.Separator77 = New Janus.Windows.UI.CommandBars.UICommand("SeparatorTF")
        Me.menuInventarioTF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTF")
        Me.MnuTraspasoEntradaVirtual1 = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoEntradaVirtual")
        Me.Separator80 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGenerales = New Janus.Windows.UI.CommandBars.UICommand("menuGenerales")
        Me.menuGeneralesArticulos1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesArticulos")
        Me.menuGeneralesFamilias1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesFamilias")
        Me.menuGeneralesFDePago1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesFDePago")
        Me.menuGeneralesLineas1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesLineas")
        Me.menuGeneralesMarcas1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesMarcas")
        Me.menuGeneralesUsos1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesUsos")
        Me.menuGeneralesDescuentos1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesDescuentos")
        Me.Separator35 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGeneralesAlmacen1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesAlmacen")
        Me.menuGeneralesBanco1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesBanco")
        Me.menuGeneralesCaja1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCaja")
        Me.menuGeneralesCat1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCat")
        Me.menuGeneralesCiudades1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCiudades")
        Me.menuGeneralesColonias1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesColonias")
        Me.menuGeneralesEstados1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesEstados")
        Me.menuGeneralesPlayer1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPlayer")
        Me.menuGeneralesPlaza1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPlaza")
        Me.menuGeneralesTipoDescuento1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoDescuento")
        Me.menuGeneralesTipoTarjeta1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoTarjeta")
        Me.menuGeneralesTipoVenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoVenta")
        Me.menuGeneralesVales1 = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesVales")
        Me.menuUtilerias = New Janus.Windows.UI.CommandBars.UICommand("menuUtilerias")
        Me.menuUtileriasCompactarArc1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasCompactarArc")
        Me.menuUtileriasGenerarArchivos1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasGenerarArchivos")
        Me.menuUtileriasEliminarDoc1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarDoc")
        Me.menuUtileriasProcArc1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasProcArc")
        Me.Separator17 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasRespaldarArch1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRespaldarArch")
        Me.menuUtileriasMovDAuditoria1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasMovDAuditoria")
        Me.Separator18 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasCierreDAño1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasCierreDAño")
        Me.Separator54 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasDatosDSucursal1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasDatosDSucursal")
        Me.Separator55 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasImpDEtiquetas1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasImpDEtiquetas")
        Me.menuUtilesLstPrecios1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilesLstPrecios")
        Me.Separator31 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtilGenArchCierreDia1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilGenArchCierreDia")
        Me.menuUtilGananciasAdicionales1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilGananciasAdicionales")
        Me.MnuUtilCargaArchivosSAP1 = New Janus.Windows.UI.CommandBars.UICommand("MnuUtilCargaArchivosSAP")
        Me.Separator67 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuContabilizacion1 = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacion")
        Me.Separator33 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.mnuHerramientasOpciones1 = New Janus.Windows.UI.CommandBars.UICommand("mnuHerramientasOpciones")
        Me.mnuUtileriasConfiguraSAP1 = New Janus.Windows.UI.CommandBars.UICommand("mnuUtileriasConfiguraSAP")
        Me.menuUtileriasRutaArvhivos1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRutaArvhivos")
        Me.menuUtileriasNumeroReferencia1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasNumeroReferencia")
        Me.mnuUtilConfigFotos1 = New Janus.Windows.UI.CommandBars.UICommand("mnuUtilConfigFotos")
        Me.Separator34 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasUserRoles1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasUserRoles")
        Me.Separator56 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.mnuUtileriasCargaInicial1 = New Janus.Windows.UI.CommandBars.UICommand("mnuUtileriasCargaInicial")
        Me.menuUtileriasLoadFacturas1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasLoadFacturas")
        Me.menuCapturaManual1 = New Janus.Windows.UI.CommandBars.UICommand("menuCapturaManual")
        Me.menuUtileriasGenArchDPVF1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasGenArchDPVF")
        Me.menuUtileriasReimprimirDPVFinanciero1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirDPVFinanciero")
        Me.menuUtileriasReimprimirTickets1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirTickets")
        Me.menuUtileriasReimprimirCupon1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirCupon")
        Me.menuUtileriasReimprimirVC1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirVC")
        Me.Separator72 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImageGearRegistration1 = New Janus.Windows.UI.CommandBars.UICommand("menuImageGearRegistration")
        Me.Separator79 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasSaldoDPCard1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasSaldoDPCard")
        Me.Separator43 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCargaNotasCredito1 = New Janus.Windows.UI.CommandBars.UICommand("menuCargaNotasCredito")
        Me.MnuPinPadBanamex1 = New Janus.Windows.UI.CommandBars.UICommand("MnuPinPadBanamex")
        Me.MnuPinPadBanamexOffline1 = New Janus.Windows.UI.CommandBars.UICommand("MnuPinPadBanamexOffline")
        Me.MnuDisposicionEfectivo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuDisposicionEfectivo")
        Me.menuVentasFacturacion = New Janus.Windows.UI.CommandBars.UICommand("menuVentasFacturacion")
        Me.menuVentasCambioTalla = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCambioTalla")
        Me.menuVentaInicio = New Janus.Windows.UI.CommandBars.UICommand("menuVentaInicio")
        Me.menuVentasCancelarFactura = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarFactura")
        Me.menuVentasCierreDia = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCierreDia")
        Me.menuVentasReporteVenta = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVenta")
        Me.menuVentasReporteVentaVT1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVT")
        Me.menuVentasReporteVentaVED1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVED")
        Me.menuVentasReporteVentaVXH1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVXH")
        Me.Separator20 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasReporteVentaPromXH1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaPromXH")
        Me.Separator57 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasPorCliente1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasPorCliente")
        Me.Separator73 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuOperacionalMarcas1 = New Janus.Windows.UI.CommandBars.UICommand("menuOperacionalMarcas")
        Me.menuOperacionalCodigos1 = New Janus.Windows.UI.CommandBars.UICommand("menuOperacionalCodigos")
        Me.menuVentaAnalisisVenta = New Janus.Windows.UI.CommandBars.UICommand("menuVentaAnalisisVenta")
        Me.menuVentaNotasCredito = New Janus.Windows.UI.CommandBars.UICommand("menuVentaNotasCredito")
        Me.menuVentasNotaCreditoManejo1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasNotaCreditoManejo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuNotasCreditoReportesConcentrado2 = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesConcentrado")
        Me.MnuCambioTalla1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCambioTalla")
        Me.menuVentasCXC = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXC")
        Me.menuVentasCXCAbono1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCAbono")
        Me.menuVentaCXCCancelarAbono1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaCXCCancelarAbono")
        Me.Separator63 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasACDT1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasACDT")
        Me.Separator19 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasCXCEdoCuenta1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCuenta")
        Me.Separator32 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasCXCReportes1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportes")
        Me.menuVentasAvisosenNotas = New Janus.Windows.UI.CommandBars.UICommand("menuVentasAvisosenNotas")
        Me.menuVentaModDatosFact = New Janus.Windows.UI.CommandBars.UICommand("menuVentaModDatosFact")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuApartadosContratos = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosContratos")
        Me.menuApartadosAOA = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosAOA")
        Me.menuApartadosRepDApartado = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartado")
        Me.menuApartadosRepDApartadoCT2 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCT")
        Me.menuApartadosRepDApartadoCD2 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCD")
        Me.menuApartadosRepDApartadoCC2 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCC")
        Me.Separator21 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuApartadosRepDApartadoAV2 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoAV")
        Me.menuApartadosRepDApartadoAAV2 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoAAV")
        Me.menuApartadosRepDAbono = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbono")
        Me.menuApartadosRepDAbonoAA1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbonoAA")
        Me.menuApartadosRepDAbonoAC1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbonoAC")
        Me.menuApartadosCancelarContratos = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratos")
        Me.menuApartadosCancelarContratoNDCredito1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratoNDCredito")
        Me.Separator22 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuApartadosCancelarContratosDef1 = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratosDef")
        Me.menuApartadosEdoCtaXContrato = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosEdoCtaXContrato")
        Me.menuApartadoCancelarAbono = New Janus.Windows.UI.CommandBars.UICommand("menuApartadoCancelarAbono")
        Me.menuInventarioExistdeCodigo = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioExistdeCodigo")
        Me.menuInventarioMovArticulos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulos")
        Me.menuInventarioMovArticulosPA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosPA")
        Me.menuInventarioMovArticuloTA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticuloTA")
        Me.Separator23 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioMovArticulosH21 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosH2")
        Me.menuInventarioMovArticulosHA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosHA")
        Me.Separator71 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuBitacora1 = New Janus.Windows.UI.CommandBars.UICommand("menuBitacora")
        Me.menuInventarioCostodeInv = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInv")
        Me.menuInventarioCostodeInvCod1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvCod")
        Me.menuInventarioCostodeInvCodDet1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvCodDet")
        Me.menuInventarioCostodeInvMarcas1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMarcas")
        Me.menuInventarioCostodeInvLinea1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvLinea")
        Me.menuInventarioCostodeInvFamilia1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvFamilia")
        Me.menuInventarioCostodeInvUsos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvUsos")
        Me.menuInventarioCostodeInvSucursal1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvSucursal")
        Me.menuInventarioCostodeInvArtCD1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvArtCD")
        Me.menuInventarioCostodeInvLF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvLF")
        Me.menuInventarioCostodeInvMLF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMLF")
        Me.menuInventarioCostodeInvMF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMF")
        Me.menuInventarioCostodeInvFM1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvFM")
        Me.menuInventarioCostodeInvRA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvRA")
        Me.menuInventarioTraspasos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasos")
        Me.menuInventarioTraspasosSalida1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasosSalida")
        Me.Separator24 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioTraspasoPT1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoPT")
        Me.MnuTraspasoEntradaMercancia1 = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoEntradaMercancia")
        Me.menuInventarioTraspasoEntradaBultos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoEntradaBultos")
        Me.menuInventarioTraspasoModTSalida1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoModTSalida")
        Me.menuInventarioTraspasoBTG1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoBTG")
        Me.Separator25 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioTraspasoRDD1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoRDD")
        Me.menuInventarioTraspasoTSG1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoTSG")
        Me.Separator29 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioTEntradaDBF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTEntradaDBF")
        Me.menuInventarioReporteInv = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInv")
        Me.menuInventarioReporteInvPC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvPC")
        Me.menuInventarioReporteInvEN1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvEN")
        Me.menuInventarioReporteInvAA1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvAA")
        Me.menuInventarioReporteInvUP1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvUP")
        Me.menuInventarioReporteInvRG1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvRG")
        Me.Separator30 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioReporteVarios1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteVarios")
        Me.menuListaArticuloDescuentoSAP1 = New Janus.Windows.UI.CommandBars.UICommand("menuListaArticuloDescuentoSAP")
        Me.mnuListaArticulosDescuentoSAPGroup1 = New Janus.Windows.UI.CommandBars.UICommand("mnuListaArticulosDescuentoSAPGroup")
        Me.menuInventarioMasVendidos1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMasVendidos")
        Me.Separator74 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioReporteDifTraslados1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteDifTraslados")
        Me.menuInventarioArtSinMov = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMov")
        Me.menuInventarioArtSinMovPC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovPC")
        Me.Separator26 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioArtSinMovLF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovLF")
        Me.menuInventarioArtSinMovMF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovMF")
        Me.menuInventarioArtSinMovMLF1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovMLF")
        Me.menuInventarioRepOperacional = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioRepOperacional")
        Me.menuInventarioDefectuosos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosos")
        Me.menuInventarioDefectuosoMAD1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosoMAD")
        Me.menuInventarioDefectuososDAD1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuososDAD")
        Me.menuInventarioDefectuosoMADEcm1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosoMADEcm")
        Me.Separator27 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInventarioDesfectuososRDD1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDesfectuososRDD")
        Me.frmRepDefecDet1 = New Janus.Windows.UI.CommandBars.UICommand("frmRepDefecDet")
        Me.menuInventarioReporteDefecEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteDefecEC")
        Me.menuVentasReporteVentaVT = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVT")
        Me.menuVentasReporteVentaVED = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVED")
        Me.menuVentasReporteVentaVXH = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaVXH")
        Me.menuVentasReporteVentaPromXH = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVentaPromXH")
        Me.menuVentasReporteVXHVentaTotal = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVXHVentaTotal")
        Me.menuVentasReporteVXHVentaDetalle = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReporteVXHVentaDetalle")
        Me.menuVentasNotaCreditoManejo = New Janus.Windows.UI.CommandBars.UICommand("menuVentasNotaCreditoManejo")
        Me.menuNotasCreditoReportesConcentrado = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesConcentrado")
        Me.menuNotasCreditoReportesDetallado = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesDetallado")
        Me.menuNotasCreditoReportesParciales = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesParciales")
        Me.menuVentaAnalisisVentaReporte = New Janus.Windows.UI.CommandBars.UICommand("menuVentaAnalisisVentaReporte")
        Me.menuNotasCreditoReportesConcentrado1 = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesConcentrado")
        Me.menuNotasCreditoReportesDetallado1 = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesDetallado")
        Me.menuNotasCreditoReportesParciales1 = New Janus.Windows.UI.CommandBars.UICommand("menuNotasCreditoReportesParciales")
        Me.menuVentasCXCAbono = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCAbono")
        Me.menuVentaCXCCancelarAbono = New Janus.Windows.UI.CommandBars.UICommand("menuVentaCXCCancelarAbono")
        Me.menuVentasCXCEdoCuenta = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCuenta")
        Me.menuVentasCXCEdoCtaXCliente1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCtaXCliente")
        Me.menuVentasCXCEdoCtaXFact1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCtaXFact")
        Me.menuVentaCXCEdoCtaXGeneral1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentaCXCEdoCtaXGeneral")
        Me.menuVentasCXCEdoCtaXCliente = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCtaXCliente")
        Me.menuVentasCXCEdoCtaXFact = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCEdoCtaXFact")
        Me.menuVentaCXCEdoCtaXGeneral = New Janus.Windows.UI.CommandBars.UICommand("menuVentaCXCEdoCtaXGeneral")
        Me.menuVentasCXCReportes = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportes")
        Me.menuVentasCXCReportesCxC1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesCxC")
        Me.menuVentasCXCReportesCxCCanceladas1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesCxCCanceladas")
        Me.menuVentasCXCReportesAbonosRealizados1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesAbonosRealizados")
        Me.menuVentasCXCReportesAbonosCancelado1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesAbonosCancelado")
        Me.menuVentasCXCReportesHistorial1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesHistorial")
        Me.menuVer = New Janus.Windows.UI.CommandBars.UICommand("menuVer")
        Me.menuVerBarra1 = New Janus.Windows.UI.CommandBars.UICommand("menuVerBarra")
        Me.menuVerBarra = New Janus.Windows.UI.CommandBars.UICommand("menuVerBarra")
        Me.menuApartadosRepDApartadoCT = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCT")
        Me.menuApartadosRepDApartadoCD = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCD")
        Me.menuApartadosRepDApartadoCC = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoCC")
        Me.menuApartadosRepDApartadoAV = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoAV")
        Me.menuApartadosRepDApartadoAAV = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDApartadoAAV")
        Me.menuApartadosRepDAbonoAA = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbonoAA")
        Me.menuApartadosRepDAbonoAC = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosRepDAbonoAC")
        Me.menuApartadosCancelarContratosDef = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratosDef")
        Me.menuApartadosCancelarContratoNDCredito = New Janus.Windows.UI.CommandBars.UICommand("menuApartadosCancelarContratoNDCredito")
        Me.menuInventarioMovArticulosPA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosPA")
        Me.menuInventarioMovArticuloTA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticuloTA")
        Me.menuInventarioMovArticulosH2 = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosH2")
        Me.menuInventarioCostodeInvCod = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvCod")
        Me.menuInventarioCostodeInvCodDet = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvCodDet")
        Me.menuInventarioCostodeInvMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMarcas")
        Me.menuInventarioCostodeInvLinea = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvLinea")
        Me.menuInventarioCostodeInvFamilia = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvFamilia")
        Me.menuInventarioCostodeInvUsos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvUsos")
        Me.menuInventarioCostodeInvSucursal = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvSucursal")
        Me.menuInventarioCostodeInvArtCD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvArtCD")
        Me.menuInventarioCostodeInvMLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMLF")
        Me.menuInventarioCostodeInvMF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvMF")
        Me.menuInventarioCostodeInvFM = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvFM")
        Me.menuInventarioCostodeInvRA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioCostodeInvRA")
        Me.menuInventarioTraspasosTE = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasosTE")
        Me.menuInventarioTraspasosSalida = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasosSalida")
        Me.menuInvDefect1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvDefect")
        Me.menuInvDevProv1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvDevProv")
        Me.menuInvAud1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvAud")
        Me.menuInvTraspasoAutorizar1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoAutorizar")
        Me.Separator69 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInvConcInv1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvConcInv")
        Me.menuInvConcVtas1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvConcVtas")
        Me.menuInvTraspasoEC1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoEC")
        Me.menuInvTraspasoErroresCDIST1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoErroresCDIST")
        Me.menuInvTraspasoVentaDist1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoVentaDist")
        Me.Separator70 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuInvTiendas1 = New Janus.Windows.UI.CommandBars.UICommand("menuInvTiendas")
        Me.menuInventarioTraspasoPT = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoPT")
        Me.menuInventarioTraspasoModTSalida = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoModTSalida")
        Me.menuInventarioTraspasoBTG = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoBTG")
        Me.menuInventarioTraspasoRDD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoRDD")
        Me.menuInventarioTraspasoTSG = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoTSG")
        Me.menuInventarioReporteInvPC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvPC")
        Me.menuInventarioReporteInvLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvLF")
        Me.menuInventarioReporteInvLFD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvLFD")
        Me.menuInventarioReporteInvMF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvMF")
        Me.menuInventarioReporteInvMLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvMLF")
        Me.menuInventarioReporteInvOLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvOLF")
        Me.menuInventarioReporteInvEN = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvEN")
        Me.menuInventarioReporteInvAA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvAA")
        Me.menuInventarioReporteInvUP = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvUP")
        Me.menuInventarioReporteInvRG = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteInvRG")
        Me.menuInventarioArtSinMovPC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovPC")
        Me.menuInventarioArtSinMovLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovLF")
        Me.menuInventarioArtSinMovMF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovMF")
        Me.menuInventarioArtSinMovMLF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioArtSinMovMLF")
        Me.menuInventarioDefectuosoMAD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosoMAD")
        Me.menuInventarioDefectuososDAD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuososDAD")
        Me.menuInventarioDesfectuososRDD = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDesfectuososRDD")
        Me.menuUtileriasCompactarArc = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasCompactarArc")
        Me.menuUtileriasGenerarArchivos = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasGenerarArchivos")
        Me.menuUtileriasEliminarDoc = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarDoc")
        Me.menuUtileriasEliminarFolioFac1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolioFac")
        Me.menuUtileriasEliminarFolioCont1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolioCont")
        Me.menuUtileriasEliminarFolAbono1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolAbono")
        Me.menuUtileriasProcArc = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasProcArc")
        Me.menuUtileriasRespaldarArch = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRespaldarArch")
        Me.menuUtileriasRespaldoResDisco1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRespaldoResDisco")
        Me.Separator28 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuUtileriasFormatoDisco1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasFormatoDisco")
        Me.menuUtileriasMovDAuditoria = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasMovDAuditoria")
        Me.menuUtileriasCierreDAño = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasCierreDAño")
        Me.menuUtileriasDatosDSucursal = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasDatosDSucursal")
        Me.menuUtileriasImpDEtiquetas = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasImpDEtiquetas")
        Me.menuUtileriasDepDInv = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasDepDInv")
        Me.menuGeneralesArticulos = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesArticulos")
        Me.menuGeneralesClientes = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesClientes")
        Me.menuGeneralesProveedores = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesProveedores")
        Me.menuGeneralesFamilias = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesFamilias")
        Me.menuGeneralesPlayers = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPlayers")
        Me.menuGeneralesMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesMarcas")
        Me.menuGeneralesSucursales = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesSucursales")
        Me.menuGeneralesUsos = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesUsos")
        Me.menuGeneralesFDePago = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesFDePago")
        Me.menuGeneralesTDeVenta = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTDeVenta")
        Me.menuGeneralesTDeDev = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTDeDev")
        Me.menuGeneralesTDeAjuste = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTDeAjuste")
        Me.menuGeneralesClaveMReg = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesClaveMReg")
        Me.menuGeneralesCAdmvo = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCAdmvo")
        Me.menuGeneralesCtaP = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCtaP")
        Me.menuGeneralesDescuentos = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesDescuentos")
        Me.menuGeneralesManagerT = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesManagerT")
        Me.menuGeneralesLineas = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesLineas")
        Me.menuGeneralesBancos = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesBancos")
        Me.menuUtileriasEliminarFolioFac = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolioFac")
        Me.menuUtileriasEliminarFolioCont = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolioCont")
        Me.menuUtileriasEliminarFolAbono = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasEliminarFolAbono")
        Me.menuUtileriasRespaldoResDisco = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRespaldoResDisco")
        Me.menuUtileriasFormatoDisco = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasFormatoDisco")
        Me.menuUtileriasImpPrecioNor = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasImpPrecioNor")
        Me.menuUtileriasImpPrecioOfert = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasImpPrecioOfert")
        Me.menuUtileriasImpUna = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasImpUna")
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
        Me.menuUtilCambioTalla = New Janus.Windows.UI.CommandBars.UICommand("menuUtilCambioTalla")
        Me.menuUtilCancelarCambioTalla = New Janus.Windows.UI.CommandBars.UICommand("menuUtilCancelarCambioTalla")
        Me.menuUtilModFP = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModFP")
        Me.menuUtilPreciosDContratos = New Janus.Windows.UI.CommandBars.UICommand("menuUtilPreciosDContratos")
        Me.menuUtilRepDTraspasos = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepDTraspasos")
        Me.menuReporteTraspasoTT1 = New Janus.Windows.UI.CommandBars.UICommand("menuReporteTraspasoTT")
        Me.menuUtilRepTraspasoTE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTE")
        Me.menuUtilRepTraspasoTS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTS")
        Me.menuUtilTrasCancelados = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCancelados")
        Me.menuUtilTrasCanceladosDE1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDE")
        Me.menuUtilTrasCanceladosDS1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDS")
        Me.menuUtilTrasCanceladosSG1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosSG")
        Me.menuUtilTrasCanceladosOrigen1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosOrigen")
        Me.menuUtilAnalCosto = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnalCosto")
        Me.menuUtilAnaLU = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnaLU")
        Me.menuUtilAnaIMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuUtilAnaIMarcas")
        Me.menuUtilDifEnCosto = New Janus.Windows.UI.CommandBars.UICommand("menuUtilDifEnCosto")
        Me.menuUtilModAjuste = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjuste")
        Me.menuUtilModAjusteGeneral1 = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteGeneral")
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
        Me.menuGeneralesAlmacen = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesAlmacen")
        Me.menuGeneralesCaja = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCaja")
        Me.menuGeneralesCat = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCat")
        Me.menuGeneralesCiudades = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCiudades")
        Me.menuGeneralesCodigoUPC = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCodigoUPC")
        Me.menuGeneralesColonias = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesColonias")
        Me.menuGeneralesCorridas = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesCorridas")
        Me.menuGeneralesEstados = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesEstados")
        Me.menuGeneralesFamilia = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesFamilia")
        Me.menuGeneralesOrigenes = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesOrigenes")
        Me.menuGeneralesPlaza = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPlaza")
        Me.menuGeneralesPublicaciones = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPublicaciones")
        Me.menuGeneralesStatus = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesStatus")
        Me.menuGeneralesTipoCliente = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoCliente")
        Me.menuGeneralesTipoDescuento = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoDescuento")
        Me.menuGeneralesTipoMov = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoMov")
        Me.menuGeneralesUnidades = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesUnidades")
        Me.menuGeneralesVentas = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesVentas")
        Me.menuGeneralesTipoTarjeta = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoTarjeta")
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
        Me.menuUtileriasUserRoles = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasUserRoles")
        Me.menuUtilRMReporteD = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMReporteD")
        Me.menuUtilRMViolacionInv = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRMViolacionInv")
        Me.menuReporteTraspasoTT = New Janus.Windows.UI.CommandBars.UICommand("menuReporteTraspasoTT")
        Me.menuUtilRepTraspasoTE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTE")
        Me.menuUtilRepTraspasoTS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilRepTraspasoTS")
        Me.menuUtilTrasCanceladosDE = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDE")
        Me.menuUtilTrasCanceladosDS = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosDS")
        Me.menuUtilTrasCanceladosSG = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosSG")
        Me.menuUtilTrasCanceladosOrigen = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTrasCanceladosOrigen")
        Me.menuInventarioMovArticulosHA = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMovArticulosHA")
        Me.menuGeneralesVales = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesVales")
        Me.menuConsultarExistencia = New Janus.Windows.UI.CommandBars.UICommand("menuConsultarExistencia")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.Separator47 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaAcerca1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuRetiros = New Janus.Windows.UI.CommandBars.UICommand("menuRetiros")
        Me.menuGeneralesTipoVenta = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesTipoVenta")
        Me.menuGeneralesPlayer = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesPlayer")
        Me.menuUtilTomadeInventario = New Janus.Windows.UI.CommandBars.UICommand("menuUtilTomadeInventario")
        Me.menuUtilArqCajaFondoCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaFondoCaja")
        Me.menuUtilArqCajaIngresoCaja = New Janus.Windows.UI.CommandBars.UICommand("menuUtilArqCajaIngresoCaja")
        Me.menuUtilModAjusteGeneral = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteGeneral")
        Me.menuUtilModAjusteEntrada = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEntrada")
        Me.menuUtilModAjusteSalida = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteSalida")
        Me.menuUtilModAjusteEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteEliminar")
        Me.menuUtilModAjusteRecibidos = New Janus.Windows.UI.CommandBars.UICommand("menuUtilModAjusteRecibidos")
        Me.menuClientes = New Janus.Windows.UI.CommandBars.UICommand("menuClientes")
        Me.menuClientesClientes1 = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClientes")
        Me.menuClientesClientesDPVL1 = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClientesDPVL")
        Me.menuClienteAsociado = New Janus.Windows.UI.CommandBars.UICommand("menuClienteAsociado")
        Me.menuClientesClienteAsociado = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClienteAsociado")
        Me.mnuHerramientasOpciones = New Janus.Windows.UI.CommandBars.UICommand("mnuHerramientasOpciones")
        Me.menuClientesClientes = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClientes")
        Me.menuClientesAsociados = New Janus.Windows.UI.CommandBars.UICommand("menuClientesAsociados")
        Me.menuClientesClienteDPVale = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClienteDPVale")
        Me.menuClientesClienteDEnTienda = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClienteDEnTienda")
        Me.menuCredito = New Janus.Windows.UI.CommandBars.UICommand("menuCredito")
        Me.menuClientesAsociados2 = New Janus.Windows.UI.CommandBars.UICommand("menuClientesAsociados")
        Me.Separator64 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuClientesClienteDPVale2 = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClienteDPVale")
        Me.menuClientesClienteDEnTienda2 = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClienteDEnTienda")
        Me.menuGeneralesBanco = New Janus.Windows.UI.CommandBars.UICommand("menuGeneralesBanco")
        Me.menuVentasInicioCaja = New Janus.Windows.UI.CommandBars.UICommand("menuVentasInicioCaja")
        Me.menuVentasCierreCaja = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCierreCaja")
        Me.menuVentasRetiros = New Janus.Windows.UI.CommandBars.UICommand("menuVentasRetiros")
        Me.menuVentasACDT = New Janus.Windows.UI.CommandBars.UICommand("menuVentasACDT")
        Me.menuVentasValeCaja = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCaja")
        Me.menuVentasValeCajaManejo1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCajaManejo")
        Me.Separator68 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuVentasValeCajaReporte1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCajaReporte")
        Me.menuInventarioTEntradaDBF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTEntradaDBF")
        Me.menuContabilizacionSegmentoContable1 = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionSegmentoContable")
        Me.Separator66 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuContabilizacion = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacion")
        Me.menuContabilizacionSegmentoContable2 = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionSegmentoContable")
        Me.menuContabilizacionDefinicionAsiento1 = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionDefinicionAsiento")
        Me.menuContabilizacionAsignacionAsiento1 = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionAsignacionAsiento")
        Me.menuContabilizacionSegmentoContable = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionSegmentoContable")
        Me.menuContabilizacionDefinicionAsiento = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionDefinicionAsiento")
        Me.menuContabilizacionAsignacionAsiento = New Janus.Windows.UI.CommandBars.UICommand("menuContabilizacionAsignacionAsiento")
        Me.menuVentasReasignarPlayer = New Janus.Windows.UI.CommandBars.UICommand("menuVentasReasignarPlayer")
        Me.menuVentasValeCajaManejo = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCajaManejo")
        Me.menuVentasValeCajaReporte = New Janus.Windows.UI.CommandBars.UICommand("menuVentasValeCajaReporte")
        Me.menuInventarioReporteVarios = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteVarios")
        Me.menuVentasCambiarFolio = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCambiarFolio")
        Me.menuVentasCXCReportesAbonosRealizados = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesAbonosRealizados")
        Me.menuVentasCXCReportesCxC = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesCxC")
        Me.menuVentasCXCReportesCxCCanceladas = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesCxCCanceladas")
        Me.menuVentasCXCReportesAbonosCancelado = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesAbonosCancelado")
        Me.menuVentasCXCReportesHistorial = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCXCReportesHistorial")
        Me.menuUtilGananciasAdicionales = New Janus.Windows.UI.CommandBars.UICommand("menuUtilGananciasAdicionales")
        Me.menuUtilesLstPrecios = New Janus.Windows.UI.CommandBars.UICommand("menuUtilesLstPrecios")
        Me.menuUtilGenArchCierreDia = New Janus.Windows.UI.CommandBars.UICommand("menuUtilGenArchCierreDia")
        Me.mnuUtileriasConfiguraSAP = New Janus.Windows.UI.CommandBars.UICommand("mnuUtileriasConfiguraSAP")
        Me.mnuUtileriasCargaInicial = New Janus.Windows.UI.CommandBars.UICommand("mnuUtileriasCargaInicial")
        Me.menuUtileriasLoadFacturas = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasLoadFacturas")
        Me.menuGerencial = New Janus.Windows.UI.CommandBars.UICommand("menuGerencial")
        Me.menuConfigurarGerencial1 = New Janus.Windows.UI.CommandBars.UICommand("menuConfigurarGerencial")
        Me.menuTemporadas1 = New Janus.Windows.UI.CommandBars.UICommand("menuTemporadas")
        Me.menuAnticiparMetas1 = New Janus.Windows.UI.CommandBars.UICommand("menuAnticiparMetas")
        Me.menuConfigurarGerencial = New Janus.Windows.UI.CommandBars.UICommand("menuConfigurarGerencial")
        Me.menuTemporadas = New Janus.Windows.UI.CommandBars.UICommand("menuTemporadas")
        Me.menuAnticiparMetas = New Janus.Windows.UI.CommandBars.UICommand("menuAnticiparMetas")
        Me.menuActualizaciones = New Janus.Windows.UI.CommandBars.UICommand("menuActualizaciones")
        Me.menuActualizacionesOpcion1 = New Janus.Windows.UI.CommandBars.UICommand("menuActualizacionesOpcion")
        Me.menuActualizacionesXCodigos1 = New Janus.Windows.UI.CommandBars.UICommand("menuActualizacionesXCodigos")
        Me.mnuActuDescargaImagenes1 = New Janus.Windows.UI.CommandBars.UICommand("mnuActuDescargaImagenes")
        Me.menuActualizacionesOpcion = New Janus.Windows.UI.CommandBars.UICommand("menuActualizacionesOpcion")
        Me.menuUtileriasRutaArvhivos = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasRutaArvhivos")
        Me.menuListaArticuloDescuentoSAP = New Janus.Windows.UI.CommandBars.UICommand("menuListaArticuloDescuentoSAP")
        Me.menuVentasPorCliente = New Janus.Windows.UI.CommandBars.UICommand("menuVentasPorCliente")
        Me.menuExportarGAD = New Janus.Windows.UI.CommandBars.UICommand("menuExportarGAD")
        Me.mnuUtilConfigFotos = New Janus.Windows.UI.CommandBars.UICommand("mnuUtilConfigFotos")
        Me.mnuActuDescargaImagenes = New Janus.Windows.UI.CommandBars.UICommand("mnuActuDescargaImagenes")
        Me.mnuListaArticulosDescuentoSAPGroup = New Janus.Windows.UI.CommandBars.UICommand("mnuListaArticulosDescuentoSAPGroup")
        Me.menuUtileriasNumeroReferencia = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasNumeroReferencia")
        Me.menuInventariolModAjusteGeneral = New Janus.Windows.UI.CommandBars.UICommand("menuInventariolModAjusteGeneral")
        Me.menuInventarioEFExportInfo = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioEFExportInfo")
        Me.MnuUtilCargaArchivosSAP = New Janus.Windows.UI.CommandBars.UICommand("MnuUtilCargaArchivosSAP")
        Me.menuInventarioMasVendidos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioMasVendidos")
        Me.menuAudDxt = New Janus.Windows.UI.CommandBars.UICommand("menuAudDxt")
        Me.CatMotCapMan = New Janus.Windows.UI.CommandBars.UICommand("CatMotCapMan")
        Me.RepMotCapMan = New Janus.Windows.UI.CommandBars.UICommand("RepMotCapMan")
        Me.menuCapturaManual = New Janus.Windows.UI.CommandBars.UICommand("menuCapturaManual")
        Me.CatMotCapMan1 = New Janus.Windows.UI.CommandBars.UICommand("CatMotCapMan")
        Me.RepMotCapMan1 = New Janus.Windows.UI.CommandBars.UICommand("RepMotCapMan")
        Me.menuInvDefect = New Janus.Windows.UI.CommandBars.UICommand("menuInvDefect")
        Me.menuInvDevProv = New Janus.Windows.UI.CommandBars.UICommand("menuInvDevProv")
        Me.menuInvAud = New Janus.Windows.UI.CommandBars.UICommand("menuInvAud")
        Me.menuInvConcInv = New Janus.Windows.UI.CommandBars.UICommand("menuInvConcInv")
        Me.menuInvConcVtas = New Janus.Windows.UI.CommandBars.UICommand("menuInvConcVtas")
        Me.menuInvTiendas = New Janus.Windows.UI.CommandBars.UICommand("menuInvTiendas")
        Me.frmRepDefecDet = New Janus.Windows.UI.CommandBars.UICommand("frmRepDefecDet")
        Me.menuBitacora = New Janus.Windows.UI.CommandBars.UICommand("menuBitacora")
        Me.menuVentasDPValeF = New Janus.Windows.UI.CommandBars.UICommand("menuVentasDPValeF")
        Me.menuUtileriasArchivosDPVF = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasArchivosDPVF")
        Me.menuUtileriasGenArchDPVF = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasGenArchDPVF")
        Me.menuUtileriasReimprimirTickets = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirTickets")
        Me.menuImageGearRegistration = New Janus.Windows.UI.CommandBars.UICommand("menuImageGearRegistration")
        Me.menuUtileriasReimprimirDPVFinanciero = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirDPVFinanciero")
        Me.menuOperacionalMarcas = New Janus.Windows.UI.CommandBars.UICommand("menuOperacionalMarcas")
        Me.menuOperacionalCodigos = New Janus.Windows.UI.CommandBars.UICommand("menuOperacionalCodigos")
        Me.menuVentasCancelarNotaVenta = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarNotaVenta")
        Me.menuInvTraspasoEC = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoEC")
        Me.menuActualizacionesXCodigos = New Janus.Windows.UI.CommandBars.UICommand("menuActualizacionesXCodigos")
        Me.menuUtileriasReimprimirCupon = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirCupon")
        Me.menuInvTraspasoErroresCDIST = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoErroresCDIST")
        Me.menuInventarioTraspasoEntradaBultos = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTraspasoEntradaBultos")
        Me.menuInventarioReporteDifTraslados = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteDifTraslados")
        Me.menuInventarioDefectuosoMADEcm = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioDefectuosoMADEcm")
        Me.menuInventarioSurtirTraspasosSolicitados = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioSurtirTraspasosSolicitados")
        Me.menuInventarioPedCancEC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioPedCancEC")
        Me.menuInvTraspasoVentaDist = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoVentaDist")
        Me.menuInvTraspasoAutorizar = New Janus.Windows.UI.CommandBars.UICommand("menuInvTraspasoAutorizar")
        Me.menuInventarioReporteDefecEC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReporteDefecEC")
        Me.menuInventarioFacturarPedidosEC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioFacturarPedidosEC")
        Me.menuInventarioAsignarGuiaEC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioAsignarGuiaEC")
        Me.menuUtileriasReimprimirVC = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasReimprimirVC")
        Me.MnuFacturacionSinExistencia = New Janus.Windows.UI.CommandBars.UICommand("MnuFacturacionSinExistencia")
        Me.menuSH = New Janus.Windows.UI.CommandBars.UICommand("menuSH")
        Me.MnuFacturacionSinExistencia1 = New Janus.Windows.UI.CommandBars.UICommand("MnuFacturacionSinExistencia")
        Me.menuSurtirPedidosSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuSurtirPedidosSH")
        Me.menuRecibirPedidoSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuRecibirPedidoSH")
        Me.menuFacturarPedidosSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuFacturarPedidosSH")
        Me.menuEnviarPedidoSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuEnviarPedidoSH")
        Me.Separator76 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuPedidosInsurtiblesSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuPedidosInsurtiblesSH")
        Me.MnuCancelacionPedido1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelacionPedido")
        Me.mnuReingresarPedidosCancelados1 = New Janus.Windows.UI.CommandBars.UICommand("mnuReingresarPedidosCancelados")
        Me.menuConsultaExistenciaSH1 = New Janus.Windows.UI.CommandBars.UICommand("menuConsultaExistenciaSH")
        Me.menuSurtirPedidosSH = New Janus.Windows.UI.CommandBars.UICommand("menuSurtirPedidosSH")
        Me.menuPedidosInsurtiblesSH = New Janus.Windows.UI.CommandBars.UICommand("menuPedidosInsurtiblesSH")
        Me.menuRecibirPedidoSH = New Janus.Windows.UI.CommandBars.UICommand("menuRecibirPedidoSH")
        Me.menuEnviarPedidoSH = New Janus.Windows.UI.CommandBars.UICommand("menuEnviarPedidoSH")
        Me.MnuCancelacionPedido = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelacionPedido")
        Me.menuFacturarPedidosSH = New Janus.Windows.UI.CommandBars.UICommand("menuFacturarPedidosSH")
        Me.mnuReingresarPedidosCancelados = New Janus.Windows.UI.CommandBars.UICommand("mnuReingresarPedidosCancelados")
        Me.menuConsultaExistenciaSH = New Janus.Windows.UI.CommandBars.UICommand("menuConsultaExistenciaSH")
        Me.MnuVentasPlayer = New Janus.Windows.UI.CommandBars.UICommand("MnuVentasPlayer")
        Me.MnuMetasTienda1 = New Janus.Windows.UI.CommandBars.UICommand("MnuMetasTienda")
        Me.MnuMetasDiarias1 = New Janus.Windows.UI.CommandBars.UICommand("MnuMetasDiarias")
        Me.MnuMetasDiarias = New Janus.Windows.UI.CommandBars.UICommand("MnuMetasDiarias")
        Me.MnuMetasTienda = New Janus.Windows.UI.CommandBars.UICommand("MnuMetasTienda")
        Me.menuInventarioTF = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioTF")
        Me.MnuTraspasoEntradaVirtual = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoEntradaVirtual")
        Me.menuVentasRecibirOtrosPagos = New Janus.Windows.UI.CommandBars.UICommand("menuVentasRecibirOtrosPagos")
        Me.menuVentasCancelarOtrosPagos = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarOtrosPagos")
        Me.menuUtileriasSaldoDPCard = New Janus.Windows.UI.CommandBars.UICommand("menuUtileriasSaldoDPCard")
        Me.MnuDPCardPuntos = New Janus.Windows.UI.CommandBars.UICommand("MnuDPCardPuntos")
        Me.MnuConsultaDPCardPunto1 = New Janus.Windows.UI.CommandBars.UICommand("MnuConsultaDPCardPunto")
        Me.MnuTraspasoDPCardPunto1 = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoDPCardPunto")
        Me.MnuConsultaDPCardPunto = New Janus.Windows.UI.CommandBars.UICommand("MnuConsultaDPCardPunto")
        Me.MnuTraspasoDPCardPunto = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoDPCardPunto")
        Me.menuInventarioEMT = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioEMT")
        Me.MnuTraspasoEntradaMercancia = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspasoEntradaMercancia")
        Me.menuInventarioReportePedidosEC = New Janus.Windows.UI.CommandBars.UICommand("menuInventarioReportePedidosEC")
        Me.menuClientesClientesDPVL = New Janus.Windows.UI.CommandBars.UICommand("menuClientesClientesDPVL")
        Me.menuCargaNotasCredito = New Janus.Windows.UI.CommandBars.UICommand("menuCargaNotasCredito")
        Me.MnuPinPadBanamex = New Janus.Windows.UI.CommandBars.UICommand("MnuPinPadBanamex")
        Me.MnuPinPadBanamexOffline = New Janus.Windows.UI.CommandBars.UICommand("MnuPinPadBanamexOffline")
        Me.MnuCambioTalla = New Janus.Windows.UI.CommandBars.UICommand("MnuCambioTalla")
        Me.MnuDisposicionEfectivo = New Janus.Windows.UI.CommandBars.UICommand("MnuDisposicionEfectivo")
        Me.MnuNuevaDisposicion1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaDisposicion")
        Me.MnuMonitoreoReproceso1 = New Janus.Windows.UI.CommandBars.UICommand("MnuMonitoreoReproceso")
        Me.MnuDisposicionCancelar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuDisposicionCancelar")
        Me.MnuNuevaDisposicion = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevaDisposicion")
        Me.MnuMonitoreoReproceso = New Janus.Windows.UI.CommandBars.UICommand("MnuMonitoreoReproceso")
        Me.MnuDisposicionCancelar = New Janus.Windows.UI.CommandBars.UICommand("MnuDisposicionCancelar")
        Me.MnuCancelacion = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelacion")
        Me.menuVentasCancelarFactura1 = New Janus.Windows.UI.CommandBars.UICommand("menuVentasCancelarFactura")
        Me.MnuDevolucionTarjeta1 = New Janus.Windows.UI.CommandBars.UICommand("MnuDevolucionTarjeta")
        Me.MnuDevolucionTarjeta = New Janus.Windows.UI.CommandBars.UICommand("MnuDevolucionTarjeta")
        Me.MnuPedidosCompra = New Janus.Windows.UI.CommandBars.UICommand("MnuPedidosCompra")
        Me.MnuRecepcionPedido1 = New Janus.Windows.UI.CommandBars.UICommand("MnuRecepcionPedido")
        Me.MnuDevolucionProveedor1 = New Janus.Windows.UI.CommandBars.UICommand("MnuDevolucionProveedor")
        Me.MnuRecepcionPedido = New Janus.Windows.UI.CommandBars.UICommand("MnuRecepcionPedido")
        Me.MnuDevolucionProveedor = New Janus.Windows.UI.CommandBars.UICommand("MnuDevolucionProveedor")
        Me.MenuDescargaManual2 = New Janus.Windows.UI.CommandBars.UICommand("MenuDescargaManual")
        Me.menuReportesWeb = New Janus.Windows.UI.CommandBars.UICommand("menuReportesWeb")
        Me.menuRepWeb11 = New Janus.Windows.UI.CommandBars.UICommand("menuRepWeb1")
        Me.menuRepWeb1 = New Janus.Windows.UI.CommandBars.UICommand("menuRepWeb1")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.MenuDescargaManual = New Janus.Windows.UI.CommandBars.UICommand("MenuDescargaManual")
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
        Me.UiStatusBar1 = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.uiPanel0Container = New Janus.Windows.UI.Dock.UIPanelInnerContainer()
        Me.uiPanel0 = New Janus.Windows.UI.Dock.UIPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.uiConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uiPanel0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
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
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentas, Me.menuApartados, Me.menuInventarios, Me.menuGenerales, Me.menuUtilerias, Me.menuVentasFacturacion, Me.menuVentasCambioTalla, Me.menuVentaInicio, Me.menuVentasCancelarFactura, Me.menuVentasCierreDia, Me.menuVentasReporteVenta, Me.menuVentaAnalisisVenta, Me.menuVentaNotasCredito, Me.menuVentasCXC, Me.menuVentasAvisosenNotas, Me.menuVentaModDatosFact, Me.menuSalir, Me.menuApartadosContratos, Me.menuApartadosAOA, Me.menuApartadosRepDApartado, Me.menuApartadosRepDAbono, Me.menuApartadosCancelarContratos, Me.menuApartadosEdoCtaXContrato, Me.menuApartadoCancelarAbono, Me.menuInventarioExistdeCodigo, Me.menuInventarioMovArticulos, Me.menuInventarioCostodeInv, Me.menuInventarioTraspasos, Me.menuInventarioReporteInv, Me.menuInventarioArtSinMov, Me.menuInventarioRepOperacional, Me.menuInventarioDefectuosos, Me.menuVentasReporteVentaVT, Me.menuVentasReporteVentaVED, Me.menuVentasReporteVentaVXH, Me.menuVentasReporteVentaPromXH, Me.menuVentasReporteVXHVentaTotal, Me.menuVentasReporteVXHVentaDetalle, Me.menuVentasNotaCreditoManejo, Me.menuNotasCreditoReportesConcentrado, Me.menuNotasCreditoReportesDetallado, Me.menuNotasCreditoReportesParciales, Me.menuVentaAnalisisVentaReporte, Me.menuVentasCXCAbono, Me.menuVentaCXCCancelarAbono, Me.menuVentasCXCEdoCuenta, Me.menuVentasCXCEdoCtaXCliente, Me.menuVentasCXCEdoCtaXFact, Me.menuVentaCXCEdoCtaXGeneral, Me.menuVentasCXCReportes, Me.menuVer, Me.menuVerBarra, Me.menuApartadosRepDApartadoCT, Me.menuApartadosRepDApartadoCD, Me.menuApartadosRepDApartadoCC, Me.menuApartadosRepDApartadoAV, Me.menuApartadosRepDApartadoAAV, Me.menuApartadosRepDAbonoAA, Me.menuApartadosRepDAbonoAC, Me.menuApartadosCancelarContratosDef, Me.menuApartadosCancelarContratoNDCredito, Me.menuInventarioMovArticulosPA, Me.menuInventarioMovArticuloTA, Me.menuInventarioMovArticulosH2, Me.menuInventarioCostodeInvCod, Me.menuInventarioCostodeInvCodDet, Me.menuInventarioCostodeInvMarcas, Me.menuInventarioCostodeInvLinea, Me.menuInventarioCostodeInvFamilia, Me.menuInventarioCostodeInvUsos, Me.menuInventarioCostodeInvSucursal, Me.menuInventarioCostodeInvArtCD, Me.menuInventarioCostodeInvMLF, Me.menuInventarioCostodeInvMF, Me.menuInventarioCostodeInvFM, Me.menuInventarioCostodeInvRA, Me.menuInventarioTraspasosTE, Me.menuInventarioTraspasosSalida, Me.menuInventarioTraspasoPT, Me.menuInventarioTraspasoModTSalida, Me.menuInventarioTraspasoBTG, Me.menuInventarioTraspasoRDD, Me.menuInventarioTraspasoTSG, Me.menuInventarioReporteInvPC, Me.menuInventarioReporteInvLF, Me.menuInventarioReporteInvLFD, Me.menuInventarioReporteInvMF, Me.menuInventarioReporteInvMLF, Me.menuInventarioReporteInvOLF, Me.menuInventarioReporteInvEN, Me.menuInventarioReporteInvAA, Me.menuInventarioReporteInvUP, Me.menuInventarioReporteInvRG, Me.menuInventarioArtSinMovPC, Me.menuInventarioArtSinMovLF, Me.menuInventarioArtSinMovMF, Me.menuInventarioArtSinMovMLF, Me.menuInventarioDefectuosoMAD, Me.menuInventarioDefectuososDAD, Me.menuInventarioDesfectuososRDD, Me.menuUtileriasCompactarArc, Me.menuUtileriasGenerarArchivos, Me.menuUtileriasEliminarDoc, Me.menuUtileriasProcArc, Me.menuUtileriasRespaldarArch, Me.menuUtileriasMovDAuditoria, Me.menuUtileriasCierreDAño, Me.menuUtileriasDatosDSucursal, Me.menuUtileriasImpDEtiquetas, Me.menuUtileriasDepDInv, Me.menuGeneralesArticulos, Me.menuGeneralesClientes, Me.menuGeneralesProveedores, Me.menuGeneralesFamilias, Me.menuGeneralesPlayers, Me.menuGeneralesMarcas, Me.menuGeneralesSucursales, Me.menuGeneralesUsos, Me.menuGeneralesFDePago, Me.menuGeneralesTDeVenta, Me.menuGeneralesTDeDev, Me.menuGeneralesTDeAjuste, Me.menuGeneralesClaveMReg, Me.menuGeneralesCAdmvo, Me.menuGeneralesCtaP, Me.menuGeneralesDescuentos, Me.menuGeneralesManagerT, Me.menuGeneralesLineas, Me.menuGeneralesBancos, Me.menuUtileriasEliminarFolioFac, Me.menuUtileriasEliminarFolioCont, Me.menuUtileriasEliminarFolAbono, Me.menuUtileriasRespaldoResDisco, Me.menuUtileriasFormatoDisco, Me.menuUtileriasImpPrecioNor, Me.menuUtileriasImpPrecioOfert, Me.menuUtileriasImpUna, Me.menuUtilRepMen, Me.menuUtiExportarInfo, Me.menuUtilCambioTalla, Me.menuUtilCancelarCambioTalla, Me.menuUtilModFP, Me.menuUtilPreciosDContratos, Me.menuUtilRepDTraspasos, Me.menuUtilTrasCancelados, Me.menuUtilAnalCosto, Me.menuUtilAnaLU, Me.menuUtilAnaIMarcas, Me.menuUtilDifEnCosto, Me.menuUtilModAjuste, Me.menuUtilBorrarTras, Me.menuUtilRepCostoVenta, Me.menuUtilLiberarCierreDia, Me.menuDesApart, Me.menuUtilArqDCaja, Me.menuUtilRevDApartados, Me.menuUtilAnalDVenta, Me.menuUtilRecDExistencia, Me.menuGeneralesAlmacen, Me.menuGeneralesCaja, Me.menuGeneralesCat, Me.menuGeneralesCiudades, Me.menuGeneralesCodigoUPC, Me.menuGeneralesColonias, Me.menuGeneralesCorridas, Me.menuGeneralesEstados, Me.menuGeneralesFamilia, Me.menuGeneralesOrigenes, Me.menuGeneralesPlaza, Me.menuGeneralesPublicaciones, Me.menuGeneralesStatus, Me.menuGeneralesTipoCliente, Me.menuGeneralesTipoDescuento, Me.menuGeneralesTipoMov, Me.menuGeneralesUnidades, Me.menuGeneralesVentas, Me.menuGeneralesTipoTarjeta, Me.menuUtilRMIncongruencia, Me.menuUtilRMDifHistoriInv, Me.menuUtilRMTraspasoE, Me.menuUtilRMTraspasoS, Me.menuUtilRMTraspasoBSG, Me.menuUtilRMAjusteE, Me.menuUtilRMAjusteS, Me.menuUtilRMAjusteG, Me.menuUtilRMAuditoRet, Me.menuUtilRMAnalisisInv, Me.menuUtilRMCostoSuc, Me.menuUtilRMCostoCodigo, Me.menuUtilRMExistenciaN, Me.menuUtilRMArticulosA, Me.menuUtilRMDescuentoO, Me.menuUtilRMReporteA, Me.menuUtileriasUserRoles, Me.menuUtilRMReporteD, Me.menuUtilRMViolacionInv, Me.menuReporteTraspasoTT, Me.menuUtilRepTraspasoTE, Me.menuUtilRepTraspasoTS, Me.menuUtilTrasCanceladosDE, Me.menuUtilTrasCanceladosDS, Me.menuUtilTrasCanceladosSG, Me.menuUtilTrasCanceladosOrigen, Me.menuInventarioMovArticulosHA, Me.menuGeneralesVales, Me.menuConsultarExistencia, Me.menuAyuda, Me.menuAyudaTema, Me.menuAyudaAcerca, Me.menuRetiros, Me.menuGeneralesTipoVenta, Me.menuGeneralesPlayer, Me.menuUtilTomadeInventario, Me.menuUtilArqCajaFondoCaja, Me.menuUtilArqCajaIngresoCaja, Me.menuUtilModAjusteGeneral, Me.menuUtilModAjusteEntrada, Me.menuUtilModAjusteSalida, Me.menuUtilModAjusteEliminar, Me.menuUtilModAjusteRecibidos, Me.menuClientes, Me.menuClienteAsociado, Me.menuClientesClienteAsociado, Me.mnuHerramientasOpciones, Me.menuClientesClientes, Me.menuClientesAsociados, Me.menuClientesClienteDPVale, Me.menuClientesClienteDEnTienda, Me.menuCredito, Me.menuGeneralesBanco, Me.menuVentasInicioCaja, Me.menuVentasCierreCaja, Me.menuVentasRetiros, Me.menuVentasACDT, Me.menuVentasValeCaja, Me.menuInventarioTEntradaDBF, Me.menuContabilizacion, Me.menuContabilizacionSegmentoContable, Me.menuContabilizacionDefinicionAsiento, Me.menuContabilizacionAsignacionAsiento, Me.menuVentasReasignarPlayer, Me.menuVentasValeCajaManejo, Me.menuVentasValeCajaReporte, Me.menuInventarioReporteVarios, Me.menuVentasCambiarFolio, Me.menuVentasCXCReportesAbonosRealizados, Me.menuVentasCXCReportesCxC, Me.menuVentasCXCReportesCxCCanceladas, Me.menuVentasCXCReportesAbonosCancelado, Me.menuVentasCXCReportesHistorial, Me.menuUtilGananciasAdicionales, Me.menuUtilesLstPrecios, Me.menuUtilGenArchCierreDia, Me.mnuUtileriasConfiguraSAP, Me.mnuUtileriasCargaInicial, Me.menuUtileriasLoadFacturas, Me.menuGerencial, Me.menuConfigurarGerencial, Me.menuTemporadas, Me.menuAnticiparMetas, Me.menuActualizaciones, Me.menuActualizacionesOpcion, Me.menuUtileriasRutaArvhivos, Me.menuListaArticuloDescuentoSAP, Me.menuVentasPorCliente, Me.menuExportarGAD, Me.mnuUtilConfigFotos, Me.mnuActuDescargaImagenes, Me.mnuListaArticulosDescuentoSAPGroup, Me.menuUtileriasNumeroReferencia, Me.menuInventariolModAjusteGeneral, Me.menuInventarioEFExportInfo, Me.MnuUtilCargaArchivosSAP, Me.menuInventarioMasVendidos, Me.menuAudDxt, Me.CatMotCapMan, Me.RepMotCapMan, Me.menuCapturaManual, Me.menuInvDefect, Me.menuInvDevProv, Me.menuInvAud, Me.menuInvConcInv, Me.menuInvConcVtas, Me.menuInvTiendas, Me.frmRepDefecDet, Me.menuBitacora, Me.menuVentasDPValeF, Me.menuUtileriasArchivosDPVF, Me.menuUtileriasGenArchDPVF, Me.menuUtileriasReimprimirTickets, Me.menuImageGearRegistration, Me.menuUtileriasReimprimirDPVFinanciero, Me.menuOperacionalMarcas, Me.menuOperacionalCodigos, Me.menuVentasCancelarNotaVenta, Me.menuInvTraspasoEC, Me.menuActualizacionesXCodigos, Me.menuUtileriasReimprimirCupon, Me.menuInvTraspasoErroresCDIST, Me.menuInventarioTraspasoEntradaBultos, Me.menuInventarioReporteDifTraslados, Me.menuInventarioDefectuosoMADEcm, Me.menuInventarioSurtirTraspasosSolicitados, Me.menuInventarioPedCancEC, Me.menuInvTraspasoVentaDist, Me.menuInvTraspasoAutorizar, Me.menuInventarioReporteDefecEC, Me.menuInventarioFacturarPedidosEC, Me.menuInventarioAsignarGuiaEC, Me.menuUtileriasReimprimirVC, Me.MnuFacturacionSinExistencia, Me.menuSH, Me.menuSurtirPedidosSH, Me.menuPedidosInsurtiblesSH, Me.menuRecibirPedidoSH, Me.menuEnviarPedidoSH, Me.MnuCancelacionPedido, Me.menuFacturarPedidosSH, Me.mnuReingresarPedidosCancelados, Me.menuConsultaExistenciaSH, Me.MnuVentasPlayer, Me.MnuMetasDiarias, Me.MnuMetasTienda, Me.menuInventarioTF, Me.MnuTraspasoEntradaVirtual, Me.menuVentasRecibirOtrosPagos, Me.menuVentasCancelarOtrosPagos, Me.menuUtileriasSaldoDPCard, Me.MnuDPCardPuntos, Me.MnuConsultaDPCardPunto, Me.MnuTraspasoDPCardPunto, Me.menuInventarioEMT, Me.MnuTraspasoEntradaMercancia, Me.menuInventarioReportePedidosEC, Me.menuClientesClientesDPVL, Me.menuCargaNotasCredito, Me.MnuPinPadBanamex, Me.MnuPinPadBanamexOffline, Me.MnuCambioTalla, Me.MnuDisposicionEfectivo, Me.MnuNuevaDisposicion, Me.MnuMonitoreoReproceso, Me.MnuDisposicionCancelar, Me.MnuCancelacion, Me.MnuDevolucionTarjeta, Me.MnuPedidosCompra, Me.MnuRecepcionPedido, Me.MnuDevolucionProveedor, Me.MenuDescargaManual2, Me.menuReportesWeb, Me.menuRepWeb1})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("05e90427-94bb-4c58-9aad-7b16d21d644e")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentas1, Me.menuApartados1, Me.menuInventarios1, Me.menuGenerales1, Me.menuUtilerias1, Me.menuClientes1, Me.menuCredito1, Me.menuVer1, Me.menuGerencial1, Me.menuSH1, Me.MnuDPCardPuntos1, Me.menuActualizaciones1, Me.MnuVentasPlayer1, Me.MenuDescargaManual1, Me.menuAyuda1, Me.menuSalir1, Me.menuReportesWeb1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(804, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuVentas1
        '
        Me.menuVentas1.Key = "menuVentas"
        Me.menuVentas1.Name = "menuVentas1"
        '
        'menuApartados1
        '
        Me.menuApartados1.Key = "menuApartados"
        Me.menuApartados1.Name = "menuApartados1"
        '
        'menuInventarios1
        '
        Me.menuInventarios1.Key = "menuInventarios"
        Me.menuInventarios1.Name = "menuInventarios1"
        '
        'menuGenerales1
        '
        Me.menuGenerales1.Key = "menuGenerales"
        Me.menuGenerales1.Name = "menuGenerales1"
        Me.menuGenerales1.Text = "&Catalogos"
        Me.menuGenerales1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilerias1
        '
        Me.menuUtilerias1.Key = "menuUtilerias"
        Me.menuUtilerias1.Name = "menuUtilerias1"
        '
        'menuClientes1
        '
        Me.menuClientes1.Key = "menuClientes"
        Me.menuClientes1.Name = "menuClientes1"
        '
        'menuCredito1
        '
        Me.menuCredito1.Key = "menuCredito"
        Me.menuCredito1.Name = "menuCredito1"
        Me.menuCredito1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVer1
        '
        Me.menuVer1.Key = "menuVer"
        Me.menuVer1.Name = "menuVer1"
        Me.menuVer1.Text = "V&er"
        Me.menuVer1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuGerencial1
        '
        Me.menuGerencial1.Key = "menuGerencial"
        Me.menuGerencial1.Name = "menuGerencial1"
        Me.menuGerencial1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuSH1
        '
        Me.menuSH1.Key = "menuSH"
        Me.menuSH1.Name = "menuSH1"
        Me.menuSH1.Text = "Si Hay"
        '
        'MnuDPCardPuntos1
        '
        Me.MnuDPCardPuntos1.Key = "MnuDPCardPuntos"
        Me.MnuDPCardPuntos1.Name = "MnuDPCardPuntos1"
        Me.MnuDPCardPuntos1.Text = "&DPCard Puntos"
        '
        'menuActualizaciones1
        '
        Me.menuActualizaciones1.Key = "menuActualizaciones"
        Me.menuActualizaciones1.Name = "menuActualizaciones1"
        '
        'MnuVentasPlayer1
        '
        Me.MnuVentasPlayer1.Key = "MnuVentasPlayer"
        Me.MnuVentasPlayer1.Name = "MnuVentasPlayer1"
        Me.MnuVentasPlayer1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MenuDescargaManual1
        '
        Me.MenuDescargaManual1.Key = "MenuDescargaManual"
        Me.MenuDescargaManual1.Name = "MenuDescargaManual1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        Me.menuAyuda1.Text = "Ay&uda"
        Me.menuAyuda1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        Me.menuSalir1.Text = "Salir"
        Me.menuSalir1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuReportesWeb1
        '
        Me.menuReportesWeb1.Key = "menuReportesWeb"
        Me.menuReportesWeb1.Name = "menuReportesWeb1"
        Me.menuReportesWeb1.Text = "Reportes"
        Me.menuReportesWeb1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentas
        '
        Me.menuVentas.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasFacturacion1, Me.MnuCancelacion1, Me.menuVentasCancelarNotaVenta1, Me.Separator50, Me.menuVentasCambioTalla1, Me.Separator9, Me.menuVentaInicio1, Me.menuVentasInicioCaja1, Me.menuVentasCierreDia1, Me.menuVentasCierreCaja1, Me.Separator61, Me.menuVentasRetiros1, Me.Separator10, Me.menuVentasReporteVenta1, Me.menuVentaAnalisisVenta1, Me.Separator11, Me.menuVentaNotasCredito1, Me.menuVentasCXC1, Me.menuVentasAvisosenNotas1, Me.Separator49, Me.menuVentaModDatosFact1, Me.menuVentasReasignarPlayer1, Me.Separator65, Me.menuVentasValeCaja1, Me.menuVentasDPValeF1, Me.Separator78, Me.menuVentasRecibirOtrosPagos1, Me.menuVentasCancelarOtrosPagos1})
        Me.menuVentas.Key = "menuVentas"
        Me.menuVentas.Name = "menuVentas"
        Me.menuVentas.Text = "&Ventas"
        '
        'menuVentasFacturacion1
        '
        Me.menuVentasFacturacion1.Image = CType(resources.GetObject("menuVentasFacturacion1.Image"), System.Drawing.Image)
        Me.menuVentasFacturacion1.Key = "menuVentasFacturacion"
        Me.menuVentasFacturacion1.Name = "menuVentasFacturacion1"
        '
        'MnuCancelacion1
        '
        Me.MnuCancelacion1.Key = "MnuCancelacion"
        Me.MnuCancelacion1.Name = "MnuCancelacion1"
        '
        'menuVentasCancelarNotaVenta1
        '
        Me.menuVentasCancelarNotaVenta1.Key = "menuVentasCancelarNotaVenta"
        Me.menuVentasCancelarNotaVenta1.Name = "menuVentasCancelarNotaVenta1"
        Me.menuVentasCancelarNotaVenta1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator50
        '
        Me.Separator50.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator50.Key = "Separator"
        Me.Separator50.Name = "Separator50"
        '
        'menuVentasCambioTalla1
        '
        Me.menuVentasCambioTalla1.Image = CType(resources.GetObject("menuVentasCambioTalla1.Image"), System.Drawing.Image)
        Me.menuVentasCambioTalla1.Key = "menuVentasCambioTalla"
        Me.menuVentasCambioTalla1.Name = "menuVentasCambioTalla1"
        Me.menuVentasCambioTalla1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuVentaInicio1
        '
        Me.menuVentaInicio1.Image = CType(resources.GetObject("menuVentaInicio1.Image"), System.Drawing.Image)
        Me.menuVentaInicio1.Key = "menuVentaInicio"
        Me.menuVentaInicio1.Name = "menuVentaInicio1"
        '
        'menuVentasInicioCaja1
        '
        Me.menuVentasInicioCaja1.Image = CType(resources.GetObject("menuVentasInicioCaja1.Image"), System.Drawing.Image)
        Me.menuVentasInicioCaja1.Key = "menuVentasInicioCaja"
        Me.menuVentasInicioCaja1.Name = "menuVentasInicioCaja1"
        '
        'menuVentasCierreDia1
        '
        Me.menuVentasCierreDia1.Image = CType(resources.GetObject("menuVentasCierreDia1.Image"), System.Drawing.Image)
        Me.menuVentasCierreDia1.Key = "menuVentasCierreDia"
        Me.menuVentasCierreDia1.Name = "menuVentasCierreDia1"
        '
        'menuVentasCierreCaja1
        '
        Me.menuVentasCierreCaja1.Image = CType(resources.GetObject("menuVentasCierreCaja1.Image"), System.Drawing.Image)
        Me.menuVentasCierreCaja1.Key = "menuVentasCierreCaja"
        Me.menuVentasCierreCaja1.Name = "menuVentasCierreCaja1"
        '
        'Separator61
        '
        Me.Separator61.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator61.Key = "Separator"
        Me.Separator61.Name = "Separator61"
        '
        'menuVentasRetiros1
        '
        Me.menuVentasRetiros1.Image = CType(resources.GetObject("menuVentasRetiros1.Image"), System.Drawing.Image)
        Me.menuVentasRetiros1.Key = "menuVentasRetiros"
        Me.menuVentasRetiros1.Name = "menuVentasRetiros1"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuVentasReporteVenta1
        '
        Me.menuVentasReporteVenta1.Key = "menuVentasReporteVenta"
        Me.menuVentasReporteVenta1.Name = "menuVentasReporteVenta1"
        '
        'menuVentaAnalisisVenta1
        '
        Me.menuVentaAnalisisVenta1.Key = "menuVentaAnalisisVenta"
        Me.menuVentaAnalisisVenta1.Name = "menuVentaAnalisisVenta1"
        '
        'Separator11
        '
        Me.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator11.Key = "Separator"
        Me.Separator11.Name = "Separator11"
        '
        'menuVentaNotasCredito1
        '
        Me.menuVentaNotasCredito1.Image = CType(resources.GetObject("menuVentaNotasCredito1.Image"), System.Drawing.Image)
        Me.menuVentaNotasCredito1.Key = "menuVentaNotasCredito"
        Me.menuVentaNotasCredito1.Name = "menuVentaNotasCredito1"
        '
        'menuVentasCXC1
        '
        Me.menuVentasCXC1.Image = CType(resources.GetObject("menuVentasCXC1.Image"), System.Drawing.Image)
        Me.menuVentasCXC1.Key = "menuVentasCXC"
        Me.menuVentasCXC1.Name = "menuVentasCXC1"
        Me.menuVentasCXC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasAvisosenNotas1
        '
        Me.menuVentasAvisosenNotas1.Image = CType(resources.GetObject("menuVentasAvisosenNotas1.Image"), System.Drawing.Image)
        Me.menuVentasAvisosenNotas1.Key = "menuVentasAvisosenNotas"
        Me.menuVentasAvisosenNotas1.Name = "menuVentasAvisosenNotas1"
        Me.menuVentasAvisosenNotas1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator49
        '
        Me.Separator49.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator49.Key = "Separator"
        Me.Separator49.Name = "Separator49"
        '
        'menuVentaModDatosFact1
        '
        Me.menuVentaModDatosFact1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuVentaModDatosFact1.Image = CType(resources.GetObject("menuVentaModDatosFact1.Image"), System.Drawing.Image)
        Me.menuVentaModDatosFact1.Key = "menuVentaModDatosFact"
        Me.menuVentaModDatosFact1.Name = "menuVentaModDatosFact1"
        '
        'menuVentasReasignarPlayer1
        '
        Me.menuVentasReasignarPlayer1.Key = "menuVentasReasignarPlayer"
        Me.menuVentasReasignarPlayer1.Name = "menuVentasReasignarPlayer1"
        Me.menuVentasReasignarPlayer1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator65
        '
        Me.Separator65.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator65.Key = "Separator"
        Me.Separator65.Name = "Separator65"
        '
        'menuVentasValeCaja1
        '
        Me.menuVentasValeCaja1.Key = "menuVentasValeCaja"
        Me.menuVentasValeCaja1.Name = "menuVentasValeCaja1"
        Me.menuVentasValeCaja1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasDPValeF1
        '
        Me.menuVentasDPValeF1.Key = "menuVentasDPValeF"
        Me.menuVentasDPValeF1.Name = "menuVentasDPValeF1"
        Me.menuVentasDPValeF1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator78
        '
        Me.Separator78.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator78.Key = "Separator"
        Me.Separator78.Name = "Separator78"
        '
        'menuVentasRecibirOtrosPagos1
        '
        Me.menuVentasRecibirOtrosPagos1.Key = "menuVentasRecibirOtrosPagos"
        Me.menuVentasRecibirOtrosPagos1.Name = "menuVentasRecibirOtrosPagos1"
        '
        'menuVentasCancelarOtrosPagos1
        '
        Me.menuVentasCancelarOtrosPagos1.Key = "menuVentasCancelarOtrosPagos"
        Me.menuVentasCancelarOtrosPagos1.Name = "menuVentasCancelarOtrosPagos1"
        '
        'menuApartados
        '
        Me.menuApartados.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuApartadosContratos1, Me.menuApartadosCancelarContratos1, Me.Separator51, Me.menuApartadosAOA1, Me.menuApartadoCancelarAbono1, Me.Separator12, Me.menuApartadosRepDApartado1, Me.menuApartadosRepDAbono1, Me.Separator13, Me.menuApartadosEdoCtaXContrato1})
        Me.menuApartados.Key = "menuApartados"
        Me.menuApartados.Name = "menuApartados"
        Me.menuApartados.Text = "&Apartados"
        '
        'menuApartadosContratos1
        '
        Me.menuApartadosContratos1.Image = CType(resources.GetObject("menuApartadosContratos1.Image"), System.Drawing.Image)
        Me.menuApartadosContratos1.Key = "menuApartadosContratos"
        Me.menuApartadosContratos1.Name = "menuApartadosContratos1"
        '
        'menuApartadosCancelarContratos1
        '
        Me.menuApartadosCancelarContratos1.Image = CType(resources.GetObject("menuApartadosCancelarContratos1.Image"), System.Drawing.Image)
        Me.menuApartadosCancelarContratos1.Key = "menuApartadosCancelarContratos"
        Me.menuApartadosCancelarContratos1.Name = "menuApartadosCancelarContratos1"
        '
        'Separator51
        '
        Me.Separator51.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator51.Key = "Separator"
        Me.Separator51.Name = "Separator51"
        '
        'menuApartadosAOA1
        '
        Me.menuApartadosAOA1.Image = CType(resources.GetObject("menuApartadosAOA1.Image"), System.Drawing.Image)
        Me.menuApartadosAOA1.Key = "menuApartadosAOA"
        Me.menuApartadosAOA1.Name = "menuApartadosAOA1"
        '
        'menuApartadoCancelarAbono1
        '
        Me.menuApartadoCancelarAbono1.Enabled = Janus.Windows.UI.InheritableBoolean.[True]
        Me.menuApartadoCancelarAbono1.Image = CType(resources.GetObject("menuApartadoCancelarAbono1.Image"), System.Drawing.Image)
        Me.menuApartadoCancelarAbono1.Key = "menuApartadoCancelarAbono"
        Me.menuApartadoCancelarAbono1.Name = "menuApartadoCancelarAbono1"
        Me.menuApartadoCancelarAbono1.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'Separator12
        '
        Me.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator12.Key = "Separator"
        Me.Separator12.Name = "Separator12"
        '
        'menuApartadosRepDApartado1
        '
        Me.menuApartadosRepDApartado1.Image = CType(resources.GetObject("menuApartadosRepDApartado1.Image"), System.Drawing.Image)
        Me.menuApartadosRepDApartado1.Key = "menuApartadosRepDApartado"
        Me.menuApartadosRepDApartado1.Name = "menuApartadosRepDApartado1"
        '
        'menuApartadosRepDAbono1
        '
        Me.menuApartadosRepDAbono1.Image = CType(resources.GetObject("menuApartadosRepDAbono1.Image"), System.Drawing.Image)
        Me.menuApartadosRepDAbono1.Key = "menuApartadosRepDAbono"
        Me.menuApartadosRepDAbono1.Name = "menuApartadosRepDAbono1"
        Me.menuApartadosRepDAbono1.Text = "Reportes de Abonos"
        '
        'Separator13
        '
        Me.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator13.Key = "Separator"
        Me.Separator13.Name = "Separator13"
        '
        'menuApartadosEdoCtaXContrato1
        '
        Me.menuApartadosEdoCtaXContrato1.Image = CType(resources.GetObject("menuApartadosEdoCtaXContrato1.Image"), System.Drawing.Image)
        Me.menuApartadosEdoCtaXContrato1.Key = "menuApartadosEdoCtaXContrato"
        Me.menuApartadosEdoCtaXContrato1.Name = "menuApartadosEdoCtaXContrato1"
        '
        'menuInventarios
        '
        Me.menuInventarios.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioExistdeCodigo1, Me.Separator52, Me.menuInventarioMovArticulos1, Me.menuInventarioCostodeInv1, Me.Separator14, Me.menuInventarioTraspasos1, Me.Separator15, Me.menuInventarioReporteInv1, Me.menuInventarioArtSinMov1, Me.Separator53, Me.menuInventarioRepOperacional1, Me.Separator16, Me.menuInventarioDefectuosos1, Me.menuInventariolModAjusteGeneral1, Me.Separator58, Me.MnuPedidosCompra1, Me.menuAudDxt1, Me.Separator75, Me.menuInventarioSurtirTraspasosSolicitados1, Me.menuInventarioReportePedidosEC1, Me.menuInventarioFacturarPedidosEC1, Me.menuInventarioAsignarGuiaEC1, Me.menuInventarioPedCancEC1, Me.Separator77, Me.menuInventarioTF1, Me.MnuTraspasoEntradaVirtual1, Me.Separator80})
        Me.menuInventarios.Key = "menuInventarios"
        Me.menuInventarios.Name = "menuInventarios"
        Me.menuInventarios.Text = "&Inventarios"
        '
        'menuInventarioExistdeCodigo1
        '
        Me.menuInventarioExistdeCodigo1.Image = CType(resources.GetObject("menuInventarioExistdeCodigo1.Image"), System.Drawing.Image)
        Me.menuInventarioExistdeCodigo1.Key = "menuInventarioExistdeCodigo"
        Me.menuInventarioExistdeCodigo1.Name = "menuInventarioExistdeCodigo1"
        Me.menuInventarioExistdeCodigo1.Text = "Existencia de Artículos"
        '
        'Separator52
        '
        Me.Separator52.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator52.Key = "Separator"
        Me.Separator52.Name = "Separator52"
        '
        'menuInventarioMovArticulos1
        '
        Me.menuInventarioMovArticulos1.Image = CType(resources.GetObject("menuInventarioMovArticulos1.Image"), System.Drawing.Image)
        Me.menuInventarioMovArticulos1.Key = "menuInventarioMovArticulos"
        Me.menuInventarioMovArticulos1.Name = "menuInventarioMovArticulos1"
        '
        'menuInventarioCostodeInv1
        '
        Me.menuInventarioCostodeInv1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioCostodeInv1.Image = CType(resources.GetObject("menuInventarioCostodeInv1.Image"), System.Drawing.Image)
        Me.menuInventarioCostodeInv1.Key = "menuInventarioCostodeInv"
        Me.menuInventarioCostodeInv1.Name = "menuInventarioCostodeInv1"
        Me.menuInventarioCostodeInv1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator14
        '
        Me.Separator14.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator14.Key = "Separator"
        Me.Separator14.Name = "Separator14"
        '
        'menuInventarioTraspasos1
        '
        Me.menuInventarioTraspasos1.Image = CType(resources.GetObject("menuInventarioTraspasos1.Image"), System.Drawing.Image)
        Me.menuInventarioTraspasos1.Key = "menuInventarioTraspasos"
        Me.menuInventarioTraspasos1.Name = "menuInventarioTraspasos1"
        '
        'Separator15
        '
        Me.Separator15.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator15.Key = "Separator"
        Me.Separator15.Name = "Separator15"
        '
        'menuInventarioReporteInv1
        '
        Me.menuInventarioReporteInv1.Image = CType(resources.GetObject("menuInventarioReporteInv1.Image"), System.Drawing.Image)
        Me.menuInventarioReporteInv1.Key = "menuInventarioReporteInv"
        Me.menuInventarioReporteInv1.Name = "menuInventarioReporteInv1"
        '
        'menuInventarioArtSinMov1
        '
        Me.menuInventarioArtSinMov1.Image = CType(resources.GetObject("menuInventarioArtSinMov1.Image"), System.Drawing.Image)
        Me.menuInventarioArtSinMov1.Key = "menuInventarioArtSinMov"
        Me.menuInventarioArtSinMov1.Name = "menuInventarioArtSinMov1"
        '
        'Separator53
        '
        Me.Separator53.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator53.Key = "Separator"
        Me.Separator53.Name = "Separator53"
        Me.Separator53.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioRepOperacional1
        '
        Me.menuInventarioRepOperacional1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioRepOperacional1.Image = CType(resources.GetObject("menuInventarioRepOperacional1.Image"), System.Drawing.Image)
        Me.menuInventarioRepOperacional1.Key = "menuInventarioRepOperacional"
        Me.menuInventarioRepOperacional1.Name = "menuInventarioRepOperacional1"
        Me.menuInventarioRepOperacional1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator16
        '
        Me.Separator16.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator16.Key = "Separator"
        Me.Separator16.Name = "Separator16"
        '
        'menuInventarioDefectuosos1
        '
        Me.menuInventarioDefectuosos1.Image = CType(resources.GetObject("menuInventarioDefectuosos1.Image"), System.Drawing.Image)
        Me.menuInventarioDefectuosos1.Key = "menuInventarioDefectuosos"
        Me.menuInventarioDefectuosos1.Name = "menuInventarioDefectuosos1"
        '
        'menuInventariolModAjusteGeneral1
        '
        Me.menuInventariolModAjusteGeneral1.Key = "menuInventariolModAjusteGeneral"
        Me.menuInventariolModAjusteGeneral1.Name = "menuInventariolModAjusteGeneral1"
        Me.menuInventariolModAjusteGeneral1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator58
        '
        Me.Separator58.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator58.Key = "Separator"
        Me.Separator58.Name = "Separator58"
        '
        'MnuPedidosCompra1
        '
        Me.MnuPedidosCompra1.Image = CType(resources.GetObject("MnuPedidosCompra1.Image"), System.Drawing.Image)
        Me.MnuPedidosCompra1.Key = "MnuPedidosCompra"
        Me.MnuPedidosCompra1.Name = "MnuPedidosCompra1"
        '
        'menuAudDxt1
        '
        Me.menuAudDxt1.Key = "menuAudDxt"
        Me.menuAudDxt1.Name = "menuAudDxt1"
        '
        'Separator75
        '
        Me.Separator75.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator75.Key = "Separator"
        Me.Separator75.Name = "Separator75"
        '
        'menuInventarioSurtirTraspasosSolicitados1
        '
        Me.menuInventarioSurtirTraspasosSolicitados1.Icon = CType(resources.GetObject("menuInventarioSurtirTraspasosSolicitados1.Icon"), System.Drawing.Icon)
        Me.menuInventarioSurtirTraspasosSolicitados1.Key = "menuInventarioSurtirTraspasosSolicitados"
        Me.menuInventarioSurtirTraspasosSolicitados1.Name = "menuInventarioSurtirTraspasosSolicitados1"
        Me.menuInventarioSurtirTraspasosSolicitados1.Text = "Enviar Pedidos de Ecommerce"
        '
        'menuInventarioReportePedidosEC1
        '
        Me.menuInventarioReportePedidosEC1.Key = "menuInventarioReportePedidosEC"
        Me.menuInventarioReportePedidosEC1.Name = "menuInventarioReportePedidosEC1"
        '
        'menuInventarioFacturarPedidosEC1
        '
        Me.menuInventarioFacturarPedidosEC1.Key = "menuInventarioFacturarPedidosEC"
        Me.menuInventarioFacturarPedidosEC1.Name = "menuInventarioFacturarPedidosEC1"
        Me.menuInventarioFacturarPedidosEC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioAsignarGuiaEC1
        '
        Me.menuInventarioAsignarGuiaEC1.Key = "menuInventarioAsignarGuiaEC"
        Me.menuInventarioAsignarGuiaEC1.Name = "menuInventarioAsignarGuiaEC1"
        Me.menuInventarioAsignarGuiaEC1.Text = "Asignar Guía a Pedidos de Ecommerce"
        Me.menuInventarioAsignarGuiaEC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioPedCancEC1
        '
        Me.menuInventarioPedCancEC1.Key = "menuInventarioPedCancEC"
        Me.menuInventarioPedCancEC1.Name = "menuInventarioPedCancEC1"
        Me.menuInventarioPedCancEC1.Text = "Cancelar Pedidos de Ecommerce"
        Me.menuInventarioPedCancEC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator77
        '
        Me.Separator77.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator77.Key = "SeparatorTF"
        Me.Separator77.Name = "Separator77"
        '
        'menuInventarioTF1
        '
        Me.menuInventarioTF1.Icon = CType(resources.GetObject("menuInventarioTF1.Icon"), System.Drawing.Icon)
        Me.menuInventarioTF1.Key = "menuInventarioTF"
        Me.menuInventarioTF1.Name = "menuInventarioTF1"
        '
        'MnuTraspasoEntradaVirtual1
        '
        Me.MnuTraspasoEntradaVirtual1.Image = CType(resources.GetObject("MnuTraspasoEntradaVirtual1.Image"), System.Drawing.Image)
        Me.MnuTraspasoEntradaVirtual1.Key = "MnuTraspasoEntradaVirtual"
        Me.MnuTraspasoEntradaVirtual1.Name = "MnuTraspasoEntradaVirtual1"
        '
        'Separator80
        '
        Me.Separator80.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator80.Key = "Separator"
        Me.Separator80.Name = "Separator80"
        '
        'menuGenerales
        '
        Me.menuGenerales.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuGeneralesArticulos1, Me.menuGeneralesFamilias1, Me.menuGeneralesFDePago1, Me.menuGeneralesLineas1, Me.menuGeneralesMarcas1, Me.menuGeneralesUsos1, Me.menuGeneralesDescuentos1, Me.Separator35, Me.menuGeneralesAlmacen1, Me.menuGeneralesBanco1, Me.menuGeneralesCaja1, Me.menuGeneralesCat1, Me.menuGeneralesCiudades1, Me.menuGeneralesColonias1, Me.menuGeneralesEstados1, Me.menuGeneralesPlayer1, Me.menuGeneralesPlaza1, Me.menuGeneralesTipoDescuento1, Me.menuGeneralesTipoTarjeta1, Me.menuGeneralesTipoVenta1, Me.menuGeneralesVales1})
        Me.menuGenerales.Key = "menuGenerales"
        Me.menuGenerales.Name = "menuGenerales"
        Me.menuGenerales.Text = "&Generales"
        '
        'menuGeneralesArticulos1
        '
        Me.menuGeneralesArticulos1.Image = CType(resources.GetObject("menuGeneralesArticulos1.Image"), System.Drawing.Image)
        Me.menuGeneralesArticulos1.Key = "menuGeneralesArticulos"
        Me.menuGeneralesArticulos1.Name = "menuGeneralesArticulos1"
        '
        'menuGeneralesFamilias1
        '
        Me.menuGeneralesFamilias1.Image = CType(resources.GetObject("menuGeneralesFamilias1.Image"), System.Drawing.Image)
        Me.menuGeneralesFamilias1.Key = "menuGeneralesFamilias"
        Me.menuGeneralesFamilias1.Name = "menuGeneralesFamilias1"
        '
        'menuGeneralesFDePago1
        '
        Me.menuGeneralesFDePago1.Image = CType(resources.GetObject("menuGeneralesFDePago1.Image"), System.Drawing.Image)
        Me.menuGeneralesFDePago1.Key = "menuGeneralesFDePago"
        Me.menuGeneralesFDePago1.Name = "menuGeneralesFDePago1"
        '
        'menuGeneralesLineas1
        '
        Me.menuGeneralesLineas1.Image = CType(resources.GetObject("menuGeneralesLineas1.Image"), System.Drawing.Image)
        Me.menuGeneralesLineas1.Key = "menuGeneralesLineas"
        Me.menuGeneralesLineas1.Name = "menuGeneralesLineas1"
        '
        'menuGeneralesMarcas1
        '
        Me.menuGeneralesMarcas1.Image = CType(resources.GetObject("menuGeneralesMarcas1.Image"), System.Drawing.Image)
        Me.menuGeneralesMarcas1.Key = "menuGeneralesMarcas"
        Me.menuGeneralesMarcas1.Name = "menuGeneralesMarcas1"
        '
        'menuGeneralesUsos1
        '
        Me.menuGeneralesUsos1.Image = CType(resources.GetObject("menuGeneralesUsos1.Image"), System.Drawing.Image)
        Me.menuGeneralesUsos1.Key = "menuGeneralesUsos"
        Me.menuGeneralesUsos1.Name = "menuGeneralesUsos1"
        '
        'menuGeneralesDescuentos1
        '
        Me.menuGeneralesDescuentos1.Image = CType(resources.GetObject("menuGeneralesDescuentos1.Image"), System.Drawing.Image)
        Me.menuGeneralesDescuentos1.Key = "menuGeneralesDescuentos"
        Me.menuGeneralesDescuentos1.Name = "menuGeneralesDescuentos1"
        '
        'Separator35
        '
        Me.Separator35.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator35.Key = "Separator"
        Me.Separator35.Name = "Separator35"
        '
        'menuGeneralesAlmacen1
        '
        Me.menuGeneralesAlmacen1.Image = CType(resources.GetObject("menuGeneralesAlmacen1.Image"), System.Drawing.Image)
        Me.menuGeneralesAlmacen1.Key = "menuGeneralesAlmacen"
        Me.menuGeneralesAlmacen1.Name = "menuGeneralesAlmacen1"
        '
        'menuGeneralesBanco1
        '
        Me.menuGeneralesBanco1.Image = CType(resources.GetObject("menuGeneralesBanco1.Image"), System.Drawing.Image)
        Me.menuGeneralesBanco1.Key = "menuGeneralesBanco"
        Me.menuGeneralesBanco1.Name = "menuGeneralesBanco1"
        Me.menuGeneralesBanco1.Text = "Bancos"
        '
        'menuGeneralesCaja1
        '
        Me.menuGeneralesCaja1.Image = CType(resources.GetObject("menuGeneralesCaja1.Image"), System.Drawing.Image)
        Me.menuGeneralesCaja1.Key = "menuGeneralesCaja"
        Me.menuGeneralesCaja1.Name = "menuGeneralesCaja1"
        '
        'menuGeneralesCat1
        '
        Me.menuGeneralesCat1.Image = CType(resources.GetObject("menuGeneralesCat1.Image"), System.Drawing.Image)
        Me.menuGeneralesCat1.Key = "menuGeneralesCat"
        Me.menuGeneralesCat1.Name = "menuGeneralesCat1"
        '
        'menuGeneralesCiudades1
        '
        Me.menuGeneralesCiudades1.Image = CType(resources.GetObject("menuGeneralesCiudades1.Image"), System.Drawing.Image)
        Me.menuGeneralesCiudades1.Key = "menuGeneralesCiudades"
        Me.menuGeneralesCiudades1.Name = "menuGeneralesCiudades1"
        '
        'menuGeneralesColonias1
        '
        Me.menuGeneralesColonias1.Image = CType(resources.GetObject("menuGeneralesColonias1.Image"), System.Drawing.Image)
        Me.menuGeneralesColonias1.Key = "menuGeneralesColonias"
        Me.menuGeneralesColonias1.Name = "menuGeneralesColonias1"
        '
        'menuGeneralesEstados1
        '
        Me.menuGeneralesEstados1.Image = CType(resources.GetObject("menuGeneralesEstados1.Image"), System.Drawing.Image)
        Me.menuGeneralesEstados1.Key = "menuGeneralesEstados"
        Me.menuGeneralesEstados1.Name = "menuGeneralesEstados1"
        '
        'menuGeneralesPlayer1
        '
        Me.menuGeneralesPlayer1.Image = CType(resources.GetObject("menuGeneralesPlayer1.Image"), System.Drawing.Image)
        Me.menuGeneralesPlayer1.Key = "menuGeneralesPlayer"
        Me.menuGeneralesPlayer1.Name = "menuGeneralesPlayer1"
        '
        'menuGeneralesPlaza1
        '
        Me.menuGeneralesPlaza1.Image = CType(resources.GetObject("menuGeneralesPlaza1.Image"), System.Drawing.Image)
        Me.menuGeneralesPlaza1.Key = "menuGeneralesPlaza"
        Me.menuGeneralesPlaza1.Name = "menuGeneralesPlaza1"
        '
        'menuGeneralesTipoDescuento1
        '
        Me.menuGeneralesTipoDescuento1.Image = CType(resources.GetObject("menuGeneralesTipoDescuento1.Image"), System.Drawing.Image)
        Me.menuGeneralesTipoDescuento1.Key = "menuGeneralesTipoDescuento"
        Me.menuGeneralesTipoDescuento1.Name = "menuGeneralesTipoDescuento1"
        '
        'menuGeneralesTipoTarjeta1
        '
        Me.menuGeneralesTipoTarjeta1.Image = CType(resources.GetObject("menuGeneralesTipoTarjeta1.Image"), System.Drawing.Image)
        Me.menuGeneralesTipoTarjeta1.Key = "menuGeneralesTipoTarjeta"
        Me.menuGeneralesTipoTarjeta1.Name = "menuGeneralesTipoTarjeta1"
        '
        'menuGeneralesTipoVenta1
        '
        Me.menuGeneralesTipoVenta1.Image = CType(resources.GetObject("menuGeneralesTipoVenta1.Image"), System.Drawing.Image)
        Me.menuGeneralesTipoVenta1.Key = "menuGeneralesTipoVenta"
        Me.menuGeneralesTipoVenta1.Name = "menuGeneralesTipoVenta1"
        '
        'menuGeneralesVales1
        '
        Me.menuGeneralesVales1.Image = CType(resources.GetObject("menuGeneralesVales1.Image"), System.Drawing.Image)
        Me.menuGeneralesVales1.Key = "menuGeneralesVales"
        Me.menuGeneralesVales1.Name = "menuGeneralesVales1"
        '
        'menuUtilerias
        '
        Me.menuUtilerias.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtileriasCompactarArc1, Me.menuUtileriasGenerarArchivos1, Me.menuUtileriasEliminarDoc1, Me.menuUtileriasProcArc1, Me.Separator17, Me.menuUtileriasRespaldarArch1, Me.menuUtileriasMovDAuditoria1, Me.Separator18, Me.menuUtileriasCierreDAño1, Me.Separator54, Me.menuUtileriasDatosDSucursal1, Me.Separator55, Me.menuUtileriasImpDEtiquetas1, Me.menuUtilesLstPrecios1, Me.Separator31, Me.menuUtilGenArchCierreDia1, Me.menuUtilGananciasAdicionales1, Me.MnuUtilCargaArchivosSAP1, Me.Separator67, Me.menuContabilizacion1, Me.Separator33, Me.mnuHerramientasOpciones1, Me.mnuUtileriasConfiguraSAP1, Me.menuUtileriasRutaArvhivos1, Me.menuUtileriasNumeroReferencia1, Me.mnuUtilConfigFotos1, Me.Separator34, Me.menuUtileriasUserRoles1, Me.Separator56, Me.mnuUtileriasCargaInicial1, Me.menuUtileriasLoadFacturas1, Me.menuCapturaManual1, Me.menuUtileriasGenArchDPVF1, Me.menuUtileriasReimprimirDPVFinanciero1, Me.menuUtileriasReimprimirTickets1, Me.menuUtileriasReimprimirCupon1, Me.menuUtileriasReimprimirVC1, Me.Separator72, Me.menuImageGearRegistration1, Me.Separator79, Me.menuUtileriasSaldoDPCard1, Me.Separator43, Me.menuCargaNotasCredito1, Me.MnuPinPadBanamex1, Me.MnuPinPadBanamexOffline1, Me.MnuDisposicionEfectivo1})
        Me.menuUtilerias.Key = "menuUtilerias"
        Me.menuUtilerias.Name = "menuUtilerias"
        Me.menuUtilerias.Text = "&Utilerias"
        '
        'menuUtileriasCompactarArc1
        '
        Me.menuUtileriasCompactarArc1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtileriasCompactarArc1.Image = CType(resources.GetObject("menuUtileriasCompactarArc1.Image"), System.Drawing.Image)
        Me.menuUtileriasCompactarArc1.Key = "menuUtileriasCompactarArc"
        Me.menuUtileriasCompactarArc1.Name = "menuUtileriasCompactarArc1"
        Me.menuUtileriasCompactarArc1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasGenerarArchivos1
        '
        Me.menuUtileriasGenerarArchivos1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtileriasGenerarArchivos1.Image = CType(resources.GetObject("menuUtileriasGenerarArchivos1.Image"), System.Drawing.Image)
        Me.menuUtileriasGenerarArchivos1.Key = "menuUtileriasGenerarArchivos"
        Me.menuUtileriasGenerarArchivos1.Name = "menuUtileriasGenerarArchivos1"
        Me.menuUtileriasGenerarArchivos1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasEliminarDoc1
        '
        Me.menuUtileriasEliminarDoc1.Image = CType(resources.GetObject("menuUtileriasEliminarDoc1.Image"), System.Drawing.Image)
        Me.menuUtileriasEliminarDoc1.Key = "menuUtileriasEliminarDoc"
        Me.menuUtileriasEliminarDoc1.Name = "menuUtileriasEliminarDoc1"
        Me.menuUtileriasEliminarDoc1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasProcArc1
        '
        Me.menuUtileriasProcArc1.Image = CType(resources.GetObject("menuUtileriasProcArc1.Image"), System.Drawing.Image)
        Me.menuUtileriasProcArc1.Key = "menuUtileriasProcArc"
        Me.menuUtileriasProcArc1.Name = "menuUtileriasProcArc1"
        Me.menuUtileriasProcArc1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator17
        '
        Me.Separator17.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator17.Key = "Separator"
        Me.Separator17.Name = "Separator17"
        '
        'menuUtileriasRespaldarArch1
        '
        Me.menuUtileriasRespaldarArch1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtileriasRespaldarArch1.Image = CType(resources.GetObject("menuUtileriasRespaldarArch1.Image"), System.Drawing.Image)
        Me.menuUtileriasRespaldarArch1.Key = "menuUtileriasRespaldarArch"
        Me.menuUtileriasRespaldarArch1.Name = "menuUtileriasRespaldarArch1"
        Me.menuUtileriasRespaldarArch1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasMovDAuditoria1
        '
        Me.menuUtileriasMovDAuditoria1.Image = CType(resources.GetObject("menuUtileriasMovDAuditoria1.Image"), System.Drawing.Image)
        Me.menuUtileriasMovDAuditoria1.Key = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria1.Name = "menuUtileriasMovDAuditoria1"
        '
        'Separator18
        '
        Me.Separator18.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator18.Key = "Separator"
        Me.Separator18.Name = "Separator18"
        '
        'menuUtileriasCierreDAño1
        '
        Me.menuUtileriasCierreDAño1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtileriasCierreDAño1.Image = CType(resources.GetObject("menuUtileriasCierreDAño1.Image"), System.Drawing.Image)
        Me.menuUtileriasCierreDAño1.Key = "menuUtileriasCierreDAño"
        Me.menuUtileriasCierreDAño1.Name = "menuUtileriasCierreDAño1"
        Me.menuUtileriasCierreDAño1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator54
        '
        Me.Separator54.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator54.Key = "Separator"
        Me.Separator54.Name = "Separator54"
        '
        'menuUtileriasDatosDSucursal1
        '
        Me.menuUtileriasDatosDSucursal1.Image = CType(resources.GetObject("menuUtileriasDatosDSucursal1.Image"), System.Drawing.Image)
        Me.menuUtileriasDatosDSucursal1.Key = "menuUtileriasDatosDSucursal"
        Me.menuUtileriasDatosDSucursal1.Name = "menuUtileriasDatosDSucursal1"
        Me.menuUtileriasDatosDSucursal1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator55
        '
        Me.Separator55.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator55.Key = "Separator"
        Me.Separator55.Name = "Separator55"
        '
        'menuUtileriasImpDEtiquetas1
        '
        Me.menuUtileriasImpDEtiquetas1.Image = CType(resources.GetObject("menuUtileriasImpDEtiquetas1.Image"), System.Drawing.Image)
        Me.menuUtileriasImpDEtiquetas1.Key = "menuUtileriasImpDEtiquetas"
        Me.menuUtileriasImpDEtiquetas1.Name = "menuUtileriasImpDEtiquetas1"
        '
        'menuUtilesLstPrecios1
        '
        Me.menuUtilesLstPrecios1.Key = "menuUtilesLstPrecios"
        Me.menuUtilesLstPrecios1.Name = "menuUtilesLstPrecios1"
        '
        'Separator31
        '
        Me.Separator31.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator31.Key = "Separator"
        Me.Separator31.Name = "Separator31"
        Me.Separator31.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilGenArchCierreDia1
        '
        Me.menuUtilGenArchCierreDia1.Key = "menuUtilGenArchCierreDia"
        Me.menuUtilGenArchCierreDia1.Name = "menuUtilGenArchCierreDia1"
        Me.menuUtilGenArchCierreDia1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtilGananciasAdicionales1
        '
        Me.menuUtilGananciasAdicionales1.Enabled = Janus.Windows.UI.InheritableBoolean.[True]
        Me.menuUtilGananciasAdicionales1.Key = "menuUtilGananciasAdicionales"
        Me.menuUtilGananciasAdicionales1.Name = "menuUtilGananciasAdicionales1"
        Me.menuUtilGananciasAdicionales1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MnuUtilCargaArchivosSAP1
        '
        Me.MnuUtilCargaArchivosSAP1.Key = "MnuUtilCargaArchivosSAP"
        Me.MnuUtilCargaArchivosSAP1.Name = "MnuUtilCargaArchivosSAP1"
        Me.MnuUtilCargaArchivosSAP1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator67
        '
        Me.Separator67.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator67.Key = "Separator"
        Me.Separator67.Name = "Separator67"
        Me.Separator67.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuContabilizacion1
        '
        Me.menuContabilizacion1.Key = "menuContabilizacion"
        Me.menuContabilizacion1.Name = "menuContabilizacion1"
        Me.menuContabilizacion1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator33
        '
        Me.Separator33.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator33.Key = "Separator"
        Me.Separator33.Name = "Separator33"
        '
        'mnuHerramientasOpciones1
        '
        Me.mnuHerramientasOpciones1.Key = "mnuHerramientasOpciones"
        Me.mnuHerramientasOpciones1.Name = "mnuHerramientasOpciones1"
        Me.mnuHerramientasOpciones1.Text = "&Opciones del Sistema...."
        '
        'mnuUtileriasConfiguraSAP1
        '
        Me.mnuUtileriasConfiguraSAP1.Icon = CType(resources.GetObject("mnuUtileriasConfiguraSAP1.Icon"), System.Drawing.Icon)
        Me.mnuUtileriasConfiguraSAP1.Key = "mnuUtileriasConfiguraSAP"
        Me.mnuUtileriasConfiguraSAP1.Name = "mnuUtileriasConfiguraSAP1"
        '
        'menuUtileriasRutaArvhivos1
        '
        Me.menuUtileriasRutaArvhivos1.Icon = CType(resources.GetObject("menuUtileriasRutaArvhivos1.Icon"), System.Drawing.Icon)
        Me.menuUtileriasRutaArvhivos1.Key = "menuUtileriasRutaArvhivos"
        Me.menuUtileriasRutaArvhivos1.Name = "menuUtileriasRutaArvhivos1"
        Me.menuUtileriasRutaArvhivos1.Text = "Configuracion Ruta Archivos FI, Fotos"
        '
        'menuUtileriasNumeroReferencia1
        '
        Me.menuUtileriasNumeroReferencia1.Icon = CType(resources.GetObject("menuUtileriasNumeroReferencia1.Icon"), System.Drawing.Icon)
        Me.menuUtileriasNumeroReferencia1.Key = "menuUtileriasNumeroReferencia"
        Me.menuUtileriasNumeroReferencia1.Name = "menuUtileriasNumeroReferencia1"
        '
        'mnuUtilConfigFotos1
        '
        Me.mnuUtilConfigFotos1.Icon = CType(resources.GetObject("mnuUtilConfigFotos1.Icon"), System.Drawing.Icon)
        Me.mnuUtilConfigFotos1.Key = "mnuUtilConfigFotos"
        Me.mnuUtilConfigFotos1.Name = "mnuUtilConfigFotos1"
        Me.mnuUtilConfigFotos1.Text = "Configuracion Ruta Imagenes"
        Me.mnuUtilConfigFotos1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator34
        '
        Me.Separator34.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator34.Key = "Separator"
        Me.Separator34.Name = "Separator34"
        '
        'menuUtileriasUserRoles1
        '
        Me.menuUtileriasUserRoles1.Key = "menuUtileriasUserRoles"
        Me.menuUtileriasUserRoles1.Name = "menuUtileriasUserRoles1"
        '
        'Separator56
        '
        Me.Separator56.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator56.Key = "Separator"
        Me.Separator56.Name = "Separator56"
        '
        'mnuUtileriasCargaInicial1
        '
        Me.mnuUtileriasCargaInicial1.Key = "mnuUtileriasCargaInicial"
        Me.mnuUtileriasCargaInicial1.Name = "mnuUtileriasCargaInicial1"
        '
        'menuUtileriasLoadFacturas1
        '
        Me.menuUtileriasLoadFacturas1.Key = "menuUtileriasLoadFacturas"
        Me.menuUtileriasLoadFacturas1.Name = "menuUtileriasLoadFacturas1"
        Me.menuUtileriasLoadFacturas1.Text = "Guardar Movimientos en SAP"
        '
        'menuCapturaManual1
        '
        Me.menuCapturaManual1.Key = "menuCapturaManual"
        Me.menuCapturaManual1.Name = "menuCapturaManual1"
        Me.menuCapturaManual1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasGenArchDPVF1
        '
        Me.menuUtileriasGenArchDPVF1.Key = "menuUtileriasGenArchDPVF"
        Me.menuUtileriasGenArchDPVF1.Name = "menuUtileriasGenArchDPVF1"
        Me.menuUtileriasGenArchDPVF1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasReimprimirDPVFinanciero1
        '
        Me.menuUtileriasReimprimirDPVFinanciero1.Key = "menuUtileriasReimprimirDPVFinanciero"
        Me.menuUtileriasReimprimirDPVFinanciero1.Name = "menuUtileriasReimprimirDPVFinanciero1"
        Me.menuUtileriasReimprimirDPVFinanciero1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasReimprimirTickets1
        '
        Me.menuUtileriasReimprimirTickets1.Key = "menuUtileriasReimprimirTickets"
        Me.menuUtileriasReimprimirTickets1.Name = "menuUtileriasReimprimirTickets1"
        Me.menuUtileriasReimprimirTickets1.Text = "Reimprimir Vouchers"
        Me.menuUtileriasReimprimirTickets1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuUtileriasReimprimirCupon1
        '
        Me.menuUtileriasReimprimirCupon1.Key = "menuUtileriasReimprimirCupon"
        Me.menuUtileriasReimprimirCupon1.Name = "menuUtileriasReimprimirCupon1"
        '
        'menuUtileriasReimprimirVC1
        '
        Me.menuUtileriasReimprimirVC1.Key = "menuUtileriasReimprimirVC"
        Me.menuUtileriasReimprimirVC1.Name = "menuUtileriasReimprimirVC1"
        Me.menuUtileriasReimprimirVC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator72
        '
        Me.Separator72.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator72.Key = "Separator"
        Me.Separator72.Name = "Separator72"
        '
        'menuImageGearRegistration1
        '
        Me.menuImageGearRegistration1.Key = "menuImageGearRegistration"
        Me.menuImageGearRegistration1.Name = "menuImageGearRegistration1"
        Me.menuImageGearRegistration1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator79
        '
        Me.Separator79.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator79.Key = "Separator"
        Me.Separator79.Name = "Separator79"
        '
        'menuUtileriasSaldoDPCard1
        '
        Me.menuUtileriasSaldoDPCard1.Key = "menuUtileriasSaldoDPCard"
        Me.menuUtileriasSaldoDPCard1.Name = "menuUtileriasSaldoDPCard1"
        '
        'Separator43
        '
        Me.Separator43.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator43.Key = "Separator"
        Me.Separator43.Name = "Separator43"
        '
        'menuCargaNotasCredito1
        '
        Me.menuCargaNotasCredito1.Key = "menuCargaNotasCredito"
        Me.menuCargaNotasCredito1.Name = "menuCargaNotasCredito1"
        '
        'MnuPinPadBanamex1
        '
        Me.MnuPinPadBanamex1.Image = CType(resources.GetObject("MnuPinPadBanamex1.Image"), System.Drawing.Image)
        Me.MnuPinPadBanamex1.Key = "MnuPinPadBanamex"
        Me.MnuPinPadBanamex1.Name = "MnuPinPadBanamex1"
        '
        'MnuPinPadBanamexOffline1
        '
        Me.MnuPinPadBanamexOffline1.Key = "MnuPinPadBanamexOffline"
        Me.MnuPinPadBanamexOffline1.Name = "MnuPinPadBanamexOffline1"
        Me.MnuPinPadBanamexOffline1.Text = "Configuración Pinpad Banamex Offline"
        '
        'MnuDisposicionEfectivo1
        '
        Me.MnuDisposicionEfectivo1.Image = CType(resources.GetObject("MnuDisposicionEfectivo1.Image"), System.Drawing.Image)
        Me.MnuDisposicionEfectivo1.Key = "MnuDisposicionEfectivo"
        Me.MnuDisposicionEfectivo1.Name = "MnuDisposicionEfectivo1"
        '
        'menuVentasFacturacion
        '
        Me.menuVentasFacturacion.Key = "menuVentasFacturacion"
        Me.menuVentasFacturacion.Name = "menuVentasFacturacion"
        Me.menuVentasFacturacion.Text = "&Facturacion"
        '
        'menuVentasCambioTalla
        '
        Me.menuVentasCambioTalla.Key = "menuVentasCambioTalla"
        Me.menuVentasCambioTalla.Name = "menuVentasCambioTalla"
        Me.menuVentasCambioTalla.Text = "&Cambio de Tallas"
        '
        'menuVentaInicio
        '
        Me.menuVentaInicio.Key = "menuVentaInicio"
        Me.menuVentaInicio.Name = "menuVentaInicio"
        Me.menuVentaInicio.Text = "&Inicio del Dia"
        '
        'menuVentasCancelarFactura
        '
        Me.menuVentasCancelarFactura.Key = "menuVentasCancelarFactura"
        Me.menuVentasCancelarFactura.Name = "menuVentasCancelarFactura"
        Me.menuVentasCancelarFactura.Text = "Ca&ncelar Facturas"
        '
        'menuVentasCierreDia
        '
        Me.menuVentasCierreDia.Key = "menuVentasCierreDia"
        Me.menuVentasCierreDia.Name = "menuVentasCierreDia"
        Me.menuVentasCierreDia.Text = "Cierre del Dia"
        '
        'menuVentasReporteVenta
        '
        Me.menuVentasReporteVenta.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasReporteVentaVT1, Me.menuVentasReporteVentaVED1, Me.menuVentasReporteVentaVXH1, Me.Separator20, Me.menuVentasReporteVentaPromXH1, Me.Separator57, Me.menuVentasPorCliente1, Me.Separator73, Me.menuOperacionalMarcas1, Me.menuOperacionalCodigos1})
        Me.menuVentasReporteVenta.Key = "menuVentasReporteVenta"
        Me.menuVentasReporteVenta.Name = "menuVentasReporteVenta"
        Me.menuVentasReporteVenta.Text = "Reportes de Ventas"
        '
        'menuVentasReporteVentaVT1
        '
        Me.menuVentasReporteVentaVT1.Key = "menuVentasReporteVentaVT"
        Me.menuVentasReporteVentaVT1.Name = "menuVentasReporteVentaVT1"
        '
        'menuVentasReporteVentaVED1
        '
        Me.menuVentasReporteVentaVED1.Key = "menuVentasReporteVentaVED"
        Me.menuVentasReporteVentaVED1.Name = "menuVentasReporteVentaVED1"
        '
        'menuVentasReporteVentaVXH1
        '
        Me.menuVentasReporteVentaVXH1.Key = "menuVentasReporteVentaVXH"
        Me.menuVentasReporteVentaVXH1.Name = "menuVentasReporteVentaVXH1"
        '
        'Separator20
        '
        Me.Separator20.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator20.Key = "Separator"
        Me.Separator20.Name = "Separator20"
        Me.Separator20.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasReporteVentaPromXH1
        '
        Me.menuVentasReporteVentaPromXH1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuVentasReporteVentaPromXH1.Key = "menuVentasReporteVentaPromXH"
        Me.menuVentasReporteVentaPromXH1.Name = "menuVentasReporteVentaPromXH1"
        Me.menuVentasReporteVentaPromXH1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator57
        '
        Me.Separator57.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator57.Key = "Separator"
        Me.Separator57.Name = "Separator57"
        '
        'menuVentasPorCliente1
        '
        Me.menuVentasPorCliente1.Key = "menuVentasPorCliente"
        Me.menuVentasPorCliente1.Name = "menuVentasPorCliente1"
        '
        'Separator73
        '
        Me.Separator73.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator73.Key = "Separator"
        Me.Separator73.Name = "Separator73"
        Me.Separator73.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuOperacionalMarcas1
        '
        Me.menuOperacionalMarcas1.Key = "menuOperacionalMarcas"
        Me.menuOperacionalMarcas1.Name = "menuOperacionalMarcas1"
        Me.menuOperacionalMarcas1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuOperacionalCodigos1
        '
        Me.menuOperacionalCodigos1.Key = "menuOperacionalCodigos"
        Me.menuOperacionalCodigos1.Name = "menuOperacionalCodigos1"
        Me.menuOperacionalCodigos1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentaAnalisisVenta
        '
        Me.menuVentaAnalisisVenta.Key = "menuVentaAnalisisVenta"
        Me.menuVentaAnalisisVenta.Name = "menuVentaAnalisisVenta"
        Me.menuVentaAnalisisVenta.Text = "Analisis de Venta"
        '
        'menuVentaNotasCredito
        '
        Me.menuVentaNotasCredito.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasNotaCreditoManejo1, Me.Separator4, Me.menuNotasCreditoReportesConcentrado2, Me.MnuCambioTalla1})
        Me.menuVentaNotasCredito.Key = "menuVentaNotasCredito"
        Me.menuVentaNotasCredito.Name = "menuVentaNotasCredito"
        Me.menuVentaNotasCredito.Text = "Notas de Credito"
        '
        'menuVentasNotaCreditoManejo1
        '
        Me.menuVentasNotaCreditoManejo1.Key = "menuVentasNotaCreditoManejo"
        Me.menuVentasNotaCreditoManejo1.Name = "menuVentasNotaCreditoManejo1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuNotasCreditoReportesConcentrado2
        '
        Me.menuNotasCreditoReportesConcentrado2.Key = "menuNotasCreditoReportesConcentrado"
        Me.menuNotasCreditoReportesConcentrado2.Name = "menuNotasCreditoReportesConcentrado2"
        Me.menuNotasCreditoReportesConcentrado2.Text = "Reporte Notas de Credito"
        '
        'MnuCambioTalla1
        '
        Me.MnuCambioTalla1.Image = CType(resources.GetObject("MnuCambioTalla1.Image"), System.Drawing.Image)
        Me.MnuCambioTalla1.Key = "MnuCambioTalla"
        Me.MnuCambioTalla1.Name = "MnuCambioTalla1"
        '
        'menuVentasCXC
        '
        Me.menuVentasCXC.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasCXCAbono1, Me.menuVentaCXCCancelarAbono1, Me.Separator63, Me.menuVentasACDT1, Me.Separator19, Me.menuVentasCXCEdoCuenta1, Me.Separator32, Me.menuVentasCXCReportes1})
        Me.menuVentasCXC.Key = "menuVentasCXC"
        Me.menuVentasCXC.Name = "menuVentasCXC"
        Me.menuVentasCXC.Text = "Cuentas por Cobrar"
        '
        'menuVentasCXCAbono1
        '
        Me.menuVentasCXCAbono1.Key = "menuVentasCXCAbono"
        Me.menuVentasCXCAbono1.Name = "menuVentasCXCAbono1"
        Me.menuVentasCXCAbono1.Text = "Abono"
        Me.menuVentasCXCAbono1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentaCXCCancelarAbono1
        '
        Me.menuVentaCXCCancelarAbono1.Key = "menuVentaCXCCancelarAbono"
        Me.menuVentaCXCCancelarAbono1.Name = "menuVentaCXCCancelarAbono1"
        Me.menuVentaCXCCancelarAbono1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator63
        '
        Me.Separator63.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator63.Key = "Separator"
        Me.Separator63.Name = "Separator63"
        '
        'menuVentasACDT1
        '
        Me.menuVentasACDT1.Key = "menuVentasACDT"
        Me.menuVentasACDT1.Name = "menuVentasACDT1"
        '
        'Separator19
        '
        Me.Separator19.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator19.Key = "Separator"
        Me.Separator19.Name = "Separator19"
        '
        'menuVentasCXCEdoCuenta1
        '
        Me.menuVentasCXCEdoCuenta1.Key = "menuVentasCXCEdoCuenta"
        Me.menuVentasCXCEdoCuenta1.Name = "menuVentasCXCEdoCuenta1"
        '
        'Separator32
        '
        Me.Separator32.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator32.Key = "Separator"
        Me.Separator32.Name = "Separator32"
        '
        'menuVentasCXCReportes1
        '
        Me.menuVentasCXCReportes1.Key = "menuVentasCXCReportes"
        Me.menuVentasCXCReportes1.Name = "menuVentasCXCReportes1"
        '
        'menuVentasAvisosenNotas
        '
        Me.menuVentasAvisosenNotas.Key = "menuVentasAvisosenNotas"
        Me.menuVentasAvisosenNotas.Name = "menuVentasAvisosenNotas"
        Me.menuVentasAvisosenNotas.Text = "Avisos del Sistema"
        '
        'menuVentaModDatosFact
        '
        Me.menuVentaModDatosFact.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuVentaModDatosFact.Key = "menuVentaModDatosFact"
        Me.menuVentaModDatosFact.Name = "menuVentaModDatosFact"
        Me.menuVentaModDatosFact.Text = "Modulo de Datos de Factura"
        Me.menuVentaModDatosFact.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuApartadosContratos
        '
        Me.menuApartadosContratos.Key = "menuApartadosContratos"
        Me.menuApartadosContratos.Name = "menuApartadosContratos"
        Me.menuApartadosContratos.Text = "Cont&ratos"
        '
        'menuApartadosAOA
        '
        Me.menuApartadosAOA.Key = "menuApartadosAOA"
        Me.menuApartadosAOA.Name = "menuApartadosAOA"
        Me.menuApartadosAOA.Text = "Abonos o Anticipos"
        '
        'menuApartadosRepDApartado
        '
        Me.menuApartadosRepDApartado.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuApartadosRepDApartadoCT2, Me.menuApartadosRepDApartadoCD2, Me.menuApartadosRepDApartadoCC2, Me.Separator21, Me.menuApartadosRepDApartadoAV2, Me.menuApartadosRepDApartadoAAV2})
        Me.menuApartadosRepDApartado.Key = "menuApartadosRepDApartado"
        Me.menuApartadosRepDApartado.Name = "menuApartadosRepDApartado"
        Me.menuApartadosRepDApartado.Text = "Reportes de Apartados"
        '
        'menuApartadosRepDApartadoCT2
        '
        Me.menuApartadosRepDApartadoCT2.Key = "menuApartadosRepDApartadoCT"
        Me.menuApartadosRepDApartadoCT2.Name = "menuApartadosRepDApartadoCT2"
        '
        'menuApartadosRepDApartadoCD2
        '
        Me.menuApartadosRepDApartadoCD2.Key = "menuApartadosRepDApartadoCD"
        Me.menuApartadosRepDApartadoCD2.Name = "menuApartadosRepDApartadoCD2"
        '
        'menuApartadosRepDApartadoCC2
        '
        Me.menuApartadosRepDApartadoCC2.Key = "menuApartadosRepDApartadoCC"
        Me.menuApartadosRepDApartadoCC2.Name = "menuApartadosRepDApartadoCC2"
        '
        'Separator21
        '
        Me.Separator21.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator21.Key = "Separator"
        Me.Separator21.Name = "Separator21"
        '
        'menuApartadosRepDApartadoAV2
        '
        Me.menuApartadosRepDApartadoAV2.Key = "menuApartadosRepDApartadoAV"
        Me.menuApartadosRepDApartadoAV2.Name = "menuApartadosRepDApartadoAV2"
        '
        'menuApartadosRepDApartadoAAV2
        '
        Me.menuApartadosRepDApartadoAAV2.Key = "menuApartadosRepDApartadoAAV"
        Me.menuApartadosRepDApartadoAAV2.Name = "menuApartadosRepDApartadoAAV2"
        Me.menuApartadosRepDApartadoAAV2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuApartadosRepDAbono
        '
        Me.menuApartadosRepDAbono.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuApartadosRepDAbonoAA1, Me.menuApartadosRepDAbonoAC1})
        Me.menuApartadosRepDAbono.Key = "menuApartadosRepDAbono"
        Me.menuApartadosRepDAbono.Name = "menuApartadosRepDAbono"
        Me.menuApartadosRepDAbono.Text = "Resportes de Abonos"
        '
        'menuApartadosRepDAbonoAA1
        '
        Me.menuApartadosRepDAbonoAA1.Key = "menuApartadosRepDAbonoAA"
        Me.menuApartadosRepDAbonoAA1.Name = "menuApartadosRepDAbonoAA1"
        '
        'menuApartadosRepDAbonoAC1
        '
        Me.menuApartadosRepDAbonoAC1.Key = "menuApartadosRepDAbonoAC"
        Me.menuApartadosRepDAbonoAC1.Name = "menuApartadosRepDAbonoAC1"
        '
        'menuApartadosCancelarContratos
        '
        Me.menuApartadosCancelarContratos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuApartadosCancelarContratoNDCredito1, Me.Separator22, Me.menuApartadosCancelarContratosDef1})
        Me.menuApartadosCancelarContratos.Key = "menuApartadosCancelarContratos"
        Me.menuApartadosCancelarContratos.Name = "menuApartadosCancelarContratos"
        Me.menuApartadosCancelarContratos.Text = "Cancelar Contratos"
        '
        'menuApartadosCancelarContratoNDCredito1
        '
        Me.menuApartadosCancelarContratoNDCredito1.Key = "menuApartadosCancelarContratoNDCredito"
        Me.menuApartadosCancelarContratoNDCredito1.Name = "menuApartadosCancelarContratoNDCredito1"
        '
        'Separator22
        '
        Me.Separator22.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator22.Key = "Separator"
        Me.Separator22.Name = "Separator22"
        '
        'menuApartadosCancelarContratosDef1
        '
        Me.menuApartadosCancelarContratosDef1.Key = "menuApartadosCancelarContratosDef"
        Me.menuApartadosCancelarContratosDef1.Name = "menuApartadosCancelarContratosDef1"
        Me.menuApartadosCancelarContratosDef1.Text = "Cancelación Definitiva"
        Me.menuApartadosCancelarContratosDef1.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'menuApartadosEdoCtaXContrato
        '
        Me.menuApartadosEdoCtaXContrato.Key = "menuApartadosEdoCtaXContrato"
        Me.menuApartadosEdoCtaXContrato.Name = "menuApartadosEdoCtaXContrato"
        Me.menuApartadosEdoCtaXContrato.Text = "Estado de Cuenta por Contrato"
        '
        'menuApartadoCancelarAbono
        '
        Me.menuApartadoCancelarAbono.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuApartadoCancelarAbono.Key = "menuApartadoCancelarAbono"
        Me.menuApartadoCancelarAbono.Name = "menuApartadoCancelarAbono"
        Me.menuApartadoCancelarAbono.Text = "Cancelar Abonos"
        Me.menuApartadoCancelarAbono.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioExistdeCodigo
        '
        Me.menuInventarioExistdeCodigo.Key = "menuInventarioExistdeCodigo"
        Me.menuInventarioExistdeCodigo.Name = "menuInventarioExistdeCodigo"
        Me.menuInventarioExistdeCodigo.Text = "Existencia de Codigos"
        '
        'menuInventarioMovArticulos
        '
        Me.menuInventarioMovArticulos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioMovArticulosPA1, Me.menuInventarioMovArticuloTA1, Me.Separator23, Me.menuInventarioMovArticulosH21, Me.menuInventarioMovArticulosHA1, Me.Separator71, Me.menuBitacora1})
        Me.menuInventarioMovArticulos.Key = "menuInventarioMovArticulos"
        Me.menuInventarioMovArticulos.Name = "menuInventarioMovArticulos"
        Me.menuInventarioMovArticulos.Text = "Movimientos de Articulos"
        '
        'menuInventarioMovArticulosPA1
        '
        Me.menuInventarioMovArticulosPA1.Key = "menuInventarioMovArticulosPA"
        Me.menuInventarioMovArticulosPA1.Name = "menuInventarioMovArticulosPA1"
        '
        'menuInventarioMovArticuloTA1
        '
        Me.menuInventarioMovArticuloTA1.Key = "menuInventarioMovArticuloTA"
        Me.menuInventarioMovArticuloTA1.Name = "menuInventarioMovArticuloTA1"
        Me.menuInventarioMovArticuloTA1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator23
        '
        Me.Separator23.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator23.Key = "Separator"
        Me.Separator23.Name = "Separator23"
        '
        'menuInventarioMovArticulosH21
        '
        Me.menuInventarioMovArticulosH21.Key = "menuInventarioMovArticulosH2"
        Me.menuInventarioMovArticulosH21.Name = "menuInventarioMovArticulosH21"
        Me.menuInventarioMovArticulosH21.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioMovArticulosHA1
        '
        Me.menuInventarioMovArticulosHA1.Key = "menuInventarioMovArticulosHA"
        Me.menuInventarioMovArticulosHA1.Name = "menuInventarioMovArticulosHA1"
        '
        'Separator71
        '
        Me.Separator71.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator71.Key = "Separator"
        Me.Separator71.Name = "Separator71"
        '
        'menuBitacora1
        '
        Me.menuBitacora1.Key = "menuBitacora"
        Me.menuBitacora1.Name = "menuBitacora1"
        '
        'menuInventarioCostodeInv
        '
        Me.menuInventarioCostodeInv.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioCostodeInvCod1, Me.menuInventarioCostodeInvCodDet1, Me.menuInventarioCostodeInvMarcas1, Me.menuInventarioCostodeInvLinea1, Me.menuInventarioCostodeInvFamilia1, Me.menuInventarioCostodeInvUsos1, Me.menuInventarioCostodeInvSucursal1, Me.menuInventarioCostodeInvArtCD1, Me.menuInventarioCostodeInvLF1, Me.menuInventarioCostodeInvMLF1, Me.menuInventarioCostodeInvMF1, Me.menuInventarioCostodeInvFM1, Me.menuInventarioCostodeInvRA1})
        Me.menuInventarioCostodeInv.Key = "menuInventarioCostodeInv"
        Me.menuInventarioCostodeInv.Name = "menuInventarioCostodeInv"
        Me.menuInventarioCostodeInv.Text = "Costo de Inventarios"
        '
        'menuInventarioCostodeInvCod1
        '
        Me.menuInventarioCostodeInvCod1.Key = "menuInventarioCostodeInvCod"
        Me.menuInventarioCostodeInvCod1.Name = "menuInventarioCostodeInvCod1"
        '
        'menuInventarioCostodeInvCodDet1
        '
        Me.menuInventarioCostodeInvCodDet1.Key = "menuInventarioCostodeInvCodDet"
        Me.menuInventarioCostodeInvCodDet1.Name = "menuInventarioCostodeInvCodDet1"
        '
        'menuInventarioCostodeInvMarcas1
        '
        Me.menuInventarioCostodeInvMarcas1.Key = "menuInventarioCostodeInvMarcas"
        Me.menuInventarioCostodeInvMarcas1.Name = "menuInventarioCostodeInvMarcas1"
        '
        'menuInventarioCostodeInvLinea1
        '
        Me.menuInventarioCostodeInvLinea1.Key = "menuInventarioCostodeInvLinea"
        Me.menuInventarioCostodeInvLinea1.Name = "menuInventarioCostodeInvLinea1"
        '
        'menuInventarioCostodeInvFamilia1
        '
        Me.menuInventarioCostodeInvFamilia1.Key = "menuInventarioCostodeInvFamilia"
        Me.menuInventarioCostodeInvFamilia1.Name = "menuInventarioCostodeInvFamilia1"
        '
        'menuInventarioCostodeInvUsos1
        '
        Me.menuInventarioCostodeInvUsos1.Key = "menuInventarioCostodeInvUsos"
        Me.menuInventarioCostodeInvUsos1.Name = "menuInventarioCostodeInvUsos1"
        '
        'menuInventarioCostodeInvSucursal1
        '
        Me.menuInventarioCostodeInvSucursal1.Key = "menuInventarioCostodeInvSucursal"
        Me.menuInventarioCostodeInvSucursal1.Name = "menuInventarioCostodeInvSucursal1"
        '
        'menuInventarioCostodeInvArtCD1
        '
        Me.menuInventarioCostodeInvArtCD1.Key = "menuInventarioCostodeInvArtCD"
        Me.menuInventarioCostodeInvArtCD1.Name = "menuInventarioCostodeInvArtCD1"
        '
        'menuInventarioCostodeInvLF1
        '
        Me.menuInventarioCostodeInvLF1.Key = "menuInventarioCostodeInvLF"
        Me.menuInventarioCostodeInvLF1.Name = "menuInventarioCostodeInvLF1"
        '
        'menuInventarioCostodeInvMLF1
        '
        Me.menuInventarioCostodeInvMLF1.Key = "menuInventarioCostodeInvMLF"
        Me.menuInventarioCostodeInvMLF1.Name = "menuInventarioCostodeInvMLF1"
        '
        'menuInventarioCostodeInvMF1
        '
        Me.menuInventarioCostodeInvMF1.Key = "menuInventarioCostodeInvMF"
        Me.menuInventarioCostodeInvMF1.Name = "menuInventarioCostodeInvMF1"
        '
        'menuInventarioCostodeInvFM1
        '
        Me.menuInventarioCostodeInvFM1.Key = "menuInventarioCostodeInvFM"
        Me.menuInventarioCostodeInvFM1.Name = "menuInventarioCostodeInvFM1"
        '
        'menuInventarioCostodeInvRA1
        '
        Me.menuInventarioCostodeInvRA1.Key = "menuInventarioCostodeInvRA"
        Me.menuInventarioCostodeInvRA1.Name = "menuInventarioCostodeInvRA1"
        '
        'menuInventarioTraspasos
        '
        Me.menuInventarioTraspasos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioTraspasosSalida1, Me.Separator24, Me.menuInventarioTraspasoPT1, Me.MnuTraspasoEntradaMercancia1, Me.menuInventarioTraspasoEntradaBultos1, Me.menuInventarioTraspasoModTSalida1, Me.menuInventarioTraspasoBTG1, Me.Separator25, Me.menuInventarioTraspasoRDD1, Me.menuInventarioTraspasoTSG1, Me.Separator29, Me.menuInventarioTEntradaDBF1})
        Me.menuInventarioTraspasos.Key = "menuInventarioTraspasos"
        Me.menuInventarioTraspasos.Name = "menuInventarioTraspasos"
        Me.menuInventarioTraspasos.Text = "Traspasos"
        '
        'menuInventarioTraspasosSalida1
        '
        Me.menuInventarioTraspasosSalida1.Key = "menuInventarioTraspasosSalida"
        Me.menuInventarioTraspasosSalida1.Name = "menuInventarioTraspasosSalida1"
        '
        'Separator24
        '
        Me.Separator24.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator24.Key = "Separator"
        Me.Separator24.Name = "Separator24"
        '
        'menuInventarioTraspasoPT1
        '
        Me.menuInventarioTraspasoPT1.Key = "menuInventarioTraspasoPT"
        Me.menuInventarioTraspasoPT1.Name = "menuInventarioTraspasoPT1"
        Me.menuInventarioTraspasoPT1.Text = "Traspasos de Entrada"
        '
        'MnuTraspasoEntradaMercancia1
        '
        Me.MnuTraspasoEntradaMercancia1.Image = CType(resources.GetObject("MnuTraspasoEntradaMercancia1.Image"), System.Drawing.Image)
        Me.MnuTraspasoEntradaMercancia1.Key = "MnuTraspasoEntradaMercancia"
        Me.MnuTraspasoEntradaMercancia1.Name = "MnuTraspasoEntradaMercancia1"
        Me.MnuTraspasoEntradaMercancia1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioTraspasoEntradaBultos1
        '
        Me.menuInventarioTraspasoEntradaBultos1.Key = "menuInventarioTraspasoEntradaBultos"
        Me.menuInventarioTraspasoEntradaBultos1.Name = "menuInventarioTraspasoEntradaBultos1"
        '
        'menuInventarioTraspasoModTSalida1
        '
        Me.menuInventarioTraspasoModTSalida1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioTraspasoModTSalida1.Key = "menuInventarioTraspasoModTSalida"
        Me.menuInventarioTraspasoModTSalida1.Name = "menuInventarioTraspasoModTSalida1"
        Me.menuInventarioTraspasoModTSalida1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioTraspasoBTG1
        '
        Me.menuInventarioTraspasoBTG1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioTraspasoBTG1.Key = "menuInventarioTraspasoBTG"
        Me.menuInventarioTraspasoBTG1.Name = "menuInventarioTraspasoBTG1"
        Me.menuInventarioTraspasoBTG1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator25
        '
        Me.Separator25.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator25.Key = "Separator"
        Me.Separator25.Name = "Separator25"
        '
        'menuInventarioTraspasoRDD1
        '
        Me.menuInventarioTraspasoRDD1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioTraspasoRDD1.Key = "menuInventarioTraspasoRDD"
        Me.menuInventarioTraspasoRDD1.Name = "menuInventarioTraspasoRDD1"
        Me.menuInventarioTraspasoRDD1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioTraspasoTSG1
        '
        Me.menuInventarioTraspasoTSG1.Key = "menuInventarioTraspasoTSG"
        Me.menuInventarioTraspasoTSG1.Name = "menuInventarioTraspasoTSG1"
        '
        'Separator29
        '
        Me.Separator29.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator29.Key = "Separator"
        Me.Separator29.Name = "Separator29"
        '
        'menuInventarioTEntradaDBF1
        '
        Me.menuInventarioTEntradaDBF1.Key = "menuInventarioTEntradaDBF"
        Me.menuInventarioTEntradaDBF1.Name = "menuInventarioTEntradaDBF1"
        '
        'menuInventarioReporteInv
        '
        Me.menuInventarioReporteInv.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioReporteInvPC1, Me.menuInventarioReporteInvEN1, Me.menuInventarioReporteInvAA1, Me.menuInventarioReporteInvUP1, Me.menuInventarioReporteInvRG1, Me.Separator30, Me.menuInventarioReporteVarios1, Me.menuListaArticuloDescuentoSAP1, Me.mnuListaArticulosDescuentoSAPGroup1, Me.menuInventarioMasVendidos1, Me.Separator74, Me.menuInventarioReporteDifTraslados1})
        Me.menuInventarioReporteInv.Key = "menuInventarioReporteInv"
        Me.menuInventarioReporteInv.Name = "menuInventarioReporteInv"
        Me.menuInventarioReporteInv.Text = "Reportes de Inventarios"
        '
        'menuInventarioReporteInvPC1
        '
        Me.menuInventarioReporteInvPC1.Key = "menuInventarioReporteInvPC"
        Me.menuInventarioReporteInvPC1.Name = "menuInventarioReporteInvPC1"
        Me.menuInventarioReporteInvPC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioReporteInvEN1
        '
        Me.menuInventarioReporteInvEN1.Key = "menuInventarioReporteInvEN"
        Me.menuInventarioReporteInvEN1.Name = "menuInventarioReporteInvEN1"
        Me.menuInventarioReporteInvEN1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioReporteInvAA1
        '
        Me.menuInventarioReporteInvAA1.Key = "menuInventarioReporteInvAA"
        Me.menuInventarioReporteInvAA1.Name = "menuInventarioReporteInvAA1"
        Me.menuInventarioReporteInvAA1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioReporteInvUP1
        '
        Me.menuInventarioReporteInvUP1.Key = "menuInventarioReporteInvUP"
        Me.menuInventarioReporteInvUP1.Name = "menuInventarioReporteInvUP1"
        '
        'menuInventarioReporteInvRG1
        '
        Me.menuInventarioReporteInvRG1.Key = "menuInventarioReporteInvRG"
        Me.menuInventarioReporteInvRG1.Name = "menuInventarioReporteInvRG1"
        '
        'Separator30
        '
        Me.Separator30.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator30.Key = "Separator"
        Me.Separator30.Name = "Separator30"
        '
        'menuInventarioReporteVarios1
        '
        Me.menuInventarioReporteVarios1.Key = "menuInventarioReporteVarios"
        Me.menuInventarioReporteVarios1.Name = "menuInventarioReporteVarios1"
        '
        'menuListaArticuloDescuentoSAP1
        '
        Me.menuListaArticuloDescuentoSAP1.Icon = CType(resources.GetObject("menuListaArticuloDescuentoSAP1.Icon"), System.Drawing.Icon)
        Me.menuListaArticuloDescuentoSAP1.Key = "menuListaArticuloDescuentoSAP"
        Me.menuListaArticuloDescuentoSAP1.Name = "menuListaArticuloDescuentoSAP1"
        '
        'mnuListaArticulosDescuentoSAPGroup1
        '
        Me.mnuListaArticulosDescuentoSAPGroup1.Icon = CType(resources.GetObject("mnuListaArticulosDescuentoSAPGroup1.Icon"), System.Drawing.Icon)
        Me.mnuListaArticulosDescuentoSAPGroup1.Key = "mnuListaArticulosDescuentoSAPGroup"
        Me.mnuListaArticulosDescuentoSAPGroup1.Name = "mnuListaArticulosDescuentoSAPGroup1"
        '
        'menuInventarioMasVendidos1
        '
        Me.menuInventarioMasVendidos1.Key = "menuInventarioMasVendidos"
        Me.menuInventarioMasVendidos1.Name = "menuInventarioMasVendidos1"
        '
        'Separator74
        '
        Me.Separator74.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator74.Key = "Separator"
        Me.Separator74.Name = "Separator74"
        '
        'menuInventarioReporteDifTraslados1
        '
        Me.menuInventarioReporteDifTraslados1.Key = "menuInventarioReporteDifTraslados"
        Me.menuInventarioReporteDifTraslados1.Name = "menuInventarioReporteDifTraslados1"
        '
        'menuInventarioArtSinMov
        '
        Me.menuInventarioArtSinMov.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioArtSinMovPC1, Me.Separator26, Me.menuInventarioArtSinMovLF1, Me.menuInventarioArtSinMovMF1, Me.menuInventarioArtSinMovMLF1})
        Me.menuInventarioArtSinMov.Key = "menuInventarioArtSinMov"
        Me.menuInventarioArtSinMov.Name = "menuInventarioArtSinMov"
        Me.menuInventarioArtSinMov.Text = "Articulos Sin Movimientos"
        '
        'menuInventarioArtSinMovPC1
        '
        Me.menuInventarioArtSinMovPC1.Key = "menuInventarioArtSinMovPC"
        Me.menuInventarioArtSinMovPC1.Name = "menuInventarioArtSinMovPC1"
        '
        'Separator26
        '
        Me.Separator26.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator26.Key = "Separator"
        Me.Separator26.Name = "Separator26"
        '
        'menuInventarioArtSinMovLF1
        '
        Me.menuInventarioArtSinMovLF1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioArtSinMovLF1.Key = "menuInventarioArtSinMovLF"
        Me.menuInventarioArtSinMovLF1.Name = "menuInventarioArtSinMovLF1"
        '
        'menuInventarioArtSinMovMF1
        '
        Me.menuInventarioArtSinMovMF1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuInventarioArtSinMovMF1.Key = "menuInventarioArtSinMovMF"
        Me.menuInventarioArtSinMovMF1.Name = "menuInventarioArtSinMovMF1"
        '
        'menuInventarioArtSinMovMLF1
        '
        Me.menuInventarioArtSinMovMLF1.Key = "menuInventarioArtSinMovMLF"
        Me.menuInventarioArtSinMovMLF1.Name = "menuInventarioArtSinMovMLF1"
        '
        'menuInventarioRepOperacional
        '
        Me.menuInventarioRepOperacional.Key = "menuInventarioRepOperacional"
        Me.menuInventarioRepOperacional.Name = "menuInventarioRepOperacional"
        Me.menuInventarioRepOperacional.Text = "Reporte Operacional"
        '
        'menuInventarioDefectuosos
        '
        Me.menuInventarioDefectuosos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInventarioDefectuosoMAD1, Me.menuInventarioDefectuososDAD1, Me.menuInventarioDefectuosoMADEcm1, Me.Separator27, Me.menuInventarioDesfectuososRDD1, Me.frmRepDefecDet1, Me.menuInventarioReporteDefecEC1})
        Me.menuInventarioDefectuosos.Key = "menuInventarioDefectuosos"
        Me.menuInventarioDefectuosos.Name = "menuInventarioDefectuosos"
        Me.menuInventarioDefectuosos.Text = "Defectuosos"
        '
        'menuInventarioDefectuosoMAD1
        '
        Me.menuInventarioDefectuosoMAD1.Key = "menuInventarioDefectuosoMAD"
        Me.menuInventarioDefectuosoMAD1.Name = "menuInventarioDefectuosoMAD1"
        '
        'menuInventarioDefectuososDAD1
        '
        Me.menuInventarioDefectuososDAD1.Key = "menuInventarioDefectuososDAD"
        Me.menuInventarioDefectuososDAD1.Name = "menuInventarioDefectuososDAD1"
        '
        'menuInventarioDefectuosoMADEcm1
        '
        Me.menuInventarioDefectuosoMADEcm1.Key = "menuInventarioDefectuosoMADEcm"
        Me.menuInventarioDefectuosoMADEcm1.Name = "menuInventarioDefectuosoMADEcm1"
        Me.menuInventarioDefectuosoMADEcm1.Text = "Marcar/Desmarcar Articulos de Baja Calidad"
        '
        'Separator27
        '
        Me.Separator27.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator27.Key = "Separator"
        Me.Separator27.Name = "Separator27"
        '
        'menuInventarioDesfectuososRDD1
        '
        Me.menuInventarioDesfectuososRDD1.Key = "menuInventarioDesfectuososRDD"
        Me.menuInventarioDesfectuososRDD1.Name = "menuInventarioDesfectuososRDD1"
        '
        'frmRepDefecDet1
        '
        Me.frmRepDefecDet1.Key = "frmRepDefecDet"
        Me.frmRepDefecDet1.Name = "frmRepDefecDet1"
        '
        'menuInventarioReporteDefecEC1
        '
        Me.menuInventarioReporteDefecEC1.Key = "menuInventarioReporteDefecEC"
        Me.menuInventarioReporteDefecEC1.Name = "menuInventarioReporteDefecEC1"
        Me.menuInventarioReporteDefecEC1.Text = "Reporte de Articulos Baja Calidad"
        '
        'menuVentasReporteVentaVT
        '
        Me.menuVentasReporteVentaVT.Key = "menuVentasReporteVentaVT"
        Me.menuVentasReporteVentaVT.Name = "menuVentasReporteVentaVT"
        Me.menuVentasReporteVentaVT.Text = "Ventas Totales"
        '
        'menuVentasReporteVentaVED
        '
        Me.menuVentasReporteVentaVED.Key = "menuVentasReporteVentaVED"
        Me.menuVentasReporteVentaVED.Name = "menuVentasReporteVentaVED"
        Me.menuVentasReporteVentaVED.Text = "Venta en Detalle"
        '
        'menuVentasReporteVentaVXH
        '
        Me.menuVentasReporteVentaVXH.Key = "menuVentasReporteVentaVXH"
        Me.menuVentasReporteVentaVXH.Name = "menuVentasReporteVentaVXH"
        Me.menuVentasReporteVentaVXH.Text = "Ventas por Hora"
        '
        'menuVentasReporteVentaPromXH
        '
        Me.menuVentasReporteVentaPromXH.Key = "menuVentasReporteVentaPromXH"
        Me.menuVentasReporteVentaPromXH.Name = "menuVentasReporteVentaPromXH"
        Me.menuVentasReporteVentaPromXH.Text = "Promedio por Hora"
        '
        'menuVentasReporteVXHVentaTotal
        '
        Me.menuVentasReporteVXHVentaTotal.Key = "menuVentasReporteVXHVentaTotal"
        Me.menuVentasReporteVXHVentaTotal.Name = "menuVentasReporteVXHVentaTotal"
        Me.menuVentasReporteVXHVentaTotal.Text = "Ventas en Totales"
        '
        'menuVentasReporteVXHVentaDetalle
        '
        Me.menuVentasReporteVXHVentaDetalle.Key = "menuVentasReporteVXHVentaDetalle"
        Me.menuVentasReporteVXHVentaDetalle.Name = "menuVentasReporteVXHVentaDetalle"
        Me.menuVentasReporteVXHVentaDetalle.Text = "Ventas en Detalle"
        '
        'menuVentasNotaCreditoManejo
        '
        Me.menuVentasNotaCreditoManejo.Key = "menuVentasNotaCreditoManejo"
        Me.menuVentasNotaCreditoManejo.Name = "menuVentasNotaCreditoManejo"
        Me.menuVentasNotaCreditoManejo.Text = "Manejo de Nota de Credito"
        '
        'menuNotasCreditoReportesConcentrado
        '
        Me.menuNotasCreditoReportesConcentrado.Key = "menuNotasCreditoReportesConcentrado"
        Me.menuNotasCreditoReportesConcentrado.Name = "menuNotasCreditoReportesConcentrado"
        Me.menuNotasCreditoReportesConcentrado.Text = "Concentrado"
        '
        'menuNotasCreditoReportesDetallado
        '
        Me.menuNotasCreditoReportesDetallado.Key = "menuNotasCreditoReportesDetallado"
        Me.menuNotasCreditoReportesDetallado.Name = "menuNotasCreditoReportesDetallado"
        Me.menuNotasCreditoReportesDetallado.Text = "Detallado"
        '
        'menuNotasCreditoReportesParciales
        '
        Me.menuNotasCreditoReportesParciales.Key = "menuNotasCreditoReportesParciales"
        Me.menuNotasCreditoReportesParciales.Name = "menuNotasCreditoReportesParciales"
        Me.menuNotasCreditoReportesParciales.Text = "Parciales"
        '
        'menuVentaAnalisisVentaReporte
        '
        Me.menuVentaAnalisisVentaReporte.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNotasCreditoReportesConcentrado1, Me.menuNotasCreditoReportesDetallado1, Me.menuNotasCreditoReportesParciales1})
        Me.menuVentaAnalisisVentaReporte.Key = "menuVentaAnalisisVentaReporte"
        Me.menuVentaAnalisisVentaReporte.Name = "menuVentaAnalisisVentaReporte"
        Me.menuVentaAnalisisVentaReporte.Text = "Reportes"
        '
        'menuNotasCreditoReportesConcentrado1
        '
        Me.menuNotasCreditoReportesConcentrado1.Key = "menuNotasCreditoReportesConcentrado"
        Me.menuNotasCreditoReportesConcentrado1.Name = "menuNotasCreditoReportesConcentrado1"
        '
        'menuNotasCreditoReportesDetallado1
        '
        Me.menuNotasCreditoReportesDetallado1.Key = "menuNotasCreditoReportesDetallado"
        Me.menuNotasCreditoReportesDetallado1.Name = "menuNotasCreditoReportesDetallado1"
        '
        'menuNotasCreditoReportesParciales1
        '
        Me.menuNotasCreditoReportesParciales1.Key = "menuNotasCreditoReportesParciales"
        Me.menuNotasCreditoReportesParciales1.Name = "menuNotasCreditoReportesParciales1"
        '
        'menuVentasCXCAbono
        '
        Me.menuVentasCXCAbono.Key = "menuVentasCXCAbono"
        Me.menuVentasCXCAbono.Name = "menuVentasCXCAbono"
        Me.menuVentasCXCAbono.Text = "Abono"
        Me.menuVentasCXCAbono.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentaCXCCancelarAbono
        '
        Me.menuVentaCXCCancelarAbono.Key = "menuVentaCXCCancelarAbono"
        Me.menuVentaCXCCancelarAbono.Name = "menuVentaCXCCancelarAbono"
        Me.menuVentaCXCCancelarAbono.Text = "Cancelar Abono"
        '
        'menuVentasCXCEdoCuenta
        '
        Me.menuVentasCXCEdoCuenta.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasCXCEdoCtaXCliente1, Me.menuVentasCXCEdoCtaXFact1, Me.menuVentaCXCEdoCtaXGeneral1})
        Me.menuVentasCXCEdoCuenta.Key = "menuVentasCXCEdoCuenta"
        Me.menuVentasCXCEdoCuenta.Name = "menuVentasCXCEdoCuenta"
        Me.menuVentasCXCEdoCuenta.Text = "Estados de Cuenta"
        '
        'menuVentasCXCEdoCtaXCliente1
        '
        Me.menuVentasCXCEdoCtaXCliente1.Key = "menuVentasCXCEdoCtaXCliente"
        Me.menuVentasCXCEdoCtaXCliente1.Name = "menuVentasCXCEdoCtaXCliente1"
        '
        'menuVentasCXCEdoCtaXFact1
        '
        Me.menuVentasCXCEdoCtaXFact1.Key = "menuVentasCXCEdoCtaXFact"
        Me.menuVentasCXCEdoCtaXFact1.Name = "menuVentasCXCEdoCtaXFact1"
        '
        'menuVentaCXCEdoCtaXGeneral1
        '
        Me.menuVentaCXCEdoCtaXGeneral1.Key = "menuVentaCXCEdoCtaXGeneral"
        Me.menuVentaCXCEdoCtaXGeneral1.Name = "menuVentaCXCEdoCtaXGeneral1"
        Me.menuVentaCXCEdoCtaXGeneral1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasCXCEdoCtaXCliente
        '
        Me.menuVentasCXCEdoCtaXCliente.Image = CType(resources.GetObject("menuVentasCXCEdoCtaXCliente.Image"), System.Drawing.Image)
        Me.menuVentasCXCEdoCtaXCliente.Key = "menuVentasCXCEdoCtaXCliente"
        Me.menuVentasCXCEdoCtaXCliente.Name = "menuVentasCXCEdoCtaXCliente"
        Me.menuVentasCXCEdoCtaXCliente.Text = "Por Asociado"
        '
        'menuVentasCXCEdoCtaXFact
        '
        Me.menuVentasCXCEdoCtaXFact.Image = CType(resources.GetObject("menuVentasCXCEdoCtaXFact.Image"), System.Drawing.Image)
        Me.menuVentasCXCEdoCtaXFact.Key = "menuVentasCXCEdoCtaXFact"
        Me.menuVentasCXCEdoCtaXFact.Name = "menuVentasCXCEdoCtaXFact"
        Me.menuVentasCXCEdoCtaXFact.Text = "Por Factura"
        '
        'menuVentaCXCEdoCtaXGeneral
        '
        Me.menuVentaCXCEdoCtaXGeneral.Image = CType(resources.GetObject("menuVentaCXCEdoCtaXGeneral.Image"), System.Drawing.Image)
        Me.menuVentaCXCEdoCtaXGeneral.Key = "menuVentaCXCEdoCtaXGeneral"
        Me.menuVentaCXCEdoCtaXGeneral.Name = "menuVentaCXCEdoCtaXGeneral"
        Me.menuVentaCXCEdoCtaXGeneral.Text = "General"
        '
        'menuVentasCXCReportes
        '
        Me.menuVentasCXCReportes.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasCXCReportesCxC1, Me.menuVentasCXCReportesCxCCanceladas1, Me.menuVentasCXCReportesAbonosRealizados1, Me.menuVentasCXCReportesAbonosCancelado1, Me.menuVentasCXCReportesHistorial1})
        Me.menuVentasCXCReportes.Image = CType(resources.GetObject("menuVentasCXCReportes.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportes.Key = "menuVentasCXCReportes"
        Me.menuVentasCXCReportes.Name = "menuVentasCXCReportes"
        Me.menuVentasCXCReportes.Text = "Reportes"
        '
        'menuVentasCXCReportesCxC1
        '
        Me.menuVentasCXCReportesCxC1.Key = "menuVentasCXCReportesCxC"
        Me.menuVentasCXCReportesCxC1.Name = "menuVentasCXCReportesCxC1"
        Me.menuVentasCXCReportesCxC1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasCXCReportesCxCCanceladas1
        '
        Me.menuVentasCXCReportesCxCCanceladas1.Key = "menuVentasCXCReportesCxCCanceladas"
        Me.menuVentasCXCReportesCxCCanceladas1.Name = "menuVentasCXCReportesCxCCanceladas1"
        Me.menuVentasCXCReportesCxCCanceladas1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasCXCReportesAbonosRealizados1
        '
        Me.menuVentasCXCReportesAbonosRealizados1.Key = "menuVentasCXCReportesAbonosRealizados"
        Me.menuVentasCXCReportesAbonosRealizados1.Name = "menuVentasCXCReportesAbonosRealizados1"
        '
        'menuVentasCXCReportesAbonosCancelado1
        '
        Me.menuVentasCXCReportesAbonosCancelado1.Key = "menuVentasCXCReportesAbonosCancelado"
        Me.menuVentasCXCReportesAbonosCancelado1.Name = "menuVentasCXCReportesAbonosCancelado1"
        Me.menuVentasCXCReportesAbonosCancelado1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasCXCReportesHistorial1
        '
        Me.menuVentasCXCReportesHistorial1.Key = "menuVentasCXCReportesHistorial"
        Me.menuVentasCXCReportesHistorial1.Name = "menuVentasCXCReportesHistorial1"
        Me.menuVentasCXCReportesHistorial1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVer
        '
        Me.menuVer.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVerBarra1})
        Me.menuVer.Key = "menuVer"
        Me.menuVer.Name = "menuVer"
        Me.menuVer.Text = "&Ver"
        '
        'menuVerBarra1
        '
        Me.menuVerBarra1.Image = CType(resources.GetObject("menuVerBarra1.Image"), System.Drawing.Image)
        Me.menuVerBarra1.Key = "menuVerBarra"
        Me.menuVerBarra1.Name = "menuVerBarra1"
        '
        'menuVerBarra
        '
        Me.menuVerBarra.Key = "menuVerBarra"
        Me.menuVerBarra.Name = "menuVerBarra"
        Me.menuVerBarra.Text = "Barra de Herramientas Lateral"
        '
        'menuApartadosRepDApartadoCT
        '
        Me.menuApartadosRepDApartadoCT.Key = "menuApartadosRepDApartadoCT"
        Me.menuApartadosRepDApartadoCT.Name = "menuApartadosRepDApartadoCT"
        Me.menuApartadosRepDApartadoCT.Text = "Contratos Totales"
        '
        'menuApartadosRepDApartadoCD
        '
        Me.menuApartadosRepDApartadoCD.Key = "menuApartadosRepDApartadoCD"
        Me.menuApartadosRepDApartadoCD.Name = "menuApartadosRepDApartadoCD"
        Me.menuApartadosRepDApartadoCD.Text = "Contratos Detalle"
        '
        'menuApartadosRepDApartadoCC
        '
        Me.menuApartadosRepDApartadoCC.Key = "menuApartadosRepDApartadoCC"
        Me.menuApartadosRepDApartadoCC.Name = "menuApartadosRepDApartadoCC"
        Me.menuApartadosRepDApartadoCC.Text = "Contratos Cancelados"
        '
        'menuApartadosRepDApartadoAV
        '
        Me.menuApartadosRepDApartadoAV.Key = "menuApartadosRepDApartadoAV"
        Me.menuApartadosRepDApartadoAV.Name = "menuApartadosRepDApartadoAV"
        Me.menuApartadosRepDApartadoAV.Text = "Apartados Vigentes"
        '
        'menuApartadosRepDApartadoAAV
        '
        Me.menuApartadosRepDApartadoAAV.Key = "menuApartadosRepDApartadoAAV"
        Me.menuApartadosRepDApartadoAAV.Name = "menuApartadosRepDApartadoAAV"
        Me.menuApartadosRepDApartadoAAV.Text = "Apartados a Vencer"
        '
        'menuApartadosRepDAbonoAA
        '
        Me.menuApartadosRepDAbonoAA.Key = "menuApartadosRepDAbonoAA"
        Me.menuApartadosRepDAbonoAA.Name = "menuApartadosRepDAbonoAA"
        Me.menuApartadosRepDAbonoAA.Text = "Abonos/Anticipos"
        '
        'menuApartadosRepDAbonoAC
        '
        Me.menuApartadosRepDAbonoAC.Key = "menuApartadosRepDAbonoAC"
        Me.menuApartadosRepDAbonoAC.Name = "menuApartadosRepDAbonoAC"
        Me.menuApartadosRepDAbonoAC.Text = "Abonos Cancelados"
        '
        'menuApartadosCancelarContratosDef
        '
        Me.menuApartadosCancelarContratosDef.Key = "menuApartadosCancelarContratosDef"
        Me.menuApartadosCancelarContratosDef.Name = "menuApartadosCancelarContratosDef"
        Me.menuApartadosCancelarContratosDef.Text = "Definitiva"
        '
        'menuApartadosCancelarContratoNDCredito
        '
        Me.menuApartadosCancelarContratoNDCredito.Key = "menuApartadosCancelarContratoNDCredito"
        Me.menuApartadosCancelarContratoNDCredito.Name = "menuApartadosCancelarContratoNDCredito"
        Me.menuApartadosCancelarContratoNDCredito.Text = "Para Not. de Credito"
        '
        'menuInventarioMovArticulosPA
        '
        Me.menuInventarioMovArticulosPA.Key = "menuInventarioMovArticulosPA"
        Me.menuInventarioMovArticulosPA.Name = "menuInventarioMovArticulosPA"
        Me.menuInventarioMovArticulosPA.Text = "Por Articulo"
        '
        'menuInventarioMovArticuloTA
        '
        Me.menuInventarioMovArticuloTA.Key = "menuInventarioMovArticuloTA"
        Me.menuInventarioMovArticuloTA.Name = "menuInventarioMovArticuloTA"
        Me.menuInventarioMovArticuloTA.Text = "Todos los Articulos"
        '
        'menuInventarioMovArticulosH2
        '
        Me.menuInventarioMovArticulosH2.Key = "menuInventarioMovArticulosH2"
        Me.menuInventarioMovArticulosH2.Name = "menuInventarioMovArticulosH2"
        Me.menuInventarioMovArticulosH2.Text = "Historico de 2 Años"
        '
        'menuInventarioCostodeInvCod
        '
        Me.menuInventarioCostodeInvCod.Key = "menuInventarioCostodeInvCod"
        Me.menuInventarioCostodeInvCod.Name = "menuInventarioCostodeInvCod"
        Me.menuInventarioCostodeInvCod.Text = "Codigo"
        '
        'menuInventarioCostodeInvCodDet
        '
        Me.menuInventarioCostodeInvCodDet.Key = "menuInventarioCostodeInvCodDet"
        Me.menuInventarioCostodeInvCodDet.Name = "menuInventarioCostodeInvCodDet"
        Me.menuInventarioCostodeInvCodDet.Text = "Codigo Detallado"
        '
        'menuInventarioCostodeInvMarcas
        '
        Me.menuInventarioCostodeInvMarcas.Key = "menuInventarioCostodeInvMarcas"
        Me.menuInventarioCostodeInvMarcas.Name = "menuInventarioCostodeInvMarcas"
        Me.menuInventarioCostodeInvMarcas.Text = "Marcas"
        '
        'menuInventarioCostodeInvLinea
        '
        Me.menuInventarioCostodeInvLinea.Key = "menuInventarioCostodeInvLinea"
        Me.menuInventarioCostodeInvLinea.Name = "menuInventarioCostodeInvLinea"
        Me.menuInventarioCostodeInvLinea.Text = "Linea"
        '
        'menuInventarioCostodeInvFamilia
        '
        Me.menuInventarioCostodeInvFamilia.Key = "menuInventarioCostodeInvFamilia"
        Me.menuInventarioCostodeInvFamilia.Name = "menuInventarioCostodeInvFamilia"
        Me.menuInventarioCostodeInvFamilia.Text = "Familia"
        '
        'menuInventarioCostodeInvUsos
        '
        Me.menuInventarioCostodeInvUsos.Key = "menuInventarioCostodeInvUsos"
        Me.menuInventarioCostodeInvUsos.Name = "menuInventarioCostodeInvUsos"
        Me.menuInventarioCostodeInvUsos.Text = "Usos"
        '
        'menuInventarioCostodeInvSucursal
        '
        Me.menuInventarioCostodeInvSucursal.Key = "menuInventarioCostodeInvSucursal"
        Me.menuInventarioCostodeInvSucursal.Name = "menuInventarioCostodeInvSucursal"
        Me.menuInventarioCostodeInvSucursal.Text = "Sucursal"
        '
        'menuInventarioCostodeInvArtCD
        '
        Me.menuInventarioCostodeInvArtCD.Key = "menuInventarioCostodeInvArtCD"
        Me.menuInventarioCostodeInvArtCD.Name = "menuInventarioCostodeInvArtCD"
        Me.menuInventarioCostodeInvArtCD.Text = "Articulo con Descuento"
        '
        'menuInventarioCostodeInvMLF
        '
        Me.menuInventarioCostodeInvMLF.Key = "menuInventarioCostodeInvMLF"
        Me.menuInventarioCostodeInvMLF.Name = "menuInventarioCostodeInvMLF"
        Me.menuInventarioCostodeInvMLF.Text = "Marca/Linea/Familia"
        '
        'menuInventarioCostodeInvMF
        '
        Me.menuInventarioCostodeInvMF.Key = "menuInventarioCostodeInvMF"
        Me.menuInventarioCostodeInvMF.Name = "menuInventarioCostodeInvMF"
        Me.menuInventarioCostodeInvMF.Text = "Marca/Familia"
        '
        'menuInventarioCostodeInvFM
        '
        Me.menuInventarioCostodeInvFM.Key = "menuInventarioCostodeInvFM"
        Me.menuInventarioCostodeInvFM.Name = "menuInventarioCostodeInvFM"
        Me.menuInventarioCostodeInvFM.Text = "Familia/Marca"
        '
        'menuInventarioCostodeInvRA
        '
        Me.menuInventarioCostodeInvRA.Key = "menuInventarioCostodeInvRA"
        Me.menuInventarioCostodeInvRA.Name = "menuInventarioCostodeInvRA"
        Me.menuInventarioCostodeInvRA.Text = "Rep. Antiguedad"
        '
        'menuInventarioTraspasosTE
        '
        Me.menuInventarioTraspasosTE.Key = "menuInventarioTraspasosTE"
        Me.menuInventarioTraspasosTE.Name = "menuInventarioTraspasosTE"
        Me.menuInventarioTraspasosTE.Text = "Traspaso Entrado"
        '
        'menuInventarioTraspasosSalida
        '
        Me.menuInventarioTraspasosSalida.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuInvDefect1, Me.menuInvDevProv1, Me.menuInvAud1, Me.menuInvTraspasoAutorizar1, Me.Separator69, Me.menuInvConcInv1, Me.menuInvConcVtas1, Me.menuInvTraspasoEC1, Me.menuInvTraspasoErroresCDIST1, Me.menuInvTraspasoVentaDist1, Me.Separator70, Me.menuInvTiendas1})
        Me.menuInventarioTraspasosSalida.Key = "menuInventarioTraspasosSalida"
        Me.menuInventarioTraspasosSalida.Name = "menuInventarioTraspasosSalida"
        Me.menuInventarioTraspasosSalida.Text = "Traspaso Salida"
        '
        'menuInvDefect1
        '
        Me.menuInvDefect1.Key = "menuInvDefect"
        Me.menuInvDefect1.Name = "menuInvDefect1"
        '
        'menuInvDevProv1
        '
        Me.menuInvDevProv1.Key = "menuInvDevProv"
        Me.menuInvDevProv1.Name = "menuInvDevProv1"
        '
        'menuInvAud1
        '
        Me.menuInvAud1.Key = "menuInvAud"
        Me.menuInvAud1.Name = "menuInvAud1"
        Me.menuInvAud1.Text = "Carta de Reclamación"
        '
        'menuInvTraspasoAutorizar1
        '
        Me.menuInvTraspasoAutorizar1.Key = "menuInvTraspasoAutorizar"
        Me.menuInvTraspasoAutorizar1.Name = "menuInvTraspasoAutorizar1"
        '
        'Separator69
        '
        Me.Separator69.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator69.Key = "Separator"
        Me.Separator69.Name = "Separator69"
        '
        'menuInvConcInv1
        '
        Me.menuInvConcInv1.Key = "menuInvConcInv"
        Me.menuInvConcInv1.Name = "menuInvConcInv1"
        Me.menuInvConcInv1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInvConcVtas1
        '
        Me.menuInvConcVtas1.Key = "menuInvConcVtas"
        Me.menuInvConcVtas1.Name = "menuInvConcVtas1"
        Me.menuInvConcVtas1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInvTraspasoEC1
        '
        Me.menuInvTraspasoEC1.Key = "menuInvTraspasoEC"
        Me.menuInvTraspasoEC1.Name = "menuInvTraspasoEC1"
        '
        'menuInvTraspasoErroresCDIST1
        '
        Me.menuInvTraspasoErroresCDIST1.Key = "menuInvTraspasoErroresCDIST"
        Me.menuInvTraspasoErroresCDIST1.Name = "menuInvTraspasoErroresCDIST1"
        Me.menuInvTraspasoErroresCDIST1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInvTraspasoVentaDist1
        '
        Me.menuInvTraspasoVentaDist1.Key = "menuInvTraspasoVentaDist"
        Me.menuInvTraspasoVentaDist1.Name = "menuInvTraspasoVentaDist1"
        Me.menuInvTraspasoVentaDist1.Text = "Por Concentración de Ventas/Inventarios"
        '
        'Separator70
        '
        Me.Separator70.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator70.Key = "Separator"
        Me.Separator70.Name = "Separator70"
        '
        'menuInvTiendas1
        '
        Me.menuInvTiendas1.Key = "menuInvTiendas"
        Me.menuInvTiendas1.Name = "menuInvTiendas1"
        Me.menuInvTiendas1.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'menuInventarioTraspasoPT
        '
        Me.menuInventarioTraspasoPT.Key = "menuInventarioTraspasoPT"
        Me.menuInventarioTraspasoPT.Name = "menuInventarioTraspasoPT"
        Me.menuInventarioTraspasoPT.Text = "Procesar Traspaso"
        '
        'menuInventarioTraspasoModTSalida
        '
        Me.menuInventarioTraspasoModTSalida.Key = "menuInventarioTraspasoModTSalida"
        Me.menuInventarioTraspasoModTSalida.Name = "menuInventarioTraspasoModTSalida"
        Me.menuInventarioTraspasoModTSalida.Text = "Modificar T. de Salida"
        '
        'menuInventarioTraspasoBTG
        '
        Me.menuInventarioTraspasoBTG.Key = "menuInventarioTraspasoBTG"
        Me.menuInventarioTraspasoBTG.Name = "menuInventarioTraspasoBTG"
        Me.menuInventarioTraspasoBTG.Text = "Borrar Traspaso Grabado"
        '
        'menuInventarioTraspasoRDD
        '
        Me.menuInventarioTraspasoRDD.Key = "menuInventarioTraspasoRDD"
        Me.menuInventarioTraspasoRDD.Name = "menuInventarioTraspasoRDD"
        Me.menuInventarioTraspasoRDD.Text = "Reporte de Diferencias"
        '
        'menuInventarioTraspasoTSG
        '
        Me.menuInventarioTraspasoTSG.Key = "menuInventarioTraspasoTSG"
        Me.menuInventarioTraspasoTSG.Name = "menuInventarioTraspasoTSG"
        Me.menuInventarioTraspasoTSG.Text = "Traspasos Sin Grabar"
        '
        'menuInventarioReporteInvPC
        '
        Me.menuInventarioReporteInvPC.Key = "menuInventarioReporteInvPC"
        Me.menuInventarioReporteInvPC.Name = "menuInventarioReporteInvPC"
        Me.menuInventarioReporteInvPC.Text = "Por Codigo"
        '
        'menuInventarioReporteInvLF
        '
        Me.menuInventarioReporteInvLF.Key = "menuInventarioReporteInvLF"
        Me.menuInventarioReporteInvLF.Name = "menuInventarioReporteInvLF"
        Me.menuInventarioReporteInvLF.Text = "Por Linea/Familia"
        '
        'menuInventarioReporteInvLFD
        '
        Me.menuInventarioReporteInvLFD.Key = "menuInventarioReporteInvLFD"
        Me.menuInventarioReporteInvLFD.Name = "menuInventarioReporteInvLFD"
        Me.menuInventarioReporteInvLFD.Text = "Por Linea/Familia DIP"
        '
        'menuInventarioReporteInvMF
        '
        Me.menuInventarioReporteInvMF.Key = "menuInventarioReporteInvMF"
        Me.menuInventarioReporteInvMF.Name = "menuInventarioReporteInvMF"
        Me.menuInventarioReporteInvMF.Text = "Por Marca/Familia"
        '
        'menuInventarioReporteInvMLF
        '
        Me.menuInventarioReporteInvMLF.Key = "menuInventarioReporteInvMLF"
        Me.menuInventarioReporteInvMLF.Name = "menuInventarioReporteInvMLF"
        Me.menuInventarioReporteInvMLF.Text = "Por Marca/Lin/Familia"
        '
        'menuInventarioReporteInvOLF
        '
        Me.menuInventarioReporteInvOLF.Key = "menuInventarioReporteInvOLF"
        Me.menuInventarioReporteInvOLF.Name = "menuInventarioReporteInvOLF"
        Me.menuInventarioReporteInvOLF.Text = "Por Origen/Lin/Familia"
        '
        'menuInventarioReporteInvEN
        '
        Me.menuInventarioReporteInvEN.Key = "menuInventarioReporteInvEN"
        Me.menuInventarioReporteInvEN.Name = "menuInventarioReporteInvEN"
        Me.menuInventarioReporteInvEN.Text = "Existencia Negativa"
        '
        'menuInventarioReporteInvAA
        '
        Me.menuInventarioReporteInvAA.Key = "menuInventarioReporteInvAA"
        Me.menuInventarioReporteInvAA.Name = "menuInventarioReporteInvAA"
        Me.menuInventarioReporteInvAA.Text = "Articulos Apartados"
        '
        'menuInventarioReporteInvUP
        '
        Me.menuInventarioReporteInvUP.Key = "menuInventarioReporteInvUP"
        Me.menuInventarioReporteInvUP.Name = "menuInventarioReporteInvUP"
        Me.menuInventarioReporteInvUP.Text = "Unicos Pares"
        '
        'menuInventarioReporteInvRG
        '
        Me.menuInventarioReporteInvRG.Key = "menuInventarioReporteInvRG"
        Me.menuInventarioReporteInvRG.Name = "menuInventarioReporteInvRG"
        Me.menuInventarioReporteInvRG.Text = "Reportes Globales"
        '
        'menuInventarioArtSinMovPC
        '
        Me.menuInventarioArtSinMovPC.Key = "menuInventarioArtSinMovPC"
        Me.menuInventarioArtSinMovPC.Name = "menuInventarioArtSinMovPC"
        Me.menuInventarioArtSinMovPC.Text = "Por Codigo"
        '
        'menuInventarioArtSinMovLF
        '
        Me.menuInventarioArtSinMovLF.Key = "menuInventarioArtSinMovLF"
        Me.menuInventarioArtSinMovLF.Name = "menuInventarioArtSinMovLF"
        Me.menuInventarioArtSinMovLF.Text = "Por Lineas/Familia"
        Me.menuInventarioArtSinMovLF.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioArtSinMovMF
        '
        Me.menuInventarioArtSinMovMF.Key = "menuInventarioArtSinMovMF"
        Me.menuInventarioArtSinMovMF.Name = "menuInventarioArtSinMovMF"
        Me.menuInventarioArtSinMovMF.Text = "Por Marca/Familia"
        Me.menuInventarioArtSinMovMF.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuInventarioArtSinMovMLF
        '
        Me.menuInventarioArtSinMovMLF.Key = "menuInventarioArtSinMovMLF"
        Me.menuInventarioArtSinMovMLF.Name = "menuInventarioArtSinMovMLF"
        Me.menuInventarioArtSinMovMLF.Text = "Marca/Lin/Familia"
        '
        'menuInventarioDefectuosoMAD
        '
        Me.menuInventarioDefectuosoMAD.Key = "menuInventarioDefectuosoMAD"
        Me.menuInventarioDefectuosoMAD.Name = "menuInventarioDefectuosoMAD"
        Me.menuInventarioDefectuosoMAD.Text = "Marcar Articulos Defectuosos"
        '
        'menuInventarioDefectuososDAD
        '
        Me.menuInventarioDefectuososDAD.Key = "menuInventarioDefectuososDAD"
        Me.menuInventarioDefectuososDAD.Name = "menuInventarioDefectuososDAD"
        Me.menuInventarioDefectuososDAD.Text = "Desmarcar Articulos Defectuosos"
        '
        'menuInventarioDesfectuososRDD
        '
        Me.menuInventarioDesfectuososRDD.Key = "menuInventarioDesfectuososRDD"
        Me.menuInventarioDesfectuososRDD.Name = "menuInventarioDesfectuososRDD"
        Me.menuInventarioDesfectuososRDD.Text = "Reporte de Defectuosos"
        '
        'menuUtileriasCompactarArc
        '
        Me.menuUtileriasCompactarArc.Key = "menuUtileriasCompactarArc"
        Me.menuUtileriasCompactarArc.Name = "menuUtileriasCompactarArc"
        Me.menuUtileriasCompactarArc.Text = "Compactar Archivos"
        '
        'menuUtileriasGenerarArchivos
        '
        Me.menuUtileriasGenerarArchivos.Key = "menuUtileriasGenerarArchivos"
        Me.menuUtileriasGenerarArchivos.Name = "menuUtileriasGenerarArchivos"
        Me.menuUtileriasGenerarArchivos.Text = "Generar Archivos"
        '
        'menuUtileriasEliminarDoc
        '
        Me.menuUtileriasEliminarDoc.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtileriasEliminarFolioFac1, Me.menuUtileriasEliminarFolioCont1, Me.menuUtileriasEliminarFolAbono1})
        Me.menuUtileriasEliminarDoc.Key = "menuUtileriasEliminarDoc"
        Me.menuUtileriasEliminarDoc.Name = "menuUtileriasEliminarDoc"
        Me.menuUtileriasEliminarDoc.Text = "Eliminar Documentos"
        '
        'menuUtileriasEliminarFolioFac1
        '
        Me.menuUtileriasEliminarFolioFac1.Key = "menuUtileriasEliminarFolioFac"
        Me.menuUtileriasEliminarFolioFac1.Name = "menuUtileriasEliminarFolioFac1"
        '
        'menuUtileriasEliminarFolioCont1
        '
        Me.menuUtileriasEliminarFolioCont1.Key = "menuUtileriasEliminarFolioCont"
        Me.menuUtileriasEliminarFolioCont1.Name = "menuUtileriasEliminarFolioCont1"
        '
        'menuUtileriasEliminarFolAbono1
        '
        Me.menuUtileriasEliminarFolAbono1.Key = "menuUtileriasEliminarFolAbono"
        Me.menuUtileriasEliminarFolAbono1.Name = "menuUtileriasEliminarFolAbono1"
        '
        'menuUtileriasProcArc
        '
        Me.menuUtileriasProcArc.Key = "menuUtileriasProcArc"
        Me.menuUtileriasProcArc.Name = "menuUtileriasProcArc"
        Me.menuUtileriasProcArc.Text = "Procesar Archivos"
        '
        'menuUtileriasRespaldarArch
        '
        Me.menuUtileriasRespaldarArch.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtileriasRespaldoResDisco1, Me.Separator28, Me.menuUtileriasFormatoDisco1})
        Me.menuUtileriasRespaldarArch.Key = "menuUtileriasRespaldarArch"
        Me.menuUtileriasRespaldarArch.Name = "menuUtileriasRespaldarArch"
        Me.menuUtileriasRespaldarArch.Text = "Respaldar Archivos"
        '
        'menuUtileriasRespaldoResDisco1
        '
        Me.menuUtileriasRespaldoResDisco1.Key = "menuUtileriasRespaldoResDisco"
        Me.menuUtileriasRespaldoResDisco1.Name = "menuUtileriasRespaldoResDisco1"
        '
        'Separator28
        '
        Me.Separator28.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator28.Key = "Separator"
        Me.Separator28.Name = "Separator28"
        '
        'menuUtileriasFormatoDisco1
        '
        Me.menuUtileriasFormatoDisco1.Key = "menuUtileriasFormatoDisco"
        Me.menuUtileriasFormatoDisco1.Name = "menuUtileriasFormatoDisco1"
        '
        'menuUtileriasMovDAuditoria
        '
        Me.menuUtileriasMovDAuditoria.Key = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria.Name = "menuUtileriasMovDAuditoria"
        Me.menuUtileriasMovDAuditoria.Text = "Movimiento de Auditoria"
        '
        'menuUtileriasCierreDAño
        '
        Me.menuUtileriasCierreDAño.Key = "menuUtileriasCierreDAño"
        Me.menuUtileriasCierreDAño.Name = "menuUtileriasCierreDAño"
        Me.menuUtileriasCierreDAño.Text = "Cierre de Año"
        '
        'menuUtileriasDatosDSucursal
        '
        Me.menuUtileriasDatosDSucursal.Key = "menuUtileriasDatosDSucursal"
        Me.menuUtileriasDatosDSucursal.Name = "menuUtileriasDatosDSucursal"
        Me.menuUtileriasDatosDSucursal.Text = "Datos de Sucursal"
        '
        'menuUtileriasImpDEtiquetas
        '
        Me.menuUtileriasImpDEtiquetas.Checked = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuUtileriasImpDEtiquetas.Key = "menuUtileriasImpDEtiquetas"
        Me.menuUtileriasImpDEtiquetas.Name = "menuUtileriasImpDEtiquetas"
        Me.menuUtileriasImpDEtiquetas.Text = "Impresion de Etiquetas"
        '
        'menuUtileriasDepDInv
        '
        Me.menuUtileriasDepDInv.Key = "menuUtileriasDepDInv"
        Me.menuUtileriasDepDInv.Name = "menuUtileriasDepDInv"
        Me.menuUtileriasDepDInv.Text = "Depuracion de Inventario"
        '
        'menuGeneralesArticulos
        '
        Me.menuGeneralesArticulos.Key = "menuGeneralesArticulos"
        Me.menuGeneralesArticulos.Name = "menuGeneralesArticulos"
        Me.menuGeneralesArticulos.Text = "Articulos"
        '
        'menuGeneralesClientes
        '
        Me.menuGeneralesClientes.Key = "menuGeneralesClientes"
        Me.menuGeneralesClientes.Name = "menuGeneralesClientes"
        Me.menuGeneralesClientes.Text = "Cliente"
        '
        'menuGeneralesProveedores
        '
        Me.menuGeneralesProveedores.Key = "menuGeneralesProveedores"
        Me.menuGeneralesProveedores.Name = "menuGeneralesProveedores"
        Me.menuGeneralesProveedores.Text = "Proveedores"
        '
        'menuGeneralesFamilias
        '
        Me.menuGeneralesFamilias.Key = "menuGeneralesFamilias"
        Me.menuGeneralesFamilias.Name = "menuGeneralesFamilias"
        Me.menuGeneralesFamilias.Text = "Familia"
        '
        'menuGeneralesPlayers
        '
        Me.menuGeneralesPlayers.Key = "menuGeneralesPlayers"
        Me.menuGeneralesPlayers.Name = "menuGeneralesPlayers"
        Me.menuGeneralesPlayers.Text = "Players"
        '
        'menuGeneralesMarcas
        '
        Me.menuGeneralesMarcas.Key = "menuGeneralesMarcas"
        Me.menuGeneralesMarcas.Name = "menuGeneralesMarcas"
        Me.menuGeneralesMarcas.Text = "Marcas"
        '
        'menuGeneralesSucursales
        '
        Me.menuGeneralesSucursales.Key = "menuGeneralesSucursales"
        Me.menuGeneralesSucursales.Name = "menuGeneralesSucursales"
        Me.menuGeneralesSucursales.Text = "Sucursales"
        '
        'menuGeneralesUsos
        '
        Me.menuGeneralesUsos.Key = "menuGeneralesUsos"
        Me.menuGeneralesUsos.Name = "menuGeneralesUsos"
        Me.menuGeneralesUsos.Text = "Usos"
        '
        'menuGeneralesFDePago
        '
        Me.menuGeneralesFDePago.Key = "menuGeneralesFDePago"
        Me.menuGeneralesFDePago.Name = "menuGeneralesFDePago"
        Me.menuGeneralesFDePago.Text = "Forma de Pago"
        '
        'menuGeneralesTDeVenta
        '
        Me.menuGeneralesTDeVenta.Key = "menuGeneralesTDeVenta"
        Me.menuGeneralesTDeVenta.Name = "menuGeneralesTDeVenta"
        Me.menuGeneralesTDeVenta.Text = "T. De Venta"
        '
        'menuGeneralesTDeDev
        '
        Me.menuGeneralesTDeDev.Key = "menuGeneralesTDeDev"
        Me.menuGeneralesTDeDev.Name = "menuGeneralesTDeDev"
        Me.menuGeneralesTDeDev.Text = "T. De Devolucion"
        '
        'menuGeneralesTDeAjuste
        '
        Me.menuGeneralesTDeAjuste.Key = "menuGeneralesTDeAjuste"
        Me.menuGeneralesTDeAjuste.Name = "menuGeneralesTDeAjuste"
        Me.menuGeneralesTDeAjuste.Text = "Tipo Ajuste"
        '
        'menuGeneralesClaveMReg
        '
        Me.menuGeneralesClaveMReg.Key = "menuGeneralesClaveMReg"
        Me.menuGeneralesClaveMReg.Name = "menuGeneralesClaveMReg"
        Me.menuGeneralesClaveMReg.Text = "Clave M. Reg"
        '
        'menuGeneralesCAdmvo
        '
        Me.menuGeneralesCAdmvo.Key = "menuGeneralesCAdmvo"
        Me.menuGeneralesCAdmvo.Name = "menuGeneralesCAdmvo"
        Me.menuGeneralesCAdmvo.Text = "Clave Admnistrativo"
        '
        'menuGeneralesCtaP
        '
        Me.menuGeneralesCtaP.Key = "menuGeneralesCtaP"
        Me.menuGeneralesCtaP.Name = "menuGeneralesCtaP"
        Me.menuGeneralesCtaP.Text = "Cuentas Poliza"
        '
        'menuGeneralesDescuentos
        '
        Me.menuGeneralesDescuentos.Key = "menuGeneralesDescuentos"
        Me.menuGeneralesDescuentos.Name = "menuGeneralesDescuentos"
        Me.menuGeneralesDescuentos.Text = "Descuentos"
        '
        'menuGeneralesManagerT
        '
        Me.menuGeneralesManagerT.Key = "menuGeneralesManagerT"
        Me.menuGeneralesManagerT.Name = "menuGeneralesManagerT"
        Me.menuGeneralesManagerT.Text = "Managers T."
        '
        'menuGeneralesLineas
        '
        Me.menuGeneralesLineas.Key = "menuGeneralesLineas"
        Me.menuGeneralesLineas.Name = "menuGeneralesLineas"
        Me.menuGeneralesLineas.Text = "Lineas"
        '
        'menuGeneralesBancos
        '
        Me.menuGeneralesBancos.Key = "menuGeneralesBancos"
        Me.menuGeneralesBancos.Name = "menuGeneralesBancos"
        Me.menuGeneralesBancos.Text = "Bancos"
        '
        'menuUtileriasEliminarFolioFac
        '
        Me.menuUtileriasEliminarFolioFac.Key = "menuUtileriasEliminarFolioFac"
        Me.menuUtileriasEliminarFolioFac.Name = "menuUtileriasEliminarFolioFac"
        Me.menuUtileriasEliminarFolioFac.Text = "Folio de Facturas"
        '
        'menuUtileriasEliminarFolioCont
        '
        Me.menuUtileriasEliminarFolioCont.Key = "menuUtileriasEliminarFolioCont"
        Me.menuUtileriasEliminarFolioCont.Name = "menuUtileriasEliminarFolioCont"
        Me.menuUtileriasEliminarFolioCont.Text = "Folio de Contratos"
        '
        'menuUtileriasEliminarFolAbono
        '
        Me.menuUtileriasEliminarFolAbono.Key = "menuUtileriasEliminarFolAbono"
        Me.menuUtileriasEliminarFolAbono.Name = "menuUtileriasEliminarFolAbono"
        Me.menuUtileriasEliminarFolAbono.Text = "Folio de Abonos"
        '
        'menuUtileriasRespaldoResDisco
        '
        Me.menuUtileriasRespaldoResDisco.Key = "menuUtileriasRespaldoResDisco"
        Me.menuUtileriasRespaldoResDisco.Name = "menuUtileriasRespaldoResDisco"
        Me.menuUtileriasRespaldoResDisco.Text = "Respaldo de Discos"
        '
        'menuUtileriasFormatoDisco
        '
        Me.menuUtileriasFormatoDisco.Key = "menuUtileriasFormatoDisco"
        Me.menuUtileriasFormatoDisco.Name = "menuUtileriasFormatoDisco"
        Me.menuUtileriasFormatoDisco.Text = "Dar Formato a Discos"
        '
        'menuUtileriasImpPrecioNor
        '
        Me.menuUtileriasImpPrecioNor.Key = "menuUtileriasImpPrecioNor"
        Me.menuUtileriasImpPrecioNor.Name = "menuUtileriasImpPrecioNor"
        Me.menuUtileriasImpPrecioNor.Text = "Precio Normal"
        '
        'menuUtileriasImpPrecioOfert
        '
        Me.menuUtileriasImpPrecioOfert.Key = "menuUtileriasImpPrecioOfert"
        Me.menuUtileriasImpPrecioOfert.Name = "menuUtileriasImpPrecioOfert"
        Me.menuUtileriasImpPrecioOfert.Text = "Precio de Oferta"
        '
        'menuUtileriasImpUna
        '
        Me.menuUtileriasImpUna.Key = "menuUtileriasImpUna"
        Me.menuUtileriasImpUna.Name = "menuUtileriasImpUna"
        Me.menuUtileriasImpUna.Text = "Una en Especifico"
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
        '
        'menuUtilRMAjusteS1
        '
        Me.menuUtilRMAjusteS1.Key = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS1.Name = "menuUtilRMAjusteS1"
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
        '
        'menuUtilRMCostoCodigo1
        '
        Me.menuUtilRMCostoCodigo1.Key = "menuUtilRMCostoCodigo"
        Me.menuUtilRMCostoCodigo1.Name = "menuUtilRMCostoCodigo1"
        '
        'Separator40
        '
        Me.Separator40.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator40.Key = "Separator"
        Me.Separator40.Name = "Separator40"
        '
        'menuUtilRMExistenciaN1
        '
        Me.menuUtilRMExistenciaN1.Key = "menuUtilRMExistenciaN"
        Me.menuUtilRMExistenciaN1.Name = "menuUtilRMExistenciaN1"
        '
        'menuUtilRMDescuentoO1
        '
        Me.menuUtilRMDescuentoO1.Key = "menuUtilRMDescuentoO"
        Me.menuUtilRMDescuentoO1.Name = "menuUtilRMDescuentoO1"
        Me.menuUtilRMDescuentoO1.Text = "Descuentos Otrorgados"
        '
        'Separator41
        '
        Me.Separator41.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator41.Key = "Separator"
        Me.Separator41.Name = "Separator41"
        '
        'menuUtilRMReporteA1
        '
        Me.menuUtilRMReporteA1.Key = "menuUtilRMReporteA"
        Me.menuUtilRMReporteA1.Name = "menuUtilRMReporteA1"
        '
        'Separator42
        '
        Me.Separator42.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator42.Key = "Separator"
        Me.Separator42.Name = "Separator42"
        '
        'menuUtilRMViolacionInv1
        '
        Me.menuUtilRMViolacionInv1.Key = "menuUtilRMViolacionInv"
        Me.menuUtilRMViolacionInv1.Name = "menuUtilRMViolacionInv1"
        '
        'menuUtiExportarInfo
        '
        Me.menuUtiExportarInfo.Key = "menuUtiExportarInfo"
        Me.menuUtiExportarInfo.Name = "menuUtiExportarInfo"
        Me.menuUtiExportarInfo.Text = "Exportar Info"
        '
        'menuUtilCambioTalla
        '
        Me.menuUtilCambioTalla.Key = "menuUtilCambioTalla"
        Me.menuUtilCambioTalla.Name = "menuUtilCambioTalla"
        Me.menuUtilCambioTalla.Text = "Cambio de Talla"
        '
        'menuUtilCancelarCambioTalla
        '
        Me.menuUtilCancelarCambioTalla.Key = "menuUtilCancelarCambioTalla"
        Me.menuUtilCancelarCambioTalla.Name = "menuUtilCancelarCambioTalla"
        Me.menuUtilCancelarCambioTalla.Text = "Cancelar Cambio de Talla"
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
        'menuUtilRepDTraspasos
        '
        Me.menuUtilRepDTraspasos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuReporteTraspasoTT1, Me.menuUtilRepTraspasoTE1, Me.menuUtilRepTraspasoTS1})
        Me.menuUtilRepDTraspasos.Key = "menuUtilRepDTraspasos"
        Me.menuUtilRepDTraspasos.Name = "menuUtilRepDTraspasos"
        Me.menuUtilRepDTraspasos.Text = "Reporte de Traspasos"
        '
        'menuReporteTraspasoTT1
        '
        Me.menuReporteTraspasoTT1.Key = "menuReporteTraspasoTT"
        Me.menuReporteTraspasoTT1.Name = "menuReporteTraspasoTT1"
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
        'menuUtilTrasCancelados
        '
        Me.menuUtilTrasCancelados.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilTrasCanceladosDE1, Me.menuUtilTrasCanceladosDS1, Me.menuUtilTrasCanceladosSG1, Me.menuUtilTrasCanceladosOrigen1})
        Me.menuUtilTrasCancelados.Key = "menuUtilTrasCancelados"
        Me.menuUtilTrasCancelados.Name = "menuUtilTrasCancelados"
        Me.menuUtilTrasCancelados.Text = "Traspasos Cancelados"
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
        'menuUtilAnalCosto
        '
        Me.menuUtilAnalCosto.Key = "menuUtilAnalCosto"
        Me.menuUtilAnalCosto.Name = "menuUtilAnalCosto"
        Me.menuUtilAnalCosto.Text = "Analisis de Costos"
        '
        'menuUtilAnaLU
        '
        Me.menuUtilAnaLU.Key = "menuUtilAnaLU"
        Me.menuUtilAnaLU.Name = "menuUtilAnaLU"
        Me.menuUtilAnaLU.Text = "Analisis de Inv. por Usos"
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
        Me.menuUtilModAjuste.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuUtilModAjusteGeneral1, Me.menuUtilModAjusteEntrada1, Me.menuUtilModAjusteSalida1, Me.Separator60, Me.menuUtilModAjusteEliminar1, Me.menuUtilModAjusteRecibidos2})
        Me.menuUtilModAjuste.Key = "menuUtilModAjuste"
        Me.menuUtilModAjuste.Name = "menuUtilModAjuste"
        Me.menuUtilModAjuste.Text = "Modulo de Ajuste"
        '
        'menuUtilModAjusteGeneral1
        '
        Me.menuUtilModAjusteGeneral1.Key = "menuUtilModAjusteGeneral"
        Me.menuUtilModAjusteGeneral1.Name = "menuUtilModAjusteGeneral1"
        '
        'menuUtilModAjusteEntrada1
        '
        Me.menuUtilModAjusteEntrada1.Key = "menuUtilModAjusteEntrada"
        Me.menuUtilModAjusteEntrada1.Name = "menuUtilModAjusteEntrada1"
        '
        'menuUtilModAjusteSalida1
        '
        Me.menuUtilModAjusteSalida1.Key = "menuUtilModAjusteSalida"
        Me.menuUtilModAjusteSalida1.Name = "menuUtilModAjusteSalida1"
        '
        'Separator60
        '
        Me.Separator60.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator60.Key = "Separator"
        Me.Separator60.Name = "Separator60"
        '
        'menuUtilModAjusteEliminar1
        '
        Me.menuUtilModAjusteEliminar1.Key = "menuUtilModAjusteEliminar"
        Me.menuUtilModAjusteEliminar1.Name = "menuUtilModAjusteEliminar1"
        '
        'menuUtilModAjusteRecibidos2
        '
        Me.menuUtilModAjusteRecibidos2.Key = "menuUtilModAjusteRecibidos"
        Me.menuUtilModAjusteRecibidos2.Name = "menuUtilModAjusteRecibidos2"
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
        'menuGeneralesAlmacen
        '
        Me.menuGeneralesAlmacen.Key = "menuGeneralesAlmacen"
        Me.menuGeneralesAlmacen.Name = "menuGeneralesAlmacen"
        Me.menuGeneralesAlmacen.Text = "Almacen"
        '
        'menuGeneralesCaja
        '
        Me.menuGeneralesCaja.Key = "menuGeneralesCaja"
        Me.menuGeneralesCaja.Name = "menuGeneralesCaja"
        Me.menuGeneralesCaja.Text = "Caja"
        '
        'menuGeneralesCat
        '
        Me.menuGeneralesCat.Key = "menuGeneralesCat"
        Me.menuGeneralesCat.Name = "menuGeneralesCat"
        Me.menuGeneralesCat.Text = "Categorias"
        '
        'menuGeneralesCiudades
        '
        Me.menuGeneralesCiudades.Key = "menuGeneralesCiudades"
        Me.menuGeneralesCiudades.Name = "menuGeneralesCiudades"
        Me.menuGeneralesCiudades.Text = "Ciudades"
        '
        'menuGeneralesCodigoUPC
        '
        Me.menuGeneralesCodigoUPC.Key = "menuGeneralesCodigoUPC"
        Me.menuGeneralesCodigoUPC.Name = "menuGeneralesCodigoUPC"
        Me.menuGeneralesCodigoUPC.Text = "Codigo UPC"
        '
        'menuGeneralesColonias
        '
        Me.menuGeneralesColonias.Key = "menuGeneralesColonias"
        Me.menuGeneralesColonias.Name = "menuGeneralesColonias"
        Me.menuGeneralesColonias.Text = "Colonias"
        '
        'menuGeneralesCorridas
        '
        Me.menuGeneralesCorridas.Key = "menuGeneralesCorridas"
        Me.menuGeneralesCorridas.Name = "menuGeneralesCorridas"
        Me.menuGeneralesCorridas.Text = "Corridas"
        '
        'menuGeneralesEstados
        '
        Me.menuGeneralesEstados.Key = "menuGeneralesEstados"
        Me.menuGeneralesEstados.Name = "menuGeneralesEstados"
        Me.menuGeneralesEstados.Text = "Estados"
        '
        'menuGeneralesFamilia
        '
        Me.menuGeneralesFamilia.Key = "menuGeneralesFamilia"
        Me.menuGeneralesFamilia.Name = "menuGeneralesFamilia"
        Me.menuGeneralesFamilia.Text = "Familia"
        '
        'menuGeneralesOrigenes
        '
        Me.menuGeneralesOrigenes.Key = "menuGeneralesOrigenes"
        Me.menuGeneralesOrigenes.Name = "menuGeneralesOrigenes"
        Me.menuGeneralesOrigenes.Text = "Origenes"
        '
        'menuGeneralesPlaza
        '
        Me.menuGeneralesPlaza.Key = "menuGeneralesPlaza"
        Me.menuGeneralesPlaza.Name = "menuGeneralesPlaza"
        Me.menuGeneralesPlaza.Text = "Plaza"
        '
        'menuGeneralesPublicaciones
        '
        Me.menuGeneralesPublicaciones.Key = "menuGeneralesPublicaciones"
        Me.menuGeneralesPublicaciones.Name = "menuGeneralesPublicaciones"
        Me.menuGeneralesPublicaciones.Text = "Publicaciones"
        '
        'menuGeneralesStatus
        '
        Me.menuGeneralesStatus.Key = "menuGeneralesStatus"
        Me.menuGeneralesStatus.Name = "menuGeneralesStatus"
        Me.menuGeneralesStatus.Text = "Status del Articulo"
        '
        'menuGeneralesTipoCliente
        '
        Me.menuGeneralesTipoCliente.Key = "menuGeneralesTipoCliente"
        Me.menuGeneralesTipoCliente.Name = "menuGeneralesTipoCliente"
        Me.menuGeneralesTipoCliente.Text = "Tipo Cliente"
        '
        'menuGeneralesTipoDescuento
        '
        Me.menuGeneralesTipoDescuento.Key = "menuGeneralesTipoDescuento"
        Me.menuGeneralesTipoDescuento.Name = "menuGeneralesTipoDescuento"
        Me.menuGeneralesTipoDescuento.Text = "Tipo Descuento"
        '
        'menuGeneralesTipoMov
        '
        Me.menuGeneralesTipoMov.Key = "menuGeneralesTipoMov"
        Me.menuGeneralesTipoMov.Name = "menuGeneralesTipoMov"
        Me.menuGeneralesTipoMov.Text = "Tipo Movimiento"
        '
        'menuGeneralesUnidades
        '
        Me.menuGeneralesUnidades.Key = "menuGeneralesUnidades"
        Me.menuGeneralesUnidades.Name = "menuGeneralesUnidades"
        Me.menuGeneralesUnidades.Text = "Unidades"
        '
        'menuGeneralesVentas
        '
        Me.menuGeneralesVentas.Key = "menuGeneralesVentas"
        Me.menuGeneralesVentas.Name = "menuGeneralesVentas"
        Me.menuGeneralesVentas.Text = "Ventas"
        '
        'menuGeneralesTipoTarjeta
        '
        Me.menuGeneralesTipoTarjeta.Key = "menuGeneralesTipoTarjeta"
        Me.menuGeneralesTipoTarjeta.Name = "menuGeneralesTipoTarjeta"
        Me.menuGeneralesTipoTarjeta.Text = "Tipo Tarjeta"
        '
        'menuUtilRMIncongruencia
        '
        Me.menuUtilRMIncongruencia.Key = "menuUtilRMIncongruencia"
        Me.menuUtilRMIncongruencia.Name = "menuUtilRMIncongruencia"
        Me.menuUtilRMIncongruencia.Text = "Incongruencia de Inventario"
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
        Me.menuUtilRMAjusteE.Key = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE.Name = "menuUtilRMAjusteE"
        Me.menuUtilRMAjusteE.Text = "Ajustes de Entrada"
        '
        'menuUtilRMAjusteS
        '
        Me.menuUtilRMAjusteS.Key = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS.Name = "menuUtilRMAjusteS"
        Me.menuUtilRMAjusteS.Text = "Ajustes de Salida"
        '
        'menuUtilRMAjusteG
        '
        Me.menuUtilRMAjusteG.Key = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG.Name = "menuUtilRMAjusteG"
        Me.menuUtilRMAjusteG.Text = "Ajustes Generales"
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
        'menuUtileriasUserRoles
        '
        Me.menuUtileriasUserRoles.Image = CType(resources.GetObject("menuUtileriasUserRoles.Image"), System.Drawing.Image)
        Me.menuUtileriasUserRoles.Key = "menuUtileriasUserRoles"
        Me.menuUtileriasUserRoles.Name = "menuUtileriasUserRoles"
        Me.menuUtileriasUserRoles.Text = "&Usuarios y Roles"
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
        'menuReporteTraspasoTT
        '
        Me.menuReporteTraspasoTT.Key = "menuReporteTraspasoTT"
        Me.menuReporteTraspasoTT.Name = "menuReporteTraspasoTT"
        Me.menuReporteTraspasoTT.Text = "Traspaso en Trasito"
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
        'menuGeneralesVales
        '
        Me.menuGeneralesVales.Key = "menuGeneralesVales"
        Me.menuGeneralesVales.Name = "menuGeneralesVales"
        Me.menuGeneralesVales.Text = "Vales"
        '
        'menuConsultarExistencia
        '
        Me.menuConsultarExistencia.Key = "menuConsultarExistencia"
        Me.menuConsultarExistencia.Name = "menuConsultarExistencia"
        Me.menuConsultarExistencia.Text = "Consultar Existencia"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1, Me.Separator47, Me.menuAyudaAcerca1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ayuda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Image = CType(resources.GetObject("menuAyudaTema1.Image"), System.Drawing.Image)
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'Separator47
        '
        Me.Separator47.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator47.Key = "Separator"
        Me.Separator47.Name = "Separator47"
        '
        'menuAyudaAcerca1
        '
        Me.menuAyudaAcerca1.Image = CType(resources.GetObject("menuAyudaAcerca1.Image"), System.Drawing.Image)
        Me.menuAyudaAcerca1.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca1.Name = "menuAyudaAcerca1"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Tema de Ayuda"
        '
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "Acerca de..."
        '
        'menuRetiros
        '
        Me.menuRetiros.Key = "menuRetiros"
        Me.menuRetiros.Name = "menuRetiros"
        Me.menuRetiros.Text = "Retiros"
        '
        'menuGeneralesTipoVenta
        '
        Me.menuGeneralesTipoVenta.Key = "menuGeneralesTipoVenta"
        Me.menuGeneralesTipoVenta.Name = "menuGeneralesTipoVenta"
        Me.menuGeneralesTipoVenta.Text = "Tipo Venta"
        '
        'menuGeneralesPlayer
        '
        Me.menuGeneralesPlayer.Key = "menuGeneralesPlayer"
        Me.menuGeneralesPlayer.Name = "menuGeneralesPlayer"
        Me.menuGeneralesPlayer.Text = "Player"
        '
        'menuUtilTomadeInventario
        '
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
        'menuClientes
        '
        Me.menuClientes.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuClientesClientes1, Me.menuClientesClientesDPVL1})
        Me.menuClientes.Key = "menuClientes"
        Me.menuClientes.Name = "menuClientes"
        Me.menuClientes.Text = "C&lientes"
        '
        'menuClientesClientes1
        '
        Me.menuClientesClientes1.Icon = CType(resources.GetObject("menuClientesClientes1.Icon"), System.Drawing.Icon)
        Me.menuClientesClientes1.Image = CType(resources.GetObject("menuClientesClientes1.Image"), System.Drawing.Image)
        Me.menuClientesClientes1.Key = "menuClientesClientes"
        Me.menuClientesClientes1.Name = "menuClientesClientes1"
        '
        'menuClientesClientesDPVL1
        '
        Me.menuClientesClientesDPVL1.Key = "menuClientesClientesDPVL"
        Me.menuClientesClientesDPVL1.Name = "menuClientesClientesDPVL1"
        '
        'menuClienteAsociado
        '
        Me.menuClienteAsociado.Key = "menuClienteAsociado"
        Me.menuClienteAsociado.Name = "menuClienteAsociado"
        Me.menuClienteAsociado.Text = "C&lientes"
        '
        'menuClientesClienteAsociado
        '
        Me.menuClientesClienteAsociado.Key = "menuClientesClienteAsociado"
        Me.menuClientesClienteAsociado.Name = "menuClientesClienteAsociado"
        Me.menuClientesClienteAsociado.Text = "Alta Cliente del Asociado"
        '
        'mnuHerramientasOpciones
        '
        Me.mnuHerramientasOpciones.CategoryName = "Herramientas"
        Me.mnuHerramientasOpciones.Image = CType(resources.GetObject("mnuHerramientasOpciones.Image"), System.Drawing.Image)
        Me.mnuHerramientasOpciones.Key = "mnuHerramientasOpciones"
        Me.mnuHerramientasOpciones.Name = "mnuHerramientasOpciones"
        Me.mnuHerramientasOpciones.Text = "&Opciones...."
        '
        'menuClientesClientes
        '
        Me.menuClientesClientes.Key = "menuClientesClientes"
        Me.menuClientesClientes.Name = "menuClientesClientes"
        Me.menuClientesClientes.Text = "Cl&ientes"
        '
        'menuClientesAsociados
        '
        Me.menuClientesAsociados.Key = "menuClientesAsociados"
        Me.menuClientesAsociados.Name = "menuClientesAsociados"
        Me.menuClientesAsociados.Text = "Aso&ciados"
        '
        'menuClientesClienteDPVale
        '
        Me.menuClientesClienteDPVale.Key = "menuClientesClienteDPVale"
        Me.menuClientesClienteDPVale.Name = "menuClientesClienteDPVale"
        Me.menuClientesClienteDPVale.Text = "Cliente DPVale"
        '
        'menuClientesClienteDEnTienda
        '
        Me.menuClientesClienteDEnTienda.Key = "menuClientesClienteDEnTienda"
        Me.menuClientesClienteDEnTienda.Name = "menuClientesClienteDEnTienda"
        Me.menuClientesClienteDEnTienda.Text = "Credito Direct&o en Tienda"
        '
        'menuCredito
        '
        Me.menuCredito.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuClientesAsociados2, Me.Separator64, Me.menuClientesClienteDPVale2, Me.menuClientesClienteDEnTienda2})
        Me.menuCredito.Key = "menuCredito"
        Me.menuCredito.Name = "menuCredito"
        Me.menuCredito.Text = "Cred&ito"
        '
        'menuClientesAsociados2
        '
        Me.menuClientesAsociados2.Image = CType(resources.GetObject("menuClientesAsociados2.Image"), System.Drawing.Image)
        Me.menuClientesAsociados2.Key = "menuClientesAsociados"
        Me.menuClientesAsociados2.Name = "menuClientesAsociados2"
        '
        'Separator64
        '
        Me.Separator64.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator64.Key = "Separator"
        Me.Separator64.Name = "Separator64"
        '
        'menuClientesClienteDPVale2
        '
        Me.menuClientesClienteDPVale2.Image = CType(resources.GetObject("menuClientesClienteDPVale2.Image"), System.Drawing.Image)
        Me.menuClientesClienteDPVale2.Key = "menuClientesClienteDPVale"
        Me.menuClientesClienteDPVale2.Name = "menuClientesClienteDPVale2"
        '
        'menuClientesClienteDEnTienda2
        '
        Me.menuClientesClienteDEnTienda2.Image = CType(resources.GetObject("menuClientesClienteDEnTienda2.Image"), System.Drawing.Image)
        Me.menuClientesClienteDEnTienda2.Key = "menuClientesClienteDEnTienda"
        Me.menuClientesClienteDEnTienda2.Name = "menuClientesClienteDEnTienda2"
        '
        'menuGeneralesBanco
        '
        Me.menuGeneralesBanco.Key = "menuGeneralesBanco"
        Me.menuGeneralesBanco.Name = "menuGeneralesBanco"
        Me.menuGeneralesBanco.Text = "Banco"
        '
        'menuVentasInicioCaja
        '
        Me.menuVentasInicioCaja.Key = "menuVentasInicioCaja"
        Me.menuVentasInicioCaja.Name = "menuVentasInicioCaja"
        Me.menuVentasInicioCaja.Text = "Inicio de Caja"
        '
        'menuVentasCierreCaja
        '
        Me.menuVentasCierreCaja.Key = "menuVentasCierreCaja"
        Me.menuVentasCierreCaja.Name = "menuVentasCierreCaja"
        Me.menuVentasCierreCaja.Text = "Cierre de Caja"
        '
        'menuVentasRetiros
        '
        Me.menuVentasRetiros.Key = "menuVentasRetiros"
        Me.menuVentasRetiros.Name = "menuVentasRetiros"
        Me.menuVentasRetiros.Text = "Retiros"
        '
        'menuVentasACDT
        '
        Me.menuVentasACDT.Key = "menuVentasACDT"
        Me.menuVentasACDT.Name = "menuVentasACDT"
        Me.menuVentasACDT.Text = "Abono Credito Directo"
        '
        'menuVentasValeCaja
        '
        Me.menuVentasValeCaja.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasValeCajaManejo1, Me.Separator68, Me.menuVentasValeCajaReporte1})
        Me.menuVentasValeCaja.Image = CType(resources.GetObject("menuVentasValeCaja.Image"), System.Drawing.Image)
        Me.menuVentasValeCaja.Key = "menuVentasValeCaja"
        Me.menuVentasValeCaja.Name = "menuVentasValeCaja"
        Me.menuVentasValeCaja.Text = "Vale de Caja"
        '
        'menuVentasValeCajaManejo1
        '
        Me.menuVentasValeCajaManejo1.Key = "menuVentasValeCajaManejo"
        Me.menuVentasValeCajaManejo1.Name = "menuVentasValeCajaManejo1"
        Me.menuVentasValeCajaManejo1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator68
        '
        Me.Separator68.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator68.Key = "Separator"
        Me.Separator68.Name = "Separator68"
        Me.Separator68.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuVentasValeCajaReporte1
        '
        Me.menuVentasValeCajaReporte1.Key = "menuVentasValeCajaReporte"
        Me.menuVentasValeCajaReporte1.Name = "menuVentasValeCajaReporte1"
        '
        'menuInventarioTEntradaDBF
        '
        Me.menuInventarioTEntradaDBF.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuContabilizacionSegmentoContable1, Me.Separator66})
        Me.menuInventarioTEntradaDBF.Key = "menuInventarioTEntradaDBF"
        Me.menuInventarioTEntradaDBF.Name = "menuInventarioTEntradaDBF"
        Me.menuInventarioTEntradaDBF.Text = "Traspaso Entrada DBF"
        Me.menuInventarioTEntradaDBF.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuContabilizacionSegmentoContable1
        '
        Me.menuContabilizacionSegmentoContable1.Key = "menuContabilizacionSegmentoContable"
        Me.menuContabilizacionSegmentoContable1.Name = "menuContabilizacionSegmentoContable1"
        '
        'Separator66
        '
        Me.Separator66.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator66.Key = "Separator"
        Me.Separator66.Name = "Separator66"
        '
        'menuContabilizacion
        '
        Me.menuContabilizacion.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuContabilizacionSegmentoContable2, Me.menuContabilizacionDefinicionAsiento1, Me.menuContabilizacionAsignacionAsiento1})
        Me.menuContabilizacion.Key = "menuContabilizacion"
        Me.menuContabilizacion.Name = "menuContabilizacion"
        Me.menuContabilizacion.Text = "Contablilización"
        '
        'menuContabilizacionSegmentoContable2
        '
        Me.menuContabilizacionSegmentoContable2.Key = "menuContabilizacionSegmentoContable"
        Me.menuContabilizacionSegmentoContable2.Name = "menuContabilizacionSegmentoContable2"
        '
        'menuContabilizacionDefinicionAsiento1
        '
        Me.menuContabilizacionDefinicionAsiento1.Key = "menuContabilizacionDefinicionAsiento"
        Me.menuContabilizacionDefinicionAsiento1.Name = "menuContabilizacionDefinicionAsiento1"
        '
        'menuContabilizacionAsignacionAsiento1
        '
        Me.menuContabilizacionAsignacionAsiento1.Key = "menuContabilizacionAsignacionAsiento"
        Me.menuContabilizacionAsignacionAsiento1.Name = "menuContabilizacionAsignacionAsiento1"
        '
        'menuContabilizacionSegmentoContable
        '
        Me.menuContabilizacionSegmentoContable.Key = "menuContabilizacionSegmentoContable"
        Me.menuContabilizacionSegmentoContable.Name = "menuContabilizacionSegmentoContable"
        Me.menuContabilizacionSegmentoContable.Text = "Segmentos Contables"
        '
        'menuContabilizacionDefinicionAsiento
        '
        Me.menuContabilizacionDefinicionAsiento.Key = "menuContabilizacionDefinicionAsiento"
        Me.menuContabilizacionDefinicionAsiento.Name = "menuContabilizacionDefinicionAsiento"
        Me.menuContabilizacionDefinicionAsiento.Text = "Definición de Asientos"
        '
        'menuContabilizacionAsignacionAsiento
        '
        Me.menuContabilizacionAsignacionAsiento.Key = "menuContabilizacionAsignacionAsiento"
        Me.menuContabilizacionAsignacionAsiento.Name = "menuContabilizacionAsignacionAsiento"
        Me.menuContabilizacionAsignacionAsiento.Text = "Asignación de Asientos"
        '
        'menuVentasReasignarPlayer
        '
        Me.menuVentasReasignarPlayer.Image = CType(resources.GetObject("menuVentasReasignarPlayer.Image"), System.Drawing.Image)
        Me.menuVentasReasignarPlayer.Key = "menuVentasReasignarPlayer"
        Me.menuVentasReasignarPlayer.Name = "menuVentasReasignarPlayer"
        Me.menuVentasReasignarPlayer.Text = "Reasignar Player a Facturas"
        '
        'menuVentasValeCajaManejo
        '
        Me.menuVentasValeCajaManejo.Image = CType(resources.GetObject("menuVentasValeCajaManejo.Image"), System.Drawing.Image)
        Me.menuVentasValeCajaManejo.Key = "menuVentasValeCajaManejo"
        Me.menuVentasValeCajaManejo.Name = "menuVentasValeCajaManejo"
        Me.menuVentasValeCajaManejo.Text = "Manejo de Vale de Caja"
        '
        'menuVentasValeCajaReporte
        '
        Me.menuVentasValeCajaReporte.Image = CType(resources.GetObject("menuVentasValeCajaReporte.Image"), System.Drawing.Image)
        Me.menuVentasValeCajaReporte.Key = "menuVentasValeCajaReporte"
        Me.menuVentasValeCajaReporte.Name = "menuVentasValeCajaReporte"
        Me.menuVentasValeCajaReporte.Text = "Reporte de Vale de Caja"
        '
        'menuInventarioReporteVarios
        '
        Me.menuInventarioReporteVarios.CategoryName = "Inventario"
        Me.menuInventarioReporteVarios.Image = CType(resources.GetObject("menuInventarioReporteVarios.Image"), System.Drawing.Image)
        Me.menuInventarioReporteVarios.Key = "menuInventarioReporteVarios"
        Me.menuInventarioReporteVarios.Name = "menuInventarioReporteVarios"
        Me.menuInventarioReporteVarios.Text = "Reportes de Inventario ..."
        '
        'menuVentasCambiarFolio
        '
        Me.menuVentasCambiarFolio.Key = "menuVentasCambiarFolio"
        Me.menuVentasCambiarFolio.Name = "menuVentasCambiarFolio"
        Me.menuVentasCambiarFolio.Text = "Cambiar Folio"
        '
        'menuVentasCXCReportesAbonosRealizados
        '
        Me.menuVentasCXCReportesAbonosRealizados.Image = CType(resources.GetObject("menuVentasCXCReportesAbonosRealizados.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportesAbonosRealizados.Key = "menuVentasCXCReportesAbonosRealizados"
        Me.menuVentasCXCReportesAbonosRealizados.Name = "menuVentasCXCReportesAbonosRealizados"
        Me.menuVentasCXCReportesAbonosRealizados.Text = "Abonos Realizados"
        '
        'menuVentasCXCReportesCxC
        '
        Me.menuVentasCXCReportesCxC.Image = CType(resources.GetObject("menuVentasCXCReportesCxC.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportesCxC.Key = "menuVentasCXCReportesCxC"
        Me.menuVentasCXCReportesCxC.Name = "menuVentasCXCReportesCxC"
        Me.menuVentasCXCReportesCxC.Text = "Cuentas por Cobrar"
        '
        'menuVentasCXCReportesCxCCanceladas
        '
        Me.menuVentasCXCReportesCxCCanceladas.Image = CType(resources.GetObject("menuVentasCXCReportesCxCCanceladas.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportesCxCCanceladas.Key = "menuVentasCXCReportesCxCCanceladas"
        Me.menuVentasCXCReportesCxCCanceladas.Name = "menuVentasCXCReportesCxCCanceladas"
        Me.menuVentasCXCReportesCxCCanceladas.Text = "Cuentas por Cobrar Canceladas"
        '
        'menuVentasCXCReportesAbonosCancelado
        '
        Me.menuVentasCXCReportesAbonosCancelado.Image = CType(resources.GetObject("menuVentasCXCReportesAbonosCancelado.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportesAbonosCancelado.Key = "menuVentasCXCReportesAbonosCancelado"
        Me.menuVentasCXCReportesAbonosCancelado.Name = "menuVentasCXCReportesAbonosCancelado"
        Me.menuVentasCXCReportesAbonosCancelado.Text = "Abonos Cancelados"
        '
        'menuVentasCXCReportesHistorial
        '
        Me.menuVentasCXCReportesHistorial.Image = CType(resources.GetObject("menuVentasCXCReportesHistorial.Image"), System.Drawing.Image)
        Me.menuVentasCXCReportesHistorial.Key = "menuVentasCXCReportesHistorial"
        Me.menuVentasCXCReportesHistorial.Name = "menuVentasCXCReportesHistorial"
        Me.menuVentasCXCReportesHistorial.Text = "Historial Crediticio"
        '
        'menuUtilGananciasAdicionales
        '
        Me.menuUtilGananciasAdicionales.Key = "menuUtilGananciasAdicionales"
        Me.menuUtilGananciasAdicionales.Name = "menuUtilGananciasAdicionales"
        Me.menuUtilGananciasAdicionales.Text = "Ganancias Adicionales"
        '
        'menuUtilesLstPrecios
        '
        Me.menuUtilesLstPrecios.Image = CType(resources.GetObject("menuUtilesLstPrecios.Image"), System.Drawing.Image)
        Me.menuUtilesLstPrecios.Key = "menuUtilesLstPrecios"
        Me.menuUtilesLstPrecios.Name = "menuUtilesLstPrecios"
        Me.menuUtilesLstPrecios.Text = "Lista de Precios"
        '
        'menuUtilGenArchCierreDia
        '
        Me.menuUtilGenArchCierreDia.Key = "menuUtilGenArchCierreDia"
        Me.menuUtilGenArchCierreDia.Name = "menuUtilGenArchCierreDia"
        Me.menuUtilGenArchCierreDia.Text = "Generar Archivos de Cierre de Día"
        '
        'mnuUtileriasConfiguraSAP
        '
        Me.mnuUtileriasConfiguraSAP.Icon = CType(resources.GetObject("mnuUtileriasConfiguraSAP.Icon"), System.Drawing.Icon)
        Me.mnuUtileriasConfiguraSAP.Key = "mnuUtileriasConfiguraSAP"
        Me.mnuUtileriasConfiguraSAP.Name = "mnuUtileriasConfiguraSAP"
        Me.mnuUtileriasConfiguraSAP.Text = "&Configuración SAP"
        '
        'mnuUtileriasCargaInicial
        '
        Me.mnuUtileriasCargaInicial.Icon = CType(resources.GetObject("mnuUtileriasCargaInicial.Icon"), System.Drawing.Icon)
        Me.mnuUtileriasCargaInicial.Key = "mnuUtileriasCargaInicial"
        Me.mnuUtileriasCargaInicial.Name = "mnuUtileriasCargaInicial"
        Me.mnuUtileriasCargaInicial.Text = "Carga Inicial Diaria"
        '
        'menuUtileriasLoadFacturas
        '
        Me.menuUtileriasLoadFacturas.Image = CType(resources.GetObject("menuUtileriasLoadFacturas.Image"), System.Drawing.Image)
        Me.menuUtileriasLoadFacturas.Key = "menuUtileriasLoadFacturas"
        Me.menuUtileriasLoadFacturas.Name = "menuUtileriasLoadFacturas"
        Me.menuUtileriasLoadFacturas.Text = "Guardar Facturas en SAP"
        '
        'menuGerencial
        '
        Me.menuGerencial.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuConfigurarGerencial1, Me.menuTemporadas1, Me.menuAnticiparMetas1})
        Me.menuGerencial.Key = "menuGerencial"
        Me.menuGerencial.Name = "menuGerencial"
        Me.menuGerencial.Text = "Sistema Gerencial"
        '
        'menuConfigurarGerencial1
        '
        Me.menuConfigurarGerencial1.Icon = CType(resources.GetObject("menuConfigurarGerencial1.Icon"), System.Drawing.Icon)
        Me.menuConfigurarGerencial1.Key = "menuConfigurarGerencial"
        Me.menuConfigurarGerencial1.Name = "menuConfigurarGerencial1"
        '
        'menuTemporadas1
        '
        Me.menuTemporadas1.Icon = CType(resources.GetObject("menuTemporadas1.Icon"), System.Drawing.Icon)
        Me.menuTemporadas1.Key = "menuTemporadas"
        Me.menuTemporadas1.Name = "menuTemporadas1"
        '
        'menuAnticiparMetas1
        '
        Me.menuAnticiparMetas1.Icon = CType(resources.GetObject("menuAnticiparMetas1.Icon"), System.Drawing.Icon)
        Me.menuAnticiparMetas1.Key = "menuAnticiparMetas"
        Me.menuAnticiparMetas1.Name = "menuAnticiparMetas1"
        '
        'menuConfigurarGerencial
        '
        Me.menuConfigurarGerencial.Key = "menuConfigurarGerencial"
        Me.menuConfigurarGerencial.Name = "menuConfigurarGerencial"
        Me.menuConfigurarGerencial.Text = "Configurar"
        '
        'menuTemporadas
        '
        Me.menuTemporadas.Key = "menuTemporadas"
        Me.menuTemporadas.Name = "menuTemporadas"
        Me.menuTemporadas.Text = "Temporadas"
        '
        'menuAnticiparMetas
        '
        Me.menuAnticiparMetas.Key = "menuAnticiparMetas"
        Me.menuAnticiparMetas.Name = "menuAnticiparMetas"
        Me.menuAnticiparMetas.Text = "Anticipar Metas"
        '
        'menuActualizaciones
        '
        Me.menuActualizaciones.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuActualizacionesOpcion1, Me.menuActualizacionesXCodigos1, Me.mnuActuDescargaImagenes1})
        Me.menuActualizaciones.Key = "menuActualizaciones"
        Me.menuActualizaciones.Name = "menuActualizaciones"
        Me.menuActualizaciones.Text = "Actuali&zaciones"
        '
        'menuActualizacionesOpcion1
        '
        Me.menuActualizacionesOpcion1.Icon = CType(resources.GetObject("menuActualizacionesOpcion1.Icon"), System.Drawing.Icon)
        Me.menuActualizacionesOpcion1.Key = "menuActualizacionesOpcion"
        Me.menuActualizacionesOpcion1.Name = "menuActualizacionesOpcion1"
        '
        'menuActualizacionesXCodigos1
        '
        Me.menuActualizacionesXCodigos1.Key = "menuActualizacionesXCodigos"
        Me.menuActualizacionesXCodigos1.Name = "menuActualizacionesXCodigos1"
        '
        'mnuActuDescargaImagenes1
        '
        Me.mnuActuDescargaImagenes1.Icon = CType(resources.GetObject("mnuActuDescargaImagenes1.Icon"), System.Drawing.Icon)
        Me.mnuActuDescargaImagenes1.Key = "mnuActuDescargaImagenes"
        Me.mnuActuDescargaImagenes1.Name = "mnuActuDescargaImagenes1"
        Me.mnuActuDescargaImagenes1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuActualizacionesOpcion
        '
        Me.menuActualizacionesOpcion.Image = CType(resources.GetObject("menuActualizacionesOpcion.Image"), System.Drawing.Image)
        Me.menuActualizacionesOpcion.Key = "menuActualizacionesOpcion"
        Me.menuActualizacionesOpcion.Name = "menuActualizacionesOpcion"
        Me.menuActualizacionesOpcion.Text = "Descargar"
        '
        'menuUtileriasRutaArvhivos
        '
        Me.menuUtileriasRutaArvhivos.Key = "menuUtileriasRutaArvhivos"
        Me.menuUtileriasRutaArvhivos.Name = "menuUtileriasRutaArvhivos"
        Me.menuUtileriasRutaArvhivos.Text = "Configuracion Ruta Archivos FI"
        '
        'menuListaArticuloDescuentoSAP
        '
        Me.menuListaArticuloDescuentoSAP.Key = "menuListaArticuloDescuentoSAP"
        Me.menuListaArticuloDescuentoSAP.Name = "menuListaArticuloDescuentoSAP"
        Me.menuListaArticuloDescuentoSAP.Text = "Reporte Articulos con Descuento"
        '
        'menuVentasPorCliente
        '
        Me.menuVentasPorCliente.Key = "menuVentasPorCliente"
        Me.menuVentasPorCliente.Name = "menuVentasPorCliente"
        Me.menuVentasPorCliente.Text = "Ventas por Cliente"
        '
        'menuExportarGAD
        '
        Me.menuExportarGAD.Key = "menuExportarGAD"
        Me.menuExportarGAD.Name = "menuExportarGAD"
        Me.menuExportarGAD.Text = "Exportar Ganancia Adicional"
        '
        'mnuUtilConfigFotos
        '
        Me.mnuUtilConfigFotos.Key = "mnuUtilConfigFotos"
        Me.mnuUtilConfigFotos.Name = "mnuUtilConfigFotos"
        Me.mnuUtilConfigFotos.Text = "Configuracion Imagenes"
        '
        'mnuActuDescargaImagenes
        '
        Me.mnuActuDescargaImagenes.Key = "mnuActuDescargaImagenes"
        Me.mnuActuDescargaImagenes.Name = "mnuActuDescargaImagenes"
        Me.mnuActuDescargaImagenes.Text = "Descargar Imagenes"
        '
        'mnuListaArticulosDescuentoSAPGroup
        '
        Me.mnuListaArticulosDescuentoSAPGroup.Key = "mnuListaArticulosDescuentoSAPGroup"
        Me.mnuListaArticulosDescuentoSAPGroup.Name = "mnuListaArticulosDescuentoSAPGroup"
        Me.mnuListaArticulosDescuentoSAPGroup.Text = "Reporte de Articulos Descuento 20% 30 % 40% 50% ..."
        '
        'menuUtileriasNumeroReferencia
        '
        Me.menuUtileriasNumeroReferencia.Key = "menuUtileriasNumeroReferencia"
        Me.menuUtileriasNumeroReferencia.Name = "menuUtileriasNumeroReferencia"
        Me.menuUtileriasNumeroReferencia.Text = "Numero de Referencia"
        '
        'menuInventariolModAjusteGeneral
        '
        Me.menuInventariolModAjusteGeneral.Image = CType(resources.GetObject("menuInventariolModAjusteGeneral.Image"), System.Drawing.Image)
        Me.menuInventariolModAjusteGeneral.Key = "menuInventariolModAjusteGeneral"
        Me.menuInventariolModAjusteGeneral.Name = "menuInventariolModAjusteGeneral"
        Me.menuInventariolModAjusteGeneral.Text = "Ajuste General"
        '
        'menuInventarioEFExportInfo
        '
        Me.menuInventarioEFExportInfo.Key = "menuInventarioEFExportInfo"
        Me.menuInventarioEFExportInfo.Name = "menuInventarioEFExportInfo"
        Me.menuInventarioEFExportInfo.Text = "Exportar Información Auditoria"
        '
        'MnuUtilCargaArchivosSAP
        '
        Me.MnuUtilCargaArchivosSAP.Image = CType(resources.GetObject("MnuUtilCargaArchivosSAP.Image"), System.Drawing.Image)
        Me.MnuUtilCargaArchivosSAP.Key = "MnuUtilCargaArchivosSAP"
        Me.MnuUtilCargaArchivosSAP.Name = "MnuUtilCargaArchivosSAP"
        Me.MnuUtilCargaArchivosSAP.Text = "Cargar Dias SAP"
        '
        'menuInventarioMasVendidos
        '
        Me.menuInventarioMasVendidos.Image = CType(resources.GetObject("menuInventarioMasVendidos.Image"), System.Drawing.Image)
        Me.menuInventarioMasVendidos.Key = "menuInventarioMasVendidos"
        Me.menuInventarioMasVendidos.Name = "menuInventarioMasVendidos"
        Me.menuInventarioMasVendidos.Text = "Reporte Articulos Mas Vendidos"
        '
        'menuAudDxt
        '
        Me.menuAudDxt.Key = "menuAudDxt"
        Me.menuAudDxt.Name = "menuAudDxt"
        Me.menuAudDxt.Text = "Auditoria de Existencias"
        '
        'CatMotCapMan
        '
        Me.CatMotCapMan.Image = CType(resources.GetObject("CatMotCapMan.Image"), System.Drawing.Image)
        Me.CatMotCapMan.Key = "CatMotCapMan"
        Me.CatMotCapMan.Name = "CatMotCapMan"
        Me.CatMotCapMan.Text = "Catalogo Motivos Captura Manual"
        '
        'RepMotCapMan
        '
        Me.RepMotCapMan.Image = CType(resources.GetObject("RepMotCapMan.Image"), System.Drawing.Image)
        Me.RepMotCapMan.Key = "RepMotCapMan"
        Me.RepMotCapMan.Name = "RepMotCapMan"
        Me.RepMotCapMan.Text = "Reporte Motivos Captura Manual"
        '
        'menuCapturaManual
        '
        Me.menuCapturaManual.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.CatMotCapMan1, Me.RepMotCapMan1})
        Me.menuCapturaManual.Image = CType(resources.GetObject("menuCapturaManual.Image"), System.Drawing.Image)
        Me.menuCapturaManual.Key = "menuCapturaManual"
        Me.menuCapturaManual.Name = "menuCapturaManual"
        Me.menuCapturaManual.Text = "Captura Manual"
        '
        'CatMotCapMan1
        '
        Me.CatMotCapMan1.Key = "CatMotCapMan"
        Me.CatMotCapMan1.Name = "CatMotCapMan1"
        '
        'RepMotCapMan1
        '
        Me.RepMotCapMan1.Key = "RepMotCapMan"
        Me.RepMotCapMan1.Name = "RepMotCapMan1"
        '
        'menuInvDefect
        '
        Me.menuInvDefect.Key = "menuInvDefect"
        Me.menuInvDefect.Name = "menuInvDefect"
        Me.menuInvDefect.Text = "Por Defectuosos"
        '
        'menuInvDevProv
        '
        Me.menuInvDevProv.Key = "menuInvDevProv"
        Me.menuInvDevProv.Name = "menuInvDevProv"
        Me.menuInvDevProv.Text = "Por Devolución a Proveedor"
        '
        'menuInvAud
        '
        Me.menuInvAud.Key = "menuInvAud"
        Me.menuInvAud.Name = "menuInvAud"
        Me.menuInvAud.Text = "Por Auditoria"
        '
        'menuInvConcInv
        '
        Me.menuInvConcInv.Key = "menuInvConcInv"
        Me.menuInvConcInv.Name = "menuInvConcInv"
        Me.menuInvConcInv.Text = "Por Concentración de Inventario"
        '
        'menuInvConcVtas
        '
        Me.menuInvConcVtas.Key = "menuInvConcVtas"
        Me.menuInvConcVtas.Name = "menuInvConcVtas"
        Me.menuInvConcVtas.Text = "Por Concentración de Ventas"
        '
        'menuInvTiendas
        '
        Me.menuInvTiendas.Key = "menuInvTiendas"
        Me.menuInvTiendas.Name = "menuInvTiendas"
        Me.menuInvTiendas.Text = "Entre Tiendas"
        '
        'frmRepDefecDet
        '
        Me.frmRepDefecDet.Key = "frmRepDefecDet"
        Me.frmRepDefecDet.Name = "frmRepDefecDet"
        Me.frmRepDefecDet.Text = "Reporte de Defectuosos a Detalle"
        '
        'menuBitacora
        '
        Me.menuBitacora.Key = "menuBitacora"
        Me.menuBitacora.Name = "menuBitacora"
        Me.menuBitacora.Text = "Bitacora de Movimientos"
        '
        'menuVentasDPValeF
        '
        Me.menuVentasDPValeF.Key = "menuVentasDPValeF"
        Me.menuVentasDPValeF.Name = "menuVentasDPValeF"
        Me.menuVentasDPValeF.Text = "DPVale Financiero"
        '
        'menuUtileriasArchivosDPVF
        '
        Me.menuUtileriasArchivosDPVF.Key = "menuUtileriasArchivosDPVF"
        Me.menuUtileriasArchivosDPVF.Name = "menuUtileriasArchivosDPVF"
        Me.menuUtileriasArchivosDPVF.Text = "Generar Archivos DPVF"
        '
        'menuUtileriasGenArchDPVF
        '
        Me.menuUtileriasGenArchDPVF.Key = "menuUtileriasGenArchDPVF"
        Me.menuUtileriasGenArchDPVF.Name = "menuUtileriasGenArchDPVF"
        Me.menuUtileriasGenArchDPVF.Text = "Generar Archivos DPVale Financiero"
        '
        'menuUtileriasReimprimirTickets
        '
        Me.menuUtileriasReimprimirTickets.Key = "menuUtileriasReimprimirTickets"
        Me.menuUtileriasReimprimirTickets.Name = "menuUtileriasReimprimirTickets"
        Me.menuUtileriasReimprimirTickets.Text = "Reimprimir Tickets"
        '
        'menuImageGearRegistration
        '
        Me.menuImageGearRegistration.Key = "menuImageGearRegistration"
        Me.menuImageGearRegistration.Name = "menuImageGearRegistration"
        Me.menuImageGearRegistration.Text = "Registrar Image Gear"
        '
        'menuUtileriasReimprimirDPVFinanciero
        '
        Me.menuUtileriasReimprimirDPVFinanciero.Key = "menuUtileriasReimprimirDPVFinanciero"
        Me.menuUtileriasReimprimirDPVFinanciero.Name = "menuUtileriasReimprimirDPVFinanciero"
        Me.menuUtileriasReimprimirDPVFinanciero.Text = "Reimprimir DPVale Financiero"
        '
        'menuOperacionalMarcas
        '
        Me.menuOperacionalMarcas.Icon = CType(resources.GetObject("menuOperacionalMarcas.Icon"), System.Drawing.Icon)
        Me.menuOperacionalMarcas.Key = "menuOperacionalMarcas"
        Me.menuOperacionalMarcas.Name = "menuOperacionalMarcas"
        Me.menuOperacionalMarcas.Text = "Reporte Operacional por Marcas"
        '
        'menuOperacionalCodigos
        '
        Me.menuOperacionalCodigos.Icon = CType(resources.GetObject("menuOperacionalCodigos.Icon"), System.Drawing.Icon)
        Me.menuOperacionalCodigos.Key = "menuOperacionalCodigos"
        Me.menuOperacionalCodigos.Name = "menuOperacionalCodigos"
        Me.menuOperacionalCodigos.Text = "Reporte Operacional por Codigos"
        '
        'menuVentasCancelarNotaVenta
        '
        Me.menuVentasCancelarNotaVenta.Image = CType(resources.GetObject("menuVentasCancelarNotaVenta.Image"), System.Drawing.Image)
        Me.menuVentasCancelarNotaVenta.Key = "menuVentasCancelarNotaVenta"
        Me.menuVentasCancelarNotaVenta.Name = "menuVentasCancelarNotaVenta"
        Me.menuVentasCancelarNotaVenta.Text = "Cancelar Nota Venta"
        '
        'menuInvTraspasoEC
        '
        Me.menuInvTraspasoEC.Key = "menuInvTraspasoEC"
        Me.menuInvTraspasoEC.Name = "menuInvTraspasoEC"
        Me.menuInvTraspasoEC.Text = "Para Ecommerce"
        '
        'menuActualizacionesXCodigos
        '
        Me.menuActualizacionesXCodigos.Key = "menuActualizacionesXCodigos"
        Me.menuActualizacionesXCodigos.Name = "menuActualizacionesXCodigos"
        Me.menuActualizacionesXCodigos.Text = "Descargas Por Códigos"
        '
        'menuUtileriasReimprimirCupon
        '
        Me.menuUtileriasReimprimirCupon.Key = "menuUtileriasReimprimirCupon"
        Me.menuUtileriasReimprimirCupon.Name = "menuUtileriasReimprimirCupon"
        Me.menuUtileriasReimprimirCupon.Text = "Reimprimir ReCupon Descuento"
        '
        'menuInvTraspasoErroresCDIST
        '
        Me.menuInvTraspasoErroresCDIST.Key = "menuInvTraspasoErroresCDIST"
        Me.menuInvTraspasoErroresCDIST.Name = "menuInvTraspasoErroresCDIST"
        Me.menuInvTraspasoErroresCDIST.Text = "Por Error del Centro de Distribución"
        '
        'menuInventarioTraspasoEntradaBultos
        '
        Me.menuInventarioTraspasoEntradaBultos.Key = "menuInventarioTraspasoEntradaBultos"
        Me.menuInventarioTraspasoEntradaBultos.Name = "menuInventarioTraspasoEntradaBultos"
        Me.menuInventarioTraspasoEntradaBultos.Text = "Traspaso de Entrada por Bultos"
        '
        'menuInventarioReporteDifTraslados
        '
        Me.menuInventarioReporteDifTraslados.Key = "menuInventarioReporteDifTraslados"
        Me.menuInventarioReporteDifTraslados.Name = "menuInventarioReporteDifTraslados"
        Me.menuInventarioReporteDifTraslados.Text = "Reporte de Diferencias Por Traslados"
        '
        'menuInventarioDefectuosoMADEcm
        '
        Me.menuInventarioDefectuosoMADEcm.Key = "menuInventarioDefectuosoMADEcm"
        Me.menuInventarioDefectuosoMADEcm.Name = "menuInventarioDefectuosoMADEcm"
        Me.menuInventarioDefectuosoMADEcm.Text = "Marcar/Desmarcar Articulos Defectuosos para Ecommerce"
        '
        'menuInventarioSurtirTraspasosSolicitados
        '
        Me.menuInventarioSurtirTraspasosSolicitados.Key = "menuInventarioSurtirTraspasosSolicitados"
        Me.menuInventarioSurtirTraspasosSolicitados.Name = "menuInventarioSurtirTraspasosSolicitados"
        Me.menuInventarioSurtirTraspasosSolicitados.Text = "Surtir Traspasos Ecommerce"
        '
        'menuInventarioPedCancEC
        '
        Me.menuInventarioPedCancEC.Key = "menuInventarioPedCancEC"
        Me.menuInventarioPedCancEC.Name = "menuInventarioPedCancEC"
        Me.menuInventarioPedCancEC.Text = "Pedidos Cancelados de Ecommerce"
        '
        'menuInvTraspasoVentaDist
        '
        Me.menuInvTraspasoVentaDist.Key = "menuInvTraspasoVentaDist"
        Me.menuInvTraspasoVentaDist.Name = "menuInvTraspasoVentaDist"
        Me.menuInvTraspasoVentaDist.Text = "Para Venta de Distribuidores"
        '
        'menuInvTraspasoAutorizar
        '
        Me.menuInvTraspasoAutorizar.Key = "menuInvTraspasoAutorizar"
        Me.menuInvTraspasoAutorizar.Name = "menuInvTraspasoAutorizar"
        Me.menuInvTraspasoAutorizar.Text = "Autorizar Traspaso Por Faltantes"
        '
        'menuInventarioReporteDefecEC
        '
        Me.menuInventarioReporteDefecEC.Key = "menuInventarioReporteDefecEC"
        Me.menuInventarioReporteDefecEC.Name = "menuInventarioReporteDefecEC"
        Me.menuInventarioReporteDefecEC.Text = "Reporte de Articulos Baja Calidad Ecommerce"
        '
        'menuInventarioFacturarPedidosEC
        '
        Me.menuInventarioFacturarPedidosEC.Key = "menuInventarioFacturarPedidosEC"
        Me.menuInventarioFacturarPedidosEC.Name = "menuInventarioFacturarPedidosEC"
        Me.menuInventarioFacturarPedidosEC.Text = "Facturar Pedidos de Ecommerce"
        '
        'menuInventarioAsignarGuiaEC
        '
        Me.menuInventarioAsignarGuiaEC.Key = "menuInventarioAsignarGuiaEC"
        Me.menuInventarioAsignarGuiaEC.Name = "menuInventarioAsignarGuiaEC"
        '
        'menuUtileriasReimprimirVC
        '
        Me.menuUtileriasReimprimirVC.Key = "menuUtileriasReimprimirVC"
        Me.menuUtileriasReimprimirVC.Name = "menuUtileriasReimprimirVC"
        Me.menuUtileriasReimprimirVC.Text = "Reimprimir Vale de Caja"
        '
        'MnuFacturacionSinExistencia
        '
        Me.MnuFacturacionSinExistencia.Key = "MnuFacturacionSinExistencia"
        Me.MnuFacturacionSinExistencia.Name = "MnuFacturacionSinExistencia"
        Me.MnuFacturacionSinExistencia.Text = "Facturación Si Hay"
        '
        'menuSH
        '
        Me.menuSH.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuFacturacionSinExistencia1, Me.menuSurtirPedidosSH1, Me.menuRecibirPedidoSH1, Me.menuFacturarPedidosSH1, Me.menuEnviarPedidoSH1, Me.Separator76, Me.menuPedidosInsurtiblesSH1, Me.MnuCancelacionPedido1, Me.mnuReingresarPedidosCancelados1, Me.menuConsultaExistenciaSH1})
        Me.menuSH.Key = "menuSH"
        Me.menuSH.Name = "menuSH"
        Me.menuSH.Text = """Si Hay"""
        '
        'MnuFacturacionSinExistencia1
        '
        Me.MnuFacturacionSinExistencia1.Icon = CType(resources.GetObject("MnuFacturacionSinExistencia1.Icon"), System.Drawing.Icon)
        Me.MnuFacturacionSinExistencia1.Key = "MnuFacturacionSinExistencia"
        Me.MnuFacturacionSinExistencia1.Name = "MnuFacturacionSinExistencia1"
        Me.MnuFacturacionSinExistencia1.Text = "Creación de Pedidos"
        '
        'menuSurtirPedidosSH1
        '
        Me.menuSurtirPedidosSH1.Icon = CType(resources.GetObject("menuSurtirPedidosSH1.Icon"), System.Drawing.Icon)
        Me.menuSurtirPedidosSH1.Key = "menuSurtirPedidosSH"
        Me.menuSurtirPedidosSH1.Name = "menuSurtirPedidosSH1"
        Me.menuSurtirPedidosSH1.Text = "Surtir Pedidos"
        '
        'menuRecibirPedidoSH1
        '
        Me.menuRecibirPedidoSH1.Icon = CType(resources.GetObject("menuRecibirPedidoSH1.Icon"), System.Drawing.Icon)
        Me.menuRecibirPedidoSH1.Key = "menuRecibirPedidoSH"
        Me.menuRecibirPedidoSH1.Name = "menuRecibirPedidoSH1"
        '
        'menuFacturarPedidosSH1
        '
        Me.menuFacturarPedidosSH1.Icon = CType(resources.GetObject("menuFacturarPedidosSH1.Icon"), System.Drawing.Icon)
        Me.menuFacturarPedidosSH1.Key = "menuFacturarPedidosSH"
        Me.menuFacturarPedidosSH1.Name = "menuFacturarPedidosSH1"
        '
        'menuEnviarPedidoSH1
        '
        Me.menuEnviarPedidoSH1.Icon = CType(resources.GetObject("menuEnviarPedidoSH1.Icon"), System.Drawing.Icon)
        Me.menuEnviarPedidoSH1.Key = "menuEnviarPedidoSH"
        Me.menuEnviarPedidoSH1.Name = "menuEnviarPedidoSH1"
        '
        'Separator76
        '
        Me.Separator76.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator76.Key = "Separator"
        Me.Separator76.Name = "Separator76"
        '
        'menuPedidosInsurtiblesSH1
        '
        Me.menuPedidosInsurtiblesSH1.Icon = CType(resources.GetObject("menuPedidosInsurtiblesSH1.Icon"), System.Drawing.Icon)
        Me.menuPedidosInsurtiblesSH1.Key = "menuPedidosInsurtiblesSH"
        Me.menuPedidosInsurtiblesSH1.Name = "menuPedidosInsurtiblesSH1"
        '
        'MnuCancelacionPedido1
        '
        Me.MnuCancelacionPedido1.Icon = CType(resources.GetObject("MnuCancelacionPedido1.Icon"), System.Drawing.Icon)
        Me.MnuCancelacionPedido1.Key = "MnuCancelacionPedido"
        Me.MnuCancelacionPedido1.Name = "MnuCancelacionPedido1"
        '
        'mnuReingresarPedidosCancelados1
        '
        Me.mnuReingresarPedidosCancelados1.Icon = CType(resources.GetObject("mnuReingresarPedidosCancelados1.Icon"), System.Drawing.Icon)
        Me.mnuReingresarPedidosCancelados1.Key = "mnuReingresarPedidosCancelados"
        Me.mnuReingresarPedidosCancelados1.Name = "mnuReingresarPedidosCancelados1"
        '
        'menuConsultaExistenciaSH1
        '
        Me.menuConsultaExistenciaSH1.Image = CType(resources.GetObject("menuConsultaExistenciaSH1.Image"), System.Drawing.Image)
        Me.menuConsultaExistenciaSH1.Key = "menuConsultaExistenciaSH"
        Me.menuConsultaExistenciaSH1.Name = "menuConsultaExistenciaSH1"
        '
        'menuSurtirPedidosSH
        '
        Me.menuSurtirPedidosSH.Key = "menuSurtirPedidosSH"
        Me.menuSurtirPedidosSH.Name = "menuSurtirPedidosSH"
        Me.menuSurtirPedidosSH.Text = "Surtir Pedidos ""Si Hay"""
        '
        'menuPedidosInsurtiblesSH
        '
        Me.menuPedidosInsurtiblesSH.Key = "menuPedidosInsurtiblesSH"
        Me.menuPedidosInsurtiblesSH.Name = "menuPedidosInsurtiblesSH"
        Me.menuPedidosInsurtiblesSH.Text = "Pedidos Insurtibles"
        '
        'menuRecibirPedidoSH
        '
        Me.menuRecibirPedidoSH.Key = "menuRecibirPedidoSH"
        Me.menuRecibirPedidoSH.Name = "menuRecibirPedidoSH"
        Me.menuRecibirPedidoSH.Text = "Recepción de Productos"
        '
        'menuEnviarPedidoSH
        '
        Me.menuEnviarPedidoSH.Key = "menuEnviarPedidoSH"
        Me.menuEnviarPedidoSH.Name = "menuEnviarPedidoSH"
        Me.menuEnviarPedidoSH.Text = "Enviar Pedidos"
        Me.menuEnviarPedidoSH.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MnuCancelacionPedido
        '
        Me.MnuCancelacionPedido.Key = "MnuCancelacionPedido"
        Me.MnuCancelacionPedido.Name = "MnuCancelacionPedido"
        Me.MnuCancelacionPedido.Text = "Cancelación de Pedidos"
        '
        'menuFacturarPedidosSH
        '
        Me.menuFacturarPedidosSH.Key = "menuFacturarPedidosSH"
        Me.menuFacturarPedidosSH.Name = "menuFacturarPedidosSH"
        Me.menuFacturarPedidosSH.Text = "Facturar Pedidos"
        '
        'mnuReingresarPedidosCancelados
        '
        Me.mnuReingresarPedidosCancelados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mnuReingresarPedidosCancelados.Key = "mnuReingresarPedidosCancelados"
        Me.mnuReingresarPedidosCancelados.Name = "mnuReingresarPedidosCancelados"
        Me.mnuReingresarPedidosCancelados.Text = "ReIngresar Inventario de Pedidos Cancelados"
        Me.mnuReingresarPedidosCancelados.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuConsultaExistenciaSH
        '
        Me.menuConsultaExistenciaSH.Key = "menuConsultaExistenciaSH"
        Me.menuConsultaExistenciaSH.Name = "menuConsultaExistenciaSH"
        Me.menuConsultaExistenciaSH.Text = "Consulta de Existencia"
        '
        'MnuVentasPlayer
        '
        Me.MnuVentasPlayer.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuMetasTienda1, Me.MnuMetasDiarias1})
        Me.MnuVentasPlayer.Key = "MnuVentasPlayer"
        Me.MnuVentasPlayer.Name = "MnuVentasPlayer"
        Me.MnuVentasPlayer.Text = "Menú de Ventas"
        '
        'MnuMetasTienda1
        '
        Me.MnuMetasTienda1.Key = "MnuMetasTienda"
        Me.MnuMetasTienda1.Name = "MnuMetasTienda1"
        '
        'MnuMetasDiarias1
        '
        Me.MnuMetasDiarias1.Key = "MnuMetasDiarias"
        Me.MnuMetasDiarias1.Name = "MnuMetasDiarias1"
        Me.MnuMetasDiarias1.Text = "Metas Diarias Players"
        '
        'MnuMetasDiarias
        '
        Me.MnuMetasDiarias.Key = "MnuMetasDiarias"
        Me.MnuMetasDiarias.Name = "MnuMetasDiarias"
        Me.MnuMetasDiarias.Text = "Cargar Metas diarias"
        '
        'MnuMetasTienda
        '
        Me.MnuMetasTienda.Key = "MnuMetasTienda"
        Me.MnuMetasTienda.Name = "MnuMetasTienda"
        Me.MnuMetasTienda.Text = "Metas Diaria Tienda"
        '
        'menuInventarioTF
        '
        Me.menuInventarioTF.Key = "menuInventarioTF"
        Me.menuInventarioTF.Name = "menuInventarioTF"
        Me.menuInventarioTF.Text = "Traspaso Virtual de Inventario"
        '
        'MnuTraspasoEntradaVirtual
        '
        Me.MnuTraspasoEntradaVirtual.Key = "MnuTraspasoEntradaVirtual"
        Me.MnuTraspasoEntradaVirtual.Name = "MnuTraspasoEntradaVirtual"
        Me.MnuTraspasoEntradaVirtual.Text = "Traspaso Entrada Virtual"
        '
        'menuVentasRecibirOtrosPagos
        '
        Me.menuVentasRecibirOtrosPagos.Image = CType(resources.GetObject("menuVentasRecibirOtrosPagos.Image"), System.Drawing.Image)
        Me.menuVentasRecibirOtrosPagos.Key = "menuVentasRecibirOtrosPagos"
        Me.menuVentasRecibirOtrosPagos.Name = "menuVentasRecibirOtrosPagos"
        Me.menuVentasRecibirOtrosPagos.Text = "Recibir Otros Pagos"
        '
        'menuVentasCancelarOtrosPagos
        '
        Me.menuVentasCancelarOtrosPagos.Image = CType(resources.GetObject("menuVentasCancelarOtrosPagos.Image"), System.Drawing.Image)
        Me.menuVentasCancelarOtrosPagos.Key = "menuVentasCancelarOtrosPagos"
        Me.menuVentasCancelarOtrosPagos.Name = "menuVentasCancelarOtrosPagos"
        Me.menuVentasCancelarOtrosPagos.Text = "Cancelar Otros Pagos"
        '
        'menuUtileriasSaldoDPCard
        '
        Me.menuUtileriasSaldoDPCard.Icon = CType(resources.GetObject("menuUtileriasSaldoDPCard.Icon"), System.Drawing.Icon)
        Me.menuUtileriasSaldoDPCard.Key = "menuUtileriasSaldoDPCard"
        Me.menuUtileriasSaldoDPCard.Name = "menuUtileriasSaldoDPCard"
        Me.menuUtileriasSaldoDPCard.Text = "Consultar Saldo DP Card"
        '
        'MnuDPCardPuntos
        '
        Me.MnuDPCardPuntos.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuConsultaDPCardPunto1, Me.MnuTraspasoDPCardPunto1})
        Me.MnuDPCardPuntos.Key = "MnuDPCardPuntos"
        Me.MnuDPCardPuntos.Name = "MnuDPCardPuntos"
        Me.MnuDPCardPuntos.Text = "DPCard Puntos"
        '
        'MnuConsultaDPCardPunto1
        '
        Me.MnuConsultaDPCardPunto1.Icon = CType(resources.GetObject("MnuConsultaDPCardPunto1.Icon"), System.Drawing.Icon)
        Me.MnuConsultaDPCardPunto1.Key = "MnuConsultaDPCardPunto"
        Me.MnuConsultaDPCardPunto1.Name = "MnuConsultaDPCardPunto1"
        '
        'MnuTraspasoDPCardPunto1
        '
        Me.MnuTraspasoDPCardPunto1.Icon = CType(resources.GetObject("MnuTraspasoDPCardPunto1.Icon"), System.Drawing.Icon)
        Me.MnuTraspasoDPCardPunto1.Key = "MnuTraspasoDPCardPunto"
        Me.MnuTraspasoDPCardPunto1.Name = "MnuTraspasoDPCardPunto1"
        Me.MnuTraspasoDPCardPunto1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'MnuConsultaDPCardPunto
        '
        Me.MnuConsultaDPCardPunto.Key = "MnuConsultaDPCardPunto"
        Me.MnuConsultaDPCardPunto.Name = "MnuConsultaDPCardPunto"
        Me.MnuConsultaDPCardPunto.Text = "Consulta de Saldo"
        '
        'MnuTraspasoDPCardPunto
        '
        Me.MnuTraspasoDPCardPunto.Key = "MnuTraspasoDPCardPunto"
        Me.MnuTraspasoDPCardPunto.Name = "MnuTraspasoDPCardPunto"
        Me.MnuTraspasoDPCardPunto.Text = "Traspaso de puntos"
        '
        'menuInventarioEMT
        '
        Me.menuInventarioEMT.Image = CType(resources.GetObject("menuInventarioEMT.Image"), System.Drawing.Image)
        Me.menuInventarioEMT.Key = "menuInventarioEMT"
        Me.menuInventarioEMT.Name = "menuInventarioEMT"
        Me.menuInventarioEMT.Text = "Recepción de Mercancia en Tiendas de Proveedores"
        '
        'MnuTraspasoEntradaMercancia
        '
        Me.MnuTraspasoEntradaMercancia.Key = "MnuTraspasoEntradaMercancia"
        Me.MnuTraspasoEntradaMercancia.Name = "MnuTraspasoEntradaMercancia"
        Me.MnuTraspasoEntradaMercancia.Text = "Traspaso Entrada de Recepción de Mercancia"
        '
        'menuInventarioReportePedidosEC
        '
        Me.menuInventarioReportePedidosEC.Icon = CType(resources.GetObject("menuInventarioReportePedidosEC.Icon"), System.Drawing.Icon)
        Me.menuInventarioReportePedidosEC.Key = "menuInventarioReportePedidosEC"
        Me.menuInventarioReportePedidosEC.Name = "menuInventarioReportePedidosEC"
        Me.menuInventarioReportePedidosEC.Text = "Reporte de Pedidos de Ecommerce"
        '
        'menuClientesClientesDPVL
        '
        Me.menuClientesClientesDPVL.Key = "menuClientesClientesDPVL"
        Me.menuClientesClientesDPVL.Name = "menuClientesClientesDPVL"
        Me.menuClientesClientesDPVL.Text = "Clientes DPVale"
        '
        'menuCargaNotasCredito
        '
        Me.menuCargaNotasCredito.Key = "menuCargaNotasCredito"
        Me.menuCargaNotasCredito.Name = "menuCargaNotasCredito"
        Me.menuCargaNotasCredito.Text = "Cargar Notas de Crédito"
        '
        'MnuPinPadBanamex
        '
        Me.MnuPinPadBanamex.Key = "MnuPinPadBanamex"
        Me.MnuPinPadBanamex.Name = "MnuPinPadBanamex"
        Me.MnuPinPadBanamex.Text = "Configuración PinPad Banamex"
        '
        'MnuPinPadBanamexOffline
        '
        Me.MnuPinPadBanamexOffline.Key = "MnuPinPadBanamexOffline"
        Me.MnuPinPadBanamexOffline.Name = "MnuPinPadBanamexOffline"
        Me.MnuPinPadBanamexOffline.Text = "Configuracion Pinpad Banamex Offline"
        '
        'MnuCambioTalla
        '
        Me.MnuCambioTalla.Key = "MnuCambioTalla"
        Me.MnuCambioTalla.Name = "MnuCambioTalla"
        Me.MnuCambioTalla.Text = "Cambio de talla"
        '
        'MnuDisposicionEfectivo
        '
        Me.MnuDisposicionEfectivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevaDisposicion1, Me.MnuMonitoreoReproceso1, Me.MnuDisposicionCancelar1})
        Me.MnuDisposicionEfectivo.Key = "MnuDisposicionEfectivo"
        Me.MnuDisposicionEfectivo.Name = "MnuDisposicionEfectivo"
        Me.MnuDisposicionEfectivo.Text = "Disposición de Efectivo"
        '
        'MnuNuevaDisposicion1
        '
        Me.MnuNuevaDisposicion1.Image = CType(resources.GetObject("MnuNuevaDisposicion1.Image"), System.Drawing.Image)
        Me.MnuNuevaDisposicion1.Key = "MnuNuevaDisposicion"
        Me.MnuNuevaDisposicion1.Name = "MnuNuevaDisposicion1"
        '
        'MnuMonitoreoReproceso1
        '
        Me.MnuMonitoreoReproceso1.Image = CType(resources.GetObject("MnuMonitoreoReproceso1.Image"), System.Drawing.Image)
        Me.MnuMonitoreoReproceso1.Key = "MnuMonitoreoReproceso"
        Me.MnuMonitoreoReproceso1.Name = "MnuMonitoreoReproceso1"
        '
        'MnuDisposicionCancelar1
        '
        Me.MnuDisposicionCancelar1.Image = CType(resources.GetObject("MnuDisposicionCancelar1.Image"), System.Drawing.Image)
        Me.MnuDisposicionCancelar1.Key = "MnuDisposicionCancelar"
        Me.MnuDisposicionCancelar1.Name = "MnuDisposicionCancelar1"
        '
        'MnuNuevaDisposicion
        '
        Me.MnuNuevaDisposicion.Key = "MnuNuevaDisposicion"
        Me.MnuNuevaDisposicion.Name = "MnuNuevaDisposicion"
        Me.MnuNuevaDisposicion.Text = "Nueva Disposición"
        '
        'MnuMonitoreoReproceso
        '
        Me.MnuMonitoreoReproceso.Key = "MnuMonitoreoReproceso"
        Me.MnuMonitoreoReproceso.Name = "MnuMonitoreoReproceso"
        Me.MnuMonitoreoReproceso.Text = "Monitoreo y Reproceso"
        '
        'MnuDisposicionCancelar
        '
        Me.MnuDisposicionCancelar.Key = "MnuDisposicionCancelar"
        Me.MnuDisposicionCancelar.Name = "MnuDisposicionCancelar"
        Me.MnuDisposicionCancelar.Text = "Cancelar"
        '
        'MnuCancelacion
        '
        Me.MnuCancelacion.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVentasCancelarFactura1, Me.MnuDevolucionTarjeta1})
        Me.MnuCancelacion.Key = "MnuCancelacion"
        Me.MnuCancelacion.Name = "MnuCancelacion"
        Me.MnuCancelacion.Text = "Cancelación"
        '
        'menuVentasCancelarFactura1
        '
        Me.menuVentasCancelarFactura1.Image = CType(resources.GetObject("menuVentasCancelarFactura1.Image"), System.Drawing.Image)
        Me.menuVentasCancelarFactura1.Key = "menuVentasCancelarFactura"
        Me.menuVentasCancelarFactura1.Name = "menuVentasCancelarFactura1"
        '
        'MnuDevolucionTarjeta1
        '
        Me.MnuDevolucionTarjeta1.Image = CType(resources.GetObject("MnuDevolucionTarjeta1.Image"), System.Drawing.Image)
        Me.MnuDevolucionTarjeta1.Key = "MnuDevolucionTarjeta"
        Me.MnuDevolucionTarjeta1.Name = "MnuDevolucionTarjeta1"
        '
        'MnuDevolucionTarjeta
        '
        Me.MnuDevolucionTarjeta.Key = "MnuDevolucionTarjeta"
        Me.MnuDevolucionTarjeta.Name = "MnuDevolucionTarjeta"
        Me.MnuDevolucionTarjeta.Text = "Devolución de tarjetas"
        '
        'MnuPedidosCompra
        '
        Me.MnuPedidosCompra.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuRecepcionPedido1, Me.MnuDevolucionProveedor1})
        Me.MnuPedidosCompra.Key = "MnuPedidosCompra"
        Me.MnuPedidosCompra.Name = "MnuPedidosCompra"
        Me.MnuPedidosCompra.Text = "Pedidos de Compra"
        '
        'MnuRecepcionPedido1
        '
        Me.MnuRecepcionPedido1.Image = CType(resources.GetObject("MnuRecepcionPedido1.Image"), System.Drawing.Image)
        Me.MnuRecepcionPedido1.Key = "MnuRecepcionPedido"
        Me.MnuRecepcionPedido1.Name = "MnuRecepcionPedido1"
        '
        'MnuDevolucionProveedor1
        '
        Me.MnuDevolucionProveedor1.Image = CType(resources.GetObject("MnuDevolucionProveedor1.Image"), System.Drawing.Image)
        Me.MnuDevolucionProveedor1.Key = "MnuDevolucionProveedor"
        Me.MnuDevolucionProveedor1.Name = "MnuDevolucionProveedor1"
        '
        'MnuRecepcionPedido
        '
        Me.MnuRecepcionPedido.Key = "MnuRecepcionPedido"
        Me.MnuRecepcionPedido.Name = "MnuRecepcionPedido"
        Me.MnuRecepcionPedido.Text = "Recepción de Pedidos"
        '
        'MnuDevolucionProveedor
        '
        Me.MnuDevolucionProveedor.Key = "MnuDevolucionProveedor"
        Me.MnuDevolucionProveedor.Name = "MnuDevolucionProveedor"
        Me.MnuDevolucionProveedor.Text = "Devolución a Proveedor"
        '
        'MenuDescargaManual2
        '
        Me.MenuDescargaManual2.Key = "MenuDescargaManual"
        Me.MenuDescargaManual2.Name = "MenuDescargaManual2"
        Me.MenuDescargaManual2.Text = "Descarga de Archivos"
        '
        'menuReportesWeb
        '
        Me.menuReportesWeb.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRepWeb11})
        Me.menuReportesWeb.Key = "menuReportesWeb"
        Me.menuReportesWeb.Name = "menuReportesWeb"
        Me.menuReportesWeb.Text = "Reportes Web"
        '
        'menuRepWeb11
        '
        Me.menuRepWeb11.Key = "menuRepWeb1"
        Me.menuRepWeb11.Name = "menuRepWeb11"
        '
        'menuRepWeb1
        '
        Me.menuRepWeb1.Key = "menuRepWeb1"
        Me.menuRepWeb1.Name = "menuRepWeb1"
        Me.menuRepWeb1.Text = "Reporte Web"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(804, 22)
        '
        'MenuDescargaManual
        '
        Me.MenuDescargaManual.Key = "MenuDescargaManual"
        Me.MenuDescargaManual.Name = "MenuDescargaManual"
        Me.MenuDescargaManual.Text = "Descarga Manual de Archivos"
        Me.MenuDescargaManual.Visible = Janus.Windows.UI.InheritableBoolean.[True]
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
        'UiStatusBar1
        '
        Me.UiStatusBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UiStatusBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiStatusBar1.Location = New System.Drawing.Point(0, 677)
        Me.UiStatusBar1.Name = "UiStatusBar1"
        UiStatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Text = "Dportenis PRO Versión"
        UiStatusBarPanel1.Width = 391
        UiStatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        UiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel2.FormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel2.Key = ""
        UiStatusBarPanel2.ProgressBarValue = 0
        UiStatusBarPanel2.Width = 390
        Me.UiStatusBar1.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1, UiStatusBarPanel2})
        Me.UiStatusBar1.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.UiStatusBar1.Size = New System.Drawing.Size(804, 24)
        Me.UiStatusBar1.TabIndex = 7
        Me.UiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        'MainForm
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(804, 701)
        Me.Controls.Add(Me.UiStatusBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(0, 726)
        Me.Name = "MainForm"
        Me.Text = "DPORTENIS PRO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.uiConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uiPanel0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Methods"

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim oClickLink As New frmInicioDia

        If oClickLink.ShowDialog() = DialogResult.OK Then
            CompruebaInicioDiaCaja(True)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim oClickLink As New frmInicioCaja
        If oClickLink.ShowDialog = DialogResult.OK Then
            CompruebaInicioDiaCaja(True)
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        oAppContext.Security.CloseImpersonatedSession()
        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CerrarCaja") Then

            Dim oClickLink As New frmCerrarCaja
            oClickLink.ShowMe(oAppContext.Security.CurrentUser.SessionLoginName)

        End If
        oAppContext.Security.CloseImpersonatedSession()

    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim oClickLink As New frmCerrarDia(oConfigCierreFI)
        oClickLink.Show()
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim oClickLink As New frmRetiro
        oClickLink.Show()
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen

        oAlmacen = oAlmacenMgr.Load(strAlmacen)

        Me.Text &= " v" & strVersionSuc & "   Sucursal " & strAlmacen   '"   20100901"

        Me.UiStatusBar1.Panels(0).Text &= " " & strVersionSuc
        Me.UiStatusBar1.Panels(1).Text = Today.ToLongDateString.ToUpper

        If Not oAlmacen Is Nothing Then Me.Text &= " " & oAlmacen.Descripcion.Trim

        Me.Text &= "  Caja " & oAppContext.ApplicationConfiguration.NoCaja

        Dim bolBand As Boolean = False

        CompruebaInicioDiaCaja(bolBand)
        'bolBand = True
        If bolBand Then
            '**********************Reporte de Descuentos Impresion Etiquetas **********************
            Dim frmx As New FrmDescNuevosPrintEtiquetas
            frmx.Show()
            frmx.CargaEtiquetas()
            '**********************Reporte de Descuentos **********************
        End If

        If oConfigCierreFI.RecibirParcialmente = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Commands("menuInvTraspasoErroresCDIST").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Commands("menuInvTraspasoAutorizar").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioReporteInv").Commands("menuInventarioReporteDifTraslados").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasoEntradaBultos").Visible = InheritableBoolean.False
        ElseIf oConfigCierreFI.RecibirPorBultos = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasoEntradaBultos").Visible = InheritableBoolean.False
        End If

        If oConfigCierreFI.RecibirParcialmente AndAlso oConfigCierreFI.BloquearXTP Then
            If RevisaTraspasosPendientes() = False Then
                BloquearSistemaXTP(True)
                MessageBox.Show("Tiene traspasos generados por faltantes pendientes por autorizar." & vbCrLf & "Es necesario que su Auditor de " & _
                                "Plaza los autorice para utilizar las opciones del Sistema.", "DportenisPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Dim oFrmTP As New frmAutorizaTraspasosPendientes(gBloqueo)
                If oFrmTP.ShowDialog = DialogResult.OK Then
                    BloquearSistemaXTP(False)
                End If
            End If
        End If

        If oConfigCierreFI.SurtirEcommerce = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioSurtirTraspasosSolicitados").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioPedCancEC").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioFacturarPedidosEC").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioAsignarGuiaEC").Visible = InheritableBoolean.False
        End If
        '----------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA: Revisamos si esta tienda participa en el proyecto "Si Hay" o no
        '----------------------------------------------------------------------------------------------------------------------------------
        Select Case FacturacionSiHay
            Case -1 'No participa
                Me.UiCommandBar1.Commands("menuSH").Visible = InheritableBoolean.False
            Case 1 'Solicitante
                Me.UiCommandBar1.Commands("menuSH").Commands("menuSurtirPedidosSH").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("menuEnviarPedidoSH").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("mnuReingresarPedidosCancelados").Visible = InheritableBoolean.False
            Case 2 'Suministradora
                Me.UiCommandBar1.Commands("menuSH").Commands("MnuFacturacionSinExistencia").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("menuRecibirPedidoSH").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("menuFacturarPedidosSH").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("menuPedidosInsurtiblesSH").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("MnuCancelacionPedido").Visible = InheritableBoolean.False
                Me.UiCommandBar1.Commands("menuSH").Commands("menuConsultaExistenciaSH").Visible = InheritableBoolean.False
        End Select
        'Me.UiCommandBar1.Commands("menuSH").Visible = InheritableBoolean.True
        '----------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 24/04/2014: Se verifica que haya capturado las metas del Día de la tienda y los Players
        '----------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.ScoreBoard Then
            ValidarMetasDiariasTiendas()
            ValidaMetasDiariasPlayers()
            DashBoard = CType(oPanelControl, HomeDash)
            DashBoard.ShowAndUpdateScoreBoard()
            Me.UiCommandBar1.Commands("MnuVentasPlayer").Visible = InheritableBoolean.True
        Else
            Me.UiCommandBar1.Commands("MnuVentasPlayer").Visible = InheritableBoolean.False
        End If
        '----------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 13.05.2014: Revisamos si se muestra o no el modulo de traspasos fisicos
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.MostrarTF = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTF").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("SeparatorTF").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuInventarios").Commands("MnuTraspasoEntradaVirtual").Visible = InheritableBoolean.False
        End If
        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 27.09.2014: Revisamos si se muestra o no el modulo de Otros Pagos (EC)
        '----------------------------------------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 09.01.2015: Revisamos si se muestra o no el modulo de Otros Pagos (DP Card)
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.RecibirOtrosPagos = False AndAlso oConfigCierreFI.AplicaDPCard = False Then
            Me.UiCommandBar1.Commands("menuVentas").Commands("menuVentasRecibirOtrosPagos").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 12.03.2015: Revisamos si se muestra o no el modulo de Cancelacion Otros Pagos Cancelacion Otros Pagos (DP Card)
        '---------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.CancelarPagosDPCard = False Then
            Me.UiCommandBar1.Commands("menuVentas").Commands("menuVentasCancelarOtrosPagos").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 21.01.2015: Revisamos si se muestra o no el modulo de Consulta de Saldo DP Card  
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.AplicaDPCard = False Then
            Me.UiCommandBar1.Commands("menuUtilerias").Commands("menuUtileriasSaldoDPCard").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 22/04/2015: Habilita o desahabilita dependiendo la configuracion Menu DPCard Puntos
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.DPCardPuntos = False Then
            Me.UiCommandBar1.Commands("MnuDPCardPuntos").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 24.07.2015: Revisamos si se muestra o no el modulo de Recepcion de Mercancia en Tndas de Proveedores
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.RecepcionMercanciaTndas = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("MnuTraspasoEntradaMercancia").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/09/2017: Validación de Menú de configuración de Banamex
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.PagosBanamex = False Then
            Me.UiCommandBar1.Commands("menuUtilerias").Commands("MnuPinPadBanamex").Visible = InheritableBoolean.False
            Me.UiCommandBar1.Commands("menuUtilerias").Commands("MnuPinPadBanamexOffline").Visible = InheritableBoolean.False
        End If

        '----------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/08/2018: Deshabilita en caso de no tener permisos
        '----------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.PedidoCompra = False Then
            Me.UiCommandBar1.Commands("menuInventarios").Commands("MnuPedidosCompra").Visible = InheritableBoolean.False
        End If

    End Sub


    '------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2014: Verifica que se haya capturado las metas diarias de los players
    '------------------------------------------------------------------------------------------------------------------

    Private Sub ValidaMetasDiariasPlayers()
        Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fechaMeta As DateTime = proceso.MSS_GET_SY_DATE_TIME()
        'fechaMeta = New DateTime(2014, 5, 1)
        Dim fechaInicio As DateTime, fechaFin As DateTime
        Dim lstMeses As ArrayList = GetListaMeses()
        If fechaMeta.Day < 16 Then
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 1)
            fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 15)
        Else
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 16)
            If lstMeses.Contains(fechaMeta.Month) Then
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 31)

            Else
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 30)
            End If
        End If
        Dim lstMetasPlayers As ArrayList = MetaDiaPlayer.GetMetasDiasPlayers(fechaInicio, fechaFin)
        If lstMetasPlayers.Count = 0 Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.MetasTienda") Then
                Dim frmMetas As New frmMetasPlayer
                frmMetas.ShowDialog()
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2014: Verifica que haya capturado las metas diarias de la Tienda
    '----------------------------------------------------------------------------------------------------------------

    Private Function ValidarMetasDiariasTiendas() As DialogResult
        Dim result As DialogResult
        result = DialogResult.Cancel
        Dim proceso As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim fechaMeta As DateTime = proceso.MSS_GET_SY_DATE_TIME()
        'fechaMeta = New DateTime(2014, 5, 1)
        Dim fechaInicio As DateTime, fechaFin As DateTime
        Dim lstMeses As ArrayList = GetListaMeses()
        If fechaMeta.Day < 16 Then
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 1)
            fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 15)
        Else
            fechaInicio = New DateTime(fechaMeta.Year, fechaMeta.Month, 16)
            If lstMeses.Contains(fechaMeta.Month) Then
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 31)

            Else
                fechaFin = New DateTime(fechaMeta.Year, fechaMeta.Month, 30)
            End If
        End If
        Dim lstMetasTiendas As ArrayList = MetasDia.GetMetaDias(fechaInicio, fechaFin)
        If lstMetasTiendas.Count = 0 Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.MetasTienda") Then
                Dim frmMetas As New frmMetaDiaTienda
                frmMetas.ShowDialog()
                result = frmMetas.result
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If
        Return result
    End Function

    Public Sub BloquearSistemaXTP(ByVal Bloquear As Boolean)
        Dim Bloq As InheritableBoolean

        If Bloquear Then
            Bloq = InheritableBoolean.False
        Else
            Bloq = InheritableBoolean.True
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'Deshabilitamos menu principal excepto el de inventario
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        Me.UiCommandBar1.Commands("menuVentas").Enabled = Bloq
        'Me.UiCommandBar1.Commands("menuInventarios").Enabled = Bloq
        Me.UiCommandBar1.Commands("menuApartados").Enabled = Bloq
        Me.UiCommandBar1.Commands("menuClientes").Enabled = Bloq
        Me.UiCommandBar1.Commands("menuActualizaciones").Enabled = Bloq
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'Deshabilitamos el submenu de inventario excepto los traspasos
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        Dim i As Integer, Limite As Integer

        Limite = Me.UiCommandBar1.Commands("menuInventarios").Commands.Count - 1

        For i = 0 To Limite
            Me.UiCommandBar1.Commands("menuInventarios").Commands(i).Enabled = Bloq
        Next i
        Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Enabled = InheritableBoolean.True
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'Deshabilitamos el submenu de traspasos excepto el de traspasos de salida
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        Limite = Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands.Count - 1

        For i = 0 To Limite
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands(i).Enabled = Bloq
        Next i
        Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Enabled = InheritableBoolean.True
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'Deshabilitamos el submenu de traspasos de salida excepto la opcion de autorizar traspasos pendientes
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        Limite = Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Commands.Count - 1

        For i = 0 To Limite
            Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Commands(i).Enabled = Bloq
        Next i
        Me.UiCommandBar1.Commands("menuInventarios").Commands("menuInventarioTraspasos").Commands("menuInventarioTraspasosSalida").Commands("menuInvTraspasoAutorizar").Enabled = InheritableBoolean.True

        gBloqueo = Bloquear

    End Sub

    Public Sub CompruebaInicioDiaCaja(ByRef bolBand As Boolean)

        Dim oInicioCajaMgr As New InicioCajaManager(oAppContext)
        Dim oInicioDiaMgr As New InicioDiaManager(oAppContext)
        Dim oInicioCaja As InicioCaja
        Dim oCierreCajaMgr As New CierreCajaManager(oAppContext)
        oInicioCaja = oInicioCajaMgr.Create

        oInicioCaja.InicioDiaID = oInicioDiaMgr.Load(Now.Date, oAppContext.ApplicationConfiguration.Almacen)
        oInicioCaja.InicioCajaID = oInicioCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja, oInicioCaja.InicioDiaID)

        If oInicioCaja.InicioDiaID = 0 Then
            DesActivaMenu()
            Me.UiCommandManager1.Commands.Item("MenuVentasInicioCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 11/06/2013: Si no han hecho el inicio de dia de hoy pero no han hecho el cierre de caja de ayer se activa el menu de retiros
            '-------------------------------------------------------------------------------------------------------------------------------------
            Dim InicioDiaID As Integer, InicioCajaID As Integer

            InicioDiaID = oInicioDiaMgr.Load(Now.AddDays(-1), oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))
            InicioCajaID = oInicioCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja.Trim.PadLeft(2, "0"), InicioDiaID)

            If oCierreCajaMgr.SelByInicioCajaID(InicioCajaID) = False Then Me.UiCommandManager1.Commands("menuVentasRetiros").Enabled = InheritableBoolean.True
            '-----------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 11/06/2013: Mostramos el formulario de inicio de dia para que lo realicen
            '-----------------------------------------------------------------------------------------------------------------------------------
            Dim objInicioDia As New frmInicioDia

            If objInicioDia.ShowDialog() = DialogResult.OK Then
                CompruebaInicioDiaCaja(bolBand)
            End If

        ElseIf oInicioCaja.InicioCajaID = 0 Then
            'SIEMPRE QUE SE HAGA EL INICIO DE CAJA SE APAECERA LA FORMA DE 
            'IMPRESION DE ETIQUETAS
            bolBand = True
            Me.UiCommandManager1.Commands.Item("MenuVentasInicioCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
            DesActivaMenu()
            Dim objInicioCaja As New frmInicioCaja
            If objInicioCaja.ShowDialog() = DialogResult.OK Then
                CompruebaInicioDiaCaja(bolBand)
            End If
        Else
            If Not oCierreCajaMgr.SelByInicioCajaID(oInicioCaja.InicioCajaID) Then
                ActivaMenu()
            Else
                Me.UiCommandManager1.Commands.Item("MenuVentasInicioCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
                DesActivaMenu()
            End If

        End If
    End Sub


   

    Public Sub ActivaMenu()
        Me.UiCommandManager1.Commands.Item("menuVentasFacturacion").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCancelarFactura").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentaNotasCredito").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXC").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentaModDatosFact").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadosContratos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadosAOA").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadoCancelarAbono").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        UiCommandManager1.Commands.Item("menuApartados").Commands.Item("menuApartadoCancelarAbono").Enabled = InheritableBoolean.True
        'Me.UiCommandManager1.Commands.Item("menuInventarioExistdeCodigo").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMov").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioRepOperacional").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasNotaCreditoManejo").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesConcentrado").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesDetallado").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesParciales").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXCAbono").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentaCXCCancelarAbono").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCuenta").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCtaXCliente").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCtaXFact").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentaCXCEdoCtaXGeneral").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasCXCReportes").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratosDef").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratoNDCredito").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasosSalida").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoPT").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoModTSalida").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoBTG").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovPC").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovLF").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovMF").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovMLF").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioDefectuosoMAD").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioDefectuososDAD").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasCompactarArc").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasGenerarArchivos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarDoc").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasProcArc").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasRespaldarArch").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasMovDAuditoria").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasCierreDAño").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasDepDInv").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolioFac").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolioCont").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolAbono").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasRespaldoResDisco").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasFormatoDisco").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpPrecioNor").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpPrecioOfert").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpUna").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtiExportarInfo").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilCancelarCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModFP").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilPreciosDContratos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCancelados").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilAnalCosto").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilAnaLU").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilAnaIMarcas").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilDifEnCosto").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjuste").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilBorrarTras").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRepCostoVenta").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilLiberarCierreDia").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuDesApart").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilArqDCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRevDApartados").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilAnalDVenta").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRecDExistencia").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMIncongruencia").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMDifHistoriInv").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoE").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoS").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoBSG").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteE").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteS").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteG").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMAuditoRet").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMAnalisisInv").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMCostoSuc").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMCostoCodigo").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMExistenciaN").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMArticulosA").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMDescuentoO").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMReporteA").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilRMViolacionInv").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosDE").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosDS").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosSG").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosOrigen").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuRetiros").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilTomadeInventario").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilArqCajaFondoCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilArqCajaIngresoCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteGeneral").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteEntrada").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteSalida").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteRecibidos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuClientes").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuCredito").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasRetiros").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasACDT").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasValeCaja").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuInventarioTEntradaDBF").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasReasignarPlayer").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("menuVentasRecibirOtrosPagos").Enabled = Janus.Windows.UI.InheritableBoolean.Default
        Me.UiCommandManager1.Commands.Item("MnuFacturacionSinExistencia").Enabled = InheritableBoolean.True
    End Sub

    Public Sub DesActivaMenu()

        Me.UiCommandManager1.Commands.Item("menuVentasFacturacion").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCancelarFactura").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentaNotasCredito").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXC").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentaModDatosFact").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadosContratos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadosAOA").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadoCancelarAbono").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandManager1.Commands.Item("menuApartados").Commands.Item("menuApartadoCancelarAbono").Enabled = InheritableBoolean.False
        'Me.UiCommandManager1.Commands.Item("menuInventarioExistdeCodigo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMov").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioRepOperacional").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasNotaCreditoManejo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesConcentrado").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesDetallado").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuNotasCreditoReportesParciales").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXCAbono").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentaCXCCancelarAbono").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCuenta").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCtaXCliente").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXCEdoCtaXFact").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentaCXCEdoCtaXGeneral").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasCXCReportes").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratosDef").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuApartadosCancelarContratoNDCredito").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasosSalida").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoPT").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoModTSalida").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioTraspasoBTG").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovPC").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovLF").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovMF").Enabled = Janus.Windows.UI.InheritableBoolean.False
        'Me.UiCommandManager1.Commands.Item("menuInventarioArtSinMovMLF").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioDefectuosoMAD").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioDefectuososDAD").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasCompactarArc").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasGenerarArchivos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarDoc").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasProcArc").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasRespaldarArch").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasMovDAuditoria").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasCierreDAño").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasDepDInv").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolioFac").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolioCont").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasEliminarFolAbono").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasRespaldoResDisco").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasFormatoDisco").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpPrecioNor").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpPrecioOfert").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtileriasImpUna").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtiExportarInfo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilCancelarCambioTalla").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModFP").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilPreciosDContratos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCancelados").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilAnalCosto").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilAnaLU").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilAnaIMarcas").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilDifEnCosto").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjuste").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilBorrarTras").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRepCostoVenta").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilLiberarCierreDia").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuDesApart").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilArqDCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRevDApartados").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilAnalDVenta").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRecDExistencia").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMIncongruencia").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMDifHistoriInv").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoE").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoS").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMTraspasoBSG").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteE").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteS").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMAjusteG").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMAuditoRet").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMAnalisisInv").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMCostoSuc").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMCostoCodigo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMExistenciaN").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMArticulosA").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMDescuentoO").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMReporteA").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilRMViolacionInv").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosDE").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosDS").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosSG").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTrasCanceladosOrigen").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuRetiros").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilTomadeInventario").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilArqCajaFondoCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilArqCajaIngresoCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteGeneral").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteEntrada").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteSalida").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuUtilModAjusteRecibidos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuClientes").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuCredito").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasRetiros").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasACDT").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasValeCaja").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuInventarioTEntradaDBF").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasReasignarPlayer").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("menuVentasRecibirOtrosPagos").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.Commands.Item("MnuFacturacionSinExistencia").Enabled = InheritableBoolean.False
    End Sub


    Private Function GetConfigEcomm() As ConfigEcomm
        Dim pagoMgr As New CatalogoFormasPagoManager(oAppContext, oConfigCierreFI)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim AlmacenMgr As New DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        Dim Almacen As DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Almacen = AlmacenMgr.Load(oSAPMgr.Read_Centros())
        Dim config As ConfigEcomm = pagoMgr.CreateConfig()
        config.Tienda = "sw" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0") & oAppContext.ApplicationConfiguration.NoCaja.PadLeft(5, "0")
        config.Nombre = Almacen.Descripcion
        config.CalleNum = Almacen.DireccionNumExt
        config.Colonia = Almacen.DireccionColonia
        config.CP = Almacen.DireccionCP
        config.Telefono = Almacen.TelefonoNum
        config.Ciudad = Almacen.DireccionCiudad
        config.Estado = Almacen.DireccionEstado
        Return config
    End Function



    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Dim nHwnI As System.IntPtr

        Select Case e.Command.Key

            Case "menuBitacora"
                Dim oForm As New frmBitacoraDeMovimientos
                oform.ShowDialog()
            Case "menuAudDxt"
                Dim oForm As New frmAuditoria
                oForm.Show()
                'MODULO DE AUDITORIA
            Case "menuUtileriasMovDAuditoria"

                'Dim nHwnI As System.IntPtr
                nHwnI = FindWindow(vbNullString, "Módulo de Auditoría")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim oModuloAuditoria As New MainFormAuditoria
                    oModuloAuditoria.ShowDialog()
                End If

                '***************************VENTAS**********************************
            Case "menuVentasFacturacion"
                CallFacturacion()
            Case "MnuFacturacionSinExistencia"
                CallFacturacionSiHay()
            Case "menuVentasCambioTalla"
                Dim menuClickB As New frmAjustesTalla
                menuClickB.Show()

            Case "menuVentaInicio"
                Dim menuClickB As New frmInicioDia
                If menuClickB.ShowDialog = DialogResult.OK Then
                    CompruebaInicioDiaCaja(True)
                End If

            Case "menuVentasCancelarFactura"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.CancelacionFacturaSH") = True Then
                    Dim menuClickB As New frmCancelarFactura
                    menuClickB.Show()
                End If


            Case "menuVentasCancelarNotaVenta"
                Dim menuClickB As New frmCancelarNotaVenta
                menuClickB.Show()

            Case "menuVentasCambiarFolio"

                '    'Validar que el Módulo Facturación no se encuentre Abierto.
                '    nHwnI = FindWindow(vbNullString, "Facturación")
                '    If Val(nHwnI.ToString) <> 0 Then
                '        MsgBox("Debe Cerrar el Módulo de Facturación.", MsgBoxStyle.Exclamation, "DPTienda")
                '        Exit Sub
                '    End If

                '    Dim menuClickB As New FrmCambiarFolio
                '    menuClickB.Show()

            Case "menuVentasCierreDia"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CerrarDia") Then

                    Dim oClickLink As New frmCerrarDia(oConfigCierreFI)
                    oClickLink.ShowMe(oAppContext.Security.CurrentUser.SessionLoginName)
                    If oClickLink.DialogResult = DialogResult.OK Then
                        DesActivaMenu()
                    End If

                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuVentasReporteVentaVT"
                'HACK: Fix this line
                Dim menuClickB As New VentasTotalesReportForm
                menuClickB.Show()

            Case "menuVentasReporteVentaVED"
                'HACK: Fix this line
                Dim menuClickBB As New VentasDetalleReportForm
                menuClickBB.Show()

            Case "menuVentasReporteVentaVXH"
                Dim menuClickB As New frmVentasPorHora
                menuClickB.Show()
            Case "menuVentasReporteVentaPromXH"
                Dim menuClickB As New frmRangos
                menuClickB.Show()
            Case "menuVentaAnalisisVenta"
                'Dim menuClickB As New frmPasswordGenerico
                'menuClickB.Show()
                Dim formAnalisisDeVenta As New frmAnalisisDeVentas
                formAnalisisDeVenta.Show()



            Case "menuVentasNotaCreditoManejo"
                'Validamos que se hayan hecho las Cargas Iniciales Completas
                Dim dsCargas As DataSet
                dsCargas = oServerUPCMgr.CargasInicialesSelByTienda(oAppContext.ApplicationConfiguration.Almacen)

                If Not dsCargas Is Nothing Then
                    If dsCargas.Tables(0).Rows.Count > 0 Then
                        Dim strCatalogos As String = ""
                        For Each oRow As DataRow In dsCargas.Tables(0).Rows
                            '------------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 27/12/2014: Si aplica el cross selling que no pida realizar la descarga de descuentos adicionales
                            '------------------------------------------------------------------------------------------------------------
                            If oConfigCierreFI.AplicaCrossSelling Then
                                If oRow.Item(1) <> "DesA" Then
                                    strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                                End If
                            Else
                                strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                            End If
                            'strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf

                        Next
                        If strCatalogos <> "" Then
                            MsgBox("Las siguientes Actualizaciones estan incompletas. Favor de hacer las descargas." _
                                                     & Microsoft.VisualBasic.vbCrLf & strCatalogos)
                            Exit Select
                        End If

                        'Exit Select

                    End If
                End If

                nHwnI = FindWindow(vbNullString, "Modulo de Captura de Notas de Credito")
                If Val(nHwnI.ToString) <> 0 Then

                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)

                Else

                    Dim menuClickB As New frmModCapNotCredito
                    menuClickB.Show()

                End If

            Case "menuNotasCreditoReportesDetallado"
                Dim menuClickB As New frmRangos
                menuClickB.Show()
            Case "menuNotasCreditoReportesParciales"
                Dim menuClickB As New frmRangos
                menuClickB.Show()
            Case "menuVentasCXCAbono"
                Dim menuClickB As New FrmAbonoDPVale
                menuClickB.Show()
            Case "menuVentaCXCCancelarAbono"
                Dim menuClickB As New frmPasswordGenerico
                menuClickB.Show()

                '</ Estados de Cuenta CXC>

            Case "menuVentasCXCEdoCtaXCliente"
                Dim menuClickB As New EstadoCuentaClienteReportForm
                menuClickB.Show()

            Case "menuVentasCXCEdoCtaXFact"
                Dim menuClickB As New EstadoCuentaFacturaReportForm
                menuClickB.Show()

            Case "menuVentaCXCEdoCtaXGeneral"
                Dim menuClickB As New EstadoCuentaGeneralReportForm
                menuClickB.Show()

            Case "menuVentasCXCReportesCxC"
                Dim piCXCRepCXC As frmCuentasxCobrar

                piCXCRepCXC = New frmCuentasxCobrar(0)
                piCXCRepCXC.Show()

                'REPORTES OPERACIONALES
            Case "menuOperacionalCodigos"
                Dim oForm As New frmOperacionalCodigos
                oForm.Show()
            Case "menuOperacionalMarcas"
                Dim oForm As New frmOperacionalMarcas
                oForm.Show()

                '/REPORTES OPERACIONALES

            Case "menuVentasCXCReportesCxCCanceladas"
                Dim piCXCRepCXCCan As frmCuentasxCobrar

                piCXCRepCXCCan = New frmCuentasxCobrar(1)
                piCXCRepCXCCan.Show()

            Case "menuVentasCXCReportesAbonosRealizados"
                Dim rptAbonosDT As New FrmRptAbonosCDT
                rptAbonosDT.Show()
                'Dim menuClickB As New ValesdeCajaReportForm
                'menuClickB.ShowMeforAbonosCxC(True)

            Case "menuVentasCXCReportesAbonosCancelado"
                Dim menuClickB As New ValesdeCajaReportForm
                menuClickB.ShowMeforAbonosCxC(False)

            Case "menuVentasCXCReportesHistorial"
                Dim menuClickB As New FrmHistorialCrediticio
                menuClickB.Show()

                '<Estados de Cuenta CXC />

            Case "menuVentasCXCReportes"
                Dim menuClickB As New frmRangos
                menuClickB.Show()

            Case "menuVentasAvisosenNotas"
                Dim menuClickB As New frmAvisosdeFacturas
                menuClickB.Show()
            Case "menuVentaModDatosFact"
                Dim menuClickB As New frmModDatosFact
                menuClickB.Show()
            Case "menuVentasInicioCaja"
                Dim menuClickB As New frmInicioCaja
                If menuClickB.ShowDialog = DialogResult.OK Then
                    CompruebaInicioDiaCaja(True)
                End If
            Case "menuVentasCierreCaja"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CerrarCaja") Then

                    Dim oClickLink As New frmCerrarCaja
                    oClickLink.ShowMe(oAppContext.Security.CurrentUser.SessionLoginName)
                    If oClickLink.DialogResult = DialogResult.OK Then
                        DesActivaMenu()
                    End If

                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuVentasRetiros"
                Dim menuClickB As New frmRetiro
                menuClickB.Show()

            Case "menuVentasACDT"
                Dim menuAbonoCDT As New frmAbonoCreditoDirectoTienda
                menuAbonoCDT.Show()

                '</Vale de Caja>
            Case "menuVentasValeCajaManejo"
                Dim menuClickB As New FrmValeCaja
                menuClickB.Show()

            Case "menuVentasValeCajaReporte"
                Dim menuClickB As New ValesdeCajaReportForm
                menuClickB.ShowMeforValeDeCaja()
                '<End/>

            Case "menuVentasDPValeF"
                If Now.Today.DayOfWeek = DayOfWeek.Sunday Then
                    MessageBox.Show("No se permite emitir préstamos en domingo.", "Microcrédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Now.Today.DayOfWeek = DayOfWeek.Saturday Then
                    If Format(Now, "HH") >= 13 Then
                        MessageBox.Show("No se permite emitir préstamos los sábados despues de la 1:00 P.M.", "Microcrédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim menuClickB As New DPValeFinanciero
                        menuClickB.Show()
                    End If
                Else
                    If Format(Now, "HH") > 18 OrElse (Format(Now, "HH") >= 18 AndAlso Format(Now, "mm") >= 30) Then
                        MessageBox.Show("No se permite emitir préstamos despues de las 6:30 P.M.", "DMicrocrédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim menuClickB As New DPValeFinanciero
                        menuClickB.Show()
                    End If
                End If

                '*********************************************************************************
                ' JNAVA (25.09.2014): REcepcion de Otros Pagos
                '*********************************************************************************
                '<OtrosPagos>
            Case "menuVentasRecibirOtrosPagos"

                nHwnI = FindWindow(vbNullString, "Otros Pagos")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmOtrosPagos
                    menuClickB.Show()
                End If

                '*********************************************************************************
                ' JNAVA (14.01.2015): Cancelacion de Otros Pagos
                '*********************************************************************************
            Case "menuVentasCancelarOtrosPagos"

                nHwnI = FindWindow(vbNullString, "Cancelar Otros Pagos")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmCancelarOtrosPagos
                    menuClickB.Show()
                End If
                '</OtrosPagos>
                '*********************************************************************************
                '***********************APARTADOS ************************
            Case "menuApartadosContratos"
                Dim menuClickB As New frmContratos
                menuClickB.Show()

            Case "menuApartadosAOA"
                Dim menuClickB As New frmAbonosContratos(, "AB")
                menuClickB.Show()

            Case "menuApartadosRepDApartadoCT"
                Dim menuClickB As New frmApartadosEnTotales
                menuClickB.Show()
            Case "menuApartadosRepDApartadoCD" 'Apartados Detalle
                Dim menuClickB As New frmApartadosVigentes
                menuClickB.Show()
            Case "menuApartadosRepDApartadoCC"
                Dim menuClickB As New frmContratosCancelados
                menuClickB.Show()
            Case "menuApartadosRepDApartadoAV"
                Dim menuClickB As New frmContratosVigentes
                menuClickB.Show()

            Case "menuApartadosRepDApartadoAAV"
                Dim menuClickB As New frmRangos
                menuClickB.Show()

            Case "menuApartadosRepDAbonoAA"
                Dim menuClickB As New frmReporteAbonos
                menuClickB.Show()
            Case "menuApartadosRepDAbonoAC"
                Dim menuClickB As New frmAbonosContratosCancelados
                menuClickB.Show()

            Case "menuApartadosCancelarContratosDef"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.CancelaContrato") = True Then
                    Dim menuClickB As New frmCancelarContratoDefinitivamente
                    menuClickB.Show()
                Else
                    MsgBox("¡No cuenta con permiso para cancelar contratos!", MsgBoxStyle.Information, Me.Text)
                End If
                oAppContext.Security.CloseImpersonatedSession()


            Case "menuApartadosCancelarContratoNDCredito"
                'Dim menuClickB As New frmPasswordGenerico
                'menuClickB.Show()

                Dim menuClick As New FrmContratosCancelar
                menuClick.Show()

            Case "menuApartadoCancelarAbono"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Apartados.CancelaAbonoApartado") Then

                    Dim menuClickB As New frmCancelacionAbono

                    menuClickB.Show()

                End If

            Case "menuVentasReasignarPlayer"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.ReasignarPlayer") Then

                    Dim menuClickB As New frmReasignarPlayerAFactura

                    menuClickB.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()


                ' **********************INVENTARIO************************
                ' Existencia de Codigo
            Case "menuInventarioExistdeCodigo"
                Dim menuClickB As New frmConsultaExistencias
                menuClickB.ModOrigen = "N" 'Normal
                menuClickB.Show()

                'Inventario Movimiento de Articulos
            Case "menuInventarioMovArticulosPA"
                'HACK: Fix this line
                'Dim menuClickB As New InventarioMovimientosArticuloReportForm
                Dim menuClickB As New frmMovimientosPorArticulo
                menuClickB.Show()
            Case "menuInventarioMovArticuloTA"
                'Dim menuClickB As New frmRangos
                Dim menuClickB As New TodosArticulosReportForm
                menuClickB.Show()
            Case "menuInventarioMovArticulosH2"
                'Dim menuClickB As New frmConExisAños
                Dim menuClickB As New HistoricoDosAñosReportForm
                menuClickB.Show()
            Case "menuInventarioMovArticulosHA"
                'Dim menuClickB As New frmConGenMovArt
                Dim menuClickB As New HistoricoApartadosReportForm
                menuClickB.Show()
                'Inventario Costo de Inventario
            Case "menuInventarioCostodeInvCod"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvCodDet"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvMarcas"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvLinea"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvFamilia"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvUsos"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvSucursal"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvArtCD"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
            Case "menuInventarioCostodeInvLF"
                Dim menuClickB As New frmCostInvLineaFam
                menuClickB.Show()
            Case "menuInventarioCostodeInvMLF"
                Dim menuClickB As New frmCostInvMarLinFam
                menuClickB.Show()
            Case "menuInventarioCostodeInvMF"
                Dim menuClickB As New frmCostInvMarMesProc
                menuClickB.Show()
            Case "menuInventarioCostodeInvFM"
                Dim menuClickB As New frmCostInvMarFechPro
                menuClickB.Show()
            Case "menuInventarioCostodeInvRA"
                MessageBox.Show("Proceso")

                '///////////*********////////////////
                'Inventario Traspasos      
                'Case "menuInventarioTraspasosSalida"
                '   Dim menuClickB As New frmInvTraspasosDSalida
                '  menuClickB.Show()

                'Traspaso Salida por Defectuosos
            Case "menuInvDefect"
                oAppContext.Security.CloseImpersonatedSession()
                If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida", "DportenisPro.DPTienda.Inventarios.TraspasosSalida.Tiendas") Then
                    Exit Sub
                Else
                    Dim menuClickB As New frmInvTSxDefectuosos
                    menuClickB.Show()
                End If
                oAppContext.Security.CloseImpersonatedSession()


                'Traspaso Salida por Devolucion a proveedor
            Case "menuInvDevProv"
                Dim menuClickB As New frmInvDevProv
                menuClickB.Show()

                'Traspaso Salida por auditoria
            Case "menuInvAud"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria") = True Then
                    Dim menuClickB As New frmInvAuditoria
                    menuClickB.Show()
                    oAppContext.Security.CloseImpersonatedSession()
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                    Exit Sub
                End If

                'Traspaso Salida por Faltantes
            Case "menuInvTraspasoAutorizar"
                Dim menuClickB As New frmAutorizaTraspasosPendientes(gBloqueo)
                If menuClickB.ShowDialog = DialogResult.OK Then
                    BloquearSistemaXTP(False)
                End If

                'Traspaso Salida por Concentracion de inventario
            Case "menuInvConcInv"
                Dim menuClickB As New frmInvConcInv
                menuClickB.Show()

                'Traspaso Salida por Concentracion de ventas
            Case "menuInvConcVtas"
                Dim menuClickB As New frmInvConcVtas
                menuClickB.Show()
                'Traspaso Salida Para Ecommerce
            Case "menuInvTraspasoEC"
                Dim menuClickB As New frmInvTraspasoEC
                menuClickB.Show()
                'Traspaso Salida Por Errores del CDist
            Case "menuInvTraspasoErroresCDIST"
                '-------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/02/2015: Se comento porque el traspaso de auditoria se unio para hacer lo mismo
                '-------------------------------------------------------------------------------------------------------
                'Dim menuClickB As New frmInvTraspasoErroresCDIST
                'menuClickB.Show()
                'Traspaso Salida Para Ventas Distribuidores
            Case "menuInvTraspasoVentaDist"
                Dim menuClickB As New frmInvTraspasoDistribuidores("CV")
                menuClickB.Show()
                'Traspaso Salida entre tiendas
            Case "menuInvTiendas"
                Dim menuClickB As New frmInvTraspasosDSalida
                'Dim menuClickB As New frmInvTraspasoDistribuidores("ET")
                menuClickB.Show()


                '//////////////************////////////////

            Case "menuInventarioTraspasoTSG"
                Dim menuclickB As New frmTraspasosPendientes
                menuclickB.Show()

            Case "menuInventarioTEntradaDBF"
                Dim menuClickB As New FrmInvTraspasoDEntradaDBF
                menuClickB.Show()


            Case "menuInventarioTraspasoModTSalida"
                Dim menuClickB As New frmInvTraspasosDSalida
                menuClickB.Show()
                'Traspaso Entrada a Detalle
            Case "menuInventarioTraspasoPT"
                Dim menuClickB As New FrmInvTraspasoDEntrada(oConfigCierreFI)
                menuClickB.Show()
                'Traspaso Entrada por Bultos
            Case "menuInventarioTraspasoEntradaBultos"
                Dim menuClickB As New FrmInvTraspasoDEntradaPorBultos
                menuClickB.Show()
            Case "menuInventarioReporteInvPC"
                'HACK: Fix this line
                Dim oRptInventario As New InventarioNormalReportForm
                oRptInventario.Show()
                'Reporte diferencias por traspaso
            Case "menuInventarioReporteDifTraslados"
                Dim oRptInventario As New frmReporteDiferenciasTraspasos
                oRptInventario.Show()
            Case "menuInventarioReporteVarios"
                Dim oRptInventario As New frmReporteInventarioVarios
                oRptInventario.Show()

                'Case "menuInventarioReporteInvLF"
                '    Dim oRptInventario As New frmInventarioLineaFamilia
                '    oRptInventario.Show()
                'Case "menuInventarioReporteInvLFD"
                'Case "menuInventarioReporteInvMF"
                'Case "menuInventarioReporteInvMLF"
                'Case "menuInventarioReporteInvOLF"

            Case "menuInventarioArtSinMovMLF"

                Dim ofrmArticulosSinMov As New frmArticulosSinMovimientos
                ofrmArticulosSinMov.Show()




            Case "menuListaArticuloDescuentoSAP"

                Dim frmx As New FrmDescNuevosPrintEtiquetas
                frmx.Show()
                frmx.CargaEtiquetas()


                '****************************************************
                'Reporte de Articulos con descuento
                '****************************************************

            Case "menuInventarioMasVendidos"

                Dim frmx As New FrmMasVendidos
                frmx.Show()

            Case "mnuListaArticulosDescuentoSAPGroup"
                '****************************************************
                'Reporte de Articulos con descuento Agrupados
                '****************************************************

                '**********************Reporte de Descuentos Agrupados **********************

                Dim frm As New FrmPrompDescuentos
                frm.Show()

                '**********************Reporte de Descuentos **********************


            Case "menuInventarioReporteInvEN"
                'HACK: Fix this line
                Dim oRptInventario As New InventarioNegativoReportForm
                oRptInventario.Show()
            Case "menuInventarioReporteInvAA"
                'HACK: Fix this line
                Dim oRptInventario As New InventarioApartadoReportForm
                oRptInventario.Show()
            Case "menuInventarioReporteInvUP"
                'HACK: Fix this line
                Dim oRptInventario As New InventarioUnicosParesReportForm
                oRptInventario.Show()
            Case "menuInventarioArtSinMovPC"
                'HACK: Fix this line
                Dim menuClickB As New InventarioArticuloSinMovimientosReportForm
                menuClickB.Show()

                'Surtido de Traspasos Solicitados por Ecommerce
            Case "menuInventarioSurtirTraspasosSolicitados"

                Dim menuClickB As New frmTraspasoAutoEcommerce
                menuClickB.Modulo = "PP"
                menuClickB.Show()

                'Facturar Pedidos Solicitados por Ecommerce
            Case "menuInventarioFacturarPedidosEC"

                Dim menuClickB As New frmTraspasoAutoEcommerce
                menuClickB.Modulo = "PF"
                menuClickB.Show()

                '------------------------------------------------------------------------
                ' JNAVA (15.03.2016): Reporte de Pedidos de Ecommerce
                '------------------------------------------------------------------------
            Case "menuInventarioReportePedidosEC"

                Dim menuClickB As New frmReportePedidosEC
                menuClickB.Show()
                '------------------------------------------------------------------------

                'Asignar Guias a los Pedidos de Ecommerce
            Case "menuInventarioAsignarGuiaEC"

                Dim menuClickB As New frmPedidosSinGuia
                menuClickB.Show()

                'Cancelar Pedidos de Ecommerce
            Case "menuInventarioPedCancEC"
                Dim oFrm As New frmPedidosCancelados
                With oFrm
                    .Proceso = "CancelacionEccommerce"
                    .Text = "Pedidos Cancelados Ecommerce"
                    .ShowDialog()
                End With
            Case "mnuReingresarPedidosCancelados"
                nHwnI = FindWindow(vbNullString, "ReIngresar al Inventario de Pedidos Cancelados")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim oFrm As New frmPedidosCancelados
                    With oFrm
                        .Proceso = "CancelacionPedidos"
                        .Text = "ReIngresar al Inventario de Pedidos Cancelados"
                        .ShowDialog()
                    End With
                End If
            Case "menuInventarioTF" 'Traspaso Virtual
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
                    Dim menuClickB As New frmTraspasoInvFisico
                    menuClickB.Show()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuTraspasoEntradaVirtual"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosEntrada") Then
                    oAppContext.Security.CloseImpersonatedSession()
                    Dim form As New frmTraspasoEntradaVirtual
                    form.Show()
                End If
                oAppContext.Security.CloseImpersonatedSession()
                'Reporte Operacion
            Case "menuInventarioRepOperacional"
                Dim menuClickB As New frmProcesar
                menuClickB.Show()
                'Marcar Articulos Defectuosos
            Case "menuInventarioDefectuosoMAD"

                Dim menuClickB As New frmDefectuosos
                menuClickB.Show()
                'Desmarcar Articulos Defectuosos
            Case "menuInventarioDefectuososDAD"

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.DesmarcarDefectuoso") Then
                    Dim menuClickB As New frmDesmarcarDefectuosos
                    With oAppContext.Security.CurrentUser
                        menuClickB.ShowMe(.SessionLoginName, .Name)
                    End With
                End If
                oAppContext.Security.CloseImpersonatedSession()

                'Marcar/Desmarcar Articulos Defectuosos para Ecommerce
            Case "menuInventarioDefectuosoMADEcm"

                Dim menuClickB As New frmDefectuososEcommerce
                menuClickB.Show()

            Case "menuInventarioDesfectuososRDD"

                Dim menuClickB As New DefectuososReportForm
                menuClickB.Show()

            Case "menuInventarioReporteDefecEC"

                Dim menuClickB As New frmReporteDefectusosEC
                menuClickB.Show()

            Case "frmRepDefecDet"

                Dim menuClickB As New frmRepDefecDet
                menuClickB.Show()

            Case "menuInventariolModAjusteGeneral"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.AjusteGeneral") Then

                    Dim oFrmAjusteGeneral As New frmAjustesTalla
                    oFrmAjusteGeneral.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuInventarioEFExportInfo"

                'oAppContext.Security.CloseImpersonatedSession()

                'If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.ExportarInformacionAuditoria") Then

                '    Dim oExportInfo As New FrmExportarInformacion
                '    oExportInfo.Show()

                'End If

                'oAppContext.Security.CloseImpersonatedSession()


                '*********************CATALOGOS************************

            Case "menuGeneralesArticulos"
                Dim menuClickB As New CatalogoArticulosForm
                menuClickB.Show()
            Case "menuGeneralesBanco"
                Dim menuClickB As New CatalogoBancosForm
                menuClickB.Show()
            Case "menuGeneralesFamilias"
                Dim menuClickB As New CatalogoFamiliasForm
                menuClickB.Show()
            Case "menuGeneralesFDePago"
                Dim menuClickB As New frmformadepago
                menuClickB.Show()
            Case "menuGeneralesLineas"
                Dim menuClickB As New CatalogoLineasForm
                menuClickB.Show()
            Case "menuGeneralesMarcas"
                Dim menuClickB As New CatalogoMarcasForm
                menuClickB.Show()
            Case "menuGeneralesUsos"
                Dim menuClickB As New CatalogoUsosForm
                menuClickB.Show()
            Case "menuGeneralesDescuentos"
                Dim menuClickB As New frmTipoDescuento
                menuClickB.Show()
            Case "menuGeneralesAlmacen"
                Dim menuClickB As New CatalogoAlmacenesForm
                menuClickB.Show()
            Case "menuGeneralesCaja"
                Dim menuClickB As New CatalogoCajaForm
                menuClickB.Show()
            Case "menuGeneralesCat"
                Dim menuClickB As New CatalogoCategoriasForm
                menuClickB.Show()
            Case "menuGeneralesCiudades"
                Dim menuClickB As New CatalogoCiudadesForm
                menuClickB.Show()
            Case "menuGeneralesCodigoUPC"
                Dim menuClickB As New CodigoUPCForm
                menuClickB.Show()
            Case "menuGeneralesColonias"
                Dim menuClickB As New frmColonias
                menuClickB.Show()
            Case "menuGeneralesCorridas"
                Dim menuClickB As New frmCorridas
                menuClickB.Show()
            Case "menuGeneralesEstados"
                Dim menuClickB As New frmEstado
                menuClickB.Show()
            Case "menuGeneralesOrigenes"
                Dim menuClickB As New frmOrigen
                menuClickB.Show()
            Case "menuGeneralesPlayer"
                Dim menuClickB As New CatalogoPlayer
                menuClickB.Show()
            Case "menuGeneralesPlaza"
                Dim menuClickB As New CatalogoPlazasForm
                menuClickB.Show()
            Case "menuGeneralesPublicaciones"
                Dim menuClickB As New frmPublicaciones
                menuClickB.Show()
            Case "menuGeneralesStatus"
                Dim menuClickB As New frmStatus
                menuClickB.Show()
            Case "menuGeneralesTipoCliente"
                Dim menuClickB As New frmTipoCliente
                menuClickB.Show()
            Case "menuGeneralesTipoDescuento"
                Dim menuClickB As New frmTipoDescuento
                menuClickB.Show()
            Case "menuGeneralesTipoMov"
                Dim menuClickB As New frmTipoMovimiento
                menuClickB.Show()
            Case "menuGeneralesTipoTarjeta"
                Dim menuClickB As New frmTipoTarjeta
                menuClickB.Show()
            Case "menuGeneralesTipoVenta"
                Dim menuClickB As New frmTipoVenta
                menuClickB.Show()
            Case "menuGeneralesUnidades"
                Dim menuClickB As New CatalogoUnidadForm
                menuClickB.Show()
            Case "menuGeneralesVales"
                Dim menuClickB As New frmVales
                menuClickB.Show()
            Case "menuGeneralesVentas"
                Dim menuClickB As New frmTipoVenta
                menuClickB.Show()

                '*********************CLIENTES******************
            Case "menuClientesClientes"
                'Dim menuClickB As New frmClientes
                Dim menuClickB As New frmClientesSAP
                menuClickB.Show()
                'Case "menuClientesClienteAsociado"
                'Dim menuClickB As New CatalogoClienteAsociadoForm
                'menuClickB.Show()
            Case "menuClientesClientesDPVL"
                Dim frmClientes As New frmClientesSAP
                frmClientes.TipoVenta = "C" 'oDPValeSAP.TipoVenta
                frmClientes.EsDPVale = True
                frmClientes.Show()

                '*******************CREDITO**********************
            Case "menuClientesAsociados"
                Dim menuClickB As New CatalogoAsociadosForm
                menuClickB.Show()
            Case "menuClientesClienteDPVale"
                Dim menuClickB As New CreditoDPVale
                menuClickB.Show()
            Case "menuClientesClienteDEnTienda"
                Dim menuClickB As New CreditoDirectoEnTienda
                menuClickB.Show()


                '*******************UTILERIAS************************
            Case "menuUtileriasRutaArvhivos"
                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DpTienda.Administrator") = True Then
                    Dim menuclickB As New FrmConfigCierreSAP
                    menuclickB.ShowDialog()
                    oAppContext.Security.CloseImpersonatedSession()
                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtileriasDatosDSucursal"
                Dim menuClickB As New frmUtilDatosDSucursal
                menuClickB.Show()

            Case "mnuHerramientasOpciones"

                Dim codCaja As String
                Dim oStreamR As StreamReader
                Dim strOriginal As String = ""
                Dim strModificado As String = ""

                codCaja = oAppContext.ApplicationConfiguration.NoCaja

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones") = True Then

                    oStreamR = New StreamReader(strDPTiendaPath)
                    strOriginal = oStreamR.ReadToEnd
                    oStreamR.Close()
                    oStreamR = Nothing

                    oAppContext.ShowSettingsEditor()

                    oStreamR = New StreamReader(strDPTiendaPath)
                    strModificado = oStreamR.ReadToEnd
                    oStreamR.Close()
                    oStreamR = Nothing

                    If strOriginal <> strModificado Then
                        SaveConfigGeneralInServer(True)
                        EncriptarCML(strDPTiendaPath)
                    End If

                End If

                oAppContext.Security.CloseImpersonatedSession()

                ''Si se cambia el numero de Caja forzamos a que se inicie
                If Not codCaja.Equals(oAppContext.ApplicationConfiguration.NoCaja) Then

                    CompruebaInicioDiaCaja(True)

                End If
                'oPanelControl.Controls.Item(1).Controls.Item(0).Text = oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server.ToUpper
                'oPanelControl.Controls.Item(1).Controls.Item(2).Text = oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database.ToUpper
                'oPanelControl.Controls.Item(1).Controls.Item(4).Text = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/"

            Case "menuContabilizacionSegmentoContable"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Contabilizacion", "DportenisPro.DPTienda.Utilerias.Contabilizacion.SegmentoContable") = True Then

                    Dim menuClickB As New FrmSegmentoContable
                    menuClickB.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuContabilizacionDefinicionAsiento"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Contabilizacion", "DportenisPro.DPTienda.Utilerias.Contabilizacion.DefinicionAsiento") = True Then

                    Dim menuClickB As New FrmAsientoContableDefinicion
                    menuClickB.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuContabilizacionAsignacionAsiento"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Contabilizacion", "DportenisPro.DPTienda.Utilerias.Contabilizacion.AsignacionAsiento") = True Then

                    Dim menuClickB As New FrmAsignacionAsientosContables
                    menuClickB.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

                'Otros
            Case "menuUtileriasImpDEtiquetas"
                Dim menuClickB As New FrmImpresionEtiquetas
                menuClickB.Show()

            Case "menuNotasCreditoReportesConcentrado"

                Dim ofrmNotasdeCreditoReporte As New NotasdeCreditoReportForm
                ofrmNotasdeCreditoReporte.Show()

            Case "menuApartadosEdoCtaXContrato"

                Dim ofrmEdoCuentaContrato As New EstadoCuentaContratoReportForm
                ofrmEdoCuentaContrato.Show()

            Case "menuInventarioReporteInvRG"
                Dim ofrmRepInvGlobales As New ReportesGlobalesInventarioReportForm
                ofrmRepInvGlobales.Show()


            Case "menuUtileriasUserRoles"

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DpTienda.Administrator") = True Then
                    oAppContext.Security.ShowSecurityManager()
                    oAppContext.Security.CloseImpersonatedSession()
                End If

            Case "menuUtilesLstPrecios"

                Dim frmListaPRecios As New ListadePreciosReportForm
                frmListaPRecios.Show()

            Case "menuUtilGananciasAdicionales"


                'Dim oExportInfo As New frmGananciaAdicional
                'oExportInfo.Show()

                Dim SaveDialog = New SaveFileDialog
                Dim oGenArchGanAdic As GenerarArchivo

                SaveDialog.DefaultExt = "*.zip"

                SaveDialog.Filter = "(*.zip)|*.zip"

                If SaveDialog.ShowDialog = DialogResult.OK Then

                    Try

                        Me.Cursor = Cursors.WaitCursor

                        Dim oExporterGAD As New GananciaAdicional(oAppContext)
                        Dim strRuta As String = SaveDialog.FileName

                        oExporterGAD.GeneraGananciaAdicional(strRuta)

                        Me.Cursor = Cursors.Default

                        MsgBox("Archivo generado en " & strRuta, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Ganancias Adicionales")

                    Catch ex As Exception

                        Throw New ApplicationException("Se produjo un error. ", ex)

                    End Try

                End If

            Case "menuUtilGenArchCierreDia"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.GenerarArchivosCierre") = True Then

                    oAppContext.Security.CloseImpersonatedSession()
                    Dim menuClickB As New FrmGenArchCierreDia
                    menuClickB.Show()

                End If


            Case "MnuUtilCargaArchivosSAP"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.CargarDiasSAP") = True Then

                    oAppContext.Security.CloseImpersonatedSession()
                    Dim menuClickB As New FrmCargaDiasSAP
                    menuClickB.Show()

                End If


            Case "mnuUtileriasConfiguraSAP"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DpTienda.Administrator") = True Then

                    Dim oConfigSAP As New SAPSystem
                    oConfigSAP.ShowDialog()
                    oAppContext.Security.CloseImpersonatedSession()
                    oConfigSAP.Dispose()
                    oConfigSAP = Nothing

                End If

                'Para Poner el Mandante
                'oPanelControl.Controls.Item(1).Controls.Item(6).Text = oAppSAPConfig.Client & " " & oAppSAPConfig.GroupName.ToUpper

                oAppContext.Security.CloseImpersonatedSession()



            Case "mnuUtileriasCargaInicial"

                '***********************************************************************************
                '''Facturas, Apartados, Abonos, Apartados SAP
                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones.CargaInicial") = True Then

                    '-----------------------------------------------------------------------------
                    ' JNAVA (01.03.2016): Se comento por que ya no se usara en Retail
                    '-----------------------------------------------------------------------------
                    'oCierreDiasMgr = New CierreDiaManager(oAppContext, oAppSAPConfig)

                    'If oCierreDiasMgr.FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
                    '    MsgBox("No se puede hacer Cargas Inciales." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", MsgBoxStyle.Information, "DPTienda")
                    '    Exit Sub
                    'End If

                    'If oCierreDiasMgr.FacturaCANSelDontSaved.Tables(0).Rows.Count > 0 Then
                    '    MessageBox.Show("No se puede hacer Cargas Inciales." & vbCrLf & " Algunas Facturas no se Cancelaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Exit Sub
                    'End If

                    'If oCierreDiasMgr.ReadSQLApartadosSinRegSAP.Rows.Count > 0 Then
                    '    MsgBox("No se puede hacer Cargas Inciales." & vbCrLf & " Algunos Apartados no se Almacenaron en SAP.", MsgBoxStyle.Information, "DPTienda")
                    '    Exit Sub
                    'End If

                    'If oCierreDiasMgr.ReadSQLApartadosCanceladosSinRegSAP.Rows.Count > 0 Then
                    '    MsgBox("No se puede hacer Cargas Inciales." & vbCrLf & " Algunos Apartados no se Cancelaron en SAP.", MsgBoxStyle.Information, "DPTienda")
                    '    Exit Sub
                    'End If

                    'If oCierreDiasMgr.ReadSQLNotasCreditoSinRegSAP.Rows.Count > 0 Then
                    '    MsgBox("No se puede hacer Cargas Inciales." & vbCrLf & " Algunas Notas de Credito no se Grabaron en SAP.", MsgBoxStyle.Information, "DPTienda")
                    '    Exit Sub
                    'End If
                    '***********************************************************************************

                    Dim ofrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)

                    ofrmProcesoSAP.ShowDialog()

                    ofrmProcesoSAP.Dispose()

                    ofrmProcesoSAP = Nothing

                End If

                oAppContext.Security.CloseImpersonatedSession()
                '-------------------------------------------------------------------------------------------
                ' FLIZARRAGA 14/09/2016: Se descomento para crear los pedidos que no se guardaron en SAP
                '-------------------------------------------------------------------------------------------
            Case "menuUtileriasLoadFacturas"
                Dim oCierreDiaManager As New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                Dim ofrmLoadFacturas As New frmGuardarFacturasPendientes
                ofrmLoadFacturas.oParent = oCierreDiaManager
                ofrmLoadFacturas.ShowDialog()

            Case "menuUtileriasGenArchDPVF"

                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones") = True Then

                    Dim oClickB As New frmGenerarArchivosDPVF
                    oClickB.Show()

                End If

                oAppContext.Security.CloseImpersonatedSession()

            Case "menuUtileriasReimprimirTickets"

                Dim oClickB As New frmReimpresionTickets
                oClickB.Show()

            Case "menuUtileriasReimprimirCupon"

                Dim oFrm As New frmReimpresionCupon
                oFrm.ShowDialog()

            Case "menuUtileriasReimprimirVC"

                Dim oFrm As New frmReimprimirValeDeCaja
                oFrm.ShowDialog()

            Case "menuUtileriasReimprimirDPVFinanciero"
                Dim oFrm As New frmImpresionPagareDPVFinanciero
                oFrm.Show()

                '*********************************************************************************
                ' JNAVA (21.01.2015): Consultor de Saldo DP Card
                '*********************************************************************************
                '<OtrosPagos - DPCard>
            Case "menuUtileriasSaldoDPCard"

                nHwnI = FindWindow(vbNullString, "Saldo DPCard")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmSaldoDPCard
                    menuClickB.Show()
                End If
                '<OtrosPagos - DPCard>


                'Pantallas de motivos de captura manual
            Case "CatMotCapMan"
                Dim oFrmCatMot As New frmCatalogoMotivosFac
                oFrmCatMot.Show()
            Case "RepMotCapMan"
                Dim oFrmRepMot As New frmReporteCatalogoMotivosFac
                oFrmRepMot.Show()

            Case "menuSalir"

                Me.Close()

                '---------------------------------------------------------
                'Sistema Gerencial

            Case "menuConfigurarGerencial"
                '----------------SISTEMA GERENCIAL
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones.SistemaGerencial") = True Then

                    Dim negGer As NegGerencial
                    negGer = New EmpGerInt.NegGerencial(oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.User, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Password)
                    negGer.Configurar()

                End If
                oAppContext.Security.CloseImpersonatedSession()
                '----------------SISTEMA GERENCIAL

            Case "menuTemporadas"
                '----------------SISTEMA GERENCIAL
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones.SistemaGerencial") = True Then

                    Dim negGer As NegGerencial
                    negGer = New EmpGerInt.NegGerencial(oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.User, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Password)

                    negGer.CatalogoTemporadas(Date.Now.Date)
                End If
                oAppContext.Security.CloseImpersonatedSession()
                '----------------SISTEMA GERENCIAL

            Case "menuAnticiparMetas"

                '----------------SISTEMA GERENCIAL
                oAppContext.Security.CloseImpersonatedSession()

                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Opciones.SistemaGerencial") = True Then
                    Dim negGer As NegGerencial
                    negGer = New EmpGerInt.NegGerencial(oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.User, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Password)

                    negGer.AnticiparMetas(Date.Now.Date)
                End If

                oAppContext.Security.CloseImpersonatedSession()
                '----------------SISTEMA GERENCIAL

            Case "menuUtileriasNumeroReferencia"

                Dim Frm As New FrmNumReferenciaX
                Frm.Show()


            Case "menuActualizacionesOpcion"
                Dim menuClickB As New frmActualizaciones
                menuClickB.Show()

            Case "menuActualizacionesXCodigos"
                Dim menuClickB As New frmDescargasXCodigo
                menuClickB.Show()

            Case "mnuActuDescargaImagenes"
                Dim menuClickB As New FrmDescargarImagenes
                menuClickB.Show()

            Case "menuVentasPorCliente"
                Dim oExportInfo As New frmVentasPorCliente
                oExportInfo.Show()

            Case "menuAyudaAcerca"
                'Dim menuclickB As New frmClientes
                'menuclickb.Show()

            Case "menuImageGearRegistration"
                'Lic.
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DpTienda.Administrator") = True Then
                    Dim oAccuLicClientLib As New AccuLicClientLib.DeploymentComponentClass
                    'oAccuLicClientLib.GetLicKeyAuto("6KKL-7R3L-N86F-RK26-AK8A")
                    oAccuLicClientLib.ConfigPath = Application.StartupPath & "/config.txt"
                    oAccuLicClientLib.GetLicKeyAuto("")


                    MessageBox.Show(oAccuLicClientLib.ResultCode.ToString)
                    MessageBox.Show(oAccuLicClientLib.ResultString)
                End If

            Case "menuSurtirPedidosSH"
                nHwnI = FindWindow(vbNullString, "Petición de Surtido Para ""Si Hay""")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmTraspasoAutoEcommerce
                    menuClickB.Modulo = "PPSH"
                    menuClickB.Show()
                End If


            Case "menuPedidosInsurtiblesSH"
                nHwnI = FindWindow(vbNullString, "Pedidos Insurtibles")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.PedidosInsurtibles") = True Then
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        'JNAVA 29/04/2013: Verificamos que el usuario tenga permisos para realizar la Devolucion de Efectivo. Si cuenta con el permiso
                        '                  aparecera el Check Devolucion de Efectivo, si no, no se mostrata dicha opcion.
                        '-------------------------------------------------------------------------------------------------------------------------------------
                        Dim menuclickb As New frmPedidosInsurtiblesSH
                        If oAppContext.Security.IsCurrentUserFeatureOperationAuthorized("DportenisPro.DPTienda.SiHay.PedidosInsurtibles", _
                            "DportenisPro.DPTienda.SiHay.PedidosInsurtibles.DevolucionEfectivo", False) = False Then
                            menuclickb.bVerDevEfec = False
                        Else
                            menuclickb.bVerDevEfec = True
                        End If
                        menuclickb.Show()
                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                End If

            Case "menuRecibirPedidoSH"
                nHwnI = FindWindow(vbNullString, "Recibir Traslados Para Pedidos ""Si Hay""")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmTraspasoAutoEcommerce
                    menuClickB.Modulo = "PRSH"
                    menuClickB.Show()
                End If


            Case "menuEnviarPedidoSH"
                'nHwnI = FindWindow(vbNullString, "Pedidos Sin Guía")
                'If Val(nHwnI.ToString) <> 0 Then
                '    ShowWindow(nHwnI, 9)
                '    SetForegroundWindow(nHwnI)
                'Else
                '    Dim menuClickB As New frmPedidosSinGuia("PESH")
                '    menuclickb.Show()
                'End If

            Case "MnuCancelacionPedido"
                nHwnI = FindWindow(vbNullString, "Cancelación de Pedidos")
                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.CancelacionPedidos") = True Then
                        Dim frmCancPedido As New frmPedidoCancelado
                        If oAppContext.Security.IsCurrentUserFeatureOperationAuthorized("DportenisPro.DPTienda.SiHay.CancelacionPedidos", "DportenisPro.DPTienda.SiHay.CancelacionPedidos.DevolucionEfectivo", False) = True Then
                            frmCancPedido.PermisoDevolucion = True
                        Else
                            frmCancPedido.PermisoDevolucion = False
                        End If
                        frmCancPedido.ShowDialog()
                    End If
                    oAppContext.Security.CloseImpersonatedSession()
                End If
            Case "menuFacturarPedidosSH"
                nHwnI = FindWindow(vbNullString, "Facturar Pedidos Si Hay")

                If Val(nHwnI.ToString) <> 0 Then
                    ShowWindow(nHwnI, 9)
                    SetForegroundWindow(nHwnI)
                Else
                    Dim menuClickB As New frmTraspasoAutoEcommerce
                    menuClickB.Modulo = "PFSH"
                    menuClickB.Show()
                End If

            Case "menuConsultaExistenciaSH"
                Dim menuClickB As New frmConsultaExistencias
                menuClickB.ModOrigen = "SH" 'Si hay
                menuClickB.Show()
                '-------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/04/2014: Menu de Metas Diarias de Tienda
                '-------------------------------------------------------------------------------------------------------------------
            Case "MnuMetasTienda"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.MetasTienda") Then
                    Dim frmMetasTienda As New frmMetaDiaTienda
                    frmMetasTienda.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuMetasDiarias"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.MetasTienda") Then
                    Dim frmMetas As New frmMetasPlayer
                    frmMetas.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
                '------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 17/04/2015: Menus de DPCard Puntos
                '------------------------------------------------------------------------------------------------------------------
            Case "MnuConsultaDPCardPunto"
                Dim frmConsulta As New frmDpCardPuntosSaldo
                frmConsulta.ShowDialog()
            Case "MnuTraspasoDPCardPunto"
                '------------------------------------------------------------------------------------------------------------------
                'JNAVA (15.09.2015): Validamos que el usuario tenga permisos para realizar traspasos de puntos
                '------------------------------------------------------------------------------------------------------------------
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.DPCardPuntos", "DportenisPro.DPTienda.DPCardPuntos.Traspaso") Then
                    nHwnI = FindWindow(vbNullString, "Traspaso de Puntos")
                    If Val(nHwnI.ToString) <> 0 Then
                        ShowWindow(nHwnI, 9)
                        SetForegroundWindow(nHwnI)
                    Else
                        Dim frmTraspaso As New frmDPCardPuntosTraspaso
                        frmTraspaso.ShowDialog()
                    End If
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "MnuTraspasoEntradaMercancia"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia") Then
                    nHwnI = FindWindow(vbNullString, "Recepción de Mercancía en Tiendas de Proveedores")
                    If Val(nHwnI.ToString) <> 0 Then
                        ShowWindow(nHwnI, 9)
                        SetForegroundWindow(nHwnI)
                    Else
                        Dim frmTraspaso As New frmRecepcionMercanciaTiendas
                        frmTraspaso.ShowDialog()
                    End If
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "menuCargaNotasCredito" 'AF (14-11-2016): Notas de credito masivas
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPRO.DPTienda.Utilerias.CargaNotasCredito") Then
                    Dim frmCargaNotasCredito As New frmCargaNotasCredito
                    frmCargaNotasCredito.ShowDialog()
                End If
            Case "MnuPinPadBanamex"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.ConfiguracionBanamex") Then
                    Dim configPay As New uPaydll.upaydll()
                    configPay.configuracion(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex)
                End If
                oAppContext.Security.CloseImpersonatedSession()

            Case "MnuPinPadBanamexOffline"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.ConfiguracionBanamex") Then
                    Dim configPay As New uPaydll.upaydll()
                    configPay.configuracionOffline(oConfigCierreFI.UserBanamex, oConfigCierreFI.PasswordBanamex)
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuCambioTalla"
                Dim frmTalla As New frmAjusteCambioTalla()
                frmTalla.ShowDialog()
            Case "MnuDevolucionTarjeta"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.DevolucionTarjeta") Then
                    Dim frmDevolucion As New frmDevolucionTarjetaBanamex()
                    frmDevolucion.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuNuevaDisposicion"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utileria.Dispersion") Then
                    MessageBox.Show("Antes de iniciar la operación consulta tu tabla de horarios para notificarle al cliente el día y hora en que recibirá su transferencia según el servicio seleccionado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim frmCredito As New frmMicrocredito()
                    frmCredito.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuMonitoreoReproceso"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utileria.MonitoreoReproceso") Then
                    MessageBox.Show("Antes de iniciar la operación consulta tu tabla de horarios para notificarle al cliente el día y hora en que recibirá su transferencia según el servicio seleccionado", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim frmReproceso As New frmReprocesoPrestamos()
                    frmReproceso.ShowDialog()
                Else
                    MessageBox.Show("Opción solo para usuarios con perfil de Gerente", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuDisposicionCancelar"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utileria.Dispersion") Then
                    Dim frmCancelar As New frmCancelaPrestamoDisposicion()
                    frmCancelar.ShowDialog()
                End If
            Case "MnuRecepcionPedido"
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPRO.DPTienda.Inventarios.OrdenesCompra") Then
                    Dim frmConsignacion As New frmConsignacion(TrasladoConsignacion.ORDENCOMPRA, oAppContext.Security.CurrentUser.SessionLoginName, Me)
                    frmConsignacion.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MnuDevolucionProveedor"
                oAppContext.Security.CloseImpersonatedSession()
                If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida", "DportenisPro.DPTienda.Inventarios.TraspasosSalida.DevolucionProveedor") Then
                    Exit Sub
                Else
                    Dim frmConsignacion As New frmConsignacion(TrasladoConsignacion.DEVOLUCION, oAppContext.Security.CurrentUser.SessionLoginName, Me)
                    frmConsignacion.ShowDialog()
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Case "MenuDescargaManual" 'Descarga manual de archivos R-M-G 24-09-19
                Dim result As Integer = MessageBox.Show("Está a punto de realizar la decarga de archivos, ¿Está segur@?", "Confirmación de Descarga", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    Exit Select

                ElseIf result = DialogResult.No Then
                    Exit Select

                ElseIf result = DialogResult.Yes Then
                   
                        Dim puedeDescargar As Boolean = False
                        'Dim articles As DataSet
                        'articles = oCatArt.GetAll()
                        Dim con As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
                        'For Each artic As CatalogoArticuloManager In articles
                        'Console.WriteLine(artic.ToString())
                        'Next
                        Dim cmd As New SqlCommand
                        Dim querystring As String = "SELECT COUNT(*) from CatalogoArticulos WHERE PrecioVenta=0.0"
                        Using conn As New SqlConnection(con)
                            conn.Open()
                            Using comm As New SqlCommand(querystring, conn)
                                Try
                                    Dim count As Int32 = Convert.ToInt32(comm.ExecuteScalar())
                                    If count = 0 Then
                                        puedeDescargar = False

                                    Else
                                        puedeDescargar = True
                                    End If
                                Catch ex As SqlException
                                    MsgBox(ex.ToString())
                                End Try
                            End Using
                            conn.Close()
                        End Using
                        If (puedeDescargar) Then
                            Dim ofrmLoad As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
                            oAppSAPConfig.DercargaManual = True
                            Try
                                ofrmLoad.ShowDev("Articulos")
                                'ofrmLoad.ShowDev("Clientes")
                                'ofrmLoad.ShowDev("Cobranza")
                                ofrmLoad.ShowDev("CodigosUPC")
                                ofrmLoad.ShowDev("Descuentos")
                                ofrmLoad.ShowDev("Inventarios")
                                'ofrmLoad.ShowDev("Vendedores")
                                'ofrmLoad.ShowDev("Promociones")
                                ofrmLoad.ShowDev("Almacenes")
                                'ofrmLoad.ShowDev("DescuentosAdicionales")
                                'ofrmLoad.ShowDev("Marcas")
                                ofrmLoad.ShowDev("RazonesRechazo")
                                'ofrmLoad.ShowDev("CodigosPostales")
                                'oAppSAPConfig.DercargaManual = False
                            Catch exc As Exception
                                MsgBox(exc)
                                oAppSAPConfig.DercargaManual = False
                            End Try
                        Else
                            MsgBox("No es posible realizar la descarga de archivos")
                        End If
                    End If

                    

            Case "menuRepWeb1"
                    Dim ResponseEcomm As Dictionary(Of String, Object) = Nothing
                    Dim config As ConfigEcomm = GetConfigEcomm() 'pagoMgr.GetConfigEcommerce()
                    Dim pagoApiEcomm As frmPagoEcommMenu = New frmPagoEcommMenu(ResponseEcomm, config, "", "", "") '50173077
                    pagoApiEcomm.ShowDialog()
                    Dim resp As Dictionary(Of String, Object) = pagoApiEcomm.Response

        End Select

    End Sub

    'Private Sub SaveConfigInServer()

    '    Try
    '        Dim Properties As PropertyInfo() = oAppContext.ApplicationConfiguration.GetType.GetProperties
    '        Dim strError As String
    '        Dim Valor As String = ""
    '        Dim bolPass As Boolean
    '        Dim oFacturasMgr As New FacturaManager(oAppContext, oConfigCierreFI)
    '        Dim strPrefijo As String = ""

    '        For Each oProp As PropertyInfo In Properties
    '            strError = ""
    '            bolPass = False
    '            Valor = ""
    '            If oProp.PropertyType.Name.Trim = "SQLConnectionHelper" Then
    '                strPrefijo = oProp.Name & "."
    '                SaveConfigInServerSQLConnectionHelper(strPrefijo, oProp.GetValue(oAppContext.ApplicationConfiguration, Nothing), oFacturasMgr)
    '            Else
    '                Valor = oProp.GetValue(oAppContext.ApplicationConfiguration, Nothing)
    '                If oProp.Name.ToUpper.Trim = "PASSWORD" Then
    '                    Valor = oSecurity.EncriptarCML(Valor)
    '                    bolPass = True
    '                End If
    '                If oProp.Name.ToUpper.Trim <> "ALMACEN" AndAlso oProp.Name.ToUpper.Trim <> "NOCAJA" Then
    '                    strError = oFacturasMgr.SaveConfigInServer(oProp.Name, Valor, 1, bolPass)
    '                    If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: oAppContext." & oProp.Name)
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "Error al guardar config general in server: oAppContext")
    '    End Try

    'End Sub

    'Private Sub SaveConfigInServerSQLConnectionHelper(ByVal strPrefijo As String, ByVal objTemp As Object, ByVal oFacturasMgr As FacturaManager)

    '    Try
    '        Dim Properties As PropertyInfo() = objTemp.GetType.GetProperties
    '        Dim strError As String
    '        Dim Valor As String = ""
    '        Dim bolPass As Boolean

    '        For Each oProp As PropertyInfo In Properties
    '            strError = ""
    '            bolPass = False
    '            Valor = oProp.GetValue(objTemp, Nothing)
    '            If oProp.Name.ToUpper.Trim = "PASSWORD" Then
    '                Valor = oSecurity.EncriptarCML(Valor)
    '                bolPass = True
    '            End If
    '            strError = oFacturasMgr.SaveConfigInServer(strPrefijo & oProp.Name, Valor, 1, bolPass)
    '            If strError.Trim <> "" Then EscribeLog(strError, "Error al grabar config en server: " & strPrefijo & oProp.Name)
    '        Next

    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "Error al guardar SQLConnectionHelper in server: " & strPrefijo)
    '    End Try

    'End Sub

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

    <System.Runtime.InteropServices.DllImport("winspool.drv")> _
    Public Shared Function OpenPrinter(ByVal pPrinterName As String, ByVal phPrinter As Long, ByVal pDefault As Object) As Long
    End Function

    <System.Runtime.InteropServices.DllImport("winspool.drv")> _
    Public Shared Function ClosePrinter(ByVal hPrinter As Long) As Long
    End Function

#End Region


    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                ManagerPanelControl("TOP10")
            Case Keys.F3
                ManagerPanelControl("LAST10")
        End Select
        If e.Alt AndAlso e.KeyCode = Keys.D Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Utilerias.Desbloqueo") = True Then
                Me.BloquearSistemaXTP(False)
            Else
                oAppContext.Security.CloseImpersonatedSession()
            End If
            oAppContext.Security.CloseImpersonatedSession()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.F Then
            CallFacturacion()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.S Then
            CallFacturacionSiHay()
        End If
    End Sub

    Private Sub MainForm_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        DashBoardTemp.timer1.Start()
        DashBoardTemp.timer2.Start()
        'Console.WriteLine("La pantalla principal tiene el focus")
    End Sub

    Private Sub MainForm_Deactivate(sender As System.Object, e As System.EventArgs) Handles MyBase.Deactivate
        DashBoardTemp.timer1.Stop()
        DashBoardTemp.timer2.Stop()
        'Console.WriteLine("La pantalla principal perdio el focus")
    End Sub

#Region "Reducción de Facturación"

    Private Sub CallFacturacion()
        Dim nHwnI As System.IntPtr
            'Validamos que se hayan hecho las Cargas Iniciales Completas
            Dim dsCargas As DataSet
            dsCargas = oServerUPCMgr.CargasInicialesSelByTienda(oAppContext.ApplicationConfiguration.Almacen)

            If Not dsCargas Is Nothing Then
                If dsCargas.Tables(0).Rows.Count > 0 Then
                    Dim strCatalogos As String = ""
                    For Each oRow As DataRow In dsCargas.Tables(0).Rows
                        '--------------------------------------------------------------------------------------------------------------
                        'JNAVA (22.12.2014): Si aplica el cross seling que no pida realizar la descarga de descuentos adicionales
                        '--------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicaCrossSelling Then
                            If oRow.Item(1) <> "DesA" Then
                                strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                            End If
                        Else
                            strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                        End If
                    Next
                    If strCatalogos <> "" Then
                        'MsgBox("Las siguientes Actualizaciones estan incompletas. Favor de hacer las descargas." _
                        '                         & Microsoft.VisualBasic.vbCrLf & strCatalogos)
                        MessageBox.Show("Las siguientes Actualizaciones estan incompletas. Favor de hacer las descargas." & vbCrLf & strCatalogos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.10.2015: Validamos que no tengan abierto el modulo de Pedidos SH abierto para permitir abrir el módulo de facturacion
            'para evitar la duplicación de folios cuando estan abiertos al mismo tiempo
            '-------------------------------------------------------------------------------------------------------------------------------------
            nHwnI = FindWindow(vbNullString, "Facturación ""Si Hay""")
            If Val(nHwnI.ToString) <> 0 Then
                MessageBox.Show("El módulo de Pedidos Si Hay está abierto, es necesario cerrarlo antes de continuar con la facturación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            nHwnI = FindWindow(vbNullString, "Facturación")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else
                'Checamos si existen facturas pendientes de grabar.
                'Dim oCierreDiaManager As New CierreDiaManager(oAppContext, oAppSAPConfig)

                'Dim oCierreDiaDG As New CierreDiaDataGateWay(oCierreDiaManager)
                'Dim dsFacturaSelDontSaved As New DataSet
                'Dim oFacturaMgr As New FacturaManager(oAppContext)
                'dsFacturaSelDontSaved = oCierreDiaDG.FacturaSelDontSavedByCaja()

                ''Si existen pendientes
                'If dsFacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
                '    Dim ofrmLoadFacturas As New frmGuardarFacturasPendientes
                '    ofrmLoadFacturas.oParent = oCierreDiaManager
                '    ofrmLoadFacturas.boolTipo = True
                '    ofrmLoadFacturas.ShowDialog()
                'Else

                '---------------------------------------------------------------------
                ' JNAVA (02.03.2017): Validamos si está activa la nueva facturacion
                '---------------------------------------------------------------------
                If oConfigCierreFI.FacturacionNueva Then
                    Dim menuClickB As New frmFacturacionNueva
                    menuClickB.Show()
                Else
                    Dim menuClickB As New frmFacturacion
                    menuClickB.Show()
                End If

                'End If

        End If
    End Sub

    Private Sub CallFacturacionSiHay()
        Dim nHwnI As System.IntPtr
            'Validamos que se hayan hecho las Cargas Iniciales Completas
            Dim dsCargas As DataSet
            dsCargas = oServerUPCMgr.CargasInicialesSelByTienda(oAppContext.ApplicationConfiguration.Almacen)

            If Not dsCargas Is Nothing Then
                If dsCargas.Tables(0).Rows.Count > 0 Then
                    Dim strCatalogos As String = ""

                    For Each oRow As DataRow In dsCargas.Tables(0).Rows

                        '------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 27/12/2014: Si aplica el cross selling que no pida realizar la descarga de descuentos adicionales
                        '------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicaCrossSelling Then
                            If oRow.Item(1) <> "DesA" Then
                                strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                            End If
                        Else
                            strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                        End If
                        'strCatalogos = strCatalogos & oRow.Item(2) & Microsoft.VisualBasic.vbCrLf
                    Next
                    If strCatalogos <> "" Then
                        MessageBox.Show("Las siguientes Actualizaciones estan incompletas. Favor de hacer las descargas." & vbCrLf & strCatalogos, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 15.10.2015: Validamos que no tengan abierto el módulo de facturación abierto para permitir abrir el módulo de pedidos Si Hay
            'para evitar la duplicación de folios cuando estan abiertos al mismo tiempo
            '-------------------------------------------------------------------------------------------------------------------------------------
            nHwnI = FindWindow(vbNullString, "Facturación")
            If Val(nHwnI.ToString) <> 0 Then
                MessageBox.Show("Tiene abierto el módulo de facturación, favor de cerrarlo antes de continuar con el pedido Si Hay", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            nHwnI = FindWindow(vbNullString, "Facturación ""Si Hay""")
            If Val(nHwnI.ToString) <> 0 Then
                ShowWindow(nHwnI, 9)
                SetForegroundWindow(nHwnI)
            Else

                Dim menuClickB As New frmFacturacionSinExistencia
                menuClickB.Show()
        End If
    End Sub

#End Region

#Region "Consignacion"

    Public Sub AplicarConsignacion(ByVal Traspaso As Dictionary(Of String, Object))
        Dim async As New ProcessAsync(Traspaso)
        async.Execute(AddressOf SaveConsignacion)
    End Sub

    Private Function SaveConsignacion(ByVal Traspaso As Dictionary(Of String, Object)) As Boolean
        Dim valido As Boolean = False
        Dim result As New Dictionary(Of String, Object)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim TraspasoEntradaMgr As New DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Dim dtPedido As DataTable = CType(Traspaso("DetallePedido"), DataTable)
        Dim lstZDpro As List(Of ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos) = CType(Traspaso("lstZDpro"), List(Of ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos))
        Dim TipoConsignacion As TrasladoConsignacion = CType(Traspaso("TrasladoConsignacion"), TrasladoConsignacion)
        Dim TraspasoId As Integer = 0, EsConSerie As Boolean
        If TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
            TraspasoId = CInt(Traspaso("TraspasoEntradaId"))
        ElseIf TipoConsignacion = TrasladoConsignacion.DEVOLUCION Then
            TraspasoId = CInt(Traspaso("TraspasoSalidaId"))
        End If
        EsConSerie = CBool(Traspaso("EsConSerie"))
        Try
            result = oSAPMgr.ZMMOC02(dtPedido)
            If CBool(result("Success")) Then
                Dim response As New Dictionary(Of String, Object)
                Dim mblnr As String = CStr(result("MBLNR"))
                For Each zdpro As ApplicationUnits.Traspasos.TraspasosEntrada.ZdproPedidos In lstZDpro
                    zdpro.DocMaterial = mblnr
                Next
                If TraspasoEntradaMgr.SaveZdproPedido(lstZDpro) Then
                    If TipoConsignacion = TrasladoConsignacion.ORDENCOMPRA Then
                        TraspasoEntradaMgr.ActualizarDocumentoEntradaMercancia(TraspasoId, mblnr)
                    ElseIf TipoConsignacion = TrasladoConsignacion.DEVOLUCION Then
                        Dim oTraspasoSalidaMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)
                        oTraspasoSalidaMgr.ActualizaDocumentoDevProveedor(TraspasoId, mblnr)
                    End If
                    If EsConSerie Then
                        response = oSAPMgr.ZMMOC03(mblnr)
                        If CBool(response("Success")) Then
                            Dim dtZequi As DataTable = CType(response("ZEQUI"), DataTable)
                            Dim lstZequi As New List(Of DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi)
                            If GuardarZequi(dtZequi, lstZequi) Then
                                valido = True
                            Else
                                EscribeLog("Error al guardar tabla Zequi", "Error Zequi")
                            End If
                        End If
                    Else
                        valido = True
                    End If
                Else
                    EscribeLog("No se pudierón guardar los datos del pedido", "Error al guardar datos del pedido")
                End If
            Else
                EscribeLog("Error al aplicar el traslado en SAP" & vbCrLf & CStr(result("Mensaje")), "Error al aplicar consignacion SAP")
            End If
        Catch ex As Exception
            EscribeLog("Error al aplicar el traslado" & vbCrLf & CStr(result("Mensaje")), "Error al aplicar el traspaso")
        End Try
        Return valido
    End Function

    Private Function GuardarZequi(ByVal dtZequi As DataTable, ByVal lstZequi As List(Of DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi)) As Boolean
        Dim valido As Boolean = False
        Dim TraspasoEntradaMgr As New DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Dim zequi As DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi = Nothing
        Try
            For Each row As DataRow In dtZequi.Rows
                zequi = New DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada.Zequi(TraspasoEntradaMgr)
                zequi.CodArticulo = CStr(row("MATNR"))
                zequi.Serie = CStr(row("SERNR"))
                zequi.NoPedido = CStr(row("EBELN"))
                zequi.CentroOrigen = CStr(row("WERKS"))
                zequi.CentroDestino = CStr(row("WERKSD"))
                zequi.Proveedor = CStr(row("LIFNR"))
                zequi.DocMaterial = CStr(row("MBLNR"))
                zequi.ClaseMovimiento = CStr(row("BWART"))
                zequi.SOBKZ = CStr(row("SOBKZ"))
                zequi.SHKZG = CStr(row("SHKZG"))
                zequi.BEWTP = CStr(row("BEWTP"))
                lstZequi.Add(zequi)
            Next
            TraspasoEntradaMgr.SaveZequi(lstZequi)
            valido = True
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al guardar los artículos de Consignación")
        End Try
        Return valido
    End Function
#End Region

End Class
