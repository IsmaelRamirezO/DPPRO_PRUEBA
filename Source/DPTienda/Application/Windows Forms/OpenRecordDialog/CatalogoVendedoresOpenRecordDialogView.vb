

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports Janus.Windows.GridEX


Public Class CatalogoVendedoresOpenRecordDialogView
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
        Dim oCatalogoVendedoresMgr As New CatalogoVendedoresManager(oAppContext)

        dsDataSource = oCatalogoVendedoresMgr.GetAll(True)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoVendedores")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoVendedores")

            .Columns("CodVendedor").Caption = "Código"
            .Columns("CodVendedor").Width = 70

            .Columns("Clave").Visible = False

            .Columns("Nombre").Caption = "Nombre"
            .Columns("Nombre").Visible = True
            .Columns("Nombre").Width = 320

        End With

    End Sub

#End Region

End Class
