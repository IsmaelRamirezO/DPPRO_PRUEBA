Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas
Imports Janus.Windows.GridEX

Public Class CatalogoMarcasRecordDialogView
    Implements IOpenRecordDialogView

#Region "Propiedades"

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
        Dim oCatalogoMarcasMgr As New CatalogoMarcasManager(oAppContext)

        dsDataSource = oCatalogoMarcasMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoMarcas")
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("CatalogoMarcas")

            .Columns("CodMarca").Caption = "C�digo"

            .Columns("Descripcion").Caption = "Descripci�n"
            .Columns("Descripcion").Visible = True

            .Columns("CodOrigen").Caption = "C�digo Origen"
            .Columns("CodOrigen").Visible = False

            '.Columns("Usuario").Caption = "Creado Por"
            '.Columns("Usuario").Visible = False

            '.Columns("Fecha").Caption = "Creado el"
            '.Columns("Fecha").FormatString = "dd / MMM / yyyy"
            '.Columns("Fecha").Visible = False

            'With .Columns("StatusRegistro")
            '    .Caption = "Habilitado"

            '    'Cambiar TRUE y FALSE al agrupar por SI y NO
            '    .HasValueList = True
            '    .ValueList.Add(New GridEXValueListItem(True, "Si"))
            '    .ValueList.Add(New GridEXValueListItem(False, "No"))
            'End With

            '.PreviewRowMember = "Descripcion"
            '.PreviewRow = True

        End With
    End Sub
#End Region

    
End Class
