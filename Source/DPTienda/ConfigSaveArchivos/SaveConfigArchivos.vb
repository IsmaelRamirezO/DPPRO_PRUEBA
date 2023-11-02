Public Class SaveConfigArchivos

    Private m_bTPVVirtual As Boolean = False
    Private m_bValidaDatosDPVL As Boolean = False
    Private m_strPuertoBrokerNew As Long = 7802
    Private m_strServerBrokerNew As String = "http://10.200.3.13"
    Private m_bprueba As Boolean = True
    Private m_bMostrarConcenAUD As Boolean = False
    Private m_bAplicaCrossSelling As Boolean = False
    Private m_intDiasRecibirPagosEC As Integer = 10
    Private m_bRecibirOtrosPagos As Boolean = False
    Private m_strNotaOtrosPagosEC As String = ""
    Private m_bPedirDatosPromoComienzo As Boolean = True
    Private m_strDPKTCodUso As String = "202"
    Private m_bDPKTPrioridadCodUso As Boolean = True
    Private m_decImporteMaximoDPVale As Decimal = 5000
    Private m_bEmparejarMayorPrecio2x1 As Boolean = False
    Private m_strPasswordFTPBroker As String = "dportenix1"
    Private m_strUserFTPBroker As String = "linux"
    Private m_strRutaFTPDHL As String = "/var/mqsi/dhl/Prod/TransformXMLtoPDF/PDFReports/"
    Private m_bNuevaRegla20y30 As Boolean = True
    Private m_bValidaCierreSH As Boolean = True
    Private m_bEtiquetaPrecioFactory As Boolean = False
    Private m_bEtiquetaDP As Boolean = True
    Private m_bMiniprinterTermica As Boolean = False
    Private m_bCompreAhoraPDOpcional As Boolean = False
    Private m_bBorrarPreciosCierre As Boolean = True
    Private m_bNuevaRegla2x1yMedio As Boolean = True
    Private m_decMaxDescApartados As Decimal = 0.2
    Private m_strPasswordBroker As String = "dportenix1"
    Private m_strUserBroker As String = "broker"
    Private m_strBaseDatosBroker As String = "ConfiguracionBroker"
    Private m_strServerSQLBroker As String = "192.168.1.26"
    Private m_lngPuertoBroker As Long = 7802
    Private m_bGenerarGuiaDHLAutomatica As Boolean = False
    Private m_bServidorHTTPS As Boolean = False
    Private m_strServerBroker As String = "http://10.200.3.18"
    Private m_strImagenFondoURL As String = "http://descargas.dportenis.com.mx/descargas/FilminaVentasFinalAgosto2012.jpg"
    'FLIZARRAGA 16/12/2014 Ruta de imagenes de consulta de existencias
    Private m_ImagenesExistencia As String = "http://www.dportenis.mx/wcsstore/Dportenis/images/catalog/zoom/"
    Private m_strMailGerenteRegional As String = ""
    Private m_strMailsLogistica As String()
    Private m_strMailGerenteOperaciones As String = ""
    Private m_strMailGerentePlaza As String = ""
    Private m_intTraspasosSalidaXDia As Integer = 6
    Private m_bSoloMismaPlazaTS As Boolean = True
    Private m_intPzasTotalesTS As Integer = 12
    Private m_bImprimirEtiquetasEnLaser As Boolean = False
    Private m_strPasswordProxy As String = ""
    Private m_strUserProxy As String = ""
    Private m_intDiasParaEnviarEC As Integer = 1
    Private m_intDiasParaFacturarConcenEC As Integer = 1
    Private m_intDiasParaFacturarEC As Integer = 1
    Private m_intDiasParaSurtirEC As Integer = 0
    Private m_strInternetServer As String = "http://descargas.dportenis.com.mx/descargas/"
    Private m_strServidorHTTPS As String = "https://descargas.grupodp.com.mx/"
    Private m_strExtensionDHL As String = "1112"
    Private m_strCuentaCLABE_DHL As String = "012744004472096730"
    Private m_strNoCuentaDHL As String = "981103257"
    Private m_intDiasParaBloquearTP As Integer = 15
    Private m_bBloquearXTP As Boolean = False
    Private m_bAplicaNewDescuentosDIPs As Boolean = True
    Private m_bShowManagerPC As Boolean = False
    Private m_bSurtirEcommerce As Boolean = False
    Private m_bPromoSMS As Boolean = True
    Private m_intTiempoRevisaPedidos As Integer = 5
    Private m_strCuentasCorreoErroresCDist As String()
    Private m_bRecibirParcialmente As Boolean = False
    Private m_bRecibirPorBultos As Boolean = False
    Private m_strPasswordTraspasos As String = ""
    Private m_strUserTraspasos As String = ""
    Private m_strBaseDatosTraspasos As String = ""
    Private m_strServerTraspasos As String = ""
    Private m_intTiempoEsperaDescargas As Integer = 20
    Private m_strDireccionImagenesEmail As String = ""
    Private m_strDireccionValidaEmail As String = ""
    Private m_bRegistroExpressPG As Boolean = False
    Private m_bRegistroPGOpcional As Boolean = True
    Private m_bHuellaOpcional As Boolean = True
    Private m_bGuardarInServer As Boolean = True
    Private m_strUnidadIMG As String = ""
    Private m_strPasswordIMG As String = ""
    Private m_strUsuarioIMG As String = ""
    Private m_strRutaIMG As String = ""
    Private m_strCorreoActivacion As String = ""
    Private m_strPasswordEmails As String = ""
    Private m_strUserEmails As String = ""
    Private m_strBaseDatosEmails As String = ""
    Private m_strServerEmails As String = ""
    Private m_strRutaActualizacion As String = ""
    Private m_intMaximoEC As Long
    Private m_intMinimoEC As Long
    Private m_bValidacionFS As Boolean
    Private m_strServidorSMTP As String = "smtp.gmail.com"
    Private m_strCuentaCorreo As String = "info@dportenis.com.mx"
    Private m_strPassFirma As String
    Private m_strUserFirma As String
    Private m_strBaseDatosFirmas As String
    Private m_strServerFirma As String
    Private m_bImprimirCedula As Boolean = True
    Private m_datFechaAutoF As Date
    Private m_usuario As String
    Private m_password As String
    Private m_ruta As String
    Private m_unidad As String
    Private m_CargaInicial As Boolean
    Private m_MiniPrinter As Boolean
    Private m_PrinterHP As Boolean
    Private m_strServerHuellas As String
    Private m_strBDHuellas As String
    Private m_strUserHuellas As String
    Private m_strPassHuellas As String
    Private m_bolUsarHuellas As Boolean
    Private m_bolUsarSccanerIFE As Boolean
    Private m_bolUsarTPV As Boolean
    Private m_bolDescargaClientes As Boolean
    Private m_strServerEhub As String
    Private m_strBaseDatosEhub As String
    Private m_strUserEhub As String
    Private m_strPassEhub As String
    Private m_strCuentasCorreoAuditoria As String()
    Private m_strCuentasCorreoUPC As String()
    Private m_strServerSeparaciones As String
    Private m_strBaseDatosSeparaciones As String
    Private m_strUserSeparaciones As String
    Private m_strPassSeparaciones As String
    Private m_decMontoMaxTarjetas As Decimal

    'SiHay
    Private m_intDiasRecogerReembolsoSH As Integer
    Private m_intDiasPostergarCitaSH As Integer = 5
    Private m_DevolverEfectivoSH As Boolean = True
    Private m_intDiasSurtirSH As Integer
    Private m_intDiasSinGuiaSH As Integer
    Private m_intDiasRecibirSH As Integer
    Private m_intDiasFacturarSH As Integer
    Private m_intDiasCancelarSH As Integer
    Private m_intDiasInsurtiblesSH As Integer

  

    'Promociones Del Buen Fin 07/11/2013
    Private m_limitediasempleado As Integer = 3
    Private m_promocionempleado As Boolean = False

    'Promocion Cupon con todos los descuentos 25/02/2014
    Private m_cuponDescuentos As Boolean = True

    'Motivos de Rechazo - 06/05/2014
    Private m_bMotivosRechazoDPVL As Boolean = False

    'ScoreBoard 19/05/2014
    Private m_MostrarScoreBoard As Boolean = False

    'Configuración de etiquetas  22/05/2014
    Private m_EtiquetasTallas As Boolean = False

    Private m_ImpresoraETIF As String = ""
    Private m_bMostrarTF As Boolean = False

    '-------------------------------------------------------------------------
    'JNAVA 20.06.2014: Traspasos de Entrada desde Lectora
    '-------------------------------------------------------------------------
    Private m_bTraspasoEntradaLectora As Boolean = False
    Private m_strNombreLectoraTE As String = "CS3070"
    Private m_strNombreArchivoLectoraTE As String = "BarcodeFile.txt"

    '-------------------------------------------------------------------------
    'JNAVA 20.06.2014: Traspasos de Entrada desde Lectora
    '-------------------------------------------------------------------------
    Private m_bAuditoriaLectoraCS3070 As Boolean = False
    '-------------------------------------------------------------------------

    '-------------------------------------------------------------------------
    'JNAVA 19.09.2014: Generar ReRevale
    '-------------------------------------------------------------------------
    Private m_bGenerarReRevale As Boolean = False
    '-------------------------------------------------------------------------

    '-------------------------------------------------------------------------
    'FLIZARRAGA 16/10/2014 Si Hay DPVale
    '-------------------------------------------------------------------------
    Private m_SiHayDPVale As Boolean = False

    '-------------------------------------------------------------------------
    'JNAVA 12.12.2014: Cliente Ecommerce
    '-------------------------------------------------------------------------
    Private m_strClienteEC As String = "50000000"
    '-------------------------------------------------------------------------

    '-------------------------------------------------------------------------
    'JNAVA 15.12.2014: Correos Pagos Ecommerce
    '-------------------------------------------------------------------------
    Private m_strMailsEC As String()

    '-------------------------------------------------------------------------
    'FLIZARRAGA 18/12/2014: Evitar Cierre de día
    '-------------------------------------------------------------------------
    Private m_EvitarCierreDia As Boolean = False
    Private m_MailsCierreDia As String()

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 07.01.2015: Config para pagos con tarjetas Karum
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bAplicaDPCard As Boolean = False

    '------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 15.01.2015: Config para pagos con tarjetas Karum
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strConsecutivoPOS As String = "0001"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/08/2016: Config para consecutivo para DPCard Puntos Karum
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ConsecutivoPuntosPOS As String = "0001"

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (27.01.2015): Importe Maximo para ventas con electronico de DPVale
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_decImporteMaximoElectronicosDPVale As Decimal = 9500.0

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (03.02.2015): Configuracion de Server de DPCard
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strPasswordDPCard As String = ""
    Private m_strUserDPCard As String = ""
    Private m_strBaseDatosDPCard As String = "Karum"
    Private m_strServerDPCard As String = "10.200.3.30"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 05/02/2014: Leyenda de Nota de Ventas de Ecommerce
    '-------------------------------------------------------------------------------------------------------------------------------

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (05.02.2015): Configuracion de Server de DPValeTODO
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strPasswordDPValeAIO As String = "dpvl250914"
    Private m_strUserDPValeAIO As String = "dpvaletodo"
    Private m_strBaseDatosDPValeAIO As String = "DPValeTodo"
    Private m_strServerDPValeAIO As String = "10.200.3.30"

    Private m_LeyendaDportenis As String = "Dportenis"
    Private m_LeyendaDPStreet As String = "DPStreet"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/02/2015: Surtir y Facturar Pedidos Ecommerce
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_AplicarSurtidoDPStreet As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 05.02.2015: Config para generar seguros DPVALE
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bGenerarSeguro As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (10.02.2015): Configuracion de Server de DPVFinanciero
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strPasswordDPVF As String = "dpvl250914"
    Private m_strUserDPVF As String = "dpvaletodo"
    Private m_strBaseDatosDPVF As String = "DPVFinanciero"
    Private m_strServerDPVF As String = "10.200.3.30"

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (11.03.2015): Configuracion de Cancelacion de Pagos de DP Card
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bCancelarPagosDPCard As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/03/2015: Config para guardar tienda de dpcard credit
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_IDTienda As String = "93251"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 01/04/2015: Aplica DPCardPuntos
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_DPCardPuntos As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2015: Aplica MQTT POS
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_MQTTPOS As Boolean = False

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/06/2015: Bloquea Artículos de Baja Calidad
    '--------------------------------------------------------------------------------------------------------------------------------
    Private m_BloqueaBajaCalidad As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (20.07.2015): Config para permitir arituculos de catalogo en Si Hay
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bArticuloCatalogoSH As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (24.07.2015): Config para permitir la recepcion de mercancia en tiendas de proveedor
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bRecepcionMercanciaTndas As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/08/2015: Config para la venta asistida
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_VentaAsistida As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 31/08/2015: Registro de traspasos de entrada del si Hay
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_RegistroTraspasoSiHay As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/09/2015: Config para anular el ajuste automatico en sobrantes
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_AjusteAutomatico As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (06.10.2015): Configuracion para ejecutar el LiveUpdate al inicio
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bEjecutarLiveUpdateInicio As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (11.12.2015): Configuracion de servidor y puerto para servicios REST
    '------------------------------------------------------------------------------------------------------------------------------
    Private m_strPuertoREST As Long = 7800
    Private m_strServidorREST As String = "http://10.200.32.14"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/11/2015: Configuracion para ruta del archivo de propiedades del MQTT
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_RutaArchivoProperties As String = "propiedades/Agente.properties"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/11/2015: Configuracion para validación de Seguro de Vida DPVL
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ValidaSeguroVidaDPVL As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/11/2015: Configuracion para validar los dias limites para modificar beneficiario
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_DiasModificacionBeneficiario As Integer = 5

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/01/2016: Configuración para SAP Retail
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_OrganizacionCompra As String = "1200"
    Private m_CanalDistribucion As String = "99"
    Private m_Sector As String = "00"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 06/04/2016: Configuraciones del Servidor FTP de cierre
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ServidorFTPCierre As String = "10.200.3.26"
    Private m_UsuarioFTPCierre As String = "FTP.SAP"
    Private m_PasswordFTPCierre As String = "FTPPRO26"

    ''-------------------------------------------------------------------------------------------------------------------------------
    ''JNAVA (11.04.2016): Configuracion para activar o desactivar el servicio de S2Credit
    ''-------------------------------------------------------------------------------------------------------------------------------
    'Private m_bolAplicaS2Credit As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 19/04/2016: Configuración de descuento Fijo en dips de producto que no es de catalogo
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_DescuentoFijoNoCatalogo As Decimal = 15

    '-------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (08.06.2016): Configuracion para Generar Log de Transacciones y para enviar correos de TimeOut
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_GenerarLogTransacciones As Boolean = False
    Private m_EnviarCorreoLentitud As Boolean = False
    Private m_LimiteTiempoLentitud As Integer = 120
    Private m_MailsLentitud As String()

    '-------------------------------------------------------------------------
    'JNAVA (28.06.2016): Configuracion para Pagina web en ticket ecommerce
    '-------------------------------------------------------------------------
    Private m_strPaginaDportenis As String = "http://www.dportenis.mx/"
    Private m_strPaginaDpStreet As String = "http://www.dpstreet.mx/"

    '-------------------------------------------------------------------------
    'FLIZARRAGA 28/07/2016: Configuración para cambiar el Público en General
    '-------------------------------------------------------------------------

    Private m_PublicoGeneral As String = "0050000004"

    '-------------------------------------------------------------------------
    'FLIZARRAGA 15/11/2016: Configuración para impedir el inicio de día
    '-------------------------------------------------------------------------
    Private m_EvitarInicioDia As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (07.07.2016): Configuracion para activar o desactivar el servicio de S2Credit y/ en Paralelo (S2Credit-SAP)
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bolAplicarS2Credit As Boolean = False
    Private m_bolAplicarParaleroS2CSAP As Boolean = False

    '----------------------------------------------------------------
    'JEMO 16/11/2016: Configuracion para registro de clientes DPCard
    '----------------------------------------------------------------
    'Private m_ActivarRegistroDPCard As Boolean = False
    Private m_UrlRegistroDPCard As String = "http://172.16.61.68/Approva2/Login.aspx?"

    '-------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (15.03.2017): Config para activar registro Approva
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_RegistroApprova As Boolean = False

    '---------------------------------------------------------------------
    'FLIZARRAGA 16/01/2017: Configuracion para pagos con tarjeta Banamex
    '---------------------------------------------------------------------
    Private m_PagoBanamex As Boolean = False
    Private m_UserBanamex As String
    Private m_PasswordBanamex As String

    '-------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (22.03.2017): Configuracion para activar o desactivar la carga de todos sin existencia los articulos en SH
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bArticuloSinExistenciaSH As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (20.05.2022): Bandera de materiales extendidos
    '-------------------------------------------------------------------------------------------------------------------------------

    Private m_bMaterialesExtendidos As Boolean = False

    '---------------------------------------------------------------------
    'FLIZARRAGA 14/07/2017: Configuracion para días por quincena
    '---------------------------------------------------------------------

    Private m_DiasQuincena As Integer = 15

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (02.03.2017): Configuracion para activar o desactivarla nueva facturacion
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_bFacturacionNueva As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRRAGA 24/07/2017: Configuración para DPTicket
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_HabilitarDPTicket As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/08/2017 Configuraciones del servidor de Servicios Rest de S2Credit
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ServidorS2Credit As String
    Private m_PuertoS2Credit As Long

    '-------------------------------------------------------------------------------------------------------------------------------
    'DARCOS (22.08.2017): Configuracion para activar o desactivar el Tipo de Venta Factura Fiscal
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_TipoVentaFactFiscal As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/10/2017: Configuración para activar el servicio de TOKA
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ActivarToka As Boolean = False
    Private m_ComisionBancoToka As Decimal = 15


    '-------------------------------------------------------------------------------------------------------------------------------
    'DARCOS (05.12.2017): Configuraciones de alertas DPcards
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_DiasBonificacion As Integer = 15
    Private m_TransaccionesPermitidasBonifica As Integer = 2
    Private m_alertaUsoBonifica As Boolean = True
    Private m_DiasCanje As Integer = 15
    Private m_TransaccionesPermitidasCanje As Integer = 2
    Private m_alertaUsoCanje As Boolean = True

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/01/2018: Configuración para las cuentas de correo autenticadas
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_PuertoSMTP As Integer = 587
    Private m_PasswordCorreo As String = "DporteniS"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/05/2018: Configuración para consignacion
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_TiempoIntervaloConsignacion As Integer = 300000
    Private m_ReintentoConsignacion As Integer = 3
    Private m_PedidoCompra As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/03/2019: Configuración para base de datos DPVFinanciero para descarga de almacenes
    '-------------------------------------------------------------------------------------------------------------------------
    Private m_ServidorFinanciero As String
    Private m_BaseFinanciero As String
    Private m_UsuarioFinanciero As String
    Private m_PasswordFinanciero As String

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 15/04/2019: Configuracion para habilitar la migracion a Financiero
    '--------------------------------------------------------------------------------------------------------------------------
    Private m_MigracionFinanciero As Boolean = False

    '-------------------------------------------------------------------------------------------------------------------------------
    'DARCOS (15.04.2019): Configuración para BD DatosEcomm
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strPasswordDatosEcomm As String = "drt45%ftT/j2"
    Private m_strUserDatosEcomm As String = "DatosEcomm"
    Private m_strBaseDatosDatosEcomm As String = "DatosEcomm"
    Private m_strServerDatosEcomm As String = "10.200.3.30"
    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/07/2019: Configuracion para impresora de pagos Ecommerce
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_ImpresoraEcommerce As String

    '-------------------------------------------------------------------------------------------------------------------------------
    'DARCOS (23.04.2019): Configuración para Servicio Ecomm
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strServicioEcomm As String = "https://cajapagos.grupodp.com.mx/" '"http://10.200.3.35/dpapi"
    'ASanchez 26/03/2021 Consifiguración de los servicios de bonificación a Blue
    Private m_strServiciosBlue As Boolean = True
    'Private m_strServiciosKarum As String = ""
    '-------------------------------------------------------------------------------------------------------------------------------
    'ASANCHEZ (30.03.2021): Configuracion de Server de Blue
    '-------------------------------------------------------------------------------------------------------------------------------
    Private m_strPasswordblue As String = "q@_3kCq=dhCkRV3c"
    Private m_strUserblue As String = "blueusrapp"
    Private m_strBaseDatosBlue As String = "Blue"
    Private m_strServerBlue As String = "10.200.3.30"
    Private m_usr_token_blue As String = "dppro"
    'SANCHEZ 21/04/2021 nuevos servidor de consulta del servidor lealtad
    Private m_strServerLealtad As String = "http://10.200.3.103"
    Private m_lngPuertoLealtad As Long = 7082


