Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.DistribucionNC

Public Class FrmValeCaja
    Inherits System.Windows.Forms.Form

    Private m_bValeCajaOpt As Boolean = False

    Private m_bDevEfectOpt As Boolean = False

    Private m_bcanModif As Boolean = True

    Private m_decMontoFonacot As Decimal

    Private m_decMontoTarjetaCredito As Decimal

    Public bShow As Boolean = True

    Public bDevEfec As Boolean = False

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        '---------------------------------------------------------------------------------------------------------------------------------------------------
        'Inicializamos este objeto desde el aqui porque en la opcion de Utilerias-Reimprimir Vale de Caja se usa este formulario y se necesita inicializarlo
        '---------------------------------------------------------------------------------------------------------------------------------------------------
        oValeCajaManager = New ValeCajaManager(oAppContext)
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
    Friend WithEvents npArticulo As PureComponents.NicePanel.NicePanel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDevDinero As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents ebMotivo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioDocumento As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTipoDocumento As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebImporte As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebFecha As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Nuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Guardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Nuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Imprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Guardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Imprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents Archivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Archivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Nuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Guardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Imprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Salir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Nuevo3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Guardar3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Imprimir3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Ayuda3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CommandManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chkHabilitar As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lblDescripGen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmValeCaja))
        Me.npArticulo = New PureComponents.NicePanel.NicePanel()
        Me.lblDescripGen = New System.Windows.Forms.Label()
        Me.chkHabilitar = New Janus.Windows.EditControls.UICheckBox()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebFecha = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebMotivo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.chkDevDinero = New Janus.Windows.EditControls.UICheckBox()
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebFolioDocumento = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebTipoDocumento = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebImporte = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CommandManager = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.Archivo1 = New Janus.Windows.UI.CommandBars.UICommand("Archivo")
        Me.Ayuda2 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.Nuevo3 = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Guardar3 = New Janus.Windows.UI.CommandBars.UICommand("Guardar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Imprimir3 = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Ayuda3 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Nuevo = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Guardar = New Janus.Windows.UI.CommandBars.UICommand("Guardar")
        Me.Imprimir = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.Salir = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.Ayuda = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.Archivo = New Janus.Windows.UI.CommandBars.UICommand("Archivo")
        Me.Nuevo2 = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Guardar2 = New Janus.Windows.UI.CommandBars.UICommand("Guardar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Imprimir2 = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Salir1 = New Janus.Windows.UI.CommandBars.UICommand("Salir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.Nuevo1 = New Janus.Windows.UI.CommandBars.UICommand("Nuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Guardar1 = New Janus.Windows.UI.CommandBars.UICommand("Guardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Imprimir1 = New Janus.Windows.UI.CommandBars.UICommand("Imprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Ayuda1 = New Janus.Windows.UI.CommandBars.UICommand("Ayuda")
        Me.npArticulo.SuspendLayout()
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'npArticulo
        '
        Me.npArticulo.BackColor = System.Drawing.Color.Transparent
        Me.npArticulo.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.npArticulo.ContainerImage = ContainerImage1
        Me.npArticulo.ContextMenuButton = False
        Me.npArticulo.Controls.Add(Me.lblDescripGen)
        Me.npArticulo.Controls.Add(Me.chkHabilitar)
        Me.npArticulo.Controls.Add(Me.ebFolio)
        Me.npArticulo.Controls.Add(Me.Label2)
        Me.npArticulo.Controls.Add(Me.ebFecha)
        Me.npArticulo.Controls.Add(Me.ebMotivo)
        Me.npArticulo.Controls.Add(Me.chkDevDinero)
        Me.npArticulo.Controls.Add(Me.ebNombre)
        Me.npArticulo.Controls.Add(Me.ebCodCliente)
        Me.npArticulo.Controls.Add(Me.ebFolioDocumento)
        Me.npArticulo.Controls.Add(Me.ebTipoDocumento)
        Me.npArticulo.Controls.Add(Me.ebImporte)
        Me.npArticulo.Controls.Add(Me.Label1)
        Me.npArticulo.Controls.Add(Me.btnGuardar)
        Me.npArticulo.Controls.Add(Me.btnImprimir)
        Me.npArticulo.Controls.Add(Me.Label24)
        Me.npArticulo.Controls.Add(Me.Label20)
        Me.npArticulo.Controls.Add(Me.Label11)
        Me.npArticulo.Controls.Add(Me.Label12)
        Me.npArticulo.Controls.Add(Me.Label10)
        Me.npArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.npArticulo.FooterImage = HeaderImage1
        Me.npArticulo.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npArticulo.FooterVisible = False
        Me.npArticulo.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Block
        HeaderImage2.Image = Nothing
        Me.npArticulo.HeaderImage = HeaderImage2
        Me.npArticulo.HeaderText = "Vale de Caja"
        Me.npArticulo.IsExpanded = True
        Me.npArticulo.Location = New System.Drawing.Point(-1, 48)
        Me.npArticulo.Name = "npArticulo"
        Me.npArticulo.OriginalFooterVisible = False
        Me.npArticulo.OriginalHeight = 0
        Me.npArticulo.Size = New System.Drawing.Size(521, 328)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.SystemColors.ControlDark
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Dot
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.SystemColors.ControlLightLight
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.Transparent
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.SystemColors.ControlLightLight
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.npArticulo.Style = PanelStyle1
        Me.npArticulo.TabIndex = 54
        Me.npArticulo.TabStop = False
        '
        'lblDescripGen
        '
        Me.lblDescripGen.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripGen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripGen.ForeColor = System.Drawing.Color.Firebrick
        Me.lblDescripGen.Location = New System.Drawing.Point(184, 91)
        Me.lblDescripGen.Name = "lblDescripGen"
        Me.lblDescripGen.Size = New System.Drawing.Size(104, 18)
        Me.lblDescripGen.TabIndex = 53
        '
        'chkHabilitar
        '
        Me.chkHabilitar.BackColor = System.Drawing.Color.Transparent
        Me.chkHabilitar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHabilitar.Location = New System.Drawing.Point(168, 144)
        Me.chkHabilitar.Name = "chkHabilitar"
        Me.chkHabilitar.Size = New System.Drawing.Size(80, 16)
        Me.chkHabilitar.TabIndex = 52
        Me.chkHabilitar.Text = "Habilitar"
        Me.chkHabilitar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolio.ButtonImage = CType(resources.GetObject("ebFolio.ButtonImage"), System.Drawing.Image)
        Me.ebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolio.Location = New System.Drawing.Point(120, 40)
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(104, 22)
        Me.ebFolio.TabIndex = 0
        Me.ebFolio.TabStop = False
        Me.ebFolio.Text = "0"
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(344, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Fecha"
        '
        'ebFecha
        '
        Me.ebFecha.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFecha.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFecha.BackColor = System.Drawing.SystemColors.Info
        Me.ebFecha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFecha.Location = New System.Drawing.Point(392, 40)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.ReadOnly = True
        Me.ebFecha.Size = New System.Drawing.Size(112, 22)
        Me.ebFecha.TabIndex = 50
        Me.ebFecha.TabStop = False
        Me.ebFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebMotivo
        '
        Me.ebMotivo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebMotivo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebMotivo.BackColor = System.Drawing.Color.White
        Me.ebMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebMotivo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebMotivo.Location = New System.Drawing.Point(16, 184)
        Me.ebMotivo.MaxLength = 255
        Me.ebMotivo.Multiline = True
        Me.ebMotivo.Name = "ebMotivo"
        Me.ebMotivo.Size = New System.Drawing.Size(488, 80)
        Me.ebMotivo.TabIndex = 2
        Me.ebMotivo.TabStop = False
        Me.ebMotivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'chkDevDinero
        '
        Me.chkDevDinero.BackColor = System.Drawing.Color.Transparent
        Me.chkDevDinero.Enabled = False
        Me.chkDevDinero.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDevDinero.Location = New System.Drawing.Point(16, 144)
        Me.chkDevDinero.Name = "chkDevDinero"
        Me.chkDevDinero.Size = New System.Drawing.Size(112, 16)
        Me.chkDevDinero.TabIndex = 48
        Me.chkDevDinero.Text = "Dev. Efectivo"
        Me.chkDevDinero.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.BackColor = System.Drawing.SystemColors.Info
        Me.ebNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(232, 112)
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(272, 22)
        Me.ebNombre.TabIndex = 1
        Me.ebNombre.TabStop = False
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodCliente
        '
        Me.ebCodCliente.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodCliente.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodCliente.BackColor = System.Drawing.SystemColors.Info
        Me.ebCodCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodCliente.Location = New System.Drawing.Point(120, 112)
        Me.ebCodCliente.Name = "ebCodCliente"
        Me.ebCodCliente.ReadOnly = True
        Me.ebCodCliente.Size = New System.Drawing.Size(104, 22)
        Me.ebCodCliente.TabIndex = 46
        Me.ebCodCliente.TabStop = False
        Me.ebCodCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFolioDocumento
        '
        Me.ebFolioDocumento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioDocumento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.ebFolioDocumento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioDocumento.Location = New System.Drawing.Point(392, 88)
        Me.ebFolioDocumento.Name = "ebFolioDocumento"
        Me.ebFolioDocumento.ReadOnly = True
        Me.ebFolioDocumento.Size = New System.Drawing.Size(112, 22)
        Me.ebFolioDocumento.TabIndex = 45
        Me.ebFolioDocumento.TabStop = False
        Me.ebFolioDocumento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTipoDocumento
        '
        Me.ebTipoDocumento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTipoDocumento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTipoDocumento.BackColor = System.Drawing.SystemColors.Info
        Me.ebTipoDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTipoDocumento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTipoDocumento.Location = New System.Drawing.Point(120, 88)
        Me.ebTipoDocumento.Name = "ebTipoDocumento"
        Me.ebTipoDocumento.ReadOnly = True
        Me.ebTipoDocumento.Size = New System.Drawing.Size(56, 22)
        Me.ebTipoDocumento.TabIndex = 44
        Me.ebTipoDocumento.TabStop = False
        Me.ebTipoDocumento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebTipoDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebImporte
        '
        Me.ebImporte.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebImporte.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebImporte.BackColor = System.Drawing.SystemColors.Info
        Me.ebImporte.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebImporte.Location = New System.Drawing.Point(120, 64)
        Me.ebImporte.Name = "ebImporte"
        Me.ebImporte.ReadOnly = True
        Me.ebImporte.Size = New System.Drawing.Size(104, 22)
        Me.ebImporte.TabIndex = 43
        Me.ebImporte.TabStop = False
        Me.ebImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Motivo"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(208, 272)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(120, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.Visible = False
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Icon = CType(resources.GetObject("btnImprimir.Icon"), System.Drawing.Icon)
        Me.btnImprimir.Location = New System.Drawing.Point(344, 272)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(120, 32)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(344, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 23)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "Folio"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 18)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Generado Por"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Folio Vale"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Cliente"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 23)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Importe"
        '
        'CommandManager
        '
        Me.CommandManager.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.BottomRebar = Me.BottomRebar1
        Me.CommandManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.CommandManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Nuevo, Me.Guardar, Me.Imprimir, Me.Salir, Me.Ayuda, Me.Archivo})
        Me.CommandManager.ContainerControl = Me
        '
        '
        '
        Me.CommandManager.EditContextMenu.Key = ""
        Me.CommandManager.Id = New System.Guid("ec1247f7-d55b-40e6-b35b-d363946ff7b4")
        Me.CommandManager.LeftRebar = Me.LeftRebar1
        Me.CommandManager.RightRebar = Me.RightRebar1
        Me.CommandManager.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.TopRebar = Me.TopRebar1
        Me.CommandManager.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.CommandManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.CommandManager
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Archivo1, Me.Ayuda2})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(517, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'Archivo1
        '
        Me.Archivo1.Key = "Archivo"
        Me.Archivo1.Name = "Archivo1"
        '
        'Ayuda2
        '
        Me.Ayuda2.Key = "Ayuda"
        Me.Ayuda2.Name = "Ayuda2"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.CommandManager
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Nuevo3, Me.Separator7, Me.Guardar3, Me.Separator8, Me.Imprimir3, Me.Separator9, Me.Ayuda3})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(149, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'Nuevo3
        '
        Me.Nuevo3.Key = "Nuevo"
        Me.Nuevo3.Name = "Nuevo3"
        Me.Nuevo3.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'Guardar3
        '
        Me.Guardar3.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.Guardar3.Key = "Guardar"
        Me.Guardar3.Name = "Guardar3"
        Me.Guardar3.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'Imprimir3
        '
        Me.Imprimir3.Key = "Imprimir"
        Me.Imprimir3.Name = "Imprimir3"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'Ayuda3
        '
        Me.Ayuda3.Image = CType(resources.GetObject("Ayuda3.Image"), System.Drawing.Image)
        Me.Ayuda3.Key = "Ayuda"
        Me.Ayuda3.Name = "Ayuda3"
        '
        'Nuevo
        '
        Me.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.Nuevo.Icon = CType(resources.GetObject("Nuevo.Icon"), System.Drawing.Icon)
        Me.Nuevo.Key = "Nuevo"
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Text = "&Nuevo"
        '
        'Guardar
        '
        Me.Guardar.Icon = CType(resources.GetObject("Guardar.Icon"), System.Drawing.Icon)
        Me.Guardar.Key = "Guardar"
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Text = "&Guardar"
        Me.Guardar.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Imprimir
        '
        Me.Imprimir.Icon = CType(resources.GetObject("Imprimir.Icon"), System.Drawing.Icon)
        Me.Imprimir.Key = "Imprimir"
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Text = "&Imprimir"
        '
        'Salir
        '
        Me.Salir.Key = "Salir"
        Me.Salir.Name = "Salir"
        Me.Salir.Text = "&Salir"
        '
        'Ayuda
        '
        Me.Ayuda.Key = "Ayuda"
        Me.Ayuda.Name = "Ayuda"
        Me.Ayuda.Text = "&Ayuda"
        '
        'Archivo
        '
        Me.Archivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Nuevo2, Me.Guardar2, Me.Separator5, Me.Imprimir2, Me.Separator6, Me.Salir1})
        Me.Archivo.Key = "Archivo"
        Me.Archivo.Name = "Archivo"
        Me.Archivo.Text = "&Archivo"
        '
        'Nuevo2
        '
        Me.Nuevo2.Key = "Nuevo"
        Me.Nuevo2.Name = "Nuevo2"
        Me.Nuevo2.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'Guardar2
        '
        Me.Guardar2.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.Guardar2.Key = "Guardar"
        Me.Guardar2.Name = "Guardar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'Imprimir2
        '
        Me.Imprimir2.Key = "Imprimir"
        Me.Imprimir2.Name = "Imprimir2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'Salir1
        '
        Me.Salir1.Key = "Salir"
        Me.Salir1.Name = "Salir1"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.CommandManager
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.CommandManager
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.CommandManager
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(517, 50)
        '
        'Nuevo1
        '
        Me.Nuevo1.Key = "Nuevo"
        Me.Nuevo1.Name = "Nuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'Guardar1
        '
        Me.Guardar1.Key = "Guardar"
        Me.Guardar1.Name = "Guardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Imprimir1
        '
        Me.Imprimir1.Key = "Imprimir"
        Me.Imprimir1.Name = "Imprimir1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'Ayuda1
        '
        Me.Ayuda1.Key = "Ayuda"
        Me.Ayuda1.Name = "Ayuda1"
        '
        'FrmValeCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(517, 359)
        Me.Controls.Add(Me.npArticulo)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmValeCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vale de Caja"
        Me.npArticulo.ResumeLayout(False)
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Miembros"

    Private oValeCajaManager As ValeCajaManager

    Public oValeCaja As ValeCaja

    Public intValeCajaID As Integer

    Private oNotaCredito As NotaCredito

    Private oDistribucionContrato As DistribucionNC

    Private bolGenerarValeCaja As Boolean

    Private decMontoAFavor As Decimal

    Private bolSalir As Boolean

    Private FolioValeUtilizado As Integer

    Private dblPagoMovimiento As Double

    Private dblMontEfvo As Double

    Private dblMontValeCaja As Double

    Private boFacturasPorLiquidar As Boolean

