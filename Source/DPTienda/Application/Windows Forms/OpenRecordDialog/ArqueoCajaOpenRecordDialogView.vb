Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU

Public Class ArqueoCajaOpenRecordDialogView
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

        Dim oArqueoCajamgr As New ArqueoDeCajaManager(oAppContext)


        dsDataSource = oArqueoCajamgr.SelectAll(False)


        With TargetGridEx
            .SetDataBinding(dsDataSource, "ArqueoCaja")
            .RetrieveStructure()
        End With

        oArqueoCajamgr = Nothing

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("ArqueoCaja")

            Dim intCol As Integer

            For intCol = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next


            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Width = 50
            .Columns("Folio").Visible = True

            .Columns("Caja").Caption = "Caja"
            .Columns("Caja").Width = 50
            .Columns("Caja").Visible = True

            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").Visible = True

            

        End With


    End Sub
End Class
