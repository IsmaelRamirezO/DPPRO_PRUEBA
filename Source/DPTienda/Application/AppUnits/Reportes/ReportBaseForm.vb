Public Class ReportBaseForm
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
    Friend WithEvents uicbEnvironmentMenusBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents uicbEnvironmentStandardBar As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents ArchivoCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Protected Friend WithEvents btnGenerateReport As Janus.Windows.EditControls.UIButton
    Friend WithEvents ArchivoImprimirCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoVistaPreliminarCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoExportarCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ilsSmallEnvironmentIcons As System.Windows.Forms.ImageList
    Friend WithEvents ilsLargeEnvironmentIcons As System.Windows.Forms.ImageList
    Friend WithEvents ArchivoCerrarCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoExportarCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoVistaPreliminarCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoImprimirCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoSalirCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoVistaPreliminarCommand2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoImprimirCommand2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoCerrarCommand1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ArchivoExportarCommand2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents uigbResults As Janus.Windows.EditControls.UIGroupBox
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Protected Friend WithEvents uigbParameters As Janus.Windows.EditControls.UIGroupBox
    Protected Friend WithEvents uicmEnvironment As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents ArchivoCerrarCommand2 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportBaseForm))
        Me.uicmEnvironment = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.uicbEnvironmentMenusBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ArchivoCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCommand")
        Me.ArchivoCerrarCommand2 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCerrarCommand")
        Me.uicbEnvironmentStandardBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ArchivoExportarCommand2 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoExportarCommand")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ArchivoVistaPreliminarCommand2 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoVistaPreliminarCommand")
        Me.ArchivoImprimirCommand2 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoImprimirCommand")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ArchivoCerrarCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCerrarCommand")
        Me.ArchivoCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCommand")
        Me.ArchivoExportarCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoExportarCommand")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ArchivoVistaPreliminarCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoVistaPreliminarCommand")
        Me.ArchivoImprimirCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoImprimirCommand")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.ArchivoSalirCommand1 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCerrarCommand")
        Me.ArchivoExportarCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoExportarCommand")
        Me.ArchivoVistaPreliminarCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoVistaPreliminarCommand")
        Me.ArchivoImprimirCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoImprimirCommand")
        Me.ArchivoCerrarCommand = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCerrarCommand")
        Me.ilsSmallEnvironmentIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ilsLargeEnvironmentIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.uigbResults = New Janus.Windows.EditControls.UIGroupBox()
        Me.geResults = New Janus.Windows.GridEX.GridEX()
        Me.uigbParameters = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnGenerateReport = New Janus.Windows.EditControls.UIButton()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uicbEnvironmentStandardBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.uigbResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbResults.SuspendLayout()
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uigbParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'uicmEnvironment
        '
        Me.uicmEnvironment.BottomRebar = Me.BottomRebar1
        UiCommandCategory1.CategoryName = "Archivo"
        UiCommandCategory2.CategoryName = "Ayuda"
        UiCommandCategory3.CategoryName = "Menús Integrados"
        Me.uicmEnvironment.Categories.AddRange(New Janus.Windows.UI.CommandBars.UICommandCategory() {UiCommandCategory1, UiCommandCategory2, UiCommandCategory3})
        Me.uicmEnvironment.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar, Me.uicbEnvironmentStandardBar})
        Me.uicmEnvironment.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoCommand, Me.ArchivoExportarCommand, Me.ArchivoVistaPreliminarCommand, Me.ArchivoImprimirCommand, Me.ArchivoCerrarCommand})
        Me.uicmEnvironment.ContainerControl = Me
        '
        '
        '
        Me.uicmEnvironment.EditContextMenu.Key = ""
        Me.uicmEnvironment.Id = New System.Guid("cde494d7-1b47-454c-9ecf-b70a6cc9737f")
        Me.uicmEnvironment.ImageList = Me.ilsSmallEnvironmentIcons
        Me.uicmEnvironment.LargeImageList = Me.ilsLargeEnvironmentIcons
        Me.uicmEnvironment.LeftRebar = Me.LeftRebar1
        Me.uicmEnvironment.RightRebar = Me.RightRebar1
        Me.uicmEnvironment.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.uicmEnvironment.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.uicmEnvironment.TopRebar = Me.TopRebar1
        Me.uicmEnvironment.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.uicmEnvironment
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'uicbEnvironmentMenusBar
        '
        Me.uicbEnvironmentMenusBar.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.uicbEnvironmentMenusBar.CommandManager = Me.uicmEnvironment
        Me.uicbEnvironmentMenusBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoCommand1, Me.ArchivoCerrarCommand2})
        Me.uicbEnvironmentMenusBar.FullRow = True
        Me.uicbEnvironmentMenusBar.Key = "Barra de Menus"
        Me.uicbEnvironmentMenusBar.Location = New System.Drawing.Point(0, 0)
        Me.uicbEnvironmentMenusBar.Name = "uicbEnvironmentMenusBar"
        Me.uicbEnvironmentMenusBar.RowIndex = 0
        Me.uicbEnvironmentMenusBar.Size = New System.Drawing.Size(512, 22)
        Me.uicbEnvironmentMenusBar.Text = "Barra de Menús"
        Me.uicbEnvironmentMenusBar.Wrappable = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'ArchivoCommand1
        '
        Me.ArchivoCommand1.Key = "ArchivoCommand"
        Me.ArchivoCommand1.Name = "ArchivoCommand1"
        Me.ArchivoCommand1.ToolTipText = "Archivo"
        '
        'ArchivoCerrarCommand2
        '
        Me.ArchivoCerrarCommand2.Key = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand2.Name = "ArchivoCerrarCommand2"
        Me.ArchivoCerrarCommand2.Text = "Salir"
        Me.ArchivoCerrarCommand2.ToolTipText = "Salir"
        Me.ArchivoCerrarCommand2.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'uicbEnvironmentStandardBar
        '
        Me.uicbEnvironmentStandardBar.CommandManager = Me.uicmEnvironment
        Me.uicbEnvironmentStandardBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoExportarCommand2, Me.Separator3, Me.ArchivoVistaPreliminarCommand2, Me.ArchivoImprimirCommand2, Me.Separator4, Me.ArchivoCerrarCommand1})
        Me.uicbEnvironmentStandardBar.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.uicbEnvironmentStandardBar.Key = "Standard"
        Me.uicbEnvironmentStandardBar.Location = New System.Drawing.Point(0, 22)
        Me.uicbEnvironmentStandardBar.Name = "uicbEnvironmentStandardBar"
        Me.uicbEnvironmentStandardBar.RowIndex = 1
        Me.uicbEnvironmentStandardBar.Size = New System.Drawing.Size(68, 28)
        Me.uicbEnvironmentStandardBar.Text = "Standard"
        '
        'ArchivoExportarCommand2
        '
        Me.ArchivoExportarCommand2.Key = "ArchivoExportarCommand"
        Me.ArchivoExportarCommand2.Name = "ArchivoExportarCommand2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'ArchivoVistaPreliminarCommand2
        '
        Me.ArchivoVistaPreliminarCommand2.Key = "ArchivoVistaPreliminarCommand"
        Me.ArchivoVistaPreliminarCommand2.Name = "ArchivoVistaPreliminarCommand2"
        '
        'ArchivoImprimirCommand2
        '
        Me.ArchivoImprimirCommand2.Key = "ArchivoImprimirCommand"
        Me.ArchivoImprimirCommand2.Name = "ArchivoImprimirCommand2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'ArchivoCerrarCommand1
        '
        Me.ArchivoCerrarCommand1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text
        Me.ArchivoCerrarCommand1.Key = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand1.Name = "ArchivoCerrarCommand1"
        '
        'ArchivoCommand
        '
        Me.ArchivoCommand.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoExportarCommand1, Me.Separator1, Me.ArchivoVistaPreliminarCommand1, Me.ArchivoImprimirCommand1, Me.Separator2, Me.ArchivoSalirCommand1})
        Me.ArchivoCommand.Key = "ArchivoCommand"
        Me.ArchivoCommand.Name = "ArchivoCommand"
        Me.ArchivoCommand.Text = "&Archivo"
        '
        'ArchivoExportarCommand1
        '
        Me.ArchivoExportarCommand1.Key = "ArchivoExportarCommand"
        Me.ArchivoExportarCommand1.Name = "ArchivoExportarCommand1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'ArchivoVistaPreliminarCommand1
        '
        Me.ArchivoVistaPreliminarCommand1.Key = "ArchivoVistaPreliminarCommand"
        Me.ArchivoVistaPreliminarCommand1.Name = "ArchivoVistaPreliminarCommand1"
        '
        'ArchivoImprimirCommand1
        '
        Me.ArchivoImprimirCommand1.Key = "ArchivoImprimirCommand"
        Me.ArchivoImprimirCommand1.Name = "ArchivoImprimirCommand1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'ArchivoSalirCommand1
        '
        Me.ArchivoSalirCommand1.Key = "ArchivoCerrarCommand"
        Me.ArchivoSalirCommand1.Name = "ArchivoSalirCommand1"
        '
        'ArchivoExportarCommand
        '
        Me.ArchivoExportarCommand.CategoryName = "Archivo"
        Me.ArchivoExportarCommand.ImageIndex = 0
        Me.ArchivoExportarCommand.Key = "ArchivoExportarCommand"
        Me.ArchivoExportarCommand.LargeImageIndex = 0
        Me.ArchivoExportarCommand.Name = "ArchivoExportarCommand"
        Me.ArchivoExportarCommand.Text = "&Exportar..."
        Me.ArchivoExportarCommand.ToolTipText = "Exportar"
        Me.ArchivoExportarCommand.Visible = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'ArchivoVistaPreliminarCommand
        '
        Me.ArchivoVistaPreliminarCommand.CategoryName = "Archivo"
        Me.ArchivoVistaPreliminarCommand.ImageIndex = 1
        Me.ArchivoVistaPreliminarCommand.Key = "ArchivoVistaPreliminarCommand"
        Me.ArchivoVistaPreliminarCommand.LargeImageIndex = 1
        Me.ArchivoVistaPreliminarCommand.Name = "ArchivoVistaPreliminarCommand"
        Me.ArchivoVistaPreliminarCommand.Text = "Vista preliminar"
        Me.ArchivoVistaPreliminarCommand.ToolTipText = "Vista Preliminar"
        '
        'ArchivoImprimirCommand
        '
        Me.ArchivoImprimirCommand.CategoryName = "Archivo"
        Me.ArchivoImprimirCommand.ImageIndex = 2
        Me.ArchivoImprimirCommand.Key = "ArchivoImprimirCommand"
        Me.ArchivoImprimirCommand.LargeSelectedImageIndex = 2
        Me.ArchivoImprimirCommand.Name = "ArchivoImprimirCommand"
        Me.ArchivoImprimirCommand.Text = "&Imprimir..."
        Me.ArchivoImprimirCommand.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'ArchivoCerrarCommand
        '
        Me.ArchivoCerrarCommand.CategoryName = "Archivo"
        Me.ArchivoCerrarCommand.Key = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand.Name = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand.Text = "Cerrar"
        Me.ArchivoCerrarCommand.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'ilsSmallEnvironmentIcons
        '
        Me.ilsSmallEnvironmentIcons.ImageStream = CType(resources.GetObject("ilsSmallEnvironmentIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsSmallEnvironmentIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilsSmallEnvironmentIcons.Images.SetKeyName(0, "")
        Me.ilsSmallEnvironmentIcons.Images.SetKeyName(1, "")
        Me.ilsSmallEnvironmentIcons.Images.SetKeyName(2, "")
        '
        'ilsLargeEnvironmentIcons
        '
        Me.ilsLargeEnvironmentIcons.ImageStream = CType(resources.GetObject("ilsLargeEnvironmentIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsLargeEnvironmentIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ilsLargeEnvironmentIcons.Images.SetKeyName(0, "")
        Me.ilsLargeEnvironmentIcons.Images.SetKeyName(1, "")
        Me.ilsLargeEnvironmentIcons.Images.SetKeyName(2, "")
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.uicmEnvironment
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.uicmEnvironment
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar, Me.uicbEnvironmentStandardBar})
        Me.TopRebar1.CommandManager = Me.uicmEnvironment
        Me.TopRebar1.Controls.Add(Me.uicbEnvironmentMenusBar)
        Me.TopRebar1.Controls.Add(Me.uicbEnvironmentStandardBar)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(512, 50)
        '
        'uigbResults
        '
        Me.uigbResults.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.uigbResults.Controls.Add(Me.geResults)
        Me.uigbResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uigbResults.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uigbResults.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbResults.Location = New System.Drawing.Point(0, 114)
        Me.uigbResults.Name = "uigbResults"
        Me.uigbResults.Padding = New System.Windows.Forms.Padding(4)
        Me.uigbResults.Size = New System.Drawing.Size(512, 139)
        Me.uigbResults.TabIndex = 1
        Me.uigbResults.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'geResults
        '
        Me.geResults.AllowColumnDrag = False
        Me.geResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.geResults.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.geResults.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.geResults.DesignTimeLayout = GridEXLayout1
        Me.geResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.geResults.Location = New System.Drawing.Point(4, 4)
        Me.geResults.Name = "geResults"
        Me.geResults.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.geResults.ShowEmptyFields = False
        Me.geResults.Size = New System.Drawing.Size(504, 131)
        Me.geResults.TabIndex = 0
        Me.geResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'uigbParameters
        '
        Me.uigbParameters.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Rebar
        Me.uigbParameters.Controls.Add(Me.btnGenerateReport)
        Me.uigbParameters.Dock = System.Windows.Forms.DockStyle.Top
        Me.uigbParameters.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uigbParameters.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbParameters.Location = New System.Drawing.Point(0, 50)
        Me.uigbParameters.Name = "uigbParameters"
        Me.uigbParameters.Size = New System.Drawing.Size(512, 64)
        Me.uigbParameters.TabIndex = 0
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'btnGenerateReport
        '
        Me.btnGenerateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateReport.Location = New System.Drawing.Point(432, 32)
        Me.btnGenerateReport.Name = "btnGenerateReport"
        Me.btnGenerateReport.Size = New System.Drawing.Size(72, 24)
        Me.btnGenerateReport.TabIndex = 0
        Me.btnGenerateReport.Text = "Generar"
        Me.btnGenerateReport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ReportBaseForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(512, 253)
        Me.Controls.Add(Me.uigbResults)
        Me.Controls.Add(Me.uigbParameters)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(520, 280)
        Me.Name = "ReportBaseForm"
        Me.Text = "Report Base Form"
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uicbEnvironmentStandardBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.uigbResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbResults.ResumeLayout(False)
        CType(Me.geResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uigbParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uigbParameters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Friend Overridable Sub ActionExport()
        MsgBox("ReportBaseForm.ActionExport")
    End Sub

    Protected Friend Overridable Sub ActionPrint()
        MsgBox("ReportBaseForm.ActionPrint")
    End Sub

    Protected Friend Overridable Sub ActionPreview()
        MsgBox("ReportBaseForm.ActionPreview")
    End Sub

    Protected Friend Overridable Sub ActionGenerate()
        MsgBox("ReportBaseForm.ActionGenerate")
    End Sub

    Protected Friend Overridable Sub ActionClose()
        Me.Close()
    End Sub

    Private Sub btnGenerateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateReport.Click
        ActionGenerate()
    End Sub

    Private Sub uicmEnvironment_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uicmEnvironment.CommandClick

        Select Case e.Command.Key

            Case ArchivoExportarCommand.Key

                ActionExport()

            Case ArchivoVistaPreliminarCommand.Key

                ActionPreview()

            Case ArchivoImprimirCommand.Key

                ActionPrint()

            Case ArchivoCerrarCommand.Key

                ActionClose()

        End Select

    End Sub

    Private Sub uicbEnvironmentStandardBar_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uicbEnvironmentStandardBar.CommandClick

    End Sub

    Private Sub uicbEnvironmentMenusBar_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uicbEnvironmentMenusBar.CommandClick

    End Sub
End Class
