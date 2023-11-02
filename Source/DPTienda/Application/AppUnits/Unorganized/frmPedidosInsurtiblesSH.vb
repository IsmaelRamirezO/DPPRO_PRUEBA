Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
'Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports System.Collections.Generic

Public Class frmPedidosInsurtiblesSH
    Inherits System.Windows.Forms.Form

#Region " Declaración de Variables "
    Dim dtPedidos As DataTable
    Dim dtCabeceraSH As DataTable 'JNAVA 30/04/2013: Cabecera de solicitudes de los pedidos Si Hay
    Dim dtPedidosDet As DataTable
    Dim dtDetalle As DataTable

    Dim oArticulosMgr As CatalogoArticuloManager
    Dim oSAPMgr As ProcesoSAPManager
    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oAlmacen As Almacen
    Dim UserSessionAplicated As String = ""
    Dim UserNameAplicated As String = ""

    'Dim Status As String = ""
    Dim strCentroSAP As String = "" 'Mi Centro en SAP
    Dim bStatusSAP As Boolean = False

    Public bVerDevEfec As Boolean = False
    Dim oPedido As Pedidos

    Dim oClientesMgr As ClientesManager
    Dim CodCliente As String = ""
    Dim ClienteNombre As String = ""
    Private Referencia As String = ""
    Private RestService As New ProcesosRetail("", "POST")

