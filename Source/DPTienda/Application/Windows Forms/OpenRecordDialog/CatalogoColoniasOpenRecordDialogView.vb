Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoColonias
Imports Janus.Windows.GridEX

Public Class CatalogoColoniasOpenRecordDialogView
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

        Dim dsDataSource As DataSet
        Dim oCatalogoColoniasMgr As New CatalogoColoniasManager(oAppContext)

        dsDataSource = oCatalogoColoniasMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoColonias")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("CatalogoColonias")

            .Columns("CodColonia").Caption = "Código"

            .Columns("Colonia").Caption = "Descripción"
            .Columns("Colonia").Visible = True

            .Columns("CodCiudad").Caption = "Ciudad"
            .Columns("CodCiudad").Visible = True

            .Columns("Usuario").Caption = "Creado Por"
            .Columns("Usuario").Visible = False

            .Columns("Fecha").Caption = "Creado el"
            .Columns("Fecha").FormatString = "dd / MMM / yyyy"

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
End Class
