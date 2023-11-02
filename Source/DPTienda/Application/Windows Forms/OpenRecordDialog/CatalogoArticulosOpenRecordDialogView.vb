Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX

Public Class CatalogoArticulosOpenRecordDialogView


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
        Dim oCatalogoArticulosMgr As New CatalogoArticuloManager(oAppContext)

        dsDataSource = oCatalogoArticulosMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoArticulos")
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("CatalogoArticulos")

            .Columns("Código").Caption = "Código"
            .Columns("Código").Width = 150
            .Columns("Código").HeaderAlignment = TextAlignment.Center

            .Columns("Descripción").Caption = "Descripcion"
            .Columns("Descripción").Width = 290
            .Columns("Descripción").HeaderAlignment = TextAlignment.Center

        End With
    End Sub
End Class
