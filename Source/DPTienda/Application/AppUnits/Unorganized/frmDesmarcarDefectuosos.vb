Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX
Imports System.IO

Public Class frmDesmarcarDefectuosos
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nebFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gexGeneral As Janus.Windows.GridEX.GridEX
    Friend WithEvents gexDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebCodigo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbTotalArticulos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebResponsable As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mnuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOAyuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesmarcarDefectuosos))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.NicePanel2 = New PureComponents.NicePanel.NicePanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gexDetalle = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gexGeneral = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ebResponsable = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.nbTotalArticulos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodigo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nebFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.mnuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("mnuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuOAyuda2 = New Janus.Windows.UI.CommandBars.UICommand("menuOAyuda")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.mnuAyuda = New Janus.Windows.UI.CommandBars.UICommand("mnuAyuda")
        Me.menuOAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuOAyuda")
        Me.menuOAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuOAyuda")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.NicePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gexDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gexGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BackgroundFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.NicePanel2)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox2)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsable)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar1.Controls.Add(Me.nbTotalArticulos)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigo)
        Me.ExplorerBar1.Controls.Add(Me.nebFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.FlatBorderColor = System.Drawing.Color.Transparent
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos de los Articulos:"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(634, 465)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'NicePanel2
        '
        Me.NicePanel2.BackColor = System.Drawing.Color.Transparent
        Me.NicePanel2.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.NicePanel2.ContainerImage = ContainerImage1
        Me.NicePanel2.ContextMenuButton = False
        Me.NicePanel2.Controls.Add(Me.Panel1)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.NicePanel2.FooterImage = HeaderImage1
        Me.NicePanel2.FooterText = "Grupo DPortenis @ 2016"
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Foto del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(350, 66)
        Me.NicePanel2.Name = "NicePanel2"
        Me.NicePanel2.OriginalFooterVisible = True
        Me.NicePanel2.OriginalHeight = 0
        Me.NicePanel2.Size = New System.Drawing.Size(264, 200)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(252, Byte), Integer))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
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
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(251, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.NicePanel2.Style = PanelStyle1
        Me.NicePanel2.TabIndex = 128
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.pbImagen)
        Me.Panel1.Location = New System.Drawing.Point(1, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 158)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Tag = "NicePanelAutoScroll"
        Me.Panel1.Text = "NicePanelAutoScroll"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImagen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbImagen.ForeColor = System.Drawing.Color.Black
        Me.pbImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(262, 158)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 129
        Me.pbImagen.TabStop = False
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.gexDetalle)
        Me.UiGroupBox2.Location = New System.Drawing.Point(438, 297)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(178, 117)
        Me.UiGroupBox2.TabIndex = 127
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gexDetalle
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gexDetalle.DesignTimeLayout = GridEXLayout1
        Me.gexDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gexDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gexDetalle.GroupByBoxVisible = False
        Me.gexDetalle.Location = New System.Drawing.Point(3, 8)
        Me.gexDetalle.Name = "gexDetalle"
        Me.gexDetalle.Size = New System.Drawing.Size(172, 106)
        Me.gexDetalle.TabIndex = 0
        Me.gexDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.gexGeneral)
        Me.UiGroupBox1.Location = New System.Drawing.Point(3, 297)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(429, 120)
        Me.UiGroupBox1.TabIndex = 126
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gexGeneral
        '
        Me.gexGeneral.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.gexGeneral.DesignTimeLayout = GridEXLayout2
        Me.gexGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gexGeneral.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gexGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gexGeneral.GroupByBoxVisible = False
        Me.gexGeneral.Location = New System.Drawing.Point(3, 8)
        Me.gexGeneral.Name = "gexGeneral"
        Me.gexGeneral.Size = New System.Drawing.Size(423, 109)
        Me.gexGeneral.TabIndex = 0
        Me.gexGeneral.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(440, 423)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(176, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(38, 432)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 23)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "Grabar"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(14, 432)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 23)
        Me.Label13.TabIndex = 123
        Me.Label13.Text = "F2"
        '
        'ebResponsable
        '
        Me.ebResponsable.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsable.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsable.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebResponsable.Location = New System.Drawing.Point(116, 95)
        Me.ebResponsable.Name = "ebResponsable"
        Me.ebResponsable.ReadOnly = True
        Me.ebResponsable.Size = New System.Drawing.Size(224, 22)
        Me.ebResponsable.TabIndex = 1
        Me.ebResponsable.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(272, 423)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(160, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'CalendarCombo1
        '
        Me.CalendarCombo1.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2010
        Me.CalendarCombo1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo1.Location = New System.Drawing.Point(518, 38)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.ReadOnly = True
        Me.CalendarCombo1.ShowDropDown = False
        Me.CalendarCombo1.Size = New System.Drawing.Size(96, 22)
        Me.CalendarCombo1.TabIndex = 12
        Me.CalendarCombo1.Value = New Date(2005, 8, 22, 0, 0, 0, 0)
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2010
        '
        'nbTotalArticulos
        '
        Me.nbTotalArticulos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalArticulos.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbTotalArticulos.ForeColor = System.Drawing.SystemColors.InfoText
        Me.nbTotalArticulos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nbTotalArticulos.Location = New System.Drawing.Point(116, 153)
        Me.nbTotalArticulos.Name = "nbTotalArticulos"
        Me.nbTotalArticulos.ReadOnly = True
        Me.nbTotalArticulos.Size = New System.Drawing.Size(96, 22)
        Me.nbTotalArticulos.TabIndex = 3
        Me.nbTotalArticulos.Text = "0"
        Me.nbTotalArticulos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalArticulos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigo
        '
        Me.ebCodigo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigo.ButtonImage = CType(resources.GetObject("ebCodigo.ButtonImage"), System.Drawing.Image)
        Me.ebCodigo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodigo.Location = New System.Drawing.Point(116, 124)
        Me.ebCodigo.Name = "ebCodigo"
        Me.ebCodigo.Size = New System.Drawing.Size(224, 22)
        Me.ebCodigo.TabIndex = 2
        Me.ebCodigo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nebFolio
        '
        Me.nebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolio.BackColor = System.Drawing.Color.White
        Me.nebFolio.ButtonImage = CType(resources.GetObject("nebFolio.ButtonImage"), System.Drawing.Image)
        Me.nebFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nebFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nebFolio.Location = New System.Drawing.Point(116, 66)
        Me.nebFolio.Name = "nebFolio"
        Me.nebFolio.Size = New System.Drawing.Size(96, 22)
        Me.nebFolio.TabIndex = 0
        Me.nebFolio.Text = "0"
        Me.nebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(462, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Fecha:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Total Artículos:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(438, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Tabla de Detalle:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tabla General:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Responsable:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código de Art.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No. de Folio:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuGuardar, Me.menuAbrir, Me.menuSalir, Me.mnuAyuda, Me.menuOAyuda, Me.menuNuevo, Me.menuImprimir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("99e51086-04f8-4a49-b4ba-31546c2ccefa")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
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
        Me.UiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.mnuAyuda1})
        Me.UiCommandBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(634, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'mnuAyuda1
        '
        Me.mnuAyuda1.Key = "mnuAyuda"
        Me.mnuAyuda1.Name = "mnuAyuda1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator3, Me.menuAbrir2, Me.Separator4, Me.menuGuardar2, Me.Separator5, Me.menuOAyuda2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(277, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuGuardar2
        '
        Me.menuGuardar2.Key = "menuGuardar"
        Me.menuGuardar2.Name = "menuGuardar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuOAyuda2
        '
        Me.menuOAyuda2.Key = "menuOAyuda"
        Me.menuOAyuda2.Name = "menuOAyuda2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo2, Me.Separator1, Me.menuAbrir1, Me.Separator6, Me.menuGuardar1, Me.Separator2, Me.menuSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuNuevo2
        '
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuGuardar1
        '
        Me.menuGuardar1.Key = "menuGuardar"
        Me.menuGuardar1.Name = "menuGuardar1"
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
        'menuGuardar
        '
        Me.menuGuardar.Image = CType(resources.GetObject("menuGuardar.Image"), System.Drawing.Image)
        Me.menuGuardar.Key = "menuGuardar"
        Me.menuGuardar.Name = "menuGuardar"
        Me.menuGuardar.Text = "&Guardar"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'menuSalir
        '
        Me.menuSalir.Image = CType(resources.GetObject("menuSalir.Image"), System.Drawing.Image)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "&Salir"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuOAyuda1})
        Me.mnuAyuda.Key = "mnuAyuda"
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Text = "A&yuda"
        '
        'menuOAyuda1
        '
        Me.menuOAyuda1.Key = "menuOAyuda"
        Me.menuOAyuda1.Name = "menuOAyuda1"
        '
        'menuOAyuda
        '
        Me.menuOAyuda.Image = CType(resources.GetObject("menuOAyuda.Image"), System.Drawing.Image)
        Me.menuOAyuda.Key = "menuOAyuda"
        Me.menuOAyuda.Name = "menuOAyuda"
        Me.menuOAyuda.Text = "Ay&uda"
        '
        'menuNuevo
        '
        Me.menuNuevo.Image = CType(resources.GetObject("menuNuevo.Image"), System.Drawing.Image)
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "&Nuevo"
        '
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "&Imprimir"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(634, 50)
        '
        'frmDesmarcarDefectuosos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(634, 515)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDesmarcarDefectuosos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desmarcar Articulos Defectuosos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.NicePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.gexDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.gexGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
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


