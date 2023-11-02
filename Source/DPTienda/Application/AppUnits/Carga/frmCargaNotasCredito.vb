Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasCorrida
Imports System.Data
Imports System.Linq
Imports DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ValeCaja
Imports Janus.Windows.GridEX
Imports System.Collections.Generic
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoFormasPago
Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU

Public Class frmCargaNotasCredito
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
    Friend WithEvents ArchivoCommand As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Protected Friend WithEvents btnCargar As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents uigbResults As Janus.Windows.EditControls.UIGroupBox
    Protected Friend WithEvents geResults As Janus.Windows.GridEX.GridEX
    Protected Friend WithEvents uigbParameters As Janus.Windows.EditControls.UIGroupBox
    Protected Friend WithEvents uicmEnvironment As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Protected Friend WithEvents btnAplicar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ArchivoCerrarCommand2 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UiCommandCategory1 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory2 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim UiCommandCategory3 As Janus.Windows.UI.CommandBars.UICommandCategory = New Janus.Windows.UI.CommandBars.UICommandCategory()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaNotasCredito))
        Me.uicmEnvironment = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.uicbEnvironmentMenusBar = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.ArchivoCerrarCommand2 = New Janus.Windows.UI.CommandBars.UICommand("ArchivoCerrarCommand")
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
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.btnAplicar = New Janus.Windows.EditControls.UIButton()
        Me.btnCargar = New Janus.Windows.EditControls.UIButton()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.uicmEnvironment.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar})
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
        Me.uicbEnvironmentMenusBar.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.ArchivoCerrarCommand2})
        Me.uicbEnvironmentMenusBar.Key = "Barra de Menus"
        Me.uicbEnvironmentMenusBar.Location = New System.Drawing.Point(0, 0)
        Me.uicbEnvironmentMenusBar.Name = "uicbEnvironmentMenusBar"
        Me.uicbEnvironmentMenusBar.RowIndex = 0
        Me.uicbEnvironmentMenusBar.Size = New System.Drawing.Size(1006, 22)
        Me.uicbEnvironmentMenusBar.Text = "Barra de Menús"
        '
        'ArchivoCerrarCommand2
        '
        Me.ArchivoCerrarCommand2.Key = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand2.Name = "ArchivoCerrarCommand2"
        Me.ArchivoCerrarCommand2.Text = "Salir"
        Me.ArchivoCerrarCommand2.ToolTipText = "Salir"
        Me.ArchivoCerrarCommand2.Visible = Janus.Windows.UI.InheritableBoolean.[True]
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
        Me.ArchivoImprimirCommand.ToolTipText = "Imprimir"
        Me.ArchivoImprimirCommand.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'ArchivoCerrarCommand
        '
        Me.ArchivoCerrarCommand.CategoryName = "Archivo"
        Me.ArchivoCerrarCommand.Key = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand.Name = "ArchivoCerrarCommand"
        Me.ArchivoCerrarCommand.Text = "Cerrar"
        Me.ArchivoCerrarCommand.ToolTipText = "Cerrar"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.uicbEnvironmentMenusBar})
        Me.TopRebar1.CommandManager = Me.uicmEnvironment
        Me.TopRebar1.Controls.Add(Me.uicbEnvironmentMenusBar)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(1006, 22)
        '
        'uigbResults
        '
        Me.uigbResults.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarBackground
        Me.uigbResults.Controls.Add(Me.geResults)
        Me.uigbResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uigbResults.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uigbResults.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbResults.Location = New System.Drawing.Point(0, 61)
        Me.uigbResults.Name = "uigbResults"
        Me.uigbResults.Padding = New System.Windows.Forms.Padding(4)
        Me.uigbResults.Size = New System.Drawing.Size(1006, 376)
        Me.uigbResults.TabIndex = 1
        Me.uigbResults.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'geResults
        '
        Me.geResults.ControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.geResults.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.geResults.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.geResults.GroupByBoxVisible = False
        Me.geResults.Location = New System.Drawing.Point(4, 4)
        Me.geResults.Name = "geResults"
        Me.geResults.Size = New System.Drawing.Size(998, 368)
        Me.geResults.TabIndex = 0
        '
        'uigbParameters
        '
        Me.uigbParameters.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Rebar
        Me.uigbParameters.Controls.Add(Me.btnExportar)
        Me.uigbParameters.Controls.Add(Me.btnAplicar)
        Me.uigbParameters.Controls.Add(Me.btnCargar)
        Me.uigbParameters.Dock = System.Windows.Forms.DockStyle.Top
        Me.uigbParameters.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uigbParameters.FrameStyle = Janus.Windows.EditControls.FrameStyle.None
        Me.uigbParameters.Location = New System.Drawing.Point(0, 22)
        Me.uigbParameters.Name = "uigbParameters"
        Me.uigbParameters.Size = New System.Drawing.Size(1006, 39)
        Me.uigbParameters.TabIndex = 0
        Me.uigbParameters.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(850, 1)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(144, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Location = New System.Drawing.Point(700, 1)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(144, 32)
        Me.btnAplicar.TabIndex = 1
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCargar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Location = New System.Drawing.Point(548, 1)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(144, 32)
        Me.btnCargar.TabIndex = 0
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'dlgArchivo
        '
        Me.dlgArchivo.CheckFileExists = False
        Me.dlgArchivo.DefaultExt = "xls"
        Me.dlgArchivo.Filter = "Archivos Excel (*.txt)|*.txt"
        '
        'frmCargaNotasCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1006, 437)
        Me.Controls.Add(Me.uigbResults)
        Me.Controls.Add(Me.uigbParameters)
        Me.Controls.Add(Me.TopRebar1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(520, 280)
        Me.Name = "frmCargaNotasCredito"
        Me.Text = "Carga Notas de Crédito"
        CType(Me.uicmEnvironment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uicbEnvironmentMenusBar, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "Constantes"
    Private Const SEPARADORVALORES As String = ","

    'Valores Producción
    Private Const I_KUNNR As Integer = 50000070

    'Valores QA
    'Private Const I_KUNNR As Integer = 50000060

#End Region

#Region "Variables"

    Private oFacturaCorridaMgr As FacturaCorridaManager
    Private oFacturaMgr As FacturaManager
    Private oFacturaFormaPago As FacturaFormaPago
    Private oArticulo As Articulo
    Private oCatalogoArticulosMgr As CatalogoArticuloManager
    Private oNotaCredito As NotaCredito
    Private oNotasCreditoMgr As NotasCreditoMasivoManager
    Private oCliente As ClienteAlterno
    Private oCatalogoClientesMgr As ClientesManager
    Private oValeCaja As ValeCaja
    Private oValeCajaMgr As ValeCajaManager
    Private oProcesosSAPMgr As ProcesoSAPManager
    Private oCajaMgr As CatalogoCajaManager
    Private oCatFormaPago As CatalogoFormasPagoManager
    Private oCierreDiasMgr As CierreDiaManager
    Private strTablaTmp As String = "NotaCreditoMasDetalleTmp" & oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & oAppContext.Security.CurrentUser.ID

#End Region


#Region "Eventos"

    ''' <summary>
    ''' Función para cerrar la forma
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Overridable Sub ActionClose()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Evento para el control del menú
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub uicmEnvironment_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles uicmEnvironment.CommandClick

        Select Case e.Command.Key

            Case ArchivoCerrarCommand.Key

                ActionClose()

        End Select

    End Sub


    ''' <summary>
    ''' Evento de la forma para control de los tabs
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridReportBaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    ''' <summary>
    ''' Evento para la carga de información del archivo al grid
    ''' Ejecuta las validaciones a la información cargada registro a registro
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        If dlgArchivo.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Dim strError As String = String.Empty
            geResults.DataSource = Nothing
            Dim datos As DataTable = oNotasCreditoMgr.ValidaArchivo(dlgArchivo.FileName, strError)
            If strError <> String.Empty Then
                MessageBox.Show(strError, "DPPro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            geResults.DataSource = datos
            Cursor = Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' Evento ejecutado en la carga de la forma para inicializar los managers y la tabla de datos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCargaNotasCredito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        With geResults
            .RootTable = New GridEXTable
            With .RootTable.Columns
                .Add("selector")
                '.Add("Seleccionado", ColumnType.CheckBox, EditType.CheckBox)
                .Add("CodAlmacen", ColumnType.Text, EditType.NoEdit)
                .Add("TipoVenta", ColumnType.Text, EditType.NoEdit)
                .Add("CodCliente", ColumnType.Text, EditType.NoEdit)
                .Add("FolioDPPRO", ColumnType.Text, EditType.NoEdit)
                .Add("FolioSAP", ColumnType.Text, EditType.NoEdit)
                .Add("CodArticulo", ColumnType.Text, EditType.NoEdit)
                .Add("Talla", ColumnType.Text, EditType.NoEdit)
                .Add("Cantidad", ColumnType.Text, EditType.NoEdit)
                .Add("PrecioUnit", ColumnType.Text, EditType.NoEdit)
                .Add("Descuento", ColumnType.Text, EditType.NoEdit)
                .Add("PrecioFinal", ColumnType.Text, EditType.NoEdit)
                .Add("CodFormaPago", ColumnType.Text, EditType.NoEdit)
                .Add("Importe", ColumnType.Text, EditType.NoEdit)
                .Add("DPValeID", ColumnType.Text, EditType.NoEdit)
                .Add("FolioDist", ColumnType.Text, EditType.NoEdit)
                .Add("FolioNotaCredito", ColumnType.Text, EditType.NoEdit)
                .Add("FolioValeCaja", ColumnType.Text, EditType.NoEdit)
                .Add("MontoValeCaja", ColumnType.Text, EditType.NoEdit)
                .Add("FacturaId", ColumnType.Text, EditType.NoEdit)
                .Add("Mensaje", ColumnType.Text, EditType.NoEdit)
                .Add("Registro", ColumnType.Text, EditType.NoEdit)
                .Add("Referencia", ColumnType.Text, EditType.NoEdit)
                .Add("NotaCreditoID", ColumnType.Text, EditType.NoEdit)
                .Add("FIDocument", ColumnType.Text, EditType.NoEdit)

                'Estatus del registro (1 procesado, 2 facturado)
                .Add("Estatus", ColumnType.Text, EditType.NoEdit)

                'datos de la nueva factura
                .Add("FTipoVenta", ColumnType.Text, EditType.NoEdit)
                .Add("FCodCliente", ColumnType.Text, EditType.NoEdit)
                .Add("FFolioDPPRO", ColumnType.Text, EditType.NoEdit)
                .Add("FFolioSAP", ColumnType.Text, EditType.NoEdit)
                .Add("FCodArticulo", ColumnType.Text, EditType.NoEdit)
                .Add("FTalla", ColumnType.Text, EditType.NoEdit)
                .Add("FCantidad", ColumnType.Text, EditType.NoEdit)
                .Add("FPrecioUnit", ColumnType.Text, EditType.NoEdit)
                .Add("FDescuento", ColumnType.Text, EditType.NoEdit)
                .Add("FPrecioFinal", ColumnType.Text, EditType.NoEdit)
                .Add("FFolioValeCaja", ColumnType.Text, EditType.NoEdit)
                .Add("FMontoValeCaja", ColumnType.Text, EditType.NoEdit)
                .Add("FDiferenciaPago", ColumnType.Text, EditType.NoEdit)
                .Add("FCodFormaPago", ColumnType.Text, EditType.NoEdit)
                .Add("FImporte", ColumnType.Text, EditType.NoEdit)
                .Add("FDPValeID", ColumnType.Text, EditType.NoEdit)
                .Add("FFolioDist", ColumnType.Text, EditType.NoEdit)
                .Add("FMensaje", ColumnType.Text, EditType.NoEdit)
                .Add("FFacturaId", ColumnType.Text, EditType.NoEdit)
                .Add("FReferencia", ColumnType.Text, EditType.NoEdit)
                .Add("FSerialId", ColumnType.Text, EditType.NoEdit)
                .Add("FTotalFactura", ColumnType.Text, EditType.NoEdit)

                'Compensaciones
                .Add("CMensaje", ColumnType.Text, EditType.NoEdit)
                .Add("CDocumento", ColumnType.Text, EditType.NoEdit)
                .Add("CDocumentoFinanciero", ColumnType.Text, EditType.NoEdit)

                .Item("Selector").ActAsSelector = True
                .Item("CodAlmacen").Caption = "Sucursal"
                .Item("TipoVenta").Caption = "Tipo de Venta"
                .Item("CodCliente").Caption = "Folio del cliente"
                .Item("FolioDPPRO").Caption = "Folio DPPRO de la venta original"
                .Item("FolioSAP").Caption = "Folio SAP de la venta original"
                .Item("CodArticulo").Caption = "Artículo"
                .Item("Talla").Caption = "Talla"
                .Item("Cantidad").Caption = "Cantidad"
                .Item("PrecioUnit").Caption = "Precio público"
                .Item("PrecioFinal").Caption = "Precio final pagado"
                .Item("CodFormaPago").Caption = "Forma de Pago"
                .Item("Importe").Caption = "Monto por forma de pago"
                .Item("DPValeID").Caption = "Folio del vale"
                .Item("FolioDist").Caption = "No. Distribuidor"
                .Item("FFacturaId").Caption = "Factura Generada"

                'Resultados
                .Item("FolioNotaCredito").Caption = "Folio de la Nota de Credito"
                .Item("FolioNotaCredito").CellStyle.BackColor = Color.Green
                .Item("FolioValeCaja").Caption = "Folio de Vale de Caja"
                .Item("FolioValeCaja").CellStyle.BackColor = Color.Green
                .Item("MontoValeCaja").Caption = "Monto de Vale de Caja"
                .Item("MontoValeCaja").CellStyle.BackColor = Color.Green
                .Item("Mensaje").CellStyle.BackColor = Color.Red
                .Item("Referencia").Bound = False

                .Item("Estatus").Visible = False

                'datos de la nueva factura
                .Item("FTipoVenta").Caption = "Tipo de Venta"
                .Item("FCodCliente").Caption = "Folio del cliente"
                .Item("FFolioDPPRO").Caption = "Folio DPPRO de la venta original"
                .Item("FFolioSAP").Caption = "Folio SAP de la venta original"
                .Item("FCodArticulo").Caption = "Artículo"
                .Item("FTalla").Caption = "Talla"
                .Item("FCantidad").Caption = "Cantidad"
                .Item("FPrecioUnit").Caption = "Precio público"
                .Item("FDescuento").Caption = "Descuento"
                .Item("FPrecioFinal").Caption = "Precio final pagado"
                .Item("FFolioValeCaja").Caption = "Folio Vale Caja"
                .Item("FMontoValeCaja").Caption = "Monto Vale Caja"
                .Item("FDiferenciaPago").Caption = "Diferencia"
                .Item("FCodFormaPago").Caption = "Forma de Pago"
                .Item("FImporte").Caption = "Monto por forma de pago"
                .Item("FDPValeID").Caption = "Folio del vale"
                .Item("FFolioDist").Caption = "No. Distribuidor"
                .Item("FMensaje").Caption = "Mensaje Factura"
                .Item("FTotalFactura").Caption = "Total Factura"
                .Item("FTotalFactura").Bound = False
                .Item("FReferencia").CellStyle.BackColor = Color.Green
                .Item("FSerialId").CellStyle.BackColor = Color.Green
                .Item("FMensaje").CellStyle.BackColor = Color.Red

                'Compensaciones
                .Item("CMensaje").Caption = "Mensaje Compensaciones"
                .Item("CMensaje").CellStyle.BackColor = Color.Red
                .Item("CMensaje").Bound = False
                .Item("CDocumento").Caption = "Documento"
                .Item("CDocumento").Bound = False
                .Item("CDocumento").CellStyle.BackColor = Color.Green
                .Item("CDocumentoFinanciero").Caption = "Documento Financiero"
                .Item("CDocumentoFinanciero").Bound = False
                .Item("CDocumentoFinanciero").CellStyle.BackColor = Color.Red

            End With
        End With

        oFacturaCorridaMgr = New FacturaCorridaManager(oAppContext)
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFacturaFormaPago = New FacturaFormaPago(oAppContext)
        oCatalogoArticulosMgr = New CatalogoArticuloManager(oAppContext)
        oNotasCreditoMgr = New NotasCreditoMasivoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        oCatalogoClientesMgr = New ClientesManager(oAppContext)
        oValeCajaMgr = New ValeCajaManager(oAppContext)
        oProcesosSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCatFormaPago = New CatalogoFormasPagoManager(oAppContext)
        oCierreDiasMgr = New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
    End Sub

    ''' <summary>
    ''' Evento que guarda la información de los registros seleccionados a SAP y la BD
    ''' Utiliza los componentes existentes del módulo de nota de crédito
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAplicar_Click(sender As System.Object, e As System.EventArgs) Handles btnAplicar.Click

        If geResults.GetRows.Count = 0 Then
            MessageBox.Show("No se ha cargado el archivo de datos", "DPPro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        'DirectCast(geResults.DataSource,System.Data.DataTable).Select("Seleccionado = 'True'")
        For Each registro As GridEXRow In geResults.GetCheckedRows
            Dim resultado As Boolean
            If registro.Cells("Estatus").Value.ToString = 0 Then
                resultado = GeneraNotaCredito(registro)
            End If
            If registro.Cells("FTipoVenta").Value <> String.Empty AndAlso Not oNotaCredito Is Nothing AndAlso oNotaCredito.ID > 0 AndAlso (registro.Cells("Estatus").Value.ToString = "1" OrElse resultado) Then 'Si esta registrado como procesada la nota de crédito o se generó la nota de crédito
                GenerarFactura(registro)
            End If
        Next
        GenerarAbonoCierre((From registro As GridEXRow In geResults.GetRows Where registro.Cells("NotaCreditoID").Value IsNot DBNull.Value AndAlso registro.Cells("NotaCreditoID").Value IsNot Nothing AndAlso registro.Cells("NotaCreditoID").Value <> "0" Select registro).ToList(), "")
        GenerarAbonoCierreDiaVenta((From registro As GridEXRow In geResults.GetRows Where registro.Cells("FFacturaId").Value IsNot DBNull.Value AndAlso registro.Cells("FFacturaId").Value IsNot Nothing AndAlso registro.Cells("FFacturaId").Value <> "0" Select registro).ToList())
        Compensar((From registro As GridEXRow In geResults.GetRows Where registro.Cells("FFacturaId").Value IsNot DBNull.Value AndAlso registro.Cells("NotaCreditoID").Value IsNot Nothing AndAlso registro.Cells("NotaCreditoID").Value IsNot DBNull.Value AndAlso registro.Cells("FFacturaId").Value IsNot Nothing AndAlso registro.Cells("NotaCreditoID").Value <> "0" AndAlso registro.Cells("FFacturaId").Value <> "0" Select registro).ToList())
        MessageBox.Show("Proceso terminado, validar la columna mensajes para detalle por registro del proceso", "DPPro", MessageBoxButtons.OK)
        Me.Cursor = Cursors.Default
    End Sub


    ''' <summary>
    ''' Evento que se ejecuta al pintar de gris el registro
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub geResults_LoadingRow(sender As System.Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles geResults.LoadingRow
        If e.Row.Cells("Mensaje").Value <> String.Empty OrElse e.Row.Cells("FMensaje").Value <> String.Empty Then
            e.Row.RowStyle = New Janus.Windows.GridEX.GridEXFormatStyle(e.Row.Table.RowFormatStyle)
            e.Row.RowStyle.BackColor = Color.Silver
        End If
        If DirectCast(e.Row.DataRow, System.Data.DataRowView)("ColumnasCambiadas").ToString().Length > 0 Then


            Dim columnasCambiadas() As String = DirectCast(e.Row.DataRow, System.Data.DataRowView)("ColumnasCambiadas").ToString().Split(",")

            Dim normalGridEXFormatStyle As New GridEXFormatStyle()
            normalGridEXFormatStyle.BackColor = Color.Transparent

            Dim cambiadoGridEXFormatStyle As New GridEXFormatStyle()
            cambiadoGridEXFormatStyle.BackColor = Color.Yellow


            e.Row.Cells("TipoVenta").FormatStyle = IIf(columnasCambiadas(0) = "0", normalGridEXFormatStyle, cambiadoGridEXFormatStyle)
            e.Row.Cells("CodArticulo").FormatStyle = IIf(columnasCambiadas(1) = "0", normalGridEXFormatStyle, cambiadoGridEXFormatStyle)
            e.Row.Cells("PrecioUnit").FormatStyle = IIf(columnasCambiadas(2) = "0", normalGridEXFormatStyle, cambiadoGridEXFormatStyle)
            e.Row.Cells("Descuento").FormatStyle = IIf(columnasCambiadas(3) = "0", normalGridEXFormatStyle, cambiadoGridEXFormatStyle)
            e.Row.Cells("PrecioFinal").FormatStyle = IIf(columnasCambiadas(4) = "0", normalGridEXFormatStyle, cambiadoGridEXFormatStyle)
        End If
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta al seleccionar manualmente un registro del grid
    ''' se controla si el registro trae mensaje de error para no permitir la selección y seleccionar el registro contiguo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub geResults_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles geResults.SelectionChanged
        ValidaSeleccionados()
    End Sub

    ''' <summary>
    ''' Función que se ejecuta el hacer click en el checkbox seleccionarTodos
    ''' se busca los registros que sean inválidos para desmarcarlos ya que el evento selectionchanged no se ejecuta en el selectall
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub geResults_ColumnHeaderClick(sender As System.Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles geResults.ColumnHeaderClick
        ValidaSeleccionados()
    End Sub

    Private Sub geResults_Click(sender As System.Object, e As System.EventArgs) Handles geResults.Click
        ValidaSeleccionados()
    End Sub

    Private Sub geResults_DblClick(sender As System.Object, e As System.EventArgs) Handles geResults.DoubleClick
        ValidaSeleccionados()
    End Sub

    Private Sub geResults_CellValueChanged(sender As System.Object, e As System.EventArgs) Handles geResults.CellValueChanged
        ValidaSeleccionados()
    End Sub

    Private Sub geResults_Validating(sender As System.Object, e As System.EventArgs) Handles geResults.Validating
        ValidaSeleccionados()
    End Sub

    Private Sub geResults_FormattingRow(sender As System.Object, e As System.EventArgs) Handles geResults.FormattingRow
        ValidaSeleccionados()
    End Sub


    ''' <summary>
    ''' Función para exportar la información del grid a un archivo excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        Dim SaveDialog = New SaveFileDialog
        Dim strRuta As String = String.Empty

        Dim xlapp
        Dim wbxl
        Dim wsxl

        Dim intRow As Integer 'counter

        Dim oRow As DataRow
        Dim oCol As DataColumn


        Me.Cursor = Cursors.WaitCursor

        Try

            xlapp = GetObject(, "Excel.Application")

            If xlapp Is Nothing Then
                xlapp = CreateObject("Excel.Application")
                If xlapp Is Nothing Then
                    MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Vales de Caja")
                    Exit Sub
                End If
            Else
                xlapp = CreateObject("Excel.Application")
            End If

            wbxl = xlapp.Workbooks.Add
            wsxl = xlapp.Sheets(1)
            wsxl.Name = "Notas"

            '****************************************
            'HOJA DE CALCULO
            '****************************************

            For columnaIndice As Integer = 1 To geResults.RootTable.Columns.Count - 1
                wsxl.Cells(1, columnaIndice).Value = geResults.RootTable.Columns(columnaIndice).Caption
            Next
            For Each registro As GridEXRow In geResults.GetRows
                For columnaIndice As Integer = 1 To geResults.RootTable.Columns.Count - 1
                    wsxl.Cells(registro.Position + 2, columnaIndice).NumberFormat = "@"
                    wsxl.Cells(registro.Position + 2, columnaIndice).Value = registro.Cells(columnaIndice).Value
                Next
            Next

            'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
            SaveDialog.DefaultExt = "*.xls"
            SaveDialog.Filter = "(*.xls)|*.xls"
            If SaveDialog.ShowDialog = DialogResult.OK Then
                wbxl.SaveAs(SaveDialog.FileName)
                MsgBox("Documento guardado en " & SaveDialog.FileName, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Notas de Crédito")
            End If

            wbxl.Close()
            wsxl = Nothing
            xlapp.Quit()
            xlapp = Nothing

            KillExcel()
        Catch ex As Exception

            Dim file As String = "LogCargaNotasCredito" & oAppContext.ApplicationConfiguration.Almacen & Date.Today.ToString("yyyy-MM-dd") & ".txt"
            Dim writer As New System.IO.StreamWriter(file, True)
            Dim linea As String = String.Empty
            writer.WriteLine("Proceso Carga de Notas de crédito")
            For columnaIndice As Integer = 1 To geResults.RootTable.Columns.Count - 1
                linea = linea & geResults.RootTable.Columns(columnaIndice).Caption & vbTab
            Next
            writer.WriteLine(linea)
            For Each registro As GridEXRow In geResults.GetRows
                linea = String.Empty
                For columnaIndice As Integer = 1 To geResults.RootTable.Columns.Count - 1
                    linea = linea & """" & registro.Cells(columnaIndice).Value & """" & vbTab
                Next
                writer.WriteLine(linea)
            Next
            writer.Close()
            MessageBox.Show("Se generó el archivo log " & file & " debido a un error al generar el archivo excel", "DPPro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default


    End Sub

#End Region

#Region "Funciones"


    ''' <summary>
    ''' Función para llenar el detalle de la nota de crédito
    ''' </summary>
    ''' <param name="Registro">registro del grid con los valores seleccionados</param>
    ''' <param name="oFactura">objeto factura de la cual se generará la nota de crédito</param>
    ''' <returns>Dataset con el detalle del producto a devolver</returns>
    ''' <remarks></remarks>
    Private Function ObtieneDetalle(ByRef Registro As GridEXRow, ByRef oFactura As Factura) As DataSet
        Dim detalle As New DataSet
        Dim oArticulo As Articulo

        oArticulo = oCatalogoArticulosMgr.Create
        oCatalogoArticulosMgr.LoadInto(Registro.Cells("CodArticulo").Value, oArticulo)

        Dim decPrecioOferta As Decimal = Decimal.Round(Convert.ToDecimal(Registro.Cells("PrecioUnit").Value.ToString()), 4)
        Dim PrecioUnit As Decimal = decPrecioOferta

        With detalle.Tables.Add("Detalle")
            With .Columns
                .Add("FolioReferencia", System.Type.GetType("System.String"))
                .Add("FacturaID", System.Type.GetType("System.String"))
                .Add("CodTipoVenta", System.Type.GetType("System.String"))
                .Add("ClienteID", System.Type.GetType("System.String"))
                .Add("CodArticulo", System.Type.GetType("System.String"))
                .Add("Descripcion", System.Type.GetType("System.String"))
                .Add("Numero", System.Type.GetType("System.String"))
                .Add("Cantidad", System.Type.GetType("System.String"))
                .Add("PrecioUnit", System.Type.GetType("System.String"))
                .Add("Importe", System.Type.GetType("System.String"))
                .Add("CostoUnit", System.Type.GetType("System.String"))
                .Add("CodCaja", System.Type.GetType("System.String"))
            End With
            .Rows.Add(New Object() {
                      oFactura.FolioFactura,
                      oFactura.FacturaID,
                      oFactura.CodTipoVenta,
                      CStr(oFactura.ClienteId).PadLeft(10, "0"),
                      Registro.Cells("CodArticulo").Value,
                    oArticulo.Descripcion,
                    Registro.Cells("Talla").Value,
                    Registro.Cells("Cantidad").Value,
                    PrecioUnit,
                      (Convert.ToInt32(Registro.Cells("Cantidad").Value) * PrecioUnit),
                    decPrecioOferta,
                    oFactura.CodCaja
                  })

        End With
        Return detalle
    End Function

    ''' <summary>
    ''' Función para validar si el registro debe ser seleccionado o no
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidaSeleccionados()
        If Not geResults Is Nothing AndAlso geResults.RowCount > 0 Then
            For Each registro As GridEXRow In geResults.GetCheckedRows
                If registro.IsChecked AndAlso registro.Cells("Mensaje").Value.ToString() <> String.Empty OrElse registro.Cells("FMensaje").Value.ToString() <> String.Empty Then
                    registro.IsChecked = False
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Función para generar la nota de crédito
    ''' </summary>
    ''' <param name="Registro">registro a procesar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GeneraNotaCredito(ByRef Registro As GridEXRow) As Boolean
        Dim decTotal As Decimal = 0D
        Dim subTotal As Decimal = 0D
        Dim iva As Decimal = 0D
        Dim porcentajeIva As Decimal = 0D
        Dim resultado As Boolean = True
        Dim oFactura As Factura = oFacturaMgr.Create

        oNotaCredito = Nothing
        oNotaCredito = oNotasCreditoMgr.Create

        oFactura = oFacturaMgr.Create
        oFactura.ClearFields()
        oFacturaMgr.LoadInto(Convert.ToInt32(Registro.Cells("FacturaID").Value), oFactura)
        oFactura.Detalle = oFacturaCorridaMgr.Load(oFactura.FacturaID)
        oCliente = oCatalogoClientesMgr.CreateAlterno
        oCliente.Clear()
        oNotasCreditoMgr.CrearTablaTmp(strTablaTmp)

        Dim productos As String() = Registro.Cells("CodArticulo").Value.ToString().Trim().Split(SEPARADORVALORES)
        Dim tallas As String() = Registro.Cells("Talla").Value.ToString().Trim().Split(SEPARADORVALORES)
        Dim cantidades As String() = Registro.Cells("Cantidad").Value.ToString().Trim().Split(SEPARADORVALORES)
        Dim preciosFinales As String() = Registro.Cells("PrecioFinal").Value.ToString().Trim().Split(SEPARADORVALORES)
        For contador As Integer = 0 To productos.Length - 1
            oArticulo = oCatalogoArticulosMgr.Load(productos(contador))
            oNotasCreditoMgr.AgregarArticulo(0, oArticulo, tallas(contador), cantidades(contador), oFactura, strTablaTmp)
            subTotal += Convert.ToDecimal(preciosFinales(contador))
        Next

        porcentajeIva = Decimal.Round((oFactura.IVA * 100 / oFactura.SubTotal) / 100, 2)
        iva = subTotal * porcentajeIva
        decTotal = subTotal + iva

        With oNotaCredito
            .FolioApartado = String.Empty
            .AlmacenID = oAppContext.ApplicationConfiguration.Almacen
            .CajaID = oFactura.CodCaja
            .PlayerID = oFactura.CodVendedor.Trim
            .ClienteID = IIf(oFactura.CodTipoVenta = "P", "10000000".PadLeft(10, "0"), oCliente.CodigoAlterno)
            .TipoDevolucionID = "EST" 'DEF EQU NEB RFF
            If oFactura.CodTipoVenta = "P" Then .ClientePGID = oCliente.CodigoAlterno
            If oFactura.CodTipoVenta = "A" Then
                .TipoVentaID = ""
            Else
                .TipoVentaID = oFactura.CodTipoVenta
            End If
            .Importe = decTotal
            .IVA = iva
            .Aplicada = "N"
            .DevDinero = "N"
            .Observaciones = (Registro.Position + 1).ToString().PadLeft(5, "0") 'Esta observación se envía como consecutivo a SAP, requerido
            .Usuario = oAppContext.Security.CurrentUser.SessionLoginName.Trim
            .Fecha = Date.Today
            .StatusRegistro = True
            .FolioSAP = IIf(Not oFactura Is Nothing, oFactura.FolioSAP, "")
            .Detalle = oNotasCreditoMgr.ActualizarDataSet("[NotaCreditoDetalleSelFromGRID]", strTablaTmp)
            .Referencia = "NAFS" & .AlmacenID & .CajaID & DateTime.Now.ToString("ssfff") 'oFactura.Referencia ' "DPVL-0013098302" 'Fijo requerido por SAP

        End With

        'A la tabla estandar hay que agregarle la columna descuento
        oNotaCredito.Detalle.Tables(0).Columns.Add("Descuento", Type.GetType("System.Decimal"))
        oNotaCredito.Detalle.Tables(0).Columns.Add("DescuentoSistema", Type.GetType("System.Decimal"))
        For Each articuloEnTemporal As DataRow In oNotaCredito.Detalle.Tables(0).Rows
            Try
                Dim articuloEnFactura As DataRow = oFactura.Detalle.Tables(0).Select("codArticulo='" & articuloEnTemporal("codArticulo") & "' and Cantidad = " & articuloEnTemporal("cantidad"))(0)
                articuloEnTemporal("Descuento") = articuloEnFactura("Descuento")
                articuloEnTemporal("DescuentoSistema") = articuloEnFactura("DescuentoSistema")
            Catch ex As Exception
            End Try
        Next

        Registro.BeginEdit()
        Dim strError As String = ""
        Try
            Registro.Cells("NotaCreditoID").Value = 0
            oNotaCredito.Save(oConfigCierreFI.UsarHuellas, Registro.Cells("FolioSAP").Value.ToString(), strError)
            If oNotaCredito.SALESDOCUMENT.Trim <> "" Then
                Registro.Cells("FolioNotaCredito").Value = oNotaCredito.SALESDOCUMENT
                Registro.Cells("NotaCreditoID").Value = oNotaCredito.ID
                Registro.Cells("FIDocument").Value = oNotaCredito.FIDOCUMENT
                Registro.Cells("Referencia").Value = oNotaCredito.Referencia
                Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & ". " & GenerarValeDeCaja(oFactura, Registro.Cells("TipoVenta").Value <> String.Empty)
                oValeCaja = oValeCajaMgr.Create
                oValeCaja = oValeCajaMgr.GetByFolioDocumento(oNotaCredito.SALESDOCUMENT)
                If Not oValeCaja Is Nothing Then
                    Registro.Cells("FolioValeCaja").Value = oValeCaja.ValeCajaID
                    Registro.Cells("MontoValeCaja").Value = oValeCaja.Importe
                ElseIf oNotaCredito.REVALE <> "" Then
                    Registro.Cells("FolioValeCaja").Value = oNotaCredito.REVALE
                    Dim oDPVale As New cDPVale
                    oDPVale.INUMVA = oNotaCredito.REVALE
                    oDPVale.I_RUTA = "X"
                    oDPVale = oProcesosSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)
                    Dim eRen As DataRow
                    If oDPVale.EEXIST = "S" Then
                        Registro.Cells("MontoValeCaja").Value = oDPVale.InfoDPVALE.Rows(0)("Monto")
                    Else
                        resultado = False
                        Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & ". " & "No se encontró el revale generado folio: " & oNotaCredito.REVALE
                    End If
                Else
                    resultado = False
                    Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & ". " & "No se registro el vale de caja"
                End If
                oFacturaMgr.InsertaFacturasNotasCreditoMasivo(Registro.Cells("Registro").Value, 1)
                Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & "Folio SAP: " & oNotaCredito.SALESDOCUMENT.Trim
            Else
                resultado = False
            End If
            Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & ". " & strError
        Catch ex As Exception
            Registro.Cells("Mensaje").Value = Registro.Cells("Mensaje").Value & ". " & ex.Message
            resultado = False
        End Try
        Registro.EndEdit()
        Return resultado
    End Function

    ''' <summary>
    ''' Función para generar el vale de caja de una factura en particular
    ''' </summary>
    ''' <param name="oFactura">objeto factura original de la nota de crédito</param>
    ''' <param name="GenerarRevale">Indica si se debe generar el revale para la nota de crédito</param>
    ''' <returns>string con el error en caso que exista</returns>
    ''' <remarks></remarks>
    Public Function GenerarValeDeCaja(ByVal oFactura As Factura, ByVal GenerarRevale As Boolean) As String
        Dim resultado As String
        Try
            '-----------------------------------------------------------------------------------------------------------------
            'Mostrar Distribucion Nota Credito :
            '-----------------------------------------------------------------------------------------------------------------
            Dim intAnticipoClienteID As Integer

            With oNotaCredito

                intAnticipoClienteID = oNotasCreditoMgr.DistribucionNotaCredito(.NotaCreditoFolio, .TipoDevolucionID, oCliente, "NC", strTablaTmp)

            End With

            Dim FrmDistribucionNotaCredito As New FrmDistribucionNotaCredito

            FrmDistribucionNotaCredito.NotaCredito = oNotaCredito
            FrmDistribucionNotaCredito.AnticipoID = intAnticipoClienteID
            FrmDistribucionNotaCredito.TipoVenaID = oNotaCredito.TipoVentaID
            FrmDistribucionNotaCredito.bShow = False
            FrmDistribucionNotaCredito.FacturasPorLiquidar = False
            resultado = FrmDistribucionNotaCredito.ProcesaDistribucion(GenerarRevale)

            FrmDistribucionNotaCredito.Dispose()
            FrmDistribucionNotaCredito = Nothing
        Catch ex As Exception
            resultado = "Error al generar el Vale de Caja: " & ex.ToString & "."
        End Try
        Return resultado
    End Function

    ''' <summary>
    ''' Función para generar el archivo de cierre y el llamado a SAP para el log, para las notas de crédito
    ''' </summary>
    ''' <param name="notasDeCredito">objeto de la nota de crédito</param>
    ''' <param name="tipoVenta">tipo de venta que se está procesando en ese momento</param>
    ''' <returns>string con el error en caso que exista</returns>
    ''' <remarks>Esta función tronará en caso que no se tenga acceso al ftp que se solicita para subir el archivo generado</remarks>
    Public Function GenerarAbonoCierre(ByRef notasDeCredito As List(Of GridEXRow), ByVal tipoVenta As String) As String
        If notasDeCredito.Count = 0 Then
            Exit Function
        End If

        Dim strError As String = ""

        For Each registro As GridEXRow In notasDeCredito
            Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                   GetConnectionString)
            Dim command As New SqlCommand("UpdateCompesarNotaCredito", conexion)
            Try
                conexion.Open()
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@NotaCreditoID", registro.Cells("NotaCreditoID").Value)
                command.ExecuteNonQuery()
                command.Dispose()
                conexion.Close()
            Catch sql As SqlException
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                strError = strError & sql.Message
            Catch ex As Exception
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                strError = strError & ex.Message
            End Try

        Next
        Return strError
    End Function

    ''' <summary>
    ''' Función para generar el archivo de cierre y el llamado a SAP para el log, para las ventas
    ''' </summary>
    ''' <param name="notasDeCredito">objeto de la nota de crédito</param>
    ''' <param name="tipoVenta">tipo de venta que se está procesando en ese momento</param>
    ''' <returns>string con el error en caso que exista</returns>
    ''' <remarks>Esta función tronará en caso que no se tenga acceso al ftp que se solicita para subir el archivo generado</remarks>
    Public Function GenerarAbonoCierreDiaVenta(ByRef facturas As List(Of GridEXRow)) As String
        If facturas.Count = 0 Then
            Exit Function
        End If

        Dim strError As String = ""


        For Each registro As GridEXRow In facturas
            Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                   GetConnectionString)
            Dim command As New SqlCommand("CierreDiaUpdFi05SAPFactura", conexion)
            Try
                conexion.Open()
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@FacturaId", registro.Cells("FFacturaId").Value)
                command.ExecuteNonQuery()
                command.Dispose()
                conexion.Close()
            Catch sql As SqlException
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                strError = strError & sql.Message
            Catch ex As Exception
                If conexion.State <> ConnectionState.Closed Then
                    conexion.Close()
                End If
                strError = strError & ex.Message
            End Try

        Next

        Return strError
    End Function

    ''' <summary>
    ''' Función para generar la factura con los valores requeridos por sap para este proceso
    ''' </summary>
    ''' <param name="Registro">registro a procesar</param>
    ''' <remarks></remarks>
    Private Sub GenerarFactura(ByRef Registro As GridEXRow)
        'Generamos la nueva factura
        Dim oFactura As Factura = oFacturaMgr.Create
        Dim oCaja As Caja = oCajaMgr.Create

        Try

            oFactura.ClearFields()
            oFactura.SerialId = oAppContext.ApplicationConfiguration.Almacen & oAppContext.ApplicationConfiguration.NoCaja & Guid.NewGuid().ToString()
            oCaja = oCajaMgr.Load(oAppContext.ApplicationConfiguration.NoCaja)
            oFactura.FolioFactura = oCaja.FolioFactura

            Dim oDPVale As cDPVale = ObtenerDatosVale(oNotaCredito.REVALE)

            oFactura.ClienteId = I_KUNNR

            'Mostramos Player
            oFactura.CodVendedor = oNotaCredito.PlayerID
            oFactura.CodTipoVenta = Registro.Cells("FTipoVenta").Value.ToString()
            oFactura.Fecha = oProcesosSAPMgr.MSS_GET_SY_DATE_TIME
            oFactura.NotaCreditoID = Convert.ToInt32(Registro.Cells("NotaCreditoID").Value)

            Dim fechaCobro As DateTime
            Dim dtDetalleVale As DataTable
            If oFactura.CodTipoVenta = "V" Then
                oFactura.Nquincenas = oProcesosSAPMgr.ZBAPI_OBTENER_NDESCUENTOS(oDPVale.EPLAZA, Date.Now.Date, Registro.Cells("MontoValeCaja").Value, oNotaCredito.REVALE, fechaCobro, dtDetalleVale)
            End If

            oFactura.Referencia = oNotaCredito.Referencia.Substring(1) 'debe llevar la misma referencia de la nota de crédito

            Registro.BeginEdit()
            Registro.Cells("FReferencia").Value = oFactura.Referencia
            Registro.Cells("FSerialId").Value = oFactura.SerialId
            Registro.Cells("FTotalFactura").Value = oFactura.Total

            Dim response As New Dictionary(Of String, Object)
            response = SaveFacturaRetail(Registro, oFactura, fechaCobro, (Registro.Position + 1))
            If response.ContainsKey("FolioSAP") Then
                oFactura.FolioSAP = CStr(response("FolioSAP"))
                oFactura.FolioFISAP = CStr(response("DocFi"))
                oFactura.REVALE = CStr(response("FolioRevale"))
            End If

            SaveFactura(Registro, oFactura)

            SaveRevale(Registro, oFactura, fechaCobro)


            Registro.Cells("FFacturaId").Value = oFactura.FacturaID
            If oFactura.FacturaID > 0 Then
                oFacturaMgr.SaveSerial(oFactura.SerialId, "S", oFactura.CodVendedor, oFactura.FacturaID)
            Else
                oFacturaMgr.SaveSerial(oFactura.SerialId, "E", oFactura.CodVendedor, 0)
            End If

            oFacturaMgr.InsertaFacturasNotasCreditoMasivo(Registro.Cells("Registro").Value, 2)
        Catch ex As Exception
            Registro.Cells("FMensaje").Value = Registro.Cells("FMensaje").Value & ". " & ex.Message
        End Try
        Registro.EndEdit()
    End Sub

    Public Function SaveRevale(ByRef Registro As GridEXRow, ByRef oFactura As Factura, ByVal FechaCobro As DateTime) As String
        Dim strerror As String = String.Empty
        Try
            If Registro.Cells("TipoVenta").Value.ToString() = "V" Then 'Se quema el revale generado
                Dim oGuardarRevale As New Dictionary(Of String, Object)
                Dim oDPVale As New cDPVale

                oDPVale = ObtenerDatosVale(Registro.Cells("FolioValeCaja").Value.ToString())
                If Not oDPVale Is Nothing Then
                    With oGuardarRevale
                        .Add("I_NUMVA", oDPVale.INUMVA.PadLeft(10, "0"))
                        .Add("I_NUMFA", oFactura.Referencia)
                        .Add("I_DOCFI", oFactura.FolioFISAP)
                        .Add("I_FACDPPRO", oFactura.FolioFactura.ToString().PadLeft(20, "0"))
                        .Add("I_FECHA", DateTime.Today.ToString("yyyyMMdd"))
                        .Add("I_FECHA2", FechaCobro.ToString("yyyyMMdd"))
                        .Add("I_CTEDIST", oDPVale.InfoDPVALE.Rows(0)("KUNNR").PadLeft(10, "0"))
                        .Add("I_NUMDE", oDPVale.InfoDPVALE.Rows(0)("NUMDE"))
                        .Add("I_OFICINAVTA", "T" & oAppContext.ApplicationConfiguration.Almacen)
                        .Add("I_MONTOUTILIZADO", Convert.ToDecimal(oDPVale.InfoDPVALE.Rows(0)("MONTO")).ToString("##,##0.00").Replace(",", "")) 'oFactura.Total
                        .Add("I_PARES_PZAS", oDPVale.InfoDPVALE.Rows(0)("PARES"))
                        .Add("I_MONTODPVALE", Convert.ToDecimal(oDPVale.InfoDPVALE.Rows(0)("MONTO")).ToString("##,##0.00").Replace(",", ""))
                        .Add("I_MONUS", oDPVale.InfoDPVALE.Rows(0)("MONUS"))
                        .Add("I_KUNNR", oDPVale.InfoDPVALE.Rows(0)("KUNNR").PadLeft(10, "0"))
                        .Add("I_REVALE", oDPVale.InfoDPVALE.Rows(0)("REVAL"))
                        .Add("I_STATUS", "B")
                        .Add("I_SIHAY", "")
                    End With
                    oNotasCreditoMgr.SapZsdProcesoRevale(oGuardarRevale, strerror)
                Else
                    strerror = "No se encontraron datos del REVALE " & Registro.Cells("FolioValeCaja").Value.ToString()
                End If
            End If
        Catch ex As Exception
            strerror = "Error al guardar el Revale: " & ex.Message
        End Try
        Return strerror
    End Function


    ''' <summary>
    ''' Función para generar la factura
    ''' </summary>
    ''' <param name="Registro">Registro a procesar</param>
    ''' <remarks></remarks>
    Public Function SaveFacturaRetail(ByRef Registro As GridEXRow, ByRef oFactura As Factura, ByVal FechaCobro As DateTime, ByVal posicion As Integer) As Dictionary(Of String, Object)
        Dim response As New Dictionary(Of String, Object)
        Dim oProcesarVenta As New Dictionary(Of String, Object)
        Dim oDPVale As New cDPVale

        With oProcesarVenta
            .Add("I_FECHA_CREACION", Format(oFactura.Fecha, "yyyy-MM-dd"))
            .Add("I_SOLICITANTE", oFactura.ClienteId)
            .Add("I_REFERENCIA", oFactura.Referencia)
            Dim CatalogoTipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oAppContext)

            .Add("I_REQUIERE_FACTURA", "")
            .Add("I_COSTO_ENVIO", 0)
            .Add("I_OFICINAVENTAS", "T" & oAppContext.ApplicationConfiguration.Almacen)
            .Add("I_MOT_PEDIDO", "ZFF")
            .Add("I_CLASEDOC", "")
            .Add("I_CANAL", "10")
            .Add("I_CEBE", "")
            .Add("I_CENTRO", "")
            .Add("I_GPOVENDEDOR", "")
            .Add("I_ORGVENTAS", "")
            .Add("I_SECTOR", "")
            .Add("I_VERSION_ID", "")
            .Add("I_REP_VENTAS", oFactura.CodVendedor)
            .Add("I_FOLIO", "")
            .Add("I_HORA", "")
            .Add("I_USUARIO", "")
            .Add("I_PLAZA", "")
            .Add("I_MONTO_TOTAL", 0)
            .Add("I_SERIALID", oFactura.SerialId)
            ' ------------------------------------------------------------------
            ' Llenamos datos de las Formas de Pago 
            '------------------------------------------------------------------
            Dim oFormasPago As New List(Of Dictionary(Of String, Object))

            Dim formas As String = Registro.Cells("FCodFormaPago").Value.ToString().Trim()
            Dim montosFormasPago As String = Registro.Cells("FImporte").Value.ToString().Trim()

            'Agregamos el monto de caja generado
            If Registro.Cells("TipoVenta").Value = "V" Then 'Se genero un revale
                formas = formas & ",DPVL"
                montosFormasPago = montosFormasPago & "," & Registro.Cells("MontoValeCaja").Value.ToString()
            Else 'se genero un vale de caja
                formas = formas & ",VCJA"
                montosFormasPago = montosFormasPago & "," & Registro.Cells("MontoValeCaja").Value.ToString()
            End If

            Dim aformasPago() As String = formas.Split(SEPARADORVALORES)
            Dim amontosFormasPago() As String = montosFormasPago.Split(SEPARADORVALORES)

            For indice As Integer = 0 To aformasPago.Length - 1
                If aformasPago(indice) <> "" Then
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oPago As New Dictionary(Of String, Object)
                    With oPago
                        .Add("FORMA_PAGO", aformasPago(indice))
                        .Add("IMPORTE", CDec(amontosFormasPago(indice)).ToString("##,##0.00").Replace(",", ""))
                        .Add("REFERENCIA", "")
                        .Add("FOLIO", "")
                        .Add("PER_FINANC", "")
                        .Add("NUM_APROBACION", "")

                        oDPVale = Nothing
                        'sabemos que si el tipo de venta original fue vale entonces se generó un revale
                        If aformasPago(indice) = "DPVL" Then
                            If Registro.Cells("TipoVenta").Value.ToString() = "V" Then 'vale
                                oDPVale = ObtenerDatosVale(Registro.Cells("FolioValeCaja").Value.ToString())
                            Else 'si es una venta normal entonces se pudo pagar la diferencia con dpvale
                                oDPVale = ObtenerDatosVale(Registro.Cells("FDPValeID").Value.ToString())
                            End If
                        End If

                        If Not oDPVale Is Nothing Then
                            .Add("NUMVA", oDPVale.INUMVA.PadLeft(10, "0"))
                            .Add("NUMDE", oDPVale.InfoDPVALE.Rows(0)("NUMDE")) ''
                            .Add("DISTRIB", oDPVale.InfoDPVALE.Rows(0)("KUNNR").PadLeft(10, "0"))
                            .Add("PARES_PZAS", oDPVale.InfoDPVALE.Rows(0)("PARES"))
                            .Add("MONTO_UTILIZADO", Convert.ToDecimal(oDPVale.InfoDPVALE.Rows(0)("MONTO")).ToString("##,##0.00").Replace(",", ""))
                            .Add("MONTODPVALE", Convert.ToDecimal(oDPVale.InfoDPVALE.Rows(0)("MONTO")).ToString("##,##0.00").Replace(",", ""))
                            .Add("REVALE", oDPVale.InfoDPVALE.Rows(0)("REVAL"))
                            .Add("RMONTODPVALE", Convert.ToDecimal(oDPVale.InfoDPVALE.Rows(0)("MONTO")).ToString("##,##0.00").Replace(",", ""))
                            If oConfigCierreFI.GenerarSeguro Then
                                Dim DataSecure As New Hashtable()
                                DataSecure("I_NUMVA") = oDPVale.INUMVA.PadLeft(10, "0")
                                DataSecure("I_KUNNR") = oDPVale.InfoDPVALE.Rows(0)("KUNNR").PadLeft(10, "0")
                                If oConfigCierreFI.GenerarSeguro Then
                                    DataSecure("I_ZSEG") = "1"
                                Else
                                    DataSecure("I_ZSEG") = "0"
                                End If
                                DataSecure("I_FECCO") = FechaCobro.ToString("yyyyMMdd")
                                DataSecure("I_NUMDE") = oDPVale.InfoDPVALE.Rows(0)("NUMDE")

                                If oProcesosSAPMgr.ZDPVL_VALSEGUROSAFS(DataSecure) = True Then
                                    oFactura.SeguroVidaSAPDPVL = True
                                    .Add("ZSEG", "1")
                                Else
                                    oFactura.SeguroVidaSAPDPVL = False
                                    .Add("ZSEG", "0")
                                End If
                            Else
                                .Add("ZSEG", "0")
                            End If
                        End If
                        .Add("NTARJETA", "")
                        .Add("SIHAY", "")
                        .Add("PEDIDOSH", "")
                        .Add("STATUS", "")
                    End With
                    oFormasPago.Add(oPago)
                End If
            Next
            '------------------------------------------------------------------
            ' Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("T_FORMAS_PAGO", oFormasPago)

            ' ------------------------------------------------------------------
            ' Llenamos datos de las Productos 
            '------------------------------------------------------------------
            Dim oProductos As New List(Of Dictionary(Of String, Object))
            '------------------------------------------------------------------
            ' Seteamos datos del detalle
            '------------------------------------------------------------------
            Dim productos As String() = Registro.Cells("FCodArticulo").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim tallas As String() = Registro.Cells("FTalla").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim cantidades As String() = Registro.Cells("FCantidad").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim descuentos As String() = Registro.Cells("FDescuento").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim preciosFinales As String() = Registro.Cells("FPrecioFinal").Value.ToString().Trim().Split(SEPARADORVALORES)
            For contador As Integer = 0 To productos.Length - 1
                Dim oCodigo As New Dictionary(Of String, Object)
                With oCodigo
                    .Add("POSNR", "")
                    .Add("ORDERITEM_ID", "")
                    .Add("MATNR", productos(contador).ToString().PadLeft(10, "0"))
                    .Add("CANTIDAD", CInt(cantidades(contador)))
                    If CDec(descuentos(contador)) > 0 Then
                        .Add("DESCUENTO", CDec(descuentos(contador)).ToString("##,##0.00").Replace(",", ""))
                        .Add("CLASE_CONDICION", "ZDP4")
                    Else
                        .Add("DESCUENTO", 0)
                        .Add("CLASE_CONDICION", "")
                    End If
                    .Add("ID_PROMOCION", "")
                    .Add("ALMACEN", "")
                    .Add("MOT_RECHAZO", "")
                End With
                oProductos.Add(oCodigo)
                oFactura.Total = oFactura.Total + preciosFinales(contador)
            Next

            '------------------------------------------------------------------
            ' Metemos los datos al detalle del objeto para serializarlo a JSON
            '------------------------------------------------------------------
            .Add("T_PRODUCTOS", oProductos)

        End With
        If oFactura.CodTipoVenta.Trim() = "O" OrElse oFactura.CodTipoVenta.Trim() = "V" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
            Dim lstInterlocutor As New List(Of Dictionary(Of String, Object))
            Dim inter As New Dictionary(Of String, Object)
            inter("CLIENTE") = oFactura.ClienteId
            inter("TIPO_CLIENTE") = oFactura.TipoCliente
            lstInterlocutor.Add(inter)
            oProcesarVenta("T_INTERLOCUTORES") = lstInterlocutor
        End If

        '------------------------------------------------------------------
        'Ejecutamos la Transaccion
        '------------------------------------------------------------------
        Dim oRetail As New ProcesosRetail("/pos/ventas_directas", "POST")
        oRetail.Parametros.Add("SerialID", oFactura.SerialId)
        response = oRetail.SapZsdProcesoventa(oProcesarVenta, False)

        oFacturaMgr.SaveSerial(oFactura.SerialId, "S", oFactura.CodVendedor, oFactura.FacturaID)

        Return response
    End Function

    ''' <summary>
    ''' Función para guardar la factura y el detalle
    ''' </summary>
    ''' <param name="Registro">Datos de la factura a guardar</param>
    ''' <param name="oFactura">Objeto factura</param>
    ''' <remarks></remarks>
    Public Sub SaveFactura(ByRef Registro As GridEXRow, ByRef oFactura As Factura)

        Dim resultado As String = String.Empty

        oFacturaMgr.Save(oFactura)

        If oFactura.FacturaID > 0 Then

            If GuardarFacturaCorrida(Registro, oFactura) Then

                If GuardarFormadePago(Registro, oFactura) Then

                    'Actualizamos DPVale
                    If oFactura.CodTipoVenta = "V" Then
                        If Not oAppSAPConfig.DPValeSAP Then
                            'ActualizaDPVale()
                            'GuardaFIDocumentWS() 'Guardamos FIDocument de la venta DPVale
                        Else
                            'ActualizaDPValeSAP()
                        End If
                    End If

                    oValeCaja = oValeCajaMgr.Create
                    oValeCaja = oValeCajaMgr.GetByFolioDocumento(Registro.Cells("FolioNotaCredito").Value)

                    'Actualizamos Vales de Caja
                    If Not (oValeCaja Is Nothing) Then
                        ActualizaValeCaja()
                    End If
                Else
                    Throw New Exception("ERROR. Forma de Pago no se guardó. ")
                End If
            Else
                Throw New Exception("ERROR. Corrida y Forma de Pago no se guardaron. ")
            End If
        Else
            Throw New Exception("ERROR. La Factura no ha sido guardada.")
        End If

    End Sub

    Private Sub ActualizaValeCaja()
        oValeCaja.MontoUtilizado = oValeCaja.Importe
        oValeCajaMgr.Save(oValeCaja)
    End Sub

    ''' <summary>
    ''' Función para guardar los datos del detalle de la factura
    ''' </summary>
    ''' <param name="Registro">Registro con el detalle del producto</param>
    ''' <param name="oFactura">Objeto con los datos de la factura</param>
    ''' <returns>true si es satisfactorio de lo contrario false</returns>
    ''' <remarks>Esta función solo almacena 1 registro de producto por cada factura</remarks>
    Private Function GuardarFacturaCorrida(ByRef Registro As GridEXRow, ByRef oFactura As Factura) As Boolean

        GuardarFacturaCorrida = False
        Dim ofacturaCorrida As FacturaCorrida
        'Dim oArticulo As Articulo
        Dim decPrecioOferta As Decimal
        Dim PrecioUnit As Decimal


        If oFactura.FacturaID > 0 Then
            Dim productos As String() = Registro.Cells("FCodArticulo").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim tallas As String() = Registro.Cells("FTalla").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim cantidades As String() = Registro.Cells("FCantidad").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim descuentos As String() = Registro.Cells("FDescuento").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim preciosUnitarios As String() = Registro.Cells("FPrecioUnit").Value.ToString().Trim().Split(SEPARADORVALORES)
            Dim preciosFinales As String() = Registro.Cells("FPrecioFinal").Value.ToString().Trim().Split(SEPARADORVALORES)
            For contador As Integer = 0 To productos.Length - 1
                'oArticulo = oCatalogoArticulosMgr.Create
                oArticulo.ClearFields()
                ofacturaCorrida = oFacturaCorridaMgr.Create
                oArticulo = oCatalogoArticulosMgr.Load(productos(contador))
                'oCatalogoArticulosMgr.LoadInto(productos(contador), oArticulo)
                ofacturaCorrida.Clearfields()
                decPrecioOferta = Decimal.Round(Convert.ToDecimal(preciosUnitarios(contador)), 4)
                PrecioUnit = decPrecioOferta
                'Asignamos Campos Corrida
                ofacturaCorrida.FacturaID = oFactura.FacturaID
                ofacturaCorrida.CodArticulo = productos(contador)
                ofacturaCorrida.Cantidad = cantidades(contador)
                ofacturaCorrida.Numero = tallas(contador)
                ofacturaCorrida.CostoUnitario = oArticulo.CostoProm
                ofacturaCorrida.PrecioUnitario = PrecioUnit
                ofacturaCorrida.PrecioOferta = decPrecioOferta
                ofacturaCorrida.Total = Convert.ToDecimal(preciosFinales(contador).ToString())
                'If descuentos(contador) > 0 Then
                '    ofacturaCorrida.CodTipoDescuento = .Item("Condicion")
                'Else
                '    ofacturaCorrida.CodTipoDescuento = ""
                'End If
                ofacturaCorrida.Descuento = descuentos(contador)
                'ofacturaCorrida.DescuentoSistema = CondicionVenta_Porcentaje()
                'ofacturaCorrida.CantDescuentoSistema = .Item("Descuento")
                ofacturaCorrida.Fecha = oFactura.Fecha
                Dim valido As Boolean = oFacturaCorridaMgr.Save(ofacturaCorrida)
                If valido = False Then
                    Return False
                End If
                With ofacturaCorrida.Movimiento
                    .ClearFieldsMovimiento()
                    .Mov_CodTipoMov = 201
                    .Mov_TipoMovimiento = "S"
                    .Mov_Status = "A"
                    .Mov_Apartados = 0
                    .Mov_CodAlmacen = oFactura.CodAlmacen
                    .Mov_Destino = oFactura.ClienteId
                    .Mov_Folio = oFactura.FolioFactura
                    .Mov_CodArticulo = oArticulo.CodArticulo
                    .Mov_Descripcion = oArticulo.Descripcion
                    .Mov_CodLinea = oArticulo.Codlinea
                    .Mov_CodMarca = oArticulo.CodMarca
                    .Mov_CodFamilia = oArticulo.CodFamilia
                    .Mov_CodUnidad = oArticulo.CodUnidadVta
                    .Mov_CodUso = oArticulo.CodUso
                    .Mov_CodCategoria = oArticulo.CodCategoria
                    .Mov_CostoUnit = oArticulo.CostoProm
                    .Mov_PrecioUnit = ofacturaCorrida.PrecioUnitario
                    .Mov_FolioControl = ""
                    .Mov_CodCaja = oFactura.CodCaja

                End With

                'Dim oRow As DataRow
                Dim tMontoNC As Decimal = 0, tCostNC As Decimal = 0
                Dim dsMultU As DataSet, drMultU As DataRow
                tMontoNC = 0
                tCostNC = 0

                If Registro.Cells("TipoVenta").Value.ToString() <> "V" Then 'vale de caja
                    tMontoNC = tMontoNC + Convert.ToDecimal(Registro.Cells("MontoValeCaja").Value.ToString())
                    dsMultU = oFacturaCorridaMgr.CostNC(Registro.Cells("FolioValeCaja").Value)
                    For Each drMultU In dsMultU.Tables(0).Rows
                        If Not IsDBNull(drMultU!CostNC) Then
                            tCostNC = tCostNC + drMultU!CostNC
                        End If
                    Next
                End If

                tMontoNC = tMontoNC / (1 + oAppContext.ApplicationConfiguration.IVA)
                oFacturaCorridaMgr.SaveMovimiento(oFactura.Total, ofacturaCorrida, tMontoNC, tCostNC)
            Next
        End If

        Return True

    End Function


    ''' <summary>
    ''' Función para guardar los datos de las formas de pago de la factura
    ''' </summary>
    ''' <param name="Registro">Registro a procesar</param>
    ''' <param name="oFactura">Objeto con los datos de la factura</param>
    ''' <returns>true si es satisfactorio de lo contrario false</returns>
    ''' <remarks>
    ''' A las formas de pago capturadas en el archivo, se agrega el revale o el vale de caja, que se haya generado durante la nota de crédito
    ''' </remarks>
    Private Function GuardarFormadePago(ByRef Registro As GridEXRow, ByRef oFactura As Factura) As Boolean

        GuardarFormadePago = False
        Dim oDPVale As cDPVale
        If oFactura.FacturaID > 0 Then

            'Grabamos Factura Forma de Pago

            Dim formas As String = Registro.Cells("FCodFormaPago").Value.ToString().Trim()
            Dim montosFormasPago As String = Registro.Cells("FImporte").Value.ToString().Trim()

            ''Procesamos las formas de pago generadas
            oFacturaFormaPago.ClearFields()

            oDPVale = Nothing
            oDPVale = ObtenerDatosVale(Registro.Cells("FolioValeCaja").Value.ToString())

            'Asignamos Campos Forma de Pago
            oFacturaFormaPago.FacturaID = oFactura.FacturaID
            If Not oDPVale Is Nothing Then
                oFacturaFormaPago.DPValeID = oDPVale.INUMVA
            End If
            If Registro.Cells("TipoVenta").Value.ToString() = "V" Then 'vale
                oFacturaFormaPago.FormaPagoID = "DPVL"
            Else
                oFacturaFormaPago.FormaPagoID = "VCJA"
            End If
            oFacturaFormaPago.BancoID = String.Empty
            oFacturaFormaPago.TipoTarjetaID = String.Empty
            oFacturaFormaPago.NumeroTarjeta = String.Empty
            oFacturaFormaPago.NumeroAutorización = String.Empty
            oFacturaFormaPago.NotaCreditoID = Registro.Cells("NotaCreditoID").Value
            oFacturaFormaPago.ComisionBancaria = 0
            oFacturaFormaPago.IngresoComision = 0
            oFacturaFormaPago.IVAComision = 0
            oFacturaFormaPago.Monto = Convert.ToDecimal(Registro.Cells("MontoValeCaja").Value.ToString())
            oFacturaFormaPago.NoAfiliacion = 0
            oFacturaFormaPago.Promocion = 0

            oFacturaFormaPago.RecordCreatedOn = oFactura.Fecha

            oFacturaFormaPago.Save()


            ''Procesamos las formas de pago adicionales
            Dim aformasPago() As String = formas.Split(SEPARADORVALORES)
            Dim amontosFormasPago() As String = montosFormasPago.Split(SEPARADORVALORES)

            For indice As Integer = 0 To aformasPago.Length - 1
                If aformasPago(indice) <> "" Then
                    oFacturaFormaPago.ClearFields()

                    oDPVale = Nothing
                    If aformasPago(indice) = "DPVL" Then
                        If Registro.Cells("TipoVenta").Value.ToString() = "V" Then 'vale
                            oDPVale = ObtenerDatosVale(Registro.Cells("FolioValeCaja").Value.ToString())
                        Else 'si es una venta normal entonces se pudo pagar la diferencia con dpvale
                            oDPVale = ObtenerDatosVale(Registro.Cells("FDPValeID").Value.ToString())
                        End If
                    End If

                    'Asignamos Campos Forma de Pago
                    oFacturaFormaPago.FacturaID = oFactura.FacturaID
                    If Not oDPVale Is Nothing Then
                        oFacturaFormaPago.DPValeID = oDPVale.INUMVA
                    End If
                    oFacturaFormaPago.FormaPagoID = aformasPago(indice)
                    oFacturaFormaPago.BancoID = String.Empty
                    oFacturaFormaPago.TipoTarjetaID = String.Empty
                    oFacturaFormaPago.NumeroTarjeta = String.Empty
                    oFacturaFormaPago.NumeroAutorización = String.Empty
                    oFacturaFormaPago.NotaCreditoID = Registro.Cells("NotaCreditoID").Value
                    oFacturaFormaPago.ComisionBancaria = 0
                    oFacturaFormaPago.IngresoComision = 0
                    oFacturaFormaPago.IVAComision = 0
                    oFacturaFormaPago.Monto = Convert.ToDecimal(amontosFormasPago(indice))
                    oFacturaFormaPago.NoAfiliacion = 0
                    oFacturaFormaPago.Promocion = 0

                    oFacturaFormaPago.RecordCreatedOn = oFactura.Fecha

                    oFacturaFormaPago.Save()
                End If
            Next

            Return True

        End If

    End Function

    ''' <summary>
    ''' Función para descargar los datos de sap del revale generado
    ''' </summary>
    ''' <param name="vale">Id del vale</param>
    ''' <returns>Objeto con los datos del vale descargado de SAP</returns>
    ''' <remarks></remarks>
    Private Function ObtenerDatosVale(ByVal vale As String) As cDPVale
        Dim oDPVale As New cDPVale
        oDPVale.INUMVA = vale
        oDPVale.I_RUTA = "X"
        oDPVale = oProcesosSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

        Return oDPVale
    End Function

    Private Sub Compensar(ByRef facturas As List(Of GridEXRow))
        Dim strError As String = String.Empty
        Dim dsResultado As DataSet
        Dim dsBanco As DataSet = Nothing

        Dim dtFormasPago As New DataTable()
        Dim dtDocumentos As New DataTable
        Dim drDocumento As DataRow
        dtDocumentos.Columns.Add("BSTNK")

        Dim dtPagos As New DataTable()
        dtPagos.Columns.Add("BSTNK")
        dtPagos.Columns.Add("TPAGO")
        dtPagos.Columns.Add("CLCOB")
        dtPagos.Columns.Add("REFBA")
        dtPagos.Columns.Add("MONTO")
        dtPagos.Columns.Add("RCAJA")
        dtPagos.Columns.Add("BANCO")
        dtPagos.Columns.Add("COMPE")

        '----------------Numero de Referencia---------------
        Dim numref As New NumeroReferencia.cNumReferencia
        Dim strNumRef As String = numref.getNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(DateTime.Today.Date.Date, "ddMMyyyy")))
        '------------------------------------------------------

        For Each registro As GridEXRow In facturas
            strError = String.Empty
            registro.BeginEdit()
            Try

                dtFormasPago = oCatFormaPago.GetAll(registro.Cells("TipoVenta").Value.ToString()).Tables(0)
                dtFormasPago.Merge(oCatFormaPago.GetAll(registro.Cells("FTipoVenta").Value.ToString()).Tables(0))

                dtDocumentos.Rows.Add(New Object() {registro.Cells("FReferencia").Value})

                Dim formas As String = registro.Cells("FCodFormaPago").Value.ToString().Trim()
                Dim montosFormasPago As String = registro.Cells("FImporte").Value.ToString().Trim()
                Dim compe As String = String.Empty

                'Agregamos el monto de caja generado
                If registro.Cells("TipoVenta").Value = "V" Then 'Se genero un revale
                    formas = "DPVL," & formas
                Else 'se genero un vale de caja
                    formas = "VCJA," & formas
                    compe = "X"
                End If
                montosFormasPago = registro.Cells("MontoValeCaja").Value.ToString() & "," & montosFormasPago

                Dim aformasPago() As String = formas.Split(SEPARADORVALORES)
                Dim amontosFormasPago() As String = montosFormasPago.Split(SEPARADORVALORES)

                For indice As Integer = 0 To aformasPago.Length - 1
                    If aformasPago(indice) <> "" Then
                        Dim clcob As String = String.Empty
                        Dim banco As String = String.Empty

                        Select Case aformasPago(indice).Trim
                            Case "EFEC"
                                clcob = "EFECTIVO"
                            Case "TACR"
                                clcob = "TARJETA 1".PadRight(9, " ")
                            Case "TADB"
                                clcob = "TARJETA 1".PadRight(9, " ")
                            Case "VCJA"
                                clcob = ""
                            Case "DPPT"
                                clcob = "DPPUNTOS"
                            Case "DPCA"
                                clcob = "DPCARDCR"
                            Case "DPVL"
                                clcob = ""
                        End Select

                        dsBanco = oCierreDiasMgr.BancoSel("T" & oAppContext.ApplicationConfiguration.Almacen, clcob)
                        If dsBanco.Tables(0).Rows.Count > 0 Then
                            banco = dsBanco.Tables(0).Rows(0)!Banco
                        End If

                        dtPagos.Rows.Add(New Object() {registro.Cells("FReferencia").Value, _
                                                       aformasPago(indice), _
                                                       clcob, _
                                                       strNumRef, _
                                                       CDec(amontosFormasPago(indice)).ToString("##,##0.00"), _
                                                       IIf(registro.Cells("TipoVenta").Value = "V", "", registro.Cells("FolioNotaCredito").Value), _
                                                      banco, _
                                                       compe})

                    End If
                Next

            Catch ex As Exception
                registro.Cells("CMensaje").Value += ex.Message
            Finally
                registro.EndEdit()
            End Try
        Next
        If dtDocumentos.Rows.Count > 0 Then

            Try
                dsResultado = oNotasCreditoMgr.SapZsdProcesoCompensacion(dtDocumentos, dtPagos, strError)

                If Not strError = String.Empty Then
                    For Each registro As GridEXRow In facturas
                        strError = String.Empty
                        registro.BeginEdit()
                        registro.Cells("CMensaje").Value += strError
                        registro.EndEdit()
                    Next
                Else
                    If dsResultado.Tables.Count = 2 AndAlso dsResultado.Tables(0).Rows.Count >= 1 AndAlso dsResultado.Tables(1).Rows.Count >= 1 Then
                        For Each registro As GridEXRow In facturas
                            Try

                                registro.BeginEdit()
                                'Buscamos el registro financiero correspondiente
                                If dsResultado.Tables(0).Select("BSTNK='" & registro.Cells("FReferencia").Value & "'").Length = 1 Then
                                    drDocumento = dsResultado.Tables(0).Select("BSTNK='" & registro.Cells("FReferencia").Value & "'")(0)

                                    registro.Cells("CDocumentoFinanciero").Value = " Sociedad: " & drDocumento("Sociedad").ToString() & _
                                                                                    " Invoice: " & drDocumento("Invoice").ToString() & _
                                                                                    " Ejercicio: " & drDocumento("Ejercicio").ToString() & _
                                                                                    " Cliente: " & drDocumento("Cliente").ToString() & _
                                                                                    " Importe: " & drDocumento("Importe").ToString() & _
                                                                                    " Ref_Fact: " & drDocumento("Ref_Fact").ToString() & _
                                                                                    " Bstnk: " & drDocumento("Bstnk").ToString() & _
                                                                                    " Augbl: " & drDocumento("Augbl").ToString()

                                    If dsResultado.Tables(1).Select("BELNR='" & drDocumento("Invoice").ToString() & "'").Length = 1 Then
                                        drDocumento = dsResultado.Tables(1).Select("BELNR='" & drDocumento("Invoice").ToString() & "'")(0)
                                        registro.Cells("CDocumento").Value = " Blart: " & drDocumento("Blart").ToString() & _
                                                                            " Belnr: " & drDocumento("Belnr").ToString()
                                    End If
                                End If
                            Catch ex As Exception
                                registro.Cells("CMensaje").Value += ex.Message
                            Finally
                                registro.EndEdit()
                            End Try

                        Next
                    End If
                End If

            Catch ex As Exception

            End Try
        End If


    End Sub

#End Region



End Class
