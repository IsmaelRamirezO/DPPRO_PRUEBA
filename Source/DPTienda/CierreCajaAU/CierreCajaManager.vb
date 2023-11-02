
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CierreCajaManager

    Private oApplicationContext As ApplicationContext
    Private oCierreCajaDG As CierreCajaDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCierreCajaDG = New CierreCajaDataGateway(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCierreCajaDG = Nothing

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

    Public Function Create() As Caja

        Dim oNuevaCaja As Caja
        oNuevaCaja = New Caja(Me)

        Return oNuevaCaja

    End Function



    Public Function Load(ByVal ID As Integer) As Caja

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de CierreCaja")
        End If


        Dim oReadedCaja As Caja

        oReadedCaja = oCierreCajaDG.SelectByID(ID)

        Return oReadedCaja

    End Function



    Public Function LoadByFechaCierre(ByVal FechaCierre As Date) As Caja

        'If (ID = 0) Then
        '    Throw New ArgumentException("Debe especificar un Código de CierreCaja")
        'End If


        Dim oReadedCaja As Caja

        oReadedCaja = oCierreCajaDG.SelectByFechaCierre(FechaCierre)

        Return oReadedCaja

    End Function



    Public Sub Save(ByVal pCaja As Caja, ByVal decMontoCajaUser As Decimal)

        If (pCaja Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Caja no puede ser nulo.")
        End If

        If (pCaja.IsNew) Then
            oCierreCajaDG.Insert(pCaja, decMontoCajaUser)
        Else
            'oCatalogoCajaDG.Update(pCaja)
        End If

    End Sub



    Public Function ValidarInicioCaja(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreCajaDG.ValidarInicioCaja(FechaCierreUser)

    End Function



    Public Function ValidarCierreCaja(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreCajaDG.ValidarCierreCaja(FechaCierreUser)

    End Function



    Public Function ValidarFacturaFolioInicial(ByVal intFacturaFolioUser As Integer, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarFacturaFolioInicial(intFacturaFolioUser, FechaCierre)

    End Function



    Public Function ValidarFacturaFolioFinal(ByVal intFacturaFolioUser As Integer, ByVal datFechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarFacturaFolioFinal(intFacturaFolioUser, datFechaCierre)

    End Function



    Public Function ValidarFecha(ByVal FechaCierreUser As Date) As Boolean

        Return oCierreCajaDG.ValidarFecha(FechaCierreUser)

    End Function



    Public Function CalcularTotalRetiros(ByVal FechaCierreUser As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalRetiros(FechaCierreUser)

    End Function
    Public Function CalcularTotalRetirosREP(ByVal FechaCierreUser As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalRetirosREP(FechaCierreUser)

    End Function


    Public Function CalcularTotalFondoCaja(ByVal FechaCierreUser As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFondoCaja(FechaCierreUser)

    End Function
    Public Function CalcularTotalFondoCajaREP(ByVal FechaCierreUser As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFondoCajaREP(FechaCierreUser)

    End Function


    Public Function ValidarMontoTarjetaElectronica(ByVal decMontoTElectronicaUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarMontoTarjetaElectronica(decMontoTElectronicaUser, FechaCierre)

    End Function
    Public Function TarjetaElectronicaGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFacturasApartadosTE(FechaCierre)

    End Function
    Public Function TarjetaElectronicaGETREP(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFacturasApartadosTEREP(FechaCierre)

    End Function

    Public Function TarjetaByBancoGETREP(ByVal FechaCierre As Date, ByVal CodBanco As String, ByVal TipoTarjeta As String) As Decimal

        Return oCierreCajaDG.CalcularTotalByBanco(FechaCierre, CodBanco, TipoTarjeta)

    End Function

    Public Function ValidarMontoTarjetaManual(ByVal decMontoTManualUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarMontoTarjetaManual(decMontoTManualUser, FechaCierre)

    End Function
    Public Function TarjetaManualGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFacturasApartadosTM(FechaCierre)

    End Function
    Public Function TarjetaManualGETREP(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalFacturasApartadosTMREP(FechaCierre)

    End Function

    Public Function ValidarMontoFacturado(ByVal decMontoFacturadoUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarMontoFacturado(decMontoFacturadoUser, FechaCierre)

    End Function
    Public Function MontoFacturadoGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoFacturado(FechaCierre)

    End Function
    Public Function MontoPedidosSHGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoPedidosSH(FechaCierre)

    End Function
    Public Function MontoFacturadoGETREP(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoFacturadoREP(FechaCierre)

    End Function

    Public Function ValidarMontoAbonosApartados(ByVal decMontoAbonosUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarMontoAbonosApartados(decMontoAbonosUser, FechaCierre)

    End Function
    Public Function AbonosApartadosGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoAbonosApartados(FechaCierre)

    End Function
    Public Function AbonosApartadosGETREP(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoAbonosApartadosREP(FechaCierre)

    End Function

    Public Function ValidarMontoCreditoDirecto(ByVal decMontoCreditoDirectoUser As Decimal, ByVal FechaCierre As Date) As Boolean

        Return oCierreCajaDG.ValidarMontoCreditoDirecto(decMontoCreditoDirectoUser, FechaCierre)

    End Function
    Public Function CreditoDirectoGET(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoApartadosCDT(FechaCierre)

    End Function
    Public Function CreditoDirectoGETREP(ByVal FechaCierre As Date) As Decimal

        Return oCierreCajaDG.CalcularTotalMontoApartadosCDTREP(FechaCierre)

    End Function
    Public Function SelByInicioCajaID(ByVal InicioCajaID As Integer) As Boolean
        Return oCierreCajaDG.SelByInicioCajaID(InicioCajaID)
    End Function

    Public Function FacturasDelDia(ByVal FechaCierre As Date) As Boolean
        Return oCierreCajaDG.FacturasDelDia(FechaCierre)
    End Function

    Public Function TotalFacturasAGet(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.TotalFacturasASel(FechaCierre)
    End Function
    Public Function TotalFacturasAGetREP(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.TotalFacturasASelREP(FechaCierre)
    End Function

    Public Function TotalFacturasCGet(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.TotalFacturasCSel(FechaCierre)
    End Function
    Public Function TotalFacturasCGetREP(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.TotalFacturasCSelREP(FechaCierre)
    End Function
    Public Function ValidarFoliosFacturas(ByVal intFacturaFolioInicio As Integer, _
                                          ByVal intFacturaFolioFin As Integer, ByRef intFolioNoGuardado As Integer _
                                          ) As Boolean

        Return oCierreCajaDG.ValidarFoliosFacturas(intFacturaFolioInicio, intFacturaFolioFin, intFolioNoGuardado)

    End Function

    Public Function FormasPagoGET(ByVal FechaCierre As Date, ByVal sp As String) As Decimal
        Return oCierreCajaDG.CalcularTotalFormasPago(FechaCierre, sp)
    End Function
    Public Function FormasPagoGETREP(ByVal FechaCierre As Date, ByVal sp As String) As Decimal
        Return oCierreCajaDG.CalcularTotalFormasPagoREP(FechaCierre, sp)
    End Function
    Public Function NotasCreditoGET(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.CalcularTotalNotasCredito(FechaCierre)
    End Function
    Public Function NotasCreditoGETREP(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.CalcularTotalNotasCreditoREP(FechaCierre)
    End Function

    Public Function NotasCreditoFoliosGETREP(ByVal FechaCierre As Date) As DataSet
        Return oCierreCajaDG.NotasCreditoFoliosGetREP(FechaCierre)
    End Function

    Public Function GetTotalIngresos(ByVal FechaCierre As Date) As DataSet
        oCierreCajaDG = New CierreCajaDataGateway(Me)
        Return oCierreCajaDG.GetTotalIngresosSel(FechaCierre)
    End Function

#End Region

#Region "Pagos Ecommerce"

    Public Function GetTotalPagosEcommerce(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Decimal
        Return oCierreCajaDG.GetTotalPagosEcommerce(CodAlmacen, FechaInicio, FechaFin)
    End Function

    Public Function GetTotalFormasPagoEcommerce(ByVal FormaPago As Integer, ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Decimal
        Return oCierreCajaDG.GetTotalFormasPagoEcommerce(FormaPago, CodAlmacen, FechaInicio, FechaFin)
    End Function

#End Region

#Region "Pagos DPCA"

    '---------------------------------------------------------------------------------------------------------------
    ' JNAVA (24.03.2015): Obtenemos lo correspondiente a los Abonos de DPCARD
    '---------------------------------------------------------------------------------------------------------------
    Public Function GetPagosDPCA(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Hashtable
        Return oCierreCajaDG.GetTotalPagosDPCA(CodAlmacen, FechaInicio, FechaFin)
    End Function

#End Region

End Class
