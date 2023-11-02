Imports System.Data
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class CatalogoClientesForm
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
    Friend WithEvents UiCommandBar2 As Janus.Windows.UI.CommandBars.UICommandBar
    Friend WithEvents menuArchivo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCiudad As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoColonia As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoEstado As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTCliente As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoNuevo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoCiudad1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoColonia1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoEstado1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuCatalogoTCliente1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyudaTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents menuArchivoNuevo2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarTema As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoGuardar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator3 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuBarTema1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents menuArchivoEliminar As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar2 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents uITab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ExplorerBar2 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar4 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ExplorerBar3 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLabel25 As System.Windows.Forms.Label
    Friend WithEvents ebEstadoCivil As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btnVerDatosFonacot As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnVerDatosFacilito As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkFacilito As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkFonacot As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebApellidoMaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebApellidoPaterno As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebSexo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebRecordCreateBy As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebRecordCreateOn As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnDatosCuentaAsociado As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkEsAsociado As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chkFacturar As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebFechaNac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebDomicilio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebEmail As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDFNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebDFCedulaFiscal As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebDFDireccion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents menuCatalogo1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuAyuda1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoSalir As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Separator4 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents menuArchivoEliminar1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ebClienteID As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebDFColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebCiudad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebDFCP As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ebCodPlaza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebCodAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebDFCiudad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ebDFEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents pbActivo As System.Windows.Forms.PictureBox
    Friend WithEvents pbInactivo As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkStatus As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents menuArchivoSalir1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebCP As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents msFechaNac As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoClientesForm))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim GridEXLayout3 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim GridEXLayout4 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem4 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem5 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem6 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim ExplorerBarGroup2 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup3 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarGroup4 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim GridEXLayout5 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim GridEXLayout6 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.UiCommandManager1 = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiCommandBar1 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuCatalogo1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuAyuda1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuArchivoSalir1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.UiCommandBar2 = New Janus.Windows.UI.CommandBars.UICommandBar
        Me.menuArchivoNuevo2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator2 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuArchivoEliminar2 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.Separator3 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuBarTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuBarTema")
        Me.menuArchivo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivo")
        Me.menuArchivoNuevo1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoGuardar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.Separator4 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
        Me.menuArchivoEliminar1 = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuCatalogo = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogo")
        Me.menuCatalogoCiudad1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCiudad")
        Me.menuCatalogoColonia1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoColonia")
        Me.menuCatalogoEstado1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoEstado")
        Me.menuCatalogoTCliente1 = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTCliente")
        Me.menuAyuda = New Janus.Windows.UI.CommandBars.UICommand("menuAyuda")
        Me.menuAyudaTema1 = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuArchivoNuevo = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoNuevo")
        Me.menuArchivoGuardar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoGuardar")
        Me.menuCatalogoCiudad = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoCiudad")
        Me.menuCatalogoColonia = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoColonia")
        Me.menuCatalogoEstado = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoEstado")
        Me.menuCatalogoTCliente = New Janus.Windows.UI.CommandBars.UICommand("menuCatalogoTCliente")
        Me.menuAyudaTema = New Janus.Windows.UI.CommandBars.UICommand("menuAyudaTema")
        Me.menuBarTema = New Janus.Windows.UI.CommandBars.UICommand("menuBarTema")
        Me.menuArchivoEliminar = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoEliminar")
        Me.menuArchivoSalir = New Janus.Windows.UI.CommandBars.UICommand("menuArchivoSalir")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.uITab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.msFechaNac = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.ebCP = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.pbActivo = New System.Windows.Forms.PictureBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.ebCodAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebCodPlaza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebCiudad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebClienteID = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebEstadoCivil = New Janus.Windows.EditControls.UIComboBox
        Me.lblLabel25 = New System.Windows.Forms.Label
        Me.btnVerDatosFonacot = New Janus.Windows.EditControls.UIButton
        Me.btnVerDatosFacilito = New Janus.Windows.EditControls.UIButton
        Me.chkFacilito = New Janus.Windows.EditControls.UICheckBox
        Me.chkFonacot = New Janus.Windows.EditControls.UICheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ebApellidoMaterno = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ebApellidoPaterno = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebSexo = New Janus.Windows.EditControls.UIComboBox
        Me.ExplorerBar4 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ExplorerBar3 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ebRecordCreateBy = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ebRecordCreateOn = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.btnDatosCuentaAsociado = New Janus.Windows.EditControls.UIButton
        Me.chkEsAsociado = New Janus.Windows.EditControls.UICheckBox
        Me.chkFacturar = New Janus.Windows.EditControls.UICheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ebFechaNac = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.ebDomicilio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ebEmail = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbInactivo = New System.Windows.Forms.PictureBox
        Me.chkStatus = New Janus.Windows.EditControls.UICheckBox
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage
        Me.ExplorerBar2 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.ebDFCiudad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebDFEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ebDFCP = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.ebDFColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.ebDFNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ebDFCedulaFiscal = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.ebDFDireccion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopRebar1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.uITab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uITab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar4.SuspendLayout()
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar3.SuspendLayout()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiCommandManager1
        '
        Me.UiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandManager1.BottomRebar = Me.BottomRebar1
        Me.UiCommandManager1.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.UiCommandBar1, Me.UiCommandBar2})
        Me.UiCommandManager1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo, Me.menuCatalogo, Me.menuAyuda, Me.menuArchivoNuevo, Me.menuArchivoGuardar, Me.menuCatalogoCiudad, Me.menuCatalogoColonia, Me.menuCatalogoEstado, Me.menuCatalogoTCliente, Me.menuAyudaTema, Me.menuBarTema, Me.menuArchivoEliminar, Me.menuArchivoSalir})
        Me.UiCommandManager1.ContainerControl = Me
        Me.UiCommandManager1.Id = New System.Guid("07ebe465-a26a-4250-a77e-00a9d443cc6d")
        Me.UiCommandManager1.LeftRebar = Me.LeftRebar1
        Me.UiCommandManager1.LockCommandBars = True
        Me.UiCommandManager1.RightRebar = Me.RightRebar1
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
        Me.UiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
        Me.UiCommandBar1.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar1.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivo1, Me.menuCatalogo1, Me.menuAyuda1, Me.menuArchivoSalir1})
        Me.UiCommandBar1.Key = "CommandBar1"
        Me.UiCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.UiCommandBar1.Name = "UiCommandBar1"
        Me.UiCommandBar1.RowIndex = 0
        Me.UiCommandBar1.Size = New System.Drawing.Size(610, 24)
        Me.UiCommandBar1.TabIndex = 0
        Me.UiCommandBar1.Text = "CommandBar1"
        '
        'menuArchivo1
        '
        Me.menuArchivo1.Key = "menuArchivo"
        Me.menuArchivo1.Name = "menuArchivo1"
        '
        'menuCatalogo1
        '
        Me.menuCatalogo1.Key = "menuCatalogo"
        Me.menuCatalogo1.Name = "menuCatalogo1"
        '
        'menuAyuda1
        '
        Me.menuAyuda1.Key = "menuAyuda"
        Me.menuAyuda1.Name = "menuAyuda1"
        '
        'menuArchivoSalir1
        '
        Me.menuArchivoSalir1.Key = "menuArchivoSalir"
        Me.menuArchivoSalir1.Name = "menuArchivoSalir1"
        '
        'UiCommandBar2
        '
        Me.UiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.CommandManager = Me.UiCommandManager1
        Me.UiCommandBar2.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo2, Me.Separator2, Me.menuArchivoGuardar2, Me.menuArchivoEliminar2, Me.Separator3, Me.menuBarTema1})
        Me.UiCommandBar2.Key = "CommandBar2"
        Me.UiCommandBar2.Location = New System.Drawing.Point(0, 24)
        Me.UiCommandBar2.Name = "UiCommandBar2"
        Me.UiCommandBar2.RowIndex = 1
        Me.UiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False
        Me.UiCommandBar2.Size = New System.Drawing.Size(266, 26)
        Me.UiCommandBar2.TabIndex = 1
        Me.UiCommandBar2.Text = "CommandBar2"
        '
        'menuArchivoNuevo2
        '
        Me.menuArchivoNuevo2.Image = CType(resources.GetObject("menuArchivoNuevo2.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo2.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo2.Name = "menuArchivoNuevo2"
        '
        'Separator2
        '
        Me.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator2.Key = "Separator"
        Me.Separator2.Name = "Separator2"
        '
        'menuArchivoGuardar2
        '
        Me.menuArchivoGuardar2.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar2.Name = "menuArchivoGuardar2"
        '
        'menuArchivoEliminar2
        '
        Me.menuArchivoEliminar2.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar2.Name = "menuArchivoEliminar2"
        '
        'Separator3
        '
        Me.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator3.Key = "Separator"
        Me.Separator3.Name = "Separator3"
        '
        'menuBarTema1
        '
        Me.menuBarTema1.Image = CType(resources.GetObject("menuBarTema1.Image"), System.Drawing.Image)
        Me.menuBarTema1.Key = "menuBarTema"
        Me.menuBarTema1.Name = "menuBarTema1"
        Me.menuBarTema1.Text = "Ay&uda"
        '
        'menuArchivo
        '
        Me.menuArchivo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuArchivoNuevo1, Me.Separator1, Me.menuArchivoGuardar1, Me.Separator4, Me.menuArchivoEliminar1})
        Me.menuArchivo.Key = "menuArchivo"
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Text = "&Archivo"
        '
        'menuArchivoNuevo1
        '
        Me.menuArchivoNuevo1.Image = CType(resources.GetObject("menuArchivoNuevo1.Image"), System.Drawing.Image)
        Me.menuArchivoNuevo1.Key = "menuArchivoNuevo"
        Me.menuArchivoNuevo1.Name = "menuArchivoNuevo1"
        '
        'Separator1
        '
        Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator1.Key = "Separator"
        Me.Separator1.Name = "Separator1"
        '
        'menuArchivoGuardar1
        '
        Me.menuArchivoGuardar1.Image = CType(resources.GetObject("menuArchivoGuardar1.Image"), System.Drawing.Image)
        Me.menuArchivoGuardar1.Key = "menuArchivoGuardar"
        Me.menuArchivoGuardar1.Name = "menuArchivoGuardar1"
        '
        'Separator4
        '
        Me.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
        Me.Separator4.Key = "Separator"
        Me.Separator4.Name = "Separator4"
        '
        'menuArchivoEliminar1
        '
        Me.menuArchivoEliminar1.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar1.Name = "menuArchivoEliminar1"
        '
        'menuCatalogo
        '
        Me.menuCatalogo.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuCatalogoCiudad1, Me.menuCatalogoColonia1, Me.menuCatalogoEstado1, Me.menuCatalogoTCliente1})
        Me.menuCatalogo.Key = "menuCatalogo"
        Me.menuCatalogo.Name = "menuCatalogo"
        Me.menuCatalogo.Text = "&Catalogo"
        '
        'menuCatalogoCiudad1
        '
        Me.menuCatalogoCiudad1.Image = CType(resources.GetObject("menuCatalogoCiudad1.Image"), System.Drawing.Image)
        Me.menuCatalogoCiudad1.Key = "menuCatalogoCiudad"
        Me.menuCatalogoCiudad1.Name = "menuCatalogoCiudad1"
        '
        'menuCatalogoColonia1
        '
        Me.menuCatalogoColonia1.Image = CType(resources.GetObject("menuCatalogoColonia1.Image"), System.Drawing.Image)
        Me.menuCatalogoColonia1.Key = "menuCatalogoColonia"
        Me.menuCatalogoColonia1.Name = "menuCatalogoColonia1"
        '
        'menuCatalogoEstado1
        '
        Me.menuCatalogoEstado1.Image = CType(resources.GetObject("menuCatalogoEstado1.Image"), System.Drawing.Image)
        Me.menuCatalogoEstado1.Key = "menuCatalogoEstado"
        Me.menuCatalogoEstado1.Name = "menuCatalogoEstado1"
        '
        'menuCatalogoTCliente1
        '
        Me.menuCatalogoTCliente1.Image = CType(resources.GetObject("menuCatalogoTCliente1.Image"), System.Drawing.Image)
        Me.menuCatalogoTCliente1.Key = "menuCatalogoTCliente"
        Me.menuCatalogoTCliente1.Name = "menuCatalogoTCliente1"
        '
        'menuAyuda
        '
        Me.menuAyuda.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.menuAyudaTema1})
        Me.menuAyuda.Key = "menuAyuda"
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Text = "Ay&uda"
        '
        'menuAyudaTema1
        '
        Me.menuAyudaTema1.Image = CType(resources.GetObject("menuAyudaTema1.Image"), System.Drawing.Image)
        Me.menuAyudaTema1.Key = "menuAyudaTema"
        Me.menuAyudaTema1.Name = "menuAyudaTema1"
        Me.menuAyudaTema1.Text = "&Tema de Ayuda"
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
        'menuCatalogoCiudad
        '
        Me.menuCatalogoCiudad.Key = "menuCatalogoCiudad"
        Me.menuCatalogoCiudad.Name = "menuCatalogoCiudad"
        Me.menuCatalogoCiudad.Text = "Ciudad"
        '
        'menuCatalogoColonia
        '
        Me.menuCatalogoColonia.Key = "menuCatalogoColonia"
        Me.menuCatalogoColonia.Name = "menuCatalogoColonia"
        Me.menuCatalogoColonia.Text = "C&olonia"
        '
        'menuCatalogoEstado
        '
        Me.menuCatalogoEstado.Key = "menuCatalogoEstado"
        Me.menuCatalogoEstado.Name = "menuCatalogoEstado"
        Me.menuCatalogoEstado.Text = "&Estado"
        '
        'menuCatalogoTCliente
        '
        Me.menuCatalogoTCliente.Key = "menuCatalogoTCliente"
        Me.menuCatalogoTCliente.Name = "menuCatalogoTCliente"
        Me.menuCatalogoTCliente.Text = "&Tipo de Cliente"
        '
        'menuAyudaTema
        '
        Me.menuAyudaTema.Key = "menuAyudaTema"
        Me.menuAyudaTema.Name = "menuAyudaTema"
        Me.menuAyudaTema.Text = "Te&ma de Ayuda"
        '
        'menuBarTema
        '
        Me.menuBarTema.Key = "menuBarTema"
        Me.menuBarTema.Name = "menuBarTema"
        Me.menuBarTema.Text = "Tema de Ayuda"
        '
        'menuArchivoEliminar
        '
        Me.menuArchivoEliminar.Image = CType(resources.GetObject("menuArchivoEliminar.Image"), System.Drawing.Image)
        Me.menuArchivoEliminar.Key = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Name = "menuArchivoEliminar"
        Me.menuArchivoEliminar.Text = "&Eliminar"
        '
        'menuArchivoSalir
        '
        Me.menuArchivoSalir.Key = "menuArchivoSalir"
        Me.menuArchivoSalir.Name = "menuArchivoSalir"
        Me.menuArchivoSalir.Text = "Salir"
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
        Me.TopRebar1.Size = New System.Drawing.Size(610, 50)
        Me.TopRebar1.TabIndex = 1
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel
        Me.UiGroupBox1.BorderColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.uITab1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(610, 517)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'uITab1
        '
        Me.uITab1.Controls.Add(Me.UiTabPage1)
        Me.uITab1.Controls.Add(Me.UiTabPage2)
        Me.uITab1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uITab1.Location = New System.Drawing.Point(0, 0)
        Me.uITab1.Name = "uITab1"
        Me.uITab1.SelectedIndex = 0
        Me.uITab1.Size = New System.Drawing.Size(672, 536)
        Me.uITab1.TabIndex = 0
        Me.uITab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.uITab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.ExplorerBar1)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(670, 512)
        Me.UiTabPage1.TabIndex = 5
        Me.UiTabPage1.Text = "Datos Generales Clientes    "
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.msFechaNac)
        Me.ExplorerBar1.Controls.Add(Me.ebCP)
        Me.ExplorerBar1.Controls.Add(Me.pbActivo)
        Me.ExplorerBar1.Controls.Add(Me.lblStatus)
        Me.ExplorerBar1.Controls.Add(Me.ebCodAlmacen)
        Me.ExplorerBar1.Controls.Add(Me.ebCodPlaza)
        Me.ExplorerBar1.Controls.Add(Me.ebCiudad)
        Me.ExplorerBar1.Controls.Add(Me.ebEstado)
        Me.ExplorerBar1.Controls.Add(Me.ebClienteID)
        Me.ExplorerBar1.Controls.Add(Me.ebEstadoCivil)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel25)
        Me.ExplorerBar1.Controls.Add(Me.btnVerDatosFonacot)
        Me.ExplorerBar1.Controls.Add(Me.btnVerDatosFacilito)
        Me.ExplorerBar1.Controls.Add(Me.chkFacilito)
        Me.ExplorerBar1.Controls.Add(Me.chkFonacot)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.ebTelefono)
        Me.ExplorerBar1.Controls.Add(Me.Label21)
        Me.ExplorerBar1.Controls.Add(Me.Label20)
        Me.ExplorerBar1.Controls.Add(Me.Label19)
        Me.ExplorerBar1.Controls.Add(Me.Label18)
        Me.ExplorerBar1.Controls.Add(Me.ebColonia)
        Me.ExplorerBar1.Controls.Add(Me.Label17)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoMaterno)
        Me.ExplorerBar1.Controls.Add(Me.Label16)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.ebApellidoPaterno)
        Me.ExplorerBar1.Controls.Add(Me.ebSexo)
        Me.ExplorerBar1.Controls.Add(Me.ExplorerBar4)
        Me.ExplorerBar1.Controls.Add(Me.chkFacturar)
        Me.ExplorerBar1.Controls.Add(Me.Label10)
        Me.ExplorerBar1.Controls.Add(Me.ebFechaNac)
        Me.ExplorerBar1.Controls.Add(Me.Label9)
        Me.ExplorerBar1.Controls.Add(Me.ebDomicilio)
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.ebEmail)
        Me.ExplorerBar1.Controls.Add(Me.ebNombre)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.pbInactivo)
        Me.ExplorerBar1.Controls.Add(Me.chkStatus)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales Clientes"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(670, 512)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'msFechaNac
        '
        Me.msFechaNac.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.msFechaNac.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.msFechaNac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.msFechaNac.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msFechaNac.Location = New System.Drawing.Point(440, 255)
        Me.msFechaNac.Mask = "00/00/0000"
        Me.msFechaNac.MaxLength = 10
        Me.msFechaNac.Name = "msFechaNac"
        Me.msFechaNac.Size = New System.Drawing.Size(96, 23)
        Me.msFechaNac.TabIndex = 14
        Me.msFechaNac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.msFechaNac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCP
        '
        Me.ebCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCP.Location = New System.Drawing.Point(416, 184)
        Me.ebCP.MaxLength = 5
        Me.ebCP.Name = "ebCP"
        Me.ebCP.Numeric = True
        Me.ebCP.PromptChar = Microsoft.VisualBasic.ChrW(0)
        Me.ebCP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebCP.Size = New System.Drawing.Size(120, 22)
        Me.ebCP.TabIndex = 9
        Me.ebCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pbActivo
        '
        Me.pbActivo.BackColor = System.Drawing.Color.Transparent
        Me.pbActivo.Image = CType(resources.GetObject("pbActivo.Image"), System.Drawing.Image)
        Me.pbActivo.Location = New System.Drawing.Point(568, 40)
        Me.pbActivo.Name = "pbActivo"
        Me.pbActivo.Size = New System.Drawing.Size(24, 24)
        Me.pbActivo.TabIndex = 136
        Me.pbActivo.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(496, 40)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(72, 23)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "ACTIVO"
        '
        'ebCodAlmacen
        '
        Me.ebCodAlmacen.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebCodAlmacen.DesignTimeLayout = GridEXLayout1
        Me.ebCodAlmacen.Enabled = False
        Me.ebCodAlmacen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodAlmacen.Location = New System.Drawing.Point(400, 280)
        Me.ebCodAlmacen.Name = "ebCodAlmacen"
        Me.ebCodAlmacen.ReadOnly = True
        Me.ebCodAlmacen.Size = New System.Drawing.Size(136, 22)
        Me.ebCodAlmacen.TabIndex = 16
        Me.ebCodAlmacen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodPlaza
        '
        Me.ebCodPlaza.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodPlaza.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodPlaza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCodPlaza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout2.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebCodPlaza.DesignTimeLayout = GridEXLayout2
        Me.ebCodPlaza.Enabled = False
        Me.ebCodPlaza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodPlaza.Location = New System.Drawing.Point(176, 280)
        Me.ebCodPlaza.Name = "ebCodPlaza"
        Me.ebCodPlaza.ReadOnly = True
        Me.ebCodPlaza.Size = New System.Drawing.Size(136, 22)
        Me.ebCodPlaza.TabIndex = 15
        Me.ebCodPlaza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodPlaza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCiudad
        '
        Me.ebCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebCiudad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout3.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebCiudad.DesignTimeLayout = GridEXLayout3
        Me.ebCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCiudad.Location = New System.Drawing.Point(176, 208)
        Me.ebCiudad.Name = "ebCiudad"
        Me.ebCiudad.Size = New System.Drawing.Size(192, 22)
        Me.ebCiudad.TabIndex = 8
        Me.ebCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebEstado
        '
        Me.ebEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout4.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebEstado.DesignTimeLayout = GridEXLayout4
        Me.ebEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEstado.Location = New System.Drawing.Point(176, 184)
        Me.ebEstado.Name = "ebEstado"
        Me.ebEstado.Size = New System.Drawing.Size(192, 22)
        Me.ebEstado.TabIndex = 7
        Me.ebEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebClienteID
        '
        Me.ebClienteID.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebClienteID.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebClienteID.ButtonImage = CType(resources.GetObject("ebClienteID.ButtonImage"), System.Drawing.Image)
        Me.ebClienteID.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.ebClienteID.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebClienteID.Location = New System.Drawing.Point(176, 39)
        Me.ebClienteID.MaxLength = 7
        Me.ebClienteID.Name = "ebClienteID"
        Me.ebClienteID.Size = New System.Drawing.Size(136, 23)
        Me.ebClienteID.TabIndex = 0
        Me.ebClienteID.Text = "0"
        Me.ebClienteID.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteID.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebClienteID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebEstadoCivil
        '
        Me.ebEstadoCivil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebEstadoCivil.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebEstadoCivil.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.Text = "SOLTERO(A)"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.Text = "CASADO(A)"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.Text = "VIUDO(A)"
        UiComboBoxItem4.FormatStyle.Alpha = 0
        UiComboBoxItem4.Text = "DIVORCIADO(A)"
        Me.ebEstadoCivil.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3, UiComboBoxItem4})
        Me.ebEstadoCivil.Location = New System.Drawing.Point(176, 256)
        Me.ebEstadoCivil.Name = "ebEstadoCivil"
        Me.ebEstadoCivil.Size = New System.Drawing.Size(136, 22)
        Me.ebEstadoCivil.TabIndex = 13
        Me.ebEstadoCivil.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'lblLabel25
        '
        Me.lblLabel25.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel25.Location = New System.Drawing.Point(56, 259)
        Me.lblLabel25.Name = "lblLabel25"
        Me.lblLabel25.Size = New System.Drawing.Size(112, 23)
        Me.lblLabel25.TabIndex = 134
        Me.lblLabel25.Text = "Estado Civil :"
        '
        'btnVerDatosFonacot
        '
        Me.btnVerDatosFonacot.Enabled = False
        Me.btnVerDatosFonacot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDatosFonacot.Location = New System.Drawing.Point(256, 309)
        Me.btnVerDatosFonacot.Name = "btnVerDatosFonacot"
        Me.btnVerDatosFonacot.Size = New System.Drawing.Size(88, 30)
        Me.btnVerDatosFonacot.TabIndex = 19
        Me.btnVerDatosFonacot.Text = "Ver Datos"
        Me.btnVerDatosFonacot.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btnVerDatosFacilito
        '
        Me.btnVerDatosFacilito.Enabled = False
        Me.btnVerDatosFacilito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDatosFacilito.Location = New System.Drawing.Point(448, 309)
        Me.btnVerDatosFacilito.Name = "btnVerDatosFacilito"
        Me.btnVerDatosFacilito.Size = New System.Drawing.Size(88, 30)
        Me.btnVerDatosFacilito.TabIndex = 21
        Me.btnVerDatosFacilito.Text = "Ver Datos"
        Me.btnVerDatosFacilito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkFacilito
        '
        Me.chkFacilito.BackColor = System.Drawing.Color.Transparent
        Me.chkFacilito.Enabled = False
        Me.chkFacilito.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFacilito.Location = New System.Drawing.Point(376, 317)
        Me.chkFacilito.Name = "chkFacilito"
        Me.chkFacilito.Size = New System.Drawing.Size(72, 23)
        Me.chkFacilito.TabIndex = 20
        Me.chkFacilito.Text = "Facilito"
        '
        'chkFonacot
        '
        Me.chkFonacot.BackColor = System.Drawing.Color.Transparent
        Me.chkFonacot.Enabled = False
        Me.chkFonacot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFonacot.Location = New System.Drawing.Point(176, 317)
        Me.chkFonacot.Name = "chkFonacot"
        Me.chkFonacot.Size = New System.Drawing.Size(88, 23)
        Me.chkFonacot.TabIndex = 18
        Me.chkFonacot.Text = "Fonacot"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Plaza:"
        '
        'ebTelefono
        '
        Me.ebTelefono.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebTelefono.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebTelefono.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebTelefono.Location = New System.Drawing.Point(440, 208)
        Me.ebTelefono.Mask = "!(###) 000-0000"
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ebTelefono.Size = New System.Drawing.Size(96, 22)
        Me.ebTelefono.TabIndex = 10
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(376, 214)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 16)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "Telefono:"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(376, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 23)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "C.P. :"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(56, 184)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 23)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Estado:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(56, 208)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 23)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Ciudad:"
        '
        'ebColonia
        '
        Me.ebColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebColonia.Location = New System.Drawing.Point(176, 160)
        Me.ebColonia.MaxLength = 50
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(360, 22)
        Me.ebColonia.TabIndex = 6
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(56, 161)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 23)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Colonia:"
        '
        'ebApellidoMaterno
        '
        Me.ebApellidoMaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoMaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoMaterno.Location = New System.Drawing.Point(176, 112)
        Me.ebApellidoMaterno.MaxLength = 30
        Me.ebApellidoMaterno.Name = "ebApellidoMaterno"
        Me.ebApellidoMaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoMaterno.TabIndex = 4
        Me.ebApellidoMaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoMaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(56, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Apellido Materno:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Apellido Paterno:"
        '
        'ebApellidoPaterno
        '
        Me.ebApellidoPaterno.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebApellidoPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebApellidoPaterno.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebApellidoPaterno.Location = New System.Drawing.Point(176, 88)
        Me.ebApellidoPaterno.MaxLength = 30
        Me.ebApellidoPaterno.Name = "ebApellidoPaterno"
        Me.ebApellidoPaterno.Size = New System.Drawing.Size(264, 22)
        Me.ebApellidoPaterno.TabIndex = 3
        Me.ebApellidoPaterno.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebApellidoPaterno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebSexo
        '
        Me.ebSexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebSexo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.ebSexo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UiComboBoxItem5.FormatStyle.Alpha = 0
        UiComboBoxItem5.Text = "M"
        UiComboBoxItem6.FormatStyle.Alpha = 0
        UiComboBoxItem6.Text = "F"
        Me.ebSexo.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem5, UiComboBoxItem6})
        Me.ebSexo.Location = New System.Drawing.Point(472, 232)
        Me.ebSexo.Name = "ebSexo"
        Me.ebSexo.Size = New System.Drawing.Size(64, 22)
        Me.ebSexo.TabIndex = 12
        Me.ebSexo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'ExplorerBar4
        '
        Me.ExplorerBar4.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar4.Controls.Add(Me.ExplorerBar3)
        Me.ExplorerBar4.Controls.Add(Me.btnDatosCuentaAsociado)
        Me.ExplorerBar4.Controls.Add(Me.chkEsAsociado)
        ExplorerBarGroup2.Expandable = False
        ExplorerBarGroup2.Image = CType(resources.GetObject("ExplorerBarGroup2.Image"), System.Drawing.Image)
        ExplorerBarGroup2.Key = "Group1"
        ExplorerBarGroup2.Text = "Asociado"
        Me.ExplorerBar4.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup2})
        Me.ExplorerBar4.Location = New System.Drawing.Point(0, 352)
        Me.ExplorerBar4.Name = "ExplorerBar4"
        Me.ExplorerBar4.Size = New System.Drawing.Size(672, 224)
        Me.ExplorerBar4.TabIndex = 31
        Me.ExplorerBar4.TabStop = False
        Me.ExplorerBar4.Text = "ExplorerBar4"
        Me.ExplorerBar4.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ExplorerBar3
        '
        Me.ExplorerBar3.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar3.Controls.Add(Me.ebRecordCreateBy)
        Me.ExplorerBar3.Controls.Add(Me.Label5)
        Me.ExplorerBar3.Controls.Add(Me.ebRecordCreateOn)
        Me.ExplorerBar3.Controls.Add(Me.Label22)
        ExplorerBarGroup3.Expandable = False
        ExplorerBarGroup3.Image = CType(resources.GetObject("ExplorerBarGroup3.Image"), System.Drawing.Image)
        ExplorerBarGroup3.Key = "Group1"
        ExplorerBarGroup3.Text = "Registro"
        Me.ExplorerBar3.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup3})
        Me.ExplorerBar3.Location = New System.Drawing.Point(0, 72)
        Me.ExplorerBar3.Name = "ExplorerBar3"
        Me.ExplorerBar3.Size = New System.Drawing.Size(672, 168)
        Me.ExplorerBar3.TabIndex = 1
        Me.ExplorerBar3.TabStop = False
        Me.ExplorerBar3.Text = "ExplorerBar3"
        Me.ExplorerBar3.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebRecordCreateBy
        '
        Me.ebRecordCreateBy.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateBy.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateBy.BackColor = System.Drawing.Color.Ivory
        Me.ebRecordCreateBy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRecordCreateBy.Location = New System.Drawing.Point(176, 32)
        Me.ebRecordCreateBy.Name = "ebRecordCreateBy"
        Me.ebRecordCreateBy.Size = New System.Drawing.Size(144, 22)
        Me.ebRecordCreateBy.TabIndex = 2
        Me.ebRecordCreateBy.TabStop = False
        Me.ebRecordCreateBy.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRecordCreateBy.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Usuario:"
        '
        'ebRecordCreateOn
        '
        Me.ebRecordCreateOn.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateOn.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebRecordCreateOn.BackColor = System.Drawing.Color.Ivory
        Me.ebRecordCreateOn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebRecordCreateOn.Location = New System.Drawing.Point(440, 32)
        Me.ebRecordCreateOn.Name = "ebRecordCreateOn"
        Me.ebRecordCreateOn.Size = New System.Drawing.Size(96, 22)
        Me.ebRecordCreateOn.TabIndex = 3
        Me.ebRecordCreateOn.TabStop = False
        Me.ebRecordCreateOn.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebRecordCreateOn.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(328, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 23)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Fecha Registro:"
        '
        'btnDatosCuentaAsociado
        '
        Me.btnDatosCuentaAsociado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDatosCuentaAsociado.Enabled = False
        Me.btnDatosCuentaAsociado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosCuentaAsociado.Location = New System.Drawing.Point(175, 32)
        Me.btnDatosCuentaAsociado.Name = "btnDatosCuentaAsociado"
        Me.btnDatosCuentaAsociado.Size = New System.Drawing.Size(177, 32)
        Me.btnDatosCuentaAsociado.TabIndex = 1
        Me.btnDatosCuentaAsociado.Text = "Datos Cuenta Asociado"
        Me.btnDatosCuentaAsociado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkEsAsociado
        '
        Me.chkEsAsociado.BackColor = System.Drawing.Color.Transparent
        Me.chkEsAsociado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEsAsociado.Enabled = False
        Me.chkEsAsociado.Location = New System.Drawing.Point(56, 36)
        Me.chkEsAsociado.Name = "chkEsAsociado"
        Me.chkEsAsociado.Size = New System.Drawing.Size(104, 23)
        Me.chkEsAsociado.TabIndex = 0
        Me.chkEsAsociado.Text = "Es Asociado"
        Me.chkEsAsociado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'chkFacturar
        '
        Me.chkFacturar.BackColor = System.Drawing.Color.Transparent
        Me.chkFacturar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFacturar.Location = New System.Drawing.Point(336, 40)
        Me.chkFacturar.Name = "chkFacturar"
        Me.chkFacturar.Size = New System.Drawing.Size(104, 23)
        Me.chkFacturar.TabIndex = 1
        Me.chkFacturar.Text = "Facturar"
        Me.chkFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(320, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 23)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Tienda:"
        '
        'ebFechaNac
        '
        '
        'ebFechaNac.DropDownCalendar
        '
        Me.ebFechaNac.DropDownCalendar.Location = New System.Drawing.Point(15, 35)
        Me.ebFechaNac.DropDownCalendar.Name = ""
        Me.ebFechaNac.DropDownCalendar.Size = New System.Drawing.Size(170, 173)
        Me.ebFechaNac.DropDownCalendar.TabIndex = 0
        Me.ebFechaNac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.ebFechaNac.Enabled = False
        Me.ebFechaNac.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFechaNac.Location = New System.Drawing.Point(456, 360)
        Me.ebFechaNac.Name = "ebFechaNac"
        Me.ebFechaNac.Size = New System.Drawing.Size(136, 22)
        Me.ebFechaNac.TabIndex = 15
        Me.ebFechaNac.Value = New Date(2005, 2, 4, 0, 0, 0, 0)
        Me.ebFechaNac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(320, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 23)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Fecha de Nacim.:"
        '
        'ebDomicilio
        '
        Me.ebDomicilio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDomicilio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDomicilio.Location = New System.Drawing.Point(176, 136)
        Me.ebDomicilio.MaxLength = 50
        Me.ebDomicilio.Name = "ebDomicilio"
        Me.ebDomicilio.Size = New System.Drawing.Size(360, 22)
        Me.ebDomicilio.TabIndex = 5
        Me.ebDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDomicilio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 23)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Domicilio:"
        '
        'ebEmail
        '
        Me.ebEmail.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebEmail.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebEmail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebEmail.Location = New System.Drawing.Point(176, 232)
        Me.ebEmail.MaxLength = 50
        Me.ebEmail.Name = "ebEmail"
        Me.ebEmail.Size = New System.Drawing.Size(240, 22)
        Me.ebEmail.TabIndex = 11
        Me.ebEmail.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebNombre
        '
        Me.ebNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombre.Location = New System.Drawing.Point(176, 64)
        Me.ebNombre.MaxLength = 30
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(264, 22)
        Me.ebNombre.TabIndex = 2
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "E-mail:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(424, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Sexo:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Codigo:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre:"
        '
        'pbInactivo
        '
        Me.pbInactivo.BackColor = System.Drawing.Color.Transparent
        Me.pbInactivo.Image = CType(resources.GetObject("pbInactivo.Image"), System.Drawing.Image)
        Me.pbInactivo.Location = New System.Drawing.Point(568, 40)
        Me.pbInactivo.Name = "pbInactivo"
        Me.pbInactivo.Size = New System.Drawing.Size(24, 24)
        Me.pbInactivo.TabIndex = 137
        Me.pbInactivo.TabStop = False
        Me.pbInactivo.Visible = False
        '
        'chkStatus
        '
        Me.chkStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkStatus.Location = New System.Drawing.Point(360, 64)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(72, 16)
        Me.chkStatus.TabIndex = 138
        Me.chkStatus.Text = "Status"
        Me.chkStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.ExplorerBar2)
        Me.UiTabPage2.Enabled = False
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(670, 512)
        Me.UiTabPage2.TabIndex = 1
        Me.UiTabPage2.Text = "Datos de Facturación"
        '
        'ExplorerBar2
        '
        Me.ExplorerBar2.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar2.Controls.Add(Me.ebDFCiudad)
        Me.ExplorerBar2.Controls.Add(Me.ebDFEstado)
        Me.ExplorerBar2.Controls.Add(Me.ebDFCP)
        Me.ExplorerBar2.Controls.Add(Me.ebDFColonia)
        Me.ExplorerBar2.Controls.Add(Me.Label24)
        Me.ExplorerBar2.Controls.Add(Me.ebDFNombre)
        Me.ExplorerBar2.Controls.Add(Me.Label23)
        Me.ExplorerBar2.Controls.Add(Me.ebDFCedulaFiscal)
        Me.ExplorerBar2.Controls.Add(Me.ebDFDireccion)
        Me.ExplorerBar2.Controls.Add(Me.Label15)
        Me.ExplorerBar2.Controls.Add(Me.Label14)
        Me.ExplorerBar2.Controls.Add(Me.Label13)
        Me.ExplorerBar2.Controls.Add(Me.Label11)
        Me.ExplorerBar2.Controls.Add(Me.Label12)
        ExplorerBarGroup4.Expandable = False
        ExplorerBarGroup4.Image = CType(resources.GetObject("ExplorerBarGroup4.Image"), System.Drawing.Image)
        ExplorerBarGroup4.Key = "Group1"
        ExplorerBarGroup4.Text = "Datos de Facturacion"
        Me.ExplorerBar2.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup4})
        Me.ExplorerBar2.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar2.Name = "ExplorerBar2"
        Me.ExplorerBar2.Size = New System.Drawing.Size(672, 512)
        Me.ExplorerBar2.TabIndex = 30
        Me.ExplorerBar2.TabStop = False
        Me.ExplorerBar2.Text = "ExplorerBar2"
        Me.ExplorerBar2.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebDFCiudad
        '
        Me.ebDFCiudad.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFCiudad.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFCiudad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout5.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebDFCiudad.DesignTimeLayout = GridEXLayout5
        Me.ebDFCiudad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFCiudad.Location = New System.Drawing.Point(160, 208)
        Me.ebDFCiudad.MaxLength = 50
        Me.ebDFCiudad.Name = "ebDFCiudad"
        Me.ebDFCiudad.Size = New System.Drawing.Size(216, 22)
        Me.ebDFCiudad.TabIndex = 5
        Me.ebDFCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDFEstado
        '
        Me.ebDFEstado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFEstado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout6.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition ID="""" /></RootTable><RowWithErrorsFo" & _
        "rmatStyle><PredefinedStyle>RowWithErrorsFormatStyle</PredefinedStyle></RowWithEr" & _
        "rorsFormatStyle><LinkFormatStyle><PredefinedStyle>LinkFormatStyle</PredefinedSty" & _
        "le></LinkFormatStyle><CardCaptionFormatStyle><PredefinedStyle>CardCaptionFormatS" & _
        "tyle</PredefinedStyle></CardCaptionFormatStyle><GroupByBoxFormatStyle><Predefine" & _
        "dStyle>GroupByBoxFormatStyle</PredefinedStyle></GroupByBoxFormatStyle><GroupByBo" & _
        "xInfoFormatStyle><PredefinedStyle>GroupByBoxInfoFormatStyle</PredefinedStyle></G" & _
        "roupByBoxInfoFormatStyle><GroupRowFormatStyle><PredefinedStyle>GroupRowFormatSty" & _
        "le</PredefinedStyle></GroupRowFormatStyle><HeaderFormatStyle><PredefinedStyle>He" & _
        "aderFormatStyle</PredefinedStyle></HeaderFormatStyle><PreviewRowFormatStyle><Pre" & _
        "definedStyle>PreviewRowFormatStyle</PredefinedStyle></PreviewRowFormatStyle><Row" & _
        "FormatStyle><PredefinedStyle>RowFormatStyle</PredefinedStyle></RowFormatStyle><S" & _
        "electedFormatStyle><PredefinedStyle>SelectedFormatStyle</PredefinedStyle></Selec" & _
        "tedFormatStyle><SelectedInactiveFormatStyle><PredefinedStyle>SelectedInactiveFor" & _
        "matStyle</PredefinedStyle></SelectedInactiveFormatStyle><WatermarkImage /><Contr" & _
        "olStyle /><VisualStyle>Office2003</VisualStyle><AllowEdit>False</AllowEdit><Expa" & _
        "ndableGroups>False</ExpandableGroups><GroupByBoxVisible>False</GroupByBoxVisible" & _
        "><HideSelection>Highlight</HideSelection></GridEXLayoutData>"
        Me.ebDFEstado.DesignTimeLayout = GridEXLayout6
        Me.ebDFEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFEstado.Location = New System.Drawing.Point(160, 176)
        Me.ebDFEstado.MaxLength = 50
        Me.ebDFEstado.Name = "ebDFEstado"
        Me.ebDFEstado.Size = New System.Drawing.Size(216, 22)
        Me.ebDFEstado.TabIndex = 4
        Me.ebDFEstado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDFCP
        '
        Me.ebDFCP.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFCP.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFCP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFCP.Location = New System.Drawing.Point(160, 240)
        Me.ebDFCP.MaxLength = 5
        Me.ebDFCP.Name = "ebDFCP"
        Me.ebDFCP.Numeric = True
        Me.ebDFCP.PromptChar = Microsoft.VisualBasic.ChrW(0)
        Me.ebDFCP.Size = New System.Drawing.Size(96, 22)
        Me.ebDFCP.TabIndex = 6
        Me.ebDFCP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebDFCP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDFColonia
        '
        Me.ebDFColonia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFColonia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFColonia.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFColonia.Location = New System.Drawing.Point(160, 144)
        Me.ebDFColonia.MaxLength = 50
        Me.ebDFColonia.Name = "ebDFColonia"
        Me.ebDFColonia.Size = New System.Drawing.Size(384, 22)
        Me.ebDFColonia.TabIndex = 3
        Me.ebDFColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(72, 240)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 16)
        Me.Label24.TabIndex = 58
        Me.Label24.Text = "C.P."
        '
        'ebDFNombre
        '
        Me.ebDFNombre.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFNombre.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFNombre.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFNombre.Location = New System.Drawing.Point(160, 48)
        Me.ebDFNombre.MaxLength = 80
        Me.ebDFNombre.Name = "ebDFNombre"
        Me.ebDFNombre.Size = New System.Drawing.Size(384, 22)
        Me.ebDFNombre.TabIndex = 0
        Me.ebDFNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(72, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 23)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Nombre:"
        '
        'ebDFCedulaFiscal
        '
        Me.ebDFCedulaFiscal.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFCedulaFiscal.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFCedulaFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFCedulaFiscal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFCedulaFiscal.Location = New System.Drawing.Point(160, 80)
        Me.ebDFCedulaFiscal.Name = "ebDFCedulaFiscal"
        Me.ebDFCedulaFiscal.PromptChar = Microsoft.VisualBasic.ChrW(0)
        Me.ebDFCedulaFiscal.Size = New System.Drawing.Size(216, 22)
        Me.ebDFCedulaFiscal.TabIndex = 1
        Me.ebDFCedulaFiscal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFCedulaFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebDFDireccion
        '
        Me.ebDFDireccion.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDFDireccion.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDFDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebDFDireccion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDFDireccion.Location = New System.Drawing.Point(160, 112)
        Me.ebDFDireccion.MaxLength = 150
        Me.ebDFDireccion.Name = "ebDFDireccion"
        Me.ebDFDireccion.Size = New System.Drawing.Size(384, 22)
        Me.ebDFDireccion.TabIndex = 2
        Me.ebDFDireccion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDFDireccion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(72, 176)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 23)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Estado:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(72, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Direccion:"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(72, 212)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 23)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Ciudad:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(72, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Colonia:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(72, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 23)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "R.F.C.:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CatalogoClientesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(610, 567)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TopRebar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CatalogoClientesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo Clientes"
        CType(Me.UiCommandManager1.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCommandBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopRebar1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.uITab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uITab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.ExplorerBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar4.ResumeLayout(False)
        CType(Me.ExplorerBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar3.ResumeLayout(False)
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.ExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Environment Var"

    Dim vClienteID As Integer = 0
    Dim esInstanciaAsociado As Boolean = False
    Dim esInstanciaFactura As Boolean = False

    Public pubClienteID As Integer = 0
    Public PubNombreCliente As String = String.Empty

    'Objeto Cliente
    Dim oClienteMgr As ClientesManager
    Public oCliente As Clientes

    'Objetos DataTable
    Dim dtEstados As DataTable
    Private dtMunicipio As DataTable
    Private dtAlmacen As DataTable
    Dim dtPlazas As DataTable

    Private rango1, rango2, rango1DF, rango2DF As Integer
    Private dsCodigos As New DataSet
    Private dsCodigosDF As New DataSet
    Private bandNuevo As Boolean = False 'True.- Mover foco
    Private bandera As Boolean = True


#End Region

#Region "Initialize"

    Private Sub InitializeObjects()

        oClienteMgr = New ClientesManager(oAppContext)
        oCliente = oClienteMgr.Create
        'Clear Fields
        oCliente.Clear()

    End Sub

    Private Sub InitializeBinding()

        'Datos Generales Cliente
        ebClienteID.DataBindings.Add(New Binding("Value", oCliente, "ClienteID"))
        ebNombre.DataBindings.Add(New Binding("Text", oCliente, "Nombre"))
        ebApellidoPaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoPaterno"))
        ebApellidoMaterno.DataBindings.Add(New Binding("Text", oCliente, "ApellidoMaterno"))
        ebSexo.DataBindings.Add(New Binding("Text", oCliente, "Sexo"))
        ebEstadoCivil.DataBindings.Add(New Binding("Text", oCliente, "EstadoCivil"))
        ebDomicilio.DataBindings.Add(New Binding("Text", oCliente, "Domicilio"))
        ebEstado.DataBindings.Add(New Binding("Text", oCliente, "Estado"))
        ebCiudad.DataBindings.Add(New Binding("Text", oCliente, "Ciudad"))
        ebColonia.DataBindings.Add(New Binding("Text", oCliente, "Colonia"))
        ebCP.DataBindings.Add(New Binding("Text", oCliente, "CP"))
        ebTelefono.DataBindings.Add(New Binding("Text", oCliente, "Telefono"))
        ebFechaNac.DataBindings.Add(New Binding("Value", oCliente, "FechaNac"))
        ebEmail.DataBindings.Add(New Binding("Text", oCliente, "Email"))
        ebCodAlmacen.DataBindings.Add(New Binding("Text", oCliente, "CodAlmacen"))
        ebCodPlaza.DataBindings.Add(New Binding("Text", oCliente, "CodPlaza"))
        chkFacturar.DataBindings.Add(New Binding("Checked", oCliente, "Facturar"))
        chkEsAsociado.DataBindings.Add(New Binding("Checked", oCliente, "EsAsociado"))
        chkFacilito.DataBindings.Add(New Binding("Checked", oCliente, "EsFacilito"))
        chkFonacot.DataBindings.Add(New Binding("Checked", oCliente, "EsFonacot"))
        chkStatus.DataBindings.Add(New Binding("Checked", oCliente, "RecordEnabled"))

        'Datos Fiscales Cliente
        'ebDFCedulaFiscal.DataBindings.Add(New Binding("Text", oCliente, "CedulaFiscal"))
        'ebDFNombre.DataBindings.Add(New Binding("Text", oCliente, "DFNombre"))
        'ebDFDireccion.DataBindings.Add(New Binding("Text", oCliente, "DFDireccion"))
        'ebDFColonia.DataBindings.Add(New Binding("Text", oCliente, "DFColonia"))
        'ebDFCiudad.DataBindings.Add(New Binding("Text", oCliente, "DFCiudad"))
        'ebDFEstado.DataBindings.Add(New Binding("Text", oCliente, "DFEstado"))
        'ebDFCP.DataBindings.Add(New Binding("Text", oCliente, "DFCP"))

        'ebRecordCreateBy.DataBindings.Add(New Binding("Text", oCliente, "RecordCreatedBy"))
        'ebRecordCreateOn.DataBindings.Add(New Binding("Text", oCliente, "RecordCreatedOn"))

    End Sub

#End Region

#Region "Properties"

    'Uso : 
    '       Se utilizan paran indicar que se llama desde el Módulo Contratos, y generar 
    '       una consulta de un Cliente especifico.


    Private bolModuloContrato As Boolean
    Private intClienteID As Integer
    Private m_strNombreApellidos As String

    Public WriteOnly Property ModuloContrato() As Boolean

        Set(ByVal Value As Boolean)

            bolModuloContrato = Value

        End Set

    End Property

    Public Property ClienteID() As Integer
        Get

            Return intClienteID

        End Get

        Set(ByVal Value As Integer)

            intClienteID = Value

        End Set

    End Property

    Public Property NombreApellidos() As String
        Get

            Return m_strNombreApellidos

        End Get

        Set(ByVal Value As String)

            m_strNombreApellidos = Value

        End Set

    End Property

#End Region

#Region "General Methods"

    Private Sub LimErrorProvider()
        ebCP.Text = String.Empty
        Me.ErrorProvider1.SetError(ebNombre, "")
        Me.ErrorProvider1.SetError(ebApellidoPaterno, "")
        Me.ErrorProvider1.SetError(ebApellidoMaterno, "")
        Me.ErrorProvider1.SetError(ebDomicilio, "")
        Me.ErrorProvider1.SetError(ebColonia, "")
        Me.ErrorProvider1.SetError(ebEstado, "")
        Me.ErrorProvider1.SetError(ebCiudad, "")
        Me.ErrorProvider1.SetError(ebCP, "")
        Me.ErrorProvider1.SetError(ebTelefono, "")
        Me.ErrorProvider1.SetError(ebEmail, "")
        Me.ErrorProvider1.SetError(ebEstadoCivil, "")
        Me.ErrorProvider1.SetError(ebCodPlaza, "")
        Me.ErrorProvider1.SetError(ebCodAlmacen, "")

        Me.ErrorProvider1.SetError(ebDFNombre, "")
        Me.ErrorProvider1.SetError(ebDFCedulaFiscal, "")
        Me.ErrorProvider1.SetError(ebDFDireccion, "")
        Me.ErrorProvider1.SetError(ebDFColonia, "")
        Me.ErrorProvider1.SetError(ebDFEstado, "")
        Me.ErrorProvider1.SetError(ebDFCiudad, "")
        Me.ErrorProvider1.SetError(ebDFCP, "")
        bandNuevo = True

    End Sub

    Private Sub CatalogoClientesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Refresh()

        'Inicializamos objeto
        InitializeObjects()

        'Inicializamos vinculos
        InitializeBinding()

        'Llenamos el combo de estados
        FillComboEstados()

        FillComboPlazas()

        FillGeneralData()

        If (bolModuloContrato = True) Then

            oCliente.Clear()

            oClienteMgr.LoadInto(intClienteID, oCliente)

        End If

        Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        ebCodPlaza.Value = oAlmacen.PlazaID

        FillComboAlmacen(ebCodPlaza.Value)
        Me.ebCodAlmacen.Value = oAppContext.ApplicationConfiguration.Almacen

        oCliente.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
        oCliente.CodPlaza = oAlmacen.PlazaID

        SendKeys.Send("{TAB}")

        If esInstanciaAsociado Then

            LoadDataForAsociado()

        Else

            ebClienteID.Focus()

        End If

        If esInstanciaFactura Then
            loaddataforfactura()
        End If

    End Sub

    Private Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles UiCommandManager1.CommandClick

        Select Case e.Command.Key

            Case "menuArchivoSalir"

                Me.Close()

            Case "menuArchivoGuardar"

                SaveCliente()

                If esInstanciaAsociado Or esInstanciaFactura Then

                    Me.ClienteID = oCliente.ClienteID
                    Me.NombreApellidos = Trim(oCliente.Nombre & " " & oCliente.ApellidoPaterno & " " & oCliente.ApellidoMaterno)

                    Me.DialogResult = DialogResult.OK

                End If

                ebClienteID.Focus()

            Case "menuArchivoEliminar"

                EliminarCliente()
                ebClienteID.Focus()

            Case "menuArchivoNuevo"
                If (bolModuloContrato = True) Then

                    MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
                    Exit Sub

                End If




                LimErrorProvider()
                UiTabPage1.Select()
                UiTabPage1.Selected = True
                UiTabPage1.Show()
                chkStatus.Checked = True

                oCliente.Clear()
                ebDFNombre.Text = String.Empty
                ebDFCedulaFiscal.Text = String.Empty
                ebDFDireccion.Text = String.Empty
                ebDFColonia.Text = String.Empty
                ebDFEstado.Text = String.Empty
                ebDFCiudad.Text = String.Empty
                ebDFCP.Text = String.Empty
                msFechaNac.Text = String.Empty


                Dim oCatalogoAlmacenesMgr As New DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.CatalogoAlmacenesManager(oAppContext)
                Dim oAlmacen As DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes.Almacen
                Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
                oAlmacen = oCatalogoAlmacenesMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

                ebCodPlaza.Value = oAlmacen.PlazaID

                FillComboAlmacen(ebCodPlaza.Value)
                Me.ebCodAlmacen.Value = oAppContext.ApplicationConfiguration.Almacen

                oCliente.CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
                oCliente.CodPlaza = oAlmacen.PlazaID

                ebRecordCreateBy.Text = ""
                ebRecordCreateOn.Text = ""
                ActivaNoModificables()
                ebClienteID.Focus()


                bandera = True
            Case "menuCatalogoCiudad"

                Dim oCatalogoB As New CatalogoCiudadesForm
                oCatalogoB.Show()


            Case "menuCatalogoColonia"

                Dim oCatalogoB As New frmColonias
                oCatalogoB.Show()

            Case "menuCatalogoEstado"

                Dim oCatalogoB As New frmEstado
                oCatalogoB.Show()

            Case "menuCatalogoTCliente"

                Dim oCatalogoB As New frmTipoCliente
                oCatalogoB.Show()

        End Select

    End Sub

    Private Function ValidaDatos() As Boolean

        If Me.ebNombre.Text = String.Empty Then
            MessageBox.Show("Capture el Nombre del Cliente", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebNombre.Focus()
            Return False

        ElseIf Me.ebApellidoPaterno.Text = String.Empty Then
            MessageBox.Show("Capture el Apellido Paterno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebApellidoPaterno.Focus()
            Return False

        ElseIf Me.ebApellidoMaterno.Text = String.Empty Then
            MessageBox.Show("Capture el Apellido Materno", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebApellidoPaterno.Focus()
            Return False

        ElseIf Me.ebDomicilio.Text = String.Empty Then
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

        ElseIf Me.ebSexo.Text = String.Empty Then
            MessageBox.Show("Seleccione Sexo", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebSexo.Focus()
            Return False

        ElseIf Me.ebEstadoCivil.Text = String.Empty Then
            MessageBox.Show("Seleccione Estado Civil", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebEstadoCivil.Focus()
            Return False

        ElseIf Me.ebFechaNac.Text = String.Empty Then
            MessageBox.Show("Capture Fecha de Nacimiento ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ebEstadoCivil.Focus()
            Return False

        ElseIf Me.chkFacturar.Checked Then

            If Me.ebDFNombre.Text = String.Empty Or Me.ebDFCedulaFiscal.Text = String.Empty Or Me.ebDFEstado.Text = String.Empty _
            Or Me.ebDFDireccion.Text = String.Empty Or Me.ebDFColonia.Text = String.Empty Or Me.ebDFCiudad.Text = String.Empty _
            Or Me.ebDFCP.Text = String.Empty Then

                MessageBox.Show("Faltan Datos Fiscales ", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False

            End If

        End If

        Return True

    End Function

    Private Sub SaveCliente()

        If (bolModuloContrato = True) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        If Not ValidaDatos() Then
            Exit Sub
        End If

        UiTabPage1.Select()

        UiTabPage1.Selected = True

        UiTabPage1.Show()

        If oCliente.ClienteID = 0 Then

            'oCliente.FechaNac = Me.ebFechaNac.Value
            oCliente.DFNombre = Me.ebDFNombre.Text
            oCliente.DFDireccion = Me.ebDFDireccion.Text
            oCliente.DFEstado = Me.ebDFEstado.Text
            oCliente.DFCiudad = Me.ebDFCiudad.Text
            oCliente.DFColonia = Me.ebDFColonia.Text
            oCliente.DFCP = Me.ebDFCP.Text
            oCliente.CedulaFiscal = Me.ebDFCedulaFiscal.Text

            oCliente.ClienteID = oClienteMgr.Save(oCliente)

            ebRecordCreateBy.Text = oCliente.RecordCreatedBy
            ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")

            oCliente.ResetFlagNew()

            MsgBox("Cliente se guardó satisfactoriamente. Codigo de Cliente :" & Format(oCliente.ClienteID, "00000000"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Cliente")

            If esInstanciaFactura Then

                pubClienteID = oCliente.ClienteID
                PubNombreCliente = oCliente.Nombre.Trim & " " & oCliente.ApellidoPaterno.Trim & " " & oCliente.ApellidoMaterno.Trim

            End If

            DesactivaNoModificables()

            bandera = True

        Else

            oCliente.DFNombre = Me.ebDFNombre.Text
            oCliente.DFDireccion = Me.ebDFDireccion.Text
            oCliente.DFEstado = Me.ebDFEstado.Text
            oCliente.DFCiudad = Me.ebDFCiudad.Text
            oCliente.DFColonia = Me.ebDFColonia.Text
            oCliente.DFCP = Me.ebDFCP.Text
            oCliente.CedulaFiscal = Me.ebDFCedulaFiscal.Text

            oCliente.RecordCreatedBy = oAppContext.Security.CurrentUser.Name
            oCliente.RecordCreatedOn = Date.Today
            oClienteMgr.Save(oCliente)

            MsgBox("Cliente " & Format(oCliente.ClienteID, "00000000") & " se guardó satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Guardar Cliente")

            ebRecordCreateBy.Text = oCliente.RecordCreatedBy
            ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")

            DesactivaNoModificables()
            bandera = True


        End If


    End Sub

    Private Sub chkFacturar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFacturar.CheckedChanged

        If chkFacturar.Checked = True Then

            UiTabPage2.Enabled = True

        Else

            UiTabPage2.Enabled = False

        End If

    End Sub

    Private Sub btnDatosCuentaAsociado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosCuentaAsociado.Click

        'TODO : Implementar cuando sea aprobado.

        'If oCliente.ClienteID <> 0 Then

        '    If chkEsAsociado.Checked = True Then

        '        'Abrimos Datos del Asociado

        '        Dim oCatalogoAsociados As CatalogoAsociadosForm = New CatalogoAsociadosForm

        '        oCatalogoAsociados.ShowDialog(6)

        '    Else

        '        MsgBox("El Cliente no es un Asociado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

        '    End If

        'Else

        '    MsgBox("Es necesario tener asignado un Cliente.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

        'End If

        'btnDatosCuentaAsociado.Focus()

    End Sub

    Private Sub Valida()

        If (ebClienteID.Value > 0 And ebClienteID.Value <> oCliente.ClienteID) Then
            Dim myID As Integer = ebClienteID.Value
            oCliente.Clear()
            oClienteMgr.LoadInto(myID, oCliente)


            If oCliente.ClienteID = 0 Then
                MsgBox("Cliente " & Format(myID, "00000000") & " no está registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
                ActivaNoModificables()
                ebClienteID.Focus()
            Else
                ebRecordCreateBy.Text = oCliente.RecordCreatedBy
                ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
                DesactivaNoModificables()
                oCliente.ResetFlagNew()

                Me.ebDFNombre.Text = oCliente.DFNombre
                Me.ebDFDireccion.Text = oCliente.DFDireccion
                Me.ebDFEstado.Text = oCliente.DFEstado
                Me.ebDFCiudad.Text = oCliente.DFCiudad
                Me.ebDFColonia.Text = oCliente.DFColonia
                Me.ebDFCP.Text = oCliente.DFCP
                Me.ebDFCedulaFiscal.Text = oCliente.CedulaFiscal
                Me.msFechaNac.Text = Format(oCliente.FechaNac, "dd/MM/yyyy")
                bandera = True
            End If
        Else
            If ebClienteID.Value <= 0 Then
                ebClienteID.Value = oCliente.ClienteID
            End If
        End If
    End Sub

    Private Sub EliminarCliente()

        If (bolModuloContrato = True) Then

            MsgBox("No puede realizar modificaciones.", MsgBoxStyle.Exclamation, "DPTienda")
            Exit Sub

        End If

        If oCliente.ClienteID = 0 Then

            MsgBox("Ingrese Código de Cliente a eliminar. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Eliminar Cliente")

        Else

            Dim oMsgResult As MsgBoxResult

            oMsgResult = MsgBox("¿Esta seguro que desea eliminar al cliente? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "  Eliminar Cliente")

            If oMsgResult = MsgBoxResult.Yes Then

                Dim myID As Integer = oCliente.ClienteID

                oClienteMgr.Delete(oCliente.ClienteID)

                MsgBox("Se eliminó el Cliente :" & Format(oCliente.ClienteID, "00000000"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Eliminar Cliente")

                ebRecordCreateBy.Text = ""
                ebRecordCreateOn.Text = ""

                oCliente.Clear()
                bandera = True

            Else

                ebClienteID.Focus()

            End If

        End If

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

        With ebDFEstado

            .DataSource = dtEstados
            .DropDownList.Columns.Add("Estado")
            .DropDownList.Columns.Add("CodEstado")
            .DropDownList.Columns("CodEstado").Visible = False
            .DropDownList.Columns("CodEstado").DataMember = "CodEstado"
            .DropDownList.Columns("Estado").DataMember = "Descripcion"
            .DropDownList.Columns("Estado").Width = 180

            .DisplayMember = "Descripcion"
            .ValueMember = "CodEstado"

            .Refresh()

        End With

    End Sub

    Private Sub FillComboPlazas()

        dtPlazas = oClienteMgr.GetAllPlazas(False)

        With ebCodPlaza

            .DataSource = dtPlazas
            .DropDownList.Columns.Add("CodPlaza")
            .DropDownList.Columns.Add("Plaza")
            .DropDownList.Columns("CodPlaza").Visible = False
            .DropDownList.Columns("CodPlaza").DataMember = "CodPlaza"
            .DropDownList.Columns("Plaza").DataMember = "Descripcion"
            .DropDownList.Columns("Plaza").Width = 170

            .DisplayMember = "CodPlaza"
            .ValueMember = "CodPlaza"

            .Refresh()

        End With

    End Sub

    Private Sub FillGeneralData()

        dtAlmacen = oClienteMgr.GetAllAlmacenes(False)
        dtMunicipio = oClienteMgr.GetAllMunicipio(False)

    End Sub

    Private Sub FilldtComboCiudades(ByVal CodEstado As Integer)

        Dim dvCiudades As DataView = New DataView(dtMunicipio)
        dvCiudades.RowFilter = "CodEstado = " & CodEstado & ""

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

        If oCliente.Ciudad <> String.Empty Then

            ebCiudad.Text = oCliente.Ciudad

        End If

    End Sub

    Private Function BuscaEstado(ByVal strEstado As String) As Integer

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

    Private Sub FillComboAlmacen(ByVal CodPlaza As String)

        Dim dvAlmacen As DataView = New DataView(dtAlmacen)
        dvAlmacen.RowFilter = "CodPlaza = '" & CodPlaza & "'"

        With ebCodAlmacen

            .DropDownList.ClearStructure()

            .DataSource = dvAlmacen
            .DropDownList.Columns.Add("Código")
            .DropDownList.Columns.Add("Descripcion")
            '.DropDownList.Columns("CodAlmacen").Visible = False
            .DropDownList.Columns("Código").DataMember = "CodAlmacen"
            .DropDownList.Columns("Descripcion").DataMember = "Descripcion"
            .DropDownList.Columns("Descripcion").Width = 150
            .DropDownList.Columns("Código").Width = 50

            .DisplayMember = "CodAlmacen"
            .ValueMember = "CodAlmacen"

            .Refresh()

        End With

    End Sub

    Private Sub ebClienteID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebClienteID.KeyDown

        If e.Alt And e.KeyCode = Keys.S Then

            LoadSearchForm()
            ebClienteID.Focus()
            ebClienteID.SelectAll()

        ElseIf e.KeyCode = Keys.Enter Then
            Valida()
            ebClienteID.Focus()
            ebClienteID.SelectAll()
        End If

    End Sub

    Private Sub LoadSearchForm()

        'Dim oOpenRecordDlg As New OpenRecordDialog
        'oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        Dim oOpenRecordDlg As OpenRecordDialogClientes


        oOpenRecordDlg = New OpenRecordDialogClientes

        oOpenRecordDlg.CurrentView = New ClientesOpenRecordDialogView

        If (oOpenRecordDlg.CurrentView Is Nothing) Then
            Exit Sub
        End If


        oOpenRecordDlg.ShowDialog()

        If (oOpenRecordDlg.DialogResult = DialogResult.OK) Then

            oCliente.Clear()

            Try
                Dim intClienteID As Integer

                If oOpenRecordDlg.pbCodigo = String.Empty Then

                    'intClienteID = oOpenRecordDlg.Record.Item("Código")
                    intClienteID = oOpenRecordDlg.Record.Item("ClienteID")

                Else

                    intClienteID = CType(oOpenRecordDlg.pbCodigo, Integer)

                End If

                oClienteMgr.LoadInto(intClienteID, oCliente)

                With oCliente

                    DesactivaNoModificables()

                    ebRecordCreateBy.Text = .RecordCreatedBy
                    ebRecordCreateOn.Text = Format(oCliente.RecordCreatedOn, "dd/MM/yyyy")
                    chkFacturar.Focus()

                    Me.msFechaNac.Text = Format(oCliente.FechaNac, "dd/MM/yyyy")
                    Me.ebDFNombre.Text = .DFNombre
                    Me.ebDFDireccion.Text = .DFDireccion
                    Me.ebDFEstado.Text = .DFEstado
                    Me.ebDFCiudad.Text = .DFCiudad
                    Me.ebDFColonia.Text = .DFColonia
                    Me.ebDFCP.Text = .DFCP
                    Me.ebDFCedulaFiscal.Text = .CedulaFiscal
                    bandera = True

                End With

            Catch ex As Exception

                Exit Sub

            End Try

        End If

    End Sub

    Private Sub ebClienteID_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.ButtonClick

        LoadSearchForm()

    End Sub

    Private Sub chkFonacot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFonacot.CheckedChanged

        If chkFonacot.Checked = True Then

            btnVerDatosFonacot.Enabled = True

        Else

            btnVerDatosFonacot.Enabled = False

        End If

    End Sub

    Private Sub chkFacilito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFacilito.CheckedChanged

        If chkFacilito.Checked = True Then

            btnVerDatosFacilito.Enabled = True

        Else

            btnVerDatosFacilito.Enabled = False

        End If

    End Sub

    Private Sub chkEsAsociado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEsAsociado.CheckedChanged

        If chkEsAsociado.Checked = True Then

            btnDatosCuentaAsociado.Enabled = True

        Else

            btnDatosCuentaAsociado.Enabled = False

        End If

    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged

        If chkStatus.Checked Then

            lblStatus.Text = "ACTIVO"
            pbActivo.Visible = True
            pbInactivo.Visible = False
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.True

        Else

            lblStatus.Text = "INACTIVO"
            pbActivo.Visible = False
            pbInactivo.Visible = True
            UiCommandManager1.Commands.Item("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False

        End If

    End Sub

    Private Sub DesactivaNoModificables()

        'ebNombre.Enabled = False
        'ebApellidoPaterno.Enabled = False
        'ebApellidoMaterno.Enabled = False
        ''ebFechaNac.Enabled = False
        'msFechaNac.Enabled = False
        'ebSexo.Enabled = False
        'ebCodAlmacen.Enabled = False
        'ebCodPlaza.Enabled = False
        Me.ebClienteID.Enabled = False
    End Sub

    Private Sub ActivaNoModificables()

        'ebNombre.Enabled = True
        'ebApellidoPaterno.Enabled = True
        'ebApellidoMaterno.Enabled = True
        ''ebFechaNac.Enabled = True
        'msFechaNac.Enabled = True
        'ebSexo.Enabled = True
        'ebCodAlmacen.Enabled = True
        'ebCodPlaza.Enabled = True
        ebClienteID.Focus()
        Me.ebClienteID.Enabled = True

    End Sub

    Private Sub ebCodAlmacen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCodAlmacen.LostFocus
        Me.ebClienteID.Focus()
    End Sub

    Private Sub ebClienteID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteID.GotFocus
        'If Me.ebCodAlmacen.Text <> String.Empty Then
        '    Me.ErrorProvider1.SetError(ebCodAlmacen, "")
        'End If
    End Sub

    Private Sub ebClienteID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebClienteID.Validating

        'If (ebClienteID.Text.Trim = String.Empty) Or (ebClienteID.Text = 0) Then

        '    ebClienteID.Focus()
        '    Return

        'End If

    End Sub

#End Region

#Region "Fiscal Data Methods"



    Private Sub FilldtDFComboCiudades(ByVal CodEstado As Integer)

        Dim dvDFCiudades As DataView = New DataView(dtMunicipio)
        dvDFCiudades.RowFilter = "CodEstado = " & CodEstado & ""

        With ebDFCiudad

            .DropDownList.ClearStructure()

            .DataSource = dvDFCiudades
            .DropDownList.Columns.Add("CodMunicipio")
            .DropDownList.Columns.Add("Ciudad")
            .DropDownList.Columns("CodMunicipio").Visible = False
            .DropDownList.Columns("CodMunicipio").DataMember = "CodMunicipio"
            .DropDownList.Columns("Ciudad").DataMember = "NombreMunicipio"
            .DropDownList.Columns("Ciudad").Width = 180

            .DisplayMember = "NombreMunicipio"
            .ValueMember = "CodMunicipio"

            .Refresh()

        End With

        If oCliente.DFCiudad <> String.Empty Then

            ebDFCiudad.Text = oCliente.DFCiudad

        End If

    End Sub

    Private Sub ebDFCiudad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFCiudad.Validating

        Dim vValueTemp As Integer

        If ebDFCiudad.Text <> "" Then

            vValueTemp = BuscaMunicipio(ebDFCiudad.Text, ebDFEstado.Value)

            If vValueTemp < 0 Then

                MsgBox("Ciudad no se encuentra registrada. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                e.Cancel = True

            Else

                dsCodigosDF = oClienteMgr.GetRange(ebDFEstado.Value, Me.ebDFCiudad.Value).Copy

                rango1DF = CType(dsCodigos.Tables("codigos").Rows(0).Item(0), Integer)
                rango2DF = CType(dsCodigos.Tables("codigos").Rows(0).Item(1), Integer)

                ebDFCiudad.Value = vValueTemp

            End If

        End If
        If sender.text = String.Empty Then
            Me.ErrorProvider1.SetError(sender, "Seleccione un Ciudad")
            e.Cancel = True
        Else
            Me.ErrorProvider1.SetError(sender, "")
        End If
    End Sub

    Private Sub ebDFCP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFCP.Validating

        If ebDFCP.Text <> "" And Not (ebDFCiudad.Value Is Nothing) And Not (ebDFEstado.Value Is Nothing) Then

            If (ebDFCiudad.Value < 0) Or (ebDFEstado.Value < 0) Then

                MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
                ebCP.Text = ""
                e.Cancel = True

            Else

                'If Not (oClienteMgr.GetZipCode(ebEstado.Value, ebCiudad.Value, ebCP.Text)) Then
                If (CType(ebDFCP.Text, Integer) < rango1DF) Or (CType(ebDFCP.Text, Integer) > rango2DF) Then

                    MessageBox.Show("Código postal no corresponde a la ciudad. Código entre " & rango1DF & " y " & rango2DF, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.ErrorProvider1.SetError(ebDFCP, "Entre " & rango1DF & " y " & rango2DF)

                    e.Cancel = True
                Else
                    Me.ErrorProvider1.SetError(ebDFCP, "")

                    oCliente.DFCP = ebDFCP.Text

                End If

            End If

        Else

            ebDFCP.Text = ""

        End If

    End Sub

    Private Sub ebDFEstado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFEstado.Validating

        Dim vValueTemp As Integer

        If ebDFEstado.Text <> "" Then

            If ebDFEstado.Value Is Nothing Then

                vValueTemp = BuscaEstado(ebDFEstado.Text)

                If vValueTemp < 0 Then

                    MsgBox("Estado no se encuentra registrado. No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                    e.Cancel = True

                Else

                    ebDFEstado.Value = vValueTemp

                    FilldtDFComboCiudades(vValueTemp)

                End If

            Else

                FilldtDFComboCiudades(ebDFEstado.Value)

            End If

        Else

            ebDFCiudad.DropDownList.ClearStructure()

        End If

        If sender.text = String.Empty Then
            Me.ErrorProvider1.SetError(sender, "Seleccione un Ciudad")
            e.Cancel = True
        Else
            Me.ErrorProvider1.SetError(sender, "")
        End If
    End Sub

    Private Sub uITab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles uITab1.SelectedTabChanged
        If Me.UiTabPage2.Selected And bandera Then
            If ebDFNombre.Text = String.Empty And Me.ebCiudad.Text <> String.Empty And Me.ebEstado.Text <> String.Empty Then
                Me.ebDFNombre.Text = Me.ebNombre.Text & " " & Me.ebApellidoPaterno.Text & " " & Me.ebApellidoMaterno.Text
                Me.ebDFDireccion.Text = Me.ebDomicilio.Text
                Me.ebDFColonia.Text = Me.ebColonia.Text

                Dim vValueTemp As Integer = BuscaEstado(ebEstado.Text)
                Me.ebDFEstado.Value = vValueTemp

                FilldtDFComboCiudades(vValueTemp)
                Dim vValueTemp2 As Integer = BuscaMunicipio(ebCiudad.Text, ebDFEstado.Value)
                ebDFCiudad.Value = vValueTemp2

                Me.ebDFCP.Text = Me.ebCP.Text

                dsCodigosDF = oClienteMgr.GetRange(ebDFEstado.Value, Me.ebDFCiudad.Value).Copy
                'dsCodigos = oClienteMgr.GetRange(ebEstado.Value, Me.ebCiudad.Value).Copy


                rango1DF = CType(dsCodigosDF.Tables("codigos").Rows(0).Item(0), Integer)
                rango2DF = CType(dsCodigosDF.Tables("codigos").Rows(0).Item(1), Integer)

                If Not oCliente.CedulaFiscal = String.Empty Then
                    Me.ebDFCedulaFiscal.Text = oCliente.CedulaFiscal
                End If




            End If
            bandera = False
        End If
    End Sub

    Private Sub CatalogoClientesForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub msFechaNac_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles msFechaNac.Validating

        If (msFechaNac.Text.Trim = String.Empty) Then

            msFechaNac.Focus()
            Return

        End If


        If msFechaNac.Text <> String.Empty Then

            If IsDate(msFechaNac.Text) Then

                oCliente.FechaNac = CDate(msFechaNac.Text & " 01:00:00")

            Else

                MsgBox("Valor de Fecha Incorrecta. Verifique. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
                msFechaNac.Text = String.Empty
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub ctrlError(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs)

        If Not bandNuevo Then 'Si se precionó el botón nuevo no validamos nada
            If sender.name = "ebCodAlmacen" Then
                If ebCodAlmacen.DropDownList.RowCount > 0 Then
                    If sender.text = String.Empty Then
                        Me.ErrorProvider1.SetError(ebCodAlmacen, "Campo requerido")
                        ebCodAlmacen.Focus()
                        e.Cancel = True
                    Else
                        Me.ErrorProvider1.SetError(ebCodAlmacen, "")
                        Me.ebClienteID.Focus()
                    End If
                Else
                    Me.ErrorProvider1.SetError(ebCodAlmacen, "")
                    Me.ebClienteID.Focus()
                End If
            Else 'Cualquier control menos ebCodAlmacen
                If sender.text = String.Empty Then
                    Me.ErrorProvider1.SetError(sender, "Campo requerido")
                    e.Cancel = True
                Else
                    Me.ErrorProvider1.SetError(sender, "")
                End If
            End If
        Else
            bandNuevo = False 'Regreso el poder de validación
        End If

    End Sub

#End Region

#Region "Validating"

    Private Sub ebCiudad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCiudad.Validating

        If (ebCiudad.Text.Trim = String.Empty) Then

            ebCiudad.Focus()
            Return

        End If


        Dim vValueTemp As Integer

        'If ebCiudad.Value Is Nothing Then

        If ebCiudad.Text <> "" Then

            vValueTemp = BuscaMunicipio(ebCiudad.Text, ebEstado.Value)

            If vValueTemp < 0 Then

                MsgBox("Ciudad no se encuentra registrada. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")

                e.Cancel = True

            Else

                ebCiudad.Value = vValueTemp


                dsCodigos = oClienteMgr.GetRange(ebEstado.Value, Me.ebCiudad.Value).Copy

                rango1 = CType(dsCodigos.Tables("codigos").Rows(0).Item(0), Integer)
                rango2 = CType(dsCodigos.Tables("codigos").Rows(0).Item(1), Integer)

                'MessageBox.Show("Código postal entre " & rango1 & _
                '" y " & rango2, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If

        End If

        ctrlError(sender, e)
    End Sub

    'Private Sub ebCodPlaza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodPlaza.Validating

    '    If Not (ebCodPlaza.Value Is Nothing) Then

    '        FillComboAlmacen(ebCodPlaza.Value)
    '        ebCodAlmacen.Text = oCliente.CodAlmacen

    '    Else

    '        If ebCodPlaza.Text = String.Empty Then

    '            ebCodAlmacen.DropDownList.ClearStructure()
    '            ebCodAlmacen.Text = ""

    '        Else
    '            'Buscamos Plaza
    '            Dim i As Integer

    '            For i = 0 To (dtPlazas.Rows.Count - 1)

    '                If dtPlazas.Rows(i).Item("CodPlaza") = ebCodPlaza.Text Then

    '                    ebCodPlaza.Value = dtPlazas.Rows(i).Item("CodPlaza")
    '                    FillComboAlmacen(ebCodPlaza.Value)
    '                    ebCodAlmacen.Text = oCliente.CodAlmacen
    '                    ebCodAlmacen.Value = Nothing
    '                    Exit Sub

    '                End If

    '            Next

    '            'No se encontro Plaza
    '            MsgBox("Plaza no se encuentra registrada. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
    '            e.Cancel = True

    '        End If

    '    End If

    '    ctrlError(sender, e)

    'End Sub

    'Private Sub ebCodAlmacen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodAlmacen.Validating

    '    If ebCodAlmacen.Text <> "" Then

    '        Dim i As Integer

    '        For i = 0 To (dtAlmacen.Rows.Count - 1)

    '            If dtAlmacen.Rows(i).Item("CodAlmacen") = ebCodAlmacen.Text And dtAlmacen.Rows(i).Item("CodPlaza") = ebCodPlaza.Text Then

    '                ebCodAlmacen.Value = dtAlmacen.Rows(i).Item("CodAlmacen")

    '                Exit Sub

    '            End If

    '        Next

    '        'No se encontro Almacen
    '        MsgBox("Codigo de Almacén no registrado. No Existe.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
    '        ebCodAlmacen.Text = ""
    '        ebCodAlmacen.Value = ""
    '        e.Cancel = True
    '    End If
    '    ctrlError(sender, e)
    'End Sub


    Private Sub ebSexo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebSexo.Validating

        'If ebSexo.Text = "" Then

        '    MsgBox("Ingrese Sexo de Cliente. ", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, " Clientes")

        '    e.Cancel = True

        'End If


        If (ebSexo.Text.Trim = String.Empty) Then

            ebSexo.Focus()
            Return

        End If

    End Sub

    Private Sub ebEstado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEstado.Validating

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

        ctrlError(sender, e)
    End Sub

    Private Sub ebCP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCP.Validating

        If (ebCP.Text.Trim = String.Empty) Then

            ebCP.Focus()
            Return

        End If


        If ebCP.Text <> "" And Not (ebCiudad.Value Is Nothing) And Not (ebEstado.Value Is Nothing) Then

            If (ebCiudad.Value < 0) Or (ebEstado.Value < 0) Then

                MsgBox("Seleccione un Estado/Ciudad válidos.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Clientes")
                ebCP.Text = ""
                e.Cancel = True

            Else

                'If Not (oClienteMgr.GetZipCode(ebEstado.Value, ebCiudad.Value, ebCP.Text)) Then
                If (CType(ebCP.Text, Integer) < rango1) Or (CType(ebCP.Text, Integer) > rango2) Then
                    MessageBox.Show("Código postal no corresponde a la ciudad. Código entre " & rango1 & " y " & rango2, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.ErrorProvider1.SetError(ebCP, "Entre " & rango1 & " y " & rango2)

                    e.Cancel = True
                Else
                    Me.ErrorProvider1.SetError(ebCP, "")
                End If

            End If

        ElseIf ebCP.Text.Equals("") Then

            Me.ErrorProvider1.SetError(ebCP, "Código Postal Requerido")
            e.Cancel = True

        End If

    End Sub

    Private Sub ebApellidoPaterno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebApellidoPaterno.Validating
        'ctrlError(sender, e)

        If (ebApellidoPaterno.Text.Trim = String.Empty) Then

            ebApellidoPaterno.Focus()
            Return

        End If

    End Sub

    Private Sub ebApellidoMaterno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebApellidoMaterno.Validating
        'ctrlError(sender, e)

        If (ebApellidoMaterno.Text.Trim = String.Empty) Then

            ebApellidoMaterno.Focus()
            Return

        End If

    End Sub

    Private Sub ebDomicilio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDomicilio.Validating
        'ctrlError(sender, e)

        If (ebDomicilio.Text.Trim = String.Empty) Then

            ebDomicilio.Focus()
            Return

        End If

    End Sub

    Private Sub ebColonia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebColonia.Validating
        'ctrlError(sender, e)

        If (ebColonia.Text.Trim = String.Empty) Then

            ebColonia.Focus()
            Return

        End If

    End Sub


    Private Sub ebNombre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebNombre.Validating

        'ctrlError(sender, e)
        If (ebNombre.Text.Trim = String.Empty) Then

            ebNombre.Focus()
            Return

        End If

    End Sub

    Private Sub ebDFCedulaFiscal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFCedulaFiscal.Validating
        ctrlError(sender, e)
    End Sub

    Private Sub ebDFColonia_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFColonia.Validating
        ctrlError(sender, e)
    End Sub

    Private Sub ebDFNombre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFNombre.Validating
        ctrlError(sender, e)
    End Sub

    Private Sub ebDFDireccion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebDFDireccion.Validating
        ctrlError(sender, e)
    End Sub
#End Region

#Region "Methods Asociados"

    Public Sub ShowMeforAsociado(ByVal ClienteID As Integer)

        vClienteID = ClienteID

        esInstanciaAsociado = True

        Me.ShowDialog()

    End Sub

    Private Sub LoadDataForAsociado()

        UiCommandBar1.Enabled = False
        UiCommandBar2.Commands("menuArchivoNuevo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuBarTema").Enabled = Janus.Windows.UI.InheritableBoolean.False
        oClienteMgr.LoadInto(vClienteID, oCliente)
        msFechaNac.Text = Format(oCliente.FechaNac, "dd/MM/yyyy")
        ebClienteID.Enabled = False

    End Sub

    Public Sub ShowMeforFactura()

        esInstanciaFactura = True

        Me.ShowDialog()

    End Sub

    Private Sub LoadDataForFactura()

        UiCommandBar1.Enabled = False
        UiCommandBar2.Commands("menuArchivoNuevo").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuArchivoEliminar").Enabled = Janus.Windows.UI.InheritableBoolean.False
        UiCommandBar2.Commands("menuBarTema").Enabled = Janus.Windows.UI.InheritableBoolean.False

    End Sub

#End Region

    Private Sub ebTelefono_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebTelefono.Validating
        If (ebTelefono.Text.Trim = String.Empty) Then

            ebTelefono.Focus()
            Return

        End If
    End Sub

    Private Sub ebEstadoCivil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebEstadoCivil.Validating

        If (ebEstadoCivil.Text.Trim = String.Empty) Then

            ebEstadoCivil.Focus()
            Return

        End If

    End Sub

    Private Sub ebCodPlaza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodPlaza.Validating

        If (ebCodPlaza.Text.Trim = String.Empty) Then

            ebCodPlaza.Focus()
            Return

        End If

    End Sub

    Private Sub ebCodAlmacen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCodAlmacen.Validating

        If (ebCodAlmacen.Text.Trim = String.Empty) Then

            ebCodAlmacen.Focus()
            Return

        End If

    End Sub
End Class
