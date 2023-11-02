
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX


Public Class CatalogoArticulosOpenRecordDialogView2
    Implements IOpenRecordDialogView2



    Public Function FieldCodigo() As String Implements IOpenRecordDialogView2.FieldCodigo

        Return "C�digo"

    End Function



    Public Function FieldDescripcion() As String Implements IOpenRecordDialogView2.FieldDescripcion

        Return "Descripci�n"

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

            .Columns("C�digo").Caption = "C�digo"
            .Columns("C�digo").Width = 150
            .Columns("C�digo").HeaderAlignment = TextAlignment.Center

            .Columns("CodArtProv").Caption = "C�digo Proveedor"
            .Columns("CodArtProv").Width = 150
            .Columns("CodArtProv").HeaderAlignment = TextAlignment.Center

            .Columns("Descripci�n").Caption = "Descripci�n"
            .Columns("Descripci�n").Width = 270
            .Columns("Descripci�n").HeaderAlignment = TextAlignment.Center

        End With

    End Sub

End Class
