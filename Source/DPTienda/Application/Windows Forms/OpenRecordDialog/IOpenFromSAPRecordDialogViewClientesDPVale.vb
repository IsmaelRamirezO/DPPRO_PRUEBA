Imports Janus.Windows.GridEX

Public Interface IOpenFromSAPRecordDialogViewClientesDPVale

    ReadOnly Property AllowGroupBy() As Boolean
    ReadOnly Property AllowFilterBy() As Boolean
    Sub SetupDataBinding(ByVal TargetGridEx As GridEX, ByVal strCriterio As String, ByVal GrupoDeCuentas As String, ByVal S2Credit As Boolean)
    Sub SetupView(ByVal TargetGridEx As GridEX)

End Interface


