Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports Janus.Windows.GridEX

Public Class FacturasDelDia
    Implements IOpenRecordDialogView

    Private m_datFechaCierre As Date

    Private m_strAlmacen As String

    Private m_strNoCaja As String


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
        Dim oFacturasMgr As CancelaFacturaManager

        oFacturasMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        dsDataSource = oFacturasMgr.FacturasDelDia(NoCaja, Almacen, FechaCierre)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "Facturas")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Facturas")

            For Each oColumna As GridEXColumn In TargetGridEx.Tables("Facturas").Columns
                oColumna.Visible = False
            Next
            .Columns("FacturaID").Width = 60
            .Columns("FacturaID").HeaderAlignment = TextAlignment.Center

            .Columns("Referencia").Width = 150
            .Columns("Referencia").HeaderAlignment = TextAlignment.Center
            .Columns("Referencia").TextAlignment = TextAlignment.Center
            .Columns("Referencia").Visible = True
            .Columns("Referencia").Position = 1

            .Columns("FolioSAP").Width = 100
            .Columns("FolioSAP").HeaderAlignment = TextAlignment.Center
            .Columns("FolioSAP").TextAlignment = TextAlignment.Center
            .Columns("FolioSAP").Visible = True
            .Columns("FolioSAP").Position = 2

            .Columns("FolioFactura").Width = 70
            .Columns("FolioFactura").HeaderAlignment = TextAlignment.Center
            .Columns("FolioFactura").TextAlignment = TextAlignment.Center
            .Columns("FolioFactura").Visible = True
            .Columns("FolioFactura").Position = 3

            .Columns("CodVendedor").Width = 110
            .Columns("CodVendedor").HeaderAlignment = TextAlignment.Center
            .Columns("CodVendedor").Visible = True
            .Columns("CodVendedor").Position = 4

            .Columns("Fecha").Width = 80
            .Columns("Fecha").HeaderAlignment = TextAlignment.Center
            .Columns("Fecha").TextAlignment = TextAlignment.Center
            .Columns("Fecha").Visible = True
            .Columns("Fecha").Position = 5

            .Columns("CodCaja").Width = 45
            .Columns("CodCaja").HeaderAlignment = TextAlignment.Center
            .Columns("CodCaja").TextAlignment = TextAlignment.Center
            .Columns("CodCaja").Visible = True
            .Columns("CodCaja").Position = 6

            .Columns("StatusRegistro").Width = 65
            .Columns("StatusRegistro").HeaderAlignment = TextAlignment.Center
            .Columns("StatusRegistro").Caption = "Habilitado"
            .Columns("StatusRegistro").Visible = True
            .Columns("StatusRegistro").Position = 7

        End With
    End Sub

#Region "Propiedades"
    Public Property NoCaja() As String
        Get
            Return m_strNoCaja
        End Get
        Set(ByVal Value As String)
            m_strNoCaja = Value
        End Set
    End Property

    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

    Public Property FechaCierre() As Date
        Get
            Return m_datFechaCierre
        End Get
        Set(ByVal Value As Date)
            m_datFechaCierre = Value
        End Set
    End Property

#End Region
    
End Class
