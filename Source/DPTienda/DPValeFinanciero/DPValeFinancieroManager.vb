Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports System.Collections.Generic

'Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class DPValeFinancieroManager

    Dim oApplicationContext As ApplicationContext
    Dim oConfigCierre As ConfigSaveArchivos.SaveConfigArchivos
    Dim oDPVFDG As DPValeFinancieroDataGateway

#Region "Properties"

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

#End Region

#Region "Constructor / Destructor"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal oConfig As ConfigSaveArchivos.SaveConfigArchivos)

        oApplicationContext = ApplicationContext
        oConfigCierre = oConfig
        oDPVFDG = New DPValeFinancieroDataGateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oDPVFDG = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As DPVFinanciero

        Dim oNuevoDPValeF As DPVFinanciero

        oNuevoDPValeF = New DPVFinanciero(Me)

        Return oNuevoDPValeF

    End Function

    Public Function CreateDispersion() As DPVFinancieroDispersion

        Dim oNuevoDPValeF As DPVFinancieroDispersion

        oNuevoDPValeF = New DPVFinancieroDispersion(Me)

        Return oNuevoDPValeF

    End Function

    Public Function LoadDpvFinancieroDispersion(ByVal CodAlmacen As String, ByVal TransactionId As Integer, ByVal ClubDP As String) As DPVFinancieroDispersion
        Return oDPVFDG.SelectDPVFinancieroDispersion(CodAlmacen, TransactionId, ClubDP)
    End Function

    Public Function Load(ByVal ID As String, ByVal Tipo As Integer) As DPVFinanciero

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un número DPVale")
        End If

        Dim oReadedDPVF As DPVFinanciero

        oReadedDPVF = oDPVFDG.SelectByID(ID, Tipo)

        Return oReadedDPVF

    End Function

    Public Sub Save(ByVal pDPVF As DPVFinanciero)

        If (pDPVF Is Nothing) Then
            Throw New ArgumentNullException("El parámetro DPValeF no puede ser nulo.")
        End If

        If (pDPVF.IsNew) Then
            oDPVFDG.Insert(pDPVF)
        Else
            'oDPVFDG.Update(pDPVF)
        End If

    End Sub

    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un número DPVale")
        End If

        oDPVFDG.Delete(ID)

    End Sub

    Public Function GetAll(Optional ByVal Fecha As String = "") As DataSet

        Return oDPVFDG.SelectAll(Fecha)

    End Function

    Public Function GetLastSec(ByVal Tipo As Integer) As Integer

        Return oDPVFDG.GetLastSec(Tipo)

    End Function

#End Region

#Region "Servicios Financieros"

    Public Function GetServiciosFinancieros(Optional ByVal Todos As Boolean = False) As DataTable

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetServiciosFinancieros(Todos)

    End Function

    Public Function GetBancos() As DataTable

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetBancos()

    End Function

    Public Function GetCompañiaCelular() As DataTable

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetCompañiaCelular()

    End Function

    Public Function MarcaGenerado(ByVal Id As Integer, ByVal SecFile As Integer) As String

        Return oDPVFDG.UpdateGenerado(Id, SecFile)

    End Function

    Public Function GetCatalogoDiasInhabiles(ByVal Fecha As DateTime) As DataTable

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetCatalogoDiasInhabiles(Fecha)

    End Function

    Public Function GetServiciosFinancierosByID(ByVal ID As String) As String

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetServiciosFinancierosByID(ID)

    End Function

    Public Function GetFechaServidor() As String

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetFechaServidor()

    End Function

    Public Function ActualizarServicioActivo(ByVal ServicioID As String, ByVal Activo As Boolean, ByVal Usuario As String) As String

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.UpdateServicioActivo(ServicioID, Activo, Usuario)

    End Function

    Public Function GetBines(ByVal Bin As String, ByVal Tipo As String, ByVal activo As Boolean) As String

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetBines(Bin, Tipo, activo)
    End Function

    Public Function GetBinesCod(ByVal Bin As String, ByVal Tipo As String, ByVal activo As Boolean) As String

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Dim id_prosa As String = oDPVFDG.GetBines(Bin, Tipo, activo)
        Dim codigo As String = ""
        If id_prosa.Trim.Length > 4 Then
            codigo = id_prosa.Substring(1, 4)
            'codigo = oDPVFDG.GetCodigo(codigo)
        End If

        Return codigo
    End Function

    Public Function GetBinTransfer(ByVal Bin As String, ByVal Tipo As String, ByVal activo As Boolean) As Boolean

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetBinTransfer(Bin, Tipo, activo)
    End Function

    Public Function GetByFecha(ByVal ServicioId As Integer, ByVal NoCuenta As String, ByVal Celular As String, ByVal NumeroTarjeta As String, ByVal Clabe As String) As DataSet

        Return oDPVFDG.SelectFecha(ServicioId, NoCuenta, Celular, NumeroTarjeta, Clabe)
    End Function

    Public Function GetServiciosFinancierosByID_Act(ByVal ID As String) As Boolean

        oDPVFDG = New DPValeFinancieroDataGateway(Me)

        Return oDPVFDG.GetServiciosFinancierosByID_Act(ID)

    End Function

    Public Function GetFechaDispersion(ByVal ServicioID As String, ByVal Fecha As DateTime, ByRef HorariosDispersion As DataTable) As String

        Return oDPVFDG.GetFechaDispersion(ServicioID, Fecha, HorariosDispersion)

    End Function

    Public Sub ConfirmacionS2Credit(ByVal DPVale As String)

        oDPVFDG = New DPValeFinancieroDataGateway(Me)
        oDPVFDG.ConfirmacionS2Credit(DPVale)

    End Sub

