Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports Janus.Windows.GridEX

Public Class FacturaCajaOpenRecordDialogView

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
        Dim oFacturaMgr As FacturaManager

        oFacturaMgr = New FacturaManager(oAppContext)

        dsDataSource = oFacturaMgr.GetAll(False, oAppContext.ApplicationConfiguration.NoCaja)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "Facturas")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Facturas")

            .Columns("FacturaID").Visible = False
            .Columns("CodAlmacen").Visible = False
            .Columns("ApartadoID").Visible = False
            .Columns("NotaCreditoID").Visible = False
            .Columns("Status").Visible = False
            .Columns("CodTipoVenta").Visible = False
            .Columns("ClienteID").Visible = False
            .Columns("DescTotal").Visible = False
            .Columns("SubTotal").Visible = False
            .Columns("IVA").Visible = False
            .Columns("Total").Visible = False
            .Columns("impresa").Visible = False
            .Columns("Usuario").Visible = False
            .Columns("FolioSAP").Visible = True


            .Columns("Referencia").Width = 100
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").TextAlignment = TextAlignment.Center
            .Columns("Referencia").Caption = "Referencia"
            .Columns("Referencia").Position = 1

            .Columns("FolioSAP").Width = 100
            .Columns("FolioSAP").HeaderAlignment = TextAlignment.Center
            .Columns("FolioSAP").TextAlignment = TextAlignment.Center
            .Columns("FolioSAP").Caption = "Folio SAP"
            .Columns("FolioSAP").Position = 2

            .Columns("FolioFactura").Width = 100
            .Columns("FolioFactura").HeaderAlignment = TextAlignment.Center
            .Columns("FolioFactura").TextAlignment = TextAlignment.Center
            .Columns("FolioFactura").Caption = "Folio"
            .Columns("FolioFactura").Position = 3

            .Columns("CodVendedor").Width = 120
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Caption = "Vendedor"
            .Columns("CodVendedor").Position = 4

            .Columns("Fecha").Width = 90
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Position = 5

            .Columns("CodCaja").Width = 60
            .Columns("CodCaja").HeaderAlignment = TextAlignment.Center
            .Columns("CodCaja").TextAlignment = TextAlignment.Center
            .Columns("CodCaja").Caption = "Caja"
            .Columns("CodCaja").Position = 6

            .Columns("StatusRegistro").Width = 65
            .Columns("StatusRegistro").HeaderAlignment = TextAlignment.Center
            .Columns("StatusRegistro").Caption = "Habilitado"
            .Columns("StatusRegistro").Position = 7

        End With
    End Sub

End Class