#Region "Methods"

    Public Sub New()

        Me.Create()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Private Sub Create()

        m_bValidacionFS = False
        m_strServidorSMTP = ""
        m_strCuentaCorreo = ""
        m_strPassFirma = ""
        m_strUserFirma = ""
        m_strBaseDatosFirmas = ""
        m_strServerFirma = ""
        m_bImprimirCedula = True
        m_datFechaAutoF = "01-01-9999"
        m_usuario = ""
        m_password = ""
        m_ruta = ""
        m_unidad = ""
        m_CargaInicial = False
        m_MiniPrinter = False
        m_PrinterHP = False
        m_strServerHuellas = "192.168.1.30"
        m_strBDHuellas = "FingerPrint"
        m_strUserHuellas = "sa"
        m_strPassHuellas = "01012006"
        m_bolUsarHuellas = False
        m_bolUsarSccanerIFE = False
        m_bolUsarTPV = True
        m_bolDescargaClientes = False
        m_strServerEhub = ""
        m_strUserEhub = ""
        m_strBaseDatosEhub = ""
        m_strPassEhub = ""
        m_strServerSeparaciones = ""
        m_strBaseDatosSeparaciones = ""
        m_strUserSeparaciones = ""
        m_strPassSeparaciones = ""
        m_decMontoMaxTarjetas = 0
        m_intMaximoEC = 9228999999
        m_intMinimoEC = 9228000001
        m_strRutaActualizacion = "C:\LiveUpdate"
        m_strServerEmails = "201.147.208.243"
        m_strBaseDatosEmails = "EmailsClientes"
        m_strUserEmails = "sa"
        m_strPasswordEmails = "01012006"
        m_strCorreoActivacion = "mail@dportenis.com.mx"
        m_bRegistroExpressPG = False
        m_bRegistroPGOpcional = True
        m_bHuellaOpcional = True
        m_bGuardarInServer = True
        m_intTiempoEsperaDescargas = 20
        m_bRecibirParcialmente = False
        m_bRecibirPorBultos = False
        m_strPasswordTraspasos = "01012006"
        m_strUserTraspasos = "sa"
        m_strBaseDatosTraspasos = "Traspasos"
        m_strServerTraspasos = "192.168.1.30"
        ReDim m_strCuentasCorreoErroresCDist(2)
        m_strCuentasCorreoErroresCDist(0) = "juan.quintero@dportenis.com.mx"
        m_strCuentasCorreoErroresCDist(1) = "andres.navarrete@dportenis.com.mx"
        m_strCuentasCorreoErroresCDist(2) = "berenice.gonzalez@dportenis.com.mx"
        ReDim m_MailsCierreDia(3)
        m_MailsCierreDia(0) = "rodrigo.solis@dportenis.com.mx"
        m_MailsCierreDia(1) = "leonardo.carbajal@dportenis.com.mx"
        m_MailsCierreDia(2) = "ismael.paez@carbajal@dportenis.com.mx"
        m_MailsCierreDia(3) = "dora.arangure@dportenis.com.mx"
        m_RutaArchivoProperties = Environment.CurrentDirectory & "\agente.properties"
    End Sub

