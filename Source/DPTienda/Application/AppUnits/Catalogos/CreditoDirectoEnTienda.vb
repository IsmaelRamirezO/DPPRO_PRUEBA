Public Class CreditoDirectoEnTienda
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
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTemas2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebAvalColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbAvalEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ebAvalCP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ebAvalTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbAvalCiudad As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebAvalDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ebAvalPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ebAvalNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ebAvalSexo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents npFirmaDigital As PureComponents.NicePanel.NicePanel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCapturaFirma As Janus.Windows.EditControls.UIButton
    Friend WithEvents EditBox1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiComboBox1 As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EditBox4 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EditBox5 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EditBox6 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UiComboBox2 As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CalendarCombo1 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EditBox7 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EditBox8 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EditBox9 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CreditoDirectoEnTienda))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem7 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem8 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem9 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem10 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem11 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem12 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem13 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTemas2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTemas1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoAbrir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuAyudaTemas = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTemas")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox3 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox2 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox1 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox6 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.EditBox5 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.EditBox9 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EditBox8 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.EditBox7 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CalendarCombo1 = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UiComboBox2 = New Janus.Windows.EditControls.UIComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.EditBox4 = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.UiComboBox1 = New Janus.Windows.EditControls.UIComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCapturaFirma = New Janus.Windows.EditControls.UIButton
        Me.npFirmaDigital = New PureComponents.NicePanel.NicePanel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ebAvalColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.cbAvalEstado = New Janus.Windows.EditControls.UIComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.ebAvalCP = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.ebAvalTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cbAvalCiudad = New Janus.Windows.EditControls.UIComboBox
        Me.ebAvalDomicilio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.ebAvalPaterno = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.ebAvalNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ebAvalSexo = New Janus.Windows.EditControls.UIComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
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
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        Me.npFirmaDigital.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoAbrir, Me.menuArchivoGuardar, Me.menuArchivoSalir, Me.menuAyudaTemas})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("321566a7-b6ff-4860-bf8a-3eeb87e72591")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuAyuda1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(664, 24)
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
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator4, Me.menuArchivoAbrir2, Me.Separator5, Me.menuArchivoGuardar2, Me.Separator6, Me.menuAyudaTemas2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(255, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoAbrir2
        '
        Me.menuArchivoAbrir2.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir2.Name = "menuArchivoAbrir2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
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
        'menuAyudaTemas2
        '
        Me.menuAyudaTemas2.Key = "menuAyudaTemas"
        Me.menuAyudaTemas2.Name = "menuAyudaTemas2"
        Me.menuAyudaTemas2.Text = "Ayuda"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoAbrir1, Me.Separator2, Me.menuArchivoGuardar1, Me.Separator3, Me.menuArchivoSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoAbrir1
        '
        Me.menuArchivoAbrir1.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir1.Name = "menuArchivoAbrir1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTemas1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTemas1
        '
        Me.menuAyudaTemas1.Key = "menuAyudaTemas"
        Me.menuAyudaTemas1.Name = "menuAyudaTemas1"
        '
        'menuArchivoNuevo
        '
        Me.menuArchivoNuevo.Image = CType(resources.GetObject("menuArchivoNuevo.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Name = "menuArchivoNuevo"
        Me.menuArchivoNuevo.Text = "&Nuevo"
        '
        'menuArchivoAbrir
        '
        Me.menuArchivoAbrir.Image = CType(resources.GetObject("menuArchivoAbrir.Image"), System.Drawing.Image)
        Me.menuArchivoAbrir.Key = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Name = "menuArchivoAbrir"
        Me.menuArchivoAbrir.Text = "A&brir"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "&Salir"
        '
        'menuAyudaTemas
        '
        Me.menuAyudaTemas.Image = CType(resources.GetObject("menuAyudaTemas.Image"), System.Drawing.Image)
        Me.menuAyudaTemas.Key = "menuAyudaTemas"
        Me.menuAyudaTemas.Name = "menuAyudaTemas"
        Me.menuAyudaTemas.Text = "&Temas de Ayuda"
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
        Me.TopRebar1.Size = New System.Drawing.Size(664, 50)
        Me.TopRebar1.TabIndex = 0
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.EditBox3)
        Me.ExplorerBar1.Controls.Add(Me.EditBox2)
        Me.ExplorerBar1.Controls.Add(Me.EditBox1)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar2)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Crédito En Tienda"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(664, 680)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox3
        '
        Me.EditBox3.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox3.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox3.BackColor = System.Drawing.Color.Ivory
        Me.EditBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox3.Location = New System.Drawing.Point(248, 72)
        Me.EditBox3.Name = "EditBox3"
        Me.EditBox3.Size = New System.Drawing.Size(240, 22)
        Me.EditBox3.TabIndex = 75
        Me.EditBox3.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox2
        '
        Me.EditBox2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox2.ButtonImage = CType(resources.GetObject("EditBox2.ButtonImage"), System.Drawing.Image)
        Me.EditBox2.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.EditBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox2.Location = New System.Drawing.Point(160, 72)
        Me.EditBox2.Name = "EditBox2"
        Me.EditBox2.Size = New System.Drawing.Size(88, 22)
        Me.EditBox2.TabIndex = 74
        Me.EditBox2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox1
        '
        Me.EditBox1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox1.Location = New System.Drawing.Point(160, 48)
        Me.EditBox1.Name = "EditBox1"
        Me.EditBox1.Size = New System.Drawing.Size(128, 22)
        Me.EditBox1.TabIndex = 73
        Me.EditBox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.EditBox6)
        Me.ExplorerBar2.Controls.Add(Me.Label6)
        Me.ExplorerBar2.Controls.Add(Me.EditBox5)
        Me.ExplorerBar2.Controls.Add(Me.Label5)
        Me.ExplorerBar2.Controls.Add(Me.ExplorerBar3)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalColonia)
        Me.ExplorerBar2.Controls.Add(Me.Label28)
        Me.ExplorerBar2.Controls.Add(Me.cbAvalEstado)
        Me.ExplorerBar2.Controls.Add(Me.Label22)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalCP)
        Me.ExplorerBar2.Controls.Add(Me.Label24)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalTelefono)
        Me.ExplorerBar2.Controls.Add(Me.Label25)
        Me.ExplorerBar2.Controls.Add(Me.cbAvalCiudad)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalDomicilio)
        Me.ExplorerBar2.Controls.Add(Me.Label26)
        Me.ExplorerBar2.Controls.Add(Me.Label27)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalPaterno)
        Me.ExplorerBar2.Controls.Add(Me.Label35)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalNombre)
        Me.ExplorerBar2.Controls.Add(Me.Label23)
        Me.ExplorerBar2.Controls.Add(Me.ebAvalSexo)
        Me.ExplorerBar2.Controls.Add(Me.Label7)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Datos del Aval"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 112)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(664, 560)
        Me.ExplorerBar2.TabIndex = 7
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox6
        '
        Me.EditBox6.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox6.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox6.Location = New System.Drawing.Point(160, 160)
        Me.EditBox6.Name = "EditBox6"
        Me.EditBox6.Size = New System.Drawing.Size(440, 22)
        Me.EditBox6.TabIndex = 95
        Me.EditBox6.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 23)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Email:"
        '
        'EditBox5
        '
        Me.EditBox5.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox5.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox5.Location = New System.Drawing.Point(400, 64)
        Me.EditBox5.Name = "EditBox5"
        Me.EditBox5.Size = New System.Drawing.Size(208, 22)
        Me.EditBox5.TabIndex = 93
        Me.EditBox5.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Materno:"
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.EditBox9)
        Me.ExplorerBar3.Controls.Add(Me.EditBox8)
        Me.ExplorerBar3.Controls.Add(Me.Label13)
        Me.ExplorerBar3.Controls.Add(Me.Label12)
        Me.ExplorerBar3.Controls.Add(Me.EditBox7)
        Me.ExplorerBar3.Controls.Add(Me.Label11)
        Me.ExplorerBar3.Controls.Add(Me.CalendarCombo1)
        Me.ExplorerBar3.Controls.Add(Me.Label10)
        Me.ExplorerBar3.Controls.Add(Me.Panel1)
        Me.ExplorerBar3.Controls.Add(Me.UiComboBox2)
        Me.ExplorerBar3.Controls.Add(Me.Label9)
        Me.ExplorerBar3.Controls.Add(Me.Label8)
        Me.ExplorerBar3.Controls.Add(Me.EditBox4)
        Me.ExplorerBar3.Controls.Add(Me.Label4)
        Me.ExplorerBar3.Controls.Add(Me.UiComboBox1)
        Me.ExplorerBar3.Controls.Add(Me.Label3)
        Me.ExplorerBar3.Controls.Add(Me.btnCapturaFirma)
        Me.ExplorerBar3.Controls.Add(Me.npFirmaDigital)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Datos de Crédito"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 240)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(664, 312)
        Me.ExplorerBar3.TabIndex = 91
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'EditBox9
        '
        Me.EditBox9.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox9.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox9.BackColor = System.Drawing.Color.Ivory
        Me.EditBox9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox9.Location = New System.Drawing.Point(200, 224)
        Me.EditBox9.Name = "EditBox9"
        Me.EditBox9.Size = New System.Drawing.Size(152, 22)
        Me.EditBox9.TabIndex = 107
        Me.EditBox9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox9.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'EditBox8
        '
        Me.EditBox8.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox8.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox8.BackColor = System.Drawing.Color.Ivory
        Me.EditBox8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox8.Location = New System.Drawing.Point(200, 200)
        Me.EditBox8.Name = "EditBox8"
        Me.EditBox8.Size = New System.Drawing.Size(312, 22)
        Me.EditBox8.TabIndex = 106
        Me.EditBox8.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(40, 232)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 23)
        Me.Label13.TabIndex = 105
        Me.Label13.Text = "Fecha del Registro:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(40, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 23)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Usuario que Registró:"
        '
        'EditBox7
        '
        Me.EditBox7.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox7.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox7.Location = New System.Drawing.Point(200, 160)
        Me.EditBox7.Name = "EditBox7"
        Me.EditBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EditBox7.Size = New System.Drawing.Size(120, 22)
        Me.EditBox7.TabIndex = 103
        Me.EditBox7.Text = "$ 0.00"
        Me.EditBox7.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox7.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 23)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "Limite de Crédito"
        '
        'CalendarCombo1
        '
        '
        'CalendarCombo1.DropDownCalendar
        '
        Me.CalendarCombo1.DropDownCalendar.Location = New System.Drawing.Point(0, 0)
        Me.CalendarCombo1.DropDownCalendar.Name = ""
        Me.CalendarCombo1.DropDownCalendar.Size = New System.Drawing.Size(170, 173)
        Me.CalendarCombo1.DropDownCalendar.TabIndex = 0
        Me.CalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.CalendarCombo1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarCombo1.Location = New System.Drawing.Point(200, 136)
        Me.CalendarCombo1.Name = "CalendarCombo1"
        Me.CalendarCombo1.Size = New System.Drawing.Size(120, 22)
        Me.CalendarCombo1.TabIndex = 101
        Me.CalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 23)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Fecha de Expiración:"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(40, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 8)
        Me.Panel1.TabIndex = 99
        '
        'UiComboBox2
        '
        Me.UiComboBox2.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.UiComboBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.Text = "MASCULINO"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.Text = "FEMENINO"
        Me.UiComboBox2.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2})
        Me.UiComboBox2.Location = New System.Drawing.Point(200, 88)
        Me.UiComboBox2.Name = "UiComboBox2"
        Me.UiComboBox2.Size = New System.Drawing.Size(56, 22)
        Me.UiComboBox2.TabIndex = 98
        Me.UiComboBox2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(264, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 23)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Quicenas."
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 23)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Plazo:"
        '
        'EditBox4
        '
        Me.EditBox4.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.EditBox4.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.EditBox4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditBox4.Location = New System.Drawing.Point(200, 64)
        Me.EditBox4.Name = "EditBox4"
        Me.EditBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EditBox4.Size = New System.Drawing.Size(120, 22)
        Me.EditBox4.TabIndex = 85
        Me.EditBox4.Text = "$ 0.00"
        Me.EditBox4.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 23)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Limite de Crédito Banco:"
        '
        'UiComboBox1
        '
        Me.UiComboBox1.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.UiComboBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.Text = "MASCULINO"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.Text = "FEMENINO"
        Me.UiComboBox1.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem3, UiComboBoxItem4})
        Me.UiComboBox1.Location = New System.Drawing.Point(200, 40)
        Me.UiComboBox1.Name = "UiComboBox1"
        Me.UiComboBox1.Size = New System.Drawing.Size(120, 22)
        Me.UiComboBox1.TabIndex = 83
        Me.UiComboBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Banco:"
        '
        'btnCapturaFirma
        '
        Me.btnCapturaFirma.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapturaFirma.Location = New System.Drawing.Point(416, 152)
        Me.btnCapturaFirma.Name = "btnCapturaFirma"
        Me.btnCapturaFirma.Size = New System.Drawing.Size(232, 24)
        Me.btnCapturaFirma.TabIndex = 57
        Me.btnCapturaFirma.Text = "Capturar Firma"
        '
        'npFirmaDigital
        '
        Me.npFirmaDigital.BackColor = System.Drawing.Color.Transparent
        Me.npFirmaDigital.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.TopCenter
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 50
        Me.npFirmaDigital.ContainerImage = ContainerImage1
        Me.npFirmaDigital.ContextMenuButton = False
        Me.npFirmaDigital.Controls.Add(Me.PictureBox2)
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.npFirmaDigital.FooterImage = HeaderImage1
        Me.npFirmaDigital.FooterText = "PureComponents NicePanel for .NET WinForms V1.0."
        Me.npFirmaDigital.FooterVisible = False
        Me.npFirmaDigital.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Pencil
        HeaderImage2.Image = Nothing
        Me.npFirmaDigital.HeaderImage = HeaderImage2
        Me.npFirmaDigital.HeaderText = "Firma Digital"
        Me.npFirmaDigital.IsExpanded = True
        Me.npFirmaDigital.Location = New System.Drawing.Point(416, 40)
        Me.npFirmaDigital.Name = "npFirmaDigital"
        Me.npFirmaDigital.OriginalFooterVisible = False
        Me.npFirmaDigital.OriginalHeight = 0
        Me.npFirmaDigital.Size = New System.Drawing.Size(232, 112)
        ContainerStyle1.BackColor = System.Drawing.SystemColors.Control
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        ContainerStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(9, Byte), CType(42, Byte), CType(127, Byte))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(102, Byte), CType(145, Byte), CType(215, Byte))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(169, Byte), CType(198, Byte), CType(237, Byte))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.SystemColors.Control
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalBackward
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.npFirmaDigital.Style = PanelStyle1
        Me.npFirmaDigital.TabIndex = 58
        Me.npFirmaDigital.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(0, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(232, 87)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'ebAvalColonia
        '
        Me.ebAvalColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalColonia.Location = New System.Drawing.Point(160, 112)
        Me.ebAvalColonia.Name = "ebAvalColonia"
        Me.ebAvalColonia.Size = New System.Drawing.Size(328, 22)
        Me.ebAvalColonia.TabIndex = 75
        Me.ebAvalColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(40, 120)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(96, 23)
        Me.Label28.TabIndex = 90
        Me.Label28.Text = "Colonia:"
        '
        'cbAvalEstado
        '
        Me.cbAvalEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbAvalEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.Text = "JALISCO"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.Text = "MEXICO"
        UiComboBoxItem7.FormatStyle.Alpha = 0
        UiComboBoxItem7.Text = "MICHOACAN"
        Me.cbAvalEstado.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem5, UiComboBoxItem6, UiComboBoxItem7})
        Me.cbAvalEstado.Location = New System.Drawing.Point(160, 136)
        Me.cbAvalEstado.Name = "cbAvalEstado"
        Me.cbAvalEstado.Size = New System.Drawing.Size(176, 22)
        Me.cbAvalEstado.TabIndex = 77
        Me.cbAvalEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(40, 144)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "Estado:"
        '
        'ebAvalCP
        '
        Me.ebAvalCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalCP.Location = New System.Drawing.Point(160, 184)
        Me.ebAvalCP.Name = "ebAvalCP"
        Me.ebAvalCP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebAvalCP.Size = New System.Drawing.Size(88, 22)
        Me.ebAvalCP.TabIndex = 79
        Me.ebAvalCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(40, 192)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 23)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "C.P."
        '
        'ebAvalTelefono
        '
        Me.ebAvalTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalTelefono.Location = New System.Drawing.Point(400, 184)
        Me.ebAvalTelefono.Mask = "!(###) 000-0000"
        Me.ebAvalTelefono.Name = "ebAvalTelefono"
        Me.ebAvalTelefono.Size = New System.Drawing.Size(152, 22)
        Me.ebAvalTelefono.TabIndex = 80
        Me.ebAvalTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(328, 192)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(96, 23)
        Me.Label25.TabIndex = 87
        Me.Label25.Text = "Teléfono:"
        '
        'cbAvalCiudad
        '
        Me.cbAvalCiudad.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbAvalCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem8.FormatStyle.Alpha = 0
        UiComboBoxItem8.Text = "CULIACAN"
        UiComboBoxItem9.FormatStyle.Alpha = 0
        UiComboBoxItem9.Text = "GUASAVE"
        UiComboBoxItem10.FormatStyle.Alpha = 0
        UiComboBoxItem10.Text = "MAZATLAN"
        UiComboBoxItem11.FormatStyle.Alpha = 0
        UiComboBoxItem11.Text = "MOCHIS"
        Me.cbAvalCiudad.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem8, UiComboBoxItem9, UiComboBoxItem10, UiComboBoxItem11})
        Me.cbAvalCiudad.Location = New System.Drawing.Point(400, 136)
        Me.cbAvalCiudad.Name = "cbAvalCiudad"
        Me.cbAvalCiudad.Size = New System.Drawing.Size(176, 22)
        Me.cbAvalCiudad.TabIndex = 78
        Me.cbAvalCiudad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ebAvalDomicilio
        '
        Me.ebAvalDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalDomicilio.Location = New System.Drawing.Point(160, 88)
        Me.ebAvalDomicilio.Name = "ebAvalDomicilio"
        Me.ebAvalDomicilio.Size = New System.Drawing.Size(440, 22)
        Me.ebAvalDomicilio.TabIndex = 74
        Me.ebAvalDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(344, 144)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 23)
        Me.Label26.TabIndex = 86
        Me.Label26.Text = "Ciudad:"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(40, 96)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 23)
        Me.Label27.TabIndex = 85
        Me.Label27.Text = "Domicilio:"
        '
        'ebAvalPaterno
        '
        Me.ebAvalPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalPaterno.Location = New System.Drawing.Point(160, 64)
        Me.ebAvalPaterno.Name = "ebAvalPaterno"
        Me.ebAvalPaterno.Size = New System.Drawing.Size(160, 22)
        Me.ebAvalPaterno.TabIndex = 72
        Me.ebAvalPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(40, 72)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(120, 16)
        Me.Label35.TabIndex = 83
        Me.Label35.Text = "Apellido Paterno:"
        '
        'ebAvalNombre
        '
        Me.ebAvalNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAvalNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAvalNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAvalNombre.Location = New System.Drawing.Point(160, 40)
        Me.ebAvalNombre.Name = "ebAvalNombre"
        Me.ebAvalNombre.Size = New System.Drawing.Size(368, 22)
        Me.ebAvalNombre.TabIndex = 71
        Me.ebAvalNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAvalNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(40, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 23)
        Me.Label23.TabIndex = 81
        Me.Label23.Text = "Nombre:"
        '
        'ebAvalSexo
        '
        Me.ebAvalSexo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebAvalSexo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem12.FormatStyle.Alpha = 0
        UiComboBoxItem12.Text = "MASCULINO"
        UiComboBoxItem13.FormatStyle.Alpha = 0
        UiComboBoxItem13.Text = "FEMENINO"
        Me.ebAvalSexo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem12, UiComboBoxItem13})
        Me.ebAvalSexo.Location = New System.Drawing.Point(160, 208)
        Me.ebAvalSexo.Name = "ebAvalSexo"
        Me.ebAvalSexo.Size = New System.Drawing.Size(88, 22)
        Me.ebAvalSexo.TabIndex = 76
        Me.ebAvalSexo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Sexo:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Crédito En Tienda:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código Asociado:"
        '
        'CreditoDirectoEnTienda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 669)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(672, 696)
        Me.MinimumSize = New System.Drawing.Size(672, 696)
        Me.Name = "CreditoDirectoEnTienda"
        Me.Text = "Forma de Credito Directo en Tienda"
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
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.npFirmaDigital.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CreditoDirectoEnTienda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
