
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas


Public Class CatalogoCajaForm
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
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaAcerca As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVer As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVerBarra As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuVerBarra1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiButton3 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents menuArchivoSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoCajaForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaAcerca = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaAcerca")
        Me.menuVer = New Janus.Windows.UI.CommandBars.UICommand("menuVer")
        Me.menuVerBarra1 = New Janus.Windows.UI.CommandBars.UICommand("menuVerBarra")
        Me.menuVerBarra = New Janus.Windows.UI.CommandBars.UICommand("menuVerBarra")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.UiButton3 = New Janus.Windows.EditControls.UIButton
        Me.UiButton2 = New Janus.Windows.EditControls.UIButton
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLabel1 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuArchivoSalir, Me.menuArchivoNuevo, Me.menuAyudaTema, Me.menuAyudaAcerca, Me.menuVer, Me.menuVerBarra, Me.menuArchivoGuardar, Me.menuArchivoEliminar})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("12b4905c-9335-4eab-91fb-e021bb3f166f")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1, Me.menuArchivoSalir2})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(416, 24)
        Me.UiCommandBar1.TabIndex = 0
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
        Me.menuAyuda1.Text = "Ay&uda"
        '
        'menuArchivoSalir2
        '
        Me.menuArchivoSalir2.Key = "menuArchivoSalir"
        Me.menuArchivoSalir2.Name = "menuArchivoSalir2"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator2, Me.menuArchivoGuardar2, Me.Separator6, Me.menuArchivoEliminar2, Me.Separator5, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(272, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
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
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
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
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        Me.menuAyudaTema2.Text = "Ayu&da"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator3, Me.menuArchivoGuardar1, Me.Separator4, Me.menuArchivoEliminar1, Me.Separator7})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        Me.menuArchivoNuevo1.Text = "&Nuevo"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1, Me.Separator1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
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
        'menuAyudaAcerca
        '
        Me.menuAyudaAcerca.Key = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Name = "menuAyudaAcerca"
        Me.menuAyudaAcerca.Text = "Acerca de..."
        '
        'menuVer
        '
        Me.menuVer.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuVerBarra1})
        Me.menuVer.Key = "menuVer"
        Me.menuVer.Name = "menuVer"
        Me.menuVer.Text = "&Barra de Menu"
        '
        'menuVerBarra1
        '
        Me.menuVerBarra1.Image = CType(resources.GetObject("menuVerBarra1.Image"), System.Drawing.Image)
        Me.menuVerBarra1.Key = "menuVerBarra"
        Me.menuVerBarra1.Name = "menuVerBarra1"
        '
        'menuVerBarra
        '
        Me.menuVerBarra.Key = "menuVerBarra"
        Me.menuVerBarra.Name = "menuVerBarra"
        Me.menuVerBarra.Text = "&Barra de Menu"
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
        Me.TopRebar1.Size = New System.Drawing.Size(416, 50)
        Me.TopRebar1.TabIndex = 0
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.Sunken
        Me.ExplorerBar1.Controls.Add(Me.EditBox6)
        Me.ExplorerBar1.Controls.Add(Me.EditBox5)
        Me.ExplorerBar1.Controls.Add(Me.EditBox4)
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.UiButton3)
        Me.ExplorerBar1.Controls.Add(Me.UiButton2)
        Me.ExplorerBar1.Controls.Add(Me.UiButton1)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales de Caja"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(416, 256)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.Location = New System.Drawing.Point(160, 166)
        Me.EditBox6.MaxLength = 4
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(104, 23)
        Me.EditBox6.TabIndex = 5
        Me.EditBox6.Text = "0"
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EditBox6.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Location = New System.Drawing.Point(160, 142)
        Me.EditBox5.MaxLength = 4
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(104, 23)
        Me.EditBox5.TabIndex = 4
        Me.EditBox5.Text = "0"
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EditBox5.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Location = New System.Drawing.Point(160, 118)
        Me.EditBox4.MaxLength = 4
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.Size = New System.Drawing.Size(104, 23)
        Me.EditBox4.TabIndex = 3
        Me.EditBox4.Text = "0"
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EditBox4.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.Location = New System.Drawing.Point(160, 94)
        Me.EditBox3.MaxLength = 4
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(104, 23)
        Me.EditBox3.TabIndex = 2
        Me.EditBox3.Text = "0"
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.EditBox3.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 23)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Folio Nota de Credito:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 23)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Folio de Abono:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Folio de Factura:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Folio de Apartado:"
        '
        'UiButton3
        '
        Me.UiButton3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton3.Location = New System.Drawing.Point(256, 216)
        Me.UiButton3.Name = "UiButton3"
        Me.UiButton3.Size = New System.Drawing.Size(75, 23)
        Me.UiButton3.TabIndex = 8
        Me.UiButton3.Text = "Eliminar"
        Me.UiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'UiButton2
        '
        Me.UiButton2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton2.Location = New System.Drawing.Point(171, 216)
        Me.UiButton2.Name = "UiButton2"
        Me.UiButton2.Size = New System.Drawing.Size(75, 23)
        Me.UiButton2.TabIndex = 7
        Me.UiButton2.Text = "Guardar"
        Me.UiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'UiButton1
        '
        Me.UiButton1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(88, 216)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(75, 23)
        Me.UiButton1.TabIndex = 6
        Me.UiButton1.Text = "Nuevo"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.BackColor = System.Drawing.Color.White
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(160, 71)
        Me.EditBox2.MaxLength = 30
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(176, 22)
        Me.EditBox2.TabIndex = 1
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.ButtonImage = CType(resources.GetObject("EditBox1.ButtonImage"), System.Drawing.Image)
        Me.EditBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox1.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Flat
        Me.EditBox1.ControlStyle.ScrollBarColor = System.Drawing.SystemColors.Control
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(160, 48)
        Me.EditBox1.MaxLength = 2
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(104, 22)
        Me.EditBox1.TabIndex = 0
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descripcion:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Codigo:"
        '
        'lblLabel1
        '
        Me.lblLabel1.Location = New System.Drawing.Point(408, 72)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.TabIndex = 17
        Me.lblLabel1.Text = "Label3"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CatalogoCajaForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(416, 306)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(424, 340)
        Me.MinimumSize = New System.Drawing.Size(424, 240)
        Me.Name = "CatalogoCajaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Caja"
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables Miembros"

    Private oCatalogoCajaMgr As CatalogoCajaManager

    Private oCaja As Caja

    Private caja As String = String.Empty

    Private bandera As String = "0"

    Private banderatab As Boolean = True

    Private banderaprovider As Boolean = True


