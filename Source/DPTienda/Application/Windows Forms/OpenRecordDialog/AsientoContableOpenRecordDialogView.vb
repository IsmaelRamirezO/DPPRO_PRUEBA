

Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU
Imports Janus.Windows.GridEX

Public Class AsientoContableOpenRecordDialogView
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



#Region "Private Methods"

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding

        Dim dsDataSource As DataSet
        Dim oDefinicionAsientoContableDG As New DefinicionAsientoContableDataGateway(oAppContext)

        dsDataSource = oDefinicionAsientoContableDG.SelectAll   'oCatalogoCajaMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "AsientoContable")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("AsientoContable")

            .Columns("CodAsiento").Caption = "Código"
            .Columns("CodAsiento").Visible = True

            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

            .Columns("Frecuencia").Caption = "Frecuencia"
            .Columns("Frecuencia").Visible = True

            .Columns("Fecha").Caption = "Fecha"
            .Columns("Fecha").Visible = True

            .Columns("NumPoliza").Caption = "Num. Poliza"
            .Columns("NumPoliza").Visible = True

            .Columns("Tipo").Caption = "Tipo"
            .Columns("Tipo").Visible = True

            .Columns("Concepto").Caption = "Concepto"
            .Columns("Concepto").Visible = True

        End With

    End Sub

#End Region

End Class
