
Option Explicit On

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class CatalogoFormasPagoManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoFormasPagoDG As CatalogoFormasPagoDataGateway
    Dim oConfigCierre As ConfigSaveArchivos.SaveConfigArchivos

    Public ReadOnly Property ConfigCierreFI() As ConfigSaveArchivos.SaveConfigArchivos
        Get
            Return oConfigCierre
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal oConfig As ConfigSaveArchivos.SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext

        oConfigCierre = oConfig

        oCatalogoFormasPagoDG = New CatalogoFormasPagoDataGateway(Me)


    End Sub



    Public Sub dispose()

        MyBase.Finalize()

        oCatalogoFormasPagoDG = Nothing

    End Sub

#End Region



#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

#End Region



#Region "Methods"

    Public Function Create() As FormaPago

        Dim oNuevaFormaPago As FormaPago
        oNuevaFormaPago = New FormaPago(Me)

        Return oNuevaFormaPago

    End Function

    Public Function CreateConfig() As ConfigEcomm

        Dim oConfigEcomm As ConfigEcomm
        oConfigEcomm = New ConfigEcomm(Me)

        Return oConfigEcomm

    End Function



    Public Function Load(ByVal ID As String, ByVal VentaID As String, ByVal flag As String) As FormaPago

        Dim oReadedFormaPago As FormaPago

        oReadedFormaPago = oCatalogoFormasPagoDG.SelectByID(ID, VentaID, Flag)

        Return oReadedFormaPago

    End Function



    Public Sub Save(ByVal pFormaPago As FormaPago)

        If (pFormaPago Is Nothing) Then
            Throw New ArgumentNullException("El parámetro FormaPago no puede ser nulo.")
        End If

        If (pFormaPago.IsNew) Then
            oCatalogoFormasPagoDG.Insert(pFormaPago)
        Else
            oCatalogoFormasPagoDG.Update(pFormaPago)
        End If

    End Sub



    Public Sub Delete(ByVal ID As String, ByVal VentaID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de FormaPago")
        End If

        If (ID.Length > 1) Then
            Throw New ArgumentException("El Código de Forma Pago no debe exceder los 1 caracteres de longitud.")
        End If

        oCatalogoFormasPagoDG.Delete(ID, VentaID)

    End Sub



    Public Function GetAll(ByVal TipoVentaID As String, Optional ByVal bExcluyeVCJA As Boolean = False) As DataSet
        'Public Function GetAll(ByVal OnlyEnabledRecords As Boolean) As DataSet

        Return oCatalogoFormasPagoDG.SelectAll(TipoVentaID, bExcluyeVCJA)
        'Return oCatalogoFormasPagoDG.SelectAll(OnlyEnabledRecords)

    End Function


    Public Function GetAllFormasPago(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oCatalogoFormasPagoMgr As CatalogoFormasPagoManager
        oCatalogoFormasPagoDG = New CatalogoFormasPagoDataGateway(Me)

        Return oCatalogoFormasPagoDG.LoadAllFormasPago(EnabledRecordsOnly)

        ' oCatalogoFormasPagoDG = Nothing

    End Function

    Public Function TarjetaUsadaHoy(ByVal NumTarjeta As String) As Boolean

        Return oCatalogoFormasPagoDG.SelectNumTarjetaDia(NumTarjeta)

    End Function

#End Region

#Region "Venta Asistida"
    Public Function GetTiposPagosEcommerce() As DataTable
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetTiposPagosEcommerce()
    End Function
#End Region

#Region "Carga de Tipo y Forma de Pago Ecomm"
    Public Function GetTiposPagosEcommerceByAlmacen() As DataTable
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetTiposPagosEcommerceByAlmacen()
    End Function

    Public Function GetFormasPagosEcommerceByAlmacen() As DataTable
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetFormasPagosEcommerceByAlmacen()
    End Function
#End Region
#Region "Carga de número de tienda de Tipo de Pago Ecomm por Id"
    Public Function GetNumTiendaTiposPagosEcommById(ByVal id As Integer) As String
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetNumTiendaTiposPagosEcommById(id)
    End Function

    Public Function GetNotaTicketTiposPagosEcommById(ByVal id As Integer) As String
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetNotaTicketTiposPagosEcommById(id)
    End Function
#End Region
#Region "Carga de configuración de ecommerce"
    Public Function GetConfigEcommerce() As ConfigEcomm
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetConfigEcommerce()
    End Function
#End Region
#Region "Consulta monto total de venta ecommerce del dia"
    Public Function GetMontoTotalPagoEcommerceByDate(ByVal fecha As DateTime) As Decimal
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetMontoTotalPagoEcommerceByDate(fecha)
    End Function

    Public Function GetDetallePagosEcommerceByDate(ByVal fecha As DateTime) As DataSet
        Dim gateway As New CatalogoFormasPagoDataGateway(Me)
        Return gateway.GetDetallePagosEcommerceByDate(fecha)
    End Function
#End Region


End Class
