
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos


Public Class ContratoManager


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)
        oApplicationContext = ApplicationContext
    End Sub

#End Region



#Region "Properties"

    Private oApplicationContext As ApplicationContext

    Public Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
        Set(ByVal Value As ApplicationContext)
            oApplicationContext = Value
        End Set
    End Property

#End Region



#Region "Methods"

    Public Function Create() As Contrato

        Dim oContrato As Contrato
        oContrato = New Contrato(Me)

        Return oContrato

    End Function



    Public Function Load(ByVal ContratoID As Integer) As Contrato

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.Select(ContratoID)

        oContratoDG = Nothing

    End Function


    Public Function SelectByID(ByVal ContratoID As Integer) As Contrato

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.SelectByID(ContratoID)

        oContratoDG = Nothing

    End Function


    Public Function LoadFolioApartado(ByVal ContratoID As Integer) As Contrato

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.SelectFolioApartado(ContratoID)

        oContratoDG = Nothing

    End Function



    Public Function LoadFolioCaja(ByVal ContratoID As Integer, ByVal CodCaja As String) As Contrato

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.SelectApartadoFolioCaja(ContratoID, CodCaja)

        oContratoDG = Nothing

    End Function



    Public Sub Save(ByVal pContrato As Contrato)

        Dim oContratoDG As New ContratoDataGateway(Me)


        If (pContrato Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Contrato no puede ser nulo.")
        End If

        If (pContrato.IsNew) Then
            oContratoDG.Insert(pContrato)
        Else
            'oContratoDG.Update(pContrato)
        End If


        oContratoDG = Nothing

    End Sub



    Public Sub Delete(ByVal ID As Integer, ByVal usuario As String)

        Dim oContratoDG As New ContratoDataGateway(Me)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Caja")
        End If

        oContratoDG.Delete(ID, usuario)

        oContratoDG = Nothing

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.SelectAll(EnabledRecordsOnly)

        oContratoDG = Nothing

    End Function



    Public Function Folios() As Integer

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.ContratoFolios

        oContratoDG = Nothing

    End Function



    Public Function ExtraerCatalogoCorridas() As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.SelectCatalogoCorridas

        oContratoDG = Nothing

    End Function



    Public Function CalcularTotalAbonos(ByVal intApartadoID As Integer) As Decimal

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.CalcularTotalAbonos(intApartadoID)

        oContratoDG = Nothing

    End Function


    Public Sub SetDocFi(ByVal intApartadoID As Integer, ByVal strdocfi As String, ByVal strContrato As String)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.UpdateDocFiContrato(intApartadoID, strdocfi, strContrato)

        oContratoDG = Nothing

    End Sub


    Public Sub SetDocFiCancelacion(ByVal intApartadoID As Integer, ByVal strdocfi As String)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.UpdateDocFiCancelacion(intApartadoID, strdocfi)

        oContratoDG = Nothing

    End Sub



    Public Function CalcularTotalAbonosAnticipoClientes(ByVal intApartadoID As Integer) As Decimal

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.CalcularTotalAbonosAnticipoClientes(intApartadoID)

        oContratoDG = Nothing

    End Function



    Public Function DistibucionCancelarContrato(ByVal oContrato As Contrato) As Integer

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.DistribucionCancelarContrato(oContrato)

        oContratoDG = Nothing

    End Function



    Public Sub ContratoCancelarAbonos(ByVal intApartadoID As Integer)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.ContratoCancelarAbonos(intApartadoID)

        oContratoDG = Nothing

    End Sub



    Public Sub CancelarContrato(ByVal intApartadoID As Integer, ByVal User As String)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.CancelarContrato(intApartadoID, User)

        oContratoDG = Nothing

    End Sub



    Public Sub ContratoCancelarUpdateInventario(ByVal dsContratoDetalle As DataSet)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.ContratoCancelarUpdateInventario(dsContratoDetalle)

        oContratoDG = Nothing

    End Sub



    Public Function ContratoCancelarAnticiposClientesDel(ByVal intAnticipoID As Integer)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.ContratoCancelarAnticiposClientesDel(intAnticipoID)

        oContratoDG = Nothing

    End Function

    Public Sub ActualizaDOCNUMFB01xFolioAbono(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        Dim oContratoDG As New ContratoDataGateway(Me)

        oContratoDG.ActualizaDOCNUMFB01xFolioAbono(ApartadoID, DOCNUMFB01)

        oContratoDG = Nothing

    End Sub

#End Region



#Region "Métodos [Contrato Detalle]"

    Public Sub CrearTablaTmp()

        Dim oContratoDG As New ContratoDataGateway(Me)


        oContratoDG.CreatTable()

        oContratoDG = Nothing

    End Sub


    Public Sub EliminarTablaTmp()

        Dim oContratoDG As New ContratoDataGateway(Me)


        oContratoDG.DeleteTable()

        oContratoDG = Nothing

    End Sub


    Public Sub AgregarArticulo(ByVal intApartadoID As Integer, ByVal oArticulo As Articulo, ByVal decNumero As String, _
                               ByVal intCantidad As Integer, ByVal decDescuento As Decimal, ByVal strUsuario As String)

        Dim oContratoDG As New ContratoDataGateway(Me)


        oContratoDG.InsertArticulo(intApartadoID, oArticulo, decNumero, intCantidad, decDescuento, strUsuario)

        oContratoDG = Nothing

    End Sub


    Public Sub EliminarArticulo(ByVal strCodArticulo As String, ByVal strTalla As String)

        Dim oContratoDG As New ContratoDataGateway(Me)


        oContratoDG.DeleteArticulo(strCodArticulo, strTalla)

        oContratoDG = Nothing

    End Sub


    Public Function BuscarArticuloTmp(ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.BuscarArticuloTmp(strCodArticulo, strTalla)


        oContratoDG = Nothing

    End Function


    Public Sub GenerarTraspasoDetalleTemporal(ByVal dsDataSet As DataSet)

        Dim oContratoDG As New ContratoDataGateway(Me)


        oContratoDG.LlenarTablaContratoDetalleTmp(dsDataSet)  'FillDataSetTraspasoDetalleCaptura(dsDataSet)

        oContratoDG = Nothing

    End Sub


    Public Function ActualizarDataSet(ByVal strStoredProcedure As String, ByVal strTabla As String) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.FillDataSet(strStoredProcedure, strTabla)

        oContratoDG = Nothing

    End Function

    'Ramiro
    'Public Function ValidarCantidad(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, ByVal strTalla As Decimal) As Boolean
    Public Function ValidarCantidad(ByVal intCantidadArticulo As Integer, ByVal strCodArticulo As String, ByVal strTalla As String) As Boolean

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.ValidarCantidadArticulo(intCantidadArticulo, strCodArticulo, strTalla)

        oContratoDG = Nothing

    End Function

    Public Function ValidarTalla(ByVal strTalla As String, ByVal strCodCorrida As String) As Boolean
        'Public Function ValidarTalla(ByVal strTalla As Decimal, ByVal strCodCorrida As String) As Boolean

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.ValidarTallaArticulo(strTalla, strCodCorrida)

        oContratoDG = Nothing

    End Function


    Public Function ExtraerCantLibreArticulo(ByVal strCodArticulo As String, ByVal strTalla As String) As Decimal

        Dim oContratoDG As New ContratoDataGateway(Me)


        Return oContratoDG.ExtraerCantLibreArticulo(strCodArticulo, strTalla)

        oContratoDG = Nothing

    End Function


    Public Function ContratoDetalleSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.ContratoDetalleSel(FechaDe, FechaHasta, CodCaja)

        oContratoDG = Nothing

    End Function


    Public Function ContratoTotalesSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.ContratoTotalesSel(FechaDe, FechaHasta, CodCaja)

        oContratoDG = Nothing

    End Function


    Public Function ContratoCanceladosSel(ByVal FechaDe As DateTime, ByVal FechaHasta As DateTime, ByVal CodCaja As String) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.ContratoCanceladosSel(FechaDe, FechaHasta, CodCaja)

        oContratoDG = Nothing

    End Function
    Public Function DivisionSel() As String

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.DivisionSel

        oContratoDG = Nothing

    End Function


    Public Function AbonosApartadosSel(ByVal AnticipoID As Integer) As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.AbonosApartadosSel(AnticipoID)

        oContratoDG = Nothing

    End Function

    Public Function ContratoVegentesSel() As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.ContratoVegentesSel

        oContratoDG = Nothing

    End Function


    Public Function ContratosVencidosSel() As DataSet

        Dim oContratoDG As New ContratoDataGateway(Me)

        Return oContratoDG.GetContratosVencidos

        oContratoDG = Nothing

    End Function

#End Region

#Region "SAP Retail"

    Public Function GetApartadoSaldado(ByVal FacturaId As Integer) As Decimal
        Dim oContratoDG As New ContratoDataGateway(Me)
        Return oContratoDG.GetApartadoSaldado(FacturaId)
    End Function

    Public Function GetAnticiposByApartadoId(ByVal ApartadoId As Integer) As DataTable
        Dim oContratoDG As New ContratoDataGateway(Me)
        Return oContratoDG.GetAnticiposByApartadoId(ApartadoId)
    End Function

    Public Function GetImporteAbonosByApartadoId(ByVal ApartadoId As Integer) As DataTable
        Dim oContratoDG As New ContratoDataGateway(Me)
        Return oContratoDG.GetImporteAbonosByApartadoId(ApartadoId)
    End Function



#End Region


End Class
