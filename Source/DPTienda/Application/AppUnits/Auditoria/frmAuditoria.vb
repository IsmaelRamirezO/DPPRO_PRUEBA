Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos

Imports Janus.Windows.UI

Public Class frmAuditoria
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
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuRecolectoraCargaAutomatica As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecolectoraCargaManual As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecolectora As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecolectora1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecolectoraCargaAutomatica1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuRecolectoraCargaManual1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents sbProcesados As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents dgMateriales As Janus.Windows.GridEX.GridEX
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTodo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirTodo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirLineaFamilia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpciones As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpcionesGuardarLectura As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpciones1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpcionesCargarLectura As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimirFamiliaMarcaLinea As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuDiferenciasInventario As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuDiferenciasInventario1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuPT600 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuPT6001 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHT630 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHT6301 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCS3070 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarTodo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpcionesGuardarLectura1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuOpcionesCargarLectura1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents MnuCargarTodo11 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCS30701 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UiStatusBarPanel4 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuditoria))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.sbProcesados = New Janus.Windows.UI.StatusBar.UIStatusBar()
        Me.dgMateriales = New Janus.Windows.GridEX.GridEX()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuRecolectora1 = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectora")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuOpciones1 = New Janus.Windows.UI.CommandBars.UICommand("menuOpciones")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuRecolectoraCargaAutomatica = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectoraCargaAutomatica")
        Me.menuPT6001 = New Janus.Windows.UI.CommandBars.UICommand("menuPT600")
        Me.menuHT6301 = New Janus.Windows.UI.CommandBars.UICommand("menuHT630")
        Me.menuCS30701 = New Janus.Windows.UI.CommandBars.UICommand("menuCS3070")
        Me.menuRecolectoraCargaManual = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectoraCargaManual")
        Me.menuRecolectora = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectora")
        Me.menuRecolectoraCargaAutomatica1 = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectoraCargaAutomatica")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuRecolectoraCargaManual1 = New Janus.Windows.UI.CommandBars.UICommand("menuRecolectoraCargaManual")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuImprimirTodo1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTodo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimirLineaFamilia1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirFamiliaMarcaLinea")
        Me.menuDiferenciasInventario1 = New Janus.Windows.UI.CommandBars.UICommand("menuDiferenciasInventario")
        Me.menuImprimirFamiliaMarcaLinea = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirFamiliaMarcaLinea")
        Me.menuImprimirTodo = New Janus.Windows.UI.CommandBars.UICommand("menuImprimirTodo")
        Me.menuOpciones = New Janus.Windows.UI.CommandBars.UICommand("menuOpciones")
        Me.menuOpcionesGuardarLectura = New Janus.Windows.UI.CommandBars.UICommand("menuOpcionesGuardarLectura")
        Me.menuOpcionesCargarLectura = New Janus.Windows.UI.CommandBars.UICommand("menuOpcionesCargarLectura")
        Me.menuDiferenciasInventario = New Janus.Windows.UI.CommandBars.UICommand("menuDiferenciasInventario")
        Me.menuPT600 = New Janus.Windows.UI.CommandBars.UICommand("menuPT600")
        Me.menuHT630 = New Janus.Windows.UI.CommandBars.UICommand("menuHT630")
        Me.menuCS3070 = New Janus.Windows.UI.CommandBars.UICommand("menuCS3070")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.MnuCargarTodo = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarTodo")
        Me.menuOpcionesGuardarLectura1 = New Janus.Windows.UI.CommandBars.UICommand("menuOpcionesGuardarLectura")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuOpcionesCargarLectura1 = New Janus.Windows.UI.CommandBars.UICommand("menuOpcionesCargarLectura")
        Me.MnuCargarTodo11 = New Janus.Windows.UI.CommandBars.UICommand("MnuCargarTodo")
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.dgMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.Controls.Add(Me.sbProcesados)
        Me.ExplorerBar1.Controls.Add(Me.dgMateriales)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 22)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(975, 392)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'sbProcesados
        '
        Me.sbProcesados.Location = New System.Drawing.Point(0, 369)
        Me.sbProcesados.Name = "sbProcesados"
        UiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty
        UiStatusBarPanel4.DrawBorder = False
        UiStatusBarPanel4.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel4.Key = "sbpProcesados"
        UiStatusBarPanel4.ProgressBarValue = 0
        UiStatusBarPanel4.Text = "Artículos Procesados"
        UiStatusBarPanel4.Width = 300
        Me.sbProcesados.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel4})
        Me.sbProcesados.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.sbProcesados.Size = New System.Drawing.Size(975, 23)
        Me.sbProcesados.TabIndex = 1
        Me.sbProcesados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'dgMateriales
        '
        Me.dgMateriales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgMateriales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout4.LayoutString = resources.GetString("GridEXLayout4.LayoutString")
        Me.dgMateriales.DesignTimeLayout = GridEXLayout4
        Me.dgMateriales.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMateriales.GroupByBoxVisible = False
        Me.dgMateriales.Location = New System.Drawing.Point(16, 16)
        Me.dgMateriales.Name = "dgMateriales"
        Me.dgMateriales.Size = New System.Drawing.Size(943, 338)
        Me.dgMateriales.TabIndex = 2
        Me.dgMateriales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRecolectoraCargaAutomatica, Me.menuRecolectoraCargaManual, Me.menuRecolectora, Me.menuSalir, Me.menuImprimir, Me.menuImprimirFamiliaMarcaLinea, Me.menuImprimirTodo, Me.menuOpciones, Me.menuOpcionesGuardarLectura, Me.menuOpcionesCargarLectura, Me.menuDiferenciasInventario, Me.menuPT600, Me.menuHT630, Me.menuCS3070, Me.MnuCargarTodo})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("10a79ae6-7b5e-46fe-89f1-650582e44c13")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRecolectora1, Me.Separator1, Me.menuImprimir1, Me.Separator3, Me.menuOpciones1, Me.Separator5, Me.menuSalir1})
        Me.UiCommandBar1.FullRow = True
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(975, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.Wrappable = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'menuRecolectora1
        '
        Me.menuRecolectora1.Key = "menuRecolectora"
        Me.menuRecolectora1.Name = "menuRecolectora1"
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
        'menuOpciones1
        '
        Me.menuOpciones1.Key = "menuOpciones"
        Me.menuOpciones1.Name = "menuOpciones1"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuRecolectoraCargaAutomatica
        '
        Me.menuRecolectoraCargaAutomatica.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuPT6001, Me.menuHT6301, Me.menuCS30701})
        Me.menuRecolectoraCargaAutomatica.Key = "menuRecolectoraCargaAutomatica"
        Me.menuRecolectoraCargaAutomatica.Name = "menuRecolectoraCargaAutomatica"
        Me.menuRecolectoraCargaAutomatica.Text = "Carga Automática"
        '
        'menuPT6001
        '
        Me.menuPT6001.Key = "menuPT600"
        Me.menuPT6001.Name = "menuPT6001"
        '
        'menuHT6301
        '
        Me.menuHT6301.Key = "menuHT630"
        Me.menuHT6301.Name = "menuHT6301"
        '
        'menuCS30701
        '
        Me.menuCS30701.Key = "menuCS3070"
        Me.menuCS30701.Name = "menuCS30701"
        '
        'menuRecolectoraCargaManual
        '
        Me.menuRecolectoraCargaManual.Key = "menuRecolectoraCargaManual"
        Me.menuRecolectoraCargaManual.Name = "menuRecolectoraCargaManual"
        Me.menuRecolectoraCargaManual.Text = "Carga Manual"
        '
        'menuRecolectora
        '
        Me.menuRecolectora.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuRecolectoraCargaAutomatica1, Me.Separator2, Me.menuRecolectoraCargaManual1})
        Me.menuRecolectora.Key = "menuRecolectora"
        Me.menuRecolectora.Name = "menuRecolectora"
        Me.menuRecolectora.Text = "Recolectora"
        '
        'menuRecolectoraCargaAutomatica1
        '
        Me.menuRecolectoraCargaAutomatica1.Key = "menuRecolectoraCargaAutomatica"
        Me.menuRecolectoraCargaAutomatica1.Name = "menuRecolectoraCargaAutomatica1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuRecolectoraCargaManual1
        '
        Me.menuRecolectoraCargaManual1.Key = "menuRecolectoraCargaManual"
        Me.menuRecolectoraCargaManual1.Name = "menuRecolectoraCargaManual1"
        '
        'menuSalir
        '
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "&Salir"
        '
        'menuImprimir
        '
        Me.menuImprimir.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuImprimirTodo1, Me.Separator4, Me.menuImprimirLineaFamilia1, Me.menuDiferenciasInventario1})
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "&Imprimir"
        '
        'menuImprimirTodo1
        '
        Me.menuImprimirTodo1.Key = "menuImprimirTodo"
        Me.menuImprimirTodo1.Name = "menuImprimirTodo1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuImprimirLineaFamilia1
        '
        Me.menuImprimirLineaFamilia1.Key = "menuImprimirFamiliaMarcaLinea"
        Me.menuImprimirLineaFamilia1.Name = "menuImprimirLineaFamilia1"
        '
        'menuDiferenciasInventario1
        '
        Me.menuDiferenciasInventario1.Key = "menuDiferenciasInventario"
        Me.menuDiferenciasInventario1.Name = "menuDiferenciasInventario1"
        Me.menuDiferenciasInventario1.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuImprimirFamiliaMarcaLinea
        '
        Me.menuImprimirFamiliaMarcaLinea.Key = "menuImprimirFamiliaMarcaLinea"
        Me.menuImprimirFamiliaMarcaLinea.Name = "menuImprimirFamiliaMarcaLinea"
        Me.menuImprimirFamiliaMarcaLinea.Text = "Imprimir Familia-Marca-Linea"
        '
        'menuImprimirTodo
        '
        Me.menuImprimirTodo.Key = "menuImprimirTodo"
        Me.menuImprimirTodo.Name = "menuImprimirTodo"
        Me.menuImprimirTodo.Text = "Imprimir Todo"
        '
        'menuOpciones
        '
        Me.menuOpciones.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuOpcionesGuardarLectura1, Me.Separator6, Me.menuOpcionesCargarLectura1, Me.MnuCargarTodo11})
        Me.menuOpciones.Key = "menuOpciones"
        Me.menuOpciones.Name = "menuOpciones"
        Me.menuOpciones.Text = "Opciones"
        '
        'menuOpcionesGuardarLectura
        '
        Me.menuOpcionesGuardarLectura.Key = "menuOpcionesGuardarLectura"
        Me.menuOpcionesGuardarLectura.Name = "menuOpcionesGuardarLectura"
        Me.menuOpcionesGuardarLectura.Text = "Guardar Lectura"
        '
        'menuOpcionesCargarLectura
        '
        Me.menuOpcionesCargarLectura.Key = "menuOpcionesCargarLectura"
        Me.menuOpcionesCargarLectura.Name = "menuOpcionesCargarLectura"
        Me.menuOpcionesCargarLectura.Text = "Cargar Ultima Lectura Guardada"
        '
        'menuDiferenciasInventario
        '
        Me.menuDiferenciasInventario.Key = "menuDiferenciasInventario"
        Me.menuDiferenciasInventario.Name = "menuDiferenciasInventario"
        Me.menuDiferenciasInventario.Text = "Diferencias de Inventario"
        '
        'menuPT600
        '
        Me.menuPT600.Key = "menuPT600"
        Me.menuPT600.Name = "menuPT600"
        Me.menuPT600.Text = "PT600"
        '
        'menuHT630
        '
        Me.menuHT630.Key = "menuHT630"
        Me.menuHT630.Name = "menuHT630"
        Me.menuHT630.Text = "HT630"
        '
        'menuCS3070
        '
        Me.menuCS3070.Key = "menuCS3070"
        Me.menuCS3070.Name = "menuCS3070"
        Me.menuCS3070.Text = "CS3070"
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
        Me.TopRebar1.Size = New System.Drawing.Size(975, 22)
        '
        'MnuCargarTodo
        '
        Me.MnuCargarTodo.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton
        Me.MnuCargarTodo.Key = "MnuCargarTodo"
        Me.MnuCargarTodo.Name = "MnuCargarTodo"
        Me.MnuCargarTodo.Text = "&Cargar  Todo"
        '
        'menuOpcionesGuardarLectura1
        '
        Me.menuOpcionesGuardarLectura1.Key = "menuOpcionesGuardarLectura"
        Me.menuOpcionesGuardarLectura1.Name = "menuOpcionesGuardarLectura1"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuOpcionesCargarLectura1
        '
        Me.menuOpcionesCargarLectura1.Key = "menuOpcionesCargarLectura"
        Me.menuOpcionesCargarLectura1.Name = "menuOpcionesCargarLectura1"
        '
        'MnuCargarTodo11
        '
        Me.MnuCargarTodo11.Checked = Janus.Windows.UI.InheritableBoolean.[False]
        Me.MnuCargarTodo11.Key = "MnuCargarTodo"
        Me.MnuCargarTodo11.Name = "MnuCargarTodo11"
        '
        'frmAuditoria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(975, 414)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Name = "frmAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "...:: Auditoria ::..."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.dgMateriales, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "Variables Globales"
    Dim dtAllUPC As DataTable 'Recolectora
    Dim dtMateriales As DataTable
    Dim dtExistencias As DataTable
    Dim dtAllUPCReport As DataTable 'Recolectora y DPPro (SAP)
