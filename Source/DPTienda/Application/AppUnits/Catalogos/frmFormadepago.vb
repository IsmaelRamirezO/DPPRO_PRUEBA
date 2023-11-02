Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago


Public Class frmformadepago
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
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiButton3 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmformadepago))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiButton3 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAyudaTema, Me.menuArchivoGuardar, Me.menuArchivoEliminar})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("54537ab9-f186-4540-97c9-d54d8469a652")
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
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(352, 22)
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
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoGuardar2, Me.Separator4, Me.menuArchivoEliminar2, Me.Separator5, Me.menuAyudaTema1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(292, 28)
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
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator2, Me.menuArchivoGuardar1, Me.Separator3, Me.menuArchivoEliminar1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema2})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "&Temas de Ayuda"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Image = CType(resources.GetObject("menuArchivoEliminar.Image"), System.Drawing.Image)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "&Eliminar"
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
        Me.TopRebar1.Size = New System.Drawing.Size(352, 50)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.ExplorerBar1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(352, 184)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.UiButton3)
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Forma de Pago"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(360, 200)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.BackColor = System.Drawing.Color.White
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(120, 64)
        Me.EditBox4.MaxLength = 30
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(216, 22)
        Me.EditBox4.TabIndex = 14
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(25, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Descripción:"
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Location = New System.Drawing.Point(24, 48)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(96, 16)
        Me.lblLabel3.TabIndex = 0
        Me.lblLabel3.Text = "C.  Tipo Venta:"
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.BackColor = System.Drawing.Color.Ivory
        Me.EditBox3.ButtonImage = CType(resources.GetObject("EditBox3.ButtonImage"), System.Drawing.Image)
        Me.EditBox3.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(120, 40)
        Me.EditBox3.MaxLength = 1
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(56, 22)
        Me.EditBox3.TabIndex = 3
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiButton3
        '
        Me.UiButton3.Location = New System.Drawing.Point(223, 152)
        Me.UiButton3.Name = "UiButton3"
        Me.UiButton3.Size = New System.Drawing.Size(75, 23)
        Me.UiButton3.TabIndex = 12
        Me.UiButton3.Text = "Eliminar"
        Me.UiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton2
        '
        Me.UiButton2.Location = New System.Drawing.Point(143, 152)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(75, 23)
        Me.UiButton2.TabIndex = 11
        Me.UiButton2.Text = "Guardar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(63, 152)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(75, 23)
        Me.UiButton1.TabIndex = 10
        Me.UiButton1.Text = "Nuevo"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.BackColor = System.Drawing.Color.White
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(120, 112)
        Me.EditBox2.MaxLength = 30
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(216, 22)
        Me.EditBox2.TabIndex = 5
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.ButtonImage = CType(resources.GetObject("EditBox1.ButtonImage"), System.Drawing.Image)
        Me.EditBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(120, 88)
        Me.EditBox1.MaxLength = 1
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(56, 22)
        Me.EditBox1.TabIndex = 4
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(25, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(24, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'frmformadepago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 234)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(368, 272)
        Me.MinimumSize = New System.Drawing.Size(368, 272)
        Me.Name = "frmformadepago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Formas de Pago"
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



#Region "Variables Miembros"
    Private oCatalogoTipoVentaMgr As CatalogoTipoVentaManager
    Private oCatalogoFormasPagoMgr As CatalogoFormasPagoManager
    'Private oCatalogoFormasPagoMgr As New CatalogoFormasPagoManager(oAppContext)

    Private oFormaPago As FormaPago
    Private oTipoVenta As TipoVenta

#End Region



#Region "Métodos Miembros"

    Private Function Fm_bolTxtValidar(Optional ByVal Vpa_strOpcion As String = "") As Boolean

        If (Vpa_strOpcion = "Guardar") Then

            EditBox1.Text = EditBox1.Text.Trim
            

            If (EditBox1.Text.Trim = String.Empty) Then
                MessageBox.Show("Debe especificar un Código de Forma Pago", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EditBox1.Focus()
                Exit Function
            End If

        End If


        EditBox2.Text = EditBox2.Text.Trim

        If (EditBox2.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Descripción de Forma Pago", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox2.Focus()
            Exit Function
        End If

        EditBox3.Text = EditBox3.Text.Trim

        If (EditBox3.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar un Codigo de Venta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox3.Focus()
            Exit Function
        End If


        Return True

    End Function



    Private Sub Sm_Nuevo()

        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Text = String.Empty
        EditBox4.Text = String.Empty
        EditBox3.Focus()

        On Error Resume Next
        oFormaPago = Nothing
        oTipoVenta = Nothing

    End Sub



    Private Sub Sm_Guardar()
        'If oFormaPago Is Nothing Then
        '    MessageBox.Show("No hay registro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    Exit Sub
        'End If

        'oFormaPago = oCatalogoFormasPagoMgr.Load(EditBox1.Text, oTipoVenta.ID, "Grabar")

        EditBox3.Focus()

        If (oFormaPago Is Nothing) Then   'Opción Guardar.

            If (oTipoVenta Is Nothing) Then

                MsgBox("No ha seleccionado un Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")
                EditBox3.Focus()

                Exit Sub

            End If


            oFormaPago = oCatalogoFormasPagoMgr.Load(EditBox1.Text, oTipoVenta.ID, "Grabar")

            If Not (oFormaPago Is Nothing) And (oTipoVenta Is Nothing) Then

                MsgBox("El Registro ya existe.", MsgBoxStyle.Exclamation, "DPTienda")
                oFormaPago = Nothing
                EditBox1.Focus()

                Exit Sub

            End If


            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar("Guardar") = False) Then
                Exit Sub
            End If


            oFormaPago = oCatalogoFormasPagoMgr.Create

            oFormaPago.ID = EditBox1.Text
            oFormaPago.VentaID = EditBox3.Text
            oFormaPago.Descripcion = EditBox2.Text
            oFormaPago.Usuario = oAppContext.Security.CurrentUser.Name
            oFormaPago.Fecha = Date.Now
            oFormaPago.Status = True

            oFormaPago.Save()


            On Error Resume Next

            oFormaPago = Nothing
            oFormaPago = oCatalogoFormasPagoMgr.Load(EditBox1.Text, EditBox3.Text, "")

            EditBox1.Text = oFormaPago.ID
            EditBox2.Text = oFormaPago.Descripcion

            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else   'Opción Actualizar.


            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If

            Dim V1_strCodTipoVenta As String
            Dim Vl_strCodFormaPago As String

            Vl_strCodFormaPago = oFormaPago.ID
            V1_strCodTipoVenta = oFormaPago.VentaID


            oFormaPago.Descripcion = EditBox2.Text
            oFormaPago.Usuario = oAppContext.Security.CurrentUser.Name
            oFormaPago.Fecha = Date.Now
            oFormaPago.Status = True

            oFormaPago.Save()

            On Error Resume Next

            oFormaPago = Nothing
            oFormaPago = oCatalogoFormasPagoMgr.Load(Vl_strCodFormaPago, V1_strCodTipoVenta, "")

            EditBox1.Text = oFormaPago.ID
            EditBox3.Text = oFormaPago.VentaID
            EditBox2.Text = oFormaPago.Descripcion

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub



    Private Sub Sm_Eliminar()

        EditBox3.Focus()

        If (oFormaPago Is Nothing) Then
            MessageBox.Show("No ha sido seleccionado un Registro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If (MessageBox.Show("Se encuentra seguro de Eliminar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel) Then
            Exit Sub
        End If

        oCatalogoFormasPagoMgr.Delete(oFormaPago.ID, oFormaPago.VentaID)

        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Text = String.Empty
        EditBox3.Focus()
        oFormaPago = Nothing

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub



    Private Sub Sm_BuscarFormaPago(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False, Optional ByVal Actualizar As Boolean = False)

        Dim oCatalogoFormasPagoDG As New CatalogoFormasPagoDataGateway(oCatalogoFormasPagoMgr)

        '<Validación>
        If (oTipoVenta Is Nothing) Then
            'MsgBox("No ha sido seleccionado un Código Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")
            'EditBox3.Focus()

            'Exit Sub
        End If
        '</Validación>


        If ((Vpa_bolOpenRecordDialog = True) Or (EditBox1.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            'If EditBox3.Text <> String.Empty Then
            If EditBox3.Text.Trim <> String.Empty Then


                oOpenRecordDlg.CurrentView = New CatalogoFormasPagoOpenRecordDialogView(oTipoVenta.ID)

                oOpenRecordDlg.ShowDialog()

                If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                    On Error Resume Next

                    oFormaPago = Nothing
                    oFormaPago = oCatalogoFormasPagoMgr.Load(oOpenRecordDlg.Record.Item("CodFormasPago"), oTipoVenta.ID, "")

                    EditBox2.Text = oFormaPago.Descripcion
                    EditBox1.Text = oFormaPago.ID
                    EditBox3.Text = oFormaPago.VentaID

                End If

                'Else
                'MessageBox.Show("Introduzca PRIMERO un Código de Tipo de Venta ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'End If

            Else
                MsgBox("No ha sido seleccionado un Código Tipo de Venta. Seleccione uno de la lista porfavor!.", MsgBoxStyle.Exclamation, "DPTienda")
            End If


        Else

            On Error Resume Next

            oFormaPago = Nothing
            oFormaPago = oCatalogoFormasPagoMgr.Load(EditBox1.Text.Trim, EditBox3.Text.Trim, "")



            If Actualizar = False Then

                EditBox1.Text = oFormaPago.ID

                EditBox2.Text = oFormaPago.Descripcion

            End If



        End If


    End Sub


    Private Sub Sm_BuscarTipoVenta(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (EditBox3.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoTipoVentaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                Sm_Nuevo()
                On Error Resume Next

                oTipoVenta = Nothing
                oTipoVenta = oCatalogoTipoVentaMgr.Load(oOpenRecordDlg.Record.Item("CodTipoVenta"))

                EditBox3.Text = oTipoVenta.ID
                EditBox4.Text = oTipoVenta.Descripcion
                EditBox1.Focus()

            End If

        Else

            On Error Resume Next

            oTipoVenta = Nothing
            oTipoVenta = oCatalogoTipoVentaMgr.Load(EditBox3.Text.Trim)

            If oTipoVenta.ID = Nothing Then

                MessageBox.Show("No existe el código de venta especificado. Seleccione uno, usando la busqueda rapida.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                EditBox3.Text = String.Empty
                EditBox3.Focus()

            Else

                EditBox3.Text = oTipoVenta.ID
                EditBox4.Text = oTipoVenta.Descripcion
                EditBox1.Focus()
            End If

        End If

    End Sub

#End Region




#Region "Métodos Privados [Eventos]"

    Private Sub frmformadepago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oCatalogoFormasPagoMgr = New CatalogoFormasPagoManager(oAppContext)
        oCatalogoTipoVentaMgr = New CatalogoTipoVentaManager(oAppContext)

    End Sub



    Private Sub frmformadepago_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oFormaPago = Nothing

        oCatalogoFormasPagoMgr.dispose()
        oCatalogoFormasPagoMgr = Nothing

        oTipoVenta = Nothing

        oCatalogoTipoVentaMgr.dispose()
        oCatalogoTipoVentaMgr = Nothing

    End Sub



    'Menú and ToolsBar :
    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Nuevo()


            Case "menuArchivoGuardar"

                Sm_Guardar()


            Case "menuArchivoEliminar"

                Sm_Eliminar()


            Case "menuAyudaTema"


            Case "menuSalir"

                Me.Close()

        End Select

    End Sub



    'Botón Nuevo :
    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

        Sm_Nuevo()

    End Sub



    'Botón Guardar :
    Private Sub UiButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton2.Click

        If EditBox3.Text <> "" Then

            Sm_BuscarTipoVenta()
        Else
            MsgBox("No ha sido seleccionado un Código Tipo de Venta.", MsgBoxStyle.Exclamation, "DPTienda")

            Exit Sub

        End If

        If EditBox1.Text <> "" Then

            Sm_BuscarFormaPago(, True)

        Else

            MsgBox("No ha sido seleccionado un Código Forma de pago.", MsgBoxStyle.Exclamation, "DPTienda")

            Exit Sub

        End If


        Sm_Guardar()
        EditBox3.Focus()

    End Sub



    'Botón Eliminar :
    Private Sub UiButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton3.Click

        Sm_Eliminar()
        EditBox3.Focus()

    End Sub



    'Botón Buscar Forma de Pago:
    Private Sub EditBox1_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox1.ButtonClick

        Sm_BuscarFormaPago(True)

    End Sub



    'EditBox Código :
    Private Sub EditBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditBox1.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            Sm_BuscarFormaPago()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarFormaPago(True)

        End If

    End Sub



    'BotónTipoVenta Buscar :
    Private Sub editBox3_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBox3.ButtonClick

        Sm_BuscarTipoVenta(True)

    End Sub



    'EditBoxTipoVenta Código :
    Private Sub editBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditBox3.KeyDown

        If (e.KeyCode = Keys.Enter) Then

            Sm_BuscarTipoVenta()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_BuscarTipoVenta(True)

        End If

    End Sub

#End Region


    'Private Sub UiButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ClickButton As New frmBusqueda
    '    ClickButton.Show()
    'End Sub

    'Private Sub EditBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBox1.Click

    'End Sub


    


    

    'Private Sub EditBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBox3.Click

    'End Sub

    
    'Private Sub EditBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBox1.Click

    'End Sub


    'Private Sub EditBox3_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox3.CursorChanged
    '    Sm_BuscarTipoVenta()
    'End Sub

  

    '  Private Sub EditBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox3.LostFocus
    '
    '       If EditBox3.Text <> "" Then
    '
    '           ' MsgBox("No ha sido seleccionado un Código Tipo de Venta. Seleccione uno de la lista porfavor!.", MsgBoxStyle.Exclamation, "DPTienda")
    '
    '           Sm_BuscarTipoVenta()
    '
    '       End If
    '  End Sub

    ' Private Sub EditBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox1.LostFocus
    '
    '       If EditBox1.Text <> "" Then
    '
    '           ' MsgBox("No ha sido seleccionado un Código Forma de Pago. Seleccione uno de la lista porfavor!.", MsgBoxStyle.Exclamation, "DPTienda")
    '
    '           Sm_BuscarFormaPago()
    '
    '       End If
    '    End Sub

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub

    
    Private Sub frmformadepago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
