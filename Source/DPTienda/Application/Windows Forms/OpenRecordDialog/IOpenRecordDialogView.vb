Imports Janus.Windows.GridEX

Public Interface IOpenRecordDialogView

    ReadOnly Property AllowGroupBy() As Boolean
    ReadOnly Property AllowFilterBy() As Boolean
    'Sub SetupDataBinding(ByVal TargetGridEx As GridEX, Optional ByVal strCodPlaza As String = "", Optional ByVal strSelCriterio As String = "", Optional ByVal strCriterio As String = "")
    Sub SetupDataBinding(ByVal TargetGridEx As GridEX)
    Sub SetupView(ByVal TargetGridEx As GridEX)

End Interface