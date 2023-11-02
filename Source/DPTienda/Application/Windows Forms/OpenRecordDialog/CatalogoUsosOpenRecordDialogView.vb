Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoUsos

Public Class CatalogoUsosOpenRecordDialogView
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

        Dim dsData As DataSet
        Dim oCatalogoUsosMgr As New UsosCatalogManager(oAppContext)

        dsData = oCatalogoUsosMgr.GetAll(False)

        TargetGridEx.SetDataBinding(dsData, "CatalogoUsos")
        TargetGridEx.RetrieveStructure()

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoUsos")

            .Columns("CodUso").Caption = "Código"
            .Columns("Descripcion").Caption = "Descripción"

            .Columns("Usuario").Visible = True

            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"
            .Columns("Fecha").Visible = False

            .Columns("StatusRegistro").Caption = "Habilitado"

        End With

    End Sub

End Class
