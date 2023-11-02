Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports Janus.Windows.GridEX

Public Class frmApartadosVigentes
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
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSair As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GrdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar3 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSair1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents ccmbDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccbHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApartadosVigentes))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar3 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuExportar2 = New Janus.Windows.UI.CommandBars.UICommand("menuExportar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuExportar1 = New Janus.Windows.UI.CommandBars.UICommand("menuExportar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSair1 = New Janus.Windows.UI.CommandBars.UICommand("menuSair")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuExportar = New Janus.Windows.UI.CommandBars.UICommand("menuExportar")
        Me.menuSair = New Janus.Windows.UI.CommandBars.UICommand("menuSair")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GrdTraspasos = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbCajas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.ccbHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2, Me.UiCommandBar3})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAbrir, Me.menuImprimir, Me.menuExportar, Me.menuSair, Me.menuAyuda, Me.menuAyudaTema})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("7b0bc5c1-88d9-43ef-a156-3f1a8d0f3d22")
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
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.AllowMerge = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar2.Key = "CommandBar1"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(728, 22)
        Me.UiCommandBar2.Text = "CommandBar1"
        Me.UiCommandBar2.Visible = False
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
        'UiCommandBar3
        '
        Me.UiCommandBar3.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar3.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar3.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir2, Me.Separator4, Me.menuImprimir2, Me.Separator5, Me.menuExportar2, Me.Separator6, Me.menuAyudaTema2})
        Me.UiCommandBar3.Key = "CommandBar2"
        Me.UiCommandBar3.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar3.Name = "UiCommandBar3"
        Me.UiCommandBar3.RowIndex = 1
        Me.UiCommandBar3.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar3.Size = New System.Drawing.Size(281, 28)
        Me.UiCommandBar3.Text = "CommandBar2"
        Me.UiCommandBar3.Visible = False
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
        'menuImprimir2
        '
        Me.menuImprimir2.Key = "menuImprimir"
        Me.menuImprimir2.Name = "menuImprimir2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuExportar2
        '
        Me.menuExportar2.Key = "menuExportar"
        Me.menuExportar2.Name = "menuExportar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator1, Me.menuImprimir1, Me.Separator2, Me.menuExportar1, Me.Separator3, Me.menuSair1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuImprimir1
        '
        Me.menuImprimir1.Key = "menuImprimir"
        Me.menuImprimir1.Name = "menuImprimir1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuExportar1
        '
        Me.menuExportar1.Key = "menuExportar"
        Me.menuExportar1.Name = "menuExportar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuSair1
        '
        Me.menuSair1.Key = "menuSair"
        Me.menuSair1.Name = "menuSair1"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "&Imprimir"
        '
        'menuExportar
        '
        Me.menuExportar.Image = CType(resources.GetObject("menuExportar.Image"), System.Drawing.Image)
        Me.menuExportar.Key = "menuExportar"
        Me.menuExportar.Name = "menuExportar"
        Me.menuExportar.Text = "&Exportar"
        '
        'menuSair
        '
        Me.menuSair.Image = CType(resources.GetObject("menuSair.Image"), System.Drawing.Image)
        Me.menuSair.Key = "menuSair"
        Me.menuSair.Name = "menuSair"
        Me.menuSair.Text = "&Salir"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "&Ayuda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Ay&uda"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2, Me.UiCommandBar3})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar3)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(728, 50)
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(32, 272)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 272)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(176, 272)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Salir"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(152, 272)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'GrdTraspasos
        '
        Me.GrdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.GrdTraspasos.DesignTimeLayout = GridEXLayout2
        Me.GrdTraspasos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GrdTraspasos.GroupByBoxVisible = False
        Me.GrdTraspasos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrdTraspasos.Location = New System.Drawing.Point(16, 96)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(704, 160)
        Me.GrdTraspasos.TabIndex = 4
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Nothing
        Me.UiCommandBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(736, 24)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.cmbCajas)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.ccbHasta)
        Me.ExplorerBar1.Controls.Add(Me.ccmbDesde)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(728, 299)
        Me.ExplorerBar1.TabIndex = 2
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbCajas
        '
        Me.cmbCajas.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbCajas.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbCajas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbCajas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbCajas.DesignTimeLayout = GridEXLayout1
        Me.cmbCajas.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.Location = New System.Drawing.Point(72, 24)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.ReadOnly = True
        Me.cmbCajas.Size = New System.Drawing.Size(128, 22)
        Me.cmbCajas.TabIndex = 139
        Me.cmbCajas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCajas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 23)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Caja:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Exportar"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(272, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "F5"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Desde"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(408, 56)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ccbHasta
        '
        '
        '
        '
        Me.ccbHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccbHasta.Location = New System.Drawing.Point(264, 56)
        Me.ccbHasta.Name = "ccbHasta"
        Me.ccbHasta.Size = New System.Drawing.Size(128, 23)
        Me.ccbHasta.TabIndex = 2
        Me.ccbHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccmbDesde
        '
        '
        '
        '
        Me.ccmbDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbDesde.Location = New System.Drawing.Point(72, 56)
        Me.ccmbDesde.Name = "ccmbDesde"
        Me.ccmbDesde.Size = New System.Drawing.Size(128, 23)
        Me.ccmbDesde.TabIndex = 1
        Me.ccmbDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'frmApartadosVigentes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 349)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.KeyPreview = True
        Me.Name = "frmApartadosVigentes"
        Me.Text = "Apartados en Detalle"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private dsTraspasos As DataSet
    Private oContratosMgr As ContratoManager
    Private oCajasMgr As CatalogoCajaManager
    Private dsCajas As DataSet


