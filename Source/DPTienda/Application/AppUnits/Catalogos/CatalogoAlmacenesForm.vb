Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes

Public Class CatalogoAlmacenesForm
    Inherits System.Windows.Forms.Form

    Private oCatalogoAlmacenesMgr As CatalogoAlmacenesManager
    Private oAlmacen As Almacen

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        InitializeObjects()

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
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarAyuda2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTelefonoNum As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionEstado As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionNoInt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionCiudad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionNoExt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDireccionCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents mebTelefonoLada As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents uicbMostrarEnSeparacion As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents uicbEsTienda As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebPlaza As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents MenuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MenuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents pbInactivo As System.Windows.Forms.PictureBox
    Friend WithEvents pbActivo As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoAlmacenesForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.MenuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuBarAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.MenuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuBarAyuda2 = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuBarNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuBarNuevo")
        Me.menuBarAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuBarAyuda")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.ebPlaza = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebTelefonoNum = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionCP = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionEstado = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionNoInt = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionCiudad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionNoExt = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDireccionCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebID = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.mebTelefonoLada = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.pbActivo = New System.Windows.Forms.PictureBox
        Me.uicbMostrarEnSeparacion = New Janus.Windows.EditControls.UICheckBox
        Me.uicbEsTienda = New Janus.Windows.EditControls.UICheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.pbInactivo = New System.Windows.Forms.PictureBox
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuSalir, Me.menuBarNuevo, Me.menuBarAyuda, Me.menuAbrir})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("869c2982-4be2-4db4-82f9-6f94aedf29d2")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.UiCommandManager1
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.TabIndex = 0
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(488, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
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
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuAbrir2, Me.Separator1, Me.menuBarAyuda1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(116, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'MenuAbrir2
        '
        Me.MenuAbrir2.Key = "menuAbrir"
        Me.MenuAbrir2.Name = "MenuAbrir2"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuBarAyuda1
        '
        Me.menuBarAyuda1.Image = CType(resources.GetObject("menuBarAyuda1.Image"), System.Drawing.Image)
        Me.menuBarAyuda1.Key = "menuBarAyuda"
        Me.menuBarAyuda1.Name = "menuBarAyuda1"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.MenuAbrir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'MenuAbrir1
        '
        Me.MenuAbrir1.Key = "menuAbrir"
        Me.MenuAbrir1.Name = "MenuAbrir1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuBarAyuda2})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
        '
        'menuBarAyuda2
        '
        Me.menuBarAyuda2.Key = "menuBarAyuda"
        Me.menuBarAyuda2.Name = "menuBarAyuda2"
        Me.menuBarAyuda2.Text = "&Temas de Ayuda"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuBarNuevo
        '
        Me.menuBarNuevo.Image = CType(resources.GetObject("menuBarNuevo.Image"), System.Drawing.Image)
        Me.menuBarNuevo.Key = "menuBarNuevo"
        Me.menuBarNuevo.Name = "menuBarNuevo"
        Me.menuBarNuevo.Text = "Nuevo"
        '
        'menuBarAyuda
        '
        Me.menuBarAyuda.Image = CType(resources.GetObject("menuBarAyuda.Image"), System.Drawing.Image)
        Me.menuBarAyuda.Key = "menuBarAyuda"
        Me.menuBarAyuda.Name = "menuBarAyuda"
        Me.menuBarAyuda.Text = "Ayu&da"
        '
        'menuAbrir
        '
        Me.menuAbrir.Icon = CType(resources.GetObject("menuAbrir.Icon"), System.Drawing.Icon)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.UiCommandManager1
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.TabIndex = 0
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.UiCommandManager1
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.TabIndex = 0
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
        Me.TopRebar1.Size = New System.Drawing.Size(488, 50)
        Me.TopRebar1.TabIndex = 0
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.White
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.TabPage
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ebPlaza)
        Me.UiGroupBox1.Controls.Add(Me.ebTelefonoNum)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionCP)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionEstado)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionNoInt)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionCiudad)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionColonia)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionNoExt)
        Me.UiGroupBox1.Controls.Add(Me.ebDireccionCalle)
        Me.UiGroupBox1.Controls.Add(Me.ebDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.ebID)
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(488, 292)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.UseThemes = False
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ebPlaza
        '
        Me.ebPlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlaza.BackColor = System.Drawing.Color.Ivory
        Me.ebPlaza.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlaza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPlaza.Location = New System.Drawing.Point(96, 208)
        Me.ebPlaza.Name = "ebPlaza"
        Me.ebPlaza.ReadOnly = True
        Me.ebPlaza.Size = New System.Drawing.Size(144, 22)
        Me.ebPlaza.TabIndex = 7
        Me.ebPlaza.TabStop = False
        Me.ebPlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTelefonoNum
        '
        Me.ebTelefonoNum.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefonoNum.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefonoNum.BackColor = System.Drawing.Color.Ivory
        Me.ebTelefonoNum.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefonoNum.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefonoNum.Location = New System.Drawing.Point(360, 208)
        Me.ebTelefonoNum.Name = "ebTelefonoNum"
        Me.ebTelefonoNum.ReadOnly = True
        Me.ebTelefonoNum.Size = New System.Drawing.Size(104, 22)
        Me.ebTelefonoNum.TabIndex = 11
        Me.ebTelefonoNum.TabStop = False
        Me.ebTelefonoNum.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefonoNum.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionCP
        '
        Me.ebDireccionCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionCP.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionCP.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCP.Location = New System.Drawing.Point(360, 184)
        Me.ebDireccionCP.Name = "ebDireccionCP"
        Me.ebDireccionCP.ReadOnly = True
        Me.ebDireccionCP.Size = New System.Drawing.Size(104, 22)
        Me.ebDireccionCP.TabIndex = 10
        Me.ebDireccionCP.TabStop = False
        Me.ebDireccionCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionEstado
        '
        Me.ebDireccionEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionEstado.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionEstado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionEstado.Location = New System.Drawing.Point(360, 160)
        Me.ebDireccionEstado.Name = "ebDireccionEstado"
        Me.ebDireccionEstado.ReadOnly = True
        Me.ebDireccionEstado.Size = New System.Drawing.Size(104, 22)
        Me.ebDireccionEstado.TabIndex = 9
        Me.ebDireccionEstado.TabStop = False
        Me.ebDireccionEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionNoInt
        '
        Me.ebDireccionNoInt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionNoInt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionNoInt.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionNoInt.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionNoInt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionNoInt.Location = New System.Drawing.Point(360, 136)
        Me.ebDireccionNoInt.Name = "ebDireccionNoInt"
        Me.ebDireccionNoInt.ReadOnly = True
        Me.ebDireccionNoInt.Size = New System.Drawing.Size(104, 22)
        Me.ebDireccionNoInt.TabIndex = 8
        Me.ebDireccionNoInt.TabStop = False
        Me.ebDireccionNoInt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionNoInt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionCiudad
        '
        Me.ebDireccionCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionCiudad.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionCiudad.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCiudad.Location = New System.Drawing.Point(96, 184)
        Me.ebDireccionCiudad.Name = "ebDireccionCiudad"
        Me.ebDireccionCiudad.ReadOnly = True
        Me.ebDireccionCiudad.Size = New System.Drawing.Size(144, 22)
        Me.ebDireccionCiudad.TabIndex = 5
        Me.ebDireccionCiudad.TabStop = False
        Me.ebDireccionCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionColonia
        '
        Me.ebDireccionColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionColonia.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionColonia.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionColonia.Location = New System.Drawing.Point(96, 160)
        Me.ebDireccionColonia.Name = "ebDireccionColonia"
        Me.ebDireccionColonia.ReadOnly = True
        Me.ebDireccionColonia.Size = New System.Drawing.Size(144, 22)
        Me.ebDireccionColonia.TabIndex = 4
        Me.ebDireccionColonia.TabStop = False
        Me.ebDireccionColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionNoExt
        '
        Me.ebDireccionNoExt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionNoExt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionNoExt.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionNoExt.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionNoExt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionNoExt.Location = New System.Drawing.Point(96, 136)
        Me.ebDireccionNoExt.Name = "ebDireccionNoExt"
        Me.ebDireccionNoExt.ReadOnly = True
        Me.ebDireccionNoExt.Size = New System.Drawing.Size(80, 22)
        Me.ebDireccionNoExt.TabIndex = 3
        Me.ebDireccionNoExt.TabStop = False
        Me.ebDireccionNoExt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionNoExt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDireccionCalle
        '
        Me.ebDireccionCalle.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDireccionCalle.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDireccionCalle.BackColor = System.Drawing.Color.Ivory
        Me.ebDireccionCalle.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCalle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDireccionCalle.Location = New System.Drawing.Point(96, 112)
        Me.ebDireccionCalle.Name = "ebDireccionCalle"
        Me.ebDireccionCalle.ReadOnly = True
        Me.ebDireccionCalle.Size = New System.Drawing.Size(368, 22)
        Me.ebDireccionCalle.TabIndex = 2
        Me.ebDireccionCalle.TabStop = False
        Me.ebDireccionCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDireccionCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDescripcion
        '
        Me.ebDescripcion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDescripcion.BackColor = System.Drawing.Color.Ivory
        Me.ebDescripcion.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDescripcion.Location = New System.Drawing.Point(96, 88)
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.ReadOnly = True
        Me.ebDescripcion.Size = New System.Drawing.Size(368, 22)
        Me.ebDescripcion.TabIndex = 1
        Me.ebDescripcion.TabStop = False
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebID
        '
        Me.ebID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebID.ButtonImage = CType(resources.GetObject("ebID.ButtonImage"), System.Drawing.Image)
        Me.ebID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebID.ForeColor = System.Drawing.Color.Red
        Me.ebID.Location = New System.Drawing.Point(96, 64)
        Me.ebID.MaxLength = 3
        Me.ebID.Name = "ebID"
        Me.ebID.Size = New System.Drawing.Size(128, 22)
        Me.ebID.TabIndex = 0
        Me.ebID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.mebTelefonoLada)
        Me.ExplorerBar1.Controls.Add(Me.pbActivo)
        Me.ExplorerBar1.Controls.Add(Me.uicbMostrarEnSeparacion)
        Me.ExplorerBar1.Controls.Add(Me.uicbEsTienda)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label25)
        Me.ExplorerBar1.Controls.Add(Me.Label24)
        Me.ExplorerBar1.Controls.Add(Me.Label23)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label15)
        Me.ExplorerBar1.Controls.Add(Me.Label14)
        Me.ExplorerBar1.Controls.Add(Me.pbInactivo)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Almacen"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.ScrollBarStyle.HoverBaseColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ExplorerBar1.Size = New System.Drawing.Size(488, 292)
        Me.ExplorerBar1.SpecialGroupsFormatStyle.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ExplorerBar1.TabIndex = 7
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        Me.ExplorerBar1.VisualStyleAreas.BackgroundStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'mebTelefonoLada
        '
        Me.mebTelefonoLada.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.mebTelefonoLada.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.mebTelefonoLada.BackColor = System.Drawing.Color.Ivory
        Me.mebTelefonoLada.Location = New System.Drawing.Point(96, 232)
        Me.mebTelefonoLada.Mask = "!(###) 000-0000"
        Me.mebTelefonoLada.Name = "mebTelefonoLada"
        Me.mebTelefonoLada.ReadOnly = True
        Me.mebTelefonoLada.Size = New System.Drawing.Size(144, 23)
        Me.mebTelefonoLada.TabIndex = 0
        Me.mebTelefonoLada.TabStop = False
        Me.mebTelefonoLada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.mebTelefonoLada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbActivo
        '
        Me.pbActivo.BackColor = System.Drawing.Color.Transparent
        Me.pbActivo.Image = CType(resources.GetObject("pbActivo.Image"), System.Drawing.Image)
        Me.pbActivo.Location = New System.Drawing.Point(392, 40)
        Me.pbActivo.Name = "pbActivo"
        Me.pbActivo.Size = New System.Drawing.Size(32, 16)
        Me.pbActivo.TabIndex = 22
        Me.pbActivo.TabStop = False
        '
        'uicbMostrarEnSeparacion
        '
        Me.uicbMostrarEnSeparacion.BackColor = System.Drawing.Color.Transparent
        Me.uicbMostrarEnSeparacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.uicbMostrarEnSeparacion.Enabled = False
        Me.uicbMostrarEnSeparacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uicbMostrarEnSeparacion.Location = New System.Drawing.Point(304, 64)
        Me.uicbMostrarEnSeparacion.Name = "uicbMostrarEnSeparacion"
        Me.uicbMostrarEnSeparacion.Size = New System.Drawing.Size(160, 23)
        Me.uicbMostrarEnSeparacion.TabIndex = 2
        Me.uicbMostrarEnSeparacion.Text = "Mostrar en Separacion"
        Me.uicbMostrarEnSeparacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'uicbEsTienda
        '
        Me.uicbEsTienda.BackColor = System.Drawing.Color.Transparent
        Me.uicbEsTienda.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.uicbEsTienda.Enabled = False
        Me.uicbEsTienda.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uicbEsTienda.Location = New System.Drawing.Point(224, 64)
        Me.uicbEsTienda.Name = "uicbEsTienda"
        Me.uicbEsTienda.Size = New System.Drawing.Size(64, 23)
        Me.uicbEsTienda.TabIndex = 1
        Me.uicbEsTienda.Text = "Tienda"
        Me.uicbEsTienda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(304, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ACTIVA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(280, 216)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 23)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Telefono:"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(280, 168)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 23)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Estado:"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(280, 192)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 23)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "C.P."
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(280, 144)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 23)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "No. Interior:"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(16, 216)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 23)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Plaza:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 240)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 23)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Lada:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 192)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 23)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Ciudad:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 144)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 23)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "No. Exterior:"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 23)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Calle:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 23)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Descripcion:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 23)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Codigo:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 23)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Colonia:"
        '
        'pbInactivo
        '
        Me.pbInactivo.BackColor = System.Drawing.Color.Transparent
        Me.pbInactivo.Image = CType(resources.GetObject("pbInactivo.Image"), System.Drawing.Image)
        Me.pbInactivo.Location = New System.Drawing.Point(392, 40)
        Me.pbInactivo.Name = "pbInactivo"
        Me.pbInactivo.Size = New System.Drawing.Size(24, 24)
        Me.pbInactivo.TabIndex = 138
        Me.pbInactivo.TabStop = False
        Me.pbInactivo.Visible = False
        '
        'CatalogoAlmacenesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 342)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(496, 376)
        Me.MinimumSize = New System.Drawing.Size(496, 376)
        Me.Name = "CatalogoAlmacenesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Almacenes"
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Métodos Privados"

    Private Sub Sm_TxtLimpiar()

        With oAlmacen

            .ID = String.Empty
            .Descripcion = String.Empty
            .PlazaID = String.Empty
            .DireccionCalle = String.Empty
            .DireccionEstado = String.Empty
            .DireccionCiudad = String.Empty
            .DireccionCP = String.Empty
            .DireccionColonia = String.Empty
            .DireccionNumInt = String.Empty
            .DireccionNumExt = String.Empty
            .TelefonoLada = String.Empty
            .TelefonoNum = String.Empty

            .EsTienda = False
            .MostrarEnSeparaciones = False

        End With

    End Sub



    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (ebID.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As OpenRecordDialog
            oOpenRecordDlg = New OpenRecordDialog
            oOpenRecordDlg.CurrentView = New CatalogoAlmacenesOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Dim strAlmacenID As String

                strAlmacenID = oOpenRecordDlg.Record.Item("CodAlmacen")

                If strAlmacenID = Nothing Then

                    oCatalogoAlmacenesMgr.LoadInto(ebID.Text, oAlmacen)

                Else

                    oCatalogoAlmacenesMgr.LoadInto(strAlmacenID, oAlmacen)
                End If

            End If

            oOpenRecordDlg = Nothing

        Else

            oCatalogoAlmacenesMgr.LoadInto(ebID.Text.Trim, oAlmacen)

        End If

        If oAlmacen.RecordEnabled = True Then
            Label2.Text = "Activa"
            Me.pbActivo.Visible = True
            Me.pbInactivo.Visible = False
        Else
            Label2.Text = "Inactiva"
            Me.pbActivo.Visible = False
            Me.pbInactivo.Visible = True
        End If

        ebID.Focus()
        ebID.SelectAll()
    End Sub


#End Region


    Private Sub InitializeObjects()

        oCatalogoAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oCatalogoAlmacenesMgr.Create

    End Sub

    Private Sub InitializeDataBindings()
        Try

            ebID.DataBindings.Add(New Binding("Text", oAlmacen, "ID"))
            ebDescripcion.DataBindings.Add(New Binding("Text", oAlmacen, "Descripcion"))
            ebPlaza.DataBindings.Add(New Binding("Text", oAlmacen, "PlazaID"))
            ebDireccionCalle.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionCalle"))
            ebDireccionEstado.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionEstado"))
            ebDireccionCiudad.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionCiudad"))
            ebDireccionCP.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionCP"))
            ebDireccionColonia.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionColonia"))
            ebDireccionNoInt.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionNumInt"))
            ebDireccionNoExt.DataBindings.Add(New Binding("Text", oAlmacen, "DireccionNumExt"))
            mebTelefonoLada.DataBindings.Add(New Binding("Text", oAlmacen, "TelefonoLada"))
            ebTelefonoNum.DataBindings.Add(New Binding("Text", oAlmacen, "TelefonoNum"))
            uicbEsTienda.DataBindings.Add(New Binding("Checked", oAlmacen, "EsTienda"))
            uicbMostrarEnSeparacion.DataBindings.Add(New Binding("Checked", oAlmacen, "MostrarEnSeparaciones"))


        Catch ex As Exception

            Throw ex

        End Try
    End Sub

    Private Sub CatalogoAlmacenesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            InitializeDataBindings()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuAbrir"

                Sm_Buscar(True)

            Case "menuAyudaTema"


            Case "menuSalir"

                Me.Close()

        End Select

    End Sub

    Private Sub ebID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebID.ButtonClick

        Sm_Buscar(True)

    End Sub

    Private Sub ebID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebID.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Dim codigo As String = ebID.Text
            For Each c As Char In ebID.Text
                If Not (Char.IsNumber(c)) Then
                    MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ebID.Focus()
                    ebID.SelectAll()
                    Exit Sub
                End If
            Next
            ebID.Text = Format(CType(codigo, Integer), "000")
            Sm_Buscar()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            Sm_Buscar(True)
        End If

    End Sub

    
    Private Sub CatalogoAlmacenesForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
