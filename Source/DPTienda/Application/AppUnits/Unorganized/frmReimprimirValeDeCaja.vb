Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class frmReimprimirValeDeCaja
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReimprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents nebFolioSAPNC As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebFolioSAPNC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnReimprimir = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.nebFolioSAPNC)
        Me.explorerBar1.Controls.Add(Me.btnReimprimir)
        Me.explorerBar1.Controls.Add(Me.Label1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(250, 88)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebFolioSAPNC
        '
        Me.nebFolioSAPNC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolioSAPNC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolioSAPNC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebFolioSAPNC.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebFolioSAPNC.Location = New System.Drawing.Point(104, 16)
        Me.nebFolioSAPNC.Name = "nebFolioSAPNC"
        Me.nebFolioSAPNC.Size = New System.Drawing.Size(136, 23)
        Me.nebFolioSAPNC.TabIndex = 15
        Me.nebFolioSAPNC.Text = "0"
        Me.nebFolioSAPNC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebFolioSAPNC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.nebFolioSAPNC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.Location = New System.Drawing.Point(8, 48)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(232, 32)
        Me.btnReimprimir.TabIndex = 14
        Me.btnReimprimir.Text = "Reimprimir Vale Caja"
        Me.btnReimprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Folio SAP N.C."
        '
        'frmReimprimirValeDeCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(250, 88)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReimprimirValeDeCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reimprimir Vale De Caja"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oNC As NotaCredito
    Dim oNCMgr As NotasCreditoManager
    Dim oVC As ValeCaja
    Dim oVCMgr As ValeCajaManager
    Dim oFacturaMgr As FacturaManager
    Dim oDistNC As DistribucionNC
    Dim oDistNCMgr As DistribucionNCManager
    Dim oCliente As ClienteAlterno
    Dim oClientesMgr As ClientesManager
    Dim oArticulo As Articulo
    Dim oCatArtMgr As CatalogoArticuloManager

    Private Sub Inicializar()
        oNCMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oVCMgr = New ValeCajaManager(oAppContext)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oDistNCMgr = New DistribucionNCManager(oAppContext)
        oClientesMgr = New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oCatArtMgr = New CatalogoArticuloManager(oAppContext)
    End Sub

    Private Function ValidaFolioNC() As Boolean

        Dim bRes As Boolean = True

        If Me.nebFolioSAPNC.Value <= 0 Then
            MessageBox.Show("Es necesario indicar el Folio SAP de la Nota de Crédito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        Else
            oNC = oNCMgr.Load(CStr(Me.nebFolioSAPNC.Value))
            If oNC Is Nothing Then
                MessageBox.Show("El Folio SAP de la Nota de Crédito indicado no está registrado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bRes = False
            End If
        End If

        Return bRes

    End Function

    Private Sub ReimprimeValeCaja()

        Me.btnReimprimir.Enabled = False

        Try
            If ValidaFolioNC() Then

                oVC = oVCMgr.GetByFolioDocumento(oNC.SALESDOCUMENT.Trim)
                If Not oVC Is Nothing AndAlso oVC.StastusRegistro = True AndAlso oVC.MontoUtilizado = 0 Then
                    'Si el vale de caja existe y esta activo lo reimprimimos
                    Dim oFrmVC As New FrmValeCaja
                    oDistNC = oDistNCMgr.LoadAnticipoCliente(oNC.NotaCreditoFolio, oNC.CajaID, "NC")
                    oVC.DistribucionDetalle = oDistNC.Detalle
                    oVC.DocumentoImporte = oNC.Importe
                    oFrmVC.oValeCaja = oVC
                    oFrmVC.NotaCredito = oNC
                    oFrmVC.Sm_ActionPrintValeCajaNotaCredito(oVC)
                Else
                    'Si no existe lo generamos e imprimimos el vale de caja
                    Dim oFrmNC As New frmModCapNotCredito
                    Dim oFactura As Factura = oFacturaMgr.Create
                    Dim oRow As DataRow

                    oFacturaMgr.LoadInto(oNC.FolioSAP, oFactura)
                    oCliente = oClientesMgr.CreateAlterno
                    oClientesMgr.Load(oNC.ClienteID, oCliente, oNC.TipoVentaID)

                    oFrmNC.Sm_Inicializar()
                    'Agregamos el detalle de la NC
                    For Each oRow In oNC.Detalle.Tables(0).Rows
                        oArticulo = oCatArtMgr.Load(CStr(oRow!CodArticulo))
                        oNCMgr.AgregarArticulo(oNC.ID, oArticulo, CStr(oRow!Numero), oRow!Cantidad, oFactura, oFrmNC.strTablaTmp)
                    Next
                    oFrmNC.oCliente = oCliente
                    oFrmNC.oNotaCredito = oNC
                    oFrmNC.GenerarValeDeCaja(oFactura, False, True)
                    oNCMgr.EliminarTablaTmp(oFrmNC.strTablaTmp)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al reimprimir el Vale de Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Error al reimprimir el vale de caja para la NC " & Me.nebFolioSAPNC.Text)
        Finally
            Me.btnReimprimir.Enabled = True
        End Try

    End Sub

    Private Sub btnReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReimprimir.Click

        ReimprimeValeCaja()

    End Sub

End Class
