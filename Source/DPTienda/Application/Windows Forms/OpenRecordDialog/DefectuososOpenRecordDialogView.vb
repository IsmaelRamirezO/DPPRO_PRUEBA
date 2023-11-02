
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos

Public Class DefectuososOpenRecordDialogView

    Implements IOpenRecordDialogView

    'Private dsDataSource As DataSet

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("Defectuosos")

            .Columns("FolioMovimiento").Caption = "Folio"
            .Columns("CodCaja").Caption = "Caja"
            .Columns("CodArticulo").Caption = "Artículo"

            .Columns("FolioMovimiento").Visible = True
            .Columns("CodCaja").Visible = True
            .Columns("CodArticulo").Visible = True
            
        End With

    End Sub

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataSet
        Dim oDefectuososMgr As New DefectuososManager(oAppContext)

        dsDataSource = oDefectuososMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "Defectuosos")
            .RetrieveStructure()
        End With

    End Sub


End Class
