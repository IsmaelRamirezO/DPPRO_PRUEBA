Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports Janus.Windows.GridEX

Public Class AsociadosOpenRecordDialogView

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

        Dim oAsociadosMgr As New AsociadosManager(oAppContext)

        dsDataSource = oAsociadosMgr.GetAll(False)
        With TargetGridEx
            .SetDataBinding(dsDataSource, "Asociados")
            .RetrieveStructure()
        End With

        oAsociadosMgr = Nothing

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Asociados")

            Dim intCol As Integer

            For intCol = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next

            .Columns("AsociadoID").Caption = "Cod. Asociado"
            .Columns("AsociadoID").Width = 50
            .Columns("AsociadoID").HeaderAlignment = TextAlignment.Center
            .Columns("AsociadoID").Visible = True

            .Columns("ClienteID").Caption = "Cod. Cliente"
            .Columns("ClienteID").Width = 50
            .Columns("ClienteID").HeaderAlignment = TextAlignment.Center
            .Columns("ClienteID").Visible = True

            .Columns("Nombre").Caption = "Nombre"
            .Columns("Nombre").Width = 120
            .Columns("Nombre").HeaderAlignment = TextAlignment.Center
            .Columns("Nombre").Visible = True

            .Columns("ApellidoPaterno").Caption = "Apellido Paterno"
            .Columns("ApellidoPaterno").Width = 110
            .Columns("ApellidoPaterno").HeaderAlignment = TextAlignment.Center
            .Columns("ApellidoPaterno").Visible = True

            .Columns("ApellidoMaterno").Caption = "Apellido Materno"
            .Columns("ApellidoMaterno").Width = 110
            .Columns("ApellidoMaterno").HeaderAlignment = TextAlignment.Center
            .Columns("ApellidoMaterno").Visible = True

            .Columns("EsCreditoDPVale").Visible = False

        End With

    End Sub

End Class
