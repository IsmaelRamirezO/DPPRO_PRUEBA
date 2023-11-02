Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class CatalogoAlmacenesOpenRecordDialogView
    Implements IOpenRecordDialogView

    'Private dsDataSource As DataSet

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoAlmacenes")

            .Columns(0).Caption = "Código"

            .Columns("Descripcion").Caption = "Descripción"

            'Ramiro Alcaraz
            '.Columns("CodPlaza").Caption = "Plaza"
            '.Columns("CodPlaza").HasValueList = True
            '.Columns("CodPlaza").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem("MZT", "Mazatlán"))

            '.Columns("Tienda").Caption = "Es Tienda"
            '.Columns("Tienda").HasValueList = True
            '.Columns("Tienda").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(True, "Si"))
            '.Columns("Tienda").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(False, "No"))
            '.Columns("Tienda").Visible = False

            .Columns("MostrarSeparaciones").Caption = "Mostrar en Separación"
            .Columns("MostrarSeparaciones").Visible = False

            .Columns("Calle").Visible = False
            .Columns("NumExterior").Visible = False

            '.Columns("NumInterior").Visible = False
            '.Columns("Colonia").Visible = False

            .Columns("CP").Visible = False
            .Columns("Ciudad").Visible = False
            .Columns("Estado").Visible = False

            '.Columns("Lada").Visible = False
            .Columns("Telefono").Visible = False

            '.Columns("Usuario").Visible = False

            '.Columns("Fecha").FormatString = "dd / MMM / yyyy"
            '.Columns("Fecha").Visible = False

            '.Columns("StatusRegistro").Caption = "Habilitado"
            '.Columns("StatusRegistro").HasValueList = True
            '.Columns("StatusRegistro").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(Boolean.TrueString, "Si"))
            '.Columns("StatusRegistro").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(Boolean.FalseString, "No"))


        End With

    End Sub

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataSet
        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)

        dsDataSource = oCatalogoAlmacenesMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoAlmacenes")
            .RetrieveStructure()
        End With

    End Sub

End Class
