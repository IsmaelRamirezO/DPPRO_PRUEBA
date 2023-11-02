<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelaPrestamoDisposicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelaPrestamoDisposicion))
        Dim UiStatusBarPanel7 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel8 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel9 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ToolbarCancelarPrestamo = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.tbNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.tbAbrirPrestamo1 = New Janus.Windows.UI.CommandBars.UICommand("tbAbrirPrestamo")
        Me.tbCancelarPrestamo1 = New Janus.Windows.UI.CommandBars.UICommand("tbCancelarPrestamo")
        Me.tbSalirPrestamo1 = New Janus.Windows.UI.CommandBars.UICommand("tbSalirPrestamo")
        Me.tbAbrirPrestamo = New Janus.Windows.UI.CommandBars.UICommand("tbAbrirPrestamo")
        Me.tbCancelarPrestamo = New Janus.Windows.UI.CommandBars.UICommand("tbCancelarPrestamo")
        Me.tbSalirPrestamo = New Janus.Windows.UI.CommandBars.UICommand("tbSalirPrestamo")
        Me.tbNuevo = New Janus.Windows.UI.CommandBars.UICommand("tbNuevo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.EstatusPrestamo = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.txtNumeroTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumeroTarjeta = New System.Windows.Forms.Label()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblCodVendedor = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.txtNoIfe = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNoIfe = New System.Windows.Forms.Label()
        Me.cmbPlazo = New Janus.Windows.EditControls.UIComboBox()
        Me.lblPlazo = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtEstatusDisp = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.ToolbarCancelarPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolbarCancelarPrestamo
        '
        Me.ToolbarCancelarPrestamo.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCancelarPrestamo.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCancelarPrestamo.AllowMerge = False
        Me.ToolbarCancelarPrestamo.BottomRebar = Me.BottomRebar1
        Me.ToolbarCancelarPrestamo.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.ToolbarCancelarPrestamo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbAbrirPrestamo, Me.tbCancelarPrestamo, Me.tbSalirPrestamo, Me.tbNuevo})
        Me.ToolbarCancelarPrestamo.ContainerControl = Me
        '
        '
        '
        Me.ToolbarCancelarPrestamo.EditContextMenu.Key = ""
        Me.ToolbarCancelarPrestamo.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.ToolbarCancelarPrestamo.LeftRebar = Me.LeftRebar1
        Me.ToolbarCancelarPrestamo.LockCommandBars = True
        Me.ToolbarCancelarPrestamo.RightRebar = Me.RightRebar1
        Me.ToolbarCancelarPrestamo.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCancelarPrestamo.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarCancelarPrestamo.ShowQuickCustomizeMenu = False
        Me.ToolbarCancelarPrestamo.TopRebar = Me.TopRebar1
        Me.ToolbarCancelarPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.ToolbarCancelarPrestamo
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.ToolbarCancelarPrestamo
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.tbNuevo1, Me.tbAbrirPrestamo1, Me.tbCancelarPrestamo1, Me.tbSalirPrestamo1})
        Me.UiCommandBar1.Key = "tbCancelar"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(300, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'tbNuevo1
        '
        Me.tbNuevo1.Image = CType(resources.GetObject("tbNuevo1.Image"), System.Drawing.Image)
        Me.tbNuevo1.Key = "tbNuevo"
        Me.tbNuevo1.Name = "tbNuevo1"
        '
        'tbAbrirPrestamo1
        '
        Me.tbAbrirPrestamo1.Image = CType(resources.GetObject("tbAbrirPrestamo1.Image"), System.Drawing.Image)
        Me.tbAbrirPrestamo1.Key = "tbAbrirPrestamo"
        Me.tbAbrirPrestamo1.Name = "tbAbrirPrestamo1"
        '
        'tbCancelarPrestamo1
        '
        Me.tbCancelarPrestamo1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.tbCancelarPrestamo1.Image = CType(resources.GetObject("tbCancelarPrestamo1.Image"), System.Drawing.Image)
        Me.tbCancelarPrestamo1.Key = "tbCancelarPrestamo"
        Me.tbCancelarPrestamo1.Name = "tbCancelarPrestamo1"
        '
        'tbSalirPrestamo1
        '
        Me.tbSalirPrestamo1.Image = CType(resources.GetObject("tbSalirPrestamo1.Image"), System.Drawing.Image)
        Me.tbSalirPrestamo1.Key = "tbSalirPrestamo"
        Me.tbSalirPrestamo1.Name = "tbSalirPrestamo1"
        '
        'tbAbrirPrestamo
        '
        Me.tbAbrirPrestamo.Key = "tbAbrirPrestamo"
        Me.tbAbrirPrestamo.Name = "tbAbrirPrestamo"
        Me.tbAbrirPrestamo.Text = "Abrir"
        '
        'tbCancelarPrestamo
        '
        Me.tbCancelarPrestamo.Key = "tbCancelarPrestamo"
        Me.tbCancelarPrestamo.Name = "tbCancelarPrestamo"
        Me.tbCancelarPrestamo.Text = "Cancelar Prestamo"
        '
        'tbSalirPrestamo
        '
        Me.tbSalirPrestamo.Key = "tbSalirPrestamo"
        Me.tbSalirPrestamo.Name = "tbSalirPrestamo"
        Me.tbSalirPrestamo.Text = "Salir"
        '
        'tbNuevo
        '
        Me.tbNuevo.Key = "tbNuevo"
        Me.tbNuevo.Name = "tbNuevo"
        Me.tbNuevo.Text = "Nuevo"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.ToolbarCancelarPrestamo
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.ToolbarCancelarPrestamo
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.ToolbarCancelarPrestamo
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(414, 28)
        '
        'EstatusPrestamo
        '
        Me.EstatusPrestamo.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstatusPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstatusPrestamo.Location = New System.Drawing.Point(0, 224)
        Me.EstatusPrestamo.Name = "EstatusPrestamo"
        UiStatusBarPanel7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel7.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel7.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel7.Key = "sbNuevo"
        UiStatusBarPanel7.ProgressBarValue = 0
        UiStatusBarPanel7.Text = "F1 Nuevo"
        UiStatusBarPanel7.Width = 140
        UiStatusBarPanel8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel8.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel8.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel8.Key = ""
        UiStatusBarPanel8.ProgressBarValue = 0
        UiStatusBarPanel8.Text = "F2 Abrir"
        UiStatusBarPanel8.Width = 140
        UiStatusBarPanel9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel9.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel9.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel9.Key = "PanelPrestamo"
        UiStatusBarPanel9.ProgressBarValue = 0
        UiStatusBarPanel9.Text = "F3 Cancelar"
        UiStatusBarPanel9.Width = 140
        Me.EstatusPrestamo.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel7, UiStatusBarPanel8, UiStatusBarPanel9})
        Me.EstatusPrestamo.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.EstatusPrestamo.Size = New System.Drawing.Size(414, 24)
        Me.EstatusPrestamo.TabIndex = 190
        Me.EstatusPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNumeroTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNumeroTarjeta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(183, 40)
        Me.txtNumeroTarjeta.MaxLength = 16
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.ReadOnly = True
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(150, 21)
        Me.txtNumeroTarjeta.TabIndex = 1
        Me.txtNumeroTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNumeroTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumeroTarjeta
        '
        Me.lblNumeroTarjeta.AutoSize = True
        Me.lblNumeroTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroTarjeta.Location = New System.Drawing.Point(12, 40)
        Me.lblNumeroTarjeta.Name = "lblNumeroTarjeta"
        Me.lblNumeroTarjeta.Size = New System.Drawing.Size(132, 16)
        Me.lblNumeroTarjeta.TabIndex = 192
        Me.lblNumeroTarjeta.Text = "Número de tarjeta:"
        '
        'ebPlayer
        '
        Me.ebPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayer.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayer.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.ButtonImage = CType(resources.GetObject("ebPlayer.ButtonImage"), System.Drawing.Image)
        Me.ebPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.Location = New System.Drawing.Point(183, 140)
        Me.ebPlayer.MaxLength = 10
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.ReadOnly = True
        Me.ebPlayer.Size = New System.Drawing.Size(68, 22)
        Me.ebPlayer.TabIndex = 4
        Me.ebPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombrePlayer
        '
        Me.ebNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePlayer.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombrePlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombrePlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePlayer.Location = New System.Drawing.Point(257, 140)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(165, 21)
        Me.ebNombrePlayer.TabIndex = 5
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblCodVendedor
        '
        Me.lblCodVendedor.AutoSize = True
        Me.lblCodVendedor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodVendedor.Location = New System.Drawing.Point(12, 140)
        Me.lblCodVendedor.Name = "lblCodVendedor"
        Me.lblCodVendedor.Size = New System.Drawing.Size(108, 16)
        Me.lblCodVendedor.TabIndex = 199
        Me.lblCodVendedor.Text = "Cod. Vendedor:"
        '
        'txtMonto
        '
        Me.txtMonto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtMonto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Info
        Me.txtMonto.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.Red
        Me.txtMonto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtMonto.Location = New System.Drawing.Point(183, 170)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(108, 23)
        Me.txtMonto.TabIndex = 6
        Me.txtMonto.Text = "$0.00"
        Me.txtMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(12, 170)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(54, 16)
        Me.lblMonto.TabIndex = 198
        Me.lblMonto.Text = "Monto:"
        '
        'txtNoIfe
        '
        Me.txtNoIfe.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoIfe.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoIfe.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoIfe.Location = New System.Drawing.Point(183, 117)
        Me.txtNoIfe.Name = "txtNoIfe"
        Me.txtNoIfe.ReadOnly = True
        Me.txtNoIfe.Size = New System.Drawing.Size(174, 20)
        Me.txtNoIfe.TabIndex = 3
        Me.txtNoIfe.TabStop = False
        Me.txtNoIfe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoIfe.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNoIfe
        '
        Me.lblNoIfe.AutoSize = True
        Me.lblNoIfe.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoIfe.Location = New System.Drawing.Point(12, 116)
        Me.lblNoIfe.Name = "lblNoIfe"
        Me.lblNoIfe.Size = New System.Drawing.Size(171, 16)
        Me.lblNoIfe.TabIndex = 197
        Me.lblNoIfe.Text = "Número de identificación:"
        '
        'cmbPlazo
        '
        Me.cmbPlazo.BackColor = System.Drawing.SystemColors.Info
        Me.cmbPlazo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbPlazo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlazo.Location = New System.Drawing.Point(183, 89)
        Me.cmbPlazo.Name = "cmbPlazo"
        Me.cmbPlazo.ReadOnly = True
        Me.cmbPlazo.Size = New System.Drawing.Size(174, 22)
        Me.cmbPlazo.TabIndex = 2
        Me.cmbPlazo.TabStop = False
        Me.cmbPlazo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblPlazo
        '
        Me.lblPlazo.AutoSize = True
        Me.lblPlazo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlazo.Location = New System.Drawing.Point(12, 93)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(47, 16)
        Me.lblPlazo.TabIndex = 196
        Me.lblPlazo.Text = "Plazo:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(12, 196)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(62, 16)
        Me.lblStatus.TabIndex = 202
        Me.lblStatus.Text = "Estatus:"
        '
        'txtEstatusDisp
        '
        Me.txtEstatusDisp.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtEstatusDisp.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtEstatusDisp.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstatusDisp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstatusDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstatusDisp.Location = New System.Drawing.Point(183, 196)
        Me.txtEstatusDisp.Name = "txtEstatusDisp"
        Me.txtEstatusDisp.ReadOnly = True
        Me.txtEstatusDisp.Size = New System.Drawing.Size(174, 21)
        Me.txtEstatusDisp.TabIndex = 7
        Me.txtEstatusDisp.TabStop = False
        Me.txtEstatusDisp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtEstatusDisp.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Enabled = False
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(330, 40)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(27, 21)
        Me.btnLeerTarjeta.TabIndex = 203
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(12, 67)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(110, 16)
        Me.lblNombreCliente.TabIndex = 204
        Me.lblNombreCliente.Text = "Nombre Cliente:"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.Location = New System.Drawing.Point(183, 64)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(174, 22)
        Me.txtNombreCliente.TabIndex = 205
        Me.txtNombreCliente.TabStop = False
        Me.txtNombreCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombreCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCancelaPrestamoDisposicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(414, 248)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.btnLeerTarjeta)
        Me.Controls.Add(Me.txtEstatusDisp)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.ebPlayer)
        Me.Controls.Add(Me.ebNombrePlayer)
        Me.Controls.Add(Me.lblCodVendedor)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.txtNoIfe)
        Me.Controls.Add(Me.lblNoIfe)
        Me.Controls.Add(Me.cmbPlazo)
        Me.Controls.Add(Me.lblPlazo)
        Me.Controls.Add(Me.txtNumeroTarjeta)
        Me.Controls.Add(Me.lblNumeroTarjeta)
        Me.Controls.Add(Me.EstatusPrestamo)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelaPrestamoDisposicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Prestamo Disposición"
        CType(Me.ToolbarCancelarPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolbarCancelarPrestamo As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents tbAbrirPrestamo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbCancelarPrestamo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalirPrestamo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbAbrirPrestamo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbCancelarPrestamo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbSalirPrestamo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EstatusPrestamo As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents txtNumeroTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumeroTarjeta As System.Windows.Forms.Label
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCodVendedor As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents txtNoIfe As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoIfe As System.Windows.Forms.Label
    Friend WithEvents cmbPlazo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtEstatusDisp As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents tbNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents tbNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtNombreCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
End Class