#End Region

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
    Friend WithEvents grpDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConfirmarTraspaso As Janus.Windows.EditControls.UIButton
    Friend WithEvents grdDetallePedido As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpPedidos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuConcretarCita As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelacionDefinitiva As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuConcretarCita1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelacionDefinitiva1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents btnActualizarPedidos As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents grdPedidosInsurtibles As Janus.Windows.GridEX.GridEX
    Friend WithEvents chckDevEfec As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents nebImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebPedidoInsurtibleSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebConcretarCita As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents cmbFechaCita As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Sele As System.Windows.Forms.Label
    Friend WithEvents btnAceptarCita As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelarCita As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosInsurtiblesSH))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.chckDevEfec = New Janus.Windows.EditControls.UICheckBox()
        Me.nebImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebPedidoInsurtibleSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConfirmarTraspaso = New Janus.Windows.EditControls.UIButton()
        Me.grdDetallePedido = New Janus.Windows.GridEX.GridEX()
        Me.grpPedidos = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnActualizarPedidos = New Janus.Windows.EditControls.UIButton()
        Me.grdPedidosInsurtibles = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuConcretarCita1 = New Janus.Windows.UI.CommandBars.UICommand("menuConcretarCita")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCancelacionDefinitiva1 = New Janus.Windows.UI.CommandBars.UICommand("menuCancelacionDefinitiva")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuConcretarCita = New Janus.Windows.UI.CommandBars.UICommand("menuConcretarCita")
        Me.menuCancelacionDefinitiva = New Janus.Windows.UI.CommandBars.UICommand("menuCancelacionDefinitiva")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ebConcretarCita = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelarCita = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptarCita = New Janus.Windows.EditControls.UIButton()
        Me.cmbFechaCita = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Sele = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalle.SuspendLayout()
        CType(Me.grdDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPedidos.SuspendLayout()
        CType(Me.grdPedidosInsurtibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ebConcretarCita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ebConcretarCita.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.grpDetalle)
        Me.explorerBar1.Controls.Add(Me.grpPedidos)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(770, 370)
        Me.explorerBar1.TabIndex = 1
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpDetalle
        '
        Me.grpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.grpDetalle.Controls.Add(Me.chckDevEfec)
        Me.grpDetalle.Controls.Add(Me.nebImporteTotal)
        Me.grpDetalle.Controls.Add(Me.lblLabel1)
        Me.grpDetalle.Controls.Add(Me.ebPedidoInsurtibleSAP)
        Me.grpDetalle.Controls.Add(Me.Label2)
        Me.grpDetalle.Controls.Add(Me.btnConfirmarTraspaso)
        Me.grpDetalle.Controls.Add(Me.grdDetallePedido)
        Me.grpDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetalle.Location = New System.Drawing.Point(184, 8)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(576, 368)
        Me.grpDetalle.TabIndex = 4
        Me.grpDetalle.Text = "Detalle Pedido"
        Me.grpDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'chckDevEfec
        '
        Me.chckDevEfec.Location = New System.Drawing.Point(392, 32)
        Me.chckDevEfec.Name = "chckDevEfec"
        Me.chckDevEfec.Size = New System.Drawing.Size(176, 24)
        Me.chckDevEfec.TabIndex = 15
        Me.chckDevEfec.Text = "Devolución de Efectivo"
        Me.chckDevEfec.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.chckDevEfec.Visible = False
        Me.chckDevEfec.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'nebImporteTotal
        '
        Me.nebImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebImporteTotal.BackColor = System.Drawing.SystemColors.Info
        Me.nebImporteTotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.nebImporteTotal.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebImporteTotal.ForeColor = System.Drawing.Color.Red
        Me.nebImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebImporteTotal.Location = New System.Drawing.Point(392, 320)
        Me.nebImporteTotal.Name = "nebImporteTotal"
        Me.nebImporteTotal.ReadOnly = True
        Me.nebImporteTotal.Size = New System.Drawing.Size(176, 40)
        Me.nebImporteTotal.TabIndex = 14
        Me.nebImporteTotal.Text = "$0.00"
        Me.nebImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(264, 328)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(144, 24)
        Me.lblLabel1.TabIndex = 13
        Me.lblLabel1.Text = "Importe Total"
        Me.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ebPedidoInsurtibleSAP
        '
        Me.ebPedidoInsurtibleSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPedidoInsurtibleSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPedidoInsurtibleSAP.BackColor = System.Drawing.SystemColors.Info
        Me.ebPedidoInsurtibleSAP.Location = New System.Drawing.Point(120, 32)
        Me.ebPedidoInsurtibleSAP.Name = "ebPedidoInsurtibleSAP"
        Me.ebPedidoInsurtibleSAP.ReadOnly = True
        Me.ebPedidoInsurtibleSAP.Size = New System.Drawing.Size(128, 23)
        Me.ebPedidoInsurtibleSAP.TabIndex = 12
        Me.ebPedidoInsurtibleSAP.TabStop = False
        Me.ebPedidoInsurtibleSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebPedidoInsurtibleSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Pedido SAP"
        '
        'btnConfirmarTraspaso
        '
        Me.btnConfirmarTraspaso.Icon = CType(resources.GetObject("btnConfirmarTraspaso.Icon"), System.Drawing.Icon)
        Me.btnConfirmarTraspaso.Location = New System.Drawing.Point(8, 320)
        Me.btnConfirmarTraspaso.Name = "btnConfirmarTraspaso"
        Me.btnConfirmarTraspaso.Size = New System.Drawing.Size(216, 40)
        Me.btnConfirmarTraspaso.TabIndex = 3
        Me.btnConfirmarTraspaso.Text = "Realizar Reembolso"
        Me.btnConfirmarTraspaso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdDetallePedido
        '
        Me.grdDetallePedido.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetallePedido.DesignTimeLayout = GridEXLayout1
        Me.grdDetallePedido.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdDetallePedido.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.grdDetallePedido.GroupByBoxVisible = False
        Me.grdDetallePedido.Location = New System.Drawing.Point(8, 64)
        Me.grdDetallePedido.Name = "grdDetallePedido"
        Me.grdDetallePedido.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDetallePedido.Size = New System.Drawing.Size(560, 248)
        Me.grdDetallePedido.TabIndex = 2
        Me.grdDetallePedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grpPedidos
        '
        Me.grpPedidos.BackColor = System.Drawing.Color.Transparent
        Me.grpPedidos.Controls.Add(Me.btnActualizarPedidos)
        Me.grpPedidos.Controls.Add(Me.grdPedidosInsurtibles)
        Me.grpPedidos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPedidos.Location = New System.Drawing.Point(8, 8)
        Me.grpPedidos.Name = "grpPedidos"
        Me.grpPedidos.Size = New System.Drawing.Size(168, 368)
        Me.grpPedidos.TabIndex = 3
        Me.grpPedidos.Text = "Pedidos Insurtibles"
        Me.grpPedidos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnActualizarPedidos
        '
        Me.btnActualizarPedidos.Icon = CType(resources.GetObject("btnActualizarPedidos.Icon"), System.Drawing.Icon)
        Me.btnActualizarPedidos.Location = New System.Drawing.Point(8, 320)
        Me.btnActualizarPedidos.Name = "btnActualizarPedidos"
        Me.btnActualizarPedidos.Size = New System.Drawing.Size(152, 40)
        Me.btnActualizarPedidos.TabIndex = 5
        Me.btnActualizarPedidos.Text = "Actualizar Pedidos"
        Me.btnActualizarPedidos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdPedidosInsurtibles
        '
        Me.grdPedidosInsurtibles.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdPedidosInsurtibles.AlternatingColors = True
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdPedidosInsurtibles.DesignTimeLayout = GridEXLayout2
        Me.grdPedidosInsurtibles.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdPedidosInsurtibles.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grdPedidosInsurtibles.GroupByBoxVisible = False
        Me.grdPedidosInsurtibles.Location = New System.Drawing.Point(8, 24)
        Me.grdPedidosInsurtibles.Name = "grdPedidosInsurtibles"
        Me.grdPedidosInsurtibles.Size = New System.Drawing.Size(152, 288)
        Me.grdPedidosInsurtibles.TabIndex = 2
        Me.grdPedidosInsurtibles.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuConcretarCita, Me.menuCancelacionDefinitiva, Me.menuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("a4d070ee-9974-4182-8f4b-ea48c70c0e3e")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuConcretarCita1, Me.Separator1, Me.menuCancelacionDefinitiva1, Me.Separator2, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(163, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuConcretarCita1
        '
        Me.menuConcretarCita1.Key = "menuConcretarCita"
        Me.menuConcretarCita1.Name = "menuConcretarCita1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuCancelacionDefinitiva1
        '
        Me.menuCancelacionDefinitiva1.Key = "menuCancelacionDefinitiva"
        Me.menuCancelacionDefinitiva1.Name = "menuCancelacionDefinitiva1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuConcretarCita
        '
        Me.menuConcretarCita.Icon = CType(resources.GetObject("menuConcretarCita.Icon"), System.Drawing.Icon)
        Me.menuConcretarCita.Key = "menuConcretarCita"
        Me.menuConcretarCita.Name = "menuConcretarCita"
        Me.menuConcretarCita.Text = "Concretar Cita"
        '
        'menuCancelacionDefinitiva
        '
        Me.menuCancelacionDefinitiva.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuCancelacionDefinitiva.Icon = CType(resources.GetObject("menuCancelacionDefinitiva.Icon"), System.Drawing.Icon)
        Me.menuCancelacionDefinitiva.Key = "menuCancelacionDefinitiva"
        Me.menuCancelacionDefinitiva.Name = "menuCancelacionDefinitiva"
        Me.menuCancelacionDefinitiva.Text = "Cancelación Definitiva"
        Me.menuCancelacionDefinitiva.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(770, 28)
        '
        'ebConcretarCita
        '
        Me.ebConcretarCita.Controls.Add(Me.btnCancelarCita)
        Me.ebConcretarCita.Controls.Add(Me.btnAceptarCita)
        Me.ebConcretarCita.Controls.Add(Me.cmbFechaCita)
        Me.ebConcretarCita.Controls.Add(Me.Sele)
        Me.ebConcretarCita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Concretar Cita"
        Me.ebConcretarCita.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ebConcretarCita.Location = New System.Drawing.Point(260, 133)
        Me.ebConcretarCita.Name = "ebConcretarCita"
        Me.ebConcretarCita.Size = New System.Drawing.Size(251, 133)
        Me.ebConcretarCita.TabIndex = 17
        Me.ebConcretarCita.Text = "Concretar Cita"
        Me.ebConcretarCita.Visible = False
        Me.ebConcretarCita.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelarCita
        '
        Me.btnCancelarCita.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancelarCita.Image = CType(resources.GetObject("btnCancelarCita.Image"), System.Drawing.Image)
        Me.btnCancelarCita.Location = New System.Drawing.Point(136, 96)
        Me.btnCancelarCita.Name = "btnCancelarCita"
        Me.btnCancelarCita.Size = New System.Drawing.Size(104, 32)
        Me.btnCancelarCita.TabIndex = 14
        Me.btnCancelarCita.Text = "Cancelar"
        Me.btnCancelarCita.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptarCita
        '
        Me.btnAceptarCita.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAceptarCita.Icon = CType(resources.GetObject("btnAceptarCita.Icon"), System.Drawing.Icon)
        Me.btnAceptarCita.Location = New System.Drawing.Point(8, 96)
        Me.btnAceptarCita.Name = "btnAceptarCita"
        Me.btnAceptarCita.Size = New System.Drawing.Size(104, 32)
        Me.btnAceptarCita.TabIndex = 13
        Me.btnAceptarCita.Text = "Aceptar"
        Me.btnAceptarCita.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbFechaCita
        '
        '
        '
        '
        Me.cmbFechaCita.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaCita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaCita.Location = New System.Drawing.Point(94, 48)
        Me.cmbFechaCita.Name = "cmbFechaCita"
        Me.cmbFechaCita.Size = New System.Drawing.Size(124, 22)
        Me.cmbFechaCita.TabIndex = 1
        Me.cmbFechaCita.TodayButtonText = "Hoy"
        Me.cmbFechaCita.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Sele
        '
        Me.Sele.BackColor = System.Drawing.Color.Transparent
        Me.Sele.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Sele.Location = New System.Drawing.Point(33, 48)
        Me.Sele.Name = "Sele"
        Me.Sele.Size = New System.Drawing.Size(45, 24)
        Me.Sele.TabIndex = 12
        Me.Sele.Text = "Fecha"
        Me.Sele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPedidosInsurtiblesSH
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(770, 398)
        Me.Controls.Add(Me.ebConcretarCita)
        Me.Controls.Add(Me.explorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPedidosInsurtiblesSH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Insurtibles"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.grdDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPedidos.ResumeLayout(False)
        CType(Me.grdPedidosInsurtibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ebConcretarCita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ebConcretarCita.ResumeLayout(False)
        Me.ebConcretarCita.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Metodos y Funciones Generales "

    Private Sub Inicializar()

        dtPedidos = New DataTable("PedidosPendientes")

        oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)

        oClientesMgr = New ClientesManager(oAppContext)

        CreaEstructuraDetalle()

        Me.chckDevEfec.Checked = False

        strCentroSAP = oSAPMgr.Read_Centros

    End Sub

    Private Sub CreaEstructuraDetalle()
        Me.dtDetalle = New DataTable("Detalle")
        With Me.dtDetalle
            .Columns.Add(New DataColumn("Codigo", GetType(String)))
            .Columns.Add("CodProveedor", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add(New DataColumn("Talla", GetType(String)))
            .Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            .Columns.Add(New DataColumn("PrecioUnit", GetType(Decimal)))
            .Columns.Add(New DataColumn("Total", GetType(Decimal)))
            .AcceptChanges()
        End With
    End Sub

    Private Sub BuscarPedidosInsurtibles()

        Limpiar(False)

        Dim htStatus As Hashtable
        htStatus = New Hashtable(1)

        htStatus(1) = "IP" 'Pedidos Insurtibles

        dtPedidos = oSAPMgr.ZSH_PEDIDOS_PENDIENTES(strCentroSAP, dtCabeceraSH, dtPedidosDet, htStatus)

        Dim oCol As New DataColumn("Modificado")
        oCol.DataType = GetType(Integer)
        oCol.DefaultValue = 0
        dtPedidos.Columns.Add(oCol)
        dtPedidos.AcceptChanges()

        If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
            '------------------------------------------------------------------------------------------------------------------------------------
            'Modificamos el nombre de la columna para que coincida con el grid
            '------------------------------------------------------------------------------------------------------------------------------------
            dtPedidos.Columns("VBELN").ColumnName = "Folio_Pedido"
            dtPedidos.AcceptChanges()

            '------------------------------------------------------------------------------------------------------------------------------------
            'Eliminamos los folios duplicados
            '------------------------------------------------------------------------------------------------------------------------------------
            dtPedidos = RegistrosDuplicados(dtPedidos, "LST")

            '------------------------------------------------------------------------------------------------------------------------------------
            'Actualizamos el grid con los pedidos pendientes
            '------------------------------------------------------------------------------------------------------------------------------------
            ActualizaGridPedidosInsurtibles()

            Me.grdDetallePedido.Focus()
        Else
            MessageBox.Show("No se encontraron pedidos insurtibles.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Function RegistrosDuplicados(ByVal dt As DataTable, ByVal tipo As String) As DataTable
        '------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (07/05/2013) - Eliminamos los folios duplicados
        '------------------------------------------------------------------------------------------------------------------------------------
        Dim dtCopy As DataTable = dt.Clone
        Dim oRowV As DataRowView
        Dim oView As DataView

        For Each oRow As DataRow In dt.Rows
            If tipo = "LST" Then 'Lista de Pedidos
                oView = New DataView(dtCopy, "Folio_Pedido = '" & oRow!Folio_Pedido & "'", "", DataViewRowState.CurrentRows)
                If oView.Count <= 0 Then
                    dtCopy.ImportRow(oRow)
                End If
            ElseIf tipo = "DET" Then 'Detalle de Pedido
                Dim SumCant As Integer = 0
                oView = New DataView(dtCopy, "Codigo = '" & oRow!Codigo & _
                                             "' AND Talla = '" & oRow!Talla & "'", "", DataViewRowState.CurrentRows)
                If oView.Count >= 1 Then
                    For Each oRowV In oView
                        SumCant += CInt(oRowV!Cantidad)
                    Next
                    For Each oRowV In oView
                        oRowV!Cantidad = SumCant + oRow!Cantidad
                        oRowV!Total = oRowV!PrecioUnit * oRowV!Cantidad
                        SumCant = 0
                        Exit For
                    Next
                Else
                    dtCopy.ImportRow(oRow)
                End If
            End If
        Next

        oView = Nothing
        oRowV = Nothing

        Return dtCopy

    End Function

    Private Sub Limpiar(ByVal bDet As Boolean)
        If bDet = False Then
            If Not dtPedidos Is Nothing Then dtPedidos.Clear()
            If Not dtPedidosDet Is Nothing Then dtPedidosDet.Clear()
            ActualizaGridPedidosInsurtibles()
        End If

        If Not dtDetalle Is Nothing Then Me.dtDetalle.Clear()
        If Not oPedido Is Nothing Then oPedido = Nothing

        Me.chckDevEfec.Checked = False
        Me.ebPedidoInsurtibleSAP.Text = ""
        Me.nebImporteTotal.Value = 0

        ActualizaGridDetalle()

        UserSessionAplicated = ""
        UserNameAplicated = ""

        bStatusSAP = False

        CodCliente = ""
        ClienteNombre = ""

    End Sub

    Private Sub ActualizaGridPedidosInsurtibles()
        Me.grdPedidosInsurtibles.DataSource = Nothing
        Me.grdPedidosInsurtibles.DataSource = dtPedidos 'FiltraPedidosDiferentes(dtPedidos)
        Me.grdPedidosInsurtibles.Refresh()
    End Sub

    Private Sub ActualizaGridDetalle()
        Me.grdDetallePedido.DataSource = Nothing
        Me.grdDetallePedido.DataSource = Me.dtDetalle
        Me.grdDetallePedido.Refresh()
    End Sub

    Private Sub MostrarDetallePedido()

        Limpiar(True)

        Dim strAlm() As String

        Me.ebPedidoInsurtibleSAP.Text = CStr(CType(Me.grdPedidosInsurtibles.GetRow().DataRow, DataRowView)!Folio_Pedido).Trim.PadLeft(10, "0")
        Me.Referencia = CStr(CType(Me.grdPedidosInsurtibles.GetRow().DataRow, DataRowView)!Referencia).Trim()
        If Me.ebPedidoInsurtibleSAP.Text.Trim <> "" AndAlso CLng(Me.ebPedidoInsurtibleSAP.Text.Trim) > 0 Then
            FiltraDetalle(Me.ebPedidoInsurtibleSAP.Text.Trim)
            ActualizaGridDetalle()

            '-------------------------------------------------------------------------------------------------------------------------
            'Calculamos el Importe Total de los pedidos insurtibles
            '-------------------------------------------------------------------------------------------------------------------------
            For Each oRow As DataRow In dtDetalle.Rows
                If oRow.IsNull("Total") = False Then
                    Me.nebImporteTotal.Value += oRow!Total
                End If
            Next
        End If

    End Sub

    Private Sub FiltraDetalle(ByVal PedidoInsurtible As String)
        Dim oRow As DataRowView
        Dim oNewRow As DataRow
        Dim oView As DataView
        Dim PrecioUnitBk As Decimal = Decimal.Zero
        Dim IVA As Decimal = Decimal.Zero
        Dim Talla As String
        Dim oArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim oArticulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        oArticulo = oArticuloMgr.Create()

        '-------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 29/04/2013: Se filtra segun el Folio del Pedido Insurtible SH y obtiene el precio unitario del articulo y calcula el total
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Not ValidaFolioPedido(PedidoInsurtible.Trim) Then
            Exit Sub
        End If

        oView = New DataView(dtPedidosDet, "VBELN = '" & PedidoInsurtible.Trim & "'", "", DataViewRowState.CurrentRows)
        If oView.Count > 0 Then
            For Each oRow In oView
                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(CStr(oRow!Matnr), oArticulo)
                Talla = oRow!J_3asize 'oArticulosMgr.GetTallaByCodigo(oRow!Matnr)
                '-------------------------------------------------------------------------------------------------------------------------
                'Consultamos el detalle de cada articulo para obtener su precio unitario
                '-------------------------------------------------------------------------------------------------------------------------
                oNewRow = dtDetalle.NewRow
                With oNewRow
                    !Codigo = oRow!Matnr
                    !CodProveedor = oArticulo.CodArtProv
                    !Talla = Talla
                    !Cantidad = CInt(oRow!Insurtible)
                    !Descripcion = oArticulo.Descripcion
                    For Each pd As PedidoDetalles In oPedido.PedidosDetalles
                     
                        If pd.CodArticulo.Trim = oRow!Matnr Then
                            'Calculamos el Precio unitario de cada Articulo (con o sin descuentos)
                            PrecioUnitBk = pd.PrecioUnit - (pd.CantDescuentoSistema / pd.Cantidad)
                            PrecioUnitBk = PrecioUnitBk - (PrecioUnitBk * (pd.Descuento / 100))
                            IVA = PrecioUnitBk * oAppContext.ApplicationConfiguration.IVA
                            PrecioUnitBk = PrecioUnitBk + IVA
                            !PrecioUnit = PrecioUnitBk
                            !Total = PrecioUnitBk * CInt(oRow!Insurtible)
                        End If
                    Next
                End With
                dtDetalle.Rows.Add(oNewRow)
            Next
            dtDetalle.AcceptChanges()
        End If

        '-------------------------------------------------------------------------------------------------------------------------
        'Validamos los registros duplicados (sin tomar en cuenta solicitud) y sumamos las cantidades y totales
        '-------------------------------------------------------------------------------------------------------------------------
        dtDetalle = RegistrosDuplicados(dtDetalle, "DET")
        dtDetalle.AcceptChanges()

    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bRes As Boolean = True

        If Me.ebPedidoInsurtibleSAP.Text.Trim = "" Then
            MessageBox.Show("Debe seleccionar un Pedido Insurtible de la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Me.BuscarPedidosInsurtibles()
            bRes = False
        ElseIf Me.dtDetalle Is Nothing OrElse Me.dtDetalle.Rows.Count <= 0 Then
            MessageBox.Show("No hay códigos insurtibles.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Me.BuscarPedidosInsurtibles()
            bRes = False
            'ElseIf ValidaDetalle(dtDetalle) = False Then
            '    Me.grdDetallePedido.Focus()
            '    bRes = False
            'elseif me.cmbFechaCita.Value 
        End If

        Return bRes

    End Function

    Private Function ValidaFolioPedido(ByVal PedidoInsurtibleSAP As String) As Boolean

        Dim bRes As Boolean = True

        oPedido = Nothing
        oPedido = New Pedidos(Me.Referencia, 3)

        If oPedido Is Nothing OrElse oPedido.PedidoID = 0 Then
            MessageBox.Show("No se encontró el Pedido " & Me.ebPedidoInsurtibleSAP.Text & " en la base de datos local. Favor de llamar a Soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        Return bRes

    End Function

#End Region

#Region " Reembolso - Metodos y Funciones "

    Private Sub RealizarReembolso()

        Dim strDocNumEfectivo As String = ""
        Dim strDocNumValeCaja As String = ""
        Dim ValeCajaID As Integer = 0
        Dim Cupon As Hashtable
        Dim decToEfectivo As Decimal = Decimal.Zero
        Dim decToValeCaja As Decimal = Decimal.Zero

        '--------------------------------------------------------------------------------
        'JNAVA (28.10.2014): Agregamos Variables para DPVale
        '--------------------------------------------------------------------------------
        Dim decToReVale As Decimal = Decimal.Zero
        Dim DPValeID As String = ""
        Dim bGeneraRevale As Boolean = False
        '--------------------------------------------------------------------------------

        Try
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'Validamos que no falte ningun dato
            '-----------------------------------------------------------------------------------------------------------------------------------------
            If ValidaCampos() Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.PedidosInsurtibles", _
                                                                 "DportenisPro.DPTienda.SiHay.PedidosInsurtibles.ReembolsarPedido") Then
                    UserSessionAplicated = oAppContext.Security.CurrentUser.SessionLoginName
                    UserNameAplicated = oAppContext.Security.CurrentUser.Name
                    oAppContext.Security.CloseImpersonatedSession()

                    '----------------------------------------------------------------------------------------------------------------------------
                    'JNAVA (20/05/2013) - Revisamos las formas de pago y obtenemos los montos para ValeCaja 
                    '                     y para DevEfec pasando los datos Por Referencia desde la Funcion.
                    '-----------------------------------------------------------------------------------------------------------------------------
                    If Not ObtenerFormasPagoPedido(decToEfectivo, decToValeCaja, decToReVale) Then
                        GoTo Salir 'Si no hay formas de pago no continua
                    End If

                    '---------------------------------------------------------------------------------------------
                    'JNAVA (28/10/2014) - Preguntamos si desea Generar ReVale (Si hay saldo para Revale)
                    '---------------------------------------------------------------------------------------------
                    bGeneraRevale = PreguntaReVale(oPedido, decToReVale, DPValeID)
                    Dim devEfec As Decimal = 0
                    If Me.chckDevEfec.Checked Then
                        If decToEfectivo > 0 Then
                            DPCardPuntos(True, decToEfectivo, devEfec)
                            If decToValeCaja > 0 Then
                                decToValeCaja -= devEfec
                                DPCardPuntos(False, decToValeCaja)
                            End If
                        End If
                    Else
                        DPCardPuntos(False, decToValeCaja)
                    End If

                    '---------------------------------------------------------------------------------------------
                    'JNAVA (23/05/2013) - Realizamos los movimientos del Reembolso en los saldos del cliente en SAP
                    '---------------------------------------------------------------------------------------------
                    If Not ReembolsoPedidoInsurtibleSAP(oPedido, decToEfectivo, decToValeCaja, decToReVale, bGeneraRevale, strDocNumEfectivo, strDocNumValeCaja) Then
                        GoTo Salir
                    End If
                    '--------------------------------------------------------------------------------------
                    'JNAVA (21/05/2013) - Generamos el Vale de Caja
                    '--------------------------------------------------------------------------------------
                    If Me.chckDevEfec.Checked Then 'Resvisamos si es Devolucion de Efectivo
                        ValeCajaID = GenerarValeCaja(decToEfectivo, strDocNumEfectivo, Me.chckDevEfec.Checked)  'Devolvemos el Efectivo
                        If decToValeCaja > 0 Then 'Si no se cubrio el importe total con el Efectivo, generamos un Vale de Caja para las demas formas de pago en el pedido
                            ValeCajaID = GenerarValeCaja(decToValeCaja, strDocNumValeCaja)
                        End If
                    Else
                        ValeCajaID = GenerarValeCaja(decToValeCaja, strDocNumValeCaja, False)
                    End If
                    '---------------------------------------------------------------------------------
                    'Si se realizo el reembloso correctamente en SAP cambiamos el status del pedido
                    '---------------------------------------------------------------------------------
                    Dim refDocVale As String = ""
                    If strDocNumValeCaja.Trim() <> "" Then
                        refDocVale = strDocNumValeCaja
                    Else
                        refDocVale = strDocNumEfectivo
                    End If
                    Cupon = CambiarStatusPedido(refDocVale)
                    '----------------------------------------------------------------------------
                    'Imprimimos el cupon de descuento en caso de que se haya generado
                    '----------------------------------------------------------------------------
                    ImprimirCuponDescuento(Cupon)

                    If ValeCajaID <> 0 Then

                        If Not bStatusSAP Then
                            GoTo Salir
                        End If

                        '--------------------------------------------------------------------------------------
                        'Si se actualizo correctamente el status del pedido en SAP, activamos el vale de caja
                        '--------------------------------------------------------------------------------------
                        ActivarValeCaja(ValeCajaID)

                        MessageBox.Show("Se realizó el reembolso del Pedido Insurtible satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        EscribeLog("No se genero el vale de caja para el pedido " & oPedido.FolioSAP, "Error al generar vale de caja en Pedido SH")
                    End If

                    '-----------------------------------------------------------------------------------------------
                    'JNAVA (28.10.2014): Imprimimos el Revale (dentro valida si se imprime o no)
                    '-----------------------------------------------------------------------------------------------
                    GenerarReVale(bGeneraRevale, DPValeID, decToReVale)

                Else
                    oAppContext.Security.CloseImpersonatedSession()
                    MessageBox.Show("No se realizó el reembolso del pedido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If
Salir:
            'Actualizamos la lista de pedidos insurtibles
            BuscarPedidosInsurtibles()
            '-----------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 19/06/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay
            '-----------------------------------------------------------------------------------------------------------------------------------------
            RefreshPedidosSiHay()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GenerarValeCaja(ByVal Importe As Decimal, ByVal DocNum As String, Optional ByVal DevolverEfectivo As Boolean = False) As Integer
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA - 30/04/2013: Generamos e imprimimos el Vale de Caja a partir del Pedido con el Tipo de Documento PI (NUEVO).
        '-----------------------------------------------------------------------------------------------------------------------------------------
        Dim ValeCajaID As Integer = 0
        Try
            Dim oValeNuevo As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)
            Dim oCliente As ClienteAlterno

            '-----------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA - 05/07/2013:'Obtenemos los datos necesariso del Cliente si es de Publico en General o si es cualquier otro tipo de cliente.
            '-----------------------------------------------------------------------------------------------------------------------------------------
            oCliente = oClientesMgr.CreateAlterno
            CodCliente = ""
            ClienteNombre = ""
            If oPedido.CodTipoVenta = "P" Then
                oClientesMgr.LoadInto(CStr(oPedido.ClienteID).PadLeft(10, "0"), oCliente)
                CodCliente = oCliente.CodigoAlterno
                ClienteNombre = oCliente.NombreCompleto
            ElseIf oPedido.CodTipoVenta = "V" Then
                CodCliente = 1
                ClienteNombre = ""
            Else
                oClientesMgr.Load(CStr(oPedido.ClienteID).PadLeft(10, "0"), oCliente, oPedido.CodTipoVenta)
                CodCliente = oCliente.CodigoAlterno
                ClienteNombre = oCliente.NombreCompleto
            End If
            oCliente = Nothing
            If ClienteNombre Is Nothing Then ClienteNombre = ""
            '-----------------------------------------------------------------------------------------------------------------------------------------

            ''Asignamos el valor del Importe Total
            Dim decValeCaja As Decimal = Importe
            ''Asignamos el valor del Importe Total

            ''Generamos el vale de caja
            If decValeCaja > 0 Then
                oValeNuevo = oValeCajaMgr.Create
                oValeNuevo.CodCliente = CodCliente.PadLeft(10, "0")
                oValeNuevo.DocumentoID = oPedido.PedidoID
                oValeNuevo.DocumentoImporte = decValeCaja
                oValeNuevo.Fecha = Now
                oValeNuevo.FolioDocumento = DocNum 'IIf(DevolverEfectivo, DocNum, oPedido.FolioSAP)
                oValeNuevo.Importe = decValeCaja
                oValeNuevo.MontoUtilizado = 0.0
                oValeNuevo.Nombre = ClienteNombre
                'Lo generamos deshabilitado, asi si ocurre un error en SAP al actualizar el status del pedido, no pueda utilizarse
                oValeNuevo.StastusRegistro = False
                oValeNuevo.TipoDocumento = "PI"
                oValeNuevo.Usuario = oAppContext.Security.CurrentUser.SessionLoginName
                oValeNuevo.DevEfectivo = DevolverEfectivo
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
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al generar el Vale de Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) 'Se agrego Caption para Correccion por cambio Faamework (JNAVA - 06/11/2015)
            EscribeLog(ex.ToString, "-Error al generar el Vale de Caja-")
            ValeCajaID = 0
            'Throw ex
        End Try

        Return ValeCajaID

    End Function

    Private Sub ActivarValeCaja(ByVal ValeCajaID As Integer)
        Try
            Dim oValeCaja As ValeCaja
            Dim oValeCajaMgr As New ValeCajaManager(oAppContext)

            oValeCaja = oValeCajaMgr.Load(ValeCajaID)

            If oValeCaja.MontoUtilizado = 0 Then
                oValeCaja.StastusRegistro = True
                oValeCaja.Save()
            End If

            oValeCaja = Nothing
            oValeCajaMgr = Nothing

        Catch ex As Exception
            'MessageBox.Show("Ocurrio un error al Activar el Vale de Caja: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.ToString, "-Error al Activar el Vale de Caja con ID: " & ValeCajaID & "-")
            Throw ex
        End Try
    End Sub

    Private Function CambiarStatusPedido(ByVal ValeCajaID As String) As Hashtable
        '---------------------------------------------------------------------------------------------------------------------------------
        'JNAVA 02/05/2013: Modificamos el estatus del pedido SH en SAP
        '---------------------------------------------------------------------------------------------------------------------------------
        Dim Cupon As Hashtable
        Dim respSAP As String
        Try
            'Filtramos la dtCabeceraSH por el pedido a actualizar
            Dim oRow As DataRowView
            Dim oView As DataView
            Dim dtCabeceraSHCopy As DataTable = dtCabeceraSH.Clone

            '---------------------------------------------------------------------------------------------------------------------------
            'JNAVA 02/05/2013: Se filtra segun el Folio del Pedido Insurtible SH
            '---------------------------------------------------------------------------------------------------------------------------
            oView = New DataView(dtCabeceraSH, "VBELN = '" & Me.ebPedidoInsurtibleSAP.Text.Trim & "'", "", DataViewRowState.CurrentRows)
            If oView.Count > 0 Then
                For Each oRow In oView
                    dtCabeceraSHCopy.ImportRow(oRow.Row)
                Next
                dtCabeceraSHCopy.AcceptChanges()
            End If

            'Armamos Estructura de la Cabecera
            Dim htCabecera As New Hashtable(4)
            htCabecera("Responsable") = UserNameAplicated
            htCabecera("Traslado") = ""
            htCabecera("Pedido") = Me.ebPedidoInsurtibleSAP.Text
            htCabecera("Guia") = ""
            'htCabecera("CentroSAP") = strCentroSAP

            Cupon = oSAPMgr.ZSH_ACTUALIZAR_SOLICITUD("REEMBOLSO", htCabecera, dtCabeceraSHCopy, Nothing, Nothing, ValeCajaID, respSAP)

            If respSAP.Trim = "S" Then bStatusSAP = True

        Catch ex As Exception
            'MessageBox.Show("Ocurrio un error al actualizar status del pedido en SAP.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.ToString, "-Error al actualizar status del pedido en SAP-")
            Throw ex
        End Try

        Return Cupon

    End Function

    Private Sub ImprimirCuponDescuento(ByVal Cupon As Hashtable)
        Dim strNombre As String = ""
        Dim FechaVig As String = ""
        Dim oCupon As New CuponDescuento

        'Si el Cupon viene vacio, nos salimos para evitar excepciones
        If Cupon Is Nothing Then Exit Sub
        If CStr(Cupon.Item("FOLIO")).Trim = "" Then Exit Sub

        'Llenamos el objeto oCupon
        With oCupon
            .Descripcion = Cupon.Item("DESCRIPCION")
            .Descuento = Cupon.Item("DESCUENTO")
            'Formateamos la Fecha
            FechaVig = Cupon.Item("FIN")
            .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
            'Formateamos la Fecha
            .Folio = Cupon.Item("FOLIO")
            .LimiteDescuento = Cupon.Item("LIMITE_DESCTO")
            .Maximo = Cupon.Item("MAXIMO")
            .Minimo = Cupon.Item("MINIMO")
            .TipoDescuento = Cupon.Item("TIPO_DESCTO")
        End With

        'imprimimos de ser necesario
        Try
            If oCupon.Folio.Trim <> "" Then
                If oConfigCierreFI.MiniPrinter Then
1:                  If oPedido.CodTipoVenta <> "P" AndAlso oPedido.CodTipoVenta <> "E" Then strNombre = ClienteNombre.Trim
2:                  Dim oRpt As New rptReCupon(oCupon.Folio, oCupon.Minimo, oCupon.Descuento, oCupon.FechaVigencia, strNombre, oCupon.TipoDescuento, "CD", oCupon.LimiteDescuento)
3:                  oRpt.Document.Name = "Cupon de Descuento"
4:                  oRpt.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
5:                  oRpt.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
6:                  oRpt.Run()

7:                  Dim RepView As New ReportViewerForm
8:                  RepView.Report = oRpt
9:                  RepView.Show()

                    'oRpt.Document.Print(False, False)
                End If
            End If

            oCupon = Nothing

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el cupon de descuento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            EscribeLog(ex.ToString, "-Error al actualizar status del pedido en SAP-: Linea " & Err.Erl)
        End Try

    End Sub

    Private Function ReembolsoPedidoInsurtibleSAP(ByVal pPedido As Pedidos, ByVal DecEfectivo As Decimal, ByVal DecValeCaja As Decimal, _
                                                  ByVal decDPVale As Decimal, ByVal bReVale As Boolean, _
                                                  ByRef strDocNumEfectivo As String, ByRef strDocNumValeCaja As String) As Boolean
        '--------------------------------------------------------------------------------------
        'JNAVA (23/05/2013) - Reembolsamos el Pedido Insurtible en SAP y Validamos
        '--------------------------------------------------------------------------------------
        Dim htDocNum As Hashtable
        Dim oContratosMgr As ContratoManager
        Dim division As String = ""
        Dim bReturn As Boolean = False
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim pedido As New Pedidos(Me.Referencia, 3)

        '--------------------------------------------------------------------------------------
        'JNAVA (12/06/2013) - Se agrego el clietne correcto SAP
        '--------------------------------------------------------------------------------------
        Dim ClienteSAP As String = GetClientePedidoSH(pPedido)

        Try
            oContratosMgr = New ContratoManager(oAppContext)
            division = oContratosMgr.DivisionSel
            Dim result As Dictionary(Of String, Object)

            '--------------------------------------------------------------------------------------
            ' JNAVA (21.03.2017): Ejecutamos Nueva RFC de Reembolso de SH en SAP
            '--------------------------------------------------------------------------------------
            result = oSAPMgr.Z_MF_FYCMX1005_REEMBOLSO_SH(pPedido.FolioSAP, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, String.Empty, decDPVale, bReVale)
            'RestService = New ProcesosRetail("/pos/sh", "POST")
            'RestService.Metodo = "/pos/sh"
            'result = RestService.SapZshReembolso(pPedido.Referencia, ClienteSAP, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Insurtible", oSAPMgr.Read_Centros(), "X", "", decDPVale, bReVale)
            '--------------------------------------------------------------------------------------
            If pedido.CodTipoVenta = "V" Then

                '-----------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (08/09/2016): Si esta activo S2credit, hace la devolucion en S2Credit. Si no hace lo normal
                '-----------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.AplicarS2Credit Then

                    Dim oS2Credit As New ProcesosS2Credit

                    '---------------------------------------------------------------------------------------------
                    ' JNAVA (08.09.2016): Validamos vale en s2credit para obtener el distribuidor
                    '---------------------------------------------------------------------------------------------
                    Dim oDPVale As New cDPVale
                    oDPVale.INUMVA = pPedido.DPValeID.ToString.PadLeft(10, "0")
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)

                    '---------------------------------------------------------------------------------------------
                    ' JNAVA (08.09.2016): Validamos vale en s2credit para obtener el distribuidor
                    '---------------------------------------------------------------------------------------------
                    Dim DistribuidorID As String
                    Dim oRow As DataRow
                    oRow = oDPVale.InfoDPVALE.Rows(0)
                    DistribuidorID = CStr(oRow("KUNNR"))
                    oRow = Nothing

                    '---------------------------------------------------------------------------------------------
                    ' JNAVA (08.09.2016): Generamos Devolucion en S2Credit
                    '---------------------------------------------------------------------------------------------
                    Dim MensajeDev As String = oS2Credit.GeneraDevolucion(pPedido.DPValeID, DistribuidorID.PadLeft(10, "0"), decDPVale)
                    If MensajeDev <> String.Empty Then
                        MessageBox.Show("Ocurrio un error al grabar la devolución del DPVale en S2Credit: " & vbCrLf & vbCrLf & MensajeDev & vbCrLf & vbCrLf & ". Favor de comunicarse a Soporte.", "Cancelacion de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                Else
                    oSAPMgr.ZSH_REEMBOLSOAFS(pPedido.Referencia, ClienteSAP, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Insurtible", "X", "", decDPVale, bReVale)
                End If

            End If
            'htDocNum = oSAPMgr.ZSH_REEMBOLSO(pPedido.FolioSAP, ClienteSAP, oAppContext.ApplicationConfiguration.Almacen, DecValeCaja, DecEfectivo, division, "Insurtible", "X", "", decDPVale, bReVale)
            oContratosMgr = Nothing
            If result Is Nothing Then
                Throw New Exception("Ocurrio un error al realizar el reembolso en SAP.")
            ElseIf CStr(result("SapZshReembolso")("MENSAJE")) <> "" Then
                MessageBox.Show("Ocurrio un error al realizar el reembolso en SAP." & vbCrLf & "Favor de Revisar el Log de Errores.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                EscribeLog(CStr(result("SapZshReembolso")("MENSAJE")), "-Error al realizar el reembolso de Pedido Si Hay Insurtible en SAP-")
                bReturn = False
                Exit Try
            End If
            'If htDocNum Is Nothing Then
            '    Throw New Exception("Ocurrio un error al realizar el reembolso en SAP.")
            'ElseIf htDocNum("MENSAJE") <> "" Then
            '    MessageBox.Show("Ocurrio un error al realizar el reembolso en SAP." & vbCrLf & "Favor de Revisar el Log de Errores.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    EscribeLog(htDocNum("MENSAJE"), "-Error al realizar el reembolso de Pedido Si Hay Insurtible en SAP-")
            '    bReturn = False
            '    Exit Try
            'End If

            'Regresamos por parametro de Referencia los numeros de documentos
            If DecEfectivo <> 0 Then
                strDocNumEfectivo = CStr(result("SapZshReembolso")("E_BELNR_EFECTIVO"))
                'strDocNumEfectivo = htDocNum("E_BELNR_EFECTIVO")
            End If

            If DecValeCaja <> 0 Then
                strDocNumValeCaja = CStr(result("SapZshReembolso")("E_BELNR_VALECJA"))
                'strDocNumValeCaja = htDocNum("E_BELNR_VALECJA")
            End If

            bReturn = True

        Catch ex As Exception
            EscribeLog(ex.ToString, "-Error al realizar el reembolso en SAP (Insurtibles)-")
            Throw ex
        End Try

        Return bReturn

    End Function

    '-----------------------------------------------------------------------------------------------------
    'JNAVA (05/07/2013): Funcion Modificada para obtener formas de pago de SAP
    '-------------------------------------------------------------------------------------------------
    Private Function ObtenerFormasPagoPedido(ByRef decEfectivo As Decimal, ByRef decValeCaja As Decimal, ByRef decDPVale As Decimal) As Boolean

        'Sumatoria
        Dim EfectivoSAP As Decimal = Decimal.Zero 'Suma EFEC
        Dim ValeCajaSAP As Decimal = Decimal.Zero 'Suma Diff EFEC
        Dim FacilitoSAP As Decimal = Decimal.Zero 'Cuando hay facilito
        Dim DPValeSAP As Decimal = Decimal.Zero 'Suma DPVale *JNAVA (28/10/2014)

        Try
            Dim htImportesSAP As Hashtable
            Dim SaldoSAP As Decimal = 0
            Dim result As New Dictionary(Of String, Object)

            'Consultamos RFC de SAP para obtener los saldos disponibles para reembolso
            RestService.Metodo = "/pos/sh"
            result = RestService.SapZshCalculoReembolsos(oPedido.Referencia)
            EfectivoSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_EFECTIVO"))
            ValeCajaSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_VALECAJA"))
            FacilitoSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_FACILITO"))
            DPValeSAP = CDec(result("SapZshCalculoReembolsos")("E_IMP_DPVALE")) 'JNAVA (28/10/2014) Saldo DPVale
            SaldoSAP = EfectivoSAP + ValeCajaSAP + FacilitoSAP + DPValeSAP 'JNAVA (28/10/2014) Modificado para agregar saldo DPVale
            result = Nothing
            'htImportesSAP = oSAPMgr.ZSH_CALCULO_REEMBOLSOS(oPedido.FolioSAP)
            'EfectivoSAP = CDec(htImportesSAP("E_IMP_EFECTIVO"))
            'ValeCajaSAP = CDec(htImportesSAP("E_IMP_VALECAJA"))
            'FacilitoSAP = CDec(htImportesSAP("E_IMP_FACILITO"))
            'DPValeSAP = CDec(htImportesSAP("E_IMP_DPVALE")) 'JNAVA (28/10/2014) Saldo DPVale
            'SaldoSAP = EfectivoSAP + ValeCajaSAP + FacilitoSAP + DPValeSAP 'JNAVA (28/10/2014) Modificado para agregar saldo DPVale
            'htImportesSAP = Nothing

            'Validamos que el importe total a devolver sea menor o igual que el saldo disponible  en sap para realizar el reembolso
            If Me.nebImporteTotal.Value > SaldoSAP AndAlso (Me.nebImporteTotal.Value - SaldoSAP) > 1 Then
                MessageBox.Show("No se puede realizar el Reembolso. El Importe Total es mayor que el Saldo disponible para reembolso." & vbCrLf & "Favor de llamar a soporte.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                decValeCaja = 0
                decEfectivo = 0
                decDPVale = 0
                Return False
            End If

            Me.nebImporteTotal.Value = IIf(Me.nebImporteTotal.Value - SaldoSAP <= 1 AndAlso Me.nebImporteTotal.Value - SaldoSAP > 0, SaldoSAP, Me.nebImporteTotal.Value)

            'Si el cliente pide devolver en efectivo ...
            If Me.chckDevEfec.Checked Then

                'Si la configuracion general de devolucion total de efectivo esta seleccionada...
                If oConfigCierreFI.DevolverEfectivoSH Then
                    'Sumamos lo que pago en efectivo con lo que pago en otras formas de pago
                    decEfectivo = EfectivoSAP + ValeCajaSAP
                Else 'De lo contrario solo devolvemos en efectivo lo que pago en esa forma de pago
                    decEfectivo = EfectivoSAP
                End If
                'Revisamos si el total a devolver es menor o igual al efectivo a devolver
                If Me.nebImporteTotal.Value <= decEfectivo Then
                    decEfectivo = Me.nebImporteTotal.Value
                    decValeCaja = 0
                    decDPVale = 0
                    'Si el total a devolver es mayor que el efectivo a devolver entonces validamos si el resto lo podemos devolver en vale de caja
                Else
                    If oConfigCierreFI.DevolverEfectivoSH = False Then
                        'si no esta activa la configuracion de devolver todo en efectivo validamos si el resto lo podemos dar en vale de caja
                        If (Me.nebImporteTotal.Value - decEfectivo) <= ValeCajaSAP Then
                            decValeCaja = Me.nebImporteTotal.Value - decEfectivo
                            decDPVale = 0
                        Else
                            'si todavia sobra el resto lo devolvemos en un revale si el cliente asi lo desea
                            decValeCaja = ValeCajaSAP
                            decDPVale = Me.nebImporteTotal.Value - decEfectivo - decValeCaja
                        End If
                    Else
                        'si la configuracion si esta activa, entonces revisamos si el total a devolver es mayor que el efectivo para devolverlo
                        'en un revale si es que el cliente asi lo desea porque ya sumamos el importe del vale de caja al efectivo
                        decValeCaja = 0
                        If Me.nebImporteTotal.Value <= decEfectivo Then
                            decEfectivo = Me.nebImporteTotal.Value
                            decDPVale = 0
                        Else
                            decDPVale = Me.nebImporteTotal.Value - decEfectivo
                        End If
                    End If
                End If

            Else 'Si no esta seleccionada la devolucion de efectivo
                decEfectivo = 0
                decValeCaja = EfectivoSAP + ValeCajaSAP
                decDPVale = DPValeSAP
                'checamos si el importe total a devolver es menor o igual que el importe en vale de caja entonces reembolsamos todo en vale de
                'caja, de lo contrario lo que se pueda en vale de caja y el resto se toma en cuenta para generar un revale
                If Me.nebImporteTotal.Value <= decValeCaja Then
                    decValeCaja = Me.nebImporteTotal.Value
                    decDPVale = 0
                Else
                    decDPVale = Me.nebImporteTotal.Value - decValeCaja
                End If
            End If

            Return True

        Catch ex As Exception
            EscribeLog(ex.ToString, "-Error al obtener las formas de pago de SAP (Insurtibles)-")
            Throw ex
        End Try

    End Function

    '-----------------------------------------------------------------------------------------------------
    'JNAVA (27/10/2013): Generamos ReVale de Insurtible
    '-------------------------------------------------------------------------------------------------
    Private Function GenerarReVale(ByVal GeneraReVale As Boolean, ByVal DPValeID As String, ByVal MontoDPVL As Decimal) As Boolean

        Dim ReValeID As String = ""
        Dim strResult As String = ""

        'Validamos que se vaya a generar Revale
        If GeneraReVale Then

            Try

                '--------------------------------------------------------------------------------------------
                ' JNAVA (20.07.2016): Genera ReVale en S2Credit o en SAP si esta activa la Configuracion 
                '--------------------------------------------------------------------------------------------
                ''Generamos el ReeVale en SAP
                'ReValeID = oSAPMgr.ZBAPI_GENERAR_REVALE(DPValeID, MontoDPVL, strResult)

                '--------------------------------------------------------------------------------------------
                ' JNAVA (20.07.2016): Generamos Revale 
                '--------------------------------------------------------------------------------------------
                Dim oS2Credit As New ProcesosS2Credit
                If oConfigCierreFI.AplicarS2Credit Then

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (20.07.2016): Valida DPVale en S2Credit para obtener cliente
                    '----------------------------------------------------------------------------------------
                    Dim oDPVale As New cDPVale
                    oDPVale.INUMVA = DPValeID
                    oDPVale = oS2Credit.ValidaDPVale(oDPVale, Nothing, String.Empty)

                    '----------------------------------------------------------------------------------------
                    ' JNAVA (20.07.2016): Generamos DPVale en S2Credit 
                    '----------------------------------------------------------------------------------------
                    ReValeID = oS2Credit.GeneraReVale(DPValeID, CStr(oDPVale.InfoDPVALE.Rows(0).Item("CODCT")).PadLeft(10, "0"), MontoDPVL, strResult)

                Else

                    ReValeID = oSAPMgr.ZBAPI_GENERAR_REVALE(DPValeID, MontoDPVL, strResult)

                End If
                '--------------------------------------------------------------------------------------------

                'Validamos Resultados
                Select Case strResult

                    Case "S"
                        ImprimeRevale(ReValeID, MontoDPVL)
                    Case "N"
                        MessageBox.Show("El REVALE no se genero en SAP, por que no existe Vale Origen", "No existe Vale Origen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case "E"
                        MessageBox.Show("El REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Case Else
                        MessageBox.Show("El REVALE no se genero en SAP ", "No se pudo generar el revale", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Select

            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al generar el Revale cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "-Error al generar el Revale de Venta con DPVale-")
            End Try

        End If

    End Function

    '-----------------------------------------------------------------------------------------------------
    'JNAVA (28/10/2013): Imprimimos ReVale de Insurtible
    '-------------------------------------------------------------------------------------------------
    Private Sub ImprimeRevale(ByVal FolioReVale As String, ByVal MontoRevale As Decimal)

        Dim ofrmPago As New frmPago

        ofrmPago.InitializeObjects()
        ofrmPago.InitializeObjectsSAP()
        ofrmPago.owsDPValeInfo = New DportenisPro.DPTienda.ApplicationUnits.ProcesosAU.ControlDPValesWS.DPValeInfo
        ofrmPago.owsDPValeInfo.MontoDPValeI = MontoRevale

        Dim oDPVale As New cDPVale
        oDPVale.INUMVA = CStr(Convert.ToInt32(FolioReVale)).PadLeft(10, "0")
        oDPVale.I_RUTA = "X"

        '----------------------------------------------------------------------------------------
        ' JNAVA (15.07.2016): Valida DPVale en S2Credit o en SAP si esta activa la Configuracion 
        '----------------------------------------------------------------------------------------
        'oDPVale = ofrmPago.oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

        '----------------------------------------------------------------------------------------
        ' JNAVA (15.07.2016): Valida DPVale
        '----------------------------------------------------------------------------------------
        Dim oS2Credit As New ProcesosS2Credit
        Dim FirmaDistribuidor As Image = Nothing
        Dim NombreDistribuidor As String = String.Empty

        If oConfigCierreFI.AplicarS2Credit Then
            oDPVale = oS2Credit.ValidaDPVale(oDPVale, FirmaDistribuidor, NombreDistribuidor)
        Else
            oDPVale = ofrmPago.oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
        End If
        '----------------------------------------------------------------------------------------

        oDPVale.I_RUTA = oConfigCierreFI.Ruta & "\Firmas\" & CStr(Convert.ToInt32(FolioReVale)).PadLeft(10, "0") & ".bmp"

        Dim oRow As DataRow
        oRow = oDPVale.InfoDPVALE.Rows(0)
        Dim DPValeInfo As New DevolucionDPValeInfo()
        DPValeInfo.DPValeOrigen = oRow("Orige")
        DPValeInfo.FechaExpedicion = Now
        DPValeInfo.FechaEntregado = Now
        DPValeInfo.FacturaId = 0
        DPValeInfo.MontoDPValeUtilizado = 0
        DPValeInfo.MontoDPValeP = 0
        DPValeInfo.DPValeID = FolioReVale
        DPValeInfo.AsociadoID = oRow("KUNNR")
        DPValeInfo.ClienteAsociadoID = oRow("CODCT")

        'ofrmPago.owsDPValeInfo.DPValeOrigen = oRow("Orige")
        ofrmPago.owsDPValeInfo.FechaExpedicion = Now.ToShortDateString
        ofrmPago.owsDPValeInfo.FechaEntregado = Now.ToShortDateString
        ofrmPago.owsDPValeInfo.FacturaID = 0
        ofrmPago.owsDPValeInfo.MontoUtilizado = 0
        ofrmPago.owsDPValeInfo.MontoDPValeP = 0
        ofrmPago.vSobrante = MontoRevale
        ofrmPago.owsDPValeInfo.DPValeID = Convert.ToInt32(FolioReVale)
        ofrmPago.owsDPValeInfo.AsociadoID = oRow("KUNNR")
        ofrmPago.owsDPValeInfo.ClienteAsociadoID = oRow("CODCT")

        ofrmPago.PrintRevale(DPValeInfo, NombreDistribuidor, FirmaDistribuidor)
        ofrmPago.Dispose()
        ofrmPago = Nothing

    End Sub

    '-----------------------------------------------------------------------------------------------------
    'JNAVA (28/10/2013): Imprimimos ReVale de Insurtible
    '-------------------------------------------------------------------------------------------------
    Private Function PreguntaReVale(ByVal oPedido As Pedidos, ByVal MontoDPVL As Decimal, ByRef DPValeID As String) As Boolean

        'Dim ReValeID As String = ""
        Dim strResult As String = ""
        Dim bResult As Boolean = False

        'Validamos que se vaya a generar Revale
        If oPedido.CodTipoVenta = "V" Then

            'Validamos que el tipo de Venta sea con DPVale
            If MontoDPVL > 0 Then

                Try
                    'Obtenemos el folio del vale de las Formas de pago del Pedido
                    For Each oRow As DataRow In oPedido.FormasPago.Rows
                        If oRow!CodFormasPago = "DPVL" Then
                            DPValeID = CStr(oRow!DPValeID)
                        End If
                    Next

                    If DPValeID = "" Then Exit Function

                    'Preguntamos si desea Generar el Rerevale
                    If MessageBox.Show("El Cliente cuenta con saldo de $" & MontoDPVL & " para Generar un Revale." & vbCrLf & "¿Desea generarlo?", "Imprimir ReVale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        bResult = True

                    End If

                Catch ex As Exception
                    MessageBox.Show("Ocurrio un error al generar el Revale cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(ex.ToString, "-Error al generar el Revale de Venta con DPVale-")
                End Try

            End If

        End If

        Return bResult

    End Function

#End Region

#Region " Concretar Citas - Metodos y Funciones "

    Private Sub PantallaConcretarCita(ByVal Mostrar As Boolean)

        'Des/habilitamos el fondo
        Me.grpPedidos.Enabled = Not Mostrar
        Me.grpDetalle.Enabled = Not Mostrar

        'Mostramos/quitamos el ExplorerBar de Concretar cita
        If Mostrar Then
            Me.ebConcretarCita.Location = New Point(260, 133)
        Else
            Me.ebConcretarCita.Location = New Point(424, 392)
        End If
        Me.ebConcretarCita.Visible = Mostrar

        Me.cmbFechaCita.Value = Date.Now

    End Sub

    '--------------------------------------------------------------------------------------------
    'JNAVA (20/05/2013) - Concretar Cita del cliente para el pedido insurtible
    '--------------------------------------------------------------------------------------------
    Private Sub ConcretarCita()

        If ValidaFolioPedido(Me.ebPedidoInsurtibleSAP.Text.Trim) Then
            Try
                If Me.cmbFechaCita.Value < Date.Now Then
                    MessageBox.Show("La Fecha debe ser mayor que la Fecha Actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbFechaCita.Focus()
                    Exit Sub
                ElseIf Me.cmbFechaCita.Value > Date.Now.AddDays(oConfigCierreFI.DiasPostergarCitaSH) Then
                    MessageBox.Show("La Fecha ingresada no debe ser mayor que " & Date.Now.AddDays(oConfigCierreFI.DiasPostergarCitaSH) & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cmbFechaCita.Focus()
                    Exit Sub
                Else
                    Me.oClientesMgr.SaveConcretarCitaSH(Me.ebPedidoInsurtibleSAP.Text, Me.cmbFechaCita.Value)
                    MessageBox.Show("Se guardó la cita con el cliente satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al concretar la cita. Favor de revisar el Log de Errores", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EscribeLog(ex.ToString, "-Error al concretar cita con el cliente-")
            End Try
            PantallaConcretarCita(False)
            Limpiar(True)
        End If
    End Sub

#End Region

#Region " Eventos "

    Private Sub frmPedidosInsurtiblesSH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnActualizarPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarPedidos.Click
        BuscarPedidosInsurtibles()
    End Sub

    Private Sub frmPedidosInsurtiblesSH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bVerDevEfec Then
            Me.chckDevEfec.Visible = True
        Else
            Me.chckDevEfec.Visible = False
        End If
        BuscarPedidosInsurtibles()
    End Sub

    Private Sub grdPedidosInsurtibles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPedidosInsurtibles.DoubleClick
        If Not dtPedidos Is Nothing AndAlso dtPedidos.Rows.Count > 0 Then
            MostrarDetallePedido()
        End If
    End Sub

    Private Sub btnConfirmarTraspaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmarTraspaso.Click
        RealizarReembolso()
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case (e.Command.Key)

            Case "menuConcretarCita"

                '-----------------------------------------------------------------------------------------------------------------------------------------
                'Validamos que no falte ningun dato para poder mostrar la pantalla de Concretar Cita
                '-----------------------------------------------------------------------------------------------------------------------------------------
                If ValidaCampos() Then
                    PantallaConcretarCita(True)
                End If

            Case "menuCancelacionDefinitiva"


            Case "menuSalir"
                Me.Close()

        End Select

    End Sub

    Private Sub btnCancelarCita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarCita.Click
        PantallaConcretarCita(False)
    End Sub

    Private Sub btnAceptarCita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarCita.Click
        ConcretarCita()
    End Sub

#End Region

#Region "DPCard Puntos"

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2015: Verifica si tiene puntos DPCard Puntos el pedido a cancelar
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub DPCardPuntos(ByVal efectivo As Boolean, ByRef Importe As Decimal, Optional ByRef importeDev As Decimal = 0)
        If oConfigCierreFI.DPCardPuntos = True Then
            Dim pedido As New Pedidos(ebPedidoInsurtibleSAP.Text.Trim(), 2)
            If pedido.NoDPCardPuntos <> "" AndAlso pedido.CodDPCardPunto = "CAN" Then
                Dim ws As New WSBroker("WS_BLUE", True)
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim ArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
                Dim articulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
                Dim total As Decimal = 0, descSistema As Decimal = 0, descuento As Decimal = 0, unitPrice As Decimal = 0
                Dim cantidad As Decimal = 0, FacturaID As Integer
                Dim oVendedoresMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
                Dim oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor = oVendedoresMgr.Create()
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(pedido.CodVendedor, oVendedor)
                Dim resultado As Hashtable
                Dim params As Hashtable
                params("CardId") = pedido.NoDPCardPuntos
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("Amount") = Importe
                params("TotalAmount") = Importe
                params("ticketid") = pedido.FolioSAP
                '-----------------------------------------------------------------------------
                'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                'params("StoreId") = "004"
                '-----------------------------------------------------------------------------
                Select Case pedido.CodTipoVenta
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
                params("SupervisorCode") = pedido.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = pedido.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                For Each row As DataRow In pedido.ArticulosNoFacturados.Rows
                    total = 0
                    unitPrice = 0
                    cantidad = 0
                    articulo = ArticuloMgr.Load(CStr(row("CodArticulo")))
                    cantidad = Math.Round(CDec(row("Cantidad")), 2)
                    unitPrice = Math.Round(CDec(row("PrecioUnit")), 2)
                    'unitPrice = total / cantidad
                    product &= articulo.Jerarquia & "|1|" & CStr(cantidad) & "|" & CStr(unitPrice) & "|PZA|"
                Next
                params("Products") = product.Remove(product.Length - 1, 1)
                If efectivo = True Then
                    resultado = ws.ReturnByMoneyRegister(params)
                Else
                    resultado = ws.ReturnRegister(params)
                End If
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then
                            Dim totalCash As Decimal = CDec(resultado("TotalPointsInCash"))
                            If totalCash < 0 AndAlso efectivo = True Then
                                importeDev = totalCash
                            End If
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

#End Region

End Class
