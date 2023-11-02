Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmTraspasosPendientes
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
    Friend WithEvents GrdTraspasos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mwnuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents mwnuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuExportar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nbTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasosPendientes))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nbTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GrdTraspasos = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
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
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuExportar1 = New Janus.Windows.UI.CommandBars.UICommand("menuExportar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.mwnuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("mwnuSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.mwnuSalir = New Janus.Windows.UI.CommandBars.UICommand("mwnuSalir")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuExportar = New Janus.Windows.UI.CommandBars.UICommand("menuExportar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.nbTotal)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.GrdTraspasos)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(736, 251)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(272, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 23)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Exportar"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(248, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 23)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "F5"
        '
        'nbTotal
        '
        Me.nbTotal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotal.BackColor = System.Drawing.Color.Ivory
        Me.nbTotal.Location = New System.Drawing.Point(128, 184)
        Me.nbTotal.Name = "nbTotal"
        Me.nbTotal.ReadOnly = True
        Me.nbTotal.Size = New System.Drawing.Size(88, 23)
        Me.nbTotal.TabIndex = 126
        Me.nbTotal.Text = "0"
        Me.nbTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Total Traspasos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(32, 224)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 23)
        Me.Label22.TabIndex = 124
        Me.Label22.Text = "Imprimir"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 224)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "F9"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(176, 224)
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
        Me.Label13.Location = New System.Drawing.Point(152, 224)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 23)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Esc"
        '
        'GrdTraspasos
        '
        Me.GrdTraspasos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdTraspasos.DesignTimeLayout = GridEXLayout1
        Me.GrdTraspasos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdTraspasos.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GrdTraspasos.GroupByBoxVisible = False
        Me.GrdTraspasos.HeaderFormatStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrdTraspasos.Location = New System.Drawing.Point(16, 16)
        Me.GrdTraspasos.Name = "GrdTraspasos"
        Me.GrdTraspasos.Size = New System.Drawing.Size(704, 160)
        Me.GrdTraspasos.TabIndex = 7
        Me.GrdTraspasos.TableSpacing = 7
        Me.GrdTraspasos.TabStop = False
        Me.GrdTraspasos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAbrir, Me.mwnuSalir, Me.menuAyuda, Me.menuAyudaTema, Me.menuImprimir, Me.menuExportar})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("3dbd2a55-9f33-4426-a5a0-5425bb40e148")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(736, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Visible = False
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
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir2, Me.Separator4, Me.menuImprimir2, Me.Separator5, Me.menuExportar2, Me.Separator6, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(281, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        Me.UiCommandBar2.Visible = False
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
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator1, Me.menuImprimir1, Me.Separator3, Me.menuExportar1, Me.Separator2, Me.mwnuSalir1})
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
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuExportar1
        '
        Me.menuExportar1.Key = "menuExportar"
        Me.menuExportar1.Name = "menuExportar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'mwnuSalir1
        '
        Me.mwnuSalir1.Key = "mwnuSalir"
        Me.mwnuSalir1.Name = "mwnuSalir1"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'mwnuSalir
        '
        Me.mwnuSalir.Image = CType(resources.GetObject("mwnuSalir.Image"), System.Drawing.Image)
        Me.mwnuSalir.Key = "mwnuSalir"
        Me.mwnuSalir.Name = "mwnuSalir"
        Me.mwnuSalir.Text = "&Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(736, 50)
        Me.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmTraspasosPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(736, 301)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.KeyPreview = True
        Me.Name = "frmTraspasosPendientes"
        Me.Text = "Traspasos Pendientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.GrdTraspasos, System.ComponentModel.ISupportInitialize).EndInit()
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

    Dim dsTraspasos As DataTable
    Dim oTraspasosEntradaMgr As TraspasosEntradaManager


#Region "Eventos Controles"

    Private Sub frmTraspasosPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.Cursor = Cursors.WaitCursor
        oTraspasosEntradaMgr = New TraspasosEntradaManager(oAppContext)
        sm_Abrir()
        Me.Cursor = Cursors.Default


    End Sub

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
                Me.Cursor = Cursors.WaitCursor
                ExportaTraspasos()
                Me.Cursor = Cursors.Default

        End Select
    End Sub

    Private Sub frmTraspasosPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.Close()

        ElseIf e.KeyCode = Keys.F9 Then

            Me.Cursor = Cursors.WaitCursor
            ActionPreview()
            Me.Cursor = Cursors.Default

        ElseIf e.KeyCode = Keys.F5 Then
            Me.Cursor = Cursors.WaitCursor
            ExportaTraspasos()
            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub GrdTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTraspasos.KeyDown
        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

#End Region

