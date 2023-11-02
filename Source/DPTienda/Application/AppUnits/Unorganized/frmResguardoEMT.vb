Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmResguardoEMT
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuBuscar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuReporte As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalida As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBuscar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuReporte1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalida1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuLimpiar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalida As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ebOdC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GrdDetalleOdC As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResguardoEMT))
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuBuscar1 = New Janus.Windows.UI.CommandBars.UICommand("menuBuscar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuReporte1 = New Janus.Windows.UI.CommandBars.UICommand("menuReporte")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalida1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalida")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuLimpiar = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuBuscar = New Janus.Windows.UI.CommandBars.UICommand("menuBuscar")
        Me.menuReporte = New Janus.Windows.UI.CommandBars.UICommand("menuReporte")
        Me.menuSalida = New Janus.Windows.UI.CommandBars.UICommand("menuSalida")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.btnSalida = New Janus.Windows.EditControls.UIButton()
        Me.GrdDetalleOdC = New Janus.Windows.GridEX.GridEX()
        Me.ebOdC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        CType(Me.GrdDetalleOdC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuLimpiar, Me.menuBuscar, Me.menuReporte, Me.menuSalida, Me.menuSalir})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("0dfd9edc-500f-4f6b-a004-acebef017565")
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
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator4, Me.menuBuscar1, Me.Separator1, Me.menuReporte1, Me.Separator2, Me.menuSalida1, Me.Separator3, Me.menuSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(387, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuBuscar1
        '
        Me.menuBuscar1.Key = "menuBuscar"
        Me.menuBuscar1.Name = "menuBuscar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuReporte1
        '
        Me.menuReporte1.Key = "menuReporte"
        Me.menuReporte1.Name = "menuReporte1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuSalida1
        '
        Me.menuSalida1.Key = "menuSalida"
        Me.menuSalida1.Name = "menuSalida1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuLimpiar
        '
        Me.menuLimpiar.Icon = CType(resources.GetObject("menuLimpiar.Icon"), System.Drawing.Icon)
        Me.menuLimpiar.Key = "menuNuevo"
        Me.menuLimpiar.Name = "menuLimpiar"
        Me.menuLimpiar.Text = "Limpiar"
        '
        'menuBuscar
        '
        Me.menuBuscar.Icon = CType(resources.GetObject("menuBuscar.Icon"), System.Drawing.Icon)
        Me.menuBuscar.Key = "menuBuscar"
        Me.menuBuscar.Name = "menuBuscar"
        Me.menuBuscar.Text = "Buscar"
        Me.menuBuscar.Visible = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuReporte
        '
        Me.menuReporte.Enabled = Janus.Windows.UI.InheritableBoolean.[True]
        Me.menuReporte.Icon = CType(resources.GetObject("menuReporte.Icon"), System.Drawing.Icon)
        Me.menuReporte.Key = "menuReporte"
        Me.menuReporte.Name = "menuReporte"
        Me.menuReporte.Text = "Generar Reporte"
        '
        'menuSalida
        '
        Me.menuSalida.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuSalida.Icon = CType(resources.GetObject("menuSalida.Icon"), System.Drawing.Icon)
        Me.menuSalida.Key = "menuSalida"
        Me.menuSalida.Name = "menuSalida"
        Me.menuSalida.Text = "Salida de Resguardo"
        '
        'menuSalir
        '
        Me.menuSalir.Icon = CType(resources.GetObject("menuSalir.Icon"), System.Drawing.Icon)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(490, 28)
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.cmbFecha)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar3)
        Me.ExplorerBar1.Controls.Add(Me.ebOdC)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(490, 388)
        Me.ExplorerBar1.TabIndex = 3
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(296, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Fecha:"
        '
        'cmbFecha
        '
        '
        '
        '
        Me.cmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbFecha.Location = New System.Drawing.Point(344, 40)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.ReadOnly = True
        Me.cmbFecha.Size = New System.Drawing.Size(128, 23)
        Me.cmbFecha.TabIndex = 117
        Me.cmbFecha.TodayButtonText = "Hoy"
        Me.cmbFecha.Value = New Date(2015, 7, 31, 0, 0, 0, 0)
        Me.cmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.UiButton1)
        Me.ExplorerBar3.Controls.Add(Me.btnSalida)
        Me.ExplorerBar3.Controls.Add(Me.GrdDetalleOdC)
        Me.ExplorerBar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExplorerBar3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Detalle en Resguardo de la Orden de Compra"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 76)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(490, 312)
        Me.ExplorerBar3.TabIndex = 113
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'UiButton1
        '
        Me.UiButton1.Icon = CType(resources.GetObject("UiButton1.Icon"), System.Drawing.Icon)
        Me.UiButton1.ImageSize = New System.Drawing.Size(24, 24)
        Me.UiButton1.Location = New System.Drawing.Point(321, 264)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(112, 40)
        Me.UiButton1.TabIndex = 10
        Me.UiButton1.Text = "Salir"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSalida
        '
        Me.btnSalida.Enabled = False
        Me.btnSalida.Icon = CType(resources.GetObject("btnSalida.Icon"), System.Drawing.Icon)
        Me.btnSalida.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnSalida.Location = New System.Drawing.Point(57, 264)
        Me.btnSalida.Name = "btnSalida"
        Me.btnSalida.Size = New System.Drawing.Size(200, 40)
        Me.btnSalida.TabIndex = 9
        Me.btnSalida.Text = "Dar salida a Materiales"
        Me.btnSalida.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'GrdDetalleOdC
        '
        Me.GrdDetalleOdC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.GrdDetalleOdC.DesignTimeLayout = GridEXLayout1
        Me.GrdDetalleOdC.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GrdDetalleOdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrdDetalleOdC.GroupByBoxVisible = False
        Me.GrdDetalleOdC.Location = New System.Drawing.Point(8, 36)
        Me.GrdDetalleOdC.Name = "GrdDetalleOdC"
        Me.GrdDetalleOdC.Size = New System.Drawing.Size(472, 216)
        Me.GrdDetalleOdC.TabIndex = 8
        Me.GrdDetalleOdC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebOdC
        '
        Me.ebOdC.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebOdC.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebOdC.ButtonImage = CType(resources.GetObject("ebOdC.ButtonImage"), System.Drawing.Image)
        Me.ebOdC.ButtonImageSize = New System.Drawing.Size(16, 16)
        Me.ebOdC.FormatString = "0000000000"
        Me.ebOdC.Location = New System.Drawing.Point(136, 40)
        Me.ebOdC.MaxLength = 10
        Me.ebOdC.Name = "ebOdC"
        Me.ebOdC.Size = New System.Drawing.Size(120, 23)
        Me.ebOdC.TabIndex = 108
        Me.ebOdC.Text = "0000000000"
        Me.ebOdC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebOdC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.ebOdC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Orden de Compra:"
        '
        'frmResguardoEMT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(490, 416)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmResguardoEMT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resguardo de EMT"
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        CType(Me.GrdDetalleOdC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaracion de Privadas"
    '--------------------------------------------------------------------------------------
    'Variables
    '--------------------------------------------------------------------------------------
    Private dtDetalleOdC As DataTable
    Private bolCerrar As Boolean = True
    Private CentroSAP As String = ""

    '--------------------------------------------------------------------------------------
    'Objetos
    '--------------------------------------------------------------------------------------
    Private oSAPMgr As ProcesoSAPManager
    Private oTraspasoEntradaMgr As TraspasosEntradaManager
    Private oArticulosMgr As CatalogoArticuloManager
    Private oArticulo As Articulo

#End Region

#Region "Metodos y Funciones"

    Private Sub Inicializar()

        '--------------------------------------------------------------------------------------
        ' Inicializamos Objetos
        '--------------------------------------------------------------------------------------
        Me.oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Me.oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
        Me.oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        '--------------------------------------------------------------------------------------
        'Inicializamos Variables
        '--------------------------------------------------------------------------------------
        Me.CentroSAP = oSAPMgr.Read_Centros()

    End Sub

    Private Sub HabilitarSalida(ByVal Habilitar As Boolean)
        Me.btnSalida.Enabled = Habilitar
        Me.UiCommandBar1.Commands("menuSalida").Enabled = Habilitar
    End Sub

    Private Sub Limpiar()

        '--------------------------------------------------------------------------------------
        ' Variables Privadas 
        '--------------------------------------------------------------------------------------
        Me.dtDetalleOdC = Nothing
        Me.bolCerrar = True

        '--------------------------------------------------------------------------------------
        'Objetos 
        '--------------------------------------------------------------------------------------
        oArticulo = Nothing

        '--------------------------------------------------------------------------------------
        ' interfaz de usuario
        '--------------------------------------------------------------------------------------
        Me.ebOdC.Text = "0000000000"
        Me.ebOdC.Value = ""
        Me.cmbFecha.Value = Date.MinValue
        Me.GrdDetalleOdC.DataSource = Nothing
        Me.btnSalida.Enabled = False
        HabilitarSalida(False)

        '--------------------------------------------------------------------------------------
        ' Foco
        '--------------------------------------------------------------------------------------
        Me.ebOdC.Focus()

    End Sub

    Private Sub CargarDetalleOdC(ByVal OrdenCompra As String)

        Try
            '--------------------------------------------------------------------------------------
            ' Obtenemos detalle de la Orden de Compra y fecha 
            '--------------------------------------------------------------------------------------
            dtDetalleOdC = Nothing
            dtDetalleOdC = oTraspasoEntradaMgr.ObtenerResguardoByOrdenCompra(OrdenCompra, CentroSAP)

            '--------------------------------------------------------------------------------------
            ' Validamos resultados
            '--------------------------------------------------------------------------------------
            If dtDetalleOdC.Rows.Count > 0 Then

                '--------------------------------------------------------------------------------------
                ' Agregamos columna nueva
                '--------------------------------------------------------------------------------------
                dtDetalleOdC.Columns.Add("Descripcion")

                '--------------------------------------------------------------------------------------
                ' Obtenemos descripcion del material
                '--------------------------------------------------------------------------------------
                For Each oRow As DataRow In dtDetalleOdC.Rows
                    Me.cmbFecha.Value = CDate(oRow!FechaCreacion)
                    oArticulo = Nothing
                    oArticulo = oArticulosMgr.Load(oRow!Codigo)
                    oRow("Descripcion") = oArticulo.Descripcion
                    oRow.AcceptChanges()
                Next
                dtDetalleOdC.AcceptChanges()

                '--------------------------------------------------------------------------------------
                ' Seteamos Detalle
                '--------------------------------------------------------------------------------------
                GrdDetalleOdC.DataSource = dtDetalleOdC

                '--------------------------------------------------------------------------------------
                'Bandera para poder cerrar el formulario
                '--------------------------------------------------------------------------------------
                bolCerrar = False

            Else
                '--------------------------------------------------------------------------------------
                ' Mostramos error
                '--------------------------------------------------------------------------------------
                MessageBox.Show("La Orden de Compra " & OrdenCompra & " no cuenta con Materiales en Resguardo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Limpiar()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------------
            ' Visualizamos boton para dar salida a mercancia (Interfaz y Menu)
            '--------------------------------------------------------------------------------------
            HabilitarSalida(True)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function ValidarOdC(ByVal OdC As String) As Boolean
        Dim bResp As Boolean = True
        '--------------------------------------------------------------------------------------
        ' Validamos variable de OdC
        '--------------------------------------------------------------------------------------
        If OdC.Trim = String.Empty OrElse OdC.Trim = "0000000000" Then
            MessageBox.Show("Favor de ingresar el Folio de la Orden de Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bResp = False
            HabilitarSalida(False)
        End If
        Return bResp
    End Function

    Private Sub GenerarReporte()

        Dim dtReporteResguardo As DataTable

        Try

            '--------------------------------------------------------------------------------------
            ' Modificado para que se pueda usar en todos los conceptos de pago
            '--------------------------------------------------------------------------------------
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia", "DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia.ReporteResguardo") Then
                GoTo Salir
            End If

            ' Obtenemos Resguardo general
            dtReporteResguardo = oTraspasoEntradaMgr.ObtenerReporteResguardos(CentroSAP)

            ' Validamos resultados
            If dtReporteResguardo.Rows.Count > 0 Then

                ' Agregamos columna nueva
                dtReporteResguardo.Columns.Add("Descripcion")

                ' Obtenemos descripcion del material
                For Each oRow As DataRow In dtReporteResguardo.Rows
                    oArticulo = Nothing
                    oArticulo = oArticulosMgr.Load(oRow!Codigo)
                    oRow("Descripcion") = oArticulo.Descripcion
                    oRow.AcceptChanges()
                Next
                dtReporteResguardo.AcceptChanges()

                ' Imprimimos reporte de salida de resguardo
                ImprimirReporteResguardo(dtReporteResguardo)

            Else
                ' Mostramos error
                MessageBox.Show("No se cuenta con Materiales en Resguardo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Limpiar()
                GoTo Salir
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al dar salida a los Materiales en Resguardo de EMT.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            EscribeLog(ex.ToString, "Error al dar salida a los Materiales en Resguardo de EMT.")
            GoTo Salir
        End Try
Salir:
        oAppContext.Security.CloseImpersonatedSession()

    End Sub

    Private Sub DarSalida()

        Try

            '--------------------------------------------------------------------------------------
            ' Modificado para que se pueda usar en todos los conceptos de pago
            '--------------------------------------------------------------------------------------
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia", "DportenisPRO.DPTienda.Inventarios.TraspasosEntradaMercancia.SalidaResguardo") Then
                GoTo Salir
            End If
            '--------------------------------------------------------------------------------------
            ' Validamos que este todo correctamente cargado
            '--------------------------------------------------------------------------------------
            If Not bolCerrar Then

                '--------------------------------------------------------------------------------------
                ' Actualizamos Registros
                '--------------------------------------------------------------------------------------
                oTraspasoEntradaMgr.ActualizarResguardosByOrdenCompra(Me.ebOdC.Text.Trim)

                '--------------------------------------------------------------------------------------
                ' Imprimimos reporte de salida de resguardo
                '--------------------------------------------------------------------------------------
                ImprimirReporteResguardo(dtDetalleOdC, Me.ebOdC.Text.Trim)

                '--------------------------------------------------------------------------------------
                ' OK
                '--------------------------------------------------------------------------------------
                MessageBox.Show("Se dio salida a los Materiales en Resguardo exitosamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                '--------------------------------------------------------------------------------------
                ' Limpiamos pantalla y variables
                '--------------------------------------------------------------------------------------
                Limpiar()

            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al dar salida a los Materiales en Resguardo de EMT.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            EscribeLog(ex.ToString, "Error al dar salida a los Materiales en Resguardo de EMT.")
            GoTo Salir
        End Try

Salir:
        oAppContext.Security.CloseImpersonatedSession()

    End Sub

    Private Sub ImprimirReporteResguardo(ByVal Detalle As DataTable, Optional ByVal OrdenCompra As String = "")

        Try

            Dim oARReporte
            oARReporte = New rptResguardo(Detalle, OrdenCompra)

            Dim oReportViewer As New ReportViewerForm
            oARReporte.Document.Name = "Resguardo EMT"
            oARReporte.Run()

            '--------------------------------------------------------------------------------------
            ' Si es Reporte lo Visualizamos, si no lo imprimimos
            '--------------------------------------------------------------------------------------
            If OrdenCompra.Trim = "" Then 'Reporte
                oReportViewer.Report = oARReporte
                oReportViewer.Show()
            Else ' Salida
                Try
                    oARReporte.Document.Print(False, False)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
        End Try

    End Sub

#End Region

#Region "Eventos"

    Private Sub frmResguardoEMT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializar()
        Limpiar()
    End Sub

    Private Sub frmResguardoEMT_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not Me.bolCerrar Then
            If MessageBox.Show("Se han cargado Materiales que se encuentran en Resguardo de EMT. ¿Seguro que desea salir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub UiCommandBar1_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandBar1.CommandClick
        Select Case e.Command.Key
            Case "menuNuevo"
                Limpiar()
            Case "menuReporte"
                GenerarReporte()
            Case "menuSalida"
                DarSalida()
            Case "menuSalir"
                Me.Close()
        End Select
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Me.Close()
    End Sub

    Private Sub btnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalida.Click
        DarSalida()
    End Sub

    Private Sub ebOdC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebOdC.Validating
        If ValidarOdC(Me.ebOdC.Text) Then
            CargarDetalleOdC(Me.ebOdC.Text)
        End If
    End Sub

#End Region

End Class
