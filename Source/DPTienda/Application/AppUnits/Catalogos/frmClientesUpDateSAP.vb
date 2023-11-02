Imports System.Data
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU

Public Class frmClientesUpDateSAP
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
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Private WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.EditBox
    Private WithEvents ebCP As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Private WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Private WithEvents ebEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Private WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Private WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Private WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Private WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir3 As Janus.Windows.UI.CommandBars.UICommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesUpDateSAP))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebCP = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoSalir3 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
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
        Me.ExplorerBar1.Controls.Add(Me.ebClienteID)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefono)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.ebColonia)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.ebEmail)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.ContainerHeight = 100
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Clientes"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(576, 212)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonEnabled = False
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.Location = New System.Drawing.Point(136, 40)
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(160, 20)
        Me.ebClienteID.TabIndex = 1
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCP.Location = New System.Drawing.Point(376, 112)
        Me.ebCP.MaxLength = 5
        Me.ebCP.Name = "ebCP"
        Me.ebCP.Numeric = True
        Me.ebCP.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.ebCP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebCP.Size = New System.Drawing.Size(120, 22)
        Me.ebCP.TabIndex = 10
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCiudad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.ebCiudad.DesignTimeLayout = GridEXLayout1
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCiudad.Location = New System.Drawing.Point(136, 136)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.Size = New System.Drawing.Size(192, 22)
        Me.ebCiudad.TabIndex = 9
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.ebEstado.DesignTimeLayout = GridEXLayout2
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEstado.Location = New System.Drawing.Point(136, 112)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.Size = New System.Drawing.Size(192, 22)
        Me.ebEstado.TabIndex = 8
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebTelefono
        '
        Me.ebTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefono.Location = New System.Drawing.Point(400, 136)
        Me.ebTelefono.Mask = "!(###) 000-0000"
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ebTelefono.Size = New System.Drawing.Size(96, 22)
        Me.ebTelefono.TabIndex = 11
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(336, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 16)
        Me.Label21.TabIndex = 177
        Me.Label21.Text = "Telefono:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(336, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 23)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "C.P. :"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 23)
        Me.Label19.TabIndex = 175
        Me.Label19.Text = "Estado:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 23)
        Me.Label18.TabIndex = 174
        Me.Label18.Text = "Ciudad:"
        '
        'ebColonia
        '
        Me.ebColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColonia.Location = New System.Drawing.Point(136, 88)
        Me.ebColonia.MaxLength = 50
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(360, 22)
        Me.ebColonia.TabIndex = 7
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 23)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Colonia:"
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(136, 64)
        Me.ebDomicilio.MaxLength = 50
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.Size = New System.Drawing.Size(360, 22)
        Me.ebDomicilio.TabIndex = 6
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 23)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Domicilio:"
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(136, 160)
        Me.ebEmail.MaxLength = 50
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.Size = New System.Drawing.Size(240, 22)
        Me.ebEmail.TabIndex = 12
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "E-mail:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 23)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Codigo:"
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuArchivoSalir, Me.menuArchivoGuardar, Me.menuAyuda})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("17f7cab3-14ba-48ec-842c-0de6c09c929f")
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.Separator1, Me.menuAyuda1, Me.Separator8, Me.menuArchivoSalir2})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(576, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuArchivoSalir2
        '
        Me.menuArchivoSalir2.Key = "menuArchivoSalir"
        Me.menuArchivoSalir2.Name = "menuArchivoSalir2"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Separator5, Me.menuArchivoGuardar2, Me.Separator6, Me.menuArchivoSalir1, Me.Separator7, Me.Separator3})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(117, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
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
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Separator2, Me.menuArchivoGuardar1, Me.Separator4, Me.menuArchivoSalir3})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
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
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoSalir3
        '
        Me.menuArchivoSalir3.Key = "menuArchivoSalir"
        Me.menuArchivoSalir3.Name = "menuArchivoSalir3"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
        '
        'menuArchivoGuardar
        '
        Me.menuArchivoGuardar.Image = CType(resources.GetObject("menuArchivoGuardar.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Name = "menuArchivoGuardar"
        Me.menuArchivoGuardar.Text = "&Guardar"
        '
        'menuAyuda
        '
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
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
        Me.TopRebar1.Size = New System.Drawing.Size(576, 50)
        Me.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmClientesUpDateSAP
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 262)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmClientesUpDateSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizae Datos Clientes"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
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


#Region "Environment Var"

    'Objeto Cliente
    Dim oClienteMgr As ClientesManager
    
    'Objetos DataTable
    Dim dtEstados As DataTable
    Private dtMunicipio As DataTable
    Private dsCodigos As New DataSet
    Private dsCodigosDF As New DataSet
    Private rango1, rango2, rango1DF, rango2DF As Integer

#End Region

#Region "Initialize"

    Private Sub InitializeObjects()

        oClienteMgr = New ClientesManager(oAppContext, oAppSAPConfig)
        
    End Sub

#End Region

#Region "Properties"

    Private strCodigoAlterno As String
    Private strCiudad As String
    Private strColonia As String
    Private strCP As String
    Private strDireccion As String
    Private strEMail As String
    Private strEstado As String
    Private strTelefono As String


    Public Property CodigoAlterno() As String
        Get

            Return strCodigoAlterno

        End Get

        Set(ByVal Value As String)

            strCodigoAlterno = Value

        End Set

    End Property

    Public Property Ciudad() As String
        Get

            Return strCiudad

        End Get

        Set(ByVal Value As String)

            strCiudad = Value

        End Set

    End Property

    Public Property Colonia() As String
        Get

            Return strColonia

        End Get

        Set(ByVal Value As String)

            strColonia = Value

        End Set

    End Property

    Public Property CP() As String
        Get

            Return strCP

        End Get

        Set(ByVal Value As String)

            strCP = Value

        End Set

    End Property

    Public Property Direccion() As String
        Get

            Return strDireccion

        End Get

        Set(ByVal Value As String)

            strDireccion = Value

        End Set

    End Property

    Public Property EMail() As String
        Get

            Return strEMail

        End Get

        Set(ByVal Value As String)

            strEMail = Value

        End Set

    End Property

    Public Property Estado() As String
        Get

            Return strEstado

        End Get

        Set(ByVal Value As String)

            strEstado = Value

        End Set

    End Property

    Public Property Telefono() As String
        Get

            Return strTelefono

        End Get

        Set(ByVal Value As String)

            strTelefono = Value

        End Set

    End Property




#End Region

#Region "General Methods"

    Private Function ValidaDatos() As Boolean

        If Me.ebDomicilio.Text = String.Empty Then
            MessageBox.Show("Capture el Domicilio", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebDomicilio.Focus()
            Return False

        ElseIf Me.ebColonia.Text = String.Empty Then
            MessageBox.Show("Captura la Colonia", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebColonia.Focus()
            Return False

        ElseIf Me.ebEstado.Text = String.Empty Then
            MessageBox.Show("Seleccione Estado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebEstado.Focus()
            Return False

        ElseIf Me.ebCiudad.Text = String.Empty Then
            MessageBox.Show("Seleccione Ciudad", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebCiudad.Focus()
            Return False

        ElseIf Me.ebCP.Text = String.Empty Then
            MessageBox.Show("Capture el Código Postal", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebCP.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub SaveCliente()
        Try

            If Not ValidaDatos() Then
                Exit Sub
            End If

            'Grabar en Dp y en SAP
            If oClienteMgr.ActualizaClientes(ebClienteID.Text, Me.ebDomicilio.Text, Me.ebCP.Text, Me.ebCiudad.Text, Me.ebEstado.Text, Me.ebTelefono.Text, Me.ebEmail.Text, Me.ebColonia.Text) = "X" Then
                oClienteMgr.UpdateSAPX(ebClienteID.Text, Me.ebDomicilio.Text, Me.ebCP.Text, Me.ebCiudad.Text, Me.ebEstado.Value, Me.ebTelefono.Text, Me.ebEmail.Text, Me.ebColonia.Text)
                MsgBox("Cliente se Actualizó satisfactoriamente. Codigo de Cliente :" & ebClienteID.Text, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Actualizar Cliente")
            Else

                MsgBox("No se actualizaron los datos del cliente. Codigo de Cliente :" & ebClienteID.Text, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Error Actualización")

            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Private Sub FillComboEstados()

        dtEstados = oClienteMgr.GetAllStates(False)

        With ebEstado

            .DataSource = dtEstados
            .DropDownList.Columns.Add("Estado")
            .DropDownList.Columns.Add("CodEstado")
            .DropDownList.Columns("CodEstado").Visible = False
            .DropDownList.Columns("CodEstado").DataMember = "CodEstado"
            .DropDownList.Columns("Estado").DataMember = "Descripcion"
            .DropDownList.Columns("Estado").Width = 170

            .DisplayMember = "Descripcion"
            .ValueMember = "CodEstado"

            .Refresh()

        End With


    End Sub

    Private Sub FillGeneralData()

        dtMunicipio = oClienteMgr.GetAllMunicipio(False)

    End Sub

    Private Sub FilldtComboCiudades(ByVal Abrevia As String)


        Dim dvCiudades As DataView = New DataView(dtMunicipio)
        dvCiudades.RowFilter = "CodEstado like '" & Abrevia & "'"

        With ebCiudad

            .DropDownList.ClearStructure()

            .DataSource = dvCiudades
            .DropDownList.Columns.Add("CodMunicipio")
            .DropDownList.Columns.Add("Ciudad")
            .DropDownList.Columns("CodMunicipio").Visible = False
            .DropDownList.Columns("CodMunicipio").DataMember = "CodMunicipio"
            .DropDownList.Columns("Ciudad").DataMember = "NombreMunicipio"
            .DropDownList.Columns("Ciudad").Width = 170

            .DisplayMember = "NombreMunicipio"
            .ValueMember = "CodMunicipio"

            .Refresh()

        End With

    End Sub

    Private Function BuscaEstado(ByVal strEstado As String) As String

        Dim i As Integer

        For i = 0 To (dtEstados.Rows.Count - 1)

            If dtEstados.Rows(i).Item("Descripcion") = strEstado Then

                Return dtEstados.Rows(i).Item("CodEstado")

            End If

        Next

        Return -1

    End Function

    Private Function BuscaMunicipio(ByVal strMunicipio As String, ByVal CodEstado As String) As Integer

        Dim i As Integer

        For i = 0 To (dtMunicipio.Rows.Count - 1)

            If dtMunicipio.Rows(i).Item("NombreMunicipio") = strMunicipio And dtMunicipio.Rows(i).Item("CodEstado") = CodEstado Then

                Return dtMunicipio.Rows(i).Item("CodMunicipio")

            End If

        Next

        Return -1

    End Function

#End Region

#Region "Fiscal Data Methods"


    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick


        Select Case e.Command.Key

            Case "menuArchivoSalir"

                Me.CodigoAlterno = String.Empty
                Me.Colonia = String.Empty
                Me.CP = String.Empty
                Me.Direccion = String.Empty
                Me.EMail = String.Empty
                Me.Estado = String.Empty

                Me.Close()

            Case "menuArchivoGuardar"

                Try

                    SaveCliente()

                Catch ex As Exception
                    Throw ex
                End Try
        End Select

    End Sub

#End Region

#Region "Validating"


    Private Sub ebCiudad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCiudad.Validating


        If (ebCiudad.Text.Trim = String.Empty) Then

            e.Cancel = True
            Return

        End If


        Dim vValueTemp As Integer


        If ebCiudad.Text <> "" Then

            vValueTemp = BuscaMunicipio(ebCiudad.Text, Me.ebEstado.Value)

            If vValueTemp < 0 Then

                MsgBox("Ciudad no se encuentra registrada. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                e.Cancel = True

            Else

                ebCiudad.Value = vValueTemp


                dsCodigos = oClienteMgr.GetRange(Me.ebEstado.Value, Me.ebCiudad.Value).Copy

                rango1 = CType(dsCodigos.Tables("codigos").Rows(0).Item(0), Integer)
                rango2 = CType(dsCodigos.Tables("codigos").Rows(0).Item(1), Integer)


            End If

        End If

        'ctrlError(sender, e)
    End Sub

    Private Sub Validarciudad()

        If (ebCiudad.Text.Trim = String.Empty) Then

            Exit Sub

        End If


        Dim vValueTemp As Integer


        If ebCiudad.Text <> "" Then

            vValueTemp = BuscaMunicipio(ebCiudad.Text, Me.ebEstado.Value)

            If vValueTemp < 0 Then

                MsgBox("Ciudad no se encuentra registrada. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                Exit Sub

            Else

                ebCiudad.Value = vValueTemp


                dsCodigos = oClienteMgr.GetRange(Me.ebEstado.Value, Me.ebCiudad.Value).Copy

                rango1 = CType(dsCodigos.Tables("codigos").Rows(0).Item(0), Integer)
                rango2 = CType(dsCodigos.Tables("codigos").Rows(0).Item(1), Integer)


            End If

        End If
    End Sub

    Private Sub ValidarEstado()

        If (ebEstado.Text.Trim = String.Empty) Then

            ebEstado.Focus()
            Return

        End If


        Dim vValueTemp As Integer

        If ebEstado.Text <> "" Then

            If ebEstado.Value Is Nothing Then

                vValueTemp = BuscaEstado(ebEstado.Text)

                If vValueTemp < 0 Then

                    MsgBox("Estado no se encuentra registrado. No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                Else

                    ebEstado.Value = vValueTemp

                    FilldtComboCiudades(vValueTemp)

                End If

            Else

                FilldtComboCiudades(ebEstado.Value)

            End If

        Else

            ebCiudad.DropDownList.ClearStructure()

        End If

    End Sub

    Private Sub ebEstado_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEstado.Validating

        If (ebEstado.Text.Trim = String.Empty) Then

            ebEstado.Focus()
            Return

        End If


        Dim vValueTemp As Integer

        If ebEstado.Text <> "" Then

            If ebEstado.Value Is Nothing Then

                vValueTemp = BuscaEstado(ebEstado.Text)

                If vValueTemp < 0 Then

                    MsgBox("Estado no se encuentra registrado. No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                    e.Cancel = True

                Else

                    ebEstado.Value = vValueTemp

                    FilldtComboCiudades(vValueTemp)

                End If

            Else

                FilldtComboCiudades(ebEstado.Value)

            End If

        Else

            ebCiudad.DropDownList.ClearStructure()

        End If

        'ctrlError(sender, e)
    End Sub

    Private Sub ebCP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCP.Validating


        If (ebCP.Text.Trim = String.Empty) Then

            ebCP.Focus()
            Return

        End If


        If ebCP.Text <> "" AndAlso Not (ebCiudad.Value Is Nothing) AndAlso Not (ebEstado.Value Is Nothing) Then

            If (ebCiudad.Value < 0) OrElse (ebEstado.Value = String.Empty) Then

                MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
                ebCP.Text = ""
                e.Cancel = True


            Else

                'If Not (oClienteMgr.GetZipCode(ebEstado.Value, ebCiudad.Value, ebCP.Text)) Then
                If (CType(ebCP.Text, Integer) < rango1) Or (CType(ebCP.Text, Integer) > rango2) Then
                    MessageBox.Show("Código postal no corresponde a la ciudad. Código entre " & rango1 & " y " & rango2, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Me.ErrorProvider1.SetError(ebCP, "Entre " & rango1 & " y " & rango2)

                    e.Cancel = True
                Else
                    'Me.ErrorProvider1.SetError(ebCP, "")
                End If

            End If

        ElseIf ebCP.Text.Equals("") Then

            'Me.ErrorProvider1.SetError(ebCP, "Código Postal Requerido")
            e.Cancel = True

        End If

    End Sub

    Private Sub ebDomicilio_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDomicilio.Validating


        If (ebDomicilio.Text.Trim = String.Empty) Then
            MessageBox.Show("Teclee Domicilio.", "DPortenis Pro", MessageBoxButtons.OK)
            e.Cancel = True
            Return

        End If

    End Sub

    Private Sub ebColonia_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebColonia.Validating


        If (ebColonia.Text.Trim = String.Empty) Then
            MessageBox.Show("Seleccione colonia.", "DPortenis Pro", MessageBoxButtons.OK)
            e.Cancel = True
            Return

        End If

    End Sub

    Private Sub ebTelefono_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTelefono.Validating


        If (ebTelefono.Text.Trim = String.Empty) Then
            MessageBox.Show("Teclee el Télefono.", "DPortenis Pro", MessageBoxButtons.OK)
            e.Cancel = True
            Return

        End If
    End Sub

#End Region


    Private Sub frmClientesUpDateSAP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Refresh()

        'Inicializamos objeto
        InitializeObjects()

        'Llenamos el combo de estados
        FillComboEstados()

        FillGeneralData()

        Me.ebClienteID.Text = Me.CodigoAlterno
        Me.ebColonia.Text = Me.Colonia
        Me.ebCP.Text = Me.CP
        Me.ebDomicilio.Text = Me.Direccion
        Me.ebEmail.Text = Me.EMail
        Me.ebEstado.Value = Me.Estado
        ValidarEstado()
        Me.ebCiudad.Text = Me.Ciudad
        Validarciudad()
        Me.ebTelefono.Text = Me.Telefono




    End Sub

End Class
