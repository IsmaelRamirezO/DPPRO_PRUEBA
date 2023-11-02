Public Class frmDPCardPuntosTraspaso
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Inicializar()
        CreateOperaciones()
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
    Friend WithEvents explorador As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents txtPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPlayer As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Activación As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnTraspaso As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCardID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblCardID As System.Windows.Forms.Label
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents MnuTraspaso As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuTraspaso1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnLeerDPCardCredit As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblDPCardCredit As System.Windows.Forms.Label
    Friend WithEvents cmmMenu As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblTotalPuntos As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnTraspasos As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDPCardCredit As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblDPCardCreditID As System.Windows.Forms.Label
    Friend WithEvents lblDPCardId As System.Windows.Forms.Label
    Friend WithEvents lblSaldoTotal As System.Windows.Forms.Label
    Friend WithEvents txtSaldoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblVerificar As System.Windows.Forms.Label
    Friend WithEvents txtTotalPuntos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNuevaDPCardId As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDeslizarTarjeta As System.Windows.Forms.Label
    Friend WithEvents MnuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents rbCardID As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents MnuBusquedaNombre As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuBusquedaNombre1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents cmbTipoOperacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoTarjeta As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDPCardPuntosTraspaso))
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.explorador = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbTipoOperacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoTarjeta = New System.Windows.Forms.Label()
        Me.txtPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.cmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Activación = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblDeslizarTarjeta = New System.Windows.Forms.Label()
        Me.lblVerificar = New System.Windows.Forms.Label()
        Me.txtSaldoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblSaldoTotal = New System.Windows.Forms.Label()
        Me.txtTotalPuntos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnTraspasos = New Janus.Windows.EditControls.UIButton()
        Me.btnDPCardCredit = New Janus.Windows.EditControls.UIButton()
        Me.txtNuevaDPCardId = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblDPCardCreditID = New System.Windows.Forms.Label()
        Me.lblDPCardId = New System.Windows.Forms.Label()
        Me.lblTotalPuntos = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.txtCardID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.btnTraspaso = New Janus.Windows.EditControls.UIButton()
        Me.btnLeerDPCardCredit = New Janus.Windows.EditControls.UIButton()
        Me.lblDPCardCredit = New System.Windows.Forms.Label()
        Me.lblCardID = New System.Windows.Forms.Label()
        Me.cmmMenu = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.MnuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuBusquedaNombre1 = New Janus.Windows.UI.CommandBars.UICommand("MnuBusquedaNombre")
        Me.MnuTraspaso1 = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspaso")
        Me.MnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuTraspaso = New Janus.Windows.UI.CommandBars.UICommand("MnuTraspaso")
        Me.MnuSalir = New Janus.Windows.UI.CommandBars.UICommand("MnuSalir")
        Me.MnuNuevo = New Janus.Windows.UI.CommandBars.UICommand("MnuNuevo")
        Me.MnuBusquedaNombre = New Janus.Windows.UI.CommandBars.UICommand("MnuBusquedaNombre")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.rbCardID = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.explorador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorador.SuspendLayout()
        CType(Me.Activación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Activación.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.cmmMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorador
        '
        Me.explorador.Controls.Add(Me.cmbTipoOperacion)
        Me.explorador.Controls.Add(Me.lblTipoTarjeta)
        Me.explorador.Controls.Add(Me.txtPlayer)
        Me.explorador.Controls.Add(Me.txtNombrePlayer)
        Me.explorador.Controls.Add(Me.lblPlayer)
        Me.explorador.Controls.Add(Me.cmbFecha)
        Me.explorador.Controls.Add(Me.lblFecha)
        Me.explorador.Dock = System.Windows.Forms.DockStyle.Top
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Key = "groupDatosGenerales"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.explorador.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorador.Location = New System.Drawing.Point(0, 28)
        Me.explorador.Name = "explorador"
        Me.explorador.Size = New System.Drawing.Size(544, 102)
        Me.explorador.TabIndex = 1
        Me.explorador.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbTipoOperacion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbTipoOperacion.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTipoOperacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbTipoOperacion.Cursor = System.Windows.Forms.Cursors.Default
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbTipoOperacion.DesignTimeLayout = GridEXLayout1
        Me.cmbTipoOperacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(104, 32)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(208, 23)
        Me.cmbTipoOperacion.TabIndex = 5
        Me.cmbTipoOperacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoOperacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTipoTarjeta
        '
        Me.lblTipoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTarjeta.Location = New System.Drawing.Point(8, 32)
        Me.lblTipoTarjeta.Name = "lblTipoTarjeta"
        Me.lblTipoTarjeta.Size = New System.Drawing.Size(88, 16)
        Me.lblTipoTarjeta.TabIndex = 222
        Me.lblTipoTarjeta.Text = "Transacción:"
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
        Me.txtPlayer.Location = New System.Drawing.Point(104, 64)
        Me.txtPlayer.MaxLength = 8
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(96, 22)
        Me.txtPlayer.TabIndex = 3
        Me.txtPlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNombrePlayer
        '
        Me.txtNombrePlayer.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNombrePlayer.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNombrePlayer.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombrePlayer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombrePlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombrePlayer.Location = New System.Drawing.Point(200, 64)
        Me.txtNombrePlayer.Name = "txtNombrePlayer"
        Me.txtNombrePlayer.ReadOnly = True
        Me.txtNombrePlayer.Size = New System.Drawing.Size(336, 21)
        Me.txtNombrePlayer.TabIndex = 4
        Me.txtNombrePlayer.TabStop = False
        Me.txtNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblPlayer
        '
        Me.lblPlayer.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.Location = New System.Drawing.Point(8, 64)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(72, 16)
        Me.lblPlayer.TabIndex = 220
        Me.lblPlayer.Text = "Player:"
        '
        'cmbFecha
        '
        Me.cmbFecha.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.Location = New System.Drawing.Point(384, 38)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.ReadOnly = True
        Me.cmbFecha.Size = New System.Drawing.Size(120, 22)
        Me.cmbFecha.TabIndex = 2
        Me.cmbFecha.TabStop = False
        Me.cmbFecha.TodayButtonText = "Hoy"
        Me.cmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(328, 40)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(56, 16)
        Me.lblFecha.TabIndex = 216
        Me.lblFecha.Text = "Fecha:"
        '
        'Activación
        '
        Me.Activación.Controls.Add(Me.ExplorerBar1)
        Me.Activación.Controls.Add(Me.btnTraspaso)
        Me.Activación.Controls.Add(Me.btnLeerDPCardCredit)
        Me.Activación.Controls.Add(Me.lblDPCardCredit)
        Me.Activación.Controls.Add(Me.lblCardID)
        Me.Activación.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Key = "grpActivacion"
        ExplorerBarGroup3.Text = "Activación"
        Me.Activación.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.Activación.Location = New System.Drawing.Point(0, 130)
        Me.Activación.Name = "Activación"
        Me.Activación.Size = New System.Drawing.Size(544, 228)
        Me.Activación.TabIndex = 2
        Me.Activación.Text = "ExplorerBar1"
        Me.Activación.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.lblDeslizarTarjeta)
        Me.ExplorerBar1.Controls.Add(Me.lblVerificar)
        Me.ExplorerBar1.Controls.Add(Me.txtSaldoTotal)
        Me.ExplorerBar1.Controls.Add(Me.lblSaldoTotal)
        Me.ExplorerBar1.Controls.Add(Me.txtTotalPuntos)
        Me.ExplorerBar1.Controls.Add(Me.btnTraspasos)
        Me.ExplorerBar1.Controls.Add(Me.btnDPCardCredit)
        Me.ExplorerBar1.Controls.Add(Me.txtNuevaDPCardId)
        Me.ExplorerBar1.Controls.Add(Me.lblDPCardCreditID)
        Me.ExplorerBar1.Controls.Add(Me.lblDPCardId)
        Me.ExplorerBar1.Controls.Add(Me.lblTotalPuntos)
        Me.ExplorerBar1.Controls.Add(Me.btnSalir)
        Me.ExplorerBar1.Controls.Add(Me.txtCardID)
        Me.ExplorerBar1.Controls.Add(Me.btnLeerDPCard)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "grpActivacion"
        ExplorerBarGroup2.Text = "Activación"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(544, 228)
        Me.ExplorerBar1.TabIndex = 236
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblDeslizarTarjeta
        '
        Me.lblDeslizarTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.lblDeslizarTarjeta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeslizarTarjeta.Location = New System.Drawing.Point(8, 120)
        Me.lblDeslizarTarjeta.Name = "lblDeslizarTarjeta"
        Me.lblDeslizarTarjeta.Size = New System.Drawing.Size(264, 16)
        Me.lblDeslizarTarjeta.TabIndex = 240
        Me.lblDeslizarTarjeta.Text = "Favor de deslizar la nueva Tarjeta..."
        '
        'lblVerificar
        '
        Me.lblVerificar.BackColor = System.Drawing.Color.Transparent
        Me.lblVerificar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerificar.Location = New System.Drawing.Point(328, 40)
        Me.lblVerificar.Name = "lblVerificar"
        Me.lblVerificar.Size = New System.Drawing.Size(192, 16)
        Me.lblVerificar.TabIndex = 239
        Me.lblVerificar.Text = "Verificando"
        Me.lblVerificar.Visible = False
        '
        'txtSaldoTotal
        '
        Me.txtSaldoTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtSaldoTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtSaldoTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtSaldoTotal.Location = New System.Drawing.Point(104, 88)
        Me.txtSaldoTotal.Name = "txtSaldoTotal"
        Me.txtSaldoTotal.Size = New System.Drawing.Size(96, 20)
        Me.txtSaldoTotal.TabIndex = 9
        Me.txtSaldoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtSaldoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblSaldoTotal
        '
        Me.lblSaldoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoTotal.Location = New System.Drawing.Point(8, 88)
        Me.lblSaldoTotal.Name = "lblSaldoTotal"
        Me.lblSaldoTotal.Size = New System.Drawing.Size(96, 16)
        Me.lblSaldoTotal.TabIndex = 237
        Me.lblSaldoTotal.Text = "Saldo Total:"
        '
        'txtTotalPuntos
        '
        Me.txtTotalPuntos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtTotalPuntos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtTotalPuntos.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalPuntos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPuntos.Location = New System.Drawing.Point(104, 64)
        Me.txtTotalPuntos.Name = "txtTotalPuntos"
        Me.txtTotalPuntos.ReadOnly = True
        Me.txtTotalPuntos.Size = New System.Drawing.Size(96, 21)
        Me.txtTotalPuntos.TabIndex = 8
        Me.txtTotalPuntos.TabStop = False
        Me.txtTotalPuntos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtTotalPuntos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnTraspasos
        '
        Me.btnTraspasos.Image = CType(resources.GetObject("btnTraspasos.Image"), System.Drawing.Image)
        Me.btnTraspasos.Location = New System.Drawing.Point(344, 176)
        Me.btnTraspasos.Name = "btnTraspasos"
        Me.btnTraspasos.Size = New System.Drawing.Size(88, 32)
        Me.btnTraspasos.TabIndex = 12
        Me.btnTraspasos.Text = "Realizar Traspaso"
        Me.btnTraspasos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnDPCardCredit
        '
        Me.btnDPCardCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDPCardCredit.Icon = CType(resources.GetObject("btnDPCardCredit.Icon"), System.Drawing.Icon)
        Me.btnDPCardCredit.Location = New System.Drawing.Point(304, 144)
        Me.btnDPCardCredit.Name = "btnDPCardCredit"
        Me.btnDPCardCredit.Size = New System.Drawing.Size(40, 22)
        Me.btnDPCardCredit.TabIndex = 11
        Me.btnDPCardCredit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtNuevaDPCardId
        '
        Me.txtNuevaDPCardId.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtNuevaDPCardId.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtNuevaDPCardId.BackColor = System.Drawing.SystemColors.Info
        Me.txtNuevaDPCardId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNuevaDPCardId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevaDPCardId.Location = New System.Drawing.Point(128, 144)
        Me.txtNuevaDPCardId.Name = "txtNuevaDPCardId"
        Me.txtNuevaDPCardId.ReadOnly = True
        Me.txtNuevaDPCardId.Size = New System.Drawing.Size(176, 21)
        Me.txtNuevaDPCardId.TabIndex = 10
        Me.txtNuevaDPCardId.TabStop = False
        Me.txtNuevaDPCardId.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtNuevaDPCardId.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDPCardCreditID
        '
        Me.lblDPCardCreditID.BackColor = System.Drawing.Color.Transparent
        Me.lblDPCardCreditID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPCardCreditID.Location = New System.Drawing.Point(8, 144)
        Me.lblDPCardCreditID.Name = "lblDPCardCreditID"
        Me.lblDPCardCreditID.Size = New System.Drawing.Size(128, 16)
        Me.lblDPCardCreditID.TabIndex = 230
        Me.lblDPCardCreditID.Text = "DPCard Credit ID:"
        '
        'lblDPCardId
        '
        Me.lblDPCardId.BackColor = System.Drawing.Color.Transparent
        Me.lblDPCardId.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPCardId.Location = New System.Drawing.Point(8, 40)
        Me.lblDPCardId.Name = "lblDPCardId"
        Me.lblDPCardId.Size = New System.Drawing.Size(80, 16)
        Me.lblDPCardId.TabIndex = 227
        Me.lblDPCardId.Text = "DPCard ID:"
        '
        'lblTotalPuntos
        '
        Me.lblTotalPuntos.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPuntos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPuntos.Location = New System.Drawing.Point(8, 64)
        Me.lblTotalPuntos.Name = "lblTotalPuntos"
        Me.lblTotalPuntos.Size = New System.Drawing.Size(96, 16)
        Me.lblTotalPuntos.TabIndex = 235
        Me.lblTotalPuntos.Text = "Total Puntos:"
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(440, 176)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(88, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'txtCardID
        '
        Me.txtCardID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.txtCardID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.txtCardID.BackColor = System.Drawing.SystemColors.Info
        Me.txtCardID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCardID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardID.Location = New System.Drawing.Point(104, 40)
        Me.txtCardID.Name = "txtCardID"
        Me.txtCardID.ReadOnly = True
        Me.txtCardID.Size = New System.Drawing.Size(176, 21)
        Me.txtCardID.TabIndex = 6
        Me.txtCardID.TabStop = False
        Me.txtCardID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCardID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(280, 40)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 7
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnTraspaso
        '
        Me.btnTraspaso.Location = New System.Drawing.Point(368, 120)
        Me.btnTraspaso.Name = "btnTraspaso"
        Me.btnTraspaso.Size = New System.Drawing.Size(75, 32)
        Me.btnTraspaso.TabIndex = 234
        Me.btnTraspaso.Text = "Realizar Traspaso"
        Me.btnTraspaso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btnLeerDPCardCredit
        '
        Me.btnLeerDPCardCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCardCredit.Icon = CType(resources.GetObject("btnLeerDPCardCredit.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCardCredit.Location = New System.Drawing.Point(320, 184)
        Me.btnLeerDPCardCredit.Name = "btnLeerDPCardCredit"
        Me.btnLeerDPCardCredit.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCardCredit.TabIndex = 232
        Me.btnLeerDPCardCredit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'lblDPCardCredit
        '
        Me.lblDPCardCredit.BackColor = System.Drawing.Color.Transparent
        Me.lblDPCardCredit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPCardCredit.Location = New System.Drawing.Point(8, 184)
        Me.lblDPCardCredit.Name = "lblDPCardCredit"
        Me.lblDPCardCredit.Size = New System.Drawing.Size(128, 16)
        Me.lblDPCardCredit.TabIndex = 230
        Me.lblDPCardCredit.Text = "DPCard Credit ID:"
        '
        'lblCardID
        '
        Me.lblCardID.BackColor = System.Drawing.Color.Transparent
        Me.lblCardID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardID.Location = New System.Drawing.Point(8, 40)
        Me.lblCardID.Name = "lblCardID"
        Me.lblCardID.Size = New System.Drawing.Size(80, 16)
        Me.lblCardID.TabIndex = 227
        Me.lblCardID.Text = "DPCard ID:"
        '
        'cmmMenu
        '
        Me.cmmMenu.BottomRebar = Me.BottomRebar1
        Me.cmmMenu.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.cmmMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuTraspaso, Me.MnuSalir, Me.MnuNuevo, Me.MnuBusquedaNombre})
        Me.cmmMenu.ContainerControl = Me
        '
        '
        '
        Me.cmmMenu.EditContextMenu.Key = ""
        Me.cmmMenu.Id = New System.Guid("972681e8-e034-45c7-82d4-4722b58cb9ad")
        Me.cmmMenu.LeftRebar = Me.LeftRebar1
        Me.cmmMenu.LockCommandBars = True
        Me.cmmMenu.RightRebar = Me.RightRebar1
        Me.cmmMenu.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.cmmMenu.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.cmmMenu.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.cmmMenu
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 350)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(544, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.cmmMenu
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MnuNuevo1, Me.MnuBusquedaNombre1, Me.MnuTraspaso1, Me.MnuSalir1})
        Me.UiCommandBar1.Key = "MnuTraspaso"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(307, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'MnuNuevo1
        '
        Me.MnuNuevo1.Image = CType(resources.GetObject("MnuNuevo1.Image"), System.Drawing.Image)
        Me.MnuNuevo1.Key = "MnuNuevo"
        Me.MnuNuevo1.Name = "MnuNuevo1"
        '
        'MnuBusquedaNombre1
        '
        Me.MnuBusquedaNombre1.Image = CType(resources.GetObject("MnuBusquedaNombre1.Image"), System.Drawing.Image)
        Me.MnuBusquedaNombre1.Key = "MnuBusquedaNombre"
        Me.MnuBusquedaNombre1.Name = "MnuBusquedaNombre1"
        '
        'MnuTraspaso1
        '
        Me.MnuTraspaso1.Image = CType(resources.GetObject("MnuTraspaso1.Image"), System.Drawing.Image)
        Me.MnuTraspaso1.Key = "MnuTraspaso"
        Me.MnuTraspaso1.Name = "MnuTraspaso1"
        '
        'MnuSalir1
        '
        Me.MnuSalir1.Image = CType(resources.GetObject("MnuSalir1.Image"), System.Drawing.Image)
        Me.MnuSalir1.Key = "MnuSalir"
        Me.MnuSalir1.Name = "MnuSalir1"
        '
        'MnuTraspaso
        '
        Me.MnuTraspaso.Key = "MnuTraspaso"
        Me.MnuTraspaso.Name = "MnuTraspaso"
        Me.MnuTraspaso.Text = "Traspaso"
        '
        'MnuSalir
        '
        Me.MnuSalir.Key = "MnuSalir"
        Me.MnuSalir.Name = "MnuSalir"
        Me.MnuSalir.Text = "Salir"
        '
        'MnuNuevo
        '
        Me.MnuNuevo.Key = "MnuNuevo"
        Me.MnuNuevo.Name = "MnuNuevo"
        Me.MnuNuevo.Text = "Nuevo"
        '
        'MnuBusquedaNombre
        '
        Me.MnuBusquedaNombre.Key = "MnuBusquedaNombre"
        Me.MnuBusquedaNombre.Name = "MnuBusquedaNombre"
        Me.MnuBusquedaNombre.Text = "Buscar DPCard"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.cmmMenu
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 130)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 220)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.cmmMenu
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(544, 130)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 220)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.cmmMenu
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(544, 28)
        '
        'rbCardID
        '
        Me.rbCardID.BackColor = System.Drawing.Color.Transparent
        Me.rbCardID.Location = New System.Drawing.Point(48, 40)
        Me.rbCardID.Name = "rbCardID"
        Me.rbCardID.Size = New System.Drawing.Size(144, 16)
        Me.rbCardID.TabIndex = 241
        Me.rbCardID.Text = "UiRadioButton1"
        Me.rbCardID.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'frmDPCardPuntosTraspaso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(544, 358)
        Me.Controls.Add(Me.Activación)
        Me.Controls.Add(Me.explorador)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDPCardPuntosTraspaso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso de Puntos"
        CType(Me.explorador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorador.ResumeLayout(False)
        Me.explorador.PerformLayout()
        CType(Me.Activación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Activación.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.cmmMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private m_dtOperaciones As DataTable
    Private m_dtTipoTarjeta As DataTable
    Private m_dtTransactionType As DataTable
    Private oVendedoresMgr As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager
    Private oVendedor As DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.Vendedor
    Private oSAPMgr As DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU.ProcesoSAPManager
#End Region

#Region "Propiedades"
    Public Property DTOperaciones() As DataTable
        Get
            Return m_dtOperaciones
        End Get
        Set(ByVal Value As DataTable)
            m_dtOperaciones = Value
        End Set
    End Property

    Public Property DTTipoTarjetas() As DataTable
        Get
            Return m_dtTipoTarjeta
        End Get
        Set(ByVal Value As DataTable)
            m_dtTipoTarjeta = Value
        End Set
    End Property

    Public Property dtTransactionType() As DataTable
        Get
            Return m_dtTransactionType
        End Get
        Set(ByVal Value As DataTable)
            m_dtTransactionType = Value
        End Set
    End Property
#End Region

#Region "Metodos Eventos Form"

    Private Sub txtCardID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCardID.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub txtNuevaDPCardId_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNuevaDPCardId.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub btnLeerDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerDPCard.Click
        LeerDatosPinPad(Me.txtCardID.Text, True)
    End Sub

    Private Sub txtNuevaDPCardId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNuevaDPCardId.KeyDown
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub txtCardID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCardID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ValidateDPCardPunto()
        End If
    End Sub

    Private Sub btnDPCardCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDPCardCredit.Click
        LeerDatosPinPad(Me.txtNuevaDPCardId.Text)
    End Sub


    Private Sub txtPlayer_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub txtPlayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlayer.KeyDown
        If e.KeyCode = Keys.Enter Then
            CargarPlayer()
        End If
    End Sub

    Private Sub txtPlayer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPlayer.Validating
        CargarPlayer()
    End Sub

    Private Sub btnTraspasos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraspasos.Click
        SelectOperation()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmmMenu_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles cmmMenu.CommandClick
        Select Case e.Command.Key
            Case "MnuNuevo"
                NewTraspaso()
            Case "MnuBusquedaNombre"
                Busqueda()
            Case "MnuTraspaso"
                SelectOperation()
            Case "MnuSalir"
                Me.Dispose()
        End Select
    End Sub

    Private Sub cmbTipoOperacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoOperacion.ValueChanged
        Select Case cmbTipoOperacion.Value
            Case "105"
                Me.lblDPCardCreditID.Text = "DPCard Credit ID"
            Case Else
                Me.lblDPCardCreditID.Text = "Nueva DPCardID"
        End Select
    End Sub

#End Region

#Region "Metodos Traspasos"

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Se lectura por medio de la pin pad.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub LeerDatosPinPad(ByRef tarjeta As String, Optional ByVal validar As Boolean = True)
        Dim valido As Boolean = False
        '------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 01/04/2015: Leemos datos de DPCard Puntos con la Pinpad
        '------------------------------------------------------------------------------------------------------------------------
        If validar = True Then
            Me.lblVerificar.Visible = True
            Me.lblVerificar.Text = "Verificando..."
        End If
        '--------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 21/02/2017: Se valida si son pagos banamex para lecturarlos por su pinpad si no la de Bancomer
        '--------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.PagosBanamex = True Then
            Dim pinpad As New Pinpad.Pinpad()
            Dim bin As String = ""
            'Dim code As String = pinpad.LeerTarjeta("1.00".Replace(",", ""), "0.00", "0", "00")
            Dim code As String = pinpad.LeerTarjeta(CDec(1).ToString("##,##0.00").Replace(",", ""), "0.00", "0", "00")
            If code.Trim() <> "10" AndAlso code.Trim() <> "40" Then
                Dim Name As String = pinpad.getAppLabel()
                bin = pinpad.getCardNumber(code)
                tarjeta = bin
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
                If validar = True Then
                    If ValidateDPCardPunto() = True Then
                        Me.lblVerificar.Visible = False
                    End If
                End If
            Else
                Me.DialogResult = DialogResult.Cancel
                MessageBox.Show("Hubo un error al lecturar la tarjeta DPCard", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '----------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 21/02/2017: Enviamos mensaje de transacción exitosa a la pinpad
                '----------------------------------------------------------------------------------------------------------------
                pinpad.Respuesta("0", "", "")
                pinpad.ClosePort()
                pinpad.sp.Dispose()
            End If 
        Else
            Dim oOtrosPagos As New OtrosPagos
            valido = oOtrosPagos.LeerDatosDPCard(tarjeta)
            If valido = False Then
                Me.DialogResult = DialogResult.Cancel
                MessageBox.Show("Hubo un error al lecturar la tarjeta DPCard", "DPPRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If validar = True Then
                    If ValidateDPCardPunto() = True Then
                        Me.lblVerificar.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Se Crean las operaciones a realizar
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub CreateOperaciones()

        '-----------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 24/04/2015: Cargandos los tipos de operaciones
        '-----------------------------------------------------------------------------------------------------------------------
        Me.dtTransactionType = New DataTable
        Me.dtTransactionType.Columns.Add("CodTipoOperacion", GetType(String))
        Me.dtTransactionType.Columns.Add("TipoOperacion", GetType(String))
        Me.dtTransactionType.AcceptChanges()

        Dim row As DataRow = Me.dtTransactionType.NewRow()
        row("CodTipoOperacion") = "102"
        row("TipoOperacion") = "Traspaso por tarjeta Dañada"
        Me.dtTransactionType.Rows.Add(row)

        row = Me.dtTransactionType.NewRow()
        row("CodTipoOperacion") = "103"
        row("TipoOperacion") = "Traspaso por tarjeta extraviada o robada"
        Me.dtTransactionType.Rows.Add(row)

        row = Me.dtTransactionType.NewRow()
        row("CodTipoOperacion") = "105"
        row("TipoOperacion") = "Traspaso por cambio a Dpcard Credit"
        Me.dtTransactionType.Rows.Add(row)

        Me.cmbTipoOperacion.DataSource = Nothing
        Me.cmbTipoOperacion.DataSource = Me.dtTransactionType
        Me.cmbTipoOperacion.ValueMember = "CodTipoOperacion"
        Me.cmbTipoOperacion.DisplayMember = "TipoOperacion"

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Busqueda de Player por medio de Nombre y apellido.
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

            If oOpenRecordDialogView.pbNombre <> String.Empty Then

                txtPlayer.Text = oOpenRecordDialogView.pbCodigo
                txtNombrePlayer.Text = oOpenRecordDialogView.pbNombre

            Else

                txtPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                txtNombrePlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")

            End If
            Me.txtCardID.ReadOnly = False
            Me.txtCardID.Focus()
        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Carga y valida que el player pertenezca a la tienda.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub CargarPlayer()
        If oConfigCierreFI.ShowManagerPC AndAlso txtPlayer.Text.Trim = "" Then
            Me.txtPlayer.Focus()
            Return
        End If

        If txtPlayer.Text.Trim <> "" Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(txtPlayer.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)

                'If strRes.Trim = "0" Then
                '    MessageBox.Show("Código de Vendedor NO EXISTE.  ", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.txtNombrePlayer.Text = ""
                '    Return
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.txtNombrePlayer.Text = ""
                'Else
                Me.txtNombrePlayer.Text = oVendedor.Nombre
                Me.txtCardID.ReadOnly = False
                Me.txtCardID.Focus()
                'End If
            End If
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Inicializa valores por default en el formulario
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Inicializar()
        oSAPMgr = New DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU.ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oVendedoresMgr = New DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores.CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create()
        Me.cmbFecha.Value = DateTime.Now
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Realiza el traspaso de Puntos de una tarjeta a otra.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Traspaso()
        Try
            If Me.txtCardID.Text.Trim() <> "" AndAlso Me.txtNuevaDPCardId.Text.Trim() <> "" AndAlso Me.cmbTipoOperacion.Value <> "" Then
                Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
                Dim ws As New WSBroker("WS_BLUE", True)
                Dim params As New Hashtable
                Dim resultado As Hashtable
                oVendedor.ClearFields()
                oVendedoresMgr.LoadInto(Me.txtPlayer.Text.Trim(), oVendedor)
                params("CardId") = Me.txtNuevaDPCardId.Text.Trim()
                params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
                params("OldCardId") = Me.txtCardID.Text.Trim()
                '-----------------------------------------------------------------------------
                'JNAVA (08.12.2015): Correccion de Almacen (storeID)
                '-----------------------------------------------------------------------------
                params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
                'params("StoreId") = "004"
                '-----------------------------------------------------------------------------
                params("ReferenceId3") = ""
                params("ReferenceId4") = ""
                params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
                params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
                params("SupervisorCode") = Me.txtPlayer.Text.Trim()
                params("SupervisorName") = oVendedor.Nombre
                params("SellerCode") = Me.txtPlayer.Text.Trim()
                params("SellerName") = oVendedor.Nombre
                params("TransactionTypeId") = cmbTipoOperacion.Value
                resultado = ws.TransferPoints(params)
                If resultado.Count > 0 Then
                    If resultado.ContainsKey("ResultID") = True Then
                        If CInt(resultado("ResultID")) > 0 Then
                            PrintHashtable(resultado)
                            resultado("OldCardId") = Me.txtCardID.Text.Trim()
                            resultado("NewCardId") = Me.txtNuevaDPCardId.Text.Trim()
                            PrintTicketDPCardPuntos(resultado)
                            MessageBox.Show("Se realizo el traspaso de puntos de " & Me.txtCardID.Text.Trim() & " a " & Me.txtNuevaDPCardId.Text, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            NewTraspaso()
                        Else
                            MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            NewTraspaso()
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Debe deslizar la tarjeta anterior y la nueva para poder realizar el traspaso", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al traspasar los puntos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Renueva la tarjeta DPCard Puntos
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub RenewMembership()
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        resultado = ws.RenewMembership(params)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("ResultId") = True Then
                If CInt(resultado("ResultId")) > 0 Then
                    resultado("CodVendedor") = Me.txtPlayer.Text.Trim()
                    PrintRenewMembership(resultado)
                Else
                    MessageBox.Show(CStr(resultado("Descripcion")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Hubo un error al ejecutar la renovacion DPCard Puntos", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Valida que la tarjeta a realizar el traspaso sea valida
    '--------------------------------------------------------------------------------------------------------------------------

    Private Function ValidateDPCardPunto() As Boolean
        Dim valido As Boolean = False
        Dim ws As New WSBroker("WS_BLUE", True)
        Dim params As New Hashtable
        Dim resultado As Hashtable
        Dim fecha As DateTime = oSAPMgr.MSS_GET_SY_DATE_TIME()
        oVendedor.ClearFields()
        oVendedoresMgr.LoadInto(Me.txtPlayer.Text.Trim(), oVendedor)
        params("CardId") = Me.txtCardID.Text.Trim()
        params("TransactionDate") = fecha.ToString("yyyy-MM-dd") & "T" & fecha.ToString("HH:mm:ss")
        params("TicketId") = "0"
        '-----------------------------------------------------------------------------
        'JNAVA (08.12.2015): Correccion de Almacen (storeID)
        '-----------------------------------------------------------------------------
        params("StoreId") = oAppContext.ApplicationConfiguration.Almacen
        'params("StoreId") = "004"
        '-----------------------------------------------------------------------------
        params("ReferenceId3") = ""
        params("ReferenceId4") = ""
        params("CashierCode") = oAppContext.ApplicationConfiguration.NoCaja
        params("CashierName") = oAppContext.ApplicationConfiguration.NoCaja
        params("SupervisorCode") = Me.txtPlayer.Text.Trim()
        params("SupervisorName") = oVendedor.Nombre
        params("SellerCode") = Me.txtPlayer.Text.Trim()
        params("SellerName") = oVendedor.Nombre
        params("NoAssigned1") = ""
        params("NoAssigned2") = ""
        resultado = ws.ValidateDPCardPuntos(params)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("ResultID") = True Then
                If CInt(resultado("ResultID")) > 0 Then
                    valido = True
                    Me.txtTotalPuntos.Text = CStr(resultado("TotalPoints"))
                    Me.txtSaldoTotal.Value = CDec(resultado("TotalPointsInCash"))
                    Me.txtNuevaDPCardId.ReadOnly = False
                    Me.txtNuevaDPCardId.Focus()
                Else
                    If CInt(resultado("ResultID")) = -4 Or CInt(resultado("ResultID")) = -6 Then
                        valido = True
                        Me.txtTotalPuntos.Text = CStr(resultado("TotalPoints"))
                        Me.txtSaldoTotal.Value = CDec(resultado("TotalPointsInCash"))
                        Me.txtNuevaDPCardId.ReadOnly = False
                        Me.txtNuevaDPCardId.Focus()
                    Else
                        MessageBox.Show(CStr(resultado("Description")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If

                End If
            End If
        End If
        Return valido
    End Function

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 17/04/2015: Impresión de los traspasos de punto de la tarjeta DPCard Puntos de Blue Engine.
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintTicketDPCardPuntos(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptTraspasoDPCardPunto(datos)
        With rptActivaciondpCard
            .Document.Name = "Activacion DPCard Puntos"
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

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Impresión de Renovación de membresia de DPCard Puntos
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub PrintRenewMembership(ByVal datos As Hashtable)
        Dim rptActivaciondpCard As New rptRenewMembership(datos)
        With rptActivaciondpCard
            .Document.Name = "Activacion DPCard Puntos"
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

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Realiza un nuevo traspaso de puntos o renovación de membresia.
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub NewTraspaso()
        Me.txtPlayer.Text = ""
        Me.txtCardID.Text = ""
        Me.txtNuevaDPCardId.Text = ""
        Me.txtNombrePlayer.Text = ""
        Me.lblDPCardCreditID.Text = "DPCard Id:"
        Me.txtTotalPuntos.Text = ""
        Me.cmbTipoOperacion.Value = ""
        Me.txtSaldoTotal.Value = 0
        Me.txtCardID.ReadOnly = True
        Me.txtNuevaDPCardId.ReadOnly = True
        Me.lblVerificar.Visible = False
        Me.cmbFecha.Value = DateTime.Now
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/04/2015: Seleccionar la acción a realizar Traspaso de Puntos o Renovación
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub SelectOperation()
        If cmbTipoOperacion.Value <> "" Then
            Traspaso()
        Else
            MessageBox.Show("Tiene que seleccionar una operación", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/04/2015: Busqueda de Tarjeta por medio del apellido paterno y los ultimos 4 digitos del telefono
    '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Busqueda()
        Dim frmSearch As New frmDPCardPuntoSearch
        frmSearch.ShowDialog()
        If frmSearch.DialogResult = DialogResult.OK Then
            Me.txtCardID.Text = frmSearch.CardId
        End If
    End Sub

    Private Sub PrintHashtable(ByVal result As Hashtable)
        For Each str As String In result.Keys
            Console.WriteLine(str & ": " & CStr(result(str)))
        Next
    End Sub

#End Region

    
End Class
