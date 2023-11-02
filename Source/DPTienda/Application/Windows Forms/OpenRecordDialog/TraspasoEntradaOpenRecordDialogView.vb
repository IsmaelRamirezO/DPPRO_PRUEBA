

Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada


Public Class TraspasoEntradaOpenRecordDialogView
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
        Dim oTraspasoMgr As New TraspasosEntradaManager(oAppContext)

        dsDataSource = oTraspasoMgr.GetAll(oAppContext.ApplicationConfiguration.Almacen)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "Traspaso")
            .RetrieveStructure()

        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("Traspaso")

            .Columns("FolioSAP").Caption = "Folio SAP"
            .Columns("FolioSAP").Width = 120

            .Columns("Origen").Caption = "S. Origen"
            .Columns("Origen").Width = 100

            .Columns("Destino").Caption = "S. Destino"
            .Columns("Destino").Width = 100

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

            .Columns("IdTraspaso").Visible = False
            .Columns("Trasportista").Visible = False
            .Columns("Bultos").Visible = False
            .Columns("Guia").Visible = False
            .Columns("TotalPiezas").Visible = False
            .Columns("Responsable").Visible = False
            .Columns("IdTraspaso").Visible = False

        End With

    End Sub

#End Region

End Class