#End Region


#Region "Properties"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/05/2018: Configuración para artículos en consignacion
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property TiempoIntervaloConsignacion As Integer
        Get
            Return m_TiempoIntervaloConsignacion
        End Get
        Set(ByVal value As Integer)
            m_TiempoIntervaloConsignacion = value
        End Set
    End Property

    Public Property ReintentoConsignacion As Integer
        Get
            Return m_ReintentoConsignacion
        End Get
        Set(ByVal value As Integer)
            m_ReintentoConsignacion = value
        End Set
    End Property

    Public Property PedidoCompra As Boolean
        Get
            Return m_PedidoCompra
        End Get
        Set(value As Boolean)
            m_PedidoCompra = value
        End Set
    End Property


    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/01/2018: Configuración para las cuentas de correo autenticadas
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property PuertoSMTP As Integer
        Get
            Return m_PuertoSMTP
        End Get
        Set(ByVal value As Integer)
            m_PuertoSMTP = value
        End Set
    End Property

    Public Property PasswordCorreo As String
        Get
            Return m_PasswordCorreo
        End Get
        Set(ByVal value As String)
            m_PasswordCorreo = value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------------------------------
    'DARCOS (05.12.2017): Configuraciones de alertas DPcards
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property DiasPermitidosBonificacion As Integer
        Get
            Return m_DiasBonificacion
        End Get
        Set(ByVal value As Integer)
            m_DiasBonificacion = value
        End Set
    End Property

    Public Property DiasPermitidosCanje As Integer
        Get
            Return m_DiasCanje
        End Get
        Set(ByVal value As Integer)
            m_DiasCanje = value
        End Set
    End Property

    Public Property transaccionesPermitidasCanje As Integer
        Get
            Return m_TransaccionesPermitidasCanje
        End Get
        Set(ByVal value As Integer)
            m_TransaccionesPermitidasCanje = value
        End Set
    End Property

    Public Property transaccionesPermitidasBonifica As Integer
        Get
            Return m_TransaccionesPermitidasBonifica
        End Get
        Set(ByVal value As Integer)
            m_TransaccionesPermitidasBonifica = value
        End Set
    End Property

    Public Property alertUsoBonifica As Boolean
        Get
            Return m_alertaUsoBonifica
        End Get
        Set(ByVal value As Boolean)
            m_alertaUsoBonifica = value
        End Set
    End Property

    Public Property alertUsoCanje As Boolean
        Get
            Return m_alertaUsoCanje
        End Get
        Set(ByVal value As Boolean)
            m_alertaUsoCanje = value
        End Set
    End Property


    '-----------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/01/2017: Configuración para pagos Banamex
    '-----------------------------------------------------------------------------------------------
    Public Property PagosBanamex As Boolean
        Get
            Return m_PagoBanamex
        End Get
        Set(ByVal value As Boolean)
            m_PagoBanamex = value
        End Set
    End Property

    Public Property UserBanamex As String
        Get
            Return m_UserBanamex
        End Get
        Set(ByVal value As String)
            m_UserBanamex = value
        End Set
    End Property

    Public Property PasswordBanamex As String
        Get
            Return m_PasswordBanamex
        End Get
        Set(ByVal value As String)
            m_PasswordBanamex = value
        End Set
    End Property


    '----------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/11/2015: Configuracion para validar los días limites para modificar beneficiario
    '----------------------------------------------------------------------------------------------

    Public Property DiasModificacionBeneficiario() As Integer
        Get
            Return m_DiasModificacionBeneficiario
        End Get
        Set(ByVal Value As Integer)
            m_DiasModificacionBeneficiario = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA 10/11/2015: Configuracion para ruta de archivo properties MQTT
    '-------------------------------------------------------------------------
    Public Property RutaArchivoProperties() As String
        Get
            Return m_RutaArchivoProperties
        End Get
        Set(ByVal Value As String)
            m_RutaArchivoProperties = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA: 01/04/2015: Aplica DPCard Puntos
    '-------------------------------------------------------------------------

    Public Property DPCardPuntos() As Boolean
        Get
            Return m_DPCardPuntos
        End Get
        Set(ByVal Value As Boolean)
            m_DPCardPuntos = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA: 21/05/2015: Aplica Facturacion MQTT en la facturación
    '-------------------------------------------------------------------------

    Public Property MQTTPOS() As Boolean
        Get
            Return m_MQTTPOS
        End Get
        Set(ByVal Value As Boolean)
            m_MQTTPOS = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA 10/06/2015: Bloquea Artículos de Baja Calidad
    '-------------------------------------------------------------------------

    Public Property BloqueaBajaCalidad() As Boolean
        Get
            Return m_BloqueaBajaCalidad
        End Get
        Set(ByVal Value As Boolean)
            m_BloqueaBajaCalidad = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA 26/03/2015: IDTienda para Tarjeta DPCard
    '-------------------------------------------------------------------------

    Public Property IDTienda() As String
        Get
            Return m_IDTienda
        End Get
        Set(ByVal Value As String)
            m_IDTienda = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA 05/02/2014: Leyenda de Ecommerce para las notas de ventas
    '-------------------------------------------------------------------------

    Public Property LeyendaDportenis() As String
        Get
            Return m_LeyendaDportenis
        End Get
        Set(ByVal Value As String)
            m_LeyendaDportenis = Value
        End Set
    End Property

    Public Property LeyendaDPStreet() As String
        Get
            Return m_LeyendaDPStreet
        End Get
        Set(ByVal Value As String)
            m_LeyendaDPStreet = Value
        End Set
    End Property

    Public Property AplicarSurtidoDPStreet() As Boolean
        Get
            Return m_AplicarSurtidoDPStreet
        End Get
        Set(ByVal Value As Boolean)
            m_AplicarSurtidoDPStreet = Value
        End Set
    End Property

    '-------------------------------------------------------------------------
    'FLIZARRAGA 18/12/2014: Evitar Cierre de día
    '-------------------------------------------------------------------------

    Public Property EvitarCierreDia() As Boolean
        Get
            Return m_EvitarCierreDia
        End Get
        Set(ByVal Value As Boolean)
            m_EvitarCierreDia = Value
        End Set
    End Property

    Public Property MailCierreDia() As String()
        Get
            Return m_MailsCierreDia
        End Get
        Set(ByVal Value As String())
            m_MailsCierreDia = Value
        End Set
    End Property

    'FLIZARRAGA 16/12/2014 Ruta de imagenes en existencia
    Public Property ImagenesExistencia() As String
        Get
            Return m_ImagenesExistencia
        End Get
        Set(ByVal Value As String)
            m_ImagenesExistencia = Value
        End Set
    End Property

    Public Property ImpresoraETIF() As String
        Get
            Return m_ImpresoraETIF
        End Get
        Set(ByVal Value As String)
            m_ImpresoraETIF = Value
        End Set
    End Property

    Public Property MostrarTF() As Boolean
        Get
            Return m_bMostrarTF
        End Get
        Set(ByVal Value As Boolean)
            m_bMostrarTF = Value
        End Set
    End Property

    Public Property ScoreBoard() As Boolean
        Get
            Return m_MostrarScoreBoard
        End Get
        Set(ByVal Value As Boolean)
            m_MostrarScoreBoard = Value
        End Set
    End Property

    Public Property EtiquetasTallas() As Boolean
        Get
            Return m_EtiquetasTallas
        End Get
        Set(ByVal Value As Boolean)
            m_EtiquetasTallas = Value
        End Set
    End Property

    Public Property CorreoActivacion() As String
        Get
            Return m_strCorreoActivacion
        End Get
        Set(ByVal Value As String)
            m_strCorreoActivacion = Value
        End Set
    End Property

    Public Property ServerEmails() As String
        Get
            Return m_strServerEmails
        End Get
        Set(ByVal Value As String)
            m_strServerEmails = Value
        End Set
    End Property

    Public Property BaseDatosEmails() As String
        Get
            Return m_strBaseDatosEmails
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosEmails = Value
        End Set
    End Property

    Public Property UserEmails() As String
        Get
            Return m_strUserEmails
        End Get
        Set(ByVal Value As String)
            m_strUserEmails = Value
        End Set
    End Property

    Public Property PasswordEmails() As String
        Get
            Return m_strPasswordEmails
        End Get
        Set(ByVal Value As String)
            m_strPasswordEmails = Value
        End Set
    End Property

    Public Property RutaActualizacion() As String
        Get
            Return m_strRutaActualizacion
        End Get
        Set(ByVal Value As String)
            m_strRutaActualizacion = Value
        End Set
    End Property

    Public Property MinimoEC() As Long
        Get
            Return m_intMinimoEC
        End Get
        Set(ByVal Value As Long)
            m_intMinimoEC = Value
        End Set
    End Property

    Public Property MaximoEC() As Long
        Get
            Return m_intMaximoEC
        End Get
        Set(ByVal Value As Long)
            m_intMaximoEC = Value
        End Set
    End Property

    Public Property MontoMaxTarjetas() As Decimal
        Get
            Return m_decMontoMaxTarjetas
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoMaxTarjetas = Value
        End Set
    End Property

    Public Property ServerSeparaciones() As String
        Get
            Return m_strServerSeparaciones
        End Get
        Set(ByVal Value As String)
            m_strServerSeparaciones = Value
        End Set
    End Property

    Public Property BDSeparaciones() As String
        Get
            Return m_strBaseDatosSeparaciones
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosSeparaciones = Value
        End Set
    End Property

    Public Property UserSeparaciones() As String
        Get
            Return m_strUserSeparaciones
        End Get
        Set(ByVal Value As String)
            m_strUserSeparaciones = Value
        End Set
    End Property

    Public Property PassSeparaciones() As String
        Get
            Return m_strPassSeparaciones
        End Get
        Set(ByVal Value As String)
            m_strPassSeparaciones = Value
        End Set
    End Property

    Public Property CuentasCorreoUPC() As String()
        Get
            Return m_strCuentasCorreoUPC
        End Get
        Set(ByVal Value As String())
            m_strCuentasCorreoUPC = Value
        End Set
    End Property

    Public Property CuentasCorreoAuditoria() As String()
        Get
            Return m_strCuentasCorreoAuditoria
        End Get
        Set(ByVal Value As String())
            m_strCuentasCorreoAuditoria = Value
        End Set
    End Property

    Public Property PassEhub() As String
        Get
            Return m_strPassEhub
        End Get
        Set(ByVal Value As String)
            m_strPassEhub = Value
        End Set
    End Property

    Public Property UserEhub() As String
        Get
            Return m_strUserEhub
        End Get
        Set(ByVal Value As String)
            m_strUserEhub = Value
        End Set
    End Property

    Public Property BaseDatosEhub() As String
        Get
            Return m_strBaseDatosEhub
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosEhub = Value
        End Set
    End Property

    Public Property ServerEhub() As String
        Get
            Return m_strServerEhub
        End Get
        Set(ByVal Value As String)
            m_strServerEhub = Value
        End Set
    End Property

    Public Property UsarDescargaClientes() As Boolean
        Get
            Return m_bolDescargaClientes
        End Get
        Set(ByVal Value As Boolean)
            m_bolDescargaClientes = Value
        End Set
    End Property

    Public Property ValidacionFS() As Boolean
        Get
            Return m_bValidacionFS
        End Get
        Set(ByVal Value As Boolean)
            m_bValidacionFS = Value
        End Set
    End Property

    Public Property PrinterHP() As Boolean
        Get
            Return m_PrinterHP
        End Get
        Set(ByVal Value As Boolean)
            m_PrinterHP = Value
        End Set
    End Property

    Public Property MiniPrinter() As Boolean
        Get
            Return m_MiniPrinter
        End Get
        Set(ByVal Value As Boolean)
            m_MiniPrinter = Value
        End Set
    End Property

    Public Property CargaInicial() As Boolean
        Get
            Return m_CargaInicial
        End Get
        Set(ByVal Value As Boolean)
            m_CargaInicial = Value
        End Set
    End Property

    Public Property TipoVentaFactFiscal() As Boolean
        Get
            Return m_TipoVentaFactFiscal
        End Get
        Set(ByVal Value As Boolean)
            m_TipoVentaFactFiscal = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal Value As String)
            m_usuario = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return m_password
        End Get
        Set(ByVal Value As String)
            m_password = Value
        End Set
    End Property

    Public Property Ruta() As String
        Get
            Return m_ruta
        End Get
        Set(ByVal Value As String)
            m_ruta = Value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return m_unidad
        End Get
        Set(ByVal Value As String)
            m_unidad = Value
        End Set
    End Property

    Public Property FechaAutoF() As Date
        Get
            Return m_datFechaAutoF
        End Get
        Set(ByVal Value As Date)
            m_datFechaAutoF = Value
        End Set
    End Property
    Public Property ImprimirCedula() As Boolean
        Get
            Return m_bImprimirCedula
        End Get
        Set(ByVal Value As Boolean)
            m_bImprimirCedula = Value
        End Set
    End Property

    Public Property ServerFirma() As String
        Get
            Return m_strServerFirma
        End Get
        Set(ByVal Value As String)
            m_strServerFirma = Value
        End Set
    End Property

    Public Property BaseDatosFirmas() As String
        Get
            Return m_strBaseDatosFirmas
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosFirmas = Value
        End Set
    End Property

    Public Property UserFirma() As String
        Get
            Return m_strUserFirma
        End Get
        Set(ByVal Value As String)
            m_strUserFirma = Value
        End Set
    End Property

    Public Property PassFirma() As String
        Get
            Return m_strPassFirma
        End Get
        Set(ByVal Value As String)
            m_strPassFirma = Value
        End Set
    End Property
    Public Property CuentaCorreo() As String
        Get
            Return m_strCuentaCorreo
        End Get
        Set(ByVal Value As String)
            m_strCuentaCorreo = Value
        End Set
    End Property

    Public Property ServidorSMTP() As String
        Get
            Return m_strServidorSMTP
        End Get
        Set(ByVal Value As String)
            m_strServidorSMTP = Value
        End Set
    End Property

    Public Property ServerHuellas() As String
        Get
            Return m_strServerHuellas
        End Get
        Set(ByVal Value As String)
            m_strServerHuellas = Value
        End Set
    End Property

    Public Property BaseDatosHuellas() As String
        Get
            Return m_strBDHuellas
        End Get
        Set(ByVal Value As String)
            m_strBDHuellas = Value
        End Set
    End Property

    Public Property UserHuellas() As String
        Get
            Return m_strUserHuellas
        End Get
        Set(ByVal Value As String)
            m_strUserHuellas = Value
        End Set
    End Property

    Public Property PassHuellas() As String
        Get
            Return m_strPassHuellas
        End Get
        Set(ByVal Value As String)
            m_strPassHuellas = Value
        End Set
    End Property

    Public Property UsarHuellas() As Boolean
        Get
            Return m_bolUsarHuellas
        End Get
        Set(ByVal Value As Boolean)
            m_bolUsarHuellas = Value
        End Set
    End Property

    Public Property UsarSccanerIFE() As Boolean
        Get
            Return m_bolUsarSccanerIFE
        End Get
        Set(ByVal Value As Boolean)
            m_bolUsarSccanerIFE = Value
        End Set
    End Property

    Public Property UsarTPV() As Boolean
        Get
            Return m_bolUsarTPV
        End Get
        Set(ByVal Value As Boolean)
            m_bolUsarTPV = Value
        End Set
    End Property

    Public Property RegistrosTraspasoSiHay() As Boolean
        Get
            Return m_RegistroTraspasoSiHay
        End Get
        Set(ByVal Value As Boolean)
            m_RegistroTraspasoSiHay = Value
        End Set
    End Property

    Public Property ValidaSeguroDPVL() As Boolean
        Get
            Return m_ValidaSeguroVidaDPVL
        End Get
        Set(ByVal Value As Boolean)
            m_ValidaSeguroVidaDPVL = Value
        End Set
    End Property

    Public Property EvitarInicioDia As Boolean
        Get
            Return m_EvitarInicioDia
        End Get
        Set(ByVal value As Boolean)
            m_EvitarInicioDia = value
        End Set
    End Property

    Public Property DiasQuincena As Integer
        Get
            Return m_DiasQuincena
        End Get
        Set(ByVal value As Integer)
            m_DiasQuincena = value
        End Set
    End Property

    Public Property ServidorS2credit As String
        Get
            Return m_ServidorS2Credit
        End Get
        Set(ByVal value As String)
            m_ServidorS2Credit = value
        End Set
    End Property

    Public Property PuertoS2Credit As String
        Get
            Return m_PuertoS2Credit
        End Get
        Set(ByVal value As String)
            m_PuertoS2Credit = value
        End Set
    End Property

