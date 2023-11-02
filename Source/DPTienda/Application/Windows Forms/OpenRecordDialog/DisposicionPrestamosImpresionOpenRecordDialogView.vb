Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports Janus.Windows.GridEX

Public Class DisposicionPrestamosImpresionOpenRecordDialogView
    Implements IOpenRecordDialogView


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
        Dim oDPVFMgr As New DPValeFinancieroManager(oAppContext, oConfigCierreFI)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        dsDataSource = oDPVFMgr.GetDisposiciones(oAppContext.ApplicationConfiguration.Almacen, oSAPMgr.MSS_GET_SY_DATE_TIME())
        With TargetGridEx
            .DataSource = dsDataSource
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable
            .Columns("ServicioId").Visible = False
            .Columns("NoServicio").Visible = False
            .Columns("EstatusDisp").Visible = False
            .Columns("FechaDispConf").Visible = False
            .Columns("UsuarioRep").Visible = False
            .Columns("FechaRep").Visible = False
            .Columns("PaymentPlan").Visible = False
            .Columns("PlazoDisp").Visible = False
            .Columns("SKU").Visible = False
            .Columns("IPReproceso").Visible = False
            .Columns("MontoSeguro").Visible = False
            .Columns("CMSeguro").Visible = False
            .Columns("TicketSeguro").Visible = False
            .Columns("Generado").Visible = False
            .Columns("Deslizada").Visible = False
            .Columns("TransactionId").Visible = False

            .Columns("CodAlmacen").Width = 80
            .Columns("CodAlmacen").HeaderAlignment = TextAlignment.Center
            .Columns("CodAlmacen").TextAlignment = TextAlignment.Center
            .Columns("CodAlmacen").Caption = "Almacen"
            .Columns("CodAlmacen").Position = 1

            .Columns("Caja").Width = 50
            .Columns("Caja").HeaderAlignment = TextAlignment.Center
            .Columns("Caja").TextAlignment = TextAlignment.Center
            .Columns("Caja").Caption = "Caja"
            .Columns("Caja").Position = 2


            .Columns("CodVendedor").Width = 80
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Caption = "Vendedor"
            .Columns("CodVendedor").Position = 3

            .Columns("TransactionSequenceNumber").Width = 50
            .Columns("TransactionSequenceNumber").HeaderAlignment = TextAlignment.Center
            .Columns("TransactionSequenceNumber").TextAlignment = TextAlignment.Center
            .Columns("TransactionSequenceNumber").Caption = "CM"
            .Columns("TransactionSequenceNumber").Position = 4

            .Columns("Monto").Width = 100
            .Columns("Monto").HeaderAlignment = TextAlignment.Center
            .Columns("Monto").TextAlignment = TextAlignment.Near
            .Columns("Monto").Caption = "Monto"
            .Columns("Monto").Position = 5

            .Columns("Banco").Width = 100
            .Columns("Banco").HeaderAlignment = TextAlignment.Center
            .Columns("Banco").TextAlignment = TextAlignment.Near
            .Columns("Banco").Caption = "Banco"
            .Columns("Banco").Position = 6

            .Columns("FechaKarum").Width = 100
            .Columns("FechaKarum").HeaderAlignment = TextAlignment.Center
            .Columns("FechaKarum").Caption = "Fecha"
            .Columns("FechaKarum").Position = 7

        End With
    End Sub
End Class
