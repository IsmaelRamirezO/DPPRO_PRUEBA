Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos

Public Class DefectuososByCodArticuloOpenRecordDialogView
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

        dsDataSource = oDefectuososMgr.GetAllCodigos(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "Defectuosos")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Defectuosos")

            .Columns("CodArticulo").Caption = "Código de Artículo"
            .Columns("CodArticulo").Visible = True
            
        End With
    End Sub
End Class
