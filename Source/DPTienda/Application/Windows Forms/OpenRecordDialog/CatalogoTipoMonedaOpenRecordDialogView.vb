
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoMonedaAU
Imports Janus.Windows.GridEX


Public Class CatalogoTipoMonedaOpenRecordDialogView
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
        Dim oCatalogoTipoMonedaMgr As New CatalogoTipoMonedaManager(oAppContext)

        dsDataSource = oCatalogoTipoMonedaMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoTipoMoneda")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoTipoMoneda")

            .Columns("CodMoneda").Caption = "Código"

            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

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

#End Region

End Class
