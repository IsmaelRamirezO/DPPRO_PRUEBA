
Imports Janus.Windows.GridEX

Public Interface IOpenRecordDialogViewClientes

    ReadOnly Property AllowGroupBy() As Boolean
    ReadOnly Property AllowFilterBy() As Boolean
    Sub SetupDataBinding(ByVal TargetGridEx As GridEX, Optional ByVal strSelCriterio As String = "", Optional ByVal strCriterio As String = "", Optional ByVal GrupoDeCuentas As String = "D018")
    Sub SetupView(ByVal TargetGridEx As GridEX)

End Interface