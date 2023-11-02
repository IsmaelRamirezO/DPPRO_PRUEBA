Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida

Public Class TraspasoFisicoSalida
    Implements IOpenRecordDialogView
#Region "Properties"

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return True
        End Get
    End Property



    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding

        Dim dsDataSource As DataSet
        Dim oTraspasoMgr As New TraspasosSalidaManager(oAppContext, oConfigCierreFI)

        dsDataSource = oTraspasoMgr.SelectTFSelAll(oAppContext.ApplicationConfiguration.Almacen)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "TraspasosFisicos")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables(0)

            .Columns("FolioTraspaso").Caption = "Folio"
            .Columns("FolioTraspaso").Width = 80

            .Columns("Origen").Caption = "S. Origen"
            .Columns("Origen").Width = 50

            .Columns("Destino").Caption = "S. Destino"
            .Columns("Destino").Width = 150

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

            .Columns("Usuario").Caption = "Usuario"
            .Columns("Usuario").Width = 100

            .Columns("Observaciones").Visible = False
            .Columns("MovID").Visible = False

        End With

    End Sub

#End Region

End Class
