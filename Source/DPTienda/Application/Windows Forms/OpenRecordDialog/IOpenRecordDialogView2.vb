
Imports Janus.Windows.GridEX


Public Interface IOpenRecordDialogView2

    Function SetupDataBinding() As DataSet

    Sub SetupView(ByVal TargetGridEx As GridEX)

    Function FieldCodigo() As String

    Function FieldCodProveedor() As String

    Function FieldDescripcion() As String

End Interface