#Region "Eventos Controles"

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "menuAbrir"

            Case "menuSalir"

                Me.Close()

            Case "menuImprimir"
                Me.Cursor = Cursors.WaitCursor
                ActionPreview()
                Me.Cursor = Cursors.Default

            Case "menuExportar"
                'ExpExcel()
                Me.Cursor = Cursors.WaitCursor
                ExportaApartadosDetalle()
                Me.Cursor = Cursors.Default

        End Select
    End Sub

    Private Sub ccbHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ccbHasta.ValueChanged

        Me.ccmbDesde.MaxDate = ccbHasta.Value

    End Sub

    Private Sub frmApartadosVigentes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Me.ccmbDesde.MaxDate = ccbHasta.Value
        ccbHasta.MinDate = Me.ccmbDesde.Value

        oContratosMgr = New ContratoManager(oAppContext)

        oCajasMgr = New CatalogoCajaManager(oAppContext)
        dsCajas = oCajasMgr.GetAll(False).Copy
        Dim oRow As DataRow = dsCajas.Tables(0).NewRow

        oRow("CodCaja") = "Td"
        oRow("Descripcion") = "Todas"
        Me.dsCajas.Tables(0).Rows.Add(oRow)



        With Me.cmbCajas

            .DataSource = dsCajas
            .DataMember = dsCajas.Tables(0).TableName
            .DropDownList.Columns.Add("CodCaja")
            .DropDownList.Columns.Add("Descripcion")
            '.DropDownList.Columns("CodCaja").Visible = False
            .DropDownList.Columns("CodCaja").DataMember = "CodCaja"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("Descripcion").Width = 170

            .DisplayMember = "Descripcion"
            .ValueMember = "CodCaja"

            .Refresh()

        End With
        cmbCajas.Value = oAppContext.ApplicationConfiguration.NoCaja

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        Me.Cursor = Cursors.WaitCursor

        If Not Me.cmbCajas.Text = String.Empty Then

            Me.dsTraspasos = oContratosMgr.ContratoDetalleSel(Me.ccmbDesde.Value, Me.ccbHasta.Value, Me.cmbCajas.Value)

            If dsTraspasos.Tables(0).Rows.Count > 0 Then

                Me.GrdTraspasos.DataSource = dsTraspasos
                Me.GrdTraspasos.DataMember = dsTraspasos.Tables(0).TableName
                'MessageBox.Show("Listo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                MessageBox.Show("Los datos proporcionados no arrojaron resultados", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else

            MessageBox.Show("Seleccione Caja", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmApartadosVigentes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F5 Then

            Me.Cursor = Cursors.WaitCursor
            ExportaApartadosDetalle()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub GrdTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasos.KeyDown
        If e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.Enter Then

            ccmbDesde.Focus()

        End If
    End Sub

#End Region

#Region "Private Sub"

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub ExportaApartadosDetalle()

        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty
        Dim isExcelOpen As Boolean = False

        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer 'counter

        Dim oRow As DataRow

        On Error Resume Next

        xlapp = GetObject(, "Excel.Application")

        If xlapp Is Nothing Then
            xlapp = CreateObject("Excel.Application")
            If xlapp Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Auditoría de Retiros")
                Exit Sub
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = "Auditoria de Retiros"

        wsxl.PageSetup.Orientation = 2
        '****************************************
        'HOJA DE CALCULO APARTADOS EN DETALLE
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE APARTADOS EN DETALLE DE LA CAJA No." & Me.cmbCajas.Value
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:M1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:M1").BorderAround(, 2, 0, )
        wsxl.Range("A1:M1").HorizontalAlignment = 3

        If Me.cmbCajas.Value = "Td" Then
            wsxl.Cells(2, 1).Value = "Caja #: Todas"
        Else
            wsxl.Cells(2, 1).Value = "Caja #: " & Me.cmbCajas.Value
        End If
        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 13).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 13).Font.Size = 10
        wsxl.Cells(2, 13).Font.Bold = True

        wsxl.Cells(3, 1).Value = "De : " & Format(Me.ccmbDesde.Value, "dd/MM/yyyy") & " Al : " & Format(Me.ccbHasta.Value, "dd/MM/yyyy")
        wsxl.Cells(3, 1).Font.Size = 10
        wsxl.Cells(3, 1).Font.Bold = True
        wsxl.Range("A3:M3").Merge()
        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:M4").Merge()
        wsxl.Range("A3:M4").HorizontalAlignment = 3

        'Encabezado

        wsxl.Cells(6, 1).Value = "Folio"
        wsxl.Columns(1).AutoFitColumns()

        wsxl.Cells(6, 2).Value = "Descripcion"
        wsxl.Columns(2).AutoFitColumns()

        wsxl.Cells(6, 3).Value = "Cantidad"
        wsxl.Columns(3).AutoFitColumns()

        wsxl.Cells(6, 4).Value = "Código"
        wsxl.Columns(4).AutoFitColumns()

        wsxl.Cells(6, 5).Value = "Talla"
        wsxl.Columns(5).AutoFitColumns()

        wsxl.Cells(6, 6).Value = "PrecioUni"
        wsxl.Columns(6).AutoFitColumns()

        wsxl.Cells(6, 7).Value = "Importe"
        wsxl.Columns(7).AutoFitColumns()

        wsxl.Cells(6, 8).Value = "Desc"
        wsxl.Columns(8).AutoFitColumns()

        wsxl.Cells(6, 9).Value = "CantDesc"
        wsxl.Columns(9).AutoFitColumns()

        wsxl.Cells(6, 10).Value = "Vendedor"
        wsxl.Columns(10).AutoFitColumns()

        wsxl.Cells(6, 11).Value = "CodCliente"
        wsxl.Columns(11).AutoFitColumns()

        wsxl.Cells(6, 12).Value = "Abonos"
        wsxl.Columns(12).AutoFitColumns()

        wsxl.Cells(6, 13).Value = "Saldo"
        wsxl.Columns(13).AutoFitColumns()

        '' Fin Encabezado

        wsxl.Range("A6:M6").Font.Bold = True
        wsxl.Range("A6:M6").HorizontalAlignment = 3
        wsxl.Range("A6:M6").Font.Size = 8
        wsxl.Range("A6:M6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:M6").BorderAround(, 2, 0, )

        intRow = 0

        Dim i As Integer = 1

        For Each objRow As DataRow In Me.dsTraspasos.Tables(0).Rows


            '' Asignar los valores de los registros a las celdas

            wsxl.Cells(6 + i, 1).Value = objRow.Item("FolioApartado")
            wsxl.Cells(6 + i, 2) = "'" & objRow.Item("Descripcion")
            wsxl.Cells(6 + i, 3).Value = objRow.Item("Cantidad")
            wsxl.Cells(6 + i, 4) = "'" & objRow.Item("CodArticulo")
            wsxl.Cells(6 + i, 5).value = objRow.Item("Numero")
            wsxl.Cells(6 + i, 6).Value = Format(objRow.Item("Precio"), "c")
            wsxl.Cells(6 + i, 7).Value = Format(objRow.Item("Total"), "c")
            wsxl.Cells(6 + i, 8).Value = objRow.Item("Descuento")
            wsxl.Cells(6 + i, 9).Value = Format(objRow.Item("TDescuento"), "c")
            wsxl.Cells(6 + i, 10) = "'" & objRow.Item("CodVendedor")
            wsxl.Cells(6 + i, 11).Value = objRow.Item("ClienteID")
            wsxl.Cells(6 + i, 12).Value = Format(objRow.Item("Abonos"), "c")
            wsxl.Cells(6 + i, 13).value = Format(objRow.Item("Saldo"), "c")

            '' Avanzamos una fila

            i += 1

        Next

        wsxl.Cells(8 + i, 2).Value = "TOTAL APARTADOS :"
        wsxl.Cells(8 + i, 3).Value = Me.dsTraspasos.Tables(0).Rows.Count

        For i = 1 To 13
            wsxl.Columns(i).AutoFitColumns()
        Next


        wsxl.PageSetup.FitToPagesWide = 1
        wsxl.PageSetup.FitToPagesTall = 1




        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
        SaveDialog.DefaultExt = "*.xls"
        SaveDialog.Filter = "(*.xls)|*.xls"
        If SaveDialog.ShowDialog = DialogResult.OK Then
            wbxl.SaveAs(SaveDialog.FileName)
            MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Repote Notas de Crédito")
        End If

        wbxl.Close()
        wsxl = Nothing
        xlapp.Quit()
        xlapp = Nothing


        KillExcel()

    End Sub

    Private Sub ActionPreview()
        Try

            If Not Me.dsTraspasos Is Nothing Then

                Dim oARReporte As New rptApartadosVigentes(Me.dsTraspasos)
                Dim oReportViewer As New ReportViewerForm



                oARReporte.Document.Name = "Apartados Vigentes"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()



                Try

                    oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception


            Throw ex


        End Try



    End Sub

#End Region

End Class
