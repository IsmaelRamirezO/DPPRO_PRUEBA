Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.GridEX
Public Class PedidoCajaOpenRecordDialogView
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataSet
        dsDataSource = Pedidos.GetAll(True, oAppContext.ApplicationConfiguration.NoCaja)
        With TargetGridEx
            .DataSource = dsDataSource.Tables(0)
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable

            .Columns("PedidoID").Visible = False
            .Columns("CodAlmacen").Visible = False
            .Columns("Status").Visible = False
            .Columns("CodTipoVenta").Visible = False
            .Columns("ClienteID").Visible = False
            .Columns("DescTotal").Visible = False
            .Columns("SubTotal").Visible = False
            .Columns("IVA").Visible = False
            .Columns("Total").Visible = False
            .Columns("impresa").Visible = False
            .Columns("Usuario").Visible = False
            .Columns("NumeroFacilito").Visible = False
            .Columns("FolioFISAP").Visible = False
            .Columns("DPesos").Visible = False
            .Columns("FCFolioSAP").Visible = False
            .Columns("FCFolioFISAP").Visible = False
            .Columns("ClientePGID").Visible = False
            .Columns("FolioSAP").Visible = False

            .Columns("Referencia").Width = 100
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").TextAlignment = TextAlignment.Center
            .Columns("Referencia").Caption = "Referencia"
            .Columns("Referencia").Position = 1

            .Columns("FolioPedido").Width = 100
            .Columns("FolioPedido").HeaderAlignment = TextAlignment.Center
            .Columns("FolioPedido").TextAlignment = TextAlignment.Center
            .Columns("FolioPedido").Caption = "Folio"
            .Columns("FolioPedido").Position = 2

            .Columns("CodVendedor").Width = 120
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Caption = "Vendedor"
            .Columns("CodVendedor").Position = 3

            .Columns("Fecha").Width = 90
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Position = 4

            .Columns("CodCaja").Width = 60
            .Columns("CodCaja").HeaderAlignment = TextAlignment.Center
            .Columns("CodCaja").TextAlignment = TextAlignment.Center
            .Columns("CodCaja").Caption = "Caja"
            .Columns("CodCaja").Position = 5

            .Columns("StatusRegistro").Width = 65
            .Columns("StatusRegistro").HeaderAlignment = TextAlignment.Center
            .Columns("StatusRegistro").Caption = "Habilitado"
            .Columns("StatusRegistro").Position = 6

        End With
    End Sub

End Class
