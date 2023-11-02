
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos




Public Class NotasCreditoManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing, Optional ByVal ConfigCierre As SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigCierre = ConfigCierre

    End Sub

#End Region



#Region "Properties"

    Private oApplicationContext As ApplicationContext
    Dim oSAPConfiguration As SAPApplicationConfig
    Private oConfigCierre As SaveConfigArchivos

    Public Property ApplicationContext() As ApplicationContext

        Get

            Return oApplicationContext

        End Get


        Set(ByVal Value As ApplicationContext)

            oApplicationContext = Value

        End Set

    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig
        Get
            Return oSAPConfiguration
        End Get
    End Property

    Public ReadOnly Property ConfigCierre As SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#End Region



#Region "Métodos"

    Public Function Create() As NotaCredito

        Dim oNotaCredito As NotaCredito
        oNotaCredito = New NotaCredito(Me)

        Return oNotaCredito

    End Function

    Public Sub InsertaValeCajaDPVL(ByVal ValeCajaID As Integer, ByVal DocFI As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        oNotasCreditoDG.InsertaValeCajaDPVL(ValeCajaID, DocFI)

        oNotasCreditoDG = Nothing

    End Sub

    Public Function Load(ByVal NotaCreditoID As Integer) As NotaCredito

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.Select(NotaCreditoID)

        oNotasCreditoDG = Nothing

    End Function

    Public Function Load(ByVal FolioSAP As String) As NotaCredito

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.Select(FolioSAP)

        oNotasCreditoDG = Nothing

    End Function

    Public Function GetFolioSAP(ByVal codCaja As String, ByVal FolioFactura As String) As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.SelectFolioSAP(codCaja, FolioFactura)

        oNotasCreditoDG = Nothing

    End Function


    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.SelectAll(EnabledRecordsOnly)

        oNotasCreditoDG = Nothing

    End Function

    Public Function GetSelectNCByCaja(ByVal CodCaja As String) As Integer

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.SeleccionaFolioNCByCaja(CodCaja)

        oNotasCreditoDG = Nothing

    End Function

    Public Function GetDatosNCSAP(ByVal strI_KEYPRO As String, ByRef dt As DataTable) As String

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.GetDatosNCSAP(strI_KEYPRO, dt)

        oNotasCreditoDG = Nothing

    End Function


    Public Overridable Sub Save(ByVal pNotaCredito As NotaCredito, ByVal EnvioServerPG As Boolean, ByVal FolioPedido As String, Optional ByRef strError As String = "")

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        If (pNotaCredito Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Nota Credito no puede ser nulo.")
        End If

        If (pNotaCredito.IsNew) Then
            '----------------------------------------------------------------------------------------
            'JNAVA (19.02.2015): Agregamos parametro nuevo para cuando es NC de Factura de SH
            '----------------------------------------------------------------------------------------
            oNotasCreditoDG.Insert(pNotaCredito, EnvioServerPG, FolioPedido, strError)
        Else
            'oContratoDG.Update(pContrato)
        End If


        oNotasCreditoDG = Nothing

    End Sub



    'Public Sub Delete(ByVal ID As Integer)

    '    Dim oContratoDG As New ContratoDataGateway(Me)

    '    If (ID = 0) Then
    '        Throw New ArgumentException("Debe especificar un Código de Caja")
    '    End If

    '    oContratoDG.Delete(ID)

    '    oContratoDG = Nothing

    'End Sub  



    Public Function ExtraerCatalogoCorridas() As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.SelectCatalogoCorridas

        oNotasCreditoDG = Nothing

    End Function



    Public Function DistribucionNotaCredito(ByVal intNotaCreditoFolio As Integer, ByVal strTipoDevolucion As String, _
                                            ByVal oCliente As DportenisPro.DPTienda.ApplicationUnits.Clientes.ClienteAlterno, ByVal strModulo As String, _
                                            ByVal strTablaTmp As String) As Integer

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.DistribucionNotaCredito(intNotaCreditoFolio, strTipoDevolucion, oCliente, strModulo, strTablaTmp)

        oNotasCreditoDG = Nothing

    End Function

#End Region



#Region "Métodos [Contrato Detalle]"

    Public Sub CrearTablaTmp(ByVal strNombreTabla As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        oNotasCreditoDG.CreatTable(strNombreTabla)

        oNotasCreditoDG = Nothing

    End Sub



    Public Sub EliminarTablaTmp(ByVal strTablaTmp As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        oNotasCreditoDG.DeleteTable(strTablaTmp)

        oNotasCreditoDG = Nothing

    End Sub

    Public Sub AgregarArticulo(ByVal intNotaCreditoID As Integer, ByVal oArticulo As Articulo, ByVal decNumero As String, _
                               ByVal intCantidad As Integer, ByVal oFactura As Factura, ByVal strTablaTmp As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        oNotasCreditoDG.InsertArticulo(intNotaCreditoID, oArticulo, decNumero, intCantidad, oFactura, strTablaTmp)

        oNotasCreditoDG = Nothing

    End Sub

    Public Sub EliminarArticulo(ByVal strFacturaFolio As String, ByVal strCodArticulo As String, ByVal strTalla As String, ByVal strTablaTmp As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        oNotasCreditoDG.DeleteArticulo(strFacturaFolio, strCodArticulo, strTalla, strTablaTmp)

        oNotasCreditoDG = Nothing

    End Sub



    Public Function ActualizarDataSet(ByVal strStoredProcedure As String, ByVal strTabla As String) As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.FillDataSet(strStoredProcedure, strTabla)

        oNotasCreditoDG = Nothing

    End Function
    Public Function FolioProGet(ByVal FolioSAP As String) As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.FolioProSel(FolioSAP)

        oNotasCreditoDG = Nothing

    End Function


    Public Function ValidarCantidad(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, ByVal strTalla As String, ByVal intFacturaID As Integer) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.ValidarCantidadArticulo(intCantidadArticulo, strCodArticulo, strTalla, intFacturaID)

        oNotasCreditoDG = Nothing

    End Function



    Public Function ValidarExistenciaArticulo(ByVal strCodArticulo As String, ByVal strTalla As String, _
                                              ByVal intFacturaID As Integer) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.ValidarExistenciaArticulo(strCodArticulo, strTalla, intFacturaID)

        oNotasCreditoDG = Nothing

    End Function



    Public Function ValidarExistenciaFormaPago(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.ValidarExistenciaFormaPago(intFacturaID, strFormaPagoID)

        oNotasCreditoDG = Nothing

    End Function



    Public Function ValidarFactura(ByVal intFacturaID As Integer, ByVal strCodCaja As String, ByVal strClienteID As String, ByVal ValidaPG As Boolean) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.ValidarFactura(intFacturaID, strCodCaja, strClienteID, ValidaPG)

        oNotasCreditoDG = Nothing

    End Function

    Public Function ValidarFacturaTipoVenta(ByVal intFacturaID As Integer, ByVal strTipoVentaID As String, ByVal strTablaTmp As String) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.ValidarFacturaTipoVenta(intFacturaID, strTipoVentaID, strTablaTmp)

        oNotasCreditoDG = Nothing

    End Function

    Public Function GetFolioSAPByDPVale(ByVal intDPValeID As Integer) As String

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.GetFolioSAPByDPVale(intDPValeID)

        oNotasCreditoDG = Nothing

    End Function

    Public Function GetDPValeInfo(ByVal intDPValeID As Integer) As String()

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.GetDPValeInfo(intDPValeID)

        oNotasCreditoDG = Nothing

    End Function


    Public Function ValidarFacturaDPVale(ByVal intFacturaID As Integer, ByVal strTablaTmp As String) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.ValidarFacturaDPVale(intFacturaID, strTablaTmp)

        oNotasCreditoDG = Nothing

    End Function



    Public Function ValidarCantidadDevueltaArticulo(ByVal oFactura As Factura, ByVal strCodArticulo As String, _
                                                    ByVal strTalla As String, ByVal intCantidadUser As Integer) As Boolean

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.ValidarCantidadDevueltaArticulo(oFactura, strCodArticulo, strTalla, intCantidadUser)

        oNotasCreditoDG = Nothing

    End Function



    Public Function Folios() As Integer

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)


        Return oNotasCreditoDG.NotaCreditoFolios

        oNotasCreditoDG = Nothing

    End Function



    Public Function GetUPCData(ByVal CodUPC As String) As DataTable

        Dim oNotasCreditoDG As NotasCreditoDataGateway
        oNotasCreditoDG = New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.SelectUPC(CodUPC)

        oNotasCreditoDG = Nothing

    End Function

#End Region

    ''Funcion para Abono Credito Directo
    Public Function GetIDAsociado(ByVal IDCliente As Integer) As Integer
        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        Return oNotasCreditoDG.GetIDAsociado(IDCliente)
    End Function

    Public Function FacturasPorLiquidar(ByVal IDAsociado As Integer) As DataSet

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        Return oNotasCreditoDG.FacturasPorLiquidar(IDAsociado)

    End Function

    Public Function ValidarTallaArticulo(ByVal strArticulo As String, ByVal strTalla As String) As Integer

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        Return oNotasCreditoDG.ValidarTallaArticulo(strArticulo, strTalla)

    End Function


    Public Function FacturaValidarNotaCreditoPasadasCanceladas(ByVal intfolioFact As Integer) As Integer

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        Return oNotasCreditoDG.FacturaValidarNotaCreditoPasadasCanceladas(intfolioFact)

    End Function

    Public Function ZBAPISD17_DEV_VENTAS(ByVal pNotaCredito As NotaCredito, ByRef DevAnt As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        oNotasCreditoDG.SaveSAP(pNotaCredito, DevAnt)

    End Function

    Public Function ValidarCambiosTalla(ByVal FolioSAP As String, ByVal TallaS As String, _
                                        ByVal CodArticulo As String, ByVal CantDev As Integer) As String

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        Return oNotasCreditoDG.ValidarCambiosTalla(FolioSAP, TallaS, CodArticulo, CantDev)

    End Function

    Public Sub DesmarcarReversa_AjustarCantDevuelta(ByVal Folios As String)

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)
        oNotasCreditoDG.DesmarcarReversa_AjustarCantDevuelta(Folios)

    End Sub

    Public Function ExtraerMontoNoCancelado(ByVal intFacturaID As Integer, ByVal strFormaPagoID As String) As Decimal

        Dim oNotasCreditoDG As New NotasCreditoDataGateway(Me)

        Return oNotasCreditoDG.ExtraerMontoNoCancelado(intFacturaID, strFormaPagoID)

        oNotasCreditoDG = Nothing

    End Function

#Region "Operacionales"
    Public Function ReporteOperacionalMarcas(ByVal CodAlmacen As String, ByVal fechaini As Date, ByVal fechafin As Date, ByVal Filtro As Integer, ByVal IVA As Decimal) As DataSet
        Dim oDg As New NotasCreditoDataGateway(Me)
        Return oDg.ReporteOperacionalMarcas(CodAlmacen, fechaini, fechafin, Filtro, IVA)
    End Function
    Public Function ReporteOperacionalMarcas_InventarioInicial(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal fechaFin As Date) As Double
        Dim oDG As New NotasCreditoDataGateway(Me)
        Return oDG.OperacionalMarcas_InventarioInicial(CodAlmacen, CodArticulo, MesIni, FechaIni, FechaInicio, fechaFin)
    End Function
    Public Function ReporteOperacionalMarcas_InventarioFinal(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesFin As Integer, ByVal FechaIni As Date, ByVal fechafin As Date) As Double
        Dim oDg As New NotasCreditoDataGateway(Me)
        Return oDg.OperacionalMarcas_InventarioFinal(CodAlmacen, CodArticulo, MesFin, FechaIni, fechafin)
    End Function
    Public Function ReporteOperacionalMaterial(ByVal CodAlmacen As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Filtro As Integer, ByVal Year As String, ByVal YearNow As String, ByVal IVA As Decimal) As DataSet
        Dim oDG As New NotasCreditoDataGateway(Me)
        Return oDG.ReporteOperacionalMaterial(CodAlmacen, FechaIni, FechaFin, Filtro, Year, YearNow, IVA)
    End Function
    Public Function Inventario_Inicial(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal FechaFin As Date) As Double
        Dim oDG As New NotasCreditoDataGateway(Me)
        Return oDG.Inventario_Inicial(CodAlmacen, CodArticulo, MesIni, FechaIni, FechaInicio, FechaFin)
    End Function
    Public Function Inventario_Inicial_Cruzado(ByVal CodALmacen As String, ByVal CodArticulo As String, ByVal MesIni As Integer, ByVal FechaIni As Date, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FechaFinal As Date) As Double
        Dim oDG As New NotasCreditoDataGateway(Me)
        Return oDG.Inventario_InicialCruzado(CodALmacen, CodArticulo, MesIni, FechaIni, FechaInicio, FechaFin, FechaFinal)
    End Function
    Public Function Inventario_Final(ByVal CodAlmacen As String, ByVal CodArticulo As String, ByVal MesFin As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Double
        Dim oDataGateway As New NotasCreditoDataGateway(Me)
        Return oDataGateway.Inventario_Final(CodAlmacen, CodArticulo, MesFin, FechaIni, FechaFin)
    End Function
    Public Function Articulos_Globales(ByVal Mes As Integer, ByVal TipoReporte As Integer) As Double
        Dim oDataGateWay As New NotasCreditoDataGateway(Me)
        Return oDataGateWay.Articulos_globales(Mes, TipoReporte)
    End Function

#End Region


End Class
