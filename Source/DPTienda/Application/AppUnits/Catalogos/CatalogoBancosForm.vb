Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU


Public Class CatalogoBancosForm
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
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents BottomRebar2 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar2 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar2 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoBancosForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar2 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.LeftRebar2 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar2 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Nothing
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 230)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(352, 0)
        Me.BottomRebar1.TabIndex = 4
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Nothing
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 230)
        Me.LeftRebar1.TabIndex = 5
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Nothing
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(352, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 230)
        Me.RightRebar1.TabIndex = 6
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar2
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuSalir, Me.menuArchivoNuevo, Me.menuAyudaTema})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("cf9dfe7c-4944-4d58-8b0c-6be55cb0eef9")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar2
        Me.UiCommandManager1.RightRebar = Me.RightRebar2
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        '
        'BottomRebar2
        '
        Me.BottomRebar2.CommandManager = Me.UiCommandManager1
        Me.BottomRebar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar2.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar2.Name = "BottomRebar2"
        Me.BottomRebar2.TabIndex = 0
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
        Me.UiCommandBar1.Size = New System.Drawing.Size(352, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Image = CType(resources.GetObject("menuArchivo1.Image"), System.Drawing.Image)
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Image = CType(resources.GetObject("menuAyuda1.Image"), System.Drawing.Image)
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuArchivoSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(110, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Image = CType(resources.GetObject("menuArchivoNuevo2.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Image = CType(resources.GetObject("menuAyudaTema2.Image"), System.Drawing.Image)
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "&Temas de Ayuda"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuArchivoSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "A&brir"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Ayu&da"
        '
        'LeftRebar2
        '
        Me.LeftRebar2.CommandManager = Me.UiCommandManager1
        Me.LeftRebar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar2.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar2.Name = "LeftRebar2"
        Me.LeftRebar2.TabIndex = 0
        '
        'RightRebar2
        '
        Me.RightRebar2.CommandManager = Me.UiCommandManager1
        Me.RightRebar2.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar2.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar2.Name = "RightRebar2"
        Me.RightRebar2.TabIndex = 0
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
        Me.TopRebar1.TabIndex = 7
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Bancos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(352, 180)
        Me.ExplorerBar1.TabIndex = 8
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.BackColor = System.Drawing.Color.Ivory
        Me.EditBox5.Enabled = False
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(120, 144)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(200, 22)
        Me.EditBox5.TabIndex = 10
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "CIE:"
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.BackColor = System.Drawing.Color.Ivory
        Me.EditBox4.Enabled = False
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(120, 120)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(216, 22)
        Me.EditBox4.TabIndex = 8
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ref. Tarj.:"
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.BackColor = System.Drawing.Color.Ivory
        Me.EditBox3.Enabled = False
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(120, 96)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(216, 22)
        Me.EditBox3.TabIndex = 6
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ref. Efvo.:"
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.BackColor = System.Drawing.Color.Ivory
        Me.EditBox2.Enabled = False
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(120, 72)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(200, 22)
        Me.EditBox2.TabIndex = 4
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
        Me.EditBox1.Location = New System.Drawing.Point(120, 48)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(112, 22)
        Me.EditBox1.TabIndex = 3
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'CatalogoBancosForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 230)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Controls.Add(Me.RightRebar1)
        Me.Controls.Add(Me.LeftRebar1)
        Me.Controls.Add(Me.BottomRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CatalogoBancosForm"
        Me.Text = "Catalogos Bancos"
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    Private oCatalogoBancosMgr As CatalogoBancosManager

    Private oBancos As Bancos

#End Region



#Region "Métodos Miembros"

    Private Function Fm_bolTxtValidar(Optional ByVal Vpa_strOpcion As String = "") As Boolean

        If (Vpa_strOpcion = "Guardar") Then

            EditBox1.Text = EditBox1.Text.Trim

            If (EditBox1.Text = String.Empty) Then
                MessageBox.Show("Debe especificar un Código de Banco", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EditBox1.Focus()
                Exit Function
            End If

        End If


        EditBox2.Text = EditBox2.Text.Trim

        If (EditBox2.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Descripción de Banco", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox2.Focus()
            Exit Function
        End If


        If (EditBox3.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Referencia de Efectivo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox3.Focus()
            Exit Function
        End If

        If (EditBox4.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Referencia de Tarjeta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox4.Focus()
            Exit Function
        End If

        If (EditBox5.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Referencia Bancaria", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox5.Focus()
            Exit Function
        End If

        Return True

    End Function



    Private Sub Sm_Nuevo()

        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Text = String.Empty
        EditBox4.Text = String.Empty
        EditBox5.Text = String.Empty

        EditBox1.Focus()

        On Error Resume Next
        oBancos = Nothing

    End Sub



    Private Sub Sm_Guardar()

        If (oBancos Is Nothing) Then   'Opción Guardar.

            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar("Guardar") = False) Then
                Exit Sub
            End If

            oBancos = oCatalogoBancosMgr.Create


            oBancos.ID = EditBox1.Text
            oBancos.Descripcion = EditBox2.Text
            oBancos.Usuario = oAppContext.Security.CurrentUser.Name
            oBancos.Fecha = Date.Now
            oBancos.Status = True
            oBancos.ReferEfectivo = EditBox3.Text
            oBancos.ReferTarjeta = EditBox4.Text
            oBancos.CIE = EditBox5.Text

            oBancos.Save()

            oBancos = oCatalogoBancosMgr.Load(EditBox1.Text)

            EditBox1.Text = oBancos.ID
            EditBox2.Text = oBancos.Descripcion
            EditBox3.Text = oBancos.ReferEfectivo
            EditBox4.Text = oBancos.ReferTarjeta
            EditBox5.Text = oBancos.CIE


            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else   'Opción Actualizar.

            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If

            Dim Vl_strCodBanco As String

            Vl_strCodBanco = oBancos.ID

            'obancos.ID = EditBox1.Text
            oBancos.Descripcion = EditBox2.Text
            oBancos.ReferEfectivo = EditBox3.Text
            oBancos.ReferTarjeta = EditBox4.Text
            oBancos.CIE = EditBox5.Text
            oBancos.Usuario = oAppContext.Security.CurrentUser.Name
            oBancos.Fecha = Date.Now
            oBancos.Status = True

            oBancos.Save()

            On Error Resume Next

            oBancos = Nothing
            oBancos = oCatalogoBancosMgr.Load(Vl_strCodBanco)

            EditBox1.Text = oBancos.ID
            EditBox2.Text = oBancos.Descripcion
            EditBox3.Text = oBancos.ReferEfectivo
            EditBox4.Text = oBancos.ReferTarjeta
            EditBox5.Text = oBancos.CIE


            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub



    Private Sub Sm_Eliminar()

        If (oBancos Is Nothing) Then
            MessageBox.Show("No ha sido seleccionado un Registro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox1.Focus()
            Exit Sub
        End If


        If (MessageBox.Show("Se encuentra seguro de Eliminar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If


        oCatalogoBancosMgr.Delete(oBancos.ID)

        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Text = String.Empty
        EditBox4.Text = String.Empty
        EditBox5.Text = String.Empty



        oBancos = Nothing

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'EditBox1.Focus()
    End Sub



    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If ((Vpa_bolOpenRecordDialog = True) Or (EditBox1.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoBancosOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oBancos = Nothing
                oBancos = oCatalogoBancosMgr.Load(oOpenRecordDlg.Record.Item("CodBanco"))

                EditBox1.Text = oBancos.ID
                EditBox2.Text = oBancos.Descripcion
                EditBox3.Text = oBancos.ReferEfectivo
                EditBox4.Text = oBancos.ReferTarjeta
                EditBox5.Text = oBancos.CIE

                EditBox1.Focus()
                EditBox1.SelectAll()

            End If

        Else


            EditBox2.Text = String.Empty
            EditBox3.Text = String.Empty
            EditBox4.Text = String.Empty
            EditBox5.Text = String.Empty


            On Error Resume Next

            oBancos = Nothing

            oBancos = oCatalogoBancosMgr.Load(EditBox1.Text.Trim)

            If Not (oBancos Is Nothing) Then

                EditBox1.Text = oBancos.ID
                EditBox2.Text = oBancos.Descripcion
                EditBox3.Text = oBancos.ReferEfectivo
                EditBox4.Text = oBancos.ReferTarjeta
                EditBox5.Text = oBancos.CIE


            Else

                oCatalogoBancosMgr.Create()
                EditBox2.Text = String.Empty
                EditBox3.Text = String.Empty
                EditBox4.Text = String.Empty
                EditBox5.Text = String.Empty


                oBancos.ID = EditBox1.Text

                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            EditBox1.Focus()
            EditBox1.SelectAll()

        End If

    End Sub


#End Region



#Region "Métodos Miembros [Eventos]"

    Private Sub CatalogoBancosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oCatalogoBancosMgr = New CatalogoBancosManager(oAppContext)

    End Sub



    Private Sub CatalogoBancosForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oBancos = Nothing

        oCatalogoBancosMgr.Dispose()
        oCatalogoBancosMgr = Nothing

    End Sub



    'Menú and ToolsBar :
    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Buscar(True)


            Case "menuArchivoGuardar"

                Sm_Guardar()


            Case "menuArchivoEliminar"

                Sm_Eliminar()


            Case "menuAyudaTema"


            Case "menuArchivoSalir"

                Me.Close()

        End Select

    End Sub



    'Botón Nuevo :
    ' Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

    '    Sm_Nuevo()

    'End Sub



    'Botón Guardar :
    'Private Sub UiButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton2.Click

    '   Sm_Guardar()

    'End Sub



    'Botón Eliminar :
    'Private Sub UiButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton3.Click

    '    Sm_Eliminar()

    '       EditBox1.Focus()

    '  End Sub



    'Botón Buscar :

    Private Sub EditBox1_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox1.ButtonClick

        Sm_Buscar(True)

    End Sub



    'EditBox Código :
    Private Sub EditBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditBox1.KeyDown


        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        ElseIf e.KeyCode = Keys.Enter Then

            Sm_Buscar()

        End If

    End Sub

#End Region

    Private Sub CatalogoBancosForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
