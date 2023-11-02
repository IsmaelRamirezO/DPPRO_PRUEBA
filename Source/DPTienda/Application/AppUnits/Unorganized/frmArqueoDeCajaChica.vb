Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmArqueoDeCajaChica
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
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nbFaltante As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbSobrante As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbTotalConteo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gridFondoCaja As Janus.Windows.GridEX.GridEX
    Friend WithEvents nbTotalDocumentos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gridDocumentos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebObservaciones As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ccmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebadministrativoName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebadministrativoID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbCajaChica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArqueoDeCajaChica))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFaltante = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbSobrante = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbCajaChica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbTotalConteo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gridFondoCaja = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbTotalDocumentos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gridDocumentos = New Janus.Windows.GridEX.GridEX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebObservaciones = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ccmbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebResponsableID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebResponsableName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursalID = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebSucursalName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebadministrativoName = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ebadministrativoID = New Janus.Windows.GridEX.EditControls.EditBox()
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
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gridFondoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gridDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExplorerBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox3)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox2)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebObservaciones)
        Me.ExplorerBar1.Controls.Add(Me.ccmbFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableID)
        Me.ExplorerBar1.Controls.Add(Me.ebResponsableName)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursalID)
        Me.ExplorerBar1.Controls.Add(Me.ebSucursalName)
        Me.ExplorerBar1.Controls.Add(Me.ebadministrativoName)
        Me.ExplorerBar1.Controls.Add(Me.ebadministrativoID)
        Me.ExplorerBar1.Controls.Add(Me.nbFolio)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.Label22)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 26)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(760, 841)
        Me.ExplorerBar1.TabIndex = 1
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(16, 584)
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
        Me.Label20.Location = New System.Drawing.Point(232, 584)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 23)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "F9"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(256, 584)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 23)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Guardar/Imprimir"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(568, 582)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(136, 28)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.nbFaltante)
        Me.UiGroupBox3.Controls.Add(Me.nbSobrante)
        Me.UiGroupBox3.Controls.Add(Me.nbCajaChica)
        Me.UiGroupBox3.Controls.Add(Me.nbTotalConteo)
        Me.UiGroupBox3.Controls.Add(Me.Label15)
        Me.UiGroupBox3.Controls.Add(Me.Label16)
        Me.UiGroupBox3.Controls.Add(Me.Label17)
        Me.UiGroupBox3.Controls.Add(Me.Label18)
        Me.UiGroupBox3.Controls.Add(Me.gridFondoCaja)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(432, 144)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(272, 432)
        Me.UiGroupBox3.TabIndex = 18
        Me.UiGroupBox3.Text = "Fondo de Caja"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'nbFaltante
        '
        Me.nbFaltante.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFaltante.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFaltante.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbFaltante.Location = New System.Drawing.Point(120, 392)
        Me.nbFaltante.Name = "nbFaltante"
        Me.nbFaltante.ReadOnly = True
        Me.nbFaltante.Size = New System.Drawing.Size(128, 23)
        Me.nbFaltante.TabIndex = 4
        Me.nbFaltante.TabStop = False
        Me.nbFaltante.Text = "$0.00"
        Me.nbFaltante.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFaltante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbSobrante
        '
        Me.nbSobrante.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbSobrante.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbSobrante.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbSobrante.Location = New System.Drawing.Point(120, 360)
        Me.nbSobrante.Name = "nbSobrante"
        Me.nbSobrante.ReadOnly = True
        Me.nbSobrante.Size = New System.Drawing.Size(128, 23)
        Me.nbSobrante.TabIndex = 3
        Me.nbSobrante.TabStop = False
        Me.nbSobrante.Text = "$0.00"
        Me.nbSobrante.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbSobrante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbCajaChica
        '
        Me.nbCajaChica.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbCajaChica.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbCajaChica.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbCajaChica.Location = New System.Drawing.Point(120, 328)
        Me.nbCajaChica.Name = "nbCajaChica"
        Me.nbCajaChica.Size = New System.Drawing.Size(128, 23)
        Me.nbCajaChica.TabIndex = 2
        Me.nbCajaChica.TabStop = False
        Me.nbCajaChica.Text = "$0.00"
        Me.nbCajaChica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbCajaChica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalConteo
        '
        Me.nbTotalConteo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalConteo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalConteo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbTotalConteo.Location = New System.Drawing.Point(120, 296)
        Me.nbTotalConteo.Name = "nbTotalConteo"
        Me.nbTotalConteo.ReadOnly = True
        Me.nbTotalConteo.Size = New System.Drawing.Size(128, 23)
        Me.nbTotalConteo.TabIndex = 1
        Me.nbTotalConteo.TabStop = False
        Me.nbTotalConteo.Text = "$0.00"
        Me.nbTotalConteo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalConteo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 392)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Faltante:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 360)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Sobrante:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 328)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Caja Chica:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 296)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 23)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Total Conteo:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridFondoCaja
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridFondoCaja.DesignTimeLayout = GridEXLayout1
        Me.gridFondoCaja.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridFondoCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridFondoCaja.GroupByBoxVisible = False
        Me.gridFondoCaja.Location = New System.Drawing.Point(8, 24)
        Me.gridFondoCaja.Name = "gridFondoCaja"
        Me.gridFondoCaja.Size = New System.Drawing.Size(256, 264)
        Me.gridFondoCaja.TabIndex = 0
        Me.gridFondoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.nbTotalDocumentos)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.gridDocumentos)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(16, 144)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(376, 432)
        Me.UiGroupBox2.TabIndex = 17
        Me.UiGroupBox2.Text = "Documentos"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'nbTotalDocumentos
        '
        Me.nbTotalDocumentos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalDocumentos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalDocumentos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbTotalDocumentos.Location = New System.Drawing.Point(240, 296)
        Me.nbTotalDocumentos.Name = "nbTotalDocumentos"
        Me.nbTotalDocumentos.ReadOnly = True
        Me.nbTotalDocumentos.Size = New System.Drawing.Size(128, 23)
        Me.nbTotalDocumentos.TabIndex = 1
        Me.nbTotalDocumentos.TabStop = False
        Me.nbTotalDocumentos.Text = "$0.00"
        Me.nbTotalDocumentos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalDocumentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(136, 296)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Total:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridDocumentos
        '
        Me.gridDocumentos.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gridDocumentos.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.gridDocumentos.DesignTimeLayout = GridEXLayout2
        Me.gridDocumentos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDocumentos.GroupByBoxVisible = False
        Me.gridDocumentos.Location = New System.Drawing.Point(8, 24)
        Me.gridDocumentos.Name = "gridDocumentos"
        Me.gridDocumentos.Size = New System.Drawing.Size(360, 264)
        Me.gridDocumentos.TabIndex = 0
        Me.gridDocumentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(512, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Observaciones:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebObservaciones
        '
        Me.ebObservaciones.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebObservaciones.Location = New System.Drawing.Point(512, 40)
        Me.ebObservaciones.MaxLength = 200
        Me.ebObservaciones.Multiline = True
        Me.ebObservaciones.Name = "ebObservaciones"
        Me.ebObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ebObservaciones.Size = New System.Drawing.Size(192, 96)
        Me.ebObservaciones.TabIndex = 8
        Me.ebObservaciones.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ccmbFecha
        '
        '
        '
        '
        Me.ccmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ccmbFecha.Location = New System.Drawing.Point(376, 16)
        Me.ccmbFecha.Name = "ccmbFecha"
        Me.ccmbFecha.ShowDropDown = False
        Me.ccmbFecha.Size = New System.Drawing.Size(112, 23)
        Me.ccmbFecha.TabIndex = 13
        Me.ccmbFecha.TabStop = False
        Me.ccmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(312, 16)
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
        Me.ebResponsableID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebResponsableID.Location = New System.Drawing.Point(144, 112)
        Me.ebResponsableID.Name = "ebResponsableID"
        Me.ebResponsableID.Size = New System.Drawing.Size(75, 23)
        Me.ebResponsableID.TabIndex = 6
        Me.ebResponsableID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebResponsableName
        '
        Me.ebResponsableName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebResponsableName.Location = New System.Drawing.Point(232, 112)
        Me.ebResponsableName.Name = "ebResponsableName"
        Me.ebResponsableName.ReadOnly = True
        Me.ebResponsableName.Size = New System.Drawing.Size(256, 23)
        Me.ebResponsableName.TabIndex = 7
        Me.ebResponsableName.TabStop = False
        Me.ebResponsableName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebResponsableName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSucursalID
        '
        Me.ebSucursalID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebSucursalID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebSucursalID.Location = New System.Drawing.Point(144, 48)
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
        Me.ebSucursalName.Location = New System.Drawing.Point(232, 48)
        Me.ebSucursalName.Name = "ebSucursalName"
        Me.ebSucursalName.ReadOnly = True
        Me.ebSucursalName.Size = New System.Drawing.Size(256, 23)
        Me.ebSucursalName.TabIndex = 3
        Me.ebSucursalName.TabStop = False
        Me.ebSucursalName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursalName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebadministrativoName
        '
        Me.ebadministrativoName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebadministrativoName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebadministrativoName.Location = New System.Drawing.Point(232, 80)
        Me.ebadministrativoName.Name = "ebadministrativoName"
        Me.ebadministrativoName.ReadOnly = True
        Me.ebadministrativoName.Size = New System.Drawing.Size(256, 23)
        Me.ebadministrativoName.TabIndex = 5
        Me.ebadministrativoName.TabStop = False
        Me.ebadministrativoName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebadministrativoName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebadministrativoID
        '
        Me.ebadministrativoID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebadministrativoID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebadministrativoID.ButtonImage = CType(resources.GetObject("ebadministrativoID.ButtonImage"), System.Drawing.Image)
        Me.ebadministrativoID.Location = New System.Drawing.Point(144, 80)
        Me.ebadministrativoID.Name = "ebadministrativoID"
        Me.ebadministrativoID.ReadOnly = True
        Me.ebadministrativoID.Size = New System.Drawing.Size(75, 23)
        Me.ebadministrativoID.TabIndex = 4
        Me.ebadministrativoID.TabStop = False
        Me.ebadministrativoID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebadministrativoID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFolio
        '
        Me.nbFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFolio.ButtonImage = CType(resources.GetObject("nbFolio.ButtonImage"), System.Drawing.Image)
        Me.nbFolio.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.nbFolio.Location = New System.Drawing.Point(144, 16)
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
        Me.Label4.Location = New System.Drawing.Point(0, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Responsable Suc."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(0, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Administrativo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(0, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folio:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(40, 584)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 23)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Guardar"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.AllowMerge = False
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAbrir, Me.menuSalir, Me.menuNuevo, Me.menuImprimir, Me.menuGuardar})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("b77b4994-9af0-492e-9620-c5ded9797fd2")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowQuickCustomizeMenu = False
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
        Me.UiCommandManager1.UseThemes = False
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
        Me.UiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.AllowMerge = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1})
        Me.UiCommandBar1.FloatingLocation = New System.Drawing.Point(39, 231)
        Me.UiCommandBar1.FloatingSize = New System.Drawing.Size(63, 22)
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(3, 26)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.Size = New System.Drawing.Size(54, 28)
        Me.UiCommandBar1.Text = "CommandBar1"
        Me.UiCommandBar1.UseThemes = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        Me.UiCommandBar1.Wrappable = Janus.Windows.UI.InheritableBoolean.[False]
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.AllowMerge = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo2, Me.Separator4, Me.menuAbrir2, Me.Separator5, Me.menuGuardar2, Me.Separator6, Me.menuImprimir1})
        Me.UiCommandBar2.FullRow = True
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 0
        Me.UiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandBar2.Size = New System.Drawing.Size(720, 26)
        Me.UiCommandBar2.Text = "CommandBar2"
        Me.UiCommandBar2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        Me.UiCommandBar2.Wrappable = Janus.Windows.UI.InheritableBoolean.[True]
        '
        'menuNuevo2
        '
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
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
        'menuGuardar2
        '
        Me.menuGuardar2.Key = "menuGuardar"
        Me.menuGuardar2.Name = "menuGuardar2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuImprimir1
        '
        Me.menuImprimir1.Key = "menuImprimir"
        Me.menuImprimir1.Name = "menuImprimir1"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo1, Me.Separator1, Me.menuAbrir1, Me.Separator2, Me.menuGuardar1, Me.Separator3, Me.menuSalir1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuNuevo1
        '
        Me.menuNuevo1.Key = "menuNuevo"
        Me.menuNuevo1.Name = "menuNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuAbrir1
        '
        Me.menuAbrir1.Key = "menuAbrir"
        Me.menuAbrir1.Name = "menuAbrir1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuGuardar1
        '
        Me.menuGuardar1.Key = "menuGuardar"
        Me.menuGuardar1.Name = "menuGuardar1"
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
        'menuNuevo
        '
        Me.menuNuevo.Image = CType(resources.GetObject("menuNuevo.Image"), System.Drawing.Image)
        Me.menuNuevo.Key = "menuNuevo"
        Me.menuNuevo.Name = "menuNuevo"
        Me.menuNuevo.Text = "&Nuevo"
        '
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "&Imprimir"
        '
        'menuGuardar
        '
        Me.menuGuardar.Image = CType(resources.GetObject("menuGuardar.Image"), System.Drawing.Image)
        Me.menuGuardar.Key = "menuGuardar"
        Me.menuGuardar.Name = "menuGuardar"
        Me.menuGuardar.Text = "&Guardar"
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
        Me.TopRebar1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar2, Me.UiCommandBar1})
        Me.TopRebar1.CommandManager = Me.UiCommandManager1
        Me.TopRebar1.Controls.Add(Me.UiCommandBar2)
        Me.TopRebar1.Controls.Add(Me.UiCommandBar1)
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.Size = New System.Drawing.Size(720, 26)
        Me.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'frmArqueoDeCajaChica
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 643)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmArqueoDeCajaChica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arqueo de Fondo de Caja Chica"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.gridFondoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.gridDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private oArqueoCajaMgr As ArqueoDeCajaManager
    Private oArqueoCaja As ArqueoDeCaja


    Private dsIngresos As DataSet

    Public AdministrativoID As String
    Public AdministrativoName As String

    Private bolGuardar As Boolean


