Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Collections.Generic

Public Class TraspasosEntradaManager

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal ConfigCierreFI As SaveConfigArchivos = Nothing)
        oApplicationContext = ApplicationContext
        oConfigCierre = ConfigCierreFI
    End Sub

#End Region

#Region "Properties"

    Private oApplicationContext As ApplicationContext
    Private oConfigCierre As SaveConfigArchivos

    Public Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
        Set(ByVal Value As ApplicationContext)
            oApplicationContext = Value
        End Set
    End Property

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#End Region

#Region "Methods"

    Public Function Load(ByVal TraspasoID As Integer) As TraspasoEntrada
        'TODO: JHV - Implementar apertura de traspaso utilizando función Select del DataGateway
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.Select(TraspasoID)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Function LoadByFolioSAP(ByVal TrasladoOrigenSAP As String) As TraspasoEntrada
        'TODO: JHV - Implementar apertura de traspaso utilizando función Select del DataGateway
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectByFolioSAP(TrasladoOrigenSAP)

    End Function

    Public Function GeneraReporteDiferencias(ByVal Desde As Date, ByVal Hasta As Date) As DataSet

        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectReporteDiferencias(Desde, Hasta)

    End Function

    Public Sub Load(ByVal TraspasoID As String, ByVal Traspaso As TraspasoEntrada)
        'TODO: JHV - Implementar apertura de traspaso a un objeto especificado utilizando metodo Select del DataGAteway
    End Sub

    Public Function GetAll(ByVal AlmacenOrigenID As String, ByVal AlmacenDestinoID As String, _
                           ByVal FromDate As Date, ByVal ToDate As Date, ByVal strStatus As String) As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectAll(AlmacenOrigenID, AlmacenDestinoID, FromDate, ToDate, strStatus)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Sub SaveArtNoLecturados(ByVal strOrigen As String, ByVal strOrigenDesc As String, _
    ByVal strDestino As String, ByVal strDestinoDesc As String, ByVal strFolioTraslado As String, _
    ByVal strResponsable As String, ByVal strTipoMovto As String, ByVal dvDetalle As DataView)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.InsertArtNoLecturados(strOrigen, strOrigenDesc, strDestino, strDestinoDesc, strFolioTraslado, strResponsable, strTipoMovto, dvDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Sub SaveArtEnAclaracion(ByVal dvDetalle As DataTable, Optional ByVal strFolio As String = "")
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.InserArtAclaracion(strFolio, dvDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub


    Public Sub SaveCargaInicialArticulosAclaracion(ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.CargaInicialArticulosAclaracion(dtDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Sub SaveCargaInicialBajaCalidad(ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.CargaInicialBajaCalidad(dtDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Sub SaveCargaInicialDefectuosos(ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.CargaInicialDefectuosos(dtDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub


    Public Sub EliminaRegistrosExistentes(ByVal Tabla As String)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.EliminaRegistros(Tabla)
        oTraspasoEntradaDG = Nothing
    End Sub


    Public Sub UpdateArtAclaracion(ByVal Folio As String, ByVal Codigo As String, ByVal CantAclarada As Integer)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.UpdateArtAclaracion(Folio, Codigo, CantAclarada)
    End Sub

    Public Function SelectArticulosAclaracionByFolio(ByVal Folio As String) As DataTable
        Dim dtResult As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        dtResult = oTraspasoEntradaDG.SelectArticulosAclaracionByFolio(Folio)
        oTraspasoEntradaDG = Nothing
        Return dtResult
    End Function


    Public Function UpdateFolioArtNoLecturados(ByVal strFolio As String, ByVal dtDetalle As DataTable) As String
        Dim respuesta As String
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        respuesta = oTraspasoEntradaDG.UpdateFolioArtNoLecturados(strFolio, dtDetalle)
        oTraspasoEntradaDG = Nothing
        Return respuesta
    End Function

    Public Sub SaveArtNoLecturadosInServer(ByVal strOrigen As String, ByVal strOrigenDesc As String, _
    ByVal strDestino As String, ByVal strDestinoDesc As String, ByVal strFolioTraslado As String, _
    ByVal strResponsable As String, ByVal strTipoMovto As String, ByVal dvDetalle As DataView)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.InsertArtNoLecturadosInServer(strOrigen, strOrigenDesc, strDestino, strDestinoDesc, strFolioTraslado, strResponsable, strTipoMovto, dvDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Sub UpdateArtNoLecturados(ByVal strFolioTraslado As String, ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.UpdateArtNoLecturados(strFolioTraslado, dtDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Sub UpdateArtNoLecturadosServer(ByVal strFolioTraslado As String, ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.UpdateArtNoLecturadosServer(strFolioTraslado, dtDetalle)
        oTraspasoEntradaDG = Nothing
    End Sub

    Public Function GetAll(ByVal AlmacenDestinoID As String) As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectAll(AlmacenDestinoID)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Sub SaveMotivo(ByVal strFacturaID As Integer, ByVal strTienda As String, ByVal strArticulo As String, _
        ByVal strTalla As String, ByVal intIdMotivo As Integer, ByVal strTipoMovto As String)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.InsertMotivo(strFacturaID, strTienda, strArticulo, strTalla, intIdMotivo, strTipoMovto)
        oTraspasoEntradaDG = Nothing

    End Sub

    Public Function TraspasoEntradaPendientesSelectAll() As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.TraspasoEntradaPendientesSelectAll
        oTraspasoEntradaDG = Nothing
    End Function

    'Public Sub AplicarEntrada(ByVal TraspasoTarget As TraspasoEntrada)

    Public Function AplicarEntrada(ByVal TraspasoTarget As TraspasoEntrada, ByVal UserSession As String, ByVal UserName As String, Optional ByVal CanceladoECM As Boolean = False, Optional EsConsignacion As Boolean = False) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        'If (oTraspasoEntradaDG.UpdateInventario(TraspasoTarget.Detalle, TraspasoTarget.TraspasoID) = True) Then
        If (oTraspasoEntradaDG.UpdateInventario(TraspasoTarget, TraspasoTarget.TraspasoID, CanceladoECM, EsConsignacion) = True) Then
            ' oTraspasoEntradaDG.Update(TraspasoTarget, UserSession, UserName)
            oTraspasoEntradaDG.InsertarTraspaso(TraspasoTarget, UserSession, UserName)
            Return True
        End If
        oTraspasoEntradaDG = Nothing
    End Function

    Public Sub AfectaInventario(ByVal TraspasoTarget As TraspasoEntrada, Optional ByVal CanceladoECM As Boolean = False)

        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        oTraspasoEntradaDG.UpdateInventario(TraspasoTarget, TraspasoTarget.TraspasoID, CanceladoECM, False)

        oTraspasoEntradaDG = Nothing

    End Sub

    Public Function AplicarTraspasoEntradaInServer(ByVal TraspasoTarget As TraspasoEntrada, ByVal UserSession As String, ByVal UserName As String) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        oTraspasoEntradaDG.InsertarTraspasoEntradaInServer(TraspasoTarget, UserSession, UserName)

        Return True

    End Function

    Public Function GetDetalleByBultos(ByVal FolioTrasladoSAP As String, ByVal NumBulto As Integer, ByRef Tratado As Boolean) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectDetalleByBultosSeparaciones(FolioTrasladoSAP, NumBulto, Tratado)

    End Function

    Public Function ValidarBultoAplicadoServer(ByVal FolioTrasladoSAP As String, ByVal NumBulto As Integer) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectDetalleByBultosServer(FolioTrasladoSAP, NumBulto)

    End Function

    Public Function ValidarBultoAplicado(ByVal FolioTrasladoSAP As String, ByVal NumBulto As Integer) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectDetalleByBultos(FolioTrasladoSAP, NumBulto)

    End Function

    Public Function ExtraerCatalogoCorridas() As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectCatalogoCorridas
        oTraspasoEntradaDG = Nothing
    End Function

    Public Sub TraspasoEntradaDBF()
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.Sm_TraspasoEntradaDBF()
        oTraspasoEntradaDG = Nothing
    End Sub
#End Region

    Public Function SelectAllPendientes() As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectAllPendientes()
        oTraspasoEntradaDG = Nothing
    End Function

    Public Function SelectMaterialTalla(ByVal strCodUPC As String) As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectMaterialTalla(strCodUPC)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Function SelectDescripcion(ByVal strArticulo As String) As String
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectDescripcion(strArticulo)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Function SelectAllByDate(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime) As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectTraspasosEntradasByDate(FechaDe, FechaAl)
        'Return oTraspasoEntradaDG.SelectAllByDate(FechaDe, FechaAl)
        oTraspasoEntradaDG = Nothing
    End Function

    Public Function SelectInfoFolioAjuste(ByVal strFolio As String) As DataSet
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SelectInfoAjuste(strFolio)
        oTraspasoEntradaDG = Nothing
    End Function

#Region "Traspaso Entrada Virtual"
    Public Function GetTraspasosVirtual(ByVal Origen As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.GetTraspasosVirtual(Origen)
    End Function

    Public Function NextFolioTraspasoEntradaVirtual(ByVal Destino As String) As Integer
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.NextFolioTraspasoEntradaVirtual(Destino)
    End Function

    Public Sub InsertarTraspasoEntradaVirtual(ByRef Traspaso As TraspasoEntrada, ByVal dtDetalle As DataTable)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.InsertarTraspasoEntradaVirtual(Traspaso, dtDetalle)
    End Sub

    Public Function ExisteCajaTraspasoEntrada(ByVal folio As Integer, ByVal cajaID As Integer) As Integer
        Dim oTraspasoEntrasdaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntrasdaDG.ExisteCajaTraspasoEntrada(folio, cajaID)
    End Function

    Public Function GetTraspasoEntradaSel(ByVal Folio As String) As TraspasoEntrada
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.GetTraspasoEntradaSel(Folio)
    End Function
#End Region

#Region "Entrega y Recepcion de Mercancias"

    Public Function InsertarResguardo(ByVal AlmacenOrigen As String, ByVal AlmacenDestino As String, ByVal dtResguardos As DataTable) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.InsertarResguardo(AlmacenOrigen, AlmacenDestino, dtResguardos)
    End Function

    Public Function ObtenerResguardoByOrdenCompra(ByVal OrdenCompra As String, ByVal Centro As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.ObtenerResguardosByOrdenCompra(OrdenCompra, Centro)
    End Function

    Public Function ActualizarResguardosByOrdenCompra(ByVal OrdenCompra As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.ActualizarResguardosByOrdenCompra(OrdenCompra)
    End Function

    Public Function ObtenerReporteResguardos(ByVal Centro As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.ObtenerReporteResguardos(Centro)
    End Function

#End Region

#Region "Consignacion"

    Public Function SaveZdproPedido(ByVal zdppro As ZdproPedidos) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SaveZdproPedido(zdppro)
    End Function

    Public Function SaveZdproPedido(ByVal lstZdpro As List(Of ZdproPedidos)) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SaveZdproPedido(lstZdpro)
    End Function

    Public Sub GetZdpproPedidoById(ByVal zdppro As ZdproPedidos)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.GetZdpproPedidoById(zdppro)
    End Sub

    Public Function SaveZequi(ByVal zequi As Zequi) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.SaveZequi(zequi)
    End Function

    Public Function SaveZequi(ByVal lstZequi As List(Of Zequi)) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.SaveZequi(lstZequi)
    End Function

    Public Sub GetZequiById(ByVal zequi As Zequi)
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        oTraspasoEntradaDG.GetZequiById(zequi)
    End Sub

    Public Function GetZequiByOption(ByVal Opcion As Integer, ByVal Valor As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.GetZequiByOption(Opcion, Valor)
    End Function

    Public Function GetZequi(ByVal CodArticulo As String, ByVal Serie As String) As Zequi
        Dim oTraspasoEntradaDg As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDg.GetZequi(CodArticulo, Serie)
    End Function

    Public Function GetZdproPedido(ByVal Tipo As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.GetZdproPedido(Tipo)
    End Function

    Public Function GetZdpproPedidoByPedidoSAP(ByVal PedidoSAP As String, ByVal Identificador As String) As DataTable
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.GetZdpproPedidoByPedidoSAP(PedidoSAP, Identificador)
    End Function

    Public Function ActualizarDocumentoEntradaMercancia(ByVal TraspasoId As Integer, ByVal Mblnr As String) As Boolean
        Dim oTraspasoEntradaDG As New TraspasosEntradaDataGateway(Me)
        Return oTraspasoEntradaDG.ActualizarDocumentoEntradaMercancia(TraspasoId, Mblnr)
    End Function

#End Region

End Class
