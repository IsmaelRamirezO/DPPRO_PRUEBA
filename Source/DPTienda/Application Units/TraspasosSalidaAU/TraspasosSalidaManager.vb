
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.IO


Public Class TraspasosSalidaManager


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

    Public Function Create() As TraspasoSalida

        Dim oTraspasoSalida As TraspasoSalida
        oTraspasoSalida = New TraspasoSalida(Me)

        Return oTraspasoSalida

    End Function

    Public Sub SaveTraspasoPendiente(ByVal pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.InsertTraspasosPedientes(pTraspasoSalida, dtDetalle)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub Save(ByVal pTraspasoSalida As TraspasoSalida)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)



        If (pTraspasoSalida Is Nothing) Then
            Throw New ArgumentNullException("El parámetro TraspasoSalida no puede ser nulo.")
        End If

        If (pTraspasoSalida.IsNew) Then
            oTraspasoSalidaDG.Insert(pTraspasoSalida)
        Else
            oTraspasoSalidaDG.Update(pTraspasoSalida)
        End If


        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub SaveCorrida(ByVal pTraspasoSalida As TraspasoSalida)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.InsertCorrida(pTraspasoSalida)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub SaveInServer(ByVal pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.InsertInServer(pTraspasoSalida, dtDetalle)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Function GetDataGeneral(ByVal CodArticulo As String) As DataRow
        Dim oTraspasoEntradaDG As TraspasosSalidaDataGateway
        oTraspasoEntradaDG = New TraspasosSalidaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectDataGeneral(CodArticulo)

        oTraspasoEntradaDG = Nothing

    End Function

    Public Function GetDataDetail(ByVal CodArticulo As String) As DataRowCollection
        Dim oTraspasoEntradaDG As TraspasosSalidaDataGateway
        oTraspasoEntradaDG = New TraspasosSalidaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectDataDetail(CodArticulo)

        oTraspasoEntradaDG = Nothing

    End Function

    Public Function SelectMaterialTalla(ByVal strCodUPC As String) As DataSet

        Dim oTraspasoEntradaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectMaterialTalla(strCodUPC)

        oTraspasoEntradaDG = Nothing

    End Function



    Public Sub SaveDBF(ByVal pTraspasoSalida As TraspasoSalida)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)



        If (pTraspasoSalida Is Nothing) Then
            Throw New ArgumentNullException("El parámetro TraspasoSalida no puede ser nulo.")
        End If

        If (pTraspasoSalida.IsNew) Then
            oTraspasoSalidaDG.InsertDBF(pTraspasoSalida)
        Else
            'oTraspasoSalidaDG.Update(pTraspasoSalida)
        End If


        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub EscribeLog(ByVal strError As String, ByVal Titulo As String)

        Dim StreamW As New StreamWriter(System.IO.Directory.GetCurrentDirectory & "\ErrorLogFile.txt", True)

        StreamW.WriteLine(Now.ToString & " --> " & Titulo.ToUpper & vbCrLf)
        StreamW.WriteLine("Detalle --> " & strError)
        StreamW.WriteLine("".PadLeft(250, "-"))

        StreamW.Close()

    End Sub

    Public Function Load(ByVal TraspasoID As String) As TraspasoSalida

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.Select(TraspasoID)

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function LoadByFolioSAP(ByVal FolioSAP As String) As TraspasoSalida

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectByFolioSAP(FolioSAP)

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function SelectByEntrega(ByVal Entrega As String) As TraspasoSalida
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)
        Return oTraspasoSalidaDG.SelectByEntrega(Entrega)
    End Function



    Public Sub Load(ByVal TraspasoID As String, ByVal Traspaso As TraspasoSalida)

        'TODO: JHV - Implementar apertura de traspaso a un objeto especificado utilizando metodo Select del DataGAteway       

    End Sub


    'Buscar Traspaso.
    Public Function GetAll(ByVal AlmacenOrigenID As String, ByVal AlmacenDestinoID As String, _
                            ByVal FromDate As Date, ByVal ToDate As Date) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectAll(AlmacenOrigenID, AlmacenDestinoID, FromDate, ToDate)

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function GetAll(ByVal strAlmacenID As String) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectAll(strAlmacenID)

        oTraspasoSalidaDG = Nothing

    End Function

    'Buscamos todos los traspasos pendientes generados por faltantes en traspasos de entrada
    Public Function GetAllTraspasosPendientes() As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectAllTraspasosPendientes()

        oTraspasoSalidaDG = Nothing

    End Function

    'Actualiza el status del traspaso pendiente generado por faltantes en traspaso de entrada
    Public Sub ActualizaTraspasoPendiente(ByVal TraspasoID As Integer, ByVal UserCancela As String, ByVal Status As String)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.UpdateTraspasoPendienteStatus(TraspasoID, UserCancela, Status)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Function AplicarEntrada(ByVal TraspasoTarget As TraspasoSalida) As Boolean

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        If (oTraspasoSalidaDG.UpdateInventario(TraspasoTarget.Detalle, TraspasoTarget.TraspasoID, TraspasoTarget.AlmacenDestinoID) = True) Then

            oTraspasoSalidaDG.UpdateGeneral(TraspasoTarget)
            Return True

        End If

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function ExtraerCatalogoCorridas() As DataSet

        Dim oTraspasoEntradaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoEntradaDG.SelectCatalogoCorridas

        oTraspasoEntradaDG = Nothing

    End Function


    Public Function GetDefectuosos(ByVal strAlmacen As String) As DataSet

        Dim oTraspasoEntradaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoEntradaDG.GetArticulosDefectuosos(strAlmacen)

        oTraspasoEntradaDG = Nothing

    End Function

    Public Sub Delete(ByVal ID As Integer)

        Dim oTraspasoEntradaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoEntradaDG.Delete(ID)

        oTraspasoEntradaDG = Nothing

    End Sub






    Public Sub CrearTablaTmp()

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.CreatTable()

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub EliminarTablaTmp()

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.DeleteTable()

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub CancelaTraspasoEC(ByVal FolioSAP As String, ByVal FCFolioSAP As String, ByVal User As String)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.CancelaTraspasoEC(FolioSAP, FCFolioSAP, User)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub AgregarArticulo(ByVal oArticulo As Articulo, ByVal strTalla As String, ByVal decCantidad As Integer, _
                               ByVal decCostoTotal As Decimal, ByVal intTraspasoID As Integer, Optional ByVal Serie As String = "")

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.InsertArticulo(oArticulo, strTalla, decCantidad, decCostoTotal, intTraspasoID, Serie)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub ActualizarLecturado(ByVal strArticulo As String, ByVal strTalla As String, ByVal intLecturado As Integer, Optional ByVal Cantidad As Integer = 0)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.ActualizarLecturado(strArticulo, strTalla, intLecturado, Cantidad)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub ActualizarLecturado2(ByVal dsTraspasoDetalle As DataSet)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.ActualizarLecturado2(dsTraspasoDetalle)

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub AgregarArticulo(ByVal Codigo As String, ByVal Descripcion As String, ByVal Corrida As String, ByVal strTalla As String, ByVal decCantidad As Integer, _
                               ByVal decCostoTotal As Decimal, ByVal intTraspasoID As Integer)
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)
        oTraspasoSalidaDG.InsertArticulo(Codigo, Descripcion, Corrida, strTalla, decCantidad, decCostoTotal, intTraspasoID)
    End Sub

    Public Sub EliminarArticuloNoLecturado()

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.DeleteArticuloNoLecturado()

        oTraspasoSalidaDG = Nothing

    End Sub

    Public Sub EliminarArticulo(ByVal strCodArticulo As String, ByVal strTalla As String) 'AS DataSet (Actualizado)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        oTraspasoSalidaDG.DeleteArticulo(strCodArticulo, strTalla)

        oTraspasoSalidaDG = Nothing

    End Sub



    Public Function GenerarTraspasoCorrida(ByVal strStoredProcedure As String) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Dim strTablaTmp As String = "TraspasoDetalleTmp" & oApplicationContext.ApplicationConfiguration.Almacen & oApplicationContext.ApplicationConfiguration.NoCaja & oApplicationContext.Security.CurrentUser.ID


        Return oTraspasoSalidaDG.FillDataSetTraspasoCorrida(strStoredProcedure, strTablaTmp, strTablaTmp & ", CatalogoArticulos, CatalogoCorridas")

        oTraspasoSalidaDG = Nothing

    End Function



    Public Function FillTablaParaSAP() As DataTable

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        Return oTraspasoSalidaDG.LlenaTablaConDetalleTraspaso

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function GenerarTraspasoCorridaDBF(ByVal strStoredProcedure As String) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)
        Dim strTablaTmp As String = "TraspasoDetalleTmp" & oApplicationContext.ApplicationConfiguration.Almacen & oApplicationContext.ApplicationConfiguration.NoCaja & oApplicationContext.Security.CurrentUser.ID


        Return oTraspasoSalidaDG.FillDataSetTraspasoCorrida(strStoredProcedure, strTablaTmp, "CatalogoArticulos")

        oTraspasoSalidaDG = Nothing

    End Function



    Public Sub GenerarTraspasoDetalleTemporal(ByVal dsDataSet As DataSet)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Dim strTablaTmp As String = "TraspasoDetalleTmp" & oApplicationContext.ApplicationConfiguration.Almacen & oApplicationContext.ApplicationConfiguration.NoCaja & oApplicationContext.Security.CurrentUser.ID '"TraspasoDetalleTmp" & oApplicationContext.ApplicationConfiguration.NoCaja


        oTraspasoSalidaDG.FillDataSetTraspasoDetalleCaptura(dsDataSet)

        oTraspasoSalidaDG = Nothing


    End Sub



    Public Function ActualizarDataSet(ByVal strStoredProcedure As String, ByVal strTabla As String) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        Return oTraspasoSalidaDG.FillDataSet(strStoredProcedure, strTabla)

        oTraspasoSalidaDG = Nothing

    End Function


    Public Function ValidarCantidad(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, ByVal strTalla As String, ByVal Destino As String) As Boolean

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.ValidarCantidadArticulo(intCantidadArticulo, strCodArticulo, strTalla, Destino)

        oTraspasoSalidaDG = Nothing

    End Function



    Public Function ValidarTalla(ByVal decTalla As Decimal, ByVal strCodCorrida As String) As Boolean

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.ValidarTallaArticulo(decTalla, strCodCorrida)

        oTraspasoSalidaDG = Nothing

    End Function



    Public Function GenerarArticuloCorrida(ByVal strCodArticulo As String, ByVal strAlmacenDestino As String) As DataSet

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.GenerarArticuloCorrida(strCodArticulo, strAlmacenDestino)

        oTraspasoSalidaDG = Nothing

    End Function
    Public Sub SaveMotivo(ByVal strFacturaID As Integer, ByVal strTienda As String, ByVal strArticulo As String, _
           ByVal strTalla As String, ByVal intIdMotivo As Integer, ByVal strTipoMovto As String)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.InsertMotivo(strFacturaID, strTienda, strArticulo, strTalla, intIdMotivo, strTipoMovto)

        oTraspasoSalidaDG = Nothing

    End Sub



    Public Sub CreatTraspasoSalidaDBF(ByRef Vp_objTraspasoSalida As TraspasoSalida, Optional ByVal bolMensaje As Boolean = False)

        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        oTraspasoSalidaDG.Sm_TraspasoSalidaDBF(Vp_objTraspasoSalida, bolMensaje)

    End Sub

    Public Function SelectAllByDate(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime) As DataSet
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectTraspasoSalidaByDate(FechaDe, FechaAl)
        'Return oTraspasoSalidaDG.SelectAllByDate(FechaDe, FechaAl)

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function SelectTraspasosByDate(ByVal Fecha As Date, ByVal Modulo As String) As DataTable
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SelectTraspasosByDate(Fecha, Modulo)

    End Function

    Public Function SelectAllDefectuosos() As DataSet
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        Return oTraspasoSalidaDG.DefectuososSelectAll()

        oTraspasoSalidaDG = Nothing

    End Function
    Public Function centro_destino(ByVal strcentrodes As String) As String
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)

        Return oTraspasoSalidaDG.SeleccionaCentro(strcentrodes)

        oTraspasoSalidaDG = Nothing

    End Function

    Public Function ExtraerDatosEmpresa() As DataSet
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)


        Return oTraspasoSalidaDG.DatosEmpresaSel()

        oTraspasoSalidaDG = Nothing

    End Function