#End Region

    Public Property PublicoGeneral As String
        Get
            Return m_PublicoGeneral
        End Get
        Set(value As String)
            m_PublicoGeneral = value
        End Set
    End Property

    Public Property DescuentoFijoNoCatalogo As Decimal
        Get
            Return m_DescuentoFijoNoCatalogo
        End Get
        Set(value As Decimal)
            m_DescuentoFijoNoCatalogo = value
        End Set
    End Property

    Public Property ServidorFTPCierre As String
        Get
            Return m_ServidorFTPCierre
        End Get
        Set(value As String)
            m_ServidorFTPCierre = value
        End Set
    End Property

    Public Property UsuarioFTPCierre As String
        Get
            Return m_UsuarioFTPCierre
        End Get
        Set(value As String)
            m_UsuarioFTPCierre = value
        End Set
    End Property

    Public Property PasswordFTPCierre As String
        Get
            Return m_PasswordFTPCierre
        End Get
        Set(value As String)
            m_PasswordFTPCierre = value
        End Set
    End Property

    Public Property TPVVirtual As String
        Get
            Return m_bTPVVirtual
        End Get
        Set(value As String)
            m_bTPVVirtual = value
        End Set
    End Property

    Public Property OrganizacionCompra As String
        Get
            Return m_OrganizacionCompra
        End Get
        Set(value As String)
            m_OrganizacionCompra = value
        End Set
    End Property

    Public Property CanalDistribucion As String
        Get
            Return m_CanalDistribucion
        End Get
        Set(value As String)
            m_CanalDistribucion = value
        End Set
    End Property

    Public Property Sector As String
        Get
            Return m_Sector
        End Get
        Set(value As String)
            m_Sector = value
        End Set
    End Property


    Public Property AplicaCrossSelling() As Boolean
        Get
            Return m_bAplicaCrossSelling
        End Get
        Set(ByVal Value As Boolean)
            m_bAplicaCrossSelling = Value
        End Set
    End Property

    Public Property PedirDatosPromoComienzo() As Boolean
        Get
            Return m_bPedirDatosPromoComienzo
        End Get
        Set(ByVal Value As Boolean)
            m_bPedirDatosPromoComienzo = Value
        End Set
    End Property

    Public Property DPKTPrioridadCodUso() As Boolean
        Get
            Return m_bDPKTPrioridadCodUso
        End Get
        Set(ByVal Value As Boolean)
            m_bDPKTPrioridadCodUso = Value
        End Set
    End Property

    Public Property DPKTCodUso() As String
        Get
            Return m_strDPKTCodUso
        End Get
        Set(ByVal Value As String)
            m_strDPKTCodUso = Value
        End Set
    End Property

    Public Property RutaIMG() As String
        Get
            Return m_strRutaIMG
        End Get
        Set(ByVal Value As String)
            m_strRutaIMG = Value
        End Set
    End Property

    Public Property UsuarioIMG() As String
        Get
            Return m_strUsuarioIMG
        End Get
        Set(ByVal Value As String)
            m_strUsuarioIMG = Value
        End Set
    End Property

    Public Property PasswordIMG() As String
        Get
            Return m_strPasswordIMG
        End Get
        Set(ByVal Value As String)
            m_strPasswordIMG = Value
        End Set
    End Property

    Public Property UnidadIMG() As String
        Get
            Return m_strUnidadIMG
        End Get
        Set(ByVal Value As String)
            m_strUnidadIMG = Value
        End Set
    End Property

    Public Property GuardarInServer() As Boolean
        Get
            Return m_bGuardarInServer
        End Get
        Set(ByVal Value As Boolean)
            m_bGuardarInServer = Value
        End Set
    End Property

    Public Property HuellaOpcional() As Boolean
        Get
            Return m_bHuellaOpcional
        End Get
        Set(ByVal Value As Boolean)
            m_bHuellaOpcional = Value
        End Set
    End Property

    Public Property RegistroPGOpcional() As Boolean
        Get
            Return m_bRegistroPGOpcional
        End Get
        Set(ByVal Value As Boolean)
            m_bRegistroPGOpcional = Value
        End Set
    End Property

    Public Property RegistroExpressPG() As Boolean
        Get
            Return m_bRegistroExpressPG
        End Get
        Set(ByVal Value As Boolean)
            m_bRegistroExpressPG = Value
        End Set
    End Property

    Public Property DireccionValidaEmail() As String
        Get
            Return m_strDireccionValidaEmail
        End Get
        Set(ByVal Value As String)
            m_strDireccionValidaEmail = Value
        End Set
    End Property

    Public Property DireccionImagenesEmail() As String
        Get
            Return m_strDireccionImagenesEmail
        End Get
        Set(ByVal Value As String)
            m_strDireccionImagenesEmail = Value
        End Set
    End Property

    Public Property TiempoEsperaDescargasNoche() As Integer
        Get
            Return m_intTiempoEsperaDescargas
        End Get
        Set(ByVal Value As Integer)
            m_intTiempoEsperaDescargas = Value
        End Set
    End Property

    Public Property ServerTraspasos() As String
        Get
            Return m_strServerTraspasos
        End Get
        Set(ByVal Value As String)
            m_strServerTraspasos = Value
        End Set
    End Property

    Public Property BaseDatosTraspasos() As String
        Get
            Return m_strBaseDatosTraspasos
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosTraspasos = Value
        End Set
    End Property

    Public Property UserTraspasos() As String
        Get
            Return m_strUserTraspasos
        End Get
        Set(ByVal Value As String)
            m_strUserTraspasos = Value
        End Set
    End Property

    Public Property PasswordTraspasos() As String
        Get
            Return m_strPasswordTraspasos
        End Get
        Set(ByVal Value As String)
            m_strPasswordTraspasos = Value
        End Set
    End Property

    Public Property RecibirPorBultos() As Boolean
        Get
            Return m_bRecibirPorBultos
        End Get
        Set(ByVal Value As Boolean)
            m_bRecibirPorBultos = Value
        End Set
    End Property

    Public Property RecibirParcialmente() As Boolean
        Get
            Return m_bRecibirParcialmente
        End Get
        Set(ByVal Value As Boolean)
            m_bRecibirParcialmente = Value
        End Set
    End Property

    Public Property CuentasCorreoErroresCDist() As String()
        Get
            Return m_strCuentasCorreoErroresCDist
        End Get
        Set(ByVal Value As String())
            m_strCuentasCorreoErroresCDist = Value
        End Set
    End Property

    Public Property TiempoRevisaPedidos() As Integer
        Get
            Return m_intTiempoRevisaPedidos
        End Get
        Set(ByVal Value As Integer)
            m_intTiempoRevisaPedidos = Value
        End Set
    End Property

    Public Property PromoSMS() As Boolean
        Get
            Return m_bPromoSMS
        End Get
        Set(ByVal Value As Boolean)
            m_bPromoSMS = Value
        End Set
    End Property

    Public Property SurtirEcommerce() As Boolean
        Get
            Return m_bSurtirEcommerce
        End Get
        Set(ByVal Value As Boolean)
            m_bSurtirEcommerce = Value
        End Set
    End Property

    Public Property ShowManagerPC() As Boolean
        Get
            Return m_bShowManagerPC
        End Get
        Set(ByVal Value As Boolean)
            m_bShowManagerPC = Value
        End Set
    End Property

    Public Property AplicaNewDescuentosDIPs() As Boolean
        Get
            Return m_bAplicaNewDescuentosDIPs
        End Get
        Set(ByVal Value As Boolean)
            m_bAplicaNewDescuentosDIPs = Value
        End Set
    End Property

    Public Property BloquearXTP() As Boolean
        Get
            Return m_bBloquearXTP
        End Get
        Set(ByVal Value As Boolean)
            m_bBloquearXTP = Value
        End Set
    End Property

    Public Property DiasParaBloquearTP() As Integer
        Get
            Return m_intDiasParaBloquearTP
        End Get
        Set(ByVal Value As Integer)
            m_intDiasParaBloquearTP = Value
        End Set
    End Property

    Public Property NoCuentaDHL() As String
        Get
            Return m_strNoCuentaDHL
        End Get
        Set(ByVal Value As String)
            m_strNoCuentaDHL = Value
        End Set
    End Property

    Public Property CuentaCLABE_DHL() As String
        Get
            Return m_strCuentaCLABE_DHL
        End Get
        Set(ByVal Value As String)
            m_strCuentaCLABE_DHL = Value
        End Set
    End Property

    Public Property ExtensionDHL() As String
        Get
            Return m_strExtensionDHL
        End Get
        Set(ByVal Value As String)
            m_strExtensionDHL = Value
        End Set
    End Property

    Public Property InternetServer() As String
        Get
            Return m_strInternetServer
        End Get
        Set(ByVal Value As String)
            m_strInternetServer = Value
        End Set
    End Property

    Public Property ServidorHTTPS() As String
        Get
            Return m_strServidorHTTPS
        End Get
        Set(ByVal Value As String)
            m_strServidorHTTPS = Value
        End Set
    End Property

    Public Property DiasParaSurtirEC() As Integer
        Get
            Return m_intDiasParaSurtirEC
        End Get
        Set(ByVal Value As Integer)
            m_intDiasParaSurtirEC = Value
        End Set
    End Property

    Public Property DiasParaFacturarEC() As Integer
        Get
            Return m_intDiasParaFacturarEC
        End Get
        Set(ByVal Value As Integer)
            m_intDiasParaFacturarEC = Value
        End Set
    End Property

    Public Property DiasParaFacturarConcenEC() As Integer
        Get
            Return m_intDiasParaFacturarConcenEC
        End Get
        Set(ByVal Value As Integer)
            m_intDiasParaFacturarConcenEC = Value
        End Set
    End Property

    Public Property DiasParaEnviarEC() As Integer
        Get
            Return m_intDiasParaEnviarEC
        End Get
        Set(ByVal Value As Integer)
            m_intDiasParaEnviarEC = Value
        End Set
    End Property

    Public Property UserProxy() As String
        Get
            Return m_strUserProxy
        End Get
        Set(ByVal Value As String)
            m_strUserProxy = Value
        End Set
    End Property

    Public Property PasswordProxy() As String
        Get
            Return m_strPasswordProxy
        End Get
        Set(ByVal Value As String)
            m_strPasswordProxy = Value
        End Set
    End Property

    Public Property ImprimirEtiquetasEnLaser() As Boolean
        Get
            Return m_bImprimirEtiquetasEnLaser
        End Get
        Set(ByVal Value As Boolean)
            m_bImprimirEtiquetasEnLaser = Value
        End Set
    End Property

    Public Property TraspasosSalidaXDia() As Integer
        Get
            Return m_intTraspasosSalidaXDia
        End Get
        Set(ByVal Value As Integer)
            m_intTraspasosSalidaXDia = Value
        End Set
    End Property

    Public Property PzasTotalesTS() As Integer
        Get
            Return m_intPzasTotalesTS
        End Get
        Set(ByVal Value As Integer)
            m_intPzasTotalesTS = Value
        End Set
    End Property

    Public Property SoloMismaPlazaTS() As Boolean
        Get
            Return m_bSoloMismaPlazaTS
        End Get
        Set(ByVal Value As Boolean)
            m_bSoloMismaPlazaTS = Value
        End Set
    End Property

    Public Property MailGerentePlaza() As String
        Get
            Return m_strMailGerentePlaza
        End Get
        Set(ByVal Value As String)
            m_strMailGerentePlaza = Value
        End Set
    End Property

    Public Property MailGerenteOperaciones() As String
        Get
            Return m_strMailGerenteOperaciones
        End Get
        Set(ByVal Value As String)
            m_strMailGerenteOperaciones = Value
        End Set
    End Property

    Public Property CuentasCorreoLogistica() As String()
        Get
            Return m_strMailsLogistica
        End Get
        Set(ByVal Value As String())
            m_strMailsLogistica = Value
        End Set
    End Property

    Public Property MailGerenteRegional() As String
        Get
            Return m_strMailGerenteRegional
        End Get
        Set(ByVal Value As String)
            m_strMailGerenteRegional = Value
        End Set
    End Property

    Public Property ImagenFondoURL() As String
        Get
            Return m_strImagenFondoURL
        End Get
        Set(ByVal Value As String)
            m_strImagenFondoURL = Value
        End Set
    End Property

    Public Property ServerSQLBroker() As String
        Get
            Return m_strServerSQLBroker
        End Get
        Set(ByVal Value As String)
            m_strServerSQLBroker = Value
        End Set
    End Property

    Public Property GenerarGuiaDHLAutomatica() As Boolean
        Get
            Return m_bGenerarGuiaDHLAutomatica
        End Get
        Set(ByVal Value As Boolean)
            m_bGenerarGuiaDHLAutomatica = Value
        End Set
    End Property

    Public Property SeleccionaServidorHTTPS() As Boolean
        Get
            Return m_bServidorHTTPS
        End Get
        Set(ByVal Value As Boolean)
            m_bServidorHTTPS = Value
        End Set
    End Property

    Public Property PuertoBroker() As Long
        Get
            Return m_lngPuertoBroker
        End Get
        Set(ByVal Value As Long)
            m_lngPuertoBroker = Value
        End Set
    End Property

    Public Property ServerBroker() As String
        Get
            Return m_strServerBroker
        End Get
        Set(ByVal Value As String)
            m_strServerBroker = Value
        End Set
    End Property

    Public Property BaseDatosBroker() As String
        Get
            Return m_strBaseDatosBroker
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosBroker = Value
        End Set
    End Property

    Public Property UserBroker() As String
        Get
            Return m_strUserBroker
        End Get
        Set(ByVal Value As String)
            m_strUserBroker = Value
        End Set
    End Property

    Public Property PasswordBroker() As String
        Get
            Return m_strPasswordBroker
        End Get
        Set(ByVal Value As String)
            m_strPasswordBroker = Value
        End Set
    End Property

    Public Property MaxDescApartados() As Decimal
        Get
            Return m_decMaxDescApartados
        End Get
        Set(ByVal Value As Decimal)
            m_decMaxDescApartados = Value
        End Set
    End Property

    Public Property NuevaRegla2x1yMedio() As Boolean
        Get
            Return m_bNuevaRegla2x1yMedio
        End Get
        Set(ByVal Value As Boolean)
            m_bNuevaRegla2x1yMedio = Value
        End Set
    End Property

    Public Property BorrarPreciosCierre() As Boolean
        Get
            Return m_bBorrarPreciosCierre
        End Get
        Set(ByVal Value As Boolean)
            m_bBorrarPreciosCierre = Value
        End Set
    End Property

    Public Property CompreAhoraPDOpcional() As Boolean
        Get
            Return m_bCompreAhoraPDOpcional
        End Get
        Set(ByVal Value As Boolean)
            m_bCompreAhoraPDOpcional = Value
        End Set
    End Property

    Public Property NuevaRegla20y30() As Boolean
        Get
            Return m_bNuevaRegla20y30
        End Get
        Set(ByVal Value As Boolean)
            m_bNuevaRegla20y30 = Value
        End Set
    End Property

    Public Property RutaFTPDHL() As String
        Get
            Return m_strRutaFTPDHL
        End Get
        Set(ByVal Value As String)
            m_strRutaFTPDHL = Value
        End Set
    End Property

    Public Property UserFTPBroker() As String
        Get
            Return m_strUserFTPBroker
        End Get
        Set(ByVal Value As String)
            m_strUserFTPBroker = Value
        End Set
    End Property

    Public Property PasswordFTPBroker() As String
        Get
            Return m_strPasswordFTPBroker
        End Get
        Set(ByVal Value As String)
            m_strPasswordFTPBroker = Value
        End Set
    End Property


    Public Property TraspasoEntradaLectora() As Boolean
        Get
            Return m_bTraspasoEntradaLectora
        End Get
        Set(ByVal Value As Boolean)
            m_bTraspasoEntradaLectora = Value
        End Set
    End Property

    Public Property NombreLectoraTE() As String
        Get
            Return m_strNombreLectoraTE
        End Get
        Set(ByVal Value As String)
            m_strNombreLectoraTE = Value
        End Set
    End Property

    Public Property NombreArchivoLectoraTE() As String
        Get
            Return m_strNombreArchivoLectoraTE
        End Get
        Set(ByVal Value As String)
            m_strNombreArchivoLectoraTE = Value
        End Set
    End Property

    Public Property EmparejarMayorPrecio2x1() As Boolean
        Get
            Return m_bEmparejarMayorPrecio2x1
        End Get
        Set(ByVal Value As Boolean)
            m_bEmparejarMayorPrecio2x1 = Value
        End Set
    End Property

    Public Property AuditoriaLectoraCS3070() As Boolean
        Get
            Return m_bAuditoriaLectoraCS3070
        End Get
        Set(ByVal Value As Boolean)
            m_bAuditoriaLectoraCS3070 = Value
        End Set
    End Property

    Public Property ImporteMaximoDPVale() As Decimal
        Get
            Return m_decImporteMaximoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decImporteMaximoDPVale = Value
        End Set
    End Property

    Public Property GenerarReRevale() As Boolean
        Get
            Return m_bGenerarReRevale
        End Get
        Set(ByVal Value As Boolean)
            m_bGenerarReRevale = Value
        End Set
    End Property

    Public Property NotaOtrosPagosEC() As String
        Get
            Return m_strNotaOtrosPagosEC
        End Get
        Set(ByVal Value As String)
            m_strNotaOtrosPagosEC = Value
        End Set
    End Property

    Public Property RecibirOtrosPagos() As Boolean
        Get
            Return m_bRecibirOtrosPagos
        End Get
        Set(ByVal Value As Boolean)
            m_bRecibirOtrosPagos = Value
        End Set
    End Property

    Public Property DiasRecibirPagosEC() As Integer
        Get
            Return m_intDiasRecibirPagosEC
        End Get
        Set(ByVal Value As Integer)
            m_intDiasRecibirPagosEC = Value
        End Set
    End Property

    Public Property MostrarConcenAUD() As Boolean
        Get
            Return m_bMostrarConcenAUD
        End Get
        Set(ByVal Value As Boolean)
            m_bMostrarConcenAUD = Value
        End Set
    End Property

    Public Property ClienteEC() As String
        Get
            Return m_strClienteEC
        End Get
        Set(ByVal Value As String)
            m_strClienteEC = Value
        End Set
    End Property

    Public Property CuentasCorreoEC() As String()
        Get
            Return m_strMailsEC
        End Get
        Set(ByVal Value As String())
            m_strMailsEC = Value
        End Set
    End Property

    Public Property AplicaDPCard() As Boolean
        Get
            Return m_bAplicaDPCard
        End Get
        Set(ByVal Value As Boolean)
            m_bAplicaDPCard = Value
        End Set
    End Property

    Public Property ConsecutivoPOS() As String
        Get
            Return m_strConsecutivoPOS
        End Get
        Set(ByVal Value As String)
            m_strConsecutivoPOS = Value
        End Set
    End Property

    Public Property ConsecutivoPuntosPOS As String
        Get
            Return m_ConsecutivoPuntosPOS
        End Get
        Set(value As String)
            m_ConsecutivoPuntosPOS = value
        End Set
    End Property

    Public Property ImporteMaximoElectronicosDPVale() As Decimal
        Get
            Return m_decImporteMaximoElectronicosDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decImporteMaximoElectronicosDPVale = Value
        End Set
    End Property

    Public Property ServerDPCard() As String
        Get
            Return m_strServerDPCard
        End Get
        Set(ByVal Value As String)
            m_strServerDPCard = Value
        End Set
    End Property

    Public Property BaseDatosDPCard() As String
        Get
            Return m_strBaseDatosDPCard
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosDPCard = Value
        End Set
    End Property

    Public Property UserDPCard() As String
        Get
            Return m_strUserDPCard
        End Get
        Set(ByVal Value As String)
            m_strUserDPCard = Value
        End Set
    End Property

    Public Property PasswordDPCard() As String
        Get
            Return m_strPasswordDPCard
        End Get
        Set(ByVal Value As String)
            m_strPasswordDPCard = Value
        End Set
    End Property

    Public Property ServerDPValeAIO() As String
        Get
            Return m_strServerDPValeAIO
        End Get
        Set(ByVal Value As String)
            m_strServerDPValeAIO = Value
        End Set
    End Property

    Public Property BaseDatosDPValeAIO() As String
        Get
            Return m_strBaseDatosDPValeAIO
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosDPValeAIO = Value
        End Set
    End Property

    Public Property UserDPValeAIO() As String
        Get
            Return m_strUserDPValeAIO
        End Get
        Set(ByVal Value As String)
            m_strUserDPValeAIO = Value
        End Set
    End Property

    Public Property PasswordDPValeAIO() As String
        Get
            Return m_strPasswordDPValeAIO
        End Get
        Set(ByVal Value As String)
            m_strPasswordDPValeAIO = Value
        End Set
    End Property

    Public Property GenerarSeguro() As Boolean
        Get
            Return m_bGenerarSeguro
        End Get
        Set(ByVal Value As Boolean)
            m_bGenerarSeguro = Value
        End Set
    End Property

    Public Property ServerDPVF() As String
        Get
            Return m_strServerDPVF
        End Get
        Set(ByVal Value As String)
            m_strServerDPVF = Value
        End Set
    End Property

    Public Property BaseDatosDPVF() As String
        Get
            Return m_strBaseDatosDPVF
        End Get
        Set(ByVal Value As String)
            m_strBaseDatosDPVF = Value
        End Set
    End Property

    Public Property UserDPVF() As String
        Get
            Return m_strUserDPVF
        End Get
        Set(ByVal Value As String)
            m_strUserDPVF = Value
        End Set
    End Property

    Public Property PasswordDPVF() As String
        Get
            Return m_strPasswordDPVF
        End Get
        Set(ByVal Value As String)
            m_strPasswordDPVF = Value
        End Set
    End Property

    'CancelarPagosDPCard

    Public Property CancelarPagosDPCard() As Boolean
        Get
            Return m_bCancelarPagosDPCard
        End Get
        Set(ByVal Value As Boolean)
            m_bCancelarPagosDPCard = Value
        End Set
    End Property

    Public Property ServerBrokerNew() As String
        Get
            Return m_strServerBrokerNew
        End Get
        Set(ByVal Value As String)
            m_strServerBrokerNew = Value
        End Set
    End Property

    Public Property PuertoBrokerNew() As Long
        Get
            Return m_strPuertoBrokerNew
        End Get
        Set(ByVal Value As Long)
            m_strPuertoBrokerNew = Value
        End Set
    End Property

    Public Property VentaAsistida() As Boolean
        Get
            Return m_VentaAsistida
        End Get
        Set(ByVal Value As Boolean)
            m_VentaAsistida = Value
        End Set
    End Property

    Public Property AjusteAutomatico() As Boolean
        Get
            Return m_AjusteAutomatico
        End Get
        Set(ByVal Value As Boolean)
            m_AjusteAutomatico = Value
        End Set
    End Property
    Public Property ValidaDatosDPVL() As Boolean
        Get
            Return m_bValidaDatosDPVL
        End Get
        Set(ByVal Value As Boolean)
            m_bValidaDatosDPVL = Value
        End Set
    End Property

    Public Property EjecutarLiveUpdateInicio() As Boolean
        Get
            Return m_bEjecutarLiveUpdateInicio
        End Get
        Set(ByVal Value As Boolean)
            m_bEjecutarLiveUpdateInicio = Value
        End Set
    End Property

    Public Property FacturacionNueva() As Boolean
        Get
            Return m_bFacturacionNueva
        End Get
        Set(ByVal Value As Boolean)
            m_bFacturacionNueva = Value
        End Set
    End Property

    Public Property HabilitarDPTicket As Boolean
        Get
            Return m_HabilitarDPTicket
        End Get
        Set(value As Boolean)
            m_HabilitarDPTicket = value
        End Set
    End Property

    Public Property ActivarToka As Boolean
        Get
            Return m_ActivarToka
        End Get
        Set(ByVal value As Boolean)
            m_ActivarToka = value
        End Set
    End Property

    Public Property ComisionBancoToka As Decimal
        Get
            Return m_ComisionBancoToka
        End Get
        Set(ByVal value As Decimal)
            m_ComisionBancoToka = value
        End Set
    End Property


