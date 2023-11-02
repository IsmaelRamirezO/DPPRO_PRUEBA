Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU

Public Class frmCancelarOtrosPagos
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
    Friend WithEvents exDatosGenerales As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents cmbConceptoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebPlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombrePlayer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebBackground As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnCancelarPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents exBotones As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents exAbonosDPCard As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents Limpiar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CancelarPago1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebSaldoDPC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebDPCard As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaPagoDPC As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebFolioPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents menuLimpiar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCancelarPago As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ebClienteDPC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnLeerDPCard As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblValidaDPCard As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarOtrosPagos))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.ebBackground = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.exBotones = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnCancelarPago = New Janus.Windows.EditControls.UIButton()
        Me.exDatosGenerales = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbConceptoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ebPlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebNombrePlayer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.exAbonosDPCard = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.lblValidaDPCard = New System.Windows.Forms.Label()
        Me.btnLeerDPCard = New Janus.Windows.EditControls.UIButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebClienteDPC = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbFechaPagoDPC = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ebFolioPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebSaldoDPC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ebDPCard = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.Limpiar1 = New Janus.Windows.UI.CommandBars.UICommand("menuLimpiar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.CancelarPago1 = New Janus.Windows.UI.CommandBars.UICommand("menuCancelarPago")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Salir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuLimpiar = New Janus.Windows.UI.CommandBars.UICommand("menuLimpiar")
        Me.menuCancelarPago = New Janus.Windows.UI.CommandBars.UICommand("menuCancelarPago")
        Me.MenuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ebBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ebBackground.SuspendLayout()
        CType(Me.exBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exBotones.SuspendLayout()
        CType(Me.exDatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exDatosGenerales.SuspendLayout()
        CType(Me.exAbonosDPCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.exAbonosDPCard.SuspendLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ebBackground
        '
        Me.ebBackground.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ebBackground.Controls.Add(Me.exBotones)
        Me.ebBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ebBackground.Location = New System.Drawing.Point(0, 28)
        Me.ebBackground.Name = "ebBackground"
        Me.ebBackground.Size = New System.Drawing.Size(714, 316)
        Me.ebBackground.TabIndex = 0
        Me.ebBackground.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'exBotones
        '
        Me.exBotones.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exBotones.Controls.Add(Me.btnCancelarPago)
        Me.exBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.exBotones.Location = New System.Drawing.Point(0, 244)
        Me.exBotones.Name = "exBotones"
        Me.exBotones.Size = New System.Drawing.Size(714, 72)
        Me.exBotones.TabIndex = 2
        Me.exBotones.Text = "ExplorerBar2"
        Me.exBotones.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnCancelarPago
        '
        Me.btnCancelarPago.Enabled = False
        Me.btnCancelarPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarPago.Icon = CType(resources.GetObject("btnCancelarPago.Icon"), System.Drawing.Icon)
        Me.btnCancelarPago.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnCancelarPago.Location = New System.Drawing.Point(277, 16)
        Me.btnCancelarPago.Name = "btnCancelarPago"
        Me.btnCancelarPago.Size = New System.Drawing.Size(160, 40)
        Me.btnCancelarPago.TabIndex = 3
        Me.btnCancelarPago.Text = "Cancelar Pago"
        Me.btnCancelarPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'exDatosGenerales
        '
        Me.exDatosGenerales.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exDatosGenerales.Controls.Add(Me.cmbConceptoPago)
        Me.exDatosGenerales.Controls.Add(Me.Label6)
        Me.exDatosGenerales.Controls.Add(Me.cmbFecha)
        Me.exDatosGenerales.Controls.Add(Me.ebPlayer)
        Me.exDatosGenerales.Controls.Add(Me.ebNombrePlayer)
        Me.exDatosGenerales.Controls.Add(Me.Label5)
        Me.exDatosGenerales.Controls.Add(Me.Label4)
        Me.exDatosGenerales.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.exDatosGenerales.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.exDatosGenerales.Location = New System.Drawing.Point(0, 24)
        Me.exDatosGenerales.Name = "exDatosGenerales"
        Me.exDatosGenerales.Size = New System.Drawing.Size(712, 112)
        Me.exDatosGenerales.TabIndex = 0
        Me.exDatosGenerales.Text = "ExplorerBar1"
        Me.exDatosGenerales.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbConceptoPago
        '
        Me.cmbConceptoPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbConceptoPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbConceptoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        Me.cmbConceptoPago.Cursor = System.Windows.Forms.Cursors.Default
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbConceptoPago.DesignTimeLayout = GridEXLayout1
        Me.cmbConceptoPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConceptoPago.Location = New System.Drawing.Point(144, 40)
        Me.cmbConceptoPago.Name = "cmbConceptoPago"
        Me.cmbConceptoPago.Size = New System.Drawing.Size(184, 23)
        Me.cmbConceptoPago.TabIndex = 0
        Me.cmbConceptoPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbConceptoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 216
        Me.Label6.Text = "Concepto de Pago:"
        '
        'cmbFecha
        '
        Me.cmbFecha.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.Location = New System.Drawing.Point(568, 40)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.ReadOnly = True
        Me.cmbFecha.Size = New System.Drawing.Size(120, 22)
        Me.cmbFecha.TabIndex = 213
        Me.cmbFecha.TabStop = False
        Me.cmbFecha.TodayButtonText = "Hoy"
        Me.cmbFecha.Value = New Date(2022, 6, 16, 0, 0, 0, 0)
        Me.cmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
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
        Me.ebPlayer.Location = New System.Drawing.Point(144, 72)
        Me.ebPlayer.MaxLength = 10
        Me.ebPlayer.Name = "ebPlayer"
        Me.ebPlayer.Size = New System.Drawing.Size(96, 22)
        Me.ebPlayer.TabIndex = 1
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
        Me.ebNombrePlayer.Location = New System.Drawing.Point(248, 72)
        Me.ebNombrePlayer.Name = "ebNombrePlayer"
        Me.ebNombrePlayer.ReadOnly = True
        Me.ebNombrePlayer.Size = New System.Drawing.Size(440, 21)
        Me.ebNombrePlayer.TabIndex = 3
        Me.ebNombrePlayer.TabStop = False
        Me.ebNombrePlayer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePlayer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "Player:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(512, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Fecha:"
        '
        'exAbonosDPCard
        '
        Me.exAbonosDPCard.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.exAbonosDPCard.Controls.Add(Me.lblValidaDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.btnLeerDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.Label17)
        Me.exAbonosDPCard.Controls.Add(Me.ebClienteDPC)
        Me.exAbonosDPCard.Controls.Add(Me.cmbFechaPagoDPC)
        Me.exAbonosDPCard.Controls.Add(Me.Label1)
        Me.exAbonosDPCard.Controls.Add(Me.ebFolioPago)
        Me.exAbonosDPCard.Controls.Add(Me.ebSaldoDPC)
        Me.exAbonosDPCard.Controls.Add(Me.Label15)
        Me.exAbonosDPCard.Controls.Add(Me.ebDPCard)
        Me.exAbonosDPCard.Controls.Add(Me.Label16)
        Me.exAbonosDPCard.Controls.Add(Me.Label2)
        Me.exAbonosDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Cancelación de Abonos de DP Card"
        Me.exAbonosDPCard.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.exAbonosDPCard.Location = New System.Drawing.Point(0, 136)
        Me.exAbonosDPCard.Name = "exAbonosDPCard"
        Me.exAbonosDPCard.Size = New System.Drawing.Size(712, 136)
        Me.exAbonosDPCard.TabIndex = 1
        Me.exAbonosDPCard.Visible = False
        Me.exAbonosDPCard.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'lblValidaDPCard
        '
        Me.lblValidaDPCard.AutoSize = True
        Me.lblValidaDPCard.BackColor = System.Drawing.Color.Transparent
        Me.lblValidaDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidaDPCard.ForeColor = System.Drawing.Color.Red
        Me.lblValidaDPCard.Location = New System.Drawing.Point(392, 72)
        Me.lblValidaDPCard.Name = "lblValidaDPCard"
        Me.lblValidaDPCard.Size = New System.Drawing.Size(256, 16)
        Me.lblValidaDPCard.TabIndex = 235
        Me.lblValidaDPCard.Text = "Validando Tarjeta. Favor de Esperar ..."
        Me.lblValidaDPCard.Visible = False
        '
        'btnLeerDPCard
        '
        Me.btnLeerDPCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeerDPCard.Icon = CType(resources.GetObject("btnLeerDPCard.Icon"), System.Drawing.Icon)
        Me.btnLeerDPCard.Location = New System.Drawing.Point(336, 72)
        Me.btnLeerDPCard.Name = "btnLeerDPCard"
        Me.btnLeerDPCard.Size = New System.Drawing.Size(40, 22)
        Me.btnLeerDPCard.TabIndex = 234
        Me.btnLeerDPCard.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 16)
        Me.Label17.TabIndex = 232
        Me.Label17.Text = "Tarjetahabiente:"
        '
        'ebClienteDPC
        '
        Me.ebClienteDPC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteDPC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteDPC.BackColor = System.Drawing.SystemColors.Info
        Me.ebClienteDPC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebClienteDPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebClienteDPC.Location = New System.Drawing.Point(144, 104)
        Me.ebClienteDPC.Name = "ebClienteDPC"
        Me.ebClienteDPC.ReadOnly = True
        Me.ebClienteDPC.Size = New System.Drawing.Size(344, 21)
        Me.ebClienteDPC.TabIndex = 231
        Me.ebClienteDPC.TabStop = False
        Me.ebClienteDPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbFechaPagoDPC
        '
        Me.cmbFechaPagoDPC.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.cmbFechaPagoDPC.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFechaPagoDPC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaPagoDPC.Location = New System.Drawing.Point(584, 41)
        Me.cmbFechaPagoDPC.Name = "cmbFechaPagoDPC"
        Me.cmbFechaPagoDPC.ReadOnly = True
        Me.cmbFechaPagoDPC.Size = New System.Drawing.Size(120, 22)
        Me.cmbFechaPagoDPC.TabIndex = 229
        Me.cmbFechaPagoDPC.TabStop = False
        Me.cmbFechaPagoDPC.TodayButtonText = "Hoy"
        Me.cmbFechaPagoDPC.Value = New Date(2022, 6, 16, 0, 0, 0, 0)
        Me.cmbFechaPagoDPC.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(472, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Fecha de Pago:"
        '
        'ebFolioPago
        '
        Me.ebFolioPago.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioPago.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioPago.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioPago.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioPago.Location = New System.Drawing.Point(144, 40)
        Me.ebFolioPago.Name = "ebFolioPago"
        Me.ebFolioPago.Size = New System.Drawing.Size(96, 23)
        Me.ebFolioPago.TabIndex = 2
        Me.ebFolioPago.Text = "0"
        Me.ebFolioPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioPago.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSaldoDPC
        '
        Me.ebSaldoDPC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSaldoDPC.BackColor = System.Drawing.SystemColors.Info
        Me.ebSaldoDPC.ButtonFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoDPC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSaldoDPC.FormatString = "c"
        Me.ebSaldoDPC.Location = New System.Drawing.Point(584, 104)
        Me.ebSaldoDPC.Name = "ebSaldoDPC"
        Me.ebSaldoDPC.ReadOnly = True
        Me.ebSaldoDPC.Size = New System.Drawing.Size(120, 23)
        Me.ebSaldoDPC.TabIndex = 225
        Me.ebSaldoDPC.Text = "$0.00"
        Me.ebSaldoDPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoDPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(496, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 16)
        Me.Label15.TabIndex = 226
        Me.Label15.Text = "Total Pago:"
        '
        'ebDPCard
        '
        Me.ebDPCard.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDPCard.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDPCard.BackColor = System.Drawing.SystemColors.Info
        Me.ebDPCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDPCard.Location = New System.Drawing.Point(144, 72)
        Me.ebDPCard.Name = "ebDPCard"
        Me.ebDPCard.Size = New System.Drawing.Size(192, 23)
        Me.ebDPCard.TabIndex = 222
        Me.ebDPCard.TabStop = False
        Me.ebDPCard.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDPCard.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 221
        Me.Label16.Text = "No. de Tarjeta:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Folio de Pago:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuLimpiar, Me.menuCancelarPago, Me.MenuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("d799eaac-4be9-47d5-90b4-771e51dfdc35")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 344)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(714, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Limpiar1, Me.Separator1, Me.CancelarPago1, Me.Separator2, Me.Salir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(239, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Limpiar1
        '
        Me.Limpiar1.Key = "menuLimpiar"
        Me.Limpiar1.Name = "Limpiar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'CancelarPago1
        '
        Me.CancelarPago1.Key = "menuCancelarPago"
        Me.CancelarPago1.Name = "CancelarPago1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Salir1
        '
        Me.Salir1.Key = "menuSalir"
        Me.Salir1.Name = "Salir1"
        '
        'menuLimpiar
        '
        Me.menuLimpiar.Image = CType(resources.GetObject("menuLimpiar.Image"), System.Drawing.Image)
        Me.menuLimpiar.Key = "menuLimpiar"
        Me.menuLimpiar.Name = "menuLimpiar"
        Me.menuLimpiar.Text = "Limpiar"
        '
        'menuCancelarPago
        '
        Me.menuCancelarPago.Icon = CType(resources.GetObject("menuCancelarPago.Icon"), System.Drawing.Icon)
        Me.menuCancelarPago.Key = "menuCancelarPago"
        Me.menuCancelarPago.Name = "menuCancelarPago"
        Me.menuCancelarPago.Text = "Cancelar Pago"
        '
        'MenuSalir
        '
        Me.MenuSalir.Icon = CType(resources.GetObject("MenuSalir.Icon"), System.Drawing.Icon)
        Me.MenuSalir.Key = "menuSalir"
        Me.MenuSalir.Name = "MenuSalir"
        Me.MenuSalir.Text = "Salir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 28)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 316)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(714, 28)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 316)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(714, 28)
        '
        'frmCancelarOtrosPagos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(714, 344)
        Me.Controls.Add(Me.LeftRebar1)
        Me.Controls.Add(Me.RightRebar1)
        Me.Controls.Add(Me.BottomRebar1)
        Me.Controls.Add(Me.exAbonosDPCard)
        Me.Controls.Add(Me.exDatosGenerales)
        Me.Controls.Add(Me.ebBackground)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCancelarOtrosPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de Otros Pagos"
        CType(Me.ebBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ebBackground.ResumeLayout(False)
        CType(Me.exBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exBotones.ResumeLayout(False)
        CType(Me.exDatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exDatosGenerales.ResumeLayout(False)
        Me.exDatosGenerales.PerformLayout()
        CType(Me.exAbonosDPCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.exAbonosDPCard.ResumeLayout(False)
        Me.exAbonosDPCard.PerformLayout()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim booleHub As Boolean = False
    Dim bolCargoEHub As Boolean = False
    Dim intPromo As Integer = 0

    Dim bExit As Boolean = False

    Dim strNoAfiliacion As String
    Dim strNombreM As String
    Dim strVencM As String
    Dim mPosEntryM As Integer = 0
    Dim strCriptogramaM As String = ""
    Dim strTarjetaBloq As String

    Dim dtConceptos As DataTable
    Public oSAPMgr As ProcesoSAPManager

    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    'Objeto Factura
    Dim oFacturaMgr As FacturaManager

    'Tabla Temporal de Formas de Pago
    Public dsFormasPago As New DataSet
    Dim m_dtFormasPago As DataTable

    Dim NumRef As String = ""

    'Objeto Otros Pagos
    Dim oOtrosPagos As OtrosPagos

    Private Resultado As Hashtable
    Dim htDatosDPC As Hashtable

    Private deslizada As Boolean = False

#Region "Metodos y Funciones Generales"

    Private Sub Inicializar()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        'Objeto Vendedores
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        'Objeto Factura
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)


    End Sub

    Private Sub Limpiar()

        'Datos Generales
        Me.ebPlayer.Text = ""
        Me.ebNombrePlayer.Text = ""
        Me.ebFolioPago.Text = ""
        Me.ebDPCard.Text = ""
        Me.ebSaldoDPC.Text = 0
        Me.cmbFechaPagoDPC.Value = Date.Now

        'Objeto Otros Pagos
        oOtrosPagos = Nothing

        Me.exAbonosDPCard.Visible = False
        Me.btnCancelarPago.Enabled = False

        Me.cmbConceptoPago.Focus()

        bExit = False

    End Sub

    Private Sub LLenarTablaConceptos()

        Dim oRow As DataRow

        If dtConceptos Is Nothing Then
            dtConceptos = New DataTable("Conceptos")
            dtConceptos.Columns.Add("ID")
            dtConceptos.Columns.Add("CONCEPTO")
        Else
            dtConceptos.Rows.Clear()
        End If

        'Agregamos el concepto correspondiente a DC
        If oConfigCierreFI.CancelarPagosDPCard Then
            oRow = dtConceptos.NewRow()
            oRow("ID") = "DC"
            oRow("CONCEPTO") = "Abono a DP Card"
            dtConceptos.Rows.Add(oRow)
        End If

        dtConceptos.AcceptChanges()

    End Sub

    Private Sub LLenarComboConceptos()

        LLenarTablaConceptos()

        With Me.cmbConceptoPago

            .DropDownList.ClearStructure()

            .DataSource = dtConceptos
            .DropDownList.Columns.Add("ID")
            .DropDownList.Columns.Add("CONCEPTO")
            .DropDownList.Columns("ID").DataMember = "ID"
            .DropDownList.Columns("CONCEPTO").DataMember = "Concepto"
            .DropDownList.Columns("CONCEPTO").Width = 200
            .DropDownList.Columns("ID").Visible = False

            .DisplayMember = "CONCEPTO"
            .ValueMember = "ID"

            .DropDownList.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False

            .Refresh()

            .Focus()

        End With

    End Sub

    Private Sub LoadSearchFormPlayer()

        Dim oOpenRecordDialogView As New OpenRecordDialog
        oOpenRecordDialogView.CurrentView = New CatalogoVendedoresOpenRecordDialogView

        oOpenRecordDialogView.ShowDialog()

        If (oOpenRecordDialogView.DialogResult = DialogResult.OK) Then

            If oOpenRecordDialogView.pbNombre <> String.Empty Then

                ebPlayer.Text = oOpenRecordDialogView.pbCodigo
                ebNombrePlayer.Text = oOpenRecordDialogView.pbNombre

            Else

                ebPlayer.Text = oOpenRecordDialogView.Record.Item("CodVendedor")
                ebNombrePlayer.Text = oOpenRecordDialogView.Record.Item("Nombre")

            End If

        End If

        oOpenRecordDialogView.Dispose()

        oOpenRecordDialogView = Nothing

    End Sub

    Private Sub MostrarPantallas()

        Limpiar()

        Select Case Me.cmbConceptoPago.Value

            Case "DC"
                Me.exAbonosDPCard.Visible = True
                Me.ebPlayer.Focus()
            Case Else

        End Select

    End Sub

    Private Sub CancelarPago(ByVal ConceptoPago As String)

        '-------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (25.02.2015): Validamamos que se haya cargado el numemero de la tarjeta
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Me.ebDPCard.Text.Trim = "" Then
            MessageBox.Show("Debe delizar la Tajerta de DP Card para continuar con la cancelacíon del Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------
        'Validamamos que realmente se haya cargado un pago
        '-------------------------------------------------------------------------------------------------------------------------------------
        If Not oOtrosPagos Is Nothing AndAlso oOtrosPagos.OtrosPagosID <> 0 Then

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Comprobamos que el usuario tenga permisos
            '-------------------------------------------------------------------------------------------------------------------------------------
            If ConceptoPago = "DC" Then
                oAppContext.Security.CloseImpersonatedSession()
                If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.OtrosPagos", "DportenisPro.DPTienda.OtrosPagos.CancelarPagosDPCard") Then
                    Exit Sub
                End If
            Else
                'Proximamente
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Preparamos el Objeto oOtrosPagos con los datos corresponcientes a la cancelacion
            '-------------------------------------------------------------------------------------------------------------------------------------
            oOtrosPagos = PrepararCancelacion(ConceptoPago)

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Realizamos la cancelacion del pago en KARUM (Revisar orden)
            '-------------------------------------------------------------------------------------------------------------------------------------
            If ConceptoPago = "DC" Then
                If CancelarPagoDPCard() = False Then
                    oAppContext.Security.CloseImpersonatedSession()
                    MessageBox.Show("Hubo un error al cancelar el Pago en el Centro de Credito.", "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                'proximamente
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Grabamos primero PRO
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Not oOtrosPagos.Save(True) Then
                oAppContext.Security.CloseImpersonatedSession()
                MessageBox.Show("No se pudo Cancelar el Pago en PRO. Surgio un error.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            '-------------------------------------------------------------------------------------------------------------------------------------
            'Grabamos la Cancelacion en SAP 
            '-------------------------------------------------------------------------------------------------------------------------------------
            If Not oOtrosPagos.SavePagoSAP(True) Then
                oAppContext.Security.CloseImpersonatedSession()
                Exit Sub
            End If

            '----------------------------------------------------------------------------------------------------------------------------
            'Imprimimos comprobantes correspondientes
            '----------------------------------------------------------------------------------------------------------------------------
            If ConceptoPago = "DC" Then
                '----------------------------------------------------------------------------------------------------------------------------
                'JNAVA (24.01.2015): Imprimimos Voucher del Pago de DP Card
                '----------------------------------------------------------------------------------------------------------------------------
                oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "PGO", False, True) 'COPIA P/TIENDA
                oOtrosPagos.ImprimirVoucherDPCard(htDatosDPC, "PGO", True, True) 'COPIA P/CLIENTE

                '----------------------------------------------------------------------------------------------------------------------------
                'JNAVA (24.02.2015): Imprimimos Comprobante del Pago de DP Card
                '----------------------------------------------------------------------------------------------------------------------------
                oOtrosPagos.ImprimirComprobantePago(CStr(Me.oOtrosPagos.OtrosPagosID), Me.oOtrosPagos.Concepto, Me.ebClienteDPC.Text, True)

            End If

            MessageBox.Show("El Pago se ha cancelado exitosamente.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se ha cargado ningún pago. Favor de Verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebFolioPago.Focus()
        End If

        oAppContext.Security.CloseImpersonatedSession()

        Me.cmbConceptoPago.Value = ""
        Limpiar()

    End Sub

    Private Function PrepararCancelacion(ByVal Concepto As String) As OtrosPagos

        Try

            'Validamos que se haya cargado un pago y que corresponda al ingresado en pantalla
            If Not oOtrosPagos Is Nothing AndAlso oOtrosPagos.OtrosPagosID = Me.ebFolioPago.Text Then
                oOtrosPagos.Tipo = Concepto
                oOtrosPagos.FechaCan = oSAPMgr.MSS_GET_SY_DATE_TIME()
                oOtrosPagos.UsuarioCan = oAppContext.Security.CurrentUser.SessionLoginName
                oOtrosPagos.Status = True
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo Preparar la Cancelación. Surgio un error", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo Preparar el Pago")
        End Try

        Return oOtrosPagos

    End Function


#End Region

#Region "DP Card"

    Private Sub ValidarFolioPagoDPC()

        If bExit Then
            Exit Sub
        End If

        If Me.ebFolioPago.Value <> 0 Then

            oOtrosPagos = Nothing
            oOtrosPagos = New OtrosPagos(Me.ebFolioPago.Value, Me.cmbConceptoPago.Value)

            'Validamos que exista el pago
            If oOtrosPagos.OtrosPagosID <> 0 Then

                'Si el status esta en verdadero, esta canceladoy no puede seguir con la cancelacion
                If oOtrosPagos.Status = True Then
                    MessageBox.Show("El Folio del Pago ingresado ya ha sido cancelado. Favor de Verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.ebFolioPago.Focus()
                    Exit Sub
                End If

                'Me.ebDPCard.Text = oOtrosPagos.NumOrden
                Me.ebSaldoDPC.Value = oOtrosPagos.TotalPago
                Me.cmbFechaPagoDPC.Value = oOtrosPagos.Fecha

                'Me.btnCancelarPago.Enabled = True
                'Me.btnCancelarPago.Focus()

                Me.btnLeerDPCard.Focus()

            Else
                MessageBox.Show("El Folio del Pago ingresado no existe o pertenece a otro Concepto. Favor de Verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebFolioPago.Focus()
            End If

        Else
            MessageBox.Show("Debe ingresar el Folio del Pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebFolioPago.Focus()
        End If

    End Sub

    Private Function CancelarPagoDPCard() As Boolean
        Dim valido As Boolean = False
        Dim parameter As New Hashtable
        Dim ws As New WSBroker("WS_KARUM", True)
        Try
            parameter("NoTarjeta") = ebDPCard.Text.Trim()
            parameter("Monto") = Math.Round(CDec(ebSaldoDPC.Value), 2)
            parameter("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
            parameter("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
            parameter("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
            'parameter("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
            parameter("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            '--------------------------------------------------------------
            'JNAVA (25.01.2015): Especificamos que la tarjeta fue dezlizada
            '--------------------------------------------------------------
            If deslizada = True Then
                parameter("Tipo") = "00"
            Else
                parameter("Tipo") = "01"
            End If
            parameter("Promocion") = "00"
            Resultado = ws.PaymentVoid(parameter)

            If Resultado.Count > 0 Then
                If Resultado.ContainsKey("Success") = True Then
                    If CBool(Resultado("Success")) = True Then
                        valido = True
                    Else
                        EscribeLog(CStr(Resultado("Mensaje")), "Error en el Metodo PaymentVoid del Webservice Karum")
                        MessageBox.Show(CStr(Resultado("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        valido = False
                        GoTo SALIR
                    End If
                Else
                    valido = False
                    GoTo SALIR
                End If
            Else
                valido = False
                GoTo Salir
            End If

            '-----------------------------------------------------------------------------
            ' JNAVA (24.02.2015): Obtenemos datos de KARUM (para ticket y registros)
            '-----------------------------------------------------------------------------
            htDatosDPC = Resultado

            '''PRUEBAS
            'htDatosDPC("Transaccion") = "1234"
            'htDatosDPC("Autorizacion") = Date.Now.ToString("ddMMyyyyHHmmss")
            '''PRUEBAS

            '-----------------------------------------------------------------------------
            ' JNAVA (08.04.2015): El número de la tienda debe ser el de KARUM
            '-----------------------------------------------------------------------------
            htDatosDPC("NoTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
            htDatosDPC("NoCaja") = oAppContext.ApplicationConfiguration.NoCaja
            htDatosDPC("Tarjeta") = Me.ebDPCard.Text.Trim()

            htDatosDPC("Monto") = CDec(Me.ebSaldoDPC.Value)
            htDatosDPC("Vendedor") = oAppContext.Security.CurrentUser.Name 'Vendedor
            oOtrosPagos.Referencia = Date.Now.ToString("ddMMyyyyHHmmss")

            '----------------------------------------------------------------------------------------------
            'JNAVA (12.03.2015): Especificamos que la tarjeta fue dezlizada
            '----------------------------------------------------------------------------------------------
            'JNAVA (13.03.2015): Si la tarjeta fue digitada, ponemos solo el apellido que regresa KARUM *
            '----------------------------------------------------------------------------------------------
            If deslizada Then
                htDatosDPC("TarjetaHabiente") = Me.ebClienteDPC.Text '*
                htDatosDPC("Linea") = "DESLIZADA"
            Else
                htDatosDPC("TarjetaHabiente") = String.Empty '*
                Me.ebClienteDPC.Text = String.Empty
                htDatosDPC("Linea") = "DIGITADA"
            End If

            '-----------------------------------------------------------
            'FLIZARRAGA 30/10/2017: Consecutivo POS
            '-----------------------------------------------------------
            htDatosDPC("ConsecutivoPOS") = CStr(Resultado("ConsecutivoPOS")).PadLeft(4, "0")

SALIR:
        Catch ex As Exception
            EscribeLog(ex.Message, "Error al cancelar abonos")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return valido
    End Function

    Private Function ValidaDPCard(ByVal EsDeslizada As Boolean) As Boolean
        Dim bResp As Boolean = True

        '--------------------------------------------------------------
        'JNAVA (12.03.2015): Especificamos que la tarjeta fue dezlizada
        '--------------------------------------------------------------
        deslizada = EsDeslizada

        '--------------------------------------------------------------
        'JNAVA (25.01.2015): Agregamos la validacion de DP Card 
        '--------------------------------------------------------------
        If Me.ebDPCard.Text.Trim = Me.oOtrosPagos.NumOrden.Trim Then
            'Me.ebDPCard.Text = NumTarjeta
            'Me.ebClienteDPC.Text = NombreCliente
            Me.btnCancelarPago.Enabled = True
            Me.btnCancelarPago.Focus()
            bResp = True
        Else
            Me.ebDPCard.Text = String.Empty
            Me.ebClienteDPC.Text = String.Empty
            MessageBox.Show("El Número de Tarjeta no coincide con la del pago. Favor de Verificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnLeerDPCard.Focus()
            bResp = False
        End If

        Return bResp

    End Function

#End Region

#Region "Eventos"

    Private Sub frmCancelarOtrosPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbFecha.Text = Format(Today, "dd - MMMM - yyyy")
        LLenarComboConceptos()
        Me.cmbConceptoPago.Focus()
    End Sub

    Private Sub ebPlayer_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayer.ButtonClick
        LoadSearchFormPlayer()
    End Sub

    Private Sub ebPlayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayer.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            LoadSearchFormPlayer()
            ebPlayer.Focus()
            ebPlayer.SelectAll()
        End If
    End Sub

    Private Sub ebPlayer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayer.Validating

        If ebPlayer.Text.Trim <> "" Then ebPlayer.Text = ebPlayer.Text.Trim.PadLeft(8, "0")

        If oConfigCierreFI.ShowManagerPC AndAlso ebPlayer.Text.Trim = "" Then

            Me.ebPlayer.Focus()
            Return

        End If

        If ebPlayer.Text.Trim <> "" Then

            oVendedor.ClearFields()

            oVendedoresMgr.LoadInto(ebPlayer.Text, oVendedor)

            If oVendedor.ID <> String.Empty Then
                'Dim strRes As String = oSAPMgr.ZBAPI_VALIDA_VENDEDOR(oVendedor.ID)

                'If strRes.Trim = "0" Then
                '    GoTo NoExiste
                'ElseIf strRes.Trim = "2" Then
                '    MessageBox.Show("El Vendedor " & oVendedor.ID & " no está asignado a la oficina de venta: T" & oAppContext.ApplicationConfiguration.Almacen, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    oVendedor.ClearFields()
                '    Me.ebNombrePlayer.Text = ""
                '    e.Cancel = True
                'Else
                ebNombrePlayer.Text = oVendedor.Nombre
                If Me.cmbConceptoPago.Value = "DC" Then
                    Me.ebFolioPago.Focus()
                End If
                'End If
            Else
NoExiste:
                MsgBox("Código de Vendedor NO EXISTE.  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "  Facturación ")

                oVendedor.ClearFields()
                Me.ebNombrePlayer.Text = ""
                e.Cancel = True

            End If

        End If
    End Sub

    Private Sub cmbConceptoPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConceptoPago.ValueChanged
        If Me.cmbConceptoPago.Text.Trim <> "" Then
            MostrarPantallas()
        End If
    End Sub

    Private Sub frmCancelarOtrosPagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ebFolioPago_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolioPago.Validating
        ValidarFolioPagoDPC()
    End Sub

    Private Sub btnCancelarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarPago.Click
        Dim avance As Boolean = True
        Dim fechaPago As Date = Format(cmbFechaPagoDPC.Value, "dd - MMMM - yyyy")

        If cmbConceptoPago.Value = "DC" Then
            If cmbFecha.Value <> fechaPago Then
                avance = False
                MessageBox.Show("Solo se pueden cancelar los abonos DPCARD del día de hoy", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        If avance Then
            CancelarPago(Me.cmbConceptoPago.Value)
        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuLimpiar"
                Me.cmbConceptoPago.Value = ""
                Limpiar()
            Case "menuCancelarPago"
                CancelarPago(Me.cmbConceptoPago.Value)
            Case "menuSalir"
                bExit = True
                Me.Close()
        End Select
    End Sub


    Private Sub frmCancelarOtrosPagos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Preguntamos si realmente quiere salir sin cancelar el pago cargado
        If Not oOtrosPagos Is Nothing AndAlso oOtrosPagos.OtrosPagosID <> 0 Then
            If MessageBox.Show("Se ha cargado el Folio de Pago " & oOtrosPagos.OtrosPagosID & " para su cancelación." & vbCrLf & " ¿Está seguro que desea salir sin cancelar el pago?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                e.Cancel = True
                bExit = False
            End If
        End If
    End Sub

    Private Sub LeerDatosTarjeta()
        '-----------------------------------------------------------------------------
        'FLIZARRAGA (20.01.2014): Validamos el DP Card con KARUM
        '-----------------------------------------------------------------------------
        Dim ws As New WSBroker("WS_KARUM", True)
        Dim param As New Hashtable
        param("NoTarjeta") = Me.ebDPCard.Text.Trim()
        '----------------------------------------------------------
        ' JNAVA (03.04.2016): Verificamos pagos sin SAP Retail
        '----------------------------------------------------------
       
            param("Fecha") = DateTime.Now.ToString("yyyyMMddHHmmss")
        'param("Fecha") = oSAPMgr.MSS_GET_SY_DATE_TIME().ToString("yyyyMMddHHmmss")
        '----------------------------------------------------------
        param("ConsecutivoPOS") = oConfigCierreFI.ConsecutivoPOS
        param("IDPOS") = oAppContext.ApplicationConfiguration.NoCaja.PadLeft(4, "0")
        'param("IDTienda") = "D3" & oAppContext.ApplicationConfiguration.Almacen.PadLeft(5, "0")
        param("IDTienda") = "D3" & oConfigCierreFI.IDTienda.PadLeft(5, "0")
        '-----------------------------------------------------------------------------
        'JNAVA (12.03.2015): Especificamos si fue deslizada o Digitada
        '-----------------------------------------------------------------------------
        If deslizada = True Then
            param("Tipo") = "00"
        Else
            param("Tipo") = "01"
        End If

        Dim resultado As Hashtable = ws.AccountStatus(param)
        If resultado.Count > 0 Then
            If resultado.ContainsKey("Success") = True Then
                If Me.ebClienteDPC.Text.Trim = String.Empty Then
                    Me.ebClienteDPC.Text = CStr(resultado("TarjetaHabiente"))
                End If
            End If
        End If
    End Sub


    Private Sub btnLeerDPCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerDPCard.Click
        '--------------------------------------------------------------
        'JNAVA (25.01.2015): Leectura de datos de tarjeta DP CArd
        '--------------------------------------------------------------
        Try
            Dim oOP As New OtrosPagos
            Me.lblValidaDPCard.Visible = True
            If oOP.LeerDatosDPCard(Me.ebDPCard.Text, Me.ebClienteDPC.Text) Then
                '--------------------------------------------------------------
                'JNAVA (13.02.2015): Agregamos la validacion de DP Card 
                '--------------------------------------------------------------
                If Not ValidaDPCard(True) Then
                    GoTo Salir
                End If
            End If
Salir:
            Me.lblValidaDPCard.Visible = False

        Catch ex As Exception
            MessageBox.Show("No se pudo leer la Tarjeta DP Card. Surgio un error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "No se pudo leer la Tarjeta DP Card")
        End Try
    End Sub

    Private Sub ebDPCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebDPCard.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.lblValidaDPCard.Visible = True
            '--------------------------------------------------------------
            'JNAVA (13.02.2015): Agregamos la validacion de DP Card 
            '--------------------------------------------------------------
            '------------------------------------------------------------------------------------
            'FLIZARRAGA 16/05/2017: Validacion de Luhn para corroborar si la tarjeta es correcta
            '------------------------------------------------------------------------------------
            If ValidacionLuhn(ebDPCard.Text.Trim()) Then
                If Not ValidaDPCard(False) Then
                    Exit Sub
                End If
                Me.lblValidaDPCard.Visible = False

            End If  
        End If
    End Sub

    Private Sub ebDPCard_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDPCard.Validating
        '--------------------------------------------------------------
        'JNAVA (13.02.2015): Agregamos la validacion de DP Card 
        '--------------------------------------------------------------
        Me.lblValidaDPCard.Visible = True
        If Not ValidaDPCard(False) Then
            Me.lblValidaDPCard.Visible = False
            Exit Sub
        End If
        Me.lblValidaDPCard.Visible = False
        LeerDatosTarjeta()
    End Sub

    Private Sub ebDPCard_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ebDPCard.KeyPress
        ValidarNumeros(e)
    End Sub

#End Region

End Class