#End Region



#Region "Métodos Miembros"

    Private Function Fm_bolTxtValidar(Optional ByVal Vpa_strOpcion As String = "") As Boolean

        If (Vpa_strOpcion = "Guardar") Then

            EditBox1.Text = EditBox1.Text.Trim

            If (EditBox1.Text = String.Empty) Then
                MessageBox.Show("Debe especificar un Código de Caja", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                EditBox1.Focus()
                Exit Function
            End If

        End If


        EditBox2.Text = EditBox2.Text.Trim

        If (EditBox2.Text.Trim = String.Empty) Then
            MessageBox.Show("Debe especificar una Descripción de Caja", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox2.Focus()
            Exit Function
        End If


        If (EditBox3.Value = 0) Then
            MessageBox.Show("Debe especificar una Folio de Factura", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox3.Focus()
            Exit Function
        End If

        If (EditBox4.Value = 0) Then
            MessageBox.Show("Debe especificar un Folio de Apartado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox4.Focus()
            Exit Function
        End If

        If (EditBox5.Value = 0) Then
            MessageBox.Show("Debe especificar un Folio Nota de Credito", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox5.Focus()
            Exit Function
        End If

        If (EditBox6.Value = 0) Then
            MessageBox.Show("Debe especificar un Folio Nota de Abono", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox6.Focus()
            Exit Function
        End If

        Return True

    End Function



    Private Sub Sm_Nuevo()
        banderaprovider = False
        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Value = 0
        EditBox4.Value = 0
        EditBox5.Value = 0
        EditBox6.Value = 0

        bandera = "0"
        banderatab = True
        EditBox1.Focus()
        On Error Resume Next
        oCaja = Nothing

        Me.ErrorProvider1.SetError(EditBox1, "")
        Me.ErrorProvider1.SetError(EditBox2, "")
        Me.ErrorProvider1.SetError(EditBox3, "")
        Me.ErrorProvider1.SetError(EditBox4, "")
        Me.ErrorProvider1.SetError(EditBox5, "")
        Me.ErrorProvider1.SetError(EditBox6, "")

        banderaprovider = True
    End Sub



    Private Sub Sm_Guardar()


        If (oCaja Is Nothing) Then   'Opción Guardar.

            If (MessageBox.Show("Se encuentra seguro de Guardar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar("Guardar") = False) Then
                Exit Sub
            End If

            oCaja = oCatalogoCajaMgr.Create


            oCaja.ID = EditBox1.Text
            oCaja.Descripcion = EditBox2.Text
            oCaja.Usuario = oAppContext.Security.CurrentUser.Name
            oCaja.Fecha = Date.Now
            oCaja.Status = True
            oCaja.FolioFactura = EditBox3.Value
            oCaja.FolioApartado = EditBox4.Value
            oCaja.FolioNotaCredito = EditBox5.Value
            oCaja.FolioAbono = EditBox6.Value


            oCaja.Save()

            oCaja = oCatalogoCajaMgr.Load(EditBox1.Text)

            EditBox1.Text = oCaja.ID
            EditBox2.Text = oCaja.Descripcion
            EditBox3.Value = oCaja.FolioFactura
            EditBox4.Value = oCaja.FolioApartado
            EditBox5.Value = oCaja.FolioNotaCredito
            EditBox6.Value = oCaja.FolioAbono

            MessageBox.Show("La información ha sido Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else   'Opción Actualizar.

            If (MessageBox.Show("Se encuentra seguro de Actualizar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
                Exit Sub
            End If


            If (Fm_bolTxtValidar() = False) Then
                Exit Sub
            End If

            Dim Vl_strCodCaja As String

            Vl_strCodCaja = oCaja.ID

            'oCaja.ID = EditBox1.Text
            oCaja.Descripcion = EditBox2.Text
            oCaja.FolioFactura = EditBox3.Value
            oCaja.FolioApartado = EditBox4.Value
            oCaja.FolioNotaCredito = EditBox5.Value
            oCaja.FolioAbono = EditBox6.Value
            oCaja.Usuario = oAppContext.Security.CurrentUser.Name
            oCaja.Fecha = Date.Now
            oCaja.Status = True

            oCaja.Save()

            On Error Resume Next

            oCaja = Nothing
            oCaja = oCatalogoCajaMgr.Load(Vl_strCodCaja)

            EditBox1.Text = oCaja.ID
            EditBox2.Text = oCaja.Descripcion
            EditBox3.Value = oCaja.FolioFactura
            EditBox4.Value = oCaja.FolioApartado
            EditBox5.Value = oCaja.FolioNotaCredito
            EditBox6.Value = oCaja.FolioAbono

            MessageBox.Show("La información ha sido Actualizada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub



    Private Sub Sm_Eliminar()

        If (oCaja Is Nothing) Then
            MessageBox.Show("No ha sido seleccionado un Registro", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EditBox1.Focus()
            Exit Sub
        End If


        If (MessageBox.Show("Se encuentra seguro de Eliminar la información Actual", "DPTienda", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel) Then
            Exit Sub
        End If


        oCatalogoCajaMgr.Delete(oCaja.ID)

        EditBox1.Text = String.Empty
        EditBox2.Text = String.Empty
        EditBox3.Value = 0
        EditBox4.Value = 0
        EditBox5.Value = 0
        EditBox6.Value = 0



        oCaja = Nothing

        MessageBox.Show("La información ha sido Eliminada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'EditBox1.Focus()
    End Sub



    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)


        If ((Vpa_bolOpenRecordDialog = True) Or (EditBox1.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oCaja = Nothing
                oCaja = oCatalogoCajaMgr.Load(oOpenRecordDlg.Record.Item("CodCaja"))

                EditBox1.Text = oCaja.ID
                EditBox2.Text = oCaja.Descripcion
                EditBox3.Value = oCaja.FolioFactura
                EditBox4.Value = oCaja.FolioApartado
                EditBox5.Value = oCaja.FolioNotaCredito
                EditBox6.Value = oCaja.FolioAbono
                EditBox1.Focus()
                EditBox1.SelectAll()

            End If

        Else


            

            On Error Resume Next

            oCaja = Nothing

            oCaja = oCatalogoCajaMgr.Load(EditBox1.Text.Trim)

            If Not (oCaja Is Nothing) Then

                EditBox1.Text = oCaja.ID
                EditBox2.Text = oCaja.Descripcion
                EditBox3.Value = oCaja.FolioFactura
                EditBox4.Value = oCaja.FolioApartado
                EditBox5.Value = oCaja.FolioNotaCredito
                EditBox6.Value = oCaja.FolioAbono
                EditBox1.Focus()
                EditBox1.SelectAll()
            Else

                oCatalogoCajaMgr.Create()

                oCaja.ID = EditBox1.Text

                If Not (bandera = EditBox1.Text) Then

                    MessageBox.Show("Código no existente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If MessageBox.Show("¿Desea registrarlo?", "DPTienda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        banderatab = False
                        EditBox2.Focus()
                        oCaja = Nothing
                    Else
                        EditBox1.Focus()
                    End If

                    EditBox2.Text = String.Empty
                    EditBox3.Value = 0
                    EditBox4.Value = 0
                    EditBox5.Value = 0
                    EditBox6.Value = 0

                End If
                bandera = EditBox1.Text

        End If

        End If

    End Sub

    Private Sub validaMayorCero(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If banderaprovider Then
                If Not CType(sender.text, Integer) > 0 Then
                    Me.ErrorProvider1.SetError(sender, "El folio debe ser mayor a 0")
                    e.Cancel = True
                Else
                    Me.ErrorProvider1.SetError(sender, "")
                End If
            End If
            
        Catch ex As Exception
            Me.ErrorProvider1.SetError(sender, "El folio debe contener solo números")
            e.Cancel = True
        End Try
        
    End Sub


#End Region



#Region "Métodos Miembros [Eventos]"

    Private Sub CatalogoCajaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        oCatalogoCajaMgr = New CatalogoCajaManager(oAppContext)


    End Sub



    Private Sub CatalogoCajaForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        oCaja = Nothing

        oCatalogoCajaMgr.dispose()
        oCatalogoCajaMgr = Nothing

    End Sub



    'Menú and ToolsBar :
    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoNuevo"

                Sm_Nuevo()


            Case "menuArchivoGuardar"

                Sm_Guardar()
                EditBox1.Focus()

            Case "menuArchivoEliminar"

                Sm_Eliminar()
                Sm_Nuevo()

            Case "menuAyudaTema"


            Case "menuArchivoSalir"

                Me.Close()

        End Select

    End Sub



    'Botón Nuevo :
    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click

        Sm_Nuevo()

    End Sub



    'Botón Guardar :
    Private Sub UiButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton2.Click

        Sm_Guardar()
        EditBox1.Focus()

    End Sub



    'Botón Eliminar :
    Private Sub UiButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton3.Click

        Sm_Eliminar()
        Sm_Nuevo()

    End Sub



    'Botón Buscar :
    Private Sub EditBox1_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBox1.ButtonClick

        Sm_Buscar(True)

    End Sub



    'EditBox Código :
    Private Sub EditBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditBox1.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        ElseIf (e.KeyCode = Keys.Enter) Then
           
            Sm_Buscar()

        End If

    End Sub


    Private Sub EditBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox1.Validating

        If banderatab Then
            If EditBox1.Text <> String.Empty Then

                Sm_Buscar()

            End If

        End If
    End Sub

    Private Sub EditBox3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox3.Validating
        validaMayorCero(sender, e)
    End Sub

    Private Sub EditBox4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox4.Validating
        validaMayorCero(sender, e)
    End Sub

    Private Sub EditBox5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox5.Validating
        validaMayorCero(sender, e)
    End Sub

    Private Sub EditBox6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox6.Validating
        validaMayorCero(sender, e)
    End Sub

    Private Sub EditBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EditBox2.Validating

        If banderaprovider Then
            If EditBox2.Text = String.Empty Then
                Me.ErrorProvider1.SetError(sender, "Capturar descripción")
                e.Cancel = True
            Else
                Me.ErrorProvider1.SetError(sender, "")
            End If
        End If
        
    End Sub

#End Region


    
    Private Sub CatalogoCajaForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
