
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja


Public Class ValeCajaOpenRecordDialogView
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
        Dim oValeCajaMgr As New ValeCajaManager(oAppContext)

        dsDataSource = oValeCajaMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "ValesCajas")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("ValesCajas")

            .Columns("ValeCajaID").Caption = "Folio"
            .Columns("ValeCajaID").Width = 50

            .Columns("TipoDocumento").Caption = "Tipo Documento"
            .Columns("TipoDocumento").Width = 50

            .Columns("FolioDocumento").Caption = "Folio Doc."
            .Columns("FolioDocumento").Width = 50

            .Columns("Nombre").Caption = "Cliente"
            .Columns("Nombre").Width = 50

            .Columns("Fecha").Caption = "Cliente"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"


            .Columns("DocumentoID").Visible = False
            .Columns("CodCliente").Visible = False
            .Columns("Importe").Visible = False
            .Columns("MontoUtilizado").Visible = False
            .Columns("ValeGenerado").Visible = False
            .Columns("DevEfectivo").Visible = False
            .Columns("Motivo").Visible = False

        End With

    End Sub

#End Region
End Class
