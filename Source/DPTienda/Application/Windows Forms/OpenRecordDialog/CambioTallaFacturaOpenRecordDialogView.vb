Imports DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU
Imports Janus.Windows.GridEX

Public Class CambioTallaFacturaOpenRecordDialogView

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
        Dim oCambioTallaMgr As New CambioTallaManager(oAppContext)

        dsDataSource = oCambioTallaMgr.ListFactura(False)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "Facturas")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Facturas")
            .Columns("ID").Width = 60
            .Columns("ID").HeaderAlignment = TextAlignment.Center
            .Columns("Caja").Width = 45
            .Columns("Caja").HeaderAlignment = TextAlignment.Center
            .Columns("Caja").TextAlignment = TextAlignment.Center
            .Columns("Folio").Width = 70
            .Columns("Folio").HeaderAlignment = TextAlignment.Center
            .Columns("Folio").HeaderAlignment = TextAlignment.Center
            .Columns("Vendedor").Width = 110
            .Columns("Vendedor").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").Width = 80
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Habilitado").Width = 65
            .Columns("Habilitado").HeaderAlignment = TextAlignment.Center
        End With
    End Sub
End Class

