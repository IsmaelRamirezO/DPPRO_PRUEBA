Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DportenisPro.DPTienda.ApplicationUnits.RevisionApartadosAU
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmRevisionApartados
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
    Friend WithEvents ccmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativoName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativoID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator8 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents gridArticulos As Janus.Windows.GridEX.GridEX
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator9 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator10 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents nbTotalAuditados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gridRevision As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents bntGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRevisionApartados))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.gridArticulos = New Janus.Windows.GridEX.GridEX()
        Me.gridRevision = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nbTotalAuditados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ccmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebResponsableID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursalID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursalName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAdministrativoName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebAdministrativoID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.nbFolio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator9 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator8 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAyudaTema2 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator10 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.bntGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridRevision, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.gridArticulos)
        Me.ExplorerBar1.Controls.Add(Me.gridRevision)
        Me.ExplorerBar1.Controls.Add(Me.Label12)
        Me.ExplorerBar1.Controls.Add(Me.nbTotalAuditados)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.Label11)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.ccmbFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableID)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableName)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursalID)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursalName)
        Me.ExplorerBar1.Controls.Add(Me.ebAdministrativoName)
        Me.ExplorerBar1.Controls.Add(Me.ebAdministrativoID)
        Me.ExplorerBar1.Controls.Add(Me.nbFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 50)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(528, 404)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'gridArticulos
        '
        Me.gridArticulos.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gridArticulos.AllowColumnDrag = False
        Me.gridArticulos.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gridArticulos.ColumnAutoResize = True
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridArticulos.DesignTimeLayout = GridEXLayout1
        Me.gridArticulos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridArticulos.Enabled = False
        Me.gridArticulos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridArticulos.GroupByBoxVisible = False
        Me.gridArticulos.Location = New System.Drawing.Point(552, 64)
        Me.gridArticulos.Name = "gridArticulos"
        Me.gridArticulos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.gridArticulos.Size = New System.Drawing.Size(48, 24)
        Me.gridArticulos.TabIndex = 8
        Me.gridArticulos.TabStop = False
        Me.gridArticulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gridRevision
        '
        Me.gridRevision.AllowAddNew = True
        Me.gridRevision.AllowDelete = True
        Me.gridRevision.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.gridRevision.ColumnInfo = resources.GetString("gridRevision.ColumnInfo")
        Me.gridRevision.Location = New System.Drawing.Point(16, 168)
        Me.gridRevision.Name = "gridRevision"
        Me.gridRevision.Rows.Count = 11
        Me.gridRevision.Rows.DefaultSize = 20
        Me.gridRevision.Size = New System.Drawing.Size(496, 144)
        Me.gridRevision.StyleInfo = resources.GetString("gridRevision.StyleInfo")
        Me.gridRevision.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(8, 344)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(192, 23)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Total de códigos auditados"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nbTotalAuditados
        '
        Me.nbTotalAuditados.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalAuditados.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalAuditados.BackColor = System.Drawing.Color.Ivory
        Me.nbTotalAuditados.Location = New System.Drawing.Point(208, 344)
        Me.nbTotalAuditados.Name = "nbTotalAuditados"
        Me.nbTotalAuditados.Size = New System.Drawing.Size(96, 23)
        Me.nbTotalAuditados.TabIndex = 32
        Me.nbTotalAuditados.TabStop = False
        Me.nbTotalAuditados.Text = "0"
        Me.nbTotalAuditados.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalAuditados.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbTotalAuditados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(440, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 23)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "ESC"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(472, 376)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 23)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Salir"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(16, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "F2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(152, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 23)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "F9"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(176, 376)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 23)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Guardar/Imprimir"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(40, 376)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Guardar"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 616)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 23)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "F2"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(304, 616)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 23)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "F9"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(328, 616)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 23)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Guardar/Imprimir"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ccmbFecha
        '
        Me.ccmbFecha.BackColor = System.Drawing.Color.Ivory
        '
        '
        '
        Me.ccmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbFecha.Location = New System.Drawing.Point(376, 24)
        Me.ccmbFecha.Name = "ccmbFecha"
        Me.ccmbFecha.ReadOnly = True
        Me.ccmbFecha.ShowDropDown = False
        Me.ccmbFecha.Size = New System.Drawing.Size(120, 23)
        Me.ccmbFecha.TabIndex = 9
        Me.ccmbFecha.TabStop = False
        Me.ccmbFecha.Value = New Date(2005, 7, 3, 0, 0, 0, 0)
        Me.ccmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(312, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Fecha:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ebResponsableID
        '
        Me.ebResponsableID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableID.ButtonImage = CType(resources.GetObject("ebResponsableID.ButtonImage"), System.Drawing.Image)
        Me.ebResponsableID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableID.Location = New System.Drawing.Point(144, 120)
        Me.ebResponsableID.Name = "ebResponsableID"
        Me.ebResponsableID.ReadOnly = True
        Me.ebResponsableID.Size = New System.Drawing.Size(75, 23)
        Me.ebResponsableID.TabIndex = 6
        Me.ebResponsableID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableName
        '
        Me.ebResponsableName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.BackColor = System.Drawing.Color.Ivory
        Me.ebResponsableName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebResponsableName.Location = New System.Drawing.Point(232, 120)
        Me.ebResponsableName.Name = "ebResponsableName"
        Me.ebResponsableName.ReadOnly = True
        Me.ebResponsableName.Size = New System.Drawing.Size(264, 23)
        Me.ebResponsableName.TabIndex = 7
        Me.ebResponsableName.TabStop = False
        Me.ebResponsableName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursalID
        '
        Me.ebSucursalID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursalID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursalID.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursalID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursalID.Location = New System.Drawing.Point(144, 56)
        Me.ebSucursalID.Name = "ebSucursalID"
        Me.ebSucursalID.ReadOnly = True
        Me.ebSucursalID.Size = New System.Drawing.Size(75, 23)
        Me.ebSucursalID.TabIndex = 2
        Me.ebSucursalID.TabStop = False
        Me.ebSucursalID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursalID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursalName
        '
        Me.ebSucursalName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursalName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursalName.BackColor = System.Drawing.Color.Ivory
        Me.ebSucursalName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursalName.Location = New System.Drawing.Point(232, 56)
        Me.ebSucursalName.Name = "ebSucursalName"
        Me.ebSucursalName.ReadOnly = True
        Me.ebSucursalName.Size = New System.Drawing.Size(264, 23)
        Me.ebSucursalName.TabIndex = 3
        Me.ebSucursalName.TabStop = False
        Me.ebSucursalName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursalName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativoName
        '
        Me.ebAdministrativoName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoName.BackColor = System.Drawing.Color.Ivory
        Me.ebAdministrativoName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativoName.Location = New System.Drawing.Point(232, 88)
        Me.ebAdministrativoName.Name = "ebAdministrativoName"
        Me.ebAdministrativoName.ReadOnly = True
        Me.ebAdministrativoName.Size = New System.Drawing.Size(264, 23)
        Me.ebAdministrativoName.TabIndex = 5
        Me.ebAdministrativoName.TabStop = False
        Me.ebAdministrativoName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdministrativoName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativoID
        '
        Me.ebAdministrativoID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoID.BackColor = System.Drawing.Color.Ivory
        Me.ebAdministrativoID.ButtonImage = CType(resources.GetObject("ebAdministrativoID.ButtonImage"), System.Drawing.Image)
        Me.ebAdministrativoID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativoID.Location = New System.Drawing.Point(144, 88)
        Me.ebAdministrativoID.Name = "ebAdministrativoID"
        Me.ebAdministrativoID.ReadOnly = True
        Me.ebAdministrativoID.Size = New System.Drawing.Size(75, 23)
        Me.ebAdministrativoID.TabIndex = 4
        Me.ebAdministrativoID.TabStop = False
        Me.ebAdministrativoID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdministrativoID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFolio
        '
        Me.nbFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolio.ButtonImage = CType(resources.GetObject("nbFolio.ButtonImage"), System.Drawing.Image)
        Me.nbFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolio.Location = New System.Drawing.Point(144, 24)
        Me.nbFolio.Name = "nbFolio"
        Me.nbFolio.Size = New System.Drawing.Size(75, 23)
        Me.nbFolio.TabIndex = 1
        Me.nbFolio.Text = "0"
        Me.nbFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFolio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nbFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(0, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Responsable Suc."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(0, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Administrativo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(0, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(40, 616)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 23)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Guardar"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAbrir, Me.menuSalir, Me.menuGuardar, Me.menuAyuda, Me.menuAyudaTema, Me.menuNuevo})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("ae5755ee-fa53-4c3d-b042-9da2063a0c4a")
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
        Me.UiCommandBar1.Size = New System.Drawing.Size(528, 22)
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
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir2, Me.Separator5, Me.menuNuevo1, Me.Separator9, Me.Separator6, Me.Separator7, Me.menuGuardar2, Me.Separator8, Me.menuAyudaTema2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(277, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        Me.UiCommandBar2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator9
        '
        Me.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator9.Key = "Separator"
        Me.Separator9.Name = "Separator9"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuGuardar2
        '
        Me.menuGuardar2.Key = "menuGuardar"
        Me.menuGuardar2.Name = "menuGuardar2"
        '
        'Separator8
        '
        Me.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator8.Key = "Separator"
        Me.Separator8.Name = "Separator8"
        '
        'menuAyudaTema2
        '
        Me.menuAyudaTema2.Key = "menuAyudaTema"
        Me.menuAyudaTema2.Name = "menuAyudaTema2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator1, Me.menuNuevo2, Me.Separator10, Me.Separator2, Me.Separator3, Me.menuGuardar1, Me.Separator4, Me.menuSalir1})
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
        'menuNuevo2
        '
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator10
        '
        Me.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator10.Key = "Separator"
        Me.Separator10.Name = "Separator10"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuGuardar1
        '
        Me.menuGuardar1.Key = "menuGuardar"
        Me.menuGuardar1.Name = "menuGuardar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuSalir1
        '
        Me.menuSalir1.Key = "menuSalir"
        Me.menuSalir1.Name = "menuSalir1"
        '
        'menuAbrir
        '
        Me.menuAbrir.Image = CType(resources.GetObject("menuAbrir.Image"), System.Drawing.Image)
        Me.menuAbrir.Key = "menuAbrir"
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Text = "A&brir"
        '
        'menuSalir
        '
        Me.menuSalir.Image = CType(resources.GetObject("menuSalir.Image"), System.Drawing.Image)
        Me.menuSalir.Key = "menuSalir"
        Me.menuSalir.Name = "menuSalir"
        Me.menuSalir.Text = "&Salir"
        '
        'menuGuardar
        '
        Me.menuGuardar.Image = CType(resources.GetObject("menuGuardar.Image"), System.Drawing.Image)
        Me.menuGuardar.Key = "menuGuardar"
        Me.menuGuardar.Name = "menuGuardar"
        Me.menuGuardar.Text = "&Guardar"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "A&yuda"
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
        'menuNuevo
        '
        Me.menuNuevo.Image = CType(resources.GetObject("menuNuevo.Image"), System.Drawing.Image)
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "&Nuevo"
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
        Me.TopRebar1.Size = New System.Drawing.Size(528, 50)
        '
        'bntGuardar
        '
        Me.bntGuardar.Location = New System.Drawing.Point(15, 15)
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(136, 23)
        Me.bntGuardar.TabIndex = 12
        Me.bntGuardar.Text = "Guardar"
        Me.bntGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'frmRevisionApartados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 454)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRevisionApartados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revisión Apartados"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridRevision, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region "Variables"

    Private bolContraseña As Boolean = False

    Private oVendedor As Vendedor

    Private oVendedoresMgr As CatalogoVendedoresManager

    Private oAlmacen As Almacen
    Private oAlmacenesMgr As CatalogoAlmacenesManager


    Private dsRevision As DataSet

    Private bolGuardar As Boolean = True

    Public AdmnistrativoID As String
    Public AdmnistrativoName As String

    Private oArticulo As Articulo
    Private oArticulosMgr As CatalogoArticuloManager

    Private oRevisionApartadosMgr As RevisionApartadosManager
    Private oRevisionApartados As RevisionApartados

    Private isRowDeleted As Boolean = False

    Private isFormLoad As Boolean = False


#End Region

    Private Sub frmRevisionApartados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ebAdministrativoID.Text = Me.AdmnistrativoID
        Me.ebAdministrativoName.Text = Me.AdmnistrativoName

        '''Sucursal
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)
        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then
            Me.ebSucursalID.Text = oAlmacen.ID
            Me.ebSucursalName.Text = oAlmacen.Descripcion
        End If

        '''Sucursal
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        oArticulosMgr = New CatalogoArticuloManager(oAppContext)

        sm_Nuevo()

        isFormLoad = True

    End Sub

    Private Sub Sm_Buscar(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (Me.ebResponsableID.Text.Trim = String.Empty)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog

            oOpenRecordDlg.CurrentView = New CatalogoVendedoresOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oVendedor = Nothing
                oVendedor = oVendedoresMgr.Load(oOpenRecordDlg.Record.Item("CodVendedor"))

                Me.ebResponsableID.Text = oVendedor.ID
                Me.ebResponsableName.Text = oVendedor.Nombre

                If Not InputBox("Teclee clave de responsable", "Contraseña", "").ToUpper = "KAROLA" Then

                    MessageBox.Show("Contraseña incorrecta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Me.ebResponsableID.Text = String.Empty
                    Me.ebResponsableID.Focus()
                    Me.ebResponsableName.Text = String.Empty

                End If


            End If

        Else

            On Error Resume Next

            oVendedor = Nothing

            oVendedor = oVendedoresMgr.Load(Me.ebResponsableID.Text.Trim)

            If oVendedor.IsDirty Then

                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ebResponsableID.Focus()
                Me.ebResponsableID.SelectAll()

            Else


                Me.ebResponsableID.Text = oVendedor.ID
                Me.ebResponsableName.Text = oVendedor.Nombre

                If Not InputBox("Teclee clave de responsable", "Contraseña", "").ToUpper = "KAROLA" Then

                    MessageBox.Show("Contraseña incorrecta", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Me.ebResponsableID.Text = String.Empty
                    Me.ebResponsableID.Focus()
                    Me.ebResponsableName.Text = String.Empty

                End If

            End If

        End If

    End Sub

    Private Sub ebResponsableID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebResponsableID.ButtonClick
        Sm_Buscar(True)
    End Sub

    Private Sub ebResponsableID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebResponsableID.KeyDown

        Select Case e.KeyCode

            Case e.Alt And Keys.S

                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.RevisionApartados") = True Then

                    ebResponsableID.Text = oAppContext.Security.CurrentUser.SessionLoginName()
                    ebResponsableName.Text = oAppContext.Security.CurrentUser.Name()

                    oAppContext.Security.CloseImpersonatedSession()

                Else

                    ebResponsableID.Text = String.Empty
                    ebResponsableName.Text = String.Empty

                End If

            Case Keys.Enter

                If Not Me.ebResponsableID.Text <> String.Empty Then

                    oAppContext.Security.CloseImpersonatedSession()
                    If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Auditoria.Auditoria", "DportenisPro.DPTienda.Auditoria.Auditoria.RevisionApartados") = True Then

                        ebResponsableID.Text = oAppContext.Security.CurrentUser.SessionLoginName()
                        ebResponsableName.Text = oAppContext.Security.CurrentUser.Name()

                        oAppContext.Security.CloseImpersonatedSession()

                    Else

                        ebResponsableID.Text = String.Empty
                        ebResponsableName.Text = String.Empty

                    End If

                End If

                SendKeys.Send("{TAB}")

        End Select

    End Sub



    Private Sub smGuardar(Optional ByVal Imprimir As Boolean = True)

        Try
            If Not ((Me.ebResponsableID.Text = String.Empty) Or (Me.ebResponsableName.Text = String.Empty)) Then

                oRevisionApartados.Administrativo = Me.ebAdministrativoID.Text
                oRevisionApartados.Responsable = Me.ebResponsableID.Text

                For Each oRow As DataRow In Me.dsRevision.Tables(0).Rows
                    If IsDBNull(oRow("CodArticulo")) Then
                        oRow.Delete()
                    End If
                Next
                Me.dsRevision.AcceptChanges()

                oRevisionApartados.Detalle = Me.dsRevision
                oRevisionApartados.Sucursal = Me.ebSucursalID.Text

                Me.nbFolio.Value = oRevisionApartadosMgr.Insert(oRevisionApartados)
                Me.oRevisionApartados.Folio = Me.nbFolio.Value
                bolGuardar = False
                Me.ebResponsableID.Enabled = False
                Me.gridRevision.Enabled = False

                MessageBox.Show("Revisión Guardada", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If Imprimir Then
                    ActionPreview()
                End If

            Else

                MessageBox.Show("Seleccione un Responsable", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ebResponsableID.Focus()

            End If

            sm_Nuevo()


        Catch ex As Exception

            Throw ex

        End Try
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "menuGuardar"

                If bolGuardar Then
                    Me.Cursor = Cursors.WaitCursor
                    smGuardar()
                    Me.Cursor = Cursors.Default

                Else

                    MessageBox.Show("Ésta revisión ya fue guardada", "DPTienda", MessageBoxButtons.OK)


                End If

            Case "menuAbrir"
                Sm_Buscar(True)


            Case "menuSalir"
                Me.Close()

            Case "menuNuevo"
                sm_Nuevo()

        End Select
    End Sub


    Private Sub Sm_Abrir(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)
        Try
            If ((Vpa_bolOpenRecordDialog = True) Or (Me.nbFolio.Value = 0)) Then

                Dim oOpenRecordDlg As New OpenRecordDialog


                oOpenRecordDlg.CurrentView = New RevisionApartadosOpenRecordDialogView

                oOpenRecordDlg.ShowDialog()

                If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then


                    Me.oRevisionApartados = Me.oRevisionApartadosMgr.SelectByID(oOpenRecordDlg.Record.Item("FolioMovimiento"))

                    If Not oRevisionApartados.IsDirty Then
                        'MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.sm_Nuevo()
                    Else

                        Me.ebAdministrativoID.Text = oRevisionApartados.Administrativo

                        'oVendedor = Nothing
                        'oVendedor = oVendedoresMgr.Load(Me.ebAdministrativoID.Text)

                        'Me.ebAdministrativoID.Text = oVendedor.ID
                        'Me.ebAdministrativoName.Text = oVendedor.Nombre

                        Me.ebResponsableID.Text = oRevisionApartados.Responsable

                        'oVendedor = Nothing
                        'oVendedor = oVendedoresMgr.Load(Me.ebResponsableID.Text)

                        'Me.ebResponsableID.Text = oVendedor.ID
                        'Me.ebResponsableName.Text = oVendedor.Nombre

                        Me.ebSucursalID.Text = oRevisionApartados.Sucursal

                        '''Sucursal
                        oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

                        oAlmacen = oAlmacenesMgr.Load(Me.ebSucursalID.Text)

                        If Not oAlmacen Is Nothing Then

                            Me.ebSucursalID.Text = oAlmacen.ID
                            Me.ebSucursalName.Text = oAlmacen.Descripcion

                        Else

                            Me.ebSucursalID.Text = oRevisionApartados.Sucursal

                        End If
                        '''Sucursal

                        Me.nbFolio.Value = oRevisionApartados.Folio
                        Me.dsRevision = Me.oRevisionApartados.Detalle.Copy
                        Me.dsRevision.AcceptChanges()
                        Me.gridRevision.DataSource = dsRevision
                        Me.gridRevision.DataMember = dsRevision.Tables(0).TableName
                        Me.gridRevision.Enabled = False
                        Me.Formatear()
                        Me.nbTotalAuditados.Value = dsRevision.Tables(0).Rows.Count
                        Me.ebResponsableID.Enabled = False
                        bolGuardar = False

                    End If

                End If

            Else


                Me.oRevisionApartados = Me.oRevisionApartadosMgr.SelectByID(Me.nbFolio.Value)

                If Not oRevisionApartados.IsDirty Then

                    MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'Me.nbFolio.Value = oRevisionApartadosMgr.SelectFolio
                    Me.sm_Nuevo()

                Else

                    Me.ebAdministrativoID.Text = oRevisionApartados.Administrativo

                    'oVendedor = Nothing
                    'oVendedor = oVendedoresMgr.Load(Me.ebAdministrativoID.Text)

                    'Me.ebAdministrativoID.Text = oVendedor.ID
                    'Me.ebAdministrativoName.Text = oVendedor.Nombre

                    Me.ebResponsableID.Text = oRevisionApartados.Responsable

                    'oVendedor = Nothing
                    'oVendedor = oVendedoresMgr.Load(Me.ebResponsableID.Text)

                    'Me.ebResponsableID.Text = oVendedor.ID
                    'Me.ebResponsableName.Text = oVendedor.Nombre

                    Me.ebSucursalID.Text = oRevisionApartados.Sucursal

                    '''Sucursal
                    oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

                    oAlmacen = oAlmacenesMgr.Load(Me.ebSucursalID.Text)

                    If Not oAlmacen Is Nothing Then

                        Me.ebSucursalID.Text = oAlmacen.ID
                        Me.ebSucursalName.Text = oAlmacen.Descripcion

                    Else

                        Me.ebSucursalID.Text = oRevisionApartados.Sucursal

                    End If
                    '''Sucursal

                    Me.nbFolio.Value = oRevisionApartados.Folio

                    Me.dsRevision = Me.oRevisionApartados.Detalle.Copy
                    Me.dsRevision.AcceptChanges()
                    Me.gridRevision.DataSource = dsRevision
                    Me.gridRevision.DataMember = dsRevision.Tables(0).TableName
                    Me.gridRevision.Enabled = False
                    Me.Formatear()
                    Me.nbTotalAuditados.Value = dsRevision.Tables(0).Rows.Count
                    Me.ebResponsableID.Enabled = False
                    bolGuardar = False

                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub nbFolio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbFolio.ButtonClick
        Me.Sm_Abrir(True)
    End Sub

    Private Sub sm_Nuevo()
        isFormLoad = False

        oRevisionApartadosMgr = New RevisionApartadosManager(oAppContext)
        oRevisionApartados = New RevisionApartados

        Me.dsRevision = oRevisionApartadosMgr.GetAll(True)
        Me.dsRevision.Clear()
        Me.dsRevision.Tables(0).Columns("Faltantes").DefaultValue = 0
        Me.dsRevision.Tables(0).Columns("Vencidos").DefaultValue = 0
        Me.dsRevision.Tables(0).Columns("NoRegistrados").DefaultValue = 0
        Me.dsRevision.Tables(0).Columns("Observaciones").DefaultValue = String.Empty
        Me.dsRevision.Tables(0).Columns("CodArticulo").DefaultValue = String.Empty
        Me.dsRevision.AcceptChanges()
        Me.gridRevision.DataSource = dsRevision
        Me.gridRevision.DataMember = dsRevision.Tables(0).TableName
        Me.nbFolio.Value = oRevisionApartadosMgr.SelectFolio

        Me.gridRevision.Enabled = True

        Me.ebResponsableName.Text = String.Empty
        Me.ebResponsableID.Text = String.Empty
        bolGuardar = True
        Me.nbFolio.Focus()
        Me.nbFolio.Value = oRevisionApartadosMgr.SelectFolio
        Me.ebResponsableID.Enabled = True
        Me.ebResponsableID.Enabled = True
        Me.nbTotalAuditados.Value = 0

        Formatear()
        isFormLoad = True
    End Sub

    Private Sub nbFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolio.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.Sm_Abrir(False)

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            Me.Sm_Abrir(True)

        End If
    End Sub

    Private Sub frmRevisionApartados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F2 Then

            If bolGuardar Then

                Me.Cursor = Cursors.WaitCursor
                smGuardar(False)
                Me.Cursor = Cursors.Default

            Else

                MessageBox.Show("Ésta revisión ya fue guardada", "DPTienda", MessageBoxButtons.OK)

            End If

        ElseIf e.KeyCode = Keys.F9 Then

            If bolGuardar Then

                Me.Cursor = Cursors.WaitCursor
                smGuardar(True)
                Me.Cursor = Cursors.Default

            Else

                MessageBox.Show("Ésta revisión ya fue guardada", "DPTienda", MessageBoxButtons.OK)

            End If

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If
    End Sub

    Public Sub ActionPreview()
        Try


            Dim oARReporte As New rptRevisionApartados(Me.oRevisionApartados, ebAdministrativoName.Text, ebResponsableName.Text)
            Dim oReportViewer As New ReportViewerForm


            oARReporte.Document.Name = "Revision Apartados"
            oARReporte.Run()

            oReportViewer.Report = oARReporte
            oReportViewer.Show()


            Try

                'oARReporte.Document.Print(True, True)

            Catch ex As Exception

                Throw ex

            End Try

        Catch ex As Exception


            Throw ex


        End Try

    End Sub

    'Private Sub gridRevision_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles gridRevision.AfterEdit

    '    If Me.gridRevision.Cols(e.Col).Name = "CodArticulo" Then


    '        Dim CodArticulo As String = Me.gridRevision(e.Row, "CodArticulo")

    '        If Not CodArticulo = String.Empty Then

    '            Dim custDV As DataView = New DataView(Me.dsRevision.Tables(0), _
    '                                                                "CodArticulo like '" & CodArticulo & "'", _
    '                                                                "CodArticulo", _
    '                                                                DataViewRowState.CurrentRows)



    '            If Not custDV.Count > 0 Then

    '                oArticulo = oArticulosMgr.Load(CodArticulo)

    '                If oArticulo Is Nothing Then

    '                    MessageBox.Show("El código no existe, Código con problemas", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                    If Me.gridRevision.Row > 0 Then

    '                        Me.gridRevision.Rows.Remove(Me.gridRevision.Row)

    '                    End If

    '                End If

    '            Else

    '                MessageBox.Show("El código ya fue registrado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                If Me.gridRevision.Row > 0 Then

    '                    Me.gridRevision.Rows.Remove(Me.gridRevision.Row)

    '                End If

    '            End If

    '        Else

    '            If Me.gridRevision.Row > 0 Then

    '                Me.gridRevision.Rows.Remove(Me.gridRevision.Row)

    '            End If

    '        End If


    '    End If

    '    Me.gridRevision.Focus()

    'End Sub

    Private Function LoadSearchArticulo() As String

        Dim cArticulo As String
        Dim oOpenRecordDlg As New OpenRecordDialog2
        oOpenRecordDlg.CurrentView = New CatalogoArticulosOpenRecordDialogView2

        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            If oOpenRecordDlg.pbCodigo = String.Empty Then

                cArticulo = oOpenRecordDlg.Record.Item("Código")

            Else

                cArticulo = oOpenRecordDlg.pbCodigo

            End If

        Else

            cArticulo = ""

        End If

        oOpenRecordDlg.Dispose()
        oOpenRecordDlg = Nothing

        Return cArticulo

    End Function

    Private Sub Formatear()
        ' TODO: Add method body here.
        Me.gridRevision.Cols("Folio").Visible = False
        Me.gridRevision.Cols("Sucursal").Visible = False
        Me.gridRevision.Cols("Administrativo").Visible = False
        Me.gridRevision.Cols("Responsable").Visible = False
        Me.gridRevision.Cols("Fecha").Visible = False
        Me.gridRevision.Cols("Usuario").Visible = False
        Me.gridRevision.Cols("StatusRegistro").Visible = False
        Me.gridRevision.Cols("FolioMovimiento").Visible = False

        Me.gridRevision.Cols("CodArticulo").Width = 149
        Me.gridRevision.Cols("Faltantes").Width = 68
        Me.gridRevision.Cols("Vencidos").Width = 67
        Me.gridRevision.Cols("NoRegistrados").Width = 107
        Me.gridRevision.Cols("Observaciones").Width = 102

    End Sub

    Private Sub gridRevision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridRevision.KeyDown
        Try

            If e.Alt And e.KeyCode = Keys.S Then

                If Me.gridRevision.Cols(Me.gridRevision.Col).Name = "CodArticulo" Then

                    Dim CodArticulo As String = LoadSearchArticulo()

                    'Dim custDV As DataView = New DataView(Me.dsRevision.Tables(0), _
                    '                                            "CodArticulo like '" & CodArticulo & "'", _
                    '                                            "CodArticulo", _
                    '                                            DataViewRowState.CurrentRows)




                    'If Not custDV.Count > 0 Then

                    gridRevision(gridRevision.Row, Me.gridRevision.Col) = CodArticulo

                    'Else

                    '    MessageBox.Show("El código ya fue registrado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'End If


                End If


            ElseIf e.KeyCode = Keys.Delete Then

                If Me.gridRevision.Row > 0 Then
                    isRowDeleted = True
                    Me.gridRevision.Rows.Remove(Me.gridRevision.Row)

                End If



            End If

        Catch ex As Exception

            Throw ex

        End Try
    End Sub

    Private Sub gridRevision_BeforeRowColChange(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles gridRevision.BeforeRowColChange

        If isRowDeleted Then
            isRowDeleted = False
            Exit Sub

        End If

        If isFormLoad = False Then

            Exit Sub

        End If

        If e.OldRange.r1 = e.NewRange.r1 Then


            If Me.gridRevision.Cols(e.OldRange.c1).Name = "CodArticulo" Then

                Dim CodArticulo As String = Me.gridRevision(e.OldRange.r1, "CodArticulo")

                If Not CodArticulo = String.Empty Then

                    For Each row As C1.Win.C1FlexGrid.Row In Me.gridRevision.Rows

                        If Not row("CodArticulo") Is Nothing Then
                            If CodArticulo.Trim = row("CodArticulo").trim And Not (row.Index = e.OldRange.r1) Then
                                MessageBox.Show("El código ya fue registrado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.gridRevision.Focus()
                                Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If

                    Next

                    'Dim custDV As DataView = New DataView(Me.dsRevision.Tables(0), _
                    '                                                                                   "CodArticulo like '" & CodArticulo & "'", _
                    '                                                                                   "CodArticulo", _
                    '                                                                                   DataViewRowState.CurrentRows)

                    'If Not custDV.Count > 0 Then

                    If Not VerificaCodigo(CodArticulo) Then

                        MessageBox.Show("El código no existe, Código con problemas", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.gridRevision.Focus()
                        Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)
                        e.Cancel = True


                    End If

                    'Else

                    '    'Ya existe
                    '    MessageBox.Show("El código ya fue registrado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    e.Cancel = True
                    '    Me.gridRevision.Focus()
                    '    Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)

                    'End If

                Else

                    MessageBox.Show("Teclee código de articulo", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    e.Cancel = True
                    Me.gridRevision.Focus()
                    Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)

                End If

            End If

        Else

            If e.OldRange.r1 > 0 Then

                Dim CodArticulo As String = Me.gridRevision(e.OldRange.r1, "CodArticulo")

                'Cambiamos de Fila */ Validamos Fila Completa
                If CodArticulo = String.Empty Then
                    Exit Sub

                End If

                For Each row As C1.Win.C1FlexGrid.Row In Me.gridRevision.Rows
                    If Not row("CodArticulo") Is Nothing Then
                        If CodArticulo.Trim = row("CodArticulo").trim And Not (row.Index = e.OldRange.r1) Then
                            MessageBox.Show("El código ya fue registrado", "DPtienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.gridRevision.Focus()
                            Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Next


                If Not EntireRowValidate(e.OldRange.r1) Then

                    e.Cancel = True
                    Me.gridRevision.Focus()
                    Me.gridRevision.Select(e.OldRange.r1, e.OldRange.c1)

                End If
            End If

        End If

    End Sub

    Private Function VerificaCodigo(ByVal strArticulo As String) As Boolean

        Dim oResult As Boolean = False

        If strArticulo <> String.Empty Then


            oArticulo = oArticulosMgr.Load(strArticulo)

            If oArticulo Is Nothing Then

                'MsgBox("El Código de Artículo No Existe", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Toma de Inventario")
                oResult = False
            Else

                Return True

            End If


        End If

        Return oResult

    End Function

    Private Function EntireRowValidate(ByVal intRow As Integer) As Boolean

        If Not VerificaCodigo(Me.gridRevision(intRow, "CodArticulo")) Then

            Return False

        End If

        If Me.gridRevision(intRow, "Faltantes") = 0 And Me.gridRevision(intRow, "Vencidos") = 0 _
        And Me.gridRevision(intRow, "NoRegistrados") = 0 Then

            MessageBox.Show("Teclee Faltantes, Vencidos o No Registrados", "DPTienda", MessageBoxButtons.OK)

            Return False

        End If

        Return True

    End Function


  
End Class
