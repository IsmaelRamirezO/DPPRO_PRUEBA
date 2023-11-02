
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports Janus.Windows.GridEX


Public Class CatalogoFormasPagoOpenRecordDialogView
    Implements IOpenRecordDialogView

    Dim strTipoVentaID As String


    'Public WriteOnly Property TipoVenta() As String
    '    Set(ByVal Valor As String)
    '        m_strTipoVenta = Valor
    '    End Set
    'End Property


    Public Sub New(ByVal TipoVentaID As String)

        strTipoVentaID = TipoVentaID

    End Sub







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
        Dim oCatalogoFormasPagoMgr As New CatalogoFormasPagoManager(oAppContext)

        dsDataSource = oCatalogoFormasPagoMgr.GetAll(strTipoVentaID)

        'dsDataSource = oCatalogoFormasPagoMgr.GetAll(False)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "CatalogoFormasPago")
            .RetrieveStructure()
        End With

    End Sub



    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CatalogoFormasPago")

            .Columns("CodFormasPago").Caption = "Código"

            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Visible = True

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

End Class
