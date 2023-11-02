Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports System.IO
Imports System.Drawing.Printing
Imports DirPrint
Imports Utilerias
Imports PrinterNET

Public Class FrmDescNuevosPrintEtiquetas
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
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents LblCodArticulo As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblPrecioDescuento As System.Windows.Forms.Label
    Friend WithEvents LblPrecioIva As System.Windows.Forms.Label
    Friend WithEvents LblDescuento As System.Windows.Forms.Label
    Friend WithEvents CmdExportar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdExportar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdExportar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdExportar3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents CmdSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdReporte As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents CmdImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CmdReporte1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescNuevosPrintEtiquetas))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdProductos = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.LblDescuento = New System.Windows.Forms.Label()
        Me.NicePanel2 = New PureComponents.NicePanel.NicePanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.LblPrecioDescuento = New System.Windows.Forms.Label()
        Me.LblPrecioIva = New System.Windows.Forms.Label()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.LblCodArticulo = New System.Windows.Forms.Label()
        Me.CmdExportar1 = New Janus.Windows.UI.CommandBars.UICommand("CmdExportar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.CmdExportar = New Janus.Windows.UI.CommandBars.UICommand("CmdExportar")
        Me.CmdExportar2 = New Janus.Windows.UI.CommandBars.UICommand("CmdExportar")
        Me.CmdImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("CmdImprimir")
        Me.CmdSalir2 = New Janus.Windows.UI.CommandBars.UICommand("CmdSalir")
        Me.CmdExportar3 = New Janus.Windows.UI.CommandBars.UICommand("CmdExportar")
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.CmdImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("CmdImprimir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.CmdReporte1 = New Janus.Windows.UI.CommandBars.UICommand("CmdReporte")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.CmdSalir = New Janus.Windows.UI.CommandBars.UICommand("CmdSalir")
        Me.CmdImprimir = New Janus.Windows.UI.CommandBars.UICommand("CmdImprimir")
        Me.CmdReporte = New Janus.Windows.UI.CommandBars.UICommand("CmdReporte")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.NicePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.grdProductos)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Lista Articulos Con Descuento"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 24)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(672, 248)
        Me.ExplorerBar1.TabIndex = 82
        Me.ExplorerBar1.Text = "0"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdProductos
        '
        Me.grdProductos.AllowColumnDrag = False
        Me.grdProductos.AlternatingColors = True
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdProductos.DesignTimeLayout = GridEXLayout1
        Me.grdProductos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdProductos.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.grdProductos.ExpandableCards = False
        Me.grdProductos.Font = New System.Drawing.Font("Arial Narrow", 8.25!)
        Me.grdProductos.GroupByBoxVisible = False
        Me.grdProductos.HeaderFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdProductos.HeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.ControlLight
        Me.grdProductos.HeaderFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical
        Me.grdProductos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grdProductos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdProductos.Location = New System.Drawing.Point(8, 48)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grdProductos.Size = New System.Drawing.Size(656, 184)
        Me.grdProductos.TabIndex = 0
        Me.grdProductos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.grdProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.LblDescuento)
        Me.ExplorerBar2.Controls.Add(Me.NicePanel2)
        Me.ExplorerBar2.Controls.Add(Me.btnImprimir)
        Me.ExplorerBar2.Controls.Add(Me.LblPrecioDescuento)
        Me.ExplorerBar2.Controls.Add(Me.LblPrecioIva)
        Me.ExplorerBar2.Controls.Add(Me.LblDescripcion)
        Me.ExplorerBar2.Controls.Add(Me.LblCodArticulo)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Articulos"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 280)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(672, 232)
        Me.ExplorerBar2.TabIndex = 84
        Me.ExplorerBar2.Text = "0"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'LblDescuento
        '
        Me.LblDescuento.AutoSize = True
        Me.LblDescuento.BackColor = System.Drawing.Color.Transparent
        Me.LblDescuento.Location = New System.Drawing.Point(264, 144)
        Me.LblDescuento.Name = "LblDescuento"
        Me.LblDescuento.Size = New System.Drawing.Size(62, 16)
        Me.LblDescuento.TabIndex = 130
        Me.LblDescuento.Text = "Descto.:"
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
        Me.NicePanel2.FooterText = "Grupo DPortenis @ " & CStr(Date.Now.Year) '20052005"
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Foto del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(8, 32)
        Me.NicePanel2.Name = "NicePanel2"
        Me.NicePanel2.OriginalFooterVisible = True
        Me.NicePanel2.OriginalHeight = 0
        Me.NicePanel2.Size = New System.Drawing.Size(232, 176)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(252, Byte), Integer))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.NicePanel2.TabIndex = 129
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
        Me.Panel1.Size = New System.Drawing.Size(230, 134)
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
        Me.pbImagen.Size = New System.Drawing.Size(230, 134)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 129
        Me.pbImagen.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Icon = CType(resources.GetObject("btnImprimir.Icon"), System.Drawing.Icon)
        Me.btnImprimir.Location = New System.Drawing.Point(528, 176)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(88, 32)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'LblPrecioDescuento
        '
        Me.LblPrecioDescuento.AutoSize = True
        Me.LblPrecioDescuento.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecioDescuento.Location = New System.Drawing.Point(264, 118)
        Me.LblPrecioDescuento.Name = "LblPrecioDescuento"
        Me.LblPrecioDescuento.Size = New System.Drawing.Size(110, 16)
        Me.LblPrecioDescuento.TabIndex = 86
        Me.LblPrecioDescuento.Text = "Precio Descto.: "
        '
        'LblPrecioIva
        '
        Me.LblPrecioIva.AutoSize = True
        Me.LblPrecioIva.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecioIva.Location = New System.Drawing.Point(264, 92)
        Me.LblPrecioIva.Name = "LblPrecioIva"
        Me.LblPrecioIva.Size = New System.Drawing.Size(81, 16)
        Me.LblPrecioIva.TabIndex = 85
        Me.LblPrecioIva.Text = "Precio IVA:"
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.LblDescripcion.Location = New System.Drawing.Point(264, 66)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(91, 16)
        Me.LblDescripcion.TabIndex = 84
        Me.LblDescripcion.Text = "Descripcion: "
        '
        'LblCodArticulo
        '
        Me.LblCodArticulo.AutoSize = True
        Me.LblCodArticulo.BackColor = System.Drawing.Color.Transparent
        Me.LblCodArticulo.Location = New System.Drawing.Point(264, 40)
        Me.LblCodArticulo.Name = "LblCodArticulo"
        Me.LblCodArticulo.Size = New System.Drawing.Size(60, 16)
        Me.LblCodArticulo.TabIndex = 83
        Me.LblCodArticulo.Text = "Codigo: "
        '
        'CmdExportar1
        '
        Me.CmdExportar1.Key = "CmdExportar"
        Me.CmdExportar1.Name = "CmdExportar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'CmdExportar
        '
        Me.CmdExportar.Image = CType(resources.GetObject("CmdExportar.Image"), System.Drawing.Image)
        Me.CmdExportar.Key = "CmdExportar"
        Me.CmdExportar.Name = "CmdExportar"
        Me.CmdExportar.Text = "Reporte"
        '
        'CmdExportar2
        '
        Me.CmdExportar2.Key = "CmdExportar"
        Me.CmdExportar2.Name = "CmdExportar2"
        '
        'CmdImprimir2
        '
        Me.CmdImprimir2.Key = "CmdImprimir"
        Me.CmdImprimir2.Name = "CmdImprimir2"
        '
        'CmdSalir2
        '
        Me.CmdSalir2.Key = "CmdSalir"
        Me.CmdSalir2.Name = "CmdSalir2"
        '
        'CmdExportar3
        '
        Me.CmdExportar3.Key = "CmdExportar"
        Me.CmdExportar3.Name = "CmdExportar3"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.CmdSalir, Me.CmdImprimir, Me.CmdReporte})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("66834d30-88f4-4550-a010-0377b6131d1b")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.CmdImprimir1, Me.Separator5, Me.CmdReporte1, Me.Separator4})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(155, 28)
        Me.UiCommandBar1.Text = "ToolBar"
        Me.UiCommandBar1.View = Janus.Windows.UI.CommandBars.View.SmallIcons
        '
        'CmdImprimir1
        '
        Me.CmdImprimir1.Description = "Imprimir Etiquetas"
        Me.CmdImprimir1.Key = "CmdImprimir"
        Me.CmdImprimir1.Name = "CmdImprimir1"
        Me.CmdImprimir1.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'CmdReporte1
        '
        Me.CmdReporte1.Description = "Mostrar Reporte"
        Me.CmdReporte1.Key = "CmdReporte"
        Me.CmdReporte1.Name = "CmdReporte1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = CType(resources.GetObject("CmdSalir.Image"), System.Drawing.Image)
        Me.CmdSalir.Key = "CmdSalir"
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Text = "Salir"
        '
        'CmdImprimir
        '
        Me.CmdImprimir.Image = CType(resources.GetObject("CmdImprimir.Image"), System.Drawing.Image)
        Me.CmdImprimir.Key = "CmdImprimir"
        Me.CmdImprimir.Name = "CmdImprimir"
        Me.CmdImprimir.Text = "Imprimir"
        '
        'CmdReporte
        '
        Me.CmdReporte.Image = CType(resources.GetObject("CmdReporte.Image"), System.Drawing.Image)
        Me.CmdReporte.Key = "CmdReporte"
        Me.CmdReporte.Name = "CmdReporte"
        Me.CmdReporte.Text = "Reporte"
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
        Me.TopRebar1.Size = New System.Drawing.Size(664, 28)
        '
        'FrmDescNuevosPrintEtiquetas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(680, 528)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(680, 528)
        Me.Name = "FrmDescNuevosPrintEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos con Descuento - Impresión de Etiquetas"
        Me.TopMost = True
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ExplorerBar2.PerformLayout()
        Me.NicePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private oInicioDiaMgr As InicioDiaManager
    Dim dt As New DataTable
    Dim bolimprimir As Boolean = False
    Dim posicion As Integer
    Dim precio As Double
    Dim precioOferta As Double
    Dim codArticulo As String
    Dim corridaFinal As String
    Dim contador As Integer
    Dim paginasTotales As Integer
    Dim c, a As Integer
    Dim pd As New PrintDocument
    Dim dtAux As DataTable


    Public Sub CargaEtiquetas()
        oInicioDiaMgr = New InicioDiaManager(oAppContext)
        '**********************Reporte de Descuentos **********************
        'True para que no me muestre los articulos ACC, AC1, TEXT
        dt = oInicioDiaMgr.ObetenerPreciosyDescuentos(False, 0, 100, True).Tables(0) 'False No lo quiero agrupado

        If dt.Rows.Count > 0 Then

            'Columna: Cantidad Etiquetas a Imprimir
            Dim dcCantidadSAP As DataColumn
            dcCantidadSAP = New DataColumn
            With dcCantidadSAP
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Etiquetas"
                .ColumnName = "Etiquetas"
                .DefaultValue = 0
            End With
            dt.Columns.Add(dcCantidadSAP)

            Me.grdProductos.DataSource = dt

            AddHandler dt.ColumnChanging, New DataColumnChangeEventHandler(AddressOf Column_Changing)

            '**********************Reporte de Descuentos **********************
        Else
            bolimprimir = True
            Me.Close()
        End If
    End Sub


    Private Sub Column_Changing(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
        Try
            Select Case UCase(e.Column.ColumnName)
                Case UCase("Etiquetas")
                    If IsDBNull(e.ProposedValue) Then
                        MessageBox.Show("Capture # Etiquetas valido", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.ProposedValue = 0
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show("Error :" & ex.ToString)
        End Try
    End Sub

    Private Sub grdProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.Click
        If File.Exists(Application.StartupPath & "\Fotos\" & Me.grdProductos.GetValue("Codigo") & ".JPG") Then
            Me.pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & Me.grdProductos.GetValue("Codigo") & ".JPG")
        Else
            Me.pbImagen.Image = Nothing
        End If
        LblCodArticulo.Text = "Codigo: " & Me.grdProductos.GetValue("Codigo")
        LblDescripcion.Text = "Descripcion: " & Me.grdProductos.GetValue("Descripcion")
        Me.LblDescuento.Text = "Descto.: " & Me.grdProductos.GetValue("Descuento") & "%"
        Me.LblPrecioIva.Text = "Precio IVA: " & Format(Me.grdProductos.GetValue("PrecioIva"), "C")
        Me.LblPrecioDescuento.Text = "Precio Descto.: " & Format(Me.grdProductos.GetValue("PrecioDescuento"), "C")

    End Sub
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim printFont As New System.Drawing.Font("Roman", 12, System.Drawing.FontStyle.Regular)
        Dim x As Integer = 100
        Dim y, pagina As Integer
        y = posicion
        contador = 0
        ' Draw a picture.
        'ev.Graphics.DrawImage(Image.FromFile("C:\Win_Vista_Button.jpg"), ev.Graphics.VisibleClipBounds)


        For i As Integer = c To dtAux.Rows.Count
            ev.Graphics.DrawString("$" & Format(CType(dtAux.Rows(i - 1).Item("precioiva"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y)
            ev.Graphics.DrawString("$" & Format(CType(dtAux.Rows(i - 1).Item("preciodescuento"), String), "Standard"), printFont, SystemBrushes.ControlText, x + 50, y + 110)
            ev.Graphics.DrawString(CType(dtAux.Rows(i - 1).Item("codArticulo"), String), printFont, SystemBrushes.ControlText, x, y + 190)

            posicion = posicion + 275

            contador = contador + 1
            a += 1
            If contador = 4 Then
                pagina += 1
                If pagina <= paginasTotales Then
                    c = i + 1
                    posicion = 0
                    ev.HasMorePages = True
                    Exit For
                Else
                    ev.HasMorePages = False
                End If
            End If
            'If a = dt.Rows.Count Then
            '    ev.HasMorePages = False
            'End If
            y = posicion
        Next

        ' Indicate that this is the last page to print.
        'ev.HasMorePages = True


    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ' Declare an object variable.

        If dt.Rows.Count <= 0 Or dt Is Nothing Then
            Exit Sub
        End If

        Dim objSum As Object
        objSum = dt.Compute("sum(etiquetas)", "")
        If CInt(objSum) > 0 Then

            Try
                posicion = 0
                contador = 0
                dtAux = New DataTable
                dtAux = dt.Clone

                For Each dr As DataRow In dt.Rows
                    For i As Integer = 1 To dr.Item("etiquetas")
                        dtAux.ImportRow(dr)
                    Next
                Next
                dtAux.AcceptChanges()

                paginasTotales = dtAux.Rows.Count / 4
                paginasTotales = paginasTotales + IIf(dtAux.Rows.Count Mod 4 > 0, 1, 0)
                c = 1
                a = 0

                ' Assumes the default printer.
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                pd.Print()
                bolimprimir = True
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("An error occurred while printing", _
                    ex.ToString())
            End Try



            'Dim dr As DataRow
            'Dim intPosEtq As Integer = 0
            'Dim i As Integer = 0
            'intPosEtq += 0

            'Dim oPrinterNET As New ClsPrinter

            'Dim strLine As String

            'Dim intIndexEtiqueta As Integer

            'With oPrinterNET

            '    .PORT = "LPT1"

            '    .OpenPORT()


            '    For Each dr In dt.Rows
            '        'Imprimir el numero de etiquetas predefinido
            '        For i = 1 To dr!etiquetas

            '            intPosEtq += 1

            '            strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
            '                       Format(CType(dr!PrecioIva, String), "Standard") + Chr(27) + Chr(18) + Chr(27) + Chr(20)
            '            .PrintPORT(strLine)

            '            If intPosEtq = 2 Then
            '                strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
            '                intPosEtq = 0
            '            Else
            '                strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
            '            End If

            '            .PrintPORT(strLine)

            '            strLine = Chr(27) + Chr(14) + Chr(27) + Chr(15) + Space(3) + "$" + _
            '                       Format(CType(dr!PrecioDescuento, String), "Standard") + Chr(27) + Chr(33) + Chr(0)
            '            .PrintPORT(strLine)

            '            strLine = vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf
            '            .PrintPORT(strLine)

            '            strLine = Space(3) + CType(dr!CodArticulo, String) + Chr(27) + Chr(33) + Chr(1)
            '            .PrintPORT(strLine)

            '            ' Alineamos impresora
            '            strLine = vbCrLf + vbCrLf + vbCrLf + vbCrLf + vbCrLf
            '            .PrintPORT(strLine)
            '        Next

            '    Next

            '    .ClosePORT()

            'End With
            'bolimprimir = True
            'Me.Close()
        Else
            MessageBox.Show("No se imprimirá ninguna Etiqueta", "No Se Seleccionaron", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub grdProductos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            If File.Exists(Application.StartupPath & "\Fotos\" & Me.grdProductos.GetValue("Codigo") & ".JPG") Then
                Me.pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & Me.grdProductos.GetValue("Codigo") & ".JPG")
            Else
                Me.pbImagen.Image = Nothing
            End If
            LblCodArticulo.Text = "Codigo: " & Me.grdProductos.GetValue("Codigo")
            LblDescripcion.Text = "Descripcion: " & Me.grdProductos.GetValue("Descripcion")
            Me.LblDescuento.Text = "Descto.: " & Me.grdProductos.GetValue("Descuento") & "%"
            Me.LblPrecioIva.Text = "Precio IVA: " & Format(Me.grdProductos.GetValue("PrecioIva"), "C")
            Me.LblPrecioDescuento.Text = "Precio Descto.: " & Format(Me.grdProductos.GetValue("PrecioDescuento"), "C")
        End If
    End Sub

    Private Sub exportar()
        '**********************Reporte de Descuentos **********************
        oInicioDiaMgr = New InicioDiaManager(oAppContext, oAppSAPConfig)

        Dim ds As DataSet

        ds = oInicioDiaMgr.ObetenerPreciosyDescuentos(False, 0, 100) ' no lo quiero agrupado

        If ds.Tables(0).Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor

            Dim oReportViewer As New ReportViewerForm

            Dim rptDesc As New rptDescuentosSAP(ds)

            rptDesc.Document.Name = "Reporte Descuentos - " & Format(Date.Now, "Short Date")

            oReportViewer.Report = rptDesc

            rptDesc.Run()

            Me.Cursor = Cursors.Default

            oReportViewer.Show()

        Else
            Exit Sub
        End If
        '**********************Reporte de Descuentos **********************
    End Sub

    Private Sub UiCommandBar1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandBar1.CommandClick

        Select Case UCase(e.Command.Key)
            Case "CMDSALIR"
                Me.Close()
            Case "CMDIMPRIMIR"
                Me.btnImprimir.PerformClick()
            Case "CMDREPORTE"
                exportar()
        End Select
    End Sub

    Private Sub FrmDescNuevosPrintEtiquetas_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bolimprimir Then
            e.Cancel = True
        End If
    End Sub
End Class