#End Region

#Region "Metodos Traslados Virtual"
    Public Sub InsertTF(ByRef pTraspasoSalida As TraspasoSalida, ByVal dtDetalle As DataTable)
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        gateway.InsertTF(pTraspasoSalida, dtDetalle)
    End Sub

    Public Function SelectTFByFolio(ByVal TraspasoID As Integer) As TraspasoSalida
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        Return gateway.SelectTFByFolio(TraspasoID)
    End Function

    Public Function SelectTFSelAll(ByVal Origen As String) As DataSet
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        Return gateway.SelectTFSelAll(Origen)
    End Function

    Public Function SelectTFNextCaja(ByVal movId As Integer) As Integer
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        Return gateway.SelectTFNextCaja(movId)
    End Function

    Public Function SelectTFNextFolio() As Integer
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        Return gateway.SelectTFNextFolio()
    End Function

    Public Function GetTraspasoSalidaDetalleVirtual(ByVal Origen As String) As DataTable
        Dim gateway As New TraspasosSalidaDataGateway(Me)
        Return gateway.GetTraspasoSalidaDetalleVirtual(Origen)
    End Function

#End Region

#Region "Consignación"

    Public Function ActualizaDocumentoDevProveedor(ByVal TraspasoId As Integer, ByVal Mblnr As String) As Boolean
        Dim oTraspasoSalidaDG As New TraspasosSalidaDataGateway(Me)
        Return oTraspasoSalidaDG.ActualizaDocumentoDevProveedor(TraspasoId, Mblnr)
    End Function

#End Region

End Class
