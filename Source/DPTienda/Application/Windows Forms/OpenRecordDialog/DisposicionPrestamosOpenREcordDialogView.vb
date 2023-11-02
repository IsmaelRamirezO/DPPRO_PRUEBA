Imports DportenisPro.DPTienda.ApplicationUnits.DPValeFinanciero
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports Janus.Windows.GridEX

Public Class DisposicionPrestamosOpenRecordDialogView
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
        dsDataSource = oDPVFMgr.GetDisposicionEfeClubDPSolicitado(oAppContext.ApplicationConfiguration.Almacen)
        With TargetGridEx
            .DataSource = dsDataSource
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.RootTable
            .Columns("TransactionId").Visible = False
            .Columns("ServicioId").Visible = False
            .Columns("NoServicio").Visible = False
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
            .Columns("AccountNumber").Visible = False
            .Columns("NoTarjeta").Visible = False

            .Columns("CodAlmacen").Width = 50
            .Columns("CodAlmacen").HeaderAlignment = TextAlignment.Center
            .Columns("CodAlmacen").TextAlignment = TextAlignment.Center
            .Columns("CodAlmacen").Caption = "Tienda"
            .Columns("CodAlmacen").Position = 0

            .Columns("Caja").Width = 50
            .Columns("Caja").HeaderAlignment = TextAlignment.Center
            .Columns("Caja").TextAlignment = TextAlignment.Center
            .Columns("Caja").Caption = "Caja"
            .Columns("Caja").Position = 1


            .Columns("CodVendedor").Width = 80
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Caption = "Vendedor"
            .Columns("CodVendedor").Position = 2

            .Columns("NombreCliente").Width = 80
            .Columns("NombreCliente").HeaderAlignment = TextAlignment.Center
            .Columns("NombreCliente").Caption = "Nombre Cliente"
            .Columns("NombreCliente").Position = 3

            .Columns("EstatusDisp").Width = 100
            .Columns("EstatusDisp").HeaderAlignment = TextAlignment.Center
            .Columns("EstatusDisp").Caption = "Estatus"
            .Columns("EstatusDisp").Position = 4

            .Columns("CodVendedor").Width = 100
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Caption = "Vendedor"
            .Columns("CodVendedor").Position = 5

            .Columns("TransactionSequenceNumber").Width = 50
            .Columns("TransactionSequenceNumber").HeaderAlignment = TextAlignment.Center
            .Columns("TransactionSequenceNumber").TextAlignment = TextAlignment.Center
            .Columns("TransactionSequenceNumber").Caption = "CM"
            .Columns("TransactionSequenceNumber").Position = 6

            .Columns("Monto").Width = 100
            .Columns("Monto").HeaderAlignment = TextAlignment.Center
            .Columns("Monto").TextAlignment = TextAlignment.Near
            .Columns("Monto").Caption = "Monto"
            .Columns("Monto").Position = 7

            .Columns("Banco").Width = 100
            .Columns("Banco").HeaderAlignment = TextAlignment.Center
            .Columns("Banco").TextAlignment = TextAlignment.Near
            .Columns("Banco").Caption = "Banco"
            .Columns("Banco").Position = 8

            .Columns("FechaKarum").Width = 100
            .Columns("FechaKarum").HeaderAlignment = TextAlignment.Center
            .Columns("FechaKarum").Caption = "Fecha"
            .Columns("FechaKarum").Position = 9

            .Columns("ClubDP").Width = 100
            .Columns("ClubDP").HeaderAlignment = TextAlignment.Center
            .Columns("ClubDP").Caption = "Club DP"
            .Columns("ClubDP").Position = 10

            .Columns("IFE").Width = 100
            .Columns("IFE").HeaderAlignment = TextAlignment.Center
            .Columns("IFE").Caption = "Num. ID"
            .Columns("IFE").Position = 11


        End With
    End Sub
End Class
