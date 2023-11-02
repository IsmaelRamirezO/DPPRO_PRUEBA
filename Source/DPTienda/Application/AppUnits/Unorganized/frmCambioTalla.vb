Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DportenisPro.DPTienda.ApplicationUnits.CambioTallaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Public Class frmCambioTalla
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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ebFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebFechaFactura As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents NicePanel1 As PureComponents.NicePanel.NicePanel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ebCodigoAnt As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebCodigoNvo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebCantidadAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCantidadNvo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebTallaAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebTallaNvo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents uiGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioTalla))
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.ebTallaAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCantidadAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodigoAnt = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaFactura = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebTallaNvo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCantidadNvo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodigoNvo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uiGuardar = New Janus.Windows.EditControls.UIButton()
        Me.NicePanel1 = New PureComponents.NicePanel.NicePanel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        Me.NicePanel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoGuardar, Me.menuAyudaTema, Me.menuArchivoSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("322c7b30-8bee-4981-9fa3-c7f231e32121")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(672, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator2, Me.menuAyudaTema1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(216, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Image = CType(resources.GetObject("menuArchivoGuardar1.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator3, Me.menuArchivoGuardar2, Me.Separator4, Me.menuArchivoSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema2})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "&Ayuda"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "&Temas de Ayuda"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "&Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(672, 50)
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.ebCaja)
        Me.ExplorerBar1.Controls.Add(Me.ebTallaAnt)
        Me.ExplorerBar1.Controls.Add(Me.ebCantidadAnt)
        Me.ExplorerBar1.Controls.Add(Me.ebCodigoAnt)
        Me.ExplorerBar1.Controls.Add(Me.ebFactura)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaFactura)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Datos del Artículo a Cambiar"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(336, 976)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebCaja
        '
        Me.ebCaja.BorderStyle = Janus.Windows.UI.BorderStyle.Sunken
        Me.ebCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebCaja.Location = New System.Drawing.Point(96, 40)
        Me.ebCaja.Name = "ebCaja"
        Me.ebCaja.Size = New System.Drawing.Size(104, 23)
        Me.ebCaja.TabIndex = 0
        Me.ebCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebTallaAnt
        '
        Me.ebTallaAnt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaAnt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaAnt.BackColor = System.Drawing.Color.Ivory
        Me.ebTallaAnt.DecimalDigits = 1
        Me.ebTallaAnt.Location = New System.Drawing.Point(96, 122)
        Me.ebTallaAnt.Name = "ebTallaAnt"
        Me.ebTallaAnt.ReadOnly = True
        Me.ebTallaAnt.Size = New System.Drawing.Size(72, 23)
        Me.ebTallaAnt.TabIndex = 3
        Me.ebTallaAnt.TabStop = False
        Me.ebTallaAnt.Text = "0.0"
        Me.ebTallaAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTallaAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCantidadAnt
        '
        Me.ebCantidadAnt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidadAnt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidadAnt.Enabled = False
        Me.ebCantidadAnt.Location = New System.Drawing.Point(248, 122)
        Me.ebCantidadAnt.Name = "ebCantidadAnt"
        Me.ebCantidadAnt.Size = New System.Drawing.Size(72, 23)
        Me.ebCantidadAnt.TabIndex = 4
        Me.ebCantidadAnt.Text = "0"
        Me.ebCantidadAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCantidadAnt.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCantidadAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoAnt
        '
        Me.ebCodigoAnt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoAnt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.ebCodigoAnt.DesignTimeLayout = GridEXLayout2
        Me.ebCodigoAnt.Enabled = False
        Me.ebCodigoAnt.Location = New System.Drawing.Point(96, 94)
        Me.ebCodigoAnt.Name = "ebCodigoAnt"
        Me.ebCodigoAnt.Size = New System.Drawing.Size(224, 23)
        Me.ebCodigoAnt.TabIndex = 3
        Me.ebCodigoAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFactura
        '
        Me.ebFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFactura.ButtonImage = CType(resources.GetObject("ebFactura.ButtonImage"), System.Drawing.Image)
        Me.ebFactura.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebFactura.DecimalDigits = 0
        Me.ebFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFactura.Location = New System.Drawing.Point(96, 67)
        Me.ebFactura.MaxLength = 9
        Me.ebFactura.Name = "ebFactura"
        Me.ebFactura.Size = New System.Drawing.Size(104, 23)
        Me.ebFactura.TabIndex = 1
        Me.ebFactura.Text = "0"
        Me.ebFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFactura.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaFactura
        '
        '
        '
        '
        Me.ebFechaFactura.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaFactura.Enabled = False
        Me.ebFechaFactura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaFactura.Location = New System.Drawing.Point(208, 67)
        Me.ebFechaFactura.Name = "ebFechaFactura"
        Me.ebFechaFactura.ReadOnly = True
        Me.ebFechaFactura.Size = New System.Drawing.Size(112, 23)
        Me.ebFechaFactura.TabIndex = 2
        Me.ebFechaFactura.TabStop = False
        Me.ebFechaFactura.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(184, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cantidad:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Talla:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Factura:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Caja:"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebTallaNvo)
        Me.ExplorerBar2.Controls.Add(Me.ebCantidadNvo)
        Me.ExplorerBar2.Controls.Add(Me.ebCodigoNvo)
        Me.ExplorerBar2.Controls.Add(Me.Label3)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        Me.ExplorerBar2.Controls.Add(Me.Label8)
        Me.ExplorerBar2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos del Articulo Nuevo"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 216)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(336, 704)
        Me.ExplorerBar2.TabIndex = 2
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebTallaNvo
        '
        Me.ebTallaNvo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTallaNvo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTallaNvo.DecimalDigits = 1
        Me.ebTallaNvo.Enabled = False
        Me.ebTallaNvo.Location = New System.Drawing.Point(96, 68)
        Me.ebTallaNvo.Name = "ebTallaNvo"
        Me.ebTallaNvo.Size = New System.Drawing.Size(72, 23)
        Me.ebTallaNvo.TabIndex = 0
        Me.ebTallaNvo.Text = "0.0"
        Me.ebTallaNvo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTallaNvo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCantidadNvo
        '
        Me.ebCantidadNvo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCantidadNvo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCantidadNvo.BackColor = System.Drawing.Color.Ivory
        Me.ebCantidadNvo.Location = New System.Drawing.Point(248, 68)
        Me.ebCantidadNvo.Name = "ebCantidadNvo"
        Me.ebCantidadNvo.ReadOnly = True
        Me.ebCantidadNvo.Size = New System.Drawing.Size(72, 23)
        Me.ebCantidadNvo.TabIndex = 2
        Me.ebCantidadNvo.TabStop = False
        Me.ebCantidadNvo.Text = "0"
        Me.ebCantidadNvo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCantidadNvo.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebCantidadNvo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodigoNvo
        '
        Me.ebCodigoNvo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodigoNvo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodigoNvo.BackColor = System.Drawing.Color.Ivory
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebCodigoNvo.DesignTimeLayout = GridEXLayout1
        Me.ebCodigoNvo.Location = New System.Drawing.Point(96, 40)
        Me.ebCodigoNvo.Name = "ebCodigoNvo"
        Me.ebCodigoNvo.ReadOnly = True
        Me.ebCodigoNvo.Size = New System.Drawing.Size(224, 23)
        Me.ebCodigoNvo.TabIndex = 0
        Me.ebCodigoNvo.TabStop = False
        Me.ebCodigoNvo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoNvo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(184, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Cantidad:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Talla:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 23)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Codigo:"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.uiGuardar)
        Me.ExplorerBar3.Controls.Add(Me.NicePanel1)
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Imagen del Artículo"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar3.Location = New System.Drawing.Point(336, 48)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(336, 864)
        Me.ExplorerBar3.TabIndex = 3
        Me.ExplorerBar3.TabStop = False
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uiGuardar
        '
        Me.uiGuardar.Image = CType(resources.GetObject("uiGuardar.Image"), System.Drawing.Image)
        Me.uiGuardar.Location = New System.Drawing.Point(96, 232)
        Me.uiGuardar.Name = "uiGuardar"
        Me.uiGuardar.Size = New System.Drawing.Size(128, 32)
        Me.uiGuardar.TabIndex = 0
        Me.uiGuardar.Text = "Guardar"
        Me.uiGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'NicePanel1
        '
        Me.NicePanel1.BackColor = System.Drawing.Color.Transparent
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.NicePanel1.ContainerImage = ContainerImage1
        Me.NicePanel1.Controls.Add(Me.pbImagen)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.NicePanel1.FooterImage = HeaderImage1
        Me.NicePanel1.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.NicePanel1.FooterVisible = False
        Me.NicePanel1.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.PureComponents
        HeaderImage2.Image = Nothing
        Me.NicePanel1.HeaderImage = HeaderImage2
        Me.NicePanel1.HeaderText = "NicePanel1"
        Me.NicePanel1.HeaderVisible = False
        Me.NicePanel1.IsExpanded = True
        Me.NicePanel1.Location = New System.Drawing.Point(16, 32)
        Me.NicePanel1.Name = "NicePanel1"
        Me.NicePanel1.OriginalFooterVisible = False
        Me.NicePanel1.OriginalHeight = 0
        Me.NicePanel1.Size = New System.Drawing.Size(272, 192)
        ContainerStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.SystemColors.ControlDark
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.[Double]
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.SystemColors.ControlLightLight
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.NicePanel1.Style = PanelStyle1
        Me.NicePanel1.TabIndex = 1
        Me.NicePanel1.TabStop = False
        '
        'pbImagen
        '
        Me.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(272, 192)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 0
        Me.pbImagen.TabStop = False
        '
        'frmCambioTalla
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 334)
        Me.Controls.Add(Me.ExplorerBar3)
        Me.Controls.Add(Me.ExplorerBar2)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCambioTalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Talla"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.NicePanel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Environment Var"

    'Objeto Cambio Talla
    Dim oCambioTallaMgr As CambioTallaManager
    Dim oCambioTalla As CambioTalla

    'Objeto Artículo
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    Dim dtDetalleFactura As DataTable
    Dim dtTallas As DataTable = New DataTable("Tallas")

    Dim vCantAnt As Integer, vCorrida As String, vExistencia As Decimal
    Dim vFacturaID As Integer

#End Region

#Region "Initialize"

    Private Sub InitializeObjects()

        'Creamos Cambio Talla
        oCambioTallaMgr = New CambioTallaManager(oAppContext)
        oCambioTalla = oCambioTallaMgr.Create
        oCambioTalla.ClearFields()

        'Creamos Articulo
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

    End Sub

    Private Sub InitializeBinding()

        ebCaja.DataBindings.Add(New Binding("Text", oCambioTalla, "CodCaja"))
        ebFactura.DataBindings.Add(New Binding("Value", oCambioTalla, "Factura"))
        ebCodigoAnt.DataBindings.Add(New Binding("Text", oCambioTalla, "CodArticuloAnt"))
        ebTallaAnt.DataBindings.Add(New Binding("Value", oCambioTalla, "NumeroAnt"))
        ebCantidadAnt.DataBindings.Add(New Binding("Value", oCambioTalla, "CantidadAnt"))
        ebCodigoNvo.DataBindings.Add(New Binding("Text", oCambioTalla, "CodArticuloNvo"))
        ebTallaNvo.DataBindings.Add(New Binding("Value", oCambioTalla, "NumeroNvo"))
        ebCantidadNvo.DataBindings.Add(New Binding("Value", oCambioTalla, "CantidadNvo"))

    End Sub

#End Region

    Private Sub frmCambioTalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        InitializeBinding()

        GetCajaToCombo()

    End Sub

    Private Sub GetCajaToCombo()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        Dim oCaja As Caja

        'Creamos Caja
        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCaja = oCajaMgr.Create

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(False)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1

                ebCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

        End If

        oCaja = Nothing
        oCajaMgr = Nothing

    End Sub

    Private Sub ebFactura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebFactura.Validating

        If (ebFactura.Value > 0) Then

            'Llenamos el ColumCombo
            If Not (FillColumnCombo()) Then

                'Si no hay datos
                e.Cancel = True

            End If

        Else

            If (ebFactura.Value < 0) Then

                e.Cancel = True

            End If

        End If

    End Sub

    Private Function FillColumnCombo() As Boolean

        Dim ValorDeFactura As Integer = ebFactura.Value

        Dim dsDataColumn As DataSet = New DataSet

        dsDataColumn = oCambioTallaMgr.GetDetailFactura(ebFactura.Value, ebCaja.Text)

        If (dsDataColumn Is Nothing) Then

            MsgBox("Factura no corresponde a la Caja " & ebCaja.Text & " o no existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")

            ebFechaFactura.Value = Date.Today

            ClearScreen()

            oCambioTalla.Factura = 0

            Return False

        End If

        ClearScreen()

        CreateGridDetalle(dsDataColumn)

        dsDataColumn.Dispose()

        ebCodigoAnt.Enabled = True

        ebCantidadAnt.Enabled = True

        ebTallaNvo.Enabled = True

        ebCodigoAnt.Refresh()

        oCambioTalla.CodArticuloAnt = String.Empty

        oCambioTalla.Factura = ValorDeFactura

        ebCodigoAnt.Focus()

        Return True

    End Function

    Private Sub CreateGridDetalle(ByVal dsdetail As DataSet)

        Dim Drow As DataRow
        Dim nReg As Integer, idx As Integer

        Dim Dcol As DataColumn

        dtDetalleFactura = Nothing

        dtDetalleFactura = New DataTable

        Dcol = New DataColumn

        Dcol.AllowDBNull = True
        Dcol.ColumnName = "ID"
        Dcol.Caption = "ID"
        Dcol.DataType = System.Type.GetType("System.Int16")
        Dcol.AutoIncrement = True
        dtDetalleFactura.Columns.Add(Dcol)

        Dcol = New DataColumn
        Dcol.AllowDBNull = True
        Dcol.ColumnName = "Codigo"
        Dcol.Caption = "Codigo"
        Dcol.DataType = System.Type.GetType("System.String")
        dtDetalleFactura.Columns.Add(Dcol)

        Dcol = New DataColumn
        Dcol.AllowDBNull = True
        Dcol.ColumnName = "Talla"
        Dcol.Caption = "Talla"
        Dcol.DataType = System.Type.GetType("System.Decimal")
        dtDetalleFactura.Columns.Add(Dcol)

        Dcol = New DataColumn
        Dcol.AllowDBNull = True
        Dcol.ColumnName = "Cantidad"
        Dcol.Caption = "Cantidad"
        Dcol.DataType = System.Type.GetType("System.Decimal")
        dtDetalleFactura.Columns.Add(Dcol)

        dtDetalleFactura.Clear()

        ebFechaFactura.Value = dsdetail.Tables(0).Rows(idx).Item("Fecha")
        vFacturaID = dsdetail.Tables(0).Rows(idx).Item("FacturaID")

        nReg = dsdetail.Tables(0).Rows.Count

        For idx = 0 To nReg - 1

            Drow = dtDetalleFactura.NewRow
            Drow("Codigo") = dsdetail.Tables(0).Rows(idx).Item("CodArticulo")
            Drow("Talla") = dsdetail.Tables(0).Rows(idx).Item("Numero")
            Drow("Cantidad") = dsdetail.Tables(0).Rows(idx).Item("Cantidad")
            dtDetalleFactura.Rows.Add(Drow)

        Next

        With ebCodigoAnt

            .DropDownList.ClearStructure()

            .DataSource = dtDetalleFactura
            .DropDownList.Columns.Add("ID")
            .DropDownList.Columns.Add("Código")
            .DropDownList.Columns("Código").Width = 180
            .DropDownList.Columns.Add("Talla")
            .DropDownList.Columns("Talla").Width = 50
            .DropDownList.Columns.Add("Cantidad")
            .DropDownList.Columns("Cantidad").Width = 50

            .DropDownList.Columns("ID").DataMember = "ID"
            .DropDownList.Columns("ID").Visible = False
            .DropDownList.Columns("Código").DataMember = "Codigo"
            .DropDownList.Columns("Talla").DataMember = "Talla"
            .DropDownList.Columns("Cantidad").DataMember = "Cantidad"

            .DisplayMember = "Codigo"
            .ValueMember = "ID"

            .Refresh()

        End With

    End Sub

    Private Sub ebCodigoAnt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodigoAnt.Validating

        Dim idxV As Integer

        If ebCodigoAnt.Text <> "" Then

            Try

                idxV = ebCodigoAnt.Value

                oCambioTalla.NumeroAnt = dtDetalleFactura.Rows(idxV).Item("Talla")
                oCambioTalla.CantidadAnt = dtDetalleFactura.Rows(idxV).Item("Cantidad")
                vCantAnt = oCambioTalla.CantidadAnt

                oCambioTalla.CodArticuloAnt = dtDetalleFactura.Rows(idxV).Item("Codigo")
                oCambioTalla.CodArticuloNvo = oCambioTalla.CodArticuloAnt

                oArticulo = oArticuloMgr.Load(oCambioTalla.CodArticuloAnt)

                If oArticulo.WithImage = True Then
                    pbImagen.Image = Image.FromStream(oArticulo.Imagen)
                Else
                    pbImagen.Image = Nothing
                End If

                vCorrida = UCase(oArticulo.CodCorrida)

                If vCorrida = "ACC" Then

                    oCambioTalla.NumeroNvo = 0
                    ebTallaNvo.Enabled = False

                Else

                    oCambioTalla.NumeroNvo = 0
                    ebTallaNvo.Enabled = True
                    GetTallas(oArticulo.CodCorrida)

                End If

            Catch ex As Exception

                'Se produjo la excepcion por un error de asignación, por que no se introdujo un dato valido
                'presente en el combo. Entonces validamos lo ingresado y verificamos si existe.

                'Tomamos los dos primeros caracters del texto.
                Dim vNumeric As Decimal, vNumString As String, vCode As String
                Dim ixVal As Integer, SiHay As Boolean
                vNumString = Mid(ebCodigoAnt.Text, 1, 2)
                vCode = Mid(ebCodigoAnt.Text, 3, Len(ebCodigoAnt.Text) - 2)

                If IsNumeric(vNumString) Then

                    vNumeric = CDec(vNumString) / 2

                    SiHay = False

                    For ixVal = 0 To (dtDetalleFactura.Rows.Count - 1)

                        If Trim(dtDetalleFactura.Rows(ixVal).Item("Codigo")) = Trim(vCode) And dtDetalleFactura.Rows(ixVal).Item("Talla") = vNumeric Then

                            oCambioTalla.NumeroAnt = dtDetalleFactura.Rows(ixVal).Item("Talla")
                            'oCambioTalla.CantidadAnt = dtDetalleFactura.Rows(ixVal).Item("Cantidad")
                            oCambioTalla.CantidadAnt = 1
                            vCantAnt = oCambioTalla.CantidadAnt

                            oCambioTalla.CodArticuloAnt = dtDetalleFactura.Rows(ixVal).Item("Codigo")
                            oCambioTalla.CodArticuloNvo = oCambioTalla.CodArticuloAnt

                            oArticulo = oArticuloMgr.Load(oCambioTalla.CodArticuloAnt)

                            If oArticulo.WithImage = True Then
                                pbImagen.Image = Image.FromStream(oArticulo.Imagen)
                            Else
                                pbImagen.Image = Nothing
                            End If

                            vCorrida = UCase(oArticulo.CodCorrida)

                            If vCorrida = "ACC" Then

                                oCambioTalla.NumeroNvo = 0
                                ebTallaNvo.Enabled = False

                            Else

                                oCambioTalla.NumeroNvo = 0
                                ebTallaNvo.Enabled = True
                                GetTallas(oArticulo.CodCorrida)

                            End If

                            'Salimos del For
                            SiHay = True
                            Exit For

                        End If

                    Next

                    If SiHay = False Then
                        MsgBox("El Código " & vCode & " en Talla " & vNumeric.ToString & " no existe en la factura. Verifique", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                        oCambioTalla.NumeroAnt = 0
                        oCambioTalla.CantidadAnt = 0
                        oCambioTalla.NumeroNvo = 0
                        oCambioTalla.CantidadNvo = 0
                        pbImagen.Image = Nothing
                        oCambioTalla.CodArticuloAnt = String.Empty
                        oCambioTalla.CodArticuloNvo = String.Empty
                        e.Cancel = True
                    End If

                Else

                    MsgBox("Código incorrecto o no existe en la factura. Verifique", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                    oCambioTalla.NumeroAnt = 0
                    oCambioTalla.CantidadAnt = 0
                    oCambioTalla.NumeroNvo = 0
                    oCambioTalla.CantidadNvo = 0
                    pbImagen.Image = Nothing
                    oCambioTalla.CodArticuloAnt = String.Empty
                    oCambioTalla.CodArticuloNvo = String.Empty
                    e.Cancel = True

                End If

            End Try

        End If

    End Sub

    Private Sub GetTallas(ByVal IDCorrida As String)

        Dim iCtalla As Integer
        Dim Dcol As DataColumn = New DataColumn
        Dim Drow As DataRow

        dtTallas = Nothing

        dtTallas = New DataTable

        Dcol = New DataColumn
        Dcol.AllowDBNull = True
        Dcol.ColumnName = "Talla"
        Dcol.Caption = "Talla"
        Dcol.DataType = System.Type.GetType("System.Decimal")
        dtTallas.Columns.Add(Dcol)

        Dim dsTallas As DataSet = New DataSet
        Dim idx As Integer, iField As String

        dsTallas = oCambioTallaMgr.GetTallas(IDCorrida)

        If dsTallas.Tables(0).Rows.Count > 0 Then

            For idx = 1 To 20

                iField = "C" + Format(idx, "00")

                If idx = 1 Then

                    If dsTallas.Tables(0).Rows(0).Item(iField) <> oCambioTalla.NumeroAnt Then
                        Drow = dtTallas.NewRow
                        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                        dtTallas.Rows.Add(Drow)
                    End If

                Else

                    If (dsTallas.Tables(0).Rows(0).Item(iField) > 0) And (dsTallas.Tables(0).Rows(0).Item(iField) <> oCambioTalla.NumeroAnt) Then

                        Drow = dtTallas.NewRow
                        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                        dtTallas.Rows.Add(Drow)

                    End If

                End If

            Next

        Else

            MsgBox("La corrida del artículo no esta registrada.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, " Cambio de Talla")

            Me.Close()

        End If


        dsTallas = Nothing

    End Sub

    Private Sub ebCantidadAnt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCantidadAnt.Validating

        If ebCodigoAnt.Text <> "" Then

            If (ebCantidadAnt.Value > vCantAnt) Or (ebCantidadAnt.Value <= 0) Then

                MsgBox("La cantidad ingresada no es correcta. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")

                oCambioTalla.CantidadAnt = vCantAnt

                e.Cancel = True

            Else

                oCambioTalla.CantidadAnt = ebCantidadAnt.Value
                oCambioTalla.CantidadNvo = oCambioTalla.CantidadAnt

            End If

        End If

    End Sub

    Private Sub ebTallaNvo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTallaNvo.Validating

        If ebCodigoAnt.Text <> "" Then

            If (ebTallaNvo.Value = oCambioTalla.NumeroAnt) Then

                MsgBox("La talla a cambiar debe ser diferente a la anterior. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                oCambioTalla.NumeroNvo = 0
                e.Cancel = True

            Else

                If (ebTallaNvo.Value < 0) Then

                    MsgBox("Talla incorrecta. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                    oCambioTalla.NumeroNvo = 0
                    e.Cancel = True

                Else

                    If (ebTallaNvo.Value = 0) Then
                        Exit Sub
                    End If

                    If Not ValidaTalla(ebTallaNvo.Value) Then

                        MsgBox("La talla ingresada no corresponde al articulo. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                        oCambioTalla.NumeroNvo = 0
                        e.Cancel = True

                    Else

                        If (vExistencia >= oCambioTalla.CantidadNvo) Then

                            oCambioTalla.NumeroNvo = ebTallaNvo.Value

                        Else

                            If (vExistencia < 1) Then
                                MsgBox("No se cuenta con existencia en esta talla.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                            Else
                                MsgBox("Esta talla solo cuenta con " & vExistencia.ToString & " PP. en Existencias. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                            End If
                            oCambioTalla.NumeroNvo = 0
                            e.Cancel = True

                        End If

                    End If

                End If

            End If

        End If

    End Sub

    Private Function ValidaTalla(ByVal Talla As Decimal) As Boolean

        Dim idxTalla As Integer

        For idxTalla = 0 To (dtTallas.Rows.Count - 1)

            If dtTallas.Rows(idxTalla).Item("Talla") = Talla Then

                vExistencia = oCambioTallaMgr.GetStock(oCambioTalla.CodAlmacen, oCambioTalla.CodArticuloNvo, Talla)

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub uiGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles uiGuardar.Click

        SaveData()

        If oCambioTalla.CodArticuloAnt = String.Empty Then
            ebCaja.Focus()
        Else
            ebCodigoAnt.Focus()
        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoSalir"

                Me.Close()

            Case "menuArchivoNuevo"

                ClearScreen()
                oCambioTalla.CodCaja = ""
                oCambioTalla.Factura = 0
                ebCaja.Focus()

            Case "menuArchivoGuardar"

                SaveData()

                If oCambioTalla.CodArticuloAnt = String.Empty Then
                    ebCaja.Focus()
                Else
                    ebCodigoAnt.Focus()
                End If

            Case "menuAyudaTema"

                'TODO : Implementar Aqui la Ayuda

            Case Else

                MsgBox(e.Command.Key.ToString)

        End Select

    End Sub

    Private Sub ClearScreen()

        ebCodigoAnt.Enabled = False
        ebCantidadAnt.Enabled = False
        ebTallaNvo.Enabled = False

        oCambioTalla.CodArticuloNvo = String.Empty
        oCambioTalla.CodArticuloAnt = String.Empty
        oCambioTalla.NumeroNvo = 0
        oCambioTalla.NumeroAnt = 0
        oCambioTalla.CantidadAnt = 0
        oCambioTalla.CantidadNvo = 0
        ebFechaFactura.Value = Date.Today
        pbImagen.Image = Nothing

        ebCaja.Focus()

    End Sub

    Private Sub FillDataMovimiento(ByVal CambiodeTallaID As Integer)

        With oCambioTalla.Movimiento

            .CodTipoMov = 0
            .TipoMovimiento = ""
            .StatusMov = "A"
            .CodAlmacenMov = oCambioTalla.CodAlmacen
            .Destino = oCambioTalla.CodAlmacen
            .Folio = CambiodeTallaID
            .CodArticulo = oArticulo.CodArticulo
            .Descripcion = oArticulo.Descripcion
            .Numero = 0
            .Total = 0
            .Apartados = 0
            .Defectuosos = 0
            .Promocion = 0
            .VtasEspeciales = 0
            .Consignacion = 0
            .Transito = 0
            .CodLinea = oArticulo.Codlinea
            .CodMarca = oArticulo.CodMarca
            .CodFamilia = oArticulo.CodFamilia
            .CodUnidad = oArticulo.CodUnidadVta
            .CodUso = oArticulo.CodUso
            .CodCategoria = oArticulo.CodCategoria
            .UsuarioMov = oCambioTalla.Usuario
            .CostoUnit = oArticulo.PrecioVenta
            .PrecioUnit = oArticulo.PrecioVenta
            .FolioControl = ""
            .CodCajaMov = oCambioTalla.CodCaja

        End With


    End Sub

    Private Function IntegridadDatos() As Boolean

        If oCambioTalla.CodArticuloAnt <> "" And _
            oCambioTalla.CodArticuloNvo <> "" And _
            oCambioTalla.CantidadAnt > 0 And _
            oCambioTalla.CantidadNvo > 0 Then

            If (ebTallaNvo.Value = 0) Then

                If (oArticulo.CodCorrida <> "TEX") And (oArticulo.CodCorrida <> "ACC") Then

                    MsgBox("No se puede guardar. Talla nueva incorrecta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")

                    ebTallaNvo.Focus()

                    Return False

                Else

                    vExistencia = 0

                    vExistencia = oCambioTallaMgr.GetStock(oCambioTalla.CodAlmacen, oCambioTalla.CodArticuloNvo, 0)

                    If (vExistencia >= oCambioTalla.CantidadNvo) Then

                        Return True

                    Else

                        If (vExistencia < 1) Then

                            MsgBox("Artículo nuevo no cuenta con existencia.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                            ebTallaNvo.Focus()

                        Else

                            MsgBox("Artículo nuevo solo cuenta con " & vExistencia.ToString & " PP. en Existencias. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
                            ebTallaNvo.Focus()

                        End If

                        Return False

                    End If


                End If

            Else

                Return True

            End If

        Else

            MsgBox("No se puede guardar. Faltan Datos.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")
            ebCodigoAnt.Focus()

            Return False

        End If

    End Function

    Private Sub SaveData()

        Dim vCambioTallaID As Integer

        If IntegridadDatos() = False Then
            Exit Sub
        End If

        'Guardamos 
        oCambioTalla.Factura = vFacturaID
        vCambioTallaID = oCambioTallaMgr.Save(oCambioTalla)

        If vCambioTallaID = 0 Then

            MsgBox("El cambio de talla no se guardó.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, " Cambio de Talla")

        Else

            'Llenamos datos necesarios de movimientos
            FillDataMovimiento(vCambioTallaID)

            'Guardamos Movimiento de Entrada
            oCambioTallaMgr.SaveMoveInOut(112, "E", oCambioTalla.NumeroAnt, oCambioTalla)
            'Guardamos Movimiento de Salida
            oCambioTallaMgr.SaveMoveInOut(215, "S", oCambioTalla.NumeroNvo, oCambioTalla)

            MsgBox("Cambio de Talla guardado satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cambio de Talla")

            'Limpiamos la pantalla para una nueva captura

            ClearScreen()
            oCambioTalla.CodCaja = ""
            oCambioTalla.Factura = 0
            ebCaja.Focus()

        End If

    End Sub

    Private Sub ebFactura_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebFactura.ButtonClick

        LoadSearchForm()

    End Sub

    Private Sub ebFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebFactura.KeyDown

        Select Case e.KeyCode

            Case Keys.Alt.S

                LoadSearchForm()

        End Select

    End Sub

    Private Sub LoadSearchForm()

        Dim dsTemFactura As DataSet
        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New CambioTallaFacturaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            dsTemFactura = oCambioTallaMgr.LoadFacturaByID(oOpenRecordDlg.Record.Item("ID"))

            If Not (dsTemFactura Is Nothing) Then

                oCambioTalla.CodCaja = dsTemFactura.Tables(0).Rows(0).Item("CodCaja")
                oCambioTalla.Factura = dsTemFactura.Tables(0).Rows(0).Item("FolioFactura")

                If Not (FillColumnCombo()) Then

                    'Si no hay datos
                    ClearScreen()
                    oCambioTalla.CodCaja = ""
                    oCambioTalla.Factura = 0
                    ebCaja.Focus()

                End If

            Else

                MsgBox("La Factura seleccionada NO EXISTE", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Información")
                ClearScreen()
                oCambioTalla.CodCaja = ""
                oCambioTalla.Factura = 0
                ebCaja.Focus()

            End If

        End If

    End Sub

    Private Sub ebCodigoAnt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodigoAnt.KeyUp

        Select Case e.KeyCode

            Case Keys.Enter

                'e.Handled = True

                If ebCodigoAnt.Text <> "" Then

                    SendKeys.Send("{TAB}")

                End If

        End Select

    End Sub

    Private Sub TopRebar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopRebar1.Click

    End Sub

    Private Sub ExplorerBar3_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar3.ItemClick

    End Sub

    Private Sub frmCambioTalla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
