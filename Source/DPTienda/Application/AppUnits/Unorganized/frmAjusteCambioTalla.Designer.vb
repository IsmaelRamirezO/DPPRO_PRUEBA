<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjusteCambioTalla
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjusteCambioTalla))
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim UiStatusBarPanel4 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel5 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel6 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ToolbarCambioTalla = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.tbNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.tbAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("tbAbrir")
        Me.tbCambioTalla1 = New Janus.Windows.UI.CommandBars.UICommand("tbCambioTalla")
        Me.tbSalir1 = New Janus.Windows.UI.CommandBars.UICommand("tbSalir")
        Me.tbNuevo = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.tbAbrir = New Janus.Windows.UI.CommandBars.UICommand("tbAbrir")
        Me.tbCambioTalla = New Janus.Windows.UI.CommandBars.UICommand("tbCambioTalla")
        Me.tbSalir = New Janus.Windows.UI.CommandBars.UICommand("tbSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.groupCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodVendedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtStatus = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbTipoVenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPlayerPedido = New System.Windows.Forms.Label()
        Me.txtClienteDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPedidoSAP = New System.Windows.Forms.Label()
        Me.NumericEditBox1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.grupoDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.gridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.NumericEditBox2 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.grupoFormasPago = New Janus.Windows.EditControls.UIGroupBox()
        Me.gridCambioTalla = New Janus.Windows.GridEX.GridEX()
        Me.NumericEditBox3 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtIVA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.txtSubtotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtImporteTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.EstatusCambioTalla = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.btnRemove = New Janus.Windows.EditControls.UIButton()
        Me.btnAdd = New Janus.Windows.EditControls.UIButton()
        Me.txtDesctoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDescuentoTotal = New System.Windows.Forms.Label()
        CType(Me.ToolbarCambioTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.groupCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCabecera.SuspendLayout()
        CType(Me.grupoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoDetalle.SuspendLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grupoFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoFormasPago.SuspendLayout()
        CType(Me.gridCambioTalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolbarCambioTalla
        '
        Me.ToolbarCambioTalla.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCambioTalla.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCambioTalla.AllowMerge = False
        Me.ToolbarCambioTalla.BottomRebar = Me.BottomRebar1
        Me.ToolbarCambioTalla.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.ToolbarCambioTalla.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbNuevo, Me.tbAbrir, Me.tbCambioTalla, Me.tbSalir})
        Me.ToolbarCambioTalla.ContainerControl = Me
        '
        '
        '
        Me.ToolbarCambioTalla.EditContextMenu.Key = ""
        Me.ToolbarCambioTalla.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.ToolbarCambioTalla.LeftRebar = Me.LeftRebar1
        Me.ToolbarCambioTalla.LockCommandBars = True
        Me.ToolbarCambioTalla.RightRebar = Me.RightRebar1
        Me.ToolbarCambioTalla.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCambioTalla.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCambioTalla.ShowQuickCustomizeMenu = False
        Me.ToolbarCambioTalla.TopRebar = Me.TopRebar1
        Me.ToolbarCambioTalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.ToolbarCambioTalla
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.ToolbarCambioTalla
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbNuevo1, Me.tbAbrir1, Me.tbCambioTalla1, Me.tbSalir1})
        Me.UiCommandBar1.Key = "toolbar"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(311, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'tbNuevo1
        '
        Me.tbNuevo1.Image = CType(resources.GetObject("tbNuevo1.Image"), System.Drawing.Image)
        Me.tbNuevo1.Key = "tbNuevo"
        Me.tbNuevo1.Name = "tbNuevo1"
        '
        'tbAbrir1
        '
        Me.tbAbrir1.Image = CType(resources.GetObject("tbAbrir1.Image"), System.Drawing.Image)
        Me.tbAbrir1.Key = "tbAbrir"
        Me.tbAbrir1.Name = "tbAbrir1"
        '
        'tbCambioTalla1
        '
        Me.tbCambioTalla1.Image = CType(resources.GetObject("tbCambioTalla1.Image"), System.Drawing.Image)
        Me.tbCambioTalla1.Key = "tbCambioTalla"
        Me.tbCambioTalla1.Name = "tbCambioTalla1"
        '
        'tbSalir1
        '
        Me.tbSalir1.Image = CType(resources.GetObject("tbSalir1.Image"), System.Drawing.Image)
        Me.tbSalir1.Key = "tbSalir"
        Me.tbSalir1.Name = "tbSalir1"
        '
        'tbNuevo
        '
        Me.tbNuevo.Key = "tbNuevo"
        Me.tbNuevo.Name = "tbNuevo"
        Me.tbNuevo.Text = "Nuevo"
        '
        'tbAbrir
        '
        Me.tbAbrir.Key = "tbAbrir"
        Me.tbAbrir.Name = "tbAbrir"
        Me.tbAbrir.Text = "Abrir Factura"
        '
        'tbCambioTalla
        '
        Me.tbCambioTalla.Key = "tbCambioTalla"
        Me.tbCambioTalla.Name = "tbCambioTalla"
        Me.tbCambioTalla.Text = "Cambio Talla"
        '
        'tbSalir
        '
        Me.tbSalir.Key = "tbSalir"
        Me.tbSalir.Name = "tbSalir"
        Me.tbSalir.Text = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.ToolbarCambioTalla
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.ToolbarCambioTalla
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.ToolbarCambioTalla
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(678, 28)
        '
        'groupCabecera
        '
        Me.groupCabecera.BackColor = System.Drawing.Color.Transparent
        Me.groupCabecera.Controls.Add(Me.txtCodVendedor)
        Me.groupCabecera.Controls.Add(Me.txtStatus)
        Me.groupCabecera.Controls.Add(Me.lblStatus)
        Me.groupCabecera.Controls.Add(Me.cmbTipoVenta)
        Me.groupCabecera.Controls.Add(Me.lblTipoVenta)
        Me.groupCabecera.Controls.Add(Me.txtFecha)
        Me.groupCabecera.Controls.Add(Me.lblFecha)
        Me.groupCabecera.Controls.Add(Me.txtPlayerDescripcion)
        Me.groupCabecera.Controls.Add(Me.lblPlayerPedido)
        Me.groupCabecera.Controls.Add(Me.txtClienteDescripcion)
        Me.groupCabecera.Controls.Add(Me.txtCliente)
        Me.groupCabecera.Controls.Add(Me.lblCliente)
        Me.groupCabecera.Controls.Add(Me.txtFolio)
        Me.groupCabecera.Controls.Add(Me.lblFolio)
        Me.groupCabecera.Controls.Add(Me.txtReferencia)
        Me.groupCabecera.Controls.Add(Me.lblPedidoSAP)
        Me.groupCabecera.Controls.Add(Me.NumericEditBox1)
        Me.groupCabecera.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupCabecera.Location = New System.Drawing.Point(12, 34)
        Me.groupCabecera.Name = "groupCabecera"
        Me.groupCabecera.Size = New System.Drawing.Size(623, 120)
        Me.groupCabecera.TabIndex = 8
        Me.groupCabecera.Text = "Factura"
        Me.groupCabecera.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtCodVendedor
        '
        Me.txtCodVendedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodVendedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodVendedor.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodVendedor.ButtonImage = CType(resources.GetObject("txtCodVendedor.ButtonImage"), System.Drawing.Image)
        Me.txtCodVendedor.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCodVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodVendedor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodVendedor.Location = New System.Drawing.Point(63, 88)
        Me.txtCodVendedor.MaxLength = 10
        Me.txtCodVendedor.Name = "txtCodVendedor"
        Me.txtCodVendedor.ReadOnly = True
        Me.txtCodVendedor.Size = New System.Drawing.Size(89, 22)
        Me.txtCodVendedor.TabIndex = 80
        Me.txtCodVendedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCodVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtStatus
        '
        Me.txtStatus.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtStatus.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Info
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(459, 88)
        Me.txtStatus.MaxLength = 3
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(56, 22)
        Me.txtStatus.TabIndex = 78
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtStatus.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(371, 88)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(68, 23)
        Me.lblStatus.TabIndex = 79
        Me.lblStatus.Text = "Status:"
        '
        'cmbTipoVenta
        '
        Me.cmbTipoVenta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoVenta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoVenta.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTipoVenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.cmbTipoVenta.DesignTimeLayout = GridEXLayout4
        Me.cmbTipoVenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoVenta.Location = New System.Drawing.Point(459, 56)
        Me.cmbTipoVenta.Name = "cmbTipoVenta"
        Me.cmbTipoVenta.ReadOnly = True
        Me.cmbTipoVenta.Size = New System.Drawing.Size(138, 22)
        Me.cmbTipoVenta.TabIndex = 66
        Me.cmbTipoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.AutoSize = True
        Me.lblTipoVenta.Location = New System.Drawing.Point(371, 56)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(82, 16)
        Me.lblTipoVenta.TabIndex = 64
        Me.lblTipoVenta.Text = "Tipo Venta:"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.txtFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(484, 23)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(113, 22)
        Me.txtFecha.TabIndex = 63
        Me.txtFecha.TabStop = False
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(428, 24)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 16)
        Me.lblFecha.TabIndex = 25
        Me.lblFecha.Text = "Fecha:"
        '
        'txtPlayerDescripcion
        '
        Me.txtPlayerDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPlayerDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPlayerDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.txtPlayerDescripcion.Location = New System.Drawing.Point(160, 88)
        Me.txtPlayerDescripcion.Name = "txtPlayerDescripcion"
        Me.txtPlayerDescripcion.ReadOnly = True
        Me.txtPlayerDescripcion.Size = New System.Drawing.Size(205, 23)
        Me.txtPlayerDescripcion.TabIndex = 24
        Me.txtPlayerDescripcion.TabStop = False
        Me.txtPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        'txtClienteDescripcion
        '
        Me.txtClienteDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtClienteDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtClienteDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.txtClienteDescripcion.Location = New System.Drawing.Point(160, 56)
        Me.txtClienteDescripcion.Name = "txtClienteDescripcion"
        Me.txtClienteDescripcion.ReadOnly = True
        Me.txtClienteDescripcion.Size = New System.Drawing.Size(205, 23)
        Me.txtClienteDescripcion.TabIndex = 21
        Me.txtClienteDescripcion.TabStop = False
        Me.txtClienteDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtClienteDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCliente
        '
        Me.txtCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCliente.Location = New System.Drawing.Point(64, 56)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(88, 23)
        Me.txtCliente.TabIndex = 20
        Me.txtCliente.TabStop = False
        Me.txtCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        'txtFolio
        '
        Me.txtFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtFolio.BackColor = System.Drawing.SystemColors.Info
        Me.txtFolio.Location = New System.Drawing.Point(64, 24)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(88, 23)
        Me.txtFolio.TabIndex = 18
        Me.txtFolio.TabStop = False
        Me.txtFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        'txtReferencia
        '
        Me.txtReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtReferencia.BackColor = System.Drawing.SystemColors.Info
        Me.txtReferencia.Location = New System.Drawing.Point(240, 22)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(182, 23)
        Me.txtReferencia.TabIndex = 16
        Me.txtReferencia.TabStop = False
        Me.txtReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPedidoSAP
        '
        Me.lblPedidoSAP.AutoSize = True
        Me.lblPedidoSAP.Location = New System.Drawing.Point(158, 24)
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
        'grupoDetalle
        '
        Me.grupoDetalle.BackColor = System.Drawing.Color.Transparent
        Me.grupoDetalle.Controls.Add(Me.gridDetalle)
        Me.grupoDetalle.Controls.Add(Me.NumericEditBox2)
        Me.grupoDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoDetalle.Location = New System.Drawing.Point(12, 160)
        Me.grupoDetalle.Name = "grupoDetalle"
        Me.grupoDetalle.Size = New System.Drawing.Size(623, 165)
        Me.grupoDetalle.TabIndex = 9
        Me.grupoDetalle.Text = "Detalle"
        Me.grupoDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'gridDetalle
        '
        Me.gridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout5.LayoutString = resources.GetString("GridEXLayout5.LayoutString")
        Me.gridDetalle.DesignTimeLayout = GridEXLayout5
        Me.gridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.gridDetalle.GroupByBoxVisible = False
        Me.gridDetalle.Location = New System.Drawing.Point(6, 15)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.gridDetalle.Size = New System.Drawing.Size(611, 144)
        Me.gridDetalle.TabIndex = 15
        Me.gridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'NumericEditBox2
        '
        Me.NumericEditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.NumericEditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.NumericEditBox2.BackColor = System.Drawing.SystemColors.Info
        Me.NumericEditBox2.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NumericEditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericEditBox2.ForeColor = System.Drawing.Color.Red
        Me.NumericEditBox2.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.NumericEditBox2.Location = New System.Drawing.Point(440, 328)
        Me.NumericEditBox2.Name = "NumericEditBox2"
        Me.NumericEditBox2.ReadOnly = True
        Me.NumericEditBox2.Size = New System.Drawing.Size(104, 22)
        Me.NumericEditBox2.TabIndex = 14
        Me.NumericEditBox2.Text = "$0.00"
        Me.NumericEditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumericEditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grupoFormasPago
        '
        Me.grupoFormasPago.BackColor = System.Drawing.Color.Transparent
        Me.grupoFormasPago.Controls.Add(Me.gridCambioTalla)
        Me.grupoFormasPago.Controls.Add(Me.NumericEditBox3)
        Me.grupoFormasPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoFormasPago.Location = New System.Drawing.Point(12, 331)
        Me.grupoFormasPago.Name = "grupoFormasPago"
        Me.grupoFormasPago.Size = New System.Drawing.Size(623, 168)
        Me.grupoFormasPago.TabIndex = 12
        Me.grupoFormasPago.Text = "Detalle de cambio de talla"
        Me.grupoFormasPago.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'gridCambioTalla
        '
        Me.gridCambioTalla.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout6.LayoutString = resources.GetString("GridEXLayout6.LayoutString")
        Me.gridCambioTalla.DesignTimeLayout = GridEXLayout6
        Me.gridCambioTalla.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridCambioTalla.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.gridCambioTalla.GroupByBoxVisible = False
        Me.gridCambioTalla.Location = New System.Drawing.Point(6, 15)
        Me.gridCambioTalla.Name = "gridCambioTalla"
        Me.gridCambioTalla.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.gridCambioTalla.Size = New System.Drawing.Size(611, 144)
        Me.gridCambioTalla.TabIndex = 15
        Me.gridCambioTalla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'NumericEditBox3
        '
        Me.NumericEditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.NumericEditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.NumericEditBox3.BackColor = System.Drawing.SystemColors.Info
        Me.NumericEditBox3.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NumericEditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericEditBox3.ForeColor = System.Drawing.Color.Red
        Me.NumericEditBox3.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.NumericEditBox3.Location = New System.Drawing.Point(440, 328)
        Me.NumericEditBox3.Name = "NumericEditBox3"
        Me.NumericEditBox3.ReadOnly = True
        Me.NumericEditBox3.Size = New System.Drawing.Size(104, 22)
        Me.NumericEditBox3.TabIndex = 14
        Me.NumericEditBox3.Text = "$0.00"
        Me.NumericEditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumericEditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtIVA
        '
        Me.txtIVA.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtIVA.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtIVA.BackColor = System.Drawing.SystemColors.Info
        Me.txtIVA.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtIVA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIVA.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtIVA.Location = New System.Drawing.Point(211, 502)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(74, 22)
        Me.txtIVA.TabIndex = 30
        Me.txtIVA.Text = "$0.00"
        Me.txtIVA.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtIVA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblIva
        '
        Me.lblIva.BackColor = System.Drawing.Color.Transparent
        Me.lblIva.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.ForeColor = System.Drawing.Color.Black
        Me.lblIva.Location = New System.Drawing.Point(170, 502)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(35, 24)
        Me.lblIva.TabIndex = 29
        Me.lblIva.Text = "IVA"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSubtotal
        '
        Me.txtSubtotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtSubtotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtSubtotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtSubtotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtSubtotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSubtotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtSubtotal.Location = New System.Drawing.Point(89, 502)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(75, 22)
        Me.txtSubtotal.TabIndex = 28
        Me.txtSubtotal.Text = "$0.00"
        Me.txtSubtotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSubtotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtotal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.Black
        Me.lblSubtotal.Location = New System.Drawing.Point(12, 502)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(74, 24)
        Me.lblSubtotal.TabIndex = 27
        Me.lblSubtotal.Text = "SubTotal"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtImporteTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtImporteTotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtImporteTotal.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteTotal.ForeColor = System.Drawing.Color.Red
        Me.txtImporteTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtImporteTotal.Location = New System.Drawing.Point(533, 501)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(96, 30)
        Me.txtImporteTotal.TabIndex = 26
        Me.txtImporteTotal.Text = "$0.00"
        Me.txtImporteTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImporteTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(481, 500)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(46, 24)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstatusCambioTalla
        '
        Me.EstatusCambioTalla.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstatusCambioTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstatusCambioTalla.Location = New System.Drawing.Point(0, 535)
        Me.EstatusCambioTalla.Name = "EstatusCambioTalla"
        UiStatusBarPanel4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel4.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel4.Key = ""
        UiStatusBarPanel4.ProgressBarValue = 0
        UiStatusBarPanel4.Width = 229
        UiStatusBarPanel5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel5.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel5.Key = "PanelPrestamo"
        UiStatusBarPanel5.ProgressBarValue = 0
        UiStatusBarPanel5.Text = "F2 Cambiar Talla"
        UiStatusBarPanel5.Width = 150
        UiStatusBarPanel6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        UiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel6.FormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel6.Key = ""
        UiStatusBarPanel6.ProgressBarValue = 0
        UiStatusBarPanel6.Text = "F3 Nuevo"
        UiStatusBarPanel6.Width = 289
        Me.EstatusCambioTalla.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel4, UiStatusBarPanel5, UiStatusBarPanel6})
        Me.EstatusCambioTalla.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.EstatusCambioTalla.Size = New System.Drawing.Size(678, 24)
        Me.EstatusCambioTalla.TabIndex = 31
        Me.EstatusCambioTalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(641, 372)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 24)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(641, 346)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 24)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtDesctoTotal
        '
        Me.txtDesctoTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtDesctoTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtDesctoTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtDesctoTotal.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDesctoTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesctoTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDesctoTotal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtDesctoTotal.Location = New System.Drawing.Point(395, 502)
        Me.txtDesctoTotal.Name = "txtDesctoTotal"
        Me.txtDesctoTotal.ReadOnly = True
        Me.txtDesctoTotal.Size = New System.Drawing.Size(74, 22)
        Me.txtDesctoTotal.TabIndex = 36
        Me.txtDesctoTotal.Text = "$0.00"
        Me.txtDesctoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDesctoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDescuentoTotal
        '
        Me.lblDescuentoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblDescuentoTotal.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuentoTotal.ForeColor = System.Drawing.Color.Black
        Me.lblDescuentoTotal.Location = New System.Drawing.Point(292, 502)
        Me.lblDescuentoTotal.Name = "lblDescuentoTotal"
        Me.lblDescuentoTotal.Size = New System.Drawing.Size(106, 24)
        Me.lblDescuentoTotal.TabIndex = 35
        Me.lblDescuentoTotal.Text = "Descto Total"
        Me.lblDescuentoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAjusteCambioTalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(678, 559)
        Me.Controls.Add(Me.txtDesctoTotal)
        Me.Controls.Add(Me.lblDescuentoTotal)
        Me.Controls.Add(Me.EstatusCambioTalla)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.lblIva)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.lblSubtotal)
        Me.Controls.Add(Me.txtImporteTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.grupoFormasPago)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grupoDetalle)
        Me.Controls.Add(Me.groupCabecera)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjusteCambioTalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de talla"
        CType(Me.ToolbarCambioTalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.groupCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCabecera.ResumeLayout(False)
        Me.groupCabecera.PerformLayout()
        CType(Me.grupoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoDetalle.ResumeLayout(False)
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grupoFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoFormasPago.ResumeLayout(False)
        CType(Me.gridCambioTalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolbarCambioTalla As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents tbNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbCambioTalla1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbCambioTalla As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents groupCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtStatus As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmbTipoVenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoVenta As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPlayerPedido As System.Windows.Forms.Label
    Friend WithEvents txtClienteDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPedidoSAP As System.Windows.Forms.Label
    Friend WithEvents NumericEditBox1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents grupoDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents NumericEditBox2 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnRemove As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtIVA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents txtImporteTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents grupoFormasPago As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gridCambioTalla As Janus.Windows.GridEX.GridEX
    Friend WithEvents NumericEditBox3 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EstatusCambioTalla As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents txtCodVendedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDesctoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDescuentoTotal As System.Windows.Forms.Label
End Class
