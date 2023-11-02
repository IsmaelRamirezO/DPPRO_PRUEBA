Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.GridEX
Public Class PedidosSAPOpenRecordDialogView
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
        Dim dsDataSource As DataTable
        dsDataSource = Pedidos.GetAllActivosSAP("P-S,PE-S,PR,PF,IP")
        AgruparPedidosSH(dsDataSource)
        With TargetGridEx
            .DataSource = dsDataSource
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable

            .Columns("MANDT").Visible = False
            .Columns("ID_SOLICITUD").Visible = False
            .Columns("CESUM").Visible = False
            .Columns("CEDES").Visible = False
            .Columns("STATUS_SUM").Visible = False
            .Columns("TIPO_ENVIO").Visible = False
            .Columns("ENTREGA").Visible = False
            .Columns("FOLIO_ENTREGA").Visible = False
            .Columns("FACTURA").Visible = False
            .Columns("ENVIADO").Visible = False
            .Columns("ID_SOLICITUD").Visible = False
            .Columns("FECHA_MODIF").Visible = False


            .Columns("VBELN").Width = 100
            .Columns("VBELN").HeaderAlignment = TextAlignment.Center
            .Columns("VBELN").TextAlignment = TextAlignment.Center
            .Columns("VBELN").Caption = "Folio SAP"
            .Columns("VBELN").Position = 1

            .Columns("Referencia").Width = 130
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").TextAlignment = TextAlignment.Center
            .Columns("Referencia").Caption = "Referencia"
            .Columns("Referencia").Position = 2


            .Columns("RESPONSABLE").Width = 120
            .Columns("RESPONSABLE").HeaderAlignment = TextAlignment.Center
            .Columns("RESPONSABLE").Caption = "Vendedor"
            .Columns("RESPONSABLE").Position = 3

            .Columns("FECHA").Width = 90
            .Columns("FECHA").HeaderAlignment = TextAlignment.Center
            .Columns("FECHA").TextAlignment = TextAlignment.Center
            .Columns("FECHA").Caption = "Fecha"
            .Columns("FECHA").Position = 4

            .Columns("HORA").Width = 90
            .Columns("HORA").HeaderAlignment = TextAlignment.Center
            .Columns("HORA").TextAlignment = TextAlignment.Near
            .Columns("HORA").Caption = "Hora"
            .Columns("HORA").Position = 5

            .Columns("GUIA").Width = 90
            .Columns("GUIA").HeaderAlignment = TextAlignment.Center
            .Columns("GUIA").TextAlignment = TextAlignment.Near
            .Columns("GUIA").Caption = "Guia"
            .Columns("GUIA").Position = 6

            .Columns("STATUS_DES").Width = 65
            .Columns("STATUS_DES").HeaderAlignment = TextAlignment.Center
            .Columns("STATUS_DES").Caption = "Status"
            .Columns("STATUS_DES").Position = 7

        End With
    End Sub

End Class