#End Region

#Region "Propiedades"

    ''' <summary>
    ''' Variable para determinar si la pantalla se debe mostrar completamente en modo desatendido (cargas masivas de notas de crédito)
    ''' </summary>
    ''' <remarks></remarks>
    Public Desatendido As Boolean = False

    Public Property ValeCaja() As ValeCaja

        Get
            Return oValeCaja
        End Get

        Set(ByVal Value As ValeCaja)

            oValeCaja = Value

        End Set

    End Property


    Public WriteOnly Property NotaCredito() As NotaCredito

        Set(ByVal Value As NotaCredito)

            oNotaCredito = Value

        End Set

    End Property



    Public WriteOnly Property DistribucionContrato() As DistribucionNC

        Set(ByVal Value As DistribucionNC)

            oDistribucionContrato = Value

        End Set

    End Property



    Public WriteOnly Property MontoAFavor() As Decimal

        Set(ByVal Value As Decimal)

            decMontoAFavor = Value

        End Set

    End Property


    Public WriteOnly Property FacturasPorLiquidar() As Boolean

        Set(ByVal Value As Boolean)

            boFacturasPorLiquidar = Value

        End Set

    End Property

    Public WriteOnly Property DevolucionEfectivo() As Boolean

        Set(ByVal Value As Boolean)

            bDevEfec = Value

        End Set

    End Property

    Public Sub ShowDev()

        Sm_Inicializar()

        Sm_GenerarValeCaja()

    End Sub


