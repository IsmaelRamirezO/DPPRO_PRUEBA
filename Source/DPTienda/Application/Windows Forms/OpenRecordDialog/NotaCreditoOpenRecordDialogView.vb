
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports Janus.Windows.GridEX


Public Class NotaCreditoOpenRecordDialogView
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
        Dim oNotasCreditoMgr As New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        dsDataSource = oNotasCreditoMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "NotasCredito")
            .RetrieveStructure()

        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("NotasCredito")

            .Columns("FolioNotaCredito").Caption = "Folio"
            .Columns("FolioNotaCredito").Visible = True
            .Columns("FolioNotaCredito").Width = 50

            .Columns("CodCaja").Caption = "No. Caja"
            .Columns("CodCaja").Visible = True
            .Columns("CodCaja").Width = 50

            .Columns("CodTipoDevolucion").Caption = "T. Devolución"
            .Columns("CodTipoDevolucion").Visible = True
            .Columns("CodTipoDevolucion").Width = 50

            .Columns("ClienteID").Caption = "Cliente"
            .Columns("ClienteID").Visible = True
            .Columns("ClienteID").Width = 50

            .Columns("Aplicada").Caption = "Aplicada"
            .Columns("Aplicada").Visible = True
            .Columns("Aplicada").Width = 50

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").Width = 100
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

            .Columns("NotaCreditoID").Visible = False

            .Columns("FolioApartado").Visible = False

            .Columns("Importe").Visible = False

            .Columns("IVA").Visible = False

            .Columns("DevDinero").Visible = False

            .Columns("Observaciones").Visible = False

            .Columns("Usuario").Visible = False

            .Columns("Fecha").Visible = False

            .Columns("StatusRegistro").Visible = False

            .Columns("SalesDocument").Position = 4
            .Columns("SalesDocument").Caption = "Folio SAP"

        End With

    End Sub

#End Region

End Class
