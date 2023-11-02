Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports Janus.Windows.GridEX

Public Class AjusteTallaOpenRecordDialogView
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
        Dim oAjustesMgr As New AjusteGeneralTallaManager(oAppContext)

        dsDataSource = oAjustesMgr.GetAll()
        With TargetGridEx
            .SetDataBinding(dsDataSource, "Ajustes")
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Ajustes")
            .Columns("Folio").Caption = "Folio Ajuste"
        End With
    End Sub

End Class