#Region "Propiedades S2Credit"

    'Public Property AplicaS2Credit() As Boolean
    '    Get
    '        Return m_bolAplicaS2Credit
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_bolAplicaS2Credit = Value
    '    End Set
    'End Property

    Public Property AplicarS2Credit() As Boolean
        Get
            Return m_bolAplicarS2Credit
        End Get
        Set(ByVal Value As Boolean)
            m_bolAplicarS2Credit = Value
        End Set
    End Property

    Public Property AplicarParaleroS2CSAP() As Boolean
        Get
            Return m_bolAplicarParaleroS2CSAP
        End Get
        Set(ByVal Value As Boolean)
            m_bolAplicarParaleroS2CSAP = Value
        End Set
    End Property

#End Region

#Region "Propiedades Promoción Buen Fin 07/11/2013"
    Public Property LimiteArticulosEmpleados() As Integer
        Get
            Return m_limitediasempleado
        End Get
        Set(ByVal Value As Integer)
            m_limitediasempleado = Value
        End Set
    End Property

    Public Property PromocionEmpleado() As Boolean
        Get
            Return m_promocionempleado
        End Get
        Set(ByVal Value As Boolean)
            m_promocionempleado = Value
        End Set
    End Property

    Public Property MiniprinterTermica() As Boolean
        Get
            Return m_bMiniprinterTermica
        End Get
        Set(ByVal Value As Boolean)
            m_bMiniprinterTermica = Value
        End Set
    End Property

    Public Property EtiquetaPrecioDP() As Boolean
        Get
            Return m_bEtiquetaDP
        End Get
        Set(ByVal Value As Boolean)
            m_bEtiquetaDP = Value
        End Set
    End Property

    Public Property EtiquetaPrecioFactory() As Boolean
        Get
            Return m_bEtiquetaPrecioFactory
        End Get
        Set(ByVal Value As Boolean)
            m_bEtiquetaPrecioFactory = Value
        End Set
    End Property

    Public Property MotivosRechazoDPVL() As Boolean
        Get
            Return m_bMotivosRechazoDPVL
        End Get
        Set(ByVal Value As Boolean)
            m_bMotivosRechazoDPVL = Value
        End Set
    End Property
