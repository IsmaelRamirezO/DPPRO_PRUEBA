Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada

Public Class OpenTraspasoEntradaVirtual
    Implements IOpenRecordDialogView

#Region "Properties"
    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dtTraspaso As DataTable
        Dim oTraspasoMgr As New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        dtTraspaso = oTraspasoMgr.GetTraspasosVirtual(oAppContext.ApplicationConfiguration.Almacen)
        With TargetGridEx
            .DataSource = dtTraspaso
            .RetrieveStructure()

        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables(0)

            .Columns("FolioTraspaso").Caption = "Folio Traspaso"
            .Columns("FolioTraspaso").Width = 120

            .Columns("Origen").Caption = "S. Origen"
            .Columns("Origen").Width = 100

            .Columns("Destino").Caption = "S. Destino"
            .Columns("Destino").Width = 100

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

            .Columns("Usuario").Caption = "Creado por"
            .Columns("Usuario").Width = 100

            .Columns("MovEntID").Visible = False

            .Columns("Observaciones").Visible = False

        End With
    End Sub
#End Region

End Class
