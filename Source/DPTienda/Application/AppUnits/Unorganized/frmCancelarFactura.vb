Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.Asociados
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.PeriodoDetalleUI
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports System.Collections.Generic

Public Class frmCancelarFactura

    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCodUser As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNomUser As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebCodCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents grpSiHay As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents CheckValeCaja As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents CheckDevEfectivo As Janus.Windows.EditControls.UICheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarFactura))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpSiHay = New Janus.Windows.EditControls.UIGroupBox()
        Me.CheckValeCaja = New Janus.Windows.EditControls.UICheckBox()
        Me.CheckDevEfectivo = New Janus.Windows.EditControls.UICheckBox()
        Me.ebFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebFolioFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebNomUser = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.ebCodUser = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grpSiHay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSiHay.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.grpSiHay)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioSAP)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ebCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar1.Controls.Add(Me.ebFolioFactura)
        Me.ExplorerBar1.Controls.Add(Me.ebNomUser)
        Me.ExplorerBar1.Controls.Add(Me.btnAceptar)
        Me.ExplorerBar1.Controls.Add(Me.ebCodUser)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Cancelacion de Venta"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(466, 275)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpSiHay
        '
        Me.grpSiHay.BackColor = System.Drawing.Color.Transparent
        Me.grpSiHay.Controls.Add(Me.CheckValeCaja)
        Me.grpSiHay.Controls.Add(Me.CheckDevEfectivo)
        Me.grpSiHay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSiHay.ForeColor = System.Drawing.Color.Brown
        Me.grpSiHay.Location = New System.Drawing.Point(272, 122)
        Me.grpSiHay.Name = "grpSiHay"
        Me.grpSiHay.Size = New System.Drawing.Size(184, 64)
        Me.grpSiHay.TabIndex = 7
        Me.grpSiHay.Text = "Pedido de Si Hay"
        Me.grpSiHay.Visible = False
        Me.grpSiHay.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'CheckValeCaja
        '
        Me.CheckValeCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckValeCaja.ForeColor = System.Drawing.Color.Black
        Me.CheckValeCaja.Location = New System.Drawing.Point(8, 16)
        Me.CheckValeCaja.Name = "CheckValeCaja"
        Me.CheckValeCaja.Size = New System.Drawing.Size(120, 24)
        Me.CheckValeCaja.TabIndex = 17
        Me.CheckValeCaja.Text = "Vale de Caja"
        Me.CheckValeCaja.Visible = False
        Me.CheckValeCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'CheckDevEfectivo
        '
        Me.CheckDevEfectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckDevEfectivo.ForeColor = System.Drawing.Color.Black
        Me.CheckDevEfectivo.Location = New System.Drawing.Point(8, 40)
        Me.CheckDevEfectivo.Name = "CheckDevEfectivo"
        Me.CheckDevEfectivo.Size = New System.Drawing.Size(176, 24)
        Me.CheckDevEfectivo.TabIndex = 16
        Me.CheckDevEfectivo.Text = "Devolución de Efectivo"
        Me.CheckDevEfectivo.Visible = False
        Me.CheckDevEfectivo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFolioSAP
        '
        Me.ebFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioSAP.ButtonImage = CType(resources.GetObject("ebFolioSAP.ButtonImage"), System.Drawing.Image)
        Me.ebFolioSAP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolioSAP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ebFolioSAP.Location = New System.Drawing.Point(144, 164)
        Me.ebFolioSAP.MaxLength = 20
        Me.ebFolioSAP.Name = "ebFolioSAP"
        Me.ebFolioSAP.Size = New System.Drawing.Size(120, 22)
        Me.ebFolioSAP.TabIndex = 4
        Me.ebFolioSAP.Text = "0"
        Me.ebFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Referencia:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 48)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Si Alguna Factura no Aparece, es por que no se Registro en SAP"
        '
        'ebCodCaja
        '
        Me.ebCodCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCodCaja.Location = New System.Drawing.Point(144, 106)
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Size = New System.Drawing.Size(88, 22)
        Me.ebCodCaja.TabIndex = 2
        Me.ebCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(16, 106)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(100, 23)
        Me.lblLabel1.TabIndex = 4
        Me.lblLabel1.Text = "No. Caja        :"
        '
        'ebFolioFactura
        '
        Me.ebFolioFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioFactura.ButtonImage = CType(resources.GetObject("ebFolioFactura.ButtonImage"), System.Drawing.Image)
        Me.ebFolioFactura.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFolioFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioFactura.Location = New System.Drawing.Point(144, 135)
        Me.ebFolioFactura.Name = "ebFolioFactura"
        Me.ebFolioFactura.Size = New System.Drawing.Size(120, 22)
        Me.ebFolioFactura.TabIndex = 3
        Me.ebFolioFactura.Text = "0"
        Me.ebFolioFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioFactura.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNomUser
        '
        Me.ebNomUser.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNomUser.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNomUser.BackColor = System.Drawing.Color.Ivory
        Me.ebNomUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNomUser.Location = New System.Drawing.Point(144, 77)
        Me.ebNomUser.MaxLength = 30
        Me.ebNomUser.Name = "ebNomUser"
        Me.ebNomUser.ReadOnly = True
        Me.ebNomUser.Size = New System.Drawing.Size(312, 22)
        Me.ebNomUser.TabIndex = 1
        Me.ebNomUser.TabStop = False
        Me.ebNomUser.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNomUser.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(280, 216)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(120, 28)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebCodUser
        '
        Me.ebCodUser.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodUser.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodUser.BackColor = System.Drawing.Color.Ivory
        Me.ebCodUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodUser.Location = New System.Drawing.Point(144, 48)
        Me.ebCodUser.Name = "ebCodUser"
        Me.ebCodUser.ReadOnly = True
        Me.ebCodUser.Size = New System.Drawing.Size(104, 22)
        Me.ebCodUser.TabIndex = 0
        Me.ebCodUser.TabStop = False
        Me.ebCodUser.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodUser.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Responsable  :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Num. Factura PRO :"
        '
        'frmCancelarFactura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(466, 275)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(472, 303)
        Me.MinimumSize = New System.Drawing.Size(472, 303)
        Me.Name = "frmCancelarFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelacion de Factura"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grpSiHay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSiHay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"

#Region "Globales"

    Dim vUserID As String
    Dim vUserName As String
    Private oDPVale As cDPVale

    Dim MontoEfectivo As Decimal = Decimal.Zero
    Dim MontoValeCaja As Decimal = Decimal.Zero
    Dim MontoDPVale As Decimal = Decimal.Zero

    Dim MontoDpvaleCancelacionSH As Decimal = Decimal.Zero
    Dim MontoValeCajaCancelacionSH As Decimal = Decimal.Zero

    Dim strDocNumEfectivo As String = ""
    Dim strDocNumValeCaja As String = ""

    Dim oSAPMgr As ProcesoSAPManager
    Dim dsFormaPago As New DataSet

    Dim oPedido As Pedidos
    Dim oPedidoDetalle As PedidoDetalles

    Dim oClientesMgr As ClientesManager
    Dim CodCliente As String = ""
    Dim ClienteNombre As String = ""

    'Tabla Temporal de Formas de Pago
    Public dsFormasPago As New DataSet

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2015: Variables DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------
    Private FormasPago() As DataRow

    Private RestService As New ProcesosRetail("", "POST")


    

#End Region

#Region "Objetos"

    'Objeto Asociados
    Dim oAsociadosMgr As AsociadosManager
    Dim oAsociado As Asociado

    'Objeto Factura
    Dim oFacturaMgr As FacturaManager
    Dim oFactura As Factura

    'Objeto Factura
    Dim oFacturaFormasPagoMgr As FacturaManager
    Dim oFacturaFormasPago As Factura

    'Objeto FacturaCorrida
    Dim oFacturaCorridaMgr As FacturaCorridaManager
    Dim oFacturaCorrida As FacturaCorrida

    'Objeto FacturaFormasPago
    Dim oFacturaFormaPago As FacturaFormaPago


    'Objeto CatalogoArticulos
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Web Service DPVale
    'Dim oWsValidaDPVale As wsControlDPVales.ControlDPVales
    'Dim oDPValeInfo As wsControlDPVales.DPValeInfo
    'Dim oDPValeFacturaInfo As wsControlDPVales.DPValeFacturaInfo

    'Web Service Abono Credito Directo
    Dim AbonoCDMgr As AbonoCreditoDirectoManager

    'Web Service Pagos Credito Directo
    'Dim oWsPagosCreditoDirecto As wsPagosCreditoDirecto.PagosCreditoDirecto
    'Dim oWsPagosCreditoDirectoInfo As wsPagosCreditoDirecto.PagosCreditoDirectoInfo

    ''Web Service Estado Cuenta Asociado
    'Dim oWsEstadoCuentaAsociado As wsEstadoCuentaAsociado.EstadodeCuentaAsociado
    'Dim oWsMovimientoInfo As wsEstadoCuentaAsociado.MovimientosInfo

    'Objeto Cierre de Dia
    Dim oCierrediaMgr As CierreDiaManager

    'Variables para getBalance
    Dim CustomerName As String = String.Empty
    Dim SaldoPuntos As String = String.Empty


#End Region

#End Region