#End Region

#Region "Propiedades Proyecto Si Hay"
    '----------------------------------------------------------------
    'JNAVA (09/05/2013) - Configuracion de Concretar Citas "Si Hay"
    '----------------------------------------------------------------
    Public Property DiasRecogerReembolsoSH() As Integer
        Get
            Return m_intDiasRecogerReembolsoSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasRecogerReembolsoSH = Value
        End Set
    End Property

    Public Property DiasPostergarCitaSH() As Integer
        Get
            Return m_intDiasPostergarCitaSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasPostergarCitaSH = Value
        End Set
    End Property

    '----------------------------------------------------------------
    'JNAVA (10/06/2013) - Configuracion "Si Hay"
    '----------------------------------------------------------------
    Public Property DevolverEfectivoSH() As Boolean
        Get
            Return m_DevolverEfectivoSH
        End Get
        Set(ByVal Value As Boolean)
            m_DevolverEfectivoSH = Value
        End Set
    End Property


    Public Property DiasSurtirSH() As Integer
        Get
            Return m_intDiasSurtirSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasSurtirSH = Value
        End Set
    End Property

    Public Property DiasSinGuiaSH() As Integer
        Get
            Return m_intDiasSinGuiaSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasSinGuiaSH = Value
        End Set
    End Property

    Public Property DiasRecibirSH() As Integer
        Get
            Return m_intDiasRecibirSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasRecibirSH = Value
        End Set
    End Property


    Public Property DiasFacturarSH() As Integer
        Get
            Return m_intDiasFacturarSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasFacturarSH = Value
        End Set
    End Property

    Public Property DiasCancelarSH() As Integer
        Get
            Return m_intDiasCancelarSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasCancelarSH = Value
        End Set
    End Property

    Public Property DiasInsurtiblesSH() As Integer
        Get
            Return m_intDiasInsurtiblesSH
        End Get
        Set(ByVal Value As Integer)
            m_intDiasInsurtiblesSH = Value
        End Set
    End Property


    Public Property ValidaCierreSH() As Boolean
        Get
            Return m_bValidaCierreSH
        End Get
        Set(ByVal Value As Boolean)
            m_bValidaCierreSH = Value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/10/2014: Configuracion DPVale Si Hay
    '-------------------------------------------------------------------------------------------------------------------

    Public Property DPValeSiHay() As Boolean
        Get
            Return m_SiHayDPVale
        End Get
        Set(ByVal Value As Boolean)
            m_SiHayDPVale = Value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (20.07.2015): Config para permitir arituculos de catalogo en Si Hay
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property ArticuloCatalogoSH() As Boolean
        Get
            Return m_bArticuloCatalogoSH
        End Get
        Set(ByVal Value As Boolean)
            m_bArticuloCatalogoSH = Value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (24.07.2015): Config para permitir la recepcion de mercancia en tiendas de proveedor
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property RecepcionMercanciaTndas() As Boolean
        Get
            Return m_bRecepcionMercanciaTndas
        End Get
        Set(ByVal Value As Boolean)
            m_bRecepcionMercanciaTndas = Value
        End Set
    End Property

    '-------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (22.03.2017): Config para permitir articulos de sin existencia en Si Hay
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property TodosArticulosSH() As Boolean
        Get
            Return m_bArticuloSinExistenciaSH
        End Get
        Set(ByVal Value As Boolean)
            m_bArticuloSinExistenciaSH = Value
        End Set
    End Property


    '-------------------------------------------------------------------------------------------------------------------------------
    ' MLVARGAS (20.05.2022): Configuración para activar la validación de materiales extendidos
    '-------------------------------------------------------------------------------------------------------------------------------
    Public Property ValidarMaterialesExtendidos() As Boolean
        Get
            Return m_bMaterialesExtendidos
        End Get
        Set(ByVal Value As Boolean)
            m_bMaterialesExtendidos = Value
        End Set
    End Property


