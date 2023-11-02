
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports Janus.Windows.GridEX


Public Class ContratoOpenRecordDialogView
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
        Dim oContratoMgr As New ContratoManager(oAppContext)

        Dim dsDataSource2 As DataSet


        dsDataSource = oContratoMgr.GetAll(False)
        dsDataSource2 = dsDataSource.Clone

        Dim dtRow() As DataRow
        dtRow = dsDataSource.Tables("Apartados").Select("Saldo>0")

        For Each row As DataRow In dtRow
            dsDataSource2.Tables("Apartados").ImportRow(row)
        Next


        With TargetGridEx

            .SetDataBinding(dsDataSource2, "Apartados")
            .RetrieveStructure()

        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("Apartados")

            .Columns("ApartadoID").Caption = "ID Apartado"
            .Columns("ApartadoID").Visible = False


            .Columns("FolioApartado").Caption = "Folio"
            .Columns("FolioApartado").Visible = True

            .Columns("CodCaja").Caption = "Caja"
            .Columns("CodCaja").Visible = True


            .Columns("CodVendedor").Caption = "Player"
            .Columns("CodVendedor").Visible = True
            .Columns("CodVendedor").Width = 50

            .Columns("ClienteID").Caption = "Cliente"
            .Columns("ClienteID").Visible = True
            .Columns("ClienteID").Width = 50

            .Columns("Importe").Caption = "Importe"
            .Columns("importe").Visible = True

            .Columns("Saldo").Visible = True

            .Columns("DescuentoTotal").Visible = False

            .Columns("IVA").Visible = False

            .Columns("Entregada").Visible = False

            .Columns("ComentarioDesc").Visible = False

            .Columns("CodTipoDescuento").Caption = "Tipo Desc"
            .Columns("CodTipoDescuento").Visible = True
            .Columns("CodTipoDescuento").Width = 70

            .Columns("Usuario").Visible = False

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"
            .Columns("Fecha").Visible = False

            With .Columns("StatusRegistro")
                .Caption = "Habilitado"

                'Cambiar TRUE y FALSE al agrupar por SI y NO
                .HasValueList = True
                .ValueList.Add(New GridEXValueListItem(True, "Si"))
                .ValueList.Add(New GridEXValueListItem(False, "No"))

                .Width = 70
            End With

            .Columns("Referencia").Width = 140

        End With

    End Sub

#End Region

End Class