#End Region

#Region "Metodos"

    Private Function CrearTablaAllUPC() As DataTable
        Dim dtAllUPC As New DataTable("AllUPC")

        Dim dcCodArticulo As New DataColumn("CodArticulo", GetType(String))
        dcCodArticulo.DefaultValue = String.Empty

        Dim dcTalla As New DataColumn("Talla", GetType(String))
        dcTalla.DefaultValue = String.Empty

        Dim dcDescripcion As New DataColumn("Descripcion", GetType(String))
        dcDescripcion.DefaultValue = String.Empty

        Dim dcCantidad As New DataColumn("Cantidad", GetType(Int32))
        dcCantidad.DefaultValue = 0

        Dim dcCodUPC As New DataColumn("CodUPC", GetType(String))
        dcCodUPC.DefaultValue = String.Empty

        Dim dcCodLinea As New DataColumn("CodLinea", GetType(String))
        dcCodLinea.DefaultValue = String.Empty

        Dim dcDesLinea As New DataColumn("DesLinea", GetType(String))
        dcDesLinea.DefaultValue = String.Empty

        Dim dcLibre As New DataColumn("Libre", GetType(Integer))
        dcLibre.DefaultValue = 0

        Dim dcValorado As New DataColumn("Valorado", GetType(Boolean))
        dcValorado.DefaultValue = False

        Dim dcCosto As New DataColumn("Costo", GetType(Decimal))
        dcCosto.DefaultValue = 0

        Dim dcCodFamilia As New DataColumn("CodFamilia", GetType(String))
        dcCodFamilia.DefaultValue = String.Empty

        Dim dcDesFamilia As New DataColumn("DesFamilia", GetType(String))
        dcDesFamilia.DefaultValue = String.Empty

        Dim dcCodMarca As New DataColumn("CodMarca", GetType(String))
        dcCodMarca.DefaultValue = String.Empty

        Dim dcDesMarca As New DataColumn("DesMarca", GetType(String))
        dcDesMarca.DefaultValue = String.Empty
        'rgermain 09.10.2016: Columna nueva con codigo de proveedor para SAP Retail
        Dim dcCodProv As New DataColumn("CodProv", GetType(String))
        dcCodProv.DefaultValue = String.Empty

        Dim dcColor As New DataColumn("Color", GetType(String))
        dcColor.DefaultValue = String.Empty
        'TODO: Poner columna costo.

        With dtAllUPC.Columns
            .Add(dcCodArticulo)
            .Add(dcDescripcion)
            .Add(dcCosto)
            .Add(dcTalla)
            .Add(dcCantidad)
            .Add(dcCodUPC)
            .Add(dcCodLinea)
            .Add(dcDesLinea)
            .Add(dcLibre)
            .Add(dcValorado)
            .Add(dcCodFamilia)
            .Add(dcDesFamilia)
            .Add(dcCodMarca)
            .Add(dcDesMarca)
            .Add(dcCodProv)
            .Add(dcColor)
        End With

        Return dtAllUPC

    End Function

    Private Sub LimpiarCampos()
        dtAllUPC = Me.CrearTablaAllUPC
        Me.UiCommandManager1.Commands("menuRecolectora").Enabled = Janus.Windows.UI.InheritableBoolean.True
    End Sub

    Private Sub BajarArchivoRecolectora(ByVal modelo As String)
        Try
            If File.Exists("C:\PTComm\PreRecep.csv") Then
                File.Delete("C:\PTComm\PreRecep.csv")
            End If

            If (modelo = "PT-600" AndAlso Not File.Exists("C:\PTComm\Upload PreRecep Data.pcb")) OrElse _
            (modelo = "HT-630" AndAlso Not File.Exists("C:\PTComm\Upload PreRecep Data HT630.pcb")) Then
                Dim oFile As StreamWriter

                If modelo = "PT-600" Then
                    oFile = New StreamWriter("C:\PTComm\Upload PreRecep Data.pcb")
                Else
                    oFile = New StreamWriter("C:\PTComm\Upload PreRecep Data HT630.pcb")
                End If
                'oFile.WriteLine("ECHO: Upload data file PreRecep.csv of job PreRecep.exe from PT600.")
                oFile.WriteLine("ECHO: Upload data file PreRecep.csv of job PreRecep.exe from " & modelo & ".")
                oFile.WriteLine("ADDRESS: A")
                'oFile.WriteLine("PORTABLE: PT-600")
                oFile.WriteLine("PORTABLE: " & modelo.ToUpper)
                oFile.WriteLine("DIRECTION: UpLoad")
                oFile.WriteLine("FASTSPEED: yes")
                oFile.WriteLine("FILE(OVERWRITE): PreRecep.csv <> C:\PTComm\PreRecep.csv")
                oFile.Close()
            End If
            If modelo = "PT-600" Then
                Shell("C:\PTComm\ptcomm.exe " & " /exit /comport:1 /ptaddr:A /batch:""C:\PTComm\Upload PreRecep Data.pcb""", AppWinStyle.NormalFocus, True, -1)
            Else
                Shell("C:\PTComm\ptcomm.exe " & " /exit /comport:1 /ptaddr:A /batch:""C:\PTComm\Upload PreRecep Data HT630.pcb""", AppWinStyle.NormalFocus, True, -1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ValidarUPC(ByVal strLine As String)
        Try
            Dim oCatalogoUPC As New CatalogosManager(oAppContext)
            Dim oMaterial As Material
            Dim strTalla As String = "", strCodigo As String = ""
            Dim dvUPC As New DataView(dtAllUPC, "CodUPC ='" & strLine & "'", "CodUPC", DataViewRowState.CurrentRows)
            If dvUPC.Count > 0 Then
                dvUPC(0)("Cantidad") += 1
            Else
                If IsNumeric(strLine) Then
                    oMaterial = oCatalogoUPC.GetDatosUPC(strLine)
                    Dim oNewRow As DataRow = dtAllUPC.NewRow

                    If Not oMaterial Is Nothing Then
                        oNewRow("CodArticulo") = oMaterial.CodArticulo
                        strCodigo = oMaterial.CodArticulo
                        Dim strCorrida As String
                        strCorrida = oCatalogoUPC.GetCorridaArt(oMaterial.CodArticulo)

                        'If strCorrida = "ACC" OrElse strCorrida = "TEX" OrElse strCorrida = "AC1" Then

                        'Select Case oMaterial.Talla
                        '    Case "10"
                        '        oNewRow("Talla") = "XXL"
                        '        strTalla = "XXL"
                        '    Case "8"
                        '        oNewRow("Talla") = "XL"
                        '        strTalla = "XL"
                        '    Case "6"
                        '        oNewRow("Talla") = "L"
                        '        strTalla = "L"
                        '    Case "4"
                        '        oNewRow("Talla") = "M"
                        '        strTalla = "M"
                        '    Case "2"
                        '        oNewRow("Talla") = "S"
                        '        strTalla = "S"
                        '    Case "1"
                        '        oNewRow("Talla") = "XS"
                        '        strTalla = "XS"
                        '    Case "00", "0"
                        '        oNewRow("Talla") = "U"
                        '        strTalla = "U"
                        '    Case Else
                        '        oNewRow("Talla") = oMaterial.Talla
                        '        strTalla = oMaterial.Talla
                        'End Select
                        'Else
                        oNewRow("Talla") = oMaterial.Talla
                        strTalla = oMaterial.Talla
                        'End If


                    Else
                        'Buscamos UPC en SAP.
                        Dim oProcesosSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                        Dim oMaterialSAP As DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU.ArticulosSAP
                        oMaterialSAP = oProcesosSapMgr.Read_UPC_FromSAP(strLine)
                        If Not oMaterialSAP Is Nothing Then
                            oNewRow("CodArticulo") = CStr(oMaterialSAP.Codarticulo).Trim
                            strCodigo = CStr(oMaterialSAP.Codarticulo).Trim
                            oNewRow("Costo") = oMaterialSAP.Costopromedio
                            oNewRow("Descripcion") = CStr(oMaterialSAP.Descripcion).Trim
                            If IsNumeric(CStr(oMaterialSAP.Codcorrida).Trim) Then
                                Dim Numero As Integer = CInt(CStr(oMaterialSAP.Codcorrida).Trim)
                                If Numero <> CDec(CStr(oMaterialSAP.Codcorrida).Trim) Then
                                    oNewRow("Talla") = CStr(oMaterialSAP.Codcorrida).Trim  'Aqui metemos la talla en esta consulta a SAP
                                    strTalla = CStr(oMaterialSAP.Codcorrida).Trim
                                Else
                                    oNewRow("Talla") = CStr(Numero).Trim  'Aqui metemos la talla en esta consulta a SAP
                                    strTalla = CStr(Numero).Trim
                                End If
                            Else
                                oNewRow("Talla") = CStr(oMaterialSAP.Codcorrida).Trim  'Aqui metemos la talla en esta consulta a SAP
                                strTalla = CStr(oMaterialSAP.Codcorrida).Trim
                            End If
                            'TODO: Sacar Linea.
                            oNewRow("CodLinea") = CStr(oMaterialSAP.Codlinea).Trim
                            oNewRow("DesLinea") = oCatalogoUPC.GetLinea(oMaterialSAP.Codlinea)

                            'TODO: Sacar Familia.
                            oNewRow("CodFamilia") = oMaterialSAP.Codfamilia
                            oNewRow("DesFamilia") = oCatalogoUPC.GetFamilia(oMaterialSAP.Codfamilia)

                            'TODO: Sacar Marca. 
                            oNewRow("CodMarca") = Mid(oMaterialSAP.Codarticulo, 1, 2)
                            oNewRow("DesMarca") = oCatalogoUPC.GetMarca(Mid(oMaterialSAP.Codarticulo, 1, 2))




                        Else
                            oNewRow("CodLinea") = String.Empty
                            oNewRow("DesLinea") = String.Empty

                            'TODO: Sacar Familia.
                            oNewRow("CodFamilia") = String.Empty
                            oNewRow("DesFamilia") = String.Empty

                            'TODO: Sacar Marca. 
                            oNewRow("CodMarca") = String.Empty
                            oNewRow("DesMarca") = String.Empty
                        End If
                    End If
                    'Buscamos el mismo articulo y talla, en caso de que los upc's sean distintos y se refieran
                    'al mismo articulo y talla
                    Dim dvArtTalla As New DataView(dtAllUPC, "CodArticulo ='" & strCodigo & "'", "CodArticulo", DataViewRowState.CurrentRows)
                    If dvArtTalla.Count > 0 Then
                        dvArtTalla(0)("Cantidad") += 1
                    Else
                        oNewRow("CodUPC") = strLine
                        oNewRow("Cantidad") = 1
                        dtAllUPC.Rows.Add(oNewRow)
                    End If





                Else
                    'Codigos Viejos.
                    Dim vCodArticulo As String
                    Dim vNumStringArticulo As String
                    Dim vNumeroArticulo As String

                    vCodArticulo = UCase(strLine)
                    vNumStringArticulo = Mid(vCodArticulo, 1, 2)

                    If IsNumeric(vNumStringArticulo) Then
                        vCodArticulo = UCase(Mid(vCodArticulo, 3, Len(vCodArticulo) - 2))
                        If vNumStringArticulo <> "00" Then
                            vNumeroArticulo = CDec(vNumStringArticulo) / 2
                        Else
                            vNumeroArticulo = "0"
                        End If

                        Dim oArticulo As Articulo
                        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                        oArticulo = oArticuloMgr.Create
                        oArticulo.ClearFields()

                        oArticuloMgr.LoadInto(vCodArticulo, oArticulo, True)
                        If oArticulo.CodArticulo <> String.Empty Then
                            vCodArticulo = oArticulo.CodArticulo
                        Else
                            oArticulo.ClearFields()
                            oArticuloMgr.LoadInto(vCodArticulo, oArticulo)
                            If oArticulo.CodArticulo <> String.Empty Then
                                vCodArticulo = oArticulo.CodArticulo
                            End If
                        End If

                        'Se cambia la talla del material si es accesorio o textil
                        If oArticulo.CodCorrida = "ACC" OrElse oArticulo.CodCorrida = "TEX" OrElse oArticulo.CodCorrida = "AC1" Then

                            Select Case vNumeroArticulo
                                Case "10"
                                    vNumeroArticulo = "XXL"
                                Case "8"
                                    vNumeroArticulo = "XL"
                                Case "6"
                                    vNumeroArticulo = "L"
                                Case "4"
                                    vNumeroArticulo = "M"
                                Case "2"
                                    vNumeroArticulo = "S"
                                Case "1"
                                    vNumeroArticulo = "XS"
                                Case "0"
                                    vNumeroArticulo = "U"
                            End Select

                        End If


                        'vCodArticulo " Codigo de articulo.
                        'vNumeroArticulo " Numero de Material.
                        Dim oNewRow As DataRow = dtAllUPC.NewRow
                        oNewRow("CodArticulo") = vCodArticulo
                        oNewRow("Talla") = vNumeroArticulo

                        Dim dvArtTalla2 As New DataView(dtAllUPC, "CodArticulo ='" & vCodArticulo & "' and Talla = '" & vNumeroArticulo & "'", "CodArticulo", DataViewRowState.CurrentRows)
                        If dvArtTalla2.Count > 0 Then
                            dvArtTalla2(0)("Cantidad") += 1
                        Else

                            oNewRow("CodUPC") = strLine

                            oNewRow("Cantidad") = 1
                            oNewRow("Costo") = oArticulo.CostoProm
                            oNewRow("Descripcion") = oArticulo.Descripcion

                            oNewRow("CodLinea") = oArticulo.Codlinea
                            oNewRow("DesLinea") = oCatalogoUPC.GetLinea(oArticulo.Codlinea)

                            oNewRow("CodFamilia") = oArticulo.CodFamilia
                            oNewRow("DesFamilia") = oCatalogoUPC.GetFamilia(oArticulo.CodFamilia)

                            'TODO: Sacar Marca. 

                            oNewRow("CodMarca") = oArticulo.CodMarca  'En este campo viene el codigo de la marca
                            oNewRow("DesMarca") = oCatalogoUPC.GetMarca(oArticulo.CodMarca)
                            dtAllUPC.Rows.Add(oNewRow)

                        End If
                    End If
                End If

            End If

            dtAllUPC.AcceptChanges()

            Me.sbProcesados.Panels("sbpProcesados").Text = "UPC Procesados .- " & dtAllUPC.Rows.Count
            Application.DoEvents()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DistribuirData(ByVal intCargarTodo As Boolean)
        If File.Exists("C:\PTComm\PreRecep.csv") Then

            Dim dvExistencias As DataView
            Dim oStreamreader As New StreamReader("C:\PTComm\PreRecep.csv")
            Dim i As Integer = 0
            Try
                dtAllUPC = Me.CrearTablaAllUPC

                Dim strLine As String
                strLine = oStreamreader.ReadLine
                While Not (strLine Is Nothing)

                    strLine = strLine.Trim
                    strLine = strLine.Replace("'", "")
                    If IsNumeric(strLine) Then
                        strLine = strLine.PadLeft(18, "0")
                    End If

                    If Not strLine = "0".PadLeft(18, "0") Then
                        ValidarUPC(strLine)
                    End If
                    strLine = oStreamreader.ReadLine

                    i += 1
                    'TODO: aragon quitar.
                    'If dtAllUPC.Rows.Count > 100 Then
                    '    Exit While
                    'End If
                End While

                'En este punto ya tengo todos los UPC validados.
                'Los que no tengan CodArticulo no se encontraron en DPPRo ni en SAP.


                '*** Aki Agrego todos los codigos del dtAllUPC a un string para evitar perdida de tiempo
                Dim strCodigos As String = "'"
                If intCargarTodo = False Then
                    For Each row As DataRow In dtAllUPC.Rows
                        strCodigos = strCodigos & CStr(row.Item("CodArticulo")).Trim() & "','"
                    Next
                    strCodigos = Mid(strCodigos, 1, strCodigos.Length - 2)
                Else
                    strCodigos = ""
                End If


                'Sacamos Tabla con Los Articulos de Existencias segun los codigos del dtAllUPC.
                'Tendra Campos CodArticulo Descripcion CodLinea DesLinea
                Dim oCatalogoUPC As New CatalogosManager(oAppContext)
                dtMateriales = oCatalogoUPC.GetMateriales(strCodigos, intCargarTodo)


                'Sacamos Tabla Existencia.
                'CodArticulo Talla Libre.
                dtExistencias = oCatalogoUPC.GetExistencias(strCodigos, intCargarTodo)
                Dim dcValorado As New DataColumn("Valorado", GetType(Boolean))
                dcValorado.DefaultValue = False
                dtExistencias.Columns.Add(dcValorado)

                'Creamos Tabla Donde Meteremos los UPC para el Reporte.
                dtAllUPCReport = Me.CrearTablaAllUPC
                dtAllUPCReport.TableName = "AllUpcReport"
                dtAllUPCReport.AcceptChanges()

                dvExistencias = New DataView(dtExistencias, "", "Numero", DataViewRowState.CurrentRows)
                For Each oRowMaterial As DataRow In dtMateriales.Rows
                    Dim dvAllUPC As New DataView(dtAllUPC, "CodArticulo ='" & oRowMaterial("CodArticulo") & "'", "Talla", DataViewRowState.CurrentRows)
                    dvExistencias.RowFilter = "CodArticulo ='" & oRowMaterial("CodArticulo") & "'"

                    'Primero tomamos todos los de la lectora. Solo sobrara produncto de existencia
                    For Each oViewAllUPC As DataRowView In dvAllUPC
                        Dim oNewRow As DataRow = dtAllUPCReport.NewRow
                        oViewAllUPC("Valorado") = 1

                        oNewRow("CodArticulo") = oRowMaterial("CodArticulo")
                        oNewRow("Descripcion") = oRowMaterial("Descripcion")
                        oNewRow("Costo") = oRowMaterial("Costo")
                        oNewRow("Talla") = oViewAllUPC("Talla")
                        Debug.WriteLine(oViewAllUPC("Cantidad"))
                        oNewRow("Cantidad") = oViewAllUPC("Cantidad") 'Recolectora
                        oNewRow("Libre") = 0
                        oNewRow("CodLinea") = oRowMaterial("CodLinea")
                        oNewRow("DesLinea") = oRowMaterial("DesLinea")
                        oNewRow("CodFamilia") = oRowMaterial("CodFamilia")
                        oNewRow("DesFamilia") = oRowMaterial("DesFamilia")
                        oNewRow("CodMarca") = oRowMaterial("CodMarca")  'En este campo viene el codigo de la marca
                        oNewRow("DesMarca") = oCatalogoUPC.GetMarca(oRowMaterial("CodMarca"))
                        oNewRow("CodProv") = dvExistencias(0)("ID_DPPRO")
                        oNewRow("Color") = dvExistencias(0)("Color")

                        oNewRow("CodUPC") = oViewAllUPC("CodUPC") 'Recolectora

                        Dim oRowFind() As DataRowView = dvExistencias.FindRows(oViewAllUPC("Talla"))

                        For Each oViewRowFind As DataRowView In oRowFind
                            oViewRowFind("Valorado") = 1
                            oNewRow("Libre") = oNewRow("Libre") + oViewRowFind("Libre")
                        Next

                        dtAllUPCReport.Rows.Add(oNewRow)
                        dtAllUPCReport.AcceptChanges()
                        dtAllUPC.AcceptChanges()
                        dtExistencias.AcceptChanges()

                        Me.sbProcesados.Panels("sbpProcesados").Text = "Artículos Procesados .- " & dtAllUPCReport.Rows.Count
                        Application.DoEvents()
                    Next

                    For Each oRowViewExistencias As DataRowView In dvExistencias
                        If CBool(oRowViewExistencias("Valorado")) = False Then
                            Dim oNewRow As DataRow = dtAllUPCReport.NewRow

                            oNewRow("CodArticulo") = oRowMaterial("CodArticulo")
                            oNewRow("Descripcion") = oRowMaterial("Descripcion")
                            oNewRow("Costo") = oRowMaterial("Costo")
                            oNewRow("Talla") = oRowViewExistencias("Numero")
                            oNewRow("Cantidad") = 0 'Recolectora
                            oNewRow("Libre") = oRowViewExistencias("Libre")
                            oNewRow("CodLinea") = oRowMaterial("CodLinea")
                            oNewRow("DesLinea") = oRowMaterial("DesLinea")
                            oNewRow("CodFamilia") = oRowMaterial("CodFamilia")
                            oNewRow("DesFamilia") = oRowMaterial("DesFamilia")
                            oNewRow("CodMarca") = oRowMaterial("CodMarca")  'En este campo viene el codigo de la marca
                            oNewRow("DesMarca") = oCatalogoUPC.GetMarca(oRowMaterial("CodMarca"))
                            oNewRow("CodProv") = oRowViewExistencias("ID_DPPRO")
                            oNewRow("Color") = oRowViewExistencias("Color")

                            oNewRow("CodUPC") = "" 'Recolectora

                            dtAllUPCReport.Rows.Add(oNewRow)

                            oRowViewExistencias("Valorado") = 1
                            dtAllUPCReport.AcceptChanges()
                            dtAllUPC.AcceptChanges()
                            dtExistencias.AcceptChanges()

                            Me.sbProcesados.Panels("sbpProcesados").Text = "Artículos Procesados .- " & dtAllUPCReport.Rows.Count
                            Application.DoEvents()
                        End If
                    Next
                    'TODO: aragon quitar.
                    'If dtAllUPCReport.Rows.Count > 100 Then
                    '    Exit For
                    'End If
                Next

                'Sacamos los materiales que solo están en SAP.
                Dim dvAllUPCOnlySAP As New DataView(dtAllUPC, "Valorado = 0", "Talla", DataViewRowState.CurrentRows)
                Dim iCont As Integer = 0

                For iCont = 0 To dvAllUPCOnlySAP.Count - 1
                    'For Each oViewAllUPC As DataRowView In dvAllUPCOnlySAP

                    Dim oNewRow As DataRow = dtAllUPCReport.NewRow
                    'dvAllUPCOnlySAP(iCont)("Valorado") = 1

                    If dvAllUPCOnlySAP(iCont)("CodArticulo") = String.Empty Then
                        oNewRow("CodArticulo") = dvAllUPCOnlySAP(iCont)("CodUPC")
                    Else
                        oNewRow("CodArticulo") = dvAllUPCOnlySAP(iCont)("CodArticulo")


                        '''Buscamos Info.
                        Dim oArticulo As Articulo
                        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
                        oArticulo = oArticuloMgr.Create
                        oArticulo.ClearFields()

                        oArticuloMgr.LoadInto(oNewRow("CodArticulo"), oArticulo, True)
                        If Not oArticulo.CodArticulo <> String.Empty Then
                            oArticulo.ClearFields()
                            oArticuloMgr.LoadInto(oNewRow("CodArticulo"), oArticulo)
                        End If

                        oNewRow("CodLinea") = oArticulo.Codlinea
                        oNewRow("DesLinea") = oCatalogoUPC.GetLinea(oArticulo.Codlinea)

                        oNewRow("CodFamilia") = oArticulo.CodFamilia
                        oNewRow("DesFamilia") = oCatalogoUPC.GetFamilia(oArticulo.CodFamilia)

                        oNewRow("CodMarca") = oArticulo.CodMarca  'En este campo viene el codigo de la marca
                        oNewRow("DesMarca") = oCatalogoUPC.GetMarca(oArticulo.CodMarca)
                        '''Fin Buscar Info
                        oNewRow("Descripcion") = oArticulo.Descripcion
                        oNewRow("Costo") = oArticulo.CostoProm

                        dvExistencias.RowFilter = "CodArticulo ='" & oNewRow("CodArticulo") & "'"
                        If dvExistencias.Count > 0 Then
                            oNewRow("CodProv") = CStr(dvExistencias(0)("ID_DPPRO")).Trim
                            oNewRow("Color") = CStr(dvExistencias(0)("Color")).Trim
                        Else
                            oNewRow("CodProv") = oArticulo.CodMarca & "-" & oArticulo.CodArtProv
                            oNewRow("Color") = ""
                        End If
                    End If

                    If oNewRow("Costo") = 0 Then
                        oNewRow("Costo") = dvAllUPCOnlySAP(iCont)("Costo")
                    End If
                    oNewRow("Talla") = dvAllUPCOnlySAP(iCont)("Talla")
                    oNewRow("Cantidad") = dvAllUPCOnlySAP(iCont)("Cantidad") 'Recolectora
                    oNewRow("Libre") = 0

                    'oNewRow("CodLinea") = dvAllUPCOnlySAP(iCont)("CodLinea")
                    'oNewRow("DesLinea") = dvAllUPCOnlySAP(iCont)("DesLinea")

                    'oNewRow("CodFamilia") = dvAllUPCOnlySAP(iCont)("CodFamilia")
                    'oNewRow("DesFamilia") = dvAllUPCOnlySAP(iCont)("DesFamilia")

                    'oNewRow("CodMarca") = dvAllUPCOnlySAP(iCont)("CodMarca")  'En este campo viene el codigo de la marca
                    'oNewRow("DesMarca") = dvAllUPCOnlySAP(iCont)("DesMarca")

                    oNewRow("CodUPC") = dvAllUPCOnlySAP(iCont)("CodUPC") 'Recolectora

                    dtAllUPCReport.Rows.Add(oNewRow)
                    dtAllUPCReport.AcceptChanges()
                    Me.sbProcesados.Panels("sbpProcesados").Text = "Artículos Procesados .- " & dtAllUPCReport.Rows.Count
                    Application.DoEvents()
                    'If dtAllUPCReport.Rows.Count > 100 Then
                    '    Exit For
                    'End If
                Next
                dtAllUPC.AcceptChanges()

                'Ya los tenemos separaditos.
                Dim dcDiferencia As New DataColumn
                With dcDiferencia
                    .ColumnName = "Diferencia"
                    .DataType = GetType(Decimal)
                    .Expression = "Cantidad - Libre"
                End With

                Dim dcTCosto As New DataColumn
                With dcTCosto
                    .ColumnName = "TCosto"
                    .DataType = GetType(Decimal)
                    .Expression = "Costo * Diferencia"
                End With

                dtAllUPCReport.Columns.Add(dcDiferencia)
                dtAllUPCReport.Columns.Add(dcTCosto)

                dtAllUPCReport.DefaultView.RowFilter = "Diferencia <> 0"
                dtAllUPCReport.DefaultView.Sort = "CodFamilia,CodMarca,CodLinea,CodProv,CodArticulo,Talla"
                dtAllUPCReport.AcceptChanges()
                Me.dgMateriales.DataSource = dtAllUPCReport.DefaultView
                Application.DoEvents()

                'SaveGridData(dtAllUPCReport.DefaultView)

            Catch ex As Exception
                Throw ex
            Finally
                oStreamreader.Close()
                oStreamreader = Nothing
            End Try
        Else
            MessageBox.Show("El archivo C:\PTComm\PreRecep.csv no existe", "Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Automatica(ByVal modelo As String)
        Try
            Dim intCargarTodo As Boolean

            Cursor.Current = Cursors.WaitCursor

            BajarArchivoRecolectora(modelo)

            If Me.UiCommandBar1.Commands("menuOpciones").Commands("MnuCargarTodo").IsChecked Then
                intCargarTodo = True
            Else
                intCargarTodo = False
            End If

            DistribuirData(intCargarTodo)

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#Region "Lectora CS3070"
    '---------------------------------------------------------------------------------------------------------
    'JNAVA 23.06.2014: Carga Automatica desde lectora CS3070
    '---------------------------------------------------------------------------------------------------------
    Private Sub Automatica_CS3070()
        Try
            Dim intCargarTodo As Boolean
            Dim strRutaArchivo As String = ""

            Cursor.Current = Cursors.WaitCursor

            If BuscaLectora(strRutaArchivo, oConfigCierreFI.NombreLectoraTE, oConfigCierreFI.NombreArchivoLectoraTE) Then

                If strRutaArchivo.Trim <> "" Then

                    BajarArchivoLectora_CS3070(strRutaArchivo, oConfigCierreFI.NombreArchivoLectoraTE)

                    If Me.UiCommandBar1.Commands("menuOpciones").Commands("MnuCargarTodo").IsChecked Then
                        intCargarTodo = True
                    Else
                        intCargarTodo = False
                    End If

                    DistribuirData(intCargarTodo)

                Else

                    MessageBox.Show("No se encontró el Archivo de carga en la lectora. Favor de verificar.", "Lectora CS3070", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Else

                MessageBox.Show("No se encontró la Lectora CS3070. Favor de verificar.", "Lectora CS3070", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '---------------------------------------------------------------------------------------------------------
    'JNAVA 23.06.2014: Función que verifica si esta disponible la Lectora CS3070
    '---------------------------------------------------------------------------------------------------------
    Private Function BuscaLectora(ByRef RutaLayout As String, ByVal NombreLectora As String, ByVal NombreArchivo As String) As Boolean
        Dim bResult As Boolean = False
        Dim fso As New Scripting.FileSystemObject

        Dim NombreUnidad As String = ""
        Dim LetraUnidad As String = ""

        Try
            For Each unidad As Scripting.Drive In fso.Drives
                If unidad.DriveType = 3 Then
                    NombreUnidad = unidad.ShareName()
                ElseIf unidad.IsReady Then
                    NombreUnidad = unidad.VolumeName
                End If
                If NombreUnidad = NombreLectora Then
                    LetraUnidad = unidad.DriveLetter
                    bResult = True
                    Exit For
                End If
            Next

            If bResult Then
                Dim Ruta As String
                Dim Temp As New DirectoryInfo(LetraUnidad & ":")
                Ruta = BuscaArchivoLayout(Temp, NombreArchivo)
                RutaLayout = Ruta
            End If

            fso = Nothing
            Return bResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------------------------
    'JNAVA 23.06.2014: Función que verifica si esta disponible el archivo de carga en la Lectora CS3070
    '---------------------------------------------------------------------------------------------------------
    Private Function BuscaArchivoLayout(ByVal SearchDir As DirectoryInfo, ByVal searchFileName As String) As String
        Static Dim FoundPath As String = ""
        Try
            If FoundPath = "" Then
                Dim temp As String = ""
                If SearchDir.GetFiles(searchFileName).Length > 0 Then
                    FoundPath = SearchDir.FullName & "\" & searchFileName
                    Return SearchDir.FullName & "\" & searchFileName
                End If
                Dim Directories() As DirectoryInfo = SearchDir.GetDirectories("*")
                For Each newDir As DirectoryInfo In Directories
                    temp = BuscaArchivoLayout(newDir, searchFileName)
                Next
                Return temp
            Else
                Return FoundPath
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    '---------------------------------------------------------------------------------------------------------
    'JNAVA 23.06.2014: Función que copia el archivo de la Lectora CS3070 a C:\PTComm\
    '---------------------------------------------------------------------------------------------------------
    Private Sub BajarArchivoLectora_CS3070(ByVal RutaArchivo As String, ByVal NombreArchivo As String)
        Try

            If Not Directory.Exists("C:\PTComm") Then
                Directory.CreateDirectory("C:\PTComm")
            End If

            If File.Exists("C:\PTComm\PreRecep.csv") Then
                File.Delete("C:\PTComm\PreRecep.csv")
            End If

            'Copiamos el archivo a la Carpeta de respaldo en lectora 
            File.Copy(RutaArchivo, "C:\PTComm\PreRecep.csv")

            'Eliminamos el archivo de la lectora
            File.Delete(RutaArchivo)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#End Region

#Region "Eventos"

    Private Sub UiCommandManager1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key
            Case "menuRecolectoraCargaAutomatica"
                'Try
                '    Dim intCargarTodo As Boolean
                '    Cursor.Current = Cursors.WaitCursor
                '    BajarArchivoRecolectora()
                '    'If MsgBox("¿Desea cargar el inventario completo?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                '    intCargarTodo = True
                '    DistribuirData(intCargarTodo)
                '    'Else
                '    '    intCargarTodo = False
                '    '    DistribuirData(intCargarTodo)
                '    'End If

                'Catch ex As Exception
                '    Throw ex
                'Finally
                '    Cursor.Current = Cursors.Default
                'End Try
            Case "menuPT600"

                Automatica("PT-600")

            Case "menuHT630"

                Automatica("HT-630")

            Case "menuCS3070"
                '--------------------------------------------------------------
                'JNAVA 23.06.2014: Carga Automatica desde lectora CS3070
                '--------------------------------------------------------------
                Automatica_CS3070()

            Case "menuRecolectoraCargaManual"

                Try
                    Dim intCargarTodo As Boolean
                    'If MsgBox("¿Desea cargar el inventario completo?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    If Me.UiCommandBar1.Commands("menuOpciones").Commands("MnuCargarTodo").IsChecked Then
                        intCargarTodo = True
                    Else
                        intCargarTodo = False
                    End If
                    'intCargarTodo = True
                    Cursor.Current = Cursors.WaitCursor
                    DistribuirData(intCargarTodo)
                    'Else
                    '   intCargarTodo = False
                    '   Cursor.Current = Cursors.WaitCursor
                    '   DistribuirData(intCargarTodo)
                    ' End If

                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try

            Case "menuImprimirTodo"
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim oReporter As New Reporter
                    Dim dtArticulos As DataTable = Me.dtAllUPCReport.Clone
                    Dim oDataView As DataView = Me.dtAllUPCReport.DefaultView
                    For Each oDataRowViewF As DataRowView In oDataView
                        oDataRowViewF("CodArticulo") = CStr(oDataRowViewF("CodArticulo")).Trim.TrimStart("0")
                        oDataRowViewF.Row.AcceptChanges()
                        dtArticulos.ImportRow(oDataRowViewF.Row)
                    Next
                    dtArticulos.AcceptChanges()

                    oReporter.dtArticulos = dtArticulos
                    oReporter.FormatToReportAuditoria()

                    Dim oReport As New rptAuditoria
                    oReporter.dtToReport.DefaultView.RowFilter = "Diferencia <> 0 or DiferenciaTalla = 'X' "
                    oReporter.dtToReport.DefaultView.Sort = "CodFamilia,CodMarca,CodLinea,CodProv,CodArticulo"
                    oReport.DataSource = oReporter.dtToReport.DefaultView
                    oReport.Run()

                    Dim oReportViewer As New ReportViewerForm
                    oReportViewer.Report = oReport
                    oReportViewer.ShowDialog()

                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try

            Case "menuImprimirFamiliaMarcaLinea"
                Try
                    Cursor.Current = Cursors.WaitCursor
                    If Not Me.dgMateriales.GetValue(0) Is Nothing Then
                        Dim oReporter As New Reporter
                        Dim dtArticulos As DataTable = Me.dtAllUPCReport.Clone

                        Dim oDataView As New DataView(dtAllUPCReport, "CodMarca ='" & Me.dgMateriales.GetValue("CodMarca") & "' and " & _
                        "CodFamilia='" & Me.dgMateriales.GetValue("CodFamilia") & "' and CodLinea ='" & Me.dgMateriales.GetValue("CodLinea") & "'", "CodArticulo", DataViewRowState.CurrentRows)

                        For Each oDataRowViewF As DataRowView In oDataView
                            oDataRowViewF("CodArticulo") = CStr(oDataRowViewF("CodArticulo")).Trim.TrimStart("0")
                            dtArticulos.ImportRow(oDataRowViewF.Row)
                        Next

                        dtArticulos.AcceptChanges()

                        oReporter.dtArticulos = dtArticulos
                        oReporter.FormatToReportAuditoria()

                        Dim oReport As New rtpAuditoriaLineaFamilia
                        oReporter.dtToReport.DefaultView.RowFilter = " Diferencia <> 0 or DiferenciaTalla = 'X' "
                        oReporter.dtToReport.DefaultView.Sort = "CodLinea,CodProv,CodArticulo"
                        oReport.DataSource = oReporter.dtToReport.DefaultView
                        oReport.Run()

                        Dim oReportViewer As New ReportViewerForm
                        oReportViewer.Report = oReport
                        oReportViewer.ShowDialog()
                    Else
                        MessageBox.Show("Para imprimir Diferencias de Inventario se requiere estar posicionado en un material", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try

            Case "menuDiferenciasInventario"
                Try
                    Cursor.Current = Cursors.WaitCursor
                    If Not Me.dgMateriales.GetValue(0) Is Nothing Then
                        Dim oReporter As New Reporter
                        Dim dtArticulos As DataTable = Me.dtAllUPCReport.Clone

                        Dim oDataView As New DataView(dtAllUPCReport, "CodMarca ='" & Me.dgMateriales.GetValue("CodMarca") & "' and " & _
                        "CodFamilia='" & Me.dgMateriales.GetValue("CodFamilia") & "' and CodLinea ='" & Me.dgMateriales.GetValue("CodLinea") & "'", "CodArticulo", DataViewRowState.CurrentRows)

                        For Each oDataRowViewF As DataRowView In oDataView
                            oDataRowViewF("CodArticulo") = CStr(oDataRowViewF("CodArticulo")).Trim.TrimStart("0")
                            dtArticulos.ImportRow(oDataRowViewF.Row)
                        Next

                        dtArticulos.AcceptChanges()

                        oReporter.dtArticulos = dtArticulos
                        oReporter.FormatAReportDiferenciasInventario()

                        Dim oReport As New rptDiferenciasInventario("Familia: " & Me.dgMateriales.GetValue("DesFamilia") & "  Marca: " & Me.dgMateriales.GetValue("DesMarca") & "  Linea: " & Me.dgMateriales.GetValue("DesLinea"))
                        oReport.DataSource = oReporter.dtAReport.DefaultView
                        oReport.Run()

                        Dim oReportViewer As New ReportViewerForm
                        oReportViewer.Report = oReport
                        oReportViewer.ShowDialog()
                    Else
                        MessageBox.Show("Para imprimir las Diferencias de Inventario se requiere estar posicionado en un material", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            Case "menuOpcionesGuardarLectura"
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim dsLectura As New DataSet
                    If Not dtAllUPCReport Is Nothing AndAlso dtAllUPCReport.Rows.Count > 0 Then

                        dsLectura.Tables.Add(Me.dtAllUPCReport)
                        dsLectura.WriteXml(Application.StartupPath & "\Auditoria.xml", XmlWriteMode.WriteSchema)


                        MessageBox.Show("Informacion guardada", "Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No hay información a guardar", "Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try


            Case "menuOpcionesCargarLectura"
                Try
                    Cursor.Current = Cursors.WaitCursor
                    Dim dsLectura As New DataSet
                    If IO.File.Exists(Application.StartupPath & "\Auditoria.xml") Then
                        dsLectura.ReadXml(Application.StartupPath & "\Auditoria.xml", XmlWriteMode.WriteSchema)
                        dtAllUPCReport = New DataTable
                        Me.dtAllUPCReport = dsLectura.Tables(0).Copy

                        dtAllUPCReport.AcceptChanges()

                        dtAllUPCReport.DefaultView.RowFilter = "Diferencia <> 0"
                        dtAllUPCReport.DefaultView.Sort = "CodLinea,CodArticulo,Talla"
                        dtAllUPCReport.AcceptChanges()
                        Me.dgMateriales.DataSource = dtAllUPCReport.DefaultView
                        Application.DoEvents()
                        MessageBox.Show("Informacion cargada", "Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No hay información a cargar", "Auditoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            Case "menuSalir"
                Me.Close()
        End Select
    End Sub

    Private Sub frmAuditoria_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("La informacion no guardada se perderá. ¿Desea Salir?", "Auditoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '---------------------------------------------------------------------------------------
        'JNAVA 25.06.2014: Configuracion para usar en auditoria, la lectora CS3070
        '---------------------------------------------------------------------------------------
        If oConfigCierreFI.AuditoriaLectoraCS3070 = False Then
            Me.UiCommandBar1.Commands("menuRecolectora").Commands("menuRecolectoraCargaAutomatica").Commands("menuCS3070").Visible = InheritableBoolean.False
        End If
        Me.UiCommandBar1.Commands("menuOpciones").Commands("MnuCargarTodo").Checked = InheritableBoolean.True

        '-------------------------------------------------------------------------------
        ' JNAVA (17.03.2017): Preguntamos si desea hacer la descarga de existencias
        '-------------------------------------------------------------------------------
        If MessageBox.Show("¿Desea realizar la descarga de existencias?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ActualizarInventario()
        End If
        '-------------------------------------------------------------------------------

    End Sub

#End Region

    '---------------------------------------------------------------------------------------------------------
    'JNAVA 18.02.2016: Función que verifica si esta disponible la ruta que simula a Lectora CS3070
    '---------------------------------------------------------------------------------------------------------
    Private Function BuscaLectoraRuta(ByRef RutaLayout As String, ByVal NombreCarpeta As String, ByVal NombreArchivo As String) As Boolean
        Dim bResult As Boolean = False

        Try

            If Directory.Exists("C:\" & NombreCarpeta) Then
                Dim Ruta As String
                Ruta = "C:\" & NombreCarpeta & "\" & NombreArchivo
                RutaLayout = Ruta
                bResult = True
            End If

            Return bResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub SaveGridData(ByVal dtView As DataView)
        Dim myDRV As DataRowView
        Dim i As Integer
        Dim path As String = "C:\Users\raymundo.germain\Desktop\MyTest.txt"
        Dim sw As StreamWriter

        sw = New StreamWriter(path)

        For Each myDRV In dtView
            For i = 0 To dtView.Table.Columns.Count - 1
                sw.Write(myDRV(i) & vbTab)       '--------->ERROR
            Next
            sw.WriteLine()
        Next
        sw.Close()
    End Sub

    '---------------------------------------------------------------------------------------------------------
    ' JNAVA 17.03.2017: Función para actualizar inventario
    '---------------------------------------------------------------------------------------------------------
    Private Sub ActualizarInventario()
        Dim ofrmLoad As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        ofrmLoad.Timer1.Enabled = False
        ofrmLoad.ShowDev("Descuentos")
        ofrmLoad.ShowDev("Inventarios")
        ofrmLoad.ShowDev("CodigosUPC")
    End Sub

End Class