#Region "Metodos"

    Private Sub InicializaObjetos()

        oDPVale = New cDPVale

        'Objeto Cierre de Dia
        oCierrediaMgr = New CierreDiaManager(oAppContext)

        'Objeto Factura
        oFacturaMgr = New FacturaManager(oAppContext)
        oFactura = oFacturaMgr.Create
        oFactura.ClearFields()

        'Objeto Factura Formas Pago
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)

        'Objeto FacturaCorrida
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaCorrida = oFacturaCorridaMgr.Create
        oFacturaCorrida.Clearfields()

        'Objeto CatalogoArticulos
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create
        oArticulo.ClearFields()

        oFacturaFormaPago = New FacturaFormaPago(oAppContext)

        'Web Service DPVale
        'oWsValidaDPVale = New wsControlDPVales.ControlDPVales

        If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
            '    oWsValidaDPVale.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            '              oWsValidaDPVale.strURL.TrimStart("/")
        End If

        'oDPValeInfo = New wsControlDPVales.DPValeInfo
        'oDPValeFacturaInfo = New wsControlDPVales.DPValeFacturaInfo

        'Asociado
        oAsociadosMgr = New AsociadosManager(oAppContext)
        oAsociado = oAsociadosMgr.Create

        'Abonos Credito Directo
        AbonoCDMgr = New AbonoCreditoDirectoManager(oAppContext)
        'Cliente
        oClientesMgr = New ClientesManager(oAppContext)

        'SAP Manager

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    End Sub

    Private Sub FillCaja()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        oCajaMgr = New CatalogoCajaManager(oAppContext)

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(True)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1

                ebCodCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

            ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja

        End If

        oCajaMgr.Dispose()
        oCajaMgr = Nothing

    End Sub

    Private Function CancelaFactura() As Boolean
        Try
            Dim resultado As Boolean = True
            Dim strFIDOCUMENT, strSALESDOCUMENT As String, strMsg As String = ""
            strFIDOCUMENT = ""
            strSALESDOCUMENT = ""
            Dim oCancelaFacturaMgr As CancelaFacturaManager
            oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            Dim canc As New Dictionary(Of String, Object)
            Dim result As New Dictionary(Of String, Object)
            Dim strError As String = ""
            Dim total As Decimal = oFactura.Detalle.Tables(0).Compute("SUM(Total)", "1=1")
            Dim totalIva As Decimal = (total * oAppContext.ApplicationConfiguration.IVA) + total
            Dim MontoDpvaleCancelacion As Decimal = 0
            Dim MontoValeCajaCancelacion As Decimal = 0
            If oFactura.CodTipoVenta = "V" Then

                '------------------------------------------------------------------------------
                'JNAVA (10.11.2014): Validamos para cuando es factura con dpvale del Si Hay
                '------------------------------------------------------------------------------

                Dim strDpValeIDDP As String
                If oFactura.Referencia.Contains("DPVLT") = False Then
                    If Not oPedido Is Nothing Then
                        strDpValeIDDP = oFacturaMgr.GetDPVALEID(0, oPedido.PedidoID)
                    Else
                        strDpValeIDDP = CStr(oCierrediaMgr.GetDpValeID(oFactura.FacturaID))
                    End If
                Else
                    strDpValeIDDP = oFactura.Referencia.Split("-")(1)
                End If
                
                '------------------------------------------------------------------------------

                'Dim strDpValeIDDP As Integer = CStr(oCierrediaMgr.GetDpValeID(oFactura.FolioFactura))
                Me.oDPVale.INUMVA = CStr(strDpValeIDDP)
                Me.oDPVale.I_RUTA = "X"
                '----------------------------------------------------------------------------------------
                ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
                '----------------------------------------------------------------------------------------
                Dim oS2Credit As New ProcesosS2Credit
                'oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

                '----------------------------------------------------------------------------------------
                ' JNAVA (18.07.2016): Valida DPVale
                '----------------------------------------------------------------------------------------
                Dim FirmaDistribuidor As Image = Nothing
                Dim NombreDistribuidor As String = String.Empty
                If oConfigCierreFI.AplicarS2Credit Then
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
                Else
                    oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                End If
                '----------------------------------------------------------------------------------------

                oFactura.ClienteId = CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadRight(10, " ")

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)

                '----------------------------------------------------------------------------------------------
                ' JNAVA (07.11.2014): Validamos si es factura del si hay
                '----------------------------------------------------------------------------------------------
                If existe.Trim().ToUpper() = "N" Then
                    'RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioFISAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If

                    'result = RestService.SapZbapisd29Cancelacion(referencia, oFactura.CodVendedor, foliosh)
                    'strSALESDOCUMENT = CStr(result("SALESDOCUMENT"))
                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.Referencia, oFactura.CodVendedor, oFactura.CodAlmacen, True, strFIDOCUMENT, strSALESDOCUMENT, foliosh)
                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------

                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then

                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strError)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strError)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strSALESDOCUMENT = oSAPMgr.ZBAPISD29_CANCELACION_DPVL_AUT(referencia, oFactura.CodVendedor, foliosh, strError)
                        If oFactura.Referencia.Contains("DPVLT") = False Then
                            MontoDpvaleCancelacion = Me.dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago='DPVL'")
                        End If
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT <> "" Then
                        '------------------------------------------------------------------------------------------------------------
                        ' JNAVA (06.09.2016): Si esta activo S2Credit, hace la- devolucion en su servicio, si no hace lo que hacia antes
                        '------------------------------------------------------------------------------------------------------------
                        If oConfigCierreFI.AplicarS2Credit Then
                            If oFactura.Referencia.Contains("DPVLT") = False Then
                                'Dim totalF As Decimal = Me.dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago='DPVL'")
                                Dim MensajeDev As String = oS2Credit.GeneraDevolucion(strDpValeIDDP, CStr(oDPVale.InfoDPVALE.Rows(0).Item("KUNNR")).PadLeft(10, "0"), MontoDpvaleCancelacion)

                                If MensajeDev <> String.Empty Then
                                    MessageBox.Show("Ocurrio un error al grabar la devolución del DPVale en S2Credit: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & vbCrLf & ". Favor de comunicarse a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            End If
                        Else
                            If oFactura.PedidoID = 0 Then
                                oSAPMgr.ZBAPISD29_CANCELACION_DPVL_AUTAFS(referencia, oFactura.CodVendedor, foliosh, strSALESDOCUMENT)
                            Else
                                Dim params As New Dictionary(Of String, Object)
                                params("Almacen") = oFactura.CodAlmacen
                                params("Kunnr") = oFactura.ClienteId
                                params("CodVendedor") = oAppContext.Security.CurrentUser.ID
                                params("Fecha") = DateTime.Now
                                params("Referencia") = oFactura.Referencia
                                params("MontoDPVL") = oFactura.Total
                                oSAPMgr.CancelacionFacturaDPValeSHAFS(params)
                            End If
                            If strMsg.Trim() <> "" Then
                                MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaDPValeRetail(oFactura.FacturaID, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT, oFactura.FolioFISAP)
            ElseIf oFactura.CodTipoVenta = "P" OrElse oFactura.CodTipoVenta = "E" Then

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)

                If existe.Trim().ToUpper() = "N" Then
                    RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioSAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If

                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.Referencia, oFactura.CodVendedor, oFactura.CodAlmacen, False, strFIDOCUMENT, strSALESDOCUMENT, foliosh)

                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------
                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strMsg = oSAPMgr.ZBAPISD29_CANCELACIONFACT_AUTO(referencia, oFactura.CodVendedor, strSALESDOCUMENT, strFIDOCUMENT)
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT.Trim = "" Then
                        EscribeLog(strMsg.Trim, "Error al cancelar la factura PG o Empleado")
                        'AFH 07.09.2016: si la factura no existe en SAP el proceso NO debe continuar
                        MessageBox.Show(strMsg, "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        resultado = False
                        Exit Function
                    Else
                        If strMsg.Trim() <> "" Then
                            MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaRetail(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)
                'oCancelaFacturaMgr.UpdateStatusFactura(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)
                '---------------------------------------------------------------------------------------------------------------------------------------
                'Revivimos el vale de empleado en la factura en caso de existir
                '---------------------------------------------------------------------------------------------------------------------------------------
                If oFactura.CodTipoVenta = "E" Then
                    'Dim res As New Dictionary(Of String, Object)
                    'RestService.Metodo = "/pos/facturacion"
                    'res = RestService.SapZRevivirvaledescto(oFactura.Referencia)
                    'If res.ContainsKey("SapZRevivirvaledescto") Then
                    '    Dim obj As Dictionary(Of String, Object) = res("SapZRevivirvaledescto")
                    '    If CStr(res("E_RESULT")).Trim() = "1" Then
                    '        MessageBox.Show("No se pudo reactivar el vale de empleado utilizado en esta factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Else

                    '    End If
                    'End If
                    'If CStr(res("SapZRevivirvaledescto")("E_RESULT")).Trim() = "1" Then

                    'Else
                    '    oCancelaFacturaMgr.ReviveValeEmpleado(oFactura.FacturaID)
                    'End If
                    If oSAPMgr.ZBAPI_REVIVE_VALE_EMPLEADO(oFactura.Referencia).Trim = "1" Then
                        MessageBox.Show("No se pudo reactivar el vale de empleado utilizado en esta factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        oCancelaFacturaMgr.ReviveValeEmpleado(oFactura.FacturaID)
                    End If
                End If



            ElseIf oFactura.CodTipoVenta = "D" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "M" OrElse oFactura.CodTipoVenta = "S" Then

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)
                If existe.Trim().ToUpper() = "N" Then
                    RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioFISAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If
                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, False, strFIDOCUMENT, strSALESDOCUMENT, foliosh)

                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------
                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strMsg = oSAPMgr.ZBAPISD29_CANCELACIONFACT_AUTO(referencia, oFactura.CodVendedor, strSALESDOCUMENT, strFIDOCUMENT)
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT.Trim = "" Then
                        EscribeLog(strMsg.Trim, "Error al cancelar la factura D, I, M o S")
                    Else
                        If strMsg.Trim() <> "" Then
                            MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaRetail(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)
                'oCancelaFacturaMgr.UpdateStatusFactura(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

            ElseIf oFactura.CodTipoVenta = "O" Then

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)
                If existe.Trim().ToUpper() = "N" Then
                    RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioFISAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If
                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, False, strFIDOCUMENT, strSALESDOCUMENT, foliosh)

                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------
                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strMsg = oSAPMgr.ZBAPISD29_CANCELACIONFACT_AUTO(referencia, oFactura.CodVendedor, strSALESDOCUMENT, strFIDOCUMENT)
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT.Trim = "" Then
                        EscribeLog(strMsg.Trim, "Error al cancelar la factura Facilito")
                    Else
                        If strMsg.Trim() <> "" Then
                            MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaRetail(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

                'oCancelaFacturaMgr.UpdateStatusFactura(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

            ElseIf oFactura.CodTipoVenta = "F" Then

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)
                If existe.Trim().ToUpper() = "N" Then
                    RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioFISAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If
                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, False, strFIDOCUMENT, strSALESDOCUMENT, foliosh)

                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------
                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strMsg = oSAPMgr.ZBAPISD29_CANCELACIONFACT_AUTO(referencia, oFactura.CodVendedor, strSALESDOCUMENT, strFIDOCUMENT)
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT.Trim = "" Then
                        EscribeLog(strMsg.Trim, "Error al cancelar la factura Fonacot")
                    Else
                        If strMsg.Trim() <> "" Then
                            MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaRetail(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

            ElseIf oFactura.CodTipoVenta = "K" Then

                Dim existe As String = oCancelaFacturaMgr.ValidaFacturaPRO(oFactura.Referencia, "", strFIDOCUMENT, strSALESDOCUMENT)
                If existe.Trim().ToUpper() = "N" Then
                    RestService = New ProcesosRetail("/pos/facturacion", "POST")
                    Dim foliosh As String = ""
                    Dim referencia As String = ""
                    If oFactura.PedidoID <> 0 Then
                        foliosh = oFactura.FolioFISAP
                        referencia = oFactura.FolioSAP
                    Else
                        referencia = oFactura.Referencia
                    End If
                    'result = RestService.SapZbapisd29Cancelacion(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, False, strFIDOCUMENT, strSALESDOCUMENT, foliosh)

                    '------------------------------------------------------------------------------------------------------------
                    ' JNAVA (24.03.2017): Validamos si es pedido de SH para cancelar  con su respectiva funcion de SAP
                    '------------------------------------------------------------------------------------------------------------
                    If oFactura.PedidoID <> 0 Then

                        If oPedido.Total <> totalIva Then
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "P", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        Else
                            strSALESDOCUMENT = oSAPMgr.ZSH_CANCELACION_VENTA(oFactura.Referencia, oFactura.FolioSAP, oFactura.Detalle.Tables(0), "C", MontoDpvaleCancelacion, MontoValeCajaCancelacion, strMsg)
                        End If
                    Else
                        '------------------------------------------------------------------------------------------------------------
                        'rgermain 02.03.2016: Llamada remota directa por RFC
                        '------------------------------------------------------------------------------------------------------------
                        strMsg = oSAPMgr.ZBAPISD29_CANCELACIONFACT_AUTO(referencia, oFactura.CodVendedor, strSALESDOCUMENT, strFIDOCUMENT)
                    End If
                    '------------------------------------------------------------------------------------------------------------

                    If strSALESDOCUMENT.Trim = "" Then
                        EscribeLog(strMsg.Trim, "Error al cancelar la factura Tarjeta Fonacot")
                    Else
                        If strMsg.Trim() <> "" Then
                            MessageBox.Show(strMsg, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
                oCancelaFacturaMgr.UpdateStatusFacturaRetail(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)

                'oCancelaFacturaMgr.UpdateStatusFactura(oFactura.FacturaID, oFactura.FolioSAP, oFactura.CodVendedor, oFactura.CodAlmacen, strFIDOCUMENT, strSALESDOCUMENT)
            End If

            Me.MontoDpvaleCancelacionSH = MontoDpvaleCancelacion
            Me.MontoValeCajaCancelacionSH = MontoValeCajaCancelacion
            'If oConfigCierreFI.UsarHuellas AndAlso strSALESDOCUMENT.Trim <> "" Then CancelaVentaPGServer(oFactura.FolioSAP, strSALESDOCUMENT, strFIDOCUMENT)

            oFacturaMgr = Nothing
            Return resultado
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub CancelaVentaPGServer(ByVal FolioSAP As String, ByVal FCFolioSAP As String, ByVal FCFolioFISAP As String)

        Dim oFingerPMgr As New FingerPrintManager(oAppContext, oConfigCierreFI)
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)

        If oFingerPMgr.CancelaClienteVenta(FolioSAP, FCFolioSAP, FCFolioFISAP) Then
            oFacturaMgr.ActualizaStatusEnvioServerPG(FCFolioSAP, 2)
        End If

        oFingerPMgr = Nothing
        oFacturaMgr = Nothing

    End Sub

    Private Sub ReviveCuponDescuento(ByVal FacturaID As Integer)

        Dim strFolioCupon As String = ""
        Dim vFacturaMgr As New FacturaManager(oAppContext)

        strFolioCupon = vFacturaMgr.GetCuponDescuento(FacturaID)
        If strFolioCupon.Trim <> "" Then
            vFacturaMgr.MarcarCuponDescuentoUsado(False, strFolioCupon, FacturaID)
            RestService.Metodo = "/pos/cupones"
            RestService.SapZCupCancelacion(strFolioCupon)
            'oSAPMgr.ZBAPI_REVIVE_CUPON(strFolioCupon)
            'ReviveCuponDescuento(strFolioCupon)
        End If

        vFacturaMgr = Nothing

    End Sub

    Private Sub ImprimirFactCancel(ByVal FacturaID As Integer, ByVal ModuloID As String, ByVal Disponible As Boolean)
        Dim oCancelaFacturaMgr As CancelaFacturaManager
        oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        Dim orptDataInfo As New rptFacturaInfo
        Dim pImprimir As cImprimirFactura
        Dim pdtGeneral As DataTable
        Dim pdtDetalles As DataTable
        Dim pdtNotas As DataTable
        Dim pdtPagos As DataTable

        pImprimir = New cImprimirFactura
        pdtGeneral = New DataTable
        pdtDetalles = New DataTable
        pdtNotas = New DataTable
        pdtPagos = New DataTable
        Dim strdpvaleinfo(3) As String
        Dim decfacilito As Decimal = 0
        Dim intdpvaleid As String = ""

        '------------------------------------------------------------------------------
        'JNAVA (10.11.2014): Validamos para cuando es factura con dpvale del Si Hay
        '------------------------------------------------------------------------------
        oFacturaMgr = New FacturaManager(oAppContext)
        If oFactura.Referencia.Contains("DPVLT") = False Then
            If oFactura.PedidoID <> 0 Then
                intdpvaleid = oFacturaMgr.GetDPVALEID(0, oFactura.PedidoID)
            Else
                intdpvaleid = oCancelaFacturaMgr.FacturaDPvaleIdSel(oFactura.FacturaID)
            End If
        Else
            intdpvaleid = oFactura.Referencia.Split("-")(1)
        End If
        
        oFacturaMgr = Nothing
        '------------------------------------------------------------------------------

        '----------------------------------------------------------------------------------------
        ' JNAVA (18.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
        '----------------------------------------------------------------------------------------
        Dim oS2Credit As New ProcesosS2Credit
        Dim NombreDistribuidor As String = String.Empty

        If oAppSAPConfig.DPValeSAP Then

            '----------------------------------------------------------------------------------------
            ' JNAVA (18.07.2016): Valida DPVale
            '----------------------------------------------------------------------------------------
            'oDPVale = oCancelaFacturaMgr.GetDPvaleInfoSap(intdpvaleid)
            If oConfigCierreFI.AplicarS2Credit Then
                oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, NombreDistribuidor)
            Else
                oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
            End If
            '----------------------------------------------------------------------------------------

        Else
            strdpvaleinfo = oCierrediaMgr.GetDPValeInfo(intdpvaleid)
        End If

        If oFactura.CodTipoVenta = "O" Then
            If IsDBNull(dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago = 'FACI'")) Then
                decfacilito = 0
            Else
                decfacilito = dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago = 'FACI'")
            End If
        End If

        With orptDataInfo
            .FacturaID = oFactura.FacturaID
            .ModuloID = ModuloID
            .Disponible = Disponible
            If intdpvaleid <> "" Then
                'Si no es dpvale SAP entra
                If oAppSAPConfig.DPValeSAP Then

                    .FolioDPVale = intdpvaleid
                    Dim oRow As DataRow
                    oRow = Me.oDPVale.InfoDPVALE.Rows(0)

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (18.07.2016): Obtiene datos de distribuidor y cliente
                    '----------------------------------------------------------------------------------------
                    If oConfigCierreFI.AplicarS2Credit Then
                        .NombreAsociado = NombreDistribuidor
                        .vNombreClienteAsociado = ""
                    Else
                        .NombreAsociado = FormatName(oCancelaFacturaMgr.GetNombreClienteSAP(CStr(oRow("KUNNR")))) & "(" & CStr(oRow("KUNNR")) & ")"
                        .vNombreClienteAsociado = FormatName(oCancelaFacturaMgr.GetNombreClienteSAP(CStr(oRow("CODCT")))) & "(" & CStr(oRow("CODCT")) & ")"
                    End If

                Else

                    .NombreAsociado = oCierrediaMgr.GetNombreCliente(CInt(strdpvaleinfo(2))) & "(" & strdpvaleinfo(3) & ")"
                    .vNombreClienteAsociado = strdpvaleinfo(0) & "(" & strdpvaleinfo(1) & ")"
                    .FolioDPVale = intdpvaleid

                End If
            Else
                .NombreAsociado = String.Empty
                .vNombreClienteAsociado = String.Empty
                .FolioDPVale = 0
            End If
            .DeudaFacilito = decfacilito
        End With

        pImprimir.ObtenerDatos(orptDataInfo, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas)

        If oConfigCierreFI.MiniPrinter Then

            Dim oARReporte As New ReporteFacturacion(orptDataInfo, pdtGeneral, "CANCELACIÓN DE FACTURA", oConfigCierreFI.ImprimirCedula)
            Dim oReportViewer As New ReportViewerForm
            oARReporte.Document.Name = "Reporte Facturacion"
            oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            oARReporte.Document.Print(False, False)

        Else
            pImprimir.ImprimirFactura("LPT1", Application.StartupPath & "\epson.drv", False, pdtGeneral, pdtDetalles, pdtPagos, pdtNotas, oFactura.FolioSAP, oFactura.CodTipoVenta, True)
        End If

    End Sub

    Private Function GetDPvaleInfoSap(ByVal DPValeID As String) As cDPVale
        Dim result As New Dictionary(Of String, Object)
        Dim restService As New ProcesosRetail("/pos/venta", "POST")
        Dim params As New Dictionary(Of String, Object)
        Dim cdpvale As New cDPVale()
        Try
            params("INUMVA") = DPValeID
            params("I_RUTA") = "X"
            result = restService.SapZbapiValidaDpvale(params)
            cdpvale.InfoDPVALE = CType(result("T_DP_VALE"), DataTable)
            cdpvale.EEXIST = CStr(result("EEXIST"))
            cdpvale.ESTATU = CStr(result("ESTATU"))
            cdpvale.EPLAZA = CStr(result("EPLAZA"))
            cdpvale.LimiteCredito = CDec(CStr(result("ELCREDITO")))
            cdpvale.Congelado = CStr(result("Congelado"))
            cdpvale.LimiteCreditoPrestamo = CDec(result("ECREDITOP"))
            cdpvale.FlagPrestamo = CStr(result("EPRESTAMO"))
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al obtener información del DPVale")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return cdpvale
    End Function

    Private Sub MovimientoEntradaArticulos()

        'Damos Entrada a los Articulos
        Dim nReg As Integer, nFil As Integer

        If oFactura.Detalle.Tables(0).Rows.Count > 0 Then

            nReg = oFactura.Detalle.Tables(0).Rows.Count - 1

        Else

            Exit Sub

        End If

        For nFil = 0 To nReg

            With oFactura.Detalle.Tables(0).Rows(nFil)

                oArticulo.ClearFields()

                oArticuloMgr.LoadInto(.Item("CodArticulo"), oArticulo)
                oFacturaCorrida.Numero = .Item("Numero")
                oFacturaCorrida.Cantidad = .Item("Cantidad")

                FillDataMovimiento()
                oFacturaCorridaMgr.SaveMovimiento(oFactura.Total, oFacturaCorrida, 0, 0)

            End With

        Next

    End Sub

    Private Sub FillDataMovimiento()

        With oFacturaCorrida.Movimiento
            .ClearFieldsMovimiento()
            .Mov_CodTipoMov = 116       'Entrada por Cancelacion de Venta
            .Mov_TipoMovimiento = "E"
            .Mov_Status = "A"
            .Mov_CodAlmacen = oFactura.CodAlmacen
            .Mov_Destino = oFactura.CodAlmacen

            '.Mov_Folio = oFactura.FacturaID
            .Mov_Folio = oFactura.FolioFactura

            .Mov_CodArticulo = oArticulo.CodArticulo
            .Mov_Descripcion = oArticulo.Descripcion
            .Mov_CodLinea = oArticulo.Codlinea
            .Mov_CodMarca = oArticulo.CodMarca
            .Mov_CodFamilia = oArticulo.CodFamilia
            .Mov_CodUnidad = oArticulo.CodUnidadVta
            .Mov_CodUso = oArticulo.CodUso
            .Mov_CodCategoria = oArticulo.CodCategoria
            .Mov_CostoUnit = oArticulo.CostoProm
            .Mov_PrecioUnit = oArticulo.PrecioVenta
            .Mov_FolioControl = ""
            .Mov_CodCaja = oFactura.CodCaja
        End With

    End Sub

    Private Sub ActualizaDatosWS()
        Try
            Dim iFil As Integer
            Dim tCredito As Decimal, tDPVale As Decimal
            tDPVale = 0
            tCredito = 0
            Dim bandVale As Boolean = True

            If Not (dsFormaPago Is Nothing) Then

                If dsFormaPago.Tables(0).Rows.Count > 0 Then

                    For iFil = 0 To (dsFormaPago.Tables(0).Rows.Count - 1)
                        'Vales de Caja
                        '--------------------Solo entrara una Vez No ocupa volver a entrar
                        If dsFormaPago.Tables(0).Rows(iFil).Item("CodFormasPago") = "VCJA" And bandVale Then
                            Dim oCancelaFacturaMgr As CancelaFacturaManager
                            oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

                            oCancelaFacturaMgr.UpdateStatusValeCaja(oFactura.FacturaID)

                            oFacturaMgr = Nothing
                            bandVale = False

                        End If
                        '--------------------Solo entrara una Vez No ocupa volver a entrar
                        'Si no es dpvale SAP entra
                        If Not oAppSAPConfig.DPValeSAP Then

                            If dsFormaPago.Tables(0).Rows(iFil).Item("CodFormasPago") = "DPVL" Then

                                'oDPValeInfo = oWsValidaDPVale.GetDPVale(dsFormaPago.Tables(0).Rows(iFil).Item("DPValeID"))

                                'If oDPValeInfo.DPValeID <> 0 Then

                                '    oDPValeFacturaInfo = Nothing

                                '    oDPValeFacturaInfo = New wsControlDPVales.DPValeFacturaInfo

                                '    With oDPValeFacturaInfo

                                '        .DPValeID = oDPValeInfo.DPValeID
                                '        .Almacen = oAppContext.ApplicationConfiguration.Almacen
                                '        .FacturaID = 0
                                '        .FechaEntregado = Now
                                '        .FechaFactura = Now
                                '        .ClienteAsociado = String.Empty
                                '        .Monto = oDPValeInfo.MontoUtilizado
                                '        .AsociadoID = oDPValeInfo.AsociadoID
                                '        .ClienteAsociadoID = 0
                                '        .CodigoCaja = oAppContext.ApplicationConfiguration.NoCaja
                                '        .FolioFactura = oFactura.FolioFactura
                                '        .MontoCobranza = 0
                                '        .ParesPzas = oDPValeInfo.ParesPzas
                                '        .MontoDPValeI = oDPValeInfo.MontoDPValeI
                                '        .MontoDPValeP = oDPValeInfo.MontoDPValeP

                                '    End With

                                '    oWsValidaDPVale.UpdateDataFactura(oDPValeFacturaInfo)
                                '    tDPVale = tDPVale + oDPValeInfo.MontoUtilizado

                                'End If
                            End If
                        End If
                    Next

                    'Si no es dpvale SAP entra
                    If Not oAppSAPConfig.DPValeSAP Then

                        'Verificamos si hay pagos DPVale
                        If tDPVale > 0 Then
                            'Insertamos Movimiento DPVale
                            'oWsEstadoCuentaAsociado = New wsEstadoCuentaAsociado.EstadodeCuentaAsociado
                            Dim oPeriodoDetalleMgr As New PeriodoDetalleManager(oAppContext)

                            If Not oAppContext.ApplicationConfiguration.WSUrl = String.Empty Then
                                'oWsEstadoCuentaAsociado.Url = oAppContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
                                'oWsEstadoCuentaAsociado.strURL.TrimEnd("/")
                            End If

                            'oWsMovimientoInfo = New wsEstadoCuentaAsociado.MovimientosInfo

                            'oWsMovimientoInfo.FechaMovimiento = oFactura.Fecha
                            'oWsMovimientoInfo.CodigoAlmacen = oFactura.CodAlmacen
                            'oWsMovimientoInfo.CodigoCaja = oFactura.CodCaja
                            'oWsMovimientoInfo.FolioMovimiento = oFactura.FolioFactura
                            'oWsMovimientoInfo.TipoDocumento = "CANC. FACTURA"
                            'oWsMovimientoInfo.Usuario = oAppContext.Security.CurrentUser.Name
                            'oWsMovimientoInfo.StatusRegistro = 1
                            'oWsMovimientoInfo.Cargo = 0
                            'oWsMovimientoInfo.Abono = tDPVale
                            'oWsMovimientoInfo.AsociadoID = oDPValeInfo.AsociadoID
                            'oWsMovimientoInfo.Año = CInt(Format(oFactura.Fecha, "yyyy"))
                            'oWsMovimientoInfo.Mes = CInt(Format(oFactura.Fecha, "MM"))

                            ' ''Se agrega la Plaza y el periodo en el que se realizó la factura.
                            'oWsMovimientoInfo.Plaza = GetPlaza()
                            ''oWsMovimientoInfo.Referencia = 0 'oPeriodoDetalleMgr.SelectPeriodoActual(oFactura.Fecha)
                            'oWsMovimientoInfo.Referencia = oDPValeInfo.DPValeID

                            'oWsEstadoCuentaAsociado.InsertMovimiento("V", oWsMovimientoInfo)

                            'oWsMovimientoInfo = Nothing
                            'oWsEstadoCuentaAsociado = Nothing

                        End If
                    End If

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Function GetPlaza() As String
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenMgr.Load(oAppContext.ApplicationConfiguration.Almacen)
        If Not oAlmacen Is Nothing Then
            If oAlmacen.ID > 0 Then
                Return oAlmacen.PlazaID
            End If
        End If

    End Function

    Private Function ValidaFactura() As Boolean

        'If oFactura.FolioSAP = String.Empty Then

        '    MsgBox("Factura " & ebFolioFactura.Text.PadLeft(6, "0") & " no puede ser cancelada. No tiene FOLIO SAP. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
        '    Return False

        'End If
        If oFactura.StatusFactura = "CAN" Then

            MsgBox("Factura " & ebFolioFactura.Text.PadLeft(6, "0") & " está CANCELADA. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
            Return False

        End If
        If Not ValidaFacturaFecha(oFactura.Fecha) Then

            MsgBox("Factura " & ebFolioFactura.Text.PadLeft(6, "0") & " no puede ser cancelada. No pertenece al Día. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
            Return False

        End If

        If ValidaFacturaCierre(oFactura.Fecha) Then

            MsgBox("Ya se realizó el Cierre del Día. No se pueden Cancelar Facturas. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
            Return False

        End If

        If oFactura.CodTipoVenta = "C" Then

            '<Aqui van los abonos>
            'If TieneAbonos(oFactura.ClienteId) Then
            '    MsgBox("Ya se realizaron Abonos a la Factura. No puede Cancelarse. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
            '    Return False
            'End If
            '</>

        End If

        If oFactura.CodTipoVenta = "A" Then

            MsgBox("No es posible cancelar facturas de apartado.", MsgBoxStyle.Exclamation, " Cancelación de Facturas")
            Return False

        End If

        Return True

    End Function

    Private Function ValidaFacturaFecha(ByVal vFechaFactura As Date) As Boolean

        Dim vFechaServer As DateTime

        Dim oFacturaMgr As CancelaFacturaManager
        oFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        vFechaServer = oFacturaMgr.GetDateServer

        oFacturaMgr = Nothing
        vFechaServer = Format(vFechaServer, "dd/MM/yyyy")
        vFechaFactura = Format(vFechaFactura, "dd/MM/yyyy")
        If vFechaServer <> vFechaFactura Then

            Return False

        Else

            Return True

        End If

    End Function

    Private Function ValidaFacturaCierre(ByVal vFechaFactura As Date) As Boolean

        Dim vFechaServer As DateTime

        Dim oFacturaMgr As CancelaFacturaManager
        oFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        If oFacturaMgr.IsDayClosed(vFechaFactura) Then

            oFacturaMgr = Nothing
            Return True

        Else

            oFacturaMgr = Nothing
            Return False

        End If

    End Function

    'Private Function TieneAbonos(ByVal intClienteID As Integer) As Boolean

    '    Dim oResult As Boolean = False
    '    Dim dsAbonos As DataSet
    '    Dim dvAbonos As DataView
    '    Dim dvRAbonos As DataRowView

    '    Me.Cursor = Cursors.WaitCursor

    '    oAsociado.Clear()
    '    oAsociadosMgr.LoadIntoByClienteID(intClienteID, oAsociado)

    '    If Not oAsociado.AsociadoID = 0 Then

    '        dsAbonos = AbonoCDMgr.SelectAbonosFacturasByAsociadoID(oAsociado.AsociadoID)

    '        If dsAbonos.Tables(0).Rows.Count > 0 Then

    '            dvAbonos = New DataView(dsAbonos.Tables(0), "FolioFactura = " & ebFolioFactura.Value & " AND CodAlmacen='" & oAppContext.ApplicationConfiguration.Almacen & "' AND CodCaja='" & ebCodCaja.Text & "'", "FolioFactura", DataViewRowState.CurrentRows)

    '            If dvAbonos.Count > 0 Then

    '                dvRAbonos = dvAbonos.Item(0)

    '                If dvAbonos.Item(0).Item("PagoEstablecido") = dvAbonos.Item(0).Item("Saldo") Then
    '                    oResult = False
    '                Else
    '                    oResult = True
    '                End If

    '            Else
    '                oResult = False
    '            End If

    '            dvAbonos.Dispose()
    '            dvAbonos = Nothing

    '        Else
    '            oResult = True
    '        End If

    '    End If

    '    Me.Cursor = Cursors.Default

    '    Return oResult

    'End Function

    Private Function ValidaFolioPedido(ByVal PedidoID As Integer) As Boolean

        Dim bRes As Boolean = True

        oPedido = Nothing
        oPedido = New Pedidos(PedidoID, 0)

        If oPedido Is Nothing OrElse oPedido.PedidoID = 0 Then
            MessageBox.Show("No se encontró el Pedido en la base de datos local. Favor de llamar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

    Private Sub Sm_BuscarFactura(ByVal TipoFolio As String, Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (Me.ebCodCaja.Text = String.Empty) Then

            MsgBox("No ha sido seleccionada un Código de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oCancelarFacturaMgr As CancelaFacturaManager
            oCancelarFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

            Dim oOpenRecordDlg As New OpenRecordDialog

            Dim oFacturasDelDia As New FacturasDelDia
            oFacturasDelDia.Almacen = oAppContext.ApplicationConfiguration.Almacen
            oFacturasDelDia.FechaCierre = oCancelarFacturaMgr.GetDateServer
            oFacturasDelDia.NoCaja = Me.ebCodCaja.Text
            oOpenRecordDlg.CurrentView = oFacturasDelDia

            oOpenRecordDlg.ShowDialog()
            'me quede en probar el abrir de los folios de las facturas
            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                If TipoFolio = "FolioPro" Then
                    Me.ebFolioFactura.Value = oOpenRecordDlg.Record.Item("FolioFactura")
                Else
                    Me.ebFolioSAP.Text = oOpenRecordDlg.Record.Item("Referencia")
                End If

            End If

        End If

        If ebFolioFactura.Value > 0 OrElse (ebFolioSAP.Text <> "0" And ebFolioSAP.Text <> "") Then

            Me.ebFolioSAP.Text = Me.ebFolioSAP.Text.PadLeft(10, "0")
            If oFacturaMgr Is Nothing Then

                oFacturaMgr = New FacturaManager(oAppContext)

            End If

            oFactura.ClearFields()

            If ebFolioFactura.Value > 0 Then
                oFacturaMgr.Load(ebFolioFactura.Value, ebCodCaja.Text, oFactura)
            Else
                Dim dsFolioCaja As DataSet
                dsFolioCaja = New DataSet

                dsFolioCaja = oFacturaMgr.SelectFolioCaja(ebFolioSAP.Text)
                If dsFolioCaja.Tables(0).Rows.Count > 0 Then
                    oFacturaMgr.Load(dsFolioCaja.Tables(0).Rows(0)("FolioFactura"), dsFolioCaja.Tables(0).Rows(0)("CodCaja"), oFactura)
                    ebCodCaja.Text = dsFolioCaja.Tables(0).Rows(0)("CodCaja")
                End If
            End If

            If oFactura.FacturaID > 0 Then

                If ValidaFactura() Then
                    'Cargamos los Articulos del Detalle
                    oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
                    'Cargamos las Formas de Pago
                    dsFormaPago = oFacturaFormaPago.Load(oFactura.FacturaID)
                    btnAceptar.Enabled = True
                    btnAceptar.Focus()

                Else

                    btnAceptar.Enabled = False
                    Me.ebFolioFactura.Focus()

                End If
                'TienePedidoSiHay(oFactura.PedidoID)
                If TienePedidoSiHay(oFactura.PedidoID) Then
                    MessageBox.Show("Para cancelar la factura tienes que cancelar el Pedido Si hay completo, ingresar a la opcion Cancelacion de Pedidos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    oFactura.ClearFields()
                    ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
                    ebFolioFactura.Value = 0
                    btnAceptar.Enabled = False
                    LimpiarPedidoSiHay()
                    ebCodCaja.Focus()
                End If
                '-------------------------------------------------------------------------------------------------------------
                'MPERAZA 23/05/2013: VALIDO SI ESA FACTURA TIENE PEDIDO DE SI HAY
                '-------------------------------------------------------------------------------------------------------------
                'If TienePedidoSiHay(oFactura.PedidoID) = True Then
                '-------------------------------------------------------------------------------------------------------------------------
                'JNAVA (05.11.2014): Si es un pedido de DPVale ya se permite cancelar facturas 
                '-------------------------------------------------------------------------------------------------------------------------
                '-------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 23/03/2015: Se reembolsara solo en efectivo
                '-------------------------------------------------------------------------------------------------------------------------
                'ActivaCheckPedidosSiHay()

                '-------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 27.10.2014: Si es un pedido de DPVale por el momento no se permite cancelar facturas porque no esta definido el
                'proceso
                '-------------------------------------------------------------------------------------------------------------------------
                'If oPedido.CodTipoVenta.Trim.ToUpper = "V" Then
                '    MessageBox.Show("Por el momento no es posible cancelar facturas de Pedidos SH con pago DPVale", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Me.btnAceptar.Enabled = False
                '    Me.ebFolioFactura.Focus()
                'Else
                '    ActivaCheckPedidosSiHay()
                'End If
                'End If
                '--------------------------------------------------------------------------------------------------------------
            Else
                MsgBox("Folio de Factura NO EXISTE.  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
                btnAceptar.Enabled = False
                Me.ebFolioFactura.Focus()
            End If
        Else
            btnAceptar.Enabled = False
            ebFolioFactura.Value = 0
        End If

        If ebFolioFactura.Value = 0 AndAlso ebFolioSAP.Text = "0" Then
            LimpiarPedidoSiHay()
        End If

    End Sub

    Private Function TienePedidoSiHay(ByVal PedidoID As Integer) As Boolean
        Dim Result As Boolean = False
        If PedidoID > 0 Then 'Primero Checa si la factura tiene un pedido de si Hay
            If ValidaFolioPedido(PedidoID) Then 'Segundo checa si el pedido existe en la base de datos
                oPedido = Nothing
                oPedido = New Pedidos(PedidoID, 0)
                Result = True
            End If
        End If
        Return Result
    End Function

    Private Sub ActivaCheckPedidosSiHay()
        MontoEfectivo = 0
        MontoValeCaja = 0
        MontoDPVale = 0
        ObtenerFormasPagoPedido(MontoEfectivo, MontoValeCaja, MontoDPVale)
        MontoEfectivo = MontoEfectivo + MontoValeCaja
        MontoValeCaja = 0
        CheckDevEfectivo.Checked = True
        '------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 25/03/2015: Se comento porque de ahora en adelante todas las cancelaciones se retornara efectivo
        '------------------------------------------------------------------------------------------------------------------
        'If MontoEfectivo > 0 AndAlso MontoValeCaja > 0 Then
        '    grpSiHay.Visible = True
        '    CheckValeCaja.Visible = True
        '    CheckValeCaja.Checked = True
        '    CheckValeCaja.Enabled = False
        '    If TienePermisoParaDevoluviondeEfectivo() Then 'Checa si tiene el permiso de devolver dinero
        '        CheckDevEfectivo.Visible = True
        '    Else
        '        'No tiene Permiso para devolucion de dinero
        '        'Pero tiene efectivo
        '        If MontoEfectivo > 0 Then
        '            grpSiHay.Visible = True
        '            CheckValeCaja.Visible = True
        '            CheckValeCaja.Checked = True
        '            CheckValeCaja.Enabled = False
        '            MontoValeCaja = MontoValeCaja + MontoEfectivo
        '            MontoEfectivo = 0
        '        End If
        '    End If
        'ElseIf MontoEfectivo > 0 Then
        '    If TienePermisoParaDevoluviondeEfectivo() Then 'Checa si tiene el permiso de devolver dinero
        '        grpSiHay.Visible = True
        '        CheckDevEfectivo.Visible = True
        '    Else
        '        'No tiene Permiso para devolucion de dinero
        '        'Pero tiene efectivo
        '        If MontoEfectivo > 0 Then
        '            grpSiHay.Visible = True
        '            CheckValeCaja.Visible = True
        '            CheckValeCaja.Checked = True
        '            CheckValeCaja.Enabled = False
        '            MontoValeCaja = MontoValeCaja + MontoEfectivo
        '            MontoEfectivo = 0
        '        End If
        '    End If
        'ElseIf MontoValeCaja > 0 Then
        '    grpSiHay.Visible = True
        '    CheckValeCaja.Visible = True
        '    CheckValeCaja.Checked = True
        '    CheckValeCaja.Enabled = False
        'End If
    End Sub

    Private Function TienePermisoParaDevoluviondeEfectivo() As Boolean
        Dim Result As Boolean = False
        Dim Permiso As String = "DportenisPro.DPTienda.SiHay.CancelacionFacturaSH"
        If oAppContext.Security.CurrentUser.IsOperationAuthorized(Permiso, Permiso & ".DevolucionEfectivo") Then
            Result = True
        End If
        Return Result
    End Function

    Private Function FormatName(ByVal strname As String) As String
        Try
            Dim strApepApemNom() As String
            Dim strNombre As String = String.Empty
            Dim strApelidos As String = String.Empty

            strApepApemNom = Split(Trim(strname), "_")
            Select Case strApepApemNom.Length
                Case 6
                    strNombre = Trim(strApepApemNom(4)) & " " & strApepApemNom(5)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2) & " " & strApepApemNom(3)
                Case 5
                    strNombre = Trim(strApepApemNom(3)) & " " & strApepApemNom(4)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1) & " " & strApepApemNom(2)
                Case 4
                    strNombre = Trim(strApepApemNom(2)) & " " & strApepApemNom(3)
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 3
                    strNombre = Trim(strApepApemNom(2))
                    strApelidos = strApepApemNom(0) & " " & strApepApemNom(1)
                Case 2
                    strNombre = strApepApemNom(1)
                    strApelidos = Trim(strApepApemNom(0))
                Case 1
                    strNombre = String.Empty
                    strApelidos = Trim(strApepApemNom(0))
                Case Else
                    strNombre = String.Empty
                    strApelidos = String.Empty
            End Select

            strNombre = strNombre & " " & strApelidos

            Return UCase(Trim(strNombre))

        Catch ex As Exception
            Throw New ApplicationException("[FormatName]", ex)
        End Try

    End Function

    Private Sub LimpiarPedidoSiHay()
        CheckDevEfectivo.Visible = False
        CheckValeCaja.Visible = False
        grpSiHay.Visible = False
        MontoEfectivo = 0
        MontoValeCaja = 0
    End Sub

    'Private Function GenerarVales(ByVal Monto As Decimal, ByVal DocNum As String, Optional ByVal DevolverEfectivo As Boolean = False) As Boolean
    '    Dim Result As Boolean = False
    '    Dim ValeCajaID As Integer = 0
    '    ValeCajaID = GenerarValeCaja(Monto, DocNum, DevolverEfectivo)
    '    If ValeCajaID <> 0 Then
    '        Result = True
    '        ActivarValeCaja(ValeCajaID)
    '    End If
    '    Return Result
    'End Function

    'Private Sub ValidaReembolso()
    '    Dim ValeCajaID As Integer = 0
    '    If CheckValeCaja.Visible = True AndAlso CheckValeCaja.Checked AndAlso CheckDevEfectivo.Visible = True AndAlso CheckDevEfectivo.Checked Then
    '        If ReembolsoFacturasCanceladasSAP(oPedido, MontoEfectivo, MontoValeCaja, MontoDPVale, strDocNumEfectivo, strDocNumValeCaja) <> String.Empty Then 'Aplicamos el Rembolso en sap
    '            GenerarVales(MontoValeCaja, strDocNumValeCaja, False) 'Genera el Vale de Caja  
    '            GenerarVales(MontoEfectivo, strDocNumEfectivo, True)  'Genera el Vale de efectivo   
    '        End If
    '    ElseIf CheckValeCaja.Visible = True AndAlso CheckValeCaja.Checked AndAlso CheckDevEfectivo.Visible = True AndAlso CheckDevEfectivo.Checked = False Then  'aplicamos una vale de caja mas el monto de efectivo
    '        MontoValeCaja = MontoValeCaja + MontoEfectivo
    '        MontoEfectivo = 0
    '        If ReembolsoFacturasCanceladasSAP(oPedido, MontoEfectivo, MontoValeCaja, MontoDPVale, strDocNumEfectivo, strDocNumValeCaja) <> String.Empty Then  'Aplicamos el Rembolso en sap
    '            GenerarVales(MontoValeCaja, strDocNumValeCaja, False) 'Genera el Vale de Caja  
    '        End If
    '    ElseIf CheckDevEfectivo.Visible = True AndAlso CheckDevEfectivo.Checked Then 'Vale de Efctivo
    '        If ReembolsoFacturasCanceladasSAP(oPedido, MontoEfectivo, MontoValeCaja, MontoDPVale, strDocNumEfectivo, strDocNumValeCaja) <> String.Empty Then 'Aplicamos el Rembolso en sap
    '            GenerarVales(MontoEfectivo, strDocNumEfectivo, True) 'Genera el Vale efectivo
    '        End If
    '    ElseIf CheckValeCaja.Visible = True AndAlso CheckValeCaja.Checked Then 'Vale de Caja
    '        If ReembolsoFacturasCanceladasSAP(oPedido, MontoEfectivo, MontoValeCaja, MontoDPVale, strDocNumEfectivo, strDocNumValeCaja) <> String.Empty Then  'Aplicamos el Rembolso en sap
    '            GenerarVales(MontoValeCaja, strDocNumValeCaja, False) 'Genera el Vale de Caja
    '        End If
    '    ElseIf CheckValeCaja.Visible = False AndAlso CheckDevEfectivo.Visible = True AndAlso CheckDevEfectivo.Checked = False Then 'si el usuario no selecciono el check de efectivo hace un vale de caja
    '        MontoValeCaja = MontoEfectivo
    '        MontoEfectivo = 0
    '        If ReembolsoFacturasCanceladasSAP(oPedido, MontoEfectivo, MontoValeCaja, MontoDPVale, strDocNumEfectivo, strDocNumValeCaja) <> String.Empty Then 'Aplicamos el Rembolso en sap
    '            GenerarVales(MontoValeCaja, strDocNumValeCaja, False) 'Genera el vale de caja
    '        End If
    '    End If

    'End Sub


    '---------------------------------------------------------------------------------------------
    'JNAVA (05/11/2014) - Validamos lo que se reembolsara
    '---------------------------------------------------------------------------------------------
    Private Sub ValidaReembolso()

        Dim ValeCajaID As Integer = 0

        Try

            '---------------------------------------------------------------------------------------------
            'Realizamos los movimientos del Reembolso en los saldos del cliente en SAP
            '---------------------------------------------------------------------------------------------
            If Not ReembolsoFacturasCanceladasSAP(oPedido, Me.MontoValeCajaCancelacionSH, 0, Me.MontoDpvaleCancelacionSH, strDocNumEfectivo, strDocNumValeCaja) Then
                Exit Sub
            End If

            '--------------------------------------------------------------------------------------
            'Generamos el Vale de Caja 
            '--------------------------------------------------------------------------------------

            '--------------------------------------------------------------------------------------
            'FLIZARRAGA 23/03/2015: Ya se retorna completa el monto del vale de caja
            '--------------------------------------------------------------------------------------
            Dim totalreembolso As Decimal = Me.MontoValeCajaCancelacionSH
            ValeCajaID = GenerarValeCaja(totalreembolso, strDocNumEfectivo, True) 'Me.CheckDevEfectivo.Checked)  'Devolvemos el Efectivo
            'If Me.CheckDevEfectivo.Checked Then 'Resvisamos si es Devolucion de Efectivo
            '    ValeCajaID = GenerarValeCaja(MontoEfectivo, strDocNumEfectivo, Me.CheckDevEfectivo.Checked)  'Devolvemos el Efectivo
            '    If MontoValeCaja > 0 Then 'Si no se cubrio el importe total con el Efectivo, generamos un Vale de Caja para las demas formas de pago en el pedido
            '        ValeCajaID = GenerarValeCaja(MontoValeCaja, strDocNumValeCaja)
            '    End If
            'Else
            '    ValeCajaID = GenerarValeCaja(MontoValeCaja, strDocNumValeCaja)
            'End If

            '--------------------------------------------------------------------------------------
            'Validamos si se genero correctamente el Vale de Caja
            '--------------------------------------------------------------------------------------
            If ValeCajaID = 0 Then
                EscribeLog("No se genero el vale de caja para el pedido " & oPedido.FolioSAP, "Error al generar vale de caja en Pedido SH")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Eventos"

    Private Sub frmCancelarFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vUserID = UCase(oAppContext.Security.CurrentUser.SessionLoginName)
        vUserName = UCase(oAppContext.Security.CurrentUser.Name)

        ebCodUser.Text = vUserID
        ebNomUser.Text = vUserName

        oAppContext.Security.CloseImpersonatedSession()
        FillCaja()

        InicializaObjetos()
    End Sub

    Private Sub frmCancelarFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ebFolioFactura_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioFactura.ButtonClick
        LimpiarPedidoSiHay()
        Sm_BuscarFactura("FolioPro", True)
    End Sub

    Private Sub ebFolioSAP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioSAP.ButtonClick
        LimpiarPedidoSiHay()
        Sm_BuscarFactura("FolioSAP", True)
    End Sub

    Private Sub ebFolioSAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioSAP.Validating
        LimpiarPedidoSiHay()
        Sm_BuscarFactura("FolioSAP", False)
    End Sub

    Private Sub ebFolioFactura_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioFactura.GotFocus
        ebFolioSAP.Text = "0"
        btnAceptar.Enabled = False
    End Sub

    Private Sub ebFolioSAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolioSAP.GotFocus
        ebFolioFactura.Value = 0
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        oAppContext.Security.CloseImpersonatedSession()
        If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CancelarFactura") Then
            Exit Sub
        End If

        oAppContext.Security.CloseImpersonatedSession()

        Try

            If ebFolioFactura.Value > 0 OrElse (ebFolioSAP.Text <> "0" And ebFolioSAP.Text <> "") Then
                'TODO: EARAGON Cancelacion Tarjeta de Credito EHub.
                ''''Cancelar Formas de Pago.
                Dim dsFormasPagoPuntos As DataSet

                If oAppSAPConfig.eHub = True Then

                    '-----------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 25/02/2015: Se modifico para tambien guardar los pagos con tarjetas Karum
                    '-----------------------------------------------------------------------------------------------------------
                    Dim dsFormasPagoTmp As DataSet = Me.dsFormaPago.Clone()

                    dsFormasPagoPuntos = Me.dsFormaPago.Clone()

                    '------------------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 24/04/2015: Omite todas formas de Pago hechas con DPCard Puntos
                    '------------------------------------------------------------------------------------------------------------------------------------
                    For Each orow As DataRow In Me.dsFormaPago.Tables(0).Rows

                        If CBool(orow("StatusRegistro")) = True AndAlso orow("CodTipoTarjeta") = "TE" AndAlso CStr(orow("CodFormasPago")) <> "DPPT" Then
                            dsFormasPagoTmp.Tables(0).ImportRow(orow)

                        End If
                    Next
                    dsFormasPagoTmp.AcceptChanges()

                    If oConfigCierreFI.DPCardPuntos = True Then

                        '------------------------------------------------------------------------------------------------------------------------------------
                        'FLIZARRAGA 24/04/2015: Guarda los pagos hechos con formas de Pago DPCard Puntos
                        '------------------------------------------------------------------------------------------------------------------------------------
                        For Each row As DataRow In Me.dsFormaPago.Tables(0).Rows

                            If CBool(row("StatusRegistro")) = True AndAlso CStr(row("CodTipoTarjeta")) = "TE" AndAlso CStr(row("CodFormasPago")) = "DPPT" Then
                                dsFormasPagoPuntos.Tables(0).ImportRow(row)

                            End If

                        Next

                        dsFormasPagoPuntos.AcceptChanges()

                    End If
                    If dsFormasPagoTmp.Tables(0).Rows.Count > 0 Then
NoCierra:

                        Dim oFrmCancelarPagoTarjeta As New frmCancelarPagoTarjeta

                        oFrmCancelarPagoTarjeta.oFactura = Me.oFactura

                        oFrmCancelarPagoTarjeta.dsFormasPago = dsFormasPagoTmp.Copy

                        If oFrmCancelarPagoTarjeta.ShowDialog() <> DialogResult.OK Then

                            'GoTo NoCierra
                            Exit Sub
                        End If
                    End If
                End If

                Dim oCancelaFacturaMgr As CancelaFacturaManager

                oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

                Me.Cursor.Current = Cursors.WaitCursor

                '-------------------------------------------------------------------------------------------------------------
                'Cancelamos Fatura en Dportenis PRO y en SAP
                ' AFH: 7.09.2016 valida si la factura fue cancelada correctamente para proceder o abortar el flujo
                '-------------------------------------------------------------------------------------------------------------
                If CancelaFactura() = False Then
                    Exit Sub
                End If

                '-----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 25/04/2015: Aplica en caso de que este activado DPCard Puntos Lealtad
                '-----------------------------------------------------------------------------------------------------------------
                Dim impDev As Decimal = 0

                If oConfigCierreFI.DPCardPuntos = True Then

                    If oFactura.NoDPCardPuntos <> "" Then
                        Dim ObjMonto As Object
                        'Dim ObjMonto As Object = dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPCA','DPPT')")
                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                            ObjMonto = dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPCA','DPPT')")
                        Else
                            ObjMonto = dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago NOT IN ('DPPT','VCJA')")
                        End If

                        Dim MontoEfectivo As Decimal = 0
                        If IsDBNull(ObjMonto) = False Then
                            MontoEfectivo = CDec(ObjMonto)
                        End If

                        'wgomez formas pago blue
                        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
                        Dim dtFormasPagoNoAcumula As DataTable = FacturaMgr.GetFormasPagoNoAcumula().Tables(0)
                        Dim MontoBlue As Decimal = 0
                        Dim tarjetaCanje As String = String.Empty
                        For Each row As DataRow In dsFormaPago.Tables(0).Rows
                            Dim bEncontrado As Boolean = False
                            For Each row1 As DataRow In dtFormasPagoNoAcumula.Rows
                                If CStr(row("CodFormasPago")) = CStr(row1("CodFormasPago")) Then
                                    bEncontrado = True
                                    Exit For
                                End If
                            Next
                            If bEncontrado = False Then
                                MontoBlue = MontoBlue + Math.Round(CDec(row("MontoPago")), 2)
                            End If
                            If CStr(row("CodFormasPago")) = "DPPT" Then
                                tarjetaCanje = CStr(row("NumeroTarjeta"))
                            End If
                        Next

                        Select Case oFactura.CodDPCardPunto
                            Case "BON"
                                '-------------------------------------------------------------------------------------------------
                                'FLIZARRAGA 25/04/2015: Cancela los puntos bonificados realizados en la factura
                                '-------------------------------------------------------------------------------------------------
                                Dim RestarTarjeta As Decimal = GetMontoDPCardPunto()
                                MontoBlue -= RestarTarjeta
                                If MontoBlue > 0 Then
                                    'MontoEfectivo -= RestarTarjeta
                                    'If MontoEfectivo > 0 Then
                                    CancelarBonificacionDPCardPuntos(oFactura, MontoBlue, impDev)
                                    'CancelarBonificacionDPCardPuntos(oFactura, MontoEfectivo, impDev)
                                End If
                            Case "CAN"
                                '-------------------------------------------------------------------------------------------------
                                'FLIZARRAGA 24/04/2015: Cancela la factura en dado caso que haya sido un canje
                                '-------------------------------------------------------------------------------------------------
                                CancelarCanjeDPCardPuntos(oFactura, dsFormasPagoPuntos, impDev)
                            Case "C/B"
                                '------------------------------------------------------------------------------------------------------------
                                'FLIZARRAGA 27/09/2018: Cancela el canje y si tiene bonificación también tiene hacer la devolución de puntos
                                '------------------------------------------------------------------------------------------------------------
                                'CancelarCanjeDPCardPuntos(oFactura, dsFormasPagoPuntos, impDev)
                                Dim tipo_ As String = String.Empty
                                If tarjetaCanje <> String.Empty Then
                                    tipo_ = consulta_bin_tipo_blue(tarjetaCanje.Trim())
                                End If
                                If tipo_.Trim() = "DB" Then
                                    CancelarCanjeDPCardPuntos(oFactura, dsFormasPagoPuntos, impDev, tarjetaCanje)
                                    If MontoBlue > 0 Then
                                        CancelarBonificacionDPCardPuntos(oFactura, MontoBlue, impDev)
                                    End If
                                Else
                                    If MontoBlue > 0 Then
                                        'If MontoEfectivo > 0 Then
                                        CancelarBonificacionByMonto(oFactura, dsFormasPagoPuntos, MontoBlue)
                                        'CancelarBonificacionByMonto(oFactura, dsFormasPagoPuntos, MontoEfectivo)
                                    End If
                                End If
                                
                        End Select
                    End If

                End If
                '-------------------------------------------------------------------------------------------------------------
                'Revivimos el cupon de descuento en caso de existir en la factura
                '-------------------------------------------------------------------------------------------------------------
                ReviveCuponDescuento(oFactura.FacturaID)

                '-------------------------------------------------------------------------------------------------------------
                'Damos Entrada a los Articulos
                MovimientoEntradaArticulos()

                'Actualizamos DPVale
                'ActualizaDatosWS()
                'Se imprime la Factura

                If oConfigCierreFI.MiniPrinter Then

                    '-----------------------------------------------------------
                    ImprimirFactCancel(oFactura.FacturaID, "Facturacion", True)

                    '-----------------------------------------------------------
                Else
                    'no se imprime nada
                End If

                '-----------------------------------------------------------------------------------------------------------------------------
                'MPERAZA 23/05/2013:   SABER SI LA FACTURA PERTENECE A UN PEDIDO DE SIHAY
                '-----------------------------------------------------------------------------------------------------------------------------
                If TienePedidoSiHay(oFactura.PedidoID) Then
                    'validamos que sea de dppuntos para no imprimir el vale de caja y que no este activo el nuevo servicio de blue
                    If oFactura.NoDPCardPuntos <> "" Then
                        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                            ValidaReembolso()
                        End If

                    End If



                End If
                Dim VcjaMgr As New ValeCajaManager(oAppContext)
                Dim Vcja As ValeCaja = VcjaMgr.Create()
                If EsFacturaCambioTalla(Vcja) Then
                    PrintValeCaja(Vcja)
                End If
                '----------------------------------------------------------------------------------------------------------------------------

                Me.Cursor = Cursors.Default
                If ebFolioFactura.Value > 0 Then
                    MsgBox("Se CANCELÓ Factura No. " & ebFolioFactura.Text.PadLeft(6, "0") & "  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
                Else
                    MsgBox("Se CANCELÓ Factura No. " & ebFolioSAP.Text.PadLeft(10, "0") & "  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Cancelación de Factura")
                End If

                oFactura.ClearFields()
                ebCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
                ebFolioFactura.Value = 0
                btnAceptar.Enabled = False
                LimpiarPedidoSiHay()
                ebCodCaja.Focus()
            End If
        Catch ex As Exception
            'Throw ex  'COMENTADO MLVARGAS, VOLVER A PONER COMO ESTABA
        End Try
    End Sub


    Private Sub ebFolioFactura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioFactura.Validating
        LimpiarPedidoSiHay()
        Sm_BuscarFactura("FolioPro", False)
    End Sub

#End Region

#Region " Reembolso - Metodos y Funciones "

    Private Function GenerarValeCaja(ByVal Importe As Decimal, ByVal DocNum As String, Optional ByVal DevolverEfectivo As Boolean = False) As Integer
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA - 30/04/2013: Generamos e imprimimos el Vale de Caja a partir del Pedido con el Tipo de Documento PI (NUEVO).
        '-----------------------------------------------------------------------------------------------------------------------------------------
        Dim ValeCajaID As Integer = 0
        Try
            Dim oValeNuevo As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
            'Dim oCliente As ClienteAlterno

            ''''Obtenemos los datos necesariso del Cliente
            ''oCliente = oClientesMgr.CreateAlterno
            ''oClientesMgr.Load(GetClientePedidoSH(oPedido), oCliente, oPedido.CodTipoVenta)
            ''CodCliente = oCliente.CodigoCliente
            ''ClienteNombre = oCliente.NombreCompleto
            ''oCliente = Nothing

            Dim oClientesMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            Dim oCliente As ClienteAlterno
            Dim CodCliente As String, ClienteNombre As String

            'Obtenemos los datos necesariso del Cliente
            oCliente = oClientesMgr.CreateAlterno
            If oPedido.CodTipoVenta = "P" Then
                oClientesMgr.Load(CStr(oPedido.ClientePGID).PadLeft(10, "0"), oCliente)
            Else
                oClientesMgr.Load(CStr(oPedido.ClienteID).PadLeft(10, "0"), oCliente, oPedido.CodTipoVenta)
            End If
            CodCliente = oCliente.CodigoAlterno
            ClienteNombre = oCliente.NombreCompleto
            oCliente = Nothing

            ''Asignamos el valor del Importe Total
            Dim decValeCaja As Decimal = Importe
            ''Asignamos el valor del Importe Total

            ''Generamos el vale de caja
            If decValeCaja > 0 Then
                oValeNuevo = oValeCajaMgr.Create
                oValeNuevo.CodCliente = GetClientePedidoSH(oPedido)
                oValeNuevo.DocumentoID = oPedido.PedidoID
                oValeNuevo.DocumentoImporte = decValeCaja
                oValeNuevo.Fecha = Now
                oValeNuevo.FolioDocumento = IIf(DevolverEfectivo, DocNum, oFactura.Referencia)
                oValeNuevo.Importe = decValeCaja
                oValeNuevo.MontoUtilizado = 0.0
                oValeNuevo.Nombre = ClienteNombre
                '--------------------------------------------------------------------------------------
                'JNAVA (05.11.2014): Lo generamos habilitado ya que no es necesario activarlo despues
                '--------------------------------------------------------------------------------------
                oValeNuevo.StastusRegistro = True 'False
                oValeNuevo.DevEfectivo = DevolverEfectivo
                '--------------------------------------------------------------------------------------
                oValeNuevo.TipoDocumento = "CF"
                oValeNuevo.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim frmValeC As New FrmValeCaja
                    frmValeC.DevolucionEfectivo = DevolverEfectivo
                    frmValeC.ValeCajaNuevo(oValeNuevo, 0, decValeCaja, True)
                    oValeNuevo.ValeCajaID = frmValeC.intValeCajaID 'Se saca el id del vale de caja generado
                    ValeCajaID = oValeNuevo.ValeCajaID
                    '-------------------------------------------------------------------------------------------------------------------
                    'JNAVA (24/05/2013= - Actualizamos el FolioFISAP en el Vale de Caja recien creado (Requerido por FLIZARRAGA)
                    '-------------------------------------------------------------------------------------------------------------------
                    oValeCajaMgr.ActualizarDocumentoFIValeCaja(ValeCajaID, DocNum)
                    '-------------------------------------------------------------------------------------------------------------------

                    'Limpiamos Objetos
                    frmValeC.Dispose()
                    frmValeC = Nothing
                    oValeNuevo = Nothing
                    oValeCajaMgr = Nothing
                End If
                

              

                
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al generar el Vale de Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) 'Se agrego el dato del valor caption por Correccion por cambio Faamework (JNAVA - 06/11/2015)
            EscribeLog(ex.ToString, "-Error al generar el Vale de Caja-")
            ValeCajaID = 0
            'Throw ex
        End Try

        Return ValeCajaID

    End Function

    'Private Sub ActivarValeCaja(ByVal ValeCajaID As Integer)
    '    Try
    '        Dim oValeCaja As ValeCaja
    '        Dim oValeCajaMgr As New ValeCajaManager(oAppContext)

    '        oValeCaja = oValeCajaMgr.Load(ValeCajaID)

    '        If oValeCaja.MontoUtilizado = 0 Then
    '            oValeCaja.StastusRegistro = True
    '            oValeCaja.Save()
    '        End If

    '        oValeCaja = Nothing
    '        oValeCajaMgr = Nothing

    '    Catch ex As Exception
    '        'MessageBox.Show("Ocurrio un error al Activar el Vale de Caja: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        EscribeLog(ex.ToString, "-Error al Activar el Vale de Caja con ID: " & ValeCajaID & "-")
    '        Throw ex
    '    End Try
    'End Sub

    'Private Function ObtenerFormasPagoPedido(ByRef decEfectivo As Decimal, ByRef decValeCaja As Decimal) As Boolean

    '    'Sumatoria 
    '    Dim EfectivoSAP As Decimal = Decimal.Zero 'Suma EFEC
    '    Dim ValeCajaSAP As Decimal = Decimal.Zero 'Suma Diff EFEC
    '    Dim FacilitoSAP As Decimal = Decimal.Zero 'Cuando hay facilito
    '    Dim MontoFactura As Decimal = Decimal.Zero
    '    Dim MontoTotalFormasPago As Decimal = Decimal.Zero

    '    MontoFactura = oFactura.Total

    '    Try
    '        Dim htImportesSAP As Hashtable

    '        'Consultamos RFC de SAP para obtener los saldos disponibles para reembolso
    '        htImportesSAP = oSAPMgr.ZSH_CALCULO_REEMBOLSOS(oPedido.FolioSAP, "X")
    '        EfectivoSAP = CDec(htImportesSAP("E_IMP_EFECTIVO"))
    '        ValeCajaSAP = CDec(htImportesSAP("E_IMP_VALECAJA"))
    '        FacilitoSAP = CDec(htImportesSAP("E_IMP_FACILITO"))
    '        htImportesSAP = Nothing

    '        'Validamos que el importe total a devolver sea menor o igual que el saldo disponible  en sap para realizar el reembolso
    '        If MontoFactura > (EfectivoSAP + ValeCajaSAP + FacilitoSAP) AndAlso (MontoFactura - (EfectivoSAP + ValeCajaSAP + FacilitoSAP)) > 1 Then
    '            MessageBox.Show("No se puede realizar el Reembolso. El Importe Total es mayor que el Saldo disponible para reembolso." & vbCrLf & "Favor de llamar a soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            decValeCaja = 0
    '            decEfectivo = 0
    '            Return False
    '        End If

    '        MontoTotalFormasPago = IIf((MontoFactura - (EfectivoSAP + ValeCajaSAP + FacilitoSAP)) <= 1, (EfectivoSAP + ValeCajaSAP + FacilitoSAP), MontoFactura)

    '        'Si la configuracion general de devolucion total de efectivo esta seleccionada...
    '        If oConfigCierreFI.DevolverEfectivoSH Then

    '            'Si la suma del Efectivo y vale de caja disponible es mayor o = al importe total a devoler,
    '            If (EfectivoSAP + ValeCajaSAP) >= MontoFactura Then
    '                decEfectivo = MontoFactura
    '                decValeCaja = 0
    '            Else 'De lo contrario, entonces hay formas de pago facilito y...
    '                decEfectivo = EfectivoSAP + ValeCajaSAP 'Devolvemos en efectivo l ocorrespondiente a Efectivo + Vale de caja
    '                decValeCaja = FacilitoSAP 'MontoFactura - decEfectivo 'y en vale de caja lo necesario de facilito.
    '            End If

    '        Else 'De lo contrario, calculamos lo que se deveolvera en efectivo y lo que sera para vale de caja.

    '            'Si facilito trae algun valor le sumo al vale de caja
    '            If FacilitoSAP <> 0 Then ValeCajaSAP = ValeCajaSAP + FacilitoSAP

    '            If EfectivoSAP <> 0 AndAlso ValeCajaSAP = 0 Then 'Unicamente una sola forma de pago efectivo
    '                If MontoFactura > EfectivoSAP Then
    '                    decEfectivo = EfectivoSAP 'MontoFactura - (MontoFactura - EfectivoSAP)
    '                    decValeCaja = 0
    '                Else
    '                    decEfectivo = MontoFactura
    '                    decValeCaja = 0
    '                End If
    '            ElseIf EfectivoSAP = 0 AndAlso ValeCajaSAP <> 0 Then 'Unicamente una sola forma de pago de tarjetas u otras
    '                If MontoFactura > ValeCajaSAP Then
    '                    decEfectivo = 0
    '                    decValeCaja = ValeCajaSAP 'MontoFactura - (MontoFactura - decValeCaja)
    '                Else
    '                    decEfectivo = 0
    '                    decValeCaja = MontoFactura
    '                End If
    '            ElseIf EfectivoSAP <> 0 AndAlso ValeCajaSAP <> 0 Then 'Son varias formas de pago
    '                If MontoFactura > EfectivoSAP Then
    '                    decEfectivo = EfectivoSAP 'MontoFactura - (MontoFactura - EfectivoSAP)
    '                    decValeCaja = MontoFactura - decEfectivo
    '                Else
    '                    decEfectivo = MontoFactura
    '                    decValeCaja = 0
    '                End If
    '            End If
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        EscribeLog(ex.ToString, "-Error al obtener las formas de pago de SAP (Insurtibles)-")
    '        Throw ex
    '    End Try
    'End Function

    '-----------------------------------------------------------------------------------------------------
    'JNAVA (05/07/2013): Funcion Modificada para obtener formas de pago de SAP (EFEC, VCy DPVL)
    '-----------------------------------------------------------------------------------------------------

    Private Function ObtenerFormasPagoPedido(ByRef decEfectivo As Decimal, ByRef decValeCaja As Decimal, ByRef decDPVale As Decimal) As Boolean

        'Sumatoria
        Dim EfectivoSAP As Decimal = Decimal.Zero 'Suma EFEC
        Dim ValeCajaSAP As Decimal = Decimal.Zero 'Suma Diff EFEC
        Dim FacilitoSAP As Decimal = Decimal.Zero 'Cuando hay facilito
        Dim DPValeSAP As Decimal = Decimal.Zero 'Suma DPVale 

        Dim MontoFactura As Decimal = Decimal.Zero
        Dim MontoTotalFormasPago As Decimal = Decimal.Zero

        MontoFactura = oFactura.Total

        Try
            Dim htImportesSAP As Hashtable
            Dim SaldoSAP As Decimal = 0
            Dim result As New Dictionary(Of String, Object)
            'Consultamos RFC de SAP para obtener los saldos disponibles para reembolso
            RestService = New ProcesosRetail("/pos/sh", "POST")
            RestService.Metodo = "/pos/sh"
            result = RestService.SapZshCalculoReembolsos(oPedido.Referencia, "X")
            EfectivoSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_EFECTIVO"))
            ValeCajaSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_VALECAJA"))
            FacilitoSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_FACILITO"))
            DPValeSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_DPVALE"))
            SaldoSAP = EfectivoSAP + ValeCajaSAP + FacilitoSAP + DPValeSAP
            result = Nothing
            'htImportesSAP = oSAPMgr.ZSH_CALCULO_REEMBOLSOS(oPedido.FolioSAP, "X")
            'EfectivoSAP = CDec(htImportesSAP("E_IMP_EFECTIVO"))
            'ValeCajaSAP = CDec(htImportesSAP("E_IMP_VALECAJA"))
            'FacilitoSAP = CDec(htImportesSAP("E_IMP_FACILITO"))
            'DPValeSAP = CDec(htImportesSAP("E_IMP_DPVALE"))
            'SaldoSAP = EfectivoSAP + ValeCajaSAP + FacilitoSAP + DPValeSAP
            'htImportesSAP = Nothing

            'Validamos que el importe total a devolver sea menor o igual que el saldo disponible  en sap para realizar el reembolso
            If MontoFactura > SaldoSAP AndAlso (MontoFactura - SaldoSAP) > 1 Then
                MessageBox.Show("No se puede realizar el Reembolso. El Importe Total es mayor que el Saldo disponible para reembolso." & vbCrLf & "Favor de llamar a soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                decValeCaja = 0
                decEfectivo = 0
                decDPVale = 0
                Return False
            End If

            MontoTotalFormasPago = IIf((MontoFactura - SaldoSAP) <= 1, (SaldoSAP), MontoFactura)

            'Si el cliente pide devolver en efectivo ...
            If Me.CheckDevEfectivo.Checked Then

                'Si la configuracion general de devolucion total de efectivo esta seleccionada...
                If oConfigCierreFI.DevolverEfectivoSH Then
                    'Sumamos lo que pago en efectivo con lo que pago en otras formas de pago
                    decEfectivo = EfectivoSAP + ValeCajaSAP
                Else 'De lo contrario solo devolvemos en efectivo lo que pago en esa forma de pago
                    decEfectivo = EfectivoSAP
                End If
                'Revisamos si el total a devolver es menor o igual al efectivo a devolver
                If MontoFactura <= decEfectivo Then
                    decEfectivo = MontoFactura
                    decValeCaja = 0
                    decDPVale = 0
                    'Si el total a devolver es mayor que el efectivo a devolver entonces validamos si el resto lo podemos devolver en vale de caja
                Else
                    If oConfigCierreFI.DevolverEfectivoSH = False Then
                        'si no esta activa la configuracion de devolver todo en efectivo validamos si el resto lo podemos dar en vale de caja
                        If (MontoFactura - decEfectivo) <= ValeCajaSAP Then
                            decValeCaja = MontoFactura - decEfectivo
                            decDPVale = 0
                        Else
                            'si todavia sobra el resto lo devolvemos en un revale si el cliente asi lo desea
                            decValeCaja = ValeCajaSAP
                            decDPVale = MontoFactura - decEfectivo - decValeCaja
                        End If
                    Else
                        'si la configuracion si esta activa, entonces revisamos si el total a devolver es mayor que el efectivo para devolverlo
                        'en un revale si es que el cliente asi lo desea porque ya sumamos el importe del vale de caja al efectivo
                        decValeCaja = 0
                        If MontoFactura <= decEfectivo Then
                            decEfectivo = MontoFactura
                            decDPVale = 0
                        Else
                            decDPVale = MontoFactura - decEfectivo
                        End If
                    End If
                End If

            Else 'Si no esta seleccionada la devolucion de efectivo
                decEfectivo = 0
                decValeCaja = EfectivoSAP + ValeCajaSAP
                decDPVale = DPValeSAP
                'checamos si el importe total a devolver es menor o igual que el importe en vale de caja entonces reembolsamos todo en vale de
                'caja, de lo contrario lo que se pueda en vale de caja y el resto se toma en cuenta para generar un revale
                If MontoFactura <= decValeCaja Then
                    decValeCaja = MontoFactura
                    decDPVale = 0
                Else
                    decDPVale = MontoFactura - decValeCaja
                End If
            End If

            Return True

        Catch ex As Exception
            EscribeLog(ex.ToString, "-Error al obtener las formas de pago de SAP (Insurtibles)-")
            Throw ex
        End Try

    End Function

    Private Function ReembolsoFacturasCanceladasSAP(ByVal pPedido As Pedidos, ByVal DecEfectivo As Decimal, ByVal DecValeCaja As Decimal, ByVal DecDPVale As Decimal, ByRef strDocNumEfectivo As String, ByRef strDocNumValeCaja As String) As Boolean
        Dim bResult As Boolean = False
        'Dim htDocNum As Hashtable
        'Dim oContratosMgr As ContratoManager
        'Dim division As String = "", Valor As Double
        Dim result As New Dictionary(Of String, Object)
        Try
            'oContratosMgr = New ContratoManager(oAppContext)
            'division = oContratosMgr.DivisionSel

            '--------------------------------------------------------------------------------------
            ' JNAVA (21.03.2017): Ejecutamos Nueva RFC de Reembolso de SH en SAP
            '--------------------------------------------------------------------------------------
            result = oSAPMgr.Z_MF_FYCMX1005_REEMBOLSO_SH(pPedido.FolioSAP, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, pPedido.FolioFISAP, DecDPVale)
            ''-------------------------------------------------------------------------------------------------------------------------------------
            ''Se cambio de esta manera porque martha cambio la rfc ahora nada mas le mando el folio sap de la factura
            ''Mperaza 11/07/2013
            ''-------------------------------------------------------------------------------------------------------------------------------------
            '' JNAVA (04.11.2014): Se agrego el reembolso en DPVale
            ''-------------------------------------------------------------------------------------------------------------------------------------
            ''htDocNum = oSAPMgr.ZSH_REEMBOLSO("", pPedido.ClienteID, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Canc Fact SH", "", oFactura.FolioFISAP, DecDPVale)
            'RestService.Metodo = "/pos/sh"
            'result = RestService.SapZshReembolso(pPedido.FolioPedido, pPedido.ClienteID, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Canc Fact SH", oSAPMgr.Read_Centros(), "", oFactura.FolioSAP, DecDPVale)
            ''result = ZSH_REEMBOLSO("", pPedido.ClienteID, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Canc Fact SH", "", oFactura.FolioFISAP, DecDPVale)
            ''htDocNum = oSAPMgr.ZSH_REEMBOLSO(pPedido.FolioSAP, pPedido.ClienteID, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Canc Fact SH", "", oFactura.FolioSAP)
            'oContratosMgr = Nothing
            '--------------------------------------------------------------------------------------

            If result Is Nothing Then
                Throw New Exception("Ocurrio un error al realizar el reembolso en SAP.")
            ElseIf result("SapZshReembolso")("MENSAJE") <> "" Then
                MessageBox.Show("Ocurrio un error al realizar el reembolso en SAP." & vbCrLf & "Favor de Revisar el Log de Errores.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                EscribeLog(result("SapZshReembolso")("MENSAJE"), "-Error al realizar el reembolso de una Cancelación de Pedido de Si Hay en SAP-")
                bResult = False
                Exit Try
            End If

            'Regresamos por parametro de Referencia los numeros de documentos
            strDocNumEfectivo = ""
            If DecEfectivo <> 0 Then
                strDocNumEfectivo = result("SapZshReembolso")("E_BELNR_EFECTIVO")
                If strDocNumEfectivo Is Nothing Then
                    strDocNumEfectivo = ""
                End If
            End If
            strDocNumValeCaja = ""
            If DecValeCaja <> 0 Then
                strDocNumValeCaja = result("SapZshReembolso")("E_BELNR_VALECJA")
                If strDocNumValeCaja Is Nothing Then
                    strDocNumValeCaja = ""
                End If
            End If

            bResult = True

        Catch ex As Exception
            EscribeLog(ex.ToString, "-Error al realizar el reembolso en SAP-")
            Throw ex
        End Try

        Return bResult

    End Function

#End Region

    '#Region "DP CARD"
    '    '--------------------------------------------------------------------------------------------------------------------------
    '    'FLIZARRAGA 25/02/2015: Metodo para cancelar la compra hecha con forma de pago Karum
    '    '--------------------------------------------------------------------------------------------------------------------------

    '    Private Sub CancelarPagoKarum(ByVal row As DataRow)
    '        Dim ws As New WSBroker("WS_KARUM")
    '        Dim param As New Hashtable
    '        Dim resultado As Hashtable
    '        param("NoTarjeta") = CStr(row("NumeroTarjeta"))
    '        param("Monto") = CDec(row("MontoPago"))
    '        param("Promocion") = "00"
    '        param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
    '        param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
    '        param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
    '        'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
    '        param("IDTienda") = "D393251"
    '        param("Tipo") = "00"
    '        resultado = ws.PurchaseVoid(param)

    '        '-----------------------------------------------------------------------
    '        ' JNAVA (25.02.2015): Validamos si se realizo la cancelacio o no
    '        '-----------------------------------------------------------------------
    '        Dim mensaje As String = ""
    '        If resultado.Count > 0 Then
    '            If resultado.ContainsKey("Success") = True Then
    '                If CBool(resultado("Success")) = True Then

    '                Else

    '                End If
    '            End If
    '        Else
    '            'Escribir en log?
    '            'Salirse y detener la cancelacion?
    '        End If

    '        '-----------------------------------------------------------------------------
    '        ' JNAVA (25.02.2015): Obtenemos datos de KARUM (para ticket y registros)
    '        '-----------------------------------------------------------------------------
    '        Dim htDatosDPC As Hashtable
    '        htDatosDPC = resultado

    '        '''PRUEBAS
    '        'htDatosDPC("Transaccion") = "1234"
    '        'htDatosDPC("Autorizacion") = Date.Now.ToString("ddMMyyyyHHmmss")
    '        '''PRUEBAS

    '        htDatosDPC("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
    '        htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
    '        htDatosDPC("Tarjeta") = CStr(row("NumeroTarjeta"))
    '        htDatosDPC("TarjetaHabiente") = "" 'Me.ebClienteDPC.Text
    '        htDatosDPC("Monto") = CDec(row("MontoPago"))
    '        htDatosDPC("Vendedor") = oAppContext.Security.CurrentUser.Name 'Vendedor
    '        htDatosDPC("Linea") = "EN LINEA"

    '        '-----------------------------------------------------------
    '        'JNAVA (12.03.2015): Consecutivo POS
    '        '-----------------------------------------------------------
    '        htDatosDPC("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS

    '        '-----------------------------------------------------------------------------
    '        ' JNAVA (25.02.2015): Imprimimos Vouchers de cancelacion de ventas
    '        '-----------------------------------------------------------------------------
    '        Dim oOtrosPagos As New OtrosPagos
    '        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", False, True) 'COPIA P/TIENDA
    '        oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "VTA", True, True) 'COPIA P/CLIENTE

    '    End Sub

    '#End Region
#Region "DPCard Puntos"
    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2015: Cancelar Bonificacion DPCard Puntos  cuando la factura haya sido una bonificación
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub CancelarBonificacionDPCardPuntos(ByVal factura As Factura, ByVal MontoBonificacion As Decimal, Optional ByRef impDev As Decimal = 0)
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create()
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(factura.CodVendedor, oVendedor)
        Dim Provider As Integer
        Dim params As New Hashtable
        Dim resultado As New Hashtable
        Dim CardId As String = ""
        Dim tipo_ As String = String.Empty
        'wgomez agregar validacion 13 caracteres
        If factura.NoDPCardPuntos.Trim().Length = 16 Or factura.NoDPCardPuntos.Trim().Length = 13 Then
            '06/04/2021 Validación parael servicio nuevo de blue, cuando sea True
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                    Provider = Proveedor.KARUM
                Else
                    Provider = Proveedor.BLUE
                End If
            Else
                If factura.NoDPCardPuntos.Trim().Length = 13 Then
                    tipo_ = "CFB"
                Else
                    tipo_ = consulta_bin_tipo_blue(factura.NoDPCardPuntos.Trim())
                End If
                Provider = Proveedor.BLUE
            End If

            CardId = factura.NoDPCardPuntos
        Else
            Provider = Proveedor.KARUM
            CardId = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
            'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
        End If
        '06/04/2021 validamos para consumir el servicio de blue o de karum
        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
            params("CardId") = CardId
            'params("CardId") = factura.NoDPCardPuntos
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            If Provider = Proveedor.BLUE Then
                params("Amount") = MontoBonificacion / (1 + oAppContext.ApplicationConfiguration.IVA)
                params("TotalAmount") = MontoBonificacion / (1 + oAppContext.ApplicationConfiguration.IVA)
            Else
                params("Amount") = MontoBonificacion
                params("TotalAmount") = MontoBonificacion
            End If

            params("ticketid") = factura.Referencia
            '-----------------------------------------------------------------------------
            'FLIZARRAGA 01/09/2016: Validamos nuestro proveedor de Puntos
            '-----------------------------------------------------------------------------
            If Provider = Proveedor.BLUE Then
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
            Else
                params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            End If
            'params("StoreId") = "004"
            '-----------------------------------------------------------------------------
            Select Case factura.CodTipoVenta
                Case "V"
                    params("ReferenceId3") = "CFDPV"
                Case "D"
                    params("ReferenceId3") = "DPC"
                Case Else
                    params("ReferenceId3") = "CF"
            End Select
            If Provider = Proveedor.KARUM Then
                params("ReferenceId3") = factura.CodDPCardPunto
                params("ReferenceId4") = MontoBonificacion & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            Else
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            End If

            params("SupervisorCode") = factura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = factura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            Dim product As String = ""
            Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
            Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
            Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
            Dim cantidad As Decimal = 0
            For Each row As DataRow In factura.Detalle.Tables(0).Rows
                total = 0
                unitPrice = 0
                cantidad = 0
                descSistema = 0
                descuento = 0
                '----------------------------------------------------------------------------
                'FLIZARRAGA 19/09/2018): Se corrigio los descuentos de artículos en el canje
                '----------------------------------------------------------------------------
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                total = Math.Round(CDec(row("Total")), 2)
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                total -= descSistema
                descuento = row("Descuento")
                descuento = total * (descuento / 100)
                unitPrice = total / cantidad
                unitPrice = unitPrice - (descuento / cantidad)
                unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                total = Math.Round(unitPrice * cantidad, 2)
                If Provider = Proveedor.BLUE Then
                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                Else
                    product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                End If
            Next
            params("Products") = product.Remove(product.Length - 1, 1)

            '---------------------------------------------------------------------------------------------------------
            'JNAVA (15.09.2015): Se ejecuta siempre la transaccion a ejecutar de BLUE ReturnByMoneyRegister 
            '                    para quitar los puntos asignados a la tarjeta por la compra original
            '---------------------------------------------------------------------------------------------------------
            'If factura.PedidoID = 0 Then
            '    resultado = ws.ReturnRegister(params)
            'Else
            resultado = ws.ReturnByMoneyRegister(params)
            'If Provider = Proveedor.KARUM Then
            '    ActualizarConsecutivoPuntosPOS()
            'End If
            'End If
            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultID") = True Then
                    If CInt(resultado("ResultID")) >= 0 Then
                        PrintHashtable(resultado)

                        'Obtener el Saldo y el Cliente
                        GetBalanceDPCard(oFactura)
                        resultado("CustomerName") = CustomerName
                        resultado("TotalPoints") = SaldoPuntos
                        resultado("MontoBonificacion") = MontoBonificacion

                        If Provider = Proveedor.BLUE Then
                            Dim importe As Decimal = CDec(resultado("TotalPointsInCash"))
                            If importe < 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += importe
                            End If
                        Else
                            Dim values() As String = CStr(params("ReferenceId4")).Split("-")
                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEVBON"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"
                            PrintReportPuntos(resultado)
                        End If
                    Else
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            'validamos el tipo de bin en el nuevo servicio de blue
            If tipo_.Trim() = "DB" Then
                params("CardId") = CardId
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("Amount") = MontoBonificacion / (1 + oAppContext.ApplicationConfiguration.IVA)
                params("TotalAmount") = MontoBonificacion / (1 + oAppContext.ApplicationConfiguration.IVA)
                params("ticketid") = factura.Referencia

                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen


                Select Case factura.CodTipoVenta
                    Case "V"
                        params("ReferenceId3") = "CFDPV"
                    Case "D"
                        params("ReferenceId3") = "DPC"
                    Case Else
                        params("ReferenceId3") = "CF"
                End Select

                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja


                params("SupervisorCode") = factura.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = factura.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    descSistema = 0
                    descuento = 0
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = Math.Round(unitPrice * cantidad, 2)

                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"

                Next
                params("Products") = product.Remove(product.Length - 1, 1)
                resultado = ws.ReturnByMoneyRegister(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            PrintHashtable(resultado)
                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos
                            resultado("MontoBonificacion") = MontoBonificacion
                            Dim importe As Decimal = CDec(resultado("TotalPointsInCash"))
                            If importe < 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += importe
                            End If
                            'PrintReportPuntos(resultado)
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                'falta el nuevo servicio de blue
                Dim obBlueReturnByMoney As Dictionary(Of String, Object)
                obBlueReturnByMoney = New Dictionary(Of String, Object)
                obBlueReturnByMoney.Add("cardId", CardId.Trim())
                obBlueReturnByMoney.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                obBlueReturnByMoney.Add("amount", CStr(MontoBonificacion))
                Dim totalAmount As Decimal = Math.Round(factura.Total, 2)
                obBlueReturnByMoney.Add("totalAmount", CStr(totalAmount))
                'obBlueReturnByMoney.Add("totalAmount", CStr(oFactura.Total))
                obBlueReturnByMoney.Add("ticketId", CStr(oFactura.Referencia))
                obBlueReturnByMoney.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                obBlueReturnByMoney.Add("referenceId3", "")
                obBlueReturnByMoney.Add("referenceId4", "")
                obBlueReturnByMoney.Add("version", "X")

                obBlueReturnByMoney.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("supervisorCod", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("supervisorName", CStr(oVendedor.Nombre))
                obBlueReturnByMoney.Add("sellerCode", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("sellerName", CStr(oVendedor.Nombre))
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = Math.Round(unitPrice * cantidad, 2)

                    'product &= CStr(CInt(articulo.CodArticulo)) & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    'product &= articulo.CodArticulo & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'wgomez cambio de monto totala por precio unitario
                    product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                Next
                product = product.Remove(product.Length - 1, 1)
                obBlueReturnByMoney.Add("products", CStr(product))


                Dim ws_1 As New WSBroker("blue_api_s1", "ReturnByMoneyRegister")
                Dim rs_ As Dictionary(Of String, Object)
                resultado = ws_1.nuevos_servicios_blue(obBlueReturnByMoney)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) > 0 Then
                            PrintHashtable(resultado)

                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos
                            'Dim values() As String = CStr(params("ReferenceId4")).Split("-")
                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                            params("Amount") = MontoBonificacion
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ResultID")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEVBON"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"

                            PrintReportPuntos(resultado)
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            EscribeLog("ResultID:" + CStr(resultado("ResultID")) + " " + CStr(resultado("Description")), "Cancelación de Bonificación")
                        End If
                    End If

                Else

                End If
            End If

        End If

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2015: Cancela los puntos canjeados en la factura
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub CancelarCanjeDPCardPuntos(ByVal factura As Factura, ByVal dtDetalleFormasPago As DataSet, Optional ByRef impDev As Decimal = 0, Optional ByVal tarjetaCanje As String = "")
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create()
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(factura.CodVendedor, oVendedor)
        Dim params As New Hashtable
        Dim resultado As New Hashtable
        Dim Provider As Integer
        Dim CardId As String = ""
        Dim RestarTarjeta As Decimal = GetMontoDPCardPunto()
        Dim tipo_ As String = String.Empty
        If tarjetaCanje = "" Then

            If factura.NoDPCardPuntos.Trim().Length = 16 Or factura.NoDPCardPuntos.Trim().Length = 13 Then
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Provider = Proveedor.KARUM
                    Else
                        Provider = Proveedor.BLUE
                    End If
                Else
                    Provider = Proveedor.BLUE
                    If factura.NoDPCardPuntos.Trim().Length = 13 Then
                        tipo_ = "CFB"
                    Else
                        tipo_ = consulta_bin_tipo_blue(factura.NoDPCardPuntos.Trim())
                    End If
                End If

                CardId = factura.NoDPCardPuntos
            Else
                Provider = Proveedor.KARUM
                CardId = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
                'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
            End If
        Else
            If tarjetaCanje.Trim().Length = 16 Or tarjetaCanje.Length = 13 Then
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(tarjetaCanje.Trim().Substring(0, 6))
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Provider = Proveedor.KARUM
                    Else
                        Provider = Proveedor.BLUE
                    End If
                Else
                    Provider = Proveedor.BLUE
                    If tarjetaCanje.Trim().Length = 13 Then
                        tipo_ = "CFB"
                    Else
                        tipo_ = consulta_bin_tipo_blue(tarjetaCanje.Trim())
                    End If
                End If

                CardId = tarjetaCanje
            Else
                Provider = Proveedor.KARUM
                CardId = tarjetaCanje.Trim().PadLeft(16, "0")
                'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
            End If

        End If
        Dim importe As Decimal = CDec(dtDetalleFormasPago.Tables(0).Compute("SUM(MontoPago)", ""))
        importe -= RestarTarjeta
        'validamos los nuevos servicios de blue
        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
            params("CardId") = CardId
            'params("CardId") = factura.NoDPCardPuntos
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            '---------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (30.09.2015): Enviamos en los parametros de Amount y TotalAmount de la cancelacion Canje de Puntos (BLUE) el monto con IVA
            '---------------------------------------------------------------------------------------------------------------------------------------------------
            'params("Amount") = Math.Round((importe / (oAppContext.ApplicationConfiguration.IVA + 1)), 2)
            If Provider = Proveedor.BLUE Then
                params("Amount") = importe.ToString("##,##0.00").Replace(",", "")
                params("TotalAmount") = importe.ToString("##,##0.00").Replace(",", "")
            Else
                params("Amount") = importe.ToString("##,##0.00").Replace(",", "")
                params("TotalAmount") = importe.ToString("##,##0.00").Replace(",", "")
            End If

            '-----------------------------------------------------------------------------------------------------------
            ' JNAVA (22.09.2015): se corrigio que en la cancelacion de canje de puntos se envie la fecha de la factura
            '-----------------------------------------------------------------------------------------------------------
            'params("ticketid") = factura.FolioSAP
            params("ticketid") = factura.Fecha.ToString("yyyyMMddHHmmss")
            '-----------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 01/07/2016: Validamos nuestro proveedor de puntos
            '-----------------------------------------------------------------------------------------------------------
            If Provider = Proveedor.BLUE Then
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
            Else
                params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                params("tipo") = "01"
            End If
            Select Case factura.CodTipoVenta
                Case "V"
                    params("ReferenceId3") = "CFDPV"
                Case "D"
                    params("ReferenceId3") = "DPC"
                Case Else
                    params("ReferenceId3") = "CF"
            End Select
            If Provider = Proveedor.KARUM Then
                params("ReferenceId3") = "CAN"
                Dim canje As Decimal = Me.dsFormaPago.Tables(0).Compute("SUM(MontoPago)", "CodFormasPago='DPPT'")
                Dim count As Decimal = Me.dsFormaPago.Tables(0).Rows.Count
                If count > 1 Then
                    canje = oFactura.Total - canje
                    canje -= RestarTarjeta
                    params("ReferenceId4") = canje.ToString("##,##0.00").Replace(",", "") & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                Else
                    params("ReferenceId4") = canje.ToString("##,##0.00").Replace(",", "") & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                End If
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            Else
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            End If

            params("SupervisorCode") = factura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = factura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            Dim product As String = ""
            Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
            Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
            Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
            Dim cantidad As Decimal = 0
            For Each row As DataRow In factura.Detalle.Tables(0).Rows
                total = 0
                unitPrice = 0
                cantidad = 0
                '----------------------------------------------------------------------------
                'FLIZARRAGA 19/09/2018): Se corrigio los descuentos de artículos en el canje
                '----------------------------------------------------------------------------
                total = Math.Round(CDec(row("Total")), 2)
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                total -= descSistema
                descuento = row("Descuento")
                descuento = total * (descuento / 100)
                unitPrice = total / cantidad
                unitPrice = unitPrice - (descuento / cantidad)
                unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                total = Math.Round(unitPrice * cantidad, 2)
                If Provider = Proveedor.BLUE Then
                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                Else
                    product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                End If
            Next
            params("Products") = product.Remove(product.Length - 1, 1)
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (17.09.2015): Se ejecuta la Transaccion ReturnByMoneyRegister que regresa los puntos canjeados a la tarjeta por la compra original
            '-----------------------------------------------------------------------------------------------------------------------------------------
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 25/04/2015: Valida si la factura es normal o es del si hay.
            '----------------------------------------------------------------------------------------------------------------------
            'If factura.PedidoID = 0 Then
            '    resultado = ws.ReturnRegister(params)
            'Else
            resultado = ws.ReturnByMoneyRegister(params)
            'If Provider = Proveedor.KARUM Then
            '    ActualizarConsecutivoPuntosPOS()
            'End If
            'End If
            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultID") = True Then
                    If CInt(resultado("ResultID")) >= 0 Then
                        PrintHashtable(resultado)

                        'Obtener el Saldo y el Cliente
                        GetBalanceDPCard(oFactura)
                        resultado("CustomerName") = CustomerName
                        resultado("TotalPoints") = SaldoPuntos

                        If Provider = Proveedor.BLUE Then
                            Dim saldo As Decimal = CDec(resultado("TotalPointsInCash"))
                            If saldo > 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += saldo
                            End If
                        Else
                            Dim values() As String = CStr(params("ReferenceId4")).Split("-")
                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEV"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"
                            PrintReportPuntos(resultado)
                        End If
                    Else
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            'validamos si es blue en el nuevo servicio
            If tipo_.Trim() = "DB" Then
                params("CardId") = CardId
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("Amount") = importe.ToString("##,##0.00").Replace(",", "")
                params("TotalAmount") = importe.ToString("##,##0.00").Replace(",", "")
                params("ticketid") = factura.Fecha.ToString("yyyyMMddHHmmss")


                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen

                Select Case factura.CodTipoVenta
                    Case "V"
                        params("ReferenceId3") = "CFDPV"
                    Case "D"
                        params("ReferenceId3") = "DPC"
                    Case Else
                        params("ReferenceId3") = "CF"
                End Select

                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja


                params("SupervisorCode") = factura.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = factura.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = Math.Round(unitPrice * cantidad, 2)
                    If Provider = Proveedor.BLUE Then
                        product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    Else
                        product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                    End If
                Next
                params("Products") = product.Remove(product.Length - 1, 1)
                resultado = ws.ReturnByMoneyRegister(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            PrintHashtable(resultado)

                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos


                            Dim saldo As Decimal = CDec(resultado("TotalPointsInCash"))
                            If saldo > 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += saldo
                            End If

                            'PrintReportPuntos(resultado)
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                '07/04/2021  servicio de ReturnByMoneyRegister
                Dim obBlueReturnByMoney As Dictionary(Of String, Object)
                obBlueReturnByMoney = New Dictionary(Of String, Object)
                obBlueReturnByMoney.Add("cardId", CardId.Trim())
                obBlueReturnByMoney.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                obBlueReturnByMoney.Add("amount", CStr(importe.ToString("##,##0.00").Replace(",", "")))
                Dim totalAmount As Decimal = Math.Round(factura.Total, 2)
                obBlueReturnByMoney.Add("totalAmount", CStr(totalAmount))
                'obBlueReturnByMoney.Add("totalAmount", CStr(oFactura.Total.ToString("##,##0.00").Replace(",", "")))
                obBlueReturnByMoney.Add("ticketId", CStr(oFactura.Referencia))
                obBlueReturnByMoney.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                obBlueReturnByMoney.Add("referenceId3", "")
                obBlueReturnByMoney.Add("referenceId4", "")
                obBlueReturnByMoney.Add("version", "X")

                obBlueReturnByMoney.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("supervisorCod", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("supervisorName", CStr(oVendedor.Nombre))
                obBlueReturnByMoney.Add("sellerCode", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("sellerName", CStr(oVendedor.Nombre))
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = Math.Round(unitPrice * cantidad, 2)

                    'product &= CStr(CInt(articulo.CodArticulo)) & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'wgomez cambio de monto total por precio unitario
                    product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                Next
                product = product.Remove(product.Length - 1, 1)
                obBlueReturnByMoney.Add("products", CStr(product))


                Dim ws_1 As New WSBroker("blue_api_s1", "ReturnByMoneyRegister")
                Dim rs_ As Dictionary(Of String, Object)
                resultado = ws_1.nuevos_servicios_blue(obBlueReturnByMoney)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) > 0 Then
                            PrintHashtable(resultado)

                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos

                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                            params("Amount") = importe.ToString("##,##0.00").Replace(",", "")
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja

                            resultado("ConsecutivoPOS") = CStr(resultado("ResultID")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEV"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"

                            PrintReportPuntos(resultado)
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            EscribeLog("ResultID:" + CStr(resultado("ResultID")) + " " + CStr(resultado("Description")), "Cancelación de Bonificación")
                        End If
                    End If

                Else

                End If
            End If
        End If

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/05/2014: Imprime el resultado del response
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub


    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 02/12/2016: Impresión de la devolución del Canje
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintReportPuntos(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptDPCardPuntosKarum(datos)
        With rptActivaciondpCard
            .Document.Name = "Devolucion DPCard Puntos"
            .PageSettings.PaperHeight = 7
            .PageSettings.PaperWidth = 14
            .PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
            .Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
            .Run()
        End With
        Try
            rptActivaciondpCard.Document.Print(False, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Cambio de talla"

    Private Function EsFacturaCambioTalla(ByRef Vcja As ValeCaja) As Boolean
        Dim valido As Boolean = False
        Dim rows() As DataRow = Me.dsFormaPago.Tables(0).Select("CodFormasPago='VCJA'")
        If rows.Length = 1 Then
            Dim VcjaMgr As New ValeCajaManager(oAppContext)
            Vcja = VcjaMgr.Load(CInt(rows(0)!DPValeID))
            If Vcja.Importe = Vcja.MontoUtilizado Then
                valido = True
            End If
        End If
        Return valido
    End Function

    Private Sub PrintValeCaja(ByVal Vcja As ValeCaja)
        Dim VcjaMgr As New ValeCajaManager(oAppContext)
        Vcja.StastusRegistro = True
        Vcja.DocumentoImporte = Vcja.Importe
        Vcja.MontoUtilizado = 0
        VcjaMgr.Save(Vcja)

        PrintValeCajaNC(Vcja)
    End Sub

#End Region

#Region "Correccion de Documentos en cierre de día"

    Private Sub PrintValeCajaNC(ByVal Vcja As ValeCaja)
        Dim rptValeCaja As New ValeCajaDevEfectivoNCMiniPrinter(Vcja)
        rptValeCaja.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
        Try

            rptValeCaja.Run()
        Catch ex As Exception
            EscribeLog(ex.Message, "Se produjó un error al Imprimir")
            Throw New ApplicationException("Se produjó un error al Imprimir.", ex)
        End Try

    End Sub

#End Region

#Region "Mejoras de Lealtad"

    '---------------------------------------------------------------------------------------------------------------------------
    'MLVARGAS 25/11/2019: Obtener el cliente y el saldo en puntos
    '---------------------------------------------------------------------------------------------------------------------------
    Public Sub GetBalanceDPCard(ByVal factura As Factura)
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As Date = process.MSS_GET_SY_DATE_TIME()
        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim CardId As String = ""
        Dim Provider As Integer
        'nueva variable tipo_ que trae el tipo de bin 
        Dim tipo_ As String = String.Empty

        Try
            '----------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 24/08/2016: Validamos Proveedor de puntos
            '----------------------------------------------------------------------------------------------------------------------
            If factura.NoDPCardPuntos.Trim().Length = 16 Or factura.NoDPCardPuntos.Trim().Length = 13 Then
                '06/04/2021 validación para que use el nuevo servicio de blue
                If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                    Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                    If FacturaMgr.IsDPCardPuntosKarum(bin) Then
                        Provider = Proveedor.KARUM
                    Else
                        Provider = Proveedor.BLUE
                    End If
                Else
                    If factura.NoDPCardPuntos.Trim().Length = 13 Then
                        tipo_ = "CFB"
                    Else
                        tipo_ = consulta_bin_tipo_blue(factura.NoDPCardPuntos.Trim())
                    End If
                    tipo_ = consulta_bin_tipo_blue(factura.NoDPCardPuntos.Trim())
                    Provider = Proveedor.BLUE

                End If

                CardId = factura.NoDPCardPuntos.Trim()
            Else
                Provider = Proveedor.KARUM
                CardId = factura.NoDPCardPuntos.Trim()
                'Me.txtCardID.Text = Me.txtCardID.Text.PadLeft(16, "0")
            End If
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                params("cardId") = CardId
                'params("cardId") = Me.txtCardID.Text.Trim()
                params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("ticketid") = ""
                '----------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 24/08/2016: Validamos que proveedor de Puntos es para poder asignar los valores a parametros de Webservices
                '----------------------------------------------------------------------------------------------------------------------
                If Provider = Proveedor.BLUE Then
                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                Else
                    params("storeid") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                    params("referenceId3") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("referenceId4") = oConfigCierreFI.ConsecutivoPuntosPOS
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                    ' comentado temporal MLVARGAS
                    'If Deslizada = True Then
                    '    params("tipo") = "00"
                    'Else
                    params("tipo") = "01"
                    'End If
                End If

                params("supervisorCode") = String.Empty 'CStr(Me.Params("SupervisorCode"))
                params("supervisorName") = String.Empty 'CStr(Me.Params("SupervisorName"))
                params("sellerCode") = String.Empty 'CStr(Me.Params("SellerCode"))
                params("sellerName") = String.Empty 'CStr(Me.Params("SellerName"))
                resultado = ws.GetBalance(params)

                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultId") = True Then
                        If CInt(resultado("ResultId")) > 0 Then

                            '-----------------------------------------------------------------------------
                            'MLVARGAS (25.11.2019): Tomar el valor de CustomerName retornado por el servicio
                            '-----------------------------------------------------------------------------
                            CustomerName = CStr(resultado("CustomerName"))

                            '-----------------------------------------------------------------------------
                            'JNAVA (17.11.2016): Validamos el proveedor para obtener los puntos
                            '-----------------------------------------------------------------------------
                            If Provider = Proveedor.KARUM Then
                                '-----------------------------------------------------------------------------
                                '  Validamos si los puntos y el saldo son numerico o no
                                '-----------------------------------------------------------------------------
                                If IsNumeric(resultado("SaldoPuntos").ToString.Trim) Then
                                    SaldoPuntos = CDec(resultado("SaldoPuntos")).ToString()
                                Else
                                    SaldoPuntos = 0
                                End If

                            Else
                                SaldoPuntos = CDec(resultado("BalancePoints")).ToString()
                                'Me.txtSaldo.Text = Format(CDec(resultado("BalanceAmount")), "c")
                            End If
                            '-----------------------------------------------------------------------------
                        Else
                            MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                '06/04/2021 empieza el nuevo consumo del ws de blue 
                If tipo_.Trim() = "DB" Then
                    params("cardId") = CardId
                    params("transactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                    params("ticketid") = ""
                    params("storeid") = oAppContext.ApplicationConfiguration.Almacen
                    params("referenceId3") = ""
                    params("referenceId4") = ""
                    params("cashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                    params("cashierName") = oAppContext.ApplicationConfiguration.NoCaja
                    params("supervisorCode") = String.Empty 'CStr(Me.Params("SupervisorCode"))
                    params("supervisorName") = String.Empty 'CStr(Me.Params("SupervisorName"))
                    params("sellerCode") = String.Empty 'CStr(Me.Params("SellerCode"))
                    params("sellerName") = String.Empty 'CStr(Me.Params("SellerName"))
                    resultado = ws.GetBalance(params)

                    If resultado.Count > 0 Then
                        If resultado.ContainsKey("ResultId") = True Then
                            If CInt(resultado("ResultId")) > 0 Then
                                CustomerName = CStr(resultado("CustomerName"))
                                SaldoPuntos = CDec(resultado("BalancePoints")).ToString()
                            Else
                                MessageBox.Show("Ocurrió un error al consultar el saldo de puntos." & vbCrLf & vbCrLf & CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                Else
                    Dim oBluegetBalance As Dictionary(Of String, Object)
                    oBluegetBalance = New Dictionary(Of String, Object)
                    oBluegetBalance.Add("cardId", CardId)
                    'oBluegetBalance.Add("cardId", Me.ebNumDPCard.Text.Trim())
                    oBluegetBalance.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))
                    oBluegetBalance.Add("ticketId", "")
                    oBluegetBalance.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                    oBluegetBalance.Add("referenceId3", "")
                    oBluegetBalance.Add("referenceId4", "")
                    oBluegetBalance.Add("cashierCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("supervisorCod", oAppContext.Security.CurrentUser.Name.Trim)
                    oBluegetBalance.Add("supervisorName", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerCode", oAppContext.Security.CurrentUser.ID)
                    oBluegetBalance.Add("sellerName", oAppContext.Security.CurrentUser.Name.Trim)
                    Dim ws_1 As New WSBroker("blue_api_s1", "GetBalance")
                    Dim rs_ As Dictionary(Of String, Object)
                    resultado = ws_1.nuevos_servicios_blue(oBluegetBalance)
                    If resultado.Count = 0 Then
                        MessageBox.Show("No se pudo verificar el Saldo de la tarjeta DPCard con el Centro de Crédito", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If CInt(resultado("ResultID")) > 0 Then
                            CustomerName = CStr(resultado("CustomerName"))
                            SaldoPuntos = CDec(resultado("BalancePoints")).ToString()
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End If
            
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al obtener el saldo de puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub



    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 24/04/2015: Cancelar Bonificacion DPCard Puntos  cuando la factura haya sido una bonificación
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub CancelarBonificacionByMonto(ByVal factura As Factura, ByVal dtDetalleFormasPago As DataSet, ByVal Monto As Decimal, Optional ByRef impDev As Decimal = 0)
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create()
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(factura.CodVendedor, oVendedor)
        Dim Provider As Integer
        Dim params As New Hashtable
        Dim resultado As New Hashtable
        Dim CardId As String = ""

        'variable de tipo_ para sacar el tipo de bin que se usara en el nuevo servicio de blue
        Dim tipo_ As String = String.Empty
        If factura.NoDPCardPuntos.Trim().Length = 16 Or factura.NoDPCardPuntos.Trim().Length = 13 Then
            '06/04/2021 Validación parael servicio nuevo de blue, cuando sea True
            If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
                Dim bin As Integer = CInt(factura.NoDPCardPuntos.Trim().Substring(0, 6))
                If oFacturaMgr.IsDPCardPuntosKarum(bin) Then
                    Provider = Proveedor.KARUM
                Else
                    Provider = Proveedor.BLUE
                End If
            Else
                Provider = Proveedor.BLUE
                If factura.NoDPCardPuntos.Trim().Length = 13 Then
                    tipo_ = "CFB"
                Else
                    tipo_ = consulta_bin_tipo_blue(factura.NoDPCardPuntos.Trim())
                End If
            End If

            CardId = factura.NoDPCardPuntos
        Else
            Provider = Proveedor.KARUM
            CardId = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
            'factura.NoDPCardPuntos = factura.NoDPCardPuntos.Trim().PadLeft(16, "0")
        End If
        Dim RestarTarjeta As Decimal = GetMontoDPCardPunto()
        Dim importeCan As Decimal = CDec(dtDetalleFormasPago.Tables(0).Compute("SUM(MontoPago)", ""))
        importeCan -= RestarTarjeta
        'validamos que este activo el servicio de blue en caso que no, seguiremos usandoe el viejo de karum
        If oConfigCierreFI.ServiciosBlueBonificacion = "False" Then
            params("CardId") = CardId
            'params("CardId") = factura.NoDPCardPuntos
            params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
            If Provider = Proveedor.BLUE Then
                params("Amount") = Monto
                params("TotalAmount") = Monto
            Else
                params("Amount") = Monto.ToString("##,##0.00").Replace(",", "")
                params("TotalAmount") = Monto.ToString("##,##0.00").Replace(",", "")
            End If

            params("ticketid") = factura.Referencia
            '-----------------------------------------------------------------------------
            'FLIZARRAGA 01/09/2016: Validamos nuestro proveedor de Puntos
            '-----------------------------------------------------------------------------
            If Provider = Proveedor.BLUE Then
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
            Else
                params("StoreId") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            End If
            'params("StoreId") = "004"
            '-----------------------------------------------------------------------------
            Select Case factura.CodTipoVenta
                Case "V"
                    params("ReferenceId3") = "CFDPV"
                Case "D"
                    params("ReferenceId3") = "DPC"
                Case Else
                    params("ReferenceId3") = "CF"
            End Select
            If Provider = Proveedor.KARUM Then
                params("ReferenceId3") = "BON"
                params("ReferenceId4") = CStr(Monto) & "-" & oConfigCierreFI.ConsecutivoPuntosPOS
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            Else
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
            End If

            params("SupervisorCode") = factura.CodVendedor
            params("SupervisorName") = oVendedor.Nombre
            params("SellerCode") = factura.CodVendedor
            params("SellerName") = oVendedor.Nombre
            Dim product As String = ""
            Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
            Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
            Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
            Dim cantidad As Decimal = 0
            For Each row As DataRow In factura.Detalle.Tables(0).Rows
                total = 0
                unitPrice = 0
                cantidad = 0
                descSistema = 0
                descuento = 0
                '----------------------------------------------------------------------------
                'FLIZARRAGA 19/09/2018): Se corrigio los descuentos de artículos en el canje
                '----------------------------------------------------------------------------
                total = Math.Round(CDec(row("Total")), 2)
                articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                cantidad = Math.Round(CDec(row("Cantidad")), 2)
                descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                total -= descSistema
                descuento = row("Descuento")
                descuento = total * (descuento / 100)
                unitPrice = total / cantidad
                unitPrice = unitPrice - (descuento / cantidad)
                unitPrice = unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA)
                total = unitPrice * cantidad
                If Provider = Proveedor.BLUE Then
                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                Else
                    product &= articulo.Jerarquia.Remove(0, 1) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & "-"
                End If
            Next
            params("Products") = product.Remove(product.Length - 1, 1)
            resultado = ws.ReturnByMoneyRegister(params)
            If resultado.Count > 0 Then
                If resultado.ContainsKey("ResultID") = True Then
                    If CInt(resultado("ResultID")) >= 0 Then
                        PrintHashtable(resultado)

                        'Obtener el Saldo y el Cliente
                        GetBalanceDPCard(oFactura)
                        resultado("CustomerName") = CustomerName
                        resultado("TotalPoints") = SaldoPuntos
                        resultado("MontoBonificacion") = Monto

                        If Provider = Proveedor.BLUE Then
                            Dim importe As Decimal = CDec(resultado("TotalPointsInCash"))
                            If importe < 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += importe
                            End If
                        Else
                            Dim values() As String = CStr(params("ReferenceId4")).Split("-")
                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ConsecutivoPOS")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEVBON"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"
                            PrintReportPuntos(resultado)
                        End If
                    Else
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            '06/04/2021 en caso constrario si esta activo, usaremos el nuevo servicio de blue, pero si el tipo es DB usaremos el ws de blue de distribuidor blue
            If tipo_.Trim() = "DB" Then
                params("CardId") = CardId
                'params("CardId") = factura.NoDPCardPuntos
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")

                params("Amount") = Monto
                params("TotalAmount") = Monto

                params("ticketid") = factura.Referencia
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                Select Case factura.CodTipoVenta
                    Case "V"
                        params("ReferenceId3") = "CFDPV"
                    Case "D"
                        params("ReferenceId3") = "DPC"
                    Case Else
                        params("ReferenceId3") = "CF"
                End Select

                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja


                params("SupervisorCode") = factura.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = factura.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    descSistema = 0
                    descuento = 0
                    '----------------------------------------------------------------------------
                    'FLIZARRAGA 19/09/2018): Se corrigio los descuentos de artículos en el canje
                    '----------------------------------------------------------------------------
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA)
                    total = unitPrice * cantidad

                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"

                Next
                params("Products") = product.Remove(product.Length - 1, 1)
                resultado = ws.ReturnByMoneyRegister(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            PrintHashtable(resultado)

                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos
                            resultado("MontoBonificacion") = Monto


                            Dim importe As Decimal = CDec(resultado("TotalPointsInCash"))
                            If importe < 0 AndAlso factura.PedidoID <> 0 Then
                                impDev += importe
                            End If
                            'PrintReportPuntos(resultado)
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                '06/04/2021 ASANCHEZ Falta crear el directory de returnbymoneyregister
                Dim obBlueReturnByMoney As Dictionary(Of String, Object)
                obBlueReturnByMoney = New Dictionary(Of String, Object)
                obBlueReturnByMoney.Add("cardId", CardId.Trim())
                obBlueReturnByMoney.Add("transactionDate", fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss"))

                obBlueReturnByMoney.Add("amount", CStr(Monto))
                Dim totalAmount As Decimal = Math.Round(factura.Total, 2)
                obBlueReturnByMoney.Add("totalAmount", CStr(totalAmount))
                obBlueReturnByMoney.Add("ticketId", CStr(factura.Referencia))
                obBlueReturnByMoney.Add("storeId", oAppContext.ApplicationConfiguration.Almacen)
                obBlueReturnByMoney.Add("referenceId3", "")
                obBlueReturnByMoney.Add("referenceId4", "")
                obBlueReturnByMoney.Add("version", "X")

                obBlueReturnByMoney.Add("cashierCode", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("cashierName", oAppContext.ApplicationConfiguration.NoCaja)
                obBlueReturnByMoney.Add("supervisorCod", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("supervisorName", CStr(oVendedor.Nombre))
                obBlueReturnByMoney.Add("sellerCode", CStr(factura.CodVendedor))
                obBlueReturnByMoney.Add("sellerName", CStr(oVendedor.Nombre))
                Dim product As String = ""
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0
                For Each row As DataRow In factura.Detalle.Tables(0).Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    total = Math.Round(CDec(row("Total")), 2)
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    descSistema = Math.Round(row("CantDescuentoSistema"), 2)
                    total -= descSistema
                    descuento = row("Descuento")
                    descuento = total * (descuento / 100)
                    unitPrice = total / cantidad
                    unitPrice = unitPrice - (descuento / cantidad)
                    unitPrice = Math.Round(unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA), 2)
                    total = Math.Round(unitPrice * cantidad, 2)

                    'product &= CStr(CInt(articulo.CodArticulo)) & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & "," & CStr(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'wgomez cambio de precio total por precio unitario
                    product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & unitPrice.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                    'product &= Convert.ToInt64(articulo.CodArticulo) & ",1," & Convert.ToInt32(cantidad) & "," & total.ToString("##,##0.00").Replace(",", "") & ",PZA-"
                Next
                product = product.Remove(product.Length - 1, 1)
                obBlueReturnByMoney.Add("products", CStr(product))


                Dim ws_1 As New WSBroker("blue_api_s1", "ReturnByMoneyRegister")
                Dim rs_ As Dictionary(Of String, Object)
                resultado = ws_1.nuevos_servicios_blue(obBlueReturnByMoney)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) > 0 Then
                            PrintHashtable(resultado)

                            'Obtener el Saldo y el Cliente
                            GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos

                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                            params("Amount") = Monto
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
                            '-----------------------------------------------------------
                            'FLIZARRAGA 30/10/2017: Consecutivo POS
                            '-----------------------------------------------------------
                            resultado("ConsecutivoPOS") = CStr(resultado("ResultID"))
                            resultado("TipoReporte") = "DEVBON"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"
                            PrintReportPuntos(resultado)

                            'wgomez impresion de cancelacion de canje

                            'Obtener el Saldo y el Cliente
                            'GetBalanceDPCard(oFactura)
                            resultado("CustomerName") = CustomerName
                            resultado("TotalPoints") = SaldoPuntos

                            resultado("CardId") = factura.NoDPCardPuntos.Trim()
                            resultado("NoTienda") = oAppContext.ApplicationConfiguration.Almacen
                            params("Amount") = importeCan.ToString("##,##0.00").Replace(",", "")
                            resultado("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja

                            resultado("ConsecutivoPOS") = CStr(resultado("ResultID")).PadLeft(4, "0")
                            resultado("TipoReporte") = "DEV"
                            resultado("Monto") = CDec(params("Amount")) * -1
                            resultado("tipo") = "01"

                            PrintReportPuntos(resultado)


                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            EscribeLog("ResultID:" + CStr(resultado("ResultID")) + " " + CStr(resultado("Description")), "Cancelación de Bonificación")
                        End If
                    End If

                Else

                End If
            End If
        End If

    End Sub

    Private Function GetSumaFormasPago(ByRef Log As String, ByVal dsFormasPago As DataSet, ByVal Importe As Decimal) As Decimal
        Dim AmountActivacion As Decimal = 0
        Log &= "El total de la factura es: " & CStr(Importe) & vbCrLf
        For Each row As DataRow In dsFormasPago.Tables(0).Rows
            If CStr(row("CodFormasPago")).Trim() <> "VCJA" AndAlso CStr(row("CodFormasPago")).Trim() <> "DPCA" AndAlso CStr(row("CodFormasPago")).Trim() <> "DPPT" Then
                If row("CodFormasPago") = "EFEC" Then
                    AmountActivacion += CDec(row("MontoPago"))
                Else
                    AmountActivacion += CDec(row("MontoPago"))
                End If
                Log &= "La forma de Pago " & CStr(row("CodFormasPago")) & " tiene un monto de " & CStr(row("MontoPago")) & vbCrLf
            End If
        Next
        Log &= "El total de la suma sin formas de pago VCJA,DPCA,DPPT: " & CStr(AmountActivacion) & vbCrLf
        Return AmountActivacion
    End Function

    Private Function GetMontoDPCardPunto() As Decimal
        Dim Monto As Decimal = 0
        Dim ArtMgr As New CatalogoArticuloManager(oAppContext)
        Dim Art As Articulo = ArtMgr.Create()
        Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
        Dim cantidad As Decimal = 0
        For Each RowFila As DataRow In oFactura.Detalle.Tables(0).Rows
            Art.ClearFields()
            ArtMgr.LoadInto(CStr(RowFila("CodArticulo")), Art)
            If Art.CodArtProv.Contains("CARD") Then
                total = 0
                descSistema = 0
                descuento = 0
                unitPrice = 0
                cantidad = 0
                cantidad = Math.Round(CDec(RowFila("Cantidad")), 2)
                total = Math.Round(CDec(RowFila("Total")), 2)
                cantidad = Math.Round(CDec(RowFila("Cantidad")), 2)
                descSistema = Math.Round(RowFila("CantDescuentoSistema"), 2)
                total -= descSistema
                descuento = RowFila("Descuento")
                descuento = total * (descuento / 100)
                unitPrice = total / cantidad
                unitPrice = unitPrice - (descuento / cantidad)
                unitPrice = unitPrice * (1 + oAppContext.ApplicationConfiguration.IVA)
                total = unitPrice * cantidad
                Monto += total
            End If
        Next
        Return Monto
    End Function

#End Region

End Class
