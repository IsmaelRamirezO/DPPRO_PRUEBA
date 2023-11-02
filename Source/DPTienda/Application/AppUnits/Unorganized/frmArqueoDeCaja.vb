Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoVendedores
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ArqueoDeCajaAU
Imports DportenisPro.DPTienda.ApplicationUnits.CierreCaja
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoBancosAU
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU



Public Class frmArqueoDeCaja
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ebResponsableID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebResponsableName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSucursalName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativoName As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebAdministrativoID As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents nbFolio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gridDenominaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents gridDenominaciones2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents bntGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents nbFaltanteFondos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbSobranteFondos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbTotalConteoFondo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbFaltanteDiaAnterior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nSobranteDiaAnterior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbIngresosDiaAnterior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbTotalConteoDiaAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gridIngresoAnterior As Janus.Windows.GridEX.GridEX
    Friend WithEvents nbFaltanteDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbSobranteDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbIngresosDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents nbTotalConteoDia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebComentarios As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ccmbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents nbFondoCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiCommandManager1 As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiCommandBar1 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator5 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAbrir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator6 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator7 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuImprimir2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArqueoDeCaja))
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.bntGuardar = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFaltanteFondos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbSobranteFondos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbFondoCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbTotalConteoFondo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gridDenominaciones2 = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFaltanteDiaAnterior = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nSobranteDiaAnterior = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbIngresosDiaAnterior = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbTotalConteoDiaAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gridIngresoAnterior = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.nbFaltanteDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbSobranteDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbIngresosDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.nbTotalConteoDia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gridDenominaciones = New Janus.Windows.GridEX.GridEX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ebComentarios = New Janus.Windows.GridEX.EditControls.EditBox()
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
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar()
        Me.menuNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator5 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuAbrir2 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator6 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator7 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir2 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuAbrir1 = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuImprimir1 = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuAbrir = New Janus.Windows.UI.CommandBars.UICommand("menuAbrir")
        Me.menuSalir = New Janus.Windows.UI.CommandBars.UICommand("menuSalir")
        Me.menuGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuGuardar")
        Me.menuImprimir = New Janus.Windows.UI.CommandBars.UICommand("menuImprimir")
        Me.menuNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuNuevo")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gridDenominaciones2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gridIngresoAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gridDenominaciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ExplorerBar1.Controls.Add(Me.bntGuardar)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox3)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox2)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.ebComentarios)
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
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 48)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(880, 616)
        Me.ExplorerBar1.TabIndex = 0
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
        Me.Label20.Location = New System.Drawing.Point(304, 584)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(24, 23)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "F9"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(328, 584)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 23)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Guardar/Imprimir"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bntGuardar
        '
        Me.bntGuardar.Image = CType(resources.GetObject("bntGuardar.Image"), System.Drawing.Image)
        Me.bntGuardar.Location = New System.Drawing.Point(719, 582)
        Me.bntGuardar.Name = "bntGuardar"
        Me.bntGuardar.Size = New System.Drawing.Size(145, 28)
        Me.bntGuardar.TabIndex = 12
        Me.bntGuardar.Text = "Guardar"
        Me.bntGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.nbFaltanteFondos)
        Me.UiGroupBox3.Controls.Add(Me.nbSobranteFondos)
        Me.UiGroupBox3.Controls.Add(Me.nbFondoCaja)
        Me.UiGroupBox3.Controls.Add(Me.nbTotalConteoFondo)
        Me.UiGroupBox3.Controls.Add(Me.Label15)
        Me.UiGroupBox3.Controls.Add(Me.Label16)
        Me.UiGroupBox3.Controls.Add(Me.Label17)
        Me.UiGroupBox3.Controls.Add(Me.Label18)
        Me.UiGroupBox3.Controls.Add(Me.gridDenominaciones2)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(592, 144)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(272, 432)
        Me.UiGroupBox3.TabIndex = 10
        Me.UiGroupBox3.Text = "Fondo de Caja"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nbFaltanteFondos
        '
        Me.nbFaltanteFondos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFaltanteFondos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFaltanteFondos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbFaltanteFondos.Location = New System.Drawing.Point(120, 392)
        Me.nbFaltanteFondos.Name = "nbFaltanteFondos"
        Me.nbFaltanteFondos.ReadOnly = True
        Me.nbFaltanteFondos.Size = New System.Drawing.Size(128, 23)
        Me.nbFaltanteFondos.TabIndex = 4
        Me.nbFaltanteFondos.TabStop = False
        Me.nbFaltanteFondos.Text = "$0.00"
        Me.nbFaltanteFondos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFaltanteFondos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbSobranteFondos
        '
        Me.nbSobranteFondos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbSobranteFondos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbSobranteFondos.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbSobranteFondos.Location = New System.Drawing.Point(120, 360)
        Me.nbSobranteFondos.Name = "nbSobranteFondos"
        Me.nbSobranteFondos.ReadOnly = True
        Me.nbSobranteFondos.Size = New System.Drawing.Size(128, 23)
        Me.nbSobranteFondos.TabIndex = 3
        Me.nbSobranteFondos.TabStop = False
        Me.nbSobranteFondos.Text = "$0.00"
        Me.nbSobranteFondos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbSobranteFondos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbFondoCaja
        '
        Me.nbFondoCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFondoCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFondoCaja.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbFondoCaja.Location = New System.Drawing.Point(120, 328)
        Me.nbFondoCaja.Name = "nbFondoCaja"
        Me.nbFondoCaja.ReadOnly = True
        Me.nbFondoCaja.Size = New System.Drawing.Size(128, 23)
        Me.nbFondoCaja.TabIndex = 2
        Me.nbFondoCaja.TabStop = False
        Me.nbFondoCaja.Text = "$0.00"
        Me.nbFondoCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFondoCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalConteoFondo
        '
        Me.nbTotalConteoFondo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoFondo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoFondo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbTotalConteoFondo.Location = New System.Drawing.Point(120, 296)
        Me.nbTotalConteoFondo.Name = "nbTotalConteoFondo"
        Me.nbTotalConteoFondo.ReadOnly = True
        Me.nbTotalConteoFondo.Size = New System.Drawing.Size(128, 23)
        Me.nbTotalConteoFondo.TabIndex = 1
        Me.nbTotalConteoFondo.TabStop = False
        Me.nbTotalConteoFondo.Text = "$0.00"
        Me.nbTotalConteoFondo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalConteoFondo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
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
        Me.Label17.Text = "Fondo Caja:"
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
        'gridDenominaciones2
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.gridDenominaciones2.DesignTimeLayout = GridEXLayout1
        Me.gridDenominaciones2.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridDenominaciones2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDenominaciones2.GroupByBoxVisible = False
        Me.gridDenominaciones2.Location = New System.Drawing.Point(8, 24)
        Me.gridDenominaciones2.Name = "gridDenominaciones2"
        Me.gridDenominaciones2.Size = New System.Drawing.Size(256, 264)
        Me.gridDenominaciones2.TabIndex = 0
        Me.gridDenominaciones2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.nbFaltanteDiaAnterior)
        Me.UiGroupBox2.Controls.Add(Me.nSobranteDiaAnterior)
        Me.UiGroupBox2.Controls.Add(Me.nbIngresosDiaAnterior)
        Me.UiGroupBox2.Controls.Add(Me.nbTotalConteoDiaAnt)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.gridIngresoAnterior)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(304, 144)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(272, 432)
        Me.UiGroupBox2.TabIndex = 9
        Me.UiGroupBox2.Text = "Ingresos en Efectivo del Día Anterior"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nbFaltanteDiaAnterior
        '
        Me.nbFaltanteDiaAnterior.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFaltanteDiaAnterior.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFaltanteDiaAnterior.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbFaltanteDiaAnterior.Location = New System.Drawing.Point(120, 392)
        Me.nbFaltanteDiaAnterior.Name = "nbFaltanteDiaAnterior"
        Me.nbFaltanteDiaAnterior.ReadOnly = True
        Me.nbFaltanteDiaAnterior.Size = New System.Drawing.Size(128, 23)
        Me.nbFaltanteDiaAnterior.TabIndex = 4
        Me.nbFaltanteDiaAnterior.TabStop = False
        Me.nbFaltanteDiaAnterior.Text = "$0.00"
        Me.nbFaltanteDiaAnterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFaltanteDiaAnterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nSobranteDiaAnterior
        '
        Me.nSobranteDiaAnterior.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nSobranteDiaAnterior.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nSobranteDiaAnterior.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nSobranteDiaAnterior.Location = New System.Drawing.Point(120, 360)
        Me.nSobranteDiaAnterior.Name = "nSobranteDiaAnterior"
        Me.nSobranteDiaAnterior.ReadOnly = True
        Me.nSobranteDiaAnterior.Size = New System.Drawing.Size(128, 23)
        Me.nSobranteDiaAnterior.TabIndex = 3
        Me.nSobranteDiaAnterior.TabStop = False
        Me.nSobranteDiaAnterior.Text = "$0.00"
        Me.nSobranteDiaAnterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nSobranteDiaAnterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbIngresosDiaAnterior
        '
        Me.nbIngresosDiaAnterior.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbIngresosDiaAnterior.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbIngresosDiaAnterior.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbIngresosDiaAnterior.Location = New System.Drawing.Point(120, 328)
        Me.nbIngresosDiaAnterior.Name = "nbIngresosDiaAnterior"
        Me.nbIngresosDiaAnterior.ReadOnly = True
        Me.nbIngresosDiaAnterior.Size = New System.Drawing.Size(128, 23)
        Me.nbIngresosDiaAnterior.TabIndex = 2
        Me.nbIngresosDiaAnterior.TabStop = False
        Me.nbIngresosDiaAnterior.Text = "$0.00"
        Me.nbIngresosDiaAnterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbIngresosDiaAnterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalConteoDiaAnt
        '
        Me.nbTotalConteoDiaAnt.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoDiaAnt.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoDiaAnt.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbTotalConteoDiaAnt.Location = New System.Drawing.Point(120, 296)
        Me.nbTotalConteoDiaAnt.Name = "nbTotalConteoDiaAnt"
        Me.nbTotalConteoDiaAnt.ReadOnly = True
        Me.nbTotalConteoDiaAnt.Size = New System.Drawing.Size(128, 23)
        Me.nbTotalConteoDiaAnt.TabIndex = 1
        Me.nbTotalConteoDiaAnt.TabStop = False
        Me.nbTotalConteoDiaAnt.Text = "$0.00"
        Me.nbTotalConteoDiaAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalConteoDiaAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 392)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Faltante:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 360)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Sobrante:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Ingresos:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 296)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Total Conteo:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridIngresoAnterior
        '
        Me.gridIngresoAnterior.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gridIngresoAnterior.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.gridIngresoAnterior.DesignTimeLayout = GridEXLayout2
        Me.gridIngresoAnterior.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridIngresoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridIngresoAnterior.GroupByBoxVisible = False
        Me.gridIngresoAnterior.Location = New System.Drawing.Point(8, 24)
        Me.gridIngresoAnterior.Name = "gridIngresoAnterior"
        Me.gridIngresoAnterior.Size = New System.Drawing.Size(256, 264)
        Me.gridIngresoAnterior.TabIndex = 0
        Me.gridIngresoAnterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.nbFaltanteDia)
        Me.UiGroupBox1.Controls.Add(Me.nbSobranteDia)
        Me.UiGroupBox1.Controls.Add(Me.nbIngresosDia)
        Me.UiGroupBox1.Controls.Add(Me.nbTotalConteoDia)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.gridDenominaciones)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 144)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(272, 432)
        Me.UiGroupBox1.TabIndex = 8
        Me.UiGroupBox1.Text = "Ingresos en Efectivo del Día"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010
        '
        'nbFaltanteDia
        '
        Me.nbFaltanteDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbFaltanteDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbFaltanteDia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbFaltanteDia.Location = New System.Drawing.Point(120, 392)
        Me.nbFaltanteDia.Name = "nbFaltanteDia"
        Me.nbFaltanteDia.ReadOnly = True
        Me.nbFaltanteDia.Size = New System.Drawing.Size(128, 23)
        Me.nbFaltanteDia.TabIndex = 4
        Me.nbFaltanteDia.TabStop = False
        Me.nbFaltanteDia.Text = "$0.00"
        Me.nbFaltanteDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbFaltanteDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbSobranteDia
        '
        Me.nbSobranteDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbSobranteDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbSobranteDia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbSobranteDia.Location = New System.Drawing.Point(120, 360)
        Me.nbSobranteDia.Name = "nbSobranteDia"
        Me.nbSobranteDia.ReadOnly = True
        Me.nbSobranteDia.Size = New System.Drawing.Size(128, 23)
        Me.nbSobranteDia.TabIndex = 3
        Me.nbSobranteDia.TabStop = False
        Me.nbSobranteDia.Text = "$0.00"
        Me.nbSobranteDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbSobranteDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbIngresosDia
        '
        Me.nbIngresosDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbIngresosDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbIngresosDia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbIngresosDia.Location = New System.Drawing.Point(120, 328)
        Me.nbIngresosDia.Name = "nbIngresosDia"
        Me.nbIngresosDia.ReadOnly = True
        Me.nbIngresosDia.Size = New System.Drawing.Size(128, 23)
        Me.nbIngresosDia.TabIndex = 2
        Me.nbIngresosDia.TabStop = False
        Me.nbIngresosDia.Text = "$0.00"
        Me.nbIngresosDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbIngresosDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'nbTotalConteoDia
        '
        Me.nbTotalConteoDia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoDia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nbTotalConteoDia.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.nbTotalConteoDia.Location = New System.Drawing.Point(120, 296)
        Me.nbTotalConteoDia.Name = "nbTotalConteoDia"
        Me.nbTotalConteoDia.ReadOnly = True
        Me.nbTotalConteoDia.Size = New System.Drawing.Size(128, 23)
        Me.nbTotalConteoDia.TabIndex = 1
        Me.nbTotalConteoDia.TabStop = False
        Me.nbTotalConteoDia.Text = "$0.00"
        Me.nbTotalConteoDia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbTotalConteoDia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 392)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Faltante:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Sobrante:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Ingresos:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Total Conteo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridDenominaciones
        '
        GridEXLayout3.LayoutString = resources.GetString("GridEXLayout3.LayoutString")
        Me.gridDenominaciones.DesignTimeLayout = GridEXLayout3
        Me.gridDenominaciones.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridDenominaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDenominaciones.GroupByBoxVisible = False
        Me.gridDenominaciones.Location = New System.Drawing.Point(8, 24)
        Me.gridDenominaciones.Name = "gridDenominaciones"
        Me.gridDenominaciones.Size = New System.Drawing.Size(256, 264)
        Me.gridDenominaciones.TabIndex = 0
        Me.gridDenominaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(512, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(256, 23)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Observaciones:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebComentarios
        '
        Me.ebComentarios.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebComentarios.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebComentarios.Location = New System.Drawing.Point(512, 40)
        Me.ebComentarios.MaxLength = 200
        Me.ebComentarios.Multiline = True
        Me.ebComentarios.Name = "ebComentarios"
        Me.ebComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ebComentarios.Size = New System.Drawing.Size(352, 96)
        Me.ebComentarios.TabIndex = 11
        Me.ebComentarios.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebComentarios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ccmbFecha
        '
        '
        '
        '
        Me.ccmbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbFecha.Location = New System.Drawing.Point(376, 16)
        Me.ccmbFecha.Name = "ccmbFecha"
        Me.ccmbFecha.ShowDropDown = False
        Me.ccmbFecha.Size = New System.Drawing.Size(112, 23)
        Me.ccmbFecha.TabIndex = 13
        Me.ccmbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
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
        Me.ebResponsableID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ebResponsableName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ebSucursalID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ebSucursalName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebSucursalName.Location = New System.Drawing.Point(232, 48)
        Me.ebSucursalName.Name = "ebSucursalName"
        Me.ebSucursalName.ReadOnly = True
        Me.ebSucursalName.Size = New System.Drawing.Size(256, 23)
        Me.ebSucursalName.TabIndex = 3
        Me.ebSucursalName.TabStop = False
        Me.ebSucursalName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebSucursalName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativoName
        '
        Me.ebAdministrativoName.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoName.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativoName.Location = New System.Drawing.Point(232, 80)
        Me.ebAdministrativoName.Name = "ebAdministrativoName"
        Me.ebAdministrativoName.ReadOnly = True
        Me.ebAdministrativoName.Size = New System.Drawing.Size(256, 23)
        Me.ebAdministrativoName.TabIndex = 5
        Me.ebAdministrativoName.TabStop = False
        Me.ebAdministrativoName.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebAdministrativoName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebAdministrativoID
        '
        Me.ebAdministrativoID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebAdministrativoID.ButtonImage = CType(resources.GetObject("ebAdministrativoID.ButtonImage"), System.Drawing.Image)
        Me.ebAdministrativoID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebAdministrativoID.Location = New System.Drawing.Point(144, 80)
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
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuAbrir, Me.menuSalir, Me.menuGuardar, Me.menuImprimir, Me.menuNuevo})
        Me.UiCommandManager1.ContainerControl = Me
        '
        '
        '
        Me.UiCommandManager1.EditContextMenu.Key = ""
        Me.UiCommandManager1.Id = New System.Guid("d3478bc9-efbc-41c2-95dd-88c7496d98bc")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
        Me.UiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
        Me.UiCommandManager1.TopRebar = Me.TopRebar1
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
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1})
        Me.UiCommandBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(880, 22)
        Me.UiCommandBar1.Text = "CommandBar1"
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
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuNuevo2, Me.Separator5, Me.menuAbrir2, Me.Separator6, Me.menuGuardar2, Me.Separator7, Me.menuImprimir2})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 22)
        Me.UiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.[True]
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.Size = New System.Drawing.Size(282, 28)
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuNuevo2
        '
        Me.menuNuevo2.Key = "menuNuevo"
        Me.menuNuevo2.Name = "menuNuevo2"
        '
        'Separator5
        '
        Me.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator5.Key = "Separator"
        Me.Separator5.Name = "Separator5"
        '
        'menuAbrir2
        '
        Me.menuAbrir2.Key = "menuAbrir"
        Me.menuAbrir2.Name = "menuAbrir2"
        '
        'Separator6
        '
        Me.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator6.Key = "Separator"
        Me.Separator6.Name = "Separator6"
        '
        'menuGuardar2
        '
        Me.menuGuardar2.Key = "menuGuardar"
        Me.menuGuardar2.Name = "menuGuardar2"
        '
        'Separator7
        '
        Me.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator7.Key = "Separator"
        Me.Separator7.Name = "Separator7"
        '
        'menuImprimir2
        '
        Me.menuImprimir2.Enabled = Janus.Windows.UI.InheritableBoolean.[False]
        Me.menuImprimir2.Key = "menuImprimir"
        Me.menuImprimir2.Name = "menuImprimir2"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAbrir1, Me.Separator1, Me.menuNuevo1, Me.Separator4, Me.menuGuardar1, Me.Separator2, Me.menuImprimir1, Me.Separator3, Me.menuSalir1})
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
        'menuGuardar1
        '
        Me.menuGuardar1.Key = "menuGuardar"
        Me.menuGuardar1.Name = "menuGuardar1"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
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
        'menuImprimir
        '
        Me.menuImprimir.Image = CType(resources.GetObject("menuImprimir.Image"), System.Drawing.Image)
        Me.menuImprimir.Key = "menuImprimir"
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Text = "&Imprimir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(880, 50)
        Me.TopRebar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmArqueoDeCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(880, 661)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.TopRebar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmArqueoDeCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresos y Fondo de Caja"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.gridDenominaciones2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.gridIngresoAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.gridDenominaciones, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private oCierreCajaMgr As CierreCajaManager

    Private dsIngresos As DataSet

    Private bolGuardar As Boolean = True

    Public AdmnistrativoID As String
    Public AdmnistrativoName As String

    Private oBancosMgr As New CatalogoBancosManager(oAppContext)
    Private oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)

