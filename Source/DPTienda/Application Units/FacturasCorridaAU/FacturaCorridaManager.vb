Imports DportenisPro.DPTienda.Core

Public Class FacturaCorridaManager

    Dim oApplicationContext As ApplicationContext

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As FacturaCorrida

        Dim oNuevoFacturaCorrida As FacturaCorrida
        oNuevoFacturaCorrida = New FacturaCorrida(Me)

        Return oNuevoFacturaCorrida

    End Function

    Public Function Load(ByVal FacturaID As Integer) As DataSet

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        Return oFacturaCorridaDG.SelectCorrida(FacturaID)

    End Function

    Public Function LoadDetalle(ByVal FacturaID As Integer, ByVal CodCaja As String) As DataSet

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        Return oFacturaCorridaDG.SelectDetalle(FacturaID, CodCaja)

    End Function


    Public Function LoadDetalle(ByVal FacturaID As Integer, ByVal PedidoID As Integer) As DataSet

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        Return oFacturaCorridaDG.SelectDetalleByPedido(FacturaID, PedidoID)

    End Function

    Public Function Save(ByVal oFacturaCorrida As FacturaCorrida) As Boolean

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        Return oFacturaCorridaDG.InsertCorrida(oFacturaCorrida)

        oFacturaCorridaDG = Nothing

    End Function


    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Sub SaveMovimiento(ByVal TotalFactura As Decimal, ByVal oFacturaCorrida As FacturaCorrida, ByVal TotalNC As Decimal, ByVal CostoNC As Decimal)

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        oFacturaCorridaDG.InsertaMovimiento(TotalFactura, oFacturaCorrida, TotalNC, CostoNC)

        oFacturaCorridaDG = Nothing

    End Sub

    Public Function CostNC(ByVal DPValeID As Integer) As DataSet

        Dim oFacturaCorridaDG As FacturaCorridaDataGateway
        oFacturaCorridaDG = New FacturaCorridaDataGateway(Me)

        Return oFacturaCorridaDG.CostoNC(DPValeID)

    End Function

#End Region

#Region "Facturacion SiHay"
    Public Function IsArticuloEnAlmacen(ByVal CodArticulo As String) As Boolean
        Dim gateway As New FacturaCorridaDataGateway(Me)
        Return gateway.IsArticuloEnAlmacen(CodArticulo)
    End Function
#End Region

End Class