#End Region

#Region "Dispersión Expres"

    Public Function ValidaPrestamoAnterior(ByVal NombreCliente As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean
        oDPVFDG = New DPValeFinancieroDataGateway(Me)
        Return oDPVFDG.getPrestamoAnterior(NombreCliente, ServicioID, Valor)
    End Function

    Public Function ValidaPrestamoAnteriorIFE(ByVal IFE As String, ByVal ServicioID As String, ByVal Valor As String) As Boolean
        oDPVFDG = New DPValeFinancieroDataGateway(Me)
        Return oDPVFDG.getPrestamoAnteriorIFE(IFE, ServicioID, Valor)
    End Function

    Public Function MensajesCreditoExpres(ByVal TipoMensaje As Integer) As DataTable
        oDPVFDG = New DPValeFinancieroDataGateway(Me)
        Return oDPVFDG.GetMensajesCredExpres(TipoMensaje)
    End Function

    Public Function GetFechaDispersionExpres(ByVal ServicioID As String, ByVal Fecha As DateTime, ByRef HorariosDispersion As DataTable) As String
        Return oDPVFDG.GetFechaDispersionExpres(ServicioID, Fecha, HorariosDispersion)
    End Function

#End Region

#Region "Microcreditos"

    Public Function Save(ByRef Disposicion As DisposicionEfeClubDP) As Boolean
        Return oDPVFDG.Save(Disposicion)
    End Function

    Public Function SaveHistorial(ByRef Disposicion As DisposicionEfeClubDP) As Boolean
        Return oDPVFDG.SaveHistorial(Disposicion)
    End Function

    Public Function LoadDispersion(ByVal TransactionId As Integer) As Dictionary(Of String, Object)
        Return oDPVFDG.LoadDispersion(TransactionId)
    End Function

    Public Function GetDisposicionEfeClubDPByAlmacen(ByVal CodAlmacen As String) As DataTable
        Return oDPVFDG.GetDisposicionEfeClubDPByAlmacen(CodAlmacen)
    End Function

    Public Function GetDisposicionEfeClubDPSolicitado(ByVal CodAlmacen As String) As DataTable
        Return oDPVFDG.GetDisposicionEfeClubDPSolicitado(CodAlmacen)
    End Function

    Public Function GetPlazos(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Return oDPVFDG.GetPlazos(CodAlmacen, Fecha)
    End Function

    Public Function SaveDPVFinancieroDispersion(ByVal pDPVF As DPVFinancieroDispersion) As Boolean
        Dim valido As Boolean = False
        If (pDPVF Is Nothing) Then
            Throw New ArgumentNullException("El proceso de disposición fue interrumpido por problemas de conexión.  Favor de ingresar a la opción de Re proceso para continuar con la operación")
        End If

        If (pDPVF.IsNew) Then
            valido = oDPVFDG.InsertDispersion(pDPVF)
        End If
        Return valido
    End Function

    Public Function GetDisposicionEfeClubDPBCount(ByVal INE As String, ByVal Fecha As DateTime) As Integer
        Return oDPVFDG.GetDisposicionEfeClubDPBCount(INE, Fecha)
    End Function

    Public Function GetDisposiciones(ByVal CodAlmacen As String, ByVal Fecha As DateTime) As DataTable
        Return oDPVFDG.GetDisposiciones(CodAlmacen, Fecha)
    End Function

    Public Function ValidarMontoMinimo(ByVal CodAlmacen As String, ByVal PlanCode As String, ByVal Monto As Decimal) As Integer
        Return oDPVFDG.ValidarMontoMinimo(CodAlmacen, PlanCode, Monto)
    End Function

    Public Function GetServicioByCodigoBanco(ByVal ServicioID As String) As DataTable
        Return oDPVFDG.GetServicioByCodigoBanco(ServicioID)
    End Function

    Public Sub GetMontosDisposicionEfeClubDP(ByVal Fecha As DateTime, ByRef MontoAprobado As Decimal, ByRef MontoCancelado As Decimal)
        oDPVFDG.GetMontosDisposicionEfeClubDP(Fecha, MontoAprobado, MontoCancelado)
    End Sub

#End Region

#Region "Mejora Microcredito"

    Public Function ValidarServicioDispersion(ByVal Servicio As String, ByVal NumTarjeta As String) As Integer
        Return oDPVFDG.ValidarServicioDispersion(Servicio, NumTarjeta)
    End Function

#End Region

#Region "Activacion por plaza"

    Public Function GetCatalogoServiciosByPlaza(ByVal Opcion As Integer, ByVal CodPlaza As String) As DataTable
        Return oDPVFDG.GetCatalogoServiciosByPlaza(Opcion, CodPlaza)
    End Function

#End Region

End Class
