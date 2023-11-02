Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports Janus.Windows.GridEX

Public Class FacturaCorridaOpenRecordDialogView

    Implements IOpenRecordDialogView

    Private FolioFactura As Integer
    Private CodCaja As String

    Public Sub New(ByVal intFolio As Integer, ByVal strCodCaja As String)

        FolioFactura = intFolio
        CodCaja = strCodCaja

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

        Dim oFCorridaMgr As New FacturaCorridaManager(oAppContext)

        dsDataSource = oFCorridaMgr.LoadDetalle(FolioFactura, CodCaja)

        With TargetGridEx

            .SetDataBinding(dsDataSource, "FacturaDetalle")
            .RetrieveStructure()

        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("FacturaDetalle")

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(3).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False

            '-----------------------------------------------------------------------------------
            ' JNAVA (07.03.2016): Ocultamos la columna de numero (el wilfrido lo pidio)
            '-----------------------------------------------------------------------------------
            .Columns("Numero").Visible = False
            '-----------------------------------------------------------------------------------

            .Columns(2).Caption = "Código"
            .Columns(2).Width = 150
            .Columns(2).HeaderAlignment = TextAlignment.Center
            .Columns(2).Position = 1
            .Columns(19).Visible = True
            .Columns(19).Position = 2
            '.Columns(4).Caption = "Talla"
            '.Columns(4).Width = 60
            '.Columns(4).FormatMode = FormatMode.UseIFormattable
            '.Columns(4).FormatString = "n"
            '.Columns(4).HeaderAlignment = TextAlignment.Center
            .Columns(18).Caption = "Descripción"
            .Columns(18).Width = 270
            .Columns(18).HeaderAlignment = TextAlignment.Center
            .Columns(18).Position = 3
            
        End With

    End Sub

End Class
