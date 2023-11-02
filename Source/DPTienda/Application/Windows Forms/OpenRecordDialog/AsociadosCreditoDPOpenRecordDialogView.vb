Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Imports Janus.Windows.GridEX

Public Class AsociadosCreditoDPOpenRecordDialogView
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding

        Dim dsDataSource As DataSet

        Dim oAbonosDPValeMgr As New AbonosDPValeManager(oAppContext)

        'dsDataSource = oAbonosDPValeMgr.GetAll(False)


        With TargetGridEx
            .SetDataBinding(dsDataSource, "Creditos")
            .RetrieveStructure()
        End With

        oAbonosDPValeMgr = Nothing

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Creditos")

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


        End With

    End Sub
End Class
