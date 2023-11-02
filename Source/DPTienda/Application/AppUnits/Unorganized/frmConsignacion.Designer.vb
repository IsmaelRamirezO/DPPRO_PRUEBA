<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsignacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsignacion))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolbarConsignacion = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrir")
        Me.MnuBuscar1 = New Janus.Windows.UI.CommandBars.UICommand("MnuBuscar")
        Me.MnuCargarLectora1 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarLectora")
        Me.MnuImpresion1 = New Janus.Windows.UI.CommandBars.UICommand("MnuImpresion")
        Me.MnuAplicarTraslado1 = New Janus.Windows.UI.CommandBars.UICommand("MnuAplicarTraslado")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuNuevo = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuAbrir = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrir")
        Me.MnuBuscar = New Janus.Windows.UI.CommandBars.UICommand("MnuBuscar")
        Me.MnuImpresion = New Janus.Windows.UI.CommandBars.UICommand("MnuImpresion")
        Me.MnuAplicarTraslado = New Janus.Windows.UI.CommandBars.UICommand("MnuAplicarTraslado")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuCargarLectora = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarLectora")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.groupCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.txtPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtProveedorDesc = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtPlayerDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.txtAlmacenDescr = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodAlmacen = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblTienda = New System.Windows.Forms.Label()
        Me.txtCodProveedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtNoPedido = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoPedido = New System.Windows.Forms.Label()
        Me.NumericEditBox1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.lblTotalPedido = New System.Windows.Forms.Label()
        Me.txtTotalPedido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalRecibido = New System.Windows.Forms.Label()
        Me.txtTotalRecibido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ToolbarConsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.groupCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupCabecera.SuspendLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolbarConsignacion
        '
        Me.ToolbarConsignacion.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarConsignacion.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarConsignacion.AllowMerge = False
        Me.ToolbarConsignacion.BottomRebar = Me.BottomRebar1
        Me.ToolbarConsignacion.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.ToolbarConsignacion.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevo, Me.MnuAbrir, Me.MnuBuscar, Me.MnuImpresion, Me.MnuAplicarTraslado, Me.MnuSalir, Me.MnuCargarLectora})
        Me.ToolbarConsignacion.ContainerControl = Me
        '
        '
        '
        Me.ToolbarConsignacion.EditContextMenu.Key = ""
        Me.ToolbarConsignacion.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.ToolbarConsignacion.LeftRebar = Me.LeftRebar1
        Me.ToolbarConsignacion.LockCommandBars = True
        Me.ToolbarConsignacion.RightRebar = Me.RightRebar1
        Me.ToolbarConsignacion.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarConsignacion.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarConsignacion.ShowQuickCustomizeMenu = False
        Me.ToolbarConsignacion.TopRebar = Me.TopRebar1
        Me.ToolbarConsignacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.ToolbarConsignacion
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.ToolbarConsignacion
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevo1, Me.MnuAbrir1, Me.MnuBuscar1, Me.MnuCargarLectora1, Me.MnuImpresion1, Me.MnuAplicarTraslado1, Me.MnuSalir1})
        Me.UiCommandBar1.Key = "Toolbar"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(525, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuNuevo1
        '
        Me.MnuNuevo1.Image = CType(resources.GetObject("MnuNuevo1.Image"), System.Drawing.Image)
        Me.MnuNuevo1.Key = "MnuNuevo"
        Me.MnuNuevo1.Name = "MnuNuevo1"
        '
        'MnuAbrir1
        '
        Me.MnuAbrir1.Image = CType(resources.GetObject("MnuAbrir1.Image"), System.Drawing.Image)
        Me.MnuAbrir1.Key = "MnuAbrir"
        Me.MnuAbrir1.Name = "MnuAbrir1"
        '
        'MnuBuscar1
        '
        Me.MnuBuscar1.Icon = CType(resources.GetObject("MnuBuscar1.Icon"), System.Drawing.Icon)
        Me.MnuBuscar1.Key = "MnuBuscar"
        Me.MnuBuscar1.Name = "MnuBuscar1"
        '
        'MnuCargarLectora1
        '
        Me.MnuCargarLectora1.Image = CType(resources.GetObject("MnuCargarLectora1.Image"), System.Drawing.Image)
        Me.MnuCargarLectora1.Key = "MnuCargarLectora"
        Me.MnuCargarLectora1.Name = "MnuCargarLectora1"
        '
        'MnuImpresion1
        '
        Me.MnuImpresion1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuImpresion1.Image = CType(resources.GetObject("MnuImpresion1.Image"), System.Drawing.Image)
        Me.MnuImpresion1.Key = "MnuImpresion"
        Me.MnuImpresion1.Name = "MnuImpresion1"
        '
        'MnuAplicarTraslado1
        '
        Me.MnuAplicarTraslado1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuAplicarTraslado1.Image = CType(resources.GetObject("MnuAplicarTraslado1.Image"), System.Drawing.Image)
        Me.MnuAplicarTraslado1.Key = "MnuAplicarTraslado"
        Me.MnuAplicarTraslado1.Name = "MnuAplicarTraslado1"
        '
        'MnuSalir1
        '
        Me.MnuSalir1.Image = CType(resources.GetObject("MnuSalir1.Image"), System.Drawing.Image)
        Me.MnuSalir1.Key = "MnuSalir"
        Me.MnuSalir1.Name = "MnuSalir1"
        '
        'MnuNuevo
        '
        Me.MnuNuevo.Key = "MnuNuevo"
        Me.MnuNuevo.Name = "MnuNuevo"
        Me.MnuNuevo.Text = "Nuevo"
        '
        'MnuAbrir
        '
        Me.MnuAbrir.Key = "MnuAbrir"
        Me.MnuAbrir.Name = "MnuAbrir"
        Me.MnuAbrir.Text = "Abrir"
        '
        'MnuBuscar
        '
        Me.MnuBuscar.Key = "MnuBuscar"
        Me.MnuBuscar.Name = "MnuBuscar"
        Me.MnuBuscar.Text = "Buscar"
        '
        'MnuImpresion
        '
        Me.MnuImpresion.Key = "MnuImpresion"
        Me.MnuImpresion.Name = "MnuImpresion"
        Me.MnuImpresion.Text = "Impresión"
        '
        'MnuAplicarTraslado
        '
        Me.MnuAplicarTraslado.Key = "MnuAplicarTraslado"
        Me.MnuAplicarTraslado.Name = "MnuAplicarTraslado"
        Me.MnuAplicarTraslado.Text = "Aplicar"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "Salir"
        '
        'MnuCargarLectora
        '
        Me.MnuCargarLectora.Key = "MnuCargarLectora"
        Me.MnuCargarLectora.Name = "MnuCargarLectora"
        Me.MnuCargarLectora.Text = "Cargar desde Lectora"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.ToolbarConsignacion
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.ToolbarConsignacion
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.ToolbarConsignacion
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(766, 28)
        '
        'groupCabecera
        '
        Me.groupCabecera.BackColor = System.Drawing.Color.Transparent
        Me.groupCabecera.Controls.Add(Me.txtReferencia)
        Me.groupCabecera.Controls.Add(Me.lblReferencia)
        Me.groupCabecera.Controls.Add(Me.txtPlayer)
        Me.groupCabecera.Controls.Add(Me.txtProveedorDesc)
        Me.groupCabecera.Controls.Add(Me.txtFecha)
        Me.groupCabecera.Controls.Add(Me.lblFecha)
        Me.groupCabecera.Controls.Add(Me.txtPlayerDescripcion)
        Me.groupCabecera.Controls.Add(Me.lblResponsable)
        Me.groupCabecera.Controls.Add(Me.txtAlmacenDescr)
        Me.groupCabecera.Controls.Add(Me.txtCodAlmacen)
        Me.groupCabecera.Controls.Add(Me.lblTienda)
        Me.groupCabecera.Controls.Add(Me.txtCodProveedor)
        Me.groupCabecera.Controls.Add(Me.lblProveedor)
        Me.groupCabecera.Controls.Add(Me.txtNoPedido)
        Me.groupCabecera.Controls.Add(Me.lblNoPedido)
        Me.groupCabecera.Controls.Add(Me.NumericEditBox1)
        Me.groupCabecera.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupCabecera.Location = New System.Drawing.Point(12, 34)
        Me.groupCabecera.Name = "groupCabecera"
        Me.groupCabecera.Size = New System.Drawing.Size(744, 120)
        Me.groupCabecera.TabIndex = 8
        Me.groupCabecera.Text = "Datos Generales"
        Me.groupCabecera.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'txtReferencia
        '
        Me.txtReferencia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtReferencia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtReferencia.Location = New System.Drawing.Point(583, 58)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(114, 23)
        Me.txtReferencia.TabIndex = 82
        Me.txtReferencia.TabStop = False
        Me.txtReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(498, 58)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(83, 16)
        Me.lblReferencia.TabIndex = 81
        Me.lblReferencia.Text = "Referencia:"
        '
        'txtPlayer
        '
        Me.txtPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtPlayer.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer.ButtonImage = CType(resources.GetObject("txtPlayer.ButtonImage"), System.Drawing.Image)
        Me.txtPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtPlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer.Location = New System.Drawing.Point(105, 88)
        Me.txtPlayer.MaxLength = 8
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(89, 22)
        Me.txtPlayer.TabIndex = 67
        Me.txtPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtProveedorDesc
        '
        Me.txtProveedorDesc.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtProveedorDesc.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtProveedorDesc.BackColor = System.Drawing.SystemColors.Info
        Me.txtProveedorDesc.Location = New System.Drawing.Point(195, 24)
        Me.txtProveedorDesc.Name = "txtProveedorDesc"
        Me.txtProveedorDesc.ReadOnly = True
        Me.txtProveedorDesc.Size = New System.Drawing.Size(260, 23)
        Me.txtProveedorDesc.TabIndex = 80
        Me.txtProveedorDesc.TabStop = False
        Me.txtProveedorDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtProveedorDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.txtFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(583, 90)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(113, 22)
        Me.txtFecha.TabIndex = 63
        Me.txtFecha.TabStop = False
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2018, 2, 7, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(498, 90)
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
        Me.txtPlayerDescripcion.Location = New System.Drawing.Point(195, 88)
        Me.txtPlayerDescripcion.Name = "txtPlayerDescripcion"
        Me.txtPlayerDescripcion.ReadOnly = True
        Me.txtPlayerDescripcion.Size = New System.Drawing.Size(260, 23)
        Me.txtPlayerDescripcion.TabIndex = 24
        Me.txtPlayerDescripcion.TabStop = False
        Me.txtPlayerDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayerDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.Location = New System.Drawing.Point(11, 88)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(95, 16)
        Me.lblResponsable.TabIndex = 22
        Me.lblResponsable.Text = "Responsable:"
        '
        'txtAlmacenDescr
        '
        Me.txtAlmacenDescr.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtAlmacenDescr.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtAlmacenDescr.BackColor = System.Drawing.SystemColors.Info
        Me.txtAlmacenDescr.Location = New System.Drawing.Point(195, 56)
        Me.txtAlmacenDescr.Name = "txtAlmacenDescr"
        Me.txtAlmacenDescr.ReadOnly = True
        Me.txtAlmacenDescr.Size = New System.Drawing.Size(260, 23)
        Me.txtAlmacenDescr.TabIndex = 21
        Me.txtAlmacenDescr.TabStop = False
        Me.txtAlmacenDescr.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtAlmacenDescr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtCodAlmacen
        '
        Me.txtCodAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodAlmacen.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodAlmacen.Location = New System.Drawing.Point(105, 56)
        Me.txtCodAlmacen.Name = "txtCodAlmacen"
        Me.txtCodAlmacen.ReadOnly = True
        Me.txtCodAlmacen.Size = New System.Drawing.Size(89, 23)
        Me.txtCodAlmacen.TabIndex = 20
        Me.txtCodAlmacen.TabStop = False
        Me.txtCodAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCodAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTienda
        '
        Me.lblTienda.AutoSize = True
        Me.lblTienda.Location = New System.Drawing.Point(11, 56)
        Me.lblTienda.Name = "lblTienda"
        Me.lblTienda.Size = New System.Drawing.Size(55, 16)
        Me.lblTienda.TabIndex = 19
        Me.lblTienda.Text = "Tienda:"
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCodProveedor.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCodProveedor.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodProveedor.Location = New System.Drawing.Point(105, 24)
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.ReadOnly = True
        Me.txtCodProveedor.Size = New System.Drawing.Size(89, 23)
        Me.txtCodProveedor.TabIndex = 18
        Me.txtCodProveedor.TabStop = False
        Me.txtCodProveedor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCodProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(11, 24)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(81, 16)
        Me.lblProveedor.TabIndex = 17
        Me.lblProveedor.Text = "Proveedor:"
        '
        'txtNoPedido
        '
        Me.txtNoPedido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoPedido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoPedido.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoPedido.Location = New System.Drawing.Point(583, 24)
        Me.txtNoPedido.Name = "txtNoPedido"
        Me.txtNoPedido.ReadOnly = True
        Me.txtNoPedido.Size = New System.Drawing.Size(114, 23)
        Me.txtNoPedido.TabIndex = 16
        Me.txtNoPedido.TabStop = False
        Me.txtNoPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoPedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoPedido
        '
        Me.lblNoPedido.AutoSize = True
        Me.lblNoPedido.Location = New System.Drawing.Point(497, 29)
        Me.lblNoPedido.Name = "lblNoPedido"
        Me.lblNoPedido.Size = New System.Drawing.Size(80, 16)
        Me.lblNoPedido.TabIndex = 15
        Me.lblNoPedido.Text = "No. Pedido:"
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
        'gridDetalle
        '
        Me.gridDetalle.AllowCardSizing = False
        Me.gridDetalle.AllowColumnDrag = False
        Me.gridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridDetalle.DesignTimeLayout = GridEXLayout1
        Me.gridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDetalle.GroupByBoxVisible = False
        Me.gridDetalle.Location = New System.Drawing.Point(14, 166)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.gridDetalle.Size = New System.Drawing.Size(742, 261)
        Me.gridDetalle.TabIndex = 16
        Me.gridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalPedido
        '
        Me.lblTotalPedido.AutoSize = True
        Me.lblTotalPedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPedido.Location = New System.Drawing.Point(411, 436)
        Me.lblTotalPedido.Name = "lblTotalPedido"
        Me.lblTotalPedido.Size = New System.Drawing.Size(92, 16)
        Me.lblTotalPedido.TabIndex = 17
        Me.lblTotalPedido.Text = "Total Pedido:"
        '
        'txtTotalPedido
        '
        Me.txtTotalPedido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalPedido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalPedido.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalPedido.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtTotalPedido.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPedido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPedido.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtTotalPedido.Location = New System.Drawing.Point(507, 433)
        Me.txtTotalPedido.Name = "txtTotalPedido"
        Me.txtTotalPedido.ReadOnly = True
        Me.txtTotalPedido.Size = New System.Drawing.Size(47, 22)
        Me.txtTotalPedido.TabIndex = 25
        Me.txtTotalPedido.Text = "0"
        Me.txtTotalPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalPedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalRecibido
        '
        Me.lblTotalRecibido.AutoSize = True
        Me.lblTotalRecibido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRecibido.Location = New System.Drawing.Point(564, 436)
        Me.lblTotalRecibido.Name = "lblTotalRecibido"
        Me.lblTotalRecibido.Size = New System.Drawing.Size(103, 16)
        Me.lblTotalRecibido.TabIndex = 26
        Me.lblTotalRecibido.Text = "Total Recibido:"
        '
        'txtTotalRecibido
        '
        Me.txtTotalRecibido.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalRecibido.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalRecibido.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalRecibido.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtTotalRecibido.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRecibido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalRecibido.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtTotalRecibido.Location = New System.Drawing.Point(673, 433)
        Me.txtTotalRecibido.Name = "txtTotalRecibido"
        Me.txtTotalRecibido.ReadOnly = True
        Me.txtTotalRecibido.Size = New System.Drawing.Size(47, 22)
        Me.txtTotalRecibido.TabIndex = 27
        Me.txtTotalRecibido.Text = "0"
        Me.txtTotalRecibido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalRecibido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmConsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(766, 463)
        Me.Controls.Add(Me.txtTotalRecibido)
        Me.Controls.Add(Me.lblTotalRecibido)
        Me.Controls.Add(Me.txtTotalPedido)
        Me.Controls.Add(Me.lblTotalPedido)
        Me.Controls.Add(Me.gridDetalle)
        Me.Controls.Add(Me.groupCabecera)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsignacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consignación"
        CType(Me.ToolbarConsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.groupCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupCabecera.ResumeLayout(False)
        Me.groupCabecera.PerformLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolbarConsignacion As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuBuscar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuImpresion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAplicarTraslado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuBuscar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuImpresion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAplicarTraslado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents groupCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtPlayerDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents txtAlmacenDescr As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCodAlmacen As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTienda As System.Windows.Forms.Label
    Friend WithEvents txtCodProveedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtNoPedido As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoPedido As System.Windows.Forms.Label
    Friend WithEvents NumericEditBox1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtProveedorDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents MnuCargarLectora1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarLectora As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents gridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblTotalPedido As System.Windows.Forms.Label
    Friend WithEvents txtTotalPedido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalRecibido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalRecibido As System.Windows.Forms.Label
End Class