#End Region

#Region "Metodos Privados"

    Public Sub Sm_Inicializar()

        oValeCajaManager = New ValeCajaManager(oAppContext)

        Sm_Configuracion()


        If Not oNotaCredito Is Nothing Then

            If ebFolioDocumento.Text.Trim = String.Empty Then
                ebFolioDocumento.Text = 0
            End If

            Dim vlComando As String

            vlComando = ""
            dblMontEfvo = 0
            chkDevDinero.Enabled = False

            vlComando = "SELECT SUM(F.Monto) as Efectivo " & _
                        "From (" & _
                        "SELECT DISTINCT NotasCredito.FolioNotaCredito, NotasCreditoDetalle.FolioReferencia " & _
                        "FROM NotasCredito INNER JOIN NotasCreditoDetalle ON NotasCredito.NotaCreditoID=NotasCreditoDetalle.NotaCreditoID " & _
                        ") " & _
                        "As NC Inner Join( " & _
                        "SELECT Factura.FolioFactura, Factura.CodTipoVenta, FacturasFormasPago.CodFormasPago, " & _
                        "FacturasFormasPago.MontoPago As Monto " & _
                        "FROM Factura INNER JOIN FacturasFormasPago ON Factura.FacturaID=FacturasFormasPago.FacturaID " & _
                        "GROUP BY Factura.FolioFactura, Factura.CodTipoVenta, FacturasFormasPago.CodFormasPago,FacturasFormasPago.MontoPago " & _
                        ") " & _
                        "AS F ON NC.FolioReferencia=F.FolioFactura WHERE NC.FolioNotaCredito=" & Me.ebFolioDocumento.Text & " And F.CodFormasPago='EFEC' And F.CodTipoVenta IN('P','I') "  'oNotaCredito.NotaCreditoFolio
            If vlComando <> "" Then
                Dim dsMultU As DataSet, drMultU As DataRow

                dsMultU = oValeCajaManager.DevEfvoVal(vlComando, "F")
                For Each drMultU In dsMultU.Tables(0).Rows
                    If Not IsDBNull(drMultU!Efectivo) Then
                        chkDevDinero.Enabled = True
                        dblMontEfvo = drMultU!Efectivo
                    End If
                Next
                dsMultU = Nothing
            End If
        Else

            If ebFolioDocumento.Text.Trim = String.Empty Then
                ebFolioDocumento.Text = 0
            End If

            If oValeCaja.TipoDocumento = "CA" Then
                Dim vlComando As String

                vlComando = ""
                dblMontEfvo = 0
                chkDevDinero.Enabled = False

                vlComando = "SELECT Sum(AbonosApartados.Abono) As Efectivo " & _
                            "FROM Apartados INNER JOIN AbonosApartados ON Apartados.ApartadoID=AbonosApartados.ApartadoID " & _
                            "WHERE Apartados.FolioApartado=" & ebFolioDocumento.Text & " And AbonosApartados.CodFormaPago='EFEC' And AbonosApartados.StatusRegistro=1;"
                If vlComando <> "" Then
                    Dim dsMultU As DataSet, drMultU As DataRow

                    dsMultU = oValeCajaManager.DevEfvoVal(vlComando, "F")
                    For Each drMultU In dsMultU.Tables(0).Rows
                        If Not IsDBNull(drMultU!Efectivo) Then
                            chkDevDinero.Enabled = True
                            dblMontEfvo = drMultU!Efectivo
                        End If
                    Next
                    dsMultU = Nothing
                End If
            End If
        End If
    End Sub



    'Private Sub Sm_Finalizar()

    'oValeCajaManager = Nothing

    'oValeCaja = Nothing

    'End Sub


    Private Sub Sm_Configuracion()

        If (oValeCaja Is Nothing) Then

            'Se Cancela o se Habilita o Deshabilita un Vale de Caja :

            oValeCaja = oValeCajaManager.Create

            bolSalir = True

            btnImprimir.Enabled = False

            ebFolio.BackColor = ebMotivo.BackColor

            ebFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image

            ebMotivo.Enabled = True

            ebFolio.TabStop = True

            ebMotivo.TabStop = True

            ebNombre.TabStop = False

        Else

            'Se genera un Vale de Caja por Nota de Credito, Factura o Abonos :

            bolGenerarValeCaja = True

            If (oValeCaja.CodCliente.PadLeft(10, "0") = "1".PadLeft(10, "0")) Then

                ebNombre.Enabled = True
                ebNombre.BackColor = ebMotivo.BackColor
                ebNombre.ReadOnly = False

                ebNombre.Focus()

            End If

            btnGuardar.Enabled = False

            Sm_MostrarInformacion()

            ebFolio.Text = oValeCajaManager.Folios

        End If

    End Sub



    Private Sub Sm_TxtLimpiar()

        oValeCaja = Nothing

        ebFolio.Text = String.Empty

        ebFecha.Text = String.Empty

        ebImporte.Text = String.Empty

        ebTipoDocumento.Text = String.Empty

        ebFolioDocumento.Text = String.Empty

        ebCodCliente.Text = String.Empty

        ebNombre.Text = String.Empty

        dblMontValeCaja = 0
        dblMontEfvo = 0

        chkDevDinero.Checked = False
        chkDevDinero.Enabled = False

        chkHabilitar.Checked = False

        ebMotivo.Text = String.Empty

    End Sub



    Private Sub Sm_MostrarInformacion()

        With oValeCaja

            ebFolio.Text = .ValeCajaID

            ebFecha.Text = Format(.Fecha, "dd - MMM - yyyy")

            ebImporte.Text = Format(.Importe, "Standard")
            dblMontValeCaja = ebImporte.Text

            ebTipoDocumento.Text = .TipoDocumento

            ebFolioDocumento.Text = .FolioDocumento

            ebCodCliente.Text = .CodCliente

            'If (oValeCaja.CodCliente.PadLeft(10, "0") = "1".PadLeft(10, "0")) Then

            '    ebNombre.Text = String.Empty

            'Else

            ebNombre.Text = .Nombre

            'End If

            chkDevDinero.Checked = .DevEfectivo

            chkHabilitar.Checked = .StastusRegistro

            ebMotivo.Text = .Motivo

        End With

    End Sub



    Public Sub Sm_ActionPrintValeCajaNotaCredito(ByVal pValeCaja As ValeCaja)

        ' AF (14-11-2016): En modo desatendido no debe mostrar ninguna ventana
        If Desatendido Then
            Exit Sub
        End If
        ' AF (14-11-2016): En modo desatendido no debe mostrar ninguna ventana

        If boFacturasPorLiquidar = False Then

            Dim oARReporte
            Dim oView As New ReportViewerForm

            If oConfigCierreFI.MiniPrinter Then

                'Sacar folio SAP de la Factura
                Dim strFolioSAP As String = String.Empty
                'strFolioSAP = oValeCajaManager.SelectNCID(oValeCaja.DocumentoID)
                strFolioSAP = oValeCajaManager.SelectNCID(pValeCaja.DocumentoID)

                oARReporte = New ValeCajaNotaCreditoMiniPrinter(pValeCaja, oNotaCredito.TipoVentaID, strFolioSAP)
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

            Else

                oARReporte = New ValeCajaNotaCredito(pValeCaja, oNotaCredito.TipoVentaID)

            End If

            oARReporte.Run()

            Try

                'Imprimir Directo :
                oARReporte.Document.Print(False, False)
                'oView.Report = oARReporte
                'oView.Show()

            Catch ex As Exception

                Throw New ApplicationException("Se produjó un error al Imprimir.", ex)

            End Try

            oARReporte = Nothing

        End If

    End Sub

    Public Sub Sm_ActionPrintValeCajaContrato()

        If boFacturasPorLiquidar = False Then
            Dim oARReporte

            If oConfigCierreFI.MiniPrinter Then

                oARReporte = New ValeCajaContratoMiniPrinter(oValeCaja, oDistribucionContrato, decMontoAFavor)
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

            Else

                oARReporte = New ValeCajaContrato(oValeCaja, oDistribucionContrato, decMontoAFavor)

            End If

            oARReporte.Run()

            Try

                'Imprimir Directo :
                oARReporte.Document.Print(False, False)

            Catch ex As Exception

                Throw New ApplicationException("Se produjó un error al Imprimir.", ex)

            End Try

            oARReporte = Nothing

        End If

    End Sub

    Public Sub Sm_ActionPrintValeCajaDevEfectivo(ByRef pValeCaja As ValeCaja)

        If boFacturasPorLiquidar = False Then

            Dim oARReporte

            If oConfigCierreFI.MiniPrinter Then

                oARReporte = New ValeCajaDevEfectivoMiniPrinter(pValeCaja)
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

            Else

                oARReporte = New ValeCajaDevEfectivo(pValeCaja)

            End If

            oARReporte.Run()

            Try

                'Dim RepView As New ReportViewerForm
                'RepView.Report = oARReporte
                'RepView.Show()

                'Imprimir Directo :
                oARReporte.Document.Print(False, False)

            Catch ex As Exception

                Throw New ApplicationException("Se produjó un error al Imprimir.", ex)

            End Try

            oARReporte = Nothing

        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'JNAVA (08/05/2013) - Metodo para imprimir el Vale de Caja de un pedido Si Hay
    Public Sub Sm_ActionPrintValeCajaPedidoSiHay(ByVal pValeCaja As ValeCaja)

        Dim oPedido As Pedidos
        'Consultamos pedido por ID
        oPedido = New Pedidos(pValeCaja.DocumentoID, 0)

        If boFacturasPorLiquidar = False Then

            Dim oARReporte
            Dim oView As New ReportViewerForm

            If oConfigCierreFI.MiniPrinter Then

                'Sacar folio SAP del pedido
                Dim strFolioSAP As String = String.Empty
                strFolioSAP = oPedido.FolioSAP

                oARReporte = New ValeCajaNotaCreditoMiniPrinter(pValeCaja, oPedido.CodTipoVenta, strFolioSAP)
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

            Else

                oARReporte = New ValeCajaNotaCredito(pValeCaja, oPedido.CodTipoVenta)

            End If

            oARReporte.Run()

            Try

                'Imprimir Directo :
                oARReporte.Document.Print(False, False)
                'oView.Report = oARReporte
                'oView.Show()

            Catch ex As Exception

                Throw New ApplicationException("Se produjó un error al Imprimir.", ex)

            End Try

            oARReporte = Nothing

        End If

    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        If (ebNombre.Text.Trim = String.Empty) Then

            MsgBox("No ha sido capturado el Nombre del Cliente.", MsgBoxStyle.Exclamation, "DPTienda")
            ebNombre.Focus()

            Exit Function

        End If

        Return True

    End Function



    Private Sub Sm_GenerarValeCaja()

        If (bolGenerarValeCaja = False) Then

            MsgBox("No puede ejecutar esta Opción.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If
        Try
            If (oValeCaja.CodCliente.PadLeft(10, "0") = "10000000".PadLeft(10, "0")) Then

                If bShow Then
                    'Validar que se haya capturado el nombre del Cliente :

                    If (Fm_bolTxtValidar() = False) Then

                        Exit Sub

                    End If

                Else
                    Me.ebNombre.Text = "Publico en General"
                End If

                oValeCaja.Nombre = ebNombre.Text

            End If

        Catch ex As Exception
            Throw New ApplicationException("Validar Cliente", ex)
        End Try
        'Capturar Nombre del Cliente.


        'Imprimir :

        Select Case oValeCaja.TipoDocumento.ToUpper

            Case "NC" 'Nota Credito.
                Try
                    If (oValeCajaManager Is Nothing) Then
                        oValeCajaManager = New ValeCajaManager(oAppContext)
                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Vala Caja Manager", ex)
                End Try

                'Asegurar que la fecha corresponda a la fecha actual
                oValeCaja.Fecha = Now

                If chkDevDinero.Checked = True Then
                    If chkHabilitar.Checked = True Then
                        Try
                            oValeCaja.Importe = dblMontEfvo
                            oValeCaja.DocumentoImporte = dblMontEfvo
                            oValeCaja.StastusRegistro = False

                            Dim oValeCaja2 As ValeCaja

                            oValeCaja2 = oValeCajaManager.Create


                            oValeCaja2.DistribucionDetalle = oValeCaja.DistribucionDetalle
                            oValeCaja2.DistribucionDetalle.Tables("AnticiposClientesDetalle").Rows(0).Item("TotalAC") = (dblMontValeCaja - dblMontEfvo) - Me.MontoTarjetaCredito - Me.MontoFonacot
                            oValeCaja2.CodCliente = oValeCaja.CodCliente
                            oValeCaja2.DocumentoID = oValeCaja.DocumentoID
                            oValeCaja2.Fecha = oValeCaja.Fecha
                            oValeCaja2.FolioDocumento = oValeCaja.FolioDocumento
                            oValeCaja2.MontoUtilizado = 0
                            oValeCaja2.Motivo = oValeCaja.Motivo
                            oValeCaja2.Nombre = oValeCaja.Nombre
                            oValeCaja2.TipoDocumento = oValeCaja.TipoDocumento
                            oValeCaja2.Usuario = oValeCaja.Usuario
                            oValeCaja2.ValeGenerado = oValeCaja.ValeGenerado
                            oValeCaja2.Importe = dblMontValeCaja - dblMontEfvo
                            oValeCaja2.DocumentoImporte = dblMontValeCaja - dblMontEfvo
                            oValeCaja2.DevEfectivo = False
                            oValeCaja2.StastusRegistro = True

                            oValeCajaManager.Save(oValeCaja)
                            Sm_ActionPrintValeCajaDevEfectivo(oValeCaja)

                            oValeCajaManager.Save(oValeCaja2)
                            Sm_ActionPrintValeCajaNotaCredito(oValeCaja2)
                        Catch ex As Exception
                            Throw New ApplicationException("Dev. Dinero, Habilitar.", ex)
                        End Try


                    Else
                        Try
                            oValeCaja.DistribucionDetalle.Tables("AnticiposClientesDetalle").Rows(0).Item("TotalAC") = (dblMontValeCaja - dblMontEfvo) - Me.MontoTarjetaCredito - Me.MontoFonacot
                            oValeCajaManager.Save(oValeCaja)
                            Sm_ActionPrintValeCajaDevEfectivo(oValeCaja)

                        Catch ex As Exception
                            Throw New ApplicationException("Dev. Dinero, Not Habilitar.", ex)
                        End Try

                    End If
                Else
                    Try
                        'VALE CAJA
                        'Le reste el monto fonacot con motivo de que generaba el vale en 0 cuando se regresaba todo de Fonacot
                        oValeCaja.DistribucionDetalle.Tables("AnticiposClientesDetalle").Rows(0).Item("TotalAC") = dblMontValeCaja - Me.MontoTarjetaCredito - Me.MontoFonacot
                        oValeCajaManager.Save(oValeCaja)

                        'Fonacot Facilito change
                        If oNotaCredito.TipoVentaID = "F" Or oNotaCredito.TipoVentaID = "O" Or oNotaCredito.TipoVentaID = "K" Then

                            '---------------------------------------------------------------------
                            ' JNAVA (24.03.2017): Validamos si está activa la nueva facturacion
                            '---------------------------------------------------------------------
                            'Mandar llamar el formulario de facturacion y mandarle el 
                            'objeto de vale de caja y notacredito completo
                            If oConfigCierreFI.FacturacionNueva Then
                                Dim oFormFact As New frmFacturacionNueva
                                oFormFact.oNotaCredito = oNotaCredito
                                oFormFact.oValeCaja = oValeCaja
                                oFormFact.bolNC = True
                                oFormFact.ShowDialog()

                                If oFormFact.FacturaGuardada = False Then
                                    Sm_ActionPrintValeCajaNotaCredito(oValeCaja)
                                End If
                            Else
                                Dim oFormFact As New frmFacturacion
                                oFormFact.oNotaCredito = oNotaCredito
                                oFormFact.oValeCaja = oValeCaja
                                oFormFact.bolNC = True
                                oFormFact.ShowDialog()

                                If oFormFact.FacturaGuardada = False Then
                                    Sm_ActionPrintValeCajaNotaCredito(oValeCaja)
                                End If
                            End If
                            '---------------------------------------------------------------------
                            
                            '*********************************
                            'Para facturacion
                            'YA declarar un objeto tipo valecaja para almacenar la informacion
                            'al momento de facturar tengo que validar si el objeto de vale de caja tiene algo
                            'y no preguntar el numero de autorizacion o datos de la hoja de fonacot
                            'por ke ya se capturaron en la factura original
                            'tengo que ver que se iguale el total de adeudo de la factura original
                            'al momento de realizarla.
                            '********************************************************

                        Else
                            'Esta linea se ejecutaba independientemente de la validacion en curso
                            'Dont Delete me
                            Sm_ActionPrintValeCajaNotaCredito(oValeCaja)
                        End If


                    Catch ex As Exception
                        Throw New ApplicationException("Not Dev. Dinero, Not Habilitar.", ex)
                    End Try


                End If
                Try
                    intValeCajaID = oValeCaja.ValeCajaID
                Catch ex As Exception
                    Throw New ApplicationException("Asignacion valecajaID.", ex)
                End Try


            Case "CA" 'Contrato Apartado.
                Try
                    If (oValeCajaManager Is Nothing) Then
                        oValeCajaManager = New ValeCajaManager(oAppContext)
                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Vale Caja Manager, -Contrato Apartado-.", ex)
                End Try
                '--------------------------------------------------------------------------------------------------------------------------------
                'Si es un vale de caja por devolucion de dinero de una cancelacion de apartado se deshabilita, para que no se pueda usar en 
                'una venta nueva (03/07/2012 v20120701)
                '--------------------------------------------------------------------------------------------------------------------------------
                If Me.chkDevDinero.Checked Then
                    oValeCaja.StastusRegistro = False
                    oValeCaja.MontoUtilizado = oValeCaja.Importe
                End If

                Try
                    oValeCajaManager.Save(oValeCaja)
                    intValeCajaID = oValeCaja.ValeCajaID
                Catch ex As Exception
                    Throw New ApplicationException("Save, -Contrato Apartado-.", ex)
                End Try

                Try
                    If chkDevDinero.Checked = True Then

                        Sm_ActionPrintValeCajaDevEfectivo(oValeCaja)

                    Else

                        Sm_ActionPrintValeCajaContrato()

                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Impresion, -Contrato Apartado-.", ex)
                End Try


            Case "VC" 'Vale Caja.

            Case "AB", "FA" 'Abono, Factura.

                Try
                    If (oValeCajaManager Is Nothing) Then
                        oValeCajaManager = New ValeCajaManager(oAppContext)
                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Vale Caja Manager, -Abono, Factura-.", ex)
                End Try

                Try
                    oValeCajaManager.Save(oValeCaja)
                    intValeCajaID = oValeCaja.ValeCajaID
                Catch ex As Exception
                    Throw New ApplicationException("Save, -Abono, Factura-.", ex)
                End Try

                Try
                    Sm_ActionPrintValeCajaXDiferencia()
                Catch ex As Exception
                    Throw New ApplicationException("Impresion, -Abono, Factura-.", ex)
                End Try

                Me.DialogResult = DialogResult.OK


            Case "PI", "CF", "CP" 'Pedidos Si Hay
                '-----------------------------------------------------------------------------------------------------------------------------------------
                'JNAVA - 30/04/2013: Imprimimos el Vale de Caja a partir Tipo de Documento PI, CF o CP (NUEVO).
                '-----------------------------------------------------------------------------------------------------------------------------------------
                Try
                    If (oValeCajaManager Is Nothing) Then
                        oValeCajaManager = New ValeCajaManager(oAppContext)
                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Vale Caja Manager, -Pedidos Si Hay-.", ex)
                End Try

                ''Si es un vale de caja por devolucion de dinero, se deshabilita y se pone el importe en el
                ''MontoUtilizado para que no se pueda usar en una venta nueva.
                If bDevEfec Then
                    oValeCaja.StastusRegistro = False
                    oValeCaja.MontoUtilizado = oValeCaja.Importe
                End If

                Try
                    oValeCajaManager.Save(oValeCaja)
                    intValeCajaID = oValeCaja.ValeCajaID
                Catch ex As Exception
                    Throw New ApplicationException("Save, -Pedidos Si Hay-.", ex)
                End Try

                Try
                    If bDevEfec Then
                        Sm_ActionPrintValeCajaDevEfectivo(oValeCaja)
                    Else
                        Sm_ActionPrintValeCajaPedidoSiHay(oValeCaja)
                    End If
                Catch ex As Exception
                    Throw New ApplicationException("Impresion, -Pedidos Si Hay.", ex)
                End Try

        End Select

        bolSalir = True

        'MsgBox("El Registro ha sido Guardado.", MsgBoxStyle.Information, "DPTienda")

        Me.Close()

    End Sub



    Private Function Fm_bolTxtValidarDevEfectivo() As Boolean

        If (oValeCaja Is Nothing) Then

            MsgBox("No ha sido seleccionado un Vale de Caja.", MsgBoxStyle.Exclamation, "DPTienda")
            ebFolio.Focus()

            Exit Function

        End If


        'Que no haya sido Cancelado.  
        If (oValeCaja.DevEfectivo = True) Then

            MsgBox("El Vale de Caja se encuentra Cancelado.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function
        End If


        If (chkDevDinero.Checked = True) And (chkHabilitar.Checked = True) Then

            MsgBox("No puede Cancelar y Deshabilitar el Vale de Caja a la vez.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Function

        End If


        'Devolver Efectivo :

        If (chkDevDinero.Checked = True) Then

            If (oValeCaja.StastusRegistro = False) Then

                MsgBox("El Vale de Caja se encuentra Deshabilitado.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Function

            End If


            If (ebMotivo.Text.Trim = String.Empty) Then

                MsgBox("El Motivo es requerido.", MsgBoxStyle.Exclamation, "DPTienda")
                ebMotivo.Focus()

                Exit Function

            End If

        End If


        Return True

    End Function



    Private Sub Sm_ActualizarValeCaja()

        If (bolGenerarValeCaja = True) Then

            MsgBox("No puede ejecutar esta Opción.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        If (Fm_bolTxtValidarDevEfectivo() = False) Then

            Exit Sub

        End If


        If (chkDevDinero.Checked = True) Then

            If (MsgBox("¿Esta seguro que desea continuar? ¡Esto significa que la cantidad mostrada " & vbCrLf _
                       & "sera entrega al cliente en este momento!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + _
                       MsgBoxStyle.DefaultButton2, "DPTienda") = MsgBoxResult.No) Then

                Exit Sub

            End If


            With oValeCaja

                .DevEfectivo = True
                .StastusRegistro = False

            End With


            'Imprimir Dev. de Efectivo :
            Sm_ActionPrintValeCajaDevEfectivo(oValeCaja)


            'Se verifica si se realizaron modificaciones :
        ElseIf (chkHabilitar.Checked = True) And (oValeCaja.StastusRegistro <> chkHabilitar.Checked) Then

            If (MsgBox("¿Esta seguro que desea continuar?" & vbCrLf & "¡Esto significa que el Vale de Caja podra ser utilizado.", _
                        MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DPTienda") = MsgBoxResult.No) Then

                Exit Sub

            End If


            oValeCaja.StastusRegistro = True


            'Se verifica si se realizaron modificaciones :
        ElseIf (chkHabilitar.Checked = False) And (oValeCaja.StastusRegistro <> chkHabilitar.Checked) Then

            If (MsgBox("¿Esta seguro que desea continuar?" & vbCrLf & "¡Esto significa que el Vale de Caja no podra ser utilizado.", _
                        MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "DPTienda") = MsgBoxResult.No) Then

                Exit Sub

            End If


            oValeCaja.StastusRegistro = False

        Else

            MsgBox("No se han realizado modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If



        oValeCajaManager.Save(oValeCaja)

        Dim intValeCajaID As Integer = oValeCaja.ValeCajaID

        oValeCaja = Nothing
        oValeCaja = oValeCajaManager.Load(intValeCajaID)

        Sm_MostrarInformacion()


        MsgBox("El Registro ha sido Guardado.", MsgBoxStyle.Information, "DPTienda")

    End Sub



    Private Sub Sm_Nuevo()

        If (bolGenerarValeCaja = True) Then

            MsgBox("No puede ejecutar esta Opción.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        Sm_TxtLimpiar()

    End Sub



    Private Sub Sm_BuscarValeCaja(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If (bolGenerarValeCaja = True) Then

            MsgBox("No puede ejecutar esta Opción.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If


        If (Vpa_bolOpenRecordDialog = True) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New ValeCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oValeCaja = Nothing
                oValeCaja = oValeCajaManager.Load(oOpenRecordDlg.Record.Item("ValeCajaID"))

                Sm_MostrarInformacion()

            End If

        Else

            If (ebFolio.Text.Trim = String.Empty) Then

                Exit Sub

            End If


            oValeCaja = Nothing
            oValeCaja = oValeCajaManager.Load(ebFolio.Text)

            '<Validación>

            If (oValeCaja Is Nothing) Then

                MessageBox.Show("El Registro no existe.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Sm_TxtLimpiar()
                ebFolio.Focus()

                Exit Sub

            End If

            '</Validación>

            Sm_MostrarInformacion()

        End If

    End Sub


#End Region

#Region "Metodos Privados [Eventos]"

    Private Sub FrmValeCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()
        If Not oNotaCredito Is Nothing Then
            If oNotaCredito.TipoVentaID = "F" Or oNotaCredito.TipoVentaID = "O" Or oNotaCredito.TipoVentaID = "K" Then
                Me.btnImprimir.Text = "Facturar"
            End If
        End If
        If Me.canModif = False Then
            If Me.DevEfectOpt = True Then
                Me.chkHabilitar.Checked = False
                Me.chkDevDinero.Checked = True
            ElseIf Me.ValeCajaOpt = True Then
                Me.chkHabilitar.Checked = True
                Me.chkDevDinero.Checked = False
            End If

            Me.chkDevDinero.Enabled = False
            Me.chkHabilitar.Enabled = False
        End If

        If bShow = False Then Sm_GenerarValeCaja()

    End Sub

    Private Sub FrmValeCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If (bolSalir = False) Then

            MsgBox("No ha sido Guardado el Anticipo a Cliente.", MsgBoxStyle.Exclamation, "DPTienda")

            e.Cancel = True

        End If


        'Sm_Finalizar()

    End Sub

    Private Sub FrmValeCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub CommandManager_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles CommandManager.CommandClick

        Select Case e.Command.Key

            Case "Nuevo"

                Sm_Nuevo()


            Case "Guardar" 'Devolucion de Efectivo.

                Sm_ActualizarValeCaja()


            Case "Imprimir" 'Generar Vale de Caja.

                Sm_GenerarValeCaja()


            Case "Ayuda"


            Case "Salir"

                If (bolGenerarValeCaja = False) Then

                    bolSalir = True

                End If


                Me.Close()

        End Select

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Sm_GenerarValeCaja()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_ActualizarValeCaja()

    End Sub

    Private Sub ebFolio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFolio.ButtonClick

        Sm_BuscarValeCaja(True)

    End Sub

    Private Sub ebFolio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFolio.Validating

        If (ebFolio.Text.Trim = String.Empty) Then

            Exit Sub

        End If


        'If (ebFolio.Text <> 0) Then

        Sm_BuscarValeCaja()

        'End If

    End Sub

    Private Sub chkDevDinero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDevDinero.CheckedChanged

        If (chkDevDinero.Checked = True) Then
            If ebImporte.Text <= dblMontEfvo Then
                chkHabilitar.Checked = False
                chkHabilitar.Enabled = False
            Else
                ebImporte.Text = Format(dblMontValeCaja - dblMontEfvo, "Standard")
                chkHabilitar.Checked = True
            End If
        Else
            chkHabilitar.Enabled = True
            chkHabilitar.Checked = True
            ebImporte.Text = Format(dblMontValeCaja, "Standard")
        End If
        oValeCaja.DevEfectivo = chkDevDinero.Checked
        oValeCaja.StastusRegistro = chkHabilitar.Checked
    End Sub

#End Region

    Public Sub ValeCajaNuevo(ByVal oValeCajaNuevo As ValeCaja, ByVal FolioValeUti As Integer, ByVal PagoMovimiento As Double, Optional ByVal Automatico As Boolean = False)

        oValeCaja = oValeCajaNuevo
        dblPagoMovimiento = PagoMovimiento

        With oValeCaja

            Me.ebFecha.Text = .Fecha
            Me.ebImporte.Text = .Importe
            Me.ebTipoDocumento.Text = .TipoDocumento
            Me.ebFolioDocumento.Text = .FolioDocumento
            Me.ebCodCliente.Text = .CodCliente
            Me.ebNombre.Text = .Nombre
            FolioValeUtilizado = FolioValeUti

            Select Case .TipoDocumento

                Case "FA"
                    lblDescripGen.Text = "FACTURA"
                Case "NC"
                    lblDescripGen.Text = "NOTA CRED."
                Case "AB"
                    lblDescripGen.Text = "ABONO"
                Case "VC"
                    lblDescripGen.Text = "VALE CAJA"
                Case Else
                    lblDescripGen.Text = ""
            End Select

        End With

        If Automatico Then
            Sm_Inicializar()
            Me.btnImprimir.PerformClick()
        Else
            Me.ShowDialog()
        End If


    End Sub


    Public Sub Sm_ActionPrintValeCajaXDiferencia()

        If boFacturasPorLiquidar = False Then

            Dim oARReporte

            If oConfigCierreFI.MiniPrinter Then

                oARReporte = New rptValeCajaAbonoCreditoMiniprinter(oValeCaja, FolioValeUtilizado, dblPagoMovimiento)
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName

            Else

                oARReporte = New rptValeCajaAbonoCredito(oValeCaja, FolioValeUtilizado, dblPagoMovimiento)

            End If

            oARReporte.Run()


            Try

                'Imprimir Directo :
                oARReporte.Document.Print(False, False)

            Catch ex As Exception

                Throw New ApplicationException("Se produjó un error. El Reporte Cierre de Dia Notas de Crédito no pudo ser impreso.", ex)

            End Try

            oARReporte = Nothing

        End If

    End Sub

    Public Property MontoTarjetaCredito() As Decimal
        Get
            Return m_decMontoTarjetaCredito
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoTarjetaCredito = Value
        End Set
    End Property

    Public Property MontoFonacot() As Decimal
        Get
            Return m_decMontoFonacot
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoFonacot = Value
        End Set
    End Property

    Public Property canModif() As Boolean
        Get
            Return m_bcanModif
        End Get
        Set(ByVal Value As Boolean)
            m_bcanModif = Value
        End Set
    End Property

    Public Property DevEfectOpt() As Boolean
        Get
            Return m_bDevEfectOpt
        End Get
        Set(ByVal Value As Boolean)
            m_bDevEfectOpt = Value
        End Set
    End Property

    Public Property ValeCajaOpt() As Boolean
        Get
            Return m_bValeCajaOpt
        End Get
        Set(ByVal Value As Boolean)
            m_bValeCajaOpt = Value
        End Set
    End Property

End Class
