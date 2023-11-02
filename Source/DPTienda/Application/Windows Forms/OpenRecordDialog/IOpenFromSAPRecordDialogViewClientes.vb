Imports Janus.Windows.GridEX

Public Interface IOpenFromSAPRecordDialogViewClientes

    'este
    ReadOnly Property AllowGroupBy() As Boolean
    ReadOnly Property AllowFilterBy() As Boolean
    Sub SetupDataBinding(ByVal TargetGridEx As GridEX, ByVal strCriterio As String, ByVal GrupoDeCuentas As String, Optional ByVal Tipo As Integer = 0, Optional ByVal TipoVenta As String = "")
    Sub SetupView(ByVal TargetGridEx As GridEX)

End Interface


