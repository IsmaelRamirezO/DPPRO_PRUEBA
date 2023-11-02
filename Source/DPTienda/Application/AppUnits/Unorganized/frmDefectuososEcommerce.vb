Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas



Public Class frmDefectuososEcommerce
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Nuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuHerramientas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCerrar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCerrar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebFechaDefectuoso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCerrar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuTemaAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuTemaAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCerrar3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCerrar4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator11 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CommandManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodArticulo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ebPlayerID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Separator12 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents rbMarcar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDesmarcar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents grdCodigos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbMotivos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbCodCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbMotivosDesmarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDefectuososEcommerce))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbMotivosDesmarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.cbCodCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbMotivos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.grdCodigos = New Janus.Windows.GridEX.GridEX()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.NicePanel2 = New PureComponents.NicePanel.NicePanel()
        Me.rbDesmarcar = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbMarcar = New Janus.Windows.EditControls.UIRadioButton()
        Me.ebPlayerName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ebCodArticulo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ebFechaDefectuoso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.menuHerramientas1 = New Janus.Windows.UI.CommandBars.UICommand("menuHerramientas")
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCerrar2 = New Janus.Windows.UI.CommandBars.UICommand("menuCerrar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuTemaAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuTemaAyuda")
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuCerrar1 = New Janus.Windows.UI.CommandBars.UICommand("menuCerrar")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Nuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuCerrar = New Janus.Windows.UI.CommandBars.UICommand("menuCerrar")
        Me.menuEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.menuTemaAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuTemaAyuda")
        Me.CommandManager = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator12 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator11 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuCerrar4 = New Janus.Windows.UI.CommandBars.UICommand("menuCerrar")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuCerrar3 = New Janus.Windows.UI.CommandBars.UICommand("menuCerrar")
        Me.menuEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuEliminar")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NicePanel2.SuspendLayout()
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.cmbMotivosDesmarca)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.btnAgregar)
        Me.ExplorerBar1.Controls.Add(Me.cbCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.cmbMotivos)
        Me.ExplorerBar1.Controls.Add(Me.grdCodigos)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursal)
        Me.ExplorerBar1.Controls.Add(Me.NicePanel2)
        Me.ExplorerBar1.Controls.Add(Me.rbDesmarcar)
        Me.ExplorerBar1.Controls.Add(Me.rbMarcar)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerName)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerID)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.ebCodArticulo)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.nebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaDefectuoso)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos del Artículo de Baja Calidad"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 28)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(669, 577)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbMotivosDesmarca
        '
        Me.cmbMotivosDesmarca.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMotivosDesmarca.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMotivosDesmarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbMotivosDesmarca.DesignTimeLayout = GridEXLayout1
        Me.cmbMotivosDesmarca.Location = New System.Drawing.Point(123, 217)
        Me.cmbMotivosDesmarca.Name = "cmbMotivosDesmarca"
        Me.cmbMotivosDesmarca.Size = New System.Drawing.Size(201, 23)
        Me.cmbMotivosDesmarca.TabIndex = 4
        Me.cmbMotivosDesmarca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMotivosDesmarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Motivo Desmarca:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Icon = CType(resources.GetObject("btnAgregar.Icon"), System.Drawing.Icon)
        Me.btnAgregar.Location = New System.Drawing.Point(13, 334)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(314, 34)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cbCodCaja
        '
        Me.cbCodCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cbCodCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cbCodCaja.BackColor = System.Drawing.SystemColors.Info
        Me.cbCodCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbCodCaja.Location = New System.Drawing.Point(122, 104)
        Me.cbCodCaja.Name = "cbCodCaja"
        Me.cbCodCaja.ReadOnly = True
        Me.cbCodCaja.Size = New System.Drawing.Size(107, 23)
        Me.cbCodCaja.TabIndex = 38
        Me.cbCodCaja.TabStop = False
        Me.cbCodCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cbCodCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbMotivos
        '
        Me.cmbMotivos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbMotivos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.cmbMotivos.DesignTimeLayout = GridEXLayout2
        Me.cmbMotivos.Location = New System.Drawing.Point(123, 161)
        Me.cmbMotivos.Name = "cmbMotivos"
        Me.cmbMotivos.Size = New System.Drawing.Size(201, 23)
        Me.cmbMotivos.TabIndex = 2
        Me.cmbMotivos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMotivos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'grdCodigos
        '
        Me.grdCodigos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.grdCodigos.DesignTimeLayout = GridEXLayout3
        Me.grdCodigos.GroupByBoxVisible = False
        Me.grdCodigos.Location = New System.Drawing.Point(9, 374)
        Me.grdCodigos.Name = "grdCodigos"
        Me.grdCodigos.Size = New System.Drawing.Size(654, 164)
        Me.grdCodigos.TabIndex = 36
        Me.grdCodigos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.SystemColors.Info
        Me.ebSucursal.Location = New System.Drawing.Point(122, 76)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.ReadOnly = True
        Me.ebSucursal.Size = New System.Drawing.Size(202, 23)
        Me.ebSucursal.TabIndex = 12
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'NicePanel2
        '
        Me.NicePanel2.BackColor = System.Drawing.Color.Transparent
        Me.NicePanel2.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.NicePanel2.ContainerImage = ContainerImage1
        Me.NicePanel2.ContextMenuButton = False
        Me.NicePanel2.Controls.Add(Me.Panel1)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.NicePanel2.FooterImage = HeaderImage1
        Me.NicePanel2.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Imagen del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(337, 38)
        Me.NicePanel2.Name = "NicePanel2"
        Me.NicePanel2.OriginalFooterVisible = True
        Me.NicePanel2.OriginalHeight = 0
        Me.NicePanel2.Size = New System.Drawing.Size(324, 330)
        ContainerStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(252, Byte), Integer))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(251, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.NicePanel2.Style = PanelStyle1
        Me.NicePanel2.TabIndex = 30
        '
        'rbDesmarcar
        '
        Me.rbDesmarcar.BackColor = System.Drawing.Color.Transparent
        Me.rbDesmarcar.Location = New System.Drawing.Point(180, 40)
        Me.rbDesmarcar.Name = "rbDesmarcar"
        Me.rbDesmarcar.Size = New System.Drawing.Size(222, 14)
        Me.rbDesmarcar.TabIndex = 34
        Me.rbDesmarcar.Text = "Desmarcar Artículo"
        Me.rbDesmarcar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbMarcar
        '
        Me.rbMarcar.BackColor = System.Drawing.Color.Transparent
        Me.rbMarcar.Checked = True
        Me.rbMarcar.Location = New System.Drawing.Point(9, 40)
        Me.rbMarcar.Name = "rbMarcar"
        Me.rbMarcar.Size = New System.Drawing.Size(148, 14)
        Me.rbMarcar.TabIndex = 33
        Me.rbMarcar.TabStop = True
        Me.rbMarcar.Text = "Marcar Artículo"
        Me.rbMarcar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebPlayerName
        '
        Me.ebPlayerName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.BackColor = System.Drawing.SystemColors.Info
        Me.ebPlayerName.Location = New System.Drawing.Point(123, 273)
        Me.ebPlayerName.Name = "ebPlayerName"
        Me.ebPlayerName.ReadOnly = True
        Me.ebPlayerName.Size = New System.Drawing.Size(201, 23)
        Me.ebPlayerName.TabIndex = 21
        Me.ebPlayerName.TabStop = False
        Me.ebPlayerName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerID
        '
        Me.ebPlayerID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerID.ButtonImage = CType(resources.GetObject("ebPlayerID.ButtonImage"), System.Drawing.Image)
        Me.ebPlayerID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebPlayerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebPlayerID.Location = New System.Drawing.Point(123, 245)
        Me.ebPlayerID.MaxLength = 8
        Me.ebPlayerID.Name = "ebPlayerID"
        Me.ebPlayerID.Size = New System.Drawing.Size(105, 23)
        Me.ebPlayerID.TabIndex = 5
        Me.ebPlayerID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 245)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 24)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Player:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 24)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Sucursal:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(40, 545)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 23)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Grabar"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(9, 545)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 23)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "F2"
        '
        'ebCodArticulo
        '
        Me.ebCodArticulo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodArticulo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodArticulo.ButtonImage = CType(resources.GetObject("ebCodArticulo.ButtonImage"), System.Drawing.Image)
        Me.ebCodArticulo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodArticulo.Location = New System.Drawing.Point(122, 132)
        Me.ebCodArticulo.Name = "ebCodArticulo"
        Me.ebCodArticulo.Size = New System.Drawing.Size(202, 23)
        Me.ebCodArticulo.TabIndex = 0
        Me.ebCodArticulo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodArticulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad:"
        '
        'nebCantidad
        '
        Me.nebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebCantidad.DecimalDigits = 0
        Me.nebCantidad.Location = New System.Drawing.Point(123, 189)
        Me.nebCantidad.Name = "nebCantidad"
        Me.nebCantidad.Size = New System.Drawing.Size(105, 23)
        Me.nebCantidad.TabIndex = 3
        Me.nebCantidad.Text = "0"
        Me.nebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Motivo Marca:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 26)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Caja:"
        '
        'ebFechaDefectuoso
        '
        Me.ebFechaDefectuoso.BackColor = System.Drawing.SystemColors.Info
        '
        '
        '
        Me.ebFechaDefectuoso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaDefectuoso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaDefectuoso.Location = New System.Drawing.Point(123, 302)
        Me.ebFechaDefectuoso.Name = "ebFechaDefectuoso"
        Me.ebFechaDefectuoso.ReadOnly = True
        Me.ebFechaDefectuoso.ShowDropDown = False
        Me.ebFechaDefectuoso.Size = New System.Drawing.Size(103, 23)
        Me.ebFechaDefectuoso.TabIndex = 32
        Me.ebFechaDefectuoso.TabStop = False
        Me.ebFechaDefectuoso.TodayButtonText = "Hoy"
        Me.ebFechaDefectuoso.Value = New Date(2016, 2, 15, 0, 0, 0, 0)
        Me.ebFechaDefectuoso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Codigo:"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(192, 545)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(114, 23)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "Graba/Imprimir"
        Me.Label22.Visible = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(169, 545)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "F9"
        Me.Label21.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(11, 300)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 17)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Fecha:"
        '
        'menuHerramientas1
        '
        Me.menuHerramientas1.Key = "menuHerramientas"
        Me.menuHerramientas1.Name = "menuHerramientas1"
        '
        'menuNuevo2
        '
        Me.menuNuevo2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuNuevo2.Image = CType(resources.GetObject("menuNuevo2.Image"), System.Drawing.Image)
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuCerrar2
        '
        Me.menuCerrar2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image
        Me.menuCerrar2.Image = CType(resources.GetObject("menuCerrar2.Image"), System.Drawing.Image)
        Me.menuCerrar2.Key = "menuCerrar"
        Me.menuCerrar2.Name = "menuCerrar2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuTemaAyuda1
        '
        Me.menuTemaAyuda1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage
        Me.menuTemaAyuda1.Image = CType(resources.GetObject("menuTemaAyuda1.Image"), System.Drawing.Image)
        Me.menuTemaAyuda1.Key = "menuTemaAyuda"
        Me.menuTemaAyuda1.Name = "menuTemaAyuda1"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Image = CType(resources.GetObject("menuNuevo1.Image"), System.Drawing.Image)
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'menuCerrar1
        '
        Me.menuCerrar1.Image = CType(resources.GetObject("menuCerrar1.Image"), System.Drawing.Image)
        Me.menuCerrar1.Key = "menuCerrar"
        Me.menuCerrar1.Name = "menuCerrar1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuEliminar1
        '
        Me.menuEliminar1.Image = CType(resources.GetObject("menuEliminar1.Image"), System.Drawing.Image)
        Me.menuEliminar1.Key = "menuEliminar"
        Me.menuEliminar1.Name = "menuEliminar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Nuevo
        '
        Me.Nuevo.Key = "menuNuevo"
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Text = "Nuevo"
        '
        'menuCerrar
        '
        Me.menuCerrar.Key = "menuCerrar"
        Me.menuCerrar.Name = "menuCerrar"
        Me.menuCerrar.Text = "Cerrar"
        '
        'menuEliminar
        '
        Me.menuEliminar.Key = "menuEliminar"
        Me.menuEliminar.Name = "menuEliminar"
        Me.menuEliminar.Text = "Eliminar"
        '
        'menuTemaAyuda
        '
        Me.menuTemaAyuda.Key = "menuTemaAyuda"
        Me.menuTemaAyuda.Name = "menuTemaAyuda"
        Me.menuTemaAyuda.Text = "Temas de Ayuda"
        '
        'CommandManager
        '
        Me.CommandManager.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.CommandManager.BottomRebar = Me.BottomRebar1
        Me.CommandManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.CommandManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoGuardar, Me.menuAyudaTema, Me.menuArchivoSalir, Me.menuAbrir, Me.menuCerrar3, Me.menuEliminar2, Me.menuImprimir})
        Me.CommandManager.ContainerControl = Me
        '
        '
        '
        Me.CommandManager.EditContextMenu.Key = ""
        Me.CommandManager.Id = New System.Guid("856b65f9-a60d-4329-ae34-f37ce0e31466")
        Me.CommandManager.LeftRebar = Me.LeftRebar1
        Me.CommandManager.LockCommandBars = True
        Me.CommandManager.RightRebar = Me.RightRebar1
        Me.CommandManager.ShowQuickCustomizeMenu = False
        Me.CommandManager.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.CommandManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.CommandManager
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator12, Me.menuArchivoGuardar2, Me.Separator10, Me.menuArchivoSalir1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(206, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        Me.UiCommandBar2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        Me.menuArchivoNuevo2.Text = "Nuevo"
        '
        'Separator12
        '
        Me.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator12.Key = "Separator"
        Me.Separator12.Name = "Separator12"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Image = CType(resources.GetObject("menuArchivoGuardar2.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        Me.menuArchivoGuardar2.Text = "Guardar"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        Me.menuArchivoSalir1.Text = "Salir"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.menuAbrir1, Me.Separator7, Me.menuArchivoGuardar1, Me.Separator8, Me.menuImprimir1, Me.Separator11, Me.menuCerrar4})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuImprimir1
        '
        Me.menuImprimir1.Key = "menuImprimir"
        Me.menuImprimir1.Name = "menuImprimir1"
        '
        'Separator11
        '
        Me.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator11.Key = "Separator"
        Me.Separator11.Name = "Separator11"
        '
        'menuCerrar4
        '
        Me.menuCerrar4.Key = "menuCerrar"
        Me.menuCerrar4.Name = "menuCerrar4"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ayuda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "Nuevo"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "Guardar"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Temas de Ayuda"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Icon = CType(resources.GetObject("menuArchivoSalir.Icon"), System.Drawing.Icon)
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "Abrir"
        '
        'menuCerrar3
        '
        Me.menuCerrar3.Image = CType(resources.GetObject("menuCerrar3.Image"), System.Drawing.Image)
        Me.menuCerrar3.Key = "menuCerrar"
        Me.menuCerrar3.Name = "menuCerrar3"
        Me.menuCerrar3.Text = "Cerrar"
        '
        'menuEliminar2
        '
        Me.menuEliminar2.Image = CType(resources.GetObject("menuEliminar2.Image"), System.Drawing.Image)
        Me.menuEliminar2.Key = "menuEliminar"
        Me.menuEliminar2.Name = "menuEliminar2"
        Me.menuEliminar2.Text = "Eliminar"
        '
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "Imprimir"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.CommandManager
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.CommandManager
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.CommandManager
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(669, 28)
        Me.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.pbImagen)
        Me.Panel1.Location = New System.Drawing.Point(1, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 288)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Tag = "NicePanelAutoScroll"
        Me.Panel1.Text = "NicePanelAutoScroll"
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImagen.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbImagen.ForeColor = System.Drawing.Color.Black
        Me.pbImagen.Location = New System.Drawing.Point(0, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(322, 288)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 1
        Me.pbImagen.TabStop = False
        '
        'frmDefectuososEcommerce
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(669, 605)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(0, 487)
        Me.Name = "frmDefectuososEcommerce"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcar / Desmarcar Artículos de Baja Calidad"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.grdCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NicePanel2.ResumeLayout(False)
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Objeto Defectuoso
    Dim oDefectuosoMgr As DefectuososManager

    'Objeto Artículo
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Objeto player
    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    Dim dtDetalleFactura As DataTable
    Dim dtTallas As DataTable = New DataTable("Tallas")

    Dim vExistencia As Integer = 0

    Dim bolImprimir As Boolean
    Dim UserNameAplicated As String = ""

    Dim dsDataColumn As New Data.DataSet

    Dim dtDefectuososEC As DataTable
    Dim dtDetalle As DataTable
    Dim oSapMgr As ProcesoSAPManager
    Dim TipoMov As String = ""
    Dim bValidaTemp As Boolean = False
    Dim oFacturaMgr As FacturaManager


#Region "Initialize"

    Private Sub InitializeObjects()



        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        'Creamos Defectuoso
        oDefectuosoMgr = New DefectuososManager(oAppContext, oAppSAPConfig)
        'oDefectuoso = oDefectuosoMgr.Create

        'Creamos Articulo
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

        'Creamos Vendedor
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        ' dtDefectuososEC = GetCodigosDefectuososEC()

        dtDefectuososEC = oFacturaMgr.BajaCalidadSel


        FillMotivos(True)

        dtDetalle = New DataTable("DetalleDefEC")
        With dtDetalle
            .Columns.Add("Material", GetType(String))
            .Columns.Add("Talla", GetType(String))
            .Columns.Add("Cantidad", GetType(Integer))
            .Columns.Add("Motivo", GetType(String))
            .Columns.Add("DesmarcadoID", GetType(String))
            .Columns.Add("MarcadoID", GetType(String))
            .AcceptChanges()
        End With

    End Sub

#End Region


#Region "Methods"

    'Private Sub GetCodigosDefectuososEC()
    '    '-----------------------------------------------------------------------------------------------------------------------------------
    '    'Obtenemos los códigos marcados como de baja calidad para Ecommerce para este centro de SAP
    '    '-----------------------------------------------------------------------------------------------------------------------------------
    '    dtDefectuososEC = oSapMgr.ZPOL_GET_DEFT_CENTRO
    '    '-----------------------------------------------------------------------------------------------------------------------------------
    '    'Quitamos los marcados de baja calidad por faltantes en traspasos de entrada, ya que la única forma de desmarcarlos es autorizando o
    '    'cancelando el traspaso de salida pendiente generado
    '    '-----------------------------------------------------------------------------------------------------------------------------------
    '    Dim MarcadoID As String = ""
    '    Dim dvFal As DataView
    '    Dim dtMotivosTemp As DataTable
    '    Dim oRowV As DataRowView

    '    dtMotivosTemp = oSapMgr.ZPOL_GET_MOTIVOS("FT")

    '    If dtMotivosTemp.Rows.Count > 0 Then
    '        MarcadoID = dtMotivosTemp.Rows(0)!ID
    '    End If

    '    dvFal = New DataView(dtDefectuososEC, "ID <> '" & MarcadoID & "'", "", DataViewRowState.CurrentRows)

    '    dtMotivosTemp = dtDefectuososEC.Clone
    '    For Each oRowV In dvFal
    '        dtMotivosTemp.ImportRow(oRowV.Row)
    '    Next

    '    dtDefectuososEC = dtMotivosTemp.Copy

    'End Sub

    Private Sub GetTallas(ByVal IDCorrida As String)

        Dim iCtalla As Integer
        Dim Dcol As DataColumn = New DataColumn
        Dim Drow As DataRow

        dtTallas = Nothing

        dtTallas = New DataTable

        Dcol = New DataColumn
        Dcol.AllowDBNull = True
        Dcol.ColumnName = "Talla"
        Dcol.Caption = "Talla"
        Dcol.DataType = System.Type.GetType("System.String")
        dtTallas.Columns.Add(Dcol)

        Dim dsTallas As DataSet = New DataSet
        Dim idx As Integer, iField As String

        dsTallas = oDefectuosoMgr.GetTallas(IDCorrida)

        '----------------------------------------------------------------------------------------------------------
        ' JNAVA (12.02.2016): Se agrego validacion por si esta mal la corrida no marque excepcion (retail)
        '----------------------------------------------------------------------------------------------------------
        If dsTallas Is Nothing Then
            MsgBox("La corrida del artículo no esta registrada.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, " Defectuosos")
            Me.Close()
            Exit Sub
        End If

        If dsTallas.Tables(0).Rows.Count > 0 Then

            For idx = 1 To 20

                iField = "C" + Format(idx, "00")

                If idx = 1 Then

                    Drow = dtTallas.NewRow
                    Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                    dtTallas.Rows.Add(Drow)


                    '    If dsTallas.Tables(0).Rows(0).Item(iField) <> oDefectuoso.Numero Then
                    '        Drow = dtTallas.NewRow
                    '        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                    '        dtTallas.Rows.Add(Drow)
                    '    End If

                Else

                    If (dsTallas.Tables(0).Rows(0).Item(iField) <> String.Empty) Then
                        Drow = dtTallas.NewRow
                        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                        dtTallas.Rows.Add(Drow)
                    End If

                    '    If (dsTallas.Tables(0).Rows(0).Item(iField) > 0) And (dsTallas.Tables(0).Rows(0).Item(iField) <> oDefectuoso.Numero) Then
                    '        Drow = dtTallas.NewRow
                    '        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
                    '        dtTallas.Rows.Add(Drow)
                    '    End If

                End If

            Next

        Else
            MsgBox("La corrida del artículo no esta registrada.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, " Defectuosos")

            Me.Close()

        End If

        dsTallas = Nothing

    End Sub

    Private Sub ValidaExistencias()

        Dim bEnc As Boolean = False
        Dim bValidado As Boolean = False

        vExistencia = 0

        If Me.rbMarcar.Checked AndAlso Me.ebCodArticulo.Text.Trim <> "" Then 'AndAlso Me.nebTalla.Text.Trim <> "" Then

            bValidado = True

            'Dim idxTalla As Integer

            'For idxTalla = 0 To (dtTallas.Rows.Count - 1)
            'If CStr(dtTallas.Rows(idxTalla).Item("Talla")).Trim.ToUpper = Me.nebTalla.Text.Trim.ToUpper Then
            '----------------------------------------------------------------------------------------------------------------------------
            'Sacamos el stock disponible
            '----------------------------------------------------------------------------------------------------------------------------
            'vExistencia = oDefectuosoMgr.GetStock(oAppContext.ApplicationConfiguration.Almacen, Me.ebCodArticulo.Text, Me.nebTalla.Text)
            '-----------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 07/05/2013: Validacion de los pedidos que estan pendientes por Facturar y Surtir
            '-----------------------------------------------------------------------------------------------------------------------------
            Dim dtNegadosSH As DataTable = GetStructureMaterialesNegados()
            Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(Me.ebCodArticulo.Text.Trim(), "", 0) 'Me.nebTalla.Text.Trim(), 0)
            ValidarMaterialesNegadosSH(dtMateriales, dtNegadosSH, "PF,P,RP")
            '----------------------------------------------------------------------------------------------------------------------------
            'Restamos los codigos ya marcados como de baja calidad
            '----------------------------------------------------------------------------------------------------------------------------
            vExistencia = CInt(dtMateriales.Rows(0)!Libres)
            vExistencia -= GetCantidadDefectuosaEC()
            '----------------------------------------------------------------------------------------------------------------------------
            'Restamos los codigos que esten en los pedidos pendientes por surtir, ya que deben negarlos para que se marquen
            'automaticamente
            '----------------------------------------------------------------------------------------------------------------------------
            vExistencia -= GetCantidadPedidaEC()
            bEnc = True
            'Exit For

            ' End If
            'Next
        ElseIf Me.rbDesmarcar.Checked AndAlso Me.ebCodArticulo.Text.Trim <> "" AndAlso Me.cmbMotivos.Text.Trim <> "" Then 'AndAlso Me.nebTalla.Text.Trim <> "" 

            bValidado = True

            Dim oRow As DataRow
            'Dim Talla As String = ""

            For Each oRow In dtDefectuososEC.Rows
                'If IsNumeric(Me.nebTalla.Text) Then
                '    Talla = Format(CDec(Me.nebTalla.Text), "#.0")
                'Else
                '    Talla = Me.nebTalla.Text
                'End If
                If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper AndAlso Me.cmbMotivos.Value = CStr(oRow!ID).Trim Then ' AndAlso Talla.Trim.ToUpper = CStr(oRow!Talla).Trim.ToUpper _

                    bEnc = True
                    vExistencia = CInt(oRow!Cantidad)
                    Exit For
                End If
            Next
        End If

        If vExistencia > 0 Then
            vExistencia -= GetCantidadAgregada()
            If Me.nebCantidad.Value > vExistencia Then Me.nebCantidad.Value = 0
        End If

        If bValidado AndAlso bEnc = False Then
            'Dim strMsg As String = "La talla " & Me.nebTalla.Text.Trim & " del codigo " & Me.ebCodArticulo.Text.Trim
            Dim strMsg As String = "El codigo " & Me.ebCodArticulo.Text.Trim
            If Me.rbMarcar.Checked Then
                strMsg &= " no existe."
            Else
                strMsg &= " no esta marcada como baja calidad."
            End If
            MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Me.nebTalla.Text = ""
            'Me.nebTalla.Focus()
            Me.ebCodArticulo.Text = ""
            Me.ebCodArticulo.Focus()

        End If

    End Sub

    Private Function GetCantidadDefectuosaEC() As Integer

        Dim intCant As Integer
        Dim oRow As DataRow
        Dim strTalla As String = ""

        'If IsNumeric(Me.nebTalla.Text.Trim) Then
        '    strTalla = Format(CDec(Me.nebTalla.Text), "#.0")
        'Else
        '    strTalla = Me.nebTalla.Text.Trim
        'End If
        For Each oRow In Me.dtDefectuososEC.Rows
            'If IsNumeric(oRow!Talla) Then
            '    strTalla = Format(CDec(oRow!Talla), "#.0")
            'Else
            '    strTalla = CStr(oRow!Talla).Trim
            'End If
            If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper Then 'AndAlso strTalla.Trim.ToUpper = CStr(oRow!Talla).Trim.ToUpper Then
                intCant += CInt(oRow!Cantidad)
            End If
        Next

        Return intCant

    End Function

    Private Function GetCantidadPedidaEC() As Integer

        Dim intCant As Integer
        Dim oRow As DataRow
        Dim strTalla As String = ""
        Dim dtPedidos As DataTable
        Dim dtPedidosDet As DataTable

        dtPedidos = oSapMgr.ZPOL_TRASLPEN(oSapMgr.Read_Centros, dtPedidosDet)

        For Each oRow In dtPedidosDet.Rows
            If IsNumeric(oRow!Talla) Then
                strTalla = Format(CDec(oRow!Talla), "#.0")
            Else
                strTalla = CStr(oRow!Talla).Trim
            End If
            If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper Then ' AndAlso strTalla.Trim.ToUpper = CStr(oRow!Talla).Trim.ToUpper Then
                intCant += CInt(oRow!Cant_Pendiente)
            End If
        Next

        Return intCant

    End Function

    Private Function ClearScreen(ByVal bAgrega As Boolean, Optional ByVal Valida As Boolean = True, Optional ByVal bLimpiar As Boolean = True) As Boolean

        If Valida AndAlso Not dtDetalle Is Nothing AndAlso dtDetalle.Rows.Count > 0 Then
            If MessageBox.Show("No has guardado el movimiento ¿Estas seguro de limpiar los datos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Return False
            End If
        ElseIf bLimpiar = False Then
            Return False
        End If

        Me.cbCodCaja.Text = oAppContext.ApplicationConfiguration.NoCaja
        vExistencia = 0
        TipoMov = ""
        UserNameAplicated = ""
        Me.ebCodArticulo.Text = ""
        'Me.nebTalla.Text = ""
        Me.nebCantidad.Value = 0
        Me.cmbMotivos.Text = ""
        Me.cmbMotivos.Value = ""
        Me.cmbMotivosDesmarca.Text = ""
        Me.cmbMotivosDesmarca.Value = ""
        Me.ebPlayerID.Text = ""
        Me.ebPlayerName.Text = ""
        If Not dtDetalle Is Nothing AndAlso bAgrega = False Then dtDetalle.Clear()
        ActualizaGrid()
        Me.ebFechaDefectuoso.Text = Format(Today, "dd/MM/yyyy")
        If Not oSapMgr Is Nothing Then FillMotivos()

        pbImagen.Image = Nothing

        If Me.rbMarcar.Checked Then
            Me.cmbMotivosDesmarca.Enabled = False
            Me.cmbMotivos.Enabled = True
        Else
            Me.cmbMotivosDesmarca.Enabled = True
            Me.cmbMotivos.Enabled = False
        End If

        Me.ebCodArticulo.Focus()

        Return True

    End Function

    Private Function ValidaDatos() As Boolean
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 16/06/2015: Valida en caso de que este en la configuración que tenga permisos de marcar y desmarcar articulos de baja calidad
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.BloqueaBajaCalidad = True Then
            oAppContext.Security.CloseImpersonatedSession()
            If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.MarcarDesmarcarDefectuosoBajaCalidad") = False Then
                MessageBox.Show("No cuenta con los permisos necesarios para agregar o marcar Artículos Defectuosos de Baja Calidad", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.ebCodArticulo.Focus()
                Return False
            End If
            oAppContext.Security.CloseImpersonatedSession()
        End If

        If Me.ebCodArticulo.Text.Trim = "" Then
            MessageBox.Show("Es necesario indicar el codigo.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebCodArticulo.Focus()
            Return False
            'ElseIf Me.nebTalla.Text.Trim = "" Then
            '    MessageBox.Show("Especifique la talla.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Me.nebTalla.Focus()
            '    Return False
        ElseIf Me.nebCantidad.Value <= 0 Then
            MessageBox.Show("Especifique la cantidad.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.nebCantidad.Focus()
            Return False
        ElseIf Me.rbMarcar.Checked AndAlso Me.cmbMotivos.Text.Trim = "" Then
            MessageBox.Show("Especifique el motivo del marcado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbMotivos.Focus()
            Return False
        ElseIf Me.rbDesmarcar.Checked AndAlso Me.cmbMotivosDesmarca.Text.Trim = "" Then
            MessageBox.Show("Especifique el motivo del desmarcado.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbMotivosDesmarca.Focus()
            Return False
        ElseIf Me.ebPlayerID.Text.Trim = "" OrElse Me.ebPlayerName.Text.Trim = "" Then
            MessageBox.Show("Especifique el codigo de vendedor.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebPlayerID.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub AgregaRegistro()

        Dim oNewRow As DataRow = dtDetalle.NewRow
        Dim idx As Integer = -1

        If ValidarCodigoAgregado(idx) Then
            dtDetalle.Rows(idx)!Cantidad += Me.nebCantidad.Value
        Else

            With oNewRow
                !Material = Me.ebCodArticulo.Text.Trim
                '!Talla = Me.nebTalla.Text.Trim
                !Cantidad = Me.nebCantidad.Value
                '!Motivo = Me.cmbMotivos.Text.Trim
                If Me.rbDesmarcar.Checked Then
                    !DesmarcadoID = Me.cmbMotivosDesmarca.Value
                    !MarcadoID = Me.cmbMotivos.Value
                    !Motivo = Me.cmbMotivosDesmarca.Text.Trim
                Else
                    !DesmarcadoID = ""
                    !MarcadoID = Me.cmbMotivos.Value
                    !Motivo = Me.cmbMotivos.Text.Trim
                End If
            End With
            dtDetalle.Rows.Add(oNewRow)

        End If

        ActualizaGrid()

        ClearScreen(True, False)

    End Sub

    Private Function ValidarCodigoAgregado(ByRef idx As Integer) As Boolean
        Dim bRes As Boolean = False
        Dim oRow As DataRow
        Dim i As Integer = 0

        For Each oRow In dtDetalle.Rows
            If Me.rbMarcar.Checked Then
                If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper AndAlso CStr(oRow!Motivo).Trim.ToUpper = Me.cmbMotivos.Text.Trim.ToUpper Then 'AndAlso CStr(oRow!Talla).Trim.ToUpper = Me.nebTalla.Text.Trim.ToUpper _

                    bRes = True
                    'idx = i
                    'Exit For
                End If
            Else
                If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper AndAlso CStr(oRow!Motivo).Trim.ToUpper = Me.cmbMotivosDesmarca.Text.Trim.ToUpper Then 'AndAlso CStr(oRow!Talla).Trim.ToUpper = Me.nebTalla.Text.Trim.ToUpper Then

                    bRes = True
                End If
            End If
            If bRes Then
                idx = i
                Exit For
            End If
            i += 1
        Next

        Return bRes

    End Function

    Private Function GetCantidadAgregada() As Integer
        Dim Cant As Integer = 0
        Dim oRow As DataRow

        For Each oRow In dtDetalle.Rows
            If Me.rbMarcar.Checked Then
                If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper Then 'AndAlso CStr(oRow!Talla).Trim.ToUpper = Me.nebTalla.Text.Trim.ToUpper Then
                    Cant += oRow!Cantidad
                End If
            Else
                If CStr(oRow!Material).Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper AndAlso CStr(Me.cmbMotivos.Value).Trim = CStr(oRow!MarcadoID).Trim Then 'AndAlso CStr(oRow!Talla).Trim.ToUpper = Me.nebTalla.Text.Trim.ToUpper _
                    Cant += oRow!Cantidad
                End If
            End If
        Next

        Return Cant

    End Function

    Private Sub EliminarRegistro()
        If dtDetalle.Rows.Count > 0 Then
            dtDetalle.Rows.RemoveAt(Me.grdCodigos.Row)
            dtDetalle.AcceptChanges()
            ActualizaGrid()
        End If
    End Sub

    Private Sub ActualizaGrid()
        Me.grdCodigos.DataSource = dtDetalle
        Me.grdCodigos.Refresh()
    End Sub

    'Private Sub FillDataMovimiento(ByVal ID As Integer)

    '    With oDefectuoso.Movimiento

    '        .CodTipoMov = 0
    '        .TipoMovimiento = ""
    '        .StatusMov = "A"
    '        .CodAlmacenMov = oDefectuoso.CodAlmacen
    '        .Destino = oDefectuoso.CodAlmacen
    '        .Folio = ID
    '        .CodArticuloMov = oArticulo.CodArticulo
    '        .Descripcion = oArticulo.Descripcion
    '        .NumeroMov = 0
    '        .Total = 0
    '        .Apartados = 0
    '        .Defectuosos = 0
    '        .Promocion = 0
    '        .VtasEspeciales = 0
    '        .Consignacion = 0
    '        .Transito = 0
    '        .CodLinea = oArticulo.Codlinea
    '        .CodMarca = oArticulo.CodMarca
    '        .CodFamilia = oArticulo.CodFamilia
    '        .CodUnidad = oArticulo.CodUnidadVta
    '        .CodUso = oArticulo.CodUso
    '        .CodCategoria = oArticulo.CodCategoria
    '        .UsuarioMov = oDefectuoso.Usuario
    '        .CostoUnit = oArticulo.PrecioVenta
    '        .PrecioUnit = oArticulo.PrecioVenta
    '        .FolioControl = ""
    '        .CodCajaMov = oDefectuoso.CodCaja

    '    End With


    'End Sub


    Private Function FiltrarMotivo(ByVal strMotivo As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If oRow!CodMotivoDefectuosoPosicion <> strMotivo Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp

    End Function


    '------------------------------------------------------------------------------
    ' JNAVA (29.02.2016): Llenamos los motivos de defectuosos nuevos
    '------------------------------------------------------------------------------
    Private Sub FillMotivos(Optional ByVal bFirst As Boolean = False)

        Dim dtTemp As DataTable
        Dim DefectuososMgr As New CatalogoArticuloManager(oAppContext)
        'Dim cmbTemp As Janus.Windows.GridEX.EditControls.MultiColumnCombo

        '-----------------------------------------------------------------------------------------------------------------------------------
        ' Obtenemos los motivos de marcado/desmarcado de SAP
        '-----------------------------------------------------------------------------------------------------------------------------------
        dtTemp = DefectuososMgr.GetMotivosDefectuosos()

        '------------------------------------------------------------------------------
        ' MLVARGAS (07.07.2022): Quitar opciones de artículos defectuosos
        '------------------------------------------------------------------------------

        dtTemp = FiltrarMotivo("Z3", dtTemp)
        dtTemp = FiltrarMotivo("Z9", dtTemp)

        'If Me.rbMarcar.Checked Then
        '    cmbTemp = Me.cmbMotivos
        'Else
        '    cmbTemp = Me.cmbMotivosDesmarca
        '    'Me.cmbMotivos.DataSource = Nothing
        '    'Me.cmbMotivos.Refresh()
        'End If

        With Me.cmbMotivos 'cmbTemp
            .Clear()
            If bFirst Then
                Me.cmbMotivos.DropDownList.Columns.Add("Cod.")
                Me.cmbMotivos.DropDownList.Columns.Add("Descripción")
                Me.cmbMotivosDesmarca.DropDownList.Columns.Add("Cod.")
                Me.cmbMotivosDesmarca.DropDownList.Columns.Add("Descripción")
            End If
            .DataSource = dtTemp
            .DropDownList.Columns("Cod.").DataMember = "CodMotivoDefectuosoPosicion"
            .DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "MotivoDefectuoso"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "MotivoDefectuoso"
            .ValueMember = "CodMotivoDefectuosoPosicion"
            .DropDownList.Columns("Cod.").Visible = False

            .Refresh()
        End With

    End Sub

    'Private Sub FillMotivos(Optional ByVal bFirst As Boolean = False)

    '    Dim dtTemp As DataTable
    '    Dim cmbTemp As Janus.Windows.GridEX.EditControls.MultiColumnCombo

    '    If Me.rbMarcar.Checked Then
    '        dtTemp = oSapMgr.ZPOL_GET_MOTIVOS("MD")
    '        cmbTemp = Me.cmbMotivos
    '    Else
    '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        'Obtenemos los motivos de desmarcado de SAP
    '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        dtTemp = oSapMgr.ZPOL_GET_MOTIVOS("DD")
    '        cmbTemp = Me.cmbMotivosDesmarca

    '        Me.cmbMotivos.DataSource = Nothing
    '        Me.cmbMotivos.Refresh()
    '    End If

    '    With cmbTemp
    '        .Clear()
    '        If bFirst Then
    '            Me.cmbMotivos.DropDownList.Columns.Add("Cod.")
    '            Me.cmbMotivos.DropDownList.Columns.Add("Descripción")
    '            Me.cmbMotivosDesmarca.DropDownList.Columns.Add("Cod.")
    '            Me.cmbMotivosDesmarca.DropDownList.Columns.Add("Descripción")
    '        End If
    '        .DataSource = dtTemp
    '        .DropDownList.Columns("Cod.").DataMember = "ID"
    '        .DropDownList.Columns("Cod.").Width = 50
    '        .DropDownList.Columns("Descripción").DataMember = "Motivo"
    '        .DropDownList.Columns("Descripción").Width = 200
    '        .DisplayMember = "Motivo"
    '        .ValueMember = "ID"
    '        .DropDownList.Columns("Cod.").Visible = False

    '        .Refresh()
    '    End With

    'End Sub

    Private Sub FillMotivosDesmarcadoByCodigo()

        Dim dvCodigo As DataView
        Dim strTalla As String = ""

        'If IsNumeric(Me.nebTalla.Text.Trim) Then
        '    strTalla = Format(CDec(Me.nebTalla.Text.Trim), "#.0")
        'Else
        '    strTalla = Me.nebTalla.Text.Trim
        'End If

        dvCodigo = New DataView(dtDefectuososEC, "Material = '" & Me.ebCodArticulo.Text.Trim & "'", "", DataViewRowState.CurrentRows) 'and Talla = '" & strTalla & "'", "", DataViewRowState.CurrentRows)

        With Me.cmbMotivosDesmarca
            .Clear()
            .DataSource = dvCodigo
            .DropDownList.Columns("Cod.").DataMember = "IDMotivo"
            .DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Motivo"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "Motivo"
            .ValueMember = "IDMotivo"
            .DropDownList.Columns("Cod.").Visible = False

            .Refresh()
        End With

    End Sub

    'Private Sub SaveData()

    '    'Me.ebDefectoNota.Text = Me.ebDefectoNota.Text.Trim()

    '    Dim vDefectuosoID As Integer

    '    If ValidaDatos() = False Then
    '        Exit Sub
    '    End If

    '    'Guardamos 
    '    'oDefectuoso.FacturaID = vFacturaID
    '    oDefectuoso.Usuario = oDefectuoso.UsuarioMov
    '    oDefectuoso.CostoUnit = oArticulo.PrecioVenta
    '    vDefectuosoID = oDefectuosoMgr.Save(oDefectuoso)

    '    If vDefectuosoID = 0 Then

    '        MsgBox("El defectuoso no se guardó.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, " Defectuosos")

    '    Else

    '        'Complemento el objeto de Defectuoso con los valores necesario para efectuar la operación de marcado
    '        FillDataMovimiento(vDefectuosoID)

    '        'Guardamos de Existencia en el inventario
    '        oDefectuosoMgr.SaveMoveInOut(0, "O", oDefectuoso.Numero, oDefectuoso)

    '        MsgBox("Defectuoso guardado satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

    '        If bolImprimir Then
    '            PrintComprobanteComparativo()
    '        End If


    '        'Limpiamos la pantalla para una nueva captura

    '        ClearScreen()

    '        cbCodCaja.Focus()

    '    End If

    'End Sub

    'Public Sub PrintComprobanteComparativo()



    '    Dim oARReporte As New rptPapeletaArticulosDefectuosos(oDefectuoso)
    '    'Dim oReportViewer As New ReportViewerForm

    '    oARReporte.Document.Name = "Analisis Comparativo"

    '    oARReporte.Run()

    '    'oReportViewer.Report = oARReporte
    '    'oReportViewer.Show()

    '    Try
    '        oARReporte.Document.Print(False, False)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub

    'Private Sub LoadSearchFormDefectuso()

    '    Dim oOpenRecordDlg As New OpenRecordDialog
    '    oOpenRecordDlg.CurrentView = New DefectuososOpenRecordDialogView

    '    oOpenRecordDlg.ShowDialog()

    '    If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

    '        oDefectuosoMgr.LoadInto(oOpenRecordDlg.Record.Item("FolioMovimiento"), oDefectuoso)

    '        If (Not oDefectuoso Is Nothing) Then
    '            'Me.nebDefectuosoID.Value = oDefectuoso.FolioMovimiento
    '            oArticulo = oArticuloMgr.Load(oDefectuoso.CodArticulo)

    '            If oArticulo.WithImage = True Then
    '                pbImagen.Image = Image.FromStream(oArticulo.Imagen)
    '            Else
    '                pbImagen.Image = Nothing
    '            End If

    '            Me.cbCodCaja.ReadOnly = True
    '            'Me.nebFolioFactura.ReadOnly = True
    '            'Me.ebCodSAP.ReadOnly = True
    '            Me.ebCodArticulo.ReadOnly = True
    '            Me.nebTalla.ReadOnly = True
    '            Me.nebCantidad.ReadOnly = True
    '            Me.ebDefectoNota.ReadOnly = True
    '            Me.ebResponsableID.ReadOnly = True
    '            Me.ebPlayerID.ReadOnly = True

    '            Me.cbCodCaja.BackColor = System.Drawing.Color.Ivory
    '            'Me.nebFolioFactura.BackColor = System.Drawing.Color.Ivory
    '            'Me.ebCodSAP.BackColor = System.Drawing.Color.Ivory
    '            Me.ebCodArticulo.BackColor = System.Drawing.Color.Ivory
    '            Me.nebTalla.BackColor = System.Drawing.Color.Ivory
    '            Me.nebCantidad.BackColor = System.Drawing.Color.Ivory
    '            Me.ebDefectoNota.BackColor = System.Drawing.Color.Ivory
    '            Me.ebPlayerID.BackColor = System.Drawing.Color.Ivory
    '            Me.ebResponsableID.BackColor = System.Drawing.Color.Ivory

    '            oVendedor = oVendedoresMgr.Load(oDefectuoso.UsuarioMov)

    '            If Not oVendedor Is Nothing Then
    '                Me.ebPlayerName.Text = oVendedor.Nombre
    '            End If

    '            oVendedor = oVendedoresMgr.Load(oDefectuoso.Autorizo)

    '            If Not oVendedor Is Nothing Then
    '                Me.ebResponsableName.Text = oVendedor.Nombre
    '            End If


    '        Else
    '            MsgBox("El Folio de la factura no existe.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Defectuosos")

    '            'Limpio la pantalla
    '            ClearScreen()

    '            'nebDefectuosoID.Focus()

    '        End If

    '    End If

    'End Sub

    'Private Sub LoadSearchFormFactura()
    '    Dim dsTemFactura As DataSet
    '    Dim oOpenRecordDlg As New OpenRecordDialog

    '    oOpenRecordDlg.CurrentView = New FacturaOpenRecordDialogView

    '    oOpenRecordDlg.ShowDialog()

    '    If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

    '        dsTemFactura = oDefectuosoMgr.LoadFacturaByID(oOpenRecordDlg.Record.Item("ID"))

    '        If Not (dsTemFactura Is Nothing) Then

    '            oDefectuoso.FacturaID = oOpenRecordDlg.Record.Item("ID")

    '            oDefectuoso.FolioFactura = dsTemFactura.Tables(0).Rows(0).Item("FolioFactura")

    '            If dsTemFactura.Tables(0).Rows(0).Item("FolioSap") <> "" Then
    '                oDefectuoso.FolioSAP = dsTemFactura.Tables(0).Rows(0).Item("FolioSap")
    '            End If


    '        Else

    '            MsgBox("La Factura seleccionada no existe.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Defectuosos")

    '            cbCodCaja.Focus()

    '        End If

    '    End If

    'End Sub


    Private Sub ObtenerImagen(ByVal urlImage As String)
        Dim strUrlImage As String = String.Empty

        '-----------------------------------------------------
        Try
            '------------------------------------------------------------------------------------------
            ' Si el nombre de la imagen lleva el texto
            ' [file:///]  QUITARLO porque genera errores 
            If urlImage.IndexOf("file:///", 0) = 0 Then
                urlImage = urlImage.Substring(8)
            End If
            '--------------------------------------------------------

            strUrlImage = urlImage
            pbImagen.ImageLocation = strUrlImage
            ' carga la imagen de forma síncrona
            pbImagen.Load()

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al tratar de cargar la imagen: " & strUrlImage)
            'Throw ex            
        End Try
    End Sub



    Private Sub LoadSearchFormArticulos()

        Dim oOpenRecordDlg As New OpenRecordDialog2

        If Me.rbMarcar.Checked Then
            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2
        Else
            oOpenRecordDlg.CurrentView = New DefectuososEcommerceOpenRecordDialogView
        End If

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            Me.ebCodArticulo.Text = oOpenRecordDlg.Record.Item("Código")


            'If File.Exists(Application.StartupPath & "\Fotos\" & Me.ebCodArticulo.Text.Trim & ".JPG") Then
            '    pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & Me.ebCodArticulo.Text.Trim & ".JPG")
            'Else
            '    pbImagen.Image = Nothing
            'End If

        End If

    End Sub

    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        'If Me.ebPlayerID.Text.Trim = "" Then

        If Vpa_bolOpenRecordDialog = True Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then
                Me.ebPlayerID.Text = oOpenRecordDlg.Record.Item("CodVendedor")
            End If

        End If

        oVendedor = Nothing
        oVendedor = oVendedoresMgr.Load(Me.ebPlayerID.Text.Trim)

        If oVendedor Is Nothing Then
            MessageBox.Show("Código de vendedor no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebPlayerID.Text = ""
            Me.ebPlayerName.Text = ""
            Me.ebPlayerID.Focus()
        Else
            Me.ebPlayerID.Text = oVendedor.ID
            Me.ebPlayerName.Text = oVendedor.Nombre
        End If
        'Else
        'Me.ebPlayerName.Text = ""
        'End If

        Me.ebPlayerID.Text = Me.ebPlayerID.Text.PadLeft(8, "0")

    End Sub

    Private Sub GuardarMovimiento()
        If dtDetalle.Rows.Count > 0 Then
            oAppContext.Security.CloseImpersonatedSession()
            If Not oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Inventarios.TraspasosSalida") Then
                oAppContext.Security.CloseImpersonatedSession()
            Else
                UserNameAplicated = oAppContext.Security.CurrentUser.Name
                oAppContext.Security.CloseImpersonatedSession()

                '------------------------------------------------------------------------------------------------------------------------------
                ' JNAVA (20.01.2017): Si marca error en SAP, no continuamos 
                '------------------------------------------------------------------------------------------------------------------------------
                'Desmarcamos los codigos seleccionados en SAP
                '------------------------------------------------------------------------------------------------------------------------------
                Dim strRes As String = String.Empty
                strRes = oSapMgr.ZPOL_DEFECTUOSOS_INS("", IIf(Me.rbMarcar.Checked, "MD", "DD"), UserNameAplicated, dtDetalle)
                If strRes.Trim.ToUpper <> "Y" Then
                    Exit Sub
                End If
                '------------------------------------------------------------------------------------------------------------------------------


                '------------------------------------------------------------------------------------------------------------------------------
                'MLVARGAS 18/07/2022: Grabar a base de datos local los artículos de baja calidad
                '------------------------------------------------------------------------------------------------------------------------------

                If rbMarcar.Checked Then
                    oFacturaMgr.SaveBajaCalidad(dtDetalle)
                Else
                    oFacturaMgr.DesmarcaBajaCalidad(dtDetalle)
                End If


                '------------------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 16/05/2015: Bloquea o desbloquea Artículos de Baja Calidad
                '------------------------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.BloqueaBajaCalidad = True Then
                    If Me.rbMarcar.Checked Then
                        SaveDefectuosos(dtDetalle)
                    Else
                        DesmarcarDefectuosos(dtDetalle)
                    End If
                End If
                'dtDefectuososEC = oSapMgr.ZPOL_GET_DEFT_CENTRO
                '------------------------------------------------------------------------------------------------------------------------------
                'Actualizamos la información de los codigos marcados que quedan desde SAP
                '------------------------------------------------------------------------------------------------------------------------------
                'dtDefectuososEC = GetCodigosDefectuososEC()
                dtDefectuososEC = oFacturaMgr.BajaCalidadSel()
                '------------------------------------------------------------------------------------------------------------------------------
                If Me.rbMarcar.Checked Then
                    MessageBox.Show("Los codigos se han marcado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Los codigos se han desmarcado correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ClearScreen(False, False)
            End If
        Else
            MessageBox.Show("No hay codigos en agregados para realizar el movimiento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region


#Region "Menus And Bars Options"

    Private Sub CommandManager_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles CommandManager.CommandClick
        Select Case e.Command.Key

            Case "menuArchivoSalir"

                If ClearScreen(False) Then
                    Me.Close()
                End If

            Case "menuArchivoNuevo"

                ClearScreen(False)

                Me.ebCodArticulo.Focus()

            Case "menuArchivoGuardar"

                'bolImprimir = True
                'SaveData()
                GuardarMovimiento()


            Case "menuAbrir"

                'Me.LoadSearchFormDefectuso()

            Case "menuImprimir"

                'PrintComprobanteComparativo()

            Case "menuAyudaTema"

                'TODO : Implementar Aqui la Ayuda

            Case Else

        End Select
    End Sub

#End Region

#Region "Events Form"

    Private Sub frmDefectuosos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'InitializeObjects()

        'InitializeBinding()

        'GetCajaToCombo()

        ClearScreen(False)

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oCatalogoAlmacen As Almacen, strCentro As String = oSapMgr.Read_Centros

        oCatalogoAlmacen = oCatalogoAlmacenesMgr.Load(strCentro) 'oAppContext.ApplicationConfiguration.Almacen)

        Me.ebSucursal.Text = oCatalogoAlmacen.ID & " " & oCatalogoAlmacen.Descripcion

        'cbCodCaja.Focus()

        cbCodCaja.Focus()

        NicePanel2.FooterText = "Grupo Dportenis @  " & CStr(Date.Now.Year) '2005

    End Sub

    'Private Sub nebDefectuosoID_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.LoadSearchFormDefectuso()
    'End Sub

    'Private Sub nebDefectuosoID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.Alt And e.KeyCode = Keys.S Then

    '        Me.LoadSearchFormDefectuso()

    '    ElseIf e.KeyCode = Keys.Enter Then

    '        If nebDefectuosoID.Value > 0 Then
    '            oDefectuosoMgr.LoadInto(nebDefectuosoID.Value, oDefectuoso)

    '            If (Not oDefectuoso Is Nothing) Then
    '                oArticulo = oArticuloMgr.Load(oDefectuoso.CodArticulo)
    '                Me.nebDefectuosoID.Value = oDefectuoso.FolioMovimiento

    '                If oArticulo.WithImage = True Then
    '                    pbImagen.Image = Image.FromStream(oArticulo.Imagen)
    '                Else
    '                    pbImagen.Image = Nothing
    '                End If

    '                Me.cbCodCaja.ReadOnly = True
    '                'Me.nebFolioFactura.ReadOnly = True
    '                'Me.ebCodSAP.ReadOnly = True
    '                Me.ebCodArticulo.ReadOnly = True
    '                Me.nebTalla.ReadOnly = True
    '                Me.nebCantidad.ReadOnly = True
    '                Me.ebDefectoNota.ReadOnly = True
    '                Me.ebResponsableID.ReadOnly = True

    '                Me.cbCodCaja.BackColor = System.Drawing.Color.Ivory
    '                'Me.nebFolioFactura.BackColor = System.Drawing.Color.Ivory
    '                'Me.ebCodSAP.BackColor = System.Drawing.Color.Ivory
    '                Me.ebCodArticulo.BackColor = System.Drawing.Color.Ivory
    '                Me.nebTalla.BackColor = System.Drawing.Color.Ivory
    '                Me.nebCantidad.BackColor = System.Drawing.Color.Ivory
    '                Me.ebDefectoNota.BackColor = System.Drawing.Color.Ivory
    '                Me.ebResponsableID.BackColor = System.Drawing.Color.Ivory

    '            Else
    '                MsgBox("El Folio de defectuoso no existe. Verifique por favor.", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Defectuosos")

    '                'Limpio la pantalla
    '                ClearScreen()

    '                nebDefectuosoID.Focus()

    '            End If
    '        End If


    '    End If
    'End Sub


    'Private Sub cbCodCaja_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If cbCodCaja.ReadOnly Then
    '        Exit Sub
    '    End If

    '    If cbCodCaja.Text <> String.Empty Then
    '        If cbCodCaja.NotInList Then

    '            MsgBox("Seleccione un número de caja válido.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

    '            e.Cancel = True

    '        End If
    '    End If
    'End Sub

    'Private Sub nebFolioFactura_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    If nebFolioFactura.ReadOnly Then
    '        Exit Sub
    '    End If



    '    If (nebFolioFactura.Value <> 0) Then

    '        dsDataColumn = oDefectuosoMgr.GetDetailFactura(nebFolioFactura.Value, cbCodCaja.Text)

    '        If (dsDataColumn Is Nothing) Then

    '            MsgBox("La Factura no corresponde a la Caja " & cbCodCaja.Text & " o no existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

    '            oDefectuoso.FacturaID = 0
    '            oDefectuoso.FolioFactura = 0
    '            oDefectuoso.FolioSAP = "0"

    '            e.Cancel = True
    '        Else

    '            oDefectuoso.FacturaID = dsDataColumn.Tables(0).Rows(0).Item("FacturaID")

    '        End If
    '    Else

    '        MsgBox("No registro un numero de Factura PRO, por lo cual es necesario que especifique el origen del defectuoso.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

    '    End If

    'End Sub

    'Private Sub nebFolioFactura_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.LoadSearchFormFactura()
    'End Sub

    'Private Sub nebFolioFactura_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If (e.KeyData.Alt And e.KeyCode = Keys.S) Then
    '        Me.LoadSearchFormFactura()
    '    End If
    'End Sub

    Private Sub ebCodArticulo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodArticulo.ButtonClick

        Me.LoadSearchFormArticulos()

    End Sub

    Private Sub ebCodArticulo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodArticulo.Validating
        If ebCodArticulo.Text.Trim <> "" And vExistencia <= 0 Then

            oArticulo = oArticuloMgr.Load(ebCodArticulo.Text)

            Me.ebCodArticulo.Text = Me.ebCodArticulo.Text.PadLeft(18, "0")

            '------------------------------------------------------------------------------------------
            ' MLVARGAS (08.07.2022) Cargar la imagen
            '------------------------------------------------------------------------------------------

            Dim codColor As String = ""
            codColor = oArticuloMgr.SelectCodColor(ebCodArticulo.Text.Trim)
            If codColor <> "NA" Then
                'Buscar la imagen del producto
                Dim generico As String = ebCodArticulo.Text.Substring(8, 7)
                Dim strPath As String = oConfigCierreFI.ImagenesExistencia & generico & "-" & codColor & ".jpg"
                ObtenerImagen(strPath)
            Else
                pbImagen.Image = Nothing
            End If


            '-------------------------------------------------------------------------------
            ' JNAVA (16.02.2016): Se agrego para poder desmarcar defectuosos en retail
            '-------------------------------------------------------------------------------
            vExistencia = 0

            If Not oArticulo Is Nothing Then

                If Me.rbDesmarcar.Checked Then
                    Dim bEnc As Boolean = False
                    For Each oRow As DataRow In dtDefectuososEC.Rows
                        If CStr(oRow!Material).PadLeft(18, "0").Trim.ToUpper = Me.ebCodArticulo.Text.Trim.ToUpper Then
                            Me.ebCodArticulo.Focus()
                            '-------------------------------------------------------------------------------
                            ' JNAVA (16.02.2016): Se agrego para poder desmarcar defectuosos en retail
                            '-------------------------------------------------------------------------------
                            vExistencia += CInt(oRow!Cantidad)
                            bEnc = True
                            'Exit For
                        End If
                    Next
                    If bEnc = False Then
                        MessageBox.Show("El artículo indicado no esta marcado como de baja calidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.ebCodArticulo.Text = ""
                        Me.ebCodArticulo.Focus()
                        '-------------------------------------------------------------------------------
                        ' JNAVA (16.02.2016): Se agrego para poder desmarcar defectuosos en retail
                        '-------------------------------------------------------------------------------
                        vExistencia = 0
                        Exit Sub
                    End If

                    '-------------------------------------------------------------------------------
                    ' JNAVA (26.01.2017): Llenamos los motivos de desmarcado por codigo
                    '-------------------------------------------------------------------------------
                    FillMotivosDesmarcadoByCodigo()
                End If

                If File.Exists(Application.StartupPath & "\Fotos\" & Me.ebCodArticulo.Text.Trim & ".JPG") Then
                    pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & Me.ebCodArticulo.Text.Trim & ".JPG")
                Else
                    pbImagen.Image = Nothing
                End If

                'GetTallas(oArticulo.CodCorrida)

            Else
                If Me.rbMarcar.Checked Then
                    MsgBox("El artículo que se desea marcar no se encuentra en el catalogo de articulos.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
                Else
                    MsgBox("El artículo que se desea desmarcar no se encuentra en el catalogo de articulos.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Me.Text)
                End If
                Me.ebCodArticulo.Text = ""
            End If

        End If

    End Sub

    Private Sub ebCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodArticulo.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            Me.LoadSearchFormArticulos()
        End If
    End Sub

    'Private Sub nebTalla_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodArticulo.Validating

    '    If ebCodArticulo.Text.Trim <> "" AndAlso Me.rbDesmarcar.Checked Then Me.FillMotivosByCodigo() ' AndAlso Me.nebTalla.Text.Trim <> "" AndAlso Me.rbDesmarcar.Checked Then Me.FillMotivosByCodigo()

    '    ValidaExistencias()

    '    'End If

    'End Sub

    Private Sub cmbMotivos_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbMotivos.Validating

        ValidaExistencias()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidaDatos() Then
            AgregaRegistro()
        End If
    End Sub

    Private Sub grdCodigos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdCodigos.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                EliminarRegistro()
        End Select
    End Sub

    Private Sub rbMarcar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMarcar.CheckedChanged
        'If Me.rbMarcar.Checked = False Then
        '    bValidaTemp = True
        'End If
        'If ClearScreen(False, bValidaTemp, bValidaTemp) = False Then
        '    bValidaTemp = False
        '    Me.rbDesmarcar.Checked = False
        '    'Me.rbMarcar.Checked = True
        'End If
        ClearScreen(False, False)
        'FillMotivos()
    End Sub

    Private Sub ebPlayerID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebPlayerID.Validating

        Sm_Buscar()

    End Sub

    Private Sub frmDefectuosos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.F2 Then

            bolImprimir = False
            GuardarMovimiento()

        ElseIf e.KeyCode = Keys.F9 Then

            'bolImprimir = True
            'SaveData()

        ElseIf e.KeyCode = Keys.Escape Then

            If ClearScreen(False) Then
                Me.Close()
            End If

        End If
    End Sub

    Private Sub nebCantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nebCantidad.Validating

        If Me.nebCantidad.Value > 0 Then

            If vExistencia = 0 Then
                ValidaExistencias()
            End If


            If Me.nebCantidad.Value > vExistencia Then
                Dim strMsg As String = "La cantidad indicada supera el número de piezas "
                If Me.rbMarcar.Checked Then
                    strMsg &= "en existencia."
                Else
                    strMsg &= "marcadas como de baja calidad."
                End If
                MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.nebCantidad.Value = 0
                Me.nebCantidad.Focus()
            End If
        End If

    End Sub

    Private Sub ebPlayerID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayerID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        End If

    End Sub

    Private Sub ebPlayerID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayerID.ButtonClick
        Sm_Buscar(True)
    End Sub

#End Region

#Region "Facturacion SiHay"

    Private Function GetDataTableFormatNegadosSH(ByVal codigo As String, ByVal talla As String, ByVal cantidad As Integer) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        'dtArticulos.Columns.Add("Talla", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        Dim row As DataRow = dtArticulos.NewRow()
        row("Codigo") = codigo
        'row("Talla") = talla
        row("Cantidad") = cantidad
        dtArticulos.Rows.Add(row)
        Return dtArticulos
    End Function

#End Region

#Region "Bloqueo y negados de Artículos de Baja Calidad"
    Private Sub SaveDefectuosos(ByVal dtNegados As DataTable)
        'Creamos Defectuoso
        Dim oDefectuosoMgr As New DefectuososManager(oAppContext, oAppSAPConfig)
        Dim oDefectuoso As Defectuoso

        'Creamos Articulo
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()

        'Creamos Vendedor
        Dim oVendedoresMgr As New CatalogoVendedoresManager(oAppContext)
        Dim oVendedor As Vendedor = oVendedoresMgr.Create
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim err As String = ""
        Dim defectuosoID As Integer

        Dim codigo As String = ""

        For Each row As DataRow In dtNegados.Rows
            oArticulo.ClearFields()
            codigo = CStr(row("Material"))
            oArticuloMgr.LoadInto(codigo, oArticulo)
            oDefectuoso = oDefectuosoMgr.Create()
            oDefectuoso.ClearFields()
            oDefectuoso.CodArticulo = oArticulo.CodArticulo
            oDefectuoso.Numero = "" 'FormatTalla(CStr(row("Talla")))
            oDefectuoso.CostoUnit = oArticulo.PrecioVenta
            oDefectuoso.Cantidad = CDec(row("Cantidad"))
            oDefectuoso.Usuario = oAppContext.Security.CurrentUser.ID
            oDefectuoso.UsuarioMov = oAppContext.Security.CurrentUser.ID
            oDefectuoso.Autorizo = oAppContext.Security.CurrentUser.ID
            oDefectuoso.FacturaID = 0
            oDefectuoso.FolioFactura = 0
            oDefectuoso.FolioSAP = "0"
            oDefectuoso.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            oDefectuoso.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
            oDefectuoso.Fecha = process.MSS_GET_SY_DATE_TIME()
            oDefectuoso.BloqueadoEcommerce = True
            '------------------------------------------------------------------
            ' JNAVA (13.02.2016): Se agrego si se marcara o no por retail
            '------------------------------------------------------------------
            oDefectuoso.Marcar = rbMarcar.Checked
            If rbMarcar.Checked Then
                oDefectuoso.DefectoNota = CStr(row("MarcadoID"))
            Else
                oDefectuoso.DefectoNota = CStr(row("DesmarcadoID"))
            End If
            'Select Case Modulo.Trim.ToUpper
            '    Case "PP"
            '        oDefectuoso.BloqueadoEcommerce = True
            '        oDefectuoso.BloqueadoSiHay = False
            '    Case "PPSH"
            '        oDefectuoso.BloqueadoSiHay = True
            '        oDefectuoso.BloqueadoEcommerce = False
            'End Select
            defectuosoID = oDefectuosoMgr.Save(oDefectuoso)
            If defectuosoID = 0 Then
                err &= "El código " & codigo & vbCrLf '& " con talla " & CStr(row("Talla")) & vbCrLf
            Else
                With oDefectuoso.Movimiento

                    .CodTipoMov = 0
                    .TipoMovimiento = ""
                    .StatusMov = "A"
                    .CodAlmacenMov = oDefectuoso.CodAlmacen
                    .Destino = oDefectuoso.CodAlmacen
                    .Folio = defectuosoID
                    .CodArticuloMov = oArticulo.CodArticulo
                    .Descripcion = oArticulo.Descripcion
                    .NumeroMov = 0
                    .Total = 0
                    .Apartados = 0
                    .Defectuosos = 0
                    .Promocion = 0
                    .VtasEspeciales = 0
                    .Consignacion = 0
                    .Transito = 0
                    .CodLinea = oArticulo.Codlinea
                    .CodMarca = oArticulo.CodMarca
                    .CodFamilia = oArticulo.CodFamilia
                    .CodUnidad = oArticulo.CodUnidadVta
                    .CodUso = IIf(IsNumeric(oArticulo.CodUso), oArticulo.CodUso, 0)
                    .CodCategoria = oArticulo.CodCategoria
                    .UsuarioMov = oDefectuoso.Usuario
                    .CostoUnit = oArticulo.PrecioVenta
                    .PrecioUnit = oArticulo.PrecioVenta
                    .FolioControl = ""
                    .CodCajaMov = oDefectuoso.CodCaja
                End With

                oDefectuosoMgr.SaveMoveInOut(0, "O", oDefectuoso.Numero, oDefectuoso)
            End If

        Next
        If err.Trim() <> "" Then
            MessageBox.Show(err, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/06/2015: Desmarcar Artículos defectuosos de Baja Calidad en SAP
    '--------------------------------------------------------------------------------------------------------------------------

    Private Sub DesmarcarDefectuosos(ByVal dtDetalle As DataTable)
        Dim dsDefectuosos As New DataSet
        Dim cantidad As Integer

        'Creamos Defectuoso
        Dim oDefectuosoMgr As New DefectuososManager(oAppContext, oAppSAPConfig)
        Dim oDefectuoso As Defectuoso

        'Creamos Artículo
        Dim oArticuloMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArticulo As Articulo = oArticuloMgr.Create()
        Dim codigo As String
        Dim dtDefecD As DataTable = CreateDefectuososD()
        Dim fila As DataRow = Nothing
        Dim cant As Decimal = 0
        For Each row As DataRow In dtDetalle.Rows
            oArticulo.ClearFields()
            codigo = CStr(row("Material"))
            oArticuloMgr.LoadInto(codigo, oArticulo)
            fila = dtDefecD.NewRow()
            fila("CodArticulo") = CStr(row("Material"))
            'fila("Numero") = CStr(row("Talla"))
            cant += CDec(row("Cantidad"))
            fila("Defectuosos") = CDec(row("Cantidad"))
            fila("Desmarcar") = CDec(row("Cantidad"))
            fila("PrecioUni") = oArticulo.PrecioVenta
            fila("Total") = CDec(row("Cantidad")) * oArticulo.PrecioVenta
            dtDefecD.Rows.Add(fila)
        Next
        dsDefectuosos.Tables.Add(dtDefecD)
        oDefectuosoMgr.DesmarcarDefectuosos(dsDefectuosos, cant, oAppContext.Security.CurrentUser.ID, True, "0004", , True)
    End Sub

    Private Function CreateDefectuososD() As DataTable
        Dim dtDefectuososD As New DataTable("DefectuososD")
        dtDefectuososD.Columns.Add("CodArticulo", GetType(String))
        dtDefectuososD.Columns.Add("Numero", GetType(String))
        dtDefectuososD.Columns.Add("Defectuosos", GetType(Integer))
        dtDefectuososD.Columns.Add("Desmarcar", GetType(Integer))
        dtDefectuososD.Columns.Add("PrecioUni", GetType(Decimal))
        dtDefectuososD.Columns.Add("Total", GetType(Decimal))
        Return dtDefectuososD
    End Function

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2015: Da el formato de talla a los articulos quitandole el 0 extra que le agrega
    '---------------------------------------------------------------------------------------------------------------------------
    Friend Function FormatTalla(ByVal strNumber As String) As String
        If IsNumeric(strNumber) Then
            If InStr(strNumber, ".5", CompareMethod.Text) = 0 Then
                strNumber = strNumber.Replace(".0", "")
            End If
        End If
        Return strNumber
    End Function

#End Region

End Class
