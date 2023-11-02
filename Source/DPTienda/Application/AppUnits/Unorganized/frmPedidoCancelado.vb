Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CancelaFacturaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class frmPedidoCancelado
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents MenuPedidoCancelado As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuAbrirPedido As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAbrirPedido1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents expPedidoCancelado As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents groupPedido As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents NumericEditBox1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPedidoSAP As System.Windows.Forms.Label
    Friend WithEvents txtFolioSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolioPedido As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtClientePedido As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtClientePedidoDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPlayerPedido As System.Windows.Forms.Label
    Friend WithEvents txtCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents grpDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gridPedidos As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents MnuCancelar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCancelar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents txtImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebSubtotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nebIVA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoCancelado))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.MenuPedidoCancelado = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuAbrirPedido1 = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrirPedido")
        Me.MnuCancelar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelar")
        Me.MnuAbrirPedido = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrirPedido")
        Me.MnuCancelar = New Janus.Windows.UI.CommandBars.UICommand("MnuCancelar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.expPedidoCancelado = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grpDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.nebIVA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nebSubtotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.gridPedidos = New Janus.Windows.GridEX.GridEX()
        Me.groupPedido = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPlayerPedido = New System.Windows.Forms.Label()
        Me.txtClientePedidoDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtClientePedido = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtFolioPedido = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolioSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPedidoSAP = New System.Windows.Forms.Label()
        Me.NumericEditBox1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.MenuPedidoCancelado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.expPedidoCancelado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expPedidoCancelado.SuspendLayout()
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalle.SuspendLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPedido.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPedidoCancelado
        '
        Me.MenuPedidoCancelado.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuPedidoCancelado.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuPedidoCancelado.AllowMerge = False
        Me.MenuPedidoCancelado.BottomRebar = Me.BottomRebar1
        Me.MenuPedidoCancelado.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.MenuPedidoCancelado.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuAbrirPedido, Me.MnuCancelar})
        Me.MenuPedidoCancelado.ContainerControl = Me
        '
        '
        '
        Me.MenuPedidoCancelado.EditContextMenu.Key = ""
        Me.MenuPedidoCancelado.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.MenuPedidoCancelado.LeftRebar = Me.LeftRebar1
        Me.MenuPedidoCancelado.LockCommandBars = True
        Me.MenuPedidoCancelado.RightRebar = Me.RightRebar1
        Me.MenuPedidoCancelado.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuPedidoCancelado.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MenuPedidoCancelado.ShowQuickCustomizeMenu = False
        Me.MenuPedidoCancelado.TopRebar = Me.TopRebar1
        Me.MenuPedidoCancelado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.MenuPedidoCancelado
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.MenuPedidoCancelado
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuAbrirPedido1, Me.MnuCancelar1})
        Me.UiCommandBar1.Key = "tbPedidoCancelado"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(205, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuAbrirPedido1
        '
        Me.MnuAbrirPedido1.Image = CType(resources.GetObject("MnuAbrirPedido1.Image"), System.Drawing.Image)
        Me.MnuAbrirPedido1.Key = "MnuAbrirPedido"
        Me.MnuAbrirPedido1.Name = "MnuAbrirPedido1"
        '
        'MnuCancelar1
        '
        Me.MnuCancelar1.Image = CType(resources.GetObject("MnuCancelar1.Image"), System.Drawing.Image)
        Me.MnuCancelar1.Key = "MnuCancelar"
        Me.MnuCancelar1.Name = "MnuCancelar1"
        Me.MnuCancelar1.Text = "Cancelar Pedido"
        '
        'MnuAbrirPedido
        '
        Me.MnuAbrirPedido.Key = "MnuAbrirPedido"
        Me.MnuAbrirPedido.Name = "MnuAbrirPedido"
        Me.MnuAbrirPedido.Text = "Abrir Pedido"
        '
        'MnuCancelar
        '
        Me.MnuCancelar.Key = "MnuCancelar"
        Me.MnuCancelar.Name = "MnuCancelar"
        Me.MnuCancelar.Text = "Cancelar"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.MenuPedidoCancelado
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.MenuPedidoCancelado
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.MenuPedidoCancelado
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(690, 28)
        '
        'expPedidoCancelado
        '
        Me.expPedidoCancelado.Controls.Add(Me.grpDetalle)
        Me.expPedidoCancelado.Controls.Add(Me.groupPedido)
        Me.expPedidoCancelado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expPedidoCancelado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expPedidoCancelado.ForeColor = System.Drawing.Color.Black
        Me.expPedidoCancelado.Location = New System.Drawing.Point(0, 28)
        Me.expPedidoCancelado.Name = "expPedidoCancelado"
        Me.expPedidoCancelado.Size = New System.Drawing.Size(690, 412)
        Me.expPedidoCancelado.TabIndex = 0
        Me.expPedidoCancelado.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grpDetalle
        '
        Me.grpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.grpDetalle.Controls.Add(Me.nebIVA)
        Me.grpDetalle.Controls.Add(Me.Label2)
        Me.grpDetalle.Controls.Add(Me.nebSubtotal)
        Me.grpDetalle.Controls.Add(Me.Label1)
        Me.grpDetalle.Controls.Add(Me.txtImporteTotal)
        Me.grpDetalle.Controls.Add(Me.lblLabel1)
        Me.grpDetalle.Controls.Add(Me.gridPedidos)
        Me.grpDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetalle.ForeColor = System.Drawing.Color.Black
        Me.grpDetalle.Location = New System.Drawing.Point(8, 136)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(672, 288)
        Me.grpDetalle.TabIndex = 5
        Me.grpDetalle.Text = "Detalle Pedido"
        Me.grpDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nebIVA
        '
        Me.nebIVA.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebIVA.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebIVA.BackColor = System.Drawing.SystemColors.Info
        Me.nebIVA.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.nebIVA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebIVA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nebIVA.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebIVA.Location = New System.Drawing.Point(248, 232)
        Me.nebIVA.Name = "nebIVA"
        Me.nebIVA.ReadOnly = True
        Me.nebIVA.Size = New System.Drawing.Size(104, 22)
        Me.nebIVA.TabIndex = 18
        Me.nebIVA.Text = "$0.00"
        Me.nebIVA.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebIVA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(208, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 24)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "IVA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nebSubtotal
        '
        Me.nebSubtotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebSubtotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebSubtotal.BackColor = System.Drawing.SystemColors.Info
        Me.nebSubtotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.nebSubtotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebSubtotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nebSubtotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nebSubtotal.Location = New System.Drawing.Point(96, 232)
        Me.nebSubtotal.Name = "nebSubtotal"
        Me.nebSubtotal.ReadOnly = True
        Me.nebSubtotal.Size = New System.Drawing.Size(104, 22)
        Me.nebSubtotal.TabIndex = 16
        Me.nebSubtotal.Text = "$0.00"
        Me.nebSubtotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebSubtotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 24)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "SubTotal"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtImporteTotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtImporteTotal.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.Red
        Me.txtImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtImporteTotal.Location = New System.Drawing.Point(472, 232)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(192, 40)
        Me.txtImporteTotal.TabIndex = 14
        Me.txtImporteTotal.Text = "$0.00"
        Me.txtImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Black
        Me.lblLabel1.Location = New System.Drawing.Point(360, 232)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(120, 24)
        Me.lblLabel1.TabIndex = 13
        Me.lblLabel1.Text = "Importe Total"
        Me.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gridPedidos
        '
        Me.gridPedidos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridPedidos.DesignTimeLayout = GridEXLayout1
        Me.gridPedidos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridPedidos.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.gridPedidos.GroupByBoxVisible = False
        Me.gridPedidos.Location = New System.Drawing.Point(16, 24)
        Me.gridPedidos.Name = "gridPedidos"
        Me.gridPedidos.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.gridPedidos.Size = New System.Drawing.Size(648, 200)
        Me.gridPedidos.TabIndex = 2
        Me.gridPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'groupPedido
        '
        Me.groupPedido.BackColor = System.Drawing.Color.Transparent
        Me.groupPedido.Controls.Add(Me.txtPlayerDescripcion)
        Me.groupPedido.Controls.Add(Me.txtCodVendedor)
        Me.groupPedido.Controls.Add(Me.lblPlayerPedido)
        Me.groupPedido.Controls.Add(Me.txtClientePedidoDescripcion)
        Me.groupPedido.Controls.Add(Me.txtClientePedido)
        Me.groupPedido.Controls.Add(Me.lblCliente)
        Me.groupPedido.Controls.Add(Me.txtFolioPedido)
        Me.groupPedido.Controls.Add(Me.lblFolio)
        Me.groupPedido.Controls.Add(Me.txtFolioSAP)
        Me.groupPedido.Controls.Add(Me.lblPedidoSAP)
        Me.groupPedido.Controls.Add(Me.NumericEditBox1)
        Me.groupPedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupPedido.Location = New System.Drawing.Point(8, 8)
        Me.groupPedido.Name = "groupPedido"
        Me.groupPedido.Size = New System.Drawing.Size(672, 120)
        Me.groupPedido.TabIndex = 6
        Me.groupPedido.Text = "Pedido"
        Me.groupPedido.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtPlayerDescripcion
        '
        Me.txtPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.txtPlayerDescripcion.Location = New System.Drawing.Point(160, 88)
        Me.txtPlayerDescripcion.Name = "txtPlayerDescripcion"
        Me.txtPlayerDescripcion.ReadOnly = True
        Me.txtPlayerDescripcion.Size = New System.Drawing.Size(304, 23)
        Me.txtPlayerDescripcion.TabIndex = 24
        Me.txtPlayerDescripcion.TabStop = False
        Me.txtPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCodVendedor
        '
        Me.txtCodVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodVendedor.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodVendedor.Location = New System.Drawing.Point(64, 88)
        Me.txtCodVendedor.Name = "txtCodVendedor"
        Me.txtCodVendedor.ReadOnly = True
        Me.txtCodVendedor.Size = New System.Drawing.Size(88, 23)
        Me.txtCodVendedor.TabIndex = 23
        Me.txtCodVendedor.TabStop = False
        Me.txtCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPlayerPedido
        '
        Me.lblPlayerPedido.AutoSize = True
        Me.lblPlayerPedido.Location = New System.Drawing.Point(8, 88)
        Me.lblPlayerPedido.Name = "lblPlayerPedido"
        Me.lblPlayerPedido.Size = New System.Drawing.Size(49, 16)
        Me.lblPlayerPedido.TabIndex = 22
        Me.lblPlayerPedido.Text = "Player"
        '
        'txtClientePedidoDescripcion
        '
        Me.txtClientePedidoDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtClientePedidoDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtClientePedidoDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.txtClientePedidoDescripcion.Location = New System.Drawing.Point(160, 56)
        Me.txtClientePedidoDescripcion.Name = "txtClientePedidoDescripcion"
        Me.txtClientePedidoDescripcion.ReadOnly = True
        Me.txtClientePedidoDescripcion.Size = New System.Drawing.Size(358, 23)
        Me.txtClientePedidoDescripcion.TabIndex = 21
        Me.txtClientePedidoDescripcion.TabStop = False
        Me.txtClientePedidoDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtClientePedidoDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtClientePedido
        '
        Me.txtClientePedido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtClientePedido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtClientePedido.BackColor = System.Drawing.SystemColors.Info
        Me.txtClientePedido.Location = New System.Drawing.Point(64, 56)
        Me.txtClientePedido.Name = "txtClientePedido"
        Me.txtClientePedido.ReadOnly = True
        Me.txtClientePedido.Size = New System.Drawing.Size(88, 23)
        Me.txtClientePedido.TabIndex = 20
        Me.txtClientePedido.TabStop = False
        Me.txtClientePedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtClientePedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(8, 56)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(57, 16)
        Me.lblCliente.TabIndex = 19
        Me.lblCliente.Text = "Cliente:"
        '
        'txtFolioPedido
        '
        Me.txtFolioPedido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioPedido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioPedido.BackColor = System.Drawing.SystemColors.Info
        Me.txtFolioPedido.Location = New System.Drawing.Point(64, 24)
        Me.txtFolioPedido.Name = "txtFolioPedido"
        Me.txtFolioPedido.ReadOnly = True
        Me.txtFolioPedido.Size = New System.Drawing.Size(88, 23)
        Me.txtFolioPedido.TabIndex = 18
        Me.txtFolioPedido.TabStop = False
        Me.txtFolioPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFolioPedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(8, 24)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(41, 16)
        Me.lblFolio.TabIndex = 17
        Me.lblFolio.Text = "Folio:"
        '
        'txtFolioSAP
        '
        Me.txtFolioSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolioSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolioSAP.BackColor = System.Drawing.SystemColors.Info
        Me.txtFolioSAP.Location = New System.Drawing.Point(336, 24)
        Me.txtFolioSAP.Name = "txtFolioSAP"
        Me.txtFolioSAP.ReadOnly = True
        Me.txtFolioSAP.Size = New System.Drawing.Size(182, 23)
        Me.txtFolioSAP.TabIndex = 16
        Me.txtFolioSAP.TabStop = False
        Me.txtFolioSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtFolioSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPedidoSAP
        '
        Me.lblPedidoSAP.AutoSize = True
        Me.lblPedidoSAP.Location = New System.Drawing.Point(256, 24)
        Me.lblPedidoSAP.Name = "lblPedidoSAP"
        Me.lblPedidoSAP.Size = New System.Drawing.Size(83, 16)
        Me.lblPedidoSAP.TabIndex = 15
        Me.lblPedidoSAP.Text = "Referencia:"
        '
        'NumericEditBox1
        '
        Me.NumericEditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.NumericEditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.NumericEditBox1.BackColor = System.Drawing.SystemColors.Info
        Me.NumericEditBox1.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NumericEditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericEditBox1.ForeColor = System.Drawing.Color.Red
        Me.NumericEditBox1.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.NumericEditBox1.Location = New System.Drawing.Point(440, 328)
        Me.NumericEditBox1.Name = "NumericEditBox1"
        Me.NumericEditBox1.ReadOnly = True
        Me.NumericEditBox1.Size = New System.Drawing.Size(104, 22)
        Me.NumericEditBox1.TabIndex = 14
        Me.NumericEditBox1.Text = "$0.00"
        Me.NumericEditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmPedidoCancelado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(690, 440)
        Me.Controls.Add(Me.expPedidoCancelado)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPedidoCancelado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de Pedidos"
        CType(Me.MenuPedidoCancelado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.expPedidoCancelado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expPedidoCancelado.ResumeLayout(False)
        CType(Me.grpDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPedido.ResumeLayout(False)
        Me.groupPedido.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables de Instancia"
    Private Pedido As Pedidos
    Private m_PermisoDevolucion As Boolean
#End Region

#Region "Propiedades"
    Public Property PermisoDevolucion() As Boolean
        Get
            Return m_PermisoDevolucion
        End Get
        Set(ByVal Value As Boolean)
            m_PermisoDevolucion = Value
        End Set
    End Property
#End Region

#Region "Metodos Privados"

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/05/2013: Muestra los pedidos en un formulario donde podras cargar el pedido correspondiente
    '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub LoadSearchFormPedidos()
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New PedidosSAPOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
            Me.Pedido = New Pedidos(oOpenRecordDlg.Record.Item("REFERENCIA"), 3)
            Me.Pedido.FolioSAP = CStr(oOpenRecordDlg.Record.Item("VBELN"))
            If Me.Pedido.PedidoID <> 0 Then
                '------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 27.10.2014: Por el momento no permitimos cancelar pedidos porque no tenemos definido el proceso a seguir
                '------------------------------------------------------------------------------------------------------------------------------
                'If Me.Pedido.CodTipoVenta.Trim.ToUpper = "V" Then
                '    MessageBox.Show("Por el momento no es posible cancelar un pedido SH con pago DPVale.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    Me.txtFolioSAP.Focus()
                '    Exit Sub
                'End If
                ClearValues()
                Dim ClienteMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                Dim Cliente As ClienteAlterno = ClienteMgr.CreateAlterno()
                If Me.Pedido.CodTipoVenta = "E" Then
                    Me.txtClientePedido.Text = Me.Pedido.ClienteID
                    Me.txtClientePedidoDescripcion.Text = "EMPLEADO"
                Else
                    If Me.Pedido.CodTipoVenta.Trim() = "P" Then
                        Me.txtClientePedido.Text = Me.Pedido.ClientePGID
                        ClienteMgr.Load(CStr(Me.Pedido.ClientePGID).PadLeft(10, "0"), Cliente)
                    Else
                        Me.txtClientePedido.Text = Me.Pedido.ClienteID
                        ClienteMgr.Load(Me.Pedido.ClienteID.PadLeft(10, "0"), Cliente)
                    End If
                    Me.txtClientePedidoDescripcion.Text = Cliente.Nombre & " " & Cliente.ApellidoPaterno & " " & Cliente.ApellidoMaterno
                End If
                Dim PlayerMgr As New CatalogoVendedoresManager(oAppContext)
                Dim Player As Vendedor = PlayerMgr.Create()
                PlayerMgr.LoadInto(Me.Pedido.CodVendedor, Player)
                Me.txtFolioPedido.Text = Me.Pedido.FolioPedido
                Me.txtCodVendedor.Text = Me.Pedido.CodVendedor
                Me.txtPlayerDescripcion.Text = Player.Nombre
                Me.txtFolioSAP.Text = Me.Pedido.Referencia
                Dim Manager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                Dim fechaHoy As DateTime = Manager.MSS_GET_SY_DATE_TIME()
                '---------------------------------------------------------------------------------------------------------------------------------------
                'RGERMAIN 16.07.2013: Filtramos el detalle del pedido solo por las piezas que es posible reembolsar todavia, y calculamos los importes
                'en base a solo estos materiales
                '---------------------------------------------------------------------------------------------------------------------------------------

                Dim dtCabSH As DataTable, dtDetSH As DataTable, oDetalle As PedidoDetalles()
                If Me.Pedido.Fecha.Date = fechaHoy.Date Then
                    '-----------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 12/07/2017: Cuando el pedido es del mismo día se carga todo el detalle
                    '-----------------------------------------------------------------------------------------------------------------------
                    oDetalle = CreateDetallePedido(Me.Pedido.PedidosDetalles)
                    Me.nebIVA.Value = Me.Pedido.IVA
                    Me.nebSubtotal.Value = Me.Pedido.SubTotal
                    Me.txtImporteTotal.Value = Me.Pedido.Total
                    AgregarDescripcion(oDetalle)
                Else
                    dtCabSH = Pedidos.GetAllActivosSAP("P-S,PE-S,PR,PF,IP", dtDetSH)
                    oDetalle = FiltraDetalle(Me.Pedido.PedidosDetalles, dtCabSH, dtDetSH)
                    'Me.gridPedidos.DataSource = Me.Pedido.PedidosDetalles
                    AgregarDescripcion(oDetalle)
                End If
                Me.gridPedidos.DataSource = oDetalle
                'Me.nebSubtotal.Value = Me.Pedido.SubTotal
                'Me.nebIVA.Value = Me.Pedido.IVA
                'Me.txtImporteTotal.Value = CDec(Me.Pedido.Total)

            Else
                MsgBox("Folio de Pedido No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Facturación")
                txtFolioSAP.Focus()
            End If
        End If
    End Sub

    Private Function FiltraDetalle(ByVal PedDetalle As PedidoDetalles(), ByVal dtCabSH As DataTable, ByVal dtDetSH As DataTable) As PedidoDetalles()
        Dim oDetalle As PedidoDetalles
        Dim oDetTemp As PedidoDetalles(), oDetalleAux As PedidoDetalles(), oDetAux As PedidoDetalles
        Dim oRowV As DataRowView, oRow As DataRow, oRowVD As DataRowView
        Dim oView As DataView, strTalla As String = ""
        Dim dtViewDet As DataView, i As Integer = 0, j As Integer, strDetalles As String = ""
        Dim oArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim oArticulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        oArticulo = oArticuloMgr.Create()
        oView = New DataView(dtCabSH, "Status_Des <> 'IP' And Vbeln = '" & Pedido.FolioSAP & "'", "", DataViewRowState.CurrentRows)

        Me.nebSubtotal.Value = 0

        For Each oRowV In oView
            dtViewDet = New DataView(dtDetSH, "Id_Solicitud = '" & CStr(oRowV!ID_Solicitud).Trim & "' And Vbeln = '" & Pedido.FolioSAP & "'", "", DataViewRowState.CurrentRows)
            For Each oRowVD In dtViewDet
                strTalla = CStr(oRowVD!J_3ASIZE).Trim
                If IsNumeric(strTalla) AndAlso InStr(strTalla, ".0") > 0 Then
                    strTalla = CInt(strTalla)
                End If
                For Each oDetalle In PedDetalle
                    '----------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 31.03.2015: Se agregó una validacion mas al IF porque no tomaba en cuenta las diferentes solicitudes del mismo
                    '                     codigo y misma tallas cuando se hacian a diferentes tiendas y duplicaba la cantidad de piezas en el
                    '                     grid cuando sucedía esta situacion
                    '----------------------------------------------------------------------------------------------------------------------------
                    If oDetalle.CodArticulo.Trim = CStr(oRowVD!MATNR).Trim AndAlso oDetalle.Numero.Trim = strTalla AndAlso _
                    InStr(strDetalles.Trim, oDetalle.CodArticulo.Trim & oDetalle.Numero & ",") <= 0 Then

                        strDetalles &= oDetalle.CodArticulo.Trim & oDetalle.Numero & ","

                        If Not oDetTemp Is Nothing AndAlso oDetTemp.Length > 0 Then oDetalleAux = oDetTemp

                        ReDim oDetTemp(i)
                        j = 0
                        If Not oDetalleAux Is Nothing Then
                            For Each oDetAux In oDetalleAux
                                If Not oDetAux Is Nothing Then
                                    oDetTemp(j) = oDetAux
                                    j += 1
                                End If
                            Next
                        End If
                        oDetTemp(i) = oDetalle

                        Me.nebSubtotal.Value += (oDetalle.Total - oDetalle.CantDescuentoSistema) - ((oDetalle.Total - oDetalle.CantDescuentoSistema) * (oDetalle.Descuento / 100))

                        oDetTemp(i).Descuento = oDetTemp(i).Descuento / 100
                        i += 1

                        Exit For
                    End If
                Next
            Next
        Next

        Me.nebIVA.Value = Me.nebSubtotal.Value * oAppContext.ApplicationConfiguration.IVA
        Me.txtImporteTotal.Value = Me.nebIVA.Value + Me.nebSubtotal.Value

        Return oDetTemp

    End Function

    '--------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/03/2016: Agrega descripción a los materiales
    '--------------------------------------------------------------------------------------------------------------------------------------

    Private Sub AgregarDescripcion(ByRef dtDetalle() As PedidoDetalles)
        Dim oArticuloMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)
        Dim oArticulo As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo
        oArticulo = oArticuloMgr.Create()
        For Each PedidoDetalles As PedidoDetalles In dtDetalle
            oArticulo.ClearFields()
            oArticuloMgr.LoadInto(PedidoDetalles.CodArticulo, oArticulo)
            PedidoDetalles.Numero = oArticuloMgr.GetTallaByCodigo(oArticulo.CodArticulo)
            PedidoDetalles.CodProveedor = oArticulo.CodArtProv
            PedidoDetalles.Descripcion = oArticulo.Descripcion
        Next
    End Sub


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


        Dim oSAPMgr As ProcesoSAPManager
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        oFacturaMgr = New FacturaManager(oAppContext)
        Dim oFactura As Factura
        oFactura = oFacturaMgr.Create

        Dim oDPVale As cDPVale
        oDPVale = New cDPVale

        Dim oCierrediaMgr As CierreDiaManager
        oCierrediaMgr = New CierreDiaManager(oAppContext)


        Dim dsFormaPago As New DataSet

        oFacturaMgr.LoadInto(FacturaID, oFactura)

        Dim ofrmPago As New frmPago
        Dim dtFormasPago As DataTable
        dtFormasPago = ofrmPago.ObtenerFormasPagoByFacturaID(oFactura.FacturaID)

        Dim dtCopy As DataTable
        dtCopy = dtFormasPago.Copy()
        dsFormaPago.Tables.Add(dtCopy)


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


        oDPVale.INUMVA = CStr(intdpvaleid)
        oDPVale.I_RUTA = "X"

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

                    If Not oDPVale.InfoDPVALE Is Nothing Then
                        oRow = oDPVale.InfoDPVALE.Rows(0)

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


    Private Sub FillDataMovimiento(ByRef oFacturaCorrida As FacturaCorrida, ByVal oArticulo As Articulo, ByVal oFactura As Factura)

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


    Private Sub MovimientoEntradaArticulos(ByVal oFactura As Factura)
        'Damos Entrada a los Articulos
        Dim nReg As Integer, nFil As Integer
        Dim oArticulo As Articulo
        Dim oArticuloMgr As CatalogoArticuloManager

        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create
        oArticulo.ClearFields()

        Dim oFacturaCorridaMgr As FacturaCorridaManager
        Dim oFacturaCorrida As FacturaCorrida
        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaCorrida = oFacturaCorridaMgr.Create
        oFacturaCorrida.Clearfields()


        If oFactura.Detalle.Tables(0).Rows.Count > 0 Then
            nReg = oFactura.Detalle.Tables(0).Rows.Count - 1
        End If

        For nFil = 0 To nReg

            With oFactura.Detalle.Tables(0).Rows(nFil)

                oArticulo.ClearFields()
                oArticuloMgr.LoadInto(.Item("CodArticulo"), oArticulo)
                oFacturaCorrida.Numero = .Item("Numero")
                oFacturaCorrida.Cantidad = .Item("Cantidad")

                FillDataMovimiento(oFacturaCorrida, oArticulo, oFactura)
                oFacturaCorridaMgr.SaveMovimiento(oFactura.Total, oFacturaCorrida, 0, 0)

            End With

        Next

    End Sub



    '--------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/05/2013: Crea la cancelación del Pedido junto con todas las facturas que tenga, se le retorna un vale de caja o efectivo
    '--------------------------------------------------------------------------------------------------------------------------------------
    Private Function SaveCancelacionPedido()
        Dim Manager As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        If Pedido Is Nothing Then
            MessageBox.Show("No se abierto ningun pedido a cancelar", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        Dim FechaPedido As DateTime = Pedido.Fecha.Date
        Dim FechaServidor As DateTime = Manager.MSS_GET_SY_DATE_TIME().Date

        Dim Facturas() As Factura = Pedido.GetFacturas(Pedido.PedidoID)
        If Not Facturas Is Nothing AndAlso Facturas.Length > 0 Then
            If FechaPedido <> FechaServidor Then
                MessageBox.Show("El pedido que desea cancelar cuenta con artículos facturados, para su devolución debe realizarse desde el módulo de nota de crédito", " Cancelación Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        oAppContext.Security.CloseImpersonatedSession()
        If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.SiHay.CancelacionPedidos", "DportenisPro.DPTienda.SiHay.CancelacionPedidos.GuardarCancelacionPedido") = True Then
            Dim result As Hashtable, ValeCajaID As Integer
            Dim ofrmPago As New frmPago
            Dim strQuin As String = "0"
            Pedido.CancelaPedidoSH = True
            '---------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 22/05/2013: Se valida si el reembolso se hara un vale de caja o se retornara efectivo
            '---------------------------------------------------------------------------------------------------------------------------
            result = Pedido.CancelarPedido(0)


            'If cbDevolucionEfectivo.Checked = False Then
            '    result = Pedido.CancelarPedido(0)
            'Else
            '    result = Pedido.CancelarPedido(1)
            'End If
            If CBool(result("Success")) = True Then

                '-----------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 26/08/2022: Si se pago con vale de caja se actualiza el estatus y monto 
                '-----------------------------------------------------------------------------------------------------------------------------
                Dim dtFormasPago As DataTable = Pedido.FormasPago
                If Not dtFormasPago Is Nothing AndAlso dtFormasPago.Rows.Count > 0 Then
                    Dim dtView As DataView
                    dtView = New DataView(dtFormasPago, "CodFormasPago = 'VCJA'", "", DataViewRowState.CurrentRows)
                    If dtView.Count > 0 Then
                        Dim oCancelaFacturaMgr As CancelaFacturaManager
                        oCancelaFacturaMgr = New CancelaFacturaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
                        oCancelaFacturaMgr.UpdateStatusValeCajaSH(Pedido.PedidoID)
                    End If
                End If

                Dim mensaje As String = "El pedido fue cancelado exitosamente" & vbCrLf
                If result.ContainsKey("SuccessValeCaja") = True AndAlso CBool(result("SuccessValeCaja")) = False Then
                    mensaje &= "Hubo un error al generar el vale de caja" & vbCrLf
                    MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearValues()
                    Exit Function
                ElseIf result.ContainsKey("SuccessCuponVenta") = True AndAlso CBool(result("SuccessCuponVenta")) = False Then
                    mensaje &= "Hubo un error al generar el cupon de venta" & vbCrLf
                    MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearValues()
                    Exit Function
                ElseIf result.ContainsKey("SuccessCupon") = True AndAlso CBool(result("SuccessCupon")) = False Then
                    mensaje &= "Hubo un error al generar el cupon de cortesia" & vbCrLf
                    MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearValues()
                    Exit Function
                Else
                    MessageBox.Show(mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearValues()
                End If
                If result.ContainsKey("Revale") AndAlso result.ContainsKey("DPValeID") AndAlso result.ContainsKey("MontoDPVale") Then
                    GenerarReVale(CBool(result("Revale")), CStr(result("DPValeID")), CDec(result("MontoDPVale")))
                End If
                ofrmPago.ActionPreviewFacturacionSH(Me.Pedido.PedidoID, False, "Facturacion", False, "CANCELACION", strQuin, False, True)

                '-----------------------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 03/09/2022: Si el pedido es del día y tiene facturas se debe imprimir el ticket de cancelación de las mismas
                '-----------------------------------------------------------------------------------------------------------------------------------------
                If FechaPedido = FechaServidor Then
                    If Not Facturas Is Nothing AndAlso Facturas.Length > 0 Then
                        For Each oFac As Factura In Facturas
                            'Imprimir facturas canceladas
                            ImprimirFactCancel(oFac.FacturaID, "Facturacion", True)

                            'Actualizar existencias
                            MovimientoEntradaArticulos(oFac)
                        Next
                    End If
                End If

            Else
                MessageBox.Show(CStr(result("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 19/06/2013: Se actualiza el estatus de los pedidos en el panel del HomeDash del Si Hay
        '-----------------------------------------------------------------------------------------------------------------------------------------
        RefreshPedidosSiHay()
    End Function

    Private Function GenerarReVale(ByVal GeneraReVale As Boolean, ByVal DPValeID As String, ByVal MontoDPVL As Decimal) As Boolean

        Dim ReValeID As String = ""
        Dim strResult As String = ""
        Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
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

                    ReValeID = oSapMgr.ZBAPI_GENERAR_REVALE(DPValeID, MontoDPVL, strResult)

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
    'FLIZARRAGA (30/10/2013): Imprimimos ReVale de Insurtible
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


    Private Function ClearValues()
        Me.gridPedidos.DataSource = Nothing
        Me.txtClientePedido.Text = ""
        Me.txtClientePedidoDescripcion.Text = ""
        Me.txtCodVendedor.Text = ""
        Me.txtFolioPedido.Text = ""
        Me.txtPlayerDescripcion.Text = ""
        Me.txtFolioPedido.Text = ""
        Me.txtFolioSAP.Text = ""
        Me.txtImporteTotal.Value = 0
        Me.nebIVA.Value = 0
        Me.nebSubtotal.Value = 0
    End Function

#End Region

#Region "Eventos"

    Private Sub MenuPedidoCancelado_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles MenuPedidoCancelado.CommandClick
        Select Case e.Command.Key
            Case "MnuAbrirPedido"
                LoadSearchFormPedidos()
            Case "MnuCancelar"
                SaveCancelacionPedido()
        End Select
    End Sub

    Private Sub frmPedidoCancelado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Me.PermisoDevolucion Then
        '    Me.cbDevolucionEfectivo.Visible = True
        'Else
        '    Me.cbDevolucionEfectivo.Visible = False
        'End If
    End Sub

    Private Function CreateDetallePedido(ByVal PedidosDetalle() As PedidoDetalles) As PedidoDetalles()
        Me.nebSubtotal.Value = 0
        For Each detalle As PedidoDetalles In PedidosDetalle
            detalle.Descuento = detalle.Descuento / 100
            Me.nebSubtotal.Value += (detalle.Total - detalle.CantDescuentoSistema) - ((detalle.Total - detalle.CantDescuentoSistema) * (detalle.Descuento / 100))
        Next
        Return PedidosDetalle
    End Function

#End Region

#Region "DPCard Puntos"
    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 28/04/2015: Valida si el pedido tiene facturas con DPPuntos
    '---------------------------------------------------------------------------------------------------------------------------
    Private Sub DPCardPuntos()
        If oConfigCierreFI.DPCardPuntos = True Then
            If Pedido.NoDPCardPuntos <> "" AndAlso Pedido.CodDPCardPunto = "CAN" Then
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
                oVendedoresMgr.LoadInto(Pedido.CodVendedor, oVendedor)
                Dim resultado As Hashtable
                Dim params As Hashtable
                params("CardId") = Pedido.NoDPCardPuntos
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                'params("Amount") = CStr(row("Subtotal"))
                'params("TotalAmount") = CStr(row("Subtotal"))
                params("ticketid") = Pedido.FolioSAP
                '-----------------------------------------------------------------------------
                'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                'params("StoreId") = "004"
                '-----------------------------------------------------------------------------
                Select Case Pedido.CodTipoVenta
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
                params("SupervisorCode") = Pedido.CodVendedor
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = Pedido.CodVendedor
                params("SellerName") = oVendedor.Nombre
                params("SellerCode") = Pedido.CodVendedor
                params("SellerName") = oVendedor.Nombre
                Dim product As String = ""
                For Each row As DataRow In Pedido.ArticulosNoFacturados.Rows
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
                resultado = ws.ReturnRegister(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) >= 0 Then

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