#End Region



    Public Sub CrearDenominaciones()

        dsIngresos = New DataSet("Ingresos")
        Dim dtDenominaciones As New DataTable("Denominaciones")

        Dim dcDenominacion As New DataColumn
        With dcDenominacion
            .ColumnName = "Denominacion"
            .Caption = "Denominación"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0.0
        End With

        Dim dcCantidad As New DataColumn
        With dcCantidad
            .ColumnName = "Cantidad"
            .Caption = "Cantidad"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Decimal)
            .Expression = "Denominacion * Cantidad"
            .DefaultValue = 0
        End With


        With dtDenominaciones.Columns
            .Add(dcDenominacion)
            .Add(dcCantidad)
            .Add(dcTotal)
        End With

        Dim i As Integer
        Dim cantidad As Decimal = 500



        Dim nRow As DataRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 500
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 200
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 100
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 50
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 20
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 10
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 5
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 2
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 1
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 0.5
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 0.2
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 0.1
        dtDenominaciones.Rows.Add(nRow)

        nRow = dtDenominaciones.NewRow
        nRow("Denominacion") = 0.05
        dtDenominaciones.Rows.Add(nRow)


        '''Efectivo dia anterior
        Dim dtDocumentos As New DataTable("Documentos")

        Dim dcFecha As New DataColumn
        With dcFecha
            .ColumnName = "Fecha"
            .Caption = "Fecha"
            .DataType = GetType(System.DateTime)
            .DefaultValue = Date.Now
        End With

        Dim dcConcepto As New DataColumn
        With dcConcepto
            .ColumnName = "Concepto"
            .Caption = "Concepto"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcImporte As New DataColumn
        With dcImporte
            .ColumnName = "Importe"
            .Caption = "Importe"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0.0
        End With


        With dtDocumentos.Columns
            .Add(dcFecha)
            .Add(dcConcepto)
            .Add(dcImporte)
        End With

        dsIngresos.Tables.Add(dtDenominaciones)
        dsIngresos.Tables.Add(dtDocumentos)

        dsIngresos.AcceptChanges()

    End Sub

    Public Sub Nuevo()

        Me.gridFondoCaja.Enabled = True
        Me.gridDocumentos.Enabled = True
        Me.ebResponsableID.Enabled = True
        Me.ebObservaciones.Enabled = True

        Me.ebResponsableID.Text = String.Empty
        Me.ebResponsableName.Text = String.Empty
        Me.ebObservaciones.Text = String.Empty
        Me.ebResponsableID.ReadOnly = False

        Me.bolGuardar = True

        '''Sucursal
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.ebSucursalID.Text = oAlmacen.ID
            Me.ebSucursalName.Text = oAlmacen.Descripcion

        End If
        '''Sucursal


        '''Objeto para seleccion de responsable
        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)
        '''Objeto para seleccion de responsable

        ''Fecha Server

        oArqueoCajaMgr = New ArqueoDeCajaManager(oAppContext)
        oArqueoCaja = oArqueoCajaMgr.Create
        Me.ccmbFecha.Value = oArqueoCajaMgr.FechaServer

        ''Fecha Server

        CrearDenominaciones()
        Me.gridDocumentos.SetDataBinding(Me.dsIngresos, "Documentos")
        Me.gridFondoCaja.SetDataBinding(Me.dsIngresos, "Denominaciones")

        Me.nbCajaChica.Value = oAppContext.ApplicationConfiguration.CajaChica

        Me.nbFolio.Value = oArqueoCajaMgr.SelectFolio(1)       '(0) Caja (1) Caja Chica

    End Sub

    Private Sub frmArqueoDeCajaChica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Administrativo
        Me.ebadministrativoName.Text = AdministrativoID
        Me.ebadministrativoID.Text = AdministrativoName

        Nuevo()

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

            End If

        Else

            On Error Resume Next

            oVendedor = Nothing


            oVendedor = oVendedoresMgr.Load(Me.ebResponsableID.Text.Trim)

            If oVendedor.IsDirty Then
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else


                Me.ebResponsableID.Text = oVendedor.ID
                Me.ebResponsableName.Text = oVendedor.Nombre

            End If

        End If

    End Sub

    Private Sub ebResponsableID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebResponsableID.ButtonClick
        Sm_Buscar(True)
    End Sub

    Private Sub ebResponsableID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebResponsableID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Sm_Buscar()
        ElseIf e.Alt And e.KeyCode = Keys.S Then
            Sm_Buscar(True)
        End If
    End Sub

    Private Sub gridFondoCaja_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridFondoCaja.CurrentCellChanged
        Try

            Me.nbTotalConteo.Value = Me.dsIngresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")
            Me.nbSobrante.Value = Math.Max((Me.nbTotalConteo.Value + Me.nbTotalDocumentos.Value) - Me.nbCajaChica.Value, 0)
            Me.nbFaltante.Value = Math.Abs(Math.Min((Me.nbTotalConteo.Value + Me.nbTotalDocumentos.Value) - Me.nbCajaChica.Value, 0))


        Catch ex As Exception


        End Try
    End Sub

    Private Sub gridDocumentos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDocumentos.CurrentCellChanged
        Try

            Me.nbTotalDocumentos.Value = Me.dsIngresos.Tables("Documentos").Compute("sum(Importe)", "Importe>0")
            Me.nbSobrante.Value = Math.Abs(Math.Min((Me.nbTotalConteo.Value + Me.nbTotalDocumentos.Value) - Me.nbCajaChica.Value, 0))
            Me.nbFaltante.Value = Math.Max((Me.nbTotalConteo.Value + Me.nbTotalDocumentos.Value) - Me.nbCajaChica.Value, 0)

        Catch ex As Exception


        End Try
    End Sub

    Private Sub sm_Imprimir(ByVal Imprimir As Boolean)

        Try
            If bolGuardar Then
                If Not Me.ebResponsableName.Text = String.Empty Then

                    If Not Me.ebObservaciones.Text.Trim = String.Empty Then

                        oArqueoCaja.Sucursal = Me.ebSucursalID.Text
                        oArqueoCaja.Caja = oAppContext.ApplicationConfiguration.NoCaja
                        oArqueoCaja.Administrativo = Me.ebadministrativoID.Text
                        oArqueoCaja.Responsable = Me.ebResponsableID.Text
                        oArqueoCaja.Observaciones = Me.ebObservaciones.Text
                        oArqueoCaja.FondoCaja = Me.nbCajaChica.Value
                        oArqueoCaja.Fecha = Me.ccmbFecha.Value
                        oArqueoCaja.StatusRegistro = True
                        oArqueoCaja.Ingresos = Me.dsIngresos.Copy

                        oArqueoCaja = oArqueoCajaMgr.InsertCajaChica(oArqueoCaja)

                        If Not oArqueoCaja.Folio = 0 Then

                            bolGuardar = False

                            MessageBox.Show("Arqueo guardado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Me.nbFolio.Value = oArqueoCaja.Folio

                            If Imprimir Then
                                PrintReport()
                            End If


                        Else

                            MessageBox.Show("El registro no pudo ser guardado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    Else

                        MessageBox.Show("Capture Observaciones", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ebObservaciones.Focus()

                    End If



                Else

                    MessageBox.Show("Capture el responsable de la sucursal", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebResponsableID.Focus()

                End If

            Else

                MessageBox.Show("No se pueden modificar los datos", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If



        Catch ex As Exception


        End Try

    End Sub

    Public Sub PrintReport()

        If oArqueoCaja.Folio <> 0 Then
            Dim oARReporte As New rptArqueoCajaChica(oArqueoCaja, ebadministrativoName.Text, ebResponsableName.Text)
            Dim oReportViewer As New ReportViewerForm

            oARReporte.Document.Name = "Arqueo de Caja Chica"

            oARReporte.Run()

            oReportViewer.Report = oARReporte
            oReportViewer.Show()

            Try
                'oARReporte.Document.Print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        sm_Imprimir(True)

    End Sub

    Private Sub frmArqueoDeCajaChica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F2 Then

            sm_Imprimir(False)

        ElseIf e.KeyCode = Keys.F9 Then

            sm_Imprimir(True)

        ElseIf e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Escape Then

            Me.Close()

        End If

    End Sub

    Private Sub sm_Abrir(Optional ByVal Vpa_bolOpenRecordDialog As Boolean = False)

        If ((Vpa_bolOpenRecordDialog = True) Or (Me.nbFolio.Value = 0)) Then

            Dim oOpenRecordDlg As New OpenRecordDialog


            oOpenRecordDlg.CurrentView = New ArqueoCajaChicaOpenRecodDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oArqueoCaja = Nothing
                oArqueoCaja = oArqueoCajaMgr.SelectCajaChica(oOpenRecordDlg.Record.Item("Folio"))

                If Not oArqueoCaja Is Nothing Then

                    Me.nbFolio.Value = oArqueoCaja.Folio


                    oAlmacen = oAlmacenesMgr.Load(oArqueoCaja.Sucursal)

                    If Not oAlmacen Is Nothing Then

                        Me.ebSucursalID.Text = oAlmacen.ID
                        Me.ebSucursalName.Text = oAlmacen.Descripcion

                    End If

                    oVendedor = Nothing
                    oVendedor = oVendedoresMgr.Load(Me.oArqueoCaja.Responsable)

                    If Not oVendedor.IsDirty Then


                        Me.ebResponsableID.Text = oVendedor.ID
                        Me.ebResponsableName.Text = oVendedor.Nombre

                    End If

                    oVendedor = Nothing
                    oVendedor = oVendedoresMgr.Load(Me.oArqueoCaja.Administrativo)

                    If Not oVendedor.IsDirty Then


                        Me.ebadministrativoID.Text = oVendedor.ID
                        Me.ebadministrativoName.Text = oVendedor.Nombre

                    End If


                    Me.ebObservaciones.Text = oArqueoCaja.Observaciones
                    Me.nbCajaChica.Value = oArqueoCaja.FondoCaja
                    Me.ccmbFecha.Value = oArqueoCaja.Fecha

                    Me.dsIngresos = Nothing
                    Me.dsIngresos = oArqueoCaja.Ingresos.Copy

                    Me.gridDocumentos.SetDataBinding(Me.dsIngresos, "Documentos")
                    Me.gridFondoCaja.SetDataBinding(Me.dsIngresos, "Denominaciones")


                    Me.gridDocumentos.Enabled = False
                    Me.gridFondoCaja.Enabled = False
                    Me.ebResponsableID.ReadOnly = True

                    bolGuardar = False
                End If

            End If

        Else

            On Error Resume Next



            oArqueoCaja = Nothing
            oArqueoCaja = oArqueoCajaMgr.SelectCajaChica(Me.nbFolio.Value)

            If Not oArqueoCaja Is Nothing Then

                Me.nbFolio.Value = oArqueoCaja.Folio


                oAlmacen = oAlmacenesMgr.Load(oArqueoCaja.Sucursal)

                If Not oAlmacen Is Nothing Then

                    Me.ebSucursalID.Text = oAlmacen.ID
                    Me.ebSucursalName.Text = oAlmacen.Descripcion

                End If

                oVendedor = Nothing
                oVendedor = oVendedoresMgr.Load(Me.oArqueoCaja.Responsable)

                If Not oVendedor.IsDirty Then


                    Me.ebResponsableID.Text = oVendedor.ID
                    Me.ebResponsableName.Text = oVendedor.Nombre

                End If

                oVendedor = Nothing
                oVendedor = oVendedoresMgr.Load(Me.oArqueoCaja.Administrativo)

                If Not oVendedor.IsDirty Then


                    Me.ebadministrativoID.Text = oVendedor.ID
                    Me.ebadministrativoName.Text = oVendedor.Nombre

                End If


                Me.ebObservaciones.Text = oArqueoCaja.Observaciones
                Me.nbCajaChica.Value = oArqueoCaja.FondoCaja
                Me.ccmbFecha.Value = oArqueoCaja.Fecha

                Me.dsIngresos = Nothing
                Me.dsIngresos = oArqueoCaja.Ingresos.Copy

                Me.gridDocumentos.SetDataBinding(Me.dsIngresos, "Documentos")
                Me.gridFondoCaja.SetDataBinding(Me.dsIngresos, "Denominaciones")


                Me.gridDocumentos.Enabled = False
                Me.gridFondoCaja.Enabled = False
                Me.ebResponsableID.ReadOnly = True

                bolGuardar = False

            End If
        End If

    End Sub

    Private Sub nbFolio_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbFolio.ButtonClick
        sm_Abrir(True)
    End Sub

    Private Sub nbFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbFolio.KeyDown
        If e.KeyCode = Keys.Enter Then

            sm_Abrir()

        ElseIf e.Alt And e.KeyCode = Keys.S Then

            sm_Abrir(True)

        End If
    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick
        Select Case e.Command.Key

            Case "menuSalir"

                Me.Close()

            Case "menuNuevo"

                Nuevo()

            Case "menuArchivoGuardar"

                sm_Imprimir(True)

            Case "menuAbrir"

                sm_Abrir(True)

            Case "menuImprimir"

                PrintReport()

            Case "menuAyudaTema"

                'TODO : Implementar Aqui la Ayuda

            Case Else

        End Select
    End Sub

    Private Sub gridDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDocumentos.KeyDown

        If e.KeyCode = Keys.Tab Then

            Me.gridFondoCaja.Focus()

        End If

    End Sub

    Private Sub gridFondoCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridFondoCaja.KeyDown

        If e.KeyCode = Keys.Tab Then

            Me.btnGuardar.Focus()

        End If

    End Sub

End Class