#End Region

#Region "Cupon con todos los descuentos 25/02/2014"
    Public Property CuponDescuentos() As Boolean
        Get
            Return m_cuponDescuentos
        End Get
        Set(ByVal Value As Boolean)
            m_cuponDescuentos = Value
        End Set
    End Property
#End Region

#Region "Propiedades Servicios REST"

    Public Property ServidorREST() As String
        Get
            Return m_strServidorREST
        End Get
        Set(ByVal Value As String)
            m_strServidorREST = Value
        End Set
    End Property

    Public Property PuertoREST() As Long
        Get
            Return m_strPuertoREST
        End Get
        Set(ByVal Value As Long)
            m_strPuertoREST = Value
        End Set
    End Property

    Public Property GenerarLogTransacciones() As Boolean
        Get
            Return m_GenerarLogTransacciones
        End Get
        Set(ByVal Value As Boolean)
            m_GenerarLogTransacciones = Value
        End Set
    End Property

    Public Property EnviarCorreoLentitud() As Boolean
        Get
            Return m_EnviarCorreoLentitud
        End Get
        Set(ByVal Value As Boolean)
            m_EnviarCorreoLentitud = Value
        End Set
    End Property

    Public Property LimiteTiempoLentitud() As Integer
        Get
            Return m_LimiteTiempoLentitud
        End Get
        Set(ByVal Value As Integer)
            m_LimiteTiempoLentitud = Value
        End Set
    End Property

    Public Property MailLentitud() As String()
        Get
            Return m_MailsLentitud
        End Get
        Set(ByVal Value As String())
            m_MailsLentitud = Value
        End Set
    End Property

    Public Property PaginaDportenis() As String
        Get
            Return m_strPaginaDportenis
        End Get
        Set(ByVal Value As String)
            m_strPaginaDportenis = Value
        End Set
    End Property

    Public Property PaginaDpStreet() As String
        Get
            Return m_strPaginaDpStreet
        End Get
        Set(ByVal Value As String)
            m_strPaginaDpStreet = Value
        End Set
    End Property