#Region "Privare Sub"


    Private Sub sm_Abrir()

        Try
            'dsTraspasos = oTraspasosEntradaMgr.SelectAllPendientes

            'If Not dsTraspasos Is Nothing Then


            '    ' Me.dsTraspasos.Tables(0).Columns("Cantidad").DataType = GetType(System.Int32)

            '    Me.GrdTraspasos.DataSource = dsTraspasos
            '    Me.GrdTraspasos.DataMember = dsTraspasos.Tables(0).TableName

            '    Me.nbTotal.Value = dsTraspasos.Tables(0).Rows.Count

            'Else

            '    MessageBox.Show("No se encontraron traspasos pendientes", "DPTIenda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'End If



            Sm_BuscarTraspasos()


        Catch ex As Exception

            Throw ex

        End Try



    End Sub

    Private Sub Sm_BuscarTraspasos()

        Dim dtTraspasoEntrada As DataTable
        Dim datFromDate As Date
        Dim datToDate As Date


        With GrdTraspasos

            Dim oSap As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            'consulta entre la fecha de hoy 1000 dias antes
            dsTraspasos = oSap.Read_TraspasosEspera(Date.Today.AddDays(-370), Date.Today, "", "S", oConfigCierreFI.RecibirParcialmente)
            If (dsTraspasos.Rows.Count = 0) Then

                .DataSource = Nothing

                MsgBox("No se tienen Traspasos pendientes.", MsgBoxStyle.Exclamation, "DPTienda")
                Exit Sub
            Else
                Me.nbTotal.Value = dsTraspasos.Rows.Count
            End If


            .DataSource = dsTraspasos
            .RetrieveStructure()

        End With

    End Sub

    Private Sub ActionPreview()
        Try

            If Not Me.dsTraspasos Is Nothing Then

                Dim oARReporte As New rptReporteTraspasosPendientes(Me.dsTraspasos)
                Dim oReportViewer As New ReportViewerForm



                oARReporte.Document.Name = "Traspasos Pendientes"
                oARReporte.Run()

                oReportViewer.Report = oARReporte
                oReportViewer.Show()



                Try

                    'oARReporte.Document.Print(True, True)

                Catch ex As Exception

                    Throw ex

                End Try

            End If

        Catch ex As Exception


            Throw ex


        End Try



    End Sub

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

    Private Sub ExportaTraspasos()

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
        wsxl.Name = "Traspasos Pendientes"

        '****************************************
        'HOJA DE CALCULO TRASPASOS PENDIENTES
        '****************************************
        wsxl.Cells(1, 1).Value = "REPORTE DE TRASPASOS PENDIENTES"
        wsxl.Cells(1, 1).Font.Bold = True
        wsxl.Cells(1, 1).Font.Size = 12

        wsxl.Range("A1:H1").Merge()
        wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        wsxl.Range("A1:H1").BorderAround(, 2, 0, )
        wsxl.Range("A1:H1").HorizontalAlignment = 3

        wsxl.Cells(2, 1).Font.Size = 10
        wsxl.Cells(2, 1).Font.Bold = True

        wsxl.Cells(2, 8).Value = Format(Date.Now, "short date")
        wsxl.Cells(2, 8).Font.Size = 10
        wsxl.Cells(2, 8).Font.Bold = True

        wsxl.Cells(4, 1).Value = "SUCURSAL : " & GetAlmacen()
        wsxl.Cells(4, 1).Font.Size = 10
        wsxl.Cells(4, 1).Font.Bold = True
        wsxl.Range("A4:H4").Merge()
        wsxl.Range("A3:H4").HorizontalAlignment = 3

        'Encabezado
        Dim Columna As Integer = 0
        While Columna < Me.GrdTraspasos.RootTable.Columns.Count
            wsxl.Cells(6, Columna + 1).Value = Me.GrdTraspasos.RootTable.Columns(Columna).Caption
            wsxl.Columns(Columna + 1).AutoFitColumns()
            Columna = Columna + 1
        End While

        wsxl.Range("A6:H6").Font.Bold = True
        wsxl.Range("A6:H6").HorizontalAlignment = 3
        wsxl.Range("A6:H6").Font.Size = 8
        wsxl.Range("A6:H6").Interior.Color = RGB(255, 255, 192)
        wsxl.Range("A6:H6").BorderAround(, 2, 0, )

        intRow = 0

        For Each oCurrentRow As GridEXRow In Me.GrdTraspasos.GetRows

            Dim odrDataRow As DataRowView
            odrDataRow = CType(oCurrentRow.DataRow, DataRowView)

            For Each column As DataColumn In odrDataRow.DataView.Table.Columns

                wsxl.Cells(oCurrentRow.Position + 7, Me.GrdTraspasos.RootTable.Columns(column.ColumnName).Position + 1).value = _
                   "'" & odrDataRow(column.ColumnName)
            Next
            intRow += 1
        Next


        wsxl.Cells(8 + intRow, 2).Value = "TOTAL TRASPASOS :"
        wsxl.Cells(8 + intRow, 3).Value = Me.GrdTraspasos.RowCount

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

#End Region

End Class
