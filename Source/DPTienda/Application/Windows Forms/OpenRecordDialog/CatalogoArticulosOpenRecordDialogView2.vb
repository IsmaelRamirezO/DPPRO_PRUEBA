
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX


Public Class CatalogoArticulosOpenRecordDialogView2
    Implements IOpenRecordDialogView2



    Public Function FieldCodigo() As String Implements IOpenRecordDialogView2.FieldCodigo

        Return "Código"

    End Function



    Public Function FieldDescripcion() As String Implements IOpenRecordDialogView2.FieldDescripcion

        Return "Descripción"

    End Function

    Public Function FieldCodProveedor() As String Implements IOpenRecordDialogView2.FieldCodProveedor
        Return "CodArtProv"
    End Function



    Public Function SetupDataBinding() As System.Data.DataSet Implements IOpenRecordDialogView2.SetupDataBinding

        Dim dsDataSource As DataSet
        Dim oCatalogoArticulosMgr As New CatalogoArticuloManager(oAppContext)

        dsDataSource = oCatalogoArticulosMgr.GetAll(False)

        Return dsDataSource

    End Function



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView2.SetupView

        With TargetGridEx.Tables("CatalogoArticulos")

            .Columns("Código").Caption = "Código"
            .Columns("Código").Width = 150
            .Columns("Código").HeaderAlignment = TextAlignment.Center

            .Columns("CodArtProv").Caption = "Código Proveedor"
            .Columns("CodArtProv").Width = 150
            .Columns("CodArtProv").HeaderAlignment = TextAlignment.Center

            .Columns("Descripción").Caption = "Descripción"
            .Columns("Descripción").Width = 270
            .Columns("Descripción").HeaderAlignment = TextAlignment.Center

        End With

    End Sub

End Class
