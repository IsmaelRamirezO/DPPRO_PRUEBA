
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports Janus.Windows.GridEX


Public Class AbonosApartadosOpenRecordDialogView
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
        Dim oAbonosApartadosMgr As New AbonosApartadosManager(oAppContext)

        dsDataSource = oAbonosApartadosMgr.GetAll(False)
        With TargetGridEx

            .SetDataBinding(dsDataSource, "AbonosApartados")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("AbonosApartados")

            .Columns("AbonoApartadoID").Visible = False

            .Columns("CodAlmacen").Caption = "Código de Almacen"
            .Columns("CodAlmacen").Visible = False

            .Columns("CodCaja").Caption = "Código Caja"
            .Columns("CodCaja").Visible = False

            .Columns("ApartadoID").Caption = "ID de Apartado"
            .Columns("ApartadoID").Visible = False


            .Columns("FolioAbono").Caption = "Folio Abono"
            .Columns("FolioAbono").Visible = True

            .Columns("ClienteID").Caption = "ID de Cliente"
            .Columns("ClienteID").Visible = False

            .Columns("CodVendedor").Caption = "Código de Vendedor"
            .Columns("CodVendedor").Visible = False

            .Columns("CodFormaPago").Caption = "Código Forma de Pago"
            .Columns("CodFormaPago").Visible = False

            .Columns("CodTipoTarjeta").Caption = "Código Tipo de Tarjeta"
            .Columns("CodTipoTarjeta").Visible = False

            .Columns("CodBanco").Caption = "Código Banco"
            .Columns("CodBanco").Visible = False

            .Columns("NumeroTarjeta").Caption = "Número de Tarjeta"
            .Columns("NumeroTarjeta").Visible = False

            .Columns("NumeroAutorizacion").Caption = "Número de Autorizacion"
            .Columns("NumeroAutorizacion").Visible = False

            .Columns("ComisionBancaria").Caption = "Comision Bancaria"
            .Columns("ComisionBancaria").Visible = False

            .Columns("IngresoComision").Caption = "Ingreso Comision"
            .Columns("IngresoComision").Visible = False

            .Columns("IVAComision").Caption = "IVA Comision"
            .Columns("IVAComision").Visible = False

            .Columns("Abono").Caption = "Monto de Abono"
            .Columns("Abono").Visible = True


            .Columns("SaldoActual").Caption = "Saldo Actual"
            .Columns("SaldoActual").Visible = True

            .Columns("SaldoNuevo").Caption = "Saldo Nuevo"
            .Columns("SaldoNuevo").Visible = False

            .Columns("Usuario").Caption = "Creado Por"
            .Columns("Usuario").Visible = False

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"
            .Columns("Fecha").Visible = False

            With .Columns("StatusRegistro")
                .Caption = "Habilitado"

                'Cambiar TRUE y FALSE al agrupar por SI y NO
                .HasValueList = True
                .ValueList.Add(New GridEXValueListItem(True, "Si"))
                .ValueList.Add(New GridEXValueListItem(False, "No"))
            End With

            '.PreviewRowMember = "Descripcion"
            '.PreviewRow = True

        End With

    End Sub

#End Region

End Class