#End Region

#Region "Dataset"
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

        Dim dtDenominaciones2 As New DataTable("Denominaciones2")

        dtDenominaciones2 = dtDenominaciones.Copy
        dtDenominaciones2.TableName = "Denominaciones2"


        '''Efectivo dia anterior
        Dim dtIngresoAnterior As New DataTable("IngresoAnterior")

        Dim dcBanco As New DataColumn
        With dcBanco
            .ColumnName = "Banco"
            .Caption = "Banco"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcFicha As New DataColumn
        With dcFicha
            .ColumnName = "Ficha"
            .Caption = "Ficha"
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


        With dtIngresoAnterior.Columns
            .Add(dcBanco)
            .Add(dcFicha)
            .Add(dcImporte)
        End With



        dsIngresos.Tables.Add(dtDenominaciones)
        dsIngresos.Tables.Add(dtDenominaciones2)
        dsIngresos.Tables.Add(dtIngresoAnterior)

        dsIngresos.AcceptChanges()

    End Sub
#End Region

    Private Sub frmArqueoDeCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '</Sucursal>

        oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.ebSucursalID.Text = oAlmacen.ID
            Me.ebSucursalName.Text = oAlmacen.Descripcion

        End If
        '<Sucursal/>

        'Administrativo
        Me.ebAdministrativoName.Text = UCase(AdmnistrativoName)
        Me.ebAdministrativoID.Text = UCase(AdmnistrativoID)

        sm_nuevo()

    End Sub

    Private Sub sm_nuevo()

        oVendedoresMgr = New CatalogoVendedoresManager(oAppContext)

        Me.ebResponsableID.Text = String.Empty
        Me.ebResponsableName.Text = String.Empty
        Me.ebComentarios.Text = String.Empty

        bolGuardar = True

        Me.gridIngresoAnterior.Enabled = True
        Me.gridDenominaciones.Enabled = True
        Me.gridDenominaciones2.Enabled = True
        Me.ebComentarios.Enabled = True

        Me.ebAdministrativoName.Text = AdmnistrativoName
        Me.ebAdministrativoID.Text = AdmnistrativoID

        '''Sucursal
        oAlmacenesMgr = New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        If Not oAlmacen Is Nothing Then

            Me.ebSucursalID.Text = oAlmacen.ID
            Me.ebSucursalName.Text = oAlmacen.Descripcion

        End If
        '''Sucursal

        '''Creamos tablas
        Me.CrearDenominaciones()
        '''Creamos tablas

        ''Fecha Server

        oArqueoCajaMgr = New ArqueoDeCajaManager(oAppContext)
        oArqueoCaja = oArqueoCajaMgr.Create
        Me.ccmbFecha.Value = oArqueoCajaMgr.FechaServer

        ''Fecha Server

        ''Ingresos Efectivo del Dia

        Me.nbIngresosDia.Value = oArqueoCajaMgr.IngresosDia(ccmbFecha.Value, oAppContext.ApplicationConfiguration.NoCaja, oAppContext.ApplicationConfiguration.Almacen)

        ''Ingresos Efectivo del Dia

        ''Ingresos Efectivo del Dia Anterior

        Me.nbIngresosDiaAnterior.Value = oArqueoCajaMgr.IngresosDia(DateAdd(DateInterval.Day, -1, ccmbFecha.Value), oAppContext.ApplicationConfiguration.NoCaja, oAppContext.ApplicationConfiguration.Almacen)

        ''Ingresos Efectivo del Dia Anterior

        ''Fondo Caja
        oCierreCajaMgr = New CierreCajaManager(oAppContext)
        Me.nbFondoCaja.Value = oCierreCajaMgr.CalcularTotalFondoCaja(ccmbFecha.Value)

        ''Fondo Caja

        oBancosMgr = New CatalogoBancosManager(oAppContext)

        Me.gridIngresoAnterior.RootTable.Columns("Banco").HasValueList = True

        Dim valueList As Janus.Windows.GridEX.GridEXValueListItemCollection = Me.gridIngresoAnterior.RootTable.Columns("Banco").ValueList
        Dim view As System.Data.DataView = oBancosMgr.GetAll(False).Tables(0).DefaultView
        Dim i As Integer = 0

        For Each row As DataRow In view.Table.Rows
            valueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(row("CodBanco"), CStr(row("CodBanco"))))
        Next


        Me.gridDenominaciones.SetDataBinding(Me.dsIngresos, "Denominaciones")
        Me.gridDenominaciones2.SetDataBinding(Me.dsIngresos, "Denominaciones2")
        Me.gridIngresoAnterior.SetDataBinding(Me.dsIngresos, "IngresoAnterior")

        Me.nbFolio.Value = oArqueoCajaMgr.SelectFolio(0)       '(0) Caja (1) Caja Chica

        Me.UiCommandBar2.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar1.Commands("menuArchivo").Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.False


    End Sub


#Region "Eventos Busqueda"

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

#End Region

#Region "Eventos Formulario"
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

    Private Sub gridDenominaciones_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDenominaciones.CurrentCellChanged

        Try

            Me.nbTotalConteoDia.Value = Me.dsIngresos.Tables("Denominaciones").Compute("sum(Total)", "Total>0")
            Me.nbSobranteDia.Value = Math.Max(Me.nbTotalConteoDia.Value - Me.nbIngresosDia.Value, 0)
            Me.nbFaltanteDia.Value = Math.Abs(Math.Min(Me.nbTotalConteoDia.Value - Me.nbIngresosDia.Value, 0))

        Catch ex As Exception


        End Try

    End Sub

    Private Sub gridDenominaciones2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDenominaciones2.CurrentCellChanged
        Try

            Me.nbTotalConteoFondo.Value = Me.dsIngresos.Tables("Denominaciones2").Compute("sum(Total)", "Total>0")
            Me.nbSobranteFondos.Value = Math.Max(Me.nbTotalConteoFondo.Value - Me.nbFondoCaja.Value, 0)
            Me.nbFaltanteFondos.Value = Math.Abs(Math.Min(Me.nbTotalConteoFondo.Value - Me.nbFondoCaja.Value, 0))

        Catch ex As Exception


        End Try
    End Sub

    Private Sub gridIngresoAnterior_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridIngresoAnterior.CurrentCellChanged
        Try

            Me.nbTotalConteoDiaAnt.Value = Me.dsIngresos.Tables("IngresoAnterior").Compute("sum(Importe)", "Importe>0")
            Me.nSobranteDiaAnterior.Value = Math.Max(Me.nbTotalConteoDiaAnt.Value - Me.nbIngresosDiaAnterior.Value, 0)
            Me.nbFaltanteDiaAnterior.Value = Math.Abs(Math.Min(Me.nbTotalConteoDiaAnt.Value - Me.nbIngresosDiaAnterior.Value, 0))

        Catch ex As Exception


        End Try
    End Sub

#End Region

    Private Sub sm_Imprimir(ByVal Imprimir As Boolean)

        Try
            If bolGuardar Then
                If Not Me.ebResponsableName.Text = String.Empty Then

                    If Not Me.ebComentarios.Text = String.Empty Then
                        oArqueoCajaMgr = New ArqueoDeCajaManager(oAppContext)
                        oArqueoCaja = oArqueoCajaMgr.Create

                        oArqueoCaja.Folio = Me.nbFolio.Value
                        oArqueoCaja.Sucursal = Me.ebSucursalID.Text
                        oArqueoCaja.Caja = oAppContext.ApplicationConfiguration.NoCaja
                        oArqueoCaja.Administrativo = Me.ebAdministrativoID.Text
                        oArqueoCaja.Responsable = Me.ebResponsableID.Text
                        oArqueoCaja.Observaciones = Me.ebComentarios.Text
                        oArqueoCaja.IngresosDia = Me.nbIngresosDia.Value
                        oArqueoCaja.IngresosDiaAnterioro = Me.nbIngresosDiaAnterior.Value
                        oArqueoCaja.FondoCaja = Me.nbFondoCaja.Value
                        oArqueoCaja.Fecha = Me.ccmbFecha.Value
                        oArqueoCaja.StatusRegistro = True
                        oArqueoCaja.Ingresos = Me.dsIngresos.Copy

                        oArqueoCaja = oArqueoCajaMgr.Insert(oArqueoCaja)

                        If Not oArqueoCaja.Folio = 0 Then

                            bolGuardar = False

                            MessageBox.Show("Arqueo guardado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Me.UiCommandBar2.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True
                            Me.UiCommandBar1.Commands("menuArchivo").Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True

                            Me.nbFolio.Value = oArqueoCaja.Folio

                            If Imprimir Then
                                PrintReport()
                            End If

                        Else

                            MessageBox.Show("El registro no pudo ser guardado", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    Else

                        MessageBox.Show("Capture observaciones", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ebComentarios.Focus()


                    End If

                Else

                    MessageBox.Show("Capture el responsable de la sucursal", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ebResponsableID.Focus()

                End If

            Else

                MessageBox.Show("No se pueden modificar los datos", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            Throw New ApplicationException("Se produjo un error. ", ex)

        End Try

    End Sub

    Private Sub bntGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntGuardar.Click

        sm_Imprimir(True)

    End Sub

    Public Sub PrintReport()

        Dim oARReporte As New rptArqueoDeCaja(oArqueoCaja, ebAdministrativoName.Text, ebResponsableName.Text)
        'Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Arqueo de Caja"

        oARReporte.Run()

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

        Try
            oARReporte.Document.Print(False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub frmArqueoDeCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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


            oOpenRecordDlg.CurrentView = New ArqueoCajaOpenRecordDialogView

            oOpenRecordDlg.ShowDialog()

            If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

                On Error Resume Next

                oArqueoCaja = Nothing
                oArqueoCaja = oArqueoCajaMgr.Select(oOpenRecordDlg.Record.Item("Folio"))

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


                        Me.ebAdministrativoID.Text = oVendedor.ID
                        Me.ebAdministrativoName.Text = oVendedor.Nombre

                    End If


                    Me.ebComentarios.Text = oArqueoCaja.Observaciones
                    Me.nbIngresosDia.Value = oArqueoCaja.IngresosDia
                    Me.nbIngresosDiaAnterior.Value = oArqueoCaja.IngresosDiaAnterioro
                    Me.nbFondoCaja.Value = oArqueoCaja.FondoCaja
                    Me.ccmbFecha.Value = oArqueoCaja.Fecha

                    Me.dsIngresos = Nothing
                    Me.dsIngresos = oArqueoCaja.Ingresos.Copy

                    Me.gridDenominaciones.SetDataBinding(Me.dsIngresos, "Denominaciones")
                    Me.gridDenominaciones2.SetDataBinding(Me.dsIngresos, "Denominaciones2")
                    Me.gridIngresoAnterior.SetDataBinding(Me.dsIngresos, "IngresoAnterior")

                    Me.gridIngresoAnterior.Enabled = False
                    Me.gridDenominaciones.Enabled = False
                    Me.gridDenominaciones2.Enabled = False
                    Me.ebComentarios.Enabled = False

                    bolGuardar = False
                    Me.UiCommandBar2.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True
                    Me.UiCommandBar1.Commands("menuArchivo").Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True
                End If

            End If

        Else

            On Error Resume Next



            oArqueoCaja = Nothing
            oArqueoCaja = oArqueoCajaMgr.Select(Me.nbFolio.Value)

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


                    Me.ebAdministrativoID.Text = oVendedor.ID
                    Me.ebAdministrativoName.Text = oVendedor.Nombre

                End If


                Me.ebComentarios.Text = oArqueoCaja.Observaciones
                Me.nbIngresosDia.Value = oArqueoCaja.IngresosDia
                Me.nbIngresosDiaAnterior.Value = oArqueoCaja.IngresosDiaAnterioro
                Me.nbFondoCaja.Value = oArqueoCaja.FondoCaja
                Me.ccmbFecha.Value = oArqueoCaja.Fecha

                Me.dsIngresos = Nothing
                Me.dsIngresos = oArqueoCaja.Ingresos.Copy

                Me.gridDenominaciones.SetDataBinding(Me.dsIngresos, "Denominaciones")
                Me.gridDenominaciones2.SetDataBinding(Me.dsIngresos, "Denominaciones2")
                Me.gridIngresoAnterior.SetDataBinding(Me.dsIngresos, "IngresoAnterior")

                Me.gridIngresoAnterior.Enabled = False
                Me.gridDenominaciones.Enabled = False
                Me.gridDenominaciones2.Enabled = False
                Me.ebComentarios.Enabled = False

                bolGuardar = False

                Me.UiCommandBar2.Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True
                Me.UiCommandBar1.Commands("menuArchivo").Commands("menuImprimir").Enabled = Janus.Windows.UI.InheritableBoolean.True

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

                sm_nuevo()

            Case "menuGuardar"

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

    Private Sub gridDenominaciones_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles gridDenominaciones.FormattingRow

    End Sub

    Private Sub gridDenominaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDenominaciones.KeyDown
        If e.KeyCode = Keys.Tab Then
            Me.gridIngresoAnterior.Focus()
        End If
    End Sub



    Private Sub gridDenominaciones2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDenominaciones2.KeyDown
        If e.KeyCode = Keys.Tab Then
            Me.bntGuardar.Focus()
        End If
    End Sub


    Private Sub gridIngresoAnterior_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridIngresoAnterior.KeyDown
        If e.KeyCode = Keys.Tab Then
            Me.gridDenominaciones2.Focus()
        End If
    End Sub
End Class
