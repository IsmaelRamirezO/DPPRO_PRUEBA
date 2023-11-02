Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos

Public Class DefectuososGOpenRecordDialogView
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
        Dim oDefectuososMgr As New DefectuososManager(oAppContext)

        dsDataSource = oDefectuososMgr.SelectAllDefectuososG(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "DefectuososG")
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("DefectuososG")

            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Visible = True

            .Columns("CodAlmacen").Caption = "Almacen"
            .Columns("CodAlmacen").Visible = True

            .Columns("Cantidad").Caption = "Cantidad"
            .Columns("Cantidad").Visible = True

            .Columns("Importe").Caption = "Importe"
            .Columns("Importe").Visible = True

            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Visible = True


        End With

    End Sub
End Class
