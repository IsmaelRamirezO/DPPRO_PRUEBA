<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMicrocredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMicrocredito))
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel2 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel3 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ToolbarDisposicionEfectivo = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuAbrirDisposicion1 = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrirDisposicion")
        Me.MnuImpresion1 = New Janus.Windows.UI.CommandBars.UICommand("MnuImpresion")
        Me.MnuGenerarPrestamo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuGenerarPrestamo")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuNuevo = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuGenerarPrestamo = New Janus.Windows.UI.CommandBars.UICommand("MnuGenerarPrestamo")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuReimpresionTicket = New Janus.Windows.UI.CommandBars.UICommand("MnuReimpresionTicket")
        Me.MnuImpresion = New Janus.Windows.UI.CommandBars.UICommand("MnuImpresion")
        Me.MnuAbrirDisposicion = New Janus.Windows.UI.CommandBars.UICommand("MnuAbrirDisposicion")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.txtNumeroTarjeta = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblNumeroTarjeta = New System.Windows.Forms.Label()
        Me.lblTarjetaHabiente = New System.Windows.Forms.Label()
        Me.txtTarjetaHabiente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPlazo = New System.Windows.Forms.Label()
        Me.cmbPlazo = New Janus.Windows.EditControls.UIComboBox()
        Me.lblNoIfe = New System.Windows.Forms.Label()
        Me.txtNoIfe = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.EstatusPrestamo = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.btnLeerTarjeta = New Janus.Windows.EditControls.UIButton()
        Me.lblCodVendedor = New System.Windows.Forms.Label()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblAviso = New System.Windows.Forms.Label()
        CType(Me.ToolbarDisposicionEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolbarDisposicionEfectivo
        '
        Me.ToolbarDisposicionEfectivo.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarDisposicionEfectivo.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarDisposicionEfectivo.AllowMerge = False
        Me.ToolbarDisposicionEfectivo.BottomRebar = Me.BottomRebar1
        Me.ToolbarDisposicionEfectivo.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.ToolbarDisposicionEfectivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevo, Me.MnuGenerarPrestamo, Me.MnuSalir, Me.MnuReimpresionTicket, Me.MnuImpresion, Me.MnuAbrirDisposicion})
        Me.ToolbarDisposicionEfectivo.ContainerControl = Me
        '
        '
        '
        Me.ToolbarDisposicionEfectivo.EditContextMenu.Key = ""
        Me.ToolbarDisposicionEfectivo.Id = New System.Guid("b5f10bba-c61f-4bb2-bb7c-7ea88d3c9579")
        Me.ToolbarDisposicionEfectivo.LeftRebar = Me.LeftRebar1
        Me.ToolbarDisposicionEfectivo.LockCommandBars = True
        Me.ToolbarDisposicionEfectivo.RightRebar = Me.RightRebar1
        Me.ToolbarDisposicionEfectivo.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarDisposicionEfectivo.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.ToolbarDisposicionEfectivo.ShowQuickCustomizeMenu = False
        Me.ToolbarDisposicionEfectivo.TopRebar = Me.TopRebar1
        Me.ToolbarDisposicionEfectivo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.ToolbarDisposicionEfectivo
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.ToolbarDisposicionEfectivo
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevo1, Me.MnuAbrirDisposicion1, Me.MnuImpresion1, Me.MnuGenerarPrestamo1, Me.MnuSalir1})
        Me.UiCommandBar1.Key = "Toolbar"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(434, 28)
        Me.UiCommandBar1.Text = "Toolbar"
        '
        'MnuNuevo1
        '
        Me.MnuNuevo1.Image = CType(resources.GetObject("MnuNuevo1.Image"), System.Drawing.Image)
        Me.MnuNuevo1.Key = "MnuNuevo"
        Me.MnuNuevo1.Name = "MnuNuevo1"
        '
        'MnuAbrirDisposicion1
        '
        Me.MnuAbrirDisposicion1.Image = CType(resources.GetObject("MnuAbrirDisposicion1.Image"), System.Drawing.Image)
        Me.MnuAbrirDisposicion1.Key = "MnuAbrirDisposicion"
        Me.MnuAbrirDisposicion1.Name = "MnuAbrirDisposicion1"
        '
        'MnuImpresion1
        '
        Me.MnuImpresion1.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuImpresion1.Image = CType(resources.GetObject("MnuImpresion1.Image"), System.Drawing.Image)
        Me.MnuImpresion1.Key = "MnuImpresion"
        Me.MnuImpresion1.Name = "MnuImpresion1"
        '
        'MnuGenerarPrestamo1
        '
        Me.MnuGenerarPrestamo1.Image = CType(resources.GetObject("MnuGenerarPrestamo1.Image"), System.Drawing.Image)
        Me.MnuGenerarPrestamo1.Key = "MnuGenerarPrestamo"
        Me.MnuGenerarPrestamo1.Name = "MnuGenerarPrestamo1"
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
        'MnuGenerarPrestamo
        '
        Me.MnuGenerarPrestamo.Key = "MnuGenerarPrestamo"
        Me.MnuGenerarPrestamo.Name = "MnuGenerarPrestamo"
        Me.MnuGenerarPrestamo.Text = "Generar  prestamo"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "Salir"
        '
        'MnuReimpresionTicket
        '
        Me.MnuReimpresionTicket.Key = "MnuReimpresionTicket"
        Me.MnuReimpresionTicket.Name = "MnuReimpresionTicket"
        Me.MnuReimpresionTicket.Text = "Abrir Disposición"
        '
        'MnuImpresion
        '
        Me.MnuImpresion.Key = "MnuImpresion"
        Me.MnuImpresion.Name = "MnuImpresion"
        Me.MnuImpresion.Text = "Impresión"
        '
        'MnuAbrirDisposicion
        '
        Me.MnuAbrirDisposicion.Key = "MnuAbrirDisposicion"
        Me.MnuAbrirDisposicion.Name = "MnuAbrirDisposicion"
        Me.MnuAbrirDisposicion.Text = "Abrir Disposicion"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.ToolbarDisposicionEfectivo
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.ToolbarDisposicionEfectivo
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.ToolbarDisposicionEfectivo
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(523, 28)
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNumeroTarjeta.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNumeroTarjeta.BackColor = System.Drawing.Color.White
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(155, 36)
        Me.txtNumeroTarjeta.MaxLength = 16
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(150, 20)
        Me.txtNumeroTarjeta.TabIndex = 1
        Me.txtNumeroTarjeta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNumeroTarjeta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblNumeroTarjeta
        '
        Me.lblNumeroTarjeta.AutoSize = True
        Me.lblNumeroTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroTarjeta.Location = New System.Drawing.Point(1, 40)
        Me.lblNumeroTarjeta.Name = "lblNumeroTarjeta"
        Me.lblNumeroTarjeta.Size = New System.Drawing.Size(132, 16)
        Me.lblNumeroTarjeta.TabIndex = 19
        Me.lblNumeroTarjeta.Text = "Número de tarjeta:"
        '
        'lblTarjetaHabiente
        '
        Me.lblTarjetaHabiente.AutoSize = True
        Me.lblTarjetaHabiente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarjetaHabiente.Location = New System.Drawing.Point(1, 67)
        Me.lblTarjetaHabiente.Name = "lblTarjetaHabiente"
        Me.lblTarjetaHabiente.Size = New System.Drawing.Size(117, 16)
        Me.lblTarjetaHabiente.TabIndex = 21
        Me.lblTarjetaHabiente.Text = "Tarjetahabiente:"
        '
        'txtTarjetaHabiente
        '
        Me.txtTarjetaHabiente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTarjetaHabiente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTarjetaHabiente.BackColor = System.Drawing.Color.White
        Me.txtTarjetaHabiente.Location = New System.Drawing.Point(155, 66)
        Me.txtTarjetaHabiente.MaxLength = 60
        Me.txtTarjetaHabiente.Name = "txtTarjetaHabiente"
        Me.txtTarjetaHabiente.ReadOnly = True
        Me.txtTarjetaHabiente.Size = New System.Drawing.Size(174, 20)
        Me.txtTarjetaHabiente.TabIndex = 3
        Me.txtTarjetaHabiente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTarjetaHabiente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPlazo
        '
        Me.lblPlazo.AutoSize = True
        Me.lblPlazo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlazo.Location = New System.Drawing.Point(1, 93)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(47, 16)
        Me.lblPlazo.TabIndex = 23
        Me.lblPlazo.Text = "Plazo:"
        '
        'cmbPlazo
        '
        Me.cmbPlazo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cmbPlazo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlazo.Location = New System.Drawing.Point(155, 89)
        Me.cmbPlazo.Name = "cmbPlazo"
        Me.cmbPlazo.Size = New System.Drawing.Size(174, 22)
        Me.cmbPlazo.TabIndex = 4
        Me.cmbPlazo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblNoIfe
        '
        Me.lblNoIfe.AutoSize = True
        Me.lblNoIfe.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoIfe.Location = New System.Drawing.Point(1, 116)
        Me.lblNoIfe.Name = "lblNoIfe"
        Me.lblNoIfe.Size = New System.Drawing.Size(153, 16)
        Me.lblNoIfe.TabIndex = 25
        Me.lblNoIfe.Text = "Numero Identificación:"
        '
        'txtNoIfe
        '
        Me.txtNoIfe.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNoIfe.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNoIfe.BackColor = System.Drawing.Color.White
        Me.txtNoIfe.Location = New System.Drawing.Point(155, 117)
        Me.txtNoIfe.MaxLength = 13
        Me.txtNoIfe.Name = "txtNoIfe"
        Me.txtNoIfe.Size = New System.Drawing.Size(174, 20)
        Me.txtNoIfe.TabIndex = 5
        Me.txtNoIfe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNoIfe.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(343, 40)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(54, 16)
        Me.lblMonto.TabIndex = 27
        Me.lblMonto.Text = "Monto:"
        '
        'txtMonto
        '
        Me.txtMonto.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtMonto.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtMonto.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.Red
        Me.txtMonto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.txtMonto.Location = New System.Drawing.Point(403, 37)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(108, 23)
        Me.txtMonto.TabIndex = 8
        Me.txtMonto.Text = "$0.00"
        Me.txtMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EstatusPrestamo
        '
        Me.EstatusPrestamo.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstatusPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstatusPrestamo.Location = New System.Drawing.Point(0, 267)
        Me.EstatusPrestamo.Name = "EstatusPrestamo"
        UiStatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Width = 229
        UiStatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel2.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel2.Key = "PanelPrestamo"
        UiStatusBarPanel2.ProgressBarValue = 0
        UiStatusBarPanel2.Text = "F2 Generar prestamo"
        UiStatusBarPanel2.Width = 150
        UiStatusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        UiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        UiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel3.FormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiStatusBarPanel3.Key = ""
        UiStatusBarPanel3.ProgressBarValue = 0
        UiStatusBarPanel3.Text = "F3 Nuevo"
        UiStatusBarPanel3.Width = 134
        Me.EstatusPrestamo.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1, UiStatusBarPanel2, UiStatusBarPanel3})
        Me.EstatusPrestamo.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.EstatusPrestamo.Size = New System.Drawing.Size(523, 24)
        Me.EstatusPrestamo.TabIndex = 29
        Me.EstatusPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnLeerTarjeta
        '
        Me.btnLeerTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerTarjeta.Icon = CType(resources.GetObject("btnLeerTarjeta.Icon"), System.Drawing.Icon)
        Me.btnLeerTarjeta.Location = New System.Drawing.Point(302, 36)
        Me.btnLeerTarjeta.Name = "btnLeerTarjeta"
        Me.btnLeerTarjeta.Size = New System.Drawing.Size(27, 20)
        Me.btnLeerTarjeta.TabIndex = 2
        Me.btnLeerTarjeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblCodVendedor
        '
        Me.lblCodVendedor.AutoSize = True
        Me.lblCodVendedor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodVendedor.Location = New System.Drawing.Point(1, 140)
        Me.lblCodVendedor.Name = "lblCodVendedor"
        Me.lblCodVendedor.Size = New System.Drawing.Size(108, 16)
        Me.lblCodVendedor.TabIndex = 30
        Me.lblCodVendedor.Text = "Cod. Vendedor:"
        '
        'ebPlayer
        '
        Me.ebPlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayer.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.ButtonImage = CType(resources.GetObject("ebPlayer.ButtonImage"), System.Drawing.Image)
        Me.ebPlayer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlayer.Location = New System.Drawing.Point(155, 140)
        Me.ebPlayer.MaxLength = 10
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.Size = New System.Drawing.Size(93, 22)
        Me.ebPlayer.TabIndex = 6
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
        Me.ebNombrePlayer.Location = New System.Drawing.Point(155, 168)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(174, 21)
        Me.ebNombrePlayer.TabIndex = 7
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblAviso
        '
        Me.lblAviso.BackColor = System.Drawing.Color.Purple
        Me.lblAviso.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso.ForeColor = System.Drawing.Color.White
        Me.lblAviso.Location = New System.Drawing.Point(21, 205)
        Me.lblAviso.Name = "lblAviso"
        Me.lblAviso.Size = New System.Drawing.Size(466, 45)
        Me.lblAviso.TabIndex = 9
        Me.lblAviso.Visible = False
        '
        'frmMicrocredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(523, 291)
        Me.Controls.Add(Me.lblAviso)
        Me.Controls.Add(Me.ebPlayer)
        Me.Controls.Add(Me.ebNombrePlayer)
        Me.Controls.Add(Me.lblCodVendedor)
        Me.Controls.Add(Me.btnLeerTarjeta)
        Me.Controls.Add(Me.EstatusPrestamo)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.lblMonto)
        Me.Controls.Add(Me.txtNoIfe)
        Me.Controls.Add(Me.lblNoIfe)
        Me.Controls.Add(Me.cmbPlazo)
        Me.Controls.Add(Me.lblPlazo)
        Me.Controls.Add(Me.txtTarjetaHabiente)
        Me.Controls.Add(Me.lblTarjetaHabiente)
        Me.Controls.Add(Me.txtNumeroTarjeta)
        Me.Controls.Add(Me.lblNumeroTarjeta)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMicrocredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disposicion en efectivo Club DP"
        CType(Me.ToolbarDisposicionEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolbarDisposicionEfectivo As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuGenerarPrestamo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuGenerarPrestamo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents txtNumeroTarjeta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNumeroTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents txtTarjetaHabiente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblTarjetaHabiente As System.Windows.Forms.Label
    Friend WithEvents cmbPlazo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents txtNoIfe As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblNoIfe As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EstatusPrestamo As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents btnLeerTarjeta As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblCodVendedor As System.Windows.Forms.Label
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblAviso As System.Windows.Forms.Label
    Friend WithEvents MnuReimpresionTicket As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuImpresion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuImpresion As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAbrirDisposicion1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuAbrirDisposicion As Janus.Windows.UI.CommandBars.UICommand
End Class