#End Region

#Region "Propiedades DPCard Puntos"
    'Inicio JEMO DPCard 16/11/2016------------------------------------------ 
    'Public Property ActivarRegistroDPCard() As Boolean
    '    Get
    '        Return m_ActivarRegistroDPCard
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_ActivarRegistroDPCard = Value
    '    End Set
    'End Property
    Public Property UrlRegistroDPCard() As String
        Get
            Return m_UrlRegistroDPCard
        End Get
        Set(ByVal Value As String)
            m_UrlRegistroDPCard = Value
        End Set
    End Property
    'Fin JEMO DPCard 16/11/2016------------------------------------------

    Public Property RegistroApprova() As Boolean
        Get
            Return m_RegistroApprova
        End Get
        Set(ByVal Value As Boolean)
            m_RegistroApprova = Value
        End Set
    End Property

#End Region

#Region "Propiedades Liberar RAM"
    Dim b_FreeRAM As Boolean = True
    Public Property FreeRAM() As Boolean
        Get
            Return b_FreeRAM
        End Get
        Set(ByVal Value As Boolean)
            b_FreeRAM = Value
        End Set
    End Property

    Dim b_TimeFreeRAM As Decimal = 5.0
    Public Property TimeFreeRAM() As Decimal
        Get
            Return b_TimeFreeRAM
        End Get
        Set(ByVal Value As Decimal)
            b_TimeFreeRAM = Value
        End Set
    End Property
#End Region

#Region "Propiedades DPVFinanciero Almacenes"

    Public Property ServidorFinanciero As String
        Get
            Return m_ServidorFinanciero
        End Get
        Set(value As String)
            m_ServidorFinanciero = value
        End Set
    End Property

    Public Property BaseFinanciero As String
        Get
            Return m_BaseFinanciero
        End Get
        Set(value As String)
            m_BaseFinanciero = value
        End Set
    End Property

    Public Property UsuarioFinanciero As String
        Get
            Return m_UsuarioFinanciero
        End Get
        Set(value As String)
            m_UsuarioFinanciero = value
        End Set
    End Property

    Public Property PasswordFinanciero As String
        Get
            Return m_PasswordFinanciero
        End Get
        Set(value As String)
            m_PasswordFinanciero = value
        End Set
    End Property

    Public Property MigracionFinanciero As Boolean
        Get
            Return m_MigracionFinanciero
        End Get
        Set(value As Boolean)
            m_MigracionFinanciero = value
        End Set
    End Property

#End Region

#Region "Propiedades DatosEcomm"
    Public Property BaseDatosDatosEcomm As String
        Get
            Return m_strBaseDatosDatosEcomm
        End Get
        Set(value As String)
            m_strBaseDatosDatosEcomm = value
        End Set
    End Property

    Public Property ServerDatosEcomm As String
        Get
            Return m_strServerDatosEcomm
        End Get
        Set(value As String)
            m_strServerDatosEcomm = value
        End Set
    End Property

    Public Property UserDatosEcomm As String
        Get
            Return m_strUserDatosEcomm
        End Get
        Set(value As String)
            m_strUserDatosEcomm = value
        End Set
    End Property

    Public Property PasswordDatosEcomm As String
        Get
            Return m_strPasswordDatosEcomm
        End Get
        Set(value As String)
            m_strPasswordDatosEcomm = value
        End Set
    End Property

    Public Property ServicioEcomm As String
        Get
            Return m_strServicioEcomm
        End Get
        Set(value As String)
            m_strServicioEcomm = value
        End Set
    End Property

    Public Property ImpresoraEcommerce As String
        Get
            Return m_ImpresoraEcommerce
        End Get
        Set(value As String)
            m_ImpresoraEcommerce = value
        End Set
    End Property
    'Asanchez 26/03/2021 Configuración de los servicios que usara Blue
    Public Property ServiciosBlueBonificacion As Boolean
        Get
            Return m_strServiciosBlue
        End Get
        Set(value As Boolean)
            m_strServiciosBlue = value
        End Set
    End Property
    'Asanchez 26/03/2021 Configuración de los servicios que usara Blue
    Public Property ServerBlue As String
        Get
            Return m_strServerBlue
        End Get
        Set(value As String)
            m_strServerBlue = value
        End Set
    End Property
    Public Property BaseDatosDBlue As String
        Get
            Return m_strBaseDatosBlue
        End Get
        Set(value As String)
            m_strBaseDatosBlue = value
        End Set
    End Property
    Public Property UserBlue As String
        Get
            Return m_strUserblue
        End Get
        Set(value As String)
            m_strUserblue = value
        End Set
    End Property
    Public Property PassBlue As String
        Get
            Return m_strPasswordblue
        End Get
        Set(value As String)
            m_strPasswordblue = value
        End Set
    End Property
    Public Property UsrTokenBlue As String
        Get
            Return m_usr_token_blue
        End Get
        Set(value As String)
            m_usr_token_blue = value
        End Set
    End Property
    'ASANCHEZ se agrego ServerLealtad
    Public Property ServerLealtad As String
        Get
            Return m_strServerLealtad
        End Get
        Set(value As String)
            m_strServerLealtad = value
        End Set
    End Property
    Public Property PuertoLealtad() As Long
        Get
            Return m_lngPuertoLealtad
        End Get
        Set(ByVal Value As Long)
            m_lngPuertoLealtad = Value
        End Set
    End Property
#End Region

End Class
