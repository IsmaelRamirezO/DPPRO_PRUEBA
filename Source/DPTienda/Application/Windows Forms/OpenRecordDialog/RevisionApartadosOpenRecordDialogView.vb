Imports DportenisPro.DPTienda.ApplicationUnits.RevisionApartadosAU
Public Class RevisionApartadosOpenRecordDialogView
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataSet
        Dim oRevisionApartadosMgr As New RevisionApartadosManager(oAppContext)


        dsDataSource = oRevisionApartadosMgr.GetAll(False)

        Dim dsFiltrado As New DataSet
        dsFiltrado = dsDataSource.Clone

        For Each row As DataRow In dsDataSource.Tables("RevisionApartados").Rows

            Dim custDV As DataView = New DataView(dsFiltrado.Tables("RevisionApartados"), _
                                                                             "FolioMovimiento = " & row("FolioMovimiento") & "", _
                                                                             "FolioMovimiento", _
                                                                             DataViewRowState.CurrentRows)

            If custDV.Count <= 0 Then
                dsFiltrado.Tables("RevisionApartados").ImportRow(row)
            End If


        Next

        With TargetGridEx

            .SetDataBinding(dsFiltrado, "RevisionApartados")
            .RetrieveStructure()

        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("RevisionApartados")

            Dim intCol As Integer

            For intCol = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next

            .Columns("FolioMovimiento").Caption = "Folio"
            .Columns("FolioMovimiento").Width = 50
            .Columns("FolioMovimiento").Visible = True

            .Columns("Sucursal").Caption = "Sucursal"
            .Columns("Sucursal").Width = 100
            .Columns("Sucursal").Visible = True

            .Columns("Administrativo").Caption = "Administrativo"
            .Columns("Administrativo").Width = 100
            .Columns("Administrativo").Visible = True

            .Columns("Responsable").Caption = "Responsable"
            .Columns("Responsable").Width = 100
            .Columns("Responsable").Visible = True

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"
            .Columns("Fecha").Visible = True


        End With

    End Sub
End Class
