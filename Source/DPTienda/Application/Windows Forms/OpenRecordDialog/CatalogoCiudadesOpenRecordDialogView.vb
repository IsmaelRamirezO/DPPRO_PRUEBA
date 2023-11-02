Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCiudades
Imports Janus.Windows.GridEX

Public Class CatalogoCiudadesOpenRecordDialogView
    Implements IOpenRecordDialogView

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

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsData As DataSet
        Dim oCatalogoCiudadesMgr As New CatalogoCiudadesManager(oAppContext)

        dsData = oCatalogoCiudadesMgr.GetAll(False)

        TargetGridEx.SetDataBinding(dsData, "CatalogoCiudades")
        TargetGridEx.RetrieveStructure()
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoCiudades")
            .Columns("CodCiudad").Caption = "Código"
            .Columns("Ciudad").Caption = "Ciudad"
            .Columns("CodEstado").Caption = "Estado"
            .Columns("CodPlaza").Caption = "Plaza"
            .Columns("Usuario").Visible = False
            .Columns("Rango1").Visible = True
            .Columns("Rango2").Visible = True
            .Columns("Rango3").Visible = False
            .Columns("Rango4").Visible = False
            .Columns("Fecha").Visible = False
            With .Columns("StatusRegistro")
                .Caption = "Habilitado"

                'Cambiar TRUE y FALSE al agrupar por SI y NO
                .HasValueList = True
                .ValueList.Add(New GridEXValueListItem(True, "Si"))
                .ValueList.Add(New GridEXValueListItem(False, "No"))
            End With
        End With
    End Sub
End Class
