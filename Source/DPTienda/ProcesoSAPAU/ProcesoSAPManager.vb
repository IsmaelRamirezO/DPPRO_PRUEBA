Option Explicit On

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports System.Collections.Generic



Public Class ProcesoSAPManager

    Private oApplicationContext As ApplicationContext
    Private oSAPConfiguration As SAPApplicationConfig
    Public ConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos
    Public funcEsquema As ERPConnect.RFCFunction

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal SAPConfiguration As SAPApplicationConfig)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration


    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

    End Sub

#End Region


#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig

        Get
            Return oSAPConfiguration
        End Get

    End Property

#End Region


    '#Zone " Metodos "


#Region "Vendedores"

    Friend Function Read_Vendedores() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_Vendedores()

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Sub Write_Vendedores(ByVal strCodVendedor As String, ByVal strNombre As String)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertVendedor(strCodVendedor, strNombre)

    End Sub

    Public Function ZBAPI_VALIDA_VENDEDOR(ByVal CodVendedor As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim strResult As String = ""

        strResult = oSAPProxy.ZBAPI_VALIDAVENDEDOR(CodVendedor)

        oSAPProxy = Nothing

        Return strResult

    End Function


#End Region


#Region "Articulos"

    Friend Function Read_Articulos(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ArticulosSAPSD01(fechaini, fechafin)

        oSAPProxy = Nothing

        Return oResult

    End Function


    Friend Sub Write_Articulos(ByVal oArticulo As ArticulosSAP)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarArticulos(oArticulo)

    End Sub

    Friend Function ZBAPI_Extraer_PreciosCondiciones(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal bCompleta As Boolean, Optional ByVal Material As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_Extraer_PreciosCondiciones(strCondicion, strLstPrecio, bCompleta, Material)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Sub Write_ArticulosPrecioVenta(ByVal codigoarticulo As String, ByVal precioventa As Double)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.ActualizaArticulosPrecioVta(codigoarticulo, precioventa)

    End Sub

    Friend Sub LoadDataFromSAPtoDB(ByVal strFile As String, ByVal Descarga As Integer)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.LoadDataFromSAPtoDB(strFile, Descarga)

    End Sub

    Friend Sub Write_ArticulosPrecioIVA(ByVal strcodigoarticulo As String, ByVal dblprecioiva As Double)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.ActualizaArticulosPrecioConIVA(strcodigoarticulo, dblprecioiva)

    End Sub


    Friend Sub Write_ArticulosPrecioSocio(ByVal strcodigoarticulo As String, ByVal dblprecioSocio As Double)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.ActualizaArticulosPrecioSocio(strcodigoarticulo, dblprecioSocio)

    End Sub


    Friend Function Write_Existencias(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarExistencias(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_DescuentoAdicional(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarDescuentosAdicionales(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_DescuentoAdicionalGeneral(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarDescuentosAdicionalesGeneral(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_DescuentoAdicionalPorMarca(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarDescuentosAdicionalesPorMarca(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_Promocion20y30(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromo20y30(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_PromocionDosPorUnoYMedio(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromoDosPorUnoYMedio(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_PromocionDosPorUnoYMedioPorMarca(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromoDosPorUnoYMedioPorMarca(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_PromocionDosPorUnoYMedioPorCodigo(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromoDosPorUnoYMedioPorCodigo(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_PromocionDpaketes(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromoDpaketesStreetPacks(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_PromocionDpaketesDetalle(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarPromoDpaketesStreetPacksDetalle(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Write_DescuentosAdicionalesFijos(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarDescuentoAdicionalFijoPorClienteDIP(oRow)

        oSAPDG = Nothing

    End Function

    Friend Function Read_Existencias() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAEXISTENCIAS()

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_ExistenciasXCodigos(ByVal strMaterial As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAEXISTENCIASXCODIGO(strMaterial)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function ZRFC_CARGAARTICULO_XCODIGO(ByVal strMaterial As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZRFC_CARGAARTICULO_XCODIGO(strMaterial)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_Marcas() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAMARCAS

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function ZMF_JERARQUIASYATRIBUTOS(Tipo As String, ByRef dtValores As DataTable) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZMF_JERARQUIASYATRIBUTOS(Tipo, dtValores)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_DescuentosAdicionales(ByVal Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGADESCUENTOSADICIONALES(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_CentrosSAP() As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim oResult As DataTable
        oResult = oSAPProxy.ZRFC_DESCARGA_DATOS_TIENDAS()
        oSAPProxy = Nothing
        Return oResult
    End Function

    Friend Function Read_DescuentosAdicionalesGeneral(ByVal Fecha As Date) As DataTable


        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGADESCUENTOSADICIONALESGENERAL(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_DescuentosAdicionalesPorMarca(ByVal Fecha As Date) As DataTable


        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGADESCUENTOSADICIONALESPORMARCA(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_Promocion20y30(ByVal Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAPROMOCION20Y30(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_PromocionDosPorUnoMedioYMedio(ByVal Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIO(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_PromocionDosPorUnoMedioYMedioPorMarca(ByVal Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIOPORMARCA(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_PromocionDpaketesStreetPacks(ByVal Fecha As Date, ByRef dtDetalle As DataTable) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAPROMOCIONDPAKETESSTREETPACKS(Fecha, dtDetalle)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_PromocionDosPorUnoMedioYMedioPorCodigo(ByVal Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIOPORCODIGO(Fecha)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_DescuentosFijosClientesDIPs() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CARGADESCUENTOSFIJOSCLIENTESDIPS

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function Read_UPC_FromSAP(ByVal CodUPC As String) As ArticulosSAP
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As ArticulosSAP

        oResult = oSAPProxy.ZBAPI_GETDATA_UPC(CodUPC)

        oSAPProxy = Nothing

        Return oResult
    End Function


#End Region


#Region "Clientes"

    Friend Function Read_Clientes(ByVal OrganizacionCompra As String, ByVal canal As String, ByVal sector As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ClientesSAPSD02(OrganizacionCompra, canal, sector)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function Valida_Clientes(ByVal strCliente As String, Optional ByVal bTodos As Boolean = False, _
    Optional ByRef bAdeuda As Boolean = False) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String

        oResult = oSAPProxy.Valida_Clientes(strCliente, bTodos, bAdeuda)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function ZCUP_INFO_CUPON(ByVal Folio As String, ByVal strTipoVenta As String, ByRef strErrorMsg As String) As CuponDescuento

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As CuponDescuento

        oResult = oSAPProxy.ZCUP_INFO_CUPON(Folio, strTipoVenta, strErrorMsg)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '-------------------------------------------------------------------------
    ' JNAVA 17.02.2016): Se comento por que ya no se usa en Retail
    '-------------------------------------------------------------------------
    'Public Function Read_Plaza() As String
    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Return oSAPProxy.Read_Plaza()

    'End Function

    Public Function Read_BitacoraSAP(ByVal Fecha As Date) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_BitacoraSAP(Fecha)

        oSAPProxy = Nothing

        Return oResult
    End Function

    Public Function ZBAPI_ELIMINAEMAILS(ByVal ClienteID As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_ELIMINAEMAILS(ClienteID)

    End Function

    Public Sub Write_Clientes(ByVal oClientes As ClientesSAP)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarClientes(oClientes)

    End Sub

    Public Sub Write_RazonesRechazo(ByVal RazonID As Integer, ByVal Razon As String, ByVal Modulo As String)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarRazonesRechazo(RazonID, Razon, Modulo)

    End Sub

    Public Sub Write_CodigosPostales(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarCodigosPostales(oRow)

    End Sub

    Public Function Write_Clientes_PG(ByVal oClientes As ClientesSAP, ByVal dtDatos As DataTable, ByVal dtDatos2 As DataTable, ByVal dtDatos3 As DataTable, ByVal codalmacen As String) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.ZBAPIDPT01_REGISTRA_CLIENTE_PG(oClientes, dtDatos, dtDatos2, dtDatos3, codalmacen)

    End Function

#End Region


#Region "CondicionesVenta Importes"

    Friend Function Read_CondicionesPreDectos(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal bCompleta As Boolean) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ExtraPreciosCondicSAPSD04(strCondicion, strLstPrecio, bCompleta)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Function Read_CondicionesPreDectosXCodigo(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal strMaterial As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ExtraPreciosCondicSAPSD04XCODIGO(strCondicion, strLstPrecio, strMaterial)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Friend Sub Write_CondicionesPreDectos(ByVal oCodicionesVtaSAP As CondicionesVtaSAP)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarCondicionesVta(oCodicionesVtaSAP)

    End Sub

    Friend Sub Delete_CondicionesPreDectos()

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.DeleteCondicionesVta()

    End Sub

    Public Sub DeleteDescuentosAdicionalesFijos()

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.DeleteDescuentosAdicionalesFijos()

        oSAPDG = Nothing

    End Sub


#End Region


#Region "Centros"

    Public Function Read_Centros(Optional ByVal strCodAlmacen As String = "", Optional ByRef CentroFI As String = "") As String

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        If strCodAlmacen.Trim = "" Then
            Return oSAPDG.SeleccionaCentro(Me.oApplicationContext.ApplicationConfiguration.Almacen, CentroFI)
        Else
            Return oSAPDG.SeleccionaCentro(strCodAlmacen, CentroFI)
        End If

    End Function

    Public Function Read_CentrosSAP(ByVal strCentroSAP As String) As String()

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        Return oSAPDG.SeleccionaCentroSAP(strCentroSAP)

    End Function

#End Region


#Region "Apartados"

    Public Function Write_DesbloqueApartado(ByVal strFolioapartado As String, ByVal dtApart As DataTable) As String


        Try
            Dim strRDocficCanc As String
            Dim oSAPProxy As New ProcesoSAPProxy(Me)
            '*****************************************************
            Dim oPartado As ZDP_PRODAPARTADO()
            Dim oAPdo As New ZDP_PRODAPARTADO
            Dim i As Integer = 0
            Dim odrArticulo As DataRow
            For Each odrArticulo In dtApart.Rows
                oAPdo.Contrato = strFolioapartado
                oAPdo.Cantidad = odrArticulo("Cantidad")
                oAPdo.Matnr = odrArticulo("CodArticulo")
                oAPdo.Talla = FormatTalla(odrArticulo("numero"))
                ReDim Preserve oPartado(i)                  'Agrego otro clase al arreglo
                oPartado(i) = oAPdo                         'Le asigno la clase al arreglo
                oAPdo = New ZDP_PRODAPARTADO                'Limpio la clase
                i = i + 1
            Next
            '*****************************************************

            strRDocficCanc = oSAPProxy.Write_DesbloqueoApartadoSAPMM14(strFolioapartado, oPartado)

            oSAPProxy = Nothing

            Return strRDocficCanc

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Public Function Write_CancelaApartado(ByVal strCliente As String, ByVal dblIImporte As Double, ByVal dblIImportePenalidad As Double, _
                                                    ByVal strTienda As String, ByVal strDevdinero As String, ByVal dblIImporteDevolucion As Double, _
                                                    ByVal strDocFi As String, ByVal strBanco As String, ByVal strTipoPago As String) As String

        Dim strDOCNUMFB01 As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        strDOCNUMFB01 = oSAPProxy.Write_CancelacionApartadoSAPFI04(strCliente, dblIImporte, dblIImportePenalidad, _
                                                    strTienda, strDevdinero, dblIImporteDevolucion, strDocFi, strBanco, strTipoPago)

        oSAPProxy = Nothing

        Return strDOCNUMFB01

    End Function

    Public Function CancelarApartadoDefinitivo(ByVal ds As DataSet, ByVal ApartadoId As String, ByVal referencia As String, ByVal Tienda As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZCANCELAR_APARTADODEFINITIVO(ds, ApartadoId, referencia, Tienda)

        oSAPProxy = Nothing

    End Function


    Public Function ExistenciasUpdate(ByVal dtProductos As DataTable) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Z_FM_COMMX001_EXISTENCIAS_UPD(dtProductos)

        oSAPProxy = Nothing

    End Function



    Public Function CancelarApartadoNC(ByVal ds As DataSet, ByVal strDevEfec As String, ByVal strPena As Decimal, ByVal strDivision As String, ByVal strAlmacen As String, ByVal strFolioContrato As Integer, ByVal ReferenciaContrato As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZCANCELAR_APARTADONC(ds, strDevEfec, strPena, strDivision, strAlmacen, strFolioContrato, ReferenciaContrato)

        oSAPProxy = Nothing

    End Function

    Public Function GenerarValeCajaDPVL(ByVal strCliente As String, ByVal strImporte As String, ByVal strDivision As String, ByVal strAlmacen As String, ByVal strFIDOCUMENT As String, ByVal MotivoPedido As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZGENERARVALECAJADPVL(strCliente, strImporte, strDivision, strAlmacen, strFIDOCUMENT, MotivoPedido)

        oSAPProxy = Nothing



    End Function

    Public Function Write_CancelaAbonoApartado(ByVal strCliente As String, ByVal Fecha As String, ByVal dblIImporte As Double, _
                                                    ByVal CuentaMayor As String, ByVal strDocFi As String, ByVal GSBER As String, _
                                                    ByVal Werks As String, ByRef strError As String, ByVal strReferencia As String) As String

        Dim strDOCNUMFB01 As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        strDOCNUMFB01 = oSAPProxy.Write_CancelacionAbonoApartadoSAPFI04(strCliente, Fecha, dblIImporte, CuentaMayor, strDocFi, GSBER, Werks, strError, strReferencia)

        oSAPProxy = Nothing

        Return strDOCNUMFB01

    End Function

    Public Function Write_RegistroApartado(ByVal strFolioapartado As String, ByVal dtApart As DataTable) As String

        Try
            Dim strRDocfic As String
            Dim oSAPProxy As New ProcesoSAPProxy(Me)
            '*****************************************************
            Dim oPartado As ZDP_PRODAPARTADO()
            Dim oAPdo As New ZDP_PRODAPARTADO
            Dim i As Integer = 0
            Dim odrArticulo As DataRow
            For Each odrArticulo In dtApart.Rows
                oAPdo.Contrato = strFolioapartado
                oAPdo.Cantidad = odrArticulo("Cantidad")
                oAPdo.Matnr = odrArticulo("CodArticulo")
                oAPdo.Talla = FormatTalla(odrArticulo("numero"))
                ReDim Preserve oPartado(i)                  'Agrego otro clase al arreglo
                oPartado(i) = oAPdo                         'Le asigno la clase al arreglo
                oAPdo = New ZDP_PRODAPARTADO                'Limpio la clase
                i = i + 1
            Next
            '*****************************************************

            strRDocfic = oSAPProxy.Write_RegistroApartadoSAPMM13(strFolioapartado, oPartado)

            oSAPProxy = Nothing

            Return strRDocfic

        Catch ex As Exception

            Throw ex

        End Try

    End Function
    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 05/07/2013: Se agrego un parametro esta para registrar los pedidos del SiHay
    '-------------------------------------------------------------------------------------------------------------------------------

    Public Function Write_Anticipoapartado(ByVal strNumdocRef As String, ByVal dblImporte As Double, ByVal strCodCliente As String, _
                                            ByVal strContrato As String, ByVal strTipoMovieminto As String, ByVal strNombreTienda As String, _
                                            ByVal strcuenta As String, ByVal strDivision As String, ByVal strNumTienda As String, _
                                            ByVal strNoAfil As String, Optional ByVal ZSH_FPAGO As String = "", Optional ByRef strErrorLog As String = "", Optional ByVal Mod_Ped As String = "") As String
        Try

            Dim strDocfic As String
            Dim oSAPProxy As New ProcesoSAPProxy(Me)
            strDocfic = oSAPProxy.Write_AnticipoApartadoSAPFI02(strNumdocRef, dblImporte, strCodCliente, strContrato, strTipoMovieminto, strNombreTienda, strcuenta, strDivision, strNumTienda, strNoAfil, ZSH_FPAGO, strErrorLog, Mod_Ped)
            oSAPProxy = Nothing
            Return strDocfic

        Catch ex As Exception

            Throw ex

        End Try


    End Function

    Friend Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber & ".0"
            End If
        End If
        Return strNumber
    End Function

#End Region


#Region "ZPP_COBRANZAS"

    Friend Sub Write_ZPP_COBRANZAS(ByVal TIENDA As String, ByVal CLACOBR As String, ByVal BANCO As String _
                            , ByVal HKONT As String, ByVal WERKS As String, ByVal GSBER As String)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertZPP_COBRANZAS(TIENDA, CLACOBR, BANCO, HKONT, WERKS, GSBER)

    End Sub

    Friend Function Read_ZPP_COBRANZAS() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ZPP_COBRANZAS

        oSAPProxy = Nothing

        Return oResult

    End Function



#End Region


#Region "Factura"
    Public Function Write_Actualiza_Dips(ByVal strCliente As String) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.ZBAPI_ACTUALIZA_DIPS(strCliente)

    End Function
    Public Function Write_Select_Dips(ByVal strCliente As String) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.ZBAPI_SELECT_DIPS(strCliente)

    End Function

    Public Sub Write_FacturaSAP(ByVal oVentasFacturaSAP As VentasFacturaSAP, Optional ByRef bReintento As Boolean = False)

        'Dim oSAPProxy As New ProcesoSAPProxy(Me)

        'Select Case oVentasFacturaSAP.TipoVenta

        '    Case "P", "S", "E"    '--Publico Gral.

        '        '-------------------------------------------------------------------------
        '        ' JNAVA (2.03.2015): Agregamos la Forma de pago de DP CARD (DPCA)
        '        '-------------------------------------------------------------------------
        '        If oVentasFacturaSAP.ZonaVenta = "EFEC" Then
        '            oSAPProxy.Write_FacturaSAP_PG_EFEC(oVentasFacturaSAP)
        '        ElseIf oVentasFacturaSAP.ZonaVenta = "TACR" Or oVentasFacturaSAP.ZonaVenta = "TADB" Or oVentasFacturaSAP.ZonaVenta = "DPCA" Then
        '            oSAPProxy.Write_FacturaSAP_PG_TARJ(oVentasFacturaSAP)
        '        ElseIf oVentasFacturaSAP.ZonaVenta = "VCJA" Then
        '            oSAPProxy.Write_FacturaSAP_PG_VCJA(oVentasFacturaSAP)
        '        End If

        '    Case "I"      '--Fact. Fiscal

        '        '-------------------------------------------------------------------------
        '        ' JNAVA (2.03.2015): Agregamos la Forma de pago de DP CARD (DPCA)
        '        '-------------------------------------------------------------------------
        '        If oVentasFacturaSAP.ZonaVenta = "EFEC" Then
        '            oSAPProxy.Write_FacturaSAP_FIS_EFEC(oVentasFacturaSAP)
        '        ElseIf oVentasFacturaSAP.ZonaVenta = "TACR" Or oVentasFacturaSAP.ZonaVenta = "TADB" Or oVentasFacturaSAP.ZonaVenta = "DPCA" Then
        '            oSAPProxy.Write_FacturaSAP_PG_TARJ(oVentasFacturaSAP)
        '        ElseIf oVentasFacturaSAP.ZonaVenta = "VCJA" Then
        '            oSAPProxy.Write_FacturaSAP_PG_VCJA(oVentasFacturaSAP)
        '        End If

        '    Case "V"    '--DPVALE
        '        If oSAPConfiguration.DPValeSAP Then
        '            'oSAPProxy.Write_FacturaSAP_DPVale_SAP(oVentasFacturaSAP)
        '            Dim bDesconexion As Boolean = False
        '            Dim inicio As Long, fin As Long, tiempofinal As Decimal
        '            If bReintento = False Then

        '                inicio = DateTime.Now.Ticks
        '                bDesconexion = oSAPProxy.ZBAPISD10_VENTA_DPVALE(oVentasFacturaSAP)
        '                fin = DateTime.Now.Ticks
        '                tiempofinal = (fin - inicio) / TimeSpan.TicksPerMillisecond
        '                'EscribeLog("Milisegundos: " & CStr(tiempofinal), "ZBAPISD10_VENTA_DPVALE")
        '                'Console.WriteLine("ZBAPISD10_VENTA_DPVALE Milisegundos: " & CStr(tiempofinal))
        '            End If

        '            '-----------------------------------------------------------------------------------------------------------------------------------
        '            'RGERMAIN 17.05.2014: Agregamos funcionalidad de reintento de guardado cuando hay error por desconexion a SAP
        '            '-----------------------------------------------------------------------------------------------------------------------------------
        '            If bDesconexion OrElse bReintento Then
        '                If bDesconexion Then bReintento = True
        '                inicio = DateTime.Now.Ticks
        '                oSAPProxy.ZDPVL_REINTENTOVENTA(oVentasFacturaSAP)
        '                fin = DateTime.Now.Ticks
        '                tiempofinal = (fin - inicio) / TimeSpan.TicksPerMillisecond
        '                'EscribeLog("Milisegundos: " & CStr(tiempofinal), "ZDPVL_REINTENTOVENTA")
        '                'Console.WriteLine("ZDPVL_REINTENTOVENTA Milisegundos: " & CStr(tiempofinal))
        '            End If

        '            If oVentasFacturaSAP.FolioFISAP.Trim <> "" AndAlso oVentasFacturaSAP.FolioSAP.Trim <> "" Then
        '                inicio = DateTime.Now.Ticks
        '                oSAPProxy.ZDPVL_LOGACTIVAS_FINALIZAR(oVentasFacturaSAP.DPValeVentaID)
        '                fin = DateTime.Now.Ticks
        '                tiempofinal = (fin - inicio) / TimeSpan.TicksPerMillisecond
        '                'EscribeLog("Milisegundos: " & CStr(tiempofinal), "ZDPVL_LOGACTIVAS_FINALIZAR")
        '                'Console.WriteLine("ZDPVL_LOGACTIVAS_FINALIZAR Milisegundos: " & CStr(tiempofinal))
        '            End If
        '        Else
        '            oSAPProxy.Write_FacturaSAP_DPVale(oVentasFacturaSAP)
        '        End If
        '    Case "D"    '--DIP'S
        '        oSAPProxy.Write_FacturaSAP_FONACOT_FACILITO_DIPS(oVentasFacturaSAP)

        '    Case "A"    '--Apartados
        '        oSAPProxy.Write_FacturaSAP_FONACOT_FACILITO_DIPS(oVentasFacturaSAP)

        '    Case "F", "K"   '--FONACOT
        '        oSAPProxy.Write_FacturaSAP_FONACOT_FACILITO_DIPS(oVentasFacturaSAP)

        '    Case "O"    '--FACILITO
        '        oSAPProxy.Write_FacturaSAP_FONACOT_FACILITO_DIPS(oVentasFacturaSAP)
        'End Select

        'oSAPProxy = Nothing

    End Sub

    Private Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New System.IO.StreamWriter(Environment.CurrentDirectory & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub

    Public Function GetCreditoAsociadoSAP(ByVal IDAsociadoSAP As String) As CreditoAsociadoSAP

        Dim oResult As New CreditoAsociadoSAP

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oResult = oSAPProxy.Read_CreditoAsociadoSAP(IDAsociadoSAP)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function ZRFC_DESCDIPS(ByVal IDAsociadoSAP As String) As Decimal

        Dim oResult As Decimal = 0

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oResult = oSAPProxy.ZRFC_DESCDIPS(IDAsociadoSAP)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function ZRFC_INSERTA_TIEMPOS(ByVal FolioSAP As String, ByVal TipoDoc As String, ByVal TimeOper As String, ByVal TimeSis As String) As String

        Dim oResult As String = ""

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oResult = oSAPProxy.ZRFC_INSERTA_TIEMPOS(FolioSAP, TipoDoc, TimeOper, TimeSis)

        oSAPProxy = Nothing

        Return oResult

    End Function

#End Region


#Region "pedido-traslado"
    '--------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/03/2014: Realiza el traslado de Defectuoso
    '--------------------------------------------------------------------------------------------------------------------

    Public Function ZMM_PROCESO_ENVIO_DEFECTUOSOS(ByVal ImportParameter As Hashtable, ByRef ExportParameter As Hashtable, ByVal dtMateriales As DataTable) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMM_PROCESO_ENVIO_DEFECTUOSOS(ImportParameter, ExportParameter, dtMateriales)
    End Function


    Public Function pedido_trasladomm02(ByVal odtArticulosTras As DataTable, ByVal strcentrodes As String, ByVal strAlmacen As String, Optional guia As Hashtable = Nothing) As String
        '************ Emanuel Vega **********************
        Dim oPartado As ZDP_PRODAPARTADO()
        Dim oAPdo As New ZDP_PRODAPARTADO
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim i As Integer = 0
        Dim odrArticulo As DataRow

        For Each odrArticulo In odtArticulosTras.Rows
            oAPdo.Contrato = strcentrodes
            oAPdo.Cantidad = odrArticulo("Cantidad")
            oAPdo.Matnr = odrArticulo("CodArticulo")
            If IsDBNull(odrArticulo("Serie")) = False Then
                oAPdo.Serie = odrArticulo("Serie")
            End If
            oAPdo.Talla = FormatTalla(odrArticulo("Talla"))
            oAPdo.MotivoDefectuoso = odrArticulo("MotivoDefectuoso")
            oAPdo.ClaveConfirm = odrArticulo("ClaveConfirm")
            ReDim Preserve oPartado(i)                  'Agrego otro clase al arreglo
            oPartado(i) = oAPdo                         'Le asigno la clase al arreglo
            oAPdo = New ZDP_PRODAPARTADO                'Limpio la clase
            i = i + 1
        Next

        Return oSAPProxy.Write_pedidotrasSAPMM02(oPartado, strAlmacen, guia)

    End Function

    'Agrega materiales a un traslado ya existente
    Public Function ZMM_TRASLADO_ME22N(ByVal FolioTraslado As String, ByVal dtMateriales As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZMM_TRASLADO_ME22N(FolioTraslado, dtMateriales)

    End Function

    'Aplica 351 a los materiales que haga falta de un traslado (parcial)
    Public Function ZMM_351_PIEZAS_RESTANTES(ByVal FolioTraslado As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZMM_351_PIEZAS_RESTANTES(FolioTraslado)

    End Function

    Public Function trasladomm02(ByVal strnumpedido As String, ByVal strobservaciones As String, ByVal strAlmacenDestino As String) As String
        '************ Emanuel Vega **********************
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Write_TrasladoSAPMM02(strnumpedido, strobservaciones, strAlmacenDestino)

    End Function

    Public Function Read_TraspasosEspera(ByVal dateFechaini As Date, ByVal dateFechaFin As Date, ByVal strI_EBELN As String, _
                                         ByVal strGeneral As String, ByVal RecibirParcial As Boolean, Optional ByRef bRes As Boolean = True, _
                                         Optional ByVal CentroSAP As String = "") As DataTable

        '************ Ramiro Alcaraz Flores **********************
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Read_TraspasosEspera(dateFechaini, dateFechaFin, strI_EBELN, strGeneral, RecibirParcial, bRes, CentroSAP)

    End Function

    Public Function Read_TraspasosPendientes(ByVal dateFechaini As Date, ByVal dateFechaFin As Date, ByVal strI_EBELN As String, _
                                             ByVal strGeneral As String, _
                                             Optional ByVal CentroSAP As String = "", Optional ByVal Material As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Read_TraspasosPendientesXgrabar(dateFechaini, dateFechaFin, strI_EBELN, strGeneral, CentroSAP, Material)

    End Function

    Public Function Write_TrasladoEntradaSAPMM02(ByVal strpedido As String) As String

        '************ Ramiro Alcaraz Flores **********************
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Write_TrasladoEntradaSAPMM02(strpedido)

    End Function

    Public Function Write_TrasladoEntradaParcialSAPMM02(ByVal strFolioTraslado As String, ByVal dtMateriales As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_AplicaTrasladoEntradaParcial(strFolioTraslado, dtMateriales)

    End Function


    Public Sub LoadDataFromSAPtoDBNew(ByVal strFile As String, ByVal Descarga As Integer)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.LoadDataFromSAPtoDB(strFile, Descarga)

    End Sub



#End Region


#Region "Abonos Facturas Credito Asociados DIPS"

    Public Function Read_ZBAPI_EXTFACTABONOS(ByVal strCliente As String) As DataTable

        '************ Ramiro Alcaraz Flores **********************
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_EXTFACTABONOS(strCliente)

        oSAPProxy = Nothing

    End Function

    Public Function Write_ZBAPIFI06_REG_ABONO_PAGO_VENTA(ByVal strTIENDA As String, ByVal strCliente As String, ByVal dblIMPORTE As Double, _
                                                      ByVal strFacturaFI As String, ByVal strCLACOBR As String, ByVal strBANCO As String, _
                                                    ByVal strFactDpPro As String, ByVal strDetalle As String, ByVal strRefBanco As String) As String()
        '************ Ramiro Alcaraz Flores **********************
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPIFI06_REG_ABONO_PAGO_VENTA(strTIENDA, strCliente, dblIMPORTE, strFacturaFI, strCLACOBR, strBANCO, strFactDpPro, strDetalle, strRefBanco)
        oSAPProxy = Nothing

    End Function

#End Region


#Region "UPC"

    'Public Function Read_UPC() As DataTable

    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Dim oResult As DataTable

    '    oResult = oSAPProxy.Read_UPC

    '    oSAPProxy = Nothing

    '    Return oResult

    'End Function

    Public Sub Write_UPC(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarUPC(oRow)

        oSAPDG = Nothing

    End Sub
    Public Sub Write_UPCServer(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarUPCServer(oRow)

        oSAPDG = Nothing

    End Sub

    Public Sub Write_UPC_From_Separaciones(ByVal oRow As DataRow)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarUPC_From_Separaciones(oRow)

        oSAPDG = Nothing

    End Sub

    Public Sub Write_UPCDirecto()

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.InsertarUPCDirecto()

        oSAPDG = Nothing

    End Sub


#End Region



#Region "Consulta Existencias en SAP"

    Public Function Read_ExistenciasSAP(ByVal strarticulo As String, ByVal strcentro As String, ByVal strtodos As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_ExistenciasSAP(strarticulo, strcentro, strtodos)

        oSAPProxy = Nothing

        Return oResult

    End Function

    

#End Region


#Region "Consulta Estado Cuenta Cliente SAP"


    Public Function Read_ZBAPI_EDOCUENTAXCLIENTE(ByVal strCliente As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_EDOCUENTAXCLIENTE(strCliente)

        oSAPProxy = Nothing

        Return oResult

    End Function


    Public Function Read_ZBAPI_CONSULTAFACTURAS(ByVal strFactura As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPI_CONSULTAFACTURAS(strFactura)

        oSAPProxy = Nothing

        Return oResult

    End Function


#End Region


#Region "Compensación VC"

    'Public Function Write_CompensacionVC(ByVal decMontoUtilizado As Decimal, ByVal strFIDocument As String, ByVal strFIFactura As String) As String
    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Dim oResult As String

    '    oResult = oSAPProxy.Write_ZBAPI_CompensacionVC(decMontoUtilizado, strFIDocument, strFIFactura)

    '    oSAPProxy = Nothing

    '    Return oResult
    'End Function

    Public Function Write_AJUSTE(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, Optional ByVal dttemp As DataTable = Nothing) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String

        oResult = oSAPProxy.Write_ZBAPI_AJUSTE(oAjusteInfo, dttemp)

        oSAPProxy = Nothing

        Return oResult
    End Function

    Public Function Write_AJUSTESOB(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, ByVal strFolio As String, ByVal strCodigo As String, ByVal intCantidad As Integer, ByVal strTalla As String, Optional ByVal dttemp As DataTable = Nothing) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String

        oResult = oSAPProxy.Write_ZBAPI_AJUSTESOB(oAjusteInfo, strFolio, strCodigo, intCantidad, strTalla, dttemp)

        oSAPProxy = Nothing

        Return oResult
    End Function

    Public Function Write_AJUSTETalla(ByVal oAjusteInfo As AjusteGeneralTallaInfo) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String

        oResult = oSAPProxy.Write_ZBAPI_AJUSTETalla(oAjusteInfo)
        'oResult = oSAPProxy.AplicarMB1B(oAjusteInfo)

        oSAPProxy = Nothing

        Return oResult
    End Function

#End Region


#Region "Descuentos Diarios"

    Public Function SeleccionaArticulos(ByVal group As Boolean, Optional ByVal bolaccText As Boolean = False) As DataSet

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        Return oSAPDG.SeleccionaArticulos(group, bolaccText)

    End Function

    Public Sub GetCondicionVenta(ByVal oCondicionVenta As CondicionesVtaSAP)

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        oSAPDG.SelectCondicionVenta(oCondicionVenta)

    End Sub


#End Region


#Region "OTROS"

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los centros en base al canal de distribución
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZRFC_CENTROS_CDIS(ByVal Canal As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim dtResult As DataTable

        dtResult = oSAPProxy.ZRFC_CENTROS_CDIS(Canal)

        oSAPProxy = Nothing

        Return dtResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para guardar el número celular de los clientes
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZRFC_INSERTA_DATOS_SMS(ByVal LADA As String, ByVal NumCel As String, ByVal FormaPago As String, ByVal CodCliente As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZRFC_INSERTA_DATOS_SMS(LADA, NumCel, FormaPago, CodCliente)

        oSAPProxy = Nothing

        Return oResult

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para guardar el número celular y email de los clientes
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZRFC_INSERTA_DATOS_PROMO(ByVal LADA As String, ByVal NumCel As String, ByVal FormaPago As String, ByVal CodCliente As String, _
                                           ByVal Email As String, ByVal FolioSAP As String, ByVal KeyDPPRO As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZRFC_INSERTA_DATOS_PROMO(LADA, NumCel, FormaPago, CodCliente, Email, FolioSAP, KeyDPPRO)

        oSAPProxy = Nothing

        Return oResult

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los folios de concentracion por tienda
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZGET_CONCENTRACIONES(ByVal OficinaVta As String, ByVal Almacen As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZGET_CONCENTRACIONES(OficinaVta, Almacen)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para actualizar el status de la concentración en SAP
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSET_CONCENT_STATUS(ByVal Folio As String, ByVal Status As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String

        oResult = oSAPProxy.ZSET_CONCENT_STATUS(Folio, Status)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para guardar el rango de guias por paqueteria de una tienda
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZGUIAS_INSERTAR_RANGO(ByVal Paqueteria As String, ByVal FolioIni As String, ByVal FolioFin As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZGUIAS_INSERTAR_RANGO(Paqueteria, FolioIni, FolioFin)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para validar una guia en SAP
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZGUIAS_VALIDAR(ByVal Paqueteria As String, ByVal Guia As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZGUIAS_VALIDAR(Paqueteria, Guia)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para actualizar el status de una guia
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZGUIAS_UTILIZAR(ByVal Paqueteria As String, ByVal Guia As String, ByVal Cancelada As Boolean) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZGUIAS_UTILIZAR(Paqueteria, Guia, Cancelada)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para grabar la guia utilizada para enviar el pedido
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_GRABAR_ENVIO(ByVal Pedido As String, ByVal Paqueteria As String, ByVal Guia As String, ByVal bEnviarCorreos As Boolean, ByVal Entrega As String, ByVal SolicitudID As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZPOL_GRABAR_ENVIO(Pedido, Paqueteria, Guia, bEnviarCorreos, Entrega, SolicitudID)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para revisar que un traspaso haya aplicado totalmente el 351 a todas sus posiciones
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZMM_VALIDA_TRASLADO_AL_100(ByVal Traslado As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZMM_VALIDA_TRASLADO_AL_100(Traslado)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para borrar un traspaso y hacer el 352 a sus posiciones en caso de ser necesario
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZMM_BORRAR_TRASLADO_Y_352(ByVal Traslado As String, ByVal b352 As Boolean) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZMM_BORRAR_TRASLADO_Y_352(Traslado, b352)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para actualizar los datos de un traspaso cancelado desde EC en la tabla de pedidos cancelados de la USI
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_USI_CANCELA_PEDIDO_352(ByVal Pedido As String, ByVal CentroSAP As String, ByVal Folio352 As String, ByVal User As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As String = ""

        oResult = oSAPProxy.ZPOL_USI_CANCELA_PEDIDO_352(Pedido, CentroSAP, Folio352, User)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los datos de envio de una factura o traslado
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_DATOS_ENVIO(ByVal Pedido As String, ByRef dtDatosG As DataTable) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZPOL_DATOS_ENVIO(Pedido, dtDatosG)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los rangos de guia de una paqueteria para este centro
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZGUIAS_RANGOS_RETR(ByVal Paqueteria As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZGUIAS_RANGOS_RETR(Paqueteria)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener las paqueterias
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPAQUETERIAS_RETR() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZPAQUETERIAS_RETR

        oSAPProxy = Nothing

        Return oResult

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los motivos de negacion de surtido a un pedido de Ecommerce
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_GET_MOTIVOS(ByVal Modulo As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZPOL_GET_MOTIVOS(Modulo)

        oSAPProxy = Nothing

        Return oResult

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los materiales marcados como de baja calidad para vender por Ecommerce
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_GET_DEFT_CENTRO(Optional ByVal Centro As String = "", Optional ByVal historico As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZPOL_GET_DEFT_CENTRO(Centro, historico)

        oSAPProxy = Nothing

        Return oResult

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los datos de una factura en SAP
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSD_DATOS_FACTURA_GRAL(ByVal FacturaSAP As String, ByRef dtCliente As DataTable, ByRef dtFactura As DataTable, ByRef decImporte As Decimal, _
                                           ByRef CodVend As String, ByRef FolioCupon As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZSD_DATOS_FACTURA_GRAL(FacturaSAP, dtCliente, decImporte, dtFactura, CodVend, FolioCupon)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Function ZPOL_VERSION_D_FACTURA(ByVal FacturaEC As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZPOL_VERSION_D_FACTURA(FacturaEC)
    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para actualizar el status en la tabla de comunicacion entre el PRO y el portal de los pedidos creados en EC e insertar los materiales confirmados
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Sub ZPOL_ACTTRASL(ByVal PedidoEC As String, ByVal FolioTS As String, ByVal Status As String, ByVal FacturaEC As String, ByVal Responsable As String, _
                             ByVal dtConfirmados As DataTable, ByVal ID_Solicitud As String)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ZPOL_ACTTRASL(PedidoEC, FolioTS, Status, FacturaEC, Responsable, dtConfirmados, ID_Solicitud)

        oSAPProxy = Nothing

    End Sub
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC que inserta los materiales negados de un pedido de EC en SAP
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Sub ZPOL_TRASL_NEGAR(ByVal FolioSAP As String, ByVal TipoMov As String, ByVal Responsable As String, ByVal dtNegados As DataTable)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ZPOL_TRASL_NEGAR(dtNegados, FolioSAP, TipoMov, Responsable)

        oSAPProxy = Nothing

    End Sub
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para marcar o desmarcar los materiales como defectuosos para Ecommerce
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_DEFECTUOSOS_INS(ByVal FolioSAP As String, ByVal TipoMov As String, ByVal Responsable As String, ByVal dtDefectuososEC As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZPOL_DEFECTUOSOS_INS(dtDefectuososEC, FolioSAP, TipoMov, Responsable)

        oSAPProxy = Nothing

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC que realiza la entrada del producto (101) lo asigna al pedido y genera la entrega, realiza el picking y la contabilizacion y salida de mercancia y genera la factura
    'y el documento contable
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_TRASLADO_A_FACTURA(ByVal PedidoEC As String, ByVal dtTraspasos As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZPOL_TRASLADO_A_FACTURA(PedidoEC, dtTraspasos)

    End Function
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'RFC que realiza el picking, packing y la contabilizacion y salida de la mercancia
    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_CHK_CONCENTRA(ByVal FolioPedido As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZPOL_CHK_CONCENTRA(FolioPedido)

    End Function

    Public Function ZRFCDPVL_FACTURAS_X_VALE(ByRef Fecha As Date) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZRFCDPVL_FACTURAS_X_VALE(Fecha)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_CHECK_PROMOS_VIGENTES(ByRef dtPromos As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_CHECK_PROMOS_VIGENTES(dtPromos)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_UPD_PROMOS_VIGENTES(ByVal TipoDesc As Integer) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_UPD_PROMOS_VIGENTES(TipoDesc)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDA_VALE_EMPLEADO(ByVal ValeE As ValeEmpleado) As ValeEmpleado

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDA_VALE_EMPLEADO(ValeE)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_REVIVE_VALE_EMPLEADO(ByVal FolioSAP As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_REVIVE_VALE_EMPLEADO(FolioSAP)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_QUEMA_VALE_EMPLEADO(ByVal Folio As String, ByVal Serie As String, ByVal FolioSAP As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_QUEMA_VALE_EMPLEADO(Folio, Serie, FolioSAP)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_QUEMA_CUPON_DESCUENTO(ByVal Folio As String, ByVal TipoVenta As String, ByVal FolioSAP As String, _
    ByRef FolioNuevo As String, ByVal formasPago As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_QUEMA_CUPON_DESCUENTO(Folio, TipoVenta, FolioSAP, FolioNuevo, formasPago)

        oSAPProxy = Nothing

    End Function

    Public Sub SaveDownloadBackground(ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos, ByVal CodAlmacen As String, ByVal CodCaja As String)

        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)

        oSAPProxy.SaveDownloadBackground(oConfigCierreFI, CodAlmacen, CodCaja)

        oSAPProxy = Nothing

    End Sub


    Public Function IsDownloadBackground(ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos, ByVal CodAlmacen As String, ByVal CodCaja As String) As Boolean

        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)

        Return oSAPProxy.IsDownloadBackground(oConfigCierreFI, CodAlmacen, CodCaja)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_GENERA_REVALE_EMPLEADO(ByVal FolioSAP As String, ByRef ValeE As ValeEmpleado) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GENERA_REVALE_EMPLEADO(FolioSAP, ValeE)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_GENERA_RECUPON(ByRef oReCupon As CuponDescuento, ByVal FolioSAP As String, ByRef FolioCupon As String, ByVal Descuento As Decimal, ByVal Minimo As Decimal) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GENERA_RECUPON(oReCupon, FolioSAP, FolioCupon, Descuento, Minimo)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_REVIVE_CUPON(ByVal FolioCupon As String, Optional ByRef cuponPadre As String = "") As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_REVIVE_CUPON(FolioCupon, cuponPadre)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_ACTUALIZA_RECUPON(ByVal FolioCupon As String, ByVal FolioSAP As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_ACTUALIZA_RECUPON(FolioCupon, FolioSAP)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_ANULAR_AJUSTE_TE(ByVal strFolio As String) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.WRITE_ZBAPI_ANULAR_AJUSTE_TE(strFolio)

        oSAPProx = Nothing

    End Function

    Public Function ZBAPI_VALIDAR_DEVOLUCION(ByVal strKEY As String, ByRef dt As DataTable) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.WRITE_ZBAPI_VALIDAR_DEVOLUCION(strKEY, dt)

        oSAPProx = Nothing

    End Function

    Public Sub DeleteCatalogo(ByVal strCatalogo As String)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.DeleteCatalogo(strCatalogo)
        oSAPProxy = Nothing
    End Sub

    Public Sub DeleteCatalogoCentros()
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.DeleteCatalogoCentros()
        oSAPProxy = Nothing
    End Sub

    Public Sub DeleteTotalesExistencias(Optional ByVal CodArticulo As String = "")
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.DeleteTotalesExistencia(CodArticulo)
        oSAPProxy = Nothing
    End Sub

    Public Function GetAllExistencias(Optional ByVal CodArticulo As String = "") As DataTable
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        Return oSAPProxy.SelectExistenciasAll(CodArticulo)
        oSAPProxy = Nothing
    End Function

    Public Function GetFoliosPickUp(ByVal Paqueteria As String, ByVal oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos) As DataTable
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        Return oSAPProxy.SelectFoliosPickUp(Paqueteria, oConfigCierreFI)
        oSAPProxy = Nothing
    End Function


    Public Sub UpdateExistenciaSAPCAR(ByVal CodArticulo As String, ByVal Total As Decimal, ByVal Apartados As Decimal, ByVal Defectuosos As Decimal, ByVal Consignacion As Decimal, ByVal Transito As Decimal)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateExistenciaSAPCAR(CodArticulo, Total, Apartados, Defectuosos, Consignacion, Transito)
        oSAPProxy = Nothing
    End Sub


    Public Sub UpdateExistenciaSAP(ByVal CodArticulo As String, ByVal Total As Decimal, ByVal Apartados As Decimal, ByVal Defectuosos As Decimal, ByVal Numero As String)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateExistenciaSAP(CodArticulo, Total, Apartados, Defectuosos, Numero)
        oSAPProxy = Nothing
    End Sub

    Public Sub UpdateInsertExistencias(ByVal oRow As DataRow)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateInsertExistencias(oRow)
        oSAPProxy = Nothing
    End Sub


    Public Sub UpdateCostoPromedio(ByVal dtResult As DataTable, ByVal Opcion As Integer)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateCostoPromedio(dtResult, Opcion)
        oSAPProxy = Nothing
    End Sub

    Public Sub UpdateCondicionesVenta(ByVal dtResult As DataTable)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateCondicionesVenta(dtResult)
        oSAPProxy = Nothing
    End Sub


    Public Sub InsertUpdCatalogoArticulos(ByVal dtResult As DataTable)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.InsertUpdCatalogoArticulos(dtResult)
        oSAPProxy = Nothing
    End Sub

    Public Sub InsertUpdCatalogoUPC(ByVal dtResult As DataTable)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.InsertUpdCatalogoUPC(dtResult)
        oSAPProxy = Nothing
    End Sub

    Public Sub ActualizaSaldosExistencia(ByVal MesActual As Integer)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateSaldosExistencia(MesActual)
        oSAPProxy = Nothing
    End Sub

    Public Sub ActualizaSaldosExistenciaPorCodigo(ByVal CodArticulo As String, ByVal Talla As String, ByVal MesActual As Integer)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateSaldosExistenciaByCodigo(CodArticulo, Talla, MesActual)
        oSAPProxy = Nothing
    End Sub

    Public Sub VenceDescuentoSistema(ByVal CodArticulo As String)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.UpdateFechasDescuentoSistema(CodArticulo)
        oSAPProxy = Nothing
    End Sub

    Public Sub DeleteDescuentosAdicionales(ByVal Opcion As Integer)
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        oSAPProxy.DeleteDescuentosAdicionales(Opcion)
        oSAPProxy = Nothing
    End Sub

    Public Function Read_promocionBonificacionDescuento(ByVal oConfigCierreFi As ConfigSaveArchivos.SaveConfigArchivos) As DataTable
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)

        Dim oResult As DataTable
        oResult = oSAPProxy.Read_promocionBonificacionDescuento(oConfigCierreFi)
        Return oResult
    End Function

    Public Function Write_BonificacionDescuento(ByVal oRow As DataRow)
        Dim oSAPDG As New ProcesoSAPDataGateway(Me)
        oSAPDG.InsertarPromoBonificacionDescuento(oRow)
        oSAPDG = Nothing
    End Function

    Public Function ApartadosDefectuosos() As DataSet
        Dim oSAPProxy As New ProcesoSAPDataGateway(Me)
        Return oSAPProxy.ApartadosDefectuosos()
        oSAPProxy = Nothing
    End Function

    Public Function Read_HistoricoMovimientos(ByVal strCodArticulo As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByRef IntExports() As Integer) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.Read_HistoricoMovimientos(strCodArticulo, FechaInicio, FechaFin, IntExports)

        oSAPProxy = Nothing

        Return oResult
    End Function

    Public Function ZBAPIFI05_VENTASDIA(ByRef strResult As String, ByVal strFname As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZBAPIFI05_VENTASDIA(strResult, strFname)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Sub ReadInfoPaqueteria(ByVal strFolioTranslado As String, ByRef Guia As String, ByRef Transportista As String, ByRef Bultos As Integer)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ReadInfoPaqueteria(strFolioTranslado, Guia, Transportista, Bultos)

        oSAPProxy = Nothing

    End Sub



    '-----------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
    '-----------------------------------------------------------------------------------------------------------------------------------
    'Public Function SaveInfoPaqueteria(ByVal strFolioTranslado As String, ByVal strValor As String, ByVal strElemento As String) As String

    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Return oSAPProxy.SaveInfoPaqueteria(strFolioTranslado, strValor, strElemento)

    '    oSAPProxy = Nothing

    'End Function

#End Region


#Region "Actualiza Direccion Telefono y Email clientes"

    Public Function ActualizaClientes(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
 ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
 , ByVal strColonia As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ActualizaClientes(strClienteID, strCalleNum, strCp, strPoblacion, strEstado, strTelefono, stremail, strColonia)

        oSAPProxy = Nothing


    End Function

#End Region


#Region "Consulta Existencias dl Z001"


    Public Function ZBAPI_CONSULTA_ALLSTOCK(ByRef strCodArticulo As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_CONSULTA_ALLSTOCK(strCodArticulo)

        oSAPProxy = Nothing

    End Function

#End Region

#Region "DPVALE SAP"

    Public Function ZBAPI_VALIDA_DPVALE(ByVal cdpvale As cDPVale) As cDPVale

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDA_DPVALE(cdpvale)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDA_REVALE(ByVal cdpvale As cDPVale) As cDPVale

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDA_DPVALE(cdpvale)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDA_REVALE_Venta(ByVal cdpvale As cDPVale) As cDPVale

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDA_ReVale_Venta(cdpvale)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_NOMBRE_CLIENTE(ByVal strNumAsociado As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_NOMBRE_CLIENTE(strNumAsociado)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDATARJETA(ByVal strNumTarjeta As String) As Boolean

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDANUMTARJETA(strNumTarjeta)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDA_FOLIO_PRO(ByVal FolioSAP As String, ByVal ClienteId As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDA_FOLIO_PRO(FolioSAP, ClienteId, strFIDOCUMENT, strSALESDOCUMENT)

        oSAPProxy = Nothing

    End Function

    Public Function WRITE_ZBAPI_ABONO_CIERREDIA(ByVal oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia, ByRef dt As DataTable)

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        oSAPProx.ZBAPI_ABONO_CIERREDIA(oZBAPI_ABONO_CIERREDIA, dt)

        oSAPProx = Nothing

    End Function
    'Funcion Vale de Caja
    Public Function WRITE_ZBAPI_ABONO_CIERREDIAVC(ByVal strClienteIDVT As String, ByVal strFecha As String, ByVal strFolioFISAP As String, _
    ByVal strClienteIDDV As String, ByVal strFIDOCUMENT As String, ByVal decMonto As Decimal, ByRef dt As DataTable) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.ZBAPI_ABONO_CIERREDIAVC(strClienteIDVT, strFecha, strFolioFISAP, strClienteIDDV, strFIDOCUMENT, decMonto, dt)

        oSAPProx = Nothing

    End Function
    'Funcion Abonos
    Public Function WRITE_ZBAPI_ABONO_CIERREDIAAB(ByVal strClienteID As String, ByVal dtDatos As DataTable, ByRef dt As DataTable) As String

        Dim oSAPProx As New ProcesoSAPProxy(Me)

        Return oSAPProx.ZBAPI_ABONO_CIERREDIAAB(strClienteID, dtDatos, dt)

        oSAPProx = Nothing

    End Function

    Public Function ZBAPI_OBTENER_CLIENTES(ByVal strPalabraFind As String, Tipo As Integer, TipoCliente As Integer, EsDip As Boolean) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_OBTENER_CLIENTES(strPalabraFind, Tipo, TipoCliente, EsDip)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_GET_CLIENTE(ByVal strCodAsociado As String, ByVal TipoVenta As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        oSAPProxy.ConfigCierreFI = ConfigCierreFI
        Return oSAPProxy.ZBAPI_GET_CLIENTE(strCodAsociado, TipoVenta)

        oSAPProxy = Nothing

    End Function

    Public Function ZDPPRO_CENTRONUEVO() As Boolean

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZDPPRO_CENTRONUEVO()

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_VALIDACLIENTEVALECAJA(ByVal FolioFI As String, Optional ByVal PedidoFolioSAP As String = "") As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_VALIDACLIENTEVALECAJA(FolioFI, PedidoFolioSAP)

        oSAPProxy = Nothing

    End Function

    'Public Function ZBAPI_TRASLADO_SALDOS(ByVal strClienteOrigen As String, ByVal strClienteDestino As String, ByVal strFolioFIDev As String) As String ', ByVal strFolioFIVenta As String) As String

    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Return oSAPProxy.ZBAPI_TRASLADO_SALDOS(strClienteOrigen, strClienteDestino, strFolioFIDev) ', strFolioFIVenta)

    '    oSAPProxy = Nothing

    'End Function

    Public Function ZPOL_TRASLPEN(ByVal Centro As String, ByRef dtDetalle As DataTable, Optional ByRef dtTrasladosModif As DataTable = Nothing) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim dtTemp As DataTable
        Dim dtTempCab As DataTable

        dtTempCab = oSAPProxy.ZPOL_TRASLPEN(Centro, dtDetalle, dtTemp)

        oSAPProxy = Nothing

        If Not dtTrasladosModif Is Nothing Then dtTrasladosModif = dtTemp.Copy

        Return dtTempCab.Copy

    End Function

    Public Function ZPOL_VALIDA_TRAS_ENV(Optional ByVal Centro As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZPOL_VALIDA_TRAS_ENV(Centro)

        oSAPProxy = Nothing

    End Function

    Public Function ZPOL_TBUSCAR_GUIA(Optional ByVal Pedido As String = "", Optional ByVal Guia As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim dtRes As DataTable

        dtRes = oSAPProxy.ZPOL_TBUSCAR_GUIA(Pedido, Guia).Copy

        oSAPProxy = Nothing

        Return dtRes

    End Function


    'Public Function ZPOL_PEDIDOSCANCELADOS(ByRef dtDetalle As DataTable, Optional ByVal Centro As String = "") As DataTable

    '    Dim oSAPProxy As New ProcesoSAPProxy(Me)

    '    Return oSAPProxy.ZPOL_PEDIDOSCANCELADOS(dtDetalle, Centro)

    '    oSAPProxy = Nothing

    'End Function

    Public Function ZBAPIMM14_DESBLOQUEOART(ByVal strContrato As String, ByVal dtMateriales As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPIMM14_DESBLOQUEOART(strContrato, dtMateriales)

    End Function

    Public Function ZBAPI_GET_CLIENTE_BY_RFC(ByVal strRFC As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GET_CLIENTE_BYRFC(strRFC)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_OBTENER_NDESCUENTOS(ByVal plaza As String, ByVal fecha As Date, ByVal monto As Decimal, ByVal strVale As String, _
                                              ByRef FechaCobro As Date, ByRef dtDetalle As DataTable) As Integer

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_OBTENER_NDESCUENTOS(plaza, fecha, monto, strVale, FechaCobro, dtDetalle)

        oSAPProxy = Nothing

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 19.09.2014: Generar ReRevale
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Function ZBAPI_GENERAR_REREVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByVal intPares As Integer, ByRef strResult As String, ByVal Cliente As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GENERAR_REREVALE(strDPvaleID, decMonto, intPares, strResult, Cliente)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_DATOS_CLIENTE(ByVal strruta As String, TipoCliente As Integer) As String()

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_DATOS_CLIENTE(strruta, TipoCliente)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_PRESTAMO_FINANCIERO(ByVal NoDist As String, ByVal Importe As String, _
                                              ByVal Intereses As String, ByVal Plaza As String, _
                                              ByVal NoDPVale As String, ByVal NoDesc As String, _
                                              ByVal NoTarjeta As String, ByVal IFE As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_PRESTAMO_FINANCIERO(NoDist, Importe, Intereses, Plaza, NoDPVale, NoDesc, NoTarjeta, _
                                                   IFE)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_GENERAR_REVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByRef strResult As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GENERAR_REVALE(strDPvaleID, decMonto, strResult)

        oSAPProxy = Nothing

    End Function

#End Region

#Region "FolioDpPro"
    Public Function SelFolioSAPByFolioFI(ByVal strFolioFI As String) As String

        Dim oSAPDG As New ProcesoSAPDataGateway(Me)

        Return oSAPDG.SelFolioSAPByFolioFI(strFolioFI)

        oSAPDG = Nothing

    End Function

    Public Function getFolioDpPro(ByVal BWART As String, ByVal FolioSAP As String, ByVal FolioTras As String) As String
        Dim oSAPDG As New ProcesoSAPDataGateway(Me)
        'If BWART = "344" Then
        '    Dim intContador As Integer = 0, BW As String = "9999", StrReturn As String
        '    Do While intContador < 2
        '        StrReturn = oSAPDG.SelFolioDelMov(BW, FolioSAP, FolioTras)
        '        If StrReturn <> "" Then
        '            Return StrReturn
        '            Exit Do
        '        Else
        '            intContador += 1
        '            BW = "8888"
        '        End If
        '    Loop
        'Else
        Return oSAPDG.SelFolioDelMov(BWART, FolioSAP, FolioTras)
        'End If


        oSAPDG = Nothing

    End Function
#End Region

#Region "FacturacionSiHay"

    Public Function ZSH_DISPONIBILIDAD(ByVal dtArticulos As DataTable, Optional ByVal validarminimos As Boolean = False) As DataSet
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_DISPONIBILIDAD(dtArticulos, validarminimos)
    End Function

    Public Function ZSH_PARTICIPANTES(ByVal I_Tienda As String, Optional ByRef strError As String = "") As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_PARTICIPANTES(I_Tienda, strError)
    End Function

    Public Function ZSH_PEDIDOS_HOMEDASH(ByVal centro As String) As DataSet
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_PEDIDOS_HOMEDASH(centro)
    End Function

    Public Function ZSH_PEDIDOS_PENDIENTES(ByVal Centro As String, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable, ByVal Status As Hashtable, Optional ByVal R_MATERIALES As DataTable = Nothing, Optional ByVal FolioPedido As String = "") As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim dtTempCab As DataTable

        dtTempCab = oSAPProxy.ZSH_PEDIDOS_PENDIENTES(Centro, dtCabecera, dtDetalle, Status, R_MATERIALES, FolioPedido)

        oSAPProxy = Nothing

        Return dtTempCab.Copy

    End Function

    Public Function ZSH_ACTUALIZAR_SOLICITUD(ByVal Modulo As String, ByVal htCabecera As Hashtable, ByVal dtCabecera As DataTable, _
                                             ByRef dtConfirmados As DataTable, ByVal dtNegados As DataTable, Optional ByVal ValeCaja As String = "", _
                                             Optional ByRef strRes As String = "") As Hashtable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZSH_ACTUALIZAR_SOLICITUD(Modulo, htCabecera, dtCabecera, dtConfirmados, dtNegados, ValeCaja, strRes)

        oSAPProxy = Nothing

    End Function

    Public Function ZSH_ACTUALIZAR_SOLICITUD(ByVal Modulo As String, ByVal htCabecera As Hashtable, ByVal dtCabecera As DataRow, _
                                             ByRef dtConfirmados As DataTable, ByVal dtNegados As DataTable, Optional ByVal ValeCaja As String = "", _
                                             Optional ByRef strRes As String = "") As Hashtable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZSH_ACTUALIZAR_SOLICITUD(Modulo, htCabecera, dtCabecera, dtConfirmados, dtNegados, ValeCaja, strRes)

        oSAPProxy = Nothing

    End Function


    '---------------------------------------------------------------------------------------------------------------------------------------------
    'RFC para obtener los datos de envio de un pedido SH
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_DATOS_ENVIO(ByVal Pedido As String, ByRef dtDatosG As DataTable) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZSH_DATOS_ENVIO(Pedido, dtDatosG)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (21/05/2013) - RFC para cancelacion de pedidos insurtible con reembolso en efectivo y/o Vale de caja
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_REEMBOLSO(ByVal FolioPedido As String, ByVal Cliente As String, ByVal Almacen As String, ByVal ImporteValeCaja As Decimal, _
                                  ByVal ImporteEfectivo As Decimal, ByVal Division As String, ByVal Tipo As String, _
                                  Optional ByVal ActualizarSiHay As String = "", Optional ByRef FolioSapFactura As String = "", _
                                  Optional ByVal decDPVale As Decimal = Decimal.Zero, Optional ByVal bRevale As Boolean = False) As Hashtable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZSH_REEMBOLSO(FolioPedido, Cliente, Almacen, ImporteValeCaja, ImporteEfectivo, Division, Tipo, ActualizarSiHay, FolioSapFactura, decDPVale, bRevale)

        oSAPProxy = Nothing

    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/05/2013: RFC para guardar el pedido con sus detalles
    '----------------------------------------------------------------------------------------------------------------------------------------------

    Public Function ZSH_FACTURACION(ByVal exports As Hashtable, ByVal tablas As DataSet) As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZSH_FACTURACION(exports, tablas)

    End Function
    '---------------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 20/05/2013: RFC para facturar los productos pendientes por entregar
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_FACTURAR_IDS(ByVal Pedido As String, ByVal Responsable As String, ByRef dtCabecera As DataTable, ByRef FolioSAP As String, _
                                    ByRef FolioFISAP As String, ByRef htCupon As Hashtable, ByRef strResult As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As DataTable

        oResult = oSAPProxy.ZSH_FACTURAR_IDS(Pedido, Responsable, dtCabecera, FolioSAP, FolioFISAP, htCupon, strResult)

        oSAPProxy = Nothing

        Return oResult

    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Cancela el pedido de SiHay y devuelve las devoluciones de Vales de Cajas y Efectivo
    '----------------------------------------------------------------------------------------------------------------------------------------------

    Public Function ZSH_CANCELAR_SOLICITUDES(ByVal FolioSAP As String, Optional ByVal debug As String = "") As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_CANCELAR_SOLICITUDES(FolioSAP, debug)
    End Function


    Public Function Z_FM_COMMX009_GET_BINFILESTORE(ByVal Centro As String, ByVal File As String) As Byte()
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.Z_FM_COMMX009_GET_BINFILESTORE(Centro, File)
    End Function


    Public Function Z_FM_COMMX006_GET_TXT_FROM_ZIP(ByVal text64 As String) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.Z_FM_COMMX006_GET_TXT_FROM_ZIP(text64)
    End Function


    '----------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Realiza el reembolso en vale de caja y en Efectivo
    '----------------------------------------------------------------------------------------------------------------------------------------------

    Public Function ZSH_REEMBOLSO(ByVal exports As Hashtable) As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_REEMBOLSO(exports)
    End Function

    Public Function ZPEDIDO_N_CURSO(ByVal Pedido As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZPEDIDO_N_CURSO(Pedido)
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 15.07.2013: RFC para crear el SA a partir de los DZ de los Pedidos Si Hay
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_CIERRE(ByVal FechaCierre As Date) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_CIERRE(FechaCierre)
        oSAPProxy = Nothing
    End Function

    Public Function GetFacturasSiHay(ByVal FechaCierre As Date) As DataTable
        Dim oDataGateWay As New ProcesoSAPDataGateway(Me)
        Return oDataGateWay.GetFacturasSiHay(FechaCierre)
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (24/06/2013) - RFC para compensar pedidos si hay
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_COMPENSAR(ByVal FechaCierre As DateTime, ByVal viewFilter As DataView, ByVal datos As Dictionary(Of String, Object)) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_COMPENSAR(FechaCierre, viewFilter, datos)
        oSAPProxy = Nothing
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (04/07/2013) - RFC para obtener desde SAP los importes disponible para Vale de caja, Efectivo y Facilito 
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_CALCULO_REEMBOLSOS(ByVal strFolioPedido As String, Optional ByVal IncluirFacturado As String = "") As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_CALCULO_REEMBOLSOS(strFolioPedido, IncluirFacturado)
        oSAPProxy = Nothing
    End Function

    Public Function ZSH_ES_TIENDA_CATALOGO() As Boolean
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_ES_TIENDA_CATALOGO()
        oSAPProxy = Nothing
    End Function

    Public Function ZSH_CANCELACION_VENTA(ByVal Referencia As String, ByVal FolioSAP As String, ByVal DetalleFactura As DataTable, ByVal Tipo As String, ByRef MontoDPVL As Decimal, ByRef MontoValeCaja As Decimal, Optional ByRef strError As String = "") As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSH_CANCELACION_VENTA(Referencia, FolioSAP, DetalleFactura, Tipo, MontoDPVL, MontoValeCaja, strError)
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (21.03.2017): Nueva RFC para reembolso de SH en SAP
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function Z_MF_FYCMX1005_REEMBOLSO_SH(ByVal FolioPedido As String, ByVal Almacen As String, ByVal ImporteValeCaja As Decimal, ByVal ImporteEfectivo As Decimal, ByVal FolioSapFactura As String, ByVal decDPVale As Decimal, Optional ByVal bRevale As Boolean = False) As Dictionary(Of String, Object)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.Z_MF_FYCMX1005_REEMBOLSO_SH(FolioPedido, Almacen, ImporteValeCaja, ImporteEfectivo, FolioSapFactura, decDPVale, bRevale)

        oSAPProxy = Nothing

    End Function

#End Region

    Public Function IsDownloadAuditoria(ByVal CodAlmacen As String, ByVal Caja As String, ByVal Fecha As DateTime) As Boolean
        Dim sap As New ProcesoSAPDataGateway(Me)
        Return sap.IsDownloadAuditoria(CodAlmacen, Caja, Fecha)
    End Function

    Public Function InsertarDescargaAuditoria(ByVal CodAlmacen As String, ByVal Caja As String)
        Dim sap As New ProcesoSAPDataGateway(Me)
        sap.InsertarDescargaAuditoria(CodAlmacen, Caja)
    End Function
    '-----------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 06/06/2013: RFC para obtener la fecha y hora del servidor de SAP
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Public Function MSS_GET_SY_DATE_TIME() As DateTime

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.MSS_GET_SY_DATE_TIME

        oSAPProxy = Nothing

    End Function

    Public Function ZPOL_REGISTRO_PAGO(ByVal oCabecera As Hashtable, ByVal dtDetalle As DataTable, ByRef strErrorMsg As String) As Boolean

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Dim oResult As Boolean

        oResult = oSAPProxy.ZPOL_REGISTRO_PAGO(oCabecera, dtDetalle, strErrorMsg)

        oSAPProxy = Nothing

        Return oResult

    End Function

    Public Sub ZCS_ALGORITMO_PROMOS(ByVal dtMateriales As DataTable, ByVal TipoVenta As String, ByVal Fecha As Date, ByRef htTotales As Hashtable, _
    ByRef dtMatDesc As DataTable, ByRef dtPromos As DataTable, ByRef dtCrossSelling As DataTable)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ZCS_ALGORITMO_PROMOS(dtMateriales, TipoVenta, Fecha, htTotales, dtMatDesc, dtPromos, dtCrossSelling)

        oSAPProxy = Nothing

    End Sub

    Public Function ZCS_PROMO_VIGENTES(ByVal Fecha As Date, Optional ByRef dtVigencias As DataTable = Nothing) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim dtRes As DataTable

        dtRes = oSAPProxy.ZCS_PROMO_VIGENTES(Fecha, dtVigencias)

        oSAPProxy = Nothing

        Return dtRes

    End Function

#Region "Descuentos Proxima Compra"

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 07/11/2013: Obtener Descuentos Proxima Compra
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Friend Function Read_DescuentoProximaCompra(ByVal Fecha As Date) As DataSet
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim oResult As DataSet
        oResult = oSAPProxy.ZCDES_PROXIMACOMPRA_GET(Fecha)
        oSAPProxy = Nothing
        Return oResult
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 07/11/2013: Guardar Descuentos Proxima Compra SQL
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Friend Function Write_DescuentoProximaCompra(ByVal oRow As DataRow)
        Dim oSAPDG As New ProcesoSAPDataGateway(Me)
        oSAPDG.InsertarDescuentoProximaCompra(oRow)
        oSAPDG = Nothing
    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 08/11/2013: Genera cupon si existe promocion de descuento proxima compra
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZCDES_PROXIMACOMPRA_CREADESCTO(ByVal Fecha As Date, ByVal ImporteFactura As Decimal, ByRef Mensaje As String) As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim oResult As Hashtable
        oResult = oSAPProxy.ZCDES_PROXIMACOMPRA_CREADESCTO(Fecha, ImporteFactura, Mensaje)
        oSAPProxy = Nothing
        Return oResult
    End Function

#End Region

#Region "Captura Motivos de Rechazo DPVale"
    '---------------------------------------------------------------------------------------
    ' JNAVA 06/05/2014 - Se agrego lo correspondiente a la captura de motivos de rechazo
    '---------------------------------------------------------------------------------------
    Public Function ZDPVL_GET_MOTIVOSRECHAZOS() As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZDPVL_GET_MOTIVOSRECHAZOS

        oSAPProxy = Nothing

    End Function

    Public Function ZDPVL_REGISTRAR_RECHAZO(ByVal NumVale As String, ByVal ClaveMotivo As String, ByVal Plaza As String, ByVal TipoVenta As String) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZDPVL_REGISTRAR_RECHAZO(NumVale, ClaveMotivo, Plaza, TipoVenta)

        oSAPProxy = Nothing

    End Function

#End Region

#Region "Venta de Electronicos"

    '---------------------------------------------------------------------------------------
    ' JNAVA 05/12/2014 - Se agrego lo correspondiente a las Ventas de Electronicos
    '---------------------------------------------------------------------------------------

    Public Function ZDPT_GUARDAR_VENTAS_ELEC(ByVal TablaElectronicos As DataTable) As String

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZDPT_GUARDAR_VENTAS_ELEC(TablaElectronicos)

        oSAPProxy = Nothing

    End Function

#End Region

#Region "Entrega de Mercancias de Proveedor"
    Public Function ZMM_ORDENCOMPRA_DETALLE(ByVal orden As String) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Dim dtRes As DataTable

        dtRes = oSAPProxy.ZMM_ORDENCOMPRA_DETALLE(orden)
        Return dtRes
    End Function

    Public Function ZMM_ENTREGA_TIENDA(ByVal orden As String, ByVal AlmacenOrigen As String, ByVal AlmacenDestino As String, ByVal dtTraspaso As DataTable, ByRef documentYear As String, ByRef err As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMM_ENTREGA_TIENDA(orden, AlmacenOrigen, AlmacenDestino, dtTraspaso, documentYear, err)
    End Function
#End Region

#Region "SAP Retail"

    Public Function ZMM_CAMBIOSMATERIALES(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal todo As Boolean, Optional ByVal material As String = "") As DataSet
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMM_CAMBIOSMATERIALES(datFechaIni, datFechaFin, todo, material)
    End Function


    Public Function ZSD_OBTENER_CORREO_OFI_VENTA(ByVal OficinaVtas As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSD_OBTENER_CORREO_OFI_VENTA(OficinaVtas)
    End Function

    Public Function ZFM_COMMX001_DPRO(ByVal strpedido As String, ByVal Materiales As DataTable, ByRef strMensaje As String, ByVal RecibirParcialmente As Boolean, Optional ByRef DocMaterial As String = "") As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZFM_COMMX001_DPRO(strpedido, Materiales, strMensaje, RecibirParcialmente, DocMaterial)
    End Function

    Function ZFMCOM_ACLARACION(ByVal strFolio As String, dvDetalle As DataView, ByVal strTipo As String) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZFMCOM_ACLARACION(strFolio, dvDetalle, strTipo)
    End Function

    Public Function ZBAPISD29_CANCELACION_DPVL_AUT(ByVal FolioSAP As String, ByVal CodVendedor As String, FolioFISAP As String, Optional ByRef strError As String = "") As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZBAPISD29_CANCELACION_DPVL_AUT(FolioSAP, CodVendedor, FolioFISAP, strError)
    End Function

    Public Function ZBAPISD29_CANCELACIONFACT_AUTO(ByVal FolioSAP As String, ByVal CodVendedor As String, ByRef SalesDocument As String, ByRef FIDocument As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZBAPISD29_CANCELACIONFACT_AUTO(FolioSAP, CodVendedor, SalesDocument, FIDocument)
    End Function

    Public Function ZPOL_SURTIDO_ENTREGA(ByVal Pedido As String, ByVal Guia As String, ByVal Paqueteria As String, ByVal dtMateriales As DataTable, ByRef MensajeError As String) As Hashtable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZPOL_SURTIDO_ENTREGA(Pedido, Guia, Paqueteria, dtMateriales, MensajeError)
    End Function

    Public Function Z_FM_COMMX001_TRASL_PEDIDO(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal Status As String) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.Z_FM_COMMX001_TRASL_PEDIDO(FechaInicio, FechaFin, Status)
    End Function

    Public Function ZMF_TALLA_COLOR(ByVal Materiales As DataTable) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMF_TALLA_COLOR(Materiales)
    End Function

    Public Function ZSD_VALIDA_PEDIDOS(ByVal FechaCierre As DateTime) As DataTable
        Dim oSAProxy As New ProcesoSAPProxy(Me)
        Return oSAProxy.ZSD_VALIDA_PEDIDOS(FechaCierre)
    End Function

    Public Function ZSD_VALIDA_PEDIDOS(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSD_VALIDA_PEDIDOS(FechaInicio, FechaFin)
    End Function

    Public Function ZSD_VALIDA_INICIODIA(ByVal OficinaVta As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZSD_VALIDA_INICIODIA(OficinaVta)
    End Function

#End Region

#Region "DPVale AFS"

    Public Function ZBAPI_OBTENER_CLIENTES_DPVALE(ByVal strAsociado As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_OBTENER_CLIENTES_DPVALE(strAsociado)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPI_GET_CLIENTE_DPVALE(ByVal strCodAsociado As String) As DataTable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZBAPI_GET_CLIENTE_DPVALE(strCodAsociado)

        oSAPProxy = Nothing

    End Function

    Public Function ZBAPISD29_CANCELACION_DPVL_AUTAFS(ByVal FolioSAP As String, ByVal CodVendedor As String, FolioFISAP As String, ByVal EntregaDev As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZBAPISD29_CANCELACION_DPVL_AUTAFS(FolioSAP, CodVendedor, FolioFISAP, EntregaDev)
    End Function

    Public Function ZDPVL_VALSEGUROSAFS(ByVal DatosSeguro As Hashtable) As Boolean
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZDPVL_VALSEGUROSAFS(DatosSeguro)
    End Function

    Public Function ZSH_REEMBOLSOAFS(ByVal FolioPedido As String, ByVal Cliente As String, ByVal Almacen As String, ByVal ImporteValeCaja As Decimal, _
                                  ByVal ImporteEfectivo As Decimal, ByVal Division As String, ByVal Tipo As String, _
                                  Optional ByVal ActualizarSiHay As String = "", Optional ByRef FolioSapFactura As String = "", _
                                  Optional ByVal decDPVale As Decimal = Decimal.Zero, Optional ByVal bRevale As Boolean = False) As Hashtable

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        Return oSAPProxy.ZSH_REEMBOLSOAFS(FolioPedido, Cliente, Almacen, ImporteValeCaja, ImporteEfectivo, Division, Tipo, ActualizarSiHay, FolioSapFactura, decDPVale, bRevale)

        oSAPProxy = Nothing

    End Function

    Public Function ActualizaStatusDPValeAFS(ByVal vale As String, ByRef mensaje As String) As String
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ActualizaStatusDPValeAFS(vale, mensaje)
    End Function

    Public Sub CancelacionFacturaDPValeSHAFS(ByVal params As Dictionary(Of String, Object))
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        oSAPProxy.CancelacionFacturaDPValeSHAFS(params)
    End Sub

#End Region

#Region "Esquemas RFC SAP"

    Public Sub ZCS_ALGORITMO_PROMOS_LOAD_ESQUEMA()

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ZCS_ALGORITMO_PROMOS_LOAD_ESQUEMA()

        oSAPProxy = Nothing

    End Sub

    Public Sub ZCS_ALGORITMO_PROMOS_GETDATA(ByVal dtMateriales As DataTable, ByVal TipoVenta As String, ByVal Fecha As Date, ByRef htTotales As Hashtable, _
    ByRef dtMatDesc As DataTable, ByRef dtPromos As DataTable, ByRef dtCrossSelling As DataTable)

        Dim oSAPProxy As New ProcesoSAPProxy(Me)

        oSAPProxy.ZCS_ALGORITMO_PROMOS_GETDATA(dtMateriales, TipoVenta, Fecha, htTotales, dtMatDesc, dtPromos, dtCrossSelling)

        oSAPProxy = Nothing

    End Sub

#End Region

#Region "Consignacion"

    Public Function ZMMOC01(ByVal Pedido As String, ByVal Almacen As String, ByVal Fecha As DateTime) As Dictionary(Of String, Object)
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMMOC01(Pedido, Almacen, Fecha)
    End Function

    Public Function ZMMOC02(ByVal dtDetallePedido As DataTable) As Dictionary(Of String, Object)
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMMOC02(dtDetallePedido)
    End Function

    Public Function ZMMOD01(ByVal Pedido As String, ByVal Almacen As String, ByVal Fecha As DateTime) As Dictionary(Of String, Object)
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMMOD01(Pedido, Almacen, Fecha)
    End Function

    Public Function ZMMOC03(ByVal Mblnr As String) As Dictionary(Of String, Object)
        Dim oSAPProxy As New ProcesoSAPProxy(Me)
        Return oSAPProxy.ZMMOC03(Mblnr)
    End Function

#End Region



End Class
