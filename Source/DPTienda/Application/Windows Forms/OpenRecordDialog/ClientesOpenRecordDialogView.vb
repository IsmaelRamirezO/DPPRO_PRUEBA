Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports Janus.Windows.GridEX

Public Class ClientesOpenRecordDialogView

    Implements IOpenRecordDialogViewClientes

   

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogViewClientes.AllowFilterBy
        Get
            Return True
        End Get
    End Property



    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogViewClientes.AllowGroupBy
        Get
            Return True
        End Get
    End Property



    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX, Optional ByVal strSelCriterio As String = "", Optional ByVal strCriterio As String = "", Optional ByVal GrupoDeCuentas As String = "D018") Implements IOpenRecordDialogViewClientes.SetupDataBinding

        Dim dsDataSource As DataSet


        Dim oClientesMgr As New ClientesManager(oAppContext)


        'dsDataSource = oClientesMgr.GetAll(False)

        dsDataSource = oClientesMgr.GetAll(strSelCriterio, strCriterio, GrupoDeCuentas)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "Clientes")
            .RetrieveStructure()
        End With

        oClientesMgr = Nothing

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogViewClientes.SetupView

        With TargetGridEx.Tables("Clientes")

            Dim intCol As Integer

            'For intCol = 0 To .Columns.Count - 1
            '    .Columns(intCol).Visible = False
            'Next

            '.Columns("ClienteID").Caption = "Código"
            '.Columns("ClienteID").Width = 50
            '.Columns("ClienteID").HeaderAlignment = TextAlignment.Center
            '.Columns("ClienteID").Visible = True

            '.Columns("Nombre").Caption = "Nombre"
            '.Columns("Nombre").Width = 120
            '.Columns("Nombre").HeaderAlignment = TextAlignment.Center
            '.Columns("Nombre").Visible = True

            '.Columns("ApellidoPaterno").Caption = "Apellido Paterno"
            '.Columns("ApellidoPaterno").Width = 110
            '.Columns("ApellidoPaterno").HeaderAlignment = TextAlignment.Center
            '.Columns("ApellidoPaterno").Visible = True

            '.Columns("ApellidoMaterno").Caption = "Apellido Materno"
            '.Columns("ApellidoMaterno").Width = 110
            '.Columns("ApellidoMaterno").HeaderAlignment = TextAlignment.Center
            '.Columns("ApellidoMaterno").Visible = True

            '.Columns("StatusRegistro").Caption = "Activo"
            '.Columns("StatusRegistro").Width = 50
            '.Columns("StatusRegistro").HeaderAlignment = TextAlignment.Center
            '.Columns("StatusRegistro").Visible = True

            '.Columns("Domicilio").Caption = "Domicilio"
            '.Columns("Domicilio").Width = 120
            '.Columns("Domicilio").HeaderAlignment = TextAlignment.Center
            '.Columns("Domicilio").Visible = False

            '.Columns("Ciudad").Caption = "Ciudad"
            '.Columns("Ciudad").Width = 50
            '.Columns("Ciudad").HeaderAlignment = TextAlignment.Center
            '.Columns("Ciudad").Visible = False

            '.Columns("CedulaFiscal").Caption = "Cedula Fiscal"
            '.Columns("CedulaFiscal").Width = 50
            '.Columns("CedulaFiscal").HeaderAlignment = TextAlignment.Center
            '.Columns("CedulaFiscal").Visible = False


            '.Columns("Telefono").Caption = "Telefono"
            '.Columns("Telefono").Width = 20
            '.Columns("Telefono").HeaderAlignment = TextAlignment.Center
            '.Columns("Telefono").Visible = False

            '.Columns("CodPlaza").Caption = "CodPlaza"
            '.Columns("CodPlaza").Width = 50
            '.Columns("CodPlaza").HeaderAlignment = TextAlignment.Center
            '.Columns("CodPlaza").Visible = True

        End With

    End Sub

End Class
