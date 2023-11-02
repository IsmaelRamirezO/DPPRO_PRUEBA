
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosSalida


Public Class TraspasoSalidaOpenRecordDialogView
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
        Dim oTraspasoMgr As New TraspasosSalidaManager(oAppContext)

        dsDataSource = oTraspasoMgr.GetAll(oAppContext.ApplicationConfiguration.Almacen)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "Traspaso")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("Traspaso")

            .Columns("Status").Caption = "Status"
            .Columns("Status").Width = 50

            .Columns("Folio").Caption = "Folio"
            .Columns("Folio").Width = 100

            .Columns("Almacen").Caption = "S. Origen"
            .Columns("Almacen").Width = 50

            .Columns("Origen").Caption = "S. Destino"
            .Columns("Origen").Width = 50

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

            .Columns("TraspasoID").Visible = False

        End With

    End Sub

#End Region

End Class
