Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports Janus.Windows.GridEX

Public Class OrdenesCompraOpenRecordDialogView
    Implements IOpenRecordDialogView

#Region "Variable"

    Private m_TipoConsignacion As String

#End Region

#Region "Propiedades"

    Public Property TipoConsignacion As String
        Get
            Return m_TipoConsignacion
        End Get
        Set(ByVal value As String)
            m_TipoConsignacion = value
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
        Dim TraspasoEntradaMgr As New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        dsDataSource = TraspasoEntradaMgr.GetZdproPedido(Me.TipoConsignacion)
        With TargetGridEx
            .DataSource = dsDataSource
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable

            .Columns("CodAlmacen").Width = 120
            .Columns("CodAlmacen").HeaderAlignment = TextAlignment.Center
            .Columns("CodAlmacen").Caption = "Almacen"
            .Columns("CodAlmacen").Position = 0

            .Columns("DocMaterial").Width = 100
            .Columns("DocMaterial").HeaderAlignment = TextAlignment.Center
            .Columns("DocMaterial").TextAlignment = TextAlignment.Center
            .Columns("DocMaterial").Caption = "Doc Material"
            .Columns("DocMaterial").Position = 1

            .Columns("PedidoSAP").Width = 130
            .Columns("PedidoSAP").HeaderAlignment = TextAlignment.Center
            .Columns("PedidoSAP").TextAlignment = TextAlignment.Center
            .Columns("PedidoSAP").Caption = "Folio"
            .Columns("PedidoSAP").Position = 2

            .Columns("Proveedor").Width = 130
            .Columns("Proveedor").HeaderAlignment = TextAlignment.Center
            .Columns("Proveedor").TextAlignment = TextAlignment.Center
            .Columns("Proveedor").Caption = "Proveedor"
            .Columns("Proveedor").Position = 3


            .Columns("Responsable").Width = 120
            .Columns("Responsable").HeaderAlignment = TextAlignment.Center
            .Columns("Responsable").Caption = "Responsable"
            .Columns("Responsable").Position = 4

            .Columns("Fecha").Width = 90
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Position = 5

        End With
    End Sub
End Class
