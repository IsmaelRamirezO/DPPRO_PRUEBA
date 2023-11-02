Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Collections.Generic

Public Class FacturaManager

    Dim oApplicationContext As ApplicationContext
    Dim oConfigCierre As ConfigSaveArchivos.SaveConfigArchivos
    Private oFacturaDG As FacturaDataGateway

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Public ReadOnly Property ConfigCierreFI() As ConfigSaveArchivos.SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal oConfig As ConfigSaveArchivos.SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext
        oConfigCierre = oConfig
        oFacturaDG = New FacturaDataGateway(Me)

    End Sub

#End Region

#Region "Main Methods"

    Public Function Create() As Factura

        Dim oNuevoFactura As Factura
        oNuevoFactura = New Factura(Me)

        Return oNuevoFactura

    End Function

    Public Sub Load(ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.SelectByFolio(FolioFactura, CodCaja, oFactura)

        oFacturaDG = Nothing

    End Sub

    ''' <summary>
    ''' Función para obtener los datos de una factura en base a al valor de la columna Referencia
    ''' </summary>
    ''' <param name="ReferenciaFactura">Referencia a buscar</param>
    ''' <param name="CodCaja">Código de caja</param>
    ''' <param name="Factura">Datos de la factura resultado</param>
    ''' <remarks></remarks>
    Public Sub SelectByReferencia(ByVal ReferenciaFactura As String, ByVal CodCaja As String, ByVal Factura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.SelectByReferencia(ReferenciaFactura, CodCaja, Factura)

        oFacturaDG = Nothing

    End Sub

    Public Sub LoadInto(ByVal FacturaID As Integer, ByRef oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.Select(FacturaID, oFactura)

        oFacturaDG = Nothing

    End Sub

    Public Function GetMontoPago(ByVal FacturaID As Integer, ByVal DPVale As Boolean) As Double
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        Return oFacturaDG.GetMontoPago(FacturaID, DPVale)

    End Function

    Public Sub LoadInto(ByVal FolioSAP As String, ByRef oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.Select(FolioSAP, oFactura)

        oFacturaDG = Nothing

    End Sub

    Public Function LoadFacturaToReport(ByVal FacturaID As Integer) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        LoadFacturaToReport = oFacturaDG.SelectFacturaToReport(FacturaID)

        oFacturaDG = Nothing

    End Function
    Public Sub UpdateFolioSAP(ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.UpdateFolioSAP(oFactura)

        oFacturaDG = Nothing

    End Sub


    Public Sub Save(ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.Insert(oFactura)

        oFacturaDG = Nothing

    End Sub

    Public Sub SaveMotivo(ByVal strFacturaID As Integer, ByVal strTienda As String, ByVal strArticulo As String, _
    ByVal strTalla As String, ByVal intIdMotivo As Integer, ByVal strTipoMovto As String)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertMotivo(strFacturaID, strTienda, strArticulo, strTalla, intIdMotivo, strTipoMovto)

        oFacturaDG = Nothing

    End Sub
    Public Function SaveCatalogoMotivo(ByVal strdescripcion As String, ByVal shrtStatus As Short, ByVal datFecha As Date) As Boolean

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.InsertCatalogoMotivo(strdescripcion, shrtStatus, datFecha)

        oFacturaDG = Nothing

    End Function

    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean, ByVal CodCaja As String) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.Select(EnabledRecordsOnly, CodCaja)

        oFacturaDG = Nothing

    End Function

    Public Function GetAllUsersRoles() As DataSet

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectUsersRoles()

        oFacturaDG = Nothing

    End Function

    Public Function GetVentasPGSinEnviar(ByVal Tipo As Integer) As DataTable

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectVentasPGSinEnviar(Tipo)

    End Function

    Public Function GetRazonesRechazo(ByRef bResult As Boolean, ByVal Modulo As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectRazonesRechazo(bResult, Modulo)

    End Function

    Public Function GetNumeroFacilito(ByVal intFolioID As Integer) As String

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.GetNumeroFacilito(intFolioID)

        oFacturaDG = Nothing

    End Function

    Public Function GetDPVALEID(ByVal intFacturaID As Integer, Optional ByVal PedidoID As Integer = 0) As String

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDpValeId(intFacturaID, PedidoID)

        oFacturaDG = Nothing

    End Function

    Public Function GetFIDEVByValeCajaID(ByVal intValeCajaId As Integer) As String

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFIDEVByValeCajaId(intValeCajaId)

        oFacturaDG = Nothing

    End Function

    Public Function Getmotivos() As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.MotivosFacSel()

        oFacturaDG = Nothing

    End Function

    Public Function SelectFacturasCDT(ByVal ClienteID As String, ByVal band As Boolean) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFacturasCDT(ClienteID, band)

        oFacturaDG = Nothing

    End Function

    Public Function SelectMotivosFac(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal strTipoMovto As String) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectMotivosFac(datFechaIni, datFechaFin, strTipoMovto)

        oFacturaDG = Nothing

    End Function

    Public Function SelectFacturasEdoCuentaCDTAll(ByVal ClienteID As String) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFacturasEdoCuentaCDTAll(ClienteID)

        oFacturaDG = Nothing

    End Function

    Public Function SelectFacturaEdoCuentaCDT(ByVal FolioFactura As Integer) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFacturaEdoCuentaCDT(FolioFactura)

        oFacturaDG = Nothing

    End Function


    Public Function SelectFacturaClienteID(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, Optional ByVal ClienteID As String = "", Optional ByVal CodTipoVenta As String = "")
        'Si ClienteID ="" Obtendra de Todos Los Clientes.
        'Si CodTipoVenta="" Obtendre Todos los Tipos de Ventas.

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFacturaClienteID(FechaInicio, FechaFin, ClienteID, CodTipoVenta)

        oFacturaDG = Nothing
    End Function

    Public Function SelectFolioCaja(ByVal FolioSAP As String) As DataSet
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFolioCaja(FolioSAP)

        oFacturaDG = Nothing
    End Function

#End Region

#Region "Extended Methods"

    Public Function GetConfigFromServer() As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectConfigFromServer

        oFacturaDG = Nothing

    End Function

    Public Function GetCondigosBajaCalidad(ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal TipoDoc As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectCodigosBajaCalidad(FolioFactura, CodCaja, TipoDoc)

        oFacturaDG = Nothing

    End Function

    Public Function GetArtAclaracion(ByVal CodArticulo As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectArticulosAclaracion(CodArticulo)

        oFacturaDG = Nothing

    End Function

    Public Sub SaveCodigoBajaCalidad(ByVal Codigo As String, ByVal Talla As String, ByVal Cantidad As Integer, ByVal Motivo As String, ByVal FolioFactura As String, _
    ByVal CodCaja As String, ByVal TipoDoc As String)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.InsertCodigoBajaCalidad(Codigo, Talla, Cantidad, Motivo, FolioFactura, CodCaja, TipoDoc)

        oFacturaDG = Nothing

    End Sub


    Public Sub SaveBajaCalidad(ByVal dtArticulos As DataTable)

        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.InsertBajaCalidad(dtArticulos)
        oFacturaDG = Nothing

    End Sub

    Public Sub DesmarcaBajaCalidad(ByVal dtArticulos As DataTable)

        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.DesmarcaBajaCalidad(dtArticulos)
        oFacturaDG = Nothing

    End Sub

    Public Function BajaCalidadSel() As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.BajaCalidadSel()

    End Function


    Public Sub BorrarCodigosBajaCalidad(ByVal FolioFactura As Integer, ByVal CodCaja As String, ByVal TipoDoc As String)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.DeleteCodigosBajaCalidad(FolioFactura, CodCaja, TipoDoc)

        oFacturaDG = Nothing

    End Sub

    Public Function SaveConfigInServer(ByVal Parametro As String, ByVal Valor As String, ByVal Tipo As Integer, ByVal EsPassword As Boolean, ByVal Actualizar As Boolean) As String

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.InsertConfigInServer(Parametro, Valor, Tipo, EsPassword, Actualizar)

    End Function

    Public Sub SaveValeEmpleado(ByVal Folio As Integer, ByVal Serie As String, ByVal FacturaID As Integer)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.InsertValeEmpleado(Folio, Serie, FacturaID)

    End Sub

    Public Sub SaveValeEmpleadoPedido(ByVal Folio As Integer, ByVal Serie As String, ByVal PedidoId As Integer)
        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.InsertValeEmpleadoPedido(Folio, Serie, PedidoId)
    End Sub

    Public Sub SaveCuponDescuento(ByVal Folio As String, ByVal FacturaID As Integer)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.InsertCuponDescuento(Folio, FacturaID)

    End Sub

    Public Sub SaveReCuponDescuento(ByVal Folio As String, ByVal FolioPadre As String, ByVal NotaCreditoID As Integer)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.InsertReCuponDescuento(Folio, FolioPadre, NotaCreditoID)

    End Sub

    Public Function GetValeEmpleado(ByVal FacturaID As Integer) As ValeEmpleado

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectValeEmpleado(FacturaID)

    End Function

    Public Function GetValeEmpleadoByPedido(ByVal PedidoId As Integer) As ValeEmpleado
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SelectValeEmpleadoByPedido(PedidoId)
    End Function

    Public Sub ActualizarCuponDetalle(ByVal FacturaID As Integer, ByVal folio As String)
        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.ActualizarFolioCupon(FacturaID, folio)
        oFacturaDG = Nothing
    End Sub

    Public Function GetCuponDescuento(ByVal FacturaID As Integer) As String

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFolioCuponDescuento(FacturaID)

    End Function

    Public Function GetReCuponDescuento(ByVal NotaCreditoID As Integer) As String

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFolioReCuponDescuento(NotaCreditoID)

    End Function

    Public Function EstaReimpresoReCuponDescuento(ByVal Folio As String) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectReCuponDescuentoByFolio(Folio)

    End Function

    Public Sub MarcarCuponDescuentoUsado(ByVal Usado As Boolean, ByRef FolioCupon As String, ByVal FacturaID As Integer)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.UpdateStatusCuponDescuento(Usado, FolioCupon, FacturaID)

    End Sub

    Public Function EstaCuponDescuentoUsado(ByVal Folio As String, ByRef FolioSAP As String) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectCuponDescuentoByFolio(Folio, FolioSAP)

    End Function

    Public Function EstaValeEmpleadoUsado(ByVal Folio As String, ByVal Serie As String, ByRef FolioSAP As String) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectValeEmpleadoByFolio(Folio, Serie, FolioSAP)

    End Function

    Public Function GetDescuentoAdicional(ByVal CodArticulo As String) As Decimal

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDescuentoAdicional(CodArticulo)

    End Function

    Public Function GetDescuentoAdicionalFijoByCliente(ByVal CodCliente As String, ByRef htDatosDesc As Hashtable) As Boolean 'ByRef Desc As Decimal, ByRef PromoID As Integer) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDescuentoFijoByClienteDIP(CodCliente, htDatosDesc) ' Desc, PromoID)

    End Function

    Public Function GetFormasPagoByPromoFijo(ByVal PromoID As Integer) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFormasPagoByPromoFijo(PromoID)

    End Function

    Public Function GetFormasPagoByPromocion(ByVal PromoID As Integer) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFormasPagoByPromo(PromoID)

    End Function

    Public Function GetFormasPagoByDpakete(ByVal Folio As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFormasPagoByFolioDpakete(Folio)

    End Function

    Public Function GetDescuentoAdicionalPorMarca(ByVal CodMarca As String) As Decimal

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDescuentoAdicionalPorMarca(CodMarca)

    End Function

    Public Function IsPromoDosPorUnoYMedioVigente(ByVal CodMarca As String) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectPromoDosPorUnoYMedio(CodMarca)

    End Function

    Public Function LoadFormasPago(ByVal FacturaId As Integer) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.LoadFormaPago(FacturaId)
    End Function

    Public Function IsCodigoEnDPakete(ByVal CodArticulo As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectMaterialEnDpakete(CodArticulo)

    End Function

    Public Function GetDetalleDPakete(ByVal Folio As String) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDetalleDpakete(Folio)

    End Function

    Public Function IsTipoVentaPermitida(ByVal Codigo As String, ByVal TipoVenta As String, ByVal TipoPromo As String, ByRef PromoID As Integer) As Boolean

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDescuentoPermitidoByTipoVenta(Codigo, TipoVenta, TipoPromo, PromoID)

    End Function

    Public Function BancoAutorizador(ByVal NoTarjeta As String, ByVal Promo As Integer) As String
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectConector(NoTarjeta, Promo)

    End Function

    Public Function GetVtasTACRDiarias(ByVal Fecha As Date) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectVtasTACR(Fecha)

    End Function

    Public Function GetFormasPagoDia(ByVal Fecha As Date) As DataTable

        Dim oFacturaDG As New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFormasPagoDia(Fecha)

    End Function

    Public Function EsTarjetaBloqueada(ByVal NoTarjeta As String) As Boolean

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectTarjetaRechazada(NoTarjeta)

    End Function

    Public Function ValidaTipoVentaCliente(ByVal CodCliente As String) As String

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectValidaTipoVentaCliente(CodCliente)

    End Function

    Public Sub SaveTarjetaRechazada(ByVal NoTarjeta As String)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertTarjetaRechazada(NoTarjeta)

    End Sub

    Public Function GetPromoPago(ByVal Ticket As Integer, ByVal Fecha As Date, ByVal Adquiriente As String) As Integer

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectPromoPago(Ticket, Fecha, Adquiriente)

    End Function

    Public Function GetVtasTotales(ByVal Fecha As Date) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectVtasTotales(Fecha)

    End Function

    Public Sub EnviarVtasTACRDiarias(ByVal dtVtasTACR As DataTable, ByVal Fecha As Date)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertVtasTACR(dtVtasTACR, Fecha)

        oFacturaDG = Nothing

    End Sub

    Public Sub EnviarVtasTotales(ByVal dtVtasTotales As DataTable, ByVal Fecha As Date)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertVtasTotales(dtVtasTotales, Fecha)

        oFacturaDG = Nothing

    End Sub

    Public Sub EnviarUsersRoles(ByVal dsSource As DataSet)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertUsersInServer(dsSource)

        oFacturaDG = Nothing

    End Sub

    Public Sub EnviarFormasPagoToServer(ByVal dtFormasPago As DataTable)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.InsertFormasPagoInServer(dtFormasPago)

        oFacturaDG = Nothing

    End Sub

    Public Sub GetExistenciaArticulo(ByVal CodArticulo As String, ByVal CodAlmacen As String, ByVal strTalla As String, ByVal oFactura As Factura, Optional ByVal CodElectronico As String = "0")

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.SelectExistencia(CodArticulo, CodAlmacen, strTalla, oFactura, CodElectronico)

        oFacturaDG = Nothing

    End Sub

    Public Function getTotalRegistrosExistencias(ByVal CodArticulo As String) As Integer
        Dim oFacturaDG As FacturaDataGateway
        Dim total As Integer
        oFacturaDG = New FacturaDataGateway(Me)

        total = oFacturaDG.getTotalRegistros(CodArticulo)
        oFacturaDG = Nothing
        Return total

    End Function

    Public Sub [GetTallasArticulo](ByVal CodCorrida As String, ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.SelectTallas(CodCorrida, oFactura)

        oFacturaDG = Nothing

    End Sub

    Public Function [GetTallasArticulo](ByVal CodCorrida As String) As DataSet

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectTallasCorrida(CodCorrida)

        oFacturaDG = Nothing

    End Function



    Public Function GetUPCData(ByVal CodUPC As String) As DataTable

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectUPC(CodUPC)

        oFacturaDG = Nothing

    End Function

    Public Sub UPdateApartadoEntregado(ByVal oApartadoId As Integer)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.UpdateApartadoAsEntregado(oApartadoId)

        oFacturaDG = Nothing

    End Sub

    Public Sub UpdatePlayer(ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.UpdatePlayer(oFactura)

        oFacturaDG = Nothing


    End Sub

    Public Sub UpdateSaldo(ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.UpdateSaldo(oFactura)

        oFacturaDG = Nothing


    End Sub

    Public Sub ActualizaStatusRecupon(ByVal FolioCupon As String, ByVal CodVendedor As String, ByVal User As String)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.UpdateStatusReCuponDescuento(FolioCupon, CodVendedor, User)

        oFacturaDG = Nothing

    End Sub

    Public Sub ActualizaStatusEnvioServerPG(ByVal FolioSAP As String, ByVal Tipo As Integer)

        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.UpdateStatusEnvioServerPG(FolioSAP, Tipo)

        oFacturaDG = Nothing

    End Sub

    Public Function SelectByDateDescuentosOtorgados(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime) As DataSet

        Return oFacturaDG.SelectByDateDescuentosOtorgados(FechaIni, FechaFin)

    End Function

    Public Function GetFacturasLiquidadas(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime) As DataSet

        Return oFacturaDG.SelectFacturasLiquidadas(FechaIni, FechaFin)

    End Function

    Public Sub GetCondicionVenta(ByVal oCondicionVenta As CondicionesVtaSAP)

        oFacturaDG.SelectCondicionVenta(oCondicionVenta)

    End Sub

    Public Function GetAfiliacion(ByVal Promocion As Integer, ByVal IDEmisor As Integer) As String

        Return oFacturaDG.SelectAfiliacion(Promocion, IDEmisor)

    End Function

    Public Function GetDateServer() As DateTime

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectDateServer()

    End Function

    '----------------------------------------------------------------------------------------------------------
    'MLVARGAS 07/11/2019: Obtener los motivos de captura manual de la tarjeta
    '----------------------------------------------------------------------------------------------------------

    Public Function GetMotivosCaptura() As DataTable
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectMotivos()

    End Function

    Public Function AddTransaccionSinTarjeta(ByVal tienda As String, ByVal caja As String, _
                                        ByVal accountNumber As String, ByVal numtarjeta As String, ByVal monto As Decimal, _
                                        ByVal transactionType As String, ByVal estatus As String, ByVal nombrecliente As String, _
                                        ByVal motivo As String, ByVal empleadoGenero As String, ByVal empleadoAutorizo As String) As Integer

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        Dim id As Integer = oFacturaDG.InsTransaccionSinTarjeta(tienda, caja, accountNumber, numtarjeta, monto, transactionType, estatus, nombrecliente, motivo, empleadoGenero, empleadoAutorizo)
        Return id
    End Function

    Public Sub UpdEstatusTransaccionSinTarjeta(ByVal id As Integer, ByVal status As String)
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        oFacturaDG.UpdTransaccionesSinTarjeta(id, status)
    End Sub

#End Region

#Region "Notas Venta Manual"
    Public Function CargarFolioNext() As Integer
        Return oFacturaDG.CargarFolioNext
    End Function
#End Region

#Region "Revale"

    Public Function [VentasDPValeDelDia](ByVal Fecha As DateTime) As DataSet

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.VentasDPValeDelDia(Fecha.Date.ToShortDateString)

        oFacturaDG = Nothing

    End Function

    Public Function VtasCompreLineaPagueTiendaDia(ByVal Fecha As DateTime) As DataSet
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.VtasCompreLineaPagueTiendaDia(Fecha)
    End Function

#End Region

#Region "Descuentos"
    Public Function TieneJerarquiaDescuentoAdicional(ByVal DescuentoAdicionalID As Integer, ByVal Fecha As DateTime, ByVal TipoVenta As String) As Boolean
        Dim gateway As New FacturaDataGateway(Me)
        Return gateway.TieneJerarquiaDescuentoAdicional(DescuentoAdicionalID, Fecha, TipoVenta)
    End Function

    Public Function GetJerarquiaDescuentoAdicional(ByVal DescuentoAdicionalID As Integer) As String
        Dim gateway As New FacturaDataGateway(Me)
        Return gateway.GetJerarquiaDescuentoAdicional(DescuentoAdicionalID)
    End Function

    Public Function GetDescuentoAdicionalIDByCodigo(ByVal codigo As String, ByVal jerarquia As String, ByVal Fecha As DateTime, ByVal TipoVenta As String) As Boolean
        Dim gateway As New FacturaDataGateway(Me)
        Return gateway.GetDescuentoAdicionalIDByCodigo(codigo, jerarquia, Fecha, TipoVenta)
    End Function
#End Region

#Region "Facturacion SiHay"
    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/04/2013: Se guarda la factura del que lleva el pedido.
    '------------------------------------------------------------------------------------------------------------------------------------

    Public Sub SaveFacturaPedidoSH(ByVal oFactura As Factura)

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        oFacturaDG.InsertSH(oFactura)

        oFacturaDG = Nothing

    End Sub

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 16/05/2013: Actualiza el folio del cupon en la tabla de Pedido
    '-------------------------------------------------------------------------------------------------------------------------------------

    Public Function ActualizarFolioCuponPedido(ByVal PedidoID As Integer, ByVal Folio As String)
        Dim oFacturaDG As New FacturaDataGateway(Me)

        oFacturaDG.ActualizarFolioCuponPedido(PedidoID, Folio)

        oFacturaDG = Nothing

    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/07/2013: Se obtienen las facturas hechas por el SiHay
    '--------------------------------------------------------------------------------------------------------------------------------------

    Public Function GetAllFacturaPedido(ByVal EnabledRecordsOnly As Boolean, ByVal CodCaja As String) As DataSet
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetAllFacturaPedido(EnabledRecordsOnly, CodCaja)
    End Function
#End Region

#Region "Venta de Electronicos"

    Public Function [VentasElectronicosDelDia](ByVal Fecha As DateTime) As DataSet

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.VentasElectronicosDelDia(Fecha.Date.ToShortDateString)

        oFacturaDG = Nothing

    End Function

#End Region

#Region "DP Card"

    Public Function GetPromocionesDPCardByBIN(ByVal Bin As Integer, ByVal Importe As Decimal, ByVal TipoVenta As String) As DataTable

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.GetPromocionesDPCardByBIN(Bin, Importe, TipoVenta)

        oFacturaDG = Nothing

    End Function

    Public Function IsDPCardPuntosKarum(ByVal Bin As Integer) As Boolean
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.IsDPCardPuntosKarum(Bin)
    End Function

    Public Function insertAutLealtad(ByVal tienda As String, ByVal caja As String, ByVal usuario As String,
                                     ByVal numTarjeta As String, ByVal importe As Decimal, Optional ByVal bonificacion As Boolean = False, Optional ByVal canje As Boolean = False, Optional ByVal autorizado As Boolean = False) As Integer
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.insertAutLealtad(tienda, caja, usuario, numTarjeta, importe, bonificacion, canje, autorizado)
    End Function
    Public Function GetTransaccionesDPCard(ByVal numTarjeta As String, ByVal fechaIn As DateTime, ByVal fechaFn As DateTime,
                                        ByVal opcion As Integer) As Integer
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.GetTransaccionesDPCard(numTarjeta, fechaIn, fechaFn, opcion)

    End Function
    Public Function GetTransaccionesDPCardBlueFinal(ByVal numTarjeta As String, ByVal fechaIn As DateTime, ByVal fechaFn As DateTime,
                                        ByVal opcion As Integer) As Integer
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.GetTransaccionesDPCard_BlueFinal(numTarjeta, fechaIn, fechaFn, opcion)

    End Function
    Public Function IsDPCardPuntosBlue(ByVal Bin As Integer) As DataTable
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.IsDPCardPuntosBlue_Karum(Bin)
    End Function

    Public Function GetFormasPagoNoAcumula() As DataSet
        Dim oFacturasDG As New FacturaDataGateway(Me)
        Return oFacturasDG.SelectAllFormasPagoNoAcumula()

    End Function

#End Region

#Region "Seguros de Vida DPVale"

    Public Function GrabarSeguroDPVale(ByVal FolioDPVale As String, ByVal Beneficiario As String, ByVal Usuario As String) As Boolean

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.GrabarSeguroDPVale(FolioDPVale, Beneficiario, Usuario)

        oFacturaDG = Nothing

    End Function

    Public Function GetSeguroDPValeByDPValeID(ByVal DPValeID As String) As DataTable

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.GetSeguroDPValeByDPValeID(DPValeID)

        oFacturaDG = Nothing

    End Function


    Public Function GetDatosFinanciamiento(ByVal Plaza As String) As DataTable

        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.GetDatosFinanciamiento(Plaza)

        oFacturaDG = Nothing

    End Function

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 13/10/2015: Modificar el beneficiario del seguro de vida
    '--------------------------------------------------------------------------------------------------------------------------

    Public Function ModificarBeneficiario(ByVal FolioDPVale As String, ByVal beneficiario As String, ByVal usuariomod As String, ByVal motivo As String) As Boolean
        Dim oFacturaDG As FacturaDataGateway

        oFacturaDG = New FacturaDataGateway(Me)
        Return oFacturaDG.ModificarBeneficiario(FolioDPVale, beneficiario, usuariomod, motivo)
    End Function

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/08/2017: Obtiene el aviso de DPVale mediante el tipo
    '--------------------------------------------------------------------------------------------------------------------------
    Public Function GetDPValeAviso(ByVal Tipo As String) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetDPValeAviso(Tipo)
    End Function

#End Region

#Region "DPCard Puntos"

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/04/2015: Actualiza la factura con el No. Tarjeta DPCard Puntos en caso de canje de productos.
    '--------------------------------------------------------------------------------------------------------------------------

    Public Sub ActualizaNoDPCardPuntos(ByVal FacturaId As Integer, ByVal datos As Hashtable)
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        oFacturaDG.ActualizaNoDPCardPuntos(FacturaId, datos)
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2015: Obtenemos el detalle por factura
    '--------------------------------------------------------------------------------------------------------------------------
    Public Function GetFacturasById(ByVal FacturaID As Integer) As DataSet
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SelectDetalle(FacturaID)
    End Function

    '--------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 15/05/2018: Obtener el código del producto original en base al código del articulo seleccionado para el cambio
    '--------------------------------------------------------------------------------------------------------------------------

    Public Function GetOldProductByNewProduct(ByVal dtDetalle As DataTable, ByVal NewProduct As String) As String
        Dim oResult As String = String.Empty
        Dim campo As String
        For Each row As DataRow In dtDetalle.Rows
            campo = row("Codigo")
            If (campo = NewProduct) Then
                oResult = row("OldCodigo")
                Exit For
            End If
        Next
        Return oResult
    End Function


    '--------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 15/05/2018: Obtener el descuento por factura / producto
    '--------------------------------------------------------------------------------------------------------------------------
    Public Function GetDctoByIdAndProduct(ByVal FacturaID As Integer, ByVal CodProducto As String) As Decimal
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        Return oFacturaDG.GetDctoByIdAndProduct(FacturaID, CodProducto)
    End Function



    Public Function GetTipoCliente(ByVal TipoVenta As String) As String
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        Return oFacturaDG.SelectTipoCliente(TipoVenta)
    End Function

    Public Function GetCodTipoVta(ByVal CodMotivo As String) As String
        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)
        Return oFacturaDG.SelectTipoVenta(CodMotivo)
    End Function



#End Region

#Region "MQTT Agente"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 09/11/2015: Obtiene el siguiente folio de MQTT
    '---------------------------------------------------------------------------------------------------------------------------
    Public Function NextFolioFactura(ByVal CodCaja As String) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.NextFolioFactura(CodCaja)
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 09/11/2015: Actualiza el folio MQTT
    '---------------------------------------------------------------------------------------------------------------------------

    Public Sub UpdateFolioMQTT(ByVal CodCaja As String, ByVal Folio As Int64)
        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.UpdateFolioMQTT(CodCaja, Folio)
    End Sub

#End Region

#Region "Retail"

    Public Function SaveSerial(ByVal SerialId As String, ByVal Enviado As String, ByVal Usuario As String, Optional ByVal FacturaId As Integer = 0, Optional ByVal ContratoId As Integer = 0, Optional PedidoId As Integer = 0) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SaveSerial(SerialId, Enviado, Usuario, FacturaId, ContratoId, PedidoId)
    End Function

    Public Function GetSerialsByDate(ByVal fecha As DateTime) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetSerialsByDate(fecha)
    End Function

    Public Function GetSerialByFacturaId(ByVal FacturaId As Integer) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetSerialByFacturaId(FacturaId)
    End Function

    Public Sub GetExistenciaCodProveedor(ByVal CodArticulo As String, ByVal CodAlmacen As String, ByVal strTalla As String, ByVal oFactura As Factura, ByRef oArticulo As CatalogoArticulos.Articulo, Optional ByRef cuenta As Integer = 0)
        Dim oFacturaDG As New FacturaDataGateway(Me)
        oFacturaDG.GetExistenciaCodProveedor(CodArticulo, CodAlmacen, strTalla, oFactura, oArticulo, cuenta)
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/09/2016: Valida que la referencia no se duplique
    '----------------------------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidaReferencia(ByVal referencia As String) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.ValidarReferencia(referencia)
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/09/2016: Guardar información Servicios 
    '----------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function SaveDetalleDPVale(ByVal infoVale As Dictionary(Of String, Object)) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SaveDetalleDPVale(infoVale)
    End Function

    Public Function GetItemsColor(ByVal Item As String, ByVal Talla As String) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetItemsColor(Item, Talla)
    End Function

    Public Function GetInfoDetalleDPValeByFormaPago(ByVal FormaPagoId As Integer) As Dictionary(Of String, Object)
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetInfoDetalleDPValeByFormaPago(FormaPagoId)
    End Function

    Public Function ObtenerReferenciaByFacturaID(ByVal FacturaID As String) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.ObtenerReferenciaByFacturaID(FacturaID)
    End Function
#End Region

#Region "CargaNotasCredito"
    ''' <summary>
    ''' ' AF (14-11-2016): Función para retornar todos los registros previamente cargados de notas de crédito masivo
    ''' </summary>
    ''' <returns>Lista de registros de notas de crédito</returns>
    ''' <remarks></remarks>
    Public Function SelectFacturasNotasCreditoMasivo() As DataTable

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.SelectFacturasNotasCreditoMasivo()

    End Function

    Public Function InsertaFacturasNotasCreditoMasivo(ByVal Registro As String, ByVal Estatus As Integer) As Boolean

        Dim oFacturaDG As FacturaDataGateway
        oFacturaDG = New FacturaDataGateway(Me)

        Return oFacturaDG.InsertaFacturasNotasCreditoMasivo(Registro, Estatus)

    End Function

#End Region

#Region "Pagos Tarjeta Banamex"

    Public Function GetPromocionesBanamex() As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetPromocionesBanamex()
    End Function

#End Region

#Region "Cambio de talla"

    Public Function GetExistenciasCambioTalla(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal Color As String) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetExistenciasCambioTalla(CodAlmacen, CodArticulo, Color)
    End Function

    Public Function GetDetalleCorridaCambioTalla(ByVal FacturaId As Integer) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetDetalleCorridaCambioTalla(FacturaId)
    End Function

    Public Function GetDetallePermitidoNotaCredito(ByVal CodArticulo As String, ByVal Referencia As String) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetDetallePermitidoNotaCredito(CodArticulo, Referencia)
    End Function

#End Region

#Region "Microcreditos"

    Public Function GetPlazos(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetPlazos(CodAlmacen, Fecha)
    End Function

    Public Function GetServiciosFinancieros(Optional ByVal Todos As Boolean = False) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetServiciosFinancieros(Todos)
    End Function

    Public Function GetBancos() As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetBancos()
    End Function

    Public Function GetServiciosFinancierosByID_Act(ByVal ID As String) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetServiciosFinancierosByID_Act(ID)
    End Function

    Public Function GetByFecha(ByVal ServicioId As Integer, ByVal NoCuenta As String, ByVal Celular As String, ByVal NumeroTarjeta As String, ByVal Clabe As String) As DataSet
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SelectFecha(ServicioId, NoCuenta, Celular, NumeroTarjeta, Clabe)
    End Function

    Public Function GetFechaServidor() As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetFechaServidor()
    End Function

    Public Function GetFechaDispersion(ByVal ServicioID As String, ByVal Fecha As DateTime, ByRef HorariosDispersion As DataTable) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetFechaDispersion(ServicioID, Fecha, HorariosDispersion)
    End Function

#Region "Dispersión Expres"

    Public Function ValidaPrestamoAnterior(ByVal NombreCliente As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.getPrestamoAnterior(NombreCliente, ServicioID, Valor)
    End Function

    Public Function MensajesCreditoExpres(ByVal TipoMensaje As Integer) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetMensajesCredExpres(TipoMensaje)
    End Function

    Public Function GetFechaDispersionExpres(ByVal ServicioID As String, ByVal Fecha As DateTime, ByRef HorariosDispersion As DataTable) As String
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetFechaDispersionExpres(ServicioID, Fecha, HorariosDispersion)
    End Function

#End Region

#End Region

#Region "Devolucion Tarjetas Banamex"

    Public Function GetPedidosFormasPagoBanamex(ByVal CodAlmacen As String, ByVal Tipo As String) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetPedidosFormasPagoBanamex(CodAlmacen, Tipo)
    End Function

    Public Function GetDevolucionTarjetaById(ByVal DevolucionTarjetaId As Integer) As DevolucionTarjeta
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetDevolucionTarjetaById(DevolucionTarjetaId)
    End Function

    Public Function SaveDevolucionTarjeta(ByVal Devolucion As DevolucionTarjeta) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.SaveDevolucionTarjeta(Devolucion)
    End Function

    Public Function GetNotasCreditoByFactura(ByVal Referencia As String) As DataTable
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.GetNotasCreditoByFactura(Referencia)
    End Function


#End Region


#Region "Correccion Ventas incompletas"

    Public Function ValidarFacturaExitosa(ByVal Referencia As String) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.ValidarFacturaExitosa(Referencia)
    End Function

    Public Function ValidaPedidoExitoso(ByVal Referencia As String) As Boolean
        Dim oFacturaDG As New FacturaDataGateway(Me)
        Return oFacturaDG.ValidaPedidoExitoso(Referencia)
    End Function

#End Region

End Class
