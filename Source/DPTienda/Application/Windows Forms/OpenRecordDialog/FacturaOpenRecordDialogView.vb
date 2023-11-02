
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports Janus.Windows.GridEX

Public Class FacturaOpenRecordDialogView
    Implements IOpenRecordDialogView

    Private m_strTipoVenta As String = String.Empty


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
        Dim oDefectuosoMgr As DefectuososManager

        oDefectuosoMgr = New DefectuososManager(oAppContext)

        dsDataSource = oDefectuosoMgr.ListFactura(False, Me.TipoVenta.Trim)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "Facturas")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Facturas")

            .Columns("ID").Width = 60
            .Columns("ID").HeaderAlignment = TextAlignment.Center
            .Columns("ID").Visible = False

            .Columns("Caja").Width = 45
            .Columns("Caja").HeaderAlignment = TextAlignment.Center
            .Columns("Caja").TextAlignment = TextAlignment.Center
            .Columns("Caja").Position = 1

            .Columns("Folio").Width = 70
            .Columns("Folio").HeaderAlignment = TextAlignment.Center
            .Columns("Folio").TextAlignment = TextAlignment.Center
            .Columns("Folio").Position = 2

            .Columns("Referencia").Width = 150
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").TextAlignment = TextAlignment.Center
            .Columns("Referencia").Position = 3

            .Columns("FolioSAP").Width = 100
            .Columns("FolioSAP").HeaderAlignment = TextAlignment.Center
            .Columns("FolioSAP").TextAlignment = TextAlignment.Center
            .Columns("FolioSAP").Position = 4

            .Columns("Vendedor").Width = 110
            .Columns("Vendedor").HeaderAlignment = TextAlignment.Center
            .Columns("Vendedor").Position = 5

            .Columns("Fecha").Width = 80
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Position = 6

            .Columns("Habilitado").Width = 65
            .Columns("Habilitado").HeaderAlignment = TextAlignment.Center
            .Columns("Habilitado").Position = 7


        End With
    End Sub

    Public Property TipoVenta() As String
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strTipoVenta = Value
        End Set
    End Property

End Class
