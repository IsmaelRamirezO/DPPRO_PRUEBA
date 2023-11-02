Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class CreditoDirectoEnTiendaOpenRecordDialogView
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

        'Dim dsDataSource As DataSet
        'Dim oAbonoCreditoDirectoEnTiendaMgr As New AbonoCreditoDirectoManager(oAppContext)

        'dsDataSource = oAbonoCreditoDirectoEnTiendaMgr.SelectCreditoDirectoAll(False)

        Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        'Se manda vacio para que muestre todos los deudores
        Dim dt As DataTable = oSap.Read_ZBAPI_EXTFACTABONOS("")

        If dt Is Nothing Then
            Throw New ApplicationException("No regresó datos la BAPI ZBAPI_EXTFACTABONOS")
        End If

        With TargetGridEx
            .DataSource = dt
            '.SetDataBinding(dsDataSource, "Creditos")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables(0)

            .Columns("Nombre").Caption = "Nombre"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").Width = "351"

            .Columns("ClienteID").Caption = "Cliente ID"
            .Columns("ClienteID").Visible = True

        End With
    End Sub
End Class
