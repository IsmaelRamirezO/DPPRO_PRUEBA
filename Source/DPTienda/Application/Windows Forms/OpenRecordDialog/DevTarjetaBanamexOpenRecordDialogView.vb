Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.GridEX

Public Class DevTarjetaBanamexOpenRecordDialogView
    Implements IOpenRecordDialogView

#Region "Variables de instancia"

    Private m_TipoPedidos As Integer

#End Region

#Region "Propiedades"

    Public Property TipoPedidos As Integer
        Get
            Return m_TipoPedidos
        End Get
        Set(ByVal value As Integer)
            m_TipoPedidos = value
        End Set
    End Property

#End Region

    Public ReadOnly Property AllowFilterBy As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataTable
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        dsDataSource = FacturaMgr.GetPedidosFormasPagoBanamex(oAppContext.ApplicationConfiguration.Almacen, Me.TipoPedidos)
        With TargetGridEx
            .DataSource = dsDataSource
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable
            If Me.TipoPedidos = 1 Then
                .Columns("FacturaId").Visible = False
            ElseIf Me.TipoPedidos = 2 Then
                .Columns("PedidoId").Visible = False
            End If

            .Columns("CodAlmacen").Width = 100
            .Columns("CodAlmacen").HeaderAlignment = TextAlignment.Center
            .Columns("CodAlmacen").TextAlignment = TextAlignment.Center
            .Columns("CodAlmacen").Caption = "Cod Almacen"
            .Columns("CodAlmacen").Position = 1

            .Columns("CodCaja").Width = 130
            .Columns("CodCaja").HeaderAlignment = TextAlignment.Center
            .Columns("CodCaja").TextAlignment = TextAlignment.Center
            .Columns("CodCaja").Caption = "Caja"
            .Columns("CodCaja").Position = 2


            .Columns("Referencia").Width = 120
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").Caption = "Referencia"
            .Columns("Referencia").Position = 3


            .Columns("Folio").Width = 120
            .Columns("Folio").HeaderAlignment = TextAlignment.Center
            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Position = 4

            .Columns("Fecha").Width = 90
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Position = 5

        End With
    End Sub
End Class
