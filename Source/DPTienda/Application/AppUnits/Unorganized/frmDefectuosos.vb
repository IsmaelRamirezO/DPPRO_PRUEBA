
Imports DportenisPro.DPTienda.ApplicationUnits.Defectuosos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.IO

Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmDefectuosos
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nebDefectuosoID As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents uiGuardar As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
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
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator13 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents CommandManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nebCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nebFolioFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbCodCaja As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebCodArticulo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents UiStatusBar1 As Janus.Windows.UI.StatusBar.UIStatusBar
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ebSucursal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ebPlayerID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPlayerName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents NicePanel2 As PureComponents.NicePanel.NicePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ebCodSAP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDefectoNota As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDefectuosos))
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage()
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage()
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle()
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle()
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle()
        Dim UiStatusBarPanel1 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Dim UiStatusBarPanel2 As Janus.Windows.UI.StatusBar.UIStatusBarPanel = New Janus.Windows.UI.StatusBar.UIStatusBarPanel()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebObservaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCodSAP = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebDefectoNota = New Janus.Windows.EditControls.UIComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.NicePanel2 = New PureComponents.NicePanel.NicePanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.ebResponsableName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebPlayerID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ebSucursal = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ebCodArticulo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nebCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cbCodCaja = New Janus.Windows.EditControls.UIComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nebDefectuosoID = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nebFolioFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebFechaDefectuoso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.uiGuardar = New Janus.Windows.EditControls.UIButton()
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
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator13 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
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
        Me.UiStatusBar1 = New Janus.Windows.UI.StatusBar.UIStatusBar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.NicePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebObservaciones)
        Me.ExplorerBar1.Controls.Add(Me.ebCodSAP)
        Me.ExplorerBar1.Controls.Add(Me.ebDefectoNota)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.btnCancelar)
        Me.ExplorerBar1.Controls.Add(Me.NicePanel2)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableName)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableID)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerName)
        Me.ExplorerBar1.Controls.Add(Me.ebPlayerID)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursal)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label13)
        Me.ExplorerBar1.Controls.Add(Me.ebCodArticulo)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.nebCantidad)
        Me.ExplorerBar1.Controls.Add(Me.cbCodCaja)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.nebDefectuosoID)
        Me.ExplorerBar1.Controls.Add(Me.nebFolioFactura)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaDefectuoso)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.uiGuardar)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos del Artículo Defectuoso"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(673, 409)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Observaciones:"
        '
        'ebObservaciones
        '
        Me.ebObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ebObservaciones.Location = New System.Drawing.Point(145, 242)
        Me.ebObservaciones.MaxLength = 200
        Me.ebObservaciones.Multiline = True
        Me.ebObservaciones.Name = "ebObservaciones"
        Me.ebObservaciones.Size = New System.Drawing.Size(221, 43)
        Me.ebObservaciones.TabIndex = 36
        Me.ebObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodSAP
        '
        Me.ebCodSAP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodSAP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodSAP.ButtonImage = CType(resources.GetObject("ebCodSAP.ButtonImage"), System.Drawing.Image)
        Me.ebCodSAP.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebCodSAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodSAP.Location = New System.Drawing.Point(145, 143)
        Me.ebCodSAP.Name = "ebCodSAP"
        Me.ebCodSAP.Size = New System.Drawing.Size(166, 23)
        Me.ebCodSAP.TabIndex = 34
        Me.ebCodSAP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodSAP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDefectoNota
        '
        Me.ebDefectoNota.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebDefectoNota.Location = New System.Drawing.Point(145, 217)
        Me.ebDefectoNota.Name = "ebDefectoNota"
        Me.ebDefectoNota.Size = New System.Drawing.Size(221, 23)
        Me.ebDefectoNota.TabIndex = 19
        Me.ebDefectoNota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 23)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Referencia:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(526, 297)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(123, 31)
        Me.btnCancelar.TabIndex = 25
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
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
        Me.NicePanel2.FooterText = "Grupo DPortenis @ 2016 "
        Me.NicePanel2.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Camera
        HeaderImage2.Image = Nothing
        Me.NicePanel2.HeaderImage = HeaderImage2
        Me.NicePanel2.HeaderText = "Imagen del Articulo"
        Me.NicePanel2.IsExpanded = True
        Me.NicePanel2.Location = New System.Drawing.Point(391, 69)
        Me.NicePanel2.Name = "NicePanel2"
        Me.NicePanel2.OriginalFooterVisible = True
        Me.NicePanel2.OriginalHeight = 0
        Me.NicePanel2.Size = New System.Drawing.Size(259, 216)
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
        Me.Panel1.Size = New System.Drawing.Size(257, 174)
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
        Me.pbImagen.Size = New System.Drawing.Size(257, 174)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 1
        Me.pbImagen.TabStop = False
        '
        'ebResponsableName
        '
        Me.ebResponsableName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableName.Enabled = False
        Me.ebResponsableName.Location = New System.Drawing.Point(145, 360)
        Me.ebResponsableName.Name = "ebResponsableName"
        Me.ebResponsableName.Size = New System.Drawing.Size(223, 23)
        Me.ebResponsableName.TabIndex = 23
        Me.ebResponsableName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableID
        '
        Me.ebResponsableID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.ButtonImage = CType(resources.GetObject("ebResponsableID.ButtonImage"), System.Drawing.Image)
        Me.ebResponsableID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebResponsableID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebResponsableID.Location = New System.Drawing.Point(145, 336)
        Me.ebResponsableID.MaxLength = 8
        Me.ebResponsableID.Name = "ebResponsableID"
        Me.ebResponsableID.Size = New System.Drawing.Size(167, 23)
        Me.ebResponsableID.TabIndex = 22
        Me.ebResponsableID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebPlayerName
        '
        Me.ebPlayerName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebPlayerName.BackColor = System.Drawing.Color.Ivory
        Me.ebPlayerName.Enabled = False
        Me.ebPlayerName.Location = New System.Drawing.Point(145, 312)
        Me.ebPlayerName.Name = "ebPlayerName"
        Me.ebPlayerName.Size = New System.Drawing.Size(222, 23)
        Me.ebPlayerName.TabIndex = 21
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
        Me.ebPlayerID.Location = New System.Drawing.Point(145, 287)
        Me.ebPlayerID.MaxLength = 8
        Me.ebPlayerID.Name = "ebPlayerID"
        Me.ebPlayerID.Size = New System.Drawing.Size(168, 23)
        Me.ebPlayerID.TabIndex = 20
        Me.ebPlayerID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPlayerID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 24)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Player:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 24)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Sucursal:"
        '
        'ebSucursal
        '
        Me.ebSucursal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursal.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursal.Location = New System.Drawing.Point(145, 68)
        Me.ebSucursal.Name = "ebSucursal"
        Me.ebSucursal.Size = New System.Drawing.Size(222, 23)
        Me.ebSucursal.TabIndex = 12
        Me.ebSucursal.TabStop = False
        Me.ebSucursal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(418, 337)
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
        Me.Label13.Location = New System.Drawing.Point(391, 337)
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
        Me.ebCodArticulo.Location = New System.Drawing.Point(145, 168)
        Me.ebCodArticulo.Name = "ebCodArticulo"
        Me.ebCodArticulo.Size = New System.Drawing.Size(166, 23)
        Me.ebCodArticulo.TabIndex = 16
        Me.ebCodArticulo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodArticulo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad:"
        '
        'nebCantidad
        '
        Me.nebCantidad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebCantidad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebCantidad.DecimalDigits = 1
        Me.nebCantidad.Location = New System.Drawing.Point(145, 193)
        Me.nebCantidad.Name = "nebCantidad"
        Me.nebCantidad.ReadOnly = True
        Me.nebCantidad.Size = New System.Drawing.Size(105, 23)
        Me.nebCantidad.TabIndex = 18
        Me.nebCantidad.Text = "0.0"
        Me.nebCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nebCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbCodCaja
        '
        Me.cbCodCaja.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCodCaja.Location = New System.Drawing.Point(145, 93)
        Me.cbCodCaja.Name = "cbCodCaja"
        Me.cbCodCaja.Size = New System.Drawing.Size(104, 23)
        Me.cbCodCaja.TabIndex = 13
        Me.cbCodCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 338)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 24)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Autorizó:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(34, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Motivo:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 23)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Caja:"
        '
        'nebDefectuosoID
        '
        Me.nebDefectuosoID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebDefectuosoID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebDefectuosoID.BackColor = System.Drawing.Color.Ivory
        Me.nebDefectuosoID.ButtonImage = CType(resources.GetObject("nebDefectuosoID.ButtonImage"), System.Drawing.Image)
        Me.nebDefectuosoID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nebDefectuosoID.DecimalDigits = 0
        Me.nebDefectuosoID.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebDefectuosoID.Location = New System.Drawing.Point(145, 43)
        Me.nebDefectuosoID.MaxLength = 9
        Me.nebDefectuosoID.Name = "nebDefectuosoID"
        Me.nebDefectuosoID.Size = New System.Drawing.Size(222, 23)
        Me.nebDefectuosoID.TabIndex = 11
        Me.nebDefectuosoID.Text = "0"
        Me.nebDefectuosoID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebDefectuosoID.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebDefectuosoID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nebFolioFactura
        '
        Me.nebFolioFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebFolioFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebFolioFactura.ButtonImage = CType(resources.GetObject("nebFolioFactura.ButtonImage"), System.Drawing.Image)
        Me.nebFolioFactura.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nebFolioFactura.DecimalDigits = 0
        Me.nebFolioFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.nebFolioFactura.Location = New System.Drawing.Point(145, 118)
        Me.nebFolioFactura.MaxLength = 9
        Me.nebFolioFactura.Name = "nebFolioFactura"
        Me.nebFolioFactura.Size = New System.Drawing.Size(166, 23)
        Me.nebFolioFactura.TabIndex = 14
        Me.nebFolioFactura.Text = "0"
        Me.nebFolioFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nebFolioFactura.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebFolioFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebFechaDefectuoso
        '
        Me.ebFechaDefectuoso.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ebFechaDefectuoso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFechaDefectuoso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaDefectuoso.Location = New System.Drawing.Point(551, 36)
        Me.ebFechaDefectuoso.Name = "ebFechaDefectuoso"
        Me.ebFechaDefectuoso.ReadOnly = True
        Me.ebFechaDefectuoso.ShowDropDown = False
        Me.ebFechaDefectuoso.Size = New System.Drawing.Size(99, 23)
        Me.ebFechaDefectuoso.TabIndex = 32
        Me.ebFechaDefectuoso.TabStop = False
        Me.ebFechaDefectuoso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Factura PRO:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Defectuoso ID:"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(548, 337)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(114, 23)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "Graba/Imprimir"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(525, 337)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "F9"
        '
        'uiGuardar
        '
        Me.uiGuardar.Image = CType(resources.GetObject("uiGuardar.Image"), System.Drawing.Image)
        Me.uiGuardar.Location = New System.Drawing.Point(390, 296)
        Me.uiGuardar.Name = "uiGuardar"
        Me.uiGuardar.Size = New System.Drawing.Size(123, 32)
        Me.uiGuardar.TabIndex = 24
        Me.uiGuardar.Text = "Guardar"
        Me.uiGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(495, 39)
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
        Me.CommandManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
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
        Me.CommandManager.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.CommandManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.Size = New System.Drawing.Size(0, 0)
        '
        'UiCommandBar1
        '
        Me.UiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.CommandManager
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(673, 22)
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
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.CommandManager
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.menuAbrir2, Me.Separator9, Me.menuArchivoGuardar2, Me.Separator10, Me.menuImprimir2, Me.Separator13, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(346, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Image = CType(resources.GetObject("menuArchivoGuardar2.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'menuImprimir2
        '
        Me.menuImprimir2.Key = "menuImprimir"
        Me.menuImprimir2.Name = "menuImprimir2"
        '
        'Separator13
        '
        Me.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator13.Key = "Separator"
        Me.Separator13.Name = "Separator13"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        Me.menuAyudaTema2.Text = "Ay&uda"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.menuAbrir1, Me.Separator7, Me.menuArchivoGuardar1, Me.Separator8, Me.menuImprimir1, Me.Separator11, Me.menuCerrar4})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
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
        Me.menuAyuda.Text = "&Ayuda"
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
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Image = CType(resources.GetObject("menuAyudaTema.Image"), System.Drawing.Image)
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "&Temas de Ayuda"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "&Salir"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.TopRebar1.CommandManager = Me.CommandManager
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(673, 50)
        '
        'UiStatusBar1
        '
        Me.UiStatusBar1.Location = New System.Drawing.Point(0, 436)
        Me.UiStatusBar1.Name = "UiStatusBar1"
        UiStatusBarPanel1.BorderColor = System.Drawing.Color.Transparent
        UiStatusBarPanel1.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        UiStatusBarPanel1.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel1.Key = ""
        UiStatusBarPanel1.ProgressBarValue = 0
        UiStatusBarPanel1.Text = "Nota:"
        UiStatusBarPanel1.Width = 40
        UiStatusBarPanel2.BorderColor = System.Drawing.Color.Transparent
        UiStatusBarPanel2.FormatStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        UiStatusBarPanel2.FormatStyle.FontBold = Janus.Windows.UI.TriState.[True]
        UiStatusBarPanel2.FormatStyle.ForeColor = System.Drawing.Color.Red
        UiStatusBarPanel2.Key = ""
        UiStatusBarPanel2.ProgressBarValue = 0
        UiStatusBarPanel2.Text = "Todos los artículos deberán ser enviados en su caja original."
        UiStatusBarPanel2.Width = 400
        Me.UiStatusBar1.Panels.AddRange(New Janus.Windows.UI.StatusBar.UIStatusBarPanel() {UiStatusBarPanel1, UiStatusBarPanel2})
        Me.UiStatusBar1.PanelsBorderColor = System.Drawing.SystemColors.ControlDark
        Me.UiStatusBar1.Size = New System.Drawing.Size(673, 23)
        Me.UiStatusBar1.TabIndex = 4
        Me.UiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmDefectuosos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(673, 459)
        Me.Controls.Add(Me.UiStatusBar1)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(679, 487)
        Me.MinimumSize = New System.Drawing.Size(679, 487)
        Me.Name = "frmDefectuosos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcar Artículos Defectuosos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.NicePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).EndInit()
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


#Region "Environment Var"

    'Objeto Defectuoso
    Dim oDefectuosoMgr As DefectuososManager
    Dim oDefectuoso As Defectuoso

    'Objeto Artículo
    Dim oArticuloMgr As CatalogoArticuloManager
    Dim oArticulo As Articulo

    'Objeto player
    Dim oVendedoresMgr As CatalogoVendedoresManager
    Dim oVendedor As Vendedor

    Dim dtDetalleFactura As DataTable
    'Dim dtTallas As DataTable = New DataTable("Tallas")

    Dim vCorrida As String, vExistencia As Decimal
    Dim vFacturaID As Integer

    Dim bolImprimir As Boolean
    Dim bolPlayer As Boolean

    Dim dsDataColumn As New Data.DataSet

    Dim oSAPMgr As ProcesoSAPManager

#End Region


#Region "Initialize"

    Private Sub InitializeObjects()

        'Creamos Defectuoso
        oDefectuosoMgr = New DefectuososManager(oAppContext, oAppSAPConfig)
        oDefectuoso = oDefectuosoMgr.Create

        'Creamos Articulo
        oArticuloMgr = New CatalogoArticuloManager(oAppContext)
        oArticulo = oArticuloMgr.Create

        'Creamos Vendedor
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oVendedor = oVendedoresMgr.Create

        'Objeto SAP
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    End Sub

    Private Sub InitializeBinding()

        nebDefectuosoID.DataBindings.Add(New Binding("Value", oDefectuoso, "FolioMovimiento"))
        cbCodCaja.DataBindings.Add(New Binding("Text", oDefectuoso, "CodCaja"))
        nebFolioFactura.DataBindings.Add(New Binding("Value", oDefectuoso, "FolioFactura"))
        ebCodArticulo.DataBindings.Add(New Binding("Text", oDefectuoso, "CodArticulo"))
        'nebTalla.DataBindings.Add(New Binding("Text", oDefectuoso, "Numero"))
        nebCantidad.DataBindings.Add(New Binding("Value", oDefectuoso, "Cantidad"))
        ebDefectoNota.DataBindings.Add(New Binding("Text", oDefectuoso, "DefectoNota"))
        ebFechaDefectuoso.DataBindings.Add(New Binding("Value", oDefectuoso, "Fecha"))
        Me.ebPlayerID.DataBindings.Add(New Binding("Text", oDefectuoso, "UsuarioMov"))
        Me.ebResponsableID.DataBindings.Add(New Binding("Text", oDefectuoso, "Autorizo"))
        Me.ebCodSAP.DataBindings.Add(New Binding("Text", oDefectuoso, "FolioSAP"))
    End Sub

#End Region


#Region "Methods"

    Private Sub GetCajaToCombo()

        'Objeto Caja
        Dim oCajaMgr As CatalogoCajaManager
        Dim oCaja As Caja

        'Creamos Caja
        oCajaMgr = New CatalogoCajaManager(oAppContext)
        oCaja = oCajaMgr.Create

        Dim dsCaja As New DataSet
        Dim nReg As Integer, i As Integer

        dsCaja = oCajaMgr.GetAll(False)

        nReg = dsCaja.Tables(0).Rows.Count

        If nReg > 0 Then

            For i = 0 To nReg - 1

                cbCodCaja.Items.Add(dsCaja.Tables(0).Rows(i).Item("CodCaja"))

            Next i

            dsCaja = Nothing

        End If

        oCaja = Nothing
        oCajaMgr = Nothing

    End Sub

    'Private Sub GetTallas(ByVal IDCorrida As String)

    '    Dim iCtalla As Integer
    '    Dim Dcol As DataColumn = New DataColumn
    '    Dim Drow As DataRow

    '    dtTallas = Nothing

    '    dtTallas = New DataTable

    '    Dcol = New DataColumn
    '    Dcol.AllowDBNull = True
    '    Dcol.ColumnName = "Talla"
    '    Dcol.Caption = "Talla"
    '    Dcol.DataType = System.Type.GetType("System.String")
    '    dtTallas.Columns.Add(Dcol)

    '    Dim dsTallas As DataSet = New DataSet
    '    Dim idx As Integer, iField As String

    '    dsTallas = oDefectuosoMgr.GetTallas(IDCorrida)

    '    If dsTallas.Tables(0).Rows.Count > 0 Then

    '        For idx = 1 To 20

    '            iField = "C" + Format(idx, "00")

    '            If idx = 1 Then

    '                Drow = dtTallas.NewRow
    '                Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
    '                dtTallas.Rows.Add(Drow)


    '                '    If dsTallas.Tables(0).Rows(0).Item(iField) <> oDefectuoso.Numero Then
    '                '        Drow = dtTallas.NewRow
    '                '        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
    '                '        dtTallas.Rows.Add(Drow)
    '                '    End If

    '            Else

    '                If (dsTallas.Tables(0).Rows(0).Item(iField) <> String.Empty) Then
    '                    Drow = dtTallas.NewRow
    '                    Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
    '                    dtTallas.Rows.Add(Drow)
    '                End If

    '                '    If (dsTallas.Tables(0).Rows(0).Item(iField) > 0) And (dsTallas.Tables(0).Rows(0).Item(iField) <> oDefectuoso.Numero) Then
    '                '        Drow = dtTallas.NewRow
    '                '        Drow("Talla") = dsTallas.Tables(0).Rows(0).Item(iField)
    '                '        dtTallas.Rows.Add(Drow)
    '                '    End If

    '            End If

    '        Next

    '    Else

    '        MsgBox("La corrida del artículo no esta registrada.", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, " Defectuosos")

    '        Me.Close()

    '    End If


    '    dsTallas = Nothing

    'End Sub

    Private Function ValidaArticulo() As Boolean

        For Each oRow As DataRow In Me.dsDataColumn.Tables(0).Rows

            If oRow("CodArticulo") = oDefectuoso.CodArticulo Then

                vExistencia = oRow("Cantidad")

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub ClearScreen()

        oDefectuoso.ID = 0
        oDefectuoso.FolioMovimiento = 0
        oDefectuoso.FacturaID = 0
        oDefectuoso.FolioFactura = 0
        oDefectuoso.FolioSAP = 0
        oDefectuoso.CodArticulo = String.Empty
        oDefectuoso.Numero = 0
        oDefectuoso.DefectoNota = String.Empty


        oDefectuoso.ClearFields()
        oDefectuoso.ClearFieldsMovimiento()


        oDefectuoso.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        oDefectuoso.CodCaja = oAppContext.ApplicationConfiguration.NoCaja
        oDefectuoso.Cantidad = 1
        oDefectuoso.Fecha = Date.Today

        Me.cbCodCaja.ReadOnly = False
        Me.nebFolioFactura.ReadOnly = False
        Me.ebCodSAP.ReadOnly = False
        Me.ebCodArticulo.ReadOnly = False
        '.ReadOnly = False
        Me.nebCantidad.ReadOnly = False
        Me.ebDefectoNota.ReadOnly = False
        Me.ebResponsableID.ReadOnly = False

        Me.cbCodCaja.BackColor = System.Drawing.SystemColors.Window
        Me.nebFolioFactura.BackColor = System.Drawing.SystemColors.Window
        Me.ebCodSAP.BackColor = System.Drawing.SystemColors.Window
        Me.ebCodArticulo.BackColor = System.Drawing.SystemColors.Window
        ' Me.nebTalla.BackColor = System.Drawing.SystemColors.Window
        Me.nebCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.ebDefectoNota.BackColor = System.Drawing.SystemColors.Window
        Me.ebPlayerID.BackColor = System.Drawing.SystemColors.Window
        Me.ebResponsableID.BackColor = System.Drawing.SystemColors.Window

        Me.nebDefectuosoID.Value = 0
        Me.ebPlayerID.Text = String.Empty
        Me.ebPlayerName.Text = String.Empty
        Me.ebResponsableID.Text = String.Empty
        Me.ebResponsableName.Text = String.Empty
        Me.ebObservaciones.Text = String.Empty

        pbImagen.Image = Nothing

        Me.nebDefectuosoID.Value = oDefectuosoMgr.SelectFolio + 1

    End Sub

    Private Function IntegridadDatos() As Boolean

        If oDefectuoso.CodArticulo <> "" Then

            If (oDefectuoso.Numero = String.Empty) Then

                'If (oArticulo.CodCorrida <> "TEX") And (oArticulo.CodCorrida <> "ACC") Then

                '    MsgBox("No se puede guardar. Talla incorrecta.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

                '    nebTalla.Focus()

                '    Return False

                'Else'

                vExistencia = 0

                vExistencia = oDefectuosoMgr.GetStock(oDefectuoso.CodAlmacen, oDefectuoso.CodArticulo, oDefectuoso.Numero)

                If (vExistencia >= oDefectuoso.Cantidad) Then

                    Return True

                Else

                    If (vExistencia < 1) Then

                        MsgBox("Artículo no cuenta con existencia suficiente para realizar el defectuoso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

                        'nebTalla.Focus()
                        Me.ebCodArticulo.Focus()

                    Else

                        MsgBox("Artículo solo cuenta con " & vExistencia.ToString & " PP. en Existencias. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

                        'nebTalla.Focus()
                        Me.ebCodArticulo.Focus()

                    End If

                    Return False

                End If


                'End If

            Else

                Return True

            End If

        Else

            MsgBox("No se puede guardar el defectuoso. Faltan Datos.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

            ebCodArticulo.Focus()

            Return False

        End If

    End Function

    Private Sub FillDataMovimiento(ByVal ID As Integer)

        With oDefectuoso.Movimiento

            .CodTipoMov = 0
            .TipoMovimiento = ""
            .StatusMov = "A"
            .CodAlmacenMov = oDefectuoso.CodAlmacen
            .Destino = oDefectuoso.CodAlmacen
            .Folio = ID
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
            .CodUso = oArticulo.CodUso
            .CodCategoria = oArticulo.CodCategoria
            .UsuarioMov = oDefectuoso.Usuario
            .CostoUnit = oArticulo.PrecioVenta
            .PrecioUnit = oArticulo.PrecioVenta
            .FolioControl = ""
            .CodCajaMov = oDefectuoso.CodCaja

        End With


    End Sub

    Private Sub SaveData()

        'Me.ebDefectoNota.Text = Me.ebDefectoNota.Text.Trim()

        If Me.nebFolioFactura.Value = 0 And Me.ebDefectoNota.Text = "" Then

            MessageBox.Show("Especifique el motivo del marcado. ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebDefectoNota.Focus()

            Exit Sub

        End If

        Me.ebPlayerName.Text = Me.ebPlayerName.Text.Trim

        If Me.ebPlayerName.TextLength = 0 Then

            MessageBox.Show("Especifique el responsable. ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebPlayerID.Focus()

            Exit Sub

        End If


        Me.ebResponsableName.Text = Me.ebResponsableName.Text.Trim

        If Me.ebResponsableName.TextLength = 0 Then

            MessageBox.Show("Especifique el manager. ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebResponsableID.Focus()

            Exit Sub

        End If

        Dim vDefectuosoID As Integer

        If IntegridadDatos() = False Then
            Exit Sub
        End If


        ' MLVARGAS (17.08.2022): Verificar si el material no se encuentra marcado como baja calidad

        Dim dtDefecSAP As DataTable
        Dim dtDefecEC As DataTable
        Dim dtMateriales As DataTable = GetDataTableFormatNegadosSH(Me.ebCodArticulo.Text, nebCantidad.Text)
        Dim UserNameDesmarca As String = oAppContext.ApplicationConfiguration.Usuario
        Dim oFacturaMgr As FacturaManager
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        If ValidarMaterialesBajaCalidad(dtMateriales, dtDefecEC, "", dtDefecSAP) = False Then
            Exit Sub
        End If

        '-----------------------------------------------------------------------------------------------------------------------
        'Se desmarcan los codigos marcados como defectuosos para Ecommerce que van en el apartado
        '-----------------------------------------------------------------------------------------------------------------------
        If Not dtDefecEC Is Nothing AndAlso dtDefecEC.Rows.Count > 0 Then
            If oSAPMgr.ZPOL_DEFECTUOSOS_INS(String.Empty, "DD", UserNameDesmarca, dtDefecEC).Trim = "Y" Then
                'Se desmarcan los códigos de baja calidad en la base de datos local
                oFacturaMgr.DesmarcaBajaCalidad(dtDefecEC)
            Else
                Exit Sub
            End If
        End If



        'Guardamos 
        'oDefectuoso.FacturaID = vFacturaID
        oDefectuoso.Usuario = oDefectuoso.UsuarioMov
        oDefectuoso.CostoUnit = oArticulo.PrecioVenta
        oDefectuoso.Observaciones = ebObservaciones.Text

        Try
            vDefectuosoID = oDefectuosoMgr.Save(oDefectuoso)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, " Defectuosos")
        End Try

        If vDefectuosoID = 0 Then

            MsgBox("El defectuoso no se guardó.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, " Defectuosos")

        Else

            'Complemento el objeto de Defectuoso con los valores necesario para efectuar la operación de marcado
            FillDataMovimiento(vDefectuosoID)

            'Guardamos de Existencia en el inventario
            oDefectuosoMgr.SaveMoveInOut(0, "O", oDefectuoso.Numero, oDefectuoso)

            MsgBox("Defectuoso guardado satisfactoriamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

            If bolImprimir Then
                PrintComprobanteComparativo()
            End If


            'Limpiamos la pantalla para una nueva captura

            ClearScreen()

            cbCodCaja.Focus()

        End If

    End Sub

    Public Sub PrintComprobanteComparativo()



        Dim oARReporte As New rptPapeletaArticulosDefectuosos(oDefectuoso)
        'Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Analisis Comparativo"

        oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

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


    Private Sub LoadSearchFormDefectuso()

        Dim oOpenRecordDlg As New OpenRecordDialog
        oOpenRecordDlg.CurrentView = New DefectuososOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oDefectuosoMgr.LoadInto(oOpenRecordDlg.Record.Item("FolioMovimiento"), oDefectuoso)

            If (Not oDefectuoso Is Nothing) Then
                Me.nebDefectuosoID.Value = oDefectuoso.FolioMovimiento
                oArticulo = oArticuloMgr.Load(oDefectuoso.CodArticulo)

                ' Poner imagen

                'If oArticulo.WithImage = True Then
                '    pbImagen.Image = Image.FromStream(oArticulo.Imagen)
                'Else
                '    pbImagen.Image = Nothing
                'End If


                Me.cbCodCaja.ReadOnly = True
                Me.nebFolioFactura.ReadOnly = True
                Me.ebCodSAP.ReadOnly = True
                Me.ebCodArticulo.ReadOnly = True
                'Me.nebTalla.ReadOnly = True
                Me.nebCantidad.ReadOnly = True
                Me.ebDefectoNota.ReadOnly = True
                Me.ebResponsableID.ReadOnly = True
                Me.ebPlayerID.ReadOnly = True

                Me.cbCodCaja.BackColor = System.Drawing.Color.Ivory
                Me.nebFolioFactura.BackColor = System.Drawing.Color.Ivory
                Me.ebCodSAP.BackColor = System.Drawing.Color.Ivory
                Me.ebCodArticulo.BackColor = System.Drawing.Color.Ivory
                'Me.nebTalla.BackColor = System.Drawing.Color.Ivory
                Me.nebCantidad.BackColor = System.Drawing.Color.Ivory
                Me.ebDefectoNota.BackColor = System.Drawing.Color.Ivory
                Me.ebPlayerID.BackColor = System.Drawing.Color.Ivory
                Me.ebResponsableID.BackColor = System.Drawing.Color.Ivory

                oVendedor = oVendedoresMgr.Load(oDefectuoso.UsuarioMov)

                If Not oVendedor Is Nothing Then
                    Me.ebPlayerName.Text = oVendedor.Nombre
                End If

                oVendedor = oVendedoresMgr.Load(oDefectuoso.Autorizo)

                If Not oVendedor Is Nothing Then
                    Me.ebResponsableName.Text = oVendedor.Nombre
                End If


            Else
                MsgBox("El Folio de la factura no existe.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Defectuosos")

                'Limpio la pantalla
                ClearScreen()

                nebDefectuosoID.Focus()

            End If

        End If

    End Sub

    Private Sub LoadSearchFormFactura()
        Dim dsTemFactura As DataSet
        Dim oOpenRecordDlg As New OpenRecordDialog

        oOpenRecordDlg.CurrentView = New FacturaOpenRecordDialogView

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            dsTemFactura = oDefectuosoMgr.LoadFacturaByID(oOpenRecordDlg.Record.Item("ID"))

            If Not (dsTemFactura Is Nothing) Then

                oDefectuoso.FacturaID = oOpenRecordDlg.Record.Item("ID")

                oDefectuoso.FolioFactura = dsTemFactura.Tables(0).Rows(0).Item("FolioFactura")

                If dsTemFactura.Tables(0).Rows(0).Item("FolioSap") <> "" Then
                    oDefectuoso.FolioSAP = dsTemFactura.Tables(0).Rows(0).Item("Referencia")
                End If

            Else

                ClearScreen()

                MsgBox("La Factura seleccionada no existe.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Defectuosos")

                cbCodCaja.Focus()

            End If

        End If

    End Sub

    Private Sub LoadSearchFormArticulos()

        If Me.nebFolioFactura.Value <> 0 Then
            Dim oOpenRecordDlgFC As New OpenRecordDialog

            oOpenRecordDlgFC.CurrentView = New FacturaCorridaOpenRecordDialogView(nebFolioFactura.Value, Me.cbCodCaja.Text)

            oOpenRecordDlgFC.ShowDialog()

            If (oOpenRecordDlgFC.DialogResult = DialogResult.OK) Then

                oDefectuoso.CodArticulo = oOpenRecordDlgFC.Record.Item("CodArticulo")
                oDefectuoso.Numero = oOpenRecordDlgFC.Record.Item("Numero")


                'If File.Exists(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG") Then
                '    pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG")
                'Else
                '    pbImagen.Image = Nothing
                'End If

            End If

        Else

            Dim oOpenRecordDlg As New OpenRecordDialog2

            oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                oDefectuoso.CodArticulo = oOpenRecordDlg.Record.Item("Código")


                'If File.Exists(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG") Then
                '    pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG")
                'Else
                '    pbImagen.Image = Nothing
                'End If
            End If
        End If

    End Sub

    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (Me.ebPlayerID.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oVendedor = Nothing
                oVendedor = oVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                If bolPlayer = True Then
                    Me.ebPlayerID.Text = oVendedor.ID
                    Me.ebPlayerName.Text = oVendedor.Nombre

                    Me.oDefectuoso.UsuarioMov = Me.ebPlayerID.Text
                Else
                    Me.ebResponsableID.Text = oVendedor.ID
                    Me.ebResponsableName.Text = oVendedor.Nombre

                    Me.oDefectuoso.Autorizo = Me.ebResponsableID.Text
                End If


            End If

        Else

            On Error Resume Next

            oVendedor = Nothing

            If bolPlayer = True Then

                oVendedor = oVendedoresMgr.Load(Me.ebPlayerID.Text.Trim)

            Else

                oVendedor = oVendedoresMgr.Load(Me.ebResponsableID.Text.Trim)

            End If


            If oVendedor.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                If bolPlayer = True Then
                    Me.ebPlayerID.Text = oVendedor.ID
                    Me.ebPlayerName.Text = oVendedor.Nombre

                    Me.oDefectuoso.UsuarioMov = Me.ebPlayerID.Text
                Else
                    Me.ebResponsableID.Text = oVendedor.ID
                    Me.ebResponsableName.Text = oVendedor.Nombre

                    Me.oDefectuoso.Autorizo = Me.ebResponsableID.Text
                End If


            End If
        End If

    End Sub

#End Region


#Region "Menus And Bars Options"

    Private Sub CommandManager_CommandClick(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles CommandManager.CommandClick
        Select Case e.Command.Key

            Case "menuArchivoSalir"

                Me.Close()

            Case "menuArchivoNuevo"

                ClearScreen()

                cbCodCaja.Focus()

            Case "menuArchivoGuardar"

                bolImprimir = True
                SaveData()


            Case "menuAbrir"

                Me.LoadSearchFormDefectuso()

            Case "menuImprimir"

                PrintComprobanteComparativo()

            Case "menuAyudaTema"

                'TODO : Implementar Aqui la Ayuda

            Case Else

        End Select
    End Sub

#End Region


#Region "Events Form"

    Private Sub frmDefectuosos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

        InitializeBinding()

        GetCajaToCombo()

        GetMotivosDefectuosos()

        ClearScreen()

        Dim oCatalogoAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oCatalogoAlmacen As Almacen

        Dim CentroSAP As String = oSAPMgr.Read_Centros
        oCatalogoAlmacen = oCatalogoAlmacenesMgr.Load(CentroSAP) 'oDefectuoso.CodAlmacen)

        Me.ebSucursal.Text = oCatalogoAlmacen.ID & " " & oCatalogoAlmacen.Descripcion

        'cbCodCaja.Focus()

        ClearScreen()

        cbCodCaja.Focus()

        NicePanel2.FooterText = "Grupo Dportenis @  " & CStr(Date.Now.Year) '2005

    End Sub

    Private Sub nebDefectuosoID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nebDefectuosoID.ButtonClick
        Me.LoadSearchFormDefectuso()
    End Sub

    Private Sub nebDefectuosoID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebDefectuosoID.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then

            Me.LoadSearchFormDefectuso()

        ElseIf e.KeyCode = Keys.Enter Then

            If nebDefectuosoID.Value > 0 Then
                oDefectuosoMgr.LoadInto(nebDefectuosoID.Value, oDefectuoso)

                If (Not oDefectuoso Is Nothing) Then
                    oArticulo = oArticuloMgr.Load(oDefectuoso.CodArticulo)
                    Me.nebDefectuosoID.Value = oDefectuoso.FolioMovimiento

                    If oArticulo.WithImage = True Then
                        pbImagen.Image = Image.FromStream(oArticulo.Imagen)
                    Else
                        pbImagen.Image = Nothing
                    End If

                    Me.cbCodCaja.ReadOnly = True
                    Me.nebFolioFactura.ReadOnly = True
                    Me.ebCodSAP.ReadOnly = True
                    Me.ebCodArticulo.ReadOnly = True
                    'Me.nebTalla.ReadOnly = True
                    Me.nebCantidad.ReadOnly = True
                    Me.ebDefectoNota.ReadOnly = True
                    Me.ebResponsableID.ReadOnly = True

                    Me.cbCodCaja.BackColor = System.Drawing.Color.Ivory
                    Me.nebFolioFactura.BackColor = System.Drawing.Color.Ivory
                    Me.ebCodSAP.BackColor = System.Drawing.Color.Ivory
                    Me.ebCodArticulo.BackColor = System.Drawing.Color.Ivory
                    ' Me.nebTalla.BackColor = System.Drawing.Color.Ivory
                    Me.nebCantidad.BackColor = System.Drawing.Color.Ivory
                    Me.ebDefectoNota.BackColor = System.Drawing.Color.Ivory
                    Me.ebResponsableID.BackColor = System.Drawing.Color.Ivory

                Else
                    MsgBox("El Folio de defectuoso no existe. Verifique por favor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Defectuosos")

                    'Limpio la pantalla
                    ClearScreen()

                    nebDefectuosoID.Focus()

                End If
            End If


        End If
    End Sub


    Private Sub cbCodCaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbCodCaja.Validating
        If cbCodCaja.ReadOnly Then
            Exit Sub
        End If

        If cbCodCaja.Text <> String.Empty Then
            If cbCodCaja.NotInList Then

                MsgBox("Seleccione un número de caja válido.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

                e.Cancel = True

            End If
        End If
    End Sub

    Private Sub nebFolioFactura_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nebFolioFactura.Validating
        If nebFolioFactura.ReadOnly Then
            Exit Sub
        End If



        If (nebFolioFactura.Value <> 0) Then

            dsDataColumn = oDefectuosoMgr.GetDetailFactura(nebFolioFactura.Value, cbCodCaja.Text)

            If (dsDataColumn Is Nothing) Then

                MsgBox("La Factura no corresponde a la Caja " & cbCodCaja.Text & " o no existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

                oDefectuoso.FacturaID = 0
                oDefectuoso.FolioFactura = 0
                oDefectuoso.FolioSAP = "0"
                dsDataColumn = Nothing

                e.Cancel = True
            Else

                oDefectuoso.FacturaID = dsDataColumn.Tables(0).Rows(0).Item("FacturaID")

            End If
        Else

            ClearScreen()

            MsgBox("No registro un numero de Factura PRO, por lo cual es necesario que especifique el origen del defectuoso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

        End If

    End Sub

    Private Sub nebFolioFactura_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nebFolioFactura.ButtonClick
        Me.LoadSearchFormFactura()
    End Sub

    Private Sub nebFolioFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nebFolioFactura.KeyDown
        If (e.KeyData.Alt And e.KeyCode = Keys.S) Then
            Me.LoadSearchFormFactura()
        End If
    End Sub

    Private Sub ebCodArticulo_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodArticulo.ButtonClick

        Me.LoadSearchFormArticulos()

    End Sub


    Private Function GetDataTableFormatNegadosSH(ByVal Codigo As String, ByVal Cantidad As Integer) As DataTable
        Dim dtArticulos As New DataTable
        dtArticulos.Columns.Add("Codigo", GetType(String))
        dtArticulos.Columns.Add("Cantidad", GetType(Integer))
        dtArticulos.Columns.Add("Libres", GetType(Integer))


        Dim FacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim oFactura As Factura = FacturaMgr.Create()
        oFactura.FacturaArticuloExistencia = 0

        FacturaMgr.GetExistenciaArticulo(Codigo, oAppContext.ApplicationConfiguration.Almacen, "", oFactura)
        Dim existencia As Decimal = oFactura.FacturaArticuloExistencia


        Dim row As DataRow = dtArticulos.NewRow()
        row("Codigo") = Codigo
        row("Cantidad") = Cantidad
        row("Libres") = existencia
        dtArticulos.Rows.Add(row)

        Return dtArticulos
    End Function


    Public Function ValidarMaterialesBajaCalidad(ByVal dtSource As DataTable, ByRef dtDefecEC As DataTable, ByRef UserName As String, _
                                                   ByRef dtDefecSAP As DataTable) As Boolean
        Dim bRes As Boolean = True
        '----------------------------------------------------------------------------------------------------------------------------------------

        Dim oRowM As DataRow
        Dim dtDefEC As DataTable
        Dim dtTemp As DataTable
        Dim oFacturaTemp As Factura
        Dim oNewRow As DataRow
        Dim Talla As String = ""
        Dim Max As Integer = 0, Min As Integer = 0, CantFactura As Integer = 0
        Dim Libres As Integer = 0
        Dim Solicitados As Integer = 0

        Dim dvMatDef As DataView
        Dim oRowDEC As DataRowView
        Dim MotivoDesmarcado As String = ""
        Dim dtMotivosDes As DataTable
        Dim DesID As String = ""
        Dim CantXTalla As Integer = 0
        'Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim dtMateriales As DataTable = dtSource.Copy

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)


        '--------------------------------------------------------------------------------------------------------------------
        ' MLVARGAS (20.07.2022): Cargar los materiales de baja calidad de la base de datos local
        '--------------------------------------------------------------------------------------------------------------------

        dtDefEC = oFacturaMgr.BajaCalidadSel()


        If Not dtDefEC Is Nothing AndAlso dtDefEC.Rows.Count > 0 Then


            dtTemp = dtDefEC.Clone
            dtTemp.Columns.Add("Minimo", GetType(Integer))
            dtTemp.Columns.Add("Maximo", GetType(Integer))
            dtTemp.Columns.Add("MaximoTotal", GetType(Integer))
            If dtTemp.Columns.Contains("Motivo") = False Then
                dtTemp.Columns.Add("Motivo", GetType(String))  'Motivo por el que se está desmarcando
            End If
            dtTemp.Columns.Add("MotivoMarc", GetType(String)) 'Motivo por el que estaba marcado
            dtTemp.Columns.Add("DesmarcadoID", GetType(String))
            dtTemp.Columns.Add("MarcadoID", GetType(String))
            dtTemp.Columns.Add("TotalXTalla", GetType(Integer)) 'Cantidad total de un mismo codigo en una misma talla
            dtTemp.AcceptChanges()

            For Each oRowM In dtMateriales.Rows

                If oRowM!Libres > 0 Then


                    '--------------------------------------------------------------------------------------------------------------------
                    'Filtramos por Codigo 
                    '--------------------------------------------------------------------------------------------------------------------
                    dvMatDef = New DataView(dtDefEC, "Material = '" & CStr(oRowM!Codigo) & "'", "", DataViewRowState.CurrentRows)

                    If dvMatDef.Count > 0 Then

                        CantXTalla = dtDefEC.Compute("SUM(Cantidad)", "Material = '" & CStr(oRowM!Codigo) & "'") 'and Talla = '" & Talla.Trim.ToUpper & "'")


                        oFacturaTemp = oFacturaMgr.Create()
                        oFacturaMgr.GetExistenciaArticulo(CStr(oRowM!Codigo).Trim, oAppContext.ApplicationConfiguration.Almacen, "", oFacturaTemp)


                        Max = 0 : Min = 0

                        'If (oFacturaTemp.FacturaArticuloExistencia - CantXTalla) >= oRowM!Cantidad Then
                        '---------------------------------------------------------------------------------------------------------------------------------------
                        'RGERMAIN 16.07.2013: Revisamos si la cantidad en la factura es mayor a la que se tiene en existencia (en el caso de los pedidos Si Hay)
                        'entonces la cantidad sobre la que se calcula el minimo es la que se tiene en existencia
                        '---------------------------------------------------------------------------------------------------------------------------------------
                        CantFactura = IIf(oRowM!Cantidad > oRowM!Libres, oRowM!Libres, oRowM!Cantidad)
                        Libres = oRowM!Libres
                        Solicitados = oRowM!Cantidad

                        If (oRowM!Libres - CantXTalla) >= CantFactura Then
                            Min = 0
                        Else
                            'Min = oRowM!Cantidad - (oFacturaTemp.FacturaArticuloExistencia - CantXTalla)
                            Min = CantFactura - (oRowM!Libres - CantXTalla)
                        End If

                        oFacturaTemp = Nothing


                        If Libres - CantXTalla < Solicitados Then
                            For Each oRowDEC In dvMatDef
                                Max = IIf(oRowDEC!Cantidad < oRowM!Cantidad, oRowDEC!Cantidad, oRowM!Cantidad)
                                oNewRow = dtTemp.NewRow
                                With oNewRow
                                    !Material = CStr(oRowDEC!Material).Trim
                                    If Not oRowDEC!Talla Is DBNull.Value Then
                                        !Talla = CStr(oRowDEC!Talla).Trim
                                    Else
                                        !Talla = ""
                                    End If
                                    !Cantidad = 0
                                    !Minimo = Min
                                    !Maximo = Max
                                    !MaximoTotal = oRowM!Cantidad
                                    '--------------------------------------------------------------------------------------------------------------------
                                    ' JNAVA (08.02.2017): Obtenemos el id y motivo de desmarcado correcto para baja calidad
                                    '--------------------------------------------------------------------------------------------------------------------
                                    !Motivo = CStr(oRowDEC!Motivo).Trim 'MotivoDesmarcado.Trim
                                    !DesmarcadoID = CStr(oRowDEC!IDMotivo).Trim 'DesID.Trim
                                    '--------------------------------------------------------------------------------------------------------------------
                                    !MarcadoID = CStr(oRowDEC!IDMotivo).Trim
                                    !MotivoMarc = CStr(oRowDEC!Motivo).Trim
                                    !TotalXTalla = CantXTalla
                                End With
                                dtTemp.Rows.Add(oNewRow)
                            Next
                        End If
                    End If
                End If
            Next
            'Copiamos el detalle de los codigos que van en la factura que estan marcados en SAP como de baja calidad para EC
            dtDefecSAP = dtTemp.Copy

            If dtTemp.Rows.Count > 0 Then
                If UserName.Trim = "" Then
                    If MessageBox.Show("El código seleccionado se encuentra marcado como de baja calidad." & vbCrLf & "Es necesario especificarlo." & _
                    vbCrLf & vbCrLf & "¿Desea continuar con este proceso?", "Dportenis PRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        bRes = False
                    End If
                End If
                If bRes = True Then
                    Dim oFrmDE As New frmDesmarcarDefectuososEC
                    oFrmDE.dtSource = dtTemp
                    oFrmDE.UserDesmarca = UserName.Trim
                    If oFrmDE.ShowDialog() = DialogResult.OK Then
                        dtDefecEC = oFrmDE.dtDefectuososEC.Copy
                        UserName = oFrmDE.UserDesmarca.Trim
                    Else
                        MessageBox.Show("Es necesario especificar las piezas marcadas como baja calidad que van en la operación.", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                Else
                    bRes = False
                End If
            End If
        End If

        Return bRes
    End Function



    Private Sub ebCodArticulo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodArticulo.Validating
        If ebCodArticulo.ReadOnly Or ebCodArticulo.Text = String.Empty Then
            Exit Sub
        End If

        Me.ebCodArticulo.Text = Me.ebCodArticulo.Text.PadLeft(18, "0")

        Dim codColor As String = ""
        codColor = oArticuloMgr.SelectCodColor(ebCodArticulo.Text)
        If codColor <> "NA" Then
            'Buscar la imagen del producto
            Dim generico As String = ebCodArticulo.Text.Substring(8, 7)
            Dim strPath As String = oConfigCierreFI.ImagenesExistencia & generico & "-" & codColor & ".jpg"
            ObtenerImagen(strPath)
        Else
            pbImagen.Image = Nothing
        End If

        oDefectuoso.CodArticulo = Me.ebCodArticulo.Text

        Dim IsFound As Boolean = False

        If oDefectuoso.FacturaID <> 0 Then

            Dim dsArticulosFactura As New DataSet
            Dim i As Integer = 0

            dsArticulosFactura = oDefectuosoMgr.GetDetailFactura(oDefectuoso.FolioFactura, oDefectuoso.CodCaja)

            If Not (dsArticulosFactura Is Nothing) Then

                While (i < dsArticulosFactura.Tables(0).Rows.Count) And (Not IsFound)
                    If oDefectuoso.CodArticulo = dsArticulosFactura.Tables(0).Rows(i).Item("CodArticulo") Then
                        IsFound = True
                        oArticulo = oArticuloMgr.Load(ebCodArticulo.Text)
                    End If
                    i += 1
                End While

                If (Not IsFound) Then

                    MsgBox("Código de Artículo No Corresponde  a la Factura. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")
                    e.Cancel = True
                    Exit Sub

                Else

                    ValidaArticulo()

                End If

            End If
        Else

            oArticulo = oArticuloMgr.Load(ebCodArticulo.Text)

            '----------------------------------------------------------------------------------------------------------
            ' JNAVA (24.02.2016): Se obtiene la existencia libre del articulo cuando no tiene una factura ligada
            '----------------------------------------------------------------------------------------------------------
            vExistencia = 0
            Dim oFacturaMgr As New FacturaManager(oAppContext, oConfigCierreFI)
            Dim oExistencias As Factura
            oExistencias = oFacturaMgr.Create
            oFacturaMgr.GetExistenciaArticulo(oArticulo.CodArticulo, oAppContext.ApplicationConfiguration.Almacen, "", oExistencias, oArticulo.CodElectronico)
            vExistencia = oExistencias.FacturaArticuloExistencia
            oExistencias = Nothing
            oFacturaMgr = Nothing
            '----------------------------------------------------------------------------------------------------------

        End If

        If Not oArticulo Is Nothing Then
            'If oArticulo.WithImage = True Then
            '    pbImagen.Image = Image.FromStream(oArticulo.Imagen)
            'Else
            '    pbImagen.Image = Nothing
            'End If

            If File.Exists(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG") Then
                pbImagen.Image = Image.FromFile(Application.StartupPath & "\Fotos\" & oDefectuoso.CodArticulo & ".JPG")
            Else
                pbImagen.Image = Nothing
            End If

            vCorrida = UCase(oArticulo.CodCorrida)

            'If vCorrida = "ACC" Then

            '    oDefectuoso.Numero = 0

            'Else

            'GetTallas(oArticulo.CodCorrida)

            'End If

        Else

            MsgBox("El artículo que se desea marcar como defectuoso no se a encuentrado.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, " Defectuosos")

            e.Cancel = True

        End If

    End Sub

    Private Sub ebCodArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodArticulo.KeyDown
        If e.Alt And e.KeyCode = Keys.S Then
            Me.LoadSearchFormArticulos()
        End If
    End Sub

    'Private Sub nebTalla_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    '    'If nebTalla.ReadOnly Then

    '    '    Exit Sub

    '    'End If

    '    'If ebCodArticulo.Text <> "" Then

    '    '    If (nebTalla.Text = String.Empty) Then

    '    '        MsgBox("Talla incorrecta. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")

    '    '        oDefectuoso.Numero = 0

    '    '        e.Cancel = True

    '    '    Else

    '    '        If (nebTalla.Text = String.Empty) Then

    '    '            If oArticulo.CodCorrida = "ACC" Or oArticulo.CodCorrida = "TEX" Then

    '    '                vExistencia = oDefectuosoMgr.GetStock(oDefectuoso.CodAlmacen, oDefectuoso.CodArticulo, 0)

    '    '                Exit Sub

    '    '            Else

    '    '                Exit Sub

    '    '            End If

    '    '        End If

    '    '        If Not ValidaTalla(nebTalla.Text) Then

    '    '            MsgBox("La talla ingresada no corresponde al articulo. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")
    '    '            oDefectuoso.Numero = 0
    '    '            e.Cancel = True

    '    '        Else

    '    '            If (vExistencia < oDefectuoso.Cantidad) Then

    '    '                If (vExistencia < 1) Then
    '    '                    MsgBox("No se cuenta con existencia en esta talla.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")
    '    '                Else
    '    '                    MsgBox("Esta talla solo cuenta con " & vExistencia.ToString & " PP. en Existencias. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Defectuosos")
    '    '                End If

    '    '                oDefectuoso.Numero = 0

    '    '                e.Cancel = True

    '    '            End If

    '    '        End If

    '    '    End If

    '    'End If

    'End Sub

    Private Sub uiGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uiGuardar.Click

        bolImprimir = True
        SaveData()

    End Sub

#End Region

    Private Sub frmDefectuosos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.F2 Then

            bolImprimir = False
            SaveData()

        ElseIf e.KeyCode = Keys.F9 Then

            bolImprimir = True
            SaveData()

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Private Sub nebCantidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nebCantidad.Validating

        If (vExistencia < nebCantidad.Value) Then

            If (vExistencia < 1) Then

                MsgBox("No se cuenta con existencia.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

            Else

                MsgBox("El articulo solo cuenta con " & vExistencia.ToString & " PP. en Existencias. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

            End If

            oDefectuoso.Cantidad = vExistencia

            e.Cancel = True

        End If

    End Sub

    Private Sub ebPlayerID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebPlayerID.KeyDown
        bolPlayer = True
        If (e.KeyCode = Keys.Enter) Then

            Sm_Buscar()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        End If
    End Sub

    Private Sub ebPlayerID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebPlayerID.ButtonClick
        bolPlayer = True
        Sm_Buscar(True)

    End Sub


    Private Sub ebResponsableID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebResponsableID.KeyDown
        bolPlayer = False

        If (e.KeyCode = Keys.Enter) Then

            Sm_Buscar()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Sm_Buscar(True)

        End If
    End Sub

    Private Sub ebResponsableID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebResponsableID.ButtonClick
        bolPlayer = False
        Sm_Buscar(True)

    End Sub

    Private Sub ExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.ItemEventArgs) Handles ExplorerBar1.ItemClick

    End Sub

    Private Sub ebCodSAP_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodSAP.ButtonClick
        Me.LoadSearchFormFactura()
    End Sub

    Private Sub ebCodSAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebCodSAP.KeyDown
        If (e.KeyData.Alt And e.KeyCode = Keys.S) Then
            Me.LoadSearchFormFactura()
        End If
    End Sub

    Private Sub ebCodSAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodSAP.Validating
        If ebCodSAP.ReadOnly Then
            Exit Sub
        End If



        If ebCodSAP.Text <> "" And nebFolioFactura.Value <> 0 Then

            dsDataColumn = oDefectuosoMgr.GetDetailFactura(nebFolioFactura.Value, cbCodCaja.Text)

            If (dsDataColumn Is Nothing) Then

                MsgBox("La Factura no corresponde a la Caja " & cbCodCaja.Text & " o no existe.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

                oDefectuoso.FacturaID = 0
                oDefectuoso.FolioFactura = 0
                oDefectuoso.FolioSAP = "0"

                e.Cancel = True
            Else

                oDefectuoso.FacturaID = dsDataColumn.Tables(0).Rows(0).Item("FacturaID")

            End If
        Else

            MsgBox("No registro un numero de factura SAP, por lo cual es necesario que especifique el origen del defectuoso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Defectuosos")

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

#Region "Retail"


    Private Function FiltrarMotivo(ByVal strMotivo As String, ByVal dtFP As DataTable) As DataTable
        Dim dtTemp As DataTable = dtFP.Clone
        Dim oRow As DataRow

        For Each oRow In dtFP.Rows
            If oRow!CodMotivoDefectuosoPosicion = strMotivo Then
                dtTemp.ImportRow(oRow)
            End If
        Next

        Return dtTemp

    End Function


    Private Sub GetMotivosDefectuosos()

        Dim DefectuososMgr As New CatalogoArticuloManager(oAppContext)
        Dim dtDefectuoso As DataTable = DefectuososMgr.GetMotivosDefectuosos()

        dtDefectuoso = FiltrarMotivo("Z3", dtDefectuoso)

        Me.ebDefectoNota.DataSource = dtDefectuoso
        Me.ebDefectoNota.DisplayMember = "MotivoDefectuoso"
        Me.ebDefectoNota.ValueMember = "CodMotivoDefectuoso"
        Me.ebDefectoNota.Refresh()
        Me.ebDefectoNota.SelectedValue = "03"
        Me.ebDefectoNota.ReadOnly = True

    End Sub
#End Region

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub nebCantidad_Click(sender As System.Object, e As System.EventArgs) Handles nebCantidad.Click

    End Sub
End Class