#Region "Environment Var"

    'Objeto Defectuoso
    Dim oDefectuosoMgr As DefectuososManager
    Dim oDefectuoso As Defectuoso

    Dim banderaEliminado As Boolean = False
    Dim bolGuardar As Boolean = True
    'Objeto Artículo
    Dim oArticuloMgr As CatalogoArticuloManager


    Dim oArticulo As Articulo

    Dim dtDetalleFactura As DataTable
    'Dim dtTallas As DataTable = New DataTable("Tallas")

    Dim vCorrida As String, vExistencia As Decimal
    Dim vFacturaID As Integer

    Dim dsDefectuosos As DataSet

    'Data User Login
    Dim UserSession As String = String.Empty
    Dim UserName As String = String.Empty

#End Region

    Public Sub CreateTablesGeneralAndDetail()

        dsDefectuosos = New DataSet("Defectuosos")
        '''Creamos la Esructura de la Tabla General
        Dim dtDefectuososG As New DataTable("DefectuososG")

        Dim dcCodigoG As New DataColumn
        With dcCodigoG
            .ColumnName = "CodArticulo"
            .Caption = "Código"
            .DataType = GetType(System.String)
            .MaxLength = 20
            .DefaultValue = String.Empty
        End With

        Dim dcCantidadG As New DataColumn
        With dcCantidadG
            .ColumnName = "Cantidad"
            .Caption = "Cantidad"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcDescripcionG As New DataColumn
        With dcDescripcionG
            .ColumnName = "Descripcion"
            .Caption = "Descripcion"
            .DataType = GetType(System.String)
            .MaxLength = 50
            .DefaultValue = String.Empty
        End With

        Dim dcCorridaIG As New DataColumn
        With dcCorridaIG
            .ColumnName = "NumInicio"
            .Caption = "Corrida Inicio"
            .DataType = GetType(System.String)
            .DefaultValue = "U"
        End With

        Dim dcCorridaFG As New DataColumn
        With dcCorridaFG
            .ColumnName = "NumFin"
            .Caption = "Corrida Fin"
            .DataType = GetType(System.String)
            .DefaultValue = "XXL"
        End With

        Dim dcImage As New DataColumn
        With dcImage
            .ColumnName = "Imagen"
            .Caption = "Foto"
            .DataType = GetType(SqlTypes.SqlBinary)
        End With

        With dtDefectuososG.Columns
            .Add(dcCodigoG)
            .Add(dcCantidadG)
            .Add(dcDescripcionG)
            .Add(dcCorridaIG)
            .Add(dcCorridaFG)
            .Add(dcImage)
        End With

        dsDefectuosos.Tables.Add(dtDefectuososG)
        dsDefectuosos.AcceptChanges()

        '''Fin de la Creación de la Esructura de la Tabla General


        '''Creamos la Esructura de la Tabla Detalle
        Dim dtDefectuososD As New DataTable("DefectuososD")

        Dim dcCodigoD As New DataColumn
        With dcCodigoD
            .ColumnName = "CodArticulo"
            .Caption = "Código"
            .DataType = GetType(System.String)
            .MaxLength = 20
            .DefaultValue = String.Empty
        End With

        'Dim dcNumeroD As New DataColumn
        'With dcNumeroD
        '    .ColumnName = "Numero"
        '    .Caption = "Talla"
        '    .DataType = GetType(System.String)
        '    .DefaultValue = 0
        'End With

        Dim dcCantidadD As New DataColumn
        With dcCantidadD
            .ColumnName = "Defectuosos"
            .Caption = "Defectuosos"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcDesmarcarD As New DataColumn
        With dcDesmarcarD
            .ColumnName = "Desmarcar"
            .Caption = "Desmarcar"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcPrecioUniD As New DataColumn
        With dcPrecioUniD
            .ColumnName = "PrecioUni"
            .Caption = "Precio Unitario"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
            .Expression = "Desmarcar * PrecioUni"
        End With


        With dtDefectuososD.Columns
            .Add(dcCodigoD)
            '.Add(dcNumeroD)
            .Add(dcCantidadD)
            .Add(dcDesmarcarD)
            .Add(dcPrecioUniD)
            .Add(dcTotal)
        End With

        dsDefectuosos.Tables.Add(dtDefectuososD)
        dsDefectuosos.AcceptChanges()

        '''Fin de la Creación de la Esructura de la Tabla Detalle

        Dim dr As DataRelation
        Dim parentCol As DataColumn
        Dim childCol As DataColumn

        parentCol = dsDefectuosos.Tables("DefectuososG").Columns("CodArticulo")
        childCol = dsDefectuosos.Tables("DefectuososD").Columns("CodArticulo")

        'dr = New DataRelation("DefectuososTallas", parentCol, childCol)
        'dsDefectuosos.Relations.Add(dr)
        'Me.dsDefectuosos.AcceptChanges()

        Dim fk As ForeignKeyConstraint

        fk = New ForeignKeyConstraint("DefectuososFK", _
        Me.dsDefectuosos.Tables("DefectuososG").Columns("CodArticulo"), _
        Me.dsDefectuosos.Tables("DefectuososD").Columns("CodArticulo"))

        fk.DeleteRule = Rule.Cascade
        fk.UpdateRule = Rule.Cascade
        fk.AcceptRejectRule = AcceptRejectRule.Cascade

        ' Me.dsDefectuosos.Tables("DefectuososD").Constraints.Remove("DefectuososTallas")

        Me.dsDefectuosos.Tables("DefectuososD").Constraints.Add(fk)

        Me.dsDefectuosos.EnforceConstraints = True
        Me.dsDefectuosos.AcceptChanges()

    End Sub

    Private Sub sm_Clear()
        Me.ebCodigo.Text = String.Empty
        Me.nbTotalArticulos.Value = 0
        Me.dsDefectuosos.Clear()
        Me.nebFolio.Value = oDefectuosoMgr.SelectFolioDesmarcado + 1
        Me.pbImagen.Image = Nothing
        Me.gexGeneral.AllowDelete = InheritableBoolean.True
        Me.gexDetalle.AllowEdit = InheritableBoolean.True
        Me.ebCodigo.Focus()
        Me.UiCommandManager1.Commands.Item("MenuGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.True
        Me.btnGuardar.Enabled = True
        Me.ebCodigo.Enabled = True
        Me.bolGuardar = True
        Me.ebCodigo.Focus()

    End Sub

    Private Sub ObtenerImagen(ByVal urlImage As String)
        Dim strUrlImage As String = String.Empty

        '-----------------------------------------------------
        Try
            '------------------------------------------------------------------------------------------
            ' Si el nombre de la imagen lleva el texto
            ' [file:///]  QUITARLO porque genera errores 
            If urlImage.IndexOf("file:///", 0) = 0 Then
                urlImage = urlImage.Substring(8)
            End If
            '--------------------------------------------------------

            strUrlImage = urlImage
            pbImagen.ImageLocation = strUrlImage
            ' carga la imagen de forma síncrona
            pbImagen.Load()

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al tratar de cargar la imagen: " & strUrlImage)
            'Throw ex            
        End Try
    End Sub


    Private Sub LoadSearchFormDefectuso(Optional ByVal OnlyEnabledRecord As Boolean = False)

        If OnlyEnabledRecord Or ebCodigo.Text = String.Empty Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New DefectuososByCodArticuloOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
                Me.ebCodigo.Text = CStr(oOpenRecordDlg.Record.Item("CodArticulo")).Trim


                Dim custDV As DataView = New DataView(dsDefectuosos.Tables("DefectuososD"), _
                                                      "CodArticulo like '" & Me.ebCodigo.Text.Trim & "'", _
                                                      "", _
                                                      DataViewRowState.CurrentRows)

                If custDV.Count > 0 Then
                    MessageBox.Show("El código del artículo ya fue seleccionado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim drDefectuosoG As DataRow
                drDefectuosoG = oDefectuosoMgr.GetDataGeneral(ebCodigo.Text.Trim)
                'If Trim(drDefectuosoG(3)) = "0" Then drDefectuosoG(3) = "U"
                'If Trim(drDefectuosoG(4)) = "0" Then drDefectuosoG(4) = "XXL"
                'drDefectuosoG.AcceptChanges()

                If Not drDefectuosoG Is Nothing Then

                    dsDefectuosos.Tables("DefectuososG").ImportRow(drDefectuosoG)

                    For Each row As DataRow In oDefectuosoMgr.GetDataDetail(ebCodigo.Text.Trim)
                        dsDefectuosos.Tables("DefectuososD").ImportRow(row)
                    Next

                Else

                    MessageBox.Show("El artículo no cuenta con defectuosos", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                'Me.gexGeneral.SetDataBinding(dsDefectuosos, "DefectuososG")


            End If

            Else


            Dim custDV As DataView = New DataView(dsDefectuosos.Tables("DefectuososD"), _
                                                     "CodArticulo like '" & Me.ebCodigo.Text.Trim & "'", _
                                                     "", _
                                                     DataViewRowState.CurrentRows)

            If custDV.Count > 0 Then
                MessageBox.Show("El código del artículo ya fue seleccionado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim drDefectuosoG As DataRow
            drDefectuosoG = oDefectuosoMgr.GetDataGeneral(ebCodigo.Text.Trim)
            

            If Not drDefectuosoG Is Nothing Then
                'If Trim(drDefectuosoG(3)) = "0" Then drDefectuosoG(3) = "U"
                'If Trim(drDefectuosoG(4)) = "0" Then drDefectuosoG(4) = "XXL"
                'drDefectuosoG.AcceptChanges()

                dsDefectuosos.Tables("DefectuososG").ImportRow(drDefectuosoG)

                For Each row As DataRow In oDefectuosoMgr.GetDataDetail(ebCodigo.Text.Trim)
                    dsDefectuosos.Tables("DefectuososD").ImportRow(row)
                Next

            Else

                MessageBox.Show("El artículo no cuenta con defectuosos", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Me.dsDefectuosos.AcceptChanges()

        End If


        '------------------------------------------------------------------------------------------
        ' MLVARGAS (08.07.2022) Cargar la imagen
        '------------------------------------------------------------------------------------------
        Dim codColor As String = ""
        codColor = oArticuloMgr.SelectCodColor(ebCodigo.Text.Trim)
        If codColor <> "NA" Then
            'Buscar la imagen del producto
            Dim generico As String = ebCodigo.Text.Substring(8, 7)
            Dim strPath As String = oConfigCierreFI.ImagenesExistencia & generico & "-" & codColor & ".jpg"
            ObtenerImagen(strPath)
        Else
            pbImagen.Image = Nothing
        End If


        'If File.Exists(Application.StartupPath & "\Fotos\" & ebCodigo.Text.Trim & ".JPG") Then
        '    pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & ebCodigo.Text.Trim & ".JPG")
        'Else
        '    pbImagen.Image = Nothing
        'End If

    End Sub

    Private Sub ebCodigo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodigo.ButtonClick

        LoadSearchFormDefectuso(True)

    End Sub

    Private Sub ebCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigo.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchFormDefectuso(True)

        ElseIf e.KeyCode = Keys.Enter Then

            LoadSearchFormDefectuso()

        End If

    End Sub

    Private Sub frmDesmarcarDefectuosos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oAppContext.Security.CloseImpersonatedSession()

        oDefectuosoMgr = New DefectuososManager(oAppContext, oAppSAPConfig)

        CreateTablesGeneralAndDetail()

        Me.gexGeneral.SetDataBinding(dsDefectuosos, "DefectuososG")

        Me.ebResponsable.Text = UserName.ToUpper

        sm_Clear()

        Me.ebCodigo.Focus()

        NicePanel2.FooterText = "Grupo Dportenis @  " & CStr(Date.Now.Year) '2005

        oArticuloMgr = New CatalogoArticuloManager(oAppContext)

    End Sub

    Private Sub gexGeneral_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gexGeneral.CurrentCellChanged
        Try
            If dsDefectuosos.Tables("DefectuososG").Rows.Count > 0 Then

                'Dim parentTableView As New DataView(dsDefectuosos.Tables("DefectuososG"))
                'Dim currentRowView As DataRowView = parentTableView(Me.gexGeneral.Row)
                'Me.gexDetalle.DataSource = currentRowView.CreateChildView("DefectuososTallas")


                Dim oCurrentRow As GridEXRow
                Dim odrDataRow As DataRowView
                oCurrentRow = Me.gexGeneral.GetRow()
                odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

                If IsDBNull(odrDataRow("Imagen")) Then
                    Dim oFotoArticulo() As Byte = CType(odrDataRow("Imagen"), Byte())
                    Dim msFotoArticulo As New MemoryStream(oFotoArticulo)
                    Me.pbImagen.Image = Image.FromStream(msFotoArticulo)
                Else
                    Me.pbImagen.Image = Nothing
                End If


                Dim custDV As DataView = New DataView(dsDefectuosos.Tables("DefectuososD"), _
                                                      "CodArticulo like '" & odrDataRow("CodArticulo") & "'", _
                                                      "", _
                                                      DataViewRowState.CurrentRows)

                Me.gexDetalle.DataSource = custDV
                Me.gexDetalle.DataMember = "DefectuososD"


            End If
        Catch ex As Exception



        End Try
    End Sub

    Private Sub gexDetalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gexDetalle.CurrentCellChanged
        Dim oCurrentRow As GridEXRow
        Dim odrDataRow As DataRowView

        Try

            If gexDetalle.RowCount > 0 Then

                oCurrentRow = Me.gexDetalle.GetRow()
                odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

                If odrDataRow.Item("Desmarcar") > odrDataRow.Item("Defectuosos") Then

                    odrDataRow.Item("Desmarcar") = odrDataRow.Item("Defectuosos")

                ElseIf odrDataRow.Item("Desmarcar") < 1 Then

                    odrDataRow.Item("Desmarcar") = 0

                End If

                Dim i As Integer = 0

                Dim oCurrentRowG As GridEXRow
                Dim odrDataRowG As DataRowView
                oCurrentRowG = Me.gexGeneral.GetRow()
                odrDataRowG = CType(oCurrentRowG.DataRow, DataRowView)

                odrDataRowG.Item("Cantidad") = dsDefectuosos.Tables("DefectuososD").Compute("sum(Desmarcar)", "Desmarcar>=0 and CodArticulo like '" & odrDataRow("CodArticulo") & "'")
                Me.nbTotalArticulos.Value = dsDefectuosos.Tables("DefectuososG").Compute("sum(Cantidad)", "Cantidad>=0")
                Me.gexGeneral.Refresh()


            End If


        Catch ex As FormatException

            odrDataRow.Item("Desmarcar") = 0

        End Try


    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If nbTotalArticulos.Text <> "" Then
            If Integer.Parse(nbTotalArticulos.Text) > 0 Then
                Sm_Guardar()
            Else
                If ebCodigo.Text = String.Empty Then
                    MessageBox.Show("Debes seleccionar un artículo.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Debes seleccionar la cantidad a desmarcar.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Else
            MessageBox.Show("Debes seleccionar la cantidad a desmarcar.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        
    End Sub

    Private Sub Sm_Guardar()

        If nbTotalArticulos.Text <> "" Then
            If Integer.Parse(nbTotalArticulos.Text) > 0 Then

                Try
                    ' Actualizar campos statusregistro y fecha_desm de la tabla de Defectuosos
                    oDefectuosoMgr.ActualizarDesmarcado(dsDefectuosos)

                    Me.nebFolio.Value = oDefectuosoMgr.DesmarcarDefectuosos(dsDefectuosos, Me.nbTotalArticulos.Value, UserSession, True, "0004")

                    MessageBox.Show("El Desmarcado se realizó correctamente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.dsDefectuosos.Clear()

                    Me.sm_Clear()

                Catch ex As Exception

                    MsgBox(ex.ToString)

                End Try
            Else
                If ebCodigo.Text = String.Empty Then
                    MessageBox.Show("Debes seleccionar un artículo.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Debes seleccionar la cantidad a desmarcar.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            MessageBox.Show("Debes seleccionar la cantidad a desmarcar.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Public Sub LoadSearchFormDesmarcados(Optional ByVal OnlyEnabledRecord As Boolean = False)

        If ((OnlyEnabledRecord = True) Or (Me.nebFolio.Value = 0)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New DefectuososGOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Me.nebFolio.Value = oOpenRecordDlg.Record.Item("Folio")

                sm_LoadData()


            End If

        Else

            sm_LoadData()


        End If


    End Sub

    Private Sub sm_LoadData()

        Dim drCollectionG As DataRowCollection
        Dim drCollectionD As DataRowCollection

        drCollectionG = oDefectuosoMgr.SelectAllDesmarcadosG(CInt(Me.nebFolio.Value))

        Me.dsDefectuosos.Clear()

        If drCollectionG Is Nothing Then

            ebCodigo.Focus()

            Exit Sub

        End If

        If (drCollectionG.Count > 0) Then

            For Each row As DataRow In drCollectionG

                Dim custDV As DataView = New DataView(dsDefectuosos.Tables("DefectuososG"), _
                                                 "CodArticulo like '" & row("CodArticulo") & "'", _
                                                 "CodArticulo", _
                                                 DataViewRowState.CurrentRows)
                '''''''''''''''''''''''''''''''''

                If custDV.Count = 0 Then
                    Me.dsDefectuosos.Tables("DefectuososG").ImportRow(row)
                End If

            Next

            drCollectionD = oDefectuosoMgr.SelectAllDesmarcadosD(CInt(Me.nebFolio.Value))

            If (drCollectionD.Count > 0) Then

                For Each row As DataRow In drCollectionD

                    Me.dsDefectuosos.Tables("DefectuososD").ImportRow(row)

                Next

                Me.gexGeneral.SetDataBinding(dsDefectuosos, "DefectuososG")

                Me.gexGeneral.AllowDelete = InheritableBoolean.False
                Me.gexDetalle.AllowEdit = InheritableBoolean.False
                Me.UiCommandManager1.Commands.Item("MenuGuardar").Enabled = Janus.Windows.UI.InheritableBoolean.False
                Me.btnGuardar.Enabled = False
                Me.ebCodigo.Enabled = False

            End If

            Me.bolGuardar = False

        Else
            MsgBox("El Folio no existe.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Defectuosos")

            'Limpio la pantalla
            Me.sm_Clear()


        End If
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "menuSalir"

                Me.Close()

            Case "menuNuevo"

                Me.sm_Clear()

            Case "menuGuardar"

                Sm_Guardar()

            Case "menuAbrir"

                Me.LoadSearchFormDesmarcados(True)

            Case "menuImprimir"

                'PrintComprobanteComparativo()

            Case "menuAyudaTema"

                'TODO : Implementar Aqui la Ayuda

            Case Else

        End Select
    End Sub

    Private Sub nebFolio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nebFolio.ButtonClick
        Me.LoadSearchFormDesmarcados(True)
    End Sub

    Private Sub nebFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebFolio.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Me.LoadSearchFormDesmarcados(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Me.LoadSearchFormDesmarcados()

        End If

    End Sub

    Private Sub frmDesmarcarDefectuosos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F2 Then

            If Me.bolGuardar = True Then
                Sm_Guardar()

            Else

                MessageBox.Show("No se puede guardar la información en este momento", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Public Sub ShowMe(ByVal strUserSession As String, ByVal strUserName As String)

        UserSession = strUserSession
        UserName = strUserName

        Me.Show()

    End Sub



End Class
